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
   public class REP013Presenter
   {
      #region [ Variables ]
      public String Title = "Reporte de COMISION - EJECUTIVO";
      public String CUS = "REP013";
      #endregion

      #region [ Contrusctor ]
      public REP013Presenter(IUnityContainer x_container, IREP013LView x_lview)
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
      public IREP013LView LView { get; set; }

      public System.Data.DataTable DTReporte { get; set; }
    
      #endregion

      #region [ Metodos ]
      public void CargarReporte(Nullable<DateTime> FEC_IniConcluye, Nullable<DateTime> FEC_FinConcluye, String DOOV_HBL, String CCOT_NumDoc , Nullable<Int32> ENTC_Ejecutivo, Nullable<Int32> ENTC_Cliente)
      {
         try
         {
            DTReporte = new System.Data.DataTable();
            Int16 EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            Int16 SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
            //DTReporte = Client.GetAllCab_Cotizacion_OVByProfitNegativo
            String _mensaje = String.Empty;
            DTReporte = Client.GetAllCab_Cotizacion_OVByComEjecutivo(EMPR_Codigo, SUCR_Codigo, FEC_IniConcluye, FEC_FinConcluye, DOOV_HBL, CCOT_NumDoc, ENTC_Ejecutivo, ENTC_Cliente, ref _mensaje);
            if (!String.IsNullOrEmpty(_mensaje))
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error cargando el reporte.", _mensaje);}
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
