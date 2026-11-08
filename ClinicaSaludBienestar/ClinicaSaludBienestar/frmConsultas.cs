
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public class frmConsultas : Form
    {
        private readonly Color oscuro = Color.FromArgb(18, 63, 73);
        private readonly Color turquesa = Color.FromArgb(20, 125, 134);
        private readonly Color fondo = Color.FromArgb(240, 247, 247);
        private readonly Color gris = Color.FromArgb(105, 127, 132);

        private ComboBox cmbPacientes = null!;
        private TextBox txtBuscar = null!;
        private DataGridView dgvConsultas = null!;

        private Label lblTotal = null!;
        private Label lblMostradas = null!;
        private Label lblIMC = null!;
        private Label lblCategoria = null!;
        private Label lblDetalle = null!;
        private Label lblEstado = null!;

        private bool cargando = false;

        public frmConsultas()
        {
            Text = "Clínica Salud y Bienestar | Consultas";
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
                new RowStyle(SizeType.Absolute, 40));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 105));
            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 50));

            Controls.Add(principal);

            // Encabezado
            Panel encabezado = new Panel();
            encabezado.Dock = DockStyle.Fill;
            encabezado.BackColor = oscuro;
            encabezado.Margin = new Padding(0, 0, 0, 5);

            Label titulo = new Label();
            titulo.Text = "REGISTRO DE CONSULTAS";
            titulo.Font = new Font(
                "Segoe UI", 22F, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.Location = new Point(22, 10);
            titulo.AutoSize = true;
            encabezado.Controls.Add(titulo);

            Label subtitulo = new Label();
            subtitulo.Text =
                "Historial clínico • Mediciones y clasificación IMC";
            subtitulo.ForeColor = Color.LightCyan;
            subtitulo.Location = new Point(25, 60);
            subtitulo.AutoSize = true;
            encabezado.Controls.Add(subtitulo);

            principal.Controls.Add(encabezado, 0, 0);

            // Tarjetas superiores
            TableLayoutPanel tarjetas = new TableLayoutPanel();
            tarjetas.Dock = DockStyle.Fill;
            tarjetas.ColumnCount = 3;
            tarjetas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33.33F));
            tarjetas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33.33F));
            tarjetas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33.34F));

            CrearTarjeta(
                tarjetas, "TOTAL DE CONSULTAS",
                0, out lblTotal);

            CrearTarjeta(
                tarjetas, "CONSULTAS MOSTRADAS",
                1, out lblMostradas);

            CrearTarjeta(
                tarjetas, "IMC SELECCIONADO",
                2, out lblIMC);

            principal.Controls.Add(tarjetas, 0, 1);

            // Filtros
            TableLayoutPanel filtros = new TableLayoutPanel();
            filtros.Dock = DockStyle.Fill;
            filtros.ColumnCount = 3;
            filtros.RowCount = 2;
            filtros.Padding = new Padding(4, 7, 4, 7);

            filtros.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 52));
            filtros.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 30));
            filtros.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 18));

            filtros.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 28));
            filtros.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            Label lblPaciente = new Label();
            lblPaciente.Text = "FILTRAR POR PACIENTE";
            lblPaciente.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            lblPaciente.ForeColor = oscuro;
            lblPaciente.Dock = DockStyle.Fill;
            filtros.Controls.Add(lblPaciente, 0, 0);

            Label lblBuscar = new Label();
            lblBuscar.Text = "BUSCAR POR NOMBRE";
            lblBuscar.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            lblBuscar.ForeColor = oscuro;
            lblBuscar.Dock = DockStyle.Fill;
            filtros.Controls.Add(lblBuscar, 1, 0);

            cmbPacientes = new ComboBox();
            cmbPacientes.Dock = DockStyle.Fill;
            cmbPacientes.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbPacientes.Font = new Font("Segoe UI", 11F);
            cmbPacientes.Margin = new Padding(0, 0, 12, 4);
            cmbPacientes.SelectedIndexChanged +=
                (s, e) => CargarConsultas();
            filtros.Controls.Add(cmbPacientes, 0, 1);

            txtBuscar = new TextBox();
            txtBuscar.Dock = DockStyle.Fill;
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.PlaceholderText = "Nombre o apellido...";
            txtBuscar.Margin = new Padding(0, 0, 12, 4);
            txtBuscar.TextChanged +=
                (s, e) => CargarConsultas();
            filtros.Controls.Add(txtBuscar, 1, 1);

            Button btnRecargar = CrearBoton(
                "RECARGAR DATOS", turquesa);
            btnRecargar.Click +=
                (s, e) => CargarConsultas();
            filtros.Controls.Add(btnRecargar, 2, 1);

            principal.Controls.Add(filtros, 0, 2);

            // Título de la tabla
            Label lblHistorial = new Label();
            lblHistorial.Text = "HISTORIAL DE CONSULTAS";
            lblHistorial.Font = new Font(
                "Segoe UI", 13F, FontStyle.Bold);
            lblHistorial.ForeColor = oscuro;
            lblHistorial.Dock = DockStyle.Fill;
            lblHistorial.Padding = new Padding(6, 7, 0, 0);

            principal.Controls.Add(lblHistorial, 0, 3);

            // Tabla adaptable
            dgvConsultas = CrearTabla();
            dgvConsultas.Dock = DockStyle.Fill;
            dgvConsultas.Margin = new Padding(4, 0, 4, 10);
            dgvConsultas.SelectionChanged +=
                dgvConsultas_SelectionChanged;

            principal.Controls.Add(dgvConsultas, 0, 4);

            // Información de la consulta seleccionada
            Panel panelDetalle = new Panel();
            panelDetalle.Dock = DockStyle.Fill;
            panelDetalle.BackColor = Color.White;
            panelDetalle.Margin = new Padding(4, 0, 4, 8);

            lblDetalle = new Label();
            lblDetalle.Text = "Selecciona una consulta";
            lblDetalle.Font = new Font(
                "Segoe UI", 12F, FontStyle.Bold);
            lblDetalle.ForeColor = oscuro;
            lblDetalle.Location = new Point(18, 12);
            lblDetalle.Size = new Size(900, 32);
            lblDetalle.Anchor =
                AnchorStyles.Top | AnchorStyles.Left |
                AnchorStyles.Right;
            panelDetalle.Controls.Add(lblDetalle);

            lblCategoria = new Label();
            lblCategoria.Text = "Categoría IMC: —";
            lblCategoria.Font = new Font("Segoe UI", 11F);
            lblCategoria.ForeColor = turquesa;
            lblCategoria.Location = new Point(18, 52);
            lblCategoria.Size = new Size(900, 28);
            lblCategoria.Anchor =
                AnchorStyles.Top | AnchorStyles.Left |
                AnchorStyles.Right;
            panelDetalle.Controls.Add(lblCategoria);

            principal.Controls.Add(panelDetalle, 0, 5);

            // Barra inferior
            TableLayoutPanel acciones = new TableLayoutPanel();
            acciones.Dock = DockStyle.Fill;
            acciones.ColumnCount = 2;
            acciones.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 160));
            acciones.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            Button btnCerrar = CrearBoton("CERRAR", oscuro);
            btnCerrar.Click += (s, e) => Close();
            acciones.Controls.Add(btnCerrar, 0, 0);

            lblEstado = new Label();
            lblEstado.Text = "Esperando información...";
            lblEstado.ForeColor = gris;
            lblEstado.Dock = DockStyle.Fill;
            lblEstado.TextAlign =
                ContentAlignment.MiddleRight;
            lblEstado.Padding = new Padding(0, 0, 10, 0);
            acciones.Controls.Add(lblEstado, 1, 0);

            principal.Controls.Add(acciones, 0, 6);
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
            valor.Size = new Size(285, 49);
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

        // Cargar pacientes para filtro
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
                            Nombre + N' ' + Apellido AS Paciente
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

        // Cargar consultas desde Azure SQL
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
                            "@PacienteId", SqlDbType.Int
                        ).Value = pacienteId;

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
                            "SELECT COUNT(*) FROM dbo.Consulta",
                            conexion))
                    {
                        total = Convert.ToInt32(
                            comando.ExecuteScalar());
                    }
                }

                dgvConsultas.DataSource = datos;

                if (dgvConsultas.Columns.Contains("Fecha"))
                {
                    dgvConsultas.Columns["Fecha"]
                        .DefaultCellStyle.Format =
                        "dd/MM/yyyy";
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

        // Consulta seleccionada
        private void dgvConsultas_SelectionChanged(
            object? sender, EventArgs e)
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
