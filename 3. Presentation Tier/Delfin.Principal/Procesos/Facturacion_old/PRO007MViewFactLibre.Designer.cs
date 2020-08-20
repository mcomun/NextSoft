namespace Delfin.Logistico
{
   partial class PRO007MViewFactLibre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PRO007MViewFactLibre));
            this.TLPanelDatos = new System.Windows.Forms.TableLayoutPanel();
            this.cmbDOCV_Serie = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
            this.dtpDOCV_FechaEmision = new Infrastructure.WinForms.Controls.MaskTime();
            this.txnDOCV_TipoCambio = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.lblTIPO_CodTDO = new System.Windows.Forms.Label();
            this.cmbTIPO_CodTDO = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.lblDOCV_Numero = new System.Windows.Forms.Label();
            this.txtDOCV_Numero = new System.Windows.Forms.TextBox();
            this.lblDOCV_Serie = new System.Windows.Forms.Label();
            this.cmbTIPO_CodFPG = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.lblTIPO_CodFPG = new System.Windows.Forms.Label();
            this.cmbTIPO_CodMND = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.lblTIPO_CodMND = new System.Windows.Forms.Label();
            this.lblDOCV_FechaEmision = new System.Windows.Forms.Label();
            this.lblDOCV_FechaVcmto = new System.Windows.Forms.Label();
            this.lblDOCV_Estado = new System.Windows.Forms.Label();
            this.cmbDOCV_Estado = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblEntidad = new System.Windows.Forms.Label();
            this.lblDOCV_TipoCambio = new System.Windows.Forms.Label();
            this.lblTIPE_Codigo = new System.Windows.Forms.Label();
            this.cmbTIPE_Codigo = new Delfin.Controls.ComboBoxTipoEntidad();
            this.txaEntidad = new Delfin.Controls.EntidadDocIden();
            this.dtpDOCV_FechaVcmto = new Infrastructure.WinForms.Controls.MaskTime();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDOCV_Observaciones = new System.Windows.Forms.TextBox();
            this.PCEncabezado = new Infrastructure.WinFormsControls.PanelCaption();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txnDOCV_ValorVtaTotal = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDOCV_PrecVtaTotal = new System.Windows.Forms.Label();
            this.lblDOCV_Impuesto1 = new System.Windows.Forms.Label();
            this.lblDOCV_ValorVtaTotal = new System.Windows.Forms.Label();
            this.lblLetras = new System.Windows.Forms.Label();
            this.txnDOCV_PrecVtaTotal = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.txnDOCV_Impuesto1 = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.TabDetalleDocVenta = new Dotnetrix.Controls.TabControlEX();
            this.TabPageServicios = new Dotnetrix.Controls.TabPageEX();
            this.grdItemsServicio = new Telerik.WinControls.UI.RadGridView();
            this.navItems = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TabPageNotas = new Dotnetrix.Controls.TabPageEX();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDOCV_Notas = new System.Windows.Forms.TextBox();
            this.PcDocVenta = new Infrastructure.WinFormsControls.PanelCaption();
            this.btnNuevoServicio = new System.Windows.Forms.Button();
            this.errorProviderFacturacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.TLPanelDatos.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.TabDetalleDocVenta.SuspendLayout();
            this.TabPageServicios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
            this.navItems.SuspendLayout();
            this.TabPageNotas.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFacturacion)).BeginInit();
            this.SuspendLayout();
            // 
            // TLPanelDatos
            // 
            this.TLPanelDatos.AutoSize = true;
            this.TLPanelDatos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.TLPanelDatos.ColumnCount = 12;
            this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.TLPanelDatos.Controls.Add(this.cmbDOCV_Serie, 4, 0);
            this.TLPanelDatos.Controls.Add(this.dtpDOCV_FechaEmision, 1, 1);
            this.TLPanelDatos.Controls.Add(this.txnDOCV_TipoCambio, 7, 3);
            this.TLPanelDatos.Controls.Add(this.lblTIPO_CodTDO, 0, 0);
            this.TLPanelDatos.Controls.Add(this.cmbTIPO_CodTDO, 1, 0);
            this.TLPanelDatos.Controls.Add(this.lblDOCV_Numero, 6, 0);
            this.TLPanelDatos.Controls.Add(this.txtDOCV_Numero, 7, 0);
            this.TLPanelDatos.Controls.Add(this.lblDOCV_Serie, 3, 0);
            this.TLPanelDatos.Controls.Add(this.cmbTIPO_CodFPG, 4, 3);
            this.TLPanelDatos.Controls.Add(this.lblTIPO_CodFPG, 3, 3);
            this.TLPanelDatos.Controls.Add(this.cmbTIPO_CodMND, 1, 3);
            this.TLPanelDatos.Controls.Add(this.lblTIPO_CodMND, 0, 3);
            this.TLPanelDatos.Controls.Add(this.lblDOCV_FechaEmision, 0, 1);
            this.TLPanelDatos.Controls.Add(this.lblDOCV_FechaVcmto, 3, 1);
            this.TLPanelDatos.Controls.Add(this.lblDOCV_Estado, 6, 1);
            this.TLPanelDatos.Controls.Add(this.cmbDOCV_Estado, 7, 1);
            this.TLPanelDatos.Controls.Add(this.lblEntidad, 3, 2);
            this.TLPanelDatos.Controls.Add(this.lblDOCV_TipoCambio, 6, 3);
            this.TLPanelDatos.Controls.Add(this.lblTIPE_Codigo, 0, 2);
            this.TLPanelDatos.Controls.Add(this.cmbTIPE_Codigo, 1, 2);
            this.TLPanelDatos.Controls.Add(this.txaEntidad, 4, 2);
            this.TLPanelDatos.Controls.Add(this.dtpDOCV_FechaVcmto, 4, 1);
            this.TLPanelDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.TLPanelDatos.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TLPanelDatos.Location = new System.Drawing.Point(0, 76);
            this.TLPanelDatos.Name = "TLPanelDatos";
            this.TLPanelDatos.RowCount = 4;
            this.TLPanelDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TLPanelDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TLPanelDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TLPanelDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TLPanelDatos.Size = new System.Drawing.Size(1100, 108);
            this.TLPanelDatos.TabIndex = 2;
            // 
            // cmbDOCV_Serie
            // 
            this.cmbDOCV_Serie.ComboIntSelectedValue = null;
            this.cmbDOCV_Serie.ComboSelectedItem = null;
            this.cmbDOCV_Serie.ComboStrSelectedValue = null;
            this.cmbDOCV_Serie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDOCV_Serie.FormattingEnabled = true;
            this.cmbDOCV_Serie.Location = new System.Drawing.Point(518, 3);
            this.cmbDOCV_Serie.Name = "cmbDOCV_Serie";
            this.cmbDOCV_Serie.Size = new System.Drawing.Size(194, 21);
            this.cmbDOCV_Serie.TabIndex = 3;
            // 
            // dtpDOCV_FechaEmision
            // 
            this.dtpDOCV_FechaEmision.Location = new System.Drawing.Point(153, 30);
            this.dtpDOCV_FechaEmision.MinimumSize = new System.Drawing.Size(100, 22);
            this.dtpDOCV_FechaEmision.Name = "dtpDOCV_FechaEmision";
            this.dtpDOCV_FechaEmision.NSActiveMouse = false;
            this.dtpDOCV_FechaEmision.NSActiveMsgFecha = false;
            this.dtpDOCV_FechaEmision.NSChangeDate = true;
            this.dtpDOCV_FechaEmision.NSDigitos = 4;
            this.dtpDOCV_FechaEmision.NSFecha = null;
            this.dtpDOCV_FechaEmision.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
            this.dtpDOCV_FechaEmision.NSSetDateNow = false;
            this.dtpDOCV_FechaEmision.Size = new System.Drawing.Size(100, 22);
            this.dtpDOCV_FechaEmision.TabIndex = 7;
            // 
            // txnDOCV_TipoCambio
            // 
            this.txnDOCV_TipoCambio.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txnDOCV_TipoCambio.Decimales = 2;
            this.txnDOCV_TipoCambio.Enteros = 9;
            this.txnDOCV_TipoCambio.Formato = "###,###,##0.00";
            this.txnDOCV_TipoCambio.Location = new System.Drawing.Point(883, 84);
            this.txnDOCV_TipoCambio.MaxLength = 13;
            this.txnDOCV_TipoCambio.Name = "txnDOCV_TipoCambio";
            this.txnDOCV_TipoCambio.Negativo = true;
            this.txnDOCV_TipoCambio.SinFormato = false;
            this.txnDOCV_TipoCambio.Size = new System.Drawing.Size(194, 20);
            this.txnDOCV_TipoCambio.TabIndex = 21;
            this.txnDOCV_TipoCambio.Text = "0.00";
            this.txnDOCV_TipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnDOCV_TipoCambio.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblTIPO_CodTDO
            // 
            this.lblTIPO_CodTDO.AutoSize = true;
            this.lblTIPO_CodTDO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodTDO.Location = new System.Drawing.Point(10, 7);
            this.lblTIPO_CodTDO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodTDO.Name = "lblTIPO_CodTDO";
            this.lblTIPO_CodTDO.Size = new System.Drawing.Size(105, 13);
            this.lblTIPO_CodTDO.TabIndex = 0;
            this.lblTIPO_CodTDO.Text = "Tipo Documento:";
            // 
            // cmbTIPO_CodTDO
            // 
            this.cmbTIPO_CodTDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodTDO.FormattingEnabled = true;
            this.cmbTIPO_CodTDO.Location = new System.Drawing.Point(153, 3);
            this.cmbTIPO_CodTDO.Name = "cmbTIPO_CodTDO";
            this.cmbTIPO_CodTDO.Session = null;
            this.cmbTIPO_CodTDO.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPO_CodTDO.TabIndex = 1;
            this.cmbTIPO_CodTDO.Tag = "TIPO_CodTDOMSGERROR";
            this.cmbTIPO_CodTDO.TiposSelectedItem = null;
            this.cmbTIPO_CodTDO.TiposSelectedValue = null;
            this.cmbTIPO_CodTDO.TiposTitulo = null;
            // 
            // lblDOCV_Numero
            // 
            this.lblDOCV_Numero.AutoSize = true;
            this.lblDOCV_Numero.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOCV_Numero.Location = new System.Drawing.Point(740, 7);
            this.lblDOCV_Numero.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblDOCV_Numero.Name = "lblDOCV_Numero";
            this.lblDOCV_Numero.Size = new System.Drawing.Size(102, 13);
            this.lblDOCV_Numero.TabIndex = 4;
            this.lblDOCV_Numero.Text = "Número Factura:";
            // 
            // txtDOCV_Numero
            // 
            this.txtDOCV_Numero.Enabled = false;
            this.txtDOCV_Numero.Location = new System.Drawing.Point(883, 3);
            this.txtDOCV_Numero.MaxLength = 20;
            this.txtDOCV_Numero.Name = "txtDOCV_Numero";
            this.txtDOCV_Numero.ReadOnly = true;
            this.txtDOCV_Numero.Size = new System.Drawing.Size(194, 20);
            this.txtDOCV_Numero.TabIndex = 5;
            this.txtDOCV_Numero.Tag = "";
            // 
            // lblDOCV_Serie
            // 
            this.lblDOCV_Serie.AutoSize = true;
            this.lblDOCV_Serie.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOCV_Serie.Location = new System.Drawing.Point(375, 7);
            this.lblDOCV_Serie.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblDOCV_Serie.Name = "lblDOCV_Serie";
            this.lblDOCV_Serie.Size = new System.Drawing.Size(42, 13);
            this.lblDOCV_Serie.TabIndex = 2;
            this.lblDOCV_Serie.Text = "Serie:";
            // 
            // cmbTIPO_CodFPG
            // 
            this.cmbTIPO_CodFPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodFPG.FormattingEnabled = true;
            this.cmbTIPO_CodFPG.Location = new System.Drawing.Point(518, 84);
            this.cmbTIPO_CodFPG.Name = "cmbTIPO_CodFPG";
            this.cmbTIPO_CodFPG.Session = null;
            this.cmbTIPO_CodFPG.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPO_CodFPG.TabIndex = 19;
            this.cmbTIPO_CodFPG.Tag = "TIPO_CodFPGMSGERROR";
            this.cmbTIPO_CodFPG.TiposSelectedItem = null;
            this.cmbTIPO_CodFPG.TiposSelectedValue = null;
            this.cmbTIPO_CodFPG.TiposTitulo = null;
            // 
            // lblTIPO_CodFPG
            // 
            this.lblTIPO_CodFPG.AutoSize = true;
            this.lblTIPO_CodFPG.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodFPG.Location = new System.Drawing.Point(375, 88);
            this.lblTIPO_CodFPG.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodFPG.Name = "lblTIPO_CodFPG";
            this.lblTIPO_CodFPG.Size = new System.Drawing.Size(98, 13);
            this.lblTIPO_CodFPG.TabIndex = 18;
            this.lblTIPO_CodFPG.Text = "Forma de Pago:";
            // 
            // cmbTIPO_CodMND
            // 
            this.cmbTIPO_CodMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodMND.FormattingEnabled = true;
            this.cmbTIPO_CodMND.Location = new System.Drawing.Point(153, 84);
            this.cmbTIPO_CodMND.Name = "cmbTIPO_CodMND";
            this.cmbTIPO_CodMND.Session = null;
            this.cmbTIPO_CodMND.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPO_CodMND.TabIndex = 17;
            this.cmbTIPO_CodMND.Tag = "TIPO_CodMNDMSGERROR";
            this.cmbTIPO_CodMND.TiposSelectedItem = null;
            this.cmbTIPO_CodMND.TiposSelectedValue = null;
            this.cmbTIPO_CodMND.TiposTitulo = null;
            // 
            // lblTIPO_CodMND
            // 
            this.lblTIPO_CodMND.AutoSize = true;
            this.lblTIPO_CodMND.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodMND.Location = new System.Drawing.Point(10, 88);
            this.lblTIPO_CodMND.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodMND.Name = "lblTIPO_CodMND";
            this.lblTIPO_CodMND.Size = new System.Drawing.Size(56, 13);
            this.lblTIPO_CodMND.TabIndex = 16;
            this.lblTIPO_CodMND.Text = "Moneda:";
            // 
            // lblDOCV_FechaEmision
            // 
            this.lblDOCV_FechaEmision.AutoSize = true;
            this.lblDOCV_FechaEmision.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOCV_FechaEmision.Location = new System.Drawing.Point(10, 34);
            this.lblDOCV_FechaEmision.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblDOCV_FechaEmision.Name = "lblDOCV_FechaEmision";
            this.lblDOCV_FechaEmision.Size = new System.Drawing.Size(111, 13);
            this.lblDOCV_FechaEmision.TabIndex = 6;
            this.lblDOCV_FechaEmision.Text = "Fecha de Emisión:";
            // 
            // lblDOCV_FechaVcmto
            // 
            this.lblDOCV_FechaVcmto.AutoSize = true;
            this.lblDOCV_FechaVcmto.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOCV_FechaVcmto.Location = new System.Drawing.Point(375, 34);
            this.lblDOCV_FechaVcmto.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblDOCV_FechaVcmto.Name = "lblDOCV_FechaVcmto";
            this.lblDOCV_FechaVcmto.Size = new System.Drawing.Size(118, 13);
            this.lblDOCV_FechaVcmto.TabIndex = 8;
            this.lblDOCV_FechaVcmto.Text = "Fecha Vencimiento:";
            // 
            // lblDOCV_Estado
            // 
            this.lblDOCV_Estado.AutoSize = true;
            this.lblDOCV_Estado.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOCV_Estado.Location = new System.Drawing.Point(740, 34);
            this.lblDOCV_Estado.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblDOCV_Estado.Name = "lblDOCV_Estado";
            this.lblDOCV_Estado.Size = new System.Drawing.Size(50, 13);
            this.lblDOCV_Estado.TabIndex = 10;
            this.lblDOCV_Estado.Text = "Estado:";
            // 
            // cmbDOCV_Estado
            // 
            this.cmbDOCV_Estado.ConstantesSelectedItem = null;
            this.cmbDOCV_Estado.ConstantesSelectedValue = null;
            this.cmbDOCV_Estado.ConstantesTitulo = null;
            this.cmbDOCV_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDOCV_Estado.FormattingEnabled = true;
            this.cmbDOCV_Estado.Location = new System.Drawing.Point(883, 30);
            this.cmbDOCV_Estado.Name = "cmbDOCV_Estado";
            this.cmbDOCV_Estado.Session = null;
            this.cmbDOCV_Estado.Size = new System.Drawing.Size(194, 21);
            this.cmbDOCV_Estado.TabIndex = 11;
            this.cmbDOCV_Estado.Tag = "DOCV_EstadoMSGERROR";
            // 
            // lblEntidad
            // 
            this.lblEntidad.AutoSize = true;
            this.lblEntidad.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntidad.Location = new System.Drawing.Point(375, 61);
            this.lblEntidad.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblEntidad.Name = "lblEntidad";
            this.lblEntidad.Size = new System.Drawing.Size(58, 13);
            this.lblEntidad.TabIndex = 14;
            this.lblEntidad.Text = "Entidad :";
            // 
            // lblDOCV_TipoCambio
            // 
            this.lblDOCV_TipoCambio.AutoSize = true;
            this.lblDOCV_TipoCambio.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOCV_TipoCambio.Location = new System.Drawing.Point(740, 88);
            this.lblDOCV_TipoCambio.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblDOCV_TipoCambio.Name = "lblDOCV_TipoCambio";
            this.lblDOCV_TipoCambio.Size = new System.Drawing.Size(84, 13);
            this.lblDOCV_TipoCambio.TabIndex = 20;
            this.lblDOCV_TipoCambio.Text = "Tipo Cambio:";
            // 
            // lblTIPE_Codigo
            // 
            this.lblTIPE_Codigo.AutoSize = true;
            this.lblTIPE_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPE_Codigo.Location = new System.Drawing.Point(10, 61);
            this.lblTIPE_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPE_Codigo.Name = "lblTIPE_Codigo";
            this.lblTIPE_Codigo.Size = new System.Drawing.Size(104, 13);
            this.lblTIPE_Codigo.TabIndex = 12;
            this.lblTIPE_Codigo.Text = "Tipo de Entidad :";
            // 
            // cmbTIPE_Codigo
            // 
            this.cmbTIPE_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPE_Codigo.FormattingEnabled = true;
            this.cmbTIPE_Codigo.Location = new System.Drawing.Point(153, 57);
            this.cmbTIPE_Codigo.Name = "cmbTIPE_Codigo";
            this.cmbTIPE_Codigo.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPE_Codigo.TabIndex = 13;
            this.cmbTIPE_Codigo.Tag = "TIPE_CodigoMSGERROR";
            this.cmbTIPE_Codigo.TipoEntidadSelectedItem = null;
            this.cmbTIPE_Codigo.TipoEntidadSelectedValue = null;
            this.cmbTIPE_Codigo.TiposTitulo = null;
            // 
            // txaEntidad
            // 
            this.txaEntidad.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txaEntidad.CrearNuevaEntidad = false;
            this.txaEntidad.Location = new System.Drawing.Point(515, 54);
            this.txaEntidad.Margin = new System.Windows.Forms.Padding(0);
            this.txaEntidad.MinimumSize = new System.Drawing.Size(565, 27);
            this.txaEntidad.Name = "txaEntidad";
            this.txaEntidad.Size = new System.Drawing.Size(565, 27);
            this.txaEntidad.SoloEntidad = false;
            this.txaEntidad.TabIndex = 15;
            this.txaEntidad.TagEntidad = null;
            this.txaEntidad.TiposEntidad = Delfin.Controls.TiposEntidad.TIPE_AgenciaAduanera;
            this.txaEntidad.txaENTC_DOCIDEN_Name = "txaENTC_DOCIDEN";
            this.txaEntidad.txaENTC_NOMCOMPLETO_Name = "txaENTC_NOMCOMPLETO";
            // 
            // dtpDOCV_FechaVcmto
            // 
            this.dtpDOCV_FechaVcmto.Location = new System.Drawing.Point(518, 30);
            this.dtpDOCV_FechaVcmto.MinimumSize = new System.Drawing.Size(100, 22);
            this.dtpDOCV_FechaVcmto.Name = "dtpDOCV_FechaVcmto";
            this.dtpDOCV_FechaVcmto.NSActiveMouse = false;
            this.dtpDOCV_FechaVcmto.NSActiveMsgFecha = false;
            this.dtpDOCV_FechaVcmto.NSChangeDate = true;
            this.dtpDOCV_FechaVcmto.NSDigitos = 4;
            this.dtpDOCV_FechaVcmto.NSFecha = null;
            this.dtpDOCV_FechaVcmto.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
            this.dtpDOCV_FechaVcmto.NSSetDateNow = false;
            this.dtpDOCV_FechaVcmto.Size = new System.Drawing.Size(100, 22);
            this.dtpDOCV_FechaVcmto.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 115);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Observaciones :";
            // 
            // txtDOCV_Observaciones
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtDOCV_Observaciones, 8);
            this.txtDOCV_Observaciones.Location = new System.Drawing.Point(3, 138);
            this.txtDOCV_Observaciones.MaxLength = 1000;
            this.txtDOCV_Observaciones.Multiline = true;
            this.txtDOCV_Observaciones.Name = "txtDOCV_Observaciones";
            this.txtDOCV_Observaciones.Size = new System.Drawing.Size(1074, 21);
            this.txtDOCV_Observaciones.TabIndex = 3;
            this.txtDOCV_Observaciones.Tag = "";
            // 
            // PCEncabezado
            // 
            this.PCEncabezado.AllowActive = false;
            this.PCEncabezado.AntiAlias = false;
            this.PCEncabezado.Caption = "Datos Generales";
            this.PCEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.PCEncabezado.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.PCEncabezado.ForeColor = System.Drawing.Color.White;
            this.PCEncabezado.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.PCEncabezado.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.PCEncabezado.Location = new System.Drawing.Point(0, 50);
            this.PCEncabezado.Name = "PCEncabezado";
            this.PCEncabezado.Size = new System.Drawing.Size(1100, 26);
            this.PCEncabezado.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Controls.Add(this.btnGuardar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1100, 50);
            this.panel3.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSize = true;
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.Image = global::Delfin.Logistico.Properties.Resources.undo;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(57, 0);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(51, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
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
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(0, 0);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(57, 50);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue;
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
            this.tableLayoutPanel1.Controls.Add(this.txnDOCV_ValorVtaTotal, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDOCV_PrecVtaTotal, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDOCV_Impuesto1, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDOCV_ValorVtaTotal, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLetras, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txnDOCV_PrecVtaTotal, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.txnDOCV_Impuesto1, 7, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 430);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1100, 81);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // txnDOCV_ValorVtaTotal
            // 
            this.txnDOCV_ValorVtaTotal.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txnDOCV_ValorVtaTotal.Decimales = 2;
            this.txnDOCV_ValorVtaTotal.Enteros = 9;
            this.txnDOCV_ValorVtaTotal.Formato = "###,###,##0.00";
            this.txnDOCV_ValorVtaTotal.Location = new System.Drawing.Point(883, 57);
            this.txnDOCV_ValorVtaTotal.MaxLength = 13;
            this.txnDOCV_ValorVtaTotal.Name = "txnDOCV_ValorVtaTotal";
            this.txnDOCV_ValorVtaTotal.Negativo = true;
            this.txnDOCV_ValorVtaTotal.SinFormato = false;
            this.txnDOCV_ValorVtaTotal.Size = new System.Drawing.Size(194, 20);
            this.txnDOCV_ValorVtaTotal.TabIndex = 7;
            this.txnDOCV_ValorVtaTotal.Text = "0.00";
            this.txnDOCV_ValorVtaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnDOCV_ValorVtaTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Son:";
            // 
            // lblDOCV_PrecVtaTotal
            // 
            this.lblDOCV_PrecVtaTotal.AutoSize = true;
            this.lblDOCV_PrecVtaTotal.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOCV_PrecVtaTotal.Location = new System.Drawing.Point(740, 7);
            this.lblDOCV_PrecVtaTotal.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblDOCV_PrecVtaTotal.Name = "lblDOCV_PrecVtaTotal";
            this.lblDOCV_PrecVtaTotal.Size = new System.Drawing.Size(76, 13);
            this.lblDOCV_PrecVtaTotal.TabIndex = 2;
            this.lblDOCV_PrecVtaTotal.Text = "Sub Total :";
            // 
            // lblDOCV_Impuesto1
            // 
            this.lblDOCV_Impuesto1.AutoSize = true;
            this.lblDOCV_Impuesto1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOCV_Impuesto1.Location = new System.Drawing.Point(740, 34);
            this.lblDOCV_Impuesto1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblDOCV_Impuesto1.Name = "lblDOCV_Impuesto1";
            this.lblDOCV_Impuesto1.Size = new System.Drawing.Size(38, 13);
            this.lblDOCV_Impuesto1.TabIndex = 4;
            this.lblDOCV_Impuesto1.Text = "IGV :";
            // 
            // lblDOCV_ValorVtaTotal
            // 
            this.lblDOCV_ValorVtaTotal.AutoSize = true;
            this.lblDOCV_ValorVtaTotal.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOCV_ValorVtaTotal.Location = new System.Drawing.Point(740, 61);
            this.lblDOCV_ValorVtaTotal.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblDOCV_ValorVtaTotal.Name = "lblDOCV_ValorVtaTotal";
            this.lblDOCV_ValorVtaTotal.Size = new System.Drawing.Size(48, 13);
            this.lblDOCV_ValorVtaTotal.TabIndex = 6;
            this.lblDOCV_ValorVtaTotal.Text = "Total :";
            // 
            // lblLetras
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lblLetras, 4);
            this.lblLetras.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(160, 7);
            this.lblLetras.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(552, 16);
            this.lblLetras.TabIndex = 1;
            // 
            // txnDOCV_PrecVtaTotal
            // 
            this.txnDOCV_PrecVtaTotal.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txnDOCV_PrecVtaTotal.Decimales = 2;
            this.txnDOCV_PrecVtaTotal.Enteros = 9;
            this.txnDOCV_PrecVtaTotal.Formato = "###,###,##0.00";
            this.txnDOCV_PrecVtaTotal.Location = new System.Drawing.Point(883, 3);
            this.txnDOCV_PrecVtaTotal.MaxLength = 13;
            this.txnDOCV_PrecVtaTotal.Name = "txnDOCV_PrecVtaTotal";
            this.txnDOCV_PrecVtaTotal.Negativo = true;
            this.txnDOCV_PrecVtaTotal.SinFormato = false;
            this.txnDOCV_PrecVtaTotal.Size = new System.Drawing.Size(194, 20);
            this.txnDOCV_PrecVtaTotal.TabIndex = 3;
            this.txnDOCV_PrecVtaTotal.Text = "0.00";
            this.txnDOCV_PrecVtaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnDOCV_PrecVtaTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txnDOCV_Impuesto1
            // 
            this.txnDOCV_Impuesto1.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txnDOCV_Impuesto1.Decimales = 2;
            this.txnDOCV_Impuesto1.Enteros = 9;
            this.txnDOCV_Impuesto1.Formato = "###,###,##0.00";
            this.txnDOCV_Impuesto1.Location = new System.Drawing.Point(883, 30);
            this.txnDOCV_Impuesto1.MaxLength = 13;
            this.txnDOCV_Impuesto1.Name = "txnDOCV_Impuesto1";
            this.txnDOCV_Impuesto1.Negativo = true;
            this.txnDOCV_Impuesto1.SinFormato = false;
            this.txnDOCV_Impuesto1.Size = new System.Drawing.Size(194, 20);
            this.txnDOCV_Impuesto1.TabIndex = 5;
            this.txnDOCV_Impuesto1.Text = "0.00";
            this.txnDOCV_Impuesto1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnDOCV_Impuesto1.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // TabDetalleDocVenta
            // 
            this.TabDetalleDocVenta.Controls.Add(this.TabPageServicios);
            this.TabDetalleDocVenta.Controls.Add(this.TabPageNotas);
            this.TabDetalleDocVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabDetalleDocVenta.Location = new System.Drawing.Point(0, 210);
            this.TabDetalleDocVenta.Name = "TabDetalleDocVenta";
            this.TabDetalleDocVenta.SelectedIndex = 0;
            this.TabDetalleDocVenta.SelectedTabColor = System.Drawing.Color.SteelBlue;
            this.TabDetalleDocVenta.Size = new System.Drawing.Size(1100, 220);
            this.TabDetalleDocVenta.TabColor = System.Drawing.Color.LightSteelBlue;
            this.TabDetalleDocVenta.TabIndex = 4;
            this.TabDetalleDocVenta.UseVisualStyles = false;
            // 
            // TabPageServicios
            // 
            this.TabPageServicios.Controls.Add(this.grdItemsServicio);
            this.TabPageServicios.Controls.Add(this.navItems);
            this.TabPageServicios.Location = new System.Drawing.Point(4, 25);
            this.TabPageServicios.Name = "TabPageServicios";
            this.TabPageServicios.Size = new System.Drawing.Size(1092, 191);
            this.TabPageServicios.TabIndex = 0;
            this.TabPageServicios.Text = "Servicios";
            // 
            // grdItemsServicio
            // 
            this.grdItemsServicio.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItemsServicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItemsServicio.Location = new System.Drawing.Point(0, 0);
            this.grdItemsServicio.Name = "grdItemsServicio";
            this.grdItemsServicio.Size = new System.Drawing.Size(1092, 166);
            this.grdItemsServicio.TabIndex = 0;
            this.grdItemsServicio.TabStop = false;
            this.grdItemsServicio.Click += new System.EventHandler(this.grdItemsServicio_Click);
            // 
            // navItems
            // 
            this.navItems.AddNewItem = null;
            this.navItems.BackColor = System.Drawing.Color.LightSteelBlue;
            this.navItems.CountItem = this.toolStripLabel1;
            this.navItems.DeleteItem = null;
            this.navItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.bindingNavigatorSeparator2});
            this.navItems.Location = new System.Drawing.Point(0, 166);
            this.navItems.MoveFirstItem = this.toolStripButton1;
            this.navItems.MoveLastItem = this.toolStripButton4;
            this.navItems.MoveNextItem = this.toolStripButton3;
            this.navItems.MovePreviousItem = this.toolStripButton2;
            this.navItems.Name = "navItems";
            this.navItems.PositionItem = this.toolStripTextBox1;
            this.navItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.navItems.Size = new System.Drawing.Size(1092, 25);
            this.navItems.TabIndex = 10;
            this.navItems.Text = "bindingNavigator1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel1.Text = "de {0}";
            this.toolStripLabel1.ToolTipText = "Número total de elementos";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Mover primero";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeftAutoMirrorImage = true;
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Mover anterior";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleName = "Posición";
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "Posición actual";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Mover siguiente";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // TabPageNotas
            // 
            this.TabPageNotas.Controls.Add(this.tableLayoutPanel2);
            this.TabPageNotas.Location = new System.Drawing.Point(4, 25);
            this.TabPageNotas.Name = "TabPageNotas";
            this.TabPageNotas.Size = new System.Drawing.Size(1092, 191);
            this.TabPageNotas.TabIndex = 2;
            this.TabPageNotas.Text = "Notas";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.LightSteelBlue;
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
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtDOCV_Notas, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtDOCV_Observaciones, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1092, 191);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label11, 2);
            this.label11.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 7);
            this.label11.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Notas";
            // 
            // txtDOCV_Notas
            // 
            this.txtDOCV_Notas.AcceptsReturn = true;
            this.tableLayoutPanel2.SetColumnSpan(this.txtDOCV_Notas, 8);
            this.txtDOCV_Notas.Location = new System.Drawing.Point(3, 30);
            this.txtDOCV_Notas.Multiline = true;
            this.txtDOCV_Notas.Name = "txtDOCV_Notas";
            this.tableLayoutPanel2.SetRowSpan(this.txtDOCV_Notas, 3);
            this.txtDOCV_Notas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDOCV_Notas.Size = new System.Drawing.Size(1074, 75);
            this.txtDOCV_Notas.TabIndex = 1;
            // 
            // PcDocVenta
            // 
            this.PcDocVenta.AllowActive = false;
            this.PcDocVenta.AntiAlias = false;
            this.PcDocVenta.Caption = "Detalle";
            this.PcDocVenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.PcDocVenta.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.PcDocVenta.ForeColor = System.Drawing.Color.White;
            this.PcDocVenta.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.PcDocVenta.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.PcDocVenta.Location = new System.Drawing.Point(0, 184);
            this.PcDocVenta.Name = "PcDocVenta";
            this.PcDocVenta.Size = new System.Drawing.Size(1100, 26);
            this.PcDocVenta.TabIndex = 3;
            // 
            // btnNuevoServicio
            // 
            this.btnNuevoServicio.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoServicio.Image")));
            this.btnNuevoServicio.Location = new System.Drawing.Point(153, 184);
            this.btnNuevoServicio.Name = "btnNuevoServicio";
            this.btnNuevoServicio.Size = new System.Drawing.Size(26, 24);
            this.btnNuevoServicio.TabIndex = 92;
            this.btnNuevoServicio.UseVisualStyleBackColor = true;
            // 
            // errorProviderFacturacion
            // 
            this.errorProviderFacturacion.ContainerControl = this;
            // 
            // PRO007MViewFactLibre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 511);
            this.Controls.Add(this.btnNuevoServicio);
            this.Controls.Add(this.TabDetalleDocVenta);
            this.Controls.Add(this.PcDocVenta);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.TLPanelDatos);
            this.Controls.Add(this.PCEncabezado);
            this.Controls.Add(this.panel3);
            this.Name = "PRO007MViewFactLibre";
            this.Text = "Facturación Libre";
            this.TLPanelDatos.ResumeLayout(false);
            this.TLPanelDatos.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.TabDetalleDocVenta.ResumeLayout(false);
            this.TabPageServicios.ResumeLayout(false);
            this.TabPageServicios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
            this.navItems.ResumeLayout(false);
            this.navItems.PerformLayout();
            this.TabPageNotas.ResumeLayout(false);
            this.TabPageNotas.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFacturacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel TLPanelDatos;
      private System.Windows.Forms.Label lblTIPO_CodTDO;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodTDO;
      private System.Windows.Forms.Label lblDOCV_Numero;
      private System.Windows.Forms.TextBox txtDOCV_Numero;
      private System.Windows.Forms.Label lblDOCV_Serie;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtDOCV_Observaciones;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodFPG;
      private System.Windows.Forms.Label lblTIPO_CodFPG;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMND;
      private System.Windows.Forms.Label lblTIPO_CodMND;
      private System.Windows.Forms.Label lblDOCV_FechaEmision;
      private System.Windows.Forms.Label lblDOCV_FechaVcmto;
      private System.Windows.Forms.Label lblDOCV_Estado;
      private Controls.Tipos.ComboBoxConstantes cmbDOCV_Estado;
      private System.Windows.Forms.Label lblEntidad;
      private System.Windows.Forms.Label lblDOCV_TipoCambio;
      private System.Windows.Forms.Label lblTIPE_Codigo;
      private Controls.ComboBoxTipoEntidad cmbTIPE_Codigo;
      private Infrastructure.WinFormsControls.PanelCaption PCEncabezado;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label lblDOCV_PrecVtaTotal;
      private System.Windows.Forms.Label lblDOCV_Impuesto1;
      private System.Windows.Forms.Label lblDOCV_ValorVtaTotal;
      private System.Windows.Forms.Label lblLetras;
      private Dotnetrix.Controls.TabControlEX TabDetalleDocVenta;
      private Dotnetrix.Controls.TabPageEX TabPageServicios;
      private Telerik.WinControls.UI.RadGridView grdItemsServicio;
      private Dotnetrix.Controls.TabPageEX TabPageNotas;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.TextBox txtDOCV_Notas;
      private Infrastructure.WinFormsControls.PanelCaption PcDocVenta;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnDOCV_ValorVtaTotal;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnDOCV_PrecVtaTotal;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnDOCV_Impuesto1;
      private Controls.EntidadDocIden txaEntidad;
      private Infrastructure.WinForms.Controls.MaskTime dtpDOCV_FechaVcmto;
      private Infrastructure.WinForms.Controls.MaskTime dtpDOCV_FechaEmision;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnDOCV_TipoCambio;
      private System.Windows.Forms.BindingNavigator navItems;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.ToolStripButton toolStripButton2;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton toolStripButton3;
      private System.Windows.Forms.ToolStripButton toolStripButton4;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
      private System.Windows.Forms.Button btnNuevoServicio;
      private System.Windows.Forms.ErrorProvider errorProviderFacturacion;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbDOCV_Serie;
   }
}