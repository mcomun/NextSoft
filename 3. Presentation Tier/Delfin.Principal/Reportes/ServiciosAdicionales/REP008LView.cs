using System;
using System.Drawing;
using System.Windows.Forms;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls.UI;

namespace Delfin.Principal
{
    public partial class REP008LView : UserControl, IREP008LView
    {
        #region [ Variables ]

        #endregion

        #region [ Formulario ]
        public REP008LView(RadPageViewPage x_tabPageControl)
        {
            InitializeComponent();
            try
            {
                TabPageControl = x_tabPageControl;
                btnReporte.Click +=btnReporte_Click;
                btnDeshacer.Click += btnDeshacer_Click;
                TitleView.FormClose += TitleView_FormClose;
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Titulo, Mensajes.ConstructorView, ex); }
        }
        #endregion

        #region [ Propiedades ]
        public RadPageViewPage TabPageControl { get; set; }
        public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
        public REP008Presenter Presenter { get; set; }

        #endregion

        #region [ IPROC008LView ]
        public void LoadFilters()
        {
            try
            {
                Presenter.FechaEmisionIni = mdtFecDesde.NSFecha != null ? mdtFecDesde.NSFecha.Value : (DateTime?)null;
                Presenter.FechaEmisionFin = mdtFecHasta.NSFecha != null ? mdtFecHasta.NSFecha.Value : (DateTime?)null;
                Presenter.ENTC_CodigoFiltro = EntidadAyudaCliente.Value != null ? EntidadAyudaCliente.Value.ENTC_Codigo : (int?)null;
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
                mdtFecDesde.NSFecha = DateTime.Now;
                mdtFecHasta.NSFecha = DateTime.Now;
                EntidadAyudaCliente.ClearValue();
                //entidad1.ContainerService = Presenter.ContainerService;
                EntidadAyudaCliente.ContainerService = Presenter.ContainerService;
                //AyudaCliente.ContainerService = Presenter.ContainerService;
                if (!string.IsNullOrEmpty(Presenter.TipoReporte) )
                {
                    TitleView.Caption = Presenter.TipoReporte.Equals("Transporte") ? "Servicios Adicionales Transporte" : "Servicios Adicionales Aduanero";
                }
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
                mdtFecDesde.NSFecha = DateTime.Now.AddMonths(-1);
                mdtFecHasta.NSFecha = DateTime.Now.AddMonths(2);
                EntidadAyudaCliente.ClearValue();
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
            LoadFilters();
            Presenter.Imprimir();
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
