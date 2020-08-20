using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
   public partial class CAJ005TransferenciasMViewSmall : Form, ICAJ005TransferenciasMViewSmall
   {

      #region [ Variables ]

      #endregion

      #region [ Formulario ]

      public CAJ005TransferenciasMViewSmall()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += CAJ005TransferenciasMView_FormClosed;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;

            btnCalcular.Click += btnCalcular_Click;

            txtTRAN_Codigo.Tag = "TRAN_CodigoMSGERROR";
            dtpTRAN_Fecha.Tag = "TRAN_FechaMSGERROR";
            txtTRAN_Glosa.Tag = "TRAN_GlosaMSGERROR";

            txtTRAN_Glosa.MaxLength = 1000;
            txtTRAN_Codigo.Enabled = false;

            this.Load += CAJ005TransferenciasMView_Load;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      private void CAJ005TransferenciasMView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }

      private void CAJ005TransferenciasMView_Load(object sender, EventArgs e)
      {

      }
      #endregion

      #region [ Propiedades ]
      public CAJ005TransferenciasPresenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }


      #endregion

      #region [ ICAJ005TransferenciasMView ]
      public void LoadView()
      {
         try
         {
            txnIngresosDSol.Enabled = false;
            txnIngresosHSol.Enabled = false;
            txnEgresosDSol.Enabled = false;
            txnEgresosHSol.Enabled = false;

            txnIngresosDDol.Enabled = false;
            txnIngresosHDol.Enabled = false;
            txnEgresosDDol.Enabled = false;
            txnEgresosHDol.Enabled = false;

            txnGBancarioDDol.Enabled = false;
            txnGBancarioDSol.Enabled = false;
            txnGBancarioHDol.Enabled = false;
            txnGBancarioHSol.Enabled = false;

            txnDiferenciaDDol.ReadOnly = true;
            txnDiferenciaDSol.ReadOnly = true;
            txnDiferenciaHDol.ReadOnly = true;
            txnDiferenciaHSol.ReadOnly = true;

            txnTotalDDol.ReadOnly = true;
            txnTotalDSol.ReadOnly = true;
            txnTotalHDol.ReadOnly = true;
            txnTotalHSol.ReadOnly = true;

            cmbTIPO_CodMNDIngresos.Enabled = false;
            cmbTIPO_CodMNDEgresos.Enabled = false;
            cmbTIPO_CodMNDGBancario.Enabled = true;

            cmbTIPO_CodMNDIngresos.LoadControl(Presenter.ContainerService, "Ayuda Moneda", "MND", "< Sel.  Moneda>", ListSortDirection.Ascending);
            cmbTIPO_CodMNDEgresos.LoadControl(Presenter.ContainerService, "Ayuda Moneda", "MND", "< Sel.  Moneda>", ListSortDirection.Ascending);
            cmbTIPO_CodMNDGBancario.LoadControl(Presenter.ContainerService, "Ayuda Moneda", "MND", "< Sel.  Moneda>", ListSortDirection.Ascending);

            cmbTIPO_CodMNDIngresos.SelectedIndexChanged += cmbTIPO_CodMNDIngresos_SelectedIndexChanged;
            cmbTIPO_CodMNDEgresos.SelectedIndexChanged += cmbTIPO_CodMNDEgresos_SelectedIndexChanged;
            cmbTIPO_CodMNDGBancario.SelectedIndexChanged += cmbTIPO_CodMNDGBancario_SelectedIndexChanged;

            txaCUBA_NroCuentaIngresos.LoadControl(Presenter.ContainerService, "Ayuda de Cuentas Bancarias", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Presenter.Session.UserName);
            txaCUBA_NroCuentaEgresos.LoadControl(Presenter.ContainerService, "Ayuda de Cuentas Bancarias", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Presenter.Session.UserName);

            txaCUBA_NroCuentaIngresos.SelectedItemCuentaBancariaChanged += txaCUBA_NroCuentaIngresos_SelectedItemCuentaBancariaChanged;
            txaCUBA_NroCuentaEgresos.SelectedItemCuentaBancariaChanged += txaCUBA_NroCuentaEgresos_SelectedItemCuentaBancariaChanged;

            txnMOVI_TipoCambioEgresos.Value = Presenter.TipoCambio;
            txnMOVI_TipoCambioIngresos.Value = Presenter.TipoCambio;
            txnGBAN_TipoCambio.Value = Presenter.TipoCambio;


            txnIngresosDDol.LostFocus += txn_LostFocus;
            txnIngresosDSol.LostFocus += txn_LostFocus;
            txnIngresosHDol.LostFocus += txn_LostFocus;
            txnIngresosHSol.LostFocus += txn_LostFocus;

            txnEgresosDDol.LostFocus += txn_LostFocus;
            txnEgresosDSol.LostFocus += txn_LostFocus;
            txnEgresosHDol.LostFocus += txn_LostFocus;
            txnEgresosHSol.LostFocus += txn_LostFocus;

            txnGBancarioDDol.LostFocus += txn_LostFocus;
            txnGBancarioDSol.LostFocus += txn_LostFocus;
            txnGBancarioHDol.LostFocus += txn_LostFocus;
            txnGBancarioHSol.LostFocus += txn_LostFocus;

            txnMOVI_TipoCambioEgresos.LostFocus += txn_LostFocus;
            txnMOVI_TipoCambioIngresos.LostFocus += txn_LostFocus;
            txnGBAN_TipoCambio.LostFocus += txn_LostFocus;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }


      public void ClearItem()
      {
         try
         {
            errorProviderTransferencia.Clear();

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ClearItem.", ex); }
      }
      public void GetItem()
      {
         try
         {
            errorProviderTransferencia.Clear();

            if (Presenter.Item != null)
            {
               /*======================================================================================================================================*/
               if (dtpTRAN_Fecha.NSFecha.HasValue) { Presenter.Item.TRAN_Fecha = dtpTRAN_Fecha.NSFecha; }
               else { Presenter.Item.TRAN_Fecha = null; }
               if (!String.IsNullOrEmpty(txtTRAN_Glosa.Text)) { Presenter.Item.TRAN_Glosa = txtTRAN_Glosa.Text; }
               else { Presenter.Item.TRAN_Glosa = null; }

               /*======================================================================================================================================*/
               /* Ingresos */
               Presenter.MOVI_Ingresos.SetTipoMovimiento(Entities.Movimiento.TipoMovimiento.IngresosTransferenciaCuentasPropias);
               Presenter.MOVI_Ingresos.SetEstado(Entities.Movimiento.Estado.Ingresado);
               Presenter.MOVI_Ingresos.MOVI_FecEmision = Presenter.Item.TRAN_Fecha;
               Presenter.MOVI_Ingresos.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
               Presenter.MOVI_Ingresos.MOVI_Cheque = false;
               if (txaCUBA_NroCuentaIngresos.SelectedItem != null) { Presenter.MOVI_Ingresos.CUBA_Codigo = txaCUBA_NroCuentaIngresos.SelectedItem.CUBA_Codigo; }

               if (cmbTIPO_CodMNDIngresos.TiposSelectedItem != null)
               {
                  Presenter.MOVI_Ingresos.TIPO_CodMND = cmbTIPO_CodMNDIngresos.TiposSelectedItem.TIPO_CodTipo;

                  if (cmbTIPO_CodMNDIngresos.TiposSelectedItem.TIPO_CodTipo.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles)))
                  { Presenter.MOVI_Ingresos.MOVI_MontoDebe = txnIngresosDSol.Value; Presenter.MOVI_Ingresos.MOVI_MontoHaber = txnIngresosHSol.Value; }
                  else if (cmbTIPO_CodMNDIngresos.TiposSelectedItem.TIPO_CodTipo.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares)))
                  { Presenter.MOVI_Ingresos.MOVI_MontoDebe = txnIngresosDDol.Value; Presenter.MOVI_Ingresos.MOVI_MontoHaber = txnIngresosHDol.Value; }
                  else
                  { Presenter.MOVI_Ingresos.MOVI_MontoDebe = 0; Presenter.MOVI_Ingresos.MOVI_MontoHaber = 0; }
               }
               else
               { Presenter.MOVI_Ingresos.MOVI_MontoDebe = 0; Presenter.MOVI_Ingresos.MOVI_MontoHaber = 0; }

               Presenter.MOVI_Ingresos.Monto = Presenter.MOVI_Ingresos.MOVI_MontoDebe > 0 ? Presenter.MOVI_Ingresos.MOVI_MontoDebe : Presenter.MOVI_Ingresos.MOVI_MontoHaber;
               Presenter.MOVI_Ingresos.MOVI_TipoCambio = txnMOVI_TipoCambioIngresos.Value;

               /*======================================================================================================================================*/
               /* Egresos */
               Presenter.MOVI_Egresos.SetTipoMovimiento(Entities.Movimiento.TipoMovimiento.EgresosTransferenciaCuentasPropias);
               Presenter.MOVI_Egresos.SetEstado(Entities.Movimiento.Estado.Ingresado);
               Presenter.MOVI_Egresos.MOVI_FecEmision = Presenter.Item.TRAN_Fecha;
               Presenter.MOVI_Egresos.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
               Presenter.MOVI_Egresos.MOVI_Cheque = false;
               if (txaCUBA_NroCuentaEgresos.SelectedItem != null) { Presenter.MOVI_Egresos.CUBA_Codigo = txaCUBA_NroCuentaEgresos.SelectedItem.CUBA_Codigo; }

               if (cmbTIPO_CodMNDEgresos.TiposSelectedItem != null)
               {
                  Presenter.MOVI_Egresos.TIPO_CodMND = cmbTIPO_CodMNDEgresos.TiposSelectedItem.TIPO_CodTipo;

                  if (cmbTIPO_CodMNDEgresos.TiposSelectedItem.TIPO_CodTipo.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles)))
                  { Presenter.MOVI_Egresos.MOVI_MontoDebe = txnEgresosDSol.Value; Presenter.MOVI_Egresos.MOVI_MontoHaber = txnEgresosHSol.Value; }
                  else if (cmbTIPO_CodMNDEgresos.TiposSelectedItem != null && cmbTIPO_CodMNDEgresos.TiposSelectedItem.TIPO_CodTipo.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares)))
                  { Presenter.MOVI_Egresos.MOVI_MontoDebe = txnEgresosDDol.Value; Presenter.MOVI_Egresos.MOVI_MontoHaber = txnEgresosHDol.Value; }
                  else
                  { Presenter.MOVI_Egresos.MOVI_MontoDebe = 0; Presenter.MOVI_Egresos.MOVI_MontoHaber = 0; }
               }
               else
               { Presenter.MOVI_Egresos.MOVI_MontoDebe = 0; Presenter.MOVI_Egresos.MOVI_MontoHaber = 0; }

               Presenter.MOVI_Egresos.Monto = Presenter.MOVI_Egresos.MOVI_MontoDebe > 0 ? Presenter.MOVI_Egresos.MOVI_MontoDebe : Presenter.MOVI_Egresos.MOVI_MontoHaber;
               Presenter.MOVI_Egresos.MOVI_TipoCambio = txnMOVI_TipoCambioEgresos.Value;

               /*======================================================================================================================================*/
               /* Gastos Bancarios */
               //if (txaCUBA_NroCuentaGBancarios.SelectedItem != null) { Presenter.MOVI_GBancarios.CUBA_Codigo = txaCUBA_NroCuentaGBancarios.SelectedItem.CUBA_Codigo; }

               Presenter.MOVI_GBancarios.GBAN_Estado = "I";

               if (cmbTIPO_CodMNDGBancario.TiposSelectedItem != null)
               {
                  Presenter.MOVI_GBancarios.TIPO_CodMND = cmbTIPO_CodMNDGBancario.TiposSelectedItem.TIPO_CodTipo;
                  Presenter.MOVI_GBancarios.TIPO_TabMND = cmbTIPO_CodMNDGBancario.TiposSelectedItem.TIPO_CodTabla;

                  if (cmbTIPO_CodMNDGBancario.TiposSelectedItem.TIPO_CodTipo.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles)))
                  { Presenter.MOVI_GBancarios.GBAN_MontoDebe = txnGBancarioDSol.Value; Presenter.MOVI_GBancarios.GBAN_MontoHaber = txnGBancarioHSol.Value; }
                  else if (cmbTIPO_CodMNDGBancario.TiposSelectedItem != null && cmbTIPO_CodMNDGBancario.TiposSelectedItem.TIPO_CodTipo.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares)))
                  { Presenter.MOVI_GBancarios.GBAN_MontoDebe = txnGBancarioDDol.Value; Presenter.MOVI_GBancarios.GBAN_MontoHaber = txnGBancarioHDol.Value; }
                  else
                  { Presenter.MOVI_GBancarios.GBAN_MontoDebe = 0; Presenter.MOVI_GBancarios.GBAN_MontoHaber = 0; }
               }
               else
               { Presenter.MOVI_GBancarios.GBAN_MontoDebe = 0; Presenter.MOVI_GBancarios.GBAN_MontoHaber = 0; }

               //Presenter.MOVI_GBancarios.Monto = Presenter.MOVI_GBancarios.GBAN_MontoDebe > 0 ? Presenter.MOVI_GBancarios.GBAN_MontoDebe : Presenter.MOVI_GBancarios.GBAN_MontoHaber;
               Presenter.MOVI_GBancarios.GBAN_TipoCambio = txnGBAN_TipoCambio.Value;
               /*======================================================================================================================================*/
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en GetItem.", ex); }
      }
      public void SetItem()
      {
         try
         {
            if (Presenter.Item != null)
            {
               if (Presenter.Item.TRAN_Codigo > 0) { txtTRAN_Codigo.Text = Presenter.Item.TRAN_Codigo.ToString(); }
               if (Presenter.Item.TRAN_Fecha.HasValue) { dtpTRAN_Fecha.NSFecha = Presenter.Item.TRAN_Fecha; }
               if (!String.IsNullOrEmpty(Presenter.Item.TRAN_Glosa)) { txtTRAN_Glosa.Text = Presenter.Item.TRAN_Glosa; }

               /*======================================================================================================================================*/
               /* Egresos */
               if (Presenter.MOVI_Egresos != null && Presenter.MOVI_Egresos.MOVI_Codigo > 0)
               {
                  txaCUBA_NroCuentaEgresos.SelectedItemCuentaBancariaChanged -= txaCUBA_NroCuentaEgresos_SelectedItemCuentaBancariaChanged;

                  txaCUBA_NroCuentaEgresos.SetCuentaBancaria(Presenter.MOVI_Egresos.EMPR_Codigo, Presenter.MOVI_Egresos.CUBA_Codigo);
                  if (Presenter.MOVI_Egresos.MOVI_TipoCambio.HasValue) { txnMOVI_TipoCambioEgresos.Value = Presenter.MOVI_Egresos.MOVI_TipoCambio.Value; }
                  if (txaCUBA_NroCuentaEgresos.SelectedItem != null && String.IsNullOrEmpty(Presenter.MOVI_Egresos.TIPO_CodMND)) { Presenter.MOVI_Egresos.TIPO_CodMND = txaCUBA_NroCuentaEgresos.SelectedItem.TIPO_CodMND; }
                  if (Presenter.MOVI_Egresos.TIPO_CodMND.Equals((Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles))))
                  { txnEgresosHSol.Value = Presenter.MOVI_Egresos.MOVI_MontoHaber; }
                  if (Presenter.MOVI_Egresos.TIPO_CodMND.Equals((Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares))))
                  { txnEgresosHDol.Value = Presenter.MOVI_Egresos.MOVI_MontoHaber; }
                  cmbTIPO_CodMNDEgresos.SelectedValue = Presenter.MOVI_Egresos.TIPO_CodMND;

                  txaCUBA_NroCuentaEgresos.SelectedItemCuentaBancariaChanged += txaCUBA_NroCuentaEgresos_SelectedItemCuentaBancariaChanged;
               }
               /*======================================================================================================================================*/
               /* Ingresos */
               if (Presenter.MOVI_Ingresos != null && Presenter.MOVI_Ingresos.MOVI_Codigo > 0)
               {
                  txaCUBA_NroCuentaIngresos.SelectedItemCuentaBancariaChanged-=txaCUBA_NroCuentaIngresos_SelectedItemCuentaBancariaChanged;
                  
                  txaCUBA_NroCuentaIngresos.SetCuentaBancaria(Presenter.MOVI_Ingresos.EMPR_Codigo, Presenter.MOVI_Ingresos.CUBA_Codigo);
                  if (Presenter.MOVI_Ingresos.MOVI_TipoCambio.HasValue) { txnMOVI_TipoCambioIngresos.Value = Presenter.MOVI_Ingresos.MOVI_TipoCambio.Value; }
                  if (txaCUBA_NroCuentaIngresos.SelectedItem != null && String.IsNullOrEmpty(Presenter.MOVI_Ingresos.TIPO_CodMND)) { Presenter.MOVI_Ingresos.TIPO_CodMND = txaCUBA_NroCuentaEgresos.SelectedItem.TIPO_CodMND; }
                  if (Presenter.MOVI_Ingresos.TIPO_CodMND.Equals((Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles))))
                  { txnIngresosDSol.Value = Presenter.MOVI_Ingresos.MOVI_MontoDebe; }
                  if (Presenter.MOVI_Ingresos.TIPO_CodMND.Equals((Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares))))
                  { txnIngresosDDol.Value = Presenter.MOVI_Ingresos.MOVI_MontoDebe; }
                  cmbTIPO_CodMNDIngresos.SelectedValue = Presenter.MOVI_Ingresos.TIPO_CodMND;
                  
                  txaCUBA_NroCuentaIngresos.SelectedItemCuentaBancariaChanged += txaCUBA_NroCuentaIngresos_SelectedItemCuentaBancariaChanged;
               }
               /*======================================================================================================================================*/
               /* Gastos Bancarios */
               if (Presenter.MOVI_GBancarios != null && Presenter.MOVI_GBancarios.GBAN_Codigo > 0)
               {
                  if (Presenter.MOVI_GBancarios.GBAN_TipoCambio > 0) { txnGBAN_TipoCambio.Value = Presenter.MOVI_GBancarios.GBAN_TipoCambio; }
                  if (!String.IsNullOrEmpty(Presenter.MOVI_GBancarios.TIPO_CodMND))
                  {
                     cmbTIPO_CodMNDGBancario.SelectedIndexChanged-=cmbTIPO_CodMNDGBancario_SelectedIndexChanged;
                     cmbTIPO_CodMNDGBancario.SelectedValue = Presenter.MOVI_GBancarios.TIPO_CodMND;
                     if (Presenter.MOVI_GBancarios.TIPO_CodMND.Equals((Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles))))
                     {
                        txnGBancarioDSol.Value = Presenter.MOVI_GBancarios.GBAN_MontoDebe;
                        txnGBancarioHSol.Value = Presenter.MOVI_GBancarios.GBAN_MontoHaber;
                     }
                     if (Presenter.MOVI_GBancarios.TIPO_CodMND.Equals((Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares))))
                     {
                        txnGBancarioDDol.Value = Presenter.MOVI_GBancarios.GBAN_MontoDebe;
                        txnGBancarioHDol.Value = Presenter.MOVI_GBancarios.GBAN_MontoHaber;
                     }
                     cmbTIPO_CodMNDGBancario.SelectedIndexChanged += cmbTIPO_CodMNDGBancario_SelectedIndexChanged;
                     SetTIPO_CodMNDGBancario();
                  }
               }
               /*======================================================================================================================================*/
               CalcularDiferencias();

               HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
               /*======================================================================================================================================*/
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en SetItem.", ex); }
      }

      public void EnabledItem(Boolean x_opcion = true)
      {
         try
         {
            btnCalcular.Enabled = x_opcion;

            txtTRAN_Glosa.ReadOnly = !x_opcion;
            dtpTRAN_Fecha.Enabled = x_opcion;

            btnGuardar.Enabled = x_opcion;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en EnabledItem.", ex); }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Transferencia>.Validate(Presenter.Item, this, errorProviderTransferencia);
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, revise los detalles.", Presenter.Item.MensajeError);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }

      #endregion

      #region [ Metodos ]

      private void btnCalcular_Click(object sender, EventArgs e)
      {
         try
         {
            Presenter.MOVI_Ingresos.MOVI_TipoCambio = txnMOVI_TipoCambioIngresos.Value;
            Presenter.MOVI_Egresos.MOVI_TipoCambio = txnMOVI_TipoCambioEgresos.Value;
            Presenter.MOVI_GBancarios.GBAN_TipoCambio = txnGBAN_TipoCambio.Value;

            CalcularDiferencias();
         }
         catch (Exception)
         { }
      }

      private void CalcularDiferencias()
      {
         try
         {
            if (Presenter.Item != null)
            {
               Decimal _ingresosDSol = 0, _gbancarioDSol = 0;
               Decimal _ingresosDDol = 0, _gbancarioDDol = 0;
               Decimal _egresosHSol = 0, _gbancarioHSol = 0;
               Decimal _egresosHDol = 0, _gbancarioHDol = 0;
               GetItem();
               //Decimal _ingresosDol = 0, _egresosDol = 0, _gbdebeDol = 0, _gbhaberDol = 0;
               if (Presenter.MOVI_Egresos != null)
               {
                  /* Egresos */
                  if (Presenter.MOVI_Egresos.TIPO_CodMND != null && Presenter.MOVI_Egresos.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles)))
                  {
                     _egresosHSol += Presenter.MOVI_Egresos.Monto;
                     _egresosHDol += Presenter.MOVI_Egresos.Monto / Presenter.MOVI_Egresos.MOVI_TipoCambio.Value;
                     //txnEgresosDDol.TextChanged -= txn_TextChanged;
                     txnEgresosDDol.Value = _egresosHDol;
                     //txnEgresosDDol.LostFocus += txn_LostFocus;
                  }
                  else if (Presenter.MOVI_Egresos.TIPO_CodMND != null && Presenter.MOVI_Egresos.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares)))
                  {
                     _egresosHSol += Presenter.MOVI_Egresos.Monto * Presenter.MOVI_Egresos.MOVI_TipoCambio.Value;
                     _egresosHDol += Presenter.MOVI_Egresos.Monto;
                     //txnEgresosHSol.TextChanged -= txn_TextChanged;
                     txnEgresosHSol.Value = _egresosHSol;
                     //txnEgresosHSol.LostFocus += txn_LostFocus;
                  }
               }
               if (Presenter.MOVI_Ingresos != null)
               {
                  /* Ingresos */
                  if (Presenter.MOVI_Ingresos.TIPO_CodMND != null && Presenter.MOVI_Ingresos.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles)))
                  {
                     _ingresosDSol += Presenter.MOVI_Ingresos.Monto;
                     _ingresosDDol += Presenter.MOVI_Ingresos.Monto / Presenter.MOVI_Ingresos.MOVI_TipoCambio.Value;
                     //txnIngresosDDol.TextChanged -= txn_TextChanged;
                     txnIngresosDDol.Value = _ingresosDDol;
                     //txnIngresosDDol.LostFocus += txn_LostFocus;
                  }
                  else if (Presenter.MOVI_Ingresos.TIPO_CodMND != null && Presenter.MOVI_Ingresos.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares)))
                  {
                     _ingresosDSol += Presenter.MOVI_Ingresos.Monto * Presenter.MOVI_Ingresos.MOVI_TipoCambio.Value;
                     _ingresosDDol += Presenter.MOVI_Ingresos.Monto;
                     //txnIngresosDSol.TextChanged -= txn_TextChanged;
                     txnIngresosDSol.Value = _ingresosDSol;
                     //txnIngresosDSol.LostFocus += txn_LostFocus;
                  }
               }
               if (Presenter.MOVI_GBancarios != null)
               {
                  if (Presenter.MOVI_GBancarios.TIPO_CodMND != null && Presenter.MOVI_GBancarios.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles)))
                  {
                     _gbancarioDSol += Presenter.MOVI_GBancarios.GBAN_MontoDebe;
                     _gbancarioHSol += Presenter.MOVI_GBancarios.GBAN_MontoHaber;

                     _gbancarioDDol += Presenter.MOVI_GBancarios.GBAN_MontoDebe / Presenter.MOVI_GBancarios.GBAN_TipoCambio;
                     _gbancarioHDol += Presenter.MOVI_GBancarios.GBAN_MontoHaber / Presenter.MOVI_GBancarios.GBAN_TipoCambio;

                     //txnGBancarioDDol.TextChanged -= txn_TextChanged;
                     //txnGBancarioHDol.TextChanged -= txn_TextChanged;

                     txnGBancarioDDol.Value = _gbancarioDDol;
                     txnGBancarioHDol.Value = _gbancarioHDol;

                     //txnGBancarioDDol.LostFocus += txn_LostFocus;
                     //txnGBancarioHDol.LostFocus += txn_LostFocus;

                  }
                  else if (Presenter.MOVI_GBancarios.TIPO_CodMND != null && Presenter.MOVI_GBancarios.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares)))
                  {
                     _gbancarioDSol += Presenter.MOVI_GBancarios.GBAN_MontoDebe * Presenter.MOVI_GBancarios.GBAN_TipoCambio;
                     _gbancarioHSol += Presenter.MOVI_GBancarios.GBAN_MontoHaber * Presenter.MOVI_GBancarios.GBAN_TipoCambio;

                     _gbancarioDDol += Presenter.MOVI_GBancarios.GBAN_MontoDebe;
                     _gbancarioHDol += Presenter.MOVI_GBancarios.GBAN_MontoHaber;

                     //txnGBancarioDSol.TextChanged -= txn_TextChanged;
                     //txnGBancarioHSol.TextChanged -= txn_TextChanged;

                     txnGBancarioDSol.Value = _gbancarioDSol;
                     txnGBancarioHSol.Value = _gbancarioHSol;

                     //txnGBancarioDSol.LostFocus += txn_LostFocus;
                     //txnGBancarioHSol.LostFocus += txn_LostFocus;
                  }
               }

               //txnIngresosDSol.Value = _ingresosDSol;
               //txnIngresosDDol.Value = _ingresosDDol;
               //txnEgresosHSol.Value = _egresosHSol;
               //txnEgresosHDol.Value = _egresosHDol;

               //txnGBancarioDDol.Value = _gbancarioDDol;
               //txnGBancarioDSol.Value = _gbancarioDSol;
               //txnGBancarioHDol.Value = _gbancarioHDol;
               //txnGBancarioHSol.Value = _gbancarioHSol;

               txnTotalDDol.Value = _ingresosDDol + _gbancarioDDol;
               txnTotalDSol.Value = _ingresosDSol + _gbancarioDSol;
               txnTotalHDol.Value = _egresosHDol + _gbancarioHDol;
               txnTotalHSol.Value = _egresosHSol + _gbancarioHSol;

               txnDiferenciaDSol.Value = txnTotalHSol.Value - txnTotalDSol.Value; txnDiferenciaDSol.Visible = txnDiferenciaDSol.Value > 0;
               txnDiferenciaHSol.Value = txnTotalDSol.Value - txnTotalHSol.Value; txnDiferenciaHSol.Visible = txnDiferenciaHSol.Value > 0;

               txnDiferenciaDDol.Value = txnTotalHDol.Value - txnTotalDDol.Value; txnDiferenciaDDol.Visible = txnDiferenciaDDol.Value > 0;
               txnDiferenciaHDol.Value = txnTotalDDol.Value - txnTotalHDol.Value; txnDiferenciaHDol.Visible = txnDiferenciaHDol.Value > 0;

               Presenter.Item.Diferencia = txnTotalDSol.Value - txnTotalHSol.Value;
            }
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos Documentos ]

      #endregion

      #region [ Eventos ]

      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.GuardarReducido(true))
            {
               this.FormClosing -= MView_FormClosing;
               Presenter.Actualizar();
               this.Close();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex); }
      }

      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            this.FormClosing -= MView_FormClosing;
            errorProviderTransferencia.Dispose();
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
                  if (Presenter.GuardarCambiosReducido() == System.Windows.Forms.DialogResult.Cancel)
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

      private void SetTIPO_CodMNDGBancario()
      {
         try
         {
            if (cmbTIPO_CodMNDGBancario.TiposSelectedItem != null)
            {
               if (cmbTIPO_CodMNDGBancario.TiposSelectedItem.TIPO_CodTipo.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles)))
               {
                  txnGBancarioDDol.Enabled = false;
                  txnGBancarioDSol.Enabled = true;
                  txnGBancarioHDol.Enabled = false;
                  txnGBancarioHSol.Enabled = true;
               }
               else if (cmbTIPO_CodMNDGBancario.TiposSelectedItem.TIPO_CodTipo.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares)))
               {
                  txnGBancarioDDol.Enabled = true;
                  txnGBancarioDSol.Enabled = false;
                  txnGBancarioHDol.Enabled = true;
                  txnGBancarioHSol.Enabled = false;
               }
               else
               {
                  txnGBancarioDDol.Enabled = false;
                  txnGBancarioDSol.Enabled = false;
                  txnGBancarioHDol.Enabled = false;
                  txnGBancarioHSol.Enabled = false;
               }
            }
            else
            {
               txnGBancarioDDol.Enabled = false;
               txnGBancarioDSol.Enabled = false;
               txnGBancarioHDol.Enabled = false;
               txnGBancarioHSol.Enabled = false;
            }

         }
         catch (Exception)
         { throw; }
      }

      private void cmbTIPO_CodMNDGBancario_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            SetTIPO_CodMNDGBancario();
            txnGBancarioDDol.Value = 0;
            txnGBancarioDSol.Value = 0;
            txnGBancarioHDol.Value = 0;
            txnGBancarioHSol.Value = 0;
            CalcularDiferencias();
         }
         catch (Exception)
         { }
      }

      private void cmbTIPO_CodMNDEgresos_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPO_CodMNDEgresos.TiposSelectedItem != null)
            {
               if (cmbTIPO_CodMNDEgresos.TiposSelectedItem.TIPO_CodTipo.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles)))
               {
                  txnEgresosDDol.Enabled = false;
                  txnEgresosDSol.Enabled = false;
                  txnEgresosHDol.Enabled = false;
                  txnEgresosHSol.Enabled = true;
               }
               else if (cmbTIPO_CodMNDEgresos.TiposSelectedItem.TIPO_CodTipo.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares)))
               {
                  txnEgresosDDol.Enabled = false;
                  txnEgresosDSol.Enabled = false;
                  txnEgresosHDol.Enabled = true;
                  txnEgresosHSol.Enabled = false;
               }
               else
               {
                  txnEgresosDDol.Enabled = false;
                  txnEgresosDSol.Enabled = false;
                  txnEgresosHDol.Enabled = false;
                  txnEgresosHSol.Enabled = false;
               }
            }
            else
            {
               txnEgresosDDol.Enabled = false;
               txnEgresosDSol.Enabled = false;
               txnEgresosHDol.Enabled = false;
               txnEgresosHSol.Enabled = false;
            }
         }
         catch (Exception)
         { }
      }

      private void cmbTIPO_CodMNDIngresos_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPO_CodMNDIngresos.TiposSelectedItem != null)
            {
               if (cmbTIPO_CodMNDIngresos.TiposSelectedItem.TIPO_CodTipo.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles)))
               {
                  txnIngresosDDol.Enabled = false;
                  txnIngresosDSol.Enabled = true;
                  txnIngresosHDol.Enabled = false;
                  txnIngresosHSol.Enabled = false;
               }
               else if (cmbTIPO_CodMNDIngresos.TiposSelectedItem.TIPO_CodTipo.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares)))
               {
                  txnIngresosDDol.Enabled = true;
                  txnIngresosDSol.Enabled = false;
                  txnIngresosHDol.Enabled = false;
                  txnIngresosHSol.Enabled = false;
               }
               else
               {
                  txnIngresosDDol.Enabled = false;
                  txnIngresosDSol.Enabled = false;
                  txnIngresosHDol.Enabled = false;
                  txnIngresosHSol.Enabled = false;
               }
            }
            else
            {
               txnIngresosDDol.Enabled = false;
               txnIngresosDSol.Enabled = false;
               txnIngresosHDol.Enabled = false;
               txnIngresosHSol.Enabled = false;
            }
         }
         catch (Exception)
         { }
      }

      private void txaCUBA_NroCuentaEgresos_SelectedItemCuentaBancariaChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaCUBA_NroCuentaEgresos.SelectedItem != null)
            {
               cmbTIPO_CodMNDEgresos.SelectedValue = txaCUBA_NroCuentaEgresos.SelectedItem.TIPO_CodMND;
               cmbTIPO_CodMNDEgresos_SelectedIndexChanged(null, null);
            }
            txnEgresosDDol.Value = 0;
            txnEgresosDSol.Value = 0;
            txnEgresosHDol.Value = 0;
            txnEgresosHSol.Value = 0;
            CalcularDiferencias();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error con la Cuenta de Egresos.", ex); }
      }

      private void txaCUBA_NroCuentaIngresos_SelectedItemCuentaBancariaChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaCUBA_NroCuentaIngresos.SelectedItem != null)
            {
               cmbTIPO_CodMNDIngresos.SelectedValue = txaCUBA_NroCuentaIngresos.SelectedItem.TIPO_CodMND;
               cmbTIPO_CodMNDIngresos_SelectedIndexChanged(null, null);
            }
            txnIngresosDDol.Value = 0;
            txnIngresosDSol.Value = 0;
            txnIngresosHDol.Value = 0;
            txnIngresosHSol.Value = 0;
            CalcularDiferencias();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error con la Cuenta de Egresos.", ex); }
      }

      private void txn_TextChanged(object sender, EventArgs e)
      {
         try
         {
            CalcularDiferencias();
         }
         catch (Exception)
         { }
      }

      private void txn_LostFocus(object sender, EventArgs e)
      {
         try
         {
            CalcularDiferencias();
         }
         catch (Exception)
         { }
      }



      #endregion
   }
}
