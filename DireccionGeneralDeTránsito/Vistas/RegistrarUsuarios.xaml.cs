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
    /// Lógica de interacción para RegistrarUsuarios.xaml
    /// </summary>
    public partial class RegistrarUsuarios : Window
    {
        public RegistrarUsuarios()
        {
            InitializeComponent();
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalAdministrativo ventanaPrincipalAdministrivo = new VentanaPrincipalAdministrativo();
            ventanaPrincipalAdministrivo.Show();
            this.Close();
        }

   
    }
}
