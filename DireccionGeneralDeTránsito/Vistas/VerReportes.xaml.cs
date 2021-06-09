using DireccionGeneralDeTránsito.DAO;
using DireccionGeneralDeTránsito.Interfaz;
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
    /// Lógica de interacción para VerReportes.xaml
    /// </summary>
    public partial class VerReportes : Window, Observer
    {

        List<Reporte> reportes;
        public static int idReporte;
        public VerReportes()
        {
            InitializeComponent();
            reportes = new List<Reporte>();
            cargarReportes();
        }

        private void cargarReportes()
        {
            reportes = ReporteDAO.obtenerDetallesReportes();
            dg_reportes.AutoGenerateColumns = false;
            dg_reportes.ItemsSource = reportes;
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalAdministrativo principalAdministrativo = new VentanaPrincipalAdministrativo();
            principalAdministrativo.Show();
            this.Close();
        }

        private void btn_verDetalle_Click(object sender, RoutedEventArgs e)
        {
            int posicionSeleccionada = dg_reportes.SelectedIndex;
            if (posicionSeleccionada >= 0)
            {
                idReporte = reportes[posicionSeleccionada].IdReporte;
                DetalleDeReportes ventanaDetalle = new DetalleDeReportes();
                ventanaDetalle.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Para ver un reporte, primero debe seleccionarlo", "ATENCIÓN");
            }
        }

        public void actualizaInformación(string operacion)
        {
            cargarReportes();
        }
    }
}
