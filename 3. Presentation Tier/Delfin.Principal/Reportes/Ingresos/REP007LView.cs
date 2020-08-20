using System;
using System.Drawing;
using System.Windows.Forms;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls.UI;
using Microsoft.Reporting.WinForms;

namespace Delfin.Principal
{
    public partial class REP007LView : UserControl, IREP007LView
    {
        #region [ Variables ]

        #endregion

        #region [ Formulario ]
        public REP007LView(RadPageViewPage x_tabPageControl)
        {
            InitializeComponent();
            try
            {
                TabPageControl = x_tabPageControl;
                btnDeshacer.Click += btnDeshacer_Click;
                btnReporteResumido.Click += btnReporte_Click;
                btnReporteDetallado.Click += btnReporteDetallado_Click;
                TitleView.FormClose += TitleView_FormClose;
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Titulo, Mensajes.ConstructorView, ex); }
        }
        #endregion

        #region [ Propiedades ]
        public RadPageViewPage TabPageControl { get; set; }
        public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
        public REP007Presenter Presenter { get; set; }

        #endregion
       
        #region [ IPROC007LView ]
        public void LoadFilters()
        {
            try
            {
                Presenter.FechaEmisionIni = mdtFecDesde.NSFecha != null ? mdtFecDesde.NSFecha.Value : (DateTime?)null;
                Presenter.FechaEmisionFin = mdtFecHasta.NSFecha != null ? mdtFecHasta.NSFecha.Value : (DateTime?)null;
                Presenter.NroOperacion = !String.IsNullOrEmpty(TxtNroOperacion.Text) ? TxtNroOperacion.Text : null;
                Presenter.HBLOperacion = !String.IsNullOrEmpty(txtHBL.Text) ? txtHBL.Text : null;
                Presenter.ENTC_CodigoFiltro = entidad1.Value != null ? entidad1.Value.ENTC_Codigo : (int?)null;
            }
            catch (Exception) { }
        }
        public void ShowValidation()
        {
            try
            {
                Dialogos.MostrarMensajeInformacion(Presenter.Titulo, "Faltan ingresar datos obligatorios: ", Presenter.MensajeError, Dialogos.Boton.Detalles);
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Titulo, Mensajes.ShowItems, ex); }
        }
        public void LoadView()
        {
            try
            {
                Presenter.ENTC_CodigoFiltro = null;
                TxtNroOperacion.Clear();
                txtHBL.Clear();
                mdtFecDesde.NSFecha = DateTime.Now;
                mdtFecHasta.NSFecha = DateTime.Now;
                entidad1.ClearValue();
                entidad1.ContainerService = Presenter.ContainerService;
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Titulo, Mensajes.LoadView, ex); }
        }
        #endregion

        #region [ Metodos ]
        private void Deshacer()
        {
            try
            {
                Presenter.ENTC_CodigoFiltro = null;
                TxtNroOperacion.Clear();
                txtHBL.Clear();
                mdtFecDesde.NSFecha = DateTime.Now.AddMonths(-1);
                mdtFecHasta.NSFecha = DateTime.Now.AddMonths(2);
                entidad1.ClearValue();
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Titulo, "Ha ocurrido un error al deshacer la vista.", ex); }
        }


        #endregion

        #region [ Eventos ]

        private void btnDeshacer_Click(object sender, EventArgs e)
        { Deshacer(); }
        void btnReporte_Click(object sender, EventArgs e)
        {
            Presenter.Imprimir("Resumido");
        }
        void btnReporteDetallado_Click(object sender, EventArgs e)
        {
            Presenter.Imprimir("Detallado");
        }
        public void ShowReporte()
        {
            try
            {
                RptImpresion.LocalReport.ReleaseSandboxAppDomain();
                RptImpresion.Reset();
                RptImpresion.ProcessingMode = ProcessingMode.Local;
                RptImpresion.LocalReport.DataSources.Clear();
                RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSource);
                RptImpresion.LocalReport.ReportPath = Presenter.ReportPath;
                //RptImpresion.LocalReport.SetParameters(Presenter.Parameters);
                RptImpresion.LocalReport.Refresh();
                RptImpresion.RefreshReport();
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Titulo, "Ha ocurrido un error de al mostrar el reporte.", ex); }
        }
        #endregion

        #region [ IFormClose ]
        private void TitleView_FormClose(object sender, EventArgs e)
        {
            if (CloseForm != null)
            {
                CloseForm(null, new FormCloseEventArgs(TabPageControl, Presenter.CUS));
            }
        }
        public event FormCloseEventArgs.FormCloseEventHandler CloseForm;
        #endregion
    }
}
