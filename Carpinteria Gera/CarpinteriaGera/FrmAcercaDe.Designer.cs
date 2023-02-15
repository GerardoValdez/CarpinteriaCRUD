namespace CarpinteriaGera
{
    partial class FrmAcercaDe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAcercaDe));
            this.lnkLinkedin = new System.Windows.Forms.LinkLabel();
            this.lnkGitHub = new System.Windows.Forms.LinkLabel();
            this.lblAcercaDe = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lnkLinkedin
            // 
            this.lnkLinkedin.ActiveLinkColor = System.Drawing.Color.DarkSlateBlue;
            this.lnkLinkedin.AutoSize = true;
            this.lnkLinkedin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLinkedin.LinkColor = System.Drawing.Color.Gainsboro;
            this.lnkLinkedin.Location = new System.Drawing.Point(63, 48);
            this.lnkLinkedin.Name = "lnkLinkedin";
            this.lnkLinkedin.Size = new System.Drawing.Size(136, 24);
            this.lnkLinkedin.TabIndex = 0;
            this.lnkLinkedin.TabStop = true;
            this.lnkLinkedin.Text = "Visitar Linkedin";
            this.lnkLinkedin.VisitedLinkColor = System.Drawing.Color.Black;
            this.lnkLinkedin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lnkGitHub
            // 
            this.lnkGitHub.ActiveLinkColor = System.Drawing.Color.DarkSlateBlue;
            this.lnkGitHub.AutoSize = true;
            this.lnkGitHub.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkGitHub.LinkColor = System.Drawing.Color.Gainsboro;
            this.lnkGitHub.Location = new System.Drawing.Point(70, 100);
            this.lnkGitHub.Name = "lnkGitHub";
            this.lnkGitHub.Size = new System.Drawing.Size(123, 24);
            this.lnkGitHub.TabIndex = 1;
            this.lnkGitHub.TabStop = true;
            this.lnkGitHub.Text = "Visitar GitHub";
            this.lnkGitHub.VisitedLinkColor = System.Drawing.Color.Black;
            this.lnkGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGitHub_LinkClicked);
            // 
            // lblAcercaDe
            // 
            this.lblAcercaDe.AutoSize = true;
            this.lblAcercaDe.Font = new System.Drawing.Font("Bookman Old Style", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcercaDe.Location = new System.Drawing.Point(44, 9);
            this.lblAcercaDe.Name = "lblAcercaDe";
            this.lblAcercaDe.Size = new System.Drawing.Size(174, 24);
            this.lblAcercaDe.TabIndex = 2;
            this.lblAcercaDe.Text = "Valdez Gerardo";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR.Location = new System.Drawing.Point(26, 13);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(20, 18);
            this.lblR.TabIndex = 3;
            this.lblR.Text = "®";
            // 
            // FrmAcercaDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.ClientSize = new System.Drawing.Size(259, 160);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.lblAcercaDe);
            this.Controls.Add(this.lnkGitHub);
            this.Controls.Add(this.lnkLinkedin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAcercaDe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Información";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkLinkedin;
        private System.Windows.Forms.LinkLabel lnkGitHub;
        private System.Windows.Forms.Label lblAcercaDe;
        private System.Windows.Forms.Label lblR;
    }
}