using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinInventarioHogar.Entidades;

namespace WinInventarioHogar.Datos
{
    public class ProductoDatos
    {
        public void Crear(Producto producto)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_ProductCreate";
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                
                comando.Parameters.AddWithValue("@name", producto.nombre);
                comando.Parameters.AddWithValue("@brand", producto.marca);
                comando.Parameters.AddWithValue("@weight", producto.peso);
                comando.Parameters.AddWithValue("@unit", producto.unidad);
                comando.Parameters.AddWithValue("@price", producto.precio);
                comando.Parameters.AddWithValue("@quantity", producto.cantidad);
                comando.Parameters.AddWithValue("@idCategory", producto.categoria.id);
                comando.Parameters.AddWithValue("@minQuantity", producto.minCantidad);

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
        
        public void Actualizar(Producto producto)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "SP_ProductUpdate";
                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", producto.id);
                comando.Parameters.AddWithValue("@name", producto.nombre);
                comando.Parameters.AddWithValue("@brand", producto.marca);
                comando.Parameters.AddWithValue("@weight", producto.peso);
                comando.Parameters.AddWithValue("@unit", producto.unidad);
                comando.Parameters.AddWithValue("@price", producto.precio);
                comando.Parameters.AddWithValue("@quantity", producto.cantidad);
                comando.Parameters.AddWithValue("@minQuantity", producto.minCantidad);
                comando.Parameters.AddWithValue("@idCategory", producto.categoria.id);


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

        public void Borrar(int id)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "SP_ProductDelete";
                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                // Ejecutar el comando
                comando.ExecuteNonQuery();
                //Si no encuentra una categoria retorna null;
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

        public List<Producto> SeleccionarTodos()
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "SP_ProductGetAll";
                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                // Ejecutar el comando
                MySqlDataReader reader = comando.ExecuteReader();

                // Recorre todas las filas retornadas por el Execute
                List<Producto> lista = new List<Producto>();
                while (reader.Read())
                {
                    Producto producto = new Producto();

                    producto.id = Convert.ToInt32(reader["id"]);
                    producto.nombre = reader["nameProduct"].ToString();
                    producto.marca = reader["brand"].ToString();
                    producto.peso = Convert.ToDecimal(reader["weight"]);
                    producto.unidad = reader["unit"].ToString();
                    producto.precio = Convert.ToDecimal(reader["price"]);
                    producto.cantidad = Convert.ToInt32(reader["quantity"]);
                    producto.categoria.id = Convert.ToInt32(reader["idCategory"]);
                    producto.minCantidad = Convert.ToInt32(reader["minQuantity"]);
                    producto.categoria.nombre = reader["nameCategory"].ToString();

                    lista.Add(producto);
                }

                return lista;
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

        public Producto SeleccionarPorId(int id)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "SP_ProductGetById";
                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                // Ejecutar el comando
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.id = Convert.ToInt32(reader["id"]);
                    producto.nombre = reader["nameProduct"].ToString();
                    producto.marca = reader["brand"].ToString();
                    producto.peso = Convert.ToDecimal(reader["weight"]);
                    producto.unidad = reader["unit"].ToString();
                    producto.precio = Convert.ToDecimal(reader["price"]);
                    producto.cantidad = Convert.ToInt32(reader["quantity"]);
                    producto.categoria.id = Convert.ToInt32(reader["idCategory"]);
                    producto.categoria.nombre = reader["nameCategory"].ToString();
                    producto.minCantidad = Convert.ToInt32(reader["minQuantity"]);

                    return producto;
                }
                //Si no encuentra una categoria retorna null;
                return null;
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
