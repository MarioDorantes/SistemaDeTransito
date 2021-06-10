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
    /// Lógica de interacción para DelegacionesRegistradas.xaml
    /// </summary>
    public partial class DelegacionesRegistradas : Window, Observer
    {
        List<Delegacion> delegaciones;
        String usuarioConectado = "";
        public DelegacionesRegistradas(String usuario)
        {
            InitializeComponent();
            usuarioConectado = usuario;
            delegaciones = new List<Delegacion>();
            CargarDelegaciones();
            if (!MainWindow.tipoUsuario.Equals("Administrativo"))
            {
                btn_editarDelegacion.IsEnabled = false;
                btn_eliminarDelegacion.IsEnabled = false;
                btn_registroDelegacion.IsEnabled = false;
            }
        }
        public void CargarDelegaciones()
        {
            delegaciones = DelegacionDAO.ObtenerDelegaciones();
            dg_delegaciones.AutoGenerateColumns = false;
            dg_delegaciones.ItemsSource = delegaciones;
        }
        private void btn_registroDelegacion_Click(object sender, RoutedEventArgs e)
        {
            RegistrarDelegación ventanaRegistro = new RegistrarDelegación();
            ventanaRegistro.Show();
            this.Close();
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalAdministrativo ventanaPrincipal = new VentanaPrincipalAdministrativo(usuarioConectado);
            ventanaPrincipal.Show();
            this.Close();
        }

        private void btn_editarDelegacion_Click(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dg_delegaciones.SelectedIndex;
            if (indiceSeleccion >= 0)
            {
                Delegacion delegacionActualizar = delegaciones[indiceSeleccion];
                RegistrarDelegación ventanaDelegacionActualizar = new RegistrarDelegación(delegacionActualizar, this);
                ventanaDelegacionActualizar.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Delegación no seleccionada");
            }
        }

        private void btn_eliminarDelegacion_Click(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dg_delegaciones.SelectedIndex;
            if (indiceSeleccion >= 0)
            {
                Delegacion delegacionEliminar = delegaciones[indiceSeleccion];
                MessageBoxResult resultado = MessageBox.Show("¿Estas seguro de eliminar la delegación " + delegacionEliminar.NombreAlias + "?", "Confirmar accion", MessageBoxButton.OKCancel);
                int idDelegacion = DelegacionDAO.cargarIdDelecacion(delegacionEliminar.NombreAlias);
                if (resultado == MessageBoxResult.OK)
                {
                    int tieneUsuarios = UsuarioDAOcs.ValidarUsuariosDelegacion(idDelegacion);
                    if(tieneUsuarios == 0)
                    {
                        int resultadoEliminar = DelegacionDAO.EliminarDelegacion(idDelegacion);
                        if (resultadoEliminar == 1)
                        {
                            MessageBox.Show("Delegacion eliminada correctamente");
                            CargarDelegaciones();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar la delegación");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La delegación no se ha podido eliminar debido a que tiene usuarios registrados en ella");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar una delegación para continuar");
            }
        }

        public void actualizaInformación(string operacion)
        {
            throw new NotImplementedException();
        }
    }
}
