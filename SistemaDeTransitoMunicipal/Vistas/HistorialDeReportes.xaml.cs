using SistemaDeTransitoMunicipal.DAO;
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

namespace SistemaDeTransitoMunicipal
{
    /// <summary>
    /// Lógica de interacción para HistorialDeReportes.xaml
    /// </summary>
    public partial class HistorialDeReportes : Window
    {

        List<Reporte> reportes;

        public HistorialDeReportes()
        {
            InitializeComponent();
            reportes = new List<Reporte>();
            extraerDatosReportes();
        }

        public void extraerDatosReportes()
        {
            reportes = ReporteDAO.obtenerReportes();
            dg_ListaReportes.AutoGenerateColumns = false;
            dg_ListaReportes.ItemsSource = reportes;
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalMunicipal inicio = new VentanaPrincipalMunicipal();
            inicio.Show();
            this.Close();
        }

        private void btn_verDetalle_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
