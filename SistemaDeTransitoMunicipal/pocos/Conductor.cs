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
        private String nombreDelegacion;
        private int idDelegacion;


        public string NumeroLicencia { get => numeroLicencia; set => numeroLicencia = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Paternos { get => paternos; set => paternos = value; }
        public string Maternos { get => maternos; set => maternos = value; }
        public string NumeroTelefono { get => numeroTelefono; set => numeroTelefono = value; }
        public string FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int IdDelegacion { get => idDelegacion; set => idDelegacion = value; }
        public string NombreDelegacion { get => nombreDelegacion; set => nombreDelegacion = value; }

        public override string ToString()
        {
            return nombre + " " + paternos + " " + maternos;
        }

    }
}
