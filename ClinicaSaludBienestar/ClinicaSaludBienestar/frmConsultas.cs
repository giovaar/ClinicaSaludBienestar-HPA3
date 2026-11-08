
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

        private ComboBox cmbPacientes;
        private TextBox txtBuscar;
        private DataGridView dgvConsultas;

        private Label lblTotal;
        private Label lblMostradas;
        private Label lblIMC;
        private Label lblCategoria;
        private Label lblDetalle;
        private Label lblEstado;

        public frmConsultas()
        {
            Text = "Clínica Salud y Bienestar | Consultas";
            ClientSize = new Size(1120, 750);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = fondo;
            Font = new Font("Segoe UI", 10F);

            CrearInterfaz();

            Shown += (s, e) => CargarPacientes();
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
            titulo.Text = "REGISTRO DE CONSULTAS";
            titulo.Font = new Font(
                "Segoe UI", 22F, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.Location = new Point(35, 15);
            titulo.AutoSize = true;
            encabezado.Controls.Add(titulo);

            Label subtitulo = new Label();
            subtitulo.Text =
                "Historial clínico • Mediciones y clasificación IMC";
            subtitulo.ForeColor = Color.LightCyan;
            subtitulo.Location = new Point(38, 69);
            subtitulo.AutoSize = true;
            encabezado.Controls.Add(subtitulo);

            // Tarjetas
            CrearTarjeta(
                "TOTAL DE CONSULTAS",
                35, 128, out lblTotal);

            CrearTarjeta(
                "CONSULTAS MOSTRADAS",
                385, 128, out lblMostradas);

            CrearTarjeta(
                "IMC SELECCIONADO",
                735, 128, out lblIMC);

            // Filtros
            Label lblPaciente = new Label();
            lblPaciente.Text = "FILTRAR POR PACIENTE";
            lblPaciente.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            lblPaciente.ForeColor = oscuro;
            lblPaciente.Location = new Point(35, 250);
            lblPaciente.AutoSize = true;
            Controls.Add(lblPaciente);

            cmbPacientes = new ComboBox();
            cmbPacientes.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbPacientes.Location = new Point(35, 280);
            cmbPacientes.Size = new Size(455, 33);
            cmbPacientes.Font = new Font("Segoe UI", 11F);
            cmbPacientes.SelectedIndexChanged += (s, e) =>
                CargarConsultas();
            Controls.Add(cmbPacientes);

            Label lblBuscar = new Label();
            lblBuscar.Text = "BUSCAR POR NOMBRE";
            lblBuscar.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            lblBuscar.ForeColor = oscuro;
            lblBuscar.Location = new Point(510, 250);
            lblBuscar.AutoSize = true;
            Controls.Add(lblBuscar);

            txtBuscar = new TextBox();
            txtBuscar.Location = new Point(510, 280);
            txtBuscar.Size = new Size(315, 34);
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.PlaceholderText =
                "Nombre o apellido...";
            txtBuscar.TextChanged += (s, e) =>
                CargarConsultas();
            Controls.Add(txtBuscar);

            Button btnActualizar = CrearBoton(
                "ACTUALIZAR", 845, 277, 225, turquesa);
            btnActualizar.Click += (s, e) =>
                CargarConsultas();
            Controls.Add(btnActualizar);

            // Tabla de consultas
            Label lblHistorial = new Label();
            lblHistorial.Text = "HISTORIAL DE CONSULTAS";
            lblHistorial.Font = new Font(
                "Segoe UI", 13F, FontStyle.Bold);
            lblHistorial.ForeColor = oscuro;
            lblHistorial.Location = new Point(35, 340);
            lblHistorial.AutoSize = true;
            Controls.Add(lblHistorial);

            dgvConsultas = new DataGridView();
            dgvConsultas.Location = new Point(35, 382);
            dgvConsultas.Size = new Size(1035, 210);
            dgvConsultas.ReadOnly = true;
            dgvConsultas.AllowUserToAddRows = false;
            dgvConsultas.AllowUserToDeleteRows = false;
            dgvConsultas.AllowUserToResizeRows = false;
            dgvConsultas.MultiSelect = false;
            dgvConsultas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvConsultas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvConsultas.BackgroundColor = Color.White;
            dgvConsultas.BorderStyle = BorderStyle.None;
            dgvConsultas.RowHeadersVisible = false;
            dgvConsultas.RowTemplate.Height = 32;
            dgvConsultas.EnableHeadersVisualStyles = false;

            dgvConsultas.ColumnHeadersHeight = 42;
            dgvConsultas.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                    .DisableResizing;

            dgvConsultas.ColumnHeadersDefaultCellStyle
                .BackColor = oscuro;
            dgvConsultas.ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;
            dgvConsultas.ColumnHeadersDefaultCellStyle
                .Font = new Font(
                    "Segoe UI", 10F, FontStyle.Bold);

            dgvConsultas.DefaultCellStyle.ForeColor = oscuro;
            dgvConsultas.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(209, 237, 234);
            dgvConsultas.DefaultCellStyle.SelectionForeColor =
                oscuro;

            dgvConsultas.AlternatingRowsDefaultCellStyle
                .BackColor = Color.FromArgb(246, 250, 250);

            dgvConsultas.SelectionChanged +=
                dgvConsultas_SelectionChanged;

            Controls.Add(dgvConsultas);

            // Información de la consulta seleccionada
            Panel panelDetalle = new Panel();
            panelDetalle.Location = new Point(35, 610);
            panelDetalle.Size = new Size(1035, 80);
            panelDetalle.BackColor = Color.White;
            Controls.Add(panelDetalle);

            lblDetalle = new Label();
            lblDetalle.Text = "Selecciona una consulta";
            lblDetalle.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            lblDetalle.ForeColor = oscuro;
            lblDetalle.Location = new Point(18, 12);
            lblDetalle.Size = new Size(980, 27);
            panelDetalle.Controls.Add(lblDetalle);

            lblCategoria = new Label();
            lblCategoria.Text = "Categoría IMC: —";
            lblCategoria.Font = new Font("Segoe UI", 11F);
            lblCategoria.ForeColor = turquesa;
            lblCategoria.Location = new Point(18, 43);
            lblCategoria.Size = new Size(980, 27);
            panelDetalle.Controls.Add(lblCategoria);

            Button btnCerrar = CrearBoton(
                "CERRAR", 35, 700, 160, oscuro);
            btnCerrar.Click += (s, e) => Close();
            Controls.Add(btnCerrar);

            lblEstado = new Label();
            lblEstado.Text = "Esperando información...";
            lblEstado.ForeColor = gris;
            lblEstado.TextAlign =
                ContentAlignment.MiddleRight;
            lblEstado.Location = new Point(650, 700);
            lblEstado.Size = new Size(420, 42);
            Controls.Add(lblEstado);
        }

        // Crear tarjetas
        private void CrearTarjeta(
            string titulo, int x, int y,
            out Label lblValor)
        {
            Panel tarjeta = new Panel();
            tarjeta.Location = new Point(x, y);
            tarjeta.Size = new Size(315, 98);
            tarjeta.BackColor = Color.White;
            Controls.Add(tarjeta);

            Label nombre = new Label();
            nombre.Text = titulo;
            nombre.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            nombre.ForeColor = gris;
            nombre.Location = new Point(16, 13);
            nombre.AutoSize = true;
            tarjeta.Controls.Add(nombre);

            lblValor = new Label();
            lblValor.Text = "—";
            lblValor.Font = new Font(
                "Segoe UI", 24F, FontStyle.Bold);
            lblValor.ForeColor = turquesa;
            lblValor.Location = new Point(15, 43);
            lblValor.Size = new Size(285, 45);
            tarjeta.Controls.Add(lblValor);
        }

        // Crear botones
        private Button CrearBoton(
            string texto, int x, int y,
            int ancho, Color color)
        {
            Button boton = new Button();
            boton.Text = texto;
            boton.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            boton.ForeColor = Color.White;
            boton.BackColor = color;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Location = new Point(x, y);
            boton.Size = new Size(ancho, 40);
            boton.Cursor = Cursors.Hand;
            return boton;
        }

        // Cargar lista de pacientes
        private void CargarPacientes()
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

                // Opción para consultar todos
                DataRow todos = tabla.NewRow();
                todos["PacienteId"] = 0;
                todos["Paciente"] = "Todos los pacientes";
                tabla.Rows.InsertAt(todos, 0);

                cmbPacientes.DisplayMember = "Paciente";
                cmbPacientes.ValueMember = "PacienteId";
                cmbPacientes.DataSource = tabla;
                cmbPacientes.SelectedIndex = 0;

                CargarConsultas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los pacientes:\n" +
                    ex.Message,
                    "Error de Azure SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Consultar registros de Azure SQL
        private void CargarConsultas()
        {
            if (cmbPacientes == null ||
                dgvConsultas == null ||
                txtBuscar == null)
                return;

            if (cmbPacientes.SelectedValue is not int)
                return;

            int pacienteId =
                Convert.ToInt32(cmbPacientes.SelectedValue);

            try
            {
                DataTable tabla = new DataTable();
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
                            (p.Nombre LIKE @Buscar
                             OR p.Apellido LIKE @Buscar
                             OR (p.Nombre + N' ' + p.Apellido)
                                LIKE @Buscar)
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
                        ).Value = "%" +
                            txtBuscar.Text.Trim() + "%";

                        using (SqlDataAdapter adaptador =
                            new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(tabla);
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

                lblTotal.Text = total.ToString();
                lblMostradas.Text = tabla.Rows.Count.ToString();
                lblIMC.Text = "—";

                lblDetalle.Text = "Selecciona una consulta";
                lblCategoria.Text = "Categoría IMC: —";

                lblEstado.Text = "Información actualizada";
            }
            catch (Exception ex)
            {
                dgvConsultas.DataSource = null;
                lblTotal.Text = "—";
                lblMostradas.Text = "—";
                lblIMC.Text = "—";
                lblDetalle.Text = "Sin información";
                lblCategoria.Text = "Categoría IMC: —";
                lblEstado.Text = "Error de conexión";

                MessageBox.Show(
                    "No se pudieron cargar las consultas:\n" +
                    ex.Message,
                    "Error de Azure SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Mostrar información de la fila seleccionada
        private void dgvConsultas_SelectionChanged(
            object sender, EventArgs e)
        {
            if (dgvConsultas.SelectedRows.Count == 0)
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
                paciente + "  |  Consulta del " +
                fecha.ToString("dd/MM/yyyy");

            lblCategoria.Text =
                "Categoría IMC: " + categoria;
        }
    }
}
