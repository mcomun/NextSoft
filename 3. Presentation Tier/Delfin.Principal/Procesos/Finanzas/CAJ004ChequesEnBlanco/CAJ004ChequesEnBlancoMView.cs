using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delfin.Controls;
using Infrastructure.Aspect.Collections;

namespace Delfin.Principal
{
   public partial class CAJ004ChequesEnBlancoMView : Form, ICAJ004ChequesEnBlancoMView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public CAJ004ChequesEnBlancoMView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += CAJ004ChequesEnBlancoMView_FormClosed;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;

            this.Load += CAJ004ChequesEnBlancoMView_Load;

            txtMOVI_OrdenDe.MaxLength = 100;
            txtMOVI_Numero.MaxLength = 15;
            txtMOVI_Codigo.Enabled = false;
            txtMOVI_Responsable.MaxLength = 50;
            txtMOVI_Numero.ReadOnly = true;

            cmbTIPO_CodMND.Enabled = false;

            txaCUBA_Codigo.SelectedItemCuentaBancariaChanged += txaCUBA_Codigo_SelectedItemCuentaBancariaChanged;
            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;
            cmbTIPO_CodMOV.Enabled = false;
            label8.Enabled = false;

            txtMOVI_Codigo.Tag = "MOVI_CodigoMSGERROR";
            txaCUBA_Codigo.Tag = "CUBA_CodigoMSGERROR";
            txaENTC_Codigo.Tag = "ENTC_CodigoMSGERROR";
            txtMOVI_Numero.Tag = "MOVI_NumeroMSGERROR";
            txtMOVI_OrdenDe.Tag = "MOVI_OrdenDeMSGERROR";
            txnMOVI_TipoCambio.Tag = "MOVI_TipoCambioMSGERROR";
            dtpMOVI_FecVigencia.Tag = "MOVI_FecVigenciaMSGERROR";
            txtMOVI_Responsable.Tag = "MOVI_ResponsableMSGERROR";
            txnMOVI_MontoLimite.Tag = "MOVI_MontoLimiteMSGERROR";
            DTPMOVI_FecEmision.Tag = "MOVI_FecEmisionMSGERROR";

            DTPMOVI_FecEmision.NSFecha = DateTime.Now;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      private void CAJ004ChequesEnBlancoMView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }

      private void CAJ004ChequesEnBlancoMView_Load(object sender, EventArgs e)
      {

      }
      #endregion

      #region [ Propiedades ]
      public CAJ004ChequesEnBlancoPresenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }

      #endregion

      #region [ ICOM007MView ]
      public void LoadView()
      {
         try
         {
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, TiposEntidad.TIPE_Proveedor, null, null, true);
            txaCUBA_Codigo.LoadControl(Presenter.ContainerService, "Ayuda Cuenta Bancaria", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Presenter.Session.UserName);

            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Moneda", "MND", "< Sel. Moneda>", ListSortDirection.Ascending);
            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo de Entidad", "< Sel. Tipo de Entidad >", ListSortDirection.Ascending);

            
            //String[] _tipos = 

            cmbTIPO_CodMOV.LoadControl(Presenter.ListTiposMOV, "Ayuda Movimiento", "< Sel. Tipo Movimiento >", ListSortDirection.Ascending);
            cmbTIPO_CodMOV.Enabled = true;
            
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      public void ClearItem()
      {
         try
         {
            errorProviderMovimiento.Clear();

            #region [ Datos Generales ]

            txtMOVI_Codigo.Clear();
            txtMOVI_Numero.Clear();
            txtMOVI_OrdenDe.Clear();
            txaCUBA_Codigo.Clear();
            txaENTC_Codigo.Clear();
            cmbTIPO_CodMND.SelectedIndex = 0;
            //DTPMOVI_FecEmision.NSClear();
            txnMOVI_TipoCambio.Clear();

            #endregion

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ClearItem.", ex); }
      }
      public void GetItem()
      {
         try
         {
            errorProviderMovimiento.Clear();

            if (!String.IsNullOrEmpty(txtMOVI_Numero.Text)) { Presenter.Item.MOVI_Numero = txtMOVI_Numero.Text; } else { Presenter.Item.MOVI_Numero = null; }
            if (txaENTC_Codigo.SelectedItem != null)
            {
               Presenter.Item.ENTC_Codigo = txaENTC_Codigo.SelectedItem.ENTC_Codigo;
               Presenter.Item.TIPE_Codigo =
               Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(TiposEntidad.TIPE_Cliente);
            }
            else { Presenter.Item.ENTC_Codigo = null; }
            if (DTPMOVI_FecEmision.NSFecha.HasValue) { Presenter.Item.MOVI_FecEmision = DTPMOVI_FecEmision.NSFecha; } else { Presenter.Item.MOVI_FecEmision = null; }
            if (txaCUBA_Codigo.SelectedItem != null) { Presenter.Item.CUBA_Codigo = txaCUBA_Codigo.SelectedItem.CUBA_Codigo; } else { Presenter.Item.CUBA_Codigo = null; }
            if (txnMOVI_TipoCambio.Value != 0) { Presenter.Item.MOVI_TipoCambio = txnMOVI_TipoCambio.Value; } else { Presenter.Item.MOVI_TipoCambio = null; }
            if (!String.IsNullOrEmpty(txtMOVI_OrdenDe.Text)) { Presenter.Item.MOVI_OrdenDe = txtMOVI_OrdenDe.Text; } else { Presenter.Item.MOVI_OrdenDe = null; }
            if (dtpMOVI_FecVigencia.NSFecha.HasValue) { Presenter.Item.MOVI_FecVigencia = dtpMOVI_FecVigencia.NSFecha; } else { Presenter.Item.MOVI_FecVigencia = null; }
            if (!String.IsNullOrEmpty(txtMOVI_Responsable.Text)) { Presenter.Item.MOVI_Responsable = txtMOVI_Responsable.Text; } else { Presenter.Item.MOVI_Responsable = null; }
            if (txnMOVI_MontoLimite.Value != 0) { Presenter.Item.MOVI_MontoLimite = txnMOVI_MontoLimite.Value; } else { Presenter.Item.MOVI_MontoLimite = null; }
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null) { Presenter.Item.TIPE_Codigo = cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo; } else { Presenter.Item.TIPE_Codigo = null; }
            if (cmbTIPO_CodMOV.TiposSelectedItem != null) { Presenter.Item.TIPO_CodMOV = cmbTIPO_CodMOV.TiposSelectedItem.TIPO_CodTipo; } else { Presenter.Item.TIPO_CodMOV = null; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en GetItem.", ex); }
      }
      public void SetItem()
      {
         try
         {
            EnabledItem();

            if (Presenter.Item != null)
            {
               if (Presenter.Item.MOVI_Codigo > 0) { txtMOVI_Codigo.Text = Presenter.Item.MOVI_Codigo.ToString(); }
               if (!String.IsNullOrEmpty(Presenter.Item.MOVI_Numero))
               {
                  txtMOVI_Numero.Text = Presenter.Item.MOVI_Numero;
               }
               if (Presenter.Item.TIPE_Codigo.HasValue) { cmbTIPE_Codigo.SelectedValue = Presenter.Item.TIPE_Codigo.Value; }
               if (Presenter.Item.ENTC_Codigo != null) { txaENTC_Codigo.SetEntidad(Presenter.Item.ENTC_Codigo); }
               if (Presenter.Item.CUBA_Codigo != null)
               {
                  txaCUBA_Codigo.SelectedItemCuentaBancariaChanged -= txaCUBA_Codigo_SelectedItemCuentaBancariaChanged;
                  txaCUBA_Codigo.SetCuentaBancaria(Presenter.Item.EMPR_Codigo, Presenter.Item.CUBA_Codigo);
                  if (txaCUBA_Codigo.SelectedItem != null) { cmbTIPO_CodMND.TiposSelectedValue = txaCUBA_Codigo.SelectedItem.TIPO_CodMND; }
                  txaCUBA_Codigo.SelectedItemCuentaBancariaChanged += txaCUBA_Codigo_SelectedItemCuentaBancariaChanged;
               }
               if (Presenter.Item.MOVI_TipoCambio != null) { txnMOVI_TipoCambio.Value = Presenter.Item.MOVI_TipoCambio.Value; }
               if (!String.IsNullOrEmpty(Presenter.Item.MOVI_OrdenDe)) { txtMOVI_OrdenDe.Text = Presenter.Item.MOVI_OrdenDe; }
               if (Presenter.Item.MOVI_FecEmision != null) { DTPMOVI_FecEmision.NSFecha = Presenter.Item.MOVI_FecEmision; }
               if (Presenter.Item.MOVI_FecVigencia.HasValue) { dtpMOVI_FecVigencia.NSFecha = Presenter.Item.MOVI_FecVigencia; }
               if (!String.IsNullOrEmpty(Presenter.Item.MOVI_Responsable)) { txtMOVI_Responsable.Text = Presenter.Item.MOVI_Responsable; }
               if (Presenter.Item.MOVI_MontoLimite.HasValue) { txnMOVI_MontoLimite.Value = Presenter.Item.MOVI_MontoLimite.Value; }
               if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodMOV)) { cmbTIPO_CodMOV.SelectedValue = Presenter.Item.TIPO_CodMOV; }
            }
            else { throw new Exception("No puede setear los valores en los controles"); }

            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en SetItem.", ex); }
      }
      private void EnabledItem()
      {
         try
         {

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en EnabledItem.", ex); }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Movimiento>.Validate(Presenter.Item, this, errorProviderMovimiento);
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, revise los detalles.", Presenter.Item.MensajeError);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }
      #endregion

      #region [ Metodos ]

      #endregion

      #region [ Metodos Documentos ]

      #endregion

      #region [ Eventos ]
      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Guardar(true))
            {
               this.FormClosing -= MView_FormClosing;
               errorProviderMovimiento.Dispose();
               Presenter.Actualizar();
               this.Close();
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se completo el proceso de guardar."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex); }
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            this.FormClosing -= MView_FormClosing;
            errorProviderMovimiento.Dispose();
            if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
            {
               if (Presenter.GuardarCambios() != System.Windows.Forms.DialogResult.Cancel)
               { this.Close(); }
               else
               { this.FormClosing += MView_FormClosing; }
            }
            else
            { this.Close(); }
            Closing = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }

      private void MView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            if (Closing != true)
            {
               this.FormClosing -= MView_FormClosing;
               if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
               {
                  if (Presenter.GuardarCambios() == System.Windows.Forms.DialogResult.Cancel)
                  {
                     e.Cancel = true;
                     this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
                  }
                  else
                  { Presenter.Actualizar(); }
               }
               else
               { Presenter.Actualizar(); }
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }

      private void txaCUBA_Codigo_SelectedItemCuentaBancariaChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaCUBA_Codigo.SelectedItem != null)
            {
               cmbTIPO_CodMND.TiposSelectedValue = txaCUBA_Codigo.SelectedItem.TIPO_CodMND;
               if (Presenter.setNroCheque(txaCUBA_Codigo.SelectedItem.CUBA_Codigo,
                   Presenter.Item.TIPO_Movimiento.TIPO_Desc2, Presenter.Item.TIPO_Movimiento.TIPO_Num1.Value))
               {
                  txtMOVI_Numero.Text = (++Presenter.Item.ItemChequera.CHEQ_NroActual).ToString();
                  txtMOVI_Numero.ReadOnly = true;
                  btnGuardar.Enabled = true;
               }
               else
               {
                  //btnGuardar.Enabled = false;
                  txtMOVI_Numero.ReadOnly = false;
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title,
                      "No tiene definido para la cuenta bancaria una chequera.");
               }
            }
            else
            {
               cmbTIPO_CodMND.SelectedIndex = 0;
               txtMOVI_Numero.Clear();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar una cuenta bancaria.", ex); }
      }

      private void cmbTIPE_Codigo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
            {
               txaENTC_Codigo.Enabled = true;
               txaENTC_Codigo.TiposEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo);
               txaENTC_Codigo.Clear();
            }
            else { txaENTC_Codigo.Enabled = false; txaENTC_Codigo.Clear(); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cambiar el tipo de entidad.", ex); }
      }

      #endregion
   }
}