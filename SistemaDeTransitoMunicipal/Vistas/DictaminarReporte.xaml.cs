﻿using SistemaDeTransitoMunicipal.pocos;
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
    /// Lógica de interacción para DictaminarReporte.xaml
    /// </summary>
    public partial class DictaminarReporte : Window
    {
        public DictaminarReporte()
        {
            InitializeComponent();
        }

        public DictaminarReporte(Reporte reporteDictaminar)
        {
            InitializeComponent();
            
        }

       /* private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {

        }
            VerReportes ventanaVerReportes = new VerReportes();
            ventanaVerReportes.Show();
            this.Close();
        }*/
    }
}
