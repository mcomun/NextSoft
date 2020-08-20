namespace Delfin.Principal
{
    partial class PRO002DSMview
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
         this.CbTIPO_CodMnd = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.label1 = new System.Windows.Forms.Label();
         this.lblBaseAduanero = new System.Windows.Forms.Label();
         this.CbBase = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.txtSCOT_Cantidad = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.lblMinimo = new System.Windows.Forms.Label();
         this.tlpTarifarioLogistico = new System.Windows.Forms.TableLayoutPanel();
         this.lblStandarSada20 = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.ENTC_CodigoEntidad = new Delfin.Controls.Entidad(this.components);
         this.lblTipoentidad = new System.Windows.Forms.Label();
         this.txtSCOT_PrecioUni = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.lblStandar20 = new System.Windows.Forms.Label();
         this.lblStandar40 = new System.Windows.Forms.Label();
         this.CbSERV_Codigo = new System.Windows.Forms.ComboBox();
         this.txtSCOT_ImporteIngreso = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.lblStandarSada40 = new System.Windows.Forms.Label();
         this.txtSCOT_ImporteEgreso = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.label2 = new System.Windows.Forms.Label();
         this.CbTipoGasto = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.PnBotones = new System.Windows.Forms.Panel();
         this.btnAgregar = new System.Windows.Forms.Button();
         this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
         this.tlpTarifarioLogistico.SuspendLayout();
         this.panel1.SuspendLayout();
         this.PnBotones.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
         this.SuspendLayout();
         // 
         // CbTIPO_CodMnd
         // 
         this.CbTIPO_CodMnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbTIPO_CodMnd.FormattingEnabled = true;
         this.CbTIPO_CodMnd.Location = new System.Drawing.Point(471, 57);
         this.CbTIPO_CodMnd.Name = "CbTIPO_CodMnd";
         this.CbTIPO_CodMnd.Size = new System.Drawing.Size(187, 21);
         this.CbTIPO_CodMnd.TabIndex = 10;
         this.CbTIPO_CodMnd.Tag = "TIPO_CodMndMSGERROR";
         this.CbTIPO_CodMnd.TiposSelectedItem = null;
         this.CbTIPO_CodMnd.TiposSelectedValue = null;
         this.CbTIPO_CodMnd.TiposTitulo = null;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(366, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(58, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Servicio:";
         // 
         // lblBaseAduanero
         // 
         this.lblBaseAduanero.AutoSize = true;
         this.lblBaseAduanero.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblBaseAduanero.Location = new System.Drawing.Point(10, 61);
         this.lblBaseAduanero.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblBaseAduanero.Name = "lblBaseAduanero";
         this.lblBaseAduanero.Size = new System.Drawing.Size(40, 13);
         this.lblBaseAduanero.TabIndex = 7;
         this.lblBaseAduanero.Text = "Base:";
         // 
         // CbBase
         // 
         this.CbBase.ConstantesSelectedItem = null;
         this.CbBase.ConstantesSelectedValue = null;
         this.CbBase.ConstantesTitulo = null;
         this.CbBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbBase.FormattingEnabled = true;
         this.CbBase.Location = new System.Drawing.Point(114, 57);
         this.CbBase.Name = "CbBase";
         this.CbBase.Size = new System.Drawing.Size(214, 21);
         this.CbBase.TabIndex = 8;
         this.CbBase.Tag = "CONS_CodBasMSGERROR";
         // 
         // txtSCOT_Cantidad
         // 
         this.txtSCOT_Cantidad.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtSCOT_Cantidad.Decimales = 2;
         this.txtSCOT_Cantidad.Enteros = 9;
         this.txtSCOT_Cantidad.Formato = "###,###,##0.00";
         this.txtSCOT_Cantidad.Location = new System.Drawing.Point(471, 30);
         this.txtSCOT_Cantidad.MaxLength = 9;
         this.txtSCOT_Cantidad.Name = "txtSCOT_Cantidad";
         this.txtSCOT_Cantidad.Negativo = false;
         this.txtSCOT_Cantidad.SinFormato = false;
         this.txtSCOT_Cantidad.Size = new System.Drawing.Size(187, 20);
         this.txtSCOT_Cantidad.TabIndex = 6;
         this.txtSCOT_Cantidad.Tag = "SCOT_CantidadMSGERROR";
         this.txtSCOT_Cantidad.Text = "0.00";
         this.txtSCOT_Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtSCOT_Cantidad.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblMinimo
         // 
         this.lblMinimo.AutoSize = true;
         this.lblMinimo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblMinimo.Location = new System.Drawing.Point(366, 34);
         this.lblMinimo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblMinimo.Name = "lblMinimo";
         this.lblMinimo.Size = new System.Drawing.Size(63, 13);
         this.lblMinimo.TabIndex = 5;
         this.lblMinimo.Text = "Cantidad:";
         // 
         // tlpTarifarioLogistico
         // 
         this.tlpTarifarioLogistico.AutoSize = true;
         this.tlpTarifarioLogistico.BackColor = System.Drawing.Color.LightSteelBlue;
         this.tlpTarifarioLogistico.ColumnCount = 7;
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 227F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpTarifarioLogistico.Controls.Add(this.CbTIPO_CodMnd, 4, 2);
         this.tlpTarifarioLogistico.Controls.Add(this.lblMinimo, 3, 1);
         this.tlpTarifarioLogistico.Controls.Add(this.txtSCOT_Cantidad, 4, 1);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandarSada20, 3, 2);
         this.tlpTarifarioLogistico.Controls.Add(this.panel1, 1, 0);
         this.tlpTarifarioLogistico.Controls.Add(this.lblTipoentidad, 0, 0);
         this.tlpTarifarioLogistico.Controls.Add(this.label1, 3, 0);
         this.tlpTarifarioLogistico.Controls.Add(this.txtSCOT_PrecioUni, 1, 1);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandar20, 0, 1);
         this.tlpTarifarioLogistico.Controls.Add(this.CbBase, 1, 2);
         this.tlpTarifarioLogistico.Controls.Add(this.lblBaseAduanero, 0, 2);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandar40, 0, 3);
         this.tlpTarifarioLogistico.Controls.Add(this.CbSERV_Codigo, 4, 0);
         this.tlpTarifarioLogistico.Controls.Add(this.txtSCOT_ImporteIngreso, 1, 4);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandarSada40, 3, 4);
         this.tlpTarifarioLogistico.Controls.Add(this.txtSCOT_ImporteEgreso, 4, 4);
         this.tlpTarifarioLogistico.Controls.Add(this.label2, 0, 4);
         this.tlpTarifarioLogistico.Controls.Add(this.CbTipoGasto, 1, 3);
         this.tlpTarifarioLogistico.Dock = System.Windows.Forms.DockStyle.Top;
         this.tlpTarifarioLogistico.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tlpTarifarioLogistico.Location = new System.Drawing.Point(0, 50);
         this.tlpTarifarioLogistico.Name = "tlpTarifarioLogistico";
         this.tlpTarifarioLogistico.RowCount = 7;
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tlpTarifarioLogistico.Size = new System.Drawing.Size(693, 189);
         this.tlpTarifarioLogistico.TabIndex = 0;
         // 
         // lblStandarSada20
         // 
         this.lblStandarSada20.AutoSize = true;
         this.lblStandarSada20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandarSada20.Location = new System.Drawing.Point(366, 61);
         this.lblStandarSada20.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandarSada20.Name = "lblStandarSada20";
         this.lblStandarSada20.Size = new System.Drawing.Size(56, 13);
         this.lblStandarSada20.TabIndex = 9;
         this.lblStandarSada20.Text = "Moneda:";
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.ENTC_CodigoEntidad);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel1.Location = new System.Drawing.Point(114, 3);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(221, 21);
         this.panel1.TabIndex = 22;
         this.panel1.Tag = "ENTC_CodigoMSGERROR";
         // 
         // ENTC_CodigoEntidad
         // 
         this.ENTC_CodigoEntidad.ActivarAyudaAuto = false;
         this.ENTC_CodigoEntidad.EnabledAyudaButton = true;
         this.ENTC_CodigoEntidad.Location = new System.Drawing.Point(3, 1);
         this.ENTC_CodigoEntidad.LongitudAceptada = 0;
         this.ENTC_CodigoEntidad.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_CodigoEntidad.Name = "ENTC_CodigoEntidad";
         this.ENTC_CodigoEntidad.RellenaCeros = false;
         this.ENTC_CodigoEntidad.Size = new System.Drawing.Size(211, 20);
         this.ENTC_CodigoEntidad.TabIndex = 0;
         this.ENTC_CodigoEntidad.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodigoEntidad.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Proveedor;
         this.ENTC_CodigoEntidad.Value = null;
         // 
         // lblTipoentidad
         // 
         this.lblTipoentidad.AutoSize = true;
         this.lblTipoentidad.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTipoentidad.Location = new System.Drawing.Point(10, 7);
         this.lblTipoentidad.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTipoentidad.Name = "lblTipoentidad";
         this.lblTipoentidad.Size = new System.Drawing.Size(66, 13);
         this.lblTipoentidad.TabIndex = 0;
         this.lblTipoentidad.Text = "Proveedor";
         // 
         // txtSCOT_PrecioUni
         // 
         this.txtSCOT_PrecioUni.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtSCOT_PrecioUni.Decimales = 2;
         this.txtSCOT_PrecioUni.Enteros = 9;
         this.txtSCOT_PrecioUni.Formato = "###,###,##0.00";
         this.txtSCOT_PrecioUni.Location = new System.Drawing.Point(114, 30);
         this.txtSCOT_PrecioUni.MaxLength = 9;
         this.txtSCOT_PrecioUni.Name = "txtSCOT_PrecioUni";
         this.txtSCOT_PrecioUni.Negativo = false;
         this.txtSCOT_PrecioUni.SinFormato = false;
         this.txtSCOT_PrecioUni.Size = new System.Drawing.Size(214, 20);
         this.txtSCOT_PrecioUni.TabIndex = 4;
         this.txtSCOT_PrecioUni.Tag = "SCOT_PrecioUniMSGERROR";
         this.txtSCOT_PrecioUni.Text = "0.00";
         this.txtSCOT_PrecioUni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtSCOT_PrecioUni.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblStandar20
         // 
         this.lblStandar20.AutoSize = true;
         this.lblStandar20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandar20.Location = new System.Drawing.Point(10, 34);
         this.lblStandar20.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandar20.Name = "lblStandar20";
         this.lblStandar20.Size = new System.Drawing.Size(95, 13);
         this.lblStandar20.TabIndex = 3;
         this.lblStandar20.Text = "Precio Unitario:";
         // 
         // lblStandar40
         // 
         this.lblStandar40.AutoSize = true;
         this.lblStandar40.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandar40.Location = new System.Drawing.Point(10, 88);
         this.lblStandar40.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandar40.Name = "lblStandar40";
         this.lblStandar40.Size = new System.Drawing.Size(73, 13);
         this.lblStandar40.TabIndex = 11;
         this.lblStandar40.Text = "Tipo Gasto:";
         // 
         // CbSERV_Codigo
         // 
         this.CbSERV_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbSERV_Codigo.FormattingEnabled = true;
         this.CbSERV_Codigo.Location = new System.Drawing.Point(471, 3);
         this.CbSERV_Codigo.Name = "CbSERV_Codigo";
         this.CbSERV_Codigo.Size = new System.Drawing.Size(187, 21);
         this.CbSERV_Codigo.TabIndex = 2;
         // 
         // txtSCOT_ImporteIngreso
         // 
         this.txtSCOT_ImporteIngreso.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtSCOT_ImporteIngreso.Decimales = 2;
         this.txtSCOT_ImporteIngreso.Enteros = 9;
         this.txtSCOT_ImporteIngreso.Formato = "###,###,##0.00";
         this.txtSCOT_ImporteIngreso.Location = new System.Drawing.Point(114, 111);
         this.txtSCOT_ImporteIngreso.MaxLength = 9;
         this.txtSCOT_ImporteIngreso.Name = "txtSCOT_ImporteIngreso";
         this.txtSCOT_ImporteIngreso.Negativo = false;
         this.txtSCOT_ImporteIngreso.SinFormato = false;
         this.txtSCOT_ImporteIngreso.Size = new System.Drawing.Size(214, 20);
         this.txtSCOT_ImporteIngreso.TabIndex = 14;
         this.txtSCOT_ImporteIngreso.Tag = "SCOT_ImporteIngresoMSGERROR";
         this.txtSCOT_ImporteIngreso.Text = "0.00";
         this.txtSCOT_ImporteIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtSCOT_ImporteIngreso.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblStandarSada40
         // 
         this.lblStandarSada40.AutoSize = true;
         this.lblStandarSada40.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandarSada40.Location = new System.Drawing.Point(366, 115);
         this.lblStandarSada40.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandarSada40.Name = "lblStandarSada40";
         this.lblStandarSada40.Size = new System.Drawing.Size(51, 13);
         this.lblStandarSada40.TabIndex = 15;
         this.lblStandarSada40.Text = "Egreso:";
         // 
         // txtSCOT_ImporteEgreso
         // 
         this.txtSCOT_ImporteEgreso.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtSCOT_ImporteEgreso.Decimales = 2;
         this.txtSCOT_ImporteEgreso.Enteros = 9;
         this.txtSCOT_ImporteEgreso.Formato = "###,###,##0.00";
         this.txtSCOT_ImporteEgreso.Location = new System.Drawing.Point(471, 111);
         this.txtSCOT_ImporteEgreso.MaxLength = 9;
         this.txtSCOT_ImporteEgreso.Name = "txtSCOT_ImporteEgreso";
         this.txtSCOT_ImporteEgreso.Negativo = false;
         this.txtSCOT_ImporteEgreso.SinFormato = false;
         this.txtSCOT_ImporteEgreso.Size = new System.Drawing.Size(187, 20);
         this.txtSCOT_ImporteEgreso.TabIndex = 16;
         this.txtSCOT_ImporteEgreso.Tag = "SCOT_ImporteEgresoMSGERROR";
         this.txtSCOT_ImporteEgreso.Text = "0.00";
         this.txtSCOT_ImporteEgreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtSCOT_ImporteEgreso.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(10, 115);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(56, 13);
         this.label2.TabIndex = 13;
         this.label2.Text = "Ingreso:";
         // 
         // CbTipoGasto
         // 
         this.CbTipoGasto.ConstantesSelectedItem = null;
         this.CbTipoGasto.ConstantesSelectedValue = null;
         this.CbTipoGasto.ConstantesTitulo = null;
         this.CbTipoGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbTipoGasto.FormattingEnabled = true;
         this.CbTipoGasto.Location = new System.Drawing.Point(114, 84);
         this.CbTipoGasto.Name = "CbTipoGasto";
         this.CbTipoGasto.Size = new System.Drawing.Size(214, 21);
         this.CbTipoGasto.TabIndex = 12;
         this.CbTipoGasto.Tag = "SCOT_IngresoGastoMSGERROR";
         // 
         // PnBotones
         // 
         this.PnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
         this.PnBotones.Controls.Add(this.btnAgregar);
         this.PnBotones.Dock = System.Windows.Forms.DockStyle.Top;
         this.PnBotones.Location = new System.Drawing.Point(0, 0);
         this.PnBotones.Name = "PnBotones";
         this.PnBotones.Size = new System.Drawing.Size(693, 50);
         this.PnBotones.TabIndex = 8;
         // 
         // btnAgregar
         // 
         this.btnAgregar.AutoSize = true;
         this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnAgregar.ForeColor = System.Drawing.Color.Black;
         this.btnAgregar.Image = global::Delfin.Principal.Properties.Resources.add;
         this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnAgregar.Location = new System.Drawing.Point(0, 0);
         this.btnAgregar.Margin = new System.Windows.Forms.Padding(0);
         this.btnAgregar.Name = "btnAgregar";
         this.btnAgregar.Size = new System.Drawing.Size(57, 50);
         this.btnAgregar.TabIndex = 0;
         this.btnAgregar.Text = "&Agregar";
         this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnAgregar.UseVisualStyleBackColor = true;
         // 
         // errorProvider1
         // 
         this.errorProvider1.ContainerControl = this;
         // 
         // PRO002DSMview
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(693, 189);
         this.Controls.Add(this.tlpTarifarioLogistico);
         this.Controls.Add(this.PnBotones);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PRO002DSMview";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Detalle Servicio Cotización";
         this.tlpTarifarioLogistico.ResumeLayout(false);
         this.tlpTarifarioLogistico.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.PnBotones.ResumeLayout(false);
         this.PnBotones.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private Controls.Tipos.ComboBoxTipos CbTIPO_CodMnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBaseAduanero;
        private Controls.Tipos.ComboBoxConstantes CbBase;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtSCOT_Cantidad;
        private System.Windows.Forms.Label lblMinimo;
        private System.Windows.Forms.TableLayoutPanel tlpTarifarioLogistico;
        private System.Windows.Forms.Label lblTipoentidad;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtSCOT_PrecioUni;
        private System.Windows.Forms.Label lblStandar20;
        private System.Windows.Forms.Label lblStandarSada40;
        private System.Windows.Forms.Label lblStandar40;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtSCOT_ImporteIngreso;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtSCOT_ImporteEgreso;
        private System.Windows.Forms.Label lblStandarSada20;
        private System.Windows.Forms.Panel panel1;
        private Controls.Entidad ENTC_CodigoEntidad;
        private System.Windows.Forms.Panel PnBotones;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox CbSERV_Codigo;
        private System.Windows.Forms.Label label2;
        private Controls.Tipos.ComboBoxConstantes CbTipoGasto;
    }
}