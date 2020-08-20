namespace Delfin.Principal
{
   partial class CAJ007ExportacionBancosMView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAJ007ExportacionBancosMView));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExportarTXT = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.errorProviderPlanillas = new System.Windows.Forms.ErrorProvider();
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.errorEventoTarea = new System.Windows.Forms.ErrorProvider();
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.navItems = new System.Windows.Forms.BindingNavigator();
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txnMonto = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTIPO_CodBCO = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPLAN_FechaEmision = new System.Windows.Forms.Label();
            this.cmbPLAN_Tipo = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblPLAN_Tipo = new System.Windows.Forms.Label();
            this.lblTIPO_CodMND = new System.Windows.Forms.Label();
            this.cmbTIPO_CodMND = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.lblCUBA_Codigo = new System.Windows.Forms.Label();
            this.txaCUBA_Codigo = new Delfin.Controls.CuentaBancaria();
            this.dtpPLAN_FechaEmision = new Infrastructure.WinForms.Controls.MaskTime();
            this.txtPLAN_Concepto = new System.Windows.Forms.TextBox();
            this.lblPLAN_Concepto = new System.Windows.Forms.Label();
            this.txtPLAN_Codigo = new System.Windows.Forms.TextBox();
            this.lblPLAN_Codigo = new System.Windows.Forms.Label();
            this.txnMOVI_TipoCambio = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.label5 = new System.Windows.Forms.Label();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tlpCBusqueda = new System.Windows.Forms.TableLayoutPanel();
            this.chkMostrarTodos = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkMostrarCtaCte = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkMostrarCtaInterbancaria = new System.Windows.Forms.CheckBox();
            this.pnlCBusqueda = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tblFiltroEB = new System.Windows.Forms.TableLayoutPanel();
            this.txaENTC_Codigo = new Delfin.Controls.EntidadDocIden();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTIPE_Codigo = new Delfin.Controls.ComboBoxTipoEntidad();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFecIni = new Infrastructure.WinForms.Controls.MaskTime();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFecFin = new Infrastructure.WinForms.Controls.MaskTime();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPlanillas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
            this.navItems.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpCBusqueda.SuspendLayout();
            this.tblFiltroEB.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.btnExportarTXT);
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Controls.Add(this.btnGuardar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1105, 50);
            this.panel3.TabIndex = 0;
            // 
            // btnExportarTXT
            // 
            this.btnExportarTXT.AutoSize = true;
            this.btnExportarTXT.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExportarTXT.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnExportarTXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarTXT.ForeColor = System.Drawing.Color.Black;
            this.btnExportarTXT.Image = global::Delfin.Principal.Properties.Resources.export;
            this.btnExportarTXT.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExportarTXT.Location = new System.Drawing.Point(112, 0);
            this.btnExportarTXT.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportarTXT.Name = "btnExportarTXT";
            this.btnExportarTXT.Size = new System.Drawing.Size(91, 50);
            this.btnExportarTXT.TabIndex = 2;
            this.btnExportarTXT.Text = "Exportar a TXT";
            this.btnExportarTXT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportarTXT.UseVisualStyleBackColor = true;
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
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Image = global::Delfin.Principal.Properties.Resources.search;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(795, 0);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(82, 40);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "  &Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // errorProviderPlanillas
            // 
            this.errorProviderPlanillas.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderPlanillas.ContainerControl = this;
            // 
            // errorEventoTarea
            // 
            this.errorEventoTarea.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorEventoTarea.ContainerControl = this;
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Location = new System.Drawing.Point(0, 330);
            this.grdItems.Margin = new System.Windows.Forms.Padding(3, 3, 18, 3);
            this.grdItems.Name = "grdItems";
            // 
            // 
            // 
            this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 330, 240, 150);
            this.grdItems.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.grdItems.Size = new System.Drawing.Size(1105, 226);
            this.grdItems.TabIndex = 7;
            this.grdItems.TabStop = false;
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
            this.panelCaption3.Location = new System.Drawing.Point(0, 304);
            this.panelCaption3.Name = "panelCaption3";
            this.panelCaption3.Size = new System.Drawing.Size(1105, 26);
            this.panelCaption3.TabIndex = 6;
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
            this.bindingNavigatorMoveFirstItem1});
            this.navItems.Location = new System.Drawing.Point(0, 556);
            this.navItems.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.navItems.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.navItems.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.navItems.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.navItems.Name = "navItems";
            this.navItems.PositionItem = this.bindingNavigatorPositionItem1;
            this.navItems.Size = new System.Drawing.Size(1105, 25);
            this.navItems.TabIndex = 8;
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
            this.tableLayoutPanel1.Controls.Add(this.txnMonto, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbTIPO_CodBCO, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPLAN_FechaEmision, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbPLAN_Tipo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblPLAN_Tipo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTIPO_CodMND, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbTIPO_CodMND, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCUBA_Codigo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txaCUBA_Codigo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpPLAN_FechaEmision, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPLAN_Concepto, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblPLAN_Concepto, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPLAN_Codigo, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPLAN_Codigo, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txnMOVI_TipoCambio, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 6, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 76);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1105, 108);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // txnMonto
            // 
            this.txnMonto.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Moneda;
            this.txnMonto.Decimales = 2;
            this.txnMonto.Enteros = 9;
            this.txnMonto.Formato = "###,###,##0.00";
            this.txnMonto.Location = new System.Drawing.Point(153, 84);
            this.txnMonto.MaxLength = 13;
            this.txnMonto.Name = "txnMonto";
            this.txnMonto.Negativo = true;
            this.txnMonto.SinFormato = false;
            this.txnMonto.Size = new System.Drawing.Size(194, 20);
            this.txnMonto.TabIndex = 15;
            this.txnMonto.Text = "0.00";
            this.txnMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnMonto.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 88);
            this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Total :";
            // 
            // cmbTIPO_CodBCO
            // 
            this.cmbTIPO_CodBCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodBCO.FormattingEnabled = true;
            this.cmbTIPO_CodBCO.Location = new System.Drawing.Point(883, 30);
            this.cmbTIPO_CodBCO.Name = "cmbTIPO_CodBCO";
            this.cmbTIPO_CodBCO.Session = null;
            this.cmbTIPO_CodBCO.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPO_CodBCO.TabIndex = 9;
            this.cmbTIPO_CodBCO.TiposSelectedItem = null;
            this.cmbTIPO_CodBCO.TiposSelectedValue = null;
            this.cmbTIPO_CodBCO.TiposTitulo = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(740, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Banco :";
            // 
            // lblPLAN_FechaEmision
            // 
            this.lblPLAN_FechaEmision.AutoSize = true;
            this.lblPLAN_FechaEmision.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPLAN_FechaEmision.Location = new System.Drawing.Point(10, 7);
            this.lblPLAN_FechaEmision.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblPLAN_FechaEmision.Name = "lblPLAN_FechaEmision";
            this.lblPLAN_FechaEmision.Size = new System.Drawing.Size(97, 13);
            this.lblPLAN_FechaEmision.TabIndex = 0;
            this.lblPLAN_FechaEmision.Text = "Fecha Emisión :";
            // 
            // cmbPLAN_Tipo
            // 
            this.cmbPLAN_Tipo.ConstantesSelectedItem = null;
            this.cmbPLAN_Tipo.ConstantesSelectedValue = null;
            this.cmbPLAN_Tipo.ConstantesTitulo = null;
            this.cmbPLAN_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPLAN_Tipo.FormattingEnabled = true;
            this.cmbPLAN_Tipo.Location = new System.Drawing.Point(153, 57);
            this.cmbPLAN_Tipo.Name = "cmbPLAN_Tipo";
            this.cmbPLAN_Tipo.Session = null;
            this.cmbPLAN_Tipo.Size = new System.Drawing.Size(194, 21);
            this.cmbPLAN_Tipo.TabIndex = 11;
            // 
            // lblPLAN_Tipo
            // 
            this.lblPLAN_Tipo.AutoSize = true;
            this.lblPLAN_Tipo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPLAN_Tipo.Location = new System.Drawing.Point(10, 61);
            this.lblPLAN_Tipo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblPLAN_Tipo.Name = "lblPLAN_Tipo";
            this.lblPLAN_Tipo.Size = new System.Drawing.Size(84, 13);
            this.lblPLAN_Tipo.TabIndex = 10;
            this.lblPLAN_Tipo.Text = "Tipo Planilla :";
            // 
            // lblTIPO_CodMND
            // 
            this.lblTIPO_CodMND.AutoSize = true;
            this.lblTIPO_CodMND.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodMND.Location = new System.Drawing.Point(375, 34);
            this.lblTIPO_CodMND.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodMND.Name = "lblTIPO_CodMND";
            this.lblTIPO_CodMND.Size = new System.Drawing.Size(60, 13);
            this.lblTIPO_CodMND.TabIndex = 6;
            this.lblTIPO_CodMND.Text = "Moneda :";
            // 
            // cmbTIPO_CodMND
            // 
            this.cmbTIPO_CodMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodMND.FormattingEnabled = true;
            this.cmbTIPO_CodMND.Location = new System.Drawing.Point(518, 30);
            this.cmbTIPO_CodMND.Name = "cmbTIPO_CodMND";
            this.cmbTIPO_CodMND.Session = null;
            this.cmbTIPO_CodMND.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPO_CodMND.TabIndex = 7;
            this.cmbTIPO_CodMND.TiposSelectedItem = null;
            this.cmbTIPO_CodMND.TiposSelectedValue = null;
            this.cmbTIPO_CodMND.TiposTitulo = null;
            // 
            // lblCUBA_Codigo
            // 
            this.lblCUBA_Codigo.AutoSize = true;
            this.lblCUBA_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCUBA_Codigo.Location = new System.Drawing.Point(10, 34);
            this.lblCUBA_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCUBA_Codigo.Name = "lblCUBA_Codigo";
            this.lblCUBA_Codigo.Size = new System.Drawing.Size(111, 13);
            this.lblCUBA_Codigo.TabIndex = 4;
            this.lblCUBA_Codigo.Text = "Cuenta Bancaria :";
            // 
            // txaCUBA_Codigo
            // 
            this.txaCUBA_Codigo.ActivarAyudaAuto = false;
            this.txaCUBA_Codigo.BackColor = System.Drawing.Color.White;
            this.txaCUBA_Codigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txaCUBA_Codigo.EMPR_Codigo = ((short)(0));
            this.txaCUBA_Codigo.EnabledAyuda = true;
            this.txaCUBA_Codigo.EnabledAyudaButton = true;
            this.txaCUBA_Codigo.EsFiltro = false;
            this.txaCUBA_Codigo.Location = new System.Drawing.Point(153, 30);
            this.txaCUBA_Codigo.LongitudAceptada = 0;
            this.txaCUBA_Codigo.MaxLength = 100;
            this.txaCUBA_Codigo.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
            this.txaCUBA_Codigo.Name = "txaCUBA_Codigo";
            this.txaCUBA_Codigo.RellenaCeros = false;
            this.txaCUBA_Codigo.SelectedItem = null;
            this.txaCUBA_Codigo.Size = new System.Drawing.Size(194, 20);
            this.txaCUBA_Codigo.TabIndex = 5;
            this.txaCUBA_Codigo.Tag = "CONS_TabESTMSGERROR";
            this.txaCUBA_Codigo.TAyuda = Delfin.Controls.CuentaBancaria.TipoAyuda.Normal;
            this.txaCUBA_Codigo.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
            this.txaCUBA_Codigo.Usuario = null;
            this.txaCUBA_Codigo.Value = null;
            // 
            // dtpPLAN_FechaEmision
            // 
            this.dtpPLAN_FechaEmision.Location = new System.Drawing.Point(153, 3);
            this.dtpPLAN_FechaEmision.MinimumSize = new System.Drawing.Size(100, 22);
            this.dtpPLAN_FechaEmision.Name = "dtpPLAN_FechaEmision";
            this.dtpPLAN_FechaEmision.NSActiveMouse = false;
            this.dtpPLAN_FechaEmision.NSActiveMsgFecha = false;
            this.dtpPLAN_FechaEmision.NSChangeDate = true;
            this.dtpPLAN_FechaEmision.NSDigitos = 4;
            this.dtpPLAN_FechaEmision.NSFecha = null;
            this.dtpPLAN_FechaEmision.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
            this.dtpPLAN_FechaEmision.NSSetDateNow = false;
            this.dtpPLAN_FechaEmision.Size = new System.Drawing.Size(100, 22);
            this.dtpPLAN_FechaEmision.TabIndex = 1;
            // 
            // txtPLAN_Concepto
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtPLAN_Concepto, 4);
            this.txtPLAN_Concepto.Location = new System.Drawing.Point(518, 57);
            this.txtPLAN_Concepto.Name = "txtPLAN_Concepto";
            this.txtPLAN_Concepto.Size = new System.Drawing.Size(559, 20);
            this.txtPLAN_Concepto.TabIndex = 13;
            // 
            // lblPLAN_Concepto
            // 
            this.lblPLAN_Concepto.AutoSize = true;
            this.lblPLAN_Concepto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPLAN_Concepto.Location = new System.Drawing.Point(375, 61);
            this.lblPLAN_Concepto.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblPLAN_Concepto.Name = "lblPLAN_Concepto";
            this.lblPLAN_Concepto.Size = new System.Drawing.Size(70, 13);
            this.lblPLAN_Concepto.TabIndex = 12;
            this.lblPLAN_Concepto.Text = "Concepto :";
            // 
            // txtPLAN_Codigo
            // 
            this.txtPLAN_Codigo.Location = new System.Drawing.Point(883, 3);
            this.txtPLAN_Codigo.Name = "txtPLAN_Codigo";
            this.txtPLAN_Codigo.Size = new System.Drawing.Size(194, 20);
            this.txtPLAN_Codigo.TabIndex = 3;
            // 
            // lblPLAN_Codigo
            // 
            this.lblPLAN_Codigo.AutoSize = true;
            this.lblPLAN_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPLAN_Codigo.Location = new System.Drawing.Point(740, 7);
            this.lblPLAN_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblPLAN_Codigo.Name = "lblPLAN_Codigo";
            this.lblPLAN_Codigo.Size = new System.Drawing.Size(56, 13);
            this.lblPLAN_Codigo.TabIndex = 2;
            this.lblPLAN_Codigo.Text = "Código :";
            // 
            // txnMOVI_TipoCambio
            // 
            this.txnMOVI_TipoCambio.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Moneda;
            this.txnMOVI_TipoCambio.Decimales = 4;
            this.txnMOVI_TipoCambio.Enteros = 9;
            this.txnMOVI_TipoCambio.Formato = "###,###,##0.0000";
            this.txnMOVI_TipoCambio.Location = new System.Drawing.Point(883, 84);
            this.txnMOVI_TipoCambio.MaxLength = 6;
            this.txnMOVI_TipoCambio.Name = "txnMOVI_TipoCambio";
            this.txnMOVI_TipoCambio.Negativo = true;
            this.txnMOVI_TipoCambio.SinFormato = false;
            this.txnMOVI_TipoCambio.Size = new System.Drawing.Size(194, 20);
            this.txnMOVI_TipoCambio.TabIndex = 17;
            this.txnMOVI_TipoCambio.Text = "0.0000";
            this.txnMOVI_TipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnMOVI_TipoCambio.Value = new decimal(new int[] {
            0,
            0,
            0,
            262144});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(740, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tipo de Cambio :";
            // 
            // panelCaption1
            // 
            this.panelCaption1.AllowActive = false;
            this.panelCaption1.AntiAlias = false;
            this.panelCaption1.Caption = "Datos";
            this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption1.Location = new System.Drawing.Point(0, 50);
            this.panelCaption1.Name = "panelCaption1";
            this.panelCaption1.Size = new System.Drawing.Size(1105, 26);
            this.panelCaption1.TabIndex = 1;
            // 
            // tlpCBusqueda
            // 
            this.tlpCBusqueda.AutoSize = true;
            this.tlpCBusqueda.ColumnCount = 10;
            this.tlpCBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpCBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpCBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpCBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpCBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpCBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpCBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpCBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpCBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpCBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCBusqueda.Controls.Add(this.chkMostrarTodos, 7, 0);
            this.tlpCBusqueda.Controls.Add(this.label3, 6, 0);
            this.tlpCBusqueda.Controls.Add(this.btnBuscar, 9, 0);
            this.tlpCBusqueda.Controls.Add(this.chkMostrarCtaCte, 1, 0);
            this.tlpCBusqueda.Controls.Add(this.label1, 0, 0);
            this.tlpCBusqueda.Controls.Add(this.label2, 3, 0);
            this.tlpCBusqueda.Controls.Add(this.chkMostrarCtaInterbancaria, 4, 0);
            this.tlpCBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpCBusqueda.Location = new System.Drawing.Point(0, 264);
            this.tlpCBusqueda.Name = "tlpCBusqueda";
            this.tlpCBusqueda.RowCount = 1;
            this.tlpCBusqueda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCBusqueda.Size = new System.Drawing.Size(1105, 40);
            this.tlpCBusqueda.TabIndex = 5;
            // 
            // chkMostrarTodos
            // 
            this.chkMostrarTodos.AutoSize = true;
            this.chkMostrarTodos.Location = new System.Drawing.Point(742, 12);
            this.chkMostrarTodos.Margin = new System.Windows.Forms.Padding(12, 12, 3, 3);
            this.chkMostrarTodos.Name = "chkMostrarTodos";
            this.chkMostrarTodos.Size = new System.Drawing.Size(15, 14);
            this.chkMostrarTodos.TabIndex = 5;
            this.chkMostrarTodos.Tag = "CCOT_PropiaMSGERROR";
            this.chkMostrarTodos.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(540, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 12, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mostrar Todos :";
            // 
            // chkMostrarCtaCte
            // 
            this.chkMostrarCtaCte.AutoSize = true;
            this.chkMostrarCtaCte.Location = new System.Drawing.Point(212, 12);
            this.chkMostrarCtaCte.Margin = new System.Windows.Forms.Padding(12, 12, 3, 3);
            this.chkMostrarCtaCte.Name = "chkMostrarCtaCte";
            this.chkMostrarCtaCte.Size = new System.Drawing.Size(15, 14);
            this.chkMostrarCtaCte.TabIndex = 1;
            this.chkMostrarCtaCte.Tag = "CCOT_PropiaMSGERROR";
            this.chkMostrarCtaCte.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mostrar Proveedores con Cuenta Corriente :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(275, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mostrar Proveedores con Cuenta Interbancaria :";
            // 
            // chkMostrarCtaInterbancaria
            // 
            this.chkMostrarCtaInterbancaria.AutoSize = true;
            this.chkMostrarCtaInterbancaria.Location = new System.Drawing.Point(477, 12);
            this.chkMostrarCtaInterbancaria.Margin = new System.Windows.Forms.Padding(12, 12, 3, 3);
            this.chkMostrarCtaInterbancaria.Name = "chkMostrarCtaInterbancaria";
            this.chkMostrarCtaInterbancaria.Size = new System.Drawing.Size(15, 14);
            this.chkMostrarCtaInterbancaria.TabIndex = 3;
            this.chkMostrarCtaInterbancaria.Tag = "CCOT_PropiaMSGERROR";
            this.chkMostrarCtaInterbancaria.UseVisualStyleBackColor = true;
            // 
            // pnlCBusqueda
            // 
            this.pnlCBusqueda.AllowActive = false;
            this.pnlCBusqueda.AntiAlias = false;
            this.pnlCBusqueda.Caption = "Criterio de Búsqueda";
            this.pnlCBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCBusqueda.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.pnlCBusqueda.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.pnlCBusqueda.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.pnlCBusqueda.Location = new System.Drawing.Point(0, 184);
            this.pnlCBusqueda.Name = "pnlCBusqueda";
            this.pnlCBusqueda.Size = new System.Drawing.Size(1105, 26);
            this.pnlCBusqueda.TabIndex = 3;
            // 
            // tblFiltroEB
            // 
            this.tblFiltroEB.AutoSize = true;
            this.tblFiltroEB.ColumnCount = 10;
            this.tblFiltroEB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblFiltroEB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblFiltroEB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblFiltroEB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblFiltroEB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblFiltroEB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblFiltroEB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblFiltroEB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblFiltroEB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblFiltroEB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFiltroEB.Controls.Add(this.txaENTC_Codigo, 4, 0);
            this.tblFiltroEB.Controls.Add(this.label10, 3, 0);
            this.tblFiltroEB.Controls.Add(this.cmbTIPE_Codigo, 1, 0);
            this.tblFiltroEB.Controls.Add(this.label9, 0, 0);
            this.tblFiltroEB.Controls.Add(this.label7, 0, 1);
            this.tblFiltroEB.Controls.Add(this.dtpFecIni, 1, 1);
            this.tblFiltroEB.Controls.Add(this.label8, 3, 1);
            this.tblFiltroEB.Controls.Add(this.dtpFecFin, 4, 1);
            this.tblFiltroEB.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblFiltroEB.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tblFiltroEB.Location = new System.Drawing.Point(0, 210);
            this.tblFiltroEB.Name = "tblFiltroEB";
            this.tblFiltroEB.RowCount = 2;
            this.tblFiltroEB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tblFiltroEB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tblFiltroEB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblFiltroEB.Size = new System.Drawing.Size(1105, 54);
            this.tblFiltroEB.TabIndex = 4;
            // 
            // txaENTC_Codigo
            // 
            this.txaENTC_Codigo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tblFiltroEB.SetColumnSpan(this.txaENTC_Codigo, 4);
            this.txaENTC_Codigo.CrearNuevaEntidad = false;
            this.txaENTC_Codigo.Location = new System.Drawing.Point(515, 0);
            this.txaENTC_Codigo.Margin = new System.Windows.Forms.Padding(0);
            this.txaENTC_Codigo.MinimumSize = new System.Drawing.Size(565, 27);
            this.txaENTC_Codigo.Name = "txaENTC_Codigo";
            this.txaENTC_Codigo.Size = new System.Drawing.Size(565, 27);
            this.txaENTC_Codigo.SoloEntidad = false;
            this.txaENTC_Codigo.TabIndex = 3;
            this.txaENTC_Codigo.TagEntidad = null;
            this.txaENTC_Codigo.TiposEntidad = Delfin.Controls.TiposEntidad.TIPE_AgenciaAduanera;
            this.txaENTC_Codigo.txaENTC_DOCIDEN_Name = "txaENTC_DOCIDEN";
            this.txaENTC_Codigo.txaENTC_NOMCOMPLETO_Name = "txaENTC_NOMCOMPLETO";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(375, 7);
            this.label10.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Entidad :";
            // 
            // cmbTIPE_Codigo
            // 
            this.cmbTIPE_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPE_Codigo.FormattingEnabled = true;
            this.cmbTIPE_Codigo.Location = new System.Drawing.Point(153, 3);
            this.cmbTIPE_Codigo.Name = "cmbTIPE_Codigo";
            this.cmbTIPE_Codigo.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPE_Codigo.TabIndex = 1;
            this.cmbTIPE_Codigo.TipoEntidadSelectedItem = null;
            this.cmbTIPE_Codigo.TipoEntidadSelectedValue = null;
            this.cmbTIPE_Codigo.TiposTitulo = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 7);
            this.label9.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tipo de Entidad :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 34);
            this.label7.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Desde :";
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Location = new System.Drawing.Point(153, 30);
            this.dtpFecIni.MinimumSize = new System.Drawing.Size(100, 22);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.NSActiveMouse = false;
            this.dtpFecIni.NSActiveMsgFecha = false;
            this.dtpFecIni.NSChangeDate = true;
            this.dtpFecIni.NSDigitos = 4;
            this.dtpFecIni.NSFecha = null;
            this.dtpFecIni.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
            this.dtpFecIni.NSSetDateNow = false;
            this.dtpFecIni.Size = new System.Drawing.Size(100, 22);
            this.dtpFecIni.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(375, 34);
            this.label8.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Hasta :";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Location = new System.Drawing.Point(518, 30);
            this.dtpFecFin.MinimumSize = new System.Drawing.Size(100, 22);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.NSActiveMouse = false;
            this.dtpFecFin.NSActiveMsgFecha = false;
            this.dtpFecFin.NSChangeDate = true;
            this.dtpFecFin.NSDigitos = 4;
            this.dtpFecFin.NSFecha = null;
            this.dtpFecFin.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
            this.dtpFecFin.NSSetDateNow = false;
            this.dtpFecFin.Size = new System.Drawing.Size(100, 22);
            this.dtpFecFin.TabIndex = 7;
            // 
            // CAJ007ExportacionBancosMView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(1105, 581);
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.panelCaption3);
            this.Controls.Add(this.tlpCBusqueda);
            this.Controls.Add(this.tblFiltroEB);
            this.Controls.Add(this.pnlCBusqueda);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.navItems);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CAJ007ExportacionBancosMView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportación Bancos";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPlanillas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
            this.navItems.ResumeLayout(false);
            this.navItems.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlpCBusqueda.ResumeLayout(false);
            this.tlpCBusqueda.PerformLayout();
            this.tblFiltroEB.ResumeLayout(false);
            this.tblFiltroEB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }



      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private System.Windows.Forms.ErrorProvider errorProviderPlanillas;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.ErrorProvider errorEventoTarea;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.BindingNavigator navItems;
      private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
      private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label lblTIPO_CodMND;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMND;
      private System.Windows.Forms.Label lblCUBA_Codigo;
      private Controls.CuentaBancaria txaCUBA_Codigo;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private Controls.Tipos.ComboBoxConstantes cmbPLAN_Tipo;
      private System.Windows.Forms.Label lblPLAN_Tipo;
      private System.Windows.Forms.TextBox txtPLAN_Codigo;
      private System.Windows.Forms.Label lblPLAN_Codigo;
      private System.Windows.Forms.Button btnBuscar;
      private System.Windows.Forms.TextBox txtPLAN_Concepto;
      private System.Windows.Forms.Label lblPLAN_Concepto;
      private System.Windows.Forms.Label lblPLAN_FechaEmision;
      private Infrastructure.WinForms.Controls.MaskTime dtpPLAN_FechaEmision;
      private System.Windows.Forms.TableLayoutPanel tlpCBusqueda;
      private System.Windows.Forms.Label label1;
      private Infrastructure.WinForms.Controls.PanelCaption pnlCBusqueda;
      private System.Windows.Forms.CheckBox chkMostrarTodos;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.CheckBox chkMostrarCtaCte;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.CheckBox chkMostrarCtaInterbancaria;
      private System.Windows.Forms.Label label5;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodBCO;
      private System.Windows.Forms.Label label4;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnMOVI_TipoCambio;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnMonto;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Button btnExportarTXT;
      private System.Windows.Forms.TableLayoutPanel tblFiltroEB;
      private System.Windows.Forms.Label label7;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecIni;
      private System.Windows.Forms.Label label8;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecFin;
      private System.Windows.Forms.Label label9;
      private Controls.ComboBoxTipoEntidad cmbTIPE_Codigo;
      private System.Windows.Forms.Label label10;
      private Controls.EntidadDocIden txaENTC_Codigo;
   }
}