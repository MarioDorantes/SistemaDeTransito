using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeTransitoMunicipal.pocos
{
    public class ReporteConductorVehiculo
    {
        private int idRepConYVeh;
        private int idReporte;
        private String numLicencia;
        private int idVehiculo;

        public int IdRepConYVeh { get => idRepConYVeh; set => idRepConYVeh = value; }
        public int IdReporte { get => idReporte; set => idReporte = value; }
        public string NumLicencia { get => numLicencia; set => numLicencia = value; }
        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
    }
}
