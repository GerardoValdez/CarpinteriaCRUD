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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void nuevoPresupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAlta alta = new FrmAlta();
            alta.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult mensaje = MessageBox.Show("Está por salir de a aplicación", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (mensaje == DialogResult.OK)
                Close();
            else
                return;

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsulta consulta = new FrmConsulta();
            consulta.ShowDialog();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FrmAcercaDe acercaDe = new FrmAcercaDe();
           acercaDe.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmeReporteProductos reporte = new FrmeReporteProductos();
            reporte.ShowDialog();
        }
    }
}
