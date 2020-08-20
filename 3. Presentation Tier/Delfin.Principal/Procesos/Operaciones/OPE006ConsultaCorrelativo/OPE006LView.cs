using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace Delfin.Principal
{
    public partial class OPE006LView : UserControl, IOPE006LView
    {
        #region [ Variables ]

        #endregion

        #region [ Formulario ]

        public OPE006LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
        {
            InitializeComponent();
            try
            {
                TabPageControl = x_tabPageControl;
                btnBuscar.Click += btnBuscar_Click;
                btnDeshacer.Click += btnDeshacer_Click;

                TitleView.FormClose += new EventHandler(View_FormClose);
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al crear la vista.", ex); }
        }

        #endregion

        #region [ Propiedades ]
        public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
        public OPE006Presenter Presenter { get; set; }
        public BindingSource BSItems { get; set; }
        #endregion

        #region [ IOPE006LView ]
        public void LoadView()
        {
            try
            {
                CONS_CodRGM.LoadControl(Presenter.ContainerService, "Tipos de Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
        }
        public void ShowItems()
        {
            try
            {
                rvwReporte.LocalReport.DataSources.Clear();
                rvwReporte.LocalReport.DataSources.Add(this.Presenter.RepDataSource);
                rvwReporte.LocalReport.ReportPath = this.Presenter.ReportPath;
                rvwReporte.LocalReport.SetParameters(this.Presenter.Parameters);
                rvwReporte.LocalReport.Refresh();
                rvwReporte.RefreshReport();
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
        }
        #endregion

        #region [ Metodos ]
        private void Buscar()
        {
            try
            {
                String _Tipo_Consulta = "CORRELATIVO DE NAVE-VIAJE";
                String _CONS_TabRGM = null;
                String _CONS_CodRGM = null;
                Nullable<DateTime> _Fecha_Inicio = null;
                Nullable<DateTime> _Fecha_Fin = null;
                if (CONS_CodRGM.ConstantesSelectedItem != null)
                {
                    _CONS_TabRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
                    _CONS_CodRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
                }
                _Fecha_Inicio = mdtFecInicio.NSFecha;
                _Fecha_Fin = mdtFecFin.NSFecha;
                Presenter.CargarReporte(_Tipo_Consulta, _CONS_TabRGM, _CONS_CodRGM, _Fecha_Inicio, _Fecha_Fin);
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Buscar al reporte.", ex); }
        }
        private void Deshacer()
        {
            try
            {
                CONS_CodRGM.ConstantesSelectedValue = null;
                mdtFecInicio.NSFecha = null;
                mdtFecFin.NSFecha = null;
                rvwReporte.Clear();
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al limpiar al reporte.", ex); }
        }

        #endregion

        #region [ Eventos ]
        private void btnBuscar_Click(object sender, EventArgs e)
        { Buscar(); }
        private void btnDeshacer_Click(object sender, EventArgs e)
        { Deshacer(); }
        #endregion

        #region [ IFormClose ]
        private void View_FormClose(object sender, EventArgs e)
        {
            if (CloseForm != null)
            {
                //BusinessLogic.Colecciones.Inicializar(Presenter.Container);
                CloseForm(null, new Infrastructure.Client.FormClose.FormCloseEventArgs(this.TabPageControl, Presenter.CUS));
            }
        }
        public event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
        #endregion
    }
}
