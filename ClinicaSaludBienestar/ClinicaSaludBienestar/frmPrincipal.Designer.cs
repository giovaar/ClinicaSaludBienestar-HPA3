
#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicaSaludBienestar
{
    partial class frmPrincipal
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlMenu = null!;
        private Panel pnlContenido = null!;

        private Label lblLogo = null!;
        private Label lblSubtitulo = null!;

        private Button btnInicio = null!;
        private Button btnPacientes = null!;
        private Button btnConsultas = null!;
        private Button btnInforme = null!;
        private Button btnEvolucion = null!;
        private Button btnGestionPacientes = null!;
        private Button btnGestionConsultas = null!;
        private Button btnSalir = null!;

        private Label lblRuta = null!;
        private Label lblTitulo = null!;
        private Label lblDescripcion = null!;
        private Label lblPie = null!;

        private Panel pnlTarjetaPacientes = null!;
        private Panel pnlTarjetaConsultas = null!;
        private Panel pnlTarjetaInforme = null!;
        private Panel pnlTarjetaEvolucion = null!;

        private Label lblTarjetaPacientes = null!;
        private Label lblTarjetaConsultas = null!;
        private Label lblTarjetaInforme = null!;
        private Label lblTarjetaEvolucion = null!;

        private Label lblDescripcionPacientes = null!;
        private Label lblDescripcionConsultas = null!;
        private Label lblDescripcionInforme = null!;
        private Label lblDescripcionEvolucion = null!;

        private Label lblAbrirPacientes = null!;
        private Label lblAbrirConsultas = null!;
        private Label lblAbrirInforme = null!;
        private Label lblAbrirEvolucion = null!;

        private Button btnProbarBD = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMenu = new Panel();
            pnlContenido = new Panel();

            lblLogo = new Label();
            lblSubtitulo = new Label();

            btnInicio = new Button();
            btnPacientes = new Button();
            btnConsultas = new Button();
            btnInforme = new Button();
            btnEvolucion = new Button();
            btnGestionPacientes = new Button();
            btnGestionConsultas = new Button();
            btnSalir = new Button();

            lblRuta = new Label();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            lblPie = new Label();

            pnlTarjetaPacientes = new Panel();
            pnlTarjetaConsultas = new Panel();
            pnlTarjetaInforme = new Panel();
            pnlTarjetaEvolucion = new Panel();

            lblTarjetaPacientes = new Label();
            lblTarjetaConsultas = new Label();
            lblTarjetaInforme = new Label();
            lblTarjetaEvolucion = new Label();

            lblDescripcionPacientes = new Label();
            lblDescripcionConsultas = new Label();
            lblDescripcionInforme = new Label();
            lblDescripcionEvolucion = new Label();

            lblAbrirPacientes = new Label();
            lblAbrirConsultas = new Label();
            lblAbrirInforme = new Label();
            lblAbrirEvolucion = new Label();

            btnProbarBD = new Button();

            pnlMenu.SuspendLayout();
            pnlContenido.SuspendLayout();
            pnlTarjetaPacientes.SuspendLayout();
            pnlTarjetaConsultas.SuspendLayout();
            pnlTarjetaInforme.SuspendLayout();
            pnlTarjetaEvolucion.SuspendLayout();
            SuspendLayout();

            // FORMULARIO
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 811);
            MinimumSize = new Size(1000, 800);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clínica Salud y Bienestar | Panel principal";
            Font = new Font("Segoe UI", 10F);
            BackColor = Color.FromArgb(240, 247, 247);
            Name = "frmPrincipal";

            // PANEL LATERAL
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Width = 235;
            pnlMenu.BackColor = Color.FromArgb(18, 63, 73);

            // LOGO
            lblLogo.Name = "lblLogo";
            lblLogo.Text = "+  SALUD Y\n    BIENESTAR";
            lblLogo.Font = new Font(
                "Segoe UI", 17F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(22, 35);
            lblLogo.Size = new Size(210, 90);

            // SUBTÍTULO
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Text = "GESTIÓN CLÍNICA";
            lblSubtitulo.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            lblSubtitulo.ForeColor =
                Color.FromArgb(137, 212, 207);
            lblSubtitulo.Location = new Point(28, 140);
            lblSubtitulo.AutoSize = true;

            // INICIO
            btnInicio.Name = "btnInicio";
            btnInicio.Text = "   INICIO";
            btnInicio.TextAlign =
                ContentAlignment.MiddleLeft;
            btnInicio.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            btnInicio.ForeColor = Color.White;
            btnInicio.BackColor =
                Color.FromArgb(20, 125, 134);
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.Cursor = Cursors.Hand;
            btnInicio.Location = new Point(12, 205);
            btnInicio.Size = new Size(211, 48);

            // PACIENTES
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Text = "   PACIENTES";
            btnPacientes.TextAlign =
                ContentAlignment.MiddleLeft;
            btnPacientes.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            btnPacientes.ForeColor = Color.White;
            btnPacientes.BackColor =
                Color.FromArgb(18, 63, 73);
            btnPacientes.FlatStyle = FlatStyle.Flat;
            btnPacientes.FlatAppearance.BorderSize = 0;
            btnPacientes.Cursor = Cursors.Hand;
            btnPacientes.Location = new Point(12, 265);
            btnPacientes.Size = new Size(211, 48);

            // CONSULTAS
            btnConsultas.Name = "btnConsultas";
            btnConsultas.Text = "   CONSULTAS";
            btnConsultas.TextAlign =
                ContentAlignment.MiddleLeft;
            btnConsultas.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            btnConsultas.ForeColor = Color.White;
            btnConsultas.BackColor =
                Color.FromArgb(18, 63, 73);
            btnConsultas.FlatStyle = FlatStyle.Flat;
            btnConsultas.FlatAppearance.BorderSize = 0;
            btnConsultas.Cursor = Cursors.Hand;
            btnConsultas.Location = new Point(12, 325);
            btnConsultas.Size = new Size(211, 48);

            // INFORME GENERAL
            btnInforme.Name = "btnInforme";
            btnInforme.Text = "   INFORME GENERAL";
            btnInforme.TextAlign =
                ContentAlignment.MiddleLeft;
            btnInforme.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            btnInforme.ForeColor = Color.White;
            btnInforme.BackColor =
                Color.FromArgb(18, 63, 73);
            btnInforme.FlatStyle = FlatStyle.Flat;
            btnInforme.FlatAppearance.BorderSize = 0;
            btnInforme.Cursor = Cursors.Hand;
            btnInforme.Location = new Point(12, 385);
            btnInforme.Size = new Size(211, 48);

            // EVOLUCIÓN IMC
            btnEvolucion.Name = "btnEvolucion";
            btnEvolucion.Text = "   EVOLUCIÓN IMC";
            btnEvolucion.TextAlign =
                ContentAlignment.MiddleLeft;
            btnEvolucion.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            btnEvolucion.ForeColor = Color.White;
            btnEvolucion.BackColor =
                Color.FromArgb(18, 63, 73);
            btnEvolucion.FlatStyle = FlatStyle.Flat;
            btnEvolucion.FlatAppearance.BorderSize = 0;
            btnEvolucion.Cursor = Cursors.Hand;
            btnEvolucion.Location = new Point(12, 445);
            btnEvolucion.Size = new Size(211, 48);

            // GESTIÓN PACIENTES
            btnGestionPacientes.Name =
                "btnGestionPacientes";
            btnGestionPacientes.Text =
                "   GESTIÓN PACIENTES";
            btnGestionPacientes.TextAlign =
                ContentAlignment.MiddleLeft;
            btnGestionPacientes.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            btnGestionPacientes.ForeColor = Color.White;
            btnGestionPacientes.BackColor =
                Color.FromArgb(18, 63, 73);
            btnGestionPacientes.FlatStyle = FlatStyle.Flat;
            btnGestionPacientes.FlatAppearance.BorderSize = 0;
            btnGestionPacientes.Cursor = Cursors.Hand;
            btnGestionPacientes.Location =
                new Point(12, 505);
            btnGestionPacientes.Size = new Size(211, 48);

            // GESTIÓN CONSULTAS
            btnGestionConsultas.Name =
                "btnGestionConsultas";
            btnGestionConsultas.Text =
                "   GESTIÓN CONSULTAS";
            btnGestionConsultas.TextAlign =
                ContentAlignment.MiddleLeft;
            btnGestionConsultas.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            btnGestionConsultas.ForeColor = Color.White;
            btnGestionConsultas.BackColor =
                Color.FromArgb(18, 63, 73);
            btnGestionConsultas.FlatStyle = FlatStyle.Flat;
            btnGestionConsultas.FlatAppearance.BorderSize = 0;
            btnGestionConsultas.Cursor = Cursors.Hand;
            btnGestionConsultas.Location =
                new Point(12, 565);
            btnGestionConsultas.Size = new Size(211, 48);

            // CERRAR SESIÓN
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

            // AGREGAR ELEMENTOS AL MENÚ
            pnlMenu.Controls.Add(lblLogo);
            pnlMenu.Controls.Add(lblSubtitulo);
            pnlMenu.Controls.Add(btnInicio);
            pnlMenu.Controls.Add(btnPacientes);
            pnlMenu.Controls.Add(btnConsultas);
            pnlMenu.Controls.Add(btnInforme);
            pnlMenu.Controls.Add(btnEvolucion);
            pnlMenu.Controls.Add(btnGestionPacientes);
            pnlMenu.Controls.Add(btnGestionConsultas);
            pnlMenu.Controls.Add(btnSalir);

            // PANEL DE CONTENIDO
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.AutoScroll = true;
            pnlContenido.BackColor =
                Color.FromArgb(240, 247, 247);

            // RUTA
            lblRuta.Name = "lblRuta";
            lblRuta.Text =
                "PANEL ADMINISTRATIVO  /  INICIO";
            lblRuta.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            lblRuta.ForeColor =
                Color.FromArgb(20, 125, 134);
            lblRuta.Location = new Point(45, 40);
            lblRuta.AutoSize = true;

            // TÍTULO
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Bienvenido al sistema";
            lblTitulo.Font = new Font(
                "Segoe UI", 27F, FontStyle.Bold);
            lblTitulo.ForeColor =
                Color.FromArgb(18, 63, 73);
            lblTitulo.Location = new Point(43, 80);
            lblTitulo.AutoSize = true;

            // DESCRIPCIÓN
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Text =
                "Gestiona pacientes, registra consultas " +
                "y analiza su evolución clínica.";
            lblDescripcion.Font =
                new Font("Segoe UI", 11F);
            lblDescripcion.ForeColor =
                Color.FromArgb(105, 127, 132);
            lblDescripcion.Location =
                new Point(47, 150);
            lblDescripcion.Size = new Size(775, 40);

            // TARJETA PACIENTES
            pnlTarjetaPacientes.Name =
                "pnlTarjetaPacientes";
            pnlTarjetaPacientes.Location =
                new Point(45, 225);
            pnlTarjetaPacientes.Size =
                new Size(350, 145);
            pnlTarjetaPacientes.BackColor = Color.White;
            pnlTarjetaPacientes.BorderStyle =
                BorderStyle.FixedSingle;
            pnlTarjetaPacientes.Cursor = Cursors.Hand;

            lblTarjetaPacientes.Name =
                "lblTarjetaPacientes";
            lblTarjetaPacientes.Text = "PACIENTES";
            lblTarjetaPacientes.Font = new Font(
                "Segoe UI", 14F, FontStyle.Bold);
            lblTarjetaPacientes.ForeColor =
                Color.FromArgb(18, 63, 73);
            lblTarjetaPacientes.Location =
                new Point(22, 26);
            lblTarjetaPacientes.Size =
                new Size(305, 40);

            lblDescripcionPacientes.Name =
                "lblDescripcionPacientes";
            lblDescripcionPacientes.Text =
                "Datos personales y registros";
            lblDescripcionPacientes.Font =
                new Font("Segoe UI", 10F);
            lblDescripcionPacientes.ForeColor =
                Color.FromArgb(105, 127, 132);
            lblDescripcionPacientes.Location =
                new Point(24, 75);
            lblDescripcionPacientes.Size =
                new Size(300, 35);

            lblAbrirPacientes.Name =
                "lblAbrirPacientes";
            lblAbrirPacientes.Text = "ABRIR  >";
            lblAbrirPacientes.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            lblAbrirPacientes.ForeColor =
                Color.FromArgb(20, 125, 134);
            lblAbrirPacientes.Location =
                new Point(24, 115);
            lblAbrirPacientes.AutoSize = true;

            pnlTarjetaPacientes.Controls.Add(
                lblTarjetaPacientes);
            pnlTarjetaPacientes.Controls.Add(
                lblDescripcionPacientes);
            pnlTarjetaPacientes.Controls.Add(
                lblAbrirPacientes);

            // TARJETA CONSULTAS
            pnlTarjetaConsultas.Name =
                "pnlTarjetaConsultas";
            pnlTarjetaConsultas.Location =
                new Point(435, 225);
            pnlTarjetaConsultas.Size =
                new Size(350, 145);
            pnlTarjetaConsultas.BackColor = Color.White;
            pnlTarjetaConsultas.BorderStyle =
                BorderStyle.FixedSingle;
            pnlTarjetaConsultas.Cursor = Cursors.Hand;

            lblTarjetaConsultas.Name =
                "lblTarjetaConsultas";
            lblTarjetaConsultas.Text = "CONSULTAS";
            lblTarjetaConsultas.Font = new Font(
                "Segoe UI", 14F, FontStyle.Bold);
            lblTarjetaConsultas.ForeColor =
                Color.FromArgb(18, 63, 73);
            lblTarjetaConsultas.Location =
                new Point(22, 26);
            lblTarjetaConsultas.Size =
                new Size(305, 40);

            lblDescripcionConsultas.Name =
                "lblDescripcionConsultas";
            lblDescripcionConsultas.Text =
                "Mediciones y clasificación IMC";
            lblDescripcionConsultas.Font =
                new Font("Segoe UI", 10F);
            lblDescripcionConsultas.ForeColor =
                Color.FromArgb(105, 127, 132);
            lblDescripcionConsultas.Location =
                new Point(24, 75);
            lblDescripcionConsultas.Size =
                new Size(300, 35);

            lblAbrirConsultas.Name =
                "lblAbrirConsultas";
            lblAbrirConsultas.Text = "ABRIR  >";
            lblAbrirConsultas.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            lblAbrirConsultas.ForeColor =
                Color.FromArgb(20, 125, 134);
            lblAbrirConsultas.Location =
                new Point(24, 115);
            lblAbrirConsultas.AutoSize = true;

            pnlTarjetaConsultas.Controls.Add(
                lblTarjetaConsultas);
            pnlTarjetaConsultas.Controls.Add(
                lblDescripcionConsultas);
            pnlTarjetaConsultas.Controls.Add(
                lblAbrirConsultas);

            // TARJETA INFORME GENERAL
            pnlTarjetaInforme.Name = "pnlTarjetaInforme";
            pnlTarjetaInforme.Location =
                new Point(45, 400);
            pnlTarjetaInforme.Size =
                new Size(350, 145);
            pnlTarjetaInforme.BackColor = Color.White;
            pnlTarjetaInforme.BorderStyle =
                BorderStyle.FixedSingle;
            pnlTarjetaInforme.Cursor = Cursors.Hand;

            lblTarjetaInforme.Name = "lblTarjetaInforme";
            lblTarjetaInforme.Text = "INFORME GENERAL";
            lblTarjetaInforme.Font = new Font(
                "Segoe UI", 14F, FontStyle.Bold);
            lblTarjetaInforme.ForeColor =
                Color.FromArgb(18, 63, 73);
            lblTarjetaInforme.Location =
                new Point(22, 26);
            lblTarjetaInforme.Size =
                new Size(305, 40);

            lblDescripcionInforme.Name =
                "lblDescripcionInforme";
            lblDescripcionInforme.Text =
                "Estadísticas de la clínica";
            lblDescripcionInforme.Font =
                new Font("Segoe UI", 10F);
            lblDescripcionInforme.ForeColor =
                Color.FromArgb(105, 127, 132);
            lblDescripcionInforme.Location =
                new Point(24, 75);
            lblDescripcionInforme.Size =
                new Size(300, 35);

            lblAbrirInforme.Name = "lblAbrirInforme";
            lblAbrirInforme.Text = "ABRIR  >";
            lblAbrirInforme.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            lblAbrirInforme.ForeColor =
                Color.FromArgb(20, 125, 134);
            lblAbrirInforme.Location =
                new Point(24, 115);
            lblAbrirInforme.AutoSize = true;

            pnlTarjetaInforme.Controls.Add(
                lblTarjetaInforme);
            pnlTarjetaInforme.Controls.Add(
                lblDescripcionInforme);
            pnlTarjetaInforme.Controls.Add(
                lblAbrirInforme);

            // TARJETA EVOLUCIÓN IMC
            pnlTarjetaEvolucion.Name =
                "pnlTarjetaEvolucion";
            pnlTarjetaEvolucion.Location =
                new Point(435, 400);
            pnlTarjetaEvolucion.Size =
                new Size(350, 145);
            pnlTarjetaEvolucion.BackColor = Color.White;
            pnlTarjetaEvolucion.BorderStyle =
                BorderStyle.FixedSingle;
            pnlTarjetaEvolucion.Cursor = Cursors.Hand;

            lblTarjetaEvolucion.Name =
                "lblTarjetaEvolucion";
            lblTarjetaEvolucion.Text =
                "EVOLUCIÓN DEL IMC";
            lblTarjetaEvolucion.Font = new Font(
                "Segoe UI", 14F, FontStyle.Bold);
            lblTarjetaEvolucion.ForeColor =
                Color.FromArgb(18, 63, 73);
            lblTarjetaEvolucion.Location =
                new Point(22, 26);
            lblTarjetaEvolucion.Size =
                new Size(305, 40);

            lblDescripcionEvolucion.Name =
                "lblDescripcionEvolucion";
            lblDescripcionEvolucion.Text =
                "Historial y tendencias";
            lblDescripcionEvolucion.Font =
                new Font("Segoe UI", 10F);
            lblDescripcionEvolucion.ForeColor =
                Color.FromArgb(105, 127, 132);
            lblDescripcionEvolucion.Location =
                new Point(24, 75);
            lblDescripcionEvolucion.Size =
                new Size(300, 35);

            lblAbrirEvolucion.Name =
                "lblAbrirEvolucion";
            lblAbrirEvolucion.Text = "ABRIR  >";
            lblAbrirEvolucion.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            lblAbrirEvolucion.ForeColor =
                Color.FromArgb(20, 125, 134);
            lblAbrirEvolucion.Location =
                new Point(24, 115);
            lblAbrirEvolucion.AutoSize = true;

            pnlTarjetaEvolucion.Controls.Add(
                lblTarjetaEvolucion);
            pnlTarjetaEvolucion.Controls.Add(
                lblDescripcionEvolucion);
            pnlTarjetaEvolucion.Controls.Add(
                lblAbrirEvolucion);

            // BOTÓN CONEXIÓN SQL
            btnProbarBD.Name = "btnProbarBD";
            btnProbarBD.Text = "PROBAR CONEXIÓN SQL";
            btnProbarBD.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            btnProbarBD.Size = new Size(230, 42);
            btnProbarBD.Location = new Point(45, 575);
            btnProbarBD.BackColor =
                Color.FromArgb(20, 125, 134);
            btnProbarBD.ForeColor = Color.White;
            btnProbarBD.FlatStyle = FlatStyle.Flat;
            btnProbarBD.FlatAppearance.BorderSize = 0;
            btnProbarBD.Cursor = Cursors.Hand;

            // PIE DE PÁGINA
            lblPie.Name = "lblPie";
            lblPie.Text =
                "Clínica Salud y Bienestar  •  HPA III  •  Grupo 1";
            lblPie.Font = new Font("Segoe UI", 9F);
            lblPie.ForeColor =
                Color.FromArgb(105, 127, 132);
            lblPie.Location = new Point(48, 640);
            lblPie.AutoSize = true;

            // AGREGAR CONTROLES AL CONTENIDO
            pnlContenido.Controls.Add(lblRuta);
            pnlContenido.Controls.Add(lblTitulo);
            pnlContenido.Controls.Add(lblDescripcion);

            pnlContenido.Controls.Add(
                pnlTarjetaPacientes);

            pnlContenido.Controls.Add(
                pnlTarjetaConsultas);

            pnlContenido.Controls.Add(
                pnlTarjetaInforme);

            pnlContenido.Controls.Add(
                pnlTarjetaEvolucion);

            pnlContenido.Controls.Add(btnProbarBD);
            pnlContenido.Controls.Add(lblPie);

            // AGREGAR PANELES AL FORMULARIO
            Controls.Add(pnlContenido);
            Controls.Add(pnlMenu);
            pnlMenu.BringToFront();

            pnlTarjetaPacientes.ResumeLayout(false);
            pnlTarjetaPacientes.PerformLayout();

            pnlTarjetaConsultas.ResumeLayout(false);
            pnlTarjetaConsultas.PerformLayout();

            pnlTarjetaInforme.ResumeLayout(false);
            pnlTarjetaInforme.PerformLayout();

            pnlTarjetaEvolucion.ResumeLayout(false);
            pnlTarjetaEvolucion.PerformLayout();

            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();

            pnlContenido.ResumeLayout(false);
            pnlContenido.PerformLayout();

            ResumeLayout(false);
        }
    }
}
