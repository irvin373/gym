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

namespace gym.vista
{
    /// <summary>
    /// Interaction logic for Biometrico.xaml
    /// </summary>
    public partial class Biometrico : Window
    {
        public Biometrico()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            label.Content = DateTime.Now.GetHashCode().ToString();
        }

        public String getBiometrica()
        {
            this.ShowDialog();
            return label.Content.ToString();
        }
    }
}
