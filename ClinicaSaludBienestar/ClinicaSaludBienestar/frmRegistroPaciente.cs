
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public class frmRegistroPaciente : Form
    {
        private readonly Color oscuro =
            Color.FromArgb(18, 63, 73);

        private readonly Color turquesa =
            Color.FromArgb(20, 125, 134);

        private readonly Color fondo =
            Color.FromArgb(240, 247, 247);

        private readonly Color gris =
            Color.FromArgb(105, 127, 132);

        private readonly DateTime fechaCorte =
            new DateTime(2026, 11, 10);

        private TextBox txtNombre = null!;
        private TextBox txtApellido = null!;
        private ComboBox cmbGenero = null!;
        private DateTimePicker dtpNacimiento = null!;
        private DateTimePicker dtpConsulta = null!;
        private NumericUpDown nudPeso = null!;
        private NumericUpDown nudEstatura = null!;
        private Label lblIMC = null!;
        private Label lblCategoria = null!;
        private Button btnGuardar = null!;

        public frmRegistroPaciente()
        {
            Text = "Clínica Salud y Bienestar | Nuevo paciente";
            ClientSize = new Size(850, 760);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = fondo;
            Font = new Font("Segoe UI", 10F);

            CrearInterfaz();
        }

        // Crear formulario
        private void CrearInterfaz()
        {
            Panel encabezado = new Panel();
            encabezado.Dock = DockStyle.Top;
            encabezado.Height = 105;
            encabezado.BackColor = oscuro;
            Controls.Add(encabezado);

            Label titulo = new Label();
            titulo.Text = "REGISTRAR PACIENTE";
            titulo.Font = new Font(
                "Segoe UI", 22F, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.Location = new Point(35, 17);
            titulo.AutoSize = true;
            encabezado.Controls.Add(titulo);

            Label subtitulo = new Label();
            subtitulo.Text =
                "Información personal y primera consulta";
            subtitulo.ForeColor = Color.LightCyan;
            subtitulo.Location = new Point(38, 70);
            subtitulo.AutoSize = true;
            encabezado.Controls.Add(subtitulo);

            // Datos personales
            Panel panelPaciente = CrearPanel(125, 290);

            CrearTitulo(
                panelPaciente, "DATOS PERSONALES", 20, 15);

            CrearEtiqueta(panelPaciente, "Nombre", 25, 65);

            txtNombre = CrearTexto(25, 92, 350);
            txtNombre.MaxLength = 60;
            panelPaciente.Controls.Add(txtNombre);

            CrearEtiqueta(panelPaciente, "Apellido", 425, 65);

            txtApellido = CrearTexto(425, 92, 350);
            txtApellido.MaxLength = 60;
            panelPaciente.Controls.Add(txtApellido);

            CrearEtiqueta(panelPaciente, "Género", 25, 165);

            cmbGenero = new ComboBox();
            cmbGenero.Location = new Point(25, 192);
            cmbGenero.Size = new Size(350, 34);
            cmbGenero.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbGenero.Font = new Font("Segoe UI", 11F);

            cmbGenero.Items.Add("Masculino");
            cmbGenero.Items.Add("Femenino");
            cmbGenero.SelectedIndex = -1;

            panelPaciente.Controls.Add(cmbGenero);

            CrearEtiqueta(
                panelPaciente, "Fecha de nacimiento", 425, 165);

            dtpNacimiento = CrearFecha(425, 192, 350);
            dtpNacimiento.MinDate = new DateTime(1900, 1, 1);
            dtpNacimiento.MaxDate =
                fechaCorte.AddYears(-18);
            dtpNacimiento.Value = new DateTime(2000, 1, 1);
            panelPaciente.Controls.Add(dtpNacimiento);

            // Primera consulta
            Panel panelConsulta = CrearPanel(430, 220);

            CrearTitulo(
                panelConsulta, "PRIMERA CONSULTA", 20, 15);

            CrearEtiqueta(panelConsulta, "Fecha", 25, 65);

            dtpConsulta = CrearFecha(25, 92, 220);
            dtpConsulta.MinDate = new DateTime(1900, 1, 1);
            dtpConsulta.MaxDate = fechaCorte;
            dtpConsulta.Value = fechaCorte;
            panelConsulta.Controls.Add(dtpConsulta);

            CrearEtiqueta(panelConsulta, "Peso (kg)", 275, 65);

            nudPeso = CrearNumero(275, 92, 220);
            nudPeso.DecimalPlaces = 2;
            nudPeso.Minimum = 1m;
            nudPeso.Maximum = 500m;
            nudPeso.Increment = 0.10m;
            nudPeso.Value = 75m;
            panelConsulta.Controls.Add(nudPeso);

            CrearEtiqueta(panelConsulta, "Estatura (m)", 525, 65);

            nudEstatura = CrearNumero(525, 92, 250);
            nudEstatura.DecimalPlaces = 2;
            nudEstatura.Minimum = 0.50m;
            nudEstatura.Maximum = 2.50m;
            nudEstatura.Increment = 0.01m;
            nudEstatura.Value = 1.75m;
            panelConsulta.Controls.Add(nudEstatura);

            Label lblTituloIMC = new Label();
            lblTituloIMC.Text = "IMC CALCULADO";
            lblTituloIMC.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            lblTituloIMC.ForeColor = gris;
            lblTituloIMC.Location = new Point(25, 155);
            lblTituloIMC.AutoSize = true;
            panelConsulta.Controls.Add(lblTituloIMC);

            lblIMC = new Label();
            lblIMC.Text = "—";
            lblIMC.Font = new Font(
                "Segoe UI", 23F, FontStyle.Bold);
            lblIMC.ForeColor = turquesa;
            lblIMC.Location = new Point(185, 143);
            lblIMC.Size = new Size(130, 48);
            panelConsulta.Controls.Add(lblIMC);

            lblCategoria = new Label();
            lblCategoria.Text =
                "La categoría se asignará desde Azure SQL";
            lblCategoria.ForeColor = gris;
            lblCategoria.Location = new Point(340, 164);
            lblCategoria.Size = new Size(430, 32);
            panelConsulta.Controls.Add(lblCategoria);

            nudPeso.ValueChanged += (s, e) => CalcularIMC();
            nudEstatura.ValueChanged += (s, e) => CalcularIMC();

            // Botones
            btnGuardar = CrearBoton(
                "GUARDAR PACIENTE",
                35, 675, 275, turquesa);

            btnGuardar.Click += btnGuardar_Click;
            Controls.Add(btnGuardar);

            Button btnLimpiar = CrearBoton(
                "LIMPIAR",
                330, 675, 180, oscuro);

            btnLimpiar.Click += (s, e) => Limpiar();
            Controls.Add(btnLimpiar);

            Button btnCerrar = CrearBoton(
                "CERRAR",
                530, 675, 180, oscuro);

            btnCerrar.Click += (s, e) => Close();
            Controls.Add(btnCerrar);

            CalcularIMC();
        }

        // Crear panel
        private Panel CrearPanel(int y, int alto)
        {
            Panel panel = new Panel();
            panel.Location = new Point(25, y);
            panel.Size = new Size(800, alto);
            panel.BackColor = Color.White;
            Controls.Add(panel);
            return panel;
        }

        // Crear título de sección
        private void CrearTitulo(
            Control padre, string texto, int x, int y)
        {
            Label etiqueta = new Label();
            etiqueta.Text = texto;
            etiqueta.Font = new Font(
                "Segoe UI", 13F, FontStyle.Bold);
            etiqueta.ForeColor = oscuro;
            etiqueta.Location = new Point(x, y);
            etiqueta.AutoSize = true;
            padre.Controls.Add(etiqueta);
        }

        // Crear etiquetas
        private void CrearEtiqueta(
            Control padre, string texto, int x, int y)
        {
            Label etiqueta = new Label();
            etiqueta.Text = texto;
            etiqueta.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            etiqueta.ForeColor = oscuro;
            etiqueta.Location = new Point(x, y);
            etiqueta.AutoSize = true;
            padre.Controls.Add(etiqueta);
        }

        // Crear caja de texto
        private TextBox CrearTexto(int x, int y, int ancho)
        {
            TextBox caja = new TextBox();
            caja.Location = new Point(x, y);
            caja.Size = new Size(ancho, 35);
            caja.Font = new Font("Segoe UI", 11F);
            return caja;
        }

        // Crear selector de fecha
        private DateTimePicker CrearFecha(
            int x, int y, int ancho)
        {
            DateTimePicker fecha = new DateTimePicker();
            fecha.Location = new Point(x, y);
            fecha.Size = new Size(ancho, 35);
            fecha.Font = new Font("Segoe UI", 11F);
            fecha.Format = DateTimePickerFormat.Custom;
            fecha.CustomFormat = "dd/MM/yyyy";
            return fecha;
        }

        // Crear control numérico
        private NumericUpDown CrearNumero(
            int x, int y, int ancho)
        {
            NumericUpDown numero = new NumericUpDown();
            numero.Location = new Point(x, y);
            numero.Size = new Size(ancho, 35);
            numero.Font = new Font("Segoe UI", 11F);
            numero.ThousandsSeparator = false;
            return numero;
        }

        // Crear botón
        private Button CrearBoton(
            string texto, int x, int y,
            int ancho, Color color)
        {
            Button boton = new Button();
            boton.Text = texto;
            boton.Location = new Point(x, y);
            boton.Size = new Size(ancho, 45);
            boton.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            boton.BackColor = color;
            boton.ForeColor = Color.White;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Cursor = Cursors.Hand;
            return boton;
        }

        // Calcular IMC
        private decimal ObtenerIMC()
        {
            decimal peso = nudPeso.Value;
            decimal estatura = nudEstatura.Value;

            decimal imc =
                peso / (estatura * estatura);

            return Math.Round(
                imc, 1, MidpointRounding.AwayFromZero);
        }

        private void CalcularIMC()
        {
            decimal imc = ObtenerIMC();
            lblIMC.Text = imc.ToString("F1");
        }

        // Validar los datos
        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarAviso("Escribe el nombre del paciente.");
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MostrarAviso("Escribe el apellido del paciente.");
                txtApellido.Focus();
                return false;
            }

            if (cmbGenero.SelectedIndex == -1)
            {
                MostrarAviso("Selecciona el género.");
                cmbGenero.Focus();
                return false;
            }

            if (dtpNacimiento.Value.Date > fechaCorte.AddYears(-18))
            {
                MostrarAviso(
                    "El paciente debe tener al menos 18 años.");
                return false;
            }

            if (dtpConsulta.Value.Date <
                dtpNacimiento.Value.Date)
            {
                MostrarAviso(
                    "La consulta no puede ser anterior al nacimiento.");
                return false;
            }

            if (nudPeso.Value <= 0 ||
                nudEstatura.Value <= 0)
            {
                MostrarAviso(
                    "El peso y la estatura deben ser positivos.");
                return false;
            }

            return true;
        }

        private void MostrarAviso(string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "Validación de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        // Buscar categoría en la base de datos
        private int ObtenerCategoria(
            SqlConnection conexion,
            SqlTransaction transaccion,
            decimal imc)
        {
            string sql = @"
                SELECT TOP (1) CategoriaId
                FROM dbo.Categoria
                WHERE LimiteInferior IS NULL
                   OR LimiteInferior <= @IMC
                ORDER BY
                    CASE WHEN LimiteInferior IS NULL
                         THEN 1 ELSE 0 END,
                    LimiteInferior DESC;";

            using (SqlCommand comando =
                new SqlCommand(sql, conexion, transaccion))
            {
                SqlParameter parametro =
                    comando.Parameters.Add(
                        "@IMC", SqlDbType.Decimal);

                parametro.Precision = 5;
                parametro.Scale = 1;
                parametro.Value = imc;

                object? resultado = comando.ExecuteScalar();

                if (resultado == null ||
                    resultado == DBNull.Value)
                {
                    throw new InvalidOperationException(
                        "No se encontró una categoría para el IMC.");
                }

                return Convert.ToInt32(resultado);
            }
        }

        // Guardar paciente y primera consulta
        private void btnGuardar_Click(
            object? sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            DialogResult respuesta = MessageBox.Show(
                "¿Deseas registrar este paciente y su primera consulta?",
                "Confirmar registro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            btnGuardar.Enabled = false;

            try
            {
                decimal imc = ObtenerIMC();

                using (SqlConnection conexion =
                    ConexionBD.CrearConexion())
                {
                    conexion.Open();

                    using (SqlTransaction transaccion =
                        conexion.BeginTransaction())
                    {
                        // Insertar paciente
                        string sqlPaciente = @"
                            INSERT INTO dbo.Paciente
                                (Nombre, Apellido, Genero,
                                 FechaNacimiento)
                            OUTPUT INSERTED.PacienteId
                            VALUES
                                (@Nombre, @Apellido, @Genero,
                                 @FechaNacimiento);";

                        int pacienteId;

                        using (SqlCommand comando =
                            new SqlCommand(
                                sqlPaciente,
                                conexion,
                                transaccion))
                        {
                            comando.Parameters.Add(
                                "@Nombre", SqlDbType.NVarChar, 60
                            ).Value = txtNombre.Text.Trim();

                            comando.Parameters.Add(
                                "@Apellido", SqlDbType.NVarChar, 60
                            ).Value = txtApellido.Text.Trim();

                            comando.Parameters.Add(
                                "@Genero", SqlDbType.Char, 1
                            ).Value = cmbGenero.SelectedIndex == 0
                                ? "M" : "F";

                            comando.Parameters.Add(
                                "@FechaNacimiento", SqlDbType.Date
                            ).Value = dtpNacimiento.Value.Date;

                            pacienteId = Convert.ToInt32(
                                comando.ExecuteScalar());
                        }

                        // Categoría según los rangos de SQL
                        int categoriaId = ObtenerCategoria(
                            conexion, transaccion, imc);

                        // Insertar primera consulta
                        string sqlConsulta = @"
                            INSERT INTO dbo.Consulta
                                (PacienteId, Fecha, Peso,
                                 Estatura, IMC, CategoriaId)
                            VALUES
                                (@PacienteId, @Fecha, @Peso,
                                 @Estatura, @IMC, @CategoriaId);";

                        using (SqlCommand comando =
                            new SqlCommand(
                                sqlConsulta,
                                conexion,
                                transaccion))
                        {
                            comando.Parameters.Add(
                                "@PacienteId", SqlDbType.Int
                            ).Value = pacienteId;

                            comando.Parameters.Add(
                                "@Fecha", SqlDbType.Date
                            ).Value = dtpConsulta.Value.Date;

                            SqlParameter peso =
                                comando.Parameters.Add(
                                    "@Peso", SqlDbType.Decimal);
                            peso.Precision = 6;
                            peso.Scale = 2;
                            peso.Value = nudPeso.Value;

                            SqlParameter estatura =
                                comando.Parameters.Add(
                                    "@Estatura", SqlDbType.Decimal);
                            estatura.Precision = 4;
                            estatura.Scale = 2;
                            estatura.Value = nudEstatura.Value;

                            SqlParameter valorIMC =
                                comando.Parameters.Add(
                                    "@IMC", SqlDbType.Decimal);
                            valorIMC.Precision = 5;
                            valorIMC.Scale = 1;
                            valorIMC.Value = imc;

                            comando.Parameters.Add(
                                "@CategoriaId", SqlDbType.Int
                            ).Value = categoriaId;

                            comando.ExecuteNonQuery();
                        }

                        transaccion.Commit();

                        MessageBox.Show(
                            "Paciente registrado correctamente.\n" +
                            "ID asignado: " + pacienteId +
                            "\nIMC: " + imc.ToString("F1"),
                            "Registro exitoso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        Limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo guardar el registro.\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }

        // Limpiar campos
        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            cmbGenero.SelectedIndex = -1;
            dtpNacimiento.Value = new DateTime(2000, 1, 1);
            dtpConsulta.Value = fechaCorte;
            nudPeso.Value = 75m;
            nudEstatura.Value = 1.75m;
            lblCategoria.Text =
                "La categoría se asignará desde Azure SQL";

            CalcularIMC();
            txtNombre.Focus();
        }
    }
}
