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
    public partial class FrmeReporteProductos : Form
    {
        private IServicio servicio;

        public FrmeReporteProductos()
        {
            InitializeComponent();
            servicio = new ImplementacionAbstractFactory().CrearServicio();
        }

        private void FrmeReporteProductos_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            
        }



        private void btnGenerar_Click(object sender, EventArgs e)
        {
            DataTable dt = servicio.ObtenerReporteProductos(dtpDesde.Value,dtpHasta.Value);

            RvProductos.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1",dt));
            RvProductos.RefreshReport();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
