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
using System.Windows.Shapes;

namespace DireccionGeneralDeTránsito
{
    /// <summary>
    /// Lógica de interacción para DetalleDeReportes.xaml
    /// </summary>
    public partial class DetalleDeReportes : Window
    {
        public DetalleDeReportes()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalAdministrativo inicio = new VentanaPrincipalAdministrativo();
            inicio.Show();
            this.Close();
        }
    }
}
