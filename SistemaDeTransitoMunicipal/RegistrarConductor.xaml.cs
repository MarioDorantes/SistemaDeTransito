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
    /// Lógica de interacción para RegistrarConductor.xaml
    /// </summary>
    public partial class RegistrarConductor : Window
    {
        public RegistrarConductor()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalMunicipal ventanaMunicipal = new VentanaPrincipalMunicipal();
            ventanaMunicipal.Show();
            this.Close();
        }
    }
}
