
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

        private TextBox txtBuscar = null!;
        private DataGridView dgvPacientes = null!;
        private DataGridView dgvHistorial = null!;
        private Label lblPacientes = null!;
        private Label lblConsultas = null!;
        private Label lblHistorial = null!;
        private Label lblEstado = null!;

        private bool cargando = false;

        public frmPacientes()
        {
            Text = "Clínica Salud y Bienestar | Pacientes";
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
            principal.Padding = new Padding(18, 0, 18, 10);
            principal.BackColor = fondo;

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 95));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 112));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 92));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Percent, 55));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 38));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Percent, 45));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 45));

            Controls.Add(principal);

            // Encabezado
            Panel encabezado = new Panel();
            encabezado.Dock = DockStyle.Fill;
            encabezado.BackColor = oscuro;
            encabezado.Margin = new Padding(0, 0, 0, 5);

            Label titulo = new Label();
            titulo.Text = "DIRECTORIO DE PACIENTES";
            titulo.Font = new Font(
                "Segoe UI", 22F, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.Location = new Point(22, 10);
            titulo.AutoSize = true;
            encabezado.Controls.Add(titulo);

            Label subtitulo = new Label();
            subtitulo.Text =
                "Gestión clínica • Información e historial";
            subtitulo.ForeColor = Color.LightCyan;
            subtitulo.Location = new Point(25, 60);
            subtitulo.AutoSize = true;
            encabezado.Controls.Add(subtitulo);

            principal.Controls.Add(encabezado, 0, 0);

            // Tarjetas
            TableLayoutPanel tarjetas = new TableLayoutPanel();
            tarjetas.Dock = DockStyle.Fill;
            tarjetas.ColumnCount = 2;
            tarjetas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50));
            tarjetas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50));

            CrearTarjeta(
                tarjetas, "PACIENTES REGISTRADOS",
                0, out lblPacientes);

            CrearTarjeta(
                tarjetas, "CONSULTAS REGISTRADAS",
                1, out lblConsultas);

            principal.Controls.Add(tarjetas, 0, 1);

            // Barra de búsqueda
            TableLayoutPanel filtros = new TableLayoutPanel();
            filtros.Dock = DockStyle.Fill;
            filtros.ColumnCount = 3;
            filtros.RowCount = 2;
            filtros.Padding = new Padding(4, 8, 4, 8);

            filtros.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));
            filtros.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 210));
            filtros.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 145));

            filtros.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 28));
            filtros.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            Label lblBuscar = new Label();
            lblBuscar.Text = "BUSCAR PACIENTE";
            lblBuscar.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            lblBuscar.ForeColor = oscuro;
            lblBuscar.Dock = DockStyle.Fill;
            filtros.Controls.Add(lblBuscar, 0, 0);

            txtBuscar = new TextBox();
            txtBuscar.Dock = DockStyle.Fill;
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.PlaceholderText =
                "Escribe un nombre o apellido...";
            txtBuscar.Margin = new Padding(0, 0, 12, 4);
            txtBuscar.TextChanged += (s, e) =>
                CargarPacientes();

            filtros.Controls.Add(txtBuscar, 0, 1);

            Button btnRecargar = CrearBoton(
                "RECARGAR DATOS", turquesa);
            btnRecargar.Click += (s, e) =>
                CargarPacientes();
            filtros.Controls.Add(btnRecargar, 1, 1);

            Button btnCerrar = CrearBoton(
                "CERRAR", oscuro);
            btnCerrar.Click += (s, e) => Close();
            filtros.Controls.Add(btnCerrar, 2, 1);

            principal.Controls.Add(filtros, 0, 2);

            // Tabla principal de pacientes
            dgvPacientes = CrearTabla();
            dgvPacientes.Dock = DockStyle.Fill;
            dgvPacientes.Margin = new Padding(4, 4, 4, 8);

            dgvPacientes.SelectionChanged +=
                dgvPacientes_SelectionChanged;

            principal.Controls.Add(dgvPacientes, 0, 3);

            // Título del historial
            lblHistorial = new Label();
            lblHistorial.Text = "HISTORIAL DE CONSULTAS";
            lblHistorial.Font = new Font(
                "Segoe UI", 13F, FontStyle.Bold);
            lblHistorial.ForeColor = oscuro;
            lblHistorial.Dock = DockStyle.Fill;
            lblHistorial.Padding = new Padding(6, 6, 0, 0);

            principal.Controls.Add(lblHistorial, 0, 4);

            // Tabla inferior, adaptable
            dgvHistorial = CrearTabla();
            dgvHistorial.Dock = DockStyle.Fill;
            dgvHistorial.Margin = new Padding(4, 0, 4, 6);

            principal.Controls.Add(dgvHistorial, 0, 5);

            // Estado inferior
            lblEstado = new Label();
            lblEstado.Text = "Esperando información...";
            lblEstado.ForeColor = gris;
            lblEstado.Dock = DockStyle.Fill;
            lblEstado.TextAlign = ContentAlignment.MiddleLeft;
            lblEstado.Padding = new Padding(8, 0, 0, 0);

            principal.Controls.Add(lblEstado, 0, 6);
        }

        // Crear tarjeta
        private void CrearTarjeta(
            TableLayoutPanel contenedor,
            string titulo,
            int columna,
            out Label valor)
        {
            Panel tarjeta = new Panel();
            tarjeta.Dock = DockStyle.Fill;
            tarjeta.BackColor = Color.White;
            tarjeta.Margin = new Padding(4, 10, 8, 10);

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
                "Segoe UI", 25F, FontStyle.Bold);
            valor.ForeColor = turquesa;
            valor.Location = new Point(16, 42);
            valor.Size = new Size(290, 49);
            tarjeta.Controls.Add(valor);

            contenedor.Controls.Add(tarjeta, columna, 0);
        }

        // Crear botón
        private Button CrearBoton(string texto, Color color)
        {
            Button boton = new Button();
            boton.Text = texto;
            boton.Dock = DockStyle.Fill;
            boton.BackColor = color;
            boton.ForeColor = Color.White;
            boton.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Cursor = Cursors.Hand;
            boton.Margin = new Padding(5, 0, 8, 4);
            return boton;
        }

        // Crear tabla
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

            tabla.ScrollBars = ScrollBars.Both;
            tabla.BackgroundColor = Color.White;
            tabla.BorderStyle = BorderStyle.None;
            tabla.RowHeadersVisible = false;
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

        // Cargar pacientes
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
                            "@Buscar", SqlDbType.NVarChar, 150
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
                    dgvPacientes.Columns["FechaNacimiento"]
                        .HeaderText = "Fecha de nacimiento";

                    dgvPacientes.Columns["FechaNacimiento"]
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
                    datos.Rows.Count + " pacientes mostrados";
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
        }

        // Seleccionar paciente
        private void dgvPacientes_SelectionChanged(
            object? sender, EventArgs e)
        {
            if (cargando ||
                dgvPacientes.SelectedRows.Count == 0)
                return;

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
                pacienteId, nombre + " " + apellido);
        }

        // Cargar historial del paciente
        private void CargarHistorial(
            int pacienteId, string paciente)
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
                            adaptador.Fill(datos);
                        }
                    }
                }

                dgvHistorial.DataSource = datos;

                if (dgvHistorial.Columns.Contains("Fecha"))
                {
                    dgvHistorial.Columns["Fecha"]
                        .DefaultCellStyle.Format =
                        "dd/MM/yyyy";
                }

                if (dgvHistorial.Columns.Contains("Peso"))
                {
                    dgvHistorial.Columns["Peso"]
                        .DefaultCellStyle.Format = "N2";
                }

                if (dgvHistorial.Columns.Contains("Estatura"))
                {
                    dgvHistorial.Columns["Estatura"]
                        .DefaultCellStyle.Format = "N2";
                }

                if (dgvHistorial.Columns.Contains("IMC"))
                {
                    dgvHistorial.Columns["IMC"]
                        .DefaultCellStyle.Format = "N1";
                }

                dgvHistorial.ClearSelection();

                lblHistorial.Text =
                    "HISTORIAL DE CONSULTAS — " + paciente;

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
