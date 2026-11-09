
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

        public bool RegistroRealizado { get; private set; }

        public frmRegistroPaciente()
        {
            Text = "Clínica Salud y Bienestar | Registrar paciente";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(850, 760);
            MinimumSize = new Size(850, 760);
            BackColor = fondo;
            Font = new Font("Segoe UI", 10F);
            AutoScroll = true;

            CrearInterfaz();
        }

        private void CrearInterfaz()
        {
            Panel encabezado = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = oscuro
            };

            Controls.Add(encabezado);

            Label titulo = new Label
            {
                Text = "REGISTRAR PACIENTE",
                Font = new Font(
                    "Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(30, 15),
                AutoSize = true
            };

            encabezado.Controls.Add(titulo);

            Label subtitulo = new Label
            {
                Text = "Datos personales + primera consulta",
                ForeColor = Color.LightCyan,
                Location = new Point(33, 65),
                AutoSize = true
            };

            encabezado.Controls.Add(subtitulo);

            Panel cuerpo = new Panel
            {
                Location = new Point(20, 115),
                Size = new Size(795, 615),
                BackColor = Color.White
            };

            Controls.Add(cuerpo);

            Label lblDatos = Etiqueta(
                "DATOS PERSONALES", 20, 20, 15, true);

            cuerpo.Controls.Add(lblDatos);

            cuerpo.Controls.Add(
                Etiqueta("Nombre", 23, 75));

            txtNombre = Caja(23, 103, 350);
            txtNombre.MaxLength = 60;
            cuerpo.Controls.Add(txtNombre);

            cuerpo.Controls.Add(
                Etiqueta("Apellido", 410, 75));

            txtApellido = Caja(410, 103, 350);
            txtApellido.MaxLength = 60;
            cuerpo.Controls.Add(txtApellido);

            cuerpo.Controls.Add(
                Etiqueta("Género", 23, 160));

            cmbGenero = new ComboBox
            {
                Location = new Point(23, 189),
                Width = 350,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 11F)
            };

            cmbGenero.Items.AddRange(
                new object[] { "Masculino", "Femenino" });

            cmbGenero.SelectedIndex = -1;
            cuerpo.Controls.Add(cmbGenero);

            cuerpo.Controls.Add(
                Etiqueta("Fecha de nacimiento", 410, 160));

            dtpNacimiento = Fecha(410, 189, 350);
            dtpNacimiento.MinDate = new DateTime(1900, 1, 1);
            dtpNacimiento.MaxDate =
                fechaCorte.AddYears(-18);
            dtpNacimiento.Value =
                new DateTime(2000, 1, 1);

            cuerpo.Controls.Add(dtpNacimiento);

            cuerpo.Controls.Add(
                Etiqueta("PRIMERA CONSULTA", 20, 245, 15, true));

            cuerpo.Controls.Add(
                Etiqueta("Fecha de consulta", 23, 295));

            dtpConsulta = Fecha(23, 325, 220);
            dtpConsulta.MinDate = new DateTime(1900, 1, 1);
            dtpConsulta.MaxDate = fechaCorte;
            dtpConsulta.Value = fechaCorte;
            cuerpo.Controls.Add(dtpConsulta);

            cuerpo.Controls.Add(
                Etiqueta("Peso (kg)", 280, 295));

            nudPeso = Numero(280, 325, 200);
            nudPeso.Minimum = 1m;
            nudPeso.Maximum = 500m;
            nudPeso.Value = 75m;
            nudPeso.Increment = 0.10m;
            cuerpo.Controls.Add(nudPeso);

            cuerpo.Controls.Add(
                Etiqueta("Estatura (m)", 515, 295));

            nudEstatura = Numero(515, 325, 245);
            nudEstatura.Minimum = 0.50m;
            nudEstatura.Maximum = 2.50m;
            nudEstatura.Value = 1.75m;
            nudEstatura.Increment = 0.01m;
            cuerpo.Controls.Add(nudEstatura);

            cuerpo.Controls.Add(
                Etiqueta("IMC CALCULADO", 23, 390));

            lblIMC = new Label
            {
                Text = "24.5",
                Font = new Font(
                    "Segoe UI", 24F, FontStyle.Bold),
                ForeColor = turquesa,
                Location = new Point(25, 419),
                Size = new Size(145, 50)
            };

            cuerpo.Controls.Add(lblIMC);

            lblCategoria = new Label
            {
                Text = "Categoría: se consultará en Azure SQL",
                ForeColor = oscuro,
                Location = new Point(200, 432),
                Size = new Size(550, 35),
                Font = new Font("Segoe UI", 10F)
            };

            cuerpo.Controls.Add(lblCategoria);

            nudPeso.ValueChanged +=
                (s, e) => ActualizarIMC();

            nudEstatura.ValueChanged +=
                (s, e) => ActualizarIMC();

            btnGuardar = Boton(
                "GUARDAR PACIENTE", 23, 520, 255, turquesa);

            btnGuardar.Click += Guardar_Click;
            cuerpo.Controls.Add(btnGuardar);

            Button btnLimpiar = Boton(
                "LIMPIAR", 300, 520, 190, oscuro);

            btnLimpiar.Click += (s, e) => Limpiar();
            cuerpo.Controls.Add(btnLimpiar);

            Button btnCerrar = Boton(
                "CERRAR", 515, 520, 245, oscuro);

            btnCerrar.Click += (s, e) => Close();
            cuerpo.Controls.Add(btnCerrar);

            ActualizarIMC();
        }

        private Label Etiqueta(
            string texto,
            int x,
            int y,
            int tamano = 10,
            bool negrita = false)
        {
            return new Label
            {
                Text = texto,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font(
                    "Segoe UI",
                    tamano,
                    negrita
                        ? FontStyle.Bold
                        : FontStyle.Regular),
                ForeColor = oscuro
            };
        }

        private TextBox Caja(int x, int y, int ancho)
        {
            return new TextBox
            {
                Location = new Point(x, y),
                Width = ancho,
                Font = new Font("Segoe UI", 11F)
            };
        }

        private DateTimePicker Fecha(
            int x, int y, int ancho)
        {
            return new DateTimePicker
            {
                Location = new Point(x, y),
                Width = ancho,
                Font = new Font("Segoe UI", 11F),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy"
            };
        }

        private NumericUpDown Numero(
            int x, int y, int ancho)
        {
            return new NumericUpDown
            {
                Location = new Point(x, y),
                Width = ancho,
                Font = new Font("Segoe UI", 11F),
                DecimalPlaces = 2
            };
        }

        private Button Boton(
            string texto,
            int x,
            int y,
            int ancho,
            Color color)
        {
            Button boton = new Button
            {
                Text = texto,
                Location = new Point(x, y),
                Size = new Size(ancho, 45),
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font(
                    "Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            boton.FlatAppearance.BorderSize = 0;
            return boton;
        }

        private decimal ObtenerIMC()
        {
            return ConsultaDatos.CalcularIMC(
                nudPeso.Value, nudEstatura.Value);
        }

        private void ActualizarIMC()
        {
            lblIMC.Text = ObtenerIMC().ToString("F1");
            lblCategoria.Text =
                "Categoría: se asignará desde Azure SQL";
        }

        private void ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
                throw new ArgumentException(
                    "Escribe el nombre del paciente.");

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
                throw new ArgumentException(
                    "Escribe el apellido del paciente.");

            if (cmbGenero.SelectedIndex == -1)
                throw new ArgumentException(
                    "Selecciona el género.");

            if (dtpNacimiento.Value.Date >
                fechaCorte.AddYears(-18))
                throw new ArgumentException(
                    "El paciente debe ser mayor de edad.");

            if (dtpConsulta.Value.Date <
                dtpNacimiento.Value.Date)
                throw new ArgumentException(
                    "La consulta no puede ser anterior " +
                    "al nacimiento.");

            if (ObtenerIMC() > 999.9m)
                throw new ArgumentException(
                    "El IMC excede el rango permitido.");
        }

        private void Guardar_Click(
            object? sender, EventArgs e)
        {
            try
            {
                ValidarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Guardar paciente y primera consulta " +
                "en ClinicaDB_Pruebas?",
                "Confirmar registro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            btnGuardar.Enabled = false;

            try
            {
                decimal imc = ObtenerIMC();
                int pacienteId;
                int consultaId;
                string nombreCategoria;

                // Nunca utilizar ConexionBD para escribir.
                using (SqlConnection conexion =
                    ConexionPruebas.CrearConexion())
                {
                    conexion.Open();
                    ConexionPruebas.VerificarBase(conexion);

                    using (SqlTransaction transaccion =
                        conexion.BeginTransaction())
                    {
                        string sqlPaciente = @"
                            INSERT INTO dbo.Paciente
                                (Nombre, Apellido, Genero,
                                 FechaNacimiento)
                            OUTPUT INSERTED.PacienteId
                            VALUES
                                (@Nombre, @Apellido, @Genero,
                                 @Nacimiento);";

                        using (SqlCommand comando =
                            new SqlCommand(
                                sqlPaciente, conexion, transaccion))
                        {
                            comando.Parameters.Add(
                                "@Nombre", SqlDbType.NVarChar, 60
                            ).Value = txtNombre.Text.Trim();

                            comando.Parameters.Add(
                                "@Apellido", SqlDbType.NVarChar, 60
                            ).Value = txtApellido.Text.Trim();

                            comando.Parameters.Add(
                                "@Genero", SqlDbType.Char, 1
                            ).Value =
                                cmbGenero.SelectedIndex == 0
                                    ? "M" : "F";

                            comando.Parameters.Add(
                                "@Nacimiento", SqlDbType.Date
                            ).Value = dtpNacimiento.Value.Date;

                            pacienteId = Convert.ToInt32(
                                comando.ExecuteScalar());
                        }

                        string sqlCategoria = @"
                            SELECT TOP (1)
                                CategoriaId, Nombre
                            FROM dbo.Categoria
                            WHERE LimiteInferior IS NULL
                               OR LimiteInferior <= @IMC
                            ORDER BY
                                CASE
                                    WHEN LimiteInferior IS NULL
                                    THEN 1 ELSE 0
                                END,
                                LimiteInferior DESC;";

                        int categoriaId;

                        using (SqlCommand comando =
                            new SqlCommand(
                                sqlCategoria, conexion, transaccion))
                        {
                            SqlParameter parametro =
                                comando.Parameters.Add(
                                    "@IMC", SqlDbType.Decimal);

                            parametro.Precision = 5;
                            parametro.Scale = 1;
                            parametro.Value = imc;

                            using (SqlDataReader lector =
                                comando.ExecuteReader())
                            {
                                if (!lector.Read())
                                    throw new InvalidOperationException(
                                        "No se encontró la categoría del IMC.");

                                categoriaId = lector.GetInt32(0);
                                nombreCategoria = lector.GetString(1);
                            }
                        }

                        string sqlConsulta = @"
                            INSERT INTO dbo.Consulta
                                (PacienteId, Fecha, Peso,
                                 Estatura, IMC, CategoriaId)
                            OUTPUT INSERTED.ConsultaId
                            VALUES
                                (@PacienteId, @Fecha, @Peso,
                                 @Estatura, @IMC, @CategoriaId);";

                        using (SqlCommand comando =
                            new SqlCommand(
                                sqlConsulta, conexion, transaccion))
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

                            consultaId = Convert.ToInt32(
                                comando.ExecuteScalar());
                        }

                        transaccion.Commit();
                    }
                }

                RegistroRealizado = true;
                lblCategoria.Text =
                    "Categoría: " + nombreCategoria;

                MessageBox.Show(
                    "Registro exitoso en ClinicaDB_Pruebas.\n\n" +
                    "Paciente ID: " + pacienteId + "\n" +
                    "Consulta ID: " + consultaId + "\n" +
                    "IMC: " + imc.ToString("F1") + "\n" +
                    "Categoría: " + nombreCategoria,
                    "Registro completado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo completar el registro.\n" +
                    "No se guardará un paciente sin su consulta.\n\n" +
                    ex.Message,
                    "Error de registro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            cmbGenero.SelectedIndex = -1;
            dtpNacimiento.Value = new DateTime(2000, 1, 1);
            dtpConsulta.Value = fechaCorte;
            nudPeso.Value = 75m;
            nudEstatura.Value = 1.75m;
            ActualizarIMC();
            txtNombre.Focus();
        }
    }
}
