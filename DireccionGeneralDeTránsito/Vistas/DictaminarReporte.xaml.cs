using DireccionGeneralDeTránsito.pocos;
using DireccionGeneralDeTránsito.DAO;
using DireccionGeneralDeTránsito.Interfaz;
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
        String usuarioConectado = "";
        public DictaminarReporte(String idReporte, String usuario)
        {
            InitializeComponent();
            usuarioConectado = usuario;
        }

        public DictaminarReporte()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            VerReportes ventanaVerReportes = new VerReportes(usuarioConectado);
            ventanaVerReportes.Show();
            this.Close();
        }

        private void btn_dictaminar_Click(object sender, RoutedEventArgs e)
        {
            string descripcionDictamen = txt_Dictamen.Text;

            if (descripcionDictamen.Length > 0)
            {
                string userNamePerito = MainWindow.userName;
                DateTime fechaYHora = DateTime.Now;
                int idReporte = VerReportes.idReporte;
                int resultadoInsercion = DictamenDAO.agregarDictamen(userNamePerito, fechaYHora, descripcionDictamen, idReporte);
                if (resultadoInsercion > 0)
                {
                    int resultadoActualizacion = ReporteDAO.cambiarEstadoReporte(idReporte);
                    if (resultadoActualizacion > 0)
                    {
                        MessageBox.Show("Se dictaminó correctamente", "Reporte dictaminado");
                        abrirVentanaVerReportes();
                        
                    }
                    else
                    {
                        MessageBox.Show("Error al cambiar el estado del reporte", "Error");
                    }

                }
                else
                {
                    MessageBox.Show("Error al agregar el dictamen", "Error");
                }
            }
            else
            {
                MessageBox.Show("Favor de llenar el campo", "ATENCIÓN");
            }
        }

        private void abrirVentanaVerReportes()
        {
            VerReportes.ventanaDetalle.Close();
            VerReportes ventanaReportes = new VerReportes();
            ventanaReportes.Show();
            this.Close();
        }
    }
}
