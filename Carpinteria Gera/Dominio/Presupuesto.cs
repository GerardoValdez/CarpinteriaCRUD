using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Presupuesto
    {
        //propiedades:

        public int PresupuestoNro { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public double Total { get; set; }
        public double Descuento { get; set; }
        public DateTime FechaBaja { get; set; }

        public List<DetallePresupuesto> Detalles { get; set; }



        //constructor:

        public Presupuesto()
        {
          Detalles = new List<DetallePresupuesto>();    
        }



        //métodos:

        public void AgregarDetalle(DetallePresupuesto detalle)
        {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int indice)
        {
            Detalles.RemoveAt(indice);
        }

        public double CalcularTotal()
        {
            double total = 0;  

            foreach (DetallePresupuesto detalle in Detalles)
            {
                total += detalle.CalcularSubTotal();
            }

            return total;
        }


        public double CalcularTotalConDescuento()
        {
            double final = this.CalcularTotal();

            if (Descuento > 0)
                final -= final * Descuento / 100;

            return final;
        }

    }
}
