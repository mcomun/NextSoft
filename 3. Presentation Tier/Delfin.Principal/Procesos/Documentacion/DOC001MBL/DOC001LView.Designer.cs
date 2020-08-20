namespace Delfin.Principal
{
    partial class DOC001LView
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DOC001LView));
         this.pnBotones = new System.Windows.Forms.Panel();
         this.btnDeshacer = new System.Windows.Forms.Button();
         this.btnExportar = new System.Windows.Forms.Button();
         this.btnBuscar = new System.Windows.Forms.Button();
         this.btnForward = new System.Windows.Forms.Button();
         this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label6 = new System.Windows.Forms.Label();
         this.AyudaEntidadLinea = new Delfin.Controls.Entidad(this.components);
         this.label1 = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.txtMBL = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.txtHBL = new System.Windows.Forms.TextBox();
         this.txtNave = new System.Windows.Forms.TextBox();
         this.mdtFecHasta = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.label4 = new System.Windows.Forms.Label();
         this.mdtFecDesde = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblCONT_FecIni = new System.Windows.Forms.Label();
         this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.grdItemsDetalle = new Telerik.WinControls.UI.RadGridView();
         this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.grdItems = new Telerik.WinControls.UI.MasterGridViewTemplate();
         this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
         this.pnBotones.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle.MasterTemplate)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
         this.SuspendLayout();
         // 
         // pnBotones
         // 
         this.pnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
         this.pnBotones.Controls.Add(this.btnDeshacer);
         this.pnBotones.Controls.Add(this.btnExportar);
         this.pnBotones.Controls.Add(this.btnBuscar);
         this.pnBotones.Controls.Add(this.btnForward);
         this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
         this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.pnBotones.Location = new System.Drawing.Point(0, 26);
         this.pnBotones.Name = "pnBotones";
         this.pnBotones.Size = new System.Drawing.Size(1016, 50);
         this.pnBotones.TabIndex = 53;
         // 
         // btnDeshacer
         // 
         this.btnDeshacer.AutoSize = true;
         this.btnDeshacer.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnDeshacer.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
         this.btnDeshacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnDeshacer.ForeColor = System.Drawing.Color.Black;
         this.btnDeshacer.Image = global::Delfin.Principal.Properties.Resources.undo;
         this.btnDeshacer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnDeshacer.Location = new System.Drawing.Point(195, 0);
         this.btnDeshacer.Margin = new System.Windows.Forms.Padding(0);
         this.btnDeshacer.Name = "btnDeshacer";
         this.btnDeshacer.Size = new System.Drawing.Size(65, 50);
         this.btnDeshacer.TabIndex = 3;
         this.btnDeshacer.Text = "&Deshacer";
         this.btnDeshacer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnDeshacer.UseVisualStyleBackColor = true;
         this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);
         // 
         // btnExportar
         // 
         this.btnExportar.AutoSize = true;
         this.btnExportar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
         this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnExportar.ForeColor = System.Drawing.Color.Black;
         this.btnExportar.Image = global::Delfin.Principal.Properties.Resources.export;
         this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnExportar.Location = new System.Drawing.Point(130, 0);
         this.btnExportar.Margin = new System.Windows.Forms.Padding(0);
         this.btnExportar.Name = "btnExportar";
         this.btnExportar.Size = new System.Drawing.Size(65, 50);
         this.btnExportar.TabIndex = 2;
         this.btnExportar.Text = "&Exportar";
         this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnExportar.UseVisualStyleBackColor = true;
         this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
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
         this.btnBuscar.Location = new System.Drawing.Point(65, 0);
         this.btnBuscar.Margin = new System.Windows.Forms.Padding(0);
         this.btnBuscar.Name = "btnBuscar";
         this.btnBuscar.Size = new System.Drawing.Size(65, 50);
         this.btnBuscar.TabIndex = 1;
         this.btnBuscar.Text = "&Buscar";
         this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnBuscar.UseVisualStyleBackColor = true;
         this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
         // 
         // btnForward
         // 
         this.btnForward.AutoSize = true;
         this.btnForward.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnForward.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
         this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnForward.ForeColor = System.Drawing.Color.Black;
         this.btnForward.Image = global::Delfin.Principal.Properties.Resources.add;
         this.btnForward.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnForward.Location = new System.Drawing.Point(0, 0);
         this.btnForward.Margin = new System.Windows.Forms.Padding(0);
         this.btnForward.Name = "btnForward";
         this.btnForward.Size = new System.Drawing.Size(65, 50);
         this.btnForward.TabIndex = 4;
         this.btnForward.Text = "Nueva";
         this.btnForward.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnForward.UseVisualStyleBackColor = true;
         // 
         // TitleView
         // 
         this.TitleView.AllowActive = false;
         this.TitleView.AntiAlias = false;
         this.TitleView.Caption = "Bill of Lading";
         this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
         this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
         this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.TitleView.Location = new System.Drawing.Point(0, 0);
         this.TitleView.Name = "TitleView";
         this.TitleView.Size = new System.Drawing.Size(1016, 26);
         this.TitleView.TabIndex = 52;
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
         this.panelCaption1.Size = new System.Drawing.Size(1016, 26);
         this.panelCaption1.TabIndex = 54;
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
         this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.AyudaEntidadLinea, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
         this.tableLayoutPanel1.Controls.Add(this.label9, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.txtMBL, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.label7, 3, 1);
         this.tableLayoutPanel1.Controls.Add(this.txtHBL, 4, 1);
         this.tableLayoutPanel1.Controls.Add(this.txtNave, 4, 0);
         this.tableLayoutPanel1.Controls.Add(this.mdtFecHasta, 4, 2);
         this.tableLayoutPanel1.Controls.Add(this.label4, 3, 2);
         this.tableLayoutPanel1.Controls.Add(this.mdtFecDesde, 1, 2);
         this.tableLayoutPanel1.Controls.Add(this.lblCONT_FecIni, 0, 2);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 3;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(1016, 81);
         this.tableLayoutPanel1.TabIndex = 55;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(10, 7);
         this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(46, 13);
         this.label6.TabIndex = 95;
         this.label6.Text = "Linea :";
         // 
         // AyudaEntidadLinea
         // 
         this.AyudaEntidadLinea.ActivarAyudaAuto = false;
         this.AyudaEntidadLinea.ContainerService = null;
         this.AyudaEntidadLinea.EnabledAyudaButton = true;
         this.AyudaEntidadLinea.Location = new System.Drawing.Point(153, 3);
         this.AyudaEntidadLinea.LongitudAceptada = 0;
         this.AyudaEntidadLinea.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.AyudaEntidadLinea.Name = "AyudaEntidadLinea";
         this.AyudaEntidadLinea.RellenaCeros = false;
         this.AyudaEntidadLinea.Size = new System.Drawing.Size(194, 20);
         this.AyudaEntidadLinea.TabIndex = 94;
         this.AyudaEntidadLinea.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.AyudaEntidadLinea.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
         this.AyudaEntidadLinea.Value = null;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(375, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(41, 13);
         this.label1.TabIndex = 99;
         this.label1.Text = "Nave:";
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label9.Location = new System.Drawing.Point(10, 34);
         this.label9.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(39, 13);
         this.label9.TabIndex = 101;
         this.label9.Text = "MBL :";
         // 
         // txtMBL
         // 
         this.txtMBL.Location = new System.Drawing.Point(153, 30);
         this.txtMBL.MaxLength = 20;
         this.txtMBL.Name = "txtMBL";
         this.txtMBL.Size = new System.Drawing.Size(194, 20);
         this.txtMBL.TabIndex = 102;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label7.Location = new System.Drawing.Point(375, 34);
         this.label7.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(38, 13);
         this.label7.TabIndex = 80;
         this.label7.Text = "HBL :";
         // 
         // txtHBL
         // 
         this.txtHBL.Location = new System.Drawing.Point(518, 30);
         this.txtHBL.MaxLength = 20;
         this.txtHBL.Name = "txtHBL";
         this.txtHBL.Size = new System.Drawing.Size(194, 20);
         this.txtHBL.TabIndex = 90;
         // 
         // txtNave
         // 
         this.txtNave.Location = new System.Drawing.Point(518, 3);
         this.txtNave.MaxLength = 30;
         this.txtNave.Name = "txtNave";
         this.txtNave.Size = new System.Drawing.Size(194, 20);
         this.txtNave.TabIndex = 103;
         // 
         // mdtFecHasta
         // 
         this.mdtFecHasta.Location = new System.Drawing.Point(518, 57);
         this.mdtFecHasta.MinimumSize = new System.Drawing.Size(100, 22);
         this.mdtFecHasta.Name = "mdtFecHasta";
         this.mdtFecHasta.NSActiveMouse = false;
         this.mdtFecHasta.NSActiveMsgFecha = false;
         this.mdtFecHasta.NSChangeDate = true;
         this.mdtFecHasta.NSDigitos = 4;
         this.mdtFecHasta.NSFecha = null;
         this.mdtFecHasta.NSSetDateNow = false;
         this.mdtFecHasta.Size = new System.Drawing.Size(104, 22);
         this.mdtFecHasta.TabIndex = 84;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(375, 61);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(44, 13);
         this.label4.TabIndex = 81;
         this.label4.Text = "Hasta:";
         // 
         // mdtFecDesde
         // 
         this.mdtFecDesde.Location = new System.Drawing.Point(153, 57);
         this.mdtFecDesde.MinimumSize = new System.Drawing.Size(100, 22);
         this.mdtFecDesde.Name = "mdtFecDesde";
         this.mdtFecDesde.NSActiveMouse = false;
         this.mdtFecDesde.NSActiveMsgFecha = false;
         this.mdtFecDesde.NSChangeDate = true;
         this.mdtFecDesde.NSDigitos = 4;
         this.mdtFecDesde.NSFecha = null;
         this.mdtFecDesde.NSSetDateNow = false;
         this.mdtFecDesde.Size = new System.Drawing.Size(106, 22);
         this.mdtFecDesde.TabIndex = 82;
         // 
         // lblCONT_FecIni
         // 
         this.lblCONT_FecIni.AutoSize = true;
         this.lblCONT_FecIni.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_FecIni.Location = new System.Drawing.Point(10, 61);
         this.lblCONT_FecIni.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_FecIni.Name = "lblCONT_FecIni";
         this.lblCONT_FecIni.Size = new System.Drawing.Size(133, 13);
         this.lblCONT_FecIni.TabIndex = 81;
         this.lblCONT_FecIni.Text = "Fecha Emisión Desde:";
         // 
         // panelCaption2
         // 
         this.panelCaption2.AllowActive = false;
         this.panelCaption2.AntiAlias = false;
         this.panelCaption2.Caption = "Resultado Búsqueda MBL";
         this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption2.Location = new System.Drawing.Point(0, 183);
         this.panelCaption2.Name = "panelCaption2";
         this.panelCaption2.Size = new System.Drawing.Size(1016, 26);
         this.panelCaption2.TabIndex = 56;
         // 
         // grdItemsDetalle
         // 
         this.grdItemsDetalle.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdItemsDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.grdItemsDetalle.Location = new System.Drawing.Point(0, 355);
         this.grdItemsDetalle.Name = "grdItemsDetalle";
         // 
         // 
         // 
         this.grdItemsDetalle.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 355, 240, 150);
         this.grdItemsDetalle.Size = new System.Drawing.Size(1016, 135);
         this.grdItemsDetalle.TabIndex = 59;
         this.grdItemsDetalle.TabStop = false;
         // 
         // panelCaption3
         // 
         this.panelCaption3.AllowActive = false;
         this.panelCaption3.AntiAlias = false;
         this.panelCaption3.Caption = "Resultado Búsqueda HBL";
         this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption3.Location = new System.Drawing.Point(0, 329);
         this.panelCaption3.Name = "panelCaption3";
         this.panelCaption3.Size = new System.Drawing.Size(1016, 26);
         this.panelCaption3.TabIndex = 60;
         // 
         // radGridView1
         // 
         this.radGridView1.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.radGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.radGridView1.Location = new System.Drawing.Point(0, 208);
         this.radGridView1.Name = "radGridView1";
         // 
         // 
         // 
         this.radGridView1.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 208, 240, 150);
         this.radGridView1.Size = new System.Drawing.Size(1016, 121);
         this.radGridView1.TabIndex = 61;
         this.radGridView1.TabStop = false;
         // 
         // DOC001LView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.Controls.Add(this.radGridView1);
         this.Controls.Add(this.panelCaption3);
         this.Controls.Add(this.grdItemsDetalle);
         this.Controls.Add(this.panelCaption2);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.pnBotones);
         this.Controls.Add(this.TitleView);
         this.Name = "DOC001LView";
         this.Size = new System.Drawing.Size(1016, 490);
         this.pnBotones.ResumeLayout(false);
         this.pnBotones.PerformLayout();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Infrastructure.WinForms.Controls.FormTitle TitleView;
      private System.Windows.Forms.Panel pnBotones;
      private System.Windows.Forms.Button btnDeshacer;
      private System.Windows.Forms.Button btnExportar;
      private System.Windows.Forms.Button btnBuscar;
      private System.Windows.Forms.Button btnForward;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
      private System.Windows.Forms.Label lblCONT_FecIni;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtFecDesde;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtFecHasta;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.TextBox txtHBL;
      private Controls.Entidad AyudaEntidadLinea;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.TextBox txtMBL;
      private Telerik.WinControls.UI.RadGridView grdItemsDetalle;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.TextBox txtNave;
      private Telerik.WinControls.UI.MasterGridViewTemplate grdItems;
      private Telerik.WinControls.UI.RadGridView radGridView1;
   }
}
