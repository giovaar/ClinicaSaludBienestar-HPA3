
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public partial class frmInformeGeneral : Form
    {
        private readonly Color turquesa =
            Color.FromArgb(20, 125, 134);

        private readonly DateTime fechaCorte =
            new DateTime(2026, 11, 10);

        public frmInformeGeneral()
        {
            InitializeComponent();

            btnRecargar.Click +=
                (s, e) => CargarInforme();

            btnCerrar.Click +=
                (s, e) => Close();

            Shown += (s, e) => CargarInforme();
        }

        // OBTENER INFORME DESDE AZURE SQL
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

                    // TOTAL DE PACIENTES
                    using (SqlCommand comando =
                        new SqlCommand(
                            "SELECT COUNT(*) FROM dbo.Paciente",
                            conexion))
                    {
                        totalPacientes = Convert.ToInt32(
                            comando.ExecuteScalar());
                    }

                    // TOTAL DE CONSULTAS
                    using (SqlCommand comando =
                        new SqlCommand(
                            "SELECT COUNT(*) FROM dbo.Consulta",
                            conexion))
                    {
                        totalConsultas = Convert.ToInt32(
                            comando.ExecuteScalar());
                    }

                    // EDAD PROMEDIO EN AÑOS CUMPLIDOS
                    const string sqlEdad = @"
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
                            "@Corte",
                            SqlDbType.Date
                        ).Value = fechaCorte;

                        edadResultado =
                            comando.ExecuteScalar();
                    }

                    // ÚLTIMA CONSULTA DE CADA PACIENTE
                    const string sqlCategorias = @"
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
                            "@Corte",
                            SqlDbType.Date
                        ).Value = fechaCorte;

                        using (SqlDataAdapter adaptador =
                            new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(categorias);
                        }
                    }
                }

                // MOSTRAR ESTADÍSTICAS
                lblPacientes.Text =
                    totalPacientes.ToString();

                lblConsultas.Text =
                    totalConsultas.ToString();

                lblEdadPromedio.Text =
                    edadResultado == null ||
                    edadResultado == DBNull.Value
                        ? "—"
                        : Convert.ToDecimal(edadResultado)
                            .ToString("F1") + " años";

                // MOSTRAR TABLA
                dgvCategorias.DataSource = categorias;

                dgvCategorias.ClearSelection();

                // CATEGORÍAS MÁS Y MENOS FRECUENTES
                CalcularFrecuencias(categorias);

                lblEstado.ForeColor = turquesa;

                lblEstado.Text =
                    "Datos recargados correctamente";
            }
            catch (Exception ex)
            {
                lblEstado.ForeColor = Color.Firebrick;

                lblEstado.Text =
                    "Error al recargar datos";

                MessageBox.Show(
                    "No se pudo generar el informe:\n" +
                    ex.Message,
                    "Error de Azure SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // CALCULAR FRECUENCIAS Y EMPATES
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

            int maximo = frecuencias.Max(
                x => x.Cantidad);

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

            lblMayor.Text =
                mayores + " (" + maximo + ")";

            lblMenor.Text =
                menores + " (" + minimo + ")";
        }
    }
}
