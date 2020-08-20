using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;
using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


namespace Delfin.Principal
{
   public class REP001AuxiliarBancosPresenter
   {
      #region [ Variables ]
      public String Title = "Reporte de Auxiliar de Bancos";
      public String CUS = "REPF001";
      #endregion

      #region [ Propiedades ]

      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public IREP001AuxiliarBancosLView LView { get; set; }
      public DateTime Fecha { get; set; }

      #endregion

      #region [ REP001AuxiliarBancosPresenter ]

      public REP001AuxiliarBancosPresenter(IUnityContainer x_container, IREP001AuxiliarBancosLView x_lview)
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

      public String F_CUBA_Codigo { get; set; }
      public String F_CUBA_NroCuenta { get; set; }
      public DateTime? F_FecIni { get; set; }
      public DateTime? F_FecFin { get; set; }
      public String F_TIPO_CodMOV { get; set; }
      public String F_TipoMovimiento { get; set; }
      public String F_HBL { get; set; }
      public String F_MBL { get; set; }
      public Boolean F_ConsiderarAnulados { get; set; }
      public String F_EntidadBancaria { get; set; }

      public void Imprimir()
      {
         try
         {
            System.Data.DataTable dtReporte = new System.Data.DataTable();
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCUBA_Codigo", FilterValue = F_CUBA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIni", FilterValue = F_FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFin", FilterValue = F_FecFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodMOV", FilterValue = F_TIPO_CodMOV, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize =  1024});
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@HBL", FilterValue = F_HBL, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@MBL", FilterValue = F_MBL, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@ConsiderarAnulados", FilterValue = F_ConsiderarAnulados, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

            dtReporte = Client.GetDTCuentasBancarias("CAJ_REPOSS_AuxiliarBancos", _listFilters);

            if (dtReporte != null && dtReporte.Rows.Count > 0)
            {
               Decimal _saldo = 0;
               foreach (System.Data.DataRow item in dtReporte.Rows)
               {
                  _saldo += Decimal.Parse(item["Debe"].ToString()) - Decimal.Parse(item["Haber"].ToString());
                  item["Saldo"] = _saldo;
               }

               String ReportPath = null;
               dtReporte.TableName = "REP001AuxiliarBancos";
               ReportPath = Application.StartupPath + @"\Reportes\REP001AuxiliarBancos.rdlc";
               ReportDataSource RepDetalle = new ReportDataSource("REP001AuxiliarBancos", dtReporte);

               Microsoft.Reporting.WinForms.ReportParameter[] Parameters = new Microsoft.Reporting.WinForms.ReportParameter[10];

               String _fecha = Fecha.ToString("dd/MM/yyyy HH:mm");
               Parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("Titulo", "Reporte de Auxiliar de Bancos");
               Parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaHora", _fecha);
               Parameters[2] = new Microsoft.Reporting.WinForms.ReportParameter("CuentaCorriente", F_CUBA_NroCuenta);
               Parameters[3] = new Microsoft.Reporting.WinForms.ReportParameter("FechaDesde", F_FecIni.Value.ToString("dd/MM/yyyy"));
               Parameters[4] = new Microsoft.Reporting.WinForms.ReportParameter("FechaHasta", F_FecFin.Value.ToString("dd/MM/yyyy"));
               Parameters[5] = new Microsoft.Reporting.WinForms.ReportParameter("TipoMovimiento", F_TipoMovimiento);
               Parameters[6] = new Microsoft.Reporting.WinForms.ReportParameter("MBL", (F_MBL == null ? "-" : F_MBL));
               Parameters[7] = new Microsoft.Reporting.WinForms.ReportParameter("HBL", (F_HBL == null ? "-" : F_HBL));
               Parameters[8] = new Microsoft.Reporting.WinForms.ReportParameter("ConsiderarAnulados", F_ConsiderarAnulados ? "Considerar Anulados" : "No Considerar Anulados");
               Parameters[9] = new Microsoft.Reporting.WinForms.ReportParameter("EntidadBancaria", F_EntidadBancaria);
               
               Visualizador rpt = new Visualizador("Reporte de Auxiliar de Bancos", ReportPath, RepDetalle, Parameters);
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
