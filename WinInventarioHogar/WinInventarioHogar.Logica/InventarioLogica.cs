using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinInventarioHogar.Datos;
using WinInventarioHogar.Entidades;

namespace WinInventarioHogar.Logica
{
    public class InventarioLogica
    {
        InventarioDatos datos;

        public InventarioLogica()
        {
            this.datos = new InventarioDatos();
        }

        public void EntradaProductos(Inventario inventario)
        {
            if (inventario.producto == null)
                throw new ApplicationException("Usuario no disponible");

            this.datos.EntradaProductos(inventario);

        }
        public void SalidaProductos(Inventario inventario)
        {
            if (inventario.producto == null)
                throw new ApplicationException("Usuario no disponible");

            this.datos.SalidaProductos(inventario);

        }
        public void CrearEntradaProductos(Usuario usuario)
        {
            if (usuario == null)
                throw new ApplicationException("Usuario no disponible");

            this.datos.CrearEntradaProductos(usuario);

        }
        public void CrearSalidaProductos(Usuario usuario)
        {
            if (usuario == null)
                throw new ApplicationException("Usuario no disponible");

            this.datos.CrearSalidaProductos(usuario);

        }


    }
}
