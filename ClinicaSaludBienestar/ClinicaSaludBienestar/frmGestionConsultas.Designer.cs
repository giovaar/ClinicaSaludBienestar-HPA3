
#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicaSaludBienestar
{
    partial class frmGestionConsultas
    {
        private System.ComponentModel.IContainer? components = null;

        private TableLayoutPanel raiz = null!;
        private Panel encabezado = null!;
        private Label titulo = null!;
        private Label subtitulo = null!;

        private TableLayoutPanel principal = null!;
        private TableLayoutPanel barra = null!;
        private Label lblTabla = null!;
        private Button btnRecargar = null!;
        private Button btnCerrar = null!;

        private DataGridView dgvConsultas = null!;

        private Panel panelDatos = null!;
        private TableLayoutPanel editor = null!;
        private Label lblSeleccion = null!;

        private TableLayoutPanel campoPaciente = null!;
        private TableLayoutPanel campoFecha = null!;
        private TableLayoutPanel campoPeso = null!;
        private TableLayoutPanel campoEstatura = null!;

        private Label lblPaciente = null!;
        private Label lblFecha = null!;
        private Label lblPeso = null!;
        private Label lblEstatura = null!;

        private ComboBox cmbPaciente = null!;
        private DateTimePicker dtpFecha = null!;
        private NumericUpDown nudPeso = null!;
        private NumericUpDown nudEstatura = null!;

        private Label lblIMC = null!;
        private FlowLayoutPanel botones = null!;

        private Button btnNuevo = null!;
        private Button btnAgregar = null!;
        private Button btnActualizar = null!;
        private Button btnEliminar = null!;

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
            raiz = new TableLayoutPanel();
            encabezado = new Panel();
            titulo = new Label();
            subtitulo = new Label();
            principal = new TableLayoutPanel();
            barra = new TableLayoutPanel();
            lblTabla = new Label();
            btnRecargar = new Button();
            btnCerrar = new Button();
            dgvConsultas = new DataGridView();
            panelDatos = new Panel();
            editor = new TableLayoutPanel();
            lblSeleccion = new Label();
            campoPaciente = new TableLayoutPanel();
            lblPaciente = new Label();
            cmbPaciente = new ComboBox();
            campoFecha = new TableLayoutPanel();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            campoPeso = new TableLayoutPanel();
            lblPeso = new Label();
            nudPeso = new NumericUpDown();
            campoEstatura = new TableLayoutPanel();
            lblEstatura = new Label();
            nudEstatura = new NumericUpDown();
            lblIMC = new Label();
            botones = new FlowLayoutPanel();
            btnNuevo = new Button();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            lblEstado = new Label();
            raiz.SuspendLayout();
            encabezado.SuspendLayout();
            principal.SuspendLayout();
            barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConsultas).BeginInit();
            panelDatos.SuspendLayout();
            editor.SuspendLayout();
            campoPaciente.SuspendLayout();
            campoFecha.SuspendLayout();
            campoPeso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPeso).BeginInit();
            campoEstatura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudEstatura).BeginInit();
            botones.SuspendLayout();
            SuspendLayout();
            // 
            // raiz
            // 
            raiz.ColumnCount = 1;
            raiz.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            raiz.Controls.Add(encabezado, 0, 0);
            raiz.Controls.Add(principal, 0, 1);
            raiz.Dock = DockStyle.Fill;
            raiz.Location = new Point(0, 0);
            raiz.Margin = new Padding(0);
            raiz.Name = "raiz";
            raiz.RowCount = 2;
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
            raiz.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            raiz.Size = new Size(1200, 850);
            raiz.TabIndex = 0;
            // 
            // encabezado
            // 
            encabezado.BackColor = Color.FromArgb(18, 63, 73);
            encabezado.Controls.Add(titulo);
            encabezado.Controls.Add(subtitulo);
            encabezado.Dock = DockStyle.Fill;
            encabezado.Location = new Point(3, 3);
            encabezado.Name = "encabezado";
            encabezado.Size = new Size(1194, 89);
            encabezado.TabIndex = 0;
            // 
            // titulo
            // 
            titulo.AutoSize = true;
            titulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.Location = new Point(30, 12);
            titulo.Name = "titulo";
            titulo.Size = new Size(373, 41);
            titulo.TabIndex = 0;
            titulo.Text = "GESTIÓN DE CONSULTAS";
            // 
            // subtitulo
            // 
            subtitulo.AutoSize = true;
            subtitulo.ForeColor = Color.LightCyan;
            subtitulo.Location = new Point(33, 60);
            subtitulo.Name = "subtitulo";
            subtitulo.Size = new Size(180, 19);
            subtitulo.TabIndex = 1;
            subtitulo.Text = "Registros clínicos | ClinicaDB";
            // 
            // principal
            // 
            principal.BackColor = Color.FromArgb(240, 247, 247);
            principal.ColumnCount = 1;
            principal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            principal.Controls.Add(barra, 0, 0);
            principal.Controls.Add(dgvConsultas, 0, 1);
            principal.Controls.Add(panelDatos, 0, 2);
            principal.Controls.Add(lblEstado, 0, 3);
            principal.Dock = DockStyle.Fill;
            principal.Location = new Point(3, 98);
            principal.Name = "principal";
            principal.Padding = new Padding(24, 15, 24, 15);
            principal.RowCount = 4;
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            principal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 260F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            principal.Size = new Size(1194, 749);
            principal.TabIndex = 1;
            // 
            // barra
            // 
            barra.ColumnCount = 3;
            barra.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            barra.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            barra.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            barra.Controls.Add(lblTabla, 0, 0);
            barra.Controls.Add(btnRecargar, 1, 0);
            barra.Controls.Add(btnCerrar, 2, 0);
            barra.Dock = DockStyle.Fill;
            barra.Location = new Point(24, 15);
            barra.Margin = new Padding(0);
            barra.Name = "barra";
            barra.RowCount = 1;
            barra.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            barra.Size = new Size(1146, 58);
            barra.TabIndex = 0;
            // 
            // lblTabla
            // 
            lblTabla.Dock = DockStyle.Fill;
            lblTabla.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTabla.ForeColor = Color.FromArgb(18, 63, 73);
            lblTabla.Location = new Point(3, 0);
            lblTabla.Name = "lblTabla";
            lblTabla.Size = new Size(860, 58);
            lblTabla.TabIndex = 0;
            lblTabla.Text = "CONSULTAS REGISTRADAS";
            lblTabla.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnRecargar
            // 
            btnRecargar.BackColor = Color.FromArgb(20, 125, 134);
            btnRecargar.Cursor = Cursors.Hand;
            btnRecargar.Dock = DockStyle.Fill;
            btnRecargar.FlatAppearance.BorderSize = 0;
            btnRecargar.FlatStyle = FlatStyle.Flat;
            btnRecargar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRecargar.ForeColor = Color.White;
            btnRecargar.Location = new Point(870, 4);
            btnRecargar.Margin = new Padding(4);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(142, 50);
            btnRecargar.TabIndex = 1;
            btnRecargar.Text = "RECARGAR";
            btnRecargar.UseVisualStyleBackColor = false;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(18, 63, 73);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.Dock = DockStyle.Fill;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(1020, 4);
            btnCerrar.Margin = new Padding(4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(122, 50);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "CERRAR";
            btnCerrar.UseVisualStyleBackColor = false;
            // 
            // dgvConsultas
            // 
            dgvConsultas.AllowUserToAddRows = false;
            dgvConsultas.AllowUserToDeleteRows = false;
            dgvConsultas.AllowUserToResizeRows = false;
            dgvConsultas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvConsultas.BackgroundColor = Color.White;
            dgvConsultas.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(18, 63, 73);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvConsultas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvConsultas.ColumnHeadersHeight = 42;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(209, 237, 234);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(18, 63, 73);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvConsultas.DefaultCellStyle = dataGridViewCellStyle2;
            dgvConsultas.Dock = DockStyle.Fill;
            dgvConsultas.EnableHeadersVisualStyles = false;
            dgvConsultas.Location = new Point(24, 73);
            dgvConsultas.Margin = new Padding(0, 0, 0, 12);
            dgvConsultas.MultiSelect = false;
            dgvConsultas.Name = "dgvConsultas";
            dgvConsultas.ReadOnly = true;
            dgvConsultas.RowHeadersVisible = false;
            dgvConsultas.RowTemplate.Height = 34;
            dgvConsultas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultas.Size = new Size(1146, 357);
            dgvConsultas.TabIndex = 1;
            // 
            // panelDatos
            // 
            panelDatos.BackColor = Color.White;
            panelDatos.Controls.Add(editor);
            panelDatos.Dock = DockStyle.Fill;
            panelDatos.Location = new Point(27, 445);
            panelDatos.Name = "panelDatos";
            panelDatos.Padding = new Padding(20);
            panelDatos.Size = new Size(1140, 254);
            panelDatos.TabIndex = 2;
            // 
            // editor
            // 
            editor.ColumnCount = 4;
            editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            editor.Controls.Add(lblSeleccion, 0, 0);
            editor.Controls.Add(campoPaciente, 0, 1);
            editor.Controls.Add(campoFecha, 1, 1);
            editor.Controls.Add(campoPeso, 2, 1);
            editor.Controls.Add(campoEstatura, 3, 1);
            editor.Controls.Add(lblIMC, 0, 2);
            editor.Controls.Add(botones, 0, 3);
            editor.Dock = DockStyle.Fill;
            editor.Location = new Point(20, 20);
            editor.Name = "editor";
            editor.RowCount = 4;
            editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            editor.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            editor.Size = new Size(1100, 214);
            editor.TabIndex = 0;
            // 
            // lblSeleccion
            // 
            editor.SetColumnSpan(lblSeleccion, 4);
            lblSeleccion.Dock = DockStyle.Fill;
            lblSeleccion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSeleccion.ForeColor = Color.FromArgb(18, 63, 73);
            lblSeleccion.Location = new Point(3, 0);
            lblSeleccion.Name = "lblSeleccion";
            lblSeleccion.Size = new Size(1094, 37);
            lblSeleccion.TabIndex = 0;
            lblSeleccion.Text = "Nueva consulta | Sin selección";
            // 
            // campoPaciente
            // 
            campoPaciente.ColumnCount = 1;
            campoPaciente.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            campoPaciente.Controls.Add(lblPaciente, 0, 0);
            campoPaciente.Controls.Add(cmbPaciente, 0, 1);
            campoPaciente.Dock = DockStyle.Fill;
            campoPaciente.Location = new Point(3, 40);
            campoPaciente.Name = "campoPaciente";
            campoPaciente.Padding = new Padding(3, 0, 12, 0);
            campoPaciente.RowCount = 2;
            campoPaciente.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            campoPaciente.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            campoPaciente.Size = new Size(269, 69);
            campoPaciente.TabIndex = 1;
            // 
            // lblPaciente
            // 
            lblPaciente.Dock = DockStyle.Fill;
            lblPaciente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPaciente.ForeColor = Color.FromArgb(18, 63, 73);
            lblPaciente.Location = new Point(6, 0);
            lblPaciente.Name = "lblPaciente";
            lblPaciente.Size = new Size(248, 27);
            lblPaciente.TabIndex = 0;
            lblPaciente.Text = "Paciente";
            // 
            // cmbPaciente
            // 
            cmbPaciente.Dock = DockStyle.Top;
            cmbPaciente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaciente.Font = new Font("Segoe UI", 11F);
            cmbPaciente.Location = new Point(6, 30);
            cmbPaciente.Name = "cmbPaciente";
            cmbPaciente.Size = new Size(248, 28);
            cmbPaciente.TabIndex = 1;
            // 
            // campoFecha
            // 
            campoFecha.ColumnCount = 1;
            campoFecha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            campoFecha.Controls.Add(lblFecha, 0, 0);
            campoFecha.Controls.Add(dtpFecha, 0, 1);
            campoFecha.Dock = DockStyle.Fill;
            campoFecha.Location = new Point(278, 40);
            campoFecha.Name = "campoFecha";
            campoFecha.Padding = new Padding(3, 0, 12, 0);
            campoFecha.RowCount = 2;
            campoFecha.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            campoFecha.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            campoFecha.Size = new Size(269, 69);
            campoFecha.TabIndex = 2;
            // 
            // lblFecha
            // 
            lblFecha.Dock = DockStyle.Fill;
            lblFecha.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFecha.ForeColor = Color.FromArgb(18, 63, 73);
            lblFecha.Location = new Point(6, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(248, 27);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha de consulta";
            // 
            // dtpFecha
            // 
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            dtpFecha.Dock = DockStyle.Top;
            dtpFecha.Font = new Font("Segoe UI", 11F);
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.Location = new Point(6, 30);
            dtpFecha.MaxDate = new DateTime(2026, 11, 10, 0, 0, 0, 0);
            dtpFecha.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(248, 27);
            dtpFecha.TabIndex = 1;
            dtpFecha.Value = new DateTime(2026, 11, 10, 0, 0, 0, 0);
            // 
            // campoPeso
            // 
            campoPeso.ColumnCount = 1;
            campoPeso.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            campoPeso.Controls.Add(lblPeso, 0, 0);
            campoPeso.Controls.Add(nudPeso, 0, 1);
            campoPeso.Dock = DockStyle.Fill;
            campoPeso.Location = new Point(553, 40);
            campoPeso.Name = "campoPeso";
            campoPeso.Padding = new Padding(3, 0, 12, 0);
            campoPeso.RowCount = 2;
            campoPeso.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            campoPeso.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            campoPeso.Size = new Size(269, 69);
            campoPeso.TabIndex = 3;
            // 
            // lblPeso
            // 
            lblPeso.Dock = DockStyle.Fill;
            lblPeso.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPeso.ForeColor = Color.FromArgb(18, 63, 73);
            lblPeso.Location = new Point(6, 0);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(248, 27);
            lblPeso.TabIndex = 0;
            lblPeso.Text = "Peso (kg)";
            // 
            // nudPeso
            // 
            nudPeso.DecimalPlaces = 2;
            nudPeso.Dock = DockStyle.Top;
            nudPeso.Font = new Font("Segoe UI", 11F);
            nudPeso.Increment = new decimal(new int[] { 10, 0, 0, 131072 });
            nudPeso.Location = new Point(6, 30);
            nudPeso.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudPeso.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPeso.Name = "nudPeso";
            nudPeso.Size = new Size(248, 27);
            nudPeso.TabIndex = 1;
            nudPeso.Value = new decimal(new int[] { 75, 0, 0, 0 });
            // 
            // campoEstatura
            // 
            campoEstatura.ColumnCount = 1;
            campoEstatura.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            campoEstatura.Controls.Add(lblEstatura, 0, 0);
            campoEstatura.Controls.Add(nudEstatura, 0, 1);
            campoEstatura.Dock = DockStyle.Fill;
            campoEstatura.Location = new Point(828, 40);
            campoEstatura.Name = "campoEstatura";
            campoEstatura.Padding = new Padding(3, 0, 12, 0);
            campoEstatura.RowCount = 2;
            campoEstatura.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            campoEstatura.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            campoEstatura.Size = new Size(269, 69);
            campoEstatura.TabIndex = 4;
            // 
            // lblEstatura
            // 
            lblEstatura.Dock = DockStyle.Fill;
            lblEstatura.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEstatura.ForeColor = Color.FromArgb(18, 63, 73);
            lblEstatura.Location = new Point(6, 0);
            lblEstatura.Name = "lblEstatura";
            lblEstatura.Size = new Size(248, 27);
            lblEstatura.TabIndex = 0;
            lblEstatura.Text = "Estatura (m)";
            // 
            // nudEstatura
            // 
            nudEstatura.DecimalPlaces = 2;
            nudEstatura.Dock = DockStyle.Top;
            nudEstatura.Font = new Font("Segoe UI", 11F);
            nudEstatura.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudEstatura.Location = new Point(6, 30);
            nudEstatura.Maximum = new decimal(new int[] { 250, 0, 0, 131072 });
            nudEstatura.Minimum = new decimal(new int[] { 50, 0, 0, 131072 });
            nudEstatura.Name = "nudEstatura";
            nudEstatura.Size = new Size(248, 27);
            nudEstatura.TabIndex = 1;
            nudEstatura.Value = new decimal(new int[] { 175, 0, 0, 131072 });
            // 
            // lblIMC
            // 
            editor.SetColumnSpan(lblIMC, 4);
            lblIMC.Dock = DockStyle.Fill;
            lblIMC.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblIMC.ForeColor = Color.FromArgb(20, 125, 134);
            lblIMC.Location = new Point(3, 112);
            lblIMC.Name = "lblIMC";
            lblIMC.Size = new Size(1094, 45);
            lblIMC.TabIndex = 5;
            lblIMC.Text = "IMC CALCULADO: 24.5";
            lblIMC.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // botones
            // 
            editor.SetColumnSpan(botones, 4);
            botones.Controls.Add(btnNuevo);
            botones.Controls.Add(btnAgregar);
            botones.Controls.Add(btnActualizar);
            botones.Controls.Add(btnEliminar);
            botones.Dock = DockStyle.Fill;
            botones.Location = new Point(3, 160);
            botones.Name = "botones";
            botones.Size = new Size(1094, 51);
            botones.TabIndex = 6;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(18, 63, 73);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(4, 4);
            btnNuevo.Margin = new Padding(4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(160, 40);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "LIMPIAR / NUEVA";
            btnNuevo.UseVisualStyleBackColor = false;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(20, 125, 134);
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(172, 4);
            btnAgregar.Margin = new Padding(4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(135, 40);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(20, 125, 134);
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(315, 4);
            btnActualizar.Margin = new Padding(4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(145, 40);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Firebrick;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(468, 4);
            btnEliminar.Margin = new Padding(4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(135, 40);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // lblEstado
            // 
            lblEstado.Dock = DockStyle.Fill;
            lblEstado.ForeColor = Color.FromArgb(105, 127, 132);
            lblEstado.Location = new Point(27, 702);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(1140, 32);
            lblEstado.TabIndex = 3;
            lblEstado.Text = "Esperando conexión...";
            lblEstado.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmGestionConsultas
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 247, 247);
            ClientSize = new Size(1200, 850);
            Controls.Add(raiz);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1050, 700);
            Name = "frmGestionConsultas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clínica Salud y Bienestar | Gestión de consultas";
            WindowState = FormWindowState.Maximized;
            raiz.ResumeLayout(false);
            encabezado.ResumeLayout(false);
            encabezado.PerformLayout();
            principal.ResumeLayout(false);
            barra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvConsultas).EndInit();
            panelDatos.ResumeLayout(false);
            editor.ResumeLayout(false);
            campoPaciente.ResumeLayout(false);
            campoFecha.ResumeLayout(false);
            campoPeso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudPeso).EndInit();
            campoEstatura.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudEstatura).EndInit();
            botones.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
