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
    public class OPE005Presenter
    {
        #region [ Variables ]
        public String Title = "Consulta de Servicios";
        public String CUS = "OPE005";
        #endregion

        #region [ Contrusctor ]
        public OPE005Presenter(IUnityContainer x_container, IOPE005LView x_lview)
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

        public IOPE005LView LView { get; set; }
        //public ICOM001MView MView { get; set; }

        public Microsoft.Reporting.WinForms.ReportDataSource RepDataSource { get; set; }
        public String ReportPath { get; set; }
        public Microsoft.Reporting.WinForms.ReportParameter[] Parameters { get; set; }
        #endregion

        #region [ Metodos ]

        public void CargarReporte(String x_TipoConsulta, String x_NumeroOV, Nullable<Int32> x_NumeroViaje, Boolean x_ChangeControl)
        {
            try
            {

                System.Data.DataTable DTConultaServicio = new System.Data.DataTable();
                ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchNVIA_Codigo", FilterValue = x_NumeroViaje, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 50 });
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCCOT_NumDoc", FilterValue = x_NumeroOV, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitSCOT_ChageControl", FilterValue = x_ChangeControl, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 4 });
                DTConultaServicio = Client.GetDTAnexos("COM_SCOTSS_Consulta_Servicios", _listFilters);

                if (DTConultaServicio != null && DTConultaServicio.Rows.Count > 0)
                {
                    //Si solo tiene una columna es el mensaje de Error
                    if (DTConultaServicio.Columns["MENSAJE_ERROR"] != null)
                    {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Faltan ingresar Tipo de Cambio",DTConultaServicio.Rows[0]["MENSAJE_ERROR"].ToString()); 
                    }
                    else
                    {
                        ReportPath = System.Windows.Forms.Application.StartupPath + @"\Reportes\rptOPE005ConsultaServicios.rdlc";
                        RepDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
                        RepDataSource.Name = "DTConsultaServicios";
                        RepDataSource.Value = DTConultaServicio;

                        this.Parameters = new Microsoft.Reporting.WinForms.ReportParameter[1];
                        Parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("TReporte", x_TipoConsulta);

                        LView.ShowItems();
                    }
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
