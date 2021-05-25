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
    /// Lógica de interacción para RegistrarConductor.xaml
    /// </summary>
    public partial class registrarConductor : Window
    {

        List<Delegacion> delegaciones = null;
        ObserverRespuesta notificacion;
        Conductor conductorEdicion;
        Boolean esNuevo = true;
        String numeroLicenciaCondcutor;

        public registrarConductor()
        {
            InitializeComponent();
            delegaciones = new List<Delegacion>();
            cargarDelegaciones();
        }

        public registrarConductor(ObserverRespuesta notificacion) : this()
        {
            this.notificacion = notificacion;
        }

        public registrarConductor(Conductor conductorEdicion, ObserverRespuesta notificacion) : this(notificacion)
        {
            this.conductorEdicion = conductorEdicion;
            cargarInformacionConductor();
            esNuevo = false;
        }

        private void cargarInformacionConductor()
        {
            numeroLicenciaCondcutor = conductorEdicion.NumeroLicencia;
            txt_numeroLicencia.Text = conductorEdicion.NumeroLicencia;
            txt_numeroLicencia.IsEnabled = false;
            txt_nombre.Text = conductorEdicion.Nombre;
            txt_paterno.Text = conductorEdicion.Paternos;
            txt_materno.Text = conductorEdicion.Maternos;
            txt_telefono.Text = conductorEdicion.NumeroTelefono;
            txt_nacimiento.Text = conductorEdicion.FechaNacimiento;
        }

        private void cargarDelegaciones()
        {
            delegaciones = DelegacionDAO.obtenerDelegaciones();
            cb_delegacion.ItemsSource = delegaciones;
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_registrar_Click(object sender, RoutedEventArgs e)
        {
            String numeroLicencia = txt_numeroLicencia.Text;
            String nombre = txt_nombre.Text;
            String paterno = txt_paterno.Text;
            String materno = txt_materno.Text;
            String fechaNacimiento = txt_nacimiento.Text;
            String telefono = txt_telefono.Text;
            int posicionSeleccion = cb_delegacion.SelectedIndex;

            Boolean camposLlenos = true;

            if(numeroLicencia.Length == 0)
            {
                camposLlenos = false;
                txt_numeroLicencia.BorderBrush = Brushes.Red;
            }
            if(nombre.Length == 0)
            {
                camposLlenos = false;
                txt_nombre.BorderBrush = Brushes.Red;
            }
            if(paterno.Length == 0)
            {
                camposLlenos = false;
                txt_paterno.BorderBrush = Brushes.Red;
            }
            if (materno.Length == 0)
            {
                camposLlenos = false;
                txt_materno.BorderBrush = Brushes.Red;
            }
            if(fechaNacimiento.Length == 0){
                camposLlenos = false;
                txt_nacimiento.BorderBrush = Brushes.Red;
            }
            if(telefono.Length == 0)
            {
                camposLlenos = false;
                txt_telefono.BorderBrush = Brushes.Red;
            }
            if(posicionSeleccion < 0)
            {
                camposLlenos = false;
                cb_delegacion.BorderBrush = Brushes.Red;
            }

            if (camposLlenos)
            {
                int delegacionSeleccionada = delegaciones[posicionSeleccion].IdDelegacion;

                int resultado = ConductorDAO.agregarConductor(numeroLicencia, nombre, paterno, materno, telefono, fechaNacimiento, delegacionSeleccionada);
                if(resultado > 0)
                {
                    MessageBox.Show("El Conductor se agregó exitosamente", "Registro exitoso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No fue posible hacer el registro", "Ocurrió un error");
                }
            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos", "Campos vacíos");
            }
        }
    }
}
