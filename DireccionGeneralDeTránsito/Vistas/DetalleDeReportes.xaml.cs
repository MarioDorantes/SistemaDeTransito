using DireccionGeneralDeTránsito.DAO;
using DireccionGeneralDeTránsito.pocos;
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

namespace DireccionGeneralDeTránsito
{
    /// <summary>
    /// Lógica de interacción para DetalleDeReportes.xaml
    /// </summary>
    public partial class DetalleDeReportes : Window
    {
        
        String usuarioConectado = "";
        Reporte reporteVisualizar;
        int idReporte = 0;
        List<Vehiculo> vehiculosYConductoresInvolucrados;


        public DetalleDeReportes(String usuario)
        {
            InitializeComponent();
            this.usuarioConectado = usuario;
        }
        public DetalleDeReportes(Reporte reporteVisualizar)
        {
            InitializeComponent();
            this.reporteVisualizar = reporteVisualizar;
            vehiculosYConductoresInvolucrados = new List<Vehiculo>();

            //Cargar conductores y vehiculos involucrados
            CargarCyVInvolucrados(reporteVisualizar.IdReporte);
            CargarInformacionReporte();

        }

        private void CargarCyVInvolucrados(int idReporte)
        {
            vehiculosYConductoresInvolucrados = ReporteConductorVehiculoDAO.obtenerConductoresVehiculosReporte(idReporte);
            dg_listaInvolucrados.AutoGenerateColumns = false;
            dg_listaInvolucrados.ItemsSource = vehiculosYConductoresInvolucrados;
        }

        private void CargarInformacionReporte()
        {
            idReporte = reporteVisualizar.IdReporte;
            txt_direccionDetalle.Text = reporteVisualizar.DireccionSiniestro;
            txt_fechaDetalle.Text = reporteVisualizar.FechaDeReporte;

            cargarImagenes();

        }

        private void cargarImagenes()
        {
            byte[] imagen1Aux = reporteVisualizar.Imagen1;
            using (var ms1 = new System.IO.MemoryStream(imagen1Aux))
            {
                var image1 = new BitmapImage();
                image1.BeginInit();
                image1.CacheOption = BitmapCacheOption.OnLoad;
                image1.StreamSource = ms1;
                image1.EndInit();
                img_1Detalle.Source = image1;
            }

            byte[] imagen2Aux = reporteVisualizar.Imagen2;
            using (var ms2 = new System.IO.MemoryStream(imagen2Aux))
            {
                var image2 = new BitmapImage();
                image2.BeginInit();
                image2.CacheOption = BitmapCacheOption.OnLoad;
                image2.StreamSource = ms2;
                image2.EndInit();
                img_2Detalle.Source = image2;
            }

            byte[] imagen3Aux = reporteVisualizar.Imagen3;
            using (var ms3 = new System.IO.MemoryStream(imagen3Aux))
            {
                var image3 = new BitmapImage();
                image3.BeginInit();
                image3.CacheOption = BitmapCacheOption.OnLoad;
                image3.StreamSource = ms3;
                image3.EndInit();
                img_3Detalle.Source = image3;
            }

            if (reporteVisualizar.Imagen4.Length > 0)
            {
                byte[] imagen4Aux = reporteVisualizar.Imagen4;
                using (var ms4 = new System.IO.MemoryStream(imagen4Aux))
                {
                    var image4 = new BitmapImage();
                    image4.BeginInit();
                    image4.CacheOption = BitmapCacheOption.OnLoad;
                    image4.StreamSource = ms4;
                    image4.EndInit();
                    img_4Detalle.Source = image4;
                }
            }
            else
            {
                img_4Detalle.Source = null;
            }


            if (reporteVisualizar.Imagen5.Length > 0)
            {
                byte[] imagen5Aux = reporteVisualizar.Imagen5;
                using (var ms5 = new System.IO.MemoryStream(imagen5Aux))
                {
                    var image5 = new BitmapImage();
                    image5.BeginInit();
                    image5.CacheOption = BitmapCacheOption.OnLoad;
                    image5.StreamSource = ms5;
                    image5.EndInit();
                    img_5Detalle.Source = image5;
                }
            }
            else
            {
                img_5Detalle.Source = null;
            }


            if (reporteVisualizar.Imagen6.Length > 0)
            {
                byte[] imagen6Aux = reporteVisualizar.Imagen6;
                using (var ms6 = new System.IO.MemoryStream(imagen6Aux))
                {
                    var image6 = new BitmapImage();
                    image6.BeginInit();
                    image6.CacheOption = BitmapCacheOption.OnLoad;
                    image6.StreamSource = ms6;
                    image6.EndInit();
                    img_6Detalle.Source = image6;
                }
            }
            else
            {
                img_6Detalle.Source = null;
            }

            if (reporteVisualizar.Imagen7.Length > 0)
            {
                byte[] imagen7Aux = reporteVisualizar.Imagen7;
                using (var ms7 = new System.IO.MemoryStream(imagen7Aux))
                {
                    var image7 = new BitmapImage();
                    image7.BeginInit();
                    image7.CacheOption = BitmapCacheOption.OnLoad;
                    image7.StreamSource = ms7;
                    image7.EndInit();
                    img_7Detalle.Source = image7;
                }
            }
            else
            {
                img_7Detalle.Source = null;
            }

            if (reporteVisualizar.Imagen8.Length > 0)
            {
                byte[] imagen8Aux = reporteVisualizar.Imagen8;
                using (var ms8 = new System.IO.MemoryStream(imagen8Aux))
                {
                    var image8 = new BitmapImage();
                    image8.BeginInit();
                    image8.CacheOption = BitmapCacheOption.OnLoad;
                    image8.StreamSource = ms8;
                    image8.EndInit();
                    img_8Detalle.Source = image8;
                }
            }
            else
            {
                img_8Detalle.Source = null;
            }

        }


        private void btn_dictaminar_Click(object sender, RoutedEventArgs e)
        {
            DictaminarReporte ventanaDictaminar = new DictaminarReporte();
            ventanaDictaminar.Show();
            this.Close();
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            VerReportes ventanaVerReportes = new VerReportes();
            ventanaVerReportes.Show();
            this.Close();
        }
    }
}
