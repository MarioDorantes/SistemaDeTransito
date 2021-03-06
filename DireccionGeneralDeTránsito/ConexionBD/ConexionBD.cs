using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DireccionGeneralDeTránsito.ConexionBD
{
    class ConexionBD
    {
        private static String SERVER = "sistematransitouv.database.windows.net";
        private static String PORT = "1433";
        private static String DATABASE = "SistemaTransito";
        private static String USER = "mario";
        private static String PASSWORD = "Uv12345678";

        public static SqlConnection getConnection()
        {
            SqlConnection conn = null;
            try
            {
                String urlconn = String.Format("Data Source={0}, {1};" +
                                                "Network Library=DBMSSOCN;" +
                                                "Initial Catalog={2};" +
                                                "User ID={3};" +
                                                "Password={4};", SERVER, PORT, DATABASE, USER, PASSWORD);

                conn = new SqlConnection(urlconn);
                conn.Open();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ocurrió un error");
            }
            return conn;
        }
    }
}
