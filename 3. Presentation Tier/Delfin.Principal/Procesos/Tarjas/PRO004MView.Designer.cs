namespace Delfin.Principal
{
   partial class PRO004MView
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnBotones = new System.Windows.Forms.Panel();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.BtnImportar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.panelCaption1 = new Infrastructure.WinFormsControls.PanelCaption();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMAN = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTARJ_Valor = new Infrastructure.WinFormsControls.TextBoxNumerico();
            this.CbTIPO_CodMND = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.PnDepTemp = new System.Windows.Forms.Panel();
            this.AyudaEntidadDepTemporal = new Delfin.Controls.Entidad(this.components);
            this.PnCliente = new System.Windows.Forms.Panel();
            this.AyudaEntidadCliente = new Delfin.Controls.Entidad(this.components);
            this.panelCaption2 = new Infrastructure.WinFormsControls.PanelCaption();
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            this.navItems = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnBotones.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.PnDepTemp.SuspendLayout();
            this.PnCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
            this.navItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnBotones
            // 
            this.pnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnBotones.Controls.Add(this.btnDeshacer);
            this.pnBotones.Controls.Add(this.btnExportar);
            this.pnBotones.Controls.Add(this.BtnImportar);
            this.pnBotones.Controls.Add(this.BtnGuardar);
            this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnBotones.Location = new System.Drawing.Point(0, 0);
            this.pnBotones.Name = "pnBotones";
            this.pnBotones.Size = new System.Drawing.Size(1024, 50);
            this.pnBotones.TabIndex = 43;
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
            this.btnDeshacer.Location = new System.Drawing.Point(172, 0);
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
            this.btnExportar.Location = new System.Drawing.Point(114, 0);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(58, 50);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "&Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // BtnImportar
            // 
            this.BtnImportar.AutoSize = true;
            this.BtnImportar.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnImportar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.BtnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnImportar.ForeColor = System.Drawing.Color.Black;
            this.BtnImportar.Image = global::Delfin.Principal.Properties.Resources.Sign_181;
            this.BtnImportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnImportar.Location = new System.Drawing.Point(57, 0);
            this.BtnImportar.Margin = new System.Windows.Forms.Padding(0);
            this.BtnImportar.Name = "BtnImportar";
            this.BtnImportar.Size = new System.Drawing.Size(57, 50);
            this.BtnImportar.TabIndex = 2;
            this.BtnImportar.Text = "&Importar";
            this.BtnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnImportar.UseVisualStyleBackColor = true;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.AutoSize = true;
            this.BtnGuardar.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.ForeColor = System.Drawing.Color.Black;
            this.BtnGuardar.Image = global::Delfin.Principal.Properties.Resources.save;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnGuardar.Location = new System.Drawing.Point(0, 0);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(0);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(57, 50);
            this.BtnGuardar.TabIndex = 0;
            this.BtnGuardar.Text = "&Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = true;
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
            this.panelCaption1.Location = new System.Drawing.Point(0, 50);
            this.panelCaption1.Name = "panelCaption1";
            this.panelCaption1.Size = new System.Drawing.Size(1024, 26);
            this.panelCaption1.TabIndex = 44;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 209F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.tableLayoutPanel1.Controls.Add(this.lblMAN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTARJ_Valor, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.CbTIPO_CodMND, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.PnDepTemp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.PnCliente, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 76);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 54);
            this.tableLayoutPanel1.TabIndex = 45;
            // 
            // lblMAN
            // 
            this.lblMAN.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAN.Location = new System.Drawing.Point(10, 7);
            this.lblMAN.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblMAN.Name = "lblMAN";
            this.lblMAN.Size = new System.Drawing.Size(137, 17);
            this.lblMAN.TabIndex = 0;
            this.lblMAN.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Deposito Temporal:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(498, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Valor:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(498, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Moneda:";
            // 
            // txtTARJ_Valor
            // 
            this.txtTARJ_Valor.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
            this.txtTARJ_Valor.Decimales = 2;
            this.txtTARJ_Valor.Enteros = 9;
            this.txtTARJ_Valor.Formato = "###,###,##0.00";
            this.txtTARJ_Valor.Location = new System.Drawing.Point(615, 3);
            this.txtTARJ_Valor.MaxLength = 9;
            this.txtTARJ_Valor.Name = "txtTARJ_Valor";
            this.txtTARJ_Valor.Negativo = false;
            this.txtTARJ_Valor.SinFormato = false;
            this.txtTARJ_Valor.Size = new System.Drawing.Size(151, 20);
            this.txtTARJ_Valor.TabIndex = 9;
            this.txtTARJ_Valor.Tag = "TARJ_ValorMSGERROR";
            this.txtTARJ_Valor.Text = "0.00";
            this.txtTARJ_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTARJ_Valor.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // CbTIPO_CodMND
            // 
            this.CbTIPO_CodMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbTIPO_CodMND.FormattingEnabled = true;
            this.CbTIPO_CodMND.Location = new System.Drawing.Point(615, 30);
            this.CbTIPO_CodMND.Name = "CbTIPO_CodMND";
            this.CbTIPO_CodMND.Size = new System.Drawing.Size(151, 21);
            this.CbTIPO_CodMND.TabIndex = 10;
            this.CbTIPO_CodMND.Tag = "TIPO_CodMNDMSGERROR";
            this.CbTIPO_CodMND.TiposSelectedItem = null;
            this.CbTIPO_CodMND.TiposSelectedValue = null;
            this.CbTIPO_CodMND.TiposTitulo = null;
            // 
            // PnDepTemp
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.PnDepTemp, 2);
            this.PnDepTemp.Controls.Add(this.AyudaEntidadDepTemporal);
            this.PnDepTemp.Location = new System.Drawing.Point(153, 30);
            this.PnDepTemp.Name = "PnDepTemp";
            this.PnDepTemp.Size = new System.Drawing.Size(316, 21);
            this.PnDepTemp.TabIndex = 11;
            this.PnDepTemp.Tag = "ENTC_DepTemporalMSGERROR";
            // 
            // AyudaEntidadDepTemporal
            // 
            this.AyudaEntidadDepTemporal.ActivarAyudaAuto = false;
            this.AyudaEntidadDepTemporal.EnabledAyudaButton = true;
            this.AyudaEntidadDepTemporal.Location = new System.Drawing.Point(0, 0);
            this.AyudaEntidadDepTemporal.LongitudAceptada = 0;
            this.AyudaEntidadDepTemporal.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.AyudaEntidadDepTemporal.Name = "AyudaEntidadDepTemporal";
            this.AyudaEntidadDepTemporal.RellenaCeros = false;
            this.AyudaEntidadDepTemporal.Size = new System.Drawing.Size(310, 20);
            this.AyudaEntidadDepTemporal.TabIndex = 6;
            this.AyudaEntidadDepTemporal.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.AyudaEntidadDepTemporal.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_DepositoTemporal;
            this.AyudaEntidadDepTemporal.Value = null;
            // 
            // PnCliente
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.PnCliente, 2);
            this.PnCliente.Controls.Add(this.AyudaEntidadCliente);
            this.PnCliente.Location = new System.Drawing.Point(153, 3);
            this.PnCliente.Name = "PnCliente";
            this.PnCliente.Size = new System.Drawing.Size(316, 21);
            this.PnCliente.TabIndex = 12;
            this.PnCliente.Tag = "ENTC_ClienteMSGERROR";
            // 
            // AyudaEntidadCliente
            // 
            this.AyudaEntidadCliente.ActivarAyudaAuto = false;
            this.AyudaEntidadCliente.EnabledAyudaButton = true;
            this.AyudaEntidadCliente.Location = new System.Drawing.Point(0, 0);
            this.AyudaEntidadCliente.LongitudAceptada = 0;
            this.AyudaEntidadCliente.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.AyudaEntidadCliente.Name = "AyudaEntidadCliente";
            this.AyudaEntidadCliente.RellenaCeros = false;
            this.AyudaEntidadCliente.Size = new System.Drawing.Size(311, 20);
            this.AyudaEntidadCliente.TabIndex = 2;
            this.AyudaEntidadCliente.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.AyudaEntidadCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            this.AyudaEntidadCliente.Value = null;
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
            this.panelCaption2.Location = new System.Drawing.Point(0, 130);
            this.panelCaption2.Name = "panelCaption2";
            this.panelCaption2.Size = new System.Drawing.Size(1024, 26);
            this.panelCaption2.TabIndex = 46;
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Location = new System.Drawing.Point(0, 156);
            this.grdItems.Name = "grdItems";
            // 
            // 
            // 
            this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 156, 240, 150);
            this.grdItems.Size = new System.Drawing.Size(1024, 267);
            this.grdItems.TabIndex = 47;
            this.grdItems.TabStop = false;
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
            this.navItems.Location = new System.Drawing.Point(0, 423);
            this.navItems.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.navItems.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.navItems.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.navItems.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.navItems.Name = "navItems";
            this.navItems.Padding = new System.Windows.Forms.Padding(3);
            this.navItems.PositionItem = this.bindingNavigatorPositionItem;
            this.navItems.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.navItems.Size = new System.Drawing.Size(1024, 29);
            this.navItems.TabIndex = 48;
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
            // PRO004MView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1024, 452);
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.navItems);
            this.Controls.Add(this.panelCaption2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.pnBotones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PRO004MView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarjas";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnBotones.ResumeLayout(false);
            this.pnBotones.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.PnDepTemp.ResumeLayout(false);
            this.PnDepTemp.PerformLayout();
            this.PnCliente.ResumeLayout(false);
            this.PnCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
            this.navItems.ResumeLayout(false);
            this.navItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ErrorProvider errorProvider1;
      private System.Windows.Forms.Panel pnBotones;
      private System.Windows.Forms.Button btnDeshacer;
      private System.Windows.Forms.Button btnExportar;
      private System.Windows.Forms.Button BtnImportar;
      private System.Windows.Forms.Button BtnGuardar;
      private Infrastructure.WinFormsControls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label lblMAN;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label1;
      private Infrastructure.WinFormsControls.TextBoxNumerico txtTARJ_Valor;
      private Controls.Tipos.ComboBoxTipos CbTIPO_CodMND;
      private Infrastructure.WinFormsControls.PanelCaption panelCaption2;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private System.Windows.Forms.BindingNavigator navItems;
      private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
      private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
      private System.Windows.Forms.Panel PnDepTemp;
      private Controls.Entidad AyudaEntidadDepTemporal;
      private System.Windows.Forms.Panel PnCliente;
      private Controls.Entidad AyudaEntidadCliente;
   }
}