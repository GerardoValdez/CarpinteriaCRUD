using Datos.Implementacion;
using Datos.Interface;
using Dominio;
using Servicios.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Implementacion
{
    public class CarpinteriaServicio : IServicio
    {
        private ICarpinteriaDao DAO;

        public CarpinteriaServicio()
        {
            DAO = new CarpinteriaDao();
        }



        public DataTable ConsultarProductos()
        {
            return DAO.GetProductos();
        }

      

        public int ProximoPresupuesto()
        {
            return DAO.NextPresupuesto();
        }



        public bool CrearPresupuesto(Presupuesto presupuesto)
        {
            return DAO.CreatePresupuesto(presupuesto);

        }



        public List<Presupuesto> ObternerPresupuestosFiltrados(DateTime desde, DateTime hasta, string cliente)
        {
            return DAO.GetPresupuestoFiltrados(desde, hasta, cliente);
        }

        public Presupuesto ObtenerPresupuestoPorNro(int nro, Presupuesto presupuesto)
        {
            return DAO.GetPresupuestoPorNro(nro, presupuesto);
        }

        public bool ModificarPresupuesto(Presupuesto presupuesto)
        {
            return DAO.UpdatePresupuesto(presupuesto);
        }




        public bool BorrarPresupuesto(int nro)
        {
            return DAO.DeletePresupeusto(nro);
        }




        public DataTable ObtenerReporteProductos(DateTime desde, DateTime hasta)
        {
            return DAO.GetReportProduct(desde,hasta);
        }
    }
}
