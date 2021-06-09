﻿using DireccionGeneralDeTránsito.pocos;
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

namespace DireccionGeneralDeTránsito
{
    /// <summary>
    /// Lógica de interacción para DetalleDeReportes.xaml
    /// </summary>
    public partial class DetalleDeReportes : Window
    {
        String usuarioConectado = "";
        public DetalleDeReportes(String usuario)

        DictaminarReporte ventanaDictaminar = new DictaminarReporte();
        public DetalleDeReportes()
        {
            InitializeComponent();
            usuarioConectado = usuario;
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalAdministrativo inicio = new VentanaPrincipalAdministrativo(usuarioConectado);
            inicio.Show();
            VerReportes ventanaVerReportes = new VerReportes();
            ventanaVerReportes.Show();
            this.Close();
        }
        
        private void btn_dictaminar_Click(object sender, RoutedEventArgs e)
        {
            ventanaDictaminar.Show();
        }
    }
}
