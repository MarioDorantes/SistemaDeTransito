using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneralDeTránsito.pocos
{
    class Reporte
    {
        private int idReporte;
        private string fechaDeReporte;
        private string estatus;
        private int idDelegacion;
        private string nombreDelegacion;
        private string direccionSiniestro;

        public int IdReporte { get => idReporte; set => idReporte = value; }
        public string FechaDeReporte { get => fechaDeReporte; set => fechaDeReporte = value; }
        public string Estatus { get => estatus; set => estatus = value; }
        public int IdDelegacion { get => idDelegacion; set => idDelegacion = value; }
        public string NombreDelegacion { get => nombreDelegacion; set => nombreDelegacion = value; }
        public string DireccionSiniestro { get => direccionSiniestro; set => direccionSiniestro = value; }
    }
}
