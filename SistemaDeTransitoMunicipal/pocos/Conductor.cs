using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeTransitoMunicipal.pocos
{
    class Conductor
    {
        private String numeroLicencia;
        private String nombre;
        private String maternos;
        private String paternos;
        private String numeroTelefono;
        private String fechaNacimiento;
        private String delegacion;

        public string NumeroLicencia { get => numeroLicencia; set => numeroLicencia = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Paternos { get => paternos; set => paternos = value; }
        public string Maternos { get => maternos; set => maternos = value; }
        public string NumeroTelefono { get => numeroTelefono; set => numeroTelefono = value; }
        public string FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Delegacion { get => delegacion; set => delegacion = value; }
    }
}
