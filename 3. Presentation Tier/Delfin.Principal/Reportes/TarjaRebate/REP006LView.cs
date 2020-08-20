using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Delfin.Entities;
using Delfin.Principal.Properties;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace Delfin.Principal
{
    public partial class REP006LView : UserControl, IREP006LView
    {
        #region [ Variables ]

        #endregion

        #region [ Formulario ]
        public REP006LView(RadPageViewPage x_tabPageControl)
        {
            InitializeComponent();
            try
            {
                TabPageControl = x_tabPageControl;
                btnDeshacer.Click += btnDeshacer_Click;
                btnReporte.Click += btnReporte_Click;
                TitleView.FormClose += TitleView_FormClose;
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Titulo, Mensajes.ConstructorView, ex); }
        }
        #endregion

        #region [ Propiedades ]
        public RadPageViewPage TabPageControl { get; set; }
        public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
        public REP006Presenter Presenter { get; set; }

        #endregion

        #region [ IPROC006LView ]
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
                entidad1.ContainerService = Presenter.ContainerService;

                Presenter.ENTC_CodigoFiltro = null;
                TxtNroOperacion.Clear();
                txtHBL.Clear();
                mdtFecDesde.NSFecha = DateTime.Now;
                mdtFecHasta.NSFecha = DateTime.Now;
                entidad1.ClearValue();
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
                mdtFecDesde.NSFecha = DateTime.Now;
                mdtFecHasta.NSFecha = DateTime.Now;
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
