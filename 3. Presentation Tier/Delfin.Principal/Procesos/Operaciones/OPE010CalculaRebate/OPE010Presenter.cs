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

using XLExcel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;

namespace Delfin.Principal
{
   public partial class OPE010Presenter
   {
      #region [ Variables ]
      public String Title = "Calcular Rebate";
      public String CUS = "OPE010";
      public DateTime Fecha { get; set; }
      #endregion

      #region [ Contrusctor ]
      public OPE010Presenter(IUnityContainer x_container, IOPE010View x_mview)
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
            Fecha = Client.GetFecha();
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
      public IOPE010View MView { get; set; }

      public System.Data.DataTable DtControlTransmisiones { get; set; }
      #endregion

      #region [ Parámetros ]
      #endregion

      #region [ Metodos ]
      public void CalcularRebate(String x_REBA_Tipo, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)//(Nullable<Int32> ENTC_CodTransportista, Nullable<Int32> ENTC_CodCliente, Nullable<DateTime> FEC_IniEmbarque, Nullable<DateTime> FEC_FinEmbarque, Nullable<DateTime> FEC_IniLlegada, Nullable<DateTime> FEC_FinLlegada, String NRO_HBL, String NRO_OV)
      {
         try
         {
            bool _isCorrect = Client.OPE_SaveCab_Cotizacion_OV_CalculaRebateGRR(x_REBA_Tipo, x_filters); //(ENTC_CodTransportista, ENTC_CodCliente, FEC_IniEmbarque, FEC_FinEmbarque, FEC_IniLlegada, FEC_FinLlegada, NRO_HBL,NRO_OV);
            if (_isCorrect)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha realizado el cálculo del Rebate satisfactoriamente"); }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron resultados."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }
      #endregion
   }
}