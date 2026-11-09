
#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicaSaludBienestar
{
    partial class frmConsultas
    {
        private System.ComponentModel.IContainer? components = null;

        private TableLayoutPanel principal = null!;
        private Panel encabezado = null!;
        private Label titulo = null!;
        private Label subtitulo = null!;

        private TableLayoutPanel tarjetas = null!;
        private Panel tarjetaTotal = null!;
        private Panel tarjetaMostradas = null!;
        private Panel tarjetaIMC = null!;

        private Label lblTituloTotal = null!;
        private Label lblTituloMostradas = null!;
        private Label lblTituloIMC = null!;

        private Label lblTotal = null!;
        private Label lblMostradas = null!;
        private Label lblIMC = null!;

        private TableLayoutPanel filtros = null!;
        private Label lblPaciente = null!;
        private Label lblBuscar = null!;
        private ComboBox cmbPacientes = null!;
        private TextBox txtBuscar = null!;
        private Button btnRecargar = null!;

        private Label lblHistorial = null!;
        private DataGridView dgvConsultas = null!;

        private Panel panelDetalle = null!;
        private Label lblDetalle = null!;
        private Label lblCategoria = null!;

        private TableLayoutPanel acciones = null!;
        private Button btnCerrar = null!;
        private Label lblEstado = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                components?.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            principal = new TableLayoutPanel();
            encabezado = new Panel();
            titulo = new Label();
            subtitulo = new Label();
            tarjetas = new TableLayoutPanel();
            tarjetaTotal = new Panel();
            lblTituloTotal = new Label();
            lblTotal = new Label();
            tarjetaMostradas = new Panel();
            lblTituloMostradas = new Label();
            lblMostradas = new Label();
            tarjetaIMC = new Panel();
            lblTituloIMC = new Label();
            lblIMC = new Label();
            filtros = new TableLayoutPanel();
            lblPaciente = new Label();
            lblBuscar = new Label();
            cmbPacientes = new ComboBox();
            txtBuscar = new TextBox();
            btnRecargar = new Button();
            lblHistorial = new Label();
            dgvConsultas = new DataGridView();
            panelDetalle = new Panel();
            lblDetalle = new Label();
            lblCategoria = new Label();
            acciones = new TableLayoutPanel();
            btnCerrar = new Button();
            lblEstado = new Label();
            principal.SuspendLayout();
            encabezado.SuspendLayout();
            tarjetas.SuspendLayout();
            tarjetaTotal.SuspendLayout();
            tarjetaMostradas.SuspendLayout();
            tarjetaIMC.SuspendLayout();
            filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConsultas).BeginInit();
            panelDetalle.SuspendLayout();
            acciones.SuspendLayout();
            SuspendLayout();
            // 
            // principal
            // 
            principal.BackColor = Color.FromArgb(240, 247, 247);
            principal.ColumnCount = 1;
            principal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            principal.Controls.Add(encabezado, 0, 0);
            principal.Controls.Add(tarjetas, 0, 1);
            principal.Controls.Add(filtros, 0, 2);
            principal.Controls.Add(lblHistorial, 0, 3);
            principal.Controls.Add(dgvConsultas, 0, 4);
            principal.Controls.Add(panelDetalle, 0, 5);
            principal.Controls.Add(acciones, 0, 6);
            principal.Dock = DockStyle.Fill;
            principal.Location = new Point(0, 0);
            principal.Name = "principal";
            principal.Padding = new Padding(18, 0, 18, 10);
            principal.RowCount = 7;
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 112F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            principal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 105F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            principal.Size = new Size(1150, 850);
            principal.TabIndex = 0;
            // 
            // encabezado
            // 
            encabezado.BackColor = Color.FromArgb(18, 63, 73);
            encabezado.Controls.Add(titulo);
            encabezado.Controls.Add(subtitulo);
            encabezado.Dock = DockStyle.Fill;
            encabezado.Location = new Point(18, 0);
            encabezado.Margin = new Padding(0, 0, 0, 5);
            encabezado.Name = "encabezado";
            encabezado.Size = new Size(1114, 90);
            encabezado.TabIndex = 0;
            // 
            // titulo
            // 
            titulo.AutoSize = true;
            titulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.Location = new Point(22, 10);
            titulo.Name = "titulo";
            titulo.Size = new Size(389, 41);
            titulo.TabIndex = 0;
            titulo.Text = "REGISTRO DE CONSULTAS";
            // 
            // subtitulo
            // 
            subtitulo.AutoSize = true;
            subtitulo.ForeColor = Color.LightCyan;
            subtitulo.Location = new Point(25, 60);
            subtitulo.Name = "subtitulo";
            subtitulo.Size = new Size(298, 19);
            subtitulo.TabIndex = 1;
            subtitulo.Text = "Historial clínico • Mediciones y clasificación IMC";
            // 
            // tarjetas
            // 
            tarjetas.ColumnCount = 3;
            tarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tarjetas.Controls.Add(tarjetaTotal, 0, 0);
            tarjetas.Controls.Add(tarjetaMostradas, 1, 0);
            tarjetas.Controls.Add(tarjetaIMC, 2, 0);
            tarjetas.Dock = DockStyle.Fill;
            tarjetas.Location = new Point(21, 98);
            tarjetas.Name = "tarjetas";
            tarjetas.RowCount = 1;
            tarjetas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tarjetas.Size = new Size(1108, 106);
            tarjetas.TabIndex = 1;
            // 
            // tarjetaTotal
            // 
            tarjetaTotal.BackColor = Color.White;
            tarjetaTotal.Controls.Add(lblTituloTotal);
            tarjetaTotal.Controls.Add(lblTotal);
            tarjetaTotal.Dock = DockStyle.Fill;
            tarjetaTotal.Location = new Point(4, 10);
            tarjetaTotal.Margin = new Padding(4, 10, 8, 10);
            tarjetaTotal.Name = "tarjetaTotal";
            tarjetaTotal.Size = new Size(357, 86);
            tarjetaTotal.TabIndex = 0;
            // 
            // lblTituloTotal
            // 
            lblTituloTotal.AutoSize = true;
            lblTituloTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloTotal.ForeColor = Color.FromArgb(105, 127, 132);
            lblTituloTotal.Location = new Point(18, 12);
            lblTituloTotal.Name = "lblTituloTotal";
            lblTituloTotal.Size = new Size(155, 19);
            lblTituloTotal.TabIndex = 0;
            lblTituloTotal.Text = "TOTAL DE CONSULTAS";
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(20, 125, 134);
            lblTotal.Location = new Point(16, 42);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(285, 49);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "—";
            // 
            // tarjetaMostradas
            // 
            tarjetaMostradas.BackColor = Color.White;
            tarjetaMostradas.Controls.Add(lblTituloMostradas);
            tarjetaMostradas.Controls.Add(lblMostradas);
            tarjetaMostradas.Dock = DockStyle.Fill;
            tarjetaMostradas.Location = new Point(373, 10);
            tarjetaMostradas.Margin = new Padding(4, 10, 8, 10);
            tarjetaMostradas.Name = "tarjetaMostradas";
            tarjetaMostradas.Size = new Size(357, 86);
            tarjetaMostradas.TabIndex = 1;
            // 
            // lblTituloMostradas
            // 
            lblTituloMostradas.AutoSize = true;
            lblTituloMostradas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloMostradas.ForeColor = Color.FromArgb(105, 127, 132);
            lblTituloMostradas.Location = new Point(18, 12);
            lblTituloMostradas.Name = "lblTituloMostradas";
            lblTituloMostradas.Size = new Size(180, 19);
            lblTituloMostradas.TabIndex = 0;
            lblTituloMostradas.Text = "CONSULTAS MOSTRADAS";
            // 
            // lblMostradas
            // 
            lblMostradas.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblMostradas.ForeColor = Color.FromArgb(20, 125, 134);
            lblMostradas.Location = new Point(16, 42);
            lblMostradas.Name = "lblMostradas";
            lblMostradas.Size = new Size(285, 49);
            lblMostradas.TabIndex = 1;
            lblMostradas.Text = "—";
            // 
            // tarjetaIMC
            // 
            tarjetaIMC.BackColor = Color.White;
            tarjetaIMC.Controls.Add(lblTituloIMC);
            tarjetaIMC.Controls.Add(lblIMC);
            tarjetaIMC.Dock = DockStyle.Fill;
            tarjetaIMC.Location = new Point(742, 10);
            tarjetaIMC.Margin = new Padding(4, 10, 8, 10);
            tarjetaIMC.Name = "tarjetaIMC";
            tarjetaIMC.Size = new Size(358, 86);
            tarjetaIMC.TabIndex = 2;
            // 
            // lblTituloIMC
            // 
            lblTituloIMC.AutoSize = true;
            lblTituloIMC.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloIMC.ForeColor = Color.FromArgb(105, 127, 132);
            lblTituloIMC.Location = new Point(18, 12);
            lblTituloIMC.Name = "lblTituloIMC";
            lblTituloIMC.Size = new Size(143, 19);
            lblTituloIMC.TabIndex = 0;
            lblTituloIMC.Text = "IMC SELECCIONADO";
            // 
            // lblIMC
            // 
            lblIMC.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblIMC.ForeColor = Color.FromArgb(20, 125, 134);
            lblIMC.Location = new Point(16, 42);
            lblIMC.Name = "lblIMC";
            lblIMC.Size = new Size(285, 49);
            lblIMC.TabIndex = 1;
            lblIMC.Text = "—";
            // 
            // filtros
            // 
            filtros.ColumnCount = 3;
            filtros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
            filtros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            filtros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            filtros.Controls.Add(lblPaciente, 0, 0);
            filtros.Controls.Add(lblBuscar, 1, 0);
            filtros.Controls.Add(cmbPacientes, 0, 1);
            filtros.Controls.Add(txtBuscar, 1, 1);
            filtros.Controls.Add(btnRecargar, 2, 1);
            filtros.Dock = DockStyle.Fill;
            filtros.Location = new Point(21, 210);
            filtros.Name = "filtros";
            filtros.Padding = new Padding(4, 7, 4, 7);
            filtros.RowCount = 2;
            filtros.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            filtros.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            filtros.Size = new Size(1108, 86);
            filtros.TabIndex = 2;
            // 
            // lblPaciente
            // 
            lblPaciente.Dock = DockStyle.Fill;
            lblPaciente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPaciente.ForeColor = Color.FromArgb(18, 63, 73);
            lblPaciente.Location = new Point(7, 7);
            lblPaciente.Name = "lblPaciente";
            lblPaciente.Size = new Size(566, 28);
            lblPaciente.TabIndex = 0;
            lblPaciente.Text = "FILTRAR POR PACIENTE";
            // 
            // lblBuscar
            // 
            lblBuscar.Dock = DockStyle.Fill;
            lblBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.FromArgb(18, 63, 73);
            lblBuscar.Location = new Point(579, 7);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(324, 28);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "BUSCAR POR NOMBRE";
            // 
            // cmbPacientes
            // 
            cmbPacientes.Dock = DockStyle.Fill;
            cmbPacientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPacientes.Font = new Font("Segoe UI", 11F);
            cmbPacientes.Location = new Point(4, 35);
            cmbPacientes.Margin = new Padding(0, 0, 12, 4);
            cmbPacientes.Name = "cmbPacientes";
            cmbPacientes.Size = new Size(560, 28);
            cmbPacientes.TabIndex = 2;
            // 
            // txtBuscar
            // 
            txtBuscar.Dock = DockStyle.Fill;
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.Location = new Point(576, 35);
            txtBuscar.Margin = new Padding(0, 0, 12, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Nombre o apellido...";
            txtBuscar.Size = new Size(318, 27);
            txtBuscar.TabIndex = 3;
            // 
            // btnRecargar
            // 
            btnRecargar.BackColor = Color.FromArgb(20, 125, 134);
            btnRecargar.Cursor = Cursors.Hand;
            btnRecargar.Dock = DockStyle.Fill;
            btnRecargar.FlatAppearance.BorderSize = 0;
            btnRecargar.FlatStyle = FlatStyle.Flat;
            btnRecargar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRecargar.ForeColor = Color.White;
            btnRecargar.Location = new Point(911, 35);
            btnRecargar.Margin = new Padding(5, 0, 8, 4);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(185, 40);
            btnRecargar.TabIndex = 4;
            btnRecargar.Text = "RECARGAR DATOS";
            btnRecargar.UseVisualStyleBackColor = false;
            // 
            // lblHistorial
            // 
            lblHistorial.Dock = DockStyle.Fill;
            lblHistorial.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblHistorial.ForeColor = Color.FromArgb(18, 63, 73);
            lblHistorial.Location = new Point(21, 299);
            lblHistorial.Name = "lblHistorial";
            lblHistorial.Padding = new Padding(6, 7, 0, 0);
            lblHistorial.Size = new Size(1108, 40);
            lblHistorial.TabIndex = 3;
            lblHistorial.Text = "HISTORIAL DE CONSULTAS";
            // 
            // dgvConsultas
            // 
            dgvConsultas.AllowUserToAddRows = false;
            dgvConsultas.AllowUserToDeleteRows = false;
            dgvConsultas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(246, 250, 250);
            dgvConsultas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvConsultas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvConsultas.BackgroundColor = Color.White;
            dgvConsultas.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(18, 63, 73);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvConsultas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvConsultas.ColumnHeadersHeight = 42;
            dgvConsultas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(18, 63, 73);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(209, 237, 234);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(18, 63, 73);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvConsultas.DefaultCellStyle = dataGridViewCellStyle3;
            dgvConsultas.Dock = DockStyle.Fill;
            dgvConsultas.EnableHeadersVisualStyles = false;
            dgvConsultas.Location = new Point(22, 339);
            dgvConsultas.Margin = new Padding(4, 0, 4, 10);
            dgvConsultas.MultiSelect = false;
            dgvConsultas.Name = "dgvConsultas";
            dgvConsultas.ReadOnly = true;
            dgvConsultas.RowHeadersVisible = false;
            dgvConsultas.RowTemplate.Height = 34;
            dgvConsultas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultas.Size = new Size(1106, 336);
            dgvConsultas.TabIndex = 4;
            // 
            // panelDetalle
            // 
            panelDetalle.BackColor = Color.White;
            panelDetalle.Controls.Add(lblDetalle);
            panelDetalle.Controls.Add(lblCategoria);
            panelDetalle.Dock = DockStyle.Fill;
            panelDetalle.Location = new Point(22, 685);
            panelDetalle.Margin = new Padding(4, 0, 4, 8);
            panelDetalle.Name = "panelDetalle";
            panelDetalle.Size = new Size(1106, 97);
            panelDetalle.TabIndex = 5;
            // 
            // lblDetalle
            // 
            lblDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDetalle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDetalle.ForeColor = Color.FromArgb(18, 63, 73);
            lblDetalle.Location = new Point(18, 12);
            lblDetalle.Name = "lblDetalle";
            lblDetalle.Size = new Size(1806, 32);
            lblDetalle.TabIndex = 0;
            lblDetalle.Text = "Selecciona una consulta";
            // 
            // lblCategoria
            // 
            lblCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCategoria.Font = new Font("Segoe UI", 11F);
            lblCategoria.ForeColor = Color.FromArgb(20, 125, 134);
            lblCategoria.Location = new Point(18, 52);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(1806, 28);
            lblCategoria.TabIndex = 1;
            lblCategoria.Text = "Categoría IMC: —";
            // 
            // acciones
            // 
            acciones.ColumnCount = 2;
            acciones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            acciones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            acciones.Controls.Add(btnCerrar, 0, 0);
            acciones.Controls.Add(lblEstado, 1, 0);
            acciones.Dock = DockStyle.Fill;
            acciones.Location = new Point(21, 793);
            acciones.Name = "acciones";
            acciones.RowCount = 1;
            acciones.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            acciones.Size = new Size(1108, 44);
            acciones.TabIndex = 6;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(18, 63, 73);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.Dock = DockStyle.Fill;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(5, 0);
            btnCerrar.Margin = new Padding(5, 0, 8, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(147, 40);
            btnCerrar.TabIndex = 0;
            btnCerrar.Text = "CERRAR";
            btnCerrar.UseVisualStyleBackColor = false;
            // 
            // lblEstado
            // 
            lblEstado.Dock = DockStyle.Fill;
            lblEstado.ForeColor = Color.FromArgb(105, 127, 132);
            lblEstado.Location = new Point(163, 0);
            lblEstado.Name = "lblEstado";
            lblEstado.Padding = new Padding(0, 0, 10, 0);
            lblEstado.Size = new Size(942, 44);
            lblEstado.TabIndex = 1;
            lblEstado.Text = "Esperando información...";
            lblEstado.TextAlign = ContentAlignment.MiddleRight;
            // 
            // frmConsultas
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 247, 247);
            ClientSize = new Size(1150, 850);
            Controls.Add(principal);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(900, 650);
            Name = "frmConsultas";
            Text = "Clínica Salud y Bienestar | Consultas";
            WindowState = FormWindowState.Maximized;
            principal.ResumeLayout(false);
            encabezado.ResumeLayout(false);
            encabezado.PerformLayout();
            tarjetas.ResumeLayout(false);
            tarjetaTotal.ResumeLayout(false);
            tarjetaTotal.PerformLayout();
            tarjetaMostradas.ResumeLayout(false);
            tarjetaMostradas.PerformLayout();
            tarjetaIMC.ResumeLayout(false);
            tarjetaIMC.PerformLayout();
            filtros.ResumeLayout(false);
            filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConsultas).EndInit();
            panelDetalle.ResumeLayout(false);
            acciones.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
