
#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicaSaludBienestar
{
    partial class frmInformeGeneral
    {
        private System.ComponentModel.IContainer? components = null;

        private TableLayoutPanel principal = null!;
        private Panel encabezado = null!;
        private Label titulo = null!;
        private Label subtitulo = null!;

        private TableLayoutPanel tarjetas = null!;

        private Panel tarjetaPacientes = null!;
        private Panel tarjetaEdad = null!;
        private Panel tarjetaConsultas = null!;

        private Label lblTituloPacientes = null!;
        private Label lblTituloEdad = null!;
        private Label lblTituloConsultas = null!;

        private Label lblPacientes = null!;
        private Label lblEdadPromedio = null!;
        private Label lblConsultas = null!;

        private Panel seccion = null!;
        private Label lblSeccion = null!;
        private Label detalle = null!;

        private DataGridView dgvCategorias = null!;

        private TableLayoutPanel resumen = null!;
        private Panel panelMayor = null!;
        private Panel panelMenor = null!;

        private Label lblTituloMayor = null!;
        private Label lblTituloMenor = null!;
        private Label lblMayor = null!;
        private Label lblMenor = null!;

        private FlowLayoutPanel acciones = null!;
        private Button btnRecargar = null!;
        private Button btnCerrar = null!;
        private Label lblEstado = null!;

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
            principal = new TableLayoutPanel();

            encabezado = new Panel();
            titulo = new Label();
            subtitulo = new Label();

            tarjetas = new TableLayoutPanel();

            tarjetaPacientes = new Panel();
            tarjetaEdad = new Panel();
            tarjetaConsultas = new Panel();

            lblTituloPacientes = new Label();
            lblTituloEdad = new Label();
            lblTituloConsultas = new Label();

            lblPacientes = new Label();
            lblEdadPromedio = new Label();
            lblConsultas = new Label();

            seccion = new Panel();
            lblSeccion = new Label();
            detalle = new Label();

            dgvCategorias = new DataGridView();

            resumen = new TableLayoutPanel();
            panelMayor = new Panel();
            panelMenor = new Panel();

            lblTituloMayor = new Label();
            lblTituloMenor = new Label();
            lblMayor = new Label();
            lblMenor = new Label();

            acciones = new FlowLayoutPanel();
            btnRecargar = new Button();
            btnCerrar = new Button();
            lblEstado = new Label();

            principal.SuspendLayout();
            encabezado.SuspendLayout();
            tarjetas.SuspendLayout();

            tarjetaPacientes.SuspendLayout();
            tarjetaEdad.SuspendLayout();
            tarjetaConsultas.SuspendLayout();

            seccion.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                dgvCategorias).BeginInit();

            resumen.SuspendLayout();
            panelMayor.SuspendLayout();
            panelMenor.SuspendLayout();
            acciones.SuspendLayout();

            SuspendLayout();

            // =====================================
            // FORMULARIO
            // =====================================

            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(1150, 850);
            MinimumSize = new Size(900, 650);

            WindowState = FormWindowState.Maximized;

            BackColor = Color.FromArgb(240, 247, 247);
            Font = new Font("Segoe UI", 10F);

            Name = "frmInformeGeneral";

            Text = "Clínica Salud y Bienestar | Informe general";

            // =====================================
            // CONTENEDOR PRINCIPAL
            // =====================================

            principal.Name = "principal";
            principal.Dock = DockStyle.Fill;

            principal.ColumnCount = 1;
            principal.RowCount = 6;

            principal.Padding = new Padding(18, 0, 18, 12);

            principal.BackColor =
                Color.FromArgb(240, 247, 247);

            principal.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 100F));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 128F));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 68F));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 120F));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 62F));

            // =====================================
            // ENCABEZADO
            // =====================================

            encabezado.Name = "encabezado";
            encabezado.Dock = DockStyle.Fill;

            encabezado.BackColor =
                Color.FromArgb(18, 63, 73);

            encabezado.Margin = new Padding(0, 0, 0, 8);

            titulo.Name = "titulo";
            titulo.Text = "INFORME GENERAL";

            titulo.Font = new Font(
                "Segoe UI", 22F, FontStyle.Bold);

            titulo.ForeColor = Color.White;
            titulo.Location = new Point(22, 10);
            titulo.AutoSize = true;

            subtitulo.Name = "subtitulo";

            subtitulo.Text =
                "Estadísticas generales • Corte: 10/11/2026";

            subtitulo.ForeColor = Color.LightCyan;
            subtitulo.Location = new Point(25, 62);
            subtitulo.AutoSize = true;

            encabezado.Controls.Add(titulo);
            encabezado.Controls.Add(subtitulo);

            // =====================================
            // CONTENEDOR DE TARJETAS
            // =====================================

            tarjetas.Name = "tarjetas";
            tarjetas.Dock = DockStyle.Fill;

            tarjetas.ColumnCount = 3;
            tarjetas.RowCount = 1;

            tarjetas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33.33F));

            tarjetas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33.33F));

            tarjetas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33.34F));

            tarjetas.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            // =====================================
            // TARJETA PACIENTES
            // =====================================

            tarjetaPacientes.Name = "tarjetaPacientes";
            tarjetaPacientes.Dock = DockStyle.Fill;

            tarjetaPacientes.BackColor = Color.White;

            tarjetaPacientes.Margin =
                new Padding(4, 12, 8, 12);

            lblTituloPacientes.Name = "lblTituloPacientes";

            lblTituloPacientes.Text =
                "PACIENTES REGISTRADOS";

            lblTituloPacientes.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);

            lblTituloPacientes.ForeColor =
                Color.FromArgb(105, 127, 132);

            lblTituloPacientes.Location =
                new Point(18, 14);

            lblTituloPacientes.AutoSize = true;

            lblPacientes.Name = "lblPacientes";
            lblPacientes.Text = "—";

            lblPacientes.Font = new Font(
                "Segoe UI", 25F, FontStyle.Bold);

            lblPacientes.ForeColor =
                Color.FromArgb(20, 125, 134);

            lblPacientes.Location = new Point(16, 44);
            lblPacientes.Size = new Size(270, 53);

            lblPacientes.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            tarjetaPacientes.Controls.Add(
                lblTituloPacientes);

            tarjetaPacientes.Controls.Add(lblPacientes);

            // =====================================
            // TARJETA EDAD PROMEDIO
            // =====================================

            tarjetaEdad.Name = "tarjetaEdad";
            tarjetaEdad.Dock = DockStyle.Fill;

            tarjetaEdad.BackColor = Color.White;

            tarjetaEdad.Margin =
                new Padding(4, 12, 8, 12);

            lblTituloEdad.Name = "lblTituloEdad";
            lblTituloEdad.Text = "EDAD PROMEDIO";

            lblTituloEdad.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);

            lblTituloEdad.ForeColor =
                Color.FromArgb(105, 127, 132);

            lblTituloEdad.Location = new Point(18, 14);
            lblTituloEdad.AutoSize = true;

            lblEdadPromedio.Name = "lblEdadPromedio";
            lblEdadPromedio.Text = "—";

            lblEdadPromedio.Font = new Font(
                "Segoe UI", 25F, FontStyle.Bold);

            lblEdadPromedio.ForeColor =
                Color.FromArgb(20, 125, 134);

            lblEdadPromedio.Location = new Point(16, 44);
            lblEdadPromedio.Size = new Size(285, 53);

            lblEdadPromedio.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            tarjetaEdad.Controls.Add(lblTituloEdad);
            tarjetaEdad.Controls.Add(lblEdadPromedio);

            // =====================================
            // TARJETA CONSULTAS
            // =====================================

            tarjetaConsultas.Name = "tarjetaConsultas";
            tarjetaConsultas.Dock = DockStyle.Fill;

            tarjetaConsultas.BackColor = Color.White;

            tarjetaConsultas.Margin =
                new Padding(4, 12, 8, 12);

            lblTituloConsultas.Name = "lblTituloConsultas";

            lblTituloConsultas.Text =
                "CONSULTAS REGISTRADAS";

            lblTituloConsultas.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);

            lblTituloConsultas.ForeColor =
                Color.FromArgb(105, 127, 132);

            lblTituloConsultas.Location =
                new Point(18, 14);

            lblTituloConsultas.AutoSize = true;

            lblConsultas.Name = "lblConsultas";
            lblConsultas.Text = "—";

            lblConsultas.Font = new Font(
                "Segoe UI", 25F, FontStyle.Bold);

            lblConsultas.ForeColor =
                Color.FromArgb(20, 125, 134);

            lblConsultas.Location = new Point(16, 44);
            lblConsultas.Size = new Size(270, 53);

            lblConsultas.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            tarjetaConsultas.Controls.Add(
                lblTituloConsultas);

            tarjetaConsultas.Controls.Add(lblConsultas);

            // AGREGAR TARJETAS
            tarjetas.Controls.Add(
                tarjetaPacientes, 0, 0);

            tarjetas.Controls.Add(
                tarjetaEdad, 1, 0);

            tarjetas.Controls.Add(
                tarjetaConsultas, 2, 0);

            // =====================================
            // TÍTULO DE DISTRIBUCIÓN
            // =====================================

            seccion.Name = "seccion";
            seccion.Dock = DockStyle.Fill;

            lblSeccion.Name = "lblSeccion";

            lblSeccion.Text =
                "DISTRIBUCIÓN POR CATEGORÍA DE IMC";

            lblSeccion.Font = new Font(
                "Segoe UI", 14F, FontStyle.Bold);

            lblSeccion.ForeColor =
                Color.FromArgb(18, 63, 73);

            lblSeccion.Location = new Point(5, 7);
            lblSeccion.AutoSize = true;

            detalle.Name = "detalle";

            detalle.Text =
                "Se utiliza la última consulta de cada paciente.";

            detalle.ForeColor =
                Color.FromArgb(105, 127, 132);

            detalle.Location = new Point(7, 41);
            detalle.AutoSize = true;

            seccion.Controls.Add(lblSeccion);
            seccion.Controls.Add(detalle);

            // =====================================
            // TABLA DE CATEGORÍAS
            // =====================================

            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.Dock = DockStyle.Fill;

            dgvCategorias.Margin =
                new Padding(4, 0, 4, 10);

            dgvCategorias.ReadOnly = true;

            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AllowUserToDeleteRows = false;
            dgvCategorias.AllowUserToResizeRows = false;

            dgvCategorias.RowHeadersVisible = false;
            dgvCategorias.MultiSelect = false;

            dgvCategorias.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCategorias.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvCategorias.ScrollBars = ScrollBars.Both;
            dgvCategorias.BackgroundColor = Color.White;
            dgvCategorias.BorderStyle = BorderStyle.None;

            dgvCategorias.RowTemplate.Height = 36;

            dgvCategorias.EnableHeadersVisualStyles = false;
            dgvCategorias.ColumnHeadersHeight = 44;

            dgvCategorias.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                    .DisableResizing;

            dgvCategorias.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(18, 63, 73);

            dgvCategorias.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvCategorias.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);

            dgvCategorias.DefaultCellStyle.Font =
                new Font("Segoe UI", 11F);

            dgvCategorias.DefaultCellStyle.ForeColor =
                Color.FromArgb(18, 63, 73);

            dgvCategorias.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(209, 237, 234);

            dgvCategorias.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(18, 63, 73);

            dgvCategorias.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(246, 250, 250);

            // =====================================
            // CONTENEDOR DE FRECUENCIAS
            // =====================================

            resumen.Name = "resumen";
            resumen.Dock = DockStyle.Fill;

            resumen.ColumnCount = 2;
            resumen.RowCount = 1;

            resumen.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50F));

            resumen.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50F));

            resumen.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            // =====================================
            // MAYOR FRECUENCIA
            // =====================================

            panelMayor.Name = "panelMayor";
            panelMayor.Dock = DockStyle.Fill;

            panelMayor.BackColor = Color.White;
            panelMayor.Margin = new Padding(4, 0, 8, 10);

            lblTituloMayor.Name = "lblTituloMayor";
            lblTituloMayor.Text = "MAYOR FRECUENCIA";

            lblTituloMayor.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);

            lblTituloMayor.ForeColor =
                Color.FromArgb(105, 127, 132);

            lblTituloMayor.Location = new Point(18, 12);
            lblTituloMayor.AutoSize = true;

            lblMayor.Name = "lblMayor";
            lblMayor.Text = "—";

            lblMayor.Font = new Font(
                "Segoe UI", 12F, FontStyle.Bold);

            lblMayor.ForeColor =
                Color.FromArgb(20, 125, 134);

            lblMayor.Dock = DockStyle.Bottom;
            lblMayor.Height = 55;

            lblMayor.Padding = new Padding(18, 0, 12, 0);
            lblMayor.AutoEllipsis = true;

            panelMayor.Controls.Add(lblTituloMayor);
            panelMayor.Controls.Add(lblMayor);

            // =====================================
            // MENOR FRECUENCIA
            // =====================================

            panelMenor.Name = "panelMenor";
            panelMenor.Dock = DockStyle.Fill;

            panelMenor.BackColor = Color.White;
            panelMenor.Margin = new Padding(4, 0, 8, 10);

            lblTituloMenor.Name = "lblTituloMenor";
            lblTituloMenor.Text = "MENOR FRECUENCIA";

            lblTituloMenor.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);

            lblTituloMenor.ForeColor =
                Color.FromArgb(105, 127, 132);

            lblTituloMenor.Location = new Point(18, 12);
            lblTituloMenor.AutoSize = true;

            lblMenor.Name = "lblMenor";
            lblMenor.Text = "—";

            lblMenor.Font = new Font(
                "Segoe UI", 12F, FontStyle.Bold);

            lblMenor.ForeColor =
                Color.FromArgb(20, 125, 134);

            lblMenor.Dock = DockStyle.Bottom;
            lblMenor.Height = 55;

            lblMenor.Padding = new Padding(18, 0, 12, 0);
            lblMenor.AutoEllipsis = true;

            panelMenor.Controls.Add(lblTituloMenor);
            panelMenor.Controls.Add(lblMenor);

            resumen.Controls.Add(panelMayor, 0, 0);
            resumen.Controls.Add(panelMenor, 1, 0);

            // =====================================
            // BARRA DE ACCIONES
            // =====================================

            acciones.Name = "acciones";
            acciones.Dock = DockStyle.Fill;

            acciones.FlowDirection =
                FlowDirection.LeftToRight;

            acciones.WrapContents = false;
            acciones.Padding = new Padding(4, 8, 0, 0);

            // RECARGAR DATOS
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Text = "RECARGAR DATOS";

            btnRecargar.Size = new Size(205, 42);

            btnRecargar.BackColor =
                Color.FromArgb(20, 125, 134);

            btnRecargar.ForeColor = Color.White;

            btnRecargar.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);

            btnRecargar.FlatStyle = FlatStyle.Flat;
            btnRecargar.FlatAppearance.BorderSize = 0;

            btnRecargar.Cursor = Cursors.Hand;
            btnRecargar.Margin = new Padding(0, 0, 12, 0);

            // CERRAR
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Text = "CERRAR";

            btnCerrar.Size = new Size(135, 42);

            btnCerrar.BackColor =
                Color.FromArgb(18, 63, 73);

            btnCerrar.ForeColor = Color.White;

            btnCerrar.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);

            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderSize = 0;

            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.Margin = new Padding(0, 0, 12, 0);

            // ESTADO
            lblEstado.Name = "lblEstado";
            lblEstado.Text = "Esperando información...";

            lblEstado.ForeColor =
                Color.FromArgb(105, 127, 132);

            lblEstado.AutoSize = true;
            lblEstado.Margin = new Padding(25, 13, 0, 0);

            acciones.Controls.Add(btnRecargar);
            acciones.Controls.Add(btnCerrar);
            acciones.Controls.Add(lblEstado);

            // =====================================
            // AGREGAR SECCIONES AL FORMULARIO
            // =====================================

            principal.Controls.Add(encabezado, 0, 0);
            principal.Controls.Add(tarjetas, 0, 1);
            principal.Controls.Add(seccion, 0, 2);
            principal.Controls.Add(dgvCategorias, 0, 3);
            principal.Controls.Add(resumen, 0, 4);
            principal.Controls.Add(acciones, 0, 5);

            Controls.Add(principal);

            // =====================================
            // FINALIZAR DISEÑO
            // =====================================

            ((System.ComponentModel.ISupportInitialize)
                dgvCategorias).EndInit();

            acciones.ResumeLayout(false);
            acciones.PerformLayout();

            panelMayor.ResumeLayout(false);
            panelMayor.PerformLayout();

            panelMenor.ResumeLayout(false);
            panelMenor.PerformLayout();

            resumen.ResumeLayout(false);

            seccion.ResumeLayout(false);
            seccion.PerformLayout();

            tarjetaPacientes.ResumeLayout(false);
            tarjetaPacientes.PerformLayout();

            tarjetaEdad.ResumeLayout(false);
            tarjetaEdad.PerformLayout();

            tarjetaConsultas.ResumeLayout(false);
            tarjetaConsultas.PerformLayout();

            tarjetas.ResumeLayout(false);

            encabezado.ResumeLayout(false);
            encabezado.PerformLayout();

            principal.ResumeLayout(false);

            ResumeLayout(false);
        }
    }
}
