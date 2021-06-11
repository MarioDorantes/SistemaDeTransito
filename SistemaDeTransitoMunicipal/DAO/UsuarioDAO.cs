using SistemaDeTransitoMunicipal.conexionBD;
using SistemaDeTransitoMunicipal.pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SistemaDeTransitoMunicipal.DAO
{
    class UsuarioDAO
    {
        public static Usuario obtenerLogin(String nombreUsuario, String contraseña)
        {
            Usuario user = null;
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    //ESTE LA PREPARA
                    SqlCommand command;
                    //ESTE LA EJECUTA
                    SqlDataReader dataReader;
                    String query = String.Format("SELECT u.usr_nombreUsuario, u.usr_contraseña, u.usr_rol, idDelegacion " +
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
                        user.Rol = (!dataReader.IsDBNull(2)) ? dataReader.GetString(2) : "";
                        user.IdDelegacion = (!dataReader.IsDBNull(3)) ? dataReader.GetInt32(3) : 0;
                    }
                    dataReader.Close();
                    command.Dispose();
                    Console.WriteLine(user);
                }
            }
            catch (Exception e)
            {
               MessageBox.Show("Error en la Base de Datos", "Ocurrió un error");
               Console.WriteLine(e.Message);
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
    }
}
