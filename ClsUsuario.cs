using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizza
{
    internal class ClsUsuario
    {
        private string correo;
        private string nombre;
        private string clave;

        public string Correo { get => correo; set => correo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Clave { get => clave; set => clave = value; }
    }
}
