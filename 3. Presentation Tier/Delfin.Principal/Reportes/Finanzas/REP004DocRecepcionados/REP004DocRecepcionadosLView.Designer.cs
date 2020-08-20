namespace Delfin.Principal
{
   partial class REP004DocRecepcionadosLView
   {
      /// <summary> 
      /// Variable del diseñador requerida.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Limpiar los recursos que se estén utilizando.
      /// </summary>
      /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Código generado por el Diseñador de componentes

      /// <summary> 
      /// Método necesario para admitir el Diseñador. No se puede modificar 
      /// el contenido del método con el editor de código.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REP004DocRecepcionadosLView));
         this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label9 = new System.Windows.Forms.Label();
         this.txaNaveViaje = new Delfin.Controls.AyudaViaje();
         this.cmbTipoRegistro = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.label8 = new System.Windows.Forms.Label();
         this.txtMBL = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.cmbTIPE_Codigo = new Delfin.Controls.ComboBoxTipoEntidad();
         this.label1 = new System.Windows.Forms.Label();
         this.txaENTC_Codigo = new Delfin.Controls.EntidadDocIden();
         this.chkSoloPendientes = new System.Windows.Forms.CheckBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.txtHBL = new System.Windows.Forms.TextBox();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.pnBotones = new System.Windows.Forms.Panel();
         this.btnImprimir = new System.Windows.Forms.Button();
         this.pnlFechas = new System.Windows.Forms.Panel();
         this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
         this.rbtnFecEmision = new System.Windows.Forms.RadioButton();
         this.rbtnFecVencimiento = new System.Windows.Forms.RadioButton();
         this.rbtnFecRecepcion = new System.Windows.Forms.RadioButton();
         this.rbtnFecPosPago = new System.Windows.Forms.RadioButton();
         this.dtpFecFin = new Infrastructure.WinForms.Controls.MaskTime();
         this.dtpFecIni = new Infrastructure.WinForms.Controls.MaskTime();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.cmbTIPO_CodDetrac = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
         this.chkDetracciones = new System.Windows.Forms.CheckBox();
         this.tableLayoutPanel1.SuspendLayout();
         this.pnBotones.SuspendLayout();
         this.pnlFechas.SuspendLayout();
         this.tableLayoutPanel3.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         this.tableLayoutPanel4.SuspendLayout();
         this.SuspendLayout();
         // 
         // TitleView
         // 
         this.TitleView.AllowActive = false;
         this.TitleView.AntiAlias = false;
         this.TitleView.Caption = "Template Reporte";
         this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
         this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
         this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.TitleView.Location = new System.Drawing.Point(0, 0);
         this.TitleView.Name = "TitleView";
         this.TitleView.Size = new System.Drawing.Size(1104, 26);
         this.TitleView.TabIndex = 0;
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
         this.tableLayoutPanel1.Controls.Add(this.label9, 3, 2);
         this.tableLayoutPanel1.Controls.Add(this.txaNaveViaje, 4, 2);
         this.tableLayoutPanel1.Controls.Add(this.cmbTipoRegistro, 1, 2);
         this.tableLayoutPanel1.Controls.Add(this.label8, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.txtMBL, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.cmbTIPE_Codigo, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
         this.tableLayoutPanel1.Controls.Add(this.txaENTC_Codigo, 4, 0);
         this.tableLayoutPanel1.Controls.Add(this.chkSoloPendientes, 6, 1);
         this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.label6, 3, 1);
         this.tableLayoutPanel1.Controls.Add(this.txtHBL, 4, 1);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 3;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(1104, 81);
         this.tableLayoutPanel1.TabIndex = 3;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label9.Location = new System.Drawing.Point(375, 61);
         this.label9.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(78, 13);
         this.label9.TabIndex = 7;
         this.label9.Text = "Nave Viaje :";
         // 
         // txaNaveViaje
         // 
         this.txaNaveViaje.ActivarAyudaAuto = false;
         this.txaNaveViaje.EMPR_Codigo = ((short)(0));
         this.txaNaveViaje.EnabledAyuda = true;
         this.txaNaveViaje.EnabledAyudaButton = true;
         this.txaNaveViaje.ENTC_CodTranportista = null;
         this.txaNaveViaje.EsFiltro = false;
         this.txaNaveViaje.FechaDesde = null;
         this.txaNaveViaje.Location = new System.Drawing.Point(518, 57);
         this.txaNaveViaje.LongitudAceptada = 0;
         this.txaNaveViaje.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
         this.txaNaveViaje.Name = "txaNaveViaje";
         this.txaNaveViaje.RellenaCeros = false;
         this.txaNaveViaje.Size = new System.Drawing.Size(194, 20);
         this.txaNaveViaje.SUCR_Codigo = ((short)(0));
         this.txaNaveViaje.TabIndex = 7;
         this.txaNaveViaje.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.Numerico;
         this.txaNaveViaje.TipoAyudaNaveViaje = Delfin.Controls.AyudaViaje.TipoAyuda.Codigo;
         this.txaNaveViaje.Value = null;
         // 
         // cmbTipoRegistro
         // 
         this.cmbTipoRegistro.ConstantesSelectedItem = null;
         this.cmbTipoRegistro.ConstantesSelectedValue = null;
         this.cmbTipoRegistro.ConstantesTitulo = null;
         this.cmbTipoRegistro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTipoRegistro.FormattingEnabled = true;
         this.cmbTipoRegistro.Location = new System.Drawing.Point(153, 57);
         this.cmbTipoRegistro.Name = "cmbTipoRegistro";
         this.cmbTipoRegistro.Session = null;
         this.cmbTipoRegistro.Size = new System.Drawing.Size(194, 21);
         this.cmbTipoRegistro.TabIndex = 8;
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label8.Location = new System.Drawing.Point(10, 61);
         this.label8.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(109, 13);
         this.label8.TabIndex = 7;
         this.label8.Text = "Tipo de Registro :";
         // 
         // txtMBL
         // 
         this.txtMBL.Location = new System.Drawing.Point(153, 30);
         this.txtMBL.Name = "txtMBL";
         this.txtMBL.Size = new System.Drawing.Size(194, 20);
         this.txtMBL.TabIndex = 5;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(10, 7);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(104, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Tipo de Entidad :";
         // 
         // cmbTIPE_Codigo
         // 
         this.cmbTIPE_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPE_Codigo.FormattingEnabled = true;
         this.cmbTIPE_Codigo.Location = new System.Drawing.Point(153, 3);
         this.cmbTIPE_Codigo.Name = "cmbTIPE_Codigo";
         this.cmbTIPE_Codigo.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPE_Codigo.TabIndex = 1;
         this.cmbTIPE_Codigo.TipoEntidadSelectedItem = null;
         this.cmbTIPE_Codigo.TipoEntidadSelectedValue = null;
         this.cmbTIPE_Codigo.TiposTitulo = null;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(375, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(58, 13);
         this.label1.TabIndex = 2;
         this.label1.Text = "Entidad :";
         // 
         // txaENTC_Codigo
         // 
         this.txaENTC_Codigo.BackColor = System.Drawing.Color.LightSteelBlue;
         this.tableLayoutPanel1.SetColumnSpan(this.txaENTC_Codigo, 4);
         this.txaENTC_Codigo.CrearNuevaEntidad = false;
         this.txaENTC_Codigo.Location = new System.Drawing.Point(515, 0);
         this.txaENTC_Codigo.Margin = new System.Windows.Forms.Padding(0);
         this.txaENTC_Codigo.MinimumSize = new System.Drawing.Size(565, 27);
         this.txaENTC_Codigo.Name = "txaENTC_Codigo";
         this.txaENTC_Codigo.Size = new System.Drawing.Size(565, 27);
         this.txaENTC_Codigo.SoloEntidad = false;
         this.txaENTC_Codigo.TabIndex = 3;
         this.txaENTC_Codigo.TagEntidad = null;
         this.txaENTC_Codigo.TiposEntidad = Delfin.Controls.TiposEntidad.TIPE_AgenciaAduanera;
         this.txaENTC_Codigo.txaENTC_DOCIDEN_Name = "txaENTC_DOCIDEN";
         this.txaENTC_Codigo.txaENTC_NOMCOMPLETO_Name = "txaENTC_NOMCOMPLETO";
         // 
         // chkSoloPendientes
         // 
         this.chkSoloPendientes.AutoSize = true;
         this.chkSoloPendientes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.tableLayoutPanel1.SetColumnSpan(this.chkSoloPendientes, 2);
         this.chkSoloPendientes.Location = new System.Drawing.Point(740, 34);
         this.chkSoloPendientes.Margin = new System.Windows.Forms.Padding(10, 7, 3, 3);
         this.chkSoloPendientes.Name = "chkSoloPendientes";
         this.chkSoloPendientes.Size = new System.Drawing.Size(153, 17);
         this.chkSoloPendientes.TabIndex = 8;
         this.chkSoloPendientes.Text = "Solo Mostrar Pendientes :  ";
         this.chkSoloPendientes.UseVisualStyleBackColor = true;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(10, 34);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(39, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "MBL :";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(375, 34);
         this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(38, 13);
         this.label6.TabIndex = 6;
         this.label6.Text = "HBL :";
         // 
         // txtHBL
         // 
         this.txtHBL.Location = new System.Drawing.Point(518, 30);
         this.txtHBL.Name = "txtHBL";
         this.txtHBL.Size = new System.Drawing.Size(194, 20);
         this.txtHBL.TabIndex = 7;
         // 
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Criterio de Búsqueda";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 76);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(1104, 26);
         this.panelCaption1.TabIndex = 2;
         // 
         // pnBotones
         // 
         this.pnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
         this.pnBotones.Controls.Add(this.btnImprimir);
         this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
         this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.pnBotones.Location = new System.Drawing.Point(0, 26);
         this.pnBotones.Name = "pnBotones";
         this.pnBotones.Size = new System.Drawing.Size(1104, 50);
         this.pnBotones.TabIndex = 1;
         // 
         // btnImprimir
         // 
         this.btnImprimir.AutoSize = true;
         this.btnImprimir.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
         this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnImprimir.ForeColor = System.Drawing.Color.Black;
         this.btnImprimir.Image = global::Delfin.Principal.Properties.Resources.printer2;
         this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnImprimir.Location = new System.Drawing.Point(0, 0);
         this.btnImprimir.Margin = new System.Windows.Forms.Padding(0);
         this.btnImprimir.Name = "btnImprimir";
         this.btnImprimir.Size = new System.Drawing.Size(58, 50);
         this.btnImprimir.TabIndex = 6;
         this.btnImprimir.Text = "&Imprimir";
         this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnImprimir.UseVisualStyleBackColor = true;
         // 
         // pnlFechas
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.pnlFechas, 9);
         this.pnlFechas.Controls.Add(this.tableLayoutPanel3);
         this.pnlFechas.Location = new System.Drawing.Point(0, 0);
         this.pnlFechas.Margin = new System.Windows.Forms.Padding(0);
         this.pnlFechas.Name = "pnlFechas";
         this.pnlFechas.Size = new System.Drawing.Size(1095, 27);
         this.pnlFechas.TabIndex = 0;
         // 
         // tableLayoutPanel3
         // 
         this.tableLayoutPanel3.AutoSize = true;
         this.tableLayoutPanel3.ColumnCount = 10;
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.Controls.Add(this.rbtnFecEmision, 0, 0);
         this.tableLayoutPanel3.Controls.Add(this.rbtnFecVencimiento, 2, 0);
         this.tableLayoutPanel3.Controls.Add(this.rbtnFecRecepcion, 4, 0);
         this.tableLayoutPanel3.Controls.Add(this.rbtnFecPosPago, 6, 0);
         this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 3;
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.Size = new System.Drawing.Size(1095, 81);
         this.tableLayoutPanel3.TabIndex = 1;
         // 
         // rbtnFecEmision
         // 
         this.rbtnFecEmision.AutoSize = true;
         this.rbtnFecEmision.Location = new System.Drawing.Point(10, 7);
         this.rbtnFecEmision.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.rbtnFecEmision.Name = "rbtnFecEmision";
         this.rbtnFecEmision.Size = new System.Drawing.Size(109, 17);
         this.rbtnFecEmision.TabIndex = 0;
         this.rbtnFecEmision.TabStop = true;
         this.rbtnFecEmision.Tag = "FE";
         this.rbtnFecEmision.Text = "Fecha de Emisión";
         this.rbtnFecEmision.UseVisualStyleBackColor = true;
         // 
         // rbtnFecVencimiento
         // 
         this.rbtnFecVencimiento.AutoSize = true;
         this.rbtnFecVencimiento.Location = new System.Drawing.Point(280, 7);
         this.rbtnFecVencimiento.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.rbtnFecVencimiento.Name = "rbtnFecVencimiento";
         this.rbtnFecVencimiento.Size = new System.Drawing.Size(116, 17);
         this.rbtnFecVencimiento.TabIndex = 1;
         this.rbtnFecVencimiento.TabStop = true;
         this.rbtnFecVencimiento.Tag = "FV";
         this.rbtnFecVencimiento.Text = "Fecha Vencimiento";
         this.rbtnFecVencimiento.UseVisualStyleBackColor = true;
         // 
         // rbtnFecRecepcion
         // 
         this.rbtnFecRecepcion.AutoSize = true;
         this.rbtnFecRecepcion.Location = new System.Drawing.Point(550, 7);
         this.rbtnFecRecepcion.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.rbtnFecRecepcion.Name = "rbtnFecRecepcion";
         this.rbtnFecRecepcion.Size = new System.Drawing.Size(125, 17);
         this.rbtnFecRecepcion.TabIndex = 2;
         this.rbtnFecRecepcion.TabStop = true;
         this.rbtnFecRecepcion.Tag = "FR";
         this.rbtnFecRecepcion.Text = "Fecha de Recepción";
         this.rbtnFecRecepcion.UseVisualStyleBackColor = true;
         // 
         // rbtnFecPosPago
         // 
         this.rbtnFecPosPago.AutoSize = true;
         this.rbtnFecPosPago.Location = new System.Drawing.Point(820, 7);
         this.rbtnFecPosPago.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.rbtnFecPosPago.Name = "rbtnFecPosPago";
         this.rbtnFecPosPago.Size = new System.Drawing.Size(135, 17);
         this.rbtnFecPosPago.TabIndex = 3;
         this.rbtnFecPosPago.TabStop = true;
         this.rbtnFecPosPago.Tag = "FP";
         this.rbtnFecPosPago.Text = "Fecha de Posible Pago";
         this.rbtnFecPosPago.UseVisualStyleBackColor = true;
         // 
         // dtpFecFin
         // 
         this.dtpFecFin.Location = new System.Drawing.Point(518, 30);
         this.dtpFecFin.MinimumSize = new System.Drawing.Size(100, 22);
         this.dtpFecFin.Name = "dtpFecFin";
         this.dtpFecFin.NSActiveMouse = false;
         this.dtpFecFin.NSActiveMsgFecha = false;
         this.dtpFecFin.NSChangeDate = true;
         this.dtpFecFin.NSDigitos = 4;
         this.dtpFecFin.NSFecha = null;
         this.dtpFecFin.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.dtpFecFin.NSSetDateNow = false;
         this.dtpFecFin.Size = new System.Drawing.Size(100, 22);
         this.dtpFecFin.TabIndex = 4;
         // 
         // dtpFecIni
         // 
         this.dtpFecIni.Location = new System.Drawing.Point(153, 30);
         this.dtpFecIni.MinimumSize = new System.Drawing.Size(100, 22);
         this.dtpFecIni.Name = "dtpFecIni";
         this.dtpFecIni.NSActiveMouse = false;
         this.dtpFecIni.NSActiveMsgFecha = false;
         this.dtpFecIni.NSChangeDate = true;
         this.dtpFecIni.NSDigitos = 4;
         this.dtpFecIni.NSFecha = null;
         this.dtpFecIni.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.dtpFecIni.NSSetDateNow = false;
         this.dtpFecIni.Size = new System.Drawing.Size(100, 22);
         this.dtpFecIni.TabIndex = 2;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(10, 34);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(52, 13);
         this.label4.TabIndex = 1;
         this.label4.Text = "Desde :";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(375, 34);
         this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(48, 13);
         this.label5.TabIndex = 3;
         this.label5.Text = "Hasta :";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label7.Location = new System.Drawing.Point(375, 7);
         this.label7.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(77, 13);
         this.label7.TabIndex = 1;
         this.label7.Text = "Detracción :";
         // 
         // cmbTIPO_CodDetrac
         // 
         this.cmbTIPO_CodDetrac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodDetrac.FormattingEnabled = true;
         this.cmbTIPO_CodDetrac.Location = new System.Drawing.Point(518, 3);
         this.cmbTIPO_CodDetrac.Name = "cmbTIPO_CodDetrac";
         this.cmbTIPO_CodDetrac.Session = null;
         this.cmbTIPO_CodDetrac.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodDetrac.TabIndex = 2;
         this.cmbTIPO_CodDetrac.TiposSelectedItem = null;
         this.cmbTIPO_CodDetrac.TiposSelectedValue = null;
         this.cmbTIPO_CodDetrac.TiposTitulo = null;
         // 
         // panelCaption2
         // 
         this.panelCaption2.AllowActive = false;
         this.panelCaption2.AntiAlias = false;
         this.panelCaption2.Caption = "Fechas";
         this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption2.Location = new System.Drawing.Point(0, 183);
         this.panelCaption2.Name = "panelCaption2";
         this.panelCaption2.Size = new System.Drawing.Size(1104, 26);
         this.panelCaption2.TabIndex = 4;
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.AutoSize = true;
         this.tableLayoutPanel2.ColumnCount = 10;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.dtpFecIni, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.label5, 3, 1);
         this.tableLayoutPanel2.Controls.Add(this.dtpFecFin, 4, 1);
         this.tableLayoutPanel2.Controls.Add(this.pnlFechas, 0, 0);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 209);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 2;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(1104, 54);
         this.tableLayoutPanel2.TabIndex = 5;
         // 
         // panelCaption3
         // 
         this.panelCaption3.AllowActive = false;
         this.panelCaption3.AntiAlias = false;
         this.panelCaption3.Caption = "Detraccion";
         this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption3.Location = new System.Drawing.Point(0, 263);
         this.panelCaption3.Name = "panelCaption3";
         this.panelCaption3.Size = new System.Drawing.Size(1104, 26);
         this.panelCaption3.TabIndex = 6;
         // 
         // tableLayoutPanel4
         // 
         this.tableLayoutPanel4.AutoSize = true;
         this.tableLayoutPanel4.ColumnCount = 10;
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel4.Controls.Add(this.cmbTIPO_CodDetrac, 4, 0);
         this.tableLayoutPanel4.Controls.Add(this.label7, 3, 0);
         this.tableLayoutPanel4.Controls.Add(this.chkDetracciones, 0, 0);
         this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel4.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 289);
         this.tableLayoutPanel4.Name = "tableLayoutPanel4";
         this.tableLayoutPanel4.RowCount = 2;
         this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel4.Size = new System.Drawing.Size(1104, 54);
         this.tableLayoutPanel4.TabIndex = 7;
         // 
         // chkDetracciones
         // 
         this.chkDetracciones.AutoSize = true;
         this.tableLayoutPanel4.SetColumnSpan(this.chkDetracciones, 2);
         this.chkDetracciones.Location = new System.Drawing.Point(10, 7);
         this.chkDetracciones.Margin = new System.Windows.Forms.Padding(10, 7, 3, 3);
         this.chkDetracciones.Name = "chkDetracciones";
         this.chkDetracciones.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.chkDetracciones.Size = new System.Drawing.Size(166, 17);
         this.chkDetracciones.TabIndex = 0;
         this.chkDetracciones.Text = "Documentos Con Detracción ";
         this.chkDetracciones.UseVisualStyleBackColor = true;
         // 
         // REP004DocRecepcionadosLView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.Controls.Add(this.tableLayoutPanel4);
         this.Controls.Add(this.panelCaption3);
         this.Controls.Add(this.tableLayoutPanel2);
         this.Controls.Add(this.panelCaption2);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.pnBotones);
         this.Controls.Add(this.TitleView);
         this.Name = "REP004DocRecepcionadosLView";
         this.Size = new System.Drawing.Size(1104, 417);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.pnBotones.ResumeLayout(false);
         this.pnBotones.PerformLayout();
         this.pnlFechas.ResumeLayout(false);
         this.pnlFechas.PerformLayout();
         this.tableLayoutPanel3.ResumeLayout(false);
         this.tableLayoutPanel3.PerformLayout();
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.tableLayoutPanel4.ResumeLayout(false);
         this.tableLayoutPanel4.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Infrastructure.WinForms.Controls.FormTitle TitleView;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.Panel pnBotones;
      private System.Windows.Forms.Button btnImprimir;
      private Controls.EntidadDocIden txaENTC_Codigo;
      private Controls.ComboBoxTipoEntidad cmbTIPE_Codigo;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Panel pnlFechas;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private System.Windows.Forms.RadioButton rbtnFecPosPago;
      private System.Windows.Forms.RadioButton rbtnFecRecepcion;
      private System.Windows.Forms.RadioButton rbtnFecVencimiento;
      private System.Windows.Forms.RadioButton rbtnFecEmision;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecFin;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecIni;
      private System.Windows.Forms.CheckBox chkSoloPendientes;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodDetrac;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label3;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
      private System.Windows.Forms.TextBox txtHBL;
      private System.Windows.Forms.TextBox txtMBL;
      private System.Windows.Forms.CheckBox chkDetracciones;
      private Controls.Tipos.ComboBoxConstantes cmbTipoRegistro;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label9;
      private Controls.AyudaViaje txaNaveViaje;
   }
}
