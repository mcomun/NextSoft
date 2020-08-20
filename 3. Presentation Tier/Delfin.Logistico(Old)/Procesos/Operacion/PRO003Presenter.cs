using System;
using System.Diagnostics;
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

namespace Delfin.Logistico
{
   public class PRO003Presenter
   {
      #region [ Variables ]
      public String Title = "Operación";
      public String CUS = "LOG003";
      private Cab_Operacion m_ItemCab_Operacion;
      private Cab_Operacion m_itemLView;
      private ObservableCollection<Det_Cotizacion> m_ItemsDet_Cotizacion;
      private ObservableCollection<Det_Cotizacion_Servicio> m_ItemsDet_Cotizacion_Servicio;
      private ObservableCollection<Det_Cotizacion_Servicio> m_ItemsDet_Cotizacion_Servicio_Parcial;
      private ObservableCollection<Det_Operacion> m_ItemsDet_OperacionLogistico;
      private ObservableCollection<Det_Operacion> m_ItemsDet_OperacioAduanero;
      private ObservableCollection<Det_Operacion> m_ItemsDet_OperacionTransporte;
      private ObservableCollection<Det_Operacion> m_ItemsDet_OperacionRegistros;
      private ObservableCollection<Det_Operacion> m_ItemsDet_OperacionRegistros_Eliminados;
      private ObservableCollection<Det_Operacion> m_ItemsDet_OperacionRegistrosTemporal;
      private ObservableCollection<Det_Operacion> m_ItemsGrillaDet_Operacion;

      Boolean isMViewShow = false;
      #endregion

      #region [ Constructor ]
      public PRO003Presenter(IUnityContainer x_container, IPRO003LView x_lview, IPRO003MView x_mview, IPRO003DMview x_dmview, IPRO003DSMview x_dsmview)
      {
         try
         {
            ContainerService = x_container;
            Session = ContainerService.Resolve<ISessionService>();
            LView = x_lview;
            MView = x_mview;
            DView = x_dmview;
            DSView = x_dsmview;
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

      public IPRO003LView LView { get; set; }
      public IPRO003MView MView { get; set; }
      public IPRO007MView MView2 { get; set; }
      public IPRO003DMview DView { get; set; }
      public IPRO003DSMview DSView { get; set; }
      public InstanceEntity Instancia { get; set; }
      public InstanceEntity InstanciaEdicion { get; set; }
      public ObservableCollection<TiposEntidad> ListTiposEntidad { get; set; }
      public ObservableCollection<Constantes> ListConstantes { get; set; }
      public ObservableCollection<Constantes> ListConstantesEstado { get; set; }
      public ObservableCollection<Constantes> ListConstantesTipo { get; set; }
      public ObservableCollection<Tipos> ListZonas { get; set; }
      public ObservableCollection<Tipos> ListZonasDestino { get; set; }

      public DateTime FILTRO_FecEmiDesde { get; set; }
      public DateTime FILTRO_FecEmiHasta { get; set; }

      public Int32? FILTROCliente { get; set; }
      public String FILTRONroOperacion { get; set; }
      public String CCOT_NumDoc { get; set; }
      public Int32 CCOT_Codigo { get; set; }
      public Int32? ENTC_Codigo { get; set; }
      public Decimal CCOT_CIF { get; set; }
      public Boolean _NuevoServicio { get; set; }
      public int Position { set; get; }
      public Int32? CCOT_CodigoLogistico { get; set; }
      public Int32? CCOT_CodigoAduanero { get; set; }
      public Int32? CCOT_CodigoTransporte { get; set; }
      public String Moneda { get; set; }
      public Decimal COPE_Fob { get; set; }
      public Decimal COPE_Flete { get; set; }
      public Decimal COPE_Seguro { get; set; }
      public String TipoTarifario { get; set; }
      public Boolean PrecioSada { get; set; }

      public Int32 SituacionFactCliente { get; set; }
      public Int32 SituacionFactProveedor { get; set; }
      #region [ Encabezado Operación ]

      public Cab_Operacion ItemLView
      {
         get { return m_itemLView; }
         set { m_itemLView = value; }
      }
      public Cab_Operacion ItemCab_Operacion
      {
         get { return m_ItemCab_Operacion; }
         set { m_ItemCab_Operacion = value; }
      }
      public ObservableCollection<Cab_Operacion> ItemsCab_Operacion { get; set; }
      #endregion

      #region [ Detalle Operación ]
      public DataTable ItemsServicios { set; get; }
      public ObservableCollection<Det_Cotizacion> ItemsDet_Cotizacion
      {
         get { return m_ItemsDet_Cotizacion; }
         set { m_ItemsDet_Cotizacion = value; }
      }
      public ObservableCollection<Det_Cotizacion> TempItemsDet_Cotizacion { get; set; }
      public ObservableCollection<Det_Cotizacion_Servicio> ItemsDet_Cotizacion_Servicio
      {
         get { return m_ItemsDet_Cotizacion_Servicio; }
         set { m_ItemsDet_Cotizacion_Servicio = value; }
      }

      public ObservableCollection<Det_Cotizacion_Servicio> ItemsDet_Cotizacion_Servicio_parcial
      {
         get { return m_ItemsDet_Cotizacion_Servicio_Parcial; }
         set { m_ItemsDet_Cotizacion_Servicio_Parcial = value; }
      }

      public ObservableCollection<Det_Operacion> ItemsDet_OperacionRegistros
      {
         get { return m_ItemsDet_OperacionRegistros; }
         set { m_ItemsDet_OperacionRegistros = value; }
      }
      public ObservableCollection<Det_Operacion> ItemsDet_OperacionRegistros_Eliminados
      {
         get { return m_ItemsDet_OperacionRegistros_Eliminados; }
         set { m_ItemsDet_OperacionRegistros_Eliminados = value; }
      }

      public ObservableCollection<Det_Operacion> ItemsDet_OperacionRegistrosTemporal
      {
         get { return m_ItemsDet_OperacionRegistros; }
         set { m_ItemsDet_OperacionRegistros = value; }
      }
      public ObservableCollection<Det_Operacion> ItemsDet_OperacionLogistico
      {
         get { return m_ItemsDet_OperacionLogistico; }
         set { m_ItemsDet_OperacionLogistico = value; }
      }
      public ObservableCollection<Det_Operacion> ItemsDet_OperacionAduanero
      {
         get { return m_ItemsDet_OperacioAduanero; }
         set { m_ItemsDet_OperacioAduanero = value; }
      }
      public ObservableCollection<Det_Operacion> ItemsDet_OperacionTransporte
      {
         get { return m_ItemsDet_OperacionTransporte; }
         set { m_ItemsDet_OperacionTransporte = value; }
      }
      public ObservableCollection<Det_Operacion> ItemsDet_Operacion { get; set; }
      public ObservableCollection<Det_Operacion> ItemsGrillaDet_Operacion
      {
         get { return m_ItemsGrillaDet_Operacion; }
         set { m_ItemsGrillaDet_Operacion = value; }
      }


      public Det_Operacion_Servicio ItemDet_OperacionServicio { get; set; }
      public Det_Operacion_Servicio TempItemDet_OperacionServicio { get; set; }
      public ObservableCollection<Det_Operacion_Servicio> ItemsDet_OperacionServicio { get; set; }
      public ObservableCollection<Det_Operacion_Servicio> ItemsDet_OperacionServicio_Eliminar { get; set; }

      public Det_Operacion ItemDet_Operacion { get; set; }
      public Det_Operacion TempItemDet_Operacion { get; set; }
      #endregion

      #endregion

      #region [ Metodos ]

      #region [ Encabezado Operación ]

      public void Nuevo()
      {
         try
         {
            if (!isMViewShow)
            {
               MView = new PRO003MView();
               MView.Presenter = this;
               MView.LoadView();
            }

            MView.ClearItem();
            InstanciaEdicion = InstanceEntity.Added;
            ItemCab_Operacion = new Cab_Operacion
            {
               AUDI_UsrCrea = Session.UserName,
               AUDI_FecCrea = Session.Fecha,
               Instance = InstanceEntity.Added,
               CONS_TabEstado = "OPE",
               TIPO_TabMND = "MND",
               CONS_TabCRG = "CRG"
            };
            MView.ClearItemsDetallesOperacion();
            MView.ClearItemsDetalleServiciosOperactivo();
            MView.SetInstance(InstanceView.New);
            //((PRO003MView)MView).ShowDialog();
            isMViewShow = true;
            if (LView != null) { ((PRO003MView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
            ((PRO003MView)MView).Show();
            ((PRO003MView)MView).BringToFront();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }

      public DataTable CargaOV(String x_NroOV)
      {
         try
         {
            if (!String.IsNullOrEmpty(x_NroOV))
            {
               Decimal _nro = 0;
               if (Decimal.TryParse(x_NroOV, out _nro))
               { return Client.GetOrdendeVenta(_nro); }
               else
               { return Client.GetOrdendeVenta(x_NroOV); }
            }
            else { return Client.GetOrdendeVenta(x_NroOV); }
         }
         catch (Exception)
         {

            throw;
         }

      }

      public void Editar()
      {
         try
         {
            if (!isMViewShow)
            {
               MView = new PRO003MView();
               MView.Presenter = this;
               MView.LoadView();
            }
            if (ItemLView != null)//ItemCab_Operacion
            {
               InstanciaEdicion = InstanceEntity.Modified;
               MView.ClearItem();
               /* Encabezado  :) */
               ItemCab_Operacion = Client.GetOneCab_Operacion(ItemLView.COPE_Codigo);
               ItemCab_Operacion.AUDI_UsrMod = Session.UserName;
               ItemCab_Operacion.AUDI_FecMod = Session.Fecha;
               ItemCab_Operacion.Instance = InstanceEntity.Modified;
               ItemsDet_OperacionRegistros = new ObservableCollection<Det_Operacion>();
               ItemsDet_OperacionRegistros_Eliminados = new ObservableCollection<Det_Operacion>();
               MView.SetItem();
               //Comento que se trate como instancia Nuevo cuando sea Editar
               //InstanciaEdicion = InstanceEntity.Added;
               /* Detalle Operacion :) */
               ItemsGrillaDet_Operacion = new ObservableCollection<Det_Operacion>();
               MView.ClearItemsDetallesOperacion();
               ItemsDet_Operacion = Client.GetAllDet_OperacionByOperacion(ItemCab_Operacion.COPE_Codigo);
               if (ItemsDet_Operacion.Count(data => data.CTAR_Tipo == "L") > 0)
               {
                  m_ItemsDet_OperacionLogistico = ItemsDet_Operacion.Where(data => data.CTAR_Tipo == "L").ToObservableCollection();
                  MView.SetItemST20_ST40_HBL(ref m_ItemsDet_OperacionLogistico, false);
                  MView.ShowItemsLogisticoDetalleOperacion();
               }
               ItemsDet_OperacionAduanero = ItemsDet_Operacion.Where(data => data.CTAR_Tipo == "A").ToObservableCollection();
               foreach (var item in ItemsDet_OperacionAduanero)
               {
                  item.Validado = true;
                  ItemsDet_OperacionRegistros.Add(item);
               }
               ItemsDet_OperacionTransporte = ItemsDet_Operacion.Where(data => data.CTAR_Tipo == "T").ToObservableCollection();
               foreach (var item in ItemsDet_OperacionTransporte)
               {
                  item.Validado = true;
                  ItemsDet_OperacionRegistros.Add(item);
               }
               MView.ShowItemsAduaneroDetalleOperacion();
               MView.ShowItemsTransporteDetalleOperacion();

               /* Detalle Servicio :) */
               MView.ClearItemsDetalleServiciosOperactivo();
               ItemsDet_OperacionServicio_Eliminar = new ObservableCollection<Det_Operacion_Servicio>();
               ItemsDet_OperacionServicio = Client.GetAllDet_Operacion_ServicioByOperacion(ItemCab_Operacion.COPE_Codigo);
               foreach (var item in ItemsDet_OperacionServicio)
               {
                  item.Validado = true;
               }
               MView.ShowItemsDetalleServiciosOperativo();
               MView.SetInstance(InstanceView.Edit);
               foreach (var item in ItemsDet_OperacionServicio)
               {
                  item.Instance = InstanceEntity.Unchanged;
               }
               //((PRO003MView)MView).ShowDialog();
               isMViewShow = true;
               if (LView != null) { ((PRO003MView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
               ((PRO003MView)MView).Show();
               ((PRO003MView)MView).BringToFront();
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
            if (ItemLView != null)//ItemCab_Operacion
            {
               DialogResult _result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
               if (_result == DialogResult.Yes)
               {
                  if ((ItemLView.COPE_Codigo != ItemCab_Operacion.COPE_Codigo) || (!isMViewShow))
                  {
                     ItemLView.Instance = InstanceEntity.Deleted;
                     if (Client.SaveCab_Operacion(ref m_itemLView))
                     {
                        Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                        Actualizar(true);
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
      public void AnulaOperacion()
      {
         try
         {
            if (ItemLView != null)//ItemCab_Operacion
            {
               DialogResult result = Dialogos.MostrarMensajePregunta(Title, "¿Esta seguro que desea anular la operación ?", Dialogos.LabelBoton.Si_No);
               if (result == DialogResult.Yes)
               {
                  if (Client.AnularOperacion(ItemLView.COPE_Codigo, "004", Session.UserName)) // 004 Estado Anulado Constantes
                  {
                     Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha anulado la operación.");
                     Actualizar(true);
                  }
                  else
                  { Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al realizar la acción seleccionada."); }
               }
            }
            else
            { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
      }
      public void Actualizar(Boolean ActualizarBasedatos = true)
      {
         try
         {
            if (ActualizarBasedatos)
            {
               ItemLView = null;
               ItemCab_Operacion = null;
               ItemsCab_Operacion = null;
               LView.FiltrosLView();
               ItemsCab_Operacion = Client.GetAllOperacionByFiltros(FILTROCliente, FILTRONroOperacion, FILTRO_FecEmiDesde, FILTRO_FecEmiHasta, SituacionFactCliente, SituacionFactProveedor, null);
            }
            else
            {
               ObservableCollection<Cab_Operacion> _listOpe = Client.GetAllOperacionByFiltros(FILTROCliente, FILTRONroOperacion, DateTime.Parse("01/01/1970"), DateTime.Now, SituacionFactCliente, SituacionFactProveedor, ItemCab_Operacion.COPE_Codigo);
               if (_listOpe != null && _listOpe.Count > 0)
               {
                  InstanceEntity _tmpInstance = ItemCab_Operacion.Instance;
                  ItemCab_Operacion = _listOpe[0];
                  ItemCab_Operacion.Instance = _tmpInstance;
                  if (ItemCab_Operacion.Instance == InstanceEntity.Added)
                  {
                     if (ItemsCab_Operacion == null) { ItemsCab_Operacion = new ObservableCollection<Cab_Operacion>(); }
                     ItemsCab_Operacion.Add(ItemCab_Operacion);
                  }
                  else if (ItemCab_Operacion.Instance == InstanceEntity.Modified)
                  {
                     var ItemResultado = ItemsCab_Operacion.FirstOrDefault(data => data.COPE_Codigo == ItemCab_Operacion.COPE_Codigo);
                     if (ItemResultado != null)
                     {
                        Position = ItemsCab_Operacion.IndexOf(ItemResultado);
                        ItemCab_Operacion = Client.GetOneOperacionLview(ItemResultado.COPE_Codigo);
                        ItemsCab_Operacion[Position] = ItemCab_Operacion;
                     }
                  }
               }
            }
            LView.ShowItems();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }
      public bool GuardarOperacion()
      {
         try
         {
            String mensajeError = String.Empty;
            MView.GetItem();
            Int32 fila = 0;
            if (ItemCab_Operacion.Validar())
            {
               if (ItemCab_Operacion.Instance == InstanceEntity.Added && Client.GetVerificaHBLOperacion(ItemCab_Operacion.COPE_HBL))
               {
                  Dialogos.MostrarMensajeInformacion(Title, "ya existe HBL verifique porfavor."); return false;
               }
               if (ItemsGrillaDet_Operacion != null)
               {
                  //if (ItemsGrillaDet_Operacion.Count == 0) { mensajeError += "* Debe ingresarse al menos un detalle para poder guardar la operación." + Environment.NewLine; }
                  foreach (var item in ItemsGrillaDet_Operacion)
                  {
                     fila++;
                     if (!item.Validado)
                     {
                        mensajeError += "* Debe ingresar el total del servicio logístico fila Nro " + fila + Environment.NewLine;
                     }
                  }
                  if (ItemsGrillaDet_Operacion.Count(tipo => tipo.TIPE_Codigo != null && tipo.TIPE_Codigo.Value == (short)14) > 1) // DEP Temporal 
                  {
                     Dialogos.MostrarMensajeInformacion(Title, "Servicios Logístico Repetidos: ", "No puede haber mas de un deposito temporal.", Dialogos.Boton.Detalles);
                     return false;
                  }
                  if (ItemsGrillaDet_Operacion.Count(tipo => tipo.TIPE_Codigo != null && tipo.TIPE_Codigo.Value == (short)15) > 1) // DEP Vacio 
                  {
                     Dialogos.MostrarMensajeInformacion(Title, "Servicios Logístico Repetidos: ", "No puede haber mas de un deposito vacio.", Dialogos.Boton.Detalles);
                     return false;
                  }
               }
               //else
               //{
               //   mensajeError += "* Debe ingresarse al menos un detalle para poder guardar la operación." + fila + Environment.NewLine;
               //}
               if (ItemsDet_OperacionRegistros != null)
               {
                  ItemsDet_OperacionAduanero = new ObservableCollection<Det_Operacion>();
                  ItemsDet_OperacionAduanero = ItemsDet_OperacionRegistros.Where(data => data.CTAR_Tipo == "A").ToObservableCollection();
                  if (ListConstantes.Any(item => ItemsDet_OperacionAduanero != null && ItemsDet_OperacionAduanero.Count(tipo => tipo.CONS_CodBas == item.CONS_CodBas) > 1))
                  {
                     Dialogos.MostrarMensajeInformacion(Title, "Servicios Aduaneros Repetidos: ", "No puede haber mas de una base.", Dialogos.Boton.Detalles);
                     return false;
                  }
                  ItemsDet_OperacionTransporte = ItemsDet_OperacionRegistros.Where(data => data.CTAR_Tipo == "T").ToObservableCollection();

                  if (ListConstantesTipo.Any(item => ItemsDet_OperacionTransporte != null && ItemsDet_OperacionAduanero.Count(tipo => tipo.CONS_CodTRA == item.CONS_CodTipo) > 1))
                  {
                     Dialogos.MostrarMensajeInformacion(Title, "Servicios Transporte Repetidos: ", "No puede haber mas de un tipo transporte.", Dialogos.Boton.Detalles);
                     return false;
                  }
               }
               //if (String.IsNullOrEmpty(mensajeError))
               //{
                  if (ItemsDet_Operacion != null) // && ItemsDet_Operacion.Count > 0)
                  {
                     ItemCab_Operacion.ItemsDet_Operacion = new ObservableCollection<Det_Operacion>();
                     ItemCab_Operacion.ItemsDet_Operacion = ItemsDet_OperacionRegistros;
                     ItemCab_Operacion.ItemsDet_Operacion_Eliminados = ItemsDet_OperacionRegistros_Eliminados;

                     if (ItemsDet_OperacionServicio_Eliminar != null && ItemsDet_OperacionServicio_Eliminar.Count > 0)
                     {
                        ItemCab_Operacion.ItemsDet_Operacion_Servicio_Eliminados = new ObservableCollection<Det_Operacion_Servicio>();
                        ItemCab_Operacion.ItemsDet_Operacion_Servicio_Eliminados = ItemsDet_OperacionServicio_Eliminar;
                     }
                     if (ItemsDet_OperacionServicio != null && ItemsDet_OperacionServicio.Count > 0)
                     {
                        ItemCab_Operacion.ItemsDet_Operacion_Servicio = new ObservableCollection<Det_Operacion_Servicio>();
                        ItemCab_Operacion.ItemsDet_Operacion_Servicio = ItemsDet_OperacionServicio;
                     }

                     if (Client.SaveCab_Operacion(ref m_ItemCab_Operacion))
                     {
                        if (m_ItemCab_Operacion.Instance == InstanceEntity.Added)
                        {
                           //m_ItemCab_Operacion

                        }

                        Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                        Actualizar(false);
                        return true;
                     }
                     Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                     return false;
                  }
                  Dialogos.MostrarMensajeInformacion(Title, "Debe agregar un detalle a la operación como minimo");
                  return false;
               //}
               //Dialogos.MostrarMensajeInformacion(Title, "Faltan ingresar datos obligatorios: ", mensajeError, Dialogos.Boton.Detalles);
               //return false;
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
      public void BuscarCotizaciones()
      {
         try
         {
            //MView.FiltrosCotizaciones();
            //MView.ClearItemsDetallesOperacion();
            //ItemsGrillaDet_Operacion = new ObservableCollection<Det_Operacion>();

            if (CCOT_CodigoLogistico != null || CCOT_CodigoAduanero != null || CCOT_CodigoTransporte != null)
            {
               TempItemsDet_Cotizacion = new ObservableCollection<Det_Cotizacion>();
               ItemsDet_Cotizacion = Client.GetAllDet_CotizacionByOperacion(CCOT_CodigoLogistico, CCOT_CodigoAduanero, CCOT_CodigoTransporte);
               if (ItemsDet_Cotizacion != null && ItemsDet_Cotizacion.Count > 0)
               {
                  var firstOrDefault = ItemsDet_Cotizacion.FirstOrDefault();
                  if (firstOrDefault != null)
                     CCOT_Codigo = firstOrDefault.CCOT_Codigo; // INTERNO
                  var detCotizacion = ItemsDet_Cotizacion.FirstOrDefault();
                  if (detCotizacion != null)
                     CCOT_NumDoc = detCotizacion.CCOT_NumDoc;
                  /* Detalle Cotizacion */
                  ItemsDet_Cotizacion = new ObservableCollection<Det_Cotizacion>();
                  ItemsDet_Operacion = new ObservableCollection<Det_Operacion>();
                  ItemsDet_Cotizacion = Client.GetAllDet_CotizacionByCotizacion(CCOT_Codigo, CCOT_CodigoLogistico == null ? CCOT_CodigoAduanero == null ? "T" : "A" : "L");

                  DetCotizacion_A_DetOperacion(); // Cambiamos de Detalle Cotizacion a Detalle Operación
                  if (ItemsDet_Operacion.Count(data => data.CTAR_Tipo == "L") > 0)
                  {
                     m_ItemsDet_OperacionLogistico = ItemsDet_Operacion.Where(data => data.CTAR_Tipo == "L").ToObservableCollection();
                     MView.SetItemST20_ST40_HBL(ref m_ItemsDet_OperacionLogistico, true);
                     MView.ShowItemsLogisticoDetalleOperacion();
                     //LimpiarServicioAdicional("L");
                  }
                  ItemsDet_OperacionAduanero = ItemsDet_Operacion.Where(data => data.CTAR_Tipo == "A").ToObservableCollection();
                  foreach (var item in ItemsDet_OperacionAduanero)
                  {
                     ENTC_Codigo = item.ENTC_Codigo;
                     if (ItemCab_Operacion.Instance == InstanceEntity.Added) { item.Validado = true; }
                     decimal valor = 0;
                     if (item.CONS_CodBas != null && item.CONS_CodBas.Equals("001")) // CIF
                     {
                        valor = item.DOPE_Venta * (CCOT_CIF / 100);
                        item.DOPE_PrecioTotVta = valor < item.DOPE_Minimo ? item.DOPE_Minimo : valor;
                        //item.DOPE_Costo = item.DOPE_Costo * (CCOT_CIF / 100);
                        item.DOPE_Venta = valor < item.DOPE_Minimo ? item.DOPE_Minimo : valor;
                     }
                     else// Otro
                     {
                        item.DOPE_PrecioTotVta = item.DOPE_Venta;
                     }
                     ItemsDet_OperacionRegistros.Add(item);
                  }
                  ItemsDet_OperacionTransporte = ItemsDet_Operacion.Where(data => data.CTAR_Tipo == "T").ToObservableCollection();
                  foreach (var item in ItemsDet_OperacionTransporte)
                  {
                     ENTC_Codigo = item.ENTC_Codigo;
                     if (ItemCab_Operacion.Instance == InstanceEntity.Added) { item.Validado = true; }
                     item.DOPE_PrecioTotVta = item.DOPE_Venta;
                     ItemsDet_OperacionRegistros.Add(item);
                  }
                  if (CCOT_CodigoAduanero != null)
                  {
                     MView.ShowItemsAduaneroDetalleOperacion();
                     //LimpiarServicioAdicional("A"); 
                  }
                  if (CCOT_CodigoTransporte != null)
                  {
                     MView.ShowItemsTransporteDetalleOperacion();
                     //LimpiarServicioAdicional("T");
                  }
                  /* Detalle Servicio :) */
                  //MView.ClearItemsDetalleServiciosOperactivo();
                  if (CCOT_CodigoTransporte == null)
                  {
                     ItemsDet_Cotizacion_Servicio_parcial = Client.GetAllDet_Cotizacion_ServicioByCotizacion(CCOT_Codigo, CCOT_CodigoLogistico == null ? CCOT_CodigoAduanero == null ? "" : "A" : "L");
                     ServicioDetCotizacion_A_ServiciosDetOperacion();
                     MView.ShowItemsDetalleServiciosOperativo();
                  }
               }
               else
               {
                  ItemsDet_Cotizacion = new ObservableCollection<Det_Cotizacion>();
                  //Dialogos.MostrarMensajeInformacion(Title, "No se encontraron resultados.");
               }
            }
            else
            {
               Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar un servicio de operación.");
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      public void LimpiarServicioAdicional(String _CTAR_Tipo)
      {

         if (ItemsDet_OperacionServicio != null)
         {

            while (ItemsDet_OperacionServicio.FirstOrDefault(tipo => tipo.SOPE_Tipo == _CTAR_Tipo && tipo.Instance != InstanceEntity.Deleted) != null)
            {
               var _item = ItemsDet_OperacionServicio.First(tipo => tipo.SOPE_Tipo == _CTAR_Tipo && tipo.Instance != InstanceEntity.Deleted);
               if (_item.SOPE_Item > 0)
               { _item.Instance = InstanceEntity.Deleted; }
               else
               { ItemsDet_OperacionServicio.Remove(_item); }
            }
         }

      }

      public void CloseView()
      {
         if (isMViewShow)
         { ((PRO003MView)MView).Close(); }
      }
      public void IsClosedMView()
      { isMViewShow = false; }

      #endregion

      #region [ Detalle Operación ]

      public void CargarServicios(Int32 x_COPE_Codigo)
      {
         try
         {
            ItemsServicios = Client.GetServicioByOperacion(x_COPE_Codigo);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al mostrar los servicios.", ex); }
      }
      private void DetCotizacion_A_DetOperacion()
      {
         try
         {
            for (int i = 0; i < ItemsDet_Cotizacion.Count; i++)
            {
               Det_Operacion _Det_Operacion = new Det_Operacion();
               _Det_Operacion.AUDI_UsrCrea = Session.UserName;
               _Det_Operacion.AUDI_FecCrea = Session.Fecha;
               _Det_Operacion.Instance = InstanceEntity.Added;
               _Det_Operacion.CONS_TabEST = "EDO";
               _Det_Operacion.CONS_CodEST = "001";// por defecto ingresada
               _Det_Operacion.Validado = false;
               _Det_Operacion.TIPE_Codigo = m_ItemsDet_Cotizacion[i].TIPE_Codigo != null ? m_ItemsDet_Cotizacion[i].TIPE_Codigo : null;
               _Det_Operacion.TIPE_Descripcion = m_ItemsDet_Cotizacion[i].TIPE_Descripcion;

               _Det_Operacion.ENTC_Codigo = m_ItemsDet_Cotizacion[i].ENTC_Codigo != null ? m_ItemsDet_Cotizacion[i].ENTC_Codigo : null;
               _Det_Operacion.ENTC_RazonSocial = m_ItemsDet_Cotizacion[i].ENTC_RazonSocial;

               _Det_Operacion.PACK_Codigo = m_ItemsDet_Cotizacion[i].PACK_Codigo != null ? m_ItemsDet_Cotizacion[i].PACK_Codigo : null;
               _Det_Operacion.CTAR_Codigo = m_ItemsDet_Cotizacion[i].CTAR_Codigo;
               _Det_Operacion.CTAR_Tipo = m_ItemsDet_Cotizacion[i].CTAR_Tipo;
               _Det_Operacion.DTAR_Item = m_ItemsDet_Cotizacion[i].DTAR_Item;
               //_Det_Operacion.DOPE_Item = i + 1;
               //_Det_Operacion.DOPE_Profit = m_ItemsDet_Cotizacion[i].DTAR_Profit != null ? m_ItemsDet_Cotizacion[i].DTAR_Profit : null;
               _Det_Operacion.CONS_CodBas = m_ItemsDet_Cotizacion[i].CONS_CodBas;
               _Det_Operacion.CONS_CodTipo = m_ItemsDet_Cotizacion[i].CONS_CodTipo;
               _Det_Operacion.CONS_CodTRA = m_ItemsDet_Cotizacion[i].CONS_CodTRA;
               _Det_Operacion.CONS_Desc_SPA = m_ItemsDet_Cotizacion[i].CONS_Desc_SPA;
               _Det_Operacion.CONS_Desc_TRA = m_ItemsDet_Cotizacion[i].CONS_Desc_TRA;
               _Det_Operacion.CONS_TabBas = m_ItemsDet_Cotizacion[i].CONS_TabBas;
               _Det_Operacion.CONS_TabTRA = m_ItemsDet_Cotizacion[i].CONS_TabTRA;
               _Det_Operacion.DESTINO = m_ItemsDet_Cotizacion[i].DESTINO;
               _Det_Operacion.DOPE_Minimo = m_ItemsDet_Cotizacion[i].DCOT_Minimo;
               _Det_Operacion.DOPE_Peso = m_ItemsDet_Cotizacion[i].DCOT_Peso != null ? m_ItemsDet_Cotizacion[i].DCOT_Peso.Value : 0;
               _Det_Operacion.DOPE_Venta = m_ItemsDet_Cotizacion[i].DCOT_Venta;
               _Det_Operacion.DOPE_VentaSada = m_ItemsDet_Cotizacion[i].DCOT_VentaSada;
               _Det_Operacion.DOPE_Costo = m_ItemsDet_Cotizacion[i].DCOT_Costo;
               _Det_Operacion.DOPE_CostoSada = m_ItemsDet_Cotizacion[i].DCOT_CostoSada;
               _Det_Operacion.DOPE_Volumen = m_ItemsDet_Cotizacion[i].DCOT_Volumen;
               _Det_Operacion.ORIGEN = m_ItemsDet_Cotizacion[i].ORIGEN;
               _Det_Operacion.TIPO_CodZONDestino = m_ItemsDet_Cotizacion[i].TIPO_CodZONDestino;
               _Det_Operacion.TIPO_CodZONOrigen = m_ItemsDet_Cotizacion[i].TIPO_CodZONOrigen;
               _Det_Operacion.TIPO_TabZON = m_ItemsDet_Cotizacion[i].TIPO_TabZON;
               _Det_Operacion.DOPE_PrecioTotVta = 0;
               _Det_Operacion.DOPE_PrecioTotCosto = 0;
               ItemsDet_Operacion.Add(_Det_Operacion);
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }
      private void ServicioDetCotizacion_A_ServiciosDetOperacion()
      {
         try
         {
            if (ItemsDet_OperacionServicio == null || ItemsDet_OperacionServicio.Count == 0)
            {
               ItemsDet_OperacionServicio = new ObservableCollection<Det_Operacion_Servicio>();
               ItemsDet_OperacionServicio_Eliminar = new ObservableCollection<Det_Operacion_Servicio>();
            }
            for (int i = 0; i < m_ItemsDet_Cotizacion_Servicio_Parcial.Count; i++)
            {
               Det_Operacion_Servicio _Servicio = new Det_Operacion_Servicio();
               _Servicio.AUDI_UsrCrea = Session.UserName;
               _Servicio.AUDI_FecCrea = Session.Fecha;
               _Servicio.Instance = InstanceEntity.Added;
               _Servicio.Validado = false;
               _Servicio.CONS_TabEST = "EDO";
               _Servicio.CONS_CodEST = "001";// por defecto ingresada

               _Servicio.TIPE_Codigo = m_ItemsDet_Cotizacion_Servicio_Parcial[i].TIPE_Codigo != null ? m_ItemsDet_Cotizacion_Servicio_Parcial[i].TIPE_Codigo.Value : (short)0;

               _Servicio.ENTC_Codigo = m_ItemsDet_Cotizacion_Servicio_Parcial[i].ENTC_Codigo != null ? m_ItemsDet_Cotizacion_Servicio_Parcial[i].ENTC_Codigo.Value : 0;
               _Servicio.Proveedor = m_ItemsDet_Cotizacion_Servicio_Parcial[i].Proveedor;

               _Servicio.SERV_Codigo = m_ItemsDet_Cotizacion_Servicio_Parcial[i].SERV_Codigo != null ? m_ItemsDet_Cotizacion_Servicio_Parcial[i].SERV_Codigo.Value : 0;
               _Servicio.CONS_Desc_Servicio = m_ItemsDet_Cotizacion_Servicio_Parcial[i].CONS_Desc_Servicio;

               _Servicio.TIPO_CodMnd = m_ItemsDet_Cotizacion_Servicio_Parcial[i].TIPO_CodMnd;
               _Servicio.TIPO_TabMnd = m_ItemsDet_Cotizacion_Servicio_Parcial[i].TIPO_TabMnd;
               _Servicio.CONS_Desc_Moneda = m_ItemsDet_Cotizacion_Servicio_Parcial[i].CONS_Desc_Moneda;

               _Servicio.CONS_CodBas = m_ItemsDet_Cotizacion_Servicio_Parcial[i].CONS_CodBas;
               _Servicio.CONS_TabBas = m_ItemsDet_Cotizacion_Servicio_Parcial[i].CONS_TabBas;
               _Servicio.CONS_Desc_Base = m_ItemsDet_Cotizacion_Servicio_Parcial[i].CONS_Desc_Base;

               _Servicio.CONS_CodTMC = m_ItemsDet_Cotizacion_Servicio_Parcial[i].CONS_CodTMC;
               _Servicio.CONS_TabTMC = m_ItemsDet_Cotizacion_Servicio_Parcial[i].CONS_TabTMC;
               _Servicio.CONS_Desc_TMC = m_ItemsDet_Cotizacion_Servicio_Parcial[i].CONS_Desc_TMC;
               _Servicio.SOPE_Tipo = m_ItemsDet_Cotizacion_Servicio_Parcial[i].SCOT_Tipo == "C" ? "O" : m_ItemsDet_Cotizacion_Servicio_Parcial[i].SCOT_Tipo;
               _Servicio.SOPE_Cantidad = m_ItemsDet_Cotizacion_Servicio_Parcial[i].SCOT_Cantidad;
               _Servicio.SOPE_PrecioUni = m_ItemsDet_Cotizacion_Servicio_Parcial[i].SCOT_PrecioUni;
               _Servicio.SOPE_ImporteIngreso = m_ItemsDet_Cotizacion_Servicio_Parcial[i].SCOT_ImporteIngreso;
               _Servicio.SOPE_ImporteEgreso = m_ItemsDet_Cotizacion_Servicio_Parcial[i].SCOT_ImporteEgreso;
               _Servicio.SOPE_ImporteEgreso = m_ItemsDet_Cotizacion_Servicio_Parcial[i].SCOT_ImporteEgreso;
               _Servicio.SOPE_Costo = m_ItemsDet_Cotizacion_Servicio_Parcial[i].SCOT_ImporteEgreso + m_ItemsDet_Cotizacion_Servicio_Parcial[i].SCOT_ImporteIngreso;

               ItemsDet_OperacionServicio.Add(_Servicio);
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }
      public void NuevoDetalleOperacion(Int32? _ENTC_Codigo, Decimal _DOPE_Venta, Decimal _DOPE_Costo)
      {
         try
         {
            TempItemDet_Operacion = new Det_Operacion
            {
               AUDI_UsrCrea = Session.UserName,
               AUDI_FecCrea = Session.Fecha,
               Instance = InstanceEntity.Added,
               ENTC_Codigo = _ENTC_Codigo,
               DOPE_Costo = _DOPE_Costo,
               DOPE_Venta = _DOPE_Venta,
               CONS_TabEST = "EDO",
               CONS_CodEST = "001"    /* INGRESADA */
            };
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }

      public void CrearItem()
      {
         Decimal DOPE_Costo20 = 0;
         Decimal DOPE_Costo20SADA;
         Decimal DOPE_Costo40;
         Decimal DOPE_Costo40SADA;
         Decimal DOPE_CostoHBL;
         Decimal DOPE_CodtoHBLSADA;
         DOPE_Costo20 = ItemDet_Operacion.DOPE_Costo20;
         DOPE_Costo20SADA = ItemDet_Operacion.DOPE_CostoSada20;
         DOPE_Costo40 = ItemDet_Operacion.DOPE_Costo40;
         DOPE_Costo40SADA = ItemDet_Operacion.DOPE_CostoSada40;
         DOPE_CostoHBL = ItemDet_Operacion.DOPE_CostoHBL;
         DOPE_CodtoHBLSADA = ItemDet_Operacion.DOPE_CostoSadaHBL;

         ItemDet_Operacion = new Det_Operacion
         {
            AUDI_UsrCrea = Session.UserName,
            AUDI_FecCrea = Session.Fecha,
            Instance = InstanceEntity.Added,
            CONS_TabEST = "EDO",
            CONS_CodEST = "001",
            DOPE_Costo20 = DOPE_Costo20,
            DOPE_CostoSada20 = DOPE_Costo20SADA,
            DOPE_Costo40 = DOPE_Costo40,
            DOPE_CostoSada40 = DOPE_Costo40SADA,
            DOPE_CostoHBL = DOPE_CostoHBL,
            DOPE_CostoSadaHBL = DOPE_CodtoHBLSADA
         };

      }

      public void AgregarDetalleOperacion()
      {
         try
         {
            Int32? _ENTC_Codigo;
            _ENTC_Codigo = ItemDet_Operacion.ENTC_Codigo;
            Decimal _DOPE_Venta = 0;
            _DOPE_Venta = ItemDet_Operacion.DOPE_Venta;
            Decimal _DOPE_Costo = 0;
            _DOPE_Costo = ItemDet_Operacion.DOPE_Costo;
            if (ItemDet_Operacion.CTAR_Tipo.Equals("L"))
            {
               ObservableCollection<Det_Operacion> TempItemsDet_Operacion = new ObservableCollection<Det_Operacion>();
               ItemsGrillaDet_Operacion.Remove(ItemDet_Operacion);
            continuar:

               foreach (var item in ItemsDet_OperacionRegistros)
               {
                  if (ItemDet_Operacion.DOPE_Fila == item.DOPE_Fila)
                  {
                     if (item.DOPE_Item > 0)
                     {
                        item.Instance = InstanceEntity.Deleted;
                        item.USR_UsrMod = Session.UserName;
                     }
                     else
                     {
                        while (ItemsDet_OperacionRegistros.FirstOrDefault(tipo => tipo.CTAR_Tipo == item.CTAR_Tipo && tipo.ENTC_Codigo == item.ENTC_Codigo && tipo.TIPE_Codigo == item.TIPE_Codigo && tipo.Instance != InstanceEntity.Deleted) != null)
                        {
                           var ite = ItemsDet_OperacionRegistros.FirstOrDefault(tipo => tipo.CTAR_Tipo == item.CTAR_Tipo && tipo.ENTC_Codigo == item.ENTC_Codigo && tipo.TIPE_Codigo == item.TIPE_Codigo && tipo.Instance != InstanceEntity.Deleted);
                           ite.Instance = InstanceEntity.Deleted;
                        }
                        TempItemsDet_Operacion.Add(item);
                        //goto continuar;
                     }
                  }
               }
               //Se elimina de la coleccion solo cuando es nuevo para que se vuelva a agregar y no se repita
               if (InstanciaEdicion == InstanceEntity.Added)
                  foreach (Det_Operacion _detOpe in TempItemsDet_Operacion)
                     ItemsDet_OperacionRegistros.Remove(_detOpe);

               DView.GetItem();
               if (ItemDet_Operacion.Validar())
               {
                  if (ItemsGrillaDet_Operacion != null && ItemsGrillaDet_Operacion.Count > 0)
                  {
                     if (ItemDet_Operacion.TIPE_Codigo != null && ItemDet_Operacion.TIPE_Codigo.Value.ToString(CultureInfo.InvariantCulture).Equals("13")) //maritimo
                     {
                        const short tipeCodigo = 13;
                        if (ItemsGrillaDet_Operacion.Count(tipo => tipo.TIPE_Codigo != null && tipo.TIPE_Codigo.Value == tipeCodigo) > 0)
                        {
                           Dialogos.MostrarMensajeInformacion(Title, "No puede haber mas de un agente maritimo."); return;
                        }
                     }
                  }
                  ItemDet_Operacion.Validado = true;
                  Int32 xUltimaFila = 0;
                  DView.GenerarST20_ST40_HBL(ref xUltimaFila, TempItemsDet_Operacion);
                  ItemDet_Operacion.DOPE_Fila = xUltimaFila;
                  ItemsGrillaDet_Operacion.Add(ItemDet_Operacion);
                  GenerarCantidades();
                  MView.ShowItemsLogisticoDetalleOperacion();
                  DView.CerrarVenta();
               }
               else
               {
                  DView.ShowValidation();
               }
            }
            else   // Tarifa Aduanera || Tarifa Transporte
            {
               if (ItemDet_Operacion.DOPE_Item > 0)
               {
                  ItemDet_Operacion.Instance = InstanceEntity.Deleted;
               }
               else
               {
                  ItemsDet_OperacionRegistros.Remove(ItemDet_Operacion);
               }
               NuevoDetalleOperacion(_ENTC_Codigo, _DOPE_Venta, _DOPE_Costo);
               DView.GetItem();
               if (TempItemDet_Operacion.Validar())
               {
                  TempItemDet_Operacion.Validado = true;
                  if (TempItemDet_Operacion.CTAR_Tipo.Equals("A"))
                  {
                     ItemsDet_OperacionRegistros.Add(TempItemDet_Operacion);
                     MView.ShowItemsAduaneroDetalleOperacion();
                  }
                  else if (TempItemDet_Operacion.CTAR_Tipo.Equals("T"))
                  {
                     ItemsDet_OperacionRegistros.Add(TempItemDet_Operacion);
                     MView.ShowItemsTransporteDetalleOperacion();
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
      public void EditarDetalleOperacion()
      {
         try
         {
            if (ItemDet_Operacion != null)
            {
               Instancia = InstanceEntity.Modified;
               DView.ClearItem();
               DView.SetItem();
               DView.SetInstance(InstanceView.Edit);
               ((PRO003DMview)DView).ShowDialog();
            }
            else
            { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
      }
      public void EliminarDetalleOperacion()
      {
         try
         {
            if (ItemDet_Operacion != null)
            {
               DialogResult result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
               if (result == DialogResult.Yes)
               {
                  if (ItemDet_Operacion.CTAR_Tipo != null && ItemDet_Operacion.CTAR_Tipo.Equals("L"))
                  {
                     ItemsGrillaDet_Operacion.Remove(ItemDet_Operacion);
                     foreach (var item in ItemsDet_OperacionRegistros)
                     {
                        if (ItemDet_Operacion.DOPE_Fila == item.DOPE_Fila)
                        {
                           if (item.DOPE_Item > 0)
                           {
                              item.Instance = InstanceEntity.Deleted;
                           }
                           else
                           {
                              ItemsDet_OperacionRegistros_Eliminados.Add(item);
                           }
                        }
                     }
                     foreach (Entities.Det_Operacion iDelete in ItemsDet_OperacionRegistros_Eliminados)
                     {
                        ItemsDet_OperacionRegistros.Remove(iDelete);
                     }

                     MView.ShowItemsLogisticoDetalleOperacion();
                  }
                  else
                  {
                     if (ItemDet_Operacion.DOPE_Item > 0)
                     {
                        ItemDet_Operacion.Instance = InstanceEntity.Deleted;
                     }
                     else
                     {
                        ItemsDet_OperacionRegistros_Eliminados.Add(ItemDet_Operacion);
                        ItemsDet_OperacionRegistros.Remove(ItemDet_Operacion);
                     }
                     if (ItemDet_Operacion.CTAR_Tipo != null && ItemDet_Operacion.CTAR_Tipo.Equals("A"))
                     {
                        MView.ShowItemsAduaneroDetalleOperacion();
                     }
                     else if (ItemDet_Operacion.CTAR_Tipo != null && ItemDet_Operacion.CTAR_Tipo.Equals("T"))
                     {
                        MView.ShowItemsTransporteDetalleOperacion();
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
      private void GenerarCantidades()
      {
         try
         {
            ObservableCollection<Det_Operacion> tempCollection = ItemsDet_OperacionRegistros.Where(data => data.CTAR_Tipo == "L" && data.Instance != InstanceEntity.Deleted).ToObservableCollection();
            foreach (var item in ItemsDet_OperacionRegistros.Where(data => data.CTAR_Tipo == "L" && data.Instance != InstanceEntity.Deleted).ToObservableCollection())
            {
               Det_Operacion item1 = item;
               Decimal total = 0;
               foreach (var fila in ItemsDet_OperacionRegistros.Where(data => data.CTAR_Tipo == "L" && data.Instance != InstanceEntity.Deleted).ToObservableCollection().Where(data => data.DOPE_Fila == item1.DOPE_Fila))
               {
                  if (fila.PACK_Codigo != null && fila.PACK_Codigo.Value == 1) // 20 
                  {
                     fila.DOPE_Cantidad = ItemDet_Operacion.DOPE_Cantidad20;
                     fila.DOPE_Cantidad20 = ItemDet_Operacion.DOPE_Cantidad20;
                     fila.DOPE_PrecioTotVta20 = PrecioSada ? ItemDet_Operacion.DOPE_Cantidad20 * fila.DOPE_VentaSada20 : ItemDet_Operacion.DOPE_Cantidad20 * fila.DOPE_Venta20;
                     fila.DOPE_PrecioTotVta = PrecioSada ? ItemDet_Operacion.DOPE_Cantidad20 * fila.DOPE_VentaSada20 : ItemDet_Operacion.DOPE_Cantidad20 * fila.DOPE_Venta20;
                     fila.Validado = true;
                     total += fila.DOPE_PrecioTotVta;
                  }
                  if (fila.PACK_Codigo != null && fila.PACK_Codigo.Value == 2) // 40 
                  {
                     fila.DOPE_Cantidad = ItemDet_Operacion.DOPE_Cantidad40;
                     fila.DOPE_Cantidad40 = ItemDet_Operacion.DOPE_Cantidad40;
                     fila.DOPE_PrecioTotVta40 = PrecioSada ? ItemDet_Operacion.DOPE_Cantidad40 * fila.DOPE_VentaSada40 : ItemDet_Operacion.DOPE_Cantidad40 * fila.DOPE_Venta40;
                     fila.DOPE_PrecioTotVta = PrecioSada ? ItemDet_Operacion.DOPE_Cantidad40 * fila.DOPE_VentaSada40 : ItemDet_Operacion.DOPE_Cantidad40 * fila.DOPE_Venta40;
                     fila.Validado = true;
                     total += fila.DOPE_PrecioTotVta;
                  }
                  if (fila.PACK_Codigo == null && (fila.TIPE_Codigo != null && fila.TIPE_Codigo.Value.ToString(CultureInfo.InvariantCulture).Equals("13"))) // HBL  solo agente maritimo
                  {
                     fila.DOPE_Cantidad = Convert.ToInt16(ItemDet_Operacion.DOPE_Cantidad20 + ItemDet_Operacion.DOPE_Cantidad40);
                     fila.DOPE_PrecioTotVta = (PrecioSada ? fila.DOPE_VentaSadaHBL : fila.DOPE_VentaHBL) * fila.DOPE_Cantidad;
                     total += fila.DOPE_PrecioTotVta;
                     fila.Validado = true;

                  }
               }
               var firstOrDefault = ItemsGrillaDet_Operacion.FirstOrDefault(data => data.DOPE_Fila == item1.DOPE_Fila);
               if (firstOrDefault != null)
               {
                  ItemsGrillaDet_Operacion.FirstOrDefault(data => data.DOPE_Fila == item1.DOPE_Fila).Validado = true;
                  ItemsGrillaDet_Operacion.FirstOrDefault(data => data.DOPE_Fila == item1.DOPE_Fila).DOPE_Cantidad20 = ItemDet_Operacion.DOPE_Cantidad20;
                  ItemsGrillaDet_Operacion.FirstOrDefault(data => data.DOPE_Fila == item1.DOPE_Fila).DOPE_Cantidad40 = ItemDet_Operacion.DOPE_Cantidad40;
                  ItemsGrillaDet_Operacion.FirstOrDefault(data => data.DOPE_Fila == item1.DOPE_Fila).DOPE_PrecioTotVta = total;
               }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al agregar el nuevo registro.", ex); }
      }
      #endregion

      #region [ Detalle Operación Servicios ]
      public DataTable GetTodosServicios()
      {
         try
         {
            return Client.GetServiciosAdicionales(7);
            //return Client.GetAllServicio().ToDataTable();
         }
         catch (Exception)
         { return null; }
      }
      public void LoadNuevoDetalleServicioOperacion()
      {
         try
         {
            _NuevoServicio = true;
            DSView.ClearItem();
            DSView.SetInstance(InstanceView.New);
            ((PRO003DSMview)DSView).ShowDialog();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }
      private void NuevoDetalleServicioOperacion(String _Tipo)
      {
         try
         {
            TempItemDet_OperacionServicio = new Det_Operacion_Servicio
            {
               AUDI_UsrCrea = Session.UserName,
               AUDI_FecCrea = Session.Fecha,
               CONS_TabTMC = "TMC",
               SOPE_Tipo = _Tipo,
               Instance = InstanceEntity.Added,
               CONS_TabEST = "EDO",
               CONS_CodEST = "001" /* INGRESADA */
            };
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }
      public void AgregarDetalleServicioOperacion()
      {
         try
         {
            String _Tipo = "O";
            if (ItemDet_OperacionServicio != null)
            {
               if (ItemDet_OperacionServicio.SOPE_Item > 0 && !_NuevoServicio)
               {
                  //ItemDet_OperacionServicio.Instance = InstanceEntity.Deleted;
                  ItemsDet_OperacionServicio.Remove(ItemDet_OperacionServicio);
                  _Tipo = ItemDet_OperacionServicio.SOPE_Tipo;
               }
               else
               {
                  if (!_NuevoServicio)
                  {
                     ItemsDet_OperacionServicio.Remove(ItemDet_OperacionServicio);
                  }
               }
            }
            NuevoDetalleServicioOperacion(_Tipo);
            DSView.GetItem();
            if (TempItemDet_OperacionServicio.Validar())
            {
               TempItemDet_OperacionServicio.Validado = true;
               ItemsDet_OperacionServicio.Add(TempItemDet_OperacionServicio);
               MView.ShowItemsDetalleServiciosOperativo();
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
      public Boolean GuardarDetalleServicioOperacion()
      {
         try
         {
            //TempItemDet_OperacionServicio = new Det_Operacion_Servicio();
            TempItemDet_OperacionServicio.SOPE_Item = ItemDet_OperacionServicio.SOPE_Item;
            DSView.GetItem();
            return true;

            //String _Tipo = "O";
            //if (ItemDet_OperacionServicio != null)
            //{
            //   if (ItemDet_OperacionServicio.SOPE_Item > 0 && !_NuevoServicio)
            //   {
            //      //ItemDet_OperacionServicio.Instance = InstanceEntity.Deleted;
            //      ItemsDet_OperacionServicio.Remove(ItemDet_OperacionServicio);
            //      _Tipo = ItemDet_OperacionServicio.SOPE_Tipo;
            //   }
            //   else
            //   {
            //      if (!_NuevoServicio)
            //      {
            //         ItemsDet_OperacionServicio.Remove(ItemDet_OperacionServicio);
            //      }
            //   }
            //}
            //NuevoDetalleServicioOperacion(_Tipo);
            //DSView.GetItem();
            //if (TempItemDet_OperacionServicio.Validar())
            //{
            //   TempItemDet_OperacionServicio.Validado = true;
            //   ItemsDet_OperacionServicio.Add(TempItemDet_OperacionServicio);
            //   MView.ShowItemsDetalleServiciosOperativo();
            //   DSView.CerrarVenta();
            //}
            //else
            //{
            //   DSView.ShowValidation();
            //}
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex);
            return false;
         }
      }
      public Boolean EditarServicioDetalleOperacion()
      {
         try
         {
            if (ItemDet_OperacionServicio != null)
            {
               if (ItemDet_OperacionServicio.DOCV_Codigo == 0)
               {
                  _NuevoServicio = false;
                  DSView.ClearItem();
                  DSView.SetItem();
                  DSView.SetInstance(InstanceView.Edit);
                  if (((PRO003DSMview)DSView).ShowDialog() == DialogResult.OK)
                  { return true; }
               }
               else
               {
                  Dialogos.MostrarMensajeInformacion(Title, "No se puede editar debido a que ya esta prefacturado este servicio");
               }
               return false;
            }
            else
            { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex);
         }
         return false;
      }
      public void EliminarDetalleServicioOperacion()
      {
         try
         {
            if (ItemDet_OperacionServicio != null)
            {
               DialogResult result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
               if (result == DialogResult.Yes)
               {
                  if (ItemDet_OperacionServicio.SOPE_Item > 0)
                  {
                     ItemsDet_OperacionServicio_Eliminar.Add(ItemDet_OperacionServicio);
                     ItemsDet_OperacionServicio.Remove(ItemDet_OperacionServicio);
                  }
                  else
                  {
                     ItemsDet_OperacionServicio_Eliminar.Add(ItemDet_OperacionServicio);
                     ItemsDet_OperacionServicio.Remove(ItemDet_OperacionServicio);
                  }
                  MView.ShowItemsDetalleServiciosOperativo();
               }
            }
            else
            { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
      }
      #endregion

      #endregion
   }
}