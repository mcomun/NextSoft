namespace Delfin.Principal
{
    partial class DOC000LView
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
            this.pnBotones = new System.Windows.Forms.Panel();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
            this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.label1 = new System.Windows.Forms.Label();
            this.AyudaEntidadLinea = new Delfin.Controls.Entidad(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AyudaHBL = new Delfin.Controls.Entidad(this.components);
            this.CCOT_FecDesde = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.maskDateTime1 = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grdItemsDetalle = new Telerik.WinControls.UI.MasterGridViewTemplate();
            this.panelCaption4 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            this.textBoxOpenFile1 = new Infrastructure.WinForms.Controls.TextBoxOpenFile();
            this.pnBotones.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // pnBotones
            // 
            this.pnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnBotones.Controls.Add(this.btnDeshacer);
            this.pnBotones.Controls.Add(this.btnExportar);
            this.pnBotones.Controls.Add(this.btnImportar);
            this.pnBotones.Controls.Add(this.btnBuscar);
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
            this.btnDeshacer.Location = new System.Drawing.Point(171, 0);
            this.btnDeshacer.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(65, 50);
            this.btnDeshacer.TabIndex = 8;
            this.btnDeshacer.Text = "&Deshacer";
            this.btnDeshacer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeshacer.UseVisualStyleBackColor = true;
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
            this.btnExportar.Location = new System.Drawing.Point(113, 0);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(58, 50);
            this.btnExportar.TabIndex = 7;
            this.btnExportar.Text = "&Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // btnImportar
            // 
            this.btnImportar.AutoSize = true;
            this.btnImportar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnImportar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.ForeColor = System.Drawing.Color.Black;
            this.btnImportar.Image = global::Delfin.Principal.Properties.Resources.document_into;
            this.btnImportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImportar.Location = new System.Drawing.Point(55, 0);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(0);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(58, 50);
            this.btnImportar.TabIndex = 6;
            this.btnImportar.Text = "Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar.UseVisualStyleBackColor = true;
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
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // TitleView
            // 
            this.TitleView.AllowActive = false;
            this.TitleView.AntiAlias = false;
            this.TitleView.Caption = "Loading List";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = global::Delfin.Principal.Properties.Resources.contract;
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(1016, 26);
            this.TitleView.TabIndex = 52;
            // 
            // panelCaption2
            // 
            this.panelCaption2.AllowActive = false;
            this.panelCaption2.AntiAlias = false;
            this.panelCaption2.Caption = "Criterios de Búsqueda";
            this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption2.Location = new System.Drawing.Point(0, 76);
            this.panelCaption2.Name = "panelCaption2";
            this.panelCaption2.Size = new System.Drawing.Size(1016, 26);
            this.panelCaption2.TabIndex = 56;
            // 
            // panelCaption3
            // 
            this.panelCaption3.AllowActive = false;
            this.panelCaption3.AntiAlias = false;
            this.panelCaption3.Caption = "Ruta del Archivo";
            this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption3.Location = new System.Drawing.Point(0, 163);
            this.panelCaption3.Name = "panelCaption3";
            this.panelCaption3.Size = new System.Drawing.Size(1016, 30);
            this.panelCaption3.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(375, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "HBL:";
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
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArchivo.Location = new System.Drawing.Point(10, 7);
            this.lblArchivo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(59, 13);
            this.lblArchivo.TabIndex = 95;
            this.lblArchivo.Text = "Archivo :";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.AyudaEntidadLinea, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.AyudaHBL, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.CCOT_FecDesde, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.maskDateTime1, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 3, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1016, 61);
            this.tableLayoutPanel2.TabIndex = 61;
            // 
            // AyudaHBL
            // 
            this.AyudaHBL.ActivarAyudaAuto = false;
            this.AyudaHBL.ContainerService = null;
            this.AyudaHBL.EnabledAyudaButton = true;
            this.AyudaHBL.Location = new System.Drawing.Point(518, 3);
            this.AyudaHBL.LongitudAceptada = 0;
            this.AyudaHBL.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.AyudaHBL.Name = "AyudaHBL";
            this.AyudaHBL.RellenaCeros = false;
            this.AyudaHBL.Size = new System.Drawing.Size(194, 20);
            this.AyudaHBL.TabIndex = 94;
            this.AyudaHBL.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.AyudaHBL.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.AyudaHBL.Value = null;
            // 
            // CCOT_FecDesde
            // 
            this.CCOT_FecDesde.Location = new System.Drawing.Point(153, 30);
            this.CCOT_FecDesde.MinimumSize = new System.Drawing.Size(100, 22);
            this.CCOT_FecDesde.Name = "CCOT_FecDesde";
            this.CCOT_FecDesde.NSActiveMouse = false;
            this.CCOT_FecDesde.NSActiveMsgFecha = false;
            this.CCOT_FecDesde.NSChangeDate = true;
            this.CCOT_FecDesde.NSDigitos = 4;
            this.CCOT_FecDesde.NSFecha = null;
            this.CCOT_FecDesde.NSSetDateNow = false;
            this.CCOT_FecDesde.Size = new System.Drawing.Size(101, 22);
            this.CCOT_FecDesde.TabIndex = 100;
            // 
            // maskDateTime1
            // 
            this.maskDateTime1.Location = new System.Drawing.Point(518, 30);
            this.maskDateTime1.MinimumSize = new System.Drawing.Size(100, 22);
            this.maskDateTime1.Name = "maskDateTime1";
            this.maskDateTime1.NSActiveMouse = false;
            this.maskDateTime1.NSActiveMsgFecha = false;
            this.maskDateTime1.NSChangeDate = true;
            this.maskDateTime1.NSDigitos = 4;
            this.maskDateTime1.NSFecha = null;
            this.maskDateTime1.NSSetDateNow = false;
            this.maskDateTime1.Size = new System.Drawing.Size(101, 22);
            this.maskDateTime1.TabIndex = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Fecha ETD inicio :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(375, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 95;
            this.label3.Text = "Fecha ETD fin :";
            // 
            // panelCaption4
            // 
            this.panelCaption4.AllowActive = false;
            this.panelCaption4.AntiAlias = false;
            this.panelCaption4.Caption = "Resultados del Loading List";
            this.panelCaption4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption4.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption4.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption4.Location = new System.Drawing.Point(0, 220);
            this.panelCaption4.Name = "panelCaption4";
            this.panelCaption4.Size = new System.Drawing.Size(1016, 30);
            this.panelCaption4.TabIndex = 63;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.lblArchivo, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxOpenFile1, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 193);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1016, 27);
            this.tableLayoutPanel3.TabIndex = 62;
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdItems.Location = new System.Drawing.Point(0, 250);
            this.grdItems.Name = "grdItems";
            this.grdItems.Size = new System.Drawing.Size(1016, 184);
            this.grdItems.TabIndex = 104;
            this.grdItems.TabStop = false;
            // 
            // textBoxOpenFile1
            // 
            this.textBoxOpenFile1.Archivo = null;
            this.tableLayoutPanel3.SetColumnSpan(this.textBoxOpenFile1, 4);
            this.textBoxOpenFile1.DefaultFile = "*";
            this.textBoxOpenFile1.EnableButton = true;
            this.textBoxOpenFile1.FileData = null;
            this.textBoxOpenFile1.FileDefined = false;
            this.textBoxOpenFile1.FileName = null;
            this.textBoxOpenFile1.Filter = "Todos los Archivos (*.*)|*.*";
            this.textBoxOpenFile1.Instance = Infrastructure.WinForms.Controls.TextBoxOpenFile.InstanceEntity.Unchanged;
            this.textBoxOpenFile1.Location = new System.Drawing.Point(153, 3);
            this.textBoxOpenFile1.LongitudAceptada = 0;
            this.textBoxOpenFile1.Name = "textBoxOpenFile1";
            this.textBoxOpenFile1.NSFileTamañoMax = 0D;
            this.textBoxOpenFile1.NSValidateFileTamaño = false;
            this.textBoxOpenFile1.Size = new System.Drawing.Size(559, 20);
            this.textBoxOpenFile1.TabIndex = 96;
            // 
            // DOC000LView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.panelCaption4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.panelCaption3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelCaption2);
            this.Controls.Add(this.pnBotones);
            this.Controls.Add(this.TitleView);
            this.Name = "DOC000LView";
            this.Size = new System.Drawing.Size(1016, 434);
            this.pnBotones.ResumeLayout(false);
            this.pnBotones.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            this.ResumeLayout(false);

      }

      #endregion

      private Infrastructure.WinForms.Controls.FormTitle TitleView;
      private System.Windows.Forms.Panel pnBotones;
      private System.Windows.Forms.Button btnBuscar;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.Button btnDeshacer;
      private System.Windows.Forms.Button btnExportar;
      private System.Windows.Forms.Button btnImportar;
      private System.Windows.Forms.Label label1;
      private Controls.Entidad AyudaEntidadLinea;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label lblArchivo;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private Telerik.WinControls.UI.MasterGridViewTemplate grdItemsDetalle;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption4;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private Controls.Entidad AyudaHBL;
      private Infrastructure.WinForms.Controls.MaskDateTime CCOT_FecDesde;
      private Infrastructure.WinForms.Controls.MaskDateTime maskDateTime1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private Infrastructure.WinForms.Controls.TextBoxOpenFile textBoxOpenFile1;
   }
}
