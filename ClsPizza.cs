using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizza
{
    internal class ClsPizza
    {
        private string cliente ;
        private string descripcion ;
        private int size;
        private double precio;
        private int cantidad;
        private int id;

        public ClsPizza()
        {
            Cliente = "Anonimo";
            Descripcion = "Normal";
        }
            


        public string Cliente { get => cliente; set => cliente = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Size { get => size; set => size = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Id { get => id; set => id = value; }

        
    }
}
