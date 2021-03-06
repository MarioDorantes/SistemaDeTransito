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
    class DelegacionDAO
    {
        public static List<Delegacion> obtenerDelegaciones()
        {
            List<Delegacion> delegaciones = new List<Delegacion>();
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;

                    String query = "SELECT * FROM delegacion; ";

                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Delegacion delegacion = new Delegacion();
                       
                        delegacion.CodigoPostal = (!dataReader.IsDBNull(0)) ? dataReader.GetString(0) : "";
                        delegacion.Alias = (!dataReader.IsDBNull(1)) ? dataReader.GetString(1) : "";
                        delegacion.Calle = (!dataReader.IsDBNull(2)) ? dataReader.GetString(2) : "";
                        delegacion.Colonia = (!dataReader.IsDBNull(3)) ? dataReader.GetString(3) : "";
                        delegacion.Municipio = (!dataReader.IsDBNull(4)) ? dataReader.GetString(4) : "";
                        delegacion.Correo = (!dataReader.IsDBNull(5)) ? dataReader.GetString(5) : "";
                        delegacion.NumeroTelefono = (!dataReader.IsDBNull(6)) ? dataReader.GetString(6) : "";
                        delegacion.IdDelegacion = (!dataReader.IsDBNull(7)) ? dataReader.GetInt32(7) : 0;
                        delegaciones.Add(delegacion);
                    }
                    command.Dispose();
                    dataReader.Close();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error en la Base de Datos", "Ocurrió un error");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return delegaciones;
        }
    }
}
