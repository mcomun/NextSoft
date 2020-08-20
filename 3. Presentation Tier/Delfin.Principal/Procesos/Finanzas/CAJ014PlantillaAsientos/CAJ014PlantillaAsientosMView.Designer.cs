namespace Delfin.Principal
{
   partial class CAJ014PlantillaAsientosMView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAJ014PlantillaAsientosMView));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.errorProviderCab_Cotizacion_OV = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderDet_Cotizacion_OV_Novedad = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorEventoTarea = new System.Windows.Forms.ErrorProvider(this.components);
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            this.panelCaption5 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txnCABP_ValorRef = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.lblTIPO_CodREG = new System.Windows.Forms.Label();
            this.txtCABP_Desc = new System.Windows.Forms.TextBox();
            this.lblCABP_Desc = new System.Windows.Forms.Label();
            this.txtCABP_Codigo = new System.Windows.Forms.TextBox();
            this.lblCABP_Codigo = new System.Windows.Forms.Label();
            this.lblCABP_Ano = new System.Windows.Forms.Label();
            this.cmbCABP_Ano = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
            this.lblCABP_ValorRef = new System.Windows.Forms.Label();
            this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
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
            this.btnNuevoDocumento = new System.Windows.Forms.Button();
            this.cmbTIPO_CodREG = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
            this.navItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Controls.Add(this.btnGuardar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(734, 50);
            this.panel3.TabIndex = 0;
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
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // errorProviderCab_Cotizacion_OV
            // 
            this.errorProviderCab_Cotizacion_OV.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderCab_Cotizacion_OV.ContainerControl = this;
            // 
            // errorProviderDet_Cotizacion_OV_Novedad
            // 
            this.errorProviderDet_Cotizacion_OV_Novedad.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderDet_Cotizacion_OV_Novedad.ContainerControl = this;
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
            this.grdItems.Location = new System.Drawing.Point(0, 184);
            this.grdItems.Margin = new System.Windows.Forms.Padding(3, 3, 18, 3);
            this.grdItems.Name = "grdItems";
            // 
            // 
            // 
            this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 184, 734, 252);
            this.grdItems.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.grdItems.Size = new System.Drawing.Size(734, 252);
            this.grdItems.TabIndex = 4;
            this.grdItems.TabStop = false;
            // 
            // panelCaption5
            // 
            this.panelCaption5.AllowActive = false;
            this.panelCaption5.AntiAlias = false;
            this.panelCaption5.Caption = "Detalle";
            this.panelCaption5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption5.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption5.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption5.Location = new System.Drawing.Point(0, 157);
            this.panelCaption5.Name = "panelCaption5";
            this.panelCaption5.Size = new System.Drawing.Size(734, 27);
            this.panelCaption5.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 10;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.txnCABP_ValorRef, 4, 2);
            this.tableLayoutPanel3.Controls.Add(this.cmbTIPO_CodREG, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblTIPO_CodREG, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtCABP_Desc, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblCABP_Desc, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtCABP_Codigo, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblCABP_Codigo, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblCABP_Ano, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cmbCABP_Ano, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblCABP_ValorRef, 3, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 76);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(734, 81);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // txnCABP_ValorRef
            // 
            this.txnCABP_ValorRef.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
            this.txnCABP_ValorRef.Decimales = 2;
            this.txnCABP_ValorRef.Enteros = 13;
            this.txnCABP_ValorRef.Formato = "#,###,###,###,##0.00";
            this.txnCABP_ValorRef.Location = new System.Drawing.Point(518, 57);
            this.txnCABP_ValorRef.MaxLength = 14;
            this.txnCABP_ValorRef.Name = "txnCABP_ValorRef";
            this.txnCABP_ValorRef.Negativo = true;
            this.txnCABP_ValorRef.SinFormato = false;
            this.txnCABP_ValorRef.Size = new System.Drawing.Size(194, 20);
            this.txnCABP_ValorRef.TabIndex = 9;
            this.txnCABP_ValorRef.Text = "0";
            this.txnCABP_ValorRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnCABP_ValorRef.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblTIPO_CodREG
            // 
            this.lblTIPO_CodREG.AutoSize = true;
            this.lblTIPO_CodREG.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodREG.Location = new System.Drawing.Point(10, 61);
            this.lblTIPO_CodREG.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodREG.Name = "lblTIPO_CodREG";
            this.lblTIPO_CodREG.Size = new System.Drawing.Size(109, 13);
            this.lblTIPO_CodREG.TabIndex = 6;
            this.lblTIPO_CodREG.Text = "Tipo de Registro :";
            // 
            // txtCABP_Desc
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.txtCABP_Desc, 4);
            this.txtCABP_Desc.Location = new System.Drawing.Point(153, 30);
            this.txtCABP_Desc.MaxLength = 100;
            this.txtCABP_Desc.Name = "txtCABP_Desc";
            this.txtCABP_Desc.Size = new System.Drawing.Size(559, 20);
            this.txtCABP_Desc.TabIndex = 5;
            // 
            // lblCABP_Desc
            // 
            this.lblCABP_Desc.AutoSize = true;
            this.lblCABP_Desc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCABP_Desc.Location = new System.Drawing.Point(10, 34);
            this.lblCABP_Desc.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCABP_Desc.Name = "lblCABP_Desc";
            this.lblCABP_Desc.Size = new System.Drawing.Size(82, 13);
            this.lblCABP_Desc.TabIndex = 4;
            this.lblCABP_Desc.Text = "Descripción :";
            // 
            // txtCABP_Codigo
            // 
            this.txtCABP_Codigo.Location = new System.Drawing.Point(518, 3);
            this.txtCABP_Codigo.MaxLength = 3;
            this.txtCABP_Codigo.Name = "txtCABP_Codigo";
            this.txtCABP_Codigo.Size = new System.Drawing.Size(194, 20);
            this.txtCABP_Codigo.TabIndex = 3;
            // 
            // lblCABP_Codigo
            // 
            this.lblCABP_Codigo.AutoSize = true;
            this.lblCABP_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCABP_Codigo.Location = new System.Drawing.Point(375, 7);
            this.lblCABP_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCABP_Codigo.Name = "lblCABP_Codigo";
            this.lblCABP_Codigo.Size = new System.Drawing.Size(56, 13);
            this.lblCABP_Codigo.TabIndex = 2;
            this.lblCABP_Codigo.Text = "Código :";
            // 
            // lblCABP_Ano
            // 
            this.lblCABP_Ano.AutoSize = true;
            this.lblCABP_Ano.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCABP_Ano.Location = new System.Drawing.Point(10, 7);
            this.lblCABP_Ano.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCABP_Ano.Name = "lblCABP_Ano";
            this.lblCABP_Ano.Size = new System.Drawing.Size(59, 13);
            this.lblCABP_Ano.TabIndex = 0;
            this.lblCABP_Ano.Text = "Periodo :";
            // 
            // cmbCABP_Ano
            // 
            this.cmbCABP_Ano.ComboIntSelectedValue = null;
            this.cmbCABP_Ano.ComboSelectedItem = null;
            this.cmbCABP_Ano.ComboStrSelectedValue = null;
            this.cmbCABP_Ano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCABP_Ano.FormattingEnabled = true;
            this.cmbCABP_Ano.Location = new System.Drawing.Point(153, 3);
            this.cmbCABP_Ano.Name = "cmbCABP_Ano";
            this.cmbCABP_Ano.Size = new System.Drawing.Size(194, 21);
            this.cmbCABP_Ano.TabIndex = 1;
            // 
            // lblCABP_ValorRef
            // 
            this.lblCABP_ValorRef.AutoSize = true;
            this.lblCABP_ValorRef.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCABP_ValorRef.Location = new System.Drawing.Point(375, 61);
            this.lblCABP_ValorRef.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCABP_ValorRef.Name = "lblCABP_ValorRef";
            this.lblCABP_ValorRef.Size = new System.Drawing.Size(113, 13);
            this.lblCABP_ValorRef.TabIndex = 8;
            this.lblCABP_ValorRef.Text = "Valor Referencial :";
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
            this.panelCaption3.Location = new System.Drawing.Point(0, 50);
            this.panelCaption3.Name = "panelCaption3";
            this.panelCaption3.Size = new System.Drawing.Size(734, 26);
            this.panelCaption3.TabIndex = 1;
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
            this.navItems.Location = new System.Drawing.Point(0, 436);
            this.navItems.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.navItems.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.navItems.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.navItems.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.navItems.Name = "navItems";
            this.navItems.PositionItem = this.bindingNavigatorPositionItem1;
            this.navItems.Size = new System.Drawing.Size(734, 25);
            this.navItems.TabIndex = 5;
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
            // btnNuevoDocumento
            // 
            this.btnNuevoDocumento.Image = global::Delfin.Principal.Properties.Resources.add16x16;
            this.btnNuevoDocumento.Location = new System.Drawing.Point(153, 158);
            this.btnNuevoDocumento.Name = "btnNuevoDocumento";
            this.btnNuevoDocumento.Size = new System.Drawing.Size(26, 24);
            this.btnNuevoDocumento.TabIndex = 92;
            this.btnNuevoDocumento.UseVisualStyleBackColor = true;
            // 
            // cmbTIPO_CodREG
            // 
            this.cmbTIPO_CodREG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodREG.FormattingEnabled = true;
            this.cmbTIPO_CodREG.Location = new System.Drawing.Point(153, 57);
            this.cmbTIPO_CodREG.Name = "cmbTIPO_CodREG";
            this.cmbTIPO_CodREG.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPO_CodREG.TabIndex = 7;
            this.cmbTIPO_CodREG.TiposSelectedItem = null;
            this.cmbTIPO_CodREG.TiposSelectedValue = null;
            this.cmbTIPO_CodREG.TiposTitulo = null;
            // 
            // CAJ014PlantillaAsientosMView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.btnNuevoDocumento);
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.navItems);
            this.Controls.Add(this.panelCaption5);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.panelCaption3);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CAJ014PlantillaAsientosMView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plantillas de Asientos";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
            this.navItems.ResumeLayout(false);
            this.navItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }



      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private System.Windows.Forms.ErrorProvider errorProviderCab_Cotizacion_OV;
      private System.Windows.Forms.ErrorProvider errorProviderDet_Cotizacion_OV_Novedad;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.ErrorProvider errorEventoTarea;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption5;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbCABP_Ano;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.TextBox txtCABP_Codigo;
      private System.Windows.Forms.Label lblCABP_Codigo;
      private System.Windows.Forms.Label lblCABP_Ano;
      private System.Windows.Forms.Label lblTIPO_CodREG;
      private System.Windows.Forms.TextBox txtCABP_Desc;
      private System.Windows.Forms.Label lblCABP_Desc;
      private System.Windows.Forms.Label lblCABP_ValorRef;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnCABP_ValorRef;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodREG;
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
      private System.Windows.Forms.Button btnNuevoDocumento;
   }
}