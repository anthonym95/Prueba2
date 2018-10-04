using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinInventarioHogar.Entidades;

namespace WinInventarioHogar.Datos
{
    public class UsuarioDatos
    {
        public void Crear(Usuario usuario)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_UserCreate";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@name", usuario.nombre);
                comando.Parameters.AddWithValue("@username", usuario.usuario);
                comando.Parameters.AddWithValue("@password", usuario.contrasena);
                comando.Parameters.AddWithValue("@idRoll", usuario.roll.id);

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
        
        public void Actualizar(Usuario usuario)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_UserUpdate";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@id", usuario.id);
                comando.Parameters.AddWithValue("@name", usuario.nombre);
                comando.Parameters.AddWithValue("@username", usuario.usuario);
                comando.Parameters.AddWithValue("@password", usuario.contrasena);
                comando.Parameters.AddWithValue("@idRoll", usuario.roll.id);
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
                string sql = "SP_UserDelete";

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

        public List<Usuario> SeleccionarTodos()
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_UserGetAll";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                // Ejecutar el comando
                MySqlDataReader reader = comando.ExecuteReader();

                // Recorre todas las filas retornadas por el Execute
                List<Usuario> lista = new List<Usuario>();
                while (reader.Read())
                {
                    Rol roll = new Rol();
                    roll.id = Convert.ToInt32(reader["idRoll"]);
                    roll.nombre = reader["nameRoll"].ToString();

                    Usuario usuario = new Usuario();
                    usuario.id = Convert.ToInt32(reader["id"]);
                    usuario.nombre = reader["nameUser"].ToString();
                    usuario.usuario = reader["username"].ToString();
                    usuario.roll = roll;

                    lista.Add(usuario);
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

        public Usuario SeleccionarPorId(int id)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                string sql = "SP_UserGetById";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                // Ejecutar el comando
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Rol roll = new Rol();
                    roll.id = Convert.ToInt32(reader["idRoll"]);
                    roll.nombre = reader["nameRoll"].ToString();

                    Usuario usuario = new Usuario();
                    usuario.id = Convert.ToInt32(reader["id"]);
                    usuario.nombre = reader["nameUser"].ToString();
                    usuario.usuario = reader["username"].ToString();
                    usuario.roll = roll;
                    return usuario;
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

        public Usuario Autenticar(Usuario u)
        {
            // Primer paso: indicar donde se encuentra la base de datos
            MySqlConnection conexion = new MySqlConnection(Conexion.Cadena);
            try
            {

                conexion.Open();
                string sql = "SP_UserLogin";

                // El SqlCommand se encarga de ejecutar el sql enviado en la bd especificada
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@username", u.usuario);
                comando.Parameters.AddWithValue("@password", u.contrasena);

                // Ejecutar el comando
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    
                    Rol roll = new Rol();
                    roll.id = Convert.ToInt32(reader["idRoll"]);
                    roll.nombre = reader["nameRoll"].ToString();

                    Usuario usuario = new Usuario();
                    usuario.id = Convert.ToInt32(reader["id"]);
                    usuario.nombre = reader["nameUser"].ToString();
                    usuario.roll = roll;
                    

                    return usuario;
                }

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
