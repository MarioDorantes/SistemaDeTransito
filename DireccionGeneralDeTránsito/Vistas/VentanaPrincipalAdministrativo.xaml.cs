using DireccionGeneralDeTránsito.Vistas;
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
    /// Lógica de interacción para VentanaPrincipalAdministrativo.xaml
    /// </summary>
    public partial class VentanaPrincipalAdministrativo : Window
    {
        public VentanaPrincipalAdministrativo()
        {
            InitializeComponent();
        }

        private void btn_verReportes_Click(object sender, RoutedEventArgs e)
        {
            VerReportes ventanaVerReportes = new VerReportes();
            ventanaVerReportes.Show();
            this.Close();
        }

        private void btn_DetalleDeReportes_Click(object sender, RoutedEventArgs e)
        {
            DetalleDeReportes detalleDeReportes = new DetalleDeReportes();
            detalleDeReportes.Show();
            this.Close();
        }

        private void btn_registroUsuarios_Click(object sender, RoutedEventArgs e)
        {
            UsuariosRegistrados ventanaUsuariosRegistrados = new UsuariosRegistrados();
            ventanaUsuariosRegistrados.Show();
            this.Close();
        }

        private void btn_delegaciones_Click(object sender, RoutedEventArgs e)
        {
            DelegacionesRegistradas ventanaDelegaciones = new DelegacionesRegistradas();
            ventanaDelegaciones.Show();
            this.Close();
        }
    }
}
