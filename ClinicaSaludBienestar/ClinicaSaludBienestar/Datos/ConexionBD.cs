
using System;
using Microsoft.Data.SqlClient;

namespace ClinicaSaludBienestar.Datos
{
    public static class ConexionBD
    {
        private const string Servidor =
            "sql-hpa3-grupo1.database.windows.net";

        private const string BaseDatos = "ClinicaDB";
        private const string Usuario = "gio_app";

        public static SqlConnection CrearConexion()
        {
            string clave = Environment.GetEnvironmentVariable(
                "CLINICA_SQL_PASSWORD",
                EnvironmentVariableTarget.User) ?? "";

            if (string.IsNullOrEmpty(clave))
            {
                throw new InvalidOperationException(
                    "No se ha configurado la contraseña de Azure SQL.");
            }

            SqlConnectionStringBuilder configuracion =
                new SqlConnectionStringBuilder();

            configuracion.DataSource = Servidor;
            configuracion.InitialCatalog = BaseDatos;
            configuracion.UserID = Usuario;
            configuracion.Password = clave;
            configuracion.Encrypt = true;
            configuracion.TrustServerCertificate = false;
            configuracion.ConnectTimeout = 30;

            return new SqlConnection(configuracion.ConnectionString);
        }
    }
}
