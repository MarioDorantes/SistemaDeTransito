using DireccionGeneralDeTránsito.pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneralDeTránsito.DAO
{
    class DelegacionDAO
    {
        public static int ActualizarDelegacion(String nombreDelegacion, String colonia, String codigoPostal, String correo, String calleNum, 
            string numeroTel, String municipio, int idDelegacion)
        {
            int infoActualizada = 0;
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    String query = "UPDATE dbo.delegacion SET nombreAlias=@nombreAlias, colonia=@colonia, codigPostal=@codigoPostal, correo=@correo," +
                        " calle=@calle, telefono=@telefono, municipio=@municipio WHERE idDelegacion=@idDelegacion";
                    command = new SqlCommand(query, conn);
                    command.Parameters.Add("@nombreAlias", System.Data.SqlDbType.VarChar, 50).Value = nombreDelegacion;
                    command.Parameters.Add("@colonia", System.Data.SqlDbType.VarChar, 50).Value = colonia;
                    command.Parameters.Add("@codigoPostal", System.Data.SqlDbType.VarChar, 50).Value = codigoPostal;
                    command.Parameters.Add("@correo", System.Data.SqlDbType.VarChar, 50).Value = correo;
                    command.Parameters.Add("@calle", System.Data.SqlDbType.VarChar, 50).Value = calleNum;
                    command.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar, 50).Value = numeroTel;
                    command.Parameters.Add("@municipio", System.Data.SqlDbType.VarChar, 50).Value = municipio;
                    command.Parameters.Add("@idDelegacion", System.Data.SqlDbType.VarChar, 50).Value = idDelegacion;
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
        public static int EliminarDelegacion(int idDelegacion)
        {
            int eliminado = 0;
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    String query = "DELETE from dbo.delegacion WHERE idDelegacion = @idDelegacion";
                    command = new SqlCommand(query, conn);
                    command.Parameters.Add("@idDelegacion", System.Data.SqlDbType.Int).Value = idDelegacion;
                    eliminado = 1;
                    command.ExecuteNonQuery();
                    command.Dispose();
                }

            }
            catch (Exception)
            {
                eliminado = 0;
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
        public static List<Delegacion> ObtenerDelegaciones()
        {
            List<Delegacion> delegaciones = new List<Delegacion>();
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;
                    String query = "SELECT codigPostal, nombreAlias, calle, colonia, municipio, correo, telefono FROM delegacion;";
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Delegacion delegacion = new Delegacion();
                        delegacion.CodigoPostal = (!dataReader.IsDBNull(0)) ? dataReader.GetString(0) : " ";
                        delegacion.NombreAlias = (!dataReader.IsDBNull(1)) ? dataReader.GetString(1) : " ";
                        delegacion.CalleNumero = (!dataReader.IsDBNull(2)) ? dataReader.GetString(2) : " ";
                        delegacion.Colonia = (!dataReader.IsDBNull(3)) ? dataReader.GetString(3) : " ";
                        delegacion.Municipio = (!dataReader.IsDBNull(4)) ? dataReader.GetString(4) : " ";
                        delegacion.Email = (!dataReader.IsDBNull(5)) ? dataReader.GetString(5) : " ";
                        delegacion.NumeroTelefono = (!dataReader.IsDBNull(6)) ? dataReader.GetString(6) : " ";
                        delegaciones.Add(delegacion);
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
            return delegaciones;
        }
        public static List<string> ObtenerDelegacionesNombre()
        {
            List<string> delegaciones = new List<string>();
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;
                    String query = "SELECT nombreAlias FROM delegacion;";
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Delegacion delegacion = new Delegacion();
                        delegacion.NombreAlias = (!dataReader.IsDBNull(0)) ? dataReader.GetString(0) : " ";
                        delegaciones.Add(delegacion.NombreAlias);
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
            return delegaciones;
        }

        public static int cargarIdDelecacion(string nombreDelegacion)
        {
            int idDelegacion = -1;
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;
                    String query = String.Format("SELECT idDelegacion FROM delegacion WHERE nombreAlias = '{0}'", nombreDelegacion);
                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        idDelegacion = (!dataReader.IsDBNull(0)) ? dataReader.GetInt32(0) : 0;
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
            return idDelegacion;
        }

        public static int RegistrarDelegacion(String nombreDel, String codigoPostal, String ColoniaDel, String municipio, String calleNum, String correo, String telefono)
        {
            int delegacionRegistrada = 0;
            SqlConnection conn = null;

            try
            {
                conn = ConexionBD.ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    String query = "INSERT INTO delegacion VALUES " +
                        "(@codigPostal, @nombreAlias, @calle, @colonia, @municipio, @correo, @telefono);";
                    command = new SqlCommand(query, conn);
                    command.Parameters.Add("codigPostal", System.Data.SqlDbType.VarChar, 50).Value = codigoPostal;
                    command.Parameters.Add("nombreAlias", System.Data.SqlDbType.VarChar, 50).Value = nombreDel;
                    command.Parameters.Add("calle", System.Data.SqlDbType.VarChar, 50).Value = calleNum;
                    command.Parameters.Add("colonia", System.Data.SqlDbType.VarChar, 50).Value = ColoniaDel;
                    command.Parameters.Add("municipio", System.Data.SqlDbType.VarChar,50).Value = municipio;
                    command.Parameters.Add("correo", System.Data.SqlDbType.VarChar, 50).Value = correo;
                    command.Parameters.Add("telefono", System.Data.SqlDbType.VarChar,50).Value = telefono;
                    command.ExecuteNonQuery();
                    command.Dispose();
                    delegacionRegistrada = 1;
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
            return delegacionRegistrada;
        }
    }
}
