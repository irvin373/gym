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
using gym.vista.Clientes;
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
        byte[] picbyte = null;
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
        
        internal String verificarEntradas(Client cliente)
        {
            String resp = String.Empty;
            resp = cliente.verificar();
            if (picbyte == null)
            {
                resp = "la imagen aun no se ha seleccionado";
            }
            if (feCNacimientoBox.Text == String.Empty)
            {
                resp = "fecha aun no ingresada";
            }
            if (!RegexInstance.Instance.regexMail(emailBox.Text))
            {
                resp = "correo no valido";
            }
            return resp;
        }

        internal Client llenarObjeto()
        {
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
            return cliente;
        }

        private void GuardarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ciBox.Text == String.Empty)
                {
                    MessageBox.Show("Ci sin ingresar");
                }
                else
                {
                    var cliente = llenarObjeto();
                    String mensajeError = verificarEntradas(cliente);
                    if (mensajeError != String.Empty)
                    {
                        MessageBox.Show(mensajeError);
                    }
                    else
                    {
                        ControllerCliente.Instance.insertar(cliente);
                        MessageBox.Show("guardado exitosamente!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
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

        private void ciBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ciBox.Text = RegexInstance.Instance.regexNumber(ciBox.Text);
        }

        private void telefonoCasaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            telefonoCasaBox.Text = RegexInstance.Instance.regexNumber(telefonoCasaBox.Text);
        }

        private void telefonoOficinaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            telefonoOficinaBox.Text = RegexInstance.Instance.regexNumber(telefonoOficinaBox.Text);
        }

        private void camaraBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Camara camara = new Camara();
                picbyte = camara.mensage();

                System.IO.MemoryStream stream = new System.IO.MemoryStream(picbyte);
                BitmapImage foto = new BitmapImage();
                foto.BeginInit();
                foto.StreamSource = stream;
                foto.CacheOption = BitmapCacheOption.OnLoad;
                foto.EndInit();
                image.Source = foto;
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }

        }

        private void nombreBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            nombreBox.Text = RegexInstance.Instance.regexText(nombreBox.Text);
        }

        private void PaternoBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PaternoBox.Text = RegexInstance.Instance.regexText(PaternoBox.Text);
        }

        private void MaternoBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MaternoBox.Text = RegexInstance.Instance.regexText(MaternoBox.Text);
        }

        private void emailBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
