﻿using SistemaDeTransitoMunicipal.DAO;
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
    public partial class GestionarConductores : Window
    {
        List<Conductor> conductores;

        public GestionarConductores()
        {
            InitializeComponent();
            conductores = new List<Conductor>();
            cargarConductores();
        }

        private void cargarConductores()
        {
            conductores = ConductorDAO.obtenerConductores();
            dg_conductores.ItemsSource = conductores;
        }

        private void btn_registrar_Click(object sender, RoutedEventArgs e)
        {
            RegistrarConductor ventanaRegistrar = new RegistrarConductor();
            ventanaRegistrar.Show();
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalMunicipal ventanaAdmin = new VentanaPrincipalMunicipal();
            ventanaAdmin.Show();
            this.Close();
        }
    }
}