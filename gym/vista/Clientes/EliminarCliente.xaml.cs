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
using gym.controlador;
using gym.modelo;
using System.Text.RegularExpressions;

namespace gym.vista.Clientes
{
    /// <summary>
    /// Interaction logic for EliminarCliente.xaml
    /// </summary>
    public partial class EliminarCliente : Window
    {
        public EliminarCliente()
        {
            InitializeComponent();
        }

        private void EliminarBtn_Click(object sender, RoutedEventArgs e)
        {
            bool condicion = ControllerCliente.Instance.EliminarCliente(busquedaBox.Text);
            MessageBox.Show(busquedaBox.Text);
            if (condicion)
            {
                MessageBox.Show("Borrado exitosamente!!!"); 
            }
            else
            {
                MessageBox.Show("Error verifique el carnet este bien escritro");
            }
        }

        private void busquedaBtn_Click(object sender, RoutedEventArgs e)
        {
            Client cliente = ControllerCliente.Instance.buscarCliente(busquedaBox.Text);
            if (cliente == null)
            {
                MessageBox.Show("No existe con ese carnet");
            }
            else
            {
                ciBox.Text = cliente.ci.ToString();
                nombreBox.Text = cliente.nombre;
                PaternoBox.Text = cliente.apellidoPaterno;
                MaternoBox.Text = cliente.apellidoMaterno;
                DomicilioBox.Text = cliente.domicilio;
                ZonaBox.Text = cliente.zona;
                emailBox.Text = cliente.email;
                telefonoCasaBox.Text = cliente.telefonoCasa;
                telefonoOficinaBox.Text = cliente.telefonoOficina;
                feCNacimientoBox.Text = cliente.fechaNacimiento.ToString();
                sexoBox.Text = cliente.sexo;
                BiometricoBox.Text = cliente.codBiometrico;

                System.IO.MemoryStream stream = new System.IO.MemoryStream(cliente.foto);
                BitmapImage foto = new BitmapImage();
                foto.BeginInit();
                foto.StreamSource = stream;
                foto.CacheOption = BitmapCacheOption.OnLoad;
                foto.EndInit();
                image.Source = foto;
            }
        }

        private void busquedaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            busquedaBox.Text = RegexInstance.Instance.regexNumber(busquedaBox.Text);
        }
    }
}
