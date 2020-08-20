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
   public class OPE007Presenter
   {
      #region [ Variables ]
      public String Title = "Flete Costo";
      public String CUS = "OPE007";
      #endregion

      #region [ Contrusctor ]
      public OPE007Presenter(IUnityContainer x_container, IOPE007LView x_lview)
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

      #region [ Propiedades ]

      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }
      public IOPE007LView LView { get; set; }
      public System.Data.DataTable DT_NoEncontrados { get; set; }
      public System.Data.DataTable DT_Diferentes { get; set; }
      public System.Data.DataSet DS_Resultado { get; set; }

      #endregion

      #region [ Metodos ]
      public void Sincronizar(System.Data.DataTable x_FleteCostoExcel)
      {
         try
         {
             DS_Resultado = new System.Data.DataSet();
             DS_Resultado = Client.OPE_CCOTSS_ComparaFleteCosto(x_FleteCostoExcel);
             DT_NoEncontrados = new System.Data.DataTable();
             DT_NoEncontrados = DS_Resultado.Tables[0];
             DT_Diferentes = new System.Data.DataTable();
             DT_Diferentes = DS_Resultado.Tables[1];
             LView.ShowItems();
         } 
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando el reporte.", ex); }
      }
      public void LimpiarReporte()
      {
         try
         {
           
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error limpiando el reporte.", ex); }
      }
      #endregion

   }
}
