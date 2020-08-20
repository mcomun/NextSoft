namespace Delfin.Principal
{
   partial class MAN015SeriesMView
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
         this.errorProviderCab_Cotizacion_OV = new System.Windows.Forms.ErrorProvider(this.components);
         this.errorProviderDet_Cotizacion_OV_Novedad = new System.Windows.Forms.ErrorProvider(this.components);
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.errorEventoTarea = new System.Windows.Forms.ErrorProvider(this.components);
         this.tableDatosGenerales = new System.Windows.Forms.TableLayoutPanel();
         this.cmbTIPO_CodTDO = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.txnSERI_NumFinal = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnSERI_NumInicial = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnSERI_MaxItems = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txtSERI_Impresora = new System.Windows.Forms.TextBox();
         this.txtSERI_Desc = new System.Windows.Forms.TextBox();
         this.txtSERI_Serie = new System.Windows.Forms.TextBox();
         this.chkSERI_Activo = new System.Windows.Forms.CheckBox();
         this.label9 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.lblSERI_Serie = new System.Windows.Forms.Label();
         this.txnSERI_UltNumero = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.lvwUnidadNegocio = new System.Windows.Forms.ListView();
         this.panel3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).BeginInit();
         this.tableDatosGenerales.SuspendLayout();
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
         this.panel3.Size = new System.Drawing.Size(735, 50);
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
         // errorProviderCab_Cotizacion_OV
         // 
         this.errorProviderCab_Cotizacion_OV.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
         this.errorProviderCab_Cotizacion_OV.ContainerControl = this;
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
         this.tableDatosGenerales.ColumnCount = 9;
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
         this.tableDatosGenerales.Controls.Add(this.cmbTIPO_CodTDO, 4, 1);
         this.tableDatosGenerales.Controls.Add(this.txnSERI_NumFinal, 4, 4);
         this.tableDatosGenerales.Controls.Add(this.txnSERI_NumInicial, 1, 4);
         this.tableDatosGenerales.Controls.Add(this.txnSERI_MaxItems, 4, 3);
         this.tableDatosGenerales.Controls.Add(this.txtSERI_Desc, 1, 2);
         this.tableDatosGenerales.Controls.Add(this.txtSERI_Serie, 1, 1);
         this.tableDatosGenerales.Controls.Add(this.chkSERI_Activo, 4, 0);
         this.tableDatosGenerales.Controls.Add(this.label6, 3, 0);
         this.tableDatosGenerales.Controls.Add(this.label5, 3, 4);
         this.tableDatosGenerales.Controls.Add(this.label4, 0, 4);
         this.tableDatosGenerales.Controls.Add(this.label3, 3, 3);
         this.tableDatosGenerales.Controls.Add(this.label2, 0, 3);
         this.tableDatosGenerales.Controls.Add(this.label1, 0, 2);
         this.tableDatosGenerales.Controls.Add(this.label10, 3, 1);
         this.tableDatosGenerales.Controls.Add(this.lblSERI_Serie, 0, 1);
         this.tableDatosGenerales.Controls.Add(this.txnSERI_UltNumero, 1, 3);
         this.tableDatosGenerales.Controls.Add(this.txtSERI_Impresora, 1, 5);
         this.tableDatosGenerales.Controls.Add(this.label9, 0, 5);
         this.tableDatosGenerales.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableDatosGenerales.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableDatosGenerales.Location = new System.Drawing.Point(0, 76);
         this.tableDatosGenerales.Name = "tableDatosGenerales";
         this.tableDatosGenerales.RowCount = 6;
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.Size = new System.Drawing.Size(735, 162);
         this.tableDatosGenerales.TabIndex = 2;
         // 
         // cmbTIPO_CodTDO
         // 
         this.cmbTIPO_CodTDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodTDO.FormattingEnabled = true;
         this.cmbTIPO_CodTDO.Location = new System.Drawing.Point(518, 30);
         this.cmbTIPO_CodTDO.Name = "cmbTIPO_CodTDO";
         this.cmbTIPO_CodTDO.Session = null;
         this.cmbTIPO_CodTDO.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodTDO.TabIndex = 5;
         this.cmbTIPO_CodTDO.TiposSelectedItem = null;
         this.cmbTIPO_CodTDO.TiposSelectedValue = null;
         this.cmbTIPO_CodTDO.TiposTitulo = null;
         // 
         // txnSERI_NumFinal
         // 
         this.txnSERI_NumFinal.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
         this.txnSERI_NumFinal.Decimales = 0;
         this.txnSERI_NumFinal.Enteros = 9;
         this.txnSERI_NumFinal.Formato = "###,###,##0.";
         this.txnSERI_NumFinal.Location = new System.Drawing.Point(518, 111);
         this.txnSERI_NumFinal.MaxLength = 10;
         this.txnSERI_NumFinal.Name = "txnSERI_NumFinal";
         this.txnSERI_NumFinal.Negativo = true;
         this.txnSERI_NumFinal.SinFormato = false;
         this.txnSERI_NumFinal.Size = new System.Drawing.Size(194, 20);
         this.txnSERI_NumFinal.TabIndex = 15;
         this.txnSERI_NumFinal.Text = "0";
         this.txnSERI_NumFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnSERI_NumFinal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // txnSERI_NumInicial
         // 
         this.txnSERI_NumInicial.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
         this.txnSERI_NumInicial.Decimales = 0;
         this.txnSERI_NumInicial.Enteros = 9;
         this.txnSERI_NumInicial.Formato = "###,###,##0.";
         this.txnSERI_NumInicial.Location = new System.Drawing.Point(153, 111);
         this.txnSERI_NumInicial.MaxLength = 10;
         this.txnSERI_NumInicial.Name = "txnSERI_NumInicial";
         this.txnSERI_NumInicial.Negativo = true;
         this.txnSERI_NumInicial.SinFormato = false;
         this.txnSERI_NumInicial.Size = new System.Drawing.Size(194, 20);
         this.txnSERI_NumInicial.TabIndex = 13;
         this.txnSERI_NumInicial.Text = "0";
         this.txnSERI_NumInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnSERI_NumInicial.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // txnSERI_MaxItems
         // 
         this.txnSERI_MaxItems.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
         this.txnSERI_MaxItems.Decimales = 0;
         this.txnSERI_MaxItems.Enteros = 9;
         this.txnSERI_MaxItems.Formato = "###,###,##0.";
         this.txnSERI_MaxItems.Location = new System.Drawing.Point(518, 84);
         this.txnSERI_MaxItems.MaxLength = 10;
         this.txnSERI_MaxItems.Name = "txnSERI_MaxItems";
         this.txnSERI_MaxItems.Negativo = true;
         this.txnSERI_MaxItems.SinFormato = false;
         this.txnSERI_MaxItems.Size = new System.Drawing.Size(194, 20);
         this.txnSERI_MaxItems.TabIndex = 11;
         this.txnSERI_MaxItems.Text = "0";
         this.txnSERI_MaxItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnSERI_MaxItems.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // txtSERI_Impresora
         // 
         this.tableDatosGenerales.SetColumnSpan(this.txtSERI_Impresora, 4);
         this.txtSERI_Impresora.Location = new System.Drawing.Point(153, 138);
         this.txtSERI_Impresora.Name = "txtSERI_Impresora";
         this.txtSERI_Impresora.Size = new System.Drawing.Size(559, 20);
         this.txtSERI_Impresora.TabIndex = 21;
         // 
         // txtSERI_Desc
         // 
         this.tableDatosGenerales.SetColumnSpan(this.txtSERI_Desc, 4);
         this.txtSERI_Desc.Location = new System.Drawing.Point(153, 57);
         this.txtSERI_Desc.Name = "txtSERI_Desc";
         this.txtSERI_Desc.Size = new System.Drawing.Size(559, 20);
         this.txtSERI_Desc.TabIndex = 7;
         // 
         // txtSERI_Serie
         // 
         this.txtSERI_Serie.Location = new System.Drawing.Point(153, 30);
         this.txtSERI_Serie.Name = "txtSERI_Serie";
         this.txtSERI_Serie.Size = new System.Drawing.Size(194, 20);
         this.txtSERI_Serie.TabIndex = 3;
         // 
         // chkSERI_Activo
         // 
         this.chkSERI_Activo.AutoSize = true;
         this.chkSERI_Activo.Location = new System.Drawing.Point(518, 3);
         this.chkSERI_Activo.Name = "chkSERI_Activo";
         this.chkSERI_Activo.Padding = new System.Windows.Forms.Padding(5);
         this.chkSERI_Activo.Size = new System.Drawing.Size(25, 21);
         this.chkSERI_Activo.TabIndex = 1;
         this.chkSERI_Activo.UseVisualStyleBackColor = true;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label9.Location = new System.Drawing.Point(10, 142);
         this.label9.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(76, 13);
         this.label9.TabIndex = 20;
         this.label9.Text = "Impresora :";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(375, 7);
         this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(51, 13);
         this.label6.TabIndex = 0;
         this.label6.Text = "Activo :";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(375, 115);
         this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(91, 13);
         this.label5.TabIndex = 14;
         this.label5.Text = "Número Final :";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(10, 115);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(99, 13);
         this.label4.TabIndex = 12;
         this.label4.Text = "Número Inicial :";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(375, 88);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(125, 13);
         this.label3.TabIndex = 10;
         this.label3.Text = "Maximo Nro. Items :";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(10, 88);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(101, 13);
         this.label2.TabIndex = 8;
         this.label2.Text = "Ultimo Número :";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 61);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(82, 13);
         this.label1.TabIndex = 6;
         this.label1.Text = "Descripción :";
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label10.Location = new System.Drawing.Point(375, 34);
         this.label10.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(109, 13);
         this.label10.TabIndex = 4;
         this.label10.Text = "Tipo Documento :";
         // 
         // lblSERI_Serie
         // 
         this.lblSERI_Serie.AutoSize = true;
         this.lblSERI_Serie.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblSERI_Serie.Location = new System.Drawing.Point(10, 34);
         this.lblSERI_Serie.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblSERI_Serie.Name = "lblSERI_Serie";
         this.lblSERI_Serie.Size = new System.Drawing.Size(46, 13);
         this.lblSERI_Serie.TabIndex = 2;
         this.lblSERI_Serie.Text = "Serie :";
         // 
         // txnSERI_UltNumero
         // 
         this.txnSERI_UltNumero.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
         this.txnSERI_UltNumero.Decimales = 0;
         this.txnSERI_UltNumero.Enteros = 9;
         this.txnSERI_UltNumero.Formato = "###,###,##0.";
         this.txnSERI_UltNumero.Location = new System.Drawing.Point(153, 84);
         this.txnSERI_UltNumero.MaxLength = 10;
         this.txnSERI_UltNumero.Name = "txnSERI_UltNumero";
         this.txnSERI_UltNumero.Negativo = true;
         this.txnSERI_UltNumero.SinFormato = false;
         this.txnSERI_UltNumero.Size = new System.Drawing.Size(194, 20);
         this.txnSERI_UltNumero.TabIndex = 9;
         this.txnSERI_UltNumero.Text = "0";
         this.txnSERI_UltNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnSERI_UltNumero.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Datos Generales";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 50);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(735, 26);
         this.panelCaption1.TabIndex = 1;
         // 
         // panelCaption2
         // 
         this.panelCaption2.AllowActive = false;
         this.panelCaption2.AntiAlias = false;
         this.panelCaption2.Caption = "Unidad de Negocio";
         this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption2.Location = new System.Drawing.Point(0, 238);
         this.panelCaption2.Name = "panelCaption2";
         this.panelCaption2.Size = new System.Drawing.Size(735, 26);
         this.panelCaption2.TabIndex = 3;
         // 
         // lvwUnidadNegocio
         // 
         this.lvwUnidadNegocio.Dock = System.Windows.Forms.DockStyle.Fill;
         this.lvwUnidadNegocio.Location = new System.Drawing.Point(0, 264);
         this.lvwUnidadNegocio.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
         this.lvwUnidadNegocio.Name = "lvwUnidadNegocio";
         this.lvwUnidadNegocio.Size = new System.Drawing.Size(735, 41);
         this.lvwUnidadNegocio.TabIndex = 4;
         this.lvwUnidadNegocio.UseCompatibleStateImageBehavior = false;
         // 
         // MAN015SeriesMView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.CancelButton = this.btnSalir;
         this.ClientSize = new System.Drawing.Size(735, 305);
         this.Controls.Add(this.lvwUnidadNegocio);
         this.Controls.Add(this.panelCaption2);
         this.Controls.Add(this.tableDatosGenerales);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Name = "MAN015SeriesMView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Series";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).EndInit();
         this.tableDatosGenerales.ResumeLayout(false);
         this.tableDatosGenerales.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }



      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private System.Windows.Forms.ErrorProvider errorProviderCab_Cotizacion_OV;
      private System.Windows.Forms.ErrorProvider errorProviderDet_Cotizacion_OV_Novedad;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.ErrorProvider errorEventoTarea;
      private System.Windows.Forms.TableLayoutPanel tableDatosGenerales;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Label lblSERI_Serie;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodTDO;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnSERI_NumFinal;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnSERI_NumInicial;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnSERI_MaxItems;
      private System.Windows.Forms.TextBox txtSERI_Impresora;
      private System.Windows.Forms.TextBox txtSERI_Desc;
      private System.Windows.Forms.TextBox txtSERI_Serie;
      private System.Windows.Forms.CheckBox chkSERI_Activo;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnSERI_UltNumero;
      private System.Windows.Forms.ListView lvwUnidadNegocio;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
   }
}