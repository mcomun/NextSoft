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
    public class REP008Presenter
    {
        #region [ Variables ]
        public String Titulo = "Servicios Adicionales";
        public String CUS = "REP008";
        #endregion

        #region [ Propiedades ]
        public IUnityContainer ContainerService { get; set; }
        public ISessionService Session { get; set; }
        public Delfin.ServiceContracts.IDelfinServices Client { get; set; }

        public IREP008LView LView { get; set; }
        public IPRO008RMView MView { get; set; }

        public Int32? ENTC_CodigoFiltro { get; set; }
        public String TipoReporte { get; set; }
        public DateTime? FechaEmisionIni { get; set; }
        public DateTime? FechaEmisionFin { get; set; }
        public String MensajeError { get; set; }

        public DataSet DSReporte { get; set; }
        public ReportDataSource RepDataSource { get; set; }

        public String ReportPath { get; set; }
        public ReportParameter[] Parameters { get; set; }


        #endregion

        #region [ Constructor ]
        public REP008Presenter(IUnityContainer x_container, IREP008LView x_lview, IPRO008RMView x_mview)
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
                    if (!String.IsNullOrEmpty(TipoReporte))
                    {
                        DSReporte = Client.GetAllServiciosAdicionalesReporte(ENTC_CodigoFiltro, FechaEmisionIni.Value, FechaEmisionFin.Value, TipoReporte); 
                    }
                }
                else
                {
                    LView.ShowValidation();
                    return;
                }
                if (DSReporte == null) return;
                if (DSReporte.Tables.Count < 1 && DSReporte.Tables[0].Rows.Count == 0)
                { Dialogos.MostrarMensajeInformacion(Titulo, "No se encontraron coincidencias."); return; }
                ReportPath = TipoReporte.Equals("Transporte") ? Application.StartupPath + @"\Reportes\RptServiciosAdicionales.rdlc" : Application.StartupPath + @"\Reportes\RptServiciosAdicionalesAduana.rdlc";
                RepDataSource = new ReportDataSource(TipoReporte.Equals("Transporte") ? "DsServiciosAdicionales" : "DsServiciosAdicionalesAduana", DSReporte.Tables[0]);
                Parameters = new ReportParameter[1];
                Parameters[0] = new ReportParameter("TipoReporte", TipoReporte);
                MView.ShowReporte();
                ((PRO008RMView)MView).ShowDialog();
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

        #endregion
    }
}
