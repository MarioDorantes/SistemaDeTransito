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
    /// Lógica de interacción para RegistrarReporte.xaml
    /// </summary>
    public partial class RegistrarReporte : Window
    {
        public RegistrarReporte()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalMunicipal inicio = new VentanaPrincipalMunicipal();
            inicio.Show();
            this.Close();
        }
    }
}
