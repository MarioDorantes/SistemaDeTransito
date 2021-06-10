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

    }
}
