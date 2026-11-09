
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public class frmGestionPacientes : Form
    {
        private readonly Color oscuro =
            Color.FromArgb(18, 63, 73);

        private readonly Color turquesa =
            Color.FromArgb(20, 125, 134);

        private readonly Color fondo =
            Color.FromArgb(240, 247, 247);

        private DataGridView dgvPacientes = null!;
        private TextBox txtBuscar = null!;
        private TextBox txtNombre = null!;
        private TextBox txtApellido = null!;
        private ComboBox cmbGenero = null!;
        private DateTimePicker dtpNacimiento = null!;
        private Label lblSeleccion = null!;
        private Label lblEstado = null!;

        private int pacienteId = 0;
        private bool cargando = false;

        public frmGestionPacientes()
        {
            Text = "Clínica Salud y Bienestar | Gestión de pacientes";
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1050, 720);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = fondo;
            Font = new Font("Segoe UI", 10F);

            CrearInterfaz();

            Shown += (s, e) => CargarPacientes();
        }

        private void CrearInterfaz()
        {
            TableLayoutPanel raiz = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

            raiz.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            raiz.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 95));

            raiz.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            Controls.Add(raiz);

            Panel encabezado = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = oscuro
            };

            raiz.Controls.Add(encabezado, 0, 0);

            Label titulo = new Label
            {
                Text = "GESTIÓN DE PACIENTES",
                Font = new Font(
                    "Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(30, 12),
                AutoSize = true
            };

            encabezado.Controls.Add(titulo);

            Label subtitulo = new Label
            {
                Text = "Administración | ClinicaDB_Pruebas",
                ForeColor = Color.LightCyan,
                Location = new Point(33, 60),
                AutoSize = true
            };

            encabezado.Controls.Add(subtitulo);

            TableLayoutPanel principal = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                BackColor = fondo,
                Padding = new Padding(24, 15, 24, 15)
            };

            principal.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 62));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 255));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 32));

            raiz.Controls.Add(principal, 0, 1);

            // Barra de búsqueda
            TableLayoutPanel barra = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                Margin = Padding.Empty
            };

            barra.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            barra.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 130));

            barra.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 140));

            principal.Controls.Add(barra, 0, 0);

            txtBuscar = new TextBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 10, 12, 10),
                Font = new Font("Segoe UI", 11F),
                PlaceholderText = "Buscar por nombre o apellido"
            };

            txtBuscar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    CargarPacientes();
                }
            };

            barra.Controls.Add(txtBuscar, 0, 0);

            Button btnBuscar = Boton(
                "BUSCAR", turquesa);

            btnBuscar.Click +=
                (s, e) => CargarPacientes();

            barra.Controls.Add(btnBuscar, 1, 0);

            Button btnRecargar = Boton(
                "RECARGAR", oscuro);

            btnRecargar.Click += (s, e) =>
            {
                txtBuscar.Clear();
                CargarPacientes();
            };

            barra.Controls.Add(btnRecargar, 2, 0);

            // Tabla
            dgvPacientes = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                MultiSelect = false,
                SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                ColumnHeadersHeight = 42,
                Margin = new Padding(0, 0, 0, 12)
            };

            dgvPacientes.RowTemplate.Height = 35;
            dgvPacientes.EnableHeadersVisualStyles = false;
            dgvPacientes.ColumnHeadersDefaultCellStyle.BackColor =
                oscuro;
            dgvPacientes.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvPacientes.SelectionChanged +=
                dgvPacientes_SelectionChanged;

            principal.Controls.Add(dgvPacientes, 0, 1);

            // Zona de edición
            Panel panelDatos = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            principal.Controls.Add(panelDatos, 0, 2);

            TableLayoutPanel editor = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 3
            };

            for (int i = 0; i < 4; i++)
            {
                editor.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 25));
            }

            editor.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 40));

            editor.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 85));

            editor.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            panelDatos.Controls.Add(editor);

            lblSeleccion = new Label
            {
                Text = "Sin paciente seleccionado",
                Dock = DockStyle.Fill,
                ForeColor = oscuro,
                Font = new Font(
                    "Segoe UI", 12F, FontStyle.Bold)
            };

            editor.Controls.Add(lblSeleccion, 0, 0);
            editor.SetColumnSpan(lblSeleccion, 4);

            // Campo nombre
            TableLayoutPanel campoNombre =
                CrearCampo(editor, "Nombre", 0);

            txtNombre = new TextBox
            {
                Dock = DockStyle.Top,
                MaxLength = 60,
                Font = new Font("Segoe UI", 11F)
            };

            campoNombre.Controls.Add(txtNombre, 0, 1);

            // Campo apellido
            TableLayoutPanel campoApellido =
                CrearCampo(editor, "Apellido", 1);

            txtApellido = new TextBox
            {
                Dock = DockStyle.Top,
                MaxLength = 60,
                Font = new Font("Segoe UI", 11F)
            };

            campoApellido.Controls.Add(txtApellido, 0, 1);

            // Género
            TableLayoutPanel campoGenero =
                CrearCampo(editor, "Género", 2);

            cmbGenero = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 11F)
            };

            cmbGenero.Items.AddRange(
                new object[] { "Masculino", "Femenino" });

            campoGenero.Controls.Add(cmbGenero, 0, 1);

            // Fecha de nacimiento
            TableLayoutPanel campoFecha =
                CrearCampo(
                    editor, "Fecha de nacimiento", 3);

            dtpNacimiento = new DateTimePicker
            {
                Dock = DockStyle.Top,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Font = new Font("Segoe UI", 11F),
                MinDate = new DateTime(1900, 1, 1),
                MaxDate = new DateTime(2008, 11, 10),
                Value = new DateTime(2000, 1, 1)
            };

            campoFecha.Controls.Add(dtpNacimiento, 0, 1);

            // Botones
            FlowLayoutPanel botones = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight
            };

            editor.Controls.Add(botones, 0, 2);
            editor.SetColumnSpan(botones, 4);

            Button btnNuevo = Boton(
                "LIMPIAR / NUEVO", oscuro);

            btnNuevo.Width = 160;
            btnNuevo.Click +=
                (s, e) => LimpiarFormulario();

            botones.Controls.Add(btnNuevo);

            Button btnAgregar = Boton(
                "AGREGAR", turquesa);

            btnAgregar.Width = 145;
            btnAgregar.Click +=
                (s, e) => AbrirRegistroCompleto();

            botones.Controls.Add(btnAgregar);

            Button btnActualizar = Boton(
                "ACTUALIZAR", turquesa);

            btnActualizar.Width = 145;
            btnActualizar.Click +=
                (s, e) => ActualizarPaciente();

            botones.Controls.Add(btnActualizar);

            Button btnEliminar = Boton(
                "ELIMINAR", Color.Firebrick);

            btnEliminar.Width = 135;
            btnEliminar.Click +=
                (s, e) => EliminarPaciente();

            botones.Controls.Add(btnEliminar);

            Button btnCerrar = Boton(
                "CERRAR", oscuro);

            btnCerrar.Width = 120;
            btnCerrar.Click +=
                (s, e) => Close();

            botones.Controls.Add(btnCerrar);

            lblEstado = new Label
            {
                Text = "Esperando conexión...",
                ForeColor = Color.FromArgb(105, 127, 132),
                Dock = DockStyle.Fill
            };

            principal.Controls.Add(lblEstado, 0, 3);

            LimpiarFormulario();
        }

        private TableLayoutPanel CrearCampo(
            TableLayoutPanel editor,
            string texto,
            int columna)
        {
            TableLayoutPanel campo = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(4, 0, 14, 0)
            };

            campo.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 30));

            campo.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            Label etiqueta = new Label
            {
                Text = texto,
                Dock = DockStyle.Fill,
                ForeColor = oscuro,
                Font = new Font(
                    "Segoe UI", 10F, FontStyle.Bold)
            };

            campo.Controls.Add(etiqueta, 0, 0);
            editor.Controls.Add(campo, columna, 1);

            return campo;
        }

        private Button Boton(
            string texto, Color color)
        {
            Button boton = new Button
            {
                Text = texto,
                Width = 125,
                Height = 43,
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font(
                    "Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(4)
            };

            boton.FlatAppearance.BorderSize = 0;
            return boton;
        }

        private void CargarPacientes()
        {
            try
            {
                cargando = true;

                DataTable tabla =
                    PacienteDatos.Consultar(txtBuscar.Text);

                dgvPacientes.DataSource = tabla;

                if (dgvPacientes.Columns.Contains("PacienteId"))
                {
                    dgvPacientes.Columns["PacienteId"]!
                        .HeaderText = "ID";
                }

                if (dgvPacientes.Columns.Contains("FechaNacimiento"))
                {
                    dgvPacientes.Columns["FechaNacimiento"]!
                        .HeaderText = "Fecha de nacimiento";

                    dgvPacientes.Columns["FechaNacimiento"]!
                        .DefaultCellStyle.Format =
                            "dd/MM/yyyy";
                }

                lblEstado.Text =
                    "Pacientes encontrados: " +
                    tabla.Rows.Count +
                    " | Base: ClinicaDB_Pruebas";

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                lblEstado.Text =
                    "No se pudieron cargar los pacientes.";

                MessageBox.Show(
                    "Error al consultar los pacientes.\n" +
                    ex.Message,
                    "Error SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                cargando = false;
            }
        }

        private void dgvPacientes_SelectionChanged(
            object? sender, EventArgs e)
        {
            if (cargando ||
                dgvPacientes.SelectedRows.Count == 0)
                return;

            DataGridViewRow fila =
                dgvPacientes.SelectedRows[0];

            if (fila.Cells["PacienteId"].Value == null)
                return;

            pacienteId = Convert.ToInt32(
                fila.Cells["PacienteId"].Value);

            txtNombre.Text = Convert.ToString(
                fila.Cells["Nombre"].Value) ?? "";

            txtApellido.Text = Convert.ToString(
                fila.Cells["Apellido"].Value) ?? "";

            string genero = (
                Convert.ToString(
                    fila.Cells["Genero"].Value) ?? ""
            ).Trim();

            cmbGenero.SelectedIndex =
                genero == "M" ? 0 :
                genero == "F" ? 1 : -1;

            dtpNacimiento.Value = Convert.ToDateTime(
                fila.Cells["FechaNacimiento"].Value);

            lblSeleccion.Text =
                "Paciente seleccionado: ID " + pacienteId;
        }

        // Abrir formulario completo de registro
        private void AbrirRegistroCompleto()
        {
            using (frmRegistroPaciente ventana =
                new frmRegistroPaciente())
            {
                ventana.ShowDialog(this);

                if (ventana.RegistroRealizado)
                {
                    txtBuscar.Clear();
                    CargarPacientes();
                }
            }
        }

        // Editar datos personales
        private void ActualizarPaciente()
        {
            if (pacienteId == 0)
            {
                MessageBox.Show(
                    "Selecciona un paciente de la tabla.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                cmbGenero.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Completa nombre, apellido y género.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Actualizar los datos del paciente ID " +
                pacienteId + " en ClinicaDB_Pruebas?",
                "Confirmar actualización",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                string genero =
                    cmbGenero.SelectedIndex == 0 ? "M" : "F";

                bool actualizado = PacienteDatos.Actualizar(
                    pacienteId,
                    txtNombre.Text,
                    txtApellido.Text,
                    genero,
                    dtpNacimiento.Value);

                MessageBox.Show(
                    actualizado
                        ? "Paciente actualizado correctamente."
                        : "No se encontró el paciente.");

                CargarPacientes();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // Eliminar solo pacientes sin consultas
        private void EliminarPaciente()
        {
            if (pacienteId == 0)
            {
                MessageBox.Show(
                    "Selecciona un paciente para eliminar.");
                return;
            }

            try
            {
                if (PacienteDatos.TieneConsultas(pacienteId))
                {
                    MessageBox.Show(
                        "Este paciente tiene consultas.\n" +
                        "No se permite eliminarlo mientras " +
                        "exista su historial clínico.",
                        "Eliminación bloqueada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Eliminar definitivamente al paciente " +
                    pacienteId + " de ClinicaDB_Pruebas?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta != DialogResult.Yes)
                    return;

                bool eliminado =
                    PacienteDatos.Eliminar(pacienteId);

                MessageBox.Show(
                    eliminado
                        ? "Paciente eliminado correctamente."
                        : "No se pudo eliminar el paciente.");

                CargarPacientes();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void LimpiarFormulario()
        {
            pacienteId = 0;

            if (txtNombre != null)
                txtNombre.Clear();

            if (txtApellido != null)
                txtApellido.Clear();

            if (cmbGenero != null)
                cmbGenero.SelectedIndex = -1;

            if (dtpNacimiento != null)
                dtpNacimiento.Value =
                    new DateTime(2000, 1, 1);

            if (lblSeleccion != null)
                lblSeleccion.Text =
                    "Sin paciente seleccionado";

            if (dgvPacientes != null)
                dgvPacientes.ClearSelection();
        }

        private void MostrarError(Exception ex)
        {
            MessageBox.Show(
                "Ocurrió un error:\n" + ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
