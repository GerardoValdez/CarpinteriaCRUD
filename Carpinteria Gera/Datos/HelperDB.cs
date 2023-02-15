using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class HelperDB : Acceso
    {
        // singleton: 

        private static HelperDB instancia;

        //métodos:

        public static HelperDB ObternerInstancia()
        {
            if (instancia == null)
                instancia = new HelperDB();

            return instancia;
            
        }





        public DataTable ConsultarProductos()
        {
            DataTable tabla = new DataTable();

            try
            {
                Conectar();
                comando.Parameters.Clear();
                comando.CommandText = "SP_CONSULTAR_PRODUCTOS";
                tabla.Load(comando.ExecuteReader());
                
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
                Desconectar();
            }
           

            return tabla;
        }




        public int NextPresupuesto()
        {
            int proximoId;

            try
            {
                Conectar();
                comando.Parameters.Clear();
                comando.CommandText = "SP_PROXIMO_ID";

                SqlParameter nextId = new SqlParameter("@next", SqlDbType.Int);
                nextId.Direction = ParameterDirection.Output;
                comando.Parameters.Add(nextId);
                comando.ExecuteNonQuery();

                proximoId = (int)nextId.Value;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Desconectar();
            }
           
            return proximoId;
        }




        public bool CreatePresupuesto(Presupuesto presupuesto)
        {
            bool ok = true;
            SqlTransaction t = null;

            try
            {
                Conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;

                comando.CommandText = "SP_INSERTAR_MAESTRO";

                comando.Parameters.AddWithValue("@cliente", presupuesto.Cliente);
                comando.Parameters.AddWithValue("@dto", presupuesto.Descuento);
                comando.Parameters.AddWithValue("@total", presupuesto.CalcularTotalConDescuento());
                
                SqlParameter output = new SqlParameter("@presupuesto_nro", DbType.Int32);
                output.Direction = ParameterDirection.Output;
                comando.Parameters.Add(output);

                comando.ExecuteNonQuery();

                int nro = (int)output.Value;

                int nroDetalle = 1;
                foreach (DetallePresupuesto detalle in presupuesto.Detalles)
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SP_INSERTAR_DETALLE";
                    
                    comando.Parameters.AddWithValue("@presupuesto_nro", nro);
                    comando.Parameters.AddWithValue("@detalle", nroDetalle);
                    comando.Parameters.AddWithValue("@id_producto", detalle.Producto.ProductoNro);
                    comando.Parameters.AddWithValue("@cantidad", detalle.Cantidad);

                    comando.ExecuteNonQuery();


                    nroDetalle ++;
                }

                t.Commit();

            }
            catch (Exception)
            {
                t.Rollback();
                ok = false;

            }
            finally
            {
                Desconectar();
            }


            return ok;
        }


        // metodos para la ventana de consultar 
        public List<Presupuesto> ObtenerPresupuestosFiltrados(DateTime desde, DateTime hasta, string cliente)
        {
            List<Presupuesto> presupuestos = new List<Presupuesto>();    
            DataTable tabla = new DataTable();

            try
            {
                Conectar();
                comando.Parameters.Clear();
                comando.CommandText = "SP_CONSULTAR_PRESUPUESTOS";

                comando.Parameters.AddWithValue("@fecha_desde",desde);
                comando.Parameters.AddWithValue("@fecha_hasta",hasta);
                comando.Parameters.AddWithValue("@cliente",cliente);

                tabla.Load(comando.ExecuteReader());

                foreach (DataRow row in tabla.Rows)
                {
                    Presupuesto presupuesto = new Presupuesto();
                    presupuesto.PresupuestoNro = int.Parse(row["presupuesto_nro"].ToString());
                    presupuesto.Fecha = DateTime.Parse(row["fecha"].ToString());
                    presupuesto.Cliente = row["cliente"].ToString();
                    presupuesto.Descuento = double.Parse(row["descuento"].ToString());
                    presupuesto.Total = double.Parse(row["total"].ToString());

                    presupuestos.Add(presupuesto);
                }
                 

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Desconectar();
            }


            return presupuestos;
        }
       



        // para editar utilizo 2 métodos, 1ro traigo el presupuesto y luego lo modifico:
        public Presupuesto ObtenerPresupuestoPorNro(int nro, Presupuesto presupuesto)
        {
            DataTable tabla = new DataTable();           

            try
            {
                Conectar();
                comando.Parameters.Clear();
                comando.CommandText = "SP_CONSULTAR_DETALLES_PRESUPUESTO"; 

                comando.Parameters.AddWithValue("@presupuesto_nro",nro);

                tabla.Load(comando.ExecuteReader());

                bool primerDetalle = true; // saco del 1er detalle los datos del presupuesto

                foreach ( DataRow row in tabla.Rows)
                {
                    //saco los datos del presupuesto del join con el 1er detalle
                    if (primerDetalle)
                    {
                        presupuesto.Fecha = DateTime.Parse(row["fecha"].ToString());
                        presupuesto.Cliente = row["cliente"].ToString();
                        presupuesto.Descuento = double.Parse(row["descuento"].ToString());
                     
                        primerDetalle = false;
                    }

                    int idProducto = int.Parse(row["id_producto"].ToString());
                    string nombreProducto = row["n_producto"].ToString();
                    double precio = double.Parse(row["precio"].ToString());
                    Producto producto = new Producto(idProducto,nombreProducto,precio);
               
                    int cantidad = int.Parse(row["cantidad"].ToString());
                    DetallePresupuesto detalle = new DetallePresupuesto(producto, cantidad);

                    presupuesto.AgregarDetalle(detalle);

                }
               

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Desconectar();
            }



            return presupuesto;
        }

        public bool ModificarPresupuesto(Presupuesto presupuesto)
        {
            bool ok = true;
            SqlTransaction t = null;    

            try
            {
                Conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;

                comando.CommandText = "SP_MODIFICAR_MAESTRO";

                //lo que se puede modificar
                comando.Parameters.AddWithValue("@cliente", presupuesto.Cliente);
                comando.Parameters.AddWithValue("@dto", presupuesto.Descuento);
                comando.Parameters.AddWithValue("@total", presupuesto.CalcularTotalConDescuento());
                // where presupuesto_nro = presupuesto.PresupuestoNro
                comando.Parameters.AddWithValue("@presupuesto_nro",presupuesto.PresupuestoNro);

                comando.ExecuteNonQuery();

                int detalleNro = 1;

                foreach (DetallePresupuesto detalle in presupuesto.Detalles)
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SP_INSERTAR_DETALLE";
                    comando.Parameters.AddWithValue("@presupuesto_nro", presupuesto.PresupuestoNro);
                    comando.Parameters.AddWithValue("@detalle", detalleNro);
                    comando.Parameters.AddWithValue("@id_producto", detalle.Producto.ProductoNro);
                    comando.Parameters.AddWithValue("@cantidad", detalle.Cantidad);

                    comando.ExecuteNonQuery();

                    detalleNro++;
                }

                t.Commit();



            }
            catch (Exception)
            {
                t.Rollback();
                ok = false;
            }
            finally
            {
                Desconectar();
            }


            return ok;

        }






        public bool EliminarPresupuesto(int nro)
        {
            bool ok = true;
            SqlTransaction t = null;

            try
            {
                Conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "SP_ELIMINAR_PRESUPUESTO";
                comando.Parameters.AddWithValue("@presupuesto_nro",nro);

                comando.ExecuteNonQuery();
                t.Commit();

            }
            catch (Exception)
            {

                t.Rollback();
                ok = false;

            }
            finally
            {
                Desconectar();
            }

            return ok;
        }




        public DataTable ObtenerReporteProducto(DateTime desde, DateTime hasta)
        {
            DataTable dt = new DataTable();

            try
            {
                Conectar();
                comando.Parameters.Clear();
                comando.CommandText = "SP_REPORTE_PRODUCTOS";
                comando.Parameters.AddWithValue("@fecha_desde", desde);
                comando.Parameters.AddWithValue("@fecha_hasta", hasta);
                dt.Load(comando.ExecuteReader());

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Desconectar(); 
            }

            return dt;
        }
    }
}
