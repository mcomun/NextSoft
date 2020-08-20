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


namespace Delfin.Comercial
{
   public partial class COM007Presenter
   {
       AppService.DelfinServiceClient oAppService = new AppService.DelfinServiceClient();

      #region [ Variables ]
      public String Title = "Cotización";
      public String CUS = "COM007";
      public Boolean FleteNegativo = false;
      #endregion

      #region [ Contrusctor ]
      public COM007Presenter(IUnityContainer x_container, ICOM007LView x_lview, ICOM007MView x_mview, Int16 x_CCOT_Tipo)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
            this.MView = x_mview;
            this.CCOT_Tipo = x_CCOT_Tipo;
            if (x_CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion)
            { CUS = "COM007"; }
            else
            { CUS = "COM008"; }
         }
         catch (Exception)
         { throw; }
      }
      public COM007Presenter(IUnityContainer x_container, ICOM007MView x_mview, Int16 x_CCOT_Tipo)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.MView = x_mview;
            this.CCOT_Tipo = x_CCOT_Tipo;
            if (x_CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion)
            { CUS = "COM007"; }
            else
            { CUS = "COM008"; }
         }
         catch (Exception)
         { throw; }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();


            //ListPuertos = Client.GetAllPuerto();
            ListPaquetes = Client.GetAllPaquete();
            ListTiposPAC = Client.GetAllTiposByTipoCodTabla("PAC");
            ListTiposCDT = Client.GetAllTiposByTipoCodTabla("CDT");
            ListTiposUNM = Client.GetAllTiposByTipoCodTabla("UNM");
            ListTiposMND = Client.GetAllTiposByTipoCodTabla("MND");
            ListTiposEVE = Client.GetAllTiposByTipoCodTabla("EVE");
            ListTiposTDO = Client.GetAllTiposByTipoCodTabla("TDO");
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

            LoadParameteres();

            VerCostoFCL = false;
            NextAdmin.Views.PAutenticacionPresenter m_autenciacionPresenter = new NextAdmin.Views.PAutenticacionPresenter(null, ContainerService);
            var BL_PermisosUsuarioProcesos = ContainerService.Resolve<NextAdmin.BusinessLogic.IBLPermisosUsuarioProcesos>();
            NextAdmin.BusinessLogic.PermisosUsuarioProcesos _itemPermisosUsuarioProcesos = BL_PermisosUsuarioProcesos.GetOneByUsuario(Session.AplicacionCodigo.Value, Session.UserCodigo, Delfin.Controls.variables.CCOT_VERCOSTOFCL);
            if (_itemPermisosUsuarioProcesos != null && _itemPermisosUsuarioProcesos.PUPR_Codigo > 0)
            { VerCostoFCL = true; }

            if (LView != null) { LView.LoadView(CCOT_Tipo); }
            MView.LoadView(CCOT_Tipo);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }


      public Int16 CCOT_Tipo { get; set; }

      public ICOM007LView LView { get; set; }
      public ICOM007MView MView { get; set; }

      public Cab_Cotizacion_OV Item { get; set; }
      public Cab_Cotizacion_OV ItemLView { get; set; }
      public ObservableCollection<Cab_Cotizacion_OV> Items { get; set; }
      public Boolean VerCostoFCL { get; set; }

      //public ObservableCollection<Puerto> ListPuertos { get; set; }
      public ObservableCollection<Paquete> ListPaquetes { get; set; }
      public ObservableCollection<Tipos> ListTiposCDT { get; set; }
      public ObservableCollection<Tipos> ListTiposPAC { get; set; }
      public ObservableCollection<Tipos> ListTiposUNM { get; set; }
      public ObservableCollection<Tipos> ListTiposMND { get; set; }
      public ObservableCollection<Tipos> ListTiposEVE { get; set; }
      public ObservableCollection<Tipos> ListTiposTDO { get; set; }
      public ObservableCollection<Constantes> ListConstantesBAS { get; set; }
      public ObservableCollection<Constantes> ListConstantesMOD { get; set; }
      public ObservableCollection<Servicio> ListServicio { get; set; }
      public ObservableCollection<TiposEntidad> ListTiposEntidad { get; set; }
      public ObservableCollection<Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem> ListIngresoEgreso { get; set; }
      public ObservableCollection<Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem> ListOrigen { get; set; }
      #endregion

      #region [ Parametros ]
      public Entities.Parametros PARA_EAGENTE_SHANGHAI { get; set; }
      public Entities.Parametros PARA_PAIS_MANDATO { get; set; }

      private void LoadParameteres()
      {
         try
         {
            var ItemsPARAMETRO = Client.GetAllParametros();

            PARA_EAGENTE_SHANGHAI = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "EAGENTE_SHANGHAI");
            PARA_PAIS_MANDATO = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "PAIS_MANDATO");
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos ]
      public Constantes FILTROItemCONSRGM { get; set; }
      public Constantes FILTROItemCONSFLE { get; set; }
      public Constantes FILTROItemCONSVia { get; set; }
      public Constantes FILTROItemCONSEST { get; set; }
      public Entidad FILTROItemEjecutivo { get; set; }
      public Entidad FILTROItemCustomer { get; set; }
      public Entidad FILTROItemAgente { get; set; }
      public Entidad FILTROItemBroker { get; set; }
      public Entidad FILTROItemCliente { get; set; }
      public Nullable<DateTime> FILTROCCOT_FecEmiDesde { get; set; }
      public Nullable<DateTime> FILTROCCOT_FecEmiHasta { get; set; }
      public String FILTROCCOT_NumDoc { get; set; }
      public String FILTRODOOV_HBL { get; set; }
      public Nullable<Decimal> FILTRONoCRM { get; set; }
      public void Actualizar()
      {
         try
         {
            ItemLView = null;
            Items = null;

            if (LView != null)
            {
               String CONS_TabRGM = null; if (FILTROItemCONSRGM != null) { CONS_TabRGM = FILTROItemCONSRGM.CONS_CodTabla; }
               String CONS_CodRGM = null; if (FILTROItemCONSRGM != null) { CONS_CodRGM = FILTROItemCONSRGM.CONS_CodTipo; }
               String CONS_TabFLE = null; if (FILTROItemCONSFLE != null) { CONS_TabFLE = FILTROItemCONSFLE.CONS_CodTabla; }
               String CONS_CodFLE = null; if (FILTROItemCONSFLE != null) { CONS_CodFLE = FILTROItemCONSFLE.CONS_CodTipo; }
               String CONS_TabVia = null; if (FILTROItemCONSVia != null) { CONS_TabVia = FILTROItemCONSVia.CONS_CodTabla; }
               String CONS_CodVia = null; if (FILTROItemCONSVia != null) { CONS_CodVia = FILTROItemCONSVia.CONS_CodTipo; }
               String CONS_TabEST = null; if (FILTROItemCONSEST != null) { CONS_TabEST = FILTROItemCONSEST.CONS_CodTabla; }
               String CONS_CodEST = null; if (FILTROItemCONSEST != null) { CONS_CodEST = FILTROItemCONSEST.CONS_CodTipo; }

               Nullable<Int32> ENTC_CodEjecutivo = null; if (FILTROItemEjecutivo != null) { ENTC_CodEjecutivo = FILTROItemEjecutivo.ENTC_Codigo; }
               Nullable<Int32> ENTC_CodCustomer = null; if (FILTROItemCustomer != null) { ENTC_CodCustomer = FILTROItemCustomer.ENTC_Codigo; }
               Nullable<Int32> ENTC_CodAgente = null; if (FILTROItemAgente != null) { ENTC_CodAgente = FILTROItemAgente.ENTC_Codigo; }
               Nullable<Int32> ENTC_CodBroker = null; if (FILTROItemBroker != null) { ENTC_CodBroker = FILTROItemBroker.ENTC_Codigo; }
               Nullable<Int32> ENTC_CodCliente = null; if (FILTROItemCliente != null) { ENTC_CodCliente = FILTROItemCliente.ENTC_Codigo; }
               Nullable<DateTime> CCOT_FecEmiDesde = FILTROCCOT_FecEmiDesde;
               Nullable<DateTime> CCOT_FecEmiHasta = FILTROCCOT_FecEmiHasta;

               String CCOT_NumDoc = null; if (!String.IsNullOrEmpty(FILTROCCOT_NumDoc)) { CCOT_NumDoc = FILTROCCOT_NumDoc; }
               String DOOV_HBL = null; if (!String.IsNullOrEmpty(FILTRODOOV_HBL)) { DOOV_HBL = FILTRODOOV_HBL; }
               Nullable<Decimal> NoCRM = null; if (FILTRONoCRM != null) { NoCRM = FILTRONoCRM; }

               Items = Client.GetAllCab_Cotizacion_OVByFiltro(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, CCOT_Tipo, CONS_TabRGM, CONS_CodRGM, CONS_TabFLE, CONS_CodFLE, CONS_TabVia, CONS_CodVia, CONS_TabEST, CONS_CodEST, ENTC_CodEjecutivo, ENTC_CodCustomer, ENTC_CodAgente, ENTC_CodBroker, ENTC_CodCliente, CCOT_FecEmiDesde, CCOT_FecEmiHasta, CCOT_NumDoc, DOOV_HBL, NoCRM);

               LView.ShowItems();
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
               MView = new COM007MView();
               MView.Presenter = this;
               MView.LoadView(this.CCOT_Tipo);
            }

            MView.ClearItem();
            this.Item = new Cab_Cotizacion_OV();
            this.Item.CCOT_Tipo = CCOT_Tipo;
            this.Item.CCOT_Version = 1;
            if (CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion)
            {
               //this.Item.CCOT_NumDoc = "20014-000001";
               this.Item.CONS_TabEST = "COT";
               this.Item.CONS_CodEST = "001";
            }
            else
            {
               this.Item.CONS_TabEST = "OVE";
               this.Item.CONS_CodEST = "001";
            }
            this.Item.CCOT_FecEmi = Session.Fecha;
            this.Item.CCOT_FecVcto = Session.Fecha;
            this.Item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            this.Item.SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
            this.Item.CCOT_EnviaAvisoLlegada = true;
            this.Item.AUDI_UsrCrea = Session.UserName;
            this.Item.AUDI_FecCrea = Session.Fecha;
            this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            MView.SetItem();

            isMViewShow = true;
            ((COM007MView)MView).Show();
            ((COM007MView)MView).BringToFront();
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
               MView = new COM007MView();
               MView.Presenter = this;
               MView.LoadView(this.CCOT_Tipo);
            }

            if (ItemLView != null)
            {
               Item = Client.GetOneCab_Cotizacion_OV(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, ItemLView.CCOT_Numero, ItemLView.CCOT_Tipo);

               if (Item != null)
               {
                  MView.ClearItem();
                  this.Item.AUDI_UsrMod = Session.UserName;
                  //this.Item.AUDI_FecMod = Session.Fecha;
                  this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                  MView.SetItem();

                  isMViewShow = true;
                  ((COM007MView)MView).Show();
                  ((COM007MView)MView).BringToFront();
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "El registro no se encuentra en la BD."); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }
      public void Versionar()
      {
         try
         {
            if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea Versionar el Item Seleccionado?", null) == System.Windows.Forms.DialogResult.OK)
            {
               if (!isMViewShow)
               {
                  MView = new COM007MView();
                  MView.Presenter = this;
                  MView.LoadView(this.CCOT_Tipo);
               }

               String MensajeError = String.Empty;
               if (ItemLView != null)
               {
                  Item = Client.GetOneCab_Cotizacion_OVNuevaVersion(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, ItemLView.CCOT_Numero, ItemLView.CCOT_Tipo, Session.UserName, ref MensajeError);

                  if (Item != null)
                  {
                     MView.ClearItem();
                     this.Item.AUDI_UsrMod = Session.UserName;
                     this.Item.AUDI_FecMod = Session.Fecha;
                     this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                     MView.SetItem();

                     Actualizar();

                     //((COM007MView)MView).ShowDialog();
                     isMViewShow = true;
                     ((COM007MView)MView).Show();
                     ((COM007MView)MView).BringToFront();
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se ha podido Versionar el Item Seleccionado.", MensajeError); }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }
      public void Copiar()
      {
         try
         {
            if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea Copiar el Item Seleccionado?", null) == System.Windows.Forms.DialogResult.OK)
            {
               if (!isMViewShow)
               {
                  MView = new COM007MView();
                  MView.Presenter = this;
                  MView.LoadView(this.CCOT_Tipo);
               }

               if (ItemLView != null)
               {
                  Item = Client.GetOneCab_Cotizacion_OVNuevaCopia(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, ItemLView.CCOT_Numero, ItemLView.CCOT_Tipo, Session.UserName);

                  if (Item != null)
                  {
                     MView.ClearItem();
                     this.Item.AUDI_UsrMod = Session.UserName;
                     this.Item.AUDI_FecMod = Session.Fecha;
                     this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                     MView.SetItem();

                     Actualizar();

                     //((COM007MView)MView).ShowDialog();
                     isMViewShow = true;
                     ((COM007MView)MView).Show();
                     ((COM007MView)MView).BringToFront();
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }
      public void Presupuestar()
      {
         try
         {
            if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea Coordinar el Items Seleccionado?", null) == System.Windows.Forms.DialogResult.OK)
            {
               if (!isMViewShow)
               {
                  MView = new COM007MView();
                  MView.Presenter = this;
                  MView.LoadView(this.CCOT_Tipo);
               }

               if (ItemLView != null)
               {
                  Item = Client.GetOneCab_Cotizacion_OVNuevoPresupuesto(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, ItemLView.CCOT_Numero, ItemLView.CCOT_Tipo, Session.UserName);

                  if (Item != null)
                  {
                     MView.ClearItem();
                     this.Item.AUDI_UsrMod = Session.UserName;
                     this.Item.AUDI_FecMod = Session.Fecha;
                     this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                     MView.SetItem();

                     Actualizar();

                     //((COM007MView)MView).ShowDialog();
                     isMViewShow = true;
                     ((COM007MView)MView).Show();
                     ((COM007MView)MView).BringToFront();
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }
      public void Coordinar()
      {
         try
         {
            if (this.ItemLView != null)
            {
               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea Coordinar la Orden de Venta Seleccionada?", null) == System.Windows.Forms.DialogResult.OK)
               {
                  //Item = Client.GetOneCab_Cotizacion_OV(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, Item.CCOT_Numero, Item.CCOT_Tipo);
                  //this.Item.CONS_TabEST = "OVE";
                  //this.Item.CONS_CodEST = Delfin.Controls.variables.CONS_ESTOVECOORDINADA;
                  //this.Item.AUDI_UsrMod = Session.UserName;
                  //this.Item.AUDI_FecMod = Session.Fecha;
                  //this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;

                  Int16 CCOT_Tipo = ItemLView.CCOT_Tipo;
                  Int32 CCOT_Numero = ItemLView.CCOT_Numero;
                  String CONS_TabEST = "OVE";
                  String CONS_CodEST = Delfin.Controls.variables.CONS_ESTOVECOORDINADA;
                  String Usuario = Session.UserName;
                  DateTime Fecha = Session.Fecha;
                  String CCOT_MensajeError = "";

                  if (Client.SaveCab_Cotizacion_OVEstado(CCOT_Tipo, CCOT_Numero, CONS_TabEST, CONS_CodEST, Usuario, Fecha, ref CCOT_MensajeError))
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha coordinado satisfactoriamente");
                     Actualizar();
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al coordinar el item."); }
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un item para poder coordinarlo."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al coordinar la Orden de Venta", ex); }
      }
      public void AutorizarConfirmar()
      {
         try
         {
            if (this.ItemLView != null)
            {
               if (ItemLView.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion)
               { AutorizarCotizacion(); }
               else if (ItemLView.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
               { ConfirmarOrdenVenta(); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un item para poder aprobarlo."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al aprobar la Cotización", ex); }
      }
      private void AutorizarCotizacion()
      {
         try
         {
            if (this.ItemLView != null)
            {
               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea Aprobar la Cotización Seleccionada?", null) == System.Windows.Forms.DialogResult.OK)
               {

                  Int32 _CCOT_NivelAprobacion = Client.GetOneCab_Cotizacion_OVNivelAprobacion(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, ItemLView.CCOT_Tipo, ItemLView.CCOT_Numero);
                  String PROC_DescC = Delfin.Controls.variables.CCOT_APROCOTIZ1;
                  if (_CCOT_NivelAprobacion > 0)
                  {
                     switch (_CCOT_NivelAprobacion)
                     {
                        case 1:
                           PROC_DescC = Delfin.Controls.variables.CCOT_APROCOTIZ1;
                           break;
                        case 2:
                           PROC_DescC = Delfin.Controls.variables.CCOT_APROCOTIZ2;
                           break;
                        case 3:
                           PROC_DescC = Delfin.Controls.variables.CCOT_APROCOTIZ3;
                           break;
                        case 4:
                           PROC_DescC = Delfin.Controls.variables.CCOT_APROCOTIZ4;
                           break;
                        default:
                           PROC_DescC = Delfin.Controls.variables.CCOT_APROCOTIZ1;
                           break;
                     }
                  }

                  NextAdmin.Views.PAutenticacionPresenter m_autenciacionPresenter = new NextAdmin.Views.PAutenticacionPresenter(null, ContainerService);
                  if (m_autenciacionPresenter.AutenticarProceso(Session.AplicacionCodigo.Value, PROC_DescC) == System.Windows.Forms.DialogResult.Yes)
                  {
                     //Item = Client.GetOneCab_Cotizacion_OV(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, Item.CCOT_Numero, Item.CCOT_Tipo);
                     //this.Item.CONS_TabEST = "COT";
                     //this.Item.CONS_CodEST = Delfin.Controls.variables.CONS_ESTCOTAUTORIZADA;
                     //this.Item.AUDI_UsrMod = Session.UserName;
                     //this.Item.AUDI_FecMod = Session.Fecha;
                     //this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;

                     Int16 CCOT_Tipo = ItemLView.CCOT_Tipo;
                     Int32 CCOT_Numero = ItemLView.CCOT_Numero;
                     String CONS_TabEST = "COT";
                     String CONS_CodEST = Delfin.Controls.variables.CONS_ESTCOTAUTORIZADA;
                     String Usuario = Session.UserName;
                     DateTime Fecha = Session.Fecha;
                     String CCOT_MensajeError = "";

                     if (Client.SaveCab_Cotizacion_OVEstado(CCOT_Tipo, CCOT_Numero, CONS_TabEST, CONS_CodEST, Usuario, Fecha, ref CCOT_MensajeError))
                     {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha aprobado satisfactoriamente");
                        Actualizar();
                     }
                     else
                     { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al aprobar el item."); }
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ud. no cuenta con los permisos necesarios para aprobar la Cotización."); }
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un item para poder aprobarlo."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al aprobar la Cotización", ex); }
      }
      private void ConfirmarOrdenVenta()
      {
         try
         {
            if (this.ItemLView != null)
            {

               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea Confirmar la Orden de Venta Seleccionada?", null) == System.Windows.Forms.DialogResult.OK)
               {
                  //Item = Client.GetOneCab_Cotizacion_OV(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, Item.CCOT_Numero, Item.CCOT_Tipo);
                  //this.Item.CONS_TabEST = "OVE";
                  //this.Item.CONS_CodEST = Delfin.Controls.variables.CONS_ESTOVECONFIRMADA;
                  //this.Item.AUDI_UsrMod = Session.UserName;
                  //this.Item.AUDI_FecMod = Session.Fecha;
                  //this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;

                  Int16 CCOT_Tipo = ItemLView.CCOT_Tipo;
                  Int32 CCOT_Numero = ItemLView.CCOT_Numero;
                  String CONS_TabEST = "OVE";
                  String CONS_CodEST = Delfin.Controls.variables.CONS_ESTOVECONFIRMADA;
                  String Usuario = Session.UserName;
                  DateTime Fecha = Session.Fecha;
                  String CCOT_MensajeError = "";

                  if (Client.SaveCab_Cotizacion_OVEstado(CCOT_Tipo, CCOT_Numero, CONS_TabEST, CONS_CodEST, Usuario, Fecha, ref CCOT_MensajeError))
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha confirmado satisfactoriamente");
                     Actualizar();
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al confirmar el item."); }
               }

            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un item para poder confirmarlo."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al confirmar la Orden de Venta", ex); }
      }

      public void ActualizarCRM()
      {

          System.Data.DataSet dsCotizacion = new System.Data.DataSet();
          dsCotizacion = oAppService.ExecuteSQL("EXEC NextSoft.dbo.TCOM_SP_CONSULTAR_Cab_Cotizacion_OV_Related " + Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo + "," + Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo + "," + ItemLView.CCOT_Numero.ToString() + "," + ItemLView.CCOT_Tipo.ToString());

          if (dsCotizacion.Tables[0].Rows[0]["CCOT_NumPresupuesto"].ToString() == "")
          {
              { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Sólo puede actualizar una cotización generada desde el CRM.");
              return;
              }
          }
          ActualizaOportunidadCrm ActualizaCRM = new ActualizaOportunidadCrm();
          ActualizaOportunidadCrm.CotizacionDTO oCotizacion = new ActualizaOportunidadCrm.CotizacionDTO();
          oCotizacion.idCRM = dsCotizacion.Tables[0].Rows[0]["CCOT_NumPresupuesto"].ToString();
          oCotizacion.regimen = dsCotizacion.Tables[0].Rows[0]["CONS_DescRGM"].ToString();
          oCotizacion.via = dsCotizacion.Tables[0].Rows[0]["CONS_DescVia"].ToString();
          oCotizacion.lineaNegocio = dsCotizacion.Tables[0].Rows[0]["CONS_DescLNG"].ToString();
          oCotizacion.fechaEmision = ((System.DateTime)(dsCotizacion.Tables[0].Rows[0]["CCOT_FecEmi"])).Date.ToString("yyyy-MM-dd");
          oCotizacion.docIden = dsCotizacion.Tables[0].Rows[0]["ENTC_DocIdenCliente"].ToString();
          oCotizacion.trafico = dsCotizacion.Tables[0].Rows[0]["TIPO_DescTRF"].ToString();
          oCotizacion.fechaVcto = ((System.DateTime)(dsCotizacion.Tables[0].Rows[0]["CCOT_FecVcto"])).Date.ToString("yyyy-MM-dd");
          oCotizacion.seguro=false;
          oCotizacion.servicioLogistico = bool.Parse(dsCotizacion.Tables[0].Rows[0]["CCOT_ServicioLogistico"].ToString());
          oCotizacion.codigoPuertoOrigen=dsCotizacion.Tables[0].Rows[0]["PUER_CodEstandarOrigen"].ToString();
          oCotizacion.codigoPaisOrigen = oCotizacion.codigoPuertoOrigen.Substring(0, 2);
          oCotizacion.codigoPuertoDestino=dsCotizacion.Tables[0].Rows[0]["PUER_CodEstandarDestino"].ToString();
          oCotizacion.codigoPaisDestino = oCotizacion.codigoPuertoDestino.Substring(0, 2);
          oCotizacion.transportista=dsCotizacion.Tables[0].Rows[0]["ENTC_NomTransportista"].ToString();
          oCotizacion.condicionEmbarque=dsCotizacion.Tables[0].Rows[0]["CONS_DescFLE"].ToString();
          oCotizacion.condicionPagoMBL=dsCotizacion.Tables[0].Rows[0]["CCOT_PagoMBL"].ToString();
          oCotizacion.condicionPagoHBL=dsCotizacion.Tables[0].Rows[0]["CCOT_PagoHBL"].ToString();
          oCotizacion.numeroContrato=dsCotizacion.Tables[0].Rows[0]["CONT_Numero"].ToString();
          oCotizacion.referencia=dsCotizacion.Tables[0].Rows[0]["DOOV_CodReferencia"].ToString();
          oCotizacion.observaciones=dsCotizacion.Tables[0].Rows[0]["CCOT_Observaciones"].ToString();
          oCotizacion.usuario=dsCotizacion.Tables[0].Rows[0]["ENTC_EmailEjecutivo"].ToString();
          oCotizacion.codigoMoneda=dsCotizacion.Tables[0].Rows[0]["TIPO_DescCMND"].ToString();
          oCotizacion.numeroCotizacion=dsCotizacion.Tables[0].Rows[0]["CCOT_NumDoc"].ToString();
          oCotizacion.versionCotizacion=dsCotizacion.Tables[0].Rows[0]["CCOT_Version"].ToString();
          oCotizacion.ContenedorList = new List<ActualizaOportunidadCrm.ContenedorDTO>();
          foreach (System.Data.DataRow drContainer in dsCotizacion.Tables[2].Rows)
          {
              oCotizacion.ContenedorList.Add(new ActualizaOportunidadCrm.ContenedorDTO() { tipoContenedor = drContainer["PACK_DescC"].ToString(), cantidadTipoContenedor = Convert.ToInt32(drContainer["DCOT_Cantidad"]), precioUnitarioTipoContenedor = Convert.ToDouble(drContainer["DCOT_PrecioUniVenta"]), importeTotalTipoContenedor = Convert.ToDouble(drContainer["DCOT_TotalUniVenta"]) });
          }

          if (ActualizaCRM.SendData(oCotizacion) == true)
          {
              Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Los datos han sido actualizados satisfactoriamente.");
          }

      }

      public void GenerarOV()
      {
         try
         {
            if (ItemLView != null)
            {
               if (ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTAUTORIZADA && ItemLView.CCOT_FecVcto >= Session.Fecha.Date)
               {
                  Item = Client.GetOneCab_Cotizacion_OVNuevoOrdenVenta(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, ItemLView.CCOT_Numero, ItemLView.CCOT_Tipo, Delfin.Controls.variables.CCOT_TipoOrdenVenta, Session.UserName);
                  if (Item != null)
                  {
                      //ZOHO WS

                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha generado la Orden de Venta satisfactoriamente.");

                     //COM007MView COM008_mview = new COM007MView();
                     //COM007Presenter COM008_presenter = new COM007Presenter(this.ContainerService, COM008_mview, Delfin.Controls.variables.CCOT_TipoOrdenVenta);
                     //COM008_mview.Presenter = COM008_presenter;
                     //COM008_presenter.Load();

                     //COM008_presenter.Item = Item;
                     //COM008_presenter.Editar();

                     //try
                     //{
                     //    ActualizarCRM();
                     //}
                     //catch (Exception ex)
                     //{ Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }

                     Actualizar();
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al generar la Orden de Venta."); }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "El item seleccionado ya no puede convertirse en Orden de Venta."); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }
      public void Concluir()
      {
         try
         {
            if (this.ItemLView != null)
            {
               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea Concluir la Orden de Venta Seleccionada?", null) == System.Windows.Forms.DialogResult.OK)
               {
                  //Item = Client.GetOneCab_Cotizacion_OV(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, Item.CCOT_Numero, Item.CCOT_Tipo);
                  //this.Item.CONS_TabEST = "OVE";
                  //this.Item.CONS_CodEST = Delfin.Controls.variables.CONS_ESTOVECOORDINADA;
                  //this.Item.AUDI_UsrMod = Session.UserName;
                  //this.Item.AUDI_FecMod = Session.Fecha;
                  //this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;

                  if (ItemLView.CCOT_ServicioTransmision || ItemLView.ValidarFechaTarifa())
                  {
                     if (ItemLView.NVIA_Codigo.HasValue)
                     {
                        if (ItemLView.DDOV_FecEmbarque.HasValue)
                        {
                           Int16 CCOT_Tipo = ItemLView.CCOT_Tipo;
                           Int32 CCOT_Numero = ItemLView.CCOT_Numero;
                           String CONS_TabEST = "OVE";
                           String CONS_CodEST = Delfin.Controls.variables.CONS_ESTOVECONCLUIDA;
                           String Usuario = Session.UserName;
                           DateTime Fecha = Session.Fecha;
                           String CCOT_MensajeError = "";


                           Boolean _continuar = true;
                           if (Item.CONS_CodLNG == Delfin.Controls.variables.CONSLNG_OtrosTraficos)
                           {
                              if (!ItemLView.ValidarOtrosTraficos())
                              { _continuar = (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "Existen servicios con datos incompletos(Falta ingresar Tipos, Serie y Numero de Documento). ¿Desea continuar con el proceso?", Item.MensajeError, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes); }
                           }

                           if (_continuar)
                           {
                              if (Client.SaveCab_Cotizacion_ConcluirOV(CCOT_Tipo, CCOT_Numero, CONS_TabEST, CONS_CodEST, Usuario, Fecha, ref CCOT_MensajeError))
                              {
                                 Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha concluido satisfactoriamente"); Actualizar();
                              }
                              else
                              {
                                 Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al concluir el item.", !String.IsNullOrEmpty(CCOT_MensajeError) ? CCOT_MensajeError : "");
                              }
                           }
                        }
                        else
                        {
                           String _labelFecha = ItemLView.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion ? "Fecha de Embarque" : "Fecha ETA";

                           Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar la " + _labelFecha + " antes de concluir la Orden de Venta.");
                        }
                     }
                     else
                     {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar el Viaje antes de concluir la Orden de Venta.");
                     }
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, ItemLView.MensajeError); }
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un item para poder concluirlo."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al concluir la Orden de Venta", ex); }
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
                  String CCOT_MensajeError = "";
                  Item = Client.SaveCab_Cotizacion_OV(ItemLView, ref CCOT_MensajeError);
                  if (Item != null)
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
      public bool Guardar(Boolean EsProspecto, Boolean ShowMessage)
      {
         try
         {
            MView.GetItem();
            FleteNegativo = false;
            if (Item.Validar(ref FleteNegativo))
            {
               if (Item.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion && (Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTCONFIRMADA || Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTANULADA))
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, String.Format("La Cotización se encuentra en estado {0} y no se guardará ningun cambio realizado.", (Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTCONFIRMADA ? "CONFIRMADA" : (Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTANULADA ? "ANULADA" : ""))));
                  return true;
               }
               if (Item.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta && (Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONCLUIDA || Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEANULADA)) //Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONFIRMADA || 
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, String.Format("La Orden de Venta se encuentra en estado {0} y no se guardará ningun cambio realizado.", (Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONCLUIDA ? "CONCLUIDA" : (Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEANULADA ? "ANULADA" : ""))));
                  return true;
               }

               if (Item.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta && EsProspecto)
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe actualizar la información del Cliente para poder crearle una Orden de Venta.");
                  return false;
               }
               if (FleteNegativo == true)
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "La Orden de Venta tiene un Profit Negativo.");
                  //return true;
               }

               Boolean m_isAdded = (Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added);

               if (Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified)
               {
                  this.Item.AUDI_UsrMod = Session.UserName;
                  this.Item.AUDI_FecMod = Session.Fecha;
               }

               String CCOT_MensajeError = "";

               //if (Item.CONS_CodEST.Equals("007"))
               //{ Item = Client.SaveCab_Cotizacion_OV(Item, ref CCOT_MensajeError, Cab_Cotizacion_OV.TipoInterfaz.OVC_Prefacturada); }
               //else
               Item = Client.SaveCab_Cotizacion_OV(Item, ref CCOT_MensajeError);
               if (Item != null && String.IsNullOrEmpty(CCOT_MensajeError))
               {
                  if (ShowMessage) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente"); }

                  Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged;
                  foreach (var item in Item.ItemsFlete)
                  { item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged; }
                  foreach (var item in Item.ItemsServicio)
                  { item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged; }
                  foreach (var item in Item.ItemsEventosTareas)
                  { item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged; }
                  foreach (var item in Item.ItemsNovedad)
                  { item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged; }
                  foreach (var item in Item.ItemsAnexos)
                  { item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged; }
                  foreach (var item in Item.ItemsArchivo)
                  { item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged; }


                  if (Item.CCOT_Tipo == 1 && Item.CONS_TabEST == "COT" && Item.CONS_CodEST == "001" && Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted)
                  { EnviarEmailCotizacion(Item, m_isAdded); }

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
                  if (!String.IsNullOrEmpty(CCOT_MensajeError))
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.", CCOT_MensajeError);

                     MView.ClearItem();
                     this.Item.AUDI_UsrMod = Session.UserName;
                     this.Item.AUDI_FecMod = Session.Fecha;
                     this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                     MView.SetItem();

                     return false;
                  }
                  else
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                     return false;
                  }
               }
            }
            else
            {
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

               ((COM007MView)MView).BringToFront();
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
         { ((COM007MView)MView).Close(); }
      }
      public void IsClosedMView()
      { isMViewShow = false; }

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
            if (CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion)
            {
               Boolean _CCOT_Versionada = Item.CCOT_Version.HasValue && Item.CCOT_Version.Value > 1;
               dtAyuda = Client.GetAllContratoByAyudaPivot(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Transportista.ENTC_Codigo, CCOT_FecEmi, CCOT_FecVcto, Regimen.CONS_CodTabla, Regimen.CONS_CodTipo, Via.CONS_CodTabla, Via.CONS_CodTipo, PUER_CodOrigen, PUER_CodDestino, _CCOT_Versionada);
            }
            else
            { dtAyuda = Client.GetAllContratoByAyudaPivotOV(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Transportista.ENTC_Codigo, CCOT_FecEmi, CCOT_FecVcto, Regimen.CONS_CodTabla, Regimen.CONS_CodTipo, Via.CONS_CodTabla, Via.CONS_CodTipo, PUER_CodOrigen, PUER_CodDestino); }

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
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 0,
                  ColumnName = "NVIA_Codigo",
                  ColumnCaption = "Código"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 0,
                  ColumnName = "DVIA_Codigo",
                  ColumnCaption = "Item"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 1,
                  ColumnName = "NVIA_NroViaje",
                  ColumnCaption = "Número Viaje"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 2,
                  ColumnName = "NAVE_Nombre",
                  ColumnCaption = "Nave"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 2,
                  ColumnName = "ENTC_RazonSocial",
                  ColumnCaption = "Transportista"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 2,
                  ColumnName = "CONS_DescVIA",
                  ColumnCaption = "Vía"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 2,
                  ColumnName = "NVIA_ETA",
                  ColumnCaption = "Fecha ETA"
               });


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
               _presenter.Item = new NaveViaje();
               if (Item != null && Item.ItemNaveViaje != null)
               {
                  _presenter.Item.NVIA_Codigo = Item.ItemNaveViaje.NVIA_Codigo;

                  if (_presenter.Editar() == System.Windows.Forms.DialogResult.OK)
                  {
                     //Item.ItemDetNaveViaje = Client.GetOneDetNaveViajeByOV(Item.CONS_TabRGM, Item.CONS_CodRGM, Item.CONS_TabVia, Item.CONS_CodVia, Item.PUER_CodOrigen.Value, Item.PUER_CodDestino.Value, _presenter.Item.NVIA_Codigo);
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
               string fileName = _folder.SelectedPath + x_ItemArchivo.OVAR_Descrip;
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
      #endregion

      #region [ Metodos Matriz Draft ]
      public void ExportarMatrizDraft()
      {
         try
         {
            if (Guardar(false, false))
            {
               OPE001Presenter.ExportarMatrizDraft(Item, ListPaquetes, ListTiposPAC);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al exportar la Matriz Draft", ex); }
      }
      #endregion

         }
}