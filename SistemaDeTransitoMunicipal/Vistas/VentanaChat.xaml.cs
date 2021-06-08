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
    /// Lógica de interacción para VentanaChat.xaml
    /// </summary>
    public partial class VentanaChat : Window
    {
        public VentanaChat()
        {
            InitializeComponent();
        }

        private void Btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalMunicipal ventanaAdmin = new VentanaPrincipalMunicipal();
            ventanaAdmin.Show();
            this.Close();
        }
    }
}
