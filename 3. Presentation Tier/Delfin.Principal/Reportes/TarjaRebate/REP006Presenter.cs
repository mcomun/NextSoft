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
   public class REP006Presenter
   {
      #region [ Variables ]
      public String Titulo = "Tarjas";
      public String CUS = "REP006";
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public Delfin.ServiceContracts.IDelfinServices Client { get; set; }
             
      public IREP006LView LView { get; set; }
      public IPRO006RView MView { get; set; }

      public Int32? ENTC_CodigoFiltro { get; set; }
      public String NroOperacion { get; set; }
      public String Cliente { get; set; }
      public String HBLOperacion { get; set; }
      public DateTime? FechaEmisionIni { get; set; }
      public DateTime? FechaEmisionFin { get; set; }
      public String MensajeError { get; set; }

      public DataSet DSReporte { get; set; }
      public ReportDataSource RepDataSourceTarjas { get; set; }
      public ReportDataSource RepDataSourceReBate { get; set; }
      
      public String ReportPath { get; set; }
      public ReportParameter[] Parameters { get; set; }
      
      
      #endregion

      #region [ Constructor ]
      public REP006Presenter(IUnityContainer x_container, IREP006LView x_lview, IPRO006RView x_mview)
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
      public void Imprimir()
      {
          try
          {
              DSReporte = new DataSet();
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
                  DSReporte = Client.GetAllTarjasRebatesReporte(ENTC_CodigoFiltro, NroOperacion, HBLOperacion, FechaEmisionIni.Value, FechaEmisionFin.Value);
              }
              else
              {
                  LView.ShowValidation();
                  return;
              }
              if (DSReporte == null) return;
              if (DSReporte.Tables.Count < 1 && DSReporte.Tables[0].Rows.Count==0)
              { Dialogos.MostrarMensajeInformacion(Titulo, "No se encontraron coincidencias."); return; }
              ReportPath = Application.StartupPath + @"\Reportes\RptTarjaRebate.rdlc";
              Cliente = "";
              if (DSReporte.Tables[0].Rows.Count == 0 && DSReporte.Tables[1].Rows.Count == 0)
              {
                 Dialogos.MostrarMensajeInformacion(Titulo, "No existen datos según los parametros ingresados");
                 return;
              }
              if (DSReporte.Tables[0].Rows.Count > 0)
              {
                 RepDataSourceTarjas = new ReportDataSource("DsTarjas", DSReporte.Tables[0]);
                 Cliente = DSReporte.Tables[0].Rows[0]["Cliente"].ToString();
              }
              if (DSReporte.Tables[1].Rows.Count > 0)
              {
                 RepDataSourceReBate = new ReportDataSource("DsRebates", DSReporte.Tables[1]);
              }
              Parameters = new ReportParameter[3];
              Parameters[0] = new ReportParameter("Entidad", Cliente);
              Parameters[1] = new ReportParameter("Inicio", FechaEmisionIni.Value.ToShortDateString());
              Parameters[2] = new ReportParameter("Fin", FechaEmisionFin.Value.ToShortDateString());
              MView.ShowReporte();
              ((PRO006RView)MView).ShowDialog();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Titulo, "Ha ocurrido un error al mostrar el reporte.", ex); }
      }
      #endregion

      #endregion
   }
}
