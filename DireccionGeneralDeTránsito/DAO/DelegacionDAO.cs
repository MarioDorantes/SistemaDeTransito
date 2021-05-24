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
                    String query = "SELECT codigoPostal, nombreAlias, calle, colonia, municipio, correo, telefono FROM delegacion;";
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
        public static int RegistrarDelegacion(String nombreDel, String codigoPostal, String ColoniaDel, String municipio, String calleNum, String correo, String telefono)
        {
            int usuarioRegistrado = 0;
            SqlConnection conn = null;

            try
            {
                conn = ConexionBD.ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    String query = "INSERT INTO delegacion VALUES " +
                        "(@codigoPostal, @nombreAlias, @calle, @colonia, @municipio, @correo, @telefono);";
                    command = new SqlCommand(query, conn);
                    command.Parameters.Add("codigoPostal", System.Data.SqlDbType.VarChar, 50).Value = codigoPostal;
                    command.Parameters.Add("nombreAlias", System.Data.SqlDbType.VarChar, 50).Value = nombreDel;
                    command.Parameters.Add("calle", System.Data.SqlDbType.VarChar, 50).Value = calleNum;
                    command.Parameters.Add("colonia", System.Data.SqlDbType.VarChar, 50).Value = ColoniaDel;
                    command.Parameters.Add("municipio", System.Data.SqlDbType.VarChar,50).Value = municipio;
                    command.Parameters.Add("correo", System.Data.SqlDbType.VarChar, 50).Value = correo;
                    command.Parameters.Add("telefono", System.Data.SqlDbType.VarChar,50).Value = telefono;
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
