﻿namespace Delfin.Logistico
{
   partial class PRO010RView
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
         this.btnMAN_salir = new System.Windows.Forms.Button();
         this.PanelBotonera.SuspendLayout();
         this.SuspendLayout();
         // 
         // RptImpresion
         // 
         this.RptImpresion.Dock = System.Windows.Forms.DockStyle.Fill;
         this.RptImpresion.Location = new System.Drawing.Point(0, 50);
         this.RptImpresion.Name = "RptImpresion";
         this.RptImpresion.Size = new System.Drawing.Size(832, 408);
         this.RptImpresion.TabIndex = 5;
         // 
         // PanelBotonera
         // 
         this.PanelBotonera.BackColor = System.Drawing.Color.LightSteelBlue;
         this.PanelBotonera.Controls.Add(this.btnMAN_salir);
         this.PanelBotonera.Dock = System.Windows.Forms.DockStyle.Top;
         this.PanelBotonera.Location = new System.Drawing.Point(0, 0);
         this.PanelBotonera.Name = "PanelBotonera";
         this.PanelBotonera.Size = new System.Drawing.Size(832, 50);
         this.PanelBotonera.TabIndex = 6;
         // 
         // btnMAN_salir
         // 
         this.btnMAN_salir.AutoSize = true;
         this.btnMAN_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnMAN_salir.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnMAN_salir.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnMAN_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnMAN_salir.ForeColor = System.Drawing.Color.DarkBlue;
         this.btnMAN_salir.Image = global::Delfin.Logistico.Properties.Resources.undo;
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
         // PRO010RView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(832, 458);
         this.Controls.Add(this.RptImpresion);
         this.Controls.Add(this.PanelBotonera);
         this.Name = "PRO010RView";
         this.Text = "PRO010RView";
         this.PanelBotonera.ResumeLayout(false);
         this.PanelBotonera.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private Microsoft.Reporting.WinForms.ReportViewer RptImpresion;
      private System.Windows.Forms.Panel PanelBotonera;
      private System.Windows.Forms.Button btnMAN_salir;
   }
}