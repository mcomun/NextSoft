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
using System.IO;
using System.Text.RegularExpressions;

namespace Delfin.Principal
{
   public partial class OPE001MView : Form, IOPE001MView
   {
        Principal.AppService.DelfinServiceClient oAppService = new Principal.AppService.DelfinServiceClient();

      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public OPE001MView()
      {
         InitializeComponent();
         try
         {

            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += OPE001MView_FormClosed;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;

            txaENTC_CodEjecutivo.AyudaValueChanged += txaENTC_CodEjecutivo_AyudaValueChanged;
            txaENTC_CodTransportista.AyudaValueChanged += txaENTC_CodTransportista_AyudaValueChanged;
            txaENTC_CodCliente.AyudaValueChanged += txaENTC_CodCliente_AyudaValueChanged;

            cmbCONS_CodRGM.SelectedIndexChanged += CONS_CodRGM_SelectedIndexChanged;
            cmbCONS_CodVia.SelectedIndexChanged += CONS_CodVia_SelectedIndexChanged;
            cmbCONS_CodLNG.SelectedIndexChanged += cmbCONS_CodLNG_SelectedIndexChanged;
            btnNuevoContacto.Click += btnNuevoContacto_Click;
            btnEditarContacto.Click += btnEditarContacto_Click;

            txaCONT_Numero.AyudaClick += CONT_Numero_AyudaClick;
            txaCONT_Numero.AyudaClean += CONT_Numero_AyudaClean;
            btnCambiarContrato.Click += btnCambiarContrato_Click;

            cmbCONS_CodFLE.SelectedIndexChanged += CONS_CodFLE_SelectedIndexChanged;

            chkCCOT_EmitirHBL.CheckedChanged += chkCCOT_EmitirHBL_CheckedChanged;

            chkCCOT_Bloqueado.CheckedChanged += chkCCOT_Bloqueado_CheckedChanged;
            chkCCOT_ConExcepcion.CheckedChanged += chkCCOT_ConExcepcion_CheckedChanged;
            chkCCOT_CargaPeligrosa.CheckedChanged += chkCCOT_CargaPeligrosa_CheckedChanged;

            #region [ Entidades ]

            txaENTC_CodShipper.AyudaValueChanged += txaENTC_CodShipper_AyudaValueChanged;
            txaENTC_CodConsignee.AyudaValueChanged += txaENTC_CodConsignee_AyudaValueChanged;
            txaENTC_CodNotify.AyudaValueChanged += txaENTC_CodNotify_AyudaValueChanged;
            txaENTC_CodAgente.AyudaValueChanged += txaENTC_CodAgente_AyudaValueChanged;

            #endregion

            #region [ Flete ]

            grdItemsFlete.CellEndEdit += grdItemsFlete_CellEndEdit;
            //btnAddFlete.Click += btnAddFlete_Click;
            //btnDelFlete.Click += btnDelFlete_Click;

            txaPUER_CodOrigen.SelectedItemChanged += txaPUER_CodOrigen_SelectedItemChanged;
            txaPUER_CodDestino.SelectedItemChanged += txaPUER_CodDestino_SelectedItemChanged;


            #endregion

            #region [ Servicios ]

            btnAddServicio.Click += btnAddServicio_Click;
            btnDelServicio.Click += btnDelServicio_Click;
            grdItemsServicio.CellBeginEdit += grdItemsServicio_CellBeginEdit;
            grdItemsServicio.CellEndEdit += grdItemsServicio_CellEndEdit;
            grdItemsServicio.CommandCellClick += grdItemsServicio_CommandCellClick;
            grdItemsServicio.CurrentCellChanged += grdItemsServicio_CurrentCellChanged;

            btnAddServicioChangeControl.Click += btnAddServicioChangeControl_Click;
            btnDelServicioChangeControl.Click += btnDelServicioChangeControl_Click;
            btnEnviarFinanzasChangeControl.Click += btnEnviarFinanzasChangeControl_Click;
            grdItemsServiciosChangeControl.CellBeginEdit += grdItemsServiciosChangeControl_CellBeginEdit;
            grdItemsServiciosChangeControl.CellEndEdit += grdServiciosChangeControl_CellEndEdit;
            grdItemsServiciosChangeControl.CommandCellClick += grdServiciosChangeControl_CommandCellClick;
            grdItemsServiciosChangeControl.CurrentCellChanged += grdItemsServiciosChangeControl_CurrentCellChanged;

            #endregion

            #region [ Nave Viaje ]

            btnAddNaveViaje.Click += btnAddNaveViaje_Click;
            btnEditarNaveViaje.Click += btnEditarNaveViaje_Click;

            txaNVIA_Codigo.AyudaClick += txaNVIA_Codigo_AyudaClick;
            txaNVIA_Codigo.AyudaClean += txaNVIA_Codigo_AyudaClean;

            #endregion

            #region [ Novedades ]

            BSItemsNovedades = new BindingSource();
            grdItemsNovedades.DataSource = BSItemsNovedades;
            btnNuevoNovedad.Click += btnNuevoNovedad_Click;
            btnEnviarNovedad.Click += btnEnviarNovedad_Click;
            grdItemsNovedades.CommandCellClick += grdItemsNovedades_CommandCellClick;

            #endregion

            #region [ Eventos / Tareas ]

            BSItemsEventosTareas = new BindingSource();
            grdItemsEventosTareas.DataSource = BSItemsEventosTareas;
            btnNuevoEventoTarea.Click += btnNuevoEventoTarea_Click;
            btnEditarEventoTarea.Click += btnEditarEventoTarea_Click;
            btnEliminarEventoTarea.Click += btnEliminarEventoTarea_Click;
            btnGuardarEventoTarea.Click += btnGuardarEventoTarea_Click;
            btnDeshacerEventoTarea.Click += btnDeshacerEventoTarea_Click;
            grdItemsEventosTareas.CurrentRowChanged += grdItemsEventosTareas_CurrentRowChanged;
            grdItemsEventosTareas.CommandCellClick += grdItemsEventosTareas_CommandCellClick;
            EVEN_Observaciones.MaxLength = 8000;
            navItemsEventos.BindingSource = BSItemsEventosTareas;
            #endregion

            #region [ Anexos ]

            BSItemsAnexos = new BindingSource();
            grdItemsAnexos.DataSource = BSItemsAnexos;
            btnNuevoAnexo.Click += btnNuevoAnexo_Click;
            btnImprimirAnexo.Click += btnImprimirAnexo_Click;
            //btnEditarAnexo.Click += btnEditarAnexo_Click;
            //btnEliminarAnexo.Click += btnEliminarAnexo_Click;
            btnGuardarAnexo.Click += btnGuardarAnexo_Click;
            btnDeshacerAnexo.Click += btnDeshacerAnexo_Click;

            rbtANEX_TipoR.CheckedChanged += rbtANEX_TipoR_CheckedChanged;
            rbtANEX_TipoI.CheckedChanged += rbtANEX_TipoI_CheckedChanged;

            grdItemsAnexos.CurrentRowChanged += grdItemsAnexos_CurrentRowChanged;

            #endregion

            #region [ Matriz Draft ]
            chkDDOV_HBLNieto.CheckedChanged += chkDDOV_HBLNieto_CheckedChanged;

            btnExportarMatrizDraft.Click += btnExportarMatrizDraft_Click;
            btnImportarMatrizDraft.Click += btnImportarMatrizDraft_Click;
            btnImprimirMatrizDraft.Click += btnImprimirMatrizDraft_Click;

            btnNumerarHBL.Click += btnNumerarHBL_Click;

            btnEmitirHBL.Click += btnEmitirHBL_Click;

            btnAddContenedor.Click += btnAddContenedor_Click;
            btnDelContenedor.Click += btnDelContenedor_Click;

            grdDet_CNTR.CommandCellClick += grdDet_CNTR_CommandCellClick;
            grdDet_CNTR.CellBeginEdit += grdDet_CNTR_CellBeginEdit;
            grdDet_CNTR.CellEndEdit += grdDet_CNTR_CellEndEdit;
            #endregion

            btnCMBL_Numero.Click += btnCMBL_Numero_Click;

            btnDocumentada.Click += btnDocumentada_Click;
            btnPrefacturar.Click += btnPrefacturar_Click;
            btnGuiaAerea.Click += btnGuiaAerea_Click;
            btnEtiqueta.Click += btnEtiqueta_Click;

            txtDOOV_MBL.CharacterCasing = CharacterCasing.Upper;

            #region[ Correo & Archivos]

            btnDireccionamiento.Click += btnDireccionamiento_Click;
            btnDesgloseVoBo.Click += btnDesgloseVoBo_Click;
            btnDevolucionMaster.Click += btnDevolucionMaster_Click;
            btnRecojo.Click += btnRecojo_Click;
            btnAutorizacionTransmision.Click += btnAutorizacionTransmision_Click;
            btnSolicitudVolante.Click += btnSolicitudVolante_Click;
            btnEmitir_BL.Click += btnEmitir_BL_Click;
            btn_Aviso.Click += btn_Aviso_Click;

            btnCargoManifest.Click += btnCargoManifest_Click;
            #endregion

            #region [ Auditoria ]
            btnAuditoriaCab_Cotizacion_OV.Click += btnAuditoriaCab_Cotizacion_OV_Click;
            btnAuditoriaDet_Cotizacion_OV_Flete.Click += btnAuditoriaDet_Cotizacion_OV_Flete_Click;
            btnAuditoriaDet_Cotizacion_OV_Servicio.Click += btnAuditoriaDet_Cotizacion_OV_Servicio_Click;
            btnAuditoriaDet_Cotizacion_OV_Servicio_ChangeControl.Click += btnAuditoriaDet_Cotizacion_OV_Servicio_ChangeControl_Click;
            btnAuditoriaDet_Cotizacion_OV_EventosTareas.Click += btnAuditoriaDet_Cotizacion_OV_EventosTareas_Click;
            btnAuditoriaOPE_Det_CNTR.Click += btnAuditoriaOPE_Det_CNTR_Click;
            #endregion

            this.Load += OPE001MView_Load;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex);
         }
      }

      private void OPE001MView_Load(object sender, EventArgs e)
      {
         tabCab_Cotizacion_OV.TabPages.Clear();

         tabCab_Cotizacion_OV.TabPages.Add(pageGenerales);
         tabCab_Cotizacion_OV.TabPages.Add(pageServiciosTarifa);
         tabCab_Cotizacion_OV.TabPages.Add(pageEmbarque);
         //tabCab_Cotizacion_OV.TabPages.Add(pageObservaciones);

         //tabCab_Cotizacion_OV.TabPages.Add(pageNovedades);
         tabCab_Cotizacion_OV.TabPages.Add(pageArchivos);
         tabCab_Cotizacion_OV.TabPages.Add(pageEventosTareas);

         //tabCab_Cotizacion_OV.TabPages.Add(pageDatosEmision);
         //tabCab_Cotizacion_OV.TabPages.Add(pageDetalleContenedores);
         tabCab_Cotizacion_OV.TabPages.Add(pageAnexos);

         tabCab_Cotizacion_OV.SelectedTab = pageGenerales;

         //grdItemsFlete.Enabled = true;
         //grdItemsServicio.Enabled = true;
         //if (Presenter.Item.CONS_CodEST == "007")
         //{
         //    grdItemsFlete.Enabled = false;
         //    grdItemsServicio.Enabled = false;
         //}

      }
      private void OPE001MView_FormClosed(object sender, FormClosedEventArgs e)
      {
         Presenter.IsClosedMView();
      }
      #endregion

      #region [ Propiedades ]
      public OPE001Presenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }

      public BindingSource BSItemsFlete { get; set; }
      public BindingSource BSItemsServicio { get; set; }
      public BindingSource BSItemsServicioChangeControl { get; set; }
      public BindingSource BSDet_CNTR { get; set; }
      public BindingSource BSItemsNovedades { get; set; }
      public BindingSource BSItemsArchivos { get; set; }
      #endregion

      #region [ IOPE001MView ]
      public void LoadView()
      {
         try
         {
            #region [ Datos Generales ]

            cmbCONS_CodESTOV.LoadControl(Presenter.ContainerService, "Constantes Estados Orden de Venta", "OVE", "< Seleccionar Estado >", ListSortDirection.Ascending);
            txaENTC_CodCliente.ContainerService = Presenter.ContainerService;
            txaENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            cmbCONS_CodRGM.LoadControl(Presenter.ContainerService, "Constantes Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);
            cmbCONS_CodVia.LoadControl(Presenter.ContainerService, "Constantes Vía", "VIA", "< Seleccionar Vía >", ListSortDirection.Ascending);
            cmbCONS_CodLNG.LoadControl(Presenter.ContainerService, "Constantes Línea de Negocio", "LNG", "< Seleccionar Línea Negocio >", ListSortDirection.Ascending);
            txaENTC_CodAgente.ContainerService = Presenter.ContainerService;
            txaENTC_CodAgente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente;
            txaENTC_CodEjecutivo.ContainerService = Presenter.ContainerService;
            txaENTC_CodEjecutivo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;
            txaENTC_CodBroker.ContainerService = Presenter.ContainerService;
            txaENTC_CodBroker.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Broker;
            txaENTC_CodCustomer.ContainerService = Presenter.ContainerService;
            txaENTC_CodCustomer.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Customer;
            txaENTC_CodShipper.ContainerService = Presenter.ContainerService;
            txaENTC_CodShipper.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Shipper;
            txaENTC_CodConsignee.ContainerService = Presenter.ContainerService;
            txaENTC_CodConsignee.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            txaENTC_CodNotify.ContainerService = Presenter.ContainerService;
            txaENTC_CodNotify.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            cmbTIPO_CodINC.LoadControl(Presenter.ContainerService, "Tipos Incoterm", "INC", "< Seleccionar Incoterm >", ListSortDirection.Ascending);

            #endregion

            #region [ Servicios y Tarifa ]

            txaENTC_CodTransportista.ContainerService = Presenter.ContainerService;
            txaENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            cmbCONS_CodTFT.LoadControl(Presenter.ContainerService, "Constantes Tipo Fecha de Tarifa", "TFT", "< Seleccionar Tipo Fecha de Tarifa >", ListSortDirection.Ascending);
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Tipos de Moneda", "MND", "< Seleccionar Moneda >", ListSortDirection.Ascending);
            cmbCONS_CodFLE.LoadControl(Presenter.ContainerService, "Constantes de Condición de Embarque", "FLE", "< Seleccionar Condición >", ListSortDirection.Ascending);
            txaPUER_CodOrigen.LoadControl(Presenter.ContainerService, "Ayuda Puertos de Origen");
            txaPUER_CodDestino.LoadControl(Presenter.ContainerService, "Ayuda Puertos de Destino");
            txaPUER_CodTrasbordo.LoadControl(Presenter.ContainerService, "Ayuda Puertos de Trasbordo");

            cmbCCOT_PagoMBL.AddComboBoxItem("P", "Prepaid", true);
            cmbCCOT_PagoMBL.AddComboBoxItem("C", "Collect");
            cmbCCOT_PagoMBL.LoadComboBox("<Seleccionar P/C (MBL)>");
            cmbCCOT_PagoHBL.AddComboBoxItem("P", "Prepaid", true);
            cmbCCOT_PagoHBL.AddComboBoxItem("C", "Collect");
            cmbCCOT_PagoHBL.LoadComboBox("<Seleccionar P/C (HBL)>");


            BSItemsFlete = new BindingSource();
            grdItemsFlete.DataSource = BSItemsFlete;

            BSItemsServicio = new BindingSource();
            grdItemsServicio.DataSource = BSItemsServicio;

            BSItemsServicioChangeControl = new BindingSource();
            grdItemsServiciosChangeControl.DataSource = BSItemsServicioChangeControl;

            #endregion

            #region [ Datos Embarque ]

            #region [ Datos Documento ]

            txaENTC_CodDepTemporal.ContainerService = Presenter.ContainerService;
            txaENTC_CodDepTemporal.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_DepositoTemporal;

            #endregion

            #region [ Datos Nave Viaje ]

            #endregion

            #region [ Datos Documento Hijo ]

            txaENTC_CodShipperNieto.ContainerService = Presenter.ContainerService;
            txaENTC_CodShipperNieto.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Shipper;
            txaENTC_CodConsigneeNieto.ContainerService = Presenter.ContainerService;
            txaENTC_CodConsigneeNieto.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            txaENTC_CodNotifyNieto.ContainerService = Presenter.ContainerService;
            txaENTC_CodNotifyNieto.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;

            cmbTIPO_CodTRF.LoadControl(Presenter.ContainerService, "Tipos de Tráfico", "TRF", "< Seleccionar Tráfico >", ListSortDirection.Ascending);

            #endregion

            #region [ Datos Emision ]

            BSDet_CNTR = new BindingSource();
            grdDet_CNTR.DataSource = BSDet_CNTR;
            navItemsCNTR.BindingSource = BSDet_CNTR;

            #endregion

            #endregion

            #region [ Datos Adicionales ]
            cmbTIPO_CodIMO.LoadControl(Presenter.ContainerService, "Tabla IMO Class", "IMO", "< Seleccionar IMO Class >", ListSortDirection.Ascending);

            #region [ Archivos ]

            BSItemsArchivos = new BindingSource();
            grdItemsArchivos.DataSource = BSItemsArchivos;
            navItemsArchivos.BindingSource = BSItemsArchivos;

            #endregion

            #endregion

            #region [ Novedades/Eventos/Tareas ]

            #region [ Novedades ]

            cmbCONS_CodNOT.LoadControl(Presenter.ContainerService, "Tipos de Novedad", "NOT", "< Seleccionar Notificación >", ListSortDirection.Ascending);

            BSItemsNovedades = new BindingSource();
            grdItemsNovedades.DataSource = BSItemsNovedades;

            #endregion

            #region [ Eventos/Tareas ]

            cmbCONS_CodMOD.LoadControl(Presenter.ContainerService, "Constantes Modulos", "MOD", "< Seleccionar Modulo >", ListSortDirection.Ascending);
            cmbTIPO_CodEVE.LoadControl(Presenter.ContainerService, "Tipos Eventos/Tarea", "EVE", "< Seleccionar Evento/Tarea >", ListSortDirection.Ascending);

            BSItemsEventosTareas.DataSource = null;
            BSItemsEventosTareas.ResetBindings(true);

            #endregion

            #endregion

            #region [ Anexos ]
            String _documentos = "";
            //foreach (ListViewItem item in lvwANEX_Documentos.Items)
            //{ _documentos += item.Text + Environment.NewLine; }

            cmbANEX_TipoRectificacion.AddComboBoxItem("1", "Descripción", true);
            cmbANEX_TipoRectificacion.AddComboBoxItem("2", "Consignatario");
            cmbANEX_TipoRectificacion.AddComboBoxItem("3", "Peso");
            cmbANEX_TipoRectificacion.AddComboBoxItem("4", "Bultos");
            cmbANEX_TipoRectificacion.AddComboBoxItem("5", "Puerto de Destino");
            cmbANEX_TipoRectificacion.AddComboBoxItem("6", "Otros");
            cmbANEX_TipoRectificacion.LoadComboBox("< Seleccionar Tipo Rectificación >");

            lvwANEX_Documentos.Items.Clear();

            BSItemsAnexos = new BindingSource();
            grdItemsAnexos.DataSource = BSItemsAnexos;
            navItemsAnexos.BindingSource = BSItemsAnexos;

            #endregion

            FormatGridFlete();
            FormatGridServicios();
            FormatGridServiciosChangeControl();

            FormatGridNovedades();
            FormatGridArchivos();
            FormatGridEventoTarea();

            FormatGridMatriz();
            FormatGridAnexos();

         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex);
         }
      }

      public void ClearItem()
      {
         try
         {
            errorProviderCab_Cotizacion_OV.Clear();

            #region [ Datos Generales ]

            txtCCOT_NumDocOV.Text = String.Empty;
            txtCCOT_NumDocCOT.Text = String.Empty;
            cmbCONS_CodESTOV.ConstantesSelectedValue = null;
            mdtCCOT_FecEmi.NSFecha = null;
            mdtCCOT_FecVcto.NSFecha = null;
            mdtCCOT_FecAprueba.NSFecha = null;
            mdtDDOV_FecEmbarque.NSFecha = null;
            txaENTC_CodCliente.ClearValue();
            cmbCONS_CodRGM.ConstantesSelectedValue = null;
            cmbCONS_CodVia.ConstantesSelectedValue = null;
            txaENTC_CodAgente.ClearValue();
            txaENTC_CodEjecutivo.ClearValue();
            txaENTC_CodBroker.ClearValue();
            txaENTC_CodCustomer.ClearValue();
            txaENTC_CodShipper.ClearValue();
            txaENTC_CodConsignee.ClearValue();
            txaENTC_CodNotify.ClearValue();
            cmbTIPO_CodINC.TiposSelectedValue = null;
            txtDOOV_CodReferencia.Text = String.Empty;
            chkCCOT_Propia.Checked = false;
            chkCCOT_ServicioLogistico.Checked = false;
            chkCCOT_ServioTransmision.Checked = false;
            chlCCOT_RecibioPreAlerta.Checked = false;
            chkCCOT_SADA.Checked = false;
            chkCCOT_Bloqueado.Checked = false;
            chkCCOT_ConExcepcion.Checked = false;
            chkCCOT_EnviaAvisoLlegada.Checked = false;
            chkCCOT_VBOperaciones.Checked = false;
            chkCCOT_VBLogistico.Checked = false;
            chkCCOT_DiferenciaFlete.Checked = false;
            chkCCOT_DiferenciaFleteRecup.Checked = false;
            txtENTC_NomContacto.Text = String.Empty;
            txtENTC_EmailContacto.Text = String.Empty;
            txtENTC_CargoContacto.Text = String.Empty;

            #endregion

            #region [ Servicios y Tarifa ]

            txaENTC_CodTransportista.ClearValue();
            txaCONT_Numero.ClearValue();
            txaCONT_Numero.AyudaButton.Visible = true;
            txaCONT_Numero.Width = 194;
            btnCambiarContrato.Visible = false;
            txtCONT_Descrip.Text = String.Empty;
            cmbCONS_CodTFT.ConstantesSelectedValue = null;
            mdtCCOT_FecTarifa.NSFecha = null;
            cmbTIPO_CodMND.TiposSelectedValue = null;
            cmbCONS_CodFLE.ConstantesSelectedValue = null;
            txaPUER_CodOrigen.SelectedValue = null;
            txaPUER_CodDestino.SelectedValue = null;
            txaPUER_CodTrasbordo.SelectedValue = null;
            mdtCCOT_FecTrasbordo.NSFecha = null;
            cmbCCOT_PagoMBL.ComboStrSelectedValue = null;
            cmbCCOT_PagoHBL.ComboStrSelectedValue = null;
            txnDCOT_Importe.Text = "0.00";
            txnDCOT_Rentabilidad.Text = "0.00";

            BSItemsFlete.DataSource = null;
            BSItemsFlete.ResetBindings(true);

            BSItemsServicio.DataSource = null;
            BSItemsServicio.ResetBindings(true);

            BSItemsServicioChangeControl.DataSource = null;
            BSItemsServicioChangeControl.ResetBindings(true);

            #endregion

            #region [ Datos Embarque ]

            #region [ Datos Documento ]

            txaENTC_CodDepTemporal.ClearValue();
            txtDOOV_MBL.Text = String.Empty;
            txtDOOV_HBL.Text = String.Empty;
            txtDDOV_NroBooking.Text = String.Empty;
            txtDOOV_Cntr.Text = String.Empty;
            mdtDOOV_FecICA.NSFecha = null;
                mdtCCOT_FecEmiDoc.NSFecha = null;
            chkCCOT_EmitirHBL.Checked = false;

            #endregion

            #region [ Datos Nave Viaje ]
            cmbTIPO_CodTRF.TiposSelectedValue = null;

            txtDOOV_Feeder_IMPO.Text = String.Empty;
            mdtDOOV_FecETDFeeder_IMPO.NSFecha = null;
            ClearItemViaje();
            #endregion

            #region [ Datos DOcumento Hijo ]

            txaENTC_CodShipperNieto.ClearValue();
            txaENTC_CodConsigneeNieto.ClearValue();
            txaENTC_CodNotifyNieto.ClearValue();
            chkDDOV_HBLNieto.Checked = false;
            txtDOOV_NumeroBLNieto.Text = String.Empty;

            #endregion

            #region [ Datos Emision ]

            txtDDOV_DescShipper.Text = String.Empty;
            txtDDOV_DescConsignee.Text = String.Empty;
            txtDDOV_DescNotify.Text = String.Empty;
            txtDDOV_DescApplyTo.Text = String.Empty;

            txtDOOV_PlaceReceipt.Text = String.Empty;
            txtDOOV_PlaceDelivery.Text = String.Empty;

            BSDet_CNTR.DataSource = null;
            BSDet_CNTR.ResetBindings(true);

            #endregion

            #endregion

            #region [ Datos Adicionales ]

            chkCCOT_CargaRefrigerada.Checked = false;
            txnCCOT_Temperatura.Text = "0.00";
            chkCCOT_Roundtrip.Checked = false;
            chkCCOT_CargaPeligrosa.Checked = false;
            cmbTIPO_CodIMO.TiposSelectedValue = null;
            txtCCOT_ImoUN.Text = String.Empty;
            cmbTIPO_CodIMO.Enabled = chkCCOT_CargaPeligrosa.Checked;
            txtCCOT_ImoUN.Enabled = chkCCOT_CargaPeligrosa.Checked;
            txnCCOT_ValidezOferta.Text = "0";
            txnCCOT_Almacenaje.Text = "0";
            txnCCOT_TiempoViaje.Text = "0";
            txnCCOT_SobreEstadia.Text = "0";
            txtCCOT_Observaciones.Text = String.Empty;

            cmbTIPO_CodIMO.Enabled = chkCCOT_CargaPeligrosa.Checked;
            txtCCOT_ImoUN.Enabled = chkCCOT_CargaPeligrosa.Checked;

            #region [ Archivos ]

            txoOVAR_Archivo.Text = string.Empty;
            BSItemsArchivos.DataSource = null;
            BSItemsArchivos.ResetBindings(true);

            #endregion

            #endregion

            #region [ Novedades/Eventos/Tareas ]

            #region [ Novedades ]

            ClearItemNovedad();

            BSItemsNovedades.DataSource = null;
            BSItemsNovedades.ResetBindings(true);

            #endregion

            #region [ Eventos/Tareas ]

            ClearItemEventoTarea();
            InstanceItemEventoTarea(false, false);

            BSItemsEventosTareas.DataSource = null;
            BSItemsEventosTareas.ResetBindings(true);

            #endregion

            #endregion

            #region [ Anexos ]

            //rbtANEX_TipoR.Checked = false;
            //rbtANEX_TipoI.Checked = false;
            //txtANEX_MroManifiesto.Text = String.Empty;
            //txtANEX_NumeroHBL.Text = String.Empty;
            //mdtANEX_FecLlegada.NSFecha = null;
            //mdtANEX_FecDescarga.NSFecha = null;
            //mdtANEX_FecSalida.NSFecha = null;
            //mdtANEX_FecEmbarque.NSFecha = null;
            ClearItemAnexo();
            InstanceItemAnexo(false, false);

            BSItemsAnexos.DataSource = null;
            BSItemsAnexos.ResetBindings(true);

            #endregion

            #region [ Linea Negocio ]
            cmbCONS_CodLNG.ConstantesSelectedValue = null;
            #endregion
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ClearItem.", ex);
         }
      }
      public void GetItem()
      {
         try
         {
            errorProviderCab_Cotizacion_OV.Clear();

            #region [ Datos Generales ]

            Presenter.Item.CCOT_NumDoc = txtCCOT_NumDocOV.Text;
            Presenter.Item.CCOT_NumDocCOT = txtCCOT_NumDocCOT.Text;
            if (cmbCONS_CodESTOV.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TabEST = cmbCONS_CodESTOV.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodEST = cmbCONS_CodESTOV.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TabEST = null;
               Presenter.Item.CONS_CodEST = null;
            }

            Presenter.Item.CCOT_FecEmi = mdtCCOT_FecEmi.NSFecha;
            Presenter.Item.CCOT_FecVcto = mdtCCOT_FecVcto.NSFecha;
            Presenter.Item.CCOT_FecAprueba = mdtCCOT_FecAprueba.NSFecha;
            Presenter.Item.DDOV_FecEmbarque = mdtDDOV_FecEmbarque.NSFecha;

            if (txaENTC_CodCliente.Value != null)
            {
               Presenter.Item.ENTC_CodCliente = txaENTC_CodCliente.Value.ENTC_Codigo;
            }
            else
            {
               Presenter.Item.ENTC_CodCliente = null;
            }
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
            if (txaENTC_CodAgente.Value != null)
            {
               Presenter.Item.ENTC_CodAgente = txaENTC_CodAgente.Value.ENTC_Codigo;
            }
            else
            {
               Presenter.Item.ENTC_CodAgente = null;
            }
            if (txaENTC_CodEjecutivo.Value != null)
            {
               Presenter.Item.ENTC_CodEjecutivo = txaENTC_CodEjecutivo.Value.ENTC_Codigo;
            }
            else
            {
               Presenter.Item.ENTC_CodEjecutivo = null;
            }
            if (txaENTC_CodBroker.Value != null)
            {
               Presenter.Item.ENTC_CodBroker = txaENTC_CodBroker.Value.ENTC_Codigo;
            }
            else
            {
               Presenter.Item.ENTC_CodBroker = null;
            }
            if (txaENTC_CodCustomer.Value != null)
            {
               Presenter.Item.ENTC_CodCustomer = txaENTC_CodCustomer.Value.ENTC_Codigo;
            }
            else
            {
               Presenter.Item.ENTC_CodCustomer = null;
            }

            if (txaENTC_CodShipper.Value != null)
            {
               Presenter.Item.ENTC_CodShipper = txaENTC_CodShipper.Value.ENTC_Codigo;
            }
            else
            {
               Presenter.Item.ENTC_CodShipper = null;
            }
            if (txaENTC_CodConsignee.Value != null)
            {
               Presenter.Item.ENTC_CodConsignee = txaENTC_CodConsignee.Value.ENTC_Codigo;
            }
            else
            {
               Presenter.Item.ENTC_CodConsignee = null;
            }
            if (txaENTC_CodNotify.Value != null)
            {
               Presenter.Item.ENTC_CodNotify = txaENTC_CodNotify.Value.ENTC_Codigo;
            }
            else
            {
               Presenter.Item.ENTC_CodNotify = null;
            }
            if (cmbTIPO_CodINC.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabINC = cmbTIPO_CodINC.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodINC = cmbTIPO_CodINC.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabINC = null;
               Presenter.Item.TIPO_CodINC = null;
            }

            Presenter.Item.DOOV_CodReferencia = txtDOOV_CodReferencia.Text;
            Presenter.Item.CCOT_Propia = chkCCOT_Propia.Checked;
            Presenter.Item.CCOT_ServicioLogistico = chkCCOT_ServicioLogistico.Checked;
            Presenter.Item.CCOT_ServicioTransmision = chkCCOT_ServioTransmision.Checked;
            Presenter.Item.CCOT_RecibioPreAlerta = chlCCOT_RecibioPreAlerta.Checked;
            Presenter.Item.CCOT_SADA = chkCCOT_SADA.Checked;
            Presenter.Item.CCOT_Bloqueado = chkCCOT_Bloqueado.Checked;
            Presenter.Item.CCOT_ConExcepcion = chkCCOT_ConExcepcion.Checked;
            Presenter.Item.CCOT_EnviaAvisoLlegada = chkCCOT_EnviaAvisoLlegada.Checked;
            Presenter.Item.CCOT_VBOperaciones = chkCCOT_VBOperaciones.Checked;
            Presenter.Item.CCOT_VBLogistico = chkCCOT_VBLogistico.Checked;
            Presenter.Item.CCOT_DiferenciaFlete = chkCCOT_DiferenciaFlete.Checked;
            Presenter.Item.CCOT_DiferenciaFleteRecup = chkCCOT_DiferenciaFleteRecup.Checked;

            #endregion

            #region [ Servicios y Tarifa ]

            if (txaENTC_CodTransportista.Value != null)
            {
               Presenter.Item.ENTC_CodTransportista = txaENTC_CodTransportista.Value.ENTC_Codigo;
            }
            else
            {
               Presenter.Item.ENTC_CodTransportista = null;
            }
            if (txaCONT_Numero.Value != null && txaCONT_Numero.Value is Entities.Contrato)
            {
               Presenter.Item.CONT_Codigo = ((Entities.Contrato)txaCONT_Numero.Value).CONT_Codigo;
            }
            else
            {
               Presenter.Item.CONT_Codigo = null;
            }
            if (cmbCONS_CodTFT.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TabTFT = cmbCONS_CodTFT.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodTFT = cmbCONS_CodTFT.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TabTFT = null;
               Presenter.Item.CONS_CodTFT = null;
            }
            Presenter.Item.CCOT_FecTarifa = mdtCCOT_FecTarifa.NSFecha;

            if (cmbTIPO_CodMND.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabMND = null;
               Presenter.Item.TIPO_CodMND = null;
            }
            if (cmbCONS_CodFLE.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TabFLE = cmbCONS_CodFLE.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodFLE = cmbCONS_CodFLE.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TabFLE = null;
               Presenter.Item.CONS_CodFLE = null;
            }

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
            Presenter.Item.CCOT_FecTrasbordo = mdtCCOT_FecTrasbordo.NSFecha;

            Presenter.Item.CCOT_PagoMBL = cmbCCOT_PagoMBL.ComboStrSelectedValue;
            Presenter.Item.CCOT_PagoHBL = cmbCCOT_PagoHBL.ComboStrSelectedValue;

            Presenter.Item.ItemsFlete = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource);
            Presenter.Item.ItemsServicio = ((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicio.DataSource);
            Presenter.Item.ItemsServicioChangeControl = ((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicioChangeControl.DataSource);

            #endregion

            #region [ Datos Embarque ]

            #region [ Datos Documento ]

            if (txaENTC_CodDepTemporal.Value != null)
            {
               Presenter.Item.ENTC_CodDepTemporal = txaENTC_CodDepTemporal.Value.ENTC_Codigo;
            }
            else
            {
               Presenter.Item.ENTC_CodDepTemporal = null;
            }

            Presenter.Item.DOOV_HBL = txtDOOV_HBL.Text;
            Presenter.Item.DOOV_MBL = txtDOOV_MBL.Text;
            Presenter.Item.DDOV_NroBooking = txtDDOV_NroBooking.Text;
            Presenter.Item.DOOV_Cntr = txtDOOV_Cntr.Text;
            Presenter.Item.DOOV_FecICA = mdtDOOV_FecICA.NSFecha;
            Presenter.Item.CCOT_FecEmiDoc = mdtCCOT_FecEmiDoc.NSFecha; 
            Presenter.Item.CCOT_EmitirHBL = chkCCOT_EmitirHBL.Checked;

            #endregion

            #region [ Datos Nave Viaje ]
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

            if (cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
            {
               Presenter.Item.DOOV_Feeder_IMPO = txtDOOV_Feeder_IMPO.Text;
               Presenter.Item.DOOV_FecETDFeeder_IMPO = mdtDOOV_FecETDFeeder_IMPO.NSFecha;
            }
            else
            {
               Presenter.Item.DOOV_Feeder_IMPO = String.Empty;
               Presenter.Item.DOOV_FecETDFeeder_IMPO = null;
            }

            if (txaNVIA_Codigo.Value != null)
            {
               Presenter.Item.NVIA_Codigo = ((Entities.NaveViaje)txaNVIA_Codigo.Value).NVIA_Codigo;
            }
            else
            {
               Presenter.Item.NVIA_Codigo = null;
            }

            #endregion

            #region [ Datos Documento Hijo ]

            if (txaENTC_CodShipperNieto.Value != null)
            {
               Presenter.Item.ENTC_CodShipperNieto = txaENTC_CodShipperNieto.Value.ENTC_Codigo;
            }
            else
            {
               Presenter.Item.ENTC_CodShipperNieto = null;
            }
            if (txaENTC_CodConsigneeNieto.Value != null)
            {
               Presenter.Item.ENTC_CodConsigneeNieto = txaENTC_CodConsigneeNieto.Value.ENTC_Codigo;
            }
            else
            {
               Presenter.Item.ENTC_CodConsigneeNieto = null;
            }
            if (txaENTC_CodNotifyNieto.Value != null)
            {
               Presenter.Item.ENTC_CodNotifyNieto = txaENTC_CodNotifyNieto.Value.ENTC_Codigo;
            }
            else
            {
               Presenter.Item.ENTC_CodNotifyNieto = null;
            }

            Presenter.Item.DDOV_HBLNieto = chkDDOV_HBLNieto.Checked;
            Presenter.Item.DOOV_NumeroBLNieto = txtDOOV_NumeroBLNieto.Text;

            #endregion

            #region [ Datos Emision ]

            Presenter.Item.DDOV_DescShipper = txtDDOV_DescShipper.Text;
            Presenter.Item.DDOV_DescConsignee = txtDDOV_DescConsignee.Text;
            Presenter.Item.DDOV_DescNotify = txtDDOV_DescNotify.Text;
            Presenter.Item.DDOV_DescApplyTo = txtDDOV_DescApplyTo.Text;

            Presenter.Item.DOOV_PlaceReceipt = txtDOOV_PlaceReceipt.Text;
            Presenter.Item.DOOV_PlaceDelivery = txtDOOV_PlaceDelivery.Text;

            Presenter.Item.ItemsDet_CNTR = ((ObservableCollection<Entities.Det_CNTR>)BSDet_CNTR.DataSource);

            #endregion

            #endregion

            #region [ Datos Adicionales ]

            Presenter.Item.CCOT_CargaRefrigerada = chkCCOT_CargaRefrigerada.Checked;
            Presenter.Item.CCOT_Temperatura = txnCCOT_Temperatura.Value;
            Presenter.Item.CCOT_Roundtrip = chkCCOT_Roundtrip.Checked;
            Presenter.Item.CCOT_CargaPeligrosa = chkCCOT_CargaPeligrosa.Checked;
            if (cmbTIPO_CodIMO.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabImo = cmbTIPO_CodIMO.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodImo = cmbTIPO_CodIMO.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabImo = null;
               Presenter.Item.TIPO_CodImo = null;
            }
            Presenter.Item.CCOT_ImoUN = txtCCOT_ImoUN.Text;
            Presenter.Item.CCOT_Almacenaje = Convert.ToInt16(txnCCOT_Almacenaje.Value);
            Presenter.Item.CCOT_SobreEstadia = Convert.ToInt16(txnCCOT_SobreEstadia.Value);
            Presenter.Item.CCOT_TiempoViaje = Convert.ToInt16(txnCCOT_TiempoViaje.Value);
            Presenter.Item.CCOT_ValidezOferta = Convert.ToInt16(txnCCOT_ValidezOferta.Value);
            Presenter.Item.CCOT_Observaciones = txtCCOT_Observaciones.Text;

            #region [ Archivos ]

            Presenter.Item.ItemsArchivo = ((ObservableCollection<Entities.Det_Cotizacion_OV_Archivo>)BSItemsArchivos.DataSource);

            #endregion

            #endregion

            #region [ Novedades/Eventos/Tareas ]

            #region [ Novedades ]

            Presenter.Item.ItemsNovedad = ((ObservableCollection<Entities.Det_Cotizacion_OV_Novedad>)BSItemsNovedades.DataSource);

            #endregion

            #region [ Eventos/Tareas ]

            Presenter.Item.ItemsEventosTareas = ((ObservableCollection<Entities.Det_Cotizacion_OV_EventosTareas>)BSItemsEventosTareas.DataSource);

            #endregion

            #endregion

            #region [ Anexos ]

            Presenter.Item.ItemsAnexos = ((ObservableCollection<Entities.Anexos>)BSItemsAnexos.DataSource);

            #endregion

            #region [ Linea Negocio ]
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
            #endregion
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en GetItem.", ex);
         }
      }
      public void SetItem()
      {
         try
         {
            #region [ Datos Generales ]

            txtCCOT_NumDocOV.Text = Presenter.Item.CCOT_NumDoc;
            txtCCOT_NumDocCOT.Text = Presenter.Item.CCOT_NumDocCOT;
            cmbCONS_CodESTOV.ConstantesSelectedValue = Presenter.Item.CONS_CodEST;


            mdtCCOT_FecEmi.NSFecha = Presenter.Item.CCOT_FecEmi;
            mdtCCOT_FecVcto.NSFecha = Presenter.Item.CCOT_FecVcto;
            mdtCCOT_FecAprueba.NSFecha = Presenter.Item.CCOT_FecAprueba;

            mdtDDOV_FecEmbarque.NSFecha = Presenter.Item.DDOV_FecEmbarque;

            if (Presenter.Item.ENTC_CodCliente.HasValue)
            {
               txaENTC_CodCliente.SetValue(Presenter.Item.ENTC_CodCliente.Value);
            }
            if (!String.IsNullOrEmpty(Presenter.Item.CONS_CodRGM))
            {
               cmbCONS_CodRGM.ConstantesSelectedValue = Presenter.Item.CONS_CodRGM;
            }
            if (!String.IsNullOrEmpty(Presenter.Item.CONS_CodVia))
            {
               cmbCONS_CodVia.ConstantesSelectedValue = Presenter.Item.CONS_CodVia;
            }

            if (!String.IsNullOrEmpty(Presenter.Item.DDOV_DescApplyTo))
            { txtDDOV_DescApplyTo.Text = Presenter.Item.DDOV_DescApplyTo; }

            if (Presenter.Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
            {
               if (String.IsNullOrEmpty(txtDDOV_DescApplyTo.Text) && Presenter.ItemEmpresa != null)
               {
                  String _DDOV_DescApplyTo = "";
                  _DDOV_DescApplyTo += Presenter.ItemEmpresa.ENTC_NomCompleto;
                  _DDOV_DescApplyTo += Environment.NewLine + Presenter.ItemEmpresa.TIPO_DescTDI + ": " + Presenter.ItemEmpresa.ENTC_DocIden;
                  _DDOV_DescApplyTo += Environment.NewLine + Presenter.ItemEmpresa.DIRE_Direccion;
                  _DDOV_DescApplyTo += Environment.NewLine + Presenter.ItemEmpresa.DIRE_Ubigeo;
                  _DDOV_DescApplyTo += Environment.NewLine + "Telf.:" + Presenter.ItemEmpresa.ENTC_Telef1 + " " + "Cel.:" + Presenter.ItemEmpresa.ENTC_Telef2;
                  _DDOV_DescApplyTo += Environment.NewLine + Presenter.ItemEmpresa.ENTC_EMail;

                  txtDDOV_DescApplyTo.Text = _DDOV_DescApplyTo;
               }
            }
            if (Presenter.Item.ENTC_CodAgente.HasValue)
            {
               txaENTC_CodAgente.SetValue(Presenter.Item.ENTC_CodAgente.Value);
            }
            if (Presenter.Item.ENTC_CodEjecutivo.HasValue)
            {
               txaENTC_CodEjecutivo.SetValue(Presenter.Item.ENTC_CodEjecutivo.Value);
            }
            if (Presenter.Item.ENTC_CodBroker.HasValue)
            {
               txaENTC_CodBroker.SetValue(Presenter.Item.ENTC_CodBroker.Value);
            }
            if (Presenter.Item.ENTC_CodCustomer.HasValue)
            {
               txaENTC_CodCustomer.SetValue(Presenter.Item.ENTC_CodCustomer.Value);
            }

            if (!String.IsNullOrEmpty(Presenter.Item.DDOV_DescShipper))
            { txtDDOV_DescShipper.Text = Presenter.Item.DDOV_DescShipper; }
            if (Presenter.Item.ENTC_CodShipper.HasValue)
            {
               txaENTC_CodShipper.SetValue(Presenter.Item.ENTC_CodShipper.Value);
            }


            if (Presenter.Item.ENTC_CodConsignee.HasValue)
            {
               txtDDOV_DescConsignee.Text = "";
               txaENTC_CodConsignee.SetValue(Presenter.Item.ENTC_CodConsignee.Value);
            }
            if (!String.IsNullOrEmpty(Presenter.Item.DDOV_DescConsignee))
            { txtDDOV_DescConsignee.Text = Presenter.Item.DDOV_DescConsignee; }

            if (Presenter.Item.ENTC_CodNotify.HasValue)
            {
               txtDDOV_DescNotify.Text = "";
               txaENTC_CodNotify.SetValue(Presenter.Item.ENTC_CodNotify.Value);
            }
            if (!String.IsNullOrEmpty(Presenter.Item.DDOV_DescNotify))
            { txtDDOV_DescNotify.Text = Presenter.Item.DDOV_DescNotify; }


            if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodINC))
            {
               cmbTIPO_CodINC.TiposSelectedValue = Presenter.Item.TIPO_CodINC;
            }
            txtDOOV_CodReferencia.Text = Presenter.Item.DOOV_CodReferencia;
            chkCCOT_Propia.Checked = Presenter.Item.CCOT_Propia;
            chkCCOT_ServicioLogistico.Checked = Presenter.Item.CCOT_ServicioLogistico;
            chkCCOT_ServioTransmision.Checked = Presenter.Item.CCOT_ServicioTransmision;
            chlCCOT_RecibioPreAlerta.Checked = Presenter.Item.CCOT_RecibioPreAlerta;
            chkCCOT_SADA.Checked = Presenter.Item.CCOT_SADA;
            chkCCOT_Bloqueado.Checked = Presenter.Item.CCOT_Bloqueado;
            chkCCOT_ConExcepcion.Checked = Presenter.Item.CCOT_ConExcepcion;
            chkCCOT_EnviaAvisoLlegada.Checked = Presenter.Item.CCOT_EnviaAvisoLlegada;
            chkCCOT_VBOperaciones.Checked = Presenter.Item.CCOT_VBOperaciones;
            chkCCOT_VBLogistico.Checked = Presenter.Item.CCOT_VBLogistico;
            chkCCOT_DiferenciaFlete.Checked = Presenter.Item.CCOT_DiferenciaFlete;
            chkCCOT_DiferenciaFleteRecup.Checked = Presenter.Item.CCOT_DiferenciaFleteRecup;
            //txtENTC_NomContacto.Text = String.Empty;
            //txtENTC_EmailContacto.Text = String.Empty;
            //txtENTC_CargoContacto.Text = String.Empty;

            this.Text = String.Format("Operaciones - Orden de Venta <{0} - {1:dd/MM/yyyy} - [{2} / {3} / {4}]>", Presenter.Item.CCOT_NumDoc, Presenter.Item.CCOT_FecEmi
                                    , cmbCONS_CodRGM.Text, cmbCONS_CodVia.Text, cmbCONS_CodLNG.Text);

            #endregion

            #region [ Servicios y Tarifa ]

            if (Presenter.Item.ENTC_CodTransportista.HasValue)
            {
               txaENTC_CodTransportista.SetValue(Presenter.Item.ENTC_CodTransportista.Value);
            }
            SetItemContrato(false);
            cmbCONS_CodTFT.ConstantesSelectedValue = Presenter.Item.CONS_CodTFT;
            mdtCCOT_FecTarifa.NSFecha = Presenter.Item.CCOT_FecTarifa;

            cmbTIPO_CodMND.TiposSelectedValue = Presenter.Item.TIPO_CodMND;
            cmbCONS_CodFLE.ConstantesSelectedValue = Presenter.Item.CONS_CodFLE;

            cmbTIPO_CodTRF.TiposSelectedValue = Presenter.Item.TIPO_CodTRF;

            txaPUER_CodOrigen.SelectedValue = Presenter.Item.PUER_CodOrigen;
            txaPUER_CodDestino.SelectedValue = Presenter.Item.PUER_CodDestino;
            txaPUER_CodTrasbordo.SelectedValue = Presenter.Item.PUER_CodTrasbordo;
            mdtCCOT_FecTrasbordo.NSFecha = Presenter.Item.CCOT_FecTrasbordo;

            cmbCCOT_PagoMBL.ComboStrSelectedValue = Presenter.Item.CCOT_PagoMBL;
            cmbCCOT_PagoHBL.ComboStrSelectedValue = Presenter.Item.CCOT_PagoHBL;

            foreach (Entities.Det_Cotizacion_OV_Flete _itemFLETE in Presenter.Item.ItemsFlete)
            {
               _itemFLETE.ListPaquete = Presenter.ListPaquetes;
               _itemFLETE.ItemPaquete = Presenter.ListPaquetes.Where(dcot => dcot.PACK_Codigo == _itemFLETE.PACK_Codigo).FirstOrDefault();
            }

            BSItemsFlete.DataSource = Presenter.Item.ItemsFlete;
            BSItemsFlete.ResetBindings(true);

            SetTipoDocumentoServicios(false);

            BSItemsServicio.DataSource = Presenter.Item.ItemsServicio;
            BSItemsServicio.ResetBindings(true);

            SetTipoDocumentoServicios(true);

            BSItemsServicioChangeControl.DataSource = Presenter.Item.ItemsServicioChangeControl;
            BSItemsServicioChangeControl.ResetBindings(true);

            CalcularTotalesFlete();

            FormatGridMatriz();

            #endregion

            #region [ Datos Embarque ]

            #region [ Datos Documento ]

            if (Presenter.Item.ENTC_CodDepTemporal.HasValue)
            {
               txaENTC_CodDepTemporal.SetValue(Presenter.Item.ENTC_CodDepTemporal.Value);
            }
            txtDOOV_HBL.Text = Presenter.Item.DOOV_HBL;
            txtDOOV_MBL.Text = Presenter.Item.DOOV_MBL;
            txtDDOV_NroBooking.Text = Presenter.Item.DDOV_NroBooking;
            txtDOOV_Cntr.Text = Presenter.Item.DOOV_Cntr;
            mdtDOOV_FecICA.NSFecha = Presenter.Item.DOOV_FecICA;
                mdtCCOT_FecEmiDoc.NSFecha = Presenter.Item.CCOT_FecEmiDoc; 
            chkCCOT_EmitirHBL.Checked = Presenter.Item.CCOT_EmitirHBL;

            #endregion

            #region [ Datos Nave Viaje ]
            if (cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
            {
               txtDOOV_Feeder_IMPO.Text = Presenter.Item.DOOV_Feeder_IMPO;
               mdtDOOV_FecETDFeeder_IMPO.NSFecha = Presenter.Item.DOOV_FecETDFeeder_IMPO;
            }
            else
            {
               txtDOOV_Feeder_IMPO.Text = String.Empty;
               mdtDOOV_FecETDFeeder_IMPO.NSFecha = null;
            }

            SetItemViaje();

            #endregion

            #region [ Datos Documento Hijo ]

            if (Presenter.Item.ENTC_CodShipperNieto.HasValue)
            {
               txaENTC_CodShipperNieto.SetValue(Presenter.Item.ENTC_CodShipperNieto.Value);
            }
            if (Presenter.Item.ENTC_CodConsigneeNieto.HasValue)
            {
               txaENTC_CodConsigneeNieto.SetValue(Presenter.Item.ENTC_CodConsigneeNieto.Value);
            }
            if (Presenter.Item.ENTC_CodNotifyNieto.HasValue)
            {
               txaENTC_CodNotifyNieto.SetValue(Presenter.Item.ENTC_CodNotifyNieto.Value);
            }
            chkDDOV_HBLNieto.Checked = !String.IsNullOrEmpty(Presenter.Item.DOOV_NumeroBLNieto);
            chkDDOV_HBLNieto.Checked = Presenter.Item.DDOV_HBLNieto;
            txtDOOV_NumeroBLNieto.Text = Presenter.Item.DOOV_NumeroBLNieto;

            #endregion

            #region [ Datos Emision ]

            txtDOOV_PlaceReceipt.Text = Presenter.Item.DOOV_PlaceReceipt;
            txtDOOV_PlaceDelivery.Text = Presenter.Item.DOOV_PlaceDelivery;

            #region [ Validacion Contenedores ]

            foreach (Entities.Det_CNTR _Det_CNTR in Presenter.Item.ItemsDet_CNTR)
            {
               if (Presenter.Item.CCOT_CargaPeligrosa)
               {
                  _Det_CNTR.DHBL_EsIMO = Presenter.Item.CCOT_CargaPeligrosa;
                  _Det_CNTR.TIPO_TabIMO = Presenter.Item.TIPO_TabImo;
                  _Det_CNTR.TIPO_CodIMO = Presenter.Item.TIPO_CodImo;
                  _Det_CNTR.DHBL_ImoUN = Presenter.Item.CCOT_ImoUN;
               }
            }

            if (Presenter != null && Presenter.Item != null && Presenter.Item.ItemsFlete != null && Presenter.Item.ItemsFlete.Count == 1 && Presenter.Item.ItemsDet_CNTR != null && Presenter.Item.ItemsDet_CNTR.Count > 0)
            {
               foreach (Entities.Det_CNTR _Det_CNTR in Presenter.Item.ItemsDet_CNTR)
               {
                  //if (_Det_CNTR.DHBL_EsIMO.HasValue && _Det_CNTR.DHBL_EsIMO.Value)
                  //{ _Det_CNTR.DHBL_ImoUN = Presenter.Item.CCOT_ImoUN; }

                  if (!Presenter.Item.ItemsDet_CNTR[0].PACK_Codigo.HasValue)
                  { _Det_CNTR.PACK_Codigo = Presenter.Item.ItemsFlete[0].PACK_Codigo; }

                  if (String.IsNullOrEmpty(Presenter.Item.ItemsDet_CNTR[0].TIPO_TabCDT))
                  { _Det_CNTR.TIPO_TabCDT = Presenter.Item.ItemsFlete[0].TIPO_TabCDT; }
                  if (String.IsNullOrEmpty(Presenter.Item.ItemsDet_CNTR[0].TIPO_CodCDT))
                  { _Det_CNTR.TIPO_CodCDT = Presenter.Item.ItemsFlete[0].TIPO_CodCDT; }
               }
               //if (!Presenter.Item.ItemsDet_CNTR[0].PACK_Codigo.HasValue)
               //{Presenter.Item.ItemsDet_CNTR[0].PACK_Codigo = Presenter.Item.ItemsFlete[0].PACK_Codigo;}

               //if (String.IsNullOrEmpty(Presenter.Item.ItemsDet_CNTR[0].TIPO_TabCDT))
               //{Presenter.Item.ItemsDet_CNTR[0].TIPO_TabCDT = Presenter.Item.ItemsFlete[0].TIPO_TabCDT;}
               //if (String.IsNullOrEmpty(Presenter.Item.ItemsDet_CNTR[0].TIPO_CodCDT))
               //{Presenter.Item.ItemsDet_CNTR[0].TIPO_CodCDT = Presenter.Item.ItemsFlete[0].TIPO_CodCDT;}
            }

            #endregion

            BSDet_CNTR.DataSource = Presenter.Item.ItemsDet_CNTR;
            BSDet_CNTR.ResetBindings(true);
            #endregion

            #endregion

            #region [ Datos Adicionales ]

            chkCCOT_CargaRefrigerada.Checked = Presenter.Item.CCOT_CargaRefrigerada;
            if (Presenter.Item.CCOT_Temperatura.HasValue)
            {
               txnCCOT_Temperatura.Text = Presenter.Item.CCOT_Temperatura.Value.ToString();
            }
            chkCCOT_Roundtrip.Checked = Presenter.Item.CCOT_Roundtrip;
            chkCCOT_CargaPeligrosa.Checked = Presenter.Item.CCOT_CargaPeligrosa;
            cmbTIPO_CodIMO.TiposSelectedValue = Presenter.Item.TIPO_CodImo;
            txtCCOT_ImoUN.Text = Presenter.Item.CCOT_ImoUN;
            txnCCOT_ValidezOferta.Text = Presenter.Item.CCOT_ValidezOferta.ToString();
            txnCCOT_Almacenaje.Text = Presenter.Item.CCOT_Almacenaje.ToString();
            txnCCOT_TiempoViaje.Text = Presenter.Item.CCOT_TiempoViaje.ToString();
            txnCCOT_SobreEstadia.Text = Presenter.Item.CCOT_SobreEstadia.ToString();
            txtCCOT_Observaciones.Text = Presenter.Item.CCOT_Observaciones;

            #region [ Archivos ]

            BSItemsArchivos.DataSource = Presenter.Item.ItemsArchivo;
            BSItemsArchivos.ResetBindings(true);

            #endregion

            #endregion

            #region [ Novedades/Eventos/Tareas ]

            #region [ Novedades ]

            BSItemsEventosTareas.DataSource = Presenter.Item.ItemsNovedad;
            BSItemsEventosTareas.ResetBindings(true);

            #endregion

            #region [ Eventos/Tareas ]

            BSItemsEventosTareas.DataSource = Presenter.Item.ItemsEventosTareas;
            BSItemsEventosTareas.ResetBindings(true);

            ValidarEventos();

            #endregion

            #endregion

            #region [ Anexos ]

            BSItemsAnexos.DataSource = Presenter.Item.ItemsAnexos;
            BSItemsAnexos.ResetBindings(true);

            #endregion

            #region [ Linea Negocio ]
            if (!String.IsNullOrEmpty(Presenter.Item.CONS_TabLNG) && !String.IsNullOrEmpty(Presenter.Item.CONS_CodLNG))
            { cmbCONS_CodLNG.ConstantesSelectedValue = Presenter.Item.CONS_CodLNG; }
            else if (cmbCONS_CodLNG.ConstantesSelectedItem != null)
            { EstablecerLineaNegocio(); } //cmbCONS_CodLNG.ConstantesSelectedValue = null;
            #endregion

            EnabledItem();

            InstanceItemAnexo(false, false);
            InstanceItemEventoTarea(false, false);


            //tabCab_Cotizacion_OV.SelectedTab = pageGenerales;

            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en SetItem.", ex);
         }
      }
      private void EnabledItem()
      {
         try
         {
            if (Presenter != null && Presenter.Item != null)
            {
               Boolean EnabledDatosGenerales = (Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVEANULADA && Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVECERRADA && !Presenter.OVSOLOLECTURA);
               Boolean EnabledDatosTarifa = (Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVEANULADA && Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVEPREFACTURADA && Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVECERRADA && !Presenter.OVSOLOLECTURA);
               Boolean EnabledDatosServicios = (Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVEANULADA && Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVEPREFACTURADA && Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVECERRADA && !Presenter.OVSOLOLECTURA);
               Boolean EnabledDatosServiciosChangeControl = (Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVEANULADA && (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEPREFACTURADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECERRADA) && !Presenter.OVSOLOLECTURA);
               Boolean EnabledDatosEmbarque = (Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVEANULADA && Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVECERRADA && !Presenter.OVSOLOLECTURA);
               Boolean EnabledDatosObservaciones = (Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVEANULADA && Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVECERRADA && !Presenter.OVSOLOLECTURA);
               Boolean EnabledDatosDocumento = (Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVEANULADA && Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVECERRADA && !Presenter.OVSOLOLECTURA);
               Boolean EnabledDatosHBL = (Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVEANULADA && Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVECERRADA && !Presenter.OVSOLOLECTURA);
               Boolean EnabledAyudaViaje = (Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVEANULADA && Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVECERRADA && !Presenter.OVSOLOLECTURA);
               Boolean EnabledDatosViaje = false;
               Boolean EnabledDatosNovedades = false;// (Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVECERRADA && !Presenter.OVSOLOLECTURA);
               Boolean EnabledDatosArchivos = (Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVEANULADA && Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVECERRADA && !Presenter.OVSOLOLECTURA);
               Boolean EnabledDatosEventos = (Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVEANULADA && Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVECERRADA && !Presenter.OVSOLOLECTURA);
               Boolean EnabledDatosAnexos = (Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVEANULADA && Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVECERRADA && !Presenter.OVSOLOLECTURA);

               #region [ Botones ]
               btnGuardar.Enabled = (Presenter.Item.CONS_CodEST != Delfin.Controls.variables.CONS_ESTOVEANULADA);
               btnDocumentada.Enabled = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONCLUIDA);
               btnPrefacturar.Enabled = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEDOCUMENTADA);
               btnEmisionCartas.Enabled = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEDOCUMENTADA || Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEPREFACTURADA);
               btn_Aviso.Enabled = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEPREFACTURADA);
               btnSolicitudVolante.Enabled = (Presenter.Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEPREFACTURADA);

               btnGuiaAerea.Enabled = true;
               btnCargoManifest.Enabled = true;
               btnEtiqueta.Enabled = true;

               btnGuiaAerea.Visible = (Presenter.Item.CONS_CodVia == Delfin.Controls.variables.CONSVIA_Aerea);
               btnCargoManifest.Visible = true;
               btnEtiqueta.Visible = (Presenter.Item.CONS_CodVia == Delfin.Controls.variables.CONSVIA_Aerea);
               #endregion

               #region [ Datos Generales ]

               txtCCOT_NumDocOV.Enabled = false;
               txtCCOT_NumDocCOT.Enabled = false;
               cmbCONS_CodESTOV.Enabled = false;
               mdtCCOT_FecEmi.Enabled = false;
               mdtCCOT_FecVcto.Enabled = EnabledDatosGenerales;
               mdtCCOT_FecAprueba.Enabled = EnabledDatosGenerales;
               mdtDDOV_FecEmbarque.Enabled = EnabledDatosGenerales;
               txaENTC_CodCliente.Enabled = EnabledDatosGenerales;
               cmbCONS_CodRGM.Enabled = false;
               cmbCONS_CodVia.Enabled = false;
               txaENTC_CodAgente.Enabled = EnabledDatosGenerales;
               txaENTC_CodEjecutivo.Enabled = EnabledDatosGenerales;
               txaENTC_CodBroker.Enabled = EnabledDatosGenerales;
               txaENTC_CodCustomer.Enabled = EnabledDatosGenerales;
               txaENTC_CodShipper.Enabled = EnabledDatosGenerales;
               txaENTC_CodConsignee.Enabled = EnabledDatosGenerales;
               txaENTC_CodNotify.Enabled = EnabledDatosGenerales;
               cmbTIPO_CodINC.Enabled = EnabledDatosGenerales;
               txtDOOV_CodReferencia.Enabled = EnabledDatosGenerales;
               chkCCOT_Propia.Enabled = EnabledDatosGenerales;
               chkCCOT_ServicioLogistico.Enabled = EnabledDatosGenerales;
               chkCCOT_ServioTransmision.Enabled = EnabledDatosGenerales;
               chlCCOT_RecibioPreAlerta.Enabled = false;
               chkCCOT_SADA.Enabled = EnabledDatosGenerales;
               //chkCCOT_Bloqueado.Enabled = EnabledDatosGenerales;
               //chkCCOT_ConExcepcion.Enabled = EnabledDatosGenerales;
               chkCCOT_Bloqueado.Enabled = false;
               chkCCOT_ConExcepcion.Enabled = false;
               chkCCOT_EnviaAvisoLlegada.Enabled = EnabledDatosGenerales;
               chkCCOT_VBOperaciones.Enabled = false;
               chkCCOT_VBLogistico.Enabled = false;
               chkCCOT_DiferenciaFlete.Enabled = false;
               chkCCOT_DiferenciaFleteRecup.Enabled = false;
               txtENTC_NomContacto.Enabled = EnabledDatosGenerales;
               txtENTC_EmailContacto.Enabled = EnabledDatosGenerales;
               txtENTC_CargoContacto.Enabled = EnabledDatosGenerales;

               txaENTC_CodShipperNieto.Enabled = EnabledDatosGenerales && chkDDOV_HBLNieto.Checked;
               txaENTC_CodConsigneeNieto.Enabled = EnabledDatosGenerales && chkDDOV_HBLNieto.Checked;
               txaENTC_CodNotifyNieto.Enabled = EnabledDatosGenerales && chkDDOV_HBLNieto.Checked;
               #endregion

               #region [ Servicios y Tarifa ]

               txaENTC_CodTransportista.Enabled = EnabledDatosTarifa;
               txaCONT_Numero.Enabled = EnabledDatosTarifa;
               btnCambiarContrato.Enabled = EnabledDatosTarifa;
               txtCONT_Descrip.Enabled = EnabledDatosTarifa;
               cmbCONS_CodTFT.Enabled = EnabledDatosTarifa;
               mdtCCOT_FecTarifa.Enabled = EnabledDatosTarifa;
               cmbTIPO_CodMND.Enabled = EnabledDatosTarifa;
               cmbCONS_CodFLE.Enabled = EnabledDatosTarifa;
               txaPUER_CodOrigen.Enabled = EnabledDatosTarifa;
               txaPUER_CodDestino.Enabled = EnabledDatosTarifa;
               txaPUER_CodTrasbordo.Enabled = EnabledDatosTarifa;
               mdtCCOT_FecTrasbordo.Enabled = EnabledDatosTarifa;
               cmbCCOT_PagoMBL.Enabled = EnabledDatosTarifa;
               cmbCCOT_PagoHBL.Enabled = EnabledDatosTarifa;
               txnDCOT_Importe.Enabled = EnabledDatosTarifa;
               txnDCOT_Rentabilidad.Enabled = EnabledDatosTarifa;

               btnAddFlete.Enabled = EnabledDatosTarifa;
               btnDelFlete.Enabled = EnabledDatosTarifa;
               //grdItemsFlete.Enabled = EnabledDatosTarifa;
               foreach (Telerik.WinControls.UI.GridViewDataColumn _column in grdItemsFlete.Columns)
               {
                  if (!_column.ReadOnly)
                  {
                     _column.ReadOnly = !EnabledDatosTarifa;
                  }
               }

               btnAddServicio.Enabled = EnabledDatosServicios;
               btnDelServicio.Enabled = EnabledDatosServicios;
               //grdItemsServicio.Enabled = EnabledDatosServicios;
               foreach (Telerik.WinControls.UI.GridViewDataColumn _column in grdItemsServicio.Columns)
               {
                  if (!_column.ReadOnly) { _column.ReadOnly = !EnabledDatosServicios; }
                  if (_column is Telerik.WinControls.UI.GridViewCommandColumn)
                  {
                     if (_column.HeaderText == "Actualizar Documento")
                     { _column.IsVisible = EnabledDatosServiciosChangeControl; }
                     else
                     { _column.IsVisible = EnabledDatosServicios; }
                  }
               }

               btnAddServicioChangeControl.Enabled = EnabledDatosServiciosChangeControl;
               btnDelServicioChangeControl.Enabled = EnabledDatosServiciosChangeControl;
               //grdItemsServiciosChangeControl.Enabled = EnabledDatosServiciosChangeControl;
               foreach (Telerik.WinControls.UI.GridViewDataColumn _column in grdItemsServiciosChangeControl.Columns)
               {
                  if (!_column.ReadOnly) { _column.ReadOnly = !EnabledDatosServiciosChangeControl; }
                  if (_column is Telerik.WinControls.UI.GridViewCommandColumn) { _column.IsVisible = EnabledDatosServiciosChangeControl; }
               }

               #endregion

               #region [ Datos Embarque ]

               #region [ Datos Documento ]

               txaENTC_CodDepTemporal.Enabled = EnabledDatosEmbarque;
               txtDOOV_MBL.Enabled = EnabledDatosEmbarque;
               txtDOOV_HBL.Enabled = EnabledDatosEmbarque;
               txtDDOV_NroBooking.Enabled = EnabledDatosEmbarque;
               txtDOOV_Cntr.Enabled = EnabledDatosEmbarque;
               mdtDOOV_FecICA.Enabled = EnabledDatosEmbarque;
                    mdtCCOT_FecEmiDoc.Enabled = EnabledDatosEmbarque;
               mdtCCOT_FecEmiDoc.Visible = (Presenter.Item.CONS_CodVia == Delfin.Controls.variables.CONSVIA_Aerea);
               lbl_FecEmiDoc.Visible = (Presenter.Item.CONS_CodVia == Delfin.Controls.variables.CONSVIA_Aerea);


                    chkCCOT_EmitirHBL.Enabled = false;
               //if (cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
               //{
               foreach (Entities.Det_Cotizacion_OV_EventosTareas _itemEvento in Presenter.Item.ItemsEventosTareas)
               {
                  if (Presenter.PARA_RELEASEHBL != null && _itemEvento.TIPO_CodEVE == Presenter.PARA_RELEASEHBL.PARA_Valor)
                  {
                     //chkCCOT_EmitirHBL.Enabled = true;
                  }
               }
               //}

               #endregion

               #region [ Datos Nave Viaje ]

               txtDOOV_Feeder_IMPO.Enabled = EnabledDatosViaje;
               mdtDOOV_FecETDFeeder_IMPO.Enabled = EnabledDatosViaje;

               txaNVIA_Codigo.Enabled = EnabledAyudaViaje;
               txaNVIA_Codigo.EnabledAyuda = EnabledAyudaViaje;
               txaNVIA_Codigo.EnabledAyudaButton = EnabledAyudaViaje;

               txtNVIA_NroViaje.Enabled = EnabledDatosViaje;


               txtNAVE_Nombre.Enabled = EnabledDatosViaje;
               //mdtDDOV_FecEmbarque.Enabled = EnabledDatosViaje;
               //txtENTC_NomTransportista.Enabled = EnabledDatosViaje;
               cmbTIPO_CodTRF.Enabled = EnabledDatosViaje;
               mdtNVIA_FecETA.Enabled = EnabledDatosViaje;
               txtENTC_NomTermPort.Enabled = EnabledDatosViaje;
               txtNVIA_NroManifiesto.Enabled = EnabledDatosViaje;
               mdtNVIA_FecCutOff.Enabled = EnabledDatosViaje;
               txtNVIA_NroManifiestoDescon.Enabled = EnabledDatosViaje;
               mdtNVIA_FecCierre.Enabled = EnabledDatosViaje;
               mdtNVIA_FecLlega_IMPO.Enabled = EnabledDatosViaje;
               mdtNVIA_FecDescarga_IMPO.Enabled = EnabledDatosViaje;
               mdtNVIA_FecZarpe_EXPO.Enabled = EnabledDatosViaje;
               mdtNVIA_FecRecogerDocs.Enabled = EnabledDatosViaje;
               mdtNVIA_FecTermEmba_EXPO.Enabled = EnabledDatosViaje;

               #endregion

               #region [ Datos Documento Hijo ]

               //txaENTC_CodShipperNieto.Enabled = EnabledDatosEmbarque;
               //txaENTC_CodConsigneeNieto.Enabled = EnabledDatosEmbarque;
               //txaENTC_CodNotifyNieto.Enabled = EnabledDatosEmbarque;
               chkDDOV_HBLNieto.Enabled = EnabledDatosEmbarque;
               txtDOOV_NumeroBLNieto.Enabled = EnabledDatosEmbarque;

               #endregion

               #region [ Datos Emision ]

               btnEmitirHBL.Visible = false;
               btnEmitirHBL.Enabled = false;

               btnNumerarHBL.Visible = false;
               btnExportarMatrizDraft.Visible = false;
               btnImportarMatrizDraft.Visible = false;
               btnImprimirMatrizDraft.Visible = false;

               btnNumerarHBL.Enabled = false;
               btnExportarMatrizDraft.Enabled = false;
               btnImportarMatrizDraft.Enabled = false;
               btnImprimirMatrizDraft.Enabled = false;


               if (Presenter.Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
               {
                  btnEmitirHBL.Visible = true;
                  btnEmitirHBL.Enabled = chkCCOT_EmitirHBL.Checked;

                  txtDDOV_DescShipper.Enabled = chkCCOT_EmitirHBL.Checked;
                  txtDDOV_DescConsignee.Enabled = chkCCOT_EmitirHBL.Checked;
                  txtDDOV_DescNotify.Enabled = chkCCOT_EmitirHBL.Checked;
                  txtDDOV_DescApplyTo.Enabled = chkCCOT_EmitirHBL.Checked;

                  txtDOOV_PlaceReceipt.Enabled = chkCCOT_EmitirHBL.Checked;
                  txtDOOV_PlaceDelivery.Enabled = chkCCOT_EmitirHBL.Checked;

                  if (Presenter.Item.DDOV_HBLNieto && (Presenter.Item.CONS_CodFLE == "001" || Presenter.Item.CONS_CodFLE == "003"))
                  {
                     btnNumerarHBL.Visible = true;
                     btnNumerarHBL.Enabled = true;
                  }
               }
               else if (Presenter.Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Exportacion)
               {
                  btnEmitirHBL.Visible = true;
                  btnEmitirHBL.Enabled = true;

                  btnNumerarHBL.Visible = true;
                  btnExportarMatrizDraft.Visible = true;
                  btnImportarMatrizDraft.Visible = true;
                  //btnImprimirMatrizDraft.Visible = true;

                  btnNumerarHBL.Enabled = true;
                  btnExportarMatrizDraft.Enabled = true;
                  btnImportarMatrizDraft.Enabled = true;
                  //btnImprimirMatrizDraft.Enabled = true;

                  txtDDOV_DescShipper.Enabled = true;
                  txtDDOV_DescConsignee.Enabled = true;
                  txtDDOV_DescNotify.Enabled = true;
                  txtDDOV_DescApplyTo.Enabled = true;

                  txtDOOV_PlaceReceipt.Enabled = true;
                  txtDOOV_PlaceDelivery.Enabled = true;
               }

               //BSDet_CNTR.DataSource = null;
               //BSDet_CNTR.ResetBindings(true);
               btnAddContenedor.Enabled = EnabledDatosHBL;
               btnDelContenedor.Enabled = EnabledDatosHBL;
               foreach (Telerik.WinControls.UI.GridViewDataColumn _column in grdDet_CNTR.Columns)
               {
                  if (!_column.ReadOnly)
                  {
                     _column.ReadOnly = !EnabledDatosHBL;
                  }
               }

               #endregion

               #endregion

               #region [ Datos Adicionales ]

               chkCCOT_CargaRefrigerada.Enabled = EnabledDatosObservaciones;
               txnCCOT_Temperatura.Enabled = EnabledDatosObservaciones;
               chkCCOT_Roundtrip.Enabled = EnabledDatosObservaciones;
               chkCCOT_CargaPeligrosa.Enabled = EnabledDatosObservaciones;
               cmbTIPO_CodIMO.Enabled = EnabledDatosObservaciones && chkCCOT_CargaPeligrosa.Checked;
               txtCCOT_ImoUN.Enabled = EnabledDatosObservaciones && chkCCOT_CargaPeligrosa.Checked;
               txnCCOT_ValidezOferta.Enabled = EnabledDatosObservaciones;
               txnCCOT_Almacenaje.Enabled = EnabledDatosObservaciones;
               txnCCOT_TiempoViaje.Enabled = EnabledDatosObservaciones;
               txnCCOT_SobreEstadia.Enabled = EnabledDatosObservaciones;
               txtCCOT_Observaciones.Enabled = EnabledDatosObservaciones;

               #region [ Archivos ]

               txoOVAR_Archivo.Enabled = EnabledDatosArchivos;
               btnAddNaveViaje.Enabled = EnabledDatosArchivos;
               btnUploadFile.Enabled = EnabledDatosArchivos;
               btnDownloadFile.Enabled = true; // EnabledDatosArchivos;
               grdItemsArchivos.Columns["Delete"].IsVisible = EnabledDatosArchivos;
               grdItemsArchivos.Columns["OVAR_DescripcionPopUp"].ReadOnly = !EnabledDatosArchivos;
               grdItemsArchivos.Columns["Delete"].IsVisible = EnabledDatosArchivos;

               //grdItemsArchivos.Enabled = EnabledDatosArchivos;
               //foreach (Telerik.WinControls.UI.GridViewDataColumn _column in grdItemsArchivos.Columns)
               //{
               //   if (!_column.ReadOnly)
               //   { _column.ReadOnly = !EnabledDatosArchivos; }
               //}

               #endregion

               #endregion

               #region [ Novedades/Eventos/Tareas ]

               #region [ Novedades ]

               txtOVNO_Descrip.Enabled = EnabledDatosNovedades;
               cmbCONS_CodNOT.Enabled = EnabledDatosNovedades;

               btnNuevoNovedad.Enabled = EnabledDatosNovedades;
               btnEnviarNovedad.Enabled = EnabledDatosNovedades;
               //grdItemsNovedades.Enabled = EnabledDatosNovedades;
               foreach (Telerik.WinControls.UI.GridViewDataColumn _column in grdItemsNovedades.Columns)
               {
                  if (!_column.ReadOnly)
                  {
                     _column.ReadOnly = !EnabledDatosNovedades;
                  }
               }

               #endregion

               #region [ Eventos/Tareas ]

               //EVEN_Fecha.Enabled = EnabledDatosEventos;
               //EVEN_Cumplida.Enabled = EnabledDatosEventos;
               //EVEN_Usuario.Enabled = EnabledDatosEventos;
               //EVEN_Observaciones.Enabled = EnabledDatosEventos;
               //cmbTIPO_CodEVE.Enabled = EnabledDatosEventos;
               //cmbCONS_CodMOD.Enabled = EnabledDatosEventos;

               //btnNuevoEventoTarea.Enabled = EnabledDatosEventos;
               //btnEditarEventoTarea.Enabled = EnabledDatosEventos;
               //btnEliminarEventoTarea.Enabled = EnabledDatosEventos;
               //btnGuardarEventoTarea.Enabled = EnabledDatosEventos;
               //btnDeshacerEventoTarea.Enabled = EnabledDatosEventos;
               //grdItemsEventosTareas.Enabled = EnabledDatosEventos;
               if (EnabledDatosEventos)
               {
                  if (Presenter.Item.ItemsEventosTareas != null && Presenter.Item.ItemsEventosTareas.Count > 0)
                  {
                     SeleccionarEventoTarea();
                     InstanceItemEventoTarea(false, false);
                  }

               }
               else
               {
                  EVEN_Fecha.Enabled = EnabledDatosEventos;
                  EVEN_Cumplida.Enabled = EnabledDatosEventos;
                  EVEN_Usuario.Enabled = EnabledDatosEventos;
                  EVEN_Observaciones.Enabled = EnabledDatosEventos;
                  cmbTIPO_CodEVE.Enabled = EnabledDatosEventos;
                  cmbCONS_CodMOD.Enabled = EnabledDatosEventos;

                  btnNuevoEventoTarea.Enabled = EnabledDatosEventos;
                  btnEditarEventoTarea.Enabled = EnabledDatosEventos;
                  btnEliminarEventoTarea.Enabled = EnabledDatosEventos;
                  btnGuardarEventoTarea.Enabled = EnabledDatosEventos;
                  btnDeshacerEventoTarea.Enabled = EnabledDatosEventos;

                  //grdItemsEventosTareas.Enabled = EnabledDatosEventos;
               }
               foreach (Telerik.WinControls.UI.GridViewDataColumn _column in grdItemsEventosTareas.Columns)
               {
                  if (!_column.ReadOnly)
                  {
                     _column.ReadOnly = !EnabledDatosEventos;
                  }
               }

               #endregion

               #endregion

               #region [ Anexos ]

               //rbtANEX_TipoR.Enabled = EnabledDatosAnexos;
               //rbtANEX_TipoI.Enabled = EnabledDatosAnexos;
               //txtANEX_NumeroHBL.Enabled = EnabledDatosAnexos;
               //txtANEX_MroManifiesto.Enabled = EnabledDatosAnexos;
               //mdtANEX_FecLlegada.Enabled = EnabledDatosAnexos;
               //mdtANEX_FecSalida.Enabled = EnabledDatosAnexos;
               //mdtANEX_FecDescarga.Enabled = EnabledDatosAnexos;
               //mdtANEX_FecEmbarque.Enabled = EnabledDatosAnexos;
               //txtANEX_Observaciones.Enabled = EnabledDatosAnexos;
               //txtANEX_DondeDice.Enabled = EnabledDatosAnexos;
               //txtANEX_DebeDecir.Enabled = EnabledDatosAnexos;
               //lvwANEX_Documentos.Enabled = EnabledDatosAnexos;

               //btnNuevoAnexo.Enabled = EnabledDatosAnexos;
               //btnGuardarAnexo.Enabled = EnabledDatosAnexos;
               //btnDeshacerAnexo.Enabled = EnabledDatosAnexos;
               //btnImprimirAnexo.Enabled = EnabledDatosAnexos;
               ////grdItemsAnexos.Enabled = EnabledDatosAnexos;

               if (EnabledDatosAnexos)
               {
                  if (Presenter.Item.ItemsAnexos != null && Presenter.Item.ItemsAnexos.Count > 0)
                  {
                     SeleccionarAnexo();
                     InstanceItemAnexo(false, false);
                  }
               }
               else
               {
                  rbtANEX_TipoR.Enabled = EnabledDatosAnexos;
                  rbtANEX_TipoI.Enabled = EnabledDatosAnexos;
                  txtANEX_NumeroHBL.Enabled = EnabledDatosAnexos;
                  txtANEX_MroManifiesto.Enabled = EnabledDatosAnexos;
                  mdtANEX_FecLlegada.Enabled = EnabledDatosAnexos;
                  mdtANEX_FecSalida.Enabled = EnabledDatosAnexos;
                  mdtANEX_FecDescarga.Enabled = EnabledDatosAnexos;
                  mdtANEX_FecEmbarque.Enabled = EnabledDatosAnexos;
                  txtANEX_Observaciones.Enabled = EnabledDatosAnexos;
                  txtANEX_DondeDice.Enabled = EnabledDatosAnexos;
                  txtANEX_DebeDecir.Enabled = EnabledDatosAnexos;
                  lvwANEX_Documentos.Enabled = EnabledDatosAnexos;

                  btnNuevoAnexo.Enabled = EnabledDatosAnexos;
                  btnGuardarAnexo.Enabled = EnabledDatosAnexos;
                  btnDeshacerAnexo.Enabled = EnabledDatosAnexos;
                  btnImprimirAnexo.Enabled = EnabledDatosAnexos;
               }

               foreach (Telerik.WinControls.UI.GridViewDataColumn _column in grdItemsAnexos.Columns)
               {
                  if (!_column.ReadOnly)
                  {
                     _column.ReadOnly = !EnabledDatosAnexos;
                  }
               }

               #endregion
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en EnabledItem.", ex);
         }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Se han encontrado los siguientes errores revisar los detalles.", Presenter.Item.MensajeError);

            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Cab_Cotizacion_OV>.Validate(Presenter.Item, this, errorProviderCab_Cotizacion_OV);

            if (!Presenter.Item.ItemsFleteOK)
            {
               errorProviderCab_Cotizacion_OV.SetError(grdItemsFlete, Presenter.Item.ItemsFleteMSGERROR);
            }
            //if (!Presenter.Item.ItemsFleteEmbarqueOK) { errorProviderCab_Cotizacion_OV.SetError(grdItemsFleteEmbarque, Presenter.Item.ItemsFleteEmbarqueMSGERROR); }
            if (!Presenter.Item.ItemsServicioOK)
            {
               errorProviderCab_Cotizacion_OV.SetError(grdItemsServicio, Presenter.Item.ItemsServicioMSGERROR);
            }

            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Cab_Cotizacion_OV>.SetTabError(tabCab_Cotizacion_OV, errorProviderCab_Cotizacion_OV);
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex);
         }
      }

      public void SelectTab(Int16 index)
      {
         try
         {
            //tabCab_Cotizacion_OV.TabPages.Add(pageGenerales);
            //tabCab_Cotizacion_OV.TabPages.Add(pageServiciosTarifa);
            //tabCab_Cotizacion_OV.TabPages.Add(pageEmbarque);
            //tabCab_Cotizacion_OV.TabPages.Add(pageArchivos);
            //tabCab_Cotizacion_OV.TabPages.Add(pageEventosTareas);
            //tabCab_Cotizacion_OV.TabPages.Add(pageAnexos);
            switch (index)
            {
               case 1: //pageGenerales
                  tabCab_Cotizacion_OV.SelectedTab = pageGenerales;
                  break;
               case 2: //pageServiciosTarifa
                  tabCab_Cotizacion_OV.SelectedTab = pageServiciosTarifa;
                  break;
               case 3: //pageEmbarque
                  tabCab_Cotizacion_OV.SelectedTab = pageEmbarque;
                  tabDatosEmbarque.SelectedTab = pageDatosEmision;
                  break;
               case 4: //pageArchivos
                  tabCab_Cotizacion_OV.SelectedTab = pageArchivos;
                  break;
               case 5: //pageEventosTareas
                  tabCab_Cotizacion_OV.SelectedTab = pageEventosTareas;
                  break;
               case 6: //pageAnexos
                  tabCab_Cotizacion_OV.SelectedTab = pageAnexos;
                  break;
            }
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos ]
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

            //Comodity
            Telerik.WinControls.UI.GridViewComboBoxColumn _comodity = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _comodity.Name = "TIPO_CodCDT";
            _comodity.HeaderText = "Comodity";
            _comodity.FieldName = "TIPO_CodCDT";
            _comodity.ValueMember = "TIPO_CodTipo";
            _comodity.DisplayMember = "TIPO_Desc1";
            _comodity.DataSource = Presenter.ListTiposCDT;
            this.grdItemsFlete.Columns.Add(_comodity);
            //Descripción de producto
            this.grdItemsFlete.Columns.Add("DCOT_Producto", "Producto", "DCOT_Producto");
            //bultos
            Telerik.WinControls.UI.GridViewDecimalColumn _bultos = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _bultos.Name = "DCOT_Bultos";
            _bultos.HeaderText = "Bultos";
            _bultos.FieldName = "DCOT_Bultos";
            _bultos.DecimalPlaces = 3;
            this.grdItemsFlete.Columns.Add(_bultos);
            //unidad de medida de los bultos
            Telerik.WinControls.UI.GridViewComboBoxColumn _unidad = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _unidad.Name = "TIPO_CodUnm";
            _unidad.HeaderText = "Unidad Medida";
            _unidad.FieldName = "TIPO_CodUnm";
            _unidad.ValueMember = "TIPO_CodTipo";
            _unidad.DisplayMember = "TIPO_Desc1";
            _unidad.DataSource = Presenter.ListTiposUNM;
            this.grdItemsFlete.Columns.Add(_unidad);
            //peso en kilogramos
            Telerik.WinControls.UI.GridViewDecimalColumn _peso = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _peso.Name = "DCOT_Peso";
            _peso.HeaderText = "Peso (Kg.)";
            _peso.FieldName = "DCOT_Peso";
            _peso.DecimalPlaces = 3;
            this.grdItemsFlete.Columns.Add(_peso);
            //volumen en toneladas m3
            Telerik.WinControls.UI.GridViewDecimalColumn _volumen = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _volumen.Name = "DCOT_Volumen";
            _volumen.HeaderText = "Volumen (m3.)";
            _volumen.FieldName = "DCOT_Volumen";
            _volumen.DecimalPlaces = 3;
            this.grdItemsFlete.Columns.Add(_volumen);
            //largo en centimétros
            Telerik.WinControls.UI.GridViewDecimalColumn _largo = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _largo.Name = "DCOT_Largo";
            _largo.HeaderText = "Largo (cm.)";
            _largo.FieldName = "DCOT_Largo";
            _largo.DecimalPlaces = 2;
            this.grdItemsFlete.Columns.Add(_largo);
            //ancho en centimétros
            Telerik.WinControls.UI.GridViewDecimalColumn _ancho = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _ancho.Name = "DCOT_Ancho";
            _ancho.HeaderText = "Ancho (cm.)";
            _ancho.FieldName = "DCOT_Ancho";
            _ancho.DecimalPlaces = 2;
            this.grdItemsFlete.Columns.Add(_ancho);
            //alto en centimétros
            Telerik.WinControls.UI.GridViewDecimalColumn _alto = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _alto.Name = "DCOT_Alto";
            _alto.HeaderText = "Alto (cm.)";
            _alto.FieldName = "DCOT_Alto";
            _alto.DecimalPlaces = 2;
            this.grdItemsFlete.Columns.Add(_alto);


            grdItemsFlete.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsFlete);
            //grdItemsFlete.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            (grdItemsFlete.Columns["DCOT_Bultos"] as Telerik.WinControls.UI.GridViewDecimalColumn).DecimalPlaces = 0;
            (grdItemsFlete.Columns["DCOT_Bultos"] as Telerik.WinControls.UI.GridViewDecimalColumn).FormatString = "{0:###,##0}";
            (grdItemsFlete.Columns["DCOT_Peso"] as Telerik.WinControls.UI.GridViewDecimalColumn).DecimalPlaces = 3;
            (grdItemsFlete.Columns["DCOT_Peso"] as Telerik.WinControls.UI.GridViewDecimalColumn).FormatString = "{0:###,##0.000}";
            (grdItemsFlete.Columns["DCOT_Volumen"] as Telerik.WinControls.UI.GridViewDecimalColumn).DecimalPlaces = 3;
            (grdItemsFlete.Columns["DCOT_Volumen"] as Telerik.WinControls.UI.GridViewDecimalColumn).FormatString = "{0:###,##0.000}";

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


            this.grdItemsFlete.Columns["DCOT_Item"].ReadOnly = true;
            this.grdItemsFlete.Columns["TIPO_CodCDT"].ReadOnly = false;
            this.grdItemsFlete.Columns["DCOT_Producto"].ReadOnly = false;
            this.grdItemsFlete.Columns["DCOT_Bultos"].ReadOnly = false;
            this.grdItemsFlete.Columns["TIPO_CodUnm"].ReadOnly = false;
            this.grdItemsFlete.Columns["DCOT_Peso"].ReadOnly = false;
            this.grdItemsFlete.Columns["DCOT_Volumen"].ReadOnly = false;
            this.grdItemsFlete.Columns["DCOT_Largo"].ReadOnly = false;
            this.grdItemsFlete.Columns["DCOT_Ancho"].ReadOnly = false;
            this.grdItemsFlete.Columns["DCOT_Alto"].ReadOnly = false;

            this.grdItemsFlete.Columns["DCOT_Item"].Width = 40;
            this.grdItemsFlete.Columns["TIPO_CodCDT"].Width = 100;
            this.grdItemsFlete.Columns["DCOT_Producto"].Width = 200;
            this.grdItemsFlete.Columns["DCOT_Bultos"].Width = 80;
            this.grdItemsFlete.Columns["TIPO_CodUnm"].Width = 80;
            this.grdItemsFlete.Columns["DCOT_Peso"].Width = 80;
            this.grdItemsFlete.Columns["DCOT_Volumen"].Width = 80;
            this.grdItemsFlete.Columns["DCOT_Largo"].Width = 80;
            this.grdItemsFlete.Columns["DCOT_Ancho"].Width = 80;
            this.grdItemsFlete.Columns["DCOT_Alto"].Width = 80;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex);
         }
      }
      private void ConfigureGridFlete()
      {
         try
         {
            if (this.grdItemsFlete.Columns.Contains("PACK_Codigo"))
            {
               if (cmbCONS_CodFLE.ConstantesSelectedItem != null)
               {
                  switch (cmbCONS_CodFLE.ConstantesSelectedItem.CONS_CodTipo)
                  {
                     case Delfin.Controls.variables.CONSFLE_FCL_LCL:
                     case Delfin.Controls.variables.CONSFLE_FCL_FCL:
                        ((Telerik.WinControls.UI.GridViewComboBoxColumn)this.grdItemsFlete.Columns["PACK_Codigo"]).DataSource = Presenter.ListPaquetes.Where(pack => pack.TIPO_CodPAQ == "001").ToObservableCollection();
                        if (Presenter.OVEDITARCOSTO)
                        {
                           this.grdItemsFlete.Columns["DCOT_PrecioUniCosto"].IsVisible = true;
                           this.grdItemsFlete.Columns["DCOT_TotalUniCosto"].IsVisible = true;
                        }
                        else
                        {
                           this.grdItemsFlete.Columns["DCOT_PrecioUniCosto"].IsVisible = false;
                           this.grdItemsFlete.Columns["DCOT_TotalUniCosto"].IsVisible = false;
                        }

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
                  if (Presenter.OVEDITARCOSTO)
                  {
                     this.grdItemsFlete.Columns["DCOT_PrecioUniCosto"].IsVisible = true;
                     this.grdItemsFlete.Columns["DCOT_TotalUniCosto"].IsVisible = true;
                  }
                  else
                  {
                     this.grdItemsFlete.Columns["DCOT_PrecioUniCosto"].IsVisible = false;
                     this.grdItemsFlete.Columns["DCOT_TotalUniCosto"].IsVisible = false;
                  }
               }
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Flete)", ex);
         }
      }
      //private void FormatGridFleteEmbarque()
      //{
      //   try
      //   {
      //      Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
      //      this.grdItemsFleteEmbarque.Columns.Clear();
      //      this.grdItemsFleteEmbarque.AllowAddNewRow = false;
      //      //Item
      //      this.grdItemsFleteEmbarque.Columns.Add("DCOT_Item", "Item", "DCOT_Item");
      //      //Comodity
      //      Telerik.WinControls.UI.GridViewComboBoxColumn _comodity = new Telerik.WinControls.UI.GridViewComboBoxColumn();
      //      _comodity.Name = "TIPO_CodCDT";
      //      _comodity.HeaderText = "Comodity";
      //      _comodity.FieldName = "TIPO_CodCDT";
      //      _comodity.ValueMember = "TIPO_CodTipo";
      //      _comodity.DisplayMember = "TIPO_Desc1";
      //      _comodity.DataSource = Presenter.ListTiposCDT;
      //      this.grdItemsFleteEmbarque.Columns.Add(_comodity);
      //      //Descripción de producto
      //      this.grdItemsFleteEmbarque.Columns.Add("DCOT_Producto", "Producto", "DCOT_Producto");
      //      //bultos
      //      Telerik.WinControls.UI.GridViewDecimalColumn _bultos = new Telerik.WinControls.UI.GridViewDecimalColumn();
      //      _bultos.Name = "DCOT_Bultos";
      //      _bultos.HeaderText = "Bultos";
      //      _bultos.FieldName = "DCOT_Bultos";
      //      _bultos.DecimalPlaces = 0;
      //      this.grdItemsFleteEmbarque.Columns.Add(_bultos);
      //      //unidad de medida de los bultos
      //      Telerik.WinControls.UI.GridViewComboBoxColumn _unidad = new Telerik.WinControls.UI.GridViewComboBoxColumn();
      //      _unidad.Name = "TIPO_CodUnm";
      //      _unidad.HeaderText = "Unidad Medida";
      //      _unidad.FieldName = "TIPO_CodUnm";
      //      _unidad.ValueMember = "TIPO_CodTipo";
      //      _unidad.DisplayMember = "TIPO_Desc1";
      //      _unidad.DataSource = Presenter.ListTiposUNM;
      //      this.grdItemsFleteEmbarque.Columns.Add(_unidad);
      //      //peso en kilogramos
      //      Telerik.WinControls.UI.GridViewDecimalColumn _peso = new Telerik.WinControls.UI.GridViewDecimalColumn();
      //      _peso.Name = "DCOT_Peso";
      //      _peso.HeaderText = "Peso (Kg.)";
      //      _peso.FieldName = "DCOT_Peso";
      //      _peso.DecimalPlaces = 2;
      //      this.grdItemsFleteEmbarque.Columns.Add(_peso);
      //      //volumen en toneladas m3
      //      Telerik.WinControls.UI.GridViewDecimalColumn _volumen = new Telerik.WinControls.UI.GridViewDecimalColumn();
      //      _volumen.Name = "DCOT_Volumen";
      //      _volumen.HeaderText = "Volumen (m3.)";
      //      _volumen.FieldName = "DCOT_Volumen";
      //      _volumen.DecimalPlaces = 2;
      //      this.grdItemsFleteEmbarque.Columns.Add(_volumen);
      //      //largo en centimétros
      //      Telerik.WinControls.UI.GridViewDecimalColumn _largo = new Telerik.WinControls.UI.GridViewDecimalColumn();
      //      _largo.Name = "DCOT_Largo";
      //      _largo.HeaderText = "Largo (cm.)";
      //      _largo.FieldName = "DCOT_Largo";
      //      _largo.DecimalPlaces = 2;
      //      this.grdItemsFleteEmbarque.Columns.Add(_largo);
      //      //ancho en centimétros
      //      Telerik.WinControls.UI.GridViewDecimalColumn _ancho = new Telerik.WinControls.UI.GridViewDecimalColumn();
      //      _ancho.Name = "DCOT_Ancho";
      //      _ancho.HeaderText = "Ancho (cm.)";
      //      _ancho.FieldName = "DCOT_Ancho";
      //      _ancho.DecimalPlaces = 2;
      //      this.grdItemsFleteEmbarque.Columns.Add(_ancho);
      //      //alto en centimétros
      //      Telerik.WinControls.UI.GridViewDecimalColumn _alto = new Telerik.WinControls.UI.GridViewDecimalColumn();
      //      _alto.Name = "DCOT_Alto";
      //      _alto.HeaderText = "Alto (cm.)";
      //      _alto.FieldName = "DCOT_Alto";
      //      _alto.DecimalPlaces = 2;
      //      this.grdItemsFleteEmbarque.Columns.Add(_alto);

      //      grdItemsFleteEmbarque.BestFitColumns();
      //      Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsFleteEmbarque);
      //      grdItemsFleteEmbarque.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

      //      this.grdItemsFleteEmbarque.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
      //      this.grdItemsFleteEmbarque.MultiSelect = false;

      //      this.grdItemsFleteEmbarque.ShowFilteringRow = false;
      //      this.grdItemsFleteEmbarque.EnableFiltering = false;
      //      this.grdItemsFleteEmbarque.MasterTemplate.EnableFiltering = false;
      //      this.grdItemsFleteEmbarque.EnableGrouping = false;
      //      this.grdItemsFleteEmbarque.MasterTemplate.EnableGrouping = false;
      //      this.grdItemsFleteEmbarque.EnableSorting = false;
      //      this.grdItemsFleteEmbarque.MasterTemplate.EnableCustomSorting = false;

      //      this.grdItemsFleteEmbarque.ReadOnly = false;
      //      this.grdItemsFleteEmbarque.AllowEditRow = true;

      //      this.grdItemsFleteEmbarque.Columns["DCOT_Item"].ReadOnly = true;
      //      this.grdItemsFleteEmbarque.Columns["TIPO_CodCDT"].ReadOnly = false;
      //      this.grdItemsFleteEmbarque.Columns["DCOT_Producto"].ReadOnly = false;
      //      this.grdItemsFleteEmbarque.Columns["DCOT_Bultos"].ReadOnly = false;
      //      this.grdItemsFleteEmbarque.Columns["TIPO_CodUnm"].ReadOnly = false;
      //      this.grdItemsFleteEmbarque.Columns["DCOT_Peso"].ReadOnly = false;
      //      this.grdItemsFleteEmbarque.Columns["DCOT_Volumen"].ReadOnly = false;
      //      this.grdItemsFleteEmbarque.Columns["DCOT_Largo"].ReadOnly = false;
      //      this.grdItemsFleteEmbarque.Columns["DCOT_Ancho"].ReadOnly = false;
      //      this.grdItemsFleteEmbarque.Columns["DCOT_Alto"].ReadOnly = false;


      //      this.grdItemsFleteEmbarque.Columns["DCOT_Item"].Width = 40;
      //      this.grdItemsFleteEmbarque.Columns["TIPO_CodCDT"].Width = 100;
      //      this.grdItemsFleteEmbarque.Columns["DCOT_Producto"].Width = 200;
      //      this.grdItemsFleteEmbarque.Columns["DCOT_Bultos"].Width = 80;
      //      this.grdItemsFleteEmbarque.Columns["TIPO_CodUnm"].Width = 80;
      //      this.grdItemsFleteEmbarque.Columns["DCOT_Peso"].Width = 80;
      //      this.grdItemsFleteEmbarque.Columns["DCOT_Volumen"].Width = 80;
      //      this.grdItemsFleteEmbarque.Columns["DCOT_Largo"].Width = 80;
      //      this.grdItemsFleteEmbarque.Columns["DCOT_Ancho"].Width = 80;
      //      this.grdItemsFleteEmbarque.Columns["DCOT_Alto"].Width = 80;
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Flete Embarque)", ex); }
      //}
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
            //grdItemsNovedades.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            this.grdItemsNovedades.ShowFilteringRow = false;
            this.grdItemsNovedades.EnableFiltering = false;
            this.grdItemsNovedades.MasterTemplate.EnableFiltering = false;
            this.grdItemsNovedades.EnableGrouping = false;
            this.grdItemsNovedades.MasterTemplate.EnableGrouping = false;
            this.grdItemsNovedades.EnableSorting = false;
            this.grdItemsNovedades.MasterTemplate.EnableCustomSorting = false;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Novedades)", ex);
         }
      }

      private void AddFlete()
      {
         try
         {
            Entities.Det_Cotizacion_OV_Flete _flete = new Entities.Det_Cotizacion_OV_Flete();
            Int32 _DCOT_Item = 0;
            if (((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Count > 0)
            {
               _DCOT_Item = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Max(dcot => dcot.DCOT_Item);
            }
            _flete.DCOT_Item = _DCOT_Item + 1;
            _flete.AUDI_UsrCrea = Presenter.Session.UserName;
            _flete.AUDI_FecCrea = Presenter.Session.Fecha;
            _flete.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            BSItemsFlete.Add(_flete);
            BSItemsFlete.ResetBindings(true);
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un flete", ex);
         }
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
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar un flete", ex);
         }
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
                  {
                     ((Entities.Det_Cotizacion_OV_Flete)grdItemsFlete.Rows[rowIndex].DataBoundItem).ItemPaquete = Presenter.ListPaquetes.Where(pack => pack.PACK_Codigo == _PACK_Codigo).FirstOrDefault();
                  }


                  if (txaCONT_Numero.Value != null && txaCONT_Numero.Value is Entities.Contrato && txaPUER_CodOrigen.SelectedItem != null && txaPUER_CodDestino.SelectedItem != null)
                  {

                     Entities.Contrato _itemContrato = (Entities.Contrato)txaCONT_Numero.Value;
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

            txnDCOT_Importe.Text = _DCOT_Venta.ToString();
            txnDCOT_Rentabilidad.Text = (_DCOT_Venta - _DCOT_Costo).ToString();
         }
         catch (Exception)
         {
         }
      }
      public void ClearItemContacto()
      {
         try
         {
            txaENTC_CodEjecutivo.ClearValue();
            txaENTC_CodBroker.ClearValue();
            txaENTC_CodCustomer.ClearValue();

            txtENTC_NomContacto.Text = String.Empty;
            txtENTC_CargoContacto.Text = String.Empty;
            txtENTC_EmailContacto.Text = String.Empty;

            btnNuevoContacto.Enabled = true;
            btnEditarContacto.Enabled = false;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al limpiar el item de Contacto.", ex);
         }
      }
      //public void SetItemContacto()
      //{
      //   try
      //   {
      //      ClearItemContacto();

      //      if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
      //      {
      //         if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
      //         {
      //            if (txaENTC_CodCliente.Value != null && txaENTC_CodCliente.Value.ENTC_CodEjecutivoImpo.HasValue)
      //            {
      //               txaENTC_CodEjecutivo.SetValue(txaENTC_CodCliente.Value.ENTC_CodEjecutivoImpo.Value);
      //            }

      //            if (txaENTC_CodCliente.Value != null && txaENTC_CodCliente.Value.ENTC_CodCustomerImpo.HasValue)
      //            {
      //               txaENTC_CodCustomer.SetValue(txaENTC_CodCliente.Value.ENTC_CodCustomerImpo.Value);
      //            }
      //         }
      //         else
      //         {
      //            if (txaENTC_CodCliente.Value != null && txaENTC_CodCliente.Value.ENTC_CodEjecutivoExpo.HasValue)
      //            {
      //               txaENTC_CodEjecutivo.SetValue(txaENTC_CodCliente.Value.ENTC_CodEjecutivoExpo.Value);
      //            }

      //            if (txaENTC_CodCliente.Value != null && txaENTC_CodCliente.Value.ENTC_CodCustomerExpo.HasValue)
      //            {
      //               txaENTC_CodCustomer.SetValue(txaENTC_CodCliente.Value.ENTC_CodCustomerExpo.Value);
      //            }
      //         }
      //      }

      //      if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
      //      {
      //         if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == "001" && txaENTC_CodCliente.Value != null && txaENTC_CodCliente.Value.ContactoImpo != null)
      //         {
      //            txtENTC_NomContacto.Text = txaENTC_CodCliente.Value.ContactoImpo.ENTC_NomCompleto;
      //            txtENTC_CargoContacto.Text = txaENTC_CodCliente.Value.ContactoImpo.ENTC_Cargo;
      //            txtENTC_EmailContacto.Text = txaENTC_CodCliente.Value.ContactoImpo.ENTC_EMail;

      //            btnNuevoContacto.Enabled = false;
      //            btnEditarContacto.Enabled = true;
      //         }
      //         else if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == "002" && txaENTC_CodCliente.Value != null && txaENTC_CodCliente.Value.ContactoExpo != null)
      //         {
      //            txtENTC_NomContacto.Text = txaENTC_CodCliente.Value.ContactoExpo.ENTC_NomCompleto;
      //            txtENTC_CargoContacto.Text = txaENTC_CodCliente.Value.ContactoExpo.ENTC_Cargo;
      //            txtENTC_EmailContacto.Text = txaENTC_CodCliente.Value.ContactoExpo.ENTC_EMail;

      //            btnNuevoContacto.Enabled = false;
      //            btnEditarContacto.Enabled = true;
      //         }
      //      }
      //   }
      //   catch (Exception ex)
      //   {
      //      Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al setear el item de Contacto.", ex);
      //   }
      //}
      private void NuevoContacto()
      {
         try
         {
            if (cmbCONS_CodRGM.ConstantesSelectedItem != null && txaENTC_CodCliente.Value != null)
            {
               Entities.Entidad _cliente = txaENTC_CodCliente.Value;
               Presenter.Contacto(true, ref _cliente, cmbCONS_CodRGM.ConstantesSelectedItem);
               txaENTC_CodCliente.SetValue(_cliente.ENTC_Codigo);
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al crear nuevo item de Contacto.", ex);
         }
      }
      private void EditarContacto()
      {
         try
         {
            if (cmbCONS_CodRGM.ConstantesSelectedItem != null && txaENTC_CodCliente.Value != null)
            {
               Entities.Entidad _cliente = txaENTC_CodCliente.Value;
               Presenter.Contacto(false, ref _cliente, cmbCONS_CodRGM.ConstantesSelectedItem);
               txaENTC_CodCliente.SetValue(_cliente.ENTC_Codigo);
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al editar el item de Contacto.", ex);
         }
      }
      private void SetDatosAdicionalesCliente()
      {
         try
         {
            if (Presenter.Item != null && txaENTC_CodCliente.Value != null)
            {
               //txaENTC_CodCliente.Value.Relacionados.Where( rela => rela.CONS_CodRGM == cmbCONS_CodRGM.ConstantesSelectedValue && rela.cons

               //TIPO_CodDTM.TiposSelectedValue = ENTC_CodCliente.Value.TIPO_CodDTM;
               if (txaENTC_CodCliente.Value.EntidadDeposito != null && txaENTC_CodCliente.Value.EntidadDeposito.Count > 0)
               {
                  if (!Presenter.Item.ENTC_CodDepTemporal.HasValue && txaENTC_CodCliente.Value.EntidadDeposito[0].ENTC_CodHijo.HasValue)
                  {
                     txaENTC_CodDepTemporal.SetValue(txaENTC_CodCliente.Value.EntidadDeposito[0].ENTC_CodHijo.Value);
                  }
               }
            }

            SetServiciosCliente();

            ////if (Presenter.Item != null && Presenter.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
            ////{
            //if (txaENTC_CodCliente.Value != null && cmbCONS_CodVia.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem != null)
            //{
            //   //TIPO_CodDTM.TiposSelectedValue = ENTC_CodCliente.Value.TIPO_CodDTM;
            //   //if (txaENTC_CodCliente.Value.EntidadDeposito != null && txaENTC_CodCliente.Value.EntidadDeposito.Count > 0)
            //   //{
            //   //   if (!Presenter.Item.ENTC_CodDepTemporal.HasValue && txaENTC_CodCliente.Value.EntidadDeposito[0].ENTC_CodHijo.HasValue)
            //   //   { txaENTC_CodDepTemporal.SetValue(txaENTC_CodCliente.Value.EntidadDeposito[0].ENTC_CodHijo.Value); }
            //   //}

            //   if (txaENTC_CodCliente.Value.ListServicio != null && txaENTC_CodCliente.Value.ListServicio.Where(eser => eser.ESER_Valor > (Decimal)0.00 && eser.CONS_CodVIA == cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo && eser.CONS_CodRGM == cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection().Count > 0)
            //   {
            //      foreach (Entities.Entidad_Servicio itemEntidadServicio in txaENTC_CodCliente.Value.ListServicio.Where(eser => eser.ESER_Valor > (Decimal)0.00 && eser.CONS_CodVIA == cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo && eser.CONS_CodRGM == cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection())
            //      {
            //         if (itemEntidadServicio.SERV_Codigo.HasValue)
            //         {
            //            if (((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicio.DataSource).Where(scot => scot.SERV_Codigo == itemEntidadServicio.SERV_Codigo.Value).FirstOrDefault() == null)
            //            {
            //               Entities.Det_Cotizacion_OV_Servicio _servicio = new Entities.Det_Cotizacion_OV_Servicio();
            //               Int32 _SCOT_Item = 0;
            //               if (((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicio.DataSource).Count > 0)
            //               {
            //                  _SCOT_Item = ((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicio.DataSource).Max(scot => scot.SCOT_Item);
            //               }
            //               _servicio.SCOT_Item = _SCOT_Item + 1;

            //               _servicio.CCOT_IngresoGasto = "I";
            //               _servicio.SERV_Codigo = itemEntidadServicio.SERV_Codigo.Value;
            //               _servicio.SCOT_Exonerado = itemEntidadServicio.ESER_Exonerado;
            //               _servicio.SCOT_PreSugerido = itemEntidadServicio.ESER_Valor;
            //               _servicio.SCOT_PrecioUni = itemEntidadServicio.ESER_Valor;

            //               _servicio.SCOT_Cantidad = itemEntidadServicio.ESER_Cantidad;
            //               _servicio.TIPO_TabMnd = itemEntidadServicio.TIPO_TabMnd;
            //               _servicio.TIPO_CodMnd = itemEntidadServicio.TIPO_CodMnd;
            //               _servicio.CONS_TabBas = itemEntidadServicio.CONS_TabBas;
            //               _servicio.CONS_CodBas = itemEntidadServicio.CONS_CodBas;

            //               switch (_servicio.CONS_CodBas)
            //               {
            //                  case Delfin.Controls.variables.CONSBASFIJO:
            //                     _servicio.SCOT_Cantidad = 1;
            //                     break;
            //                  default:
            //                     break;
            //               }

            //               _servicio.AUDI_UsrCrea = Presenter.Session.UserName;
            //               _servicio.AUDI_FecCrea = Presenter.Session.Fecha;
            //               _servicio.TIPE_Codigo = 1;
            //               _servicio.ENTC_Codigo = txaENTC_CodCliente.Value.ENTC_Codigo;
            //               _servicio.ENTC_NomCom = txaENTC_CodCliente.Value.ENTC_NomCompleto;

            //               _servicio.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

            //               BSItemsServicio.Add(_servicio);
            //            }
            //         }
            //      }

            //      BSItemsServicio.ResetBindings(true);
            //   }
            //}
            //}
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al cargar los datos adicionales del Cliente.", ex);
         }
      }
      private void SetRelacionadosCliente()
      {
         try
         {
            ClearItemContacto();

            if (txaENTC_CodCliente.Value != null)
            {
               if (txaENTC_CodConsignee.Value == null) { txaENTC_CodConsignee.SetValue(txaENTC_CodCliente.Value.ENTC_Codigo); }
               if (txaENTC_CodNotify.Value == null) { txaENTC_CodNotify.SetValue(txaENTC_CodCliente.Value.ENTC_Codigo); }
            }

            if (cmbCONS_CodRGM.ConstantesSelectedItem != null && txaENTC_CodCliente.Value != null && txaENTC_CodCliente.Value.Relacionados != null && txaENTC_CodCliente.Value.Relacionados.Count > 0) //&& cmbTIPO_CodTRF.TiposSelectedItem != null
            {
               var _itemsRelacionados = txaENTC_CodCliente.Value.Relacionados.Where(rela => rela.Relacionado.CONS_CodRGM == cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection(); //&& rela.Relacionado.TIPO_CodTRF == cmbTIPO_CodTRF.TiposSelectedItem.TIPO_CodTipo
               foreach (var _itemRelacionado in _itemsRelacionados)
               {
                  switch (_itemRelacionado.TIPE_Codigo)
                  {
                     case 3: //Ejecutivos de Venta
                        if (txaENTC_CodEjecutivo.Value == null)
                        { txaENTC_CodEjecutivo.SetValue(_itemRelacionado.ENTC_Codigo); }
                        break;
                     case 4: //Customer Services
                        if (txaENTC_CodCustomer.Value == null)
                        { txaENTC_CodCustomer.SetValue(_itemRelacionado.ENTC_Codigo); }
                        break;
                     case 6: //Agente Carga
                        if (txaENTC_CodAgente.Value == null)
                        { txaENTC_CodAgente.SetValue(_itemRelacionado.ENTC_Codigo); }
                        break;
                     case 9: //Contacto
                        txtENTC_NomContacto.Text = _itemRelacionado.ENTC_NomCompleto;
                        txtENTC_CargoContacto.Text = _itemRelacionado.ENTC_Cargo;
                        txtENTC_EmailContacto.Text = _itemRelacionado.ENTC_EMail;

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
      //private void SetDatosAdicionalesAgente()
      //{
      //   try
      //   {
      //      //if (Presenter.Item != null && Presenter.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
      //      //{
      //      if (txaENTC_CodAgente.Value != null && cmbCONS_CodVia.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem != null)
      //      {
      //         if (txaENTC_CodAgente.Value.ListServicio != null && txaENTC_CodAgente.Value.ListServicio.Where(eser => eser.ESER_Valor > (Decimal)0.00 && eser.CONS_CodVIA == cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo && eser.CONS_CodRGM == cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection().Count > 0)
      //         {

      //            foreach (Entities.Entidad_Servicio itemEntidadServicio in txaENTC_CodAgente.Value.ListServicio.Where(eser => eser.ESER_Valor > (Decimal)0.00 && eser.CONS_CodVIA == cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo && eser.CONS_CodRGM == cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection())
      //            {
      //               if (itemEntidadServicio.SERV_Codigo.HasValue)
      //               {
      //                  if (((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicio.DataSource).Where(scot => scot.SERV_Codigo == itemEntidadServicio.SERV_Codigo.Value).FirstOrDefault() == null)
      //                  {
      //                     Entities.Det_Cotizacion_OV_Servicio _servicio = new Entities.Det_Cotizacion_OV_Servicio();
      //                     Int32 _SCOT_Item = 0;
      //                     if (((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicio.DataSource).Count > 0)
      //                     { _SCOT_Item = ((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicio.DataSource).Max(scot => scot.SCOT_Item); }
      //                     _servicio.SCOT_Item = _SCOT_Item + 1;

      //                     _servicio.SERV_Codigo = itemEntidadServicio.SERV_Codigo.Value;
      //                     _servicio.SCOT_Exonerado = itemEntidadServicio.ESER_Exonerado;
      //                     _servicio.SCOT_PreSugerido = itemEntidadServicio.ESER_Valor;
      //                     _servicio.SCOT_PrecioUni = itemEntidadServicio.ESER_Valor;

      //                     _servicio.SCOT_Cantidad = itemEntidadServicio.ESER_Cantidad;
      //                     _servicio.TIPO_TabMnd = itemEntidadServicio.TIPO_TabMnd;
      //                     _servicio.TIPO_CodMnd = itemEntidadServicio.TIPO_CodMnd;
      //                     _servicio.CONS_TabBas = itemEntidadServicio.CONS_TabBas;
      //                     _servicio.CONS_CodBas = itemEntidadServicio.CONS_CodBas;

      //                     _servicio.TIPE_Codigo = 1;
      //                     _servicio.ENTC_Codigo = txaENTC_CodCliente.Value.ENTC_Codigo;
      //                     _servicio.ENTC_NomCom = txaENTC_CodCliente.Value.ENTC_NomCompleto;

      //                     _servicio.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

      //                     BSItemsServicio.Add(_servicio);
      //                  }
      //               }
      //            }

      //            BSItemsServicio.ResetBindings(true);
      //         }
      //      }
      //      //}
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al cargar los datos adicionales del Cliente.", ex); }
      //}
      #endregion

      #region [ Servicios ]

      #region [ Generales ]
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
                              break;
                           case "C":
                              _itemDet_Cotizacion_OV_Servicio.CCOT_IngresoGasto = "E";
                              break;
                           case "I":
                              _itemDet_Cotizacion_OV_Servicio.CCOT_IngresoGasto = "I";
                              if (txaENTC_CodCliente.Value != null)
                              {
                                 _itemDet_Cotizacion_OV_Servicio.TIPE_Codigo = Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Cliente);
                                 _itemDet_Cotizacion_OV_Servicio.ENTC_Codigo = txaENTC_CodCliente.Value.ENTC_Codigo;
                                 _itemDet_Cotizacion_OV_Servicio.ENTC_NomCom = txaENTC_CodCliente.Value.ENTC_NomCompleto;
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
            if (Presenter.Item != null && Presenter.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
            {
               if (cmbCONS_CodVia.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodLNG.ConstantesSelectedItem != null)
               {
                  if (txaENTC_CodCliente.Value != null && txaENTC_CodCliente.Value.ListServicio != null)
                  {
                     ObservableCollection<Entities.Entidad_Servicio> _listEntidad_Servicio = txaENTC_CodCliente.Value.ListServicio.Where(eser => eser.ESER_Valor > (Decimal)0.00 && eser.CONS_CodVIA == cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo && eser.CONS_CodRGM == cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo && eser.CONS_CodLNG == cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection();
                     if (_listEntidad_Servicio.Count > 0)
                     { SetServiciosAdicionales(_listEntidad_Servicio, Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Cliente), txaENTC_CodCliente.Value.ENTC_Codigo, txaENTC_CodCliente.Value.ENTC_NomCompleto); }
                  }
               }
            }
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
                  if (txaENTC_CodTransportista.Value != null && txaENTC_CodTransportista.Value.ListServicio != null)
                  {
                     if (txaENTC_CodTransportista.Value.ListServicio.Where(eser => eser.ESER_Valor > (Decimal)0.00).ToObservableCollection().Count > 0)
                     {
                        ObservableCollection<Entities.Entidad_Servicio> _listEntidad_Servicio = txaENTC_CodTransportista.Value.ListServicio.Where(eser => eser.ESER_Valor > (Decimal)0.00 && eser.CONS_CodVIA == cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo && eser.CONS_CodRGM == cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo && eser.CONS_CodLNG == cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection();
                        if (_listEntidad_Servicio.Count > 0)
                        { SetServiciosAdicionales(_listEntidad_Servicio, Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Transportista), txaENTC_CodTransportista.Value.ENTC_Codigo, txaENTC_CodTransportista.Value.ENTC_NomCompleto); }
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
            if (Presenter.Item != null && Presenter.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
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
                  foreach (var item in grdItemsServicio.Rows)
                  {
                     //item.Cells["SERV_Codigo"].Value = null;
                  }
               }
            }

            if (grdItemsServiciosChangeControl.Columns.Contains("SERV_Codigo") && grdItemsServiciosChangeControl.Columns["SERV_Codigo"] != null)
            {
               if (cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodVia.ConstantesSelectedItem != null && cmbCONS_CodLNG.ConstantesSelectedItem != null)
               {
                  Presenter.LoadServicios(cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla, cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo, cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTabla, cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo, cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTabla, cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTipo);
                  (grdItemsServiciosChangeControl.Columns["SERV_Codigo"] as Telerik.WinControls.UI.GridViewComboBoxColumn).DataSource = Presenter.ListServicio.OrderBy(serv => serv.SERV_Nombre_SPA).ToObservableCollection();

                  Boolean _noExiste = false;
                  foreach (var item in grdItemsServiciosChangeControl.Rows)
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
                  (grdItemsServiciosChangeControl.Columns["SERV_Codigo"] as Telerik.WinControls.UI.GridViewComboBoxColumn).DataSource = Presenter.ListServicio.OrderBy(serv => serv.SERV_Nombre_SPA).ToObservableCollection();
                  foreach (var item in grdItemsServiciosChangeControl.Rows)
                  {
                     //item.Cells["SERV_Codigo"].Value = null;
                  }
               }
            }

         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al configurar los servicios de la Grilla.", ex);
         }
      }
      private void SetTipoDocumentoServicios(Boolean IsChangeControl)
      {
         try
         {
            if (!IsChangeControl)
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
                                                                       orderby doc.SEDO_Item
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
            else
            {
               foreach (Entities.Det_Cotizacion_OV_Servicio _itemDet_Cotizacion_OV_Servicio in Presenter.Item.ItemsServicioChangeControl)
               {
                  if (String.IsNullOrEmpty(_itemDet_Cotizacion_OV_Servicio.TIPO_CodTDO) && !String.IsNullOrEmpty(_itemDet_Cotizacion_OV_Servicio.CCOT_IngresoGasto))
                  {
                     String _movimiento = _itemDet_Cotizacion_OV_Servicio.CCOT_IngresoGasto;
                     if (_movimiento == "E") { _movimiento = "C"; }

                     ObservableCollection<Entities.ServiciosDocumentos> _serviciosDocumento = Presenter.Client.GetAllServiciosDocumentosByServCodigo(_itemDet_Cotizacion_OV_Servicio.SERV_Codigo).ToObservableCollection();//.Where(doc => doc.SEDO_Seleccionar == 1)
                     ObservableCollection<Entities.Tipos> _tiposTDO = (from tdo in Presenter.ListTiposTDO
                                                                       join doc in _serviciosDocumento on tdo.TIPO_CodTipo equals doc.TIPO_CodTDO
                                                                       where doc.SEDO_Tipo == _movimiento
                                                                       orderby doc.SEDO_Item
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
         }
         catch (Exception)
         { }
      }
      private void SetDatosServicios(Boolean IsChangeControl, Int32 rowIndex)
      {
         try
         {
            if (!IsChangeControl)
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

                     //switch (_itemServicio.SERV_TipoMov)
                     //{
                     //   case "A":
                     //      grdItemsServicio.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value = null;
                     //      break;
                     //   case "C":
                     //      grdItemsServicio.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value = "E";
                     //      break;
                     //   case "I":
                     //      grdItemsServicio.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value = "I";
                     //      break;
                     //}

                     //if (grdItemsServicio.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value != null)
                     //{
                     //   String _movimiento = grdItemsServicio.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value.ToString();
                     //   if (_movimiento == "E") { _movimiento = "C"; }

                     //   ObservableCollection<Entities.ServiciosDocumentos> _serviciosDocumento = Presenter.Client.GetAllServiciosDocumentosByServCodigo(_itemServicio.SERV_Codigo).ToObservableCollection();//.Where(doc => doc.SEDO_Seleccionar == 1)
                     //   ObservableCollection<Entities.Tipos> _tiposTDO = (from tdo in Presenter.ListTiposTDO
                     //                                                     join doc in _serviciosDocumento on tdo.TIPO_CodTipo equals doc.TIPO_CodTDO
                     //                                                     where doc.SEDO_Tipo == _movimiento
                     //                                                     select tdo).ToObservableCollection();

                     //   if (_tiposTDO.Count > 0)
                     //   {
                     //      grdItemsServicio.Rows[rowIndex].Cells["TIPO_TabTDO"].Value = _tiposTDO[0].TIPO_CodTabla;
                     //      grdItemsServicio.Rows[rowIndex].Cells["TIPO_CodTDO"].Value = _tiposTDO[0].TIPO_CodTipo;
                     //      grdItemsServicio.Rows[rowIndex].Cells["TIPO_DescTDO"].Value = _tiposTDO[0].TIPO_Desc1;
                     //   }
                     //}


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
                           if (txaENTC_CodCliente.Value != null)
                           {
                              grdItemsServicio.Rows[rowIndex].Cells["TIPE_Codigo"].Value = Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Cliente);
                              grdItemsServicio.Rows[rowIndex].Cells["ENTC_Codigo"].Value = txaENTC_CodCliente.Value.ENTC_Codigo;
                              grdItemsServicio.Rows[rowIndex].Cells["ENTC_NomCom"].Value = txaENTC_CodCliente.Value.ENTC_NomCompleto;
                           }
                           break;
                     }

                     if (_itemServicio.SERV_AfeIgv.HasValue)
                     {
                        //if (grdItemsServicio.Rows[rowIndex].Cells["ENTC_Domiciliado"].Value != DBNull.Value)
                        //{
                        //   if ((Boolean)grdItemsServicio.Rows[rowIndex].Cells["ENTC_Domiciliado"].Value)
                        //   { grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = false; }
                        //   else
                        //   { grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = _itemServicio.SERV_AfeIgv.Value; }
                        //}
                        //else
                        grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = _itemServicio.SERV_AfeIgv.Value;
                        grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeIgvServicio"].Value = _itemServicio.SERV_AfeIgv.Value;
                     }
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
                           //_SCOT_Cantidad = (Decimal)1.00;
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
                        SetTipoDocumentoServicio(IsChangeControl, rowIndex);

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
            else
            {
               Int32 _SERV_Codigo;
               if (grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_Codigo"].Value != null && Int32.TryParse(grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_Codigo"].Value.ToString(), out _SERV_Codigo))
               {
                  Entities.Servicio _itemServicio = Presenter.ListServicio.Where(serv => serv.SERV_Codigo == _SERV_Codigo).FirstOrDefault();

                  if (_itemServicio != null)
                  {
                     //grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SCOT_PrecioUni"].Value = _itemServicio.SERV_Valor;
                     //grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = _itemServicio.SERV_AfeIgv;
                     //grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeDet"].Value = _itemServicio.SERV_AfeDet;
                     //grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SCOT_PreSugerido"].Value = _itemServicio.SERV_Valor;

                     //switch (_itemServicio.SERV_TipoMov)
                     //{
                     //   case "A":
                     //      grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value = null;
                     //      break;
                     //   case "C":
                     //      grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value = "E";
                     //      break;
                     //   case "I":
                     //      grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value = "I";
                     //      break;
                     //}

                     //if (grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value != null)
                     //{
                     //   String _movimiento = grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value.ToString();
                     //   if (_movimiento == "E") { _movimiento = "C"; }
                     //   ObservableCollection<Entities.ServiciosDocumentos> _serviciosDocumento = Presenter.Client.GetAllServiciosDocumentosByServCodigo(_itemServicio.SERV_Codigo).ToObservableCollection();//.Where(doc => doc.SEDO_Seleccionar == 1)
                     //   ObservableCollection<Entities.Tipos> _tiposTDO = (from tdo in Presenter.ListTiposTDO
                     //                                                     join doc in _serviciosDocumento on tdo.TIPO_CodTipo equals doc.TIPO_CodTDO
                     //                                                     where doc.SEDO_Tipo == _movimiento
                     //                                                     select tdo).ToObservableCollection();

                     //   if (_tiposTDO.Count > 0)
                     //   {
                     //      grdItemsServiciosChangeControl.Rows[rowIndex].Cells["TIPO_TabTDO"].Value = _tiposTDO[0].TIPO_CodTabla;
                     //      grdItemsServiciosChangeControl.Rows[rowIndex].Cells["TIPO_CodTDO"].Value = _tiposTDO[0].TIPO_CodTipo;
                     //      grdItemsServiciosChangeControl.Rows[rowIndex].Cells["TIPO_DescTDO"].Value = _tiposTDO[0].TIPO_Desc1;
                     //   }
                     //}


                     switch (_itemServicio.SERV_TipoMov)
                     {
                        case "A":
                           grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value = null;
                           break;
                        case "C":
                           grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value = "E";
                           break;
                        case "I":
                           grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value = "I";
                           if (txaENTC_CodCliente.Value != null)
                           {
                              grdItemsServiciosChangeControl.Rows[rowIndex].Cells["TIPE_Codigo"].Value = Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Cliente);
                              grdItemsServiciosChangeControl.Rows[rowIndex].Cells["ENTC_Codigo"].Value = txaENTC_CodCliente.Value.ENTC_Codigo;
                              grdItemsServiciosChangeControl.Rows[rowIndex].Cells["ENTC_NomCom"].Value = txaENTC_CodCliente.Value.ENTC_NomCompleto;
                           }
                           break;
                     }

                     if (_itemServicio.SERV_AfeIgv.HasValue)
                     {
                        //if (grdItemsServiciosChangeControl.Rows[rowIndex].Cells["ENTC_Domiciliado"].Value != DBNull.Value)
                        //{
                        //   if ((Boolean)grdItemsServiciosChangeControl.Rows[rowIndex].Cells["ENTC_Domiciliado"].Value)
                        //   { grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = false; }
                        //   else { grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = _itemServicio.SERV_AfeIgv.Value; }
                        //}
                        //else
                        grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = _itemServicio.SERV_AfeIgv.Value;
                        grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeIgvServicio"].Value = _itemServicio.SERV_AfeIgv.Value;
                     }
                     if (_itemServicio.SERV_AfeDet.HasValue)
                     { grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeDet"].Value = _itemServicio.SERV_AfeDet.Value; }

                     //grdItemsServicio.Rows[rowIndex].Cells["SCOT_Exonerado"].Value = _itemServicio.SERV_Ex;
                     grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SCOT_PreSugerido"].Value = _itemServicio.SERV_Valor;
                     grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SCOT_PrecioUni"].Value = _itemServicio.SERV_Valor;
                     grdItemsServiciosChangeControl.Rows[rowIndex].Cells["TIPO_TabMnd"].Value = _itemServicio.TIPO_TabMND;
                     grdItemsServiciosChangeControl.Rows[rowIndex].Cells["TIPO_CodMnd"].Value = _itemServicio.TIPO_CodMND;
                     grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CONS_TabBas"].Value = _itemServicio.CONS_TabBAS;
                     grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CONS_CodBas"].Value = _itemServicio.CONS_CodBAS;

                     Decimal _SCOT_Cantidad = (Decimal)1.00;
                     Nullable<Decimal> _DCOT_Peso = (Decimal)0.00;
                     Nullable<Decimal> _DCOT_Volumen = (Decimal)0.00;

                     switch (_itemServicio.CONS_CodBAS)
                     {
                        case Delfin.Controls.variables.CONSBASFIJO:
                           //_SCOT_Cantidad = (Decimal)1.00;
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
                     grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SCOT_Cantidad"].Value = _SCOT_Cantidad;


                     ObservableCollection<Entities.ServiciosDocumentos> _serviciosDocumento = Presenter.Client.GetAllServiciosDocumentosByServCodigo(_itemServicio.SERV_Codigo).ToObservableCollection();//.Where(doc => doc.SEDO_Seleccionar == 1)

                     String _movimiento = (grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value != null ? grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CCOT_IngresoGasto"].Value.ToString() : null);
                     if (!String.IsNullOrEmpty(_movimiento))
                     {
                        SetTipoDocumentoServicio(IsChangeControl, rowIndex);

                        //if (_movimiento == "E") { _movimiento = "C"; }
                        //ObservableCollection<Entities.Tipos> _tiposTDO = (from tdo in Presenter.ListTiposTDO
                        //                                                  join doc in _serviciosDocumento on tdo.TIPO_CodTipo equals doc.TIPO_CodTDO
                        //                                                  where doc.SEDO_Tipo == _movimiento
                        //                                                  select tdo).ToObservableCollection();

                        //grdItemsServiciosChangeControl.Rows[rowIndex].Cells["TIPO_TabTDO"].Value = _tiposTDO[0].TIPO_CodTabla;
                        //grdItemsServiciosChangeControl.Rows[rowIndex].Cells["TIPO_CodTDO"].Value = _tiposTDO[0].TIPO_CodTipo;
                        //grdItemsServiciosChangeControl.Rows[rowIndex].Cells["TIPO_DescTDO"].Value = _tiposTDO[0].TIPO_Desc1;
                     }
                  }
               }
            }
         }
         catch (Exception)
         {
         }
      }
      private void SetTipoDocumentoServicio(Boolean IsChangeControl, Int32 RowIndex)
      {
         try
         {
            Int32 _SERV_Codigo;

            if (!IsChangeControl)
            {
               if (grdItemsServicio.Rows[RowIndex].Cells["SERV_Codigo"].Value != null && Int32.TryParse(grdItemsServicio.Rows[RowIndex].Cells["SERV_Codigo"].Value.ToString(), out _SERV_Codigo))
               {
                  Entities.Servicio _servicio = Presenter.Client.GetOneServicio(_SERV_Codigo);
                  ObservableCollection<Entities.ServiciosDocumentos> _serviciosDocumento = Presenter.Client.GetAllServiciosDocumentosByServCodigo(_SERV_Codigo).ToObservableCollection();//.Where(doc => doc.SEDO_Seleccionar == 1)

                  String _movimiento = (grdItemsServicio.Rows[RowIndex].Cells["CCOT_IngresoGasto"].Value != null ? grdItemsServicio.Rows[RowIndex].Cells["CCOT_IngresoGasto"].Value.ToString() : null);
                  if (!String.IsNullOrEmpty(_movimiento))
                  {
                     if (_movimiento == "E") { _movimiento = "C"; }

                     if (_movimiento == "I" && txaENTC_CodCliente.Value != null && grdItemsServicio.Rows[RowIndex].Cells["ENTC_Codigo"].Value == null)
                     {
                        grdItemsServicio.Rows[RowIndex].Cells["TIPE_Codigo"].Value = Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Cliente);
                        grdItemsServicio.Rows[RowIndex].Cells["ENTC_Codigo"].Value = txaENTC_CodCliente.Value.ENTC_Codigo;
                        grdItemsServicio.Rows[RowIndex].Cells["ENTC_NomCom"].Value = txaENTC_CodCliente.Value.ENTC_NomCompleto;
                        grdItemsServicio.Rows[RowIndex].Cells["ENTC_Domiciliado"].Value = txaENTC_CodCliente.Value.ENTC_Domiciliado;
                     }

                     ObservableCollection<Entities.Tipos> _tiposTDO = (from tdo in Presenter.ListTiposTDO
                                                                       join doc in _serviciosDocumento on tdo.TIPO_CodTipo equals doc.TIPO_CodTDO
                                                                       where doc.SEDO_Tipo == _movimiento
                                                                       orderby doc.SEDO_Item
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
            else
            {
               if (grdItemsServiciosChangeControl.Rows[RowIndex].Cells["SERV_Codigo"].Value != null && Int32.TryParse(grdItemsServiciosChangeControl.Rows[RowIndex].Cells["SERV_Codigo"].Value.ToString(), out _SERV_Codigo))
               {
                  Entities.Servicio _servicio = Presenter.Client.GetOneServicio(_SERV_Codigo);
                  ObservableCollection<Entities.ServiciosDocumentos> _serviciosDocumento = Presenter.Client.GetAllServiciosDocumentosByServCodigo(_SERV_Codigo).ToObservableCollection();//.Where(doc => doc.SEDO_Seleccionar == 1)

                  String _movimiento = (grdItemsServiciosChangeControl.Rows[RowIndex].Cells["CCOT_IngresoGasto"].Value != null ? grdItemsServiciosChangeControl.Rows[RowIndex].Cells["CCOT_IngresoGasto"].Value.ToString() : null);
                  if (!String.IsNullOrEmpty(_movimiento))
                  {
                     if (_movimiento == "E") { _movimiento = "C"; }

                     if (_movimiento == "I" && txaENTC_CodCliente.Value != null && grdItemsServiciosChangeControl.Rows[RowIndex].Cells["ENTC_Codigo"].Value == null)
                     {
                        grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPE_Codigo"].Value = Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Cliente);
                        grdItemsServiciosChangeControl.Rows[RowIndex].Cells["ENTC_Codigo"].Value = txaENTC_CodCliente.Value.ENTC_Codigo;
                        grdItemsServiciosChangeControl.Rows[RowIndex].Cells["ENTC_NomCom"].Value = txaENTC_CodCliente.Value.ENTC_NomCompleto;
                     }

                     ObservableCollection<Entities.Tipos> _tiposTDO = (from tdo in Presenter.ListTiposTDO
                                                                       join doc in _serviciosDocumento on tdo.TIPO_CodTipo equals doc.TIPO_CodTDO
                                                                       where doc.SEDO_Tipo == _movimiento
                                                                       orderby doc.SEDO_Item
                                                                       select tdo).ToObservableCollection();

                     if ((_movimiento == "I" && _servicio.SERV_CuenIngreso.StartsWith("70")) || (_movimiento == "C" && _servicio.SERV_CuenCosto.StartsWith("70")))
                     {
                        Boolean _tieneRUC = false;

                        Int16 _TIPE_Codigo = -1;
                        Int32 _ENTC_Codigo = -1;
                        if (grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPE_Codigo"].Value != null && Int16.TryParse(grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPE_Codigo"].Value.ToString(), out _TIPE_Codigo))
                        {
                           if (grdItemsServiciosChangeControl.Rows[RowIndex].Cells["ENTC_Codigo"].Value != null && Int32.TryParse(grdItemsServiciosChangeControl.Rows[RowIndex].Cells["ENTC_Codigo"].Value.ToString(), out _ENTC_Codigo))
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
                           grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = _tipoTDO.TIPO_CodTabla;
                           grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = _tipoTDO.TIPO_CodTipo;
                           grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = _tipoTDO.TIPO_Desc1;
                        }
                        else
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Configuración de Servicios", String.Format("Debe ingresar al mantenimiento de Servicios editar el servicio {0} y configurar el documento {1} para el tipo de movimiento {2}.", _servicio.SERV_Nombre_SPA, _documentodesc, _movimientodesc)); }

                     }
                     else
                     {
                        if (_tiposTDO.Count > 0)
                        {
                           grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = _tiposTDO[0].TIPO_CodTabla;
                           grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = _tiposTDO[0].TIPO_CodTipo;
                           grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = _tiposTDO[0].TIPO_Desc1;
                        }
                     }
                  }
               }
            }
         }
         catch (Exception)
         { }
      }
      private void SeleccionarProveedor(Boolean IsChangeControl, Int32 rowIndex)
      {
         try
         {

            Nullable<Int32> _ENTC_CodTransportista = null;
            if (txaENTC_CodTransportista.Value != null)
            { _ENTC_CodTransportista = txaENTC_CodTransportista.Value.ENTC_Codigo; }

            Nullable<Int32> _ENTC_CodAgente = null;
            if (txaENTC_CodAgente.Value != null)
            { _ENTC_CodAgente = txaENTC_CodAgente.Value.ENTC_Codigo; }

            Nullable<Int32> _ENTC_CodShipper = null;
            if (txaENTC_CodShipperNieto.Value != null)
            { _ENTC_CodShipper = txaENTC_CodShipperNieto.Value.ENTC_Codigo; }

            Nullable<Int32> _ENTC_CodConsignee = null;
            if (txaENTC_CodConsigneeNieto.Value != null)
            { _ENTC_CodConsignee = txaENTC_CodConsigneeNieto.Value.ENTC_Codigo; }

            COM007PView _seleccionar = new COM007PView(Presenter.ContainerService, txaENTC_CodCliente.Value != null ? txaENTC_CodCliente.Value.ENTC_Codigo : -1, _ENTC_CodTransportista, _ENTC_CodAgente, _ENTC_CodShipper, _ENTC_CodConsignee);

            if (!IsChangeControl)
            {
               if (_seleccionar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                  if (_seleccionar.Proveedor != null)
                  {
                     grdItemsServicio.Rows[rowIndex].Cells["TIPE_Codigo"].Value = _seleccionar.TipoEntidad;
                     grdItemsServicio.Rows[rowIndex].Cells["ENTC_Codigo"].Value = _seleccionar.Proveedor.ENTC_Codigo;
                     grdItemsServicio.Rows[rowIndex].Cells["ENTC_NomCom"].Value = _seleccionar.Proveedor.ENTC_NomCompleto;
                     grdItemsServicio.Rows[rowIndex].Cells["ENTC_Domiciliado"].Value = _seleccionar.Proveedor.ENTC_Domiciliado;

                     SetTipoDocumentoServicio(IsChangeControl, rowIndex);

                     //// Asignar el valor de Afecto = Falso si es una entidad de No Domicialiado
                     //if (_seleccionar.Proveedor.ENTC_Domiciliado)
                     //{ grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = false; }
                  }
                  else
                  {
                     grdItemsServicio.Rows[rowIndex].Cells["TIPE_Codigo"].Value = null;
                     grdItemsServicio.Rows[rowIndex].Cells["ENTC_Codigo"].Value = null;
                     grdItemsServicio.Rows[rowIndex].Cells["ENTC_NomCom"].Value = null;
                     grdItemsServicio.Rows[rowIndex].Cells["ENTC_Domiciliado"].Value = null;

                     //// Restaurar el valor del Afecto IGV
                     //if (grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeIgvServicio"].Value != DBNull.Value)
                     //{ grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeIgvServicio"].Value; }
                     //else { grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = false; }
                  }
               }
               else
               {
                  grdItemsServicio.Rows[rowIndex].Cells["TIPE_Codigo"].Value = null;
                  grdItemsServicio.Rows[rowIndex].Cells["ENTC_Codigo"].Value = null;
                  grdItemsServicio.Rows[rowIndex].Cells["ENTC_NomCom"].Value = null;
                  grdItemsServicio.Rows[rowIndex].Cells["ENTC_Domiciliado"].Value = null;

                  //// Restaurar el valor del Afecto IGV
                  //if (grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeIgvServicio"].Value != DBNull.Value)
                  //{ grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeIgvServicio"].Value; }
                  //else { grdItemsServicio.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = false; }
               }
            }
            else
            {
               if (_seleccionar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                  if (_seleccionar.Proveedor != null)
                  {
                     grdItemsServiciosChangeControl.Rows[rowIndex].Cells["TIPE_Codigo"].Value = _seleccionar.TipoEntidad;
                     grdItemsServiciosChangeControl.Rows[rowIndex].Cells["ENTC_Codigo"].Value = _seleccionar.Proveedor.ENTC_Codigo;
                     grdItemsServiciosChangeControl.Rows[rowIndex].Cells["ENTC_NomCom"].Value = _seleccionar.Proveedor.ENTC_NomCompleto;
                     grdItemsServiciosChangeControl.Rows[rowIndex].Cells["ENTC_Domiciliado"].Value = _seleccionar.Proveedor.ENTC_Domiciliado;

                     SetTipoDocumentoServicio(IsChangeControl, rowIndex);

                     //// Asignar el valor de Afecto = Falso si es una entidad de No Domicialiado
                     //if (_seleccionar.Proveedor.ENTC_Domiciliado)
                     //{ grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = false; }
                  }
                  else
                  {
                     grdItemsServiciosChangeControl.Rows[rowIndex].Cells["TIPE_Codigo"].Value = null;
                     grdItemsServiciosChangeControl.Rows[rowIndex].Cells["ENTC_Codigo"].Value = null;
                     grdItemsServiciosChangeControl.Rows[rowIndex].Cells["ENTC_NomCom"].Value = null;
                     grdItemsServiciosChangeControl.Rows[rowIndex].Cells["ENTC_Domiciliado"].Value = null;

                     //// Restaurar el valor del Afecto IGV
                     //if (grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeIgvServicio"].Value != DBNull.Value)
                     //{ grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeIgvServicio"].Value; }
                     //else { grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = false; }

                  }
               }
               else
               {
                  grdItemsServiciosChangeControl.Rows[rowIndex].Cells["TIPE_Codigo"].Value = null;
                  grdItemsServiciosChangeControl.Rows[rowIndex].Cells["ENTC_Codigo"].Value = null;
                  grdItemsServiciosChangeControl.Rows[rowIndex].Cells["ENTC_NomCom"].Value = null;
                  grdItemsServiciosChangeControl.Rows[rowIndex].Cells["ENTC_Domiciliado"].Value = null;

                  //// Restaurar el valor del Afecto IGV
                  //if (grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeIgvServicio"].Value != DBNull.Value)
                  //{ grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeIgvServicio"].Value; }
                  //else { grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_AfeIgv"].Value = false; }
               }
            }
         }
         catch (Exception)
         {
         }
      }
      private void SeleccionarTipoDocumento(Boolean IsChangeControl, Int32 RowIndex)
      {
         try
         {
            Int32 _SERV_Codigo;

            if (!IsChangeControl)
            {
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
                                                                       orderby doc.SEDO_Item
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
            else
            {
               if (grdItemsServiciosChangeControl.Rows[RowIndex].Cells["SERV_Codigo"].Value != null && Int32.TryParse(grdItemsServiciosChangeControl.Rows[RowIndex].Cells["SERV_Codigo"].Value.ToString(), out _SERV_Codigo))
               {
                  ObservableCollection<Entities.ServiciosDocumentos> _serviciosDocumento = Presenter.Client.GetAllServiciosDocumentosByServCodigo(_SERV_Codigo).ToObservableCollection();//.Where(doc => doc.SEDO_Seleccionar == 1)

                  String _movimiento = (grdItemsServiciosChangeControl.Rows[RowIndex].Cells["CCOT_IngresoGasto"].Value != null ? grdItemsServiciosChangeControl.Rows[RowIndex].Cells["CCOT_IngresoGasto"].Value.ToString() : null);
                  if (String.IsNullOrEmpty(_movimiento))
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Ayuda Tipos de Documento", "Debe seleccionar el si es Ingreso o Egreso."); }
                  else
                  {
                     if (_movimiento == "E") { _movimiento = "C"; }
                     ObservableCollection<Entities.Tipos> _tiposTDO = (from tdo in Presenter.ListTiposTDO
                                                                       join doc in _serviciosDocumento on tdo.TIPO_CodTipo equals doc.TIPO_CodTDO
                                                                       where doc.SEDO_Tipo == _movimiento
                                                                       orderby doc.SEDO_Item
                                                                       select tdo).ToObservableCollection();

                     if (_tiposTDO.Count == 0)
                     {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Ayuda Tipos de Documento", "No se encontraron Tipos de Documentos Configurados para el servicio seleccionado.");
                     }
                     else if (_tiposTDO.Count == 1)
                     {
                        grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = _tiposTDO[0].TIPO_CodTabla;
                        grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = _tiposTDO[0].TIPO_CodTipo;
                        grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = _tiposTDO[0].TIPO_Desc1;
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
                                 grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = _tipoTDO.TIPO_CodTabla;
                                 grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = _tipoTDO.TIPO_CodTipo;
                                 grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = _tipoTDO.TIPO_Desc1;
                              }
                              else
                              {
                                 grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = null;
                                 grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = null;
                                 grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = null;
                              }
                           }
                           else
                           {
                              grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = null;
                              grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = null;
                              grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = null;
                           }
                        }
                        else
                        {
                           grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = null;
                           grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = null;
                           grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = null;
                        }

                     }
                  }
               }
            }
         }
         catch (Exception)
         {
         }
      }
      private void ActualizarTipoDocumento(Boolean IsChangeControl, Int32 RowIndex)
      {
         try
         {
            Int32 _SERV_Codigo;

            if (!IsChangeControl)
            {
               if (grdItemsServicio.Rows[RowIndex].Cells["SERV_Codigo"].Value != null && Int32.TryParse(grdItemsServicio.Rows[RowIndex].Cells["SERV_Codigo"].Value.ToString(), out _SERV_Codigo) && grdItemsServicio.Rows[RowIndex].Cells["CCOT_IngresoGasto"].Value != null)
               {
                  String _movimiento = (grdItemsServicio.Rows[RowIndex].Cells["CCOT_IngresoGasto"].Value != null ? grdItemsServicio.Rows[RowIndex].Cells["CCOT_IngresoGasto"].Value.ToString() : null);
                  if (String.IsNullOrEmpty(_movimiento))
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Actualizar Tipos de Documento", "Debe seleccionar el si es Ingreso o Egreso."); }
                  else
                  {
                     OPE001DView _view = new OPE001DView(Presenter, (grdItemsServicio.Rows[RowIndex].DataBoundItem as Entities.Det_Cotizacion_OV_Servicio));
                     if (_view.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                     {
                        grdItemsServicio.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = _view.ItemDetalle.TIPO_TabTDO;
                        grdItemsServicio.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = _view.ItemDetalle.TIPO_CodTDO;
                        grdItemsServicio.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = _view.ItemDetalle.TIPO_DescTDO;
                        grdItemsServicio.Rows[RowIndex].Cells["SCOT_SerieTDO"].Value = _view.ItemDetalle.SCOT_SerieTDO;
                        grdItemsServicio.Rows[RowIndex].Cells["SCOT_NumeroTDO"].Value = _view.ItemDetalle.SCOT_NumeroTDO;
                        grdItemsServicio.Rows[RowIndex].Cells["SCOT_FechaEmision"].Value = _view.ItemDetalle.SCOT_FechaEmision;
                     }
                  }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Actualizar Tipos de Documento", "Debe seleccionar el servicio."); }
            }
            else
            {
               if (grdItemsServiciosChangeControl.Rows[RowIndex].Cells["SERV_Codigo"].Value != null && Int32.TryParse(grdItemsServiciosChangeControl.Rows[RowIndex].Cells["SERV_Codigo"].Value.ToString(), out _SERV_Codigo))
               {
                  ObservableCollection<Entities.ServiciosDocumentos> _serviciosDocumento = Presenter.Client.GetAllServiciosDocumentosByServCodigo(_SERV_Codigo).ToObservableCollection();//.Where(doc => doc.SEDO_Seleccionar == 1)

                  String _movimiento = (grdItemsServiciosChangeControl.Rows[RowIndex].Cells["CCOT_IngresoGasto"].Value != null ? grdItemsServiciosChangeControl.Rows[RowIndex].Cells["CCOT_IngresoGasto"].Value.ToString() : null);
                  if (String.IsNullOrEmpty(_movimiento))
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Ayuda Tipos de Documento", "Debe seleccionar el si es Ingreso o Egreso."); }
                  else
                  {
                     OPE001DView _view = new OPE001DView(Presenter, (grdItemsServiciosChangeControl.Rows[RowIndex].DataBoundItem as Entities.Det_Cotizacion_OV_Servicio));
                     if (_view.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                     {
                        grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_TabTDO"].Value = _view.ItemDetalle.TIPO_TabTDO;
                        grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_CodTDO"].Value = _view.ItemDetalle.TIPO_CodTDO;
                        grdItemsServiciosChangeControl.Rows[RowIndex].Cells["TIPO_DescTDO"].Value = _view.ItemDetalle.TIPO_DescTDO;
                        grdItemsServiciosChangeControl.Rows[RowIndex].Cells["SCOT_SerieTDO"].Value = _view.ItemDetalle.SCOT_SerieTDO;
                        grdItemsServiciosChangeControl.Rows[RowIndex].Cells["SCOT_NumeroTDO"].Value = _view.ItemDetalle.SCOT_NumeroTDO;
                        grdItemsServiciosChangeControl.Rows[RowIndex].Cells["SCOT_FechaEmision"].Value = _view.ItemDetalle.SCOT_FechaEmision;
                     }
                  }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Actualizar Tipos de Documento", "Debe seleccionar el servicio."); }
            }
         }
         catch (Exception)
         {
         }
      }
      private void CalcularCantidadBase(Boolean IsChangeControl, Int32 rowIndex)
      {
         try
         {
            if (!IsChangeControl)
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
                           {
                              _SCOT_Cantidad = _DCOT_Peso.Value;
                           }
                           else
                           {
                              _SCOT_Cantidad = _DCOT_Volumen.Value;
                           }
                        }
                        break;
                     default:
                        break;
                  }

                  grdItemsServicio.Rows[rowIndex].Cells["SCOT_Cantidad"].Value = _SCOT_Cantidad;
               }
            }
            else
            {
               if (grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CONS_CodBAS"].Value != null && !String.IsNullOrEmpty(grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CONS_CodBAS"].Value.ToString()))
               {
                  String _CONS_CodBAS = grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CONS_CodBAS"].Value.ToString();
                  Decimal _SCOT_Cantidad = (Decimal)0.00;
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
                           {
                              _SCOT_Cantidad = _DCOT_Peso.Value;
                           }
                           else
                           {
                              _SCOT_Cantidad = _DCOT_Volumen.Value;
                           }
                        }
                        break;
                     default:
                        break;
                  }

                  grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SCOT_Cantidad"].Value = _SCOT_Cantidad;
               }
            }
         }
         catch (Exception)
         {
         }
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

            foreach (var item in grdItemsServiciosChangeControl.Rows)
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

      #region [ Metodos Servicios ]
      private void FormatGridServicios()
      {
         try
         {

            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsServicio.Columns.Clear();
            this.grdItemsServicio.AllowAddNewRow = false;

            //Descripción del servicio
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

            //Ingreso Gasto
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
            this.grdItemsServicio.Columns.Add("ENTC_NomCom", "Entidad", "ENTC_NomCom");
            //Base (Valor, Contenedor, Peso/Volumen)
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

            //Afecto a IGV (no editable) - Servicio Original
            Telerik.WinControls.UI.GridViewCheckBoxColumn _afectoIGVServicio = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _afectoIGVServicio.Name = "SERV_AfeIgvServicio";
            _afectoIGVServicio.HeaderText = "Afecto IGV Servicio";
            _afectoIGVServicio.FieldName = "SERV_AfeIgvServicio";
            _afectoIGVServicio.IsVisible = false;
            this.grdItemsServicio.Columns.Add(_afectoIGVServicio);

            //Entidad No Domiciliado (no editable)
            Telerik.WinControls.UI.GridViewCheckBoxColumn _ENTC_Domiciliado = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _ENTC_Domiciliado.Name = "ENTC_Domiciliado";
            _ENTC_Domiciliado.HeaderText = "No Domiciliado";
            _ENTC_Domiciliado.FieldName = "ENTC_Domiciliado";
            _ENTC_Domiciliado.IsVisible = false;
            this.grdItemsServicio.Columns.Add(_ENTC_Domiciliado);
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

            Telerik.WinControls.UI.GridViewCommandColumn _actualizarDocumentoTDO = new Telerik.WinControls.UI.GridViewCommandColumn();
            _actualizarDocumentoTDO.Name = "ActualizarDocumento";
            _actualizarDocumentoTDO.HeaderText = "Actualizar Documento";
            _actualizarDocumentoTDO.DefaultText = "Actualizar Documento";
            _actualizarDocumentoTDO.UseDefaultText = true;
            this.grdItemsServicio.Columns.Add(_actualizarDocumentoTDO);

            this.grdItemsServicio.Columns.Add("TIPO_TabMnd", "Tipo Tabla Moneda", "TIPO_TabMnd");
            this.grdItemsServicio.Columns.Add("CONS_TabBas", "Tipo Tabla Documento", "CONS_TabBas");

            //Edicion del Servicio
            //this.grdItemsServicio.Columns.Add("SCOT_Editable", "Editable", "SCOT_Editable");
            Telerik.WinControls.UI.GridViewCheckBoxColumn _editable = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _editable.Name = "SCOT_Editable";
            _editable.HeaderText = "Editable";
            _editable.FieldName = "SCOT_Editable";
            _editable.ReadOnly = true;
            this.grdItemsServicio.Columns.Add(_editable);

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
            this.grdItemsServicio.Columns["CONS_CodBas"].ReadOnly = false;
            this.grdItemsServicio.Columns["SCOT_Cantidad"].ReadOnly = false;
            this.grdItemsServicio.Columns["SCOT_Origen"].ReadOnly = false;
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

            this.grdItemsServicio.Columns["TIPO_TabMnd"].IsVisible = false;
            this.grdItemsServicio.Columns["CONS_TabBas"].IsVisible = false;

            this.grdItemsServicio.Columns["SCOT_Editable"].ReadOnly = true;
            this.grdItemsServicio.Columns["SCOT_Editable"].IsVisible = false;


            this.grdItemsServicio.Columns["TIPE_Desc"].TextAlignment = ContentAlignment.MiddleLeft;
            //this.grdItemsServicio.Columns["SERV_Codigo"].TextAlignment = ContentAlignment.MiddleLeft;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex);
         }
      }
      private void AddServicio()
      {
         try
         {
            Entities.Det_Cotizacion_OV_Servicio _servicio = new Entities.Det_Cotizacion_OV_Servicio();
            Int32 _SCOT_Item = 0;
            if (((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicio.DataSource).Count > 0)
            {
               _SCOT_Item = ((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicio.DataSource).Max(scot => scot.SCOT_Item);
            }
            _servicio.SCOT_Item = _SCOT_Item + 1;
            _servicio.SCOT_ChageControl = false;
            _servicio.SCOT_Origen = "D";
            _servicio.SCOT_Editable = true;
            _servicio.AUDI_UsrCrea = Presenter.Session.UserName;
            _servicio.AUDI_FecCrea = Presenter.Session.Fecha;
            _servicio.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            BSItemsServicio.Add(_servicio);
            BSItemsServicio.ResetBindings(true);
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un servicio", ex);
         }
      }
      private void DelServicio()
      {
         try
         {
            if (BSItemsServicio.Current != null && BSItemsServicio.Current is Entities.Det_Cotizacion_OV_Servicio)
            {
               Entities.Det_Cotizacion_OV_Servicio _servicio = (Entities.Det_Cotizacion_OV_Servicio)BSItemsServicio.Current;

               if (_servicio.SCOT_Eliminable)
               {
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
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "El registro no puede ser eliminado porque ya fue procesado por Finanzas."); }
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar un servicio", ex);
         }
      }

      private void grdItemsServicio_CellBeginEdit(object sender, Telerik.WinControls.UI.GridViewCellCancelEventArgs e)
      {
         try
         {
            //if (e.Column.Name == "TIPO_CodTDO")
            //{  
            //   Int32 _SERV_Codigo;
            //   if (grdItemsServicio.Rows[e.RowIndex].Cells["SERV_Codigo"].Value != null && Int32.TryParse(grdItemsServicio.Rows[e.RowIndex].Cells["SERV_Codigo"].Value.ToString(), out _SERV_Codigo))
            //   {
            //      ObservableCollection<Entities.ServiciosDocumentos> _serviciosDocumento = Presenter.Client.GetAllServiciosDocumentosByServCodigo(_SERV_Codigo).Where(doc => doc.SEDO_Seleccionar == 1).ToObservableCollection();

            //      ObservableCollection<Entities.Tipos> _tiposTDO = (from tdo in Presenter.ListTiposTDO
            //                                                        join doc in _serviciosDocumento on tdo.TIPO_CodTipo equals doc.TIPO_CodTDO
            //                                                        select tdo).ToObservableCollection();

            //      ((Telerik.WinControls.UI.GridViewComboBoxColumn)this.grdItemsServicio.CurrentColumn).DataSource = _tiposTDO;


            //      this.grdItemsServicio.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnInfo.AllowSort = false;

            //      ((Telerik.WinControls.UI.GridViewComboBoxColumn)(this.grdItemsServicio.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnInfo)).DataSource = _tiposTDO;
            //   }
            //   //else
            //   //{ ((Telerik.WinControls.UI.GridViewLookUpColumn)this.grdItemsServicio.CurrentColumn).DataSource = null; }
            //}
            if (e.Row is Telerik.WinControls.UI.GridViewDataRowInfo)
            {
               if (e.Row.Cells["SCOT_Editable"].Value != null)
               {
                  Boolean _Editable = Convert.ToBoolean(e.Row.Cells["SCOT_Editable"].Value);
                  if (_Editable)
                  { e.Cancel = false; }
                  else
                  { e.Cancel = true; }
               }

            }
         }
         catch (Exception) { }
         finally { if (e.Cancel) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "El registro no puede ser editado debido a que ya fue procesado por Finanzans."); } }
      }
      private void grdItemsServicio_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
      {
         if (e.Column.Name == "SERV_Codigo")
         { SetDatosServicios(false, e.RowIndex); }
         else if (e.Column.Name == "CCOT_IngresoGasto")
         { SetTipoDocumentoServicio(false, e.RowIndex); }
         else if (e.Column.Name == "ENTC_Codigo")
         { SetTipoDocumentoServicio(false, e.RowIndex); }
         else if (e.Column.Name == "CONS_CodBas")
         { CalcularCantidadBase(false, e.RowIndex); }
      }
      private void grdItemsServicio_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            Boolean _editar = true;
            if ((sender as Telerik.WinControls.UI.GridCommandCellElement).RowInfo.Cells["SCOT_Editable"].Value != null)
            { _editar = Convert.ToBoolean((sender as Telerik.WinControls.UI.GridCommandCellElement).RowInfo.Cells["SCOT_Editable"].Value); }

            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               //switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).Tag.ToString())
               switch ((sender as Telerik.WinControls.UI.GridCommandCellElement).ColumnInfo.Name)
               {
                  case "Entidad":
                     if (_editar)
                     {
                        SeleccionarProveedor(false, ((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex);
                     }
                     break;
                  case "TipoDocumento":
                     if (_editar)
                     {
                        SeleccionarTipoDocumento(false, ((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex);
                     }
                     break;
                  case "ActualizarDocumento":
                     ActualizarTipoDocumento(false, ((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex);
                     break;
               }
            }



            //if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            //{
            //   switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
            //   {
            //      case "Proveedor":
            //         SeleccionarProveedor(false, ((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex);
            //         break;
            //      case "Tipo Documento":
            //         SeleccionarTipoDocumento(false, ((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex);
            //         break;
            //   }
            //}
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el botón para seleccionar el proveedor.", ex);
         }
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
      {
         AddServicio();
      }
      private void btnDelServicio_Click(object sender, EventArgs e)
      {
         DelServicio();
      }
      #endregion

      #region [ Metodos Servicios ChangeControl]
      private void FormatGridServiciosChangeControl()
      {
         try
         {

            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsServiciosChangeControl.Columns.Clear();
            this.grdItemsServiciosChangeControl.AllowAddNewRow = false;

            //Descripción del servicio
            Telerik.WinControls.UI.GridViewCheckBoxColumn _exonerado = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _exonerado.Name = "SCOT_Exonerado";
            _exonerado.HeaderText = "Exonerado";
            _exonerado.FieldName = "SCOT_Exonerado";
            _exonerado.ReadOnly = true;
            this.grdItemsServiciosChangeControl.Columns.Add(_exonerado);

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
            this.grdItemsServiciosChangeControl.Columns.Add(_servicio);
            //Ingreso Gasto
            Telerik.WinControls.UI.GridViewComboBoxColumn _ingresoegreso = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _ingresoegreso.Name = "CCOT_IngresoGasto";
            _ingresoegreso.HeaderText = "Ingreso/Egreso";
            _ingresoegreso.FieldName = "CCOT_IngresoGasto";
            _ingresoegreso.ValueMember = "StrCodigo";
            _ingresoegreso.DisplayMember = "StrDesc";
            _ingresoegreso.DataSource = Presenter.ListIngresoEgreso;
            _ingresoegreso.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            this.grdItemsServiciosChangeControl.Columns.Add(_ingresoegreso);


            //Proveedor del servicio
            Telerik.WinControls.UI.GridViewCommandColumn _proveedor = new Telerik.WinControls.UI.GridViewCommandColumn();
            _proveedor.Name = "Entidad";
            _proveedor.HeaderText = "Entidad";
            _proveedor.DefaultText = "Entidad";
            _proveedor.UseDefaultText = true;
            this.grdItemsServiciosChangeControl.Columns.Add(_proveedor);
            this.grdItemsServiciosChangeControl.Columns.Add("TIPE_Codigo", "Tipo Entidad", "TIPE_Codigo");
            this.grdItemsServiciosChangeControl.Columns.Add("ENTC_Codigo", "Código Proveedor", "ENTC_Codigo");

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
            this.grdItemsServiciosChangeControl.Columns.Add(_tipoentidad);
            this.grdItemsServiciosChangeControl.Columns.Add("ENTC_NomCom", "Entidad", "ENTC_NomCom");
            //Base (Valor, Contenedor, Peso/Volumen)
            Telerik.WinControls.UI.GridViewComboBoxColumn _base = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _base.Name = "CONS_CodBas";
            _base.HeaderText = "Base";
            _base.FieldName = "CONS_CodBas";
            _base.ValueMember = "CONS_CodTipo";
            _base.DisplayMember = "CONS_Desc_SPA";
            _base.DataSource = Presenter.ListConstantesBAS;
            //_base.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            this.grdItemsServiciosChangeControl.Columns.Add(_base);
            //Cantidad
            Telerik.WinControls.UI.GridViewDecimalColumn _cantidad = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _cantidad.Name = "SCOT_Cantidad";
            _cantidad.HeaderText = "Cantidad";
            _cantidad.FieldName = "SCOT_Cantidad";
            _cantidad.DecimalPlaces = 2;
            _cantidad.Minimum = (Decimal)0.00;
            this.grdItemsServiciosChangeControl.Columns.Add(_cantidad);
            //Origen del servicio (0 = Local, 1 = Destino)
            Telerik.WinControls.UI.GridViewComboBoxColumn _origen = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _origen.Name = "SCOT_Origen";
            _origen.HeaderText = "Origen";
            _origen.FieldName = "SCOT_Origen";
            _origen.ValueMember = "StrCodigo";
            _origen.DisplayMember = "StrDesc";
            _origen.DataSource = Presenter.ListOrigen;
            //_origen.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            this.grdItemsServiciosChangeControl.Columns.Add(_origen);
            //Moneda
            Telerik.WinControls.UI.GridViewComboBoxColumn _moneda = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _moneda.Name = "TIPO_CodMnd";
            _moneda.HeaderText = "Moneda";
            _moneda.FieldName = "TIPO_CodMnd";
            _moneda.ValueMember = "TIPO_CodTipo";
            _moneda.DisplayMember = "TIPO_Desc1";
            _moneda.DataSource = Presenter.ListTiposMND;
            //_moneda.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            this.grdItemsServiciosChangeControl.Columns.Add(_moneda);
            //Precio Unitario
            Telerik.WinControls.UI.GridViewDecimalColumn _precio = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _precio.Name = "SCOT_PrecioUni";
            _precio.HeaderText = "Precio Unitario";
            _precio.FieldName = "SCOT_PrecioUni";
            _precio.DecimalPlaces = 2;
            _precio.Minimum = (Decimal)0.00;
            this.grdItemsServiciosChangeControl.Columns.Add(_precio);
            //Importe de Venta
            Telerik.WinControls.UI.GridViewDecimalColumn _importeingreso = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _importeingreso.Name = "SCOT_Importe_Ingreso";
            _importeingreso.HeaderText = "Importe Ingreso";
            _importeingreso.FieldName = "SCOT_Importe_Ingreso";
            _importeingreso.DecimalPlaces = 2;
            _importeingreso.Minimum = (Decimal)0.00;
            this.grdItemsServiciosChangeControl.Columns.Add(_importeingreso);
            //Importe de Venta
            Telerik.WinControls.UI.GridViewDecimalColumn _importeegreso = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _importeegreso.Name = "SCOT_Importe_Egreso";
            _importeegreso.HeaderText = "Importe Egreso";
            _importeegreso.FieldName = "SCOT_Importe_Egreso";
            _importeegreso.DecimalPlaces = 2;
            _importeegreso.Minimum = (Decimal)0.00;
            this.grdItemsServiciosChangeControl.Columns.Add(_importeegreso);
            //Afecto a IGV (no editable)
            Telerik.WinControls.UI.GridViewCheckBoxColumn _afectoIGV = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _afectoIGV.Name = "SERV_AfeIgv";
            _afectoIGV.HeaderText = "Afecto IGV";
            _afectoIGV.FieldName = "SERV_AfeIgv";
            this.grdItemsServiciosChangeControl.Columns.Add(_afectoIGV);
            //Afecto a Detracción (no editable)
            Telerik.WinControls.UI.GridViewCheckBoxColumn _afectoDetraccion = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _afectoDetraccion.Name = "SERV_AfeDet";
            _afectoDetraccion.HeaderText = "Afecto Detracción";
            _afectoDetraccion.FieldName = "SERV_AfeDet";
            this.grdItemsServiciosChangeControl.Columns.Add(_afectoDetraccion);

            //Afecto a IGV (no editable) - Servicio Original
            Telerik.WinControls.UI.GridViewCheckBoxColumn _afectoIGVServicio = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _afectoIGVServicio.Name = "SERV_AfeIgvServicio";
            _afectoIGVServicio.HeaderText = "Afecto IGV Servicio";
            _afectoIGVServicio.FieldName = "SERV_AfeIgvServicio";
            _afectoIGVServicio.IsVisible = false;
            this.grdItemsServiciosChangeControl.Columns.Add(_afectoIGVServicio);

            //Entidad No Domiciliado (no editable)
            Telerik.WinControls.UI.GridViewCheckBoxColumn _ENTC_Domiciliado = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _ENTC_Domiciliado.Name = "ENTC_Domiciliado";
            _ENTC_Domiciliado.HeaderText = "No Domiciliado";
            _ENTC_Domiciliado.FieldName = "ENTC_Domiciliado";
            _ENTC_Domiciliado.IsVisible = false;
            this.grdItemsServiciosChangeControl.Columns.Add(_ENTC_Domiciliado);
            //Importe de Venta
            Telerik.WinControls.UI.GridViewDecimalColumn _preciosugerido = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _preciosugerido.Name = "SCOT_PreSugerido";
            _preciosugerido.HeaderText = "Precio Sugerido";
            _preciosugerido.FieldName = "SCOT_PreSugerido";
            _preciosugerido.DecimalPlaces = 2;
            _preciosugerido.Minimum = (Decimal)0.00;
            this.grdItemsServiciosChangeControl.Columns.Add(_preciosugerido);

            Telerik.WinControls.UI.GridViewCommandColumn _tipoDocumentoTDO = new Telerik.WinControls.UI.GridViewCommandColumn();
            _tipoDocumentoTDO.Name = "TipoDocumento";
            _tipoDocumentoTDO.HeaderText = "Tipo Documento";
            _tipoDocumentoTDO.DefaultText = "Tipo Documento";
            _tipoDocumentoTDO.UseDefaultText = true;
            this.grdItemsServiciosChangeControl.Columns.Add(_tipoDocumentoTDO);
            this.grdItemsServiciosChangeControl.Columns.Add("TIPO_DescTDO", "Tipo Documento", "TIPO_DescTDO");
            this.grdItemsServiciosChangeControl.Columns.Add("TIPO_TabTDO", "Tipo Tabla Documento", "TIPO_TabTDO");
            this.grdItemsServiciosChangeControl.Columns.Add("TIPO_CodTDO", "Tipo Codigo Documento", "TIPO_CodTDO");
            this.grdItemsServiciosChangeControl.Columns.Add("SCOT_SerieTDO", "Serie Documento", "SCOT_SerieTDO");
            this.grdItemsServiciosChangeControl.Columns.Add("SCOT_NumeroTDO", "Nro. Documento", "SCOT_NumeroTDO");

            Telerik.WinControls.UI.GridViewDateTimeColumn _fechaEmision = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            _fechaEmision.Name = "SCOT_FechaEmision";
            _fechaEmision.HeaderText = "Fec. Emisión";
            _fechaEmision.FieldName = "SCOT_FechaEmision";
            _fechaEmision.FormatString = "{0:dd/MM/yyyy}";
            _fechaEmision.Format = DateTimePickerFormat.Short;
            this.grdItemsServiciosChangeControl.Columns.Add(_fechaEmision);

            Telerik.WinControls.UI.GridViewCommandColumn _actualizarDocumentoTDO = new Telerik.WinControls.UI.GridViewCommandColumn();
            _actualizarDocumentoTDO.Name = "ActualizarDocumento";
            _actualizarDocumentoTDO.HeaderText = "Actualizar Documento";
            _actualizarDocumentoTDO.DefaultText = "Actualizar Documento";
            _actualizarDocumentoTDO.UseDefaultText = true;
            this.grdItemsServiciosChangeControl.Columns.Add(_actualizarDocumentoTDO);

            Telerik.WinControls.UI.GridViewDateTimeColumn _fechaOperacion = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            _fechaOperacion.Name = "SCOT_FechaOperacion";
            _fechaOperacion.HeaderText = "Fecha Operacion";
            _fechaOperacion.FieldName = "SCOT_FechaOperacion";
            _fechaOperacion.FormatString = "{0:d}";
            this.grdItemsServiciosChangeControl.Columns.Add(_fechaOperacion);

            //Editable 
            Telerik.WinControls.UI.GridViewCheckBoxColumn _editable = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _editable.Name = "SCOT_Editable";
            _editable.HeaderText = "Editable";
            _editable.FieldName = "SCOT_Editable";
            _editable.ReadOnly = true;
            this.grdItemsServiciosChangeControl.Columns.Add(_editable);

            grdItemsServiciosChangeControl.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsServiciosChangeControl);
            //grdServiciosChangeControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            this.grdItemsServiciosChangeControl.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.grdItemsServiciosChangeControl.MultiSelect = false;

            this.grdItemsServiciosChangeControl.ShowFilteringRow = false;
            this.grdItemsServiciosChangeControl.EnableFiltering = false;
            this.grdItemsServiciosChangeControl.MasterTemplate.EnableFiltering = false;
            this.grdItemsServiciosChangeControl.EnableGrouping = false;
            this.grdItemsServiciosChangeControl.MasterTemplate.EnableGrouping = false;
            this.grdItemsServiciosChangeControl.EnableSorting = false;
            this.grdItemsServiciosChangeControl.MasterTemplate.EnableCustomSorting = false;

            this.grdItemsServiciosChangeControl.ReadOnly = false;
            this.grdItemsServiciosChangeControl.AllowEditRow = true;

            this.grdItemsServiciosChangeControl.Columns["SCOT_PreSugerido"].IsVisible = false;
            this.grdItemsServiciosChangeControl.Columns["TIPE_Codigo"].IsVisible = false;
            this.grdItemsServiciosChangeControl.Columns["ENTC_Codigo"].IsVisible = false;

            this.grdItemsServiciosChangeControl.Columns["SCOT_Exonerado"].ReadOnly = true;
            this.grdItemsServiciosChangeControl.Columns["CCOT_IngresoGasto"].ReadOnly = false;
            this.grdItemsServiciosChangeControl.Columns["SERV_Codigo"].ReadOnly = false;
            this.grdItemsServiciosChangeControl.Columns["TIPE_Desc"].ReadOnly = true;
            this.grdItemsServiciosChangeControl.Columns["ENTC_NomCom"].ReadOnly = true;
            this.grdItemsServiciosChangeControl.Columns["CONS_CodBas"].ReadOnly = false;
            this.grdItemsServiciosChangeControl.Columns["SCOT_Cantidad"].ReadOnly = false;
            this.grdItemsServiciosChangeControl.Columns["SCOT_Origen"].ReadOnly = false;
            this.grdItemsServiciosChangeControl.Columns["TIPO_CodMnd"].ReadOnly = false;
            this.grdItemsServiciosChangeControl.Columns["SCOT_PrecioUni"].ReadOnly = false;
            this.grdItemsServiciosChangeControl.Columns["SCOT_Importe_Ingreso"].ReadOnly = true;
            this.grdItemsServiciosChangeControl.Columns["SCOT_Importe_Egreso"].ReadOnly = true;
            this.grdItemsServiciosChangeControl.Columns["SERV_AfeIgv"].ReadOnly = true;
            this.grdItemsServiciosChangeControl.Columns["SERV_AfeDet"].ReadOnly = true;

            this.grdItemsServiciosChangeControl.Columns["SCOT_Exonerado"].Width = 60;
            this.grdItemsServiciosChangeControl.Columns["CCOT_IngresoGasto"].Width = 80;
            this.grdItemsServiciosChangeControl.Columns["SERV_Codigo"].Width = 200;
            this.grdItemsServiciosChangeControl.Columns["ENTC_NomCom"].Width = 150;
            this.grdItemsServiciosChangeControl.Columns["CONS_CodBas"].Width = 80;
            this.grdItemsServiciosChangeControl.Columns["SCOT_Cantidad"].Width = 80;
            this.grdItemsServiciosChangeControl.Columns["SCOT_Origen"].Width = 80;
            this.grdItemsServiciosChangeControl.Columns["TIPO_CodMnd"].Width = 80;
            this.grdItemsServiciosChangeControl.Columns["SCOT_PrecioUni"].Width = 100;
            this.grdItemsServiciosChangeControl.Columns["SCOT_Importe_Ingreso"].Width = 100;
            this.grdItemsServiciosChangeControl.Columns["SCOT_Importe_Egreso"].Width = 100;
            this.grdItemsServiciosChangeControl.Columns["SERV_AfeIgv"].Width = 80;
            this.grdItemsServiciosChangeControl.Columns["SERV_AfeDet"].Width = 80;

            this.grdItemsServiciosChangeControl.Columns["TIPO_DescTDO"].ReadOnly = true;
            this.grdItemsServiciosChangeControl.Columns["TIPO_DescTDO"].Width = 120;
            this.grdItemsServiciosChangeControl.Columns["TIPO_TabTDO"].IsVisible = false;
            this.grdItemsServiciosChangeControl.Columns["TIPO_CodTDO"].IsVisible = false;

            this.grdItemsServiciosChangeControl.Columns["SCOT_SerieTDO"].Width = 80;
            this.grdItemsServiciosChangeControl.Columns["SCOT_NumeroTDO"].Width = 80;
            this.grdItemsServiciosChangeControl.Columns["SCOT_FechaEmision"].Width = 100;

            this.grdItemsServiciosChangeControl.Columns["SCOT_Origen"].IsVisible = false;
            this.grdItemsServiciosChangeControl.Columns["SCOT_FechaOperacion"].ReadOnly = false;
            this.grdItemsServiciosChangeControl.Columns["SCOT_FechaOperacion"].Width = 100;

            this.grdItemsServiciosChangeControl.Columns["SCOT_Editable"].ReadOnly = true;
            this.grdItemsServiciosChangeControl.Columns["SCOT_Editable"].IsVisible = false;
            //this.grdServiciosChangeControl.Columns["SERV_Codigo"].TextAlignment = ContentAlignment.MiddleLeft;

            this.grdItemsServiciosChangeControl.Columns["TIPE_Desc"].TextAlignment = ContentAlignment.MiddleLeft;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex);
         }
      }
      private void AddServicioChangeControl()
      {
         try
         {
            Entities.Det_Cotizacion_OV_Servicio _servicio = new Entities.Det_Cotizacion_OV_Servicio();
            Int32 _SCOT_Item = 0;
            if (((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicioChangeControl.DataSource).Count > 0)
            {
               _SCOT_Item = ((ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>)BSItemsServicioChangeControl.DataSource).Max(scot => scot.SCOT_Item);
            }
            _servicio.SCOT_Item = _SCOT_Item + 1;
            _servicio.SCOT_ChageControl = true;
            _servicio.SCOT_Origen = "D";
            _servicio.SCOT_FechaOperacion = Presenter.Session.Fecha;
            _servicio.AUDI_UsrCrea = Presenter.Session.UserName;
            _servicio.AUDI_FecCrea = Presenter.Session.Fecha;
            _servicio.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            BSItemsServicioChangeControl.Add(_servicio);
            BSItemsServicioChangeControl.ResetBindings(true);
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un servicio", ex);
         }
      }
      private void DelServicioChangeControl()
      {
         try
         {
            if (BSItemsServicioChangeControl.Current != null && BSItemsServicioChangeControl.Current is Entities.Det_Cotizacion_OV_Servicio)
            {
               Entities.Det_Cotizacion_OV_Servicio _servicio = (Entities.Det_Cotizacion_OV_Servicio)BSItemsServicioChangeControl.Current;
               Entities.Det_Cotizacion_OV_Servicio _servicioBD = Presenter.Client.GetOneDet_Cotizacion_OV_Servicio(_servicio.CCOT_Tipo, _servicio.CCOT_Numero, _servicio.SCOT_Item);
               if (_servicioBD != null)
               { _servicio = _servicioBD; }

               if (_servicio.SCOT_Eliminable)
               {
                  if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Esta seguro que desea eliminar el servicio?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
                  {
                     if (_servicio.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
                     {
                        _servicio.AUDI_UsrMod = Presenter.Session.UserName;
                        _servicio.AUDI_FecMod = Presenter.Session.Fecha;
                        _servicio.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                        Presenter.Item.ItemsServicioChangeControlDeleted.Add(_servicio);
                     }
                     BSItemsServicioChangeControl.RemoveCurrent();
                     BSItemsServicioChangeControl.ResetBindings(true);
                  }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "El registro no puede ser eliminado porque ya fue procesado por Finanzas."); }
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar un servicio", ex);
         }
      }
      private void EnviarFinanzasServicioChangeControl()
      {
         try
         {

            if (BSItemsServicioChangeControl.Current != null && BSItemsServicioChangeControl.Current is Entities.Det_Cotizacion_OV_Servicio)
            {
               Entities.Det_Cotizacion_OV_Servicio _servicio = (Entities.Det_Cotizacion_OV_Servicio)BSItemsServicioChangeControl.Current;
               if (_servicio.SCOT_Editable)
               {
                  if (Presenter.EnviarFinanzas(ref _servicio))
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Presenter.Title, "El registro fue enviado satisfactoriamente a Finanzas.");
                     _servicio.SCOT_Editable = false;
                     _servicio.SCOT_EnviarFinanzas = false;
                     _servicio.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged;
                  }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "El registro no puede ser enviado nuevamente a Finanzas."); }
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar un servicio", ex);
         }
      }

      private void grdItemsServiciosChangeControl_CellBeginEdit(object sender, Telerik.WinControls.UI.GridViewCellCancelEventArgs e)
      {
         try
         {
            Boolean _Editable = true;
            if (e.Row is Telerik.WinControls.UI.GridViewDataRowInfo)
            {
               if (e.Row.Cells["SCOT_Editable"].Value != null)
               {
                  _Editable = Convert.ToBoolean(e.Row.Cells["SCOT_Editable"].Value);
                  if (_Editable)
                  { e.Cancel = false; }
                  else
                  { e.Cancel = true; }
               }

            }
            if (((grdItemsServiciosChangeControl.Rows[e.RowIndex].DataBoundItem as Entities.Det_Cotizacion_OV_Servicio).CHAN_Cerrado) || !(_Editable))
            { e.Cancel = true; }
         }
         catch (Exception) { }
         finally { if (e.Cancel) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "El registro no puede ser editado debido a que ya fue procesado por Finanzans."); } }
      }
      private void grdServiciosChangeControl_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
      {
         try
         {
            if (e.Column.Name == "SERV_Codigo")
            { SetDatosServicios(true, e.RowIndex); }
            else if (e.Column.Name == "CCOT_IngresoGasto")
            { SetTipoDocumentoServicio(true, e.RowIndex); }
            else if (e.Column.Name == "ENTC_Codigo")
            { SetTipoDocumentoServicio(true, e.RowIndex); }
            else if (e.Column.Name == "CONS_CodBas")
            { CalcularCantidadBase(true, e.RowIndex); }
         }
         catch (Exception) { }
      }
      private void grdServiciosChangeControl_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            Boolean _editar = true;
            if ((sender as Telerik.WinControls.UI.GridCommandCellElement).RowInfo.Cells["SCOT_Editable"].Value != null)
            { _editar = Convert.ToBoolean((sender as Telerik.WinControls.UI.GridCommandCellElement).RowInfo.Cells["SCOT_Editable"].Value); }

            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               //switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).Tag.ToString())
               switch ((sender as Telerik.WinControls.UI.GridCommandCellElement).ColumnInfo.Name)
               {
                  case "Entidad":
                     if (_editar)
                     {
                        if (!(grdItemsServiciosChangeControl.Rows[((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex].DataBoundItem as Entities.Det_Cotizacion_OV_Servicio).CHAN_Cerrado)
                        { SeleccionarProveedor(true, ((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex); }
                        else
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "El mes se encuentra cerrado para este registro."); }
                     }
                     break;
                  case "TipoDocumento":
                     if (_editar)
                     {
                        if (!(grdItemsServiciosChangeControl.Rows[((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex].DataBoundItem as Entities.Det_Cotizacion_OV_Servicio).CHAN_Cerrado)
                        { SeleccionarTipoDocumento(true, ((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex); }
                        else
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "El mes se encuentra cerrado para este registro."); }
                     }
                     break;
                  case "ActualizarDocumento":
                     ActualizarTipoDocumento(true, ((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex);
                     break;
               }
            }


            //if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            //{
            //   switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
            //   {
            //      case "Proveedor":
            //         SeleccionarProveedor(true, ((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex);
            //         break;
            //      case "Tipo Documento":
            //         SeleccionarTipoDocumento(true, ((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex);
            //         break;
            //   }
            //}
         }
         catch (Exception ex) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el botón para seleccionar el proveedor.", ex); }
      }
      private void grdItemsServiciosChangeControl_CurrentCellChanged(object sender, Telerik.WinControls.UI.CurrentCellChangedEventArgs e)
      {
         try
         {
            Int32 rowIndex = e.CurrentCell.RowInfo.Index;
            if (e.NewCell.ColumnInfo.Name == "CCOT_IngresoGasto" && grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_Codigo"] != null)
            {
               grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CCOT_IngresoGasto"].ReadOnly = true;

               Int32 _SERV_Codigo;
               if (grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_Codigo"].Value != null && Int32.TryParse(grdItemsServiciosChangeControl.Rows[rowIndex].Cells["SERV_Codigo"].Value.ToString(), out _SERV_Codigo))
               {
                  Entities.Servicio _itemServicio = Presenter.ListServicio.Where(serv => serv.SERV_Codigo == _SERV_Codigo).FirstOrDefault();
                  if (_itemServicio != null)
                  {
                     switch (_itemServicio.SERV_TipoMov)
                     {
                        case "A":
                           grdItemsServiciosChangeControl.Rows[rowIndex].Cells["CCOT_IngresoGasto"].ReadOnly = false;
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
      private void btnAddServicioChangeControl_Click(object sender, EventArgs e)
      {
         AddServicioChangeControl();
      }
      private void btnDelServicioChangeControl_Click(object sender, EventArgs e)
      {
         DelServicioChangeControl();
      }
      private void btnEnviarFinanzasChangeControl_Click(object sender, EventArgs e)
      { EnviarFinanzasServicioChangeControl(); }
      #endregion

      #endregion

      #region [ Metodos Linea Negocio ]
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
                     Boolean _validacionAgente = (Presenter.PARA_EAGENTE_SHANGHAI != null && txaENTC_CodAgente.Value.ENTC_Codigo == Presenter.PARA_EAGENTE_SHANGHAI.PARA_IntValor);
                     //Boolean _validacionPuerto = (Presenter.PARA_PAIS_MANDATO != null && txaPUER_CodOrigen.SelectedItem.TIPO_CodPais == Presenter.PARA_PAIS_MANDATO.PARA_Valor);
                     if (_validacionAgente) //&& _validacionPuerto
                     { cmbCONS_CodLNG.ConstantesSelectedValue = Delfin.Controls.variables.CONSLNG_Mandato; }
                     else
                     { cmbCONS_CodLNG.ConstantesSelectedValue = Delfin.Controls.variables.CONSLNG_OtrosTraficos; }
                  }
               }
            }
         }
         catch (Exception)
         { }
      }
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
                  if (mdtCCOT_FecEmi.NSFecha.HasValue && mdtCCOT_FecVcto.NSFecha.HasValue)
                  {
                     if (txaENTC_CodTransportista.Value != null)
                     {
                        Int32? PUER_CodigoOrigen = null, PUER_CodigoDestino = null;
                        if (txaPUER_CodOrigen.SelectedItem != null) { PUER_CodigoOrigen = txaPUER_CodOrigen.SelectedItem.PUER_Codigo; }
                        if (txaPUER_CodDestino.SelectedItem != null) { PUER_CodigoDestino = txaPUER_CodDestino.SelectedItem.PUER_Codigo; }

                        Presenter.AyudaContrato(txaENTC_CodTransportista.Value, cmbCONS_CodRGM.ConstantesSelectedItem, cmbCONS_CodVia.ConstantesSelectedItem, mdtCCOT_FecEmi.NSFecha.Value, mdtCCOT_FecVcto.NSFecha.Value, PUER_CodigoOrigen, PUER_CodigoDestino, ActualizarContrato);
                     }
                     else
                     {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un Transportista para poder buscar un Contrato.");
                     }
                  }
                  else
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar la Fecha de Emisión y Vencimiento para poder buscar un Contrato.");
                  }
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar una Vía para poder buscar un Contrato.");
               }
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un Régimen para poder buscar un Contrato.");
            }
         }
         catch (Exception)
         {
         }
      }
      public void ClearItemContrato()
      {
         try
         {
            txaCONT_Numero.Text = String.Empty;
            txtCONT_Descrip.Text = String.Empty;
            txaPUER_CodOrigen.SelectedValue = null;
            txaPUER_CodDestino.SelectedValue = null;
            cmbTIPO_CodMND.TiposSelectedValue = null;

            txaCONT_Numero.AyudaButton.Visible = true;
            txaCONT_Numero.Width = 194;
            btnCambiarContrato.Visible = false;
         }
         catch (Exception)
         {
         }
      }
      public void SetItemContrato(Boolean ActualizarContrato)
      {
         try
         {
            if (Presenter.Item.ItemContrato != null)
            {
               txaCONT_Numero.SetValue(Presenter.Item.ItemContrato, Presenter.Item.ItemContrato.CONT_Numero);
               if (Presenter.Item.ItemContrato.CONT_FecIni.HasValue && Presenter.Item.ItemContrato.CONT_FecFin.HasValue)
               {
                  txtCONT_Descrip.Text = Presenter.Item.ItemContrato.CONT_Descrip + " - Fecha Inicio: " + Presenter.Item.ItemContrato.CONT_FecIni.Value.ToShortDateString() + " Fecha Fin: " + Presenter.Item.ItemContrato.CONT_FecFin.Value.ToShortDateString();
               }
               else
               {
                  txtCONT_Descrip.Text = Presenter.Item.ItemContrato.CONT_Descrip;
               }

               txaPUER_CodOrigen.SelectedValue = Presenter.Item.ItemContrato.PUER_CodigoOrigen;
               txaPUER_CodDestino.SelectedValue = Presenter.Item.ItemContrato.PUER_CodigoDestino;
               cmbTIPO_CodMND.TiposSelectedValue = Presenter.Item.ItemContrato.TIPO_CodMND;

               txaCONT_Numero.AyudaButton.Visible = false;
               txaCONT_Numero.Width = 165;
               btnCambiarContrato.Visible = true;

               if (ActualizarContrato)
               {
                  Boolean _cambiarPV = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Desea actualizar el Precio de Venta?") == System.Windows.Forms.DialogResult.OK;
                  for (int i = 0; i < grdItemsFlete.Rows.Count; i++)
                  {
                     ConsultarTarifario(i, true, _cambiarPV);
                  }
               }
            }
            else
            {
               txaCONT_Numero.ClearValue();
               txaCONT_Numero.AyudaButton.Visible = true;
               txaCONT_Numero.Width = 194;
               btnCambiarContrato.Visible = false;
            }
         }
         catch (Exception)
         {
         }
      }

      private void CONT_Numero_AyudaClick(object sender, EventArgs e)
      {
         AyudaContrato(false);
      }
      private void CONT_Numero_AyudaClean(object sender, EventArgs e)
      {
         ClearItemContrato();
      }
      private void btnCambiarContrato_Click(object sender, EventArgs e)
      {
         AyudaContrato(true);
      }
      #endregion

      #region [ Metodos Viaje ]
      public void ClearItemViaje()
      {
         try
         {
            txaNVIA_Codigo.ClearValue();
            txtNVIA_NroViaje.Text = String.Empty;
            txtNAVE_Nombre.Text = String.Empty;
            //mdtNVIA_FecCierreDire_IMPO_TermEmba_EXPO.NSFecha = null;
            //txtENTC_NomTransportista.Text = String.Empty;
            //cmbTIPO_CodTRF.TiposSelectedValue = null;
            mdtNVIA_FecETA.NSFecha = null;
            txtENTC_NomTermPort.Text = String.Empty;
            txtENTC_NomAgentePortuario.Text = String.Empty;
            txtNVIA_NroManifiesto.Text = String.Empty;
            mdtNVIA_FecCutOff.NSFecha = null;
            txtNVIA_NroManifiestoDescon.Text = string.Empty;
            mdtNVIA_FecCierre.NSFecha = null;
            mdtNVIA_FecLlega_IMPO.NSFecha = null;
            mdtNVIA_FecDescarga_IMPO.NSFecha = null;
            mdtNVIA_FecZarpe_EXPO.NSFecha = null;
            mdtNVIA_FecRecogerDocs.NSFecha = null;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ClearItem, ex);
         }
      }
      public void SetItemViaje()
      {
         try
         {
            if (Presenter.Item.ItemNaveViaje != null)
            {
               //txaNVIA_NroViaje.SetValue(Presenter.Item.ItemNaveViaje, Presenter.Item.ItemNaveViaje.NVIA_NroViaje);
               //txaNAVE_Codigo.SetValue(Presenter.Item.ItemNave,Presenter.Item.ItemNave.NAVE_Nombre);
               //mdtNVIA_FecETA.NSFecha = Presenter.Item.ItemNaveViaje.NVIA_FecETA_IMPO_ETD_EXPO;
               //mdtNVIA_FecETDMaster.NSFecha = Presenter.Item.ItemNaveViaje.NVIA_FecETA_IMPO_ETD_EXPO;
               //mdtNVIA_FecCutOff.NSFecha = Presenter.Item.ItemDetNaveViaje.NVIA_FecCutOff;



               txaNVIA_Codigo.SetValue(Presenter.Item.ItemNaveViaje, Presenter.Item.ItemNaveViaje.NVIA_Codigo.ToString());
               txtNVIA_NroViaje.Text = Presenter.Item.ItemNaveViaje.NVIA_NroViaje;
               txtNAVE_Nombre.Text = Presenter.Item.ItemNaveViaje.NAVE_Nombre;
               //if (Presenter.Item.ItemNave != null)
               //{
               //txtNAVE_Nombre.Text = Presenter.Item.ItemNave.NAVE_Nombre;
               //txaNAVE_Codigo.SetValue(Presenter.Item.ItemNave, Presenter.Item.ItemNave.NAVE_Nombre); 
               //}

               //mdtNVIA_FecCierreDire_IMPO_TermEmba_EXPO.NSFecha = Presenter.Item.ItemNaveViaje.NVIA_FecCierreDire_IMPO_TermEmba_EXPO;
               //txtENTC_NomTransportista.Text = Presenter.Item.ItemNaveViaje.ENTC_NomTransportista;
               //cmbTIPO_CodTRF.TiposSelectedValue = Presenter.Item.ItemNaveViaje.TIPO_CodTRF;
               mdtNVIA_FecETA.NSFecha = Presenter.Item.ItemNaveViaje.NVIA_FecETA_IMPO_ETD_EXPO;
               txtENTC_NomTermPort.Text = Presenter.Item.ItemNaveViaje.ENTC_NomTermin;
               if (Presenter.Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
               { txtENTC_NomAgentePortuario.Text = Presenter.Item.ItemNaveViaje.ENTC_NomAgent1; }
               else
               { txtENTC_NomAgentePortuario.Text = Presenter.Item.ItemNaveViaje.ENTC_NomAgente; }

               txtNVIA_NroManifiesto.Text = Presenter.Item.ItemNaveViaje.NVIA_NroManifiesto;
               mdtNVIA_FecCutOff.NSFecha = Presenter.Item.ItemNaveViaje.NVIA_FecCutOff_EXPO;
               txtNVIA_NroManifiestoDescon.Text = Presenter.Item.ItemNaveViaje.NVIA_NorManifiestoDescon;
               mdtNVIA_FecCierre.NSFecha = Presenter.Item.ItemNaveViaje.NVIA_FecCierreDire_IMPO_TermEmba_EXPO;
               mdtNVIA_FecLlega_IMPO.NSFecha = Presenter.Item.ItemNaveViaje.NVIA_FecLlega_IMPO_Zarpe_EXPO;
               mdtNVIA_FecDescarga_IMPO.NSFecha = Presenter.Item.ItemNaveViaje.NVIA_FecDescarga_IMPO;
               mdtNVIA_FecZarpe_EXPO.NSFecha = Presenter.Item.ItemNaveViaje.NVIA_FecLlega_IMPO_Zarpe_EXPO;
               mdtNVIA_FecRecogerDocs.NSFecha = Presenter.Item.ItemNaveViaje.ENTC_FecRecogerDocs;
               mdtNVIA_FecTermEmba_EXPO.NSFecha = Presenter.Item.ItemNaveViaje.NVIA_FecCierreDire_IMPO_TermEmba_EXPO;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.GetItem, ex);
         }
      }
      public void SetNaveViajeRegimen()
      {
         try
         {
            if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
            {
               if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
               {
                  tableDatosViaje.RowStyles[0].Height = 27;
                  lblDOOV_Feeder_IMPO.Visible = true;
                  txtDOOV_Feeder_IMPO.Visible = true;
                  lblDOOV_FecETDFeeder_IMPO.Visible = true;
                  mdtDOOV_FecETDFeeder_IMPO.Visible = true;

                  lblNVIA_FecCutOff.Visible = false;
                  mdtNVIA_FecCutOff.Visible = false;
                  lblNVIA_NroManifiestoDescon.Visible = true;
                  txtNVIA_NroManifiestoDescon.Visible = true;

                  tableDatosViaje.RowStyles[4].Height = 27;
                  lblNVIA_FecCierre.Visible = true;
                  mdtNVIA_FecCierre.Visible = true;
                  lblNVIA_FecLlega_IMPO.Visible = true;
                  mdtNVIA_FecLlega_IMPO.Visible = true;
                  lblNVIA_FecDescarga_IMPO.Visible = true;
                  mdtNVIA_FecDescarga_IMPO.Visible = true;

                  tableDatosViaje.RowStyles[5].Height = 0;
                  lblNVIA_FecZarpe_EXPO.Visible = false;
                  mdtNVIA_FecZarpe_EXPO.Visible = false;
                  lblNVIA_FecRecogerDocs.Visible = false;
                  mdtNVIA_FecRecogerDocs.Visible = false;
                  lblNVIA_FecTermEmba_EXPO.Visible = false;
                  mdtNVIA_FecTermEmba_EXPO.Visible = false;


                  lblCCOT_EnviaAvisoLlegada.Text = "Aviso de LLegada";

                  lblDDOV_FecEmbarque.Text = "Fecha de Embarque";
                  lblNVIA_FecETA.Text = "Fecha ETA:";
               }
               else if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Exportacion)
               {
                  tableDatosViaje.RowStyles[0].Height = 0;
                  lblDOOV_Feeder_IMPO.Visible = false;
                  txtDOOV_Feeder_IMPO.Visible = false;
                  lblDOOV_FecETDFeeder_IMPO.Visible = false;
                  mdtDOOV_FecETDFeeder_IMPO.Visible = false;

                  lblNVIA_FecCutOff.Visible = true;
                  mdtNVIA_FecCutOff.Visible = true;
                  lblNVIA_NroManifiestoDescon.Visible = false;
                  txtNVIA_NroManifiestoDescon.Visible = false;

                  tableDatosViaje.RowStyles[4].Height = 0;
                  lblNVIA_FecCierre.Visible = false;
                  mdtNVIA_FecCierre.Visible = false;
                  lblNVIA_FecLlega_IMPO.Visible = false;
                  mdtNVIA_FecLlega_IMPO.Visible = false;
                  lblNVIA_FecDescarga_IMPO.Visible = false;
                  mdtNVIA_FecDescarga_IMPO.Visible = false;

                  tableDatosViaje.RowStyles[5].Height = 27;
                  lblNVIA_FecZarpe_EXPO.Visible = true;
                  mdtNVIA_FecZarpe_EXPO.Visible = true;
                  lblNVIA_FecRecogerDocs.Visible = true;
                  mdtNVIA_FecRecogerDocs.Visible = true;
                  lblNVIA_FecTermEmba_EXPO.Visible = true;
                  mdtNVIA_FecTermEmba_EXPO.Visible = true;

                  lblCCOT_EnviaAvisoLlegada.Text = "Aviso de Zarpe";

                  lblDDOV_FecEmbarque.Text = "Fecha Zarpe:";
                  lblNVIA_FecETA.Text = "Fecha ETD:";
               }
               else
               {
                  tableDatosViaje.RowStyles[0].Height = 0;
                  lblDOOV_Feeder_IMPO.Visible = false;
                  txtDOOV_Feeder_IMPO.Visible = false;
                  lblDOOV_FecETDFeeder_IMPO.Visible = false;
                  mdtDOOV_FecETDFeeder_IMPO.Visible = false;

                  lblNVIA_FecCutOff.Visible = false;
                  mdtNVIA_FecCutOff.Visible = false;
                  lblNVIA_NroManifiestoDescon.Visible = false;
                  txtNVIA_NroManifiestoDescon.Visible = false;

                  tableDatosViaje.RowStyles[4].Height = 0;
                  lblNVIA_FecCierre.Visible = false;
                  mdtNVIA_FecCierre.Visible = false;
                  lblNVIA_FecLlega_IMPO.Visible = false;
                  mdtNVIA_FecLlega_IMPO.Visible = false;
                  lblNVIA_FecDescarga_IMPO.Visible = false;
                  mdtNVIA_FecDescarga_IMPO.Visible = false;

                  tableDatosViaje.RowStyles[5].Height = 0;
                  lblNVIA_FecZarpe_EXPO.Visible = false;
                  mdtNVIA_FecZarpe_EXPO.Visible = false;
                  lblNVIA_FecRecogerDocs.Visible = false;
                  mdtNVIA_FecRecogerDocs.Visible = false;
                  lblNVIA_FecTermEmba_EXPO.Visible = false;
                  mdtNVIA_FecTermEmba_EXPO.Visible = false;

                  lblCCOT_EnviaAvisoLlegada.Text = "Aviso de LLegada";

                  lblDDOV_FecEmbarque.Text = "Fecha de Embarque";
                  lblNVIA_FecETA.Text = "Fecha ETA/ETD:";
               }
            }
            else
            {
               tableDatosViaje.RowStyles[0].Height = 0;
               lblDOOV_Feeder_IMPO.Visible = false;
               txtDOOV_Feeder_IMPO.Visible = false;
               lblDOOV_FecETDFeeder_IMPO.Visible = false;
               mdtDOOV_FecETDFeeder_IMPO.Visible = false;

               lblNVIA_FecCutOff.Visible = false;
               mdtNVIA_FecCutOff.Visible = false;
               lblNVIA_NroManifiestoDescon.Visible = false;
               txtNVIA_NroManifiestoDescon.Visible = false;

               tableDatosViaje.RowStyles[4].Height = 0;
               lblNVIA_FecCierre.Visible = false;
               mdtNVIA_FecCierre.Visible = false;
               lblNVIA_FecLlega_IMPO.Visible = false;
               mdtNVIA_FecLlega_IMPO.Visible = false;
               lblNVIA_FecDescarga_IMPO.Visible = false;
               mdtNVIA_FecDescarga_IMPO.Visible = false;

               tableDatosViaje.RowStyles[5].Height = 0;
               lblNVIA_FecZarpe_EXPO.Visible = false;
               mdtNVIA_FecZarpe_EXPO.Visible = false;
               lblNVIA_FecRecogerDocs.Visible = false;
               mdtNVIA_FecRecogerDocs.Visible = false;
               lblNVIA_FecTermEmba_EXPO.Visible = false;
               mdtNVIA_FecTermEmba_EXPO.Visible = false;

               lblCCOT_EnviaAvisoLlegada.Text = "Aviso de LLegada";

               lblDDOV_FecEmbarque.Text = "Fecha de Embarque";
               lblNVIA_FecETA.Text = "Fecha ETA/ETD:";
            }
         }
         catch (Exception)
         {
            throw;
         }
      }

      private void txaNVIA_Codigo_AyudaClick(object sender, EventArgs e)
      {
         Presenter.AyudaNaveViaje(null);
      }
      private void txaNVIA_Codigo_AyudaClean(object sender, EventArgs e)
      {
         ClearItemViaje();
      }
      private void btnAddNaveViaje_Click(object sender, EventArgs e)
      {
         Presenter.EdicionNaveViaje(true);
      }
      private void btnEditarNaveViaje_Click(object sender, EventArgs e)
      {
         Presenter.EdicionNaveViaje(false);
      }
      #endregion

      #region [ Metodos Novedades ]
      public void ClearItemNovedad()
      {
         try
         {
            txtOVNO_Descrip.Text = String.Empty;
            cmbCONS_CodNOT.ConstantesSelectedValue = null;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ClearItem, ex);
         }
      }
      public void GetItemNovedad()
      {
         try
         {
            Presenter.ItemNovedad.OVNO_Descrip = txtOVNO_Descrip.Text;
            if (cmbCONS_CodNOT.ConstantesSelectedItem != null)
            {
               Presenter.ItemNovedad.CONS_TabNot = cmbCONS_CodNOT.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.ItemNovedad.CONS_CodNot = cmbCONS_CodNOT.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.ItemNovedad.CONS_TabNot = null;
               Presenter.ItemNovedad.CONS_CodNot = null;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.GetItem, ex);
         }
      }
      public void ShowNovedades()
      {
         try
         {
            BSItemsNovedades.DataSource = Presenter.Item.ItemsNovedad;
            BSItemsNovedades.ResetBindings(true);
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al mostrar las novedades.", ex);
         }
      }
      public void ShowValidationItemNovedad()
      {
         try
         {
            //Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Det_Cotizacion_OV_Novedad>.Validate(Presenter.ItemNovedad, pageNovedades, errorProviderDet_Cotizacion_OV_Novedad);
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex);
         }
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
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar la novedad.", ex);
         }
      }
      private void EnviarNovedades()
      {
         try
         {
            Presenter.EnviarNovedades();
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al enviar las novedades.", ex);
         }
      }

      private void btnNuevoNovedad_Click(object sender, EventArgs e)
      {
         AgregarNovedad();
      }
      private void btnEnviarNovedad_Click(object sender, EventArgs e)
      {
         EnviarNovedades();
      }
      #endregion

      #region [ Metodos Archivos ]
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

            Telerik.WinControls.UI.GridViewCommandColumn _Descripcion = new Telerik.WinControls.UI.GridViewCommandColumn();
            _Descripcion.Name = "OVAR_DescripcionPopUp";
            _Descripcion.HeaderText = "";
            _Descripcion.DefaultText = "...";
            _Descripcion.UseDefaultText = true;
            _Descripcion.Tag = "OVAR_DescripcionPopUp";
            _Descripcion.MinWidth = 20;
            _Descripcion.Width = 20;
            this.grdItemsArchivos.Columns.Add(_Descripcion);

            grdItemsArchivos.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsArchivos);
            //grdItemsArchivos.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

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
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Archivos)", ex);
         }
      }
      private void UploadFile()
      {
         try
         {
            if (!String.IsNullOrEmpty(txoOVAR_Archivo.Text) && !String.IsNullOrEmpty(txoOVAR_Archivo.Text) && Presenter.UploadFile(txoOVAR_Archivo.FullPath))
            {
               BSItemsArchivos.DataSource = Presenter.Item.ItemsArchivo;
               BSItemsArchivos.ResetBindings(true);

               txoOVAR_Archivo.FileName = null;
               txoOVAR_Archivo.Clear();
               txoOVAR_Archivo.Text = null;
               txoOVAR_Archivo.Select();
               txoOVAR_Archivo.Focus();
            }
            else
            {
               txoOVAR_Archivo.Select();
               txoOVAR_Archivo.Focus();
            }

         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.GetItem, ex);
         }
      }

      private void DownloadFile()
      {
         try
         {
            if (BSItemsArchivos.Current != null && BSItemsArchivos.Current is Entities.Det_Cotizacion_OV_Archivo)
            {
               Presenter.DownloadFile(((Entities.Det_Cotizacion_OV_Archivo)BSItemsArchivos.Current));
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetItem, ex);
         }
      }

      private void ShowFileStream()
      {
          try
          {
              if (BSItemsArchivos.Current != null && BSItemsArchivos.Current is Entities.Det_Cotizacion_OV_Archivo)
              {
                  Presenter.ShowFileStream(((Entities.Det_Cotizacion_OV_Archivo)BSItemsArchivos.Current));
              }
          }
          catch (Exception ex)
          {
              Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetItem, ex);
          }
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
               {
                  Presenter.ItemArchivo = null;
               }
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex);
         }
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
      private Entities.Det_Cotizacion_OV_EventosTareas ItemEventoTarea = null;
      public BindingSource BSItemsEventosTareas { get; set; }

      private void FormatGridEventoTarea()
      {
         try
         {

            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsEventosTareas.Columns.Clear();
            this.grdItemsEventosTareas.AllowAddNewRow = false;

            //EVEN_Item         

            //Manual
            Telerik.WinControls.UI.GridViewCheckBoxColumn _manual = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _manual.Name = "EVEN_Manual";
            _manual.HeaderText = "Manual";
            _manual.FieldName = "EVEN_Manual";
            _manual.ReadOnly = true;
            this.grdItemsEventosTareas.Columns.Add(_manual);

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
            Telerik.WinControls.UI.GridViewTextBoxColumn _fecha = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            _fecha.Name = "EVEN_Fecha";
            _fecha.HeaderText = "Fecha";
            _fecha.FieldName = "EVEN_Fecha";
            _fecha.FormatString = "{0:dd/MM/yyyy HH:mm}";
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
            //grdItemsEventosTareas.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

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
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex);
         }
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
            cmbTIPO_CodEVE.Enabled = ItemEnabled;
            cmbCONS_CodMOD.Enabled = ItemEnabled;

            grdItemsEventosTareas.EnableAlternatingRowColor = !ItemEnabled;

            btnNuevoEventoTarea.Enabled = !EnabledGuardar;
            btnEditarEventoTarea.Enabled = (!EnabledGuardar && ItemEventoTarea != null);
            btnEliminarEventoTarea.Enabled = (!EnabledGuardar && ItemEventoTarea != null);
            btnGuardarEventoTarea.Enabled = EnabledGuardar;
            btnDeshacerEventoTarea.Enabled = EnabledGuardar;

            grdItemsEventosTareas.Enabled = !EnabledGuardar;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetInstanceView, ex);
         }
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
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex);
         }
      }
      private void ClearItemEventoTarea()
      {
         try
         {
            EVEN_Fecha.NSFecha = null;
            EVEN_Cumplida.Checked = false;
            EVEN_Usuario.Text = String.Empty;
            EVEN_Observaciones.Text = String.Empty;
            cmbTIPO_CodEVE.TiposSelectedValue = null;
            cmbCONS_CodMOD.ConstantesSelectedValue = null;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ClearItem, ex);
         }
      }
      private void GetItemEventoTarea()
      {
         try
         {
            if (ItemEventoTarea != null)
            {
               if (ItemEventoTarea.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added || ItemEventoTarea.EVEN_Item <= 0)
               {
                  if (BSItemsEventosTareas != null && BSItemsEventosTareas.DataSource != null && BSItemsEventosTareas.DataSource is ObservableCollection<Entities.Det_Cotizacion_OV_EventosTareas>)
                  { ItemEventoTarea.EVEN_Item = (BSItemsEventosTareas.DataSource as ObservableCollection<Entities.Det_Cotizacion_OV_EventosTareas>).Max(even => even.EVEN_Item); }
                  else
                  { ItemEventoTarea.EVEN_Item = 1; }
               }

               ItemEventoTarea.EVEN_Fecha = EVEN_Fecha.NSFecha;
               ItemEventoTarea.EVEN_Cumplida = EVEN_Cumplida.Checked;
               ItemEventoTarea.EVEN_Usuario = EVEN_Usuario.Text;
               ItemEventoTarea.EVEN_Observaciones = EVEN_Observaciones.Text;
               if (cmbTIPO_CodEVE.TiposSelectedItem != null)
               {
                  ItemEventoTarea.TIPO_TabEVE = cmbTIPO_CodEVE.TiposSelectedItem.TIPO_CodTabla;
                  ItemEventoTarea.TIPO_CodEVE = cmbTIPO_CodEVE.TiposSelectedItem.TIPO_CodTipo;
               }
               else
               {
                  ItemEventoTarea.TIPO_TabEVE = null;
                  ItemEventoTarea.TIPO_CodEVE = null;
               }
               if (cmbCONS_CodMOD.ConstantesSelectedItem != null)
               {
                  ItemEventoTarea.CONS_TabMOD = cmbCONS_CodMOD.ConstantesSelectedItem.CONS_CodTabla;
                  ItemEventoTarea.CONS_CodMOD = cmbCONS_CodMOD.ConstantesSelectedItem.CONS_CodTipo;
               }
               else
               {
                  ItemEventoTarea.CONS_TabMOD = null;
                  ItemEventoTarea.CONS_CodMOD = null;
               }
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.GetItem, ex);
         }
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
               cmbTIPO_CodEVE.TiposSelectedValue = ItemEventoTarea.TIPO_CodEVE;
               cmbCONS_CodMOD.ConstantesSelectedValue = ItemEventoTarea.CONS_CodMOD;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetItem, ex);
         }
      }
      private void MostrarErrorItemEventoTarea()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Det_Cotizacion_OV_EventosTareas>.Validate(ItemEventoTarea, tableEventoTarea, errorEventoTarea);
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex);
         }
      }
       
      private void ValidarEventos()
      {
         try
         {
            chkCCOT_EmitirHBL.Enabled = false;
            chkCCOT_EmitirHBL.Checked = false;

            chkCCOT_Bloqueado.Checked = false;
            chkCCOT_ConExcepcion.Checked = false;

            if (BSItemsEventosTareas != null && BSItemsEventosTareas.DataSource != null && BSItemsEventosTareas.DataSource is ObservableCollection<Entities.Det_Cotizacion_OV_EventosTareas>)
            {
               foreach (Entities.Det_Cotizacion_OV_EventosTareas _itemDet_Cotizacion_OV_EventosTareas in (BSItemsEventosTareas.DataSource as ObservableCollection<Entities.Det_Cotizacion_OV_EventosTareas>).OrderBy(even => even.EVEN_Item).ToObservableCollection())
               {
                  //if (Presenter.PARA_RELEASEHBL != null && _itemDet_Cotizacion_OV_EventosTareas.TIPO_CodEVE == Presenter.PARA_RELEASEHBL.PARA_Valor)
                   if (Presenter.PARA_RELEASEHBL != null && EmitirHBL(_itemDet_Cotizacion_OV_EventosTareas.TIPO_CodEVE))
                  { chkCCOT_EmitirHBL.Enabled = true; chkCCOT_EmitirHBL.Checked = true; }
                  else if (Presenter.PARA_BLOQUEAROV != null && _itemDet_Cotizacion_OV_EventosTareas.TIPO_CodEVE == Presenter.PARA_BLOQUEAROV.PARA_Valor)
                  { chkCCOT_Bloqueado.Checked = true; }
                  else if (Presenter.PARA_DESBLOQUEAROV != null && _itemDet_Cotizacion_OV_EventosTareas.TIPO_CodEVE == Presenter.PARA_DESBLOQUEAROV.PARA_Valor)
                  { chkCCOT_Bloqueado.Checked = false; }
                  else if (Presenter.PARA_AGREGAREXCEPCIONOV != null && _itemDet_Cotizacion_OV_EventosTareas.TIPO_CodEVE == Presenter.PARA_AGREGAREXCEPCIONOV.PARA_Valor)
                  { chkCCOT_ConExcepcion.Checked = true; }
                  else if (Presenter.PARA_QUITAREXCEPCIONOV != null && _itemDet_Cotizacion_OV_EventosTareas.TIPO_CodEVE == Presenter.PARA_QUITAREXCEPCIONOV.PARA_Valor)
                  { chkCCOT_ConExcepcion.Checked = false; }
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al validar los eventos.", ex); }
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
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex);
         }
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
               {
                  ItemEventoTarea.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
               }
               SetItemEventoTarea();
               InstanceItemEventoTarea(ItemEventoTarea.EVEN_Manual, true);
               Edicion = true;
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un elemento de la grilla");
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex);
         }
      }
      private void btnEliminarEventoTarea_Click(object sender, EventArgs e)
      {
         try
         {
            SeleccionarEventoTarea();
            if (ItemEventoTarea != null)
            {
               if (ItemEventoTarea.EVEN_Manual)
               {

                  System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
                  if (_result == System.Windows.Forms.DialogResult.Yes)
                  {
                     if (ItemEventoTarea.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
                     {
                        ItemEventoTarea.AUDI_UsrMod = Presenter.Session.UserName;
                        ItemEventoTarea.AUDI_FecMod = Presenter.Session.Fecha;
                        ItemEventoTarea.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                        Presenter.Item.ItemsEventosTareasDeleted.Add(ItemEventoTarea.Clone() as Entities.Det_Cotizacion_OV_EventosTareas);
                     }

                     if (Presenter.PARA_RELEASEHBL != null && ItemEventoTarea.TIPO_CodEVE == Presenter.PARA_RELEASEHBL.PARA_Valor)
                     {
                        chkCCOT_EmitirHBL.Enabled = false;
                        chkCCOT_EmitirHBL.Checked = false;
                     }

                     BSItemsEventosTareas.RemoveCurrent();
                     BSItemsEventosTareas.ResetBindings(true);
                     Edicion = false;

                     ValidarEventos();
                  }
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se puede eliminar un evento que no sea manual.");
               }
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un elemento de la grilla");
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex);
         }
         finally
         {
            ItemEventoTarea = null;
            SeleccionarEventoTarea();
            InstanceItemEventoTarea(false, false);
         }
      }
       public bool EmitirHBL(string evento)
      {
          if (oAppService.ExecuteSQL("SELECT Valor1 FROM NextSoft.dgp.MapeoDatos WHERE Tabla='PARAMETROS' AND Clave='EMITIR_HBL' AND Valor1='" + evento + "'").Tables[0].Rows.Count > 0)
              return true;
          else
              return false;
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
                  {
                     //Validar Release HBL
                     Boolean _isCorrect = true;
                     //if (Presenter.PARA_RELEASEHBL != null && ItemEventoTarea.TIPO_CodEVE == Presenter.PARA_RELEASEHBL.PARA_Valor)
                     if (cmbCONS_CodRGM.ConstantesSelectedItem != null && EmitirHBL(ItemEventoTarea.TIPO_CodEVE))
                     {
                        //if (cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
                        //{
                        //chkCCOT_EmitirHBL.Enabled = true;
                        chkCCOT_EmitirHBL.Checked = true;
                        //}
                     }
                     else if (Presenter.PARA_BLOQUEAROV != null && ItemEventoTarea.TIPO_CodEVE == Presenter.PARA_BLOQUEAROV.PARA_Valor)
                     {
                        if (chkCCOT_Bloqueado.Checked)
                        {
                           Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "La Orden de venta ya se encuentra Bloqueada.");
                           _isCorrect = false;
                        }
                        if (chkCCOT_ConExcepcion.Checked)
                        {
                           Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "La Orden de venta ya se encuentra Con Excepción.");
                           _isCorrect = false;
                        }
                        if (_isCorrect)
                        {
                           chkCCOT_Bloqueado.Checked = true;
                        }
                     }
                     else if (Presenter.PARA_DESBLOQUEAROV != null && ItemEventoTarea.TIPO_CodEVE == Presenter.PARA_DESBLOQUEAROV.PARA_Valor)
                     {
                        if (!chkCCOT_Bloqueado.Checked)
                        {
                           Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "La Orden de venta no se encuentra Bloqueada.");
                           _isCorrect = false;
                        }
                        if (_isCorrect)
                        {
                           chkCCOT_Bloqueado.Checked = false;
                        }
                     }
                     else if (Presenter.PARA_AGREGAREXCEPCIONOV != null && ItemEventoTarea.TIPO_CodEVE == Presenter.PARA_AGREGAREXCEPCIONOV.PARA_Valor)
                     {
                        if (chkCCOT_Bloqueado.Checked)
                        {
                           Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "La Orden de venta ya se encuentra Bloqueada.");
                           _isCorrect = false;
                        }
                        if (chkCCOT_ConExcepcion.Checked)
                        {
                           Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "La Orden de venta ya se encuentra Con Excepción.");
                           _isCorrect = false;
                        }
                        if (_isCorrect)
                        {
                           chkCCOT_ConExcepcion.Checked = true;
                        }
                     }
                     else if (Presenter.PARA_QUITAREXCEPCIONOV != null && ItemEventoTarea.TIPO_CodEVE == Presenter.PARA_QUITAREXCEPCIONOV.PARA_Valor)
                     {
                        if (!chkCCOT_ConExcepcion.Checked)
                        {
                           Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "La Orden de venta no se encuentra con Excepción.");
                           _isCorrect = false;
                        }
                        if (_isCorrect)
                        {
                           chkCCOT_ConExcepcion.Checked = false;
                        }
                     }
                     if (_isCorrect)
                     {
                        BSItemsEventosTareas.Add(ItemEventoTarea);
                     }
                  }
                  else
                  {
                     BSItemsEventosTareas[BSItemsEventosTareas.Position] = ItemEventoTarea;
                  }

                  BSItemsEventosTareas.ResetBindings(true);
                  ItemEventoTarea = null;
                  ClearItemEventoTarea();
                  if (BSItemsEventosTareas.Current != null && BSItemsEventosTareas.Current is Entities.Det_Cotizacion_OV_EventosTareas)
                  {
                     ItemEventoTarea = ((Entities.Det_Cotizacion_OV_EventosTareas)BSItemsEventosTareas.Current);
                  }
                  else
                  {
                     ItemEventoTarea = null;
                  }
                  InstanceItemEventoTarea(false, false);
                  Edicion = false;

                  ValidarEventos();
               }
               else
               {
                  MostrarErrorItemEventoTarea();
               }
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
         }
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
         {
         }
      }
      private void grdItemsEventosTareas_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
      {
         SeleccionarEventoTarea();
      }
      #endregion

      #region [ Metodos Anexos ]
      public Boolean EdicionAnexo { get; set; }
      private Entities.Anexos ItemAnexo = null;
      public BindingSource BSItemsAnexos { get; set; }

      private void FormatGridAnexos()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsAnexos.Columns.Clear();
            this.grdItemsAnexos.AllowAddNewRow = false;

            grdItemsAnexos.Columns.Add("ANEX_TipoDesc", "Tipo Anexo", "ANEX_TipoDesc");
            grdItemsAnexos.Columns.Add("ANEX_MroManifiesto", "Número Manifiesto", "ANEX_MroManifiesto");
            grdItemsAnexos.Columns.Add("ANEX_NumeroHBL", "Número HBL", "ANEX_NumeroHBL");
            grdItemsAnexos.Columns.Add("ANEX_FecLlegada", "Fec. Llegada", "ANEX_FecLlegada");
            grdItemsAnexos.Columns.Add("ANEX_FecDescarga", "Fec. Descarga", "ANEX_FecDescarga");
            grdItemsAnexos.Columns.Add("ANEX_FecEmbarque", "Fec. Embarque", "ANEX_FecEmbarque");
            grdItemsAnexos.Columns.Add("ANEX_FecSalida", "Fec. Salida", "ANEX_FecSalida");
            grdItemsAnexos.Columns.Add("ANEX_DescTipoRectificacion", "Tipo Rectificación", "ANEX_DescTipoRectificacion");
            grdItemsAnexos.Columns.Add("ANEX_Observaciones", "Observaciones", "ANEX_Observaciones");
            grdItemsAnexos.Columns.Add("ANEX_DondeDice", "Donde Dice", "ANEX_DondeDice");
            grdItemsAnexos.Columns.Add("ANEX_DebeDecir", "Debe Decir", "ANEX_DebeDecir");
            grdItemsAnexos.Columns.Add("ANEX_Fundamentos", "Fundamentos", "ANEX_Fundamentos");
            //grdItemsAnexos.Columns.Add("", "Documentos que se Adjuntan", "");

            grdItemsAnexos.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsAnexos);
            //grdItemsAnexos.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            this.grdItemsAnexos.ShowFilteringRow = false;
            this.grdItemsAnexos.EnableFiltering = false;
            this.grdItemsAnexos.MasterTemplate.EnableFiltering = false;
            this.grdItemsAnexos.EnableGrouping = false;
            this.grdItemsAnexos.MasterTemplate.EnableGrouping = false;
            this.grdItemsAnexos.EnableSorting = false;
            this.grdItemsAnexos.MasterTemplate.EnableCustomSorting = false;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Novedades)", ex);
         }
      }
      private void InstanceItemAnexo(Boolean ItemEnabled, Boolean EnabledGuardar)
      {
         try
         {
            //CCOT_Tipo
            //CCOT_Numero
            //ANEX_Item
            rbtANEX_TipoR.Enabled = ItemEnabled;
            rbtANEX_TipoI.Enabled = ItemEnabled;
            cmbANEX_TipoRectificacion.Enabled = ItemEnabled;
            txtANEX_NumeroHBL.Enabled = ItemEnabled;
            txtANEX_MroManifiesto.Enabled = ItemEnabled;
            mdtANEX_FecLlegada.Enabled = ItemEnabled;
            mdtANEX_FecSalida.Enabled = ItemEnabled;
            mdtANEX_FecDescarga.Enabled = ItemEnabled;
            mdtANEX_FecEmbarque.Enabled = ItemEnabled;
            txtANEX_Observaciones.Enabled = ItemEnabled;
            txtANEX_DondeDice.Enabled = ItemEnabled;
            txtANEX_DebeDecir.Enabled = ItemEnabled;
            txtANEX_Fundamentos.Enabled = ItemEnabled;
            lvwANEX_Documentos.Enabled = ItemEnabled;

            btnNuevoAnexo.Enabled = !EnabledGuardar;
            //btnEditarAnexo.Enabled = (!EnabledGuardar && ItemAnexo != null);
            //btnEliminarAnexo.Enabled = (!EnabledGuardar && ItemAnexo != null);
            btnGuardarAnexo.Enabled = EnabledGuardar;
            btnDeshacerAnexo.Enabled = EnabledGuardar;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetInstanceView, ex);
         }
      }
      private void SeleccionarAnexo()
      {
         try
         {
            if (Presenter != null)
            {
               if ((grdItemsAnexos.CurrentRow != null && grdItemsAnexos.CurrentRow.DataBoundItem != null && grdItemsAnexos.CurrentRow.DataBoundItem is Entities.Anexos))
               {
                  ItemAnexo = (grdItemsAnexos.CurrentRow.DataBoundItem as Entities.Anexos);
               }
               else
               {
                  ItemAnexo = null;
               }
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex);
         }
      }
      private void ClearItemAnexo()
      {
         try
         {
            //CCOT_Tipo
            //CCOT_Numero
            //ANEX_Item
            rbtANEX_TipoR.Checked = false;
            rbtANEX_TipoI.Checked = false;
            cmbANEX_TipoRectificacion.ComboStrSelectedValue = null;
            txtANEX_NumeroHBL.Text = String.Empty;
            txtANEX_MroManifiesto.Text = String.Empty;
            mdtANEX_FecLlegada.NSFecha = null;
            mdtANEX_FecSalida.NSFecha = null;
            mdtANEX_FecDescarga.NSFecha = null;
            mdtANEX_FecEmbarque.NSFecha = null;
            txtANEX_Observaciones.Text = String.Empty;
            txtANEX_DondeDice.Text = String.Empty;
            txtANEX_DebeDecir.Text = String.Empty;
            txtANEX_Fundamentos.Text = String.Empty;
            for (int i = 0; i < lvwANEX_Documentos.Items.Count; i++)
            {
               lvwANEX_Documentos.Items[i].Checked = false;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ClearItem, ex);
         }
      }
      private void GetItemAnexo()
      {
         try
         {
            if (ItemAnexo != null)
            {
               //CCOT_Tipo
               //CCOT_Numero
               //ANEX_Item
               if (rbtANEX_TipoR.Checked)
               {
                  ItemAnexo.ANEX_Tipo = "R";
               }
               else if (rbtANEX_TipoI.Checked)
               {
                  ItemAnexo.ANEX_Tipo = "I";
               }

               ItemAnexo.ANEX_TipoRectificacion = cmbANEX_TipoRectificacion.ComboStrSelectedValue;

               ItemAnexo.ANEX_NumeroHBL = txtANEX_NumeroHBL.Text;
               ItemAnexo.ANEX_MroManifiesto = txtANEX_MroManifiesto.Text;
               ItemAnexo.ANEX_FecLlegada = mdtANEX_FecLlegada.NSFecha;
               ItemAnexo.ANEX_FecSalida = mdtANEX_FecSalida.NSFecha;
               ItemAnexo.ANEX_FecDescarga = mdtANEX_FecDescarga.NSFecha;
               ItemAnexo.ANEX_FecEmbarque = mdtANEX_FecEmbarque.NSFecha;
               ItemAnexo.ANEX_Observaciones = txtANEX_Observaciones.Text;
               ItemAnexo.ANEX_DondeDice = txtANEX_DondeDice.Text;
               ItemAnexo.ANEX_DebeDecir = txtANEX_DebeDecir.Text;
               ItemAnexo.ANEX_Fundamentos = txtANEX_Fundamentos.Text;
               ItemAnexo.ANEX_Documentos = String.Empty;
               for (int i = 0; i < lvwANEX_Documentos.Items.Count; i++)
               {
                  ItemAnexo.ANEX_Documentos += (lvwANEX_Documentos.Items[i].Checked ? "1" : "0");
               }
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.GetItem, ex);
         }
      }
      private void SetItemAnexo()
      {
         try
         {
            if (ItemAnexo != null)
            {
               //CCOT_Tipo
               //CCOT_Numero
               //ANEX_Item
               if (ItemAnexo.ANEX_Tipo == "R")
               {
                  rbtANEX_TipoR.Checked = true;
               }
               else if (ItemAnexo.ANEX_Tipo == "I")
               {
                  rbtANEX_TipoI.Checked = true;
               }
               cmbANEX_TipoRectificacion.ComboStrSelectedValue = ItemAnexo.ANEX_TipoRectificacion;

               txtANEX_NumeroHBL.Text = ItemAnexo.ANEX_NumeroHBL;
               txtANEX_MroManifiesto.Text = ItemAnexo.ANEX_MroManifiesto;
               mdtANEX_FecLlegada.NSFecha = ItemAnexo.ANEX_FecLlegada;
               mdtANEX_FecSalida.NSFecha = ItemAnexo.ANEX_FecSalida;
               mdtANEX_FecDescarga.NSFecha = ItemAnexo.ANEX_FecDescarga;
               mdtANEX_FecEmbarque.NSFecha = ItemAnexo.ANEX_FecEmbarque;
               txtANEX_DondeDice.Text = ItemAnexo.ANEX_DondeDice;
               txtANEX_DebeDecir.Text = ItemAnexo.ANEX_DebeDecir;
               txtANEX_Fundamentos.Text = ItemAnexo.ANEX_Fundamentos;
               txtANEX_Observaciones.Text = ItemAnexo.ANEX_Observaciones;
               for (int i = 0; i < lvwANEX_Documentos.Items.Count; i++)
               {
                  if (!String.IsNullOrEmpty(ItemAnexo.ANEX_Documentos) && ItemAnexo.ANEX_Documentos.Length - 1 >= i)
                  {
                     lvwANEX_Documentos.Items[i].Checked = (ItemAnexo.ANEX_Documentos.Substring(i, 1) == "1" ? true : false);
                  }
               }
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetItem, ex);
         }
      }
      private void MostrarErrorItemAnexo()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Anexos>.Validate(ItemAnexo, tableAnexo, errorAnexo);
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex);
         }
      }

      private void btnNuevoAnexo_Click(object sender, EventArgs e)
      {
         try
         {
            ClearItemAnexo();
            ItemAnexo = new Entities.Anexos();
            ItemAnexo.CCOT_Tipo = Presenter.Item.CCOT_Tipo;
            ItemAnexo.CCOT_Numero = Presenter.Item.CCOT_Numero;
            ItemAnexo.ANEX_Item = Convert.ToInt16(Presenter.Item.ItemsAnexos.Count + 1);
            ItemAnexo.AUDI_UsrCrea = Presenter.Session.UserName;
            ItemAnexo.AUDI_FecCrea = Presenter.Session.Fecha;

            ItemAnexo.ANEX_NumeroHBL = Presenter.Item.DOOV_HBL;

            if (Presenter.Item.ItemNaveViaje != null)
            {
               ItemAnexo.ANEX_MroManifiesto = Presenter.Item.ItemNaveViaje.NVIA_NroManifiesto;

               if (Presenter.Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
               {
                  ItemAnexo.ANEX_FecLlegada = Presenter.Item.ItemNaveViaje.NVIA_FecLlega_IMPO_Zarpe_EXPO;
                  ItemAnexo.ANEX_FecDescarga = Presenter.Item.ItemNaveViaje.NVIA_FecDescarga_IMPO;
               }
               else if (Presenter.Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Exportacion)
               {
                  ItemAnexo.ANEX_FecSalida = Presenter.Item.ItemNaveViaje.NVIA_FecLlega_IMPO_Zarpe_EXPO;
                  ItemAnexo.ANEX_FecEmbarque = Presenter.Item.DDOV_FecEmbarque;
               }
            }
            ItemAnexo.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            InstanceItemAnexo(true, true);
            SetItemAnexo();
            EdicionAnexo = false;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex);
         }
      }
      private void btnEditarAnexo_Click(object sender, EventArgs e)
      {
         try
         {
            SeleccionarAnexo();
            if (ItemAnexo != null)
            {
               ClearItemAnexo();
               ItemAnexo.AUDI_UsrMod = Presenter.Session.UserName;
               ItemAnexo.AUDI_FecMod = Presenter.Session.Fecha;
               if (ItemAnexo.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
               {
                  ItemAnexo.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
               }
               SetItemAnexo();
               InstanceItemAnexo(true, true);
               EdicionAnexo = true;
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un elemento de la grilla");
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex);
         }
      }
      private void btnEliminarAnexo_Click(object sender, EventArgs e)
      {
         try
         {
            SeleccionarAnexo();
            if (ItemAnexo != null)
            {
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  if (ItemAnexo.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
                  {
                     ItemAnexo.AUDI_UsrMod = Presenter.Session.UserName;
                     ItemAnexo.AUDI_FecMod = Presenter.Session.Fecha;
                     ItemAnexo.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                     Presenter.Item.ItemsAnexosDeleted.Add(ItemAnexo);
                  }
                  BSItemsAnexos.RemoveCurrent();
                  BSItemsAnexos.ResetBindings(true);
                  Edicion = false;
               }
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un elemento de la grilla");
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex);
         }
      }
      private void btnGuardarAnexo_Click(object sender, EventArgs e)
      {
         try
         {
            if (ItemAnexo != null)
            {
               GetItemAnexo();
               if (ItemAnexo.Validar())
               {
                  if (!Edicion)
                  {
                     BSItemsAnexos.Add(ItemAnexo);
                  }
                  else
                  {
                     BSItemsAnexos[BSItemsAnexos.Position] = ItemAnexo;
                  }

                  BSItemsAnexos.ResetBindings(true);
                  ItemAnexo = null;
                  ClearItemAnexo();
                  if (BSItemsAnexos.Current != null && BSItemsAnexos.Current is Entities.Anexos)
                  {
                     ItemAnexo = ((Entities.Anexos)BSItemsAnexos.Current);
                  }
                  else
                  {
                     ItemAnexo = null;
                  }
                  InstanceItemAnexo(false, false);
                  Edicion = false;
               }
               else
               {
                  MostrarErrorItemAnexo();
               }
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
         }
      }
      private void btnDeshacerAnexo_Click(object sender, EventArgs e)
      {
         try
         {
            ClearItemAnexo();
            lvwANEX_Documentos.Items.Clear();
            InstanceItemAnexo(false, false);
            BSItemsAnexos.MoveFirst();
            Edicion = false;
         }
         catch (Exception)
         {
         }
      }
      private void btnImprimirAnexo_Click(object sender, EventArgs e)
      {
         try
         {
            if (BSItemsAnexos.Current != null && BSItemsAnexos.Current is Entities.Anexos && (BSItemsAnexos.Current as Entities.Anexos).Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
            { Presenter.ImprimirAnexo((BSItemsAnexos.Current as Entities.Anexos)); }
            else
            {
               if (BSItemsAnexos.Current != null && BSItemsAnexos.Current is Entities.Anexos && (BSItemsAnexos.Current as Entities.Anexos).Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe guardar la Orden de Venta para que se guarde el Anexo y así pueda imprimir el mismo."); }
            }
         }
         catch (Exception)
         { }
      }

      private void rbtANEX_TipoR_CheckedChanged(object sender, EventArgs e)
      {
         try
         {
            cmbANEX_TipoRectificacion.ComboStrSelectedValue = null;
            if (rbtANEX_TipoR.Checked)
            {

               lvwANEX_Documentos.Items.Clear();

               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Documento de Transporte" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Manifiesto de Carga" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Documento Nacional de Identidad - DNI" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Registro Único de Contribuyente - RUC" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Comunicación de Origen Proveedor" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Comunicación de Origen Embarcador" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Acta de Reconocimiento Previo" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Factura Comercial / Declaración Jurada" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Especificaciones Técnicas" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Liquidación de Cobranza Cancelada" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Volante de Despacho" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Declaración Aduanera Autenticada" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Nota de tarja / Tarja al Detalle" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Lista de Embarque" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Documento de Puerto / Aereopuerto / Terminal" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Certificado de Peso" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Ticket de Balanza" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Otros" });

               txtANEX_Observaciones.Text = String.Empty;
               txtANEX_DondeDice.Text = String.Empty;
               txtANEX_DebeDecir.Text = String.Empty;

               txtANEX_Observaciones.Enabled = rbtANEX_TipoR.Checked;
               txtANEX_DondeDice.Enabled = rbtANEX_TipoR.Checked;
               txtANEX_DebeDecir.Enabled = rbtANEX_TipoR.Checked;

               cmbANEX_TipoRectificacion.Enabled = true;
            }
         }
         catch (Exception)
         { }
      }
      private void rbtANEX_TipoI_CheckedChanged(object sender, EventArgs e)
      {
         try
         {
            cmbANEX_TipoRectificacion.ComboStrSelectedValue = null;
            if (rbtANEX_TipoI.Checked)
            {
               lvwANEX_Documentos.Items.Clear();

               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Documento de Transporte" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Manifiesto de Carga" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Documento Nacional de Identidad - DNI" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Comunicación de Origen Proveedor" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Comunicación de Origen Embarcador" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Factura Comercial / Declaración Jurada" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Liquidación de Cobranza Cancelada" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Declaración Aduanera Autenticada" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Nota de tarja / Tarja al Detalle" });
               lvwANEX_Documentos.Items.Add(new ListViewItem() { Text = "Otros" });

               txtANEX_Observaciones.Text = String.Empty;
               txtANEX_DondeDice.Text = String.Empty;
               txtANEX_DebeDecir.Text = String.Empty;

               txtANEX_Observaciones.Enabled = !rbtANEX_TipoI.Checked;
               txtANEX_DondeDice.Enabled = !rbtANEX_TipoI.Checked;
               txtANEX_DebeDecir.Enabled = !rbtANEX_TipoI.Checked;

               cmbANEX_TipoRectificacion.Enabled = false;
            }
         }
         catch (Exception)
         { }
      }

      private void grdItemsAnexos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
      {
         SeleccionarAnexo();
      }
      #endregion

      #region [ Metodos Matriz Draft ]
      #region [ Metodos ]
      private void FormatGridMatriz()
      {
         try
         {
            //CNTR_Numero
            //DHBL_Precinto
            //PACK_Codigo
            //DHBL_DescProducto
            //DHBL_MarcasNumeros
            //DHBL_CantBultos
            //DHBL_PesoBruto
            //DHBL_Volumen
            //TIPO_CodCDT
            //TIPO_CodPAC
            //DHBL_EsIMO
            //TIPO_CodIMO
            //DHBL_PP


            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdDet_CNTR.Columns.Clear();
            this.grdDet_CNTR.AllowAddNewRow = false;

            grdDet_CNTR.Columns.Add("CNTR_Numero", "Número del Contenedor", "CNTR_Numero");
            grdDet_CNTR.Columns.Add("DHBL_Precinto", "Precinto", "DHBL_Precinto");

            Telerik.WinControls.UI.GridViewComboBoxColumn _tipocontenedor = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _tipocontenedor.Name = "PACK_Codigo";
            _tipocontenedor.HeaderText = "Tipo Contenedor";
            _tipocontenedor.FieldName = "PACK_Codigo";
            _tipocontenedor.ValueMember = "PACK_Codigo";
            _tipocontenedor.DisplayMember = "PACK_DescC";
            _tipocontenedor.TextAlignment = ContentAlignment.MiddleLeft;

            if (Presenter.Item != null && Presenter.Item.ItemsFlete != null && Presenter.Item.ItemsFlete.Count > 0)
            {
               var _listPaquetes = (from pack in Presenter.ListPaquetes
                                    join flete in Presenter.Item.ItemsFlete on pack.PACK_Codigo equals flete.PACK_Codigo
                                    select pack).ToObservableCollection();

               _tipocontenedor.DataSource = _listPaquetes.OrderBy(pack => pack.PACK_DescC).ToObservableCollection();

            }
            else
            {
               _tipocontenedor.DataSource = Presenter.ListPaquetes;
            }

            this.grdDet_CNTR.Columns.Add(_tipocontenedor);

            grdDet_CNTR.Columns.Add("DHBL_DescProducto", "Descripción de la Carga", "DHBL_DescProducto");
            Telerik.WinControls.UI.GridViewCommandColumn _DHBL_DescProducto = new Telerik.WinControls.UI.GridViewCommandColumn();
            _DHBL_DescProducto.Name = "DHBL_DescProductoPopUp";
            _DHBL_DescProducto.HeaderText = "";
            _DHBL_DescProducto.DefaultText = "...";
            _DHBL_DescProducto.UseDefaultText = true;
            _DHBL_DescProducto.Tag = "DHBL_DescProductoPopUp";
            _DHBL_DescProducto.MinWidth = 20;
            this.grdDet_CNTR.Columns.Add(_DHBL_DescProducto);

            grdDet_CNTR.Columns.Add("DHBL_MarcasNumeros", "Marcas y Números", "DHBL_MarcasNumeros");
            Telerik.WinControls.UI.GridViewCommandColumn _DHBL_MarcasNumeros = new Telerik.WinControls.UI.GridViewCommandColumn();
            _DHBL_MarcasNumeros.Name = "_DHBL_MarcasNumerosPopUp";
            _DHBL_MarcasNumeros.HeaderText = "";
            _DHBL_MarcasNumeros.DefaultText = "...";
            _DHBL_MarcasNumeros.UseDefaultText = true;
            _DHBL_MarcasNumeros.Tag = "_DHBL_MarcasNumerosPopUp";
            _DHBL_MarcasNumeros.MinWidth = 20;
            this.grdDet_CNTR.Columns.Add(_DHBL_MarcasNumeros);

            //grdDet_CNTR.Columns.Add("DHBL_CantBultos", "Cantidad de Bultos", "DHBL_CantBultos");
            Telerik.WinControls.UI.GridViewDecimalColumn _DHBL_CantBultos = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _DHBL_CantBultos.Name = "DHBL_CantBultos";
            _DHBL_CantBultos.HeaderText = "Cantidad de Bultos";
            _DHBL_CantBultos.FieldName = "DHBL_CantBultos";
            _DHBL_CantBultos.DecimalPlaces = 3;
            _DHBL_CantBultos.Minimum = 0;
            _DHBL_CantBultos.TextAlignment = ContentAlignment.MiddleRight;
            grdDet_CNTR.Columns.Add(_DHBL_CantBultos);

            //grdDet_CNTR.Columns.Add("DHBL_PesoBruto", "Peso (Kg.)", "DHBL_PesoBruto");
            Telerik.WinControls.UI.GridViewDecimalColumn _DHBL_PesoBruto = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _DHBL_PesoBruto.Name = "DHBL_PesoBruto";
            _DHBL_PesoBruto.HeaderText = "Peso (Kg.)";
            _DHBL_PesoBruto.FieldName = "DHBL_PesoBruto";
            _DHBL_PesoBruto.DecimalPlaces = 3;
            _DHBL_PesoBruto.Minimum = 0;
            _DHBL_PesoBruto.TextAlignment = ContentAlignment.MiddleRight;
            grdDet_CNTR.Columns.Add(_DHBL_PesoBruto);

            //grdDet_CNTR.Columns.Add("DHBL_Volumen", "Volumen (M³)", "DHBL_Volumen");
            Telerik.WinControls.UI.GridViewDecimalColumn _DHBL_Volumen = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _DHBL_Volumen.Name = "DHBL_Volumen";
            _DHBL_Volumen.HeaderText = "Volumen (M³)";
            _DHBL_Volumen.FieldName = "DHBL_Volumen";
            _DHBL_Volumen.DecimalPlaces = 3;
            _DHBL_Volumen.Minimum = 0;
            _DHBL_Volumen.TextAlignment = ContentAlignment.MiddleRight;
            grdDet_CNTR.Columns.Add(_DHBL_Volumen);

            Telerik.WinControls.UI.GridViewComboBoxColumn _comodity = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _comodity.Name = "TIPO_CodCDT";
            _comodity.HeaderText = "Comodity";
            _comodity.FieldName = "TIPO_CodCDT";
            _comodity.ValueMember = "TIPO_CodTipo";
            _comodity.DisplayMember = "TIPO_Desc1";
            _comodity.DataSource = Presenter.ListTiposCDT.OrderBy(cdt => cdt.TIPO_Desc1).ToObservableCollection();
            this.grdDet_CNTR.Columns.Add(_comodity);

            Telerik.WinControls.UI.GridViewComboBoxColumn _tipobulto = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _tipobulto.Name = "TIPO_CodPAC";
            _tipobulto.HeaderText = "Tipo Bulto";
            _tipobulto.FieldName = "TIPO_CodPAC";
            _tipobulto.ValueMember = "TIPO_CodTipo";
            _tipobulto.DisplayMember = "TIPO_Desc1";
            _tipobulto.DataSource = Presenter.ListTiposPAC.OrderBy(pac => pac.TIPO_Desc1).ToObservableCollection(); ;
            this.grdDet_CNTR.Columns.Add(_tipobulto);


            Telerik.WinControls.UI.GridViewCheckBoxColumn _esimo = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _esimo.Name = "DHBL_EsIMO";
            _esimo.HeaderText = "Es IMO";
            _esimo.FieldName = "DHBL_EsIMO";
            this.grdDet_CNTR.Columns.Add(_esimo);

            Telerik.WinControls.UI.GridViewComboBoxColumn _tipoimo = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _tipoimo.Name = "TIPO_CodIMO";
            _tipoimo.HeaderText = "Clase IMO";
            _tipoimo.FieldName = "TIPO_CodIMO";
            _tipoimo.ValueMember = "TIPO_CodTipo";
            _tipoimo.DisplayMember = "TIPO_Desc1";
            _tipoimo.DataSource = Presenter.ListTiposIMO;
            this.grdDet_CNTR.Columns.Add(_tipoimo);

            grdDet_CNTR.Columns.Add("DHBL_ImoUN", "Imo UN", "DHBL_ImoUN");

            grdDet_CNTR.Columns.Add("DHBL_ContractNRO", "Contract NRO", "DHBL_ContractNRO");

            Telerik.WinControls.UI.GridViewCheckBoxColumn _pp = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _pp.Name = "DHBL_PP";
            _pp.HeaderText = "Es Parte Contenedor";
            _pp.FieldName = "DHBL_PP";
            this.grdDet_CNTR.Columns.Add(_pp);

            grdDet_CNTR.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdDet_CNTR);
            //grdDet_CNTR.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            (grdDet_CNTR.Columns["DHBL_CantBultos"] as Telerik.WinControls.UI.GridViewDecimalColumn).DecimalPlaces = 3;
            (grdDet_CNTR.Columns["DHBL_CantBultos"] as Telerik.WinControls.UI.GridViewDecimalColumn).FormatString = "{0:###,##0.000}";
            (grdDet_CNTR.Columns["DHBL_PesoBruto"] as Telerik.WinControls.UI.GridViewDecimalColumn).DecimalPlaces = 3;
            (grdDet_CNTR.Columns["DHBL_PesoBruto"] as Telerik.WinControls.UI.GridViewDecimalColumn).FormatString = "{0:###,##0.000}";
            (grdDet_CNTR.Columns["DHBL_Volumen"] as Telerik.WinControls.UI.GridViewDecimalColumn).DecimalPlaces = 3;
            (grdDet_CNTR.Columns["DHBL_Volumen"] as Telerik.WinControls.UI.GridViewDecimalColumn).FormatString = "{0:###,##0.000}";

            this.grdDet_CNTR.ShowFilteringRow = false;
            this.grdDet_CNTR.EnableFiltering = false;
            this.grdDet_CNTR.MasterTemplate.EnableFiltering = false;
            this.grdDet_CNTR.EnableGrouping = false;
            this.grdDet_CNTR.MasterTemplate.EnableGrouping = false;
            this.grdDet_CNTR.EnableSorting = false;
            this.grdDet_CNTR.MasterTemplate.EnableCustomSorting = false;


            //CNTR_Numero
            //DHBL_Precinto
            //PACK_Codigo
            //DHBL_DescProducto
            //DHBL_MarcasNumeros
            //DHBL_CantBultos
            //DHBL_PesoBruto
            //DHBL_Volumen
            //TIPO_CodCDT
            //TIPO_CodPAC
            //DHBL_EsIMO
            //TIPO_CodIMO
            //DHBL_PP

            this.grdDet_CNTR.AllowEditRow = true;
            this.grdDet_CNTR.Columns["CNTR_Numero"].ReadOnly = false;
            this.grdDet_CNTR.Columns["DHBL_Precinto"].ReadOnly = false;
            this.grdDet_CNTR.Columns["PACK_Codigo"].ReadOnly = false;
            this.grdDet_CNTR.Columns["DHBL_DescProducto"].ReadOnly = false;
            this.grdDet_CNTR.Columns["DHBL_MarcasNumeros"].ReadOnly = false;
            this.grdDet_CNTR.Columns["DHBL_CantBultos"].ReadOnly = false;
            this.grdDet_CNTR.Columns["DHBL_PesoBruto"].ReadOnly = false;
            this.grdDet_CNTR.Columns["DHBL_Volumen"].ReadOnly = false;
            this.grdDet_CNTR.Columns["TIPO_CodCDT"].ReadOnly = false;
            this.grdDet_CNTR.Columns["TIPO_CodPAC"].ReadOnly = false;
            this.grdDet_CNTR.Columns["DHBL_EsIMO"].ReadOnly = false;
            this.grdDet_CNTR.Columns["TIPO_CodIMO"].ReadOnly = false;
            this.grdDet_CNTR.Columns["DHBL_ImoUN"].ReadOnly = false;
            this.grdDet_CNTR.Columns["DHBL_PP"].ReadOnly = true;

            this.grdDet_CNTR.Columns["CNTR_Numero"].Width = 100;
            this.grdDet_CNTR.Columns["DHBL_Precinto"].Width = 100;
            this.grdDet_CNTR.Columns["PACK_Codigo"].Width = 100;
            this.grdDet_CNTR.Columns["DHBL_DescProducto"].Width = 200;
            this.grdDet_CNTR.Columns["DHBL_MarcasNumeros"].Width = 200;
            this.grdDet_CNTR.Columns["DHBL_CantBultos"].Width = 100;
            this.grdDet_CNTR.Columns["DHBL_PesoBruto"].Width = 100;
            this.grdDet_CNTR.Columns["DHBL_Volumen"].Width = 100;
            this.grdDet_CNTR.Columns["TIPO_CodCDT"].Width = 100;
            this.grdDet_CNTR.Columns["TIPO_CodPAC"].Width = 100;
            this.grdDet_CNTR.Columns["DHBL_EsIMO"].Width = 60;
            this.grdDet_CNTR.Columns["TIPO_CodIMO"].Width = 100;
            this.grdDet_CNTR.Columns["DHBL_ImoUN"].Width = 80;
            this.grdDet_CNTR.Columns["DHBL_PP"].Width = 60;

         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Contenedores)", ex);
         }
      }
      private void SetDatosShipper(Entities.Entidad x_shipper)
      {
         try
         {
            if (String.IsNullOrEmpty(txtDDOV_DescShipper.Text))
            {
               String _DDOV_DescShipper = "";
               _DDOV_DescShipper += x_shipper.ENTC_NomCompleto;
               _DDOV_DescShipper += Environment.NewLine + x_shipper.TIPO_DescTDI + ": " + x_shipper.ENTC_DocIden;
               _DDOV_DescShipper += Environment.NewLine + x_shipper.DIRE_Direccion;
               _DDOV_DescShipper += Environment.NewLine + x_shipper.DIRE_Ubigeo;
               _DDOV_DescShipper += Environment.NewLine + "Telf.:" + x_shipper.ENTC_Telef1 + " " + "Cel.:" + x_shipper.ENTC_Telef2;

               txtDDOV_DescShipper.Text = _DDOV_DescShipper;
            }
         }
         catch (Exception) { }
      }
      private void SetDatosConsignee(Entities.Entidad x_consignee)
      {
         try
         {
            if (String.IsNullOrEmpty(txtDDOV_DescConsignee.Text))
            {
               String _DDOV_DescConsignee = "";
               _DDOV_DescConsignee += x_consignee.ENTC_NomCompleto;
               _DDOV_DescConsignee += Environment.NewLine + x_consignee.TIPO_DescTDI + ": " + x_consignee.ENTC_DocIden;
               _DDOV_DescConsignee += Environment.NewLine + x_consignee.DIRE_Direccion;
               _DDOV_DescConsignee += Environment.NewLine + x_consignee.DIRE_Ubigeo;
               _DDOV_DescConsignee += Environment.NewLine + "Telf.:" + x_consignee.ENTC_Telef1 + " " + "Cel.:" + x_consignee.ENTC_Telef2;

               txtDDOV_DescConsignee.Text = _DDOV_DescConsignee;
            }
         }
         catch (Exception) { }
      }
      private void SetDatosNotify(Entities.Entidad x_notify)
      {
         try
         {
            if (String.IsNullOrEmpty(txtDDOV_DescNotify.Text))
            {
               String _DDOV_DescNotify = "";
               _DDOV_DescNotify += x_notify.ENTC_NomCompleto;
               _DDOV_DescNotify += Environment.NewLine + x_notify.TIPO_DescTDI + ": " + x_notify.ENTC_DocIden;
               _DDOV_DescNotify += Environment.NewLine + x_notify.DIRE_Direccion;
               _DDOV_DescNotify += Environment.NewLine + x_notify.DIRE_Ubigeo;
               _DDOV_DescNotify += Environment.NewLine + "Telf.:" + x_notify.ENTC_Telef1 + " " + "Cel.:" + x_notify.ENTC_Telef2;

               txtDDOV_DescNotify.Text = _DDOV_DescNotify;
            }
         }
         catch (Exception) { }
      }
      private void SetDatosAgente(Entities.Entidad x_agente)
      {
         try
         {
            if (Presenter.Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Exportacion)
            {
               if (String.IsNullOrEmpty(txtDDOV_DescApplyTo.Text))
               {
                  String _DDOV_DescApplyTo = "";
                  _DDOV_DescApplyTo += x_agente.ENTC_NomCompleto;
                  _DDOV_DescApplyTo += Environment.NewLine + x_agente.TIPO_DescTDI + ": " + x_agente.ENTC_DocIden;
                  _DDOV_DescApplyTo += Environment.NewLine + x_agente.DIRE_Direccion;
                  _DDOV_DescApplyTo += Environment.NewLine + x_agente.DIRE_Ubigeo;
                  _DDOV_DescApplyTo += Environment.NewLine + "Telf.:" + x_agente.ENTC_Telef1 + " " + "Cel.:" + x_agente.ENTC_Telef2;
                  _DDOV_DescApplyTo += Environment.NewLine + x_agente.ENTC_EMail;

                  txtDDOV_DescApplyTo.Text = _DDOV_DescApplyTo;
               }
            }
         }
         catch (Exception) { }
      }
      private void AddContenedor()
      {
         try
         {
            Entities.Det_CNTR _det_cntr = new Entities.Det_CNTR();
            Int32 _DHBL_Item = 0;
            if (((ObservableCollection<Entities.Det_CNTR>)BSDet_CNTR.DataSource).Count > 0)
            { _DHBL_Item = ((ObservableCollection<Entities.Det_CNTR>)BSDet_CNTR.DataSource).Max(dhbl => dhbl.DHBL_Item.Value); }

            _det_cntr.CCOT_Tipo = Presenter.Item.CCOT_Tipo;
            _det_cntr.CCOT_Numero = Presenter.Item.CCOT_Numero;
            _det_cntr.DHBL_Item = _DHBL_Item + 1;

            _det_cntr.TIPO_TabCDT = "CDT";
            _det_cntr.TIPO_CodCDT = "001"; //GENERAL

            _det_cntr.AUDI_UsrCrea = Presenter.Session.UserName;
            _det_cntr.AUDI_FecCrea = Presenter.Session.Fecha;
            _det_cntr.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            BSDet_CNTR.Add(_det_cntr);
            BSDet_CNTR.ResetBindings(true);
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un contenedor", ex);
         }
      }
      private void DelContenedor()
      {
         try
         {
            if (BSDet_CNTR.Current != null && BSDet_CNTR.Current is Entities.Det_CNTR)
            {
               Entities.Det_CNTR _det_cntr = (Entities.Det_CNTR)BSDet_CNTR.Current;
               if (_det_cntr.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
               {
                  _det_cntr.AUDI_UsrMod = Presenter.Session.UserName;
                  _det_cntr.AUDI_FecMod = Presenter.Session.Fecha;
                  _det_cntr.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                  Presenter.Item.ItemsDet_CNTRDeleted.Add(_det_cntr);
               }
               BSDet_CNTR.RemoveCurrent();
               BSDet_CNTR.ResetBindings(true);
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar un contenedor", ex);
         }
      }
      public void ShowImportacionMatrizDraft()
      {
         try
         {
            txtDDOV_DescShipper.Text = Presenter.Item.DDOV_DescShipper;
            txtDDOV_DescConsignee.Text = Presenter.Item.DDOV_DescConsignee;
            txtDDOV_DescNotify.Text = Presenter.Item.DDOV_DescNotify;

            BSDet_CNTR.DataSource = Presenter.Item.ItemsDet_CNTR;
            BSDet_CNTR.ResetBindings(true);
         }
         catch (Exception) { }
      }
      #endregion

      #region [ Eventos ]
      private void btnExportarMatrizDraft_Click(object sender, EventArgs e)
      {
         Presenter.ExportarMatrizDraft();
      }
      private void btnImportarMatrizDraft_Click(object sender, EventArgs e)
      {
         Presenter.ImportarMatrizDraft();
      }
      private void btnImprimirMatrizDraft_Click(object sender, EventArgs e)
      { Presenter.ImprimirMatrizDraft(); }
      private void btnNumerarHBL_Click(object sender, EventArgs e)
      {
         try
         {
            String NumeroHBL = "";
            if (Presenter.NumerarHBL(ref NumeroHBL))
            {
               String _HBL = "";
               if (Presenter.Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Exportacion)
               {
                  txtDOOV_HBL.Text = NumeroHBL;
               }
               else
               {
                  if (Presenter.Item.DDOV_HBLNieto)
                  {
                     txtDOOV_HBL.Text = NumeroHBL;
                     txtDOOV_NumeroBLNieto.Text = NumeroHBL;
                  }
                  else
                  {
                     txtDOOV_HBL.Text = NumeroHBL;
                  }
               }
            }
         }
         catch (Exception)
         {
         }
      }
      private void btnEmitirHBL_Click(object sender, EventArgs e)
      {
         try
         {
            Presenter.EmitirHBL(chkSinLogo.Checked, chkSinFormato.Checked, chkSinFlete.Checked, chkDetallado.Checked);
         }
         catch (Exception)
         {
         }
      }
      private void btnAddContenedor_Click(object sender, EventArgs e)
      {
         AddContenedor();
      }
      private void btnDelContenedor_Click(object sender, EventArgs e)
      {
         DelContenedor();
      }
      private void txaENTC_CodShipper_AyudaValueChanged(object sender, EventArgs e)
      {
         if (txaENTC_CodShipper.Value != null)
         { SetDatosShipper(txaENTC_CodShipper.Value); }
         else
         { txtDDOV_DescShipper.Text = String.Empty; }
      }
      private void txaENTC_CodConsignee_AyudaValueChanged(object sender, EventArgs e)
      {
         if (txaENTC_CodConsignee.Value != null)
         { SetDatosConsignee(txaENTC_CodConsignee.Value); }
         else
         { txtDDOV_DescConsignee.Text = String.Empty; }

         try
         {
            if (txaENTC_CodConsignee.Value != null && txaENTC_CodNotify.Value == null)
            { txaENTC_CodNotify.SetValue((txaENTC_CodConsignee.Value.ENTC_Codigo)); }
         }
         catch (Exception)
         { }
      }
      private void txaENTC_CodNotify_AyudaValueChanged(object sender, EventArgs e)
      {
         if (txaENTC_CodNotify.Value != null)
         { SetDatosNotify(txaENTC_CodNotify.Value); }
         else
         { txtDDOV_DescNotify.Text = String.Empty; }
      }
      private void txaENTC_CodAgente_AyudaValueChanged(object sender, EventArgs e)
      {
         EstablecerLineaNegocio();
         SetServiciosAgente();
         if (txaENTC_CodAgente.Value != null)
         { SetDatosAgente(txaENTC_CodAgente.Value); }
         else
         {
            if (Presenter.Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Exportacion)
            { txtDDOV_DescApplyTo.Text = String.Empty; }
         }
      }
      private void chkCCOT_EmitirHBL_CheckedChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Exportacion)
            { btnEmitirHBL.Enabled = true; }
            else
            { btnEmitirHBL.Enabled = chkCCOT_EmitirHBL.Checked; }

            txtDDOV_DescShipper.Enabled = chkCCOT_EmitirHBL.Checked;
            txtDDOV_DescConsignee.Enabled = chkCCOT_EmitirHBL.Checked;
            txtDDOV_DescNotify.Enabled = chkCCOT_EmitirHBL.Checked;
            txtDDOV_DescApplyTo.Enabled = chkCCOT_EmitirHBL.Checked;

            txtDOOV_PlaceReceipt.Enabled = chkCCOT_EmitirHBL.Checked;
            txtDOOV_PlaceDelivery.Enabled = chkCCOT_EmitirHBL.Checked;
         }
         catch (Exception)
         { }
      }
      private void chkDDOV_HBLNieto_CheckedChanged(object sender, EventArgs e)
      {
         try
         {
            if (chkDDOV_HBLNieto.Checked)
            {
               txaENTC_CodConsigneeNieto.Enabled = true;
               txaENTC_CodConsigneeNieto.EnabledAyudaButton = true;

               txaENTC_CodShipperNieto.Enabled = true;
               txaENTC_CodShipperNieto.EnabledAyudaButton = true;

               txaENTC_CodNotifyNieto.Enabled = true;
               txaENTC_CodNotifyNieto.EnabledAyudaButton = true;

               if (txaENTC_CodConsignee.Value != null && txaENTC_CodConsigneeNieto.Value == null)
               { txaENTC_CodConsigneeNieto.SetValue(txaENTC_CodConsignee.Value.ENTC_Codigo); }

               if (txaENTC_CodShipper.Value != null && txaENTC_CodShipperNieto.Value == null)
               { txaENTC_CodShipperNieto.SetValue(txaENTC_CodShipper.Value.ENTC_Codigo); }

               if (txaENTC_CodNotify.Value != null && txaENTC_CodNotifyNieto.Value == null)
               { txaENTC_CodNotifyNieto.SetValue(txaENTC_CodNotify.Value.ENTC_Codigo); }

               txtDOOV_NumeroBLNieto.Text = txtDOOV_HBL.Text;
               txtDOOV_NumeroBLNieto.Enabled = true;

               //if (Presenter.Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion && (Presenter.Item.CONS_CodFLE == "001" || Presenter.Item.CONS_CodFLE == "003"))
               //{
                  btnNumerarHBL.Visible = true;
                  btnNumerarHBL.Enabled = true;
            //   }
            }
            else
            {
               txaENTC_CodConsigneeNieto.Enabled = false;
               txaENTC_CodConsigneeNieto.EnabledAyudaButton = false;
               txaENTC_CodConsigneeNieto.ClearValue();

               txaENTC_CodShipperNieto.Enabled = false;
               txaENTC_CodShipperNieto.EnabledAyudaButton = false;
               txaENTC_CodShipperNieto.ClearValue();

               txaENTC_CodNotifyNieto.Enabled = false;
               txaENTC_CodNotifyNieto.EnabledAyudaButton = false;
               txaENTC_CodNotifyNieto.ClearValue();

               txtDOOV_NumeroBLNieto.Text = null;
               txtDOOV_NumeroBLNieto.Enabled = false;

               if (Presenter.Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion && (Presenter.Item.CONS_CodFLE == "001" || Presenter.Item.CONS_CodFLE == "003"))
               {
                  btnNumerarHBL.Visible = false;
                  btnNumerarHBL.Enabled = false;
               }
            }
         }
         catch (Exception)
         { }
      }

      private void grdDet_CNTR_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            String _texto = "";
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               //switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).Tag.ToString())
               switch ((sender as Telerik.WinControls.UI.GridCommandCellElement).ColumnInfo.Name)
               {
                  case "DHBL_DescProductoPopUp":
                     _texto = grdDet_CNTR.CurrentRow.Cells["DHBL_DescProducto"].Value != null ? grdDet_CNTR.CurrentRow.Cells["DHBL_DescProducto"].Value.ToString() : "";
                     OPE001TView _viewDHBL_DescProducto = new OPE001TView("Descripción de la Carga", _texto, 4000);
                     if (_viewDHBL_DescProducto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                     { grdDet_CNTR.CurrentRow.Cells["DHBL_DescProducto"].Value = _viewDHBL_DescProducto.Texto; }
                     _viewDHBL_DescProducto.Dispose();
                     _viewDHBL_DescProducto = null;
                     break;
                  case "_DHBL_MarcasNumerosPopUp":
                     _texto = grdDet_CNTR.CurrentRow.Cells["DHBL_MarcasNumeros"].Value != null ? grdDet_CNTR.CurrentRow.Cells["DHBL_MarcasNumeros"].Value.ToString() : "";
                     OPE001TView _viewDHBL_MarcasNumeros = new OPE001TView("Marcas y Números", _texto, 4000);
                     if (_viewDHBL_MarcasNumeros.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                     { grdDet_CNTR.CurrentRow.Cells["DHBL_MarcasNumeros"].Value = _viewDHBL_MarcasNumeros.Texto; }
                     _viewDHBL_MarcasNumeros.Dispose();
                     _viewDHBL_MarcasNumeros = null;
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el botón de la grilla de contenedores.", ex); }
      }
      private void grdDet_CNTR_CellBeginEdit(object sender, Telerik.WinControls.UI.GridViewCellCancelEventArgs e)
      {
         try
         {
            if (grdDet_CNTR.Columns[e.ColumnIndex].Name == "PACK_Codigo" && grdDet_CNTR.Columns[e.ColumnIndex] is Telerik.WinControls.UI.GridViewComboBoxColumn)
            {
               if (BSItemsFlete != null && BSItemsFlete.DataSource != null && (BSItemsFlete.DataSource is ObservableCollection<Entities.Det_Cotizacion_OV_Flete>) && (BSItemsFlete.DataSource as ObservableCollection<Entities.Det_Cotizacion_OV_Flete>).Count > 0)
               {
                  var _listPaquetes = (from pack in Presenter.ListPaquetes
                                       join flete in (BSItemsFlete.DataSource as ObservableCollection<Entities.Det_Cotizacion_OV_Flete>) on pack.PACK_Codigo equals flete.PACK_Codigo
                                       select pack).ToObservableCollection();

                  (grdDet_CNTR.Columns[e.ColumnIndex] as Telerik.WinControls.UI.GridViewComboBoxColumn).DataSource = _listPaquetes.OrderBy(pack => pack.PACK_DescC).ToObservableCollection();
               }
               else
               {
                  (grdDet_CNTR.Columns[e.ColumnIndex] as Telerik.WinControls.UI.GridViewComboBoxColumn).DataSource = Presenter.ListPaquetes;
               }
            }
         }
         catch (Exception) { }
      }
      private void grdDet_CNTR_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
      {
         try
         {
            if (grdDet_CNTR.Columns[e.ColumnIndex].Name == "PACK_Codigo")
            {
               if (grdDet_CNTR.Rows[e.RowIndex].DataBoundItem != null && grdDet_CNTR.Rows[e.RowIndex].DataBoundItem is Entities.Det_CNTR && Presenter.ListPaquetes.Where(pack => pack.PACK_Codigo == (grdDet_CNTR.Rows[e.RowIndex].DataBoundItem as Entities.Det_CNTR).PACK_Codigo).FirstOrDefault() != null)
               { (grdDet_CNTR.Rows[e.RowIndex].DataBoundItem as Entities.Det_CNTR).PACK_Desc = Presenter.ListPaquetes.Where(pack => pack.PACK_Codigo == (grdDet_CNTR.Rows[e.RowIndex].DataBoundItem as Entities.Det_CNTR).PACK_Codigo).FirstOrDefault().PACK_Desc; }
            }
         }
         catch (Exception) { }
      }
      #endregion
      #endregion

      #region [ Correo & Archivos ]
      #region[ Metodos ]
      #endregion

      #region [ Eventos ]
      private void btnDireccionamiento_Click(object sender, EventArgs e)
      {
         try
         {
            String _Cod_Cosco = Presenter.PARA_CODIGOCOSCO.PARA_Valor;
            String _Cod_Transportista = Convert.ToString(Presenter.Item.ENTC_CodTransportista);
            Nullable<Int32> _NVIA_Codigo = Presenter.Item.NVIA_Codigo;
            Nullable<Int32> _CCOT_Numero = Presenter.Item.CCOT_Numero;

            //########## PARAMETROS ##########
            Delfin.Controls.EmailFiles EFiles = null;
            Boolean _por_ov = true;
            Nullable<DateTime> _fec_eta_etd = Presenter.Item.ItemNaveViaje.NVIA_FecETA_IMPO_ETD_EXPO;
            String _transportista = Presenter.Item.ENTC_NomTransportista;
            String _nombre_nave = Presenter.Item.ItemNaveViaje.NAVE_Nombre;
            String _numero_viaje = Presenter.Item.ItemNaveViaje.NVIA_NroViaje;
            String _correo_ope = Presenter.PARA_CORREOOPERACIONES.PARA_Valor;
            //################################

            if (_Cod_Transportista == _Cod_Cosco)
            {
               Presenter.Direccionamiento(_NVIA_Codigo, 1, _CCOT_Numero); //numero 1 es COSCO
               EFiles = new Controls.EmailFiles();
               String _mensaje = EFiles.CorreoDireccionamientoCosco(_por_ov, Presenter.DtDireciomaniento, _fec_eta_etd, _transportista, _nombre_nave, _numero_viaje, _correo_ope);
               if (!String.IsNullOrEmpty(_mensaje))
               {
                  if (_mensaje.Substring(0, 1) == "#")
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE DIRECCIONAMIENTO (Ver Detalles)", _mensaje); }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
               }
               else
               {
                  Presenter.GenerarEventosTareas("Se ha generado el correo para el Direccionamiento de la Linea de la Orden de Venta", Presenter.PARA_DIRECCIONAMIENTOLINEA.PARA_Valor, Presenter.Item.CCOT_Numero, Presenter.Item.CCOT_Tipo);
               }
            }
            else
            {
               Presenter.Direccionamiento(_NVIA_Codigo, 2, _CCOT_Numero); //cualquier otro numero es otro transportista
               EFiles = new Controls.EmailFiles();
               String _mensaje = EFiles.CorreoDireccionamiento(Presenter.DtDireciomaniento, _fec_eta_etd, _transportista, _nombre_nave, _numero_viaje, _correo_ope);
               if (!String.IsNullOrEmpty(_mensaje))
               {
                  if (_mensaje.Substring(0, 1) == "#")
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE DIRECCIONAMIENTO (Ver Detalles)", _mensaje); }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
               }
               else
               {
                  Presenter.GenerarEventosTareas("Se ha generado el correo para el Direccionamiento de la Linea de la Orden de Venta", Presenter.PARA_DIRECCIONAMIENTOLINEA.PARA_Valor, Presenter.Item.CCOT_Numero, Presenter.Item.CCOT_Tipo);
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error durante el proceso del Envío del Correo Direccionamiento: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
      private void btnDesgloseVoBo_Click(object sender, EventArgs e)
      {
         try
         {
            String _Cod_Tramarsa = Presenter.PARA_CODIGOTRAMARSA.PARA_Valor;
            String _Cod_AgentePor = Convert.ToString(Presenter.Item.ItemNaveViaje.ENTC_CodAgenPortVoBo_IMPO);
            Nullable<Int32> _NVIA_Codigo = Presenter.Item.NVIA_Codigo;
            Nullable<Int32> _CCOT_Numero = Presenter.Item.CCOT_Numero;

            //########## PARAMETROS ##########
            Delfin.Controls.EmailFiles EFiles = null;
            Boolean _por_ov = true;
            Nullable<DateTime> _fec_eta = Presenter.Item.ItemNaveViaje.NVIA_FecETA_IMPO_ETD_EXPO;
            Nullable<DateTime> _fec_zarpe = Presenter.Item.ItemNaveViaje.NVIA_FecLlega_IMPO_Zarpe_EXPO;
            String _transportista = Presenter.Item.ENTC_NomTransportista;
            String _nombre_nave = Presenter.Item.ItemNaveViaje.NAVE_Nombre;
            String _numero_viaje = Presenter.Item.ItemNaveViaje.NVIA_NroViaje;
            String _agente = String.Empty;
            switch (Presenter.Item.CONS_CodRGM)
            {
               case Delfin.Controls.variables.CONSRGM_Importacion:
                  _agente = Presenter.Item.ItemNaveViaje.ENTC_NomAgent1;
                  break;
               case Delfin.Controls.variables.CONSRGM_Exportacion:
                  _agente = Presenter.Item.ItemNaveViaje.ENTC_NomAgente;
                  break;
            }
            String _codigo_regimen = Presenter.Item.CONS_CodRGM;
            //################################

            if (_Cod_AgentePor == _Cod_Tramarsa)
            {
               Presenter.DesgloseVoBo(_NVIA_Codigo, 2, _CCOT_Numero); //cualquier numero execto el 1 es TRAMARSA
               EFiles = new Controls.EmailFiles();
               String _mensaje = EFiles.DocVoBoTramarsa(_por_ov, Presenter.DtVoBo, _fec_eta, _agente, _nombre_nave, _numero_viaje);
               if (!String.IsNullOrEmpty(_mensaje))
               {
                  if (_mensaje.Substring(0, 1) == "#")
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE DESGLOSE DE VoBo (Ver Detalles)", _mensaje); }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
               }
               else
               {
                  Presenter.GenerarEventosTareas("Se ha generado el Doc. de Desglose De VoBo", Presenter.PARA_DESGLOSEVoBo.PARA_Valor, Presenter.Item.CCOT_Numero, Presenter.Item.CCOT_Tipo);
               }
            }
            else
            {
               Presenter.DesgloseVoBo(_NVIA_Codigo, 1, _CCOT_Numero); //numero 1 cualquier agente menos TRAMARSA
               EFiles = new Controls.EmailFiles();
               String _mensaje = EFiles.DocVoBo(Presenter.DtVoBo, _fec_eta, _fec_zarpe, _NVIA_Codigo, _agente, _nombre_nave, _numero_viaje, _codigo_regimen);
               if (!String.IsNullOrEmpty(_mensaje))
               {
                  if (_mensaje.Substring(0, 1) == "#")
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE DESGLOSE DE VoBo (Ver Detalles)", _mensaje); }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
               }
               else
               {
                  Presenter.GenerarEventosTareas("Se ha generado el Doc. de Desglose De VoBo", Presenter.PARA_DESGLOSEVoBo.PARA_Valor, Presenter.Item.CCOT_Numero, Presenter.Item.CCOT_Tipo);
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error durante el proceso de abrir el documento: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
      private void btnDevolucionMaster_Click(object sender, EventArgs e)
      {
         try
         {
            //########## PARAMETROS ##########
            Delfin.Controls.EmailFiles EFiles = null;
            Boolean _por_ov = true;
            String _ccot_numdoc = Presenter.Item.CCOT_NumDoc;
            String _nombre_transportista = Presenter.Item.ENTC_NomTransportista;
            Int32 _codigo_transportista = 0;
            if (Presenter.Item.ENTC_CodTransportista != null)
            { _codigo_transportista = Convert.ToInt32(Presenter.Item.ENTC_CodTransportista); }
            String _numero_mbl = Presenter.Item.DOOV_MBL;
            String _cons_tabrgm = Presenter.Item.CONS_TabRGM;
            String _cons_codrgm = Presenter.Item.CONS_CodRGM;
            //################################

            EFiles = new Controls.EmailFiles();
            String _mensaje = EFiles.DevolucionMaster(_por_ov, _ccot_numdoc, _numero_mbl, _nombre_transportista, _cons_tabrgm, _cons_codrgm, _codigo_transportista);
            if (!String.IsNullOrEmpty(_mensaje))
            {
               if (_mensaje.Substring(0, 1) == "#")
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE DEVOLUCION DE MASTER (Ver Detalles)", _mensaje); }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
            }
            else
            {
               Presenter.GenerarEventosTareas("Se ha realizado la Devolución de Master de la Orden de Venta", Presenter.PARA_DEVOLUCIONMASTER.PARA_Valor, Presenter.Item.CCOT_Numero, Presenter.Item.CCOT_Tipo);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error durante el proceso de abrir el documento: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

      }
      private void btnRecojo_Click(object sender, EventArgs e)
      {
         try
         {
            //########## PARAMETROS ##########
            Delfin.Controls.EmailFiles EFiles = null;
            Boolean _por_ov = true;
            String _ccot_numdoc = Presenter.Item.CCOT_NumDoc;
            String _nombre_cliente = Presenter.Item.ENTC_NomCliente;
            String _nombre_contacto = Presenter.Item.ENTC_NomContacto;
            String _nombre_transportista = Presenter.Item.ENTC_NomTransportista;
            String _numero_mbl = Presenter.Item.DOOV_MBL;
            String _nombre_nave = Presenter.Item.ItemNaveViaje.NAVE_Nombre;
            String _numero_viaje = Presenter.Item.ItemNaveViaje.NVIA_NroViaje;
            //################################

            EFiles = new Controls.EmailFiles();
            String _mensaje = EFiles.CartaRecojo(_por_ov, _ccot_numdoc, _nombre_cliente, _nombre_contacto, _nombre_transportista, _numero_mbl, _nombre_nave, _numero_viaje);
            if (!String.IsNullOrEmpty(_mensaje))
            {
               if (_mensaje.Substring(0, 1) == "#")
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE CARTA DE RECOJO (Ver Detalles)", _mensaje); }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
            }
            else
            {
               Presenter.GenerarEventosTareas("Recojo de BLs de la Orden de Venta", Presenter.PARA_RECOJOBLs.PARA_Valor, Presenter.Item.CCOT_Numero, Presenter.Item.CCOT_Tipo);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error durante el proceso de abrir el documento: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
      private void btnAutorizacionTransmision_Click(object sender, EventArgs e)
      {
         try
         {
            //########## PARAMETROS ##########
            Delfin.Controls.EmailFiles EFiles = null;
            Boolean _por_ov = true;
            String _ccot_numdoc = Presenter.Item.CCOT_NumDoc;
            String _nombre_transportista = Presenter.Item.ENTC_NomTransportista;
            String _numero_mbl = Presenter.Item.DOOV_MBL;
            String _nombre_empresa = Presenter.ItemEmpresa.ENTC_NomCompleto;
            String _ruc_empresa = Presenter.ItemEmpresa.ENTC_DocIden;
            String _nombre_cliente = Presenter.Item.ENTC_NomCliente;
            String _ruc_cliente = Presenter.Item.ENTC_DocIdenCliente;
            //################################

            EFiles = new Controls.EmailFiles();
            String _mensaje = EFiles.CartaAutorizacionTransmision(_por_ov, _ccot_numdoc, _nombre_transportista, _nombre_empresa, _ruc_empresa, _nombre_cliente, _ruc_cliente, _numero_mbl);
            if (!String.IsNullOrEmpty(_mensaje))
            {
               if (_mensaje.Substring(0, 1) == "#")
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE AUTORIZACION DE TRASMISION (Ver Detalles)", _mensaje); }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
            }
            else
            {
               Presenter.GenerarEventosTareas("Se ha realizado la Autorización de Servicio de Transmision de la Orden de Venta", Presenter.PARA_SERVICIOTRANSMISION.PARA_Valor, Presenter.Item.CCOT_Numero, Presenter.Item.CCOT_Tipo);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error durante el proceso de abrir el documento: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
      private void btnSolicitudVolante_Click(object sender, EventArgs e)
      {
         try
         {
            String _TIPO_Embarque = null;
            switch (Presenter.Item.CONS_CodFLE)
            {
               case "001":
               case "003":
                  _TIPO_Embarque = "LCL";
                  break;
               case "002":
               case "004":
                  _TIPO_Embarque = "FCL";
                  break;
            }
            //########## PARAMETROS ##########
            Delfin.Controls.EmailFiles EFiles = null;
            Nullable<Int32> _NVIA_Codigo = Presenter.Item.NVIA_Codigo;
            Nullable<Int32> _CCOT_Numero = Presenter.Item.CCOT_Numero;
            Nullable<DateTime> _fec_eta_etd = Presenter.Item.ItemNaveViaje.NVIA_FecETA_IMPO_ETD_EXPO;
            Nullable<DateTime> _fec_llegada = Presenter.Item.ItemNaveViaje.NVIA_FecLlega_IMPO_Zarpe_EXPO;
            String _nombre_transportista = Presenter.Item.ENTC_NomTransportista;
            String _nombre_nave = Presenter.Item.ItemNaveViaje.NAVE_Nombre;
            String _numero_viaje = Presenter.Item.ItemNaveViaje.NVIA_NroViaje;
            String _nombre_termportuario = Presenter.Item.ItemNaveViaje.ENTC_NomTermin;
            String _numero_manifiesto = Presenter.Item.ItemNaveViaje.NVIA_NroManifiesto;
            String _correo_operaciones = Presenter.PARA_CORREOOPERACIONES.PARA_Valor;
            //################################

            Presenter.CargaTarjada(_NVIA_Codigo, _TIPO_Embarque, _CCOT_Numero);
            string _mensajeError = string.Empty;
            if (Presenter.DtCargaTarjada != null && Presenter.DtCargaTarjada.Rows.Count > 0)
            {
               Delfin.Controls.Utils.checkMail("Operaciones", _correo_operaciones, ref _mensajeError);
               foreach (DataRow drCargaTarjada in Presenter.DtCargaTarjada.Rows)
               {
                  string _nombre = Convert.ToString(drCargaTarjada["ENTC_NomCliente"]);
                  string _correo = Convert.ToString(drCargaTarjada["ENTC_EMailCliente"]);
                  Delfin.Controls.Utils.checkMail(_nombre, _correo, ref _mensajeError);
               }
            }
            if (string.IsNullOrEmpty(_mensajeError))
            {
               EFiles = new Controls.EmailFiles();
               String _mensaje = EFiles.CargaTarjada(Presenter.DtCargaTarjada, _fec_llegada, _fec_eta_etd, _TIPO_Embarque, _nombre_transportista, _nombre_nave, _nombre_termportuario, _numero_manifiesto, _numero_viaje, _correo_operaciones);
               if (!String.IsNullOrEmpty(_mensaje))
               {
                  if (_mensaje.Substring(0, 1) == "#")
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE DESGLOSE DE VoBo (Ver Detalles)", _mensaje); }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
               }
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Verifique los siguientes Correos Electronicos (detalles)", _mensajeError);
            }

         }
         catch (Exception ex)
         {
            MessageBox.Show("Error durante el proceso de Solicitud Volante: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
      private void btnEmitir_BL_Click(object sender, EventArgs e)
      {
         try
         {
            Delfin.Controls.EmailFiles EFiles = null;
            Nullable<Int32> _NVIA_Codigo = Presenter.Item.NVIA_Codigo;
            Nullable<Int32> _CCOT_Numero = Presenter.Item.CCOT_Numero;
            String _nombre_nave = Presenter.Item.ItemNaveViaje.NAVE_Nombre;
            String _numero_viaje = Presenter.Item.ItemNaveViaje.NVIA_NroViaje;
            String _correo_operaciones = Presenter.PARA_CORREOOPERACIONES.PARA_Valor;
            Presenter.CorreoEmitirHBL(_NVIA_Codigo, _CCOT_Numero);
            EFiles = new Controls.EmailFiles();
            String _mensaje = EFiles.CorreoEmitirHBL(Presenter.DtEmisionCorreoHBL, _correo_operaciones, _nombre_nave, _numero_viaje);
            if (!String.IsNullOrEmpty(_mensaje))
            {
               if (_mensaje.Substring(0, 1) == "#")
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE EMITIR HBL (Ver Detalles)", _mensaje); }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
            }
            else
            {
               Presenter.GenerarEventosTareas("Se ha generado la Emisión de HBL", Presenter.PARA_EMISIONHBL.PARA_Valor, Presenter.Item.CCOT_Numero, Presenter.Item.CCOT_Tipo);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error durante el proceso del Envío del Correo: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
      public bool IsValidEmail(string email)
      {
          if (email.Trim() == "")
          { return false; }
          //return Regex.IsMatch(email, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*[-\\.\\w]*[-\\.\\w]@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");
          return true;
      }
      private void btn_Aviso_Click(object sender, EventArgs e)
      {
         try
         {
            string _mensajeError = string.Empty;
            string _correo_ope = Presenter.PARA_CORREOOPERACIONES == null ? null : Presenter.PARA_CORREOOPERACIONES.PARA_Valor;
            string _correo_log = Presenter.PARA_CORREOLOGISTICA == null ? null : Presenter.PARA_CORREOLOGISTICA.PARA_Valor;
            Presenter.CartasAvisos(Presenter.Item.NVIA_Codigo, Presenter.Item.CCOT_Numero);
            if (Presenter.DtAvisos != null && Presenter.DtAvisos.Rows.Count > 0)
            {
               Delfin.Controls.Utils.checkMail("Operaciones", _correo_ope, ref _mensajeError);
               Delfin.Controls.Utils.checkMail("Logística", _correo_log, ref _mensajeError);
               foreach (DataRow drAvisos in Presenter.DtAvisos.Rows)
               {
                  //Delfin.Controls.Utils.checkMail(Convert.ToString(drAvisos["ENTC_NomCliente"]), Convert.ToString(drAvisos["ENTC_EMailCliente"]), ref _mensajeError);
                   if (!IsValidEmail(drAvisos["ENTC_EmailCliente"].ToString()))
                   {
                       _mensajeError = "El correo " + drAvisos["ENTC_EmailCliente"].ToString() + " de " + drAvisos["ENTC_NomCliente"].ToString() + " no tiene el formato correcto.";
                   }
                  Delfin.Controls.Utils.checkMail(Convert.ToString(drAvisos["ENTC_NomCustomer"]), Convert.ToString(drAvisos["ENTC_EmailCustomer"]), ref _mensajeError);
                  Delfin.Controls.Utils.checkMail(Convert.ToString(drAvisos["ENTC_NomEjecutivo"]), Convert.ToString(drAvisos["ENTC_EmailEjecutivo"]), ref _mensajeError);
               }
            }
            if (string.IsNullOrEmpty(_mensajeError))
            {
               //########## PARAMETROS ##########
               Delfin.Controls.EmailFiles EFiles = null;
               String _cons_tabrgm = Presenter.Item.CONS_TabRGM;
               String _cons_codrgm = Presenter.Item.CONS_CodRGM;
               String _cons_tabvia = Presenter.Item.CONS_TabVia;
               String _cons_codvia = Presenter.Item.CONS_CodVia;
               String _transportista = Presenter.Item.ENTC_NomTransportista;
               String _vobo1 = String.Empty;
               String _vobo2 = String.Empty;
               switch (Presenter.Item.CONS_CodRGM)
               {
                  case Delfin.Controls.variables.CONSRGM_Exportacion:
                     _vobo1 = Presenter.Item.ItemNaveViaje.ENTC_NomAgente;
                     _vobo2 = String.Empty;
                     break;
                  case Delfin.Controls.variables.CONSRGM_Importacion:
                     _vobo1 = Presenter.Item.ItemNaveViaje.ENTC_NomAgent1;
                     _vobo2 = Presenter.Item.ItemNaveViaje.ENTC_NomAgent2;
                     break;
               }
               String _nombre_nave = Presenter.Item.ItemNaveViaje.NAVE_Nombre;
               String _numero_viaje = Presenter.Item.ItemNaveViaje.NVIA_NroViaje;
               Nullable<DateTime> _fec_eta_etd = Presenter.Item.ItemNaveViaje.NVIA_FecETA_IMPO_ETD_EXPO;
               Nullable<DateTime> _fec_llegada_zarpe = Presenter.Item.ItemNaveViaje.NVIA_FecLlega_IMPO_Zarpe_EXPO;
               Nullable<DateTime> _fec_recogo_docs = Presenter.Item.ItemNaveViaje.ENTC_FecRecogerDocs;
               Nullable<DateTime> _fec_cierre_dir = Presenter.Item.ItemNaveViaje.NVIA_FecCierreDire_IMPO_TermEmba_EXPO;
               //################################

               EFiles = new Controls.EmailFiles();
               String _mensaje = EFiles.Avisos(Presenter.DtAvisos, _cons_tabrgm, _cons_codrgm, _cons_tabvia, _cons_codvia, _transportista, _vobo1, _vobo2, _nombre_nave, _numero_viaje, _fec_eta_etd, _fec_llegada_zarpe, _fec_recogo_docs, _fec_cierre_dir, _correo_ope, _correo_log);
               if (!String.IsNullOrEmpty(_mensaje))
               {
                  if (_mensaje.Substring(0, 1) == "#")
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE AVISOS (Ver Detalles)", _mensaje); }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
               }
               else
               {
                  Presenter.GenerarEventosTareas("Se ha generado el correo Aviso de Llegada o Salida de la Orden de Venta", Presenter.PARA_CARTAAVISOS.PARA_Valor, Presenter.Item.CCOT_Numero, Presenter.Item.CCOT_Tipo);
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Verifique los siguientes Correos Electronicos (detalles)", _mensajeError); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al generar el Aviso", ex); }
      }
      private void btnCargoManifest_Click(object sender, EventArgs e)
      {
         try
         {
            Presenter.GenerarCargoManifest();
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error durante la generacion de Cargo Manifiest: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
      #endregion
      #endregion

      #region [ Eventos ]
      private void EndEditGrids()
      {
         try
         {
            grdItemsFlete.EndEdit();
            grdItemsServicio.EndEdit();
            grdItemsServiciosChangeControl.EndEdit();
            grdDet_CNTR.EndEdit();
         }
         catch (Exception)
         { }
      }
      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            EndEditGrids();
            Boolean EsProspecto = (txaENTC_CodCliente.Value != null && txaENTC_CodCliente.Value.ENTC_Prospecto.HasValue) ? txaENTC_CodCliente.Value.ENTC_Prospecto.Value : false;
            if (Presenter.Guardar(EsProspecto, true))
            {
               //this.FormClosing -= MView_FormClosing;
               //errorProviderCab_Cotizacion_OV.Dispose();
               //Presenter.Actualizar();
               //this.Close();
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex);
         }
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            Boolean EsProspecto = (txaENTC_CodCliente.Value != null && txaENTC_CodCliente.Value.ENTC_Prospecto.HasValue) ? txaENTC_CodCliente.Value.ENTC_Prospecto.Value : false;

            this.FormClosing -= MView_FormClosing;
            errorProviderCab_Cotizacion_OV.Dispose();
            if ((Presenter.Item.CONS_CodEST != "007") && (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))) 
            {
               EndEditGrids();
               if (Presenter.GuardarCambios(EsProspecto) != System.Windows.Forms.DialogResult.Cancel)
               {
                  this.Close();
               }
               else
               {
                  this.FormClosing += MView_FormClosing;
               }
            }
            else
            {
               this.Close();
            }
            Closing = true;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex);
         }
      }
      private void btnCMBL_Numero_Click(object sender, EventArgs e)
      {
         Presenter.MostrarMBL();
      }
      private void btnDocumentada_Click(object sender, EventArgs e)
      {
         Presenter.Documentada();
      }
      private void btnPrefacturar_Click(object sender, EventArgs e)
      {
         Presenter.PreFacturar();
      }
      private void btnGuiaAerea_Click(object sender, EventArgs e)
      {
         try
         {
            Presenter.ImprimirGuiaAerea(txaENTC_CodShipper.Value, txaENTC_CodConsignee.Value, txaENTC_CodAgente.Value, txaENTC_CodTransportista.Value, Presenter.ItemEmpresa, txaPUER_CodOrigen.SelectedItem, txaPUER_CodDestino.SelectedItem, (Entities.NaveViaje)txaNVIA_Codigo.Value, txtDDOV_DescShipper.Text, txtDDOV_DescConsignee.Text);
         }
         catch (Exception)
         { }
      }
      private void btnEtiqueta_Click(object sender, EventArgs e)
      {
         try
         {
            Presenter.ImprimirEtiquetas();
         }
         catch (Exception)
         { }
      }

      private void txaENTC_CodEjecutivo_AyudaValueChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaENTC_CodEjecutivo.Value != null && txaENTC_CodEjecutivo.Value.ENTC_Propio.HasValue)
            {
               chkCCOT_Propia.Checked = txaENTC_CodEjecutivo.Value.ENTC_Propio.Value;
            }
            else
            {
               chkCCOT_Propia.Checked = false;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el Ejecutivo.", ex);
         }
      }
      private void txaENTC_CodTransportista_AyudaValueChanged(object sender, EventArgs e)
      {
         try
         {
            SetServiciosLinea();
            if (txaENTC_CodTransportista.Value != null && !String.IsNullOrEmpty(txaENTC_CodTransportista.Value.CONS_CodTFT))
            { cmbCONS_CodTFT.ConstantesSelectedValue = txaENTC_CodTransportista.Value.CONS_CodTFT; }
            else
            { cmbCONS_CodTFT.ConstantesSelectedValue = null; }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el Transportista.", ex);
         }
      }
      private void txaENTC_CodCliente_AyudaValueChanged(object sender, EventArgs e)
      {
         //SetItemContacto();
         SetDatosAdicionalesCliente();
         SetRelacionadosCliente();
      }

      private void CONS_CodRGM_SelectedIndexChanged(object sender, EventArgs e)
      {
         //SetItemContacto();
         EstablecerLineaNegocio();
         SetRelacionadosCliente();
         SetNaveViajeRegimen();
         ConfigureServicios();
      }
      private void CONS_CodVia_SelectedIndexChanged(object sender, EventArgs e)
      {
         EstablecerLineaNegocio();
         ConfigureServicios();
      }
      private void cmbCONS_CodLNG_SelectedIndexChanged(object sender, EventArgs e)
      {
         ConfigureServicios();

         SetServiciosCliente();
         SetServiciosAgente();
         SetServiciosLinea();
      }

      private void txaPUER_CodOrigen_SelectedItemChanged(object sender, EventArgs e)
      {
         try
         {
            EstablecerLineaNegocio();
            if (cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
            {
               if (cmbTIPO_CodTRF.TiposSelectedItem == null)
               {
                  if (txaPUER_CodOrigen.SelectedItem != null)
                  { cmbTIPO_CodTRF.TiposSelectedValue = txaPUER_CodOrigen.SelectedItem.TIPO_CodTRF; }
                  else
                  { cmbTIPO_CodTRF.TiposSelectedValue = null; }
               }
            }
         }
         catch (Exception)
         { }
      }
      private void txaPUER_CodDestino_SelectedItemChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbCONS_CodRGM.ConstantesSelectedItem != null && cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Exportacion)
            {
               if (cmbTIPO_CodTRF.TiposSelectedItem == null)
               {
                  if (txaPUER_CodDestino.SelectedItem != null)
                  { cmbTIPO_CodTRF.TiposSelectedValue = txaPUER_CodDestino.SelectedItem.TIPO_CodTRF; }
                  else
                  { cmbTIPO_CodTRF.TiposSelectedValue = null; }
               }
            }
         }
         catch (Exception)
         { }
      }

      private void btnNuevoContacto_Click(object sender, EventArgs e)
      {
         NuevoContacto();
      }
      private void btnEditarContacto_Click(object sender, EventArgs e)
      {
         EditarContacto();
      }

      private void chkCCOT_Bloqueado_CheckedChanged(object sender, EventArgs e)
      {
         if (chkCCOT_Bloqueado.Checked)
         {
            chkCCOT_ConExcepcion.Checked = false;
            chkCCOT_ConExcepcion.Enabled = false;
         }
      }
      private void chkCCOT_ConExcepcion_CheckedChanged(object sender, EventArgs e)
      {
         if (chkCCOT_ConExcepcion.Checked)
         {
            chkCCOT_Bloqueado.Checked = false;
            chkCCOT_Bloqueado.Enabled = false;
         }
      }
      private void chkCCOT_CargaPeligrosa_CheckedChanged(object sender, EventArgs e)
      {
         try
         {
            if (!chkCCOT_CargaPeligrosa.Checked)
            {
               cmbTIPO_CodIMO.TiposSelectedValue = null;
               txtCCOT_ImoUN.Text = String.Empty;

               foreach (Telerik.WinControls.UI.GridViewRowInfo _Det_CNTR in grdDet_CNTR.Rows)
               {
                  _Det_CNTR.Cells["DHBL_EsIMO"].Value = false;
                  _Det_CNTR.Cells["TIPO_TabIMO"].Value = null;
                  _Det_CNTR.Cells["TIPO_CodIMO"].Value = null;
                  _Det_CNTR.Cells["DHBL_ImoUN"].Value = null;
               }
            }

            cmbTIPO_CodIMO.Enabled = chkCCOT_CargaPeligrosa.Checked;
            txtCCOT_ImoUN.Enabled = chkCCOT_CargaPeligrosa.Checked;
         }
         catch (Exception)
         { }
      }

      private void CONS_CodFLE_SelectedIndexChanged(object sender, EventArgs e)
      {
         ConfigureGridFlete();
      }
      private void btnAddFlete_Click(object sender, EventArgs e)
      {
         AddFlete();
      }
      private void btnDelFlete_Click(object sender, EventArgs e)
      {
         DelFlete();
      }
      private void grdItemsFlete_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
      {
         //if (e.Column.Name == "PACK_Codigo")
         //{ ConsultarTarifario(e.RowIndex); }
         //else if (e.Column.Name == "DCOT_PrecioUniCosto")
         //{ CalcularTotalesFlete(); }
         //else if (e.Column.Name == "DCOT_PrecioUniVenta")
         //{ CalcularTotalesFlete(); }
         //else if (e.Column.Name == "DCOT_Cantidad")
         //{ ActualizarCantidadesServicio(); }

         try
         {
            if (e.Column.Name == "PACK_Codigo")
            {
               if (BSItemsFlete != null && BSItemsFlete.DataSource != null && (BSItemsFlete.DataSource is ObservableCollection<Entities.Det_Cotizacion_OV_Flete>) && (BSItemsFlete.DataSource as ObservableCollection<Entities.Det_Cotizacion_OV_Flete>).Count > 0)
               {
                  var _listPaquetes = (from pack in Presenter.ListPaquetes
                                       join flete in (BSItemsFlete.DataSource as ObservableCollection<Entities.Det_Cotizacion_OV_Flete>) on pack.PACK_Codigo equals flete.PACK_Codigo
                                       select pack).ToObservableCollection();

                  (grdDet_CNTR.Columns["PACK_Codigo"] as Telerik.WinControls.UI.GridViewComboBoxColumn).DataSource = _listPaquetes.OrderBy(pack => pack.PACK_DescC).ToObservableCollection();
               }
               else
               {
                  (grdDet_CNTR.Columns["PACK_Codigo"] as Telerik.WinControls.UI.GridViewComboBoxColumn).DataSource = Presenter.ListPaquetes;
               }

               if (grdItemsFlete.Rows[e.RowIndex].DataBoundItem != null && grdItemsFlete.Rows[e.RowIndex].DataBoundItem is Entities.Det_Cotizacion_OV_Flete && Presenter.ListPaquetes.Where(pack => pack.PACK_Codigo == (grdItemsFlete.Rows[e.RowIndex].DataBoundItem as Entities.Det_Cotizacion_OV_Flete).PACK_Codigo).FirstOrDefault() != null)
               {
                  (grdItemsFlete.Rows[e.RowIndex].DataBoundItem as Entities.Det_Cotizacion_OV_Flete).PACK_Desc = Presenter.ListPaquetes.Where(pack => pack.PACK_Codigo == (grdItemsFlete.Rows[e.RowIndex].DataBoundItem as Entities.Det_Cotizacion_OV_Flete).PACK_Codigo).FirstOrDefault().PACK_Desc;
                  (grdItemsFlete.Rows[e.RowIndex].DataBoundItem as Entities.Det_Cotizacion_OV_Flete).PACK_DescC = Presenter.ListPaquetes.Where(pack => pack.PACK_Codigo == (grdItemsFlete.Rows[e.RowIndex].DataBoundItem as Entities.Det_Cotizacion_OV_Flete).PACK_Codigo).FirstOrDefault().PACK_DescC;
               }
            }
         }
         catch (Exception) { }
      }

      private void grdItemsArchivos_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            String _texto = "";

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

               switch ((sender as Telerik.WinControls.UI.GridCommandCellElement).ColumnInfo.Name)
               {
                  case "OVAR_DescripcionPopUp":
                     SeleccionarItemFile();

                     _texto = grdItemsArchivos.CurrentRow.Cells["OVAR_Observacion"].Value != null ? grdItemsArchivos.CurrentRow.Cells["OVAR_Observacion"].Value.ToString() : "";
                     OPE001TView _viewText = new OPE001TView("Observaciones del Archivo", _texto, 1000, grdItemsArchivos.CurrentRow.Cells["OVAR_Observacion"].ReadOnly);
                     _viewText.ShowDialog();
                     if (!grdItemsArchivos.CurrentRow.Cells["OVAR_Observacion"].ReadOnly)
                     { grdItemsArchivos.CurrentRow.Cells["OVAR_Observacion"].Value = _viewText.Texto; }

                     _viewText.Dispose();
                     _viewText = null;
                     break;
               }

            }

         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex);
         }

      }


      private void MView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            Boolean EsProspecto = (txaENTC_CodCliente.Value != null && txaENTC_CodCliente.Value.ENTC_Prospecto.HasValue) ? txaENTC_CodCliente.Value.ENTC_Prospecto.Value : false;

            if (Closing != true)
            {
               this.FormClosing -= MView_FormClosing;
               if ((Presenter.Item.CONS_CodEST != "007") &&  (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario)))
               {
                  if (Presenter.GuardarCambios(EsProspecto) == System.Windows.Forms.DialogResult.Cancel)
                  {
                     e.Cancel = true;
                     this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
                  }
                  else
                  {
                     Presenter.Actualizar();
                  }
               }
               else
               {
                  Presenter.Actualizar();
               }
            }
            else
            {
               Closing = false;
               e.Cancel = true;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex);
         }
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

      #region [ Auditoria ]
      private void btnAuditoriaCab_Cotizacion_OV_Click(object sender, EventArgs e)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinCCOT_Tipo", FilterValue = Presenter.Item.CCOT_Tipo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintCCOT_Numero", FilterValue = Presenter.Item.CCOT_Numero, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

            Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.AUDI_COM_Cab_Cotizacion_OV, _filters);
            _auditoriaView.Show();
         }
         catch (Exception)
         { }
      }
      private void btnAuditoriaDet_Cotizacion_OV_Flete_Click(object sender, EventArgs e)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinCCOT_Tipo", FilterValue = Presenter.Item.CCOT_Tipo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintCCOT_Numero", FilterValue = Presenter.Item.CCOT_Numero, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

            Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.AUDI_COM_Det_Cotizacion_OV_Flete, _filters);
            _auditoriaView.Show();
         }
         catch (Exception)
         { }
      }
      private void btnAuditoriaDet_Cotizacion_OV_Servicio_Click(object sender, EventArgs e)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinCCOT_Tipo", FilterValue = Presenter.Item.CCOT_Tipo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintCCOT_Numero", FilterValue = Presenter.Item.CCOT_Numero, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitSCOT_ChangeControl", FilterValue = false, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

            Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.AUDI_COM_Det_Cotizacion_OV_Servicios, _filters);
            _auditoriaView.Show();
         }
         catch (Exception)
         { }
      }
      private void btnAuditoriaDet_Cotizacion_OV_Servicio_ChangeControl_Click(object sender, EventArgs e)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinCCOT_Tipo", FilterValue = Presenter.Item.CCOT_Tipo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintCCOT_Numero", FilterValue = Presenter.Item.CCOT_Numero, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitSCOT_ChangeControl", FilterValue = true, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

            Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.AUDI_COM_Det_Cotizacion_OV_Servicios, _filters);
            _auditoriaView.Show();
         }
         catch (Exception)
         { }
      }
      private void btnAuditoriaDet_Cotizacion_OV_EventosTareas_Click(object sender, EventArgs e)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinCCOT_Tipo", FilterValue = Presenter.Item.CCOT_Tipo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintCCOT_Numero", FilterValue = Presenter.Item.CCOT_Numero, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

            Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.AUDI_COM_Det_Cotizacion_OV_EventosTareas, _filters);
            _auditoriaView.Show();
         }
         catch (Exception)
         { }
      }
      private void btnAuditoriaOPE_Det_CNTR_Click(object sender, EventArgs e)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinCCOT_Tipo", FilterValue = Presenter.Item.CCOT_Tipo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintCCOT_Numero", FilterValue = Presenter.Item.CCOT_Numero, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

            Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.AUDI_OPE_Det_CNTR, _filters);
            _auditoriaView.Show();
         }
         catch (Exception)
         { }
      }
      #endregion

      private void OPE001MView_Load_1(object sender, EventArgs e)
      {

      }

      private void tabCab_Cotizacion_OV_SelectedIndexChanged(object sender, EventArgs e)
      {
          if (tabCab_Cotizacion_OV.SelectedIndex == 2)
          { tabDatosEmbarque.SelectedIndex = 0; }
          if (tabCab_Cotizacion_OV.SelectedIndex == 4)
          { tabControlEX1.SelectedIndex = 1; }
      }

      private void btnShowFileStream_Click(object sender, EventArgs e)
      {
          ShowFileStream();
      }
   }
}