using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;

namespace Delfin.Comercial
{
   public class REP006DetraccionPendientesPresenter
   {
      #region [ Variables ]
      public String Title = "Detracciones Pendientes";
      public String CUS = "REPF006";
      #endregion

      #region [ Propiedades ]

      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public IREP006DetraccionPendientesLView LView { get; set; }

      #endregion
      
      #region [ REP006DetraccionPendientesPresenter ]

      public REP006DetraccionPendientesPresenter(IUnityContainer x_container, IREP006DetraccionPendientesLView x_lview)
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
            LView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }

      #endregion

      #region [ Metodos ]

      #endregion

      #region [ Eventos ]

      #endregion

      #region [ IFormClose ]

      #endregion

   }
}
