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
//using Delfin.Controls;

namespace Delfin.Principal
{
   public class REP010Presenter
   {
      #region [ Variables ]
      public String Title = "Reporte de HAPAG-HSUD";
      public String CUS = "REP010";
      #endregion

      #region [ Contrusctor ]
      public REP010Presenter(IUnityContainer x_container, IREP010LView x_lview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
         }
         catch (Exception)
         { throw; }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();
            //LoadParameteres();
            LView.LoadView();
            //MView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Parámetros ]

      //public Entities.Parametros PARA_CODIGOHAPAG   { get; set; }
      //public Entities.Parametros PARA_CODIGOHAMBURG { get; set; }

      //private void LoadParameteres()
      //{
      //    try
      //    {
      //        var ItemsPARAMETRO = Client.GetAllParametros();

      //        PARA_CODIGOHAPAG = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CODIGO_HAPAG_LLOYD");
      //        PARA_CODIGOHAMBURG = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CODIGO_HAMBURG_SUD");
      //    }
      //    catch (Exception)
      //    { }
      //}
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }
      public IREP010LView LView { get; set; }

      public System.Data.DataTable DTReporte { get; set; }
    
      #endregion

      #region [ Metodos ]
      public void CargarReporte(String x_REBA_Tipo, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)//(Nullable<Int32> ENTC_CodTransportista, Nullable<Int32> ENTC_CodCliente, Nullable<DateTime> FEC_IniEmbarque, Nullable<DateTime> FEC_FinEmbarque, Nullable<DateTime> FEC_IniLlegada, Nullable<DateTime> FEC_FinLlegada, String NRO_HBL, String NRO_OV)
      {
         try
         {
            DTReporte = new System.Data.DataTable();
            Int16 EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            Int16 SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
            String _mensaje = String.Empty;
            DTReporte = Client.GetAllCab_Cotizacion_OVByReporteRebateHapagHamburg(x_REBA_Tipo, x_filters, ref _mensaje);//(EMPR_Codigo,SUCR_Codigo,ENTC_CodTransportista, ENTC_CodCliente, FEC_IniEmbarque, FEC_FinEmbarque, FEC_IniLlegada, FEC_FinLlegada, NRO_HBL, NRO_OV, ref _mensaje);

            if (!String.IsNullOrEmpty(_mensaje))
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error cargando el reporte.", _mensaje); }
            else if (DTReporte != null && DTReporte.Rows.Count > 0)
            {
                LView.FormatDataGrid();
                LView.ShowItems(DTReporte); 
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron resultados."); }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando el reporte.", ex); }
      }
      public void LimpiarReporte()
      {
         try
         {
            DTReporte = new System.Data.DataTable();
            //LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error limpiando el reporte.", ex); }
      }
      #endregion

   }
}
