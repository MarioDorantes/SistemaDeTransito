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

                    String query = "SELECT * FROM vehiculo;";
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

        public static List<Vehiculo> obtenerInformacionVehiculosParaElReporte()
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

                    String query = "SELECT v.vhc_idVehiculo, v.vhc_marca, v.vhc_modelo, v.vhc_color, " +
                        "v.vhc_numPlacas, c.cn_nombre AS conductorNomnbre, c.cn_apellido_Paterno AS conductorApellidoPaterno, " +
                        "c.cn_apellidoMaterno AS conductorApellidoMaterno FROM dbo.vehiculo v " +
                        "INNER JOIN dbo.conductor c ON v.cn_numLicencia = c.cn_numLicencia;";

                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Vehiculo vehiculo = new Vehiculo();
                        vehiculo.IdVehiculo = (!dataReader.IsDBNull(0)) ? dataReader.GetInt32(0) : 0;
                        vehiculo.Marca = (!dataReader.IsDBNull(1)) ? dataReader.GetString(1) : "";
                        vehiculo.Modelo = (!dataReader.IsDBNull(2)) ? dataReader.GetString(2) : "";
                        vehiculo.Color = (!dataReader.IsDBNull(3)) ? dataReader.GetString(3) : "";
                        vehiculo.NumeroPlacas = (!dataReader.IsDBNull(4)) ? dataReader.GetString(4) : "";
                        vehiculo.ConductorNombre = (!dataReader.IsDBNull(5)) ? dataReader.GetString(5) : "";
                        vehiculo.ConductorApellidoPaterno = (!dataReader.IsDBNull(6)) ? dataReader.GetString(6) : "";
                        vehiculo.ConductorApellidoMaterno = (!dataReader.IsDBNull(7)) ? dataReader.GetString(7) : "";
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

        public static int agregarVehiculo(String numLicencia, String marca, String modelo, String año, String color, 
            String aseguradora, String numPoliza, String numPlacas)
        {
            SqlConnection conn = null;
            int resultado = 0;

            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    String query = "INSERT INTO VEHICULO VALUES (@cn_numLicencia, @vhc_marca, @vhc_modelo, " +
                        "@vhc_año, @vhc_color, @vhc_aseguradora, @vhc_numPoliza, @vhc_numPlacas)";
                    command = new SqlCommand(query, conn);

                    command.Parameters.Add("cn_numLicencia", System.Data.SqlDbType.NChar, 30).Value = numLicencia;
                    command.Parameters.Add("vhc_marca", System.Data.SqlDbType.NVarChar, 50).Value = marca;
                    command.Parameters.Add("vhc_modelo", System.Data.SqlDbType.NVarChar, 50).Value = modelo;
                    command.Parameters.Add("vhc_año", System.Data.SqlDbType.NVarChar, 50).Value = año;
                    command.Parameters.Add("vhc_color", System.Data.SqlDbType.NVarChar, 50).Value = color;
                    command.Parameters.Add("vhc_aseguradora", System.Data.SqlDbType.NVarChar, 100).Value = aseguradora;
                    command.Parameters.Add("vhc_numPoliza", System.Data.SqlDbType.NVarChar, 50).Value = numPoliza;
                    command.Parameters.Add("vhc_numPlacas", System.Data.SqlDbType.NVarChar, 50).Value = numPlacas;
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
