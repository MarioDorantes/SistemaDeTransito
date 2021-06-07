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

namespace DireccionGeneralDeTránsito.vistas
{
    /// <summary>
    /// Lógica de interacción para ChatGeneral.xaml
    /// </summary>
    public partial class ChatGeneral : Window
    {
        public ChatGeneral()
        {
            InitializeComponent();
        }

        private void Btn_Regresar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalAdministrativo ventanaPrincipal = new VentanaPrincipalAdministrativo();
            ventanaPrincipal.Show();
            this.Close();
        }

        private void Btn_EnviarMensaje_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
