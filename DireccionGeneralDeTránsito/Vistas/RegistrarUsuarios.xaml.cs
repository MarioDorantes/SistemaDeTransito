using DireccionGeneralDeTránsito.DAO;
using DireccionGeneralDeTránsito.Interfaz;
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
        Usuario usuarioEditar;
        Observer notificacion;
        Boolean isNuevo = false;
        String usuarioConectado = "";
        public RegistrarUsuarios(String usuario)
        {
            InitializeComponent();
            usuarioConectado = usuario;
            CargarTipoUsuario();
            CargarDelegaciones();

        }
        public RegistrarUsuarios()
        {
            InitializeComponent();
            CargarTipoUsuario();
            CargarDelegaciones();

        }
        public RegistrarUsuarios(Observer notificacion) : this()
        {
            this.notificacion = notificacion;
        }

        public RegistrarUsuarios(Usuario edicionUsuario, Observer notificacion) : this(notificacion)
        {
            this.usuarioEditar = edicionUsuario;
            CargarInfoUsuarioEditar();
            isNuevo = true;
        }

        public void CargarInfoUsuarioEditar()
        {
            tbx_nombreRegistro.Text = usuarioEditar.Nombre;
            tbx_aMaternoRegistro.Text = usuarioEditar.ApellidoMaterno;
            tbx_aPaternoRegistro.Text = usuarioEditar.ApellidoPaterno;
            tbx_nombreUsuario.Text = usuarioEditar.NombreUsuario;
            cmb_delegacion.Text = usuarioEditar.Delegacion;
            cmb_tipoUsuario.Text = usuarioEditar.TipoUsuario;
            pbx_contraseña.Password = usuarioEditar.Contraseña;
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
            UsuariosRegistrados ventanaUsuariosRegistrados = new UsuariosRegistrados(usuarioConectado);
            ventanaUsuariosRegistrados.Show();
            this.Close();
        }

        private void btn_confirmarRegistro_Click(object sender, RoutedEventArgs e)
        {
            String nombreUsuario = tbx_nombreUsuario.Text;
            String nombre = tbx_nombreRegistro.Text;
            String apellidoPaterno = tbx_aPaternoRegistro.Text;
            String apellidoMaterno = tbx_aMaternoRegistro.Text;
            String contraseña = pbx_contraseña.Password;
            String tipoUsuario = cmb_tipoUsuario.Text;
            String nombreDelegacion = cmb_delegacion.Text;
            int idDelegacion = DelegacionDAO.cargarIdDelecacion(nombreDelegacion);

            if(isNuevo == true)
            {
                if (pbx_contraseña.Password.Equals(pbx_confirmarPass.Password))
                {
                    String nombreUsuarioViejo = usuarioEditar.NombreUsuario;
                    int resultadoActualizar = UsuarioDAOcs.actualizarInformacionUsuario(nombre, apellidoPaterno, apellidoMaterno, nombreUsuario, contraseña,
                    idDelegacion, tipoUsuario, nombreUsuarioViejo);
                    
                    if (resultadoActualizar == 1)
                    {
                            MessageBox.Show("Información actualizada correctamente");
                        UsuariosRegistrados ventanaUsuariosRegistrados = new UsuariosRegistrados(usuarioConectado);
                        ventanaUsuariosRegistrados.Show();
                        this.Close();

                    }
                    else
                    {
                            MessageBox.Show("Error al actualizar la información, inténtelo de nuevo más tarde");
                    }
                }    
            }
            else
            {
                int seRegistro;
                if (pbx_contraseña.Password.Equals(pbx_confirmarPass.Password))
                {
                    if (tbx_nombreUsuario.Text == "" || tbx_nombreRegistro.Text == "" || tbx_aPaternoRegistro.Text == "" || tbx_aMaternoRegistro.Text == ""
                    || pbx_contraseña.Password == "" || cmb_tipoUsuario.Text == "")
                    {
                        MessageBox.Show("Campos faltantes");
                    }
                    else
                    {
                        if (UsuarioDAOcs.comprobarExistencia(nombreUsuario)==false)
                        {
                            seRegistro = UsuarioDAOcs.RegistrarUsuario(nombre, apellidoPaterno, apellidoMaterno, nombreUsuario, contraseña, idDelegacion, tipoUsuario);
                            if (seRegistro == 1)
                            {
                                MessageBox.Show("Usuario registrado correctamente");
                                UsuariosRegistrados ventanaUsuariosRegistrados = new UsuariosRegistrados(usuarioConectado);
                                ventanaUsuariosRegistrados.Show();
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("El nombre de usuario que inténtas registrar ya existe dentro del sistema");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El nombre de usuario que inténtas registrar ya existe dentro del sistema");
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
}
