using Dominio;
using Servicios;
using Servicios.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpinteriaGera
{
    public partial class FrmConsulta : Form
    {
        private IServicio servicio;

        public FrmConsulta()
        {
            InitializeComponent();
            servicio = new ImplementacionAbstractFactory().CrearServicio();
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now.AddDays(7);    
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvPresupuestos.Rows.Clear();
            List<Presupuesto> presupuestos = servicio.ObternerPresupuestosFiltrados(dtpDesde.Value,dtpHasta.Value,txtCliente.Text);

            foreach (Presupuesto presupuesto in presupuestos)
            {
                dgvPresupuestos.Rows.Add(new object[] {presupuesto.PresupuestoNro,presupuesto.Fecha.ToString("dd/MM/yyyy"), presupuesto.Cliente});
            }
         
        }


        private void dgvPresupuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nro = int.Parse(dgvPresupuestos.CurrentRow.Cells["colNro"].Value.ToString());
            new FrmDetallePresupuesto(nro).ShowDialog();
        }


        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // De acá saco el nro de presupuesto que utilizo en todo el editar!
            int nroPresupuesto = int.Parse(dgvPresupuestos.CurrentRow.Cells["colNro"].Value.ToString());
            
            FrmAlta modificar = new FrmAlta(nroPresupuesto);

            modificar.ShowDialog();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("¿Seguro que desea quitar el presupuesto seleccionado?",
               "CONFIRMACIÓN", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if(dgvPresupuestos.CurrentRow != null)
                {
                    int nro = int.Parse(dgvPresupuestos.CurrentRow.Cells["colNro"].Value.ToString());
                    if (servicio.BorrarPresupuesto(nro))
                    {
                        MessageBox.Show("El presupuesto se quitó exitosamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.btnConsultar_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("El presupuesto NO se quitó exitosamente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir de esta ventana?",
               "CONFIRMACIÓN", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2) == DialogResult.OK) 

                Dispose();
        }

        
    }
}
