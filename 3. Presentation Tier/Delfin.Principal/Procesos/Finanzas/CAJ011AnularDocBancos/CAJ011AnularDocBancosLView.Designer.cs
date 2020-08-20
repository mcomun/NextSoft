namespace Delfin.Principal
{
   partial class CAJ011AnularDocBancosLView
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAJ011AnularDocBancosLView));
         this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.tsmColumnas = new System.Windows.Forms.ToolStripMenuItem();
         this.pnBotones = new System.Windows.Forms.Panel();
         this.btnExportar = new System.Windows.Forms.Button();
         this.btnDeshacer = new System.Windows.Forms.Button();
         this.btnBuscar = new System.Windows.Forms.Button();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.cmbTIPO_CodBCO = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.label2 = new System.Windows.Forms.Label();
         this.cmbTIPO_CodMND = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.lblTIPO_CodMND = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.dtpFecFin = new Infrastructure.WinForms.Controls.MaskTime();
         this.dtpFecIni = new Infrastructure.WinForms.Controls.MaskTime();
         this.label3 = new System.Windows.Forms.Label();
         this.lblCUBA_Codigo = new System.Windows.Forms.Label();
         this.txaCUBA_Codigo = new Delfin.Controls.CuentaBancaria(this.components);
         this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.grdItems = new Telerik.WinControls.UI.RadGridView();
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
         this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
         this.sctBase = new System.Windows.Forms.SplitContainer();
         this.grdItemsDetalle = new Telerik.WinControls.UI.RadGridView();
         this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.cmsMenu.SuspendLayout();
         this.pnBotones.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
         this.navItems.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.sctBase)).BeginInit();
         this.sctBase.Panel1.SuspendLayout();
         this.sctBase.Panel2.SuspendLayout();
         this.sctBase.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle.MasterTemplate)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
         this.bindingNavigator1.SuspendLayout();
         this.SuspendLayout();
         // 
         // cmsMenu
         // 
         this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.tsmColumnas});
         this.cmsMenu.Name = "cmsMenu";
         this.cmsMenu.Size = new System.Drawing.Size(129, 70);
         // 
         // editarToolStripMenuItem
         // 
         this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
         this.editarToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
         this.editarToolStripMenuItem.Text = "Editar";
         // 
         // eliminarToolStripMenuItem
         // 
         this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
         this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
         this.eliminarToolStripMenuItem.Text = "Eliminar";
         // 
         // tsmColumnas
         // 
         this.tsmColumnas.Name = "tsmColumnas";
         this.tsmColumnas.Size = new System.Drawing.Size(128, 22);
         this.tsmColumnas.Text = "Columnas";
         // 
         // pnBotones
         // 
         this.pnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
         this.pnBotones.Controls.Add(this.btnExportar);
         this.pnBotones.Controls.Add(this.btnDeshacer);
         this.pnBotones.Controls.Add(this.btnBuscar);
         this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
         this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.pnBotones.Location = new System.Drawing.Point(0, 26);
         this.pnBotones.Name = "pnBotones";
         this.pnBotones.Size = new System.Drawing.Size(1102, 50);
         this.pnBotones.TabIndex = 1;
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
         this.btnExportar.Location = new System.Drawing.Point(120, 0);
         this.btnExportar.Margin = new System.Windows.Forms.Padding(0);
         this.btnExportar.Name = "btnExportar";
         this.btnExportar.Size = new System.Drawing.Size(58, 50);
         this.btnExportar.TabIndex = 16;
         this.btnExportar.Text = "&Exportar";
         this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnExportar.UseVisualStyleBackColor = true;
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
         this.btnDeshacer.Location = new System.Drawing.Point(55, 0);
         this.btnDeshacer.Margin = new System.Windows.Forms.Padding(0);
         this.btnDeshacer.Name = "btnDeshacer";
         this.btnDeshacer.Size = new System.Drawing.Size(65, 50);
         this.btnDeshacer.TabIndex = 1;
         this.btnDeshacer.Text = "&Deshacer";
         this.btnDeshacer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnDeshacer.UseVisualStyleBackColor = true;
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
         this.btnBuscar.TabIndex = 0;
         this.btnBuscar.Text = "&Buscar";
         this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnBuscar.UseVisualStyleBackColor = true;
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
         this.panelCaption1.Location = new System.Drawing.Point(0, 76);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(1102, 26);
         this.panelCaption1.TabIndex = 2;
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
         this.tableLayoutPanel1.Controls.Add(this.cmbTIPO_CodBCO, 7, 0);
         this.tableLayoutPanel1.Controls.Add(this.label2, 6, 0);
         this.tableLayoutPanel1.Controls.Add(this.cmbTIPO_CodMND, 4, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblTIPO_CodMND, 3, 0);
         this.tableLayoutPanel1.Controls.Add(this.label4, 3, 1);
         this.tableLayoutPanel1.Controls.Add(this.dtpFecFin, 4, 1);
         this.tableLayoutPanel1.Controls.Add(this.dtpFecIni, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.lblCUBA_Codigo, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.txaCUBA_Codigo, 1, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(1102, 54);
         this.tableLayoutPanel1.TabIndex = 3;
         // 
         // cmbTIPO_CodBCO
         // 
         this.cmbTIPO_CodBCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodBCO.FormattingEnabled = true;
         this.cmbTIPO_CodBCO.Location = new System.Drawing.Point(883, 3);
         this.cmbTIPO_CodBCO.Name = "cmbTIPO_CodBCO";
         this.cmbTIPO_CodBCO.Session = null;
         this.cmbTIPO_CodBCO.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodBCO.TabIndex = 5;
         this.cmbTIPO_CodBCO.TiposSelectedItem = null;
         this.cmbTIPO_CodBCO.TiposSelectedValue = null;
         this.cmbTIPO_CodBCO.TiposTitulo = null;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(740, 7);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(51, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "Banco :";
         // 
         // cmbTIPO_CodMND
         // 
         this.cmbTIPO_CodMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodMND.FormattingEnabled = true;
         this.cmbTIPO_CodMND.Location = new System.Drawing.Point(518, 3);
         this.cmbTIPO_CodMND.Name = "cmbTIPO_CodMND";
         this.cmbTIPO_CodMND.Session = null;
         this.cmbTIPO_CodMND.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodMND.TabIndex = 3;
         this.cmbTIPO_CodMND.TiposSelectedItem = null;
         this.cmbTIPO_CodMND.TiposSelectedValue = null;
         this.cmbTIPO_CodMND.TiposTitulo = null;
         // 
         // lblTIPO_CodMND
         // 
         this.lblTIPO_CodMND.AutoSize = true;
         this.lblTIPO_CodMND.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPO_CodMND.Location = new System.Drawing.Point(375, 7);
         this.lblTIPO_CodMND.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPO_CodMND.Name = "lblTIPO_CodMND";
         this.lblTIPO_CodMND.Size = new System.Drawing.Size(60, 13);
         this.lblTIPO_CodMND.TabIndex = 2;
         this.lblTIPO_CodMND.Text = "Moneda :";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(375, 34);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(133, 13);
         this.label4.TabIndex = 8;
         this.label4.Text = "Fecha Emisión Hasta :";
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
         this.dtpFecFin.TabIndex = 9;
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
         this.dtpFecIni.TabIndex = 7;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(10, 34);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(137, 13);
         this.label3.TabIndex = 6;
         this.label3.Text = "Fecha Emisión Desde :";
         // 
         // lblCUBA_Codigo
         // 
         this.lblCUBA_Codigo.AutoSize = true;
         this.lblCUBA_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCUBA_Codigo.Location = new System.Drawing.Point(10, 7);
         this.lblCUBA_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCUBA_Codigo.Name = "lblCUBA_Codigo";
         this.lblCUBA_Codigo.Size = new System.Drawing.Size(111, 13);
         this.lblCUBA_Codigo.TabIndex = 0;
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
         this.txaCUBA_Codigo.Location = new System.Drawing.Point(153, 3);
         this.txaCUBA_Codigo.LongitudAceptada = 0;
         this.txaCUBA_Codigo.MaxLength = 100;
         this.txaCUBA_Codigo.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
         this.txaCUBA_Codigo.Name = "txaCUBA_Codigo";
         this.txaCUBA_Codigo.RellenaCeros = false;
         this.txaCUBA_Codigo.SelectedItem = null;
         this.txaCUBA_Codigo.Size = new System.Drawing.Size(194, 20);
         this.txaCUBA_Codigo.TabIndex = 1;
         this.txaCUBA_Codigo.TAyuda = Delfin.Controls.CuentaBancaria.TipoAyuda.Normal;
         this.txaCUBA_Codigo.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
         this.txaCUBA_Codigo.Usuario = null;
         this.txaCUBA_Codigo.Value = null;
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
         this.panelCaption2.Location = new System.Drawing.Point(0, 156);
         this.panelCaption2.Name = "panelCaption2";
         this.panelCaption2.Size = new System.Drawing.Size(1102, 26);
         this.panelCaption2.TabIndex = 4;
         // 
         // grdItems
         // 
         this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItems.Location = new System.Drawing.Point(0, 0);
         this.grdItems.Name = "grdItems";
         // 
         // 
         // 
         this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 240, 150);
         this.grdItems.Size = new System.Drawing.Size(1102, 148);
         this.grdItems.TabIndex = 5;
         this.grdItems.TabStop = false;
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
         this.navItems.Location = new System.Drawing.Point(0, 148);
         this.navItems.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
         this.navItems.MoveLastItem = this.bindingNavigatorMoveLastItem1;
         this.navItems.MoveNextItem = this.bindingNavigatorMoveNextItem1;
         this.navItems.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
         this.navItems.Name = "navItems";
         this.navItems.PositionItem = this.bindingNavigatorPositionItem1;
         this.navItems.Size = new System.Drawing.Size(1102, 25);
         this.navItems.TabIndex = 6;
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
         // TitleView
         // 
         this.TitleView.AllowActive = false;
         this.TitleView.AntiAlias = false;
         this.TitleView.Caption = "ANULAR DOCUMENTOS BANCARIOS";
         this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
         this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
         this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.TitleView.Location = new System.Drawing.Point(0, 0);
         this.TitleView.Name = "TitleView";
         this.TitleView.Size = new System.Drawing.Size(1102, 26);
         this.TitleView.TabIndex = 0;
         // 
         // sctBase
         // 
         this.sctBase.Dock = System.Windows.Forms.DockStyle.Fill;
         this.sctBase.Location = new System.Drawing.Point(0, 182);
         this.sctBase.Name = "sctBase";
         this.sctBase.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // sctBase.Panel1
         // 
         this.sctBase.Panel1.Controls.Add(this.grdItems);
         this.sctBase.Panel1.Controls.Add(this.navItems);
         // 
         // sctBase.Panel2
         // 
         this.sctBase.Panel2.Controls.Add(this.grdItemsDetalle);
         this.sctBase.Panel2.Controls.Add(this.bindingNavigator1);
         this.sctBase.Size = new System.Drawing.Size(1102, 268);
         this.sctBase.SplitterDistance = 173;
         this.sctBase.TabIndex = 7;
         // 
         // grdItemsDetalle
         // 
         this.grdItemsDetalle.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdItemsDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItemsDetalle.Location = new System.Drawing.Point(0, 0);
         this.grdItemsDetalle.Name = "grdItemsDetalle";
         // 
         // 
         // 
         this.grdItemsDetalle.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 240, 150);
         this.grdItemsDetalle.Size = new System.Drawing.Size(1102, 66);
         this.grdItemsDetalle.TabIndex = 8;
         this.grdItemsDetalle.TabStop = false;
         // 
         // bindingNavigator1
         // 
         this.bindingNavigator1.AddNewItem = null;
         this.bindingNavigator1.BackColor = System.Drawing.Color.LightSteelBlue;
         this.bindingNavigator1.CountItem = this.toolStripLabel1;
         this.bindingNavigator1.DeleteItem = null;
         this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator3});
         this.bindingNavigator1.Location = new System.Drawing.Point(0, 66);
         this.bindingNavigator1.MoveFirstItem = this.toolStripButton4;
         this.bindingNavigator1.MoveLastItem = this.toolStripButton1;
         this.bindingNavigator1.MoveNextItem = this.toolStripButton2;
         this.bindingNavigator1.MovePreviousItem = this.toolStripButton3;
         this.bindingNavigator1.Name = "bindingNavigator1";
         this.bindingNavigator1.PositionItem = this.toolStripTextBox1;
         this.bindingNavigator1.Size = new System.Drawing.Size(1102, 25);
         this.bindingNavigator1.TabIndex = 7;
         this.bindingNavigator1.Text = "bindingNavigator1";
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(37, 22);
         this.toolStripLabel1.Text = "de {0}";
         this.toolStripLabel1.ToolTipText = "Número total de elementos";
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.RightToLeftAutoMirrorImage = true;
         this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
         this.toolStripButton1.Text = "Mover último";
         // 
         // toolStripButton2
         // 
         this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
         this.toolStripButton2.Name = "toolStripButton2";
         this.toolStripButton2.RightToLeftAutoMirrorImage = true;
         this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
         this.toolStripButton2.Text = "Mover siguiente";
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripTextBox1
         // 
         this.toolStripTextBox1.AccessibleName = "Posición";
         this.toolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripTextBox1.AutoSize = false;
         this.toolStripTextBox1.Name = "toolStripTextBox1";
         this.toolStripTextBox1.Size = new System.Drawing.Size(50, 23);
         this.toolStripTextBox1.Text = "0";
         this.toolStripTextBox1.ToolTipText = "Posición actual";
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripButton3
         // 
         this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
         this.toolStripButton3.Name = "toolStripButton3";
         this.toolStripButton3.RightToLeftAutoMirrorImage = true;
         this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
         this.toolStripButton3.Text = "Mover anterior";
         // 
         // toolStripButton4
         // 
         this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
         this.toolStripButton4.Name = "toolStripButton4";
         this.toolStripButton4.RightToLeftAutoMirrorImage = true;
         this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
         this.toolStripButton4.Text = "Mover primero";
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
         // 
         // CAJ011AnularDocBancosLView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.Controls.Add(this.sctBase);
         this.Controls.Add(this.panelCaption2);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.pnBotones);
         this.Controls.Add(this.TitleView);
         this.Name = "CAJ011AnularDocBancosLView";
         this.Size = new System.Drawing.Size(1102, 450);
         this.cmsMenu.ResumeLayout(false);
         this.pnBotones.ResumeLayout(false);
         this.pnBotones.PerformLayout();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
         this.navItems.ResumeLayout(false);
         this.navItems.PerformLayout();
         this.sctBase.Panel1.ResumeLayout(false);
         this.sctBase.Panel1.PerformLayout();
         this.sctBase.Panel2.ResumeLayout(false);
         this.sctBase.Panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.sctBase)).EndInit();
         this.sctBase.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
         this.bindingNavigator1.ResumeLayout(false);
         this.bindingNavigator1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ContextMenuStrip cmsMenu;
      private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem tsmColumnas;
      private System.Windows.Forms.Panel pnBotones;
      private System.Windows.Forms.Button btnDeshacer;
      private System.Windows.Forms.Button btnBuscar;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private Infrastructure.WinForms.Controls.FormTitle TitleView;
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
      private System.Windows.Forms.Label lblCUBA_Codigo;
      private System.Windows.Forms.Label label3;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecFin;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecIni;
      private System.Windows.Forms.Label label4;
      private Controls.CuentaBancaria txaCUBA_Codigo;
      private System.Windows.Forms.Label lblTIPO_CodMND;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMND;
      private System.Windows.Forms.Label label2;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodBCO;
      private System.Windows.Forms.SplitContainer sctBase;
      private Telerik.WinControls.UI.RadGridView grdItemsDetalle;
      private System.Windows.Forms.BindingNavigator bindingNavigator1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.ToolStripButton toolStripButton2;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton toolStripButton3;
      private System.Windows.Forms.ToolStripButton toolStripButton4;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.Button btnExportar;

   }
}
