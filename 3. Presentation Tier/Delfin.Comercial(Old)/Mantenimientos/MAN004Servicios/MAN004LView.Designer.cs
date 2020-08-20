namespace Delfin.Comercial
{
   partial class MAN004LView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAN004LView));
            this.pnBotones = new System.Windows.Forms.Panel();
            this.btnMAN_Deshacer = new System.Windows.Forms.Button();
            this.btnMAN_Exportar = new System.Windows.Forms.Button();
            this.btnMAN_Buscar = new System.Windows.Forms.Button();
            this.btnMAN_Nuevo = new System.Windows.Forms.Button();
            this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
            this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.navItems = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmColumnas = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SERV_AfeDet = new System.Windows.Forms.CheckBox();
            this.SERV_AfeIgv = new System.Windows.Forms.CheckBox();
            this.lblCONS_CodRGM = new System.Windows.Forms.Label();
            this.lblCONS_CodVia = new System.Windows.Forms.Label();
            this.CONS_CodRGM = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.CONS_CodVia = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblSERV_AfeIgv = new System.Windows.Forms.Label();
            this.lblSERV_AfeDet = new System.Windows.Forms.Label();
            this.CONS_CodLNG = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.SERV_TipoMov = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.pnBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
            this.navItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
            this.cmsMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBotones
            // 
            this.pnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnBotones.Controls.Add(this.btnMAN_Deshacer);
            this.pnBotones.Controls.Add(this.btnMAN_Exportar);
            this.pnBotones.Controls.Add(this.btnMAN_Buscar);
            this.pnBotones.Controls.Add(this.btnMAN_Nuevo);
            this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnBotones.Location = new System.Drawing.Point(0, 26);
            this.pnBotones.Name = "pnBotones";
            this.pnBotones.Size = new System.Drawing.Size(900, 50);
            this.pnBotones.TabIndex = 27;
            // 
            // btnMAN_Deshacer
            // 
            this.btnMAN_Deshacer.AutoSize = true;
            this.btnMAN_Deshacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMAN_Deshacer.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnMAN_Deshacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMAN_Deshacer.ForeColor = System.Drawing.Color.Black;
            this.btnMAN_Deshacer.Image = global::Delfin.Comercial.Properties.Resources.undo;
            this.btnMAN_Deshacer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMAN_Deshacer.Location = new System.Drawing.Point(170, 0);
            this.btnMAN_Deshacer.Margin = new System.Windows.Forms.Padding(0);
            this.btnMAN_Deshacer.Name = "btnMAN_Deshacer";
            this.btnMAN_Deshacer.Size = new System.Drawing.Size(65, 50);
            this.btnMAN_Deshacer.TabIndex = 3;
            this.btnMAN_Deshacer.Text = "&Deshacer";
            this.btnMAN_Deshacer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMAN_Deshacer.UseVisualStyleBackColor = true;
            // 
            // btnMAN_Exportar
            // 
            this.btnMAN_Exportar.AutoSize = true;
            this.btnMAN_Exportar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMAN_Exportar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnMAN_Exportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMAN_Exportar.ForeColor = System.Drawing.Color.Black;
            this.btnMAN_Exportar.Image = global::Delfin.Comercial.Properties.Resources.export;
            this.btnMAN_Exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMAN_Exportar.Location = new System.Drawing.Point(112, 0);
            this.btnMAN_Exportar.Margin = new System.Windows.Forms.Padding(0);
            this.btnMAN_Exportar.Name = "btnMAN_Exportar";
            this.btnMAN_Exportar.Size = new System.Drawing.Size(58, 50);
            this.btnMAN_Exportar.TabIndex = 2;
            this.btnMAN_Exportar.Text = "&Exportar";
            this.btnMAN_Exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMAN_Exportar.UseVisualStyleBackColor = true;
            // 
            // btnMAN_Buscar
            // 
            this.btnMAN_Buscar.AutoSize = true;
            this.btnMAN_Buscar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMAN_Buscar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnMAN_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMAN_Buscar.ForeColor = System.Drawing.Color.Black;
            this.btnMAN_Buscar.Image = global::Delfin.Comercial.Properties.Resources.search;
            this.btnMAN_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMAN_Buscar.Location = new System.Drawing.Point(57, 0);
            this.btnMAN_Buscar.Margin = new System.Windows.Forms.Padding(0);
            this.btnMAN_Buscar.Name = "btnMAN_Buscar";
            this.btnMAN_Buscar.Size = new System.Drawing.Size(55, 50);
            this.btnMAN_Buscar.TabIndex = 1;
            this.btnMAN_Buscar.Text = "&Buscar";
            this.btnMAN_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMAN_Buscar.UseVisualStyleBackColor = true;
            // 
            // btnMAN_Nuevo
            // 
            this.btnMAN_Nuevo.AutoSize = true;
            this.btnMAN_Nuevo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMAN_Nuevo.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnMAN_Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMAN_Nuevo.ForeColor = System.Drawing.Color.Black;
            this.btnMAN_Nuevo.Image = global::Delfin.Comercial.Properties.Resources.add;
            this.btnMAN_Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMAN_Nuevo.Location = new System.Drawing.Point(0, 0);
            this.btnMAN_Nuevo.Margin = new System.Windows.Forms.Padding(0);
            this.btnMAN_Nuevo.Name = "btnMAN_Nuevo";
            this.btnMAN_Nuevo.Size = new System.Drawing.Size(57, 50);
            this.btnMAN_Nuevo.TabIndex = 0;
            this.btnMAN_Nuevo.Text = "&Nuevo";
            this.btnMAN_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMAN_Nuevo.UseVisualStyleBackColor = true;
            // 
            // TitleView
            // 
            this.TitleView.AllowActive = false;
            this.TitleView.AntiAlias = false;
            this.TitleView.Caption = "MANTENIMIENTO DE SERVICIOS";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(900, 26);
            this.TitleView.TabIndex = 40;
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
            this.panelCaption2.Location = new System.Drawing.Point(0, 183);
            this.panelCaption2.Name = "panelCaption2";
            this.panelCaption2.Size = new System.Drawing.Size(900, 26);
            this.panelCaption2.TabIndex = 46;
            // 
            // navItems
            // 
            this.navItems.AddNewItem = null;
            this.navItems.BackColor = System.Drawing.Color.SteelBlue;
            this.navItems.CountItem = this.bindingNavigatorCountItem;
            this.navItems.DeleteItem = null;
            this.navItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navItems.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.navItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorMoveFirstItem});
            this.navItems.Location = new System.Drawing.Point(0, 421);
            this.navItems.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.navItems.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.navItems.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.navItems.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.navItems.Name = "navItems";
            this.navItems.Padding = new System.Windows.Forms.Padding(3);
            this.navItems.PositionItem = this.bindingNavigatorPositionItem;
            this.navItems.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.navItems.Size = new System.Drawing.Size(900, 29);
            this.navItems.TabIndex = 48;
            this.navItems.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 20);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Siguiente";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 23);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición Actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMovePreviousItem.Text = "Anterior";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveFirstItem.Text = "Primero";
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Location = new System.Drawing.Point(0, 209);
            this.grdItems.Name = "grdItems";
            // 
            // 
            // 
            this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 209, 240, 150);
            this.grdItems.Size = new System.Drawing.Size(900, 212);
            this.grdItems.TabIndex = 49;
            this.grdItems.TabStop = false;
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
            this.tableLayoutPanel1.Controls.Add(this.SERV_AfeDet, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.SERV_AfeIgv, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCONS_CodRGM, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCONS_CodVia, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.CONS_CodRGM, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.CONS_CodVia, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label11, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSERV_AfeIgv, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSERV_AfeDet, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.CONS_CodLNG, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.SERV_TipoMov, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 81);
            this.tableLayoutPanel1.TabIndex = 51;
            // 
            // SERV_AfeDet
            // 
            this.SERV_AfeDet.AutoSize = true;
            this.SERV_AfeDet.Dock = System.Windows.Forms.DockStyle.Left;
            this.SERV_AfeDet.Location = new System.Drawing.Point(518, 57);
            this.SERV_AfeDet.Name = "SERV_AfeDet";
            this.SERV_AfeDet.Size = new System.Drawing.Size(15, 21);
            this.SERV_AfeDet.TabIndex = 56;
            this.SERV_AfeDet.Tag = "SERV_AfeDetMSGERROR";
            this.SERV_AfeDet.UseVisualStyleBackColor = true;
            // 
            // SERV_AfeIgv
            // 
            this.SERV_AfeIgv.AutoSize = true;
            this.SERV_AfeIgv.Dock = System.Windows.Forms.DockStyle.Left;
            this.SERV_AfeIgv.Location = new System.Drawing.Point(153, 57);
            this.SERV_AfeIgv.Name = "SERV_AfeIgv";
            this.SERV_AfeIgv.Size = new System.Drawing.Size(15, 21);
            this.SERV_AfeIgv.TabIndex = 55;
            this.SERV_AfeIgv.Tag = "SERV_AfeIgvMSGERROR";
            this.SERV_AfeIgv.UseVisualStyleBackColor = true;
            // 
            // lblCONS_CodRGM
            // 
            this.lblCONS_CodRGM.AutoSize = true;
            this.lblCONS_CodRGM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodRGM.Location = new System.Drawing.Point(10, 7);
            this.lblCONS_CodRGM.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONS_CodRGM.Name = "lblCONS_CodRGM";
            this.lblCONS_CodRGM.Size = new System.Drawing.Size(62, 13);
            this.lblCONS_CodRGM.TabIndex = 25;
            this.lblCONS_CodRGM.Text = "Régimen:";
            // 
            // lblCONS_CodVia
            // 
            this.lblCONS_CodVia.AutoSize = true;
            this.lblCONS_CodVia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodVia.Location = new System.Drawing.Point(375, 7);
            this.lblCONS_CodVia.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONS_CodVia.Name = "lblCONS_CodVia";
            this.lblCONS_CodVia.Size = new System.Drawing.Size(30, 13);
            this.lblCONS_CodVia.TabIndex = 27;
            this.lblCONS_CodVia.Text = "Vía:";
            // 
            // CONS_CodRGM
            // 
            this.CONS_CodRGM.ConstantesSelectedItem = null;
            this.CONS_CodRGM.ConstantesSelectedValue = null;
            this.CONS_CodRGM.ConstantesTitulo = null;
            this.CONS_CodRGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CONS_CodRGM.FormattingEnabled = true;
            this.CONS_CodRGM.Location = new System.Drawing.Point(153, 3);
            this.CONS_CodRGM.Name = "CONS_CodRGM";
            this.CONS_CodRGM.Session = null;
            this.CONS_CodRGM.Size = new System.Drawing.Size(194, 21);
            this.CONS_CodRGM.TabIndex = 26;
            this.CONS_CodRGM.Tag = "CONS_CodRGMMSGERROR";
            // 
            // CONS_CodVia
            // 
            this.CONS_CodVia.ConstantesSelectedItem = null;
            this.CONS_CodVia.ConstantesSelectedValue = null;
            this.CONS_CodVia.ConstantesTitulo = null;
            this.CONS_CodVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CONS_CodVia.FormattingEnabled = true;
            this.CONS_CodVia.Location = new System.Drawing.Point(518, 3);
            this.CONS_CodVia.Name = "CONS_CodVia";
            this.CONS_CodVia.Session = null;
            this.CONS_CodVia.Size = new System.Drawing.Size(194, 21);
            this.CONS_CodVia.TabIndex = 28;
            this.CONS_CodVia.Tag = "CONS_CodViaMSGERROR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Línea de Negocio:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(375, 34);
            this.label11.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Costos / Ingresos:";
            // 
            // lblSERV_AfeIgv
            // 
            this.lblSERV_AfeIgv.AutoSize = true;
            this.lblSERV_AfeIgv.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSERV_AfeIgv.Location = new System.Drawing.Point(10, 61);
            this.lblSERV_AfeIgv.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblSERV_AfeIgv.Name = "lblSERV_AfeIgv";
            this.lblSERV_AfeIgv.Size = new System.Drawing.Size(95, 13);
            this.lblSERV_AfeIgv.TabIndex = 52;
            this.lblSERV_AfeIgv.Text = "Gravado I.G.V:";
            // 
            // lblSERV_AfeDet
            // 
            this.lblSERV_AfeDet.AutoSize = true;
            this.lblSERV_AfeDet.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSERV_AfeDet.Location = new System.Drawing.Point(375, 61);
            this.lblSERV_AfeDet.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblSERV_AfeDet.Name = "lblSERV_AfeDet";
            this.lblSERV_AfeDet.Size = new System.Drawing.Size(113, 13);
            this.lblSERV_AfeDet.TabIndex = 54;
            this.lblSERV_AfeDet.Text = "Afecto Detracción:";
            // 
            // CONS_CodLNG
            // 
            this.CONS_CodLNG.ConstantesSelectedItem = null;
            this.CONS_CodLNG.ConstantesSelectedValue = null;
            this.CONS_CodLNG.ConstantesTitulo = null;
            this.CONS_CodLNG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CONS_CodLNG.FormattingEnabled = true;
            this.CONS_CodLNG.Location = new System.Drawing.Point(153, 30);
            this.CONS_CodLNG.Name = "CONS_CodLNG";
            this.CONS_CodLNG.Session = null;
            this.CONS_CodLNG.Size = new System.Drawing.Size(194, 21);
            this.CONS_CodLNG.TabIndex = 57;
            // 
            // SERV_TipoMov
            // 
            this.SERV_TipoMov.ConstantesSelectedItem = null;
            this.SERV_TipoMov.ConstantesSelectedValue = null;
            this.SERV_TipoMov.ConstantesTitulo = null;
            this.SERV_TipoMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SERV_TipoMov.FormattingEnabled = true;
            this.SERV_TipoMov.Location = new System.Drawing.Point(518, 30);
            this.SERV_TipoMov.Name = "SERV_TipoMov";
            this.SERV_TipoMov.Session = null;
            this.SERV_TipoMov.Size = new System.Drawing.Size(194, 21);
            this.SERV_TipoMov.TabIndex = 58;
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
            this.panelCaption1.TabIndex = 50;
            // 
            // MAN004LView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.panelCaption2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.navItems);
            this.Controls.Add(this.pnBotones);
            this.Controls.Add(this.TitleView);
            this.Name = "MAN004LView";
            this.Size = new System.Drawing.Size(900, 450);
            this.pnBotones.ResumeLayout(false);
            this.pnBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
            this.navItems.ResumeLayout(false);
            this.navItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            this.cmsMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel pnBotones;
      private System.Windows.Forms.Button btnMAN_Deshacer;
      private System.Windows.Forms.Button btnMAN_Exportar;
      private System.Windows.Forms.Button btnMAN_Buscar;
      private System.Windows.Forms.Button btnMAN_Nuevo;
      private Infrastructure.WinForms.Controls.FormTitle TitleView;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
      private System.Windows.Forms.BindingNavigator navItems;
      private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
      private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private System.Windows.Forms.ContextMenuStrip cmsMenu;
      private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem tsmColumnas;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.Label lblCONS_CodRGM;
      private System.Windows.Forms.Label lblCONS_CodVia;
      private Controls.Tipos.ComboBoxConstantes CONS_CodRGM;
      private Controls.Tipos.ComboBoxConstantes CONS_CodVia;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label lblSERV_AfeIgv;
      private System.Windows.Forms.Label lblSERV_AfeDet;
      private System.Windows.Forms.CheckBox SERV_AfeIgv;
      private System.Windows.Forms.CheckBox SERV_AfeDet;
      private Controls.Tipos.ComboBoxConstantes CONS_CodLNG;
      private Controls.Tipos.ComboBoxConstantes SERV_TipoMov;
   }
}
