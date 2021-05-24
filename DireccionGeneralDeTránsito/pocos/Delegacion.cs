using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneralDeTránsito.pocos
{
    class Delegacion
    {
        String nombreAlias;
        String colonia;
        String codigoPostal;
        String calleNumero;
        String numeroTelefono;
        String email;
        String municipio;

        public string NombreAlias { get => nombreAlias; set => nombreAlias = value; }
        public string Colonia { get => colonia; set => colonia = value; }
        public string CodigoPostal { get => codigoPostal; set => codigoPostal = value; }
        public string CalleNumero { get => calleNumero; set => calleNumero = value; }
        public string NumeroTelefono { get => numeroTelefono; set => numeroTelefono = value; }
        public string Email { get => email; set => email = value; }
        public string Municipio { get => municipio; set => municipio = value; }
    }
}
