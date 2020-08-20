namespace Delfin.Principal
{
   partial class OPE009View
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
            this.btnCargar = new System.Windows.Forms.Button();
            this.errorProviderCab_Cotizacion_OV = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderDet_Cotizacion_OV_Novedad = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorEventoTarea = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableDatosGenerales = new System.Windows.Forms.TableLayoutPanel();
            this.txaNVIA_Codigo = new Delfin.Controls.AyudaViaje();
            this.txtCCOT_NumDoc = new System.Windows.Forms.TextBox();
            this.lblCCOT_NumDoc = new System.Windows.Forms.Label();
            this.lblENTC_CodCliente = new System.Windows.Forms.Label();
            this.lblNAVE_Nombre = new System.Windows.Forms.Label();
            this.txaENTC_CodCliente = new Delfin.Controls.Entidad(this.components);
            this.txaENTC_CodAgente = new Delfin.Controls.Entidad(this.components);
            this.lblENTC_CodAgente = new System.Windows.Forms.Label();
            this.lblENTC_CodTransportista = new System.Windows.Forms.Label();
            this.txaENTC_CodTransportista = new Delfin.Controls.Entidad(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.mdtREPO_FechaInicio = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.label4 = new System.Windows.Forms.Label();
            this.mdtREPO_FechaTermino = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblCONS_CodRGM = new System.Windows.Forms.Label();
            this.cmbCONS_CodRGM = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblCONS_CodLNG = new System.Windows.Forms.Label();
            this.cmbCONS_CodLNG = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblCONS_CodVia = new System.Windows.Forms.Label();
            this.cmbCONS_CodVia = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.txtNVIA_NroViaje = new System.Windows.Forms.TextBox();
            this.txtNAVE_Nombre = new System.Windows.Forms.TextBox();
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
            this.panel3.Controls.Add(this.btnCargar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(737, 50);
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
            this.tableDatosGenerales.Controls.Add(this.txaNVIA_Codigo, 1, 2);
            this.tableDatosGenerales.Controls.Add(this.txtCCOT_NumDoc, 4, 1);
            this.tableDatosGenerales.Controls.Add(this.lblCCOT_NumDoc, 3, 1);
            this.tableDatosGenerales.Controls.Add(this.lblENTC_CodCliente, 0, 3);
            this.tableDatosGenerales.Controls.Add(this.lblNAVE_Nombre, 0, 2);
            this.tableDatosGenerales.Controls.Add(this.txaENTC_CodCliente, 1, 3);
            this.tableDatosGenerales.Controls.Add(this.txaENTC_CodAgente, 1, 4);
            this.tableDatosGenerales.Controls.Add(this.lblENTC_CodAgente, 0, 4);
            this.tableDatosGenerales.Controls.Add(this.lblENTC_CodTransportista, 0, 5);
            this.tableDatosGenerales.Controls.Add(this.txaENTC_CodTransportista, 1, 5);
            this.tableDatosGenerales.Controls.Add(this.label3, 0, 6);
            this.tableDatosGenerales.Controls.Add(this.mdtREPO_FechaInicio, 1, 6);
            this.tableDatosGenerales.Controls.Add(this.label4, 3, 6);
            this.tableDatosGenerales.Controls.Add(this.mdtREPO_FechaTermino, 4, 6);
            this.tableDatosGenerales.Controls.Add(this.lblCONS_CodRGM, 3, 0);
            this.tableDatosGenerales.Controls.Add(this.cmbCONS_CodRGM, 4, 0);
            this.tableDatosGenerales.Controls.Add(this.lblCONS_CodLNG, 0, 0);
            this.tableDatosGenerales.Controls.Add(this.cmbCONS_CodLNG, 1, 0);
            this.tableDatosGenerales.Controls.Add(this.lblCONS_CodVia, 0, 1);
            this.tableDatosGenerales.Controls.Add(this.cmbCONS_CodVia, 1, 1);
            this.tableDatosGenerales.Controls.Add(this.txtNVIA_NroViaje, 3, 2);
            this.tableDatosGenerales.Controls.Add(this.txtNAVE_Nombre, 4, 2);
            this.tableDatosGenerales.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableDatosGenerales.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableDatosGenerales.Location = new System.Drawing.Point(0, 50);
            this.tableDatosGenerales.Name = "tableDatosGenerales";
            this.tableDatosGenerales.RowCount = 7;
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.Size = new System.Drawing.Size(737, 189);
            this.tableDatosGenerales.TabIndex = 1;
            // 
            // txaNVIA_Codigo
            // 
            this.txaNVIA_Codigo.ActivarAyudaAuto = false;
            this.txaNVIA_Codigo.EMPR_Codigo = ((short)(0));
            this.txaNVIA_Codigo.EnabledAyuda = true;
            this.txaNVIA_Codigo.EnabledAyudaButton = true;
            this.txaNVIA_Codigo.ENTC_CodTranportista = null;
            this.txaNVIA_Codigo.EsFiltro = false;
            this.txaNVIA_Codigo.FechaDesde = null;
            this.txaNVIA_Codigo.Location = new System.Drawing.Point(153, 57);
            this.txaNVIA_Codigo.LongitudAceptada = 0;
            this.txaNVIA_Codigo.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
            this.txaNVIA_Codigo.Name = "txaNVIA_Codigo";
            this.txaNVIA_Codigo.RellenaCeros = false;
            this.txaNVIA_Codigo.Size = new System.Drawing.Size(194, 20);
            this.txaNVIA_Codigo.SUCR_Codigo = ((short)(0));
            this.txaNVIA_Codigo.TabIndex = 2;
            this.txaNVIA_Codigo.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.Numerico;
            this.txaNVIA_Codigo.TipoAyudaNaveViaje = Delfin.Controls.AyudaViaje.TipoAyuda.Codigo;
            this.txaNVIA_Codigo.Value = null;
            // 
            // txtCCOT_NumDoc
            // 
            this.txtCCOT_NumDoc.Location = new System.Drawing.Point(518, 30);
            this.txtCCOT_NumDoc.MaxLength = 50;
            this.txtCCOT_NumDoc.Name = "txtCCOT_NumDoc";
            this.txtCCOT_NumDoc.Size = new System.Drawing.Size(194, 20);
            this.txtCCOT_NumDoc.TabIndex = 104;
            this.txtCCOT_NumDoc.Tag = "CCOT_NumDoc";
            // 
            // lblCCOT_NumDoc
            // 
            this.lblCCOT_NumDoc.AutoSize = true;
            this.lblCCOT_NumDoc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCOT_NumDoc.Location = new System.Drawing.Point(375, 34);
            this.lblCCOT_NumDoc.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCCOT_NumDoc.Name = "lblCCOT_NumDoc";
            this.lblCCOT_NumDoc.Size = new System.Drawing.Size(84, 13);
            this.lblCCOT_NumDoc.TabIndex = 103;
            this.lblCCOT_NumDoc.Text = "Número O.V.:";
            // 
            // lblENTC_CodCliente
            // 
            this.lblENTC_CodCliente.AutoSize = true;
            this.lblENTC_CodCliente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_CodCliente.Location = new System.Drawing.Point(10, 88);
            this.lblENTC_CodCliente.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblENTC_CodCliente.Name = "lblENTC_CodCliente";
            this.lblENTC_CodCliente.Size = new System.Drawing.Size(52, 13);
            this.lblENTC_CodCliente.TabIndex = 24;
            this.lblENTC_CodCliente.Text = "Cliente:";
            // 
            // lblNAVE_Nombre
            // 
            this.lblNAVE_Nombre.AutoSize = true;
            this.lblNAVE_Nombre.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNAVE_Nombre.Location = new System.Drawing.Point(10, 61);
            this.lblNAVE_Nombre.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblNAVE_Nombre.Name = "lblNAVE_Nombre";
            this.lblNAVE_Nombre.Size = new System.Drawing.Size(121, 13);
            this.lblNAVE_Nombre.TabIndex = 134;
            this.lblNAVE_Nombre.Text = "Viaje (Nro. - Nave):";
            // 
            // txaENTC_CodCliente
            // 
            this.txaENTC_CodCliente.ActivarAyudaAuto = false;
            this.tableDatosGenerales.SetColumnSpan(this.txaENTC_CodCliente, 4);
            this.txaENTC_CodCliente.ContainerService = null;
            this.txaENTC_CodCliente.EnabledAyudaButton = true;
            this.txaENTC_CodCliente.Location = new System.Drawing.Point(152, 84);
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
            // txaENTC_CodAgente
            // 
            this.txaENTC_CodAgente.ActivarAyudaAuto = false;
            this.tableDatosGenerales.SetColumnSpan(this.txaENTC_CodAgente, 4);
            this.txaENTC_CodAgente.ContainerService = null;
            this.txaENTC_CodAgente.EnabledAyudaButton = true;
            this.txaENTC_CodAgente.Location = new System.Drawing.Point(152, 111);
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
            // lblENTC_CodAgente
            // 
            this.lblENTC_CodAgente.AutoSize = true;
            this.lblENTC_CodAgente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_CodAgente.Location = new System.Drawing.Point(10, 115);
            this.lblENTC_CodAgente.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblENTC_CodAgente.Name = "lblENTC_CodAgente";
            this.lblENTC_CodAgente.Size = new System.Drawing.Size(52, 13);
            this.lblENTC_CodAgente.TabIndex = 26;
            this.lblENTC_CodAgente.Tag = "MSGERROR";
            this.lblENTC_CodAgente.Text = "Agente:";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Desde:";
            // 
            // mdtREPO_FechaInicio
            // 
            this.mdtREPO_FechaInicio.Location = new System.Drawing.Point(153, 165);
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
            this.label4.Location = new System.Drawing.Point(375, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 80;
            this.label4.Text = "Hasta:";
            // 
            // mdtREPO_FechaTermino
            // 
            this.mdtREPO_FechaTermino.Location = new System.Drawing.Point(518, 165);
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
            // lblCONS_CodRGM
            // 
            this.lblCONS_CodRGM.AutoSize = true;
            this.lblCONS_CodRGM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodRGM.Location = new System.Drawing.Point(375, 7);
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
            this.cmbCONS_CodRGM.Location = new System.Drawing.Point(517, 3);
            this.cmbCONS_CodRGM.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbCONS_CodRGM.Name = "cmbCONS_CodRGM";
            this.cmbCONS_CodRGM.Session = null;
            this.cmbCONS_CodRGM.Size = new System.Drawing.Size(194, 21);
            this.cmbCONS_CodRGM.TabIndex = 62;
            this.cmbCONS_CodRGM.Tag = "CONS_CodRGMMSGERROR";
            // 
            // lblCONS_CodLNG
            // 
            this.lblCONS_CodLNG.AutoSize = true;
            this.lblCONS_CodLNG.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodLNG.Location = new System.Drawing.Point(10, 7);
            this.lblCONS_CodLNG.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONS_CodLNG.Name = "lblCONS_CodLNG";
            this.lblCONS_CodLNG.Size = new System.Drawing.Size(91, 13);
            this.lblCONS_CodLNG.TabIndex = 65;
            this.lblCONS_CodLNG.Text = "Línea Negocio:";
            // 
            // cmbCONS_CodLNG
            // 
            this.cmbCONS_CodLNG.ConstantesSelectedItem = null;
            this.cmbCONS_CodLNG.ConstantesSelectedValue = null;
            this.cmbCONS_CodLNG.ConstantesTitulo = null;
            this.cmbCONS_CodLNG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCONS_CodLNG.FormattingEnabled = true;
            this.cmbCONS_CodLNG.Location = new System.Drawing.Point(153, 3);
            this.cmbCONS_CodLNG.Name = "cmbCONS_CodLNG";
            this.cmbCONS_CodLNG.Session = null;
            this.cmbCONS_CodLNG.Size = new System.Drawing.Size(194, 21);
            this.cmbCONS_CodLNG.TabIndex = 66;
            this.cmbCONS_CodLNG.Tag = "CONS_CodLNGMSGERROR";
            // 
            // lblCONS_CodVia
            // 
            this.lblCONS_CodVia.AutoSize = true;
            this.lblCONS_CodVia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodVia.Location = new System.Drawing.Point(10, 34);
            this.lblCONS_CodVia.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblCONS_CodVia.Name = "lblCONS_CodVia";
            this.lblCONS_CodVia.Size = new System.Drawing.Size(30, 13);
            this.lblCONS_CodVia.TabIndex = 63;
            this.lblCONS_CodVia.Text = "Vía:";
            // 
            // cmbCONS_CodVia
            // 
            this.cmbCONS_CodVia.ConstantesSelectedItem = null;
            this.cmbCONS_CodVia.ConstantesSelectedValue = null;
            this.cmbCONS_CodVia.ConstantesTitulo = null;
            this.cmbCONS_CodVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCONS_CodVia.FormattingEnabled = true;
            this.cmbCONS_CodVia.Location = new System.Drawing.Point(152, 30);
            this.cmbCONS_CodVia.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbCONS_CodVia.Name = "cmbCONS_CodVia";
            this.cmbCONS_CodVia.Session = null;
            this.cmbCONS_CodVia.Size = new System.Drawing.Size(194, 21);
            this.cmbCONS_CodVia.TabIndex = 64;
            this.cmbCONS_CodVia.Tag = "CONS_CodViaMSGERROR";
            // 
            // txtNVIA_NroViaje
            // 
            this.txtNVIA_NroViaje.Location = new System.Drawing.Point(368, 57);
            this.txtNVIA_NroViaje.MaxLength = 50;
            this.txtNVIA_NroViaje.Name = "txtNVIA_NroViaje";
            this.txtNVIA_NroViaje.Size = new System.Drawing.Size(144, 20);
            this.txtNVIA_NroViaje.TabIndex = 137;
            this.txtNVIA_NroViaje.Tag = "CCOT_NumDoc";
            // 
            // txtNAVE_Nombre
            // 
            this.txtNAVE_Nombre.Location = new System.Drawing.Point(518, 57);
            this.txtNAVE_Nombre.MaxLength = 50;
            this.txtNAVE_Nombre.Name = "txtNAVE_Nombre";
            this.txtNAVE_Nombre.Size = new System.Drawing.Size(194, 20);
            this.txtNAVE_Nombre.TabIndex = 138;
            this.txtNAVE_Nombre.Tag = "CCOT_NumDoc";
            // 
            // OPE009View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(737, 244);
            this.Controls.Add(this.tableDatosGenerales);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OPE009View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STATEMENT CHANGE CONTROL";
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
      private System.Windows.Forms.Label lblCONS_CodLNG;
      private Controls.Tipos.ComboBoxConstantes cmbCONS_CodLNG;
      private Controls.Tipos.ComboBoxConstantes cmbCONS_CodVia;
      private System.Windows.Forms.Label lblCONS_CodVia;
      private System.Windows.Forms.Label lblCONS_CodRGM;
      private Controls.Tipos.ComboBoxConstantes cmbCONS_CodRGM;
      private Controls.Entidad txaENTC_CodAgente;
      private System.Windows.Forms.Label lblENTC_CodAgente;
      private Controls.Entidad txaENTC_CodCliente;
      private System.Windows.Forms.Label lblENTC_CodCliente;
      private Controls.Entidad txaENTC_CodTransportista;
      private System.Windows.Forms.Label lblENTC_CodTransportista;
      private System.Windows.Forms.Label label3;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtREPO_FechaInicio;
      private System.Windows.Forms.Label label4;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtREPO_FechaTermino;
      private System.Windows.Forms.TextBox txtCCOT_NumDoc;
      private System.Windows.Forms.Label lblCCOT_NumDoc;
      private System.Windows.Forms.Label lblNAVE_Nombre;
      private System.Windows.Forms.TextBox txtNVIA_NroViaje;
      private System.Windows.Forms.TextBox txtNAVE_Nombre;
      private Controls.AyudaViaje txaNVIA_Codigo;
   }
}