namespace Delfin.Principal
{
   partial class PRO007LView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PRO007LView));
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmColumnas = new System.Windows.Forms.ToolStripMenuItem();
            this.pnBotones = new System.Windows.Forms.Panel();
            this.btnNuevoFactLibre = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panelCaption1 = new Infrastructure.WinFormsControls.PanelCaption();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbDocOrigen = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblDocOrigen = new System.Windows.Forms.Label();
            this.cmbDOCV_Estado = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTIPE_Codigo = new Delfin.Controls.ComboBoxTipoEntidad();
            this.label2 = new System.Windows.Forms.Label();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.mdtFecHasta = new Infrastructure.WinFormsControls.MaskDateTime();
            this.mdtFecDesde = new Infrastructure.WinFormsControls.MaskDateTime();
            this.lblCONT_FecIni = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txaENTC_Codigo = new Delfin.Controls.EntidadDocIden();
            this.txaSeries = new Delfin.Controls.Serie.SeriesLarge();
            this.txtDOCV_Numero = new System.Windows.Forms.TextBox();
            this.lblDOCV_Numero = new System.Windows.Forms.Label();
            this.chkFacturaSinSerie = new System.Windows.Forms.CheckBox();
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            this.panelCaption2 = new Infrastructure.WinFormsControls.PanelCaption();
            this.tabBase = new Crownwood.DotNetMagic.Controls.TabControl();
            this.tpgFacturas = new Crownwood.DotNetMagic.Controls.TabPage();
            this.tpgDocMandato = new Crownwood.DotNetMagic.Controls.TabPage();
            this.grdItemsDocMandato = new Telerik.WinControls.UI.RadGridView();
            this.panelCaption3 = new Infrastructure.WinFormsControls.PanelCaption();
            this.navItemsDocMandato = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
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
            this.TitleView = new Infrastructure.WinFormsControls.FormTitle();
            this.cmsMenu.SuspendLayout();
            this.pnBotones.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
            this.tabBase.SuspendLayout();
            this.tpgFacturas.SuspendLayout();
            this.tpgDocMandato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDocMandato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDocMandato.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navItemsDocMandato)).BeginInit();
            this.navItemsDocMandato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
            this.navItems.SuspendLayout();
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
            this.pnBotones.Controls.Add(this.btnNuevoFactLibre);
            this.pnBotones.Controls.Add(this.btnDeshacer);
            this.pnBotones.Controls.Add(this.btnExportar);
            this.pnBotones.Controls.Add(this.btnBuscar);
            this.pnBotones.Controls.Add(this.btnNuevo);
            this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnBotones.Location = new System.Drawing.Point(0, 26);
            this.pnBotones.Name = "pnBotones";
            this.pnBotones.Size = new System.Drawing.Size(1099, 50);
            this.pnBotones.TabIndex = 1;
            // 
            // btnNuevoFactLibre
            // 
            this.btnNuevoFactLibre.AutoSize = true;
            this.btnNuevoFactLibre.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNuevoFactLibre.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnNuevoFactLibre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoFactLibre.ForeColor = System.Drawing.Color.Black;
            this.btnNuevoFactLibre.Image = global::Delfin.Principal.Properties.Resources.add2_24x24;
            this.btnNuevoFactLibre.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevoFactLibre.Location = new System.Drawing.Point(235, 0);
            this.btnNuevoFactLibre.Margin = new System.Windows.Forms.Padding(0);
            this.btnNuevoFactLibre.Name = "btnNuevoFactLibre";
            this.btnNuevoFactLibre.Size = new System.Drawing.Size(104, 50);
            this.btnNuevoFactLibre.TabIndex = 5;
            this.btnNuevoFactLibre.Text = "Nuevo &Fact. Libre";
            this.btnNuevoFactLibre.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevoFactLibre.UseVisualStyleBackColor = true;
            this.btnNuevoFactLibre.Visible = false;
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
            this.btnDeshacer.Location = new System.Drawing.Point(170, 0);
            this.btnDeshacer.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(65, 50);
            this.btnDeshacer.TabIndex = 4;
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
            this.btnExportar.Location = new System.Drawing.Point(112, 0);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(58, 50);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "&Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = true;
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
            this.btnBuscar.Location = new System.Drawing.Point(57, 0);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(55, 50);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.AutoSize = true;
            this.btnNuevo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.ForeColor = System.Drawing.Color.Black;
            this.btnNuevo.Image = global::Delfin.Principal.Properties.Resources.add;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevo.Location = new System.Drawing.Point(0, 0);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(0);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(57, 50);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
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
            this.panelCaption1.Size = new System.Drawing.Size(1099, 26);
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
            this.tableLayoutPanel1.Controls.Add(this.cmbDocOrigen, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDocOrigen, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbDOCV_Estado, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbTIPE_Codigo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkEstado, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.mdtFecHasta, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.mdtFecDesde, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCONT_FecIni, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txaENTC_Codigo, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txaSeries, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDOCV_Numero, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblDOCV_Numero, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkFacturaSinSerie, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1099, 108);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // cmbDocOrigen
            // 
            this.cmbDocOrigen.ConstantesSelectedItem = null;
            this.cmbDocOrigen.ConstantesSelectedValue = null;
            this.cmbDocOrigen.ConstantesTitulo = null;
            this.cmbDocOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocOrigen.FormattingEnabled = true;
            this.cmbDocOrigen.Location = new System.Drawing.Point(153, 57);
            this.cmbDocOrigen.Name = "cmbDocOrigen";
            this.cmbDocOrigen.Session = null;
            this.cmbDocOrigen.Size = new System.Drawing.Size(194, 21);
            this.cmbDocOrigen.TabIndex = 5;
            // 
            // lblDocOrigen
            // 
            this.lblDocOrigen.AutoSize = true;
            this.lblDocOrigen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocOrigen.Location = new System.Drawing.Point(10, 61);
            this.lblDocOrigen.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblDocOrigen.Name = "lblDocOrigen";
            this.lblDocOrigen.Size = new System.Drawing.Size(112, 13);
            this.lblDocOrigen.TabIndex = 8;
            this.lblDocOrigen.Text = "Tipo Doc. Origen :";
            // 
            // cmbDOCV_Estado
            // 
            this.cmbDOCV_Estado.ConstantesSelectedItem = null;
            this.cmbDOCV_Estado.ConstantesSelectedValue = null;
            this.cmbDOCV_Estado.ConstantesTitulo = null;
            this.cmbDOCV_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDOCV_Estado.FormattingEnabled = true;
            this.cmbDOCV_Estado.Location = new System.Drawing.Point(883, 84);
            this.cmbDOCV_Estado.Name = "cmbDOCV_Estado";
            this.cmbDOCV_Estado.Session = null;
            this.cmbDOCV_Estado.Size = new System.Drawing.Size(194, 21);
            this.cmbDOCV_Estado.TabIndex = 13;
            this.cmbDOCV_Estado.Tag = "DOCV_EstadoMSGERROR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(375, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Entidad :";
            // 
            // cmbTIPE_Codigo
            // 
            this.cmbTIPE_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPE_Codigo.FormattingEnabled = true;
            this.cmbTIPE_Codigo.Location = new System.Drawing.Point(153, 30);
            this.cmbTIPE_Codigo.Name = "cmbTIPE_Codigo";
            this.cmbTIPE_Codigo.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPE_Codigo.TabIndex = 6;
            this.cmbTIPE_Codigo.TipoEntidadSelectedItem = null;
            this.cmbTIPE_Codigo.TipoEntidadSelectedValue = null;
            this.cmbTIPE_Codigo.TiposTitulo = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(740, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Estado :";
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel1.SetColumnSpan(this.chkEstado, 2);
            this.chkEstado.Location = new System.Drawing.Point(733, 3);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Padding = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.chkEstado.Size = new System.Drawing.Size(176, 21);
            this.chkEstado.TabIndex = 4;
            this.chkEstado.Text = "Incluir Pre-Facturas Anuladas :";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // mdtFecHasta
            // 
            this.mdtFecHasta.Location = new System.Drawing.Point(518, 3);
            this.mdtFecHasta.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFecHasta.Name = "mdtFecHasta";
            this.mdtFecHasta.NSActiveMouse = false;
            this.mdtFecHasta.NSActiveMsgFecha = false;
            this.mdtFecHasta.NSChangeDate = true;
            this.mdtFecHasta.NSDigitos = 4;
            this.mdtFecHasta.NSFecha = null;
            this.mdtFecHasta.NSSetDateNow = false;
            this.mdtFecHasta.Size = new System.Drawing.Size(131, 22);
            this.mdtFecHasta.TabIndex = 3;
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
            this.mdtFecDesde.Size = new System.Drawing.Size(138, 22);
            this.mdtFecDesde.TabIndex = 1;
            // 
            // lblCONT_FecIni
            // 
            this.lblCONT_FecIni.AutoSize = true;
            this.lblCONT_FecIni.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONT_FecIni.Location = new System.Drawing.Point(10, 7);
            this.lblCONT_FecIni.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONT_FecIni.Name = "lblCONT_FecIni";
            this.lblCONT_FecIni.Size = new System.Drawing.Size(127, 13);
            this.lblCONT_FecIni.TabIndex = 0;
            this.lblCONT_FecIni.Text = "Fec. Emisión Desde :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(375, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Fec. Emisión Hasta :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tipo de Entidad :";
            // 
            // txaENTC_Codigo
            // 
            this.txaENTC_Codigo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tableLayoutPanel1.SetColumnSpan(this.txaENTC_Codigo, 4);
            this.txaENTC_Codigo.CrearNuevaEntidad = false;
            this.txaENTC_Codigo.Location = new System.Drawing.Point(515, 27);
            this.txaENTC_Codigo.Margin = new System.Windows.Forms.Padding(0);
            this.txaENTC_Codigo.MinimumSize = new System.Drawing.Size(565, 27);
            this.txaENTC_Codigo.Name = "txaENTC_Codigo";
            this.txaENTC_Codigo.Size = new System.Drawing.Size(565, 27);
            this.txaENTC_Codigo.SoloEntidad = false;
            this.txaENTC_Codigo.TabIndex = 8;
            this.txaENTC_Codigo.TagEntidad = null;
            this.txaENTC_Codigo.TiposEntidad = Delfin.Controls.TiposEntidad.TIPE_AgenciaAduanera;
            this.txaENTC_Codigo.txaENTC_DOCIDEN_Name = "txaENTC_DOCIDEN";
            this.txaENTC_Codigo.txaENTC_NOMCOMPLETO_Name = "txaENTC_NOMCOMPLETO";
            // 
            // txaSeries
            // 
            this.txaSeries.cmbSERI_Serie_Enabled = false;
            this.txaSeries.cmbTIPO_CodTDO_Enabled = true;
            this.tableLayoutPanel1.SetColumnSpan(this.txaSeries, 5);
            this.txaSeries.ListSeries = null;
            this.txaSeries.ListTiposTDO = null;
            this.txaSeries.Location = new System.Drawing.Point(365, 54);
            this.txaSeries.Margin = new System.Windows.Forms.Padding(0);
            this.txaSeries.Name = "txaSeries";
            this.txaSeries.SelectedItem = null;
            this.txaSeries.SelectedItemTipoTDO = null;
            this.txaSeries.Size = new System.Drawing.Size(715, 27);
            this.txaSeries.TabIndex = 9;
            // 
            // txtDOCV_Numero
            // 
            this.txtDOCV_Numero.Location = new System.Drawing.Point(518, 84);
            this.txtDOCV_Numero.Name = "txtDOCV_Numero";
            this.txtDOCV_Numero.Size = new System.Drawing.Size(193, 20);
            this.txtDOCV_Numero.TabIndex = 11;
            // 
            // lblDOCV_Numero
            // 
            this.lblDOCV_Numero.AutoSize = true;
            this.lblDOCV_Numero.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOCV_Numero.Location = new System.Drawing.Point(375, 88);
            this.lblDOCV_Numero.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblDOCV_Numero.Name = "lblDOCV_Numero";
            this.lblDOCV_Numero.Size = new System.Drawing.Size(124, 13);
            this.lblDOCV_Numero.TabIndex = 10;
            this.lblDOCV_Numero.Text = "Número de Factura :";
            // 
            // chkFacturaSinSerie
            // 
            this.chkFacturaSinSerie.AutoSize = true;
            this.chkFacturaSinSerie.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel1.SetColumnSpan(this.chkFacturaSinSerie, 2);
            this.chkFacturaSinSerie.Location = new System.Drawing.Point(3, 84);
            this.chkFacturaSinSerie.Name = "chkFacturaSinSerie";
            this.chkFacturaSinSerie.Padding = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.chkFacturaSinSerie.Size = new System.Drawing.Size(171, 21);
            this.chkFacturaSinSerie.TabIndex = 5;
            this.chkFacturaSinSerie.Text = "Incluir Facturas sin Serie :      ";
            this.chkFacturaSinSerie.UseVisualStyleBackColor = true;
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Location = new System.Drawing.Point(0, 26);
            this.grdItems.Name = "grdItems";
            // 
            // 
            // 
            this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 26, 240, 150);
            this.grdItems.Size = new System.Drawing.Size(1097, 164);
            this.grdItems.TabIndex = 1;
            this.grdItems.TabStop = false;
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
            this.panelCaption2.Location = new System.Drawing.Point(0, 0);
            this.panelCaption2.Name = "panelCaption2";
            this.panelCaption2.Size = new System.Drawing.Size(1097, 26);
            this.panelCaption2.TabIndex = 0;
            // 
            // tabBase
            // 
            this.tabBase.AllowCtrlTab = false;
            this.tabBase.BoldSelectedPage = true;
            this.tabBase.ButtonActiveColor = System.Drawing.Color.LightSteelBlue;
            this.tabBase.ButtonInactiveColor = System.Drawing.Color.LightSteelBlue;
            this.tabBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBase.Location = new System.Drawing.Point(0, 210);
            this.tabBase.MediaPlayerDockSides = false;
            this.tabBase.Name = "tabBase";
            this.tabBase.OfficeDockSides = false;
            this.tabBase.PositionTop = true;
            this.tabBase.SelectedIndex = 0;
            this.tabBase.ShowDropSelect = false;
            this.tabBase.Size = new System.Drawing.Size(1099, 215);
            this.tabBase.Style = Crownwood.DotNetMagic.Common.VisualStyle.Office2007Black;
            this.tabBase.TabIndex = 4;
            this.tabBase.TabPages.AddRange(new Crownwood.DotNetMagic.Controls.TabPage[] {
            this.tpgFacturas,
            this.tpgDocMandato});
            this.tabBase.TextTips = true;
            // 
            // tpgFacturas
            // 
            this.tpgFacturas.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tpgFacturas.Controls.Add(this.grdItems);
            this.tpgFacturas.Controls.Add(this.panelCaption2);
            this.tpgFacturas.InactiveBackColor = System.Drawing.Color.Empty;
            this.tpgFacturas.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tpgFacturas.InactiveTextColor = System.Drawing.Color.Empty;
            this.tpgFacturas.Location = new System.Drawing.Point(1, 24);
            this.tpgFacturas.Name = "tpgFacturas";
            this.tpgFacturas.SelectBackColor = System.Drawing.Color.Empty;
            this.tpgFacturas.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tpgFacturas.SelectTextColor = System.Drawing.Color.Empty;
            this.tpgFacturas.Size = new System.Drawing.Size(1097, 190);
            this.tpgFacturas.TabIndex = 4;
            this.tpgFacturas.Title = "Documentos de Facturación";
            this.tpgFacturas.ToolTip = "Documentos de Facturación";
            // 
            // tpgDocMandato
            // 
            this.tpgDocMandato.Controls.Add(this.grdItemsDocMandato);
            this.tpgDocMandato.Controls.Add(this.panelCaption3);
            this.tpgDocMandato.Controls.Add(this.navItemsDocMandato);
            this.tpgDocMandato.InactiveBackColor = System.Drawing.Color.Empty;
            this.tpgDocMandato.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tpgDocMandato.InactiveTextColor = System.Drawing.Color.Empty;
            this.tpgDocMandato.Location = new System.Drawing.Point(1, 24);
            this.tpgDocMandato.Name = "tpgDocMandato";
            this.tpgDocMandato.SelectBackColor = System.Drawing.Color.Empty;
            this.tpgDocMandato.Selected = false;
            this.tpgDocMandato.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tpgDocMandato.SelectTextColor = System.Drawing.Color.Empty;
            this.tpgDocMandato.Size = new System.Drawing.Size(1097, 190);
            this.tpgDocMandato.TabIndex = 5;
            this.tpgDocMandato.Title = "Recibo de Caja";
            this.tpgDocMandato.ToolTip = "Page";
            // 
            // grdItemsDocMandato
            // 
            this.grdItemsDocMandato.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItemsDocMandato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItemsDocMandato.Location = new System.Drawing.Point(0, 26);
            this.grdItemsDocMandato.Name = "grdItemsDocMandato";
            // 
            // 
            // 
            this.grdItemsDocMandato.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 26, 240, 150);
            this.grdItemsDocMandato.Size = new System.Drawing.Size(1097, 139);
            this.grdItemsDocMandato.TabIndex = 1;
            this.grdItemsDocMandato.TabStop = false;
            // 
            // panelCaption3
            // 
            this.panelCaption3.AllowActive = false;
            this.panelCaption3.AntiAlias = false;
            this.panelCaption3.Caption = "Resultado Búsqueda";
            this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption3.Location = new System.Drawing.Point(0, 0);
            this.panelCaption3.Name = "panelCaption3";
            this.panelCaption3.Size = new System.Drawing.Size(1097, 26);
            this.panelCaption3.TabIndex = 0;
            // 
            // navItemsDocMandato
            // 
            this.navItemsDocMandato.AddNewItem = null;
            this.navItemsDocMandato.BackColor = System.Drawing.Color.LightSteelBlue;
            this.navItemsDocMandato.CountItem = this.toolStripLabel2;
            this.navItemsDocMandato.DeleteItem = null;
            this.navItemsDocMandato.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navItemsDocMandato.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator3,
            this.toolStripLabel2,
            this.toolStripTextBox2,
            this.toolStripSeparator4,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripSeparator5});
            this.navItemsDocMandato.Location = new System.Drawing.Point(0, 165);
            this.navItemsDocMandato.MoveFirstItem = this.toolStripButton5;
            this.navItemsDocMandato.MoveLastItem = this.toolStripButton8;
            this.navItemsDocMandato.MoveNextItem = this.toolStripButton7;
            this.navItemsDocMandato.MovePreviousItem = this.toolStripButton6;
            this.navItemsDocMandato.Name = "navItemsDocMandato";
            this.navItemsDocMandato.PositionItem = this.toolStripTextBox2;
            this.navItemsDocMandato.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.navItemsDocMandato.Size = new System.Drawing.Size(1097, 25);
            this.navItemsDocMandato.TabIndex = 2;
            this.navItemsDocMandato.Text = "bindingNavigator1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel2.Text = "de {0}";
            this.toolStripLabel2.ToolTipText = "Número total de elementos";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.RightToLeftAutoMirrorImage = true;
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Mover primero";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.RightToLeftAutoMirrorImage = true;
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Mover anterior";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.AccessibleName = "Posición";
            this.toolStripTextBox2.AutoSize = false;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox2.Text = "0";
            this.toolStripTextBox2.ToolTipText = "Posición actual";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.RightToLeftAutoMirrorImage = true;
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "Mover siguiente";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.RightToLeftAutoMirrorImage = true;
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "Mover último";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
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
            this.navItems.Location = new System.Drawing.Point(0, 425);
            this.navItems.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.navItems.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.navItems.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.navItems.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.navItems.Name = "navItems";
            this.navItems.PositionItem = this.bindingNavigatorPositionItem1;
            this.navItems.Size = new System.Drawing.Size(1099, 25);
            this.navItems.TabIndex = 54;
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
            this.TitleView.Caption = "Facturación";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(1099, 26);
            this.TitleView.TabIndex = 0;
            // 
            // PRO007LView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.tabBase);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.pnBotones);
            this.Controls.Add(this.TitleView);
            this.Controls.Add(this.navItems);
            this.Name = "PRO007LView";
            this.Size = new System.Drawing.Size(1099, 450);
            this.cmsMenu.ResumeLayout(false);
            this.pnBotones.ResumeLayout(false);
            this.pnBotones.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            this.tabBase.ResumeLayout(false);
            this.tpgFacturas.ResumeLayout(false);
            this.tpgDocMandato.ResumeLayout(false);
            this.tpgDocMandato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDocMandato.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDocMandato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navItemsDocMandato)).EndInit();
            this.navItemsDocMandato.ResumeLayout(false);
            this.navItemsDocMandato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
            this.navItems.ResumeLayout(false);
            this.navItems.PerformLayout();
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
      private System.Windows.Forms.Button btnExportar;
      private System.Windows.Forms.Button btnBuscar;
      private System.Windows.Forms.Button btnNuevo;
      private Infrastructure.WinFormsControls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private Infrastructure.WinFormsControls.FormTitle TitleView;
      private System.Windows.Forms.Label lblCONT_FecIni;
      private Infrastructure.WinFormsControls.MaskDateTime mdtFecDesde;
      private Infrastructure.WinFormsControls.MaskDateTime mdtFecHasta;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label1;
      private Controls.EntidadDocIden txaENTC_Codigo;
      private System.Windows.Forms.CheckBox chkEstado;
      private System.Windows.Forms.TextBox txtDOCV_Numero;
      private System.Windows.Forms.Label lblDOCV_Numero;
      private System.Windows.Forms.Label label2;
      private Controls.Tipos.ComboBoxConstantes cmbDOCV_Estado;
      private Controls.Serie.SeriesLarge txaSeries;
      private Infrastructure.WinFormsControls.PanelCaption panelCaption2;
      private Crownwood.DotNetMagic.Controls.TabControl tabBase;
      private Crownwood.DotNetMagic.Controls.TabPage tpgFacturas;
      private Crownwood.DotNetMagic.Controls.TabPage tpgDocMandato;
      private Telerik.WinControls.UI.RadGridView grdItemsDocMandato;
      private Infrastructure.WinFormsControls.PanelCaption panelCaption3;
      private System.Windows.Forms.BindingNavigator navItemsDocMandato;
      private System.Windows.Forms.ToolStripLabel toolStripLabel2;
      private System.Windows.Forms.ToolStripButton toolStripButton5;
      private System.Windows.Forms.ToolStripButton toolStripButton6;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.ToolStripButton toolStripButton7;
      private System.Windows.Forms.ToolStripButton toolStripButton8;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
      private Controls.ComboBoxTipoEntidad cmbTIPE_Codigo;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.CheckBox chkFacturaSinSerie;
      private Controls.Tipos.ComboBoxConstantes cmbDocOrigen;
      private System.Windows.Forms.Label lblDocOrigen;
      private System.Windows.Forms.Button btnNuevoFactLibre;
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
      

   }
}
