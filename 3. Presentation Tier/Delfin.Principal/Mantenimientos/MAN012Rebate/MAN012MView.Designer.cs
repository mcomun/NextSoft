namespace Delfin.Principal
{
    partial class MAN012MView
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
            this.txnREBA_Codigo = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.lblREBA_Codigo = new System.Windows.Forms.Label();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnMAN_salir = new System.Windows.Forms.Button();
            this.btnMAN_guardar = new System.Windows.Forms.Button();
            this.errorGRR = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableRebateGRR = new System.Windows.Forms.TableLayoutPanel();
            this.txaENTC_CodTransportista = new Delfin.Controls.Entidad(this.components);
            this.lblREBA_FecIni = new System.Windows.Forms.Label();
            this.mdtREBA_FecIni = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblREBA_FecFin = new System.Windows.Forms.Label();
            this.mdtREBA_FecFin = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblENTC_CodTransportista = new System.Windows.Forms.Label();
            this.lblREBA_Tipo = new System.Windows.Forms.Label();
            this.lblTIPO_CodMND = new System.Windows.Forms.Label();
            this.cmbTIPO_CodMnd = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.lblREBA_CostoFlete = new System.Windows.Forms.Label();
            this.lblREBA_CostoFleteDes = new System.Windows.Forms.Label();
            this.lblREBA_LimiteInf = new System.Windows.Forms.Label();
            this.lblREBA_LimiteSup = new System.Windows.Forms.Label();
            this.txnREBA_CostoFlete = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.txnREBA_CostoFleteDes = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.txnREBA_LimiteInf = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.txnREBA_LimiteSup = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.txnREBA_Valor = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.lblREBA_Valor = new System.Windows.Forms.Label();
            this.cmbREBA_Tipo = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
            this.lblREBA_ValorPorcentaje = new System.Windows.Forms.Label();
            this.txnREBA_ValorPorcentaje = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.label1 = new System.Windows.Forms.Label();
            this.mdtREBA_FecCalc = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.splitRebateGRR = new System.Windows.Forms.SplitContainer();
            this.grdGRR_Paquetes = new Telerik.WinControls.UI.RadGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.grdGRR_Contrato = new Telerik.WinControls.UI.RadGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnReloadContratos = new System.Windows.Forms.Button();
            this.panelCaption4 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorGRR)).BeginInit();
            this.tableRebateGRR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRebateGRR)).BeginInit();
            this.splitRebateGRR.Panel1.SuspendLayout();
            this.splitRebateGRR.Panel2.SuspendLayout();
            this.splitRebateGRR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGRR_Paquetes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGRR_Paquetes.MasterTemplate)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGRR_Contrato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGRR_Contrato.MasterTemplate)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // txnREBA_Codigo
            // 
            this.txnREBA_Codigo.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
            this.txnREBA_Codigo.Decimales = 0;
            this.txnREBA_Codigo.Enteros = 11;
            this.txnREBA_Codigo.Formato = "##,###,###,##0.";
            this.txnREBA_Codigo.Location = new System.Drawing.Point(153, 3);
            this.txnREBA_Codigo.MaxLength = 12;
            this.txnREBA_Codigo.Name = "txnREBA_Codigo";
            this.txnREBA_Codigo.Negativo = true;
            this.txnREBA_Codigo.ReadOnly = true;
            this.txnREBA_Codigo.SinFormato = true;
            this.txnREBA_Codigo.Size = new System.Drawing.Size(194, 20);
            this.txnREBA_Codigo.TabIndex = 1;
            this.txnREBA_Codigo.Tag = "REBA_CodigoMSGERROR";
            this.txnREBA_Codigo.Text = "0";
            this.txnREBA_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnREBA_Codigo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblREBA_Codigo
            // 
            this.lblREBA_Codigo.AutoSize = true;
            this.lblREBA_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_Codigo.Location = new System.Drawing.Point(10, 7);
            this.lblREBA_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_Codigo.Name = "lblREBA_Codigo";
            this.lblREBA_Codigo.Size = new System.Drawing.Size(52, 13);
            this.lblREBA_Codigo.TabIndex = 0;
            this.lblREBA_Codigo.Text = "Codigo:";
            // 
            // panelCaption1
            // 
            this.panelCaption1.AllowActive = false;
            this.panelCaption1.AntiAlias = false;
            this.panelCaption1.Caption = "Datos del Rebate y GRR";
            this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption1.Location = new System.Drawing.Point(0, 50);
            this.panelCaption1.Name = "panelCaption1";
            this.panelCaption1.Size = new System.Drawing.Size(734, 26);
            this.panelCaption1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.btnMAN_salir);
            this.panel3.Controls.Add(this.btnMAN_guardar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(734, 50);
            this.panel3.TabIndex = 0;
            // 
            // btnMAN_salir
            // 
            this.btnMAN_salir.AutoSize = true;
            this.btnMAN_salir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMAN_salir.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnMAN_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMAN_salir.ForeColor = System.Drawing.Color.Black;
            this.btnMAN_salir.Image = global::Delfin.Principal.Properties.Resources.undo;
            this.btnMAN_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMAN_salir.Location = new System.Drawing.Point(57, 0);
            this.btnMAN_salir.Margin = new System.Windows.Forms.Padding(0);
            this.btnMAN_salir.Name = "btnMAN_salir";
            this.btnMAN_salir.Size = new System.Drawing.Size(55, 50);
            this.btnMAN_salir.TabIndex = 1;
            this.btnMAN_salir.Text = "&Salir";
            this.btnMAN_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMAN_salir.UseVisualStyleBackColor = true;
            // 
            // btnMAN_guardar
            // 
            this.btnMAN_guardar.AutoSize = true;
            this.btnMAN_guardar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMAN_guardar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnMAN_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMAN_guardar.ForeColor = System.Drawing.Color.Black;
            this.btnMAN_guardar.Image = global::Delfin.Principal.Properties.Resources.save;
            this.btnMAN_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMAN_guardar.Location = new System.Drawing.Point(0, 0);
            this.btnMAN_guardar.Margin = new System.Windows.Forms.Padding(0);
            this.btnMAN_guardar.Name = "btnMAN_guardar";
            this.btnMAN_guardar.Size = new System.Drawing.Size(57, 50);
            this.btnMAN_guardar.TabIndex = 0;
            this.btnMAN_guardar.Text = "&Guardar";
            this.btnMAN_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMAN_guardar.UseVisualStyleBackColor = true;
            // 
            // errorGRR
            // 
            this.errorGRR.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorGRR.ContainerControl = this;
            // 
            // tableRebateGRR
            // 
            this.tableRebateGRR.AutoSize = true;
            this.tableRebateGRR.ColumnCount = 7;
            this.tableRebateGRR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableRebateGRR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableRebateGRR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableRebateGRR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableRebateGRR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableRebateGRR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableRebateGRR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableRebateGRR.Controls.Add(this.txaENTC_CodTransportista, 1, 1);
            this.tableRebateGRR.Controls.Add(this.lblREBA_FecIni, 0, 2);
            this.tableRebateGRR.Controls.Add(this.mdtREBA_FecIni, 1, 2);
            this.tableRebateGRR.Controls.Add(this.lblREBA_FecFin, 3, 2);
            this.tableRebateGRR.Controls.Add(this.mdtREBA_FecFin, 4, 2);
            this.tableRebateGRR.Controls.Add(this.lblENTC_CodTransportista, 0, 1);
            this.tableRebateGRR.Controls.Add(this.lblREBA_Codigo, 0, 0);
            this.tableRebateGRR.Controls.Add(this.txnREBA_Codigo, 1, 0);
            this.tableRebateGRR.Controls.Add(this.lblREBA_Tipo, 3, 0);
            this.tableRebateGRR.Controls.Add(this.lblTIPO_CodMND, 0, 3);
            this.tableRebateGRR.Controls.Add(this.cmbTIPO_CodMnd, 1, 3);
            this.tableRebateGRR.Controls.Add(this.lblREBA_CostoFlete, 0, 4);
            this.tableRebateGRR.Controls.Add(this.lblREBA_CostoFleteDes, 3, 4);
            this.tableRebateGRR.Controls.Add(this.lblREBA_LimiteInf, 0, 5);
            this.tableRebateGRR.Controls.Add(this.lblREBA_LimiteSup, 3, 5);
            this.tableRebateGRR.Controls.Add(this.txnREBA_CostoFlete, 1, 4);
            this.tableRebateGRR.Controls.Add(this.txnREBA_CostoFleteDes, 4, 4);
            this.tableRebateGRR.Controls.Add(this.txnREBA_LimiteInf, 1, 5);
            this.tableRebateGRR.Controls.Add(this.txnREBA_LimiteSup, 4, 5);
            this.tableRebateGRR.Controls.Add(this.txnREBA_Valor, 4, 3);
            this.tableRebateGRR.Controls.Add(this.lblREBA_Valor, 3, 3);
            this.tableRebateGRR.Controls.Add(this.cmbREBA_Tipo, 4, 0);
            this.tableRebateGRR.Controls.Add(this.lblREBA_ValorPorcentaje, 0, 6);
            this.tableRebateGRR.Controls.Add(this.txnREBA_ValorPorcentaje, 1, 6);
            this.tableRebateGRR.Controls.Add(this.label1, 3, 6);
            this.tableRebateGRR.Controls.Add(this.mdtREBA_FecCalc, 4, 6);
            this.tableRebateGRR.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableRebateGRR.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableRebateGRR.Location = new System.Drawing.Point(0, 76);
            this.tableRebateGRR.Name = "tableRebateGRR";
            this.tableRebateGRR.RowCount = 8;
            this.tableRebateGRR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableRebateGRR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableRebateGRR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableRebateGRR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableRebateGRR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableRebateGRR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableRebateGRR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableRebateGRR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableRebateGRR.Size = new System.Drawing.Size(734, 194);
            this.tableRebateGRR.TabIndex = 2;
            // 
            // txaENTC_CodTransportista
            // 
            this.txaENTC_CodTransportista.ActivarAyudaAuto = false;
            this.tableRebateGRR.SetColumnSpan(this.txaENTC_CodTransportista, 4);
            this.txaENTC_CodTransportista.ContainerService = null;
            this.txaENTC_CodTransportista.EnabledAyudaButton = true;
            this.txaENTC_CodTransportista.Location = new System.Drawing.Point(153, 30);
            this.txaENTC_CodTransportista.LongitudAceptada = 0;
            this.txaENTC_CodTransportista.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.txaENTC_CodTransportista.Name = "txaENTC_CodTransportista";
            this.txaENTC_CodTransportista.RellenaCeros = false;
            this.txaENTC_CodTransportista.Size = new System.Drawing.Size(559, 20);
            this.txaENTC_CodTransportista.TabIndex = 5;
            this.txaENTC_CodTransportista.Tag = "ENTC_CodTransportistaMSGERROR";
            this.txaENTC_CodTransportista.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.txaENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.txaENTC_CodTransportista.UsarTipoEntidad = true;
            this.txaENTC_CodTransportista.Value = null;
            // 
            // lblREBA_FecIni
            // 
            this.lblREBA_FecIni.AutoSize = true;
            this.lblREBA_FecIni.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_FecIni.Location = new System.Drawing.Point(10, 61);
            this.lblREBA_FecIni.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_FecIni.Name = "lblREBA_FecIni";
            this.lblREBA_FecIni.Size = new System.Drawing.Size(80, 13);
            this.lblREBA_FecIni.TabIndex = 6;
            this.lblREBA_FecIni.Text = "Fecha Inicio:";
            // 
            // mdtREBA_FecIni
            // 
            this.mdtREBA_FecIni.Location = new System.Drawing.Point(153, 57);
            this.mdtREBA_FecIni.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtREBA_FecIni.Name = "mdtREBA_FecIni";
            this.mdtREBA_FecIni.NSActiveMouse = false;
            this.mdtREBA_FecIni.NSActiveMsgFecha = false;
            this.mdtREBA_FecIni.NSChangeDate = true;
            this.mdtREBA_FecIni.NSDigitos = 4;
            this.mdtREBA_FecIni.NSFecha = null;
            this.mdtREBA_FecIni.NSSetDateNow = false;
            this.mdtREBA_FecIni.Size = new System.Drawing.Size(101, 22);
            this.mdtREBA_FecIni.TabIndex = 7;
            this.mdtREBA_FecIni.Tag = "REBA_FecIniMSGERROR";
            // 
            // lblREBA_FecFin
            // 
            this.lblREBA_FecFin.AutoSize = true;
            this.lblREBA_FecFin.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_FecFin.Location = new System.Drawing.Point(375, 61);
            this.lblREBA_FecFin.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_FecFin.Name = "lblREBA_FecFin";
            this.lblREBA_FecFin.Size = new System.Drawing.Size(65, 13);
            this.lblREBA_FecFin.TabIndex = 8;
            this.lblREBA_FecFin.Text = "Fecha Fin:";
            // 
            // mdtREBA_FecFin
            // 
            this.mdtREBA_FecFin.Location = new System.Drawing.Point(538, 57);
            this.mdtREBA_FecFin.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtREBA_FecFin.Name = "mdtREBA_FecFin";
            this.mdtREBA_FecFin.NSActiveMouse = false;
            this.mdtREBA_FecFin.NSActiveMsgFecha = false;
            this.mdtREBA_FecFin.NSChangeDate = true;
            this.mdtREBA_FecFin.NSDigitos = 4;
            this.mdtREBA_FecFin.NSFecha = null;
            this.mdtREBA_FecFin.NSSetDateNow = false;
            this.mdtREBA_FecFin.Size = new System.Drawing.Size(101, 22);
            this.mdtREBA_FecFin.TabIndex = 9;
            this.mdtREBA_FecFin.Tag = "REBA_FecFinMSGERROR";
            // 
            // lblENTC_CodTransportista
            // 
            this.lblENTC_CodTransportista.AutoSize = true;
            this.lblENTC_CodTransportista.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_CodTransportista.Location = new System.Drawing.Point(10, 34);
            this.lblENTC_CodTransportista.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblENTC_CodTransportista.Name = "lblENTC_CodTransportista";
            this.lblENTC_CodTransportista.Size = new System.Drawing.Size(86, 13);
            this.lblENTC_CodTransportista.TabIndex = 4;
            this.lblENTC_CodTransportista.Text = "Transportista:";
            // 
            // lblREBA_Tipo
            // 
            this.lblREBA_Tipo.AutoSize = true;
            this.lblREBA_Tipo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_Tipo.Location = new System.Drawing.Point(375, 7);
            this.lblREBA_Tipo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_Tipo.Name = "lblREBA_Tipo";
            this.lblREBA_Tipo.Size = new System.Drawing.Size(36, 13);
            this.lblREBA_Tipo.TabIndex = 2;
            this.lblREBA_Tipo.Text = "Tipo:";
            // 
            // lblTIPO_CodMND
            // 
            this.lblTIPO_CodMND.AutoSize = true;
            this.lblTIPO_CodMND.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodMND.Location = new System.Drawing.Point(10, 88);
            this.lblTIPO_CodMND.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodMND.Name = "lblTIPO_CodMND";
            this.lblTIPO_CodMND.Size = new System.Drawing.Size(56, 13);
            this.lblTIPO_CodMND.TabIndex = 10;
            this.lblTIPO_CodMND.Tag = "";
            this.lblTIPO_CodMND.Text = "Moneda:";
            // 
            // cmbTIPO_CodMnd
            // 
            this.cmbTIPO_CodMnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodMnd.FormattingEnabled = true;
            this.cmbTIPO_CodMnd.Location = new System.Drawing.Point(153, 84);
            this.cmbTIPO_CodMnd.Name = "cmbTIPO_CodMnd";
            this.cmbTIPO_CodMnd.Session = null;
            this.cmbTIPO_CodMnd.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPO_CodMnd.TabIndex = 11;
            this.cmbTIPO_CodMnd.Tag = "TIPO_CodMNDMSGERROR";
            this.cmbTIPO_CodMnd.TiposSelectedItem = null;
            this.cmbTIPO_CodMnd.TiposSelectedValue = null;
            this.cmbTIPO_CodMnd.TiposTitulo = null;
            // 
            // lblREBA_CostoFlete
            // 
            this.lblREBA_CostoFlete.AutoSize = true;
            this.lblREBA_CostoFlete.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_CostoFlete.Location = new System.Drawing.Point(10, 115);
            this.lblREBA_CostoFlete.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_CostoFlete.Name = "lblREBA_CostoFlete";
            this.lblREBA_CostoFlete.Size = new System.Drawing.Size(76, 13);
            this.lblREBA_CostoFlete.TabIndex = 14;
            this.lblREBA_CostoFlete.Text = "Costo Flete:";
            // 
            // lblREBA_CostoFleteDes
            // 
            this.lblREBA_CostoFleteDes.AutoSize = true;
            this.lblREBA_CostoFleteDes.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_CostoFleteDes.Location = new System.Drawing.Point(375, 115);
            this.lblREBA_CostoFleteDes.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_CostoFleteDes.Name = "lblREBA_CostoFleteDes";
            this.lblREBA_CostoFleteDes.Size = new System.Drawing.Size(146, 13);
            this.lblREBA_CostoFleteDes.TabIndex = 16;
            this.lblREBA_CostoFleteDes.Text = "Cos. Flete Des. x CNTR:";
            // 
            // lblREBA_LimiteInf
            // 
            this.lblREBA_LimiteInf.AutoSize = true;
            this.lblREBA_LimiteInf.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_LimiteInf.Location = new System.Drawing.Point(10, 142);
            this.lblREBA_LimiteInf.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_LimiteInf.Name = "lblREBA_LimiteInf";
            this.lblREBA_LimiteInf.Size = new System.Drawing.Size(93, 13);
            this.lblREBA_LimiteInf.TabIndex = 18;
            this.lblREBA_LimiteInf.Text = "Limite Inferior:";
            // 
            // lblREBA_LimiteSup
            // 
            this.lblREBA_LimiteSup.AutoSize = true;
            this.lblREBA_LimiteSup.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_LimiteSup.Location = new System.Drawing.Point(375, 142);
            this.lblREBA_LimiteSup.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_LimiteSup.Name = "lblREBA_LimiteSup";
            this.lblREBA_LimiteSup.Size = new System.Drawing.Size(99, 13);
            this.lblREBA_LimiteSup.TabIndex = 20;
            this.lblREBA_LimiteSup.Text = "Limite Superior:";
            // 
            // txnREBA_CostoFlete
            // 
            this.txnREBA_CostoFlete.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txnREBA_CostoFlete.Decimales = 2;
            this.txnREBA_CostoFlete.Enteros = 9;
            this.txnREBA_CostoFlete.Formato = "###,###,##0.00";
            this.txnREBA_CostoFlete.Location = new System.Drawing.Point(153, 111);
            this.txnREBA_CostoFlete.MaxLength = 13;
            this.txnREBA_CostoFlete.Name = "txnREBA_CostoFlete";
            this.txnREBA_CostoFlete.Negativo = true;
            this.txnREBA_CostoFlete.SinFormato = false;
            this.txnREBA_CostoFlete.Size = new System.Drawing.Size(194, 20);
            this.txnREBA_CostoFlete.TabIndex = 15;
            this.txnREBA_CostoFlete.Tag = "REBA_CostoFleteMSGERROR";
            this.txnREBA_CostoFlete.Text = "0.00";
            this.txnREBA_CostoFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnREBA_CostoFlete.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txnREBA_CostoFleteDes
            // 
            this.txnREBA_CostoFleteDes.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txnREBA_CostoFleteDes.Decimales = 2;
            this.txnREBA_CostoFleteDes.Enteros = 9;
            this.txnREBA_CostoFleteDes.Formato = "###,###,##0.00";
            this.txnREBA_CostoFleteDes.Location = new System.Drawing.Point(538, 111);
            this.txnREBA_CostoFleteDes.MaxLength = 13;
            this.txnREBA_CostoFleteDes.Name = "txnREBA_CostoFleteDes";
            this.txnREBA_CostoFleteDes.Negativo = true;
            this.txnREBA_CostoFleteDes.SinFormato = false;
            this.txnREBA_CostoFleteDes.Size = new System.Drawing.Size(174, 20);
            this.txnREBA_CostoFleteDes.TabIndex = 17;
            this.txnREBA_CostoFleteDes.Tag = "REBA_CostoFleteDesMSGERROR";
            this.txnREBA_CostoFleteDes.Text = "0.00";
            this.txnREBA_CostoFleteDes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnREBA_CostoFleteDes.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txnREBA_LimiteInf
            // 
            this.txnREBA_LimiteInf.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txnREBA_LimiteInf.Decimales = 2;
            this.txnREBA_LimiteInf.Enteros = 9;
            this.txnREBA_LimiteInf.Formato = "###,###,##0.00";
            this.txnREBA_LimiteInf.Location = new System.Drawing.Point(153, 138);
            this.txnREBA_LimiteInf.MaxLength = 13;
            this.txnREBA_LimiteInf.Name = "txnREBA_LimiteInf";
            this.txnREBA_LimiteInf.Negativo = true;
            this.txnREBA_LimiteInf.SinFormato = false;
            this.txnREBA_LimiteInf.Size = new System.Drawing.Size(194, 20);
            this.txnREBA_LimiteInf.TabIndex = 19;
            this.txnREBA_LimiteInf.Tag = "REBA_LimiteInfMSGERROR";
            this.txnREBA_LimiteInf.Text = "0.00";
            this.txnREBA_LimiteInf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnREBA_LimiteInf.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txnREBA_LimiteSup
            // 
            this.txnREBA_LimiteSup.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txnREBA_LimiteSup.Decimales = 2;
            this.txnREBA_LimiteSup.Enteros = 9;
            this.txnREBA_LimiteSup.Formato = "###,###,##0.00";
            this.txnREBA_LimiteSup.Location = new System.Drawing.Point(538, 138);
            this.txnREBA_LimiteSup.MaxLength = 13;
            this.txnREBA_LimiteSup.Name = "txnREBA_LimiteSup";
            this.txnREBA_LimiteSup.Negativo = true;
            this.txnREBA_LimiteSup.SinFormato = false;
            this.txnREBA_LimiteSup.Size = new System.Drawing.Size(174, 20);
            this.txnREBA_LimiteSup.TabIndex = 21;
            this.txnREBA_LimiteSup.Tag = "REBA_LimiteSupMSGERROR";
            this.txnREBA_LimiteSup.Text = "0.00";
            this.txnREBA_LimiteSup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnREBA_LimiteSup.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txnREBA_Valor
            // 
            this.txnREBA_Valor.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txnREBA_Valor.Decimales = 2;
            this.txnREBA_Valor.Enteros = 9;
            this.txnREBA_Valor.Formato = "###,###,##0.00";
            this.txnREBA_Valor.Location = new System.Drawing.Point(538, 84);
            this.txnREBA_Valor.MaxLength = 13;
            this.txnREBA_Valor.Name = "txnREBA_Valor";
            this.txnREBA_Valor.Negativo = true;
            this.txnREBA_Valor.SinFormato = false;
            this.txnREBA_Valor.Size = new System.Drawing.Size(174, 20);
            this.txnREBA_Valor.TabIndex = 13;
            this.txnREBA_Valor.Tag = "REBA_ValorMSGERROR";
            this.txnREBA_Valor.Text = "0.00";
            this.txnREBA_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnREBA_Valor.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblREBA_Valor
            // 
            this.lblREBA_Valor.AutoSize = true;
            this.lblREBA_Valor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_Valor.Location = new System.Drawing.Point(375, 88);
            this.lblREBA_Valor.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_Valor.Name = "lblREBA_Valor";
            this.lblREBA_Valor.Size = new System.Drawing.Size(152, 13);
            this.lblREBA_Valor.TabIndex = 12;
            this.lblREBA_Valor.Text = "Valor  de Rebate x TEUS:";
            // 
            // cmbREBA_Tipo
            // 
            this.cmbREBA_Tipo.ComboIntSelectedValue = null;
            this.cmbREBA_Tipo.ComboSelectedItem = null;
            this.cmbREBA_Tipo.ComboStrSelectedValue = null;
            this.cmbREBA_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbREBA_Tipo.FormattingEnabled = true;
            this.cmbREBA_Tipo.Location = new System.Drawing.Point(538, 3);
            this.cmbREBA_Tipo.Name = "cmbREBA_Tipo";
            this.cmbREBA_Tipo.Size = new System.Drawing.Size(121, 21);
            this.cmbREBA_Tipo.TabIndex = 3;
            this.cmbREBA_Tipo.Tag = "REBA_TipoMSGERROR";
            this.cmbREBA_Tipo.SelectedIndexChanged += new System.EventHandler(this.cmbREBA_Tipo_SelectedIndexChanged);
            // 
            // lblREBA_ValorPorcentaje
            // 
            this.lblREBA_ValorPorcentaje.AutoSize = true;
            this.lblREBA_ValorPorcentaje.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_ValorPorcentaje.Location = new System.Drawing.Point(10, 169);
            this.lblREBA_ValorPorcentaje.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_ValorPorcentaje.Name = "lblREBA_ValorPorcentaje";
            this.lblREBA_ValorPorcentaje.Size = new System.Drawing.Size(114, 13);
            this.lblREBA_ValorPorcentaje.TabIndex = 22;
            this.lblREBA_ValorPorcentaje.Text = "Valor de GRR (%):";
            // 
            // txnREBA_ValorPorcentaje
            // 
            this.txnREBA_ValorPorcentaje.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Porcentaje;
            this.txnREBA_ValorPorcentaje.Decimales = 2;
            this.txnREBA_ValorPorcentaje.Enteros = 3;
            this.txnREBA_ValorPorcentaje.Formato = "##0.00";
            this.txnREBA_ValorPorcentaje.Location = new System.Drawing.Point(153, 165);
            this.txnREBA_ValorPorcentaje.MaxLength = 6;
            this.txnREBA_ValorPorcentaje.Name = "txnREBA_ValorPorcentaje";
            this.txnREBA_ValorPorcentaje.Negativo = false;
            this.txnREBA_ValorPorcentaje.SinFormato = false;
            this.txnREBA_ValorPorcentaje.Size = new System.Drawing.Size(194, 20);
            this.txnREBA_ValorPorcentaje.TabIndex = 23;
            this.txnREBA_ValorPorcentaje.Tag = "REBA_ValorMSGERROR";
            this.txnREBA_ValorPorcentaje.Text = "0.00";
            this.txnREBA_ValorPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnREBA_ValorPorcentaje.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(375, 169);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Fecha Cálculo:";
            // 
            // mdtREBA_FecCalc
            // 
            this.mdtREBA_FecCalc.Location = new System.Drawing.Point(538, 165);
            this.mdtREBA_FecCalc.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtREBA_FecCalc.Name = "mdtREBA_FecCalc";
            this.mdtREBA_FecCalc.NSActiveMouse = false;
            this.mdtREBA_FecCalc.NSActiveMsgFecha = false;
            this.mdtREBA_FecCalc.NSChangeDate = true;
            this.mdtREBA_FecCalc.NSDigitos = 4;
            this.mdtREBA_FecCalc.NSFecha = null;
            this.mdtREBA_FecCalc.NSSetDateNow = false;
            this.mdtREBA_FecCalc.Size = new System.Drawing.Size(101, 22);
            this.mdtREBA_FecCalc.TabIndex = 9;
            this.mdtREBA_FecCalc.Tag = "REBA_FecFinMSGERROR";
            // 
            // splitRebateGRR
            // 
            this.splitRebateGRR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRebateGRR.Location = new System.Drawing.Point(0, 270);
            this.splitRebateGRR.Name = "splitRebateGRR";
            // 
            // splitRebateGRR.Panel1
            // 
            this.splitRebateGRR.Panel1.Controls.Add(this.grdGRR_Paquetes);
            this.splitRebateGRR.Panel1.Controls.Add(this.panel1);
            // 
            // splitRebateGRR.Panel2
            // 
            this.splitRebateGRR.Panel2.Controls.Add(this.grdGRR_Contrato);
            this.splitRebateGRR.Panel2.Controls.Add(this.panel8);
            this.splitRebateGRR.Size = new System.Drawing.Size(734, 191);
            this.splitRebateGRR.SplitterDistance = 355;
            this.splitRebateGRR.TabIndex = 22;
            // 
            // grdGRR_Paquetes
            // 
            this.grdGRR_Paquetes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdGRR_Paquetes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGRR_Paquetes.Location = new System.Drawing.Point(0, 29);
            this.grdGRR_Paquetes.Name = "grdGRR_Paquetes";
            this.grdGRR_Paquetes.Size = new System.Drawing.Size(355, 162);
            this.grdGRR_Paquetes.TabIndex = 0;
            this.grdGRR_Paquetes.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelCaption2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 29);
            this.panel1.TabIndex = 56;
            // 
            // panelCaption2
            // 
            this.panelCaption2.AllowActive = false;
            this.panelCaption2.AntiAlias = false;
            this.panelCaption2.Caption = "Paquetes";
            this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption2.Location = new System.Drawing.Point(0, 0);
            this.panelCaption2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelCaption2.Name = "panelCaption2";
            this.panelCaption2.Size = new System.Drawing.Size(355, 27);
            this.panelCaption2.TabIndex = 0;
            // 
            // grdGRR_Contrato
            // 
            this.grdGRR_Contrato.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdGRR_Contrato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGRR_Contrato.Location = new System.Drawing.Point(0, 29);
            this.grdGRR_Contrato.Name = "grdGRR_Contrato";
            this.grdGRR_Contrato.Size = new System.Drawing.Size(375, 162);
            this.grdGRR_Contrato.TabIndex = 0;
            this.grdGRR_Contrato.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnReloadContratos);
            this.panel8.Controls.Add(this.panelCaption4);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(375, 29);
            this.panel8.TabIndex = 55;
            // 
            // btnReloadContratos
            // 
            this.btnReloadContratos.BackColor = System.Drawing.Color.Transparent;
            this.btnReloadContratos.Image = global::Delfin.Principal.Properties.Resources.replace2;
            this.btnReloadContratos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReloadContratos.Location = new System.Drawing.Point(158, 1);
            this.btnReloadContratos.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnReloadContratos.Name = "btnReloadContratos";
            this.btnReloadContratos.Size = new System.Drawing.Size(25, 25);
            this.btnReloadContratos.TabIndex = 1;
            this.btnReloadContratos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReloadContratos.UseVisualStyleBackColor = false;
            // 
            // panelCaption4
            // 
            this.panelCaption4.AllowActive = false;
            this.panelCaption4.AntiAlias = false;
            this.panelCaption4.Caption = "Contratos";
            this.panelCaption4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption4.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption4.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption4.Location = new System.Drawing.Point(0, 0);
            this.panelCaption4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelCaption4.Name = "panelCaption4";
            this.panelCaption4.Size = new System.Drawing.Size(375, 27);
            this.panelCaption4.TabIndex = 0;
            // 
            // MAN012MView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.splitRebateGRR);
            this.Controls.Add(this.tableRebateGRR);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MAN012MView";
            this.ShowInTaskbar = false;
            this.Text = "Mantenimiento de Rebate y GRR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorGRR)).EndInit();
            this.tableRebateGRR.ResumeLayout(false);
            this.tableRebateGRR.PerformLayout();
            this.splitRebateGRR.Panel1.ResumeLayout(false);
            this.splitRebateGRR.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRebateGRR)).EndInit();
            this.splitRebateGRR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGRR_Paquetes.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGRR_Paquetes)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGRR_Contrato.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGRR_Contrato)).EndInit();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infrastructure.WinForms.Controls.TextBoxNumerico txnREBA_Codigo;
        private System.Windows.Forms.Label lblREBA_Codigo;
        private System.Windows.Forms.TableLayoutPanel tableRebateGRR;
        private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnMAN_salir;
        private System.Windows.Forms.Button btnMAN_guardar;
        private System.Windows.Forms.ErrorProvider errorGRR;
        private System.Windows.Forms.Label lblENTC_CodTransportista;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtREBA_FecIni;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtREBA_FecFin;
        private System.Windows.Forms.Label lblREBA_FecIni;
        private System.Windows.Forms.Label lblREBA_FecFin;
        private System.Windows.Forms.Label lblTIPO_CodMND;
        private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMnd;
        private System.Windows.Forms.SplitContainer splitRebateGRR;
        private Telerik.WinControls.UI.RadGridView grdGRR_Paquetes;
        private Telerik.WinControls.UI.RadGridView grdGRR_Contrato;
        private System.Windows.Forms.Label lblREBA_Tipo;
        private System.Windows.Forms.Label lblREBA_CostoFlete;
        private System.Windows.Forms.Label lblREBA_CostoFleteDes;
        private System.Windows.Forms.Label lblREBA_LimiteInf;
        private System.Windows.Forms.Label lblREBA_LimiteSup;
        private Infrastructure.WinForms.Controls.TextBoxNumerico txnREBA_CostoFlete;
        private Infrastructure.WinForms.Controls.TextBoxNumerico txnREBA_CostoFleteDes;
        private Infrastructure.WinForms.Controls.TextBoxNumerico txnREBA_LimiteInf;
        private Infrastructure.WinForms.Controls.TextBoxNumerico txnREBA_LimiteSup;
        private System.Windows.Forms.Panel panel1;
        private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnReloadContratos;
        private Infrastructure.WinForms.Controls.PanelCaption panelCaption4;
        private Controls.Entidad txaENTC_CodTransportista;
        private Infrastructure.WinForms.Controls.TextBoxNumerico txnREBA_Valor;
        private System.Windows.Forms.Label lblREBA_Valor;
        private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbREBA_Tipo;
        private System.Windows.Forms.Label lblREBA_ValorPorcentaje;
        private Infrastructure.WinForms.Controls.TextBoxNumerico txnREBA_ValorPorcentaje;
        private System.Windows.Forms.Label label1;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtREBA_FecCalc;
    }
}