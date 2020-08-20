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
using Delfin.Controls;

namespace Delfin.Principal
{
   public class REP001Presenter
   {
      #region [ Variables ]
      public String Title = "Reporte de Fletamento";
      public String CUS = "REP001";
      #endregion

      #region [ Contrusctor ]
      public REP001Presenter(IUnityContainer x_container, IREP001LView x_lview)
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
            ListPuertos = Client.GetAllPuerto();
            LView.LoadView();
            //MView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public IREP001LView LView { get; set; }

      public ObservableCollection<Puerto> ListPuertos { get; set; }
      public System.Data.DataTable DTReporte { get; set; }
      #endregion

      #region [ Metodos ]
      public void CargarReporte(Nullable<DateTime> CCOT_FechaDesde, Nullable<DateTime> CCOT_FechaHasta, Nullable<Int32> ENTC_CodCliente, Nullable<Int32> ENTC_CodTransportista, String TIPO_TabCDT, String TIPO_CodCDT, String TIPO_TabTRF, String TIPO_CodTRF, Nullable<Int32> PUER_Codigo)
      {
         try
         {
            if (CCOT_FechaDesde.HasValue)
            {
               if (CCOT_FechaHasta.HasValue)
               {
                  
                  DTReporte = Client.GetAllCab_Cotizacion_OVReporteFletamiento(CCOT_FechaDesde.Value, CCOT_FechaHasta.Value, ENTC_CodCliente, ENTC_CodTransportista, TIPO_TabCDT, TIPO_CodCDT, TIPO_TabTRF, TIPO_CodTRF, PUER_Codigo);

                  if (DTReporte != null && DTReporte.Rows.Count > 0)
                  {
                     LView.ShowItems();
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron resultados."); }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar la fecha Hasta."); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar la fecha Desde."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando el reporte.", ex); }
      }
      public void LimpiarReporte()
      {
         try
         {
            DTReporte = new System.Data.DataTable();
            LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error limpiando el reporte.", ex); }
      }
      #endregion
   }
}
