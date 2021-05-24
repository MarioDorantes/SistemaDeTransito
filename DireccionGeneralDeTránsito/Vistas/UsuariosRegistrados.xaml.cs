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
using System.Windows.Shapes;

namespace DireccionGeneralDeTránsito.Vistas
{
    /// <summary>
    /// Lógica de interacción para UsuariosRegistrados.xaml
    /// </summary>
    public partial class UsuariosRegistrados : Window
    {
        List<Usuario> usuarios;

        public UsuariosRegistrados()
        {
            InitializeComponent();
            usuarios = new List<Usuario>();
            cargarUsuarios();
        }

        private void cargarUsuarios()
        {
            usuarios = UsuarioDAOcs.ObtenerUsuarios();
            dg_UsuariosRegistrados.AutoGenerateColumns = false;
            dg_UsuariosRegistrados.ItemsSource = usuarios;
        }
        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalAdministrativo ventanaPrincipal = new VentanaPrincipalAdministrativo();
            ventanaPrincipal.Show();
            this.Close();
        }

        private void btn_registrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            RegistrarUsuarios ventanaRegistroUsuario = new RegistrarUsuarios();
            ventanaRegistroUsuario.Show();
            this.Close();
        }
    }
}
