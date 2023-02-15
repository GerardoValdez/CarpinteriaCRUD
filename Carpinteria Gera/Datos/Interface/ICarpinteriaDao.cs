using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interface
{
    //public y abstract
    public interface ICarpinteriaDao
    {
        DataTable GetProductos();
        int NextPresupuesto();
        bool CreatePresupuesto(Presupuesto presupuesto);


        List<Presupuesto> GetPresupuestoFiltrados(DateTime desde, DateTime hasta, string cliente);
        Presupuesto GetPresupuestoPorNro(int nro, Presupuesto presupuesto);
        bool UpdatePresupuesto(Presupuesto presupuesto);

        bool DeletePresupeusto(int nro);

        DataTable GetReportProduct(DateTime desde, DateTime hasta);
    }
}
