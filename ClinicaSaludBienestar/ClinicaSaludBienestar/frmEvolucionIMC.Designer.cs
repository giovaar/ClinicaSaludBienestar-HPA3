
#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ClinicaSaludBienestar
{
    partial class frmEvolucionIMC
    {
        private System.ComponentModel.IContainer? components = null;

        private TableLayoutPanel principal = null!;
        private Panel encabezado = null!;
        private Label titulo = null!;
        private Label subtitulo = null!;

        private TableLayoutPanel filtros = null!;
        private Label lblSeleccion = null!;
        private ComboBox cmbPacientes = null!;
        private Button btnRecargar = null!;
        private Button btnCerrar = null!;

        private TableLayoutPanel tarjetas = null!;
        private Panel tarjetaInicial = null!;
        private Panel tarjetaActual = null!;
        private Panel tarjetaTendencia = null!;

        private Label lblTituloInicial = null!;
        private Label lblTituloActual = null!;
        private Label lblTituloTendencia = null!;

        private Label lblInicial = null!;
        private Label lblActual = null!;
        private Label lblTendencia = null!;
        private Label lblCategoria = null!;

        private TableLayoutPanel seccionGrafico = null!;
        private Label lblTituloGrafico = null!;
        private Chart chartIMC = null!;

        private TableLayoutPanel seccionTabla = null!;
        private Label lblTituloTabla = null!;
        private DataGridView dgvConsultas = null!;

        private Label lblEstado = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                components?.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ChartArea chartArea1 = new ChartArea();
            Series series1 = new Series();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            principal = new TableLayoutPanel();
            encabezado = new Panel();
            titulo = new Label();
            subtitulo = new Label();
            filtros = new TableLayoutPanel();
            lblSeleccion = new Label();
            cmbPacientes = new ComboBox();
            btnRecargar = new Button();
            btnCerrar = new Button();
            tarjetas = new TableLayoutPanel();
            tarjetaInicial = new Panel();
            lblTituloInicial = new Label();
            lblInicial = new Label();
            tarjetaActual = new Panel();
            lblTituloActual = new Label();
            lblActual = new Label();
            tarjetaTendencia = new Panel();
            lblTituloTendencia = new Label();
            lblTendencia = new Label();
            lblCategoria = new Label();
            seccionGrafico = new TableLayoutPanel();
            lblTituloGrafico = new Label();
            chartIMC = new Chart();
            seccionTabla = new TableLayoutPanel();
            lblTituloTabla = new Label();
            dgvConsultas = new DataGridView();
            lblEstado = new Label();
            principal.SuspendLayout();
            encabezado.SuspendLayout();
            filtros.SuspendLayout();
            tarjetas.SuspendLayout();
            tarjetaInicial.SuspendLayout();
            tarjetaActual.SuspendLayout();
            tarjetaTendencia.SuspendLayout();
            seccionGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartIMC).BeginInit();
            seccionTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConsultas).BeginInit();
            SuspendLayout();
            // 
            // principal
            // 
            principal.BackColor = Color.FromArgb(240, 247, 247);
            principal.ColumnCount = 1;
            principal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            principal.Controls.Add(encabezado, 0, 0);
            principal.Controls.Add(filtros, 0, 1);
            principal.Controls.Add(tarjetas, 0, 2);
            principal.Controls.Add(lblCategoria, 0, 3);
            principal.Controls.Add(seccionGrafico, 0, 4);
            principal.Controls.Add(seccionTabla, 0, 5);
            principal.Controls.Add(lblEstado, 0, 6);
            principal.Dock = DockStyle.Fill;
            principal.Location = new Point(0, 0);
            principal.Name = "principal";
            principal.Padding = new Padding(18, 0, 18, 12);
            principal.RowCount = 7;
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            principal.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            principal.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            principal.Size = new Size(1200, 850);
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
            encabezado.Size = new Size(1164, 90);
            encabezado.TabIndex = 0;
            // 
            // titulo
            // 
            titulo.AutoSize = true;
            titulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.Location = new Point(22, 9);
            titulo.Name = "titulo";
            titulo.Size = new Size(316, 41);
            titulo.TabIndex = 0;
            titulo.Text = "EVOLUCIÓN DEL IMC";
            // 
            // subtitulo
            // 
            subtitulo.AutoSize = true;
            subtitulo.ForeColor = Color.LightCyan;
            subtitulo.Location = new Point(25, 59);
            subtitulo.Name = "subtitulo";
            subtitulo.Size = new Size(221, 19);
            subtitulo.TabIndex = 1;
            subtitulo.Text = "Seguimiento histórico de pacientes";
            // 
            // filtros
            // 
            filtros.ColumnCount = 3;
            filtros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            filtros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            filtros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            filtros.Controls.Add(lblSeleccion, 0, 0);
            filtros.Controls.Add(cmbPacientes, 0, 1);
            filtros.Controls.Add(btnRecargar, 1, 1);
            filtros.Controls.Add(btnCerrar, 2, 1);
            filtros.Dock = DockStyle.Fill;
            filtros.Location = new Point(21, 98);
            filtros.Name = "filtros";
            filtros.Padding = new Padding(4, 6, 4, 6);
            filtros.RowCount = 2;
            filtros.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            filtros.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            filtros.Size = new Size(1158, 74);
            filtros.TabIndex = 1;
            // 
            // lblSeleccion
            // 
            lblSeleccion.Dock = DockStyle.Fill;
            lblSeleccion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSeleccion.ForeColor = Color.FromArgb(18, 63, 73);
            lblSeleccion.Location = new Point(7, 6);
            lblSeleccion.Name = "lblSeleccion";
            lblSeleccion.Size = new Size(814, 25);
            lblSeleccion.TabIndex = 0;
            lblSeleccion.Text = "SELECCIONAR PACIENTE";
            // 
            // cmbPacientes
            // 
            cmbPacientes.Dock = DockStyle.Fill;
            cmbPacientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPacientes.Font = new Font("Segoe UI", 11F);
            cmbPacientes.Location = new Point(4, 31);
            cmbPacientes.Margin = new Padding(0, 0, 14, 4);
            cmbPacientes.Name = "cmbPacientes";
            cmbPacientes.Size = new Size(806, 28);
            cmbPacientes.TabIndex = 1;
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
            btnRecargar.Location = new Point(829, 31);
            btnRecargar.Margin = new Padding(5, 0, 8, 3);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(167, 34);
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
            btnCerrar.Location = new Point(1009, 31);
            btnCerrar.Margin = new Padding(5, 0, 8, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(137, 34);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "CERRAR";
            btnCerrar.UseVisualStyleBackColor = false;
            // 
            // tarjetas
            // 
            tarjetas.ColumnCount = 3;
            tarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tarjetas.Controls.Add(tarjetaInicial, 0, 0);
            tarjetas.Controls.Add(tarjetaActual, 1, 0);
            tarjetas.Controls.Add(tarjetaTendencia, 2, 0);
            tarjetas.Dock = DockStyle.Fill;
            tarjetas.Location = new Point(21, 178);
            tarjetas.Name = "tarjetas";
            tarjetas.RowCount = 1;
            tarjetas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tarjetas.Size = new Size(1158, 104);
            tarjetas.TabIndex = 2;
            // 
            // tarjetaInicial
            // 
            tarjetaInicial.BackColor = Color.White;
            tarjetaInicial.Controls.Add(lblTituloInicial);
            tarjetaInicial.Controls.Add(lblInicial);
            tarjetaInicial.Dock = DockStyle.Fill;
            tarjetaInicial.Location = new Point(4, 5);
            tarjetaInicial.Margin = new Padding(4, 5, 8, 8);
            tarjetaInicial.Name = "tarjetaInicial";
            tarjetaInicial.Size = new Size(373, 91);
            tarjetaInicial.TabIndex = 0;
            // 
            // lblTituloInicial
            // 
            lblTituloInicial.AutoSize = true;
            lblTituloInicial.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloInicial.ForeColor = Color.FromArgb(105, 127, 132);
            lblTituloInicial.Location = new Point(18, 12);
            lblTituloInicial.Name = "lblTituloInicial";
            lblTituloInicial.Size = new Size(88, 19);
            lblTituloInicial.TabIndex = 0;
            lblTituloInicial.Text = "IMC INICIAL";
            // 
            // lblInicial
            // 
            lblInicial.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblInicial.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblInicial.ForeColor = Color.FromArgb(20, 125, 134);
            lblInicial.Location = new Point(15, 40);
            lblInicial.Name = "lblInicial";
            lblInicial.Size = new Size(473, 52);
            lblInicial.TabIndex = 1;
            lblInicial.Text = "—";
            // 
            // tarjetaActual
            // 
            tarjetaActual.BackColor = Color.White;
            tarjetaActual.Controls.Add(lblTituloActual);
            tarjetaActual.Controls.Add(lblActual);
            tarjetaActual.Dock = DockStyle.Fill;
            tarjetaActual.Location = new Point(389, 5);
            tarjetaActual.Margin = new Padding(4, 5, 8, 8);
            tarjetaActual.Name = "tarjetaActual";
            tarjetaActual.Size = new Size(373, 91);
            tarjetaActual.TabIndex = 1;
            // 
            // lblTituloActual
            // 
            lblTituloActual.AutoSize = true;
            lblTituloActual.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloActual.ForeColor = Color.FromArgb(105, 127, 132);
            lblTituloActual.Location = new Point(18, 12);
            lblTituloActual.Name = "lblTituloActual";
            lblTituloActual.Size = new Size(93, 19);
            lblTituloActual.TabIndex = 0;
            lblTituloActual.Text = "IMC ACTUAL";
            // 
            // lblActual
            // 
            lblActual.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblActual.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblActual.ForeColor = Color.FromArgb(20, 125, 134);
            lblActual.Location = new Point(15, 40);
            lblActual.Name = "lblActual";
            lblActual.Size = new Size(473, 52);
            lblActual.TabIndex = 1;
            lblActual.Text = "—";
            // 
            // tarjetaTendencia
            // 
            tarjetaTendencia.BackColor = Color.White;
            tarjetaTendencia.Controls.Add(lblTituloTendencia);
            tarjetaTendencia.Controls.Add(lblTendencia);
            tarjetaTendencia.Dock = DockStyle.Fill;
            tarjetaTendencia.Location = new Point(774, 5);
            tarjetaTendencia.Margin = new Padding(4, 5, 8, 8);
            tarjetaTendencia.Name = "tarjetaTendencia";
            tarjetaTendencia.Size = new Size(376, 91);
            tarjetaTendencia.TabIndex = 2;
            // 
            // lblTituloTendencia
            // 
            lblTituloTendencia.AutoSize = true;
            lblTituloTendencia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloTendencia.ForeColor = Color.FromArgb(105, 127, 132);
            lblTituloTendencia.Location = new Point(18, 12);
            lblTituloTendencia.Name = "lblTituloTendencia";
            lblTituloTendencia.Size = new Size(86, 19);
            lblTituloTendencia.TabIndex = 0;
            lblTituloTendencia.Text = "TENDENCIA";
            // 
            // lblTendencia
            // 
            lblTendencia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTendencia.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTendencia.ForeColor = Color.FromArgb(20, 125, 134);
            lblTendencia.Location = new Point(15, 40);
            lblTendencia.Name = "lblTendencia";
            lblTendencia.Size = new Size(476, 52);
            lblTendencia.TabIndex = 1;
            lblTendencia.Text = "—";
            // 
            // lblCategoria
            // 
            lblCategoria.Dock = DockStyle.Fill;
            lblCategoria.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCategoria.ForeColor = Color.FromArgb(18, 63, 73);
            lblCategoria.Location = new Point(21, 285);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Padding = new Padding(8, 9, 0, 0);
            lblCategoria.Size = new Size(1158, 43);
            lblCategoria.TabIndex = 3;
            lblCategoria.Text = "Categoría actual: —";
            // 
            // seccionGrafico
            // 
            seccionGrafico.ColumnCount = 1;
            seccionGrafico.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            seccionGrafico.Controls.Add(lblTituloGrafico, 0, 0);
            seccionGrafico.Controls.Add(chartIMC, 0, 1);
            seccionGrafico.Dock = DockStyle.Fill;
            seccionGrafico.Location = new Point(21, 331);
            seccionGrafico.Name = "seccionGrafico";
            seccionGrafico.RowCount = 2;
            seccionGrafico.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            seccionGrafico.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            seccionGrafico.Size = new Size(1158, 249);
            seccionGrafico.TabIndex = 4;
            // 
            // lblTituloGrafico
            // 
            lblTituloGrafico.Dock = DockStyle.Fill;
            lblTituloGrafico.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTituloGrafico.ForeColor = Color.FromArgb(18, 63, 73);
            lblTituloGrafico.Location = new Point(3, 0);
            lblTituloGrafico.Name = "lblTituloGrafico";
            lblTituloGrafico.Padding = new Padding(5, 3, 0, 0);
            lblTituloGrafico.Size = new Size(1152, 35);
            lblTituloGrafico.TabIndex = 0;
            lblTituloGrafico.Text = "GRÁFICO DE EVOLUCIÓN";
            // 
            // chartIMC
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.LabelStyle.Font = new Font("Segoe UI", 8F);
            chartArea1.AxisX.LineColor = Color.LightGray;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Title = "Fecha de consulta";
            chartArea1.AxisX.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
            chartArea1.AxisY.LabelStyle.Format = "0.0";
            chartArea1.AxisY.LineColor = Color.LightGray;
            chartArea1.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 235, 235);
            chartArea1.AxisY.Title = "IMC";
            chartArea1.AxisY.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
            chartArea1.BackColor = Color.White;
            chartArea1.Name = "AreaIMC";
            chartIMC.ChartAreas.Add(chartArea1);
            chartIMC.Dock = DockStyle.Fill;
            chartIMC.Location = new Point(4, 35);
            chartIMC.Margin = new Padding(4, 0, 4, 8);
            chartIMC.Name = "chartIMC";
            series1.BorderWidth = 3;
            series1.ChartArea = "AreaIMC";
            series1.ChartType = SeriesChartType.Line;
            series1.Color = Color.FromArgb(20, 125, 134);
            series1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.LabelFormat = "0.0";
            series1.MarkerColor = Color.FromArgb(20, 125, 134);
            series1.MarkerSize = 10;
            series1.MarkerStyle = MarkerStyle.Circle;
            series1.Name = "Evolución IMC";
            series1.XValueType = ChartValueType.Int32;
            series1.YValueType = ChartValueType.Double;
            chartIMC.Series.Add(series1);
            chartIMC.Size = new Size(1150, 206);
            chartIMC.TabIndex = 1;
            // 
            // seccionTabla
            // 
            seccionTabla.ColumnCount = 1;
            seccionTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            seccionTabla.Controls.Add(lblTituloTabla, 0, 0);
            seccionTabla.Controls.Add(dgvConsultas, 0, 1);
            seccionTabla.Dock = DockStyle.Fill;
            seccionTabla.Location = new Point(21, 586);
            seccionTabla.Name = "seccionTabla";
            seccionTabla.RowCount = 2;
            seccionTabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            seccionTabla.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            seccionTabla.Size = new Size(1158, 203);
            seccionTabla.TabIndex = 5;
            // 
            // lblTituloTabla
            // 
            lblTituloTabla.Dock = DockStyle.Fill;
            lblTituloTabla.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTituloTabla.ForeColor = Color.FromArgb(18, 63, 73);
            lblTituloTabla.Location = new Point(3, 0);
            lblTituloTabla.Name = "lblTituloTabla";
            lblTituloTabla.Padding = new Padding(5, 3, 0, 0);
            lblTituloTabla.Size = new Size(1152, 35);
            lblTituloTabla.TabIndex = 0;
            lblTituloTabla.Text = "HISTORIAL DE CONSULTAS";
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
            dgvConsultas.Location = new Point(4, 35);
            dgvConsultas.Margin = new Padding(4, 0, 4, 6);
            dgvConsultas.MultiSelect = false;
            dgvConsultas.Name = "dgvConsultas";
            dgvConsultas.ReadOnly = true;
            dgvConsultas.RowHeadersVisible = false;
            dgvConsultas.RowTemplate.Height = 34;
            dgvConsultas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultas.Size = new Size(1150, 162);
            dgvConsultas.TabIndex = 1;
            // 
            // lblEstado
            // 
            lblEstado.Dock = DockStyle.Fill;
            lblEstado.ForeColor = Color.FromArgb(105, 127, 132);
            lblEstado.Location = new Point(21, 792);
            lblEstado.Name = "lblEstado";
            lblEstado.Padding = new Padding(8, 0, 0, 0);
            lblEstado.Size = new Size(1158, 46);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Esperando información...";
            lblEstado.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmEvolucionIMC
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 247, 247);
            ClientSize = new Size(1200, 850);
            Controls.Add(principal);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(950, 700);
            Name = "frmEvolucionIMC";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clínica Salud y Bienestar | Evolución del IMC";
            WindowState = FormWindowState.Maximized;
            principal.ResumeLayout(false);
            encabezado.ResumeLayout(false);
            encabezado.PerformLayout();
            filtros.ResumeLayout(false);
            tarjetas.ResumeLayout(false);
            tarjetaInicial.ResumeLayout(false);
            tarjetaInicial.PerformLayout();
            tarjetaActual.ResumeLayout(false);
            tarjetaActual.PerformLayout();
            tarjetaTendencia.ResumeLayout(false);
            tarjetaTendencia.PerformLayout();
            seccionGrafico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartIMC).EndInit();
            seccionTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvConsultas).EndInit();
            ResumeLayout(false);
        }
    }
}
