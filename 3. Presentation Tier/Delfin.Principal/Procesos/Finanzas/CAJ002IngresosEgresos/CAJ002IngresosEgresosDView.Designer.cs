namespace Delfin.Principal
{
   partial class CAJ002IngresosEgresosDView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAJ002IngresosEgresosDView));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtCCCT_Numero = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCCCT_Serie = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTIPO_CodTDO = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.label5 = new System.Windows.Forms.Label();
            this.txaNVIA_Codigo = new Delfin.Controls.AyudaViaje();
            this.lblNVIA_Codigo = new System.Windows.Forms.Label();
            this.cmbTIPE_Codigo = new Delfin.Controls.ComboBoxTipoEntidad();
            this.lblTIPE_Codigo = new System.Windows.Forms.Label();
            this.txaENTC_Codigo = new Delfin.Controls.EntidadDocIden();
            this.lblENTC_Codigo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoDocumento = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMBL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHBL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpMOVI_FecEmision = new Infrastructure.WinForms.Controls.MaskTime();
            this.grdItemsDocumentos = new Telerik.WinControls.UI.RadGridView();
            this.panelCaption5 = new Infrastructure.WinForms.Controls.PanelCaption();
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
            this.CMSseleccion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.marcarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desmarcarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcarSeleccionadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desmarcarSeleccionadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDocumentos.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
            this.navItems.SuspendLayout();
            this.CMSseleccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnBuscar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1103, 50);
            this.panel3.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.Black;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAceptar.Location = new System.Drawing.Point(57, 0);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(0);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(56, 50);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Image = global::Delfin.Principal.Properties.Resources.search;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.Location = new System.Drawing.Point(0, 0);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(57, 50);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // panelCaption3
            // 
            this.panelCaption3.AllowActive = false;
            this.panelCaption3.AntiAlias = false;
            this.panelCaption3.Caption = "Datos de Busqueda";
            this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption3.Location = new System.Drawing.Point(0, 50);
            this.panelCaption3.Name = "panelCaption3";
            this.panelCaption3.Size = new System.Drawing.Size(1103, 26);
            this.panelCaption3.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.LightSteelBlue;
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
            this.tableLayoutPanel3.Controls.Add(this.txtCCCT_Numero, 7, 3);
            this.tableLayoutPanel3.Controls.Add(this.label7, 6, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtCCCT_Serie, 4, 3);
            this.tableLayoutPanel3.Controls.Add(this.label6, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.cmbTIPO_CodTDO, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txaNVIA_Codigo, 4, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblNVIA_Codigo, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.cmbTIPE_Codigo, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTIPE_Codigo, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txaENTC_Codigo, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblENTC_Codigo, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.cmbTipoDocumento, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtMBL, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.label4, 6, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtHBL, 7, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.dtpMOVI_FecEmision, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 76);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1103, 108);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // txtCCCT_Numero
            // 
            this.txtCCCT_Numero.Location = new System.Drawing.Point(883, 84);
            this.txtCCCT_Numero.MaxLength = 20;
            this.txtCCCT_Numero.Name = "txtCCCT_Numero";
            this.txtCCCT_Numero.Size = new System.Drawing.Size(194, 20);
            this.txtCCCT_Numero.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(740, 88);
            this.label7.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Numero :";
            // 
            // txtCCCT_Serie
            // 
            this.txtCCCT_Serie.Location = new System.Drawing.Point(518, 84);
            this.txtCCCT_Serie.MaxLength = 20;
            this.txtCCCT_Serie.Name = "txtCCCT_Serie";
            this.txtCCCT_Serie.Size = new System.Drawing.Size(194, 20);
            this.txtCCCT_Serie.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(375, 88);
            this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Serie :";
            // 
            // cmbTIPO_CodTDO
            // 
            this.cmbTIPO_CodTDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodTDO.FormattingEnabled = true;
            this.cmbTIPO_CodTDO.Location = new System.Drawing.Point(153, 84);
            this.cmbTIPO_CodTDO.Name = "cmbTIPO_CodTDO";
            this.cmbTIPO_CodTDO.Session = null;
            this.cmbTIPO_CodTDO.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPO_CodTDO.TabIndex = 15;
            this.cmbTIPO_CodTDO.TiposSelectedItem = null;
            this.cmbTIPO_CodTDO.TiposSelectedValue = null;
            this.cmbTIPO_CodTDO.TiposTitulo = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tipo Documento :";
            // 
            // txaNVIA_Codigo
            // 
            this.txaNVIA_Codigo.ActivarAyudaAuto = false;
            this.txaNVIA_Codigo.EMPR_Codigo = ((short)(0));
            this.txaNVIA_Codigo.EnabledAyuda = true;
            this.txaNVIA_Codigo.EnabledAyudaButton = true;
            this.txaNVIA_Codigo.ENTC_CodTranportista = null;
            this.txaNVIA_Codigo.EsFiltro = false;
            this.txaNVIA_Codigo.FechaDesde = null;
            this.txaNVIA_Codigo.Location = new System.Drawing.Point(518, 57);
            this.txaNVIA_Codigo.LongitudAceptada = 0;
            this.txaNVIA_Codigo.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
            this.txaNVIA_Codigo.Name = "txaNVIA_Codigo";
            this.txaNVIA_Codigo.RellenaCeros = false;
            this.txaNVIA_Codigo.Size = new System.Drawing.Size(194, 20);
            this.txaNVIA_Codigo.SUCR_Codigo = ((short)(0));
            this.txaNVIA_Codigo.TabIndex = 13;
            this.txaNVIA_Codigo.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.Numerico;
            this.txaNVIA_Codigo.TipoAyudaNaveViaje = Delfin.Controls.AyudaViaje.TipoAyuda.Codigo;
            this.txaNVIA_Codigo.Value = null;
            // 
            // lblNVIA_Codigo
            // 
            this.lblNVIA_Codigo.AutoSize = true;
            this.lblNVIA_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_Codigo.Location = new System.Drawing.Point(375, 61);
            this.lblNVIA_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_Codigo.Name = "lblNVIA_Codigo";
            this.lblNVIA_Codigo.Size = new System.Drawing.Size(78, 13);
            this.lblNVIA_Codigo.TabIndex = 12;
            this.lblNVIA_Codigo.Text = "Nave Viaje :";
            // 
            // cmbTIPE_Codigo
            // 
            this.cmbTIPE_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPE_Codigo.FormattingEnabled = true;
            this.cmbTIPE_Codigo.Location = new System.Drawing.Point(153, 3);
            this.cmbTIPE_Codigo.Name = "cmbTIPE_Codigo";
            this.cmbTIPE_Codigo.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPE_Codigo.TabIndex = 1;
            this.cmbTIPE_Codigo.TipoEntidadSelectedItem = null;
            this.cmbTIPE_Codigo.TipoEntidadSelectedValue = null;
            this.cmbTIPE_Codigo.TiposTitulo = null;
            // 
            // lblTIPE_Codigo
            // 
            this.lblTIPE_Codigo.AutoSize = true;
            this.lblTIPE_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPE_Codigo.Location = new System.Drawing.Point(10, 7);
            this.lblTIPE_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPE_Codigo.Name = "lblTIPE_Codigo";
            this.lblTIPE_Codigo.Size = new System.Drawing.Size(86, 13);
            this.lblTIPE_Codigo.TabIndex = 0;
            this.lblTIPE_Codigo.Text = "Tipo Entidad :";
            // 
            // txaENTC_Codigo
            // 
            this.txaENTC_Codigo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txaENTC_Codigo.CrearNuevaEntidad = false;
            this.txaENTC_Codigo.Location = new System.Drawing.Point(515, 0);
            this.txaENTC_Codigo.Margin = new System.Windows.Forms.Padding(0);
            this.txaENTC_Codigo.MinimumSize = new System.Drawing.Size(565, 27);
            this.txaENTC_Codigo.Name = "txaENTC_Codigo";
            this.txaENTC_Codigo.Size = new System.Drawing.Size(565, 27);
            this.txaENTC_Codigo.SoloEntidad = false;
            this.txaENTC_Codigo.TabIndex = 3;
            this.txaENTC_Codigo.TagEntidad = null;
            this.txaENTC_Codigo.TiposEntidad = Delfin.Controls.TiposEntidad.TIPE_AgenciaAduanera;
            this.txaENTC_Codigo.txaENTC_DOCIDEN_Name = "txaENTC_DOCIDEN";
            this.txaENTC_Codigo.txaENTC_NOMCOMPLETO_Name = "txaENTC_NOMCOMPLETO";
            // 
            // lblENTC_Codigo
            // 
            this.lblENTC_Codigo.AutoSize = true;
            this.lblENTC_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_Codigo.Location = new System.Drawing.Point(375, 7);
            this.lblENTC_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblENTC_Codigo.Name = "lblENTC_Codigo";
            this.lblENTC_Codigo.Size = new System.Drawing.Size(56, 13);
            this.lblENTC_Codigo.TabIndex = 2;
            this.lblENTC_Codigo.Text = "Cliente :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tipo :";
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.ConstantesSelectedItem = null;
            this.cmbTipoDocumento.ConstantesSelectedValue = null;
            this.cmbTipoDocumento.ConstantesTitulo = null;
            this.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Location = new System.Drawing.Point(153, 30);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Session = null;
            this.cmbTipoDocumento.Size = new System.Drawing.Size(194, 21);
            this.cmbTipoDocumento.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(375, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "MBL :";
            // 
            // txtMBL
            // 
            this.txtMBL.Location = new System.Drawing.Point(518, 30);
            this.txtMBL.Name = "txtMBL";
            this.txtMBL.Size = new System.Drawing.Size(194, 20);
            this.txtMBL.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(740, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "HBL :";
            // 
            // txtHBL
            // 
            this.txtHBL.Location = new System.Drawing.Point(883, 30);
            this.txtHBL.Name = "txtHBL";
            this.txtHBL.Size = new System.Drawing.Size(194, 20);
            this.txtHBL.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fecha Desde :";
            // 
            // dtpMOVI_FecEmision
            // 
            this.dtpMOVI_FecEmision.Location = new System.Drawing.Point(153, 57);
            this.dtpMOVI_FecEmision.MinimumSize = new System.Drawing.Size(100, 22);
            this.dtpMOVI_FecEmision.Name = "dtpMOVI_FecEmision";
            this.dtpMOVI_FecEmision.NSActiveMouse = false;
            this.dtpMOVI_FecEmision.NSActiveMsgFecha = false;
            this.dtpMOVI_FecEmision.NSChangeDate = true;
            this.dtpMOVI_FecEmision.NSDigitos = 4;
            this.dtpMOVI_FecEmision.NSFecha = null;
            this.dtpMOVI_FecEmision.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
            this.dtpMOVI_FecEmision.NSSetDateNow = false;
            this.dtpMOVI_FecEmision.Size = new System.Drawing.Size(100, 22);
            this.dtpMOVI_FecEmision.TabIndex = 11;
            // 
            // grdItemsDocumentos
            // 
            this.grdItemsDocumentos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItemsDocumentos.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdItemsDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItemsDocumentos.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdItemsDocumentos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdItemsDocumentos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdItemsDocumentos.Location = new System.Drawing.Point(0, 211);
            this.grdItemsDocumentos.Margin = new System.Windows.Forms.Padding(3, 3, 18, 3);
            // 
            // grdItemsDocumentos
            // 
            this.grdItemsDocumentos.MasterTemplate.EnableFiltering = true;
            this.grdItemsDocumentos.Name = "grdItemsDocumentos";
            this.grdItemsDocumentos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.grdItemsDocumentos.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 211, 240, 150);
            this.grdItemsDocumentos.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.grdItemsDocumentos.Size = new System.Drawing.Size(1103, 175);
            this.grdItemsDocumentos.TabIndex = 9;
            this.grdItemsDocumentos.TabStop = false;
            this.grdItemsDocumentos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdItems_MouseClick);
            // 
            // panelCaption5
            // 
            this.panelCaption5.AllowActive = false;
            this.panelCaption5.AntiAlias = false;
            this.panelCaption5.Caption = "Resultado de Busqueda";
            this.panelCaption5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption5.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption5.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption5.Location = new System.Drawing.Point(0, 184);
            this.panelCaption5.Name = "panelCaption5";
            this.panelCaption5.Size = new System.Drawing.Size(1103, 27);
            this.panelCaption5.TabIndex = 8;
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
            this.navItems.Location = new System.Drawing.Point(0, 386);
            this.navItems.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.navItems.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.navItems.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.navItems.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.navItems.Name = "navItems";
            this.navItems.PositionItem = this.bindingNavigatorPositionItem1;
            this.navItems.Size = new System.Drawing.Size(1103, 25);
            this.navItems.TabIndex = 55;
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
            this.marcarSeleccionadosToolStripMenuItem.Click += new System.EventHandler(this.tsmDesmarcarTodos_Click);
            // 
            // desmarcarSeleccionadosToolStripMenuItem
            // 
            this.desmarcarSeleccionadosToolStripMenuItem.Name = "desmarcarSeleccionadosToolStripMenuItem";
            this.desmarcarSeleccionadosToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.desmarcarSeleccionadosToolStripMenuItem.Text = "Desmarcar Seleccionados";
            this.desmarcarSeleccionadosToolStripMenuItem.Click += new System.EventHandler(this.tsmDesmarcarSeleccionados_Click);
            // 
            // CAJ002IngresosEgresosDView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1103, 411);
            this.Controls.Add(this.grdItemsDocumentos);
            this.Controls.Add(this.navItems);
            this.Controls.Add(this.panelCaption5);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.panelCaption3);
            this.Controls.Add(this.panel3);
            this.MinimizeBox = false;
            this.Name = "CAJ002IngresosEgresosDView";
            this.Text = "Busqueda de Documentos";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDocumentos.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
            this.navItems.ResumeLayout(false);
            this.navItems.PerformLayout();
            this.CMSseleccion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnAceptar;
      private System.Windows.Forms.Button btnBuscar;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private Telerik.WinControls.UI.RadGridView grdItemsDocumentos;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption5;
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
      private System.Windows.Forms.Label lblENTC_Codigo;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private Controls.EntidadDocIden txaENTC_Codigo;
      private Infrastructure.WinForms.Controls.MaskTime dtpMOVI_FecEmision;
      private Controls.Tipos.ComboBoxConstantes cmbTipoDocumento;
      private System.Windows.Forms.Label lblTIPE_Codigo;
      private Controls.ComboBoxTipoEntidad cmbTIPE_Codigo;
      private System.Windows.Forms.TextBox txtHBL;
      private System.Windows.Forms.TextBox txtMBL;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private Controls.AyudaViaje txaNVIA_Codigo;
      private System.Windows.Forms.Label lblNVIA_Codigo;
      private System.Windows.Forms.ContextMenuStrip CMSseleccion;
      private System.Windows.Forms.ToolStripMenuItem marcarTodosToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem desmarcarTodosToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem marcarSeleccionadosToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem desmarcarSeleccionadosToolStripMenuItem;
      private System.Windows.Forms.Label label5;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodTDO;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.TextBox txtCCCT_Serie;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.TextBox txtCCCT_Numero;
   }
}