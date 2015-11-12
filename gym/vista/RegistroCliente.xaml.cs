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
using gym.modelo;
using gym.controlador;

namespace gym.vista
{
    /// <summary>
    /// Interaction logic for RegistroCliente.xaml
    /// </summary>
    public partial class RegistroCliente : Window
    {
        public RegistroCliente()
        {
            InitializeComponent();
            //sexoBox.Background = Brushes.LightBlue;
            ComboBoxItem cboxitem = new ComboBoxItem();
            cboxitem.Content = "Masculino";
            sexoBox.Items.Add(cboxitem);
            cboxitem = new ComboBoxItem();
            cboxitem.Content = "Femenino";
            sexoBox.Items.Add(cboxitem);
        }

        private void GuardarBtn_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.ci = int.Parse(ciBox.Text);
            cliente.nombre = nombreBox.Text;
            cliente.apellidoPaterno = PaternoBox.Text;
            cliente.apellidoMaterno = MaternoBox.Text;
            cliente.domicilio = DomicilioBox.Text;
            cliente.zona = ZonaBox.Text;
            cliente.email = emailBox.Text;
            cliente.telefonoCasa = telefonoCasaBox.Text;
            cliente.telefonoOficina = telefonoOficinaBox.Text;
            cliente.fechaNacimiento = feCNacimientoBox.DisplayDate;

            try
            {
                ControllerCliente.Instance.insertar(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
