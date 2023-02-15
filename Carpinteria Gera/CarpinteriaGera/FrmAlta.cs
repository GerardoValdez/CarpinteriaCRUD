using Dominio;
using Servicios;
using Servicios.Implementacion;
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
    public partial class FrmAlta : Form
    {
        private Presupuesto presupuesto;
        private IServicio servicio;
        // variable para disparar un form de Alta o Editar y utilizada en los metodos
        private int nroPresupuesto = 0;



        public FrmAlta()
        {
            InitializeComponent();

            servicio = new ImplementacionAbstractFactory().CrearServicio();
            presupuesto = new Presupuesto();

        }


        // form MODIFICAR
        public FrmAlta(int numeroPresupuesto)
        {
            InitializeComponent();
            servicio = new ImplementacionAbstractFactory().CrearServicio();
            //Guardamos en el atributo en nro de presupuesto
            presupuesto = new Presupuesto();

            nroPresupuesto = numeroPresupuesto;

            
            //le doy el presupuestoNro a mi new Presupuesto
            presupuesto.PresupuestoNro = nroPresupuesto;

            
        }



        private void FrmAlta_Load(object sender, EventArgs e)
        {
            if (nroPresupuesto != 0)           
                InicializarEditarPresupuesto(nroPresupuesto, presupuesto);
            
            else           
                InicializarPresupuestoNuevo();

                
            CargarCombo();

        }

       
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarAgregar() && EstaEnGrilla())
            {
                //convierto el item del combo en una fila:

                DataRowView item = (DataRowView)cboProductos.SelectedItem;
                int productoNro = Convert.ToInt32(item.Row.ItemArray[0]);
                string nombre = Convert.ToString(item.Row.ItemArray[1]);
                double precio = Convert.ToDouble(item.Row.ItemArray[2]);

                int cantidad = Convert.ToInt32(txtCantidad.Text);

                Producto producto = new Producto(productoNro,nombre,precio);

                DetallePresupuesto detalle = new DetallePresupuesto(producto, cantidad);

                presupuesto.AgregarDetalle(detalle);

                dgvDetalles.Rows.Add(new object[] { productoNro, nombre, precio, cantidad });

                Calcular();

            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            //paso cliente, descuento y total al objeto
            presupuesto.Cliente = txtCliente.Text;
            presupuesto.Descuento = Convert.ToDouble(txtDto.Text);

            if (ValidarAceptar())
            {
                if (nroPresupuesto != 0)
                {

                    if (servicio.ModificarPresupuesto(presupuesto))
                    {
                        MessageBox.Show("Presupuesto modificado", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }

                    else
                        MessageBox.Show("ERROR. No se pudo modificar el presupuesto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    if (servicio.CrearPresupuesto(presupuesto))
                    {
                        MessageBox.Show("Registro exitoso", "REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                    else
                        MessageBox.Show("No registrado", "REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }






        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4)
            {
                presupuesto.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);

                Calcular();
            }
        }



        private void CargarCombo()
        {
            DataTable tabla = servicio.ConsultarProductos();
            cboProductos.DataSource = tabla;
            cboProductos.DisplayMember = "n_producto";
            cboProductos.ValueMember = "id_producto";
            cboProductos.SelectedIndex = -1;
        }

        private void InicializarPresupuestoNuevo()
        {
            //condicion para verificar si es un nuevo presupuesto o estoy por editar
            if (nroPresupuesto == 0)
            {
                txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
                txtCliente.Text = "CONSUMIDOR FINAL";
                txtDto.Text = "0";
                txtCantidad.Text = "1";
                lblNroPresupuesto.Text += servicio.ProximoPresupuesto();
            }

        }

        private void InicializarEditarPresupuesto(int numeroPresupuesto, Presupuesto presupuesto)
        {
            //Cambiamos el título de la ventana
            Text = "Editar Presupuesto";
            //Traemos el Nro de Presupuesto a modificar
            lblNroPresupuesto.Text += numeroPresupuesto.ToString();

            //guardo el presupuesto traido de la base segun el nro de presupuesto
            presupuesto = servicio.ObtenerPresupuestoPorNro(numeroPresupuesto, presupuesto);

            txtFecha.Text = presupuesto.Fecha.ToString("dd/MM/yyyy");
            txtCliente.Text = presupuesto.Cliente.ToString();
            txtDto.Text = presupuesto.Descuento.ToString();
            txtCantidad.Text = "1";

            foreach (DetallePresupuesto detalle in presupuesto.Detalles)
            {
                dgvDetalles.Rows.Add(new object[] { detalle.Producto.ProductoNro, detalle.Producto.Nombre,
                                                    detalle.Producto.Precio, detalle.Cantidad });

            }

            Calcular();

        }



        private bool EstaEnGrilla()
        {
            bool ok = true;

            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["colProd"].Value.ToString().Equals(cboProductos.Text))
                {
                    MessageBox.Show("El producto ya fue cargado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ok = false;
                } 
            }

            return ok;

        }

        private bool ValidarAgregar()
        {
            bool ok = true;

            if (cboProductos.Text == String.Empty)
            {
                MessageBox.Show("Debe seleccionar un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ok = false;
            }

            if (txtCantidad.Text == String.Empty || !int.TryParse(txtCantidad.Text, out _))
            {
                MessageBox.Show("Ingresar cantidad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ok = false;
            }

            if (txtDto.Text == String.Empty || !int.TryParse(txtCantidad.Text, out _))
            {
                MessageBox.Show("Ingrese un valor númerico en el campo descuento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ok = false;
            }



            return ok;
        }

        private bool ValidarAceptar()
        {
            bool ok = true;

            if (txtCliente.Text == String.Empty)
            {
                MessageBox.Show("Debe ingresar un cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ok = false;
            }

            return ok;
        }


        private void Calcular()
        {
            txtTotal.Text = presupuesto.CalcularTotal().ToString();

            double descuento = (presupuesto.CalcularTotal() * Convert.ToDouble(txtDto.Text)) / 100;
            txtFinal.Text = (presupuesto.CalcularTotal() - descuento).ToString();

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult mensaje = MessageBox.Show("Está seguro que desea cancelar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (mensaje == DialogResult.OK)
                Close();
            else
                return;
        }
    }
}
