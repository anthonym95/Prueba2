using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinInventarioHogar.Datos;
using WinInventarioHogar.Entidades;

namespace WinInventarioHogar.Logica
{
    public class RolLogica
    {
        RolDatos datos;

        public RolLogica()
        {
            datos = new RolDatos();
        }

        public void Crear(Rol rol)
        {
            foreach (Rol r in SeleccionarTodos())
            {
                if (rol.nombre.ToLower() == r.nombre.ToLower())
                {
                    throw new ApplicationException("El nombre de rol ya se encuentra registrado");
                }
            }

            if (string.IsNullOrEmpty(rol.nombre))
                throw new ApplicationException("El nombre se encuentra vacío");

            this.datos.Crear(rol);

        }

        public void Actualizar(Rol rol)
        {
            if (rol.nombre == "")
                throw new ApplicationException("El nombre se encuentra vacío");

            this.datos.Actualizar(rol);
        }

        public List<Rol> SeleccionarTodos()
        {
            return this.datos.SeleccionarTodos();
        }

        public Rol SeleccionarPorId(int id)
        {
            return this.datos.SeleccionarPorId(id); 
        }

        public void Borrar(int id)
        {
            this.datos.Borrar(id);
        }
    }
}
