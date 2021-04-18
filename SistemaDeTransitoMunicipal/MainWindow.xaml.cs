﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaDeTransitoMunicipal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_IniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalMunicipal ventanaInicio = new VentanaPrincipalMunicipal();
            ventanaInicio.Show();
            this.Close();
        }

        private void btn_registrarConductor_Click(object sender, RoutedEventArgs e)
        {
            RegistrarConductor ventanaRegistrar = new RegistrarConductor();
            ventanaRegistrar.Show();
            this.Close();
        }
    }
}
