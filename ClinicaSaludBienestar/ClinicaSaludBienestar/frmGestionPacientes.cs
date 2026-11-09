
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public partial class frmGestionPacientes : Form
    {
        private int pacienteId = 0;
        private bool cargando = false;

        public frmGestionPacientes()
        {
            InitializeComponent();

            txtBuscar.KeyDown += txtBuscar_KeyDown;

            btnBuscar.Click += (s, e) =>
                CargarPacientes();

            btnRecargar.Click += (s, e) =>
            {
                txtBuscar.Clear();
                CargarPacientes();
            };

            dgvPacientes.SelectionChanged +=
                dgvPacientes_SelectionChanged;

            btnNuevo.Click += (s, e) =>
                LimpiarFormulario();

            btnAgregar.Click += (s, e) =>
                AbrirRegistroCompleto();

            btnActualizar.Click += (s, e) =>
                ActualizarPaciente();

            btnEliminar.Click += (s, e) =>
                EliminarPaciente();

            btnCerrar.Click += (s, e) => Close();

            Shown += (s, e) => CargarPacientes();

            LimpiarFormulario();
        }

        private void txtBuscar_KeyDown(
            object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CargarPacientes();
            }
        }

        // CONSULTAR PACIENTES
        private void CargarPacientes()
        {
            try
            {
                cargando = true;

                DataTable tabla =
                    PacienteDatos.Consultar(txtBuscar.Text);

                dgvPacientes.DataSource = tabla;

                if (dgvPacientes.Columns.Contains("PacienteId"))
                {
                    dgvPacientes.Columns["PacienteId"]!
                        .HeaderText = "ID";
                }

                if (dgvPacientes.Columns.Contains(
                    "FechaNacimiento"))
                {
                    dgvPacientes.Columns["FechaNacimiento"]!
                        .HeaderText = "Fecha de nacimiento";

                    dgvPacientes.Columns["FechaNacimiento"]!
                        .DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                lblEstado.ForeColor =
                    Color.FromArgb(20, 125, 134);

                lblEstado.Text =
                    "Pacientes encontrados: " +
                    tabla.Rows.Count +
                    " | Base: ClinicaDB";

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                lblEstado.ForeColor = Color.Firebrick;

                lblEstado.Text =
                    "No se pudieron cargar los pacientes.";

                MessageBox.Show(
                    "Error al consultar los pacientes.\n" +
                    ex.Message,
                    "Error SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                cargando = false;
            }
        }

        // SELECCIONAR UN PACIENTE
        private void dgvPacientes_SelectionChanged(
            object? sender, EventArgs e)
        {
            if (cargando ||
                dgvPacientes.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow fila =
                dgvPacientes.SelectedRows[0];

            if (fila.Cells["PacienteId"].Value == null)
                return;

            pacienteId = Convert.ToInt32(
                fila.Cells["PacienteId"].Value);

            txtNombre.Text = Convert.ToString(
                fila.Cells["Nombre"].Value) ?? "";

            txtApellido.Text = Convert.ToString(
                fila.Cells["Apellido"].Value) ?? "";

            string genero = (
                Convert.ToString(
                    fila.Cells["Genero"].Value) ?? ""
            ).Trim();

            cmbGenero.SelectedIndex =
                genero == "M" ? 0 :
                genero == "F" ? 1 : -1;

            dtpNacimiento.Value = Convert.ToDateTime(
                fila.Cells["FechaNacimiento"].Value);

            lblSeleccion.Text =
                "Paciente seleccionado: ID " + pacienteId;
        }

        // ABRIR REGISTRO CON PRIMERA CONSULTA
        private void AbrirRegistroCompleto()
        {
            using (frmRegistroPaciente ventana =
                new frmRegistroPaciente())
            {
                ventana.ShowDialog(this);

                if (ventana.RegistroRealizado)
                {
                    txtBuscar.Clear();
                    CargarPacientes();
                }
            }
        }

        // ACTUALIZAR DATOS PERSONALES
        private void ActualizarPaciente()
        {
            if (pacienteId == 0)
            {
                MessageBox.Show(
                    "Selecciona un paciente de la tabla.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                cmbGenero.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Completa nombre, apellido y género.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Actualizar los datos del paciente ID " +
                pacienteId + " en ClinicaDB?",
                "Confirmar actualización",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                string genero =
                    cmbGenero.SelectedIndex == 0 ? "M" : "F";

                bool actualizado = PacienteDatos.Actualizar(
                    pacienteId,
                    txtNombre.Text,
                    txtApellido.Text,
                    genero,
                    dtpNacimiento.Value);

                MessageBox.Show(
                    actualizado
                        ? "Paciente actualizado correctamente."
                        : "No se encontró el paciente.");

                CargarPacientes();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ELIMINAR PACIENTE SIN CONSULTAS
        private void EliminarPaciente()
        {
            if (pacienteId == 0)
            {
                MessageBox.Show(
                    "Selecciona un paciente para eliminar.");
                return;
            }

            try
            {
                if (PacienteDatos.TieneConsultas(pacienteId))
                {
                    MessageBox.Show(
                        "Este paciente tiene consultas.\n" +
                        "No se permite eliminarlo mientras " +
                        "exista su historial clínico.",
                        "Eliminación bloqueada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Eliminar definitivamente al paciente " +
                    pacienteId + " de ClinicaDB?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta != DialogResult.Yes)
                    return;

                bool eliminado =
                    PacienteDatos.Eliminar(pacienteId);

                MessageBox.Show(
                    eliminado
                        ? "Paciente eliminado correctamente."
                        : "No se pudo eliminar el paciente.");

                CargarPacientes();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // LIMPIAR CAMPOS
        private void LimpiarFormulario()
        {
            pacienteId = 0;

            txtNombre.Clear();
            txtApellido.Clear();

            cmbGenero.SelectedIndex = -1;

            dtpNacimiento.Value =
                new DateTime(2000, 1, 1);

            lblSeleccion.Text =
                "Sin paciente seleccionado";

            dgvPacientes.ClearSelection();
        }

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
