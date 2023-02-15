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
    public partial class FrmAcercaDe : Form
    {
        public FrmAcercaDe()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkLinkedin.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/gerardo-valdez/");
        }

        private void lnkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkGitHub.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/GerardoValdez");

        }

        
    }
}
