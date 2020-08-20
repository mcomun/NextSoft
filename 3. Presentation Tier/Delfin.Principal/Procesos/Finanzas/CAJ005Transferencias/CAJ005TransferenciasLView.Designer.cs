namespace Delfin.Principal
{
   partial class CAJ005TransferenciasLView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAJ005TransferenciasLView));
         this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.tsmColumnas = new System.Windows.Forms.ToolStripMenuItem();
         this.pnBotones = new System.Windows.Forms.Panel();
         this.btnExportar = new System.Windows.Forms.Button();
         this.btnDeshacer = new System.Windows.Forms.Button();
         this.btnBuscar = new System.Windows.Forms.Button();
         this.btnNuevoReducido = new System.Windows.Forms.Button();
         this.btnNuevo = new System.Windows.Forms.Button();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.txtTRAN_Codigo = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.dtpFecFin = new Infrastructure.WinForms.Controls.MaskTime();
         this.dtpFecIni = new Infrastructure.WinForms.Controls.MaskTime();
         this.label3 = new System.Windows.Forms.Label();
         this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.grdItems = new Telerik.WinControls.UI.RadGridView();
         this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
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
         this.cmsMenu.SuspendLayout();
         this.pnBotones.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
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
         this.pnBotones.Controls.Add(this.btnExportar);
         this.pnBotones.Controls.Add(this.btnDeshacer);
         this.pnBotones.Controls.Add(this.btnBuscar);
         this.pnBotones.Controls.Add(this.btnNuevoReducido);
         this.pnBotones.Controls.Add(this.btnNuevo);
         this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
         this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.pnBotones.Location = new System.Drawing.Point(0, 26);
         this.pnBotones.Name = "pnBotones";
         this.pnBotones.Size = new System.Drawing.Size(900, 50);
         this.pnBotones.TabIndex = 42;
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
         this.btnExportar.Location = new System.Drawing.Point(283, 0);
         this.btnExportar.Margin = new System.Windows.Forms.Padding(0);
         this.btnExportar.Name = "btnExportar";
         this.btnExportar.Size = new System.Drawing.Size(58, 50);
         this.btnExportar.TabIndex = 4;
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
         this.btnDeshacer.Location = new System.Drawing.Point(218, 0);
         this.btnDeshacer.Margin = new System.Windows.Forms.Padding(0);
         this.btnDeshacer.Name = "btnDeshacer";
         this.btnDeshacer.Size = new System.Drawing.Size(65, 50);
         this.btnDeshacer.TabIndex = 3;
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
         this.btnBuscar.Location = new System.Drawing.Point(163, 0);
         this.btnBuscar.Margin = new System.Windows.Forms.Padding(0);
         this.btnBuscar.Name = "btnBuscar";
         this.btnBuscar.Size = new System.Drawing.Size(55, 50);
         this.btnBuscar.TabIndex = 1;
         this.btnBuscar.Text = "&Buscar";
         this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnBuscar.UseVisualStyleBackColor = true;
         // 
         // btnNuevoReducido
         // 
         this.btnNuevoReducido.AutoSize = true;
         this.btnNuevoReducido.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnNuevoReducido.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
         this.btnNuevoReducido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnNuevoReducido.ForeColor = System.Drawing.Color.Black;
         this.btnNuevoReducido.Image = global::Delfin.Principal.Properties.Resources.add;
         this.btnNuevoReducido.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnNuevoReducido.Location = new System.Drawing.Point(57, 0);
         this.btnNuevoReducido.Margin = new System.Windows.Forms.Padding(0);
         this.btnNuevoReducido.Name = "btnNuevoReducido";
         this.btnNuevoReducido.Size = new System.Drawing.Size(106, 50);
         this.btnNuevoReducido.TabIndex = 5;
         this.btnNuevoReducido.Text = "&Nuevo (Reducido)";
         this.btnNuevoReducido.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnNuevoReducido.UseVisualStyleBackColor = true;
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
         this.panelCaption1.Size = new System.Drawing.Size(900, 26);
         this.panelCaption1.TabIndex = 45;
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
         this.tableLayoutPanel1.Controls.Add(this.txtTRAN_Codigo, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
         this.tableLayoutPanel1.Controls.Add(this.dtpFecFin, 4, 1);
         this.tableLayoutPanel1.Controls.Add(this.dtpFecIni, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 54);
         this.tableLayoutPanel1.TabIndex = 46;
         // 
         // txtTRAN_Codigo
         // 
         this.txtTRAN_Codigo.Location = new System.Drawing.Point(153, 3);
         this.txtTRAN_Codigo.MaxLength = 10;
         this.txtTRAN_Codigo.Name = "txtTRAN_Codigo";
         this.txtTRAN_Codigo.Size = new System.Drawing.Size(194, 20);
         this.txtTRAN_Codigo.TabIndex = 7;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(10, 7);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(58, 13);
         this.label4.TabIndex = 6;
         this.label4.Text = "Interno :";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(375, 34);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(133, 13);
         this.label2.TabIndex = 5;
         this.label2.Text = "Fecha Emisión Hasta :";
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
         this.dtpFecFin.TabIndex = 5;
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
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(10, 34);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(137, 13);
         this.label3.TabIndex = 5;
         this.label3.Text = "Fecha Emisión Desde :";
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
         this.panelCaption2.Size = new System.Drawing.Size(900, 26);
         this.panelCaption2.TabIndex = 47;
         // 
         // grdItems
         // 
         this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItems.Location = new System.Drawing.Point(0, 182);
         this.grdItems.Name = "grdItems";
         // 
         // 
         // 
         this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 182, 240, 150);
         this.grdItems.Size = new System.Drawing.Size(900, 243);
         this.grdItems.TabIndex = 50;
         this.grdItems.TabStop = false;
         // 
         // TitleView
         // 
         this.TitleView.AllowActive = false;
         this.TitleView.AntiAlias = false;
         this.TitleView.Caption = "TRANSFERENCIA DE CUENTAS PROPIAS";
         this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
         this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
         this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.TitleView.Location = new System.Drawing.Point(0, 0);
         this.TitleView.Name = "TitleView";
         this.TitleView.Size = new System.Drawing.Size(900, 26);
         this.TitleView.TabIndex = 51;
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
         this.navItems.Size = new System.Drawing.Size(900, 25);
         this.navItems.TabIndex = 53;
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
         // CAJ005TransferenciasLView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.Controls.Add(this.grdItems);
         this.Controls.Add(this.navItems);
         this.Controls.Add(this.panelCaption2);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.pnBotones);
         this.Controls.Add(this.TitleView);
         this.Name = "CAJ005TransferenciasLView";
         this.Size = new System.Drawing.Size(900, 450);
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
      private System.Windows.Forms.Button btnNuevo;
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
      private System.Windows.Forms.Button btnExportar;
      private System.Windows.Forms.Label label3;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecFin;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecIni;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox txtTRAN_Codigo;
      private System.Windows.Forms.Button btnNuevoReducido;

   }
}
