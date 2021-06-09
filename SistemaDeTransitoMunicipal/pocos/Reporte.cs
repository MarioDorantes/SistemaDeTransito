using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeTransitoMunicipal.pocos
{
    public class Reporte
    {

        private int idReporte;
        private String numLicencia;
        private int idVehiculo;
        private int idDelegacion;
        private String fecha;
        private String estatus;
        private String direccion;
        private byte [] imagen1;

        public int IdReporte { get => idReporte; set => idReporte = value; }
        public string NumLicencia { get => numLicencia; set => numLicencia = value; }
        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public int IdDelegacion { get => idDelegacion; set => idDelegacion = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Estatus { get => estatus; set => estatus = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public byte[] Imagen1 { get => imagen1; set => imagen1 = value; }
    }
}
