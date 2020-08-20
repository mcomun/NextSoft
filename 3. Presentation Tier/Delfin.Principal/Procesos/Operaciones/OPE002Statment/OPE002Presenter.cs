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
   public partial class OPE002Presenter
   {
      #region [ Variables ]

      public String Title = "Statment";
      public String CUS = "OPE002";

      #endregion

      #region [ Contrusctor ]

      public OPE002Presenter(IUnityContainer x_container, IOPE002View x_mview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.MView = x_mview;

         }
         catch (Exception)
         {
            throw;
         }
      }

      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();

            MView.LoadView();
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex);
         }
      }

      #endregion

      #region [ Propiedades ]

      public IUnityContainer ContainerService { get; set; }

      public ISessionService Session { get; set; }

      public IDelfinServices Client { get; set; }

      public IOPE002View MView { get; set; }

      #endregion

      #region [ Metodos ]

      public void Cargar(Entities.NaveViaje ItemNaveViaje, Boolean ChangeControl)
      {
         try
         {
            Int16 EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            Int16 SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
            Int32 NVIA_Codigo = ItemNaveViaje.NVIA_Codigo;
            Nullable<Int16> CCOT_Tipo = null;
            Nullable<Int32> CCOT_Numero = null;
            String Usuario = Session.UserName;


            var _itemTipoCambio = Client.GetOneTiposCambio(Session.Fecha.ToString("yyyyMMdd"));
            if (_itemTipoCambio != null)
            {
               System.Data.DataTable dtStatment = Client.OPE_GetCab_Cotizacion_OVStatment(EMPR_Codigo, SUCR_Codigo, NVIA_Codigo, CCOT_Tipo, CCOT_Numero, Usuario, _itemTipoCambio.TIPC_Venta, ChangeControl, false);

               if (dtStatment != null && dtStatment.Rows.Count > 0)
               { Infrastructure.WinForms.Controls.ExportarExcel.Export(dtStatment); }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se han encontrado registros para emitir el Statment"); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar el Tipo de Cambio para la fecha " + Session.Fecha.ToShortDateString()); }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex);
         }
      }

      #endregion
   }
}