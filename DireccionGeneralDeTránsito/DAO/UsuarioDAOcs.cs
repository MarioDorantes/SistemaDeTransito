using DireccionGeneralDeTránsito.ConexionBD;
using DireccionGeneralDeTránsito.pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DireccionGeneralDeTránsito.DAO
{
    public class UsuarioDAOcs
    {
        public static Usuario obtenerLogin(String nombreUsuario, String contraseña)
        {
            Usuario user = null;
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;
                    String query = String.Format("SELECT u.usr_nombreUsuario, u.usr_contraseña, u.usr_rol " +
                                                 "FROM usuario u WHERE u.usr_nombreUsuario = '{0}' AND u.usr_contraseña = '{1}';",
                                                 nombreUsuario, contraseña);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();

                    if (dataReader.Read())
                    {
                        user = new Usuario();
                        user.NombreUsuario = (!dataReader.IsDBNull(0)) ? dataReader.GetString(0) : "";
                        user.Contraseña = (!dataReader.IsDBNull(1)) ? dataReader.GetString(1) : "";
                        user.TipoUsuario = (!dataReader.IsDBNull(2)) ? dataReader.GetString(2) : "";
                    }
                    dataReader.Close();
                    command.Dispose();
                    Console.WriteLine(user);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error de inicio");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return user;

        }

        public static Boolean comprobarExistencia(String nombreUsuario)
        {
            Boolean existe = false;
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = ObtenerUsuarios();
            foreach(Usuario usuario in usuarios)
            {
                if (usuario.Nombre.Equals(nombreUsuario))
                {
                    existe = true;
                }
            }
            return existe;
        }

        public static int actualizarInformacionUsuario(String nombre, String aPaterno, String aMaterno, String nombreUsuario, String contraseña, int delegacion, 
            String tipoUsuario, String nombresUsuarioViejo)
        {
            int infoActualizada = 0;
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    String query = "UPDATE dbo.Usuario SET usr_nombreUsuario=@nombreUsuario, usr_contraseña=@contraseña, usr_rol=@tipoUsuario, idDelegacion=@idDelegacion," +
                        " usr_nombre=@nombre, usr_aPaterno=@aPaterno, usr_aMaterno=@aMaterno WHERE usr_nombreUsuario=@nombreUsuarioViejo;";
                    command = new SqlCommand(query, conn);
                    command.Parameters.Add("@nombreUsuario", System.Data.SqlDbType.VarChar, 50).Value = nombreUsuario;
                    command.Parameters.Add("@contraseña", System.Data.SqlDbType.VarChar, 50).Value = contraseña;
                    command.Parameters.Add("@idDelegacion", System.Data.SqlDbType.Int).Value = delegacion;
                    command.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 50).Value = nombre;
                    command.Parameters.Add("@aPaterno", System.Data.SqlDbType.VarChar, 50).Value = aPaterno;
                    command.Parameters.Add("@aMaterno", System.Data.SqlDbType.VarChar, 50).Value = aMaterno;
                    command.Parameters.Add("@tipoUsuario", System.Data.SqlDbType.VarChar,50).Value = tipoUsuario;
                    command.Parameters.Add("@nombreUsuarioViejo", System.Data.SqlDbType.VarChar, 50).Value = nombresUsuarioViejo;
                    infoActualizada = 1;
                    command.ExecuteNonQuery();
                    command.Dispose();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                infoActualizada = 0;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return infoActualizada;
        }
        
        public static int ValidarUsuariosDelegacion(int idDelegacion)
        {
            List<Usuario> usuarios = new List<Usuario>();
            int tieneUsuarios = 0;
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;
                    String query = String.Format("SELECT usr_nombreUsuario FROM usuario WHERE idDelegacion= {0}", idDelegacion);
                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Nombre = (!dataReader.IsDBNull(0)) ? dataReader.GetString(0) : " ";
                        usuarios.Add(usuario);
                    }
                    if (usuarios.Count() > 0)
                    {
                        tieneUsuarios = 1;
                    }
                    else
                    {
                        tieneUsuarios = 0;
                    }
                    dataReader.Close();
                    command.Dispose();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                tieneUsuarios = 0;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return tieneUsuarios;
        }
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
                    String query = "SELECT u.usr_nombre, u.usr_aPaterno, u.usr_aMaterno, u.usr_rol, u.usr_nombreUsuario, d.nombreAlias FROM usuario u "+
                        " INNER JOIN dbo.delegacion d ON u.idDelegacion = d.idDelegacion";
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
                        "(@usr_nombreUsuario, @usr_nombre, @usr_aPaterno, @usr_aMaterno,  @usr_rol, @usr_contraseña, @idDelegacion);";
                    command = new SqlCommand(query, conn);
                    command.Parameters.Add("usr_nombreUsuario", System.Data.SqlDbType.VarChar, 50).Value = nombreUsuario;
                    command.Parameters.Add("usr_contraseña", System.Data.SqlDbType.VarChar, 50).Value = contraseña;
                    command.Parameters.Add("usr_rol", System.Data.SqlDbType.VarChar, 50).Value = tipoUsuario;
                    command.Parameters.Add("idDelegacion", System.Data.SqlDbType.Int).Value = delegacion;
                    command.Parameters.Add("usr_nombre", System.Data.SqlDbType.VarChar, 50).Value = nombre;
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
