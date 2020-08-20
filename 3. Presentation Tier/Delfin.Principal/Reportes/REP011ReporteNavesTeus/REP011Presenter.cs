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

namespace Delfin.Principal
{
   public class REP011Presenter
   {
      #region [ Variables ]
      public String Title = "Reporte de TEUS";
      public String CUS = "REP011";
      #endregion

      #region [ Contrusctor ]
      public REP011Presenter(IUnityContainer x_container, IREP011LView x_lview)
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
            ItemsNave = new ObservableCollection<Nave>();
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
      public IREP011LView LView { get; set; }

      public System.Data.DataTable DTReporte { get; set; }
      public ObservableCollection<Nave> ItemsNave { get; set; }
      #endregion

      #region [ Metodos ]
      public void CargarReporte(String CONS_TabRGM, String CONS_CodRGM, String NVIA_NroViaje, Nullable<DateTime> FEC_IniETA, Nullable<DateTime> FEC_FinETA, Nullable<DateTime> FEC_IniZarpe, Nullable<DateTime> FEC_FinZarpe, Nullable<DateTime> FEC_IniEmbarque, Nullable<DateTime> FEC_FinEmbarque, Nullable<Int32> ENTC_Transportista, Nullable<Int32> ENTC_Vendedor, Nullable<Int32> ENTC_Deposito, Nullable<Int16> NAVE_Codigo, Boolean Detallado)
      {
         try
         {
            DTReporte = new System.Data.DataTable();
            Int16 EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            Int16 SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
            DTReporte = Client.GetAllCab_Cotizacion_OVByReporteTeus(EMPR_Codigo,SUCR_Codigo,CONS_TabRGM, CONS_CodRGM, NVIA_NroViaje, FEC_IniETA, FEC_FinETA, FEC_IniZarpe, FEC_FinZarpe, FEC_IniEmbarque,FEC_FinEmbarque, ENTC_Transportista,ENTC_Vendedor,ENTC_Deposito, NAVE_Codigo,Detallado);

            if (DTReporte != null && DTReporte.Rows.Count > 0)
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
