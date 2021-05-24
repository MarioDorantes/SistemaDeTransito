using DireccionGeneralDeTránsito.ConexionBD;
using DireccionGeneralDeTránsito.pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DireccionGeneralDeTránsito.DAO
{
    class UsuarioDAOcs
    {
        public static int EliminarUsuario(string nombreUsuario)
        {
            int eliminado = 0;
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    String query = "DELETE from usuario WHERE usr_nombreUsuario=@nombreUsuario";
                    command = new SqlCommand(query, conn);
                    command.Parameters.Add("@nombreUsuario", System.Data.SqlDbType.VarChar,50).Value = nombreUsuario;
                    eliminado = 1;
                    command.ExecuteNonQuery();
                    command.Dispose();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return eliminado;
        }
        public static List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;
                    String query = "SELECT u.Nombre, u.usr_aPaterno, u.usr_aMaterno, u.usr_rol, u.usr_nombreUsuario, d.nombreAlias FROM usuario u "+
                        " INNER JOIN dbo.delegacion d ON u.idDelegacion = d.idDelegacion";
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Nombre = (!dataReader.IsDBNull(0)) ? dataReader.GetString(0) : " ";
                        usuario.ApellidoPaterno = (!dataReader.IsDBNull(1)) ? dataReader.GetString(1) : " ";
                        usuario.ApellidoMaterno = (!dataReader.IsDBNull(2)) ? dataReader.GetString(2) : " ";
                        usuario.TipoUsuario = (!dataReader.IsDBNull(3)) ? dataReader.GetString(3) : " ";
                        usuario.NombreUsuario = (!dataReader.IsDBNull(4)) ? dataReader.GetString(4) : " ";
                        usuario.Delegacion = (!dataReader.IsDBNull(5)) ? dataReader.GetString(5) : " ";
                        usuarios.Add(usuario);
                    }
                    dataReader.Close();
                    command.Dispose();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return usuarios;
        }
        public static int RegistrarUsuario(String nombre, String aPaterno, String aMaterno, String nombreUsuario, String contraseña, int delegacion, String tipoUsuario)
        {
            int usuarioRegistrado = 0;
            SqlConnection conn = null;

            try
            {
                conn = ConexionBD.ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    String query = "INSERT INTO usuario VALUES " +
                        "(@usr_nombreUsuario, @usr_contraseña, @usr_rol, @idDelegacion, @Nombre, @usr_aPaterno, @usr_aMaterno);";
                    command = new SqlCommand(query, conn);
                    command.Parameters.Add("usr_nombreUsuario", System.Data.SqlDbType.VarChar, 50).Value = nombreUsuario;
                    command.Parameters.Add("usr_contraseña", System.Data.SqlDbType.VarChar, 50).Value = contraseña;
                    command.Parameters.Add("usr_rol", System.Data.SqlDbType.VarChar, 50).Value = tipoUsuario;
                    command.Parameters.Add("idDelegacion", System.Data.SqlDbType.VarChar, 50).Value = delegacion;
                    command.Parameters.Add("Nombre", System.Data.SqlDbType.VarChar, 50).Value = nombre;
                    command.Parameters.Add("usr_aPaterno", System.Data.SqlDbType.VarChar, 50).Value = aPaterno;
                    command.Parameters.Add("usr_aMaterno", System.Data.SqlDbType.VarChar, 50).Value = aMaterno;
                    command.ExecuteNonQuery();
                    command.Dispose();
                    usuarioRegistrado = 1;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return usuarioRegistrado;
        }
    }
}
