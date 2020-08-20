using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Collections.ObjectModel;

namespace Delfin.Principal
{
   public class REP004DocRecepcionadosPresenter
   {
      #region [ Variables ]
      public String Title = "Documentos Recepcionados";
      public String CUS = "REPF004";
      #endregion

      #region [ Propiedades ]

      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public IREP004DocRecepcionadosLView LView { get; set; }
      public DateTime Fecha { get; set; }
      public TReporte TipoReporte;

      public enum TReporte
      {
         Todos = 0, Agente = 6, Proveedor = 2, Transportista = 5
      }
      #endregion

      #region [ REP004DocRecepcionadosPresenter ]

      public REP004DocRecepcionadosPresenter(IUnityContainer x_container, IREP004DocRecepcionadosLView x_lview, TReporte x_TipoReporte)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
            TipoReporte = x_TipoReporte;
            CUS = String.Format("{0}{1}", CUS, (int)x_TipoReporte);
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


      public Int16? F_TIPE_Codigo { get; set; }
      public String F_TIPE_Codigo_Text { get; set; }
      public Int32? F_ENTC_Codigo { get; set; }
      public String F_ENTC_Codigo_Text { get; set; }
      public String F_TipoFecha { get; set; }
      public Boolean F_SoloMostrarPendientes { get; set; }
      public Boolean F_ConDetraccion { get; set; }
      public String F_TIPO_CodDetrac { get; set; }
      public String F_TIPO_CodDetrac_Text { get; set; }
      public String F_TipoRegistro { get; set; }
      public Int32? F_NVIA_Codigo { get; set; }
      public String F_NVIA_NroViaje { get; set; }

      public String F_HBL { get; set; }
      public String F_MBL { get; set; }
      public DateTime? F_FecIni { get; set; }
      public DateTime? F_FecFin { get; set; }
      public String F_lblFecha { get; set; }

      public void Imprimir()
      {
         try
         {
            System.Data.DataTable dtReporte = new System.Data.DataTable();
            System.Data.DataTable dtReporteTotales = new System.Data.DataTable();
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinTIPE_Codigo", FilterValue = F_TIPE_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = F_ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodDetrac", FilterValue = F_TIPO_CodDetrac, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@HBL", FilterValue = F_HBL, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@MBL", FilterValue = F_MBL, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TipoFecha", FilterValue = F_TipoFecha, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 2 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIni", FilterValue = F_FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFin", FilterValue = F_FecFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintNVIA_Codigo", FilterValue = F_NVIA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@SoloPendientes", FilterValue = F_SoloMostrarPendientes, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@ConDetraccion", FilterValue = F_ConDetraccion, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TipoRegistro", FilterValue = F_TipoRegistro, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
            if (TipoReporte == TReporte.Agente)
            { _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@MonedaOriginal", FilterValue = true, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 }); }

            System.Data.DataSet DSDatos = Client.GetDSDocsVta("CAJ_REPOSS_TodosDocumentos", _listFilters);
            dtReporte = DSDatos.Tables[0];
            dtReporteTotales = DSDatos.Tables[1];

            if (dtReporte != null && dtReporte.Rows.Count > 0)
            {
               String ReportPath = null;
               dtReporte.TableName = "DSDetalle";

               if (F_ConDetraccion)
               { ReportPath = Application.StartupPath + @"\Reportes\REP006DetraccionPendientes.rdlc"; }
               else { ReportPath = Application.StartupPath + @"\Reportes\REP004DocRecepcionados.rdlc"; }

               Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource();
               rds.Name = "DSDetalle";
               rds.Value = dtReporte;

               Microsoft.Reporting.WinForms.ReportDataSource rdsDet = new Microsoft.Reporting.WinForms.ReportDataSource();
               rdsDet.Name = "DSTotales";
               rdsDet.Value = dtReporteTotales;

               Dictionary<String, Microsoft.Reporting.WinForms.ReportDataSource> x_subreports = new Dictionary<string, Microsoft.Reporting.WinForms.ReportDataSource>();

               String _titulo = "";
               switch (TipoReporte)
               {
                  case TReporte.Agente: // "Agente":
                     if (!F_ENTC_Codigo.HasValue)
                     { ReportPath = Application.StartupPath + @"\Reportes\REP004DocRecepcionadosAgenteTodos.rdlc"; }
                     else
                     { ReportPath = Application.StartupPath + @"\Reportes\REP004DocRecepcionadosAgente.rdlc"; }
                     x_subreports.Add("REP004DocRecepcionadosAgenteTotal", rdsDet);
                     break;
                  case TReporte.Proveedor:  //"Proveedor"
                     if (!F_ENTC_Codigo.HasValue) { ReportPath = Application.StartupPath + @"\Reportes\REP004DocRecepcionadosProveedorTodos.rdlc"; }
                     else { ReportPath = Application.StartupPath + @"\Reportes\REP004DocRecepcionadosProveedor.rdlc"; }
                     x_subreports.Add("REP004DocRecepcionadosLineasTotal", rdsDet);
                     break;
                  case TReporte.Todos: // "Cliente":
                     if (!F_ENTC_Codigo.HasValue) { ReportPath = Application.StartupPath + @"\Reportes\REP004DocRecepcionadosClientesTodos.rdlc"; }
                     else { ReportPath = Application.StartupPath + @"\Reportes\REP004DocRecepcionadosClientes.rdlc"; }
                     x_subreports.Add("REP004DocRecepcionadosClientesTotal", rdsDet);
                     break;
                  case TReporte.Transportista: // "Transportista":
                     if (!F_ENTC_Codigo.HasValue) { ReportPath = Application.StartupPath + @"\Reportes\REP004DocRecepcionadosLineasTodos.rdlc"; }
                     else { ReportPath = Application.StartupPath + @"\Reportes\REP004DocRecepcionadosLineas.rdlc"; }
                     x_subreports.Add("REP004DocRecepcionadosLineasTotal", rdsDet);
                     break;
                  default:
                     if (!F_ENTC_Codigo.HasValue) { ReportPath = Application.StartupPath + @"\Reportes\REP004DocRecepcionadosClientesTodos.rdlc"; }
                     else { ReportPath = Application.StartupPath + @"\Reportes\REP004DocRecepcionadosClientes.rdlc"; }
                     x_subreports.Add("REP004DocRecepcionadosClientesTotal", rdsDet);
                     break;
               }
               //ReportDataSource RepDetalle = new ReportDataSource("DSDetalle", dtReporte);
               

               Microsoft.Reporting.WinForms.ReportParameter[] Parameters = new Microsoft.Reporting.WinForms.ReportParameter[14];

               String _fecha = Fecha.ToString("dd/MM/yyyy HH:mm");
               String _tfdesde = "{0} desde :", _tfhasta = "{0} hasta :";
               if (F_ConDetraccion) { _titulo = "Reporte de Detracciones Pendientes"; }
               else if (F_SoloMostrarPendientes) { _titulo = "Reporte de Documentos Pendientes"; }
               else { _titulo = "Reporte de Documentos Recepcionados"; }

               Parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("Titulo", _titulo);
               Parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaHora", _fecha);
               Parameters[2] = new Microsoft.Reporting.WinForms.ReportParameter("FechaDesde", (F_FecIni.HasValue ? F_FecIni.Value.ToString("dd/MM/yyyy") : "-"));
               Parameters[3] = new Microsoft.Reporting.WinForms.ReportParameter("FechaHasta", F_FecFin.Value.ToString("dd/MM/yyyy"));
               Parameters[4] = new Microsoft.Reporting.WinForms.ReportParameter("MBL", (F_MBL == null ? "-" : F_MBL));
               Parameters[5] = new Microsoft.Reporting.WinForms.ReportParameter("HBL", (F_HBL == null ? "-" : F_HBL));

               Parameters[6] = new Microsoft.Reporting.WinForms.ReportParameter("TipoEntidad", F_TIPE_Codigo_Text);
               Parameters[7] = new Microsoft.Reporting.WinForms.ReportParameter("Entidad", String.IsNullOrEmpty(F_ENTC_Codigo_Text) ? "-" : F_ENTC_Codigo_Text);
               Parameters[8] = new Microsoft.Reporting.WinForms.ReportParameter("MostrarPendientes", F_SoloMostrarPendientes ? "Mostrar Solo Pendientes" : "-");

               Parameters[9] = new Microsoft.Reporting.WinForms.ReportParameter("lblFechaDesde", String.Format(_tfdesde, F_lblFecha));
               Parameters[10] = new Microsoft.Reporting.WinForms.ReportParameter("lblFechaHasta", String.Format(_tfhasta, F_lblFecha));
               Parameters[11] = new Microsoft.Reporting.WinForms.ReportParameter("TipoDetraccion", F_TIPO_CodDetrac_Text);

               String _TRegistro = "";
               if (String.IsNullOrEmpty(F_TipoRegistro)) { _TRegistro = "Por Cobrar"; }
               else { _TRegistro = F_TipoRegistro.Equals("I") ? "Por Cobrar" : "Por Pagar"; }

               Parameters[12] = new Microsoft.Reporting.WinForms.ReportParameter("Por", _TRegistro);
               Parameters[13] = new Microsoft.Reporting.WinForms.ReportParameter("Viaje", F_NVIA_NroViaje != null ? F_NVIA_NroViaje : "-");

               //Visualizador rpt = new Visualizador(_titulo, ReportPath, RepDetalle, Parameters);
               //rpt.StartPosition = FormStartPosition.CenterScreen;
               //rpt.Imprimir();
               //rpt.ShowDialog();
               Visualizador _impresion = new Visualizador("", ReportPath, rds, Parameters, x_subreports, null) { StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen };
               _impresion.Imprimir();
               _impresion.ShowDialog();

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
