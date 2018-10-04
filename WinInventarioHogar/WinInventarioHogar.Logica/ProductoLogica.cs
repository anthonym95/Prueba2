using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinInventarioHogar.Datos;
using WinInventarioHogar.Entidades;

namespace WinInventarioHogar.Logica
{
    public class ProductoLogica
    {
        private ProductoDatos datos;

        public ProductoLogica()
        {
            this.datos = new ProductoDatos();
        }

        public void Crear(Producto producto)
        {
            foreach (Producto p in SeleccionarTodos())
            {
                if (producto.nombre.ToLower() == p.nombre.ToLower())
                {
                    throw new ApplicationException("El nombre del producto ya se encuentra registrado");
                }
            }

            if (producto.nombre == "")
                throw new ApplicationException("El nombre se encuentra vacío");

            if (producto.marca == "")
                throw new ApplicationException("La marca se encuentra vacío");

            if (producto.peso < 0)
                throw new ApplicationException("Digite un valor igual o mayor a cero");

            if (producto.cantidad < 0)
                throw new ApplicationException("Digite un valor igual o mayor a cero");

            if (producto.precio < 0)
                throw new ApplicationException("Digite un valor igual o mayor a cero");

            if (producto.categoria == null)
                throw new ApplicationException("Debe seleccionar una categoría");


            this.datos.Crear(producto);

        }

        public void Actualizar(Producto producto)
        {
            if (producto.nombre == "")
                throw new ApplicationException("El nombre se encuentra vacío");

            if (producto.cantidad < 0)
                throw new ApplicationException("Digite un valor igual o mayor a cero");

            if (producto.precio < 0)
                throw new ApplicationException("Digite un valor igual o mayor a cero");

            if (producto.categoria == null)
                throw new ApplicationException("Debe seleccionar una categoría");

            this.datos.Actualizar(producto);
        }

        public void Borrar(int id)
        {
            this.datos.Borrar(id);
        }

        public List<Producto> SeleccionarTodos()
        {
            return this.datos.SeleccionarTodos();
        }

        public Producto SeleccionarPorId(int id)
        {
            return this.datos.SeleccionarPorId(id);
        }
    }
}
