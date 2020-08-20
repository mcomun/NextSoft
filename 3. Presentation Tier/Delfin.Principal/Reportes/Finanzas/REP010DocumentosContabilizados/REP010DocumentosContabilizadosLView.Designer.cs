namespace Delfin.Principal
{
   partial class REP010DocumentosContabilizadosLView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REP010DocumentosContabilizadosLView));
         this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.cmbTipoResultado = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblTIPE_Codigo = new System.Windows.Forms.Label();
         this.dtpFecFin = new Infrastructure.WinForms.Controls.MaskTime();
         this.dtpFecIni = new Infrastructure.WinForms.Controls.MaskTime();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.pnBotones = new System.Windows.Forms.Panel();
         this.btnExportar = new System.Windows.Forms.Button();
         this.btnBuscar = new System.Windows.Forms.Button();
         this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
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
         this.grdItems = new Telerik.WinControls.UI.RadGridView();
         this.tableLayoutPanel1.SuspendLayout();
         this.pnBotones.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
         this.navItems.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
         this.SuspendLayout();
         // 
         // TitleView
         // 
         this.TitleView.AllowActive = false;
         this.TitleView.AntiAlias = false;
         this.TitleView.Caption = "Reporte de Documentos Generados";
         this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
         this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
         this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.TitleView.Location = new System.Drawing.Point(0, 0);
         this.TitleView.Name = "TitleView";
         this.TitleView.Size = new System.Drawing.Size(1102, 26);
         this.TitleView.TabIndex = 52;
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
         this.tableLayoutPanel1.Controls.Add(this.cmbTipoResultado, 7, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblTIPE_Codigo, 6, 0);
         this.tableLayoutPanel1.Controls.Add(this.dtpFecFin, 4, 0);
         this.tableLayoutPanel1.Controls.Add(this.dtpFecIni, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
         this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 1;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(1102, 27);
         this.tableLayoutPanel1.TabIndex = 55;
         // 
         // cmbTipoResultado
         // 
         this.cmbTipoResultado.ConstantesSelectedItem = null;
         this.cmbTipoResultado.ConstantesSelectedValue = null;
         this.cmbTipoResultado.ConstantesTitulo = null;
         this.cmbTipoResultado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTipoResultado.FormattingEnabled = true;
         this.cmbTipoResultado.Location = new System.Drawing.Point(883, 3);
         this.cmbTipoResultado.Name = "cmbTipoResultado";
         this.cmbTipoResultado.Session = null;
         this.cmbTipoResultado.Size = new System.Drawing.Size(194, 21);
         this.cmbTipoResultado.TabIndex = 8;
         // 
         // lblTIPE_Codigo
         // 
         this.lblTIPE_Codigo.AutoSize = true;
         this.lblTIPE_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPE_Codigo.Location = new System.Drawing.Point(740, 7);
         this.lblTIPE_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPE_Codigo.Name = "lblTIPE_Codigo";
         this.lblTIPE_Codigo.Size = new System.Drawing.Size(118, 13);
         this.lblTIPE_Codigo.TabIndex = 57;
         this.lblTIPE_Codigo.Text = "Tipo de Resultado :";
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
         this.dtpFecFin.TabIndex = 57;
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
         this.dtpFecIni.TabIndex = 57;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(375, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(115, 13);
         this.label1.TabIndex = 57;
         this.label1.Text = "Fecha Pref. Hasta :";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(10, 7);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(119, 13);
         this.label2.TabIndex = 57;
         this.label2.Text = "Fecha Pref. Desde :";
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
         this.panelCaption1.Size = new System.Drawing.Size(1102, 26);
         this.panelCaption1.TabIndex = 54;
         // 
         // pnBotones
         // 
         this.pnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
         this.pnBotones.Controls.Add(this.btnExportar);
         this.pnBotones.Controls.Add(this.btnBuscar);
         this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
         this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.pnBotones.Location = new System.Drawing.Point(0, 26);
         this.pnBotones.Name = "pnBotones";
         this.pnBotones.Size = new System.Drawing.Size(1102, 50);
         this.pnBotones.TabIndex = 53;
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
         this.btnExportar.Location = new System.Drawing.Point(55, 0);
         this.btnExportar.Margin = new System.Windows.Forms.Padding(0);
         this.btnExportar.Name = "btnExportar";
         this.btnExportar.Size = new System.Drawing.Size(81, 50);
         this.btnExportar.TabIndex = 7;
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
         this.btnBuscar.Location = new System.Drawing.Point(0, 0);
         this.btnBuscar.Margin = new System.Windows.Forms.Padding(0);
         this.btnBuscar.Name = "btnBuscar";
         this.btnBuscar.Size = new System.Drawing.Size(55, 50);
         this.btnBuscar.TabIndex = 1;
         this.btnBuscar.Text = "&Buscar";
         this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnBuscar.UseVisualStyleBackColor = true;
         // 
         // panelCaption2
         // 
         this.panelCaption2.AllowActive = false;
         this.panelCaption2.AntiAlias = false;
         this.panelCaption2.Caption = "Resultado de Búsqueda";
         this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption2.Location = new System.Drawing.Point(0, 129);
         this.panelCaption2.Name = "panelCaption2";
         this.panelCaption2.Size = new System.Drawing.Size(1102, 26);
         this.panelCaption2.TabIndex = 56;
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
         this.navItems.Location = new System.Drawing.Point(0, 392);
         this.navItems.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
         this.navItems.MoveLastItem = this.bindingNavigatorMoveLastItem1;
         this.navItems.MoveNextItem = this.bindingNavigatorMoveNextItem1;
         this.navItems.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
         this.navItems.Name = "navItems";
         this.navItems.PositionItem = this.bindingNavigatorPositionItem1;
         this.navItems.Size = new System.Drawing.Size(1102, 25);
         this.navItems.TabIndex = 57;
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
         this.grdItems.Location = new System.Drawing.Point(0, 155);
         this.grdItems.Name = "grdItems";
         // 
         // 
         // 
         this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 155, 240, 150);
         this.grdItems.Size = new System.Drawing.Size(1102, 237);
         this.grdItems.TabIndex = 58;
         this.grdItems.TabStop = false;
         // 
         // REP010DocumentosContabilizadosLView
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
         this.Name = "REP010DocumentosContabilizadosLView";
         this.Size = new System.Drawing.Size(1102, 417);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.pnBotones.ResumeLayout(false);
         this.pnBotones.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
         this.navItems.ResumeLayout(false);
         this.navItems.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Infrastructure.WinForms.Controls.FormTitle TitleView;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.Panel pnBotones;
      private System.Windows.Forms.Button btnBuscar;
      private System.Windows.Forms.Button btnExportar;
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
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecIni;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecFin;
      private Controls.Tipos.ComboBoxConstantes cmbTipoResultado;
      private System.Windows.Forms.Label lblTIPE_Codigo;
   }
}
