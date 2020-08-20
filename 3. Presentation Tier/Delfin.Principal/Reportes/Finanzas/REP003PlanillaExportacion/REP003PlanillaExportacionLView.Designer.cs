namespace Delfin.Principal
{
   partial class REP003PlanillaExportacionLView
   {
      /// <summary> 
      /// Variable del diseñador requerida.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Limpiar los recursos que se estén utilizando.
      /// </summary>
      /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Código generado por el Diseñador de componentes

      /// <summary> 
      /// Método necesario para admitir el Diseñador. No se puede modificar 
      /// el contenido del método con el editor de código.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REP003PlanillaExportacionLView));
         this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.pnBotones = new System.Windows.Forms.Panel();
         this.btnBuscar = new System.Windows.Forms.Button();
         this.btnImprimir = new System.Windows.Forms.Button();
         this.pnBotones.SuspendLayout();
         this.SuspendLayout();
         // 
         // TitleView
         // 
         this.TitleView.AllowActive = false;
         this.TitleView.AntiAlias = false;
         this.TitleView.Caption = "Template Reporte";
         this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
         this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
         this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.TitleView.Location = new System.Drawing.Point(0, 0);
         this.TitleView.Name = "TitleView";
         this.TitleView.Size = new System.Drawing.Size(767, 26);
         this.TitleView.TabIndex = 52;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.AutoSize = true;
         this.tableLayoutPanel1.ColumnCount = 7;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 4;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(767, 108);
         this.tableLayoutPanel1.TabIndex = 55;
         // 
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Criterio de Búsqueda";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 76);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(767, 26);
         this.panelCaption1.TabIndex = 54;
         // 
         // pnBotones
         // 
         this.pnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
         this.pnBotones.Controls.Add(this.btnImprimir);
         this.pnBotones.Controls.Add(this.btnBuscar);
         this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
         this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.pnBotones.Location = new System.Drawing.Point(0, 26);
         this.pnBotones.Name = "pnBotones";
         this.pnBotones.Size = new System.Drawing.Size(767, 50);
         this.pnBotones.TabIndex = 53;
         // 
         // btnBuscar
         // 
         this.btnBuscar.AutoSize = true;
         this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
         this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnBuscar.ForeColor = System.Drawing.Color.Black;
         this.btnBuscar.Image = global::Delfin.Principal.Properties.Resources.search;
         this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnBuscar.Location = new System.Drawing.Point(0, 0);
         this.btnBuscar.Margin = new System.Windows.Forms.Padding(0);
         this.btnBuscar.Name = "btnBuscar";
         this.btnBuscar.Size = new System.Drawing.Size(55, 50);
         this.btnBuscar.TabIndex = 1;
         this.btnBuscar.Text = "&Buscar";
         this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnBuscar.UseVisualStyleBackColor = true;
         // 
         // btnImprimir
         // 
         this.btnImprimir.AutoSize = true;
         this.btnImprimir.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
         this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnImprimir.ForeColor = System.Drawing.Color.Black;
         this.btnImprimir.Image = global::Delfin.Principal.Properties.Resources.printer2;
         this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnImprimir.Location = new System.Drawing.Point(55, 0);
         this.btnImprimir.Margin = new System.Windows.Forms.Padding(0);
         this.btnImprimir.Name = "btnImprimir";
         this.btnImprimir.Size = new System.Drawing.Size(58, 50);
         this.btnImprimir.TabIndex = 6;
         this.btnImprimir.Text = "&Imprimir";
         this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnImprimir.UseVisualStyleBackColor = true;
         // 
         // REP000LView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.pnBotones);
         this.Controls.Add(this.TitleView);
         this.Name = "REP000LView";
         this.Size = new System.Drawing.Size(767, 417);
         this.pnBotones.ResumeLayout(false);
         this.pnBotones.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Infrastructure.WinForms.Controls.FormTitle TitleView;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.Panel pnBotones;
      private System.Windows.Forms.Button btnBuscar;
      private System.Windows.Forms.Button btnImprimir;
   }
}
