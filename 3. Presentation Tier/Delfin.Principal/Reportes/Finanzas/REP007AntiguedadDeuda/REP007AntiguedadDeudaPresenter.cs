using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Delfin.Principal
{
   public class REP007AntiguedadDeudaPresenter
   {
      #region [ Variables ]
      public String Title = "Antiguedad de la Deuda";
      public String CUS = "REPF007";
      #endregion

      #region [ Propiedades ]

      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public IREP007AntiguedadDeudaLView LView { get; set; }

      public DateTime Fecha { get; set; }

      #endregion
      
      #region [ REP007AntiguedadDeudaPresenter ]

      public REP007AntiguedadDeudaPresenter(IUnityContainer x_container, IREP007AntiguedadDeudaLView x_lview)
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
            Fecha = Client.GetFecha();
            LView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }

      #endregion

      #region [ Metodos ]

      public DateTime? F_FecIni { get; set; }
      public DateTime? F_FecFin { get; set; }

      public void Imprimir()
      {
         try
         {
            System.Data.DataTable dtReporte = new System.Data.DataTable();
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            //_listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCUBA_Codigo", FilterValue = F_CUBA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIni", FilterValue = F_FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFin", FilterValue = F_FecFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            //_listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrMOVI_EstadoCheque", FilterValue = F_MOVI_EstadoCheque, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
            //_listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TipoCheque", FilterValue = F_TipoCheque, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });

            dtReporte = Client.GetDTCuentasBancarias("CAJ_REPOSS_Cheques", _listFilters);

            if (dtReporte != null && dtReporte.Rows.Count > 0)
            {
               String ReportPath = null;
               dtReporte.TableName = "DSDetalle";
               ReportPath = Application.StartupPath + @"\Reportes\REP002Cheques.rdlc";
               ReportDataSource RepDetalle = new ReportDataSource("DSDetalle", dtReporte);

               Microsoft.Reporting.WinForms.ReportParameter[] Parameters = new Microsoft.Reporting.WinForms.ReportParameter[8];

               String _fecha = Fecha.ToString("dd/MM/yyyy HH:mm");
               Parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("Titulo", Title);
               Parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaHora", _fecha);
               Parameters[2] = new Microsoft.Reporting.WinForms.ReportParameter("CuentaCorriente", "-");
               Parameters[3] = new Microsoft.Reporting.WinForms.ReportParameter("FechaDesde", F_FecIni.Value.ToString("dd/MM/yyyy"));
               Parameters[4] = new Microsoft.Reporting.WinForms.ReportParameter("FechaHasta", F_FecFin.Value.ToString("dd/MM/yyyy"));
               Parameters[5] = new Microsoft.Reporting.WinForms.ReportParameter("Estado", "-");
               Parameters[6] = new Microsoft.Reporting.WinForms.ReportParameter("EntidadBancaria", "-");
               Parameters[7] = new Microsoft.Reporting.WinForms.ReportParameter("Tipo", "-");

               Visualizador rpt = new Visualizador("Reporte de Cheques", ReportPath, RepDetalle, Parameters);
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
