
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ClinicaSaludBienestar.Datos
{
    public static class ConexionPruebas
    {
        private const string Servidor =
            "sql-hpa3-grupo1.database.windows.net";

        private const string BaseDatos =
            "ClinicaDB_Pruebas";

        private const string Usuario = "gio_app";

        // Crear conexión a la base de pruebas
        public static SqlConnection CrearConexion()
        {
            string clave = Environment.GetEnvironmentVariable(
                "CLINICA_SQL_PASSWORD",
                EnvironmentVariableTarget.User) ?? "";

            if (string.IsNullOrWhiteSpace(clave))
            {
                throw new InvalidOperationException(
                    "No se encontró la variable " +
                    "CLINICA_SQL_PASSWORD en Windows.");
            }

            SqlConnectionStringBuilder configuracion =
                new SqlConnectionStringBuilder();

            configuracion.DataSource = Servidor;
            configuracion.InitialCatalog = BaseDatos;
            configuracion.UserID = Usuario;
            configuracion.Password = clave;

            // Seguridad de Azure SQL
            configuracion.Encrypt = true;
            configuracion.TrustServerCertificate = false;

            // Configuración de conexión
            configuracion.ConnectTimeout = 60;
            configuracion.ConnectRetryCount = 3;
            configuracion.ConnectRetryInterval = 10;

            return new SqlConnection(
                configuracion.ConnectionString);
        }

        // Verificar que estamos en la base de pruebas
        public static void VerificarBase(
            SqlConnection conexion)
        {
            if (conexion.State != ConnectionState.Open)
            {
                throw new InvalidOperationException(
                    "La conexión SQL no está abierta.");
            }

            using (SqlCommand comando = new SqlCommand(
                "SELECT DB_NAME();", conexion))
            {
                string nombreBase =
                    Convert.ToString(
                        comando.ExecuteScalar()) ?? "";

                if (!string.Equals(
                    nombreBase,
                    BaseDatos,
                    StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(
                        "Operación cancelada. " +
                        "La conexión no corresponde a " +
                        "ClinicaDB_Pruebas.");
                }
            }
        }
    }
}
