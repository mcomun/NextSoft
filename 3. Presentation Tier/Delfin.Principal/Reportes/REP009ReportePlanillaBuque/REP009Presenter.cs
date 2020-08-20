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
   public class REP009Presenter
   {
      #region [ Variables ]
      public String Title = "Reporte de Planilla Buque";
      public String CUS = "REP009";
      #endregion

      #region [ Contrusctor ]
      public REP009Presenter(IUnityContainer x_container, IREP009LView x_lview)
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
            ListPaquetes = Client.GetAllPaquete();

            ItemTransportista = new Entities.Entidad();
            ItemsNave = new ObservableCollection<Entities.Nave>();
            ItemsNaveUnTransportista = new ObservableCollection<Entities.Nave>();
            ItemsNave = Client.GetAllNave(null);

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

      public IREP009LView LView { get; set; }

      public ObservableCollection<Puerto> ListPuertos { get; set; }
      public ObservableCollection<Paquete> ListPaquetes { get; set; }
      public System.Data.DataTable DTReporte { get; set; }
      public Entities.Entidad Transportista { get; set; }
      public Contrato ItemContrato { get; set; }

      public ObservableCollection<Entities.Nave> ItemsNaveUnTransportista { get; set; }
      public Entities.Entidad ItemTransportista { get; set; }
      public ObservableCollection<Entities.Nave> ItemsNave { get; set; }
      #endregion

      #region [ Metodos ]
      public void CargarReporte(String CONS_TabRGM, String CONS_CodRGM, Nullable<DateTime> NVIA_FecETAIni, Nullable<DateTime> NVIA_FecETAFin, Nullable<DateTime> NVIA_FecZarpeIni, Nullable<DateTime> NVIA_FecZarpeFin, Nullable<Int32> ENTC_CodTransportista, Nullable<Int16> NAVE_Codigo)
      {
         try
         {
            DTReporte = new System.Data.DataTable();

            DTReporte = Client.GetAllNaveViajeByReporte(CONS_TabRGM, CONS_CodRGM, NVIA_FecETAIni, NVIA_FecETAFin, NVIA_FecZarpeIni, NVIA_FecZarpeFin, ENTC_CodTransportista, NAVE_Codigo);

            if (DTReporte != null && DTReporte.Rows.Count > 0)
            {
                LView.FormatDataGrid(CONS_CodRGM);
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
            LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error limpiando el reporte.", ex); }
      }
      #endregion

   }
}
