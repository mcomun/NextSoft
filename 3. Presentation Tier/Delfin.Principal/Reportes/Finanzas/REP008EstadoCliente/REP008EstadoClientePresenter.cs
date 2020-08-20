using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using Microsoft.Reporting.WinForms;

namespace Delfin.Principal
{
   public class REP008EstadoClientePresenter
   {
      #region [ Variables ]
      public String Title = "Estado de Cuenta del Cliente";
      public String CUS = "REPF008";
      #endregion

      #region [ Propiedades ]

      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public IREP008EstadoClienteLView LView { get; set; }

     public DateTime? F_FecIni { get; set; }
     public DateTime? F_FecFin { get; set; }
     public String UnidadNegocio { get; set; }
     public String UnidadNegocioText { get; set; }
     public String F_HBL { get; set; }
     public String F_MBL { get; set; }
     public Boolean F_ConsiderarAnulados { get; set; }
     public Int32 F_Entidad { get; set; }
     public String F_EntidadText{ get; set; }
     #endregion
      
      #region [ REP008EstadoClientePresenter ]

      public REP008EstadoClientePresenter(IUnityContainer x_container, IREP008EstadoClienteLView x_lview)
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
      public void Imprimir()
      {
          try
          {
              System.Data.DataTable dtReporte = new System.Data.DataTable();
              ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
              _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
              _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = F_Entidad, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 24 });
              _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIni", FilterValue = F_FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
              _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFin", FilterValue = F_FecFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
              _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@UnidadNegocio", FilterValue = UnidadNegocio, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
              _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@HBL", FilterValue = F_HBL, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
              _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@MBL", FilterValue = F_MBL, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
              _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@ConsiderarDiferidos", FilterValue = F_ConsiderarAnulados, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

              dtReporte = Client.GetDTCuentasBancarias("CAJ_REPOSS_EstadoCuenta", _listFilters);

              if (dtReporte != null && dtReporte.Rows.Count > 0)
              {
                  String ReportPath = null;
                  dtReporte.TableName = "REP001AuxiliarBancos";
                  ReportPath = Application.StartupPath + @"\Reportes\REP008EstadoCliente.rdlc";
                  ReportDataSource RepDetalle = new ReportDataSource("CAJ_REPOSS_EstadoCuenta", dtReporte);

                  Microsoft.Reporting.WinForms.ReportParameter[] Parameters = new Microsoft.Reporting.WinForms.ReportParameter[10];

                  Parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("Titulo", "Reporte de Estado Cliente");
                  Parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("Entidad", F_Entidad.ToString());
                  Parameters[2] = new Microsoft.Reporting.WinForms.ReportParameter("FechaDesde", F_FecIni.Value.ToString("dd/MM/yyyy"));
                  Parameters[3] = new Microsoft.Reporting.WinForms.ReportParameter("FechaHasta", F_FecFin.Value.ToString("dd/MM/yyyy"));
                  Parameters[4] = new Microsoft.Reporting.WinForms.ReportParameter("UnidadNegocio", UnidadNegocioText);
                  Parameters[5] = new Microsoft.Reporting.WinForms.ReportParameter("MBL", (F_MBL == null ? "-" : F_MBL));
                  Parameters[6] = new Microsoft.Reporting.WinForms.ReportParameter("HBL", (F_HBL == null ? "-" : F_HBL));
                  Parameters[7] = new Microsoft.Reporting.WinForms.ReportParameter("ConsiderarAnulados", F_ConsiderarAnulados ? "Considerar Anulados" : "No Considerar Anulados");
                  Parameters[8] = new Microsoft.Reporting.WinForms.ReportParameter("EntidadText", F_EntidadText);
                  Parameters[9] = new Microsoft.Reporting.WinForms.ReportParameter("FechaHora", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

                  Visualizador rpt = new Visualizador("Reporte de Estado Cliente", ReportPath, RepDetalle,Parameters);
                  rpt.StartPosition = FormStartPosition.CenterScreen;
                  rpt.Imprimir();
                  rpt.ShowDialog();

              }
              else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron registros"); }

          }
          catch (Exception)
          { throw; }
      }
      #endregion

      #region [ Eventos ]

      #endregion

      #region [ IFormClose ]

      #endregion

   }
}
