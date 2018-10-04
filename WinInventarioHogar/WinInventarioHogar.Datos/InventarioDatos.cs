using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinInventarioHogar.Entidades;

namespace WinInventarioHogar.Datos
{
    public class InventarioDatos
    {
        public void EntradaProductos(Inventario inventario)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_ProductIn";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idProduct", inventario.producto.id);
                comando.Parameters.AddWithValue("@quantity", inventario.cantidad);
                comando.Parameters.AddWithValue("@minQuantity", inventario.minCantidad);

                // Ejecutar el comando
                comando.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        public void SalidaProductos(Inventario inventario)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_ProductOut";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                
                comando.Parameters.AddWithValue("@idProduct", inventario.producto.id);
                comando.Parameters.AddWithValue("@quantity", inventario.cantidad);
                comando.Parameters.AddWithValue("@minQuantity", inventario.minCantidad);

                // Ejecutar el comando
                comando.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        public void CrearEntradaProductos(Usuario usuario)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_ProductInCreate";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@idUser", usuario.id);

                // Ejecutar el comando
                comando.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        public void CrearSalidaProductos(Usuario usuario)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_ProductOutCreate";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@idUser", usuario.id);

                // Ejecutar el comando
                comando.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        
    }
}
