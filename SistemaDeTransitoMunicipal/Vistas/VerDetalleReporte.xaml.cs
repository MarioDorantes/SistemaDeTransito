using SistemaDeTransitoMunicipal.pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SistemaDeTransitoMunicipal.vistas
{
    /// <summary>
    /// Lógica de interacción para VerDetalleReporte.xaml
    /// </summary>
    public partial class VerDetalleReporte : Window
    {

        Reporte reporteVisualizar;
        int idReporte = 0;

        public VerDetalleReporte()
        {
            InitializeComponent();
        }

        public VerDetalleReporte(Reporte reporteVisualizar)
        {
            InitializeComponent();
            this.reporteVisualizar = reporteVisualizar;
            CargarInformacionReporte();
        }

        private void CargarInformacionReporte()
        {
            idReporte = reporteVisualizar.IdReporte;
            txt_direccionDetalle.Text = reporteVisualizar.Direccion;
            txt_fechaDetalle.Text = reporteVisualizar.Fecha;

            /*
            OPCION 1 QUE NO JALA JSJS 
             
            byte[] imagen1 = Encoding.ASCII.GetBytes(reporteVisualizar.Imagen1);
            String ima1Aux = imagen1.ToString();
            img_1Detalle= ima1Aux;
            */

            /*
            OPCION 2 TAMPOCO JALA xd LE VOY MAS A ESTE
            byte [] imagen1 = Encoding.ASCII.GetBytes(reporteVisualizar.Imagen1);
            String resultadoImg1 = "C:\\Users\\mario\\Downloads\\imagenUno.jpg";
            System.IO.File.WriteAllBytes(@resultadoImg1, imagen1);
            img_1Detalle.Source = @resultadoImg1;
            */

        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            HistorialDeReportes regresar = new HistorialDeReportes();
            regresar.Show();
            this.Close();
        }
    }
}
