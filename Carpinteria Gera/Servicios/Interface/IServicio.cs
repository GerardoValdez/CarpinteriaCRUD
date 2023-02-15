using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interface
{
    //public y abstract
    public interface IServicio
    {
        DataTable ConsultarProductos();
        int ProximoPresupuesto();
        bool CrearPresupuesto(Presupuesto presupuesto);

        List<Presupuesto> ObternerPresupuestosFiltrados(DateTime desde, DateTime hasta, string cliente);
        Presupuesto ObtenerPresupuestoPorNro(int nro, Presupuesto presupuesto);
        bool ModificarPresupuesto(Presupuesto presupuesto);
        
        bool BorrarPresupuesto(int nro);

        DataTable ObtenerReporteProductos(DateTime desde, DateTime hasta);


    }
}
