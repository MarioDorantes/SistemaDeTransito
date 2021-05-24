using DireccionGeneralDeTránsito.DAO;
using DireccionGeneralDeTránsito.pocos;
using DireccionGeneralDeTránsito.Vistas;
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
    /// Lógica de interacción para RegistrarDelegación.xaml
    /// </summary>
    public partial class RegistrarDelegación : Window
    {
        public RegistrarDelegación()
        {
            InitializeComponent();
            cargarMinicipios();
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            DelegacionesRegistradas ventanaDelegaciones = new DelegacionesRegistradas();
            ventanaDelegaciones.Show();
            this.Close();
        }

        private void cargarMinicipios()
        {
            List<string> municipios = new List<string>();
            municipios.Add("Xalapa-Enriquez");
            municipios.Add("Veracrúz");
            municipios.Add("Boca del Rio");
            municipios.Add("Coatepec");
            municipios.Add("Xico");
            municipios.Add("Perote");
            municipios.Add("Banderilla");
            municipios.Add("Jiolotepec");
            municipios.Add("Las Haldas");
            municipios.Add("Naolinco");
            municipios.Add("Teocelo");
            municipios.Add("Martinez de la Torre");
            municipios.Add("Tlacotalpan");
            municipios.Add("Tlapacoyan");
            municipios.Add("Poza rica");
            municipios.Add("Coatzacoalcos");
            municipios.Add("Tierra blanca");
            municipios.Sort();
            cmb_municipio.ItemsSource = municipios;
        }

        private void btn_confirmarRegistroDelegacion_Click(object sender, RoutedEventArgs e)
        {
            String nombreDelegacion = txb_nombreDelegacion.Text;
            String colonia = txb_coloniaDelegacion.Text;
            String codigoPostal = txb_codigoPostal.Text;
            String calleNum = txb_calle.Text;
            String numeroTel = txb_telefono.Text;
            String email = txb_correo.Text;
            String municipio = cmb_municipio.Text;
            if(txb_nombreDelegacion.Text =="" || txb_coloniaDelegacion.Text == "" || txb_codigoPostal.Text == ""
                || txb_calle.Text == "" || txb_telefono.Text == "" || txb_correo.Text == "" || cmb_municipio.Text == "")
            {
                MessageBox.Show("Campos faltantes");
            }
            else
            {
                if (DelegacionDAO.RegistrarDelegacion(nombreDelegacion, codigoPostal, colonia, municipio, calleNum, email, numeroTel) == 1)
                {
                    MessageBox.Show("Delegación registrada correctamente");
                }
                else
                {
                    MessageBox.Show("Error de registro en la delegación, inténtelo de nuevo");
                }
            }
        }
    }
}
