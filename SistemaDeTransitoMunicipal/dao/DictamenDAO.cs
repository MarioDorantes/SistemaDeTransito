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
    class DictamenDAO
    { 
        public static Dictamen obtenerDictamen(int idReporte)
        {
            Dictamen dictamen = new Dictamen();
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;

                    String query = String.Format("SELECT * FROM dictamen where idReporte = '{0}'; ", idReporte);

                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();

                    if (dataReader.Read())
                    {
                        dictamen.NombrePerito = (!dataReader.IsDBNull(0)) ? dataReader.GetString(0) : "";
                        dictamen.Folio = (!dataReader.IsDBNull(1)) ? dataReader.GetInt32(1) : 0;
                        dictamen.FechaYhora = (!dataReader.IsDBNull(2)) ? dataReader.GetDateTime(2).ToString("g") : "";
                        dictamen.Descripcion = (!dataReader.IsDBNull(3)) ? dataReader.GetString(3) : "";
                        dictamen.IdReporte = (!dataReader.IsDBNull(4)) ? dataReader.GetInt32(4) : 0;
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
            return dictamen;
        }
    }
}
