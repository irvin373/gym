using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace combertirImagen
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

        Uri url;
        
        private void button_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (dlg.ShowDialog().Value)
            {
                url = new Uri(dlg.FileName);
                image.Source = new BitmapImage(new Uri(dlg.FileName));
            }
            FileStream fs;
            fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);

        }

        public static Color GetPixelColor(BitmapSource source, int x, int y)
        {
            Color c = Colors.White;
            if (source != null)
            {
                try
                {
                    CroppedBitmap cb = new CroppedBitmap(source, new Int32Rect(x, y, 1, 1));
                    var pixels = new byte[4];
                    cb.CopyPixels(pixels, 4, 0);
                    c = Color.FromRgb(pixels[2], pixels[1], pixels[0]);
                }
                catch (Exception) { }
            }
            return c;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            String cadena = "";
            int value;
            Color c;
            List<int> matrix = new List<int>();
            var source = new BitmapImage(url);
            for (int i = 0; i < source.PixelHeight; i++)
            {
                for (int j = 0; j < source.PixelWidth; j++)
                {

                    c = GetPixelColor(source, i, j);
                    if (c.ToString() == "#FFFFFFFF")
                    {
                        value = 0;
                    }
                    else
                    {
                        value = 1;
                    }
                    matrix.Add(value);
                    cadena += value.ToString();
                }
                cadena += "\n";

            }
            textBox.Text = cadena;
        }
    }
}
