
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ClinicaSaludBienestar.Datos
{
    public static class ConexionPruebas
    {
        // Todos los formularios utilizan ClinicaDB
        public static SqlConnection CrearConexion()
        {
            return ConexionBD.CrearConexion();
        }

        // Verificar que estamos conectados a ClinicaDB
        public static void VerificarBase(
            SqlConnection conexion)
        {
            if (conexion.State != ConnectionState.Open)
            {
                throw new InvalidOperationException(
                    "La conexión SQL no está abierta.");
            }

            using (SqlCommand comando =
                new SqlCommand(
                    "SELECT DB_NAME();", conexion))
            {
                string baseActual =
                    Convert.ToString(
                        comando.ExecuteScalar()) ?? "";

                if (baseActual != "ClinicaDB")
                {
                    throw new InvalidOperationException(
                        "Base de datos incorrecta: " +
                        baseActual);
                }
            }
        }
    }
}
