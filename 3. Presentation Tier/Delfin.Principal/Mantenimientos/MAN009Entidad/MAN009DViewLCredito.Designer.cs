namespace Delfin.Principal
{
   partial class MAN009DViewLCredito
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
         this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnSalir = new System.Windows.Forms.Button();
         this.btnGuardar = new System.Windows.Forms.Button();
         this.tlpDetalle = new System.Windows.Forms.TableLayoutPanel();
         this.cmbTipoFechaVencimiento = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblENLI_FormaPago = new System.Windows.Forms.Label();
         this.cmbENLI_FormaPago = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.dtpENLI_FecVencimiento = new Infrastructure.WinForms.Controls.MaskTime();
         this.dtpENLI_FecInicio = new Infrastructure.WinForms.Controls.MaskTime();
         this.lblENLI_FecVencimiento = new System.Windows.Forms.Label();
         this.lblENLI_FecInicio = new System.Windows.Forms.Label();
         this.cmbTIPO_CodMND = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.txnENLI_DiasDuracion = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblENLI_DiasDuracion = new System.Windows.Forms.Label();
         this.txnENLI_Monto = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.label5 = new System.Windows.Forms.Label();
         this.lblENLI_Tipos = new System.Windows.Forms.Label();
         this.cmbENLI_Tipos = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblTipoFechaVencimiento = new System.Windows.Forms.Label();
         this.txtENLI_Codigo = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.lblENLI_Fecha = new System.Windows.Forms.Label();
         this.dtpENLI_Fecha = new Infrastructure.WinForms.Controls.MaskTime();
         this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
         this.cmbTIPE_CodPadre = new System.Windows.Forms.ComboBox();
         this.lblTIPE_CodPadre = new System.Windows.Forms.Label();
         this.lblENTC_CodPadre = new System.Windows.Forms.Label();
         this.txaENTC_CodPadre = new Delfin.Controls.EntidadDocIden();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tlpDatosGenerales = new System.Windows.Forms.TableLayoutPanel();
         this.label9 = new System.Windows.Forms.Label();
         this.txtENLI_Notas = new System.Windows.Forms.TextBox();
         this.errorProviderLC = new System.Windows.Forms.ErrorProvider(this.components);
         this.chkENLI_CliAutEmiCheqDiferidos = new System.Windows.Forms.CheckBox();
         this.chkENLI_CliConCredLibre = new System.Windows.Forms.CheckBox();
         this.panel3.SuspendLayout();
         this.tlpDetalle.SuspendLayout();
         this.tableLayoutPanel3.SuspendLayout();
         this.tlpDatosGenerales.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderLC)).BeginInit();
         this.SuspendLayout();
         // 
         // panelCaption3
         // 
         this.panelCaption3.AllowActive = false;
         this.panelCaption3.AntiAlias = false;
         this.panelCaption3.Caption = "Detalle";
         this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption3.Location = new System.Drawing.Point(0, 103);
         this.panelCaption3.Name = "panelCaption3";
         this.panelCaption3.Size = new System.Drawing.Size(1098, 26);
         this.panelCaption3.TabIndex = 2;
         // 
         // panel3
         // 
         this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
         this.panel3.Controls.Add(this.btnSalir);
         this.panel3.Controls.Add(this.btnGuardar);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel3.Location = new System.Drawing.Point(0, 0);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(1098, 50);
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
         this.btnSalir.Text = "Salir";
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
         this.btnGuardar.Text = "Guardar";
         this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnGuardar.UseVisualStyleBackColor = true;
         // 
         // tlpDetalle
         // 
         this.tlpDetalle.AutoSize = true;
         this.tlpDetalle.ColumnCount = 11;
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpDetalle.Controls.Add(this.chkENLI_CliConCredLibre, 3, 3);
         this.tlpDetalle.Controls.Add(this.chkENLI_CliAutEmiCheqDiferidos, 0, 3);
         this.tlpDetalle.Controls.Add(this.cmbTipoFechaVencimiento, 7, 0);
         this.tlpDetalle.Controls.Add(this.lblENLI_FormaPago, 6, 2);
         this.tlpDetalle.Controls.Add(this.lblENLI_Tipos, 3, 0);
         this.tlpDetalle.Controls.Add(this.cmbENLI_Tipos, 4, 0);
         this.tlpDetalle.Controls.Add(this.cmbENLI_FormaPago, 7, 2);
         this.tlpDetalle.Controls.Add(this.label3, 8, 1);
         this.tlpDetalle.Controls.Add(this.label2, 0, 1);
         this.tlpDetalle.Controls.Add(this.dtpENLI_FecVencimiento, 4, 2);
         this.tlpDetalle.Controls.Add(this.dtpENLI_FecInicio, 1, 2);
         this.tlpDetalle.Controls.Add(this.lblENLI_FecVencimiento, 3, 2);
         this.tlpDetalle.Controls.Add(this.lblENLI_FecInicio, 0, 2);
         this.tlpDetalle.Controls.Add(this.cmbTIPO_CodMND, 1, 1);
         this.tlpDetalle.Controls.Add(this.txnENLI_DiasDuracion, 7, 1);
         this.tlpDetalle.Controls.Add(this.lblENLI_DiasDuracion, 6, 1);
         this.tlpDetalle.Controls.Add(this.txnENLI_Monto, 4, 1);
         this.tlpDetalle.Controls.Add(this.label5, 3, 1);
         this.tlpDetalle.Controls.Add(this.lblTipoFechaVencimiento, 6, 0);
         this.tlpDetalle.Controls.Add(this.txtENLI_Codigo, 1, 0);
         this.tlpDetalle.Controls.Add(this.label1, 0, 0);
         this.tlpDetalle.Dock = System.Windows.Forms.DockStyle.Top;
         this.tlpDetalle.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tlpDetalle.Location = new System.Drawing.Point(0, 129);
         this.tlpDetalle.Name = "tlpDetalle";
         this.tlpDetalle.RowCount = 4;
         this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpDetalle.Size = new System.Drawing.Size(1098, 108);
         this.tlpDetalle.TabIndex = 3;
         // 
         // cmbTipoFechaVencimiento
         // 
         this.tlpDetalle.SetColumnSpan(this.cmbTipoFechaVencimiento, 2);
         this.cmbTipoFechaVencimiento.ConstantesSelectedItem = null;
         this.cmbTipoFechaVencimiento.ConstantesSelectedValue = null;
         this.cmbTipoFechaVencimiento.ConstantesTitulo = null;
         this.cmbTipoFechaVencimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTipoFechaVencimiento.FormattingEnabled = true;
         this.cmbTipoFechaVencimiento.Location = new System.Drawing.Point(883, 3);
         this.cmbTipoFechaVencimiento.Name = "cmbTipoFechaVencimiento";
         this.cmbTipoFechaVencimiento.Size = new System.Drawing.Size(194, 21);
         this.cmbTipoFechaVencimiento.TabIndex = 5;
         // 
         // lblENLI_FormaPago
         // 
         this.lblENLI_FormaPago.AutoSize = true;
         this.lblENLI_FormaPago.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.lblENLI_FormaPago.Location = new System.Drawing.Point(740, 61);
         this.lblENLI_FormaPago.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENLI_FormaPago.Name = "lblENLI_FormaPago";
         this.lblENLI_FormaPago.Size = new System.Drawing.Size(85, 13);
         this.lblENLI_FormaPago.TabIndex = 17;
         this.lblENLI_FormaPago.Text = "Forma de Pago :";
         // 
         // cmbENLI_FormaPago
         // 
         this.tlpDetalle.SetColumnSpan(this.cmbENLI_FormaPago, 2);
         this.cmbENLI_FormaPago.ConstantesSelectedItem = null;
         this.cmbENLI_FormaPago.ConstantesSelectedValue = null;
         this.cmbENLI_FormaPago.ConstantesTitulo = null;
         this.cmbENLI_FormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbENLI_FormaPago.FormattingEnabled = true;
         this.cmbENLI_FormaPago.Location = new System.Drawing.Point(883, 57);
         this.cmbENLI_FormaPago.Name = "cmbENLI_FormaPago";
         this.cmbENLI_FormaPago.Size = new System.Drawing.Size(194, 21);
         this.cmbENLI_FormaPago.TabIndex = 18;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.label3.Location = new System.Drawing.Point(990, 34);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(28, 13);
         this.label3.TabIndex = 12;
         this.label3.Text = "días";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.label2.Location = new System.Drawing.Point(10, 34);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(52, 13);
         this.label2.TabIndex = 6;
         this.label2.Text = "Moneda :";
         // 
         // dtpENLI_FecVencimiento
         // 
         this.dtpENLI_FecVencimiento.Location = new System.Drawing.Point(518, 57);
         this.dtpENLI_FecVencimiento.MinimumSize = new System.Drawing.Size(100, 22);
         this.dtpENLI_FecVencimiento.Name = "dtpENLI_FecVencimiento";
         this.dtpENLI_FecVencimiento.NSActiveMouse = false;
         this.dtpENLI_FecVencimiento.NSActiveMsgFecha = false;
         this.dtpENLI_FecVencimiento.NSChangeDate = true;
         this.dtpENLI_FecVencimiento.NSDigitos = 4;
         this.dtpENLI_FecVencimiento.NSFecha = null;
         this.dtpENLI_FecVencimiento.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.dtpENLI_FecVencimiento.NSSetDateNow = false;
         this.dtpENLI_FecVencimiento.Size = new System.Drawing.Size(100, 22);
         this.dtpENLI_FecVencimiento.TabIndex = 16;
         // 
         // dtpENLI_FecInicio
         // 
         this.dtpENLI_FecInicio.Location = new System.Drawing.Point(153, 57);
         this.dtpENLI_FecInicio.MinimumSize = new System.Drawing.Size(100, 22);
         this.dtpENLI_FecInicio.Name = "dtpENLI_FecInicio";
         this.dtpENLI_FecInicio.NSActiveMouse = false;
         this.dtpENLI_FecInicio.NSActiveMsgFecha = false;
         this.dtpENLI_FecInicio.NSChangeDate = true;
         this.dtpENLI_FecInicio.NSDigitos = 4;
         this.dtpENLI_FecInicio.NSFecha = null;
         this.dtpENLI_FecInicio.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.dtpENLI_FecInicio.NSSetDateNow = false;
         this.dtpENLI_FecInicio.Size = new System.Drawing.Size(100, 22);
         this.dtpENLI_FecInicio.TabIndex = 14;
         // 
         // lblENLI_FecVencimiento
         // 
         this.lblENLI_FecVencimiento.AutoSize = true;
         this.lblENLI_FecVencimiento.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.lblENLI_FecVencimiento.Location = new System.Drawing.Point(375, 61);
         this.lblENLI_FecVencimiento.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENLI_FecVencimiento.Name = "lblENLI_FecVencimiento";
         this.lblENLI_FecVencimiento.Size = new System.Drawing.Size(104, 13);
         this.lblENLI_FecVencimiento.TabIndex = 15;
         this.lblENLI_FecVencimiento.Text = "Fecha Vencimiento :";
         // 
         // lblENLI_FecInicio
         // 
         this.lblENLI_FecInicio.AutoSize = true;
         this.lblENLI_FecInicio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.lblENLI_FecInicio.Location = new System.Drawing.Point(10, 61);
         this.lblENLI_FecInicio.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENLI_FecInicio.Name = "lblENLI_FecInicio";
         this.lblENLI_FecInicio.Size = new System.Drawing.Size(71, 13);
         this.lblENLI_FecInicio.TabIndex = 13;
         this.lblENLI_FecInicio.Text = "Fecha Inicio :";
         // 
         // cmbTIPO_CodMND
         // 
         this.cmbTIPO_CodMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodMND.FormattingEnabled = true;
         this.cmbTIPO_CodMND.Location = new System.Drawing.Point(153, 30);
         this.cmbTIPO_CodMND.Name = "cmbTIPO_CodMND";
         this.cmbTIPO_CodMND.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodMND.TabIndex = 7;
         this.cmbTIPO_CodMND.TiposSelectedItem = null;
         this.cmbTIPO_CodMND.TiposSelectedValue = null;
         this.cmbTIPO_CodMND.TiposTitulo = null;
         // 
         // txnENLI_DiasDuracion
         // 
         this.txnENLI_DiasDuracion.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.txnENLI_DiasDuracion.Decimales = 0;
         this.txnENLI_DiasDuracion.Enteros = 9;
         this.txnENLI_DiasDuracion.Formato = "###,###,##0.";
         this.txnENLI_DiasDuracion.Location = new System.Drawing.Point(883, 30);
         this.txnENLI_DiasDuracion.MaxLength = 10;
         this.txnENLI_DiasDuracion.Name = "txnENLI_DiasDuracion";
         this.txnENLI_DiasDuracion.Negativo = true;
         this.txnENLI_DiasDuracion.SinFormato = false;
         this.txnENLI_DiasDuracion.Size = new System.Drawing.Size(94, 20);
         this.txnENLI_DiasDuracion.TabIndex = 11;
         this.txnENLI_DiasDuracion.Text = "0";
         this.txnENLI_DiasDuracion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnENLI_DiasDuracion.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblENLI_DiasDuracion
         // 
         this.lblENLI_DiasDuracion.AutoSize = true;
         this.lblENLI_DiasDuracion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.lblENLI_DiasDuracion.Location = new System.Drawing.Point(740, 34);
         this.lblENLI_DiasDuracion.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENLI_DiasDuracion.Name = "lblENLI_DiasDuracion";
         this.lblENLI_DiasDuracion.Size = new System.Drawing.Size(86, 13);
         this.lblENLI_DiasDuracion.TabIndex = 10;
         this.lblENLI_DiasDuracion.Text = "Duración (días) :";
         // 
         // txnENLI_Monto
         // 
         this.txnENLI_Monto.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.txnENLI_Monto.Decimales = 2;
         this.txnENLI_Monto.Enteros = 9;
         this.txnENLI_Monto.Formato = "###,###,##0.00";
         this.txnENLI_Monto.Location = new System.Drawing.Point(518, 30);
         this.txnENLI_Monto.MaxLength = 13;
         this.txnENLI_Monto.Name = "txnENLI_Monto";
         this.txnENLI_Monto.Negativo = true;
         this.txnENLI_Monto.SinFormato = false;
         this.txnENLI_Monto.Size = new System.Drawing.Size(194, 20);
         this.txnENLI_Monto.TabIndex = 9;
         this.txnENLI_Monto.Text = "0.00";
         this.txnENLI_Monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnENLI_Monto.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.label5.Location = new System.Drawing.Point(375, 34);
         this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(43, 13);
         this.label5.TabIndex = 8;
         this.label5.Text = "Monto :";
         // 
         // lblENLI_Tipos
         // 
         this.lblENLI_Tipos.AutoSize = true;
         this.lblENLI_Tipos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.lblENLI_Tipos.Location = new System.Drawing.Point(375, 7);
         this.lblENLI_Tipos.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENLI_Tipos.Name = "lblENLI_Tipos";
         this.lblENLI_Tipos.Size = new System.Drawing.Size(115, 13);
         this.lblENLI_Tipos.TabIndex = 2;
         this.lblENLI_Tipos.Text = "Tipo de Limite Crédito :";
         // 
         // cmbENLI_Tipos
         // 
         this.cmbENLI_Tipos.ConstantesSelectedItem = null;
         this.cmbENLI_Tipos.ConstantesSelectedValue = null;
         this.cmbENLI_Tipos.ConstantesTitulo = null;
         this.cmbENLI_Tipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbENLI_Tipos.FormattingEnabled = true;
         this.cmbENLI_Tipos.Location = new System.Drawing.Point(518, 3);
         this.cmbENLI_Tipos.Name = "cmbENLI_Tipos";
         this.cmbENLI_Tipos.Size = new System.Drawing.Size(194, 21);
         this.cmbENLI_Tipos.TabIndex = 3;
         // 
         // lblTipoFechaVencimiento
         // 
         this.lblTipoFechaVencimiento.AutoSize = true;
         this.lblTipoFechaVencimiento.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.lblTipoFechaVencimiento.Location = new System.Drawing.Point(740, 7);
         this.lblTipoFechaVencimiento.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTipoFechaVencimiento.Name = "lblTipoFechaVencimiento";
         this.lblTipoFechaVencimiento.Size = new System.Drawing.Size(107, 13);
         this.lblTipoFechaVencimiento.TabIndex = 4;
         this.lblTipoFechaVencimiento.Text = "Fecha - Vencimiento:";
         // 
         // txtENLI_Codigo
         // 
         this.txtENLI_Codigo.Location = new System.Drawing.Point(153, 3);
         this.txtENLI_Codigo.Name = "txtENLI_Codigo";
         this.txtENLI_Codigo.Size = new System.Drawing.Size(194, 20);
         this.txtENLI_Codigo.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.label1.Location = new System.Drawing.Point(10, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(46, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Código :";
         // 
         // lblENLI_Fecha
         // 
         this.lblENLI_Fecha.AutoSize = true;
         this.lblENLI_Fecha.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.lblENLI_Fecha.Location = new System.Drawing.Point(10, 7);
         this.lblENLI_Fecha.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENLI_Fecha.Name = "lblENLI_Fecha";
         this.lblENLI_Fecha.Size = new System.Drawing.Size(43, 13);
         this.lblENLI_Fecha.TabIndex = 0;
         this.lblENLI_Fecha.Text = "Fecha :";
         // 
         // dtpENLI_Fecha
         // 
         this.dtpENLI_Fecha.Location = new System.Drawing.Point(153, 3);
         this.dtpENLI_Fecha.MinimumSize = new System.Drawing.Size(100, 22);
         this.dtpENLI_Fecha.Name = "dtpENLI_Fecha";
         this.dtpENLI_Fecha.NSActiveMouse = false;
         this.dtpENLI_Fecha.NSActiveMsgFecha = false;
         this.dtpENLI_Fecha.NSChangeDate = true;
         this.dtpENLI_Fecha.NSDigitos = 4;
         this.dtpENLI_Fecha.NSFecha = null;
         this.dtpENLI_Fecha.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.dtpENLI_Fecha.NSSetDateNow = false;
         this.dtpENLI_Fecha.Size = new System.Drawing.Size(100, 22);
         this.dtpENLI_Fecha.TabIndex = 1;
         // 
         // tableLayoutPanel3
         // 
         this.tableLayoutPanel3.AutoSize = true;
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
         this.tableLayoutPanel3.Controls.Add(this.cmbTIPE_CodPadre, 1, 0);
         this.tableLayoutPanel3.Controls.Add(this.lblTIPE_CodPadre, 0, 0);
         this.tableLayoutPanel3.Controls.Add(this.lblENTC_CodPadre, 3, 0);
         this.tableLayoutPanel3.Controls.Add(this.txaENTC_CodPadre, 4, 0);
         this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 76);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 1;
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.Size = new System.Drawing.Size(1098, 27);
         this.tableLayoutPanel3.TabIndex = 2;
         // 
         // cmbTIPE_CodPadre
         // 
         this.cmbTIPE_CodPadre.FormattingEnabled = true;
         this.cmbTIPE_CodPadre.Location = new System.Drawing.Point(153, 3);
         this.cmbTIPE_CodPadre.Name = "cmbTIPE_CodPadre";
         this.cmbTIPE_CodPadre.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPE_CodPadre.TabIndex = 1;
         // 
         // lblTIPE_CodPadre
         // 
         this.lblTIPE_CodPadre.AutoSize = true;
         this.lblTIPE_CodPadre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.lblTIPE_CodPadre.Location = new System.Drawing.Point(10, 7);
         this.lblTIPE_CodPadre.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPE_CodPadre.Name = "lblTIPE_CodPadre";
         this.lblTIPE_CodPadre.Size = new System.Drawing.Size(88, 13);
         this.lblTIPE_CodPadre.TabIndex = 0;
         this.lblTIPE_CodPadre.Text = "Tipo de Entidad :";
         // 
         // lblENTC_CodPadre
         // 
         this.lblENTC_CodPadre.AutoSize = true;
         this.lblENTC_CodPadre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.lblENTC_CodPadre.Location = new System.Drawing.Point(375, 7);
         this.lblENTC_CodPadre.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENTC_CodPadre.Name = "lblENTC_CodPadre";
         this.lblENTC_CodPadre.Size = new System.Drawing.Size(85, 13);
         this.lblENTC_CodPadre.TabIndex = 2;
         this.lblENTC_CodPadre.Text = "Código Entidad :";
         // 
         // txaENTC_CodPadre
         // 
         this.txaENTC_CodPadre.BackColor = System.Drawing.Color.LightSteelBlue;
         this.txaENTC_CodPadre.CrearNuevaEntidad = false;
         this.txaENTC_CodPadre.Location = new System.Drawing.Point(515, 0);
         this.txaENTC_CodPadre.Margin = new System.Windows.Forms.Padding(0);
         this.txaENTC_CodPadre.MinimumSize = new System.Drawing.Size(565, 27);
         this.txaENTC_CodPadre.Name = "txaENTC_CodPadre";
         this.txaENTC_CodPadre.Size = new System.Drawing.Size(565, 27);
         this.txaENTC_CodPadre.TabIndex = 3;
         this.txaENTC_CodPadre.TagEntidad = null;
         this.txaENTC_CodPadre.TiposEntidad = Delfin.Controls.TiposEntidad.TIPE_AgenciaAduanera;
         this.txaENTC_CodPadre.txaENTC_DOCIDEN_Name = "txaENTC_DOCIDEN";
         this.txaENTC_CodPadre.txaENTC_NOMCOMPLETO_Name = "txaENTC_NOMCOMPLETO";
         // 
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Datos de la Entidad";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 50);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(1098, 26);
         this.panelCaption1.TabIndex = 1;
         // 
         // panelCaption2
         // 
         this.panelCaption2.AllowActive = false;
         this.panelCaption2.AntiAlias = false;
         this.panelCaption2.Caption = "Datos Generales";
         this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption2.Location = new System.Drawing.Point(0, 237);
         this.panelCaption2.Name = "panelCaption2";
         this.panelCaption2.Size = new System.Drawing.Size(1098, 26);
         this.panelCaption2.TabIndex = 4;
         // 
         // tlpDatosGenerales
         // 
         this.tlpDatosGenerales.AutoSize = true;
         this.tlpDatosGenerales.ColumnCount = 10;
         this.tlpDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tlpDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tlpDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tlpDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tlpDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tlpDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tlpDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tlpDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tlpDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tlpDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpDatosGenerales.Controls.Add(this.label9, 0, 1);
         this.tlpDatosGenerales.Controls.Add(this.lblENLI_Fecha, 0, 0);
         this.tlpDatosGenerales.Controls.Add(this.dtpENLI_Fecha, 1, 0);
         this.tlpDatosGenerales.Controls.Add(this.txtENLI_Notas, 1, 1);
         this.tlpDatosGenerales.Dock = System.Windows.Forms.DockStyle.Top;
         this.tlpDatosGenerales.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tlpDatosGenerales.Location = new System.Drawing.Point(0, 263);
         this.tlpDatosGenerales.Name = "tlpDatosGenerales";
         this.tlpDatosGenerales.RowCount = 3;
         this.tlpDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpDatosGenerales.Size = new System.Drawing.Size(1098, 81);
         this.tlpDatosGenerales.TabIndex = 5;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.label9.Location = new System.Drawing.Point(10, 34);
         this.label9.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(41, 13);
         this.label9.TabIndex = 3;
         this.label9.Text = "Notas :";
         // 
         // txtENLI_Notas
         // 
         this.tlpDatosGenerales.SetColumnSpan(this.txtENLI_Notas, 7);
         this.txtENLI_Notas.Location = new System.Drawing.Point(153, 30);
         this.txtENLI_Notas.Multiline = true;
         this.txtENLI_Notas.Name = "txtENLI_Notas";
         this.tlpDatosGenerales.SetRowSpan(this.txtENLI_Notas, 2);
         this.txtENLI_Notas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.txtENLI_Notas.Size = new System.Drawing.Size(924, 48);
         this.txtENLI_Notas.TabIndex = 2;
         // 
         // errorProviderLC
         // 
         this.errorProviderLC.ContainerControl = this;
         // 
         // chkENLI_CliAutEmiCheqDiferidos
         // 
         this.chkENLI_CliAutEmiCheqDiferidos.AutoSize = true;
         this.chkENLI_CliAutEmiCheqDiferidos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.tlpDetalle.SetColumnSpan(this.chkENLI_CliAutEmiCheqDiferidos, 2);
         this.chkENLI_CliAutEmiCheqDiferidos.Location = new System.Drawing.Point(10, 88);
         this.chkENLI_CliAutEmiCheqDiferidos.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.chkENLI_CliAutEmiCheqDiferidos.Name = "chkENLI_CliAutEmiCheqDiferidos";
         this.chkENLI_CliAutEmiCheqDiferidos.Size = new System.Drawing.Size(204, 17);
         this.chkENLI_CliAutEmiCheqDiferidos.TabIndex = 2;
         this.chkENLI_CliAutEmiCheqDiferidos.Text = "Autorizado a emitir cheques diferidos :";
         this.chkENLI_CliAutEmiCheqDiferidos.UseVisualStyleBackColor = true;
         // 
         // chkENLI_CliConCredLibre
         // 
         this.chkENLI_CliConCredLibre.AutoSize = true;
         this.chkENLI_CliConCredLibre.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.tlpDetalle.SetColumnSpan(this.chkENLI_CliConCredLibre, 2);
         this.chkENLI_CliConCredLibre.Location = new System.Drawing.Point(375, 88);
         this.chkENLI_CliConCredLibre.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.chkENLI_CliConCredLibre.Name = "chkENLI_CliConCredLibre";
         this.chkENLI_CliConCredLibre.Size = new System.Drawing.Size(142, 17);
         this.chkENLI_CliConCredLibre.TabIndex = 3;
         this.chkENLI_CliConCredLibre.Text = "Cliente con credito libre :";
         this.chkENLI_CliConCredLibre.UseVisualStyleBackColor = true;
         // 
         // MAN009DViewLCredito
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(1098, 325);
         this.Controls.Add(this.tlpDatosGenerales);
         this.Controls.Add(this.panelCaption2);
         this.Controls.Add(this.tlpDetalle);
         this.Controls.Add(this.panelCaption3);
         this.Controls.Add(this.tableLayoutPanel3);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "MAN009DViewLCredito";
         this.Text = "Limite de Credito del Cliente";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         this.tlpDetalle.ResumeLayout(false);
         this.tlpDetalle.PerformLayout();
         this.tableLayoutPanel3.ResumeLayout(false);
         this.tableLayoutPanel3.PerformLayout();
         this.tlpDatosGenerales.ResumeLayout(false);
         this.tlpDatosGenerales.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderLC)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private System.Windows.Forms.TableLayoutPanel tlpDetalle;
      private System.Windows.Forms.Label lblENLI_DiasDuracion;
      private System.Windows.Forms.Label lblENLI_Fecha;
      private System.Windows.Forms.TextBox txtENLI_Codigo;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label lblENLI_FecVencimiento;
      private System.Windows.Forms.Label lblENLI_FecInicio;
      private System.Windows.Forms.Label lblENLI_Tipos;
      private Controls.Tipos.ComboBoxConstantes cmbENLI_Tipos;
      private System.Windows.Forms.Label label5;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMND;
      private System.Windows.Forms.Label label2;
      private Infrastructure.WinForms.Controls.MaskTime dtpENLI_FecVencimiento;
      private Infrastructure.WinForms.Controls.MaskTime dtpENLI_FecInicio;
      private Infrastructure.WinForms.Controls.MaskTime dtpENLI_Fecha;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnENLI_DiasDuracion;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnENLI_Monto;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private System.Windows.Forms.ComboBox cmbTIPE_CodPadre;
      private System.Windows.Forms.Label lblTIPE_CodPadre;
      private System.Windows.Forms.Label lblENTC_CodPadre;
      private Controls.EntidadDocIden txaENTC_CodPadre;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
      private System.Windows.Forms.TableLayoutPanel tlpDatosGenerales;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.TextBox txtENLI_Notas;
      private System.Windows.Forms.ErrorProvider errorProviderLC;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label lblENLI_FormaPago;
      private Controls.Tipos.ComboBoxConstantes cmbENLI_FormaPago;
      private Controls.Tipos.ComboBoxConstantes cmbTipoFechaVencimiento;
      private System.Windows.Forms.Label lblTipoFechaVencimiento;
      private System.Windows.Forms.CheckBox chkENLI_CliConCredLibre;
      private System.Windows.Forms.CheckBox chkENLI_CliAutEmiCheqDiferidos;
   }
}