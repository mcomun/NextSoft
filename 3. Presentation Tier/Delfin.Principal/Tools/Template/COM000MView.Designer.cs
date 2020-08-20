namespace Delfin.Principal
{
   partial class COM000MView
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
         this.components = new System.ComponentModel.Container();
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnSalir = new System.Windows.Forms.Button();
         this.btnGuardar = new System.Windows.Forms.Button();
         this.errorProviderCab_Cotizacion_OV = new System.Windows.Forms.ErrorProvider(this.components);
         this.tabCab_Cotizacion_OV = new Dotnetrix.Controls.TabControlEX();
         this.pageGenerales = new Dotnetrix.Controls.TabPageEX();
         this.tableDatosGenerales = new System.Windows.Forms.TableLayoutPanel();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.pageDetalle = new Dotnetrix.Controls.TabPageEX();
         this.grdItemsServicio = new Telerik.WinControls.UI.RadGridView();
         this.btnDelServicio = new System.Windows.Forms.Button();
         this.btnAddServicio = new System.Windows.Forms.Button();
         this.panelCaption5 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
         this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.errorProviderDet_Cotizacion_OV_Novedad = new System.Windows.Forms.ErrorProvider(this.components);
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.errorEventoTarea = new System.Windows.Forms.ErrorProvider(this.components);
         this.panel3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).BeginInit();
         this.tabCab_Cotizacion_OV.SuspendLayout();
         this.pageGenerales.SuspendLayout();
         this.pageDetalle.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio.MasterTemplate)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).BeginInit();
         this.SuspendLayout();
         // 
         // panel3
         // 
         this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
         this.panel3.Controls.Add(this.btnSalir);
         this.panel3.Controls.Add(this.btnGuardar);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel3.Location = new System.Drawing.Point(0, 0);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(1104, 50);
         this.panel3.TabIndex = 0;
         // 
         // btnSalir
         // 
         this.btnSalir.AutoSize = true;
         this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnSalir.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnSalir.ForeColor = System.Drawing.Color.Black;
         this.btnSalir.Image = global::Delfin.Principal.Properties.Resources.undo;
         this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnSalir.Location = new System.Drawing.Point(57, 0);
         this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
         this.btnSalir.Name = "btnSalir";
         this.btnSalir.Size = new System.Drawing.Size(55, 50);
         this.btnSalir.TabIndex = 1;
         this.btnSalir.Text = "Salir";
         this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnSalir.UseVisualStyleBackColor = true;
         // 
         // btnGuardar
         // 
         this.btnGuardar.AutoSize = true;
         this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnGuardar.ForeColor = System.Drawing.Color.Black;
         this.btnGuardar.Image = global::Delfin.Principal.Properties.Resources.save;
         this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnGuardar.Location = new System.Drawing.Point(0, 0);
         this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
         this.btnGuardar.Name = "btnGuardar";
         this.btnGuardar.Size = new System.Drawing.Size(57, 50);
         this.btnGuardar.TabIndex = 0;
         this.btnGuardar.Text = "Guardar";
         this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnGuardar.UseVisualStyleBackColor = true;
         // 
         // errorProviderCab_Cotizacion_OV
         // 
         this.errorProviderCab_Cotizacion_OV.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
         this.errorProviderCab_Cotizacion_OV.ContainerControl = this;
         // 
         // tabCab_Cotizacion_OV
         // 
         this.tabCab_Cotizacion_OV.Controls.Add(this.pageGenerales);
         this.tabCab_Cotizacion_OV.Controls.Add(this.pageDetalle);
         this.tabCab_Cotizacion_OV.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabCab_Cotizacion_OV.Location = new System.Drawing.Point(0, 50);
         this.tabCab_Cotizacion_OV.Name = "tabCab_Cotizacion_OV";
         this.tabCab_Cotizacion_OV.SelectedIndex = 1;
         this.tabCab_Cotizacion_OV.SelectedTabColor = System.Drawing.Color.SteelBlue;
         this.tabCab_Cotizacion_OV.Size = new System.Drawing.Size(1104, 378);
         this.tabCab_Cotizacion_OV.TabIndex = 1;
         this.tabCab_Cotizacion_OV.UseVisualStyles = false;
         // 
         // pageGenerales
         // 
         this.pageGenerales.Controls.Add(this.tableDatosGenerales);
         this.pageGenerales.Controls.Add(this.panelCaption1);
         this.pageGenerales.Location = new System.Drawing.Point(4, 25);
         this.pageGenerales.Name = "pageGenerales";
         this.pageGenerales.Size = new System.Drawing.Size(1096, 349);
         this.pageGenerales.TabIndex = 0;
         this.pageGenerales.Text = "Datos Generales";
         // 
         // tableDatosGenerales
         // 
         this.tableDatosGenerales.AutoSize = true;
         this.tableDatosGenerales.ColumnCount = 9;
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
         this.tableDatosGenerales.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableDatosGenerales.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableDatosGenerales.Location = new System.Drawing.Point(0, 26);
         this.tableDatosGenerales.Name = "tableDatosGenerales";
         this.tableDatosGenerales.RowCount = 6;
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.Size = new System.Drawing.Size(1096, 162);
         this.tableDatosGenerales.TabIndex = 0;
         // 
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Datos Generales";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 0);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(1096, 26);
         this.panelCaption1.TabIndex = 1;
         // 
         // pageDetalle
         // 
         this.pageDetalle.Controls.Add(this.grdItemsServicio);
         this.pageDetalle.Controls.Add(this.btnDelServicio);
         this.pageDetalle.Controls.Add(this.btnAddServicio);
         this.pageDetalle.Controls.Add(this.panelCaption5);
         this.pageDetalle.Controls.Add(this.tableLayoutPanel3);
         this.pageDetalle.Controls.Add(this.panelCaption3);
         this.pageDetalle.Location = new System.Drawing.Point(4, 25);
         this.pageDetalle.Name = "pageDetalle";
         this.pageDetalle.Size = new System.Drawing.Size(1096, 349);
         this.pageDetalle.TabIndex = 1;
         this.pageDetalle.Text = "Detalle";
         // 
         // grdItemsServicio
         // 
         this.grdItemsServicio.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdItemsServicio.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItemsServicio.Location = new System.Drawing.Point(0, 188);
         this.grdItemsServicio.Margin = new System.Windows.Forms.Padding(3, 3, 18, 3);
         this.grdItemsServicio.Name = "grdItemsServicio";
         // 
         // 
         // 
         this.grdItemsServicio.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 188, 240, 150);
         this.grdItemsServicio.RootElement.MinSize = new System.Drawing.Size(0, 0);
         this.grdItemsServicio.Size = new System.Drawing.Size(1096, 161);
         this.grdItemsServicio.TabIndex = 7;
         this.grdItemsServicio.TabStop = false;
         // 
         // btnDelServicio
         // 
         this.btnDelServicio.BackColor = System.Drawing.Color.Transparent;
         this.btnDelServicio.Image = global::Delfin.Principal.Properties.Resources.delete1;
         this.btnDelServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnDelServicio.Location = new System.Drawing.Point(184, 309);
         this.btnDelServicio.Name = "btnDelServicio";
         this.btnDelServicio.Size = new System.Drawing.Size(25, 24);
         this.btnDelServicio.TabIndex = 6;
         this.btnDelServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnDelServicio, "Eliminar Servicio");
         this.btnDelServicio.UseVisualStyleBackColor = false;
         // 
         // btnAddServicio
         // 
         this.btnAddServicio.BackColor = System.Drawing.Color.Transparent;
         this.btnAddServicio.Image = global::Delfin.Principal.Properties.Resources.add16x16;
         this.btnAddServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnAddServicio.Location = new System.Drawing.Point(153, 309);
         this.btnAddServicio.Name = "btnAddServicio";
         this.btnAddServicio.Size = new System.Drawing.Size(25, 24);
         this.btnAddServicio.TabIndex = 5;
         this.btnAddServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnAddServicio, "Nuevo Servicio");
         this.btnAddServicio.UseVisualStyleBackColor = false;
         // 
         // panelCaption5
         // 
         this.panelCaption5.AllowActive = false;
         this.panelCaption5.AntiAlias = false;
         this.panelCaption5.Caption = "Detalle";
         this.panelCaption5.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption5.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption5.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption5.Location = new System.Drawing.Point(0, 161);
         this.panelCaption5.Name = "panelCaption5";
         this.panelCaption5.Size = new System.Drawing.Size(1096, 27);
         this.panelCaption5.TabIndex = 4;
         // 
         // tableLayoutPanel3
         // 
         this.tableLayoutPanel3.AutoSize = true;
         this.tableLayoutPanel3.ColumnCount = 10;
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 26);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 5;
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel3.Size = new System.Drawing.Size(1096, 135);
         this.tableLayoutPanel3.TabIndex = 0;
         // 
         // panelCaption3
         // 
         this.panelCaption3.AllowActive = false;
         this.panelCaption3.AntiAlias = false;
         this.panelCaption3.Caption = "Datos del Detalle";
         this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption3.Location = new System.Drawing.Point(0, 0);
         this.panelCaption3.Name = "panelCaption3";
         this.panelCaption3.Size = new System.Drawing.Size(1096, 26);
         this.panelCaption3.TabIndex = 0;
         // 
         // errorProviderDet_Cotizacion_OV_Novedad
         // 
         this.errorProviderDet_Cotizacion_OV_Novedad.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
         this.errorProviderDet_Cotizacion_OV_Novedad.ContainerControl = this;
         // 
         // errorEventoTarea
         // 
         this.errorEventoTarea.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
         this.errorEventoTarea.ContainerControl = this;
         // 
         // COM000MView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.CancelButton = this.btnSalir;
         this.ClientSize = new System.Drawing.Size(1104, 428);
         this.Controls.Add(this.tabCab_Cotizacion_OV);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Name = "COM000MView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Cotización";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).EndInit();
         this.tabCab_Cotizacion_OV.ResumeLayout(false);
         this.pageGenerales.ResumeLayout(false);
         this.pageGenerales.PerformLayout();
         this.pageDetalle.ResumeLayout(false);
         this.pageDetalle.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).EndInit();
         this.ResumeLayout(false);

      }



      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private System.Windows.Forms.ErrorProvider errorProviderCab_Cotizacion_OV;
      private Dotnetrix.Controls.TabControlEX tabCab_Cotizacion_OV;
      private Dotnetrix.Controls.TabPageEX pageGenerales;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private Dotnetrix.Controls.TabPageEX pageDetalle;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private Telerik.WinControls.UI.RadGridView grdItemsServicio;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption5;
      private System.Windows.Forms.Button btnDelServicio;
      private System.Windows.Forms.Button btnAddServicio;
      private System.Windows.Forms.ErrorProvider errorProviderDet_Cotizacion_OV_Novedad;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.ErrorProvider errorEventoTarea;
      private System.Windows.Forms.TableLayoutPanel tableDatosGenerales;
   }
}