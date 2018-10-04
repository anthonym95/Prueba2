using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinInventarioHogar.Entidades;

namespace WinInventarioHogar.Datos
{
    public class RolDatos
    {
        public void Crear(Rol rol)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_RolCreate";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@name", rol.nombre);

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

        public void Actualizar(Rol rol)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_RolUpdate";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@id", rol.id);
                comando.Parameters.AddWithValue("@name", rol.nombre);
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
                string sql = "SP_RolDelete";

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

        public List<Rol> SeleccionarTodos()
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_RolGetAll";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                // Ejecutar el comando
                MySqlDataReader reader = comando.ExecuteReader();

                // Recorre todas las filas retornadas por el Execute
                List<Rol> lista = new List<Rol>();
                while (reader.Read())
                {
                    Rol rol = new Rol();
                    rol.id = Convert.ToInt32(reader["id"]);
                    rol.nombre = reader["name"].ToString();
                    lista.Add(rol);
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

        public Rol SeleccionarPorId(int id)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_RolGetById";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                // Ejecutar el comando
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Rol rol = new Rol();
                    rol.id = Convert.ToInt32(reader["id"]);
                    rol.nombre = reader["name"].ToString();

                    return rol;
                }
                // Si no encuentra una categoria retorna null;
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
