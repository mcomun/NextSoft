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
    public partial class OPE005LView : UserControl, IOPE005LView
    {
        #region [ Variables ]

        #endregion

        #region [ Formulario ]

        public OPE005LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
        {
            InitializeComponent();
            try
            {
                TabPageControl = x_tabPageControl;
                cmbTipoConsulta.SelectedIndexChanged += cmbTipoConsulta_SelectedIndexChanged;
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
        public OPE005Presenter Presenter { get; set; }
        public BindingSource BSItems { get; set; }
        #endregion

        #region [ IOPE005LView ]
        public void LoadView()
        {
            try
            {
                cmbTipoConsulta.AddComboBoxItem(1, "ORDEN DE VENTA", true);
                cmbTipoConsulta.AddComboBoxItem(2, "NAVE VIAJE");
                cmbTipoConsulta.LoadComboBox("< Seleccionar Consulta >");
                txaNVIA_NroViaje.LoadControl(Presenter.ContainerService);
                txaNVIA_NroViaje.Visible = false;
                ckcChangeControl.Checked = false;
                lblNumero.Visible = false;
                txtNumero.Visible = false;
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
                String _Tipo_Consulta = null;
                String _Numero_OV = null;
                Nullable<Int32> _Nave_Viaje = null;
                Boolean _Change_Control = false;
                if (cmbTipoConsulta.SelectedValue != null)
                {
                    Int32 x = Convert.ToInt32(cmbTipoConsulta.SelectedValue);
                    switch (x)
                    {
                        case 1:
                            if (!String.IsNullOrEmpty(txtNumero.Text))
                            {
                                _Numero_OV = txtNumero.Text;
                                _Tipo_Consulta = String.Format("CONSULTA POR ORDEN DE VENTA NÚMERO {0}", _Numero_OV);
                            }
                            else
                            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe Ingresar el Número de OV"); return; }
                            break;
                        case 2:
                            if (txaNVIA_NroViaje.Value != null)
                            {
                                _Nave_Viaje = (txaNVIA_NroViaje.Value as Entities.NaveViaje).NVIA_Codigo;
                                _Tipo_Consulta = String.Format("CONSULTA POR NAVE VIAJE NÚMERO {0}", (txaNVIA_NroViaje.Value as Entities.NaveViaje).NVIA_NroViaje);
                            }
                            else
                            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe Ingresar el Número de Viaje"); return; }
                            break;
                            
                    }
                    _Change_Control = ckcChangeControl.Checked;
                    Presenter.CargarReporte(_Tipo_Consulta, _Numero_OV, _Nave_Viaje, _Change_Control);
                }
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar el Tipo de Consulta"); }

            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Buscar al reporte.", ex); }
        }
        private void Deshacer()
        {
            try
            {
                rvwReporte.Clear();
                txaNVIA_NroViaje.ClearValue();
                cmbTipoConsulta.SelectedIndex = -1;
                ckcChangeControl.Checked = false;
                txtNumero.Text = String.Empty;
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
        private void cmbTipoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoConsulta.SelectedValue == null)
                {
                    this.lblNumero.Visible = false;
                    this.tableLayoutPanel1.Controls.Add(this.txaNVIA_NroViaje, 7, 0);
                    this.txaNVIA_NroViaje.Visible = false;
                    this.tableLayoutPanel1.Controls.Add(this.txtNumero, 5, 0);
                    this.txtNumero.Visible = false;
                }
                else
                {
                    Int32 x = Convert.ToInt32(cmbTipoConsulta.SelectedValue);
                    switch (x)
                    {
                        case 1:
                            this.lblNumero.Text = "Número de OV :";
                            this.lblNumero.Visible = true;
                            this.tableLayoutPanel1.Controls.Add(this.txaNVIA_NroViaje, 7, 0);
                            this.txaNVIA_NroViaje.Visible = false;
                            this.tableLayoutPanel1.Controls.Add(this.txtNumero, 4, 0);
                            this.txtNumero.Visible = true;
                            break;
                        case 2:
                            this.lblNumero.Text = "Número de Viaje :";
                            this.lblNumero.Visible = true;
                            this.tableLayoutPanel1.Controls.Add(this.txtNumero, 5, 0);
                            this.txtNumero.Visible = false;
                            this.tableLayoutPanel1.Controls.Add(this.txaNVIA_NroViaje, 4, 0);
                            this.txaNVIA_NroViaje.Visible = true;
                            break;
                        default:
                            this.lblNumero.Visible = false;
                            this.tableLayoutPanel1.Controls.Add(this.txaNVIA_NroViaje, 7, 0);
                            this.txaNVIA_NroViaje.Visible = false;
                            this.tableLayoutPanel1.Controls.Add(this.txtNumero, 5, 0);
                            this.txtNumero.Visible = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
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
