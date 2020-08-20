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
    public partial class OPE004View : Form, IOPE004View
    {
        #region [ Variables ]

        #endregion

        #region [ Formulario ]
        public OPE004View()
        {
            InitializeComponent();
            try
            {
                btnCargar.Click += btnCargar_Click;
                btnSalir.Click += btnSalir_Click;

                txaNVIA_Codigo.AyudaValueChanged += txaNVIA_Codigo_AyudaValueChanged;
                txaNVIA_NroViaje.AyudaValueChanged += txaNVIA_NroViaje_AyudaValueChanged;

                this.Load += OPE001RView_Load;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
        }

        private void OPE001RView_Load(object sender, EventArgs e)
        {}
        #endregion

        #region [ Propiedades ]
        public OPE004Presenter Presenter { get; set; }
        #endregion

        #region [ ICOM000MView ]
        public void LoadView()
        {
            try
            {
                this.txaNVIA_Codigo.LoadControl(Presenter.ContainerService);
                this.txaNVIA_NroViaje.LoadControl(Presenter.ContainerService);
                this.cmbTIPO_CodTRF.LoadControl(Presenter.ContainerService, "Tipos de Tráfico", "TRF", "< Seleccionar Tráfico >", ListSortDirection.Ascending);

                this.cmbTIPO_CodTRF.Visible = false;
                this.lblTIPO_CodTRF.Visible = false;
                this.tableDatosGenerales.SetColumnSpan(this.txtENTC_NomTransportista, 4);
                Presenter.LoadParameteres();
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
        }

        public void ShowValidation()
        {
            try
            {

            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
        }
        #endregion

        #region [ Metodos ]
        private void ClearDatosViaje()
        {
            try
            {
                txaNVIA_Codigo.AyudaValueChanged -= txaNVIA_Codigo_AyudaValueChanged;
                txaNVIA_NroViaje.AyudaValueChanged -= txaNVIA_NroViaje_AyudaValueChanged;

                txaNVIA_Codigo.ClearValue();
                txaNVIA_NroViaje.ClearValue();
                txtNAVE_Nombre.Text = String.Empty;
                txtENTC_NomTransportista.Text = string.Empty;
                cmbTIPO_CodTRF.TiposSelectedValue = null;

                txaNVIA_Codigo.AyudaValueChanged += txaNVIA_Codigo_AyudaValueChanged;
                txaNVIA_NroViaje.AyudaValueChanged += txaNVIA_NroViaje_AyudaValueChanged;
            }
            catch (Exception)
            { }
        }
        private void SetDatosViaje(Entities.NaveViaje ItemViaje)
        {
            try
            {
                txaNVIA_Codigo.AyudaValueChanged -= txaNVIA_Codigo_AyudaValueChanged;
                txaNVIA_NroViaje.AyudaValueChanged -= txaNVIA_NroViaje_AyudaValueChanged;

                txaNVIA_Codigo.LoadNaveViaje(ItemViaje.NVIA_Codigo);
                txaNVIA_NroViaje.LoadNaveViaje(ItemViaje.NVIA_Codigo);
                txtNAVE_Nombre.Text = ItemViaje.NAVE_Nombre;
                txtENTC_NomTransportista.Text = ItemViaje.ENTC_NomTransp;
                cmbTIPO_CodTRF.TiposSelectedValue = ItemViaje.TIPO_CodTRF;

                txaNVIA_Codigo.AyudaValueChanged += txaNVIA_Codigo_AyudaValueChanged;
                txaNVIA_NroViaje.AyudaValueChanged += txaNVIA_NroViaje_AyudaValueChanged;
            }
            catch (Exception)
            { }
        }
        #endregion

        #region [ Metodos Documentos ]

        #endregion

        #region [ Eventos ]
        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txaNVIA_NroViaje.Value != null && txaNVIA_NroViaje.Value is Entities.NaveViaje)
                {
                    if (rbtSDA.Checked)
                    { Presenter.Cargar(txaNVIA_Codigo.Value as Entities.NaveViaje, rgFormat.EditValue as string); }
                    else if (rbtTeledespacho.Checked)
                    { Presenter.CargarTeledespacho(txaNVIA_Codigo.Value as Entities.NaveViaje); }
                }
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar el Viaje"); }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex); }
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

        private void txaNVIA_NroViaje_AyudaValueChanged(object sender, EventArgs e)
        {
            if (txaNVIA_NroViaje.Value != null && txaNVIA_NroViaje.Value is Entities.NaveViaje)
            { SetDatosViaje(txaNVIA_NroViaje.Value as Entities.NaveViaje); }
            else
            { ClearDatosViaje(); }
        }
        private void txaNVIA_Codigo_AyudaValueChanged(object sender, EventArgs e)
        {
            if (txaNVIA_Codigo.Value != null && txaNVIA_Codigo.Value is Entities.NaveViaje)
            { SetDatosViaje(txaNVIA_Codigo.Value as Entities.NaveViaje); }
            else
            { ClearDatosViaje(); }
        }
        #endregion
    }
}