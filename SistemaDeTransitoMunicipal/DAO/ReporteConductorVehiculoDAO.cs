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
    class ReporteConductorVehiculoDAO
    {
        public static int agregarReporteConductorVehiculo(int idReporte, Vehiculo vehiculo)
        {
            String numLicencia = vehiculo.NumeroLicencia;
            int idVehiculo = vehiculo.IdVehiculo;

            SqlConnection conn = null;
            int resultado = 0;

            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    String query = "INSERT INTO REPORTECONDUCTORYVEHICULO VALUES (@rpt_idReporte, @cn_numLicencia, @vhc_idVehiculo)";
                    command = new SqlCommand(query, conn);

                    command.Parameters.Add("rpt_idReporte", System.Data.SqlDbType.Int).Value = idReporte;
                    command.Parameters.Add("cn_numLicencia", System.Data.SqlDbType.NChar, 30).Value = numLicencia;
                    command.Parameters.Add("vhc_idVehiculo", System.Data.SqlDbType.Int).Value = idVehiculo;
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


        public static List<Vehiculo> obtenerConductoresVehiculosReporte(int idReporte)
        {

            List<Vehiculo> conductoresYVehiculosDeReporte = new List<Vehiculo>();
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;

                    String query = String.Format("SELECT v.*, c.cn_nombre, c.cn_apellido_paterno, c.cn_apellidoMaterno " +
                        "FROM Conductor as c INNER JOIN ReporteConductorYVehiculo as  rcv ON c.cn_numLicencia = rcv.cn_numLicencia " +
                        "INNER JOIN Vehiculo as v ON v.vhc_idVehiculo = rcv.vhc_idVehiculo " +
                        "INNER JOIN Reporte as r ON rcv.rpt_idReporte = r.rpt_idReporte AND r.rpt_idReporte = '{0}'; ", idReporte);

                    Console.WriteLine(query);

                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {

                        Vehiculo vehiculo = new Vehiculo();
                        vehiculo.NumeroLicencia = (!dataReader.IsDBNull(0)) ? dataReader.GetString(0) : "";
                        vehiculo.IdVehiculo = (!dataReader.IsDBNull(1)) ? dataReader.GetInt32(1) : 0;
                        vehiculo.Marca = (!dataReader.IsDBNull(2)) ? dataReader.GetString(2) : "";
                        vehiculo.Modelo = (!dataReader.IsDBNull(3)) ? dataReader.GetString(3) : "";
                        vehiculo.Año = (!dataReader.IsDBNull(4)) ? dataReader.GetString(4) : "";
                        vehiculo.Color = (!dataReader.IsDBNull(5)) ? dataReader.GetString(5) : "";
                        vehiculo.Aseguradora = (!dataReader.IsDBNull(6)) ? dataReader.GetString(6) : "";
                        vehiculo.NumeroPoliza = (!dataReader.IsDBNull(7)) ? dataReader.GetString(7) : "";
                        vehiculo.NumeroPlacas = (!dataReader.IsDBNull(8)) ? dataReader.GetString(8) : "";
                        vehiculo.ConductorNombre = (!dataReader.IsDBNull(9)) ? dataReader.GetString(9) : "";
                        vehiculo.ConductorApellidoPaterno = (!dataReader.IsDBNull(10)) ? dataReader.GetString(10) : "";
                        vehiculo.ConductorApellidoMaterno = (!dataReader.IsDBNull(11)) ? dataReader.GetString(11) : "";
                        conductoresYVehiculosDeReporte.Add(vehiculo);
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
            return conductoresYVehiculosDeReporte;
        }


    }
}
