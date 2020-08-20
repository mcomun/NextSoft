namespace Delfin.Principal
{
   partial class PRO005LView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PRO005LView));
            this.pnBotones = new System.Windows.Forms.Panel();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.TitleView = new Infrastructure.WinFormsControls.FormTitle();
            this.panelCaption1 = new Infrastructure.WinFormsControls.PanelCaption();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mdtFADesde = new Infrastructure.WinFormsControls.MaskDateTime();
            this.lblCONT_FecIni = new System.Windows.Forms.Label();
            this.mdtFecDesde = new Infrastructure.WinFormsControls.MaskDateTime();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mdtFecHasta = new Infrastructure.WinFormsControls.MaskDateTime();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AyudaEntidadCliente = new Delfin.Controls.Entidad(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtHBL = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mdtFAHasta = new Infrastructure.WinFormsControls.MaskDateTime();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AyudaEntidadLinea = new Delfin.Controls.Entidad(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.AyudaEntidadDepTmp = new Delfin.Controls.Entidad(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMBL = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtViaje = new System.Windows.Forms.TextBox();
            this.txaNave = new Delfin.Controls.AyudaNave();
            this.panelCaption2 = new Infrastructure.WinFormsControls.PanelCaption();
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            this.grdItemsDetalle = new Telerik.WinControls.UI.RadGridView();
            this.panelCaption3 = new Infrastructure.WinFormsControls.PanelCaption();
            this.pnBotones.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // pnBotones
            // 
            this.pnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnBotones.Controls.Add(this.btnAsignar);
            this.pnBotones.Controls.Add(this.btnDeshacer);
            this.pnBotones.Controls.Add(this.btnExportar);
            this.pnBotones.Controls.Add(this.btnBuscar);
            this.pnBotones.Controls.Add(this.btnForward);
            this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnBotones.Location = new System.Drawing.Point(0, 26);
            this.pnBotones.Name = "pnBotones";
            this.pnBotones.Size = new System.Drawing.Size(1016, 50);
            this.pnBotones.TabIndex = 1;
            // 
            // btnAsignar
            // 
            this.btnAsignar.AutoSize = true;
            this.btnAsignar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAsignar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignar.ForeColor = System.Drawing.Color.Black;
            this.btnAsignar.Image = global::Delfin.Principal.Properties.Resources.search;
            this.btnAsignar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAsignar.Location = new System.Drawing.Point(306, 0);
            this.btnAsignar.Margin = new System.Windows.Forms.Padding(0);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(127, 50);
            this.btnAsignar.TabIndex = 5;
            this.btnAsignar.Text = "&Asignar Dep. Temporal";
            this.btnAsignar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
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
            this.btnDeshacer.Location = new System.Drawing.Point(241, 0);
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
            this.btnExportar.Location = new System.Drawing.Point(183, 0);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(58, 50);
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
            this.btnBuscar.Location = new System.Drawing.Point(128, 0);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(55, 50);
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
            this.btnForward.Image = global::Delfin.Principal.Properties.Resources.copy;
            this.btnForward.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnForward.Location = new System.Drawing.Point(0, 0);
            this.btnForward.Margin = new System.Windows.Forms.Padding(0);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(128, 50);
            this.btnForward.TabIndex = 4;
            this.btnForward.Text = "&Cargar Datos OV";
            this.btnForward.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnForward.UseVisualStyleBackColor = true;
            // 
            // TitleView
            // 
            this.TitleView.AllowActive = false;
            this.TitleView.AntiAlias = false;
            this.TitleView.Caption = "DIRECCIONAMIENTO";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(1016, 26);
            this.TitleView.TabIndex = 0;
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
            this.panelCaption1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.mdtFADesde, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCONT_FecIni, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mdtFecDesde, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.AyudaEntidadCliente, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHBL, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.AyudaEntidadLinea, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.AyudaEntidadDepTmp, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMBL, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtViaje, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.txaNave, 5, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1016, 135);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // mdtFADesde
            // 
            this.mdtFADesde.Location = new System.Drawing.Point(153, 30);
            this.mdtFADesde.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFADesde.Name = "mdtFADesde";
            this.mdtFADesde.NSActiveMouse = false;
            this.mdtFADesde.NSActiveMsgFecha = false;
            this.mdtFADesde.NSChangeDate = true;
            this.mdtFADesde.NSDigitos = 4;
            this.mdtFADesde.NSFecha = null;
            this.mdtFADesde.NSSetDateNow = false;
            this.mdtFADesde.Size = new System.Drawing.Size(100, 22);
            this.mdtFADesde.TabIndex = 6;
            // 
            // lblCONT_FecIni
            // 
            this.lblCONT_FecIni.AutoSize = true;
            this.lblCONT_FecIni.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONT_FecIni.Location = new System.Drawing.Point(10, 7);
            this.lblCONT_FecIni.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONT_FecIni.Name = "lblCONT_FecIni";
            this.lblCONT_FecIni.Size = new System.Drawing.Size(133, 13);
            this.lblCONT_FecIni.TabIndex = 0;
            this.lblCONT_FecIni.Text = "Fecha Emisión Desde:";
            // 
            // mdtFecDesde
            // 
            this.mdtFecDesde.Location = new System.Drawing.Point(153, 3);
            this.mdtFecDesde.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFecDesde.Name = "mdtFecDesde";
            this.mdtFecDesde.NSActiveMouse = false;
            this.mdtFecDesde.NSActiveMsgFecha = false;
            this.mdtFecDesde.NSChangeDate = true;
            this.mdtFecDesde.NSDigitos = 4;
            this.mdtFecDesde.NSFecha = null;
            this.mdtFecDesde.NSSetDateNow = false;
            this.mdtFecDesde.Size = new System.Drawing.Size(100, 22);
            this.mdtFecDesde.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mdtFecHasta);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(250, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 27);
            this.panel1.TabIndex = 2;
            // 
            // mdtFecHasta
            // 
            this.mdtFecHasta.Location = new System.Drawing.Point(88, 2);
            this.mdtFecHasta.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFecHasta.Name = "mdtFecHasta";
            this.mdtFecHasta.NSActiveMouse = false;
            this.mdtFecHasta.NSActiveMsgFecha = false;
            this.mdtFecHasta.NSChangeDate = true;
            this.mdtFecHasta.NSDigitos = 4;
            this.mdtFecHasta.NSFecha = null;
            this.mdtFecHasta.NSSetDateNow = false;
            this.mdtFecHasta.Size = new System.Drawing.Size(109, 22);
            this.mdtFecHasta.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hasta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(475, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "HBL :";
            // 
            // AyudaEntidadCliente
            // 
            this.AyudaEntidadCliente.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.AyudaEntidadCliente, 2);
            this.AyudaEntidadCliente.ContainerService = null;
            this.AyudaEntidadCliente.EnabledAyudaButton = true;
            this.AyudaEntidadCliente.Location = new System.Drawing.Point(153, 57);
            this.AyudaEntidadCliente.LongitudAceptada = 0;
            this.AyudaEntidadCliente.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.AyudaEntidadCliente.Name = "AyudaEntidadCliente";
            this.AyudaEntidadCliente.RellenaCeros = false;
            this.AyudaEntidadCliente.Size = new System.Drawing.Size(294, 20);
            this.AyudaEntidadCliente.TabIndex = 11;
            this.AyudaEntidadCliente.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.AyudaEntidadCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.AyudaEntidadCliente.UsarTipoEntidad = true;
            this.AyudaEntidadCliente.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cliente :";
            // 
            // txtHBL
            // 
            this.txtHBL.Location = new System.Drawing.Point(618, 3);
            this.txtHBL.MaxLength = 20;
            this.txtHBL.Name = "txtHBL";
            this.txtHBL.Size = new System.Drawing.Size(294, 20);
            this.txtHBL.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mdtFAHasta);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(250, 27);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 27);
            this.panel2.TabIndex = 7;
            // 
            // mdtFAHasta
            // 
            this.mdtFAHasta.Location = new System.Drawing.Point(88, 2);
            this.mdtFAHasta.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFAHasta.Name = "mdtFAHasta";
            this.mdtFAHasta.NSActiveMouse = false;
            this.mdtFAHasta.NSActiveMsgFecha = false;
            this.mdtFAHasta.NSChangeDate = true;
            this.mdtFAHasta.NSDigitos = 4;
            this.mdtFAHasta.NSFecha = null;
            this.mdtFAHasta.NSSetDateNow = false;
            this.mdtFAHasta.Size = new System.Drawing.Size(109, 22);
            this.mdtFAHasta.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha Arribo Desde:";
            // 
            // AyudaEntidadLinea
            // 
            this.AyudaEntidadLinea.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.AyudaEntidadLinea, 2);
            this.AyudaEntidadLinea.ContainerService = null;
            this.AyudaEntidadLinea.EnabledAyudaButton = true;
            this.AyudaEntidadLinea.Location = new System.Drawing.Point(153, 84);
            this.AyudaEntidadLinea.LongitudAceptada = 0;
            this.AyudaEntidadLinea.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.AyudaEntidadLinea.Name = "AyudaEntidadLinea";
            this.AyudaEntidadLinea.RellenaCeros = false;
            this.AyudaEntidadLinea.Size = new System.Drawing.Size(294, 20);
            this.AyudaEntidadLinea.TabIndex = 15;
            this.AyudaEntidadLinea.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.AyudaEntidadLinea.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.AyudaEntidadLinea.UsarTipoEntidad = true;
            this.AyudaEntidadLinea.Value = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 88);
            this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Linea :";
            // 
            // AyudaEntidadDepTmp
            // 
            this.AyudaEntidadDepTmp.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.AyudaEntidadDepTmp, 2);
            this.AyudaEntidadDepTmp.ContainerService = null;
            this.AyudaEntidadDepTmp.EnabledAyudaButton = true;
            this.AyudaEntidadDepTmp.Location = new System.Drawing.Point(153, 111);
            this.AyudaEntidadDepTmp.LongitudAceptada = 0;
            this.AyudaEntidadDepTmp.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.AyudaEntidadDepTmp.Name = "AyudaEntidadDepTmp";
            this.AyudaEntidadDepTmp.RellenaCeros = false;
            this.AyudaEntidadDepTmp.Size = new System.Drawing.Size(294, 20);
            this.AyudaEntidadDepTmp.TabIndex = 19;
            this.AyudaEntidadDepTmp.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.AyudaEntidadDepTmp.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.AyudaEntidadDepTmp.UsarTipoEntidad = true;
            this.AyudaEntidadDepTmp.Value = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 115);
            this.label8.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Depósito Temporal :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(475, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nave:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(475, 34);
            this.label9.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "MBL :";
            // 
            // txtMBL
            // 
            this.txtMBL.Location = new System.Drawing.Point(618, 30);
            this.txtMBL.MaxLength = 20;
            this.txtMBL.Name = "txtMBL";
            this.txtMBL.Size = new System.Drawing.Size(294, 20);
            this.txtMBL.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(475, 88);
            this.label10.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Viaje:";
            // 
            // txtViaje
            // 
            this.txtViaje.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtViaje.Location = new System.Drawing.Point(618, 84);
            this.txtViaje.MaxLength = 30;
            this.txtViaje.Name = "txtViaje";
            this.txtViaje.Size = new System.Drawing.Size(294, 20);
            this.txtViaje.TabIndex = 17;
            // 
            // txaNave
            // 
            this.txaNave.ActivarAyudaAuto = false;
            this.txaNave.EnabledAyuda = true;
            this.txaNave.EnabledAyudaButton = true;
            this.txaNave.EsFiltro = false;
            this.txaNave.Location = new System.Drawing.Point(618, 57);
            this.txaNave.LongitudAceptada = 0;
            this.txaNave.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
            this.txaNave.Name = "txaNave";
            this.txaNave.RellenaCeros = false;
            this.txaNave.SelectedItem = null;
            this.txaNave.Size = new System.Drawing.Size(294, 20);
            this.txaNave.TabIndex = 20;
            this.txaNave.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
            this.txaNave.Value = null;
            // 
            // panelCaption2
            // 
            this.panelCaption2.AllowActive = false;
            this.panelCaption2.AntiAlias = false;
            this.panelCaption2.Caption = "Resultado Búsqueda";
            this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption2.Location = new System.Drawing.Point(0, 237);
            this.panelCaption2.Name = "panelCaption2";
            this.panelCaption2.Size = new System.Drawing.Size(1016, 26);
            this.panelCaption2.TabIndex = 4;
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Location = new System.Drawing.Point(0, 263);
            this.grdItems.Name = "grdItems";
            // 
            // 
            // 
            this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 263, 240, 150);
            this.grdItems.Size = new System.Drawing.Size(1016, 49);
            this.grdItems.TabIndex = 5;
            this.grdItems.TabStop = false;
            this.grdItems.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.dgvItems_RowFormatting);
            this.grdItems.ValueChanged += new System.EventHandler(this.grdItems_ValueChanged);
            // 
            // grdItemsDetalle
            // 
            this.grdItemsDetalle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItemsDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdItemsDetalle.Location = new System.Drawing.Point(0, 338);
            this.grdItemsDetalle.Name = "grdItemsDetalle";
            // 
            // 
            // 
            this.grdItemsDetalle.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 338, 240, 150);
            this.grdItemsDetalle.Size = new System.Drawing.Size(1016, 152);
            this.grdItemsDetalle.TabIndex = 7;
            this.grdItemsDetalle.TabStop = false;
            // 
            // panelCaption3
            // 
            this.panelCaption3.AllowActive = false;
            this.panelCaption3.AntiAlias = false;
            this.panelCaption3.Caption = "Detalles";
            this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption3.Location = new System.Drawing.Point(0, 312);
            this.panelCaption3.Name = "panelCaption3";
            this.panelCaption3.Size = new System.Drawing.Size(1016, 26);
            this.panelCaption3.TabIndex = 6;
            // 
            // PRO005LView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.panelCaption3);
            this.Controls.Add(this.grdItemsDetalle);
            this.Controls.Add(this.panelCaption2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.pnBotones);
            this.Controls.Add(this.TitleView);
            this.Name = "PRO005LView";
            this.Size = new System.Drawing.Size(1016, 490);
            this.pnBotones.ResumeLayout(false);
            this.pnBotones.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private Infrastructure.WinFormsControls.FormTitle TitleView;
      private System.Windows.Forms.Panel pnBotones;
      private System.Windows.Forms.Button btnDeshacer;
      private System.Windows.Forms.Button btnExportar;
      private System.Windows.Forms.Button btnBuscar;
      private System.Windows.Forms.Button btnForward;
      private Infrastructure.WinFormsControls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Panel panel1;
      private Infrastructure.WinFormsControls.PanelCaption panelCaption2;
      private System.Windows.Forms.Label lblCONT_FecIni;
      private Infrastructure.WinFormsControls.MaskDateTime mdtFecDesde;
      private Infrastructure.WinFormsControls.MaskDateTime mdtFecHasta;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label7;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private Controls.Entidad AyudaEntidadCliente;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox txtHBL;
      private System.Windows.Forms.Panel panel2;
      private Infrastructure.WinFormsControls.MaskDateTime mdtFAHasta;
      private System.Windows.Forms.Label label5;
      private Infrastructure.WinFormsControls.MaskDateTime mdtFADesde;
      private System.Windows.Forms.Label label3;
      private Controls.Entidad AyudaEntidadLinea;
      private System.Windows.Forms.Label label6;
      private Controls.Entidad AyudaEntidadDepTmp;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.TextBox txtMBL;
      private Telerik.WinControls.UI.RadGridView grdItemsDetalle;
      private Infrastructure.WinFormsControls.PanelCaption panelCaption3;
      private System.Windows.Forms.Button btnAsignar;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.TextBox txtViaje;
      private Controls.AyudaNave txaNave;
   }
}
