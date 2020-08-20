namespace Delfin.Principal
{
    partial class PRO003DSMview
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
         this.label1 = new System.Windows.Forms.Label();
         this.lblBaseAduanero = new System.Windows.Forms.Label();
         this.txtSOPE_Cantidad = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.lblMinimo = new System.Windows.Forms.Label();
         this.tlpTarifarioLogistico = new System.Windows.Forms.TableLayoutPanel();
         this.ENTC_CodigoEntidad = new Delfin.Controls.EntidadClear(this.components);
         this.label4 = new System.Windows.Forms.Label();
         this.cmbTIPE_codigo = new Delfin.Controls.ComboBoxTipoEntidad();
         this.CbTIPO_CodMnd = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.lblStandarSada20 = new System.Windows.Forms.Label();
         this.lblStandar20 = new System.Windows.Forms.Label();
         this.CbBase = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblStandar40 = new System.Windows.Forms.Label();
         this.txtSOPE_ImporteIngreso = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.lblStandarSada40 = new System.Windows.Forms.Label();
         this.txtSOPE_ImporteEgreso = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.label2 = new System.Windows.Forms.Label();
         this.CbTipoGasto = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.label3 = new System.Windows.Forms.Label();
         this.txtSOPE_Costo = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.CbSERV_Codigo = new System.Windows.Forms.ComboBox();
         this.txtSOPE_PrecioUni = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.lblTipoentidad = new System.Windows.Forms.Label();
         this.PnBotones = new System.Windows.Forms.Panel();
         this.btnGuardar = new System.Windows.Forms.Button();
         this.btnAgregar = new System.Windows.Forms.Button();
         this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
         this.tlpTarifarioLogistico.SuspendLayout();
         this.PnBotones.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 34);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(58, 13);
         this.label1.TabIndex = 4;
         this.label1.Text = "Servicio:";
         // 
         // lblBaseAduanero
         // 
         this.lblBaseAduanero.AutoSize = true;
         this.lblBaseAduanero.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblBaseAduanero.Location = new System.Drawing.Point(10, 88);
         this.lblBaseAduanero.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblBaseAduanero.Name = "lblBaseAduanero";
         this.lblBaseAduanero.Size = new System.Drawing.Size(40, 13);
         this.lblBaseAduanero.TabIndex = 10;
         this.lblBaseAduanero.Text = "Base:";
         // 
         // txtSOPE_Cantidad
         // 
         this.txtSOPE_Cantidad.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtSOPE_Cantidad.Decimales = 2;
         this.txtSOPE_Cantidad.Enteros = 9;
         this.txtSOPE_Cantidad.Formato = "###,###,##0.00";
         this.txtSOPE_Cantidad.Location = new System.Drawing.Point(518, 57);
         this.txtSOPE_Cantidad.MaxLength = 9;
         this.txtSOPE_Cantidad.Name = "txtSOPE_Cantidad";
         this.txtSOPE_Cantidad.Negativo = false;
         this.txtSOPE_Cantidad.SinFormato = false;
         this.txtSOPE_Cantidad.Size = new System.Drawing.Size(194, 20);
         this.txtSOPE_Cantidad.TabIndex = 9;
         this.txtSOPE_Cantidad.Tag = "SOPE_CantidadMSGERROR";
         this.txtSOPE_Cantidad.Text = "0.00";
         this.txtSOPE_Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtSOPE_Cantidad.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblMinimo
         // 
         this.lblMinimo.AutoSize = true;
         this.lblMinimo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblMinimo.Location = new System.Drawing.Point(375, 61);
         this.lblMinimo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblMinimo.Name = "lblMinimo";
         this.lblMinimo.Size = new System.Drawing.Size(63, 13);
         this.lblMinimo.TabIndex = 8;
         this.lblMinimo.Text = "Cantidad:";
         // 
         // tlpTarifarioLogistico
         // 
         this.tlpTarifarioLogistico.AutoSize = true;
         this.tlpTarifarioLogistico.BackColor = System.Drawing.Color.LightSteelBlue;
         this.tlpTarifarioLogistico.ColumnCount = 7;
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpTarifarioLogistico.Controls.Add(this.ENTC_CodigoEntidad, 4, 0);
         this.tlpTarifarioLogistico.Controls.Add(this.label4, 0, 0);
         this.tlpTarifarioLogistico.Controls.Add(this.cmbTIPE_codigo, 1, 0);
         this.tlpTarifarioLogistico.Controls.Add(this.CbTIPO_CodMnd, 4, 3);
         this.tlpTarifarioLogistico.Controls.Add(this.lblMinimo, 3, 2);
         this.tlpTarifarioLogistico.Controls.Add(this.txtSOPE_Cantidad, 4, 2);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandarSada20, 3, 3);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandar20, 0, 2);
         this.tlpTarifarioLogistico.Controls.Add(this.CbBase, 1, 3);
         this.tlpTarifarioLogistico.Controls.Add(this.lblBaseAduanero, 0, 3);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandar40, 0, 4);
         this.tlpTarifarioLogistico.Controls.Add(this.txtSOPE_ImporteIngreso, 1, 5);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandarSada40, 3, 5);
         this.tlpTarifarioLogistico.Controls.Add(this.txtSOPE_ImporteEgreso, 4, 5);
         this.tlpTarifarioLogistico.Controls.Add(this.label2, 0, 5);
         this.tlpTarifarioLogistico.Controls.Add(this.CbTipoGasto, 1, 4);
         this.tlpTarifarioLogistico.Controls.Add(this.label3, 3, 4);
         this.tlpTarifarioLogistico.Controls.Add(this.txtSOPE_Costo, 4, 4);
         this.tlpTarifarioLogistico.Controls.Add(this.label1, 0, 1);
         this.tlpTarifarioLogistico.Controls.Add(this.CbSERV_Codigo, 1, 1);
         this.tlpTarifarioLogistico.Controls.Add(this.txtSOPE_PrecioUni, 1, 2);
         this.tlpTarifarioLogistico.Controls.Add(this.lblTipoentidad, 3, 0);
         this.tlpTarifarioLogistico.Dock = System.Windows.Forms.DockStyle.Top;
         this.tlpTarifarioLogistico.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tlpTarifarioLogistico.Location = new System.Drawing.Point(0, 50);
         this.tlpTarifarioLogistico.Name = "tlpTarifarioLogistico";
         this.tlpTarifarioLogistico.RowCount = 8;
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.Size = new System.Drawing.Size(733, 216);
         this.tlpTarifarioLogistico.TabIndex = 1;
         // 
         // ENTC_CodigoEntidad
         // 
         this.ENTC_CodigoEntidad.ActivarAyudaAuto = false;
         this.ENTC_CodigoEntidad.BackColor = System.Drawing.Color.White;
         this.ENTC_CodigoEntidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
         this.ENTC_CodigoEntidad.CrearNuevaEntidad = false;
         this.ENTC_CodigoEntidad.EnabledAyuda = true;
         this.ENTC_CodigoEntidad.EnabledAyudaButton = true;
         this.ENTC_CodigoEntidad.EsFiltro = false;
         this.ENTC_CodigoEntidad.Location = new System.Drawing.Point(518, 3);
         this.ENTC_CodigoEntidad.LongitudAceptada = 0;
         this.ENTC_CodigoEntidad.MaxLength = 100;
         this.ENTC_CodigoEntidad.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
         this.ENTC_CodigoEntidad.Name = "ENTC_CodigoEntidad";
         this.ENTC_CodigoEntidad.PorDocIden = false;
         this.ENTC_CodigoEntidad.RellenaCeros = false;
         this.ENTC_CodigoEntidad.SelectedItem = null;
         this.ENTC_CodigoEntidad.Size = new System.Drawing.Size(194, 20);
         this.ENTC_CodigoEntidad.SoloEntidad = false;
         this.ENTC_CodigoEntidad.TabIndex = 3;
         this.ENTC_CodigoEntidad.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodigoEntidad.TIPO_CodCRG = null;
         this.ENTC_CodigoEntidad.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
         this.ENTC_CodigoEntidad.Value = null;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(10, 7);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(86, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "Tipo Entidad :";
         // 
         // cmbTIPE_codigo
         // 
         this.cmbTIPE_codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPE_codigo.FormattingEnabled = true;
         this.cmbTIPE_codigo.Location = new System.Drawing.Point(153, 3);
         this.cmbTIPE_codigo.Name = "cmbTIPE_codigo";
         this.cmbTIPE_codigo.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPE_codigo.TabIndex = 1;
         this.cmbTIPE_codigo.TipoEntidadSelectedItem = null;
         this.cmbTIPE_codigo.TipoEntidadSelectedValue = null;
         this.cmbTIPE_codigo.TiposTitulo = null;
         // 
         // CbTIPO_CodMnd
         // 
         this.CbTIPO_CodMnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbTIPO_CodMnd.FormattingEnabled = true;
         this.CbTIPO_CodMnd.Location = new System.Drawing.Point(518, 84);
         this.CbTIPO_CodMnd.Name = "CbTIPO_CodMnd";
         this.CbTIPO_CodMnd.Session = null;
         this.CbTIPO_CodMnd.Size = new System.Drawing.Size(194, 21);
         this.CbTIPO_CodMnd.TabIndex = 13;
         this.CbTIPO_CodMnd.Tag = "TIPO_CodMndMSGERROR";
         this.CbTIPO_CodMnd.TiposSelectedItem = null;
         this.CbTIPO_CodMnd.TiposSelectedValue = null;
         this.CbTIPO_CodMnd.TiposTitulo = null;
         // 
         // lblStandarSada20
         // 
         this.lblStandarSada20.AutoSize = true;
         this.lblStandarSada20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandarSada20.Location = new System.Drawing.Point(375, 88);
         this.lblStandarSada20.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandarSada20.Name = "lblStandarSada20";
         this.lblStandarSada20.Size = new System.Drawing.Size(56, 13);
         this.lblStandarSada20.TabIndex = 12;
         this.lblStandarSada20.Text = "Moneda:";
         // 
         // lblStandar20
         // 
         this.lblStandar20.AutoSize = true;
         this.lblStandar20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandar20.Location = new System.Drawing.Point(10, 61);
         this.lblStandar20.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandar20.Name = "lblStandar20";
         this.lblStandar20.Size = new System.Drawing.Size(95, 13);
         this.lblStandar20.TabIndex = 6;
         this.lblStandar20.Text = "Precio Unitario:";
         // 
         // CbBase
         // 
         this.CbBase.ConstantesSelectedItem = null;
         this.CbBase.ConstantesSelectedValue = null;
         this.CbBase.ConstantesTitulo = null;
         this.CbBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbBase.FormattingEnabled = true;
         this.CbBase.Location = new System.Drawing.Point(153, 84);
         this.CbBase.Name = "CbBase";
         this.CbBase.Session = null;
         this.CbBase.Size = new System.Drawing.Size(194, 21);
         this.CbBase.TabIndex = 11;
         this.CbBase.Tag = "CONS_CodBasMSGERROR";
         // 
         // lblStandar40
         // 
         this.lblStandar40.AutoSize = true;
         this.lblStandar40.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandar40.Location = new System.Drawing.Point(10, 115);
         this.lblStandar40.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandar40.Name = "lblStandar40";
         this.lblStandar40.Size = new System.Drawing.Size(73, 13);
         this.lblStandar40.TabIndex = 14;
         this.lblStandar40.Text = "Tipo Gasto:";
         // 
         // txtSOPE_ImporteIngreso
         // 
         this.txtSOPE_ImporteIngreso.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtSOPE_ImporteIngreso.Decimales = 2;
         this.txtSOPE_ImporteIngreso.Enteros = 9;
         this.txtSOPE_ImporteIngreso.Formato = "###,###,##0.00";
         this.txtSOPE_ImporteIngreso.Location = new System.Drawing.Point(153, 138);
         this.txtSOPE_ImporteIngreso.MaxLength = 9;
         this.txtSOPE_ImporteIngreso.Name = "txtSOPE_ImporteIngreso";
         this.txtSOPE_ImporteIngreso.Negativo = false;
         this.txtSOPE_ImporteIngreso.SinFormato = false;
         this.txtSOPE_ImporteIngreso.Size = new System.Drawing.Size(194, 20);
         this.txtSOPE_ImporteIngreso.TabIndex = 19;
         this.txtSOPE_ImporteIngreso.Tag = "SCOT_ImporteIngresoMSGERROR";
         this.txtSOPE_ImporteIngreso.Text = "0.00";
         this.txtSOPE_ImporteIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtSOPE_ImporteIngreso.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblStandarSada40
         // 
         this.lblStandarSada40.AutoSize = true;
         this.lblStandarSada40.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandarSada40.Location = new System.Drawing.Point(375, 142);
         this.lblStandarSada40.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandarSada40.Name = "lblStandarSada40";
         this.lblStandarSada40.Size = new System.Drawing.Size(51, 13);
         this.lblStandarSada40.TabIndex = 20;
         this.lblStandarSada40.Text = "Egreso:";
         // 
         // txtSOPE_ImporteEgreso
         // 
         this.txtSOPE_ImporteEgreso.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtSOPE_ImporteEgreso.Decimales = 2;
         this.txtSOPE_ImporteEgreso.Enteros = 9;
         this.txtSOPE_ImporteEgreso.Formato = "###,###,##0.00";
         this.txtSOPE_ImporteEgreso.Location = new System.Drawing.Point(518, 138);
         this.txtSOPE_ImporteEgreso.MaxLength = 9;
         this.txtSOPE_ImporteEgreso.Name = "txtSOPE_ImporteEgreso";
         this.txtSOPE_ImporteEgreso.Negativo = false;
         this.txtSOPE_ImporteEgreso.SinFormato = false;
         this.txtSOPE_ImporteEgreso.Size = new System.Drawing.Size(194, 20);
         this.txtSOPE_ImporteEgreso.TabIndex = 21;
         this.txtSOPE_ImporteEgreso.Tag = "SCOT_ImporteEgresoMSGERROR";
         this.txtSOPE_ImporteEgreso.Text = "0.00";
         this.txtSOPE_ImporteEgreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtSOPE_ImporteEgreso.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(10, 142);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(56, 13);
         this.label2.TabIndex = 18;
         this.label2.Text = "Ingreso:";
         // 
         // CbTipoGasto
         // 
         this.CbTipoGasto.ConstantesSelectedItem = null;
         this.CbTipoGasto.ConstantesSelectedValue = null;
         this.CbTipoGasto.ConstantesTitulo = null;
         this.CbTipoGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbTipoGasto.FormattingEnabled = true;
         this.CbTipoGasto.Location = new System.Drawing.Point(153, 111);
         this.CbTipoGasto.Name = "CbTipoGasto";
         this.CbTipoGasto.Session = null;
         this.CbTipoGasto.Size = new System.Drawing.Size(194, 21);
         this.CbTipoGasto.TabIndex = 15;
         this.CbTipoGasto.Tag = "CONS_CodTMCMSGERROR";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(375, 115);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(45, 13);
         this.label3.TabIndex = 16;
         this.label3.Text = "Costo:";
         // 
         // txtSOPE_Costo
         // 
         this.txtSOPE_Costo.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtSOPE_Costo.Decimales = 2;
         this.txtSOPE_Costo.Enteros = 9;
         this.txtSOPE_Costo.Formato = "###,###,##0.00";
         this.txtSOPE_Costo.Location = new System.Drawing.Point(518, 111);
         this.txtSOPE_Costo.MaxLength = 9;
         this.txtSOPE_Costo.Name = "txtSOPE_Costo";
         this.txtSOPE_Costo.Negativo = false;
         this.txtSOPE_Costo.SinFormato = false;
         this.txtSOPE_Costo.Size = new System.Drawing.Size(194, 20);
         this.txtSOPE_Costo.TabIndex = 17;
         this.txtSOPE_Costo.Tag = "SOPE_CostoMSGERROR";
         this.txtSOPE_Costo.Text = "0.00";
         this.txtSOPE_Costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtSOPE_Costo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // CbSERV_Codigo
         // 
         this.CbSERV_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbSERV_Codigo.FormattingEnabled = true;
         this.CbSERV_Codigo.Location = new System.Drawing.Point(153, 30);
         this.CbSERV_Codigo.Name = "CbSERV_Codigo";
         this.CbSERV_Codigo.Size = new System.Drawing.Size(194, 21);
         this.CbSERV_Codigo.TabIndex = 5;
         this.CbSERV_Codigo.Tag = "SERV_CodigoMSGERROR";
         // 
         // txtSOPE_PrecioUni
         // 
         this.txtSOPE_PrecioUni.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtSOPE_PrecioUni.Decimales = 2;
         this.txtSOPE_PrecioUni.Enteros = 9;
         this.txtSOPE_PrecioUni.Formato = "###,###,##0.00";
         this.txtSOPE_PrecioUni.Location = new System.Drawing.Point(153, 57);
         this.txtSOPE_PrecioUni.MaxLength = 9;
         this.txtSOPE_PrecioUni.Name = "txtSOPE_PrecioUni";
         this.txtSOPE_PrecioUni.Negativo = false;
         this.txtSOPE_PrecioUni.SinFormato = false;
         this.txtSOPE_PrecioUni.Size = new System.Drawing.Size(194, 20);
         this.txtSOPE_PrecioUni.TabIndex = 7;
         this.txtSOPE_PrecioUni.Tag = "SOPE_PrecioUniMSGERROR";
         this.txtSOPE_PrecioUni.Text = "0.00";
         this.txtSOPE_PrecioUni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtSOPE_PrecioUni.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblTipoentidad
         // 
         this.lblTipoentidad.AutoSize = true;
         this.lblTipoentidad.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTipoentidad.Location = new System.Drawing.Point(375, 7);
         this.lblTipoentidad.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTipoentidad.Name = "lblTipoentidad";
         this.lblTipoentidad.Size = new System.Drawing.Size(58, 13);
         this.lblTipoentidad.TabIndex = 2;
         this.lblTipoentidad.Text = "Entidad :";
         // 
         // PnBotones
         // 
         this.PnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
         this.PnBotones.Controls.Add(this.btnGuardar);
         this.PnBotones.Controls.Add(this.btnAgregar);
         this.PnBotones.Dock = System.Windows.Forms.DockStyle.Top;
         this.PnBotones.Location = new System.Drawing.Point(0, 0);
         this.PnBotones.Name = "PnBotones";
         this.PnBotones.Size = new System.Drawing.Size(733, 50);
         this.PnBotones.TabIndex = 8;
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
         this.btnGuardar.Location = new System.Drawing.Point(57, 0);
         this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
         this.btnGuardar.Name = "btnGuardar";
         this.btnGuardar.Size = new System.Drawing.Size(57, 50);
         this.btnGuardar.TabIndex = 1;
         this.btnGuardar.Text = "&Guardar";
         this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnGuardar.UseVisualStyleBackColor = true;
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
         // PRO003DSMview
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(733, 222);
         this.Controls.Add(this.tlpTarifarioLogistico);
         this.Controls.Add(this.PnBotones);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PRO003DSMview";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Detalle Servicio Cotización";
         this.tlpTarifarioLogistico.ResumeLayout(false);
         this.tlpTarifarioLogistico.PerformLayout();
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
        private Infrastructure.WinFormsControls.TextBoxNumerico txtSOPE_Cantidad;
        private System.Windows.Forms.Label lblMinimo;
        private System.Windows.Forms.TableLayoutPanel tlpTarifarioLogistico;
        private System.Windows.Forms.Label lblTipoentidad;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtSOPE_PrecioUni;
        private System.Windows.Forms.Label lblStandar20;
        private System.Windows.Forms.Label lblStandarSada40;
        private System.Windows.Forms.Label lblStandar40;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtSOPE_ImporteIngreso;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtSOPE_ImporteEgreso;
        private System.Windows.Forms.Label lblStandarSada20;
        private System.Windows.Forms.Panel PnBotones;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox CbSERV_Codigo;
        private System.Windows.Forms.Label label2;
        private Controls.Tipos.ComboBoxConstantes CbTipoGasto;
        private System.Windows.Forms.Label label3;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtSOPE_Costo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label4;
        private Controls.ComboBoxTipoEntidad cmbTIPE_codigo;
        private Controls.EntidadClear ENTC_CodigoEntidad;
    }
}