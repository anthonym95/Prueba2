using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinInventarioHogar.Logica;
using WinInventarioHogar.Entidades;

namespace WinInventarioHogar.Administrador
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.DefaultCellStyle.Font = new Font("Tahoma", 13);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 13);
            UsuarioLogica logica = new UsuarioLogica();
            dgvUsuarios.DataSource = logica.SeleccionarTodos();
            cmbRoll.SelectedIndex = 0;
            llenarComboBox();
            txtId.Text = "0";
        }
        
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value);
                UsuarioLogica logica = new UsuarioLogica();
                Usuario usuario = logica.SeleccionarPorId(id);
                txtNombre.Text = usuario.nombre;
                txtUsuario.Text = usuario.usuario;
                txtContrasena.Text = "";
                cmbRoll.SelectedIndex = usuario.idRoll;

                txtId.Text = id.ToString();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario de la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                RolLogica logicaRoll = new RolLogica();
                UsuarioLogica logicaUsuario = new UsuarioLogica();

                
                Usuario usuario = new Usuario();
                
                usuario.nombre = txtNombre.Text;
                usuario.usuario = txtUsuario.Text;
                usuario.contrasena = txtContrasena.Text;
                usuario.roll = logicaRoll.SeleccionarPorId(cmbRoll.SelectedIndex);

                Usuario u = logicaUsuario.SeleccionarPorId(Convert.ToInt32(txtId.Text));

                if ( u != null)
                {
                    usuario.id = Convert.ToInt32(txtId.Text);
                    logicaUsuario.Actualizar(usuario);
                }
                else
                {
                    logicaUsuario.Crear(usuario);
                }
                dgvUsuarios.DataSource = logicaUsuario.SeleccionarTodos();
                dgvUsuarios.CurrentRow.Selected = false;
                MessageTimer.Start();
                lblSuccess.Text = "*Guardado con éxito";
                lblSuccess.Visible = true;
            }
            catch (Exception ex)
            {
                lblError.Text = "*"+ ex.Message;
                lblError.Visible = true;
                MessageTimer.Start();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                UsuarioLogica logica = new UsuarioLogica();
                bool estado = MessageBox.Show("Esta seguro que desea borrar este usuario?.", "Esta seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                if (estado)
                {
                    int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value);
                    logica.Borrar(id);
                    
                }
                dgvUsuarios.DataSource = logica.SeleccionarTodos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario de la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Text = "0";
            txtNombre.Text = "";
            txtContrasena.Text = "";
            txtUsuario.Text = "";
            cmbRoll.SelectedIndex = 0;
        }


        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblSuccess.Visible = false;
            MessageTimer.Stop();
        }

        private void frmUsuarios_Click(object sender, EventArgs e)
        {
            txtId.Text = "0";
            txtNombre.Text = "";
            txtContrasena.Text = "";
            txtUsuario.Text = "";
            cmbRoll.SelectedIndex = 0;
            dgvUsuarios.CurrentRow.Selected = false;
        }

        private void llenarComboBox()
        {
            RolLogica logica = new RolLogica();
            foreach (Rol item in logica.SeleccionarTodos())
            {
                cmbRoll.Items.Add(item);
            }
            cmbRoll.DisplayMember = "nombre";
            cmbRoll.ValueMember = "id";
        }
    }
}
