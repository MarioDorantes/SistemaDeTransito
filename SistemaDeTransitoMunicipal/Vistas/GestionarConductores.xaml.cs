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
    /// Lógica de interacción para GestionarConductores.xaml
    /// </summary>
    public partial class GestionarConductores : Window, ObserverRespuesta
    {
        List<Conductor> conductores;

        public GestionarConductores()
        {
            InitializeComponent();
            conductores = new List<Conductor>();
            cargarConductores();
        }

        public void actualizainformacion(String operacion)
        {
            cargarConductores();
        }

        private void cargarConductores()
        {
            int idDelegacionLoggeada = MainWindow.idDelegacionLoggeada;
            conductores = ConductorDAO.obtenerConductores(idDelegacionLoggeada);
            dg_conductores.AutoGenerateColumns = false;
            dg_conductores.ItemsSource = conductores;
        }

        private void btn_registrar_Click(object sender, RoutedEventArgs e)
        {
            registrarConductor ventanaRegistrar = new registrarConductor(this);
            ventanaRegistrar.Show();
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalMunicipal ventanaAdmin = new VentanaPrincipalMunicipal();
            ventanaAdmin.Show();
            this.Close();
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dg_conductores.SelectedIndex;
            if(indiceSeleccion >= 0)
            {
                Conductor conductorEdicion = conductores[indiceSeleccion];
                registrarConductor editarConductor = new registrarConductor(conductorEdicion, this);
                editarConductor.ShowDialog();
            }
            else
            {
                MessageBox.Show("Para editar un conductor, primero debe seleccionarlo", "ATENCIÓN");
            }
        }

        public void actualizaInformacion(string respuesta)
        {
            throw new NotImplementedException();
        }
    }
}
