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
    public class OPE006Presenter
    {
        #region [ Variables ]
        public String Title = "Consulta de Servicios";
        public String CUS = "OPE006";
        #endregion

        #region [ Contrusctor ]
        public OPE006Presenter(IUnityContainer x_container, IOPE006LView x_lview)
        {
            try
            {
                this.ContainerService = x_container;
                Session = this.ContainerService.Resolve<ISessionService>();
                this.LView = x_lview;
                //this.MView = x_mview;
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

        public IOPE006LView LView { get; set; }
        //public ICOM001MView MView { get; set; }

        public Microsoft.Reporting.WinForms.ReportDataSource RepDataSource { get; set; }
        public String ReportPath { get; set; }
        public Microsoft.Reporting.WinForms.ReportParameter[] Parameters { get; set; }
        #endregion

        #region [ Metodos ]

        public void CargarReporte(String x_TipoConsulta, String x_CONSTabRGM, String x_CONSCodRGM, Nullable<DateTime> x_FechaInicio, Nullable<DateTime> x_FechaFin)
        {
            try
            {

                System.Data.DataTable DTConultaServicio = new System.Data.DataTable();
                ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_TabRGM", FilterValue = x_CONSTabRGM, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_CodRGM", FilterValue = x_CONSCodRGM, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmNVIA_FecETA_ETD_Ini", FilterValue = x_FechaInicio, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmNVIA_FecETA_ETD_Fin", FilterValue = x_FechaFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                DTConultaServicio = Client.GetDTAnexos("COM_NVIASS_Consulta_Correlativo", _listFilters);

                if (DTConultaServicio != null && DTConultaServicio.Rows.Count > 0)
                {

                    ReportPath = System.Windows.Forms.Application.StartupPath + @"\Reportes\rptOPE006ConsultarCorrelativos.rdlc";
                    RepDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
                    RepDataSource.Name = "DTConsultarCorrelativos";
                    RepDataSource.Value = DTConultaServicio;

                    this.Parameters = new Microsoft.Reporting.WinForms.ReportParameter[1];
                    Parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("TReporte", x_TipoConsulta);

                    LView.ShowItems();
                }
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron resultados."); }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando la consulta.", ex); }
        }

        #endregion
    }
}
