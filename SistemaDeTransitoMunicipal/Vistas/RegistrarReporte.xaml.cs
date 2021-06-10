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


        Vehiculo vehiculoAAgregar;

        private void btn_agregarADataGrid_Click(object sender, RoutedEventArgs e)
        {
            int seleccion = dg_listaConductores.SelectedIndex;

            if (seleccion >= 0)
            {

                vehiculoAAgregar = vehiculos[seleccion];

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
        Uri fileUri2;
        Uri fileUri3;
        Uri fileUri4;
        Uri fileUri5;
        Uri fileUri6;
        Uri fileUri7;
        Uri fileUri8;

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
                    fileUri2 = new Uri(openFileDialog.FileName);
                    img_num2.Source = new BitmapImage(fileUri2);
                }
                else if (img_num3.Source == null)
                {
                    fileUri3 = new Uri(openFileDialog.FileName);
                    img_num3.Source = new BitmapImage(fileUri3);
                }
                else if (img_num4.Source == null)
                {
                    fileUri4 = new Uri(openFileDialog.FileName);
                    img_num4.Source = new BitmapImage(fileUri4);
                }
                else if (img_num5.Source == null)
                {
                    fileUri5 = new Uri(openFileDialog.FileName);
                    img_num5.Source = new BitmapImage(fileUri5);
                }
                else if (img_num6.Source == null)
                {
                    fileUri6 = new Uri(openFileDialog.FileName);
                    img_num6.Source = new BitmapImage(fileUri6);
                }
                else if (img_num7.Source == null)
                {
                    fileUri7 = new Uri(openFileDialog.FileName);
                    img_num7.Source = new BitmapImage(fileUri7);
                }
                else if (img_num8.Source == null)
                {
                    fileUri8 = new Uri(openFileDialog.FileName);
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
            if (img_num2.Source == null)
            {
                camposLlenos = false;
            }
            if (img_num3.Source == null)
            {
                camposLlenos = false;
            }

            if (camposLlenos)
            {
                int idDelegacion = MainWindow.idDelegacionLoggeada;

                byte[] imagen1;
                byte[] imagen2;
                byte[] imagen3;
                byte[] imagen4;
                byte[] imagen5;
                byte[] imagen6;
                byte[] imagen7;
                byte[] imagen8;

                imagen1 = System.IO.File.ReadAllBytes(fileUri1.LocalPath);
                imagen2 = System.IO.File.ReadAllBytes(fileUri2.LocalPath);
                imagen3 = System.IO.File.ReadAllBytes(fileUri3.LocalPath);

                if (img_num4.Source == null)
                {
                    imagen4 = new byte [0];
                }
                else
                {
                    imagen4 = System.IO.File.ReadAllBytes(fileUri4.LocalPath);
                }

                if (img_num5.Source == null)
                {
                    imagen5 = new byte[0];
                }
                else
                {
                    imagen5 = System.IO.File.ReadAllBytes(fileUri5.LocalPath);
                }

                if (img_num6.Source == null)
                {
                    imagen6 = new byte[0];
                }
                else
                {
                    imagen6 = System.IO.File.ReadAllBytes(fileUri6.LocalPath);
                }

                if (img_num7.Source == null)
                {
                    imagen7 = new byte[0];
                }
                else
                {
                    imagen7 = System.IO.File.ReadAllBytes(fileUri7.LocalPath);
                }

                if (img_num8.Source == null)
                {
                    imagen8 = new byte[0];
                }
                else
                {
                    imagen8 = System.IO.File.ReadAllBytes(fileUri8.LocalPath);
                }


                int resultado = ReporteDAO.agregarReporte(idDelegacion, fecha, estatus, direccion, imagen1, imagen2, imagen3, imagen4, imagen5, imagen6, imagen7, imagen8);

                int resultado2 = 0;
                int reporteMax = ReporteDAO.obtenerIdReporteMax();

                Console.WriteLine("El reporte max es: " + reporteMax);

                foreach (Vehiculo vehiculoAReporte in vehiculosReporte)
                {
                    
                    resultado2 = ReporteConductorVehiculoDAO.agregarReporteConductorVehiculo(reporteMax, vehiculoAReporte.NumeroLicencia, vehiculoAReporte.IdVehiculo);
                    
                }

                if (resultado > 0 && resultado2 > 0)
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
                MessageBox.Show("Favor de llenar todos los campos e ingresar mínimo 3 fotografías", "Campos vacíos");
            }



        }



    }
}
