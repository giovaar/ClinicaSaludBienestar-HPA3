using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public class frmPrincipal : Form
    {
        private readonly Color oscuro =
            Color.FromArgb(18, 63, 73);

        private readonly Color turquesa =
            Color.FromArgb(20, 125, 134);

        private readonly Color fondo =
            Color.FromArgb(240, 247, 247);

        private readonly Color gris =
            Color.FromArgb(105, 127, 132);

        private Panel panelContenido = null!;

        public frmPrincipal()
        {
            Text = "Clínica Salud y Bienestar | Panel principal";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1150, 850);
            MinimumSize = new Size(1000, 800);
            BackColor = fondo;
            Font = new Font("Segoe UI", 10F);

            CrearInterfaz();
        }

        // Crear interfaz principal
        private void CrearInterfaz()
        {
            // Panel lateral
            Panel lateral = new Panel();
            lateral.Dock = DockStyle.Left;
            lateral.Width = 235;
            lateral.BackColor = oscuro;
            Controls.Add(lateral);

            // Logo
            Label logo = new Label();
            logo.Text = "+  SALUD Y\n    BIENESTAR";
            logo.Font = new Font(
                "Segoe UI", 17F, FontStyle.Bold);
            logo.ForeColor = Color.White;
            logo.Location = new Point(22, 35);
            logo.Size = new Size(210, 90);
            lateral.Controls.Add(logo);

            // Subtitulo
            Label subtitulo = new Label();
            subtitulo.Text = "GESTIÓN CLÍNICA";
            subtitulo.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            subtitulo.ForeColor =
                Color.FromArgb(137, 212, 207);
            subtitulo.Location = new Point(28, 140);
            subtitulo.AutoSize = true;
            lateral.Controls.Add(subtitulo);

            // Menú lateral
            CrearBotonMenu(
                lateral, "INICIO", 205, true,
                MostrarInicio);

            CrearBotonMenu(
                lateral, "PACIENTES", 265, false,
                AbrirPacientes);

            CrearBotonMenu(
                lateral, "CONSULTAS", 325, false,
                AbrirConsultas);

            CrearBotonMenu(
                lateral, "INFORME GENERAL", 385, false,
                AbrirInformeGeneral);

            CrearBotonMenu(
                lateral, "EVOLUCIÓN IMC", 445, false,
                AbrirEvolucionIMC);

            // Gestión de pacientes
            CrearBotonMenu(
                lateral, "GESTIÓN PACIENTES", 505, false,
                AbrirGestionPacientes);

            // NUEVO: Gestión de consultas
            CrearBotonMenu(
                lateral, "GESTIÓN CONSULTAS", 565, false,
                AbrirGestionConsultas);

            // Cerrar sesión
            Button btnSalir = new Button();
            btnSalir.Name = "btnSalir";
            btnSalir.Text = "CERRAR SESIÓN";
            btnSalir.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            btnSalir.ForeColor = Color.White;
            btnSalir.BackColor =
                Color.FromArgb(26, 91, 102);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.Cursor = Cursors.Hand;

            btnSalir.Dock = DockStyle.Bottom;
            btnSalir.Height = 48;

            btnSalir.Click += (s, e) => Close();
            lateral.Controls.Add(btnSalir);

            // Panel de contenido
            panelContenido = new Panel();
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.BackColor = fondo;
            panelContenido.AutoScroll = true;
            Controls.Add(panelContenido);
            panelContenido.BringToFront();

            MostrarInicio();
        }

        // Crear botones del menú lateral
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
            boton.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            boton.ForeColor = Color.White;

            boton.BackColor =
                seleccionado ? turquesa : oscuro;

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

        // Mostrar pantalla de inicio
        private void MostrarInicio()
        {
            panelContenido.Controls.Clear();

            Label etiqueta = new Label();
            etiqueta.Text =
                "PANEL ADMINISTRATIVO  /  INICIO";
            etiqueta.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            etiqueta.ForeColor = turquesa;
            etiqueta.Location = new Point(45, 40);
            etiqueta.AutoSize = true;
            panelContenido.Controls.Add(etiqueta);

            Label titulo = new Label();
            titulo.Text = "Bienvenido al sistema";
            titulo.Font = new Font(
                "Segoe UI", 27F, FontStyle.Bold);
            titulo.ForeColor = oscuro;
            titulo.Location = new Point(43, 80);
            titulo.AutoSize = true;
            panelContenido.Controls.Add(titulo);

            Label descripcion = new Label();
            descripcion.Text =
                "Gestiona pacientes, registra consultas " +
                "y analiza su evolución clínica.";
            descripcion.Font = new Font("Segoe UI", 11F);
            descripcion.ForeColor = gris;
            descripcion.Location = new Point(47, 150);
            descripcion.Size = new Size(775, 40);
            panelContenido.Controls.Add(descripcion);

            // Tarjeta Pacientes
            CrearTarjeta(
                "PACIENTES",
                "Datos personales y registros",
                45, 225,
                AbrirPacientes);

            // Tarjeta Consultas
            CrearTarjeta(
                "CONSULTAS",
                "Mediciones y clasificación IMC",
                435, 225,
                AbrirConsultas);

            // Tarjeta Informe General
            CrearTarjeta(
                "INFORME GENERAL",
                "Estadísticas de la clínica",
                45, 400,
                AbrirInformeGeneral);

            // Tarjeta Evolución IMC
            CrearTarjeta(
                "EVOLUCIÓN DEL IMC",
                "Historial y tendencias",
                435, 400,
                AbrirEvolucionIMC);

            // Probar conexión SQL
            Button btnProbarBD = new Button();
            btnProbarBD.Name = "btnProbarBD";
            btnProbarBD.Text = "PROBAR CONEXIÓN SQL";
            btnProbarBD.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);

            btnProbarBD.Size = new Size(230, 42);
            btnProbarBD.Location = new Point(45, 575);
            btnProbarBD.BackColor = turquesa;
            btnProbarBD.ForeColor = Color.White;
            btnProbarBD.FlatStyle = FlatStyle.Flat;
            btnProbarBD.FlatAppearance.BorderSize = 0;
            btnProbarBD.Cursor = Cursors.Hand;

            btnProbarBD.Click += btnProbarBD_Click;

            panelContenido.Controls.Add(btnProbarBD);

            // Pie de página
            Label pie = new Label();
            pie.Text =
                "Clínica Salud y Bienestar  •  HPA III  •  Grupo 1";
            pie.Font = new Font("Segoe UI", 9F);
            pie.ForeColor = gris;
            pie.Location = new Point(48, 640);
            pie.AutoSize = true;

            panelContenido.Controls.Add(pie);
        }

        // Crear tarjetas del panel principal
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
            tarjeta.BorderStyle =
                BorderStyle.FixedSingle;
            tarjeta.Cursor = Cursors.Hand;

            Label lblTitulo = new Label();
            lblTitulo.Text = titulo;
            lblTitulo.Font = new Font(
                "Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = oscuro;
            lblTitulo.Location = new Point(22, 26);
            lblTitulo.Size = new Size(305, 40);
            tarjeta.Controls.Add(lblTitulo);

            Label lblDescripcion = new Label();
            lblDescripcion.Text = descripcion;
            lblDescripcion.Font =
                new Font("Segoe UI", 10F);
            lblDescripcion.ForeColor = gris;
            lblDescripcion.Location = new Point(24, 75);
            lblDescripcion.Size = new Size(300, 35);
            tarjeta.Controls.Add(lblDescripcion);

            Label enlace = new Label();
            enlace.Text = "ABRIR  >";
            enlace.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            enlace.ForeColor = turquesa;
            enlace.Location = new Point(24, 115);
            enlace.AutoSize = true;
            tarjeta.Controls.Add(enlace);

            tarjeta.Click += (s, e) => accion();
            lblTitulo.Click += (s, e) => accion();
            lblDescripcion.Click +=
                (s, e) => accion();
            enlace.Click += (s, e) => accion();

            panelContenido.Controls.Add(tarjeta);
        }

        // Abrir Pacientes
        private void AbrirPacientes()
        {
            using (frmPacientes ventana =
                new frmPacientes())
            {
                ventana.ShowDialog(this);
            }
        }

        // Abrir Consultas
        private void AbrirConsultas()
        {
            using (frmConsultas ventana =
                new frmConsultas())
            {
                ventana.ShowDialog(this);
            }
        }

        // Abrir Informe General
        private void AbrirInformeGeneral()
        {
            using (frmInformeGeneral ventana =
                new frmInformeGeneral())
            {
                ventana.ShowDialog(this);
            }
        }

        // Abrir Evolución del IMC
        private void AbrirEvolucionIMC()
        {
            using (frmEvolucionIMC ventana =
                new frmEvolucionIMC())
            {
                ventana.ShowDialog(this);
            }
        }

        // Abrir Gestión de Pacientes
        private void AbrirGestionPacientes()
        {
            using (frmGestionPacientes ventana =
                new frmGestionPacientes())
            {
                ventana.ShowDialog(this);
            }
        }

        // NUEVO: Abrir Gestión de Consultas
        private void AbrirGestionConsultas()
        {
            using (frmGestionConsultas ventana =
                new frmGestionConsultas())
            {
                ventana.ShowDialog(this);
            }
        }

        // Probar conexión con la base oficial
        private void btnProbarBD_Click(
            object? sender,
            EventArgs e)
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
                    "Error de conexión SQL:\n" +
                    ex.Message,
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
