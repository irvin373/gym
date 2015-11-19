using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym.modelo
{
    class Client
    {
        public int ci { get; set; }
        public String nombre { get; set; }
        public String apellidoPaterno { get; set; }
        public String apellidoMaterno { get; set; }
        public String domicilio { get; set; }
        public String zona { get; set; }
        public String email { get; set; }
        public String telefonoCasa { get; set; }
        public String telefonoOficina { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public String sexo { get; set; }
        public String codBiometrico { get; set; }
        public byte[] foto { get; set; }
        public Client() { }
    }
}
