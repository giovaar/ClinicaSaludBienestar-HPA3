
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicaSaludBienestar
{
    public class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            Text = "Clínica Salud y Bienestar | Panel principal";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1000, 650);
            MinimumSize = new Size(850, 550);
            BackColor = Color.FromArgb(242, 248, 248);

            Panel encabezado = new Panel();
            encabezado.Dock = DockStyle.Top;
            encabezado.Height = 100;
            encabezado.BackColor = Color.FromArgb(18, 63, 73);
            Controls.Add(encabezado);

            Label titulo = new Label();
            titulo.Text = "SALUD Y BIENESTAR";
            titulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.Location = new Point(35, 24);
            titulo.AutoSize = true;
            encabezado.Controls.Add(titulo);

            Label bienvenida = new Label();
            bienvenida.Text = "Panel principal";
            bienvenida.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            bienvenida.ForeColor = Color.FromArgb(18, 63, 73);
            bienvenida.Location = new Point(45, 150);
            bienvenida.AutoSize = true;
            Controls.Add(bienvenida);

            Label descripcion = new Label();
            descripcion.Text =
                "Sistema de gestión clínica y evolución del IMC.\n" +
                "Próximamente: registro, informes y gráficos.";
            descripcion.Font = new Font("Segoe UI", 13F);
            descripcion.ForeColor = Color.FromArgb(95, 116, 120);
            descripcion.Location = new Point(48, 215);
            descripcion.Size = new Size(650, 85);
            Controls.Add(descripcion);

            Button btnSalir = new Button();
            btnSalir.Text = "Salir del sistema";
            btnSalir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSalir.Size = new Size(200, 48);
            btnSalir.Location = new Point(48, 340);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.BackColor = Color.FromArgb(20, 125, 134);
            btnSalir.ForeColor = Color.White;
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.Click += (s, e) => Close();
            Controls.Add(btnSalir);
        }
    }
}
