using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeTransitoMunicipal.pocos
{
    class Dictamen
    {
        private string nombrePerito;
        private int folio;
        private string fechaYhora;
        private string descripcion;
        private int idReporte;

        public string NombrePerito { get => nombrePerito; set => nombrePerito = value; }
        public int Folio { get => folio; set => folio = value; }
        public string FechaYhora { get => fechaYhora; set => fechaYhora = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdReporte { get => idReporte; set => idReporte = value; }
        
    }
}
