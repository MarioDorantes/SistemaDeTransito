using SistemaDeTransitoMunicipal.vistas;
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
    public partial class VentanaPrincipalMunicipal : Window
    {
        public VentanaPrincipalMunicipal()
        {
            InitializeComponent();
        }


        private void btn_RegistrarReporte_Click(object sender, RoutedEventArgs e)
        {
            RegistrarReporte registrarReporte = new RegistrarReporte();
            registrarReporte.Show();
            this.Close();
        }

        private void btn_HistorialDeReportes_Click(object sender, RoutedEventArgs e)
        {
            HistorialDeReportes historialDeReportes = new HistorialDeReportes();
            historialDeReportes.Show();
            this.Close();
        }

        private void btn_registrar_conductor_Click(object sender, RoutedEventArgs e)
        {
            GestionarConductores ventanaGestionar = new GestionarConductores();
            ventanaGestionar.Show();
            this.Close();
        }

        private void btn_dictamen_reporte_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_gestionar_vehiculos_Click(object sender, RoutedEventArgs e)
        {
            GestionarVehiculos gestionarVehiculos = new GestionarVehiculos();
            gestionarVehiculos.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicioDeSesion = new MainWindow();
            inicioDeSesion.Show();
            this.Close();
        }

        private void btn_chat_Click(object sender, RoutedEventArgs e)
        {
            VentanaChat ventanaChat = new VentanaChat();
            ventanaChat.Show();
            this.Close();
        }
    }
}
