namespace Delfin.Principal
{
   partial class MAN003LView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAN003LView));
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
            this.pnBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
            this.navItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
            this.cmsMenu.SuspendLayout();
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
            this.btnMAN_Deshacer.Image = global::Delfin.Principal.Properties.Resources.undo;
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
            this.btnMAN_Exportar.Image = global::Delfin.Principal.Properties.Resources.export;
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
            this.btnMAN_Buscar.Image = global::Delfin.Principal.Properties.Resources.search;
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
            this.btnMAN_Nuevo.Image = global::Delfin.Principal.Properties.Resources.add;
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
            this.TitleView.Caption = "MANTENIMIENTO DE RESULTADO DE GESTIÓN";
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
            this.panelCaption2.Location = new System.Drawing.Point(0, 76);
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
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
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
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMovePreviousItem.Text = "Anterior";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveFirstItem.Text = "Primero";
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Location = new System.Drawing.Point(0, 102);
            this.grdItems.Name = "grdItems";
            // 
            // 
            // 
            this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 102, 240, 150);
            this.grdItems.Size = new System.Drawing.Size(900, 319);
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
            // MAN003LView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.navItems);
            this.Controls.Add(this.panelCaption2);
            this.Controls.Add(this.pnBotones);
            this.Controls.Add(this.TitleView);
            this.Name = "MAN003LView";
            this.Size = new System.Drawing.Size(900, 450);
            this.pnBotones.ResumeLayout(false);
            this.pnBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
            this.navItems.ResumeLayout(false);
            this.navItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            this.cmsMenu.ResumeLayout(false);
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
   }
}
