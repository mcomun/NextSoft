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

namespace Delfin.Principal
{
   public partial class COM012Presenter
   {
      #region [ Variables ]
      public String Title = "Comisiones";
      public String CUS = "COM008";
      #endregion

      #region [ Contrusctor ]
      public COM012Presenter(IUnityContainer x_container, ICOM012LView x_lview, ICOM012MView x_mview)
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
      public COM012Presenter(IUnityContainer x_container, ICOM012MView x_mview)
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
      
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();
            if (LView != null)
            { LView.LoadView(); }
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
      
      public ICOM012LView LView { get; set; }
      public ICOM012MView MView { get; set; }

      public Cab_Cotizacion_OV Item { get; set; }
      public ObservableCollection<Cab_Cotizacion_OV> Items { get; set; }
      #endregion

      #region [ Metodos ]
      public void Procesar(ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters) //(Int32 NVIA_Codigo)
      {
         try
         {
            if (Client.SaveComisionesOV(x_filters)) //(NVIA_Codigo, Session.UserName))
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se han procesado satisfactoriamente las comisiones."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }
      #endregion
   }
}
