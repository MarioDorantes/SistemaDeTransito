using SistemaDeTransitoMunicipal.DAO;
using SistemaDeTransitoMunicipal.Interface;
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
using System.Windows.Shapes;

namespace SistemaDeTransitoMunicipal.Vistas
{
    /// <summary>
    /// Lógica de interacción para GestionarVehiculos.xaml
    /// </summary>
    public partial class GestionarVehiculos : Window, ObserverRespuesta
    {

        List<Vehiculo> vehiculos;

        public GestionarVehiculos()
        {
            InitializeComponent();
            vehiculos = new List<Vehiculo>();
            cargarDatosVehiculos();
        }

        public void cargarDatosVehiculos()
        {
            vehiculos = VehiculoDAO.obtenerVehiculos();
            dg_vehiculosRegistrados.AutoGenerateColumns = false;
            dg_vehiculosRegistrados.ItemsSource = vehiculos;
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalMunicipal ventanaAdmin = new VentanaPrincipalMunicipal();
            ventanaAdmin.Show();
            this.Close();
        }

        private void btn_registrar_Click(object sender, RoutedEventArgs e)
        {
            RegistrarVehiculo registrarVehiculo = new RegistrarVehiculo(this);
            registrarVehiculo.ShowDialog();
        }


        public void actualizaInformacion(string respuesta)
        {
            cargarDatosVehiculos();
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dg_vehiculosRegistrados.SelectedIndex;
            if (indiceSeleccion >= 0)
            {
                Vehiculo vehiculoAEliminar = vehiculos[indiceSeleccion];
                MessageBoxResult resultado = MessageBox.Show("¿Seguro desea eliminar el vehiculo con placas: " + vehiculoAEliminar.NumeroPlacas + "?", "Confirmar eliminacion", MessageBoxButton.OKCancel);
                
                if (resultado == MessageBoxResult.OK)
                {
                    int resultadoEliminacion = VehiculoDAO.eliminarVehiculo(vehiculoAEliminar.IdVehiculo);
                    if (resultadoEliminacion > 0)
                    {
                        MessageBox.Show("Vehiculo eliminado con éxito", "Eliminación exitosa");
                        this.actualizaInformacion("Eliminar");
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar", "Ocurrió un error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Para eliminar un Vehiculo, debe seleccionarlo", "Sin selección");
            }
        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dg_vehiculosRegistrados.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                Vehiculo vehiculoAEdicion = vehiculos[indiceSeleccion];
                RegistrarVehiculo modificarVehiculo = new RegistrarVehiculo(vehiculoAEdicion, this);
                modificarVehiculo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Para editar un vehiculo debe seleccionarlo", "Sin selección");
            }
        }
    }
}
