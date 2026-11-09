
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public partial class frmConsultas : Form
    {
        private readonly Color turquesa =
            Color.FromArgb(20, 125, 134);

        private bool cargando = false;

        public frmConsultas()
        {
            InitializeComponent();

            cmbPacientes.SelectedIndexChanged +=
                (s, e) => CargarConsultas();

            txtBuscar.TextChanged +=
                (s, e) => CargarConsultas();

            btnRecargar.Click +=
                (s, e) => CargarConsultas();

            btnCerrar.Click +=
                (s, e) => Close();

            dgvConsultas.SelectionChanged +=
                dgvConsultas_SelectionChanged;

            Shown += (s, e) => CargarPacientes();
        }

        private void CargarPacientes()
        {
            cargando = true;

            try
            {
                DataTable tabla = new DataTable();

                using (SqlConnection conexion =
                    ConexionBD.CrearConexion())
                {
                    conexion.Open();

                    string sql = @"
                        SELECT
                            PacienteId,
                            Nombre + N' ' + Apellido
                                AS Paciente
                        FROM dbo.Paciente
                        ORDER BY PacienteId;";

                    using (SqlDataAdapter adaptador =
                        new SqlDataAdapter(sql, conexion))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                DataRow todos = tabla.NewRow();
                todos["PacienteId"] = 0;
                todos["Paciente"] = "Todos los pacientes";
                tabla.Rows.InsertAt(todos, 0);

                cmbPacientes.DisplayMember = "Paciente";
                cmbPacientes.ValueMember = "PacienteId";
                cmbPacientes.DataSource = tabla;
                cmbPacientes.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblEstado.ForeColor = Color.Firebrick;
                lblEstado.Text = "Error al cargar pacientes";

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

            if (cmbPacientes.SelectedValue is int)
                CargarConsultas();
        }

        private void CargarConsultas()
        {
            if (cargando)
                return;

            if (cmbPacientes.SelectedValue is not int pacienteId)
                return;

            cargando = true;

            try
            {
                DataTable datos = new DataTable();
                int total;

                using (SqlConnection conexion =
                    ConexionBD.CrearConexion())
                {
                    conexion.Open();

                    string sql = @"
                        SELECT
                            c.ConsultaId AS ID,
                            p.Nombre + N' ' + p.Apellido
                                AS Paciente,
                            c.Fecha,
                            c.Peso,
                            c.Estatura,
                            c.IMC,
                            cat.Nombre AS Categoria
                        FROM dbo.Consulta c
                        INNER JOIN dbo.Paciente p
                            ON c.PacienteId = p.PacienteId
                        INNER JOIN dbo.Categoria cat
                            ON c.CategoriaId = cat.CategoriaId
                        WHERE
                            (@PacienteId = 0
                             OR c.PacienteId = @PacienteId)
                            AND
                            (
                                p.Nombre LIKE @Buscar
                                OR p.Apellido LIKE @Buscar
                                OR (p.Nombre + N' ' + p.Apellido)
                                   LIKE @Buscar
                            )
                        ORDER BY
                            c.Fecha DESC,
                            c.ConsultaId DESC;";

                    using (SqlCommand comando =
                        new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(
                            "@PacienteId",
                            SqlDbType.Int).Value = pacienteId;

                        comando.Parameters.Add(
                            "@Buscar",
                            SqlDbType.NVarChar,
                            150).Value =
                            "%" + txtBuscar.Text.Trim() + "%";

                        using (SqlDataAdapter adaptador =
                            new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(datos);
                        }
                    }

                    using (SqlCommand comando =
                        new SqlCommand(
                            "SELECT COUNT(*) FROM dbo.Consulta",
                            conexion))
                    {
                        total = Convert.ToInt32(
                            comando.ExecuteScalar());
                    }
                }

                dgvConsultas.DataSource = datos;

                if (dgvConsultas.Columns.Contains("Fecha"))
                    dgvConsultas.Columns["Fecha"]!
                        .DefaultCellStyle.Format = "dd/MM/yyyy";

                if (dgvConsultas.Columns.Contains("Peso"))
                    dgvConsultas.Columns["Peso"]!
                        .DefaultCellStyle.Format = "N2";

                if (dgvConsultas.Columns.Contains("Estatura"))
                    dgvConsultas.Columns["Estatura"]!
                        .DefaultCellStyle.Format = "N2";

                if (dgvConsultas.Columns.Contains("IMC"))
                    dgvConsultas.Columns["IMC"]!
                        .DefaultCellStyle.Format = "N1";

                dgvConsultas.ClearSelection();

                lblTotal.Text = total.ToString();
                lblMostradas.Text = datos.Rows.Count.ToString();
                lblIMC.Text = "—";
                lblDetalle.Text = "Selecciona una consulta";
                lblCategoria.Text = "Categoría IMC: —";

                lblEstado.ForeColor = turquesa;
                lblEstado.Text =
                    "Datos recargados correctamente • " +
                    datos.Rows.Count + " consultas mostradas";
            }
            catch (Exception ex)
            {
                dgvConsultas.DataSource = null;
                lblTotal.Text = "—";
                lblMostradas.Text = "—";
                lblIMC.Text = "—";
                lblDetalle.Text = "Sin información";
                lblCategoria.Text = "Categoría IMC: —";

                lblEstado.ForeColor = Color.Firebrick;
                lblEstado.Text = "Error al recargar datos";

                MessageBox.Show(
                    "No se pudieron cargar las consultas:\n" +
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

        private void dgvConsultas_SelectionChanged(
            object? sender,
            EventArgs e)
        {
            if (cargando ||
                dgvConsultas.SelectedRows.Count == 0)
                return;

            DataGridViewRow fila =
                dgvConsultas.SelectedRows[0];

            if (fila.Cells["IMC"].Value == null)
                return;

            string paciente = Convert.ToString(
                fila.Cells["Paciente"].Value) ?? "";

            decimal imc = Convert.ToDecimal(
                fila.Cells["IMC"].Value);

            string categoria = Convert.ToString(
                fila.Cells["Categoria"].Value) ?? "";

            DateTime fecha = Convert.ToDateTime(
                fila.Cells["Fecha"].Value);

            lblIMC.Text = imc.ToString("F1");

            lblDetalle.Text =
                paciente + " | Consulta del " +
                fecha.ToString("dd/MM/yyyy");

            lblCategoria.Text =
                "Categoría IMC: " + categoria;
        }
    }
}
