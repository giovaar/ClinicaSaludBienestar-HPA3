
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public class frmPacientes : Form
    {
        private readonly Color oscuro = Color.FromArgb(18, 63, 73);
        private readonly Color turquesa = Color.FromArgb(20, 125, 134);
        private readonly Color fondo = Color.FromArgb(240, 247, 247);
        private readonly Color gris = Color.FromArgb(105, 127, 132);

        private TextBox txtBuscar;
        private DataGridView dgvPacientes;
        private DataGridView dgvHistorial;
        private Label lblTotalPacientes;
        private Label lblTotalConsultas;
        private Label lblHistorial;

        public frmPacientes()
        {
            Text = "Clínica Salud y Bienestar | Pacientes";
            ClientSize = new Size(1120, 750);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = fondo;
            Font = new Font("Segoe UI", 10F);

            CrearInterfaz();

            Shown += (s, e) => CargarPacientes();
        }

        // Crear el diseño del formulario
        private void CrearInterfaz()
        {
            Panel encabezado = new Panel();
            encabezado.Dock = DockStyle.Top;
            encabezado.Height = 105;
            encabezado.BackColor = oscuro;
            Controls.Add(encabezado);

            Label titulo = new Label();
            titulo.Text = "DIRECTORIO DE PACIENTES";
            titulo.Font = new Font(
                "Segoe UI", 21F, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.Location = new Point(35, 20);
            titulo.AutoSize = true;
            encabezado.Controls.Add(titulo);

            Label subtitulo = new Label();
            subtitulo.Text =
                "Gestión clínica • Información e historial";
            subtitulo.Font = new Font("Segoe UI", 10F);
            subtitulo.ForeColor =
                Color.FromArgb(183, 222, 220);
            subtitulo.Location = new Point(38, 67);
            subtitulo.AutoSize = true;
            encabezado.Controls.Add(subtitulo);

            // Indicadores
            CrearTarjeta("PACIENTES", 35, 125,
                out lblTotalPacientes);

            CrearTarjeta("CONSULTAS", 315, 125,
                out lblTotalConsultas);

            // Buscar pacientes
            Label lblBuscar = new Label();
            lblBuscar.Text = "Buscar paciente";
            lblBuscar.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            lblBuscar.ForeColor = oscuro;
            lblBuscar.Location = new Point(35, 220);
            lblBuscar.AutoSize = true;
            Controls.Add(lblBuscar);

            txtBuscar = new TextBox();
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Font = new Font("Segoe UI", 12F);
            txtBuscar.Location = new Point(35, 252);
            txtBuscar.Size = new Size(640, 34);
            txtBuscar.PlaceholderText =
                "Escribe un nombre o apellido...";
            txtBuscar.TextChanged += (s, e) =>
                CargarPacientes();
            Controls.Add(txtBuscar);

            Button btnActualizar = CrearBoton(
                "ACTUALIZAR", 702, 249, 160);
            btnActualizar.Click += (s, e) =>
                CargarPacientes();
            Controls.Add(btnActualizar);

            Button btnCerrar = CrearBoton(
                "CERRAR", 885, 249, 185);
            btnCerrar.BackColor = oscuro;
            btnCerrar.Click += (s, e) => Close();
            Controls.Add(btnCerrar);

            // Tabla de pacientes
            dgvPacientes = CrearTabla();
            dgvPacientes.Name = "dgvPacientes";
            dgvPacientes.Location = new Point(35, 310);
            dgvPacientes.Size = new Size(1035, 205);
            dgvPacientes.SelectionChanged +=
                dgvPacientes_SelectionChanged;
            Controls.Add(dgvPacientes);

            // Historial del paciente
            lblHistorial = new Label();
            lblHistorial.Text =
                "HISTORIAL DE CONSULTAS";
            lblHistorial.Font = new Font(
                "Segoe UI", 13F, FontStyle.Bold);
            lblHistorial.ForeColor = oscuro;
            lblHistorial.Location = new Point(35, 537);
            lblHistorial.Size = new Size(1020, 30);
            Controls.Add(lblHistorial);

            dgvHistorial = CrearTabla();
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.Location = new Point(35, 577);
            dgvHistorial.Size = new Size(1035, 120);
            Controls.Add(dgvHistorial);

            Label pie = new Label();
            pie.Text =
                "Clínica Salud y Bienestar  •  HPA III  •  Grupo 1";
            pie.Font = new Font("Segoe UI", 9F);
            pie.ForeColor = gris;
            pie.Location = new Point(37, 715);
            pie.AutoSize = true;
            Controls.Add(pie);
        }

        // Crear tarjetas de estadísticas
        private void CrearTarjeta(
            string texto, int x, int y,
            out Label lblCantidad)
        {
            Panel tarjeta = new Panel();
            tarjeta.BackColor = Color.White;
            tarjeta.Location = new Point(x, y);
            tarjeta.Size = new Size(255, 76);
            Controls.Add(tarjeta);

            Label nombre = new Label();
            nombre.Text = texto;
            nombre.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            nombre.ForeColor = gris;
            nombre.Location = new Point(15, 10);
            nombre.AutoSize = true;
            tarjeta.Controls.Add(nombre);

            lblCantidad = new Label();
            lblCantidad.Text = "—";
            lblCantidad.Font = new Font(
                "Segoe UI", 22F, FontStyle.Bold);
            lblCantidad.ForeColor = turquesa;
            lblCantidad.Location = new Point(13, 30);
            lblCantidad.Size = new Size(200, 42);
            tarjeta.Controls.Add(lblCantidad);
        }

        // Crear botones
        private Button CrearBoton(
            string texto, int x, int y, int ancho)
        {
            Button boton = new Button();
            boton.Text = texto;
            boton.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            boton.ForeColor = Color.White;
            boton.BackColor = turquesa;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Cursor = Cursors.Hand;
            boton.Location = new Point(x, y);
            boton.Size = new Size(ancho, 40);
            return boton;
        }

        // Crear tablas con estilo personalizado
        private DataGridView CrearTabla()
        {
            DataGridView tabla = new DataGridView();

            tabla.ReadOnly = true;
            tabla.AllowUserToAddRows = false;
            tabla.AllowUserToDeleteRows = false;
            tabla.AllowUserToResizeRows = false;
            tabla.MultiSelect = false;
            tabla.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            tabla.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            tabla.BackgroundColor = Color.White;
            tabla.BorderStyle = BorderStyle.None;
            tabla.RowHeadersVisible = false;
            tabla.GridColor = Color.FromArgb(230, 237, 237);
            tabla.RowTemplate.Height = 32;

            tabla.EnableHeadersVisualStyles = false;

            tabla.ColumnHeadersHeight = 40;
            tabla.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            tabla.ColumnHeadersDefaultCellStyle.BackColor =
                oscuro;
            tabla.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            tabla.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            tabla.DefaultCellStyle.BackColor = Color.White;
            tabla.DefaultCellStyle.ForeColor = oscuro;
            tabla.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F);

            tabla.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(209, 237, 234);
            tabla.DefaultCellStyle.SelectionForeColor =
                oscuro;

            tabla.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(246, 250, 250);

            return tabla;
        }

        // Cargar pacientes desde Azure SQL
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
                            "@Buscar", SqlDbType.NVarChar, 150
                        ).Value = "%" + txtBuscar.Text.Trim() + "%";

                        DataTable datos = new DataTable();

                        using (SqlDataAdapter adaptador =
                            new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(datos);
                        }

                        dgvPacientes.DataSource = datos;
                    }

                    using (SqlCommand comando =
                        new SqlCommand(
                            "SELECT COUNT(*) FROM dbo.Paciente",
                            conexion))
                    {
                        lblTotalPacientes.Text =
                            Convert.ToString(
                                comando.ExecuteScalar());
                    }

                    using (SqlCommand comando =
                        new SqlCommand(
                            "SELECT COUNT(*) FROM dbo.Consulta",
                            conexion))
                    {
                        lblTotalConsultas.Text =
                            Convert.ToString(
                                comando.ExecuteScalar());
                    }
                }

                dgvPacientes.ClearSelection();

                dgvHistorial.DataSource = null;
                lblHistorial.Text =
                    "HISTORIAL DE CONSULTAS";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los pacientes:\n" +
                    ex.Message,
                    "Error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Mostrar consultas del paciente seleccionado
        private void dgvPacientes_SelectionChanged(
            object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
                return;

            if (dgvPacientes.SelectedRows[0]
                .Cells["ID"].Value == null)
                return;

            int pacienteId = Convert.ToInt32(
                dgvPacientes.SelectedRows[0]
                    .Cells["ID"].Value);

            string nombre = Convert.ToString(
                dgvPacientes.SelectedRows[0]
                    .Cells["Nombre"].Value) ?? "";

            string apellido = Convert.ToString(
                dgvPacientes.SelectedRows[0]
                    .Cells["Apellido"].Value) ?? "";

            CargarHistorial(pacienteId, nombre + " " + apellido);
        }

        // Consultar historial de peso e IMC
        private void CargarHistorial(
            int pacienteId, string paciente)
        {
            try
            {
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
                        ORDER BY c.Fecha ASC, c.ConsultaId ASC;";

                    using (SqlCommand comando =
                        new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(
                            "@PacienteId", SqlDbType.Int
                        ).Value = pacienteId;

                        DataTable datos = new DataTable();

                        using (SqlDataAdapter adaptador =
                            new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(datos);
                        }

                        dgvHistorial.DataSource = datos;
                    }
                }

                lblHistorial.Text =
                    "HISTORIAL DE CONSULTAS — " + paciente;

                dgvHistorial.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el historial:\n" +
                    ex.Message,
                    "Error de consultas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
