using SistemaDeTransitoMunicipal.DAO;
using SistemaDeTransitoMunicipal.pocos;
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

namespace SistemaDeTransitoMunicipal
{
    
    public partial class MainWindow : Window
    {
        public static string nombreUsuario = "";
        public static string rolUsuario = "";
        public static int idDelegacionLoggeada = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_IniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            String usuario = txt_nombreUsuario.Text;
            String contraseña = txt_pswd_Contraseña.Password;

            if (usuario.Length > 0 && contraseña.Length > 0)
            {
                Usuario userRespuesta = UsuarioDAO.obtenerLogin(usuario, contraseña);
                if (userRespuesta != null && userRespuesta.NombreUsuario != null)
                {
                    nombreUsuario = userRespuesta.NombreUsuario;
                    rolUsuario = userRespuesta.Rol;
                    idDelegacionLoggeada = userRespuesta.IdDelegacion;
                    MessageBox.Show("Bienvenido al sistema : " + userRespuesta.NombreUsuario, "Usuario encontrado");
                    irVentanaAdministrador();
                }
                else
                {
                    MessageBox.Show("Datos incorrectos, favor de verificar", "Error");
                }
            }
            else
            {
                MessageBox.Show("Usuario y contraseña obligatorios", "Campos vacios");
            }
        }

        private void irVentanaAdministrador()
        {
            VentanaPrincipalMunicipal ventanaAdmin = new VentanaPrincipalMunicipal();
            ventanaAdmin.Show();
            this.Close();
        }
    }
}
