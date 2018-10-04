using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WinInventarioHogar.Datos
{
    public class Conexion
    {
        /// <summary>
        /// Retorna la cadena de conexion con la base de datos sql server
        /// </summary>
        public static string Cadena
        {
            get
            {
                // Obtenemos la cadena de conexion del archivo app.config
                return ConfigurationManager.ConnectionStrings["WinInventarioHogar.Properties.Settings.Conexion"].ConnectionString;
            }
        }
    }
}
