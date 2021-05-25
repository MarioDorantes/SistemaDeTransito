using DireccionGeneralDeTránsito.DAO;
using DireccionGeneralDeTránsito.Interfaz;
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
    public partial class UsuariosRegistrados : Window, Observer
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

        private void btn_eliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dg_UsuariosRegistrados.SelectedIndex;
            if (indiceSeleccion >= 0)
            {
                Usuario usuarioEliminar = usuarios[indiceSeleccion];
                MessageBoxResult resultado = MessageBox.Show("¿Estas seguro de eliminar al usuario " + usuarioEliminar.Nombre + " " + usuarioEliminar.ApellidoMaterno
                    + "?", "Confirmar accion", MessageBoxButton.OKCancel);
                if (resultado==MessageBoxResult.OK)
                {
                    int resultadoEliminar = UsuarioDAOcs.EliminarUsuario(usuarioEliminar.NombreUsuario);
                    if(resultadoEliminar == 1)
                    {
                        MessageBox.Show("Usuario eliminado correctamente");
                    }else
                    {
                        MessageBox.Show("Error al eliminar el usuario");
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar a un usuario a eliminar");
            }
        }

        private void btn_modificarUsuario_Click(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dg_UsuariosRegistrados.SelectedIndex;
            if(indiceSeleccion >= 0)
            {
                Usuario usuarioEditar = usuarios[indiceSeleccion];
                RegistrarUsuarios formEditarUsuario = new RegistrarUsuarios(usuarioEditar, this);
                formEditarUsuario.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario no seleccionado");
            }
        }

        public void actualizaInformación(string operacion)
        {
            
        }
    }
}
