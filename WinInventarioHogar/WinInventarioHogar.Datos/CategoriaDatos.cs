using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinInventarioHogar.Entidades;

namespace WinInventarioHogar.Datos
{
    public class CategoriaDatos
    {
        public void Crear(Categoria categoria)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_CategoryCreate";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@name", categoria.nombre);

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

        public void Actualizar(Categoria categoria)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_CategoryUpdate";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@id", categoria.id);
                comando.Parameters.AddWithValue("@name", categoria.nombre);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

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
                string sql = "SP_CategoryDelete";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

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

        public List<Categoria> SeleccionarTodos()
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_CategoryGetAll";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                // Ejecutar el comando
                MySqlDataReader reader = comando.ExecuteReader();

                // Recorre todas las filas retornadas por el Execute
                List<Categoria> lista = new List<Categoria>();
                while (reader.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.id = Convert.ToInt32(reader["id"]);
                    categoria.nombre = reader["name"].ToString();
                    lista.Add(categoria);
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

        public Categoria SeleccionarPorId(int id)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_CategoryGetById";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                // Ejecutar el comando
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.id = Convert.ToInt32(reader["id"]);
                    categoria.nombre = reader["name"].ToString();

                    return categoria;
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
