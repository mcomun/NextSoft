namespace Delfin.Principal
{
   partial class CAJ004ChequesEnBlancoMView
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
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnSalir = new System.Windows.Forms.Button();
         this.btnGuardar = new System.Windows.Forms.Button();
         this.errorProviderMovimiento = new System.Windows.Forms.ErrorProvider(this.components);
         this.errorProviderDet_Cotizacion_OV_Novedad = new System.Windows.Forms.ErrorProvider(this.components);
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.errorEventoTarea = new System.Windows.Forms.ErrorProvider(this.components);
         this.tableDatosGenerales = new System.Windows.Forms.TableLayoutPanel();
         this.cmbTIPO_CodMOV = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.label8 = new System.Windows.Forms.Label();
         this.cmbTIPE_Codigo = new Delfin.Controls.ComboBoxTipoEntidad();
         this.lblTIPE_Codigo = new System.Windows.Forms.Label();
         this.txtMOVI_Codigo = new System.Windows.Forms.TextBox();
         this.label23 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.txaCUBA_Codigo = new Delfin.Controls.CuentaBancaria(this.components);
         this.label5 = new System.Windows.Forms.Label();
         this.cmbTIPO_CodMND = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.label2 = new System.Windows.Forms.Label();
         this.txtMOVI_Numero = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.DTPMOVI_FecEmision = new Infrastructure.WinForms.Controls.MaskTime();
         this.label6 = new System.Windows.Forms.Label();
         this.txnMOVI_TipoCambio = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txaENTC_Codigo = new Delfin.Controls.EntidadDocIden();
         this.label1 = new System.Windows.Forms.Label();
         this.txtMOVI_OrdenDe = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.lblMOVI_FecVigencia = new System.Windows.Forms.Label();
         this.dtpMOVI_FecVigencia = new Infrastructure.WinForms.Controls.MaskTime();
         this.txnMOVI_MontoLimite = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblMOVI_MontoLimite = new System.Windows.Forms.Label();
         this.txtMOVI_Responsable = new System.Windows.Forms.TextBox();
         this.lblMOVI_Responsable = new System.Windows.Forms.Label();
         this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.panel3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderMovimiento)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).BeginInit();
         this.tableDatosGenerales.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
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
         this.panel3.Size = new System.Drawing.Size(1102, 50);
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
         this.btnGuardar.Image = global::Delfin.Principal.Properties.Resources.save;
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
         // errorProviderMovimiento
         // 
         this.errorProviderMovimiento.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
         this.errorProviderMovimiento.ContainerControl = this;
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
         // tableDatosGenerales
         // 
         this.tableDatosGenerales.AutoSize = true;
         this.tableDatosGenerales.ColumnCount = 10;
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableDatosGenerales.Controls.Add(this.cmbTIPO_CodMOV, 4, 0);
         this.tableDatosGenerales.Controls.Add(this.label8, 3, 0);
         this.tableDatosGenerales.Controls.Add(this.cmbTIPE_Codigo, 1, 3);
         this.tableDatosGenerales.Controls.Add(this.lblTIPE_Codigo, 0, 3);
         this.tableDatosGenerales.Controls.Add(this.txtMOVI_Codigo, 1, 0);
         this.tableDatosGenerales.Controls.Add(this.label23, 0, 0);
         this.tableDatosGenerales.Controls.Add(this.label4, 0, 1);
         this.tableDatosGenerales.Controls.Add(this.txaCUBA_Codigo, 1, 1);
         this.tableDatosGenerales.Controls.Add(this.label5, 3, 1);
         this.tableDatosGenerales.Controls.Add(this.cmbTIPO_CodMND, 4, 1);
         this.tableDatosGenerales.Controls.Add(this.label2, 0, 2);
         this.tableDatosGenerales.Controls.Add(this.txtMOVI_Numero, 1, 2);
         this.tableDatosGenerales.Controls.Add(this.label3, 6, 0);
         this.tableDatosGenerales.Controls.Add(this.DTPMOVI_FecEmision, 7, 0);
         this.tableDatosGenerales.Controls.Add(this.label6, 6, 1);
         this.tableDatosGenerales.Controls.Add(this.txnMOVI_TipoCambio, 7, 1);
         this.tableDatosGenerales.Controls.Add(this.txaENTC_Codigo, 4, 3);
         this.tableDatosGenerales.Controls.Add(this.label1, 3, 3);
         this.tableDatosGenerales.Controls.Add(this.txtMOVI_OrdenDe, 4, 2);
         this.tableDatosGenerales.Controls.Add(this.label7, 3, 2);
         this.tableDatosGenerales.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableDatosGenerales.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableDatosGenerales.Location = new System.Drawing.Point(0, 76);
         this.tableDatosGenerales.Name = "tableDatosGenerales";
         this.tableDatosGenerales.RowCount = 5;
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.Size = new System.Drawing.Size(1102, 135);
         this.tableDatosGenerales.TabIndex = 2;
         // 
         // cmbTIPO_CodMOV
         // 
         this.cmbTIPO_CodMOV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodMOV.FormattingEnabled = true;
         this.cmbTIPO_CodMOV.Location = new System.Drawing.Point(518, 3);
         this.cmbTIPO_CodMOV.Name = "cmbTIPO_CodMOV";
         this.cmbTIPO_CodMOV.Session = null;
         this.cmbTIPO_CodMOV.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodMOV.TabIndex = 14;
         this.cmbTIPO_CodMOV.TiposSelectedItem = null;
         this.cmbTIPO_CodMOV.TiposSelectedValue = null;
         this.cmbTIPO_CodMOV.TiposTitulo = null;
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label8.Location = new System.Drawing.Point(375, 7);
         this.label8.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(127, 13);
         this.label8.TabIndex = 13;
         this.label8.Text = "Tipo de Movimiento :";
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
         // txtMOVI_Codigo
         // 
         this.txtMOVI_Codigo.Location = new System.Drawing.Point(153, 3);
         this.txtMOVI_Codigo.Name = "txtMOVI_Codigo";
         this.txtMOVI_Codigo.Size = new System.Drawing.Size(194, 20);
         this.txtMOVI_Codigo.TabIndex = 1;
         // 
         // label23
         // 
         this.label23.AutoSize = true;
         this.label23.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label23.Location = new System.Drawing.Point(10, 7);
         this.label23.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label23.Name = "label23";
         this.label23.Size = new System.Drawing.Size(86, 13);
         this.label23.TabIndex = 0;
         this.label23.Text = "Nro. Interno :";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(10, 34);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(94, 13);
         this.label4.TabIndex = 4;
         this.label4.Text = "Cta. Bancaria :";
         // 
         // txaCUBA_Codigo
         // 
         this.txaCUBA_Codigo.ActivarAyudaAuto = false;
         this.txaCUBA_Codigo.BackColor = System.Drawing.Color.White;
         this.txaCUBA_Codigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
         this.txaCUBA_Codigo.EMPR_Codigo = ((short)(0));
         this.txaCUBA_Codigo.EnabledAyuda = true;
         this.txaCUBA_Codigo.EnabledAyudaButton = true;
         this.txaCUBA_Codigo.EsFiltro = false;
         this.txaCUBA_Codigo.Location = new System.Drawing.Point(153, 30);
         this.txaCUBA_Codigo.LongitudAceptada = 0;
         this.txaCUBA_Codigo.MaxLength = 100;
         this.txaCUBA_Codigo.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
         this.txaCUBA_Codigo.Name = "txaCUBA_Codigo";
         this.txaCUBA_Codigo.RellenaCeros = false;
         this.txaCUBA_Codigo.SelectedItem = null;
         this.txaCUBA_Codigo.Size = new System.Drawing.Size(194, 20);
         this.txaCUBA_Codigo.TabIndex = 5;
         this.txaCUBA_Codigo.TAyuda = Delfin.Controls.CuentaBancaria.TipoAyuda.Normal;
         this.txaCUBA_Codigo.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
         this.txaCUBA_Codigo.Usuario = null;
         this.txaCUBA_Codigo.Value = null;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(375, 34);
         this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(51, 13);
         this.label5.TabIndex = 6;
         this.label5.Text = "Moneda";
         // 
         // cmbTIPO_CodMND
         // 
         this.cmbTIPO_CodMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodMND.FormattingEnabled = true;
         this.cmbTIPO_CodMND.Location = new System.Drawing.Point(518, 30);
         this.cmbTIPO_CodMND.Name = "cmbTIPO_CodMND";
         this.cmbTIPO_CodMND.Session = null;
         this.cmbTIPO_CodMND.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodMND.TabIndex = 7;
         this.cmbTIPO_CodMND.TiposSelectedItem = null;
         this.cmbTIPO_CodMND.TiposSelectedValue = null;
         this.cmbTIPO_CodMND.TiposTitulo = null;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(10, 61);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(60, 13);
         this.label2.TabIndex = 10;
         this.label2.Text = "Cheque :";
         // 
         // txtMOVI_Numero
         // 
         this.txtMOVI_Numero.Location = new System.Drawing.Point(153, 57);
         this.txtMOVI_Numero.Name = "txtMOVI_Numero";
         this.txtMOVI_Numero.Size = new System.Drawing.Size(194, 20);
         this.txtMOVI_Numero.TabIndex = 11;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(740, 7);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(93, 13);
         this.label3.TabIndex = 2;
         this.label3.Text = "Fecha Emisión:";
         // 
         // DTPMOVI_FecEmision
         // 
         this.DTPMOVI_FecEmision.Location = new System.Drawing.Point(883, 3);
         this.DTPMOVI_FecEmision.MinimumSize = new System.Drawing.Size(100, 22);
         this.DTPMOVI_FecEmision.Name = "DTPMOVI_FecEmision";
         this.DTPMOVI_FecEmision.NSActiveMouse = false;
         this.DTPMOVI_FecEmision.NSActiveMsgFecha = false;
         this.DTPMOVI_FecEmision.NSChangeDate = true;
         this.DTPMOVI_FecEmision.NSDigitos = 4;
         this.DTPMOVI_FecEmision.NSFecha = null;
         this.DTPMOVI_FecEmision.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.DTPMOVI_FecEmision.NSSetDateNow = false;
         this.DTPMOVI_FecEmision.Size = new System.Drawing.Size(100, 22);
         this.DTPMOVI_FecEmision.TabIndex = 3;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(740, 34);
         this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(88, 13);
         this.label6.TabIndex = 8;
         this.label6.Text = "Tipo Cambio :";
         // 
         // txnMOVI_TipoCambio
         // 
         this.txnMOVI_TipoCambio.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Moneda;
         this.txnMOVI_TipoCambio.Decimales = 4;
         this.txnMOVI_TipoCambio.Enteros = 1;
         this.txnMOVI_TipoCambio.Formato = "0.0000";
         this.txnMOVI_TipoCambio.Location = new System.Drawing.Point(883, 30);
         this.txnMOVI_TipoCambio.MaxLength = 6;
         this.txnMOVI_TipoCambio.Name = "txnMOVI_TipoCambio";
         this.txnMOVI_TipoCambio.Negativo = true;
         this.txnMOVI_TipoCambio.SinFormato = false;
         this.txnMOVI_TipoCambio.Size = new System.Drawing.Size(194, 20);
         this.txnMOVI_TipoCambio.TabIndex = 9;
         this.txnMOVI_TipoCambio.Text = "0.0000";
         this.txnMOVI_TipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnMOVI_TipoCambio.Value = new decimal(new int[] {
            0,
            0,
            0,
            262144});
         // 
         // txaENTC_Codigo
         // 
         this.txaENTC_Codigo.BackColor = System.Drawing.Color.LightSteelBlue;
         this.tableDatosGenerales.SetColumnSpan(this.txaENTC_Codigo, 4);
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
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(375, 88);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(58, 13);
         this.label1.TabIndex = 16;
         this.label1.Text = "Entidad :";
         // 
         // txtMOVI_OrdenDe
         // 
         this.tableDatosGenerales.SetColumnSpan(this.txtMOVI_OrdenDe, 4);
         this.txtMOVI_OrdenDe.Location = new System.Drawing.Point(518, 57);
         this.txtMOVI_OrdenDe.Name = "txtMOVI_OrdenDe";
         this.txtMOVI_OrdenDe.Size = new System.Drawing.Size(559, 20);
         this.txtMOVI_OrdenDe.TabIndex = 13;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label7.Location = new System.Drawing.Point(375, 61);
         this.label7.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(71, 13);
         this.label7.TabIndex = 12;
         this.label7.Text = "Orden De :";
         // 
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Datos";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 50);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(1102, 26);
         this.panelCaption1.TabIndex = 1;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.AutoSize = true;
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
         this.tableLayoutPanel1.Controls.Add(this.lblMOVI_FecVigencia, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.dtpMOVI_FecVigencia, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.txnMOVI_MontoLimite, 7, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblMOVI_MontoLimite, 6, 0);
         this.tableLayoutPanel1.Controls.Add(this.txtMOVI_Responsable, 4, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblMOVI_Responsable, 3, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 237);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(1102, 54);
         this.tableLayoutPanel1.TabIndex = 4;
         // 
         // lblMOVI_FecVigencia
         // 
         this.lblMOVI_FecVigencia.AutoSize = true;
         this.lblMOVI_FecVigencia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblMOVI_FecVigencia.Location = new System.Drawing.Point(10, 7);
         this.lblMOVI_FecVigencia.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblMOVI_FecVigencia.Name = "lblMOVI_FecVigencia";
         this.lblMOVI_FecVigencia.Size = new System.Drawing.Size(101, 13);
         this.lblMOVI_FecVigencia.TabIndex = 0;
         this.lblMOVI_FecVigencia.Text = "Fecha Vigencia :";
         // 
         // dtpMOVI_FecVigencia
         // 
         this.dtpMOVI_FecVigencia.Location = new System.Drawing.Point(153, 3);
         this.dtpMOVI_FecVigencia.MinimumSize = new System.Drawing.Size(100, 22);
         this.dtpMOVI_FecVigencia.Name = "dtpMOVI_FecVigencia";
         this.dtpMOVI_FecVigencia.NSActiveMouse = false;
         this.dtpMOVI_FecVigencia.NSActiveMsgFecha = false;
         this.dtpMOVI_FecVigencia.NSChangeDate = true;
         this.dtpMOVI_FecVigencia.NSDigitos = 4;
         this.dtpMOVI_FecVigencia.NSFecha = null;
         this.dtpMOVI_FecVigencia.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.dtpMOVI_FecVigencia.NSSetDateNow = false;
         this.dtpMOVI_FecVigencia.Size = new System.Drawing.Size(100, 22);
         this.dtpMOVI_FecVigencia.TabIndex = 1;
         // 
         // txnMOVI_MontoLimite
         // 
         this.txnMOVI_MontoLimite.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnMOVI_MontoLimite.Decimales = 2;
         this.txnMOVI_MontoLimite.Enteros = 9;
         this.txnMOVI_MontoLimite.Formato = "###,###,##0.00";
         this.txnMOVI_MontoLimite.Location = new System.Drawing.Point(883, 3);
         this.txnMOVI_MontoLimite.MaxLength = 13;
         this.txnMOVI_MontoLimite.Name = "txnMOVI_MontoLimite";
         this.txnMOVI_MontoLimite.Negativo = true;
         this.txnMOVI_MontoLimite.SinFormato = false;
         this.txnMOVI_MontoLimite.Size = new System.Drawing.Size(194, 20);
         this.txnMOVI_MontoLimite.TabIndex = 5;
         this.txnMOVI_MontoLimite.Text = "0.00";
         this.txnMOVI_MontoLimite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnMOVI_MontoLimite.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // lblMOVI_MontoLimite
         // 
         this.lblMOVI_MontoLimite.AutoSize = true;
         this.lblMOVI_MontoLimite.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblMOVI_MontoLimite.Location = new System.Drawing.Point(740, 7);
         this.lblMOVI_MontoLimite.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblMOVI_MontoLimite.Name = "lblMOVI_MontoLimite";
         this.lblMOVI_MontoLimite.Size = new System.Drawing.Size(88, 13);
         this.lblMOVI_MontoLimite.TabIndex = 4;
         this.lblMOVI_MontoLimite.Text = "Monto Limite :";
         // 
         // txtMOVI_Responsable
         // 
         this.txtMOVI_Responsable.Location = new System.Drawing.Point(518, 3);
         this.txtMOVI_Responsable.Name = "txtMOVI_Responsable";
         this.txtMOVI_Responsable.Size = new System.Drawing.Size(194, 20);
         this.txtMOVI_Responsable.TabIndex = 3;
         // 
         // lblMOVI_Responsable
         // 
         this.lblMOVI_Responsable.AutoSize = true;
         this.lblMOVI_Responsable.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblMOVI_Responsable.Location = new System.Drawing.Point(375, 7);
         this.lblMOVI_Responsable.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblMOVI_Responsable.Name = "lblMOVI_Responsable";
         this.lblMOVI_Responsable.Size = new System.Drawing.Size(88, 13);
         this.lblMOVI_Responsable.TabIndex = 2;
         this.lblMOVI_Responsable.Text = "Responsable :";
         // 
         // panelCaption2
         // 
         this.panelCaption2.AllowActive = false;
         this.panelCaption2.AntiAlias = false;
         this.panelCaption2.Caption = "Datos de Vigencia";
         this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption2.Location = new System.Drawing.Point(0, 211);
         this.panelCaption2.Name = "panelCaption2";
         this.panelCaption2.Size = new System.Drawing.Size(1102, 26);
         this.panelCaption2.TabIndex = 3;
         // 
         // CAJ004ChequesEnBlancoMView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.CancelButton = this.btnSalir;
         this.ClientSize = new System.Drawing.Size(1102, 268);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panelCaption2);
         this.Controls.Add(this.tableDatosGenerales);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Name = "CAJ004ChequesEnBlancoMView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Cheques en Blanco";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderMovimiento)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).EndInit();
         this.tableDatosGenerales.ResumeLayout(false);
         this.tableDatosGenerales.PerformLayout();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }



      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private System.Windows.Forms.ErrorProvider errorProviderMovimiento;
      private System.Windows.Forms.ErrorProvider errorProviderDet_Cotizacion_OV_Novedad;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.ErrorProvider errorEventoTarea;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
      private System.Windows.Forms.TableLayoutPanel tableDatosGenerales;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.Label lblMOVI_MontoLimite;
      private System.Windows.Forms.Label lblMOVI_Responsable;
      private System.Windows.Forms.Label lblMOVI_FecVigencia;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label23;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox txtMOVI_Responsable;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnMOVI_MontoLimite;
      private Infrastructure.WinForms.Controls.MaskTime dtpMOVI_FecVigencia;
      private System.Windows.Forms.TextBox txtMOVI_OrdenDe;
      private System.Windows.Forms.TextBox txtMOVI_Codigo;
      private System.Windows.Forms.TextBox txtMOVI_Numero;
      private Infrastructure.WinForms.Controls.MaskTime DTPMOVI_FecEmision;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMND;
      private Controls.EntidadDocIden txaENTC_Codigo;
      private Controls.CuentaBancaria txaCUBA_Codigo;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnMOVI_TipoCambio;
      private System.Windows.Forms.Label lblTIPE_Codigo;
      private Controls.ComboBoxTipoEntidad cmbTIPE_Codigo;
      private System.Windows.Forms.Label label8;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMOV;
   }
}