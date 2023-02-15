using Datos.Interface;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Implementacion
{
    public class CarpinteriaDao : ICarpinteriaDao
    {
        public bool CreatePresupuesto(Presupuesto presupuesto)
        {
            return HelperDB.ObternerInstancia().CreatePresupuesto(presupuesto);
        }

        public DataTable GetProductos()
        {
           return HelperDB.ObternerInstancia().ConsultarProductos();
        }

        public int NextPresupuesto()
        {
            return HelperDB.ObternerInstancia().NextPresupuesto();
        }





        public List<Presupuesto> GetPresupuestoFiltrados(DateTime desde, DateTime hasta, string cliente)
        {
            return HelperDB.ObternerInstancia().ObtenerPresupuestosFiltrados(desde, hasta, cliente);
        }

        public Presupuesto GetPresupuestoPorNro(int nro, Presupuesto presupuesto)
        {
            return HelperDB.ObternerInstancia().ObtenerPresupuestoPorNro(nro, presupuesto);
        }

        public bool UpdatePresupuesto(Presupuesto presupuesto)
        {
            return HelperDB.ObternerInstancia().ModificarPresupuesto(presupuesto);
        }




        public bool DeletePresupeusto(int nro)
        {
            return HelperDB.ObternerInstancia().EliminarPresupuesto(nro);
        }




        public DataTable GetReportProduct(DateTime desde, DateTime hasta)
        {
            return HelperDB.ObternerInstancia().ObtenerReporteProducto(desde, hasta);
        }
    }
}
