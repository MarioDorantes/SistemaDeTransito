using DireccionGeneralDeTránsito.pocos;
using DireccionGeneralDeTránsito.vistas;
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
        String nombre = "";
        public VentanaPrincipalAdministrativo(String nombreUsuario)
        {
            InitializeComponent();
            nombre = nombreUsuario;
            
        }
        private void btn_verReportes_Click(object sender, RoutedEventArgs e)
        {
            VerReportes ventanaVerReportes = new VerReportes(nombre);
            ventanaVerReportes.Show();
            this.Close();
        }

        private void btn_DetalleDeReportes_Click(object sender, RoutedEventArgs e)
        {
            ChatGeneral ventanaChat = new ChatGeneral(nombre);
            ventanaChat.Show();
            this.Close();
        }

        private void btn_registroUsuarios_Click(object sender, RoutedEventArgs e)
        {
            UsuariosRegistrados ventanaUsuariosRegistrados = new UsuariosRegistrados(nombre);
            ventanaUsuariosRegistrados.Show();
            this.Close();
        }

        private void btn_delegaciones_Click(object sender, RoutedEventArgs e)
        {
            DelegacionesRegistradas ventanaDelegaciones = new DelegacionesRegistradas(nombre);
            ventanaDelegaciones.Show();
            this.Close();
        }
    }
}
