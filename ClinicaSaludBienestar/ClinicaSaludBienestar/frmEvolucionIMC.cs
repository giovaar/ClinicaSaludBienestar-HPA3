
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public class frmEvolucionIMC : Form
    {
        private readonly Color oscuro =
            Color.FromArgb(18, 63, 73);

        private readonly Color turquesa =
            Color.FromArgb(20, 125, 134);

        private readonly Color fondo =
            Color.FromArgb(240, 247, 247);

        private readonly Color gris =
            Color.FromArgb(105, 127, 132);

        private ComboBox cmbPacientes = null!;
        private Chart chartIMC = null!;
        private DataGridView dgvConsultas = null!;

        private Label lblInicial = null!;
        private Label lblActual = null!;
        private Label lblTendencia = null!;
        private Label lblCategoria = null!;
        private Label lblEstado = null!;

        private bool cargando = false;

        public frmEvolucionIMC()
        {
            Text = "Clínica Salud y Bienestar | Evolución del IMC";
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(950, 700);
            BackColor = fondo;
            Font = new Font("Segoe UI", 10F);

            CrearInterfaz();

            Shown += (s, e) => CargarPacientes();
        }

        // CREAR INTERFAZ
        private void CrearInterfaz()
        {
            TableLayoutPanel principal =
                new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 1,
                    RowCount = 7,
                    Padding = new Padding(18, 0, 18, 12),
                    BackColor = fondo
                };

            principal.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 95));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 80));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 110));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 43));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Percent, 55));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Percent, 45));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 45));

            Controls.Add(principal);

            // ENCABEZADO
            Panel encabezado = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = oscuro,
                Margin = new Padding(0, 0, 0, 5)
            };

            Label titulo = new Label
            {
                Text = "EVOLUCIÓN DEL IMC",
                Font = new Font(
                    "Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(22, 9),
                AutoSize = true
            };

            encabezado.Controls.Add(titulo);

            Label subtitulo = new Label
            {
                Text = "Seguimiento histórico de pacientes",
                ForeColor = Color.LightCyan,
                Location = new Point(25, 59),
                AutoSize = true
            };

            encabezado.Controls.Add(subtitulo);
            principal.Controls.Add(encabezado, 0, 0);

            // SELECCIÓN DE PACIENTES
            TableLayoutPanel filtros =
                new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 3,
                    RowCount = 2,
                    Padding = new Padding(4, 6, 4, 6)
                };

            filtros.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            filtros.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 180));

            filtros.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 150));

            filtros.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 25));

            filtros.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            Label lblSeleccion = new Label
            {
                Text = "SELECCIONAR PACIENTE",
                Dock = DockStyle.Fill,
                Font = new Font(
                    "Segoe UI", 10F, FontStyle.Bold),
                ForeColor = oscuro
            };

            filtros.Controls.Add(lblSeleccion, 0, 0);

            cmbPacientes = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 11F),
                Margin = new Padding(0, 0, 14, 4)
            };

            cmbPacientes.SelectedIndexChanged +=
                (s, e) =>
                {
                    if (!cargando &&
                        cmbPacientes.SelectedValue is int id)
                    {
                        CargarEvolucion(id);
                    }
                };

            filtros.Controls.Add(cmbPacientes, 0, 1);

            Button btnRecargar =
                CrearBoton("RECARGAR DATOS", turquesa);

            btnRecargar.Click +=
                (s, e) => CargarPacientes();

            filtros.Controls.Add(btnRecargar, 1, 1);

            Button btnCerrar =
                CrearBoton("CERRAR", oscuro);

            btnCerrar.Click += (s, e) => Close();

            filtros.Controls.Add(btnCerrar, 2, 1);

            principal.Controls.Add(filtros, 0, 1);

            // TARJETAS DE INDICADORES
            TableLayoutPanel tarjetas =
                new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 3,
                    RowCount = 1
                };

            tarjetas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33.33F));

            tarjetas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33.33F));

            tarjetas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33.34F));

            CrearTarjeta(
                tarjetas, "IMC INICIAL", 0, out lblInicial);

            CrearTarjeta(
                tarjetas, "IMC ACTUAL", 1, out lblActual);

            CrearTarjeta(
                tarjetas, "TENDENCIA", 2, out lblTendencia);

            principal.Controls.Add(tarjetas, 0, 2);

            // CATEGORÍA ACTUAL
            lblCategoria = new Label
            {
                Text = "Categoría actual: —",
                Font = new Font(
                    "Segoe UI", 12F, FontStyle.Bold),
                ForeColor = oscuro,
                Dock = DockStyle.Fill,
                Padding = new Padding(8, 9, 0, 0)
            };

            principal.Controls.Add(lblCategoria, 0, 3);

            // GRÁFICO DE EVOLUCIÓN
            TableLayoutPanel seccionGrafico =
                CrearSeccion("GRÁFICO DE EVOLUCIÓN");

            chartIMC = CrearGrafico();

            seccionGrafico.Controls.Add(chartIMC, 0, 1);
            principal.Controls.Add(seccionGrafico, 0, 4);

            // HISTORIAL DE CONSULTAS
            TableLayoutPanel seccionTabla =
                CrearSeccion("HISTORIAL DE CONSULTAS");

            dgvConsultas = CrearTabla();

            seccionTabla.Controls.Add(dgvConsultas, 0, 1);
            principal.Controls.Add(seccionTabla, 0, 5);

            // MENSAJE DE ESTADO
            lblEstado = new Label
            {
                Text = "Esperando información...",
                ForeColor = gris,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 0, 0)
            };

            principal.Controls.Add(lblEstado, 0, 6);
        }

        // CREAR CONTROL CHART
        private Chart CrearGrafico()
        {
            Chart grafico = new Chart
            {
                Name = "chartIMC",
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(4, 0, 4, 8)
            };

            ChartArea area = new ChartArea("AreaIMC");

            area.BackColor = Color.White;

            area.AxisX.Title = "Fecha de consulta";
            area.AxisX.TitleFont =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.LineColor = Color.LightGray;
            area.AxisX.LabelStyle.Font =
                new Font("Segoe UI", 8F);

            area.AxisY.Title = "IMC";
            area.AxisY.TitleFont =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            area.AxisY.LabelStyle.Format = "0.0";

            area.AxisY.MajorGrid.LineColor =
                Color.FromArgb(230, 235, 235);

            area.AxisY.LineColor = Color.LightGray;

            grafico.ChartAreas.Add(area);

            Series serie = new Series("Evolución IMC")
            {
                ChartArea = "AreaIMC",
                ChartType = SeriesChartType.Line,
                Color = turquesa,
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 10,
                MarkerColor = turquesa,
                IsValueShownAsLabel = true,
                LabelFormat = "0.0",
                Font = new Font(
                    "Segoe UI", 9F, FontStyle.Bold),
                IsXValueIndexed = true,
                XValueType = ChartValueType.Int32,
                YValueType = ChartValueType.Double
            };

            grafico.Series.Add(serie);
            grafico.Legends.Clear();

            return grafico;
        }

        // CREAR SECCIÓN
        private TableLayoutPanel CrearSeccion(string titulo)
        {
            TableLayoutPanel seccion =
                new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 1,
                    RowCount = 2
                };

            seccion.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 35));

            seccion.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            Label etiqueta = new Label
            {
                Text = titulo,
                Dock = DockStyle.Fill,
                ForeColor = oscuro,
                Font = new Font(
                    "Segoe UI", 12F, FontStyle.Bold),
                Padding = new Padding(5, 3, 0, 0)
            };

            seccion.Controls.Add(etiqueta, 0, 0);

            return seccion;
        }

        // CREAR BOTONES
        private Button CrearBoton(
            string texto, Color color)
        {
            Button boton = new Button
            {
                Text = texto,
                Dock = DockStyle.Fill,
                BackColor = color,
                ForeColor = Color.White,
                Font = new Font(
                    "Segoe UI", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Margin = new Padding(5, 0, 8, 3)
            };

            boton.FlatAppearance.BorderSize = 0;

            return boton;
        }

        // CREAR TARJETAS
        private void CrearTarjeta(
            TableLayoutPanel contenedor,
            string titulo,
            int columna,
            out Label valor)
        {
            Panel tarjeta = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(4, 5, 8, 8)
            };

            Label nombre = new Label
            {
                Text = titulo,
                Location = new Point(18, 12),
                AutoSize = true,
                ForeColor = gris,
                Font = new Font(
                    "Segoe UI", 10F, FontStyle.Bold)
            };

            tarjeta.Controls.Add(nombre);

            valor = new Label
            {
                Text = "—",
                Location = new Point(15, 40),
                Size = new Size(300, 52),
                ForeColor = turquesa,
                Font = new Font(
                    "Segoe UI", 24F, FontStyle.Bold),
                Anchor = AnchorStyles.Top |
                         AnchorStyles.Left |
                         AnchorStyles.Right
            };

            tarjeta.Controls.Add(valor);

            contenedor.Controls.Add(tarjeta, columna, 0);
        }

        // CREAR TABLA DEL HISTORIAL
        private DataGridView CrearTabla()
        {
            DataGridView tabla = new DataGridView
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(4, 0, 4, 6),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                MultiSelect = false,
                RowHeadersVisible = false,
                SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersHeight = 42
            };

            tabla.RowTemplate.Height = 34;
            tabla.EnableHeadersVisualStyles = false;

            tabla.ColumnHeadersDefaultCellStyle.BackColor =
                oscuro;

            tabla.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            tabla.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            tabla.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F);

            tabla.DefaultCellStyle.ForeColor = oscuro;

            tabla.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(209, 237, 234);

            tabla.DefaultCellStyle.SelectionForeColor =
                oscuro;

            tabla.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(246, 250, 250);

            return tabla;
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

                    string sql = @"
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

        // CARGAR EVOLUCIÓN DEL PACIENTE
        private void CargarEvolucion(int pacienteId)
        {
            try
            {
                DataTable tabla = new DataTable();

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
                            "@PacienteId", SqlDbType.Int
                        ).Value = pacienteId;

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

            // AJUSTE AUTOMÁTICO DEL EJE VERTICAL
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
                    {
                        minimo = valor;
                    }

                    if (valor > maximo)
                    {
                        maximo = valor;
                    }
                }

                // Dejar margen para visualizar los puntos
                area.AxisY.Minimum =
                    Math.Max(0, Math.Floor(minimo - 1));

                area.AxisY.Maximum =
                    Math.Ceiling(maximo + 1);

                // Separación de las líneas horizontales
                double rango =
                    area.AxisY.Maximum - area.AxisY.Minimum;

                if (rango <= 5)
                {
                    area.AxisY.Interval = 1;
                }
                else if (rango <= 10)
                {
                    area.AxisY.Interval = 2;
                }
                else
                {
                    area.AxisY.Interval = 5;
                }
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

            if (chartIMC != null)
            {
                chartIMC.Series["Evolución IMC"]
                    .Points.Clear();

                ChartArea area =
                    chartIMC.ChartAreas["AreaIMC"];

                area.AxisY.Minimum = double.NaN;
                area.AxisY.Maximum = double.NaN;
                area.AxisY.Interval = 0;
            }

            lblInicial.Text = "—";
            lblActual.Text = "—";
            lblTendencia.Text = "Sin datos";
            lblCategoria.Text =
                "Categoría actual: —";
        }
    }
}
