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
    public partial class frmAgregarProductos : Form
    {
        public frmAgregarProductos()
        {
            InitializeComponent();
        }

        private void frmAgregarProductos_Load(object sender, EventArgs e)
        {
            ProductoLogica logica = new ProductoLogica();

            //configuración del DataGridView Productos
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.DefaultCellStyle.Font = new Font("Tahoma", 13);
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 13);
            dgvProductos.DataSource = logica.SeleccionarTodos();

            //Reseteo de controles del frame
            cmbArea.SelectedIndex = 0;
            cmbMedida.SelectedIndex = 0;
            llenarComboBox();
            txtId.Text = "0";
            txtPeso.Text = "0";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Text = "0";
            txtNombre.Text = "";
            txtMarca.Text = "";
            txtCantidad.Value = 0;
            txtPrecio.Text = "0";
            txtPeso.Text = "0";
            txtMinCantidad.Value = 0;
            cmbMedida.SelectedIndex = 0;
            cmbArea.SelectedIndex = 0;
        }

        private void llenarComboBox()
        {
            CategoriaLogica logica = new CategoriaLogica();
            foreach (Categoria item in logica.SeleccionarTodos())
            {
                cmbArea.Items.Add(item);
            }
            cmbArea.DisplayMember = "nombre";
            cmbArea.ValueMember = "id";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaLogica logicaCategoria = new CategoriaLogica();
                ProductoLogica logicaProducto = new ProductoLogica();


                Producto producto = new Producto();

                producto.nombre = txtNombre.Text;
                producto.marca = txtMarca.Text;

                string unidad = cmbMedida.SelectedIndex == 0 ? "Kg" :
                                cmbMedida.SelectedIndex == 1 ? "g" :
                                cmbMedida.SelectedIndex == 2 ? "mL" :
                                cmbMedida.SelectedIndex == 3 ? "L" :
                                cmbMedida.SelectedIndex == 4 ? "oz" : "Kg";

                int cantidad = 0;
                int minCantidad = 0;
                decimal precio = 0m;
                decimal peso = 0m;

                if (!int.TryParse(txtMinCantidad.Text, out minCantidad) ||
                    !int.TryParse(txtCantidad.Text, out cantidad) ||
                    !decimal.TryParse(txtPrecio.Text, out precio) ||
                    !decimal.TryParse(txtPeso.Text, out peso))
                {
                    lblError.Text = "*Debe ser un valor numérico."; lblError.Visible = true;
                }

                producto.peso = peso;
                producto.unidad = unidad;
                producto.cantidad = cantidad;
                producto.minCantidad = minCantidad;
                producto.precio = precio;
                producto.categoria = logicaCategoria.SeleccionarPorId(cmbArea.SelectedIndex);

                Producto p = logicaProducto.SeleccionarPorId(Convert.ToInt32(txtId.Text));

                if (p != null)
                {
                    producto.id = Convert.ToInt32(txtId.Text);
                    logicaProducto.Actualizar(producto);
                }
                else
                {
                    logicaProducto.Crear(producto);
                }


                dgvProductos.DataSource = logicaProducto.SeleccionarTodos();
                dgvProductos.CurrentRow.Selected = false;
                MessageTimer.Start();
                lblSuccess.Text = "*Guardado con éxito.";
                lblSuccess.Visible = true;
                btnLimpiar_Click(this,null);
            }
            catch (Exception ex)
            {
                lblError.Text = "*" + ex.Message;
                lblError.Visible = true;
                MessageTimer.Start();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.SelectedRows.Count > 0)
                {
                    ProductoLogica logica = new ProductoLogica();
                    bool estado = MessageBox.Show("Esta seguro que desea borrar este producto?.", "Esta seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                    if (estado)
                    {
                        int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
                        logica.Borrar(id);

                    }
                    dgvProductos.DataSource = logica.SeleccionarTodos();
                    lblSuccess.Text = "*Se eliminó satisfactoriamente.";
                    lblSuccess.Visible = true;
                    MessageTimer.Start();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un producto de la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "*" + ex.Message;
                lblError.Visible = true;
                MessageTimer.Start();
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
                ProductoLogica logica = new ProductoLogica();
                Producto producto = logica.SeleccionarPorId(id);
                txtId.Text = id.ToString();
                txtNombre.Text = producto.nombre;
                txtMarca.Text = producto.marca;
                txtCantidad.Text = producto.cantidad.ToString();
                txtPeso.Text = producto.peso.ToString();
                txtPrecio.Text = producto.precio.ToString();
                txtMinCantidad.Text = producto.minCantidad.ToString();
                cmbArea.SelectedIndex = producto.idCategoria;

                int unidad = producto.unidad == "Kg" ? 0 : 
                             producto.unidad == "g" ? 1 : 
                             producto.unidad == "mL" ? 2 : 
                             producto.unidad == "L" ? 3 : 
                             producto.unidad == "oz" ? 4 : 0;

                cmbMedida.SelectedIndex = unidad;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto de la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblSuccess.Visible = false;
            MessageTimer.Stop();
        }


    }
}
