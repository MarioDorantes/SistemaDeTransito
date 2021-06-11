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

        public static int agregarReporte(int idDelegacion, String fecha, String estatus, String direccion, byte[] imagen1, byte[] imagen2, byte[] imagen3, byte[] imagen4, byte[] imagen5, byte[] imagen6, byte[] imagen7, byte[] imagen8)
        {
            SqlConnection conn = null;
            int resultado = 0;

            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    String query = "INSERT INTO REPORTE VALUES (@idDelegacion, @rpt_fecha, @rpt_estatus, " +
                        "@rpt_direccion, @rpt_imagen1, @rpt_imagen2, @rpt_imagen3, @rpt_imagen4, @rpt_imagen5, @rpt_imagen6, @rpt_imagen7, @rpt_imagen8)";
                    command = new SqlCommand(query, conn);

                    command.Parameters.Add("idDelegacion", System.Data.SqlDbType.Int).Value = idDelegacion;
                    command.Parameters.Add("rpt_fecha", System.Data.SqlDbType.Date).Value = fecha;
                    command.Parameters.Add("rpt_estatus", System.Data.SqlDbType.NVarChar, 50).Value = estatus;
                    command.Parameters.Add("rpt_direccion", System.Data.SqlDbType.NVarChar, 50).Value = direccion;
                    command.Parameters.Add("rpt_imagen1", System.Data.SqlDbType.VarBinary).Value = imagen1;
                    command.Parameters.Add("rpt_imagen2", System.Data.SqlDbType.VarBinary).Value = imagen2;
                    command.Parameters.Add("rpt_imagen3", System.Data.SqlDbType.VarBinary).Value = imagen3;
                    command.Parameters.Add("rpt_imagen4", System.Data.SqlDbType.VarBinary).Value = imagen4;
                    command.Parameters.Add("rpt_imagen5", System.Data.SqlDbType.VarBinary).Value = imagen5;
                    command.Parameters.Add("rpt_imagen6", System.Data.SqlDbType.VarBinary).Value = imagen6;
                    command.Parameters.Add("rpt_imagen7", System.Data.SqlDbType.VarBinary).Value = imagen7;
                    command.Parameters.Add("rpt_imagen8", System.Data.SqlDbType.VarBinary).Value = imagen8;
                    resultado = command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en la Base de Datos", "Ha ocurrido un error");
                Console.WriteLine(e.Message);
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

                    String query = "SELECT * FROM reporte;";
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
                        reporte.Imagen2 = (!dataReader.IsDBNull(6)) ? (byte[])dataReader.GetValue(6) : new byte[0];
                        reporte.Imagen3 = (!dataReader.IsDBNull(7)) ? (byte[])dataReader.GetValue(7) : new byte[0];
                        reporte.Imagen4 = (!dataReader.IsDBNull(8)) ? (byte[])dataReader.GetValue(8) : new byte[0];
                        reporte.Imagen5 = (!dataReader.IsDBNull(9)) ? (byte[])dataReader.GetValue(9) : new byte[0];
                        reporte.Imagen6 = (!dataReader.IsDBNull(10)) ? (byte[])dataReader.GetValue(10) : new byte[0];
                        reporte.Imagen7 = (!dataReader.IsDBNull(11)) ? (byte[])dataReader.GetValue(11) : new byte[0];
                        reporte.Imagen8 = (!dataReader.IsDBNull(12)) ? (byte[])dataReader.GetValue(12) : new byte[0];
                        reportes.Add(reporte);
                    }
                    command.Dispose();
                    dataReader.Close();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error en la Base de datos", "Error");
                Console.WriteLine(e.Message);
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


        public static int obtenerIdReporteMax()
        {
            SqlConnection conn = null;
            int reporteMaximo = 0;
            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;

                    String query = "SELECT MAX(rpt_idReporte) FROM REPORTE;";

                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Reporte reporte = new Reporte();
                        reporteMaximo = reporte.IdReporte = (!dataReader.IsDBNull(0)) ? dataReader.GetInt32(0) : 0;
                    }

                    command.Dispose();
                    dataReader.Close();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error en la Base de datos", "Error");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return reporteMaximo;
        }



    }
}
