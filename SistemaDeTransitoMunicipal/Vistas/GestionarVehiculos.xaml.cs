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
using System.Windows.Shapes;

namespace SistemaDeTransitoMunicipal.Vistas
{
    /// <summary>
    /// Lógica de interacción para GestionarVehiculos.xaml
    /// </summary>
    public partial class GestionarVehiculos : Window
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
            RegistrarVehiculo registrarVehiculo = new RegistrarVehiculo();
            registrarVehiculo.Show();
            this.Close();
        }
    }
}
