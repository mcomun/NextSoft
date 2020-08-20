namespace Delfin.Comercial
{
   partial class COM007OView
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
         System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Documento de Transporte");
         System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Manifiesto de Carga");
         System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Documento Nacional de Identidad - DNI");
         System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Registro Único de Contribuyente - RUC");
         System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Comunicación de Origen Proveedor");
         System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Comunicación de Origen Embarcador");
         System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Acta de Reconocimiento Previo");
         System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Factura Comercial / Declaración Jurada");
         System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Especificaciones Técnicas");
         System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Liquidación de Cobranza Cancelada");
         System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("Volante de Despacho");
         System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("Declaración Aduanera Autenticada");
         System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("Nota de tarja / Tarja al Detalle");
         System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("Lista de Embarque");
         System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("Documento de Puerto / Aereopuerto / Terminal");
         System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("Certificado de Peso");
         System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("Ticket de Balanza");
         System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("Otros");
         this.errorProviderCab_Cotizacion_OV = new System.Windows.Forms.ErrorProvider(this.components);
         this.tabCab_Cotizacion_OV = new Dotnetrix.Controls.TabControlEX();
         this.pageGenerales = new Dotnetrix.Controls.TabPageEX();
         this.tableDatosGenerales = new System.Windows.Forms.TableLayoutPanel();
         this.ENTC_EMail = new System.Windows.Forms.TextBox();
         this.ENTC_Contacto = new System.Windows.Forms.TextBox();
         this.CCOT_NumDocCOT = new System.Windows.Forms.TextBox();
         this.lblENTC_EMail = new System.Windows.Forms.Label();
         this.lblENTC_CodContacto = new System.Windows.Forms.Label();
         this.lblCCOT_NumDocCOT = new System.Windows.Forms.Label();
         this.lblCCOT_Version = new System.Windows.Forms.Label();
         this.CCOT_Version = new System.Windows.Forms.TextBox();
         this.lblCONS_CodESTCOT = new System.Windows.Forms.Label();
         this.CONS_CodESTCOT = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblCCOT_NumDocOV = new System.Windows.Forms.Label();
         this.CCOT_NumDocOV = new System.Windows.Forms.TextBox();
         this.lblCCOT_NumDocCOT2 = new System.Windows.Forms.Label();
         this.CCOT_NumDocCOT2 = new System.Windows.Forms.TextBox();
         this.lblCONS_CodESTOV = new System.Windows.Forms.Label();
         this.CONS_CodESTOV = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblCCOT_FecEmi = new System.Windows.Forms.Label();
         this.CCOT_FecEmi = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblCCOT_FecVcto = new System.Windows.Forms.Label();
         this.CCOT_FecVcto = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblENTC_CodCustomer = new System.Windows.Forms.Label();
         this.ENTC_CodCustomer = new Delfin.Controls.Entidad(this.components);
         this.lblENTC_CodBroker = new System.Windows.Forms.Label();
         this.ENTC_CodBroker = new Delfin.Controls.Entidad(this.components);
         this.lblENTC_CodEjecutivo = new System.Windows.Forms.Label();
         this.ENTC_CodEjecutivo = new Delfin.Controls.Entidad(this.components);
         this.lblENTC_CodAgente = new System.Windows.Forms.Label();
         this.ENTC_CodAgente = new Delfin.Controls.Entidad(this.components);
         this.lblCONS_CodRGM = new System.Windows.Forms.Label();
         this.cmbCONS_CodRGM = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblCONS_CodVia = new System.Windows.Forms.Label();
         this.cmbCONS_CodVia = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblENTC_CodCliente = new System.Windows.Forms.Label();
         this.ENTC_CodCliente = new Delfin.Controls.Entidad(this.components);
         this.lblCCOT_FecAprueba = new System.Windows.Forms.Label();
         this.CCOT_FecAprueba = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblCCOT_Propia = new System.Windows.Forms.Label();
         this.CCOT_Propia = new System.Windows.Forms.CheckBox();
         this.lblCCOT_ServicioLogistico = new System.Windows.Forms.Label();
         this.CCOT_ServicioLogistico = new System.Windows.Forms.CheckBox();
         this.label5 = new System.Windows.Forms.Label();
         this.checkBox3 = new System.Windows.Forms.CheckBox();
         this.label9 = new System.Windows.Forms.Label();
         this.checkBox6 = new System.Windows.Forms.CheckBox();
         this.label2 = new System.Windows.Forms.Label();
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this.label4 = new System.Windows.Forms.Label();
         this.checkBox2 = new System.Windows.Forms.CheckBox();
         this.label6 = new System.Windows.Forms.Label();
         this.checkBox4 = new System.Windows.Forms.CheckBox();
         this.lblTIPO_CodINC = new System.Windows.Forms.Label();
         this.TIPO_CodINC = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.label26 = new System.Windows.Forms.Label();
         this.maskDateTime2 = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnEditarContacto = new System.Windows.Forms.Button();
         this.btnNuevoContacto = new System.Windows.Forms.Button();
         this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.ENTC_Cargo = new System.Windows.Forms.TextBox();
         this.lblENTC_Cargo = new System.Windows.Forms.Label();
         this.label31 = new System.Windows.Forms.Label();
         this.checkBox11 = new System.Windows.Forms.CheckBox();
         this.label30 = new System.Windows.Forms.Label();
         this.checkBox10 = new System.Windows.Forms.CheckBox();
         this.label29 = new System.Windows.Forms.Label();
         this.checkBox9 = new System.Windows.Forms.CheckBox();
         this.label28 = new System.Windows.Forms.Label();
         this.checkBox8 = new System.Windows.Forms.CheckBox();
         this.label27 = new System.Windows.Forms.Label();
         this.checkBox7 = new System.Windows.Forms.CheckBox();
         this.label7 = new System.Windows.Forms.Label();
         this.checkBox5 = new System.Windows.Forms.CheckBox();
         this.label32 = new System.Windows.Forms.Label();
         this.checkBox12 = new System.Windows.Forms.CheckBox();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.pageServiciosTarifa = new Dotnetrix.Controls.TabPageEX();
         this.tabServiciosAdicionales = new Dotnetrix.Controls.TabControlEX();
         this.pageServicios = new Dotnetrix.Controls.TabPageEX();
         this.btnAddServicio = new System.Windows.Forms.Button();
         this.grdItemsServicio = new Telerik.WinControls.UI.RadGridView();
         this.btnDelServicio = new System.Windows.Forms.Button();
         this.panelCaption5 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.pageChangeControl = new Dotnetrix.Controls.TabPageEX();
         this.grdServiciosChangeControl = new Telerik.WinControls.UI.RadGridView();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.panelCaption16 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.panel1 = new System.Windows.Forms.Panel();
         this.grdItemsFlete = new Telerik.WinControls.UI.RadGridView();
         this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
         this.lblCCOT_PagoMBL = new System.Windows.Forms.Label();
         this.CCOT_PagoMBL = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
         this.lblCCOT_PagoHBL = new System.Windows.Forms.Label();
         this.CCOT_PagoHBL = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
         this.lblDCOT_Importe = new System.Windows.Forms.Label();
         this.DCOT_Importe = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblDCOT_Rentabilidad = new System.Windows.Forms.Label();
         this.DCOT_Rentabilidad = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.panel8 = new System.Windows.Forms.Panel();
         this.btnDelFlete = new System.Windows.Forms.Button();
         this.btnAddFlete = new System.Windows.Forms.Button();
         this.panelCaption4 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
         this.panel2 = new System.Windows.Forms.Panel();
         this.CONT_Numero = new Infrastructure.WinForms.Controls.TextBoxAyuda(this.components);
         this.btnCambiarContrato = new System.Windows.Forms.Button();
         this.label19 = new System.Windows.Forms.Label();
         this.ENTC_CodTransportista = new Delfin.Controls.Entidad(this.components);
         this.lblENTC_CodTransportista = new System.Windows.Forms.Label();
         this.lblPUER_CodOrigen = new System.Windows.Forms.Label();
         this.ayudaPuerto1 = new Delfin.Controls.AyudaPuerto();
         this.lblPUER_CodDestino = new System.Windows.Forms.Label();
         this.ayudaPuerto2 = new Delfin.Controls.AyudaPuerto();
         this.lblPUER_CodTrasbordo = new System.Windows.Forms.Label();
         this.ayudaPuerto3 = new Delfin.Controls.AyudaPuerto();
         this.label34 = new System.Windows.Forms.Label();
         this.maskDateTime3 = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.label35 = new System.Windows.Forms.Label();
         this.maskDateTime4 = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.label8 = new System.Windows.Forms.Label();
         this.maskDateTime1 = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblCONS_CodTFT = new System.Windows.Forms.Label();
         this.CONS_CodTFT = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblCCOT_FecTarifa = new System.Windows.Forms.Label();
         this.CCOT_FecTarifa = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblTIPO_CodMND = new System.Windows.Forms.Label();
         this.TIPO_CodMND = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.lblCONT_Numero = new System.Windows.Forms.Label();
         this.CONT_Descrip = new System.Windows.Forms.TextBox();
         this.lblCONS_CodFLE = new System.Windows.Forms.Label();
         this.CONS_CodFLE = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.pageEmbarque = new Dotnetrix.Controls.TabPageEX();
         this.tabControlEX1 = new Dotnetrix.Controls.TabControlEX();
         this.tabPageEX1 = new Dotnetrix.Controls.TabPageEX();
         this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
         this.CCOT_Roundtrip = new System.Windows.Forms.CheckBox();
         this.lblCCOT_Roundtrip = new System.Windows.Forms.Label();
         this.CCOT_Temperatura = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblCCOT_Temperatura = new System.Windows.Forms.Label();
         this.CCOT_CargaRefrigerada = new System.Windows.Forms.CheckBox();
         this.lblCCOT_CargaRefrigerada = new System.Windows.Forms.Label();
         this.TIPO_CodImo = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.CCOT_CargaPeligrosa = new System.Windows.Forms.CheckBox();
         this.lblCCOT_CargaPeligrosa = new System.Windows.Forms.Label();
         this.lblTIPO_CodImo = new System.Windows.Forms.Label();
         this.lblCCOT_ValidezOferta = new System.Windows.Forms.Label();
         this.CCOT_ValidezOferta = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblCCOT_SobreEstadia = new System.Windows.Forms.Label();
         this.CCOT_SobreEstadia = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblCCOT_TiempoViaje = new System.Windows.Forms.Label();
         this.CCOT_TiempoViaje = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblCCOT_Almacenaje = new System.Windows.Forms.Label();
         this.CCOT_Almacenaje = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.label1 = new System.Windows.Forms.Label();
         this.CCOT_Observaciones = new System.Windows.Forms.TextBox();
         this.panelCaption9 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableDatosViaje = new System.Windows.Forms.TableLayoutPanel();
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this.lblNVIA_FecETDMaster = new System.Windows.Forms.Label();
         this.label36 = new System.Windows.Forms.Label();
         this.NVIA_FecETDMaster = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblNVIA_FecCutOff = new System.Windows.Forms.Label();
         this.textBoxAyuda1 = new Infrastructure.WinForms.Controls.TextBoxAyuda(this.components);
         this.NVIA_FecCutOff = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblDOOV_Feeder_IMPO = new System.Windows.Forms.Label();
         this.DOOV_Feeder_IMPO = new System.Windows.Forms.TextBox();
         this.lblNVIA_NroViaje = new System.Windows.Forms.Label();
         this.NVIA_NroViaje = new Infrastructure.WinForms.Controls.TextBoxAyuda(this.components);
         this.lblNVIA_FecETA = new System.Windows.Forms.Label();
         this.NVIA_FecETA = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.DOOV_FecETDFeeder_IMPO = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblDOOV_FecETDFeeder_IMPO = new System.Windows.Forms.Label();
         this.lblNAVE_Nombre = new System.Windows.Forms.Label();
         this.panel10 = new System.Windows.Forms.Panel();
         this.btnAddNaveViaje = new System.Windows.Forms.Button();
         this.btnEditarNaveViaje = new System.Windows.Forms.Button();
         this.panelCaption10 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
         this.TIPO_CodDTM = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.lblTIPO_CodDTM = new System.Windows.Forms.Label();
         this.DOOV_MBL = new System.Windows.Forms.TextBox();
         this.lblDOOV_Cntr = new System.Windows.Forms.Label();
         this.DOOV_Cntr = new System.Windows.Forms.TextBox();
         this.lblDOOV_MBL = new System.Windows.Forms.Label();
         this.lblDOOV_HBL = new System.Windows.Forms.Label();
         this.DOOV_HBL = new System.Windows.Forms.TextBox();
         this.label38 = new System.Windows.Forms.Label();
         this.textBox11 = new System.Windows.Forms.TextBox();
         this.panelCaption12 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tabPageEX2 = new Dotnetrix.Controls.TabPageEX();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.textBox3 = new System.Windows.Forms.TextBox();
         this.label10 = new System.Windows.Forms.Label();
         this.ENTC_CodNotify = new Delfin.Controls.Entidad(this.components);
         this.ENTC_CodConsignee = new Delfin.Controls.Entidad(this.components);
         this.ENTC_CodShipper = new Delfin.Controls.Entidad(this.components);
         this.label11 = new System.Windows.Forms.Label();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.label13 = new System.Windows.Forms.Label();
         this.textBox4 = new System.Windows.Forms.TextBox();
         this.label37 = new System.Windows.Forms.Label();
         this.entidad1 = new Delfin.Controls.Entidad(this.components);
         this.textBox10 = new System.Windows.Forms.TextBox();
         this.lblDOOV_CodReferencia = new System.Windows.Forms.Label();
         this.DOOV_CodReferencia = new System.Windows.Forms.TextBox();
         this.panelCaption8 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.toolStrip4 = new System.Windows.Forms.ToolStrip();
         this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
         this.tabPageEX3 = new Dotnetrix.Controls.TabPageEX();
         this.grdMatrizDetalle = new Telerik.WinControls.UI.RadGridView();
         this.toolStrip2 = new System.Windows.Forms.ToolStrip();
         this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
         this.panelCaption17 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.pageArchivos = new Dotnetrix.Controls.TabPageEX();
         this.grdItemsArchivos = new Telerik.WinControls.UI.RadGridView();
         this.panel4 = new System.Windows.Forms.Panel();
         this.btnDownloadFile = new System.Windows.Forms.Button();
         this.btnUploadFile = new System.Windows.Forms.Button();
         this.panelCaption13 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableArchivo = new System.Windows.Forms.TableLayoutPanel();
         this.lblOVAR_Archivo = new System.Windows.Forms.Label();
         this.OVAR_Archivo = new Infrastructure.WinForms.Controls.TextBoxOpenFile();
         this.panelCaption11 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.pageEventosTareas = new Dotnetrix.Controls.TabPageEX();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.grdItemsNovedades = new Telerik.WinControls.UI.RadGridView();
         this.panel5 = new System.Windows.Forms.Panel();
         this.btnNuevoNovedad = new System.Windows.Forms.Button();
         this.btnEnviarNovedad = new System.Windows.Forms.Button();
         this.panelCaption14 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableNovedad = new System.Windows.Forms.TableLayoutPanel();
         this.lblOVNO_Descrip = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.CONS_CodNot = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.OVNO_Descrip = new System.Windows.Forms.TextBox();
         this.panelCaption15 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.grdItemsEventosTareas = new Telerik.WinControls.UI.RadGridView();
         this.panel9 = new System.Windows.Forms.Panel();
         this.btnNuevoEventoTarea = new System.Windows.Forms.Button();
         this.btnEditarEventoTarea = new System.Windows.Forms.Button();
         this.btnDeshacerEventoTarea = new System.Windows.Forms.Button();
         this.btnEliminarEventoTarea = new System.Windows.Forms.Button();
         this.btnGuardarEventoTarea = new System.Windows.Forms.Button();
         this.panelEventosTareas = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableEventoTarea = new System.Windows.Forms.TableLayoutPanel();
         this.lblTIPO_CodEVE = new System.Windows.Forms.Label();
         this.TIPO_CodEVE = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.panel6 = new System.Windows.Forms.Panel();
         this.EVEN_Cumplida = new System.Windows.Forms.RadioButton();
         this.EVEN_Pendiente = new System.Windows.Forms.RadioButton();
         this.EVEN_Observaciones = new System.Windows.Forms.TextBox();
         this.lblEVEN_Observaciones = new System.Windows.Forms.Label();
         this.lblEVEN_Fecha = new System.Windows.Forms.Label();
         this.EVEN_Fecha = new Infrastructure.WinForms.Controls.MaskTime();
         this.lblEVEN_Cumplida = new System.Windows.Forms.Label();
         this.CONS_CodMOD = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblCONS_CodMOD = new System.Windows.Forms.Label();
         this.lblEVEN_Usuario = new System.Windows.Forms.Label();
         this.EVEN_Usuario = new System.Windows.Forms.TextBox();
         this.panelEventoTarea = new Infrastructure.WinForms.Controls.PanelCaption();
         this.pageRectificaciones = new Dotnetrix.Controls.TabPageEX();
         this.tabRectificaciones = new Dotnetrix.Controls.TabControlEX();
         this.pageDatosRectificacion = new Dotnetrix.Controls.TabPageEX();
         this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
         this.listView1 = new System.Windows.Forms.ListView();
         this.textBox8 = new System.Windows.Forms.TextBox();
         this.label20 = new System.Windows.Forms.Label();
         this.maskTime2 = new Infrastructure.WinForms.Controls.MaskTime();
         this.maskTime4 = new Infrastructure.WinForms.Controls.MaskTime();
         this.label17 = new System.Windows.Forms.Label();
         this.label18 = new System.Windows.Forms.Label();
         this.maskTime1 = new Infrastructure.WinForms.Controls.MaskTime();
         this.maskTime3 = new Infrastructure.WinForms.Controls.MaskTime();
         this.label16 = new System.Windows.Forms.Label();
         this.label15 = new System.Windows.Forms.Label();
         this.label21 = new System.Windows.Forms.Label();
         this.textBox5 = new System.Windows.Forms.TextBox();
         this.textBox6 = new System.Windows.Forms.TextBox();
         this.label22 = new System.Windows.Forms.Label();
         this.textBox7 = new System.Windows.Forms.TextBox();
         this.label23 = new System.Windows.Forms.Label();
         this.textBox9 = new System.Windows.Forms.TextBox();
         this.label24 = new System.Windows.Forms.Label();
         this.label25 = new System.Windows.Forms.Label();
         this.comboBoxTipos1 = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.label14 = new System.Windows.Forms.Label();
         this.label33 = new System.Windows.Forms.Label();
         this.panel7 = new System.Windows.Forms.Panel();
         this.radioButton2 = new System.Windows.Forms.RadioButton();
         this.radioButton1 = new System.Windows.Forms.RadioButton();
         this.pageListRectificaciones = new Dotnetrix.Controls.TabPageEX();
         this.grdListRectificaciones = new Telerik.WinControls.UI.RadGridView();
         this.toolStrip3 = new System.Windows.Forms.ToolStrip();
         this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
         this.panelCaption18 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.errorProviderDet_Cotizacion_OV_Novedad = new System.Windows.Forms.ErrorProvider(this.components);
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.errorEventoTarea = new System.Windows.Forms.ErrorProvider(this.components);
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.btnGuardar = new System.Windows.Forms.ToolStripButton();
         this.btnSalir = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
         this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
         this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
         this.lblCONS_CodLNG = new System.Windows.Forms.Label();
         this.cmbCONS_CodLNG = new Delfin.Controls.Tipos.ComboBoxConstantes();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).BeginInit();
         this.tabCab_Cotizacion_OV.SuspendLayout();
         this.pageGenerales.SuspendLayout();
         this.tableDatosGenerales.SuspendLayout();
         this.panel3.SuspendLayout();
         this.pageServiciosTarifa.SuspendLayout();
         this.tabServiciosAdicionales.SuspendLayout();
         this.pageServicios.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio.MasterTemplate)).BeginInit();
         this.pageChangeControl.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdServiciosChangeControl)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdServiciosChangeControl.MasterTemplate)).BeginInit();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsFlete)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsFlete.MasterTemplate)).BeginInit();
         this.tableLayoutPanel4.SuspendLayout();
         this.panel8.SuspendLayout();
         this.tableLayoutPanel3.SuspendLayout();
         this.panel2.SuspendLayout();
         this.pageEmbarque.SuspendLayout();
         this.tabControlEX1.SuspendLayout();
         this.tabPageEX1.SuspendLayout();
         this.tableLayoutPanel7.SuspendLayout();
         this.tableDatosViaje.SuspendLayout();
         this.panel10.SuspendLayout();
         this.tableLayoutPanel8.SuspendLayout();
         this.tabPageEX2.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         this.toolStrip4.SuspendLayout();
         this.tabPageEX3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdMatrizDetalle)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdMatrizDetalle.MasterTemplate)).BeginInit();
         this.toolStrip2.SuspendLayout();
         this.pageArchivos.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsArchivos)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsArchivos.MasterTemplate)).BeginInit();
         this.panel4.SuspendLayout();
         this.tableArchivo.SuspendLayout();
         this.pageEventosTareas.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsNovedades)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsNovedades.MasterTemplate)).BeginInit();
         this.panel5.SuspendLayout();
         this.tableNovedad.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsEventosTareas)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsEventosTareas.MasterTemplate)).BeginInit();
         this.panel9.SuspendLayout();
         this.tableEventoTarea.SuspendLayout();
         this.panel6.SuspendLayout();
         this.pageRectificaciones.SuspendLayout();
         this.tabRectificaciones.SuspendLayout();
         this.pageDatosRectificacion.SuspendLayout();
         this.tableLayoutPanel9.SuspendLayout();
         this.panel7.SuspendLayout();
         this.pageListRectificaciones.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdListRectificaciones)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdListRectificaciones.MasterTemplate)).BeginInit();
         this.toolStrip3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).BeginInit();
         this.toolStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // errorProviderCab_Cotizacion_OV
         // 
         this.errorProviderCab_Cotizacion_OV.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
         this.errorProviderCab_Cotizacion_OV.ContainerControl = this;
         // 
         // tabCab_Cotizacion_OV
         // 
         this.tabCab_Cotizacion_OV.Controls.Add(this.pageGenerales);
         this.tabCab_Cotizacion_OV.Controls.Add(this.pageServiciosTarifa);
         this.tabCab_Cotizacion_OV.Controls.Add(this.pageEmbarque);
         this.tabCab_Cotizacion_OV.Controls.Add(this.pageArchivos);
         this.tabCab_Cotizacion_OV.Controls.Add(this.pageEventosTareas);
         this.tabCab_Cotizacion_OV.Controls.Add(this.pageRectificaciones);
         this.tabCab_Cotizacion_OV.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabCab_Cotizacion_OV.Location = new System.Drawing.Point(0, 38);
         this.tabCab_Cotizacion_OV.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.tabCab_Cotizacion_OV.Name = "tabCab_Cotizacion_OV";
         this.tabCab_Cotizacion_OV.SelectedIndex = 0;
         this.tabCab_Cotizacion_OV.SelectedTabColor = System.Drawing.Color.SteelBlue;
         this.tabCab_Cotizacion_OV.Size = new System.Drawing.Size(1212, 523);
         this.tabCab_Cotizacion_OV.TabIndex = 1;
         this.tabCab_Cotizacion_OV.UseVisualStyles = false;
         // 
         // pageGenerales
         // 
         this.pageGenerales.Controls.Add(this.tableDatosGenerales);
         this.pageGenerales.Controls.Add(this.panelCaption1);
         this.pageGenerales.Location = new System.Drawing.Point(4, 25);
         this.pageGenerales.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.pageGenerales.Name = "pageGenerales";
         this.pageGenerales.Size = new System.Drawing.Size(1204, 494);
         this.pageGenerales.TabIndex = 0;
         this.pageGenerales.Text = "Datos Generales";
         // 
         // tableDatosGenerales
         // 
         this.tableDatosGenerales.AutoSize = true;
         this.tableDatosGenerales.ColumnCount = 10;
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableDatosGenerales.Controls.Add(this.cmbCONS_CodLNG, 1, 14);
         this.tableDatosGenerales.Controls.Add(this.lblCONS_CodLNG, 0, 14);
         this.tableDatosGenerales.Controls.Add(this.ENTC_EMail, 1, 13);
         this.tableDatosGenerales.Controls.Add(this.ENTC_Contacto, 1, 12);
         this.tableDatosGenerales.Controls.Add(this.CCOT_NumDocCOT, 1, 0);
         this.tableDatosGenerales.Controls.Add(this.lblENTC_CodContacto, 0, 12);
         this.tableDatosGenerales.Controls.Add(this.lblCCOT_NumDocCOT, 0, 0);
         this.tableDatosGenerales.Controls.Add(this.lblCCOT_Version, 3, 0);
         this.tableDatosGenerales.Controls.Add(this.CCOT_Version, 4, 0);
         this.tableDatosGenerales.Controls.Add(this.lblCONS_CodESTCOT, 6, 0);
         this.tableDatosGenerales.Controls.Add(this.CONS_CodESTCOT, 7, 0);
         this.tableDatosGenerales.Controls.Add(this.lblCCOT_NumDocOV, 0, 1);
         this.tableDatosGenerales.Controls.Add(this.CCOT_NumDocOV, 1, 1);
         this.tableDatosGenerales.Controls.Add(this.lblCCOT_NumDocCOT2, 3, 1);
         this.tableDatosGenerales.Controls.Add(this.CCOT_NumDocCOT2, 4, 1);
         this.tableDatosGenerales.Controls.Add(this.lblCONS_CodESTOV, 6, 1);
         this.tableDatosGenerales.Controls.Add(this.CONS_CodESTOV, 7, 1);
         this.tableDatosGenerales.Controls.Add(this.lblCCOT_FecEmi, 0, 2);
         this.tableDatosGenerales.Controls.Add(this.CCOT_FecEmi, 1, 2);
         this.tableDatosGenerales.Controls.Add(this.lblCCOT_FecVcto, 3, 2);
         this.tableDatosGenerales.Controls.Add(this.CCOT_FecVcto, 4, 2);
         this.tableDatosGenerales.Controls.Add(this.lblENTC_CodCustomer, 0, 9);
         this.tableDatosGenerales.Controls.Add(this.ENTC_CodCustomer, 1, 9);
         this.tableDatosGenerales.Controls.Add(this.lblENTC_CodBroker, 0, 8);
         this.tableDatosGenerales.Controls.Add(this.ENTC_CodBroker, 1, 8);
         this.tableDatosGenerales.Controls.Add(this.lblENTC_CodEjecutivo, 0, 7);
         this.tableDatosGenerales.Controls.Add(this.ENTC_CodEjecutivo, 1, 7);
         this.tableDatosGenerales.Controls.Add(this.lblENTC_CodAgente, 0, 6);
         this.tableDatosGenerales.Controls.Add(this.ENTC_CodAgente, 1, 6);
         this.tableDatosGenerales.Controls.Add(this.lblCONS_CodRGM, 0, 5);
         this.tableDatosGenerales.Controls.Add(this.cmbCONS_CodRGM, 1, 5);
         this.tableDatosGenerales.Controls.Add(this.lblCONS_CodVia, 3, 5);
         this.tableDatosGenerales.Controls.Add(this.cmbCONS_CodVia, 4, 5);
         this.tableDatosGenerales.Controls.Add(this.lblENTC_CodCliente, 0, 4);
         this.tableDatosGenerales.Controls.Add(this.ENTC_CodCliente, 1, 4);
         this.tableDatosGenerales.Controls.Add(this.lblCCOT_FecAprueba, 0, 3);
         this.tableDatosGenerales.Controls.Add(this.CCOT_FecAprueba, 1, 3);
         this.tableDatosGenerales.Controls.Add(this.lblCCOT_Propia, 6, 2);
         this.tableDatosGenerales.Controls.Add(this.CCOT_Propia, 7, 2);
         this.tableDatosGenerales.Controls.Add(this.lblCCOT_ServicioLogistico, 6, 3);
         this.tableDatosGenerales.Controls.Add(this.CCOT_ServicioLogistico, 7, 3);
         this.tableDatosGenerales.Controls.Add(this.label5, 6, 4);
         this.tableDatosGenerales.Controls.Add(this.checkBox3, 7, 4);
         this.tableDatosGenerales.Controls.Add(this.label9, 6, 5);
         this.tableDatosGenerales.Controls.Add(this.checkBox6, 7, 5);
         this.tableDatosGenerales.Controls.Add(this.label2, 6, 6);
         this.tableDatosGenerales.Controls.Add(this.checkBox1, 7, 6);
         this.tableDatosGenerales.Controls.Add(this.label4, 6, 7);
         this.tableDatosGenerales.Controls.Add(this.checkBox2, 7, 7);
         this.tableDatosGenerales.Controls.Add(this.label6, 6, 8);
         this.tableDatosGenerales.Controls.Add(this.checkBox4, 7, 8);
         this.tableDatosGenerales.Controls.Add(this.lblTIPO_CodINC, 0, 10);
         this.tableDatosGenerales.Controls.Add(this.TIPO_CodINC, 1, 10);
         this.tableDatosGenerales.Controls.Add(this.label26, 3, 3);
         this.tableDatosGenerales.Controls.Add(this.maskDateTime2, 4, 3);
         this.tableDatosGenerales.Controls.Add(this.panel3, 0, 11);
         this.tableDatosGenerales.Controls.Add(this.ENTC_Cargo, 4, 13);
         this.tableDatosGenerales.Controls.Add(this.lblENTC_Cargo, 3, 13);
         this.tableDatosGenerales.Controls.Add(this.label31, 6, 15);
         this.tableDatosGenerales.Controls.Add(this.checkBox11, 7, 15);
         this.tableDatosGenerales.Controls.Add(this.label30, 6, 14);
         this.tableDatosGenerales.Controls.Add(this.checkBox10, 7, 14);
         this.tableDatosGenerales.Controls.Add(this.label29, 6, 13);
         this.tableDatosGenerales.Controls.Add(this.checkBox9, 7, 13);
         this.tableDatosGenerales.Controls.Add(this.label28, 6, 12);
         this.tableDatosGenerales.Controls.Add(this.checkBox8, 7, 12);
         this.tableDatosGenerales.Controls.Add(this.label27, 6, 11);
         this.tableDatosGenerales.Controls.Add(this.checkBox7, 7, 11);
         this.tableDatosGenerales.Controls.Add(this.label7, 6, 10);
         this.tableDatosGenerales.Controls.Add(this.checkBox5, 7, 10);
         this.tableDatosGenerales.Controls.Add(this.label32, 6, 9);
         this.tableDatosGenerales.Controls.Add(this.checkBox12, 7, 9);
         this.tableDatosGenerales.Controls.Add(this.lblENTC_EMail, 0, 13);
         this.tableDatosGenerales.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableDatosGenerales.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableDatosGenerales.Location = new System.Drawing.Point(0, 26);
         this.tableDatosGenerales.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.tableDatosGenerales.Name = "tableDatosGenerales";
         this.tableDatosGenerales.RowCount = 16;
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
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosGenerales.Size = new System.Drawing.Size(1204, 432);
         this.tableDatosGenerales.TabIndex = 0;
         // 
         // ENTC_EMail
         // 
         this.ENTC_EMail.Location = new System.Drawing.Point(152, 354);
         this.ENTC_EMail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ENTC_EMail.Name = "ENTC_EMail";
         this.ENTC_EMail.ReadOnly = true;
         this.ENTC_EMail.Size = new System.Drawing.Size(194, 20);
         this.ENTC_EMail.TabIndex = 3;
         // 
         // ENTC_Contacto
         // 
         this.tableDatosGenerales.SetColumnSpan(this.ENTC_Contacto, 4);
         this.ENTC_Contacto.Location = new System.Drawing.Point(152, 327);
         this.ENTC_Contacto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ENTC_Contacto.Name = "ENTC_Contacto";
         this.ENTC_Contacto.ReadOnly = true;
         this.ENTC_Contacto.Size = new System.Drawing.Size(558, 20);
         this.ENTC_Contacto.TabIndex = 6;
         // 
         // CCOT_NumDocCOT
         // 
         this.CCOT_NumDocCOT.Location = new System.Drawing.Point(152, 3);
         this.CCOT_NumDocCOT.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_NumDocCOT.Name = "CCOT_NumDocCOT";
         this.CCOT_NumDocCOT.ReadOnly = true;
         this.CCOT_NumDocCOT.Size = new System.Drawing.Size(194, 20);
         this.CCOT_NumDocCOT.TabIndex = 1;
         this.CCOT_NumDocCOT.Tag = "CCOT_NumDocMSGERROR";
         // 
         // lblENTC_EMail
         // 
         this.lblENTC_EMail.AutoSize = true;
         this.lblENTC_EMail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_EMail.Location = new System.Drawing.Point(10, 358);
         this.lblENTC_EMail.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblENTC_EMail.Name = "lblENTC_EMail";
         this.lblENTC_EMail.Size = new System.Drawing.Size(43, 13);
         this.lblENTC_EMail.TabIndex = 2;
         this.lblENTC_EMail.Text = "Email:";
         // 
         // lblENTC_CodContacto
         // 
         this.lblENTC_CodContacto.AutoSize = true;
         this.lblENTC_CodContacto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_CodContacto.Location = new System.Drawing.Point(10, 331);
         this.lblENTC_CodContacto.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblENTC_CodContacto.Name = "lblENTC_CodContacto";
         this.lblENTC_CodContacto.Size = new System.Drawing.Size(116, 13);
         this.lblENTC_CodContacto.TabIndex = 0;
         this.lblENTC_CodContacto.Text = "Nombre Completo:";
         // 
         // lblCCOT_NumDocCOT
         // 
         this.lblCCOT_NumDocCOT.AutoSize = true;
         this.lblCCOT_NumDocCOT.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_NumDocCOT.Location = new System.Drawing.Point(10, 7);
         this.lblCCOT_NumDocCOT.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_NumDocCOT.Name = "lblCCOT_NumDocCOT";
         this.lblCCOT_NumDocCOT.Size = new System.Drawing.Size(62, 13);
         this.lblCCOT_NumDocCOT.TabIndex = 0;
         this.lblCCOT_NumDocCOT.Text = "Número:";
         // 
         // lblCCOT_Version
         // 
         this.lblCCOT_Version.AutoSize = true;
         this.lblCCOT_Version.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_Version.Location = new System.Drawing.Point(374, 7);
         this.lblCCOT_Version.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_Version.Name = "lblCCOT_Version";
         this.lblCCOT_Version.Size = new System.Drawing.Size(60, 13);
         this.lblCCOT_Version.TabIndex = 2;
         this.lblCCOT_Version.Text = "Versión:";
         // 
         // CCOT_Version
         // 
         this.CCOT_Version.Location = new System.Drawing.Point(516, 3);
         this.CCOT_Version.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_Version.Name = "CCOT_Version";
         this.CCOT_Version.ReadOnly = true;
         this.CCOT_Version.Size = new System.Drawing.Size(194, 20);
         this.CCOT_Version.TabIndex = 3;
         this.CCOT_Version.Tag = "CCOT_VersionMSGERROR";
         // 
         // lblCONS_CodESTCOT
         // 
         this.lblCONS_CodESTCOT.AutoSize = true;
         this.lblCONS_CodESTCOT.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONS_CodESTCOT.Location = new System.Drawing.Point(738, 7);
         this.lblCONS_CodESTCOT.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCONS_CodESTCOT.Name = "lblCONS_CodESTCOT";
         this.lblCONS_CodESTCOT.Size = new System.Drawing.Size(55, 13);
         this.lblCONS_CodESTCOT.TabIndex = 4;
         this.lblCONS_CodESTCOT.Text = "Estado:";
         // 
         // CONS_CodESTCOT
         // 
         this.CONS_CodESTCOT.ConstantesSelectedItem = null;
         this.CONS_CodESTCOT.ConstantesSelectedValue = null;
         this.CONS_CodESTCOT.ConstantesTitulo = null;
         this.CONS_CodESTCOT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CONS_CodESTCOT.Enabled = false;
         this.CONS_CodESTCOT.FormattingEnabled = true;
         this.CONS_CodESTCOT.Location = new System.Drawing.Point(880, 3);
         this.CONS_CodESTCOT.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CONS_CodESTCOT.Name = "CONS_CodESTCOT";
         this.CONS_CodESTCOT.Size = new System.Drawing.Size(194, 21);
         this.CONS_CodESTCOT.TabIndex = 5;
         this.CONS_CodESTCOT.Tag = "CONS_CodESTMSGERROR";
         // 
         // lblCCOT_NumDocOV
         // 
         this.lblCCOT_NumDocOV.AutoSize = true;
         this.lblCCOT_NumDocOV.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_NumDocOV.Location = new System.Drawing.Point(10, 34);
         this.lblCCOT_NumDocOV.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_NumDocOV.Name = "lblCCOT_NumDocOV";
         this.lblCCOT_NumDocOV.Size = new System.Drawing.Size(62, 13);
         this.lblCCOT_NumDocOV.TabIndex = 32;
         this.lblCCOT_NumDocOV.Text = "Número:";
         // 
         // CCOT_NumDocOV
         // 
         this.CCOT_NumDocOV.Location = new System.Drawing.Point(152, 30);
         this.CCOT_NumDocOV.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_NumDocOV.Name = "CCOT_NumDocOV";
         this.CCOT_NumDocOV.ReadOnly = true;
         this.CCOT_NumDocOV.Size = new System.Drawing.Size(194, 20);
         this.CCOT_NumDocOV.TabIndex = 33;
         this.CCOT_NumDocOV.Tag = "CCOT_NumDocMSGERROR";
         // 
         // lblCCOT_NumDocCOT2
         // 
         this.lblCCOT_NumDocCOT2.AutoSize = true;
         this.lblCCOT_NumDocCOT2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_NumDocCOT2.Location = new System.Drawing.Point(374, 34);
         this.lblCCOT_NumDocCOT2.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_NumDocCOT2.Name = "lblCCOT_NumDocCOT2";
         this.lblCCOT_NumDocCOT2.Size = new System.Drawing.Size(133, 13);
         this.lblCCOT_NumDocCOT2.TabIndex = 34;
         this.lblCCOT_NumDocCOT2.Text = "Número Cotización:";
         // 
         // CCOT_NumDocCOT2
         // 
         this.CCOT_NumDocCOT2.Location = new System.Drawing.Point(516, 30);
         this.CCOT_NumDocCOT2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_NumDocCOT2.Name = "CCOT_NumDocCOT2";
         this.CCOT_NumDocCOT2.ReadOnly = true;
         this.CCOT_NumDocCOT2.Size = new System.Drawing.Size(194, 20);
         this.CCOT_NumDocCOT2.TabIndex = 35;
         this.CCOT_NumDocCOT2.Tag = "CCOT_VersionMSGERROR";
         // 
         // lblCONS_CodESTOV
         // 
         this.lblCONS_CodESTOV.AutoSize = true;
         this.lblCONS_CodESTOV.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONS_CodESTOV.Location = new System.Drawing.Point(738, 34);
         this.lblCONS_CodESTOV.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCONS_CodESTOV.Name = "lblCONS_CodESTOV";
         this.lblCONS_CodESTOV.Size = new System.Drawing.Size(55, 13);
         this.lblCONS_CodESTOV.TabIndex = 36;
         this.lblCONS_CodESTOV.Text = "Estado:";
         // 
         // CONS_CodESTOV
         // 
         this.CONS_CodESTOV.ConstantesSelectedItem = null;
         this.CONS_CodESTOV.ConstantesSelectedValue = null;
         this.CONS_CodESTOV.ConstantesTitulo = null;
         this.CONS_CodESTOV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CONS_CodESTOV.Enabled = false;
         this.CONS_CodESTOV.FormattingEnabled = true;
         this.CONS_CodESTOV.Location = new System.Drawing.Point(880, 30);
         this.CONS_CodESTOV.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CONS_CodESTOV.Name = "CONS_CodESTOV";
         this.CONS_CodESTOV.Size = new System.Drawing.Size(194, 21);
         this.CONS_CodESTOV.TabIndex = 37;
         this.CONS_CodESTOV.Tag = "CONS_CodESTMSGERROR";
         // 
         // lblCCOT_FecEmi
         // 
         this.lblCCOT_FecEmi.AutoSize = true;
         this.lblCCOT_FecEmi.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_FecEmi.Location = new System.Drawing.Point(10, 61);
         this.lblCCOT_FecEmi.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_FecEmi.Name = "lblCCOT_FecEmi";
         this.lblCCOT_FecEmi.Size = new System.Drawing.Size(105, 13);
         this.lblCCOT_FecEmi.TabIndex = 8;
         this.lblCCOT_FecEmi.Text = "Fecha Emision:";
         // 
         // CCOT_FecEmi
         // 
         this.CCOT_FecEmi.Location = new System.Drawing.Point(152, 57);
         this.CCOT_FecEmi.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_FecEmi.MinimumSize = new System.Drawing.Size(100, 22);
         this.CCOT_FecEmi.Name = "CCOT_FecEmi";
         this.CCOT_FecEmi.NSActiveMouse = false;
         this.CCOT_FecEmi.NSActiveMsgFecha = false;
         this.CCOT_FecEmi.NSChangeDate = true;
         this.CCOT_FecEmi.NSDigitos = 4;
         this.CCOT_FecEmi.NSFecha = null;
         this.CCOT_FecEmi.NSSetDateNow = false;
         this.CCOT_FecEmi.Size = new System.Drawing.Size(101, 22);
         this.CCOT_FecEmi.TabIndex = 9;
         this.CCOT_FecEmi.Tag = "CCOT_FecEmiMSGERROR";
         // 
         // lblCCOT_FecVcto
         // 
         this.lblCCOT_FecVcto.AutoSize = true;
         this.lblCCOT_FecVcto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_FecVcto.Location = new System.Drawing.Point(374, 61);
         this.lblCCOT_FecVcto.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_FecVcto.Name = "lblCCOT_FecVcto";
         this.lblCCOT_FecVcto.Size = new System.Drawing.Size(134, 13);
         this.lblCCOT_FecVcto.TabIndex = 14;
         this.lblCCOT_FecVcto.Text = "Fecha Vencimiento:";
         // 
         // CCOT_FecVcto
         // 
         this.CCOT_FecVcto.Location = new System.Drawing.Point(516, 57);
         this.CCOT_FecVcto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_FecVcto.MinimumSize = new System.Drawing.Size(100, 22);
         this.CCOT_FecVcto.Name = "CCOT_FecVcto";
         this.CCOT_FecVcto.NSActiveMouse = false;
         this.CCOT_FecVcto.NSActiveMsgFecha = false;
         this.CCOT_FecVcto.NSChangeDate = true;
         this.CCOT_FecVcto.NSDigitos = 4;
         this.CCOT_FecVcto.NSFecha = null;
         this.CCOT_FecVcto.NSSetDateNow = false;
         this.CCOT_FecVcto.Size = new System.Drawing.Size(101, 22);
         this.CCOT_FecVcto.TabIndex = 15;
         this.CCOT_FecVcto.Tag = "CCOT_FecVctoMSGERROR";
         // 
         // lblENTC_CodCustomer
         // 
         this.lblENTC_CodCustomer.AutoSize = true;
         this.lblENTC_CodCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_CodCustomer.Location = new System.Drawing.Point(10, 250);
         this.lblENTC_CodCustomer.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblENTC_CodCustomer.Name = "lblENTC_CodCustomer";
         this.lblENTC_CodCustomer.Size = new System.Drawing.Size(73, 13);
         this.lblENTC_CodCustomer.TabIndex = 28;
         this.lblENTC_CodCustomer.Text = "Customer:";
         // 
         // ENTC_CodCustomer
         // 
         this.ENTC_CodCustomer.ActivarAyudaAuto = false;
         this.tableDatosGenerales.SetColumnSpan(this.ENTC_CodCustomer, 4);
         this.ENTC_CodCustomer.ContainerService = null;
         this.ENTC_CodCustomer.EnabledAyudaButton = true;
         this.ENTC_CodCustomer.Location = new System.Drawing.Point(152, 246);
         this.ENTC_CodCustomer.LongitudAceptada = 0;
         this.ENTC_CodCustomer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ENTC_CodCustomer.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_CodCustomer.Name = "ENTC_CodCustomer";
         this.ENTC_CodCustomer.RellenaCeros = false;
         this.ENTC_CodCustomer.Size = new System.Drawing.Size(558, 20);
         this.ENTC_CodCustomer.TabIndex = 29;
         this.ENTC_CodCustomer.Tag = "ENTC_CodCustomerMSGERROR";
         this.ENTC_CodCustomer.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodCustomer.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Customer;
         this.ENTC_CodCustomer.Value = null;
         // 
         // lblENTC_CodBroker
         // 
         this.lblENTC_CodBroker.AutoSize = true;
         this.lblENTC_CodBroker.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_CodBroker.Location = new System.Drawing.Point(10, 223);
         this.lblENTC_CodBroker.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblENTC_CodBroker.Name = "lblENTC_CodBroker";
         this.lblENTC_CodBroker.Size = new System.Drawing.Size(51, 13);
         this.lblENTC_CodBroker.TabIndex = 24;
         this.lblENTC_CodBroker.Text = "Broker:";
         // 
         // ENTC_CodBroker
         // 
         this.ENTC_CodBroker.ActivarAyudaAuto = false;
         this.tableDatosGenerales.SetColumnSpan(this.ENTC_CodBroker, 4);
         this.ENTC_CodBroker.ContainerService = null;
         this.ENTC_CodBroker.EnabledAyudaButton = true;
         this.ENTC_CodBroker.Location = new System.Drawing.Point(152, 219);
         this.ENTC_CodBroker.LongitudAceptada = 0;
         this.ENTC_CodBroker.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ENTC_CodBroker.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_CodBroker.Name = "ENTC_CodBroker";
         this.ENTC_CodBroker.RellenaCeros = false;
         this.ENTC_CodBroker.Size = new System.Drawing.Size(558, 20);
         this.ENTC_CodBroker.TabIndex = 25;
         this.ENTC_CodBroker.Tag = "ENTC_CodBrokerMSGERROR";
         this.ENTC_CodBroker.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodBroker.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Broker;
         this.ENTC_CodBroker.Value = null;
         // 
         // lblENTC_CodEjecutivo
         // 
         this.lblENTC_CodEjecutivo.AutoSize = true;
         this.lblENTC_CodEjecutivo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_CodEjecutivo.Location = new System.Drawing.Point(10, 196);
         this.lblENTC_CodEjecutivo.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblENTC_CodEjecutivo.Name = "lblENTC_CodEjecutivo";
         this.lblENTC_CodEjecutivo.Size = new System.Drawing.Size(72, 13);
         this.lblENTC_CodEjecutivo.TabIndex = 20;
         this.lblENTC_CodEjecutivo.Text = "Ejecutivo:";
         // 
         // ENTC_CodEjecutivo
         // 
         this.ENTC_CodEjecutivo.ActivarAyudaAuto = false;
         this.tableDatosGenerales.SetColumnSpan(this.ENTC_CodEjecutivo, 4);
         this.ENTC_CodEjecutivo.ContainerService = null;
         this.ENTC_CodEjecutivo.EnabledAyudaButton = true;
         this.ENTC_CodEjecutivo.Location = new System.Drawing.Point(152, 192);
         this.ENTC_CodEjecutivo.LongitudAceptada = 0;
         this.ENTC_CodEjecutivo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ENTC_CodEjecutivo.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_CodEjecutivo.Name = "ENTC_CodEjecutivo";
         this.ENTC_CodEjecutivo.RellenaCeros = false;
         this.ENTC_CodEjecutivo.Size = new System.Drawing.Size(558, 20);
         this.ENTC_CodEjecutivo.TabIndex = 21;
         this.ENTC_CodEjecutivo.Tag = "ENTC_CodEjecutivoMSGERROR";
         this.ENTC_CodEjecutivo.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodEjecutivo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;
         this.ENTC_CodEjecutivo.Value = null;
         // 
         // lblENTC_CodAgente
         // 
         this.lblENTC_CodAgente.AutoSize = true;
         this.lblENTC_CodAgente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_CodAgente.Location = new System.Drawing.Point(10, 169);
         this.lblENTC_CodAgente.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblENTC_CodAgente.Name = "lblENTC_CodAgente";
         this.lblENTC_CodAgente.Size = new System.Drawing.Size(57, 13);
         this.lblENTC_CodAgente.TabIndex = 16;
         this.lblENTC_CodAgente.Tag = "MSGERROR";
         this.lblENTC_CodAgente.Text = "Agente:";
         // 
         // ENTC_CodAgente
         // 
         this.ENTC_CodAgente.ActivarAyudaAuto = false;
         this.tableDatosGenerales.SetColumnSpan(this.ENTC_CodAgente, 4);
         this.ENTC_CodAgente.ContainerService = null;
         this.ENTC_CodAgente.EnabledAyudaButton = true;
         this.ENTC_CodAgente.Location = new System.Drawing.Point(152, 165);
         this.ENTC_CodAgente.LongitudAceptada = 0;
         this.ENTC_CodAgente.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ENTC_CodAgente.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_CodAgente.Name = "ENTC_CodAgente";
         this.ENTC_CodAgente.RellenaCeros = false;
         this.ENTC_CodAgente.Size = new System.Drawing.Size(558, 20);
         this.ENTC_CodAgente.TabIndex = 17;
         this.ENTC_CodAgente.Tag = "ENTC_CodAgenteMSGERROR";
         this.ENTC_CodAgente.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodAgente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente;
         this.ENTC_CodAgente.Value = null;
         // 
         // lblCONS_CodRGM
         // 
         this.lblCONS_CodRGM.AutoSize = true;
         this.lblCONS_CodRGM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONS_CodRGM.Location = new System.Drawing.Point(10, 142);
         this.lblCONS_CodRGM.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCONS_CodRGM.Name = "lblCONS_CodRGM";
         this.lblCONS_CodRGM.Size = new System.Drawing.Size(67, 13);
         this.lblCONS_CodRGM.TabIndex = 10;
         this.lblCONS_CodRGM.Text = "Régimen:";
         // 
         // cmbCONS_CodRGM
         // 
         this.cmbCONS_CodRGM.ConstantesSelectedItem = null;
         this.cmbCONS_CodRGM.ConstantesSelectedValue = null;
         this.cmbCONS_CodRGM.ConstantesTitulo = null;
         this.cmbCONS_CodRGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbCONS_CodRGM.FormattingEnabled = true;
         this.cmbCONS_CodRGM.Location = new System.Drawing.Point(152, 138);
         this.cmbCONS_CodRGM.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.cmbCONS_CodRGM.Name = "cmbCONS_CodRGM";
         this.cmbCONS_CodRGM.Size = new System.Drawing.Size(194, 21);
         this.cmbCONS_CodRGM.TabIndex = 11;
         this.cmbCONS_CodRGM.Tag = "CONS_CodRGMMSGERROR";
         // 
         // lblCONS_CodVia
         // 
         this.lblCONS_CodVia.AutoSize = true;
         this.lblCONS_CodVia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONS_CodVia.Location = new System.Drawing.Point(374, 142);
         this.lblCONS_CodVia.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCONS_CodVia.Name = "lblCONS_CodVia";
         this.lblCONS_CodVia.Size = new System.Drawing.Size(31, 13);
         this.lblCONS_CodVia.TabIndex = 12;
         this.lblCONS_CodVia.Text = "Vía:";
         // 
         // cmbCONS_CodVia
         // 
         this.cmbCONS_CodVia.ConstantesSelectedItem = null;
         this.cmbCONS_CodVia.ConstantesSelectedValue = null;
         this.cmbCONS_CodVia.ConstantesTitulo = null;
         this.cmbCONS_CodVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbCONS_CodVia.FormattingEnabled = true;
         this.cmbCONS_CodVia.Location = new System.Drawing.Point(516, 138);
         this.cmbCONS_CodVia.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.cmbCONS_CodVia.Name = "cmbCONS_CodVia";
         this.cmbCONS_CodVia.Size = new System.Drawing.Size(194, 21);
         this.cmbCONS_CodVia.TabIndex = 13;
         this.cmbCONS_CodVia.Tag = "CONS_CodViaMSGERROR";
         // 
         // lblENTC_CodCliente
         // 
         this.lblENTC_CodCliente.AutoSize = true;
         this.lblENTC_CodCliente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_CodCliente.Location = new System.Drawing.Point(10, 115);
         this.lblENTC_CodCliente.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblENTC_CodCliente.Name = "lblENTC_CodCliente";
         this.lblENTC_CodCliente.Size = new System.Drawing.Size(56, 13);
         this.lblENTC_CodCliente.TabIndex = 6;
         this.lblENTC_CodCliente.Text = "Cliente:";
         // 
         // ENTC_CodCliente
         // 
         this.ENTC_CodCliente.ActivarAyudaAuto = false;
         this.tableDatosGenerales.SetColumnSpan(this.ENTC_CodCliente, 4);
         this.ENTC_CodCliente.ContainerService = null;
         this.ENTC_CodCliente.EnabledAyudaButton = true;
         this.ENTC_CodCliente.Location = new System.Drawing.Point(152, 111);
         this.ENTC_CodCliente.LongitudAceptada = 0;
         this.ENTC_CodCliente.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ENTC_CodCliente.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_CodCliente.Name = "ENTC_CodCliente";
         this.ENTC_CodCliente.RellenaCeros = false;
         this.ENTC_CodCliente.Size = new System.Drawing.Size(558, 20);
         this.ENTC_CodCliente.TabIndex = 7;
         this.ENTC_CodCliente.Tag = "ENTC_CodClienteMSGERROR";
         this.ENTC_CodCliente.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
         this.ENTC_CodCliente.Value = null;
         // 
         // lblCCOT_FecAprueba
         // 
         this.lblCCOT_FecAprueba.AutoSize = true;
         this.lblCCOT_FecAprueba.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_FecAprueba.Location = new System.Drawing.Point(10, 88);
         this.lblCCOT_FecAprueba.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_FecAprueba.Name = "lblCCOT_FecAprueba";
         this.lblCCOT_FecAprueba.Size = new System.Drawing.Size(113, 13);
         this.lblCCOT_FecAprueba.TabIndex = 18;
         this.lblCCOT_FecAprueba.Text = "Fecha Aprobación:";
         // 
         // CCOT_FecAprueba
         // 
         this.CCOT_FecAprueba.Location = new System.Drawing.Point(152, 84);
         this.CCOT_FecAprueba.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_FecAprueba.MinimumSize = new System.Drawing.Size(100, 22);
         this.CCOT_FecAprueba.Name = "CCOT_FecAprueba";
         this.CCOT_FecAprueba.NSActiveMouse = false;
         this.CCOT_FecAprueba.NSActiveMsgFecha = false;
         this.CCOT_FecAprueba.NSChangeDate = true;
         this.CCOT_FecAprueba.NSDigitos = 4;
         this.CCOT_FecAprueba.NSFecha = null;
         this.CCOT_FecAprueba.NSSetDateNow = false;
         this.CCOT_FecAprueba.Size = new System.Drawing.Size(101, 22);
         this.CCOT_FecAprueba.TabIndex = 19;
         this.CCOT_FecAprueba.Tag = "CCOT_FecApruebaMSGERROR";
         // 
         // lblCCOT_Propia
         // 
         this.lblCCOT_Propia.AutoSize = true;
         this.lblCCOT_Propia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_Propia.Location = new System.Drawing.Point(738, 61);
         this.lblCCOT_Propia.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_Propia.Name = "lblCCOT_Propia";
         this.lblCCOT_Propia.Size = new System.Drawing.Size(111, 13);
         this.lblCCOT_Propia.TabIndex = 22;
         this.lblCCOT_Propia.Text = "Cotización Propia:";
         // 
         // CCOT_Propia
         // 
         this.CCOT_Propia.AutoSize = true;
         this.CCOT_Propia.Location = new System.Drawing.Point(880, 61);
         this.CCOT_Propia.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.CCOT_Propia.Name = "CCOT_Propia";
         this.CCOT_Propia.Size = new System.Drawing.Size(15, 14);
         this.CCOT_Propia.TabIndex = 23;
         this.CCOT_Propia.Tag = "CCOT_PropiaMSGERROR";
         this.CCOT_Propia.UseVisualStyleBackColor = true;
         // 
         // lblCCOT_ServicioLogistico
         // 
         this.lblCCOT_ServicioLogistico.AutoSize = true;
         this.lblCCOT_ServicioLogistico.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_ServicioLogistico.Location = new System.Drawing.Point(738, 88);
         this.lblCCOT_ServicioLogistico.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_ServicioLogistico.Name = "lblCCOT_ServicioLogistico";
         this.lblCCOT_ServicioLogistico.Size = new System.Drawing.Size(111, 13);
         this.lblCCOT_ServicioLogistico.TabIndex = 26;
         this.lblCCOT_ServicioLogistico.Text = "Servicio Logístico:";
         // 
         // CCOT_ServicioLogistico
         // 
         this.CCOT_ServicioLogistico.AutoSize = true;
         this.CCOT_ServicioLogistico.Location = new System.Drawing.Point(880, 88);
         this.CCOT_ServicioLogistico.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.CCOT_ServicioLogistico.Name = "CCOT_ServicioLogistico";
         this.CCOT_ServicioLogistico.Size = new System.Drawing.Size(15, 14);
         this.CCOT_ServicioLogistico.TabIndex = 27;
         this.CCOT_ServicioLogistico.Tag = "CCOT_ServicioLogisticoMSGERROR";
         this.CCOT_ServicioLogistico.UseVisualStyleBackColor = true;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(738, 115);
         this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(130, 13);
         this.label5.TabIndex = 40;
         this.label5.Text = "Servicio Transmisión:";
         // 
         // checkBox3
         // 
         this.checkBox3.AutoSize = true;
         this.checkBox3.Location = new System.Drawing.Point(880, 115);
         this.checkBox3.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.checkBox3.Name = "checkBox3";
         this.checkBox3.Size = new System.Drawing.Size(15, 14);
         this.checkBox3.TabIndex = 45;
         this.checkBox3.Tag = "CCOT_ServicioLogisticoMSGERROR";
         this.checkBox3.UseVisualStyleBackColor = true;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label9.Location = new System.Drawing.Point(738, 142);
         this.label9.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(115, 13);
         this.label9.TabIndex = 48;
         this.label9.Text = "Recibio Pre-Alerta:";
         // 
         // checkBox6
         // 
         this.checkBox6.AutoSize = true;
         this.checkBox6.Location = new System.Drawing.Point(880, 142);
         this.checkBox6.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.checkBox6.Name = "checkBox6";
         this.checkBox6.Size = new System.Drawing.Size(15, 14);
         this.checkBox6.TabIndex = 49;
         this.checkBox6.Tag = "CCOT_ServicioLogisticoMSGERROR";
         this.checkBox6.UseVisualStyleBackColor = true;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(738, 169);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(76, 13);
         this.label2.TabIndex = 38;
         this.label2.Text = "Emitir HB/L:";
         // 
         // checkBox1
         // 
         this.checkBox1.AutoSize = true;
         this.checkBox1.Location = new System.Drawing.Point(880, 169);
         this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(15, 14);
         this.checkBox1.TabIndex = 43;
         this.checkBox1.Tag = "CCOT_ServicioLogisticoMSGERROR";
         this.checkBox1.UseVisualStyleBackColor = true;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(738, 196);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(45, 13);
         this.label4.TabIndex = 39;
         this.label4.Text = "SADA:";
         // 
         // checkBox2
         // 
         this.checkBox2.AutoSize = true;
         this.checkBox2.Location = new System.Drawing.Point(880, 196);
         this.checkBox2.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.checkBox2.Name = "checkBox2";
         this.checkBox2.Size = new System.Drawing.Size(15, 14);
         this.checkBox2.TabIndex = 44;
         this.checkBox2.Tag = "CCOT_ServicioLogisticoMSGERROR";
         this.checkBox2.UseVisualStyleBackColor = true;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(738, 223);
         this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(93, 13);
         this.label6.TabIndex = 41;
         this.label6.Text = "OV Bloqueado:";
         // 
         // checkBox4
         // 
         this.checkBox4.AutoSize = true;
         this.checkBox4.Location = new System.Drawing.Point(880, 223);
         this.checkBox4.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.checkBox4.Name = "checkBox4";
         this.checkBox4.Size = new System.Drawing.Size(15, 14);
         this.checkBox4.TabIndex = 46;
         this.checkBox4.Tag = "CCOT_ServicioLogisticoMSGERROR";
         this.checkBox4.UseVisualStyleBackColor = true;
         // 
         // lblTIPO_CodINC
         // 
         this.lblTIPO_CodINC.AutoSize = true;
         this.lblTIPO_CodINC.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPO_CodINC.Location = new System.Drawing.Point(10, 277);
         this.lblTIPO_CodINC.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblTIPO_CodINC.Name = "lblTIPO_CodINC";
         this.lblTIPO_CodINC.Size = new System.Drawing.Size(64, 13);
         this.lblTIPO_CodINC.TabIndex = 30;
         this.lblTIPO_CodINC.Text = "Incoterm:";
         // 
         // TIPO_CodINC
         // 
         this.TIPO_CodINC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.TIPO_CodINC.FormattingEnabled = true;
         this.TIPO_CodINC.Location = new System.Drawing.Point(152, 273);
         this.TIPO_CodINC.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.TIPO_CodINC.Name = "TIPO_CodINC";
         this.TIPO_CodINC.Size = new System.Drawing.Size(194, 21);
         this.TIPO_CodINC.TabIndex = 31;
         this.TIPO_CodINC.Tag = "TIPO_CodINCMSGERROR";
         this.TIPO_CodINC.TiposSelectedItem = null;
         this.TIPO_CodINC.TiposSelectedValue = null;
         this.TIPO_CodINC.TiposTitulo = null;
         // 
         // label26
         // 
         this.label26.AutoSize = true;
         this.label26.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label26.Location = new System.Drawing.Point(374, 88);
         this.label26.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label26.Name = "label26";
         this.label26.Size = new System.Drawing.Size(107, 13);
         this.label26.TabIndex = 50;
         this.label26.Text = "Fecha Embarque:";
         // 
         // maskDateTime2
         // 
         this.maskDateTime2.Location = new System.Drawing.Point(516, 84);
         this.maskDateTime2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.maskDateTime2.MinimumSize = new System.Drawing.Size(100, 22);
         this.maskDateTime2.Name = "maskDateTime2";
         this.maskDateTime2.NSActiveMouse = false;
         this.maskDateTime2.NSActiveMsgFecha = false;
         this.maskDateTime2.NSChangeDate = true;
         this.maskDateTime2.NSDigitos = 4;
         this.maskDateTime2.NSFecha = null;
         this.maskDateTime2.NSSetDateNow = false;
         this.maskDateTime2.Size = new System.Drawing.Size(101, 22);
         this.maskDateTime2.TabIndex = 51;
         this.maskDateTime2.Tag = "CCOT_FecApruebaMSGERROR";
         // 
         // panel3
         // 
         this.tableDatosGenerales.SetColumnSpan(this.panel3, 5);
         this.panel3.Controls.Add(this.btnEditarContacto);
         this.panel3.Controls.Add(this.btnNuevoContacto);
         this.panel3.Controls.Add(this.panelCaption2);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel3.Location = new System.Drawing.Point(0, 297);
         this.panel3.Margin = new System.Windows.Forms.Padding(0);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(714, 27);
         this.panel3.TabIndex = 56;
         // 
         // btnEditarContacto
         // 
         this.btnEditarContacto.BackColor = System.Drawing.Color.Transparent;
         this.btnEditarContacto.Image = global::Delfin.Comercial.Properties.Resources.editar16x16;
         this.btnEditarContacto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnEditarContacto.Location = new System.Drawing.Point(184, 0);
         this.btnEditarContacto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnEditarContacto.Name = "btnEditarContacto";
         this.btnEditarContacto.Size = new System.Drawing.Size(25, 25);
         this.btnEditarContacto.TabIndex = 4;
         this.btnEditarContacto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnEditarContacto, "Editar Contacto");
         this.btnEditarContacto.UseVisualStyleBackColor = false;
         // 
         // btnNuevoContacto
         // 
         this.btnNuevoContacto.BackColor = System.Drawing.Color.Transparent;
         this.btnNuevoContacto.Image = global::Delfin.Comercial.Properties.Resources.add16x16;
         this.btnNuevoContacto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnNuevoContacto.Location = new System.Drawing.Point(152, 1);
         this.btnNuevoContacto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnNuevoContacto.Name = "btnNuevoContacto";
         this.btnNuevoContacto.Size = new System.Drawing.Size(25, 25);
         this.btnNuevoContacto.TabIndex = 3;
         this.btnNuevoContacto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnNuevoContacto, "Nuevo Contacto");
         this.btnNuevoContacto.UseVisualStyleBackColor = false;
         // 
         // panelCaption2
         // 
         this.panelCaption2.AllowActive = false;
         this.panelCaption2.AntiAlias = false;
         this.panelCaption2.Caption = "Contacto Cliente";
         this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption2.Location = new System.Drawing.Point(0, 0);
         this.panelCaption2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption2.Name = "panelCaption2";
         this.panelCaption2.Size = new System.Drawing.Size(714, 26);
         this.panelCaption2.TabIndex = 4;
         // 
         // ENTC_Cargo
         // 
         this.ENTC_Cargo.Location = new System.Drawing.Point(516, 354);
         this.ENTC_Cargo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ENTC_Cargo.Name = "ENTC_Cargo";
         this.ENTC_Cargo.ReadOnly = true;
         this.ENTC_Cargo.Size = new System.Drawing.Size(194, 20);
         this.ENTC_Cargo.TabIndex = 5;
         // 
         // lblENTC_Cargo
         // 
         this.lblENTC_Cargo.AutoSize = true;
         this.lblENTC_Cargo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_Cargo.Location = new System.Drawing.Point(374, 358);
         this.lblENTC_Cargo.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblENTC_Cargo.Name = "lblENTC_Cargo";
         this.lblENTC_Cargo.Size = new System.Drawing.Size(47, 13);
         this.lblENTC_Cargo.TabIndex = 4;
         this.lblENTC_Cargo.Text = "Cargo:";
         // 
         // label31
         // 
         this.label31.AutoSize = true;
         this.label31.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label31.Location = new System.Drawing.Point(738, 412);
         this.label31.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label31.Name = "label31";
         this.label31.Size = new System.Drawing.Size(83, 13);
         this.label31.TabIndex = 57;
         this.label31.Text = "Documentos:";
         // 
         // checkBox11
         // 
         this.checkBox11.AutoSize = true;
         this.checkBox11.Location = new System.Drawing.Point(880, 412);
         this.checkBox11.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.checkBox11.Name = "checkBox11";
         this.checkBox11.Size = new System.Drawing.Size(15, 14);
         this.checkBox11.TabIndex = 62;
         this.checkBox11.Tag = "CCOT_ServicioLogisticoMSGERROR";
         this.checkBox11.UseVisualStyleBackColor = true;
         // 
         // label30
         // 
         this.label30.AutoSize = true;
         this.label30.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label30.Location = new System.Drawing.Point(738, 385);
         this.label30.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label30.Name = "label30";
         this.label30.Size = new System.Drawing.Size(111, 13);
         this.label30.TabIndex = 55;
         this.label30.Text = "Flete Recuperado:";
         // 
         // checkBox10
         // 
         this.checkBox10.AutoSize = true;
         this.checkBox10.Location = new System.Drawing.Point(880, 385);
         this.checkBox10.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.checkBox10.Name = "checkBox10";
         this.checkBox10.Size = new System.Drawing.Size(15, 14);
         this.checkBox10.TabIndex = 61;
         this.checkBox10.Tag = "CCOT_ServicioLogisticoMSGERROR";
         this.checkBox10.UseVisualStyleBackColor = true;
         // 
         // label29
         // 
         this.label29.AutoSize = true;
         this.label29.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label29.Location = new System.Drawing.Point(738, 358);
         this.label29.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label29.Name = "label29";
         this.label29.Size = new System.Drawing.Size(116, 13);
         this.label29.TabIndex = 54;
         this.label29.Text = "Flete Provisionado:";
         // 
         // checkBox9
         // 
         this.checkBox9.AutoSize = true;
         this.checkBox9.Location = new System.Drawing.Point(880, 358);
         this.checkBox9.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.checkBox9.Name = "checkBox9";
         this.checkBox9.Size = new System.Drawing.Size(15, 14);
         this.checkBox9.TabIndex = 60;
         this.checkBox9.Tag = "CCOT_ServicioLogisticoMSGERROR";
         this.checkBox9.UseVisualStyleBackColor = true;
         // 
         // label28
         // 
         this.label28.AutoSize = true;
         this.label28.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label28.Location = new System.Drawing.Point(738, 331);
         this.label28.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label28.Name = "label28";
         this.label28.Size = new System.Drawing.Size(93, 13);
         this.label28.TabIndex = 53;
         this.label28.Text = "VºBº Logística:";
         // 
         // checkBox8
         // 
         this.checkBox8.AutoSize = true;
         this.checkBox8.Location = new System.Drawing.Point(880, 331);
         this.checkBox8.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.checkBox8.Name = "checkBox8";
         this.checkBox8.Size = new System.Drawing.Size(15, 14);
         this.checkBox8.TabIndex = 59;
         this.checkBox8.Tag = "CCOT_ServicioLogisticoMSGERROR";
         this.checkBox8.UseVisualStyleBackColor = true;
         // 
         // label27
         // 
         this.label27.AutoSize = true;
         this.label27.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label27.Location = new System.Drawing.Point(738, 304);
         this.label27.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label27.Name = "label27";
         this.label27.Size = new System.Drawing.Size(115, 13);
         this.label27.TabIndex = 52;
         this.label27.Text = "VºBº Operaciones:";
         // 
         // checkBox7
         // 
         this.checkBox7.AutoSize = true;
         this.checkBox7.Location = new System.Drawing.Point(880, 304);
         this.checkBox7.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.checkBox7.Name = "checkBox7";
         this.checkBox7.Size = new System.Drawing.Size(15, 14);
         this.checkBox7.TabIndex = 58;
         this.checkBox7.Tag = "CCOT_ServicioLogisticoMSGERROR";
         this.checkBox7.UseVisualStyleBackColor = true;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label7.Location = new System.Drawing.Point(738, 277);
         this.label7.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(109, 13);
         this.label7.TabIndex = 42;
         this.label7.Text = "Aviso de Llegada:";
         // 
         // checkBox5
         // 
         this.checkBox5.AutoSize = true;
         this.checkBox5.Location = new System.Drawing.Point(880, 277);
         this.checkBox5.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.checkBox5.Name = "checkBox5";
         this.checkBox5.Size = new System.Drawing.Size(15, 14);
         this.checkBox5.TabIndex = 47;
         this.checkBox5.Tag = "CCOT_ServicioLogisticoMSGERROR";
         this.checkBox5.UseVisualStyleBackColor = true;
         // 
         // label32
         // 
         this.label32.AutoSize = true;
         this.label32.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label32.Location = new System.Drawing.Point(738, 250);
         this.label32.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label32.Name = "label32";
         this.label32.Size = new System.Drawing.Size(113, 13);
         this.label32.TabIndex = 63;
         this.label32.Text = "OV por Excepción:";
         // 
         // checkBox12
         // 
         this.checkBox12.AutoSize = true;
         this.checkBox12.Location = new System.Drawing.Point(880, 250);
         this.checkBox12.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.checkBox12.Name = "checkBox12";
         this.checkBox12.Size = new System.Drawing.Size(15, 14);
         this.checkBox12.TabIndex = 64;
         this.checkBox12.Tag = "CCOT_ServicioLogisticoMSGERROR";
         this.checkBox12.UseVisualStyleBackColor = true;
         // 
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Datos Generales Cotización";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 0);
         this.panelCaption1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(1204, 26);
         this.panelCaption1.TabIndex = 1;
         // 
         // pageServiciosTarifa
         // 
         this.pageServiciosTarifa.Controls.Add(this.tabServiciosAdicionales);
         this.pageServiciosTarifa.Controls.Add(this.panel1);
         this.pageServiciosTarifa.Controls.Add(this.panel8);
         this.pageServiciosTarifa.Controls.Add(this.tableLayoutPanel3);
         this.pageServiciosTarifa.Controls.Add(this.panelCaption3);
         this.pageServiciosTarifa.Location = new System.Drawing.Point(4, 25);
         this.pageServiciosTarifa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.pageServiciosTarifa.Name = "pageServiciosTarifa";
         this.pageServiciosTarifa.Size = new System.Drawing.Size(1204, 494);
         this.pageServiciosTarifa.TabIndex = 1;
         this.pageServiciosTarifa.Text = "Servicios y Tarifa";
         // 
         // tabServiciosAdicionales
         // 
         this.tabServiciosAdicionales.Controls.Add(this.pageServicios);
         this.tabServiciosAdicionales.Controls.Add(this.pageChangeControl);
         this.tabServiciosAdicionales.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabServiciosAdicionales.Location = new System.Drawing.Point(0, 311);
         this.tabServiciosAdicionales.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.tabServiciosAdicionales.Name = "tabServiciosAdicionales";
         this.tabServiciosAdicionales.SelectedIndex = 0;
         this.tabServiciosAdicionales.SelectedTabColor = System.Drawing.Color.SteelBlue;
         this.tabServiciosAdicionales.Size = new System.Drawing.Size(1204, 183);
         this.tabServiciosAdicionales.TabIndex = 52;
         this.tabServiciosAdicionales.UseVisualStyles = false;
         // 
         // pageServicios
         // 
         this.pageServicios.Controls.Add(this.btnAddServicio);
         this.pageServicios.Controls.Add(this.grdItemsServicio);
         this.pageServicios.Controls.Add(this.btnDelServicio);
         this.pageServicios.Controls.Add(this.panelCaption5);
         this.pageServicios.Location = new System.Drawing.Point(4, 25);
         this.pageServicios.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.pageServicios.Name = "pageServicios";
         this.pageServicios.Size = new System.Drawing.Size(1196, 154);
         this.pageServicios.TabIndex = 0;
         this.pageServicios.Text = "Servicios Adicionales";
         // 
         // btnAddServicio
         // 
         this.btnAddServicio.BackColor = System.Drawing.Color.Transparent;
         this.btnAddServicio.Image = global::Delfin.Comercial.Properties.Resources.add16x16;
         this.btnAddServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnAddServicio.Location = new System.Drawing.Point(287, 1);
         this.btnAddServicio.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnAddServicio.Name = "btnAddServicio";
         this.btnAddServicio.Size = new System.Drawing.Size(25, 25);
         this.btnAddServicio.TabIndex = 13;
         this.btnAddServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnAddServicio, "Nuevo Servicio");
         this.btnAddServicio.UseVisualStyleBackColor = false;
         // 
         // grdItemsServicio
         // 
         this.grdItemsServicio.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdItemsServicio.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItemsServicio.Location = new System.Drawing.Point(0, 27);
         this.grdItemsServicio.Margin = new System.Windows.Forms.Padding(2, 3, 18, 3);
         this.grdItemsServicio.Name = "grdItemsServicio";
         // 
         // 
         // 
         this.grdItemsServicio.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 27, 240, 150);
         this.grdItemsServicio.RootElement.MinSize = new System.Drawing.Size(0, 0);
         this.grdItemsServicio.Size = new System.Drawing.Size(1196, 127);
         this.grdItemsServicio.TabIndex = 12;
         this.grdItemsServicio.TabStop = false;
         // 
         // btnDelServicio
         // 
         this.btnDelServicio.BackColor = System.Drawing.Color.Transparent;
         this.btnDelServicio.Image = global::Delfin.Comercial.Properties.Resources.delete1;
         this.btnDelServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnDelServicio.Location = new System.Drawing.Point(318, 1);
         this.btnDelServicio.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnDelServicio.Name = "btnDelServicio";
         this.btnDelServicio.Size = new System.Drawing.Size(25, 25);
         this.btnDelServicio.TabIndex = 11;
         this.btnDelServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnDelServicio, "Eliminar Servicio");
         this.btnDelServicio.UseVisualStyleBackColor = false;
         // 
         // panelCaption5
         // 
         this.panelCaption5.AllowActive = false;
         this.panelCaption5.AntiAlias = false;
         this.panelCaption5.Caption = "Servicios Adicionales";
         this.panelCaption5.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption5.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption5.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption5.Location = new System.Drawing.Point(0, 0);
         this.panelCaption5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption5.Name = "panelCaption5";
         this.panelCaption5.Size = new System.Drawing.Size(1196, 27);
         this.panelCaption5.TabIndex = 10;
         // 
         // pageChangeControl
         // 
         this.pageChangeControl.Controls.Add(this.grdServiciosChangeControl);
         this.pageChangeControl.Controls.Add(this.button1);
         this.pageChangeControl.Controls.Add(this.button2);
         this.pageChangeControl.Controls.Add(this.panelCaption16);
         this.pageChangeControl.Location = new System.Drawing.Point(4, 25);
         this.pageChangeControl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.pageChangeControl.Name = "pageChangeControl";
         this.pageChangeControl.Size = new System.Drawing.Size(1196, 154);
         this.pageChangeControl.TabIndex = 1;
         this.pageChangeControl.Text = "Servicios Change Control";
         // 
         // grdServiciosChangeControl
         // 
         this.grdServiciosChangeControl.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdServiciosChangeControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdServiciosChangeControl.Location = new System.Drawing.Point(0, 27);
         this.grdServiciosChangeControl.Margin = new System.Windows.Forms.Padding(2, 3, 18, 3);
         this.grdServiciosChangeControl.Name = "grdServiciosChangeControl";
         // 
         // 
         // 
         this.grdServiciosChangeControl.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 27, 240, 150);
         this.grdServiciosChangeControl.RootElement.MinSize = new System.Drawing.Size(0, 0);
         this.grdServiciosChangeControl.Size = new System.Drawing.Size(1196, 127);
         this.grdServiciosChangeControl.TabIndex = 13;
         this.grdServiciosChangeControl.TabStop = false;
         // 
         // button1
         // 
         this.button1.BackColor = System.Drawing.Color.Transparent;
         this.button1.Image = global::Delfin.Comercial.Properties.Resources.add16x16;
         this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button1.Location = new System.Drawing.Point(287, 1);
         this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(25, 25);
         this.button1.TabIndex = 11;
         this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.button1, "Nuevo Servicio");
         this.button1.UseVisualStyleBackColor = false;
         // 
         // button2
         // 
         this.button2.BackColor = System.Drawing.Color.Transparent;
         this.button2.Image = global::Delfin.Comercial.Properties.Resources.delete1;
         this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button2.Location = new System.Drawing.Point(318, 1);
         this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(25, 25);
         this.button2.TabIndex = 12;
         this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.button2, "Eliminar Servicio");
         this.button2.UseVisualStyleBackColor = false;
         // 
         // panelCaption16
         // 
         this.panelCaption16.AllowActive = false;
         this.panelCaption16.AntiAlias = false;
         this.panelCaption16.Caption = "Servicios Change Control";
         this.panelCaption16.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption16.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption16.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption16.Location = new System.Drawing.Point(0, 0);
         this.panelCaption16.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption16.Name = "panelCaption16";
         this.panelCaption16.Size = new System.Drawing.Size(1196, 27);
         this.panelCaption16.TabIndex = 10;
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.grdItemsFlete);
         this.panel1.Controls.Add(this.tableLayoutPanel4);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel1.Location = new System.Drawing.Point(0, 190);
         this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(1204, 121);
         this.panel1.TabIndex = 50;
         // 
         // grdItemsFlete
         // 
         this.grdItemsFlete.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdItemsFlete.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItemsFlete.Location = new System.Drawing.Point(0, 0);
         this.grdItemsFlete.Name = "grdItemsFlete";
         // 
         // 
         // 
         this.grdItemsFlete.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 240, 150);
         this.grdItemsFlete.RootElement.MaxSize = new System.Drawing.Size(0, 0);
         this.grdItemsFlete.RootElement.MinSize = new System.Drawing.Size(0, 0);
         this.grdItemsFlete.Size = new System.Drawing.Size(1204, 94);
         this.grdItemsFlete.TabIndex = 0;
         this.grdItemsFlete.TabStop = false;
         // 
         // tableLayoutPanel4
         // 
         this.tableLayoutPanel4.AutoSize = true;
         this.tableLayoutPanel4.ColumnCount = 12;
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel4.Controls.Add(this.lblCCOT_PagoMBL, 0, 0);
         this.tableLayoutPanel4.Controls.Add(this.CCOT_PagoMBL, 1, 0);
         this.tableLayoutPanel4.Controls.Add(this.lblCCOT_PagoHBL, 3, 0);
         this.tableLayoutPanel4.Controls.Add(this.CCOT_PagoHBL, 4, 0);
         this.tableLayoutPanel4.Controls.Add(this.lblDCOT_Importe, 6, 0);
         this.tableLayoutPanel4.Controls.Add(this.DCOT_Importe, 7, 0);
         this.tableLayoutPanel4.Controls.Add(this.lblDCOT_Rentabilidad, 9, 0);
         this.tableLayoutPanel4.Controls.Add(this.DCOT_Rentabilidad, 10, 0);
         this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 94);
         this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.tableLayoutPanel4.Name = "tableLayoutPanel4";
         this.tableLayoutPanel4.RowCount = 1;
         this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel4.Size = new System.Drawing.Size(1204, 27);
         this.tableLayoutPanel4.TabIndex = 1;
         // 
         // lblCCOT_PagoMBL
         // 
         this.lblCCOT_PagoMBL.AutoSize = true;
         this.lblCCOT_PagoMBL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_PagoMBL.Location = new System.Drawing.Point(10, 7);
         this.lblCCOT_PagoMBL.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_PagoMBL.Name = "lblCCOT_PagoMBL";
         this.lblCCOT_PagoMBL.Size = new System.Drawing.Size(76, 13);
         this.lblCCOT_PagoMBL.TabIndex = 0;
         this.lblCCOT_PagoMBL.Text = "P/C (MBL):";
         // 
         // CCOT_PagoMBL
         // 
         this.CCOT_PagoMBL.ComboIntSelectedValue = null;
         this.CCOT_PagoMBL.ComboSelectedItem = null;
         this.CCOT_PagoMBL.ComboStrSelectedValue = null;
         this.CCOT_PagoMBL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CCOT_PagoMBL.FormattingEnabled = true;
         this.CCOT_PagoMBL.Location = new System.Drawing.Point(102, 3);
         this.CCOT_PagoMBL.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_PagoMBL.Name = "CCOT_PagoMBL";
         this.CCOT_PagoMBL.Size = new System.Drawing.Size(146, 21);
         this.CCOT_PagoMBL.TabIndex = 1;
         this.CCOT_PagoMBL.Tag = "CCOT_PagoMBLMSGERROR";
         // 
         // lblCCOT_PagoHBL
         // 
         this.lblCCOT_PagoHBL.AutoSize = true;
         this.lblCCOT_PagoHBL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_PagoHBL.Location = new System.Drawing.Point(275, 7);
         this.lblCCOT_PagoHBL.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_PagoHBL.Name = "lblCCOT_PagoHBL";
         this.lblCCOT_PagoHBL.Size = new System.Drawing.Size(75, 13);
         this.lblCCOT_PagoHBL.TabIndex = 2;
         this.lblCCOT_PagoHBL.Text = "P/C (HBL):";
         // 
         // CCOT_PagoHBL
         // 
         this.CCOT_PagoHBL.ComboIntSelectedValue = null;
         this.CCOT_PagoHBL.ComboSelectedItem = null;
         this.CCOT_PagoHBL.ComboStrSelectedValue = null;
         this.CCOT_PagoHBL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CCOT_PagoHBL.FormattingEnabled = true;
         this.CCOT_PagoHBL.Location = new System.Drawing.Point(367, 3);
         this.CCOT_PagoHBL.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_PagoHBL.Name = "CCOT_PagoHBL";
         this.CCOT_PagoHBL.Size = new System.Drawing.Size(146, 21);
         this.CCOT_PagoHBL.TabIndex = 3;
         this.CCOT_PagoHBL.Tag = "CCOT_PagoHBLMSGERROR";
         // 
         // lblDCOT_Importe
         // 
         this.lblDCOT_Importe.AutoSize = true;
         this.lblDCOT_Importe.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblDCOT_Importe.Location = new System.Drawing.Point(540, 7);
         this.lblDCOT_Importe.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblDCOT_Importe.Name = "lblDCOT_Importe";
         this.lblDCOT_Importe.Size = new System.Drawing.Size(80, 13);
         this.lblDCOT_Importe.TabIndex = 4;
         this.lblDCOT_Importe.Text = "Flete (Total):";
         // 
         // DCOT_Importe
         // 
         this.DCOT_Importe.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.DCOT_Importe.Decimales = 2;
         this.DCOT_Importe.Enteros = 9;
         this.DCOT_Importe.Formato = "###,###,##0.00";
         this.DCOT_Importe.Location = new System.Drawing.Point(632, 3);
         this.DCOT_Importe.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.DCOT_Importe.MaxLength = 13;
         this.DCOT_Importe.Name = "DCOT_Importe";
         this.DCOT_Importe.Negativo = true;
         this.DCOT_Importe.SinFormato = false;
         this.DCOT_Importe.Size = new System.Drawing.Size(146, 20);
         this.DCOT_Importe.TabIndex = 5;
         this.DCOT_Importe.Tag = "DCOT_ImporteMSGERROR";
         this.DCOT_Importe.Text = "0.00";
         this.DCOT_Importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.DCOT_Importe.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // lblDCOT_Rentabilidad
         // 
         this.lblDCOT_Rentabilidad.AutoSize = true;
         this.lblDCOT_Rentabilidad.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblDCOT_Rentabilidad.Location = new System.Drawing.Point(805, 7);
         this.lblDCOT_Rentabilidad.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblDCOT_Rentabilidad.Name = "lblDCOT_Rentabilidad";
         this.lblDCOT_Rentabilidad.Size = new System.Drawing.Size(82, 13);
         this.lblDCOT_Rentabilidad.TabIndex = 6;
         this.lblDCOT_Rentabilidad.Text = "Rentabilidad:";
         this.lblDCOT_Rentabilidad.Visible = false;
         // 
         // DCOT_Rentabilidad
         // 
         this.DCOT_Rentabilidad.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.DCOT_Rentabilidad.Decimales = 2;
         this.DCOT_Rentabilidad.Enteros = 9;
         this.DCOT_Rentabilidad.Formato = "###,###,##0.00";
         this.DCOT_Rentabilidad.Location = new System.Drawing.Point(897, 3);
         this.DCOT_Rentabilidad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.DCOT_Rentabilidad.MaxLength = 13;
         this.DCOT_Rentabilidad.Name = "DCOT_Rentabilidad";
         this.DCOT_Rentabilidad.Negativo = true;
         this.DCOT_Rentabilidad.SinFormato = false;
         this.DCOT_Rentabilidad.Size = new System.Drawing.Size(146, 20);
         this.DCOT_Rentabilidad.TabIndex = 7;
         this.DCOT_Rentabilidad.Tag = "DCOT_RentabilidadMSGERROR";
         this.DCOT_Rentabilidad.Text = "0.00";
         this.DCOT_Rentabilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.DCOT_Rentabilidad.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         this.DCOT_Rentabilidad.Visible = false;
         // 
         // panel8
         // 
         this.panel8.Controls.Add(this.btnDelFlete);
         this.panel8.Controls.Add(this.btnAddFlete);
         this.panel8.Controls.Add(this.panelCaption4);
         this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel8.Location = new System.Drawing.Point(0, 161);
         this.panel8.Name = "panel8";
         this.panel8.Size = new System.Drawing.Size(1204, 29);
         this.panel8.TabIndex = 53;
         // 
         // btnDelFlete
         // 
         this.btnDelFlete.BackColor = System.Drawing.Color.Transparent;
         this.btnDelFlete.Image = global::Delfin.Comercial.Properties.Resources.delete1;
         this.btnDelFlete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnDelFlete.Location = new System.Drawing.Point(73, 2);
         this.btnDelFlete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnDelFlete.Name = "btnDelFlete";
         this.btnDelFlete.Size = new System.Drawing.Size(25, 25);
         this.btnDelFlete.TabIndex = 3;
         this.btnDelFlete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnDelFlete, "Eliminar Servicio Flete");
         this.btnDelFlete.UseVisualStyleBackColor = false;
         // 
         // btnAddFlete
         // 
         this.btnAddFlete.BackColor = System.Drawing.Color.Transparent;
         this.btnAddFlete.Image = global::Delfin.Comercial.Properties.Resources.add16x16;
         this.btnAddFlete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnAddFlete.Location = new System.Drawing.Point(44, 2);
         this.btnAddFlete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnAddFlete.Name = "btnAddFlete";
         this.btnAddFlete.Size = new System.Drawing.Size(25, 25);
         this.btnAddFlete.TabIndex = 2;
         this.btnAddFlete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnAddFlete, "Nuevo Servicio Flete");
         this.btnAddFlete.UseVisualStyleBackColor = false;
         // 
         // panelCaption4
         // 
         this.panelCaption4.AllowActive = false;
         this.panelCaption4.AntiAlias = false;
         this.panelCaption4.Caption = "Flete";
         this.panelCaption4.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption4.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption4.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption4.Location = new System.Drawing.Point(0, 0);
         this.panelCaption4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption4.Name = "panelCaption4";
         this.panelCaption4.Size = new System.Drawing.Size(1204, 27);
         this.panelCaption4.TabIndex = 2;
         // 
         // tableLayoutPanel3
         // 
         this.tableLayoutPanel3.AutoSize = true;
         this.tableLayoutPanel3.ColumnCount = 10;
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.Controls.Add(this.panel2, 1, 4);
         this.tableLayoutPanel3.Controls.Add(this.label19, 2, 0);
         this.tableLayoutPanel3.Controls.Add(this.ENTC_CodTransportista, 1, 0);
         this.tableLayoutPanel3.Controls.Add(this.lblENTC_CodTransportista, 0, 0);
         this.tableLayoutPanel3.Controls.Add(this.lblPUER_CodOrigen, 0, 1);
         this.tableLayoutPanel3.Controls.Add(this.ayudaPuerto1, 1, 1);
         this.tableLayoutPanel3.Controls.Add(this.lblPUER_CodDestino, 3, 1);
         this.tableLayoutPanel3.Controls.Add(this.ayudaPuerto2, 4, 1);
         this.tableLayoutPanel3.Controls.Add(this.lblPUER_CodTrasbordo, 6, 1);
         this.tableLayoutPanel3.Controls.Add(this.ayudaPuerto3, 7, 1);
         this.tableLayoutPanel3.Controls.Add(this.label34, 0, 2);
         this.tableLayoutPanel3.Controls.Add(this.maskDateTime3, 1, 2);
         this.tableLayoutPanel3.Controls.Add(this.label35, 3, 2);
         this.tableLayoutPanel3.Controls.Add(this.maskDateTime4, 4, 2);
         this.tableLayoutPanel3.Controls.Add(this.label8, 6, 2);
         this.tableLayoutPanel3.Controls.Add(this.maskDateTime1, 7, 2);
         this.tableLayoutPanel3.Controls.Add(this.lblCONS_CodTFT, 0, 3);
         this.tableLayoutPanel3.Controls.Add(this.CONS_CodTFT, 1, 3);
         this.tableLayoutPanel3.Controls.Add(this.lblCCOT_FecTarifa, 3, 3);
         this.tableLayoutPanel3.Controls.Add(this.CCOT_FecTarifa, 4, 3);
         this.tableLayoutPanel3.Controls.Add(this.lblTIPO_CodMND, 6, 3);
         this.tableLayoutPanel3.Controls.Add(this.TIPO_CodMND, 7, 3);
         this.tableLayoutPanel3.Controls.Add(this.lblCONT_Numero, 0, 4);
         this.tableLayoutPanel3.Controls.Add(this.CONT_Descrip, 3, 4);
         this.tableLayoutPanel3.Controls.Add(this.lblCONS_CodFLE, 6, 4);
         this.tableLayoutPanel3.Controls.Add(this.CONS_CodFLE, 7, 4);
         this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 26);
         this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 5;
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.Size = new System.Drawing.Size(1204, 135);
         this.tableLayoutPanel3.TabIndex = 0;
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.CONT_Numero);
         this.panel2.Controls.Add(this.btnCambiarContrato);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel2.Location = new System.Drawing.Point(150, 108);
         this.panel2.Margin = new System.Windows.Forms.Padding(0);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(200, 27);
         this.panel2.TabIndex = 24;
         // 
         // CONT_Numero
         // 
         this.CONT_Numero.ActivarAyudaAuto = false;
         this.CONT_Numero.EnabledAyuda = true;
         this.CONT_Numero.EnabledAyudaButton = true;
         this.CONT_Numero.EsFiltro = false;
         this.CONT_Numero.Location = new System.Drawing.Point(5, 3);
         this.CONT_Numero.LongitudAceptada = 0;
         this.CONT_Numero.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CONT_Numero.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
         this.CONT_Numero.Name = "CONT_Numero";
         this.CONT_Numero.RellenaCeros = false;
         this.CONT_Numero.Size = new System.Drawing.Size(165, 20);
         this.CONT_Numero.TabIndex = 0;
         this.CONT_Numero.Tag = "CONT_NumeroMSGERROR";
         this.CONT_Numero.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
         this.CONT_Numero.Value = null;
         // 
         // btnCambiarContrato
         // 
         this.btnCambiarContrato.Image = global::Delfin.Comercial.Properties.Resources.replace14x14;
         this.btnCambiarContrato.Location = new System.Drawing.Point(174, 3);
         this.btnCambiarContrato.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnCambiarContrato.Name = "btnCambiarContrato";
         this.btnCambiarContrato.Size = new System.Drawing.Size(22, 20);
         this.btnCambiarContrato.TabIndex = 1;
         this.toolTip1.SetToolTip(this.btnCambiarContrato, "Cambiar Contrato");
         this.btnCambiarContrato.UseVisualStyleBackColor = true;
         // 
         // label19
         // 
         this.label19.AutoSize = true;
         this.label19.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label19.Location = new System.Drawing.Point(724, 7);
         this.label19.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label19.Name = "label19";
         this.label19.Size = new System.Drawing.Size(2, 20);
         this.label19.TabIndex = 2;
         this.label19.Text = "Tipo Fecha Tarifa:";
         // 
         // ENTC_CodTransportista
         // 
         this.ENTC_CodTransportista.ActivarAyudaAuto = false;
         this.tableLayoutPanel3.SetColumnSpan(this.ENTC_CodTransportista, 4);
         this.ENTC_CodTransportista.ContainerService = null;
         this.ENTC_CodTransportista.EnabledAyudaButton = true;
         this.ENTC_CodTransportista.Location = new System.Drawing.Point(152, 3);
         this.ENTC_CodTransportista.LongitudAceptada = 0;
         this.ENTC_CodTransportista.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ENTC_CodTransportista.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_CodTransportista.Name = "ENTC_CodTransportista";
         this.ENTC_CodTransportista.RellenaCeros = false;
         this.ENTC_CodTransportista.Size = new System.Drawing.Size(558, 20);
         this.ENTC_CodTransportista.TabIndex = 1;
         this.ENTC_CodTransportista.Tag = "ENTC_CodTransportistaMSGERROR";
         this.ENTC_CodTransportista.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
         this.ENTC_CodTransportista.Value = null;
         // 
         // lblENTC_CodTransportista
         // 
         this.lblENTC_CodTransportista.AutoSize = true;
         this.lblENTC_CodTransportista.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_CodTransportista.Location = new System.Drawing.Point(10, 7);
         this.lblENTC_CodTransportista.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblENTC_CodTransportista.Name = "lblENTC_CodTransportista";
         this.lblENTC_CodTransportista.Size = new System.Drawing.Size(86, 13);
         this.lblENTC_CodTransportista.TabIndex = 0;
         this.lblENTC_CodTransportista.Text = "Transportista:";
         // 
         // lblPUER_CodOrigen
         // 
         this.lblPUER_CodOrigen.AutoSize = true;
         this.lblPUER_CodOrigen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblPUER_CodOrigen.Location = new System.Drawing.Point(10, 34);
         this.lblPUER_CodOrigen.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblPUER_CodOrigen.Name = "lblPUER_CodOrigen";
         this.lblPUER_CodOrigen.Size = new System.Drawing.Size(101, 13);
         this.lblPUER_CodOrigen.TabIndex = 7;
         this.lblPUER_CodOrigen.Text = "Puerto Origen:";
         // 
         // ayudaPuerto1
         // 
         this.ayudaPuerto1.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ayudaPuerto1.CONS_CodVia = null;
         this.ayudaPuerto1.CONS_TabVia = null;
         this.ayudaPuerto1.DontSendTab = false;
         this.ayudaPuerto1.Location = new System.Drawing.Point(152, 30);
         this.ayudaPuerto1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ayudaPuerto1.Name = "ayudaPuerto1";
         this.ayudaPuerto1.SelectedItem = null;
         this.ayudaPuerto1.SelectedValue = null;
         this.ayudaPuerto1.Size = new System.Drawing.Size(194, 20);
         this.ayudaPuerto1.TabIndex = 28;
         this.ayudaPuerto1.TIPO_CodPais = null;
         this.ayudaPuerto1.TIPO_TabPais = null;
         this.ayudaPuerto1.Title = null;
         // 
         // lblPUER_CodDestino
         // 
         this.lblPUER_CodDestino.AutoSize = true;
         this.lblPUER_CodDestino.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblPUER_CodDestino.Location = new System.Drawing.Point(374, 34);
         this.lblPUER_CodDestino.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblPUER_CodDestino.Name = "lblPUER_CodDestino";
         this.lblPUER_CodDestino.Size = new System.Drawing.Size(107, 13);
         this.lblPUER_CodDestino.TabIndex = 13;
         this.lblPUER_CodDestino.Text = "Puerto Destino:";
         // 
         // ayudaPuerto2
         // 
         this.ayudaPuerto2.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ayudaPuerto2.CONS_CodVia = null;
         this.ayudaPuerto2.CONS_TabVia = null;
         this.ayudaPuerto2.DontSendTab = false;
         this.ayudaPuerto2.Location = new System.Drawing.Point(516, 30);
         this.ayudaPuerto2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ayudaPuerto2.Name = "ayudaPuerto2";
         this.ayudaPuerto2.SelectedItem = null;
         this.ayudaPuerto2.SelectedValue = null;
         this.ayudaPuerto2.Size = new System.Drawing.Size(194, 20);
         this.ayudaPuerto2.TabIndex = 29;
         this.ayudaPuerto2.TIPO_CodPais = null;
         this.ayudaPuerto2.TIPO_TabPais = null;
         this.ayudaPuerto2.Title = null;
         // 
         // lblPUER_CodTrasbordo
         // 
         this.lblPUER_CodTrasbordo.AutoSize = true;
         this.lblPUER_CodTrasbordo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblPUER_CodTrasbordo.Location = new System.Drawing.Point(738, 34);
         this.lblPUER_CodTrasbordo.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblPUER_CodTrasbordo.Name = "lblPUER_CodTrasbordo";
         this.lblPUER_CodTrasbordo.Size = new System.Drawing.Size(110, 13);
         this.lblPUER_CodTrasbordo.TabIndex = 19;
         this.lblPUER_CodTrasbordo.Text = "Puerto Trasbordo:";
         // 
         // ayudaPuerto3
         // 
         this.ayudaPuerto3.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ayudaPuerto3.CONS_CodVia = null;
         this.ayudaPuerto3.CONS_TabVia = null;
         this.ayudaPuerto3.DontSendTab = false;
         this.ayudaPuerto3.Location = new System.Drawing.Point(880, 30);
         this.ayudaPuerto3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ayudaPuerto3.Name = "ayudaPuerto3";
         this.ayudaPuerto3.SelectedItem = null;
         this.ayudaPuerto3.SelectedValue = null;
         this.ayudaPuerto3.Size = new System.Drawing.Size(194, 20);
         this.ayudaPuerto3.TabIndex = 30;
         this.ayudaPuerto3.TIPO_CodPais = null;
         this.ayudaPuerto3.TIPO_TabPais = null;
         this.ayudaPuerto3.Title = null;
         // 
         // label34
         // 
         this.label34.AutoSize = true;
         this.label34.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label34.Location = new System.Drawing.Point(10, 61);
         this.label34.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label34.Name = "label34";
         this.label34.Size = new System.Drawing.Size(107, 13);
         this.label34.TabIndex = 31;
         this.label34.Text = "Fecha Embarque:";
         // 
         // maskDateTime3
         // 
         this.maskDateTime3.Location = new System.Drawing.Point(152, 57);
         this.maskDateTime3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.maskDateTime3.MinimumSize = new System.Drawing.Size(100, 22);
         this.maskDateTime3.Name = "maskDateTime3";
         this.maskDateTime3.NSActiveMouse = false;
         this.maskDateTime3.NSActiveMsgFecha = false;
         this.maskDateTime3.NSChangeDate = true;
         this.maskDateTime3.NSDigitos = 4;
         this.maskDateTime3.NSFecha = null;
         this.maskDateTime3.NSSetDateNow = false;
         this.maskDateTime3.Size = new System.Drawing.Size(100, 22);
         this.maskDateTime3.TabIndex = 32;
         this.maskDateTime3.Tag = "CCOT_FecTarifaMSGERROR";
         // 
         // label35
         // 
         this.label35.AutoSize = true;
         this.label35.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label35.Location = new System.Drawing.Point(374, 61);
         this.label35.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label35.Name = "label35";
         this.label35.Size = new System.Drawing.Size(103, 13);
         this.label35.TabIndex = 33;
         this.label35.Text = "Fecha Descarga:";
         // 
         // maskDateTime4
         // 
         this.maskDateTime4.Location = new System.Drawing.Point(516, 57);
         this.maskDateTime4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.maskDateTime4.MinimumSize = new System.Drawing.Size(100, 22);
         this.maskDateTime4.Name = "maskDateTime4";
         this.maskDateTime4.NSActiveMouse = false;
         this.maskDateTime4.NSActiveMsgFecha = false;
         this.maskDateTime4.NSChangeDate = true;
         this.maskDateTime4.NSDigitos = 4;
         this.maskDateTime4.NSFecha = null;
         this.maskDateTime4.NSSetDateNow = false;
         this.maskDateTime4.Size = new System.Drawing.Size(100, 22);
         this.maskDateTime4.TabIndex = 34;
         this.maskDateTime4.Tag = "CCOT_FecTarifaMSGERROR";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label8.Location = new System.Drawing.Point(738, 61);
         this.label8.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(106, 13);
         this.label8.TabIndex = 26;
         this.label8.Text = "Fecha Trasbordo:";
         // 
         // maskDateTime1
         // 
         this.maskDateTime1.Location = new System.Drawing.Point(880, 57);
         this.maskDateTime1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.maskDateTime1.MinimumSize = new System.Drawing.Size(100, 22);
         this.maskDateTime1.Name = "maskDateTime1";
         this.maskDateTime1.NSActiveMouse = false;
         this.maskDateTime1.NSActiveMsgFecha = false;
         this.maskDateTime1.NSChangeDate = true;
         this.maskDateTime1.NSDigitos = 4;
         this.maskDateTime1.NSFecha = null;
         this.maskDateTime1.NSSetDateNow = false;
         this.maskDateTime1.Size = new System.Drawing.Size(100, 22);
         this.maskDateTime1.TabIndex = 27;
         this.maskDateTime1.Tag = "CCOT_FecTarifaMSGERROR";
         // 
         // lblCONS_CodTFT
         // 
         this.lblCONS_CodTFT.AutoSize = true;
         this.lblCONS_CodTFT.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONS_CodTFT.Location = new System.Drawing.Point(10, 88);
         this.lblCONS_CodTFT.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCONS_CodTFT.Name = "lblCONS_CodTFT";
         this.lblCONS_CodTFT.Size = new System.Drawing.Size(109, 13);
         this.lblCONS_CodTFT.TabIndex = 3;
         this.lblCONS_CodTFT.Text = "Tipo Fecha Tarifa:";
         // 
         // CONS_CodTFT
         // 
         this.CONS_CodTFT.ConstantesSelectedItem = null;
         this.CONS_CodTFT.ConstantesSelectedValue = null;
         this.CONS_CodTFT.ConstantesTitulo = null;
         this.CONS_CodTFT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CONS_CodTFT.FormattingEnabled = true;
         this.CONS_CodTFT.Location = new System.Drawing.Point(152, 84);
         this.CONS_CodTFT.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CONS_CodTFT.Name = "CONS_CodTFT";
         this.CONS_CodTFT.Size = new System.Drawing.Size(194, 21);
         this.CONS_CodTFT.TabIndex = 4;
         this.CONS_CodTFT.Tag = "CONS_CodTFTMSGERROR";
         // 
         // lblCCOT_FecTarifa
         // 
         this.lblCCOT_FecTarifa.AutoSize = true;
         this.lblCCOT_FecTarifa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_FecTarifa.Location = new System.Drawing.Point(374, 88);
         this.lblCCOT_FecTarifa.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_FecTarifa.Name = "lblCCOT_FecTarifa";
         this.lblCCOT_FecTarifa.Size = new System.Drawing.Size(81, 13);
         this.lblCCOT_FecTarifa.TabIndex = 9;
         this.lblCCOT_FecTarifa.Text = "Fecha Tarifa:";
         // 
         // CCOT_FecTarifa
         // 
         this.CCOT_FecTarifa.Location = new System.Drawing.Point(516, 84);
         this.CCOT_FecTarifa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_FecTarifa.MinimumSize = new System.Drawing.Size(100, 22);
         this.CCOT_FecTarifa.Name = "CCOT_FecTarifa";
         this.CCOT_FecTarifa.NSActiveMouse = false;
         this.CCOT_FecTarifa.NSActiveMsgFecha = false;
         this.CCOT_FecTarifa.NSChangeDate = true;
         this.CCOT_FecTarifa.NSDigitos = 4;
         this.CCOT_FecTarifa.NSFecha = null;
         this.CCOT_FecTarifa.NSSetDateNow = false;
         this.CCOT_FecTarifa.Size = new System.Drawing.Size(100, 22);
         this.CCOT_FecTarifa.TabIndex = 10;
         this.CCOT_FecTarifa.Tag = "CCOT_FecTarifaMSGERROR";
         // 
         // lblTIPO_CodMND
         // 
         this.lblTIPO_CodMND.AutoSize = true;
         this.lblTIPO_CodMND.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPO_CodMND.Location = new System.Drawing.Point(738, 88);
         this.lblTIPO_CodMND.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblTIPO_CodMND.Name = "lblTIPO_CodMND";
         this.lblTIPO_CodMND.Size = new System.Drawing.Size(61, 13);
         this.lblTIPO_CodMND.TabIndex = 15;
         this.lblTIPO_CodMND.Text = "Moneda:";
         // 
         // TIPO_CodMND
         // 
         this.TIPO_CodMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.TIPO_CodMND.FormattingEnabled = true;
         this.TIPO_CodMND.Location = new System.Drawing.Point(880, 84);
         this.TIPO_CodMND.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.TIPO_CodMND.Name = "TIPO_CodMND";
         this.TIPO_CodMND.Size = new System.Drawing.Size(194, 21);
         this.TIPO_CodMND.TabIndex = 16;
         this.TIPO_CodMND.Tag = "TIPO_CodMNDMSGERROR";
         this.TIPO_CodMND.TiposSelectedItem = null;
         this.TIPO_CodMND.TiposSelectedValue = null;
         this.TIPO_CodMND.TiposTitulo = null;
         // 
         // lblCONT_Numero
         // 
         this.lblCONT_Numero.AutoSize = true;
         this.lblCONT_Numero.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_Numero.Location = new System.Drawing.Point(10, 115);
         this.lblCONT_Numero.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCONT_Numero.Name = "lblCONT_Numero";
         this.lblCONT_Numero.Size = new System.Drawing.Size(111, 13);
         this.lblCONT_Numero.TabIndex = 23;
         this.lblCONT_Numero.Text = "Número Contrato:";
         // 
         // CONT_Descrip
         // 
         this.tableLayoutPanel3.SetColumnSpan(this.CONT_Descrip, 2);
         this.CONT_Descrip.Location = new System.Drawing.Point(366, 111);
         this.CONT_Descrip.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CONT_Descrip.Name = "CONT_Descrip";
         this.CONT_Descrip.Size = new System.Drawing.Size(344, 20);
         this.CONT_Descrip.TabIndex = 25;
         this.CONT_Descrip.Tag = "CONT_DescripMSGERROR";
         // 
         // lblCONS_CodFLE
         // 
         this.lblCONS_CodFLE.AutoSize = true;
         this.lblCONS_CodFLE.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONS_CodFLE.Location = new System.Drawing.Point(738, 115);
         this.lblCONS_CodFLE.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCONS_CodFLE.Name = "lblCONS_CodFLE";
         this.lblCONS_CodFLE.Size = new System.Drawing.Size(74, 13);
         this.lblCONS_CodFLE.TabIndex = 21;
         this.lblCONS_CodFLE.Text = "Condición:";
         // 
         // CONS_CodFLE
         // 
         this.CONS_CodFLE.ConstantesSelectedItem = null;
         this.CONS_CodFLE.ConstantesSelectedValue = null;
         this.CONS_CodFLE.ConstantesTitulo = null;
         this.CONS_CodFLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CONS_CodFLE.FormattingEnabled = true;
         this.CONS_CodFLE.Location = new System.Drawing.Point(880, 111);
         this.CONS_CodFLE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CONS_CodFLE.Name = "CONS_CodFLE";
         this.CONS_CodFLE.Size = new System.Drawing.Size(194, 21);
         this.CONS_CodFLE.TabIndex = 22;
         this.CONS_CodFLE.Tag = "CONS_CodFLEMSGERROR";
         // 
         // panelCaption3
         // 
         this.panelCaption3.AllowActive = false;
         this.panelCaption3.AntiAlias = false;
         this.panelCaption3.Caption = "Datos de Contrato";
         this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption3.Location = new System.Drawing.Point(0, 0);
         this.panelCaption3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption3.Name = "panelCaption3";
         this.panelCaption3.Size = new System.Drawing.Size(1204, 26);
         this.panelCaption3.TabIndex = 0;
         // 
         // pageEmbarque
         // 
         this.pageEmbarque.Controls.Add(this.tabControlEX1);
         this.pageEmbarque.Location = new System.Drawing.Point(4, 25);
         this.pageEmbarque.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.pageEmbarque.Name = "pageEmbarque";
         this.pageEmbarque.Size = new System.Drawing.Size(1204, 494);
         this.pageEmbarque.TabIndex = 2;
         this.pageEmbarque.Text = "Datos Embarque";
         // 
         // tabControlEX1
         // 
         this.tabControlEX1.Controls.Add(this.tabPageEX1);
         this.tabControlEX1.Controls.Add(this.tabPageEX2);
         this.tabControlEX1.Controls.Add(this.tabPageEX3);
         this.tabControlEX1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControlEX1.Location = new System.Drawing.Point(0, 0);
         this.tabControlEX1.Name = "tabControlEX1";
         this.tabControlEX1.SelectedIndex = 2;
         this.tabControlEX1.SelectedTabColor = System.Drawing.Color.SteelBlue;
         this.tabControlEX1.Size = new System.Drawing.Size(1204, 494);
         this.tabControlEX1.TabIndex = 33;
         this.tabControlEX1.UseVisualStyles = false;
         // 
         // tabPageEX1
         // 
         this.tabPageEX1.Controls.Add(this.tableLayoutPanel7);
         this.tabPageEX1.Controls.Add(this.panelCaption9);
         this.tabPageEX1.Controls.Add(this.tableDatosViaje);
         this.tabPageEX1.Controls.Add(this.panel10);
         this.tabPageEX1.Controls.Add(this.tableLayoutPanel8);
         this.tabPageEX1.Controls.Add(this.panelCaption12);
         this.tabPageEX1.Location = new System.Drawing.Point(4, 25);
         this.tabPageEX1.Name = "tabPageEX1";
         this.tabPageEX1.Size = new System.Drawing.Size(1196, 465);
         this.tabPageEX1.TabIndex = 0;
         this.tabPageEX1.Text = "Datos Documento";
         // 
         // tableLayoutPanel7
         // 
         this.tableLayoutPanel7.AutoSize = true;
         this.tableLayoutPanel7.ColumnCount = 10;
         this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel7.Controls.Add(this.CCOT_Roundtrip, 7, 0);
         this.tableLayoutPanel7.Controls.Add(this.lblCCOT_Roundtrip, 6, 0);
         this.tableLayoutPanel7.Controls.Add(this.CCOT_Temperatura, 4, 0);
         this.tableLayoutPanel7.Controls.Add(this.lblCCOT_Temperatura, 3, 0);
         this.tableLayoutPanel7.Controls.Add(this.CCOT_CargaRefrigerada, 1, 0);
         this.tableLayoutPanel7.Controls.Add(this.lblCCOT_CargaRefrigerada, 0, 0);
         this.tableLayoutPanel7.Controls.Add(this.TIPO_CodImo, 4, 1);
         this.tableLayoutPanel7.Controls.Add(this.CCOT_CargaPeligrosa, 1, 1);
         this.tableLayoutPanel7.Controls.Add(this.lblCCOT_CargaPeligrosa, 0, 1);
         this.tableLayoutPanel7.Controls.Add(this.lblTIPO_CodImo, 3, 1);
         this.tableLayoutPanel7.Controls.Add(this.lblCCOT_ValidezOferta, 6, 1);
         this.tableLayoutPanel7.Controls.Add(this.CCOT_ValidezOferta, 7, 1);
         this.tableLayoutPanel7.Controls.Add(this.lblCCOT_SobreEstadia, 6, 2);
         this.tableLayoutPanel7.Controls.Add(this.CCOT_SobreEstadia, 7, 2);
         this.tableLayoutPanel7.Controls.Add(this.lblCCOT_TiempoViaje, 3, 2);
         this.tableLayoutPanel7.Controls.Add(this.CCOT_TiempoViaje, 4, 2);
         this.tableLayoutPanel7.Controls.Add(this.lblCCOT_Almacenaje, 0, 2);
         this.tableLayoutPanel7.Controls.Add(this.CCOT_Almacenaje, 1, 2);
         this.tableLayoutPanel7.Controls.Add(this.label1, 0, 3);
         this.tableLayoutPanel7.Controls.Add(this.CCOT_Observaciones, 1, 3);
         this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 242);
         this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.tableLayoutPanel7.Name = "tableLayoutPanel7";
         this.tableLayoutPanel7.RowCount = 6;
         this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel7.Size = new System.Drawing.Size(1196, 162);
         this.tableLayoutPanel7.TabIndex = 35;
         // 
         // CCOT_Roundtrip
         // 
         this.CCOT_Roundtrip.AutoSize = true;
         this.CCOT_Roundtrip.Location = new System.Drawing.Point(880, 7);
         this.CCOT_Roundtrip.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.CCOT_Roundtrip.Name = "CCOT_Roundtrip";
         this.CCOT_Roundtrip.Size = new System.Drawing.Size(15, 14);
         this.CCOT_Roundtrip.TabIndex = 5;
         this.CCOT_Roundtrip.Tag = "CCOT_RoundtripMSGERROR";
         this.CCOT_Roundtrip.UseVisualStyleBackColor = true;
         // 
         // lblCCOT_Roundtrip
         // 
         this.lblCCOT_Roundtrip.AutoSize = true;
         this.lblCCOT_Roundtrip.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_Roundtrip.Location = new System.Drawing.Point(738, 7);
         this.lblCCOT_Roundtrip.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_Roundtrip.Name = "lblCCOT_Roundtrip";
         this.lblCCOT_Roundtrip.Size = new System.Drawing.Size(67, 13);
         this.lblCCOT_Roundtrip.TabIndex = 4;
         this.lblCCOT_Roundtrip.Text = "Roundtrip:";
         // 
         // CCOT_Temperatura
         // 
         this.CCOT_Temperatura.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.CCOT_Temperatura.Decimales = 2;
         this.CCOT_Temperatura.Enteros = 9;
         this.CCOT_Temperatura.Formato = "###,###,##0.00";
         this.CCOT_Temperatura.Location = new System.Drawing.Point(516, 3);
         this.CCOT_Temperatura.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_Temperatura.MaxLength = 13;
         this.CCOT_Temperatura.Name = "CCOT_Temperatura";
         this.CCOT_Temperatura.Negativo = true;
         this.CCOT_Temperatura.SinFormato = false;
         this.CCOT_Temperatura.Size = new System.Drawing.Size(194, 20);
         this.CCOT_Temperatura.TabIndex = 3;
         this.CCOT_Temperatura.Tag = "CCOT_TemperaturaMSGERROR";
         this.CCOT_Temperatura.Text = "0.00";
         this.CCOT_Temperatura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.CCOT_Temperatura.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
         // 
         // lblCCOT_Temperatura
         // 
         this.lblCCOT_Temperatura.AutoSize = true;
         this.lblCCOT_Temperatura.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_Temperatura.Location = new System.Drawing.Point(374, 7);
         this.lblCCOT_Temperatura.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_Temperatura.Name = "lblCCOT_Temperatura";
         this.lblCCOT_Temperatura.Size = new System.Drawing.Size(114, 13);
         this.lblCCOT_Temperatura.TabIndex = 2;
         this.lblCCOT_Temperatura.Text = "Temperatura (Cº):";
         // 
         // CCOT_CargaRefrigerada
         // 
         this.CCOT_CargaRefrigerada.AutoSize = true;
         this.CCOT_CargaRefrigerada.Location = new System.Drawing.Point(152, 7);
         this.CCOT_CargaRefrigerada.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.CCOT_CargaRefrigerada.Name = "CCOT_CargaRefrigerada";
         this.CCOT_CargaRefrigerada.Size = new System.Drawing.Size(15, 14);
         this.CCOT_CargaRefrigerada.TabIndex = 1;
         this.CCOT_CargaRefrigerada.Tag = "CCOT_CargaRefrigeradaMSGERROR";
         this.CCOT_CargaRefrigerada.UseVisualStyleBackColor = true;
         // 
         // lblCCOT_CargaRefrigerada
         // 
         this.lblCCOT_CargaRefrigerada.AutoSize = true;
         this.lblCCOT_CargaRefrigerada.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_CargaRefrigerada.Location = new System.Drawing.Point(10, 7);
         this.lblCCOT_CargaRefrigerada.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_CargaRefrigerada.Name = "lblCCOT_CargaRefrigerada";
         this.lblCCOT_CargaRefrigerada.Size = new System.Drawing.Size(118, 13);
         this.lblCCOT_CargaRefrigerada.TabIndex = 0;
         this.lblCCOT_CargaRefrigerada.Text = "Carga Refrigerada:";
         // 
         // TIPO_CodImo
         // 
         this.TIPO_CodImo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.TIPO_CodImo.FormattingEnabled = true;
         this.TIPO_CodImo.Location = new System.Drawing.Point(516, 30);
         this.TIPO_CodImo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.TIPO_CodImo.Name = "TIPO_CodImo";
         this.TIPO_CodImo.Size = new System.Drawing.Size(194, 21);
         this.TIPO_CodImo.TabIndex = 7;
         this.TIPO_CodImo.Tag = "TIPO_CodImoMSGERROR";
         this.TIPO_CodImo.TiposSelectedItem = null;
         this.TIPO_CodImo.TiposSelectedValue = null;
         this.TIPO_CodImo.TiposTitulo = null;
         // 
         // CCOT_CargaPeligrosa
         // 
         this.CCOT_CargaPeligrosa.AutoSize = true;
         this.CCOT_CargaPeligrosa.Location = new System.Drawing.Point(152, 34);
         this.CCOT_CargaPeligrosa.Margin = new System.Windows.Forms.Padding(2, 7, 2, 3);
         this.CCOT_CargaPeligrosa.Name = "CCOT_CargaPeligrosa";
         this.CCOT_CargaPeligrosa.Size = new System.Drawing.Size(15, 14);
         this.CCOT_CargaPeligrosa.TabIndex = 9;
         this.CCOT_CargaPeligrosa.Tag = "CCOT_CargaPeligrosaMSGERROR";
         this.CCOT_CargaPeligrosa.UseVisualStyleBackColor = true;
         // 
         // lblCCOT_CargaPeligrosa
         // 
         this.lblCCOT_CargaPeligrosa.AutoSize = true;
         this.lblCCOT_CargaPeligrosa.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_CargaPeligrosa.Location = new System.Drawing.Point(10, 34);
         this.lblCCOT_CargaPeligrosa.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_CargaPeligrosa.Name = "lblCCOT_CargaPeligrosa";
         this.lblCCOT_CargaPeligrosa.Size = new System.Drawing.Size(103, 13);
         this.lblCCOT_CargaPeligrosa.TabIndex = 8;
         this.lblCCOT_CargaPeligrosa.Text = "Carga Peligrosa:";
         // 
         // lblTIPO_CodImo
         // 
         this.lblTIPO_CodImo.AutoSize = true;
         this.lblTIPO_CodImo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPO_CodImo.Location = new System.Drawing.Point(374, 34);
         this.lblTIPO_CodImo.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblTIPO_CodImo.Name = "lblTIPO_CodImo";
         this.lblTIPO_CodImo.Size = new System.Drawing.Size(70, 13);
         this.lblTIPO_CodImo.TabIndex = 6;
         this.lblTIPO_CodImo.Text = "IMO Class:";
         // 
         // lblCCOT_ValidezOferta
         // 
         this.lblCCOT_ValidezOferta.AutoSize = true;
         this.lblCCOT_ValidezOferta.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_ValidezOferta.Location = new System.Drawing.Point(738, 34);
         this.lblCCOT_ValidezOferta.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_ValidezOferta.Name = "lblCCOT_ValidezOferta";
         this.lblCCOT_ValidezOferta.Size = new System.Drawing.Size(129, 13);
         this.lblCCOT_ValidezOferta.TabIndex = 6;
         this.lblCCOT_ValidezOferta.Text = "Validez Oferta (días):";
         // 
         // CCOT_ValidezOferta
         // 
         this.CCOT_ValidezOferta.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
         this.CCOT_ValidezOferta.Decimales = 0;
         this.CCOT_ValidezOferta.Enteros = 9;
         this.CCOT_ValidezOferta.Formato = "###,###,##0.";
         this.CCOT_ValidezOferta.Location = new System.Drawing.Point(880, 30);
         this.CCOT_ValidezOferta.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_ValidezOferta.MaxLength = 10;
         this.CCOT_ValidezOferta.Name = "CCOT_ValidezOferta";
         this.CCOT_ValidezOferta.Negativo = true;
         this.CCOT_ValidezOferta.SinFormato = false;
         this.CCOT_ValidezOferta.Size = new System.Drawing.Size(194, 20);
         this.CCOT_ValidezOferta.TabIndex = 7;
         this.CCOT_ValidezOferta.Tag = "CCOT_ValidezOfertaMSGERROR";
         this.CCOT_ValidezOferta.Text = "0";
         this.CCOT_ValidezOferta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.CCOT_ValidezOferta.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblCCOT_SobreEstadia
         // 
         this.lblCCOT_SobreEstadia.AutoSize = true;
         this.lblCCOT_SobreEstadia.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_SobreEstadia.Location = new System.Drawing.Point(738, 61);
         this.lblCCOT_SobreEstadia.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_SobreEstadia.Name = "lblCCOT_SobreEstadia";
         this.lblCCOT_SobreEstadia.Size = new System.Drawing.Size(124, 13);
         this.lblCCOT_SobreEstadia.TabIndex = 4;
         this.lblCCOT_SobreEstadia.Text = "Sobreestadía (días):";
         // 
         // CCOT_SobreEstadia
         // 
         this.CCOT_SobreEstadia.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
         this.CCOT_SobreEstadia.Decimales = 0;
         this.CCOT_SobreEstadia.Enteros = 9;
         this.CCOT_SobreEstadia.Formato = "###,###,##0.";
         this.CCOT_SobreEstadia.Location = new System.Drawing.Point(880, 57);
         this.CCOT_SobreEstadia.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_SobreEstadia.MaxLength = 10;
         this.CCOT_SobreEstadia.Name = "CCOT_SobreEstadia";
         this.CCOT_SobreEstadia.Negativo = true;
         this.CCOT_SobreEstadia.SinFormato = false;
         this.CCOT_SobreEstadia.Size = new System.Drawing.Size(194, 20);
         this.CCOT_SobreEstadia.TabIndex = 5;
         this.CCOT_SobreEstadia.Tag = "CCOT_SobreEstadiaMSGERROR";
         this.CCOT_SobreEstadia.Text = "0";
         this.CCOT_SobreEstadia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.CCOT_SobreEstadia.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblCCOT_TiempoViaje
         // 
         this.lblCCOT_TiempoViaje.AutoSize = true;
         this.lblCCOT_TiempoViaje.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_TiempoViaje.Location = new System.Drawing.Point(374, 61);
         this.lblCCOT_TiempoViaje.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_TiempoViaje.Name = "lblCCOT_TiempoViaje";
         this.lblCCOT_TiempoViaje.Size = new System.Drawing.Size(124, 13);
         this.lblCCOT_TiempoViaje.TabIndex = 2;
         this.lblCCOT_TiempoViaje.Text = "Tiempo Viaje (días):";
         // 
         // CCOT_TiempoViaje
         // 
         this.CCOT_TiempoViaje.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
         this.CCOT_TiempoViaje.Decimales = 0;
         this.CCOT_TiempoViaje.Enteros = 9;
         this.CCOT_TiempoViaje.Formato = "###,###,##0.";
         this.CCOT_TiempoViaje.Location = new System.Drawing.Point(516, 57);
         this.CCOT_TiempoViaje.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_TiempoViaje.MaxLength = 10;
         this.CCOT_TiempoViaje.Name = "CCOT_TiempoViaje";
         this.CCOT_TiempoViaje.Negativo = true;
         this.CCOT_TiempoViaje.SinFormato = false;
         this.CCOT_TiempoViaje.Size = new System.Drawing.Size(194, 20);
         this.CCOT_TiempoViaje.TabIndex = 3;
         this.CCOT_TiempoViaje.Tag = "CCOT_TiempoViajeMSGERROR";
         this.CCOT_TiempoViaje.Text = "0";
         this.CCOT_TiempoViaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.CCOT_TiempoViaje.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblCCOT_Almacenaje
         // 
         this.lblCCOT_Almacenaje.AutoSize = true;
         this.lblCCOT_Almacenaje.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_Almacenaje.Location = new System.Drawing.Point(10, 61);
         this.lblCCOT_Almacenaje.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_Almacenaje.Name = "lblCCOT_Almacenaje";
         this.lblCCOT_Almacenaje.Size = new System.Drawing.Size(116, 13);
         this.lblCCOT_Almacenaje.TabIndex = 0;
         this.lblCCOT_Almacenaje.Text = "Almacenaje (días):";
         // 
         // CCOT_Almacenaje
         // 
         this.CCOT_Almacenaje.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
         this.CCOT_Almacenaje.Decimales = 0;
         this.CCOT_Almacenaje.Enteros = 9;
         this.CCOT_Almacenaje.Formato = "###,###,##0.";
         this.CCOT_Almacenaje.Location = new System.Drawing.Point(152, 57);
         this.CCOT_Almacenaje.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_Almacenaje.MaxLength = 10;
         this.CCOT_Almacenaje.Name = "CCOT_Almacenaje";
         this.CCOT_Almacenaje.Negativo = true;
         this.CCOT_Almacenaje.SinFormato = false;
         this.CCOT_Almacenaje.Size = new System.Drawing.Size(194, 20);
         this.CCOT_Almacenaje.TabIndex = 1;
         this.CCOT_Almacenaje.Tag = "CCOT_AlmacenajeMSGERROR";
         this.CCOT_Almacenaje.Text = "0";
         this.CCOT_Almacenaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.CCOT_Almacenaje.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 88);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(96, 13);
         this.label1.TabIndex = 8;
         this.label1.Text = "Observaciones:";
         // 
         // CCOT_Observaciones
         // 
         this.tableLayoutPanel7.SetColumnSpan(this.CCOT_Observaciones, 7);
         this.CCOT_Observaciones.Location = new System.Drawing.Point(152, 84);
         this.CCOT_Observaciones.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CCOT_Observaciones.Multiline = true;
         this.CCOT_Observaciones.Name = "CCOT_Observaciones";
         this.tableLayoutPanel7.SetRowSpan(this.CCOT_Observaciones, 3);
         this.CCOT_Observaciones.Size = new System.Drawing.Size(922, 75);
         this.CCOT_Observaciones.TabIndex = 16;
         this.CCOT_Observaciones.Tag = "CCOT_ObservacionesMSGERROR";
         // 
         // panelCaption9
         // 
         this.panelCaption9.AllowActive = false;
         this.panelCaption9.AntiAlias = false;
         this.panelCaption9.Caption = "Datos de Observaciones";
         this.panelCaption9.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption9.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption9.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption9.Location = new System.Drawing.Point(0, 216);
         this.panelCaption9.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption9.Name = "panelCaption9";
         this.panelCaption9.Size = new System.Drawing.Size(1196, 26);
         this.panelCaption9.TabIndex = 34;
         // 
         // tableDatosViaje
         // 
         this.tableDatosViaje.AutoSize = true;
         this.tableDatosViaje.ColumnCount = 10;
         this.tableDatosViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableDatosViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableDatosViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableDatosViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableDatosViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableDatosViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableDatosViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableDatosViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableDatosViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableDatosViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableDatosViaje.Controls.Add(this.comboBox1, 1, 2);
         this.tableDatosViaje.Controls.Add(this.lblNVIA_FecETDMaster, 6, 1);
         this.tableDatosViaje.Controls.Add(this.label36, 0, 2);
         this.tableDatosViaje.Controls.Add(this.NVIA_FecETDMaster, 7, 1);
         this.tableDatosViaje.Controls.Add(this.lblNVIA_FecCutOff, 6, 2);
         this.tableDatosViaje.Controls.Add(this.textBoxAyuda1, 4, 2);
         this.tableDatosViaje.Controls.Add(this.NVIA_FecCutOff, 7, 2);
         this.tableDatosViaje.Controls.Add(this.lblDOOV_Feeder_IMPO, 0, 0);
         this.tableDatosViaje.Controls.Add(this.DOOV_Feeder_IMPO, 1, 0);
         this.tableDatosViaje.Controls.Add(this.lblNVIA_NroViaje, 0, 1);
         this.tableDatosViaje.Controls.Add(this.NVIA_NroViaje, 1, 1);
         this.tableDatosViaje.Controls.Add(this.lblNVIA_FecETA, 3, 1);
         this.tableDatosViaje.Controls.Add(this.NVIA_FecETA, 4, 1);
         this.tableDatosViaje.Controls.Add(this.DOOV_FecETDFeeder_IMPO, 7, 0);
         this.tableDatosViaje.Controls.Add(this.lblDOOV_FecETDFeeder_IMPO, 6, 0);
         this.tableDatosViaje.Controls.Add(this.lblNAVE_Nombre, 3, 2);
         this.tableDatosViaje.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableDatosViaje.Location = new System.Drawing.Point(0, 135);
         this.tableDatosViaje.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.tableDatosViaje.Name = "tableDatosViaje";
         this.tableDatosViaje.RowCount = 3;
         this.tableDatosViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableDatosViaje.Size = new System.Drawing.Size(1196, 81);
         this.tableDatosViaje.TabIndex = 33;
         // 
         // comboBox1
         // 
         this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox1.FormattingEnabled = true;
         this.comboBox1.Location = new System.Drawing.Point(153, 57);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(193, 21);
         this.comboBox1.TabIndex = 43;
         // 
         // lblNVIA_FecETDMaster
         // 
         this.lblNVIA_FecETDMaster.AutoSize = true;
         this.lblNVIA_FecETDMaster.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblNVIA_FecETDMaster.Location = new System.Drawing.Point(738, 34);
         this.lblNVIA_FecETDMaster.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblNVIA_FecETDMaster.Name = "lblNVIA_FecETDMaster";
         this.lblNVIA_FecETDMaster.Size = new System.Drawing.Size(54, 13);
         this.lblNVIA_FecETDMaster.TabIndex = 8;
         this.lblNVIA_FecETDMaster.Text = "ETD(M):";
         // 
         // label36
         // 
         this.label36.AutoSize = true;
         this.label36.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label36.Location = new System.Drawing.Point(10, 61);
         this.label36.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label36.Name = "label36";
         this.label36.Size = new System.Drawing.Size(42, 13);
         this.label36.TabIndex = 44;
         this.label36.Text = "Línea:";
         // 
         // NVIA_FecETDMaster
         // 
         this.NVIA_FecETDMaster.Location = new System.Drawing.Point(880, 30);
         this.NVIA_FecETDMaster.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.NVIA_FecETDMaster.MinimumSize = new System.Drawing.Size(100, 22);
         this.NVIA_FecETDMaster.Name = "NVIA_FecETDMaster";
         this.NVIA_FecETDMaster.NSActiveMouse = false;
         this.NVIA_FecETDMaster.NSActiveMsgFecha = false;
         this.NVIA_FecETDMaster.NSChangeDate = true;
         this.NVIA_FecETDMaster.NSDigitos = 4;
         this.NVIA_FecETDMaster.NSFecha = null;
         this.NVIA_FecETDMaster.NSSetDateNow = false;
         this.NVIA_FecETDMaster.Size = new System.Drawing.Size(100, 22);
         this.NVIA_FecETDMaster.TabIndex = 9;
         this.NVIA_FecETDMaster.Tag = "DOOV_ETDMMSGERROR";
         // 
         // lblNVIA_FecCutOff
         // 
         this.lblNVIA_FecCutOff.AutoSize = true;
         this.lblNVIA_FecCutOff.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblNVIA_FecCutOff.Location = new System.Drawing.Point(738, 61);
         this.lblNVIA_FecCutOff.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblNVIA_FecCutOff.Name = "lblNVIA_FecCutOff";
         this.lblNVIA_FecCutOff.Size = new System.Drawing.Size(53, 13);
         this.lblNVIA_FecCutOff.TabIndex = 22;
         this.lblNVIA_FecCutOff.Text = "Cut Off:";
         // 
         // textBoxAyuda1
         // 
         this.textBoxAyuda1.ActivarAyudaAuto = false;
         this.textBoxAyuda1.EnabledAyuda = true;
         this.textBoxAyuda1.EnabledAyudaButton = true;
         this.textBoxAyuda1.EsFiltro = false;
         this.textBoxAyuda1.Location = new System.Drawing.Point(516, 57);
         this.textBoxAyuda1.LongitudAceptada = 0;
         this.textBoxAyuda1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.textBoxAyuda1.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
         this.textBoxAyuda1.Name = "textBoxAyuda1";
         this.textBoxAyuda1.RellenaCeros = false;
         this.textBoxAyuda1.Size = new System.Drawing.Size(196, 20);
         this.textBoxAyuda1.TabIndex = 46;
         this.textBoxAyuda1.Tag = "CONT_NumeroMSGERROR";
         this.textBoxAyuda1.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
         this.textBoxAyuda1.Value = null;
         // 
         // NVIA_FecCutOff
         // 
         this.NVIA_FecCutOff.Location = new System.Drawing.Point(880, 57);
         this.NVIA_FecCutOff.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.NVIA_FecCutOff.MinimumSize = new System.Drawing.Size(100, 22);
         this.NVIA_FecCutOff.Name = "NVIA_FecCutOff";
         this.NVIA_FecCutOff.NSActiveMouse = false;
         this.NVIA_FecCutOff.NSActiveMsgFecha = false;
         this.NVIA_FecCutOff.NSChangeDate = true;
         this.NVIA_FecCutOff.NSDigitos = 4;
         this.NVIA_FecCutOff.NSFecha = null;
         this.NVIA_FecCutOff.NSSetDateNow = false;
         this.NVIA_FecCutOff.Size = new System.Drawing.Size(100, 22);
         this.NVIA_FecCutOff.TabIndex = 23;
         this.NVIA_FecCutOff.Tag = "DOOV_ETDMMSGERROR";
         // 
         // lblDOOV_Feeder_IMPO
         // 
         this.lblDOOV_Feeder_IMPO.AutoSize = true;
         this.lblDOOV_Feeder_IMPO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblDOOV_Feeder_IMPO.Location = new System.Drawing.Point(10, 7);
         this.lblDOOV_Feeder_IMPO.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblDOOV_Feeder_IMPO.Name = "lblDOOV_Feeder_IMPO";
         this.lblDOOV_Feeder_IMPO.Size = new System.Drawing.Size(51, 13);
         this.lblDOOV_Feeder_IMPO.TabIndex = 2;
         this.lblDOOV_Feeder_IMPO.Text = "Feeder:";
         // 
         // DOOV_Feeder_IMPO
         // 
         this.tableDatosViaje.SetColumnSpan(this.DOOV_Feeder_IMPO, 4);
         this.DOOV_Feeder_IMPO.Location = new System.Drawing.Point(152, 3);
         this.DOOV_Feeder_IMPO.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.DOOV_Feeder_IMPO.Name = "DOOV_Feeder_IMPO";
         this.DOOV_Feeder_IMPO.Size = new System.Drawing.Size(558, 20);
         this.DOOV_Feeder_IMPO.TabIndex = 3;
         this.DOOV_Feeder_IMPO.Tag = "DOOV_FeederMSGERROR";
         // 
         // lblNVIA_NroViaje
         // 
         this.lblNVIA_NroViaje.AutoSize = true;
         this.lblNVIA_NroViaje.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblNVIA_NroViaje.Location = new System.Drawing.Point(10, 34);
         this.lblNVIA_NroViaje.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblNVIA_NroViaje.Name = "lblNVIA_NroViaje";
         this.lblNVIA_NroViaje.Size = new System.Drawing.Size(41, 13);
         this.lblNVIA_NroViaje.TabIndex = 10;
         this.lblNVIA_NroViaje.Text = "Viaje:";
         // 
         // NVIA_NroViaje
         // 
         this.NVIA_NroViaje.ActivarAyudaAuto = false;
         this.NVIA_NroViaje.EnabledAyuda = true;
         this.NVIA_NroViaje.EnabledAyudaButton = true;
         this.NVIA_NroViaje.EsFiltro = false;
         this.NVIA_NroViaje.Location = new System.Drawing.Point(152, 30);
         this.NVIA_NroViaje.LongitudAceptada = 0;
         this.NVIA_NroViaje.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.NVIA_NroViaje.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
         this.NVIA_NroViaje.Name = "NVIA_NroViaje";
         this.NVIA_NroViaje.RellenaCeros = false;
         this.NVIA_NroViaje.Size = new System.Drawing.Size(194, 20);
         this.NVIA_NroViaje.TabIndex = 21;
         this.NVIA_NroViaje.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
         this.NVIA_NroViaje.Value = null;
         // 
         // lblNVIA_FecETA
         // 
         this.lblNVIA_FecETA.AutoSize = true;
         this.lblNVIA_FecETA.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblNVIA_FecETA.Location = new System.Drawing.Point(374, 34);
         this.lblNVIA_FecETA.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblNVIA_FecETA.Name = "lblNVIA_FecETA";
         this.lblNVIA_FecETA.Size = new System.Drawing.Size(33, 13);
         this.lblNVIA_FecETA.TabIndex = 12;
         this.lblNVIA_FecETA.Text = "ETA:";
         // 
         // NVIA_FecETA
         // 
         this.NVIA_FecETA.Location = new System.Drawing.Point(516, 30);
         this.NVIA_FecETA.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.NVIA_FecETA.MinimumSize = new System.Drawing.Size(100, 22);
         this.NVIA_FecETA.Name = "NVIA_FecETA";
         this.NVIA_FecETA.NSActiveMouse = false;
         this.NVIA_FecETA.NSActiveMsgFecha = false;
         this.NVIA_FecETA.NSChangeDate = true;
         this.NVIA_FecETA.NSDigitos = 4;
         this.NVIA_FecETA.NSFecha = null;
         this.NVIA_FecETA.NSSetDateNow = false;
         this.NVIA_FecETA.Size = new System.Drawing.Size(100, 22);
         this.NVIA_FecETA.TabIndex = 13;
         this.NVIA_FecETA.Tag = "DOOV_ETAMSGERROR";
         // 
         // DOOV_FecETDFeeder_IMPO
         // 
         this.DOOV_FecETDFeeder_IMPO.Location = new System.Drawing.Point(880, 3);
         this.DOOV_FecETDFeeder_IMPO.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.DOOV_FecETDFeeder_IMPO.MinimumSize = new System.Drawing.Size(100, 22);
         this.DOOV_FecETDFeeder_IMPO.Name = "DOOV_FecETDFeeder_IMPO";
         this.DOOV_FecETDFeeder_IMPO.NSActiveMouse = false;
         this.DOOV_FecETDFeeder_IMPO.NSActiveMsgFecha = false;
         this.DOOV_FecETDFeeder_IMPO.NSChangeDate = true;
         this.DOOV_FecETDFeeder_IMPO.NSDigitos = 4;
         this.DOOV_FecETDFeeder_IMPO.NSFecha = null;
         this.DOOV_FecETDFeeder_IMPO.NSSetDateNow = false;
         this.DOOV_FecETDFeeder_IMPO.Size = new System.Drawing.Size(100, 22);
         this.DOOV_FecETDFeeder_IMPO.TabIndex = 5;
         this.DOOV_FecETDFeeder_IMPO.Tag = "DOOV_ETDFMSGERROR";
         // 
         // lblDOOV_FecETDFeeder_IMPO
         // 
         this.lblDOOV_FecETDFeeder_IMPO.AutoSize = true;
         this.lblDOOV_FecETDFeeder_IMPO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblDOOV_FecETDFeeder_IMPO.Location = new System.Drawing.Point(738, 7);
         this.lblDOOV_FecETDFeeder_IMPO.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblDOOV_FecETDFeeder_IMPO.Name = "lblDOOV_FecETDFeeder_IMPO";
         this.lblDOOV_FecETDFeeder_IMPO.Size = new System.Drawing.Size(51, 13);
         this.lblDOOV_FecETDFeeder_IMPO.TabIndex = 4;
         this.lblDOOV_FecETDFeeder_IMPO.Text = "ETD(F):";
         // 
         // lblNAVE_Nombre
         // 
         this.lblNAVE_Nombre.AutoSize = true;
         this.lblNAVE_Nombre.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblNAVE_Nombre.Location = new System.Drawing.Point(374, 61);
         this.lblNAVE_Nombre.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblNAVE_Nombre.Name = "lblNAVE_Nombre";
         this.lblNAVE_Nombre.Size = new System.Drawing.Size(41, 13);
         this.lblNAVE_Nombre.TabIndex = 6;
         this.lblNAVE_Nombre.Text = "Nave:";
         // 
         // panel10
         // 
         this.panel10.Controls.Add(this.btnAddNaveViaje);
         this.panel10.Controls.Add(this.btnEditarNaveViaje);
         this.panel10.Controls.Add(this.panelCaption10);
         this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel10.Location = new System.Drawing.Point(0, 108);
         this.panel10.Name = "panel10";
         this.panel10.Size = new System.Drawing.Size(1196, 27);
         this.panel10.TabIndex = 32;
         // 
         // btnAddNaveViaje
         // 
         this.btnAddNaveViaje.BackColor = System.Drawing.Color.Transparent;
         this.btnAddNaveViaje.Image = global::Delfin.Comercial.Properties.Resources.add16x16;
         this.btnAddNaveViaje.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnAddNaveViaje.Location = new System.Drawing.Point(94, 0);
         this.btnAddNaveViaje.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnAddNaveViaje.Name = "btnAddNaveViaje";
         this.btnAddNaveViaje.Size = new System.Drawing.Size(25, 25);
         this.btnAddNaveViaje.TabIndex = 29;
         this.btnAddNaveViaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnAddNaveViaje, "Nuevo Viaje");
         this.btnAddNaveViaje.UseVisualStyleBackColor = false;
         // 
         // btnEditarNaveViaje
         // 
         this.btnEditarNaveViaje.BackColor = System.Drawing.Color.Transparent;
         this.btnEditarNaveViaje.Image = global::Delfin.Comercial.Properties.Resources.editar16x16;
         this.btnEditarNaveViaje.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnEditarNaveViaje.Location = new System.Drawing.Point(126, 0);
         this.btnEditarNaveViaje.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnEditarNaveViaje.Name = "btnEditarNaveViaje";
         this.btnEditarNaveViaje.Size = new System.Drawing.Size(25, 25);
         this.btnEditarNaveViaje.TabIndex = 28;
         this.btnEditarNaveViaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnEditarNaveViaje, "Editar Viaje");
         this.btnEditarNaveViaje.UseVisualStyleBackColor = false;
         // 
         // panelCaption10
         // 
         this.panelCaption10.AllowActive = false;
         this.panelCaption10.AntiAlias = false;
         this.panelCaption10.Caption = "Datos Viaje";
         this.panelCaption10.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption10.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption10.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption10.Location = new System.Drawing.Point(0, 0);
         this.panelCaption10.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption10.Name = "panelCaption10";
         this.panelCaption10.Size = new System.Drawing.Size(1196, 27);
         this.panelCaption10.TabIndex = 27;
         // 
         // tableLayoutPanel8
         // 
         this.tableLayoutPanel8.AutoSize = true;
         this.tableLayoutPanel8.ColumnCount = 10;
         this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel8.Controls.Add(this.TIPO_CodDTM, 1, 0);
         this.tableLayoutPanel8.Controls.Add(this.lblTIPO_CodDTM, 0, 0);
         this.tableLayoutPanel8.Controls.Add(this.DOOV_MBL, 7, 1);
         this.tableLayoutPanel8.Controls.Add(this.lblDOOV_Cntr, 0, 1);
         this.tableLayoutPanel8.Controls.Add(this.DOOV_Cntr, 1, 1);
         this.tableLayoutPanel8.Controls.Add(this.lblDOOV_MBL, 6, 1);
         this.tableLayoutPanel8.Controls.Add(this.lblDOOV_HBL, 6, 0);
         this.tableLayoutPanel8.Controls.Add(this.DOOV_HBL, 7, 0);
         this.tableLayoutPanel8.Controls.Add(this.label38, 6, 2);
         this.tableLayoutPanel8.Controls.Add(this.textBox11, 7, 2);
         this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 27);
         this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.tableLayoutPanel8.Name = "tableLayoutPanel8";
         this.tableLayoutPanel8.RowCount = 3;
         this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel8.Size = new System.Drawing.Size(1196, 81);
         this.tableLayoutPanel8.TabIndex = 10;
         // 
         // TIPO_CodDTM
         // 
         this.tableLayoutPanel8.SetColumnSpan(this.TIPO_CodDTM, 4);
         this.TIPO_CodDTM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.TIPO_CodDTM.FormattingEnabled = true;
         this.TIPO_CodDTM.Location = new System.Drawing.Point(152, 3);
         this.TIPO_CodDTM.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.TIPO_CodDTM.Name = "TIPO_CodDTM";
         this.TIPO_CodDTM.Size = new System.Drawing.Size(558, 21);
         this.TIPO_CodDTM.TabIndex = 1;
         this.TIPO_CodDTM.Tag = "TIPO_CodDTMMSGERROR";
         this.TIPO_CodDTM.TiposSelectedItem = null;
         this.TIPO_CodDTM.TiposSelectedValue = null;
         this.TIPO_CodDTM.TiposTitulo = null;
         // 
         // lblTIPO_CodDTM
         // 
         this.lblTIPO_CodDTM.AutoSize = true;
         this.lblTIPO_CodDTM.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPO_CodDTM.Location = new System.Drawing.Point(10, 7);
         this.lblTIPO_CodDTM.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblTIPO_CodDTM.Name = "lblTIPO_CodDTM";
         this.lblTIPO_CodDTM.Size = new System.Drawing.Size(62, 13);
         this.lblTIPO_CodDTM.TabIndex = 0;
         this.lblTIPO_CodDTM.Text = "Depósito:";
         // 
         // DOOV_MBL
         // 
         this.DOOV_MBL.Location = new System.Drawing.Point(880, 30);
         this.DOOV_MBL.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.DOOV_MBL.Name = "DOOV_MBL";
         this.DOOV_MBL.Size = new System.Drawing.Size(194, 20);
         this.DOOV_MBL.TabIndex = 19;
         this.DOOV_MBL.Tag = "DOOV_MBLMSGERROR";
         // 
         // lblDOOV_Cntr
         // 
         this.lblDOOV_Cntr.AutoSize = true;
         this.lblDOOV_Cntr.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblDOOV_Cntr.Location = new System.Drawing.Point(10, 34);
         this.lblDOOV_Cntr.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblDOOV_Cntr.Name = "lblDOOV_Cntr";
         this.lblDOOV_Cntr.Size = new System.Drawing.Size(79, 13);
         this.lblDOOV_Cntr.TabIndex = 14;
         this.lblDOOV_Cntr.Text = "Contenedor:";
         // 
         // DOOV_Cntr
         // 
         this.tableLayoutPanel8.SetColumnSpan(this.DOOV_Cntr, 4);
         this.DOOV_Cntr.Location = new System.Drawing.Point(152, 30);
         this.DOOV_Cntr.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.DOOV_Cntr.Multiline = true;
         this.DOOV_Cntr.Name = "DOOV_Cntr";
         this.tableLayoutPanel8.SetRowSpan(this.DOOV_Cntr, 2);
         this.DOOV_Cntr.Size = new System.Drawing.Size(558, 47);
         this.DOOV_Cntr.TabIndex = 15;
         this.DOOV_Cntr.Tag = "DOOV_CntrMSGERROR";
         // 
         // lblDOOV_MBL
         // 
         this.lblDOOV_MBL.AutoSize = true;
         this.lblDOOV_MBL.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblDOOV_MBL.Location = new System.Drawing.Point(738, 34);
         this.lblDOOV_MBL.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblDOOV_MBL.Name = "lblDOOV_MBL";
         this.lblDOOV_MBL.Size = new System.Drawing.Size(68, 13);
         this.lblDOOV_MBL.TabIndex = 18;
         this.lblDOOV_MBL.Text = "BL Master:";
         // 
         // lblDOOV_HBL
         // 
         this.lblDOOV_HBL.AutoSize = true;
         this.lblDOOV_HBL.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblDOOV_HBL.Location = new System.Drawing.Point(738, 7);
         this.lblDOOV_HBL.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblDOOV_HBL.Name = "lblDOOV_HBL";
         this.lblDOOV_HBL.Size = new System.Drawing.Size(52, 13);
         this.lblDOOV_HBL.TabIndex = 16;
         this.lblDOOV_HBL.Text = "BL Hijo:";
         // 
         // DOOV_HBL
         // 
         this.DOOV_HBL.Location = new System.Drawing.Point(880, 3);
         this.DOOV_HBL.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.DOOV_HBL.Name = "DOOV_HBL";
         this.DOOV_HBL.Size = new System.Drawing.Size(194, 20);
         this.DOOV_HBL.TabIndex = 17;
         this.DOOV_HBL.Tag = "DOOV_HBLMSGERROR";
         // 
         // label38
         // 
         this.label38.AutoSize = true;
         this.label38.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label38.Location = new System.Drawing.Point(738, 61);
         this.label38.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label38.Name = "label38";
         this.label38.Size = new System.Drawing.Size(76, 13);
         this.label38.TabIndex = 20;
         this.label38.Text = "Nº Booking:";
         // 
         // textBox11
         // 
         this.textBox11.Location = new System.Drawing.Point(880, 57);
         this.textBox11.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.textBox11.Name = "textBox11";
         this.textBox11.Size = new System.Drawing.Size(194, 20);
         this.textBox11.TabIndex = 21;
         this.textBox11.Tag = "DOOV_MBLMSGERROR";
         // 
         // panelCaption12
         // 
         this.panelCaption12.AllowActive = false;
         this.panelCaption12.AntiAlias = false;
         this.panelCaption12.Caption = "Datos Documento";
         this.panelCaption12.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption12.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption12.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption12.Location = new System.Drawing.Point(0, 0);
         this.panelCaption12.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption12.Name = "panelCaption12";
         this.panelCaption12.Size = new System.Drawing.Size(1196, 27);
         this.panelCaption12.TabIndex = 9;
         // 
         // tabPageEX2
         // 
         this.tabPageEX2.Controls.Add(this.tableLayoutPanel2);
         this.tabPageEX2.Controls.Add(this.panelCaption8);
         this.tabPageEX2.Controls.Add(this.toolStrip4);
         this.tabPageEX2.Location = new System.Drawing.Point(4, 25);
         this.tabPageEX2.Name = "tabPageEX2";
         this.tabPageEX2.Size = new System.Drawing.Size(1196, 465);
         this.tabPageEX2.TabIndex = 1;
         this.tabPageEX2.Text = "Datos de Emisión";
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.ColumnCount = 6;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
         this.tableLayoutPanel2.Controls.Add(this.textBox3, 0, 3);
         this.tableLayoutPanel2.Controls.Add(this.label10, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.ENTC_CodNotify, 4, 2);
         this.tableLayoutPanel2.Controls.Add(this.ENTC_CodConsignee, 1, 2);
         this.tableLayoutPanel2.Controls.Add(this.ENTC_CodShipper, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.label11, 0, 2);
         this.tableLayoutPanel2.Controls.Add(this.textBox1, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.label13, 3, 2);
         this.tableLayoutPanel2.Controls.Add(this.textBox4, 3, 3);
         this.tableLayoutPanel2.Controls.Add(this.label37, 3, 0);
         this.tableLayoutPanel2.Controls.Add(this.entidad1, 4, 0);
         this.tableLayoutPanel2.Controls.Add(this.textBox10, 3, 1);
         this.tableLayoutPanel2.Controls.Add(this.lblDOOV_CodReferencia, 0, 4);
         this.tableLayoutPanel2.Controls.Add(this.DOOV_CodReferencia, 1, 4);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 64);
         this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 11;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.Size = new System.Drawing.Size(1196, 401);
         this.tableLayoutPanel2.TabIndex = 19;
         // 
         // textBox3
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.textBox3, 2);
         this.textBox3.Location = new System.Drawing.Point(2, 114);
         this.textBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.textBox3.Multiline = true;
         this.textBox3.Name = "textBox3";
         this.textBox3.Size = new System.Drawing.Size(546, 48);
         this.textBox3.TabIndex = 10;
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label10.Location = new System.Drawing.Point(10, 7);
         this.label10.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(62, 13);
         this.label10.TabIndex = 4;
         this.label10.Text = "SHIPPER:";
         // 
         // ENTC_CodNotify
         // 
         this.ENTC_CodNotify.ActivarAyudaAuto = false;
         this.ENTC_CodNotify.ContainerService = null;
         this.ENTC_CodNotify.EnabledAyudaButton = true;
         this.ENTC_CodNotify.Location = new System.Drawing.Point(717, 87);
         this.ENTC_CodNotify.LongitudAceptada = 0;
         this.ENTC_CodNotify.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ENTC_CodNotify.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_CodNotify.Name = "ENTC_CodNotify";
         this.ENTC_CodNotify.RellenaCeros = false;
         this.ENTC_CodNotify.Size = new System.Drawing.Size(396, 20);
         this.ENTC_CodNotify.TabIndex = 5;
         this.ENTC_CodNotify.Tag = "ENTC_CodNotifyMSGERROR";
         this.ENTC_CodNotify.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodNotify.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
         this.ENTC_CodNotify.Value = null;
         // 
         // ENTC_CodConsignee
         // 
         this.ENTC_CodConsignee.ActivarAyudaAuto = false;
         this.ENTC_CodConsignee.ContainerService = null;
         this.ENTC_CodConsignee.EnabledAyudaButton = true;
         this.ENTC_CodConsignee.Location = new System.Drawing.Point(152, 87);
         this.ENTC_CodConsignee.LongitudAceptada = 0;
         this.ENTC_CodConsignee.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ENTC_CodConsignee.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_CodConsignee.Name = "ENTC_CodConsignee";
         this.ENTC_CodConsignee.RellenaCeros = false;
         this.ENTC_CodConsignee.Size = new System.Drawing.Size(396, 20);
         this.ENTC_CodConsignee.TabIndex = 3;
         this.ENTC_CodConsignee.Tag = "ENTC_CodConsigneeMSGERROR";
         this.ENTC_CodConsignee.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodConsignee.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
         this.ENTC_CodConsignee.Value = null;
         // 
         // ENTC_CodShipper
         // 
         this.ENTC_CodShipper.ActivarAyudaAuto = false;
         this.ENTC_CodShipper.ContainerService = null;
         this.ENTC_CodShipper.EnabledAyudaButton = true;
         this.ENTC_CodShipper.Location = new System.Drawing.Point(152, 3);
         this.ENTC_CodShipper.LongitudAceptada = 0;
         this.ENTC_CodShipper.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ENTC_CodShipper.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_CodShipper.Name = "ENTC_CodShipper";
         this.ENTC_CodShipper.RellenaCeros = false;
         this.ENTC_CodShipper.Size = new System.Drawing.Size(396, 20);
         this.ENTC_CodShipper.TabIndex = 1;
         this.ENTC_CodShipper.Tag = "ENTC_CodShipperMSGERROR";
         this.ENTC_CodShipper.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodShipper.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Shipper;
         this.ENTC_CodShipper.Value = null;
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label11.Location = new System.Drawing.Point(10, 91);
         this.label11.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(82, 13);
         this.label11.TabIndex = 5;
         this.label11.Text = "CONSIGNEE:";
         // 
         // textBox1
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.textBox1, 2);
         this.textBox1.Location = new System.Drawing.Point(2, 33);
         this.textBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.textBox1.Multiline = true;
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(546, 48);
         this.textBox1.TabIndex = 8;
         // 
         // label13
         // 
         this.label13.AutoSize = true;
         this.label13.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label13.Location = new System.Drawing.Point(575, 91);
         this.label13.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(53, 13);
         this.label13.TabIndex = 7;
         this.label13.Text = "NOTIFY:";
         // 
         // textBox4
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.textBox4, 2);
         this.textBox4.Location = new System.Drawing.Point(567, 114);
         this.textBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.textBox4.Multiline = true;
         this.textBox4.Name = "textBox4";
         this.textBox4.Size = new System.Drawing.Size(546, 48);
         this.textBox4.TabIndex = 11;
         // 
         // label37
         // 
         this.label37.AutoSize = true;
         this.label37.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label37.Location = new System.Drawing.Point(575, 7);
         this.label37.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label37.Name = "label37";
         this.label37.Size = new System.Drawing.Size(58, 13);
         this.label37.TabIndex = 18;
         this.label37.Tag = "MSGERROR";
         this.label37.Text = "AGENTE:";
         // 
         // entidad1
         // 
         this.entidad1.ActivarAyudaAuto = false;
         this.entidad1.ContainerService = null;
         this.entidad1.EnabledAyudaButton = true;
         this.entidad1.Location = new System.Drawing.Point(717, 3);
         this.entidad1.LongitudAceptada = 0;
         this.entidad1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.entidad1.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.entidad1.Name = "entidad1";
         this.entidad1.RellenaCeros = false;
         this.entidad1.Size = new System.Drawing.Size(396, 20);
         this.entidad1.TabIndex = 19;
         this.entidad1.Tag = "ENTC_CodAgenteMSGERROR";
         this.entidad1.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.entidad1.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente;
         this.entidad1.Value = null;
         // 
         // textBox10
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.textBox10, 2);
         this.textBox10.Location = new System.Drawing.Point(567, 33);
         this.textBox10.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.textBox10.Multiline = true;
         this.textBox10.Name = "textBox10";
         this.textBox10.Size = new System.Drawing.Size(546, 48);
         this.textBox10.TabIndex = 20;
         // 
         // lblDOOV_CodReferencia
         // 
         this.lblDOOV_CodReferencia.AutoSize = true;
         this.lblDOOV_CodReferencia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblDOOV_CodReferencia.Location = new System.Drawing.Point(10, 172);
         this.lblDOOV_CodReferencia.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblDOOV_CodReferencia.Name = "lblDOOV_CodReferencia";
         this.lblDOOV_CodReferencia.Size = new System.Drawing.Size(73, 13);
         this.lblDOOV_CodReferencia.TabIndex = 6;
         this.lblDOOV_CodReferencia.Text = "Referencia:";
         // 
         // DOOV_CodReferencia
         // 
         this.DOOV_CodReferencia.Location = new System.Drawing.Point(152, 168);
         this.DOOV_CodReferencia.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.DOOV_CodReferencia.Name = "DOOV_CodReferencia";
         this.DOOV_CodReferencia.Size = new System.Drawing.Size(396, 20);
         this.DOOV_CodReferencia.TabIndex = 7;
         // 
         // panelCaption8
         // 
         this.panelCaption8.AllowActive = false;
         this.panelCaption8.AntiAlias = false;
         this.panelCaption8.Caption = "Datos Adicionales";
         this.panelCaption8.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption8.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption8.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption8.Location = new System.Drawing.Point(0, 38);
         this.panelCaption8.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption8.Name = "panelCaption8";
         this.panelCaption8.Size = new System.Drawing.Size(1196, 26);
         this.panelCaption8.TabIndex = 5;
         // 
         // toolStrip4
         // 
         this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton14});
         this.toolStrip4.Location = new System.Drawing.Point(0, 0);
         this.toolStrip4.Name = "toolStrip4";
         this.toolStrip4.Size = new System.Drawing.Size(1196, 38);
         this.toolStrip4.TabIndex = 18;
         this.toolStrip4.Text = "toolStrip4";
         // 
         // toolStripButton14
         // 
         this.toolStripButton14.Image = global::Delfin.Comercial.Properties.Resources.printer2;
         this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton14.Name = "toolStripButton14";
         this.toolStripButton14.Size = new System.Drawing.Size(57, 35);
         this.toolStripButton14.Text = "Imprimir";
         this.toolStripButton14.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.toolStripButton14.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         // 
         // tabPageEX3
         // 
         this.tabPageEX3.Controls.Add(this.grdMatrizDetalle);
         this.tabPageEX3.Controls.Add(this.toolStrip2);
         this.tabPageEX3.Controls.Add(this.panelCaption17);
         this.tabPageEX3.Location = new System.Drawing.Point(4, 25);
         this.tabPageEX3.Name = "tabPageEX3";
         this.tabPageEX3.Size = new System.Drawing.Size(1196, 465);
         this.tabPageEX3.TabIndex = 2;
         this.tabPageEX3.Text = "Detalle de Contenedores";
         // 
         // grdMatrizDetalle
         // 
         this.grdMatrizDetalle.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdMatrizDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdMatrizDetalle.Location = new System.Drawing.Point(0, 65);
         this.grdMatrizDetalle.Margin = new System.Windows.Forms.Padding(2, 3, 18, 3);
         this.grdMatrizDetalle.Name = "grdMatrizDetalle";
         // 
         // 
         // 
         this.grdMatrizDetalle.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 65, 240, 150);
         this.grdMatrizDetalle.RootElement.MinSize = new System.Drawing.Size(0, 0);
         this.grdMatrizDetalle.Size = new System.Drawing.Size(1196, 400);
         this.grdMatrizDetalle.TabIndex = 18;
         this.grdMatrizDetalle.TabStop = false;
         // 
         // toolStrip2
         // 
         this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6});
         this.toolStrip2.Location = new System.Drawing.Point(0, 27);
         this.toolStrip2.Name = "toolStrip2";
         this.toolStrip2.Size = new System.Drawing.Size(1196, 38);
         this.toolStrip2.TabIndex = 17;
         this.toolStrip2.Text = "toolStrip2";
         // 
         // toolStripButton4
         // 
         this.toolStripButton4.Image = global::Delfin.Comercial.Properties.Resources.arrow_down_blue;
         this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton4.Name = "toolStripButton4";
         this.toolStripButton4.Size = new System.Drawing.Size(54, 35);
         this.toolStripButton4.Text = "Exportar";
         this.toolStripButton4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         // 
         // toolStripButton5
         // 
         this.toolStripButton5.Image = global::Delfin.Comercial.Properties.Resources.arrow_up_green;
         this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton5.Name = "toolStripButton5";
         this.toolStripButton5.Size = new System.Drawing.Size(57, 35);
         this.toolStripButton5.Text = "Importar";
         this.toolStripButton5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.toolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         // 
         // toolStripButton6
         // 
         this.toolStripButton6.Image = global::Delfin.Comercial.Properties.Resources.printer2;
         this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton6.Name = "toolStripButton6";
         this.toolStripButton6.Size = new System.Drawing.Size(57, 35);
         this.toolStripButton6.Text = "Imprimir";
         this.toolStripButton6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.toolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         // 
         // panelCaption17
         // 
         this.panelCaption17.AllowActive = false;
         this.panelCaption17.AntiAlias = false;
         this.panelCaption17.Caption = "Detalles de Contenedores";
         this.panelCaption17.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption17.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption17.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption17.Location = new System.Drawing.Point(0, 0);
         this.panelCaption17.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption17.Name = "panelCaption17";
         this.panelCaption17.Size = new System.Drawing.Size(1196, 27);
         this.panelCaption17.TabIndex = 16;
         // 
         // pageArchivos
         // 
         this.pageArchivos.Controls.Add(this.grdItemsArchivos);
         this.pageArchivos.Controls.Add(this.panel4);
         this.pageArchivos.Controls.Add(this.tableArchivo);
         this.pageArchivos.Controls.Add(this.panelCaption11);
         this.pageArchivos.Location = new System.Drawing.Point(4, 25);
         this.pageArchivos.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.pageArchivos.Name = "pageArchivos";
         this.pageArchivos.Size = new System.Drawing.Size(1204, 494);
         this.pageArchivos.TabIndex = 5;
         this.pageArchivos.Text = "Archivos";
         // 
         // grdItemsArchivos
         // 
         this.grdItemsArchivos.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdItemsArchivos.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItemsArchivos.Location = new System.Drawing.Point(0, 81);
         this.grdItemsArchivos.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.grdItemsArchivos.Name = "grdItemsArchivos";
         // 
         // 
         // 
         this.grdItemsArchivos.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 81, 240, 150);
         this.grdItemsArchivos.RootElement.MinSize = new System.Drawing.Size(0, 0);
         this.grdItemsArchivos.Size = new System.Drawing.Size(1204, 413);
         this.grdItemsArchivos.TabIndex = 8;
         this.grdItemsArchivos.TabStop = false;
         // 
         // panel4
         // 
         this.panel4.Controls.Add(this.btnDownloadFile);
         this.panel4.Controls.Add(this.btnUploadFile);
         this.panel4.Controls.Add(this.panelCaption13);
         this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel4.Location = new System.Drawing.Point(0, 54);
         this.panel4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panel4.Name = "panel4";
         this.panel4.Size = new System.Drawing.Size(1204, 27);
         this.panel4.TabIndex = 13;
         // 
         // btnDownloadFile
         // 
         this.btnDownloadFile.BackColor = System.Drawing.Color.Transparent;
         this.btnDownloadFile.Image = global::Delfin.Comercial.Properties.Resources.arrow_down_blue;
         this.btnDownloadFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnDownloadFile.Location = new System.Drawing.Point(184, 1);
         this.btnDownloadFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnDownloadFile.Name = "btnDownloadFile";
         this.btnDownloadFile.Size = new System.Drawing.Size(25, 25);
         this.btnDownloadFile.TabIndex = 10;
         this.btnDownloadFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnDownloadFile, "Descargar Archivo");
         this.btnDownloadFile.UseVisualStyleBackColor = false;
         this.btnDownloadFile.Click += new System.EventHandler(this.btnDownloadFile_Click);
         // 
         // btnUploadFile
         // 
         this.btnUploadFile.BackColor = System.Drawing.Color.Transparent;
         this.btnUploadFile.Image = global::Delfin.Comercial.Properties.Resources.arrow_up_green;
         this.btnUploadFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnUploadFile.Location = new System.Drawing.Point(152, 1);
         this.btnUploadFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnUploadFile.Name = "btnUploadFile";
         this.btnUploadFile.Size = new System.Drawing.Size(25, 25);
         this.btnUploadFile.TabIndex = 9;
         this.btnUploadFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnUploadFile, "Subir Archivo");
         this.btnUploadFile.UseVisualStyleBackColor = false;
         this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
         // 
         // panelCaption13
         // 
         this.panelCaption13.AllowActive = false;
         this.panelCaption13.AntiAlias = false;
         this.panelCaption13.Caption = "Listado Archivos";
         this.panelCaption13.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption13.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption13.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption13.Location = new System.Drawing.Point(0, 0);
         this.panelCaption13.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption13.Name = "panelCaption13";
         this.panelCaption13.Size = new System.Drawing.Size(1204, 27);
         this.panelCaption13.TabIndex = 13;
         // 
         // tableArchivo
         // 
         this.tableArchivo.AutoSize = true;
         this.tableArchivo.ColumnCount = 10;
         this.tableArchivo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableArchivo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableArchivo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableArchivo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableArchivo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableArchivo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableArchivo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableArchivo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableArchivo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableArchivo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableArchivo.Controls.Add(this.lblOVAR_Archivo, 0, 0);
         this.tableArchivo.Controls.Add(this.OVAR_Archivo, 1, 0);
         this.tableArchivo.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableArchivo.Location = new System.Drawing.Point(0, 27);
         this.tableArchivo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.tableArchivo.Name = "tableArchivo";
         this.tableArchivo.RowCount = 1;
         this.tableArchivo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableArchivo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableArchivo.Size = new System.Drawing.Size(1204, 27);
         this.tableArchivo.TabIndex = 11;
         // 
         // lblOVAR_Archivo
         // 
         this.lblOVAR_Archivo.AutoSize = true;
         this.lblOVAR_Archivo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblOVAR_Archivo.Location = new System.Drawing.Point(10, 7);
         this.lblOVAR_Archivo.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblOVAR_Archivo.Name = "lblOVAR_Archivo";
         this.lblOVAR_Archivo.Size = new System.Drawing.Size(55, 13);
         this.lblOVAR_Archivo.TabIndex = 3;
         this.lblOVAR_Archivo.Text = "Archivo:";
         // 
         // OVAR_Archivo
         // 
         this.OVAR_Archivo.Archivo = null;
         this.tableArchivo.SetColumnSpan(this.OVAR_Archivo, 4);
         this.OVAR_Archivo.DefaultFile = "*";
         this.OVAR_Archivo.EnableButton = true;
         this.OVAR_Archivo.FileData = null;
         this.OVAR_Archivo.FileDefined = false;
         this.OVAR_Archivo.FileName = null;
         this.OVAR_Archivo.Filter = "Todos los Archivos (*.*)|*.*";
         this.OVAR_Archivo.Instance = Infrastructure.WinForms.Controls.TextBoxOpenFile.InstanceEntity.Unchanged;
         this.OVAR_Archivo.Location = new System.Drawing.Point(152, 3);
         this.OVAR_Archivo.LongitudAceptada = 0;
         this.OVAR_Archivo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.OVAR_Archivo.Name = "OVAR_Archivo";
         this.OVAR_Archivo.NSFileTamañoMax = 0D;
         this.OVAR_Archivo.NSValidateFileTamaño = false;
         this.OVAR_Archivo.Size = new System.Drawing.Size(558, 20);
         this.OVAR_Archivo.TabIndex = 4;
         // 
         // panelCaption11
         // 
         this.panelCaption11.AllowActive = false;
         this.panelCaption11.AntiAlias = false;
         this.panelCaption11.Caption = "Datos Archivo";
         this.panelCaption11.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption11.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption11.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption11.Location = new System.Drawing.Point(0, 0);
         this.panelCaption11.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption11.Name = "panelCaption11";
         this.panelCaption11.Size = new System.Drawing.Size(1204, 27);
         this.panelCaption11.TabIndex = 7;
         // 
         // pageEventosTareas
         // 
         this.pageEventosTareas.Controls.Add(this.splitContainer1);
         this.pageEventosTareas.Location = new System.Drawing.Point(4, 25);
         this.pageEventosTareas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.pageEventosTareas.Name = "pageEventosTareas";
         this.pageEventosTareas.Size = new System.Drawing.Size(1204, 494);
         this.pageEventosTareas.TabIndex = 6;
         this.pageEventosTareas.Text = "Novedades/Eventos/Tareas";
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.grdItemsNovedades);
         this.splitContainer1.Panel1.Controls.Add(this.panel5);
         this.splitContainer1.Panel1.Controls.Add(this.tableNovedad);
         this.splitContainer1.Panel1.Controls.Add(this.panelCaption15);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.grdItemsEventosTareas);
         this.splitContainer1.Panel2.Controls.Add(this.panel9);
         this.splitContainer1.Panel2.Controls.Add(this.tableEventoTarea);
         this.splitContainer1.Panel2.Controls.Add(this.panelEventoTarea);
         this.splitContainer1.Size = new System.Drawing.Size(1204, 494);
         this.splitContainer1.SplitterDistance = 194;
         this.splitContainer1.TabIndex = 35;
         // 
         // grdItemsNovedades
         // 
         this.grdItemsNovedades.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdItemsNovedades.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItemsNovedades.Location = new System.Drawing.Point(0, 108);
         this.grdItemsNovedades.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.grdItemsNovedades.Name = "grdItemsNovedades";
         // 
         // 
         // 
         this.grdItemsNovedades.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 108, 240, 150);
         this.grdItemsNovedades.RootElement.MinSize = new System.Drawing.Size(0, 0);
         this.grdItemsNovedades.Size = new System.Drawing.Size(1204, 86);
         this.grdItemsNovedades.TabIndex = 29;
         this.grdItemsNovedades.TabStop = false;
         // 
         // panel5
         // 
         this.panel5.Controls.Add(this.btnNuevoNovedad);
         this.panel5.Controls.Add(this.btnEnviarNovedad);
         this.panel5.Controls.Add(this.panelCaption14);
         this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel5.Location = new System.Drawing.Point(0, 81);
         this.panel5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panel5.Name = "panel5";
         this.panel5.Size = new System.Drawing.Size(1204, 27);
         this.panel5.TabIndex = 28;
         // 
         // btnNuevoNovedad
         // 
         this.btnNuevoNovedad.BackColor = System.Drawing.Color.Transparent;
         this.btnNuevoNovedad.Image = global::Delfin.Comercial.Properties.Resources.disk_blue_ok;
         this.btnNuevoNovedad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnNuevoNovedad.Location = new System.Drawing.Point(152, 1);
         this.btnNuevoNovedad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnNuevoNovedad.Name = "btnNuevoNovedad";
         this.btnNuevoNovedad.Size = new System.Drawing.Size(25, 25);
         this.btnNuevoNovedad.TabIndex = 26;
         this.btnNuevoNovedad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnNuevoNovedad, "Guardar Novedad");
         this.btnNuevoNovedad.UseVisualStyleBackColor = false;
         // 
         // btnEnviarNovedad
         // 
         this.btnEnviarNovedad.BackColor = System.Drawing.Color.Transparent;
         this.btnEnviarNovedad.Image = global::Delfin.Comercial.Properties.Resources.mail_forward;
         this.btnEnviarNovedad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnEnviarNovedad.Location = new System.Drawing.Point(184, 1);
         this.btnEnviarNovedad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnEnviarNovedad.Name = "btnEnviarNovedad";
         this.btnEnviarNovedad.Size = new System.Drawing.Size(25, 25);
         this.btnEnviarNovedad.TabIndex = 25;
         this.btnEnviarNovedad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnEnviarNovedad, "Enviar Novedades Pendientes");
         this.btnEnviarNovedad.UseVisualStyleBackColor = false;
         // 
         // panelCaption14
         // 
         this.panelCaption14.AllowActive = false;
         this.panelCaption14.AntiAlias = false;
         this.panelCaption14.Caption = "Listado Novedades";
         this.panelCaption14.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption14.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption14.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption14.Location = new System.Drawing.Point(0, 0);
         this.panelCaption14.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption14.Name = "panelCaption14";
         this.panelCaption14.Size = new System.Drawing.Size(1204, 27);
         this.panelCaption14.TabIndex = 21;
         // 
         // tableNovedad
         // 
         this.tableNovedad.AutoSize = true;
         this.tableNovedad.ColumnCount = 10;
         this.tableNovedad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableNovedad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableNovedad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableNovedad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableNovedad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableNovedad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableNovedad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableNovedad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableNovedad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableNovedad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableNovedad.Controls.Add(this.lblOVNO_Descrip, 0, 0);
         this.tableNovedad.Controls.Add(this.label3, 6, 0);
         this.tableNovedad.Controls.Add(this.CONS_CodNot, 7, 0);
         this.tableNovedad.Controls.Add(this.OVNO_Descrip, 1, 0);
         this.tableNovedad.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableNovedad.Location = new System.Drawing.Point(0, 27);
         this.tableNovedad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.tableNovedad.Name = "tableNovedad";
         this.tableNovedad.RowCount = 2;
         this.tableNovedad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableNovedad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableNovedad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableNovedad.Size = new System.Drawing.Size(1204, 54);
         this.tableNovedad.TabIndex = 20;
         // 
         // lblOVNO_Descrip
         // 
         this.lblOVNO_Descrip.AutoSize = true;
         this.lblOVNO_Descrip.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblOVNO_Descrip.Location = new System.Drawing.Point(10, 7);
         this.lblOVNO_Descrip.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblOVNO_Descrip.Name = "lblOVNO_Descrip";
         this.lblOVNO_Descrip.Size = new System.Drawing.Size(78, 13);
         this.lblOVNO_Descrip.TabIndex = 5;
         this.lblOVNO_Descrip.Text = "Descripción:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(738, 7);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(105, 13);
         this.label3.TabIndex = 7;
         this.label3.Text = "Tipo Notificación:";
         // 
         // CONS_CodNot
         // 
         this.CONS_CodNot.ConstantesSelectedItem = null;
         this.CONS_CodNot.ConstantesSelectedValue = null;
         this.CONS_CodNot.ConstantesTitulo = null;
         this.CONS_CodNot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CONS_CodNot.FormattingEnabled = true;
         this.CONS_CodNot.Location = new System.Drawing.Point(880, 3);
         this.CONS_CodNot.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CONS_CodNot.Name = "CONS_CodNot";
         this.CONS_CodNot.Size = new System.Drawing.Size(194, 21);
         this.CONS_CodNot.TabIndex = 8;
         // 
         // OVNO_Descrip
         // 
         this.tableNovedad.SetColumnSpan(this.OVNO_Descrip, 4);
         this.OVNO_Descrip.Location = new System.Drawing.Point(152, 3);
         this.OVNO_Descrip.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.OVNO_Descrip.Multiline = true;
         this.OVNO_Descrip.Name = "OVNO_Descrip";
         this.tableNovedad.SetRowSpan(this.OVNO_Descrip, 2);
         this.OVNO_Descrip.Size = new System.Drawing.Size(558, 46);
         this.OVNO_Descrip.TabIndex = 6;
         // 
         // panelCaption15
         // 
         this.panelCaption15.AllowActive = false;
         this.panelCaption15.AntiAlias = false;
         this.panelCaption15.Caption = "Datos Novedad";
         this.panelCaption15.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption15.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption15.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption15.Location = new System.Drawing.Point(0, 0);
         this.panelCaption15.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption15.Name = "panelCaption15";
         this.panelCaption15.Size = new System.Drawing.Size(1204, 27);
         this.panelCaption15.TabIndex = 19;
         // 
         // grdItemsEventosTareas
         // 
         this.grdItemsEventosTareas.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdItemsEventosTareas.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItemsEventosTareas.Location = new System.Drawing.Point(0, 192);
         this.grdItemsEventosTareas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.grdItemsEventosTareas.Name = "grdItemsEventosTareas";
         // 
         // 
         // 
         this.grdItemsEventosTareas.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 192, 240, 150);
         this.grdItemsEventosTareas.RootElement.MinSize = new System.Drawing.Size(0, 0);
         this.grdItemsEventosTareas.Size = new System.Drawing.Size(1204, 104);
         this.grdItemsEventosTareas.TabIndex = 38;
         this.grdItemsEventosTareas.TabStop = false;
         // 
         // panel9
         // 
         this.panel9.Controls.Add(this.btnNuevoEventoTarea);
         this.panel9.Controls.Add(this.btnEditarEventoTarea);
         this.panel9.Controls.Add(this.btnDeshacerEventoTarea);
         this.panel9.Controls.Add(this.btnEliminarEventoTarea);
         this.panel9.Controls.Add(this.btnGuardarEventoTarea);
         this.panel9.Controls.Add(this.panelEventosTareas);
         this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel9.Location = new System.Drawing.Point(0, 162);
         this.panel9.Name = "panel9";
         this.panel9.Size = new System.Drawing.Size(1204, 30);
         this.panel9.TabIndex = 37;
         // 
         // btnNuevoEventoTarea
         // 
         this.btnNuevoEventoTarea.BackColor = System.Drawing.Color.Transparent;
         this.btnNuevoEventoTarea.Image = global::Delfin.Comercial.Properties.Resources.add16x16;
         this.btnNuevoEventoTarea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnNuevoEventoTarea.Location = new System.Drawing.Point(126, 2);
         this.btnNuevoEventoTarea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnNuevoEventoTarea.Name = "btnNuevoEventoTarea";
         this.btnNuevoEventoTarea.Size = new System.Drawing.Size(25, 25);
         this.btnNuevoEventoTarea.TabIndex = 31;
         this.btnNuevoEventoTarea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnNuevoEventoTarea, "Nuevo Evento/Tarea");
         this.btnNuevoEventoTarea.UseVisualStyleBackColor = false;
         // 
         // btnEditarEventoTarea
         // 
         this.btnEditarEventoTarea.BackColor = System.Drawing.Color.Transparent;
         this.btnEditarEventoTarea.Image = global::Delfin.Comercial.Properties.Resources.editar16x16;
         this.btnEditarEventoTarea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnEditarEventoTarea.Location = new System.Drawing.Point(158, 2);
         this.btnEditarEventoTarea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnEditarEventoTarea.Name = "btnEditarEventoTarea";
         this.btnEditarEventoTarea.Size = new System.Drawing.Size(25, 25);
         this.btnEditarEventoTarea.TabIndex = 30;
         this.btnEditarEventoTarea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnEditarEventoTarea, "Editar Evento/Tarea");
         this.btnEditarEventoTarea.UseVisualStyleBackColor = false;
         // 
         // btnDeshacerEventoTarea
         // 
         this.btnDeshacerEventoTarea.BackColor = System.Drawing.Color.Transparent;
         this.btnDeshacerEventoTarea.Image = global::Delfin.Comercial.Properties.Resources.undo1;
         this.btnDeshacerEventoTarea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnDeshacerEventoTarea.Location = new System.Drawing.Point(251, 2);
         this.btnDeshacerEventoTarea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnDeshacerEventoTarea.Name = "btnDeshacerEventoTarea";
         this.btnDeshacerEventoTarea.Size = new System.Drawing.Size(25, 25);
         this.btnDeshacerEventoTarea.TabIndex = 34;
         this.btnDeshacerEventoTarea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnDeshacerEventoTarea, "Deshacer Edición Evento/Tarea");
         this.btnDeshacerEventoTarea.UseVisualStyleBackColor = false;
         // 
         // btnEliminarEventoTarea
         // 
         this.btnEliminarEventoTarea.BackColor = System.Drawing.Color.Transparent;
         this.btnEliminarEventoTarea.Image = global::Delfin.Comercial.Properties.Resources.delete1;
         this.btnEliminarEventoTarea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnEliminarEventoTarea.Location = new System.Drawing.Point(189, 2);
         this.btnEliminarEventoTarea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnEliminarEventoTarea.Name = "btnEliminarEventoTarea";
         this.btnEliminarEventoTarea.Size = new System.Drawing.Size(25, 25);
         this.btnEliminarEventoTarea.TabIndex = 32;
         this.btnEliminarEventoTarea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnEliminarEventoTarea, "Eliminar Evento/Tarea");
         this.btnEliminarEventoTarea.UseVisualStyleBackColor = false;
         // 
         // btnGuardarEventoTarea
         // 
         this.btnGuardarEventoTarea.BackColor = System.Drawing.Color.Transparent;
         this.btnGuardarEventoTarea.Image = global::Delfin.Comercial.Properties.Resources.disk_blue_ok;
         this.btnGuardarEventoTarea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnGuardarEventoTarea.Location = new System.Drawing.Point(220, 2);
         this.btnGuardarEventoTarea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnGuardarEventoTarea.Name = "btnGuardarEventoTarea";
         this.btnGuardarEventoTarea.Size = new System.Drawing.Size(25, 25);
         this.btnGuardarEventoTarea.TabIndex = 33;
         this.btnGuardarEventoTarea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip1.SetToolTip(this.btnGuardarEventoTarea, "Confirmar Edición Evento/Tarea");
         this.btnGuardarEventoTarea.UseVisualStyleBackColor = false;
         // 
         // panelEventosTareas
         // 
         this.panelEventosTareas.AllowActive = false;
         this.panelEventosTareas.AntiAlias = false;
         this.panelEventosTareas.Caption = "Eventos/Tareas";
         this.panelEventosTareas.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelEventosTareas.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelEventosTareas.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelEventosTareas.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelEventosTareas.Location = new System.Drawing.Point(0, 0);
         this.panelEventosTareas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelEventosTareas.Name = "panelEventosTareas";
         this.panelEventosTareas.Size = new System.Drawing.Size(1204, 30);
         this.panelEventosTareas.TabIndex = 18;
         // 
         // tableEventoTarea
         // 
         this.tableEventoTarea.AutoSize = true;
         this.tableEventoTarea.ColumnCount = 10;
         this.tableEventoTarea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableEventoTarea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableEventoTarea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableEventoTarea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableEventoTarea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableEventoTarea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableEventoTarea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableEventoTarea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableEventoTarea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableEventoTarea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableEventoTarea.Controls.Add(this.lblTIPO_CodEVE, 0, 0);
         this.tableEventoTarea.Controls.Add(this.TIPO_CodEVE, 1, 0);
         this.tableEventoTarea.Controls.Add(this.panel6, 4, 1);
         this.tableEventoTarea.Controls.Add(this.EVEN_Observaciones, 1, 2);
         this.tableEventoTarea.Controls.Add(this.lblEVEN_Observaciones, 0, 2);
         this.tableEventoTarea.Controls.Add(this.lblEVEN_Fecha, 0, 1);
         this.tableEventoTarea.Controls.Add(this.EVEN_Fecha, 1, 1);
         this.tableEventoTarea.Controls.Add(this.lblEVEN_Cumplida, 3, 1);
         this.tableEventoTarea.Controls.Add(this.CONS_CodMOD, 7, 0);
         this.tableEventoTarea.Controls.Add(this.lblCONS_CodMOD, 6, 0);
         this.tableEventoTarea.Controls.Add(this.lblEVEN_Usuario, 6, 1);
         this.tableEventoTarea.Controls.Add(this.EVEN_Usuario, 7, 1);
         this.tableEventoTarea.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableEventoTarea.Location = new System.Drawing.Point(0, 27);
         this.tableEventoTarea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.tableEventoTarea.Name = "tableEventoTarea";
         this.tableEventoTarea.RowCount = 5;
         this.tableEventoTarea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableEventoTarea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableEventoTarea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableEventoTarea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableEventoTarea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableEventoTarea.Size = new System.Drawing.Size(1204, 135);
         this.tableEventoTarea.TabIndex = 17;
         // 
         // lblTIPO_CodEVE
         // 
         this.lblTIPO_CodEVE.AutoSize = true;
         this.lblTIPO_CodEVE.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPO_CodEVE.Location = new System.Drawing.Point(10, 7);
         this.lblTIPO_CodEVE.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblTIPO_CodEVE.Name = "lblTIPO_CodEVE";
         this.lblTIPO_CodEVE.Size = new System.Drawing.Size(116, 13);
         this.lblTIPO_CodEVE.TabIndex = 3;
         this.lblTIPO_CodEVE.Text = "Tipo Evento/Tarea:";
         // 
         // TIPO_CodEVE
         // 
         this.tableEventoTarea.SetColumnSpan(this.TIPO_CodEVE, 4);
         this.TIPO_CodEVE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.TIPO_CodEVE.FormattingEnabled = true;
         this.TIPO_CodEVE.Location = new System.Drawing.Point(152, 3);
         this.TIPO_CodEVE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.TIPO_CodEVE.Name = "TIPO_CodEVE";
         this.TIPO_CodEVE.Size = new System.Drawing.Size(558, 21);
         this.TIPO_CodEVE.TabIndex = 4;
         this.TIPO_CodEVE.TiposSelectedItem = null;
         this.TIPO_CodEVE.TiposSelectedValue = null;
         this.TIPO_CodEVE.TiposTitulo = null;
         // 
         // panel6
         // 
         this.panel6.Controls.Add(this.EVEN_Cumplida);
         this.panel6.Controls.Add(this.EVEN_Pendiente);
         this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel6.Location = new System.Drawing.Point(514, 27);
         this.panel6.Margin = new System.Windows.Forms.Padding(0);
         this.panel6.Name = "panel6";
         this.panel6.Size = new System.Drawing.Size(200, 27);
         this.panel6.TabIndex = 8;
         // 
         // EVEN_Cumplida
         // 
         this.EVEN_Cumplida.AutoSize = true;
         this.EVEN_Cumplida.Dock = System.Windows.Forms.DockStyle.Left;
         this.EVEN_Cumplida.Location = new System.Drawing.Point(73, 0);
         this.EVEN_Cumplida.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.EVEN_Cumplida.Name = "EVEN_Cumplida";
         this.EVEN_Cumplida.Size = new System.Drawing.Size(68, 27);
         this.EVEN_Cumplida.TabIndex = 1;
         this.EVEN_Cumplida.TabStop = true;
         this.EVEN_Cumplida.Text = "Cumplida";
         this.EVEN_Cumplida.UseVisualStyleBackColor = true;
         // 
         // EVEN_Pendiente
         // 
         this.EVEN_Pendiente.AutoSize = true;
         this.EVEN_Pendiente.Checked = true;
         this.EVEN_Pendiente.Dock = System.Windows.Forms.DockStyle.Left;
         this.EVEN_Pendiente.Location = new System.Drawing.Point(0, 0);
         this.EVEN_Pendiente.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.EVEN_Pendiente.Name = "EVEN_Pendiente";
         this.EVEN_Pendiente.Size = new System.Drawing.Size(73, 27);
         this.EVEN_Pendiente.TabIndex = 0;
         this.EVEN_Pendiente.TabStop = true;
         this.EVEN_Pendiente.Text = "Pendiente";
         this.EVEN_Pendiente.UseVisualStyleBackColor = true;
         // 
         // EVEN_Observaciones
         // 
         this.tableEventoTarea.SetColumnSpan(this.EVEN_Observaciones, 7);
         this.EVEN_Observaciones.Location = new System.Drawing.Point(152, 57);
         this.EVEN_Observaciones.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.EVEN_Observaciones.Multiline = true;
         this.EVEN_Observaciones.Name = "EVEN_Observaciones";
         this.tableEventoTarea.SetRowSpan(this.EVEN_Observaciones, 3);
         this.EVEN_Observaciones.Size = new System.Drawing.Size(924, 75);
         this.EVEN_Observaciones.TabIndex = 17;
         this.EVEN_Observaciones.Tag = "CCOT_ObservacionesMSGERROR";
         // 
         // lblEVEN_Observaciones
         // 
         this.lblEVEN_Observaciones.AutoSize = true;
         this.lblEVEN_Observaciones.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblEVEN_Observaciones.Location = new System.Drawing.Point(10, 61);
         this.lblEVEN_Observaciones.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblEVEN_Observaciones.Name = "lblEVEN_Observaciones";
         this.lblEVEN_Observaciones.Size = new System.Drawing.Size(96, 13);
         this.lblEVEN_Observaciones.TabIndex = 18;
         this.lblEVEN_Observaciones.Text = "Observaciones:";
         // 
         // lblEVEN_Fecha
         // 
         this.lblEVEN_Fecha.AutoSize = true;
         this.lblEVEN_Fecha.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblEVEN_Fecha.Location = new System.Drawing.Point(10, 34);
         this.lblEVEN_Fecha.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblEVEN_Fecha.Name = "lblEVEN_Fecha";
         this.lblEVEN_Fecha.Size = new System.Drawing.Size(87, 13);
         this.lblEVEN_Fecha.TabIndex = 19;
         this.lblEVEN_Fecha.Text = "Fecha y Hora:";
         // 
         // EVEN_Fecha
         // 
         this.EVEN_Fecha.Location = new System.Drawing.Point(152, 30);
         this.EVEN_Fecha.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.EVEN_Fecha.MinimumSize = new System.Drawing.Size(100, 22);
         this.EVEN_Fecha.Name = "EVEN_Fecha";
         this.EVEN_Fecha.NSActiveMouse = false;
         this.EVEN_Fecha.NSActiveMsgFecha = false;
         this.EVEN_Fecha.NSChangeDate = true;
         this.EVEN_Fecha.NSDigitos = 4;
         this.EVEN_Fecha.NSFecha = null;
         this.EVEN_Fecha.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.FechaHora;
         this.EVEN_Fecha.NSSetDateNow = true;
         this.EVEN_Fecha.Size = new System.Drawing.Size(194, 22);
         this.EVEN_Fecha.TabIndex = 21;
         // 
         // lblEVEN_Cumplida
         // 
         this.lblEVEN_Cumplida.AutoSize = true;
         this.lblEVEN_Cumplida.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblEVEN_Cumplida.Location = new System.Drawing.Point(374, 34);
         this.lblEVEN_Cumplida.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblEVEN_Cumplida.Name = "lblEVEN_Cumplida";
         this.lblEVEN_Cumplida.Size = new System.Drawing.Size(50, 13);
         this.lblEVEN_Cumplida.TabIndex = 7;
         this.lblEVEN_Cumplida.Text = "Estado:";
         // 
         // CONS_CodMOD
         // 
         this.CONS_CodMOD.ConstantesSelectedItem = null;
         this.CONS_CodMOD.ConstantesSelectedValue = null;
         this.CONS_CodMOD.ConstantesTitulo = null;
         this.CONS_CodMOD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CONS_CodMOD.FormattingEnabled = true;
         this.CONS_CodMOD.Location = new System.Drawing.Point(880, 3);
         this.CONS_CodMOD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.CONS_CodMOD.Name = "CONS_CodMOD";
         this.CONS_CodMOD.Size = new System.Drawing.Size(194, 21);
         this.CONS_CodMOD.TabIndex = 6;
         // 
         // lblCONS_CodMOD
         // 
         this.lblCONS_CodMOD.AutoSize = true;
         this.lblCONS_CodMOD.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONS_CodMOD.Location = new System.Drawing.Point(738, 7);
         this.lblCONS_CodMOD.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCONS_CodMOD.Name = "lblCONS_CodMOD";
         this.lblCONS_CodMOD.Size = new System.Drawing.Size(52, 13);
         this.lblCONS_CodMOD.TabIndex = 5;
         this.lblCONS_CodMOD.Text = "Modulo:";
         // 
         // lblEVEN_Usuario
         // 
         this.lblEVEN_Usuario.AutoSize = true;
         this.lblEVEN_Usuario.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblEVEN_Usuario.Location = new System.Drawing.Point(738, 34);
         this.lblEVEN_Usuario.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblEVEN_Usuario.Name = "lblEVEN_Usuario";
         this.lblEVEN_Usuario.Size = new System.Drawing.Size(55, 13);
         this.lblEVEN_Usuario.TabIndex = 22;
         this.lblEVEN_Usuario.Text = "Usuario:";
         // 
         // EVEN_Usuario
         // 
         this.EVEN_Usuario.Location = new System.Drawing.Point(880, 30);
         this.EVEN_Usuario.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.EVEN_Usuario.Name = "EVEN_Usuario";
         this.EVEN_Usuario.ReadOnly = true;
         this.EVEN_Usuario.Size = new System.Drawing.Size(194, 20);
         this.EVEN_Usuario.TabIndex = 23;
         // 
         // panelEventoTarea
         // 
         this.panelEventoTarea.AllowActive = false;
         this.panelEventoTarea.AntiAlias = false;
         this.panelEventoTarea.Caption = "Datos Evento/Tarea";
         this.panelEventoTarea.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelEventoTarea.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelEventoTarea.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelEventoTarea.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelEventoTarea.Location = new System.Drawing.Point(0, 0);
         this.panelEventoTarea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelEventoTarea.Name = "panelEventoTarea";
         this.panelEventoTarea.Size = new System.Drawing.Size(1204, 27);
         this.panelEventoTarea.TabIndex = 15;
         // 
         // pageRectificaciones
         // 
         this.pageRectificaciones.Controls.Add(this.tabRectificaciones);
         this.pageRectificaciones.Controls.Add(this.toolStrip3);
         this.pageRectificaciones.Controls.Add(this.panelCaption18);
         this.pageRectificaciones.Location = new System.Drawing.Point(4, 25);
         this.pageRectificaciones.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.pageRectificaciones.Name = "pageRectificaciones";
         this.pageRectificaciones.Size = new System.Drawing.Size(1204, 494);
         this.pageRectificaciones.TabIndex = 8;
         this.pageRectificaciones.Text = "Anexos(1, 2 y 3)";
         // 
         // tabRectificaciones
         // 
         this.tabRectificaciones.BackColor = System.Drawing.Color.LightSteelBlue;
         this.tabRectificaciones.Controls.Add(this.pageDatosRectificacion);
         this.tabRectificaciones.Controls.Add(this.pageListRectificaciones);
         this.tabRectificaciones.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabRectificaciones.Location = new System.Drawing.Point(0, 65);
         this.tabRectificaciones.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.tabRectificaciones.Name = "tabRectificaciones";
         this.tabRectificaciones.SelectedIndex = 0;
         this.tabRectificaciones.SelectedTabColor = System.Drawing.Color.SteelBlue;
         this.tabRectificaciones.Size = new System.Drawing.Size(1204, 429);
         this.tabRectificaciones.TabIndex = 19;
         this.tabRectificaciones.UseVisualStyles = false;
         // 
         // pageDatosRectificacion
         // 
         this.pageDatosRectificacion.Controls.Add(this.tableLayoutPanel9);
         this.pageDatosRectificacion.Location = new System.Drawing.Point(4, 25);
         this.pageDatosRectificacion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.pageDatosRectificacion.Name = "pageDatosRectificacion";
         this.pageDatosRectificacion.Size = new System.Drawing.Size(1196, 400);
         this.pageDatosRectificacion.TabIndex = 0;
         this.pageDatosRectificacion.Text = "Datos Anexo";
         // 
         // tableLayoutPanel9
         // 
         this.tableLayoutPanel9.AutoSize = true;
         this.tableLayoutPanel9.ColumnCount = 10;
         this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
         this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel9.Controls.Add(this.listView1, 1, 9);
         this.tableLayoutPanel9.Controls.Add(this.textBox8, 1, 5);
         this.tableLayoutPanel9.Controls.Add(this.label20, 0, 0);
         this.tableLayoutPanel9.Controls.Add(this.maskTime2, 7, 0);
         this.tableLayoutPanel9.Controls.Add(this.maskTime4, 7, 1);
         this.tableLayoutPanel9.Controls.Add(this.label17, 6, 0);
         this.tableLayoutPanel9.Controls.Add(this.label18, 6, 1);
         this.tableLayoutPanel9.Controls.Add(this.maskTime1, 4, 0);
         this.tableLayoutPanel9.Controls.Add(this.maskTime3, 4, 1);
         this.tableLayoutPanel9.Controls.Add(this.label16, 3, 0);
         this.tableLayoutPanel9.Controls.Add(this.label15, 3, 1);
         this.tableLayoutPanel9.Controls.Add(this.label21, 0, 1);
         this.tableLayoutPanel9.Controls.Add(this.textBox5, 1, 0);
         this.tableLayoutPanel9.Controls.Add(this.textBox6, 1, 1);
         this.tableLayoutPanel9.Controls.Add(this.label22, 0, 3);
         this.tableLayoutPanel9.Controls.Add(this.textBox7, 1, 3);
         this.tableLayoutPanel9.Controls.Add(this.label23, 0, 5);
         this.tableLayoutPanel9.Controls.Add(this.textBox9, 1, 7);
         this.tableLayoutPanel9.Controls.Add(this.label24, 0, 7);
         this.tableLayoutPanel9.Controls.Add(this.label25, 0, 9);
         this.tableLayoutPanel9.Controls.Add(this.comboBoxTipos1, 4, 2);
         this.tableLayoutPanel9.Controls.Add(this.label14, 3, 2);
         this.tableLayoutPanel9.Controls.Add(this.label33, 0, 2);
         this.tableLayoutPanel9.Controls.Add(this.panel7, 1, 2);
         this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
         this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.tableLayoutPanel9.Name = "tableLayoutPanel9";
         this.tableLayoutPanel9.RowCount = 12;
         this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel9.Size = new System.Drawing.Size(1196, 366);
         this.tableLayoutPanel9.TabIndex = 19;
         // 
         // listView1
         // 
         this.listView1.CheckBoxes = true;
         this.tableLayoutPanel9.SetColumnSpan(this.listView1, 7);
         listViewItem1.StateImageIndex = 0;
         listViewItem2.StateImageIndex = 0;
         listViewItem3.StateImageIndex = 0;
         listViewItem4.StateImageIndex = 0;
         listViewItem5.StateImageIndex = 0;
         listViewItem6.StateImageIndex = 0;
         listViewItem7.StateImageIndex = 0;
         listViewItem8.StateImageIndex = 0;
         listViewItem9.StateImageIndex = 0;
         listViewItem10.StateImageIndex = 0;
         listViewItem11.StateImageIndex = 0;
         listViewItem12.StateImageIndex = 0;
         listViewItem13.StateImageIndex = 0;
         listViewItem14.StateImageIndex = 0;
         listViewItem15.StateImageIndex = 0;
         listViewItem16.StateImageIndex = 0;
         listViewItem17.StateImageIndex = 0;
         listViewItem18.StateImageIndex = 0;
         this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18});
         this.listView1.Location = new System.Drawing.Point(152, 246);
         this.listView1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.listView1.Name = "listView1";
         this.tableLayoutPanel9.SetRowSpan(this.listView1, 3);
         this.listView1.Size = new System.Drawing.Size(924, 117);
         this.listView1.TabIndex = 19;
         this.listView1.UseCompatibleStateImageBehavior = false;
         this.listView1.View = System.Windows.Forms.View.List;
         // 
         // textBox8
         // 
         this.tableLayoutPanel9.SetColumnSpan(this.textBox8, 7);
         this.textBox8.Location = new System.Drawing.Point(152, 138);
         this.textBox8.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.textBox8.Multiline = true;
         this.textBox8.Name = "textBox8";
         this.tableLayoutPanel9.SetRowSpan(this.textBox8, 2);
         this.textBox8.Size = new System.Drawing.Size(924, 47);
         this.textBox8.TabIndex = 21;
         // 
         // label20
         // 
         this.label20.AutoSize = true;
         this.label20.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label20.Location = new System.Drawing.Point(10, 7);
         this.label20.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label20.Name = "label20";
         this.label20.Size = new System.Drawing.Size(136, 13);
         this.label20.TabIndex = 14;
         this.label20.Text = "Número de Manifiesto:";
         // 
         // maskTime2
         // 
         this.maskTime2.Location = new System.Drawing.Point(880, 3);
         this.maskTime2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.maskTime2.MinimumSize = new System.Drawing.Size(100, 22);
         this.maskTime2.Name = "maskTime2";
         this.maskTime2.NSActiveMouse = false;
         this.maskTime2.NSActiveMsgFecha = false;
         this.maskTime2.NSChangeDate = true;
         this.maskTime2.NSDigitos = 4;
         this.maskTime2.NSFecha = null;
         this.maskTime2.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.maskTime2.NSSetDateNow = false;
         this.maskTime2.Size = new System.Drawing.Size(100, 22);
         this.maskTime2.TabIndex = 11;
         // 
         // maskTime4
         // 
         this.maskTime4.Location = new System.Drawing.Point(880, 30);
         this.maskTime4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.maskTime4.MinimumSize = new System.Drawing.Size(100, 22);
         this.maskTime4.Name = "maskTime4";
         this.maskTime4.NSActiveMouse = false;
         this.maskTime4.NSActiveMsgFecha = false;
         this.maskTime4.NSChangeDate = true;
         this.maskTime4.NSDigitos = 4;
         this.maskTime4.NSFecha = null;
         this.maskTime4.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.maskTime4.NSSetDateNow = false;
         this.maskTime4.Size = new System.Drawing.Size(100, 22);
         this.maskTime4.TabIndex = 13;
         // 
         // label17
         // 
         this.label17.AutoSize = true;
         this.label17.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label17.Location = new System.Drawing.Point(738, 7);
         this.label17.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label17.Name = "label17";
         this.label17.Size = new System.Drawing.Size(102, 13);
         this.label17.TabIndex = 9;
         this.label17.Text = "Fecha de Salida:";
         // 
         // label18
         // 
         this.label18.AutoSize = true;
         this.label18.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label18.Location = new System.Drawing.Point(738, 34);
         this.label18.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label18.Name = "label18";
         this.label18.Size = new System.Drawing.Size(125, 13);
         this.label18.TabIndex = 10;
         this.label18.Text = "Fecha de Embarque:";
         // 
         // maskTime1
         // 
         this.maskTime1.Location = new System.Drawing.Point(516, 3);
         this.maskTime1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.maskTime1.MinimumSize = new System.Drawing.Size(100, 22);
         this.maskTime1.Name = "maskTime1";
         this.maskTime1.NSActiveMouse = false;
         this.maskTime1.NSActiveMsgFecha = false;
         this.maskTime1.NSChangeDate = true;
         this.maskTime1.NSDigitos = 4;
         this.maskTime1.NSFecha = null;
         this.maskTime1.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.maskTime1.NSSetDateNow = false;
         this.maskTime1.Size = new System.Drawing.Size(100, 22);
         this.maskTime1.TabIndex = 8;
         // 
         // maskTime3
         // 
         this.maskTime3.Location = new System.Drawing.Point(516, 30);
         this.maskTime3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.maskTime3.MinimumSize = new System.Drawing.Size(100, 22);
         this.maskTime3.Name = "maskTime3";
         this.maskTime3.NSActiveMouse = false;
         this.maskTime3.NSActiveMsgFecha = false;
         this.maskTime3.NSChangeDate = true;
         this.maskTime3.NSDigitos = 4;
         this.maskTime3.NSFecha = null;
         this.maskTime3.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.maskTime3.NSSetDateNow = false;
         this.maskTime3.Size = new System.Drawing.Size(100, 22);
         this.maskTime3.TabIndex = 12;
         // 
         // label16
         // 
         this.label16.AutoSize = true;
         this.label16.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label16.Location = new System.Drawing.Point(374, 7);
         this.label16.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label16.Name = "label16";
         this.label16.Size = new System.Drawing.Size(111, 13);
         this.label16.TabIndex = 7;
         this.label16.Text = "Fecha de Llegada:";
         // 
         // label15
         // 
         this.label15.AutoSize = true;
         this.label15.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label15.Location = new System.Drawing.Point(374, 34);
         this.label15.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label15.Name = "label15";
         this.label15.Size = new System.Drawing.Size(121, 13);
         this.label15.TabIndex = 6;
         this.label15.Text = "Fecha de Descarga:";
         // 
         // label21
         // 
         this.label21.AutoSize = true;
         this.label21.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label21.Location = new System.Drawing.Point(10, 34);
         this.label21.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label21.Name = "label21";
         this.label21.Size = new System.Drawing.Size(101, 13);
         this.label21.TabIndex = 15;
         this.label21.Text = "Número de HBL:";
         // 
         // textBox5
         // 
         this.textBox5.Location = new System.Drawing.Point(152, 3);
         this.textBox5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.textBox5.Name = "textBox5";
         this.textBox5.Size = new System.Drawing.Size(194, 20);
         this.textBox5.TabIndex = 16;
         // 
         // textBox6
         // 
         this.textBox6.Location = new System.Drawing.Point(152, 30);
         this.textBox6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.textBox6.Name = "textBox6";
         this.textBox6.Size = new System.Drawing.Size(194, 20);
         this.textBox6.TabIndex = 17;
         // 
         // label22
         // 
         this.label22.AutoSize = true;
         this.label22.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label22.Location = new System.Drawing.Point(10, 88);
         this.label22.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label22.Name = "label22";
         this.label22.Size = new System.Drawing.Size(96, 13);
         this.label22.TabIndex = 18;
         this.label22.Text = "Observaciones:";
         // 
         // textBox7
         // 
         this.tableLayoutPanel9.SetColumnSpan(this.textBox7, 7);
         this.textBox7.Location = new System.Drawing.Point(152, 84);
         this.textBox7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.textBox7.Multiline = true;
         this.textBox7.Name = "textBox7";
         this.tableLayoutPanel9.SetRowSpan(this.textBox7, 2);
         this.textBox7.Size = new System.Drawing.Size(924, 47);
         this.textBox7.TabIndex = 19;
         // 
         // label23
         // 
         this.label23.AutoSize = true;
         this.label23.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label23.Location = new System.Drawing.Point(10, 142);
         this.label23.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label23.Name = "label23";
         this.label23.Size = new System.Drawing.Size(78, 13);
         this.label23.TabIndex = 20;
         this.label23.Text = "Donde Dice:";
         // 
         // textBox9
         // 
         this.tableLayoutPanel9.SetColumnSpan(this.textBox9, 7);
         this.textBox9.Location = new System.Drawing.Point(152, 192);
         this.textBox9.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.textBox9.Multiline = true;
         this.textBox9.Name = "textBox9";
         this.tableLayoutPanel9.SetRowSpan(this.textBox9, 2);
         this.textBox9.Size = new System.Drawing.Size(924, 47);
         this.textBox9.TabIndex = 22;
         // 
         // label24
         // 
         this.label24.AutoSize = true;
         this.label24.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label24.Location = new System.Drawing.Point(10, 196);
         this.label24.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label24.Name = "label24";
         this.label24.Size = new System.Drawing.Size(76, 13);
         this.label24.TabIndex = 23;
         this.label24.Text = "Debe Decir:";
         // 
         // label25
         // 
         this.label25.AutoSize = true;
         this.label25.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label25.Location = new System.Drawing.Point(10, 250);
         this.label25.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label25.Name = "label25";
         this.tableLayoutPanel9.SetRowSpan(this.label25, 2);
         this.label25.Size = new System.Drawing.Size(124, 26);
         this.label25.TabIndex = 25;
         this.label25.Text = "Documentos que se Adjuntan:";
         // 
         // comboBoxTipos1
         // 
         this.comboBoxTipos1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxTipos1.FormattingEnabled = true;
         this.comboBoxTipos1.Location = new System.Drawing.Point(516, 57);
         this.comboBoxTipos1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.comboBoxTipos1.Name = "comboBoxTipos1";
         this.comboBoxTipos1.Size = new System.Drawing.Size(194, 21);
         this.comboBoxTipos1.TabIndex = 5;
         this.comboBoxTipos1.TiposSelectedItem = null;
         this.comboBoxTipos1.TiposSelectedValue = null;
         this.comboBoxTipos1.TiposTitulo = null;
         // 
         // label14
         // 
         this.label14.AutoSize = true;
         this.label14.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label14.Location = new System.Drawing.Point(374, 61);
         this.label14.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(129, 13);
         this.label14.TabIndex = 4;
         this.label14.Text = "Tipo de Rectificación:";
         // 
         // label33
         // 
         this.label33.AutoSize = true;
         this.label33.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label33.Location = new System.Drawing.Point(10, 61);
         this.label33.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label33.Name = "label33";
         this.label33.Size = new System.Drawing.Size(94, 13);
         this.label33.TabIndex = 26;
         this.label33.Text = "Tipo de Anexo:";
         // 
         // panel7
         // 
         this.panel7.Controls.Add(this.radioButton2);
         this.panel7.Controls.Add(this.radioButton1);
         this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel7.Location = new System.Drawing.Point(150, 54);
         this.panel7.Margin = new System.Windows.Forms.Padding(0);
         this.panel7.Name = "panel7";
         this.panel7.Size = new System.Drawing.Size(200, 27);
         this.panel7.TabIndex = 27;
         // 
         // radioButton2
         // 
         this.radioButton2.AutoSize = true;
         this.radioButton2.Location = new System.Drawing.Point(95, 3);
         this.radioButton2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.radioButton2.Name = "radioButton2";
         this.radioButton2.Size = new System.Drawing.Size(90, 17);
         this.radioButton2.TabIndex = 1;
         this.radioButton2.TabStop = true;
         this.radioButton2.Text = "Incorporación";
         this.radioButton2.UseVisualStyleBackColor = true;
         // 
         // radioButton1
         // 
         this.radioButton1.AutoSize = true;
         this.radioButton1.Location = new System.Drawing.Point(4, 4);
         this.radioButton1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.radioButton1.Name = "radioButton1";
         this.radioButton1.Size = new System.Drawing.Size(87, 17);
         this.radioButton1.TabIndex = 0;
         this.radioButton1.TabStop = true;
         this.radioButton1.Text = "Rectificación";
         this.radioButton1.UseVisualStyleBackColor = true;
         // 
         // pageListRectificaciones
         // 
         this.pageListRectificaciones.Controls.Add(this.grdListRectificaciones);
         this.pageListRectificaciones.Location = new System.Drawing.Point(4, 25);
         this.pageListRectificaciones.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.pageListRectificaciones.Name = "pageListRectificaciones";
         this.pageListRectificaciones.Size = new System.Drawing.Size(1196, 400);
         this.pageListRectificaciones.TabIndex = 1;
         this.pageListRectificaciones.Text = "Listado de Anexos";
         // 
         // grdListRectificaciones
         // 
         this.grdListRectificaciones.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdListRectificaciones.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdListRectificaciones.Location = new System.Drawing.Point(0, 0);
         this.grdListRectificaciones.Margin = new System.Windows.Forms.Padding(2, 3, 18, 3);
         this.grdListRectificaciones.Name = "grdListRectificaciones";
         // 
         // 
         // 
         this.grdListRectificaciones.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 240, 150);
         this.grdListRectificaciones.RootElement.MinSize = new System.Drawing.Size(0, 0);
         this.grdListRectificaciones.Size = new System.Drawing.Size(1196, 400);
         this.grdListRectificaciones.TabIndex = 11;
         this.grdListRectificaciones.TabStop = false;
         // 
         // toolStrip3
         // 
         this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton7,
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolStripButton9});
         this.toolStrip3.Location = new System.Drawing.Point(0, 27);
         this.toolStrip3.Name = "toolStrip3";
         this.toolStrip3.Size = new System.Drawing.Size(1204, 38);
         this.toolStrip3.TabIndex = 17;
         this.toolStrip3.Text = "toolStrip3";
         // 
         // toolStripButton7
         // 
         this.toolStripButton7.Image = global::Delfin.Comercial.Properties.Resources.add;
         this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton7.Name = "toolStripButton7";
         this.toolStripButton7.Size = new System.Drawing.Size(46, 35);
         this.toolStripButton7.Text = "Nuevo";
         this.toolStripButton7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.toolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         // 
         // toolStripButton2
         // 
         this.toolStripButton2.Image = global::Delfin.Comercial.Properties.Resources.save;
         this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton2.Name = "toolStripButton2";
         this.toolStripButton2.Size = new System.Drawing.Size(53, 35);
         this.toolStripButton2.Text = "Guardar";
         this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.Image = global::Delfin.Comercial.Properties.Resources.undo;
         this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.Size = new System.Drawing.Size(59, 35);
         this.toolStripButton1.Text = "Deshacer";
         this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         // 
         // toolStripButton9
         // 
         this.toolStripButton9.Image = global::Delfin.Comercial.Properties.Resources.printer2;
         this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton9.Name = "toolStripButton9";
         this.toolStripButton9.Size = new System.Drawing.Size(57, 35);
         this.toolStripButton9.Text = "Imprimir";
         this.toolStripButton9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.toolStripButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         // 
         // panelCaption18
         // 
         this.panelCaption18.AllowActive = false;
         this.panelCaption18.AntiAlias = false;
         this.panelCaption18.Caption = "Manifiesto de Carga - Rectificaciones e Incorporaciones";
         this.panelCaption18.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption18.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption18.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption18.Location = new System.Drawing.Point(0, 0);
         this.panelCaption18.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption18.Name = "panelCaption18";
         this.panelCaption18.Size = new System.Drawing.Size(1204, 27);
         this.panelCaption18.TabIndex = 16;
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
         // toolStrip1
         // 
         this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnSalir,
            this.toolStripButton3,
            this.toolStripDropDownButton1,
            this.toolStripButton11,
            this.toolStripButton10,
            this.toolStripButton8});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(1212, 38);
         this.toolStrip1.TabIndex = 4;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // btnGuardar
         // 
         this.btnGuardar.Image = global::Delfin.Comercial.Properties.Resources.save;
         this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnGuardar.Name = "btnGuardar";
         this.btnGuardar.Size = new System.Drawing.Size(53, 35);
         this.btnGuardar.Text = "Guardar";
         this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         // 
         // btnSalir
         // 
         this.btnSalir.Image = global::Delfin.Comercial.Properties.Resources.undo;
         this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnSalir.Name = "btnSalir";
         this.btnSalir.Size = new System.Drawing.Size(33, 35);
         this.btnSalir.Text = "Salir";
         this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         // 
         // toolStripButton3
         // 
         this.toolStripButton3.Image = global::Delfin.Comercial.Properties.Resources.money2;
         this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton3.Name = "toolStripButton3";
         this.toolStripButton3.Size = new System.Drawing.Size(69, 35);
         this.toolStripButton3.Text = "Prefacturar";
         this.toolStripButton3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         // 
         // toolStripDropDownButton1
         // 
         this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
         this.toolStripDropDownButton1.Image = global::Delfin.Comercial.Properties.Resources.document_into;
         this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
         this.toolStripDropDownButton1.Size = new System.Drawing.Size(98, 35);
         this.toolStripDropDownButton1.Text = "Emisión Cartas";
         this.toolStripDropDownButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         // 
         // toolStripMenuItem1
         // 
         this.toolStripMenuItem1.Name = "toolStripMenuItem1";
         this.toolStripMenuItem1.Size = new System.Drawing.Size(252, 22);
         this.toolStripMenuItem1.Text = "Devolución Master";
         // 
         // toolStripMenuItem2
         // 
         this.toolStripMenuItem2.Name = "toolStripMenuItem2";
         this.toolStripMenuItem2.Size = new System.Drawing.Size(252, 22);
         this.toolStripMenuItem2.Text = "Recojo";
         // 
         // toolStripMenuItem3
         // 
         this.toolStripMenuItem3.Name = "toolStripMenuItem3";
         this.toolStripMenuItem3.Size = new System.Drawing.Size(252, 22);
         this.toolStripMenuItem3.Text = "Autorización Servicio Transmisión";
         // 
         // toolStripMenuItem4
         // 
         this.toolStripMenuItem4.Name = "toolStripMenuItem4";
         this.toolStripMenuItem4.Size = new System.Drawing.Size(252, 22);
         this.toolStripMenuItem4.Text = "Direccionamiento";
         // 
         // toolStripMenuItem5
         // 
         this.toolStripMenuItem5.Name = "toolStripMenuItem5";
         this.toolStripMenuItem5.Size = new System.Drawing.Size(252, 22);
         this.toolStripMenuItem5.Text = "Visto Bueno";
         // 
         // toolStripMenuItem6
         // 
         this.toolStripMenuItem6.Name = "toolStripMenuItem6";
         this.toolStripMenuItem6.Size = new System.Drawing.Size(252, 22);
         this.toolStripMenuItem6.Text = "Solicitud Volante";
         // 
         // toolStripButton11
         // 
         this.toolStripButton11.Image = global::Delfin.Comercial.Properties.Resources.printer2;
         this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton11.Name = "toolStripButton11";
         this.toolStripButton11.Size = new System.Drawing.Size(68, 35);
         this.toolStripButton11.Text = "Guía Aérea";
         this.toolStripButton11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.toolStripButton11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         // 
         // toolStripButton10
         // 
         this.toolStripButton10.Image = global::Delfin.Comercial.Properties.Resources.printer2;
         this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton10.Name = "toolStripButton10";
         this.toolStripButton10.Size = new System.Drawing.Size(157, 35);
         this.toolStripButton10.Text = "Exportación Cargo Manifest";
         this.toolStripButton10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.toolStripButton10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         // 
         // toolStripButton8
         // 
         this.toolStripButton8.Image = global::Delfin.Comercial.Properties.Resources.printer2;
         this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton8.Name = "toolStripButton8";
         this.toolStripButton8.Size = new System.Drawing.Size(57, 35);
         this.toolStripButton8.Text = "Sctickers";
         this.toolStripButton8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.toolStripButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         // 
         // lblCONS_CodLNG
         // 
         this.lblCONS_CodLNG.AutoSize = true;
         this.lblCONS_CodLNG.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONS_CodLNG.Location = new System.Drawing.Point(10, 385);
         this.lblCONS_CodLNG.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONS_CodLNG.Name = "lblCONS_CodLNG";
         this.lblCONS_CodLNG.Size = new System.Drawing.Size(102, 13);
         this.lblCONS_CodLNG.TabIndex = 59;
         this.lblCONS_CodLNG.Text = "Línea Negocio:";
         // 
         // cmbCONS_CodLNG
         // 
         this.cmbCONS_CodLNG.ConstantesSelectedItem = null;
         this.cmbCONS_CodLNG.ConstantesSelectedValue = null;
         this.cmbCONS_CodLNG.ConstantesTitulo = null;
         this.cmbCONS_CodLNG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbCONS_CodLNG.Enabled = false;
         this.cmbCONS_CodLNG.FormattingEnabled = true;
         this.cmbCONS_CodLNG.Location = new System.Drawing.Point(153, 381);
         this.cmbCONS_CodLNG.Name = "cmbCONS_CodLNG";
         this.cmbCONS_CodLNG.Size = new System.Drawing.Size(194, 21);
         this.cmbCONS_CodLNG.TabIndex = 60;
         this.cmbCONS_CodLNG.Tag = "CONS_CodLNGMSGERROR";
         // 
         // COM007OView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(1212, 561);
         this.Controls.Add(this.tabCab_Cotizacion_OV);
         this.Controls.Add(this.toolStrip1);
         this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.Name = "COM007OView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Cotización";
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).EndInit();
         this.tabCab_Cotizacion_OV.ResumeLayout(false);
         this.pageGenerales.ResumeLayout(false);
         this.pageGenerales.PerformLayout();
         this.tableDatosGenerales.ResumeLayout(false);
         this.tableDatosGenerales.PerformLayout();
         this.panel3.ResumeLayout(false);
         this.pageServiciosTarifa.ResumeLayout(false);
         this.pageServiciosTarifa.PerformLayout();
         this.tabServiciosAdicionales.ResumeLayout(false);
         this.pageServicios.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsServicio)).EndInit();
         this.pageChangeControl.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdServiciosChangeControl.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdServiciosChangeControl)).EndInit();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsFlete.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsFlete)).EndInit();
         this.tableLayoutPanel4.ResumeLayout(false);
         this.tableLayoutPanel4.PerformLayout();
         this.panel8.ResumeLayout(false);
         this.tableLayoutPanel3.ResumeLayout(false);
         this.tableLayoutPanel3.PerformLayout();
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         this.pageEmbarque.ResumeLayout(false);
         this.tabControlEX1.ResumeLayout(false);
         this.tabPageEX1.ResumeLayout(false);
         this.tabPageEX1.PerformLayout();
         this.tableLayoutPanel7.ResumeLayout(false);
         this.tableLayoutPanel7.PerformLayout();
         this.tableDatosViaje.ResumeLayout(false);
         this.tableDatosViaje.PerformLayout();
         this.panel10.ResumeLayout(false);
         this.tableLayoutPanel8.ResumeLayout(false);
         this.tableLayoutPanel8.PerformLayout();
         this.tabPageEX2.ResumeLayout(false);
         this.tabPageEX2.PerformLayout();
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.toolStrip4.ResumeLayout(false);
         this.toolStrip4.PerformLayout();
         this.tabPageEX3.ResumeLayout(false);
         this.tabPageEX3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdMatrizDetalle.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdMatrizDetalle)).EndInit();
         this.toolStrip2.ResumeLayout(false);
         this.toolStrip2.PerformLayout();
         this.pageArchivos.ResumeLayout(false);
         this.pageArchivos.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsArchivos.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsArchivos)).EndInit();
         this.panel4.ResumeLayout(false);
         this.tableArchivo.ResumeLayout(false);
         this.tableArchivo.PerformLayout();
         this.pageEventosTareas.ResumeLayout(false);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel1.PerformLayout();
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.Panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsNovedades.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsNovedades)).EndInit();
         this.panel5.ResumeLayout(false);
         this.tableNovedad.ResumeLayout(false);
         this.tableNovedad.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsEventosTareas.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItemsEventosTareas)).EndInit();
         this.panel9.ResumeLayout(false);
         this.tableEventoTarea.ResumeLayout(false);
         this.tableEventoTarea.PerformLayout();
         this.panel6.ResumeLayout(false);
         this.panel6.PerformLayout();
         this.pageRectificaciones.ResumeLayout(false);
         this.pageRectificaciones.PerformLayout();
         this.tabRectificaciones.ResumeLayout(false);
         this.pageDatosRectificacion.ResumeLayout(false);
         this.pageDatosRectificacion.PerformLayout();
         this.tableLayoutPanel9.ResumeLayout(false);
         this.tableLayoutPanel9.PerformLayout();
         this.panel7.ResumeLayout(false);
         this.panel7.PerformLayout();
         this.pageListRectificaciones.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdListRectificaciones.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdListRectificaciones)).EndInit();
         this.toolStrip3.ResumeLayout(false);
         this.toolStrip3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).EndInit();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }



      #endregion

      private System.Windows.Forms.ErrorProvider errorProviderCab_Cotizacion_OV;
      private Dotnetrix.Controls.TabControlEX tabCab_Cotizacion_OV;
      private Dotnetrix.Controls.TabPageEX pageGenerales;
      private System.Windows.Forms.TableLayoutPanel tableDatosGenerales;
      private System.Windows.Forms.TextBox CCOT_NumDocCOT;
      private System.Windows.Forms.Label lblCCOT_NumDocCOT;
      private System.Windows.Forms.Label lblCCOT_Version;
      private System.Windows.Forms.TextBox CCOT_Version;
      private System.Windows.Forms.Label lblCCOT_FecEmi;
      private Infrastructure.WinForms.Controls.MaskDateTime CCOT_FecEmi;
      private System.Windows.Forms.Label lblCCOT_FecVcto;
      private Infrastructure.WinForms.Controls.MaskDateTime CCOT_FecVcto;
      private System.Windows.Forms.Label lblENTC_CodAgente;
      private Controls.Entidad ENTC_CodAgente;
      private System.Windows.Forms.Label lblCONS_CodRGM;
      private Controls.Tipos.ComboBoxConstantes cmbCONS_CodRGM;
      private System.Windows.Forms.Label lblCONS_CodVia;
      private Controls.Tipos.ComboBoxConstantes cmbCONS_CodVia;
      private System.Windows.Forms.Label lblENTC_CodCliente;
      private Controls.Entidad ENTC_CodCliente;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private Dotnetrix.Controls.TabPageEX pageServiciosTarifa;
      private System.Windows.Forms.Label lblTIPO_CodMND;
      private System.Windows.Forms.Label lblPUER_CodOrigen;
      private System.Windows.Forms.Label lblPUER_CodDestino;
      private System.Windows.Forms.Label lblCONS_CodESTCOT;
      private Controls.Tipos.ComboBoxConstantes CONS_CodESTCOT;
      private System.Windows.Forms.Label lblENTC_CodBroker;
      private System.Windows.Forms.Label lblENTC_CodEjecutivo;
      private System.Windows.Forms.Label lblENTC_CodCustomer;
      private Controls.Entidad ENTC_CodBroker;
      private Controls.Entidad ENTC_CodEjecutivo;
      private Controls.Entidad ENTC_CodCustomer;
      private Controls.Tipos.ComboBoxTipos TIPO_CodINC;
      private System.Windows.Forms.Label lblTIPO_CodINC;
      private System.Windows.Forms.Label lblCCOT_Propia;
      private System.Windows.Forms.Label lblCCOT_ServicioLogistico;
      private System.Windows.Forms.CheckBox CCOT_Propia;
      private System.Windows.Forms.CheckBox CCOT_ServicioLogistico;
      private System.Windows.Forms.TextBox ENTC_EMail;
      private System.Windows.Forms.TextBox ENTC_Cargo;
      private System.Windows.Forms.Label lblCCOT_FecAprueba;
      private Infrastructure.WinForms.Controls.MaskDateTime CCOT_FecAprueba;
      private System.Windows.Forms.Button btnEditarContacto;
      private System.Windows.Forms.Button btnNuevoContacto;
      private Dotnetrix.Controls.TabPageEX pageEmbarque;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private Controls.Tipos.ComboBoxTipos TIPO_CodMND;
      private System.Windows.Forms.Label lblPUER_CodTrasbordo;
      private Controls.Entidad ENTC_CodTransportista;
      private System.Windows.Forms.Label lblENTC_CodTransportista;
      private System.Windows.Forms.Label lblCONT_Numero;
      private System.Windows.Forms.TextBox CONT_Descrip;
      private Infrastructure.WinForms.Controls.TextBoxAyuda CONT_Numero;
      private System.Windows.Forms.Panel panel1;
      private Controls.Tipos.ComboBoxConstantes CONS_CodFLE;
      private System.Windows.Forms.Label lblCONS_CodFLE;
      private Controls.Tipos.ComboBoxConstantes CONS_CodTFT;
      private System.Windows.Forms.Label lblCONS_CodTFT;
      private System.Windows.Forms.Label lblCCOT_FecTarifa;
      private Infrastructure.WinForms.Controls.MaskDateTime CCOT_FecTarifa;
      private Telerik.WinControls.UI.RadGridView grdItemsFlete;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
      private System.Windows.Forms.Label lblCCOT_PagoMBL;
      private System.Windows.Forms.Label lblCCOT_PagoHBL;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox CCOT_PagoMBL;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox CCOT_PagoHBL;
      private System.Windows.Forms.Label lblDCOT_Importe;
      private System.Windows.Forms.Label lblDCOT_Rentabilidad;
      private Infrastructure.WinForms.Controls.TextBoxNumerico DCOT_Importe;
      private Infrastructure.WinForms.Controls.TextBoxNumerico DCOT_Rentabilidad;
      private System.Windows.Forms.Label label19;
      private System.Windows.Forms.Label lblENTC_CodContacto;
      private System.Windows.Forms.Label lblENTC_EMail;
      private System.Windows.Forms.Label lblENTC_Cargo;
      private System.Windows.Forms.TextBox ENTC_Contacto;
      private System.Windows.Forms.Label lblCCOT_NumDocOV;
      private System.Windows.Forms.TextBox CCOT_NumDocOV;
      private System.Windows.Forms.Label lblCCOT_NumDocCOT2;
      private System.Windows.Forms.TextBox CCOT_NumDocCOT2;
      private System.Windows.Forms.Label lblCONS_CodESTOV;
      private Controls.Tipos.ComboBoxConstantes CONS_CodESTOV;
      private Dotnetrix.Controls.TabPageEX pageArchivos;
      private Telerik.WinControls.UI.RadGridView grdItemsArchivos;
      private System.Windows.Forms.TableLayoutPanel tableArchivo;
      private System.Windows.Forms.Button btnDownloadFile;
      private System.Windows.Forms.Button btnUploadFile;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption11;
      private System.Windows.Forms.Label lblOVAR_Archivo;
      private Infrastructure.WinForms.Controls.TextBoxOpenFile OVAR_Archivo;
      private System.Windows.Forms.Panel panel4;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption13;
      private System.Windows.Forms.ErrorProvider errorProviderDet_Cotizacion_OV_Novedad;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Button btnCambiarContrato;
      private System.Windows.Forms.ToolTip toolTip1;
      private Dotnetrix.Controls.TabPageEX pageEventosTareas;
      private System.Windows.Forms.ErrorProvider errorEventoTarea;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.CheckBox checkBox1;
      private System.Windows.Forms.CheckBox checkBox2;
      private System.Windows.Forms.CheckBox checkBox3;
      private System.Windows.Forms.CheckBox checkBox4;
      private System.Windows.Forms.CheckBox checkBox5;
      private System.Windows.Forms.Label label8;
      private Infrastructure.WinForms.Controls.MaskDateTime maskDateTime1;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.CheckBox checkBox6;
      private Controls.AyudaPuerto ayudaPuerto1;
      private Controls.AyudaPuerto ayudaPuerto2;
      private Controls.AyudaPuerto ayudaPuerto3;
      private Dotnetrix.Controls.TabControlEX tabServiciosAdicionales;
      private Dotnetrix.Controls.TabPageEX pageChangeControl;
      private Telerik.WinControls.UI.RadGridView grdServiciosChangeControl;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption16;
      private Dotnetrix.Controls.TabPageEX pageServicios;
      private Telerik.WinControls.UI.RadGridView grdItemsServicio;
      private System.Windows.Forms.Button btnDelServicio;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption5;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton btnGuardar;
      private System.Windows.Forms.ToolStripButton btnSalir;
      private System.Windows.Forms.ToolStripButton toolStripButton3;
      private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
      private Dotnetrix.Controls.TabPageEX pageRectificaciones;
      private System.Windows.Forms.ToolStrip toolStrip3;
      private System.Windows.Forms.ToolStripButton toolStripButton7;
      private System.Windows.Forms.ToolStripButton toolStripButton9;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption18;
      private System.Windows.Forms.Button btnAddServicio;
      private Dotnetrix.Controls.TabControlEX tabRectificaciones;
      private Dotnetrix.Controls.TabPageEX pageDatosRectificacion;
      private Dotnetrix.Controls.TabPageEX pageListRectificaciones;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
      private System.Windows.Forms.ListView listView1;
      private System.Windows.Forms.TextBox textBox8;
      private System.Windows.Forms.Label label20;
      private Infrastructure.WinForms.Controls.MaskTime maskTime2;
      private Infrastructure.WinForms.Controls.MaskTime maskTime4;
      private System.Windows.Forms.Label label17;
      private System.Windows.Forms.Label label18;
      private Infrastructure.WinForms.Controls.MaskTime maskTime1;
      private Infrastructure.WinForms.Controls.MaskTime maskTime3;
      private System.Windows.Forms.Label label16;
      private System.Windows.Forms.Label label15;
      private System.Windows.Forms.Label label14;
      private Controls.Tipos.ComboBoxTipos comboBoxTipos1;
      private System.Windows.Forms.Label label21;
      private System.Windows.Forms.TextBox textBox5;
      private System.Windows.Forms.TextBox textBox6;
      private System.Windows.Forms.Label label22;
      private System.Windows.Forms.TextBox textBox7;
      private System.Windows.Forms.Label label23;
      private System.Windows.Forms.TextBox textBox9;
      private System.Windows.Forms.Label label24;
      private System.Windows.Forms.Label label25;
      private System.Windows.Forms.ToolStripButton toolStripButton2;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private Telerik.WinControls.UI.RadGridView grdListRectificaciones;
      private System.Windows.Forms.Label label26;
      private Infrastructure.WinForms.Controls.MaskDateTime maskDateTime2;
      private System.Windows.Forms.Label label27;
      private System.Windows.Forms.Label label28;
      private System.Windows.Forms.Label label29;
      private System.Windows.Forms.Label label30;
      private System.Windows.Forms.Panel panel3;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
      private System.Windows.Forms.Label label31;
      private System.Windows.Forms.CheckBox checkBox7;
      private System.Windows.Forms.CheckBox checkBox8;
      private System.Windows.Forms.CheckBox checkBox9;
      private System.Windows.Forms.CheckBox checkBox10;
      private System.Windows.Forms.CheckBox checkBox11;
      private System.Windows.Forms.ToolStripButton toolStripButton11;
      private System.Windows.Forms.ToolStripButton toolStripButton10;
      private System.Windows.Forms.ToolStripButton toolStripButton8;
      private System.Windows.Forms.Label label32;
      private System.Windows.Forms.CheckBox checkBox12;
      private System.Windows.Forms.Label label33;
      private System.Windows.Forms.Panel panel7;
      private System.Windows.Forms.RadioButton radioButton2;
      private System.Windows.Forms.RadioButton radioButton1;
      private System.Windows.Forms.Label label34;
      private Infrastructure.WinForms.Controls.MaskDateTime maskDateTime3;
      private Infrastructure.WinForms.Controls.MaskDateTime maskDateTime4;
      private System.Windows.Forms.Label label35;
      private System.Windows.Forms.Panel panel8;
      private System.Windows.Forms.Button btnDelFlete;
      private System.Windows.Forms.Button btnAddFlete;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption4;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private Telerik.WinControls.UI.RadGridView grdItemsNovedades;
      private System.Windows.Forms.Panel panel5;
      private System.Windows.Forms.Button btnNuevoNovedad;
      private System.Windows.Forms.Button btnEnviarNovedad;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption14;
      private System.Windows.Forms.TableLayoutPanel tableNovedad;
      private System.Windows.Forms.Label lblOVNO_Descrip;
      private System.Windows.Forms.Label label3;
      private Controls.Tipos.ComboBoxConstantes CONS_CodNot;
      private System.Windows.Forms.TextBox OVNO_Descrip;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption15;
      private Telerik.WinControls.UI.RadGridView grdItemsEventosTareas;
      private System.Windows.Forms.Panel panel9;
      private System.Windows.Forms.Button btnNuevoEventoTarea;
      private System.Windows.Forms.Button btnEditarEventoTarea;
      private System.Windows.Forms.Button btnDeshacerEventoTarea;
      private System.Windows.Forms.Button btnEliminarEventoTarea;
      private System.Windows.Forms.Button btnGuardarEventoTarea;
      private Infrastructure.WinForms.Controls.PanelCaption panelEventosTareas;
      private System.Windows.Forms.TableLayoutPanel tableEventoTarea;
      private System.Windows.Forms.Label lblTIPO_CodEVE;
      private Controls.Tipos.ComboBoxTipos TIPO_CodEVE;
      private System.Windows.Forms.Panel panel6;
      private System.Windows.Forms.RadioButton EVEN_Cumplida;
      private System.Windows.Forms.RadioButton EVEN_Pendiente;
      private System.Windows.Forms.TextBox EVEN_Observaciones;
      private System.Windows.Forms.Label lblEVEN_Observaciones;
      private System.Windows.Forms.Label lblEVEN_Fecha;
      private Infrastructure.WinForms.Controls.MaskTime EVEN_Fecha;
      private System.Windows.Forms.Label lblEVEN_Cumplida;
      private Controls.Tipos.ComboBoxConstantes CONS_CodMOD;
      private System.Windows.Forms.Label lblCONS_CodMOD;
      private System.Windows.Forms.Label lblEVEN_Usuario;
      private System.Windows.Forms.TextBox EVEN_Usuario;
      private Infrastructure.WinForms.Controls.PanelCaption panelEventoTarea;
      private Dotnetrix.Controls.TabControlEX tabControlEX1;
      private Dotnetrix.Controls.TabPageEX tabPageEX1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
      private System.Windows.Forms.CheckBox CCOT_Roundtrip;
      private System.Windows.Forms.Label lblCCOT_Roundtrip;
      private Infrastructure.WinForms.Controls.TextBoxNumerico CCOT_Temperatura;
      private System.Windows.Forms.Label lblCCOT_Temperatura;
      private System.Windows.Forms.CheckBox CCOT_CargaRefrigerada;
      private System.Windows.Forms.Label lblCCOT_CargaRefrigerada;
      private Controls.Tipos.ComboBoxTipos TIPO_CodImo;
      private System.Windows.Forms.CheckBox CCOT_CargaPeligrosa;
      private System.Windows.Forms.Label lblCCOT_CargaPeligrosa;
      private System.Windows.Forms.Label lblTIPO_CodImo;
      private System.Windows.Forms.Label lblCCOT_ValidezOferta;
      private Infrastructure.WinForms.Controls.TextBoxNumerico CCOT_ValidezOferta;
      private System.Windows.Forms.Label lblCCOT_SobreEstadia;
      private Infrastructure.WinForms.Controls.TextBoxNumerico CCOT_SobreEstadia;
      private System.Windows.Forms.Label lblCCOT_TiempoViaje;
      private Infrastructure.WinForms.Controls.TextBoxNumerico CCOT_TiempoViaje;
      private System.Windows.Forms.Label lblCCOT_Almacenaje;
      private Infrastructure.WinForms.Controls.TextBoxNumerico CCOT_Almacenaje;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox CCOT_Observaciones;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption9;
      private System.Windows.Forms.TableLayoutPanel tableDatosViaje;
      private System.Windows.Forms.Label lblNVIA_FecETDMaster;
      private Infrastructure.WinForms.Controls.MaskDateTime NVIA_FecETDMaster;
      private System.Windows.Forms.Label lblNVIA_FecCutOff;
      private Infrastructure.WinForms.Controls.MaskDateTime NVIA_FecCutOff;
      private System.Windows.Forms.Label lblDOOV_Feeder_IMPO;
      private System.Windows.Forms.TextBox DOOV_Feeder_IMPO;
      private System.Windows.Forms.Label lblNAVE_Nombre;
      private System.Windows.Forms.Label lblNVIA_NroViaje;
      private Infrastructure.WinForms.Controls.TextBoxAyuda NVIA_NroViaje;
      private System.Windows.Forms.Label lblNVIA_FecETA;
      private Infrastructure.WinForms.Controls.MaskDateTime NVIA_FecETA;
      private Infrastructure.WinForms.Controls.MaskDateTime DOOV_FecETDFeeder_IMPO;
      private System.Windows.Forms.Label lblDOOV_FecETDFeeder_IMPO;
      private System.Windows.Forms.Panel panel10;
      private System.Windows.Forms.Button btnAddNaveViaje;
      private System.Windows.Forms.Button btnEditarNaveViaje;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption10;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
      private Controls.Tipos.ComboBoxTipos TIPO_CodDTM;
      private System.Windows.Forms.Label lblTIPO_CodDTM;
      private System.Windows.Forms.Label lblDOOV_HBL;
      private System.Windows.Forms.TextBox DOOV_HBL;
      private System.Windows.Forms.Label lblDOOV_MBL;
      private System.Windows.Forms.TextBox DOOV_MBL;
      private System.Windows.Forms.Label lblDOOV_Cntr;
      private System.Windows.Forms.TextBox DOOV_Cntr;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption12;
      private Dotnetrix.Controls.TabPageEX tabPageEX2;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.TextBox textBox4;
      private System.Windows.Forms.TextBox textBox3;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Label lblDOOV_CodReferencia;
      private Controls.Entidad ENTC_CodShipper;
      private Controls.Entidad ENTC_CodConsignee;
      private Controls.Entidad ENTC_CodNotify;
      private System.Windows.Forms.TextBox DOOV_CodReferencia;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption8;
      private System.Windows.Forms.ToolStrip toolStrip4;
      private System.Windows.Forms.ToolStripButton toolStripButton14;
      private Dotnetrix.Controls.TabPageEX tabPageEX3;
      private Telerik.WinControls.UI.RadGridView grdMatrizDetalle;
      private System.Windows.Forms.ToolStrip toolStrip2;
      private System.Windows.Forms.ToolStripButton toolStripButton4;
      private System.Windows.Forms.ToolStripButton toolStripButton5;
      private System.Windows.Forms.ToolStripButton toolStripButton6;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption17;
      private System.Windows.Forms.ComboBox comboBox1;
      private System.Windows.Forms.Label label36;
      private Infrastructure.WinForms.Controls.TextBoxAyuda textBoxAyuda1;
      private System.Windows.Forms.Label label37;
      private Controls.Entidad entidad1;
      private System.Windows.Forms.TextBox textBox10;
      private System.Windows.Forms.Label label38;
      private System.Windows.Forms.TextBox textBox11;
      private Controls.Tipos.ComboBoxConstantes cmbCONS_CodLNG;
      private System.Windows.Forms.Label lblCONS_CodLNG;
   }
}