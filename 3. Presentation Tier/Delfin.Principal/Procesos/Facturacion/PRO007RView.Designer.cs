namespace Delfin.Principal
{
   partial class PRO007RView
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
            this.RptImpresion = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PanelBotonera = new System.Windows.Forms.Panel();
            this.dsReportes1 = new Delfin.Principal.Reportes.Comercial.DSReportes();
            this.btnMAN_salir = new System.Windows.Forms.Button();
            this.PanelBotonera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsReportes1)).BeginInit();
            this.SuspendLayout();
            // 
            // RptImpresion
            // 
            this.RptImpresion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RptImpresion.Location = new System.Drawing.Point(0, 50);
            this.RptImpresion.Name = "RptImpresion";
            this.RptImpresion.Size = new System.Drawing.Size(920, 451);
            this.RptImpresion.TabIndex = 0;
            // 
            // PanelBotonera
            // 
            this.PanelBotonera.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PanelBotonera.Controls.Add(this.btnMAN_salir);
            this.PanelBotonera.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelBotonera.Location = new System.Drawing.Point(0, 0);
            this.PanelBotonera.Name = "PanelBotonera";
            this.PanelBotonera.Size = new System.Drawing.Size(920, 50);
            this.PanelBotonera.TabIndex = 4;
            // 
            // dsReportes1
            // 
            this.dsReportes1.DataSetName = "DSReportes";
            this.dsReportes1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnMAN_salir
            // 
            this.btnMAN_salir.AutoSize = true;
            this.btnMAN_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMAN_salir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMAN_salir.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnMAN_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMAN_salir.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnMAN_salir.Image = global::Delfin.Principal.Properties.Resources.undo;
            this.btnMAN_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMAN_salir.Location = new System.Drawing.Point(0, 0);
            this.btnMAN_salir.Margin = new System.Windows.Forms.Padding(0);
            this.btnMAN_salir.Name = "btnMAN_salir";
            this.btnMAN_salir.Size = new System.Drawing.Size(55, 50);
            this.btnMAN_salir.TabIndex = 1;
            this.btnMAN_salir.Text = "&Salir";
            this.btnMAN_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMAN_salir.UseVisualStyleBackColor = true;
            // 
            // PRO007RView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 501);
            this.Controls.Add(this.RptImpresion);
            this.Controls.Add(this.PanelBotonera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PRO007RView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.PanelBotonera.ResumeLayout(false);
            this.PanelBotonera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsReportes1)).EndInit();
            this.ResumeLayout(false);

      }

      #endregion

      private Principal.Reportes.Comercial.DSReportes dsReportes1;
      private Microsoft.Reporting.WinForms.ReportViewer RptImpresion;
      private System.Windows.Forms.Panel PanelBotonera;
      private System.Windows.Forms.Button btnMAN_salir;
   }
}