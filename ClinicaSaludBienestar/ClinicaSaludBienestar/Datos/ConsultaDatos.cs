
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ClinicaSaludBienestar.Datos
{
    public static class ConsultaDatos
    {
        private static readonly DateTime FechaCorte =
            new DateTime(2026, 11, 10);

        // Consultar las consultas registradas
        public static DataTable Consultar(int? pacienteId = null)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion =
                ConexionPruebas.CrearConexion())
            {
                conexion.Open();
                ConexionPruebas.VerificarBase(conexion);

                string sql = @"
                    SELECT
                        c.ConsultaId,
                        c.PacienteId,
                        p.Nombre,
                        p.Apellido,
                        c.Fecha,
                        c.Peso,
                        c.Estatura,
                        c.IMC,
                        cat.Nombre AS Categoria
                    FROM dbo.Consulta c
                    INNER JOIN dbo.Paciente p
                        ON c.PacienteId = p.PacienteId
                    INNER JOIN dbo.Categoria cat
                        ON c.CategoriaId = cat.CategoriaId
                    WHERE
                        (@PacienteId IS NULL
                         OR c.PacienteId = @PacienteId)
                    ORDER BY
                        c.Fecha DESC,
                        c.ConsultaId DESC;";

                using (SqlCommand comando =
                    new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(
                        "@PacienteId", SqlDbType.Int
                    ).Value = pacienteId.HasValue
                        ? (object)pacienteId.Value
                        : DBNull.Value;

                    using (SqlDataAdapter adaptador =
                        new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        // Obtener pacientes para un ComboBox
        public static DataTable ObtenerPacientes()
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
                        Nombre + ' ' + Apellido
                            AS NombreCompleto
                    FROM dbo.Paciente
                    ORDER BY Apellido, Nombre, PacienteId;";

                using (SqlCommand comando =
                    new SqlCommand(sql, conexion))
                using (SqlDataAdapter adaptador =
                    new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }

        // Registrar una consulta
        public static int Agregar(
            int pacienteId,
            DateTime fecha,
            decimal peso,
            decimal estatura)
        {
            ValidarMediciones(
                pacienteId, fecha, peso, estatura);

            decimal imc = CalcularIMC(peso, estatura);

            using (SqlConnection conexion =
                ConexionPruebas.CrearConexion())
            {
                conexion.Open();
                ConexionPruebas.VerificarBase(conexion);

                using (SqlTransaction transaccion =
                    conexion.BeginTransaction())
                {
                    ValidarPacienteYFecha(
                        conexion, transaccion,
                        pacienteId, fecha);

                    int categoriaId = ObtenerCategoria(
                        conexion, transaccion, imc);

                    string sql = @"
                        INSERT INTO dbo.Consulta
                            (PacienteId, Fecha, Peso,
                             Estatura, IMC, CategoriaId)
                        OUTPUT INSERTED.ConsultaId
                        VALUES
                            (@PacienteId, @Fecha, @Peso,
                             @Estatura, @IMC, @CategoriaId);";

                    int consultaId;

                    using (SqlCommand comando =
                        new SqlCommand(
                            sql, conexion, transaccion))
                    {
                        AgregarParametros(
                            comando,
                            pacienteId,
                            fecha,
                            peso,
                            estatura,
                            imc,
                            categoriaId);

                        consultaId = Convert.ToInt32(
                            comando.ExecuteScalar());
                    }

                    transaccion.Commit();

                    return consultaId;
                }
            }
        }

        // Actualizar una consulta
        public static bool Actualizar(
            int consultaId,
            int pacienteId,
            DateTime fecha,
            decimal peso,
            decimal estatura)
        {
            if (consultaId <= 0)
            {
                throw new ArgumentException(
                    "El ID de la consulta no es válido.");
            }

            ValidarMediciones(
                pacienteId, fecha, peso, estatura);

            decimal imc = CalcularIMC(peso, estatura);

            using (SqlConnection conexion =
                ConexionPruebas.CrearConexion())
            {
                conexion.Open();
                ConexionPruebas.VerificarBase(conexion);

                using (SqlTransaction transaccion =
                    conexion.BeginTransaction())
                {
                    ValidarPacienteYFecha(
                        conexion, transaccion,
                        pacienteId, fecha);

                    int categoriaId = ObtenerCategoria(
                        conexion, transaccion, imc);

                    string sql = @"
                        UPDATE dbo.Consulta
                        SET PacienteId = @PacienteId,
                            Fecha = @Fecha,
                            Peso = @Peso,
                            Estatura = @Estatura,
                            IMC = @IMC,
                            CategoriaId = @CategoriaId
                        WHERE ConsultaId = @ConsultaId;";

                    int filas;

                    using (SqlCommand comando =
                        new SqlCommand(
                            sql, conexion, transaccion))
                    {
                        AgregarParametros(
                            comando,
                            pacienteId,
                            fecha,
                            peso,
                            estatura,
                            imc,
                            categoriaId);

                        comando.Parameters.Add(
                            "@ConsultaId", SqlDbType.Int
                        ).Value = consultaId;

                        filas = comando.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    return filas > 0;
                }
            }
        }

        // Eliminar una consulta
        public static bool Eliminar(int consultaId)
        {
            if (consultaId <= 0)
            {
                throw new ArgumentException(
                    "El ID de la consulta no es válido.");
            }

            using (SqlConnection conexion =
                ConexionPruebas.CrearConexion())
            {
                conexion.Open();
                ConexionPruebas.VerificarBase(conexion);

                string sql = @"
                    DELETE FROM dbo.Consulta
                    WHERE ConsultaId = @ConsultaId;";

                using (SqlCommand comando =
                    new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(
                        "@ConsultaId", SqlDbType.Int
                    ).Value = consultaId;

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        // Calcular el IMC con un decimal
        public static decimal CalcularIMC(
            decimal peso,
            decimal estatura)
        {
            if (peso <= 0 || estatura <= 0)
            {
                throw new ArgumentException(
                    "El peso y la estatura deben ser positivos.");
            }

            decimal imc =
                peso / (estatura * estatura);

            return Math.Round(
                imc, 1,
                MidpointRounding.AwayFromZero);
        }

        // Obtener categoría desde Azure SQL
        private static int ObtenerCategoria(
            SqlConnection conexion,
            SqlTransaction transaccion,
            decimal imc)
        {
            string sql = @"
                SELECT TOP (1) CategoriaId
                FROM dbo.Categoria
                WHERE LimiteInferior IS NULL
                   OR LimiteInferior <= @IMC
                ORDER BY
                    CASE
                        WHEN LimiteInferior IS NULL
                        THEN 1
                        ELSE 0
                    END,
                    LimiteInferior DESC;";

            using (SqlCommand comando =
                new SqlCommand(
                    sql, conexion, transaccion))
            {
                SqlParameter parametro =
                    comando.Parameters.Add(
                        "@IMC", SqlDbType.Decimal);

                parametro.Precision = 5;
                parametro.Scale = 1;
                parametro.Value = imc;

                object? resultado =
                    comando.ExecuteScalar();

                if (resultado == null ||
                    resultado == DBNull.Value)
                {
                    throw new InvalidOperationException(
                        "No se encontró una categoría de IMC.");
                }

                return Convert.ToInt32(resultado);
            }
        }

        // Verificar existencia del paciente
        // y fecha válida para su consulta
        private static void ValidarPacienteYFecha(
            SqlConnection conexion,
            SqlTransaction transaccion,
            int pacienteId,
            DateTime fecha)
        {
            string sql = @"
                SELECT FechaNacimiento
                FROM dbo.Paciente
                WHERE PacienteId = @PacienteId;";

            using (SqlCommand comando =
                new SqlCommand(
                    sql, conexion, transaccion))
            {
                comando.Parameters.Add(
                    "@PacienteId", SqlDbType.Int
                ).Value = pacienteId;

                object? resultado =
                    comando.ExecuteScalar();

                if (resultado == null ||
                    resultado == DBNull.Value)
                {
                    throw new ArgumentException(
                        "El paciente seleccionado no existe.");
                }

                DateTime nacimiento =
                    Convert.ToDateTime(resultado);

                if (fecha.Date < nacimiento.Date)
                {
                    throw new ArgumentException(
                        "La consulta no puede ser anterior " +
                        "a la fecha de nacimiento.");
                }
            }
        }

        // Agregar parámetros SQL
        private static void AgregarParametros(
            SqlCommand comando,
            int pacienteId,
            DateTime fecha,
            decimal peso,
            decimal estatura,
            decimal imc,
            int categoriaId)
        {
            comando.Parameters.Add(
                "@PacienteId", SqlDbType.Int
            ).Value = pacienteId;

            comando.Parameters.Add(
                "@Fecha", SqlDbType.Date
            ).Value = fecha.Date;

            SqlParameter parametroPeso =
                comando.Parameters.Add(
                    "@Peso", SqlDbType.Decimal);

            parametroPeso.Precision = 6;
            parametroPeso.Scale = 2;
            parametroPeso.Value = peso;

            SqlParameter parametroEstatura =
                comando.Parameters.Add(
                    "@Estatura", SqlDbType.Decimal);

            parametroEstatura.Precision = 4;
            parametroEstatura.Scale = 2;
            parametroEstatura.Value = estatura;

            SqlParameter parametroIMC =
                comando.Parameters.Add(
                    "@IMC", SqlDbType.Decimal);

            parametroIMC.Precision = 5;
            parametroIMC.Scale = 1;
            parametroIMC.Value = imc;

            comando.Parameters.Add(
                "@CategoriaId", SqlDbType.Int
            ).Value = categoriaId;
        }

        // Validar campos de la consulta
        private static void ValidarMediciones(
            int pacienteId,
            DateTime fecha,
            decimal peso,
            decimal estatura)
        {
            if (pacienteId <= 0)
            {
                throw new ArgumentException(
                    "Selecciona un paciente válido.");
            }

            if (fecha.Date < new DateTime(1900, 1, 1) ||
                fecha.Date > FechaCorte)
            {
                throw new ArgumentException(
                    "La fecha debe estar entre " +
                    "01/01/1900 y 10/11/2026.");
            }

            if (peso < 1m || peso > 500m)
            {
                throw new ArgumentException(
                    "El peso debe estar entre 1 y 500 kg.");
            }

            if (estatura < 0.50m || estatura > 2.50m)
            {
                throw new ArgumentException(
                    "La estatura debe estar " +
                    "entre 0.50 y 2.50 metros.");
            }

            if (decimal.Round(peso, 2) != peso ||
                decimal.Round(estatura, 2) != estatura)
            {
                throw new ArgumentException(
                    "El peso y la estatura admiten " +
                    "máximo dos decimales.");
            }

            decimal imc = CalcularIMC(peso, estatura);

            if (imc > 999.9m)
            {
                throw new ArgumentException(
                    "El IMC supera el rango permitido.");
            }
        }
    }
}
