using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeTransitoMunicipal.pocos
{
    class Usuario
    {
        private String nombreUsuario;
        private String contraseña;
        private String rol;
        private int idDelegacion;

        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Rol { get => rol; set => rol = value; }
        public int IdDelegacion { get => idDelegacion; set => idDelegacion = value; }
    }
}
