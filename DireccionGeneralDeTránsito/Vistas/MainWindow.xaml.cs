using DireccionGeneralDeTránsito.DAO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DireccionGeneralDeTránsito
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static string nombreUsuario = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_InicioSesion_Click(object sender, RoutedEventArgs e)
        {
            String usuario = txt_nombreUsuario.Text;
            String contraseña = pswd_contraseña.Password;
            if (usuario.Length >0 && contraseña.Length >= 0)
            {
                Usuario usuarioLogin = UsuarioDAOcs.obtenerLogin(usuario, contraseña);
                if(usuarioLogin != null)
                {
                    nombreUsuario = usuarioLogin.NombreUsuario;
                    MessageBox.Show("Bienvenido al sistema " + nombreUsuario);
                    VentanaPrincipalAdministrativo ventanaPrincipalAdministrativo = new VentanaPrincipalAdministrativo();
                    ventanaPrincipalAdministrativo.Show();
                    this.Close();
                }
                else if(usuarioLogin == null)
                {
                    lbl_malInicio.Visibility = Visibility.Visible;
                    txt_nombreUsuario.Foreground = Brushes.Red;
                    pswd_contraseña.Foreground = Brushes.Red;
                }
            }
            else
            {
                lbl_malInicio.Visibility = Visibility.Visible;
                txt_nombreUsuario.Foreground = Brushes.Red;
                pswd_contraseña.Foreground = Brushes.Red;
            }


        }
    }
}
