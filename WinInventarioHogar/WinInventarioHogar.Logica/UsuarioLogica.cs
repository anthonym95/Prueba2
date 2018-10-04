using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinInventarioHogar.Entidades;
using WinInventarioHogar.Datos;

namespace WinInventarioHogar.Logica
{
    public class UsuarioLogica
    {
        private UsuarioDatos datos;

        public UsuarioLogica()
        {
            this.datos = new UsuarioDatos();
        }

        public void Crear(Usuario usuario)
        {
            foreach (Usuario u in SeleccionarTodos())
            {
                if(usuario.usuario == u.usuario)
                {
                    throw new ApplicationException("El nombre de usuario ya se encuentra registrado");
                }
            }

            if(usuario.nombre == "")
                throw new ApplicationException("El nombre se encuentra vacío");

            if (usuario.usuario == "")
                throw new ApplicationException("El nombre de usuario se encuentra vacío");

            if (usuario.roll == null)
                throw new ApplicationException("Debe seleccionar un roll");


            this.datos.Crear(usuario);

        }

        public void Actualizar(Usuario usuario)
        {
            if (usuario.nombre == "")
                throw new ApplicationException("El nombre se encuentra vacío");

            if (usuario.usuario == "")
                throw new ApplicationException("El nombre de usuario se encuentra vacío");

            if (usuario.roll == null)
                throw new ApplicationException("Debe seleccionar un roll");

            this.datos.Actualizar(usuario);
        }

        public void Borrar(int id)
        {
            this.datos.Borrar(id);
        }

        public Usuario Autentificar(Usuario usuario)
        {
            if (usuario.usuario == "")
                throw new ApplicationException("Debe ingresar el nombre de Usuario");
            if (usuario.contrasena == "")
                throw new ApplicationException("Debe ingresar la contraseña de Usuario");

            return this.datos.Autenticar(usuario);
        }

        public List<Usuario> SeleccionarTodos()
        {
            return this.datos.SeleccionarTodos();
        }

        public Usuario SeleccionarPorId(int id)
        {
            return this.datos.SeleccionarPorId(id);
        }

        
    }
}
