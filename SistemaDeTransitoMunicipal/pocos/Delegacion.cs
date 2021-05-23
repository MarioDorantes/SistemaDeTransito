using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeTransitoMunicipal.pocos
{
    class Delegacion
    {
        private String alias;
        private String codigoPostal;
        private String calle;
        private String numero;
        private String colonia;
        private String municipio;
        private String correo;
        private String numeroTelefono;

        public string Alias { get => alias; set => alias = value; }
        public string CodigoPostal { get => codigoPostal; set => codigoPostal = value; }
        public string Calle { get => calle; set => calle = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Colonia { get => colonia; set => colonia = value; }
        public string Municipio { get => municipio; set => municipio = value; }
        public string Correo { get => correo; set => correo = value; }
        public string NumeroTelefono { get => numeroTelefono; set => numeroTelefono = value; }

        public override string ToString()
        {
            return alias;
        }
    }
}
