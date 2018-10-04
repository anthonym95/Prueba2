using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinInventarioHogar.Entidades
{
    public class Inventario
    {
        public Producto producto { get; set; }
        public int cantidad { get; set; }
        public int minCantidad { get; set; }
        public Inventario()
        {
            producto = new Producto();
        }
    }
}
