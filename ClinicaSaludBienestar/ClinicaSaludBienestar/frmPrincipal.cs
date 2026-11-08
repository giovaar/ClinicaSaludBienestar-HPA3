
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public class frmPrincipal : Form
    {
        private readonly Color oscuro = Color.FromArgb(18, 63, 73);
        private readonly Color turquesa = Color.FromArgb(20, 125, 134);
        private readonly Color fondo = Color.FromArgb(240, 247, 247);
        private readonly Color gris = Color.FromArgb(105, 127, 132);

        private Panel panelContenido;

        public frmPrincipal()
        {
            Text = "Clínica Salud y Bienestar | Panel principal";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1150, 730);
            MinimumSize = new Size(1000, 650);
            BackColor = fondo;
            Font = new Font("Segoe UI", 10F);

            CrearInterfaz();
        }

        private void CrearInterfaz()
        {
            // Menú lateral
            Panel lateral = new Panel();
            lateral.Dock = DockStyle.Left;
            lateral.Width = 235;
            lateral.BackColor = oscuro;
            Controls.Add(lateral);

            Label logo = new Label();
            logo.Text = "+  SALUD Y\n    BIENESTAR";
            logo.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            logo.ForeColor = Color.White;
            logo.Location = new Point(22, 35);
            logo.Size = new Size(210, 90);
            lateral.Controls.Add(logo);

            Label subtitulo = new Label();
            subtitulo.Text = "GESTIÓN CLÍNICA";
            subtitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            subtitulo.ForeColor = Color.FromArgb(137, 212, 207);
            subtitulo.Location = new Point(28, 140);
            subtitulo.AutoSize = true;
            lateral.Controls.Add(subtitulo);

            CrearBotonMenu(lateral, "INICIO", 205, true, MostrarInicio);

            CrearBotonMenu(lateral, "PACIENTES", 265, false,
                () => MostrarPendiente("Registro de pacientes"));

            CrearBotonMenu(lateral, "CONSULTAS", 325, false,
                () => MostrarPendiente("Registro de consultas"));

            CrearBotonMenu(lateral, "INFORME GENERAL", 385, false,
                () => MostrarPendiente("Informe general"));

            CrearBotonMenu(lateral, "EVOLUCIÓN IMC", 445, false,
                () => MostrarPendiente("Evolución del IMC"));

            Button btnSalir = new Button();
            btnSalir.Text = "CERRAR SESIÓN";
            btnSalir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir.ForeColor = Color.White;
            btnSalir.BackColor = Color.FromArgb(26, 91, 102);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.Location = new Point(20, 575);
            btnSalir.Size = new Size(195, 45);
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalir.Click += (s, e) => Close();
            lateral.Controls.Add(btnSalir);

            // Área principal
            panelContenido = new Panel();
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.BackColor = fondo;
            panelContenido.AutoScroll = true;
            Controls.Add(panelContenido);
            panelContenido.BringToFront();

            MostrarInicio();
        }

        private void CrearBotonMenu(
            Panel lateral,
            string texto,
            int y,
            bool seleccionado,
            Action accion)
        {
            Button boton = new Button();
            boton.Text = "   " + texto;
            boton.TextAlign = ContentAlignment.MiddleLeft;
            boton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            boton.ForeColor = Color.White;
            boton.BackColor = seleccionado ? turquesa : oscuro;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(30, 108, 119);

            boton.Cursor = Cursors.Hand;
            boton.Location = new Point(12, y);
            boton.Size = new Size(211, 48);
            boton.Click += (s, e) => accion();

            lateral.Controls.Add(boton);
        }

        private void MostrarInicio()
        {
            panelContenido.Controls.Clear();

            Label etiqueta = new Label();
            etiqueta.Text = "PANEL ADMINISTRATIVO  /  INICIO";
            etiqueta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            etiqueta.ForeColor = turquesa;
            etiqueta.Location = new Point(45, 40);
            etiqueta.AutoSize = true;
            panelContenido.Controls.Add(etiqueta);

            Label titulo = new Label();
            titulo.Text = "Bienvenido al sistema";
            titulo.Font = new Font("Segoe UI", 27F, FontStyle.Bold);
            titulo.ForeColor = oscuro;
            titulo.Location = new Point(43, 80);
            titulo.AutoSize = true;
            panelContenido.Controls.Add(titulo);

            Label descripcion = new Label();
            descripcion.Text =
                "Gestiona pacientes, registra consultas y analiza " +
                "su evolución clínica.";
            descripcion.Font = new Font("Segoe UI", 11F);
            descripcion.ForeColor = gris;
            descripcion.Location = new Point(47, 150);
            descripcion.Size = new Size(775, 40);
            panelContenido.Controls.Add(descripcion);

            CrearTarjeta(
                "PACIENTES",
                "Datos personales y registros",
                45, 225,
                () => MostrarPendiente("Registro de pacientes"));

            CrearTarjeta(
                "CONSULTAS",
                "Mediciones y clasificación IMC",
                435, 225,
                () => MostrarPendiente("Registro de consultas"));

            CrearTarjeta(
                "INFORME GENERAL",
                "Estadísticas de la clínica",
                45, 400,
                () => MostrarPendiente("Informe general"));

            CrearTarjeta(
                "EVOLUCIÓN DEL IMC",
                "Historial y tendencias",
                435, 400,
                () => MostrarPendiente("Evolución del IMC"));

            // Botón para probar la conexión SQL
            Button btnProbarBD = new Button();
            btnProbarBD.Name = "btnProbarBD";
            btnProbarBD.Text = "PROBAR CONEXIÓN SQL";
            btnProbarBD.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProbarBD.Size = new Size(230, 42);
            btnProbarBD.Location = new Point(45, 575);
            btnProbarBD.BackColor = turquesa;
            btnProbarBD.ForeColor = Color.White;
            btnProbarBD.FlatStyle = FlatStyle.Flat;
            btnProbarBD.FlatAppearance.BorderSize = 0;
            btnProbarBD.Cursor = Cursors.Hand;
            btnProbarBD.Click += btnProbarBD_Click;
            panelContenido.Controls.Add(btnProbarBD);

            Label pie = new Label();
            pie.Text =
                "Clínica Salud y Bienestar  •  HPA III  •  Grupo 1";
            pie.Font = new Font("Segoe UI", 9F);
            pie.ForeColor = gris;
            pie.Location = new Point(48, 640);
            pie.AutoSize = true;
            panelContenido.Controls.Add(pie);
        }

        private void CrearTarjeta(
            string titulo,
            string descripcion,
            int x,
            int y,
            Action accion)
        {
            Panel tarjeta = new Panel();
            tarjeta.Location = new Point(x, y);
            tarjeta.Size = new Size(350, 145);
            tarjeta.BackColor = Color.White;
            tarjeta.BorderStyle = BorderStyle.FixedSingle;
            tarjeta.Cursor = Cursors.Hand;

            Label lblTitulo = new Label();
            lblTitulo.Text = titulo;
            lblTitulo.Font =
                new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = oscuro;
            lblTitulo.Location = new Point(22, 26);
            lblTitulo.Size = new Size(305, 40);
            tarjeta.Controls.Add(lblTitulo);

            Label lblDescripcion = new Label();
            lblDescripcion.Text = descripcion;
            lblDescripcion.Font = new Font("Segoe UI", 10F);
            lblDescripcion.ForeColor = gris;
            lblDescripcion.Location = new Point(24, 75);
            lblDescripcion.Size = new Size(300, 35);
            tarjeta.Controls.Add(lblDescripcion);

            Label enlace = new Label();
            enlace.Text = "ABRIR  >";
            enlace.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            enlace.ForeColor = turquesa;
            enlace.Location = new Point(24, 115);
            enlace.AutoSize = true;
            tarjeta.Controls.Add(enlace);

            tarjeta.Click += (s, e) => accion();
            lblTitulo.Click += (s, e) => accion();
            lblDescripcion.Click += (s, e) => accion();
            enlace.Click += (s, e) => accion();

            panelContenido.Controls.Add(tarjeta);
        }

        private void MostrarPendiente(string modulo)
        {
            MessageBox.Show(
                "El módulo \"" + modulo +
                "\" se encuentra en desarrollo.",
                "Clínica Salud y Bienestar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Comprobar la conexión con Azure SQL
        private void btnProbarBD_Click(object sender, EventArgs e)
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
                            "Base de datos: ClinicaDB\n" +
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
                    "No se pudo realizar la prueba:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
