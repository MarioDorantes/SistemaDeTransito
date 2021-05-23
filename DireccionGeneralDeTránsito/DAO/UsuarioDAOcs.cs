using DireccionGeneralDeTránsito.ConexionBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DireccionGeneralDeTránsito.DAO
{
    class UsuarioDAOcs
    {
        public static int RegistrarUsuarios(String nombre, String aPaterno, String aMaterno, String nombreUsuario, String contraseña, int delegacion, String tipoUsuario)
        {
            int seRegistro = 0;
            SqlConnection conn = null;
            try
            {
                conn = ConexionBD.ConexionBD.getConnection();

            }
            catch
            {

            }
            
            return seRegistro;
        }
    }
}
