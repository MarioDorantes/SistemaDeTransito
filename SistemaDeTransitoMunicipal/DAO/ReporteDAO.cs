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
                    command.Parameters.Add("rpt_imagen1", System.Data.SqlDbType.VarBinary).Value = imagen1;
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


        public static List<Reporte> obtenerReportes()
        {
            List<Reporte> reportes = new List<Reporte>();
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;

                    String query = "SELECT * FROM reportePrueba;";
                    Console.WriteLine(query);

                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Reporte reporte = new Reporte();
                        reporte.IdReporte = (!dataReader.IsDBNull(0)) ? dataReader.GetInt32(0) : 0;
                        reporte.IdDelegacion = (!dataReader.IsDBNull(1)) ? dataReader.GetInt32(1) : 0;
                        reporte.Fecha = (!dataReader.IsDBNull(2)) ? dataReader.GetDateTime(2).ToString("d") : "";
                        reporte.Estatus = (!dataReader.IsDBNull(3)) ? dataReader.GetString(3) : "";
                        reporte.Direccion = (!dataReader.IsDBNull(4)) ? dataReader.GetString(4) : "";
                        reporte.Imagen1 = (!dataReader.IsDBNull(5)) ? (byte [])dataReader.GetValue(5) : new byte [0];

                        reportes.Add(reporte);
                    }
                    command.Dispose();
                    dataReader.Close();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("No hay conexión a la base de datos. Intente más tarde", "Error" + e.Message);
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



    }
}
