
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public class frmEvolucionIMC : Form
    {
        private readonly Color oscuro = Color.FromArgb(18, 63, 73);
        private readonly Color turquesa = Color.FromArgb(20, 125, 134);
        private readonly Color fondo = Color.FromArgb(240, 247, 247);
        private readonly Color gris = Color.FromArgb(105, 127, 132);

        private ComboBox cmbPacientes = null!;
        private Label lblInicial = null!;
        private Label lblActual = null!;
        private Label lblTendencia = null!;
        private Label lblCategoria = null!;
        private Label lblEstado = null!;
        private DataGridView dgvConsultas = null!;
        private Panel panelGrafico = null!;

        private bool cargando = false;
        private List<PuntoIMC> puntos = new List<PuntoIMC>();

        private class PuntoIMC
        {
            public DateTime Fecha { get; set; }
            public decimal IMC { get; set; }
        }

        // Panel con doble búfer para evitar parpadeos
        private class PanelGrafico : Panel
        {
            public PanelGrafico()
            {
                DoubleBuffered = true;
                ResizeRedraw = true;
            }
        }

        public frmEvolucionIMC()
        {
            Text = "Clínica Salud y Bienestar | Evolución del IMC";
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(900, 650);
            BackColor = fondo;
            Font = new Font("Segoe UI", 10F);

            CrearInterfaz();

            Shown += (s, e) => CargarPacientes();
        }

        // Crear interfaz adaptable
        private void CrearInterfaz()
        {
            TableLayoutPanel principal = new TableLayoutPanel();
            principal.Dock = DockStyle.Fill;
            principal.ColumnCount = 1;
            principal.RowCount = 7;
            principal.Padding = new Padding(18, 0, 18, 12);
            principal.BackColor = fondo;

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 95));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 80));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 110));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 43));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Percent, 52));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Percent, 48));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 55));

            Controls.Add(principal);

            // Encabezado
            Panel encabezado = new Panel();
            encabezado.Dock = DockStyle.Fill;
            encabezado.BackColor = oscuro;
            encabezado.Margin = new Padding(0, 0, 0, 5);

            Label titulo = new Label();
            titulo.Text = "EVOLUCIÓN DEL IMC";
            titulo.Font = new Font(
                "Segoe UI", 22F, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.Location = new Point(22, 9);
            titulo.AutoSize = true;
            encabezado.Controls.Add(titulo);

            Label subtitulo = new Label();
            subtitulo.Text =
                "Seguimiento histórico de pacientes";
            subtitulo.ForeColor = Color.LightCyan;
            subtitulo.Location = new Point(25, 59);
            subtitulo.AutoSize = true;
            encabezado.Controls.Add(subtitulo);

            principal.Controls.Add(encabezado, 0, 0);

            // Selector de paciente
            TableLayoutPanel filtros = new TableLayoutPanel();
            filtros.Dock = DockStyle.Fill;
            filtros.ColumnCount = 3;
            filtros.RowCount = 2;
            filtros.Padding = new Padding(4, 6, 4, 6);

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

            Label lblSeleccion = new Label();
            lblSeleccion.Text = "SELECCIONAR PACIENTE";
            lblSeleccion.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            lblSeleccion.ForeColor = oscuro;
            lblSeleccion.Dock = DockStyle.Fill;
            filtros.Controls.Add(lblSeleccion, 0, 0);

            cmbPacientes = new ComboBox();
            cmbPacientes.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbPacientes.Dock = DockStyle.Fill;
            cmbPacientes.Font = new Font("Segoe UI", 11F);
            cmbPacientes.Margin = new Padding(0, 0, 14, 4);

            cmbPacientes.SelectedIndexChanged += (s, e) =>
            {
                if (!cargando &&
                    cmbPacientes.SelectedValue is int pacienteId)
                {
                    CargarEvolucion(pacienteId);
                }
            };

            filtros.Controls.Add(cmbPacientes, 0, 1);

            Button btnRecargar = CrearBoton(
                "RECARGAR DATOS", turquesa);
            filtros.Controls.Add(btnRecargar, 1, 1);
            btnRecargar.Click += (s, e) => CargarPacientes();

            Button btnCerrar = CrearBoton("CERRAR", oscuro);
            filtros.Controls.Add(btnCerrar, 2, 1);
            btnCerrar.Click += (s, e) => Close();

            principal.Controls.Add(filtros, 0, 1);

            // Tarjetas de IMC
            TableLayoutPanel tarjetas = new TableLayoutPanel();
            tarjetas.Dock = DockStyle.Fill;
            tarjetas.ColumnCount = 3;
            tarjetas.RowCount = 1;

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

            // Categoría actual
            lblCategoria = new Label();
            lblCategoria.Text = "Categoría actual: —";
            lblCategoria.Font = new Font(
                "Segoe UI", 12F, FontStyle.Bold);
            lblCategoria.ForeColor = oscuro;
            lblCategoria.Dock = DockStyle.Fill;
            lblCategoria.Padding = new Padding(8, 9, 0, 0);

            principal.Controls.Add(lblCategoria, 0, 3);

            // Contenedor del gráfico
            TableLayoutPanel seccionGrafico =
                new TableLayoutPanel();

            seccionGrafico.Dock = DockStyle.Fill;
            seccionGrafico.ColumnCount = 1;
            seccionGrafico.RowCount = 2;
            seccionGrafico.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 35));
            seccionGrafico.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            Label lblGrafico = new Label();
            lblGrafico.Text = "GRÁFICO DE EVOLUCIÓN";
            lblGrafico.Font = new Font(
                "Segoe UI", 12F, FontStyle.Bold);
            lblGrafico.ForeColor = oscuro;
            lblGrafico.Dock = DockStyle.Fill;
            lblGrafico.Padding = new Padding(5, 3, 0, 0);

            seccionGrafico.Controls.Add(lblGrafico, 0, 0);

            panelGrafico = new PanelGrafico();
            panelGrafico.Dock = DockStyle.Fill;
            panelGrafico.Margin = new Padding(4, 0, 4, 8);
            panelGrafico.BackColor = Color.White;
            panelGrafico.Paint += DibujarGrafico;

            seccionGrafico.Controls.Add(panelGrafico, 0, 1);
            principal.Controls.Add(seccionGrafico, 0, 4);

            // Tabla de historial
            TableLayoutPanel seccionTabla = new TableLayoutPanel();
            seccionTabla.Dock = DockStyle.Fill;
            seccionTabla.ColumnCount = 1;
            seccionTabla.RowCount = 2;

            seccionTabla.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 35));
            seccionTabla.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            Label lblTabla = new Label();
            lblTabla.Text = "HISTORIAL DE CONSULTAS";
            lblTabla.Font = new Font(
                "Segoe UI", 12F, FontStyle.Bold);
            lblTabla.ForeColor = oscuro;
            lblTabla.Dock = DockStyle.Fill;
            lblTabla.Padding = new Padding(5, 3, 0, 0);

            seccionTabla.Controls.Add(lblTabla, 0, 0);

            dgvConsultas = CrearTabla();
            dgvConsultas.Dock = DockStyle.Fill;
            dgvConsultas.Margin = new Padding(4, 0, 4, 6);

            seccionTabla.Controls.Add(dgvConsultas, 0, 1);
            principal.Controls.Add(seccionTabla, 0, 5);

            // Estado
            lblEstado = new Label();
            lblEstado.Text = "Esperando información...";
            lblEstado.ForeColor = gris;
            lblEstado.Dock = DockStyle.Fill;
            lblEstado.TextAlign = ContentAlignment.MiddleLeft;
            lblEstado.Padding = new Padding(8, 0, 0, 0);
            principal.Controls.Add(lblEstado, 0, 6);
        }

        // Crear botones
        private Button CrearBoton(string texto, Color color)
        {
            Button boton = new Button();
            boton.Text = texto;
            boton.BackColor = color;
            boton.ForeColor = Color.White;
            boton.Dock = DockStyle.Fill;
            boton.Margin = new Padding(5, 0, 8, 3);
            boton.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Cursor = Cursors.Hand;
            return boton;
        }

        // Crear tarjetas de indicadores
        private void CrearTarjeta(
            TableLayoutPanel contenedor,
            string titulo,
            int columna,
            out Label valor)
        {
            Panel tarjeta = new Panel();
            tarjeta.Dock = DockStyle.Fill;
            tarjeta.Margin = new Padding(4, 5, 8, 8);
            tarjeta.BackColor = Color.White;

            Label nombre = new Label();
            nombre.Text = titulo;
            nombre.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            nombre.ForeColor = gris;
            nombre.Location = new Point(18, 12);
            nombre.AutoSize = true;
            tarjeta.Controls.Add(nombre);

            valor = new Label();
            valor.Text = "—";
            valor.Font = new Font(
                "Segoe UI", 24F, FontStyle.Bold);
            valor.ForeColor = turquesa;
            valor.Location = new Point(15, 40);
            valor.Size = new Size(300, 52);
            valor.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;
            tarjeta.Controls.Add(valor);

            contenedor.Controls.Add(tarjeta, columna, 0);
        }

        // Crear tabla de consultas
        private DataGridView CrearTabla()
        {
            DataGridView tabla = new DataGridView();

            tabla.ReadOnly = true;
            tabla.AllowUserToAddRows = false;
            tabla.AllowUserToDeleteRows = false;
            tabla.AllowUserToResizeRows = false;
            tabla.MultiSelect = false;
            tabla.RowHeadersVisible = false;

            tabla.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            tabla.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            tabla.ScrollBars = ScrollBars.Both;

            tabla.BackgroundColor = Color.White;
            tabla.BorderStyle = BorderStyle.None;
            tabla.RowTemplate.Height = 34;

            tabla.EnableHeadersVisualStyles = false;
            tabla.ColumnHeadersHeight = 42;
            tabla.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                    .DisableResizing;

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

        // Cargar pacientes
        private void CargarPacientes()
        {
            int? anterior = cmbPacientes.SelectedValue is int id
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

                    using (SqlDataAdapter adaptador =
                        new SqlDataAdapter(sql, conexion))
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
                            cmbPacientes.SelectedValue = anterior.Value;
                            break;
                        }
                    }
                }

                lblEstado.ForeColor = turquesa;
                lblEstado.Text =
                    "Lista recargada correctamente • " +
                    tabla.Rows.Count + " pacientes";
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

            if (cmbPacientes.SelectedValue is int seleccionado)
                CargarEvolucion(seleccionado);
        }

        // Cargar historial de IMC
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
                        ORDER BY c.Fecha ASC,
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
                    dgvConsultas.Columns["Fecha"]
                        .DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                if (dgvConsultas.Columns.Contains("Peso"))
                {
                    dgvConsultas.Columns["Peso"]
                        .DefaultCellStyle.Format = "N2";
                }

                if (dgvConsultas.Columns.Contains("Estatura"))
                {
                    dgvConsultas.Columns["Estatura"]
                        .DefaultCellStyle.Format = "N2";
                }

                if (dgvConsultas.Columns.Contains("IMC"))
                {
                    dgvConsultas.Columns["IMC"]
                        .DefaultCellStyle.Format = "N1";
                }

                dgvConsultas.ClearSelection();
                puntos.Clear();

                foreach (DataRow fila in tabla.Rows)
                {
                    puntos.Add(new PuntoIMC
                    {
                        Fecha = Convert.ToDateTime(fila["Fecha"]),
                        IMC = Convert.ToDecimal(fila["IMC"])
                    });
                }

                if (puntos.Count == 0)
                {
                    lblInicial.Text = "—";
                    lblActual.Text = "—";
                    lblTendencia.Text = "Sin datos";
                    lblCategoria.Text = "Categoría actual: —";
                }
                else
                {
                    decimal inicial = puntos[0].IMC;
                    decimal actual = puntos[puntos.Count - 1].IMC;

                    lblInicial.Text = inicial.ToString("F1");
                    lblActual.Text = actual.ToString("F1");

                    // Función que superó las pruebas límite
                    lblTendencia.Text = puntos.Count < 2
                        ? "Sin tendencia"
                        : PruebasIMC.CalcularTendencia(
                            inicial, actual);

                    lblCategoria.Text =
                        "Categoría actual: " +
                        Convert.ToString(
                            tabla.Rows[tabla.Rows.Count - 1]
                                ["Categoria"]);
                }

                panelGrafico.Invalidate();

                lblEstado.ForeColor = turquesa;
                lblEstado.Text =
                    "Datos recargados correctamente • " +
                    puntos.Count + " consultas encontradas";
            }
            catch (Exception ex)
            {
                puntos.Clear();
                dgvConsultas.DataSource = null;

                lblInicial.Text = "—";
                lblActual.Text = "—";
                lblTendencia.Text = "Sin datos";
                lblCategoria.Text = "Categoría actual: —";

                panelGrafico.Invalidate();

                lblEstado.ForeColor = Color.Firebrick;
                lblEstado.Text = "Error al cargar evolución";

                MessageBox.Show(
                    "No se pudo consultar la evolución:\n" +
                    ex.Message,
                    "Error de Azure SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Dibujar gráfico adaptable
        private void DibujarGrafico(
            object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int ancho = panelGrafico.ClientSize.Width;
            int alto = panelGrafico.ClientSize.Height;

            if (ancho < 140 || alto < 100)
                return;

            if (puntos.Count == 0)
            {
                g.DrawString(
                    "Selecciona un paciente con consultas.",
                    Font, Brushes.Gray, 25, 25);
                return;
            }

            int izquierda = 75;
            int derecha = ancho - 45;
            int arriba = 45;
            int abajo = alto - 55;

            decimal minimo = puntos[0].IMC;
            decimal maximo = puntos[0].IMC;

            foreach (PuntoIMC punto in puntos)
            {
                if (punto.IMC < minimo)
                    minimo = punto.IMC;

                if (punto.IMC > maximo)
                    maximo = punto.IMC;
            }

            // Margen para que la línea no toque el borde
            minimo -= 1m;
            maximo += 1m;

            using (Pen eje = new Pen(Color.LightGray, 1))
            using (Font fuente = new Font("Segoe UI", 9F))
            {
                // Líneas horizontales de referencia
                for (int i = 0; i <= 4; i++)
                {
                    float y = arriba +
                        (abajo - arriba) * i / 4f;

                    g.DrawLine(eje, izquierda, y, derecha, y);

                    decimal valor = maximo -
                        (maximo - minimo) * i / 4m;

                    g.DrawString(
                        valor.ToString("F1"),
                        fuente,
                        Brushes.Gray,
                        15,
                        y - 9);
                }

                g.DrawLine(
                    eje, izquierda, arriba, izquierda, abajo);
            }

            PointF? anterior = null;

            using (Font fuente = new Font("Segoe UI", 9F))
            using (Pen linea = new Pen(turquesa, 3))
            using (Brush marcador = new SolidBrush(turquesa))
            {
                for (int i = 0; i < puntos.Count; i++)
                {
                    float x = puntos.Count == 1
                        ? (izquierda + derecha) / 2f
                        : izquierda +
                          (derecha - izquierda) * i /
                          (float)(puntos.Count - 1);

                    float proporcion = (float)(
                        (puntos[i].IMC - minimo) /
                        (maximo - minimo));

                    float y = abajo -
                        (abajo - arriba) * proporcion;

                    PointF actual = new PointF(x, y);

                    if (anterior.HasValue)
                    {
                        g.DrawLine(
                            linea, anterior.Value, actual);
                    }

                    g.FillEllipse(
                        marcador, x - 5, y - 5, 10, 10);

                    string valor =
                        puntos[i].IMC.ToString("F1");

                    string fecha =
                        puntos[i].Fecha.ToString("dd/MM/yyyy");

                    SizeF tamValor =
                        g.MeasureString(valor, fuente);

                    SizeF tamFecha =
                        g.MeasureString(fecha, fuente);

                    g.DrawString(
                        valor, fuente,
                        Brushes.DarkSlateGray,
                        x - tamValor.Width / 2,
                        y - 25);

                    g.DrawString(
                        fecha, fuente,
                        Brushes.Gray,
                        x - tamFecha.Width / 2,
                        abajo + 12);

                    anterior = actual;
                }
            }
        }
    }
}
