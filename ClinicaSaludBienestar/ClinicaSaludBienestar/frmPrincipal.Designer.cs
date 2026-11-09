
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
            pnlContenido = new Panel();
            lblRuta = new Label();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            pnlTarjetaPacientes = new Panel();
            lblTarjetaPacientes = new Label();
            lblDescripcionPacientes = new Label();
            lblAbrirPacientes = new Label();
            pnlTarjetaConsultas = new Panel();
            lblTarjetaConsultas = new Label();
            lblDescripcionConsultas = new Label();
            lblAbrirConsultas = new Label();
            pnlTarjetaInforme = new Panel();
            lblTarjetaInforme = new Label();
            lblDescripcionInforme = new Label();
            lblAbrirInforme = new Label();
            pnlTarjetaEvolucion = new Panel();
            lblTarjetaEvolucion = new Label();
            lblDescripcionEvolucion = new Label();
            lblAbrirEvolucion = new Label();
            btnProbarBD = new Button();
            lblPie = new Label();
            pnlMenu.SuspendLayout();
            pnlContenido.SuspendLayout();
            pnlTarjetaPacientes.SuspendLayout();
            pnlTarjetaConsultas.SuspendLayout();
            pnlTarjetaInforme.SuspendLayout();
            pnlTarjetaEvolucion.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(18, 63, 73);
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
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(235, 761);
            pnlMenu.TabIndex = 1;
            // 
            // lblLogo
            // 
            lblLogo.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(22, 35);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(210, 90);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "+  SALUD Y\n    BIENESTAR";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSubtitulo.ForeColor = Color.FromArgb(137, 212, 207);
            lblSubtitulo.Location = new Point(28, 140);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(106, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "GESTIÓN CLÍNICA";
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.FromArgb(20, 125, 134);
            btnInicio.Cursor = Cursors.Hand;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInicio.ForeColor = Color.White;
            btnInicio.Location = new Point(12, 205);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(211, 48);
            btnInicio.TabIndex = 2;
            btnInicio.Text = "   INICIO";
            btnInicio.TextAlign = ContentAlignment.MiddleLeft;
            btnInicio.UseVisualStyleBackColor = false;
            // 
            // btnPacientes
            // 
            btnPacientes.BackColor = Color.FromArgb(18, 63, 73);
            btnPacientes.Cursor = Cursors.Hand;
            btnPacientes.FlatAppearance.BorderSize = 0;
            btnPacientes.FlatStyle = FlatStyle.Flat;
            btnPacientes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPacientes.ForeColor = Color.White;
            btnPacientes.Location = new Point(12, 265);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Size = new Size(211, 48);
            btnPacientes.TabIndex = 3;
            btnPacientes.Text = "   PACIENTES";
            btnPacientes.TextAlign = ContentAlignment.MiddleLeft;
            btnPacientes.UseVisualStyleBackColor = false;
            // 
            // btnConsultas
            // 
            btnConsultas.BackColor = Color.FromArgb(18, 63, 73);
            btnConsultas.Cursor = Cursors.Hand;
            btnConsultas.FlatAppearance.BorderSize = 0;
            btnConsultas.FlatStyle = FlatStyle.Flat;
            btnConsultas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConsultas.ForeColor = Color.White;
            btnConsultas.Location = new Point(12, 325);
            btnConsultas.Name = "btnConsultas";
            btnConsultas.Size = new Size(211, 48);
            btnConsultas.TabIndex = 4;
            btnConsultas.Text = "   CONSULTAS";
            btnConsultas.TextAlign = ContentAlignment.MiddleLeft;
            btnConsultas.UseVisualStyleBackColor = false;
            // 
            // btnInforme
            // 
            btnInforme.BackColor = Color.FromArgb(18, 63, 73);
            btnInforme.Cursor = Cursors.Hand;
            btnInforme.FlatAppearance.BorderSize = 0;
            btnInforme.FlatStyle = FlatStyle.Flat;
            btnInforme.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInforme.ForeColor = Color.White;
            btnInforme.Location = new Point(12, 385);
            btnInforme.Name = "btnInforme";
            btnInforme.Size = new Size(211, 48);
            btnInforme.TabIndex = 5;
            btnInforme.Text = "   INFORME GENERAL";
            btnInforme.TextAlign = ContentAlignment.MiddleLeft;
            btnInforme.UseVisualStyleBackColor = false;
            // 
            // btnEvolucion
            // 
            btnEvolucion.BackColor = Color.FromArgb(18, 63, 73);
            btnEvolucion.Cursor = Cursors.Hand;
            btnEvolucion.FlatAppearance.BorderSize = 0;
            btnEvolucion.FlatStyle = FlatStyle.Flat;
            btnEvolucion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEvolucion.ForeColor = Color.White;
            btnEvolucion.Location = new Point(12, 445);
            btnEvolucion.Name = "btnEvolucion";
            btnEvolucion.Size = new Size(211, 48);
            btnEvolucion.TabIndex = 6;
            btnEvolucion.Text = "   EVOLUCIÓN IMC";
            btnEvolucion.TextAlign = ContentAlignment.MiddleLeft;
            btnEvolucion.UseVisualStyleBackColor = false;
            // 
            // btnGestionPacientes
            // 
            btnGestionPacientes.BackColor = Color.FromArgb(18, 63, 73);
            btnGestionPacientes.Cursor = Cursors.Hand;
            btnGestionPacientes.FlatAppearance.BorderSize = 0;
            btnGestionPacientes.FlatStyle = FlatStyle.Flat;
            btnGestionPacientes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGestionPacientes.ForeColor = Color.White;
            btnGestionPacientes.Location = new Point(12, 505);
            btnGestionPacientes.Name = "btnGestionPacientes";
            btnGestionPacientes.Size = new Size(211, 48);
            btnGestionPacientes.TabIndex = 7;
            btnGestionPacientes.Text = "   GESTIÓN PACIENTES";
            btnGestionPacientes.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionPacientes.UseVisualStyleBackColor = false;
            // 
            // btnGestionConsultas
            // 
            btnGestionConsultas.BackColor = Color.FromArgb(18, 63, 73);
            btnGestionConsultas.Cursor = Cursors.Hand;
            btnGestionConsultas.FlatAppearance.BorderSize = 0;
            btnGestionConsultas.FlatStyle = FlatStyle.Flat;
            btnGestionConsultas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGestionConsultas.ForeColor = Color.White;
            btnGestionConsultas.Location = new Point(12, 565);
            btnGestionConsultas.Name = "btnGestionConsultas";
            btnGestionConsultas.Size = new Size(211, 48);
            btnGestionConsultas.TabIndex = 8;
            btnGestionConsultas.Text = "   GESTIÓN CONSULTAS";
            btnGestionConsultas.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionConsultas.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(26, 91, 102);
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.Dock = DockStyle.Bottom;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(0, 713);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(235, 48);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "CERRAR SESIÓN";
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // pnlContenido
            // 
            pnlContenido.AutoScroll = true;
            pnlContenido.BackColor = Color.FromArgb(240, 247, 247);
            pnlContenido.Controls.Add(lblRuta);
            pnlContenido.Controls.Add(lblTitulo);
            pnlContenido.Controls.Add(lblDescripcion);
            pnlContenido.Controls.Add(pnlTarjetaPacientes);
            pnlContenido.Controls.Add(pnlTarjetaConsultas);
            pnlContenido.Controls.Add(pnlTarjetaInforme);
            pnlContenido.Controls.Add(pnlTarjetaEvolucion);
            pnlContenido.Controls.Add(btnProbarBD);
            pnlContenido.Controls.Add(lblPie);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(235, 0);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(863, 761);
            pnlContenido.TabIndex = 0;
            // 
            // lblRuta
            // 
            lblRuta.AutoSize = true;
            lblRuta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRuta.ForeColor = Color.FromArgb(20, 125, 134);
            lblRuta.Location = new Point(45, 40);
            lblRuta.Name = "lblRuta";
            lblRuta.Size = new Size(239, 19);
            lblRuta.TabIndex = 0;
            lblRuta.Text = "PANEL ADMINISTRATIVO  /  INICIO";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 27F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(18, 63, 73);
            lblTitulo.Location = new Point(43, 80);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(385, 48);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Bienvenido al sistema";
            // 
            // lblDescripcion
            // 
            lblDescripcion.Font = new Font("Segoe UI", 11F);
            lblDescripcion.ForeColor = Color.FromArgb(105, 127, 132);
            lblDescripcion.Location = new Point(47, 150);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(775, 40);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Gestiona pacientes, registra consultas y analiza su evolución clínica.";
            // 
            // pnlTarjetaPacientes
            // 
            pnlTarjetaPacientes.BackColor = Color.White;
            pnlTarjetaPacientes.BorderStyle = BorderStyle.FixedSingle;
            pnlTarjetaPacientes.Controls.Add(lblTarjetaPacientes);
            pnlTarjetaPacientes.Controls.Add(lblDescripcionPacientes);
            pnlTarjetaPacientes.Controls.Add(lblAbrirPacientes);
            pnlTarjetaPacientes.Cursor = Cursors.Hand;
            pnlTarjetaPacientes.Location = new Point(45, 225);
            pnlTarjetaPacientes.Name = "pnlTarjetaPacientes";
            pnlTarjetaPacientes.Size = new Size(350, 145);
            pnlTarjetaPacientes.TabIndex = 3;
            // 
            // lblTarjetaPacientes
            // 
            lblTarjetaPacientes.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTarjetaPacientes.ForeColor = Color.FromArgb(18, 63, 73);
            lblTarjetaPacientes.Location = new Point(22, 26);
            lblTarjetaPacientes.Name = "lblTarjetaPacientes";
            lblTarjetaPacientes.Size = new Size(305, 40);
            lblTarjetaPacientes.TabIndex = 0;
            lblTarjetaPacientes.Text = "PACIENTES";
            // 
            // lblDescripcionPacientes
            // 
            lblDescripcionPacientes.Font = new Font("Segoe UI", 10F);
            lblDescripcionPacientes.ForeColor = Color.FromArgb(105, 127, 132);
            lblDescripcionPacientes.Location = new Point(24, 75);
            lblDescripcionPacientes.Name = "lblDescripcionPacientes";
            lblDescripcionPacientes.Size = new Size(300, 35);
            lblDescripcionPacientes.TabIndex = 1;
            lblDescripcionPacientes.Text = "Datos personales y registros";
            // 
            // lblAbrirPacientes
            // 
            lblAbrirPacientes.AutoSize = true;
            lblAbrirPacientes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAbrirPacientes.ForeColor = Color.FromArgb(20, 125, 134);
            lblAbrirPacientes.Location = new Point(24, 115);
            lblAbrirPacientes.Name = "lblAbrirPacientes";
            lblAbrirPacientes.Size = new Size(57, 15);
            lblAbrirPacientes.TabIndex = 2;
            lblAbrirPacientes.Text = "ABRIR  >";
            // 
            // pnlTarjetaConsultas
            // 
            pnlTarjetaConsultas.BackColor = Color.White;
            pnlTarjetaConsultas.BorderStyle = BorderStyle.FixedSingle;
            pnlTarjetaConsultas.Controls.Add(lblTarjetaConsultas);
            pnlTarjetaConsultas.Controls.Add(lblDescripcionConsultas);
            pnlTarjetaConsultas.Controls.Add(lblAbrirConsultas);
            pnlTarjetaConsultas.Cursor = Cursors.Hand;
            pnlTarjetaConsultas.Location = new Point(435, 225);
            pnlTarjetaConsultas.Name = "pnlTarjetaConsultas";
            pnlTarjetaConsultas.Size = new Size(350, 145);
            pnlTarjetaConsultas.TabIndex = 4;
            // 
            // lblTarjetaConsultas
            // 
            lblTarjetaConsultas.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTarjetaConsultas.ForeColor = Color.FromArgb(18, 63, 73);
            lblTarjetaConsultas.Location = new Point(22, 26);
            lblTarjetaConsultas.Name = "lblTarjetaConsultas";
            lblTarjetaConsultas.Size = new Size(305, 40);
            lblTarjetaConsultas.TabIndex = 0;
            lblTarjetaConsultas.Text = "CONSULTAS";
            // 
            // lblDescripcionConsultas
            // 
            lblDescripcionConsultas.Font = new Font("Segoe UI", 10F);
            lblDescripcionConsultas.ForeColor = Color.FromArgb(105, 127, 132);
            lblDescripcionConsultas.Location = new Point(24, 75);
            lblDescripcionConsultas.Name = "lblDescripcionConsultas";
            lblDescripcionConsultas.Size = new Size(300, 35);
            lblDescripcionConsultas.TabIndex = 1;
            lblDescripcionConsultas.Text = "Mediciones y clasificación IMC";
            // 
            // lblAbrirConsultas
            // 
            lblAbrirConsultas.AutoSize = true;
            lblAbrirConsultas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAbrirConsultas.ForeColor = Color.FromArgb(20, 125, 134);
            lblAbrirConsultas.Location = new Point(24, 115);
            lblAbrirConsultas.Name = "lblAbrirConsultas";
            lblAbrirConsultas.Size = new Size(57, 15);
            lblAbrirConsultas.TabIndex = 2;
            lblAbrirConsultas.Text = "ABRIR  >";
            // 
            // pnlTarjetaInforme
            // 
            pnlTarjetaInforme.BackColor = Color.White;
            pnlTarjetaInforme.BorderStyle = BorderStyle.FixedSingle;
            pnlTarjetaInforme.Controls.Add(lblTarjetaInforme);
            pnlTarjetaInforme.Controls.Add(lblDescripcionInforme);
            pnlTarjetaInforme.Controls.Add(lblAbrirInforme);
            pnlTarjetaInforme.Cursor = Cursors.Hand;
            pnlTarjetaInforme.Location = new Point(45, 400);
            pnlTarjetaInforme.Name = "pnlTarjetaInforme";
            pnlTarjetaInforme.Size = new Size(350, 145);
            pnlTarjetaInforme.TabIndex = 5;
            // 
            // lblTarjetaInforme
            // 
            lblTarjetaInforme.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTarjetaInforme.ForeColor = Color.FromArgb(18, 63, 73);
            lblTarjetaInforme.Location = new Point(22, 26);
            lblTarjetaInforme.Name = "lblTarjetaInforme";
            lblTarjetaInforme.Size = new Size(305, 40);
            lblTarjetaInforme.TabIndex = 0;
            lblTarjetaInforme.Text = "INFORME GENERAL";
            // 
            // lblDescripcionInforme
            // 
            lblDescripcionInforme.Font = new Font("Segoe UI", 10F);
            lblDescripcionInforme.ForeColor = Color.FromArgb(105, 127, 132);
            lblDescripcionInforme.Location = new Point(24, 75);
            lblDescripcionInforme.Name = "lblDescripcionInforme";
            lblDescripcionInforme.Size = new Size(300, 35);
            lblDescripcionInforme.TabIndex = 1;
            lblDescripcionInforme.Text = "Estadísticas de la clínica";
            // 
            // lblAbrirInforme
            // 
            lblAbrirInforme.AutoSize = true;
            lblAbrirInforme.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAbrirInforme.ForeColor = Color.FromArgb(20, 125, 134);
            lblAbrirInforme.Location = new Point(24, 115);
            lblAbrirInforme.Name = "lblAbrirInforme";
            lblAbrirInforme.Size = new Size(57, 15);
            lblAbrirInforme.TabIndex = 2;
            lblAbrirInforme.Text = "ABRIR  >";
            // 
            // pnlTarjetaEvolucion
            // 
            pnlTarjetaEvolucion.BackColor = Color.White;
            pnlTarjetaEvolucion.BorderStyle = BorderStyle.FixedSingle;
            pnlTarjetaEvolucion.Controls.Add(lblTarjetaEvolucion);
            pnlTarjetaEvolucion.Controls.Add(lblDescripcionEvolucion);
            pnlTarjetaEvolucion.Controls.Add(lblAbrirEvolucion);
            pnlTarjetaEvolucion.Cursor = Cursors.Hand;
            pnlTarjetaEvolucion.Location = new Point(435, 400);
            pnlTarjetaEvolucion.Name = "pnlTarjetaEvolucion";
            pnlTarjetaEvolucion.Size = new Size(350, 145);
            pnlTarjetaEvolucion.TabIndex = 6;
            // 
            // lblTarjetaEvolucion
            // 
            lblTarjetaEvolucion.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTarjetaEvolucion.ForeColor = Color.FromArgb(18, 63, 73);
            lblTarjetaEvolucion.Location = new Point(22, 26);
            lblTarjetaEvolucion.Name = "lblTarjetaEvolucion";
            lblTarjetaEvolucion.Size = new Size(305, 40);
            lblTarjetaEvolucion.TabIndex = 0;
            lblTarjetaEvolucion.Text = "EVOLUCIÓN DEL IMC";
            // 
            // lblDescripcionEvolucion
            // 
            lblDescripcionEvolucion.Font = new Font("Segoe UI", 10F);
            lblDescripcionEvolucion.ForeColor = Color.FromArgb(105, 127, 132);
            lblDescripcionEvolucion.Location = new Point(24, 75);
            lblDescripcionEvolucion.Name = "lblDescripcionEvolucion";
            lblDescripcionEvolucion.Size = new Size(300, 35);
            lblDescripcionEvolucion.TabIndex = 1;
            lblDescripcionEvolucion.Text = "Historial y tendencias";
            // 
            // lblAbrirEvolucion
            // 
            lblAbrirEvolucion.AutoSize = true;
            lblAbrirEvolucion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAbrirEvolucion.ForeColor = Color.FromArgb(20, 125, 134);
            lblAbrirEvolucion.Location = new Point(24, 115);
            lblAbrirEvolucion.Name = "lblAbrirEvolucion";
            lblAbrirEvolucion.Size = new Size(57, 15);
            lblAbrirEvolucion.TabIndex = 2;
            lblAbrirEvolucion.Text = "ABRIR  >";
            // 
            // btnProbarBD
            // 
            btnProbarBD.BackColor = Color.FromArgb(20, 125, 134);
            btnProbarBD.Cursor = Cursors.Hand;
            btnProbarBD.FlatAppearance.BorderSize = 0;
            btnProbarBD.FlatStyle = FlatStyle.Flat;
            btnProbarBD.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProbarBD.ForeColor = Color.White;
            btnProbarBD.Location = new Point(45, 575);
            btnProbarBD.Name = "btnProbarBD";
            btnProbarBD.Size = new Size(230, 42);
            btnProbarBD.TabIndex = 7;
            btnProbarBD.Text = "PROBAR CONEXIÓN SQL";
            btnProbarBD.UseVisualStyleBackColor = false;
            // 
            // lblPie
            // 
            lblPie.AutoSize = true;
            lblPie.Font = new Font("Segoe UI", 9F);
            lblPie.ForeColor = Color.FromArgb(105, 127, 132);
            lblPie.Location = new Point(48, 640);
            lblPie.Name = "lblPie";
            lblPie.Size = new Size(246, 15);
            lblPie.TabIndex = 8;
            lblPie.Text = "Clínica Salud y Bienestar  •  HPA III  •  Grupo 1";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 247, 247);
            ClientSize = new Size(1098, 761);
            Controls.Add(pnlContenido);
            Controls.Add(pnlMenu);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1000, 800);
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clínica Salud y Bienestar | Panel principal";
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            pnlContenido.ResumeLayout(false);
            pnlContenido.PerformLayout();
            pnlTarjetaPacientes.ResumeLayout(false);
            pnlTarjetaPacientes.PerformLayout();
            pnlTarjetaConsultas.ResumeLayout(false);
            pnlTarjetaConsultas.PerformLayout();
            pnlTarjetaInforme.ResumeLayout(false);
            pnlTarjetaInforme.PerformLayout();
            pnlTarjetaEvolucion.ResumeLayout(false);
            pnlTarjetaEvolucion.PerformLayout();
            ResumeLayout(false);
        }
    }
}
