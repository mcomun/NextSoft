namespace Delfin.Principal.Procesos.Facturacion
{
    partial class PRO007RViewRC
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
            this.CrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrystalReportViewer
            // 
            this.CrystalReportViewer.ActiveViewIndex = -1;
            this.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrystalReportViewer.EnableRefresh = false;
            this.CrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.CrystalReportViewer.Margin = new System.Windows.Forms.Padding(2);
            this.CrystalReportViewer.Name = "CrystalReportViewer";
            this.CrystalReportViewer.ReuseParameterValuesOnRefresh = true;
            this.CrystalReportViewer.Size = new System.Drawing.Size(774, 404);
            this.CrystalReportViewer.TabIndex = 1;
            this.CrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.CrystalReportViewer.Load += new System.EventHandler(this.CrystalReportViewer_Load);
            this.CrystalReportViewer.Click += new System.EventHandler(this.CrystalReportViewer_Click);
            // 
            // PRO007RViewRC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 404);
            this.Controls.Add(this.CrystalReportViewer);
            this.Name = "PRO007RViewRC";
            this.Text = "Visor de Recibo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PRO007RViewRC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportViewer;

    }
}