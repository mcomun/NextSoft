namespace Delfin.Principal
{
   partial class COM012MView
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
         this.btnProcesar = new System.Windows.Forms.Button();
         this.errorProviderCab_Cotizacion_OV = new System.Windows.Forms.ErrorProvider(this.components);
         this.errorProviderDet_Cotizacion_OV_Novedad = new System.Windows.Forms.ErrorProvider(this.components);
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.lblFechaIniEmbarque = new System.Windows.Forms.Label();
         this.mdtNVIA_FechaIniEmbarque = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblFechaFinEmbarque = new System.Windows.Forms.Label();
         this.mdtNVIA_FechaFinEmbarque = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblFechaIniLlegada = new System.Windows.Forms.Label();
         this.mdtNVIA_FechaIniLlegada = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblFechaFinLlegada = new System.Windows.Forms.Label();
         this.mdtNVIA_FechaFinLlegada = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblENTC_CodEjecutivo = new System.Windows.Forms.Label();
         this.ayudaENTC_CodEjecutivo = new Delfin.Controls.Entidad(this.components);
         this.tableDatosGenerales = new System.Windows.Forms.TableLayoutPanel();
         this.txaNVIA_Codigo = new Delfin.Controls.AyudaViaje();
         this.label1 = new System.Windows.Forms.Label();
         this.label36 = new System.Windows.Forms.Label();
         this.txtENTC_NomTransportista = new System.Windows.Forms.TextBox();
         this.label58 = new System.Windows.Forms.Label();
         this.cmbTIPO_CodTRF = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.lblNAVE_Nombre = new System.Windows.Forms.Label();
         this.txtNAVE_Nombre = new System.Windows.Forms.TextBox();
         this.txaNVIA_NroViaje = new Delfin.Controls.AyudaViaje();
         this.lblNVIA_NroViaje = new System.Windows.Forms.Label();
         this.panel3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).BeginInit();
         this.tableLayoutPanel1.SuspendLayout();
         this.tableDatosGenerales.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel3
         // 
         this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
         this.panel3.Controls.Add(this.btnSalir);
         this.panel3.Controls.Add(this.btnProcesar);
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
         this.btnSalir.Location = new System.Drawing.Point(61, 0);
         this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
         this.btnSalir.Name = "btnSalir";
         this.btnSalir.Size = new System.Drawing.Size(55, 50);
         this.btnSalir.TabIndex = 1;
         this.btnSalir.Text = "&Salir";
         this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnSalir.UseVisualStyleBackColor = true;
         // 
         // btnProcesar
         // 
         this.btnProcesar.AutoSize = true;
         this.btnProcesar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnProcesar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnProcesar.ForeColor = System.Drawing.Color.Black;
         this.btnProcesar.Image = global::Delfin.Principal.Properties.Resources.replace21;
         this.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnProcesar.Location = new System.Drawing.Point(0, 0);
         this.btnProcesar.Margin = new System.Windows.Forms.Padding(0);
         this.btnProcesar.Name = "btnProcesar";
         this.btnProcesar.Size = new System.Drawing.Size(61, 50);
         this.btnProcesar.TabIndex = 0;
         this.btnProcesar.Text = "&Procesar";
         this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnProcesar.UseVisualStyleBackColor = true;
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
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.AutoSize = true;
         this.tableLayoutPanel1.ColumnCount = 7;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.Controls.Add(this.lblFechaIniEmbarque, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaIniEmbarque, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblFechaFinEmbarque, 3, 0);
         this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaFinEmbarque, 4, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblFechaIniLlegada, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaIniLlegada, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.lblFechaFinLlegada, 3, 1);
         this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaFinLlegada, 4, 1);
         this.tableLayoutPanel1.Controls.Add(this.lblENTC_CodEjecutivo, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.ayudaENTC_CodEjecutivo, 1, 2);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 3;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(735, 81);
         this.tableLayoutPanel1.TabIndex = 3;
         // 
         // lblFechaIniEmbarque
         // 
         this.lblFechaIniEmbarque.AutoSize = true;
         this.lblFechaIniEmbarque.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFechaIniEmbarque.Location = new System.Drawing.Point(10, 7);
         this.lblFechaIniEmbarque.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblFechaIniEmbarque.Name = "lblFechaIniEmbarque";
         this.lblFechaIniEmbarque.Size = new System.Drawing.Size(136, 12);
         this.lblFechaIniEmbarque.TabIndex = 4;
         this.lblFechaIniEmbarque.Text = "Fecha Inicio Embarque:";
         // 
         // mdtNVIA_FechaIniEmbarque
         // 
         this.mdtNVIA_FechaIniEmbarque.Location = new System.Drawing.Point(153, 3);
         this.mdtNVIA_FechaIniEmbarque.MinimumSize = new System.Drawing.Size(100, 22);
         this.mdtNVIA_FechaIniEmbarque.Name = "mdtNVIA_FechaIniEmbarque";
         this.mdtNVIA_FechaIniEmbarque.NSActiveMouse = false;
         this.mdtNVIA_FechaIniEmbarque.NSActiveMsgFecha = false;
         this.mdtNVIA_FechaIniEmbarque.NSChangeDate = true;
         this.mdtNVIA_FechaIniEmbarque.NSDigitos = 4;
         this.mdtNVIA_FechaIniEmbarque.NSFecha = null;
         this.mdtNVIA_FechaIniEmbarque.NSSetDateNow = false;
         this.mdtNVIA_FechaIniEmbarque.Size = new System.Drawing.Size(144, 22);
         this.mdtNVIA_FechaIniEmbarque.TabIndex = 5;
         // 
         // lblFechaFinEmbarque
         // 
         this.lblFechaFinEmbarque.AutoSize = true;
         this.lblFechaFinEmbarque.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFechaFinEmbarque.Location = new System.Drawing.Point(375, 7);
         this.lblFechaFinEmbarque.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblFechaFinEmbarque.Name = "lblFechaFinEmbarque";
         this.lblFechaFinEmbarque.Size = new System.Drawing.Size(131, 13);
         this.lblFechaFinEmbarque.TabIndex = 6;
         this.lblFechaFinEmbarque.Text = "Fecha Fin Embarque :";
         // 
         // mdtNVIA_FechaFinEmbarque
         // 
         this.mdtNVIA_FechaFinEmbarque.Location = new System.Drawing.Point(518, 3);
         this.mdtNVIA_FechaFinEmbarque.MinimumSize = new System.Drawing.Size(100, 22);
         this.mdtNVIA_FechaFinEmbarque.Name = "mdtNVIA_FechaFinEmbarque";
         this.mdtNVIA_FechaFinEmbarque.NSActiveMouse = false;
         this.mdtNVIA_FechaFinEmbarque.NSActiveMsgFecha = false;
         this.mdtNVIA_FechaFinEmbarque.NSChangeDate = true;
         this.mdtNVIA_FechaFinEmbarque.NSDigitos = 4;
         this.mdtNVIA_FechaFinEmbarque.NSFecha = null;
         this.mdtNVIA_FechaFinEmbarque.NSSetDateNow = false;
         this.mdtNVIA_FechaFinEmbarque.Size = new System.Drawing.Size(144, 22);
         this.mdtNVIA_FechaFinEmbarque.TabIndex = 7;
         // 
         // lblFechaIniLlegada
         // 
         this.lblFechaIniLlegada.AutoSize = true;
         this.lblFechaIniLlegada.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFechaIniLlegada.Location = new System.Drawing.Point(10, 34);
         this.lblFechaIniLlegada.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblFechaIniLlegada.Name = "lblFechaIniLlegada";
         this.lblFechaIniLlegada.Size = new System.Drawing.Size(105, 13);
         this.lblFechaIniLlegada.TabIndex = 8;
         this.lblFechaIniLlegada.Text = "Fecha Inicio ETA:";
         // 
         // mdtNVIA_FechaIniLlegada
         // 
         this.mdtNVIA_FechaIniLlegada.Location = new System.Drawing.Point(153, 30);
         this.mdtNVIA_FechaIniLlegada.MinimumSize = new System.Drawing.Size(100, 22);
         this.mdtNVIA_FechaIniLlegada.Name = "mdtNVIA_FechaIniLlegada";
         this.mdtNVIA_FechaIniLlegada.NSActiveMouse = false;
         this.mdtNVIA_FechaIniLlegada.NSActiveMsgFecha = false;
         this.mdtNVIA_FechaIniLlegada.NSChangeDate = true;
         this.mdtNVIA_FechaIniLlegada.NSDigitos = 4;
         this.mdtNVIA_FechaIniLlegada.NSFecha = null;
         this.mdtNVIA_FechaIniLlegada.NSSetDateNow = false;
         this.mdtNVIA_FechaIniLlegada.Size = new System.Drawing.Size(144, 22);
         this.mdtNVIA_FechaIniLlegada.TabIndex = 9;
         // 
         // lblFechaFinLlegada
         // 
         this.lblFechaFinLlegada.AutoSize = true;
         this.lblFechaFinLlegada.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFechaFinLlegada.Location = new System.Drawing.Point(375, 34);
         this.lblFechaFinLlegada.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblFechaFinLlegada.Name = "lblFechaFinLlegada";
         this.lblFechaFinLlegada.Size = new System.Drawing.Size(94, 13);
         this.lblFechaFinLlegada.TabIndex = 10;
         this.lblFechaFinLlegada.Text = "Fecha Fin ETA :";
         // 
         // mdtNVIA_FechaFinLlegada
         // 
         this.mdtNVIA_FechaFinLlegada.Location = new System.Drawing.Point(518, 30);
         this.mdtNVIA_FechaFinLlegada.MinimumSize = new System.Drawing.Size(100, 22);
         this.mdtNVIA_FechaFinLlegada.Name = "mdtNVIA_FechaFinLlegada";
         this.mdtNVIA_FechaFinLlegada.NSActiveMouse = false;
         this.mdtNVIA_FechaFinLlegada.NSActiveMsgFecha = false;
         this.mdtNVIA_FechaFinLlegada.NSChangeDate = true;
         this.mdtNVIA_FechaFinLlegada.NSDigitos = 4;
         this.mdtNVIA_FechaFinLlegada.NSFecha = null;
         this.mdtNVIA_FechaFinLlegada.NSSetDateNow = false;
         this.mdtNVIA_FechaFinLlegada.Size = new System.Drawing.Size(144, 22);
         this.mdtNVIA_FechaFinLlegada.TabIndex = 11;
         // 
         // lblENTC_CodEjecutivo
         // 
         this.lblENTC_CodEjecutivo.AutoSize = true;
         this.lblENTC_CodEjecutivo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_CodEjecutivo.Location = new System.Drawing.Point(10, 61);
         this.lblENTC_CodEjecutivo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENTC_CodEjecutivo.Name = "lblENTC_CodEjecutivo";
         this.lblENTC_CodEjecutivo.Size = new System.Drawing.Size(64, 13);
         this.lblENTC_CodEjecutivo.TabIndex = 16;
         this.lblENTC_CodEjecutivo.Text = "Ejecutivo:";
         // 
         // ayudaENTC_CodEjecutivo
         // 
         this.ayudaENTC_CodEjecutivo.ActivarAyudaAuto = false;
         this.tableLayoutPanel1.SetColumnSpan(this.ayudaENTC_CodEjecutivo, 4);
         this.ayudaENTC_CodEjecutivo.ContainerService = null;
         this.ayudaENTC_CodEjecutivo.EnabledAyudaButton = true;
         this.ayudaENTC_CodEjecutivo.Location = new System.Drawing.Point(153, 57);
         this.ayudaENTC_CodEjecutivo.LongitudAceptada = 0;
         this.ayudaENTC_CodEjecutivo.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ayudaENTC_CodEjecutivo.Name = "ayudaENTC_CodEjecutivo";
         this.ayudaENTC_CodEjecutivo.RellenaCeros = false;
         this.ayudaENTC_CodEjecutivo.Size = new System.Drawing.Size(559, 20);
         this.ayudaENTC_CodEjecutivo.TabIndex = 17;
         this.ayudaENTC_CodEjecutivo.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ayudaENTC_CodEjecutivo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;
         this.ayudaENTC_CodEjecutivo.UsarTipoEntidad = true;
         this.ayudaENTC_CodEjecutivo.Value = null;
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
         this.tableDatosGenerales.Controls.Add(this.txaNVIA_Codigo, 1, 0);
         this.tableDatosGenerales.Controls.Add(this.label1, 0, 0);
         this.tableDatosGenerales.Controls.Add(this.label36, 0, 2);
         this.tableDatosGenerales.Controls.Add(this.txtENTC_NomTransportista, 1, 2);
         this.tableDatosGenerales.Controls.Add(this.label58, 3, 2);
         this.tableDatosGenerales.Controls.Add(this.cmbTIPO_CodTRF, 4, 2);
         this.tableDatosGenerales.Controls.Add(this.lblNAVE_Nombre, 3, 1);
         this.tableDatosGenerales.Controls.Add(this.txtNAVE_Nombre, 4, 1);
         this.tableDatosGenerales.Controls.Add(this.txaNVIA_NroViaje, 1, 1);
         this.tableDatosGenerales.Controls.Add(this.lblNVIA_NroViaje, 0, 1);
         this.tableDatosGenerales.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableDatosGenerales.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableDatosGenerales.Location = new System.Drawing.Point(0, 131);
         this.tableDatosGenerales.Name = "tableDatosGenerales";
         this.tableDatosGenerales.RowCount = 3;
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.Size = new System.Drawing.Size(735, 81);
         this.tableDatosGenerales.TabIndex = 2;
         this.tableDatosGenerales.Visible = false;
         // 
         // txaNVIA_Codigo
         // 
         this.txaNVIA_Codigo.ActivarAyudaAuto = false;
         this.txaNVIA_Codigo.EMPR_Codigo = ((short)(0));
         this.txaNVIA_Codigo.EnabledAyuda = true;
         this.txaNVIA_Codigo.EnabledAyudaButton = true;
         this.txaNVIA_Codigo.ENTC_CodTranportista = null;
         this.txaNVIA_Codigo.EsFiltro = false;
         this.txaNVIA_Codigo.Location = new System.Drawing.Point(153, 3);
         this.txaNVIA_Codigo.LongitudAceptada = 0;
         this.txaNVIA_Codigo.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
         this.txaNVIA_Codigo.Name = "txaNVIA_Codigo";
         this.txaNVIA_Codigo.RellenaCeros = false;
         this.txaNVIA_Codigo.Size = new System.Drawing.Size(194, 20);
         this.txaNVIA_Codigo.SUCR_Codigo = ((short)(0));
         this.txaNVIA_Codigo.TabIndex = 71;
         this.txaNVIA_Codigo.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.Numerico;
         this.txaNVIA_Codigo.TipoAyudaNaveViaje = Delfin.Controls.AyudaViaje.TipoAyuda.Codigo;
         this.txaNVIA_Codigo.Value = null;
         this.txaNVIA_Codigo.Visible = false;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(41, 13);
         this.label1.TabIndex = 70;
         this.label1.Text = "Viaje:";
         this.label1.Visible = false;
         // 
         // label36
         // 
         this.label36.AutoSize = true;
         this.label36.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label36.Location = new System.Drawing.Point(10, 61);
         this.label36.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label36.Name = "label36";
         this.label36.Size = new System.Drawing.Size(42, 13);
         this.label36.TabIndex = 65;
         this.label36.Text = "Línea:";
         this.label36.Visible = false;
         // 
         // txtENTC_NomTransportista
         // 
         this.txtENTC_NomTransportista.Location = new System.Drawing.Point(152, 57);
         this.txtENTC_NomTransportista.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.txtENTC_NomTransportista.Name = "txtENTC_NomTransportista";
         this.txtENTC_NomTransportista.ReadOnly = true;
         this.txtENTC_NomTransportista.Size = new System.Drawing.Size(196, 20);
         this.txtENTC_NomTransportista.TabIndex = 67;
         this.txtENTC_NomTransportista.Tag = "";
         this.txtENTC_NomTransportista.Visible = false;
         // 
         // label58
         // 
         this.label58.AutoSize = true;
         this.label58.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label58.Location = new System.Drawing.Point(375, 61);
         this.label58.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label58.Name = "label58";
         this.label58.Size = new System.Drawing.Size(50, 13);
         this.label58.TabIndex = 63;
         this.label58.Text = "Tráfico:";
         this.label58.Visible = false;
         // 
         // cmbTIPO_CodTRF
         // 
         this.cmbTIPO_CodTRF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodTRF.Enabled = false;
         this.cmbTIPO_CodTRF.FormattingEnabled = true;
         this.cmbTIPO_CodTRF.Location = new System.Drawing.Point(518, 57);
         this.cmbTIPO_CodTRF.Name = "cmbTIPO_CodTRF";
         this.cmbTIPO_CodTRF.Session = null;
         this.cmbTIPO_CodTRF.Size = new System.Drawing.Size(193, 21);
         this.cmbTIPO_CodTRF.TabIndex = 64;
         this.cmbTIPO_CodTRF.TiposSelectedItem = null;
         this.cmbTIPO_CodTRF.TiposSelectedValue = null;
         this.cmbTIPO_CodTRF.TiposTitulo = null;
         this.cmbTIPO_CodTRF.Visible = false;
         // 
         // lblNAVE_Nombre
         // 
         this.lblNAVE_Nombre.AutoSize = true;
         this.lblNAVE_Nombre.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblNAVE_Nombre.Location = new System.Drawing.Point(375, 34);
         this.lblNAVE_Nombre.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblNAVE_Nombre.Name = "lblNAVE_Nombre";
         this.lblNAVE_Nombre.Size = new System.Drawing.Size(41, 13);
         this.lblNAVE_Nombre.TabIndex = 60;
         this.lblNAVE_Nombre.Text = "Nave:";
         this.lblNAVE_Nombre.Visible = false;
         // 
         // txtNAVE_Nombre
         // 
         this.txtNAVE_Nombre.Location = new System.Drawing.Point(517, 30);
         this.txtNAVE_Nombre.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.txtNAVE_Nombre.Name = "txtNAVE_Nombre";
         this.txtNAVE_Nombre.ReadOnly = true;
         this.txtNAVE_Nombre.Size = new System.Drawing.Size(196, 20);
         this.txtNAVE_Nombre.TabIndex = 69;
         this.txtNAVE_Nombre.Tag = "";
         this.txtNAVE_Nombre.Visible = false;
         // 
         // txaNVIA_NroViaje
         // 
         this.txaNVIA_NroViaje.ActivarAyudaAuto = false;
         this.txaNVIA_NroViaje.EMPR_Codigo = ((short)(0));
         this.txaNVIA_NroViaje.EnabledAyuda = true;
         this.txaNVIA_NroViaje.EnabledAyudaButton = true;
         this.txaNVIA_NroViaje.ENTC_CodTranportista = null;
         this.txaNVIA_NroViaje.EsFiltro = false;
         this.txaNVIA_NroViaje.Location = new System.Drawing.Point(153, 30);
         this.txaNVIA_NroViaje.LongitudAceptada = 0;
         this.txaNVIA_NroViaje.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
         this.txaNVIA_NroViaje.Name = "txaNVIA_NroViaje";
         this.txaNVIA_NroViaje.RellenaCeros = false;
         this.txaNVIA_NroViaje.Size = new System.Drawing.Size(194, 20);
         this.txaNVIA_NroViaje.SUCR_Codigo = ((short)(0));
         this.txaNVIA_NroViaje.TabIndex = 68;
         this.txaNVIA_NroViaje.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
         this.txaNVIA_NroViaje.TipoAyudaNaveViaje = Delfin.Controls.AyudaViaje.TipoAyuda.NroViaje;
         this.txaNVIA_NroViaje.Value = null;
         this.txaNVIA_NroViaje.Visible = false;
         // 
         // lblNVIA_NroViaje
         // 
         this.lblNVIA_NroViaje.AutoSize = true;
         this.lblNVIA_NroViaje.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblNVIA_NroViaje.Location = new System.Drawing.Point(10, 34);
         this.lblNVIA_NroViaje.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblNVIA_NroViaje.Name = "lblNVIA_NroViaje";
         this.lblNVIA_NroViaje.Size = new System.Drawing.Size(65, 13);
         this.lblNVIA_NroViaje.TabIndex = 61;
         this.lblNVIA_NroViaje.Text = "Nro Viaje:";
         this.lblNVIA_NroViaje.Visible = false;
         // 
         // COM012MView
         // 
         this.AcceptButton = this.btnProcesar;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.CancelButton = this.btnSalir;
         this.ClientSize = new System.Drawing.Size(735, 131);
         this.Controls.Add(this.tableDatosGenerales);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "COM012MView";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "CÁLCULO DE COMISIONES";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).EndInit();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.tableDatosGenerales.ResumeLayout(false);
         this.tableDatosGenerales.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }



      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnProcesar;
      private System.Windows.Forms.ErrorProvider errorProviderCab_Cotizacion_OV;
      private System.Windows.Forms.ErrorProvider errorProviderDet_Cotizacion_OV_Novedad;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.TableLayoutPanel tableDatosGenerales;
      private Controls.AyudaViaje txaNVIA_Codigo;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label36;
      private System.Windows.Forms.TextBox txtENTC_NomTransportista;
      private System.Windows.Forms.Label label58;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodTRF;
      private System.Windows.Forms.Label lblNAVE_Nombre;
      private System.Windows.Forms.TextBox txtNAVE_Nombre;
      private Controls.AyudaViaje txaNVIA_NroViaje;
      private System.Windows.Forms.Label lblNVIA_NroViaje;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label lblFechaIniEmbarque;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaIniEmbarque;
      private System.Windows.Forms.Label lblFechaFinEmbarque;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaFinEmbarque;
      private System.Windows.Forms.Label lblFechaIniLlegada;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaIniLlegada;
      private System.Windows.Forms.Label lblFechaFinLlegada;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaFinLlegada;
      private System.Windows.Forms.Label lblENTC_CodEjecutivo;
      private Controls.Entidad ayudaENTC_CodEjecutivo;
   }
}