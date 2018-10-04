using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinInventarioHogar.Datos;
using WinInventarioHogar.Entidades;

namespace WinInventarioHogar.Logica
{
    public class CategoriaLogica
    {
        CategoriaDatos datos;

        public CategoriaLogica()
        {
            datos = new CategoriaDatos();
        }

        public void Crear(Categoria categoria)
        {
            foreach (Categoria c in SeleccionarTodos())
            {
                if (categoria.nombre.ToLower() == c.nombre.ToLower())
                {
                    throw new ApplicationException("El nombre de categoría ya se encuentra registrado");
                }
            }

            if (string.IsNullOrEmpty(categoria.nombre))
                throw new ApplicationException("El nombre se encuentra vacío");

            this.datos.Crear(categoria);

        }

        public void Actualizar(Categoria categoria)
        {
            if (categoria.nombre == "")
                throw new ApplicationException("El nombre se encuentra vacío");

            this.datos.Actualizar(categoria);
        }

        public List<Categoria> SeleccionarTodos()
        {
            return this.datos.SeleccionarTodos();
        }

        public Categoria SeleccionarPorId(int id)
        {
            return this.datos.SeleccionarPorId(id);
        }

        public void Borrar(int id)
        {
            this.datos.Borrar(id);
        }
    }
}
