using SistemaDeTransitoMunicipal.conexionBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SistemaDeTransitoMunicipal.DAO
{
    class ReporteDAO
    {

        public static int agregarReporte(int idDelegacion, String fecha, String estatus, String direccion, byte[] imagen1)
        {
            SqlConnection conn = null;
            int resultado = 0;

            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    String query = "INSERT INTO REPORTEPRUEBA VALUES (@idDelegacion, @rpt_fecha, @rpt_estatus, " +
                        "@rpt_direccion, @rpt_imagen1)";
                    command = new SqlCommand(query, conn);

                    command.Parameters.Add("idDelegacion", System.Data.SqlDbType.Int).Value = idDelegacion;
                    command.Parameters.Add("rpt_fecha", System.Data.SqlDbType.Date).Value = fecha;
                    command.Parameters.Add("rpt_estatus", System.Data.SqlDbType.NVarChar, 50).Value = estatus;
                    command.Parameters.Add("rpt_direccion", System.Data.SqlDbType.NVarChar, 50).Value = direccion;
                    command.Parameters.Add("rpt_imagen1", System.Data.SqlDbType.Image).Value = imagen1;
                    resultado = command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ha ocurrido un error");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return resultado;
        }

    }
}
