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

        public String verificar()
        {
            String resp = String.Empty;
            if (nombre == String.Empty)
            {
                resp = "nombre vacio";
            }
            if (apellidoPaterno == String.Empty)
            {
                resp = "apellido paterno vacio";
            }
            if (apellidoMaterno == String.Empty)
            {
                resp = "apellido materno vacio";
            }
            if (zona == String.Empty)
            {
                resp = "zona vacio";
            }
            if (domicilio == String.Empty)
            {
                resp = "domicilio vacio";
            }
            if (email == String.Empty)
            {
                resp = "email vacio";
            }
            if (telefonoCasa == String.Empty)
            {
                resp = "telefono casa vacio";
            }
            if (telefonoOficina == String.Empty)
            {
                resp = "telefono oficina vacio";
            }
            if (sexo== String.Empty)
            {
                resp = "sexo vacio";
            }
            if (codBiometrico == String.Empty)
            {
                codBiometrico = "nombre vacio";
            }
            return resp;
        }
    }
}
