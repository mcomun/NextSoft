using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.Collections;

namespace Delfin.Comercial
{
   public partial class COM007MView : Form, ICOM007MView
   {
      AppService.DelfinServiceClient oAppService = new AppService.DelfinServiceClient();

      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public COM007MView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += COM007MView_FormClosed;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;
            btnExportar.Click += btnExportar_Click;

            btnExportar.Enabled = false;
            btnExportar.Visible = false;

            BSItemsFlete = new BindingSource();
            grdItemsFlete.DataSource = BSItemsFlete;
            grdItemsFleteEmbarque.DataSource = BSItemsFlete;

            BSItemsServicio = new BindingSource();
            grdItemsServicio.DataSource = BSItemsServicio;

            BSItemsArchivos = new BindingSource();
            grdItemsArchivos.DataSource = BSItemsArchivos;

            ENTC_CodEjecutivo.AyudaValueChanged += ENTC_CodEjecutivo_AyudaValueChanged;
            ENTC_CodTransportista.AyudaValueChanged += ENTC_CodTransportista_AyudaValueChanged;

            ENTC_CodCliente.AyudaValueChanged += ENTC_CodCliente_AyudaValueChanged;
            txaENTC_CodAgente.AyudaValueChanged += ENTC_CodAgente_AyudaValueChanged;
            cmbCONS_CodRGM.SelectedIndexChanged += cmbCONS_CodRGM_SelectedIndexChanged;
            cmbCONS_CodVia.SelectedIndexChanged += cmbCONS_CodVia_SelectedIndexChanged;
            cmbCONS_CodLNG.SelectedIndexChanged += cmbCONS_CodLNG_SelectedIndexChanged;
            btnNuevoContacto.Click += btnNuevoContacto_Click;
            btnEditarContacto.Click += btnEditarContacto_Click;

            CONT_Numero.AyudaClick += CONT_Numero_AyudaClick;
            CONT_Numero.AyudaClean += CONT_Numero_AyudaClean;
            btnCambiarContrato.Click += btnCambiarContrato_Click;

            CONS_CodFLE.SelectedIndexChanged += CONS_CodFLE_SelectedIndexChanged;

            //TIPO_CodPAIOrigen.SelectedIndexChanged += TIPO_CodPAIOrigen_SelectedIndexChanged;
            //TIPO_CodPAITrasbordo.SelectedIndexChanged += TIPO_CodPAITrasbordo_SelectedIndexChanged;
            //TIPO_CodPAIDestino.SelectedIndexChanged += TIPO_CodPAIDestino_SelectedIndexChanged;

            txaPUER_CodOrigen.SelectedItemChanged += txaPUER_CodOrigen_SelectedItemChanged;
            txaPUER_CodDestino.SelectedItemChanged += txaPUER_CodDestino_SelectedItemChanged;

            grdItemsFlete.CellEndEdit += grdItemsFlete_CellEndEdit;
            grdItemsServicio.CellEndEdit += grdItemsServicio_CellEndEdit;
            grdItemsServicio.CommandCellClick += grdItemsServicio_CommandCellClick;
            grdItemsServicio.CurrentCellChanged += grdItemsServicio_CurrentCellChanged;

            btnAddFlete.Click += btnAddFlete_Click;
            btnDelFlete.Click += btnDelFlete_Click;
            btnAddServicio.Click += btnAddServicio_Click;
            btnDelServicio.Click += btnDelServicio_Click;

            btnAddNaveViaje.Click += btnAddNaveViaje_Click;
            btnEditarNaveViaje.Click += btnEditarNaveViaje_Click;

            BSItemsNovedades = new BindingSource();
            grdItemsNovedades.DataSource = BSItemsNovedades;
            grdItemsNovedades.CommandCellClick += grdItemsNovedades_CommandCellClick;
            btnNuevoNovedad.Click += btnNuevoNovedad_Click;
            btnEnviarNovedad.Click += btnEnviarNovedad_Click;

            BSItemsEventosTareas = new BindingSource();
            grdItemsEventosTareas.DataSource = BSItemsEventosTareas;
            btnNuevoEventoTarea.Click += btnNuevoEventoTarea_Click;
            btnEditarEventoTarea.Click += btnEditarEventoTarea_Click;
            btnEliminarEventoTarea.Click += btnEliminarEventoTarea_Click;
            btnGuardarEventoTarea.Click += btnGuardarEventoTarea_Click;
            btnDeshacerEventoTarea.Click += btnDeshacerEventoTarea_Click;
            grdItemsEventosTareas.CurrentRowChanged += grdItemsEventosTareas_CurrentRowChanged;
            grdItemsEventosTareas.CommandCellClick += grdItemsEventosTareas_CommandCellClick;

            ENTC_CodConsignee.AyudaValueChanged += ENTC_CodConsignee_AyudaValueChanged;
            cmbTIPO_CodTRF.SelectedIndexChanged += cmbTIPO_CodTRF_SelectedIndexChanged;

            CCOT_FecEmi.SelectedDateChanged += CCOT_FecEmi_SelectedDateChanged;

            chkCCOT_CargaPeligrosa.CheckedChanged += chkCCOT_CargaPeligrosa_CheckedChanged;

            this.Load += COM007MView_Load;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      private void COM007MView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }

      private void COM007MView_Load(object sender, EventArgs e)
      {
         tabCab_Cotizacion_OV.TabPages.Clear();

         tabCab_Cotizacion_OV.TabPages.Add(pageGenerales);
         tabCab_Cotizacion_OV.TabPages.Add(pageServiciosTarifa);
         tabCab_Cotizacion_OV.TabPages.Add(pageEmbarque);
         tabCab_Cotizacion_OV.TabPages.Add(pageObservaciones);
         if (Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
         {
            tabCab_Cotizacion_OV.TabPages.Add(pageNovedades);
            tabCab_Cotizacion_OV.TabPages.Add(pageArchivos);
            tabCab_Cotizacion_OV.TabPages.Add(pageEventosTareas);
         }

         tabCab_Cotizacion_OV.SelectedTab = pageGenerales;

         //grdItemsFlete.Enabled = true;
         //grdItemsServicio.Enabled = true;
         if (Presenter.Item.CONS_CodEST == "006" | Presenter.Item.CONS_CodEST == "007")
          {
              //grdItemsFlete.Enabled = false;
              //grdItemsServicio.Enabled = false;
              btnAddFlete.Enabled = false;
              btnDelFlete.Enabled = false;
          }
         

      }
      #endregion

      #region [ Propiedades ]
      public COM007Presenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }

      public BindingSource BSItemsFlete { get; set; }
      public BindingSource BSItemsServicio { get; set; }

      public BindingSource BSItemsNovedades { get; set; }
      public BindingSource BSItemsArchivos { get; set; }
      #endregion

      #region [ ICOM007MView ]
      public void LoadView(Int16 CCOT_Tipo)
      {
         try
         {

            txaENTC_CodAgente.ContainerService = Presenter.ContainerService;
            ENTC_CodBroker.ContainerService = Presenter.ContainerService;
            ENTC_CodCliente.ContainerService = Presenter.ContainerService;
            ENTC_CodConsignee.ContainerService = Presenter.ContainerService;
            ENTC_CodCustomer.ContainerService = Presenter.ContainerService;
            ENTC_CodEjecutivo.ContainerService = Presenter.ContainerService;
            ENTC_CodNotify.ContainerService = Presenter.ContainerService;
            ENTC_CodTransportista.ContainerService = Presenter.ContainerService;
            ENTC_CodShipper.ContainerService = Presenter.ContainerService;

            if (CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion)
            {
               this.Text = "Comercial - Cotización";
               this.Icon = Comercial.Properties.Resources.ico_cotizacion;


               //tabCab_Cotizacion_OV.TabPages.Remove(pageNovedades);
               //tabCab_Cotizacion_OV.TabPages.Remove(pageArchivos);

               tableDatosGenerales.RowStyles[1].Height = 0;
               lblCCOT_NumDocOV.Visible = false;
               CCOT_NumDocOV.Visible = false;
               lblCCOT_NumDocCOT2.Visible = false;
               CCOT_NumDocCOT2.Visible = false;
               lblCONS_CodESTOV.Visible = false;
               CONS_CodESTOV.Visible = false;

               lblDDOV_FecEmbarque.Visible = false;
               mdtDDOV_FecEmbarque.Visible = false;
            }
            else
            {
               this.Text = "Comercial - Orden de Venta";
               this.Icon = Comercial.Properties.Resources.ico_ordenventa;

               tableDatosGenerales.RowStyles[0].Height = 0;
               lblCCOT_NumDocCOT.Visible = false;
               CCOT_NumDocCOT.Visible = false;
               lblCCOT_Version.Visible = false;
               CCOT_Version.Visible = false;
               lblCONS_CodESTCOT.Visible = false;
               CONS_CodESTCOT.Visible = false;

               lblDDOV_FecEmbarque.Visible = true;
               mdtDDOV_FecEmbarque.Visible = true;

            }

            CONS_CodESTCOT.LoadControl(Presenter.ContainerService, "Estados Cotización", "COT", "< Seleccionar Estado >", ListSortDirection.Ascending);
            CONS_CodESTOV.LoadControl(Presenter.ContainerService, "Estados Orden Venta", "OVE", "< Seleccionar Estado >", ListSortDirection.Ascending);
            cmbCONS_CodLNG.LoadControl(Presenter.ContainerService, "Líneas de Negocio", "LNG", "< Seleccionar Línea Negocio >", ListSortDirection.Ascending);
            ENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            cmbCONS_CodVia.LoadControl(Presenter.ContainerService, "Tabla Vía", "VIA", "< Seleccionar Vía >", ListSortDirection.Ascending);
            cmbCONS_CodRGM.LoadControl(Presenter.ContainerService, "Tabla Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);
            txaENTC_CodAgente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente;
            ENTC_CodBroker.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Broker;
            ENTC_CodEjecutivo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;
            ENTC_CodCustomer.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Customer;
            TIPO_CodINC.LoadControl(Presenter.ContainerService, "Tabla Incoterm", "INC", "< Seleccionar Incoterm >", ListSortDirection.Ascending);

            ENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            CONS_CodTFT.LoadControl(Presenter.ContainerService, "Tipos Fecha Tarifa", "TFT", "< Seleccionar Fecha Tarifa >", ListSortDirection.Ascending);

            //TIPO_CodPAIOrigen.LoadControl(Presenter.ContainerService, "Tabla Países Origen", "PAI", "< Seleccionar País Origen >", ListSortDirection.Ascending);
            //TIPO_CodPAITrasbordo.LoadControl(Presenter.ContainerService, "Tabla Países Trasbordo", "PAI", "< Seleccionar País Trasbordo >", ListSortDirection.Ascending);
            //TIPO_CodPAIDestino.LoadControl(Presenter.ContainerService, "Tabla Países Destino", "PAI", "< Seleccionar País Origen >", ListSortDirection.Ascending);
            txaPUER_CodOrigen.LoadControl(Presenter.ContainerService, "Ayuda Puerto Origen");
            txaPUER_CodDestino.LoadControl(Presenter.ContainerService, "Ayuda Puerto Origen");
            txaPUER_CodTrasbordo.LoadControl(Presenter.ContainerService, "Ayuda Puerto Origen");

            cmbTIPO_CodTRF.LoadControl(Presenter.ContainerService, "Tabla Tráficos", "TRF", "< Seleccionar Tráfico >", ListSortDirection.Ascending);

            TIPO_CodMND.LoadControl(Presenter.ContainerService, "Tabla Monedas", "MND", "< Seleccionar Moneda >", ListSortDirection.Ascending);
            CONS_CodFLE.LoadControl(Presenter.ContainerService, "Tabla Condición", "FLE", "< Seleccionar Condición >", ListSortDirection.Ascending);
            CCOT_PagoMBL.AddComboBoxItem("P", "Prepaid", true);
            CCOT_PagoMBL.AddComboBoxItem("C", "Collect");
            CCOT_PagoMBL.LoadComboBox("<Seleccionar P/C (MBL)>");
            CCOT_PagoHBL.AddComboBoxItem("P", "Prepaid", true);
            CCOT_PagoHBL.AddComboBoxItem("C", "Collect");
            CCOT_PagoHBL.LoadComboBox("<Seleccionar P/C (HBL)>");

            cmbTIPO_CodImo.LoadControl(Presenter.ContainerService, "Tabla IMO Class", "IMO", "< Seleccionar IMO Class >", ListSortDirection.Ascending);

            ENTC_CodShipper.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Shipper;
            ENTC_CodNotify.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            ENTC_CodConsignee.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;

            //PUER_CodOrigen.DataSource = null;
            //PUER_CodOrigen.Enabled = false;

            //PUER_CodDestino.DataSource = null;
            //PUER_CodDestino.Enabled = false;

            FormatGridFlete();
            FormatGridFleteEmbarque();
            FormatGridServicios();

            if (CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
            {
               txaENTC_CodDepTemporal.ContainerService = Presenter.ContainerService;
               txaENTC_CodDepTemporal.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_DepositoTemporal;
               //TIPO_CodDTM.LoadControl(Presenter.ContainerService, "Tabla Deposito", "DTM", "< Seleccionar Depósito >", ListSortDirection.Ascending);
               CONS_CodNot.LoadControl(Presenter.ContainerService, "Tipos de Novedad", "NOT", "< Seleccionar Notificación >", ListSortDirection.Ascending);

               CONS_CodMOD.LoadControl(Presenter.ContainerService, "Constantes Modulos", "MOD", "< Seleccionar Modulo >", ListSortDirection.Ascending);
               TIPO_CodEVE.LoadControl(Presenter.ContainerService, "Tipos Eventos/Tarea", "EVE", "< Seleccionar Evento/Tarea >", ListSortDirection.Ascending);

               FormatGridNovedades();
               FormatGridArchivos();
               FormatGridEventoTarea();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      public void ClearItem()
      {
         try
         {
            errorProviderCab_Cotizacion_OV.Clear();

            #region [ Datos Generales ]
            CCOT_NumDocCOT.Text = String.Empty;
            CCOT_Version.Text = String.Empty;
            //CONS_TabEST
            CONS_CodESTCOT.ConstantesSelectedValue = null;
            ENTC_CodCliente.ClearValue();
            CCOT_FecEmi.NSFecha = null;
            //CONS_TabRGM
            cmbCONS_CodRGM.ConstantesSelectedValue = null;
            //CONS_TabVia
            cmbCONS_CodVia.ConstantesSelectedValue = null;
            CCOT_FecVcto.NSFecha = null;
            txaENTC_CodAgente.ClearValue();
            CCOT_FecAprueba.NSFecha = null;
            mdtDDOV_FecEmbarque.NSFecha = null;
            //CCOT_UsrAprueba
            ENTC_CodBroker.ClearValue();
            CCOT_Propia.Checked = false;
            ENTC_CodEjecutivo.ClearValue();
            CCOT_ServicioLogistico.Checked = false;
            CCOT_VoBo_GateIn.Checked = false;
            ENTC_CodCustomer.ClearValue();
            //TIPO_TabINC
            TIPO_CodINC.TiposSelectedValue = null;

            chkCCOT_ServioTransmision.Checked = false;
            chkCCOT_EnviaAvisoLlegada.Checked = false;

            ENTC_Contacto.Text = string.Empty;
            ENTC_EMail.Text = string.Empty;
            ENTC_Cargo.Text = string.Empty;
            #endregion

            #region [ Servicios y Tarifa ]
            //CONT_Numero.Text = string.Empty;
            //CONT_Descrip.Text = string.Empty;
            CONT_Numero.ClearValue();
            CONT_Numero.AyudaButton.Visible = true;
            CONT_Numero.Width = 194;
            btnCambiarContrato.Visible = false;
            //ClearItemContrato();

            ENTC_CodTransportista.ClearValue();
            //CONS_TabTFT
            CONS_CodTFT.ConstantesSelectedValue = null;

            //TIPO_TabPAIOrigen
            //TIPO_CodPAIOrigen.TiposSelectedValue = null;
            //PUER_CodOrigen
            //TIPO_TabPAITrasbordo
            //TIPO_CodPAITrasbordo.TiposSelectedValue = null;
            //PUER_CodTrasbordo
            //TIPO_TabPAIDestino
            //TIPO_CodPAIDestino.TiposSelectedValue = null;
            //PUER_CodDestino

            txaPUER_CodOrigen.Clear();
            txaPUER_CodDestino.Clear();
            txaPUER_CodTrasbordo.Clear();

            cmbTIPO_CodTRF.TiposSelectedValue = null;

            CCOT_FecTarifa.NSFecha = null;

            //TIPO_TabMND
            TIPO_CodMND.TiposSelectedValue = null;
            //CONS_TabFLE
            CONS_CodFLE.ConstantesSelectedValue = null;
            CCOT_PagoMBL.ComboStrSelectedValue = null;
            CCOT_PagoHBL.ComboStrSelectedValue = null;
            DCOT_Importe.Text = "0.00";
            DCOT_Rentabilidad.Text = "0.00";

            BSItemsFlete.DataSource = null;
            BSItemsFlete.ResetBindings(true);

            BSItemsServicio.DataSource = null;
            BSItemsServicio.ResetBindings(true);
            #endregion

            #region [ Datos Embarque ]
            CCOT_CargaRefrigerada.Checked = false;
            CCOT_Roundtrip.Checked = false;
            chkCCOT_CargaPeligrosa.Checked = false;
            CCOT_Temperatura.Text = "0.00";
            //TIPO_TabImo
            cmbTIPO_CodImo.TiposSelectedValue = null;
            txtCCOT_ImoUN.Text = String.Empty;
            cmbTIPO_CodImo.Enabled = chkCCOT_CargaPeligrosa.Checked;
            txtCCOT_ImoUN.Enabled = chkCCOT_CargaPeligrosa.Checked;

            ENTC_CodShipper.ClearValue();
            ENTC_CodConsignee.ClearValue();
            ENTC_CodNotify.ClearValue();

            DOOV_CodReferencia.Text = null;
            #endregion

            #region [ Observaciones ]
            CCOT_Almacenaje.Text = "0";
            CCOT_SobreEstadia.Text = "0";
            CCOT_TiempoViaje.Text = "0";
            CCOT_ValidezOferta.Text = "0";
            CCOT_Observaciones.Text = string.Empty;
            #endregion

            #region [ Adicionales Orden Venta ]
            if (Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
            {
               #region [ Documentos ]
               DOOV_Cntr.Text = null;
               DOOV_HBL.Text = null;
               DOOV_MBL.Text = null;
               txtDDOV_NroBooking.Text = null;
               //TIPO_CodDTM.TiposSelectedValue = null;
               txaENTC_CodDepTemporal.ClearValue();
               chkDDOV_HBLNieto.Checked = false;
               #endregion

               #region [ Viaje ]
               DOOV_Feeder_IMPO.Text = String.Empty;
               DOOV_FecETDFeeder_IMPO.NSFecha = null;
               ClearItemViaje();
               #endregion

               #region [ Novedades ]
               ClearItemNovedad();

               BSItemsNovedades.DataSource = null;
               BSItemsNovedades.ResetBindings(true);
               #endregion

               #region [ Archivos ]
               OVAR_Archivo.Text = string.Empty;

               BSItemsArchivos.DataSource = null;
               BSItemsArchivos.ResetBindings(true);
               #endregion

               #region [ Eventos/Tareas ]
               BSItemsEventosTareas.DataSource = null;
               BSItemsEventosTareas.ResetBindings(true);

               ClearItemEventoTarea();
               InstanceItemEventoTarea(false, false);
               #endregion
            }
            #endregion

            cmbCONS_CodLNG.ConstantesSelectedValue = null;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ClearItem.", ex); }
      }
      public void GetItem()
      {
         try
         {
            errorProviderCab_Cotizacion_OV.Clear();

            #region [ Datos Generales ]



            if (Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion)
            {
               Presenter.Item.CCOT_NumDoc = CCOT_NumDocCOT.Text;

               Int16 _CCOT_Version;
               if (Int16.TryParse(CCOT_Version.Text, out _CCOT_Version))
               { Presenter.Item.CCOT_Version = _CCOT_Version; }
               else
               { Presenter.Item.CCOT_Version = null; }

               if (CONS_CodESTCOT.ConstantesSelectedItem != null)
               {
                  Presenter.Item.CONS_TabEST = CONS_CodESTCOT.ConstantesSelectedItem.CONS_CodTabla;
                  Presenter.Item.CONS_CodEST = CONS_CodESTCOT.ConstantesSelectedItem.CONS_CodTipo;
               }
               else
               {
                  Presenter.Item.CONS_TabEST = null;
                  Presenter.Item.CONS_CodEST = null;
               }
            }
            else if (Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
            {

               Presenter.Item.CCOT_NumDoc = CCOT_NumDocOV.Text;
               Presenter.Item.CCOT_NumDocCOT = CCOT_NumDocCOT2.Text;

               if (CONS_CodESTOV.ConstantesSelectedItem != null)
               {
                  Presenter.Item.CONS_TabEST = CONS_CodESTOV.ConstantesSelectedItem.CONS_CodTabla;
                  Presenter.Item.CONS_CodEST = CONS_CodESTOV.ConstantesSelectedItem.CONS_CodTipo;
               }
               else
               {
                  Presenter.Item.CONS_TabEST = null;
                  Presenter.Item.CONS_CodEST = null;
               }
            }



            if (ENTC_CodCliente.Value != null)
            { Presenter.Item.ENTC_CodCliente = ENTC_CodCliente.Value.ENTC_Codigo; }
            else
            { Presenter.Item.ENTC_CodCliente = null; }
            Presenter.Item.CCOT_FecEmi = CCOT_FecEmi.NSFecha;
            if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TabRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TabRGM = null;
               Presenter.Item.CONS_CodRGM = null;
            }
            if (cmbCONS_CodVia.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TabVia = cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodVia = cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TabVia = null;
               Presenter.Item.CONS_CodVia = null;
            }
            Presenter.Item.CCOT_FecVcto = CCOT_FecVcto.NSFecha;
            if (txaENTC_CodAgente.Value != null)
            { Presenter.Item.ENTC_CodAgente = txaENTC_CodAgente.Value.ENTC_Codigo; }
            else
            { Presenter.Item.ENTC_CodAgente = null; }
            Presenter.Item.CCOT_FecAprueba = CCOT_FecAprueba.NSFecha;
            Presenter.Item.DDOV_FecEmbarque = mdtDDOV_FecEmbarque.NSFecha;
            //Presenter.Item.CCOT_UsrAprueba = CCOT_UsrAprueba.Text
            if (ENTC_CodBroker.Value != null)
            { Presenter.Item.ENTC_CodBroker = ENTC_CodBroker.Value.ENTC_Codigo; }
            else
            { Presenter.Item.ENTC_CodBroker = null; }
            Presenter.Item.CCOT_Propia = CCOT_Propia.Checked;
            if (ENTC_CodEjecutivo.Value != null)
            { Presenter.Item.ENTC_CodEjecutivo = ENTC_CodEjecutivo.Value.ENTC_Codigo; }
            else
            { Presenter.Item.ENTC_CodEjecutivo = null; }
            Presenter.Item.CCOT_ServicioLogistico = CCOT_ServicioLogistico.Checked;
            Presenter.Item.CCOT_VoBoGateIn = CCOT_VoBo_GateIn.Checked;
            if (ENTC_CodCustomer.Value != null)
            { Presenter.Item.ENTC_CodCustomer = ENTC_CodCustomer.Value.ENTC_Codigo; }
            else
            { Presenter.Item.ENTC_CodCustomer = null; }
            if (TIPO_CodINC.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabINC = TIPO_CodINC.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodINC = TIPO_CodINC.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabINC = null;
               Presenter.Item.TIPO_CodINC = null;
            }

            Presenter.Item.CCOT_ServicioTransmision = chkCCOT_ServioTransmision.Checked;
            Presenter.Item.CCOT_EnviaAvisoLlegada = chkCCOT_EnviaAvisoLlegada.Checked;
            #endregion

            #region [ Servicios y Tarifa ]
            if (CONT_Numero.Value != null && CONT_Numero.Value is Entities.Contrato)
            { Presenter.Item.CONT_Codigo = ((Entities.Contrato)CONT_Numero.Value).CONT_Codigo; }
            else
            { Presenter.Item.CONT_Codigo = null; }
            //Presenter.Item.CONT_Numero
            //Presenter.Item.CONT_Descrip
            if (ENTC_CodTransportista.Value != null)
            { Presenter.Item.ENTC_CodTransportista = ENTC_CodTransportista.Value.ENTC_Codigo; }
            else
            { Presenter.Item.ENTC_CodTransportista = null; }
            if (CONS_CodTFT.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TabTFT = CONS_CodTFT.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodTFT = CONS_CodTFT.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TabTFT = null;
               Presenter.Item.CONS_CodTFT = null;
            }

            //if (TIPO_CodPAIOrigen.TiposSelectedItem != null)
            //{
            //   Presenter.Item.TIPO_TabPAIOrigen = TIPO_CodPAIOrigen.TiposSelectedItem.TIPO_CodTabla;
            //   Presenter.Item.TIPO_CodPAIOrigen = TIPO_CodPAIOrigen.TiposSelectedItem.TIPO_CodTipo;
            //}
            //else
            //{
            //   Presenter.Item.TIPO_TabPAIOrigen = null;
            //   Presenter.Item.TIPO_CodPAIOrigen = null;
            //}
            //Presenter.Item.PUER_CodOrigen = PUER_CodOrigen.ComboIntSelectedValue;
            //if (TIPO_CodPAITrasbordo.TiposSelectedItem != null)
            //{
            //   Presenter.Item.TIPO_TabPAITrasbordo = TIPO_CodPAITrasbordo.TiposSelectedItem.TIPO_CodTabla;
            //   Presenter.Item.TIPO_CodPAITrasbordo = TIPO_CodPAITrasbordo.TiposSelectedItem.TIPO_CodTipo;
            //}
            //else
            //{
            //   Presenter.Item.TIPO_TabPAITrasbordo = null;
            //   Presenter.Item.TIPO_CodPAITrasbordo = null;
            //}
            //Presenter.Item.PUER_CodTrasbordo = PUER_CodTrasbordo.ComboIntSelectedValue;
            //if (TIPO_CodPAIDestino.TiposSelectedItem != null)
            //{
            //   Presenter.Item.TIPO_TabPAIDestino = TIPO_CodPAIDestino.TiposSelectedItem.TIPO_CodTabla;
            //   Presenter.Item.TIPO_CodPAIDestino = TIPO_CodPAIDestino.TiposSelectedItem.TIPO_CodTipo;
            //}
            //else
            //{
            //   Presenter.Item.TIPO_TabPAIDestino = null;
            //   Presenter.Item.TIPO_CodPAIDestino = null;
            //}
            //Presenter.Item.PUER_CodDestino = PUER_CodDestino.ComboIntSelectedValue;

            if (txaPUER_CodOrigen.SelectedItem != null)
            {
               Presenter.Item.TIPO_TabPAIOrigen = txaPUER_CodOrigen.SelectedItem.TIPO_TabPais;
               Presenter.Item.TIPO_CodPAIOrigen = txaPUER_CodOrigen.SelectedItem.TIPO_CodPais;
               Presenter.Item.PUER_CodOrigen = txaPUER_CodOrigen.SelectedItem.PUER_Codigo;
            }
            else
            {
               Presenter.Item.TIPO_TabPAIOrigen = null;
               Presenter.Item.TIPO_CodPAIOrigen = null;
               Presenter.Item.PUER_CodOrigen = null;
            }
            if (txaPUER_CodDestino.SelectedItem != null)
            {
               Presenter.Item.TIPO_TabPAIDestino = txaPUER_CodDestino.SelectedItem.TIPO_TabPais;
               Presenter.Item.TIPO_CodPAIDestino = txaPUER_CodDestino.SelectedItem.TIPO_CodPais;
               Presenter.Item.PUER_CodDestino = txaPUER_CodDestino.SelectedItem.PUER_Codigo;
            }
            else
            {
               Presenter.Item.TIPO_TabPAIDestino = null;
               Presenter.Item.TIPO_CodPAIDestino = null;
               Presenter.Item.PUER_CodDestino = null;
            }
            if (txaPUER_CodTrasbordo.SelectedItem != null)
            {
               Presenter.Item.TIPO_TabPAITrasbordo = txaPUER_CodTrasbordo.SelectedItem.TIPO_TabPais;
               Presenter.Item.TIPO_CodPAITrasbordo = txaPUER_CodTrasbordo.SelectedItem.TIPO_CodPais;
               Presenter.Item.PUER_CodTrasbordo = txaPUER_CodTrasbordo.SelectedItem.PUER_Codigo;
            }
            else
            {
               Presenter.Item.TIPO_TabPAITrasbordo = null;
               Presenter.Item.TIPO_CodPAITrasbordo = null;
               Presenter.Item.PUER_CodTrasbordo = null;
            }

            if (cmbTIPO_CodTRF.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabTRF = cmbTIPO_CodTRF.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodTRF = cmbTIPO_CodTRF.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabTRF = null;
               Presenter.Item.TIPO_CodTRF = null;
            }

            Presenter.Item.CCOT_FecTarifa = CCOT_FecTarifa.NSFecha;

            if (TIPO_CodMND.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabMND = TIPO_CodMND.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodMND = TIPO_CodMND.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabMND = null;
               Presenter.Item.TIPO_CodMND = null;
            }
            if (CONS_CodFLE.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TabFLE = CONS_CodFLE.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodFLE = CONS_CodFLE.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TabFLE = null;
               Presenter.Item.CONS_CodFLE = null;
            }
            Presenter.Item.CCOT_PagoMBL = CCOT_PagoMBL.ComboStrSelectedValue;
            Presenter.Item.CCOT_PagoHBL = CCOT_PagoHBL.ComboStrSelectedValue;
            //Presenter.Item.DCOT_Importe
            //Presenter.Item.DCOT_Rentabilidad


            Presenter.Item.ItemsFlete = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource);
            Presenter.Item.ItemsServicio = ((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicio.DataSource);

            #endregion

            #region [ Datos Embarque ]
            Presenter.Item.CCOT_CargaRefrigerada = CCOT_CargaRefrigerada.Checked;
            Presenter.Item.CCOT_Roundtrip = CCOT_Roundtrip.Checked;
            Presenter.Item.CCOT_CargaPeligrosa = chkCCOT_CargaPeligrosa.Checked;
            Presenter.Item.CCOT_Temperatura = CCOT_Temperatura.Value;
            if (cmbTIPO_CodImo.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabImo = cmbTIPO_CodImo.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodImo = cmbTIPO_CodImo.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabImo = null;
               Presenter.Item.TIPO_CodImo = null;
            }
            Presenter.Item.CCOT_ImoUN = txtCCOT_ImoUN.Text;

            if (ENTC_CodShipper.Value != null)
            { Presenter.Item.ENTC_CodShipper = ENTC_CodShipper.Value.ENTC_Codigo; }
            else
            { Presenter.Item.ENTC_CodShipper = null; }
            if (ENTC_CodConsignee.Value != null)
            { Presenter.Item.ENTC_CodConsignee = ENTC_CodConsignee.Value.ENTC_Codigo; }
            else
            { Presenter.Item.ENTC_CodConsignee = null; }
            if (ENTC_CodNotify.Value != null)
            { Presenter.Item.ENTC_CodNotify = ENTC_CodNotify.Value.ENTC_Codigo; }
            else
            { Presenter.Item.ENTC_CodNotify = null; }

            Presenter.Item.DOOV_CodReferencia = DOOV_CodReferencia.Text;
            #endregion

            #region [ Observaciones ]
            Presenter.Item.CCOT_Almacenaje = Convert.ToInt16(CCOT_Almacenaje.Value);
            Presenter.Item.CCOT_SobreEstadia = Convert.ToInt16(CCOT_SobreEstadia.Value);
            Presenter.Item.CCOT_TiempoViaje = Convert.ToInt16(CCOT_TiempoViaje.Value);
            Presenter.Item.CCOT_ValidezOferta = Convert.ToInt16(CCOT_ValidezOferta.Value);
            Presenter.Item.CCOT_Observaciones = CCOT_Observaciones.Text;
            #endregion

            #region [ Adicionales Orden Venta ]
            if (Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
            {
               #region [ Documentos ]
               Presenter.Item.DOOV_Cntr = DOOV_Cntr.Text;
               Presenter.Item.DOOV_HBL = DOOV_HBL.Text;
               Presenter.Item.DOOV_MBL = DOOV_MBL.Text;
               Presenter.Item.DDOV_NroBooking = txtDDOV_NroBooking.Text;
               //if (TIPO_CodDTM.TiposSelectedItem != null)
               //{
               //   Presenter.Item.TIPO_TabDTM = TIPO_CodDTM.TiposSelectedItem.TIPO_CodTabla;
               //   Presenter.Item.TIPO_CodDTM = TIPO_CodDTM.TiposSelectedItem.TIPO_CodTipo;
               //}
               //else
               //{ 
               //   Presenter.Item.TIPO_TabDTM = null;
               //   Presenter.Item.TIPO_CodDTM = null;
               //}
               if (txaENTC_CodDepTemporal.Value != null)
               { Presenter.Item.ENTC_CodDepTemporal = txaENTC_CodDepTemporal.Value.ENTC_Codigo; }
               else
               { Presenter.Item.ENTC_CodDepTemporal = null; }

               Presenter.Item.DDOV_HBLNieto = chkDDOV_HBLNieto.Checked;
               #endregion

               #region [ Viaje ]
               if (cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
               {
                  Presenter.Item.DOOV_Feeder_IMPO = DOOV_Feeder_IMPO.Text;
                  Presenter.Item.DOOV_FecETDFeeder_IMPO = DOOV_FecETDFeeder_IMPO.NSFecha;
               }
               else
               {
                  Presenter.Item.DOOV_Feeder_IMPO = String.Empty;
                  Presenter.Item.DOOV_FecETDFeeder_IMPO = null;
               }

               if (NVIA_NroViaje.Value != null)
               { Presenter.Item.NVIA_Codigo = ((Entities.NaveViaje)NVIA_NroViaje.Value).NVIA_Codigo; }
               else
               { Presenter.Item.NVIA_Codigo = null; }
               #endregion

               #region [ Novedades ]
               Presenter.Item.ItemsNovedad = ((ObservableCollection<Entities.Det_Cotizacion_OV_Novedad>)BSItemsNovedades.DataSource);
               #endregion

               #region [ Archivos ]
               Presenter.Item.ItemsArchivo = ((ObservableCollection<Entities.Det_Cotizacion_OV_Archivo>)BSItemsArchivos.DataSource);
               #endregion

               #region [ Eventos/Tareas ]
               Presenter.Item.ItemsEventosTareas = ((ObservableCollection<Entities.Det_Cotizacion_OV_EventosTareas>)BSItemsEventosTareas.DataSource);
               #endregion
            }
            #endregion

            if (cmbCONS_CodLNG.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TabLNG = cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodLNG = cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TabLNG = null;
               Presenter.Item.CONS_CodLNG = null;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en GetItem.", ex); }
      }
      public void SetItem()
      {
         try
         {
            #region [ Servicios y Tarifa ]
            //if (Presenter.Item.CONT_Codigo.HasValue)
            //{ 
            //   CONT_Numero.SetValue(Presenter.Item.ItemContrato, Presenter.Item.CONT_Numero);
            //   CONT_Numero.Text = Presenter.Item.CONT_Numero;
            //   CONT_Descrip.Text = Presenter.Item.CONT_Descrip;
            //}

            //TIPO_CodPAIOrigen.TiposSelectedValue = Presenter.Item.TIPO_CodPAIOrigen;
            //if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodPAIOrigen) && Presenter.Item.PUER_CodOrigen.HasValue) { PUER_CodOrigen.ComboIntSelectedValue = Presenter.Item.PUER_CodOrigen.Value; };
            //TIPO_CodPAITrasbordo.TiposSelectedValue = Presenter.Item.TIPO_CodPAITrasbordo;
            //if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodPAITrasbordo) && Presenter.Item.PUER_CodTrasbordo.HasValue) { PUER_CodTrasbordo.ComboIntSelectedValue = Presenter.Item.PUER_CodTrasbordo.Value; }
            //TIPO_CodPAIDestino.TiposSelectedValue = Presenter.Item.TIPO_CodPAIDestino;
            //if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodPAIDestino) && Presenter.Item.PUER_CodDestino.HasValue) { PUER_CodDestino.ComboIntSelectedValue = Presenter.Item.PUER_CodDestino.Value; }

            TIPO_CodMND.TiposSelectedValue = Presenter.Item.TIPO_CodMND;
            CONS_CodFLE.ConstantesSelectedValue = Presenter.Item.CONS_CodFLE;
            CCOT_PagoMBL.ComboStrSelectedValue = Presenter.Item.CCOT_PagoMBL;
            CCOT_PagoHBL.ComboStrSelectedValue = Presenter.Item.CCOT_PagoHBL;

            foreach (Entities.Det_Cotizacion_OV_Flete _itemFLETE in Presenter.Item.ItemsFlete)
            {
               _itemFLETE.ListPaquete = Presenter.ListPaquetes;
               _itemFLETE.ItemPaquete = Presenter.ListPaquetes.Where(dcot => dcot.PACK_Codigo == _itemFLETE.PACK_Codigo).FirstOrDefault();
            }

            BSItemsFlete.DataSource = Presenter.Item.ItemsFlete;
            BSItemsFlete.ResetBindings(true);

            CalcularTotalesFlete();
            #endregion

            #region [ Datos Generales ]
            if (Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion)
            {
               CCOT_NumDocCOT.Text = Presenter.Item.CCOT_NumDoc;
               CCOT_Version.Text = Presenter.Item.CCOT_Version.ToString();
               CONS_CodESTCOT.ConstantesSelectedValue = Presenter.Item.CONS_CodEST;
            }
            else if (Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
            {
               CCOT_NumDocOV.Text = Presenter.Item.CCOT_NumDoc;
               CCOT_NumDocCOT2.Text = Presenter.Item.CCOT_NumDocCOT;
               CONS_CodESTOV.ConstantesSelectedValue = Presenter.Item.CONS_CodEST;
            }

            cmbCONS_CodRGM.ConstantesSelectedValue = Presenter.Item.CONS_CodRGM;
            cmbCONS_CodVia.ConstantesSelectedValue = Presenter.Item.CONS_CodVia;

            txaPUER_CodOrigen.SelectedValue = Presenter.Item.PUER_CodOrigen;
            txaPUER_CodDestino.SelectedValue = Presenter.Item.PUER_CodDestino;
            txaPUER_CodTrasbordo.SelectedValue = Presenter.Item.PUER_CodTrasbordo;

            if (Presenter.Item.ENTC_CodTransportista.HasValue) { ENTC_CodTransportista.SetValue(Presenter.Item.ENTC_CodTransportista.Value); }

            CONS_CodTFT.ConstantesSelectedValue = Presenter.Item.CONS_CodTFT;
            CCOT_FecTarifa.NSFecha = Presenter.Item.CCOT_FecTarifa;

            SetItemContrato(false);
            TIPO_CodMND.TiposSelectedValue = Presenter.Item.TIPO_CodMND;


            if (!String.IsNullOrEmpty(Presenter.Item.TIPO_TabTRF) && !String.IsNullOrEmpty(Presenter.Item.TIPO_CodTRF))
            { cmbTIPO_CodTRF.TiposSelectedValue = Presenter.Item.TIPO_CodTRF; }
            else
            { cmbTIPO_CodTRF.TiposSelectedValue = null; }

            BSItemsServicio.DataSource = Presenter.Item.ItemsServicio;
            BSItemsServicio.ResetBindings(true);

            if (Presenter.Item.ENTC_CodCliente.HasValue) { ENTC_CodCliente.SetValue(Presenter.Item.ENTC_CodCliente.Value); }
            CCOT_FecEmi.NSFecha = Presenter.Item.CCOT_FecEmi;
            CCOT_FecVcto.NSFecha = Presenter.Item.CCOT_FecVcto;
            if (Presenter.Item.ENTC_CodAgente.HasValue) { txaENTC_CodAgente.SetValue(Presenter.Item.ENTC_CodAgente.Value); }
            CCOT_FecAprueba.NSFecha = Presenter.Item.CCOT_FecAprueba;
            mdtDDOV_FecEmbarque.NSFecha = Presenter.Item.DDOV_FecEmbarque;
            if (Presenter.Item.ENTC_CodBroker.HasValue) { ENTC_CodBroker.SetValue(Presenter.Item.ENTC_CodBroker.Value); }
            CCOT_Propia.Checked = Presenter.Item.CCOT_Propia;
            if (Presenter.Item.ENTC_CodEjecutivo.HasValue) { ENTC_CodEjecutivo.SetValue(Presenter.Item.ENTC_CodEjecutivo.Value); }
            CCOT_ServicioLogistico.Checked = Presenter.Item.CCOT_ServicioLogistico;
            CCOT_VoBo_GateIn.Checked = Presenter.Item.CCOT_VoBoGateIn;
            if (Presenter.Item.ENTC_CodCustomer.HasValue) { ENTC_CodCustomer.SetValue(Presenter.Item.ENTC_CodCustomer.Value); }
            TIPO_CodINC.TiposSelectedValue = Presenter.Item.TIPO_CodINC;

            chkCCOT_ServioTransmision.Checked = Presenter.Item.CCOT_ServicioTransmision;
            chkCCOT_EnviaAvisoLlegada.Checked = Presenter.Item.CCOT_EnviaAvisoLlegada;
            CCOT_VoBo_GateIn.Checked = Presenter.Item.CCOT_VoBoGateIn;

            #endregion

            #region [ Datos Embarque ]
            CCOT_CargaRefrigerada.Checked = Presenter.Item.CCOT_CargaRefrigerada;
            CCOT_Roundtrip.Checked = Presenter.Item.CCOT_Roundtrip;
            chkCCOT_CargaPeligrosa.Checked = Presenter.Item.CCOT_CargaPeligrosa;
            if (Presenter.Item.CCOT_Temperatura.HasValue) { CCOT_Temperatura.Text = Presenter.Item.CCOT_Temperatura.Value.ToString(); }
            cmbTIPO_CodImo.TiposSelectedValue = Presenter.Item.TIPO_CodImo;
            txtCCOT_ImoUN.Text = Presenter.Item.CCOT_ImoUN;
            if (Presenter.Item.ENTC_CodShipper.HasValue) { ENTC_CodShipper.SetValue(Presenter.Item.ENTC_CodShipper.Value); }
            if (Presenter.Item.ENTC_CodConsignee.HasValue) { ENTC_CodConsignee.SetValue(Presenter.Item.ENTC_CodConsignee.Value); }
            if (Presenter.Item.ENTC_CodNotify.HasValue) { ENTC_CodNotify.SetValue(Presenter.Item.ENTC_CodNotify.Value); }
            DOOV_CodReferencia.Text = Presenter.Item.DOOV_CodReferencia;
            #endregion

            #region [ Observaciones ]
            CCOT_Almacenaje.Text = Presenter.Item.CCOT_Almacenaje.ToString();
            CCOT_SobreEstadia.Text = Presenter.Item.CCOT_SobreEstadia.ToString();
            CCOT_TiempoViaje.Text = Presenter.Item.CCOT_TiempoViaje.ToString();
            CCOT_ValidezOferta.Text = Presenter.Item.CCOT_ValidezOferta.ToString();
            CCOT_Observaciones.Text = Presenter.Item.CCOT_Observaciones;
            #endregion

            #region [ Adicionales Orden Venta ]
            if (Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
            {
               #region [ Documentos ]
               DOOV_Cntr.Text = Presenter.Item.DOOV_Cntr;
               DOOV_HBL.Text = Presenter.Item.DOOV_HBL;
               DOOV_MBL.Text = Presenter.Item.DOOV_MBL;
               txtDDOV_NroBooking.Text = Presenter.Item.DDOV_NroBooking;
               //TIPO_CodDTM.TiposSelectedValue = Presenter.Item.TIPO_CodDTM;
               if (Presenter.Item.ENTC_CodDepTemporal.HasValue)
               { txaENTC_CodDepTemporal.SetValue(Presenter.Item.ENTC_CodDepTemporal.Value); }

               chkDDOV_HBLNieto.Checked = Presenter.Item.DDOV_HBLNieto;
               #endregion

               #region [ Viaje ]
               if (cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
               {
                  DOOV_Feeder_IMPO.Text = Presenter.Item.DOOV_Feeder_IMPO;
                  DOOV_FecETDFeeder_IMPO.NSFecha = Presenter.Item.DOOV_FecETDFeeder_IMPO;
               }
               else
               {
                  DOOV_Feeder_IMPO.Text = String.Empty;
                  DOOV_FecETDFeeder_IMPO.NSFecha = null;
               }

               SetItemViaje();
               #endregion

               #region [ Novedades ]
               ShowNovedades();

               //tableNovedad.Enabled = (Presenter.Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added);
               //btnNuevoNovedad.Enabled = (Presenter.Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added);
               //btnEnviarNovedad.Enabled = (Presenter.Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added);
               //grdItemsNovedades.Enabled= (Presenter.Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added);
               #endregion

               #region [ Archivos ]
               BSItemsArchivos.DataSource = Presenter.Item.ItemsArchivo;
               BSItemsArchivos.ResetBindings(true);

               //tableArchivo.Enabled = (Presenter.Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added);
               //btnUploadFile.Enabled = (Presenter.Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added);
               //btnDownloadFile.Enabled = (Presenter.Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added);
               //grdItemsArchivos.Enabled = (Presenter.Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added);
               #endregion

               #region [ Eventos/Tareas ]
               BSItemsEventosTareas.DataSource = Presenter.Item.ItemsEventosTareas;
               BSItemsEventosTareas.ResetBindings(true);
               SeleccionarEventoTarea();
               InstanceItemEventoTarea(false, false);
               #endregion
            }
            #endregion

            if (!String.IsNullOrEmpty(Presenter.Item.CONS_TabLNG) && !String.IsNullOrEmpty(Presenter.Item.CONS_CodLNG))
            { cmbCONS_CodLNG.ConstantesSelectedValue = Presenter.Item.CONS_CodLNG; }
            else
            { cmbCONS_CodLNG.ConstantesSelectedValue = null; EstablecerLineaNegocio(); }

            EnabledItem();

            tabCab_Cotizacion_OV.SelectedTab = pageGenerales;

            #region [ Bloqueo Grilla ]

            if (Presenter.Item.CONS_CodEST.Equals("006") | Presenter.Item.CONS_CodEST.Equals("007"))
            {
                this.grdItemsFlete.Enabled = true;
                this.grdItemsFlete.Columns["DCOT_Item"].ReadOnly = true;
                this.grdItemsFlete.Columns["PACK_Codigo"].ReadOnly = true;
                this.grdItemsFlete.Columns["DCOT_Cantidad"].ReadOnly = true;
                this.grdItemsFlete.Columns["DCOT_PrecioUniCosto"].ReadOnly = true;
                this.grdItemsFlete.Columns["DCOT_PrecioUniVenta"].ReadOnly = true;
                this.grdItemsFlete.Columns["DCOT_TotalUniCosto"].ReadOnly = true;
                this.grdItemsFlete.Columns["DCOT_TotalUniVenta"].ReadOnly = true;

                this.grdItemsServicio.Enabled = true;
                this.grdItemsServicio.Columns["CCOT_IngresoGasto"].ReadOnly = true;
                this.grdItemsServicio.Columns["SERV_Codigo"].ReadOnly = true;
                this.grdItemsServicio.Columns["CONS_CodBas"].ReadOnly = true;
                this.grdItemsServicio.Columns["SCOT_Cantidad"].ReadOnly = true;
                this.grdItemsServicio.Columns["SCOT_Origen"].ReadOnly = true;
                this.grdItemsServicio.Columns["TIPO_CodMnd"].ReadOnly = true;
                this.grdItemsServicio.Columns["SCOT_PrecioUni"].ReadOnly = true;
                this.grdItemsServicio.Columns["TIPE_Codigo"].ReadOnly = true;
                this.grdItemsServicio.Columns["Entidad"].IsVisible = false;
                
                this.grdItemsServicio.Columns["SCOT_SerieTDO"].ReadOnly = false;
                this.grdItemsServicio.Columns["SCOT_NumeroTDO"].ReadOnly = false;
                this.grdItemsServicio.Columns["TipoDocumento"].ReadOnly = false;
                
            }

            #endregion

            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en SetItem.", ex); }
      }
      private void EnabledItem()
      {
         try
         {
            Boolean EnabledDatosGenerales = false;
            Boolean EnabledDatosGeneralesOtros = false;
            Boolean EnabledDatosTarifa = false;
            Boolean EnabledDatosServicios = false;
            Boolean EnabledDatosEmbarque = false;
            Boolean EnabledDatosObservaciones = false;
            Boolean EnabledDatosDocumento = false;
            Boolean EnabledDatosViaje = false;
            Boolean EnabledDatosNovedades = false;
            Boolean EnabledDatosArchivos = false;

            Boolean PermisosEspeciales = false;

            CONS_CodESTCOT.Enabled = false;

            PermisosEspeciales = Presenter.VerificarPemisoEdicion();

            if (Presenter.Item.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion)
            {
               EnabledDatosGenerales = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTINGRESADA);
               EnabledDatosGeneralesOtros = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTINGRESADA);
               EnabledDatosTarifa = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTINGRESADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTAUTORIZADA);
               EnabledDatosServicios = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTINGRESADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTAUTORIZADA);
               EnabledDatosEmbarque = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTINGRESADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTAUTORIZADA);
               EnabledDatosObservaciones = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTINGRESADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTAUTORIZADA);

               CCOT_NumDocCOT.Enabled = EnabledDatosGenerales;
               CCOT_Version.Enabled = EnabledDatosGenerales;
               //CONS_CodESTCOT.Enabled = EnabledDatosGenerales;
            }
            else if (Presenter.Item.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
            {
               EnabledDatosGenerales = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEINGRESADA && !(Presenter.Item.CCOT_TipoPadre.HasValue && Presenter.Item.CCOT_NumPadre.HasValue));
               EnabledDatosGeneralesOtros = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTINGRESADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECOORDINADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONFIRMADA);
               EnabledDatosTarifa = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEINGRESADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECOORDINADA) || (PermisosEspeciales);
               EnabledDatosServicios = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEINGRESADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECOORDINADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONFIRMADA) || (PermisosEspeciales);
               EnabledDatosEmbarque = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEINGRESADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECOORDINADA) || (PermisosEspeciales);
               EnabledDatosObservaciones = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEINGRESADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECOORDINADA) || (PermisosEspeciales);
               EnabledDatosDocumento = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEINGRESADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECOORDINADA) || (PermisosEspeciales);
               EnabledDatosViaje = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEINGRESADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECOORDINADA) || (PermisosEspeciales);
               EnabledDatosNovedades = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEINGRESADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECOORDINADA) || (PermisosEspeciales);
               EnabledDatosArchivos = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEINGRESADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECOORDINADA) || (PermisosEspeciales);

               CCOT_NumDocOV.Enabled = EnabledDatosGenerales;
               CCOT_NumDocCOT2.Enabled = EnabledDatosGenerales;
               //CONS_CodESTOV.Enabled = EnabledDatosGenerales;
            }

            #region [ Datos Generales ]
            ENTC_CodCliente.Enabled = EnabledDatosGeneralesOtros;
            ENTC_CodCliente.AyudaButton.Enabled = EnabledDatosGeneralesOtros;
            CCOT_FecEmi.Enabled = EnabledDatosGenerales;
            cmbCONS_CodRGM.Enabled = EnabledDatosGenerales;
            cmbCONS_CodVia.Enabled = EnabledDatosGenerales;
            CCOT_FecVcto.Enabled = EnabledDatosGenerales;
            txaENTC_CodAgente.Enabled = EnabledDatosGeneralesOtros;
            txaENTC_CodAgente.AyudaButton.Enabled = EnabledDatosGeneralesOtros;
            CCOT_FecAprueba.Enabled = EnabledDatosGenerales;
            mdtDDOV_FecEmbarque.Enabled = EnabledDatosGeneralesOtros;
            ENTC_CodEjecutivo.Enabled = EnabledDatosGeneralesOtros;
            ENTC_CodEjecutivo.AyudaButton.Enabled = EnabledDatosGeneralesOtros;
            CCOT_Propia.Enabled = EnabledDatosGeneralesOtros;
            ENTC_CodBroker.Enabled = EnabledDatosGeneralesOtros;
            ENTC_CodBroker.AyudaButton.Enabled = EnabledDatosGeneralesOtros;
            CCOT_ServicioLogistico.Enabled = EnabledDatosGeneralesOtros;
            CCOT_VoBo_GateIn.Enabled = EnabledDatosGeneralesOtros;
            ENTC_CodCustomer.Enabled = EnabledDatosGeneralesOtros;
            ENTC_CodCustomer.AyudaButton.Enabled = EnabledDatosGeneralesOtros;
            TIPO_CodINC.Enabled = EnabledDatosGeneralesOtros;

            chkCCOT_ServioTransmision.Enabled = EnabledDatosGeneralesOtros;
            chkCCOT_EnviaAvisoLlegada.Enabled = EnabledDatosGeneralesOtros;

            btnNuevoContacto.Enabled = EnabledDatosGeneralesOtros;
            btnEditarContacto.Enabled = EnabledDatosGeneralesOtros;
            ENTC_Contacto.ReadOnly = true;
            ENTC_EMail.ReadOnly = true;
            ENTC_Cargo.ReadOnly = true;
            ENTC_Contacto.Enabled = EnabledDatosGeneralesOtros;
            ENTC_EMail.Enabled = EnabledDatosGeneralesOtros;
            ENTC_Cargo.Enabled = EnabledDatosGeneralesOtros;
            #endregion

            #region [ Datos Servicios ]
            ENTC_CodTransportista.Enabled = EnabledDatosTarifa;
            ENTC_CodTransportista.AyudaButton.Enabled = EnabledDatosTarifa;
            CONS_CodTFT.Enabled = EnabledDatosTarifa;
            CONT_Numero.Enabled = EnabledDatosTarifa;
            CONT_Numero.AyudaButton.Enabled = EnabledDatosTarifa;
            btnCambiarContrato.Enabled = EnabledDatosTarifa;
            CONT_Descrip.Enabled = EnabledDatosTarifa;
            CCOT_FecTarifa.Enabled = EnabledDatosTarifa;

            //TIPO_CodPAIOrigen.Enabled = EnabledDatosTarifa;
            //PUER_CodOrigen.Enabled = EnabledDatosTarifa;
            //TIPO_CodPAIDestino.Enabled = EnabledDatosTarifa;
            //PUER_CodDestino.Enabled = EnabledDatosTarifa;
            //TIPO_CodPAITrasbordo.Enabled = EnabledDatosTarifa;
            //PUER_CodTrasbordo.Enabled = EnabledDatosTarifa;

            txaPUER_CodOrigen.Enabled = EnabledDatosTarifa;
            txaPUER_CodDestino.Enabled = EnabledDatosTarifa;
            txaPUER_CodTrasbordo.Enabled = EnabledDatosTarifa;

            TIPO_CodMND.Enabled = EnabledDatosTarifa;
            CONS_CodFLE.Enabled = EnabledDatosTarifa;
            btnAddFlete.Enabled = EnabledDatosTarifa;
            btnDelFlete.Enabled = EnabledDatosTarifa;
            grdItemsFlete.Enabled = EnabledDatosTarifa;
            CCOT_PagoMBL.Enabled = EnabledDatosTarifa;
            CCOT_PagoHBL.Enabled = EnabledDatosTarifa;
            DCOT_Importe.ReadOnly = true;
            DCOT_Rentabilidad.ReadOnly = true;
            DCOT_Importe.Enabled = EnabledDatosTarifa;
            DCOT_Rentabilidad.Enabled = EnabledDatosTarifa;
            btnAddServicio.Enabled = EnabledDatosServicios;
            btnDelServicio.Enabled = EnabledDatosServicios;
            grdItemsServicio.Enabled = EnabledDatosServicios;
            #endregion

            #region [ Datos Embarque ]
            CCOT_CargaRefrigerada.Enabled = EnabledDatosEmbarque;
            CCOT_Roundtrip.Enabled = EnabledDatosEmbarque;
            chkCCOT_CargaPeligrosa.Enabled = EnabledDatosEmbarque;
            CCOT_Temperatura.Enabled = EnabledDatosEmbarque;
            cmbTIPO_CodImo.Enabled = EnabledDatosEmbarque && chkCCOT_CargaPeligrosa.Checked;
            txtCCOT_ImoUN.Enabled = EnabledDatosEmbarque && chkCCOT_CargaPeligrosa.Checked;
            grdItemsFleteEmbarque.Enabled = EnabledDatosEmbarque;
            ENTC_CodShipper.Enabled = EnabledDatosEmbarque;
            ENTC_CodShipper.AyudaButton.Enabled = EnabledDatosEmbarque;
            ENTC_CodConsignee.Enabled = EnabledDatosEmbarque;
            ENTC_CodConsignee.AyudaButton.Enabled = EnabledDatosEmbarque;
            ENTC_CodNotify.Enabled = EnabledDatosEmbarque;
            ENTC_CodNotify.AyudaButton.Enabled = EnabledDatosEmbarque;
            DOOV_CodReferencia.Enabled = EnabledDatosEmbarque;
            #endregion

            #region [ Datos Observaciones ]
            CCOT_Almacenaje.Enabled = EnabledDatosObservaciones;
            CCOT_TiempoViaje.Enabled = EnabledDatosObservaciones;
            CCOT_SobreEstadia.Enabled = EnabledDatosObservaciones;
            CCOT_ValidezOferta.Enabled = EnabledDatosObservaciones;
            CCOT_Observaciones.Enabled = EnabledDatosObservaciones;
            #endregion

            if (Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
            {
               #region [ Datos Novedades ]
               //TIPO_CodDTM.Enabled = EnabledDatosDocumento;
               txaENTC_CodDepTemporal.Enabled = EnabledDatosDocumento;
               DOOV_HBL.Enabled = EnabledDatosDocumento;
               DOOV_Cntr.Enabled = EnabledDatosDocumento;
               DOOV_MBL.Enabled = EnabledDatosDocumento;
               txtDDOV_NroBooking.Enabled = EnabledDatosDocumento;

               chkDDOV_HBLNieto.Enabled = EnabledDatosDocumento;


               NVIA_NroViaje.Enabled = EnabledDatosViaje;
               NVIA_NroViaje.AyudaButton.Enabled = EnabledDatosViaje;
               NVIA_FecETA.NSMaskedTextBox.ReadOnly = true;
               NVIA_FecETA.NSDateTimePicke.Enabled = false;
               //DOOV_FecETDFeeder_IMPO.NSMaskedTextBox.ReadOnly = true;
               //DOOV_FecETDFeeder_IMPO.NSDateTimePicke.Enabled = false;
               NAVE_Nombre.ReadOnly = true;
               NVIA_FecETDMaster.NSMaskedTextBox.ReadOnly = true;
               NVIA_FecETDMaster.NSDateTimePicke.Enabled = false;
               //DOOV_Feeder_IMPO.ReadOnly = true;
               NVIA_FecCutOff.NSMaskedTextBox.ReadOnly = true;
               NVIA_FecCutOff.NSDateTimePicke.Enabled = false;

               OVNO_Descrip.Enabled = EnabledDatosNovedades;
               CONS_CodNot.Enabled = EnabledDatosNovedades;
               btnNuevoNovedad.Enabled = EnabledDatosNovedades;
               btnEnviarNovedad.Enabled = EnabledDatosNovedades;
               grdItemsNovedades.Enabled = EnabledDatosNovedades;
               #endregion

               #region [ Datos Archivo ]
               OVAR_Archivo.Enabled = EnabledDatosArchivos;
               OVAR_Archivo.AyudaButton.Enabled = EnabledDatosArchivos;
               btnUploadFile.Enabled = EnabledDatosArchivos;
               btnDownloadFile.Enabled = EnabledDatosArchivos;
               grdItemsArchivos.Enabled = EnabledDatosArchivos;
               #endregion

               #region [ Eventos/Tareas ]
               ClearItemEventoTarea();
               SeleccionarEventoTarea();
               InstanceItemEventoTarea(false, false);
               #endregion
            }

            //cmbCONS_CodLNG.Enabled = false;
            cmbCONS_CodLNG.Enabled = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en EnabledItem.", ex); }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Se han encontrado los siguientes errores revisar los detalles.", Presenter.Item.MensajeError);

            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Cab_Cotizacion_OV>.Validate(Presenter.Item, this, errorProviderCab_Cotizacion_OV);

            if (!Presenter.Item.ItemsFleteOK) { errorProviderCab_Cotizacion_OV.SetError(grdItemsFlete, Presenter.Item.ItemsFleteMSGERROR); }
            if (!Presenter.Item.ItemsFleteEmbarqueOK) { errorProviderCab_Cotizacion_OV.SetError(grdItemsFleteEmbarque, Presenter.Item.ItemsFleteEmbarqueMSGERROR); }
            if (!Presenter.Item.ItemsServicioOK) { errorProviderCab_Cotizacion_OV.SetError(grdItemsServicio, Presenter.Item.ItemsServicioMSGERROR); }

            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Cab_Cotizacion_OV>.SetTabError(tabCab_Cotizacion_OV, errorProviderCab_Cotizacion_OV);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }
      #endregion

      #region [ Metodos ]
      //private void LoadPuertosOrigen()
      //{
      //   try
      //   {
      //      Boolean _inicializar = true;
      //      if (TIPO_CodPAIOrigen.TiposSelectedItem != null)
      //      {
      //         ObservableCollection<Entities.Puerto> _items = Presenter.ListPuertos.Where(puer => puer.TIPO_CodPais == TIPO_CodPAIOrigen.TiposSelectedItem.TIPO_CodTipo && puer.CONS_CodVia == CONS_CodVia.ConstantesSelectedValue && puer.PUER_Favorito).ToObservableCollection();
      //         if (_items != null && _items.Count > 0)
      //         {
      //            foreach (Entities.Puerto _puerto in _items)
      //            {
      //               PUER_CodOrigen.AddComboBoxItem(_puerto.PUER_Codigo, _puerto.PUER_Nombre, _inicializar);
      //               _inicializar = false;
      //            }
      //            PUER_CodOrigen.LoadComboBox("< Seleccionar Puerto Origen >", ListSortDirection.Ascending);
      //            PUER_CodOrigen.Enabled = true;
      //         }
      //         else
      //         {
      //            PUER_CodOrigen.DataSource = null;
      //            PUER_CodOrigen.Enabled = false;
      //         }
      //      }
      //      else
      //      {
      //         PUER_CodOrigen.DataSource = null;
      //         PUER_CodOrigen.Enabled = false;
      //      }
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los puertos de origen.", ex); }
      //}
      //private void LoadPuertosTrasbordo()
      //{
      //   try
      //   {
      //      Boolean _inicializar = true;
      //      if (TIPO_CodPAITrasbordo.TiposSelectedItem != null)
      //      {
      //         ObservableCollection<Entities.Puerto> _items = Presenter.ListPuertos.Where(puer => puer.TIPO_CodPais == TIPO_CodPAITrasbordo.TiposSelectedItem.TIPO_CodTipo && puer.CONS_CodVia == CONS_CodVia.ConstantesSelectedValue && puer.PUER_Favorito).ToObservableCollection();
      //         if (_items != null && _items.Count > 0)
      //         {
      //            foreach (Entities.Puerto _puerto in _items)
      //            {
      //               PUER_CodTrasbordo.AddComboBoxItem(_puerto.PUER_Codigo, _puerto.PUER_Nombre, _inicializar);
      //               _inicializar = false;
      //            }
      //            PUER_CodTrasbordo.LoadComboBox("< Seleccionar Puerto Trasbordo >", ListSortDirection.Ascending);
      //            PUER_CodTrasbordo.Enabled = true;
      //         }
      //         else
      //         {
      //            PUER_CodTrasbordo.DataSource = null;
      //            PUER_CodTrasbordo.Enabled = false;
      //         }
      //      }
      //      else
      //      {
      //         PUER_CodDestino.DataSource = null;
      //         PUER_CodDestino.Enabled = false;
      //      }
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los puertos de trasbordo.", ex); }
      //}
      //private void LoadPuertosDestino()
      //{
      //   try
      //   {
      //      Boolean _inicializar = true;
      //      if (TIPO_CodPAIDestino.TiposSelectedItem != null)
      //      {
      //         ObservableCollection<Entities.Puerto> _items = Presenter.ListPuertos.Where(puer => puer.TIPO_CodPais == TIPO_CodPAIDestino.TiposSelectedItem.TIPO_CodTipo && puer.CONS_CodVia == CONS_CodVia.ConstantesSelectedValue && puer.PUER_Favorito).ToObservableCollection();
      //         if (_items != null && _items.Count > 0)
      //         {
      //            foreach (Entities.Puerto _puerto in _items)
      //            {
      //               PUER_CodDestino.AddComboBoxItem(_puerto.PUER_Codigo, _puerto.PUER_Nombre, _inicializar);
      //               _inicializar = false;
      //            }
      //            PUER_CodDestino.LoadComboBox("< Seleccionar Puerto Destino >", ListSortDirection.Ascending);
      //            PUER_CodDestino.Enabled = true;
      //         }
      //         else
      //         {
      //            PUER_CodDestino.DataSource = null;
      //            PUER_CodDestino.Enabled = false;
      //         }
      //      }
      //      else
      //      {
      //         PUER_CodDestino.DataSource = null;
      //         PUER_CodDestino.Enabled = false;
      //      }
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los puertos de destino.", ex); }
      //}

      private void FormatGridFlete()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsFlete.Columns.Clear();
            this.grdItemsFlete.AllowAddNewRow = false;

            //Item
            this.grdItemsFlete.Columns.Add("DCOT_Item", "Item", "DCOT_Item");
            //tipo de paquete (tamaño y tipo de contenedor)
            Telerik.WinControls.UI.GridViewComboBoxColumn _paquete = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _paquete.Name = "PACK_Codigo";
            _paquete.HeaderText = "Tipo Paquete";
            _paquete.FieldName = "PACK_Codigo";
            _paquete.ValueMember = "PACK_Codigo";
            _paquete.DisplayMember = "PACK_Desc";
            this.grdItemsFlete.Columns.Add(_paquete);
            //cantidad
            Telerik.WinControls.UI.GridViewDecimalColumn _cantidad = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _cantidad.Name = "DCOT_Cantidad";
            _cantidad.HeaderText = "Cantidad";
            _cantidad.FieldName = "DCOT_Cantidad";
            _cantidad.DecimalPlaces = 2;
            this.grdItemsFlete.Columns.Add(_cantidad);
            //tarifa unitaria costo
            Telerik.WinControls.UI.GridViewDecimalColumn _preciocosto = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _preciocosto.Name = "DCOT_PrecioUniCosto";
            _preciocosto.HeaderText = "P.U. Costo";
            _preciocosto.FieldName = "DCOT_PrecioUniCosto";
            _preciocosto.DecimalPlaces = 2;
            this.grdItemsFlete.Columns.Add(_preciocosto);
            //tarifa unitario venta
            Telerik.WinControls.UI.GridViewDecimalColumn _precioventa = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _precioventa.Name = "DCOT_PrecioUniVenta";
            _precioventa.HeaderText = "P.U. Venta";
            _precioventa.FieldName = "DCOT_PrecioUniVenta";
            _precioventa.DecimalPlaces = 2;
            this.grdItemsFlete.Columns.Add(_precioventa);
            //total costo 
            Telerik.WinControls.UI.GridViewDecimalColumn _totalcosto = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _totalcosto.Name = "DCOT_TotalUniCosto";
            _totalcosto.HeaderText = "Total Costo";
            _totalcosto.FieldName = "DCOT_TotalUniCosto";
            _totalcosto.DecimalPlaces = 2;
            this.grdItemsFlete.Columns.Add(_totalcosto);
            //total venta
            Telerik.WinControls.UI.GridViewDecimalColumn _totalventa = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _totalventa.Name = "DCOT_TotalUniVenta";
            _totalventa.HeaderText = "Total Venta";
            _totalventa.FieldName = "DCOT_TotalUniVenta";
            _totalventa.DecimalPlaces = 2;
            this.grdItemsFlete.Columns.Add(_totalventa);

            this.grdItemsFlete.Columns.Add("TARI_Codigo", "TARI_Codigo", "TARI_Codigo");


            grdItemsFlete.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsFlete);
            grdItemsFlete.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            this.grdItemsFlete.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.grdItemsFlete.MultiSelect = false;

            this.grdItemsFlete.ShowFilteringRow = false;
            this.grdItemsFlete.EnableFiltering = false;
            this.grdItemsFlete.MasterTemplate.EnableFiltering = false;
            this.grdItemsFlete.EnableGrouping = false;
            this.grdItemsFlete.MasterTemplate.EnableGrouping = false;
            this.grdItemsFlete.EnableSorting = false;
            this.grdItemsFlete.MasterTemplate.EnableCustomSorting = false;

            this.grdItemsFlete.ReadOnly = false;
            this.grdItemsFlete.AllowEditRow = true;

            this.grdItemsFlete.Columns["TARI_Codigo"].IsVisible = false;

            this.grdItemsFlete.Columns["DCOT_Item"].ReadOnly = true;

            this.grdItemsFlete.Columns["PACK_Codigo"].ReadOnly = false;
            this.grdItemsFlete.Columns["DCOT_Cantidad"].ReadOnly = false;
            this.grdItemsFlete.Columns["DCOT_PrecioUniCosto"].ReadOnly = false;
            this.grdItemsFlete.Columns["DCOT_PrecioUniVenta"].ReadOnly = false;

            this.grdItemsFlete.Columns["DCOT_TotalUniCosto"].ReadOnly = true;
            this.grdItemsFlete.Columns["DCOT_TotalUniVenta"].ReadOnly = true;

            this.grdItemsFlete.Columns["TARI_Codigo"].ReadOnly = true;


            this.grdItemsFlete.Columns["DCOT_Item"].Width = 40;

            this.grdItemsFlete.Columns["PACK_Codigo"].Width = 150;
            this.grdItemsFlete.Columns["DCOT_Cantidad"].Width = 80;
            this.grdItemsFlete.Columns["DCOT_PrecioUniCosto"].Width = 100;
            this.grdItemsFlete.Columns["DCOT_PrecioUniVenta"].Width = 100;

            this.grdItemsFlete.Columns["DCOT_TotalUniCosto"].Width = 100;
            this.grdItemsFlete.Columns["DCOT_TotalUniVenta"].Width = 100;


            this.grdItemsFlete.Columns["TARI_Codigo"].Width = 0;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
      }
      private void ConfigureGridFlete()
      {
         try
         {
            if (this.grdItemsFlete.Columns.Contains("PACK_Codigo"))
            {
               if (CONS_CodFLE.ConstantesSelectedItem != null)
               {
                  switch (CONS_CodFLE.ConstantesSelectedItem.CONS_CodTipo)
                  {
                     case Delfin.Controls.variables.CONSFLE_FCL_LCL:
                     case Delfin.Controls.variables.CONSFLE_FCL_FCL:
                        ((Telerik.WinControls.UI.GridViewComboBoxColumn)this.grdItemsFlete.Columns["PACK_Codigo"]).DataSource = Presenter.ListPaquetes.Where(pack => pack.TIPO_CodPAQ == "001").ToObservableCollection();
                        this.grdItemsFlete.Columns["DCOT_PrecioUniCosto"].IsVisible = Presenter.VerCostoFCL;
                        this.grdItemsFlete.Columns["DCOT_TotalUniCosto"].IsVisible = Presenter.VerCostoFCL;
                        break;
                     case Delfin.Controls.variables.CONSFLE_LCL_LCL:
                     case Delfin.Controls.variables.CONSFLE_LCL_FCL:
                        ((Telerik.WinControls.UI.GridViewComboBoxColumn)this.grdItemsFlete.Columns["PACK_Codigo"]).DataSource = Presenter.ListPaquetes.Where(pack => pack.TIPO_CodPAQ != "001").ToObservableCollection();
                        this.grdItemsFlete.Columns["DCOT_PrecioUniCosto"].IsVisible = true;
                        this.grdItemsFlete.Columns["DCOT_TotalUniCosto"].IsVisible = true;
                        break;
                     default:
                        break;
                  }
               }
               else
               {
                  ((Telerik.WinControls.UI.GridViewComboBoxColumn)this.grdItemsFlete.Columns["PACK_Codigo"]).DataSource = null;
                  this.grdItemsFlete.Columns["DCOT_PrecioUniCosto"].IsVisible = false;
                  this.grdItemsFlete.Columns["DCOT_TotalUniCosto"].IsVisible = false;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Flete)", ex); }
      }
      private void FormatGridFleteEmbarque()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsFleteEmbarque.Columns.Clear();
            this.grdItemsFleteEmbarque.AllowAddNewRow = false;
            //Item
            this.grdItemsFleteEmbarque.Columns.Add("DCOT_Item", "Item", "DCOT_Item");
            //Comodity
            Telerik.WinControls.UI.GridViewComboBoxColumn _comodity = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _comodity.Name = "TIPO_CodCDT";
            _comodity.HeaderText = "Comodity";
            _comodity.FieldName = "TIPO_CodCDT";
            _comodity.ValueMember = "TIPO_CodTipo";
            _comodity.DisplayMember = "TIPO_Desc1";
            _comodity.DataSource = Presenter.ListTiposCDT;
            this.grdItemsFleteEmbarque.Columns.Add(_comodity);
            //Descripción de producto
            this.grdItemsFleteEmbarque.Columns.Add("DCOT_Producto", "Producto", "DCOT_Producto");
            //bultos
            Telerik.WinControls.UI.GridViewDecimalColumn _bultos = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _bultos.Name = "DCOT_Bultos";
            _bultos.HeaderText = "Bultos";
            _bultos.FieldName = "DCOT_Bultos";
            _bultos.DecimalPlaces = 3;
            this.grdItemsFleteEmbarque.Columns.Add(_bultos);
            //unidad de medida de los bultos
            Telerik.WinControls.UI.GridViewComboBoxColumn _unidad = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _unidad.Name = "TIPO_CodUnm";
            _unidad.HeaderText = "Unidad Medida";
            _unidad.FieldName = "TIPO_CodUnm";
            _unidad.ValueMember = "TIPO_CodTipo";
            _unidad.DisplayMember = "TIPO_Desc1";
            _unidad.DataSource = Presenter.ListTiposUNM;
            this.grdItemsFleteEmbarque.Columns.Add(_unidad);
            //peso en kilogramos
            Telerik.WinControls.UI.GridViewDecimalColumn _peso = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _peso.Name = "DCOT_Peso";
            _peso.HeaderText = "Peso (Kg.)";
            _peso.FieldName = "DCOT_Peso";
            _peso.DecimalPlaces = 3;
            this.grdItemsFleteEmbarque.Columns.Add(_peso);
            //volumen en toneladas m3
            Telerik.WinControls.UI.GridViewDecimalColumn _volumen = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _volumen.Name = "DCOT_Volumen";
            _volumen.HeaderText = "Volumen (m3.)";
            _volumen.FieldName = "DCOT_Volumen";
            _volumen.DecimalPlaces = 3;
            this.grdItemsFleteEmbarque.Columns.Add(_volumen);
            //largo en centimétros
            Telerik.WinControls.UI.GridViewDecimalColumn _largo = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _largo.Name = "DCOT_Largo";
            _largo.HeaderText = "Largo (cm.)";
            _largo.FieldName = "DCOT_Largo";
            _largo.DecimalPlaces = 2;
            this.grdItemsFleteEmbarque.Columns.Add(_largo);
            //ancho en centimétros
            Telerik.WinControls.UI.GridViewDecimalColumn _ancho = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _ancho.Name = "DCOT_Ancho";
            _ancho.HeaderText = "Ancho (cm.)";
            _ancho.FieldName = "DCOT_Ancho";
            _ancho.DecimalPlaces = 2;
            this.grdItemsFleteEmbarque.Columns.Add(_ancho);
            //alto en centimétros
            Telerik.WinControls.UI.GridViewDecimalColumn _alto = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _alto.Name = "DCOT_Alto";
            _alto.HeaderText = "Alto (cm.)";
            _alto.FieldName = "DCOT_Alto";
            _alto.DecimalPlaces = 2;
            this.grdItemsFleteEmbarque.Columns.Add(_alto);

            grdItemsFleteEmbarque.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsFleteEmbarque);
            grdItemsFleteEmbarque.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            (grdItemsFleteEmbarque.Columns["DCOT_Bultos"] as Telerik.WinControls.UI.GridViewDecimalColumn).DecimalPlaces = 0;
            (grdItemsFleteEmbarque.Columns["DCOT_Peso"] as Telerik.WinControls.UI.GridViewDecimalColumn).FormatString = "{0:###,##0}";
            (grdItemsFleteEmbarque.Columns["DCOT_Peso"] as Telerik.WinControls.UI.GridViewDecimalColumn).DecimalPlaces = 3;
            (grdItemsFleteEmbarque.Columns["DCOT_Peso"] as Telerik.WinControls.UI.GridViewDecimalColumn).FormatString = "{0:###,##0.000}";
            (grdItemsFleteEmbarque.Columns["DCOT_Volumen"] as Telerik.WinControls.UI.GridViewDecimalColumn).DecimalPlaces = 3;
            (grdItemsFleteEmbarque.Columns["DCOT_Volumen"] as Telerik.WinControls.UI.GridViewDecimalColumn).FormatString = "{0:###,##0.000}";

            this.grdItemsFleteEmbarque.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.grdItemsFleteEmbarque.MultiSelect = false;

            this.grdItemsFleteEmbarque.ShowFilteringRow = false;
            this.grdItemsFleteEmbarque.EnableFiltering = false;
            this.grdItemsFleteEmbarque.MasterTemplate.EnableFiltering = false;
            this.grdItemsFleteEmbarque.EnableGrouping = false;
            this.grdItemsFleteEmbarque.MasterTemplate.EnableGrouping = false;
            this.grdItemsFleteEmbarque.EnableSorting = false;
            this.grdItemsFleteEmbarque.MasterTemplate.EnableCustomSorting = false;

            this.grdItemsFleteEmbarque.ReadOnly = false;
            this.grdItemsFleteEmbarque.AllowEditRow = true;

            this.grdItemsFleteEmbarque.Columns["DCOT_Item"].ReadOnly = true;
            this.grdItemsFleteEmbarque.Columns["TIPO_CodCDT"].ReadOnly = false;
            this.grdItemsFleteEmbarque.Columns["DCOT_Producto"].ReadOnly = false;
            this.grdItemsFleteEmbarque.Columns["DCOT_Bultos"].ReadOnly = false;
            this.grdItemsFleteEmbarque.Columns["TIPO_CodUnm"].ReadOnly = false;
            this.grdItemsFleteEmbarque.Columns["DCOT_Peso"].ReadOnly = false;
            this.grdItemsFleteEmbarque.Columns["DCOT_Volumen"].ReadOnly = false;
            this.grdItemsFleteEmbarque.Columns["DCOT_Largo"].ReadOnly = false;
            this.grdItemsFleteEmbarque.Columns["DCOT_Ancho"].ReadOnly = false;
            this.grdItemsFleteEmbarque.Columns["DCOT_Alto"].ReadOnly = false;


            this.grdItemsFleteEmbarque.Columns["DCOT_Item"].Width = 40;
            this.grdItemsFleteEmbarque.Columns["TIPO_CodCDT"].Width = 100;
            this.grdItemsFleteEmbarque.Columns["DCOT_Producto"].Width = 200;
            this.grdItemsFleteEmbarque.Columns["DCOT_Bultos"].Width = 80;
            this.grdItemsFleteEmbarque.Columns["TIPO_CodUnm"].Width = 80;
            this.grdItemsFleteEmbarque.Columns["DCOT_Peso"].Width = 80;
            this.grdItemsFleteEmbarque.Columns["DCOT_Volumen"].Width = 80;
            this.grdItemsFleteEmbarque.Columns["DCOT_Largo"].Width = 80;
            this.grdItemsFleteEmbarque.Columns["DCOT_Ancho"].Width = 80;
            this.grdItemsFleteEmbarque.Columns["DCOT_Alto"].Width = 80;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Flete Embarque)", ex); }
      }

      private void FormatGridNovedades()
      {
         try
         {

            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsNovedades.Columns.Clear();
            this.grdItemsNovedades.AllowAddNewRow = false;

            grdItemsNovedades.Columns.Add("OVNO_Fecha", "Fecha", "OVNO_Fecha");
            grdItemsNovedades.Columns.Add("OVNO_Email", "Email", "OVNO_Email");
            grdItemsNovedades.Columns.Add("OVNO_Descrip", "Descripción", "OVNO_Descrip");
            Telerik.WinControls.UI.GridViewCommandColumn _Descripcion = new Telerik.WinControls.UI.GridViewCommandColumn();
            _Descripcion.Name = "OVNO_DescripcionPopUp";
            _Descripcion.HeaderText = "";
            _Descripcion.DefaultText = "...";
            _Descripcion.UseDefaultText = true;
            _Descripcion.Tag = "OVNO_DescripcionPopUp";
            _Descripcion.MinWidth = 20;
            _Descripcion.Width = 20;
            this.grdItemsNovedades.Columns.Add(_Descripcion);

            grdItemsNovedades.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsNovedades);
            grdItemsNovedades.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            this.grdItemsNovedades.ShowFilteringRow = false;
            this.grdItemsNovedades.EnableFiltering = false;
            this.grdItemsNovedades.MasterTemplate.EnableFiltering = false;
            this.grdItemsNovedades.EnableGrouping = false;
            this.grdItemsNovedades.MasterTemplate.EnableGrouping = false;
            this.grdItemsNovedades.EnableSorting = false;
            this.grdItemsNovedades.MasterTemplate.EnableCustomSorting = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Novedades)", ex); }
      }
      private void FormatGridArchivos()
      {
         try
         {

            grdItemsArchivos.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItemsArchivos_CommandCellClick);

            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsArchivos.Columns.Clear();
            this.grdItemsArchivos.AllowAddNewRow = false;


            Telerik.WinControls.UI.GridViewCommandColumn commandColumn;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItemsArchivos.Columns.Add(commandColumn);
            this.grdItemsArchivos.Columns["Delete"].AllowSort = false;
            this.grdItemsArchivos.Columns["Delete"].AllowFiltering = false;


            grdItemsArchivos.Columns.Add("OVAR_FecEmi", "Fecha", "OVAR_FecEmi");
            grdItemsArchivos.Columns.Add("OVAR_Archivo", "Archivo", "OVAR_Archivo");
            grdItemsArchivos.Columns.Add("OVAR_Descrip", "Descripción", "OVAR_Descrip");
            grdItemsArchivos.Columns.Add("OVAR_Observacion", "Observación", "OVAR_Observacion");


            grdItemsArchivos.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsArchivos);
            grdItemsArchivos.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            grdItemsArchivos.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            grdItemsArchivos.MultiSelect = false;

            grdItemsArchivos.ShowFilteringRow = false;
            grdItemsArchivos.EnableFiltering = false;
            grdItemsArchivos.MasterTemplate.EnableFiltering = false;
            grdItemsArchivos.EnableGrouping = false;
            grdItemsArchivos.MasterTemplate.EnableGrouping = false;
            grdItemsArchivos.EnableSorting = false;
            grdItemsArchivos.MasterTemplate.EnableCustomSorting = false;

            grdItemsArchivos.ReadOnly = false;
            grdItemsArchivos.AllowEditRow = true;

            grdItemsArchivos.Columns["OVAR_FecEmi"].ReadOnly = true;
            grdItemsArchivos.Columns["OVAR_Archivo"].IsVisible = false;
            grdItemsArchivos.Columns["OVAR_Descrip"].ReadOnly = true;
            grdItemsArchivos.Columns["OVAR_Observacion"].ReadOnly = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Archivos)", ex); }
      }

      private void AddFlete()
      {
         try
         {
            Entities.Det_Cotizacion_OV_Flete _flete = new Entities.Det_Cotizacion_OV_Flete();
            Int32 _DCOT_Item = 0;
            if (((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Count > 0)
            { _DCOT_Item = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Max(dcot => dcot.DCOT_Item); }
            _flete.DCOT_Item = _DCOT_Item + 1;
            _flete.AUDI_UsrCrea = Presenter.Session.UserName;
            _flete.AUDI_FecCrea = Presenter.Session.Fecha;
            _flete.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            BSItemsFlete.Add(_flete);
            BSItemsFlete.ResetBindings(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un flete", ex); }
      }
      private void DelFlete()
      {
         try
         {
            if (BSItemsFlete.Current != null && BSItemsFlete.Current is Entities.Det_Cotizacion_OV_Flete)
            {
               Entities.Det_Cotizacion_OV_Flete _flete = (Entities.Det_Cotizacion_OV_Flete)BSItemsFlete.Current;
               if (_flete.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
               {
                  _flete.AUDI_UsrMod = Presenter.Session.UserName;
                  _flete.AUDI_FecMod = Presenter.Session.Fecha;
                  _flete.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                  Presenter.Item.ItemsFleteDeleted.Add(_flete);
               }
               BSItemsFlete.RemoveCurrent();
               BSItemsFlete.ResetBindings(true);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar un flete", ex); }
      }

      private void ConsultarTarifario(Int32 rowIndex, Boolean ActualizarCosto = false, Boolean ActualizarPrecioVenta = false)
      {
         try
         {
            grdItemsFlete.Rows[rowIndex].Cells["TARI_Codigo"].Value = null;

            Int32 _PACK_Codigo;
            if (Int32.TryParse(grdItemsFlete.Rows[rowIndex].Cells["PACK_Codigo"].Value.ToString(), out _PACK_Codigo))
            {
               if (_PACK_Codigo > 0)
               {
                  if (grdItemsFlete.Rows[rowIndex].DataBoundItem != null && grdItemsFlete.Rows[rowIndex].DataBoundItem is Entities.Det_Cotizacion_OV_Flete)
                  { ((Entities.Det_Cotizacion_OV_Flete)grdItemsFlete.Rows[rowIndex].DataBoundItem).ItemPaquete = Presenter.ListPaquetes.Where(pack => pack.PACK_Codigo == _PACK_Codigo).FirstOrDefault(); }


                  if (CONT_Numero.Value != null && CONT_Numero.Value is Entities.Contrato && txaPUER_CodOrigen.SelectedItem != null && txaPUER_CodDestino.SelectedItem != null)
                  {

                     Entities.Contrato _itemContrato = (Entities.Contrato)CONT_Numero.Value;
                     Entities.Tarifa _itemTarifa = _itemContrato.ListTarifa.Where(tari => tari.PACK_Codigo == _PACK_Codigo
                                                                                       && tari.PUER_CodOrigen == txaPUER_CodOrigen.SelectedItem.PUER_Codigo
                                                                                       && tari.PUER_CodDestino == txaPUER_CodDestino.SelectedItem.PUER_Codigo).FirstOrDefault();

                     if (_itemTarifa == null) { throw new Exception("No se encontro una tarifa adecuada para el flete que esta ingresando"); }
                     grdItemsFlete.Rows[rowIndex].Cells["TARI_Codigo"].Value = _itemTarifa.TARI_Codigo;

                     //Decimal _DCOT_PrecioUniCosto = (Decimal)0.00;
                     //Decimal _DCOT_PrecioUniVenta = (Decimal)0.00;
                     //Decimal.TryParse(grdItemsFlete.Rows[rowIndex].Cells["DCOT_PrecioUniCosto"].Value.ToString(), out _DCOT_PrecioUniCosto);
                     //Decimal.TryParse(grdItemsFlete.Rows[rowIndex].Cells["DCOT_PrecioUniVenta"].Value.ToString(), out _DCOT_PrecioUniVenta);

                     if (_itemTarifa.TARI_Costo.HasValue && _itemTarifa.TARI_Costo.Value > (Decimal)0.00 || ActualizarCosto)
                     { grdItemsFlete.Rows[rowIndex].Cells["DCOT_PrecioUniCosto"].Value = _itemTarifa.TARI_Costo; }

                     if (_itemTarifa.TARI_PVenta1.HasValue && _itemTarifa.TARI_PVenta1.Value > (Decimal)0.00 || ActualizarPrecioVenta)
                     { grdItemsFlete.Rows[rowIndex].Cells["DCOT_PrecioUniVenta"].Value = _itemTarifa.TARI_PVenta1; }
                  }
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al configurar flete.", ex); }
      }
      private void CalcularTotalesFlete()
      {
         try
         {
            Decimal _DCOT_Costo = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.DCOT_TotalUniCosto);
            Decimal _DCOT_Venta = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.DCOT_TotalUniVenta);

            DCOT_Importe.Text = _DCOT_Venta.ToString();
            DCOT_Rentabilidad.Text = (_DCOT_Venta - _DCOT_Costo).ToString();
         }
         catch (Exception)
         { }
      }

      private void CalcularCantidadBase(Int32 rowIndex)
      {
         try
         {
            if (grdItemsServicio.Rows[rowIndex].Cells["CONS_CodBAS"].Value != null && !String.IsNullOrEmpty(grdItemsServicio.Rows[rowIndex].Cells["CONS_CodBAS"].Value.ToString()))
            {
               String _CONS_CodBAS = grdItemsServicio.Rows[rowIndex].Cells["CONS_CodBAS"].Value.ToString();
               Decimal _SCOT_Cantidad = (Decimal)1.00;
               Nullable<Decimal> _DCOT_Peso = (Decimal)0.00;
               Nullable<Decimal> _DCOT_Volumen = (Decimal)0.00;
               switch (_CONS_CodBAS)
               {
                  case Delfin.Controls.variables.CONSBASFIJO:

                     break;
                  case Delfin.Controls.variables.CONSBASCONTENEDOR:
                     _SCOT_Cantidad = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.Contenedor);
                     break;
                  case Delfin.Controls.variables.CONSBASTEUS:
                     _SCOT_Cantidad = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.TEUS);
                     break;
                  case Delfin.Controls.variables.CONSBASPESOVOLUMEN:
                     _DCOT_Peso = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.DCOT_Peso);
                     _DCOT_Volumen = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.DCOT_Volumen);
                     if (_DCOT_Peso.HasValue && _DCOT_Volumen.HasValue)
                     {
                        if (_DCOT_Peso.Value > _DCOT_Volumen.Value)
                        { _SCOT_Cantidad = _DCOT_Peso.Value; }
                        else
                        { _SCOT_Cantidad = _DCOT_Volumen.Value; }
                     }
                     break;
                  default:
                     break;
               }

               grdItemsServicio.Rows[rowIndex].Cells["SCOT_Cantidad"].Value = _SCOT_Cantidad;
            }
         }
         catch (Exception)
         { }
      }

      public void ClearItemContacto()
      {
         try
         {
            ENTC_CodEjecutivo.ClearValue();
            ENTC_CodBroker.ClearValue();

            ENTC_Contacto.Text = String.Empty;
            ENTC_Cargo.Text = String.Empty;
            ENTC_EMail.Text = String.Empty;

            btnNuevoContacto.Enabled = true;
            btnEditarContacto.Enabled = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al limpiar el item de Contacto.", ex); }
      }
      //public void SetItemContacto()
      //{
      //   try
      //   {
      //ClearItemContacto();

      //if (ENTC_CodCliente.Value != null)
      //{
      //   if (ENTC_CodConsignee.Value == null) { ENTC_CodConsignee.SetValue(ENTC_CodCliente.Value.ENTC_Codigo); }
      //   if (ENTC_CodNotify.Value == null) { ENTC_CodNotify.SetValue(ENTC_CodCliente.Value.ENTC_Codigo); }
      //}

      //if (CONS_CodRGM.ConstantesSelectedItem != null)
      //{
      //   if (CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
      //   {
      //      if (ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ENTC_CodEjecutivoImpo.HasValue)
      //      { ENTC_CodEjecutivo.SetValue(ENTC_CodCliente.Value.ENTC_CodEjecutivoImpo.Value); }

      //      if (ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ENTC_CodCustomerImpo.HasValue)
      //      { ENTC_CodCustomer.SetValue(ENTC_CodCliente.Value.ENTC_CodCustomerImpo.Value); }
      //   }
      //   else
      //   {
      //      if (ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ENTC_CodEjecutivoExpo.HasValue)
      //      { ENTC_CodEjecutivo.SetValue(ENTC_CodCliente.Value.ENTC_CodEjecutivoExpo.Value); }

      //      if (ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ENTC_CodCustomerExpo.HasValue)
      //      { ENTC_CodCustomer.SetValue(ENTC_CodCliente.Value.ENTC_CodCustomerExpo.Value); }
      //   }
      //}

      //if (CONS_CodRGM.ConstantesSelectedItem != null)
      //{
      //   if (CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == "001" && ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ContactoImpo != null)
      //   {
      //      ENTC_Contacto.Text = ENTC_CodCliente.Value.ContactoImpo.ENTC_NomCompleto;
      //      ENTC_Cargo.Text = ENTC_CodCliente.Value.ContactoImpo.ENTC_Cargo;
      //      ENTC_EMail.Text = ENTC_CodCliente.Value.ContactoImpo.ENTC_EMail;

      //      btnNuevoContacto.Enabled = false;
      //      btnEditarContacto.Enabled = true;
      //   }
      //   else if (CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == "002" && ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ContactoExpo != null)
      //   {
      //      ENTC_Contacto.Text = ENTC_CodCliente.Value.ContactoExpo.ENTC_NomCompleto;
      //      ENTC_Cargo.Text = ENTC_CodCliente.Value.ContactoExpo.ENTC_Cargo;
      //      ENTC_EMail.Text = ENTC_CodCliente.Value.ContactoExpo.ENTC_EMail;

      //      btnNuevoContacto.Enabled = false;
      //      btnEditarContacto.Enabled = true;
      //   }
      //}
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al setear el item de Contacto.", ex); }
      //}
      private void NuevoContacto()
      {
         try
         {
            if (cmbCONS_CodRGM.ConstantesSelectedItem != null && ENTC_CodCliente.Value != null)
            {
               Entities.Entidad _cliente = ENTC_CodCliente.Value;
               Presenter.Contacto(true, ref _cliente, cmbCONS_CodRGM.ConstantesSelectedItem);
               ENTC_CodCliente.SetValue(_cliente.ENTC_Codigo);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al crear nuevo item de Contacto.", ex); }
      }
      private void EditarContacto()
      {
         try
         {
            if (cmbCONS_CodRGM.ConstantesSelectedItem != null && ENTC_CodCliente.Value != null)
            {
               Entities.Entidad _cliente = ENTC_CodCliente.Value;
               Presenter.Contacto(false, ref _cliente, cmbCONS_CodRGM.ConstantesSelectedItem);
               ENTC_CodCliente.SetValue(_cliente.ENTC_Codigo);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al editar el item de Contacto.", ex); }
      }

      private void SetRelacionadosCliente()
      {
         try
         {
            ClearItemContacto();

            if (ENTC_CodCliente.Value != null)
            {
               if (ENTC_CodConsignee.Value == null) { ENTC_CodConsignee.SetValue(ENTC_CodCliente.Value.ENTC_Codigo); }
               if (ENTC_CodNotify.Value == null) { ENTC_CodNotify.SetValue(ENTC_CodCliente.Value.ENTC_Codigo); }
            }

            if (cmbCONS_CodRGM.ConstantesSelectedItem != null && ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.Relacionados != null && ENTC_CodCliente.Value.Relacionados.Count > 0) //&& cmbTIPO_CodTRF.TiposSelectedItem != null
            {
               var _itemsRelacionados = ENTC_CodCliente.Value.Relacionados.Where(rela => rela.Relacionado.CONS_CodRGM == cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection(); //&& rela.Relacionado.TIPO_CodTRF == cmbTIPO_CodTRF.TiposSelectedItem.TIPO_CodTipo
               foreach (var _itemRelacionado in _itemsRelacionados)
               {
                  switch (_itemRelacionado.TIPE_Codigo)
                  {
                     case 3: //Ejecutivos de Venta
                        if (ENTC_CodEjecutivo.Value == null)
                        { ENTC_CodEjecutivo.SetValue(_itemRelacionado.ENTC_Codigo); }
                        break;
                     case 4: //Customer Services
                        if (ENTC_CodCustomer.Value == null)
                        { ENTC_CodCustomer.SetValue(_itemRelacionado.ENTC_Codigo); }
                        break;
                     case 6: //Agente Carga
                        if (txaENTC_CodAgente.Value == null)
                        { txaENTC_CodAgente.SetValue(_itemRelacionado.ENTC_Codigo); }
                        break;
                     case 9: //Contacto
                        ENTC_Contacto.Text = _itemRelacionado.ENTC_NomCompleto;
                        ENTC_Cargo.Text = _itemRelacionado.ENTC_Cargo;
                        ENTC_EMail.Text = _itemRelacionado.ENTC_EMail;

                        btnNuevoContacto.Enabled = false;
                        btnEditarContacto.Enabled = true;
                        break;
                     case 14: //Deposito Temporal
                        if (txaENTC_CodDepTemporal.Value == null)
                        { txaENTC_CodDepTemporal.SetValue(_itemRelacionado.ENTC_Codigo); }
                        break;
                  }
               }
            }
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos Linea Negocio ]

      public bool AgenteMandato(int agente)
      {
          if (oAppService.ExecuteSQL("SELECT Valor1 FROM NextSoft.dgp.MapeoDatos WHERE Tabla='PARAMETROS' AND Clave='EAGENTE_MANDATO' AND Valor1='" + agente + "'").Tables[0].Rows.Count > 0)
              return true;
          else
              return false;
      }
      private void EstablecerLineaNegocio()
      {
         try
         {
            cmbCONS_CodLNG.ConstantesSelectedValue = null;

            if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
            {
               if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Exportacion)
               { cmbCONS_CodLNG.ConstantesSelectedValue = Delfin.Controls.variables.CONSLNG_Exportacion; }
               else if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
               {
                  if (txaENTC_CodAgente.Value != null) //&& txaPUER_CodOrigen.SelectedItem != null
                  {
                     //Boolean _validacionAgente = (Presenter.PARA_EAGENTE_SHANGHAI != null && txaENTC_CodAgente.Value.ENTC_Codigo == Presenter.PARA_EAGENTE_SHANGHAI.PARA_IntValor);
                     //Boolean _validacionPuerto = (Presenter.PARA_PAIS_MANDATO != null && txaPUER_CodOrigen.SelectedItem.TIPO_CodPais == Presenter.PARA_PAIS_MANDATO.PARA_Valor);
                      //Boolean _validacionAgente = AgenteMandato(txaENTC_CodAgente.Value.ENTC_Codigo);

                     if (cmbCONS_CodLNG.ConstantesSelectedValue == null)
                     {
                         if (AgenteMandato(txaENTC_CodAgente.Value.ENTC_Codigo)) //&& _validacionPuerto
                         { cmbCONS_CodLNG.ConstantesSelectedValue = Delfin.Controls.variables.CONSLNG_Mandato; }
                         else
                         { cmbCONS_CodLNG.ConstantesSelectedValue = Delfin.Controls.variables.CONSLNG_OtrosTraficos; }
                     }
                  }
               }
            }
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos Servicios ]
      #region [ Metodos ]
      private void SetServiciosAdicionales(ObservableCollection<Entities.Entidad_Servicio> x_listEntidad_Servicio, Int16 TIPE_Codigo, Int32 ENTC_Codigo, String ENTC_NomCompleto)
      {
         try
         {
            foreach (Entities.Entidad_Servicio itemEntidadServicio in x_listEntidad_Servicio)
            {
               if (itemEntidadServicio.SERV_Codigo.HasValue)
               {
                  if (((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicio.DataSource).Where(scot => scot.SERV_Codigo == itemEntidadServicio.SERV_Codigo.Value).FirstOrDefault() == null)
                  {
                     Entities.Det_Cotizacion_OV_Servicio _itemDet_Cotizacion_OV_Servicio = new Entities.Det_Cotizacion_OV_Servicio();
                     Int32 _SCOT_Item = 0;
                     if (((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicio.DataSource).Count > 0)
                     { _SCOT_Item = ((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicio.DataSource).Max(scot => scot.SCOT_Item); }
                     _itemDet_Cotizacion_OV_Servicio.SCOT_Item = _SCOT_Item + 1;

                     _itemDet_Cotizacion_OV_Servicio.SERV_Codigo = itemEntidadServicio.SERV_Codigo.Value;

                     Entities.Servicio _itemServicio = Presenter.ListServicio.Where(serv => serv.SERV_Codigo == itemEntidadServicio.SERV_Codigo.Value).FirstOrDefault();

                     if (_itemServicio != null)
                     {
                        //_itemDet_Cotizacion_OV_Servicio.CCOT_IngresoGasto = "I";
                        switch (_itemServicio.SERV_TipoMov)
                        {
                           case "A":
                              _itemDet_Cotizacion_OV_Servicio.CCOT_IngresoGasto = null;
                              switch (TIPE_Codigo)
                              {
                                 case Delfin.Controls.EntidadClear.TIPE_Cliente:
                                    _itemDet_Cotizacion_OV_Servicio.CCOT_IngresoGasto = "I";
                                    break;
                                 case Delfin.Controls.EntidadClear.TIPE_Agente:
                                    _itemDet_Cotizacion_OV_Servicio.CCOT_IngresoGasto = "E";
                                    break;
                                 default:
                                    _itemDet_Cotizacion_OV_Servicio.CCOT_IngresoGasto = null;
                                    break;
                              }
                              break;
                           case "C":
                              _itemDet_Cotizacion_OV_Servicio.CCOT_IngresoGasto = "E";
                              break;
                           case "I":
                              _itemDet_Cotizacion_OV_Servicio.CCOT_IngresoGasto = "I";
                              if (ENTC_CodCliente.Value != null)
                              {
                                 _itemDet_Cotizacion_OV_Servicio.TIPE_Codigo = Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Cliente);
                                 _itemDet_Cotizacion_OV_Servicio.ENTC_Codigo = ENTC_CodCliente.Value.ENTC_Codigo;
                                 _itemDet_Cotizacion_OV_Servicio.ENTC_NomCom = ENTC_CodCliente.Value.ENTC_NomCompleto;
                              }
                              break;
                        }
                        if (_itemServicio.SERV_AfeIgv.HasValue)
                        { _itemDet_Cotizacion_OV_Servicio.SERV_AfeIgv = _itemServicio.SERV_AfeIgv.Value; }
                        if (_itemServicio.SERV_AfeDet.HasValue)
                        { _itemDet_Cotizacion_OV_Servicio.SERV_AfeDet = _itemServicio.SERV_AfeDet.Value; }
                     }

                     _itemDet_Cotizacion_OV_Servicio.SCOT_Exonerado = itemEntidadServicio.ESER_Exonerado;
                     _itemDet_Cotizacion_OV_Servicio.SCOT_PreSugerido = itemEntidadServicio.ESER_Valor;
                     _itemDet_Cotizacion_OV_Servicio.SCOT_PrecioUni = itemEntidadServicio.ESER_Valor;
                     _itemDet_Cotizacion_OV_Servicio.TIPO_TabMnd = itemEntidadServicio.TIPO_TabMnd;
                     _itemDet_Cotizacion_OV_Servicio.TIPO_CodMnd = itemEntidadServicio.TIPO_CodMnd;
                     _itemDet_Cotizacion_OV_Servicio.CONS_TabBas = itemEntidadServicio.CONS_TabBas;
                     _itemDet_Cotizacion_OV_Servicio.CONS_CodBas = itemEntidadServicio.CONS_CodBas;

                     Decimal _SCOT_Cantidad = (Decimal)1.00;
                     Nullable<Decimal> _DCOT_Peso = (Decimal)0.00;
                     Nullable<Decimal> _DCOT_Volumen = (Decimal)0.00;

                     switch (_itemDet_Cotizacion_OV_Servicio.CONS_CodBas)
                     {
                        case Delfin.Controls.variables.CONSBASFIJO:
                           //_SCOT_Cantidad = (Decimal)1.00;

                           _itemDet_Cotizacion_OV_Servicio.SCOT_Cantidad = itemEntidadServicio.ESER_Cantidad;
                           break;
                        case Delfin.Controls.variables.CONSBASCONTENEDOR:
                           _SCOT_Cantidad = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.Contenedor);
                           break;
                        case Delfin.Controls.variables.CONSBASTEUS:
                           _SCOT_Cantidad = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.TEUS);
                           break;
                        case Delfin.Controls.variables.CONSBASPESOVOLUMEN:
                           _DCOT_Peso = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.DCOT_Peso);
                           _DCOT_Volumen = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.DCOT_Volumen);
                           if (_DCOT_Peso.HasValue && _DCOT_Volumen.HasValue)
                           {
                              if (_DCOT_Peso.Value > _DCOT_Volumen.Value)
                              { _SCOT_Cantidad = _DCOT_Peso.Value; }
                              else
                              { _SCOT_Cantidad = _DCOT_Volumen.Value; }
                           }
                           break;
                        default:
                           break;
                     }
                     _itemDet_Cotizacion_OV_Servicio.SCOT_Cantidad = _SCOT_Cantidad;


                     _itemDet_Cotizacion_OV_Servicio.AUDI_UsrCrea = Presenter.Session.UserName;
                     _itemDet_Cotizacion_OV_Servicio.AUDI_FecCrea = Presenter.Session.Fecha;

                     _itemDet_Cotizacion_OV_Servicio.TIPE_Codigo = TIPE_Codigo;
                     _itemDet_Cotizacion_OV_Servicio.ENTC_Codigo = ENTC_Codigo;
                     _itemDet_Cotizacion_OV_Servicio.ENTC_NomCom = ENTC_NomCompleto;

                     _itemDet_Cotizacion_OV_Servicio.SCOT_Origen = "D";

                     _itemDet_Cotizacion_OV_Servicio.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

                     BSItemsServicio.Add(_itemDet_Cotizacion_OV_Servicio);
                  }
               }
            }

            BSItemsServicio.ResetBindings(true);
         }
         catch (Exception)
         { }
      }

      private void SetServiciosCliente()
      {
         try
         {
            //if (Presenter.Item != null && Presenter.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
            //{
               if (cmbCONS_CodVia.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodLNG.ConstantesSelectedItem != null)
               {
                  if (ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ListServicio != null)
                  {
                     //if (Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
                     //{ 
                     //   //TIPO_CodDTM.TiposSelectedValue = ENTC_CodCliente.Value.TIPO_CodDTM; 
                     //   if (ENTC_CodCliente.Value.EntidadDeposito != null && ENTC_CodCliente.Value.EntidadDeposito.Count > 0)
                     //   {
                     //      if (!Presenter.Item.ENTC_CodDepTemporal.HasValue && ENTC_CodCliente.Value.EntidadDeposito[0].ENTC_CodHijo.HasValue)
                     //      { txaENTC_CodDepTemporal.SetValue(ENTC_CodCliente.Value.EntidadDeposito[0].ENTC_CodHijo.Value); }
                     //   }
                     //}

                     ObservableCollection<Entities.Entidad_Servicio> _listEntidad_Servicio = ENTC_CodCliente.Value.ListServicio.Where(eser => eser.ESER_Valor > (Decimal)0.00 && eser.CONS_CodVIA == cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo && eser.CONS_CodRGM == cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo && eser.CONS_CodLNG == cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection();
                     if (_listEntidad_Servicio.Count > 0)
                     { SetServiciosAdicionales(_listEntidad_Servicio, Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Cliente), ENTC_CodCliente.Value.ENTC_Codigo, ENTC_CodCliente.Value.ENTC_NomCompleto); }
                  }
               }
            //}
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al cargar los datos adicionales del Cliente.", ex); }
      }
      private void SetServiciosLinea()
      {
         try
         {
            if (Presenter.Item != null && Presenter.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
            {
               if (cmbCONS_CodVia.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodLNG.ConstantesSelectedItem != null)
               {
                  if (ENTC_CodTransportista.Value != null && ENTC_CodTransportista.Value.ListServicio != null)
                  {
                     if (ENTC_CodTransportista.Value.ListServicio.Where(eser => eser.ESER_Valor > (Decimal)0.00).ToObservableCollection().Count > 0)
                     {
                        ObservableCollection<Entities.Entidad_Servicio> _listEntidad_Servicio = ENTC_CodTransportista.Value.ListServicio.Where(eser => eser.ESER_Valor > (Decimal)0.00 && eser.CONS_CodVIA == cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo && eser.CONS_CodRGM == cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo && eser.CONS_CodLNG == cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection();
                        if (_listEntidad_Servicio.Count > 0)
                        { SetServiciosAdicionales(_listEntidad_Servicio, Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Transportista), ENTC_CodTransportista.Value.ENTC_Codigo, ENTC_CodTransportista.Value.ENTC_NomCompleto); }
                     }
                  }
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al cargar los datos adicionales del Cliente.", ex); }
      }
      private void SetServiciosAgente()
      {
         try
         {
            if (Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
            {
               if (Presenter.Item != null && (Presenter.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added || !Presenter.Item.AUDI_FecMod.HasValue))
               {
                  if (cmbCONS_CodVia.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodLNG.ConstantesSelectedItem != null)
                  {
                     if (txaENTC_CodAgente.Value != null && txaENTC_CodAgente.Value.ListServicio != null)
                     {
                        ObservableCollection<Entities.Entidad_Servicio> _listEntidad_Servicio = txaENTC_CodAgente.Value.ListServicio.Where(eser => eser.ESER_Valor > (Decimal)0.00 && eser.CONS_CodVIA == cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo && eser.CONS_CodRGM == cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo && eser.CONS_CodLNG == cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection();
                        if (_listEntidad_Servicio.Count > 0)
                        { SetServiciosAdicionales(_listEntidad_Servicio, Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Agente), txaENTC_CodAgente.Value.ENTC_Codigo, txaENTC_CodAgente.Value.ENTC_NomCompleto); }
                     }
                  }
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al cargar los datos adicionales del Cliente.", ex); }
      }

      private void ConfigureServicios()
      {
         try
         {
            if (grdItemsServicio.Columns.Contains("SERV_Codigo") && grdItemsServicio.Columns["SERV_Codigo"] != null)
            {
               if (cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodVia.ConstantesSelectedItem != null && cmbCONS_CodLNG.ConstantesSelectedItem != null)
               {
                  Presenter.LoadServicios(cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla, cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo, cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTabla, cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo, cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTabla, cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTipo);
                  (grdItemsServicio.Columns["SERV_Codigo"] as Telerik.WinControls.UI.GridViewComboBoxColumn).DataSource = Presenter.ListServicio.OrderBy(serv => serv.SERV_Nombre_SPA).ToObservableCollection();
                  Boolean _noExiste = false;
                  foreach (var item in grdItemsServicio.Rows)
                  {
                     Int32 _serv_codigo;
                     if (item.Cells["SERV_Codigo"].Value != null && Int32.TryParse(item.Cells["SERV_Codigo"].Value.ToString(), out _serv_codigo))
                     {
                        if (Presenter.ListServicio.FirstOrDefault(serv => serv.SERV_Codigo == _serv_codigo) == null)
                        { item.Cells["SERV_Codigo"].Value = null; _noExiste = true; }
                     }
                     //else
                     //{ item.Cells["SERV_Codigo"].Value = null; }
                  }

                  if (_noExiste)
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Se ha cambiado la configuración de los servicios, por tal motivo se ha quitado los servicios."); }
               }
               else
               {
                  Presenter.LoadServicios(null, null, null, null, null, null);
                  (grdItemsServicio.Columns["SERV_Codigo"] as Telerik.WinControls.UI.GridViewComboBoxColumn).DataSource = Presenter.ListServicio.OrderBy(serv => serv.SERV_Nombre_SPA).ToObservableCollection();
                  //foreach (var item in grdItemsServicio.Rows)
                  //{ item.Cells["SERV_Codigo"].Value = null; }
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al configurar los servicios de la Grilla.", ex); }
      }
      private void FormatGridServicios()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsServicio.Columns.Clear();
            this.grdItemsServicio.AllowAddNewRow = false;

            //Exonerado
            Telerik.WinControls.UI.GridViewCheckBoxColumn _exonerado = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _exonerado.Name = "SCOT_Exonerado";
            _exonerado.HeaderText = "Exonerado";
            _exonerado.FieldName = "SCOT_Exonerado";
            _exonerado.ReadOnly = true;
            this.grdItemsServicio.Columns.Add(_exonerado);

            //Descripción del servicio
            Telerik.WinControls.UI.GridViewComboBoxColumn _servicio = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _servicio.Name = "SERV_Codigo";
            _servicio.HeaderText = "Servicio";
            _servicio.FieldName = "SERV_CodigoStr";
            _servicio.ValueMember = "SERV_CodigoStr";
            _servicio.DisplayMember = "SERV_Nombre_SPA";
            _servicio.DataSource = Presenter.ListServicio;
            _servicio.DataType = typeof(System.String);
            //_servicio.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            //_servicio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //_servicio.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            this.grdItemsServicio.Columns.Add(_servicio);

            //Ingreso o Gasto
            Telerik.WinControls.UI.GridViewComboBoxColumn _ingresoegreso = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _ingresoegreso.Name = "CCOT_IngresoGasto";
            _ingresoegreso.HeaderText = "Ingreso/Egreso";
            _ingresoegreso.FieldName = "CCOT_IngresoGasto";
            _ingresoegreso.ValueMember = "StrCodigo";
            _ingresoegreso.DisplayMember = "StrDesc";
            _ingresoegreso.DataSource = Presenter.ListIngresoEgreso;
            _ingresoegreso.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            this.grdItemsServicio.Columns.Add(_ingresoegreso);


            //Proveedor del servicio
            Telerik.WinControls.UI.GridViewCommandColumn _proveedor = new Telerik.WinControls.UI.GridViewCommandColumn();
            _proveedor.Name = "Entidad";
            _proveedor.HeaderText = "Entidad";
            _proveedor.DefaultText = "Entidad";
            _proveedor.UseDefaultText = true;
            this.grdItemsServicio.Columns.Add(_proveedor);
            this.grdItemsServicio.Columns.Add("TIPE_Codigo", "Tipo Entidad", "TIPE_Codigo");
            this.grdItemsServicio.Columns.Add("ENTC_Codigo", "Código Proveedor", "ENTC_Codigo");
            Telerik.WinControls.UI.GridViewComboBoxColumn _tipoentidad = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _tipoentidad.Name = "TIPE_Desc";
            _tipoentidad.HeaderText = "Tipo Entidad";
            _tipoentidad.FieldName = "TIPE_Codigo";
            _tipoentidad.ValueMember = "TIPE_Codigo";
            _tipoentidad.DisplayMember = "TIPE_Descripcion";
            _tipoentidad.DataSource = Presenter.ListTiposEntidad;
            _tipoentidad.ReadOnly = true;
            _tipoentidad.TextAlignment = ContentAlignment.MiddleLeft;
            //_tipoentidad.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            this.grdItemsServicio.Columns.Add(_tipoentidad);
            this.grdItemsServicio.Columns.Add("ENTC_NomCom", "Proveedor", "ENTC_NomCom");
            //Base (Valor, Contenedor, Peso/Volumen)
            this.grdItemsServicio.Columns.Add("CONS_TabBas", "Tipo Tabla Base", "CONS_TabBas");
            Telerik.WinControls.UI.GridViewComboBoxColumn _base = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _base.Name = "CONS_CodBas";
            _base.HeaderText = "Base";
            _base.FieldName = "CONS_CodBas";
            _base.ValueMember = "CONS_CodTipo";
            _base.DisplayMember = "CONS_Desc_SPA";
            _base.DataSource = Presenter.ListConstantesBAS;
            //_base.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            this.grdItemsServicio.Columns.Add(_base);
            //Cantidad
            Telerik.WinControls.UI.GridViewDecimalColumn _cantidad = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _cantidad.Name = "SCOT_Cantidad";
            _cantidad.HeaderText = "Cantidad";
            _cantidad.FieldName = "SCOT_Cantidad";
            _cantidad.DecimalPlaces = 2;
            _cantidad.Minimum = (Decimal)0.00;
            this.grdItemsServicio.Columns.Add(_cantidad);
            //Origen del servicio (0 = Local, 1 = Destino)
            Telerik.WinControls.UI.GridViewComboBoxColumn _origen = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _origen.Name = "SCOT_Origen";
            _origen.HeaderText = "Origen";
            _origen.FieldName = "SCOT_Origen";
            _origen.ValueMember = "StrCodigo";
            _origen.DisplayMember = "StrDesc";
            _origen.DataSource = Presenter.ListOrigen;
            //_origen.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            this.grdItemsServicio.Columns.Add(_origen);
            //Moneda
            this.grdItemsServicio.Columns.Add("TIPO_TabMnd", "Tipo Tabla Base", "TIPO_TabMnd");
            Telerik.WinControls.UI.GridViewComboBoxColumn _moneda = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _moneda.Name = "TIPO_CodMnd";
            _moneda.HeaderText = "Moneda";
            _moneda.FieldName = "TIPO_CodMnd";
            _moneda.ValueMember = "TIPO_CodTipo";
            _moneda.DisplayMember = "TIPO_Desc1";
            _moneda.DataSource = Presenter.ListTiposMND;
            //_moneda.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            this.grdItemsServicio.Columns.Add(_moneda);
            //Precio Unitario
            Telerik.WinControls.UI.GridViewDecimalColumn _precio = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _precio.Name = "SCOT_PrecioUni";
            _precio.HeaderText = "Precio Unitario";
            _precio.FieldName = "SCOT_PrecioUni";
            _precio.DecimalPlaces = 2;
            _precio.Minimum = (Decimal)0.00;
            this.grdItemsServicio.Columns.Add(_precio);
            //Importe de Venta
            Telerik.WinControls.UI.GridViewDecimalColumn _importeingreso = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _importeingreso.Name = "SCOT_Importe_Ingreso";
            _importeingreso.HeaderText = "Importe Ingreso";
            _importeingreso.FieldName = "SCOT_Importe_Ingreso";
            _importeingreso.DecimalPlaces = 2;
            _importeingreso.Minimum = (Decimal)0.00;
            this.grdItemsServicio.Columns.Add(_importeingreso);
            //Importe de Venta
            Telerik.WinControls.UI.GridViewDecimalColumn _importeegreso = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _importeegreso.Name = "SCOT_Importe_Egreso";
            _importeegreso.HeaderText = "Importe Egreso";
            _importeegreso.FieldName = "SCOT_Importe_Egreso";
            _importeegreso.DecimalPlaces = 2;
            _importeegreso.Minimum = (Decimal)0.00;
            this.grdItemsServicio.Columns.Add(_importeegreso);
            //Afecto a IGV (no editable)
            Telerik.WinControls.UI.GridViewCheckBoxColumn _afectoIGV = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _afectoIGV.Name = "SERV_AfeIgv";
            _afectoIGV.HeaderText = "Afecto IGV";
            _afectoIGV.FieldName = "SERV_AfeIgv";
            this.grdItemsServicio.Columns.Add(_afectoIGV);
            //Afecto a Detracción (no editable)
            Telerik.WinControls.UI.GridViewCheckBoxColumn _afectoDetraccion = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _afectoDetraccion.Name = "SERV_AfeDet";
            _afectoDetraccion.HeaderText = "Afecto Detracción";
            _afectoDetraccion.FieldName = "SERV_AfeDet";
            this.grdItemsServicio.Columns.Add(_afectoDetraccion);
            //Importe de Venta
            Telerik.WinControls.UI.GridViewDecimalColumn _preciosugerido = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _preciosugerido.Name = "SCOT_PreSugerido";
            _preciosugerido.HeaderText = "Precio Sugerido";
            _preciosugerido.FieldName = "SCOT_PreSugerido";
            _preciosugerido.DecimalPlaces = 2;
            _preciosugerido.Minimum = (Decimal)0.00;
            this.grdItemsServicio.Columns.Add(_preciosugerido);

            Telerik.WinControls.UI.GridViewCommandColumn _tipoDocumentoTDO = new Telerik.WinControls.UI.GridViewCommandColumn();
            _tipoDocumentoTDO.Name = "TipoDocumento";
            _tipoDocumentoTDO.HeaderText = "Tipo Documento";
            _tipoDocumentoTDO.DefaultText = "Tipo Documento";
            _tipoDocumentoTDO.UseDefaultText = true;
            this.grdItemsServicio.Columns.Add(_tipoDocumentoTDO);
            this.grdItemsServicio.Columns.Add("TIPO_DescTDO", "Tipo Documento", "TIPO_DescTDO");
            this.grdItemsServicio.Columns.Add("TIPO_TabTDO", "Tipo Tabla Documento", "TIPO_TabTDO");
            this.grdItemsServicio.Columns.Add("TIPO_CodTDO", "Tipo Codigo Documento", "TIPO_CodTDO");
            this.grdItemsServicio.Columns.Add("SCOT_SerieTDO", "Serie Documento", "SCOT_SerieTDO");
            this.grdItemsServicio.Columns.Add("SCOT_NumeroTDO", "Nro. Documento", "SCOT_NumeroTDO");

            Telerik.WinControls.UI.GridViewDateTimeColumn _fechaEmision = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            _fechaEmision.Name = "SCOT_FechaEmision";
            _fechaEmision.HeaderText = "Fec. Emisión";
            _fechaEmision.FieldName = "SCOT_FechaEmision";
            _fechaEmision.FormatString = "{0:dd/MM/yyyy}";
            _fechaEmision.Format = DateTimePickerFormat.Short;
            this.grdItemsServicio.Columns.Add(_fechaEmision);

            grdItemsServicio.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsServicio);
            //grdItemsServicio.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            this.grdItemsServicio.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.grdItemsServicio.MultiSelect = false;

            this.grdItemsServicio.ShowFilteringRow = false;
            this.grdItemsServicio.EnableFiltering = false;
            this.grdItemsServicio.MasterTemplate.EnableFiltering = false;
            this.grdItemsServicio.EnableGrouping = false;
            this.grdItemsServicio.MasterTemplate.EnableGrouping = false;
            this.grdItemsServicio.EnableSorting = false;
            this.grdItemsServicio.MasterTemplate.EnableCustomSorting = false;

            this.grdItemsServicio.ReadOnly = false;
            this.grdItemsServicio.AllowEditRow = true;

            this.grdItemsServicio.Columns["SCOT_PreSugerido"].IsVisible = false;
            this.grdItemsServicio.Columns["TIPE_Codigo"].IsVisible = false;
            this.grdItemsServicio.Columns["ENTC_Codigo"].IsVisible = false;

            this.grdItemsServicio.Columns["SCOT_Exonerado"].ReadOnly = true;
            this.grdItemsServicio.Columns["CCOT_IngresoGasto"].ReadOnly = false;
            this.grdItemsServicio.Columns["SERV_Codigo"].ReadOnly = false;
            this.grdItemsServicio.Columns["TIPE_Desc"].ReadOnly = true;
            this.grdItemsServicio.Columns["ENTC_NomCom"].ReadOnly = true;
            this.grdItemsServicio.Columns["CONS_TabBas"].IsVisible = false;
            this.grdItemsServicio.Columns["CONS_CodBas"].ReadOnly = false;
            this.grdItemsServicio.Columns["SCOT_Cantidad"].ReadOnly = false;
            this.grdItemsServicio.Columns["SCOT_Origen"].ReadOnly = false;
            this.grdItemsServicio.Columns["TIPO_TabMnd"].IsVisible = false;
            this.grdItemsServicio.Columns["TIPO_CodMnd"].ReadOnly = false;
            this.grdItemsServicio.Columns["SCOT_PrecioUni"].ReadOnly = false;
            this.grdItemsServicio.Columns["SCOT_Importe_Ingreso"].ReadOnly = true;
            this.grdItemsServicio.Columns["SCOT_Importe_Egreso"].ReadOnly = true;
            this.grdItemsServicio.Columns["SERV_AfeIgv"].ReadOnly = true;
            this.grdItemsServicio.Columns["SERV_AfeDet"].ReadOnly = true;

            this.grdItemsServicio.Columns["SCOT_Exonerado"].Width = 60;
            this.grdItemsServicio.Columns["CCOT_IngresoGasto"].Width = 80;
            this.grdItemsServicio.Columns["SERV_Codigo"].Width = 200;
            this.grdItemsServicio.Columns["ENTC_NomCom"].Width = 150;
            this.grdItemsServicio.Columns["CONS_CodBas"].Width = 80;
            this.grdItemsServicio.Columns["SCOT_Cantidad"].Width = 80;
            this.grdItemsServicio.Columns["SCOT_Origen"].Width = 80;
            this.grdItemsServicio.Columns["TIPO_CodMnd"].Width = 80;
            this.grdItemsServicio.Columns["SCOT_PrecioUni"].Width = 100;
            this.grdItemsServicio.Columns["SCOT_Importe_Ingreso"].Width = 100;
            this.grdItemsServicio.Columns["SCOT_Importe_Egreso"].Width = 100;
            this.grdItemsServicio.Columns["SERV_AfeIgv"].Width = 80;
            this.grdItemsServicio.Columns["SERV_AfeDet"].Width = 80;

            this.grdItemsServicio.Columns["TIPO_DescTDO"].ReadOnly = true;
            this.grdItemsServicio.Columns["TIPO_DescTDO"].Width = 120;
            this.grdItemsServicio.Columns["TIPO_TabTDO"].IsVisible = false;
            this.grdItemsServicio.Columns["TIPO_CodTDO"].IsVisible = false;

            this.grdItemsServicio.Columns["SCOT_SerieTDO"].Width = 80;
            this.grdItemsServicio.Columns["SCOT_NumeroTDO"].Width = 80;
            this.grdItemsServicio.Columns["SCOT_FechaEmision"].Width = 100;

            this.grdItemsServicio.Columns["SCOT_Origen"].IsVisible = false;

            //this.grdItemsServicio.Columns["CCOT_IngresoGasto"].ReadOnly = true;


            //this.grdItemsServicio.Columns["SERV_Codigo"].TextAlignment = ContentAlignment.MiddleLeft;
            this.grdItemsServicio.Columns["TIPE_Desc"].TextAlignment = ContentAlignment.MiddleLeft;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex); }
      }
      private void AddServicio()
      {
         try
         {
            Entities.Det_Cotizacion_OV_Servicio _servicio = new Entities.Det_Cotizacion_OV_Servicio();
            Int32 _SCOT_Item = 0;
            if (((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicio.DataSource).Count > 0)
            { _SCOT_Item = ((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicio.DataSource).Max(scot => scot.SCOT_Item); }
            _servicio.SCOT_Item = _SCOT_Item + 1;
            _servicio.SCOT_Origen = "D";
            _servicio.AUDI_UsrCrea = Presenter.Session.UserName;
            _servicio.AUDI_FecCrea = Presenter.Session.Fecha;
            _servicio.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            BSItemsServicio.Add(_servicio);
            BSItemsServicio.ResetBindings(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un servicio", ex); }
      }
      private void DelServicio()
      {
         try
         {
            if (BSItemsServicio.Current != null && BSItemsServicio.Current is Entities.Det_Cotizacion_OV_Servicio)
            {
               Entities.Det_Cotizacion_OV_Servicio _servicio = (Entities.Det_Cotizacion_OV_Servicio)BSItemsServicio.Current;
               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Esta seguro que desea eliminar el servicio?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
               {
                  if (_servicio.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
                  {
                     _servicio.AUDI_UsrMod = Presenter.Session.UserName;
                     _servicio.AUDI_FecMod = Presenter.Session.Fecha;
                     _servicio.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                     Presenter.Item.ItemsServicioDeleted.Add(_servicio);
                  }
                  BSItemsServicio.RemoveCurrent();
                  BSItemsServicio.ResetBindings(true);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar un servicio", ex); }
      }
      private void SetDatosServicios(Int32 rowIndex)
      {
         try
         {
            Int32 _SERV_Codigo;
            if (grdItemsServicio.Rows[rowIndex].Cells["SERV_Codigo"].Value != null && Int32.TryParse(grdItemsServicio.Rows[rowIndex].Cells["SERV_Codigo"].Value.ToString(), out _SERV_Codigo))
            {
               Entities.Servicio _itemServicio = Presenter.ListServicio.Where(serv => serv.SERV_Codigo == _SERV_Codigo).FirstOrDefault();
               if (_itemServicio != null)
               {
                  //grdItemsServicio.Rows[rowIndex].Cells["SCOT_PrecioUni"].Value = _itemServicio.SERV_Valor;
                  //grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = _itemServicio.SERV_AfeIgv;
                  //grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeDet"].Value = _itemServicio.SERV_AfeDet;
                  //grdItemsServicio.Rows[rowIndex].Cells["SCOT_PreSugerido"].Value = _itemServicio.SERV_Valor;

                  switch (_itemServicio.SERV_TipoMov)
                  {
                     case "A":
                        grdItemsServicio.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value = null;
                        break;
                     case "C":
                        grdItemsServicio.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value = "E";
                        break;
                     case "I":
                        grdItemsServicio.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value = "I";
                        if (ENTC_CodCliente.Value != null)
                        {
                           grdItemsServicio.Rows[rowIndex].Cells["TIPE_Codigo"].Value = Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Cliente);
                           grdItemsServicio.Rows[rowIndex].Cells["ENTC_Codigo"].Value = ENTC_CodCliente.Value.ENTC_Codigo;
                           grdItemsServicio.Rows[rowIndex].Cells["ENTC_NomCom"].Value = ENTC_CodCliente.Value.ENTC_NomCompleto;
                        }
                        break;
                  }

                  if (_itemServicio.SERV_AfeIgv.HasValue)
                  { grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = _itemServicio.SERV_AfeIgv.Value; }
                  if (_itemServicio.SERV_AfeDet.HasValue)
                  { grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeDet"].Value = _itemServicio.SERV_AfeDet.Value; }

                  //grdItemsServicio.Rows[rowIndex].Cells["SCOT_Exonerado"].Value = _itemServicio.SERV_Ex;
                  grdItemsServicio.Rows[rowIndex].Cells["SCOT_PreSugerido"].Value = _itemServicio.SERV_Valor;
                  grdItemsServicio.Rows[rowIndex].Cells["SCOT_PrecioUni"].Value = _itemServicio.SERV_Valor;
                  grdItemsServicio.Rows[rowIndex].Cells["TIPO_TabMnd"].Value = _itemServicio.TIPO_TabMND;
                  grdItemsServicio.Rows[rowIndex].Cells["TIPO_CodMnd"].Value = _itemServicio.TIPO_CodMND;
                  grdItemsServicio.Rows[rowIndex].Cells["CONS_TabBas"].Value = _itemServicio.CONS_TabBAS;
                  grdItemsServicio.Rows[rowIndex].Cells["CONS_CodBas"].Value = _itemServicio.CONS_CodBAS;

                  Decimal _SCOT_Cantidad = (Decimal)1.00;
                  Nullable<Decimal> _DCOT_Peso = (Decimal)0.00;
                  Nullable<Decimal> _DCOT_Volumen = (Decimal)0.00;

                  switch (_itemServicio.CONS_CodBAS)
                  {
                     case Delfin.Controls.variables.CONSBASFIJO:
                        _SCOT_Cantidad = (Decimal)1.00;
                        //grdItemsServicio.Rows[rowIndex].Cells["SCOT_Cantidad"].Value = itemEntidadServicio.ESER_Cantidad;
                        break;
                     case Delfin.Controls.variables.CONSBASCONTENEDOR:
                        _SCOT_Cantidad = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.Contenedor);
                        break;
                     case Delfin.Controls.variables.CONSBASTEUS:
                        _SCOT_Cantidad = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.TEUS);
                        break;
                     case Delfin.Controls.variables.CONSBASPESOVOLUMEN:
                        _DCOT_Peso = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.DCOT_Peso);
                        _DCOT_Volumen = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.DCOT_Volumen);
                        if (_DCOT_Peso.HasValue && _DCOT_Volumen.HasValue)
                        {
                           if (_DCOT_Peso.Value > _DCOT_Volumen.Value)
                           { _SCOT_Cantidad = _DCOT_Peso.Value; }
                           else
                           { _SCOT_Cantidad = _DCOT_Volumen.Value; }
                        }
                        break;
                     default:
                        break;
                  }
                  grdItemsServicio.Rows[rowIndex].Cells["SCOT_Cantidad"].Value = _SCOT_Cantidad;


                  ObservableCollection<Entities.ServiciosDocumentos> _serviciosDocumento = Presenter.Client.GetAllServiciosDocumentosByServCodigo(_itemServicio.SERV_Codigo).ToObservableCollection();//.Where(doc => doc.SEDO_Seleccionar == 1)

                  String _movimiento = (grdItemsServicio.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value != null ? grdItemsServicio.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value.ToString() : null);
                  if (!String.IsNullOrEmpty(_movimiento))
                  {
                     SetTipoDocumentoServicio(rowIndex);

                     //if (_movimiento == "E") { _movimiento = "C"; }
                     //ObservableCollection<Entities.Tipos> _tiposTDO = (from tdo in Presenter.ListTiposTDO
                     //                                                  join doc in _serviciosDocumento on tdo.TIPO_CodTipo equals doc.TIPO_CodTDO
                     //                                                  where doc.SEDO_Tipo == _movimiento
                     //                                                  select tdo).ToObservableCollection();

                     //grdItemsServicio.Rows[rowIndex].Cells["TIPO_TabTDO"].Value = _tiposTDO[0].TIPO_CodTabla;
                     //grdItemsServicio.Rows[rowIndex].Cells["TIPO_CodTDO"].Value = _tiposTDO[0].TIPO_CodTipo;
                     //grdItemsServicio.Rows[rowIndex].Cells["TIPO_DescTDO"].Value = _tiposTDO[0].TIPO_Desc1;
                  }
               }
            }
         }
         catch (Exception)
         { }
      }
      private void SetTipoDocumentoServicio(Int32 RowIndex)
      {
         try
         {
            Int32 _SERV_Codigo;

            if (grdItemsServicio.Rows[RowIndex].Cells["SERV_Codigo"].Value != null && Int32.TryParse(grdItemsServicio.Rows[RowIndex].Cells["SERV_Codigo"].Value.ToString(), out _SERV_Codigo))
            {
               Entities.Servicio _servicio = Presenter.Client.GetOneServicio(_SERV_Codigo);
               ObservableCollection<Entities.ServiciosDocumentos> _serviciosDocumento = Presenter.Client.GetAllServiciosDocumentosByServCodigo(_SERV_Codigo).ToObservableCollection();//.Where(doc => doc.SEDO_Seleccionar == 1)

               String _movimiento = (grdItemsServicio.Rows[RowIndex].Cells["CCOT_IngresoGasto"].Value != null ? grdItemsServicio.Rows[RowIndex].Cells["CCOT_IngresoGasto"].Value.ToString() : null);
               if (!String.IsNullOrEmpty(_movimiento))
               {
                  if (_movimiento == "E") { _movimiento = "C"; }

                  if (_movimiento == "I" && ENTC_CodCliente.Value != null && grdItemsServicio.Rows[RowIndex].Cells["ENTC_Codigo"].Value == null)
                  {
                     grdItemsServicio.Rows[RowIndex].Cells["TIPE_Codigo"].Value = Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Cliente);
                     grdItemsServicio.Rows[RowIndex].Cells["ENTC_Codigo"].Value = ENTC_CodCliente.Value.ENTC_Codigo;
                     grdItemsServicio.Rows[RowIndex].Cells["ENTC_NomCom"].Value = ENTC_CodCliente.Value.ENTC_NomCompleto;
                  }

                  ObservableCollection<Entities.Tipos> _tiposTDO = (from tdo in Presenter.ListTiposTDO
                                                                    join doc in _serviciosDocumento on tdo.TIPO_CodTipo equals doc.TIPO_CodTDO
                                                                    where doc.SEDO_Tipo == _movimiento
                                                                    select tdo).ToObservableCollection();
                  if ((_movimiento == "I" && _servicio.SERV_CuenIngreso.StartsWith("70")) || (_movimiento == "C" && _servicio.SERV_CuenCosto.StartsWith("70")))
                  {
                     Boolean _tieneRUC = false;

                     Int16 _TIPE_Codigo = -1;
                     Int32 _ENTC_Codigo = -1;
                     if (grdItemsServicio.Rows[RowIndex].Cells["TIPE_Codigo"].Value != null && Int16.TryParse(grdItemsServicio.Rows[RowIndex].Cells["TIPE_Codigo"].Value.ToString(), out _TIPE_Codigo))
                     {
                        if (grdItemsServicio.Rows[RowIndex].Cells["ENTC_Codigo"].Value != null && Int32.TryParse(grdItemsServicio.Rows[RowIndex].Cells["ENTC_Codigo"].Value.ToString(), out _ENTC_Codigo))
                        {
                           var _entidad = Presenter.Client.GetOneEntidad(_ENTC_Codigo, _TIPE_Codigo, true);
                           _tieneRUC = _entidad.TIPO_CodTDI == "001";
                        }
                     }

                     //001 => FAC
                     //003 => BOL
                     //007 => NC
                     var _tipoTDO = _tiposTDO.Where(ttdo => ttdo.TIPO_CodTipo == (_movimiento == "I" ? (_tieneRUC ? "001" : "003") : "007")).FirstOrDefault();

                     String _movimientodesc = "";
                     String _documentodesc = "";
                     switch (((_movimiento == "I" ? (_tieneRUC ? "001" : "003") : "007")))
                     {
                        case "001":
                           _movimientodesc = "Ingreso";
                           _documentodesc = "Factura";
                           break;
                        case "003":
                           _movimientodesc = "Ingreso";
                           _documentodesc = "Boleta";
                           break;
                        case "007":
                           _movimientodesc = "Egreso";
                           _documentodesc = "Nota Credito";
                           break;
                     }

                     if (_tipoTDO != null)
                     {
                        grdItemsServicio.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = _tipoTDO.TIPO_CodTabla;
                        grdItemsServicio.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = _tipoTDO.TIPO_CodTipo;
                        grdItemsServicio.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = _tipoTDO.TIPO_Desc1;
                     }
                     else
                     { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Configuración de Servicios", String.Format("Debe ingresar al mantenimiento de Servicios editar el servicio {0} y configurar el documento {1} para el tipo de movimiento {2}.", _servicio.SERV_Nombre_SPA, _documentodesc, _movimientodesc)); }

                  }
                  else
                  {
                     if (_tiposTDO.Count > 0)
                     {
                        grdItemsServicio.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = _tiposTDO[0].TIPO_CodTabla;
                        grdItemsServicio.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = _tiposTDO[0].TIPO_CodTipo;
                        grdItemsServicio.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = _tiposTDO[0].TIPO_Desc1;
                     }
                  }
               }
            }
         }
         catch (Exception)
         { }
      }

      private void SeleccionarProveedor(Int32 rowIndex)
      {
         try
         {
            Nullable<Int32> _ENTC_CodTransportista = null;
            if (ENTC_CodTransportista.Value != null)
            { _ENTC_CodTransportista = ENTC_CodTransportista.Value.ENTC_Codigo; }

            Nullable<Int32> _ENTC_CodAgente = null;
            if (txaENTC_CodAgente.Value != null)
            { _ENTC_CodAgente = txaENTC_CodAgente.Value.ENTC_Codigo; }

            Nullable<Int32> _ENTC_CodShipper = null;
            if (ENTC_CodShipper.Value != null)
            { _ENTC_CodShipper = ENTC_CodShipper.Value.ENTC_Codigo; }

            Nullable<Int32> _ENTC_CodConsignee = null;
            if (ENTC_CodConsignee.Value != null)
            { _ENTC_CodConsignee = ENTC_CodConsignee.Value.ENTC_Codigo; }


            COM007PView _seleccionar = new COM007PView(Presenter.ContainerService, ENTC_CodCliente.Value != null ? ENTC_CodCliente.Value.ENTC_Codigo : -1, _ENTC_CodTransportista, _ENTC_CodAgente, _ENTC_CodShipper, _ENTC_CodConsignee);
            if (_seleccionar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               if (_seleccionar.Proveedor != null)
               {
                  grdItemsServicio.Rows[rowIndex].Cells["TIPE_Codigo"].Value = _seleccionar.TipoEntidad;
                  grdItemsServicio.Rows[rowIndex].Cells["ENTC_Codigo"].Value = _seleccionar.Proveedor.ENTC_Codigo;
                  grdItemsServicio.Rows[rowIndex].Cells["ENTC_NomCom"].Value = _seleccionar.Proveedor.ENTC_NomCompleto;
               }
               else
               {
                  grdItemsServicio.Rows[rowIndex].Cells["TIPE_Codigo"].Value = null;
                  grdItemsServicio.Rows[rowIndex].Cells["ENTC_Codigo"].Value = null;
                  grdItemsServicio.Rows[rowIndex].Cells["ENTC_NomCom"].Value = null;
               }
            }
            else
            {
               grdItemsServicio.Rows[rowIndex].Cells["TIPE_Codigo"].Value = null;
               grdItemsServicio.Rows[rowIndex].Cells["ENTC_Codigo"].Value = null;
               grdItemsServicio.Rows[rowIndex].Cells["ENTC_NomCom"].Value = null;
            }
         }
         catch (Exception)
         { }
      }
      private void SeleccionarTipoDocumento(Int32 RowIndex)
      {
         try
         {
            Int32 _SERV_Codigo;

            if (grdItemsServicio.Rows[RowIndex].Cells["SERV_Codigo"].Value != null && Int32.TryParse(grdItemsServicio.Rows[RowIndex].Cells["SERV_Codigo"].Value.ToString(), out _SERV_Codigo))
            {
               ObservableCollection<Entities.ServiciosDocumentos> _serviciosDocumento = Presenter.Client.GetAllServiciosDocumentosByServCodigo(_SERV_Codigo).ToObservableCollection();//.Where(doc => doc.SEDO_Seleccionar == 1)

               String _movimiento = (grdItemsServicio.Rows[RowIndex].Cells["CCOT_IngresoGasto"].Value != null ? grdItemsServicio.Rows[RowIndex].Cells["CCOT_IngresoGasto"].Value.ToString() : null);
               if (String.IsNullOrEmpty(_movimiento))
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Ayuda Tipos de Documento", "Debe seleccionar el si es Ingreso o Egreso."); }
               else
               {
                  if (_movimiento == "E") { _movimiento = "C"; }
                  ObservableCollection<Entities.Tipos> _tiposTDO = (from tdo in Presenter.ListTiposTDO
                                                                    join doc in _serviciosDocumento on tdo.TIPO_CodTipo equals doc.TIPO_CodTDO
                                                                    where doc.SEDO_Tipo == _movimiento
                                                                    select tdo).ToObservableCollection();

                  if (_tiposTDO.Count == 0)
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Ayuda Tipos de Documento", "No se encontraron Tipos de Documentos Configurados para el servicio seleccionado.");
                  }
                  else if (_tiposTDO.Count == 1)
                  {
                     grdItemsServicio.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = _tiposTDO[0].TIPO_CodTabla;
                     grdItemsServicio.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = _tiposTDO[0].TIPO_CodTipo;
                     grdItemsServicio.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = _tiposTDO[0].TIPO_Desc1;
                  }
                  else
                  {
                     List<Infrastructure.WinForms.Controls.ColumnaAyuda> _columnas = new List<Infrastructure.WinForms.Controls.ColumnaAyuda>();
                     _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
                     {
                        Index = 0,
                        ColumnName = "TIPO_Desc1",
                        ColumnCaption = "Tipo de Documento",
                        Alineacion = DataGridViewContentAlignment.MiddleLeft,
                        Width = 250,
                        DataType = typeof(System.String),
                        Format = null
                     });
                     _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
                     {
                        Index = 1,
                        ColumnName = "TIPO_CodTipo",
                        ColumnCaption = "Código Tipo de Documento",
                        Alineacion = DataGridViewContentAlignment.MiddleRight,
                        Width = 100,
                        DataType = typeof(System.Int32),
                        Format = null
                     });
                     Infrastructure.WinForms.Controls.Ayuda x_Ayuda = new Infrastructure.WinForms.Controls.Ayuda("Ayuda Tipo de Documento", _tiposTDO.ToDataTable(), false, _columnas);

                     if (x_Ayuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                     {
                        String _TIPO_CodTDO;
                        if (!String.IsNullOrEmpty(x_Ayuda.Respuesta.Rows[0]["TIPO_CodTipo"].ToString()))
                        {

                           _TIPO_CodTDO = x_Ayuda.Respuesta.Rows[0]["TIPO_CodTipo"].ToString();
                           Entities.Tipos _tipoTDO = Presenter.ListTiposTDO.Where(ttdo => ttdo.TIPO_CodTipo == _TIPO_CodTDO).FirstOrDefault();

                           if (_tipoTDO != null)
                           {
                              grdItemsServicio.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = _tipoTDO.TIPO_CodTabla;
                              grdItemsServicio.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = _tipoTDO.TIPO_CodTipo;
                              grdItemsServicio.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = _tipoTDO.TIPO_Desc1;
                           }
                           else
                           {
                              grdItemsServicio.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = null;
                              grdItemsServicio.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = null;
                              grdItemsServicio.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = null;
                           }
                        }
                        else
                        {
                           grdItemsServicio.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = null;
                           grdItemsServicio.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = null;
                           grdItemsServicio.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = null;
                        }
                     }
                     else
                     {
                        grdItemsServicio.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = null;
                        grdItemsServicio.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = null;
                        grdItemsServicio.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = null;
                     }
                  }
               }
            }
         }
         catch (Exception)
         { }
      }

      private void SetTipoDocumentoServicios()
      {
         try
         {
            foreach (Entities.Det_Cotizacion_OV_Servicio _itemDet_Cotizacion_OV_Servicio in Presenter.Item.ItemsServicio)
            {
               if (String.IsNullOrEmpty(_itemDet_Cotizacion_OV_Servicio.TIPO_CodTDO) && !String.IsNullOrEmpty(_itemDet_Cotizacion_OV_Servicio.CCOT_IngresoGasto))
               {
                  String _movimiento = _itemDet_Cotizacion_OV_Servicio.CCOT_IngresoGasto;
                  if (_movimiento == "E") { _movimiento = "C"; }

                  ObservableCollection<Entities.ServiciosDocumentos> _serviciosDocumento = Presenter.Client.GetAllServiciosDocumentosByServCodigo(_itemDet_Cotizacion_OV_Servicio.SERV_Codigo).ToObservableCollection();//.Where(doc => doc.SEDO_Seleccionar == 1)
                  ObservableCollection<Entities.Tipos> _tiposTDO = (from tdo in Presenter.ListTiposTDO
                                                                    join doc in _serviciosDocumento on tdo.TIPO_CodTipo equals doc.TIPO_CodTDO
                                                                    where doc.SEDO_Tipo == _movimiento
                                                                    select tdo).ToObservableCollection();

                  if (_tiposTDO.Count > 0)
                  {
                     _itemDet_Cotizacion_OV_Servicio.TIPO_TabTDO = _tiposTDO[0].TIPO_CodTabla;
                     _itemDet_Cotizacion_OV_Servicio.TIPO_CodTDO = _tiposTDO[0].TIPO_CodTipo;
                     _itemDet_Cotizacion_OV_Servicio.TIPO_DescTDO = _tiposTDO[0].TIPO_Desc1;
                  }
               }
            }
         }
         catch (Exception)
         { }
      }

      private void ActualizarCantidadesServicio()
      {
         try
         {
            foreach (var item in grdItemsServicio.Rows)
            {
               Decimal _SCOT_Cantidad = (Decimal)0.00;
               switch (item.Cells["CONS_CodBAS"].Value.ToString())
               {
                  case Delfin.Controls.variables.CONSBASCONTENEDOR:
                     _SCOT_Cantidad = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.Contenedor);
                     item.Cells["SCOT_Cantidad"].Value = _SCOT_Cantidad;
                     break;
                  case Delfin.Controls.variables.CONSBASTEUS:
                     _SCOT_Cantidad = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Sum(dcot => dcot.TEUS);
                     item.Cells["SCOT_Cantidad"].Value = _SCOT_Cantidad;
                     break;
               }
            }
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Eventos ]
      private void grdItemsServicio_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
      {
         if (e.Column.Name == "SERV_Codigo")
         { SetDatosServicios(e.RowIndex); }
         else if (e.Column.Name == "CCOT_IngresoGasto")
         { SetTipoDocumentoServicio(e.RowIndex); }
         else if (e.Column.Name == "CONS_CodBas")
         { CalcularCantidadBase(e.RowIndex); }
      }
      private void grdItemsServicio_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Entidad":
                     SeleccionarProveedor(((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex);
                     break;
                  case "Tipo Documento":
                     SeleccionarTipoDocumento(((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex);
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el botón para seleccionar el proveedor.", ex); }

      }
      private void grdItemsServicio_CurrentCellChanged(object sender, Telerik.WinControls.UI.CurrentCellChangedEventArgs e)
      {
         try
         {
            Int32 rowIndex = e.CurrentCell.RowInfo.Index;
            if (e.NewCell.ColumnInfo.Name == "CCOT_IngresoGasto" && grdItemsServicio.Rows[rowIndex].Cells["SERV_Codigo"] != null)
            {
               grdItemsServicio.Rows[rowIndex].Cells["CCOT_IngresoGasto"].ReadOnly = true;

               Int32 _SERV_Codigo;
               if (grdItemsServicio.Rows[rowIndex].Cells["SERV_Codigo"].Value != null && Int32.TryParse(grdItemsServicio.Rows[rowIndex].Cells["SERV_Codigo"].Value.ToString(), out _SERV_Codigo))
               {
                  Entities.Servicio _itemServicio = Presenter.ListServicio.Where(serv => serv.SERV_Codigo == _SERV_Codigo).FirstOrDefault();
                  if (_itemServicio != null)
                  {
                     switch (_itemServicio.SERV_TipoMov)
                     {
                        case "A":
                           grdItemsServicio.Rows[rowIndex].Cells["CCOT_IngresoGasto"].ReadOnly = false;
                           break;
                        //case "C":
                        //case "I":
                        //   grdItemsServicio.Rows[rowIndex].Cells["CCOT_IngresoGasto"].ReadOnly = true;
                        //   break;
                     }
                  }
               }
            }
         }
         catch (Exception)
         { }
      }

      private void btnAddServicio_Click(object sender, EventArgs e)
      { AddServicio(); }
      private void btnDelServicio_Click(object sender, EventArgs e)
      { DelServicio(); }
      #endregion
      #endregion

      #region [ Metodos Documentos ]
      //Entities.Det_Cotizacion_OV_Documento ItemDocumento = null;
      //private void InstanceItemDocumento(Boolean ItemEnabled, Boolean EnabledGuardar)
      //{
      //   try
      //   {
      //      TIPO_CodDTM.Enabled = ItemEnabled;
      //      DOOV_Feeder.Enabled = ItemEnabled;
      //      TIPO_CodVapor.Enabled = ItemEnabled;
      //      DOOV_Viaje.Enabled = ItemEnabled;
      //      DOOV_ETDF.Enabled = ItemEnabled;
      //      DOOV_ETDM.Enabled = ItemEnabled;
      //      DOOV_ETA.Enabled = ItemEnabled;
      //      DOOV_Cntr.Enabled = ItemEnabled;
      //      DOOV_HBL.Enabled = ItemEnabled;
      //      DOOV_MBL.Enabled = ItemEnabled;

      //      btnNuevoDocumento.Enabled = !EnabledGuardar;
      //      btnEditarDocumento.Enabled = (!EnabledGuardar && ItemDocumento != null);
      //      btnEliminarDocumento.Enabled = (!EnabledGuardar && ItemDocumento != null);
      //      btnGuardarDocumento.Enabled = EnabledGuardar;
      //      btnDeshacerDocumento.Enabled = EnabledGuardar;
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetInstanceView, ex); }
      //}
      //private void ClearItemDocumento()
      //{
      //   try
      //   {
      //      TIPO_CodDTM.TiposSelectedValue = null;
      //      DOOV_Feeder.Text = String.Empty;
      //      TIPO_CodVapor.TiposSelectedValue = null;
      //      DOOV_Viaje.Text = String.Empty;
      //      DOOV_ETDF.NSFecha = null;
      //      DOOV_ETDM.NSFecha = null;
      //      DOOV_ETA.NSFecha = null;
      //      DOOV_Cntr.Text = String.Empty;
      //      DOOV_HBL.Text = String.Empty;
      //      DOOV_MBL.Text = String.Empty;
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ClearItem, ex); }
      //}
      //private void GetItemDocumento()
      //{
      //   try
      //   {
      //      if (TIPO_CodDTM.TiposSelectedItem != null)
      //      {
      //         ItemDocumento.TIPO_TabDTM = TIPO_CodDTM.TiposSelectedItem.TIPO_CodTabla;
      //         ItemDocumento.TIPO_CodDTM = TIPO_CodDTM.TiposSelectedItem.TIPO_CodTipo;
      //         ItemDocumento.TIPO_DescDTM = TIPO_CodDTM.TiposSelectedItem.TIPO_Desc1;
      //      }
      //      else
      //      {
      //         ItemDocumento.TIPO_TabDTM = null;
      //         ItemDocumento.TIPO_CodDTM = null;
      //         ItemDocumento.TIPO_DescDTM = null;
      //      }
      //      ItemDocumento.DOOV_Feeder = DOOV_Feeder.Text;
      //      if (TIPO_CodVapor.TiposSelectedItem != null)
      //      { 
      //         ItemDocumento.TIPO_TabVapor = TIPO_CodVapor.TiposSelectedItem.TIPO_CodTabla;
      //         ItemDocumento.TIPO_CodVapor = TIPO_CodVapor.TiposSelectedItem.TIPO_CodTipo;
      //         ItemDocumento.TIPO_DescVapor = TIPO_CodVapor.TiposSelectedItem.TIPO_Desc1;
      //      }
      //      else
      //      {
      //         ItemDocumento.TIPO_TabVapor = null;
      //         ItemDocumento.TIPO_CodVapor = null;
      //         ItemDocumento.TIPO_DescVapor = null;
      //      }
      //      ItemDocumento.DOOV_Viaje = DOOV_Viaje.Text;
      //      ItemDocumento.DOOV_ETDF  =DOOV_ETDF.NSFecha;
      //      ItemDocumento.DOOV_ETDM = DOOV_ETDM.NSFecha;
      //      ItemDocumento.DOOV_ETA = DOOV_ETA.NSFecha;
      //      ItemDocumento.DOOV_Cntr =  DOOV_Cntr.Text;
      //      ItemDocumento.DOOV_HBL = DOOV_HBL.Text;
      //      ItemDocumento.DOOV_MBL = DOOV_MBL.Text;
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.GetItem, ex); }
      //}
      //private void SetItemDocumento()
      //{
      //   try
      //   {
      //      TIPO_CodDTM.TiposSelectedValue = ItemDocumento.TIPO_CodDTM;
      //      DOOV_Feeder.Text = ItemDocumento.DOOV_Feeder;
      //      TIPO_CodVapor.TiposSelectedValue = ItemDocumento.TIPO_CodVapor;
      //      DOOV_Viaje.Text = ItemDocumento.DOOV_Viaje;
      //      DOOV_ETDF.NSFecha = ItemDocumento.DOOV_ETDF;
      //      DOOV_ETDM.NSFecha = ItemDocumento.DOOV_ETDM;
      //      DOOV_ETA.NSFecha = ItemDocumento.DOOV_ETA;
      //      DOOV_Cntr.Text = ItemDocumento.DOOV_Cntr;
      //      DOOV_HBL.Text = ItemDocumento.DOOV_HBL;
      //      DOOV_MBL.Text = ItemDocumento.DOOV_MBL;
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetItem, ex); }
      //}
      //private void MostrarErrorItemDocumento()
      //{
      //   try
      //   {
      //      Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Det_Cotizacion_OV_Documento>.Validate(ItemDocumento, pageDocumentos, errorProvider2);
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      //}

      //private void BSItemsDocumentos_CurrentItemChanged(object sender, EventArgs e)
      //{
      //   try
      //   {
      //      if (BSItemsDocumentos.Current != null && BSItemsDocumentos.Current is Entities.Det_Cotizacion_OV_Documento)
      //      { ItemDocumento = ((Entities.Det_Cotizacion_OV_Documento)BSItemsDocumentos.Current); }
      //      else
      //      { ItemDocumento = null; }
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.CurrentItemChanged, ex); }
      //}
      //private void btnNuevoDocumento_Click(object sender, EventArgs e)
      //{
      //   try
      //   {
      //      ClearItemDocumento();
      //      ItemDocumento = new Entities.Det_Cotizacion_OV_Documento();
      //      ItemDocumento.AUDI_UsrCrea = Presenter.Session.UserName;
      //      ItemDocumento.AUDI_FecCrea = Presenter.Session.Fecha;
      //      ItemDocumento.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
      //      SetItemDocumento();
      //      InstanceItemDocumento(true, true);
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      //}
      //private void btnEditarDocumento_Click(object sender, EventArgs e)
      //{
      //   try
      //   {
      //      if (ItemDocumento != null)
      //      {
      //         ClearItemDocumento();
      //         ItemDocumento.AUDI_UsrMod = Presenter.Session.UserName;
      //         ItemDocumento.AUDI_FecMod = Presenter.Session.Fecha;
      //         ItemDocumento.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
      //         SetItemDocumento();
      //         InstanceItemDocumento(true, true);
      //      }
      //      else
      //      { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un elemento de la grilla"); }
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      //}
      //private void btnEliminarDocumento_Click(object sender, EventArgs e)
      //{
      //   try
      //   {
      //      if (ItemDocumento != null)
      //      {
      //         System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
      //         if (_result == System.Windows.Forms.DialogResult.Yes)
      //         {
      //            if (ItemDocumento.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
      //            {
      //               ItemDocumento.AUDI_UsrMod = Presenter.Session.UserName;
      //               ItemDocumento.AUDI_FecMod = Presenter.Session.Fecha;
      //               ItemDocumento.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
      //               Presenter.Item.ItemsDocumentoDeleted.Add(ItemDocumento);
      //            }
      //            BSItemsDocumentos.RemoveCurrent();
      //            BSItemsDocumentos.ResetBindings(true);
      //         }
      //      }
      //      else
      //      { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un elemento de la grilla"); }
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex); }
      //}
      //private void btnGuardarDocumento_Click(object sender, EventArgs e)
      //{
      //   try
      //   {
      //      if (ItemDocumento != null)
      //      {
      //         GetItemDocumento();
      //         if (ItemDocumento.Validar())
      //         {
      //            if (ItemDocumento.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
      //            { BSItemsDocumentos.Add(ItemDocumento); }
      //            else
      //            { BSItemsDocumentos[BSItemsDocumentos.Position] = ItemDocumento; }

      //            BSItemsDocumentos.ResetBindings(true);
      //            ItemDocumento = null;
      //            ClearItemDocumento();
      //            if (BSItemsDocumentos.Current != null && BSItemsDocumentos.Current is Entities.Det_Cotizacion_OV_Documento)
      //            { ItemDocumento = ((Entities.Det_Cotizacion_OV_Documento)BSItemsDocumentos.Current); }
      //            else
      //            { ItemDocumento = null; }
      //            InstanceItemDocumento(false, false);
      //         }
      //         else
      //         { MostrarErrorItemDocumento(); }
      //      }
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex); }
      //}
      //private void btnDeshacerDocumento_Click(object sender, EventArgs e)
      //{
      //   try
      //   {
      //      ClearItemDocumento();
      //      InstanceItemDocumento(false, false);
      //      BSItemsDocumentos.MoveFirst();
      //   }
      //   catch (Exception)
      //   { }
      //}
      #endregion

      #region [ Metodos Contrato ]
      private void AyudaContrato(Boolean ActualizarContrato)
      {
         try
         {
            if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
            {
               if (cmbCONS_CodVia.ConstantesSelectedItem != null)
               {
                  if (CCOT_FecEmi.NSFecha.HasValue && CCOT_FecVcto.NSFecha.HasValue)
                  {
                     if (ENTC_CodTransportista.Value != null)
                     {
                        Nullable<Int32> _PUER_CodOrigen = null;
                        if (txaPUER_CodOrigen.SelectedItem != null) { _PUER_CodOrigen = txaPUER_CodOrigen.SelectedItem.PUER_Codigo; }
                        Nullable<Int32> _PUER_CodDestino = null;
                        if (txaPUER_CodDestino.SelectedItem != null) { _PUER_CodDestino = txaPUER_CodDestino.SelectedItem.PUER_Codigo; }

                        Presenter.AyudaContrato(ENTC_CodTransportista.Value, cmbCONS_CodRGM.ConstantesSelectedItem, cmbCONS_CodVia.ConstantesSelectedItem, CCOT_FecEmi.NSFecha.Value, CCOT_FecVcto.NSFecha.Value, _PUER_CodOrigen, _PUER_CodDestino, ActualizarContrato);
                     }
                     else
                     { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un Transportista para poder buscar un Contrato."); }
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar la Fecha de Emisión y Vencimiento para poder buscar un Contrato."); }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar una Vía para poder buscar un Contrato."); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un Régimen para poder buscar un Contrato."); }
         }
         catch (Exception)
         { }
      }
      public void ClearItemContrato()
      {
         try
         {
            CONT_Numero.Text = String.Empty;
            CONT_Descrip.Text = String.Empty;
            //TIPO_CodPAIOrigen.TiposSelectedValue = null;
            txaPUER_CodOrigen.Clear();
            //TIPO_CodPAIDestino.TiposSelectedValue = null;
            txaPUER_CodDestino.Clear();
            TIPO_CodMND.TiposSelectedValue = null;

            CONT_Numero.AyudaButton.Visible = true;
            CONT_Numero.Width = 194;
            btnCambiarContrato.Visible = false;
         }
         catch (Exception)
         { }
      }
      public void SetItemContrato(Boolean ActualizarContrato)
      {
         try
         {
            if (Presenter.Item.ItemContrato != null)
            {
               CONT_Numero.SetValue(Presenter.Item.ItemContrato, Presenter.Item.ItemContrato.CONT_Numero);
               CONT_Descrip.Text = Presenter.Item.ItemContrato.CONT_Descrip;
               //TIPO_CodPAIOrigen.TiposSelectedValue = Presenter.Item.ItemContrato.TIPO_CodPaisOrigen;
               if (Presenter.Item.ItemContrato.PUER_CodigoOrigen.HasValue)
               { txaPUER_CodOrigen.SelectedValue = Presenter.Item.ItemContrato.PUER_CodigoOrigen.Value; }
               //TIPO_CodPAIDestino.TiposSelectedValue = Presenter.Item.ItemContrato.TIPO_CodPaisDestino;
               if (Presenter.Item.ItemContrato.PUER_CodigoDestino.HasValue)
               { txaPUER_CodDestino.SelectedValue = Presenter.Item.ItemContrato.PUER_CodigoDestino.Value; }
               TIPO_CodMND.TiposSelectedValue = Presenter.Item.ItemContrato.TIPO_CodMND;

               CONT_Numero.AyudaButton.Visible = false;
               CONT_Numero.Width = 165;
               btnCambiarContrato.Visible = true;

               if (ActualizarContrato)
               {
                  Boolean _cambiarPV = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Desea actualizar el Precio de Venta?") == System.Windows.Forms.DialogResult.OK;
                  for (int i = 0; i < grdItemsFlete.Rows.Count; i++)
                  { ConsultarTarifario(i, true, _cambiarPV); }
               }
            }
            else
            {
               CONT_Numero.ClearValue();
               CONT_Numero.AyudaButton.Visible = true;
               CONT_Numero.Width = 194;
               btnCambiarContrato.Visible = false;
            }
         }
         catch (Exception)
         { }
      }

      private void CONT_Numero_AyudaClick(object sender, EventArgs e)
      { AyudaContrato(false); }
      private void CONT_Numero_AyudaClean(object sender, EventArgs e)
      { ClearItemContrato(); }
      private void btnCambiarContrato_Click(object sender, EventArgs e)
      { AyudaContrato(true); }
      #endregion

      #region [ Metodos Viaje ]
      public void ClearItemViaje()
      {
         try
         {
            NVIA_NroViaje.ClearValue();
            NVIA_NroViaje.Text = String.Empty;
            NAVE_Nombre.Text = String.Empty;
            NVIA_FecETA.NSFecha = null;
            NVIA_FecETDMaster.NSFecha = null;
            NVIA_FecCutOff.NSFecha = null;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ClearItem, ex); }
      }
      public void SetItemViaje()
      {
         try
         {
            if (Presenter.Item.ItemNaveViaje != null)
            {
               NVIA_NroViaje.SetValue(Presenter.Item.ItemNaveViaje, Presenter.Item.ItemNaveViaje.NVIA_Codigo.ToString());
               NAVE_Nombre.Text = Presenter.Item.ItemNaveViaje.NAVE_Nombre;
               NVIA_FecETA.NSFecha = Presenter.Item.ItemNaveViaje.NVIA_FecETA_IMPO_ETD_EXPO;
               NVIA_FecETDMaster.NSFecha = Presenter.Item.ItemNaveViaje.NVIA_FecLlega_IMPO_Zarpe_EXPO;
               NVIA_FecCutOff.NSFecha = Presenter.Item.ItemNaveViaje.NVIA_FecCutOff_EXPO;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.GetItem, ex); }
      }

      public void SetNaveViajeRegimen()
      {
         try
         {
            if (Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
            {
               if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
               {
                  if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
                  {
                     btnExportar.Enabled = false;
                     btnExportar.Visible = false;

                     tableDatosViaje.RowStyles[0].Height = 27;
                     lblDOOV_Feeder_IMPO.Visible = true;
                     DOOV_Feeder_IMPO.Visible = true;
                     lblDOOV_FecETDFeeder_IMPO.Visible = true;
                     DOOV_FecETDFeeder_IMPO.Visible = true;

                     lblNVIA_FecCutOff.Visible = false;
                     NVIA_FecCutOff.Visible = false;

                     lblDDOV_FecEmbarque.Text = "Fecha Embarque:";
                     lblNVIA_FecETA.Text = "Fecha ETA:";

                     tableDatosGenerales.RowStyles[9].Height = 27;
                     lblCCOT_EnviaAvisoLlegada.Text = "Aviso de LLegada";
                     lblCCOT_EnviaAvisoLlegada.Visible = true;
                     chkCCOT_EnviaAvisoLlegada.Visible = true;
                  }
                  else
                  {
                     btnExportar.Enabled = true;
                     btnExportar.Visible = true;

                     tableDatosViaje.RowStyles[0].Height = 0;
                     lblDOOV_Feeder_IMPO.Visible = false;
                     DOOV_Feeder_IMPO.Visible = false;
                     lblDOOV_FecETDFeeder_IMPO.Visible = false;
                     DOOV_FecETDFeeder_IMPO.Visible = false;

                     lblNVIA_FecCutOff.Visible = true;
                     NVIA_FecCutOff.Visible = true;

                     lblDDOV_FecEmbarque.Text = "Fecha Zarpe:";
                     lblNVIA_FecETA.Text = "Fecha ETD:";

                     tableDatosGenerales.RowStyles[9].Height = 27;
                     lblCCOT_EnviaAvisoLlegada.Text = "Aviso de Zarpe";
                     lblCCOT_EnviaAvisoLlegada.Visible = true;
                     chkCCOT_EnviaAvisoLlegada.Visible = true;
                  }
               }
               else
               {
                  tableDatosViaje.RowStyles[0].Height = 0;
                  lblDOOV_Feeder_IMPO.Visible = false;
                  DOOV_Feeder_IMPO.Visible = false;
                  lblDOOV_FecETDFeeder_IMPO.Visible = false;
                  DOOV_FecETDFeeder_IMPO.Visible = false;

                  lblNVIA_FecCutOff.Visible = false;
                  NVIA_FecCutOff.Visible = false;

                  lblDDOV_FecEmbarque.Text = "Fecha Embarque:";

                  tableDatosGenerales.RowStyles[9].Height = 0;
                  lblCCOT_EnviaAvisoLlegada.Text = "";
                  lblCCOT_EnviaAvisoLlegada.Visible = false;
                  chkCCOT_EnviaAvisoLlegada.Visible = false;
               }
            }
            else
            {
               tableDatosGenerales.RowStyles[9].Height = 0;
               lblCCOT_EnviaAvisoLlegada.Text = "";
               lblCCOT_EnviaAvisoLlegada.Visible = false;
               chkCCOT_EnviaAvisoLlegada.Visible = false;
            }
         }
         catch (Exception)
         { throw; }
      }

      private void NVIA_NroViaje_AyudaClick(object sender, EventArgs e)
      { Presenter.AyudaNaveViaje(NVIA_NroViaje.Text); }
      private void NVIA_NroViaje_AyudaClean(object sender, EventArgs e)
      { ClearItemViaje(); }

      private void btnAddNaveViaje_Click(object sender, EventArgs e)
      { Presenter.EdicionNaveViaje(true); }
      private void btnEditarNaveViaje_Click(object sender, EventArgs e)
      { Presenter.EdicionNaveViaje(false); }
      #endregion

      #region [ Metodos Novedades ]

      public void ClearItemNovedad()
      {
         try
         {
            OVNO_Descrip.Text = String.Empty;
            CONS_CodNot.ConstantesSelectedValue = null;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ClearItem, ex); }
      }
      public void GetItemNovedad()
      {
         try
         {
            Presenter.ItemNovedad.OVNO_Descrip = OVNO_Descrip.Text;
            if (CONS_CodNot.ConstantesSelectedItem != null)
            {
               Presenter.ItemNovedad.CONS_TabNot = CONS_CodNot.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.ItemNovedad.CONS_CodNot = CONS_CodNot.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.ItemNovedad.CONS_TabNot = null;
               Presenter.ItemNovedad.CONS_CodNot = null;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.GetItem, ex); }
      }
      public void ShowNovedades()
      {
         try
         {
            BSItemsNovedades.DataSource = Presenter.Item.ItemsNovedad;
            BSItemsNovedades.ResetBindings(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al mostrar las novedades.", ex); }
      }
      public void ShowValidationItemNovedad()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Det_Cotizacion_OV_Novedad>.Validate(Presenter.ItemNovedad, pageNovedades, errorProviderDet_Cotizacion_OV_Novedad);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }
      private void AgregarNovedad()
      {
         try
         {
            if (Presenter.AgregarNovedad())
            {
               BSItemsNovedades.DataSource = Presenter.Item.ItemsNovedad;
               BSItemsNovedades.ResetBindings(true);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar la novedad.", ex); }
      }
      private void EnviarNovedades()
      {
         try
         {
            Presenter.EnviarNovedades();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al enviar las novedades.", ex); }
      }

      private void btnNuevoNovedad_Click(object sender, EventArgs e)
      { AgregarNovedad(); }
      private void btnEnviarNovedad_Click(object sender, EventArgs e)
      { EnviarNovedades(); }
      #endregion

      #region [ Metodos Archivos ]
      private void UploadFile()
      {
         try
         {
            if (Presenter.Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
            {
               if (!String.IsNullOrEmpty(OVAR_Archivo.Text) && !String.IsNullOrEmpty(OVAR_Archivo.Text) && Presenter.UploadFile(OVAR_Archivo.FullPath))
               {
                  BSItemsArchivos.DataSource = Presenter.Item.ItemsArchivo;
                  BSItemsArchivos.ResetBindings(true);

                  OVAR_Archivo.FileName = null;
                  OVAR_Archivo.Clear();
                  OVAR_Archivo.Text = null;
                  OVAR_Archivo.Select();
                  OVAR_Archivo.Focus();
               }
               else
               { OVAR_Archivo.Select(); OVAR_Archivo.Focus(); }
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Para poder subir archivos primero debe guardar la Orden de Venta");
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.GetItem, ex); }
      }
      private void DownloadFile()
      {
         try
         {
            if (BSItemsArchivos.Current != null && BSItemsArchivos.Current is Entities.Det_Cotizacion_OV_Archivo)
            { Presenter.DownloadFile(((Entities.Det_Cotizacion_OV_Archivo)BSItemsArchivos.Current)); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetItem, ex); }
      }
      private void SeleccionarItemFile()
      {
         try
         {
            if (Presenter != null)
            {
               if ((grdItemsArchivos.CurrentRow != null && grdItemsArchivos.CurrentRow.DataBoundItem != null && grdItemsArchivos.CurrentRow.DataBoundItem is Entities.Det_Cotizacion_OV_Archivo))
               {
                  Presenter.ItemArchivo = (grdItemsArchivos.CurrentRow.DataBoundItem as Entities.Det_Cotizacion_OV_Archivo);
               }
               else
               { Presenter.ItemArchivo = null; }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }

      private void btnUploadFile_Click(object sender, EventArgs e)
      {
         UploadFile();
      }
      private void btnDownloadFile_Click(object sender, EventArgs e)
      {
         DownloadFile();
      }
      #endregion

      #region [ Metodos Eventos Tareas ]
      public Boolean Edicion { get; set; }
      Entities.Det_Cotizacion_OV_EventosTareas ItemEventoTarea = null;
      public BindingSource BSItemsEventosTareas { get; set; }

      private void FormatGridEventoTarea()
      {
         try
         {

            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsEventosTareas.Columns.Clear();
            this.grdItemsEventosTareas.AllowAddNewRow = false;

            //EVEN_Item         

            //Evento/Tarea
            Telerik.WinControls.UI.GridViewComboBoxColumn _evento = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _evento.Name = "TIPO_CodEVE";
            _evento.HeaderText = "Evento/Tarea";
            _evento.FieldName = "TIPO_CodEVE";
            _evento.ValueMember = "TIPO_CodTipo";
            _evento.DisplayMember = "TIPO_Desc1";
            _evento.DataSource = Presenter.ListTiposEVE;
            this.grdItemsEventosTareas.Columns.Add(_evento);

            //Modulo
            Telerik.WinControls.UI.GridViewComboBoxColumn _modulo = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _modulo.Name = "CONS_CodMOD";
            _modulo.HeaderText = "Modulo";
            _modulo.FieldName = "CONS_CodMOD";
            _modulo.ValueMember = "CONS_CodTipo";
            _modulo.DisplayMember = "CONS_Desc_SPA";
            _modulo.DataSource = Presenter.ListConstantesMOD;
            this.grdItemsEventosTareas.Columns.Add(_modulo);

            //Fecha
            Telerik.WinControls.UI.GridViewDateTimeColumn _fecha = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            _fecha.Name = "EVEN_Fecha";
            _fecha.HeaderText = "Fecha";
            _fecha.FieldName = "EVEN_Fecha";
            _fecha.FormatString = "dd/MM/yyyy hh:mm";
            _fecha.ReadOnly = true;
            this.grdItemsEventosTareas.Columns.Add(_fecha);

            //Cumplida
            Telerik.WinControls.UI.GridViewCheckBoxColumn _cumplida = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _cumplida.Name = "EVEN_Cumplida";
            _cumplida.HeaderText = "Cumplida";
            _cumplida.FieldName = "EVEN_Cumplida";
            _cumplida.ReadOnly = true;
            this.grdItemsEventosTareas.Columns.Add(_cumplida);

            this.grdItemsEventosTareas.Columns.Add("EVEN_Usuario", "Usuario", "EVEN_Usuario");
            this.grdItemsEventosTareas.Columns.Add("EVEN_Observaciones", "Observaciones", "EVEN_Observaciones");

            Telerik.WinControls.UI.GridViewCommandColumn _Observaciones = new Telerik.WinControls.UI.GridViewCommandColumn();
            _Observaciones.Name = "EVEN_ObservacionesPopUp";
            _Observaciones.HeaderText = "";
            _Observaciones.DefaultText = "...";
            _Observaciones.UseDefaultText = true;
            _Observaciones.Tag = "EVEN_ObservacionesPopUp";
            _Observaciones.MinWidth = 20;
            _Observaciones.Width = 20;
            this.grdItemsEventosTareas.Columns.Add(_Observaciones);

            grdItemsEventosTareas.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsEventosTareas);
            grdItemsEventosTareas.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            this.grdItemsEventosTareas.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.FullRowSelect;
            this.grdItemsEventosTareas.MultiSelect = false;

            this.grdItemsEventosTareas.ShowFilteringRow = false;
            this.grdItemsEventosTareas.EnableFiltering = false;
            this.grdItemsEventosTareas.MasterTemplate.EnableFiltering = false;
            this.grdItemsEventosTareas.EnableGrouping = false;
            this.grdItemsEventosTareas.MasterTemplate.EnableGrouping = false;
            this.grdItemsEventosTareas.EnableSorting = false;
            this.grdItemsEventosTareas.MasterTemplate.EnableCustomSorting = false;

            this.grdItemsEventosTareas.ReadOnly = true;
            this.grdItemsEventosTareas.AllowEditRow = false;

            this.grdItemsEventosTareas.Columns["EVEN_Fecha"].ReadOnly = true;
            this.grdItemsEventosTareas.Columns["EVEN_Cumplida"].ReadOnly = false;
            this.grdItemsEventosTareas.Columns["EVEN_Usuario"].ReadOnly = false;
            this.grdItemsEventosTareas.Columns["EVEN_Observaciones"].ReadOnly = true;
            this.grdItemsEventosTareas.Columns["TIPO_CodEVE"].ReadOnly = false;
            this.grdItemsEventosTareas.Columns["CONS_CodMOD"].ReadOnly = false;


            this.grdItemsEventosTareas.Columns["EVEN_Fecha"].Width = 80;
            this.grdItemsEventosTareas.Columns["EVEN_Cumplida"].Width = 60;
            this.grdItemsEventosTareas.Columns["EVEN_Usuario"].Width = 100;
            this.grdItemsEventosTareas.Columns["EVEN_Observaciones"].Width = 350;
            this.grdItemsEventosTareas.Columns["TIPO_CodEVE"].Width = 120;
            this.grdItemsEventosTareas.Columns["CONS_CodMOD"].Width = 120;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex); }
      }

      private void InstanceItemEventoTarea(Boolean ItemEnabled, Boolean EnabledGuardar)
      {
         try
         {
            EVEN_Fecha.Enabled = ItemEnabled;
            EVEN_Cumplida.Enabled = ItemEnabled;
            EVEN_Pendiente.Enabled = ItemEnabled;
            EVEN_Usuario.Enabled = ItemEnabled;
            EVEN_Observaciones.Enabled = ItemEnabled;
            TIPO_CodEVE.Enabled = ItemEnabled;
            CONS_CodMOD.Enabled = ItemEnabled;

            btnNuevoEventoTarea.Enabled = !EnabledGuardar;
            btnEditarEventoTarea.Enabled = (!EnabledGuardar && ItemEventoTarea != null);
            btnEliminarEventoTarea.Enabled = (!EnabledGuardar && ItemEventoTarea != null);
            btnGuardarEventoTarea.Enabled = EnabledGuardar;
            btnDeshacerEventoTarea.Enabled = EnabledGuardar;

            grdItemsEventosTareas.Enabled = !EnabledGuardar;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetInstanceView, ex); }
      }
      private void SeleccionarEventoTarea()
      {
         try
         {
            if (Presenter != null)
            {
               if ((grdItemsEventosTareas.CurrentRow != null && grdItemsEventosTareas.CurrentRow.DataBoundItem != null && grdItemsEventosTareas.CurrentRow.DataBoundItem is Entities.Det_Cotizacion_OV_EventosTareas))
               {
                  //Presenter.ItemEventosTareas = (grdItemsEventosTareas.CurrentRow.DataBoundItem as Entities.Det_Cotizacion_OV_EventosTareas);
                  ItemEventoTarea = (grdItemsEventosTareas.CurrentRow.DataBoundItem as Entities.Det_Cotizacion_OV_EventosTareas);
               }
               else
               {
                  //Presenter.ItemEventosTareas = null;
                  ItemEventoTarea = null;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }
      private void ClearItemEventoTarea()
      {
         try
         {
            EVEN_Fecha.NSFecha = null;
            EVEN_Cumplida.Checked = false;
            EVEN_Usuario.Text = String.Empty;
            EVEN_Observaciones.Text = String.Empty;
            TIPO_CodEVE.TiposSelectedValue = null;
            CONS_CodMOD.ConstantesSelectedValue = null;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ClearItem, ex); }
      }
      private void GetItemEventoTarea()
      {
         try
         {
            if (ItemEventoTarea != null)
            {
               ItemEventoTarea.EVEN_Fecha = EVEN_Fecha.NSFecha;
               ItemEventoTarea.EVEN_Cumplida = EVEN_Cumplida.Checked;
               ItemEventoTarea.EVEN_Usuario = EVEN_Usuario.Text;
               ItemEventoTarea.EVEN_Observaciones = EVEN_Observaciones.Text;
               if (TIPO_CodEVE.TiposSelectedItem != null)
               {
                  ItemEventoTarea.TIPO_TabEVE = TIPO_CodEVE.TiposSelectedItem.TIPO_CodTabla;
                  ItemEventoTarea.TIPO_CodEVE = TIPO_CodEVE.TiposSelectedItem.TIPO_CodTipo;
               }
               else
               {
                  ItemEventoTarea.TIPO_TabEVE = null;
                  ItemEventoTarea.TIPO_CodEVE = null;
               }
               if (CONS_CodMOD.ConstantesSelectedItem != null)
               {
                  ItemEventoTarea.CONS_TabMOD = CONS_CodMOD.ConstantesSelectedItem.CONS_CodTabla;
                  ItemEventoTarea.CONS_CodMOD = CONS_CodMOD.ConstantesSelectedItem.CONS_CodTipo;
               }
               else
               {
                  ItemEventoTarea.CONS_TabMOD = null;
                  ItemEventoTarea.CONS_CodMOD = null;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.GetItem, ex); }
      }
      private void SetItemEventoTarea()
      {
         try
         {
            if (ItemEventoTarea != null)
            {
               EVEN_Fecha.NSFecha = ItemEventoTarea.EVEN_Fecha;
               EVEN_Cumplida.Checked = ItemEventoTarea.EVEN_Cumplida;
               EVEN_Usuario.Text = ItemEventoTarea.EVEN_Usuario;
               EVEN_Observaciones.Text = ItemEventoTarea.EVEN_Observaciones;
               TIPO_CodEVE.TiposSelectedValue = ItemEventoTarea.TIPO_CodEVE;
               CONS_CodMOD.ConstantesSelectedValue = ItemEventoTarea.CONS_CodMOD;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetItem, ex); }
      }
      private void MostrarErrorItemEventoTarea()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Det_Cotizacion_OV_EventosTareas>.Validate(ItemEventoTarea, tableEventoTarea, errorEventoTarea);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }

      private void btnNuevoEventoTarea_Click(object sender, EventArgs e)
      {
         try
         {
            ClearItemEventoTarea();
            ItemEventoTarea = new Entities.Det_Cotizacion_OV_EventosTareas();
            ItemEventoTarea.EVEN_Fecha = DateTime.Now;
            ItemEventoTarea.EVEN_Manual = true;
            ItemEventoTarea.EVEN_Usuario = Presenter.Session.UserName;
            ItemEventoTarea.AUDI_UsrCrea = Presenter.Session.UserName;
            ItemEventoTarea.AUDI_FecCrea = Presenter.Session.Fecha;
            if (Presenter.ListConstantesMOD != null && Presenter.ListConstantesMOD.Count > 0 && Presenter.ListConstantesMOD.First() != null)
            {
               ItemEventoTarea.CONS_TabMOD = Presenter.ListConstantesMOD.First().CONS_CodTabla;
               ItemEventoTarea.CONS_CodMOD = Presenter.ListConstantesMOD.First().CONS_CodTipo;
            }
            ItemEventoTarea.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            InstanceItemEventoTarea(true, true);
            SetItemEventoTarea();
            Edicion = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }
      private void btnEditarEventoTarea_Click(object sender, EventArgs e)
      {
         try
         {
            SeleccionarEventoTarea();
            if (ItemEventoTarea != null)
            {
               ClearItemEventoTarea();
               ItemEventoTarea.AUDI_UsrMod = Presenter.Session.UserName;
               ItemEventoTarea.AUDI_FecMod = Presenter.Session.Fecha;
               if (ItemEventoTarea.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
               { ItemEventoTarea.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified; }
               SetItemEventoTarea();
               InstanceItemEventoTarea(ItemEventoTarea.EVEN_Manual, true);
               Edicion = true;
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }
      private void btnEliminarEventoTarea_Click(object sender, EventArgs e)
      {
         try
         {
            SeleccionarEventoTarea();
            if (ItemEventoTarea != null)
            {
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  if (ItemEventoTarea.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
                  {
                     ItemEventoTarea.AUDI_UsrMod = Presenter.Session.UserName;
                     ItemEventoTarea.AUDI_FecMod = Presenter.Session.Fecha;
                     ItemEventoTarea.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                     Presenter.Item.ItemsEventosTareasDeleted.Add(ItemEventoTarea);
                  }
                  BSItemsEventosTareas.RemoveCurrent();
                  BSItemsEventosTareas.ResetBindings(true);
                  Edicion = false;
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex); }
      }
      private void btnGuardarEventoTarea_Click(object sender, EventArgs e)
      {
         try
         {
            if (ItemEventoTarea != null)
            {
               GetItemEventoTarea();
               if (ItemEventoTarea.Validar())
               {
                  if (!Edicion)
                  { BSItemsEventosTareas.Add(ItemEventoTarea); }
                  else
                  { BSItemsEventosTareas[BSItemsEventosTareas.Position] = ItemEventoTarea; }

                  BSItemsEventosTareas.ResetBindings(true);
                  ItemEventoTarea = null;
                  ClearItemEventoTarea();
                  if (BSItemsEventosTareas.Current != null && BSItemsEventosTareas.Current is Entities.Det_Cotizacion_OV_EventosTareas)
                  { ItemEventoTarea = ((Entities.Det_Cotizacion_OV_EventosTareas)BSItemsEventosTareas.Current); }
                  else
                  { ItemEventoTarea = null; }
                  InstanceItemEventoTarea(false, false);
                  Edicion = false;
               }
               else
               { MostrarErrorItemEventoTarea(); }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex); }
      }
      private void btnDeshacerEventoTarea_Click(object sender, EventArgs e)
      {
         try
         {
            ClearItemEventoTarea();
            InstanceItemEventoTarea(false, false);
            BSItemsEventosTareas.MoveFirst();
            Edicion = false;
         }
         catch (Exception)
         { }
      }
      private void grdItemsEventosTareas_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
      {
         SeleccionarEventoTarea();
      }
      #endregion

      #region [ Eventos ]
      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            Boolean EsProspecto = (ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ENTC_Prospecto.HasValue) ? ENTC_CodCliente.Value.ENTC_Prospecto.Value : false;
            if (Presenter.Guardar(EsProspecto, true))
            {
               //this.FormClosing -= MView_FormClosing;
               //errorProviderCab_Cotizacion_OV.Dispose();
               //Presenter.Actualizar();
               //this.Close();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex); }
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            Boolean EsProspecto = (ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ENTC_Prospecto.HasValue) ? ENTC_CodCliente.Value.ENTC_Prospecto.Value : false;

            this.FormClosing -= MView_FormClosing;
            errorProviderCab_Cotizacion_OV.Dispose();
            if ((Presenter.Item.CONS_CodEST != "007") &&  (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario)))
            {
               if (Presenter.GuardarCambios(EsProspecto) != System.Windows.Forms.DialogResult.Cancel)
               { this.Close(); }
               else
               { this.FormClosing += MView_FormClosing; }
            }
            else
            { this.Close(); }
            Closing = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      private void btnExportar_Click(object sender, EventArgs e)
      {
         Presenter.ExportarMatrizDraft();
      }

      private void ENTC_CodEjecutivo_AyudaValueChanged(object sender, EventArgs e)
      {
         try
         {
            //if (ENTC_CodEjecutivo.Value != null && ENTC_CodEjecutivo.Value.ENTC_Propio.HasValue)
            //{ CCOT_Propia.Checked = ENTC_CodEjecutivo.Value.ENTC_Propio.Value; }
            //else
            //{ CCOT_Propia.Checked = false; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el Ejecutivo.", ex); }
      }
      private void ENTC_CodTransportista_AyudaValueChanged(object sender, EventArgs e)
      {
         try
         {
            if (ENTC_CodTransportista.Value != null && !String.IsNullOrEmpty(ENTC_CodTransportista.Value.CONS_CodTFT))
            { CONS_CodTFT.ConstantesSelectedValue = ENTC_CodTransportista.Value.CONS_CodTFT; }
            else
            { CONS_CodTFT.ConstantesSelectedValue = null; }

            SetServiciosLinea();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el Transportista.", ex); }
      }

      private void ENTC_CodCliente_AyudaValueChanged(object sender, EventArgs e)
      {
         //SetItemContacto(); 
         SetServiciosCliente();
         SetRelacionadosCliente();

         try { if (ENTC_CodCliente.Value != null) { CCOT_ServicioLogistico.Checked = ENTC_CodCliente.Value.ENTC_ServicioLogistico; } }
         catch (Exception) { }
      }
      private void ENTC_CodAgente_AyudaValueChanged(object sender, EventArgs e)
      { SetServiciosAgente(); EstablecerLineaNegocio(); }
      private void cmbCONS_CodRGM_SelectedIndexChanged(object sender, EventArgs e)
      {
         //SetItemContacto(); 
         SetNaveViajeRegimen();
         ConfigureServicios();
         SetRelacionadosCliente();
         EstablecerLineaNegocio();
      }
      private void cmbCONS_CodVia_SelectedIndexChanged(object sender, EventArgs e)
      {
         ConfigureServicios();
         EstablecerLineaNegocio();
         try
         {
            if (cmbCONS_CodVia.ConstantesSelectedItem != null)
            {
               txaPUER_CodOrigen.CONS_TabVia = cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTabla;
               txaPUER_CodOrigen.CONS_CodVia = cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo;
               txaPUER_CodDestino.CONS_TabVia = cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTabla;
               txaPUER_CodDestino.CONS_CodVia = cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo;
               txaPUER_CodTrasbordo.CONS_TabVia = cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTabla;
               txaPUER_CodTrasbordo.CONS_CodVia = cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               txaPUER_CodOrigen.CONS_TabVia = null;
               txaPUER_CodOrigen.CONS_CodVia = null;
               txaPUER_CodDestino.CONS_TabVia = null;
               txaPUER_CodDestino.CONS_CodVia = null;
               txaPUER_CodTrasbordo.CONS_TabVia = null;
               txaPUER_CodTrasbordo.CONS_CodVia = null;
            }
         }
         catch (Exception)
         { }
      }
      private void cmbCONS_CodLNG_SelectedIndexChanged(object sender, EventArgs e)
      {
         ConfigureServicios();
         SetServiciosCliente();
         SetServiciosAgente();
         SetServiciosLinea();
      }

      private void btnNuevoContacto_Click(object sender, EventArgs e)
      { NuevoContacto(); }
      private void btnEditarContacto_Click(object sender, EventArgs e)
      { EditarContacto(); }

      //private void TIPO_CodPAIOrigen_SelectedIndexChanged(object sender, EventArgs e)
      //{ LoadPuertosOrigen(); }
      //private void TIPO_CodPAITrasbordo_SelectedIndexChanged(object sender, EventArgs e)
      //{ LoadPuertosTrasbordo(); }
      //private void TIPO_CodPAIDestino_SelectedIndexChanged(object sender, EventArgs e)
      //{ LoadPuertosDestino(); }

      private void CONS_CodFLE_SelectedIndexChanged(object sender, EventArgs e)
      { ConfigureGridFlete(); }

      private void btnAddFlete_Click(object sender, EventArgs e)
      { AddFlete(); }
      private void btnDelFlete_Click(object sender, EventArgs e)
      { DelFlete(); }

      private void grdItemsFlete_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
      {
         if (e.Column.Name == "PACK_Codigo")
         { ConsultarTarifario(e.RowIndex); }
         else if (e.Column.Name == "DCOT_PrecioUniCosto")
         { CalcularTotalesFlete(); }
         else if (e.Column.Name == "DCOT_PrecioUniVenta")
         { CalcularTotalesFlete(); }
         else if (e.Column.Name == "DCOT_Cantidad")
         { ActualizarCantidadesServicio(); }
      }

      private void grdItemsArchivos_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Eliminar":
                     SeleccionarItemFile();
                     if (Presenter.EliminarFile())
                     {
                        BSItemsArchivos.DataSource = Presenter.Item.ItemsArchivo;
                        BSItemsArchivos.ResetBindings(true);
                     }
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }

      }

      private void ENTC_CodConsignee_AyudaValueChanged(object sender, EventArgs e)
      {
         try
         {
            if (ENTC_CodConsignee.Value != null && ENTC_CodNotify.Value != null)
            { ENTC_CodNotify.SetValue((ENTC_CodConsignee.Value.ENTC_Codigo)); }
         }
         catch (Exception)
         { }
      }

      private void txaPUER_CodOrigen_SelectedItemChanged(object sender, EventArgs e)
      {
         try
         {
            //Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta && 
            if (cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
            {
               if (txaPUER_CodOrigen.SelectedItem != null)
               { cmbTIPO_CodTRF.TiposSelectedValue = txaPUER_CodOrigen.SelectedItem.TIPO_CodTRF; }
               else
               { cmbTIPO_CodTRF.TiposSelectedValue = null; }
            }
            //EstablecerLineaNegocio();
         }
         catch (Exception)
         { }
      }
      private void txaPUER_CodDestino_SelectedItemChanged(object sender, EventArgs e)
      {
         try
         {
            //Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta && 
            if (cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Exportacion)
            {
               if (txaPUER_CodDestino.SelectedItem != null)
               { cmbTIPO_CodTRF.TiposSelectedValue = txaPUER_CodDestino.SelectedItem.TIPO_CodTRF; }
               else
               { cmbTIPO_CodTRF.TiposSelectedValue = null; }
            }
         }
         catch (Exception)
         { }
      }

      private void cmbTIPO_CodTRF_SelectedIndexChanged(object sender, EventArgs e)
      {
         SetRelacionadosCliente();
      }

      private void CCOT_FecEmi_SelectedDateChanged(object sender, EventArgs e)
      { CCOT_FecVcto.NSFecha = CCOT_FecEmi.NSFecha; }

      private void chkCCOT_CargaPeligrosa_CheckedChanged(object sender, EventArgs e)
      {
         if (!chkCCOT_CargaPeligrosa.Checked)
         {
            cmbTIPO_CodImo.TiposSelectedValue = null;
            txtCCOT_ImoUN.Text = String.Empty;
         }
         cmbTIPO_CodImo.Enabled = chkCCOT_CargaPeligrosa.Checked;
         txtCCOT_ImoUN.Enabled = chkCCOT_CargaPeligrosa.Checked;
      }

      private void MView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            Boolean EsProspecto = (ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ENTC_Prospecto.HasValue) ? ENTC_CodCliente.Value.ENTC_Prospecto.Value : false;

            if (Closing != true)
            {
               this.FormClosing -= MView_FormClosing;
               if ((Presenter.Item.CONS_CodEST != "007") && (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario)))
               {
                  if (Presenter.GuardarCambios(EsProspecto) == System.Windows.Forms.DialogResult.Cancel)
                  {
                     e.Cancel = true;
                     this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
                  }
                  else
                  { Presenter.Actualizar(); }
               }
               else
               { Presenter.Actualizar(); }
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      #endregion

      #region [ PopUp Grid text ]
      private void grdItemsNovedades_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            String _texto = "";
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((sender as Telerik.WinControls.UI.GridCommandCellElement).ColumnInfo.Name)
               {
                  case "OVNO_DescripcionPopUp":
                     _texto = grdItemsEventosTareas.CurrentRow.Cells["OVNO_Descripcion"].Value != null ? grdItemsEventosTareas.CurrentRow.Cells["OVNO_Descripcion"].Value.ToString() : "";
                     OPE001TView _viewText = new OPE001TView("Descripción de la Novedad", _texto, 4000, true);
                     _viewText.ShowDialog();
                     _viewText.Dispose();
                     _viewText = null;
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el botón de la grilla de eventos.", ex); }
      }
      private void grdItemsEventosTareas_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            String _texto = "";
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((sender as Telerik.WinControls.UI.GridCommandCellElement).ColumnInfo.Name)
               {
                  case "EVEN_ObservacionesPopUp":
                     _texto = grdItemsEventosTareas.CurrentRow.Cells["EVEN_Observaciones"].Value != null ? grdItemsEventosTareas.CurrentRow.Cells["EVEN_Observaciones"].Value.ToString() : "";
                     OPE001TView _viewText = new OPE001TView("Observaciones del Evento", _texto, 4000, true);
                     _viewText.ShowDialog();
                     _viewText.Dispose();
                     _viewText = null;
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el botón de la grilla de eventos.", ex); }
      }
      #endregion

      private void DOOV_HBL_KeyPress(object sender, KeyPressEventArgs e)
      {
          //if (Char.IsLetter(e.KeyChar))
          //{
          //    e.Handled = false;
          //}
          //else if (Char.IsControl(e.KeyChar))
          //{
          //    e.Handled = false;
          //}
          //else if (Char.IsSeparator(e.KeyChar))
          //{
          //    e.Handled = false;
          //}
          //else if (Char.IsNumber(e.KeyChar))
          //{
          //    e.Handled = false;
          //}
          //else
          //{
          //    e.Handled = true;
          //}
      }

      private void DOOV_MBL_KeyPress(object sender, KeyPressEventArgs e)
      {
          //if (Char.IsLetter(e.KeyChar))
          //{
          //    e.Handled = false;
          //}
          //else if (Char.IsControl(e.KeyChar))
          //{
          //    e.Handled = false;
          //}
          //else if (Char.IsSeparator(e.KeyChar))
          //{
          //    e.Handled = false;
          //}
          //else if (Char.IsNumber(e.KeyChar))
          //{
          //    e.Handled = false;
          //}
          //else
          //{
          //    e.Handled = true;
          //}
      }

      private void CCOT_VoBo_GateIn_CheckedChanged(object sender, EventArgs e)
      {
          if (CCOT_ServicioLogistico.Checked == true && CCOT_VoBo_GateIn.Checked == true)
          { CCOT_ServicioLogistico.Checked = false; }
      }

      private void CCOT_ServicioLogistico_CheckedChanged(object sender, EventArgs e)
      {
          if (CCOT_VoBo_GateIn.Checked == true && CCOT_ServicioLogistico.Checked == true)
          { CCOT_VoBo_GateIn.Checked = false; }

      }

      private void COM007MView_Load_1(object sender, EventArgs e)
      {

      }
   }
}