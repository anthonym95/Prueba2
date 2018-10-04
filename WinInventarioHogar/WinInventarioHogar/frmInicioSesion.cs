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

namespace WinInventarioHogar
{
    public partial class frmInicioSesion : Form
    {
        Usuario user;
    
        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.usuario =  txtUser.Text;
                usuario.contrasena = txtPassword.Text;

                UsuarioLogica logica = new UsuarioLogica();


                if (logica.Autentificar(usuario) !=null)
                {
                    Usuario usuarioDatos = logica.Autentificar(usuario);
                    user = logica.Autentificar(usuario);
                    this.Hide();
                    frmPrincipal principal = new frmPrincipal(usuarioDatos);
                    principal.Show();
                }
                else
                {
                    MessageBox.Show("Datos incorrectos");
                }
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    Usuario usuario = new Usuario();
                    usuario.usuario = txtUser.Text;
                    usuario.contrasena = txtPassword.Text;

                    UsuarioLogica logica = new UsuarioLogica();


                    if (logica.Autentificar(usuario) != null)
                    {
                        Usuario usuarioDatos = logica.Autentificar(usuario);
                        user = logica.Autentificar(usuario);
                        this.Hide();
                        frmPrincipal principal = new frmPrincipal(usuarioDatos);
                        principal.Show();
                    }
                    else
                    {
                        MessageBox.Show("Datos incorrectos");
                    }
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    Usuario usuario = new Usuario();
                    usuario.usuario = txtUser.Text;
                    usuario.contrasena = txtPassword.Text;

                    UsuarioLogica logica = new UsuarioLogica();


                    if (logica.Autentificar(usuario) != null)
                    {
                        Usuario usuarioDatos = logica.Autentificar(usuario);
                        user = logica.Autentificar(usuario);
                        this.Hide();
                        frmPrincipal principal = new frmPrincipal(usuarioDatos);
                        principal.Show();
                    }
                    else
                    {
                        MessageBox.Show("Datos incorrectos");
                    }
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Nombre de Usuario")
            {
                txtUser.Text = "";

                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Nombre de Usuario";

                txtUser.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Contraseña")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Contraseña";
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.ForeColor = Color.Gray;
            }
        }

    }
}
