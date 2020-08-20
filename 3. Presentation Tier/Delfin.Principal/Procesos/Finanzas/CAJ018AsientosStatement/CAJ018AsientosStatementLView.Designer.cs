namespace Delfin.Principal
{
   partial class CAJ018AsientosStatementLView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAJ018AsientosStatementLView));
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmColumnas = new System.Windows.Forms.ToolStripMenuItem();
            this.pnBotones = new System.Windows.Forms.Panel();
            this.btnProcesarAsientos = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NAVE_Codigo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecFin = new Infrastructure.WinForms.Controls.MaskTime();
            this.dtpFecIni = new Infrastructure.WinForms.Controls.MaskTime();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCONS_CodLNG = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblCONS_CodLNG = new System.Windows.Forms.Label();
            this.cmbCONS_CodVia = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblCONS_CodVia = new System.Windows.Forms.Label();
            this.cmbCONS_CodRGM = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblCONS_CodRGM = new System.Windows.Forms.Label();
            this.NVIA_NroViaje = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTipoAsiento = new System.Windows.Forms.TextBox();
            this.txtTipoLibro = new System.Windows.Forms.TextBox();
            this.lblRegistro_1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
            this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.navItems = new System.Windows.Forms.BindingNavigator();
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CMSseleccion = new System.Windows.Forms.ContextMenuStrip();
            this.marcarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desmarcarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcarSeleccionadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desmarcarSeleccionadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMenu.SuspendLayout();
            this.pnBotones.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
            this.navItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.CMSseleccion.SuspendLayout();
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
            this.pnBotones.Controls.Add(this.btnProcesarAsientos);
            this.pnBotones.Controls.Add(this.btnDeshacer);
            this.pnBotones.Controls.Add(this.btnBuscar);
            this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnBotones.Location = new System.Drawing.Point(0, 26);
            this.pnBotones.Name = "pnBotones";
            this.pnBotones.Size = new System.Drawing.Size(1106, 50);
            this.pnBotones.TabIndex = 1;
            // 
            // btnProcesarAsientos
            // 
            this.btnProcesarAsientos.AutoSize = true;
            this.btnProcesarAsientos.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProcesarAsientos.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnProcesarAsientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesarAsientos.ForeColor = System.Drawing.Color.Black;
            this.btnProcesarAsientos.Image = global::Delfin.Principal.Properties.Resources.document_out_24x24;
            this.btnProcesarAsientos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProcesarAsientos.Location = new System.Drawing.Point(120, 0);
            this.btnProcesarAsientos.Margin = new System.Windows.Forms.Padding(0);
            this.btnProcesarAsientos.Name = "btnProcesarAsientos";
            this.btnProcesarAsientos.Size = new System.Drawing.Size(104, 50);
            this.btnProcesarAsientos.TabIndex = 0;
            this.btnProcesarAsientos.Text = "&Generar Asientos";
            this.btnProcesarAsientos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesarAsientos.UseVisualStyleBackColor = true;
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
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = true;
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
            this.panelCaption1.Size = new System.Drawing.Size(1106, 26);
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
            this.tableLayoutPanel1.Controls.Add(this.NAVE_Codigo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpFecFin, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpFecIni, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbCONS_CodLNG, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCONS_CodLNG, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbCONS_CodVia, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCONS_CodVia, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbCONS_CodRGM, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCONS_CodRGM, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NVIA_NroViaje, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1106, 81);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // NAVE_Codigo
            // 
            this.NAVE_Codigo.FormattingEnabled = true;
            this.NAVE_Codigo.Location = new System.Drawing.Point(153, 57);
            this.NAVE_Codigo.Name = "NAVE_Codigo";
            this.NAVE_Codigo.Size = new System.Drawing.Size(193, 21);
            this.NAVE_Codigo.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nave:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(375, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fec. ETA/ETD Hasta :";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Location = new System.Drawing.Point(518, 3);
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
            this.dtpFecFin.TabIndex = 3;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Location = new System.Drawing.Point(153, 3);
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
            this.dtpFecIni.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fec. ETA/ETD Desde :";
            // 
            // cmbCONS_CodLNG
            // 
            this.cmbCONS_CodLNG.ConstantesSelectedItem = null;
            this.cmbCONS_CodLNG.ConstantesSelectedValue = null;
            this.cmbCONS_CodLNG.ConstantesTitulo = null;
            this.cmbCONS_CodLNG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCONS_CodLNG.Enabled = false;
            this.cmbCONS_CodLNG.FormattingEnabled = true;
            this.cmbCONS_CodLNG.Location = new System.Drawing.Point(883, 30);
            this.cmbCONS_CodLNG.Name = "cmbCONS_CodLNG";
            this.cmbCONS_CodLNG.Session = null;
            this.cmbCONS_CodLNG.Size = new System.Drawing.Size(194, 21);
            this.cmbCONS_CodLNG.TabIndex = 9;
            this.cmbCONS_CodLNG.Tag = "CONS_CodLNGMSGERROR";
            // 
            // lblCONS_CodLNG
            // 
            this.lblCONS_CodLNG.AutoSize = true;
            this.lblCONS_CodLNG.Location = new System.Drawing.Point(740, 34);
            this.lblCONS_CodLNG.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONS_CodLNG.Name = "lblCONS_CodLNG";
            this.lblCONS_CodLNG.Size = new System.Drawing.Size(81, 13);
            this.lblCONS_CodLNG.TabIndex = 8;
            this.lblCONS_CodLNG.Text = "Línea Negocio:";
            // 
            // cmbCONS_CodVia
            // 
            this.cmbCONS_CodVia.ConstantesSelectedItem = null;
            this.cmbCONS_CodVia.ConstantesSelectedValue = null;
            this.cmbCONS_CodVia.ConstantesTitulo = null;
            this.cmbCONS_CodVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCONS_CodVia.FormattingEnabled = true;
            this.cmbCONS_CodVia.Location = new System.Drawing.Point(517, 30);
            this.cmbCONS_CodVia.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbCONS_CodVia.Name = "cmbCONS_CodVia";
            this.cmbCONS_CodVia.Session = null;
            this.cmbCONS_CodVia.Size = new System.Drawing.Size(194, 21);
            this.cmbCONS_CodVia.TabIndex = 7;
            this.cmbCONS_CodVia.Tag = "CONS_CodViaMSGERROR";
            // 
            // lblCONS_CodVia
            // 
            this.lblCONS_CodVia.AutoSize = true;
            this.lblCONS_CodVia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodVia.Location = new System.Drawing.Point(375, 34);
            this.lblCONS_CodVia.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblCONS_CodVia.Name = "lblCONS_CodVia";
            this.lblCONS_CodVia.Size = new System.Drawing.Size(30, 13);
            this.lblCONS_CodVia.TabIndex = 6;
            this.lblCONS_CodVia.Text = "Vía:";
            // 
            // cmbCONS_CodRGM
            // 
            this.cmbCONS_CodRGM.ConstantesSelectedItem = null;
            this.cmbCONS_CodRGM.ConstantesSelectedValue = null;
            this.cmbCONS_CodRGM.ConstantesTitulo = null;
            this.cmbCONS_CodRGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCONS_CodRGM.FormattingEnabled = true;
            this.cmbCONS_CodRGM.Location = new System.Drawing.Point(153, 30);
            this.cmbCONS_CodRGM.Name = "cmbCONS_CodRGM";
            this.cmbCONS_CodRGM.Session = null;
            this.cmbCONS_CodRGM.Size = new System.Drawing.Size(194, 21);
            this.cmbCONS_CodRGM.TabIndex = 5;
            // 
            // lblCONS_CodRGM
            // 
            this.lblCONS_CodRGM.AutoSize = true;
            this.lblCONS_CodRGM.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodRGM.Location = new System.Drawing.Point(10, 34);
            this.lblCONS_CodRGM.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONS_CodRGM.Name = "lblCONS_CodRGM";
            this.lblCONS_CodRGM.Size = new System.Drawing.Size(62, 13);
            this.lblCONS_CodRGM.TabIndex = 4;
            this.lblCONS_CodRGM.Text = "Régimen:";
            // 
            // NVIA_NroViaje
            // 
            this.NVIA_NroViaje.Location = new System.Drawing.Point(518, 57);
            this.NVIA_NroViaje.MaxLength = 50;
            this.NVIA_NroViaje.Name = "NVIA_NroViaje";
            this.NVIA_NroViaje.Size = new System.Drawing.Size(194, 20);
            this.NVIA_NroViaje.TabIndex = 13;
            this.NVIA_NroViaje.Tag = "NVIA_NroViajeMSGERROR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(375, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nro: Viaje:";
            // 
            // txtTipoAsiento
            // 
            this.txtTipoAsiento.Location = new System.Drawing.Point(883, 3);
            this.txtTipoAsiento.Name = "txtTipoAsiento";
            this.txtTipoAsiento.Size = new System.Drawing.Size(194, 20);
            this.txtTipoAsiento.TabIndex = 5;
            // 
            // txtTipoLibro
            // 
            this.txtTipoLibro.Location = new System.Drawing.Point(518, 3);
            this.txtTipoLibro.Name = "txtTipoLibro";
            this.txtTipoLibro.Size = new System.Drawing.Size(194, 20);
            this.txtTipoLibro.TabIndex = 3;
            // 
            // lblRegistro_1
            // 
            this.lblRegistro_1.AutoSize = true;
            this.lblRegistro_1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro_1.Location = new System.Drawing.Point(375, 7);
            this.lblRegistro_1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblRegistro_1.Name = "lblRegistro_1";
            this.lblRegistro_1.Size = new System.Drawing.Size(108, 13);
            this.lblRegistro_1.TabIndex = 2;
            this.lblRegistro_1.Text = "Registro  / Libro :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(740, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de Asiento :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Periodo (Año) :";
            // 
            // TitleView
            // 
            this.TitleView.AllowActive = false;
            this.TitleView.AntiAlias = false;
            this.TitleView.Caption = "GENERAR ASIENTOS DE STATEMENT";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(1106, 26);
            this.TitleView.TabIndex = 0;
            // 
            // panelCaption2
            // 
            this.panelCaption2.AllowActive = false;
            this.panelCaption2.AntiAlias = false;
            this.panelCaption2.Caption = "Resultado de Busqueda";
            this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption2.Location = new System.Drawing.Point(0, 236);
            this.panelCaption2.Name = "panelCaption2";
            this.panelCaption2.Size = new System.Drawing.Size(1106, 26);
            this.panelCaption2.TabIndex = 6;
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
            this.navItems.Size = new System.Drawing.Size(1106, 25);
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
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Location = new System.Drawing.Point(0, 262);
            this.grdItems.Name = "grdItems";
            // 
            // 
            // 
            this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 262, 240, 150);
            this.grdItems.Size = new System.Drawing.Size(1106, 163);
            this.grdItems.TabIndex = 7;
            this.grdItems.TabStop = false;
            this.grdItems.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdItems_MouseClick);
            // 
            // panelCaption3
            // 
            this.panelCaption3.AllowActive = false;
            this.panelCaption3.AntiAlias = false;
            this.panelCaption3.Caption = "Opciones del Generción de Asiento";
            this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption3.Location = new System.Drawing.Point(0, 183);
            this.panelCaption3.Name = "panelCaption3";
            this.panelCaption3.Size = new System.Drawing.Size(1106, 26);
            this.panelCaption3.TabIndex = 4;
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
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblRegistro_1, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtTipoLibro, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtTipoAsiento, 7, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 209);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1106, 27);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(153, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(194, 20);
            this.textBox1.TabIndex = 4;
            // 
            // CMSseleccion
            // 
            this.CMSseleccion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marcarTodosToolStripMenuItem,
            this.desmarcarTodosToolStripMenuItem,
            this.marcarSeleccionadosToolStripMenuItem,
            this.desmarcarSeleccionadosToolStripMenuItem});
            this.CMSseleccion.Name = "CMSseleccion";
            this.CMSseleccion.Size = new System.Drawing.Size(209, 92);
            // 
            // marcarTodosToolStripMenuItem
            // 
            this.marcarTodosToolStripMenuItem.Name = "marcarTodosToolStripMenuItem";
            this.marcarTodosToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.marcarTodosToolStripMenuItem.Text = "Marcar Todos";
            this.marcarTodosToolStripMenuItem.Click += new System.EventHandler(this.tsmMarcarTodos_Click);
            // 
            // desmarcarTodosToolStripMenuItem
            // 
            this.desmarcarTodosToolStripMenuItem.Name = "desmarcarTodosToolStripMenuItem";
            this.desmarcarTodosToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.desmarcarTodosToolStripMenuItem.Text = "Desmarcar Todos";
            this.desmarcarTodosToolStripMenuItem.Click += new System.EventHandler(this.tsmDesmarcarTodos_Click);
            // 
            // marcarSeleccionadosToolStripMenuItem
            // 
            this.marcarSeleccionadosToolStripMenuItem.Name = "marcarSeleccionadosToolStripMenuItem";
            this.marcarSeleccionadosToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.marcarSeleccionadosToolStripMenuItem.Text = "Marcar Seleccionados";
            this.marcarSeleccionadosToolStripMenuItem.Click += new System.EventHandler(this.tsmMarcarSeleccionados_Click);
            // 
            // desmarcarSeleccionadosToolStripMenuItem
            // 
            this.desmarcarSeleccionadosToolStripMenuItem.Name = "desmarcarSeleccionadosToolStripMenuItem";
            this.desmarcarSeleccionadosToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.desmarcarSeleccionadosToolStripMenuItem.Text = "Desmarcar Seleccionados";
            this.desmarcarSeleccionadosToolStripMenuItem.Click += new System.EventHandler(this.tsmDesmarcarSeleccionados_Click);
            // 
            // CAJ018AsientosStatementLView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.panelCaption2);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelCaption3);
            this.Controls.Add(this.navItems);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.pnBotones);
            this.Controls.Add(this.TitleView);
            this.Name = "CAJ018AsientosStatementLView";
            this.Size = new System.Drawing.Size(1106, 450);
            this.cmsMenu.ResumeLayout(false);
            this.pnBotones.ResumeLayout(false);
            this.pnBotones.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
            this.navItems.ResumeLayout(false);
            this.navItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.CMSseleccion.ResumeLayout(false);
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
      private System.Windows.Forms.Button btnProcesarAsientos;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinForms.Controls.FormTitle TitleView;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecFin;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecIni;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label lblRegistro_1;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox txtTipoAsiento;
      private System.Windows.Forms.TextBox txtTipoLibro;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
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
      private Telerik.WinControls.UI.RadGridView grdItems;
      private System.Windows.Forms.Label lblCONS_CodRGM;
      private Controls.Tipos.ComboBoxConstantes cmbCONS_CodRGM;
      private System.Windows.Forms.Label lblCONS_CodVia;
      private Controls.Tipos.ComboBoxConstantes cmbCONS_CodVia;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Label lblCONS_CodLNG;
      private Controls.Tipos.ComboBoxConstantes cmbCONS_CodLNG;
      private System.Windows.Forms.Button btnBuscar;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox NVIA_NroViaje;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.ComboBox NAVE_Codigo;
      private System.Windows.Forms.ContextMenuStrip CMSseleccion;
      private System.Windows.Forms.ToolStripMenuItem marcarTodosToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem desmarcarTodosToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem marcarSeleccionadosToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem desmarcarSeleccionadosToolStripMenuItem;

   }
}
