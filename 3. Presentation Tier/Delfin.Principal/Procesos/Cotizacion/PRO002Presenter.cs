using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Infrastructure.Aspect.BusinessEntity;
using Microsoft.Practices.Unity;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Aspect.Collections;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using Infrastructure.WinFormsControls;
using System.Data;
using Infrastructure.Aspect.Constants;
using Microsoft.Reporting.WinForms;

namespace Delfin.Principal
{
   public class PRO002Presenter
   {
      #region [ Variables ]
      public String Title = "Cotización";
      public String CUS = "LOG002";
      public Boolean _LoadCotizacion = false ;
      private Cab_Cotizacion m_ItemCab_Cotizacion;
      private Cab_Cotizacion m_itemLView;
      private ObservableCollection<Det_Tarifa> m_ItemsDet_Tarifa;
      private ObservableCollection<Det_Tarifa_Servicio> m_ItemsDet_Tarifa_Servicio;
      private ObservableCollection<Det_Cotizacion> m_ItemsDet_CotizacionLogistico;
      private ObservableCollection<Det_Cotizacion> m_ItemsDet_CotizacioAduanero;
      private ObservableCollection<Det_Cotizacion> m_ItemsDet_CotizacionTransporte;
      private ObservableCollection<Det_Cotizacion> m_ItemsDet_CotizacionRegistros;
      private ObservableCollection<Det_Cotizacion> m_ItemsGrillaDet_Cotizacion;
      public ReportDataSource RepDataSourceCotizacion { get; set; }
      
      #endregion

      #region [ Constructor ]
      public PRO002Presenter(IUnityContainer x_container, IPRO002LView x_lview, IPRO002MView x_mview, IPRO002DMview x_dmview, IPRO002DSMview x_dsmview, IPRO002DImprimir x_dimprimir)
      {
         try
         {
            ContainerService = x_container;
            Session = ContainerService.Resolve<ISessionService>();
            LView = x_lview;
            MView = x_mview;
            DView = x_dmview;
            DSView = x_dsmview;
            DIView = x_dimprimir;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.ConstructorPresenter, ex); }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<Delfin.ServiceContracts.IDelfinServices>();
            ListTiposEntidad = Client.GetAllTiposEntidad().Where(tipe => tipe.TIPE_Codigo == 13 || tipe.TIPE_Codigo == 14 || tipe.TIPE_Codigo == 15).ToObservableCollection();
            ListConstantes = Client.GetAllConstantesByConstanteTabla("BSL");
            ListConstantesTipo = Client.GetAllConstantesByConstanteTabla("TRA");
            ListZonas = Client.GetAllTiposByTipoCodTabla("ZON");
            ListZonasDestino = Client.GetAllTiposByTipoCodTabla("ZON");
            ListConstantesEstado = Client.GetAllConstantesByConstanteTabla("COT");
            ListConstantesEstado = ListConstantesEstado.Where(data => data.CONS_CodBas != "003").ToObservableCollection(); // Menos el estado Confirmada
            LView.LoadView();
            MView.LoadView();
            DView.LoadView();
            DSView.LoadView();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.LoadPresenter, ex); }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public Delfin.ServiceContracts.IDelfinServices Client { get; set; }

      public IPRO002LView LView { get; set; }
      public IPRO002MView MView { get; set; }
      public IPRO002DMview DView { get; set; }
      public IPRO002DSMview DSView { get; set; }
      public IPRO002DImprimir DIView { get; set; }

      public ObservableCollection<TiposEntidad> ListTiposEntidad { get; set; }
      public ObservableCollection<Constantes> ListConstantes { get; set; }
      public ObservableCollection<Constantes> ListConstantesEstado { get; set; }
      public ObservableCollection<Constantes> ListConstantesTipo { get; set; }
      public ObservableCollection<Tipos> ListZonas { get; set; }
      public ObservableCollection<Tipos> ListZonasDestino { get; set; }

      public InstanceView InstanceViewServicio { get; set; }
      public DateTime FILTRO_FecEmiDesde { get; set; }
      public DateTime FILTRO_FecEmiHasta { get; set; }

      public Int32? FILTROCliente { get; set; }
      public String FILTRONroCotizacion { get; set; }

      public Int32? CTAR_CodigoLogistico { get; set; }
      public Int32? CTAR_CodigoAduanero { get; set; }
      public Int32? CTAR_CodigoTransporte { get; set; }
      public Int32  CTAR_Codigo { get; set; }
      public Int32?  ENTC_Codigo { get; set; }
      public String TipoTarifario { get; set; }
      public Boolean TarifaBuscada{ get; set; }
      public String ReportPath { get; set; }
      Boolean isMViewShow = false;

      #region [ Encabezado Cotización ]
      
      public Cab_Cotizacion ItemCab_Cotizacion
      {
          get { return m_ItemCab_Cotizacion; }
          set { m_ItemCab_Cotizacion = value; }
      }
      public Cab_Cotizacion ItemLView
      {
          get { return m_itemLView; }
          set { m_itemLView = value; }
      }
      public ObservableCollection<Cab_Cotizacion> ItemsCab_Cotizacion { get; set; }
      #endregion

      #region [ Detalle Cotización ]
      public ObservableCollection<Det_Tarifa> ItemsDet_Tarifa
      {
          get { return m_ItemsDet_Tarifa; }
          set { m_ItemsDet_Tarifa = value; }
      }
      public ObservableCollection<Det_Tarifa_Servicio> ItemsDet_Tarifa_Servicio
      {
          get { return m_ItemsDet_Tarifa_Servicio; }
          set { m_ItemsDet_Tarifa_Servicio = value; }
      }
      public ObservableCollection<Det_Cotizacion> ItemsDet_CotizacionRegistros
      {
          get { return m_ItemsDet_CotizacionRegistros; }
          set { m_ItemsDet_CotizacionRegistros = value; }
      }
      public ObservableCollection<Det_Cotizacion> ItemsDet_CotizacionLogistico
      {
          get { return m_ItemsDet_CotizacionLogistico; }
          set { m_ItemsDet_CotizacionLogistico = value; }
      }
      public ObservableCollection<Det_Cotizacion> ItemsDet_CotizacionAduanero
      {
          get { return m_ItemsDet_CotizacioAduanero; }
          set { m_ItemsDet_CotizacioAduanero = value; }
      }
      public ObservableCollection<Det_Cotizacion> ItemsDet_CotizacionTransporte
      {
          get { return m_ItemsDet_CotizacionTransporte; }
          set { m_ItemsDet_CotizacionTransporte = value; }
      }
      public ObservableCollection<Det_Cotizacion> ItemsDet_Cotizacion { get; set; }
      public ObservableCollection<Det_Cotizacion> ItemsGrillaDet_Cotizacion
      {
          get { return m_ItemsGrillaDet_Cotizacion; }
          set { m_ItemsGrillaDet_Cotizacion = value; }
      }

      public Det_Cotizacion_Servicio ItemDet_CotizacionServicio { get; set; }
      public Det_Cotizacion_Servicio TempItemDet_CotizacionServicio { get; set; } 
      public ObservableCollection<Det_Cotizacion_Servicio> ItemsDet_CotizacionServicio { get; set; }

      public Det_Cotizacion ItemDet_Cotizacion { get; set; }
      public Det_Cotizacion TempItemDet_Cotizacion { get; set; }
      #endregion
      
      #endregion

      #region [ Metodos ]

      #region [ Encabezado Cotización ]
      
      public void Nuevo()
      {
          try
          {
              if (!isMViewShow)
              {
                  MView = new PRO002MView();
                  MView.Presenter = this;
                  MView.LoadView();
              }

             _LoadCotizacion = false;
              MView.ClearItem();
              ItemCab_Cotizacion = new Cab_Cotizacion
              {
                  AUDI_UsrCrea = Session.UserName,
                  AUDI_FecCrea = Session.Fecha,
                  Instance = InstanceEntity.Added,
                  CONS_TabReg = "RGM",
                  CONS_TabEstado = "COT",
                  TIPO_TabMND = "MND"
              };
              MView.ClearItemsDetallesCotizacion();
              MView.ClearItemsDetalleServicios();
              MView.SetInstance(InstanceView.New);
              //((PRO002MView)MView).ShowDialog();
              isMViewShow = true;
              if (LView != null) { ((PRO002MView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
              ((PRO002MView)MView).Show();
              ((PRO002MView)MView).BringToFront();

          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }
      public void Editar()
      {
          try
          {
              if (!isMViewShow)
              {
                  MView = new PRO002MView();
                  MView.Presenter = this;
                  MView.LoadView();
              }
              if (ItemLView != null)//ItemCab_Cotizacion
              {
                 _LoadCotizacion = true;

                  MView.ClearItemsDetallesCotizacion();
                  MView.ClearItem();
                  /* Encabezado  :) */
                  ItemCab_Cotizacion = Client.GetOneCab_Cotizacion(ItemLView.CCOT_Codigo);
                  ItemCab_Cotizacion.AUDI_UsrMod = Session.UserName;
                  ItemCab_Cotizacion.AUDI_FecMod = Session.Fecha;
                  ItemCab_Cotizacion.Instance = InstanceEntity.Modified;
                  MView.SetItem();

                  /* Detalle Cotizacion :) */
                  
                  ItemsDet_Cotizacion = Client.GetAllDet_CotizacionByCotizacion(ItemCab_Cotizacion.CCOT_Codigo, "");
                  if (ItemsDet_Cotizacion.Count(data => data.CTAR_Tipo == "L") > 0)
                  {
                      m_ItemsDet_CotizacionLogistico = ItemsDet_Cotizacion.Where(data => data.CTAR_Tipo == "L").ToObservableCollection();
                      MView.SetItemST20_ST40_HBL(ref m_ItemsDet_CotizacionLogistico);
                      MView.ShowItemsLogisticoDetalleCotizacion(false);
                  }
                  ItemsDet_CotizacionAduanero = ItemsDet_Cotizacion.Where(data => data.CTAR_Tipo == "A").ToObservableCollection();
                  foreach (var item in ItemsDet_CotizacionAduanero)
                  {
                      ItemsDet_CotizacionRegistros.Add(item);
                  }
                  ItemsDet_CotizacionTransporte = ItemsDet_Cotizacion.Where(data => data.CTAR_Tipo == "T").ToObservableCollection();
                  foreach (var item in ItemsDet_CotizacionTransporte)
                  {
                      ItemsDet_CotizacionRegistros.Add(item);
                  }
                  MView.ShowItemsAduaneroDetalleCotizacion();
                  MView.ShowItemsTransporteDetalleCotizacion();

                  /* Detalle Servicio Cotizacion :) */
                  MView.ClearItemsDetalleServicios();
                  ItemsDet_CotizacionServicio = Client.GetAllDet_Cotizacion_ServicioByCotizacion(ItemCab_Cotizacion.CCOT_Codigo, "");
                  foreach (var _item in ItemsDet_CotizacionServicio)
                  {
                      _item.Validado = true; 
                  }
                  MView.ShowItemsDetalleServicios();

                  MView.SetInstance(InstanceView.Edit);
                  _LoadCotizacion = false;
                  //((PRO002MView)MView).ShowDialog();
                  isMViewShow = true;
                  if (LView != null) { ((PRO002MView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
                  ((PRO002MView)MView).Show();
                  ((PRO002MView)MView).BringToFront();

              }
              else
              { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
      }
      public void Eliminar()
      {
          try
          {
              if (ItemLView != null)//ItemCab_Cotizacion
              {
                  DialogResult _result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
                  if (_result == DialogResult.Yes)
                  {
                      if ((ItemLView.CCOT_Codigo != ItemCab_Cotizacion.CCOT_Codigo) || (!isMViewShow))
                      {
                      ItemLView.Instance = InstanceEntity.Deleted;
                      if (Client.SaveCab_Cotizacion(ref m_itemLView))
                      {
                          Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                          Actualizar();
                      }
                      else
                      { Dialogos.MostrarMensajeInformacion(Title, "No se ha podido eliminar el item debido a que ya se encuentra relacionado."); }
                      }
                      else
                      {
                          { Dialogos.MostrarMensajeInformacion(Title, "El Registro que desea eliminar se encuentra abierto por favor cierre el registro para poder eliminarlo"); }
                      }
                  }
              }
              else
              { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
      }
      public void AprobarAnular(String x_Accion)
      {
          try
          {
              if (!String.IsNullOrEmpty(x_Accion))
              {
                  if (ItemLView != null)//ItemCab_Cotizacion
                  {
                      DialogResult _result = Dialogos.MostrarMensajePregunta(Title, "¿Esta seguro que desea " + x_Accion + " la cotización ?", Dialogos.LabelBoton.Si_No);
                      if (_result == DialogResult.Yes)
                      {
                          String _Estado = String.Empty;
                          if (x_Accion.Equals("Aprobar"))
                          {
                            _Estado = "002"; // Autorizada
                          }
                          else
                          {
                              _Estado = "004"; // Anulada
                          }
                          if (Client.AprobarAnularCotizacion(ItemLView.CCOT_Codigo, _Estado, Session.UserName))
                          {
                             Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha " + (x_Accion=="Aprobar"?"Aprobado":"Anulado") + " la cotización.");
                              Actualizar();
                          }
                          else
                          { Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al realizar la acción seleccionada."); }
                      }
                  }
                  else
                  { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); } 
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
      }
      public void Actualizar()
      {
          try
          {
              //ItemCab_Cotizacion = null;
              ItemLView = null;
              ItemsCab_Cotizacion = null;
              LView.FiltrosLView();
              ItemsCab_Cotizacion = Client.GetAllByFiltrosCab_Cotizacion(FILTROCliente, FILTRONroCotizacion, FILTRO_FecEmiDesde, FILTRO_FecEmiHasta);
              LView.ShowItems();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }
      public bool GuardarCotizacion()
      {
          try
          {
              String _MensajeError = String.Empty;
              MView.GetItem();
              Int32 _Fila = 0;
              if (ItemCab_Cotizacion.Validar())
              {
                  if (ItemsDet_CotizacionServicio != null )
                  {
                      foreach (var item in ItemsDet_CotizacionServicio)
                      {
                          _Fila++;
                          if (!item.Validado)
                          {
                              _MensajeError += "* Debe completar de llenar los datos de servicios incluidos fila Nro " + _Fila + Environment.NewLine;
                          }
                      } 
                  }
                  if (String.IsNullOrEmpty(_MensajeError))
                  {
                      //if (ItemsDet_CotizacionRegistros != null && ItemsDet_CotizacionRegistros.Count > 0)
                      //{
                          ItemCab_Cotizacion.ItemsDet_Cotizacion = new ObservableCollection<Det_Cotizacion>();
                          ItemCab_Cotizacion.ItemsDet_Cotizacion = ItemsDet_CotizacionRegistros;

                          if (ItemsDet_CotizacionServicio != null && ItemsDet_CotizacionServicio.Count > 0)
                          {
                              ItemCab_Cotizacion.ItemsDet_Cotizacion_Servicio = new ObservableCollection<Det_Cotizacion_Servicio>();
                              ItemCab_Cotizacion.ItemsDet_Cotizacion_Servicio = ItemsDet_CotizacionServicio;
                          }
                          if (Client.SaveCab_Cotizacion(ref m_ItemCab_Cotizacion))
                          {
                              Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                              Actualizar();
                              return true;
                          }
                          Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                          return false;
                      //}
                      //Dialogos.MostrarMensajeInformacion(Title, "Debe agregar un detalle a la Cotizacion como minimo");
                      //return false;
                  }
                  Dialogos.MostrarMensajeInformacion(Title, "Faltan ingresar datos obligatorios: ", _MensajeError, Dialogos.Boton.Detalles);
                  return false;
              }
              MView.ShowValidation();
              return false;
          }
          catch (Exception ex)
          {
              Dialogos.MostrarMensajeError(Title, Mensajes.SavePresenter, ex);
              return false;
          }
      }
      public void BuscarTarifarios(Boolean x_Filtros, Int32? _CTAR_CodigoLogistico, Int32? _CTAR_CodigoAduanero, Int32?  _CTAR_CodigoTransporte)
      {
          try
          {

              CTAR_CodigoLogistico = null;
              CTAR_CodigoAduanero = null;
              CTAR_CodigoTransporte = null;
              //MView.FiltrosTarifas();
              //MView.ClearItemsDetallesCotizacion();
              CTAR_CodigoLogistico = _CTAR_CodigoLogistico;
              CTAR_CodigoAduanero = _CTAR_CodigoAduanero;
              CTAR_CodigoTransporte = _CTAR_CodigoTransporte;

              TarifaBuscada = true;
              if (x_Filtros)
              {
                  if (CTAR_CodigoLogistico != null || CTAR_CodigoAduanero != null || CTAR_CodigoTransporte != null)
                  {
                      ItemsDet_Tarifa = Client.GetAllTarifasByCotizacion(CTAR_CodigoLogistico, CTAR_CodigoAduanero, CTAR_CodigoTransporte,true);
                  }
                  else
                  {
                      Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar un servicio de tarifa."); return;
                  } 
              }
              else  /* Buscar Mejor Tarifa  Sin Filtros */
              {
                 MView.ClearItemsDetallesCotizacion();
                 MView.ClearItemsDetalleServicios();
                 ItemsDet_Tarifa = Client.GetAllTarifasByCotizacion(CTAR_CodigoLogistico, CTAR_CodigoAduanero, CTAR_CodigoTransporte, false);
                      //ItemsDet_Tarifa = ItemsDet_Tarifa.Where(data => data.CTAR_Codigo == interno).ToObservableCollection();
                 //ItemsDet_Tarifa = ItemsDet_Tarifa.Where(data => data.CTAR_Codigo == interno).ToObservableCollection();
                      //MView.SetItemServicio(firstOrDefault.CTAR_Tipo, firstOrDefault.CTAR_Codigo);
                  //}
              }
              
              if (ItemsDet_Tarifa != null && ItemsDet_Tarifa.Count > 0)
              {
                 var firstOrDefault = ItemsDet_Tarifa.FirstOrDefault();
                 if (firstOrDefault != null)
                 {
                    CTAR_Codigo = firstOrDefault.CTAR_Codigo;
                    ENTC_Codigo = firstOrDefault.ENTC_Codigo;  
                 }
                  /* Detalle Cotizacion */
                 Int32? _CTAR_CodTServicio = null;
                 Int32? _CTAR_CodLServicio = null;
                 Int32? _CTAR_CodAServicio = null;
                 
                  DetTarifa_A_DetCotizacion();// cambiamos de Detalle Tarifas a Detalle Cotización
                  if (ItemsDet_Cotizacion.Count(data => data.CTAR_Tipo == "L") > 0)
                  {
                      m_ItemsDet_CotizacionLogistico = ItemsDet_Cotizacion.Where(data => data.CTAR_Tipo == "L").ToObservableCollection();
                      MView.SetItemST20_ST40_HBL(ref m_ItemsDet_CotizacionLogistico);
                      _CTAR_CodLServicio = Convert.ToInt32 ( m_ItemsDet_CotizacionLogistico.ToDataTable().Rows[0]["CTAR_Codigo"].ToString());   
                      MView.ShowItemsLogisticoDetalleCotizacion(true);
                      MView.SeteaCabTarifarios(Convert.ToInt32(m_ItemsDet_CotizacionLogistico.ToDataTable().Rows[0]["CTAR_Codigo"].ToString()), "L");
                  }
                  ItemsDet_CotizacionAduanero = ItemsDet_Cotizacion.Where(data => data.CTAR_Tipo == "A").ToObservableCollection();
                  foreach (var item in ItemsDet_CotizacionAduanero)
                  {
                     _CTAR_CodAServicio = item.CTAR_Codigo; 
                      ItemsDet_CotizacionRegistros.Add(item);
                      MView.SeteaCabTarifarios(Convert.ToInt32(ItemsDet_CotizacionAduanero.ToDataTable().Rows[0]["CTAR_Codigo"].ToString()), "A");
                  }
                  ItemsDet_CotizacionTransporte = ItemsDet_Cotizacion.Where(data => data.CTAR_Tipo == "T").ToObservableCollection();
                  foreach (var item in ItemsDet_CotizacionTransporte)
                  {
                     _CTAR_CodTServicio = item.CTAR_Codigo;
                      ItemsDet_CotizacionRegistros.Add(item);
                  }
                  MView.ShowItemsAduaneroDetalleCotizacion();
                  MView.ShowItemsTransporteDetalleCotizacion();

                  /* Detalle Servicio :) */
                  //MView.ClearItemsDetalleServicios();
                  if (CTAR_CodigoAduanero != null || CTAR_CodigoLogistico != null)
                  {
                     if(ItemsDet_CotizacionServicio == null)
                        ItemsDet_CotizacionServicio = new ObservableCollection<Det_Cotizacion_Servicio>();
                     if (CTAR_CodigoLogistico != null)
                        LimpiarServicioAdicional("L");
                     if (CTAR_CodigoAduanero != null)
                        LimpiarServicioAdicional("A");
                     ItemsDet_Tarifa_Servicio = Client.GetAllServiciosTarifaByCotizacion(CTAR_CodigoLogistico, CTAR_CodigoAduanero);
                     ServicioDetTarifa_A_ServiciosDetCotizacion();
                     MView.ShowItemsDetalleServicios();
                  }
              } else { Dialogos.MostrarMensajeInformacion(Title, "No se encontraron resultados.");  }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      public void LimpiarServicioAdicional(String _CTAR_Tipo)
      {
         if (ItemsDet_CotizacionServicio != null)
         {

            while (ItemsDet_CotizacionServicio.FirstOrDefault(tipo => tipo.SCOT_Tipo == _CTAR_Tipo && tipo.Instance != InstanceEntity.Deleted) != null)
            {
               var _item = ItemsDet_CotizacionServicio.First(tipo => tipo.SCOT_Tipo == _CTAR_Tipo && tipo.Instance != InstanceEntity.Deleted);
               if (_item.SCOT_Item > 0)
               { _item.Instance = InstanceEntity.Deleted; }
               else
               { ItemsDet_CotizacionServicio.Remove(_item); }
            }
         }
      }

      #endregion

      #region [ Detalle Cotización ]

      private void DetTarifa_A_DetCotizacion()
      {
          try
          {
              ItemsDet_Cotizacion= new ObservableCollection<Det_Cotizacion> ();
              for (int i = 0; i < ItemsDet_Tarifa.Count; i++)
              {
                 var detCotizacion = new Det_Cotizacion
                 {
                     AUDI_UsrCrea = Session.UserName,
                     AUDI_FecCrea = Session.Fecha,
                     Instance = InstanceEntity.Added,
                     TIPE_Codigo = m_ItemsDet_Tarifa[i].TIPE_Codigo ?? null,
                     TIPE_Descripcion = m_ItemsDet_Tarifa[i].TIPE_Descripcion,
                     ENTC_Codigo = m_ItemsDet_Tarifa[i].ENTC_Codigo ?? null,
                     ENTC_RazonSocial = m_ItemsDet_Tarifa[i].ENTC_RazonSocial,
                     PACK_Codigo = m_ItemsDet_Tarifa[i].PACK_Codigo ?? null,
                     CTAR_Codigo = m_ItemsDet_Tarifa[i].CTAR_Codigo,
                     CTAR_Tipo = m_ItemsDet_Tarifa[i].CTAR_Tipo,
                     DTAR_Item = m_ItemsDet_Tarifa[i].DTAR_Item,
                     DCOT_Profit = m_ItemsDet_Tarifa[i].DTAR_Profit ?? null,
                     CONS_CodBas = m_ItemsDet_Tarifa[i].CONS_CodBas,
                     CONS_CodTipo = m_ItemsDet_Tarifa[i].CONS_CodTipo,
                     CONS_CodTRA = m_ItemsDet_Tarifa[i].CONS_CodTRA,
                     CONS_Desc_SPA = m_ItemsDet_Tarifa[i].CONS_Desc_SPA,
                     CONS_Desc_TRA = m_ItemsDet_Tarifa[i].CONS_Desc_TRA,
                     CONS_TabBas = m_ItemsDet_Tarifa[i].CONS_TabBas,
                     CONS_TabTRA = m_ItemsDet_Tarifa[i].CONS_TabTRA,
                     DESTINO = m_ItemsDet_Tarifa[i].DESTINO,
                     DCOT_Minimo = m_ItemsDet_Tarifa[i].DTAR_Minimo != null ? m_ItemsDet_Tarifa[i].DTAR_Minimo.Value : 0,
                     DCOT_Peso = m_ItemsDet_Tarifa[i].DTAR_Peso != null ? m_ItemsDet_Tarifa[i].DTAR_Peso.Value : 0,
                     DCOT_Roudtrip = m_ItemsDet_Tarifa[i].DTAR_Roundtrip,
                     DCOT_Venta = m_ItemsDet_Tarifa[i].DTAR_Venta != null ? m_ItemsDet_Tarifa[i].DTAR_Venta.Value : 0,
                     DCOT_VentaSada = m_ItemsDet_Tarifa[i].DTAR_VentaSada != null ? m_ItemsDet_Tarifa[i].DTAR_VentaSada.Value : 0,
                     DCOT_Costo = m_ItemsDet_Tarifa[i].DTAR_Costo != null ? m_ItemsDet_Tarifa[i].DTAR_Costo.Value : 0,
                     DCOT_CostoSada = m_ItemsDet_Tarifa[i].DTAR_CostoSada != null ? m_ItemsDet_Tarifa[i].DTAR_CostoSada.Value : 0,
                     DCOT_Volumen = m_ItemsDet_Tarifa[i].DTAR_Volumen,
                     ORIGEN = m_ItemsDet_Tarifa[i].ORIGEN,
                     TIPO_CodZONDestino = m_ItemsDet_Tarifa[i].TIPO_CodZONDestino,
                     TIPO_CodZONOrigen = m_ItemsDet_Tarifa[i].TIPO_CodZONOrigen,
                     TIPO_TabZON = m_ItemsDet_Tarifa[i].TIPO_TabZON
                 };
                 ItemsDet_Cotizacion.Add( detCotizacion);
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }
      private void ServicioDetTarifa_A_ServiciosDetCotizacion()
      {
          try
          {
              for (int i = 0; i < ItemsDet_Tarifa_Servicio.Count; i++)
              {
                   Det_Cotizacion_Servicio _Servicio = new Det_Cotizacion_Servicio();
                  _Servicio.AUDI_UsrCrea = Session.UserName;
                  _Servicio.AUDI_FecCrea = Session.Fecha;
                  _Servicio.Instance = InstanceEntity.Added;
                  _Servicio.Validado = false;

                  _Servicio.TIPE_Codigo =null;
                  _Servicio.SCOT_Tipo = m_ItemsDet_Tarifa_Servicio[i].CTAR_Tipo; 
                  _Servicio.ENTC_Codigo = null;

                  _Servicio.SERV_Codigo = m_ItemsDet_Tarifa_Servicio[i].SERV_Codigo != null ? m_ItemsDet_Tarifa_Servicio[i].SERV_Codigo.Value : 0;
                  _Servicio.CONS_Desc_Servicio = m_ItemsDet_Tarifa_Servicio[i].TIPO_Desc_Servicio;
                 _Servicio.SCOT_Cantidad = 1;
                 _Servicio.CONS_CodBas = "003"; 
                 _Servicio.CONS_Desc_Base = "Cntd.";
                 _Servicio.CONS_CodTMC = "001"; 
                 _Servicio.CONS_Desc_TMC = "Ingreso";
                 _Servicio.SCOT_PrecioUni = Convert.ToDecimal ( m_ItemsDet_Tarifa_Servicio[i].DTAS_Costo);
                 _Servicio.SCOT_ImporteIngreso = Convert.ToDecimal(m_ItemsDet_Tarifa_Servicio[i].DTAS_Costo); 
                  _Servicio.TIPO_CodMnd = m_ItemsDet_Tarifa_Servicio[i].TIPO_CodMnd;
                  _Servicio.TIPO_TabMnd = m_ItemsDet_Tarifa_Servicio[i].TIPO_TabMnd;
                  _Servicio.CONS_Desc_Moneda = m_ItemsDet_Tarifa_Servicio[i].TIPO_Desc1;
                  ItemsDet_CotizacionServicio.Add(_Servicio);
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }
      public void NuevoDetalleCotizaciones(String _CTAR_Tipo, Int32? _CTAR_Codigo, Int16? _DTAR_Item, Int32? _ENTC_Codigo )
      {
          try
          {
              TempItemDet_Cotizacion = new Det_Cotizacion
              {
                  AUDI_UsrCrea = Session.UserName,
                  AUDI_FecCrea = Session.Fecha,
                  CTAR_Tipo = _CTAR_Tipo,
                  CTAR_Codigo = _CTAR_Codigo,
                  DTAR_Item = _DTAR_Item,
                  ENTC_Codigo = _ENTC_Codigo,
                  Instance = InstanceEntity.Added
              };
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }
      public void AgregarDetalleCotizacion()
      {
          try
          {
             String _CTAR_Tipo = "C";
             Int16? _DTAR_Item = 0;
             Int32? _CTAR_Codigo = 0;
             Decimal _DTAR_Costo20 = 0;
             Decimal _DTAR_CostoSADA20 = 0;
             Decimal _DTAR_Costo40 = 0;
             Decimal _DTAR_CostoSADA40 = 0;
             Decimal _DTAR_CostoHBL = 0;
             Decimal _DTAR_CostoSADAHBL = 0;
             Int32? _ENTC_Codigo = 0;
             _CTAR_Tipo = ItemDet_Cotizacion.CTAR_Tipo;
             _CTAR_Codigo = ItemDet_Cotizacion.CTAR_Codigo;
             _DTAR_Item = ItemDet_Cotizacion.DTAR_Item;
             _DTAR_Costo20 = ItemDet_Cotizacion.DCOT_Costo20;
             _DTAR_CostoSADA20 = ItemDet_Cotizacion.DCOT_CostoSada20;
             _DTAR_Costo40 = ItemDet_Cotizacion.DCOT_Costo40;
             _DTAR_CostoSADA40 = ItemDet_Cotizacion.DCOT_CostoSada40;
             _DTAR_CostoHBL = ItemDet_Cotizacion.DCOT_CostoHBL;
             _DTAR_CostoSADAHBL = ItemDet_Cotizacion.DCOT_CostoSadaHBL;
             _ENTC_Codigo = ItemDet_Cotizacion.ENTC_Codigo; 
              if (ItemDet_Cotizacion.CTAR_Tipo.Equals("L"))
              {
                  //ItemsGrillaDet_Cotizacion.Remove(ItemDet_Cotizacion);
                  continuar:
                  foreach (var item in ItemsDet_CotizacionRegistros)
                  {
                      try
                      {
                          if (ItemDet_Cotizacion.DCOT_Fila == item.DCOT_Fila)
                          {
                              if (item.DCOT_Item > 0)
                              {
                                  item.Instance = InstanceEntity.Deleted;
                              }
                              else
                              {
                                  ItemsDet_CotizacionRegistros.Remove(item);  
                                  goto continuar;
                              }
                          }
                      } catch (Exception)
                      { }
                  }
                  ItemDet_Cotizacion = new Det_Cotizacion
                  {
                     AUDI_UsrCrea = Session.UserName,
                     AUDI_FecCrea = Session.Fecha,
                     CTAR_Tipo = _CTAR_Tipo,
                     CTAR_Codigo = _CTAR_Codigo,
                     DTAR_Item = _DTAR_Item,
                     DCOT_Costo20 = _DTAR_Costo20,
                     DCOT_CostoSada20 = _DTAR_CostoSADA20,
                     DCOT_Costo40 = _DTAR_Costo40,
                     DCOT_CostoSada40 = _DTAR_CostoSADA40,
                     DCOT_CostoHBL = _DTAR_CostoHBL,
                     DCOT_CostoSadaHBL = _DTAR_CostoSADAHBL,
                     ENTC_Codigo = _ENTC_Codigo,
                     Instance = InstanceEntity.Added
                  };
                  DView.GetItem();
                  if (ItemDet_Cotizacion.Validar())
                  {
                      if (ItemsGrillaDet_Cotizacion != null && ItemsGrillaDet_Cotizacion.Count > 0)
                      {
                          if (ItemDet_Cotizacion.TIPE_Codigo != null && ItemDet_Cotizacion.TIPE_Codigo.Value.ToString(CultureInfo.InvariantCulture).Equals("13")) //maritimo
                          {
                              const short tipeCodigo = 13;
                              if (ItemsGrillaDet_Cotizacion.Count(tipo => tipo.TIPE_Codigo != null && tipo.TIPE_Codigo.Value == tipeCodigo) > 0)
                              {
                                  Dialogos.MostrarMensajeInformacion(Title, "No puede haber mas de un agente maritimo."); return;
                              }
                          }
                          else
                          {
                             if (ItemsGrillaDet_Cotizacion.Any(entCodigo => entCodigo.ENTC_Codigo == ItemDet_Cotizacion.ENTC_Codigo && entCodigo.TIPE_Codigo.Value == ItemDet_Cotizacion.TIPE_Codigo && entCodigo.Instance == InstanceEntity.Added  ))
                              {
                                  Dialogos.MostrarMensajeInformacion(Title, "No puede haber mas de una entidad duplicada."); return;
                              }     
                          }
                      }

                      if (ItemDet_Cotizacion.DCOT_Venta20 == 0)
                      {
                         foreach (Det_Cotizacion Item in ItemsGrillaDet_Cotizacion)
                         {
                            Item.DCOT_Venta20 = ItemDet_Cotizacion.DCOT_Venta20;
                         }
                         while (ItemsDet_CotizacionRegistros.FirstOrDefault(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted && tipo.PACK_Codigo == 1 && tipo.DCOT_Venta > 0) != null)
                         {
                            var _item = ItemsDet_CotizacionRegistros.First(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted && tipo.PACK_Codigo == 1 && tipo.DCOT_Venta > 0);
                            _item.DCOT_Venta = ItemDet_Cotizacion.DCOT_Venta20;
                         }
                      }
                      if (ItemDet_Cotizacion.DCOT_VentaSada20 == 0)
                      {
                         foreach (Det_Cotizacion Item in ItemsGrillaDet_Cotizacion)
                         {
                            Item.DCOT_VentaSada20 = ItemDet_Cotizacion.DCOT_VentaSada20;
                         }
                         while (ItemsDet_CotizacionRegistros.FirstOrDefault(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted && tipo.PACK_Codigo == 1 && tipo.DCOT_VentaSada > 0) != null)
                         {
                            var _item = ItemsDet_CotizacionRegistros.First(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted && tipo.PACK_Codigo == 1 && tipo.DCOT_VentaSada > 0);
                            _item.DCOT_VentaSada = ItemDet_Cotizacion.DCOT_VentaSada20;
                         }
                      }
                      if (ItemDet_Cotizacion.DCOT_Venta40 == 0)
                      {
                         foreach (Det_Cotizacion Item in ItemsGrillaDet_Cotizacion)
                         {
                            Item.DCOT_Venta40 = ItemDet_Cotizacion.DCOT_Venta40;
                         }
                         while (ItemsDet_CotizacionRegistros.FirstOrDefault(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted && tipo.PACK_Codigo == 2 && tipo.DCOT_Venta > 0) != null)
                         {
                            var _item = ItemsDet_CotizacionRegistros.First(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted && tipo.PACK_Codigo == 2 && tipo.DCOT_Venta > 0);
                            _item.DCOT_Venta = ItemDet_Cotizacion.DCOT_Venta40;
                         }
                      }
                      if (ItemDet_Cotizacion.DCOT_VentaSada40 == 0)
                      {
                         foreach (Det_Cotizacion Item in ItemsGrillaDet_Cotizacion)
                         {
                            Item.DCOT_VentaSada40 = ItemDet_Cotizacion.DCOT_VentaSada40;
                         }
                         while (ItemsDet_CotizacionRegistros.FirstOrDefault(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted && tipo.PACK_Codigo == 2 && tipo.DCOT_VentaSada > 0) != null)
                         {
                            var _item = ItemsDet_CotizacionRegistros.First(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted && tipo.PACK_Codigo == 2 && tipo.DCOT_VentaSada > 0);
                            _item.DCOT_VentaSada = ItemDet_Cotizacion.DCOT_VentaSada40;
                         }
                      }
                      if (ItemDet_Cotizacion.Instance == InstanceEntity.Added)
                        ItemsGrillaDet_Cotizacion.Add(ItemDet_Cotizacion);
                      DView.GenerarST20_ST40_HBL(_CTAR_Tipo, _CTAR_Codigo, _DTAR_Item );
                      //ItemsDet_CotizacionRegistros.Add(TempItemDet_Cotizacion); 
                      MView.ShowItemsLogisticoDetalleCotizacion(true);
                      DView.CerrarVenta();
                  }
                  else
                  {
                      DView.ShowValidation();
                  }
              }
              else   // Tarifa Aduanera || Tarifa Transporte
              {

                  if (ItemDet_Cotizacion.DCOT_Item > 0 )
                  {
                      ItemDet_Cotizacion.Instance = InstanceEntity.Deleted;
                  }
                  else
                  {
                      ItemsDet_CotizacionRegistros.Remove(ItemDet_Cotizacion);
                  }
                  NuevoDetalleCotizaciones(_CTAR_Tipo, _CTAR_Codigo, _DTAR_Item, _ENTC_Codigo);
                  DView.GetItem();
                  if (TempItemDet_Cotizacion.Validar())
                  {
                      if (TempItemDet_Cotizacion.CTAR_Tipo.Equals("A"))
                      {
                          if (ItemsDet_CotizacionRegistros.Any(codBase => codBase.CONS_CodBas == TempItemDet_Cotizacion.CONS_CodBas && codBase.CTAR_Tipo == "A" && codBase.Instance != InstanceEntity.Deleted))
                          {
                              Dialogos.MostrarMensajeInformacion(Title, "No puede haber mas de un base duplicada."); return;
                          }
                          ItemsDet_CotizacionRegistros.Add(TempItemDet_Cotizacion);
                          MView.ShowItemsAduaneroDetalleCotizacion();
                      }
                      else if (TempItemDet_Cotizacion.CTAR_Tipo.Equals("T"))
                      {
                          if (ItemsDet_CotizacionRegistros.Any(data => data.CONS_CodTRA == TempItemDet_Cotizacion.CONS_CodTRA && data.TIPO_CodZONDestino == TempItemDet_Cotizacion.TIPO_CodZONDestino && data.CTAR_Tipo == "T" && data.Instance != InstanceEntity.Deleted))
                          {
                              Dialogos.MostrarMensajeInformacion(Title, "No puede haber mas de una mismo tipo y destino."); return;
                          }
                          ItemsDet_CotizacionRegistros.Add(TempItemDet_Cotizacion);
                          MView.ShowItemsTransporteDetalleCotizacion();
                      }
                      DView.CerrarVenta();
                  }
                  else
                  {
                      DView.ShowValidation();
                  }
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }
      public void EditarDetalleCotizacion()
      {
          try
          {
              if (ItemDet_Cotizacion != null)
              {
                  DView.ClearItem();
                  DView.SetItem();
                  DView.SetInstance(InstanceView.Edit);
                  ((PRO002DMview)DView).ShowDialog();
              }
              else
              { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
      }
      public void EliminarDetalleCotizacion()
      {
          try
          {
              if (ItemDet_Cotizacion != null)
              {
                  DialogResult result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
                  if (result == DialogResult.Yes)
                  {
                      if (ItemDet_Cotizacion.CTAR_Tipo != null && ItemDet_Cotizacion.CTAR_Tipo.Equals("L"))
                      {
                          ItemsGrillaDet_Cotizacion.Remove(ItemDet_Cotizacion);
                          retorna:
                          foreach (var item in ItemsDet_CotizacionRegistros)
                          {
                              if (ItemDet_Cotizacion.DCOT_Fila == item.DCOT_Fila)
                              {
                                  if (item.DCOT_Item > 0)
                                  {
                                      item.Instance = InstanceEntity.Deleted;
                                  }
                                  else
                                  {
                                      ItemsDet_CotizacionRegistros.Remove(item);
                                      goto retorna;
                                  }
                              }
                          }
                          MView.ShowItemsLogisticoDetalleCotizacion(false);
                      }
                      else
                      {
                          if (ItemDet_Cotizacion.DCOT_Item > 0)
                          {
                              ItemDet_Cotizacion.Instance = InstanceEntity.Deleted;
                          }
                          else
                          {
                              ItemsDet_CotizacionRegistros.Remove(ItemDet_Cotizacion);
                          }
                          if (ItemDet_Cotizacion.CTAR_Tipo != null && ItemDet_Cotizacion.CTAR_Tipo.Equals("A"))
                          {
                              MView.ShowItemsAduaneroDetalleCotizacion();
                          }
                          else if (ItemDet_Cotizacion.CTAR_Tipo != null && ItemDet_Cotizacion.CTAR_Tipo.Equals("T"))
                          {
                              MView.ShowItemsTransporteDetalleCotizacion();
                          }
                      }
                  }
              }
              else
              { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
      }
      #endregion

      #region [ Detalle Cotización Servicios ]
      public DataTable GetTodosServicios()
      {
          try
          { 
              //return Client.GetAllServicio().ToDataTable();
              return Client.GetServiciosAdicionales(7); 
          }
          catch (Exception)
          { return null; }
      }
      public void LoadNuevoDetalleServicioCotizacion()
      {
          try
          {
              DSView.ClearItem();
              DSView.SetInstance(InstanceView.New);
              ((PRO002DSMview)DSView).ShowDialog();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }

       private void NuevoDetalleServicioCotizacion(String Tipo)
      {
          try
          {
              TempItemDet_CotizacionServicio = new Det_Cotizacion_Servicio
              {
                  AUDI_UsrCrea = Session.UserName,
                  AUDI_FecCrea = Session.Fecha,
                  SCOT_Tipo = Tipo,
                  CONS_TabTMC = "TMC",
                  Instance = InstanceEntity.Added
              };
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }
      public void AgregarDetalleServicioCotizacion()
      {
          try
          {
             String _Tipo = "C";
              if (InstanceViewServicio == InstanceView.Edit)
              {
                  if (ItemDet_CotizacionServicio.SCOT_Item > 0)
                  {
                      ItemDet_CotizacionServicio.Instance = InstanceEntity.Deleted;
                  }
                  else
                  {
                     _Tipo = ItemDet_CotizacionServicio.SCOT_Tipo;
                      ItemsDet_CotizacionServicio.Remove(ItemDet_CotizacionServicio);
                  }
              }
              NuevoDetalleServicioCotizacion(_Tipo);
              DSView.GetItem();
              if (TempItemDet_CotizacionServicio.Validar())
              {
                  TempItemDet_CotizacionServicio.Validado = true;
                  ItemsDet_CotizacionServicio.Add(TempItemDet_CotizacionServicio);
                  MView.ShowItemsDetalleServicios();
                  DSView.CerrarVenta();
              }
              else
              {
                  DSView.ShowValidation();
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }
      public void EditarServicioDetalleCotizacion()
      {
          try
          {
              if (ItemDet_CotizacionServicio != null)
              {
                  DSView.ClearItem();
                  DSView.SetItem();
                  DSView.SetInstance(InstanceView.Edit);
                  ((PRO002DSMview)DSView).ShowDialog();
              }
              else
              { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
      }
      public void EliminarDetalleServicioCotizacion()
      {
          try
          {
              if (ItemDet_CotizacionServicio != null)
              {
                  DialogResult result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
                  if (result != DialogResult.Yes) return;
                  if (ItemDet_CotizacionServicio.SCOT_Item > 0)
                  {
                      ItemDet_CotizacionServicio.Instance = InstanceEntity.Deleted;
                  }
                  else
                  {
                      ItemsDet_CotizacionServicio.Remove(ItemDet_CotizacionServicio);
                  }
                  MView.ShowItemsDetalleServicios();
              }
              else
              { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
      }
      #endregion
      #endregion
      public void CloseView()
      {
          if (isMViewShow)
          { ((PRO002MView)MView).Close(); }
      }

      public void IsClosedMView()
      { isMViewShow = false; }

      #region [Imprimir]
      public void Imprimir()
      {
         try
         {
            DataTable _DT;
            _DT = Client.PrintCotizacion(ItemCab_Cotizacion.CCOT_Codigo);
            ReportPath = null;
            ReportPath = Application.StartupPath + @"\Reportes\RptCotizacion.rdlc";
            RepDataSourceCotizacion = new ReportDataSource("Cotizacion", _DT);

            DIView.ShowReporte();
            ((PRO002DImprimir)DIView).ShowDialog();
         }
         catch (Exception ex)
         { throw ex; }
      }

      #endregion
   }
}