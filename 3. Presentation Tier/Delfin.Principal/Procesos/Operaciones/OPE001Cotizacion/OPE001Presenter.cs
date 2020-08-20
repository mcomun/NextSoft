using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Aspect;
using Infrastructure.Aspect.Collections;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using System.IO;

using System.Configuration;
using System.Net;
using System.Runtime.Serialization.Json;

using Infrastructure.Aspect.DataAccess;
using Delfin.Principal.Reportes;
using XLExcel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace Delfin.Principal
{
   public partial class OPE001Presenter
   {
      #region [ Variables ]
      public String Title = "Orden de Venta";
      public String CUS = "OPE001";
      public Boolean FleteNegativo = false;

      private Cab_Cotizacion_OV m_item;
      private Cab_Cotizacion_OV m_itemLView;
      #endregion

      #region [ Contrusctor ]
      public OPE001Presenter(IUnityContainer x_container, IOPE001MView x_mview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.MView = x_mview;
         }
         catch (Exception)
         { throw; }
      }
      public OPE001Presenter(IUnityContainer x_container, IOPE001LView x_lview, IOPE001MView x_mview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
            this.MView = x_mview;
         }
         catch (Exception)
         { throw; }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();

            LoadProcesosUsuario();

            //ListPuertos = Client.GetAllPuerto();
            ListPaquetes = Client.GetAllPaquete();
            ListTiposCDT = Client.GetAllTiposByTipoCodTabla("CDT");
            ListTiposUNM = Client.GetAllTiposByTipoCodTabla("UNM");
            ListTiposMND = Client.GetAllTiposByTipoCodTabla("MND");
            ListTiposTDO = Client.GetAllTiposByTipoCodTabla("TDO");
            ListTiposEVE = Client.GetAllTiposByTipoCodTabla("EVE");
            ListTiposPAC = Client.GetAllTiposByTipoCodTabla("PAC");
            ListTiposIMO = Client.GetAllTiposByTipoCodTabla("IMO");
            //ListServicio = Client.GetAllServicio();
            ListServicio = new ObservableCollection<Servicio>();

            ListTiposEntidad = Client.GetAllTiposEntidad();

            ListConstantesBAS = Client.GetAllConstantesByConstanteTabla("BAS");
            ListConstantesMOD = Client.GetAllConstantesByConstanteTabla("MOD");

            Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.AddComboBoxItem("I", "Ingreso", true);
            Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.AddComboBoxItem("E", "Egreso");
            ListIngresoEgreso = Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.GetComboBoxItems();

            Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.AddComboBoxItem("L", "Origen", true);
            Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.AddComboBoxItem("D", "Destino");
            ListOrigen = Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.GetComboBoxItems();


            #region [ Parametros ]
            LoadParameteres();
            #endregion

            Empresa();

            if (LView != null) { LView.LoadView(); }
            MView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }


      public IOPE001LView LView { get; set; }
      public IOPE001MView MView { get; set; }

      public Cab_Cotizacion_OV ItemLView
      {
         get
         {
            if (m_itemLView == null) { m_itemLView = new Cab_Cotizacion_OV(); }
            return m_itemLView;
         }
         set { m_itemLView = value; }
      }
      public Cab_Cotizacion_OV Item
      {
         get
         {
            if (m_item == null) { m_item = new Cab_Cotizacion_OV(); }
            return m_item;
         }
         set { m_item = value; }
      }
      public ObservableCollection<Cab_Cotizacion_OV> Items { get; set; }

      //public ObservableCollection<Puerto> ListPuertos { get; set; }
      public ObservableCollection<Paquete> ListPaquetes { get; set; }
      public ObservableCollection<Tipos> ListTiposCDT { get; set; }
      public ObservableCollection<Tipos> ListTiposUNM { get; set; }
      public ObservableCollection<Tipos> ListTiposMND { get; set; }
      public ObservableCollection<Tipos> ListTiposEVE { get; set; }
      public ObservableCollection<Tipos> ListTiposTDO { get; set; }
      public ObservableCollection<Tipos> ListTiposPAC { get; set; }
      public ObservableCollection<Tipos> ListTiposIMO { get; set; }
      public ObservableCollection<Constantes> ListConstantesBAS { get; set; }
      public ObservableCollection<Constantes> ListConstantesMOD { get; set; }
      public ObservableCollection<Servicio> ListServicio { get; set; }
      public ObservableCollection<Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem> ListIngresoEgreso { get; set; }
      public ObservableCollection<Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem> ListOrigen { get; set; }

      public ObservableCollection<TiposEntidad> ListTiposEntidad { get; set; }

      //############## CORREOS & ARCHIVOS ###################
      public System.Data.DataTable DtDireciomaniento = new System.Data.DataTable(); // CARTA DE CAMBIO DE ALMACEN(DIRECCIONAMIENTO)
      public System.Data.DataTable DtVoBo = new System.Data.DataTable(); // CARTA DE DESGLOSE DE VoBo
      public System.Data.DataTable DtCargaTarjada = new System.Data.DataTable(); // CORREO CARGA TARJADA
      public System.Data.DataTable DtEmisionCorreoHBL = new System.Data.DataTable();// EMISION DE BL
      public System.Data.DataTable DtAvisos = new System.Data.DataTable();
      public Entidad ItemEmpresa { get; set; }
      public ObservableCollection<Det_Cotizacion_OV_EventosTareas> ItemsEventosTareas { get; set; }
      public Det_Cotizacion_OV_EventosTareas ItemEventoTarea { get; set; }
      //#####################################################


      public Boolean OVCONCLUIDA { get; set; }
      public Boolean OVDOCUMENTADA { get; set; }
      public Boolean OVSOLOLECTURA { get; set; }
      public Boolean OVEDITARCOSTO { get; set; }
      #endregion

      #region [ Parámetros ]
      public Entities.Parametros PARA_OVDOCUMENTADA { get; set; }

      public Entities.Parametros PARA_RELEASEHBL { get; set; }
      public Entities.Parametros PARA_IMPRIMIRHBL { get; set; }

      public Entities.Parametros PARA_BLOQUEAROV { get; set; }
      public Entities.Parametros PARA_DESBLOQUEAROV { get; set; }
      public Entities.Parametros PARA_AGREGAREXCEPCIONOV { get; set; }
      public Entities.Parametros PARA_QUITAREXCEPCIONOV { get; set; }

      public Entities.Parametros PARA_CODIGOCOSCO { get; set; }
      public Entities.Parametros PARA_CORREOOPERACIONES { get; set; }
      public Entities.Parametros PARA_CORREOLOGISTICA { get; set; }
      public Entities.Parametros PARA_CODIGOTRAMARSA { get; set; }
      public Entities.Parametros PARA_CODIGOEMPRESA { get; set; } //Empresa de DELFIN GROUP PERU 

      public Entities.Parametros PARA_EAGENTE_SHANGHAI { get; set; }
      public Entities.Parametros PARA_PAIS_MANDATO { get; set; }

      //####### EVENTOS #######
      public Entities.Parametros PARA_DIRECCIONAMIENTOLINEA { get; set; }
      public Entities.Parametros PARA_DESGLOSEVoBo { get; set; }
      public Entities.Parametros PARA_CARTAAVISOS { get; set; }
      public Entities.Parametros PARA_DEVOLUCIONMASTER { get; set; }
      public Entities.Parametros PARA_RECOJOBLs { get; set; }
      public Entities.Parametros PARA_SERVICIOTRANSMISION { get; set; }
      public Entities.Parametros PARA_EMISIONHBL { get; set; }
      //#######################

      private void LoadParameteres()
      {
         try
         {
            var ItemsPARAMETRO = Client.GetAllParametros();

            PARA_OVDOCUMENTADA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "OVDOCUMENTADA");

            PARA_RELEASEHBL = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "RELEASEHBL");
            PARA_IMPRIMIRHBL = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "IMPRIMIRHBL");

            PARA_BLOQUEAROV = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "BLOQUEAROV");
            PARA_DESBLOQUEAROV = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "DESBLOQUEAROV");
            PARA_AGREGAREXCEPCIONOV = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "AGREGAREXCEPCIONOV");
            PARA_QUITAREXCEPCIONOV = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "QUITAREXCEPCIONOV");

            PARA_CODIGOCOSCO = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CODIGO_COSCO_PERU");
            PARA_CORREOOPERACIONES = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CORREO_OPERACIONES");
            PARA_CORREOLOGISTICA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CORREO_LOGISTICA");
            PARA_CODIGOTRAMARSA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CODIGO_TRAMARSA");
            PARA_CODIGOEMPRESA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "EMPRESA");

            PARA_EAGENTE_SHANGHAI = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "EAGENTE_SHANGHAI");
            PARA_PAIS_MANDATO = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "PAIS_MANDATO");
            //####### EVENTOS #######
            PARA_DIRECCIONAMIENTOLINEA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "DIRECCIONALINEA");
            PARA_DESGLOSEVoBo = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "DESGLOSEVoBo");
            PARA_CARTAAVISOS = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CARTA_AVISOS");
            PARA_DEVOLUCIONMASTER = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "DEVOLUCION_MASTER");
            PARA_RECOJOBLs = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "RECOJO_BLs");
            PARA_SERVICIOTRANSMISION = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "SERVICIO_TRANSMISION");
            PARA_EMISIONHBL = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "EMISION_HBL");
            //#######################
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos ]

      private ObservableCollection<DataAccessFilterSQL> m_listFilters;

      public ObservableCollection<DataAccessFilterSQL> ListFilters
      {
         get
         {
            if (m_listFilters == null) { m_listFilters = new ObservableCollection<DataAccessFilterSQL>(); }
            return m_listFilters;
         }
         set { m_listFilters = value; }
      }

      public void Actualizar()
      {
         try
         {
            ItemLView = null;
            Items = null;

            if (LView != null)
            {
               if (OVCONCLUIDA || OVDOCUMENTADA || OVSOLOLECTURA)
               {
                  Items = Client.OPE_GetAllCab_Cotizacion_OVFilter(null, ListFilters);

                  LView.ShowItems();
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe tener asignado unos de los procesos para poder visualizar y/o editar la OV (Comuníquese con el administrador del sistema)."); }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      public void LoadServicios(String CONS_TabRGM, String CONS_CodRGM, String CONS_TabVia, String CONS_CodVia, String CONS_TabLNG, String CONS_CodLNG)
      {
         try
         {
            if (!String.IsNullOrEmpty(CONS_TabVia) && !String.IsNullOrEmpty(CONS_CodVia) && !String.IsNullOrEmpty(CONS_TabRGM) && !String.IsNullOrEmpty(CONS_CodRGM) && !String.IsNullOrEmpty(CONS_TabLNG) && !String.IsNullOrEmpty(CONS_CodLNG))
            { ListServicio = Client.GetAllServicioByViaRegimen(CONS_TabVia, CONS_CodVia, CONS_TabRGM, CONS_CodRGM, CONS_TabLNG, CONS_CodLNG); }
            else
            { ListServicio = new ObservableCollection<Servicio>(); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando los servicios.", ex); }
      }

      Boolean isMViewShow = false;
      public void Nuevo()
      {
         try
         {
            if (!isMViewShow)
            {
               MView = new OPE001MView();
               MView.Presenter = this;
               MView.LoadView();
            }

            MView.ClearItem();
            this.Item = new Cab_Cotizacion_OV();
            this.Item.CCOT_Version = 1;
            this.Item.CONS_TabEST = "OVE";
            this.Item.CONS_CodEST = "001";
            this.Item.CCOT_FecEmi = Session.Fecha;
            this.Item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            this.Item.SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
            this.Item.AUDI_UsrCrea = Session.UserName;
            this.Item.AUDI_FecCrea = Session.Fecha;
            this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            MView.SetItem();

            MView.SelectTab(1);

            isMViewShow = true;
            ((OPE001MView)MView).Show();
            ((OPE001MView)MView).BringToFront();

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }
      public void Editar()
      {
         try
         {
            if (!isMViewShow)
            {
               MView = new OPE001MView();
               MView.Presenter = this;
               MView.LoadView();
            }

            if (OVCONCLUIDA || OVDOCUMENTADA || OVSOLOLECTURA)
            {
               if (ItemLView != null)
               {

                  Item = Client.OPE_GetOneCab_Cotizacion_OV(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, ItemLView.CCOT_Tipo, ItemLView.CCOT_Numero);

                  if (Item != null)
                  {
                     //Det_CNTR si tuviese nuevos contenedores
                     Int32 _DHBL_ItemMax = 1;
                     if (Item.ItemsDet_CNTR.Where(cntr => cntr.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added).Count() > 0)
                     { _DHBL_ItemMax = Item.ItemsDet_CNTR.Where(cntr => cntr.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added).Max(cntr => cntr.DHBL_Item.Value) + 1; }

                     foreach (Entities.Det_CNTR _itemDet_CNTR in Item.ItemsDet_CNTR.Where(cntr => cntr.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added))
                     {
                        _itemDet_CNTR.DHBL_Item = _DHBL_ItemMax;
                        _itemDet_CNTR.AUDI_UsrCrea = Session.UserName;
                        _itemDet_CNTR.AUDI_FecCrea = Session.Fecha;
                        _DHBL_ItemMax += 1;
                     }

                     MView.ClearItem();
                     this.Item.AUDI_UsrMod = Session.UserName;
                     this.Item.AUDI_FecMod = Session.Fecha;
                     this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                     MView.SetItem();

                     MView.SelectTab(1);

                     isMViewShow = true;
                     ((OPE001MView)MView).Show();
                     ((OPE001MView)MView).BringToFront();
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe tener asignado unos de los procesos para poder visualizar y/o editar la OV (Comuníquese con el administrador del sistema)."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }
      public void Anular()
      {
         try
         {
            if (this.ItemLView != null)
            {
               if (ItemLView.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion)
               {
                  if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea Anular la Cotización Seleccionada?", null) == System.Windows.Forms.DialogResult.OK)
                  {

                     //Item = Client.GetOneCab_Cotizacion_OV(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, Item.CCOT_Numero, Item.CCOT_Tipo);
                     //this.Item.CONS_TabEST = "COT";
                     //this.Item.CONS_CodEST = Delfin.Controls.variables.CONS_ESTCOTANULADA;
                     //this.Item.AUDI_UsrMod = Session.UserName;
                     //this.Item.AUDI_FecMod = Session.Fecha;
                     //this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;

                     Int16 CCOT_Tipo = ItemLView.CCOT_Tipo;
                     Int32 CCOT_Numero = ItemLView.CCOT_Numero;
                     String CONS_TabEST = "COT";
                     String CONS_CodEST = Delfin.Controls.variables.CONS_ESTCOTANULADA;
                     String Usuario = Session.UserName;
                     DateTime Fecha = Session.Fecha;
                     String CCOT_MensajeError = "";

                     if (Client.SaveCab_Cotizacion_OVEstado(CCOT_Tipo, CCOT_Numero, CONS_TabEST, CONS_CodEST, Usuario, Fecha, ref CCOT_MensajeError))
                     {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha anulado satisfactoriamente");
                        Actualizar();
                     }
                     else
                     { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al anular la Cotización."); }
                  }
               }
               else if (ItemLView.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
               {
                  if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea Anular la Orden de Venta Seleccionada?", null) == System.Windows.Forms.DialogResult.OK)
                  {
                     //Item = Client.GetOneCab_Cotizacion_OV(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, Item.CCOT_Numero, Item.CCOT_Tipo);
                     //this.Item.CONS_TabEST = "OVE";
                     //this.Item.CONS_CodEST = Delfin.Controls.variables.CONS_ESTOVEANULADA;
                     //this.Item.AUDI_UsrMod = Session.UserName;
                     //this.Item.AUDI_FecMod = Session.Fecha;
                     //this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;

                     Int16 CCOT_Tipo = ItemLView.CCOT_Tipo;
                     Int32 CCOT_Numero = ItemLView.CCOT_Numero;
                     String CONS_TabEST = "OVE";
                     String CONS_CodEST = Delfin.Controls.variables.CONS_ESTOVEANULADA;
                     String Usuario = Session.UserName;
                     DateTime Fecha = Session.Fecha;
                     String CCOT_MensajeError = "";

                     if (Client.SaveCab_Cotizacion_OVEstado(CCOT_Tipo, CCOT_Numero, CONS_TabEST, CONS_CodEST, Usuario, Fecha, ref CCOT_MensajeError))
                     {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha anulado satisfactoriamente");
                        Actualizar();
                     }
                     else
                     { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al anular la Orden de Venta."); }
                  }
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un item para poder aprobarlo."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al aprobar la Cotización", ex); }
      }
      public void Eliminar()
      {
         try
         {
            if (ItemLView != null)
            {
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  ItemLView.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                  String _mensajeError = "";
                  if (Client.OPE_SaveCab_Cotizacion_OV(ref m_itemLView, ref _mensajeError))
                  {
                     Actualizar();
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item."); }
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex); }
      }
      public bool Guardar(Boolean EsProspecto, Boolean ShowMessage, Boolean ValidarContenedores = true)
      {
         try
         {
            MView.GetItem();
            FleteNegativo = false;

            if (Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONCLUIDA) { ValidarContenedores = false; }

            if (Item.ValidarOperaciones(ref FleteNegativo, ValidarContenedores))
            {
               //if (Item.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion && (Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTCONFIRMADA || Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTANULADA))
               //{ return true; }
               //if (Item.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta && (Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONCLUIDA || Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEANULADA)) //Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONFIRMADA || 
               //{ return true; }

               //if (Item.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta && EsProspecto)
               //{
               //   Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe actualizar la información del Cliente para poder crearle una Orden de Venta.");
               //   return false; 
               //}
               //if (FleteNegativo == true)
               //{
               //    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "La Orden de Venta tiene un Profit Negativo.");
               //    //return true;
               //}

               Boolean m_isAdded = (Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added);
               String CCOT_MensajeError = "";

               if (Client.OPE_SaveCab_Cotizacion_OV(ref m_item, ref CCOT_MensajeError))
               {
                  Item = Client.OPE_GetOneCab_Cotizacion_OV(m_item.EMPR_Codigo.Value, m_item.SUCR_Codigo.Value, m_item.CCOT_Tipo, m_item.CCOT_Numero);

                  if (ShowMessage) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente"); }

                  //if (Item.CCOT_Tipo == 1 && Item.CONS_TabEST == "COT" && Item.CONS_CodEST == "001" && Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted)
                  //{ EnviarEmailCotizacion(Item, m_isAdded); }

                  //Editar();
                  //Actualizar();

                  MView.ClearItem();
                  this.Item.AUDI_UsrMod = Session.UserName;
                  this.Item.AUDI_FecMod = Session.Fecha;
                  this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                  MView.SetItem();

                  return true;
               }
               else
               {
                  if (String.IsNullOrEmpty(CCOT_MensajeError))
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                     return false;
                  }
                  else
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.", CCOT_MensajeError);
                     return false;
                  }

               }
            }
            else
            {
               //Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Se han encontrado algunos errores, revisar los detalles.", Item.MensajeError);
               MView.ShowValidation();
               return false;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
            return false;
         }
      }
      public System.Windows.Forms.DialogResult GuardarCambios(Boolean EsProspecto)
      {
         try
         {
            if (this.Item != null)
            {
               if (Item.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion && (Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTCONFIRMADA || Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTANULADA))
               { return System.Windows.Forms.DialogResult.No; }
               if (Item.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta && (Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONFIRMADA || Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONCLUIDA || Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEANULADA))
               { return System.Windows.Forms.DialogResult.No; }

               ((OPE001MView)MView).BringToFront();
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.SaveChangesPreguntaPresenter, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  if (Guardar(EsProspecto, true))
                  { return System.Windows.Forms.DialogResult.Yes; }
                  else
                  { return System.Windows.Forms.DialogResult.Cancel; }
               }
               else
               { return _result; }
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al cerrar el formulario.");
               return System.Windows.Forms.DialogResult.Cancel;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
            return System.Windows.Forms.DialogResult.Cancel;
         }
      }

      public void CloseView()
      {
         if (isMViewShow)
         { ((OPE001MView)MView).Close(); }
      }
      public void IsClosedMView()
      { isMViewShow = false; }

      public void LoadProcesosUsuario()
      {
         try
         {
            var BL_PermisosUsuarioProcesos = ContainerService.Resolve<NextAdmin.BusinessLogic.IBLPermisosUsuarioProcesos>();
            NextAdmin.BusinessLogic.PermisosUsuarioProcesos _premiso_OVCONCLUIDA = BL_PermisosUsuarioProcesos.GetOneByUsuario(Session.AplicacionCodigo.Value, Session.UserCodigo, Delfin.Controls.variables.CCOT_OVCONCLUIDA);
            if (_premiso_OVCONCLUIDA != null && _premiso_OVCONCLUIDA.PUPR_Codigo > 0)
            { OVCONCLUIDA = true; }
            else
            { OVCONCLUIDA = false; }

            BL_PermisosUsuarioProcesos = ContainerService.Resolve<NextAdmin.BusinessLogic.IBLPermisosUsuarioProcesos>();
            NextAdmin.BusinessLogic.PermisosUsuarioProcesos _premiso_OVDOCUMENTADA = BL_PermisosUsuarioProcesos.GetOneByUsuario(Session.AplicacionCodigo.Value, Session.UserCodigo, Delfin.Controls.variables.CCOT_OVDOCUMENTADA);
            if (_premiso_OVDOCUMENTADA != null && _premiso_OVDOCUMENTADA.PUPR_Codigo > 0)
            { OVDOCUMENTADA = true; }
            else
            { OVDOCUMENTADA = false; }

            BL_PermisosUsuarioProcesos = ContainerService.Resolve<NextAdmin.BusinessLogic.IBLPermisosUsuarioProcesos>();
            NextAdmin.BusinessLogic.PermisosUsuarioProcesos _premiso_OVSOLOLECTURA = BL_PermisosUsuarioProcesos.GetOneByUsuario(Session.AplicacionCodigo.Value, Session.UserCodigo, Delfin.Controls.variables.CCOT_OVSOLOLECTURA);
            if (_premiso_OVSOLOLECTURA != null && _premiso_OVSOLOLECTURA.PUPR_Codigo > 0)
            { OVSOLOLECTURA = true; }
            else
            { OVSOLOLECTURA = false; }

            BL_PermisosUsuarioProcesos = ContainerService.Resolve<NextAdmin.BusinessLogic.IBLPermisosUsuarioProcesos>();
            NextAdmin.BusinessLogic.PermisosUsuarioProcesos _premiso_OVEDITARCOSTO = BL_PermisosUsuarioProcesos.GetOneByUsuario(Session.AplicacionCodigo.Value, Session.UserCodigo, Delfin.Controls.variables.CCOT_OVEDITARCOSTO);
            if (_premiso_OVEDITARCOSTO != null && _premiso_OVEDITARCOSTO.PUPR_Codigo > 0)
            { OVEDITARCOSTO = true; }
            else
            { OVEDITARCOSTO = false; }
         }
         catch (Exception)
         { }
      }

      public Boolean VerificarPemisoEdicion()
      {
         try
         {
            var BL_PermisosUsuarioProcesos = ContainerService.Resolve<NextAdmin.BusinessLogic.IBLPermisosUsuarioProcesos>();
            NextAdmin.BusinessLogic.PermisosUsuarioProcesos _itemPermisosUsuarioProcesos = BL_PermisosUsuarioProcesos.GetOneByUsuario(Session.AplicacionCodigo.Value, Session.UserCodigo, Delfin.Controls.variables.CCOT_EDITARCOTIZ);
            if (_itemPermisosUsuarioProcesos != null && _itemPermisosUsuarioProcesos.PUPR_Codigo > 0)
            { return true; }
            else
            { return false; }
         }
         catch (Exception)
         { return false; }
      }

      public void Documentada()
      {
         try
         {
            if (PARA_OVDOCUMENTADA != null)
            {
               if (this.Item != null)
               {
                  if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea Documentar la Orden de Venta?", null) == System.Windows.Forms.DialogResult.OK)
                  {
                     MView.GetItem();
                     FleteNegativo = false;
                     if (Item.ValidarOperaciones(ref FleteNegativo, true, true))
                     {
                        Boolean _respueta = true;
                        if (Item.CCOT_EmitirHBL)
                        {
                           var _dialog = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "El RO cuenta con la opción de Emisión de HBL, ¿Desea continuar con el proceso?.", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
                           _respueta = _dialog == System.Windows.Forms.DialogResult.Yes;
                        }

                        if (_respueta)
                        {
                           m_item.CONS_CodEST = Delfin.Controls.variables.CONS_ESTOVEDOCUMENTADA;

                           Entities.Det_Cotizacion_OV_EventosTareas _itemEventoTarea = new Entities.Det_Cotizacion_OV_EventosTareas();

                           _itemEventoTarea.CCOT_Tipo = m_item.CCOT_Tipo;
                           _itemEventoTarea.CCOT_Numero = m_item.CCOT_Numero;
                           //ItemEventoTarea.EVEN_Item = 0;
                           _itemEventoTarea.EVEN_Fecha = DateTime.Now;
                           _itemEventoTarea.EVEN_Cumplida = true;
                           _itemEventoTarea.EVEN_Usuario = Session.UserName;
                           _itemEventoTarea.EVEN_Observaciones = "La Orden de Venta ha cambiado de estado a Documentada.";
                           _itemEventoTarea.TIPO_TabEVE = "EVE";
                           _itemEventoTarea.TIPO_CodEVE = PARA_OVDOCUMENTADA.PARA_Valor;
                           if (ListConstantesMOD != null && ListConstantesMOD.Count > 0 && ListConstantesMOD.First() != null)
                           {
                              _itemEventoTarea.CONS_TabMOD = ListConstantesMOD.First().CONS_CodTabla;
                              _itemEventoTarea.CONS_CodMOD = ListConstantesMOD.First().CONS_CodTipo;
                           }
                           _itemEventoTarea.EVEN_Manual = false;

                           _itemEventoTarea.AUDI_UsrCrea = Session.UserName;
                           _itemEventoTarea.AUDI_FecCrea = Session.Fecha;

                           _itemEventoTarea.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

                           Item.ItemsEventosTareas.Add(_itemEventoTarea);

                           String CCOT_MensajeError = "";

                           if (Client.OPE_SaveCab_Cotizacion_OV(ref m_item, ref CCOT_MensajeError))
                           {
                              Item = Client.OPE_GetOneCab_Cotizacion_OV(m_item.EMPR_Codigo.Value, m_item.SUCR_Codigo.Value, m_item.CCOT_Tipo, m_item.CCOT_Numero);
                              Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha documentado satisfactoriamente la Orden de Venta.");

                              MView.ClearItem();
                              this.Item.AUDI_UsrMod = Session.UserName;
                              this.Item.AUDI_FecMod = Session.Fecha;
                              this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                              MView.SetItem();
                           }
                           else
                           { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item como documentado.", CCOT_MensajeError); }
                        }
                     }
                     else
                     {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Se han encontrado algunos errores, revisar los detalles.", Item.MensajeError);
                        MView.ShowValidation();
                     }
                  }
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encuentra configurado parámetro(OVDOCUMENTADA) para el Evento cambio de estado a OV Documentada."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex); }
      }
      public void PreFacturar()
      {
         try
         {
            if (this.Item != null)
            {
               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea Prefacturar la Orden de Venta?", null) == System.Windows.Forms.DialogResult.OK)
               {
                  var _itemTipoCambio = Client.GetOneTiposCambio(Session.Fecha.ToString("yyyyMMdd"));

                  if (Item.NVIA_Codigo.HasValue)
                  {
                     if (_itemTipoCambio != null)
                     {
                        if (Guardar(false, false))
                        {
                           Int16 _EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                           Int16 _SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
                           Int32 _NVIA_Codigo = Item.NVIA_Codigo.Value;
                           Nullable<Int16> _CCOT_Tipo = Item.CCOT_Tipo;
                           Nullable<Int32> _CCOT_Numero = Item.CCOT_Numero;
                           Decimal _CCCT_TipoCambio = _itemTipoCambio.TIPC_Venta;
                           DateTime _CCCT_FecEmision = Session.Fecha;
                           String _AUDI_Usuario = Session.UserName;

                           String _mensaje = "";

                           Boolean _isCorrect = Client.OPE_SaveCab_Cotizacion_OV_GenerarCuentasCorrientes(_EMPR_Codigo, _SUCR_Codigo, _NVIA_Codigo, _CCOT_Tipo, _CCOT_Numero, _CCCT_TipoCambio, _CCCT_FecEmision, _AUDI_Usuario, false, ref _mensaje);
                           if (_isCorrect)
                           {
                              Item = Client.OPE_GetOneCab_Cotizacion_OV(m_item.EMPR_Codigo.Value, m_item.SUCR_Codigo.Value, m_item.CCOT_Tipo, m_item.CCOT_Numero);
                              Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha procesado la Pre-Facturación correctamente.");
                              MView.SetItem();
                           }
                           else
                           {
                              if (!String.IsNullOrEmpty(_mensaje))
                              {
                                 Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al procesar la Pre-Facturación.", _mensaje);
                              }
                              else
                              {
                                 Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al procesar la Pre-Facturación.");
                              }
                           }
                        }
                     }
                     else
                     {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar el Tipo de Cambio para la fecha " + Session.Fecha.ToShortDateString() + ".");
                     }
                  }
                  else
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe asociar la Orden de Venta a un Viaje.");
                  }
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha Ocurrido un error al procesar la Pre-Facturación", ex); }
      }
      #endregion

      #region [ Metodos Contrato ]
      public void AyudaContrato(Entidad Transportista, Constantes Regimen, Constantes Via, DateTime CCOT_FecEmi, DateTime CCOT_FecVcto, Nullable<Int32> PUER_CodOrigen, Nullable<Int32> PUER_CodDestino, Boolean ActualizarContrato)
      {
         try
         {
            Int32 _CONT_Codigo = -1;
            String _TIPO_TabPaisOrigen = null;
            String _TIPO_CodPaisOrigen = null;
            Nullable<Int32> _PUER_CodigoOrigen = null;
            String _TIPO_TabPaisDestino = null;
            String _TIPO_CodPaisDestino = null;
            Nullable<Int32> _PUER_CodigoDestino = null;

            System.Data.DataTable dtAyuda = new System.Data.DataTable();
            dtAyuda = Client.GetAllContratoByAyudaPivotOV(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Transportista.ENTC_Codigo, CCOT_FecEmi, CCOT_FecVcto, Regimen.CONS_CodTabla, Regimen.CONS_CodTipo, Via.CONS_CodTabla, Via.CONS_CodTipo, PUER_CodOrigen, PUER_CodDestino);

            if (dtAyuda == null || dtAyuda.Rows.Count == 0)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias."); }
            else if (dtAyuda.Rows.Count == 1)
            {
               if (Int32.TryParse(dtAyuda.Rows[0]["CODIGO"].ToString(), out _CONT_Codigo))
               {
                  _TIPO_TabPaisOrigen = dtAyuda.Rows[0]["TIPO_TabPaisOrigen"].ToString();
                  _TIPO_CodPaisOrigen = dtAyuda.Rows[0]["TIPO_CodPaisOrigen"].ToString();
                  if (dtAyuda.Rows[0]["PUER_CodigoOrigen"] != System.DBNull.Value)
                  {
                     Int32 _PUER_CodigoOrigenValue;
                     if (Int32.TryParse(dtAyuda.Rows[0]["PUER_CodigoOrigen"].ToString(), out _PUER_CodigoOrigenValue))
                     { _PUER_CodigoOrigen = _PUER_CodigoOrigenValue; }
                  }
                  _TIPO_TabPaisDestino = dtAyuda.Rows[0]["TIPO_TabPaisDestino"].ToString();
                  _TIPO_CodPaisDestino = dtAyuda.Rows[0]["TIPO_CodPaisDestino"].ToString();

                  if (dtAyuda.Rows[0]["PUER_CodigoDestino"] != System.DBNull.Value)
                  {
                     Int32 _PUER_CodigoDestinoValue;
                     if (Int32.TryParse(dtAyuda.Rows[0]["PUER_CodigoDestino"].ToString(), out _PUER_CodigoDestinoValue))
                     { _PUER_CodigoDestino = _PUER_CodigoDestinoValue; }
                  }
               }
            }
            else
            {
               List<Infrastructure.WinForms.Controls.ColumnaAyuda> _columnas = new List<Infrastructure.WinForms.Controls.ColumnaAyuda>();
               Int32 _index = 0;
               foreach (System.Data.DataColumn _column in dtAyuda.Columns)
               {
                  if (_column.ColumnName != "PUER_CodigoOrigen"
                   && _column.ColumnName != "TIPO_TabPaisOrigen"
                   && _column.ColumnName != "TIPO_CodPaisOrigen"
                   && _column.ColumnName != "PUER_CodigoDestino"
                   && _column.ColumnName != "TIPO_TabPaisDestino"
                   && _column.ColumnName != "TIPO_CodPaisDestino")
                  {
                     _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
                     {
                        Index = _index,
                        ColumnName = _column.ColumnName,
                        ColumnCaption = _column.ColumnName
                     });
                     _index += 1;
                  }
               }


               //_columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               //{
               //   Index = 1,
               //   ColumnName = "CONT_Numero",
               //   ColumnCaption = "Número"
               //});
               //_columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               //{
               //   Index = 2,
               //   ColumnName = "CONT_Descrip",
               //   ColumnCaption = "Descripción"
               //});
               //_columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               //{
               //   Index = 3,
               //   ColumnName = "CONT_FecEmi",
               //   ColumnCaption = "Fec. Emisión"
               //});
               //_columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               //{
               //   Index = 4,
               //   ColumnName = "CONT_FecIni",
               //   ColumnCaption = "Fec. Inicio"
               //});
               //_columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               //{
               //   Index = 5,
               //   ColumnName = "CONT_FecFin",
               //   ColumnCaption = "Fec. Fin"
               //});
               //_columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               //{
               //   Index = 6,
               //   ColumnName = "TIPO_DescPaisOrigen",
               //   ColumnCaption = "País Origen"
               //});
               //_columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               //{
               //   Index = 7,
               //   ColumnName = "PUER_NombreOrigen",
               //   ColumnCaption = "Puerto Origen"
               //});
               //_columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               //{
               //   Index = 8,
               //   ColumnName = "TIPO_DescPaisDestino",
               //   ColumnCaption = "País Destino"
               //});
               //_columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               //{
               //   Index = 9,
               //   ColumnName = "PUER_NombreDestino",
               //   ColumnCaption = "Puerto Destino"
               //});

               Infrastructure.WinForms.Controls.Ayuda x_Ayuda = new Infrastructure.WinForms.Controls.Ayuda("Ayuda Contrato", dtAyuda, false, _columnas);
               x_Ayuda.Width = x_Ayuda.Width * 2;
               if (x_Ayuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                  if (Int32.TryParse(x_Ayuda.Respuesta.Rows[0]["CODIGO"].ToString(), out _CONT_Codigo))
                  {
                     _TIPO_TabPaisOrigen = x_Ayuda.Respuesta.Rows[0]["TIPO_TabPaisOrigen"].ToString();
                     _TIPO_CodPaisOrigen = x_Ayuda.Respuesta.Rows[0]["TIPO_CodPaisOrigen"].ToString();
                     if (x_Ayuda.Respuesta.Rows[0]["PUER_CodigoOrigen"] != System.DBNull.Value)
                     {
                        Int32 _PUER_CodigoOrigenValue;
                        if (Int32.TryParse(x_Ayuda.Respuesta.Rows[0]["PUER_CodigoOrigen"].ToString(), out _PUER_CodigoOrigenValue))
                        { _PUER_CodigoOrigen = _PUER_CodigoOrigenValue; }
                     }
                     _TIPO_TabPaisDestino = x_Ayuda.Respuesta.Rows[0]["TIPO_TabPaisDestino"].ToString();
                     _TIPO_CodPaisDestino = x_Ayuda.Respuesta.Rows[0]["TIPO_CodPaisDestino"].ToString();
                     if (x_Ayuda.Respuesta.Rows[0]["PUER_CodigoDestino"] != System.DBNull.Value)
                     {
                        Int32 _PUER_CodigoDestinoValue;
                        if (Int32.TryParse(x_Ayuda.Respuesta.Rows[0]["PUER_CodigoDestino"].ToString(), out _PUER_CodigoDestinoValue))
                        { _PUER_CodigoDestino = _PUER_CodigoDestinoValue; }
                     }
                  }

               }
            }

            if (_CONT_Codigo > 0)
            {
               Contrato _itemContrato = Client.GetOneContrato(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, _CONT_Codigo);
               _itemContrato.TIPO_TabPaisOrigen = _TIPO_TabPaisOrigen;
               _itemContrato.TIPO_CodPaisOrigen = _TIPO_CodPaisOrigen;
               _itemContrato.PUER_CodigoOrigen = _PUER_CodigoOrigen;
               _itemContrato.TIPO_TabPaisDestino = _TIPO_TabPaisDestino;
               _itemContrato.TIPO_CodPaisDestino = _TIPO_CodPaisDestino;
               _itemContrato.PUER_CodigoDestino = _PUER_CodigoDestino;

               Item.ItemContrato = _itemContrato;
               MView.SetItemContrato(ActualizarContrato);
            }
            else
            {
               MView.ClearItemContrato();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "ha ocurrido un error en la Ayuda de Contrato", ex); }
      }
      #endregion

      #region [ Metodos Contacto ]
      public void Contacto(Boolean Nuevo, ref Entidad ItemEntidad, Constantes ItemConstanteRGM)
      {
         try
         {
            MAN009MView MAN009_mview_sinlv;
            MAN009Presenter MAN009_presenter_sinlv;
            MAN009_mview_sinlv = new MAN009MView();
            MAN009_presenter_sinlv = new MAN009Presenter(ContainerService, MAN009_mview_sinlv, Delfin.Controls.EntidadClear.TIPE_Contacto);
            MAN009_mview_sinlv.Presenter = MAN009_presenter_sinlv;
            MAN009_presenter_sinlv.lsinlview = true;
            MAN009_presenter_sinlv.tipe_Desc = "Contacto";
            MAN009_presenter_sinlv.Load();

            ItemEntidad = Client.GetOneEntidad(ItemEntidad.ENTC_Codigo, Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Controls.TiposEntidad.TIPE_Cliente));
            if (Nuevo)
            {
               if (MAN009_presenter_sinlv.Nuevo() != System.Windows.Forms.DialogResult.Cancel)
               {
                  if (ItemConstanteRGM.CONS_CodTipo == "001") //Importaciones
                  {
                     ItemEntidad.AUDI_UsrMod = Session.UserName;
                     ItemEntidad.AUDI_FecMod = Session.Fecha;
                     ItemEntidad.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;

                     ItemEntidad.ContactoImpo = MAN009_presenter_sinlv.Item;
                     ItemEntidad.ContactoImpo.AUDI_UsrMod = Session.UserName;
                     ItemEntidad.ContactoImpo.AUDI_FecMod = Session.Fecha;
                     ItemEntidad.ContactoImpo.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

                     Client.SaveEntidad(ItemEntidad);
                     ItemEntidad.ContactoImpo = MAN009_presenter_sinlv.Item;

                  }
                  else if (ItemConstanteRGM.CONS_CodTipo == "002") //Exportaciones
                  {
                     ItemEntidad.AUDI_UsrMod = Session.UserName;
                     ItemEntidad.AUDI_FecMod = Session.Fecha;
                     ItemEntidad.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;

                     ItemEntidad.ContactoExpo = MAN009_presenter_sinlv.Item;
                     ItemEntidad.ContactoExpo.AUDI_UsrMod = Session.UserName;
                     ItemEntidad.ContactoExpo.AUDI_FecMod = Session.Fecha;
                     ItemEntidad.ContactoExpo.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

                     Client.SaveEntidad(ItemEntidad);
                     ItemEntidad.ContactoExpo = MAN009_presenter_sinlv.Item;
                  }
               }
            }
            else
            {
               if (ItemConstanteRGM.CONS_CodTipo == "001") //Importaciones
               { MAN009_presenter_sinlv.Item = ItemEntidad.ContactoImpo; }
               else if (ItemConstanteRGM.CONS_CodTipo == "002") //Exportaciones
               { MAN009_presenter_sinlv.Item = ItemEntidad.ContactoExpo; }

               if (MAN009_presenter_sinlv.Editar() != System.Windows.Forms.DialogResult.Cancel)
               {
                  if (ItemConstanteRGM.CONS_CodTipo == "001") //Importaciones
                  { ItemEntidad.ContactoImpo = MAN009_presenter_sinlv.Item; }
                  else if (ItemConstanteRGM.CONS_CodTipo == "002") //Exportaciones
                  { ItemEntidad.ContactoExpo = MAN009_presenter_sinlv.Item; }
               }
            }
         }
         catch (Exception)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al registrar el contacto"); }
      }
      #endregion

      #region [ Metodos NaveViaje ]
      public void AyudaNaveViaje(String NVIA_NroViaje)
      {
         try
         {
            MView.GetItem();

            if (!Item.CCOT_FecEmi.HasValue)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar la Fecha de Emisión."); return; }

            if (String.IsNullOrEmpty(Item.CONS_TabRGM) || String.IsNullOrEmpty(Item.CONS_CodRGM))
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar el Régimen."); return; }

            if (String.IsNullOrEmpty(Item.CONS_TabVia) || String.IsNullOrEmpty(Item.CONS_CodVia))
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar la Vía."); return; }

            if (!Item.PUER_CodOrigen.HasValue)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar el Puerto Origen."); return; }

            if (!Item.PUER_CodDestino.HasValue)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar el Puerto Destino."); return; }


            System.Data.DataTable dtAyuda = new System.Data.DataTable();
            NVIA_NroViaje = (String.IsNullOrEmpty(NVIA_NroViaje) ? null : NVIA_NroViaje);
            dtAyuda = Client.GetAllDetNaveViajeAyuda(Item.CONS_TabRGM, Item.CONS_CodRGM, Item.CONS_TabVia, Item.CONS_CodVia, Item.PUER_CodOrigen.Value, Item.PUER_CodDestino.Value, Item.CCOT_FecEmi.Value, NVIA_NroViaje).ToDataTable();
            if (dtAyuda.Rows.Count == 0)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias."); }
            else if (dtAyuda.Rows.Count == 1)
            {
               Int32 _DVIA_Codigo;
               if (Int32.TryParse(dtAyuda.Rows[0]["DVIA_Codigo"].ToString(), out _DVIA_Codigo))
               {
                  Int32 _NVIA_Codigo;
                  if (Int32.TryParse(dtAyuda.Rows[0]["NVIA_Codigo"].ToString(), out _NVIA_Codigo))
                  {
                     //Item.ItemDetNaveViaje = Client.GetOneDetNaveViaje(_DVIA_Codigo, _NVIA_Codigo);
                     Item.ItemNaveViaje = Client.GetOneNaveViaje(_NVIA_Codigo);
                     MView.SetItemViaje();
                  }
               }
            }
            else
            {
               List<Infrastructure.WinForms.Controls.ColumnaAyuda> _columnas = new List<Infrastructure.WinForms.Controls.ColumnaAyuda>();
               Int32 _index = 0;
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = _index,
                  ColumnName = "NAVE_Nombre",
                  ColumnCaption = "Nave",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 120,
                  DataType = typeof(System.String),
                  Format = null
               }); _index += 1;

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = _index,
                  ColumnName = "ENTC_RazonSocial",
                  ColumnCaption = "Transportista",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 250,
                  DataType = typeof(System.String),
                  Format = null
               }); _index += 1;

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = _index,
                  ColumnName = "NVIA_NroViaje",
                  ColumnCaption = "Nro. Viaje",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 80,
                  DataType = typeof(System.String),
                  Format = null
               }); _index += 1;
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = _index,
                  ColumnName = "NVIA_FecETA_IMPO_ETD_EXPO",
                  ColumnCaption = "ETA\\ETD",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 80,
                  DataType = typeof(System.DateTime),
                  Format = "dd/MM/yyyy"
               }); _index += 1;
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = _index,
                  ColumnName = "CONS_DescVIA",
                  ColumnCaption = "Vía",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 60,
                  DataType = typeof(System.String),
                  Format = null
               }); _index += 1;

               //_columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               //{
               //   Index = _index,
               //   ColumnName = "NVIA_NroManifiesto",
               //   ColumnCaption = "Nro. Manifiesto",
               //   Alineacion = DataGridViewContentAlignment.MiddleLeft,
               //   Width = 60,
               //   DataType = typeof(System.String),
               //   Format = null
               //}); _index += 1;
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = _index,
                  ColumnName = "NVIA_Codigo",
                  ColumnCaption = "Código",
                  Alineacion = DataGridViewContentAlignment.MiddleRight,
                  Width = 50,
                  DataType = typeof(System.Int32),
                  Format = null
               }); _index += 1;


               //_columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               //{
               //   Index = _index,
               //   ColumnName = "NVIA_FECARRIBO",
               //   ColumnCaption = "Fec. Arribo",
               //   Alineacion = DataGridViewContentAlignment.MiddleLeft,
               //   Width = 80,
               //   DataType = typeof(System.String),
               //   Format = null
               //});_index += 1;


               Infrastructure.WinForms.Controls.Ayuda x_Ayuda = new Infrastructure.WinForms.Controls.Ayuda("Ayuda Contrato", dtAyuda, false, _columnas);
               x_Ayuda.Width = Convert.ToInt32(x_Ayuda.Width * 1.5);
               if (x_Ayuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                  Int32 _DVIA_Codigo;
                  if (Int32.TryParse(x_Ayuda.Respuesta.Rows[0]["DVIA_Codigo"].ToString(), out _DVIA_Codigo))
                  {
                     Int32 _NVIA_Codigo;
                     if (Int32.TryParse(x_Ayuda.Respuesta.Rows[0]["NVIA_Codigo"].ToString(), out _NVIA_Codigo))
                     {
                        //Item.ItemDetNaveViaje = Client.GetOneDetNaveViaje(_DVIA_Codigo, _NVIA_Codigo);
                        Item.ItemNaveViaje = Client.GetOneNaveViaje(_NVIA_Codigo);
                        MView.SetItemViaje();
                     }
                  }
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al mostrar la ayuda de viaje", ex); }
      }
      public void EdicionNaveViaje(Boolean Nuevo)
      {
         try
         {
            MAN011MView _view = new MAN011MView();
            MAN011Presenter _presenter = new MAN011Presenter(this.ContainerService, _view);
            _view.Presenter = _presenter;
            _presenter.Load();

            MView.GetItem();

            if (Nuevo)
            {
               Boolean _isCorrect = true;
               String _mensaje = "";

               _presenter.Item = new NaveViaje();
               _presenter.Item.NVIA_Estado = "A";
               if (Item.ENTC_CodTransportista.HasValue)
               { _presenter.Item.ENTC_CodTransportista = Item.ENTC_CodTransportista; }
               else
               {
                  _isCorrect = false;
                  _mensaje += "* Debe seleccionar el Transportista." + Environment.NewLine;
                  //Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar el Transportista."); 
               }
               if (!String.IsNullOrEmpty(Item.CONS_TabRGM) && !String.IsNullOrEmpty(Item.CONS_CodRGM))
               {
                  _presenter.Item.CONS_TabRGM = Item.CONS_TabRGM;
                  _presenter.Item.CONS_CodRGM = Item.CONS_CodRGM;
               }
               else
               {
                  _isCorrect = false;
                  _mensaje += "* Debe seleccionar el Régimen." + Environment.NewLine;
                  //Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar el Régimen."); 
               }
               if (!String.IsNullOrEmpty(Item.CONS_TabVia) && !String.IsNullOrEmpty(Item.CONS_CodVia))
               {
                  _presenter.Item.CONS_TabVia = Item.CONS_TabVia;
                  _presenter.Item.CONS_CodVia = Item.CONS_CodVia;
               }
               else
               {
                  _isCorrect = false;
                  _mensaje += "* Debe seleccionar la Vía." + Environment.NewLine;
                  //Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar la Vía."); 
               }

               if (Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
               {
                  if (Item.PUER_CodDestino.HasValue)
                  {
                     _presenter.Item.TIPO_TabPAI = Item.TIPO_TabPAIDestino;
                     _presenter.Item.TIPO_CodPAI = Item.TIPO_CodPAIDestino;
                     _presenter.Item.PUER_Codigo = Item.PUER_CodDestino;
                     _presenter.Item.PUER_Nombre = Item.PUER_NombreDestino;
                  }
                  else
                  {
                     _isCorrect = false;
                     _mensaje += "* Debe seleccionar el puerto de Destino." + Environment.NewLine;
                     //Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar la Vía."); 
                  }

                  Entities.DetNaveViaje _detnaveviaje = new DetNaveViaje();
                  _detnaveviaje.TIPO_TabPAI = Item.TIPO_TabPAIOrigen;
                  _detnaveviaje.TIPO_CodPAI = Item.TIPO_CodPAIOrigen;
                  _detnaveviaje.PUER_Codigo = Item.PUER_CodOrigen;
                  _detnaveviaje.PUER_Nombre = Item.PUER_NombreOrigen;
                  _detnaveviaje.AUDI_UsrCrea = Session.UserName;
                  _detnaveviaje.AUDI_FecCrea = Session.Fecha;
                  _detnaveviaje.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                  _presenter.Item.ItemsDetNaveViaje.Add(_detnaveviaje);
               }
               else
               {
                  if (Item.PUER_CodOrigen.HasValue)
                  {
                     _presenter.Item.TIPO_TabPAI = Item.TIPO_TabPAIOrigen;
                     _presenter.Item.TIPO_CodPAI = Item.TIPO_CodPAIOrigen;
                     _presenter.Item.PUER_Codigo = Item.PUER_CodOrigen;
                     _presenter.Item.PUER_Nombre = Item.PUER_NombreOrigen;
                  }
                  else
                  {
                     _isCorrect = false;
                     _mensaje += "* Debe seleccionar el puerto de Origen." + Environment.NewLine;
                     //Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar la Vía."); 
                  }

                  Entities.DetNaveViaje _detnaveviaje = new DetNaveViaje();
                  _detnaveviaje.TIPO_TabPAI = Item.TIPO_TabPAIDestino;
                  _detnaveviaje.TIPO_CodPAI = Item.TIPO_CodPAIDestino;
                  _detnaveviaje.PUER_Codigo = Item.PUER_CodDestino;
                  _detnaveviaje.PUER_Nombre = Item.PUER_NombreDestino;
                  _detnaveviaje.AUDI_UsrCrea = Session.UserName;
                  _detnaveviaje.AUDI_FecCrea = Session.Fecha;
                  _detnaveviaje.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                  _presenter.Item.ItemsDetNaveViaje.Add(_detnaveviaje);
               }

               if (_isCorrect)
               {
                  if (_presenter.NuevoEdicion() == System.Windows.Forms.DialogResult.OK)
                  {
                     //Item.ItemDetNaveViaje = Client.GetOneDetNaveViajeByOV(Item.CONS_TabRGM, Item.CONS_CodRGM, Item.CONS_TabVia, Item.CONS_CodVia, Item.PUER_CodOrigen.Value, Item.PUER_CodDestino.Value, _presenter.Item.NVIA_Codigo);
                     Item.ItemNaveViaje = Client.GetOneNaveViaje(_presenter.Item.NVIA_Codigo);
                     MView.SetItemViaje();
                  }
                  //else
                  //{ MView.ClearItemViaje(); }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Falta ingresar algunos datos revisar los detalles.", _mensaje); }
            }
            else
            {
               if (Item != null && Item.ItemNaveViaje != null)
               {
                  _presenter.Item = new NaveViaje();
                  _presenter.Item.NVIA_Codigo = Item.ItemNaveViaje.NVIA_Codigo;

                  if (_presenter.Editar() == System.Windows.Forms.DialogResult.OK)
                  {
                     Item.ItemNaveViaje = Client.GetOneNaveViaje(_presenter.Item.NVIA_Codigo);
                     MView.SetItemViaje();
                  }
                  //else
                  //{ MView.ClearItemViaje(); }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Para poder editar el viaje primero debe crearlo/seleccionarlo."); }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al mostrar la edición de la nave viaje", ex); }
      }
      #endregion

      #region [ Metodos Novedades ]
      public Det_Cotizacion_OV_Novedad ItemNovedad { get; set; }
      public Boolean AgregarNovedad()
      {
         try
         {
            ItemNovedad = new Det_Cotizacion_OV_Novedad();
            ItemNovedad.CCOT_Numero = Item.CCOT_Numero;
            ItemNovedad.CCOT_Tipo = Item.CCOT_Tipo;
            ItemNovedad.OVNO_Fecha = Session.Fecha;
            ItemNovedad.OVNO_Email = false;
            MView.GetItemNovedad();
            ItemNovedad.AUDI_UsrCrea = Session.UserName;
            ItemNovedad.AUDI_FecCrea = Session.Fecha;
            ItemNovedad.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            if (ItemNovedad.Validar())
            {
               if (Client.SaveDet_Cotizacion_OV_Novedad(ItemNovedad))
               {
                  Item.ItemsNovedad = Client.GetAllDet_Cotizacion_OV_NovedadByCab_Cotizacion_OV(Item.CCOT_Numero, Item.CCOT_Tipo);
                  MView.ClearItemNovedad();
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se agregó satifactoriamente la Novedad.");
                  MView.ShowNovedades();
                  return true;
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al agregar la Novedad.");
                  return false;
               }
            }
            else
            {
               MView.ShowValidationItemNovedad();
               return false;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al agregar la Novedad.", ex);
            return false;
         }
      }
      public Boolean EnviarNovedades()
      {
         try
         {
            //if (Client.SaveCab_Cotizacion_OVEnviarNovedades(Item.EMPR_Codigo.Value, Item.SUCR_Codigo.Value, Item.CCOT_Tipo, Item.CCOT_Numero, Session.UserName))
            if (EnviarNovedades(Item.EMPR_Codigo.Value, Item.SUCR_Codigo.Value, Item.CCOT_Tipo, Item.CCOT_Numero, Session.UserName))
            {
               Item.ItemsNovedad = Client.GetAllDet_Cotizacion_OV_NovedadByCab_Cotizacion_OV(Item.CCOT_Numero, Item.CCOT_Tipo);
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se envió satifactoriamente la Novedad.");
               MView.ShowNovedades();
               return true;
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al enviar las Novedades.");
               return false;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al enivar las Novedaded.", ex);
            return false;
         }
      }
      #endregion

      #region [ Metodos Archivo ]
      public Det_Cotizacion_OV_Archivo ItemArchivo { get; set; }

      public Boolean UploadFile(String FilePath)
      {
         try
         {
            if (string.IsNullOrWhiteSpace(FilePath))
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un archivo.");
               return false;
            }
            else if (!File.Exists(FilePath))
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "El archivo seleccionado no existe.");
               return false;
            }
            else
            {
               byte[] fileToSend = File.ReadAllBytes(FilePath);

               Det_Cotizacion_OV_Archivo ItemArchivo = new Det_Cotizacion_OV_Archivo();
               ItemArchivo.CCOT_Numero = Item.CCOT_Numero;
               ItemArchivo.CCOT_Tipo = Item.CCOT_Tipo;
               ItemArchivo.OVAR_Descrip = System.IO.Path.GetFileName(FilePath);
               ItemArchivo.OVAR_FecEmi = DateTime.Now;
               ItemArchivo.OVAR_Archivo = fileToSend;
               ItemArchivo.AUDI_UsrCrea = Session.UserName;
               ItemArchivo.AUDI_FecCrea = DateTime.Now;
               ItemArchivo.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
               Item.ItemsArchivo.Add(ItemArchivo);

               /*ACTUALIZAMOS LOS ANTERIORES DOCUMENTOS Y GUARDAMOS LOS NUEVOS*/
               Boolean _iscorrect = true;
               foreach (Det_Cotizacion_OV_Archivo _item in Item.ItemsArchivo)
               {
                  _iscorrect = Client.SaveDet_Cotizacion_OV_Archivo(_item);
               }

               if (_iscorrect)
               {
                  Item.ItemsArchivo = Client.GetAllDet_Cotizacion_OV_ArchivoByCab_Cotizacion_OV(Item.CCOT_Numero, Item.CCOT_Tipo);
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha subido satisfactoriamente el archivo.");
                  return true;
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al subir el archivo.");
                  return false;
               }
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error en el metodo para subir el archivo.", ex);
            return false;
         }
      }
      public Boolean DownloadFile(Det_Cotizacion_OV_Archivo x_ItemArchivo)
      {
         try
         {
            System.Windows.Forms.FolderBrowserDialog _folder = new System.Windows.Forms.FolderBrowserDialog();
            if (_folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               string fileName = _folder.SelectedPath + "\\" + x_ItemArchivo.OVAR_Descrip;
               using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
               {
                  // Write the data to the file, byte by byte. 
                  for (int i = 0; i < x_ItemArchivo.OVAR_Archivo.Length; i++)
                  { fileStream.WriteByte(x_ItemArchivo.OVAR_Archivo[i]); }

                  // Set the stream position to the beginning of the file.
                  fileStream.Seek(0, SeekOrigin.Begin);

                  // Read and verify the data. 
                  for (int i = 0; i < fileStream.Length; i++)
                  {
                     if (x_ItemArchivo.OVAR_Archivo[i] != fileStream.ReadByte())
                     {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al crear le archivo.");
                        Console.WriteLine("Error writing data.");
                        return false;
                     }
                  }
               }

               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha creado satifactoriamente el archivo.");
               System.Diagnostics.Process.Start(fileName);
               return true;
            }
            else
            { return false; }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al descargar el archivo.", ex);
            return false;
         }
      }

      public Boolean ShowFileStream(Det_Cotizacion_OV_Archivo x_ItemArchivo)
      {
          try
          {
              //System.Windows.Forms.FolderBrowserDialog _folder = new System.Windows.Forms.FolderBrowserDialog();
              //if (_folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
              //{
                  string fileName = System.IO.Path.GetTempPath() +  x_ItemArchivo.OVAR_Descrip;
                  using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
                  {
                      // Write the data to the file, byte by byte. 
                      for (int i = 0; i < x_ItemArchivo.OVAR_Archivo.Length; i++)
                      { fileStream.WriteByte(x_ItemArchivo.OVAR_Archivo[i]); }

                      // Set the stream position to the beginning of the file.
                      fileStream.Seek(0, SeekOrigin.Begin);

                      // Read and verify the data. 
                      for (int i = 0; i < fileStream.Length; i++)
                      {
                          if (x_ItemArchivo.OVAR_Archivo[i] != fileStream.ReadByte())
                          {
                              Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al crear le archivo.");
                              Console.WriteLine("Error writing data.");
                              return false;
                          }
                      }
                  }

                  //Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha creado satifactoriamente el archivo.");
                  System.Diagnostics.Process.Start(fileName);
                  //System.IO.File.Delete(fileName);
                  return true;
              //}
              //else
              //{ return false; }
          }
          catch (Exception ex)
          {
              Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al descargar el archivo.", ex);
              return false;
          }
      }

      public Boolean EliminarFile()
      {
         try
         {
            if (ItemArchivo != null)
            {
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  ItemArchivo.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                  if (Client.SaveDet_Cotizacion_OV_Archivo(ItemArchivo))
                  {
                     Item.ItemsArchivo = Client.GetAllDet_Cotizacion_OV_ArchivoByCab_Cotizacion_OV(Item.CCOT_Numero, Item.CCOT_Tipo);
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el archivo.");
                     return true;
                  }
                  else
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al eliminar el archivo.");
                     return false;
                  }
               }
               else
               { return false; }
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un archivo para poder eliminarlo.");
               return false;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al eliminar el archivo.", ex);
            return false;
         }
      }

      #region [ Backup ]
      //public Boolean UploadFile(String FilePath)
      //{
      //   try
      //   {
      //      if (string.IsNullOrWhiteSpace(FilePath))
      //      {
      //         Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un archivo.");
      //         return false;
      //      }
      //      else if (!File.Exists(FilePath))
      //      {
      //         Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "El archivo seleccionado no existe.");
      //         return false;
      //      }
      //      else
      //      {
      //         try
      //         {
      //            // Create the REST request.
      //            string url = ConfigurationManager.AppSettings["serviceUrl"];
      //            string requestUrl = string.Format("{0}/UploadFile/{1}/{2}/{3}/{4}", url, Item.CCOT_Numero, Item.CCOT_Tipo, System.IO.Path.GetFileName(FilePath), Session.UserName);

      //            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
      //            request.Method = "POST";
      //            request.ContentType = "text/plain";

      //            byte[] fileToSend = File.ReadAllBytes(FilePath);
      //            request.ContentLength = fileToSend.Length;

      //            using (Stream requestStream = request.GetRequestStream())
      //            {
      //               // Send the file as body request.
      //               requestStream.Write(fileToSend, 0, fileToSend.Length);
      //               requestStream.Close();
      //            }

      //            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
      //            { Console.WriteLine("HTTP/{0} {1} {2}", response.ProtocolVersion, (int)response.StatusCode, response.StatusDescription); }

      //            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha subido satisfactoriamente el archivo.");

      //            Item.ItemsArchivo = Client.GetAllDet_Cotizacion_OV_ArchivoByCab_Cotizacion_OV(Item.CCOT_Numero, Item.CCOT_Tipo);

      //            return true;

      //         }
      //         catch (Exception ex)
      //         {
      //            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al subir el archivo.", ex);
      //            return false;
      //         }
      //      }

      //   }
      //   catch (Exception ex)
      //   {
      //      Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error en el metodo para subir el archivo.", ex);
      //      return false;
      //   }
      //}
      //public Boolean DowloadFile(Det_Cotizacion_OV_Archivo ItemArchivo)
      //{
      //   try
      //   {
      //      // Create the REST request.
      //      string url = ConfigurationManager.AppSettings["serviceUrl"];
      //      string requestUrl = string.Format("{0}/DownloadFile/{1}/{2}/{3}", url, ItemArchivo.CCOT_Numero, ItemArchivo.CCOT_Tipo, ItemArchivo.OVAR_Codigo);

      //      byte[] response = null;

      //      int left = 0;
      //      int steps = 0;
      //      int pos = 0;

      //      int bytelength = 1024;

      //      WebRequest request = WebRequest.Create(requestUrl);
      //      // Get response  
      //      using (HttpWebResponse webResponse = request.GetResponse() as HttpWebResponse)
      //      {
      //         using (Stream stream = webResponse.GetResponseStream())
      //         {
      //            response = new byte[(int)webResponse.ContentLength];

      //            left = (int)webResponse.ContentLength % bytelength;
      //            steps = (int)webResponse.ContentLength / bytelength;
      //            pos = 0;

      //            while (pos < response.Length)
      //            {
      //               int bytesRead = stream.Read(response, pos, response.Length - pos);
      //               if (bytesRead == 0)
      //               {
      //                  // End of data and we didn't finish reading. Oops.
      //                  throw new IOException("Premature end of data");
      //               }
      //               pos += bytesRead;
      //            }

      //            //StreamWriter writer = new StreamWriter(stream);



      //            //responsefile = new byte[(int)response.ContentLength];

      //            //left = (int)response.ContentLength % bytelength;
      //            //steps = (int)response.ContentLength / bytelength;
      //            //pos = 0;

      //            //for (int i = 0; i < steps; i++)
      //            //{
      //            //   stream.Read(responsefile, pos, bytelength);
      //            //   pos += bytelength;
      //            //}

      //            //if (left != 0)
      //            //{ stream.Read(responsefile, pos, left); }

      //            //stream.Close();
      //         }
      //      }

      //      string fileName = "c://" + ItemArchivo.OVAR_Descrip;
      //      using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
      //      {
      //         // Write the data to the file, byte by byte. 
      //         for (int i = 0; i < response.Length; i++)
      //         { fileStream.WriteByte(response[i]); }

      //         // Set the stream position to the beginning of the file.
      //         fileStream.Seek(0, SeekOrigin.Begin);

      //         // Read and verify the data. 
      //         for (int i = 0; i < fileStream.Length; i++)
      //         {
      //            if (response[i] != fileStream.ReadByte())
      //            {
      //               Console.WriteLine("Error writing data.");
      //            }
      //         }
      //         Console.WriteLine("The data was written to {0} " + "and verified.", fileStream.Name);
      //      }




      //      Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha descargado satisfactoriamente el archivo.");
      //      return true;
      //   }
      //   catch (Exception ex)
      //   {
      //      Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al descargar el archivo.", ex);
      //      return false;
      //   }


      //}      
      #endregion
      #endregion

      #region [ Metodos Anexos ]
      public void ImprimirAnexo(Anexos ItemAnexo)
      {
         try
         {
            System.Data.DataTable dtAnexo = Client.GetOneAnexosPrint(ItemAnexo.CCOT_Tipo, ItemAnexo.CCOT_Numero, ItemAnexo.ANEX_Item);

            if (dtAnexo != null)
            {

               Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource();
               rds.Name = "DTAnexo1";
               rds.Value = dtAnexo;
               String _path = "";
               if (ItemAnexo.ANEX_Tipo == "R")
               {
                  //_path = "Delfin.Principal.Reportes.OPE001Anexos.rptAnexo1.rdlc";
                  _path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Reportes\\rptAnexo1.rdlc";
               }
               else if (ItemAnexo.ANEX_Tipo == "I")
               {
                  //_path = "Delfin.Principal.Reportes.OPE001Anexos.rptAnexo2.rdlc";
                  _path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Reportes\\rptAnexo2.rdlc";
               }

               Visualizador _impresion = new Visualizador("Impresión Anexo", _path, rds) { StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen };
               _impresion.Imprimir();
               _impresion.ShowDialog();
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se ha podido imprimir el registro porque no devolvió ningun resultado."); }
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos Eventos/Tareas ]
      //public Det_Cotizacion_OV_EventosTareas ItemEventosTareas { get; set; }

      //public void NuevoEventoTarea()
      //{
      //   try
      //   {

      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al hacer nuevo Evento Tarea.", ex); }
      //}
      //public Boolean EliminarEventoTarea()
      //{
      //   try
      //   {
      //      if (ItemEventosTareas != null)
      //      {
      //         System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
      //         if (_result == System.Windows.Forms.DialogResult.Yes)
      //         {
      //            ItemEventosTareas.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
      //            if (Client.SaveDet_Cotizacion_OV_EventosTareas(ItemEventosTareas))
      //            {
      //               Item.ItemsEventosTareas = Client.GetAllDet_Cotizacion_OV_EventosTareasByCotizacion_OV(Item.CCOT_Numero, Item.CCOT_Tipo);
      //               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el Evento/Tarea.");
      //               return true;
      //            }
      //            else
      //            {
      //               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al eliminar el Evento/Tarea.");
      //               return false;
      //            }
      //         }
      //         else
      //         { return false; }
      //      }
      //      else
      //      {
      //         Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un Evento/Tarea para poder eliminarlo.");
      //         return false;
      //      }
      //   }
      //   catch (Exception ex)
      //   {
      //      Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al eliminar el Evento/Tarea.", ex);
      //      return false;
      //   }
      //}
      public void GenerarEventosTareas(String Observacion_Evento, String Codigo_Evento, Int32 CCOT_Numero, Int16 CCOT_Tipo)
      {
         try
         {
            ItemsEventosTareas = new ObservableCollection<Det_Cotizacion_OV_EventosTareas>();

            ItemEventoTarea = new Det_Cotizacion_OV_EventosTareas();
            ItemEventoTarea.CCOT_Numero = CCOT_Numero;
            ItemEventoTarea.CCOT_Tipo = CCOT_Tipo;
            ItemEventoTarea.EVEN_Fecha = DateTime.Now;
            ItemEventoTarea.EVEN_Cumplida = true;
            ItemEventoTarea.EVEN_Usuario = Session.UserName;
            ItemEventoTarea.EVEN_Observaciones = Observacion_Evento;
            ItemEventoTarea.TIPO_TabEVE = "EVE";
            ItemEventoTarea.TIPO_CodEVE = Codigo_Evento;
            if (ListConstantesMOD != null && ListConstantesMOD.Count > 0 && ListConstantesMOD.First() != null)
            {
               ItemEventoTarea.CONS_TabMOD = ListConstantesMOD.First().CONS_CodTabla;
               ItemEventoTarea.CONS_CodMOD = ListConstantesMOD.First().CONS_CodTipo;
            }
            ItemEventoTarea.EVEN_Manual = false;

            ItemEventoTarea.AUDI_UsrCrea = Session.UserName;
            ItemEventoTarea.AUDI_FecCrea = Session.Fecha;

            ItemEventoTarea.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

            ItemsEventosTareas.Add(ItemEventoTarea);

            if ((Client.SaveDet_Cotizacion_OV_EventosTareas(ItemsEventosTareas)))
            {
               Item = Client.OPE_GetOneCab_Cotizacion_OV(m_item.EMPR_Codigo.Value, m_item.SUCR_Codigo.Value, m_item.CCOT_Tipo, m_item.CCOT_Numero);

               MView.ClearItem();
               this.Item.AUDI_UsrMod = Session.UserName;
               this.Item.AUDI_FecMod = Session.Fecha;
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
               MView.SetItem();
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Error al momento de generar Eventos", ex);
         }
      }
      #endregion

      #region [ Metodos MBL ]
      public void MostrarMBL()
      {
         try
         {
            if (Guardar(false, false, false))
            {
               if (!String.IsNullOrEmpty(Item.DOOV_MBL.Trim()))
               {
                  IDOC001MView _DOC001MView = new DOC001MView();
                  DOC001Presenter _DOC001Presenter = new DOC001Presenter(this.ContainerService, _DOC001MView);
                  _DOC001MView.Presenter = _DOC001Presenter;
                  _DOC001Presenter.Load();
                  _DOC001Presenter.Item = Client.GetOneCab_MBLByNumero(Item.DOOV_MBL);
                  _DOC001Presenter.Editar();
               }
               else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar el número de MBL"); }
               //((DOC001MView)_DOC001MView).ShowDialog();
            }
         }
         catch (Exception)
         { }
      }
      public Boolean NumerarHBL(ref String NumeroHBL)
      {
         try
         {
            if (Client.OPE_SaveCab_Cotizacion_OV_NumerarHBL(ref m_item, ref NumeroHBL, Session.UserName))
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha numerado satisfactoriamente el HBL con el Nro. " + NumeroHBL);
               return true;
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al numerar el HBL.");
               return false;
            }
         }
         catch (Exception)
         { return false; }
      }
      #endregion

      #region [ Metodos Matriz Draft ]
      public void ImprimirMatrizDraft()
      {
         try
         {
            System.Data.DataSet dsMatriz = Client.GetAllDet_CntrByPrintMatriz(Item.CCOT_Tipo, Item.CCOT_Numero);

            if (dsMatriz != null)
            {
               Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource();
               rds.Name = "DTMatrizDraft";
               rds.Value = dsMatriz.Tables[0];

               Microsoft.Reporting.WinForms.ReportDataSource rdsDetail = new Microsoft.Reporting.WinForms.ReportDataSource();
               rdsDetail.Name = "DTMatrizDraftDetail";
               rdsDetail.Value = dsMatriz.Tables[1];

               //String _path = "Delfin.Principal.Reportes.OPE001MatrizDraft.rptMatrizDraft.rdlc";
               String _path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Reportes\\rptMatrizDraft.rdlc";

               Visualizador _impresion = new Visualizador("Impresión Anexo", _path, rds, rdsDetail, null) { StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen };
               _impresion.Imprimir();
               _impresion.ShowDialog();
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se ha podido imprimir la Matriz Draft."); }
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos Correo & Archivos]
      public void Direccionamiento(Nullable<Int32> NVIA_Codigo, Int16 TIPO_Direccionamiento, Nullable<Int32> CCOT_Numero)
      {
         DtDireciomaniento = new System.Data.DataTable();
         DtDireciomaniento = Client.GetAllMBLsByNaveViaje(NVIA_Codigo, TIPO_Direccionamiento, CCOT_Numero);
      }

      public void DesgloseVoBo(Nullable<Int32> NVIA_Codigo, Int16 TIPO_VoBo, Nullable<Int32> CCOT_Numero)
      {
         DtVoBo = new System.Data.DataTable();
         DtVoBo = Client.GetAllDet_CntrByNaveViaje(NVIA_Codigo, TIPO_VoBo, CCOT_Numero);
      }

      public void Empresa()
      {
         try
         {
            Int32 Codigo_Empresa = Convert.ToInt32(PARA_CODIGOEMPRESA.PARA_Valor);
            ItemEmpresa = new Entidad();
            ItemEmpresa = Client.GetOneEntidad(Codigo_Empresa);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha Ocurrido un error al Traer los Datos de la Empresa", ex); }
      }

      public void CargaTarjada(Nullable<Int32> NVIA_Codigo, String TIPO_Embarque, Nullable<Int32> CCOT_Numero)
      {
         DtCargaTarjada = new System.Data.DataTable();
         DtCargaTarjada = Client.GetAllCargaTarjadaByNaveViaje(NVIA_Codigo, TIPO_Embarque, CCOT_Numero);
      }

      public void CorreoEmitirHBL(Nullable<Int32> NVIA_Codigo, Nullable<Int32> CCOT_Numero)
      {
         try
         {
            DtEmisionCorreoHBL = new System.Data.DataTable();
            DtEmisionCorreoHBL = Client.GetAllEmisionHBLByNaveViaje(NVIA_Codigo, CCOT_Numero);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public void CartasAvisos(Nullable<Int32> x_NVIA_Codigo, Nullable<Int32> x_CCOT_Numero)
      {
         try
         {
            DtAvisos = new System.Data.DataTable();
            DtAvisos = Client.GetAllAvisosByNaveViaje(x_NVIA_Codigo, x_CCOT_Numero,null,null);
         }
         catch (Exception ex)
         { throw ex; }
      }

      #region [ Cargo Manifiest ]
      public void GenerarCargoManifest()
      {
         System.Data.DataTable DtCargoManifest = new System.Data.DataTable();
         DtCargoManifest = Client.GetAllCab_Cotizacion_OVByCargoManifest(Item.CCOT_Numero, Item.CCOT_Tipo);
         if (DtCargoManifest != null && DtCargoManifest.Rows.Count > 0)
         {
            foreach (System.Data.DataRow drCargoManifest in DtCargoManifest.Rows)
            {
               XLExcel.Application xlApplication;
               XLExcel.Workbook xlWorkbook;
               XLExcel.Worksheet xlWorksheet;
               XLExcel.Range xlRange;

               object misValue = System.Reflection.Missing.Value;

               xlApplication = new XLExcel.Application();
               xlWorkbook = xlApplication.Workbooks.Add(misValue);
               xlWorksheet = (XLExcel.Worksheet)xlWorkbook.Worksheets[1];
               try
               {
                  if (Guardar(false, false))
                  {
                     xlWorksheet.Columns["A:A"].ColumnWidth = 2;
                     xlWorksheet.Columns["B:B"].ColumnWidth = 15;
                     xlWorksheet.Columns["C:C"].ColumnWidth = 15;
                     xlWorksheet.Columns["D:D"].ColumnWidth = 15;
                     xlWorksheet.Columns["E:E"].ColumnWidth = 35;
                     xlWorksheet.Columns["F:F"].ColumnWidth = 35;
                     xlWorksheet.Columns["G:G"].ColumnWidth = 35;
                     xlWorksheet.Columns["H:H"].ColumnWidth = 30;
                     xlWorksheet.Columns["I:I"].ColumnWidth = 10;
                     xlWorksheet.Columns["J:J"].ColumnWidth = 10;

                     xlWorksheet.Rows["1:1"].RowHeight = 14;
                     xlWorksheet.Rows["2:2"].RowHeight = 20;
                     xlWorksheet.Rows["3:3"].RowHeight = 14;
                     xlWorksheet.Rows["4:4"].RowHeight = 14;
                     xlWorksheet.Rows["5:5"].RowHeight = 14;
                     xlWorksheet.Rows["6:6"].RowHeight = 20;
                     xlWorksheet.Rows["7:7"].RowHeight = 14;
                     xlWorksheet.Rows["8:8"].RowHeight = 14;
                     xlWorksheet.Rows["9:9"].RowHeight = 14;
                     xlWorksheet.Rows["10:10"].RowHeight = 14;
                     xlWorksheet.Rows["15:15"].RowHeight = 20;
                     xlWorksheet.Rows["16:16"].RowHeight = 150;
                     xlWorksheet.Rows["17:17"].RowHeight = 14;

                     String _ruta = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\\logoDelfin.png");
                     System.Drawing.Image logoDelfin = System.Drawing.Image.FromFile(_ruta);
                     xlWorksheet.Shapes.AddPicture(_ruta, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 2f, 2f, 100, 80);

                     xlRange = xlWorksheet.Range["G3"];
                     SetValueCellCM(xlRange, "FREIGHT FORWARDER", "Bookman Old Style", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

                     xlRange = xlWorksheet.Range["C2:I2"];
                     SetValueHeaderCM(xlRange, "DELFIN GROUP CO SAC", "Bookman Old Style", 14);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

                     xlRange = xlWorksheet.Range["C6:I6"];
                     SetValueHeaderCM(xlRange, "*** CONSOLIDATION CARGO MANIFEST ***", "Arial", 12);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

                     xlRange = xlWorksheet.Range["B8"];
                     SetValueHeaderCM(xlRange, "FLIGHT", "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange = xlWorksheet.Range["B9"];
                     SetValueHeaderCM(xlRange, (Convert.ToString(drCargoManifest["NUMERO_VIAJE"])), "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

                     xlRange = xlWorksheet.Range["C8"];
                     SetValueHeaderCM(xlRange, "DATE", "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange = xlWorksheet.Range["C9"];
                     String _fecha = (Convert.ToString(drCargoManifest["FECHA"]));
                     if (!String.IsNullOrEmpty(_fecha))
                     {
                        DateTime fecha = Convert.ToDateTime(_fecha);
                        SetValueHeaderCM(xlRange, fecha.ToString("d"), "Arial", 10);
                     }
                     else
                     { SetValueHeaderCM(xlRange, " __/__/__ ", "Arial", 10); }
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

                     xlRange = xlWorksheet.Range["E8"];
                     SetValueHeaderCM(xlRange, "AGENT  :", "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange = xlWorksheet.Range["F8"];
                     SetValueHeaderCM(xlRange, (Convert.ToString(drCargoManifest["NOMBRE_AGENTE"])), "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

                     xlRange = xlWorksheet.Range["E9"];
                     SetValueHeaderCM(xlRange, "MAWB   :", "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange = xlWorksheet.Range["F9"];
                     SetValueHeaderCM(xlRange, (Convert.ToString(drCargoManifest["MBL"]).Trim()), "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

                     xlRange = xlWorksheet.Range["E10"];
                     SetValueHeaderCM(xlRange, "CARRIER NAME   :", "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange = xlWorksheet.Range["F10"];
                     SetValueHeaderCM(xlRange, (Convert.ToString(drCargoManifest["NOMBRE_LINEA"])), "Arial", 10);
                     //SetValueHeaderCM(xlRange, (Convert.ToString(drCargoManifest["NOMBRE_NAVE"])), "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

                     xlRange = xlWorksheet.Range["E11"];
                     SetValueHeaderCM(xlRange, "DEP A/P   :", "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange = xlWorksheet.Range["F11"];
                     SetValueHeaderCM(xlRange, (Convert.ToString(drCargoManifest["PORI_PAIS_NOMBRE"])), "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

                     xlRange = xlWorksheet.Range["E12"];
                     SetValueHeaderCM(xlRange, "DEST A/P   :", "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange = xlWorksheet.Range["F12"];
                     SetValueHeaderCM(xlRange, (Convert.ToString(drCargoManifest["PDES_PAIS_NOMBRE"])), "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

                     xlRange = xlWorksheet.Range["B15"];
                     SetValueHeaderCM(xlRange, "HAWB NO.", "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange = xlWorksheet.Range["B16"];
                     SetValueCellCM(xlRange, (Convert.ToString(drCargoManifest["HBL"])), "Arial", 8, true);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange.WrapText = true;
                     xlRange = xlWorksheet.Range["B17"];
                     SetValueHeaderCM(xlRange, "TOTAL   .", "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

                     xlRange = xlWorksheet.Range["C15"];
                     SetValueHeaderCM(xlRange, "PCS", "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange = xlWorksheet.Range["C16"];
                     SetValueCellCM(xlRange, (Convert.ToString(drCargoManifest["CANT_BULTOS"])), "Arial", 8, true);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange.WrapText = true;
                     xlRange = xlWorksheet.Range["C17"];
                     SetValueHeaderCM(xlRange, (Convert.ToString(drCargoManifest["CANT_BULTOS"])), "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange.WrapText = true;

                     xlRange = xlWorksheet.Range["D15"];
                     SetValueHeaderCM(xlRange, "WT (KG)", "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange = xlWorksheet.Range["D16"];
                     SetValueCellCM(xlRange, (Convert.ToString(drCargoManifest["CANT_PESO"])), "Arial", 8, true);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange.WrapText = true;
                     xlRange = xlWorksheet.Range["D17"];
                     SetValueHeaderCM(xlRange, (Convert.ToString(drCargoManifest["CANT_PESO"])), "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange.WrapText = true;

                     xlRange = xlWorksheet.Range["E15"];
                     SetValueHeaderCM(xlRange, "SHIPPER NAME", "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange = xlWorksheet.Range["E16"];
                     SetValueCellCM(xlRange, (Convert.ToString(drCargoManifest["ENTC_SHIPPER"])), "Arial", 8, true);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange.WrapText = true;

                     xlRange = xlWorksheet.Range["F15"];
                     SetValueHeaderCM(xlRange, "CONSIGNEE NAME", "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange = xlWorksheet.Range["F16"];
                     SetValueCellCM(xlRange, (Convert.ToString(drCargoManifest["ENTC_CONSIGNEE"])), "Arial", 8, true);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange.WrapText = true;

                     xlRange = xlWorksheet.Range["G15"];
                     SetValueHeaderCM(xlRange, "COMMODITY", "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange = xlWorksheet.Range["G16"];
                     SetValueCellCM(xlRange, (Convert.ToString(drCargoManifest["DESC_PRODUCTO"])), "Arial", 8, true);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange.WrapText = true;

                     xlRange = xlWorksheet.Range["H15"];
                     SetValueHeaderCM(xlRange, "FINAL DESTINATION", "Arial", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange = xlWorksheet.Range["H16"];
                     SetValueCellCM(xlRange, (Convert.ToString(drCargoManifest["PDES_NOMBRE"])), "Arial", 8, true);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange.WrapText = true;

                     xlRange = xlWorksheet.Range["C23:I23"];
                     SetValueHeaderCM(xlRange, "Calle Antequera Nº 777 piso 12 – San Isidro, Lima 27 – Perú", "Times New Roman", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlHairline, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange.Font.Bold = false;
                     xlRange = xlWorksheet.Range["C24:I24"];
                     SetValueHeaderCM(xlRange, "Telf. (51) (1) 615-3535    Fax: (51) (1) 615-3553", "Times New Roman", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlHairline, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     xlRange.Font.Bold = false;
                     xlRange = xlWorksheet.Range["C25:I25"];
                     SetValueHeaderCM(xlRange, "www.delfingroupco.com", "Times New Roman", 10);
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlHairline, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

                     xlApplication.Visible = true;

                  }
               }
               catch (Exception)
               { }
               finally
               {
                  if (xlWorksheet != null) { releaseObject(xlWorksheet); }
                  if (xlWorkbook != null) { releaseObject(xlWorkbook); }
                  if (xlApplication != null) { releaseObject(xlApplication); }
               }
            }
         }
         else
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "La Orden de Venta no contiene detalles"); }
      }
      private void SetValueCM(XLExcel.Range xlRange, Object xlValue, String xlFontName, Int32 xlFontSize, Boolean xlMergeCells = false, XLExcel.XlVAlign xlVAlign = XLExcel.XlVAlign.xlVAlignCenter, XLExcel.XlHAlign xlHAlign = XLExcel.XlHAlign.xlHAlignCenter, Boolean xlBold = false, Boolean xlUnderline = false)
      {
         xlRange.MergeCells = xlMergeCells;
         xlRange.Value = xlValue;
         xlRange.Font.Name = xlFontName;
         xlRange.Font.Size = xlFontSize;
         xlRange.Font.Bold = xlBold;
         xlRange.Font.Underline = xlUnderline;
         xlRange.VerticalAlignment = xlVAlign;
         xlRange.HorizontalAlignment = xlHAlign;
      }
      private void SetValueHeaderCM(XLExcel.Range xlRange, Object xlValue, String xlFontName, Int32 xlFontSize, Boolean xlMergeCells = true, XLExcel.XlVAlign xlVAlign = XLExcel.XlVAlign.xlVAlignCenter, XLExcel.XlHAlign xlHAlign = XLExcel.XlHAlign.xlHAlignCenter, Boolean xlBold = true, Boolean xlUnderline = false)
      { SetValueCM(xlRange, xlValue, xlFontName, xlFontSize, xlMergeCells, xlVAlign, xlHAlign, xlBold, xlUnderline); }
      private void SetValueCellCM(XLExcel.Range xlRange, Object xlValue, String xlFontName, Int32 xlFontSize, Boolean xlMergeCells = false, XLExcel.XlVAlign xlVAlign = XLExcel.XlVAlign.xlVAlignTop, XLExcel.XlHAlign xlHAlign = XLExcel.XlHAlign.xlHAlignLeft, Boolean xlBold = false, Boolean xlUnderline = false)
      { SetValueCM(xlRange, xlValue, xlFontName, xlFontSize, xlMergeCells, xlVAlign, xlHAlign, xlBold, xlUnderline); }
      #endregion
      #endregion

      #region [ Metodos Via Aerea ]
      public void ImprimirEtiquetas()
      {
         try
         {
            System.Data.DataTable dtEtiqueta = Client.OPE_GetOneCab_Cotizacion_OVImpresionEtiqueta(Item.CCOT_Tipo, Item.CCOT_Numero);

            if (dtEtiqueta != null && dtEtiqueta.Rows.Count > 0)
            {
               Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource();
               rds.Name = "DTEtiqueta";
               rds.Value = dtEtiqueta;

               //String _path = "Delfin.Principal.Reportes.OPE001Etiqueta.rtpEtiqueta.rdlc";
               String _path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Reportes\\rtpEtiqueta.rdlc";
               Int32 _bultos = 0;
               if (Int32.TryParse(dtEtiqueta.Rows[0]["DCOT_Bultos"].ToString(), out _bultos))
               {
                  Microsoft.Reporting.WinForms.ReportParameter[] _parameters = new Microsoft.Reporting.WinForms.ReportParameter[1];
                  _parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("parCantidad", _bultos.ToString());

                  //System.Windows.Forms.PrintDialog _dialog = new System.Windows.Forms.PrintDialog();
                  //if (_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                  //{
                  //   Impresora = _dialog.PrinterSettings.PrinterName;

                  Visualizador _impresion = new Visualizador("Impresión Etiquetas", _path, rds, _parameters) { StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen };
                  //_impresion.ListoImprimir += _impresion_ListoImprimir;
                  //_impresion.Viewer.PrinterSettings.PrinterName = _dialog.PrinterSettings.PrinterName;

                  for (int i = 0; i < _bultos; i += 8)
                  {
                     _impresion.Imprimir(false);
                     _impresion.Viewer.RefreshReport();
                     _impresion.ShowDialog();
                  }
                  //}
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se ha podido imprimir la Matriz Draft."); }
         }
         catch (Exception)
         { }
      }
      private String Impresora;
      private void _impresion_ListoImprimir(Microsoft.Reporting.WinForms.ReportViewer e)
      {
         try
         {
            if (!String.IsNullOrEmpty(Impresora))
            { PrintReportViewer.PrintByPriner(e, Impresora); }
            else
            {
               StringBuilder dp = new StringBuilder(256);
               int size = dp.Capacity;
               if (PrintReportViewer.GetDefaultPrinter(dp, ref size))
               { PrintReportViewer.PrintByPriner(e, dp.ToString().Trim()); }
            }
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos Servicios ChangeControl ]
      public Boolean EnviarFinanzas(ref Entities.Det_Cotizacion_OV_Servicio ItemDet_Cotizacion_OV_Servicio)
      {
         try
         {
            System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea enviar a finanzas el registro seleccionado?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
            if (_result == System.Windows.Forms.DialogResult.Yes)
            {
                DateTime l_fecha = ItemDet_Cotizacion_OV_Servicio.SCOT_FechaOperacion == null ? DateTime.Now : Convert.ToDateTime(ItemDet_Cotizacion_OV_Servicio.SCOT_FechaOperacion);
                var _itemTipoCambio = Client.GetOneTiposCambio(l_fecha.ToString("yyyyMMdd"));

               if (_itemTipoCambio != null)
               {
                  if (ItemDet_Cotizacion_OV_Servicio.Validar())
                  {
                     ItemDet_Cotizacion_OV_Servicio.CCOT_Tipo = Item.CCOT_Tipo;
                     ItemDet_Cotizacion_OV_Servicio.CCOT_Numero = Item.CCOT_Numero;
                     ItemDet_Cotizacion_OV_Servicio.SCOT_EnviarFinanzas = true;
                     if (ItemDet_Cotizacion_OV_Servicio.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
                     {
                        ItemDet_Cotizacion_OV_Servicio.AUDI_UsrCrea = Session.UserName;
                        ItemDet_Cotizacion_OV_Servicio.AUDI_FecCrea = Session.Fecha;
                     }
                     else if (ItemDet_Cotizacion_OV_Servicio.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified)
                     {
                        ItemDet_Cotizacion_OV_Servicio.AUDI_UsrMod = Session.UserName;
                        ItemDet_Cotizacion_OV_Servicio.AUDI_FecMod = Session.Fecha;
                     }
                     else if (ItemDet_Cotizacion_OV_Servicio.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
                     {
                        ItemDet_Cotizacion_OV_Servicio.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                        ItemDet_Cotizacion_OV_Servicio.AUDI_UsrMod = Session.UserName;
                        ItemDet_Cotizacion_OV_Servicio.AUDI_FecMod = Session.Fecha;
                     }

                     bool _resultado = Client.SaveDet_Cotizacion_OV_Servicio(ref ItemDet_Cotizacion_OV_Servicio, true);
                     
                     ItemDet_Cotizacion_OV_Servicio.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged;
                     ItemDet_Cotizacion_OV_Servicio.SCOT_Editable = false;
                     ItemDet_Cotizacion_OV_Servicio.SCOT_EnviarFinanzas = false;
                     
                     return _resultado;
                  }
                  else
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Se han encontrado algunos errores, revisar los detalles.", ItemDet_Cotizacion_OV_Servicio.MensajeError);
                     return false;
                  }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar el Tipo de Cambio para la fecha " + l_fecha.ToShortDateString()); return false; }
            }
            return false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un errro al enviar a Finanzas el registro seleccionado.", ex); return false; }
      }
      #endregion
   }
}