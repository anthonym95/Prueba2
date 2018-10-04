using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinInventarioHogar.Entidades
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public decimal peso { get; set; }
        public string unidad { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public int minCantidad { get; set; }
        public Categoria categoria { get; set; }

        public Producto()
        {
            categoria = new Categoria(); 
        }

        public string nombreCategoria
        {
            get { return categoria.nombre; }
        }

        public int idCategoria
        {
            get { return categoria.id; }
        }

        public string pesoUnidad
        {
            get { return peso.ToString() + " " + unidad; }
        }

        public string nombreMarcaPeso
        {
            get { return nombre + " " + marca + " " + pesoUnidad; }
        }
    }
}
