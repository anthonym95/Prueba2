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
using WinInventarioHogar.Logica;

namespace WinInventarioHogar.Usuarios.Productos
{
    public partial class frmEntradaProductos : Form
    {
        Usuario usuario;
        public static int count_fila = 0;
        public frmEntradaProductos(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }
        
        private void frmEntradaProductos_Load(object sender, EventArgs e)
        {

            lblFecha.Text = DateTime.Now.ToString("dd'/'MM'/'yyyy");
            llenarComboBox();




            // Personalización del datagridview productos
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.DefaultCellStyle.Font = new Font("Tahoma", 13);
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 13);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                bool estado = MessageBox.Show("Esta seguro que desea borrar este producto?.", "Esta seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                if (estado)
                {
                    foreach (DataGridViewRow item in this.dgvProductos.SelectedRows)
                    {
                        dgvProductos.Rows.RemoveAt(item.Index);
                        count_fila--;
                    }
                }
            }
            else
            {
                MessageTimer.Start();
                lblSuccess.Visible = false;
                lblError.Text = "*Debe seleccionar un producto de la tabla.";
                lblError.Visible = true;
            }
            cmbProductos.SelectedItem = null;
            cmbProductos.Text = "";
            nudCantidad.Value = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = 0;
            Producto p;
            ProductoLogica logica = new ProductoLogica();
            InventarioLogica logica2 = new InventarioLogica();
            if (dgvProductos.Rows.Count > 0)
            {
                logica2.CrearEntradaProductos(usuario);
                foreach (DataGridViewRow item in dgvProductos.Rows)
                {

                    id = Convert.ToInt32(item.Cells[0].Value.ToString());
                    p = logica.SeleccionarPorId(id);
                    p.cantidad += Convert.ToInt32(item.Cells[6].Value.ToString());
                    logica.Actualizar(p);
                    Inventario inventario = new Inventario();
                    inventario.producto = p;
                    inventario.cantidad = Convert.ToInt32(item.Cells[6].Value.ToString());

                    logica2.EntradaProductos(inventario);


                }

                dgvProductos.Rows.Clear();
                count_fila = 0;

                MessageTimer.Start();
                lblError.Visible = false;
                lblSuccess.Text = "*Se ha guardado la entrada de productos.";
                lblSuccess.Visible = true;
            }
            else
            {
                MessageTimer.Start();
                lblSuccess.Visible = false;
                lblError.Text = "*Debe agregar productos de entrada.";
                lblError.Visible = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool existe = false;
            int num_fila = 0;

            ProductoLogica logica = new ProductoLogica();

            if (cmbProductos.SelectedItem == null)
            {
                lblSuccess.Visible = false;
                MessageTimer.Start();
                lblError.Text = "*Debe seleccionar un producto.";
                lblError.Visible = true;
            }

            Producto p = logica.SeleccionarPorId(((Producto)cmbProductos.SelectedItem).id);
            int cantidad = Convert.ToInt32(nudCantidad.Value);

            if (count_fila == 0)
            {
                dgvProductos.Rows.Add(p.id, p.nombre, p.marca, p.pesoUnidad, p.precio, p.cantidad, cantidad);
                int cantidadFinal = Convert.ToInt32(dgvProductos.Rows[count_fila].Cells[5].Value) + cantidad;
                dgvProductos.Rows[count_fila].Cells[7].Value = cantidadFinal;
                count_fila++;
                MessageTimer.Start();
                lblError.Visible = false;
                lblSuccess.Text = "*Agregado con éxito.";
                lblSuccess.Visible = true;
                    
            }else
            {
                foreach (DataGridViewRow item in dgvProductos.Rows)
                {
                    if (item.Cells[0].Value.ToString() == (cmbProductos.SelectedIndex + 1).ToString())
                    {
                        existe = true;
                        num_fila = item.Index;
                    }
                }

                if (existe)
                {
                    MessageTimer.Start();
                    lblSuccess.Visible = false;
                    lblError.Text = "*Éste producto ya se encuentra agregado.";
                    lblError.Visible = true;
                }else
                {
                    dgvProductos.Rows.Add(p.id, p.nombre, p.marca, p.pesoUnidad, p.precio, p.cantidad, cantidad);
                    int cantidadFinal = Convert.ToInt32(dgvProductos.Rows[count_fila].Cells[5].Value) + cantidad;
                    dgvProductos.Rows[count_fila].Cells[7].Value = cantidadFinal;
                    count_fila++;
                    MessageTimer.Start();
                    lblError.Visible = false;
                    lblSuccess.Text = "*Agregado con éxito.";
                    lblSuccess.Visible = true;
                }
            }

            cmbProductos.SelectedItem = null ;
            cmbProductos.Text = "";
            nudCantidad.Value = 0;
            dgvProductos.CurrentRow.Selected = false;
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblSuccess.Visible = false;
            MessageTimer.Stop();
        }
        
        private void frmEntradaProductos_Leave(object sender, EventArgs e)
        {
            count_fila = 0;
        }

        private void llenarComboBox()
        {

            cmbProductos.ValueMember = "id";
            cmbProductos.DisplayMember = "nombreMarcaPeso";

            ProductoLogica logica = new ProductoLogica();
            foreach (Producto item in logica.SeleccionarTodos())
            {
                cmbProductos.Items.Add(item);
            }

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            foreach (Producto item in logica.SeleccionarTodos())
            {
                coleccion.Add(item.nombreMarcaPeso);
            }

            cmbProductos.AutoCompleteCustomSource = coleccion;
            cmbProductos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProductos.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
    }
}
