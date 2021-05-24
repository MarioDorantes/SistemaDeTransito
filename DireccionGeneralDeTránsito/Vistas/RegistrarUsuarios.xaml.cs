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
    /// Lógica de interacción para RegistrarUsuarios.xaml
    /// </summary>
    public partial class RegistrarUsuarios : Window
    {
        public RegistrarUsuarios()
        {
            InitializeComponent();
            CargarTipoUsuario();
            CargarDelegaciones();

        }
        public void CargarTipoUsuario()
        {
            List<string> cargos = new List<string>();
            cargos.Add("Administrativo");
            cargos.Add("Perito");
            cargos.Add("Soporte");
            cargos.Add("Atención");
            cmb_tipoUsuario.ItemsSource = cargos;
        }
        
        public void CargarDelegaciones()
        {
            cmb_delegacion.ItemsSource = DelegacionDAO.ObtenerDelegaciones();
        }
        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            UsuariosRegistrados ventanaUsuariosRegistrados = new UsuariosRegistrados();
            ventanaUsuariosRegistrados.Show();
            this.Close();
        }

        private void btn_confirmarRegistro_Click(object sender, RoutedEventArgs e)
        {
            int seRegistro = 0;
            String nombreUsuario = tbx_nombreUsuario.Text;
            String nombre = tbx_nombreRegistro.Text;
            String apellidoPaterno = tbx_aPaternoRegistro.Text;
            String apellidoMaterno = tbx_aMaternoRegistro.Text;
            String contraseña = pbx_contraseña.Password;
            String tipoUsuario = cmb_tipoUsuario.Text;
            String nombreDelegacion = cmb_delegacion.Text;
            int idDelegacion = DelegacionDAO.cargarIdDelecacion(nombreDelegacion);

            if (pbx_contraseña.Password.Equals(pbx_confirmarPass.Password))
            {
                if (tbx_nombreUsuario.Text == "" || tbx_nombreRegistro.Text == "" || tbx_aPaternoRegistro.Text == "" || tbx_aMaternoRegistro.Text == ""
                || pbx_contraseña.Password == "" || cmb_tipoUsuario.Text == "")
                {
                    MessageBox.Show("Campos faltantes");
                }
                else
                {
                    seRegistro = UsuarioDAOcs.RegistrarUsuario(nombre, apellidoPaterno, apellidoMaterno, nombreUsuario, contraseña, idDelegacion, tipoUsuario);
                    if(seRegistro == 1)
                    {
                        MessageBox.Show("Usuario registrado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Error de registro");
                    }
                }
            }
            else
            {
                lbl_passValidador.Visibility = Visibility.Visible;
                pbx_contraseña.Foreground = Brushes.Red;
                pbx_confirmarPass.Foreground = Brushes.Red;
            }
            
        }
    }
}
