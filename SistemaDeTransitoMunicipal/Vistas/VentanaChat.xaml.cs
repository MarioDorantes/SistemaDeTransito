using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SistemaDeTransitoMunicipal.vistas
{
    /// <summary>
    /// Lógica de interacción para VentanaChat.xaml
    /// </summary>
    public partial class VentanaChat : Window
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string msjServidor = "";
        public VentanaChat()
        {
            InitializeComponent();
            ConectarAlServidor();
            Console.WriteLine(MainWindow.nombreUsuario);
        }

        public void ConectarAlServidor()
        {
            try
            {
                Console.WriteLine("Conectando al servidor...");
                clientSocket.Connect("127.0.0.1", 1234);
                serverStream = clientSocket.GetStream();
                string nombreChat = MainWindow.nombreUsuario;
                byte[] outStream = Encoding.ASCII.GetBytes(nombreChat + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                Thread threadListen = new Thread(escucharMensajes);
                threadListen.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse con el servidor, inténtelo más tarde", ex.Message);
                Btn_Enviar.IsEnabled = false;
            }
        }

        private void escucharMensajes()
        {
            try
            {
                while (true)
                {
                    serverStream = clientSocket.GetStream();
                    byte[] inStream = new byte[65537];
                    serverStream.Read(inStream, 0, clientSocket.ReceiveBufferSize);

                    string returndata = Encoding.ASCII.GetString(inStream);
                    msjServidor += returndata + " ";

                    Console.WriteLine("Msj del servidor: " + returndata);

                    Tb_Contenido.Dispatcher.Invoke((ThreadStart)delegate
                    {
                        Tb_Contenido.Clear();
                        Tb_Contenido.Text = msjServidor;
                    });
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de conexión con el servidor");
               
            }

        }

        private void Btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipalMunicipal ventanaAdmin = new VentanaPrincipalMunicipal();
            ventanaAdmin.Show();
            this.Close();
        }

        private void Btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
            if (Tb_mensaje.Text.Length > 0)
            {
                    byte[] outStream = Encoding.ASCII.GetBytes(Tb_mensaje.Text + "$");
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
                    Tb_mensaje.Text = "";
                
            }
            else
            {
                MessageBox.Show("Debes escribir un mensaje para ser enviado por el chat...", "Mensaje obligatorios");
            }
        }
    }
}
