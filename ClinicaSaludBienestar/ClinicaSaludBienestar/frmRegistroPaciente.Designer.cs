
#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicaSaludBienestar
{
    partial class frmRegistroPaciente
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlEncabezado = null!;
        private Panel pnlCuerpo = null!;

        private Label lblTitulo = null!;
        private Label lblSubtitulo = null!;
        private Label lblDatos = null!;
        private Label lblNombre = null!;
        private Label lblApellido = null!;
        private Label lblGenero = null!;
        private Label lblNacimiento = null!;
        private Label lblPrimeraConsulta = null!;
        private Label lblFechaConsulta = null!;
        private Label lblPeso = null!;
        private Label lblEstatura = null!;
        private Label lblTituloIMC = null!;
        private Label lblIMC = null!;
        private Label lblCategoria = null!;

        private TextBox txtNombre = null!;
        private TextBox txtApellido = null!;
        private ComboBox cmbGenero = null!;

        private DateTimePicker dtpNacimiento = null!;
        private DateTimePicker dtpConsulta = null!;

        private NumericUpDown nudPeso = null!;
        private NumericUpDown nudEstatura = null!;

        private Button btnGuardar = null!;
        private Button btnLimpiar = null!;
        private Button btnCerrar = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        // ÚNICO INITIALIZECOMPONENT DEL FORMULARIO
        private void InitializeComponent()
        {
            pnlEncabezado = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            pnlCuerpo = new Panel();
            lblDatos = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblGenero = new Label();
            cmbGenero = new ComboBox();
            lblNacimiento = new Label();
            dtpNacimiento = new DateTimePicker();
            lblPrimeraConsulta = new Label();
            lblFechaConsulta = new Label();
            dtpConsulta = new DateTimePicker();
            lblPeso = new Label();
            nudPeso = new NumericUpDown();
            lblEstatura = new Label();
            nudEstatura = new NumericUpDown();
            lblTituloIMC = new Label();
            lblIMC = new Label();
            lblCategoria = new Label();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnCerrar = new Button();
            pnlEncabezado.SuspendLayout();
            pnlCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPeso).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEstatura).BeginInit();
            SuspendLayout();
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(18, 63, 73);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Controls.Add(lblSubtitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(981, 100);
            pnlEncabezado.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(30, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(329, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRAR PACIENTE";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.ForeColor = Color.LightCyan;
            lblSubtitulo.Location = new Point(33, 65);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(234, 19);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Datos personales + primera consulta";
            // 
            // pnlCuerpo
            // 
            pnlCuerpo.BackColor = Color.White;
            pnlCuerpo.Controls.Add(lblDatos);
            pnlCuerpo.Controls.Add(lblNombre);
            pnlCuerpo.Controls.Add(txtNombre);
            pnlCuerpo.Controls.Add(lblApellido);
            pnlCuerpo.Controls.Add(txtApellido);
            pnlCuerpo.Controls.Add(lblGenero);
            pnlCuerpo.Controls.Add(cmbGenero);
            pnlCuerpo.Controls.Add(lblNacimiento);
            pnlCuerpo.Controls.Add(dtpNacimiento);
            pnlCuerpo.Controls.Add(lblPrimeraConsulta);
            pnlCuerpo.Controls.Add(lblFechaConsulta);
            pnlCuerpo.Controls.Add(dtpConsulta);
            pnlCuerpo.Controls.Add(lblPeso);
            pnlCuerpo.Controls.Add(nudPeso);
            pnlCuerpo.Controls.Add(lblEstatura);
            pnlCuerpo.Controls.Add(nudEstatura);
            pnlCuerpo.Controls.Add(lblTituloIMC);
            pnlCuerpo.Controls.Add(lblIMC);
            pnlCuerpo.Controls.Add(lblCategoria);
            pnlCuerpo.Controls.Add(btnGuardar);
            pnlCuerpo.Controls.Add(btnLimpiar);
            pnlCuerpo.Controls.Add(btnCerrar);
            pnlCuerpo.Location = new Point(20, 115);
            pnlCuerpo.Name = "pnlCuerpo";
            pnlCuerpo.Size = new Size(795, 615);
            pnlCuerpo.TabIndex = 0;
            // 
            // lblDatos
            // 
            lblDatos.AutoSize = true;
            lblDatos.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblDatos.ForeColor = Color.FromArgb(18, 63, 73);
            lblDatos.Location = new Point(20, 20);
            lblDatos.Name = "lblDatos";
            lblDatos.Size = new Size(207, 28);
            lblDatos.TabIndex = 0;
            lblDatos.Text = "DATOS PERSONALES";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(23, 75);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(59, 19);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 11F);
            txtNombre.Location = new Point(23, 103);
            txtNombre.MaxLength = 60;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(350, 27);
            txtNombre.TabIndex = 2;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(410, 75);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(58, 19);
            lblApellido.TabIndex = 3;
            lblApellido.Text = "Apellido";
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 11F);
            txtApellido.Location = new Point(410, 103);
            txtApellido.MaxLength = 60;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(350, 27);
            txtApellido.TabIndex = 4;
            // 
            // lblGenero
            // 
            lblGenero.AutoSize = true;
            lblGenero.Location = new Point(23, 160);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(54, 19);
            lblGenero.TabIndex = 5;
            lblGenero.Text = "Género";
            // 
            // cmbGenero
            // 
            cmbGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenero.Font = new Font("Segoe UI", 11F);
            cmbGenero.Items.AddRange(new object[] { "Masculino", "Femenino" });
            cmbGenero.Location = new Point(23, 189);
            cmbGenero.Name = "cmbGenero";
            cmbGenero.Size = new Size(350, 28);
            cmbGenero.TabIndex = 6;
            // 
            // lblNacimiento
            // 
            lblNacimiento.AutoSize = true;
            lblNacimiento.Location = new Point(410, 160);
            lblNacimiento.Name = "lblNacimiento";
            lblNacimiento.Size = new Size(134, 19);
            lblNacimiento.TabIndex = 7;
            lblNacimiento.Text = "Fecha de nacimiento";
            // 
            // dtpNacimiento
            // 
            dtpNacimiento.CustomFormat = "dd/MM/yyyy";
            dtpNacimiento.Font = new Font("Segoe UI", 11F);
            dtpNacimiento.Format = DateTimePickerFormat.Custom;
            dtpNacimiento.Location = new Point(410, 189);
            dtpNacimiento.MaxDate = new DateTime(2008, 11, 10, 0, 0, 0, 0);
            dtpNacimiento.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpNacimiento.Name = "dtpNacimiento";
            dtpNacimiento.Size = new Size(350, 27);
            dtpNacimiento.TabIndex = 8;
            dtpNacimiento.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // lblPrimeraConsulta
            // 
            lblPrimeraConsulta.AutoSize = true;
            lblPrimeraConsulta.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblPrimeraConsulta.ForeColor = Color.FromArgb(18, 63, 73);
            lblPrimeraConsulta.Location = new Point(20, 245);
            lblPrimeraConsulta.Name = "lblPrimeraConsulta";
            lblPrimeraConsulta.Size = new Size(208, 28);
            lblPrimeraConsulta.TabIndex = 9;
            lblPrimeraConsulta.Text = "PRIMERA CONSULTA";
            // 
            // lblFechaConsulta
            // 
            lblFechaConsulta.AutoSize = true;
            lblFechaConsulta.Location = new Point(23, 295);
            lblFechaConsulta.Name = "lblFechaConsulta";
            lblFechaConsulta.Size = new Size(118, 19);
            lblFechaConsulta.TabIndex = 10;
            lblFechaConsulta.Text = "Fecha de consulta";
            // 
            // dtpConsulta
            // 
            dtpConsulta.CustomFormat = "dd/MM/yyyy";
            dtpConsulta.Font = new Font("Segoe UI", 11F);
            dtpConsulta.Format = DateTimePickerFormat.Custom;
            dtpConsulta.Location = new Point(23, 325);
            dtpConsulta.MaxDate = new DateTime(2026, 11, 10, 0, 0, 0, 0);
            dtpConsulta.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpConsulta.Name = "dtpConsulta";
            dtpConsulta.Size = new Size(220, 27);
            dtpConsulta.TabIndex = 11;
            dtpConsulta.Value = new DateTime(2026, 11, 10, 0, 0, 0, 0);
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Location = new Point(280, 295);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(64, 19);
            lblPeso.TabIndex = 12;
            lblPeso.Text = "Peso (kg)";
            // 
            // nudPeso
            // 
            nudPeso.DecimalPlaces = 2;
            nudPeso.Font = new Font("Segoe UI", 11F);
            nudPeso.Increment = new decimal(new int[] { 10, 0, 0, 131072 });
            nudPeso.Location = new Point(280, 325);
            nudPeso.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudPeso.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPeso.Name = "nudPeso";
            nudPeso.Size = new Size(200, 27);
            nudPeso.TabIndex = 13;
            nudPeso.Value = new decimal(new int[] { 75, 0, 0, 0 });
            // 
            // lblEstatura
            // 
            lblEstatura.AutoSize = true;
            lblEstatura.Location = new Point(515, 295);
            lblEstatura.Name = "lblEstatura";
            lblEstatura.Size = new Size(83, 19);
            lblEstatura.TabIndex = 14;
            lblEstatura.Text = "Estatura (m)";
            // 
            // nudEstatura
            // 
            nudEstatura.DecimalPlaces = 2;
            nudEstatura.Font = new Font("Segoe UI", 11F);
            nudEstatura.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudEstatura.Location = new Point(515, 325);
            nudEstatura.Maximum = new decimal(new int[] { 250, 0, 0, 131072 });
            nudEstatura.Minimum = new decimal(new int[] { 50, 0, 0, 131072 });
            nudEstatura.Name = "nudEstatura";
            nudEstatura.Size = new Size(245, 27);
            nudEstatura.TabIndex = 15;
            nudEstatura.Value = new decimal(new int[] { 175, 0, 0, 131072 });
            // 
            // lblTituloIMC
            // 
            lblTituloIMC.AutoSize = true;
            lblTituloIMC.Location = new Point(23, 390);
            lblTituloIMC.Name = "lblTituloIMC";
            lblTituloIMC.Size = new Size(120, 19);
            lblTituloIMC.TabIndex = 16;
            lblTituloIMC.Text = "IMC CALCULADO";
            // 
            // lblIMC
            // 
            lblIMC.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblIMC.ForeColor = Color.FromArgb(20, 125, 134);
            lblIMC.Location = new Point(25, 419);
            lblIMC.Name = "lblIMC";
            lblIMC.Size = new Size(145, 50);
            lblIMC.TabIndex = 17;
            lblIMC.Text = "24.5";
            // 
            // lblCategoria
            // 
            lblCategoria.Font = new Font("Segoe UI", 10F);
            lblCategoria.ForeColor = Color.FromArgb(18, 63, 73);
            lblCategoria.Location = new Point(200, 432);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(550, 35);
            lblCategoria.TabIndex = 18;
            lblCategoria.Text = "Categoría: se asignará desde Azure SQL";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(20, 125, 134);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(23, 520);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(255, 45);
            btnGuardar.TabIndex = 19;
            btnGuardar.Text = "GUARDAR PACIENTE";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(18, 63, 73);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(300, 520);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(190, 45);
            btnLimpiar.TabIndex = 20;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(18, 63, 73);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(515, 520);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(245, 45);
            btnCerrar.TabIndex = 21;
            btnCerrar.Text = "CERRAR";
            btnCerrar.UseVisualStyleBackColor = false;
            // 
            // frmRegistroPaciente
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(240, 247, 247);
            ClientSize = new Size(981, 760);
            Controls.Add(pnlCuerpo);
            Controls.Add(pnlEncabezado);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(850, 760);
            Name = "frmRegistroPaciente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Clínica Salud y Bienestar | Registrar paciente";
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            pnlCuerpo.ResumeLayout(false);
            pnlCuerpo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPeso).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEstatura).EndInit();
            ResumeLayout(false);
        }
    }
}
