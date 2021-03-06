using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneralDeTránsito.pocos
{
    public class Usuario
    {
        String nombreUsuario;
        String nombre;
        String apellidoPaterno;
        String apellidoMaterno;
        String contraseña;
        String tipoUsuario;
        string delegacion;

        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public string Delegacion { get => delegacion; set => delegacion = value; }
    }
}
