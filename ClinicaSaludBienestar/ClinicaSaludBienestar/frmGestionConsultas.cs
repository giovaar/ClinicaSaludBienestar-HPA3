
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClinicaSaludBienestar.Datos;

namespace ClinicaSaludBienestar
{
    public class frmGestionConsultas : Form
    {
        private readonly Color oscuro =
            Color.FromArgb(18, 63, 73);

        private readonly Color turquesa =
            Color.FromArgb(20, 125, 134);

        private readonly Color fondo =
            Color.FromArgb(240, 247, 247);

        private readonly Color gris =
            Color.FromArgb(105, 127, 132);

        private readonly DateTime fechaCorte =
            new DateTime(2026, 11, 10);

        private DataGridView dgvConsultas = null!;
        private ComboBox cmbPaciente = null!;
        private DateTimePicker dtpFecha = null!;
        private NumericUpDown nudPeso = null!;
        private NumericUpDown nudEstatura = null!;
        private Label lblIMC = null!;
        private Label lblSeleccion = null!;
        private Label lblEstado = null!;

        private int consultaId = 0;
        private bool cargando = false;

        public frmGestionConsultas()
        {
            Text = "Clínica Salud y Bienestar | Gestión de consultas";
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1050, 700);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = fondo;
            Font = new Font("Segoe UI", 10F);

            CrearInterfaz();

            Shown += (s, e) => CargarDatos();
        }

        private void CrearInterfaz()
        {
            // Distribución principal
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

            // Encabezado
            Panel encabezado = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = oscuro
            };

            raiz.Controls.Add(encabezado, 0, 0);

            Label titulo = new Label
            {
                Text = "GESTIÓN DE CONSULTAS",
                Font = new Font(
                    "Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(30, 12),
                AutoSize = true
            };

            encabezado.Controls.Add(titulo);

            Label subtitulo = new Label
            {
                Text = "Registros clínicos | ClinicaDB_Pruebas",
                ForeColor = Color.LightCyan,
                Location = new Point(33, 60),
                AutoSize = true
            };

            encabezado.Controls.Add(subtitulo);

            // Contenido
            TableLayoutPanel principal = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(24, 15, 24, 15),
                BackColor = fondo
            };

            principal.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 58));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 260));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 32));

            raiz.Controls.Add(principal, 0, 1);

            // Barra superior
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
                new ColumnStyle(SizeType.Absolute, 150));

            barra.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 130));

            principal.Controls.Add(barra, 0, 0);

            Label lblTabla = new Label
            {
                Text = "CONSULTAS REGISTRADAS",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font(
                    "Segoe UI", 13F, FontStyle.Bold),
                ForeColor = oscuro
            };

            barra.Controls.Add(lblTabla, 0, 0);

            Button btnRecargar = CrearBoton(
                "RECARGAR", turquesa);

            btnRecargar.Click +=
                (s, e) => CargarDatos();

            barra.Controls.Add(btnRecargar, 1, 0);

            Button btnCerrar = CrearBoton(
                "CERRAR", oscuro);

            btnCerrar.Click +=
                (s, e) => Close();

            barra.Controls.Add(btnCerrar, 2, 0);

            // Tabla
            dgvConsultas = new DataGridView
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

            dgvConsultas.RowTemplate.Height = 34;

            dgvConsultas.EnableHeadersVisualStyles = false;

            dgvConsultas.ColumnHeadersDefaultCellStyle.BackColor =
                oscuro;

            dgvConsultas.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvConsultas.SelectionChanged +=
                dgvConsultas_SelectionChanged;

            principal.Controls.Add(dgvConsultas, 0, 1);

            // Panel de edición
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
                RowCount = 4
            };

            for (int i = 0; i < 4; i++)
            {
                editor.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 25));
            }

            editor.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 37));

            editor.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 75));

            editor.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 45));

            editor.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            panelDatos.Controls.Add(editor);

            lblSeleccion = new Label
            {
                Text = "Nueva consulta | Sin selección",
                Dock = DockStyle.Fill,
                ForeColor = oscuro,
                Font = new Font(
                    "Segoe UI", 12F, FontStyle.Bold)
            };

            editor.Controls.Add(lblSeleccion, 0, 0);
            editor.SetColumnSpan(lblSeleccion, 4);

            // Selector de paciente
            Panel panelPaciente = CrearCampo(
                editor, "Paciente", 0);

            cmbPaciente = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle =
                    ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 11F)
            };

            panelPaciente.Controls.Add(cmbPaciente);

            // Fecha
            Panel panelFecha = CrearCampo(
                editor, "Fecha de consulta", 1);

            dtpFecha = new DateTimePicker
            {
                Dock = DockStyle.Top,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Font = new Font("Segoe UI", 11F),
                MinDate = new DateTime(1900, 1, 1),
                MaxDate = fechaCorte,
                Value = fechaCorte
            };

            panelFecha.Controls.Add(dtpFecha);

            // Peso
            Panel panelPeso = CrearCampo(
                editor, "Peso (kg)", 2);

            nudPeso = new NumericUpDown
            {
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 11F),
                DecimalPlaces = 2,
                Minimum = 1m,
                Maximum = 500m,
                Increment = 0.10m,
                Value = 75m
            };

            panelPeso.Controls.Add(nudPeso);

            // Estatura
            Panel panelEstatura = CrearCampo(
                editor, "Estatura (m)", 3);

            nudEstatura = new NumericUpDown
            {
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 11F),
                DecimalPlaces = 2,
                Minimum = 0.50m,
                Maximum = 2.50m,
                Increment = 0.01m,
                Value = 1.75m
            };

            panelEstatura.Controls.Add(nudEstatura);

            // IMC calculado
            lblIMC = new Label
            {
                Text = "IMC: --",
                Dock = DockStyle.Fill,
                Font = new Font(
                    "Segoe UI", 14F, FontStyle.Bold),
                ForeColor = turquesa,
                TextAlign = ContentAlignment.MiddleLeft
            };

            editor.Controls.Add(lblIMC, 0, 2);
            editor.SetColumnSpan(lblIMC, 4);

            nudPeso.ValueChanged +=
                (s, e) => ActualizarIMC();

            nudEstatura.ValueChanged +=
                (s, e) => ActualizarIMC();

            // Botones del CRUD
            FlowLayoutPanel botones = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight
            };

            editor.Controls.Add(botones, 0, 3);
            editor.SetColumnSpan(botones, 4);

            Button btnNuevo = CrearBoton(
                "LIMPIAR / NUEVA", oscuro);

            btnNuevo.Width = 160;
            btnNuevo.Click +=
                (s, e) => LimpiarFormulario();

            botones.Controls.Add(btnNuevo);

            Button btnAgregar = CrearBoton(
                "AGREGAR", turquesa);

            btnAgregar.Width = 135;
            btnAgregar.Click +=
                (s, e) => AgregarConsulta();

            botones.Controls.Add(btnAgregar);

            Button btnActualizar = CrearBoton(
                "ACTUALIZAR", turquesa);

            btnActualizar.Width = 145;
            btnActualizar.Click +=
                (s, e) => ActualizarConsulta();

            botones.Controls.Add(btnActualizar);

            Button btnEliminar = CrearBoton(
                "ELIMINAR", Color.Firebrick);

            btnEliminar.Width = 135;
            btnEliminar.Click +=
                (s, e) => EliminarConsulta();

            botones.Controls.Add(btnEliminar);

            // Pie de estado
            lblEstado = new Label
            {
                Text = "Esperando conexión...",
                Dock = DockStyle.Fill,
                ForeColor = gris,
                TextAlign = ContentAlignment.MiddleLeft
            };

            principal.Controls.Add(lblEstado, 0, 3);

            ActualizarIMC();
        }

        // Panel para un campo
        private Panel CrearCampo(
            TableLayoutPanel tabla,
            string texto,
            int columna)
        {
            TableLayoutPanel contenedor =
                new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 1,
                    RowCount = 2,
                    Padding = new Padding(3, 0, 12, 0)
                };

            contenedor.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 27));

            contenedor.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            Label etiqueta = new Label
            {
                Text = texto,
                Dock = DockStyle.Fill,
                ForeColor = oscuro,
                Font = new Font(
                    "Segoe UI", 10F, FontStyle.Bold)
            };

            contenedor.Controls.Add(etiqueta, 0, 0);

            Panel campo = new Panel
            {
                Dock = DockStyle.Fill
            };

            contenedor.Controls.Add(campo, 0, 1);

            tabla.Controls.Add(contenedor, columna, 1);

            return campo;
        }

        // Crear botones
        private Button CrearBoton(
            string texto, Color color)
        {
            Button boton = new Button
            {
                Text = texto,
                Width = 135,
                Height = 40,
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

        // Cargar pacientes y consultas
        private void CargarDatos()
        {
            try
            {
                cargando = true;

                DataTable pacientes =
                    ConsultaDatos.ObtenerPacientes();

                cmbPaciente.DataSource = null;
                cmbPaciente.DisplayMember = "NombreCompleto";
                cmbPaciente.ValueMember = "PacienteId";
                cmbPaciente.DataSource = pacientes;

                DataTable consultas =
                    ConsultaDatos.Consultar();

                dgvConsultas.DataSource = consultas;

                if (dgvConsultas.Columns.Contains("ConsultaId"))
                {
                    dgvConsultas.Columns["ConsultaId"]!
                        .HeaderText = "ID Consulta";
                }

                if (dgvConsultas.Columns.Contains("PacienteId"))
                {
                    dgvConsultas.Columns["PacienteId"]!
                        .HeaderText = "ID Paciente";
                }

                if (dgvConsultas.Columns.Contains("Fecha"))
                {
                    dgvConsultas.Columns["Fecha"]!
                        .DefaultCellStyle.Format =
                        "dd/MM/yyyy";
                }

                if (dgvConsultas.Columns.Contains("Peso"))
                {
                    dgvConsultas.Columns["Peso"]!
                        .DefaultCellStyle.Format = "N2";
                }

                if (dgvConsultas.Columns.Contains("Estatura"))
                {
                    dgvConsultas.Columns["Estatura"]!
                        .DefaultCellStyle.Format = "N2";
                }

                if (dgvConsultas.Columns.Contains("IMC"))
                {
                    dgvConsultas.Columns["IMC"]!
                        .DefaultCellStyle.Format = "N1";
                }

                lblEstado.Text =
                    "Pacientes disponibles: " +
                    pacientes.Rows.Count +
                    "  |  Consultas registradas: " +
                    consultas.Rows.Count;

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                lblEstado.Text =
                    "Error al cargar los datos.";

                MessageBox.Show(
                    "No se pudieron cargar las consultas.\n" +
                    ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                cargando = false;
            }
        }

        // Seleccionar una consulta de la tabla
        private void dgvConsultas_SelectionChanged(
            object? sender, EventArgs e)
        {
            if (cargando ||
                dgvConsultas.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow fila =
                dgvConsultas.SelectedRows[0];

            if (fila.Cells["ConsultaId"].Value == null)
            {
                return;
            }

            try
            {
                consultaId = Convert.ToInt32(
                    fila.Cells["ConsultaId"].Value);

                int pacienteId = Convert.ToInt32(
                    fila.Cells["PacienteId"].Value);

                cmbPaciente.SelectedValue = pacienteId;

                dtpFecha.Value = Convert.ToDateTime(
                    fila.Cells["Fecha"].Value);

                nudPeso.Value = Convert.ToDecimal(
                    fila.Cells["Peso"].Value);

                nudEstatura.Value = Convert.ToDecimal(
                    fila.Cells["Estatura"].Value);

                lblSeleccion.Text =
                    "Consulta seleccionada: ID " +
                    consultaId;

                ActualizarIMC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar la consulta.\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // Calcular IMC visible
        private void ActualizarIMC()
        {
            if (lblIMC == null ||
                nudPeso == null ||
                nudEstatura == null)
            {
                return;
            }

            decimal imc = ConsultaDatos.CalcularIMC(
                nudPeso.Value,
                nudEstatura.Value);

            lblIMC.Text = "IMC CALCULADO: " +
                imc.ToString("F1");
        }

        private int ObtenerPacienteSeleccionado()
        {
            if (cmbPaciente.SelectedValue == null ||
                cmbPaciente.SelectedValue is DataRowView)
            {
                throw new InvalidOperationException(
                    "Selecciona un paciente válido.");
            }

            return Convert.ToInt32(
                cmbPaciente.SelectedValue);
        }

        // Agregar consulta
        private void AgregarConsulta()
        {
            if (consultaId != 0)
            {
                MessageBox.Show(
                    "Presiona LIMPIAR / NUEVA " +
                    "para registrar otra consulta.",
                    "Consulta seleccionada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int pacienteId =
                    ObtenerPacienteSeleccionado();

                DialogResult respuesta = MessageBox.Show(
                    "¿Agregar esta consulta a " +
                    "ClinicaDB_Pruebas?",
                    "Confirmar registro",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                int nuevoId = ConsultaDatos.Agregar(
                    pacienteId,
                    dtpFecha.Value,
                    nudPeso.Value,
                    nudEstatura.Value);

                MessageBox.Show(
                    "Consulta registrada correctamente.\n" +
                    "ID: " + nuevoId,
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarDatos();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // Actualizar consulta
        private void ActualizarConsulta()
        {
            if (consultaId == 0)
            {
                MessageBox.Show(
                    "Selecciona una consulta de la tabla.");
                return;
            }

            try
            {
                int pacienteId =
                    ObtenerPacienteSeleccionado();

                DialogResult respuesta = MessageBox.Show(
                    "¿Actualizar la consulta ID " +
                    consultaId + "?",
                    "Confirmar actualización",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                bool actualizado =
                    ConsultaDatos.Actualizar(
                        consultaId,
                        pacienteId,
                        dtpFecha.Value,
                        nudPeso.Value,
                        nudEstatura.Value);

                MessageBox.Show(
                    actualizado
                        ? "Consulta actualizada correctamente."
                        : "No se encontró la consulta.");

                CargarDatos();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // Eliminar consulta
        private void EliminarConsulta()
        {
            if (consultaId == 0)
            {
                MessageBox.Show(
                    "Selecciona una consulta para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Eliminar definitivamente la consulta ID " +
                consultaId + " de ClinicaDB_Pruebas?\n\n" +
                "Esta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                bool eliminado =
                    ConsultaDatos.Eliminar(consultaId);

                MessageBox.Show(
                    eliminado
                        ? "Consulta eliminada correctamente."
                        : "No se encontró la consulta.");

                CargarDatos();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // Limpiar formulario
        private void LimpiarFormulario()
        {
            consultaId = 0;

            if (cmbPaciente != null)
                cmbPaciente.SelectedIndex = -1;

            if (dtpFecha != null)
                dtpFecha.Value = fechaCorte;

            if (nudPeso != null)
                nudPeso.Value = 75m;

            if (nudEstatura != null)
                nudEstatura.Value = 1.75m;

            if (lblSeleccion != null)
                lblSeleccion.Text =
                    "Nueva consulta | Sin selección";

            if (dgvConsultas != null)
                dgvConsultas.ClearSelection();

            ActualizarIMC();
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
