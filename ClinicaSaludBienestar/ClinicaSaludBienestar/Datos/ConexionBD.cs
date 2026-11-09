
using System;
using Microsoft.Data.SqlClient;

namespace ClinicaSaludBienestar.Datos
{
    public static class ConexionBD
    {
        // Datos del servidor Azure SQL
        private const string Servidor =
            "sql-hpa3-grupo1.database.windows.net";

        private const string BaseDatos = "ClinicaDB_Pruebas";

        private const string Usuario = "gio_app";

        // Crear conexión a Azure SQL
        public static SqlConnection CrearConexion()
        {
            string clave = Environment.GetEnvironmentVariable(
                "CLINICA_SQL_PASSWORD",
                EnvironmentVariableTarget.User) ?? "";

            if (string.IsNullOrWhiteSpace(clave))
            {
                throw new InvalidOperationException(
                    "No se ha configurado la contraseña de Azure SQL.");
            }

            // Configurar conexión
            SqlConnectionStringBuilder configuracion =
                new SqlConnectionStringBuilder();

            configuracion.DataSource = Servidor;
            configuracion.InitialCatalog = BaseDatos;
            configuracion.UserID = Usuario;
            configuracion.Password = clave;

            // Seguridad
            configuracion.Encrypt = true;
            configuracion.TrustServerCertificate = false;

            // Tiempo de conexión
            configuracion.ConnectTimeout = 60;

            // Recuperación de conexiones interrumpidas
            configuracion.ConnectRetryCount = 3;
            configuracion.ConnectRetryInterval = 10;

            return new SqlConnection(
                configuracion.ConnectionString);
        }
    }
}
