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

                    String query = "SELECT r.rpt_idReporte, r.rpt_fecha, r.rpt_estatus, r.idDelegacion, d.nombreAlias, r.rpt_direccion, " +
                        "r.rpt_imagen1, r.rpt_imagen2, r.rpt_imagen3, r.rpt_imagen4, r.rpt_imagen5, r.rpt_imagen6, r.rpt_imagen7, r.rpt_imagen8 " +
                        "FROM reporte r "
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

                        reporte.Imagen1 = (!dataReader.IsDBNull(6)) ? (byte[])dataReader.GetValue(6) : new byte[0];
                        reporte.Imagen2 = (!dataReader.IsDBNull(7)) ? (byte[])dataReader.GetValue(7) : new byte[0];
                        reporte.Imagen3 = (!dataReader.IsDBNull(8)) ? (byte[])dataReader.GetValue(8) : new byte[0];
                        reporte.Imagen4 = (!dataReader.IsDBNull(9)) ? (byte[])dataReader.GetValue(9) : new byte[0];
                        reporte.Imagen5 = (!dataReader.IsDBNull(10)) ? (byte[])dataReader.GetValue(10) : new byte[0];
                        reporte.Imagen6 = (!dataReader.IsDBNull(11)) ? (byte[])dataReader.GetValue(11) : new byte[0];
                        reporte.Imagen7 = (!dataReader.IsDBNull(12)) ? (byte[])dataReader.GetValue(12) : new byte[0];
                        reporte.Imagen8 = (!dataReader.IsDBNull(13)) ? (byte[])dataReader.GetValue(13) : new byte[0];
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
                        String query = String.Format("UPDATE reporte SET rpt_estatus = 'Dictaminado' WHERE rpt_idReporte = {0};", idReporte);
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
    

