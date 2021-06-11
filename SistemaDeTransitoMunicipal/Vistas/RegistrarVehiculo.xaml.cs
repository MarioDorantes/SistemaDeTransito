using SistemaDeTransitoMunicipal.DAO;
using SistemaDeTransitoMunicipal.Interface;
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
        ObserverRespuesta notificacion;
        Vehiculo vehiculoEdicion;
        Boolean isNuevo = true;
        int idVehiculo = 0;

        public RegistrarVehiculo()
        {
            InitializeComponent();
            conductores = new List<Conductor>();
            cargarConductores();
        }

        public RegistrarVehiculo(ObserverRespuesta notificacion) : this()
        {
            this.notificacion = notificacion;
        }

        public RegistrarVehiculo(Vehiculo vehiculoEdicion, ObserverRespuesta notificacion) : this(notificacion)
        {
            this.vehiculoEdicion = vehiculoEdicion;
            isNuevo = false;
            CargarInformacionVehiculoEdicion();
        }

        private void CargarInformacionVehiculoEdicion()
        {

            idVehiculo = vehiculoEdicion.IdVehiculo;
            txt_marca.Text = vehiculoEdicion.Marca;
            txt_modelo.Text = vehiculoEdicion.Modelo;
            txt_año.Text = vehiculoEdicion.Año;
            txt_color.Text = vehiculoEdicion.Color;
            txt_aseguradora.Text = vehiculoEdicion.Aseguradora;
            txt_num_poliza.Text = vehiculoEdicion.NumeroPoliza;
            txt_num_placas.Text = vehiculoEdicion.NumeroPlacas;
            int posConductor = obtenerPosConductor(vehiculoEdicion.NumeroLicencia);
            cmb_conductores.SelectedIndex = posConductor;

        }

        private int obtenerPosConductor(String numLicencia)
        {
            int resultado = 0;
            if (conductores.Count > 0)
            {
                for (int i = 0; i < conductores.Count; i++)
                {
                    Conductor conductor = conductores[i];
                    if (conductor.NumeroLicencia == numLicencia)
                    {
                        return i;
                    }
                }
            }
            return resultado;
        }

        private void cargarConductores()
        {
            conductores = ConductorDAO.obtenerTodosLosConductores();
            cmb_conductores.ItemsSource = conductores;
        }


        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
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
            Boolean placasRepetida = false;

            placasRepetida = VehiculoDAO.verificarPlacasRegistradas(numPlacas);

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

                int resultado = 0;

                if (isNuevo)
                {

                    if (!placasRepetida)
                    {
                        resultado = VehiculoDAO.agregarVehiculo(numLicencia, marca, modelo, año, color, aseguradora, numPoliza, numPlacas);

                        if (resultado > 0)
                        {
                            MessageBox.Show("El vehiculo se registro exitosamente", "Registro exitoso");
                            notificacion.actualizaInformacion("Registrar");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No fue posible hacer el registro", "Ocurrió un error");
                        }

                       
                    }
                    else
                    {
                        MessageBox.Show("Este numero de placas han sido registradas anteriormente.", "Atención");
                    }

                    
                }
                else
                {
                    
                    resultado = VehiculoDAO.modificarVehiculo(numLicencia, marca, modelo, año, color, aseguradora, numPoliza, numPlacas, vehiculoEdicion.IdVehiculo);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Vehiculo actualizado exitosamente", "Mensaje de confirmación");
                        notificacion.actualizaInformacion("Editar");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error, intente más tarde", "Error");
                    }
                    
                    
                }
                

            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos", "Campos vacíos");
            }

        }
    }
}
