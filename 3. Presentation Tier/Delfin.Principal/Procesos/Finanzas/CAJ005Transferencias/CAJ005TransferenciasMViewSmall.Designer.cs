namespace Delfin.Principal
{
   partial class CAJ005TransferenciasMViewSmall
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
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableDatosGenerales = new System.Windows.Forms.TableLayoutPanel();
         this.txtTRAN_Codigo = new System.Windows.Forms.TextBox();
         this.lblTRAN_Codigo = new System.Windows.Forms.Label();
         this.lblTRAN_Glosa = new System.Windows.Forms.Label();
         this.lblTRAN_Fecha = new System.Windows.Forms.Label();
         this.dtpTRAN_Fecha = new Infrastructure.WinForms.Controls.MaskTime();
         this.txtTRAN_Glosa = new System.Windows.Forms.TextBox();
         this.panelCaption4 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
         this.txnGBAN_TipoCambio = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnMOVI_TipoCambioEgresos = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnMOVI_TipoCambioIngresos = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.cmbTIPO_CodMNDGBancario = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.cmbTIPO_CodMNDEgresos = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.btnCalcular = new System.Windows.Forms.Button();
         this.cmbTIPO_CodMNDIngresos = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.label12 = new System.Windows.Forms.Label();
         this.txaCUBA_NroCuentaEgresos = new Delfin.Controls.CuentaBancaria(this.components);
         this.txaCUBA_NroCuentaIngresos = new Delfin.Controls.CuentaBancaria(this.components);
         this.label5 = new System.Windows.Forms.Label();
         this.txnDiferenciaHDol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnDiferenciaDDol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnDiferenciaHSol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnDiferenciaDSol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnTotalHDol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnTotalDDol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnTotalHSol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnGBancarioDSol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnGBancarioHSol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnGBancarioDDol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnGBancarioHDol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnEgresosHDol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnIngresosHDol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnIngresosDDol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.label10 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.txnEgresosDSol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.label3 = new System.Windows.Forms.Label();
         this.txnIngresosDSol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.label1 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.txnIngresosHSol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnEgresosHSol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.label9 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label11 = new System.Windows.Forms.Label();
         this.txnTotalDSol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnEgresosDDol = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.label2 = new System.Windows.Forms.Label();
         this.lblDiferencia = new System.Windows.Forms.Label();
         this.label13 = new System.Windows.Forms.Label();
         this.errorProviderTransferencia = new System.Windows.Forms.ErrorProvider(this.components);
         this.panel3.SuspendLayout();
         this.tableDatosGenerales.SuspendLayout();
         this.tableLayoutPanel3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderTransferencia)).BeginInit();
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
         this.panel3.Size = new System.Drawing.Size(1100, 50);
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
         this.btnGuardar.Text = "&Guardar";
         this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnGuardar.UseVisualStyleBackColor = true;
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
         this.panelCaption1.Size = new System.Drawing.Size(1100, 26);
         this.panelCaption1.TabIndex = 1;
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
         this.tableDatosGenerales.Controls.Add(this.txtTRAN_Codigo, 1, 0);
         this.tableDatosGenerales.Controls.Add(this.lblTRAN_Codigo, 0, 0);
         this.tableDatosGenerales.Controls.Add(this.lblTRAN_Glosa, 3, 0);
         this.tableDatosGenerales.Controls.Add(this.lblTRAN_Fecha, 0, 1);
         this.tableDatosGenerales.Controls.Add(this.dtpTRAN_Fecha, 1, 1);
         this.tableDatosGenerales.Controls.Add(this.txtTRAN_Glosa, 4, 0);
         this.tableDatosGenerales.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableDatosGenerales.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableDatosGenerales.Location = new System.Drawing.Point(0, 76);
         this.tableDatosGenerales.Name = "tableDatosGenerales";
         this.tableDatosGenerales.RowCount = 2;
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.Size = new System.Drawing.Size(1100, 54);
         this.tableDatosGenerales.TabIndex = 2;
         // 
         // txtTRAN_Codigo
         // 
         this.txtTRAN_Codigo.Location = new System.Drawing.Point(153, 3);
         this.txtTRAN_Codigo.Name = "txtTRAN_Codigo";
         this.txtTRAN_Codigo.Size = new System.Drawing.Size(194, 20);
         this.txtTRAN_Codigo.TabIndex = 1;
         // 
         // lblTRAN_Codigo
         // 
         this.lblTRAN_Codigo.AutoSize = true;
         this.lblTRAN_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTRAN_Codigo.Location = new System.Drawing.Point(10, 7);
         this.lblTRAN_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTRAN_Codigo.Name = "lblTRAN_Codigo";
         this.lblTRAN_Codigo.Size = new System.Drawing.Size(86, 13);
         this.lblTRAN_Codigo.TabIndex = 0;
         this.lblTRAN_Codigo.Text = "Nro. Interno :";
         // 
         // lblTRAN_Glosa
         // 
         this.lblTRAN_Glosa.AutoSize = true;
         this.lblTRAN_Glosa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTRAN_Glosa.Location = new System.Drawing.Point(375, 7);
         this.lblTRAN_Glosa.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTRAN_Glosa.Name = "lblTRAN_Glosa";
         this.lblTRAN_Glosa.Size = new System.Drawing.Size(48, 13);
         this.lblTRAN_Glosa.TabIndex = 4;
         this.lblTRAN_Glosa.Text = "Glosa :";
         // 
         // lblTRAN_Fecha
         // 
         this.lblTRAN_Fecha.AutoSize = true;
         this.lblTRAN_Fecha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTRAN_Fecha.Location = new System.Drawing.Point(10, 34);
         this.lblTRAN_Fecha.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTRAN_Fecha.Name = "lblTRAN_Fecha";
         this.lblTRAN_Fecha.Size = new System.Drawing.Size(49, 13);
         this.lblTRAN_Fecha.TabIndex = 2;
         this.lblTRAN_Fecha.Text = "Fecha :";
         // 
         // dtpTRAN_Fecha
         // 
         this.dtpTRAN_Fecha.Location = new System.Drawing.Point(153, 30);
         this.dtpTRAN_Fecha.MinimumSize = new System.Drawing.Size(100, 22);
         this.dtpTRAN_Fecha.Name = "dtpTRAN_Fecha";
         this.dtpTRAN_Fecha.NSActiveMouse = false;
         this.dtpTRAN_Fecha.NSActiveMsgFecha = false;
         this.dtpTRAN_Fecha.NSChangeDate = true;
         this.dtpTRAN_Fecha.NSDigitos = 4;
         this.dtpTRAN_Fecha.NSFecha = null;
         this.dtpTRAN_Fecha.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.dtpTRAN_Fecha.NSSetDateNow = false;
         this.dtpTRAN_Fecha.Size = new System.Drawing.Size(100, 22);
         this.dtpTRAN_Fecha.TabIndex = 3;
         // 
         // txtTRAN_Glosa
         // 
         this.tableDatosGenerales.SetColumnSpan(this.txtTRAN_Glosa, 4);
         this.txtTRAN_Glosa.Location = new System.Drawing.Point(518, 3);
         this.txtTRAN_Glosa.Multiline = true;
         this.txtTRAN_Glosa.Name = "txtTRAN_Glosa";
         this.tableDatosGenerales.SetRowSpan(this.txtTRAN_Glosa, 2);
         this.txtTRAN_Glosa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.txtTRAN_Glosa.Size = new System.Drawing.Size(559, 48);
         this.txtTRAN_Glosa.TabIndex = 5;
         // 
         // panelCaption4
         // 
         this.panelCaption4.AllowActive = false;
         this.panelCaption4.AntiAlias = false;
         this.panelCaption4.Caption = "Resumen";
         this.panelCaption4.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption4.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption4.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption4.Location = new System.Drawing.Point(0, 130);
         this.panelCaption4.Name = "panelCaption4";
         this.panelCaption4.Size = new System.Drawing.Size(1100, 26);
         this.panelCaption4.TabIndex = 3;
         // 
         // tableLayoutPanel3
         // 
         this.tableLayoutPanel3.AutoSize = true;
         this.tableLayoutPanel3.ColumnCount = 17;
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.Controls.Add(this.txnGBAN_TipoCambio, 13, 4);
         this.tableLayoutPanel3.Controls.Add(this.txnMOVI_TipoCambioEgresos, 13, 3);
         this.tableLayoutPanel3.Controls.Add(this.txnMOVI_TipoCambioIngresos, 13, 2);
         this.tableLayoutPanel3.Controls.Add(this.cmbTIPO_CodMNDGBancario, 3, 4);
         this.tableLayoutPanel3.Controls.Add(this.cmbTIPO_CodMNDEgresos, 3, 3);
         this.tableLayoutPanel3.Controls.Add(this.btnCalcular, 0, 0);
         this.tableLayoutPanel3.Controls.Add(this.cmbTIPO_CodMNDIngresos, 3, 2);
         this.tableLayoutPanel3.Controls.Add(this.label12, 3, 1);
         this.tableLayoutPanel3.Controls.Add(this.txaCUBA_NroCuentaEgresos, 1, 3);
         this.tableLayoutPanel3.Controls.Add(this.txaCUBA_NroCuentaIngresos, 1, 2);
         this.tableLayoutPanel3.Controls.Add(this.label5, 1, 1);
         this.tableLayoutPanel3.Controls.Add(this.txnDiferenciaHDol, 11, 6);
         this.tableLayoutPanel3.Controls.Add(this.txnDiferenciaDDol, 9, 6);
         this.tableLayoutPanel3.Controls.Add(this.txnDiferenciaHSol, 7, 6);
         this.tableLayoutPanel3.Controls.Add(this.txnDiferenciaDSol, 5, 6);
         this.tableLayoutPanel3.Controls.Add(this.txnTotalHDol, 11, 5);
         this.tableLayoutPanel3.Controls.Add(this.txnTotalDDol, 9, 5);
         this.tableLayoutPanel3.Controls.Add(this.txnTotalHSol, 7, 5);
         this.tableLayoutPanel3.Controls.Add(this.txnGBancarioDSol, 5, 4);
         this.tableLayoutPanel3.Controls.Add(this.txnGBancarioHSol, 7, 4);
         this.tableLayoutPanel3.Controls.Add(this.txnGBancarioDDol, 9, 4);
         this.tableLayoutPanel3.Controls.Add(this.txnGBancarioHDol, 11, 4);
         this.tableLayoutPanel3.Controls.Add(this.txnEgresosHDol, 11, 3);
         this.tableLayoutPanel3.Controls.Add(this.txnIngresosHDol, 11, 2);
         this.tableLayoutPanel3.Controls.Add(this.txnIngresosDDol, 9, 2);
         this.tableLayoutPanel3.Controls.Add(this.label10, 5, 0);
         this.tableLayoutPanel3.Controls.Add(this.label7, 7, 1);
         this.tableLayoutPanel3.Controls.Add(this.label6, 5, 1);
         this.tableLayoutPanel3.Controls.Add(this.txnEgresosDSol, 5, 3);
         this.tableLayoutPanel3.Controls.Add(this.label3, 0, 3);
         this.tableLayoutPanel3.Controls.Add(this.txnIngresosDSol, 5, 2);
         this.tableLayoutPanel3.Controls.Add(this.label1, 0, 2);
         this.tableLayoutPanel3.Controls.Add(this.label4, 0, 4);
         this.tableLayoutPanel3.Controls.Add(this.txnIngresosHSol, 7, 2);
         this.tableLayoutPanel3.Controls.Add(this.txnEgresosHSol, 7, 3);
         this.tableLayoutPanel3.Controls.Add(this.label9, 11, 1);
         this.tableLayoutPanel3.Controls.Add(this.label8, 9, 1);
         this.tableLayoutPanel3.Controls.Add(this.label11, 9, 0);
         this.tableLayoutPanel3.Controls.Add(this.txnTotalDSol, 5, 5);
         this.tableLayoutPanel3.Controls.Add(this.txnEgresosDDol, 9, 3);
         this.tableLayoutPanel3.Controls.Add(this.label2, 3, 5);
         this.tableLayoutPanel3.Controls.Add(this.lblDiferencia, 3, 6);
         this.tableLayoutPanel3.Controls.Add(this.label13, 13, 0);
         this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 156);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 7;
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.Size = new System.Drawing.Size(1100, 189);
         this.tableLayoutPanel3.TabIndex = 4;
         // 
         // txnGBAN_TipoCambio
         // 
         this.txnGBAN_TipoCambio.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnGBAN_TipoCambio.Decimales = 4;
         this.txnGBAN_TipoCambio.Enteros = 9;
         this.txnGBAN_TipoCambio.Formato = "###,###,##0.0000";
         this.txnGBAN_TipoCambio.Location = new System.Drawing.Point(998, 111);
         this.txnGBAN_TipoCambio.MaxLength = 15;
         this.txnGBAN_TipoCambio.Name = "txnGBAN_TipoCambio";
         this.txnGBAN_TipoCambio.Negativo = true;
         this.txnGBAN_TipoCambio.SinFormato = false;
         this.txnGBAN_TipoCambio.Size = new System.Drawing.Size(79, 20);
         this.txnGBAN_TipoCambio.TabIndex = 32;
         this.txnGBAN_TipoCambio.Text = "0.0000";
         this.txnGBAN_TipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnGBAN_TipoCambio.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnMOVI_TipoCambioEgresos
         // 
         this.txnMOVI_TipoCambioEgresos.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnMOVI_TipoCambioEgresos.Decimales = 4;
         this.txnMOVI_TipoCambioEgresos.Enteros = 9;
         this.txnMOVI_TipoCambioEgresos.Formato = "###,###,##0.0000";
         this.txnMOVI_TipoCambioEgresos.Location = new System.Drawing.Point(998, 84);
         this.txnMOVI_TipoCambioEgresos.MaxLength = 15;
         this.txnMOVI_TipoCambioEgresos.Name = "txnMOVI_TipoCambioEgresos";
         this.txnMOVI_TipoCambioEgresos.Negativo = true;
         this.txnMOVI_TipoCambioEgresos.SinFormato = false;
         this.txnMOVI_TipoCambioEgresos.Size = new System.Drawing.Size(79, 20);
         this.txnMOVI_TipoCambioEgresos.TabIndex = 24;
         this.txnMOVI_TipoCambioEgresos.Text = "0.0000";
         this.txnMOVI_TipoCambioEgresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnMOVI_TipoCambioEgresos.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnMOVI_TipoCambioIngresos
         // 
         this.txnMOVI_TipoCambioIngresos.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnMOVI_TipoCambioIngresos.Decimales = 4;
         this.txnMOVI_TipoCambioIngresos.Enteros = 9;
         this.txnMOVI_TipoCambioIngresos.Formato = "###,###,##0.0000";
         this.txnMOVI_TipoCambioIngresos.Location = new System.Drawing.Point(998, 57);
         this.txnMOVI_TipoCambioIngresos.MaxLength = 15;
         this.txnMOVI_TipoCambioIngresos.Name = "txnMOVI_TipoCambioIngresos";
         this.txnMOVI_TipoCambioIngresos.Negativo = true;
         this.txnMOVI_TipoCambioIngresos.SinFormato = false;
         this.txnMOVI_TipoCambioIngresos.Size = new System.Drawing.Size(79, 20);
         this.txnMOVI_TipoCambioIngresos.TabIndex = 16;
         this.txnMOVI_TipoCambioIngresos.Text = "0.0000";
         this.txnMOVI_TipoCambioIngresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnMOVI_TipoCambioIngresos.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // cmbTIPO_CodMNDGBancario
         // 
         this.cmbTIPO_CodMNDGBancario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodMNDGBancario.FormattingEnabled = true;
         this.cmbTIPO_CodMNDGBancario.Location = new System.Drawing.Point(363, 111);
         this.cmbTIPO_CodMNDGBancario.Name = "cmbTIPO_CodMNDGBancario";
         this.cmbTIPO_CodMNDGBancario.Session = null;
         this.cmbTIPO_CodMNDGBancario.Size = new System.Drawing.Size(94, 21);
         this.cmbTIPO_CodMNDGBancario.TabIndex = 27;
         this.cmbTIPO_CodMNDGBancario.TiposSelectedItem = null;
         this.cmbTIPO_CodMNDGBancario.TiposSelectedValue = null;
         this.cmbTIPO_CodMNDGBancario.TiposTitulo = null;
         // 
         // cmbTIPO_CodMNDEgresos
         // 
         this.cmbTIPO_CodMNDEgresos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodMNDEgresos.FormattingEnabled = true;
         this.cmbTIPO_CodMNDEgresos.Location = new System.Drawing.Point(363, 84);
         this.cmbTIPO_CodMNDEgresos.Name = "cmbTIPO_CodMNDEgresos";
         this.cmbTIPO_CodMNDEgresos.Session = null;
         this.cmbTIPO_CodMNDEgresos.Size = new System.Drawing.Size(94, 21);
         this.cmbTIPO_CodMNDEgresos.TabIndex = 19;
         this.cmbTIPO_CodMNDEgresos.TiposSelectedItem = null;
         this.cmbTIPO_CodMNDEgresos.TiposSelectedValue = null;
         this.cmbTIPO_CodMNDEgresos.TiposTitulo = null;
         // 
         // btnCalcular
         // 
         this.btnCalcular.Image = global::Delfin.Principal.Properties.Resources.calculator_16x16;
         this.btnCalcular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnCalcular.Location = new System.Drawing.Point(0, 0);
         this.btnCalcular.Margin = new System.Windows.Forms.Padding(0);
         this.btnCalcular.Name = "btnCalcular";
         this.btnCalcular.Size = new System.Drawing.Size(150, 27);
         this.btnCalcular.TabIndex = 9;
         this.btnCalcular.Text = "Calcular";
         this.btnCalcular.UseVisualStyleBackColor = true;
         // 
         // cmbTIPO_CodMNDIngresos
         // 
         this.cmbTIPO_CodMNDIngresos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodMNDIngresos.FormattingEnabled = true;
         this.cmbTIPO_CodMNDIngresos.Location = new System.Drawing.Point(363, 57);
         this.cmbTIPO_CodMNDIngresos.Name = "cmbTIPO_CodMNDIngresos";
         this.cmbTIPO_CodMNDIngresos.Session = null;
         this.cmbTIPO_CodMNDIngresos.Size = new System.Drawing.Size(94, 21);
         this.cmbTIPO_CodMNDIngresos.TabIndex = 11;
         this.cmbTIPO_CodMNDIngresos.TiposSelectedItem = null;
         this.cmbTIPO_CodMNDIngresos.TiposSelectedValue = null;
         this.cmbTIPO_CodMNDIngresos.TiposTitulo = null;
         // 
         // label12
         // 
         this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label12.Location = new System.Drawing.Point(370, 34);
         this.label12.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(87, 13);
         this.label12.TabIndex = 4;
         this.label12.Text = "Moneda";
         this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // txaCUBA_NroCuentaEgresos
         // 
         this.txaCUBA_NroCuentaEgresos.ActivarAyudaAuto = false;
         this.txaCUBA_NroCuentaEgresos.BackColor = System.Drawing.Color.White;
         this.txaCUBA_NroCuentaEgresos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
         this.txaCUBA_NroCuentaEgresos.EMPR_Codigo = ((short)(0));
         this.txaCUBA_NroCuentaEgresos.EnabledAyuda = true;
         this.txaCUBA_NroCuentaEgresos.EnabledAyudaButton = true;
         this.txaCUBA_NroCuentaEgresos.EsFiltro = false;
         this.txaCUBA_NroCuentaEgresos.Location = new System.Drawing.Point(153, 84);
         this.txaCUBA_NroCuentaEgresos.LongitudAceptada = 0;
         this.txaCUBA_NroCuentaEgresos.MaxLength = 100;
         this.txaCUBA_NroCuentaEgresos.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
         this.txaCUBA_NroCuentaEgresos.Name = "txaCUBA_NroCuentaEgresos";
         this.txaCUBA_NroCuentaEgresos.RellenaCeros = false;
         this.txaCUBA_NroCuentaEgresos.SelectedItem = null;
         this.txaCUBA_NroCuentaEgresos.Size = new System.Drawing.Size(194, 20);
         this.txaCUBA_NroCuentaEgresos.TabIndex = 18;
         this.txaCUBA_NroCuentaEgresos.TAyuda = Delfin.Controls.CuentaBancaria.TipoAyuda.Normal;
         this.txaCUBA_NroCuentaEgresos.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
         this.txaCUBA_NroCuentaEgresos.Usuario = null;
         this.txaCUBA_NroCuentaEgresos.Value = null;
         // 
         // txaCUBA_NroCuentaIngresos
         // 
         this.txaCUBA_NroCuentaIngresos.ActivarAyudaAuto = false;
         this.txaCUBA_NroCuentaIngresos.BackColor = System.Drawing.Color.White;
         this.txaCUBA_NroCuentaIngresos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
         this.txaCUBA_NroCuentaIngresos.EMPR_Codigo = ((short)(0));
         this.txaCUBA_NroCuentaIngresos.EnabledAyuda = true;
         this.txaCUBA_NroCuentaIngresos.EnabledAyudaButton = true;
         this.txaCUBA_NroCuentaIngresos.EsFiltro = false;
         this.txaCUBA_NroCuentaIngresos.Location = new System.Drawing.Point(153, 57);
         this.txaCUBA_NroCuentaIngresos.LongitudAceptada = 0;
         this.txaCUBA_NroCuentaIngresos.MaxLength = 100;
         this.txaCUBA_NroCuentaIngresos.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
         this.txaCUBA_NroCuentaIngresos.Name = "txaCUBA_NroCuentaIngresos";
         this.txaCUBA_NroCuentaIngresos.RellenaCeros = false;
         this.txaCUBA_NroCuentaIngresos.SelectedItem = null;
         this.txaCUBA_NroCuentaIngresos.Size = new System.Drawing.Size(194, 20);
         this.txaCUBA_NroCuentaIngresos.TabIndex = 10;
         this.txaCUBA_NroCuentaIngresos.TAyuda = Delfin.Controls.CuentaBancaria.TipoAyuda.Normal;
         this.txaCUBA_NroCuentaIngresos.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
         this.txaCUBA_NroCuentaIngresos.Usuario = null;
         this.txaCUBA_NroCuentaIngresos.Value = null;
         // 
         // label5
         // 
         this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(160, 34);
         this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(187, 13);
         this.label5.TabIndex = 3;
         this.label5.Text = "Cuenta Bancaria";
         this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // txnDiferenciaHDol
         // 
         this.txnDiferenciaHDol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnDiferenciaHDol.Decimales = 2;
         this.txnDiferenciaHDol.Enteros = 9;
         this.txnDiferenciaHDol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txnDiferenciaHDol.ForeColor = System.Drawing.Color.DarkRed;
         this.txnDiferenciaHDol.Formato = "###,###,##0.00";
         this.txnDiferenciaHDol.Location = new System.Drawing.Point(868, 165);
         this.txnDiferenciaHDol.MaxLength = 13;
         this.txnDiferenciaHDol.Name = "txnDiferenciaHDol";
         this.txnDiferenciaHDol.Negativo = true;
         this.txnDiferenciaHDol.SinFormato = false;
         this.txnDiferenciaHDol.Size = new System.Drawing.Size(109, 20);
         this.txnDiferenciaHDol.TabIndex = 42;
         this.txnDiferenciaHDol.Text = "0.00";
         this.txnDiferenciaHDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnDiferenciaHDol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnDiferenciaDDol
         // 
         this.txnDiferenciaDDol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnDiferenciaDDol.Decimales = 2;
         this.txnDiferenciaDDol.Enteros = 9;
         this.txnDiferenciaDDol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txnDiferenciaDDol.ForeColor = System.Drawing.Color.DarkRed;
         this.txnDiferenciaDDol.Formato = "###,###,##0.00";
         this.txnDiferenciaDDol.Location = new System.Drawing.Point(738, 165);
         this.txnDiferenciaDDol.MaxLength = 13;
         this.txnDiferenciaDDol.Name = "txnDiferenciaDDol";
         this.txnDiferenciaDDol.Negativo = true;
         this.txnDiferenciaDDol.SinFormato = false;
         this.txnDiferenciaDDol.Size = new System.Drawing.Size(109, 20);
         this.txnDiferenciaDDol.TabIndex = 41;
         this.txnDiferenciaDDol.Text = "0.00";
         this.txnDiferenciaDDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnDiferenciaDDol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnDiferenciaHSol
         // 
         this.txnDiferenciaHSol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnDiferenciaHSol.Decimales = 2;
         this.txnDiferenciaHSol.Enteros = 9;
         this.txnDiferenciaHSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txnDiferenciaHSol.ForeColor = System.Drawing.Color.DarkRed;
         this.txnDiferenciaHSol.Formato = "###,###,##0.00";
         this.txnDiferenciaHSol.Location = new System.Drawing.Point(608, 165);
         this.txnDiferenciaHSol.MaxLength = 13;
         this.txnDiferenciaHSol.Name = "txnDiferenciaHSol";
         this.txnDiferenciaHSol.Negativo = true;
         this.txnDiferenciaHSol.SinFormato = false;
         this.txnDiferenciaHSol.Size = new System.Drawing.Size(109, 20);
         this.txnDiferenciaHSol.TabIndex = 40;
         this.txnDiferenciaHSol.Text = "0.00";
         this.txnDiferenciaHSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnDiferenciaHSol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnDiferenciaDSol
         // 
         this.txnDiferenciaDSol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnDiferenciaDSol.Decimales = 2;
         this.txnDiferenciaDSol.Enteros = 9;
         this.txnDiferenciaDSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txnDiferenciaDSol.ForeColor = System.Drawing.Color.DarkRed;
         this.txnDiferenciaDSol.Formato = "###,###,##0.00";
         this.txnDiferenciaDSol.Location = new System.Drawing.Point(478, 165);
         this.txnDiferenciaDSol.MaxLength = 13;
         this.txnDiferenciaDSol.Name = "txnDiferenciaDSol";
         this.txnDiferenciaDSol.Negativo = true;
         this.txnDiferenciaDSol.SinFormato = false;
         this.txnDiferenciaDSol.Size = new System.Drawing.Size(109, 20);
         this.txnDiferenciaDSol.TabIndex = 39;
         this.txnDiferenciaDSol.Text = "0.00";
         this.txnDiferenciaDSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnDiferenciaDSol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnTotalHDol
         // 
         this.txnTotalHDol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnTotalHDol.Decimales = 2;
         this.txnTotalHDol.Enteros = 9;
         this.txnTotalHDol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txnTotalHDol.Formato = "###,###,##0.00";
         this.txnTotalHDol.Location = new System.Drawing.Point(868, 138);
         this.txnTotalHDol.MaxLength = 13;
         this.txnTotalHDol.Name = "txnTotalHDol";
         this.txnTotalHDol.Negativo = true;
         this.txnTotalHDol.SinFormato = false;
         this.txnTotalHDol.Size = new System.Drawing.Size(109, 20);
         this.txnTotalHDol.TabIndex = 37;
         this.txnTotalHDol.Text = "0.00";
         this.txnTotalHDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnTotalHDol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnTotalDDol
         // 
         this.txnTotalDDol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnTotalDDol.Decimales = 2;
         this.txnTotalDDol.Enteros = 9;
         this.txnTotalDDol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txnTotalDDol.Formato = "###,###,##0.00";
         this.txnTotalDDol.Location = new System.Drawing.Point(738, 138);
         this.txnTotalDDol.MaxLength = 13;
         this.txnTotalDDol.Name = "txnTotalDDol";
         this.txnTotalDDol.Negativo = true;
         this.txnTotalDDol.SinFormato = false;
         this.txnTotalDDol.Size = new System.Drawing.Size(109, 20);
         this.txnTotalDDol.TabIndex = 36;
         this.txnTotalDDol.Text = "0.00";
         this.txnTotalDDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnTotalDDol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnTotalHSol
         // 
         this.txnTotalHSol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnTotalHSol.Decimales = 2;
         this.txnTotalHSol.Enteros = 9;
         this.txnTotalHSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txnTotalHSol.Formato = "###,###,##0.00";
         this.txnTotalHSol.Location = new System.Drawing.Point(608, 138);
         this.txnTotalHSol.MaxLength = 13;
         this.txnTotalHSol.Name = "txnTotalHSol";
         this.txnTotalHSol.Negativo = true;
         this.txnTotalHSol.SinFormato = false;
         this.txnTotalHSol.Size = new System.Drawing.Size(109, 20);
         this.txnTotalHSol.TabIndex = 35;
         this.txnTotalHSol.Text = "0.00";
         this.txnTotalHSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnTotalHSol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnGBancarioDSol
         // 
         this.txnGBancarioDSol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnGBancarioDSol.Decimales = 2;
         this.txnGBancarioDSol.Enteros = 9;
         this.txnGBancarioDSol.Formato = "###,###,##0.00";
         this.txnGBancarioDSol.Location = new System.Drawing.Point(478, 111);
         this.txnGBancarioDSol.MaxLength = 13;
         this.txnGBancarioDSol.Name = "txnGBancarioDSol";
         this.txnGBancarioDSol.Negativo = true;
         this.txnGBancarioDSol.SinFormato = false;
         this.txnGBancarioDSol.Size = new System.Drawing.Size(109, 20);
         this.txnGBancarioDSol.TabIndex = 28;
         this.txnGBancarioDSol.Text = "0.00";
         this.txnGBancarioDSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnGBancarioDSol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnGBancarioHSol
         // 
         this.txnGBancarioHSol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnGBancarioHSol.Decimales = 2;
         this.txnGBancarioHSol.Enteros = 9;
         this.txnGBancarioHSol.Formato = "###,###,##0.00";
         this.txnGBancarioHSol.Location = new System.Drawing.Point(608, 111);
         this.txnGBancarioHSol.MaxLength = 13;
         this.txnGBancarioHSol.Name = "txnGBancarioHSol";
         this.txnGBancarioHSol.Negativo = true;
         this.txnGBancarioHSol.SinFormato = false;
         this.txnGBancarioHSol.Size = new System.Drawing.Size(109, 20);
         this.txnGBancarioHSol.TabIndex = 29;
         this.txnGBancarioHSol.Text = "0.00";
         this.txnGBancarioHSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnGBancarioHSol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnGBancarioDDol
         // 
         this.txnGBancarioDDol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnGBancarioDDol.Decimales = 2;
         this.txnGBancarioDDol.Enteros = 9;
         this.txnGBancarioDDol.Formato = "###,###,##0.00";
         this.txnGBancarioDDol.Location = new System.Drawing.Point(738, 111);
         this.txnGBancarioDDol.MaxLength = 13;
         this.txnGBancarioDDol.Name = "txnGBancarioDDol";
         this.txnGBancarioDDol.Negativo = true;
         this.txnGBancarioDDol.SinFormato = false;
         this.txnGBancarioDDol.Size = new System.Drawing.Size(109, 20);
         this.txnGBancarioDDol.TabIndex = 30;
         this.txnGBancarioDDol.Text = "0.00";
         this.txnGBancarioDDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnGBancarioDDol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnGBancarioHDol
         // 
         this.txnGBancarioHDol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnGBancarioHDol.Decimales = 2;
         this.txnGBancarioHDol.Enteros = 9;
         this.txnGBancarioHDol.Formato = "###,###,##0.00";
         this.txnGBancarioHDol.Location = new System.Drawing.Point(868, 111);
         this.txnGBancarioHDol.MaxLength = 13;
         this.txnGBancarioHDol.Name = "txnGBancarioHDol";
         this.txnGBancarioHDol.Negativo = true;
         this.txnGBancarioHDol.SinFormato = false;
         this.txnGBancarioHDol.Size = new System.Drawing.Size(109, 20);
         this.txnGBancarioHDol.TabIndex = 31;
         this.txnGBancarioHDol.Text = "0.00";
         this.txnGBancarioHDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnGBancarioHDol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnEgresosHDol
         // 
         this.txnEgresosHDol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnEgresosHDol.Decimales = 2;
         this.txnEgresosHDol.Enteros = 9;
         this.txnEgresosHDol.Formato = "###,###,##0.00";
         this.txnEgresosHDol.Location = new System.Drawing.Point(868, 84);
         this.txnEgresosHDol.MaxLength = 13;
         this.txnEgresosHDol.Name = "txnEgresosHDol";
         this.txnEgresosHDol.Negativo = true;
         this.txnEgresosHDol.SinFormato = false;
         this.txnEgresosHDol.Size = new System.Drawing.Size(109, 20);
         this.txnEgresosHDol.TabIndex = 23;
         this.txnEgresosHDol.Text = "0.00";
         this.txnEgresosHDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnEgresosHDol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnIngresosHDol
         // 
         this.txnIngresosHDol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnIngresosHDol.Decimales = 2;
         this.txnIngresosHDol.Enteros = 9;
         this.txnIngresosHDol.Formato = "###,###,##0.00";
         this.txnIngresosHDol.Location = new System.Drawing.Point(868, 57);
         this.txnIngresosHDol.MaxLength = 13;
         this.txnIngresosHDol.Name = "txnIngresosHDol";
         this.txnIngresosHDol.Negativo = true;
         this.txnIngresosHDol.SinFormato = false;
         this.txnIngresosHDol.Size = new System.Drawing.Size(109, 20);
         this.txnIngresosHDol.TabIndex = 15;
         this.txnIngresosHDol.Text = "0.00";
         this.txnIngresosHDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnIngresosHDol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnIngresosDDol
         // 
         this.txnIngresosDDol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnIngresosDDol.Decimales = 2;
         this.txnIngresosDDol.Enteros = 9;
         this.txnIngresosDDol.Formato = "###,###,##0.00";
         this.txnIngresosDDol.Location = new System.Drawing.Point(738, 57);
         this.txnIngresosDDol.MaxLength = 13;
         this.txnIngresosDDol.Name = "txnIngresosDDol";
         this.txnIngresosDDol.Negativo = true;
         this.txnIngresosDDol.SinFormato = false;
         this.txnIngresosDDol.Size = new System.Drawing.Size(109, 20);
         this.txnIngresosDDol.TabIndex = 14;
         this.txnIngresosDDol.Text = "0.00";
         this.txnIngresosDDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnIngresosDDol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // label10
         // 
         this.tableLayoutPanel3.SetColumnSpan(this.label10, 3);
         this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label10.Location = new System.Drawing.Point(485, 7);
         this.label10.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(232, 20);
         this.label10.TabIndex = 0;
         this.label10.Text = "S/.";
         this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label7
         // 
         this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label7.Location = new System.Drawing.Point(615, 34);
         this.label7.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(102, 13);
         this.label7.TabIndex = 6;
         this.label7.Text = "Haber";
         this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label6
         // 
         this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(485, 34);
         this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(102, 13);
         this.label6.TabIndex = 5;
         this.label6.Text = "Debe";
         this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // txnEgresosDSol
         // 
         this.txnEgresosDSol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnEgresosDSol.Decimales = 2;
         this.txnEgresosDSol.Enteros = 9;
         this.txnEgresosDSol.Formato = "###,###,##0.00";
         this.txnEgresosDSol.Location = new System.Drawing.Point(478, 84);
         this.txnEgresosDSol.MaxLength = 13;
         this.txnEgresosDSol.Name = "txnEgresosDSol";
         this.txnEgresosDSol.Negativo = true;
         this.txnEgresosDSol.SinFormato = false;
         this.txnEgresosDSol.Size = new System.Drawing.Size(109, 20);
         this.txnEgresosDSol.TabIndex = 20;
         this.txnEgresosDSol.Text = "0.00";
         this.txnEgresosDSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnEgresosDSol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(10, 88);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(92, 13);
         this.label3.TabIndex = 17;
         this.label3.Text = "Total Egresos :";
         // 
         // txnIngresosDSol
         // 
         this.txnIngresosDSol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnIngresosDSol.Decimales = 2;
         this.txnIngresosDSol.Enteros = 9;
         this.txnIngresosDSol.Formato = "###,###,##0.00";
         this.txnIngresosDSol.Location = new System.Drawing.Point(478, 57);
         this.txnIngresosDSol.MaxLength = 13;
         this.txnIngresosDSol.Name = "txnIngresosDSol";
         this.txnIngresosDSol.Negativo = true;
         this.txnIngresosDSol.SinFormato = false;
         this.txnIngresosDSol.Size = new System.Drawing.Size(109, 20);
         this.txnIngresosDSol.TabIndex = 12;
         this.txnIngresosDSol.Text = "0.00";
         this.txnIngresosDSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnIngresosDSol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 61);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(97, 13);
         this.label1.TabIndex = 9;
         this.label1.Text = "Total Ingresos :";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(10, 115);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(115, 13);
         this.label4.TabIndex = 25;
         this.label4.Text = "Gastos Bancarios :";
         // 
         // txnIngresosHSol
         // 
         this.txnIngresosHSol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnIngresosHSol.Decimales = 2;
         this.txnIngresosHSol.Enteros = 9;
         this.txnIngresosHSol.Formato = "###,###,##0.00";
         this.txnIngresosHSol.Location = new System.Drawing.Point(608, 57);
         this.txnIngresosHSol.MaxLength = 13;
         this.txnIngresosHSol.Name = "txnIngresosHSol";
         this.txnIngresosHSol.Negativo = true;
         this.txnIngresosHSol.SinFormato = false;
         this.txnIngresosHSol.Size = new System.Drawing.Size(109, 20);
         this.txnIngresosHSol.TabIndex = 13;
         this.txnIngresosHSol.Text = "0.00";
         this.txnIngresosHSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnIngresosHSol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnEgresosHSol
         // 
         this.txnEgresosHSol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnEgresosHSol.Decimales = 2;
         this.txnEgresosHSol.Enteros = 9;
         this.txnEgresosHSol.Formato = "###,###,##0.00";
         this.txnEgresosHSol.Location = new System.Drawing.Point(608, 84);
         this.txnEgresosHSol.MaxLength = 13;
         this.txnEgresosHSol.Name = "txnEgresosHSol";
         this.txnEgresosHSol.Negativo = true;
         this.txnEgresosHSol.SinFormato = false;
         this.txnEgresosHSol.Size = new System.Drawing.Size(109, 20);
         this.txnEgresosHSol.TabIndex = 21;
         this.txnEgresosHSol.Text = "0.00";
         this.txnEgresosHSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnEgresosHSol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // label9
         // 
         this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label9.Location = new System.Drawing.Point(875, 34);
         this.label9.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(102, 13);
         this.label9.TabIndex = 8;
         this.label9.Text = "Haber";
         this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label8
         // 
         this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label8.Location = new System.Drawing.Point(745, 34);
         this.label8.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(102, 13);
         this.label8.TabIndex = 7;
         this.label8.Text = "Debe";
         this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label11
         // 
         this.tableLayoutPanel3.SetColumnSpan(this.label11, 3);
         this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label11.Location = new System.Drawing.Point(745, 7);
         this.label11.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(232, 20);
         this.label11.TabIndex = 1;
         this.label11.Text = "US$";
         this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // txnTotalDSol
         // 
         this.txnTotalDSol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnTotalDSol.Decimales = 2;
         this.txnTotalDSol.Enteros = 9;
         this.txnTotalDSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txnTotalDSol.Formato = "###,###,##0.00";
         this.txnTotalDSol.Location = new System.Drawing.Point(478, 138);
         this.txnTotalDSol.MaxLength = 13;
         this.txnTotalDSol.Name = "txnTotalDSol";
         this.txnTotalDSol.Negativo = true;
         this.txnTotalDSol.SinFormato = false;
         this.txnTotalDSol.Size = new System.Drawing.Size(109, 20);
         this.txnTotalDSol.TabIndex = 34;
         this.txnTotalDSol.Text = "0.00";
         this.txnTotalDSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnTotalDSol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // txnEgresosDDol
         // 
         this.txnEgresosDDol.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnEgresosDDol.Decimales = 2;
         this.txnEgresosDDol.Enteros = 9;
         this.txnEgresosDDol.Formato = "###,###,##0.00";
         this.txnEgresosDDol.Location = new System.Drawing.Point(738, 84);
         this.txnEgresosDDol.MaxLength = 13;
         this.txnEgresosDDol.Name = "txnEgresosDDol";
         this.txnEgresosDDol.Negativo = true;
         this.txnEgresosDDol.SinFormato = false;
         this.txnEgresosDDol.Size = new System.Drawing.Size(109, 20);
         this.txnEgresosDDol.TabIndex = 22;
         this.txnEgresosDDol.Text = "0.00";
         this.txnEgresosDDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnEgresosDDol.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(370, 142);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(43, 13);
         this.label2.TabIndex = 33;
         this.label2.Text = "Total :";
         // 
         // lblDiferencia
         // 
         this.lblDiferencia.AutoSize = true;
         this.lblDiferencia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblDiferencia.Location = new System.Drawing.Point(370, 169);
         this.lblDiferencia.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblDiferencia.Name = "lblDiferencia";
         this.lblDiferencia.Size = new System.Drawing.Size(74, 13);
         this.lblDiferencia.TabIndex = 38;
         this.lblDiferencia.Text = "Diferencia :";
         // 
         // label13
         // 
         this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label13.Location = new System.Drawing.Point(1005, 7);
         this.label13.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label13.Name = "label13";
         this.tableLayoutPanel3.SetRowSpan(this.label13, 2);
         this.label13.Size = new System.Drawing.Size(72, 47);
         this.label13.TabIndex = 2;
         this.label13.Text = "Tipo Cambio";
         this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // errorProviderTransferencia
         // 
         this.errorProviderTransferencia.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
         this.errorProviderTransferencia.ContainerControl = this;
         // 
         // CAJ005TransferenciasMViewSmall
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(1100, 359);
         this.Controls.Add(this.tableLayoutPanel3);
         this.Controls.Add(this.panelCaption4);
         this.Controls.Add(this.tableDatosGenerales);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.panel3);
         this.Name = "CAJ005TransferenciasMViewSmall";
         this.Text = "Transferencia de Cuentas Propias";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         this.tableDatosGenerales.ResumeLayout(false);
         this.tableDatosGenerales.PerformLayout();
         this.tableLayoutPanel3.ResumeLayout(false);
         this.tableLayoutPanel3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderTransferencia)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableDatosGenerales;
      private System.Windows.Forms.TextBox txtTRAN_Glosa;
      private System.Windows.Forms.TextBox txtTRAN_Codigo;
      private System.Windows.Forms.Label lblTRAN_Glosa;
      private System.Windows.Forms.Label lblTRAN_Fecha;
      private System.Windows.Forms.Label lblTRAN_Codigo;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption4;
      private System.Windows.Forms.Button btnCalcular;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private System.Windows.Forms.Label lblDiferencia;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnDiferenciaHDol;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnDiferenciaDDol;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnDiferenciaHSol;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnDiferenciaDSol;
      private System.Windows.Forms.Label label2;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnTotalHDol;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnTotalDDol;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnTotalHSol;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnGBancarioDSol;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnGBancarioHSol;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnGBancarioDDol;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnGBancarioHDol;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnEgresosHDol;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnIngresosHDol;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnIngresosDDol;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label6;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnEgresosDSol;
      private System.Windows.Forms.Label label3;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnIngresosDSol;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label4;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnIngresosHSol;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnEgresosHSol;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label11;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnTotalDSol;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnEgresosDDol;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label12;
      private Controls.CuentaBancaria txaCUBA_NroCuentaEgresos;
      private Controls.CuentaBancaria txaCUBA_NroCuentaIngresos;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMNDGBancario;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMNDEgresos;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMNDIngresos;
      private Infrastructure.WinForms.Controls.MaskTime dtpTRAN_Fecha;
      private System.Windows.Forms.ErrorProvider errorProviderTransferencia;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnGBAN_TipoCambio;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnMOVI_TipoCambioEgresos;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnMOVI_TipoCambioIngresos;
      private System.Windows.Forms.Label label13;
   }
}