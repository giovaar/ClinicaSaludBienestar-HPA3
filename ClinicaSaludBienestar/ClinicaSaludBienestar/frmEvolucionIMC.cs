
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public partial class frmEvolucionIMC : Form
    {
        private readonly Color turquesa =
            Color.FromArgb(20, 125, 134);

        private bool cargando = false;

        public frmEvolucionIMC()
        {
            InitializeComponent();

            cmbPacientes.SelectedIndexChanged +=
                cmbPacientes_SelectedIndexChanged;

            btnRecargar.Click +=
                (s, e) => CargarPacientes();

            btnCerrar.Click +=
                (s, e) => Close();

            Shown += (s, e) => CargarPacientes();
        }

        // SELECCIONAR PACIENTE
        private void cmbPacientes_SelectedIndexChanged(
            object? sender, EventArgs e)
        {
            if (!cargando &&
                cmbPacientes.SelectedValue is int id)
            {
                CargarEvolucion(id);
            }
        }

        // CARGAR PACIENTES
        private void CargarPacientes()
        {
            int? anterior =
                cmbPacientes.SelectedValue is int id
                    ? id
                    : null;

            cargando = true;

            try
            {
                DataTable tabla = new DataTable();

                using (SqlConnection conexion =
                    ConexionBD.CrearConexion())
                {
                    conexion.Open();

                    const string sql = @"
                        SELECT
                            PacienteId,
                            Nombre + N' ' + Apellido AS Paciente
                        FROM dbo.Paciente
                        ORDER BY PacienteId;";

                    using (SqlCommand comando =
                        new SqlCommand(sql, conexion))
                    using (SqlDataAdapter adaptador =
                        new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                cmbPacientes.DataSource = null;
                cmbPacientes.DisplayMember = "Paciente";
                cmbPacientes.ValueMember = "PacienteId";
                cmbPacientes.DataSource = tabla;

                if (anterior.HasValue)
                {
                    foreach (DataRow fila in tabla.Rows)
                    {
                        if (Convert.ToInt32(
                            fila["PacienteId"]) == anterior.Value)
                        {
                            cmbPacientes.SelectedValue =
                                anterior.Value;
                            break;
                        }
                    }
                }

                lblEstado.ForeColor = turquesa;
                lblEstado.Text =
                    "Pacientes recargados: " +
                    tabla.Rows.Count;
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

            if (cmbPacientes.SelectedValue is int seleccionado)
            {
                CargarEvolucion(seleccionado);
            }
            else
            {
                LimpiarResultados();
            }
        }

        // CARGAR HISTORIAL DEL PACIENTE
        private void CargarEvolucion(int pacienteId)
        {
            try
            {
                DataTable tabla = new DataTable();

                using (SqlConnection conexion =
                    ConexionBD.CrearConexion())
                {
                    conexion.Open();

                    const string sql = @"
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
                            SqlDbType.Int).Value = pacienteId;

                        using (SqlDataAdapter adaptador =
                            new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(tabla);
                        }
                    }
                }

                dgvConsultas.DataSource = tabla;

                if (dgvConsultas.Columns.Contains("Fecha"))
                {
                    dgvConsultas.Columns["Fecha"]!
                        .DefaultCellStyle.Format =
                        "dd/MM/yyyy";
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

                dgvConsultas.ClearSelection();

                ActualizarGrafico(tabla);
                ActualizarIndicadores(tabla);

                lblEstado.ForeColor = turquesa;
                lblEstado.Text =
                    "Datos cargados correctamente | " +
                    tabla.Rows.Count +
                    " consultas encontradas";
            }
            catch (Exception ex)
            {
                LimpiarResultados();

                lblEstado.ForeColor = Color.Firebrick;
                lblEstado.Text =
                    "Error al cargar la evolución";

                MessageBox.Show(
                    "No se pudo consultar la evolución:\n" +
                    ex.Message,
                    "Error de Azure SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ACTUALIZAR GRÁFICO CHART
        private void ActualizarGrafico(DataTable tabla)
        {
            Series serie =
                chartIMC.Series["Evolución IMC"];

            serie.Points.Clear();

            foreach (DataRow fila in tabla.Rows)
            {
                DateTime fecha =
                    Convert.ToDateTime(fila["Fecha"]);

                decimal imc =
                    Convert.ToDecimal(fila["IMC"]);

                int indice = serie.Points.AddY(
                    Convert.ToDouble(imc));

                DataPoint punto = serie.Points[indice];

                punto.AxisLabel =
                    fecha.ToString("dd/MM/yyyy");

                punto.ToolTip =
                    "Fecha: " +
                    fecha.ToString("dd/MM/yyyy") +
                    "\nIMC: " +
                    imc.ToString("F1");
            }

            ChartArea area =
                chartIMC.ChartAreas["AreaIMC"];

            area.AxisY.Minimum = double.NaN;
            area.AxisY.Maximum = double.NaN;

            if (serie.Points.Count > 0)
            {
                double minimo = double.MaxValue;
                double maximo = double.MinValue;

                foreach (DataPoint punto in serie.Points)
                {
                    double valor = punto.YValues[0];

                    if (valor < minimo)
                        minimo = valor;

                    if (valor > maximo)
                        maximo = valor;
                }

                area.AxisY.Minimum =
                    Math.Max(0, Math.Floor(minimo - 1));

                area.AxisY.Maximum =
                    Math.Ceiling(maximo + 1);

                double rango =
                    area.AxisY.Maximum - area.AxisY.Minimum;

                if (rango <= 5)
                    area.AxisY.Interval = 1;
                else if (rango <= 10)
                    area.AxisY.Interval = 2;
                else
                    area.AxisY.Interval = 5;
            }
            else
            {
                area.AxisY.Interval = 0;
            }

            area.RecalculateAxesScale();

            chartIMC.Invalidate();
        }

        // ACTUALIZAR INDICADORES
        private void ActualizarIndicadores(DataTable tabla)
        {
            if (tabla.Rows.Count == 0)
            {
                lblInicial.Text = "—";
                lblActual.Text = "—";
                lblTendencia.Text = "Sin datos";
                lblCategoria.Text =
                    "Categoría actual: —";
                return;
            }

            decimal inicial = Convert.ToDecimal(
                tabla.Rows[0]["IMC"]);

            decimal actual = Convert.ToDecimal(
                tabla.Rows[tabla.Rows.Count - 1]["IMC"]);

            lblInicial.Text = inicial.ToString("F1");
            lblActual.Text = actual.ToString("F1");

            lblTendencia.Text =
                tabla.Rows.Count < 2
                    ? "Sin tendencia"
                    : PruebasIMC.CalcularTendencia(
                        inicial, actual);

            lblCategoria.Text =
                "Categoría actual: " +
                Convert.ToString(
                    tabla.Rows[tabla.Rows.Count - 1]
                        ["Categoria"]);
        }

        // LIMPIAR RESULTADOS
        private void LimpiarResultados()
        {
            dgvConsultas.DataSource = null;

            Series serie =
                chartIMC.Series["Evolución IMC"];

            serie.Points.Clear();

            ChartArea area =
                chartIMC.ChartAreas["AreaIMC"];

            area.AxisY.Minimum = double.NaN;
            area.AxisY.Maximum = double.NaN;
            area.AxisY.Interval = 0;

            lblInicial.Text = "—";
            lblActual.Text = "—";
            lblTendencia.Text = "Sin datos";
            lblCategoria.Text = "Categoría actual: —";
        }
    }
}
