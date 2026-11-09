
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            btnInicio.Click += (s, e) => MostrarInicio();

            btnPacientes.Click +=
                (s, e) => AbrirPacientes();

            btnConsultas.Click +=
                (s, e) => AbrirConsultas();

            btnInforme.Click +=
                (s, e) => AbrirInformeGeneral();

            btnEvolucion.Click +=
                (s, e) => AbrirEvolucionIMC();

            btnGestionPacientes.Click +=
                (s, e) => AbrirGestionPacientes();

            btnGestionConsultas.Click +=
                (s, e) => AbrirGestionConsultas();

            btnSalir.Click += (s, e) => Close();

            btnProbarBD.Click += btnProbarBD_Click;

            pnlTarjetaPacientes.Click +=
                (s, e) => AbrirPacientes();

            lblTarjetaPacientes.Click +=
                (s, e) => AbrirPacientes();

            lblDescripcionPacientes.Click +=
                (s, e) => AbrirPacientes();

            lblAbrirPacientes.Click +=
                (s, e) => AbrirPacientes();

            pnlTarjetaConsultas.Click +=
                (s, e) => AbrirConsultas();

            lblTarjetaConsultas.Click +=
                (s, e) => AbrirConsultas();

            lblDescripcionConsultas.Click +=
                (s, e) => AbrirConsultas();

            lblAbrirConsultas.Click +=
                (s, e) => AbrirConsultas();

            pnlTarjetaInforme.Click +=
                (s, e) => AbrirInformeGeneral();

            lblTarjetaInforme.Click +=
                (s, e) => AbrirInformeGeneral();

            lblDescripcionInforme.Click +=
                (s, e) => AbrirInformeGeneral();

            lblAbrirInforme.Click +=
                (s, e) => AbrirInformeGeneral();

            pnlTarjetaEvolucion.Click +=
                (s, e) => AbrirEvolucionIMC();

            lblTarjetaEvolucion.Click +=
                (s, e) => AbrirEvolucionIMC();

            lblDescripcionEvolucion.Click +=
                (s, e) => AbrirEvolucionIMC();

            lblAbrirEvolucion.Click +=
                (s, e) => AbrirEvolucionIMC();
        }

        private void MostrarInicio()
        {
            pnlContenido.AutoScrollPosition =
                new System.Drawing.Point(0, 0);
        }

        private void AbrirPacientes()
        {
            using (frmPacientes ventana =
                new frmPacientes())
            {
                ventana.ShowDialog(this);
            }
        }

        private void AbrirConsultas()
        {
            using (frmConsultas ventana =
                new frmConsultas())
            {
                ventana.ShowDialog(this);
            }
        }

        private void AbrirInformeGeneral()
        {
            using (frmInformeGeneral ventana =
                new frmInformeGeneral())
            {
                ventana.ShowDialog(this);
            }
        }

        private void AbrirEvolucionIMC()
        {
            using (frmEvolucionIMC ventana =
                new frmEvolucionIMC())
            {
                ventana.ShowDialog(this);
            }
        }

        private void AbrirGestionPacientes()
        {
            using (frmGestionPacientes ventana =
                new frmGestionPacientes())
            {
                ventana.ShowDialog(this);
            }
        }

        private void AbrirGestionConsultas()
        {
            using (frmGestionConsultas ventana =
                new frmGestionConsultas())
            {
                ventana.ShowDialog(this);
            }
        }

        private void btnProbarBD_Click(
            object? sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion =
                    ConexionBD.CrearConexion())
                {
                    conexion.Open();

                    string sql =
                        "SELECT COUNT(*) FROM dbo.Paciente";

                    using (SqlCommand comando =
                        new SqlCommand(sql, conexion))
                    {
                        int total = Convert.ToInt32(
                            comando.ExecuteScalar());

                        MessageBox.Show(
                            "Conexión exitosa con Azure SQL.\n" +
                            "Base de datos: " +
                            conexion.Database + "\n" +
                            "Pacientes registrados: " + total,
                            "Conexión correcta",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Error de conexión SQL:\n" + ex.Message,
                    "Error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo realizar la prueba:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
