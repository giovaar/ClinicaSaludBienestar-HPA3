
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public partial class frmGestionConsultas : Form
    {
        private readonly DateTime fechaCorte =
            new DateTime(2026, 11, 10);

        private int consultaId = 0;
        private bool cargando = false;

        public frmGestionConsultas()
        {
            InitializeComponent();

            btnRecargar.Click +=
                (s, e) => CargarDatos();

            btnCerrar.Click +=
                (s, e) => Close();

            dgvConsultas.SelectionChanged +=
                dgvConsultas_SelectionChanged;

            nudPeso.ValueChanged +=
                (s, e) => ActualizarIMC();

            nudEstatura.ValueChanged +=
                (s, e) => ActualizarIMC();

            btnNuevo.Click +=
                (s, e) => LimpiarFormulario();

            btnAgregar.Click +=
                (s, e) => AgregarConsulta();

            btnActualizar.Click +=
                (s, e) => ActualizarConsulta();

            btnEliminar.Click +=
                (s, e) => EliminarConsulta();

            Shown += (s, e) => CargarDatos();

            ActualizarIMC();
        }

        // CARGAR PACIENTES Y CONSULTAS
        private void CargarDatos()
        {
            if (cargando)
                return;

            try
            {
                cargando = true;

                DataTable pacientes =
                    ConsultaDatos.ObtenerPacientes();

                cmbPaciente.DataSource = null;
                cmbPaciente.DisplayMember = "NombreCompleto";
                cmbPaciente.ValueMember = "PacienteId";
                cmbPaciente.DataSource = pacientes;

                DataTable consultas =
                    ConsultaDatos.Consultar();

                dgvConsultas.DataSource = consultas;

                if (dgvConsultas.Columns.Contains("ConsultaId"))
                {
                    dgvConsultas.Columns["ConsultaId"]!
                        .HeaderText = "ID Consulta";
                }

                if (dgvConsultas.Columns.Contains("PacienteId"))
                {
                    dgvConsultas.Columns["PacienteId"]!
                        .HeaderText = "ID Paciente";
                }

                if (dgvConsultas.Columns.Contains("Fecha"))
                {
                    dgvConsultas.Columns["Fecha"]!
                        .DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                if (dgvConsultas.Columns.Contains("Peso"))
                {
                    dgvConsultas.Columns["Peso"]!
                        .DefaultCellStyle.Format = "N2";
                }

                if (dgvConsultas.Columns.Contains("Estatura"))
                {
                    dgvConsultas.Columns["Estatura"]!
                        .DefaultCellStyle.Format = "N2";
                }

                if (dgvConsultas.Columns.Contains("IMC"))
                {
                    dgvConsultas.Columns["IMC"]!
                        .DefaultCellStyle.Format = "N1";
                }

                lblEstado.ForeColor =
                    Color.FromArgb(20, 125, 134);

                lblEstado.Text =
                    "Pacientes disponibles: " +
                    pacientes.Rows.Count +
                    "  |  Consultas registradas: " +
                    consultas.Rows.Count;

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                lblEstado.ForeColor = Color.Firebrick;
                lblEstado.Text = "Error al cargar los datos.";

                MessageBox.Show(
                    "No se pudieron cargar las consultas.\n" +
                    ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                cargando = false;
            }
        }

        // SELECCIONAR CONSULTA DE LA TABLA
        private void dgvConsultas_SelectionChanged(
            object? sender,
            EventArgs e)
        {
            if (cargando ||
                dgvConsultas.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow fila =
                dgvConsultas.SelectedRows[0];

            if (fila.Cells["ConsultaId"].Value == null)
                return;

            try
            {
                consultaId = Convert.ToInt32(
                    fila.Cells["ConsultaId"].Value);

                int pacienteId = Convert.ToInt32(
                    fila.Cells["PacienteId"].Value);

                cmbPaciente.SelectedValue = pacienteId;

                dtpFecha.Value = Convert.ToDateTime(
                    fila.Cells["Fecha"].Value);

                nudPeso.Value = Convert.ToDecimal(
                    fila.Cells["Peso"].Value);

                nudEstatura.Value = Convert.ToDecimal(
                    fila.Cells["Estatura"].Value);

                lblSeleccion.Text =
                    "Consulta seleccionada: ID " +
                    consultaId;

                ActualizarIMC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar la consulta.\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // CALCULAR IMC
        private void ActualizarIMC()
        {
            decimal imc = ConsultaDatos.CalcularIMC(
                nudPeso.Value,
                nudEstatura.Value);

            lblIMC.Text =
                "IMC CALCULADO: " + imc.ToString("F1");
        }

        // OBTENER PACIENTE SELECCIONADO
        private int ObtenerPacienteSeleccionado()
        {
            if (cmbPaciente.SelectedValue == null ||
                cmbPaciente.SelectedValue is DataRowView)
            {
                throw new InvalidOperationException(
                    "Selecciona un paciente válido.");
            }

            return Convert.ToInt32(
                cmbPaciente.SelectedValue);
        }

        // AGREGAR CONSULTA
        private void AgregarConsulta()
        {
            if (consultaId != 0)
            {
                MessageBox.Show(
                    "Presiona LIMPIAR / NUEVA " +
                    "para registrar otra consulta.",
                    "Consulta seleccionada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int pacienteId =
                    ObtenerPacienteSeleccionado();

                DialogResult respuesta = MessageBox.Show(
                    "¿Agregar esta consulta a ClinicaDB?",
                    "Confirmar registro",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                int nuevoId = ConsultaDatos.Agregar(
                    pacienteId,
                    dtpFecha.Value,
                    nudPeso.Value,
                    nudEstatura.Value);

                MessageBox.Show(
                    "Consulta registrada correctamente.\n" +
                    "ID: " + nuevoId,
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarDatos();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ACTUALIZAR CONSULTA
        private void ActualizarConsulta()
        {
            if (consultaId == 0)
            {
                MessageBox.Show(
                    "Selecciona una consulta de la tabla.");
                return;
            }

            try
            {
                int pacienteId =
                    ObtenerPacienteSeleccionado();

                DialogResult respuesta = MessageBox.Show(
                    "¿Actualizar la consulta ID " +
                    consultaId + " en ClinicaDB?",
                    "Confirmar actualización",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                bool actualizado =
                    ConsultaDatos.Actualizar(
                        consultaId,
                        pacienteId,
                        dtpFecha.Value,
                        nudPeso.Value,
                        nudEstatura.Value);

                MessageBox.Show(
                    actualizado
                        ? "Consulta actualizada correctamente."
                        : "No se encontró la consulta.");

                CargarDatos();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ELIMINAR CONSULTA
        private void EliminarConsulta()
        {
            if (consultaId == 0)
            {
                MessageBox.Show(
                    "Selecciona una consulta para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Eliminar definitivamente la consulta ID " +
                consultaId + " de ClinicaDB?\n\n" +
                "Esta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                bool eliminado =
                    ConsultaDatos.Eliminar(consultaId);

                MessageBox.Show(
                    eliminado
                        ? "Consulta eliminada correctamente."
                        : "No se encontró la consulta.");

                CargarDatos();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // LIMPIAR FORMULARIO
        private void LimpiarFormulario()
        {
            consultaId = 0;

            cmbPaciente.SelectedIndex = -1;
            dtpFecha.Value = fechaCorte;

            nudPeso.Value = 75m;
            nudEstatura.Value = 1.75m;

            lblSeleccion.Text =
                "Nueva consulta | Sin selección";

            dgvConsultas.ClearSelection();

            ActualizarIMC();
        }

        // MOSTRAR ERRORES
        private void MostrarError(Exception ex)
        {
            MessageBox.Show(
                "Ocurrió un error:\n" + ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
