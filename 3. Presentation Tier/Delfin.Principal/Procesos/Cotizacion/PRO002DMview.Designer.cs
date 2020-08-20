namespace Delfin.Principal
{
    partial class PRO002DMview
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
         this.tlpTarifarioAduaneroTransp = new System.Windows.Forms.TableLayoutPanel();
         this.lblRoundtrip = new System.Windows.Forms.Label();
         this.chkRoundtrip = new System.Windows.Forms.CheckBox();
         this.CbDestino = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.CbOrigen = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.lblDestino = new System.Windows.Forms.Label();
         this.CbTipo = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.label1 = new System.Windows.Forms.Label();
         this.lblOrigen = new System.Windows.Forms.Label();
         this.lblCostoAduanero = new System.Windows.Forms.Label();
         this.lblBaseAduanero = new System.Windows.Forms.Label();
         this.txtCostoAduTransp = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.CbBase = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.txtMinimo = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.lblMinimo = new System.Windows.Forms.Label();
         this.tlpTarifarioLogistico = new System.Windows.Forms.TableLayoutPanel();
         this.PnHBL = new Infrastructure.WinFormsControls.PanelCaption();
         this.PnStandar40 = new Infrastructure.WinFormsControls.PanelCaption();
         this.PnStandar20 = new Infrastructure.WinFormsControls.PanelCaption();
         this.lblCONT_Numero = new System.Windows.Forms.Label();
         this.CbTipoEntidad = new System.Windows.Forms.ComboBox();
         this.lblTipoentidad = new System.Windows.Forms.Label();
         this.txtVenta20 = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.lblStandar20 = new System.Windows.Forms.Label();
         this.txtVentaSada20 = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.lblStandarSada40 = new System.Windows.Forms.Label();
         this.lblStandar40 = new System.Windows.Forms.Label();
         this.txtVenta40 = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.txtVentaSada40 = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.lblStandarHBLSada = new System.Windows.Forms.Label();
         this.txtHBL = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.txtHBLSada = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.lblStandarSada20 = new System.Windows.Forms.Label();
         this.lblStandarHBL = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.ENTC_CodigoEntidad = new Delfin.Controls.Entidad(this.components);
         this.PnBotones = new System.Windows.Forms.Panel();
         this.btnAgregar = new System.Windows.Forms.Button();
         this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
         this.tlpTarifarioAduaneroTransp.SuspendLayout();
         this.tlpTarifarioLogistico.SuspendLayout();
         this.panel1.SuspendLayout();
         this.PnBotones.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
         this.SuspendLayout();
         // 
         // tlpTarifarioAduaneroTransp
         // 
         this.tlpTarifarioAduaneroTransp.AutoSize = true;
         this.tlpTarifarioAduaneroTransp.BackColor = System.Drawing.Color.LightSteelBlue;
         this.tlpTarifarioAduaneroTransp.ColumnCount = 7;
         this.tlpTarifarioAduaneroTransp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
         this.tlpTarifarioAduaneroTransp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
         this.tlpTarifarioAduaneroTransp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
         this.tlpTarifarioAduaneroTransp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
         this.tlpTarifarioAduaneroTransp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247F));
         this.tlpTarifarioAduaneroTransp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tlpTarifarioAduaneroTransp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpTarifarioAduaneroTransp.Controls.Add(this.lblRoundtrip, 0, 4);
         this.tlpTarifarioAduaneroTransp.Controls.Add(this.chkRoundtrip, 1, 4);
         this.tlpTarifarioAduaneroTransp.Controls.Add(this.CbDestino, 4, 3);
         this.tlpTarifarioAduaneroTransp.Controls.Add(this.CbOrigen, 1, 3);
         this.tlpTarifarioAduaneroTransp.Controls.Add(this.lblDestino, 3, 3);
         this.tlpTarifarioAduaneroTransp.Controls.Add(this.CbTipo, 1, 0);
         this.tlpTarifarioAduaneroTransp.Controls.Add(this.label1, 0, 0);
         this.tlpTarifarioAduaneroTransp.Controls.Add(this.lblOrigen, 0, 3);
         this.tlpTarifarioAduaneroTransp.Controls.Add(this.lblCostoAduanero, 0, 1);
         this.tlpTarifarioAduaneroTransp.Controls.Add(this.lblBaseAduanero, 3, 1);
         this.tlpTarifarioAduaneroTransp.Controls.Add(this.txtCostoAduTransp, 1, 1);
         this.tlpTarifarioAduaneroTransp.Controls.Add(this.CbBase, 4, 1);
         this.tlpTarifarioAduaneroTransp.Controls.Add(this.txtMinimo, 1, 2);
         this.tlpTarifarioAduaneroTransp.Controls.Add(this.lblMinimo, 0, 2);
         this.tlpTarifarioAduaneroTransp.Dock = System.Windows.Forms.DockStyle.Top;
         this.tlpTarifarioAduaneroTransp.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tlpTarifarioAduaneroTransp.Location = new System.Drawing.Point(0, 239);
         this.tlpTarifarioAduaneroTransp.Name = "tlpTarifarioAduaneroTransp";
         this.tlpTarifarioAduaneroTransp.RowCount = 5;
         this.tlpTarifarioAduaneroTransp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioAduaneroTransp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioAduaneroTransp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioAduaneroTransp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioAduaneroTransp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioAduaneroTransp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tlpTarifarioAduaneroTransp.Size = new System.Drawing.Size(734, 135);
         this.tlpTarifarioAduaneroTransp.TabIndex = 1;
         // 
         // lblRoundtrip
         // 
         this.lblRoundtrip.AutoSize = true;
         this.lblRoundtrip.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblRoundtrip.Location = new System.Drawing.Point(10, 115);
         this.lblRoundtrip.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblRoundtrip.Name = "lblRoundtrip";
         this.lblRoundtrip.Size = new System.Drawing.Size(67, 13);
         this.lblRoundtrip.TabIndex = 12;
         this.lblRoundtrip.Text = "Roundtrip:";
         // 
         // chkRoundtrip
         // 
         this.chkRoundtrip.AutoSize = true;
         this.chkRoundtrip.Location = new System.Drawing.Point(114, 115);
         this.chkRoundtrip.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
         this.chkRoundtrip.Name = "chkRoundtrip";
         this.chkRoundtrip.Size = new System.Drawing.Size(15, 14);
         this.chkRoundtrip.TabIndex = 13;
         this.chkRoundtrip.UseVisualStyleBackColor = true;
         // 
         // CbDestino
         // 
         this.CbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbDestino.FormattingEnabled = true;
         this.CbDestino.Location = new System.Drawing.Point(471, 84);
         this.CbDestino.Name = "CbDestino";
         this.CbDestino.Size = new System.Drawing.Size(241, 21);
         this.CbDestino.TabIndex = 11;
         this.CbDestino.Tag = "TIPO_CodZONDestinoMSGERROR";
         this.CbDestino.TiposSelectedItem = null;
         this.CbDestino.TiposSelectedValue = null;
         this.CbDestino.TiposTitulo = null;
         // 
         // CbOrigen
         // 
         this.CbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbOrigen.FormattingEnabled = true;
         this.CbOrigen.Location = new System.Drawing.Point(114, 84);
         this.CbOrigen.Name = "CbOrigen";
         this.CbOrigen.Size = new System.Drawing.Size(187, 21);
         this.CbOrigen.TabIndex = 9;
         this.CbOrigen.Tag = "TIPO_CodZONOrigenMSGERROR";
         this.CbOrigen.TiposSelectedItem = null;
         this.CbOrigen.TiposSelectedValue = null;
         this.CbOrigen.TiposTitulo = null;
         // 
         // lblDestino
         // 
         this.lblDestino.AutoSize = true;
         this.lblDestino.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblDestino.Location = new System.Drawing.Point(332, 88);
         this.lblDestino.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblDestino.Name = "lblDestino";
         this.lblDestino.Size = new System.Drawing.Size(55, 13);
         this.lblDestino.TabIndex = 10;
         this.lblDestino.Text = "Destino:";
         // 
         // CbTipo
         // 
         this.CbTipo.ConstantesSelectedItem = null;
         this.CbTipo.ConstantesSelectedValue = null;
         this.CbTipo.ConstantesTitulo = null;
         this.CbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbTipo.FormattingEnabled = true;
         this.CbTipo.Location = new System.Drawing.Point(114, 3);
         this.CbTipo.Name = "CbTipo";
         this.CbTipo.Size = new System.Drawing.Size(187, 21);
         this.CbTipo.TabIndex = 1;
         this.CbTipo.Tag = "CONS_CodTRAMSGERROR";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(36, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Tipo:";
         // 
         // lblOrigen
         // 
         this.lblOrigen.AutoSize = true;
         this.lblOrigen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblOrigen.Location = new System.Drawing.Point(10, 88);
         this.lblOrigen.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblOrigen.Name = "lblOrigen";
         this.lblOrigen.Size = new System.Drawing.Size(50, 13);
         this.lblOrigen.TabIndex = 8;
         this.lblOrigen.Text = "Origen:";
         // 
         // lblCostoAduanero
         // 
         this.lblCostoAduanero.AutoSize = true;
         this.lblCostoAduanero.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCostoAduanero.Location = new System.Drawing.Point(10, 34);
         this.lblCostoAduanero.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCostoAduanero.Name = "lblCostoAduanero";
         this.lblCostoAduanero.Size = new System.Drawing.Size(45, 13);
         this.lblCostoAduanero.TabIndex = 2;
         this.lblCostoAduanero.Text = "Costo:";
         // 
         // lblBaseAduanero
         // 
         this.lblBaseAduanero.AutoSize = true;
         this.lblBaseAduanero.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblBaseAduanero.Location = new System.Drawing.Point(332, 34);
         this.lblBaseAduanero.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblBaseAduanero.Name = "lblBaseAduanero";
         this.lblBaseAduanero.Size = new System.Drawing.Size(40, 13);
         this.lblBaseAduanero.TabIndex = 4;
         this.lblBaseAduanero.Text = "Base:";
         // 
         // txtCostoAduTransp
         // 
         this.txtCostoAduTransp.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtCostoAduTransp.Decimales = 2;
         this.txtCostoAduTransp.Enteros = 9;
         this.txtCostoAduTransp.Formato = "###,###,##0.00";
         this.txtCostoAduTransp.Location = new System.Drawing.Point(114, 30);
         this.txtCostoAduTransp.MaxLength = 9;
         this.txtCostoAduTransp.Name = "txtCostoAduTransp";
         this.txtCostoAduTransp.Negativo = false;
         this.txtCostoAduTransp.SinFormato = false;
         this.txtCostoAduTransp.Size = new System.Drawing.Size(187, 20);
         this.txtCostoAduTransp.TabIndex = 3;
         this.txtCostoAduTransp.Tag = "DCOT_VentaMSGERROR";
         this.txtCostoAduTransp.Text = "0.00";
         this.txtCostoAduTransp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtCostoAduTransp.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // CbBase
         // 
         this.CbBase.ConstantesSelectedItem = null;
         this.CbBase.ConstantesSelectedValue = null;
         this.CbBase.ConstantesTitulo = null;
         this.CbBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbBase.FormattingEnabled = true;
         this.CbBase.Location = new System.Drawing.Point(471, 30);
         this.CbBase.Name = "CbBase";
         this.CbBase.Size = new System.Drawing.Size(241, 21);
         this.CbBase.TabIndex = 5;
         this.CbBase.Tag = "CONS_CodBasMSGERROR";
         // 
         // txtMinimo
         // 
         this.txtMinimo.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtMinimo.Decimales = 2;
         this.txtMinimo.Enteros = 9;
         this.txtMinimo.Formato = "###,###,##0.00";
         this.txtMinimo.Location = new System.Drawing.Point(114, 57);
         this.txtMinimo.MaxLength = 9;
         this.txtMinimo.Name = "txtMinimo";
         this.txtMinimo.Negativo = false;
         this.txtMinimo.SinFormato = false;
         this.txtMinimo.Size = new System.Drawing.Size(187, 20);
         this.txtMinimo.TabIndex = 7;
         this.txtMinimo.Text = "0.00";
         this.txtMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtMinimo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblMinimo
         // 
         this.lblMinimo.AutoSize = true;
         this.lblMinimo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblMinimo.Location = new System.Drawing.Point(10, 61);
         this.lblMinimo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblMinimo.Name = "lblMinimo";
         this.lblMinimo.Size = new System.Drawing.Size(52, 13);
         this.lblMinimo.TabIndex = 6;
         this.lblMinimo.Text = "Minimo:";
         // 
         // tlpTarifarioLogistico
         // 
         this.tlpTarifarioLogistico.AutoSize = true;
         this.tlpTarifarioLogistico.BackColor = System.Drawing.Color.LightSteelBlue;
         this.tlpTarifarioLogistico.ColumnCount = 7;
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpTarifarioLogistico.Controls.Add(this.PnHBL, 0, 5);
         this.tlpTarifarioLogistico.Controls.Add(this.PnStandar40, 0, 3);
         this.tlpTarifarioLogistico.Controls.Add(this.PnStandar20, 0, 1);
         this.tlpTarifarioLogistico.Controls.Add(this.lblCONT_Numero, 0, 0);
         this.tlpTarifarioLogistico.Controls.Add(this.CbTipoEntidad, 1, 0);
         this.tlpTarifarioLogistico.Controls.Add(this.lblTipoentidad, 3, 0);
         this.tlpTarifarioLogistico.Controls.Add(this.txtVenta20, 1, 2);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandar20, 0, 2);
         this.tlpTarifarioLogistico.Controls.Add(this.txtVentaSada20, 4, 2);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandarSada40, 3, 4);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandar40, 0, 4);
         this.tlpTarifarioLogistico.Controls.Add(this.txtVenta40, 1, 4);
         this.tlpTarifarioLogistico.Controls.Add(this.txtVentaSada40, 4, 4);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandarHBLSada, 3, 6);
         this.tlpTarifarioLogistico.Controls.Add(this.txtHBL, 1, 6);
         this.tlpTarifarioLogistico.Controls.Add(this.txtHBLSada, 4, 6);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandarSada20, 3, 2);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandarHBL, 0, 6);
         this.tlpTarifarioLogistico.Controls.Add(this.panel1, 4, 0);
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
         this.tlpTarifarioLogistico.Size = new System.Drawing.Size(734, 189);
         this.tlpTarifarioLogistico.TabIndex = 0;
         // 
         // PnHBL
         // 
         this.PnHBL.AllowActive = false;
         this.PnHBL.AntiAlias = false;
         this.PnHBL.Caption = "HBL";
         this.tlpTarifarioLogistico.SetColumnSpan(this.PnHBL, 5);
         this.PnHBL.Dock = System.Windows.Forms.DockStyle.Top;
         this.PnHBL.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.PnHBL.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.PnHBL.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.PnHBL.Location = new System.Drawing.Point(3, 138);
         this.PnHBL.Name = "PnHBL";
         this.PnHBL.Size = new System.Drawing.Size(709, 21);
         this.PnHBL.TabIndex = 13;
         // 
         // PnStandar40
         // 
         this.PnStandar40.AllowActive = false;
         this.PnStandar40.AntiAlias = false;
         this.PnStandar40.Caption = "Standar 40";
         this.tlpTarifarioLogistico.SetColumnSpan(this.PnStandar40, 5);
         this.PnStandar40.Dock = System.Windows.Forms.DockStyle.Top;
         this.PnStandar40.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.PnStandar40.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.PnStandar40.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.PnStandar40.Location = new System.Drawing.Point(3, 84);
         this.PnStandar40.Name = "PnStandar40";
         this.PnStandar40.Size = new System.Drawing.Size(709, 21);
         this.PnStandar40.TabIndex = 8;
         // 
         // PnStandar20
         // 
         this.PnStandar20.AllowActive = false;
         this.PnStandar20.AntiAlias = false;
         this.PnStandar20.Caption = "Standar 20";
         this.tlpTarifarioLogistico.SetColumnSpan(this.PnStandar20, 5);
         this.PnStandar20.Dock = System.Windows.Forms.DockStyle.Top;
         this.PnStandar20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.PnStandar20.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.PnStandar20.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.PnStandar20.Location = new System.Drawing.Point(3, 30);
         this.PnStandar20.Name = "PnStandar20";
         this.PnStandar20.Size = new System.Drawing.Size(709, 21);
         this.PnStandar20.TabIndex = 3;
         // 
         // lblCONT_Numero
         // 
         this.lblCONT_Numero.AutoSize = true;
         this.lblCONT_Numero.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_Numero.Location = new System.Drawing.Point(10, 7);
         this.lblCONT_Numero.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_Numero.Name = "lblCONT_Numero";
         this.lblCONT_Numero.Size = new System.Drawing.Size(82, 13);
         this.lblCONT_Numero.TabIndex = 0;
         this.lblCONT_Numero.Text = "Tipo Entidad:";
         // 
         // CbTipoEntidad
         // 
         this.CbTipoEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbTipoEntidad.FormattingEnabled = true;
         this.CbTipoEntidad.Location = new System.Drawing.Point(114, 3);
         this.CbTipoEntidad.Name = "CbTipoEntidad";
         this.CbTipoEntidad.Size = new System.Drawing.Size(187, 21);
         this.CbTipoEntidad.TabIndex = 1;
         this.CbTipoEntidad.Tag = "TIPE_CodigoMSGERROR";
         // 
         // lblTipoentidad
         // 
         this.lblTipoentidad.AutoSize = true;
         this.lblTipoentidad.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTipoentidad.Location = new System.Drawing.Point(332, 7);
         this.lblTipoentidad.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTipoentidad.Name = "lblTipoentidad";
         this.lblTipoentidad.Size = new System.Drawing.Size(85, 13);
         this.lblTipoentidad.TabIndex = 2;
         this.lblTipoentidad.Text = "Razón Social:";
         // 
         // txtVenta20
         // 
         this.txtVenta20.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtVenta20.Decimales = 2;
         this.txtVenta20.Enteros = 9;
         this.txtVenta20.Formato = "###,###,##0.00";
         this.txtVenta20.Location = new System.Drawing.Point(114, 57);
         this.txtVenta20.MaxLength = 9;
         this.txtVenta20.Name = "txtVenta20";
         this.txtVenta20.Negativo = false;
         this.txtVenta20.SinFormato = false;
         this.txtVenta20.Size = new System.Drawing.Size(187, 20);
         this.txtVenta20.TabIndex = 3;
         this.txtVenta20.Tag = "DCOT_Venta20MSGERROR";
         this.txtVenta20.Text = "0.00";
         this.txtVenta20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtVenta20.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblStandar20
         // 
         this.lblStandar20.AutoSize = true;
         this.lblStandar20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandar20.Location = new System.Drawing.Point(10, 61);
         this.lblStandar20.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandar20.Name = "lblStandar20";
         this.lblStandar20.Size = new System.Drawing.Size(97, 13);
         this.lblStandar20.TabIndex = 4;
         this.lblStandar20.Text = "Valor Venta 20:";
         // 
         // txtVentaSada20
         // 
         this.txtVentaSada20.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtVentaSada20.Decimales = 2;
         this.txtVentaSada20.Enteros = 9;
         this.txtVentaSada20.Formato = "###,###,##0.00";
         this.txtVentaSada20.Location = new System.Drawing.Point(471, 57);
         this.txtVentaSada20.MaxLength = 9;
         this.txtVentaSada20.Name = "txtVentaSada20";
         this.txtVentaSada20.Negativo = false;
         this.txtVentaSada20.SinFormato = false;
         this.txtVentaSada20.Size = new System.Drawing.Size(193, 20);
         this.txtVentaSada20.TabIndex = 4;
         this.txtVentaSada20.Tag = "DCOT_VentaSada20MSGERROR";
         this.txtVentaSada20.Text = "0.00";
         this.txtVentaSada20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtVentaSada20.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblStandarSada40
         // 
         this.lblStandarSada40.AutoSize = true;
         this.lblStandarSada40.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandarSada40.Location = new System.Drawing.Point(332, 115);
         this.lblStandarSada40.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandarSada40.Name = "lblStandarSada40";
         this.lblStandarSada40.Size = new System.Drawing.Size(130, 13);
         this.lblStandarSada40.TabIndex = 11;
         this.lblStandarSada40.Text = "Valor Venta Sada 40:";
         // 
         // lblStandar40
         // 
         this.lblStandar40.AutoSize = true;
         this.lblStandar40.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandar40.Location = new System.Drawing.Point(10, 115);
         this.lblStandar40.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandar40.Name = "lblStandar40";
         this.lblStandar40.Size = new System.Drawing.Size(97, 13);
         this.lblStandar40.TabIndex = 9;
         this.lblStandar40.Text = "Valor Venta 40:";
         // 
         // txtVenta40
         // 
         this.txtVenta40.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtVenta40.Decimales = 2;
         this.txtVenta40.Enteros = 9;
         this.txtVenta40.Formato = "###,###,##0.00";
         this.txtVenta40.Location = new System.Drawing.Point(114, 111);
         this.txtVenta40.MaxLength = 9;
         this.txtVenta40.Name = "txtVenta40";
         this.txtVenta40.Negativo = false;
         this.txtVenta40.SinFormato = false;
         this.txtVenta40.Size = new System.Drawing.Size(187, 20);
         this.txtVenta40.TabIndex = 5;
         this.txtVenta40.Tag = "DCOT_Venta40MSGERROR";
         this.txtVenta40.Text = "0.00";
         this.txtVenta40.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtVenta40.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // txtVentaSada40
         // 
         this.txtVentaSada40.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtVentaSada40.Decimales = 2;
         this.txtVentaSada40.Enteros = 9;
         this.txtVentaSada40.Formato = "###,###,##0.00";
         this.txtVentaSada40.Location = new System.Drawing.Point(471, 111);
         this.txtVentaSada40.MaxLength = 9;
         this.txtVentaSada40.Name = "txtVentaSada40";
         this.txtVentaSada40.Negativo = false;
         this.txtVentaSada40.SinFormato = false;
         this.txtVentaSada40.Size = new System.Drawing.Size(194, 20);
         this.txtVentaSada40.TabIndex = 6;
         this.txtVentaSada40.Tag = "DCOT_VentaSada40MSGERROR";
         this.txtVentaSada40.Text = "0.00";
         this.txtVentaSada40.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtVentaSada40.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblStandarHBLSada
         // 
         this.lblStandarHBLSada.AutoSize = true;
         this.lblStandarHBLSada.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandarHBLSada.Location = new System.Drawing.Point(332, 169);
         this.lblStandarHBLSada.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandarHBLSada.Name = "lblStandarHBLSada";
         this.lblStandarHBLSada.Size = new System.Drawing.Size(104, 13);
         this.lblStandarHBLSada.TabIndex = 16;
         this.lblStandarHBLSada.Text = "Venta HBL Sada:";
         // 
         // txtHBL
         // 
         this.txtHBL.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtHBL.Decimales = 2;
         this.txtHBL.Enteros = 9;
         this.txtHBL.Formato = "###,###,##0.00";
         this.txtHBL.Location = new System.Drawing.Point(114, 165);
         this.txtHBL.MaxLength = 9;
         this.txtHBL.Name = "txtHBL";
         this.txtHBL.Negativo = false;
         this.txtHBL.SinFormato = false;
         this.txtHBL.Size = new System.Drawing.Size(187, 20);
         this.txtHBL.TabIndex = 7;
         this.txtHBL.Tag = "DCOT_VentaHBLMSGERROR";
         this.txtHBL.Text = "0.00";
         this.txtHBL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtHBL.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // txtHBLSada
         // 
         this.txtHBLSada.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtHBLSada.Decimales = 2;
         this.txtHBLSada.Enteros = 9;
         this.txtHBLSada.Formato = "###,###,##0.00";
         this.txtHBLSada.Location = new System.Drawing.Point(471, 165);
         this.txtHBLSada.MaxLength = 9;
         this.txtHBLSada.Name = "txtHBLSada";
         this.txtHBLSada.Negativo = false;
         this.txtHBLSada.SinFormato = false;
         this.txtHBLSada.Size = new System.Drawing.Size(194, 20);
         this.txtHBLSada.TabIndex = 8;
         this.txtHBLSada.Tag = "DCOT_VentaSadaHBLMSGERROR";
         this.txtHBLSada.Text = "0.00";
         this.txtHBLSada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtHBLSada.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblStandarSada20
         // 
         this.lblStandarSada20.AutoSize = true;
         this.lblStandarSada20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandarSada20.Location = new System.Drawing.Point(332, 61);
         this.lblStandarSada20.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandarSada20.Name = "lblStandarSada20";
         this.lblStandarSada20.Size = new System.Drawing.Size(130, 13);
         this.lblStandarSada20.TabIndex = 6;
         this.lblStandarSada20.Text = "Valor Venta Sada 20:";
         // 
         // lblStandarHBL
         // 
         this.lblStandarHBL.AutoSize = true;
         this.lblStandarHBL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandarHBL.Location = new System.Drawing.Point(10, 169);
         this.lblStandarHBL.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandarHBL.Name = "lblStandarHBL";
         this.lblStandarHBL.Size = new System.Drawing.Size(71, 13);
         this.lblStandarHBL.TabIndex = 14;
         this.lblStandarHBL.Text = "Venta HBL:";
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.ENTC_CodigoEntidad);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel1.Location = new System.Drawing.Point(471, 3);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(241, 21);
         this.panel1.TabIndex = 22;
         this.panel1.Tag = "ENTC_CodigoMSGERROR";
         // 
         // ENTC_CodigoEntidad
         // 
         this.ENTC_CodigoEntidad.ActivarAyudaAuto = false;
         this.ENTC_CodigoEntidad.EnabledAyudaButton = true;
         this.ENTC_CodigoEntidad.Location = new System.Drawing.Point(0, 0);
         this.ENTC_CodigoEntidad.LongitudAceptada = 0;
         this.ENTC_CodigoEntidad.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_CodigoEntidad.Name = "ENTC_CodigoEntidad";
         this.ENTC_CodigoEntidad.RellenaCeros = false;
         this.ENTC_CodigoEntidad.Size = new System.Drawing.Size(242, 20);
         this.ENTC_CodigoEntidad.TabIndex = 2;
         this.ENTC_CodigoEntidad.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodigoEntidad.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
         this.ENTC_CodigoEntidad.Value = null;
         // 
         // PnBotones
         // 
         this.PnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
         this.PnBotones.Controls.Add(this.btnAgregar);
         this.PnBotones.Dock = System.Windows.Forms.DockStyle.Top;
         this.PnBotones.Location = new System.Drawing.Point(0, 0);
         this.PnBotones.Name = "PnBotones";
         this.PnBotones.Size = new System.Drawing.Size(734, 50);
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
         // PRO002DMview
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(734, 379);
         this.Controls.Add(this.tlpTarifarioAduaneroTransp);
         this.Controls.Add(this.tlpTarifarioLogistico);
         this.Controls.Add(this.PnBotones);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PRO002DMview";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Detalle Cotización";
         this.tlpTarifarioAduaneroTransp.ResumeLayout(false);
         this.tlpTarifarioAduaneroTransp.PerformLayout();
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

        private System.Windows.Forms.TableLayoutPanel tlpTarifarioAduaneroTransp;
        private System.Windows.Forms.Label lblRoundtrip;
        private System.Windows.Forms.CheckBox chkRoundtrip;
        private Controls.Tipos.ComboBoxTipos CbDestino;
        private Controls.Tipos.ComboBoxTipos CbOrigen;
        private System.Windows.Forms.Label lblDestino;
        private Controls.Tipos.ComboBoxConstantes CbTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Label lblCostoAduanero;
        private System.Windows.Forms.Label lblBaseAduanero;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtCostoAduTransp;
        private Controls.Tipos.ComboBoxConstantes CbBase;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtMinimo;
        private System.Windows.Forms.Label lblMinimo;
        private System.Windows.Forms.TableLayoutPanel tlpTarifarioLogistico;
        private Infrastructure.WinFormsControls.PanelCaption PnHBL;
        private Infrastructure.WinFormsControls.PanelCaption PnStandar40;
        private Infrastructure.WinFormsControls.PanelCaption PnStandar20;
        private System.Windows.Forms.Label lblCONT_Numero;
        private System.Windows.Forms.ComboBox CbTipoEntidad;
        private System.Windows.Forms.Label lblTipoentidad;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtVenta20;
        private System.Windows.Forms.Label lblStandar20;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtVentaSada20;
        private System.Windows.Forms.Label lblStandarSada40;
        private System.Windows.Forms.Label lblStandar40;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtVenta40;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtVentaSada40;
        private System.Windows.Forms.Label lblStandarHBLSada;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtHBL;
        private Infrastructure.WinFormsControls.TextBoxNumerico txtHBLSada;
        private System.Windows.Forms.Label lblStandarSada20;
        private System.Windows.Forms.Label lblStandarHBL;
        private System.Windows.Forms.Panel panel1;
        private Controls.Entidad ENTC_CodigoEntidad;
        private System.Windows.Forms.Panel PnBotones;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}