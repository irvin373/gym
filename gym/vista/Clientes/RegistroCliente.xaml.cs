﻿using System;
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
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;

namespace gym.vista
{
    /// <summary>
    /// Interaction logic for RegistroCliente.xaml
    /// </summary>
    public partial class RegistroCliente : Window
    {
        String codigoBio = String.Empty;
        byte[] picbyte;
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
            MemoryStream stream = new MemoryStream();            
            Client cliente = new Client();
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
            cliente.sexo = sexoBox.Text;
            cliente.codBiometrico = codigoBio;
            cliente.foto = picbyte;
            try
            {
                ControllerCliente.Instance.insertar(cliente);
                MessageBox.Show("guardado exitosamente!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Biometrico biometrico = new Biometrico();
            codigoBio = biometrico.getBiometrica();
            MessageBox.Show(codigoBio);
        }

        private void cargarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (dlg.ShowDialog().Value)
            {
                image.Source = new BitmapImage(new Uri(dlg.FileName));
            }
            FileStream fs;
            fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
            picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
        }

        internal String ReplexNum(String format)
        {
            Match m;// = Regex.Match(format, @"[\d]+", RegexOptions.IgnoreCase);
            foreach (var item in format)
            {
                m = Regex.Match(item.ToString(), @"[\d]+", RegexOptions.IgnoreCase);
                if (!m.Success)
                {
                    format = format.Replace(item.ToString(), String.Empty);
                }
            }
            return format;
        }

        private void ciBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ciBox.Text = ReplexNum(ciBox.Text);
        }

        private void telefonoCasaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            telefonoCasaBox.Text = ReplexNum(telefonoCasaBox.Text);
        }

        private void telefonoOficinaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            telefonoOficinaBox.Text = ReplexNum(telefonoOficinaBox.Text);
        }
    }
}
