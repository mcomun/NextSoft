namespace Delfin.Logistico
{
   partial class PRO007MView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PRO007MView));
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnSalir = new System.Windows.Forms.Button();
         this.btnBuscarTarja = new System.Windows.Forms.Button();
         this.btnBuscar = new System.Windows.Forms.Button();
         this.btnGuardar = new System.Windows.Forms.Button();
         this.PCEncabezado = new Infrastructure.WinFormsControls.PanelCaption();
         this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
         this.miniToolStrip = new System.Windows.Forms.BindingNavigator(this.components);
         this.TLPanelDatos = new System.Windows.Forms.TableLayoutPanel();
         this.txaSeries = new Delfin.Controls.Serie.SeriesLarge();
         this.label3 = new System.Windows.Forms.Label();
         this.txtPDOV_Numero = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.txtPDOV_Observaciones = new System.Windows.Forms.TextBox();
         this.CbTIPO_CodFPG = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.lblSERV_Notas = new System.Windows.Forms.Label();
         this.CbTIPO_CodMND = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.label4 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.DTPPDOV_FechaEmision = new System.Windows.Forms.DateTimePicker();
         this.DTPPDOV_FechaVcmto = new Infrastructure.WinFormsControls.MaskDateTime();
         this.label6 = new System.Windows.Forms.Label();
         this.CmbDOCV_Estado = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.PanelCliente = new System.Windows.Forms.Panel();
         this.AyudaENTC_Cliente = new Delfin.Controls.Entidad(this.components);
         this.lblENTC_Codigo = new System.Windows.Forms.Label();
         this.lblDOCV_TipoCambio = new System.Windows.Forms.Label();
         this.NUDPDOV_TipoCambio = new System.Windows.Forms.NumericUpDown();
         this.lblTIPE_Codigo = new System.Windows.Forms.Label();
         this.cmbTIPE_Codigo = new Delfin.Controls.ComboBoxTipoEntidad();
         this.PcDocVenta = new Infrastructure.WinFormsControls.PanelCaption();
         this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
         this.TabPageNotas = new Dotnetrix.Controls.TabPageEX();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.label11 = new System.Windows.Forms.Label();
         this.TxtDOCV_Notas = new System.Windows.Forms.TextBox();
         this.TabPageServicios = new Dotnetrix.Controls.TabPageEX();
         this.grdItemsServicios = new Telerik.WinControls.UI.RadGridView();
         this.navItems = new System.Windows.Forms.BindingNavigator(this.components);
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
         this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.TabDetalleDocVenta = new Dotnetrix.Controls.TabControlEX();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label5 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.label12 = new System.Windows.Forms.Label();
         this.txtSubTotal = new System.Windows.Forms.TextBox();
         this.txtIGV = new System.Windows.Forms.TextBox();
         this.txtTotal = new System.Windows.Forms.TextBox();
         this.lblLetras = new System.Windows.Forms.Label();
         this.panel3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.miniToolStrip)).BeginInit();
         this.TLPanelDatos.SuspendLayout();
         this.PanelCliente.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.NUDPDOV_TipoCambio)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
         this.TabPageNotas.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         this.TabPageServicios.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicios)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicios.MasterTemplate)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
         this.TabDetalleDocVenta.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel3
         // 
         this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
         this.panel3.Controls.Add(this.btnSalir);
         this.panel3.Controls.Add(this.btnBuscarTarja);
         this.panel3.Controls.Add(this.btnBuscar);
         this.panel3.Controls.Add(this.btnGuardar);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel3.Location = new System.Drawing.Point(0, 0);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(1084, 50);
         this.panel3.TabIndex = 0;
         // 
         // btnSalir
         // 
         this.btnSalir.AutoSize = true;
         this.btnSalir.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnSalir.ForeColor = System.Drawing.Color.Black;
         this.btnSalir.Image = global::Delfin.Logistico.Properties.Resources.undo;
         this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnSalir.Location = new System.Drawing.Point(240, 0);
         this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
         this.btnSalir.Name = "btnSalir";
         this.btnSalir.Size = new System.Drawing.Size(51, 50);
         this.btnSalir.TabIndex = 5;
         this.btnSalir.Text = "&Salir";
         this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnSalir.UseVisualStyleBackColor = true;
         // 
         // btnBuscarTarja
         // 
         this.btnBuscarTarja.AutoSize = true;
         this.btnBuscarTarja.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnBuscarTarja.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnBuscarTarja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnBuscarTarja.ForeColor = System.Drawing.Color.Black;
         this.btnBuscarTarja.Image = global::Delfin.Logistico.Properties.Resources.search;
         this.btnBuscarTarja.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnBuscarTarja.Location = new System.Drawing.Point(161, 0);
         this.btnBuscarTarja.Margin = new System.Windows.Forms.Padding(0);
         this.btnBuscarTarja.Name = "btnBuscarTarja";
         this.btnBuscarTarja.Size = new System.Drawing.Size(79, 50);
         this.btnBuscarTarja.TabIndex = 3;
         this.btnBuscarTarja.Text = "&Búscar Tarja";
         this.btnBuscarTarja.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnBuscarTarja.UseVisualStyleBackColor = true;
         // 
         // btnBuscar
         // 
         this.btnBuscar.AutoSize = true;
         this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnBuscar.ForeColor = System.Drawing.Color.Black;
         this.btnBuscar.Image = global::Delfin.Logistico.Properties.Resources.search;
         this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnBuscar.Location = new System.Drawing.Point(57, 0);
         this.btnBuscar.Margin = new System.Windows.Forms.Padding(0);
         this.btnBuscar.Name = "btnBuscar";
         this.btnBuscar.Size = new System.Drawing.Size(104, 50);
         this.btnBuscar.TabIndex = 2;
         this.btnBuscar.Text = "&Búscar Operación";
         this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnBuscar.UseVisualStyleBackColor = true;
         // 
         // btnGuardar
         // 
         this.btnGuardar.AutoSize = true;
         this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnGuardar.ForeColor = System.Drawing.Color.Black;
         this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
         this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnGuardar.Location = new System.Drawing.Point(0, 0);
         this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
         this.btnGuardar.Name = "btnGuardar";
         this.btnGuardar.Size = new System.Drawing.Size(57, 50);
         this.btnGuardar.TabIndex = 0;
         this.btnGuardar.Text = "&Guardar";
         this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnGuardar.UseVisualStyleBackColor = true;
         // 
         // PCEncabezado
         // 
         this.PCEncabezado.AllowActive = false;
         this.PCEncabezado.AntiAlias = false;
         this.PCEncabezado.Caption = "Datos Documentos de Venta";
         this.PCEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
         this.PCEncabezado.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.PCEncabezado.ForeColor = System.Drawing.Color.White;
         this.PCEncabezado.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.PCEncabezado.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.PCEncabezado.Location = new System.Drawing.Point(0, 50);
         this.PCEncabezado.Name = "PCEncabezado";
         this.PCEncabezado.Size = new System.Drawing.Size(1084, 26);
         this.PCEncabezado.TabIndex = 1;
         // 
         // errorProvider1
         // 
         this.errorProvider1.ContainerControl = this;
         // 
         // miniToolStrip
         // 
         this.miniToolStrip.AddNewItem = null;
         this.miniToolStrip.AutoSize = false;
         this.miniToolStrip.BackColor = System.Drawing.Color.SteelBlue;
         this.miniToolStrip.CanOverflow = false;
         this.miniToolStrip.CountItem = null;
         this.miniToolStrip.DeleteItem = null;
         this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
         this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
         this.miniToolStrip.MoveFirstItem = null;
         this.miniToolStrip.MoveLastItem = null;
         this.miniToolStrip.MoveNextItem = null;
         this.miniToolStrip.MovePreviousItem = null;
         this.miniToolStrip.Name = "miniToolStrip";
         this.miniToolStrip.Padding = new System.Windows.Forms.Padding(3);
         this.miniToolStrip.PositionItem = null;
         this.miniToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
         this.miniToolStrip.Size = new System.Drawing.Size(875, 29);
         this.miniToolStrip.TabIndex = 3;
         // 
         // TLPanelDatos
         // 
         this.TLPanelDatos.AutoSize = true;
         this.TLPanelDatos.BackColor = System.Drawing.Color.LightSteelBlue;
         this.TLPanelDatos.ColumnCount = 12;
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.TLPanelDatos.Controls.Add(this.txaSeries, 0, 0);
         this.TLPanelDatos.Controls.Add(this.label3, 6, 0);
         this.TLPanelDatos.Controls.Add(this.txtPDOV_Numero, 7, 0);
         this.TLPanelDatos.Controls.Add(this.label1, 0, 4);
         this.TLPanelDatos.Controls.Add(this.txtPDOV_Observaciones, 1, 4);
         this.TLPanelDatos.Controls.Add(this.CbTIPO_CodFPG, 4, 3);
         this.TLPanelDatos.Controls.Add(this.lblSERV_Notas, 3, 3);
         this.TLPanelDatos.Controls.Add(this.CbTIPO_CodMND, 1, 3);
         this.TLPanelDatos.Controls.Add(this.label4, 0, 3);
         this.TLPanelDatos.Controls.Add(this.label8, 0, 1);
         this.TLPanelDatos.Controls.Add(this.label7, 3, 1);
         this.TLPanelDatos.Controls.Add(this.DTPPDOV_FechaEmision, 1, 1);
         this.TLPanelDatos.Controls.Add(this.DTPPDOV_FechaVcmto, 4, 1);
         this.TLPanelDatos.Controls.Add(this.label6, 6, 1);
         this.TLPanelDatos.Controls.Add(this.CmbDOCV_Estado, 7, 1);
         this.TLPanelDatos.Controls.Add(this.PanelCliente, 4, 2);
         this.TLPanelDatos.Controls.Add(this.lblENTC_Codigo, 3, 2);
         this.TLPanelDatos.Controls.Add(this.lblDOCV_TipoCambio, 6, 3);
         this.TLPanelDatos.Controls.Add(this.NUDPDOV_TipoCambio, 7, 3);
         this.TLPanelDatos.Controls.Add(this.lblTIPE_Codigo, 0, 2);
         this.TLPanelDatos.Controls.Add(this.cmbTIPE_Codigo, 1, 2);
         this.TLPanelDatos.Dock = System.Windows.Forms.DockStyle.Top;
         this.TLPanelDatos.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.TLPanelDatos.Location = new System.Drawing.Point(0, 76);
         this.TLPanelDatos.Name = "TLPanelDatos";
         this.TLPanelDatos.RowCount = 5;
         this.TLPanelDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.TLPanelDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.TLPanelDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.TLPanelDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.TLPanelDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.TLPanelDatos.Size = new System.Drawing.Size(1084, 135);
         this.TLPanelDatos.TabIndex = 2;
         // 
         // txaSeries
         // 
         this.txaSeries.cmbSERI_Serie_Enabled = false;
         this.txaSeries.cmbTIPO_CodTDO_Enabled = true;
         this.TLPanelDatos.SetColumnSpan(this.txaSeries, 5);
         this.txaSeries.ListSeries = null;
         this.txaSeries.ListTiposTDO = null;
         this.txaSeries.Location = new System.Drawing.Point(0, 0);
         this.txaSeries.Margin = new System.Windows.Forms.Padding(0);
         this.txaSeries.Name = "txaSeries";
         this.txaSeries.SelectedItem = null;
         this.txaSeries.SelectedItemTipoTDO = null;
         this.txaSeries.Size = new System.Drawing.Size(715, 27);
         this.txaSeries.TabIndex = 0;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(740, 7);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(102, 13);
         this.label3.TabIndex = 1;
         this.label3.Text = "Número Factura:";
         // 
         // txtPDOV_Numero
         // 
         this.txtPDOV_Numero.Enabled = false;
         this.txtPDOV_Numero.Location = new System.Drawing.Point(883, 3);
         this.txtPDOV_Numero.MaxLength = 20;
         this.txtPDOV_Numero.Name = "txtPDOV_Numero";
         this.txtPDOV_Numero.ReadOnly = true;
         this.txtPDOV_Numero.Size = new System.Drawing.Size(194, 20);
         this.txtPDOV_Numero.TabIndex = 2;
         this.txtPDOV_Numero.Tag = "";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 115);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(91, 13);
         this.label1.TabIndex = 19;
         this.label1.Text = "Observaciones";
         // 
         // txtPDOV_Observaciones
         // 
         this.TLPanelDatos.SetColumnSpan(this.txtPDOV_Observaciones, 4);
         this.txtPDOV_Observaciones.Location = new System.Drawing.Point(153, 111);
         this.txtPDOV_Observaciones.MaxLength = 1000;
         this.txtPDOV_Observaciones.Multiline = true;
         this.txtPDOV_Observaciones.Name = "txtPDOV_Observaciones";
         this.txtPDOV_Observaciones.Size = new System.Drawing.Size(559, 20);
         this.txtPDOV_Observaciones.TabIndex = 20;
         this.txtPDOV_Observaciones.Tag = "";
         // 
         // CbTIPO_CodFPG
         // 
         this.CbTIPO_CodFPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbTIPO_CodFPG.FormattingEnabled = true;
         this.CbTIPO_CodFPG.Location = new System.Drawing.Point(518, 84);
         this.CbTIPO_CodFPG.Name = "CbTIPO_CodFPG";
         this.CbTIPO_CodFPG.Session = null;
         this.CbTIPO_CodFPG.Size = new System.Drawing.Size(194, 21);
         this.CbTIPO_CodFPG.TabIndex = 16;
         this.CbTIPO_CodFPG.Tag = "TIPO_CodFPGMSGERROR";
         this.CbTIPO_CodFPG.TiposSelectedItem = null;
         this.CbTIPO_CodFPG.TiposSelectedValue = null;
         this.CbTIPO_CodFPG.TiposTitulo = null;
         // 
         // lblSERV_Notas
         // 
         this.lblSERV_Notas.AutoSize = true;
         this.lblSERV_Notas.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblSERV_Notas.Location = new System.Drawing.Point(375, 88);
         this.lblSERV_Notas.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblSERV_Notas.Name = "lblSERV_Notas";
         this.lblSERV_Notas.Size = new System.Drawing.Size(98, 13);
         this.lblSERV_Notas.TabIndex = 15;
         this.lblSERV_Notas.Text = "Forma de Pago:";
         // 
         // CbTIPO_CodMND
         // 
         this.CbTIPO_CodMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbTIPO_CodMND.FormattingEnabled = true;
         this.CbTIPO_CodMND.Location = new System.Drawing.Point(153, 84);
         this.CbTIPO_CodMND.Name = "CbTIPO_CodMND";
         this.CbTIPO_CodMND.Session = null;
         this.CbTIPO_CodMND.Size = new System.Drawing.Size(194, 21);
         this.CbTIPO_CodMND.TabIndex = 14;
         this.CbTIPO_CodMND.Tag = "TIPO_CodMNDMSGERROR";
         this.CbTIPO_CodMND.TiposSelectedItem = null;
         this.CbTIPO_CodMND.TiposSelectedValue = null;
         this.CbTIPO_CodMND.TiposTitulo = null;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(10, 88);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(56, 13);
         this.label4.TabIndex = 13;
         this.label4.Text = "Moneda:";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label8.Location = new System.Drawing.Point(10, 34);
         this.label8.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(111, 13);
         this.label8.TabIndex = 3;
         this.label8.Text = "Fecha de Emisión:";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label7.Location = new System.Drawing.Point(375, 34);
         this.label7.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(118, 13);
         this.label7.TabIndex = 5;
         this.label7.Text = "Fecha Vencimiento:";
         // 
         // DTPPDOV_FechaEmision
         // 
         this.DTPPDOV_FechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.DTPPDOV_FechaEmision.Location = new System.Drawing.Point(153, 30);
         this.DTPPDOV_FechaEmision.Name = "DTPPDOV_FechaEmision";
         this.DTPPDOV_FechaEmision.Size = new System.Drawing.Size(194, 20);
         this.DTPPDOV_FechaEmision.TabIndex = 4;
         this.DTPPDOV_FechaEmision.Tag = "DOCV_FechaEmisionMSGERROR";
         this.DTPPDOV_FechaEmision.ValueChanged += new System.EventHandler(this.DTPPDOV_FechaEmision_ValueChanged);
         // 
         // DTPPDOV_FechaVcmto
         // 
         this.DTPPDOV_FechaVcmto.Location = new System.Drawing.Point(518, 30);
         this.DTPPDOV_FechaVcmto.MinimumSize = new System.Drawing.Size(100, 22);
         this.DTPPDOV_FechaVcmto.Name = "DTPPDOV_FechaVcmto";
         this.DTPPDOV_FechaVcmto.NSActiveMouse = false;
         this.DTPPDOV_FechaVcmto.NSActiveMsgFecha = false;
         this.DTPPDOV_FechaVcmto.NSChangeDate = true;
         this.DTPPDOV_FechaVcmto.NSDigitos = 4;
         this.DTPPDOV_FechaVcmto.NSFecha = null;
         this.DTPPDOV_FechaVcmto.NSSetDateNow = false;
         this.DTPPDOV_FechaVcmto.Size = new System.Drawing.Size(194, 22);
         this.DTPPDOV_FechaVcmto.TabIndex = 6;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(740, 34);
         this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(50, 13);
         this.label6.TabIndex = 7;
         this.label6.Text = "Estado:";
         // 
         // CmbDOCV_Estado
         // 
         this.CmbDOCV_Estado.ConstantesSelectedItem = null;
         this.CmbDOCV_Estado.ConstantesSelectedValue = null;
         this.CmbDOCV_Estado.ConstantesTitulo = null;
         this.CmbDOCV_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CmbDOCV_Estado.FormattingEnabled = true;
         this.CmbDOCV_Estado.Location = new System.Drawing.Point(883, 30);
         this.CmbDOCV_Estado.Name = "CmbDOCV_Estado";
         this.CmbDOCV_Estado.Session = null;
         this.CmbDOCV_Estado.Size = new System.Drawing.Size(194, 21);
         this.CmbDOCV_Estado.TabIndex = 8;
         this.CmbDOCV_Estado.Tag = "DOCV_EstadoMSGERROR";
         // 
         // PanelCliente
         // 
         this.TLPanelDatos.SetColumnSpan(this.PanelCliente, 4);
         this.PanelCliente.Controls.Add(this.AyudaENTC_Cliente);
         this.PanelCliente.Location = new System.Drawing.Point(518, 57);
         this.PanelCliente.Name = "PanelCliente";
         this.PanelCliente.Size = new System.Drawing.Size(559, 21);
         this.PanelCliente.TabIndex = 12;
         this.PanelCliente.Tag = "ENTC_CodigoMSGERROR";
         // 
         // AyudaENTC_Cliente
         // 
         this.AyudaENTC_Cliente.ActivarAyudaAuto = false;
         this.AyudaENTC_Cliente.ContainerService = null;
         this.AyudaENTC_Cliente.EnabledAyudaButton = true;
         this.AyudaENTC_Cliente.Location = new System.Drawing.Point(3, 1);
         this.AyudaENTC_Cliente.LongitudAceptada = 0;
         this.AyudaENTC_Cliente.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.AyudaENTC_Cliente.Name = "AyudaENTC_Cliente";
         this.AyudaENTC_Cliente.RellenaCeros = false;
         this.AyudaENTC_Cliente.Size = new System.Drawing.Size(552, 20);
         this.AyudaENTC_Cliente.TabIndex = 0;
         this.AyudaENTC_Cliente.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.AyudaENTC_Cliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
         this.AyudaENTC_Cliente.UsarTipoEntidad = true;
         this.AyudaENTC_Cliente.Value = null;
         // 
         // lblENTC_Codigo
         // 
         this.lblENTC_Codigo.AutoSize = true;
         this.lblENTC_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_Codigo.Location = new System.Drawing.Point(375, 61);
         this.lblENTC_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENTC_Codigo.Name = "lblENTC_Codigo";
         this.lblENTC_Codigo.Size = new System.Drawing.Size(58, 13);
         this.lblENTC_Codigo.TabIndex = 11;
         this.lblENTC_Codigo.Text = "Entidad :";
         // 
         // lblDOCV_TipoCambio
         // 
         this.lblDOCV_TipoCambio.AutoSize = true;
         this.lblDOCV_TipoCambio.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblDOCV_TipoCambio.Location = new System.Drawing.Point(740, 88);
         this.lblDOCV_TipoCambio.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblDOCV_TipoCambio.Name = "lblDOCV_TipoCambio";
         this.lblDOCV_TipoCambio.Size = new System.Drawing.Size(84, 13);
         this.lblDOCV_TipoCambio.TabIndex = 17;
         this.lblDOCV_TipoCambio.Text = "Tipo Cambio:";
         // 
         // NUDPDOV_TipoCambio
         // 
         this.NUDPDOV_TipoCambio.DecimalPlaces = 4;
         this.NUDPDOV_TipoCambio.Location = new System.Drawing.Point(883, 84);
         this.NUDPDOV_TipoCambio.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            262144});
         this.NUDPDOV_TipoCambio.Name = "NUDPDOV_TipoCambio";
         this.NUDPDOV_TipoCambio.Size = new System.Drawing.Size(194, 20);
         this.NUDPDOV_TipoCambio.TabIndex = 18;
         this.NUDPDOV_TipoCambio.Tag = "DOCV_TipoCambioMSGERROR";
         this.NUDPDOV_TipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // lblTIPE_Codigo
         // 
         this.lblTIPE_Codigo.AutoSize = true;
         this.lblTIPE_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPE_Codigo.Location = new System.Drawing.Point(10, 61);
         this.lblTIPE_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPE_Codigo.Name = "lblTIPE_Codigo";
         this.lblTIPE_Codigo.Size = new System.Drawing.Size(104, 13);
         this.lblTIPE_Codigo.TabIndex = 9;
         this.lblTIPE_Codigo.Text = "Tipo de Entidad :";
         // 
         // cmbTIPE_Codigo
         // 
         this.cmbTIPE_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPE_Codigo.FormattingEnabled = true;
         this.cmbTIPE_Codigo.Location = new System.Drawing.Point(153, 57);
         this.cmbTIPE_Codigo.Name = "cmbTIPE_Codigo";
         this.cmbTIPE_Codigo.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPE_Codigo.TabIndex = 10;
         this.cmbTIPE_Codigo.Tag = "TIPE_CodigoMSGERROR";
         this.cmbTIPE_Codigo.TipoEntidadSelectedItem = null;
         this.cmbTIPE_Codigo.TipoEntidadSelectedValue = null;
         this.cmbTIPE_Codigo.TiposTitulo = null;
         // 
         // PcDocVenta
         // 
         this.PcDocVenta.AllowActive = false;
         this.PcDocVenta.AntiAlias = false;
         this.PcDocVenta.Caption = "Detalle  Documentos de Venta";
         this.PcDocVenta.Dock = System.Windows.Forms.DockStyle.Top;
         this.PcDocVenta.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.PcDocVenta.ForeColor = System.Drawing.Color.White;
         this.PcDocVenta.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.PcDocVenta.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.PcDocVenta.Location = new System.Drawing.Point(0, 211);
         this.PcDocVenta.Name = "PcDocVenta";
         this.PcDocVenta.Size = new System.Drawing.Size(1084, 26);
         this.PcDocVenta.TabIndex = 3;
         // 
         // radGridView1
         // 
         this.radGridView1.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.radGridView1.Location = new System.Drawing.Point(0, 0);
         this.radGridView1.Name = "radGridView1";
         this.radGridView1.Size = new System.Drawing.Size(1014, 215);
         this.radGridView1.TabIndex = 9;
         this.radGridView1.TabStop = false;
         // 
         // TabPageNotas
         // 
         this.TabPageNotas.Controls.Add(this.tableLayoutPanel2);
         this.TabPageNotas.Location = new System.Drawing.Point(4, 25);
         this.TabPageNotas.Name = "TabPageNotas";
         this.TabPageNotas.Size = new System.Drawing.Size(1076, 238);
         this.TabPageNotas.TabIndex = 2;
         this.TabPageNotas.Text = "Notas";
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.AutoSize = true;
         this.tableLayoutPanel2.BackColor = System.Drawing.Color.LightSteelBlue;
         this.tableLayoutPanel2.ColumnCount = 2;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1016F));
         this.tableLayoutPanel2.Controls.Add(this.label11, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.TxtDOCV_Notas, 0, 1);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 3;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 179F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(1076, 238);
         this.tableLayoutPanel2.TabIndex = 9;
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.tableLayoutPanel2.SetColumnSpan(this.label11, 2);
         this.label11.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label11.Location = new System.Drawing.Point(10, 7);
         this.label11.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(39, 13);
         this.label11.TabIndex = 22;
         this.label11.Text = "Notas";
         // 
         // TxtDOCV_Notas
         // 
         this.TxtDOCV_Notas.AcceptsReturn = true;
         this.tableLayoutPanel2.SetColumnSpan(this.TxtDOCV_Notas, 2);
         this.TxtDOCV_Notas.Location = new System.Drawing.Point(3, 30);
         this.TxtDOCV_Notas.Multiline = true;
         this.TxtDOCV_Notas.Name = "TxtDOCV_Notas";
         this.tableLayoutPanel2.SetRowSpan(this.TxtDOCV_Notas, 2);
         this.TxtDOCV_Notas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.TxtDOCV_Notas.Size = new System.Drawing.Size(1011, 203);
         this.TxtDOCV_Notas.TabIndex = 23;
         // 
         // TabPageServicios
         // 
         this.TabPageServicios.Controls.Add(this.grdItemsServicios);
         this.TabPageServicios.Controls.Add(this.navItems);
         this.TabPageServicios.Location = new System.Drawing.Point(4, 25);
         this.TabPageServicios.Name = "TabPageServicios";
         this.TabPageServicios.Size = new System.Drawing.Size(1076, 238);
         this.TabPageServicios.TabIndex = 0;
         this.TabPageServicios.Text = "Servicios";
         // 
         // grdItemsServicios
         // 
         this.grdItemsServicios.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdItemsServicios.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItemsServicios.Location = new System.Drawing.Point(0, 0);
         this.grdItemsServicios.Name = "grdItemsServicios";
         this.grdItemsServicios.Size = new System.Drawing.Size(1076, 213);
         this.grdItemsServicios.TabIndex = 9;
         this.grdItemsServicios.TabStop = false;
         // 
         // navItems
         // 
         this.navItems.AddNewItem = null;
         this.navItems.BackColor = System.Drawing.Color.SteelBlue;
         this.navItems.CountItem = this.toolStripLabel1;
         this.navItems.DeleteItem = null;
         this.navItems.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.navItems.Location = new System.Drawing.Point(0, 213);
         this.navItems.MoveFirstItem = this.toolStripButton1;
         this.navItems.MoveLastItem = this.toolStripButton4;
         this.navItems.MoveNextItem = this.toolStripButton3;
         this.navItems.MovePreviousItem = this.toolStripButton2;
         this.navItems.Name = "navItems";
         this.navItems.PositionItem = this.toolStripTextBox1;
         this.navItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.navItems.Size = new System.Drawing.Size(1076, 25);
         this.navItems.TabIndex = 45;
         this.navItems.Text = "bindingNavigator1";
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(35, 22);
         this.toolStripLabel1.Text = "de {0}";
         this.toolStripLabel1.ToolTipText = "Número total de elementos";
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.RightToLeftAutoMirrorImage = true;
         this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
         this.toolStripButton1.Text = "Mover primero";
         // 
         // toolStripButton4
         // 
         this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
         this.toolStripButton4.Name = "toolStripButton4";
         this.toolStripButton4.RightToLeftAutoMirrorImage = true;
         this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
         this.toolStripButton4.Text = "Mover último";
         // 
         // toolStripButton3
         // 
         this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
         this.toolStripButton3.Name = "toolStripButton3";
         this.toolStripButton3.RightToLeftAutoMirrorImage = true;
         this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
         this.toolStripButton3.Text = "Mover siguiente";
         // 
         // toolStripButton2
         // 
         this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
         this.toolStripButton2.Name = "toolStripButton2";
         this.toolStripButton2.RightToLeftAutoMirrorImage = true;
         this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
         this.toolStripButton2.Text = "Mover anterior";
         // 
         // toolStripTextBox1
         // 
         this.toolStripTextBox1.AccessibleName = "Posición";
         this.toolStripTextBox1.AutoSize = false;
         this.toolStripTextBox1.Name = "toolStripTextBox1";
         this.toolStripTextBox1.Size = new System.Drawing.Size(50, 23);
         this.toolStripTextBox1.Text = "0";
         this.toolStripTextBox1.ToolTipText = "Posición actual";
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // bindingNavigatorSeparator2
         // 
         this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
         this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // TabDetalleDocVenta
         // 
         this.TabDetalleDocVenta.Controls.Add(this.TabPageServicios);
         this.TabDetalleDocVenta.Controls.Add(this.TabPageNotas);
         this.TabDetalleDocVenta.Dock = System.Windows.Forms.DockStyle.Top;
         this.TabDetalleDocVenta.Location = new System.Drawing.Point(0, 237);
         this.TabDetalleDocVenta.Name = "TabDetalleDocVenta";
         this.TabDetalleDocVenta.SelectedIndex = 0;
         this.TabDetalleDocVenta.SelectedTabColor = System.Drawing.Color.SteelBlue;
         this.TabDetalleDocVenta.Size = new System.Drawing.Size(1084, 267);
         this.TabDetalleDocVenta.TabColor = System.Drawing.Color.LightSteelBlue;
         this.TabDetalleDocVenta.TabIndex = 4;
         this.TabDetalleDocVenta.UseVisualStyles = false;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.AutoSize = true;
         this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue;
         this.tableLayoutPanel1.ColumnCount = 8;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 268F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
         this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.label2, 6, 0);
         this.tableLayoutPanel1.Controls.Add(this.label10, 6, 1);
         this.tableLayoutPanel1.Controls.Add(this.label12, 6, 2);
         this.tableLayoutPanel1.Controls.Add(this.txtSubTotal, 7, 0);
         this.tableLayoutPanel1.Controls.Add(this.txtIGV, 7, 1);
         this.tableLayoutPanel1.Controls.Add(this.txtTotal, 7, 2);
         this.tableLayoutPanel1.Controls.Add(this.lblLetras, 1, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 504);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 3;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(1084, 81);
         this.tableLayoutPanel1.TabIndex = 14;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(10, 7);
         this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(35, 13);
         this.label5.TabIndex = 0;
         this.label5.Text = "Son:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(813, 7);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(68, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Sub Total";
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label10.Location = new System.Drawing.Point(813, 34);
         this.label10.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(30, 13);
         this.label10.TabIndex = 4;
         this.label10.Text = "IGV";
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label12.Location = new System.Drawing.Point(813, 61);
         this.label12.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(40, 13);
         this.label12.TabIndex = 6;
         this.label12.Text = "Total";
         // 
         // txtSubTotal
         // 
         this.txtSubTotal.Enabled = false;
         this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtSubTotal.Location = new System.Drawing.Point(897, 3);
         this.txtSubTotal.Name = "txtSubTotal";
         this.txtSubTotal.ReadOnly = true;
         this.txtSubTotal.Size = new System.Drawing.Size(121, 20);
         this.txtSubTotal.TabIndex = 3;
         this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // txtIGV
         // 
         this.txtIGV.Enabled = false;
         this.txtIGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtIGV.Location = new System.Drawing.Point(897, 30);
         this.txtIGV.Name = "txtIGV";
         this.txtIGV.ReadOnly = true;
         this.txtIGV.Size = new System.Drawing.Size(121, 20);
         this.txtIGV.TabIndex = 5;
         this.txtIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // txtTotal
         // 
         this.txtTotal.Enabled = false;
         this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtTotal.Location = new System.Drawing.Point(897, 57);
         this.txtTotal.Name = "txtTotal";
         this.txtTotal.ReadOnly = true;
         this.txtTotal.Size = new System.Drawing.Size(121, 20);
         this.txtTotal.TabIndex = 7;
         this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // lblLetras
         // 
         this.tableLayoutPanel1.SetColumnSpan(this.lblLetras, 5);
         this.lblLetras.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblLetras.Location = new System.Drawing.Point(62, 7);
         this.lblLetras.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblLetras.Name = "lblLetras";
         this.lblLetras.Size = new System.Drawing.Size(660, 16);
         this.lblLetras.TabIndex = 1;
         // 
         // PRO007MView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(1084, 590);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.TabDetalleDocVenta);
         this.Controls.Add(this.PcDocVenta);
         this.Controls.Add(this.TLPanelDatos);
         this.Controls.Add(this.PCEncabezado);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PRO007MView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Facturación";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.miniToolStrip)).EndInit();
         this.TLPanelDatos.ResumeLayout(false);
         this.TLPanelDatos.PerformLayout();
         this.PanelCliente.ResumeLayout(false);
         this.PanelCliente.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.NUDPDOV_TipoCambio)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
         this.TabPageNotas.ResumeLayout(false);
         this.TabPageNotas.PerformLayout();
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.TabPageServicios.ResumeLayout(false);
         this.TabPageServicios.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicios.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicios)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
         this.TabDetalleDocVenta.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnGuardar;
      private Infrastructure.WinFormsControls.PanelCaption PCEncabezado;
      private System.Windows.Forms.ErrorProvider errorProvider1;
      private System.Windows.Forms.BindingNavigator miniToolStrip;
      
      private System.Windows.Forms.TableLayoutPanel TLPanelDatos;
      private System.Windows.Forms.Label lblENTC_Codigo;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Panel PanelCliente;
      private System.Windows.Forms.TextBox txtPDOV_Observaciones;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label lblDOCV_TipoCambio;
      private System.Windows.Forms.NumericUpDown NUDPDOV_TipoCambio;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox txtPDOV_Numero;
      private System.Windows.Forms.Label label7;
      private Infrastructure.WinFormsControls.MaskDateTime DTPPDOV_FechaVcmto;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label lblSERV_Notas;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.DateTimePicker DTPPDOV_FechaEmision;
      private Infrastructure.WinFormsControls.PanelCaption PcDocVenta;
      private Controls.Entidad AyudaENTC_Cliente;
      private Telerik.WinControls.UI.RadGridView radGridView1;
      private Controls.Tipos.ComboBoxTipos CbTIPO_CodFPG;
      private Controls.Tipos.ComboBoxTipos CbTIPO_CodMND;
      private Dotnetrix.Controls.TabControlEX TabDetalleDocVenta;
      private Dotnetrix.Controls.TabPageEX TabPageServicios;
      private Dotnetrix.Controls.TabPageEX TabPageNotas;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.TextBox TxtDOCV_Notas;
      private Telerik.WinControls.UI.RadGridView grdItemsServicios;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.TextBox txtSubTotal;
      private System.Windows.Forms.TextBox txtIGV;
      private System.Windows.Forms.TextBox txtTotal;
      private System.Windows.Forms.Label lblLetras;
      private Controls.Tipos.ComboBoxConstantes CmbDOCV_Estado;
      private System.Windows.Forms.Button btnBuscar;
      private System.Windows.Forms.Button btnBuscarTarja;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.BindingNavigator navItems;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.ToolStripButton toolStripButton2;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton toolStripButton3;
      private System.Windows.Forms.ToolStripButton toolStripButton4;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
      private System.Windows.Forms.Label lblTIPE_Codigo;
      private Controls.ComboBoxTipoEntidad cmbTIPE_Codigo;
      private Controls.Serie.SeriesLarge txaSeries;
   }
}