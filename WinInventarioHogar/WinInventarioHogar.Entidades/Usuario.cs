using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinInventarioHogar.Entidades
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public Rol roll { get; set; }

        public string nombreRoll
        {
            get { return roll.nombre; }
        }

        public int idRoll
        {
            get { return roll.id; }
        }
    }
}
