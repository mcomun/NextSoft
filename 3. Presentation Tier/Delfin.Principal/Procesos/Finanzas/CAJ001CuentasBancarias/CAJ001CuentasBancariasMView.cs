using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delfin.Principal.Properties;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Aspect.Collections;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Delfin.Principal
{
   public partial class CAJ001CuentasBancariasMView : Form, ICAJ001CuentasBancariasMView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public CAJ001CuentasBancariasMView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += CAJ001CuentasBancariasMView_FormClosed;

            pnlVisible.Visible = false;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;

            tsbtnNuevaChequera.Click += tsbtnNuevaChequera_Click;

            grdItemsChequera.CommandCellClick += grdItemsChequera_CommandCellClick;
            grdItemsChequera.CellFormatting += grdItemsChequera_CellFormatting;

            grdItemsSeguridad.CellFormatting += grdItemsSeguridad_CellFormatting;
            grdItemsSeguridad.CommandCellClick += grdItemsSeguridad_CommandCellClick;

            grdItemsFirmas.CellFormatting += grdItemsFirmas_CellFormatting;
            grdItemsFirmas.CommandCellClick += grdItemsFirmas_CommandCellClick;

            BSItemsChequera = new BindingSource();
            grdItemsChequera.DataSource = BSItemsChequera;
            BSItemsChequera.CurrentChanged += BSItemsChequera_CurrentChanged;
            //grdItemsFlete.DataSource = BSItemsFlete;
            //grdItemsFleteEmbarque.DataSource = BSItemsFlete;

            BSItemsSeguridad = new BindingSource();
            BSItemsFirmas = new BindingSource();
            tsbtnNuevoUsuario.Click += tsbtnNuevoUsuario_Click;
            tsbtnNuevaFirma.Click += tsbtnNuevaFirma_Click;
            txtCUBA_Codigo.Tag = "CUBA_CodigoMSGERROR";
            cmbSUCR_Codigo.Tag = "SUCR_CodigoMSGERROR";
            cmbTIPO_CodBCO.Tag = "TIPO_CodBCOMSGERROR";
            cmbTIPO_CodMND.Tag = "TIPO_CodMNDMSGERROR";
            txtCUBA_NroCuenta.Tag = "CUBA_NroCuentaMSGERROR";
            cmbCUBA_TipoCuenta.Tag = "CUBA_TipoCuentaMSGERROR";
            txtCUBA_CuenContable.Tag = "CUBA_CuenContableMSGERROR";
            txtCUBA_CtaPorCobrar.Tag = "CUBA_CtaPorCobrarMSGERROR";
            txtCUBA_CtaPorPagar.Tag = "CUBA_CtaPorPagarMSGERROR";
            dtpCUBA_FechaCierre.Tag = "CUBA_FechaCierreMSGERROR";
            chkCUBA_Bloqueo.Tag = "CUBA_BloqueoMSGERROR";
            chkCUBA_PermChequeBlanco.Tag = "CUBA_PermChequeBlancoMSGERROR";
            chkCUBA_PermImprAutomatica.Tag = "CUBA_PermImprAutomaticaMSGERROR";
            txtCUBA_CodAgencia.Tag = "CUBA_CodAgenciaMSGERROR";
            txtCUBA_Descripcion.Tag = "CUBA_DescripcionMSGERROR";
            txtCUBA_SubCtaEgreso.Tag = "CUBA_SubCtaEgresoMSGERROR";
            txtCUBA_SubCtaIngreso.Tag = "CUBA_SubCtaIngresoMSGERROR";
            txtCUBA_SubCtaEgresoEV.Tag = "CUBA_SubCtaEgresoEVMSGERROR";
            txtCUBA_SubCtaIngresoEV.Tag = "CUBA_SubCtaIngresoEVMSGERROR";

            /************* DATOS GENERALES(MaxLength)****************/
            txtCUBA_Codigo.MaxLength = 3;
            txtCUBA_NroCuenta.MaxLength = 50;
            txtCUBA_CuenContable.MaxLength = 20;
            txtCUBA_CtaPorCobrar.MaxLength = 20;
            txtCUBA_CtaPorPagar.MaxLength = 20;
            txtCUBA_CodAgencia.MaxLength = 20;
            txtCUBA_CuenPuente.MaxLength = 20;
            txtCUBA_Descripcion.MaxLength = 100;
            txtCUBA_SubCtaEgreso.MaxLength = 20;
            txtCUBA_SubCtaIngreso.MaxLength = 20;
            txtCUBA_SubCtaEgresoEV.MaxLength = 20;
            txtCUBA_SubCtaIngresoEV.MaxLength = 20;

            txnCFecha_X.LostFocus += txnCFecha_X_LostFocus;
            txnCFecha_Y.LostFocus += txnCFecha_X_LostFocus;
            txnCOrdenDe_X.LostFocus += txnCFecha_X_LostFocus;
            txnCOrdenDe_Y.LostFocus += txnCFecha_X_LostFocus;
            txnCMonto_X.LostFocus += txnCFecha_X_LostFocus;
            txnCMonto_Y.LostFocus += txnCFecha_X_LostFocus;
            txnCMontoLetras_X.LostFocus += txnCFecha_X_LostFocus;
            txnCMontoLetras_Y.LostFocus += txnCFecha_X_LostFocus;
            txnCFirma1_X.LostFocus += txnCFecha_X_LostFocus;
            txnCFirma1_Y.LostFocus += txnCFecha_X_LostFocus;
            txnCFirma2_X.LostFocus += txnCFecha_X_LostFocus;
            txnCFirma2_Y.LostFocus += txnCFecha_X_LostFocus;
            txnCNoNegociable_X.LostFocus += txnCFecha_X_LostFocus;
            txnCNoNegociable_Y.LostFocus += txnCFecha_X_LostFocus;
            txnCReferencias_X.LostFocus += txnCFecha_X_LostFocus;
            txnCReferencias_Y.LostFocus += txnCFecha_X_LostFocus;

            cmbSUCR_Codigo.DropDownStyle = ComboBoxStyle.DropDownList;

            this.Load += CAJ001CuentasBancariasMView_Load;
            chkCUBA_CtaEmprVinculada.CheckedChanged += chkCUBA_CtaEmprVinculada_CheckedChanged;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }
      
      private void CAJ001CuentasBancariasMView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }

      private void CAJ001CuentasBancariasMView_Load(object sender, EventArgs e)
      {
         tabCuentasBancarias.TabPages.Clear();

         tabCuentasBancarias.TabPages.Add(pageGenerales);
         tabCuentasBancarias.TabPages.Add(pageChequera);
         tabCuentasBancarias.TabPages.Add(pageSeguridad);
         tabCuentasBancarias.TabPages.Add(pageFirmas);
         tabCuentasBancarias.SelectedTab = pageGenerales;
      }

      #endregion

      #region [ Propiedades ]
      public CAJ001CuentasBancariasPresenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }

      public BindingSource BSItemsChequera { get; set; }
      public BindingSource BSItemsSeguridad { get; set; }
      public BindingSource BSItemsFirmas { get; set; }
      #endregion

      #region [ ICAJ001MView ]
      public void LoadView()
      {
         try
         {
            /* Cargar Sucursal */
            cmbSUCR_Codigo.DisplayMember = "SUCR_Desc";
            cmbSUCR_Codigo.ValueMember = "SUCR_Codigo";
            cmbSUCR_Codigo.DataSource = Presenter.ListSucursales;

            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Moneda", "MND", "< Seleccionar Moneda >", ListSortDirection.Ascending);
            cmbTIPO_CodBCO.LoadControl(Presenter.ContainerService, "Banco", "BCO", "< Seleccionar Banco >", ListSortDirection.Ascending);
            cmbCUBA_TipoCuenta.LoadControl("Tipo de Cuenta", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.TipoCuenta, "< Seleccionar Tipo de Cuenta >", ListSortDirection.Ascending);

            cmbCUBA_LibroDestino.LoadControl(Presenter.ListTiposREG, "Ayuda de Tipo de Registro", "< Seleccione un Libro >", ListSortDirection.Ascending);

            #region [ Chequera ]
            BSItemsChequera.DataSource = null;
            grdItemsChequera.DataSource = BSItemsChequera;
            navItemsChequera.BindingSource = BSItemsChequera;
            BSItemsChequera.ResetBindings(true);
            #endregion

            #region [ Seguridad ]
            BSItemsSeguridad.DataSource = null;
            grdItemsSeguridad.DataSource = BSItemsSeguridad;
            navItemsSeguridad.BindingSource = BSItemsSeguridad;
            BSItemsSeguridad.ResetBindings(true);
            #endregion

            #region [ Firmas ]
            BSItemsFirmas.DataSource = null;
            grdItemsFirmas.DataSource = BSItemsFirmas;
            navItemsFirmas.BindingSource = BSItemsFirmas;
            BSItemsFirmas.ResetBindings(true);
            #endregion
            FormatGridChequera();
            FormatGridSeguridad();
            FormatGridFirmas();

            lblCUBA_CuenPuente.Enabled = false;
            txtCUBA_CuenPuente.Enabled = false;
            txtCUBA_SubCtaIngresoEV.Enabled = false;
            txtCUBA_SubCtaEgresoEV.Enabled = false;
            lblCUBA_SubCtaIngresoEV.Enabled = false;
            lblCUBA_SubCtaEgresoEV.Enabled = false;

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      public void ClearItem()
      {
         try
         {
            errorProviderCuentasBancarias.Clear();

            #region [ Datos Generales ]
            txtCUBA_Codigo.Clear();
            cmbSUCR_Codigo.SelectedIndex = 0;
            cmbTIPO_CodMND.SelectedIndex = 0;
            cmbTIPO_CodBCO.SelectedIndex = 0;
            txtCUBA_NroCuenta.Clear();
            cmbCUBA_TipoCuenta.SelectedIndex = 0;
            txtCUBA_CuenContable.Clear();
            txtCUBA_CodAgencia.Clear();
            txtCUBA_CtaPorPagar.Clear();
            txtCUBA_CtaPorCobrar.Clear();
            txtCUBA_Descripcion.Clear();

            chkCUBA_Bloqueo.Checked = false;
            chkCUBA_PermChequeBlanco.Checked = false;
            chkCUBA_PermImprAutomatica.Checked = false;
            dtpCUBA_FechaCierre.NSClear();

            #endregion

            #region [ Chequera ]
            BSItemsChequera.DataSource = null;
            BSItemsChequera.ResetBindings(true);
            #endregion

            #region [ Seguridad ]
            BSItemsSeguridad.DataSource = null;
            BSItemsSeguridad.ResetBindings(true);
            #endregion

            #region [ Firmas ]
            BSItemsFirmas.DataSource = null;
            BSItemsFirmas.ResetBindings(true);
            #endregion
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ClearItem.", ex); }
      }
      public void GetItem()
      {
         try
         {
            errorProviderCuentasBancarias.Clear();
            if (Presenter != null && Presenter.Item != null)
            {
               #region [ Datos Generales ]

               Presenter.Item.CUBA_Codigo = null; if (txtCUBA_Codigo.Text.Length > 0) { Presenter.Item.CUBA_Codigo = txtCUBA_Codigo.Text; }
               Presenter.Item.SUCR_Codigo = null; if (cmbSUCR_Codigo.SelectedItem != null && (cmbSUCR_Codigo.SelectedItem as Entities.Sucursales).SUCR_Codigo > 0) { Presenter.Item.SUCR_Codigo = (cmbSUCR_Codigo.SelectedItem as Entities.Sucursales).SUCR_Codigo; }

               Presenter.Item.TIPO_CodMND = null; Presenter.Item.TIPO_TabMND = null;
               if (cmbTIPO_CodMND.TiposSelectedItem != null) { Presenter.Item.TIPO_CodMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo; Presenter.Item.TIPO_TabMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTabla; }

               Presenter.Item.TIPO_CodBCO = null; Presenter.Item.TIPO_TabBCO = null;
               if (cmbTIPO_CodBCO.TiposSelectedItem != null) { Presenter.Item.TIPO_CodBCO = cmbTIPO_CodBCO.TiposSelectedItem.TIPO_CodTipo; Presenter.Item.TIPO_TabBCO = cmbTIPO_CodBCO.TiposSelectedItem.TIPO_CodTabla; }

               Presenter.Item.CUBA_LibroDestino = null; if (cmbCUBA_LibroDestino.TiposSelectedItem != null) { Presenter.Item.CUBA_LibroDestino = cmbCUBA_LibroDestino.TiposSelectedItem.TIPO_CodTipo; }

               Presenter.Item.CUBA_NroCuenta = null; if (!String.IsNullOrEmpty(txtCUBA_NroCuenta.Text)) { Presenter.Item.CUBA_NroCuenta = txtCUBA_NroCuenta.Text; }
               Presenter.Item.CUBA_TipoCuenta = null; if (cmbCUBA_TipoCuenta.ConstantesSelectedItem != null) { Presenter.Item.CUBA_TipoCuenta = cmbCUBA_TipoCuenta.ConstantesSelectedItem.CONS_CodTipo; }
               Presenter.Item.CUBA_CuenContable = null; if (!String.IsNullOrEmpty(txtCUBA_CuenContable.Text)) { Presenter.Item.CUBA_CuenContable = txtCUBA_CuenContable.Text; }
               Presenter.Item.CUBA_CodAgencia = null; if (!String.IsNullOrEmpty(txtCUBA_CodAgencia.Text)) { Presenter.Item.CUBA_CodAgencia = txtCUBA_CodAgencia.Text; }
               Presenter.Item.CUBA_CtaPorPagar = null; if (!String.IsNullOrEmpty(txtCUBA_CtaPorPagar.Text)) { Presenter.Item.CUBA_CtaPorPagar = txtCUBA_CtaPorPagar.Text; }
               Presenter.Item.CUBA_CtaPorCobrar = null; if (!String.IsNullOrEmpty(txtCUBA_CtaPorCobrar.Text)) { Presenter.Item.CUBA_CtaPorCobrar = txtCUBA_CtaPorCobrar.Text; }
               Presenter.Item.CUBA_Descripcion = null; if (!String.IsNullOrEmpty(txtCUBA_Descripcion.Text)) { Presenter.Item.CUBA_Descripcion = txtCUBA_Descripcion.Text; }
               Presenter.Item.CUBA_SubCtaIngreso = null; if (!String.IsNullOrEmpty(txtCUBA_SubCtaIngreso.Text)) { Presenter.Item.CUBA_SubCtaIngreso = txtCUBA_SubCtaIngreso.Text; }
               Presenter.Item.CUBA_SubCtaEgreso = null; if (!String.IsNullOrEmpty(txtCUBA_SubCtaEgreso.Text)) { Presenter.Item.CUBA_SubCtaEgreso = txtCUBA_SubCtaEgreso.Text; }
               Presenter.Item.CUBA_SubCtaIngresoEV = null; if (!String.IsNullOrEmpty(txtCUBA_SubCtaIngresoEV.Text)) { Presenter.Item.CUBA_SubCtaIngresoEV = txtCUBA_SubCtaIngresoEV.Text; }
               Presenter.Item.CUBA_SubCtaEgresoEV = null; if (!String.IsNullOrEmpty(txtCUBA_SubCtaEgresoEV.Text)) { Presenter.Item.CUBA_SubCtaEgresoEV = txtCUBA_SubCtaEgresoEV.Text; }

               Presenter.Item.CUBA_Bloqueo = chkCUBA_Bloqueo.Checked;
               Presenter.Item.CUBA_PermChequeBlanco = chkCUBA_PermChequeBlanco.Checked;
               Presenter.Item.CUBA_PermImprAutomatica = chkCUBA_PermImprAutomatica.Checked;
               Presenter.Item.CUBA_CtaEmprVinculada = chkCUBA_CtaEmprVinculada.Checked;

               Presenter.Item.CUBA_FechaCierre = null; if (dtpCUBA_FechaCierre.NSFecha.HasValue) { Presenter.Item.CUBA_FechaCierre = dtpCUBA_FechaCierre.NSFecha; }

               Presenter.Item.CUBA_MedioVirtual = chkCUBA_MedioVirtual.Checked;
               Presenter.Item.CUBA_InscritoSOL = chkCUBA_InscritoSOL.Checked;
               Presenter.Item.CUBA_CuenPuente = null; if (!String.IsNullOrEmpty(txtCUBA_CuenPuente.Text)) { Presenter.Item.CUBA_CuenPuente = txtCUBA_CuenPuente.Text; }

               #endregion
            }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en GetItem.", ex); }
      }

      public void SetItem()
      {
         try
         {
            if (Presenter != null && Presenter.Item != null)
            {
               if (Presenter.Item.CUBA_Codigo != null) { txtCUBA_Codigo.Text = Presenter.Item.CUBA_Codigo; }
               if (Presenter.Item.SUCR_Codigo != null) { cmbSUCR_Codigo.SelectedValue = Presenter.Item.SUCR_Codigo; }
               if (Presenter.Item.TIPO_CodMND != null) { cmbTIPO_CodMND.SelectedValue = Presenter.Item.TIPO_CodMND; }
               if (Presenter.Item.TIPO_CodBCO != null) { cmbTIPO_CodBCO.SelectedValue = Presenter.Item.TIPO_CodBCO; }
               if (Presenter.Item.CUBA_NroCuenta != null) { txtCUBA_NroCuenta.Text = Presenter.Item.CUBA_NroCuenta; }
               if (Presenter.Item.CUBA_TipoCuenta != null) { cmbCUBA_TipoCuenta.SelectedValue = Presenter.Item.CUBA_TipoCuenta; }
               if (Presenter.Item.CUBA_CuenContable != null) { txtCUBA_CuenContable.Text = Presenter.Item.CUBA_CuenContable; }
               if (Presenter.Item.CUBA_CodAgencia != null) { txtCUBA_CodAgencia.Text = Presenter.Item.CUBA_CodAgencia; }
               if (Presenter.Item.CUBA_CtaPorPagar != null) { txtCUBA_CtaPorPagar.Text = Presenter.Item.CUBA_CtaPorPagar; }
               if (Presenter.Item.CUBA_CtaPorCobrar != null) { txtCUBA_CtaPorCobrar.Text = Presenter.Item.CUBA_CtaPorCobrar; }
               if (Presenter.Item.CUBA_Descripcion != null) { txtCUBA_Descripcion.Text = Presenter.Item.CUBA_Descripcion; }
               if (Presenter.Item.CUBA_CuenPuente != null) { txtCUBA_CuenPuente.Text = Presenter.Item.CUBA_CuenPuente; }
               if (Presenter.Item.CUBA_SubCtaIngreso != null) { txtCUBA_SubCtaIngreso.Text = Presenter.Item.CUBA_SubCtaIngreso; }
               if (Presenter.Item.CUBA_SubCtaEgreso != null) { txtCUBA_SubCtaEgreso.Text = Presenter.Item.CUBA_SubCtaEgreso; }
               if (Presenter.Item.CUBA_SubCtaIngresoEV != null) { txtCUBA_SubCtaIngresoEV.Text = Presenter.Item.CUBA_SubCtaIngresoEV; }
               if (Presenter.Item.CUBA_SubCtaEgresoEV != null) { txtCUBA_SubCtaEgresoEV.Text = Presenter.Item.CUBA_SubCtaEgresoEV; }
               if (!String.IsNullOrEmpty(Presenter.Item.CUBA_LibroDestino)) { cmbCUBA_LibroDestino.SelectedValue = Presenter.Item.CUBA_LibroDestino; }

               chkCUBA_Bloqueo.Checked = (Presenter.Item.CUBA_Bloqueo.HasValue ? Presenter.Item.CUBA_Bloqueo.Value : false);
               chkCUBA_PermChequeBlanco.Checked = (Presenter.Item.CUBA_PermChequeBlanco.HasValue ? Presenter.Item.CUBA_PermChequeBlanco.Value : false);
               chkCUBA_PermImprAutomatica.Checked = (Presenter.Item.CUBA_PermImprAutomatica.HasValue ? Presenter.Item.CUBA_PermImprAutomatica.Value : false);
               if (Presenter.Item.CUBA_FechaCierre.HasValue) { dtpCUBA_FechaCierre.NSFecha = Presenter.Item.CUBA_FechaCierre; }
               chkCUBA_MedioVirtual.Checked = Presenter.Item.CUBA_MedioVirtual;
               chkCUBA_InscritoSOL.Checked = (Presenter.Item.CUBA_InscritoSOL.HasValue ? Presenter.Item.CUBA_InscritoSOL.Value : false);
               chkCUBA_CtaEmprVinculada.Checked = Presenter.Item.CUBA_CtaEmprVinculada;
               
               BSItemsChequera.DataSource = Presenter.Item.ListChequera;
               BSItemsChequera.ResetBindings(false);
               BSItemsSeguridad.DataSource = Presenter.Item.ListCuentasBancariasUsuarios;
               BSItemsSeguridad.ResetBindings(false);

               BSItemsFirmas.DataSource = Presenter.Item.ListFirmas;
               BSItemsFirmas.ResetBindings(false);
               EnabledItem();
               tabCuentasBancarias.SelectedTab = pageGenerales;
               HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
            }
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
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.CuentasBancarias>.Validate(Presenter.Item, this, errorProviderCuentasBancarias);
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.CuentasBancarias>.SetTabError(tabCuentasBancarias, errorProviderCuentasBancarias);
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, revise los detalles.", Presenter.Item.MensajeError);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }
      #endregion

      #region [ Metodos ]

      #region [ Chequera ]

      private void FormatGridChequera()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsChequera.Columns.Clear();
            this.grdItemsChequera.AllowAddNewRow = false;

            Telerik.WinControls.UI.GridViewCommandColumn commandColumn;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItemsChequera.Columns.Add(commandColumn);
            this.grdItemsChequera.Columns["Delete"].AllowSort = false;
            this.grdItemsChequera.Columns["Delete"].AllowFiltering = false;
             this.grdItemsChequera.Columns["Delete"].MaxWidth = 50;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Editar";
            commandColumn.DefaultText = "Editar";
            commandColumn.UseDefaultText = true;
            this.grdItemsChequera.Columns.Add(commandColumn);
            this.grdItemsChequera.Columns["Edit"].AllowSort = true;
            this.grdItemsChequera.Columns["Edit"].AllowFiltering = true;
            this.grdItemsChequera.Columns["Edit"].MaxWidth = 50;
            this.grdItemsChequera.Columns.Add("CHEQ_Codigo", "Código", "CHEQ_Codigo");
            this.grdItemsChequera.Columns.Add("CHEQ_NroInicial", "Nro. Inicial", "CHEQ_NroInicial");
            this.grdItemsChequera.Columns.Add("CHEQ_NroFinal", "Nro. Final", "CHEQ_NroFinal");
            this.grdItemsChequera.Columns.Add("CHEQ_NroActual", "Nro Actual", "CHEQ_NroActual");
            this.grdItemsChequera.Columns.Add("CHEQ_Diferido_Text", "Tipo", "CHEQ_Diferido_Text");
            this.grdItemsChequera.Columns.Add("CHEQ_Estado_Text", "Estado", "CHEQ_Estado_Text");

            this.grdItemsChequera.Columns["CHEQ_Codigo"].ReadOnly = true;
            this.grdItemsChequera.Columns["CHEQ_NroInicial"].ReadOnly = true;
            this.grdItemsChequera.Columns["CHEQ_NroFinal"].ReadOnly = true;
            this.grdItemsChequera.Columns["CHEQ_NroActual"].ReadOnly = true;
            this.grdItemsChequera.Columns["CHEQ_Diferido_Text"].ReadOnly = true;
            this.grdItemsChequera.Columns["CHEQ_Estado_Text"].ReadOnly = true;

            grdItemsChequera.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsChequera);
            this.grdItemsChequera.Columns["CHEQ_Diferido_Text"].Width = 150;
            this.grdItemsChequera.Columns["CHEQ_Estado_Text"].Width = 150;
            grdItemsChequera.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.None;

            this.grdItemsChequera.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.grdItemsChequera.MultiSelect = false;

            this.grdItemsChequera.ShowFilteringRow = false;
            this.grdItemsChequera.EnableFiltering = false;
            this.grdItemsChequera.MasterTemplate.EnableFiltering = false;
            this.grdItemsChequera.EnableGrouping = false;
            this.grdItemsChequera.MasterTemplate.EnableGrouping = false;
            this.grdItemsChequera.EnableSorting = false;
            this.grdItemsChequera.MasterTemplate.EnableCustomSorting = false;

            this.grdItemsChequera.ReadOnly = false;
            this.grdItemsChequera.AllowEditRow = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex); }
      }

      private void NuevaChequera()
      {
         try
         {
            if (Presenter.Item != null)
            {
               Int32 _item = 0;
               if (((ObservableCollection<Entities.Chequera>)BSItemsChequera.DataSource).Count > 0)
               {
                  _item = ((ObservableCollection<Entities.Chequera>)BSItemsChequera.DataSource).Max(dcot => dcot.CHEQ_Codigo);
               }
               if (Presenter.NuevaChequera(_item))
               {
                  BSItemsChequera.DataSource = Presenter.Item.ListChequera;
                  BSItemsChequera.ResetBindings(false);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar una chequera", ex); }
      }

      private void EditarChequera()
      {
         try
         {
            if (Presenter.Item != null && BSItemsChequera != null && BSItemsChequera.DataSource != null)
            {
               Int32 x_position = BSItemsChequera.Position;
               Entities.Chequera _chequera = (BSItemsChequera.Current as Entities.Chequera);
               if (Presenter.EditarChequera(ref _chequera))
               {
                  (BSItemsChequera.DataSource as ObservableCollection<Entities.Chequera>)[x_position] = _chequera;
                  BSItemsChequera.ResetBindings(false);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al editar una chequera", ex); }
      }

      private void EliminarChequera()
      {
         try
         {
            if (BSItemsChequera.Current != null && BSItemsChequera.Current is Entities.Chequera)
            {
               Entities.Chequera _flete = (Entities.Chequera)BSItemsChequera.Current;
               if (_flete.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
               {
                  _flete.AUDI_UsrMod = Presenter.Session.UserName;
                  _flete.AUDI_FecMod = Presenter.Session.Fecha;
                  _flete.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                  if (Presenter.Item.ListChequeraEliminados == null) { Presenter.Item.ListChequeraEliminados = new ObservableCollection<Entities.Chequera>(); }
                  Presenter.Item.ListChequeraEliminados.Add(_flete);
               }
               BSItemsChequera.RemoveCurrent();
               BSItemsChequera.ResetBindings(true);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar una chequera", ex); }
      }

      private String GetCoordenadas()
      {
         try
         {
            String _coordenadas = String.Format("{0},{1}", txnCFecha_X.Value, txnCFecha_Y.Value);
            _coordenadas += String.Format("|{0},{1}", txnCOrdenDe_X.Value, txnCOrdenDe_Y.Value);
            _coordenadas += String.Format("|{0},{1}", txnCMonto_X.Value, txnCMonto_Y.Value);
            _coordenadas += String.Format("|{0},{1}", txnCMontoLetras_X.Value, txnCMontoLetras_Y.Value);
            _coordenadas += String.Format("|{0},{1}", txnCFirma1_X.Value, txnCFirma1_Y.Value);
            _coordenadas += String.Format("|{0},{1}", txnCFirma2_X.Value, txnCFirma2_X.Value);
            _coordenadas += String.Format("|{0},{1}", txnCNoNegociable_X.Value, txnCNoNegociable_Y.Value);
            _coordenadas += String.Format("|{0},{1}", txnCReferencias_X.Value, txnCReferencias_Y.Value);
            return _coordenadas;
         }
         catch (Exception)
         { throw; }
      }

      private void SetCoordenadas(String _coordenadas)
      {
         try
         {
            if (!String.IsNullOrEmpty(_coordenadas))
            {
               String[] _coord = _coordenadas.Split('|');
               for (int i = 0; i < _coord.Count(); i++)
               {
                  String[] _valor = _coord[i].Split(',');
                  if (i == 0) { txnCFecha_X.Value = Int32.Parse(_valor[0]); txnCFecha_Y.Value = Int32.Parse(_valor[1]); }
                  if (i == 1) { txnCOrdenDe_X.Value = Int32.Parse(_valor[0]); txnCOrdenDe_Y.Value = Int32.Parse(_valor[1]); }
                  if (i == 2) { txnCMonto_X.Value = Int32.Parse(_valor[0]); txnCMonto_Y.Value = Int32.Parse(_valor[1]); }
                  if (i == 3) { txnCMontoLetras_X.Value = Int32.Parse(_valor[0]); txnCMontoLetras_Y.Value = Int32.Parse(_valor[1]); }
                  if (i == 4) { txnCFirma1_X.Value = Int32.Parse(_valor[0]); txnCFirma1_Y.Value = Int32.Parse(_valor[1]); }
                  if (i == 5) { txnCFirma2_X.Value = Int32.Parse(_valor[0]); txnCFirma2_Y.Value = Int32.Parse(_valor[1]); }
                  if (i == 6) { txnCNoNegociable_X.Value = Int32.Parse(_valor[0]); txnCNoNegociable_Y.Value = Int32.Parse(_valor[1]); }
                  if (i == 7) { txnCReferencias_X.Value = Int32.Parse(_valor[0]); txnCReferencias_Y.Value = Int32.Parse(_valor[1]); }
               }
            }
            else
            {
               txnCFecha_X.Clear();
               txnCFecha_Y.Clear();
               txnCOrdenDe_X.Clear();
               txnCOrdenDe_Y.Clear();
               txnCMonto_X.Clear();
               txnCMonto_Y.Clear();
               txnCMontoLetras_X.Clear();
               txnCMontoLetras_Y.Clear();
               txnCFirma1_X.Clear();
               txnCFirma1_Y.Clear();
               txnCFirma2_X.Clear();
               txnCFirma2_Y.Clear();
               txnCNoNegociable_X.Clear();
               txnCNoNegociable_Y.Clear();
               txnCReferencias_X.Clear();
               txnCReferencias_Y.Clear();
            }
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Seguridad ]
      private void FormatGridSeguridad()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsSeguridad.Columns.Clear();
            this.grdItemsSeguridad.AllowAddNewRow = false;

            Telerik.WinControls.UI.GridViewCommandColumn commandColumn;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItemsSeguridad.Columns.Add(commandColumn);
            this.grdItemsSeguridad.Columns["Delete"].AllowSort = false;
            this.grdItemsSeguridad.Columns["Delete"].AllowFiltering = false;
             this.grdItemsSeguridad.Columns["Delete"].MaxWidth = 50;
            this.grdItemsSeguridad.Columns.Add("USER_Codigo", "Usuario", "USER_Codigo");
            this.grdItemsSeguridad.Columns.Add("USER_Nombres", "Nombres", "USER_Nombres");

            grdItemsSeguridad.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsSeguridad);
            //grdItemsSeguridad.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.grdItemsSeguridad.Columns["USER_Codigo"].Width = 80;
            this.grdItemsSeguridad.Columns["USER_Nombres"].Width = 200;

            this.grdItemsSeguridad.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.grdItemsSeguridad.MultiSelect = false;

            this.grdItemsSeguridad.ShowFilteringRow = false;
            this.grdItemsSeguridad.EnableFiltering = false;
            this.grdItemsSeguridad.MasterTemplate.EnableFiltering = false;
            this.grdItemsSeguridad.EnableGrouping = false;
            this.grdItemsSeguridad.MasterTemplate.EnableGrouping = false;
            this.grdItemsSeguridad.EnableSorting = false;
            this.grdItemsSeguridad.MasterTemplate.EnableCustomSorting = false;

            this.grdItemsSeguridad.ReadOnly = true;
            this.grdItemsSeguridad.AllowEditRow = false;

             this.grdItemsSeguridad.Columns["USER_Codigo"].ReadOnly = true;
             this.grdItemsSeguridad.Columns["USER_Nombres"].ReadOnly = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Usuarios)", ex); }
      }

      private void NuevaSeguridad()
      {
         try
         {
            NextAdmin.BusinessLogic.Usuarios _usuario = null;
            System.Data.DataTable dtAyuda = null;

            if (BSItemsSeguridad.DataSource != null && ((ObservableCollection<Entities.CuentasBancariasUsuarios>)BSItemsSeguridad.DataSource).Count > 0)
            { dtAyuda = Presenter.ListUsuarios.Where(_usua => ((ObservableCollection<Entities.CuentasBancariasUsuarios>)BSItemsSeguridad.DataSource).Where(cbus => cbus.USER_Codigo == _usua.USUA_CodUsr).FirstOrDefault() == null).ToObservableCollection().ToDataTable(); }
            else
            { dtAyuda = Presenter.ListUsuarios.ToDataTable(); }

            if (dtAyuda.Rows.Count == 0)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Ayuda de Usuarios", "No se encontraron coincidencias."); }
            else if (dtAyuda.Rows.Count == 1)
            {
               Int32 _USUA_Codigo;
               if (Int32.TryParse(dtAyuda.Rows[0]["USUA_Codigo"].ToString(), out _USUA_Codigo))
               { _usuario = Presenter.ListUsuarios.Where(usua => usua.USUA_Codigo == _USUA_Codigo).FirstOrDefault(); }
            }
            else
            {
               List<Infrastructure.WinForms.Controls.ColumnaAyuda> _columnas = new List<Infrastructure.WinForms.Controls.ColumnaAyuda>();
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 0,
                  ColumnName = "USUA_CodUsr",
                  ColumnCaption = "Usuario"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 1,
                  ColumnName = "USUA_Nombres",
                  ColumnCaption = "Nombre"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 2,
                  ColumnName = "USUA_Email",
                  ColumnCaption = "E-mail"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 3,
                  ColumnName = "USUA_Codigo",
                  ColumnCaption = "Código"
               });
               Infrastructure.WinForms.Controls.Ayuda x_Ayuda = new Infrastructure.WinForms.Controls.Ayuda("Ayuda Usuarior", dtAyuda, false, _columnas);
               if (x_Ayuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                  Int32 _USUA_Codigo;
                  if (Int32.TryParse(x_Ayuda.Respuesta.Rows[0]["USUA_Codigo"].ToString(), out _USUA_Codigo))
                  { _usuario = Presenter.ListUsuarios.Where(usua => usua.USUA_Codigo == _USUA_Codigo).FirstOrDefault(); }
               }
            }

            if (_usuario != null)
            {
               Entities.CuentasBancariasUsuarios _itemCuentasBancariasUsuarios = new Entities.CuentasBancariasUsuarios();
               _itemCuentasBancariasUsuarios.EMPR_Codigo = Convert.ToInt16(Presenter.Session.EmpresaCodigo);
               _itemCuentasBancariasUsuarios.USER_Codigo = _usuario.USUA_CodUsr;
               _itemCuentasBancariasUsuarios.USER_Nombres = _usuario.USUA_Nombres;
               _itemCuentasBancariasUsuarios.AUDI_UsrCrea = Presenter.Session.UserName;
               _itemCuentasBancariasUsuarios.AUDI_FecCrea = Presenter.Session.Fecha;
               _itemCuentasBancariasUsuarios.Instance = InstanceEntity.Added;

               //Presenter.Item.ListCuentasBancariasUsuarios.Add(_itemCuentasBancariasUsuarios);
               BSItemsSeguridad.Add(_itemCuentasBancariasUsuarios);
            }

            BSItemsSeguridad.ResetBindings(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un usuario", ex); }
      }
      private void EliminarSeguridad()
      {
         try
         {
            if (BSItemsSeguridad.Current != null && BSItemsSeguridad.Current is Entities.CuentasBancariasUsuarios)
            {
               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Esta seguro que desea eliminar el usuario?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
               {
                  Entities.CuentasBancariasUsuarios _itemCuentaBancosUsuarios = ((BSItemsSeguridad.Current as Entities.CuentasBancariasUsuarios).Clone() as Entities.CuentasBancariasUsuarios);
                  if (_itemCuentaBancosUsuarios.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
                  {
                     //_itemCuentaBancosUsuarios.AUDI_UsrMod = Presenter.Session.UserName;
                     //_itemCuentaBancosUsuarios.AUDI_FecMod = Presenter.Session.Fecha;
                     _itemCuentaBancosUsuarios.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                     Presenter.Item.ListCuentaBancosUsuariosEliminados.Add(_itemCuentaBancosUsuarios);
                  }

                  BSItemsSeguridad.RemoveCurrent();
                  BSItemsSeguridad.ResetBindings(true);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar un usuario", ex); }
      }
      #endregion

      #region [Firmas]
      private void FormatGridFirmas()
      {
          try
          {
              Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
              this.grdItemsFirmas.Columns.Clear();
              this.grdItemsFirmas.AllowAddNewRow = false;

              GridViewCommandColumn commandColumn;
              commandColumn = new GridViewCommandColumn();
              commandColumn.Name = "Delete";
              commandColumn.HeaderText = "Eliminar";
              commandColumn.DefaultText = "Eliminar";
              commandColumn.UseDefaultText = true;
              this.grdItemsFirmas.Columns.Add(commandColumn);
              this.grdItemsFirmas.Columns["Delete"].AllowSort = false;
              this.grdItemsFirmas.Columns["Delete"].AllowFiltering = false;
              this.grdItemsFirmas.Columns["Delete"].MaxWidth = 50;
              this.grdItemsFirmas.Columns.Add("FIRM_Codigo", "Código", "FIRM_Codigo");
              this.grdItemsFirmas.Columns.Add("FIRM_Nombre", "Nombre", "FIRM_Nombre");
              this.grdItemsFirmas.Columns.Add("FIRM_Cargo", "Cargo", "FIRM_Cargo");
              grdItemsFirmas.BestFitColumns();
              Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsFirmas);
              //grdItemsFirmas.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

              this.grdItemsFirmas.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
              this.grdItemsFirmas.MultiSelect = false;

              this.grdItemsFirmas.ShowFilteringRow = false;
              this.grdItemsFirmas.EnableFiltering = false;
              this.grdItemsFirmas.MasterTemplate.EnableFiltering = false;
              this.grdItemsFirmas.EnableGrouping = false;
              this.grdItemsFirmas.MasterTemplate.EnableGrouping = false;
              this.grdItemsFirmas.EnableSorting = false;
              this.grdItemsFirmas.MasterTemplate.EnableCustomSorting = false;

              this.grdItemsFirmas.ReadOnly = false;
              this.grdItemsFirmas.AllowEditRow = true;

              this.grdItemsFirmas.Columns["FIRM_Codigo"].ReadOnly = true;
              this.grdItemsFirmas.Columns["FIRM_Nombre"].ReadOnly = false;
              this.grdItemsFirmas.Columns["FIRM_Cargo"].ReadOnly = false;
              
              this.grdItemsFirmas.Columns["FIRM_Codigo"].Width = 80;
              this.grdItemsFirmas.Columns["FIRM_Nombre"].Width = 200;
              this.grdItemsFirmas.Columns["FIRM_Cargo"].Width = 200;


              

          }
          catch (Exception ex)
          { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex); }
      }
      private void NuevaFirma()
      {
          if (BSItemsFirmas != null)
          {
              Entities.Firmas _firma = new Entities.Firmas();
              Int32 _FIRM_Item = 0;
              if (((ObservableCollection<Entities.Firmas>)BSItemsFirmas.DataSource).Count > 0)
              { _FIRM_Item = ((ObservableCollection<Entities.Firmas>)BSItemsFirmas.DataSource).Max(dcot => dcot.FIRM_Codigo); }
              _firma.FIRM_Codigo = Convert.ToInt16(_FIRM_Item + 1);
              _firma.AUDI_UsrCrea = Presenter.Session.UserName;
              _firma.AUDI_FecCrea = Presenter.Session.Fecha;
              _firma.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
              BSItemsFirmas.Add(_firma);
              BSItemsFirmas.ResetBindings(true);
          }
      }
      private void EliminarFirma()
      {
          try
          {
              if (BSItemsFirmas.Current != null && BSItemsFirmas.Current is Entities.Firmas)
              {
                  if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Esta seguro que desea eliminar la Firma?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
                  {
                      Entities.Firmas _itemFirmas = ((BSItemsFirmas.Current as Entities.Firmas).Clone() as Entities.Firmas);
                      if (_itemFirmas.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
                      {
                          //_itemCuentaBancosUsuarios.AUDI_UsrMod = Presenter.Session.UserName;
                          //_itemCuentaBancosUsuarios.AUDI_FecMod = Presenter.Session.Fecha;
                          _itemFirmas.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                          Presenter.Item.ListFirmasEliminadas.Add(_itemFirmas);
                      }

                      BSItemsFirmas.RemoveCurrent();
                      BSItemsFirmas.ResetBindings(true);
                  }
              }
          }
          catch (Exception ex)
          { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar un usuario", ex); }
      }
      #endregion

      #endregion

      #region [ Eventos ]
      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Guardar(true))
            {
               this.FormClosing -= MView_FormClosing;
               //errorProviderCab_Cotizacion_OV.Dispose();
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
            errorProviderCuentasBancarias.Dispose();
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

      private void tsbtnNuevaChequera_Click(object sender, EventArgs e)
      { NuevaChequera(); }

      private void grdItemsChequera_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     EditarChequera();
                     break;
                  case "Eliminar":
                     EliminarChequera();
                     //SeleccionarItem();
                     //Presenter.Eliminar();
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }
      }
      void grdItemsChequera_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            if (e.CellElement is GridCommandCellElement)
            {
               if (e.Column.Name.Equals("Edit"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.editar16x16;
                     bte.ToolTipText = @"Editar Registro";
                     bte.AutoSize = true;
                  }
               }
               if (e.Column.Name.Equals("Delete"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.Sign_07;
                     bte.ToolTipText = @"Eliminar Registro";
                     bte.AutoSize = true;
                  }
               }
               if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
               {
                  ((RadButtonElement)e.CellElement.Children[0]).Visibility = ElementVisibility.Hidden;
               }
            }
         }
         catch (Exception ex) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }


      #region [ Seguridad ]
      private void grdItemsSeguridad_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            if (e.CellElement is GridCommandCellElement)
            {
               //if (e.Column.Name.Equals("Edit"))
               //{
               //   RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
               //   if (bte.Image == null)
               //   {
               //      bte.TextImageRelation = TextImageRelation.Overlay;
               //      bte.DisplayStyle = DisplayStyle.Image;
               //      bte.ImageAlignment = ContentAlignment.MiddleCenter;
               //      bte.Image = Resources.editar16x16;
               //      bte.ToolTipText = @"Editar Registro";
               //      bte.AutoSize = true;
               //   }
               //}
               if (e.Column.Name.Equals("Delete"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.Sign_07;
                     bte.ToolTipText = @"Eliminar Registro";
                     bte.AutoSize = true;
                  }
               }
               if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
               {
                  ((RadButtonElement)e.CellElement.Children[0]).Visibility = ElementVisibility.Hidden;
               }
            }
         }
         catch (Exception ex) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      private void grdItemsSeguridad_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((sender as Telerik.WinControls.UI.GridCommandCellElement).ColumnInfo.Name)
               {
                  case "Delete":
                     EliminarSeguridad();
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el botón de la grilla de contenedores.", ex); }
      }
      private void BSItemsChequera_CurrentChanged(object sender, EventArgs e)
      {
         try
         {
            if (BSItemsChequera.Current != null)
            {
               Entities.Chequera _chequera = (BSItemsChequera.Current as Entities.Chequera);
               SetCoordenadas(_chequera.CHEQ_Coordenadas);
               //_chequera.CHEQ_Coordenadas = GetCoordenadas();
            }
         }
         catch (Exception)
         { }
      }
      private void tsbtnNuevoUsuario_Click(object sender, EventArgs e)
      {
         NuevaSeguridad();
      }
      #endregion

      #region [Firmas]
      private void grdItemsFirmas_CellFormatting(object sender, CellFormattingEventArgs e)
      {
          try
          {
              if (e.CellElement is GridCommandCellElement)
              {
                  //if (e.Column.Name.Equals("Edit"))
                  //{
                  //   RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  //   if (bte.Image == null)
                  //   {
                  //      bte.TextImageRelation = TextImageRelation.Overlay;
                  //      bte.DisplayStyle = DisplayStyle.Image;
                  //      bte.ImageAlignment = ContentAlignment.MiddleCenter;
                  //      bte.Image = Resources.editar16x16;
                  //      bte.ToolTipText = @"Editar Registro";
                  //      bte.AutoSize = true;
                  //   }
                  //}
                  if (e.Column.Name.Equals("Delete"))
                  {
                      RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                      if (bte.Image == null)
                      {
                          bte.TextImageRelation = TextImageRelation.Overlay;
                          bte.DisplayStyle = DisplayStyle.Image;
                          bte.ImageAlignment = ContentAlignment.MiddleCenter;
                          bte.Image = Resources.Sign_07;
                          bte.ToolTipText = @"Eliminar Registro";
                          bte.AutoSize = true;
                      }
                  }
                  if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
                  {
                      ((RadButtonElement)e.CellElement.Children[0]).Visibility = ElementVisibility.Hidden;
                  }
              }
          }
          catch (Exception ex) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      private void grdItemsFirmas_CommandCellClick(object sender, EventArgs e)
      {
          try
          {
              if (sender is Telerik.WinControls.UI.GridCommandCellElement)
              {
                  switch ((sender as Telerik.WinControls.UI.GridCommandCellElement).ColumnInfo.Name)
                  {
                      case "Delete":
                          EliminarFirma();
                          break;
                  }
              }
          }
          catch (Exception ex)
          { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el botón de la grilla de contenedores.", ex); }
      }
      private void tsbtnNuevaFirma_Click(object sender, EventArgs e)
      {
          NuevaFirma();
      }
      #endregion

      void txnCFecha_X_LostFocus(object sender, EventArgs e)
      {
         try
         {
            if (BSItemsChequera.Current != null)
            {
               Entities.Chequera _chequera = (BSItemsChequera.Current as Entities.Chequera);
               //SetCoordenadas(_chequera.CHEQ_Coordenadas);
               _chequera.CHEQ_Coordenadas = GetCoordenadas();
            }
         }
         catch (Exception)
         { }
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

      private void chkCUBA_CtaEmprVinculada_CheckedChanged(object sender, EventArgs e)
      {
         try
         {
            lblCUBA_CuenPuente.Enabled = chkCUBA_CtaEmprVinculada.Checked;
            txtCUBA_CuenPuente.Enabled = chkCUBA_CtaEmprVinculada.Checked;
            txtCUBA_SubCtaEgresoEV.Enabled = chkCUBA_CtaEmprVinculada.Checked;
            txtCUBA_SubCtaIngresoEV.Enabled = chkCUBA_CtaEmprVinculada.Checked;
            lblCUBA_SubCtaEgresoEV.Enabled = chkCUBA_CtaEmprVinculada.Checked;
            lblCUBA_SubCtaIngresoEV.Enabled = chkCUBA_CtaEmprVinculada.Checked;
            if (!chkCUBA_CtaEmprVinculada.Checked) 
            { 
               txtCUBA_CuenPuente.Clear();
               txtCUBA_SubCtaEgresoEV.Clear();
               txtCUBA_SubCtaIngresoEV.Clear();
            }

         }
         catch (Exception)
         { }
      }

      #endregion
   }
}