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

        void SaveToPng(FrameworkElement visual, string fileName)
        {
            var encoder = new PngBitmapEncoder();
            SaveUsingEncoder(visual, fileName, encoder);
        }

        // and so on for other encoders (if you want)


        void SaveUsingEncoder(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        {
            RenderTargetBitmap bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(visual);
            BitmapFrame frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);

            using (var stream = File.Create(fileName))
            {
                encoder.Save(stream);
            }
        }

        public byte[] mensage()
        {
            this.ShowDialog();
            return webcamCapture1.getpic();
        }

        private void buttonCaptureImage_Click(object sender, RoutedEventArgs e)
        {
            capturedImage.Source = webcamCapture1.GrabImage();
        }
    }
}
