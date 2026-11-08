
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public class frmInformeGeneral : Form
    {
        private readonly Color oscuro = Color.FromArgb(18, 63, 73);
        private readonly Color turquesa = Color.FromArgb(20, 125, 134);
        private readonly Color fondo = Color.FromArgb(240, 247, 247);
        private readonly Color gris = Color.FromArgb(105, 127, 132);

        private readonly DateTime fechaCorte =
            new DateTime(2026, 11, 10);

        private Label lblPacientes = null!;
        private Label lblEdadPromedio = null!;
        private Label lblConsultas = null!;
        private Label lblMayor = null!;
        private Label lblMenor = null!;
        private Label lblEstado = null!;
        private DataGridView dgvCategorias = null!;

        public frmInformeGeneral()
        {
            Text = "Clínica Salud y Bienestar | Informe general";
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(900, 650);
            BackColor = fondo;
            Font = new Font("Segoe UI", 10F);

            CrearInterfaz();
            Shown += (s, e) => CargarInforme();
        }

        // Crear interfaz adaptable
        private void CrearInterfaz()
        {
            TableLayoutPanel principal = new TableLayoutPanel();
            principal.Dock = DockStyle.Fill;
            principal.ColumnCount = 1;
            principal.RowCount = 6;
            principal.Padding = new Padding(18, 0, 18, 12);
            principal.BackColor = fondo;

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 100));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 128));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 68));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 120));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 62));

            Controls.Add(principal);

            // Encabezado
            Panel encabezado = new Panel();
            encabezado.Dock = DockStyle.Fill;
            encabezado.BackColor = oscuro;
            encabezado.Margin = new Padding(0, 0, 0, 8);

            Label titulo = new Label();
            titulo.Text = "INFORME GENERAL";
            titulo.Font = new Font(
                "Segoe UI", 22F, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.Location = new Point(22, 10);
            titulo.AutoSize = true;
            encabezado.Controls.Add(titulo);

            Label subtitulo = new Label();
            subtitulo.Text =
                "Estadísticas generales • Corte: 10/11/2026";
            subtitulo.ForeColor = Color.LightCyan;
            subtitulo.Location = new Point(25, 62);
            subtitulo.AutoSize = true;
            encabezado.Controls.Add(subtitulo);

            principal.Controls.Add(encabezado, 0, 0);

            // Tarjetas de resumen
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
                tarjetas, "PACIENTES REGISTRADOS",
                0, out lblPacientes);

            CrearTarjeta(
                tarjetas, "EDAD PROMEDIO",
                1, out lblEdadPromedio);

            CrearTarjeta(
                tarjetas, "CONSULTAS REGISTRADAS",
                2, out lblConsultas);

            principal.Controls.Add(tarjetas, 0, 1);

            // Título de tabla
            Panel seccion = new Panel();
            seccion.Dock = DockStyle.Fill;

            Label lblSeccion = new Label();
            lblSeccion.Text =
                "DISTRIBUCIÓN POR CATEGORÍA DE IMC";
            lblSeccion.Font = new Font(
                "Segoe UI", 14F, FontStyle.Bold);
            lblSeccion.ForeColor = oscuro;
            lblSeccion.Location = new Point(5, 7);
            lblSeccion.AutoSize = true;
            seccion.Controls.Add(lblSeccion);

            Label detalle = new Label();
            detalle.Text =
                "Se utiliza la última consulta de cada paciente.";
            detalle.ForeColor = gris;
            detalle.Location = new Point(7, 41);
            detalle.AutoSize = true;
            seccion.Controls.Add(detalle);

            principal.Controls.Add(seccion, 0, 2);

            // Tabla adaptable
            dgvCategorias = new DataGridView();
            dgvCategorias.Dock = DockStyle.Fill;
            dgvCategorias.Margin = new Padding(4, 0, 4, 10);
            dgvCategorias.ReadOnly = true;
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AllowUserToDeleteRows = false;
            dgvCategorias.AllowUserToResizeRows = false;
            dgvCategorias.RowHeadersVisible = false;
            dgvCategorias.MultiSelect = false;
            dgvCategorias.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCategorias.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.ScrollBars = ScrollBars.Both;
            dgvCategorias.BackgroundColor = Color.White;
            dgvCategorias.BorderStyle = BorderStyle.None;
            dgvCategorias.RowTemplate.Height = 36;
            dgvCategorias.EnableHeadersVisualStyles = false;

            dgvCategorias.ColumnHeadersHeight = 44;
            dgvCategorias.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                    .DisableResizing;

            dgvCategorias.ColumnHeadersDefaultCellStyle.BackColor =
                oscuro;
            dgvCategorias.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            dgvCategorias.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);

            dgvCategorias.DefaultCellStyle.Font =
                new Font("Segoe UI", 11F);
            dgvCategorias.DefaultCellStyle.ForeColor = oscuro;
            dgvCategorias.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(209, 237, 234);
            dgvCategorias.DefaultCellStyle.SelectionForeColor =
                oscuro;
            dgvCategorias.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(246, 250, 250);

            principal.Controls.Add(dgvCategorias, 0, 3);

            // Categorías más y menos frecuentes
            TableLayoutPanel resumen = new TableLayoutPanel();
            resumen.Dock = DockStyle.Fill;
            resumen.ColumnCount = 2;
            resumen.RowCount = 1;
            resumen.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50));
            resumen.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50));

            lblMayor = CrearResumen(
                resumen, "MAYOR FRECUENCIA", 0);

            lblMenor = CrearResumen(
                resumen, "MENOR FRECUENCIA", 1);

            principal.Controls.Add(resumen, 0, 4);

            // Barra de acciones
            FlowLayoutPanel acciones = new FlowLayoutPanel();
            acciones.Dock = DockStyle.Fill;
            acciones.FlowDirection = FlowDirection.LeftToRight;
            acciones.WrapContents = false;
            acciones.Padding = new Padding(4, 8, 0, 0);

            Button btnRecargar = CrearBoton(
                "RECARGAR DATOS", turquesa, 205);
            btnRecargar.Click += (s, e) => CargarInforme();
            acciones.Controls.Add(btnRecargar);

            Button btnCerrar = CrearBoton(
                "CERRAR", oscuro, 135);
            btnCerrar.Click += (s, e) => Close();
            acciones.Controls.Add(btnCerrar);

            lblEstado = new Label();
            lblEstado.Text = "Esperando información...";
            lblEstado.ForeColor = gris;
            lblEstado.AutoSize = true;
            lblEstado.Margin = new Padding(25, 13, 0, 0);
            acciones.Controls.Add(lblEstado);

            principal.Controls.Add(acciones, 0, 5);
        }

        // Crear tarjeta estadística
        private void CrearTarjeta(
            TableLayoutPanel contenedor,
            string titulo,
            int columna,
            out Label valor)
        {
            Panel tarjeta = new Panel();
            tarjeta.BackColor = Color.White;
            tarjeta.Dock = DockStyle.Fill;
            tarjeta.Margin = new Padding(4, 12, 8, 12);

            Label nombre = new Label();
            nombre.Text = titulo;
            nombre.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            nombre.ForeColor = gris;
            nombre.Location = new Point(18, 14);
            nombre.AutoSize = true;
            tarjeta.Controls.Add(nombre);

            valor = new Label();
            valor.Text = "—";
            valor.Font = new Font(
                "Segoe UI", 25F, FontStyle.Bold);
            valor.ForeColor = turquesa;
            valor.Location = new Point(16, 44);
            valor.Size = new Size(270, 53);
            valor.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;
            tarjeta.Controls.Add(valor);

            contenedor.Controls.Add(tarjeta, columna, 0);
        }

        // Crear resumen de frecuencias
        private Label CrearResumen(
            TableLayoutPanel contenedor,
            string titulo,
            int columna)
        {
            Panel panel = new Panel();
            panel.BackColor = Color.White;
            panel.Dock = DockStyle.Fill;
            panel.Margin = new Padding(4, 0, 8, 10);

            Label nombre = new Label();
            nombre.Text = titulo;
            nombre.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            nombre.ForeColor = gris;
            nombre.Location = new Point(18, 12);
            nombre.AutoSize = true;
            panel.Controls.Add(nombre);

            Label valor = new Label();
            valor.Text = "—";
            valor.Font = new Font(
                "Segoe UI", 12F, FontStyle.Bold);
            valor.ForeColor = turquesa;
            valor.Location = new Point(18, 42);
            valor.Size = new Size(450, 55);
            valor.Dock = DockStyle.Bottom;
            valor.Padding = new Padding(18, 0, 12, 0);
            valor.AutoEllipsis = true;
            panel.Controls.Add(valor);

            contenedor.Controls.Add(panel, columna, 0);
            return valor;
        }

        // Crear botón
        private Button CrearBoton(
            string texto, Color color, int ancho)
        {
            Button boton = new Button();
            boton.Text = texto;
            boton.Width = ancho;
            boton.Height = 42;
            boton.BackColor = color;
            boton.ForeColor = Color.White;
            boton.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Cursor = Cursors.Hand;
            boton.Margin = new Padding(0, 0, 12, 0);
            return boton;
        }

        // Consultar informe desde Azure SQL
        private void CargarInforme()
        {
            try
            {
                DataTable categorias = new DataTable();
                int totalPacientes;
                int totalConsultas;
                object? edadResultado;

                using (SqlConnection conexion =
                    ConexionBD.CrearConexion())
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(
                        "SELECT COUNT(*) FROM dbo.Paciente", conexion))
                    {
                        totalPacientes = Convert.ToInt32(
                            comando.ExecuteScalar());
                    }

                    using (SqlCommand comando = new SqlCommand(
                        "SELECT COUNT(*) FROM dbo.Consulta", conexion))
                    {
                        totalConsultas = Convert.ToInt32(
                            comando.ExecuteScalar());
                    }

                    // Edad en años cumplidos al corte
                    string sqlEdad = @"
                        SELECT AVG(CAST(
                            DATEDIFF(YEAR, FechaNacimiento, @Corte)
                            - CASE
                                WHEN DATEADD(
                                    YEAR,
                                    DATEDIFF(
                                        YEAR,
                                        FechaNacimiento,
                                        @Corte
                                    ),
                                    FechaNacimiento
                                ) > @Corte
                                THEN 1
                                ELSE 0
                              END
                            AS DECIMAL(10,2)
                        ))
                        FROM dbo.Paciente
                        WHERE FechaNacimiento <= @Corte;";

                    using (SqlCommand comando =
                        new SqlCommand(sqlEdad, conexion))
                    {
                        comando.Parameters.Add(
                            "@Corte", SqlDbType.Date
                        ).Value = fechaCorte;

                        edadResultado = comando.ExecuteScalar();
                    }

                    // Una categoría por paciente:
                    // la de su última consulta
                    string sqlCategorias = @"
                        WITH UltimaConsulta AS
                        (
                            SELECT
                                PacienteId,
                                CategoriaId,
                                ROW_NUMBER() OVER
                                (
                                    PARTITION BY PacienteId
                                    ORDER BY Fecha DESC,
                                             ConsultaId DESC
                                ) AS Numero
                            FROM dbo.Consulta
                            WHERE Fecha <= @Corte
                        )
                        SELECT
                            cat.Nombre AS Categoria,
                            COUNT(u.PacienteId) AS Cantidad
                        FROM dbo.Categoria cat
                        LEFT JOIN UltimaConsulta u
                            ON cat.CategoriaId = u.CategoriaId
                           AND u.Numero = 1
                        GROUP BY
                            cat.CategoriaId,
                            cat.Nombre,
                            cat.LimiteInferior
                        ORDER BY
                            CASE
                                WHEN cat.LimiteInferior IS NULL
                                THEN 0
                                ELSE 1
                            END,
                            cat.LimiteInferior;";

                    using (SqlCommand comando =
                        new SqlCommand(sqlCategorias, conexion))
                    {
                        comando.Parameters.Add(
                            "@Corte", SqlDbType.Date
                        ).Value = fechaCorte;

                        using (SqlDataAdapter adaptador =
                            new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(categorias);
                        }
                    }
                }

                lblPacientes.Text = totalPacientes.ToString();
                lblConsultas.Text = totalConsultas.ToString();

                lblEdadPromedio.Text =
                    edadResultado == null ||
                    edadResultado == DBNull.Value
                        ? "—"
                        : Convert.ToDecimal(edadResultado)
                            .ToString("F1") + " años";

                dgvCategorias.DataSource = categorias;
                dgvCategorias.ClearSelection();

                CalcularFrecuencias(categorias);

                lblEstado.ForeColor = turquesa;
                lblEstado.Text =
                    "Datos recargados correctamente";
            }
            catch (Exception ex)
            {
                lblEstado.ForeColor = Color.Firebrick;
                lblEstado.Text = "Error al recargar datos";

                MessageBox.Show(
                    "No se pudo generar el informe:\n" +
                    ex.Message,
                    "Error de Azure SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Calcular categorías más y menos frecuentes
        private void CalcularFrecuencias(DataTable tabla)
        {
            var frecuencias = tabla.AsEnumerable()
                .Select(fila => new
                {
                    Nombre = Convert.ToString(
                        fila["Categoria"]) ?? "",
                    Cantidad = Convert.ToInt32(
                        fila["Cantidad"])
                })
                .ToList();

            if (frecuencias.Count == 0 ||
                frecuencias.All(x => x.Cantidad == 0))
            {
                lblMayor.Text = "Sin registros";
                lblMenor.Text = "Sin registros";
                return;
            }

            int maximo = frecuencias.Max(x => x.Cantidad);

            int minimo = frecuencias
                .Where(x => x.Cantidad > 0)
                .Min(x => x.Cantidad);

            string mayores = string.Join(", ",
                frecuencias
                    .Where(x => x.Cantidad == maximo)
                    .Select(x => x.Nombre));

            string menores = string.Join(", ",
                frecuencias
                    .Where(x => x.Cantidad == minimo)
                    .Select(x => x.Nombre));

            lblMayor.Text = mayores + " (" + maximo + ")";
            lblMenor.Text = menores + " (" + minimo + ")";
        }
    }
}
