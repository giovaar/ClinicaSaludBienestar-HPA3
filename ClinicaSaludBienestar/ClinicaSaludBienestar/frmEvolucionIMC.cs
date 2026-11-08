
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

        private ComboBox cmbPacientes;
        private Label lblInicial, lblActual, lblTendencia;
        private Label lblCategoria;
        private DataGridView dgvConsultas;
        private Panel panelGrafico;

        private List<PuntoIMC> puntos = new List<PuntoIMC>();

        private class PuntoIMC
        {
            public DateTime Fecha { get; set; }
            public decimal IMC { get; set; }
        }

        public frmEvolucionIMC()
        {
            Text = "Clínica Salud y Bienestar | Evolución del IMC";
            ClientSize = new Size(1100, 760);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = fondo;
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1000, 700);

            CrearInterfaz();

            Shown += (s, e) => CargarPacientes();
        }

        // Crear diseño de evolución del IMC
        private void CrearInterfaz()
        {
            Panel encabezado = new Panel();
            encabezado.Dock = DockStyle.Top;
            encabezado.Height = 100;
            encabezado.BackColor = oscuro;
            Controls.Add(encabezado);

            Label titulo = new Label();
            titulo.Text = "EVOLUCIÓN DEL IMC";
            titulo.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.Location = new Point(35, 16);
            titulo.AutoSize = true;
            encabezado.Controls.Add(titulo);

            Label subtitulo = new Label();
            subtitulo.Text = "Seguimiento histórico de pacientes";
            subtitulo.ForeColor = Color.LightCyan;
            subtitulo.Location = new Point(38, 67);
            subtitulo.AutoSize = true;
            encabezado.Controls.Add(subtitulo);

            Label lblSeleccion = new Label();
            lblSeleccion.Text = "SELECCIONAR PACIENTE";
            lblSeleccion.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            lblSeleccion.ForeColor = oscuro;
            lblSeleccion.Location = new Point(35, 125);
            lblSeleccion.AutoSize = true;
            Controls.Add(lblSeleccion);

            cmbPacientes = new ComboBox();
            cmbPacientes.Name = "cmbPacientes";
            cmbPacientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPacientes.Font = new Font("Segoe UI", 11F);
            cmbPacientes.Location = new Point(35, 157);
            cmbPacientes.Size = new Size(530, 34);
            cmbPacientes.SelectedIndexChanged += (s, e) =>
            {
                if (cmbPacientes.SelectedValue is int id)
                    CargarEvolucion(id);
            };
            Controls.Add(cmbPacientes);

            Button btnActualizar = new Button();
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Location = new Point(590, 153);
            btnActualizar.Size = new Size(160, 42);
            btnActualizar.BackColor = turquesa;
            btnActualizar.ForeColor = Color.White;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Click += (s, e) => CargarPacientes();
            Controls.Add(btnActualizar);

            Button btnCerrar = new Button();
            btnCerrar.Text = "CERRAR";
            btnCerrar.Location = new Point(770, 153);
            btnCerrar.Size = new Size(160, 42);
            btnCerrar.BackColor = oscuro;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Click += (s, e) => Close();
            Controls.Add(btnCerrar);

            CrearTarjeta("IMC INICIAL", 35, out lblInicial);
            CrearTarjeta("IMC ACTUAL", 385, out lblActual);
            CrearTarjeta("TENDENCIA", 735, out lblTendencia);

            lblCategoria = new Label();
            lblCategoria.Text = "Categoría actual: —";
            lblCategoria.Font = new Font(
                "Segoe UI", 12F, FontStyle.Bold);
            lblCategoria.ForeColor = oscuro;
            lblCategoria.Location = new Point(35, 325);
            lblCategoria.Size = new Size(1000, 35);
            Controls.Add(lblCategoria);

            Label lblGrafico = new Label();
            lblGrafico.Text = "GRÁFICO DE EVOLUCIÓN";
            lblGrafico.Font = new Font(
                "Segoe UI", 12F, FontStyle.Bold);
            lblGrafico.ForeColor = oscuro;
            lblGrafico.Location = new Point(35, 365);
            lblGrafico.AutoSize = true;
            Controls.Add(lblGrafico);

            panelGrafico = new Panel();
            panelGrafico.Location = new Point(35, 402);
            panelGrafico.Size = new Size(1020, 170);
            panelGrafico.BackColor = Color.White;
            panelGrafico.Paint += DibujarGrafico;
            Controls.Add(panelGrafico);

            Label lblTabla = new Label();
            lblTabla.Text = "HISTORIAL DE CONSULTAS";
            lblTabla.Font = new Font(
                "Segoe UI", 12F, FontStyle.Bold);
            lblTabla.ForeColor = oscuro;
            lblTabla.Location = new Point(35, 593);
            lblTabla.AutoSize = true;
            Controls.Add(lblTabla);

            dgvConsultas = new DataGridView();
            dgvConsultas.Location = new Point(35, 625);
            dgvConsultas.Size = new Size(1020, 105);
            dgvConsultas.ReadOnly = true;
            dgvConsultas.AllowUserToAddRows = false;
            dgvConsultas.AllowUserToDeleteRows = false;
            dgvConsultas.RowHeadersVisible = false;
            dgvConsultas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvConsultas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvConsultas.BackgroundColor = Color.White;
            dgvConsultas.BorderStyle = BorderStyle.None;
            dgvConsultas.EnableHeadersVisualStyles = false;
            dgvConsultas.ColumnHeadersDefaultCellStyle.BackColor =
                oscuro;
            dgvConsultas.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            dgvConsultas.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(209, 237, 234);
            dgvConsultas.DefaultCellStyle.SelectionForeColor =
                oscuro;
            Controls.Add(dgvConsultas);
        }

        // Crear tarjetas de resultados
        private void CrearTarjeta(
            string titulo, int x, out Label valor)
        {
            Panel tarjeta = new Panel();
            tarjeta.Location = new Point(x, 220);
            tarjeta.Size = new Size(315, 90);
            tarjeta.BackColor = Color.White;
            Controls.Add(tarjeta);

            Label nombre = new Label();
            nombre.Text = titulo;
            nombre.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            nombre.ForeColor = Color.Gray;
            nombre.Location = new Point(15, 12);
            nombre.AutoSize = true;
            tarjeta.Controls.Add(nombre);

            valor = new Label();
            valor.Text = "—";
            valor.Font = new Font(
                "Segoe UI", 21F, FontStyle.Bold);
            valor.ForeColor = turquesa;
            valor.Location = new Point(15, 38);
            valor.Size = new Size(280, 43);
            tarjeta.Controls.Add(valor);
        }

        // Consultar pacientes de Azure SQL
        private void CargarPacientes()
        {
            try
            {
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
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        cmbPacientes.DataSource = null;
                        cmbPacientes.DisplayMember = "Paciente";
                        cmbPacientes.ValueMember = "PacienteId";
                        cmbPacientes.DataSource = tabla;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar pacientes:\n" + ex.Message,
                    "Azure SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Consultar historial de IMC
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
                        ORDER BY c.Fecha, c.ConsultaId;";

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
                    panelGrafico.Invalidate();
                    return;
                }

                decimal inicial = puntos[0].IMC;
                decimal actual = puntos[puntos.Count - 1].IMC;
                decimal diferencia = actual - inicial;

                lblInicial.Text = inicial.ToString("F1");
                lblActual.Text = actual.ToString("F1");

                if (puntos.Count < 2)
                {
                    lblTendencia.Text = "Sin tendencia";
                }
                else if (diferencia > 0.5m)
                {
                    lblTendencia.Text = "Sube";
                }
                else if (diferencia < -0.5m)
                {
                    lblTendencia.Text = "Baja";
                }
                else
                {
                    lblTendencia.Text = "Estable";
                }

                lblCategoria.Text =
                    "Categoría actual: " +
                    Convert.ToString(
                        tabla.Rows[tabla.Rows.Count - 1]["Categoria"]);

                panelGrafico.Invalidate();
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

                MessageBox.Show(
                    "Error al consultar evolución:\n" + ex.Message,
                    "Azure SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Dibujar gráfico sin paquetes adicionales
        private void DibujarGrafico(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (puntos.Count == 0)
            {
                g.DrawString(
                    "Selecciona un paciente con consultas.",
                    Font, Brushes.Gray, 25, 65);
                return;
            }

            int izquierda = 65;
            int derecha = panelGrafico.Width - 55;
            int arriba = 30;
            int abajo = panelGrafico.Height - 45;

            decimal minimo = puntos[0].IMC;
            decimal maximo = puntos[0].IMC;

            foreach (PuntoIMC punto in puntos)
            {
                if (punto.IMC < minimo) minimo = punto.IMC;
                if (punto.IMC > maximo) maximo = punto.IMC;
            }

            // Margen vertical para que no se corte la línea
            minimo -= 1m;
            maximo += 1m;

            using (Pen eje = new Pen(Color.LightGray, 1))
            {
                g.DrawLine(eje, izquierda, abajo, derecha, abajo);
                g.DrawLine(eje, izquierda, arriba, izquierda, abajo);
            }

            PointF? anterior = null;

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
                    using (Pen linea = new Pen(turquesa, 3))
                    {
                        g.DrawLine(linea, anterior.Value, actual);
                    }
                }

                using (Brush marcador = new SolidBrush(turquesa))
                {
                    g.FillEllipse(marcador, x - 5, y - 5, 10, 10);
                }

                using (Font fuente = new Font("Segoe UI", 9F))
                {
                    string valor = puntos[i].IMC.ToString("F1");
                    string fecha = puntos[i].Fecha.ToString("dd/MM");

                    SizeF anchoValor = g.MeasureString(valor, fuente);
                    SizeF anchoFecha = g.MeasureString(fecha, fuente);

                    g.DrawString(
                        valor, fuente, Brushes.DarkSlateGray,
                        x - anchoValor.Width / 2, y - 25);

                    g.DrawString(
                        fecha, fuente, Brushes.Gray,
                        x - anchoFecha.Width / 2, abajo + 10);
                }

                anterior = actual;
            }
        }
    }
}
