using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PictureBooth
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

        public bool mensage()
        {
            this.ShowDialog();
            return true;
        }

        private void buttonCaptureImage_Click(object sender, RoutedEventArgs e)
        {
            capturedImage.Source = webcamCapture1.GrabImage();
        }
    }
}
