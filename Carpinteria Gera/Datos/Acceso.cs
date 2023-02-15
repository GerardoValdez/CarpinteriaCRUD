using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Datos
{
    public class Acceso
    {
        protected SqlConnection conexion = new SqlConnection(Properties.Resources.ConnectionString);
        protected SqlCommand comando = new SqlCommand();
        


        protected void Conectar()
        {
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
        }

        protected void Desconectar()
        {
            conexion.Close();
        }

    }
}
