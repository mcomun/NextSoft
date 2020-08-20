using System;
using System.Data;
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
using System.Collections.Generic;

namespace Delfin.Principal
{
   public class PRO022Presenter
   {
      #region [ Variables ]
      public String Title = "Notas de Credito";
      public String CUS = "PRO022";
      Boolean isMViewShow = false;

      public enum TipoInicio
      {
         Normal = 0, EditarFacturacion = 1
      }
      #endregion

      #region [ Constructor ]
      public PRO022Presenter(IUnityContainer x_container, IPRO022LView x_lview, TipoInicio x_opcion = TipoInicio.Normal)
      {
         try
         {
            ContainerService = x_container;
            Session = ContainerService.Resolve<ISessionService>();
            TInicio = x_opcion;
            LView = x_lview;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.ConstructorPresenter, ex); }
      }

      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<Delfin.ServiceContracts.IDelfinServices>();

            /* Cargar la series de notas de credito */
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_TabTDO", FilterValue = "TDO", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodTDO", FilterValue = "007", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

            ListSeries = Client.GetAllSeriesFilter("VEN_SERISS_Todos", _listFilters);
            Fecha = Client.GetFecha();
            ListSeries.Insert(0, new Series() { SERI_Serie = "< Sel. Nro de Serie >", SERI_Desc = null });

            var item = Client.GetOneParametrosByClave("IGV");
            decimal igv;
            if (item != null && decimal.TryParse(item.PARA_Valor, out igv)) { IGV = igv; }

            switch (TInicio)
            {
               case TipoInicio.Normal:
                  LView.LoadView();
                  break;
               case TipoInicio.EditarFacturacion:

                  Editar(ItemDocsVta.DOCV_Codigo);
                  break;
               default:
                  break;
            }

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.LoadPresenter, ex); }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public Delfin.ServiceContracts.IDelfinServices Client { get; set; }
      public IPRO022LView LView { get; set; }
      public IPRO022MView MView { get; set; }
      public IPRO022RView RMView { get; set; }

      //#########
      public Entities.Entidad ClienteSelected { get; set; }
      public DocsVta ItemDocsVta { get; set; }
      public int ItemNotaCreditoSelectedID { get; set; }
      public DocsVta ItemNotaCredito { get; set; }
      public ObservableCollection<DocsVta> ItemsNotaCredito { get; set; }
      public DataSet ItemsNotaCreditoDS { get; set; }

      //#########
      public Decimal IGV { get; set; }
      //#########
      public String F_NroNotaCreditoFiltro { get; set; }
      public String F_NroFacturaFiltro { get; set; }
      public DateTime? F_FecEmisionIniFiltro { get; set; }
      public DateTime? F_FecEmisionFinFiltro { get; set; }
      public int? F_Entc_CodigoFiltro { get; set; }
      public String F_DOCV_Serie { get; set; }
      //#########
      public DataSet DSReporte { get; set; }
      public ReportDataSource RepDataSourceCabecera { get; set; }
      public ReportDataSource RepDataSourceDetalle { get; set; }
      public String ReportPath { get; set; }
      public ReportParameter[] Parameters { get; set; }
      //#########
      public ObservableCollection<Series> ListSeries { get; set; }
      public DateTime Fecha { get; set; }

      public TipoInicio TInicio { get; set; }
      #endregion

      #region [ Metodos ]

      public void Nuevo()
      {
         try
         {
            if (!isMViewShow)
            {
               MView = new PRO022MView();
               MView.Presenter = this;
               MView.LoadView();
            }
            //MView.ClearItem();
            ItemNotaCredito = new DocsVta
            {
               AUDI_UsrCrea = Session.UserName,
               AUDI_FecCrea = Session.Fecha,
               Instance = InstanceEntity.Added,
               TIPO_TabFPG = "FPG",
               TIPO_TabTDO = "TDO",
               TIPO_TabMND = "MND",
               ItemCtaCte = new CtaCte(),
               ItemDetCtaCte = new DetCtaCte(),
               ItemDetCtaCteFactura = new DetCtaCte(),
               EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo,
               DOCV_Serie = String.IsNullOrEmpty(F_DOCV_Serie) ? null : F_DOCV_Serie
            };
            ItemNotaCredito.ItemDetCtaCte.EMPR_Codigo = ItemNotaCredito.EMPR_Codigo;
            ItemNotaCredito.ItemDetCtaCteFactura.EMPR_Codigo = ItemNotaCredito.EMPR_Codigo;
            ItemNotaCredito.ItemCtaCte.EMPR_Codigo = ItemNotaCredito.EMPR_Codigo;

            MView.SetItem();
            MView.SetInstance(InstanceView.New);
            isMViewShow = true;
            ((PRO022MView)MView).Show();
            ((PRO022MView)MView).BringToFront();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }

      public void Editar(int DOCV_Codigo)
      {
         try
         {
            if (!isMViewShow)
            {
               MView = new PRO022MView();
               MView.Presenter = this;
               MView.LoadView();
            }
            if (DOCV_Codigo != 0)
            {
               MView.ClearItem();

               ItemNotaCredito = Client.GetOneDocsVta(Controls.Entorno.ItemEmpresa.EMPR_Codigo, DOCV_Codigo);
               ItemNotaCredito.Instance = InstanceEntity.Modified;

               ItemNotaCredito.AUDI_UsrMod = Session.UserName;
               ItemNotaCredito.AUDI_FecMod = Session.Fecha;

               MView.SetItem();
               MView.SetInstance(InstanceView.Edit);
               switch (TInicio)
               {
                  case TipoInicio.Normal:
                     isMViewShow = true;
                     ((PRO022MView)MView).Show();
                     ((PRO022MView)MView).BringToFront();
                     break;
                  case TipoInicio.EditarFacturacion:
                     if (ItemNotaCredito.ItemDetCtaCteFactura == null)
                     {
                        ItemNotaCredito.ItemDetCtaCteFactura = new DetCtaCte();
                        ItemNotaCredito.ItemDetCtaCteFactura.Instance = InstanceEntity.Added;
                        ItemNotaCredito.ItemDetCtaCteFactura.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                     }
                     ((PRO022MView)MView).ShowDialog();
                     //Actualizar();
                     break;
                  default:
                     break;
               }
            }
            else
            { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
      }

      public void Imprimir(int DOCV_Codigo)
      {
         try
         {

            if (DOCV_Codigo != 0)
            {
               ItemNotaCredito = Client.GetOneDocsVta(DOCV_Codigo);
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
               DSReporte = Client.GetDSDocsVta("VEN_DDOVSS_TodosImpresionByDOCV_Codigo", _listFilters);   //Client.GetAllDocsVtaImpresionFactura(ItemDocsVta.DOCV_Codigo);
               //DSReporte = Client.GetAllDocsVtaImpresionFactura(ItemNotaCredito.DOCV_Codigo);
               //DSReportePadre = Client.GetAllDocsVtaImpresionFactura(ItemNotaCredito.DOCV_Codigo);

               if (DSReporte != null)
               {
                  if (DSReporte.Tables.Count < 3)
                  { Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias."); return; }

                  string nro = DSReporte.Tables[0].Rows[0]["DOCV_Numero"].ToString();

                  ItemNotaCredito.Instance = InstanceEntity.Modified;
                  ItemNotaCredito.DOCV_Numero = nro;
                  ItemNotaCredito.AUDI_UsrMod = Session.UserName;
                  ItemNotaCredito.AUDI_FecMod = Session.Fecha;
                  ItemNotaCredito.DOCV_Estado = "I";
                  DocsVta ItemNC = ItemNotaCredito;

                  if (Client.SaveDocsVta(ref ItemNC))
                  {
                     ItemNotaCredito = ItemNC;
                     Actualizar();
                  }

                  ReportPath = Application.StartupPath + @"\Reportes\RptFactNC.rdlc";

                  Decimal igvCalc = ((IGV / 100) * Decimal.Parse(DSReporte.Tables[0].Rows[0]["DOCV_ValorTotal"].ToString()));

                  DataColumn _dc = DSReporte.Tables[0].Columns.Add("Usuario", typeof(String));
                  DSReporte.Tables[0].Rows[0]["Usuario"] = Session.UserName + "/" + DSReporte.Tables[0].Rows[0]["DOCV_Serie"] + "-" + DSReporte.Tables[0].Rows[0]["DOCV_NUmero"];
                  RepDataSourceCabecera = new ReportDataSource("DsEncabezado", DSReporte.Tables[0]);
                  RepDataSourceDetalle = new ReportDataSource("DsDetalle", DSReporte.Tables[2]);
                  Parameters = new ReportParameter[3];
                  _letras = Utilitarios.NumeroALetras(DSReporte.Tables[0].Rows[0]["DOCV_ValorVtaTotal"].ToString(), DSReporte.Tables[0].Rows[0]["TIPO_Desc1"].ToString());
                  Parameters[0] = new ReportParameter("Letras", _letras);

                  Parameters[1] = new ReportParameter("IGV", ((IGV / 100) * Decimal.Parse(DSReporte.Tables[0].Rows[0]["DOCV_ValorTotal"].ToString())).ToString());

                  string referenciaPrev = DSReporte.Tables[2].Rows[0]["Referencia"].ToString();
                  string referencia = "Referencia de la Factura: " + referenciaPrev;
                  Parameters[2] = new ReportParameter("Referencia", referencia);
                  RMView = new PRO022RView();
                  RMView.Presenter = this;
                  RMView.ShowReporte();
                  ((PRO022RView)RMView).ShowDialog();
               }
            }
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Title, Mensajes.SavePresenter, ex);
         }
      }

      public void Anular(int DOCV_Codigo)
      {
         try
         {
            if (DOCV_Codigo != 0)
            {
               ItemNotaCredito = Client.GetOneDocsVta(DOCV_Codigo);
               if (ItemNotaCredito == null)
               {
                  Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al Anular la Nota de Credito.");
                  return;
               }

               if (String.Equals(ItemNotaCredito.DOCV_Estado, "I"))
               {
                  Dialogos.MostrarMensajeSatisfactorio(Title, "No se puede Anular una Nota de Credito que ya fue Impresa.");
                  return;
               }

               DialogResult result;
               Boolean x_Eliminar = false;
               if (String.IsNullOrEmpty(ItemNotaCredito.DOCV_Numero))
               { result = Dialogos.MostrarMensajePregunta(Title, "¿ Desea eliminar la Nota de Credito?", Dialogos.LabelBoton.Si_No); x_Eliminar = true; }
               else { result = Dialogos.MostrarMensajePregunta(Title, "¿ Desea anular la Nota de Credito?", Dialogos.LabelBoton.Si_No); x_Eliminar = false; }


               if (result == DialogResult.Yes)
               {

                  ItemNotaCredito.Instance = InstanceEntity.Modified;
                  ItemNotaCredito.AUDI_UsrMod = Session.UserName;
                  ItemNotaCredito.AUDI_FecMod = Session.Fecha;

                  ItemNotaCredito.DOCV_Estado = "A";
                  DocsVta ItemNC = ItemNotaCredito;
                  if (Client.SaveDocsVta(ref ItemNC, DocsVta.TInterfazDocsVta.AnularNotaCredito))
                  {
                     Dialogos.MostrarMensajeSatisfactorio(Title, "La Nota de Credito ha sido Anulada");
                     ItemNotaCredito = ItemNC;
                     Actualizar();
                     return;
                  }
                  else
                  {
                     Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al Anular la Nota de Credito.");
                  }
               }
            }
            else
            { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
      }

      public void Actualizar()
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchDOCV_Numero", FilterValue = F_NroNotaCreditoFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchDOCV_NumeroPadre", FilterValue = F_NroFacturaFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_TabTDO", FilterValue = "TDO", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodTDO", FilterValue = "007", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = F_Entc_CodigoFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmDOCV_FechaEmisionIni", FilterValue = F_FecEmisionIniFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmDOCV_FechaEmisionFin", FilterValue = F_FecEmisionFinFiltro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchDOCV_Serie", FilterValue = F_DOCV_Serie, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 10 });

            ItemsNotaCreditoDS = Client.GetDSDocsVta("VEN_DOCV_ByFilters", _listFilters);

            LView.FiltrosLView();
            LView.ShowItems();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      public bool Guardar()
      {
         try
         {
            if (ItemNotaCredito != null)
            {
               if (TInicio == TipoInicio.Normal)
               { MView.GetItem(); }
               else { MView.GetItemReferencia(); }

               if (preValidacion())
               {
                  if (ItemNotaCredito.Validar())
                  {
                     DocsVta ItemNC = ItemNotaCredito;
                     if (Client.SaveDocsVta(ref ItemNC, DocsVta.TInterfazDocsVta.NotaCredito))
                     {
                        Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                        ItemNotaCredito = ItemNC;
                        if (TInicio == TipoInicio.Normal) { Actualizar(); }
                        return true;
                     }
                     Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                     return false;
                  }
                  MView.ShowValidation();
                  return false;
               }
            }
            return false;
         }

         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Title, Mensajes.SavePresenter, ex);
            return false;
         }
      }

      public decimal CalcularMontoPagado(string tipoCodTDO, int id)
      {
         decimal sum = 0;
         List<object> filters = new List<object>();
         filters.Add(id);
         filters.Add(tipoCodTDO);
         //DataSet DS = Client.GetDS("VEN_SUM_DocvByPadre", filters);
         DataSet DS = Client.GetDS("VEN_GetPagosDocvByPadre", filters);
         if (DS != null && DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
         {
            string TIPO_CodMND = ItemDocsVta.TIPO_CodMND;

            foreach (DataRow Row in DS.Tables[0].Rows)
            {
               string RowTipoMND = Row["TIPO_CodMND"].ToString();

               if (string.Equals(TIPO_CodMND, RowTipoMND))
               {
                  decimal valor = decimal.Parse(Row["DOCV_ValorTotal"].ToString());
                  sum = sum + valor;
               }
               else
               {
                  decimal valorEx = decimal.Parse(Row["DOCV_ValorTotal"].ToString());
                  decimal tipoCambio = decimal.Parse(Row["DOCV_TipoCambio"].ToString());
                  decimal valor = valorEx * tipoCambio;
                  sum = sum + valor;
               }
            }

         }

         return sum;
      }

      private bool preValidacion()
      {
         bool isValid = true;

         if (ClienteSelected == null)
         {
            Dialogos.MostrarMensajeInformacion(Title, "Debe Seleccionar un Cliente");
            isValid = false;
            return isValid;
         }
         if (ItemDocsVta == null)
         {
            Dialogos.MostrarMensajeInformacion(Title, "Debe Seleccionar una Factura");
            isValid = false;
            return isValid;
         }

         if (ItemNotaCredito.TIPO_CodMND == null)
         {
            Dialogos.MostrarMensajeInformacion(Title, "Debe Seleccionar una Moneda");
            isValid = false;
            return isValid;
         }

         string dateStr = ItemNotaCredito.DOCV_FechaEmision.Value.ToString("yyyyMMdd");
         decimal tipoCambio = GetTipoCambio(dateStr);
         if (tipoCambio == 0)
         {
            Dialogos.MostrarMensajeInformacion(Title, "No se encontro el tipo de cambio de para la fecha: " + dateStr + "\n Verifique con el administrador de sistemas");
            isValid = false;
            return isValid;
         }

         /*
         if (ItemNotaCredito.DOCV_ValorTotal == null || ItemNotaCredito.DOCV_ValorTotal == 0)
         {
            Dialogos.MostrarMensajeInformacion(Title, "Debe Ingresar un Monto");
            isValid = false;
            return isValid;
         }*/


         /*
         if (DocVtaSelected != null)
         {
            decimal saldo = DocVtaSelected.DOCV_ValorTotal - DocVtaSelected.DOCV_MontoPagado;

            if (saldo < 0)
            {
               Dialogos.MostrarMensajeError(Title, "El Monto Pagado Supera el Saldo de la Factura");
               isValid = false;
               return isValid;
            }
         }*/

         if ((ItemNotaCredito.TIPO_CodMND.Equals("001") ? ItemNotaCredito.DOCV_ValorTotal : ItemNotaCredito.DOCV_ValorTotalD) > ItemDocsVta.DOCV_ValorTotal)
         {
            Dialogos.MostrarMensajeInformacion(Title, "El monto de nota de credito no debe exceder al importe de la factura");
            isValid = false;
            return isValid;
         }

         if (String.IsNullOrEmpty(ItemNotaCredito.DOCV_Serie))
         {
            Dialogos.MostrarMensajeInformacion(Title, "No ha selecionado un numero de serie serie valido");
            isValid = false;
         }

         return isValid;
      }

      public decimal GetTipoCambio(String _Fecha)
      {
         String fecha = String.Empty;
         //fecha = Session.Fecha.Year.ToString() + Session.Fecha.Month.ToString().PadLeft(2, '0').Trim() + Session.Fecha.Day.ToString().PadLeft(2, '0').Trim();
         var First = Client.GetOneTiposCambio(_Fecha);

         decimal TipoCambio = 0;
         TipoCambio = First != null ? First.TIPC_Compra : 0;
         return TipoCambio;
      }

      public void CloseView()
      {
         if (isMViewShow)
         { ((PRO022MView)MView).Close(); }
      }

      public void IsClosedMView()
      { isMViewShow = false; }

      #endregion

   }
}
