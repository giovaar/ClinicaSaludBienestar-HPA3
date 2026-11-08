
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

        private Label lblPacientes;
        private Label lblEdadPromedio;
        private Label lblConsultas;
        private Label lblMayor;
        private Label lblMenor;
        private Label lblEstado;
        private DataGridView dgvCategorias;

        private readonly DateTime fechaCorte =
            new DateTime(2026, 11, 10);

        public frmInformeGeneral()
        {
            Text = "Clínica Salud y Bienestar | Informe general";
            ClientSize = new Size(1100, 760);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = fondo;
            Font = new Font("Segoe UI", 10F);

            CrearInterfaz();

            Shown += (s, e) => CargarInforme();
        }

        // Crear interfaz
        private void CrearInterfaz()
        {
            Panel encabezado = new Panel();
            encabezado.Dock = DockStyle.Top;
            encabezado.Height = 105;
            encabezado.BackColor = oscuro;
            Controls.Add(encabezado);

            Label titulo = new Label();
            titulo.Text = "INFORME GENERAL";
            titulo.Font = new Font(
                "Segoe UI", 23F, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.Location = new Point(35, 18);
            titulo.AutoSize = true;
            encabezado.Controls.Add(titulo);

            Label subtitulo = new Label();
            subtitulo.Text =
                "Estadísticas generales • Corte: 10/11/2026";
            subtitulo.ForeColor = Color.LightCyan;
            subtitulo.Location = new Point(38, 70);
            subtitulo.AutoSize = true;
            encabezado.Controls.Add(subtitulo);

            CrearTarjeta(
                "PACIENTES REGISTRADOS",
                35, 130, 320,
                out lblPacientes);

            CrearTarjeta(
                "EDAD PROMEDIO",
                390, 130, 320,
                out lblEdadPromedio);

            CrearTarjeta(
                "CONSULTAS REGISTRADAS",
                745, 130, 320,
                out lblConsultas);

            Label lblSeccion = new Label();
            lblSeccion.Text =
                "DISTRIBUCIÓN POR CATEGORÍA DE IMC";
            lblSeccion.Font = new Font(
                "Segoe UI", 14F, FontStyle.Bold);
            lblSeccion.ForeColor = oscuro;
            lblSeccion.Location = new Point(35, 260);
            lblSeccion.AutoSize = true;
            Controls.Add(lblSeccion);

            Label lblDetalle = new Label();
            lblDetalle.Text =
                "Se considera la última consulta de cada paciente.";
            lblDetalle.ForeColor = gris;
            lblDetalle.Location = new Point(37, 297);
            lblDetalle.AutoSize = true;
            Controls.Add(lblDetalle);

            dgvCategorias = new DataGridView();
            dgvCategorias.Location = new Point(35, 330);
            dgvCategorias.Size = new Size(1030, 232);
            dgvCategorias.ReadOnly = true;
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AllowUserToDeleteRows = false;
            dgvCategorias.AllowUserToResizeRows = false;
            dgvCategorias.MultiSelect = false;
            dgvCategorias.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvCategorias.BackgroundColor = Color.White;
            dgvCategorias.BorderStyle = BorderStyle.None;
            dgvCategorias.RowHeadersVisible = false;
            dgvCategorias.GridColor =
                Color.FromArgb(230, 237, 237);
            dgvCategorias.RowTemplate.Height = 31;

            dgvCategorias.EnableHeadersVisualStyles = false;
            dgvCategorias.ColumnHeadersHeight = 40;
            dgvCategorias.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                    .DisableResizing;

            dgvCategorias.ColumnHeadersDefaultCellStyle
                .BackColor = oscuro;
            dgvCategorias.ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;
            dgvCategorias.ColumnHeadersDefaultCellStyle
                .Font = new Font(
                    "Segoe UI", 10F, FontStyle.Bold);

            dgvCategorias.DefaultCellStyle.BackColor =
                Color.White;
            dgvCategorias.DefaultCellStyle.ForeColor =
                oscuro;
            dgvCategorias.DefaultCellStyle
                .SelectionBackColor =
                Color.FromArgb(209, 237, 234);
            dgvCategorias.DefaultCellStyle
                .SelectionForeColor = oscuro;

            dgvCategorias.AlternatingRowsDefaultCellStyle
                .BackColor = Color.FromArgb(246, 250, 250);

            Controls.Add(dgvCategorias);

            // Resumen de categorías
            Panel panelResumen = new Panel();
            panelResumen.Location = new Point(35, 580);
            panelResumen.Size = new Size(1030, 103);
            panelResumen.BackColor = Color.White;
            Controls.Add(panelResumen);

            Label lblMayorTitulo = new Label();
            lblMayorTitulo.Text = "MAYOR FRECUENCIA";
            lblMayorTitulo.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            lblMayorTitulo.ForeColor = gris;
            lblMayorTitulo.Location = new Point(18, 12);
            lblMayorTitulo.AutoSize = true;
            panelResumen.Controls.Add(lblMayorTitulo);

            lblMayor = new Label();
            lblMayor.Text = "—";
            lblMayor.Font = new Font(
                "Segoe UI", 12F, FontStyle.Bold);
            lblMayor.ForeColor = turquesa;
            lblMayor.Location = new Point(18, 41);
            lblMayor.Size = new Size(480, 52);
            panelResumen.Controls.Add(lblMayor);

            Label lblMenorTitulo = new Label();
            lblMenorTitulo.Text = "MENOR FRECUENCIA";
            lblMenorTitulo.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            lblMenorTitulo.ForeColor = gris;
            lblMenorTitulo.Location = new Point(530, 12);
            lblMenorTitulo.AutoSize = true;
            panelResumen.Controls.Add(lblMenorTitulo);

            lblMenor = new Label();
            lblMenor.Text = "—";
            lblMenor.Font = new Font(
                "Segoe UI", 12F, FontStyle.Bold);
            lblMenor.ForeColor = turquesa;
            lblMenor.Location = new Point(530, 41);
            lblMenor.Size = new Size(470, 52);
            panelResumen.Controls.Add(lblMenor);

            Button btnActualizar = new Button();
            btnActualizar.Text = "ACTUALIZAR INFORME";
            btnActualizar.Location = new Point(35, 699);
            btnActualizar.Size = new Size(230, 42);
            btnActualizar.BackColor = turquesa;
            btnActualizar.ForeColor = Color.White;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Click += (s, e) => CargarInforme();
            Controls.Add(btnActualizar);

            Button btnCerrar = new Button();
            btnCerrar.Text = "CERRAR";
            btnCerrar.Location = new Point(285, 699);
            btnCerrar.Size = new Size(150, 42);
            btnCerrar.BackColor = oscuro;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.Click += (s, e) => Close();
            Controls.Add(btnCerrar);

            lblEstado = new Label();
            lblEstado.Text = "Esperando información...";
            lblEstado.ForeColor = gris;
            lblEstado.TextAlign = ContentAlignment.MiddleRight;
            lblEstado.Location = new Point(650, 699);
            lblEstado.Size = new Size(415, 42);
            Controls.Add(lblEstado);
        }

        // Crear tarjetas de información
        private void CrearTarjeta(
            string titulo, int x, int y, int ancho,
            out Label lblValor)
        {
            Panel tarjeta = new Panel();
            tarjeta.Location = new Point(x, y);
            tarjeta.Size = new Size(ancho, 105);
            tarjeta.BackColor = Color.White;
            Controls.Add(tarjeta);

            Label nombre = new Label();
            nombre.Text = titulo;
            nombre.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            nombre.ForeColor = gris;
            nombre.Location = new Point(17, 13);
            nombre.AutoSize = true;
            tarjeta.Controls.Add(nombre);

            lblValor = new Label();
            lblValor.Text = "—";
            lblValor.Font = new Font(
                "Segoe UI", 25F, FontStyle.Bold);
            lblValor.ForeColor = turquesa;
            lblValor.Location = new Point(15, 46);
            lblValor.Size = new Size(ancho - 30, 50);
            tarjeta.Controls.Add(lblValor);
        }

        // Cargar estadísticas desde Azure SQL
        private void CargarInforme()
        {
            try
            {
                using (SqlConnection conexion =
                    ConexionBD.CrearConexion())
                {
                    conexion.Open();

                    // Total de pacientes
                    using (SqlCommand comando =
                        new SqlCommand(
                            "SELECT COUNT(*) FROM dbo.Paciente",
                            conexion))
                    {
                        lblPacientes.Text =
                            Convert.ToString(
                                comando.ExecuteScalar()) ?? "0";
                    }

                    // Total de consultas
                    using (SqlCommand comando =
                        new SqlCommand(
                            "SELECT COUNT(*) FROM dbo.Consulta",
                            conexion))
                    {
                        lblConsultas.Text =
                            Convert.ToString(
                                comando.ExecuteScalar()) ?? "0";
                    }

                    // Edad promedio al 10 de noviembre de 2026
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

                        object resultado =
                            comando.ExecuteScalar();

                        if (resultado == null ||
                            resultado == DBNull.Value)
                        {
                            lblEdadPromedio.Text = "—";
                        }
                        else
                        {
                            decimal promedio =
                                Convert.ToDecimal(resultado);

                            lblEdadPromedio.Text =
                                promedio.ToString("F1") + " años";
                        }
                    }

                    // Clasificar según la consulta más reciente
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

                    DataTable tabla = new DataTable();

                    using (SqlCommand comando =
                        new SqlCommand(sqlCategorias, conexion))
                    {
                        comando.Parameters.Add(
                            "@Corte", SqlDbType.Date
                        ).Value = fechaCorte;

                        using (SqlDataAdapter adaptador =
                            new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(tabla);
                        }
                    }

                    dgvCategorias.DataSource = tabla;
                    dgvCategorias.ClearSelection();

                    CalcularFrecuencias(tabla);
                    lblEstado.Text = "Informe actualizado";
                }
            }
            catch (Exception ex)
            {
                lblPacientes.Text = "—";
                lblEdadPromedio.Text = "—";
                lblConsultas.Text = "—";
                lblMayor.Text = "—";
                lblMenor.Text = "—";
                dgvCategorias.DataSource = null;
                lblEstado.Text = "Error al actualizar";

                MessageBox.Show(
                    "No se pudo generar el informe:\n" +
                    ex.Message,
                    "Error de Azure SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Identificar categorías con mayor y menor frecuencia
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

            var mayores = frecuencias
                .Where(x => x.Cantidad == maximo)
                .Select(x => x.Nombre)
                .ToList();

            // Excluir las categorías con cero pacientes
            int minimo = frecuencias
                .Where(x => x.Cantidad > 0)
                .Min(x => x.Cantidad);

            var menores = frecuencias
                .Where(x => x.Cantidad == minimo)
                .Select(x => x.Nombre)
                .ToList();

            lblMayor.Text =
                string.Join(", ", mayores) +
                " (" + maximo + ")";

            lblMenor.Text =
                string.Join(", ", menores) +
                " (" + minimo + ")";
        }
    }
}
