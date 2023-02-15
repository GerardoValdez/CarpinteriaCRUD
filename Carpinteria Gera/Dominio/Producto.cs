using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        //propiedades:

        public int ProductoNro { get; set; }
        public string Nombre{ get; set; }
        public double Precio { get; set; }
        public bool Activo { get; set; }



        //constructor:

        public Producto(int productoNro, string nombreProducto, double precio)
        {
            ProductoNro = productoNro;
            Nombre = nombreProducto;
            Precio = precio;
            Activo = true;
        }



        //métodos:

        public override string ToString()
        {
            return Nombre; 
        }
    }
}
