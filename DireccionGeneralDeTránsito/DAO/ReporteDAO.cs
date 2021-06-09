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
    class ReporteDAO
    {

        public static List<Reporte> obtenerDetallesReportes()
        {
            List<Reporte> reportes = new List<Reporte>();
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.ConexionBD.getConnection();

                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;

                    String query = "SELECT r.rpt_id, r.fechaReporte, r.estatusReporte, r.idDelegacion, d.nombreAlias, r.direccionSiniestro FROM reporte r "
                                   + "INNER JOIN delegacion d ON r.idDelegacion = d.idDelegacion; ";

                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Reporte reporte = new Reporte();
                        reporte.IdReporte = (!dataReader.IsDBNull(0)) ? dataReader.GetInt32(0) : 0;
                        reporte.FechaDeReporte = (!dataReader.IsDBNull(1)) ? dataReader.GetDateTime(1).ToString("d") : "";
                        reporte.Estatus = (!dataReader.IsDBNull(2)) ? dataReader.GetString(2) : "";
                        reporte.IdDelegacion = (!dataReader.IsDBNull(3)) ? dataReader.GetInt32(3) : 0;
                        reporte.NombreDelegacion = (!dataReader.IsDBNull(4)) ? dataReader.GetString(4) : "";
                        reporte.DireccionSiniestro = (!dataReader.IsDBNull(5)) ? dataReader.GetString(5) : "";
                        reportes.Add(reporte);
                    }
                    command.Dispose();
                    dataReader.Close();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message + "No se estableció conexión con la BD", "Ocurrió un error");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return reportes;
        }

        public static int cambiarEstadoReporte(int idReporte)
        {
            {
                int informacionActualizada = 0;
                SqlConnection conn = null;
                try
                {
                    conn = ConexionBD.ConexionBD.getConnection();
                    if (conn != null)
                    {
                        SqlCommand command;
                        String query = String.Format("UPDATE reporte SET estatusReporte = 'Dictaminado' WHERE rpt_id = {0};", idReporte);
                        command = new SqlCommand(query, conn);
                        informacionActualizada = command.ExecuteNonQuery();
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

                return informacionActualizada;
            }
        }
    }
}
    

