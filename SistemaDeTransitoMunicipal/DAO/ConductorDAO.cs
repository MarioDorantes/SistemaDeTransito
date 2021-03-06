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
    class ConductorDAO
    {
        public static List<Conductor> obtenerConductores(int idDelegacion)
        {
            List<Conductor> conductores = new List<Conductor>();
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;

                    String query = String.Format("SELECT c.*, d.nombreAlias FROM conductor c " +
                                   "INNER JOIN delegacion d ON c.idDelegacion = d.idDelegacion " +
                                   "INNER JOIN Usuario u ON d.idDelegacion = u.idDelegacion " +
                                   "WHERE u.usr_rol = 'Administrativo' AND u.idDelegacion = '{0}'; ", idDelegacion);

                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Conductor conductor = new Conductor();
                        conductor.NumeroLicencia = (!dataReader.IsDBNull(0)) ? dataReader.GetString(0) : "";
                        conductor.NumeroTelefono = (!dataReader.IsDBNull(1)) ? dataReader.GetString(1) : "";
                        conductor.FechaNacimiento = (!dataReader.IsDBNull(2)) ? dataReader.GetDateTime(2).ToString("d") : "";
                        conductor.Nombre = (!dataReader.IsDBNull(3)) ? dataReader.GetString(3) : "";
                        conductor.Paternos = (!dataReader.IsDBNull(4)) ? dataReader.GetString(4): "";
                        conductor.Maternos = (!dataReader.IsDBNull(5)) ? dataReader.GetString(5) : "";
                        conductor.IdDelegacion = (!dataReader.IsDBNull(6)) ? dataReader.GetInt32(6) : 0;
                        conductor.NombreDelegacion = (!dataReader.IsDBNull(7)) ? dataReader.GetString(7) : "";
                        conductores.Add(conductor);
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
                if(conn != null)
                {
                    conn.Close();
                }
            }
            return conductores;
        }

        //Metodo creado para registro de vehiculos
        public static List<Conductor> obtenerTodosLosConductores()
        {
            List<Conductor> conductores = new List<Conductor>();
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;

                    String query = ("SELECT * FROM conductor;");

                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Conductor conductor = new Conductor();
                        conductor.NumeroLicencia = (!dataReader.IsDBNull(0)) ? dataReader.GetString(0) : "";
                        conductor.NumeroTelefono = (!dataReader.IsDBNull(1)) ? dataReader.GetString(1) : "";
                        conductor.FechaNacimiento = (!dataReader.IsDBNull(2)) ? dataReader.GetDateTime(2).ToString("d") : "";
                        conductor.Nombre = (!dataReader.IsDBNull(3)) ? dataReader.GetString(3) : "";
                        conductor.Paternos = (!dataReader.IsDBNull(4)) ? dataReader.GetString(4) : "";
                        conductor.Maternos = (!dataReader.IsDBNull(5)) ? dataReader.GetString(5) : "";
                        conductor.IdDelegacion = (!dataReader.IsDBNull(6)) ? dataReader.GetInt32(6) : 0;
                        conductores.Add(conductor);
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
            return conductores;
        }


        public static int agregarConductor(String numeroLicencia, String nombre, String paterno,
            String materno, String numeroTelefono, String fechaNacimiento, int delegacion)
        {
            SqlConnection conn = null;
            int resultado = 0;

            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    String query = "INSERT INTO conductor VALUES (@cn_numLicencia, @cn_numTelefono, @cn_FechaNacimiento, " +
                                   "@cn_nombre, @cn_apellido_paterno, @cn_apellidoMaterno, @idDelegacion)";
                    command = new SqlCommand(query, conn);

                    command.Parameters.Add("cn_numLicencia", System.Data.SqlDbType.NChar, 30).Value = numeroLicencia;
                    command.Parameters.Add("cn_numTelefono", System.Data.SqlDbType.NChar, 30).Value = numeroTelefono;
                    command.Parameters.Add("cn_FechaNacimiento", System.Data.SqlDbType.Date).Value = fechaNacimiento;
                    command.Parameters.Add("cn_nombre", System.Data.SqlDbType.NVarChar, 100).Value = nombre;
                    command.Parameters.Add("cn_apellido_paterno", System.Data.SqlDbType.NVarChar, 100).Value = paterno;
                    command.Parameters.Add("cn_apellidoMaterno", System.Data.SqlDbType.NVarChar, 100).Value = materno;
                    command.Parameters.Add("idDelegacion", System.Data.SqlDbType.Int).Value = delegacion;
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

        public static int modificarConductor(String numeroLicencia, String nombre, String paterno,
            String materno, String numeroTelefono, String fechaNacimiento, String numeroLicenciaConductor)
        {
            SqlConnection conn = null;
            int resultado = 0;

            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    String query = String.Format("UPDATE conductor SET cn_numTelefono = @cn_numTelefono, cn_FechaNacimiento = @cn_FechaNacimiento, " +
                                    "cn_nombre = @cn_nombre, cn_apellido_paterno = @cn_apellido_paterno, cn_apellidoMaterno = @cn_apellidoMaterno" +
                                    " WHERE cn_numLicencia = '{0}'", numeroLicenciaConductor);
                    command = new SqlCommand(query, conn);

                    command.Parameters.Add("cn_numLicencia", System.Data.SqlDbType.NChar, 30).Value = numeroLicencia;
                    command.Parameters.Add("cn_numTelefono", System.Data.SqlDbType.NChar, 30).Value = numeroTelefono;
                    command.Parameters.Add("cn_FechaNacimiento", System.Data.SqlDbType.Date).Value = fechaNacimiento;
                    command.Parameters.Add("cn_nombre", System.Data.SqlDbType.NVarChar, 100).Value = nombre;
                    command.Parameters.Add("cn_apellido_paterno", System.Data.SqlDbType.NVarChar, 100).Value = paterno;
                    command.Parameters.Add("cn_apellidoMaterno", System.Data.SqlDbType.NVarChar, 100).Value = materno;
                    resultado = command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en la base de datos", "Ha ocurrido un error");
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

        public static int eliminarConductor(String numeroLicencia)
        {
            SqlConnection conn = null;
            int resultado = 0;

            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    String query = "DELETE FROM conductor WHERE cn_numLicencia = @cn_numLicencia";
                    command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@cn_numLicencia", numeroLicencia);
                    resultado = command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se puede eliminar al conductor, debido a que esta relacionado a un vehículo y/o reporte", "Error");
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

        public static Boolean verificarLicenciasRegistradas(string numeroDeLicencia)
        {
            Boolean licenciaObtenida = false;
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnection();
                if (conn != null)
                {
                    SqlCommand command;
                    SqlDataReader dataReader;

                    String query = String.Format("SELECT cn_numLicencia FROM conductor WHERE cn_numLicencia = '{0}' ", numeroDeLicencia);

                    command = new SqlCommand(query, conn);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        licenciaObtenida = true;
                    }
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
            return licenciaObtenida;
        }
    }
}
