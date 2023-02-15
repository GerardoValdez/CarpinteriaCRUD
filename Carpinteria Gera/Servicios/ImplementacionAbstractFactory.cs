using Datos.Implementacion;
using Servicios.Implementacion;
using Servicios.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ImplementacionAbstractFactory : AbstractFactory
    {
        public override IServicio CrearServicio()
        {
            return new CarpinteriaServicio();
        }
    }
}
