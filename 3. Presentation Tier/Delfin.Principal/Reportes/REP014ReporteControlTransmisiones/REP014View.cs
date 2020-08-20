using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.Collections;

namespace Delfin.Principal
{
    public partial class REP014View : Form, IREP014View
    {
        #region [ Variables ]

        #endregion

        #region [ Formulario ]
        public REP014View()
        {
            InitializeComponent();
            try
            {
                btnCargar.Click += btnCargar_Click;
                btnSalir.Click += btnSalir_Click;
                cmbCONS_CodRGM.SelectedIndexChanged += cmbCONS_CodRGM_SelectedIndexChanged;

                this.Load += OPE002View_Load;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
        }
        private void OPE002View_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region [ Propiedades ]
        public REP014Presenter Presenter { get; set; }
        #endregion

        #region [ IOPE002MView ]
        public void LoadView()
        {
            try
            {
                cmbCONS_CodRGM.LoadControl(Presenter.ContainerService, "Tabla de Regimen", "RGM", "< Seleccionar Regimen >", ListSortDirection.Ascending);
                mdtFECH_Inicio.NSFecha = new DateTime(Presenter.Fecha.Year, Presenter.Fecha.Month, 1);
                mdtFECH_Fin.NSFecha = mdtFECH_Inicio.NSFecha.Value.AddMonths(1).AddDays(-1);
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
        }
        #endregion

        #region [ Metodos ]

        #endregion

        #region [ Metodos Documentos ]

        #endregion

        #region [ Eventos ]
        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                String _CONS_TabRGM = null;
                String _CONS_CodRGM = null;
                Nullable<DateTime> _NVIA_FecETAETDInicio = null;
                Nullable<DateTime> _NVIA_FecETAETDFin = null;
                if (mdtFECH_Inicio.NSFecha != null && mdtFECH_Fin.NSFecha != null)
                {
                    _NVIA_FecETAETDInicio = mdtFECH_Inicio.NSFecha;
                    _NVIA_FecETAETDFin = mdtFECH_Fin.NSFecha;
                    if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
                    {
                        _CONS_TabRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
                        _CONS_CodRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
                    }
                    Presenter.Cargar(_CONS_TabRGM, _CONS_CodRGM, _NVIA_FecETAETDInicio, _NVIA_FecETAETDFin);
                }
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Filtros del Reportes", "Debe ingresar una Fecha de Inicio y Fin"); }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar.", ex); }
        }
        private void cmbCONS_CodRGM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
                {

                    if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
                    {
                        lblFECHA.Text = "Fecha ETA :";
                    }
                    if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Exportacion)
                    {
                        lblFECHA.Text = "Fecha Zarpe :";
                    }

                }
                else
                {
                    lblFECHA.Text = "Fecha ETA/Zarpe :";
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
        }
        #endregion
    }
}