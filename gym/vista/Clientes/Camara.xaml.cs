using System;
using System.Collections.Generic;
using System.IO;
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

namespace gym.vista.Clientes
{
    /// <summary>
    /// Interaction logic for Camara.xaml
    /// </summary>
    public partial class Camara : Window
    {
        public Camara()
        {
            InitializeComponent();
        }

        private void buttonStopCapture_Click(object sender, RoutedEventArgs e)
        {
            webcamCapture1.StopCapture();
        }

        private void buttonStartCapture_Click(object sender, RoutedEventArgs e)
        {
            webcamCapture1.StartCapture();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        public byte[] mensage()
        {
            this.ShowDialog();
            return webcamCapture1.getpic();
        }

        private void buttonCaptureImage_Click(object sender, RoutedEventArgs e)
        {
            capturedImage.Source = webcamCapture1.GrabImage();
            //this.Close();
        }
    }
}
