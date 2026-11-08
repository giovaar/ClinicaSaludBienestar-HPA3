
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ClinicaSaludBienestar
{
    public partial class frmLogin : Form
    {
        // Credenciales de demostración del parcial
        private const string USUARIO = "admin";
        private const string CLAVE = "Clinica2026";

        private int intentos = 3;

        private TextBox txtUsuario;
        private TextBox txtClave;
        private Label lblIntentos;
        private Button btnIngresar;

        private readonly Color oscuro = Color.FromArgb(18, 63, 73);
        private readonly Color turquesa = Color.FromArgb(20, 125, 134);
        private readonly Color gris = Color.FromArgb(105, 127, 132);

        public frmLogin()
        {
            InitializeComponent();
            CrearInterfaz();
        }

        private void CrearInterfaz()
        {
            // Configuración de la ventana
            Text = "Salud y Bienestar | Acceso";
            ClientSize = new Size(960, 580);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10F);
            AutoScaleMode = AutoScaleMode.None;

            Controls.Clear();

            // Panel izquierdo
            Panel panelIzquierdo = new Panel();
            panelIzquierdo.Location = new Point(0, 0);
            panelIzquierdo.Size = new Size(385, 580);
            panelIzquierdo.BackColor = oscuro;

            panelIzquierdo.Paint += (s, e) =>
            {
                using (LinearGradientBrush fondo =
                    new LinearGradientBrush(
                        panelIzquierdo.ClientRectangle,
                        Color.FromArgb(18, 63, 73),
                        Color.FromArgb(21, 108, 119),
                        60F))
                {
                    e.Graphics.FillRectangle(
                        fondo, panelIzquierdo.ClientRectangle);
                }

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen linea = new Pen(
                    Color.FromArgb(65, 174, 177), 2))
                {
                    e.Graphics.DrawEllipse(linea, 205, 315, 270, 270);
                    e.Graphics.DrawEllipse(linea, 245, 355, 190, 190);
                }
            };

            Controls.Add(panelIzquierdo);

            // Identidad de la clínica
            Label lblSimbolo = new Label();
            lblSimbolo.Text = "+";
            lblSimbolo.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblSimbolo.ForeColor = Color.FromArgb(95, 224, 212);
            lblSimbolo.Location = new Point(42, 55);
            lblSimbolo.Size = new Size(80, 75);
            panelIzquierdo.Controls.Add(lblSimbolo);

            Label lblMarca = new Label();
            lblMarca.Text = "SALUD Y\nBIENESTAR";
            lblMarca.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblMarca.ForeColor = Color.White;
            lblMarca.Location = new Point(45, 150);
            lblMarca.Size = new Size(310, 110);
            panelIzquierdo.Controls.Add(lblMarca);

            Label lblDescripcion = new Label();
            lblDescripcion.Text =
                "Tecnología que acompaña tu salud.\n" +
                "Control clínico y seguimiento del IMC.";
            lblDescripcion.Font = new Font("Segoe UI", 11F);
            lblDescripcion.ForeColor =
                Color.FromArgb(207, 232, 230);
            lblDescripcion.Location = new Point(47, 280);
            lblDescripcion.Size = new Size(300, 75);
            panelIzquierdo.Controls.Add(lblDescripcion);

            Label lblFrase = new Label();
            lblFrase.Text = "Tu salud, en perspectiva.";
            lblFrase.Font =
                new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFrase.ForeColor = Color.White;
            lblFrase.Location = new Point(47, 465);
            lblFrase.Size = new Size(315, 38);
            panelIzquierdo.Controls.Add(lblFrase);

            Label lblVersion = new Label();
            lblVersion.Text = "HPA III  |  GRUPO 1  |  2026";
            lblVersion.Font = new Font("Segoe UI", 9F);
            lblVersion.ForeColor =
                Color.FromArgb(194, 223, 221);
            lblVersion.Location = new Point(47, 520);
            lblVersion.Size = new Size(300, 28);
            panelIzquierdo.Controls.Add(lblVersion);

            // Panel derecho
            Panel panelDerecho = new Panel();
            panelDerecho.Location = new Point(385, 0);
            panelDerecho.Size = new Size(575, 580);
            panelDerecho.BackColor = Color.White;
            Controls.Add(panelDerecho);

            Label lblBienvenida = new Label();
            lblBienvenida.Text = "Bienvenido de nuevo";
            lblBienvenida.Font =
                new Font("Segoe UI", 23F, FontStyle.Bold);
            lblBienvenida.ForeColor = oscuro;
            lblBienvenida.Location = new Point(65, 78);
            lblBienvenida.Size = new Size(460, 48);
            panelDerecho.Controls.Add(lblBienvenida);

            Label lblSubtitulo = new Label();
            lblSubtitulo.Text =
                "Ingresa tus credenciales para continuar.";
            lblSubtitulo.Font = new Font("Segoe UI", 11F);
            lblSubtitulo.ForeColor = gris;
            lblSubtitulo.Location = new Point(68, 139);
            lblSubtitulo.Size = new Size(435, 32);
            panelDerecho.Controls.Add(lblSubtitulo);

            // Usuario
            Label lblUsuario = CrearEtiqueta("USUARIO", 207);
            panelDerecho.Controls.Add(lblUsuario);

            txtUsuario = CrearCajaTexto(239);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.MaxLength = 50;
            panelDerecho.Controls.Add(txtUsuario);

            // Contraseña
            Label lblClave = CrearEtiqueta("CONTRASEÑA", 310);
            panelDerecho.Controls.Add(lblClave);

            txtClave = CrearCajaTexto(342);
            txtClave.Name = "txtClave";
            txtClave.MaxLength = 50;
            txtClave.UseSystemPasswordChar = true;
            panelDerecho.Controls.Add(txtClave);

            // Botón de ingreso
            btnIngresar = new Button();
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Text = "INICIAR SESIÓN";
            btnIngresar.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.BackColor = turquesa;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.Location = new Point(70, 427);
            btnIngresar.Size = new Size(430, 49);
            btnIngresar.Click += btnIngresar_Click;
            panelDerecho.Controls.Add(btnIngresar);

            // Intentos
            lblIntentos = new Label();
            lblIntentos.Name = "lblIntentos";
            lblIntentos.Text = "3 intentos disponibles";
            lblIntentos.Font = new Font("Segoe UI", 10F);
            lblIntentos.ForeColor = gris;
            lblIntentos.TextAlign = ContentAlignment.MiddleCenter;
            lblIntentos.Location = new Point(70, 493);
            lblIntentos.Size = new Size(430, 30);
            panelDerecho.Controls.Add(lblIntentos);

            AcceptButton = btnIngresar;
        }

        private Label CrearEtiqueta(string texto, int y)
        {
            Label etiqueta = new Label();
            etiqueta.Text = texto;
            etiqueta.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            etiqueta.ForeColor = oscuro;
            etiqueta.Location = new Point(70, y);
            etiqueta.Size = new Size(420, 25);
            return etiqueta;
        }

        private TextBox CrearCajaTexto(int y)
        {
            TextBox caja = new TextBox();
            caja.Font = new Font("Segoe UI", 12F);
            caja.Location = new Point(70, y);
            caja.Size = new Size(430, 35);
            caja.BorderStyle = BorderStyle.FixedSingle;
            return caja;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string clave = txtClave.Text;

            if (usuario == USUARIO && clave == CLAVE)
            {
                MessageBox.Show(
                    "Bienvenido a Clínica Salud y Bienestar.",
                    "Acceso autorizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Hide();

                using (frmPrincipal principal = new frmPrincipal())
                {
                    principal.ShowDialog();
                }

                Close();
            }
            else
            {
                intentos--;

                if (intentos > 0)
                {
                    string mensaje = intentos == 1
                        ? "Le queda 1 intento."
                        : "Le quedan " + intentos + " intentos.";

                    MessageBox.Show(
                        "Usuario o clave incorrectos.\n" + mensaje,
                        "Acceso denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    lblIntentos.Text =
                        intentos + " intento(s) disponible(s)";

                    txtClave.Clear();
                    txtClave.Focus();
                }
                else
                {
                    MessageBox.Show(
                        "Ha superado el máximo de 3 intentos.\n" +
                        "La aplicación se cerrará.",
                        "Acceso bloqueado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    Application.Exit();
                }
            }
        }
    }
}
