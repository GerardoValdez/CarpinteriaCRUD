using Dominio;
using Servicios;
using Servicios.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpinteriaGera
{
    public partial class FrmDetallePresupuesto : Form
    {
        private IServicio servicio;
        private int nroPresupuesto;
        Presupuesto presupuesto;

     
        public FrmDetallePresupuesto(int nro)
        {
            InitializeComponent();
            servicio = new ImplementacionAbstractFactory().CrearServicio();
            presupuesto = new Presupuesto();
            nroPresupuesto = nro;
            presupuesto.PresupuestoNro = nroPresupuesto;
           
           

        }

        private void FrmDetallePresupuesto_Load(object sender, EventArgs e)
        {
           

            inicializarDetalle(nroPresupuesto, presupuesto);

        }

        private void inicializarDetalle(int nroPresupuesto, Presupuesto presupuesto)
        {
            // datos Presupuesto:
            this.Text += nroPresupuesto.ToString();
            presupuesto = servicio.ObtenerPresupuestoPorNro(nroPresupuesto,presupuesto);
            txtFecha.Text = presupuesto.Fecha.ToString("dd/MM/yyyy");
            txtCliente.Text = presupuesto.Cliente;
            txtDto.Text = presupuesto.Descuento.ToString();
            txtTotal.Text = presupuesto.Total.ToString();


            // datos detalles:
            foreach (DetallePresupuesto detalle in presupuesto.Detalles)
            {
                dgvDetalles.Rows.Add(new object[] {detalle.Producto.Nombre, detalle.Producto.Precio , detalle.Cantidad });
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();  
        }
    }
}
