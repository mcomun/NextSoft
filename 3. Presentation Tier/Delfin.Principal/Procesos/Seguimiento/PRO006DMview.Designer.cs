namespace Delfin.Principal
{
    partial class PRO006DMview
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
            this.PnBotones = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStandarHBL = new System.Windows.Forms.Label();
            this.lblStandarSada20 = new System.Windows.Forms.Label();
            this.lblStandarHBLSada = new System.Windows.Forms.Label();
            this.lblStandar40 = new System.Windows.Forms.Label();
            this.lblStandarSada40 = new System.Windows.Forms.Label();
            this.lblStandar20 = new System.Windows.Forms.Label();
            this.PnStandar40 = new Infrastructure.WinFormsControls.PanelCaption();
            this.PnCantidades = new Infrastructure.WinFormsControls.PanelCaption();
            this.tlpTarifarioLogistico = new System.Windows.Forms.TableLayoutPanel();
            this.mdtDSEG_FechaArribo = new Infrastructure.WinFormsControls.MaskDateTime();
            this.mdtDSEG_FecIngresoDep = new Infrastructure.WinFormsControls.MaskDateTime();
            this.CbPACK_Codigo = new System.Windows.Forms.ComboBox();
            this.txtDSEG_NroContenedor = new System.Windows.Forms.TextBox();
            this.mdtDSEG_FecRetiroDep = new Infrastructure.WinFormsControls.MaskDateTime();
            this.mdtDSEG_FecPago = new Infrastructure.WinFormsControls.MaskDateTime();
            this.label1 = new System.Windows.Forms.Label();
            this.mdtFecVencimiento = new Infrastructure.WinFormsControls.MaskDateTime();
            this.chkDSEG_Tarja = new System.Windows.Forms.CheckBox();
            this.CbCONS_CodESS = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.PnBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tlpTarifarioLogistico.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnBotones
            // 
            this.PnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PnBotones.Controls.Add(this.btnAgregar);
            this.PnBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnBotones.Location = new System.Drawing.Point(0, 0);
            this.PnBotones.Name = "PnBotones";
            this.PnBotones.Size = new System.Drawing.Size(673, 50);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(332, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Ingreso Dep.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha de Arribo:";
            // 
            // lblStandarHBL
            // 
            this.lblStandarHBL.AutoSize = true;
            this.lblStandarHBL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandarHBL.Location = new System.Drawing.Point(10, 88);
            this.lblStandarHBL.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblStandarHBL.Name = "lblStandarHBL";
            this.lblStandarHBL.Size = new System.Drawing.Size(42, 13);
            this.lblStandarHBL.TabIndex = 10;
            this.lblStandarHBL.Text = "Tarja:";
            // 
            // lblStandarSada20
            // 
            this.lblStandarSada20.AutoSize = true;
            this.lblStandarSada20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandarSada20.Location = new System.Drawing.Point(332, 61);
            this.lblStandarSada20.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblStandarSada20.Name = "lblStandarSada20";
            this.lblStandarSada20.Size = new System.Drawing.Size(77, 13);
            this.lblStandarSada20.TabIndex = 8;
            this.lblStandarSada20.Text = "Fecha Pago:";
            // 
            // lblStandarHBLSada
            // 
            this.lblStandarHBLSada.AutoSize = true;
            this.lblStandarHBLSada.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandarHBLSada.Location = new System.Drawing.Point(10, 169);
            this.lblStandarHBLSada.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblStandarHBLSada.Name = "lblStandarHBLSada";
            this.lblStandarHBLSada.Size = new System.Drawing.Size(50, 13);
            this.lblStandarHBLSada.TabIndex = 19;
            this.lblStandarHBLSada.Text = "Estado:";
            // 
            // lblStandar40
            // 
            this.lblStandar40.AutoSize = true;
            this.lblStandar40.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandar40.Location = new System.Drawing.Point(10, 142);
            this.lblStandar40.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblStandar40.Name = "lblStandar40";
            this.lblStandar40.Size = new System.Drawing.Size(79, 13);
            this.lblStandar40.TabIndex = 15;
            this.lblStandar40.Text = "Contenedor:";
            // 
            // lblStandarSada40
            // 
            this.lblStandarSada40.AutoSize = true;
            this.lblStandarSada40.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandarSada40.Location = new System.Drawing.Point(332, 142);
            this.lblStandarSada40.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblStandarSada40.Name = "lblStandarSada40";
            this.lblStandarSada40.Size = new System.Drawing.Size(107, 13);
            this.lblStandarSada40.TabIndex = 17;
            this.lblStandarSada40.Text = "Nro. Contenedor:";
            // 
            // lblStandar20
            // 
            this.lblStandar20.AutoSize = true;
            this.lblStandar20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandar20.Location = new System.Drawing.Point(10, 61);
            this.lblStandar20.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblStandar20.Name = "lblStandar20";
            this.lblStandar20.Size = new System.Drawing.Size(82, 20);
            this.lblStandar20.TabIndex = 6;
            this.lblStandar20.Text = "Fecha Retiro Dep.:";
            // 
            // PnStandar40
            // 
            this.PnStandar40.AllowActive = false;
            this.PnStandar40.AntiAlias = false;
            this.PnStandar40.Caption = "Contenedor";
            this.tlpTarifarioLogistico.SetColumnSpan(this.PnStandar40, 5);
            this.PnStandar40.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnStandar40.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.PnStandar40.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.PnStandar40.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.PnStandar40.Location = new System.Drawing.Point(3, 111);
            this.PnStandar40.Name = "PnStandar40";
            this.PnStandar40.Size = new System.Drawing.Size(651, 21);
            this.PnStandar40.TabIndex = 14;
            // 
            // PnCantidades
            // 
            this.PnCantidades.AllowActive = false;
            this.PnCantidades.AntiAlias = false;
            this.PnCantidades.Caption = "Fechas";
            this.tlpTarifarioLogistico.SetColumnSpan(this.PnCantidades, 5);
            this.PnCantidades.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnCantidades.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.PnCantidades.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.PnCantidades.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.PnCantidades.Location = new System.Drawing.Point(3, 3);
            this.PnCantidades.Name = "PnCantidades";
            this.PnCantidades.Size = new System.Drawing.Size(651, 21);
            this.PnCantidades.TabIndex = 1;
            // 
            // tlpTarifarioLogistico
            // 
            this.tlpTarifarioLogistico.AutoSize = true;
            this.tlpTarifarioLogistico.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tlpTarifarioLogistico.ColumnCount = 7;
            this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTarifarioLogistico.Controls.Add(this.PnCantidades, 0, 0);
            this.tlpTarifarioLogistico.Controls.Add(this.PnStandar40, 0, 4);
            this.tlpTarifarioLogistico.Controls.Add(this.lblStandarSada40, 3, 5);
            this.tlpTarifarioLogistico.Controls.Add(this.lblStandar40, 0, 5);
            this.tlpTarifarioLogistico.Controls.Add(this.label2, 0, 1);
            this.tlpTarifarioLogistico.Controls.Add(this.label3, 3, 1);
            this.tlpTarifarioLogistico.Controls.Add(this.mdtDSEG_FechaArribo, 1, 1);
            this.tlpTarifarioLogistico.Controls.Add(this.mdtDSEG_FecIngresoDep, 4, 1);
            this.tlpTarifarioLogistico.Controls.Add(this.CbPACK_Codigo, 1, 5);
            this.tlpTarifarioLogistico.Controls.Add(this.txtDSEG_NroContenedor, 4, 5);
            this.tlpTarifarioLogistico.Controls.Add(this.mdtDSEG_FecRetiroDep, 1, 2);
            this.tlpTarifarioLogistico.Controls.Add(this.lblStandar20, 0, 2);
            this.tlpTarifarioLogistico.Controls.Add(this.lblStandarSada20, 3, 2);
            this.tlpTarifarioLogistico.Controls.Add(this.mdtDSEG_FecPago, 4, 2);
            this.tlpTarifarioLogistico.Controls.Add(this.label1, 3, 3);
            this.tlpTarifarioLogistico.Controls.Add(this.mdtFecVencimiento, 4, 3);
            this.tlpTarifarioLogistico.Controls.Add(this.chkDSEG_Tarja, 1, 3);
            this.tlpTarifarioLogistico.Controls.Add(this.lblStandarHBL, 0, 3);
            this.tlpTarifarioLogistico.Controls.Add(this.lblStandarHBLSada, 0, 6);
            this.tlpTarifarioLogistico.Controls.Add(this.CbCONS_CodESS, 1, 6);
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
            this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTarifarioLogistico.Size = new System.Drawing.Size(673, 216);
            this.tlpTarifarioLogistico.TabIndex = 0;
            // 
            // mdtDSEG_FechaArribo
            // 
            this.mdtDSEG_FechaArribo.Enabled = false;
            this.mdtDSEG_FechaArribo.Location = new System.Drawing.Point(119, 30);
            this.mdtDSEG_FechaArribo.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtDSEG_FechaArribo.Name = "mdtDSEG_FechaArribo";
            this.mdtDSEG_FechaArribo.NSActiveMouse = false;
            this.mdtDSEG_FechaArribo.NSActiveMsgFecha = false;
            this.mdtDSEG_FechaArribo.NSChangeDate = true;
            this.mdtDSEG_FechaArribo.NSDigitos = 4;
            this.mdtDSEG_FechaArribo.NSFecha = null;
            this.mdtDSEG_FechaArribo.NSSetDateNow = false;
            this.mdtDSEG_FechaArribo.Size = new System.Drawing.Size(182, 22);
            this.mdtDSEG_FechaArribo.TabIndex = 3;
            this.mdtDSEG_FechaArribo.Tag = "DSEG_FechaArriboMSGERROR";
            // 
            // mdtDSEG_FecIngresoDep
            // 
            this.mdtDSEG_FecIngresoDep.Location = new System.Drawing.Point(471, 30);
            this.mdtDSEG_FecIngresoDep.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtDSEG_FecIngresoDep.Name = "mdtDSEG_FecIngresoDep";
            this.mdtDSEG_FecIngresoDep.NSActiveMouse = false;
            this.mdtDSEG_FecIngresoDep.NSActiveMsgFecha = false;
            this.mdtDSEG_FecIngresoDep.NSChangeDate = true;
            this.mdtDSEG_FecIngresoDep.NSDigitos = 4;
            this.mdtDSEG_FecIngresoDep.NSFecha = null;
            this.mdtDSEG_FecIngresoDep.NSSetDateNow = false;
            this.mdtDSEG_FecIngresoDep.Size = new System.Drawing.Size(182, 22);
            this.mdtDSEG_FecIngresoDep.TabIndex = 5;
            this.mdtDSEG_FecIngresoDep.Tag = "DSEG_FecIngresoDepMSGERROR";
            // 
            // CbPACK_Codigo
            // 
            this.CbPACK_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPACK_Codigo.FormattingEnabled = true;
            this.CbPACK_Codigo.Location = new System.Drawing.Point(119, 138);
            this.CbPACK_Codigo.Name = "CbPACK_Codigo";
            this.CbPACK_Codigo.Size = new System.Drawing.Size(182, 21);
            this.CbPACK_Codigo.TabIndex = 16;
            this.CbPACK_Codigo.Tag = "PACK_CodigoMSGERROR";
            // 
            // txtDSEG_NroContenedor
            // 
            this.txtDSEG_NroContenedor.Location = new System.Drawing.Point(471, 138);
            this.txtDSEG_NroContenedor.Name = "txtDSEG_NroContenedor";
            this.txtDSEG_NroContenedor.Size = new System.Drawing.Size(182, 20);
            this.txtDSEG_NroContenedor.TabIndex = 18;
            this.txtDSEG_NroContenedor.Tag = "DSEG_NroContenedorMSGERROR";
            // 
            // mdtDSEG_FecRetiroDep
            // 
            this.mdtDSEG_FecRetiroDep.Location = new System.Drawing.Point(119, 57);
            this.mdtDSEG_FecRetiroDep.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtDSEG_FecRetiroDep.Name = "mdtDSEG_FecRetiroDep";
            this.mdtDSEG_FecRetiroDep.NSActiveMouse = false;
            this.mdtDSEG_FecRetiroDep.NSActiveMsgFecha = false;
            this.mdtDSEG_FecRetiroDep.NSChangeDate = true;
            this.mdtDSEG_FecRetiroDep.NSDigitos = 4;
            this.mdtDSEG_FecRetiroDep.NSFecha = null;
            this.mdtDSEG_FecRetiroDep.NSSetDateNow = false;
            this.mdtDSEG_FecRetiroDep.Size = new System.Drawing.Size(182, 22);
            this.mdtDSEG_FecRetiroDep.TabIndex = 7;
            // 
            // mdtDSEG_FecPago
            // 
            this.mdtDSEG_FecPago.Location = new System.Drawing.Point(471, 57);
            this.mdtDSEG_FecPago.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtDSEG_FecPago.Name = "mdtDSEG_FecPago";
            this.mdtDSEG_FecPago.NSActiveMouse = false;
            this.mdtDSEG_FecPago.NSActiveMsgFecha = false;
            this.mdtDSEG_FecPago.NSChangeDate = true;
            this.mdtDSEG_FecPago.NSDigitos = 4;
            this.mdtDSEG_FecPago.NSFecha = null;
            this.mdtDSEG_FecPago.NSSetDateNow = false;
            this.mdtDSEG_FecPago.Size = new System.Drawing.Size(182, 22);
            this.mdtDSEG_FecPago.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(332, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fecha Vencimiento:";
            // 
            // mdtFecVencimiento
            // 
            this.mdtFecVencimiento.Enabled = false;
            this.mdtFecVencimiento.Location = new System.Drawing.Point(471, 84);
            this.mdtFecVencimiento.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFecVencimiento.Name = "mdtFecVencimiento";
            this.mdtFecVencimiento.NSActiveMouse = false;
            this.mdtFecVencimiento.NSActiveMsgFecha = false;
            this.mdtFecVencimiento.NSChangeDate = true;
            this.mdtFecVencimiento.NSDigitos = 4;
            this.mdtFecVencimiento.NSFecha = null;
            this.mdtFecVencimiento.NSSetDateNow = false;
            this.mdtFecVencimiento.Size = new System.Drawing.Size(182, 22);
            this.mdtFecVencimiento.TabIndex = 13;
            // 
            // chkDSEG_Tarja
            // 
            this.chkDSEG_Tarja.AutoSize = true;
            this.chkDSEG_Tarja.Location = new System.Drawing.Point(119, 84);
            this.chkDSEG_Tarja.Name = "chkDSEG_Tarja";
            this.chkDSEG_Tarja.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.chkDSEG_Tarja.Size = new System.Drawing.Size(15, 19);
            this.chkDSEG_Tarja.TabIndex = 11;
            this.chkDSEG_Tarja.UseVisualStyleBackColor = true;
            // 
            // CbCONS_CodESS
            // 
            this.CbCONS_CodESS.ConstantesSelectedItem = null;
            this.CbCONS_CodESS.ConstantesSelectedValue = null;
            this.CbCONS_CodESS.ConstantesTitulo = null;
            this.CbCONS_CodESS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCONS_CodESS.FormattingEnabled = true;
            this.CbCONS_CodESS.Location = new System.Drawing.Point(119, 165);
            this.CbCONS_CodESS.Name = "CbCONS_CodESS";
            this.CbCONS_CodESS.Size = new System.Drawing.Size(182, 21);
            this.CbCONS_CodESS.TabIndex = 0;
            this.CbCONS_CodESS.Tag = "CONS_CodESSMSGERROR";
            // 
            // PRO006DMview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(673, 242);
            this.Controls.Add(this.tlpTarifarioLogistico);
            this.Controls.Add(this.PnBotones);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PRO006DMview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Seguimiento";
            this.PnBotones.ResumeLayout(false);
            this.PnBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tlpTarifarioLogistico.ResumeLayout(false);
            this.tlpTarifarioLogistico.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnBotones;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tlpTarifarioLogistico;
        private Infrastructure.WinFormsControls.PanelCaption PnCantidades;
        private Infrastructure.WinFormsControls.PanelCaption PnStandar40;
        private System.Windows.Forms.Label lblStandar20;
        private System.Windows.Forms.Label lblStandarSada40;
        private System.Windows.Forms.Label lblStandar40;
        private System.Windows.Forms.Label lblStandarHBLSada;
        private System.Windows.Forms.Label lblStandarSada20;
        private System.Windows.Forms.Label lblStandarHBL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Controls.Tipos.ComboBoxConstantes CbCONS_CodESS;
        private Infrastructure.WinFormsControls.MaskDateTime mdtDSEG_FechaArribo;
        private Infrastructure.WinFormsControls.MaskDateTime mdtDSEG_FecIngresoDep;
        private System.Windows.Forms.CheckBox chkDSEG_Tarja;
        private Infrastructure.WinFormsControls.MaskDateTime mdtDSEG_FecRetiroDep;
        private Infrastructure.WinFormsControls.MaskDateTime mdtDSEG_FecPago;
        private System.Windows.Forms.ComboBox CbPACK_Codigo;
        private System.Windows.Forms.TextBox txtDSEG_NroContenedor;
        private System.Windows.Forms.Label label1;
        private Infrastructure.WinFormsControls.MaskDateTime mdtFecVencimiento;
    }
}