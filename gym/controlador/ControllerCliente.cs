using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gym.modelo;
using System.Data.SqlClient;
using System.Windows;

namespace gym.controlador
{
    class ControllerCliente
    {
        public static ControllerCliente instancia = null;
        SqlConnection connection = ConexionBD.Instance.Conexion;

        private ControllerCliente()
        {
        }

        public bool EliminarCliente(String Id)
        {
            bool resp = false;
            try
            {
                connection.Open();
                String sql = "delete from cliente where ci ='" + Id+"'";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteReader();
                connection.Close();
                resp = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                resp = false;
            }
            return resp;
        }

        public Client buscarCliente(String id)
        {
            SqlCommand command;
            SqlDataReader dataReader;
            Client cliente = new Client();
            string sql = "select * from cliente where ci = '" + id + "'";
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    cliente.ci = dataReader.GetInt32(0);
                    cliente.nombre = dataReader.GetString(1);
                    cliente.apellidoPaterno = dataReader.GetString(2);
                    cliente.apellidoMaterno = dataReader.GetString(3);
                    cliente.domicilio = dataReader.GetString(4);
                    cliente.zona = dataReader.GetString(5);
                    cliente.email = dataReader.GetString(6);
                    cliente.telefonoCasa = dataReader.GetString(7);
                    cliente.telefonoOficina = dataReader.GetString(8);
                    cliente.fechaNacimiento = dataReader.GetDateTime(9);
                    cliente.sexo = dataReader.GetString(10);
                    cliente.codBiometrico = dataReader.GetString(11);
                    cliente.foto = (byte[])dataReader.GetValue(12);
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                cliente = null;
            }
            return cliente;
        }

        public static ControllerCliente Instance
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControllerCliente();
                }
                return instancia;
            }
        }

        public void insertar(Client cliente)
        {
            String query = "INSERT INTO cliente (ci,nombre,apellidoPaterno,apellidoMaterno,domicilio,zona,email,telefonoCasa,telefonoOficina,fechaNacimiento,sexo,codigoBiometrico,foto)"+
                "VALUES(@ci,@nombre,@apellidoPaterno,@apellidoMaterno,@domicilio,@zona,@email,@telefonoCasa,@telefonoOficina,@fechaNacimiento,@sexo,@codigoBiometrico,@foto)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ci", cliente.ci);
            command.Parameters.AddWithValue("@nombre", cliente.nombre);
            command.Parameters.AddWithValue("@apellidoPaterno", cliente.apellidoPaterno);
            command.Parameters.AddWithValue("@apellidoMaterno", cliente.apellidoMaterno);
            command.Parameters.AddWithValue("@domicilio", cliente.domicilio);
            command.Parameters.AddWithValue("@zona", cliente.zona);
            command.Parameters.AddWithValue("@email", cliente.email);
            command.Parameters.AddWithValue("@telefonoCasa", cliente.telefonoCasa);
            command.Parameters.AddWithValue("@telefonoOficina", cliente.telefonoOficina);
            command.Parameters.AddWithValue("@fechaNacimiento", cliente.fechaNacimiento);
            command.Parameters.AddWithValue("@sexo", cliente.sexo);
            command.Parameters.AddWithValue("@codigoBiometrico", cliente.codBiometrico);
            command.Parameters.AddWithValue("@foto", cliente.foto);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
