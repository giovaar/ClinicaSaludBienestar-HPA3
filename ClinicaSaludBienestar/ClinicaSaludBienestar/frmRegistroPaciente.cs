
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public partial class frmRegistroPaciente : Form
    {
        private readonly DateTime fechaCorte =
            new DateTime(2026, 11, 10);

        public bool RegistroRealizado { get; private set; }

        public frmRegistroPaciente()
        {
            InitializeComponent();

            nudPeso.ValueChanged +=
                (s, e) => ActualizarIMC();

            nudEstatura.ValueChanged +=
                (s, e) => ActualizarIMC();

            btnGuardar.Click += Guardar_Click;
            btnLimpiar.Click += (s, e) => Limpiar();
            btnCerrar.Click += (s, e) => Close();

            ActualizarIMC();
        }

        // CALCULAR EL IMC
        private decimal ObtenerIMC()
        {
            return ConsultaDatos.CalcularIMC(
                nudPeso.Value,
                nudEstatura.Value);
        }

        // ACTUALIZAR RESULTADO
        private void ActualizarIMC()
        {
            lblIMC.Text = ObtenerIMC().ToString("F1");

            lblCategoria.Text =
                "Categoría: se asignará desde Azure SQL";
        }

        // VALIDAR DATOS DEL PACIENTE
        private void ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                throw new ArgumentException(
                    "Escribe el nombre del paciente.");
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                throw new ArgumentException(
                    "Escribe el apellido del paciente.");
            }

            if (cmbGenero.SelectedIndex == -1)
            {
                throw new ArgumentException(
                    "Selecciona el género.");
            }

            if (dtpNacimiento.Value.Date >
                fechaCorte.AddYears(-18))
            {
                throw new ArgumentException(
                    "El paciente debe ser mayor de edad.");
            }

            if (dtpConsulta.Value.Date <
                dtpNacimiento.Value.Date)
            {
                throw new ArgumentException(
                    "La consulta no puede ser anterior al nacimiento.");
            }

            if (ObtenerIMC() > 999.9m)
            {
                throw new ArgumentException(
                    "El IMC excede el rango permitido.");
            }
        }

        // GUARDAR PACIENTE Y PRIMERA CONSULTA
        private void Guardar_Click(object? sender, EventArgs e)
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
                "¿Guardar paciente y primera consulta en ClinicaDB?",
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

                using (SqlConnection conexion =
                    ConexionPruebas.CrearConexion())
                {
                    conexion.Open();

                    ConexionPruebas.VerificarBase(conexion);

                    using (SqlTransaction transaccion =
                        conexion.BeginTransaction())
                    {
                        // INSERTAR PACIENTE
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
                                sqlPaciente,
                                conexion,
                                transaccion))
                        {
                            comando.Parameters.Add(
                                "@Nombre",
                                SqlDbType.NVarChar,
                                60
                            ).Value = txtNombre.Text.Trim();

                            comando.Parameters.Add(
                                "@Apellido",
                                SqlDbType.NVarChar,
                                60
                            ).Value = txtApellido.Text.Trim();

                            comando.Parameters.Add(
                                "@Genero",
                                SqlDbType.Char,
                                1
                            ).Value =
                                cmbGenero.SelectedIndex == 0
                                    ? "M"
                                    : "F";

                            comando.Parameters.Add(
                                "@Nacimiento",
                                SqlDbType.Date
                            ).Value =
                                dtpNacimiento.Value.Date;

                            pacienteId = Convert.ToInt32(
                                comando.ExecuteScalar());
                        }

                        // OBTENER CATEGORÍA DESDE SQL
                        string sqlCategoria = @"
                            SELECT TOP (1)
                                CategoriaId,
                                Nombre
                            FROM dbo.Categoria
                            WHERE LimiteInferior IS NULL
                               OR LimiteInferior <= @IMC
                            ORDER BY
                                CASE
                                    WHEN LimiteInferior IS NULL
                                    THEN 1
                                    ELSE 0
                                END,
                                LimiteInferior DESC;";

                        int categoriaId;

                        using (SqlCommand comando =
                            new SqlCommand(
                                sqlCategoria,
                                conexion,
                                transaccion))
                        {
                            SqlParameter parametro =
                                comando.Parameters.Add(
                                    "@IMC",
                                    SqlDbType.Decimal);

                            parametro.Precision = 5;
                            parametro.Scale = 1;
                            parametro.Value = imc;

                            using (SqlDataReader lector =
                                comando.ExecuteReader())
                            {
                                if (!lector.Read())
                                {
                                    throw new InvalidOperationException(
                                        "No se encontró la categoría del IMC.");
                                }

                                categoriaId = lector.GetInt32(0);
                                nombreCategoria = lector.GetString(1);
                            }
                        }

                        // INSERTAR PRIMERA CONSULTA
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
                                sqlConsulta,
                                conexion,
                                transaccion))
                        {
                            comando.Parameters.Add(
                                "@PacienteId",
                                SqlDbType.Int
                            ).Value = pacienteId;

                            comando.Parameters.Add(
                                "@Fecha",
                                SqlDbType.Date
                            ).Value =
                                dtpConsulta.Value.Date;

                            SqlParameter peso =
                                comando.Parameters.Add(
                                    "@Peso",
                                    SqlDbType.Decimal);

                            peso.Precision = 6;
                            peso.Scale = 2;
                            peso.Value = nudPeso.Value;

                            SqlParameter estatura =
                                comando.Parameters.Add(
                                    "@Estatura",
                                    SqlDbType.Decimal);

                            estatura.Precision = 4;
                            estatura.Scale = 2;
                            estatura.Value = nudEstatura.Value;

                            SqlParameter valorIMC =
                                comando.Parameters.Add(
                                    "@IMC",
                                    SqlDbType.Decimal);

                            valorIMC.Precision = 5;
                            valorIMC.Scale = 1;
                            valorIMC.Value = imc;

                            comando.Parameters.Add(
                                "@CategoriaId",
                                SqlDbType.Int
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
                    "Registro exitoso en ClinicaDB.\n\n" +
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

        // LIMPIAR FORMULARIO
        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();

            cmbGenero.SelectedIndex = -1;

            dtpNacimiento.Value =
                new DateTime(2000, 1, 1);

            dtpConsulta.Value = fechaCorte;

            nudPeso.Value = 75m;
            nudEstatura.Value = 1.75m;

            ActualizarIMC();
            txtNombre.Focus();
        }
    }
}
