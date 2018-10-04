using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinInventarioHogar.Entidades;
using WinInventarioHogar.Logica;

namespace WinInventarioHogar.Administrador
{
    public partial class frmCategoriasRoles : Form
    {
        public frmCategoriasRoles()
        {
            InitializeComponent();
        }

        private void frmCategoriasRoles_Load(object sender, EventArgs e)
        {
            this.dgvConfigs();
            CategoriaLogica categoriaLogica = new CategoriaLogica();
            RolLogica rolLogica = new RolLogica();
            dgvCategorias.DataSource = categoriaLogica.SeleccionarTodos();
            dgvRoles.DataSource = rolLogica.SeleccionarTodos();
            cmbTipo.SelectedIndex = 0;
            txtId.Text = "0";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------------------\\
                // ACTUALIZAR O CREAR ROLES O CATEGORÍAS \\
                //---------------------------------------\\

                ////// ROLES //////
                if (cmbTipo.SelectedIndex == 2)
                {
                    RolLogica logicaRol = new RolLogica();
                    // Nuevo Rol
                    Rol rol = new Rol();
                    rol.nombre = txtNombre.Text;

                    // Actualizar o Crear Rol
                    Rol r = logicaRol.SeleccionarPorId(Convert.ToInt32(txtId.Text));
                    if (r != null)
                    {
                        rol.id = Convert.ToInt32(txtId.Text);
                        logicaRol.Actualizar(rol);
                        dgvRoles.DataSource = logicaRol.SeleccionarTodos();
                    }
                    else
                    {
                        logicaRol.Crear(rol);
                        dgvRoles.DataSource = logicaRol.SeleccionarTodos();
                    }
                }
                else
                {
                    ////// CATEGORÍAS //////
                    if (cmbTipo.SelectedIndex == 1)
                    {
                        CategoriaLogica logicaCategoria = new CategoriaLogica();
                        // Nueva Categoría
                        Categoria categoria = new Categoria();
                        categoria.nombre = txtNombre.Text;

                        // Actualizar o Crear Categoría
                        Categoria c = logicaCategoria.SeleccionarPorId(Convert.ToInt32(txtId.Text));

                        
                        if (c !=null)
                        {
                            categoria.id = Convert.ToInt32(txtId.Text);
                            logicaCategoria.Actualizar(categoria);
                            dgvCategorias.DataSource = logicaCategoria.SeleccionarTodos();
                        }
                        else
                        {
                            logicaCategoria.Crear(categoria);
                            dgvCategorias.DataSource = logicaCategoria.SeleccionarTodos();
                        }
                    }else
                    {
                        MessageTimer.Start();
                        lblError.Text = "*Debe seleccionar un tipo";
                        lblError.Visible = true;
                    }
                }

                cmbTipo.Enabled = true;
                MessageTimer.Start();
                lblSuccess.Text = "*Guardado con éxito";
                lblSuccess.Visible = true;
                txtId.Text = "0";
                cmbTipo.Enabled = true;
                txtNombre.Text = "";
                cmbTipo.SelectedIndex = 0;
                dgvRoles.CurrentRow.Selected = false;
                dgvCategorias.CurrentRow.Selected = false;
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
            cmbTipo.Enabled = false;
            if (dgvCategorias.SelectedRows.Count > 0 || dgvRoles.SelectedRows.Count > 0)
            {
                if (dgvCategorias.SelectedRows.Count > 0)
                {
                    int idCategoria = Convert.ToInt32(dgvCategorias.CurrentRow.Cells[0].Value);
                    CategoriaLogica logicaCategoria = new CategoriaLogica();
                    Categoria categoria = logicaCategoria.SeleccionarPorId(idCategoria);
                    txtId.Text = categoria.id.ToString();
                    txtNombre.Text = categoria.nombre;
                    cmbTipo.SelectedIndex = 1;
                }

                if (dgvRoles.SelectedRows.Count > 0)
                {
                    int idRol = Convert.ToInt32(dgvRoles.CurrentRow.Cells[0].Value);
                    RolLogica logicaRol = new RolLogica();
                    Rol rol = logicaRol.SeleccionarPorId(idRol);
                    txtId.Text = rol.id.ToString();
                    txtNombre.Text = rol.nombre;
                    cmbTipo.SelectedIndex = 2;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una elemento de alguna de las tablas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0 || dgvRoles.SelectedRows.Count > 0)
            {
                // si esta seleccionado un elemento de la tabla categorías
                if (dgvCategorias.SelectedRows.Count > 0)
                {
                    bool estadoCategoria = MessageBox.Show("¿Esta seguro que desea borrar esta categoría?.", "¿Esta seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                    if (estadoCategoria)
                    {
                        int id = Convert.ToInt32(dgvCategorias.CurrentRow.Cells[0].Value);
                        CategoriaLogica logica = new CategoriaLogica();
                        logica.Borrar(id);
                        dgvCategorias.DataSource = logica.SeleccionarTodos();
                    }
                    return;
                }
                else
                {
                    // si esta seleccionado un elemento de la tabla roles
                    if (dgvRoles.SelectedRows.Count > 0)
                    {
                        bool estadoRol = MessageBox.Show("¿Esta seguro que desea borrar este rol?.", "¿Esta seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                        if (estadoRol)
                        {
                            int id = Convert.ToInt32(dgvRoles.CurrentRow.Cells[0].Value);
                            RolLogica logica = new RolLogica();
                            logica.Borrar(id);
                            dgvRoles.DataSource = logica.SeleccionarTodos();
                        }
                        return;
                    }
                }

                
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento de alguna de las tablas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Text = "0";
            cmbTipo.Enabled = true;
            txtNombre.Text = "";
            cmbTipo.SelectedIndex = 0;
        }

        private void frmCategoriasRoles_Click(object sender, EventArgs e)
        {
            txtId.Text = "0";
            cmbTipo.Enabled = true;
            txtNombre.Text = "";
            cmbTipo.SelectedIndex = 0;
            dgvRoles.CurrentRow.Selected = false;
            dgvCategorias.CurrentRow.Selected = false;
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblSuccess.Visible = false;
            MessageTimer.Stop();
        }

        private void dgvCategorias_Click(object sender, EventArgs e)
        {
            dgvRoles.CurrentRow.Selected = false;
        }

        private void dgvRoles_Click(object sender, EventArgs e)
        {
            dgvCategorias.CurrentRow.Selected = false;
        }

        private void dgvConfigs()
        {
            dgvRoles.AutoGenerateColumns = false;
            dgvRoles.DefaultCellStyle.Font = new Font("Tahoma", 13);
            dgvRoles.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 13);
            dgvCategorias.AutoGenerateColumns = false;
            dgvCategorias.DefaultCellStyle.Font = new Font("Tahoma", 13);
            dgvCategorias.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 13);
        }

    }
}
