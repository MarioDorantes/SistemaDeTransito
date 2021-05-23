using DireccionGeneralDeTránsito.ConexionBD;
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
