
#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicaSaludBienestar
{
    partial class frmPacientes
    {
        private System.ComponentModel.IContainer? components = null;

        private TableLayoutPanel principal = null!;
        private Panel encabezado = null!;
        private Label titulo = null!;
        private Label subtitulo = null!;

        private TableLayoutPanel tarjetas = null!;
        private Panel tarjetaPacientes = null!;
        private Panel tarjetaConsultas = null!;
        private Label lblTituloPacientes = null!;
        private Label lblTituloConsultas = null!;
        private Label lblPacientes = null!;
        private Label lblConsultas = null!;

        private TableLayoutPanel filtros = null!;
        private Label lblBuscar = null!;
        private TextBox txtBuscar = null!;
        private Button btnRecargar = null!;
        private Button btnCerrar = null!;

        private DataGridView dgvPacientes = null!;
        private DataGridView dgvHistorial = null!;
        private Label lblHistorial = null!;
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            principal = new TableLayoutPanel();
            encabezado = new Panel();
            titulo = new Label();
            subtitulo = new Label();
            tarjetas = new TableLayoutPanel();
            tarjetaPacientes = new Panel();
            lblTituloPacientes = new Label();
            lblPacientes = new Label();
            tarjetaConsultas = new Panel();
            lblTituloConsultas = new Label();
            lblConsultas = new Label();
            filtros = new TableLayoutPanel();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnRecargar = new Button();
            btnCerrar = new Button();
            dgvPacientes = new DataGridView();
            lblHistorial = new Label();
            dgvHistorial = new DataGridView();
            lblEstado = new Label();
            principal.SuspendLayout();
            encabezado.SuspendLayout();
            tarjetas.SuspendLayout();
            tarjetaPacientes.SuspendLayout();
            tarjetaConsultas.SuspendLayout();
            filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
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
            principal.Controls.Add(dgvPacientes, 0, 3);
            principal.Controls.Add(lblHistorial, 0, 4);
            principal.Controls.Add(dgvHistorial, 0, 5);
            principal.Controls.Add(lblEstado, 0, 6);
            principal.Dock = DockStyle.Fill;
            principal.Location = new Point(0, 0);
            principal.Name = "principal";
            principal.Padding = new Padding(18, 0, 18, 10);
            principal.RowCount = 7;
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 112F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            principal.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            principal.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
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
            titulo.Size = new Size(409, 41);
            titulo.TabIndex = 0;
            titulo.Text = "DIRECTORIO DE PACIENTES";
            // 
            // subtitulo
            // 
            subtitulo.AutoSize = true;
            subtitulo.ForeColor = Color.LightCyan;
            subtitulo.Location = new Point(25, 60);
            subtitulo.Name = "subtitulo";
            subtitulo.Size = new Size(246, 19);
            subtitulo.TabIndex = 1;
            subtitulo.Text = "Gestión clínica • Información e historial";
            // 
            // tarjetas
            // 
            tarjetas.ColumnCount = 2;
            tarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tarjetas.Controls.Add(tarjetaPacientes, 0, 0);
            tarjetas.Controls.Add(tarjetaConsultas, 1, 0);
            tarjetas.Dock = DockStyle.Fill;
            tarjetas.Location = new Point(21, 98);
            tarjetas.Name = "tarjetas";
            tarjetas.RowCount = 1;
            tarjetas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tarjetas.Size = new Size(1108, 106);
            tarjetas.TabIndex = 1;
            // 
            // tarjetaPacientes
            // 
            tarjetaPacientes.BackColor = Color.White;
            tarjetaPacientes.Controls.Add(lblTituloPacientes);
            tarjetaPacientes.Controls.Add(lblPacientes);
            tarjetaPacientes.Dock = DockStyle.Fill;
            tarjetaPacientes.Location = new Point(4, 10);
            tarjetaPacientes.Margin = new Padding(4, 10, 8, 10);
            tarjetaPacientes.Name = "tarjetaPacientes";
            tarjetaPacientes.Size = new Size(542, 86);
            tarjetaPacientes.TabIndex = 0;
            // 
            // lblTituloPacientes
            // 
            lblTituloPacientes.AutoSize = true;
            lblTituloPacientes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloPacientes.ForeColor = Color.FromArgb(105, 127, 132);
            lblTituloPacientes.Location = new Point(18, 12);
            lblTituloPacientes.Name = "lblTituloPacientes";
            lblTituloPacientes.Size = new Size(179, 19);
            lblTituloPacientes.TabIndex = 0;
            lblTituloPacientes.Text = "PACIENTES REGISTRADOS";
            // 
            // lblPacientes
            // 
            lblPacientes.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblPacientes.ForeColor = Color.FromArgb(20, 125, 134);
            lblPacientes.Location = new Point(16, 42);
            lblPacientes.Name = "lblPacientes";
            lblPacientes.Size = new Size(290, 49);
            lblPacientes.TabIndex = 1;
            lblPacientes.Text = "—";
            // 
            // tarjetaConsultas
            // 
            tarjetaConsultas.BackColor = Color.White;
            tarjetaConsultas.Controls.Add(lblTituloConsultas);
            tarjetaConsultas.Controls.Add(lblConsultas);
            tarjetaConsultas.Dock = DockStyle.Fill;
            tarjetaConsultas.Location = new Point(558, 10);
            tarjetaConsultas.Margin = new Padding(4, 10, 8, 10);
            tarjetaConsultas.Name = "tarjetaConsultas";
            tarjetaConsultas.Size = new Size(542, 86);
            tarjetaConsultas.TabIndex = 1;
            // 
            // lblTituloConsultas
            // 
            lblTituloConsultas.AutoSize = true;
            lblTituloConsultas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloConsultas.ForeColor = Color.FromArgb(105, 127, 132);
            lblTituloConsultas.Location = new Point(18, 12);
            lblTituloConsultas.Name = "lblTituloConsultas";
            lblTituloConsultas.Size = new Size(186, 19);
            lblTituloConsultas.TabIndex = 0;
            lblTituloConsultas.Text = "CONSULTAS REGISTRADAS";
            // 
            // lblConsultas
            // 
            lblConsultas.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblConsultas.ForeColor = Color.FromArgb(20, 125, 134);
            lblConsultas.Location = new Point(16, 42);
            lblConsultas.Name = "lblConsultas";
            lblConsultas.Size = new Size(290, 49);
            lblConsultas.TabIndex = 1;
            lblConsultas.Text = "—";
            // 
            // filtros
            // 
            filtros.ColumnCount = 3;
            filtros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            filtros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210F));
            filtros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145F));
            filtros.Controls.Add(lblBuscar, 0, 0);
            filtros.Controls.Add(txtBuscar, 0, 1);
            filtros.Controls.Add(btnRecargar, 1, 1);
            filtros.Controls.Add(btnCerrar, 2, 1);
            filtros.Dock = DockStyle.Fill;
            filtros.Location = new Point(21, 210);
            filtros.Name = "filtros";
            filtros.Padding = new Padding(4, 8, 4, 8);
            filtros.RowCount = 2;
            filtros.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            filtros.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            filtros.Size = new Size(1108, 86);
            filtros.TabIndex = 2;
            // 
            // lblBuscar
            // 
            lblBuscar.Dock = DockStyle.Fill;
            lblBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.FromArgb(18, 63, 73);
            lblBuscar.Location = new Point(7, 8);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(739, 28);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "BUSCAR PACIENTE";
            // 
            // txtBuscar
            // 
            txtBuscar.Dock = DockStyle.Fill;
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.Location = new Point(4, 36);
            txtBuscar.Margin = new Padding(0, 0, 12, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Escribe un nombre o apellido...";
            txtBuscar.Size = new Size(733, 27);
            txtBuscar.TabIndex = 1;
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
            btnRecargar.Location = new Point(754, 36);
            btnRecargar.Margin = new Padding(5, 0, 8, 4);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(197, 38);
            btnRecargar.TabIndex = 2;
            btnRecargar.Text = "RECARGAR DATOS";
            btnRecargar.UseVisualStyleBackColor = false;
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
            btnCerrar.Location = new Point(964, 36);
            btnCerrar.Margin = new Padding(5, 0, 8, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(132, 38);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "CERRAR";
            btnCerrar.UseVisualStyleBackColor = false;
            // 
            // dgvPacientes
            // 
            dgvPacientes.AllowUserToAddRows = false;
            dgvPacientes.AllowUserToDeleteRows = false;
            dgvPacientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(246, 250, 250);
            dgvPacientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPacientes.BackgroundColor = Color.White;
            dgvPacientes.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(18, 63, 73);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPacientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPacientes.ColumnHeadersHeight = 42;
            dgvPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(18, 63, 73);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(209, 237, 234);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(18, 63, 73);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPacientes.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPacientes.Dock = DockStyle.Fill;
            dgvPacientes.EnableHeadersVisualStyles = false;
            dgvPacientes.Location = new Point(22, 303);
            dgvPacientes.Margin = new Padding(4, 4, 4, 8);
            dgvPacientes.MultiSelect = false;
            dgvPacientes.Name = "dgvPacientes";
            dgvPacientes.ReadOnly = true;
            dgvPacientes.RowHeadersVisible = false;
            dgvPacientes.RowTemplate.Height = 34;
            dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPacientes.Size = new Size(1106, 239);
            dgvPacientes.TabIndex = 3;
            // 
            // lblHistorial
            // 
            lblHistorial.Dock = DockStyle.Fill;
            lblHistorial.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblHistorial.ForeColor = Color.FromArgb(18, 63, 73);
            lblHistorial.Location = new Point(21, 550);
            lblHistorial.Name = "lblHistorial";
            lblHistorial.Padding = new Padding(6, 6, 0, 0);
            lblHistorial.Size = new Size(1108, 38);
            lblHistorial.TabIndex = 4;
            lblHistorial.Text = "HISTORIAL DE CONSULTAS";
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(246, 250, 250);
            dgvHistorial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.BackgroundColor = Color.White;
            dgvHistorial.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(18, 63, 73);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvHistorial.ColumnHeadersHeight = 42;
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(18, 63, 73);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(209, 237, 234);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(18, 63, 73);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvHistorial.DefaultCellStyle = dataGridViewCellStyle6;
            dgvHistorial.Dock = DockStyle.Fill;
            dgvHistorial.EnableHeadersVisualStyles = false;
            dgvHistorial.Location = new Point(22, 588);
            dgvHistorial.Margin = new Padding(4, 0, 4, 6);
            dgvHistorial.MultiSelect = false;
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.RowTemplate.Height = 34;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(1106, 200);
            dgvHistorial.TabIndex = 5;
            // 
            // lblEstado
            // 
            lblEstado.Dock = DockStyle.Fill;
            lblEstado.ForeColor = Color.FromArgb(105, 127, 132);
            lblEstado.Location = new Point(21, 794);
            lblEstado.Name = "lblEstado";
            lblEstado.Padding = new Padding(8, 0, 0, 0);
            lblEstado.Size = new Size(1108, 46);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Esperando información...";
            lblEstado.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmPacientes
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 247, 247);
            ClientSize = new Size(1150, 850);
            Controls.Add(principal);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(900, 650);
            Name = "frmPacientes";
            Text = "Clínica Salud y Bienestar | Pacientes";
            WindowState = FormWindowState.Maximized;
            principal.ResumeLayout(false);
            encabezado.ResumeLayout(false);
            encabezado.PerformLayout();
            tarjetas.ResumeLayout(false);
            tarjetaPacientes.ResumeLayout(false);
            tarjetaPacientes.PerformLayout();
            tarjetaConsultas.ResumeLayout(false);
            tarjetaConsultas.PerformLayout();
            filtros.ResumeLayout(false);
            filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
        }
    }
}
