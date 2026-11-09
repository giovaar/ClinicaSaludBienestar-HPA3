
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public partial class frmPacientes : Form
    {
        private readonly Color oscuro =
            Color.FromArgb(18, 63, 73);

        private readonly Color turquesa =
            Color.FromArgb(20, 125, 134);

        private bool cargando = false;

        public frmPacientes()
        {
            InitializeComponent();

            txtBuscar.TextChanged +=
                (s, e) => CargarPacientes();

            btnRecargar.Click +=
                (s, e) => CargarPacientes();

            btnCerrar.Click +=
                (s, e) => Close();

            dgvPacientes.SelectionChanged +=
                dgvPacientes_SelectionChanged;

            Shown += (s, e) => CargarPacientes();
        }

        // CARGAR PACIENTES
        private void CargarPacientes()
        {
            if (cargando)
                return;

            cargando = true;

            try
            {
                DataTable datos = new DataTable();

                int pacientes;
                int consultas;

                using (SqlConnection conexion =
                    ConexionBD.CrearConexion())
                {
                    conexion.Open();

                    string sql = @"
                        SELECT
                            PacienteId AS ID,
                            Nombre,
                            Apellido,
                            CASE Genero
                                WHEN 'M' THEN 'Masculino'
                                WHEN 'F' THEN 'Femenino'
                            END AS Genero,
                            FechaNacimiento
                        FROM dbo.Paciente
                        WHERE Nombre LIKE @Buscar
                           OR Apellido LIKE @Buscar
                           OR (Nombre + N' ' + Apellido)
                              LIKE @Buscar
                        ORDER BY PacienteId;";

                    using (SqlCommand comando =
                        new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(
                            "@Buscar",
                            SqlDbType.NVarChar,
                            150
                        ).Value =
                            "%" + txtBuscar.Text.Trim() + "%";

                        using (SqlDataAdapter adaptador =
                            new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(datos);
                        }
                    }

                    using (SqlCommand comando =
                        new SqlCommand(
                            "SELECT COUNT(*) FROM dbo.Paciente",
                            conexion))
                    {
                        pacientes = Convert.ToInt32(
                            comando.ExecuteScalar());
                    }

                    using (SqlCommand comando =
                        new SqlCommand(
                            "SELECT COUNT(*) FROM dbo.Consulta",
                            conexion))
                    {
                        consultas = Convert.ToInt32(
                            comando.ExecuteScalar());
                    }
                }

                dgvPacientes.DataSource = datos;

                if (dgvPacientes.Columns.Contains(
                    "FechaNacimiento"))
                {
                    dgvPacientes.Columns["FechaNacimiento"]!
                        .HeaderText = "Fecha de nacimiento";

                    dgvPacientes.Columns["FechaNacimiento"]!
                        .DefaultCellStyle.Format =
                        "dd/MM/yyyy";
                }

                dgvPacientes.ClearSelection();

                dgvHistorial.DataSource = null;

                lblHistorial.Text =
                    "HISTORIAL DE CONSULTAS";

                lblPacientes.Text = pacientes.ToString();
                lblConsultas.Text = consultas.ToString();

                lblEstado.ForeColor = turquesa;

                lblEstado.Text =
                    "Datos recargados correctamente • " +
                    datos.Rows.Count +
                    " pacientes mostrados";
            }
            catch (Exception ex)
            {
                lblEstado.ForeColor = Color.Firebrick;

                lblEstado.Text =
                    "Error al cargar pacientes";

                MessageBox.Show(
                    "No se pudieron cargar los pacientes:\n" +
                    ex.Message,
                    "Error de Azure SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                cargando = false;
            }
        }

        // SELECCIONAR PACIENTE
        private void dgvPacientes_SelectionChanged(
            object? sender,
            EventArgs e)
        {
            if (cargando ||
                dgvPacientes.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow fila =
                dgvPacientes.SelectedRows[0];

            if (fila.Cells["ID"].Value == null)
                return;

            int pacienteId = Convert.ToInt32(
                fila.Cells["ID"].Value);

            string nombre = Convert.ToString(
                fila.Cells["Nombre"].Value) ?? "";

            string apellido = Convert.ToString(
                fila.Cells["Apellido"].Value) ?? "";

            CargarHistorial(
                pacienteId,
                nombre + " " + apellido);
        }

        // CARGAR HISTORIAL
        private void CargarHistorial(
            int pacienteId,
            string paciente)
        {
            try
            {
                DataTable datos = new DataTable();

                using (SqlConnection conexion =
                    ConexionBD.CrearConexion())
                {
                    conexion.Open();

                    string sql = @"
                        SELECT
                            c.Fecha,
                            c.Peso,
                            c.Estatura,
                            c.IMC,
                            cat.Nombre AS Categoria
                        FROM dbo.Consulta c
                        INNER JOIN dbo.Categoria cat
                            ON c.CategoriaId = cat.CategoriaId
                        WHERE c.PacienteId = @PacienteId
                        ORDER BY
                            c.Fecha ASC,
                            c.ConsultaId ASC;";

                    using (SqlCommand comando =
                        new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(
                            "@PacienteId",
                            SqlDbType.Int
                        ).Value = pacienteId;

                        using (SqlDataAdapter adaptador =
                            new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(datos);
                        }
                    }
                }

                dgvHistorial.DataSource = datos;

                if (dgvHistorial.Columns.Contains("Fecha"))
                {
                    dgvHistorial.Columns["Fecha"]!
                        .DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                if (dgvHistorial.Columns.Contains("Peso"))
                {
                    dgvHistorial.Columns["Peso"]!
                        .DefaultCellStyle.Format = "N2";
                }

                if (dgvHistorial.Columns.Contains("Estatura"))
                {
                    dgvHistorial.Columns["Estatura"]!
                        .DefaultCellStyle.Format = "N2";
                }

                if (dgvHistorial.Columns.Contains("IMC"))
                {
                    dgvHistorial.Columns["IMC"]!
                        .DefaultCellStyle.Format = "N1";
                }

                dgvHistorial.ClearSelection();

                lblHistorial.Text =
                    "HISTORIAL DE CONSULTAS — " +
                    paciente;

                lblEstado.ForeColor = turquesa;

                lblEstado.Text =
                    "Historial cargado • " +
                    datos.Rows.Count + " consultas";
            }
            catch (Exception ex)
            {
                dgvHistorial.DataSource = null;

                lblEstado.ForeColor = Color.Firebrick;
                lblEstado.Text = "Error al cargar historial";

                MessageBox.Show(
                    "No se pudo cargar el historial:\n" +
                    ex.Message,
                    "Error de Azure SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
