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
   public class COM009Presenter
   {
      #region [ Variables ]
      public String Title = "KPI Cotizaciones";
      public String CUS = "COM009";
      #endregion

      #region [ Contrusctor ]
      public COM009Presenter(IUnityContainer x_container, ICOM009LView x_lview)
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

      public ICOM009LView LView { get; set; }
      
      public Microsoft.Reporting.WinForms.ReportDataSource RepDataSource { get; set; }
      public String ReportPath { get; set; }
      public Microsoft.Reporting.WinForms.ReportParameter[] Parameters { get; set; }
      #endregion

      #region [ Metodos ]
      public void CargarReporte(Nullable<DateTime> Desde, Nullable<DateTime> Hasta, Boolean PorEjecutivo, Entities.Entidad Ejecutivo)
      {
         try
         {
            if (Desde.HasValue)
            {
               if (Hasta.HasValue)
               {
                  System.Data.DataTable DTKPIs = null;
                  if (PorEjecutivo)
                  {
                     if (Ejecutivo != null)
                     { DTKPIs = Client.GetAllCab_Cotizacion_OVKPICotizaciones(Entorno.ItemEmpresa.EMPR_Codigo, Entorno.ItemSucursal.SUCR_Codigo, Desde.Value, Hasta.Value, PorEjecutivo, Ejecutivo.ENTC_Codigo); }
                     else
                     { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un Ejecutivo."); }
                  }
                  else
                  { DTKPIs = Client.GetAllCab_Cotizacion_OVKPICotizaciones(Entorno.ItemEmpresa.EMPR_Codigo, Entorno.ItemSucursal.SUCR_Codigo, Desde.Value, Hasta.Value, PorEjecutivo, null); }

                  if (DTKPIs != null && DTKPIs.Rows.Count > 0)
                  {
                     if (!PorEjecutivo)
                     {
                        ReportPath = System.Windows.Forms.Application.StartupPath + @"\Reportes\rptKPI003Cotizaciones.rdlc";
                        RepDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
                        RepDataSource.Name = "DTKPIs";
                        RepDataSource.Value = DTKPIs;

                        String MIN = DTKPIs.Rows[0]["KPIMIN"].ToString();
                        String MAX = DTKPIs.Rows[0]["KPIMAX"].ToString();

                        this.Parameters = new Microsoft.Reporting.WinForms.ReportParameter[2];
                        Parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("parMIN", MIN);
                        Parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("parMAX", MAX);
                     }
                     else
                     {
                        ReportPath = System.Windows.Forms.Application.StartupPath + @"\Reportes\rptKPI003CotizacionesEjecutivo.rdlc";
                        RepDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
                        RepDataSource.Name = "DTKPIs";
                        RepDataSource.Value = DTKPIs;

                        String MIN = DTKPIs.Rows[0]["KPIMIN"].ToString();
                        String MAX = DTKPIs.Rows[0]["KPIMAX"].ToString();

                        this.Parameters = new Microsoft.Reporting.WinForms.ReportParameter[3];
                        Parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("parMIN", MIN);
                        Parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("parMAX", MAX);
                        Parameters[2] = new Microsoft.Reporting.WinForms.ReportParameter("parEJECUTIVO", Ejecutivo.ENTC_NomCompleto);
                     }
                     
                     LView.ShowItems(); 
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron resultados."); }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar la fecha Hasta."); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar la fecha Desde."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando el reporte.", ex); }
      }
      public void LimpiarReporte()
      {
         try
         {
            ReportPath = System.Windows.Forms.Application.StartupPath + @"\Reportes\rptKPI003Cotizaciones.rdlc";

            RepDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
            RepDataSource.Name = "DTKPIs";
            RepDataSource.Value = null;

            String MIN = "0";
            String MAX = "0";

            this.Parameters = new Microsoft.Reporting.WinForms.ReportParameter[2];
            Parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("parMIN", MIN);
            Parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("parMAX", MAX);

            LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error limpiando el reporte.", ex); }
      }
      #endregion
   }
}
