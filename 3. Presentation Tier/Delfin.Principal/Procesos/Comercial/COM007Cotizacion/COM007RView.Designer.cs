namespace Delfin.Principal
{
   partial class COM007RView
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
         this.rvwReporte = new Microsoft.Reporting.WinForms.ReportViewer();
         this.SuspendLayout();
         // 
         // rvwReporte
         // 
         this.rvwReporte.Dock = System.Windows.Forms.DockStyle.Fill;
         this.rvwReporte.Location = new System.Drawing.Point(0, 0);
         this.rvwReporte.Name = "rvwReporte";
         this.rvwReporte.Size = new System.Drawing.Size(545, 419);
         this.rvwReporte.TabIndex = 47;
         this.rvwReporte.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
         // 
         // COM007RView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(545, 419);
         this.Controls.Add(this.rvwReporte);
         this.MinimizeBox = false;
         this.Name = "COM007RView";
         this.Text = "Visualizador";
         this.ResumeLayout(false);

      }

      #endregion

      private Microsoft.Reporting.WinForms.ReportViewer rvwReporte;
   }
}