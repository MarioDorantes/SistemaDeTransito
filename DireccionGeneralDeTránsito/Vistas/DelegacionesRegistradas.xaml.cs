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

namespace DireccionGeneralDeTránsito.Vistas
{
    /// <summary>
    /// Lógica de interacción para DelegacionesRegistradas.xaml
    /// </summary>
    public partial class DelegacionesRegistradas : Window
    {
        public DelegacionesRegistradas()
        {
            InitializeComponent();
        }

        private void btn_registroDelegacion_Click(object sender, RoutedEventArgs e)
        {
            RegistrarDelegación ventanaRegistro = new RegistrarDelegación();
            ventanaRegistro.Show();
            this.Close();
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalAdministrativo ventanaPrincipal = new VentanaPrincipalAdministrativo();
            ventanaPrincipal.Show();
            this.Close();
        }
    }
}
