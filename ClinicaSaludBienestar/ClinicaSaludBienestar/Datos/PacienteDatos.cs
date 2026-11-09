
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ClinicaSaludBienestar.Datos
{
    public static class PacienteDatos
    {
        // Consultar y buscar pacientes
        public static DataTable Consultar(string buscar = "")
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion =
                ConexionPruebas.CrearConexion())
            {
                conexion.Open();
                ConexionPruebas.VerificarBase(conexion);

                string sql = @"
                    SELECT
                        PacienteId,
                        Nombre,
                        Apellido,
                        Genero,
                        FechaNacimiento
                    FROM dbo.Paciente
                    WHERE Nombre LIKE @Buscar
                       OR Apellido LIKE @Buscar
                    ORDER BY PacienteId;";

                using (SqlCommand comando =
                    new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(
                        "@Buscar", SqlDbType.NVarChar, 125
                    ).Value = "%" + buscar.Trim() + "%";

                    using (SqlDataAdapter adaptador =
                        new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        // Agregar paciente
        public static int Agregar(
            string nombre,
            string apellido,
            string genero,
            DateTime fechaNacimiento)
        {
            ValidarPaciente(
                nombre, apellido, genero,
                fechaNacimiento);

            using (SqlConnection conexion =
                ConexionPruebas.CrearConexion())
            {
                conexion.Open();
                ConexionPruebas.VerificarBase(conexion);

                string sql = @"
                    INSERT INTO dbo.Paciente
                        (Nombre, Apellido, Genero,
                         FechaNacimiento)
                    OUTPUT INSERTED.PacienteId
                    VALUES
                        (@Nombre, @Apellido, @Genero,
                         @FechaNacimiento);";

                using (SqlCommand comando =
                    new SqlCommand(sql, conexion))
                {
                    AgregarParametros(
                        comando, nombre, apellido,
                        genero, fechaNacimiento);

                    return Convert.ToInt32(
                        comando.ExecuteScalar());
                }
            }
        }

        // Actualizar paciente
        public static bool Actualizar(
            int pacienteId,
            string nombre,
            string apellido,
            string genero,
            DateTime fechaNacimiento)
        {
            if (pacienteId <= 0)
            {
                throw new ArgumentException(
                    "El ID del paciente no es válido.");
            }

            ValidarPaciente(
                nombre, apellido, genero,
                fechaNacimiento);

            using (SqlConnection conexion =
                ConexionPruebas.CrearConexion())
            {
                conexion.Open();
                ConexionPruebas.VerificarBase(conexion);

                string sql = @"
                    UPDATE dbo.Paciente
                    SET Nombre = @Nombre,
                        Apellido = @Apellido,
                        Genero = @Genero,
                        FechaNacimiento = @FechaNacimiento
                    WHERE PacienteId = @PacienteId;";

                using (SqlCommand comando =
                    new SqlCommand(sql, conexion))
                {
                    AgregarParametros(
                        comando, nombre, apellido,
                        genero, fechaNacimiento);

                    comando.Parameters.Add(
                        "@PacienteId", SqlDbType.Int
                    ).Value = pacienteId;

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        // Eliminar paciente si no tiene consultas
        public static bool Eliminar(int pacienteId)
        {
            if (pacienteId <= 0)
            {
                throw new ArgumentException(
                    "El ID del paciente no es válido.");
            }

            using (SqlConnection conexion =
                ConexionPruebas.CrearConexion())
            {
                conexion.Open();
                ConexionPruebas.VerificarBase(conexion);

                string sql = @"
                    DELETE FROM dbo.Paciente
                    WHERE PacienteId = @PacienteId
                      AND NOT EXISTS
                      (
                          SELECT 1
                          FROM dbo.Consulta
                          WHERE PacienteId = @PacienteId
                      );";

                using (SqlCommand comando =
                    new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(
                        "@PacienteId", SqlDbType.Int
                    ).Value = pacienteId;

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        // Verificar si el paciente tiene consultas
        public static bool TieneConsultas(int pacienteId)
        {
            using (SqlConnection conexion =
                ConexionPruebas.CrearConexion())
            {
                conexion.Open();
                ConexionPruebas.VerificarBase(conexion);

                string sql = @"
                    SELECT COUNT(*)
                    FROM dbo.Consulta
                    WHERE PacienteId = @PacienteId;";

                using (SqlCommand comando =
                    new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(
                        "@PacienteId", SqlDbType.Int
                    ).Value = pacienteId;

                    int total = Convert.ToInt32(
                        comando.ExecuteScalar());

                    return total > 0;
                }
            }
        }

        // Parámetros comunes
        private static void AgregarParametros(
            SqlCommand comando,
            string nombre,
            string apellido,
            string genero,
            DateTime fechaNacimiento)
        {
            comando.Parameters.Add(
                "@Nombre", SqlDbType.NVarChar, 60
            ).Value = nombre.Trim();

            comando.Parameters.Add(
                "@Apellido", SqlDbType.NVarChar, 60
            ).Value = apellido.Trim();

            comando.Parameters.Add(
                "@Genero", SqlDbType.Char, 1
            ).Value = genero;

            comando.Parameters.Add(
                "@FechaNacimiento", SqlDbType.Date
            ).Value = fechaNacimiento.Date;
        }

        // Validaciones
        private static void ValidarPaciente(
            string nombre,
            string apellido,
            string genero,
            DateTime fechaNacimiento)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException(
                    "Debes escribir el nombre.");
            }

            if (string.IsNullOrWhiteSpace(apellido))
            {
                throw new ArgumentException(
                    "Debes escribir el apellido.");
            }

            if (nombre.Trim().Length > 60 ||
                apellido.Trim().Length > 60)
            {
                throw new ArgumentException(
                    "El nombre y apellido deben tener " +
                    "máximo 60 caracteres.");
            }

            if (genero != "M" && genero != "F")
            {
                throw new ArgumentException(
                    "El género debe ser M o F.");
            }

            DateTime fechaCorte =
                new DateTime(2026, 11, 10);

            if (fechaNacimiento.Date >
                fechaCorte.AddYears(-18))
            {
                throw new ArgumentException(
                    "El paciente debe tener al menos " +
                    "18 años al 10/11/2026.");
            }

            if (fechaNacimiento.Date <
                new DateTime(1900, 1, 1))
            {
                throw new ArgumentException(
                    "La fecha de nacimiento no es válida.");
            }
        }
    }
}
