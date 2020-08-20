namespace Delfin.Principal
{
   partial class OPE003View
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
            this.cmbREPO_Anio = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cmbREPO_Gerencia = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.errorProviderCab_Cotizacion_OV = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderDet_Cotizacion_OV_Novedad = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorEventoTarea = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableDatosGenerales = new System.Windows.Forms.TableLayoutPanel();
            this.lblCONS_CodFLE = new System.Windows.Forms.Label();
            this.cmbCONS_CodLNG = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblCONS_CodLNG = new System.Windows.Forms.Label();
            this.cmbCONS_CodVia = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblCONS_CodVia = new System.Windows.Forms.Label();
            this.lblTIPO_CodPAIDestino = new System.Windows.Forms.Label();
            this.cmbTIPO_CodPAIDestino = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.lblPUER_CodDestino = new System.Windows.Forms.Label();
            this.txaPUER_CodDestino = new Delfin.Controls.AyudaPuerto();
            this.lblPUER_CodOrigen = new System.Windows.Forms.Label();
            this.txaPUER_CodOrigen = new Delfin.Controls.AyudaPuerto();
            this.cmbTIPO_CodPAIOrigen = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.lblTIPO_CodPAIOrigen = new System.Windows.Forms.Label();
            this.lblENTC_CodTransportista = new System.Windows.Forms.Label();
            this.txaENTC_CodTransportista = new Delfin.Controls.Entidad(this.components);
            this.lblENTC_CodEjecutivo = new System.Windows.Forms.Label();
            this.txaENTC_CodEjecutivo = new Delfin.Controls.Entidad(this.components);
            this.lblENTC_CodAgente = new System.Windows.Forms.Label();
            this.txaENTC_CodAgente = new Delfin.Controls.Entidad(this.components);
            this.lblENTC_CodCliente = new System.Windows.Forms.Label();
            this.txaENTC_CodCliente = new Delfin.Controls.Entidad(this.components);
            this.chkMostrarRebate = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCONS_CodRGM = new System.Windows.Forms.Label();
            this.cmbCONS_CodRGM = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.cmbCCOT_CodFLE = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.chkServicioTransmision = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mdtREPO_FechaInicio = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.label4 = new System.Windows.Forms.Label();
            this.mdtREPO_FechaTermino = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblTipoFecha = new System.Windows.Forms.Label();
            this.cmbTipoFecha = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
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
            this.panel3.Controls.Add(this.cmbREPO_Anio);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cmbREPO_Gerencia);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Controls.Add(this.btnCargar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(756, 50);
            this.panel3.TabIndex = 0;
            // 
            // cmbREPO_Anio
            // 
            this.cmbREPO_Anio.ComboIntSelectedValue = null;
            this.cmbREPO_Anio.ComboSelectedItem = null;
            this.cmbREPO_Anio.ComboStrSelectedValue = null;
            this.cmbREPO_Anio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbREPO_Anio.FormattingEnabled = true;
            this.cmbREPO_Anio.Location = new System.Drawing.Point(531, 23);
            this.cmbREPO_Anio.Name = "cmbREPO_Anio";
            this.cmbREPO_Anio.Size = new System.Drawing.Size(194, 21);
            this.cmbREPO_Anio.TabIndex = 73;
            this.cmbREPO_Anio.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(492, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "Año:";
            this.label2.Visible = false;
            // 
            // cmbREPO_Gerencia
            // 
            this.cmbREPO_Gerencia.ComboIntSelectedValue = null;
            this.cmbREPO_Gerencia.ComboSelectedItem = null;
            this.cmbREPO_Gerencia.ComboStrSelectedValue = null;
            this.cmbREPO_Gerencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbREPO_Gerencia.FormattingEnabled = true;
            this.cmbREPO_Gerencia.Location = new System.Drawing.Point(285, 23);
            this.cmbREPO_Gerencia.Name = "cmbREPO_Gerencia";
            this.cmbREPO_Gerencia.Size = new System.Drawing.Size(194, 21);
            this.cmbREPO_Gerencia.TabIndex = 0;
            this.cmbREPO_Gerencia.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Reporte:";
            this.label1.Visible = false;
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
            // btnCargar
            // 
            this.btnCargar.AutoSize = true;
            this.btnCargar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.ForeColor = System.Drawing.Color.Black;
            this.btnCargar.Image = global::Delfin.Principal.Properties.Resources.replace21;
            this.btnCargar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCargar.Location = new System.Drawing.Point(0, 0);
            this.btnCargar.Margin = new System.Windows.Forms.Padding(0);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(57, 50);
            this.btnCargar.TabIndex = 0;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargar.UseVisualStyleBackColor = true;
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
            this.tableDatosGenerales.ColumnCount = 7;
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableDatosGenerales.Controls.Add(this.lblCONS_CodFLE, 0, 8);
            this.tableDatosGenerales.Controls.Add(this.cmbCONS_CodLNG, 1, 1);
            this.tableDatosGenerales.Controls.Add(this.lblCONS_CodLNG, 0, 1);
            this.tableDatosGenerales.Controls.Add(this.cmbCONS_CodVia, 4, 1);
            this.tableDatosGenerales.Controls.Add(this.lblCONS_CodVia, 3, 1);
            this.tableDatosGenerales.Controls.Add(this.lblTIPO_CodPAIDestino, 0, 7);
            this.tableDatosGenerales.Controls.Add(this.cmbTIPO_CodPAIDestino, 1, 7);
            this.tableDatosGenerales.Controls.Add(this.lblPUER_CodDestino, 3, 7);
            this.tableDatosGenerales.Controls.Add(this.txaPUER_CodDestino, 4, 7);
            this.tableDatosGenerales.Controls.Add(this.lblPUER_CodOrigen, 3, 6);
            this.tableDatosGenerales.Controls.Add(this.txaPUER_CodOrigen, 4, 6);
            this.tableDatosGenerales.Controls.Add(this.cmbTIPO_CodPAIOrigen, 1, 6);
            this.tableDatosGenerales.Controls.Add(this.lblTIPO_CodPAIOrigen, 0, 6);
            this.tableDatosGenerales.Controls.Add(this.lblENTC_CodTransportista, 0, 5);
            this.tableDatosGenerales.Controls.Add(this.txaENTC_CodTransportista, 1, 5);
            this.tableDatosGenerales.Controls.Add(this.lblENTC_CodEjecutivo, 0, 4);
            this.tableDatosGenerales.Controls.Add(this.txaENTC_CodEjecutivo, 1, 4);
            this.tableDatosGenerales.Controls.Add(this.lblENTC_CodAgente, 0, 3);
            this.tableDatosGenerales.Controls.Add(this.txaENTC_CodAgente, 1, 3);
            this.tableDatosGenerales.Controls.Add(this.lblENTC_CodCliente, 0, 2);
            this.tableDatosGenerales.Controls.Add(this.txaENTC_CodCliente, 1, 2);
            this.tableDatosGenerales.Controls.Add(this.chkMostrarRebate, 4, 0);
            this.tableDatosGenerales.Controls.Add(this.label5, 3, 0);
            this.tableDatosGenerales.Controls.Add(this.lblCONS_CodRGM, 0, 0);
            this.tableDatosGenerales.Controls.Add(this.cmbCONS_CodRGM, 1, 0);
            this.tableDatosGenerales.Controls.Add(this.cmbCCOT_CodFLE, 1, 8);
            this.tableDatosGenerales.Controls.Add(this.label6, 3, 8);
            this.tableDatosGenerales.Controls.Add(this.chkServicioTransmision, 4, 8);
            this.tableDatosGenerales.Controls.Add(this.label3, 0, 10);
            this.tableDatosGenerales.Controls.Add(this.mdtREPO_FechaInicio, 1, 10);
            this.tableDatosGenerales.Controls.Add(this.label4, 3, 10);
            this.tableDatosGenerales.Controls.Add(this.mdtREPO_FechaTermino, 4, 10);
            this.tableDatosGenerales.Controls.Add(this.lblTipoFecha, 0, 9);
            this.tableDatosGenerales.Controls.Add(this.cmbTipoFecha, 1, 9);
            this.tableDatosGenerales.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableDatosGenerales.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableDatosGenerales.Location = new System.Drawing.Point(0, 50);
            this.tableDatosGenerales.Name = "tableDatosGenerales";
            this.tableDatosGenerales.RowCount = 11;
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.Size = new System.Drawing.Size(756, 297);
            this.tableDatosGenerales.TabIndex = 1;
            // 
            // lblCONS_CodFLE
            // 
            this.lblCONS_CodFLE.AutoSize = true;
            this.lblCONS_CodFLE.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodFLE.Location = new System.Drawing.Point(10, 223);
            this.lblCONS_CodFLE.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblCONS_CodFLE.Name = "lblCONS_CodFLE";
            this.lblCONS_CodFLE.Size = new System.Drawing.Size(77, 20);
            this.lblCONS_CodFLE.TabIndex = 84;
            this.lblCONS_CodFLE.Text = "Condición Embarque:";
            // 
            // cmbCONS_CodLNG
            // 
            this.cmbCONS_CodLNG.ConstantesSelectedItem = null;
            this.cmbCONS_CodLNG.ConstantesSelectedValue = null;
            this.cmbCONS_CodLNG.ConstantesTitulo = null;
            this.cmbCONS_CodLNG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCONS_CodLNG.FormattingEnabled = true;
            this.cmbCONS_CodLNG.Location = new System.Drawing.Point(153, 30);
            this.cmbCONS_CodLNG.Name = "cmbCONS_CodLNG";
            this.cmbCONS_CodLNG.Session = null;
            this.cmbCONS_CodLNG.Size = new System.Drawing.Size(194, 21);
            this.cmbCONS_CodLNG.TabIndex = 66;
            this.cmbCONS_CodLNG.Tag = "CONS_CodLNGMSGERROR";
            // 
            // lblCONS_CodLNG
            // 
            this.lblCONS_CodLNG.AutoSize = true;
            this.lblCONS_CodLNG.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodLNG.Location = new System.Drawing.Point(10, 34);
            this.lblCONS_CodLNG.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONS_CodLNG.Name = "lblCONS_CodLNG";
            this.lblCONS_CodLNG.Size = new System.Drawing.Size(91, 13);
            this.lblCONS_CodLNG.TabIndex = 65;
            this.lblCONS_CodLNG.Text = "Línea Negocio:";
            // 
            // cmbCONS_CodVia
            // 
            this.cmbCONS_CodVia.ConstantesSelectedItem = null;
            this.cmbCONS_CodVia.ConstantesSelectedValue = null;
            this.cmbCONS_CodVia.ConstantesTitulo = null;
            this.cmbCONS_CodVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCONS_CodVia.FormattingEnabled = true;
            this.cmbCONS_CodVia.Location = new System.Drawing.Point(517, 30);
            this.cmbCONS_CodVia.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbCONS_CodVia.Name = "cmbCONS_CodVia";
            this.cmbCONS_CodVia.Session = null;
            this.cmbCONS_CodVia.Size = new System.Drawing.Size(194, 21);
            this.cmbCONS_CodVia.TabIndex = 64;
            this.cmbCONS_CodVia.Tag = "CONS_CodViaMSGERROR";
            // 
            // lblCONS_CodVia
            // 
            this.lblCONS_CodVia.AutoSize = true;
            this.lblCONS_CodVia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodVia.Location = new System.Drawing.Point(375, 34);
            this.lblCONS_CodVia.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblCONS_CodVia.Name = "lblCONS_CodVia";
            this.lblCONS_CodVia.Size = new System.Drawing.Size(30, 13);
            this.lblCONS_CodVia.TabIndex = 63;
            this.lblCONS_CodVia.Text = "Vía:";
            // 
            // lblTIPO_CodPAIDestino
            // 
            this.lblTIPO_CodPAIDestino.AutoSize = true;
            this.lblTIPO_CodPAIDestino.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodPAIDestino.Location = new System.Drawing.Point(10, 196);
            this.lblTIPO_CodPAIDestino.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodPAIDestino.Name = "lblTIPO_CodPAIDestino";
            this.lblTIPO_CodPAIDestino.Size = new System.Drawing.Size(82, 13);
            this.lblTIPO_CodPAIDestino.TabIndex = 4;
            this.lblTIPO_CodPAIDestino.Text = "País Destino:";
            // 
            // cmbTIPO_CodPAIDestino
            // 
            this.cmbTIPO_CodPAIDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodPAIDestino.FormattingEnabled = true;
            this.cmbTIPO_CodPAIDestino.Location = new System.Drawing.Point(153, 192);
            this.cmbTIPO_CodPAIDestino.Name = "cmbTIPO_CodPAIDestino";
            this.cmbTIPO_CodPAIDestino.Session = null;
            this.cmbTIPO_CodPAIDestino.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPO_CodPAIDestino.TabIndex = 5;
            this.cmbTIPO_CodPAIDestino.TiposSelectedItem = null;
            this.cmbTIPO_CodPAIDestino.TiposSelectedValue = null;
            this.cmbTIPO_CodPAIDestino.TiposTitulo = null;
            // 
            // lblPUER_CodDestino
            // 
            this.lblPUER_CodDestino.AutoSize = true;
            this.lblPUER_CodDestino.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPUER_CodDestino.Location = new System.Drawing.Point(375, 196);
            this.lblPUER_CodDestino.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblPUER_CodDestino.Name = "lblPUER_CodDestino";
            this.lblPUER_CodDestino.Size = new System.Drawing.Size(96, 13);
            this.lblPUER_CodDestino.TabIndex = 12;
            this.lblPUER_CodDestino.Text = "Puerto Destino:";
            // 
            // txaPUER_CodDestino
            // 
            this.txaPUER_CodDestino.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txaPUER_CodDestino.CONS_CodVia = null;
            this.txaPUER_CodDestino.CONS_TabVia = null;
            this.txaPUER_CodDestino.DontSendTab = false;
            this.txaPUER_CodDestino.Location = new System.Drawing.Point(517, 192);
            this.txaPUER_CodDestino.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txaPUER_CodDestino.Name = "txaPUER_CodDestino";
            this.txaPUER_CodDestino.SelectedItem = null;
            this.txaPUER_CodDestino.SelectedValue = null;
            this.txaPUER_CodDestino.Size = new System.Drawing.Size(194, 20);
            this.txaPUER_CodDestino.TabIndex = 13;
            this.txaPUER_CodDestino.TIPO_CodPais = null;
            this.txaPUER_CodDestino.TIPO_TabPais = null;
            this.txaPUER_CodDestino.Title = null;
            // 
            // lblPUER_CodOrigen
            // 
            this.lblPUER_CodOrigen.AutoSize = true;
            this.lblPUER_CodOrigen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPUER_CodOrigen.Location = new System.Drawing.Point(375, 169);
            this.lblPUER_CodOrigen.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblPUER_CodOrigen.Name = "lblPUER_CodOrigen";
            this.lblPUER_CodOrigen.Size = new System.Drawing.Size(91, 13);
            this.lblPUER_CodOrigen.TabIndex = 10;
            this.lblPUER_CodOrigen.Text = "Puerto Origen:";
            // 
            // txaPUER_CodOrigen
            // 
            this.txaPUER_CodOrigen.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txaPUER_CodOrigen.CONS_CodVia = null;
            this.txaPUER_CodOrigen.CONS_TabVia = null;
            this.txaPUER_CodOrigen.DontSendTab = false;
            this.txaPUER_CodOrigen.Location = new System.Drawing.Point(517, 165);
            this.txaPUER_CodOrigen.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txaPUER_CodOrigen.Name = "txaPUER_CodOrigen";
            this.txaPUER_CodOrigen.SelectedItem = null;
            this.txaPUER_CodOrigen.SelectedValue = null;
            this.txaPUER_CodOrigen.Size = new System.Drawing.Size(194, 20);
            this.txaPUER_CodOrigen.TabIndex = 11;
            this.txaPUER_CodOrigen.TIPO_CodPais = null;
            this.txaPUER_CodOrigen.TIPO_TabPais = null;
            this.txaPUER_CodOrigen.Title = null;
            // 
            // cmbTIPO_CodPAIOrigen
            // 
            this.cmbTIPO_CodPAIOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodPAIOrigen.FormattingEnabled = true;
            this.cmbTIPO_CodPAIOrigen.Location = new System.Drawing.Point(153, 165);
            this.cmbTIPO_CodPAIOrigen.Name = "cmbTIPO_CodPAIOrigen";
            this.cmbTIPO_CodPAIOrigen.Session = null;
            this.cmbTIPO_CodPAIOrigen.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPO_CodPAIOrigen.TabIndex = 3;
            this.cmbTIPO_CodPAIOrigen.TiposSelectedItem = null;
            this.cmbTIPO_CodPAIOrigen.TiposSelectedValue = null;
            this.cmbTIPO_CodPAIOrigen.TiposTitulo = null;
            // 
            // lblTIPO_CodPAIOrigen
            // 
            this.lblTIPO_CodPAIOrigen.AutoSize = true;
            this.lblTIPO_CodPAIOrigen.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodPAIOrigen.Location = new System.Drawing.Point(10, 169);
            this.lblTIPO_CodPAIOrigen.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodPAIOrigen.Name = "lblTIPO_CodPAIOrigen";
            this.lblTIPO_CodPAIOrigen.Size = new System.Drawing.Size(77, 13);
            this.lblTIPO_CodPAIOrigen.TabIndex = 2;
            this.lblTIPO_CodPAIOrigen.Text = "País Origen:";
            // 
            // lblENTC_CodTransportista
            // 
            this.lblENTC_CodTransportista.AutoSize = true;
            this.lblENTC_CodTransportista.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_CodTransportista.Location = new System.Drawing.Point(10, 142);
            this.lblENTC_CodTransportista.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblENTC_CodTransportista.Name = "lblENTC_CodTransportista";
            this.lblENTC_CodTransportista.Size = new System.Drawing.Size(86, 13);
            this.lblENTC_CodTransportista.TabIndex = 67;
            this.lblENTC_CodTransportista.Text = "Transportista:";
            // 
            // txaENTC_CodTransportista
            // 
            this.txaENTC_CodTransportista.ActivarAyudaAuto = false;
            this.tableDatosGenerales.SetColumnSpan(this.txaENTC_CodTransportista, 4);
            this.txaENTC_CodTransportista.ContainerService = null;
            this.txaENTC_CodTransportista.EnabledAyudaButton = true;
            this.txaENTC_CodTransportista.Location = new System.Drawing.Point(152, 138);
            this.txaENTC_CodTransportista.LongitudAceptada = 0;
            this.txaENTC_CodTransportista.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txaENTC_CodTransportista.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.txaENTC_CodTransportista.Name = "txaENTC_CodTransportista";
            this.txaENTC_CodTransportista.RellenaCeros = false;
            this.txaENTC_CodTransportista.Size = new System.Drawing.Size(558, 20);
            this.txaENTC_CodTransportista.TabIndex = 68;
            this.txaENTC_CodTransportista.Tag = "ENTC_CodTransportistaMSGERROR";
            this.txaENTC_CodTransportista.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.txaENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.txaENTC_CodTransportista.UsarTipoEntidad = true;
            this.txaENTC_CodTransportista.Value = null;
            // 
            // lblENTC_CodEjecutivo
            // 
            this.lblENTC_CodEjecutivo.AutoSize = true;
            this.lblENTC_CodEjecutivo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_CodEjecutivo.Location = new System.Drawing.Point(10, 115);
            this.lblENTC_CodEjecutivo.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblENTC_CodEjecutivo.Name = "lblENTC_CodEjecutivo";
            this.lblENTC_CodEjecutivo.Size = new System.Drawing.Size(64, 13);
            this.lblENTC_CodEjecutivo.TabIndex = 28;
            this.lblENTC_CodEjecutivo.Text = "Ejecutivo:";
            // 
            // txaENTC_CodEjecutivo
            // 
            this.txaENTC_CodEjecutivo.ActivarAyudaAuto = false;
            this.tableDatosGenerales.SetColumnSpan(this.txaENTC_CodEjecutivo, 4);
            this.txaENTC_CodEjecutivo.ContainerService = null;
            this.txaENTC_CodEjecutivo.EnabledAyudaButton = true;
            this.txaENTC_CodEjecutivo.Location = new System.Drawing.Point(152, 111);
            this.txaENTC_CodEjecutivo.LongitudAceptada = 0;
            this.txaENTC_CodEjecutivo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txaENTC_CodEjecutivo.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.txaENTC_CodEjecutivo.Name = "txaENTC_CodEjecutivo";
            this.txaENTC_CodEjecutivo.RellenaCeros = false;
            this.txaENTC_CodEjecutivo.Size = new System.Drawing.Size(558, 20);
            this.txaENTC_CodEjecutivo.TabIndex = 29;
            this.txaENTC_CodEjecutivo.Tag = "ENTC_CodEjecutivoMSGERROR";
            this.txaENTC_CodEjecutivo.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.txaENTC_CodEjecutivo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;
            this.txaENTC_CodEjecutivo.UsarTipoEntidad = true;
            this.txaENTC_CodEjecutivo.Value = null;
            // 
            // lblENTC_CodAgente
            // 
            this.lblENTC_CodAgente.AutoSize = true;
            this.lblENTC_CodAgente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_CodAgente.Location = new System.Drawing.Point(10, 88);
            this.lblENTC_CodAgente.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblENTC_CodAgente.Name = "lblENTC_CodAgente";
            this.lblENTC_CodAgente.Size = new System.Drawing.Size(52, 13);
            this.lblENTC_CodAgente.TabIndex = 26;
            this.lblENTC_CodAgente.Tag = "MSGERROR";
            this.lblENTC_CodAgente.Text = "Agente:";
            // 
            // txaENTC_CodAgente
            // 
            this.txaENTC_CodAgente.ActivarAyudaAuto = false;
            this.tableDatosGenerales.SetColumnSpan(this.txaENTC_CodAgente, 4);
            this.txaENTC_CodAgente.ContainerService = null;
            this.txaENTC_CodAgente.EnabledAyudaButton = true;
            this.txaENTC_CodAgente.Location = new System.Drawing.Point(152, 84);
            this.txaENTC_CodAgente.LongitudAceptada = 0;
            this.txaENTC_CodAgente.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txaENTC_CodAgente.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.txaENTC_CodAgente.Name = "txaENTC_CodAgente";
            this.txaENTC_CodAgente.RellenaCeros = false;
            this.txaENTC_CodAgente.Size = new System.Drawing.Size(558, 20);
            this.txaENTC_CodAgente.TabIndex = 27;
            this.txaENTC_CodAgente.Tag = "ENTC_CodAgenteMSGERROR";
            this.txaENTC_CodAgente.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.txaENTC_CodAgente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente;
            this.txaENTC_CodAgente.UsarTipoEntidad = true;
            this.txaENTC_CodAgente.Value = null;
            // 
            // lblENTC_CodCliente
            // 
            this.lblENTC_CodCliente.AutoSize = true;
            this.lblENTC_CodCliente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_CodCliente.Location = new System.Drawing.Point(10, 61);
            this.lblENTC_CodCliente.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblENTC_CodCliente.Name = "lblENTC_CodCliente";
            this.lblENTC_CodCliente.Size = new System.Drawing.Size(52, 13);
            this.lblENTC_CodCliente.TabIndex = 24;
            this.lblENTC_CodCliente.Text = "Cliente:";
            // 
            // txaENTC_CodCliente
            // 
            this.txaENTC_CodCliente.ActivarAyudaAuto = false;
            this.tableDatosGenerales.SetColumnSpan(this.txaENTC_CodCliente, 4);
            this.txaENTC_CodCliente.ContainerService = null;
            this.txaENTC_CodCliente.EnabledAyudaButton = true;
            this.txaENTC_CodCliente.Location = new System.Drawing.Point(152, 57);
            this.txaENTC_CodCliente.LongitudAceptada = 0;
            this.txaENTC_CodCliente.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txaENTC_CodCliente.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.txaENTC_CodCliente.Name = "txaENTC_CodCliente";
            this.txaENTC_CodCliente.RellenaCeros = false;
            this.txaENTC_CodCliente.Size = new System.Drawing.Size(558, 20);
            this.txaENTC_CodCliente.TabIndex = 25;
            this.txaENTC_CodCliente.Tag = "ENTC_CodClienteMSGERROR";
            this.txaENTC_CodCliente.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.txaENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            this.txaENTC_CodCliente.UsarTipoEntidad = true;
            this.txaENTC_CodCliente.Value = null;
            // 
            // chkMostrarRebate
            // 
            this.chkMostrarRebate.AutoSize = true;
            this.chkMostrarRebate.Location = new System.Drawing.Point(518, 7);
            this.chkMostrarRebate.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.chkMostrarRebate.Name = "chkMostrarRebate";
            this.chkMostrarRebate.Size = new System.Drawing.Size(15, 14);
            this.chkMostrarRebate.TabIndex = 85;
            this.chkMostrarRebate.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(375, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 86;
            this.label5.Text = "Mostrar Rebate:";
            // 
            // lblCONS_CodRGM
            // 
            this.lblCONS_CodRGM.AutoSize = true;
            this.lblCONS_CodRGM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodRGM.Location = new System.Drawing.Point(10, 7);
            this.lblCONS_CodRGM.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblCONS_CodRGM.Name = "lblCONS_CodRGM";
            this.lblCONS_CodRGM.Size = new System.Drawing.Size(62, 13);
            this.lblCONS_CodRGM.TabIndex = 61;
            this.lblCONS_CodRGM.Text = "Régimen:";
            // 
            // cmbCONS_CodRGM
            // 
            this.cmbCONS_CodRGM.ConstantesSelectedItem = null;
            this.cmbCONS_CodRGM.ConstantesSelectedValue = null;
            this.cmbCONS_CodRGM.ConstantesTitulo = null;
            this.cmbCONS_CodRGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCONS_CodRGM.FormattingEnabled = true;
            this.cmbCONS_CodRGM.Location = new System.Drawing.Point(152, 3);
            this.cmbCONS_CodRGM.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbCONS_CodRGM.Name = "cmbCONS_CodRGM";
            this.cmbCONS_CodRGM.Session = null;
            this.cmbCONS_CodRGM.Size = new System.Drawing.Size(194, 21);
            this.cmbCONS_CodRGM.TabIndex = 62;
            this.cmbCONS_CodRGM.Tag = "CONS_CodRGMMSGERROR";
            // 
            // cmbCCOT_CodFLE
            // 
            this.cmbCCOT_CodFLE.ComboIntSelectedValue = null;
            this.cmbCCOT_CodFLE.ComboSelectedItem = null;
            this.cmbCCOT_CodFLE.ComboStrSelectedValue = null;
            this.cmbCCOT_CodFLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCCOT_CodFLE.FormattingEnabled = true;
            this.cmbCCOT_CodFLE.Location = new System.Drawing.Point(153, 219);
            this.cmbCCOT_CodFLE.Name = "cmbCCOT_CodFLE";
            this.cmbCCOT_CodFLE.Size = new System.Drawing.Size(193, 21);
            this.cmbCCOT_CodFLE.TabIndex = 87;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(375, 223);
            this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "Servicio Transmisión:";
            // 
            // chkServicioTransmision
            // 
            this.chkServicioTransmision.AutoSize = true;
            this.chkServicioTransmision.Location = new System.Drawing.Point(518, 223);
            this.chkServicioTransmision.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.chkServicioTransmision.Name = "chkServicioTransmision";
            this.chkServicioTransmision.Size = new System.Drawing.Size(15, 14);
            this.chkServicioTransmision.TabIndex = 89;
            this.chkServicioTransmision.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 277);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Desde:";
            // 
            // mdtREPO_FechaInicio
            // 
            this.mdtREPO_FechaInicio.Location = new System.Drawing.Point(153, 273);
            this.mdtREPO_FechaInicio.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtREPO_FechaInicio.Name = "mdtREPO_FechaInicio";
            this.mdtREPO_FechaInicio.NSActiveMouse = false;
            this.mdtREPO_FechaInicio.NSActiveMsgFecha = false;
            this.mdtREPO_FechaInicio.NSChangeDate = true;
            this.mdtREPO_FechaInicio.NSDigitos = 4;
            this.mdtREPO_FechaInicio.NSFecha = null;
            this.mdtREPO_FechaInicio.NSSetDateNow = false;
            this.mdtREPO_FechaInicio.Size = new System.Drawing.Size(101, 22);
            this.mdtREPO_FechaInicio.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(375, 277);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 80;
            this.label4.Text = "Hasta:";
            // 
            // mdtREPO_FechaTermino
            // 
            this.mdtREPO_FechaTermino.Location = new System.Drawing.Point(518, 273);
            this.mdtREPO_FechaTermino.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtREPO_FechaTermino.Name = "mdtREPO_FechaTermino";
            this.mdtREPO_FechaTermino.NSActiveMouse = false;
            this.mdtREPO_FechaTermino.NSActiveMsgFecha = false;
            this.mdtREPO_FechaTermino.NSChangeDate = true;
            this.mdtREPO_FechaTermino.NSDigitos = 4;
            this.mdtREPO_FechaTermino.NSFecha = null;
            this.mdtREPO_FechaTermino.NSSetDateNow = false;
            this.mdtREPO_FechaTermino.Size = new System.Drawing.Size(101, 22);
            this.mdtREPO_FechaTermino.TabIndex = 83;
            // 
            // lblTipoFecha
            // 
            this.lblTipoFecha.AutoSize = true;
            this.lblTipoFecha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoFecha.Location = new System.Drawing.Point(10, 250);
            this.lblTipoFecha.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblTipoFecha.Name = "lblTipoFecha";
            this.lblTipoFecha.Size = new System.Drawing.Size(106, 13);
            this.lblTipoFecha.TabIndex = 90;
            this.lblTipoFecha.Text = "Tipo de Fecha :";
            // 
            // cmbTipoFecha
            // 
            this.cmbTipoFecha.ComboIntSelectedValue = null;
            this.cmbTipoFecha.ComboSelectedItem = null;
            this.cmbTipoFecha.ComboStrSelectedValue = null;
            this.cmbTipoFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoFecha.FormattingEnabled = true;
            this.cmbTipoFecha.Location = new System.Drawing.Point(153, 246);
            this.cmbTipoFecha.Name = "cmbTipoFecha";
            this.cmbTipoFecha.Size = new System.Drawing.Size(194, 21);
            this.cmbTipoFecha.TabIndex = 91;
            this.cmbTipoFecha.Visible = false;
            // 
            // OPE003View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(756, 382);
            this.Controls.Add(this.tableDatosGenerales);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OPE003View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes Gerencia";
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
      private System.Windows.Forms.Button btnCargar;
      private System.Windows.Forms.ErrorProvider errorProviderCab_Cotizacion_OV;
      private System.Windows.Forms.ErrorProvider errorProviderDet_Cotizacion_OV_Novedad;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.ErrorProvider errorEventoTarea;
      private System.Windows.Forms.TableLayoutPanel tableDatosGenerales;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbREPO_Gerencia;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbREPO_Anio;
      private System.Windows.Forms.Label lblCONS_CodLNG;
      private Controls.Tipos.ComboBoxConstantes cmbCONS_CodLNG;
      private Controls.Tipos.ComboBoxConstantes cmbCONS_CodVia;
      private System.Windows.Forms.Label lblCONS_CodVia;
      private System.Windows.Forms.Label lblCONS_CodRGM;
      private Controls.Tipos.ComboBoxConstantes cmbCONS_CodRGM;
      private Controls.Entidad txaENTC_CodEjecutivo;
      private System.Windows.Forms.Label lblENTC_CodEjecutivo;
      private Controls.Entidad txaENTC_CodAgente;
      private System.Windows.Forms.Label lblENTC_CodAgente;
      private Controls.Entidad txaENTC_CodCliente;
      private System.Windows.Forms.Label lblENTC_CodCliente;
      private Controls.Entidad txaENTC_CodTransportista;
      private System.Windows.Forms.Label lblENTC_CodTransportista;
      private Controls.AyudaPuerto txaPUER_CodDestino;
      private System.Windows.Forms.Label lblPUER_CodDestino;
      private Controls.AyudaPuerto txaPUER_CodOrigen;
      private System.Windows.Forms.Label lblPUER_CodOrigen;
      private System.Windows.Forms.Label label3;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtREPO_FechaInicio;
      private System.Windows.Forms.Label label4;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtREPO_FechaTermino;
      private System.Windows.Forms.Label lblCONS_CodFLE;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodPAIDestino;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodPAIOrigen;
      private System.Windows.Forms.Label lblTIPO_CodPAIOrigen;
      private System.Windows.Forms.Label lblTIPO_CodPAIDestino;
      private System.Windows.Forms.CheckBox chkMostrarRebate;
      private System.Windows.Forms.Label label5;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbCCOT_CodFLE;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.CheckBox chkServicioTransmision;
      private System.Windows.Forms.Label lblTipoFecha;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbTipoFecha;
   }
}