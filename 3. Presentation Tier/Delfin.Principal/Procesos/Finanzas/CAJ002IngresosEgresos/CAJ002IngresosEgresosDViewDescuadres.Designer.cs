namespace Delfin.Principal
{
   partial class CAJ002IngresosEgresosDViewDescuadres
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAJ002IngresosEgresosDViewDescuadres));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlDescuadre = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tlpDescuadre = new System.Windows.Forms.TableLayoutPanel();
            this.lblTIPD_Item = new System.Windows.Forms.Label();
            this.txtTIPD_Item = new System.Windows.Forms.TextBox();
            this.lblTIPO_CodDES = new System.Windows.Forms.Label();
            this.cmbTIPO_CodDES = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.lblTIPE_Codigo = new System.Windows.Forms.Label();
            this.cmbTIPE_Codigo = new Delfin.Controls.ComboBoxTipoEntidad();
            this.lblENTC_Codigo = new System.Windows.Forms.Label();
            this.txaENTC_Codigo = new Delfin.Controls.EntidadDocIden();
            this.lblTIPD_MontoDebe = new System.Windows.Forms.Label();
            this.txnTIPD_MontoDebe = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.txnTIPD_MontoHaber = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.lblTIPD_MontoHaber = new System.Windows.Forms.Label();
            this.txnTIPD_TipoCambio = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.lblTIPD_TipoCambio = new System.Windows.Forms.Label();
            this.cmbTIPO_CodMND = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.lblTIPO_CodMND = new System.Windows.Forms.Label();
            this.lblTIPD_Tipo = new System.Windows.Forms.Label();
            this.cmbTIPD_Tipo = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblTIPD_GeneraCtaCte = new System.Windows.Forms.Label();
            this.chkTIPD_GeneraCtaCte = new System.Windows.Forms.CheckBox();
            this.txtTIPD_Cuenta = new System.Windows.Forms.TextBox();
            this.lblTIPD_Cuenta = new System.Windows.Forms.Label();
            this.lblCENT_Codigo = new System.Windows.Forms.Label();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txaCENT_Desc = new Infrastructure.WinForms.Controls.TextBoxAyuda(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbCENT_Ano = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
            this.txaCENT_Codigo = new Infrastructure.WinForms.Controls.TextBoxAyuda(this.components);
            this.errorProviderTipificacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPendiente = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.lblPendiente = new System.Windows.Forms.Label();
            this.txtDifDescuadre = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.lblDifDescuadre = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.tlpDescuadre.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTipificacion)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.panel3.Size = new System.Drawing.Size(1101, 50);
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
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(57, 0);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(55, 50);
            this.btnSalir.TabIndex = 1;
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
            // pnlDescuadre
            // 
            this.pnlDescuadre.AllowActive = false;
            this.pnlDescuadre.AntiAlias = false;
            this.pnlDescuadre.Caption = "Anticipos / Descuadres";
            this.pnlDescuadre.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDescuadre.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.pnlDescuadre.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.pnlDescuadre.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.pnlDescuadre.Location = new System.Drawing.Point(0, 50);
            this.pnlDescuadre.Name = "pnlDescuadre";
            this.pnlDescuadre.Size = new System.Drawing.Size(1101, 26);
            this.pnlDescuadre.TabIndex = 1;
            // 
            // tlpDescuadre
            // 
            this.tlpDescuadre.AutoSize = true;
            this.tlpDescuadre.ColumnCount = 10;
            this.tlpDescuadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDescuadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpDescuadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpDescuadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDescuadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpDescuadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpDescuadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDescuadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpDescuadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpDescuadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDescuadre.Controls.Add(this.lblTIPD_Item, 6, 0);
            this.tlpDescuadre.Controls.Add(this.txtTIPD_Item, 7, 0);
            this.tlpDescuadre.Controls.Add(this.lblTIPO_CodDES, 0, 0);
            this.tlpDescuadre.Controls.Add(this.cmbTIPO_CodDES, 1, 0);
            this.tlpDescuadre.Controls.Add(this.lblTIPE_Codigo, 0, 3);
            this.tlpDescuadre.Controls.Add(this.cmbTIPE_Codigo, 1, 3);
            this.tlpDescuadre.Controls.Add(this.lblENTC_Codigo, 3, 3);
            this.tlpDescuadre.Controls.Add(this.txaENTC_Codigo, 4, 3);
            this.tlpDescuadre.Controls.Add(this.lblTIPD_MontoDebe, 0, 2);
            this.tlpDescuadre.Controls.Add(this.txnTIPD_MontoDebe, 1, 2);
            this.tlpDescuadre.Controls.Add(this.txnTIPD_MontoHaber, 4, 2);
            this.tlpDescuadre.Controls.Add(this.lblTIPD_MontoHaber, 3, 2);
            this.tlpDescuadre.Controls.Add(this.txnTIPD_TipoCambio, 7, 2);
            this.tlpDescuadre.Controls.Add(this.lblTIPD_TipoCambio, 6, 2);
            this.tlpDescuadre.Controls.Add(this.cmbTIPO_CodMND, 7, 1);
            this.tlpDescuadre.Controls.Add(this.lblTIPO_CodMND, 6, 1);
            this.tlpDescuadre.Controls.Add(this.lblTIPD_Tipo, 0, 1);
            this.tlpDescuadre.Controls.Add(this.cmbTIPD_Tipo, 1, 1);
            this.tlpDescuadre.Controls.Add(this.lblTIPD_GeneraCtaCte, 3, 1);
            this.tlpDescuadre.Controls.Add(this.chkTIPD_GeneraCtaCte, 4, 1);
            this.tlpDescuadre.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpDescuadre.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpDescuadre.Location = new System.Drawing.Point(0, 76);
            this.tlpDescuadre.Name = "tlpDescuadre";
            this.tlpDescuadre.RowCount = 4;
            this.tlpDescuadre.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpDescuadre.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpDescuadre.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpDescuadre.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpDescuadre.Size = new System.Drawing.Size(1101, 108);
            this.tlpDescuadre.TabIndex = 2;
            // 
            // lblTIPD_Item
            // 
            this.lblTIPD_Item.AutoSize = true;
            this.lblTIPD_Item.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPD_Item.Location = new System.Drawing.Point(740, 7);
            this.lblTIPD_Item.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPD_Item.Name = "lblTIPD_Item";
            this.lblTIPD_Item.Size = new System.Drawing.Size(58, 13);
            this.lblTIPD_Item.TabIndex = 2;
            this.lblTIPD_Item.Text = "Interno :";
            // 
            // txtTIPD_Item
            // 
            this.txtTIPD_Item.Location = new System.Drawing.Point(883, 3);
            this.txtTIPD_Item.Name = "txtTIPD_Item";
            this.txtTIPD_Item.Size = new System.Drawing.Size(194, 20);
            this.txtTIPD_Item.TabIndex = 2;
            // 
            // lblTIPO_CodDES
            // 
            this.lblTIPO_CodDES.AutoSize = true;
            this.lblTIPO_CodDES.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodDES.Location = new System.Drawing.Point(10, 7);
            this.lblTIPO_CodDES.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodDES.Name = "lblTIPO_CodDES";
            this.lblTIPO_CodDES.Size = new System.Drawing.Size(79, 13);
            this.lblTIPO_CodDES.TabIndex = 0;
            this.lblTIPO_CodDES.Text = "Tipificación :";
            // 
            // cmbTIPO_CodDES
            // 
            this.tlpDescuadre.SetColumnSpan(this.cmbTIPO_CodDES, 4);
            this.cmbTIPO_CodDES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodDES.FormattingEnabled = true;
            this.cmbTIPO_CodDES.Location = new System.Drawing.Point(153, 3);
            this.cmbTIPO_CodDES.Name = "cmbTIPO_CodDES";
            this.cmbTIPO_CodDES.Session = null;
            this.cmbTIPO_CodDES.Size = new System.Drawing.Size(559, 21);
            this.cmbTIPO_CodDES.TabIndex = 1;
            this.cmbTIPO_CodDES.TiposSelectedItem = null;
            this.cmbTIPO_CodDES.TiposSelectedValue = null;
            this.cmbTIPO_CodDES.TiposTitulo = null;
            // 
            // lblTIPE_Codigo
            // 
            this.lblTIPE_Codigo.AutoSize = true;
            this.lblTIPE_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPE_Codigo.Location = new System.Drawing.Point(10, 88);
            this.lblTIPE_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPE_Codigo.Name = "lblTIPE_Codigo";
            this.lblTIPE_Codigo.Size = new System.Drawing.Size(86, 13);
            this.lblTIPE_Codigo.TabIndex = 14;
            this.lblTIPE_Codigo.Text = "Tipo Entidad :";
            // 
            // cmbTIPE_Codigo
            // 
            this.cmbTIPE_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPE_Codigo.FormattingEnabled = true;
            this.cmbTIPE_Codigo.Location = new System.Drawing.Point(153, 84);
            this.cmbTIPE_Codigo.Name = "cmbTIPE_Codigo";
            this.cmbTIPE_Codigo.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPE_Codigo.TabIndex = 15;
            this.cmbTIPE_Codigo.TipoEntidadSelectedItem = null;
            this.cmbTIPE_Codigo.TipoEntidadSelectedValue = null;
            this.cmbTIPE_Codigo.TiposTitulo = null;
            // 
            // lblENTC_Codigo
            // 
            this.lblENTC_Codigo.AutoSize = true;
            this.lblENTC_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_Codigo.Location = new System.Drawing.Point(375, 88);
            this.lblENTC_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblENTC_Codigo.Name = "lblENTC_Codigo";
            this.lblENTC_Codigo.Size = new System.Drawing.Size(58, 13);
            this.lblENTC_Codigo.TabIndex = 16;
            this.lblENTC_Codigo.Text = "Entidad :";
            // 
            // txaENTC_Codigo
            // 
            this.txaENTC_Codigo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txaENTC_Codigo.CrearNuevaEntidad = false;
            this.txaENTC_Codigo.Location = new System.Drawing.Point(515, 81);
            this.txaENTC_Codigo.Margin = new System.Windows.Forms.Padding(0);
            this.txaENTC_Codigo.MinimumSize = new System.Drawing.Size(565, 27);
            this.txaENTC_Codigo.Name = "txaENTC_Codigo";
            this.txaENTC_Codigo.Size = new System.Drawing.Size(565, 27);
            this.txaENTC_Codigo.SoloEntidad = false;
            this.txaENTC_Codigo.TabIndex = 17;
            this.txaENTC_Codigo.TagEntidad = null;
            this.txaENTC_Codigo.TiposEntidad = Delfin.Controls.TiposEntidad.TIPE_AgenciaAduanera;
            this.txaENTC_Codigo.txaENTC_DOCIDEN_Name = "txaENTC_DOCIDEN";
            this.txaENTC_Codigo.txaENTC_NOMCOMPLETO_Name = "txaENTC_NOMCOMPLETO";
            // 
            // lblTIPD_MontoDebe
            // 
            this.lblTIPD_MontoDebe.AutoSize = true;
            this.lblTIPD_MontoDebe.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPD_MontoDebe.Location = new System.Drawing.Point(10, 61);
            this.lblTIPD_MontoDebe.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPD_MontoDebe.Name = "lblTIPD_MontoDebe";
            this.lblTIPD_MontoDebe.Size = new System.Drawing.Size(84, 13);
            this.lblTIPD_MontoDebe.TabIndex = 8;
            this.lblTIPD_MontoDebe.Text = "Monto Debe :";
            // 
            // txnTIPD_MontoDebe
            // 
            this.txnTIPD_MontoDebe.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txnTIPD_MontoDebe.Decimales = 2;
            this.txnTIPD_MontoDebe.Enteros = 9;
            this.txnTIPD_MontoDebe.Formato = "###,###,##0.00";
            this.txnTIPD_MontoDebe.Location = new System.Drawing.Point(153, 57);
            this.txnTIPD_MontoDebe.MaxLength = 13;
            this.txnTIPD_MontoDebe.Name = "txnTIPD_MontoDebe";
            this.txnTIPD_MontoDebe.Negativo = true;
            this.txnTIPD_MontoDebe.SinFormato = false;
            this.txnTIPD_MontoDebe.Size = new System.Drawing.Size(194, 20);
            this.txnTIPD_MontoDebe.TabIndex = 9;
            this.txnTIPD_MontoDebe.Text = "0.00";
            this.txnTIPD_MontoDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnTIPD_MontoDebe.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txnTIPD_MontoHaber
            // 
            this.txnTIPD_MontoHaber.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txnTIPD_MontoHaber.Decimales = 2;
            this.txnTIPD_MontoHaber.Enteros = 9;
            this.txnTIPD_MontoHaber.Formato = "###,###,##0.00";
            this.txnTIPD_MontoHaber.Location = new System.Drawing.Point(518, 57);
            this.txnTIPD_MontoHaber.MaxLength = 13;
            this.txnTIPD_MontoHaber.Name = "txnTIPD_MontoHaber";
            this.txnTIPD_MontoHaber.Negativo = true;
            this.txnTIPD_MontoHaber.SinFormato = false;
            this.txnTIPD_MontoHaber.Size = new System.Drawing.Size(194, 20);
            this.txnTIPD_MontoHaber.TabIndex = 11;
            this.txnTIPD_MontoHaber.Text = "0.00";
            this.txnTIPD_MontoHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnTIPD_MontoHaber.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblTIPD_MontoHaber
            // 
            this.lblTIPD_MontoHaber.AutoSize = true;
            this.lblTIPD_MontoHaber.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPD_MontoHaber.Location = new System.Drawing.Point(375, 61);
            this.lblTIPD_MontoHaber.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPD_MontoHaber.Name = "lblTIPD_MontoHaber";
            this.lblTIPD_MontoHaber.Size = new System.Drawing.Size(88, 13);
            this.lblTIPD_MontoHaber.TabIndex = 10;
            this.lblTIPD_MontoHaber.Text = "Monto Haber :";
            // 
            // txnTIPD_TipoCambio
            // 
            this.txnTIPD_TipoCambio.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Moneda;
            this.txnTIPD_TipoCambio.Decimales = 4;
            this.txnTIPD_TipoCambio.Enteros = 1;
            this.txnTIPD_TipoCambio.Formato = "0.0000";
            this.txnTIPD_TipoCambio.Location = new System.Drawing.Point(883, 57);
            this.txnTIPD_TipoCambio.MaxLength = 6;
            this.txnTIPD_TipoCambio.Name = "txnTIPD_TipoCambio";
            this.txnTIPD_TipoCambio.Negativo = true;
            this.txnTIPD_TipoCambio.SinFormato = false;
            this.txnTIPD_TipoCambio.Size = new System.Drawing.Size(194, 20);
            this.txnTIPD_TipoCambio.TabIndex = 13;
            this.txnTIPD_TipoCambio.Text = "0.0000";
            this.txnTIPD_TipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnTIPD_TipoCambio.Value = new decimal(new int[] {
            0,
            0,
            0,
            262144});
            // 
            // lblTIPD_TipoCambio
            // 
            this.lblTIPD_TipoCambio.AutoSize = true;
            this.lblTIPD_TipoCambio.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPD_TipoCambio.Location = new System.Drawing.Point(740, 61);
            this.lblTIPD_TipoCambio.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPD_TipoCambio.Name = "lblTIPD_TipoCambio";
            this.lblTIPD_TipoCambio.Size = new System.Drawing.Size(110, 13);
            this.lblTIPD_TipoCambio.TabIndex = 12;
            this.lblTIPD_TipoCambio.Text = "Tipo de Cambio : ";
            // 
            // cmbTIPO_CodMND
            // 
            this.cmbTIPO_CodMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodMND.FormattingEnabled = true;
            this.cmbTIPO_CodMND.Location = new System.Drawing.Point(883, 30);
            this.cmbTIPO_CodMND.Name = "cmbTIPO_CodMND";
            this.cmbTIPO_CodMND.Session = null;
            this.cmbTIPO_CodMND.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPO_CodMND.TabIndex = 7;
            this.cmbTIPO_CodMND.TiposSelectedItem = null;
            this.cmbTIPO_CodMND.TiposSelectedValue = null;
            this.cmbTIPO_CodMND.TiposTitulo = null;
            // 
            // lblTIPO_CodMND
            // 
            this.lblTIPO_CodMND.AutoSize = true;
            this.lblTIPO_CodMND.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodMND.Location = new System.Drawing.Point(740, 34);
            this.lblTIPO_CodMND.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodMND.Name = "lblTIPO_CodMND";
            this.lblTIPO_CodMND.Size = new System.Drawing.Size(60, 13);
            this.lblTIPO_CodMND.TabIndex = 6;
            this.lblTIPO_CodMND.Text = "Moneda :";
            // 
            // lblTIPD_Tipo
            // 
            this.lblTIPD_Tipo.AutoSize = true;
            this.lblTIPD_Tipo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPD_Tipo.Location = new System.Drawing.Point(10, 34);
            this.lblTIPD_Tipo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPD_Tipo.Name = "lblTIPD_Tipo";
            this.lblTIPD_Tipo.Size = new System.Drawing.Size(44, 13);
            this.lblTIPD_Tipo.TabIndex = 4;
            this.lblTIPD_Tipo.Text = "Tipo : ";
            // 
            // cmbTIPD_Tipo
            // 
            this.cmbTIPD_Tipo.ConstantesSelectedItem = null;
            this.cmbTIPD_Tipo.ConstantesSelectedValue = null;
            this.cmbTIPD_Tipo.ConstantesTitulo = null;
            this.cmbTIPD_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPD_Tipo.FormattingEnabled = true;
            this.cmbTIPD_Tipo.Location = new System.Drawing.Point(153, 30);
            this.cmbTIPD_Tipo.Name = "cmbTIPD_Tipo";
            this.cmbTIPD_Tipo.Session = null;
            this.cmbTIPD_Tipo.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPD_Tipo.TabIndex = 5;
            // 
            // lblTIPD_GeneraCtaCte
            // 
            this.lblTIPD_GeneraCtaCte.AutoSize = true;
            this.lblTIPD_GeneraCtaCte.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPD_GeneraCtaCte.Location = new System.Drawing.Point(375, 34);
            this.lblTIPD_GeneraCtaCte.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPD_GeneraCtaCte.Name = "lblTIPD_GeneraCtaCte";
            this.lblTIPD_GeneraCtaCte.Size = new System.Drawing.Size(114, 13);
            this.lblTIPD_GeneraCtaCte.TabIndex = 2;
            this.lblTIPD_GeneraCtaCte.Text = "Genera Cta. Cte. :";
            // 
            // chkTIPD_GeneraCtaCte
            // 
            this.chkTIPD_GeneraCtaCte.AutoSize = true;
            this.chkTIPD_GeneraCtaCte.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTIPD_GeneraCtaCte.Location = new System.Drawing.Point(518, 34);
            this.chkTIPD_GeneraCtaCte.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.chkTIPD_GeneraCtaCte.Name = "chkTIPD_GeneraCtaCte";
            this.chkTIPD_GeneraCtaCte.Size = new System.Drawing.Size(15, 14);
            this.chkTIPD_GeneraCtaCte.TabIndex = 3;
            this.chkTIPD_GeneraCtaCte.UseVisualStyleBackColor = true;
            // 
            // txtTIPD_Cuenta
            // 
            this.txtTIPD_Cuenta.Location = new System.Drawing.Point(153, 3);
            this.txtTIPD_Cuenta.Name = "txtTIPD_Cuenta";
            this.txtTIPD_Cuenta.Size = new System.Drawing.Size(194, 20);
            this.txtTIPD_Cuenta.TabIndex = 1;
            // 
            // lblTIPD_Cuenta
            // 
            this.lblTIPD_Cuenta.AutoSize = true;
            this.lblTIPD_Cuenta.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPD_Cuenta.Location = new System.Drawing.Point(10, 7);
            this.lblTIPD_Cuenta.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPD_Cuenta.Name = "lblTIPD_Cuenta";
            this.lblTIPD_Cuenta.Size = new System.Drawing.Size(57, 13);
            this.lblTIPD_Cuenta.TabIndex = 0;
            this.lblTIPD_Cuenta.Text = "Cuenta :";
            // 
            // lblCENT_Codigo
            // 
            this.lblCENT_Codigo.AutoSize = true;
            this.lblCENT_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCENT_Codigo.Location = new System.Drawing.Point(375, 7);
            this.lblCENT_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCENT_Codigo.Name = "lblCENT_Codigo";
            this.lblCENT_Codigo.Size = new System.Drawing.Size(110, 13);
            this.lblCENT_Codigo.TabIndex = 2;
            this.lblCENT_Codigo.Text = "Centro de Costo :";
            // 
            // panelCaption1
            // 
            this.panelCaption1.AllowActive = false;
            this.panelCaption1.AntiAlias = false;
            this.panelCaption1.Caption = "Datos Contables";
            this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption1.Location = new System.Drawing.Point(0, 184);
            this.panelCaption1.Name = "panelCaption1";
            this.panelCaption1.Size = new System.Drawing.Size(1101, 26);
            this.panelCaption1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.txaCENT_Desc, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCENT_Codigo, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTIPD_Cuenta, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTIPD_Cuenta, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 210);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1101, 27);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // txaCENT_Desc
            // 
            this.txaCENT_Desc.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.txaCENT_Desc, 3);
            this.txaCENT_Desc.EnabledAyuda = true;
            this.txaCENT_Desc.EnabledAyudaButton = true;
            this.txaCENT_Desc.EsFiltro = false;
            this.txaCENT_Desc.Location = new System.Drawing.Point(733, 3);
            this.txaCENT_Desc.LongitudAceptada = 0;
            this.txaCENT_Desc.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
            this.txaCENT_Desc.Name = "txaCENT_Desc";
            this.txaCENT_Desc.RellenaCeros = false;
            this.txaCENT_Desc.Size = new System.Drawing.Size(344, 20);
            this.txaCENT_Desc.TabIndex = 4;
            this.txaCENT_Desc.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
            this.txaCENT_Desc.Value = null;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.Controls.Add(this.cmbCENT_Ano, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txaCENT_Codigo, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(515, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 27);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // cmbCENT_Ano
            // 
            this.cmbCENT_Ano.ComboIntSelectedValue = null;
            this.cmbCENT_Ano.ComboSelectedItem = null;
            this.cmbCENT_Ano.ComboStrSelectedValue = null;
            this.cmbCENT_Ano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCENT_Ano.FormattingEnabled = true;
            this.cmbCENT_Ano.Location = new System.Drawing.Point(3, 3);
            this.cmbCENT_Ano.Name = "cmbCENT_Ano";
            this.cmbCENT_Ano.Size = new System.Drawing.Size(64, 21);
            this.cmbCENT_Ano.TabIndex = 0;
            // 
            // txaCENT_Codigo
            // 
            this.txaCENT_Codigo.ActivarAyudaAuto = false;
            this.txaCENT_Codigo.EnabledAyuda = true;
            this.txaCENT_Codigo.EnabledAyudaButton = true;
            this.txaCENT_Codigo.EsFiltro = false;
            this.txaCENT_Codigo.Location = new System.Drawing.Point(73, 3);
            this.txaCENT_Codigo.LongitudAceptada = 0;
            this.txaCENT_Codigo.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
            this.txaCENT_Codigo.Name = "txaCENT_Codigo";
            this.txaCENT_Codigo.RellenaCeros = false;
            this.txaCENT_Codigo.Size = new System.Drawing.Size(124, 20);
            this.txaCENT_Codigo.TabIndex = 1;
            this.txaCENT_Codigo.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
            this.txaCENT_Codigo.Value = null;
            // 
            // errorProviderTipificacion
            // 
            this.errorProviderTipificacion.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderTipificacion.ContainerControl = this;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.txtPendiente);
            this.panel2.Controls.Add(this.lblPendiente);
            this.panel2.Controls.Add(this.txtDifDescuadre);
            this.panel2.Controls.Add(this.lblDifDescuadre);
            this.panel2.Location = new System.Drawing.Point(553, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(529, 24);
            this.panel2.TabIndex = 7;
            // 
            // txtPendiente
            // 
            this.txtPendiente.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txtPendiente.Decimales = 2;
            this.txtPendiente.Enteros = 9;
            this.txtPendiente.Formato = "###,###,##0.00";
            this.txtPendiente.Location = new System.Drawing.Point(421, 2);
            this.txtPendiente.MaxLength = 13;
            this.txtPendiente.Name = "txtPendiente";
            this.txtPendiente.Negativo = true;
            this.txtPendiente.SinFormato = false;
            this.txtPendiente.Size = new System.Drawing.Size(101, 20);
            this.txtPendiente.TabIndex = 7;
            this.txtPendiente.Text = "0.00";
            this.txtPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPendiente.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblPendiente
            // 
            this.lblPendiente.AutoSize = true;
            this.lblPendiente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendiente.ForeColor = System.Drawing.Color.White;
            this.lblPendiente.Location = new System.Drawing.Point(308, 6);
            this.lblPendiente.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblPendiente.Name = "lblPendiente";
            this.lblPendiente.Size = new System.Drawing.Size(95, 13);
            this.lblPendiente.TabIndex = 8;
            this.lblPendiente.Text = "Dif. Pendiente :";
            // 
            // txtDifDescuadre
            // 
            this.txtDifDescuadre.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txtDifDescuadre.Decimales = 2;
            this.txtDifDescuadre.Enteros = 9;
            this.txtDifDescuadre.Formato = "###,###,##0.00";
            this.txtDifDescuadre.Location = new System.Drawing.Point(189, 2);
            this.txtDifDescuadre.MaxLength = 13;
            this.txtDifDescuadre.Name = "txtDifDescuadre";
            this.txtDifDescuadre.Negativo = true;
            this.txtDifDescuadre.SinFormato = false;
            this.txtDifDescuadre.Size = new System.Drawing.Size(101, 20);
            this.txtDifDescuadre.TabIndex = 6;
            this.txtDifDescuadre.Text = "0.00";
            this.txtDifDescuadre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDifDescuadre.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblDifDescuadre
            // 
            this.lblDifDescuadre.AutoSize = true;
            this.lblDifDescuadre.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifDescuadre.ForeColor = System.Drawing.Color.White;
            this.lblDifDescuadre.Location = new System.Drawing.Point(9, 6);
            this.lblDifDescuadre.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblDifDescuadre.Name = "lblDifDescuadre";
            this.lblDifDescuadre.Size = new System.Drawing.Size(162, 13);
            this.lblDifDescuadre.TabIndex = 6;
            this.lblDifDescuadre.Text = "Total Anticipo /Descuadre :";
            // 
            // CAJ002IngresosEgresosDViewDescuadres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1101, 249);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.tlpDescuadre);
            this.Controls.Add(this.pnlDescuadre);
            this.Controls.Add(this.panel3);
            this.Name = "CAJ002IngresosEgresosDViewDescuadres";
            this.Text = "Descuadres / Anticipos";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tlpDescuadre.ResumeLayout(false);
            this.tlpDescuadre.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTipificacion)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel3;
      private Infrastructure.WinForms.Controls.PanelCaption pnlDescuadre;
      private System.Windows.Forms.TableLayoutPanel tlpDescuadre;
      private System.Windows.Forms.CheckBox chkTIPD_GeneraCtaCte;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnTIPD_MontoDebe;
      private System.Windows.Forms.TextBox txtTIPD_Cuenta;
      private System.Windows.Forms.Label lblTIPD_MontoDebe;
      private System.Windows.Forms.Label lblTIPO_CodDES;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodDES;
      private Controls.Tipos.ComboBoxConstantes cmbTIPD_Tipo;
      private System.Windows.Forms.Label lblTIPD_Tipo;
      private System.Windows.Forms.Button btnGuardar;
      private System.Windows.Forms.Label lblTIPO_CodMND;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMND;
      private System.Windows.Forms.Label lblCENT_Codigo;
      private System.Windows.Forms.Label lblTIPD_Cuenta;
      private System.Windows.Forms.Label lblTIPD_TipoCambio;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnTIPD_TipoCambio;
      private Controls.ComboBoxTipoEntidad cmbTIPE_Codigo;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnTIPD_MontoHaber;
      private System.Windows.Forms.Label lblTIPD_MontoHaber;
      private System.Windows.Forms.Label lblTIPE_Codigo;
      private Controls.EntidadDocIden txaENTC_Codigo;
      private System.Windows.Forms.Label lblENTC_Codigo;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbCENT_Ano;
      private Infrastructure.WinForms.Controls.TextBoxAyuda txaCENT_Codigo;
      private Infrastructure.WinForms.Controls.TextBoxAyuda txaCENT_Desc;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Label lblTIPD_GeneraCtaCte;
      private System.Windows.Forms.TextBox txtTIPD_Item;
      private System.Windows.Forms.Label lblTIPD_Item;
      private System.Windows.Forms.ErrorProvider errorProviderTipificacion;
      private System.Windows.Forms.Panel panel2;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txtPendiente;
      private System.Windows.Forms.Label lblPendiente;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txtDifDescuadre;
      private System.Windows.Forms.Label lblDifDescuadre;
   }
}