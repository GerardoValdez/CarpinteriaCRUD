using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetallePresupuesto
    {
        //propiedades:

        public Producto Producto { get; set; }
        public int Cantidad { get; set; }



        //constructor:

        public DetallePresupuesto(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;    
        }



        //métodos:

        public double CalcularSubTotal()
        {
            return Producto.Precio * Cantidad;
        }
    }
}
