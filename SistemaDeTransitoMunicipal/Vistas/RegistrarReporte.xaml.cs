using Microsoft.Win32;
using SistemaDeTransitoMunicipal.DAO;
using SistemaDeTransitoMunicipal.pocos;
using System;
using System.Collections.Generic;
using System.IO;
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
            salir();
        }

        private void salir()
        {
            VentanaPrincipalMunicipal inicio = new VentanaPrincipalMunicipal();
            inicio.Show();
            this.Close();
        }


        private void btn_agregarADataGrid_Click(object sender, RoutedEventArgs e)
        {
            int seleccion = dg_listaConductores.SelectedIndex;

            if (seleccion >= 0)
            {

                Vehiculo vehiculoAAgregar = vehiculos[seleccion];

                vehiculosReporte.Add(vehiculoAAgregar);
                dg_agregados.AutoGenerateColumns = false;
                dg_agregados.ItemsSource = null;
                dg_agregados.ItemsSource = vehiculosReporte;

            }
            else
            {
                MessageBox.Show("Para agregar un registro, primero debe seleccionarlo", "Sin selección");
            }
        }

        Uri fileUri1;

        private void btn_foto1_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                if (img_num1.Source == null)
                {
                    fileUri1 = new Uri(openFileDialog.FileName);
                    img_num1.Source = new BitmapImage(fileUri1);
                }
                else if (img_num2.Source == null)
                {
                    Uri fileUri2 = new Uri(openFileDialog.FileName);
                    img_num2.Source = new BitmapImage(fileUri2);
                }
                else if (img_num3.Source == null)
                {
                    Uri fileUri3 = new Uri(openFileDialog.FileName);
                    img_num3.Source = new BitmapImage(fileUri3);
                }
                else if (img_num4.Source == null)
                {
                    Uri fileUri4 = new Uri(openFileDialog.FileName);
                    img_num4.Source = new BitmapImage(fileUri4);
                }
                else if (img_num5.Source == null)
                {
                    Uri fileUri5 = new Uri(openFileDialog.FileName);
                    img_num5.Source = new BitmapImage(fileUri5);
                }
                else if (img_num6.Source == null)
                {
                    Uri fileUri6 = new Uri(openFileDialog.FileName);
                    img_num6.Source = new BitmapImage(fileUri6);
                }
                else if (img_num7.Source == null)
                {
                    Uri fileUri7 = new Uri(openFileDialog.FileName);
                    img_num7.Source = new BitmapImage(fileUri7);
                }
                else if (img_num8.Source == null)
                {
                    Uri fileUri8 = new Uri(openFileDialog.FileName);
                    img_num8.Source = new BitmapImage(fileUri8);
                }
            }
        }

 
        private void btn_registrar_reporte_Click(object sender, RoutedEventArgs e)
        {
            String direccion = txt_direccion.Text;
            String fecha = txt_fecha.Text;
            String estatus = "Pendiente";

            Boolean camposLlenos = true;

            if (direccion.Length == 0)
            {
                camposLlenos = false;
                txt_direccion.BorderBrush = Brushes.Red;
            }
            if (fecha.Length == 0)
            {
                camposLlenos = false;
                txt_fecha.BorderBrush = Brushes.Red;
            }
            if(img_num1.Source == null)
            {
                camposLlenos = false;
            }

            if (camposLlenos)
            {
                int idDelegacion = MainWindow.idDelegacionLoggeada;

                //PRUEBA PARA PASAR IMAGEN A BYTE
                /*
                String imag1Aux = img_num1.Source.ToString();
                byte[] imagen1 = Encoding.ASCII.GetBytes(imag1Aux);
                */

                byte[] imagen1 = System.IO.File.ReadAllBytes(fileUri1.AbsoluteUri);

                int resultado = ReporteDAO.agregarReporte(idDelegacion, fecha, estatus, direccion, imagen1);

                if (resultado > 0)
                {
                    MessageBox.Show("El Reporte se registro exitosamente", "Registro exitoso");

                }
                else
                {
                    MessageBox.Show("No fue posible hacer el registro", "Ocurrió un error");
                }

                salir();

            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos", "Campos vacíos");
            }



        }



    }
}
