using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym.controlador
{
    class ConexionBD
    {
        private SqlConnection connection = 
            new SqlConnection(@"Data Source=irvin-laptop;Initial Catalog=gymBD;Integrated Security=True");
        private static ConexionBD instancia = null;

        public ConexionBD()
        { }

        public static ConexionBD Instance
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ConexionBD();
                }
                return instancia;
            }
        }

        public SqlConnection Conexion
        {
            get
            {
                return connection;
            }
        }
    }
}
