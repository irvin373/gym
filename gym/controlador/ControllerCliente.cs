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
        private ControllerCliente()
        {
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

        public void insertar(Cliente cliente)
        {
            SqlConnection connection = ConexionBD.Instance.Conexion;
            String query = "INSERT INTO cliente (ci,nombre,apellidoPaterno,apellidoMaterno,"+
                "domicilio,zona,email,telefonoCasa, telefonoOficina,fechaNacimiento)"+
                "VALUES(@ci,@nombre,@apellidoPaterno,@apellidoMaterno," +
                "@domicilio,@zona,@email,@telefonoCasa, @telefonoOficina,@fechaNacimiento)";
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

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
