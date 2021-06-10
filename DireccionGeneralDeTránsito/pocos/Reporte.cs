using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneralDeTránsito.pocos
{
    public class Reporte
    {
        private int idReporte;
        private string fechaDeReporte;
        private string estatus;
        private int idDelegacion;
        private string nombreDelegacion;
        private string direccionSiniestro;
        private byte[] imagen1;
        private byte[] imagen2;
        private byte[] imagen3;
        private byte[] imagen4;
        private byte[] imagen5;
        private byte[] imagen6;
        private byte[] imagen7;
        private byte[] imagen8;

        public int IdReporte { get => idReporte; set => idReporte = value; }
        public string FechaDeReporte { get => fechaDeReporte; set => fechaDeReporte = value; }
        public string Estatus { get => estatus; set => estatus = value; }
        public int IdDelegacion { get => idDelegacion; set => idDelegacion = value; }
        public string NombreDelegacion { get => nombreDelegacion; set => nombreDelegacion = value; }
        public string DireccionSiniestro { get => direccionSiniestro; set => direccionSiniestro = value; }
        public byte[] Imagen1 { get => imagen1; set => imagen1 = value; }
        public byte[] Imagen2 { get => imagen2; set => imagen2 = value; }
        public byte[] Imagen3 { get => imagen3; set => imagen3 = value; }
        public byte[] Imagen4 { get => imagen4; set => imagen4 = value; }
        public byte[] Imagen5 { get => imagen5; set => imagen5 = value; }
        public byte[] Imagen6 { get => imagen6; set => imagen6 = value; }
        public byte[] Imagen7 { get => imagen7; set => imagen7 = value; }
        public byte[] Imagen8 { get => imagen8; set => imagen8 = value; }
    }
}
