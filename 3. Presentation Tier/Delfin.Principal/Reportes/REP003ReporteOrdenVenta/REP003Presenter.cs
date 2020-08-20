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
   public class REP003Presenter
   {
      #region [ Variables ]
      public String Title = "Reporte de Orden de Venta";
      public String CUS = "REP003";
      #endregion

      #region [ Contrusctor ]
      public REP003Presenter(IUnityContainer x_container, IREP003LView x_lview)
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

      public IREP003LView LView { get; set; }

      public ObservableCollection<Puerto> ListPuertos { get; set; }
      public System.Data.DataTable DTReporte { get; set; }
      public Entities.Entidad Transportista { get; set; }
      #endregion

      #region [ Metodos ]
      public void CargarReporte(String CONS_TabRGM, String CONS_CodRGM, String CONS_TabVIA, String CONS_CodVIA, DateTime CONT_FecEmiDesde, DateTime CONT_FecEmiHasta, Nullable<Int32> ENTC_CodTransportista, Nullable<Int32> PUER_CodOrigen, Nullable<Int32> PUER_CodDestino)
      {
         try
         {

            DTReporte = Client.GetAllCab_Cotizacion_OVByReporteOV(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, CONS_TabRGM, CONS_CodRGM, CONS_TabVIA, CONS_CodVIA, CONT_FecEmiDesde, CONT_FecEmiHasta, ENTC_CodTransportista, PUER_CodOrigen, PUER_CodDestino);

            if (DTReporte != null && DTReporte.Rows.Count > 0)
            {
               foreach (System.Data.DataColumn column in DTReporte.Columns)
               { column.AllowDBNull = true; }

               Int32 Numero = 0;
               Int16 Item = 0;
               foreach (System.Data.DataRow row in DTReporte.Rows)
               {
                  
                  Int32 _Numero = 0;
                  Int16 _Item = 0;
                  if (Int32.TryParse(row["NUMERO"].ToString(), out _Numero))
                  {
                     if (Numero == _Numero)
                     {
                        row["ORDEN VENTA"] = DBNull.Value;
                        row["FECHA EMISISON"] = DBNull.Value;
                        row["PUERTO ORIGEN"] = DBNull.Value;
                        row["PUERTO DESTINO"] = DBNull.Value;
                        row["TRANSPORTISTA"] = DBNull.Value;
                        row["EJECUTIVO"] = DBNull.Value;
                     }
                     else
                     { Numero = _Numero; }
                  }
               }

               DTReporte.Columns.Remove("NUMERO");
               DTReporte.Columns.Remove("ITEM");

               LView.ShowItems();
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
