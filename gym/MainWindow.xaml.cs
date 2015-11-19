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
using System.Windows.Navigation;
using System.Windows.Shapes;
using gym.vista;
using gym.vista.Cliente;
using gym.vista.Clientes;

namespace gym
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            RegistroCliente clie = new RegistroCliente();
            clie.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Buscar busqueda = new Buscar();
            busqueda.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            EliminarCliente eliminar = new EliminarCliente();
            eliminar.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            imagePixel image = new imagePixel();
            image.ShowDialog();
        }
    }
}
