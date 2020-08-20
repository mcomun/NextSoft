using System;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using Delfin.ServiceProxy;
using Infrastructure.Client.Services.Session;
using Infrastructure.WinFormsControls;
using System.Data;
using Infrastructure.Aspect.Constants;
using Microsoft.Reporting.WinForms;

namespace Delfin.Principal
{
   public class REP007Presenter
   {
      #region [ Variables ]
      public String Titulo = "Ingresos";
      public String CUS = "REP007";
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public Delfin.ServiceContracts.IDelfinServices Client { get; set; }
             
      public IREP007LView LView { get; set; }
      public IPRO007RMView MView { get; set; }

      public Int32? ENTC_CodigoFiltro { get; set; }
      public String NroOperacion { get; set; }
      public String Cliente { get; set; }
      public String HBLOperacion { get; set; }
      public DateTime? FechaEmisionIni { get; set; }
      public DateTime? FechaEmisionFin { get; set; }
      public String MensajeError { get; set; }

      public DataSet DSReporte { get; set; }
      public ReportDataSource RepDataSource { get; set; }
      
      public String ReportPath { get; set; }
      public ReportParameter[] Parameters { get; set; }
      
      
      #endregion

      #region [ Constructor ]
      public REP007Presenter(IUnityContainer x_container, IREP007LView x_lview, IPRO007RMView x_mview)
      {
         try
         {
            ContainerService = x_container;
            Session = ContainerService.Resolve<ISessionService>();
            LView = x_lview;
            MView = x_mview;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Titulo, Mensajes.ConstructorPresenter, ex); }
      }
      public void Load()
      {
         try
         {
             Client = ContainerService.Resolve<Delfin.ServiceContracts.IDelfinServices>();
             LView.LoadView();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Titulo, Mensajes.LoadPresenter, ex); }
      }
      #endregion

      #region [ Metodos ]
      
      #region [ Documento de Venta ]
      
      
      #endregion

      #region [ Impresión ]
      public void Imprimir(String x_TipoReporte)
      {
          try
          {
              DSReporte = new DataSet();
              DataTable _Dt = new DataTable();
              LView.LoadFilters();
              MensajeError = String.Empty;
              if (FechaEmisionIni == null && FechaEmisionFin == null)
              {
                  MensajeError += "* Debe ingresar la fecha de desde y fecha de hasta" + Environment.NewLine;
              }
              if (FechaEmisionIni == null)
              {
                  MensajeError += "* Debe ingresar la fecha de desde" + Environment.NewLine;
              }
              if (FechaEmisionFin == null)
              {
                  MensajeError += "* Debe ingresar la fecha de hasta" + Environment.NewLine;
              }
              if (String.IsNullOrEmpty(MensajeError))
              {
                  if (!String.IsNullOrEmpty(x_TipoReporte))
                  {
                      _Dt = Client.GetAllOperacionLiquidacion(ENTC_CodigoFiltro, NroOperacion, HBLOperacion, FechaEmisionIni.Value, FechaEmisionFin.Value, x_TipoReporte); 
                  }
              }
              else
              {
                  LView.ShowValidation();
                  return;
              }
              if (_Dt == null)
              { Dialogos.MostrarMensajeInformacion(Titulo, "No se encontraron coincidencias."); return; }
             if(_Dt.Rows.Count == 0 )
              { Dialogos.MostrarMensajeInformacion(Titulo, "No se encontraron coincidencias."); return; }
              ReportPath = null;

              if (!String.IsNullOrEmpty(x_TipoReporte) && x_TipoReporte.Equals("Resumido"))
              {
                 ReportPath = Application.StartupPath + @"\Reportes\RptIngresos.rdlc";
                  RepDataSource = new ReportDataSource("DsIngresos", _Dt);
              }
              else
              {
                 ReportPath = Application.StartupPath + @"\Reportes\RptIngresosDetallado.rdlc";
                  RepDataSource = new ReportDataSource("DSIngresoDetallado", _Dt);

              }
              LView.ShowReporte();
          }
          catch (Exception ex)
          { throw ex; }
      }
      #endregion

      #endregion
   }
}
