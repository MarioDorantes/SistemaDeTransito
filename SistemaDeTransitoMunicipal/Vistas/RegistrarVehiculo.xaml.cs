using SistemaDeTransitoMunicipal.DAO;
using SistemaDeTransitoMunicipal.pocos;
using SistemaDeTransitoMunicipal.Vistas;
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
    /// Lógica de interacción para RegistrarVehiculo.xaml
    /// </summary>
    public partial class RegistrarVehiculo : Window
    {
        List<Conductor> conductores;

        public RegistrarVehiculo()
        {
            InitializeComponent();
            cargarConductores();
        }
        
        private void cargarConductores()
        {
            conductores = ConductorDAO.obtenerTodosLosConductores();
            cmb_conductores.ItemsSource = conductores;
        }


        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            salirAPrincipal();
        }

        private void salirAPrincipal()
        {
            GestionarVehiculos regresar = new GestionarVehiculos();
            regresar.Show();
            this.Close();
        }

        private void btn_registrar_Click(object sender, RoutedEventArgs e)
        {
            String marca = txt_marca.Text;
            String modelo = txt_modelo.Text;
            String año = txt_año.Text;
            String color = txt_color.Text;
            String aseguradora = txt_aseguradora.Text;
            String numPoliza = txt_num_poliza.Text;
            String numPlacas = txt_num_placas.Text;
            int posicionConductor = cmb_conductores.SelectedIndex;
            

            Boolean camposLlenos = true;

            if (marca.Length == 0)
            {
                camposLlenos = false;
                txt_marca.BorderBrush = Brushes.Red;
            }
            if(modelo.Length == 0)
            {
                camposLlenos = false;
                txt_modelo.BorderBrush = Brushes.Red;
            }
            if (año.Length == 0)
            {
                camposLlenos = false;
                txt_año.BorderBrush = Brushes.Red;
            }
            if (color.Length == 0)
            {
                camposLlenos = false;
                txt_color.BorderBrush = Brushes.Red;
            }
            if (aseguradora.Length == 0)
            {
                camposLlenos = false;
                txt_aseguradora.BorderBrush = Brushes.Red;
            }
            if (numPoliza.Length == 0)
            {
                camposLlenos = false;
                txt_num_poliza.BorderBrush = Brushes.Red;
            }
            if (numPlacas.Length == 0)
            {
                camposLlenos = false;
                txt_num_placas.BorderBrush = Brushes.Red;
            }
            if(posicionConductor < 0)
            {
                camposLlenos = false;
                cmb_conductores.BorderBrush = Brushes.Red;

            }


            if (camposLlenos)
            {

                String numLicencia = conductores[cmb_conductores.SelectedIndex].NumeroLicencia;

                int resultado = VehiculoDAO.agregarVehiculo(numLicencia, marca, modelo, año, color, aseguradora, numPoliza, numPlacas);

                if (resultado > 0)
                {
                    MessageBox.Show("El vehiculo se registro exitosamente", "Registro exitoso");
                    
                }
                else
                {
                    MessageBox.Show("No fue posible hacer el registro", "Ocurrió un error");
                }

                salirAPrincipal();
            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos", "Campos vacíos");
            }

        }
    }
}
