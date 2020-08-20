using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;

namespace Delfin.Principal
{
   public class REP003PlanillaExportacionPresenter
   {
      #region [ Variables ]
      public String Title = "Planilla de Exportacióna Bancos";
      public String CUS = "REPF003";
      #endregion

      #region [ Propiedades ]

      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public IREP003PlanillaExportacionLView LView { get; set; }

      #endregion
      
      #region [ REP003PlanillaExportacionPresenter ]

      public REP003PlanillaExportacionPresenter(IUnityContainer x_container, IREP003PlanillaExportacionLView x_lview)
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
