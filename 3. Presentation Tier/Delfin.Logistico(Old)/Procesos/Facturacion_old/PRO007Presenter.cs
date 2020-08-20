using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Delfin.Controls;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Aspect.Collections;
using Microsoft.Practices.Unity;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using Infrastructure.WinFormsControls;
using Infrastructure.Aspect.Constants;
using Microsoft.Reporting.WinForms;

namespace Delfin.Logistico
{
   public class PRO007Presenter
   {
      #region [ Variables ]
      public String Title = "Facturación";
      public String CUS = "PRO007";

      private PreDocsVta m_ItemPreDocsVta;
      private ObservableCollection<PreDetDocsVta> m_ItemsPreDetDocsVta;
      private DocsVta m_ItemDocsVta;

      public enum TipoImpresion
      { Imprimir = 0, Revisar = 1 }

      public enum TFacturacion
      { SLI = 0, Otros = 1, Mandato = 2 }

      public enum TipoInicio
      {
         NuevoFactura = 0, EditarFactura = 1, NuevoPreFactura = 2, EditarPreFactura = 3, EditarNotaCredito = 4
      }

      #endregion

      #region [ Constructor ]
      public PRO007Presenter(IUnityContainer x_container, IPRO007LView x_lview, IPRO007MView x_mview)
      {
         try
         {
            ContainerService = x_container;
            Session = ContainerService.Resolve<ISessionService>();
            LView = x_lview;
            MView = x_mview;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.ConstructorPresenter, ex); }
      }
      public PRO007Presenter(IUnityContainer x_container, IPRO007LView x_lview, IPRO007MView x_mview, IPRO007RView x_rmview)
      {
         try
         {
            ContainerService = x_container;
            Session = ContainerService.Resolve<ISessionService>();
            LView = x_lview;
            MView = x_mview;
            RMView = x_rmview;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.ConstructorPresenter, ex); }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<Delfin.ServiceContracts.IDelfinServices>();
            TipoFacturacion = TFacturacion.SLI;

            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            //_listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrSERI_UnidadNegocio", FilterValue = "S", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
            ListSeries = Client.GetAllSeriesFilter("VEN_SERISS_Todos", _listFilters);
            ListServicio = new ObservableCollection<Servicio>();
            ListServicio = Client.GetAllServicio();

            FactLibre = false;
            try
            {
               Entities.Parametros _para = Client.GetOneParametrosByClave("FACT_FLIBRE");
               if (_para != null) { FactLibre = _para.PARA_Valor.ToString().Equals("1"); }
               _para = Client.GetOneParametrosByClave("FL_TIPOSTDO");
               if (_para != null) { TiposTDO = _para.PARA_Valor.ToString().Split('|'); }
               _para = Client.GetOneParametrosByClave("FL_TIPOSMND");
               if (_para != null) { TiposMND = _para.PARA_Valor.ToString().Split('|'); }
            }
            catch (Exception)
            { FactLibre = false; }

            LView.LoadView();
            MView.LoadView();
            var item = Client.GetOneParametrosByClave("IGV");
            decimal igv;
            if (item != null && decimal.TryParse(item.PARA_Valor, out igv))
            { IGV = igv; }

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.LoadPresenter, ex); }
      }
      #endregion

      #region [ Propiedades ]

      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public Delfin.ServiceContracts.IDelfinServices Client { get; set; }
      public IPRO007LView LView { get; set; }
      public IPRO007MView MView { get; set; }
      public IPRO007RView RMView { get; set; }
      public IPRO007MViewFactLibre MViewFL { get; set; }
      public Int32 COPE_Codigo { get; set; }
      public Int32 TARJ_Codigo { get; set; }

      public Entities.Entidad ClienteSelected { get; set; }

      public String TipoDocumentoVenta { get; set; }
      public String TipoPreFactura { get; set; }
      public String TipoMoneda { get; set; }
      public String TipoFPago { get; set; }
      public String TipoDoc { get; set; }
      public String ReportPath { get; set; }
      public Decimal IGV { get; set; }
      public Decimal TipoCambio { get; set; }
      public Double DiasCredito { get; set; }

      public DataSet DSReporte { get; set; }
      public DataTable DTServicios;
      public ReportDataSource RepDataSourceCabecera { get; set; }
      public ReportDataSource RepDataSourceDetalle { get; set; }
      public ReportParameter[] Parameters { get; set; }

      private Boolean isMViewShow = false;
      private Boolean isMViewShowFL = false;

      public ObservableCollection<Entities.Series> ListSeries { get; set; }

      public TFacturacion TipoFacturacion { get; set; }

      #region [ Encabezado Facturacion ]

      public PreDocsVta ItemPreDocsVta
      {
         get { return m_ItemPreDocsVta; }
         set { m_ItemPreDocsVta = value; }
      }
      public ObservableCollection<PreDocsVta> ItemsPreDocsVta { get; set; }

      public CtaCte ItemCtaCte { get; set; }
      public CtaCte ItemCtaCteDocMandato { get; set; }
      public ObservableCollection<CtaCte> ItemsCtaCte { get; set; }
      public ObservableCollection<CtaCte> ItemsCtaCteDocMandato { get; set; }

      public DocsVta ItemDocsVta
      {
         get { return m_ItemDocsVta; }
         set { m_ItemDocsVta = value; }
      }
      public DocsVta ItemDocsVtaFL { get; set; }
      public ObservableCollection<DocsVta> ItemsDocsVta { get; set; }
      public TipoImpresion TImpresion { get; set; }
      public Boolean FactLibre { get; set; }
      public String[] TiposTDO { get; set; }
      public String[] TiposMND { get; set; }

      public TipoInicio TInicio { get; set; }
      #endregion

      #region [ Detalle Facturacion ]
      public ObservableCollection<PreDetDocsVta> ItemsPreDetDocsVta
      {
         get { return m_ItemsPreDetDocsVta; }
         set { m_ItemsPreDetDocsVta = value; }
      }
      public ObservableCollection<PreDetDocsVta> GrillaItemsPreDetDocsVta { get; set; }
      //public ObservableCollection<DetDocsVta> GrillaItemsDetDocsVta { get; set; }
      public PreDetDocsVta ItemPreDetDocsVta { get; set; }
      public DetDocsVta ItemDetDocsVta { get; set; }
      public Int32 Entc_CodigoCliente { get; set; }
      public Int32 Entc_Codigo { get; set; }
      public Int16 TIPE_Codigo { get; set; }
      public String DOCV_Serie { get; set; }
      public String DOCV_Observaciones { get; set; }

      public Int32? Entc_CodigoFiltro { get; set; }
      public Boolean F_Estado { get; set; }
      public Boolean F_DocumentosSinSerie { get; set; }
      public String F_DOCV_Estado { get; set; }
      public String F_TIPO_TabTDO { get; set; }
      public String F_TIPO_CodTDO { get; set; }

      public string NroFacturaFiltro { get; set; }
      public DateTime? FecEmisiónIniFiltro { get; set; }
      public DateTime? FecEmisiónFinFiltro { get; set; }
      public String F_Serie { get; set; }
      public String F_UnidadNegocio { get; set; }

      public ObservableCollection<PreDetDocsVta_Det_Operacion> ItemsPreDetDocsVta_Det_Operacion { get; set; }
      public PreDetDocsVta_Det_Operacion ItemPreDetDocsVta_Det_Operacion { get; set; }

      //public ObservableCollection<DetDocsVta_Det_Operacion> ItemsDetDocsVta_Det_Operacion { get; set; }
      //public DetDocsVta_Det_Operacion ItemDetDocsVta_Det_Operacion { get; set; }
      #endregion

      public ObservableCollection<Entities.Servicio> ListServicio { get; set; }

      #endregion

      #region [ Metodos ]

      #region [ Encabezado Facturacion ]

      public void Nuevo()
      {
         try
         {
            this.TInicio = TipoInicio.NuevoPreFactura;
            if (!isMViewShow)
            {
               MView = new PRO007MView();
               MView.Presenter = this;
               MView.LoadView();
            }

            MView.ClearItem();
            ItemPreDocsVta = new PreDocsVta
            {
               AUDI_UsrCrea = Session.UserName,
               AUDI_FecCrea = Session.Fecha,
               Instance = InstanceEntity.Added,
               TIPO_TabFPG = "FPG",
               TIPO_TabTDO = "TDO",
               TIPO_TabMND = "MND"
            };
            MView.ClearItemsDetalles();
            MView.SetInstance(InstanceView.New);
            //((PRO007MView)MView).ShowDialog();
            isMViewShow = true;
            ((PRO007MView)MView).Show();
            ((PRO007MView)MView).BringToFront();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }
      public void Editar(String x_TIPO_CodMND, Decimal x_TipoCambio)
      {
         String _TIPO_CodMND;
         Decimal x_TIPO_Cambio;
         try
         {
            if (!isMViewShow)
            {
               MView = new PRO007MView();
               MView.Presenter = this;
               MView.LoadView();
            }

            if (ItemPreDocsVta != null)
            {
               MView.ClearItem();
               string docvOrigen = ItemPreDocsVta.DOCV_Origen;
               /* Encabezado Pre Factura  :) */
               ItemPreDocsVta = Client.GetOnePreDocsVta(ItemPreDocsVta.PDOC_Codigo);
               ItemPreDocsVta.AUDI_UsrMod = Session.UserName;
               ItemPreDocsVta.AUDI_FecMod = Session.Fecha;
               ItemPreDocsVta.Instance = InstanceEntity.Modified;
               ItemPreDocsVta.DOCV_Origen = docvOrigen;
               _TIPO_CodMND = ItemPreDocsVta.TIPO_CodMND;
               x_TIPO_Cambio = ItemPreDocsVta.DOCV_TipoCambio;
               MView.SetItem();
               MView.ClearItemsDetalles();
               /* Detalle Pre Factura  :) */
               if (!String.IsNullOrEmpty(ItemPreDocsVta.DOCV_Origen))
               {
                  if (ItemPreDocsVta.DOCV_Origen.Equals("OPERACION"))
                  {
                     TipoPreFactura = "OPERACION";
                     EdicionServiciosOperacion();
                     ServiciosOperacion(_TIPO_CodMND, x_TIPO_Cambio);
                     MView.ShowItemsDetalles();
                     MView.Calculos();
                  }
                  else
                  {
                     TipoPreFactura = "Tarjas";
                     DTServicios = Client.GetAllDet_TarjasServiciosFacturacion(ItemPreDocsVta.PDOC_Codigo, x_TIPO_CodMND, x_TipoCambio);
                     ServiciosTarjas(false);
                     MView.Calculos();
                     MView.ShowItemsDetalles();
                  }
               }
               MView.SetInstance(InstanceView.Edit);
               //((PRO007MView)MView).ShowDialog();
               isMViewShow = true;
               ((PRO007MView)MView).Show();
               ((PRO007MView)MView).BringToFront();
            }
            else
            { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
      }
      public void AbrirFactura()
      {
         try
         {
            if (ItemDocsVta != null)
            {
               /* Encabezado Factura  :) */
               MView.ClearItem();
               ItemDocsVta = Client.GetOneDocsVta(ItemDocsVta.DOCV_Codigo);
               MView.SetItem();

               TInicio = TipoInicio.EditarFactura;
               /* Detalle  Factura  :) */
               MView.ClearItemsDetalles();
               ServiciosDetDocsVta();
               MView.Calculos();
               MView.ShowItemsDetalles();
               MView.SetInstance(InstanceView.Default);
               MView.SetEnabled();
               ((PRO007MView)MView).ShowDialog();
            }
            else
            { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
      }
      public void AbrirNotaCredito()
      {
         try
         {
            PRO022Presenter PRO022_Presenter = new PRO022Presenter(ContainerService, null, PRO022Presenter.TipoInicio.EditarFacturacion);
            PRO022_Presenter.CUS = "PRO022";
            PRO022_Presenter.ItemDocsVta = ItemDocsVta;
            PRO022_Presenter.Load();
            Actualizar();
         }
         catch (Exception)
         {

            throw;
         }
      }

      public void AnularPreFactura()
      {
         try
         {
            if (ItemPreDocsVta != null)
            {
               DialogResult result = Dialogos.MostrarMensajePregunta(Title, "¿ Desea anular la pre factura?", Dialogos.LabelBoton.Si_No);
               if (result == DialogResult.Yes)
               {
                  ItemPreDocsVta.Instance = InstanceEntity.Modified;
                  ItemPreDocsVta.CONS_TabANU = Constantes.GetTabAnulacion();
                  ItemPreDocsVta.CONS_CodANU = Constantes.GetCodAnulacion(Constantes.TipoAnulacion.AnulacionPreFactura);
                  ItemPreDocsVta.AUDI_UsrMod = Session.UserName;
                  ItemPreDocsVta.AUDI_FecMod = Session.Fecha;
                  if (Client.SaveAnulacionPreFacturaPreDocsVta(m_ItemPreDocsVta, m_ItemPreDocsVta.DOCV_Origen))
                  {
                     Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha anulado el item.");
                     Actualizar();
                  }
                  else
                  { Dialogos.MostrarMensajeInformacion(Title, "No se ha podido anular el item debido a que ya se encuentra relacionado."); }
               }
            }
            else
            { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
      }
      public void AnularFactura_SLI()
      {
         try
         {
            if (ItemDocsVta != null)
            {
               DialogResult result = Dialogos.MostrarMensajePregunta(Title, "¿ Desea anular el documento de venta Nro. " + ItemDocsVta.DOCV_Numero + "  ?", Dialogos.LabelBoton.Si_No);
               if (result == DialogResult.Yes)
               {
                  ItemDocsVta.CONS_TabANU = Constantes.GetTabAnulacion();
                  ItemDocsVta.CONS_CodANU = Constantes.GetCodAnulacion(Constantes.TipoAnulacion.AnulacionSLI);
                  ItemDocsVta.AUDI_UsrMod = Session.UserName;
                  ItemDocsVta.AUDI_FecMod = Session.Fecha;
                  if (Client.AnularDocsVtaFacturacion(ItemDocsVta))
                  {
                     Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha anulado el item.");
                     Actualizar();
                  }
                  else
                  { Dialogos.MostrarMensajeInformacion(Title, "No se ha podido anular el item debido por que se encuentra relacionado."); }
               }
            }
            else
            { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
      }
      public void AnularFactura_OV()
      {
         try
         {
            if (ItemDocsVta != null)
            {
               if (String.IsNullOrEmpty(ItemDocsVta.DOCV_Numero))
               {
                  Dialogos.MostrarMensajeInformacion(Title, "NO puede anular un Documento que aun no ha sido Impreso.");
                  return;
               }
               DialogResult result = Dialogos.MostrarMensajePregunta(Title, "¿ Desea anular el documento de venta Nro. " + ItemDocsVta.DOCV_Numero + "  ?", Dialogos.LabelBoton.Si_No);
               if (result == DialogResult.Yes)
               {
                  ItemDocsVta.CONS_TabANU = Constantes.GetTabAnulacion();
                  ItemDocsVta.CONS_CodANU = Constantes.GetCodAnulacion(Constantes.TipoAnulacion.AnulacionOV);
                  ItemDocsVta.AUDI_UsrMod = Session.UserName;
                  ItemDocsVta.AUDI_FecMod = Session.Fecha;
                  Entities.DocsVta _item = ItemDocsVta;
                  if (Client.SaveDocsVta(ref _item, DocsVta.TInterfazDocsVta.AnularFactura))
                  {
                     Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha anulado el item.");
                     Actualizar();
                  }
                  else
                  { Dialogos.MostrarMensajeInformacion(Title, "No se ha podido anular el item debido por que se encuentra relacionado."); }
               }
            }
         }
         catch (Exception)
         { throw; }
      }

      public void Actualizar()
      {
         try
         {
            ItemPreDocsVta = null;
            ItemsPreDocsVta = null;
            LView.FiltrosLView();
            if (!String.IsNullOrEmpty(TipoDocumentoVenta))
            {
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               switch (TipoDocumentoVenta)
               {
                  case "PreFactura":
                     switch (F_UnidadNegocio)
                     {
                        case "S":
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmDOCV_FechaEmisionIni", FilterValue = FecEmisiónIniFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmDOCV_FechaEmisionFin", FilterValue = FecEmisiónFinFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = Entc_CodigoFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Estado", FilterValue = F_Estado, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });
                           //ItemsPreDocsVta = Client.GetAllPorFiltrosLViewPreDocsVta(NroFacturaFiltro, FecEmisiónIniFiltro.Value, FecEmisiónFinFiltro.Value, Entc_CodigoFiltro, Estado);
                           ItemsPreDocsVta = Client.GetAllPreDocsVtaFilter("VEN_PDOCSS_TodosPorFiltros", _listFilters);
                           break;
                        default:
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCCCT_Numero", FilterValue = NroFacturaFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCCCT_FechaEmisionIni", FilterValue = FecEmisiónIniFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCCCT_FechaEmisionFin", FilterValue = FecEmisiónFinFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = Entc_CodigoFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCCCT_Estado", FilterValue = F_Estado, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
                           ItemsCtaCte = Client.GetAllCtaCteFilter("CAJ_CCCTSS_Prefacturados", _listFilters);
                           break;
                     }
                     break;
                  case "Factura":
                     switch (F_UnidadNegocio)
                     {
                        case "S":
                           //ItemsDocsVta = Client.GetAllDocsVtaPorFiltrosLView(NroFacturaFiltro, FecEmisiónIniFiltro.Value, FecEmisiónFinFiltro.Value, Entc_CodigoFiltro, F_Estado);
                           //_listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchDOCV_Numero", FilterValue = NroFacturaFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmDOCV_FechaEmisionIni", FilterValue = FecEmisiónIniFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmDOCV_FechaEmisionFin", FilterValue = FecEmisiónFinFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = Entc_CodigoFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Estado", FilterValue = F_DOCV_Estado, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchSerie", FilterValue = F_Serie, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
                           ItemsDocsVta = Client.GetAllDocsVtaFilter("VEN_DOCVSS_TodosByFiltros", _listFilters);
                           break;
                        case "M":
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCCCT_Numero", FilterValue = NroFacturaFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCCCT_FechaEmisionIni", FilterValue = FecEmisiónIniFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCCCT_FechaEmisionFin", FilterValue = FecEmisiónFinFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = Entc_CodigoFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCCCT_Estado", FilterValue = F_DOCV_Estado, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_TabTDO", FilterValue = F_TIPO_TabTDO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodTDO", FilterValue = F_TIPO_CodTDO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchSerie", FilterValue = F_Serie, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });

                           ItemsCtaCteDocMandato = Client.GetAllCtaCteFilter("CAJ_CCCTSS_TodosDocMandato", _listFilters);
                           break;
                        default:

                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCCCT_Numero", FilterValue = NroFacturaFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCCCT_FechaEmisionIni", FilterValue = FecEmisiónIniFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCCCT_FechaEmisionFin", FilterValue = FecEmisiónFinFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = Entc_CodigoFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCCCT_Estado", FilterValue = F_DOCV_Estado, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_TabTDO", FilterValue = F_TIPO_TabTDO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodTDO", FilterValue = F_TIPO_CodTDO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchSerie", FilterValue = F_Serie, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
                           _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@IncluirSinSerie", FilterValue = F_DocumentosSinSerie, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });
                           ItemsDocsVta = Client.GetAllDocsVtaFilter("VEN_DOCVSS_Facturados", _listFilters);
                           break;
                     }

                     break;
               }
            }
            LView.ShowItems();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      public bool Guardar()
      {
         try
         {
            if (TipoDocumentoVenta.Equals("Factura"))
            {
               //Client.ModificarCliente(ItemDocsVta.DOCV_Codigo, Entc_Codigo, Session.UserName, TIPE_Codigo);
               Entities.DocsVta _item = new DocsVta();
               _item.DOCV_Codigo = ItemDocsVta.DOCV_Codigo;
               _item.ENTC_Codigo = Entc_Codigo;
               _item.AUDI_UsrMod = Session.UserName;
               _item.TIPE_Codigo = TIPE_Codigo;
               _item.DOCV_Serie = DOCV_Serie;
               _item.DOCV_Observaciones = DOCV_Observaciones;
               Client.SaveDocsVta(ref _item, DocsVta.TInterfazDocsVta.ActualizarFactura);
               Actualizar();
               return true;
            }
            else
            {
               MView.GetItem();
               if (ItemPreDocsVta.Validar())
               {

                  if (GrillaItemsPreDetDocsVta != null && GrillaItemsPreDetDocsVta.Count > 0)
                  {
                     ItemPreDocsVta.ItemsPreDetDocsVta = new ObservableCollection<PreDetDocsVta>();
                     ItemPreDocsVta.ItemsPreDetDocsVta_Det_Operacion = new ObservableCollection<PreDetDocsVta_Det_Operacion>();
                     if (ItemPreDocsVta.Instance == InstanceEntity.Added)
                     {
                        if (GrillaItemsPreDetDocsVta.Where(data => data.Agregar).ToObservableCollection().Count > 0)
                        {
                           ItemPreDocsVta.ItemsPreDetDocsVta = GrillaItemsPreDetDocsVta.Where(data => data.Agregar).ToObservableCollection();// solo los marcados
                           ItemPreDocsVta.ItemsPreDetDocsVta_Det_Operacion = ItemsPreDetDocsVta_Det_Operacion;
                           MView.GetItemTotales();
                           MView.GetItemsDetalleServicios();
                        }
                        else
                        {
                           Dialogos.MostrarMensajeInformacion(Title, "Debe agregar un detalle del documento de venta como minimo");
                           return false;
                        }
                     }
                     else
                     {
                        if (GrillaItemsPreDetDocsVta.Where(data => data.Agregar).ToObservableCollection().Count > 0)
                        {
                           ItemPreDocsVta.ItemsPreDetDocsVta = GrillaItemsPreDetDocsVta;
                           ItemPreDocsVta.ItemsPreDetDocsVta_Det_Operacion = ItemsPreDetDocsVta_Det_Operacion;
                           MView.GetItemTotales();
                           MView.GetItemsDetalleServicios();
                        }
                        else
                        {
                           Dialogos.MostrarMensajeInformacion(Title, "Debe agregar un detalle del documento de venta como minimo");
                           return false;
                        }
                     }
                     if (Client.SavePreDocsVta(ref m_ItemPreDocsVta))
                     {
                        Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                        Actualizar();
                        return true;
                     }
                     Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                     return false;
                  }
                  Dialogos.MostrarMensajeInformacion(Title, "Debe agregar un detalle del documento de venta como minimo");
                  return false;
               }
            }
            MView.ShowValidation();
            return false;
         }
         catch (Exception)
         { throw; }
      }
      /// <summary>
      /// Imprimir un documento de Venta como Factura / Boleta
      /// </summary>
      public void Impresion()
      {
         try
         {
            if (ItemDocsVta.DOCV_Estado.Equals("A"))
            {
               Dialogos.MostrarMensajeInformacion(Title, "No se puede imprimir el item anulado.");
               return;
            }
            if (!ItemDocsVta.DOCV_Estado.Equals("I"))
            {
               if (!ValidarTipoCambio(Session.Fecha.Year.ToString() + Session.Fecha.Month.ToString().PadLeft(2, '0').Trim() + Session.Fecha.Day.ToString().PadLeft(2, '0').Trim()))
               {
                  return;
               }
            }
            DSReporte = new DataSet();
            String _letras = String.Empty;
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintDOCV_Codigo", FilterValue = ItemDocsVta.DOCV_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchAUDI_UsrMod", FilterValue = Session.UserName, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Serie", FilterValue = ItemDocsVta.DOCV_Serie, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
            DSReporte = Client.GetImpresionDSDocsVta("VEN_DDOVSS_TodosImpresionByDOCV_Codigo", _listFilters, Session.UserName, Entorno.ItemSucursal.SUCR_Codigo, true);   //Client.GetAllDocsVtaImpresionFactura(ItemDocsVta.DOCV_Codigo);

            if (DSReporte != null)
            {
               if (DSReporte.Tables.Count < 2) { Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias."); return; }
               _letras = Utilitarios.NumeroALetras(DSReporte.Tables[0].Rows[0]["DOCV_ValorVtaTotal"].ToString(), DSReporte.Tables[0].Rows[0]["TIPO_Desc1"].ToString());
               switch (TImpresion)
               {
                  case TipoImpresion.Imprimir:

                     ReportPath = Application.StartupPath + @"\Reportes\RptFacturacion.rdlc";
                     if (String.Equals(ItemDocsVta.TIPO_CodTDO, "003")) { ReportPath = Application.StartupPath + @"\Reportes\RptFactBoleta.rdlc"; }

                     Parameters = new ReportParameter[3];
                     Parameters[0] = new ReportParameter("Letras", _letras);
                     Parameters[1] = new ReportParameter("IGV", Decimal.Parse(DSReporte.Tables[0].Rows[0]["DOCV_Impuesto1"].ToString()).ToString());

                     String x_Exoneracion = "";
                     Entities.Parametros _para = new Parametros();
                     if (TipoFacturacion == TFacturacion.SLI)
                     {
                        _para = Client.GetOneParametrosByClave("FC_OPSUJETAPOT");
                        if (_para != null) { x_Exoneracion += _para.PARA_Valor.ToString().Trim(); }
                     }

                     if (Decimal.Parse(DSReporte.Tables[0].Rows[0]["DOCV_Impuesto1"].ToString()) == 0)
                     {
                        _para = Client.GetOneParametrosByClave("FC_EXONERADO");
                        if (_para != null) { x_Exoneracion += (x_Exoneracion.Trim().Length > 0 ? Environment.NewLine : "") + _para.PARA_Valor.ToString().Trim(); }
                     }
                     x_Exoneracion += " ";

                     Parameters[2] = new ReportParameter("ExoneracionIGV", x_Exoneracion);
                     //Actualizar();
                     break;
                  case TipoImpresion.Revisar:
                     ReportPath = Application.StartupPath + @"\Reportes\RptFactBoletaView.rdlc";
                     if (String.Equals(ItemDocsVta.TIPO_CodTDO, "003")) { ReportPath = Application.StartupPath + @"\Reportes\RptFactBoletaView.rdlc"; }
                     Parameters = new ReportParameter[7];
                     Parameters[0] = new ReportParameter("Letras", _letras);
                     Parameters[1] = new ReportParameter("IGV", DSReporte.Tables[0].Rows[0]["DOCV_Impuesto1"].ToString());
                     Parameters[2] = new ReportParameter("RUC", Controls.Entorno.ItemEmpresa.EMPR_RUC);
                     Parameters[3] = new ReportParameter("Serie", DSReporte.Tables[0].Rows[0]["DOCV_Serie"].ToString().PadLeft(3, '0'));
                     Parameters[4] = new ReportParameter("Numero", DSReporte.Tables[0].Rows[0]["DOCV_Numero"].ToString().PadLeft(7, '0'));
                     Parameters[5] = new ReportParameter("Total", DSReporte.Tables[0].Rows[0]["DOCV_ValorVtaTotal"].ToString());
                     Parameters[6] = new ReportParameter("SubTotal", DSReporte.Tables[0].Rows[0]["DOCV_ValorTotal"].ToString());
                     break;
               }


               DataColumn _dc = DSReporte.Tables[0].Columns.Add("Usuario", typeof(String));
               DSReporte.Tables[0].Rows[0]["Usuario"] = Session.UserName + " / " + DSReporte.Tables[0].Rows[0]["DOCV_Serie"].ToString().PadLeft(3, '0') + "-" + DSReporte.Tables[0].Rows[0]["DOCV_NUmero"].ToString().PadLeft(7, '0');
               RepDataSourceCabecera = new ReportDataSource("DsEncabezado", DSReporte.Tables[0]);
               RepDataSourceDetalle = new ReportDataSource("DsDetalle", DSReporte.Tables[1]);

               RMView.ShowReporte();
               ((PRO007RView)RMView).Size = new Size(800, 750);
               ((PRO007RView)RMView).MaximizeBox = true;
               ((PRO007RView)RMView).FormBorderStyle = FormBorderStyle.Sizable;
               ((PRO007RView)RMView).ShowDialog();
            }
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Title, Mensajes.SavePresenter, ex);
         }
      }
      /// <summary>
      /// Imprimir una nota de credito
      /// </summary>
      /// <param name="DOCV_Codigo"></param>
      public void ImpresionNC()
      {
         try
         {
            if (ItemDocsVta != null && ItemDocsVta.DOCV_Codigo != 0)
            {
               DocsVta ItemNotaCredito = Client.GetOneDocsVta(ItemDocsVta.DOCV_Codigo);
               if (ItemNotaCredito == null)
               {
                  Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al Imprimir la Nota de Credito.");
                  return;
               }

               if (ItemNotaCredito.DOCV_Estado.Equals("A"))
               {
                  Dialogos.MostrarMensajeInformacion(Title, "No se puede imprimir el item anulado.");
                  return;
               }

               DSReporte = new DataSet();
               String _letras = String.Empty;

               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintDOCV_Codigo", FilterValue = ItemNotaCredito.DOCV_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchAUDI_UsrMod", FilterValue = Session.UserName, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Serie", FilterValue = ItemNotaCredito.DOCV_Serie, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
               if (TipoFacturacion == TFacturacion.SLI)
               { _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@OrigenDoc", FilterValue = "S", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 }); }
               DSReporte = Client.GetImpresionDSDocsVta("VEN_DDOVSS_TodosImpresionByDOCV_Codigo", _listFilters, Session.UserName, Entorno.ItemSucursal.SUCR_Codigo, true);   //Client.GetAllDocsVtaImpresionFactura(ItemDocsVta.DOCV_Codigo);
               //DSReporte = Client.GetAllDocsVtaImpresionFactura(ItemNotaCredito.DOCV_Codigo);
               //DSReportePadre = Client.GetAllDocsVtaImpresionFactura(ItemNotaCredito.DOCV_Codigo);

               if (DSReporte != null)
               {
                  if (!(DSReporte.Tables[2].Rows.Count > 0))
                  { Dialogos.MostrarMensajeInformacion(Title, "No se cargo el documento [Nota de Credito], probablemente no tenga el numero de factura a la que le corresponde."); return; }

                  if (DSReporte.Tables.Count < 3)
                  { Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias."); return; }

                  string nro = DSReporte.Tables[0].Rows[0]["DOCV_Numero"].ToString();

                  ItemNotaCredito.Instance = InstanceEntity.Modified;
                  ItemNotaCredito.DOCV_Numero = nro;
                  ItemNotaCredito.AUDI_UsrMod = Session.UserName;
                  ItemNotaCredito.AUDI_FecMod = Session.Fecha;
                  ItemNotaCredito.DOCV_Estado = "I";
                  DocsVta ItemNC = ItemNotaCredito;

                  //if (Client.SaveDocsVta(ref ItemNC))
                  //{
                  //   ItemNotaCredito = ItemNC;
                  //   Actualizar();
                  //}

                  ReportPath = Application.StartupPath + @"\Reportes\RptFactNC.rdlc";

                  Decimal igvCalc = ((IGV / 100) * Decimal.Parse(DSReporte.Tables[0].Rows[0]["DOCV_ValorTotal"].ToString()));

                  DataColumn _dc = DSReporte.Tables[0].Columns.Add("Usuario", typeof(String));
                  DSReporte.Tables[0].Rows[0]["Usuario"] = Session.UserName + "/" + DSReporte.Tables[0].Rows[0]["DOCV_Serie"] + "-" + DSReporte.Tables[0].Rows[0]["DOCV_NUmero"].ToString().PadLeft(7, '0');
                  RepDataSourceCabecera = new ReportDataSource("DsEncabezado", DSReporte.Tables[0]);
                  RepDataSourceDetalle = new ReportDataSource("DsDetalle", DSReporte.Tables[2]);
                  Parameters = new ReportParameter[4];
                  _letras = Utilitarios.NumeroALetras(DSReporte.Tables[0].Rows[0]["DOCV_ValorVtaTotal"].ToString(), DSReporte.Tables[0].Rows[0]["TIPO_Desc1"].ToString());
                  Parameters[0] = new ReportParameter("Letras", _letras);

                  Parameters[1] = new ReportParameter("IGV", (Decimal.Parse(DSReporte.Tables[0].Rows[0]["DOCV_Impuesto1"].ToString())).ToString());

                  String x_Exoneracion = "";
                  Entities.Parametros _para = new Parametros();
                  if (Decimal.Parse(DSReporte.Tables[2].Rows[0]["DOCV_Impuesto1_Ref"].ToString()) == 0)
                  {
                     _para = Client.GetOneParametrosByClave("FC_EXONERADO");
                     if (_para != null) { x_Exoneracion += (x_Exoneracion.Trim().Length > 0 ? Environment.NewLine : "") + _para.PARA_Valor.ToString().Trim(); }
                  }
                  x_Exoneracion += " ";

                  Parameters[3] = new ReportParameter("ExoneracionIGV", x_Exoneracion);

                  string referenciaPrev = DSReporte.Tables[2].Rows[0]["Referencia"].ToString();
                  string referencia = "Referencia de la Factura: " + referenciaPrev;
                  Parameters[2] = new ReportParameter("Referencia", referencia);

                  RMView.ShowReporte();
                  ((PRO007RView)RMView).Size = new Size(800, 750);
                  ((PRO007RView)RMView).MaximizeBox = true;
                  ((PRO007RView)RMView).FormBorderStyle = FormBorderStyle.Sizable;
                  ((PRO007RView)RMView).ShowDialog();
               }
            }
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Title, Mensajes.SavePresenter, ex);
         }
      }

      public void ImpresionRC()
      {
         try
         {
            DSReporte = new DataSet();
            String _letras = String.Empty;
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintCCCT_Codigo", FilterValue = ItemDocsVta.CCCT_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchAUDI_UsrMod", FilterValue = Session.UserName, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
            DSReporte = Client.GetDSDocsVta("CAJ_CCCTSS_ImprimiReciboCaja", _listFilters, true);

            if (DSReporte != null)
            {
               if (DSReporte.Tables.Count < 2) { Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias."); return; }
               _letras = Utilitarios.NumeroALetras(DSReporte.Tables[0].Rows[0]["DOCV_ValorVtaTotal"].ToString(), DSReporte.Tables[0].Rows[0]["TIPO_Desc1"].ToString());

               ReportPath = Application.StartupPath + @"\Reportes\RptReciboCaja.rdlc";
               //if (String.Equals(ItemCtaCteDocMandato.TIPO_CodTDO, "003")) { ReportPath = Application.StartupPath + @"\Rpts\RptFactBoleta.rdlc"; }

               Parameters = new ReportParameter[2];
               Parameters[0] = new ReportParameter("Letras", _letras);
               Parameters[1] = new ReportParameter("IGV", Decimal.Parse(DSReporte.Tables[0].Rows[0]["DOCV_Impuesto1"].ToString()).ToString());
               //Actualizar();

               DataColumn _dc = DSReporte.Tables[0].Columns.Add("Usuario", typeof(String));
               DSReporte.Tables[0].Rows[0]["Usuario"] = Session.UserName; // DSReporte.Tables[0].Rows[0]["DOCV_Serie"].ToString().PadLeft(3, '0') + "-" + DSReporte.Tables[0].Rows[0]["DOCV_NUmero"].ToString().PadLeft(7, '0');
               RepDataSourceCabecera = new ReportDataSource("DsEncabezado", DSReporte.Tables[0]);
               RepDataSourceDetalle = new ReportDataSource("DsDetalle", DSReporte.Tables[1]);

               RMView.ShowReporte();
               ((PRO007RView)RMView).Size = new Size(800, 750);
               ((PRO007RView)RMView).MaximizeBox = true;
               ((PRO007RView)RMView).FormBorderStyle = FormBorderStyle.Sizable;
               ((PRO007RView)RMView).ShowDialog();
            }
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Title, Mensajes.SavePresenter, ex);
         }
      }

      public void Facturar()
      {
         try
         {
            if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea facturar el registro seleccionado?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
            {
               switch (TipoFacturacion)
               {
                  case TFacturacion.SLI:
                     if (ItemPreDocsVta is Entities.PreDocsVta)
                     {
                        if (ItemPreDocsVta.DOCV_Estado.Equals("A"))
                        {
                           Dialogos.MostrarMensajeInformacion(Title, "No se puede facturar el item anulado.");
                           return;
                        }
                        ItemDocsVta = new DocsVta { AUDI_UsrCrea = Session.UserName, PDOC_Codigo = ItemPreDocsVta.PDOC_Codigo };
                        if (Client.SaveDocsVtaFacturacion(ItemDocsVta))
                        {
                           Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha facturado satisfactoriamente");
                           Actualizar();
                        }
                        else Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al facturar");
                     }
                     break;
                  case TFacturacion.Otros:
                     if (ItemCtaCte is Entities.CtaCte)
                     {
                        Entities.CtaCte _item = ItemCtaCte;
                        _item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                        _item.AUDI_UsrCrea = Session.UserName;

                        if (Client.SaveCtaCte(ref _item, CtaCte.TInterfazCtaCte.Facturar))
                        {
                           Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha facturado satisfactoriamente");
                           Actualizar();
                        }
                        else { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al facturar"); }
                     }
                     break;
                  default:
                     break;
               }
            }
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Title, Mensajes.SavePresenter, ex);
         }
      }

      public Boolean FormaDePago()
      {
         try
         {
            PRO007DViewFPG DView = new PRO007DViewFPG();
            DView.Presenter = this;
            DView.StartPosition = FormStartPosition.CenterScreen;
            DView.FormBorderStyle = FormBorderStyle.FixedDialog;
            DView.ItemDocVta = Client.GetOneDocsVta(ItemDocsVta.DOCV_Codigo);
            if (String.IsNullOrEmpty(DView.ItemDocVta.DOCV_Numero))
            {
               DView.LoadView();
               DialogResult x_dialogo = DView.ShowDialog();
               if (x_dialogo == DialogResult.OK)
               {
                  Entities.DocsVta x_DocsVta = DView.ItemDocVta;
                  x_DocsVta.AUDI_UsrMod = Session.UserName;

                  if (Client.SaveDocsVta(ref x_DocsVta, DocsVta.TInterfazDocsVta.ActualizarFormaPago))
                  {
                     ItemDocsVta.TIPO_CodFPG = x_DocsVta.TIPO_CodFPG;
                     ItemDocsVta.TIPO_TabFPG = x_DocsVta.TIPO_TabFPG;
                     ItemDocsVta.TIPO_FPG = x_DocsVta.TIPO_FPG;
                     ItemDocsVta.DOCV_FechaVcmto = x_DocsVta.DOCV_FechaVcmto;
                     return true;
                  }
               }
            }
            else
            {
               Dialogos.MostrarMensajeInformacion(Title, "No se puede cambiar la forma de pago de un documento impreso.");
            }
            return false;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al cambiar la forma de Pago", ex);
            return false;
         }
      }

      public Boolean RegenerarDocumento()
      {
         try
         {
            PRO007DViewRegenerar DView = new PRO007DViewRegenerar();
            DView.Presenter = this;
            DView.StartPosition = FormStartPosition.CenterScreen;
            DView.FormBorderStyle = FormBorderStyle.FixedDialog;
            DView.ItemDocVta = Client.GetOneDocsVta(ItemDocsVta.DOCV_Codigo);

            if (DView.ItemDocVta.DOCV_Estado.Equals("A"))
            {
               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea regenerar la factura Anulada?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
               {
                  DView.LoadView();
                  DialogResult x_dialogo = DView.ShowDialog();
                  if (x_dialogo == DialogResult.OK)
                  {
                     Entities.DocsVta x_DocsVta = DView.ItemDocVta;
                     x_DocsVta.AUDI_UsrMod = Session.UserName;
                     x_DocsVta.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;

                     if (Client.SaveDocsVta(ref x_DocsVta, DocsVta.TInterfazDocsVta.RegenerarDocumentoVenta))
                     {
                        ItemDocsVta.TIPO_CodFPG = x_DocsVta.TIPO_CodFPG;
                        ItemDocsVta.TIPO_TabFPG = x_DocsVta.TIPO_TabFPG;
                        ItemDocsVta.TIPO_FPG = x_DocsVta.TIPO_FPG;
                        ItemDocsVta.DOCV_FechaVcmto = x_DocsVta.DOCV_FechaVcmto;
                        Actualizar();
                        return true;
                     }
                  }
               }
            }
            else
            {
               Dialogos.MostrarMensajeInformacion(Title, "No se puede regenerar un documento que no se encuentra anulado.");
            }
            return false;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al regenerar documento de venta", ex);
            return false;
         }
      }

      #region [ Operacion ]
      public DataTable LoadAyudaOperacion()
      {
         try
         {
            return Client.GetAllAyudaOperacion(true);
         }
         catch (Exception) { return null; }
      }
      public void ServiciosOperacion(String x_TIPO_CodMND, Decimal x_TIPO_Cambio)
      {
         try
         {
            String _Moneda = "";
            DTServicios = new DataTable();
            DTServicios = Client.GetAllServiciosPreFactura(COPE_Codigo, x_TIPO_CodMND, x_TIPO_Cambio);
            if (DTServicios != null && DTServicios.Rows.Count > 0)
            {
               var first = DTServicios.Select("").FirstOrDefault();
               if (first != null)
               {
                  Entc_CodigoCliente = Int32.Parse(first.ItemArray[4].ToString());  // Cliente
                  //TipoCambio = Decimal.Parse(first.ItemArray[10].ToString());  // Tipo Cambio
                  TipoMoneda = first.ItemArray[11].ToString();  // Tipo Moneda
                  // TipoFPago = first.ItemArray[12].ToString();  // Tipo Pago
                  DiasCredito = Double.Parse(first.ItemArray[12].ToString());  // Dias Credito
                  TipoDoc = first.ItemArray[13].ToString();  // Tipo Documento
               }
               for (int i = 0; i < 4; i++)
               {
                  switch (i)
                  {
                     case 0: // Logistico 
                        if (DTServicios.Select("CTAR_Tipo = 'L'").Any())
                        {
                           foreach (var dr in DTServicios.Select("CTAR_Tipo = 'L'"))
                           {
                              ItemPreDetDocsVta_Det_Operacion = new PreDetDocsVta_Det_Operacion();
                              ItemPreDetDocsVta_Det_Operacion.DOPE_Venta = dr["DOPE_Venta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_Venta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOPE_PrecioTotVta = dr["DOPE_PrecioTotVta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_PrecioTotVta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOPE_Item = dr["DOPE_Item"] != DBNull.Value ? Convert.ToInt32(dr["DOPE_Item"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.COPE_Codigo = dr["COPE_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["COPE_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.SERV_Codigo = dr["SERV_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["SERV_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.CTAR_Tipo = "L";
                              _Moneda = dr["Moneda"].ToString();
                              ItemPreDetDocsVta_Det_Operacion.Importe = Convert.ToDecimal(dr["Importe"].ToString());
                              ItemPreDetDocsVta_Det_Operacion.Agregar = false;
                              ItemsPreDetDocsVta_Det_Operacion.Add(ItemPreDetDocsVta_Det_Operacion);
                           }
                           var firstOrDefault = DTServicios.Select("CTAR_Tipo = 'L'").FirstOrDefault();
                           var servicioDesc = "";
                           Int32 servCodigo = 0;
                           if (firstOrDefault != null)
                           {
                              servicioDesc = firstOrDefault.ItemArray[1].ToString(); //Descripcion
                              servCodigo = Convert.ToInt32(firstOrDefault.ItemArray[2].ToString()); //Servicio
                           }
                           ItemPreDetDocsVta = new PreDetDocsVta
                           {
                              AUDI_UsrCrea = Session.UserName,
                              AUDI_FecCrea = Session.Fecha,
                              Instance = InstanceEntity.Added,
                              Agregar = false,
                              Servicio = servicioDesc,
                              DDOV_ValorVenta = DTServicios.Select("CTAR_Tipo = 'L'").Sum(e => (Decimal)e.ItemArray[3]), //DOPE_Venta
                              CTAR_Tipo = "L",
                              Importe = DTServicios.Select("CTAR_Tipo = 'L'").Sum(e => (Decimal)e.ItemArray[14]), //Importe,
                              Moneda = _Moneda,
                              SERV_Codigo = servCodigo,
                              DDOV_PrecioUnitario = DTServicios.Select("CTAR_Tipo = 'L'").Sum(e => (Decimal)e.ItemArray[8]), //Precio Unitario
                              DDOV_Cantidad = 1
                           };
                           GrillaItemsPreDetDocsVta.Add(ItemPreDetDocsVta);
                        }
                        break;
                     case 1: // Aduana 
                        if (DTServicios.Select("CTAR_Tipo = 'A'").Any())
                        {
                           foreach (DataRow dr in DTServicios.Select("CTAR_Tipo = 'A'"))
                           {
                              ItemPreDetDocsVta_Det_Operacion = new PreDetDocsVta_Det_Operacion();
                              ItemPreDetDocsVta_Det_Operacion.DOPE_Venta = dr["DOPE_Venta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_Venta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOPE_PrecioTotVta = dr["DOPE_PrecioTotVta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_PrecioTotVta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOPE_Item = dr["DOPE_Item"] != DBNull.Value ? Convert.ToInt32(dr["DOPE_Item"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.COPE_Codigo = dr["COPE_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["COPE_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.SERV_Codigo = dr["SERV_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["SERV_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.CTAR_Tipo = "A";
                              _Moneda = dr["Moneda"].ToString();
                              ItemPreDetDocsVta_Det_Operacion.Importe = Convert.ToDecimal(dr["Importe"].ToString());
                              ItemPreDetDocsVta_Det_Operacion.Agregar = false;
                              ItemsPreDetDocsVta_Det_Operacion.Add(ItemPreDetDocsVta_Det_Operacion);
                           }
                           var firstOrDefault = DTServicios.Select("CTAR_Tipo = 'A'").FirstOrDefault();
                           var servicioDesc = "";
                           Int32 servCodigo = 0;
                           if (firstOrDefault != null)
                           {
                              servicioDesc = firstOrDefault.ItemArray[1].ToString(); //Descripcion
                              servCodigo = Convert.ToInt32(firstOrDefault.ItemArray[2].ToString()); //Servicio
                           }
                           ItemPreDetDocsVta = new PreDetDocsVta
                           {
                              AUDI_UsrCrea = Session.UserName,
                              AUDI_FecCrea = Session.Fecha,
                              Instance = InstanceEntity.Added,
                              Agregar = false,
                              Servicio = servicioDesc,
                              DDOV_ValorVenta = DTServicios.Select("CTAR_Tipo = 'A'").Sum(e => (Decimal)e.ItemArray[3]), //DOPE_Venta
                              CTAR_Tipo = "A",
                              Moneda = _Moneda,
                              Importe = DTServicios.Select("CTAR_Tipo = 'A'").Sum(e => (Decimal)e.ItemArray[14]), //Importe,
                              SERV_Codigo = servCodigo,
                              DDOV_PrecioUnitario = DTServicios.Select("CTAR_Tipo = 'A'").Sum(e => (Decimal)e.ItemArray[8]), //Precio Unitario
                              DDOV_Cantidad = 1
                           };
                           GrillaItemsPreDetDocsVta.Add(ItemPreDetDocsVta);
                        }
                        break;
                     case 2: // Transporte 
                        if (DTServicios.Select("CTAR_Tipo = 'T'").Any())
                        {
                           foreach (DataRow dr in DTServicios.Select("CTAR_Tipo = 'T'"))
                           {
                              ItemPreDetDocsVta_Det_Operacion = new PreDetDocsVta_Det_Operacion();
                              ItemPreDetDocsVta_Det_Operacion.DOPE_Venta = dr["DOPE_Venta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_Venta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOPE_PrecioTotVta = dr["DOPE_PrecioTotVta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_PrecioTotVta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOPE_Item = dr["DOPE_Item"] != DBNull.Value ? Convert.ToInt32(dr["DOPE_Item"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.COPE_Codigo = dr["COPE_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["COPE_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.SERV_Codigo = dr["SERV_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["SERV_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.CTAR_Tipo = "T";
                              _Moneda = dr["Moneda"].ToString();
                              ItemPreDetDocsVta_Det_Operacion.Importe = Convert.ToDecimal(dr["Importe"].ToString());
                              ItemPreDetDocsVta_Det_Operacion.Agregar = false;
                              ItemsPreDetDocsVta_Det_Operacion.Add(ItemPreDetDocsVta_Det_Operacion);
                           }
                           var firstOrDefault = DTServicios.Select("CTAR_Tipo = 'T'").FirstOrDefault();
                           var servicioDesc = "";
                           Int32 servCodigo = 0;
                           if (firstOrDefault != null)
                           {
                              servicioDesc = firstOrDefault.ItemArray[1].ToString(); //Descripcion
                              servCodigo = Convert.ToInt32(firstOrDefault.ItemArray[2].ToString()); //Servicio
                           }
                           ItemPreDetDocsVta = new PreDetDocsVta
                           {
                              AUDI_UsrCrea = Session.UserName,
                              AUDI_FecCrea = Session.Fecha,
                              Instance = InstanceEntity.Added,
                              Agregar = false,
                              Servicio = servicioDesc,
                              DDOV_ValorVenta = DTServicios.Select("CTAR_Tipo = 'T'").Sum(e => (Decimal)e.ItemArray[3]), //DOPE_Venta
                              CTAR_Tipo = "T",
                              Moneda = _Moneda,
                              Importe = DTServicios.Select("CTAR_Tipo = 'T'").Sum(e => (Decimal)e.ItemArray[14]), //Importe,
                              SERV_Codigo = servCodigo,
                              DDOV_PrecioUnitario = DTServicios.Select("CTAR_Tipo = 'T'").Sum(e => (Decimal)e.ItemArray[8]), //Precio Unitario
                              DDOV_Cantidad = 1
                           };
                           GrillaItemsPreDetDocsVta.Add(ItemPreDetDocsVta);
                        }
                        break;
                     case 3: // Servicios Adicionales

                        if (DTServicios.Select("ISNULL(CTAR_Tipo, '') = ''").Any()) // devuelve si hay sin servicios adicionales
                        {
                           foreach (DataRow dr in DTServicios.Select("ISNULL(CTAR_Tipo, '') = ''"))
                           {
                              ItemPreDetDocsVta_Det_Operacion = new PreDetDocsVta_Det_Operacion();
                              ItemPreDetDocsVta_Det_Operacion.DOPE_Venta = dr["DOPE_Venta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_Venta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOPE_PrecioTotVta = dr["DOPE_PrecioTotVta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_PrecioTotVta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.SOPE_Item = dr["DOPE_Item"] != DBNull.Value ? Convert.ToInt32(dr["DOPE_Item"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.COPE_Codigo = dr["COPE_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["COPE_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.SERV_Codigo = dr["SERV_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["SERV_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.Importe = Convert.ToDecimal(dr["Importe"].ToString());
                              ItemPreDetDocsVta_Det_Operacion.CTAR_Tipo = "";

                              ItemPreDetDocsVta_Det_Operacion.Agregar = false;
                              ItemPreDetDocsVta = new PreDetDocsVta
                              {
                                 AUDI_UsrCrea = Session.UserName,
                                 AUDI_FecCrea = Session.Fecha,
                                 Instance = InstanceEntity.Added,
                                 Agregar = false,
                                 SOPE_Item = dr["DOPE_Item"] != DBNull.Value ? Convert.ToInt32(dr["DOPE_Item"]) : 0,
                                 Servicio = dr["Servicio"] != DBNull.Value ? dr["Servicio"].ToString() : null, //servicio
                                 DDOV_ValorVenta = dr["DOPE_Venta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_Venta"]) : 0, //DOPE_Venta
                                 Moneda = dr["Moneda"].ToString(),
                                 Importe = Convert.ToDecimal(dr["Importe"].ToString()),
                                 CTAR_Tipo = "",
                                 SERV_Codigo = ItemPreDetDocsVta_Det_Operacion.SERV_Codigo,
                                 DDOV_PrecioUnitario = dr["DOPE_PrecioTotVta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_PrecioTotVta"]) : 0, // DTServicios.Select("ISNULL(CTAR_Tipo, '') = ''").Sum(e => (Decimal)e.ItemArray[8]), //Precio Unitario
                                 DDOV_Cantidad = 1
                              };
                              GrillaItemsPreDetDocsVta.Add(ItemPreDetDocsVta);
                              ItemsPreDetDocsVta_Det_Operacion.Add(ItemPreDetDocsVta_Det_Operacion);
                           }
                        }
                        break;
                  }
               }
            }
         }
         catch (Exception) { }
      }
      private void EdicionServiciosOperacion()
      {
         try
         {
            DTServicios = new DataTable();
            DTServicios = Client.GetAllServiciosPorDOCV_CodigoPreFactura(ItemPreDocsVta.PDOC_Codigo);
            String _Moneda = "";
            if (DTServicios != null && DTServicios.Rows.Count > 0)
            {
               var first = DTServicios.Select("").FirstOrDefault();
               if (first != null)
               {
                  COPE_Codigo = Int32.Parse(first.ItemArray[7].ToString());  //COPE_Codigo
               }
               for (int i = 0; i < 4; i++)
               {
                  switch (i)
                  {
                     case 0: // Logistico 
                        if (DTServicios.Select("CTAR_Tipo = 'L'").Any())
                        {
                           foreach (var dr in DTServicios.Select("CTAR_Tipo = 'L'"))
                           {
                              ItemPreDetDocsVta_Det_Operacion = new PreDetDocsVta_Det_Operacion();
                              ItemPreDetDocsVta_Det_Operacion.DOPE_Venta = dr["DOPE_Venta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_Venta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOPE_PrecioTotVta = dr["DOPE_PrecioTotVta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_PrecioTotVta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOPE_Item = dr["DOPE_Item"] != DBNull.Value ? Convert.ToInt32(dr["DOPE_Item"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.COPE_Codigo = dr["COPE_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["COPE_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.SERV_Codigo = dr["SERV_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["SERV_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOCV_Codigo = dr["DOCV_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["DOCV_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.PDDO_Item = (short)(dr["PDDO_Item"] != DBNull.Value ? Convert.ToInt16(dr["PDDO_Item"]) : 0);
                              ItemPreDetDocsVta_Det_Operacion.CTAR_Tipo = "L";
                              _Moneda = dr["Moneda"].ToString();
                              ItemPreDetDocsVta_Det_Operacion.Importe = Convert.ToDecimal(dr["Importe"].ToString());
                              ItemPreDetDocsVta_Det_Operacion.Agregar = true;
                              ItemsPreDetDocsVta_Det_Operacion.Add(ItemPreDetDocsVta_Det_Operacion);
                           }
                           var firstOrDefault = DTServicios.Select("CTAR_Tipo = 'L'").FirstOrDefault();
                           var servicioDesc = "";
                           Int32 servCodigo = 0;
                           if (firstOrDefault != null)
                           {
                              servicioDesc = firstOrDefault.ItemArray[1].ToString(); //Descripcion
                              servCodigo = Convert.ToInt32(firstOrDefault.ItemArray[2].ToString()); //Servicio
                           }
                           var orDefault = DTServicios.Select("CTAR_Tipo = 'L'").FirstOrDefault();
                           if (orDefault != null)
                              ItemPreDetDocsVta = new PreDetDocsVta
                              {
                                 AUDI_UsrMod = Session.UserName,
                                 AUDI_FecMod = Session.Fecha,
                                 Instance = InstanceEntity.Modified,
                                 Agregar = true,
                                 Servicio = servicioDesc,
                                 DDOV_ValorVenta = DTServicios.Select("CTAR_Tipo = 'L'").Sum(e => (Decimal)e.ItemArray[3]), //DOPE_Venta
                                 CTAR_Tipo = "L",
                                 Moneda = _Moneda,
                                 SERV_Codigo = servCodigo,
                                 DDOV_PrecioUnitario = DTServicios.Select("CTAR_Tipo = 'L'").Sum(e => (Decimal)e.ItemArray[8]), //Precio Unitario
                                 Importe = DTServicios.Select("CTAR_Tipo = 'L'").Sum(e => (Decimal)e.ItemArray[11]),
                                 DDOV_Cantidad = 1,
                                 DOCV_Codigo = Int32.Parse(orDefault.ItemArray[9].ToString()),
                                 PDDO_Item = Int16.Parse(orDefault.ItemArray[10].ToString())
                              };
                           GrillaItemsPreDetDocsVta.Add(ItemPreDetDocsVta);
                        }
                        break;
                     case 1: // Aduana 
                        if (DTServicios.Select("CTAR_Tipo = 'A'").Any())
                        {
                           foreach (DataRow dr in DTServicios.Select("CTAR_Tipo = 'A'"))
                           {
                              ItemPreDetDocsVta_Det_Operacion = new PreDetDocsVta_Det_Operacion();
                              ItemPreDetDocsVta_Det_Operacion.DOPE_Venta = dr["DOPE_Venta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_Venta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOPE_PrecioTotVta = dr["DOPE_PrecioTotVta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_PrecioTotVta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOPE_Item = dr["DOPE_Item"] != DBNull.Value ? Convert.ToInt32(dr["DOPE_Item"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.COPE_Codigo = dr["COPE_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["COPE_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.SERV_Codigo = dr["SERV_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["SERV_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOCV_Codigo = dr["DOCV_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["DOCV_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.PDDO_Item = (short)(dr["PDDO_Item"] != DBNull.Value ? Convert.ToInt16(dr["PDDO_Item"]) : 0);
                              ItemPreDetDocsVta_Det_Operacion.CTAR_Tipo = "A";
                              ItemPreDetDocsVta_Det_Operacion.Importe = Convert.ToDecimal(dr["Importe"].ToString());
                              _Moneda = dr["Moneda"].ToString();
                              ItemPreDetDocsVta_Det_Operacion.Agregar = true;
                              ItemsPreDetDocsVta_Det_Operacion.Add(ItemPreDetDocsVta_Det_Operacion);
                           }
                           var firstOrDefault = DTServicios.Select("CTAR_Tipo = 'A'").FirstOrDefault();
                           var servicioDesc = "";
                           Int32 servCodigo = 0;
                           if (firstOrDefault != null)
                           {
                              servicioDesc = firstOrDefault.ItemArray[1].ToString(); //Descripcion
                              servCodigo = Convert.ToInt32(firstOrDefault.ItemArray[2].ToString()); //Servicio
                           }
                           var orDefault = DTServicios.Select("CTAR_Tipo = 'A'").FirstOrDefault();
                           if (orDefault != null)
                              ItemPreDetDocsVta = new PreDetDocsVta
                              {
                                 AUDI_UsrMod = Session.UserName,
                                 AUDI_FecMod = Session.Fecha,
                                 Instance = InstanceEntity.Modified,
                                 Agregar = true,
                                 Servicio = servicioDesc,
                                 DDOV_ValorVenta = DTServicios.Select("CTAR_Tipo = 'A'").Sum(e => (Decimal)e.ItemArray[3]), //DOPE_Venta
                                 CTAR_Tipo = "A",
                                 Moneda = _Moneda,
                                 Importe = DTServicios.Select("CTAR_Tipo = 'A'").Sum(e => (Decimal)e.ItemArray[11]), //DOPE_Venta
                                 SERV_Codigo = servCodigo,
                                 DDOV_PrecioUnitario = DTServicios.Select("CTAR_Tipo = 'A'").Sum(e => (Decimal)e.ItemArray[8]), //Precio Unitario
                                 DDOV_Cantidad = 1,
                                 DOCV_Codigo = Int32.Parse(orDefault.ItemArray[9].ToString()),
                                 PDDO_Item = Int16.Parse(orDefault.ItemArray[10].ToString())
                              };
                           GrillaItemsPreDetDocsVta.Add(ItemPreDetDocsVta);
                        }
                        break;
                     case 2: // Transporte 
                        if (DTServicios.Select("CTAR_Tipo = 'T'").Any())
                        {
                           foreach (DataRow dr in DTServicios.Select("CTAR_Tipo = 'T'"))
                           {
                              ItemPreDetDocsVta_Det_Operacion = new PreDetDocsVta_Det_Operacion();
                              ItemPreDetDocsVta_Det_Operacion.DOPE_Venta = dr["DOPE_Venta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_Venta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOPE_PrecioTotVta = dr["DOPE_PrecioTotVta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_PrecioTotVta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOPE_Item = dr["DOPE_Item"] != DBNull.Value ? Convert.ToInt32(dr["DOPE_Item"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.COPE_Codigo = dr["COPE_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["COPE_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.SERV_Codigo = dr["SERV_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["SERV_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOCV_Codigo = dr["DOCV_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["DOCV_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.PDDO_Item = (short)(dr["PDDO_Item"] != DBNull.Value ? Convert.ToInt16(dr["PDDO_Item"]) : 0);
                              ItemPreDetDocsVta_Det_Operacion.CTAR_Tipo = "T";
                              _Moneda = dr["Moneda"].ToString();
                              ItemPreDetDocsVta_Det_Operacion.Importe = Convert.ToDecimal(dr["Importe"].ToString());
                              ItemPreDetDocsVta_Det_Operacion.Agregar = true;
                              ItemsPreDetDocsVta_Det_Operacion.Add(ItemPreDetDocsVta_Det_Operacion);
                           }
                           var firstOrDefault = DTServicios.Select("CTAR_Tipo = 'T'").FirstOrDefault();
                           var servicioDesc = "";
                           Int32 servCodigo = 0;
                           if (firstOrDefault != null)
                           {
                              servicioDesc = firstOrDefault.ItemArray[1].ToString(); //Descripcion
                              servCodigo = Convert.ToInt32(firstOrDefault.ItemArray[2].ToString()); //Servicio
                           }
                           var orDefault = DTServicios.Select("CTAR_Tipo = 'T'").FirstOrDefault();
                           if (orDefault != null)
                              ItemPreDetDocsVta = new PreDetDocsVta
                              {
                                 AUDI_UsrMod = Session.UserName,
                                 AUDI_FecMod = Session.Fecha,
                                 Instance = InstanceEntity.Modified,
                                 Agregar = true,
                                 Servicio = servicioDesc,
                                 DDOV_ValorVenta = DTServicios.Select("CTAR_Tipo = 'T'").Sum(e => (Decimal)e.ItemArray[3]), //DOPE_Venta
                                 CTAR_Tipo = "T",
                                 Moneda = _Moneda,
                                 SERV_Codigo = servCodigo,
                                 Importe = DTServicios.Select("CTAR_Tipo = 'T'").Sum(e => (Decimal)e.ItemArray[11]), //Importe
                                 DDOV_PrecioUnitario = DTServicios.Select("CTAR_Tipo = 'T'").Sum(e => (Decimal)e.ItemArray[8]), //Precio Unitario
                                 DDOV_Cantidad = 1,
                                 DOCV_Codigo = Int32.Parse(orDefault.ItemArray[9].ToString()),
                                 PDDO_Item = Int16.Parse(orDefault.ItemArray[10].ToString())
                              };
                           GrillaItemsPreDetDocsVta.Add(ItemPreDetDocsVta);
                        }
                        break;
                     case 3: // Servicios Adicionales

                        if (DTServicios.Select("ISNULL(CTAR_Tipo, '') = ''").Any()) // devuelve si hay sin servicios adicionales
                        {
                           foreach (DataRow dr in DTServicios.Select("ISNULL(CTAR_Tipo, '') = ''"))
                           {
                              ItemPreDetDocsVta_Det_Operacion = new PreDetDocsVta_Det_Operacion();
                              ItemPreDetDocsVta_Det_Operacion.DOPE_Venta = dr["DOPE_Venta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_Venta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOPE_PrecioTotVta = dr["DOPE_PrecioTotVta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_PrecioTotVta"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.SOPE_Item = dr["DOPE_Item"] != DBNull.Value ? Convert.ToInt32(dr["DOPE_Item"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.COPE_Codigo = dr["COPE_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["COPE_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.SERV_Codigo = dr["SERV_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["SERV_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.DOCV_Codigo = dr["DOCV_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["DOCV_Codigo"]) : 0;
                              ItemPreDetDocsVta_Det_Operacion.PDDO_Item = (short)(dr["PDDO_Item"] != DBNull.Value ? Convert.ToInt16(dr["PDDO_Item"]) : 0);
                              ItemPreDetDocsVta_Det_Operacion.CTAR_Tipo = "";
                              _Moneda = dr["Moneda"].ToString();
                              ItemPreDetDocsVta_Det_Operacion.Importe = Convert.ToDecimal(dr["Importe"].ToString());
                              ItemPreDetDocsVta_Det_Operacion.Agregar = true;
                              var orDefault = DTServicios.Select("ISNULL(CTAR_Tipo, '') = ''").FirstOrDefault();
                              if (orDefault != null)
                                 ItemPreDetDocsVta = new PreDetDocsVta
                                 {
                                    AUDI_UsrMod = Session.UserName,
                                    AUDI_FecMod = Session.Fecha,
                                    Instance = InstanceEntity.Modified,
                                    Agregar = true,
                                    SOPE_Item = dr["DOPE_Item"] != DBNull.Value ? Convert.ToInt32(dr["DOPE_Item"]) : 0,
                                    Servicio = dr["Servicio"] != DBNull.Value ? dr["Servicio"].ToString() : null, //servicio
                                    DDOV_ValorVenta = dr["DOPE_Venta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_Venta"]) : 0, //DOPE_Venta
                                    CTAR_Tipo = "",
                                    Moneda = dr["Moneda"].ToString(),
                                    Importe = Convert.ToDecimal(dr["Importe"].ToString()),
                                    SERV_Codigo = ItemPreDetDocsVta_Det_Operacion.SERV_Codigo,
                                    DDOV_PrecioUnitario = dr["DOPE_PrecioTotVta"] != DBNull.Value ? Convert.ToDecimal(dr["DOPE_PrecioTotVta"]) : 0,//DTServicios.Select("ISNULL(CTAR_Tipo, '') = ''").Sum(e => (Decimal)e.ItemArray[8]), //Precio Unitario
                                    DDOV_Cantidad = 1,

                                    DOCV_Codigo = Int32.Parse(orDefault.ItemArray[9].ToString()),
                                    PDDO_Item = Int16.Parse(orDefault.ItemArray[10].ToString())
                                 };
                              GrillaItemsPreDetDocsVta.Add(ItemPreDetDocsVta);
                              ItemsPreDetDocsVta_Det_Operacion.Add(ItemPreDetDocsVta_Det_Operacion);
                           }
                        }
                        break;
                  }
               }
            }
         }
         catch (Exception) { }
      }
      private void ServiciosDetDocsVta()
      {
         try
         {
            DTServicios = new DataTable();
            DTServicios = Client.GetAllServiciosDetDocsVtaPorDOCV_CodigoFactura(ItemDocsVta.DOCV_Codigo);
         }
         catch (Exception) { }
      }
      #endregion

      #region [ Tarjas ]

      public Boolean ValidarTipoCambio(String _Fecha)
      {
         String fecha = String.Empty;
         //fecha = Session.Fecha.Year.ToString() + Session.Fecha.Month.ToString().PadLeft(2, '0').Trim() + Session.Fecha.Day.ToString().PadLeft(2, '0').Trim();
         var First = Client.GetOneTiposCambio(_Fecha);
         TipoCambio = 0;
         TipoCambio = First != null ? First.TIPC_Compra : 0;
         if (TipoCambio > 0)
         {
            return true;
         }
         Dialogos.MostrarMensajeInformacion(Title, "No se encontro el tipo de cambio de hoy verifique con el administrador de sistemas");
         return false;
      }
      public void ServiciosTarjas(Boolean x_Busqueda)
      {
         try
         {
            if (DTServicios != null && DTServicios.Rows.Count > 0)
            {
               String filtro = String.Empty;
               String _Moneda = "";
               ItemsPreDetDocsVta_Det_Operacion = new ObservableCollection<PreDetDocsVta_Det_Operacion>();
               filtro = !x_Busqueda ? "Agregar = True" : "";
               var first = DTServicios.Select(filtro).FirstOrDefault();
               if (first != null)
               {
                  Entc_CodigoCliente = Int32.Parse(first.ItemArray[17].ToString());  //cliente
                  TipoMoneda = first.ItemArray[13].ToString();  // Tipo Moneda
                  TipoDoc = "001"; // Por defecto Factura
                  TipoFPago = Int32.Parse(first.ItemArray[16].ToString()) > 0 ? "002" : "001";// contado y credito
                  DiasCredito = Double.Parse(first.ItemArray[16].ToString());  // Dias Credito
                  //TipoCambio = Decimal.Parse(first.ItemArray[17].ToString());  // Tipo Cambio
                  decimal tot = 0;
                  decimal valor = 0;
                  if (Convert.ToDecimal(first.ItemArray[6].ToString()) > 0 && Convert.ToDecimal(first.ItemArray[7].ToString()) > 0)
                  {
                     tot = Convert.ToDecimal(first.ItemArray[6].ToString()) + Convert.ToDecimal(first.ItemArray[7].ToString());  // ENTC_ValTarja + ENTC_ValRebate
                  }
                  else
                  {
                     valor = Convert.ToDecimal(first.ItemArray[6].ToString()) > 0 ? Convert.ToDecimal(first.ItemArray[6].ToString()) : Convert.ToDecimal(first.ItemArray[7].ToString());
                  }
                  ItemPreDetDocsVta = new PreDetDocsVta();

                  ItemPreDetDocsVta.AUDI_UsrCrea = Session.UserName;
                  ItemPreDetDocsVta.AUDI_FecCrea = Session.Fecha;
                  ItemPreDetDocsVta.Instance = InstanceEntity.Added;
                  ItemPreDetDocsVta.Agregar = Convert.ToBoolean(first.ItemArray[0].ToString());//agregar
                  ItemPreDetDocsVta.Servicio = first.ItemArray[2].ToString(); //servicio
                  ItemPreDetDocsVta.DDOV_ValorVenta = tot > 0 ? (DTServicios.Select("Agregar=True").Count() * tot) : (DTServicios.Select("Agregar=True").Count() * valor); //ENTC_ValTarja
                  ItemPreDetDocsVta.DDOV_Cantidad = 1;
                  ItemPreDetDocsVta.Importe = tot > 0 ? (DTServicios.Select("Agregar=True").Count() * tot) : (DTServicios.Select("Agregar=True").Count() * valor); //ENTC_ValTarja;
                  ItemPreDetDocsVta.Moneda = first.ItemArray[12].ToString();
                  ItemPreDetDocsVta.DOCV_Codigo = first.ItemArray[9] != DBNull.Value ? Convert.ToInt32(first.ItemArray[9]) : 0; //  DOCV_Codigo
                  ItemPreDetDocsVta.Tarjas = true;
                  GrillaItemsPreDetDocsVta.Add(ItemPreDetDocsVta);
               }
               foreach (DataRow dr in DTServicios.Select(""))
               {
                  ItemPreDetDocsVta_Det_Operacion = new PreDetDocsVta_Det_Operacion();
                  ItemPreDetDocsVta_Det_Operacion.ENTC_ValTarja = dr["ENTC_ValTarja"] != DBNull.Value ? Convert.ToDecimal(dr["ENTC_ValTarja"]) : 0;
                  ItemPreDetDocsVta_Det_Operacion.ENTC_ValRebate = dr["ENTC_ValRebate"] != DBNull.Value ? Convert.ToDecimal(dr["ENTC_ValRebate"]) : 0;
                  ItemPreDetDocsVta_Det_Operacion.TARJ_Codigo = dr["TARJ_Codigo"] != DBNull.Value ? Convert.ToInt32(dr["TARJ_Codigo"]) : 0;
                  ItemPreDetDocsVta_Det_Operacion.DTAJ_Item = dr["DTAJ_Item"] != DBNull.Value ? Convert.ToInt32(dr["DTAJ_Item"]) : 0;
                  ItemPreDetDocsVta_Det_Operacion.Agregar = dr["Agregar"] != DBNull.Value && Convert.ToBoolean(dr["Agregar"]);
                  ItemPreDetDocsVta_Det_Operacion.Tarjas = true;
                  ItemsPreDetDocsVta_Det_Operacion.Add(ItemPreDetDocsVta_Det_Operacion);
               }
            }
         }
         catch (Exception) { }
      }
      #endregion
      #endregion

      #region [ Detalle Facturacion ]
      public void MarcarServicios()
      {
         try
         {
            if (!String.IsNullOrEmpty(TipoDocumentoVenta))
            {
               switch (TipoDocumentoVenta)
               {
                  case "PreFactura":
                     if (ItemsPreDetDocsVta_Det_Operacion.Any(data => data.CTAR_Tipo == ItemPreDetDocsVta.CTAR_Tipo && ItemPreDetDocsVta.Agregar))
                     {
                        if (!String.IsNullOrEmpty(ItemPreDetDocsVta.CTAR_Tipo)) // Logistico, aduanero y transporte
                        {
                           foreach (var item in ItemsPreDetDocsVta_Det_Operacion.Where(data => data.CTAR_Tipo == ItemPreDetDocsVta.CTAR_Tipo))
                           {
                              item.Agregar = true;
                           }
                        }
                        else  // servicio adicional
                        {
                           var preDetDocsVtaDetOperacion = ItemsPreDetDocsVta_Det_Operacion.FirstOrDefault(data => data.SOPE_Item == ItemPreDetDocsVta.SOPE_Item);
                           if (preDetDocsVtaDetOperacion != null)
                              preDetDocsVtaDetOperacion.Agregar = true;
                        }
                     }
                     else
                     {
                        if (!String.IsNullOrEmpty(ItemPreDetDocsVta.CTAR_Tipo)) // Logistico, aduanero y transporte
                        {
                           foreach (var item in ItemsPreDetDocsVta_Det_Operacion.Where(data => data.CTAR_Tipo == ItemPreDetDocsVta.CTAR_Tipo))
                           {
                              item.Agregar = false;
                           }
                        }
                        else  // servicio adicional
                        {
                           var preDetDocsVtaDetOperacion = ItemsPreDetDocsVta_Det_Operacion.FirstOrDefault(data => data.SOPE_Item == ItemPreDetDocsVta.SOPE_Item);
                           if (preDetDocsVtaDetOperacion != null)
                              preDetDocsVtaDetOperacion.Agregar = false;
                        }
                     }
                     break;
                  case "Factura":

                     break;
               }
            }

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al marcar los servicios", ex); }
      }
      #endregion

      #region [ Facturación Libre ]

      private Boolean ValidarFL(ref String x_msg)
      {
         try
         {
            Boolean Is_Correct = true;
            if (!ItemDocsVtaFL.ValidarFL())
            {
               Is_Correct = false;
               x_msg += String.Format("- El documento tiene los siguientes errores: {1}.{0}", Environment.NewLine, ItemDocsVtaFL.MensajeError);
            }
            if (ItemDocsVtaFL.ItemsDetDocsVta != null && ItemDocsVtaFL.ItemsDetDocsVta.Count > 0)
            {
               foreach (Entities.DetDocsVta iDetDocVta in ItemDocsVtaFL.ItemsDetDocsVta)
               {
                  if (!iDetDocVta.Validar())
                  {
                     x_msg += String.Format("- El item [{1}] tiene los siguientes errores: {2}.{0}", Environment.NewLine, iDetDocVta.DDOV_Item, iDetDocVta.MensajeError);
                     Is_Correct = false;
                  }
               }
            }
            else { x_msg += String.Format("- Debe ingresar al menos un elemento en el detalle del documento{0}", Environment.NewLine); Is_Correct = false; }

            return Is_Correct;
         }
         catch (Exception)
         { throw; }
      }

      public Boolean GuardarFL()
      {
         try
         {
            MViewFL.GetItem();
            String x_msg = "";
            if (ValidarFL(ref x_msg))
            {
               Entities.DocsVta _item = ItemDocsVtaFL;
               if (Client.SaveDocsVta(ref _item, DocsVta.TInterfazDocsVta.FacturacionLibre))
               {
                  return true;
               }
            }
            else
            {
               MViewFL.ShowValidation(x_msg);
               return false;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      public void NuevoFL()
      {
         try
         {
            if (!isMViewShowFL)
            {
               MViewFL = new PRO007MViewFactLibre();
               MViewFL.Presenter = this;
               MViewFL.LoadView();
            }

            this.ItemDocsVtaFL = new DocsVta();
            this.ItemDocsVtaFL.ItemsDetDocsVta = new ObservableCollection<DetDocsVta>();
            this.ItemDocsVtaFL.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            this.ItemDocsVtaFL.AUDI_UsrCrea = Session.UserName;
            this.ItemDocsVtaFL.AUDI_FecCrea = Session.Fecha;
            this.ItemDocsVtaFL.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            MViewFL.Nuevo();
            MViewFL.SetItem();

            isMViewShowFL = true;

            if (LView != null) { ((PRO007MViewFactLibre)MViewFL).Icon = Icon.FromHandle(((Bitmap)LView.IconView).GetHicon()); }
            ((PRO007MViewFactLibre)MViewFL).StartPosition = FormStartPosition.CenterScreen;
            ((PRO007MViewFactLibre)MViewFL).ShowDialog();
            ((PRO007MViewFactLibre)MViewFL).BringToFront();
         }
         catch (Exception)
         { throw; }
      }

      public void EditarFL()
      { }

      public void AnularFL()
      { }

      public Int32? F_SERV_Codigo { get; set; }


      public void LoadServicios(String TIPO_TabMND, String TIPO_CodMND)
      {
         try
         {
            if (!String.IsNullOrEmpty(TIPO_TabMND) && !String.IsNullOrEmpty(TIPO_TabMND))
            {
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintSERV_Codigo", FilterValue = F_SERV_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_TabMND", FilterValue = TIPO_TabMND, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodMND", FilterValue = TIPO_CodMND, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               ListServicio = Client.GetAllServiciosFilter("COM_SERVSS_TodosPorMoneda", _listFilters);

            }
            else
            { ListServicio = new ObservableCollection<Servicio>(); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando los servicios.", ex); }
      }


      #endregion

      #endregion

      #region [ Eventos ]
      public void CloseView()
      {
         if (isMViewShowFL)
         { ((PRO007MViewFactLibre)MViewFL).Close(); }
      }
      public void IsClosedMViewFL()
      { isMViewShowFL = false; }

      public void CloseViewFL()
      {
         if (isMViewShowFL)
         { ((PRO007MView)MView).Close(); }
      }
      public void IsClosedMView()
      { isMViewShow = false; }
      #endregion

   }
}
