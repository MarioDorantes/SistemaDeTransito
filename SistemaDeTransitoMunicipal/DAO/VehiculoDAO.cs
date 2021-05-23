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
    class VehiculoDAO
    {
        public static List<Vehiculo> obtenerVehiculos()
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;

                    String query = "SELECT * FROM VEHICULO;";

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
                        vehiculos.Add(vehiculo);
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
            return vehiculos;
        }
    }
}
