using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delfin.Controls.Tipos;
using Delfin.Entities;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinForms.Controls;
using Telerik.WinControls.UI;
using Flujo = Delfin.Controls.Flujo;

namespace Delfin.Principal
{
  
    public partial class CAJ002IngresosEgresosFlujoDView : Form
    {

        #region [ Variables ]
        public enum TInicio
        {
            Nuevo = 0, Editar = 1
        }
        #endregion

        #region [ Propiedades ]
        public CAJ002IngresosEgresosPresenter Presenter { get; set; }
        public BindingSource BSItems { get; set; }
        public TInicio TipoInicio { get; set; }
        public Entities.MovimientoFlujo ItemMovimientoFlujo { get; set; }
        #endregion

        #region [ Formulario ]
        public CAJ002IngresosEgresosFlujoDView()
        {
            InitializeComponent();
            btnAceptar.Click += btnAceptar_Click;
            txaFlujo.SelectedItemFlujoChanged += txaFlujo_SelectedItemFlujoChanged;
            txaFlujo.AyudaClean += txaFlujo_AyudaClean;
            BSItems = new BindingSource();
        }
        public void LoadView(TInicio x_opcion)
        {
            try
            {
                cmbFLUJ_TipoFlujo.LoadControl("Tipos de Flujo", ComboBoxConstantes.OConstantes.TipoFlujo, "<Seleccionar Tipo>", ListSortDirection.Ascending);
                switch (Presenter.TMovimiento)
                {
                    case Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Ingresos:
                        txaFlujo.LoadControl(Presenter.ContainerService, "Tipos Flujo", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Flujo.TipoAyuda.Ingresos);

                            break;
                    case Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Egresos:
                        txaFlujo.LoadControl(Presenter.ContainerService, "Tipos Flujo", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Flujo.TipoAyuda.Egresos);

                            break;
                        default:
                            break;
                }
                SetItem();
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error iniciando", ex); }
        }
        public void GetItem()
        {
            try
            {
                if(ItemMovimientoFlujo!=null)
                {

                    if (txaFlujo.SelectedItem != null)
                    {
                        ItemMovimientoFlujo.FLUJ_Codigo = txaFlujo.SelectedItem.FLUJ_Codigo.ToString();
                        ItemMovimientoFlujo.FLUJ_Glosa = txaFlujo.SelectedItem.FLUJ_Glosa;
                    } else { ItemMovimientoFlujo.FLUJ_Codigo = null; }
                    if (txtPorcentaje.Value > 0) { ItemMovimientoFlujo.MFLU_Porcentaje = Convert.ToInt32(txtPorcentaje.Value); } else { ItemMovimientoFlujo.MFLU_Porcentaje = null; }
                    if (txtMonto.Value > 0) { ItemMovimientoFlujo.MFLU_Monto = Convert.ToDecimal(txtMonto.Value); } else { ItemMovimientoFlujo.MFLU_Monto = null; }
                
                }

            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error iniciando", ex); }
        }
        public void SetItem()
        {
            try
            {
                
                if (ItemMovimientoFlujo != null)
                {
                    if (ItemMovimientoFlujo.MFLU_Item > 0) { txtCodigo.Text = ItemMovimientoFlujo.MFLU_Item.ToString(); }
                    if (ItemMovimientoFlujo.FLUJ_Codigo != null)
                    {
                       
                        txaFlujo.SetCuentaBancaria(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, ItemMovimientoFlujo.FLUJ_Codigo);
                    }
                    if (ItemMovimientoFlujo.MFLU_Porcentaje.HasValue) { txtPorcentaje.Value = Convert.ToInt32(ItemMovimientoFlujo.MFLU_Porcentaje); }
                    if (ItemMovimientoFlujo.MFLU_Monto.HasValue) { txtMonto.Value = Convert.ToDecimal(ItemMovimientoFlujo.MFLU_Monto); }
                    
                }

            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error iniciando", ex); }
        }

        public void ShowValidation()
        {
            try
            {
                Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", ItemMovimientoFlujo.MensajeError, Dialogos.Boton.Detalles);
                FormShowErrorProvider<Entities.MovimientoFlujo>.Validate(ItemMovimientoFlujo, this, errorProviderMovimientoFlujo);
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
        }
        #endregion

       

        #region [ Eventos ]
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                GetItem();
                if (ItemMovimientoFlujo.Validar())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else { ShowValidation(); }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error", ex); }
        }
        private void txaFlujo_SelectedItemFlujoChanged(object sender, EventArgs e)
        {
            try
            {
                if (txaFlujo.SelectedItem != null)
                { cmbFLUJ_TipoFlujo.ConstantesSelectedValue = txaFlujo.SelectedItem.FLUJ_TipoFlujo; }
            }
            catch (Exception)
            { }
        }
        private void txaFlujo_AyudaClean(object sender, EventArgs e)
        {
            try
            {
                cmbFLUJ_TipoFlujo.SelectedIndex = 0;
            }
            catch (Exception)
            { }
        }
        #endregion
    }

     

      

}
