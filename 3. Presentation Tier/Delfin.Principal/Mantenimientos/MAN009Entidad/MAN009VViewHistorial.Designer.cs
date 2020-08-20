namespace Delfin.Principal.Mantenimientos.MAN009Entidad
{
   partial class MAN009VViewHistorial
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAN009VViewHistorial));
         this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnSalir = new System.Windows.Forms.Button();
         this.grdItemsLimiteCreditoCli = new Telerik.WinControls.UI.RadGridView();
         this.navItems = new System.Windows.Forms.BindingNavigator(this.components);
         this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
         this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
         this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
         this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
         this.panel3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsLimiteCreditoCli)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsLimiteCreditoCli.MasterTemplate)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
         this.navItems.SuspendLayout();
         this.SuspendLayout();
         // 
         // panelCaption3
         // 
         this.panelCaption3.AllowActive = false;
         this.panelCaption3.AntiAlias = false;
         this.panelCaption3.Caption = "Historial - {0}";
         this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption3.Location = new System.Drawing.Point(0, 50);
         this.panelCaption3.Name = "panelCaption3";
         this.panelCaption3.Size = new System.Drawing.Size(784, 26);
         this.panelCaption3.TabIndex = 3;
         // 
         // panel3
         // 
         this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
         this.panel3.Controls.Add(this.btnSalir);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel3.Location = new System.Drawing.Point(0, 0);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(784, 50);
         this.panel3.TabIndex = 2;
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
         this.btnSalir.Location = new System.Drawing.Point(0, 0);
         this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
         this.btnSalir.Name = "btnSalir";
         this.btnSalir.Size = new System.Drawing.Size(55, 50);
         this.btnSalir.TabIndex = 1;
         this.btnSalir.Text = "Salir";
         this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnSalir.UseVisualStyleBackColor = true;
         // 
         // grdItemsLimiteCreditoCli
         // 
         this.grdItemsLimiteCreditoCli.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItemsLimiteCreditoCli.Location = new System.Drawing.Point(0, 76);
         // 
         // grdItemsLimiteCreditoCli
         // 
         this.grdItemsLimiteCreditoCli.MasterTemplate.AllowCellContextMenu = false;
         this.grdItemsLimiteCreditoCli.MasterTemplate.AllowColumnChooser = false;
         this.grdItemsLimiteCreditoCli.MasterTemplate.AllowColumnReorder = false;
         this.grdItemsLimiteCreditoCli.Name = "grdItemsLimiteCreditoCli";
         this.grdItemsLimiteCreditoCli.Size = new System.Drawing.Size(784, 285);
         this.grdItemsLimiteCreditoCli.TabIndex = 4;
         this.grdItemsLimiteCreditoCli.TabStop = false;
         // 
         // navItems
         // 
         this.navItems.AddNewItem = null;
         this.navItems.BackColor = System.Drawing.Color.LightSteelBlue;
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
         this.navItems.Location = new System.Drawing.Point(0, 332);
         this.navItems.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
         this.navItems.MoveLastItem = this.bindingNavigatorMoveLastItem;
         this.navItems.MoveNextItem = this.bindingNavigatorMoveNextItem;
         this.navItems.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
         this.navItems.Name = "navItems";
         this.navItems.Padding = new System.Windows.Forms.Padding(3);
         this.navItems.PositionItem = this.bindingNavigatorPositionItem;
         this.navItems.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
         this.navItems.Size = new System.Drawing.Size(784, 29);
         this.navItems.TabIndex = 7;
         this.navItems.Text = "bindingNavigator1";
         // 
         // bindingNavigatorCountItem
         // 
         this.bindingNavigatorCountItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
         this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 20);
         this.bindingNavigatorCountItem.Text = "de {0}";
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
         // MAN009VViewHistorial
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 361);
         this.Controls.Add(this.navItems);
         this.Controls.Add(this.grdItemsLimiteCreditoCli);
         this.Controls.Add(this.panelCaption3);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "MAN009VViewHistorial";
         this.Text = "MAN009VViewHistorial";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsLimiteCreditoCli.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsLimiteCreditoCli)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
         this.navItems.ResumeLayout(false);
         this.navItems.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private Telerik.WinControls.UI.RadGridView grdItemsLimiteCreditoCli;
      private System.Windows.Forms.BindingNavigator navItems;
      private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
      private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
   }
}