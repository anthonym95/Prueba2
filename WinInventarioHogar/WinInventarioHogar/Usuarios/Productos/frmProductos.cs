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

namespace WinInventarioHogar.Usuarios.Productos
{
    public partial class frmProductos : Form
    {
        Usuario usuario;
        public frmProductos(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            abrirFormHijo(new frmSalidaProductos(usuario));
        }


        private void abrirFormHijo(object formHijo)
        {
            if (this.plProductos.Controls.Count > 0)
            {
                this.plProductos.Controls.RemoveAt(0);
            }
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.plProductos.Controls.Add(fh);
            this.plProductos.Tag = fh;
            fh.Show();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            btnAgregarProducto.Visible = false;
            btnEntradaProducto.Visible = true;
            btnSalidaProductos.Location = new Point(657, 4);
            btnSalidaProductos.Visible = true;
            abrirFormHijo(new frmAgregarProductos());
        }

        private void btnEntradaProducto_Click(object sender, EventArgs e)
        {
            btnSalidaProductos.Visible = true;
            btnSalidaProductos.Location = new Point(855, 4);
            btnEntradaProducto.Visible = false;
            btnAgregarProducto.Visible = true;
            abrirFormHijo(new frmEntradaProductos(usuario));
        }

        private void btnSalidaProductos_Click(object sender, EventArgs e)
        {
            
            btnSalidaProductos.Visible = false;
            btnSalidaProductos.Location = new Point(855, 4);
            btnEntradaProducto.Visible = true;
            btnAgregarProducto.Visible = true;
            abrirFormHijo(new frmSalidaProductos(usuario));
        }
    }
}
