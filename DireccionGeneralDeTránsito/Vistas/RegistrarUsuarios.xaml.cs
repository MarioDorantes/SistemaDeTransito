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
            UsuariosRegistrados ventanaUsuariosRegistrados = new UsuariosRegistrados();
            ventanaUsuariosRegistrados.Show();
            this.Close();
        }

        private void btn_confirmarRegistro_Click(object sender, RoutedEventArgs e)
        {
            String nombreUsuario = tbx_nombreUsuario.Text;
            String nombre = tbx_nombreRegistro.Text;
            String apellidoPaterno = tbx_aPaternoRegistro.Text;
            String apellidoMaterno = tbx_aMaternoRegistro.Text;
            String contraseña = pbx_contraseña.Password;
            String tipoUsuario = cmb_tipoUsuario.Text;
        }
    }
}
