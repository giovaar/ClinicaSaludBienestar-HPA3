
using System;
using Microsoft.Data.SqlClient;

namespace ClinicaSaludBienestar.Datos
{
    public static class ConexionBD
    {
        // Servidor de Azure SQL
        private const string Servidor =
            "sql-hpa3-grupo1.database.windows.net";

        // Única base de datos del proyecto
        private const string BaseDatos = "ClinicaDB";

        // Usuario de Azure SQL
        private const string Usuario = "gio_app";

        // Crear conexión
        public static SqlConnection CrearConexion()
        {
            // Obtener contraseña de Windows
            string clave = Environment.GetEnvironmentVariable(
                "CLINICA_SQL_PASSWORD",
                EnvironmentVariableTarget.User) ?? "";

            if (string.IsNullOrWhiteSpace(clave))
            {
                throw new InvalidOperationException(
                    "No se ha configurado la contraseña " +
                    "de Azure SQL en Windows.");
            }

            SqlConnectionStringBuilder configuracion =
                new SqlConnectionStringBuilder();

            configuracion.DataSource = Servidor;
            configuracion.InitialCatalog = BaseDatos;
            configuracion.UserID = Usuario;
            configuracion.Password = clave;

            // Configuración de seguridad
            configuracion.Encrypt = true;
            configuracion.TrustServerCertificate = false;

            // Tiempo de espera
            configuracion.ConnectTimeout = 60;

            // Reintentos de conexión
            configuracion.ConnectRetryCount = 3;
            configuracion.ConnectRetryInterval = 10;

            return new SqlConnection(
                configuracion.ConnectionString);
        }
    }
}
