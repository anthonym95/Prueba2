using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinInventarioHogar.Entidades;

namespace WinInventarioHogar
{
    public partial class frmPrincipal : Form
    {

        public Usuario u { get; set; }

        public frmPrincipal(Usuario usuario)
        {
            u = usuario;
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (u.roll.id == 1)
            {
                msAdmin.Visible = true;
            }
            lblUsuario.Text = u.nombre;
            abrirFormHijo(new Usuarios.frmInicio());
            btnInicio.BackColor = Color.FromArgb(255, 48, 50, 79);
        }

        private void tsmiUsuarios_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Administrador.frmUsuarios());
            btnOpciones.BackColor = Color.Transparent;
            btnInicio.BackColor = Color.Transparent;
            btnProductos.BackColor = Color.Transparent;
            btnReportes.BackColor = Color.Transparent;
        }

        private void tsmiCategoriasRoles_Click(object sender, EventArgs e)
        {

            abrirFormHijo(new Administrador.frmCategoriasRoles());
            btnOpciones.BackColor = Color.Transparent;
            btnInicio.BackColor = Color.Transparent;
            btnProductos.BackColor = Color.Transparent;
            btnReportes.BackColor = Color.Transparent;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Usuarios.frmInicio());
            btnOpciones.BackColor = Color.Transparent;
            btnProductos.BackColor = Color.Transparent;
            btnReportes.BackColor = Color.Transparent;
            btnInicio.BackColor = Color.FromArgb(255, 48, 50, 79);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Usuarios.Productos.frmProductos(u));
            btnOpciones.BackColor = Color.Transparent;
            btnReportes.BackColor = Color.Transparent;
            btnInicio.BackColor = Color.Transparent;
            btnProductos.BackColor = Color.FromArgb(255, 48, 50, 79);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Usuarios.frmReportes());
            btnOpciones.BackColor = Color.Transparent;
            btnInicio.BackColor = Color.Transparent;
            btnProductos.BackColor = Color.Transparent;
            btnReportes.BackColor = Color.FromArgb(255, 48, 50, 79);
        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Usuarios.frmOpciones());
            btnInicio.BackColor = Color.Transparent;
            btnProductos.BackColor = Color.Transparent;
            btnReportes.BackColor = Color.Transparent;
            btnOpciones.BackColor = Color.FromArgb(255, 48, 50, 79);
        }

        private void abrirFormHijo(object formHijo)
        {
            if (this.Content.Controls.Count > 0)
            {
                this.Content.Controls.RemoveAt(0);
            }
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Content.Controls.Add(fh);
            this.Content.Tag = fh;
            fh.Show();
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tsmiSalir_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
