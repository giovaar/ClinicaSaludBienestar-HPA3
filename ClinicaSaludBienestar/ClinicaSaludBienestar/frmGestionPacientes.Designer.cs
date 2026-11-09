
#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicaSaludBienestar
{
    partial class frmGestionPacientes
    {
        private System.ComponentModel.IContainer? components = null;

        private TableLayoutPanel raiz = null!;
        private Panel encabezado = null!;
        private Label titulo = null!;
        private Label subtitulo = null!;

        private TableLayoutPanel principal = null!;
        private TableLayoutPanel barra = null!;

        private TextBox txtBuscar = null!;
        private Button btnBuscar = null!;
        private Button btnRecargar = null!;

        private DataGridView dgvPacientes = null!;

        private Panel panelDatos = null!;
        private TableLayoutPanel editor = null!;

        private Label lblSeleccion = null!;

        private TableLayoutPanel campoNombre = null!;
        private TableLayoutPanel campoApellido = null!;
        private TableLayoutPanel campoGenero = null!;
        private TableLayoutPanel campoFecha = null!;

        private Label lblNombre = null!;
        private Label lblApellido = null!;
        private Label lblGenero = null!;
        private Label lblFecha = null!;

        private TextBox txtNombre = null!;
        private TextBox txtApellido = null!;
        private ComboBox cmbGenero = null!;
        private DateTimePicker dtpNacimiento = null!;

        private FlowLayoutPanel botones = null!;

        private Button btnNuevo = null!;
        private Button btnAgregar = null!;
        private Button btnActualizar = null!;
        private Button btnEliminar = null!;
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            raiz = new TableLayoutPanel();
            encabezado = new Panel();
            titulo = new Label();
            subtitulo = new Label();
            principal = new TableLayoutPanel();
            barra = new TableLayoutPanel();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnRecargar = new Button();
            dgvPacientes = new DataGridView();
            panelDatos = new Panel();
            editor = new TableLayoutPanel();
            lblSeleccion = new Label();
            campoNombre = new TableLayoutPanel();
            lblNombre = new Label();
            txtNombre = new TextBox();
            campoApellido = new TableLayoutPanel();
            lblApellido = new Label();
            txtApellido = new TextBox();
            campoGenero = new TableLayoutPanel();
            lblGenero = new Label();
            cmbGenero = new ComboBox();
            campoFecha = new TableLayoutPanel();
            lblFecha = new Label();
            dtpNacimiento = new DateTimePicker();
            botones = new FlowLayoutPanel();
            btnNuevo = new Button();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            lblEstado = new Label();
            raiz.SuspendLayout();
            encabezado.SuspendLayout();
            principal.SuspendLayout();
            barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).BeginInit();
            panelDatos.SuspendLayout();
            editor.SuspendLayout();
            campoNombre.SuspendLayout();
            campoApellido.SuspendLayout();
            campoGenero.SuspendLayout();
            campoFecha.SuspendLayout();
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
            titulo.Size = new Size(358, 41);
            titulo.TabIndex = 0;
            titulo.Text = "GESTIÓN DE PACIENTES";
            // 
            // subtitulo
            // 
            subtitulo.AutoSize = true;
            subtitulo.ForeColor = Color.LightCyan;
            subtitulo.Location = new Point(33, 60);
            subtitulo.Name = "subtitulo";
            subtitulo.Size = new Size(168, 19);
            subtitulo.TabIndex = 1;
            subtitulo.Text = "Administración | ClinicaDB";
            // 
            // principal
            // 
            principal.BackColor = Color.FromArgb(240, 247, 247);
            principal.ColumnCount = 1;
            principal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            principal.Controls.Add(barra, 0, 0);
            principal.Controls.Add(dgvPacientes, 0, 1);
            principal.Controls.Add(panelDatos, 0, 2);
            principal.Controls.Add(lblEstado, 0, 3);
            principal.Dock = DockStyle.Fill;
            principal.Location = new Point(3, 98);
            principal.Name = "principal";
            principal.Padding = new Padding(24, 15, 24, 15);
            principal.RowCount = 4;
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            principal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 255F));
            principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            principal.Size = new Size(1194, 749);
            principal.TabIndex = 1;
            // 
            // barra
            // 
            barra.ColumnCount = 3;
            barra.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            barra.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            barra.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            barra.Controls.Add(txtBuscar, 0, 0);
            barra.Controls.Add(btnBuscar, 1, 0);
            barra.Controls.Add(btnRecargar, 2, 0);
            barra.Dock = DockStyle.Fill;
            barra.Location = new Point(24, 15);
            barra.Margin = new Padding(0);
            barra.Name = "barra";
            barra.RowCount = 1;
            barra.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            barra.Size = new Size(1146, 62);
            barra.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Dock = DockStyle.Fill;
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.Location = new Point(0, 10);
            txtBuscar.Margin = new Padding(0, 10, 12, 10);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por nombre o apellido";
            txtBuscar.Size = new Size(864, 27);
            txtBuscar.TabIndex = 0;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(20, 125, 134);
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Dock = DockStyle.Fill;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(880, 4);
            btnBuscar.Margin = new Padding(4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(122, 54);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // btnRecargar
            // 
            btnRecargar.BackColor = Color.FromArgb(18, 63, 73);
            btnRecargar.Cursor = Cursors.Hand;
            btnRecargar.Dock = DockStyle.Fill;
            btnRecargar.FlatAppearance.BorderSize = 0;
            btnRecargar.FlatStyle = FlatStyle.Flat;
            btnRecargar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRecargar.ForeColor = Color.White;
            btnRecargar.Location = new Point(1010, 4);
            btnRecargar.Margin = new Padding(4);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(132, 54);
            btnRecargar.TabIndex = 2;
            btnRecargar.Text = "RECARGAR";
            btnRecargar.UseVisualStyleBackColor = false;
            // 
            // dgvPacientes
            // 
            dgvPacientes.AllowUserToAddRows = false;
            dgvPacientes.AllowUserToDeleteRows = false;
            dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPacientes.BackgroundColor = Color.White;
            dgvPacientes.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(18, 63, 73);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPacientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPacientes.ColumnHeadersHeight = 42;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(209, 237, 234);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(18, 63, 73);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPacientes.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPacientes.Dock = DockStyle.Fill;
            dgvPacientes.EnableHeadersVisualStyles = false;
            dgvPacientes.Location = new Point(24, 77);
            dgvPacientes.Margin = new Padding(0, 0, 0, 12);
            dgvPacientes.MultiSelect = false;
            dgvPacientes.Name = "dgvPacientes";
            dgvPacientes.ReadOnly = true;
            dgvPacientes.RowHeadersVisible = false;
            dgvPacientes.RowTemplate.Height = 35;
            dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPacientes.Size = new Size(1146, 358);
            dgvPacientes.TabIndex = 1;
            // 
            // panelDatos
            // 
            panelDatos.BackColor = Color.White;
            panelDatos.Controls.Add(editor);
            panelDatos.Dock = DockStyle.Fill;
            panelDatos.Location = new Point(27, 450);
            panelDatos.Name = "panelDatos";
            panelDatos.Padding = new Padding(20);
            panelDatos.Size = new Size(1140, 249);
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
            editor.Controls.Add(campoNombre, 0, 1);
            editor.Controls.Add(campoApellido, 1, 1);
            editor.Controls.Add(campoGenero, 2, 1);
            editor.Controls.Add(campoFecha, 3, 1);
            editor.Controls.Add(botones, 0, 2);
            editor.Dock = DockStyle.Fill;
            editor.Location = new Point(20, 20);
            editor.Name = "editor";
            editor.RowCount = 3;
            editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 85F));
            editor.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            editor.Size = new Size(1100, 209);
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
            lblSeleccion.Size = new Size(1094, 40);
            lblSeleccion.TabIndex = 0;
            lblSeleccion.Text = "Sin paciente seleccionado";
            // 
            // campoNombre
            // 
            campoNombre.ColumnCount = 1;
            campoNombre.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            campoNombre.Controls.Add(lblNombre, 0, 0);
            campoNombre.Controls.Add(txtNombre, 0, 1);
            campoNombre.Dock = DockStyle.Fill;
            campoNombre.Location = new Point(3, 43);
            campoNombre.Name = "campoNombre";
            campoNombre.Padding = new Padding(4, 0, 14, 0);
            campoNombre.RowCount = 2;
            campoNombre.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            campoNombre.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            campoNombre.Size = new Size(269, 79);
            campoNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.Dock = DockStyle.Fill;
            lblNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(18, 63, 73);
            lblNombre.Location = new Point(7, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(245, 30);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Top;
            txtNombre.Font = new Font("Segoe UI", 11F);
            txtNombre.Location = new Point(7, 33);
            txtNombre.MaxLength = 60;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(245, 27);
            txtNombre.TabIndex = 1;
            // 
            // campoApellido
            // 
            campoApellido.ColumnCount = 1;
            campoApellido.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            campoApellido.Controls.Add(lblApellido, 0, 0);
            campoApellido.Controls.Add(txtApellido, 0, 1);
            campoApellido.Dock = DockStyle.Fill;
            campoApellido.Location = new Point(278, 43);
            campoApellido.Name = "campoApellido";
            campoApellido.Padding = new Padding(4, 0, 14, 0);
            campoApellido.RowCount = 2;
            campoApellido.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            campoApellido.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            campoApellido.Size = new Size(269, 79);
            campoApellido.TabIndex = 2;
            // 
            // lblApellido
            // 
            lblApellido.Dock = DockStyle.Fill;
            lblApellido.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblApellido.ForeColor = Color.FromArgb(18, 63, 73);
            lblApellido.Location = new Point(7, 0);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(245, 30);
            lblApellido.TabIndex = 0;
            lblApellido.Text = "Apellido";
            // 
            // txtApellido
            // 
            txtApellido.Dock = DockStyle.Top;
            txtApellido.Font = new Font("Segoe UI", 11F);
            txtApellido.Location = new Point(7, 33);
            txtApellido.MaxLength = 60;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(245, 27);
            txtApellido.TabIndex = 1;
            // 
            // campoGenero
            // 
            campoGenero.ColumnCount = 1;
            campoGenero.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            campoGenero.Controls.Add(lblGenero, 0, 0);
            campoGenero.Controls.Add(cmbGenero, 0, 1);
            campoGenero.Dock = DockStyle.Fill;
            campoGenero.Location = new Point(553, 43);
            campoGenero.Name = "campoGenero";
            campoGenero.Padding = new Padding(4, 0, 14, 0);
            campoGenero.RowCount = 2;
            campoGenero.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            campoGenero.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            campoGenero.Size = new Size(269, 79);
            campoGenero.TabIndex = 3;
            // 
            // lblGenero
            // 
            lblGenero.Dock = DockStyle.Fill;
            lblGenero.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGenero.ForeColor = Color.FromArgb(18, 63, 73);
            lblGenero.Location = new Point(7, 0);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(245, 30);
            lblGenero.TabIndex = 0;
            lblGenero.Text = "Género";
            // 
            // cmbGenero
            // 
            cmbGenero.Dock = DockStyle.Top;
            cmbGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenero.Font = new Font("Segoe UI", 11F);
            cmbGenero.Items.AddRange(new object[] { "Masculino", "Femenino" });
            cmbGenero.Location = new Point(7, 33);
            cmbGenero.Name = "cmbGenero";
            cmbGenero.Size = new Size(245, 28);
            cmbGenero.TabIndex = 1;
            // 
            // campoFecha
            // 
            campoFecha.ColumnCount = 1;
            campoFecha.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            campoFecha.Controls.Add(lblFecha, 0, 0);
            campoFecha.Controls.Add(dtpNacimiento, 0, 1);
            campoFecha.Dock = DockStyle.Fill;
            campoFecha.Location = new Point(828, 43);
            campoFecha.Name = "campoFecha";
            campoFecha.Padding = new Padding(4, 0, 14, 0);
            campoFecha.RowCount = 2;
            campoFecha.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            campoFecha.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            campoFecha.Size = new Size(269, 79);
            campoFecha.TabIndex = 4;
            // 
            // lblFecha
            // 
            lblFecha.Dock = DockStyle.Fill;
            lblFecha.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFecha.ForeColor = Color.FromArgb(18, 63, 73);
            lblFecha.Location = new Point(7, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(245, 30);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha de nacimiento";
            // 
            // dtpNacimiento
            // 
            dtpNacimiento.CustomFormat = "dd/MM/yyyy";
            dtpNacimiento.Dock = DockStyle.Top;
            dtpNacimiento.Font = new Font("Segoe UI", 11F);
            dtpNacimiento.Format = DateTimePickerFormat.Custom;
            dtpNacimiento.Location = new Point(7, 33);
            dtpNacimiento.MaxDate = new DateTime(2008, 11, 10, 0, 0, 0, 0);
            dtpNacimiento.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpNacimiento.Name = "dtpNacimiento";
            dtpNacimiento.Size = new Size(245, 27);
            dtpNacimiento.TabIndex = 1;
            dtpNacimiento.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // botones
            // 
            editor.SetColumnSpan(botones, 4);
            botones.Controls.Add(btnNuevo);
            botones.Controls.Add(btnAgregar);
            botones.Controls.Add(btnActualizar);
            botones.Controls.Add(btnEliminar);
            botones.Controls.Add(btnCerrar);
            botones.Dock = DockStyle.Fill;
            botones.Location = new Point(3, 128);
            botones.Name = "botones";
            botones.Size = new Size(1094, 78);
            botones.TabIndex = 5;
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
            btnNuevo.Size = new Size(160, 43);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "LIMPIAR / NUEVO";
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
            btnAgregar.Size = new Size(145, 43);
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
            btnActualizar.Location = new Point(325, 4);
            btnActualizar.Margin = new Padding(4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(145, 43);
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
            btnEliminar.Location = new Point(478, 4);
            btnEliminar.Margin = new Padding(4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(135, 43);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(18, 63, 73);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(621, 4);
            btnCerrar.Margin = new Padding(4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(120, 43);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "CERRAR";
            btnCerrar.UseVisualStyleBackColor = false;
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
            // 
            // frmGestionPacientes
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 247, 247);
            ClientSize = new Size(1200, 850);
            Controls.Add(raiz);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1050, 720);
            Name = "frmGestionPacientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clínica Salud y Bienestar | Gestión de pacientes";
            WindowState = FormWindowState.Maximized;
            raiz.ResumeLayout(false);
            encabezado.ResumeLayout(false);
            encabezado.PerformLayout();
            principal.ResumeLayout(false);
            barra.ResumeLayout(false);
            barra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).EndInit();
            panelDatos.ResumeLayout(false);
            editor.ResumeLayout(false);
            campoNombre.ResumeLayout(false);
            campoNombre.PerformLayout();
            campoApellido.ResumeLayout(false);
            campoApellido.PerformLayout();
            campoGenero.ResumeLayout(false);
            campoFecha.ResumeLayout(false);
            botones.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
