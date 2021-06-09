using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneralDeTránsito.DAO
{
    class DictamenDAO
    {
        public static int agregarDictamen(string userNamePerito, DateTime fechaDictamen, string descripcion, int idReporte)
        {
            int resultadoInsercion = 0;
            SqlConnection conn = null;

            try
            {
                conn = ConexionBD.ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    String query = "INSERT INTO dictamen VALUES (@perito, @fechaYHora, @descripcion, @idReporte)";
                    command = new SqlCommand(query, conn);
                    command.Parameters.Add("perito", System.Data.SqlDbType.NVarChar, 100).Value = userNamePerito;
                    command.Parameters.Add("fechaYHora", System.Data.SqlDbType.DateTime).Value = fechaDictamen;
                    command.Parameters.Add("descripcion", System.Data.SqlDbType.NVarChar).Value = descripcion;
                    command.Parameters.Add("idReporte", System.Data.SqlDbType.Int).Value = idReporte;
                    resultadoInsercion = command.ExecuteNonQuery();
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
            return resultadoInsercion;
        }
    }
}
