namespace Delfin.Principal
{
   partial class PRO006LView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PRO006LView));
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmColumnas = new System.Windows.Forms.ToolStripMenuItem();
            this.pnBotones = new System.Windows.Forms.Panel();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panelCaption1 = new Infrastructure.WinFormsControls.PanelCaption();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mdtFecDesde = new Infrastructure.WinFormsControls.MaskDateTime();
            this.lblCONT_FecIni = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mdtFecHasta = new Infrastructure.WinFormsControls.MaskDateTime();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNave = new System.Windows.Forms.TextBox();
            this.panelCaption2 = new Infrastructure.WinFormsControls.PanelCaption();
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            this.TitleView = new Infrastructure.WinFormsControls.FormTitle();
            this.navItems = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsMenu.SuspendLayout();
            this.pnBotones.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.pnBotones.Controls.Add(this.btnDeshacer);
            this.pnBotones.Controls.Add(this.btnExportar);
            this.pnBotones.Controls.Add(this.btnBuscar);
            this.pnBotones.Controls.Add(this.btnNuevo);
            this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnBotones.Location = new System.Drawing.Point(0, 26);
            this.pnBotones.Name = "pnBotones";
            this.pnBotones.Size = new System.Drawing.Size(968, 50);
            this.pnBotones.TabIndex = 42;
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
            this.panelCaption1.Size = new System.Drawing.Size(968, 26);
            this.panelCaption1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 224F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 337F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.Controls.Add(this.mdtFecDesde, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCONT_FecIni, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNave, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(968, 27);
            this.tableLayoutPanel1.TabIndex = 2;
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
            this.mdtFecDesde.TabIndex = 13;
            // 
            // lblCONT_FecIni
            // 
            this.lblCONT_FecIni.AutoSize = true;
            this.lblCONT_FecIni.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONT_FecIni.Location = new System.Drawing.Point(10, 7);
            this.lblCONT_FecIni.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONT_FecIni.Name = "lblCONT_FecIni";
            this.lblCONT_FecIni.Size = new System.Drawing.Size(80, 13);
            this.lblCONT_FecIni.TabIndex = 12;
            this.lblCONT_FecIni.Text = "Fecha Inicio:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mdtFecHasta);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(266, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 21);
            this.panel1.TabIndex = 14;
            // 
            // mdtFecHasta
            // 
            this.mdtFecHasta.Location = new System.Drawing.Point(107, -1);
            this.mdtFecHasta.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFecHasta.Name = "mdtFecHasta";
            this.mdtFecHasta.NSActiveMouse = false;
            this.mdtFecHasta.NSActiveMsgFecha = false;
            this.mdtFecHasta.NSChangeDate = true;
            this.mdtFecHasta.NSDigitos = 4;
            this.mdtFecHasta.NSFecha = null;
            this.mdtFecHasta.NSSetDateNow = false;
            this.mdtFecHasta.Size = new System.Drawing.Size(100, 22);
            this.mdtFecHasta.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fecha Fin:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(512, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nave:";
            // 
            // txtNave
            // 
            this.txtNave.Location = new System.Drawing.Point(615, 3);
            this.txtNave.Name = "txtNave";
            this.txtNave.Size = new System.Drawing.Size(193, 20);
            this.txtNave.TabIndex = 15;
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
            this.panelCaption2.Location = new System.Drawing.Point(0, 129);
            this.panelCaption2.Name = "panelCaption2";
            this.panelCaption2.Size = new System.Drawing.Size(968, 26);
            this.panelCaption2.TabIndex = 3;
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Location = new System.Drawing.Point(0, 155);
            this.grdItems.Name = "grdItems";
            // 
            // 
            // 
            this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 155, 240, 150);
            this.grdItems.Size = new System.Drawing.Size(968, 377);
            this.grdItems.TabIndex = 4;
            this.grdItems.TabStop = false;
            // 
            // TitleView
            // 
            this.TitleView.AllowActive = false;
            this.TitleView.AntiAlias = false;
            this.TitleView.Caption = "SEGUIMIENTOS";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(968, 26);
            this.TitleView.TabIndex = 0;
            // 
            // navItems
            // 
            this.navItems.AddNewItem = null;
            this.navItems.BackColor = System.Drawing.Color.SteelBlue;
            this.navItems.CountItem = this.toolStripLabel4;
            this.navItems.DeleteItem = null;
            this.navItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton13,
            this.toolStripButton14,
            this.toolStripSeparator7,
            this.toolStripLabel4,
            this.toolStripTextBox4,
            this.toolStripSeparator8,
            this.toolStripButton15,
            this.toolStripButton16,
            this.bindingNavigatorSeparator2});
            this.navItems.Location = new System.Drawing.Point(0, 532);
            this.navItems.MoveFirstItem = this.toolStripButton13;
            this.navItems.MoveLastItem = this.toolStripButton16;
            this.navItems.MoveNextItem = this.toolStripButton15;
            this.navItems.MovePreviousItem = this.toolStripButton14;
            this.navItems.Name = "navItems";
            this.navItems.PositionItem = this.toolStripTextBox4;
            this.navItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.navItems.Size = new System.Drawing.Size(968, 25);
            this.navItems.TabIndex = 52;
            this.navItems.Text = "bindingNavigator1";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel4.Text = "of {0}";
            this.toolStripLabel4.ToolTipText = "Número total de elementos";
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.RightToLeftAutoMirrorImage = true;
            this.toolStripButton13.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton13.Text = "Mover primero";
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton14.Image")));
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.RightToLeftAutoMirrorImage = true;
            this.toolStripButton14.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton14.Text = "Mover anterior";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox4
            // 
            this.toolStripTextBox4.AccessibleName = "Posición";
            this.toolStripTextBox4.AutoSize = false;
            this.toolStripTextBox4.Name = "toolStripTextBox4";
            this.toolStripTextBox4.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox4.Text = "0";
            this.toolStripTextBox4.ToolTipText = "Posición actual";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton15
            // 
            this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton15.Image")));
            this.toolStripButton15.Name = "toolStripButton15";
            this.toolStripButton15.RightToLeftAutoMirrorImage = true;
            this.toolStripButton15.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton15.Text = "Mover siguiente";
            // 
            // toolStripButton16
            // 
            this.toolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton16.Image")));
            this.toolStripButton16.Name = "toolStripButton16";
            this.toolStripButton16.RightToLeftAutoMirrorImage = true;
            this.toolStripButton16.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton16.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // PRO006LView
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
            this.Name = "PRO006LView";
            this.Size = new System.Drawing.Size(968, 557);
            this.cmsMenu.ResumeLayout(false);
            this.pnBotones.ResumeLayout(false);
            this.pnBotones.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
      private System.Windows.Forms.Button btnExportar;
      private System.Windows.Forms.Button btnBuscar;
      private System.Windows.Forms.Button btnNuevo;
      private Infrastructure.WinFormsControls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinFormsControls.PanelCaption panelCaption2;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private Infrastructure.WinFormsControls.FormTitle TitleView;
      private System.Windows.Forms.Label lblCONT_FecIni;
      private Infrastructure.WinFormsControls.MaskDateTime mdtFecDesde;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Panel panel1;
      private Infrastructure.WinFormsControls.MaskDateTime mdtFecHasta;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox txtNave;
      private System.Windows.Forms.BindingNavigator navItems;
      private System.Windows.Forms.ToolStripLabel toolStripLabel4;
      private System.Windows.Forms.ToolStripButton toolStripButton13;
      private System.Windows.Forms.ToolStripButton toolStripButton14;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
      private System.Windows.Forms.ToolStripTextBox toolStripTextBox4;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
      private System.Windows.Forms.ToolStripButton toolStripButton15;
      private System.Windows.Forms.ToolStripButton toolStripButton16;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;

   }
}
