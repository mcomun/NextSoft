namespace Delfin.Comercial
{
   partial class CAJ016FacturacionMView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAJ016FacturacionMView));
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnSalir = new System.Windows.Forms.Button();
         this.btnGuardar = new System.Windows.Forms.Button();
         this.errorProviderCab_Cotizacion_OV = new System.Windows.Forms.ErrorProvider(this.components);
         this.btnDelServicio = new System.Windows.Forms.Button();
         this.btnAddServicio = new System.Windows.Forms.Button();
         this.errorProviderDet_Cotizacion_OV_Novedad = new System.Windows.Forms.ErrorProvider(this.components);
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.errorEventoTarea = new System.Windows.Forms.ErrorProvider(this.components);
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.lblTIPO_CODTDO = new System.Windows.Forms.Label();
         this.cmbTIPO_CodTDO = new System.Windows.Forms.ComboBox();
         this.lblFACT_SERIE = new System.Windows.Forms.Label();
         this.txtDOCV_Serie = new Infrastructure.WinForms.Controls.TextBoxAlfaNumerico();
         this.lblFACT_NUMERO = new System.Windows.Forms.Label();
         this.txtDOCV_Numero = new Infrastructure.WinForms.Controls.TextBoxAlfaNumerico();
         this.lblFACT_CODIGO = new System.Windows.Forms.Label();
         this.txtDOCV_Codigo = new System.Windows.Forms.TextBox();
         this.lblFACT_FECEMI = new System.Windows.Forms.Label();
         this.dtpDOCV_FechaEmision = new Infrastructure.WinForms.Controls.MaskTime();
         this.lblFACT_ESTADO = new System.Windows.Forms.Label();
         this.cmbDOCV_Estado = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
         this.lblTIPO_CODMND = new System.Windows.Forms.Label();
         this.cmbTIPO_CodMND = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.lblTIPE_Codigo = new System.Windows.Forms.Label();
         this.cmbTIPE_Codigo = new Delfin.Controls.ComboBoxTipoEntidad();
         this.lblDOCV_TipoCambio = new System.Windows.Forms.Label();
         this.txnDOCV_TipoCambio = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblENTC_Codigo = new System.Windows.Forms.Label();
         this.txaENTC_Codigo = new Delfin.Controls.EntidadDocIden();
         this.lblTIPO_CodFPG = new System.Windows.Forms.Label();
         this.cmbTIPO_CodFPG = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.lblENTC_DIRCLIENTE = new System.Windows.Forms.Label();
         this.txtENTC_DIRCLIENTE = new System.Windows.Forms.TextBox();
         this.panelCaption5 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.navItems = new System.Windows.Forms.BindingNavigator(this.components);
         this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
         this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
         this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.grdItemsServicio = new Telerik.WinControls.UI.RadGridView();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.txnFACT_MONTOINAFECTO = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblFACT_MONTOINAFECTO = new System.Windows.Forms.Label();
         this.txnFACT_MONTOIGV = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblFACT_MONTOIGV = new System.Windows.Forms.Label();
         this.txnFACT_MONTOTOTAL = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblFACT_MONTOTOTAL = new System.Windows.Forms.Label();
         this.lblFACT_GLOSA = new System.Windows.Forms.Label();
         this.txtFACT_GLOSA = new System.Windows.Forms.TextBox();
         this.panel3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).BeginInit();
         this.tableLayoutPanel2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
         this.navItems.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio.MasterTemplate)).BeginInit();
         this.tableLayoutPanel1.SuspendLayout();
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
         this.btnSalir.Image = global::Delfin.Comercial.Properties.Resources.undo;
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
         this.btnGuardar.Image = global::Delfin.Comercial.Properties.Resources.save;
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
         // btnDelServicio
         // 
         this.btnDelServicio.BackColor = System.Drawing.Color.Transparent;
         this.btnDelServicio.Image = global::Delfin.Comercial.Properties.Resources.delete1;
         this.btnDelServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnDelServicio.Location = new System.Drawing.Point(184, 212);
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
         this.btnAddServicio.Image = global::Delfin.Comercial.Properties.Resources.add16x16;
         this.btnAddServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnAddServicio.Location = new System.Drawing.Point(153, 212);
         this.btnAddServicio.Name = "btnAddServicio";
         this.btnAddServicio.Size = new System.Drawing.Size(25, 24);
         this.btnAddServicio.TabIndex = 5;
         this.btnAddServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnAddServicio, "Nuevo Servicio");
         this.btnAddServicio.UseVisualStyleBackColor = false;
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
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Datos Generales";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 50);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(1104, 26);
         this.panelCaption1.TabIndex = 1;
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.AutoSize = true;
         this.tableLayoutPanel2.ColumnCount = 10;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.Controls.Add(this.lblTIPO_CODTDO, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.cmbTIPO_CodTDO, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.lblFACT_SERIE, 3, 1);
         this.tableLayoutPanel2.Controls.Add(this.txtDOCV_Serie, 4, 1);
         this.tableLayoutPanel2.Controls.Add(this.lblFACT_NUMERO, 6, 1);
         this.tableLayoutPanel2.Controls.Add(this.txtDOCV_Numero, 7, 1);
         this.tableLayoutPanel2.Controls.Add(this.lblFACT_CODIGO, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.txtDOCV_Codigo, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.lblFACT_FECEMI, 3, 0);
         this.tableLayoutPanel2.Controls.Add(this.dtpDOCV_FechaEmision, 4, 0);
         this.tableLayoutPanel2.Controls.Add(this.lblFACT_ESTADO, 6, 0);
         this.tableLayoutPanel2.Controls.Add(this.cmbDOCV_Estado, 7, 0);
         this.tableLayoutPanel2.Controls.Add(this.lblTIPO_CODMND, 0, 2);
         this.tableLayoutPanel2.Controls.Add(this.cmbTIPO_CodMND, 1, 2);
         this.tableLayoutPanel2.Controls.Add(this.lblDOCV_TipoCambio, 3, 2);
         this.tableLayoutPanel2.Controls.Add(this.txnDOCV_TipoCambio, 4, 2);
         this.tableLayoutPanel2.Controls.Add(this.lblTIPE_Codigo, 0, 3);
         this.tableLayoutPanel2.Controls.Add(this.cmbTIPE_Codigo, 1, 3);
         this.tableLayoutPanel2.Controls.Add(this.lblENTC_Codigo, 3, 3);
         this.tableLayoutPanel2.Controls.Add(this.txaENTC_Codigo, 4, 3);
         this.tableLayoutPanel2.Controls.Add(this.lblTIPO_CodFPG, 6, 2);
         this.tableLayoutPanel2.Controls.Add(this.cmbTIPO_CodFPG, 7, 2);
         this.tableLayoutPanel2.Controls.Add(this.lblENTC_DIRCLIENTE, 0, 4);
         this.tableLayoutPanel2.Controls.Add(this.txtENTC_DIRCLIENTE, 1, 4);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 76);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 5;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(1104, 135);
         this.tableLayoutPanel2.TabIndex = 2;
         // 
         // lblTIPO_CODTDO
         // 
         this.lblTIPO_CODTDO.AutoSize = true;
         this.lblTIPO_CODTDO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPO_CODTDO.Location = new System.Drawing.Point(10, 34);
         this.lblTIPO_CODTDO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPO_CODTDO.Name = "lblTIPO_CODTDO";
         this.lblTIPO_CODTDO.Size = new System.Drawing.Size(105, 13);
         this.lblTIPO_CODTDO.TabIndex = 6;
         this.lblTIPO_CODTDO.Text = "Tipo Documento:";
         // 
         // cmbTIPO_CodTDO
         // 
         this.cmbTIPO_CodTDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodTDO.FormattingEnabled = true;
         this.cmbTIPO_CodTDO.Location = new System.Drawing.Point(153, 30);
         this.cmbTIPO_CodTDO.Name = "cmbTIPO_CodTDO";
         this.cmbTIPO_CodTDO.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodTDO.TabIndex = 7;
         this.cmbTIPO_CodTDO.Tag = "TIPO_CODTDOMSGERROR";
         // 
         // lblFACT_SERIE
         // 
         this.lblFACT_SERIE.AutoSize = true;
         this.lblFACT_SERIE.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFACT_SERIE.Location = new System.Drawing.Point(375, 34);
         this.lblFACT_SERIE.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblFACT_SERIE.Name = "lblFACT_SERIE";
         this.lblFACT_SERIE.Size = new System.Drawing.Size(111, 13);
         this.lblFACT_SERIE.TabIndex = 8;
         this.lblFACT_SERIE.Text = "Serie Documento:";
         // 
         // txtDOCV_Serie
         // 
         this.txtDOCV_Serie.Location = new System.Drawing.Point(518, 30);
         this.txtDOCV_Serie.LongitudAceptada = 0;
         this.txtDOCV_Serie.Name = "txtDOCV_Serie";
         this.txtDOCV_Serie.RellenaCeros = false;
         this.txtDOCV_Serie.Size = new System.Drawing.Size(194, 20);
         this.txtDOCV_Serie.TabIndex = 9;
         this.txtDOCV_Serie.Tag = "FACT_SERIEMSGERROR";
         this.txtDOCV_Serie.Tipo = Infrastructure.WinForms.Controls.TextBoxAlfaNumerico.TipoTextBoxAlfaNumerico.AlfaNumerico;
         // 
         // lblFACT_NUMERO
         // 
         this.lblFACT_NUMERO.AutoSize = true;
         this.lblFACT_NUMERO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFACT_NUMERO.Location = new System.Drawing.Point(740, 34);
         this.lblFACT_NUMERO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblFACT_NUMERO.Name = "lblFACT_NUMERO";
         this.lblFACT_NUMERO.Size = new System.Drawing.Size(126, 13);
         this.lblFACT_NUMERO.TabIndex = 10;
         this.lblFACT_NUMERO.Text = "Número Documento:";
         // 
         // txtDOCV_Numero
         // 
         this.txtDOCV_Numero.Location = new System.Drawing.Point(883, 30);
         this.txtDOCV_Numero.LongitudAceptada = 0;
         this.txtDOCV_Numero.Name = "txtDOCV_Numero";
         this.txtDOCV_Numero.RellenaCeros = false;
         this.txtDOCV_Numero.Size = new System.Drawing.Size(194, 20);
         this.txtDOCV_Numero.TabIndex = 11;
         this.txtDOCV_Numero.Tag = "FACT_NUMEROMSGERROR";
         this.txtDOCV_Numero.Tipo = Infrastructure.WinForms.Controls.TextBoxAlfaNumerico.TipoTextBoxAlfaNumerico.AlfaNumerico;
         // 
         // lblFACT_CODIGO
         // 
         this.lblFACT_CODIGO.AutoSize = true;
         this.lblFACT_CODIGO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFACT_CODIGO.Location = new System.Drawing.Point(10, 7);
         this.lblFACT_CODIGO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblFACT_CODIGO.Name = "lblFACT_CODIGO";
         this.lblFACT_CODIGO.Size = new System.Drawing.Size(52, 13);
         this.lblFACT_CODIGO.TabIndex = 0;
         this.lblFACT_CODIGO.Text = "Código:";
         // 
         // txtDOCV_Codigo
         // 
         this.txtDOCV_Codigo.Location = new System.Drawing.Point(153, 3);
         this.txtDOCV_Codigo.Name = "txtDOCV_Codigo";
         this.txtDOCV_Codigo.ReadOnly = true;
         this.txtDOCV_Codigo.Size = new System.Drawing.Size(194, 20);
         this.txtDOCV_Codigo.TabIndex = 1;
         this.txtDOCV_Codigo.Tag = "FACT_CODIGOMSGERROR";
         // 
         // lblFACT_FECEMI
         // 
         this.lblFACT_FECEMI.AutoSize = true;
         this.lblFACT_FECEMI.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFACT_FECEMI.Location = new System.Drawing.Point(375, 7);
         this.lblFACT_FECEMI.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblFACT_FECEMI.Name = "lblFACT_FECEMI";
         this.lblFACT_FECEMI.Size = new System.Drawing.Size(93, 13);
         this.lblFACT_FECEMI.TabIndex = 2;
         this.lblFACT_FECEMI.Tag = "";
         this.lblFACT_FECEMI.Text = "Fecha Emisión:";
         // 
         // dtpDOCV_FechaEmision
         // 
         this.dtpDOCV_FechaEmision.Location = new System.Drawing.Point(518, 3);
         this.dtpDOCV_FechaEmision.MinimumSize = new System.Drawing.Size(100, 22);
         this.dtpDOCV_FechaEmision.Name = "dtpDOCV_FechaEmision";
         this.dtpDOCV_FechaEmision.NSActiveMouse = false;
         this.dtpDOCV_FechaEmision.NSActiveMsgFecha = false;
         this.dtpDOCV_FechaEmision.NSChangeDate = true;
         this.dtpDOCV_FechaEmision.NSDigitos = 4;
         this.dtpDOCV_FechaEmision.NSFecha = null;
         this.dtpDOCV_FechaEmision.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.dtpDOCV_FechaEmision.NSSetDateNow = false;
         this.dtpDOCV_FechaEmision.Size = new System.Drawing.Size(125, 22);
         this.dtpDOCV_FechaEmision.TabIndex = 3;
         this.dtpDOCV_FechaEmision.Tag = "FACT_FECEMIMSGERROR";
         // 
         // lblFACT_ESTADO
         // 
         this.lblFACT_ESTADO.AutoSize = true;
         this.lblFACT_ESTADO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFACT_ESTADO.Location = new System.Drawing.Point(740, 7);
         this.lblFACT_ESTADO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblFACT_ESTADO.Name = "lblFACT_ESTADO";
         this.lblFACT_ESTADO.Size = new System.Drawing.Size(50, 13);
         this.lblFACT_ESTADO.TabIndex = 4;
         this.lblFACT_ESTADO.Text = "Estado:";
         // 
         // cmbDOCV_Estado
         // 
         this.cmbDOCV_Estado.ComboIntSelectedValue = null;
         this.cmbDOCV_Estado.ComboSelectedItem = null;
         this.cmbDOCV_Estado.ComboStrSelectedValue = null;
         this.cmbDOCV_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbDOCV_Estado.FormattingEnabled = true;
         this.cmbDOCV_Estado.Location = new System.Drawing.Point(883, 3);
         this.cmbDOCV_Estado.Name = "cmbDOCV_Estado";
         this.cmbDOCV_Estado.Size = new System.Drawing.Size(194, 21);
         this.cmbDOCV_Estado.TabIndex = 5;
         this.cmbDOCV_Estado.Tag = "FACT_ESTADOMSGERROR";
         // 
         // lblTIPO_CODMND
         // 
         this.lblTIPO_CODMND.AutoSize = true;
         this.lblTIPO_CODMND.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPO_CODMND.Location = new System.Drawing.Point(10, 61);
         this.lblTIPO_CODMND.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPO_CODMND.Name = "lblTIPO_CODMND";
         this.lblTIPO_CODMND.Size = new System.Drawing.Size(56, 13);
         this.lblTIPO_CODMND.TabIndex = 12;
         this.lblTIPO_CODMND.Text = "Moneda:";
         // 
         // cmbTIPO_CodMND
         // 
         this.cmbTIPO_CodMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodMND.FormattingEnabled = true;
         this.cmbTIPO_CodMND.Location = new System.Drawing.Point(153, 57);
         this.cmbTIPO_CodMND.Name = "cmbTIPO_CodMND";
         this.cmbTIPO_CodMND.Session = null;
         this.cmbTIPO_CodMND.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodMND.TabIndex = 13;
         this.cmbTIPO_CodMND.TiposSelectedItem = null;
         this.cmbTIPO_CodMND.TiposSelectedValue = null;
         this.cmbTIPO_CodMND.TiposTitulo = null;
         // 
         // lblTIPE_Codigo
         // 
         this.lblTIPE_Codigo.AutoSize = true;
         this.lblTIPE_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPE_Codigo.Location = new System.Drawing.Point(10, 88);
         this.lblTIPE_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPE_Codigo.Name = "lblTIPE_Codigo";
         this.lblTIPE_Codigo.Size = new System.Drawing.Size(86, 13);
         this.lblTIPE_Codigo.TabIndex = 18;
         this.lblTIPE_Codigo.Text = "Tipo Entidad :";
         // 
         // cmbTIPE_Codigo
         // 
         this.cmbTIPE_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPE_Codigo.FormattingEnabled = true;
         this.cmbTIPE_Codigo.Location = new System.Drawing.Point(153, 84);
         this.cmbTIPE_Codigo.Name = "cmbTIPE_Codigo";
         this.cmbTIPE_Codigo.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPE_Codigo.TabIndex = 19;
         this.cmbTIPE_Codigo.TipoEntidadSelectedItem = null;
         this.cmbTIPE_Codigo.TipoEntidadSelectedValue = null;
         this.cmbTIPE_Codigo.TiposTitulo = null;
         // 
         // lblDOCV_TipoCambio
         // 
         this.lblDOCV_TipoCambio.AutoSize = true;
         this.lblDOCV_TipoCambio.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblDOCV_TipoCambio.Location = new System.Drawing.Point(375, 61);
         this.lblDOCV_TipoCambio.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblDOCV_TipoCambio.Name = "lblDOCV_TipoCambio";
         this.lblDOCV_TipoCambio.Size = new System.Drawing.Size(88, 13);
         this.lblDOCV_TipoCambio.TabIndex = 14;
         this.lblDOCV_TipoCambio.Text = "Tipo Cambio :";
         // 
         // txnDOCV_TipoCambio
         // 
         this.txnDOCV_TipoCambio.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnDOCV_TipoCambio.Decimales = 3;
         this.txnDOCV_TipoCambio.Enteros = 9;
         this.txnDOCV_TipoCambio.Formato = "###,###,##0.000";
         this.txnDOCV_TipoCambio.Location = new System.Drawing.Point(518, 57);
         this.txnDOCV_TipoCambio.MaxLength = 14;
         this.txnDOCV_TipoCambio.Name = "txnDOCV_TipoCambio";
         this.txnDOCV_TipoCambio.Negativo = true;
         this.txnDOCV_TipoCambio.SinFormato = false;
         this.txnDOCV_TipoCambio.Size = new System.Drawing.Size(120, 20);
         this.txnDOCV_TipoCambio.TabIndex = 15;
         this.txnDOCV_TipoCambio.Tag = "FACT_TCCONTABLEMSGERROR";
         this.txnDOCV_TipoCambio.Text = "0.000";
         this.txnDOCV_TipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnDOCV_TipoCambio.Value = new decimal(new int[] {
            0,
            0,
            0,
            196608});
         // 
         // lblENTC_Codigo
         // 
         this.lblENTC_Codigo.AutoSize = true;
         this.lblENTC_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_Codigo.Location = new System.Drawing.Point(375, 88);
         this.lblENTC_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENTC_Codigo.Name = "lblENTC_Codigo";
         this.lblENTC_Codigo.Size = new System.Drawing.Size(52, 13);
         this.lblENTC_Codigo.TabIndex = 20;
         this.lblENTC_Codigo.Text = "Cliente:";
         // 
         // txaENTC_Codigo
         // 
         this.txaENTC_Codigo.BackColor = System.Drawing.Color.LightSteelBlue;
         this.txaENTC_Codigo.CrearNuevaEntidad = false;
         this.txaENTC_Codigo.Location = new System.Drawing.Point(515, 81);
         this.txaENTC_Codigo.Margin = new System.Windows.Forms.Padding(0);
         this.txaENTC_Codigo.MinimumSize = new System.Drawing.Size(565, 27);
         this.txaENTC_Codigo.Name = "txaENTC_Codigo";
         this.txaENTC_Codigo.Size = new System.Drawing.Size(565, 27);
         this.txaENTC_Codigo.SoloEntidad = false;
         this.txaENTC_Codigo.TabIndex = 21;
         this.txaENTC_Codigo.TagEntidad = null;
         this.txaENTC_Codigo.TiposEntidad = Delfin.Controls.TiposEntidad.TIPE_AgenciaAduanera;
         this.txaENTC_Codigo.txaENTC_DOCIDEN_Name = "txaENTC_DOCIDEN";
         this.txaENTC_Codigo.txaENTC_NOMCOMPLETO_Name = "txaENTC_NOMCOMPLETO";
         // 
         // lblTIPO_CodFPG
         // 
         this.lblTIPO_CodFPG.AutoSize = true;
         this.lblTIPO_CodFPG.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPO_CodFPG.Location = new System.Drawing.Point(740, 61);
         this.lblTIPO_CodFPG.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPO_CodFPG.Name = "lblTIPO_CodFPG";
         this.lblTIPO_CodFPG.Size = new System.Drawing.Size(100, 13);
         this.lblTIPO_CodFPG.TabIndex = 16;
         this.lblTIPO_CodFPG.Text = "Condición Pago:";
         // 
         // cmbTIPO_CodFPG
         // 
         this.cmbTIPO_CodFPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodFPG.FormattingEnabled = true;
         this.cmbTIPO_CodFPG.Location = new System.Drawing.Point(883, 57);
         this.cmbTIPO_CodFPG.Name = "cmbTIPO_CodFPG";
         this.cmbTIPO_CodFPG.Session = null;
         this.cmbTIPO_CodFPG.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodFPG.TabIndex = 17;
         this.cmbTIPO_CodFPG.TiposSelectedItem = null;
         this.cmbTIPO_CodFPG.TiposSelectedValue = null;
         this.cmbTIPO_CodFPG.TiposTitulo = null;
         // 
         // lblENTC_DIRCLIENTE
         // 
         this.lblENTC_DIRCLIENTE.AutoSize = true;
         this.lblENTC_DIRCLIENTE.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_DIRCLIENTE.Location = new System.Drawing.Point(10, 115);
         this.lblENTC_DIRCLIENTE.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENTC_DIRCLIENTE.Name = "lblENTC_DIRCLIENTE";
         this.lblENTC_DIRCLIENTE.Size = new System.Drawing.Size(133, 13);
         this.lblENTC_DIRCLIENTE.TabIndex = 22;
         this.lblENTC_DIRCLIENTE.Text = "Dirección Facturación:";
         // 
         // txtENTC_DIRCLIENTE
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.txtENTC_DIRCLIENTE, 7);
         this.txtENTC_DIRCLIENTE.Location = new System.Drawing.Point(153, 111);
         this.txtENTC_DIRCLIENTE.Name = "txtENTC_DIRCLIENTE";
         this.txtENTC_DIRCLIENTE.Size = new System.Drawing.Size(924, 20);
         this.txtENTC_DIRCLIENTE.TabIndex = 23;
         this.txtENTC_DIRCLIENTE.Tag = "ENTC_DIRCLIENTEMSGERROR";
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
         this.panelCaption5.Location = new System.Drawing.Point(0, 211);
         this.panelCaption5.Name = "panelCaption5";
         this.panelCaption5.Size = new System.Drawing.Size(1104, 27);
         this.panelCaption5.TabIndex = 3;
         // 
         // navItems
         // 
         this.navItems.AddNewItem = null;
         this.navItems.BackColor = System.Drawing.Color.LightSteelBlue;
         this.navItems.CountItem = this.bindingNavigatorCountItem1;
         this.navItems.DeleteItem = null;
         this.navItems.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.navItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorSeparator4});
         this.navItems.Location = new System.Drawing.Point(0, 455);
         this.navItems.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
         this.navItems.MoveLastItem = this.bindingNavigatorMoveLastItem1;
         this.navItems.MoveNextItem = this.bindingNavigatorMoveNextItem1;
         this.navItems.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
         this.navItems.Name = "navItems";
         this.navItems.PositionItem = this.bindingNavigatorPositionItem1;
         this.navItems.Size = new System.Drawing.Size(1104, 25);
         this.navItems.TabIndex = 5;
         this.navItems.Text = "bindingNavigator1";
         // 
         // bindingNavigatorCountItem1
         // 
         this.bindingNavigatorCountItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
         this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(37, 22);
         this.bindingNavigatorCountItem1.Text = "de {0}";
         this.bindingNavigatorCountItem1.ToolTipText = "Número total de elementos";
         // 
         // bindingNavigatorMoveLastItem1
         // 
         this.bindingNavigatorMoveLastItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
         this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
         this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMoveLastItem1.Text = "Mover último";
         // 
         // bindingNavigatorMoveNextItem1
         // 
         this.bindingNavigatorMoveNextItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
         this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
         this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMoveNextItem1.Text = "Mover siguiente";
         // 
         // bindingNavigatorSeparator2
         // 
         this.bindingNavigatorSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
         this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // bindingNavigatorPositionItem1
         // 
         this.bindingNavigatorPositionItem1.AccessibleName = "Posición";
         this.bindingNavigatorPositionItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorPositionItem1.AutoSize = false;
         this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
         this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 23);
         this.bindingNavigatorPositionItem1.Text = "0";
         this.bindingNavigatorPositionItem1.ToolTipText = "Posición actual";
         // 
         // bindingNavigatorSeparator3
         // 
         this.bindingNavigatorSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
         this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
         // 
         // bindingNavigatorMovePreviousItem1
         // 
         this.bindingNavigatorMovePreviousItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
         this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
         this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMovePreviousItem1.Text = "Mover anterior";
         // 
         // bindingNavigatorMoveFirstItem1
         // 
         this.bindingNavigatorMoveFirstItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
         this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
         this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMoveFirstItem1.Text = "Mover primero";
         // 
         // bindingNavigatorSeparator4
         // 
         this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
         this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
         // 
         // grdItemsServicio
         // 
         this.grdItemsServicio.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdItemsServicio.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItemsServicio.Location = new System.Drawing.Point(0, 238);
         this.grdItemsServicio.Margin = new System.Windows.Forms.Padding(3, 3, 18, 3);
         this.grdItemsServicio.Name = "grdItemsServicio";
         // 
         // 
         // 
         this.grdItemsServicio.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 26, 240, 150);
         this.grdItemsServicio.RootElement.MinSize = new System.Drawing.Size(0, 0);
         this.grdItemsServicio.Size = new System.Drawing.Size(1104, 217);
         this.grdItemsServicio.TabIndex = 4;
         this.grdItemsServicio.TabStop = false;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.AutoSize = true;
         this.tableLayoutPanel1.ColumnCount = 10;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.Controls.Add(this.txnFACT_MONTOINAFECTO, 7, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblFACT_MONTOINAFECTO, 6, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblFACT_GLOSA, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.txtFACT_GLOSA, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.lblFACT_MONTOIGV, 6, 1);
         this.tableLayoutPanel1.Controls.Add(this.txnFACT_MONTOIGV, 7, 1);
         this.tableLayoutPanel1.Controls.Add(this.txnFACT_MONTOTOTAL, 7, 2);
         this.tableLayoutPanel1.Controls.Add(this.lblFACT_MONTOTOTAL, 6, 2);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 480);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 3;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(1104, 81);
         this.tableLayoutPanel1.TabIndex = 6;
         // 
         // txnFACT_MONTOINAFECTO
         // 
         this.txnFACT_MONTOINAFECTO.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnFACT_MONTOINAFECTO.Decimales = 2;
         this.txnFACT_MONTOINAFECTO.Enteros = 9;
         this.txnFACT_MONTOINAFECTO.Formato = "###,###,##0.00";
         this.txnFACT_MONTOINAFECTO.Location = new System.Drawing.Point(883, 3);
         this.txnFACT_MONTOINAFECTO.MaxLength = 13;
         this.txnFACT_MONTOINAFECTO.Name = "txnFACT_MONTOINAFECTO";
         this.txnFACT_MONTOINAFECTO.Negativo = true;
         this.txnFACT_MONTOINAFECTO.ReadOnly = true;
         this.txnFACT_MONTOINAFECTO.SinFormato = false;
         this.txnFACT_MONTOINAFECTO.Size = new System.Drawing.Size(120, 20);
         this.txnFACT_MONTOINAFECTO.TabIndex = 3;
         this.txnFACT_MONTOINAFECTO.Tag = "FACT_MONTOINAFECTOMSGERROR";
         this.txnFACT_MONTOINAFECTO.Text = "0.00";
         this.txnFACT_MONTOINAFECTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnFACT_MONTOINAFECTO.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // lblFACT_MONTOINAFECTO
         // 
         this.lblFACT_MONTOINAFECTO.AutoSize = true;
         this.lblFACT_MONTOINAFECTO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFACT_MONTOINAFECTO.Location = new System.Drawing.Point(740, 7);
         this.lblFACT_MONTOINAFECTO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblFACT_MONTOINAFECTO.Name = "lblFACT_MONTOINAFECTO";
         this.lblFACT_MONTOINAFECTO.Size = new System.Drawing.Size(69, 13);
         this.lblFACT_MONTOINAFECTO.TabIndex = 2;
         this.lblFACT_MONTOINAFECTO.Text = "Sub Total :";
         // 
         // txnFACT_MONTOIGV
         // 
         this.txnFACT_MONTOIGV.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnFACT_MONTOIGV.Decimales = 2;
         this.txnFACT_MONTOIGV.Enteros = 9;
         this.txnFACT_MONTOIGV.Formato = "###,###,##0.00";
         this.txnFACT_MONTOIGV.Location = new System.Drawing.Point(883, 30);
         this.txnFACT_MONTOIGV.MaxLength = 13;
         this.txnFACT_MONTOIGV.Name = "txnFACT_MONTOIGV";
         this.txnFACT_MONTOIGV.Negativo = true;
         this.txnFACT_MONTOIGV.ReadOnly = true;
         this.txnFACT_MONTOIGV.SinFormato = false;
         this.txnFACT_MONTOIGV.Size = new System.Drawing.Size(120, 20);
         this.txnFACT_MONTOIGV.TabIndex = 7;
         this.txnFACT_MONTOIGV.Tag = "FACT_MONTOIGVMSGERROR";
         this.txnFACT_MONTOIGV.Text = "0.00";
         this.txnFACT_MONTOIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnFACT_MONTOIGV.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // lblFACT_MONTOIGV
         // 
         this.lblFACT_MONTOIGV.AutoSize = true;
         this.lblFACT_MONTOIGV.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFACT_MONTOIGV.Location = new System.Drawing.Point(740, 34);
         this.lblFACT_MONTOIGV.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblFACT_MONTOIGV.Name = "lblFACT_MONTOIGV";
         this.lblFACT_MONTOIGV.Size = new System.Drawing.Size(65, 13);
         this.lblFACT_MONTOIGV.TabIndex = 6;
         this.lblFACT_MONTOIGV.Text = "Total IGV:";
         // 
         // txnFACT_MONTOTOTAL
         // 
         this.txnFACT_MONTOTOTAL.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnFACT_MONTOTOTAL.Decimales = 2;
         this.txnFACT_MONTOTOTAL.Enteros = 9;
         this.txnFACT_MONTOTOTAL.Formato = "###,###,##0.00";
         this.txnFACT_MONTOTOTAL.Location = new System.Drawing.Point(883, 57);
         this.txnFACT_MONTOTOTAL.MaxLength = 13;
         this.txnFACT_MONTOTOTAL.Name = "txnFACT_MONTOTOTAL";
         this.txnFACT_MONTOTOTAL.Negativo = true;
         this.txnFACT_MONTOTOTAL.ReadOnly = true;
         this.txnFACT_MONTOTOTAL.SinFormato = false;
         this.txnFACT_MONTOTOTAL.Size = new System.Drawing.Size(120, 20);
         this.txnFACT_MONTOTOTAL.TabIndex = 9;
         this.txnFACT_MONTOTOTAL.Tag = "FACT_MONTOTOTALMSGERROR";
         this.txnFACT_MONTOTOTAL.Text = "0.00";
         this.txnFACT_MONTOTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnFACT_MONTOTOTAL.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // lblFACT_MONTOTOTAL
         // 
         this.lblFACT_MONTOTOTAL.AutoSize = true;
         this.lblFACT_MONTOTOTAL.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFACT_MONTOTOTAL.Location = new System.Drawing.Point(740, 61);
         this.lblFACT_MONTOTOTAL.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblFACT_MONTOTOTAL.Name = "lblFACT_MONTOTOTAL";
         this.lblFACT_MONTOTOTAL.Size = new System.Drawing.Size(77, 13);
         this.lblFACT_MONTOTOTAL.TabIndex = 8;
         this.lblFACT_MONTOTOTAL.Text = "Monto Total:";
         // 
         // lblFACT_GLOSA
         // 
         this.lblFACT_GLOSA.AutoSize = true;
         this.lblFACT_GLOSA.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFACT_GLOSA.Location = new System.Drawing.Point(10, 7);
         this.lblFACT_GLOSA.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblFACT_GLOSA.Name = "lblFACT_GLOSA";
         this.lblFACT_GLOSA.Size = new System.Drawing.Size(44, 13);
         this.lblFACT_GLOSA.TabIndex = 0;
         this.lblFACT_GLOSA.Text = "Glosa:";
         // 
         // txtFACT_GLOSA
         // 
         this.tableLayoutPanel1.SetColumnSpan(this.txtFACT_GLOSA, 5);
         this.txtFACT_GLOSA.Location = new System.Drawing.Point(3, 30);
         this.txtFACT_GLOSA.Multiline = true;
         this.txtFACT_GLOSA.Name = "txtFACT_GLOSA";
         this.tableLayoutPanel1.SetRowSpan(this.txtFACT_GLOSA, 2);
         this.txtFACT_GLOSA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.txtFACT_GLOSA.Size = new System.Drawing.Size(709, 48);
         this.txtFACT_GLOSA.TabIndex = 1;
         // 
         // CAJ016FacturacionMView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.CancelButton = this.btnSalir;
         this.ClientSize = new System.Drawing.Size(1104, 561);
         this.Controls.Add(this.btnDelServicio);
         this.Controls.Add(this.btnAddServicio);
         this.Controls.Add(this.grdItemsServicio);
         this.Controls.Add(this.navItems);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panelCaption5);
         this.Controls.Add(this.tableLayoutPanel2);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Name = "CAJ016FacturacionMView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Facturación Libre";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).EndInit();
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
         this.navItems.ResumeLayout(false);
         this.navItems.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio)).EndInit();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }



      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private System.Windows.Forms.ErrorProvider errorProviderCab_Cotizacion_OV;
      private System.Windows.Forms.Button btnDelServicio;
      private System.Windows.Forms.Button btnAddServicio;
      private System.Windows.Forms.ErrorProvider errorProviderDet_Cotizacion_OV_Novedad;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.ErrorProvider errorEventoTarea;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption5;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Label lblTIPO_CODTDO;
      private System.Windows.Forms.ComboBox cmbTIPO_CodTDO;
      private System.Windows.Forms.Label lblFACT_SERIE;
      private Infrastructure.WinForms.Controls.TextBoxAlfaNumerico txtDOCV_Serie;
      private System.Windows.Forms.Label lblFACT_NUMERO;
      private Infrastructure.WinForms.Controls.TextBoxAlfaNumerico txtDOCV_Numero;
      private System.Windows.Forms.Label lblFACT_CODIGO;
      private System.Windows.Forms.TextBox txtDOCV_Codigo;
      private System.Windows.Forms.Label lblFACT_FECEMI;
      private Infrastructure.WinForms.Controls.MaskTime dtpDOCV_FechaEmision;
      private System.Windows.Forms.Label lblFACT_ESTADO;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbDOCV_Estado;
      private System.Windows.Forms.Label lblTIPO_CODMND;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMND;
      private System.Windows.Forms.Label lblTIPE_Codigo;
      private Controls.ComboBoxTipoEntidad cmbTIPE_Codigo;
      private System.Windows.Forms.Label lblDOCV_TipoCambio;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnDOCV_TipoCambio;
      private System.Windows.Forms.Label lblENTC_Codigo;
      private Controls.EntidadDocIden txaENTC_Codigo;
      private System.Windows.Forms.Label lblTIPO_CodFPG;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodFPG;
      private System.Windows.Forms.Label lblENTC_DIRCLIENTE;
      private System.Windows.Forms.TextBox txtENTC_DIRCLIENTE;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private Telerik.WinControls.UI.RadGridView grdItemsServicio;
      private System.Windows.Forms.BindingNavigator navItems;
      private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
      private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnFACT_MONTOINAFECTO;
      private System.Windows.Forms.Label lblFACT_MONTOINAFECTO;
      private System.Windows.Forms.Label lblFACT_GLOSA;
      private System.Windows.Forms.TextBox txtFACT_GLOSA;
      private System.Windows.Forms.Label lblFACT_MONTOIGV;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnFACT_MONTOIGV;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnFACT_MONTOTOTAL;
      private System.Windows.Forms.Label lblFACT_MONTOTOTAL;
   }
}