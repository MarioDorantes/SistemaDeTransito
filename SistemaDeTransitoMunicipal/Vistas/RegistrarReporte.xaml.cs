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

namespace SistemaDeTransitoMunicipal
{
    /// <summary>
    /// Lógica de interacción para RegistrarReporte.xaml
    /// </summary>
    public partial class RegistrarReporte : Window
    {

        List<Vehiculo> vehiculos;
        List<Vehiculo> vehiculosReporte;

        public RegistrarReporte()
        {
            InitializeComponent();
            vehiculos = new List<Vehiculo>();
            vehiculosReporte = new List<Vehiculo>();
            extraerDatosConductorVehiculo();
        }

        public void extraerDatosConductorVehiculo()
        {
            vehiculos = VehiculoDAO.obtenerInformacionVehiculosParaElReporte();
            dg_listaConductores.AutoGenerateColumns = false;
            dg_listaConductores.ItemsSource = vehiculos;
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalMunicipal inicio = new VentanaPrincipalMunicipal();
            inicio.Show();
            this.Close();
        }

        private void btn_agregarADataGrid_Click(object sender, RoutedEventArgs e)
        {
            int seleccion = dg_listaConductores.SelectedIndex;
            if(seleccion >= 0)
            {
                Vehiculo vehiculoAAgregar = vehiculos[seleccion];
                if(vehiculosReporte.Count != 0)
                {
                    List<int> idVehiculos = new List<int>();

                    for(int i = 0; i < vehiculos.Count; i++)
                    {
                        //Console.WriteLine(vehiculosReporte[i].IdVehiculo + "\n");
                        idVehiculos.Add(vehiculosReporte[i].IdVehiculo);
                    }
                }
                else
                {
                    vehiculosReporte.Add(vehiculoAAgregar);
                    dg_agregados.AutoGenerateColumns = false;
                    dg_agregados.ItemsSource = null;
                    dg_agregados.ItemsSource = vehiculosReporte;
                    dg_listaConductores.SelectedIndex = -1;
                }
            }
            else
            {
                MessageBox.Show("Para agregar un registro, primero debe seleccionarlo", "Sin selección");
            }
        }



    }
}
