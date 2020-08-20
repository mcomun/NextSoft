using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using Delfin.Controls;
using Delfin.Entities;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.Constants;
using Telerik.WinControls.UI;
using Delfin.Principal.Properties;
using Telerik.WinControls;
using TiposEntidad = Delfin.Controls.TiposEntidad;

namespace Delfin.Principal
{
   public partial class CAJ002IngresosEgresosMView : Form, ICAJ002IngresosEgresosMView
   {
      #region [ Variables ]

      public enum TipoInicio
      {
         Nuevo = 0, Editar = 1
      }

      #endregion

      #region [ Formulario ]

      public CAJ002IngresosEgresosMView(TipoInicio x_TInicio)
      {
         InitializeComponent();
         try
         {
            this.FormClosing += MView_FormClosing;
            this.FormClosed += CAJ002IngresosEgresosMView_FormClosed;

            TInicio = x_TInicio;

            BSItemsDocumentos = new BindingSource();
            grdItemsDocumentos.DataSource = BSItemsDocumentos;

            BSItemsConciliacion = new BindingSource();
            grdItemsConciliacion.DataSource = BSItemsConciliacion;

            BSItemsFlujo = new BindingSource();
            grdItemsFlujo.DataSource = BSItemsFlujo;

            BSItemsMovimientosFlujo = new BindingSource();
            grdItemsFlujo.DataSource = BSItemsMovimientosFlujo;

            BSItemsTipificacion = new BindingSource();
            grdItemsTipificacion.DataSource = BSItemsTipificacion;

            txtMOVI_NroOficina.MaxLength = 20;
            txtMOVI_Concepto.MaxLength = 100;
            txtMOVI_Referencia.MaxLength = 100;
            txnMOVI_NroOperacion.MaxLength = 20;

            txaCUBA_NroCuenta.Tag = "CUBA_CodigoMSGERROR";
            txaENTC_Codigo.Tag = "ENTC_CodigoMSGERROR";
            txtMOVI_Concepto.Tag = "MOVI_ConceptoMSGERROR";
            txtMOVI_NroOficina.Tag = "MOVI_NroOficinaMSGERROR";
            txtMOVI_Referencia.Tag = "MOVI_ReferenciaMSGERROR";
            cmbTIPO_CodMND.Tag = "TIPO_CodMNDMSGERROR";
            cmbTIPO_CodMOV.Tag = "TIPO_CodMOVMSGERROR";
            txnMOVI_NroOperacion.Tag = "MOVI_NroOperacionMSGERROR";
            txnMOVI_TipoCambio.Tag = "MOVI_TipoCambioMSGERROR";
            dtpMOVI_FecDiferido.Tag = "MOVI_FecDiferidoMSGERROR";
            dtpMOVI_FecEmision.Tag = "MOVI_FecEmisionMSGERROR";
            cmbTIPO_CodDES.Tag = "TIPO_CodDESMSGERROR";
            txnMOVI_MontoDescuadre.Tag = "MOVI_MontoDescuadreMSGERROR";
            txnMonto.Tag = "MontoMSGERROR";
            dtpMOVI_FecOperacion.Tag = "MOVI_FecOperacionMSGERROR";
            cmbTIPO_CodMDP.Tag = "TIPO_CodMDPMSGERROR";

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;
            btnAceptar.Click += btnAceptar_Click;
            btnEjecutarDiferido.Click += btnEjecutarDiferido_Click;
            btnRediferir.Click += btnRediferir_Click;
            btnNuevoDocumento.Click += btnNuevoDocumento_Click;
            btnNuevoFlujo.Click += btnNuevoFlujo_Click;
            tsbtnNuevoDocumento.Click += btnNuevoDocumento_Click;
            btnCtaCteDescuadre.Click += btnCtaCteDescuadre_Click;
            btnCopy.Click += btnCopy_Click;
            btnTipificacion.Click += btnTipificacion_Click;

            txaCUBA_NroCuenta.SelectedItemCuentaBancariaChanged += txaCUBA_NroCuenta_SelectedItemCuentaBancariaChanged;
            txnMonto.LostFocus += txnMonto_LostFocus;

            grdItemsDocumentos.CellFormatting += grdItemsDocumentos_CellFormatting;
            grdItemsDocumentos.CommandCellClick += grdItemsDocumentos_CommandCellClick;
            grdItemsDocumentos.CellEndEdit += grdItemsDocumentos_CellEndEdit;

            grdItemsTipificacion.CellFormatting += grdItemsTipificacion_CellFormatting;
            grdItemsTipificacion.CommandCellClick += grdItemsTipificacion_CommandCellClick;
            cmbTIPO_CodMOV.SelectedIndexChanged += cmbTIPO_CodMOV_SelectedIndexChanged;
            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;

            grdItemsFlujo.CommandCellClick += grdItemsFlujo_CommandCellClick;
            grdItemsFlujo.CellFormatting += grdItemsFlujo_CellFormatting;
            this.Load += CAJ002IngresosEgresosMView_Load;
            dtpMOVI_FecEmision.SelectedDateChanged += dtpMOVI_FecEmision_SelectedDateChanged;
            //dtpMOVI_FecEmision.LostFocus += dtpMOVI_FecEmision_SelectedDateChanged;

            btnAbrir.Visible = false;
            btnAceptar.Visible = false;
            btnEjecutarDiferido.Visible = false;
            dtpMOVI_FecEjecutado.Enabled = false;
            dtpMOVI_FecEjecutado2.Enabled = false;
            btnRediferir.Visible = false;
            chkGeneraCtaCte.Enabled = false;
            txtNroCtaCte.Enabled = false;
            txtCentroCosto.Enabled = false;
            chkGeneraCtaCte.Visible = false;
            txtNroCtaCte.Visible = true;
            txtCentroCosto.Visible = true;

            txtMOVI_Codigo.Enabled = false;
            lblMOVI_Codigo.Enabled = false;
            lblCONS_CodEST.Enabled = false;
            cmbCONS_CodEST.Enabled = false;
            cmbTIPO_CodMND.Enabled = false;
            txaENTC_Codigo.Enabled = false;
            txnMOVI_MontoDescuadre.Enabled = false;
            txtMOVI_UserAnulacion.ReadOnly = true;
            dtpMOVI_FecAnulacion.Enabled = false;
            txtMOVI_GlosaAnulacion.ReadOnly = true;
            lblMensaje.Visible = false;
            txtMOVI_DocNumero.ReadOnly = true;
            cmbPLAN_Tipo.Enabled = false;
            dtpPLAN_FechaEmision.Enabled = false;
            txtPLAN_Codigo.ReadOnly = true;
            txtNroOperacionPlanillas.ReadOnly = true;
            lblMensaje.Visible = false;
            txtPendiente.ReadOnly = true;
            txtDifDescuadre.ReadOnly = true;

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      void dtpMOVI_FecEmision_SelectedDateChanged(object sender, EventArgs e)
      {
         try
         {
            try
            {
               if (dtpMOVI_FecEmision.NSFecha.HasValue)
               {
                  txnMOVI_TipoCambio.Value = Presenter.GetTipoCambio(dtpMOVI_FecEmision.NSFecha.Value);
                  Presenter.TipoCambio = txnMOVI_TipoCambio.Value;
               }
               else { txnMOVI_TipoCambio.Value = Presenter.TipoCambio; }
            }
            catch (Exception)
            { }
         }
         catch (Exception)
         { }
      }

      private void CAJ002IngresosEgresosMView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }

      private void CAJ002IngresosEgresosMView_Load(object sender, EventArgs e)
      {
         tabIngresos.SelectedTab = pageGenerales;
      }

      #endregion

      #region [ Propiedades ]

      public CAJ002IngresosEgresosPresenter Presenter { get; set; }
      public CAJ002IngresosEgresosPresenter PresenterBase { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }

      public TipoInicio TInicio { get; set; }

      public BindingSource BSItemsDocumentos { get; set; }
      public BindingSource BSItemsConciliacion { get; set; }
      public BindingSource BSItemsFlujo { get; set; }
      public BindingSource BSItemsFirmas { get; set; }
      public BindingSource BSItemsMovimientosFlujo { get; set; }
      public BindingSource BSItemsTipificacion { get; set; }

      #endregion

      #region [ CAJ002IngresosEgresosMView ]

      public void LoadView()
      {
         try
         {
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, Delfin.Controls.TiposEntidad.TIPE_Cliente, null, null, true);
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Ayuda Moneda", "MND", "< Sel.  Moneda >", ListSortDirection.Ascending);
            cmbTIPO_CodMOV.LoadControl(Presenter.ListTiposMOV, "Ayuda Movimiento", "< Sel. Tipo Movimiento >", ListSortDirection.Ascending);
            cmbTIPO_CodMDP.LoadControl(Presenter.ContainerService, "Ayuda Medio de Pago", "MDP", "< Sel. Medio de Pago >", ListSortDirection.Ascending);
            txaCUBA_NroCuenta.LoadControl(Presenter.ContainerService, "Ayuda de Cuentas Bancarias", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Presenter.Session.UserName);
            cmbCONS_CodEST.LoadControl(Presenter.ContainerService, "Estado", "EST", "< Estado >", ListSortDirection.Ascending);

            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo de Entidad", "< Sel. Tipo de Entidad >", ListSortDirection.Ascending);
            cmbTIPO_CodSerie.LoadControl(Presenter.ContainerService, "Series de Ingresos", "SER", "< Seleccione Serie >", ListSortDirection.Ascending);

            cmbPLAN_Tipo.LoadControl("Ayuda de Tipo Plantilla", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.TipoPlantilla, "< Sel. Tipo Plantilla >", ListSortDirection.Ascending);

            cmbTIPO_CodDES.SelectedIndexChanged += cmbTIPO_CodDES_SelectedIndexChanged;

            FormatGridDocumentos();
            FormatGridConciliacion();
            FormatGridTipificacion();
            FormatGridFlujo();

            tlpDescuadre.Visible = false;
            btnTipificacion.Enabled = false;
            //pnlDescuadre.Visible = true;
            //btnNuevoDocumento.Location = new Point(btnNuevoDocumento.Location.X, btnNuevoDocumento.Location.Y + 27 * 2);

            lblENTC_Codigo.Text = "Entidad :";
            chkMOVI_NoNegociable.Visible = false;
            #region [ Movimiento Flujo ]
            BSItemsMovimientosFlujo.DataSource = null;
            grdItemsFlujo.DataSource = BSItemsMovimientosFlujo;
            navItemsFlujo.BindingSource = BSItemsMovimientosFlujo;
            BSItemsMovimientosFlujo.ResetBindings(true);
            #endregion

            #region [ Tipificación ]
            BSItemsTipificacion.DataSource = null;
            grdItemsTipificacion.DataSource = BSItemsTipificacion;
            navItemsTipificacion.BindingSource = BSItemsTipificacion;
            BSItemsTipificacion.ResetBindings(true);
            #endregion

            switch (Presenter.TMovimiento)
            {
               case TipoMovimientoCtaCte.Ingresos:
                  switch (TInicio)
                  {
                     case TipoInicio.Nuevo:
                        this.Text = "Ingresos [ Nuevo Registro ]";
                        dtpMOVI_FecOperacion.NSFecha = DateTime.Now;
                        break;
                     case TipoInicio.Editar:
                        this.Text = "Ingresos [ Editar Registro: {0:00000} /  Cliente: {1} - {2} ]";
                        break;
                     default:
                        throw new ArgumentOutOfRangeException();
                  }
                  txaENTC_Codigo.TiposEntidad = TiposEntidad.TIPE_Cliente;
                  tabIngresos.TabPages.Remove(pagePlanillas);
                  lblENTC_Codigo.Text = "Cliente :";
                  tableDatosGenerales.RowStyles[5].Height = 0;
                  lblMOVI_Numero.Visible = false;
                  txtMOVI_Numero.Visible = false;
                  lblMOVI_OrdenDe.Visible = false;
                  txtMOVI_OrdenDe.Visible = false;
                  //btnNuevoDocumento.Location = new Point(btnNuevoDocumento.Location.X, btnNuevoDocumento.Location.Y - 27 * 3);

                  cmbTIPO_CodDES.LoadControl(Presenter.ListTipoDES.Where(TDES => TDES.TIPO_Desc3 == "I" || String.IsNullOrEmpty(TDES.TIPO_Desc3)).ToObservableCollection(), "Tipo Descuadre", "< Sel. Tipificación >", ListSortDirection.Ascending);
                  break;
               case TipoMovimientoCtaCte.Egresos:
                  switch (TInicio)
                  {
                     case TipoInicio.Nuevo:
                        this.Text = "Egresos [ Nuevo Registro ]";
                        dtpMOVI_FecOperacion.NSFecha = DateTime.Now;
                        break;
                     case TipoInicio.Editar:
                        this.Text = "Egresos [ Editar Registro: {0:00000} / Entidad: {1} - {2} ]";
                        break;
                     default:
                        throw new ArgumentOutOfRangeException();
                  }
                  txaENTC_Codigo.TiposEntidad = TiposEntidad.TIPE_Proveedor;
                  lblENTC_Codigo.Text = "Entidad :";
                  //btnNuevoDocumento.Location = new Point(btnNuevoDocumento.Location.X, btnNuevoDocumento.Location.Y - 27 * 5);
                  //tableDatosGenerales.RowStyles[8].Height = 0;
                  //lblTIPO_CodSerie.Visible = false;
                  //cmbTIPO_CodSerie.Visible = false;
                  tlpReciboCaja.Visible = false;
                  pnlReciboCaja.Visible = false;
                  lblMOVI_DocNumero.Visible = false;
                  txtMOVI_DocNumero.Visible = false;
                  cmbTIPO_CodDES.LoadControl(Presenter.ListTipoDES.Where(TDES => TDES.TIPO_Desc3 == "E" || String.IsNullOrEmpty(TDES.TIPO_Desc3)).ToObservableCollection(), "Tipo Descuadre", "< Sel. Tipificación >", ListSortDirection.Ascending);
                  break;
            }
            switch (Presenter.TipoInicio)
            {
               case CAJ002IngresosEgresosPresenter.TInicio.Normal:
                  btnAceptar.Visible = false;
                  break;
               case CAJ002IngresosEgresosPresenter.TInicio.SoloMovimiento:
                  btnAceptar.Visible = true;
                  btnGuardar.Visible = false;
                  this.pnlTDetalle.Visible = false;
                  grdItemsDocumentos.Visible = false;
                  navItems.Visible = false;
                  btnNuevoDocumento.Visible = false;
                  tabIngresos.TabPages.Clear();
                  tabIngresos.TabPages.Add(pageGenerales);
                  //tlpDescuadre.Visible = false;
                  //pnlDescuadre.Visible = false;
                  btnTipificacion.Enabled = false;
                  tbcDetalle.TabPages.Remove(tpgTipificaciones);

                  tableDatosGenerales.RowStyles[3].Height = 0;
                  cmbTIPE_Codigo.Enabled = false;
                  cmbTIPE_Codigo.Visible = false;
                  txaENTC_Codigo.Enabled = false;
                  txaENTC_Codigo.Visible = false;
                  lblTIPE_Codigo.Visible = false;
                  lblENTC_Codigo.Visible = false;
                  cmbTIPO_CodMOV.Enabled = false;
                  cmbTIPO_CodMOV.SelectedIndexChanged -= cmbTIPO_CodMOV_SelectedIndexChanged;
                  break;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      private void cmbTIPO_CodDES_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPO_CodDES.TiposSelectedItem != null)
            {
               chkGeneraCtaCte.Visible = true;
               chkGeneraCtaCte.Checked = (cmbTIPO_CodDES.TiposSelectedItem.TIPO_Num1.HasValue ? cmbTIPO_CodDES.TiposSelectedItem.TIPO_Num1.Value == 1 : false);
               txtNroCtaCte.Visible = true;
               txtCentroCosto.Visible = true;
               txtNroCtaCte.Text = cmbTIPO_CodDES.TiposSelectedItem.TIPO_Desc2;
               txtCentroCosto.Text = cmbTIPO_CodDES.TiposSelectedItem.TIPO_Mascara;
            }
            else
            {
               chkGeneraCtaCte.Visible = true;
               chkGeneraCtaCte.Checked = false;
               txtNroCtaCte.Visible = true;
               txtNroCtaCte.Clear();
               txtCentroCosto.Visible = true;
               txtCentroCosto.Clear();
            }
         }
         catch (Exception)
         { }
      }

      public void ClearItem()
      {
         try
         {
            errorProviderMovimiento.Clear();

            #region [ Datos Generales ]

            txaCUBA_NroCuenta.ClearValue();
            txaENTC_Codigo.Clear();
            txtMOVI_Codigo.Clear();
            txtMOVI_Concepto.Clear();
            txtMOVI_NroOficina.Clear();
            txtMOVI_Referencia.Clear();
            txnMOVI_NroOperacion.Clear();
            txnMOVI_TipoCambio.Clear();

            cmbTIPO_CodMND.SelectedIndex = 0;
            cmbTIPO_CodMOV.SelectedIndex = 0;

            dtpMOVI_FecEmision.NSClear();
            dtpMOVI_FecOperacion.NSClear();
            dtpMOVI_FecDiferido.NSClear();

            BSItemsDocumentos.DataSource = null;
            BSItemsDocumentos.ResetBindings(true);

            #endregion
            #region [ Movimientos Flujo ]
            BSItemsMovimientosFlujo.DataSource = null;
            BSItemsMovimientosFlujo.ResetBindings(true);
            #endregion

            #region [ Tipificaciones ]
            BSItemsTipificacion.DataSource = null;
            BSItemsTipificacion.ResetBindings(true);
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

            #region [ Datos Generales ]

            if (txaCUBA_NroCuenta.SelectedItem != null)
            {
               Presenter.Item.CUBA_Codigo = txaCUBA_NroCuenta.SelectedItem.CUBA_Codigo;
               Presenter.Item.ItemCuentasBancarias = txaCUBA_NroCuenta.SelectedItem;
               Presenter.Item.CUBA_NroCuenta = txaCUBA_NroCuenta.SelectedItem.CUBA_NroCuenta;
            }
            else { Presenter.Item.CUBA_Codigo = null; }
            if (!String.IsNullOrEmpty(txtMOVI_Numero.Text)) { Presenter.Item.MOVI_Numero = txtMOVI_Numero.Text; }
            if (!String.IsNullOrEmpty(txtMOVI_OrdenDe.Text)) { Presenter.Item.MOVI_OrdenDe = txtMOVI_OrdenDe.Text; }
            if (cmbTIPO_CodMND.TiposSelectedItem != null) { Presenter.Item.TIPO_MND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_DescC; }
            if (cmbTIPO_CodMOV.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_CodMOV = cmbTIPO_CodMOV.TiposSelectedItem.TIPO_CodTipo;
               Presenter.Item.TIPO_TabMOV = cmbTIPO_CodMOV.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_Movimiento = cmbTIPO_CodMOV.TiposSelectedItem;
            }
            else { Presenter.Item.TIPO_CodMOV = null; Presenter.Item.TIPO_TabMOV = null; }
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null) { Presenter.Item.TIPE_Codigo = cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo; } else { Presenter.Item.TIPE_Codigo = null; }
            if (txaENTC_Codigo.SelectedItem != null)
            {
               Presenter.Item.ENTC_Codigo = txaENTC_Codigo.SelectedItem.ENTC_Codigo;
               Presenter.Item.TIPE_Codigo = Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(txaENTC_Codigo.TiposEntidad);
            }
            else { Presenter.Item.ENTC_Codigo = null; }
            if (dtpMOVI_FecEmision.NSFecha.HasValue) { Presenter.Item.MOVI_FecEmision = dtpMOVI_FecEmision.NSFecha.Value.Date; } else { Presenter.Item.MOVI_FecEmision = null; }
            if (dtpMOVI_FecOperacion.NSFecha.HasValue) { Presenter.Item.MOVI_FecOperacion = dtpMOVI_FecOperacion.NSFecha.Value.Date; } else { Presenter.Item.MOVI_FecOperacion = null; }
            if (!String.IsNullOrEmpty(txtMOVI_NroOficina.Text)) { Presenter.Item.MOVI_NroOficina = txtMOVI_NroOficina.Text; } else { Presenter.Item.MOVI_NroOficina = null; }
            if (!String.IsNullOrEmpty(txnMOVI_NroOperacion.Text)) { Presenter.Item.MOVI_NroOperacion = (txnMOVI_NroOperacion.Text); } else { Presenter.Item.MOVI_NroOperacion = null; }
            if (txnMOVI_TipoCambio.Value > 0) { Presenter.Item.MOVI_TipoCambio = txnMOVI_TipoCambio.Value; } else { Presenter.Item.MOVI_TipoCambio = null; }
            if (!String.IsNullOrEmpty(txtMOVI_Referencia.Text)) { Presenter.Item.MOVI_Referencia = txtMOVI_Referencia.Text; } else { Presenter.Item.MOVI_Referencia = null; }
            if (!String.IsNullOrEmpty(txtMOVI_Concepto.Text)) { Presenter.Item.MOVI_Concepto = txtMOVI_Concepto.Text; } else { Presenter.Item.MOVI_Concepto = null; }
            if (dtpMOVI_FecDiferido.NSFecha.HasValue && dtpMOVI_FecDiferido.Visible) { Presenter.Item.MOVI_FecDiferido = dtpMOVI_FecDiferido.NSFecha; }
            else { Presenter.Item.MOVI_FecDiferido = null; }
            if (dtpMOVI_FecEjecutado.NSFecha.HasValue && dtpMOVI_FecEjecutado.Visible) { Presenter.Item.MOVI_FecEjecutado = dtpMOVI_FecEjecutado.NSFecha; }
            else { Presenter.Item.MOVI_FecEjecutado = null; }
            if (cmbTIPO_CodMDP.TiposSelectedItem != null) { Presenter.Item.TIPO_CodMDP = cmbTIPO_CodMDP.TiposSelectedItem.TIPO_CodTipo; Presenter.Item.TIPO_TabMDP = cmbTIPO_CodMDP.TiposSelectedItem.TIPO_CodTabla; }
            else { Presenter.Item.TIPO_CodMDP = null; Presenter.Item.TIPO_TabMDP = null; }
            //if (txnMonto.Value > 0)
            //{
            Presenter.Item.Monto = txnMonto.Value;
            switch (Presenter.TMovimiento)
            {
               case TipoMovimientoCtaCte.Ingresos:
                  Presenter.Item.MOVI_MontoDebe = txnMonto.Value;
                  break;
               case TipoMovimientoCtaCte.Egresos:
                  Presenter.Item.MOVI_MontoHaber = txnMonto.Value;
                  break;
            }
            //}
            Presenter.Item.TIPO_CodDES = null;
            Presenter.Item.TIPO_TabDES = null;
            Presenter.Item.MOVI_MontoDescuadre = null;
            Presenter.Item.MOVI_NoNegociable = chkMOVI_NoNegociable.Checked;
            if (Presenter.Item.TieneDescuadre)
            {
               if (cmbTIPO_CodDES.TiposSelectedItem != null)
               {
                  Presenter.Item.TIPO_TabDES = cmbTIPO_CodDES.TiposSelectedItem.TIPO_CodTabla;
                  Presenter.Item.TIPO_CodDES = cmbTIPO_CodDES.TiposSelectedItem.TIPO_CodTipo;
                  Presenter.Item.GeneraCtaCte = (cmbTIPO_CodDES.TiposSelectedItem.TIPO_Num1.HasValue ? cmbTIPO_CodDES.TiposSelectedItem.TIPO_Num1.Value : 0) == 1;
               }
               if (txnMOVI_MontoDescuadre.Value != 0)
               {
                  if (chkGeneraCtaCte.Checked)
                  { Presenter.Item.MOVI_MontoDescuadre = txnMOVI_MontoDescuadre.Value; }
                  else
                  {
                     Decimal _descuadre = txnMOVI_MontoDescuadre.Value;
                     try
                     { _descuadre = Convert.ToDecimal(txnMOVI_MontoDescuadre.Tag); }
                     catch (Exception)
                     {
                        getDescuadre();
                        _descuadre = Convert.ToDecimal(txnMOVI_MontoDescuadre.Tag);
                     }
                     Presenter.Item.MOVI_MontoDescuadre = _descuadre;
                  }
               }
            }

            Presenter.Item.TIPO_TabSerie = null;
            Presenter.Item.TIPO_CodSerie = null;
            if (cmbTIPO_CodSerie.TiposSelectedItem != null)
            { Presenter.Item.TIPO_CodSerie = cmbTIPO_CodSerie.TiposSelectedItem.TIPO_CodTipo; Presenter.Item.TIPO_TabSerie = cmbTIPO_CodSerie.TiposSelectedItem.TIPO_CodTabla; }

            Presenter.Item.Oficina_Operacion = String.Format("{0} / {1}", Presenter.Item.MOVI_NroOficina, Presenter.Item.MOVI_NroOperacion);

            #endregion

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en GetItem.", ex); }
      }

      public void SetItem()
      {
         try
         {
            if (Presenter != null & Presenter.Item != null)
            {
               if (Presenter.Item.CUBA_Codigo != null)
               {
                  txaCUBA_NroCuenta.SetCuentaBancaria(Presenter.Item.EMPR_Codigo, Presenter.Item.CUBA_Codigo);
                  cmbTIPO_CodMND.SelectedValue = txaCUBA_NroCuenta.SelectedItem.TIPO_CodMND;
               }
               else if (Presenter.Item.ItemCuentasBancarias != null)
               {
                  txaCUBA_NroCuenta.SetCuentaBancaria(Presenter.Item.ItemCuentasBancarias);
                  cmbTIPO_CodMND.SelectedValue = txaCUBA_NroCuenta.SelectedItem.TIPO_CodMND;
               }
               if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodMOV)) { cmbTIPO_CodMOV.TiposSelectedValue = Presenter.Item.TIPO_CodMOV; }
               if (Presenter.Item.TIPE_Codigo.HasValue) { cmbTIPE_Codigo.TipoEntidadSelectedValue = Presenter.Item.TIPE_Codigo.Value; }
               if (Presenter.Item.ENTC_Codigo.HasValue) { txaENTC_Codigo.SetEntidad(Presenter.Item.ENTC_Codigo); }

               if (Presenter.Item.MOVI_Codigo != 0)
               {
                  txtMOVI_Codigo.Text = Presenter.Item.MOVI_Codigo.ToString();
                  if (txaENTC_Codigo.SelectedItem != null)
                  {
                     this.Text = String.Format(this.Text, Presenter.Item.MOVI_Codigo, txaENTC_Codigo.SelectedItem.ENTC_DocIden, txaENTC_Codigo.SelectedItem.ENTC_RazonSocial);
                  }
               }
               if (Presenter.Item.MOVI_FecEmision.HasValue) { dtpMOVI_FecEmision.NSFecha = Presenter.Item.MOVI_FecEmision; }
               if (Presenter.Item.MOVI_FecDiferido.HasValue) { dtpMOVI_FecDiferido.NSFecha = Presenter.Item.MOVI_FecDiferido; }
               if (Presenter.Item.MOVI_FecEjecutado.HasValue) { dtpMOVI_FecEjecutado.NSFecha = Presenter.Item.MOVI_FecEjecutado; dtpMOVI_FecEjecutado2.NSFecha = Presenter.Item.MOVI_FecEjecutado; }
               if (Presenter.Item.MOVI_FecOperacion.HasValue) { dtpMOVI_FecOperacion.NSFecha = Presenter.Item.MOVI_FecOperacion; }
               if (!String.IsNullOrEmpty(Presenter.Item.MOVI_Numero)) { txtMOVI_Numero.Text = Presenter.Item.MOVI_Numero; }
               if (!String.IsNullOrEmpty(Presenter.Item.MOVI_OrdenDe)) { txtMOVI_OrdenDe.Text = Presenter.Item.MOVI_OrdenDe; }
               if (!String.IsNullOrEmpty(Presenter.Item.MOVI_NroOficina)) { txtMOVI_NroOficina.Text = Presenter.Item.MOVI_NroOficina; }
               if (!String.IsNullOrEmpty(Presenter.Item.MOVI_NroOperacion)) { txnMOVI_NroOperacion.Text = Presenter.Item.MOVI_NroOperacion; }
               if (!String.IsNullOrEmpty(Presenter.Item.MOVI_Referencia)) { txtMOVI_Referencia.Text = Presenter.Item.MOVI_Referencia; }
               if (!String.IsNullOrEmpty(Presenter.Item.MOVI_Concepto)) { txtMOVI_Concepto.Text = Presenter.Item.MOVI_Concepto; }
               if (Presenter.Item.CONS_CodEST != null) { cmbCONS_CodEST.ConstantesSelectedValue = Presenter.Item.CONS_CodEST; }
               if (Presenter.Item.Monto > 0) { txnMonto.Value = Presenter.Item.Monto; }

               if (Presenter.Item.MOVI_UserAnulacion != null) { txtMOVI_UserAnulacion.Text = Presenter.Item.MOVI_UserAnulacion; }
               if (Presenter.Item.MOVI_FecAnulacion != null) { dtpMOVI_FecAnulacion.NSFecha = Presenter.Item.MOVI_FecAnulacion; }
               if (Presenter.Item.MOVI_GlosaAnulacion != null) { txtMOVI_GlosaAnulacion.Text = Presenter.Item.MOVI_GlosaAnulacion; }
               if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodMDP)) { cmbTIPO_CodMDP.SelectedValue = Presenter.Item.TIPO_CodMDP; }
               btnCtaCteDescuadre.Enabled = false;
               if (Presenter.Item.TieneDescuadre)
               {
                  //if (!pnlDescuadre.Visible) { btnNuevoDocumento.Location = new Point(btnNuevoDocumento.Location.X, btnNuevoDocumento.Location.Y + 27 * 2); }
                  //tlpDescuadre.Visible = true;
                  //pnlDescuadre.Visible = true;
                  btnTipificacion.Enabled = true;

                  if (Presenter.Item.TIPO_CodDES != null)
                  {
                     cmbTIPO_CodDES.TiposSelectedValue = Presenter.Item.TIPO_CodDES;
                     btnCtaCteDescuadre.Enabled = (cmbTIPO_CodDES.TiposSelectedItem.TIPO_Num1 == 1);
                  }
                  if (Presenter.Item.MOVI_MontoDescuadre.HasValue) { txnMOVI_MontoDescuadre.Value = Presenter.Item.MOVI_MontoDescuadre.Value; }
               }
               if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodSerie)) { cmbTIPO_CodSerie.TiposSelectedValue = Presenter.Item.TIPO_CodSerie; }
               if (Presenter.Item.MOVI_DocNumero.HasValue) { txtMOVI_DocNumero.Text = Presenter.Item.MOVI_DocNumero.ToString(); }
               if (Presenter.Item.ItemPlanillas != null)
               {
                  cmbPLAN_Tipo.SelectedValue = Presenter.Item.ItemPlanillas.PLAN_Tipo;
                  dtpPLAN_FechaEmision.NSFecha = Presenter.Item.ItemPlanillas.PLAN_FechaEmision;
                  txtPLAN_Codigo.Text = Presenter.Item.ItemPlanillas.PLAN_Codigo;
                  txtNroOperacionPlanillas.Text = Presenter.Item.ItemPlanillas.PLAN_Lote;
               }
               chkMOVI_NoNegociable.Checked = Presenter.Item.MOVI_NoNegociable;
               if (Presenter.Item.MOVI_TipoCambio != null)
               { txnMOVI_TipoCambio.Text = Presenter.Item.MOVI_TipoCambio.ToString(); }
               else
               { txnMOVI_TipoCambio.Value = Presenter.TipoCambio; }

               BSItemsDocumentos.DataSource = Presenter.Item.ListDetCtaCte;
               BSItemsDocumentos.ResetBindings(true);
               grdItemsDocumentos.BestFitColumns();
               navItems.BindingSource = BSItemsDocumentos;

               BSItemsMovimientosFlujo.DataSource = Presenter.Item.ListFlujos;
               BSItemsMovimientosFlujo.ResetBindings(true);

               BSItemsTipificacion.DataSource = Presenter.Item.ListTipificaciones;
               BSItemsTipificacion.ResetBindings(true);
               grdItemsTipificacion.BestFitColumns();

               BSItemsConciliacion.DataSource = Presenter.Item.ListConciliacion;
               BSItemsConciliacion.ResetBindings(true);

               this.grdItemsDocumentos.Columns["CCCT_Monto_Real_Text"].Width = 80;
               this.grdItemsDocumentos.Columns["CCCT_Pendiente"].Width = 80;
               this.grdItemsDocumentos.Columns["DCCT_TipoCambio"].Width = 80;
               this.grdItemsDocumentos.Columns["CCCT_Saldo_Text"].Width = 80;

               EnabledItem();
               tabIngresos.SelectedTab = pageGenerales;

               getDescuadre();
               CalcularDescuadre();

               HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en SetItem.", ex); }
      }

      private void EnabledItem(Boolean x_opcion = true)
      {
         try
         {
            btnGuardar.Enabled = x_opcion;
            btnNuevoDocumento.Enabled = x_opcion;

            txaCUBA_NroCuenta.Enabled = x_opcion;

            cmbTIPE_Codigo.Enabled = x_opcion;
            txaENTC_Codigo.Enabled = (cmbTIPE_Codigo.TipoEntidadSelectedItem != null ? x_opcion : false);

            if (Presenter != null && Presenter.Item != null && !Presenter.Item.ENTC_Codigo.HasValue) { cmbTIPE_Codigo.Enabled = true; txaENTC_Codigo.Enabled = true; }

            cmbTIPO_CodDES.Enabled = x_opcion;
            if (Presenter.TipoInicio != CAJ002IngresosEgresosPresenter.TInicio.SoloMovimiento)
            { cmbTIPO_CodMOV.Enabled = x_opcion; }

            grdItemsDocumentos.ReadOnly = !x_opcion;

            dtpMOVI_FecDiferido.Enabled = x_opcion;
            dtpMOVI_FecEjecutado.Enabled = false;
            dtpMOVI_FecEjecutado2.Enabled = false;
            dtpMOVI_FecEmision.Enabled = x_opcion;
            //tlpDescuadre.Enabled = x_opcion;

            txnMOVI_MontoDescuadre.ReadOnly = !x_opcion;
            txnMOVI_NroOperacion.ReadOnly = !x_opcion;
            txnMOVI_TipoCambio.ReadOnly = !x_opcion;
            txnMonto.ReadOnly = !x_opcion;

            txtMOVI_Concepto.ReadOnly = !x_opcion;
            txtMOVI_NroOficina.ReadOnly = !x_opcion;
            txtMOVI_Numero.ReadOnly = !x_opcion;
            txtMOVI_OrdenDe.ReadOnly = !x_opcion;
            txtMOVI_Referencia.ReadOnly = !x_opcion;

            cmbTIPO_CodSerie.Enabled = x_opcion;
            dtpMOVI_FecOperacion.Enabled = x_opcion;

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en EnabledItem.", ex); }
      }

      public void EnabledItemEditar(Boolean x_opcion = true)
      {
         try
         {
            cmbTIPO_CodMOV.Enabled = x_opcion;
            txaCUBA_NroCuenta.Enabled = x_opcion;

            cmbTIPE_Codigo.Enabled = x_opcion;
            txaENTC_Codigo.Enabled = (cmbTIPE_Codigo.TipoEntidadSelectedItem != null ? x_opcion : false);
            if (Presenter != null && Presenter.Item != null && !Presenter.Item.ENTC_Codigo.HasValue) { cmbTIPE_Codigo.Enabled = true; txaENTC_Codigo.Enabled = true; }

            dtpMOVI_FecDiferido.Enabled = true;
            dtpMOVI_FecEjecutado.Enabled = false;
            dtpMOVI_FecEjecutado2.Enabled = false;
            if (!x_opcion)
            {
               if (Presenter.TipoBusqueda == CAJ002IngresosEgresosPresenter.TBusqueda.Base)
               { this.grdItemsDocumentos.Columns["Delete"].IsVisible = true; }
               this.grdItemsDocumentos.Columns["CtaCte"].IsVisible = true;
            }
            //switch (Presenter.Item.TIPO_CodMOV)
            //{
            //   case String.Format("{0:000}", (int)Entities.Movimiento.TipoMovimiento.IngresosTransferenciaCuentasPropias):
            //   //case Presenter.Item.GetTipoMovimiento(Entities.Movimiento.TipoMovimiento.EgresosTransferenciaCuentasPropias):
            //      dtpMOVI_FecEmision.Enabled = false;
            //      break;
            //   default:
            //      break;
            //}

            if (Presenter.Item.TIPO_CodMOV.Equals(Presenter.Item.GetTipoMovimiento(Entities.Movimiento.TipoMovimiento.IngresosTransferenciaCuentasPropias)) ||
                Presenter.Item.TIPO_CodMOV.Equals(Presenter.Item.GetTipoMovimiento(Entities.Movimiento.TipoMovimiento.EgresosTransferenciaCuentasPropias)))
            {
               dtpMOVI_FecEmision.Enabled = false;
               btnGuardar.Enabled = false;
               EnabledItem(false);
            }
            if (Presenter.Item.TIPO_CodMOV.Equals(Presenter.Item.GetTipoMovimiento(Entities.Movimiento.TipoMovimiento.IngresosDiferidos)) && Presenter.Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
            {
               dtpMOVI_FecDiferido.Enabled = false;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en EnabledItem.", ex); }
      }

      public void SetDiferido()
      {
         try
         {
            btnEjecutarDiferido.Visible = true;
            btnRediferir.Visible = true;
            dtpMOVI_FecDiferido.Enabled = true;
         }
         catch (Exception)
         { throw; }
      }

      public void SetEjecutado()
      {
         try
         {
            btnGuardar.Enabled = false;

            EnabledItem(false);
            dtpMOVI_FecDiferido.Enabled = false;
         }
         catch (Exception)
         { throw; }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Movimiento>.Validate(Presenter.Item, this, errorProviderMovimiento);
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Movimiento>.SetTabError(tabIngresos, errorProviderMovimiento);
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, revise los detalles.", Presenter.Item.MensajeError);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }

      public void SetItemFlujo()
      {
         BSItemsFlujo.DataSource = Presenter.ItemsMovimientosFlujo.ToDataTable();
         grdItemsFlujo.DataSource = BSItemsFlujo;
      }

      #endregion

      #region [ Metodos ]

      private void FormatGridDocumentos()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsDocumentos.Columns.Clear();
            this.grdItemsDocumentos.AllowAddNewRow = false;

            GridViewCommandColumn commandColumn;
            if (Presenter.TipoBusqueda == CAJ002IngresosEgresosPresenter.TBusqueda.Base)
            {
               commandColumn = new GridViewCommandColumn();
               commandColumn.Name = "Delete";
               commandColumn.HeaderText = "Eliminar";
               commandColumn.DefaultText = "Eliminar";
               commandColumn.UseDefaultText = true;
               this.grdItemsDocumentos.Columns.Add(commandColumn);
               this.grdItemsDocumentos.Columns["Delete"].AllowSort = false;
               this.grdItemsDocumentos.Columns["Delete"].AllowFiltering = false;
            }
            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "CtaCte";
            commandColumn.HeaderText = "Cta Cte.";
            commandColumn.DefaultText = "CtaCte";
            commandColumn.UseDefaultText = true;
            this.grdItemsDocumentos.Columns.Add(commandColumn);
            this.grdItemsDocumentos.Columns["CtaCte"].AllowSort = false;
            this.grdItemsDocumentos.Columns["CtaCte"].WrapText = true;
            this.grdItemsDocumentos.Columns["CtaCte"].AllowFiltering = false;

            this.grdItemsDocumentos.Columns.Add("TIPO_TDO", "Tipo", "TIPO_TDO");
            this.grdItemsDocumentos.Columns.Add("CCCT_Serie", "Serie", "CCCT_Serie");
            this.grdItemsDocumentos.Columns.Add("CCCT_Numero", "Número", "CCCT_Numero");
            this.grdItemsDocumentos.Columns.Add("CCCT_FechaEmision", "Fecha", "CCCT_FechaEmision");
            this.grdItemsDocumentos.Columns["CCCT_FechaEmision"].FormatString = "{0:dd/MM/yyyy}";
            this.grdItemsDocumentos.Columns["CCCT_FechaEmision"].ReadOnly = true;
            //this.grdItemsDocumentos.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            this.grdItemsDocumentos.Columns.Add("TipoCtaCte", "Tipo", "TipoCtaCte");
            this.grdItemsDocumentos.Columns.Add("CCCT_Monto_Text", "Monto", "CCCT_Monto_Text");
            this.grdItemsDocumentos.Columns.Add("CCCT_Monto_Real_Text", "Monto Real", "CCCT_Monto_Real_Text");

            this.grdItemsDocumentos.Columns.Add("OV_OP", "OV / OP", "OV_OP");
            this.grdItemsDocumentos.Columns.Add("NAVE_Nombre", "Nave Viaje", "NAVE_Nombre");
            this.grdItemsDocumentos.Columns.Add("MBL_HBL", "MBL / HBL", "MBL_HBL");

            //this.grdItemsDocumentos.Columns.Add("CCCT_Pendiente", "Monto a Cancelar", "CCCT_Pendiente");
            GridViewDecimalColumn decimalColum = new GridViewDecimalColumn();
            decimalColum.Name = "CCCT_Pendiente";
            decimalColum.HeaderText = "Monto a Cancelar";
            decimalColum.FieldName = "CCCT_Pendiente";
            decimalColum.DecimalPlaces = 2;
            decimalColum.Maximum = 999999;
            decimalColum.Minimum = -9999999;
            this.grdItemsDocumentos.Columns.Add(decimalColum);
            this.grdItemsDocumentos.Columns["CCCT_Pendiente"].FormatString = "{0:#,###,##0.00}";
            this.grdItemsDocumentos.Columns["CCCT_Pendiente"].Width = 60;
            this.grdItemsDocumentos.Columns["CCCT_Pendiente"].WrapText = true;
            this.grdItemsDocumentos.Columns["CCCT_Pendiente"].TextAlignment = ContentAlignment.MiddleRight;
            this.grdItemsDocumentos.Columns["CCCT_Pendiente"].ReadOnly = false;

            //this.grdItemsDocumentos.Columns.Add("DCCT_TipoCambio", "Tipo de Cambio Delfin", "DCCT_TipoCambio");
            decimalColum = new GridViewDecimalColumn();
            decimalColum.Name = "DCCT_TipoCambio";
            decimalColum.HeaderText = "Tipo de Cambio Delfin";
            decimalColum.FieldName = "DCCT_TipoCambio";
            decimalColum.DecimalPlaces = 4;
            decimalColum.Maximum = 10;
            decimalColum.Minimum = 0;
            decimalColum.WrapText = true;
            this.grdItemsDocumentos.Columns.Add(decimalColum);
            this.grdItemsDocumentos.Columns["DCCT_TipoCambio"].FormatString = "{0:#,###,##0.0000}";
            this.grdItemsDocumentos.Columns["DCCT_TipoCambio"].Width = 60;
            this.grdItemsDocumentos.Columns["DCCT_TipoCambio"].TextAlignment = ContentAlignment.MiddleRight;
            this.grdItemsDocumentos.Columns["DCCT_TipoCambio"].WrapText = true;
            this.grdItemsDocumentos.Columns["DCCT_TipoCambio"].ReadOnly = false;

            this.grdItemsDocumentos.Columns.Add("CCCT_Saldo_Text", "Saldo", "CCCT_Saldo_Text");
            this.grdItemsDocumentos.Columns.Add("ENTC_RazonSocial", "Entidad", "ENTC_RazonSocial");
            this.grdItemsDocumentos.Columns.Add("CCCT_Codigo", "Nro.", "CCCT_Codigo");

            this.grdItemsDocumentos.Columns.Add("SERV_Codigo", "Código", "SERV_Codigo");
            this.grdItemsDocumentos.Columns.Add("SERV_Nombre_SPA", "Nombre.", "SERV_Nombre_SPA");
            this.grdItemsDocumentos.Columns.Add("MODULO", "Modulo", "MODULO");

            grdItemsDocumentos.Columns["TIPO_TDO"].ReadOnly = true;
            grdItemsDocumentos.Columns["CCCT_Serie"].ReadOnly = true;
            grdItemsDocumentos.Columns["CCCT_Numero"].ReadOnly = true;
            grdItemsDocumentos.Columns["OV_OP"].ReadOnly = true;
            grdItemsDocumentos.Columns["NAVE_Nombre"].ReadOnly = true;
            grdItemsDocumentos.Columns["MBL_HBL"].ReadOnly = true;
            //grdItemsDocumentos.Columns["TIPO_MND"].ReadOnly = true;
            grdItemsDocumentos.Columns["CCCT_Monto_Text"].ReadOnly = true;
            grdItemsDocumentos.Columns["CCCT_Monto_Text"].TextAlignment = ContentAlignment.MiddleRight;
            grdItemsDocumentos.Columns["CCCT_Monto_Text"].WrapText = true;
            grdItemsDocumentos.Columns["CCCT_Monto_Real_Text"].ReadOnly = true;
            grdItemsDocumentos.Columns["CCCT_Monto_Real_Text"].TextAlignment = ContentAlignment.MiddleRight;
            grdItemsDocumentos.Columns["CCCT_Monto_Real_Text"].WrapText = true;
            grdItemsDocumentos.Columns["ENTC_RazonSocial"].ReadOnly = true;
            grdItemsDocumentos.Columns["CCCT_Saldo_Text"].ReadOnly = true;
            grdItemsDocumentos.Columns["CCCT_Saldo_Text"].TextAlignment = ContentAlignment.MiddleRight;
            grdItemsDocumentos.Columns["CCCT_Codigo"].ReadOnly = true;
            grdItemsDocumentos.Columns["TipoCtaCte"].TextAlignment = ContentAlignment.MiddleCenter;
            grdItemsDocumentos.Columns["TipoCtaCte"].ReadOnly = true;
            grdItemsDocumentos.Columns["MODULO"].ReadOnly = true;
            if (Presenter.TMovimiento == TipoMovimientoCtaCte.Ingresos)
            {
               grdItemsDocumentos.Columns["SERV_Codigo"].ReadOnly = true;
               grdItemsDocumentos.Columns["SERV_Nombre_SPA"].ReadOnly = true;
            }

            /* Crear Grupor para Unir cabeceras */
            ColumnGroupsViewDefinition columnGroupsView = new ColumnGroupsViewDefinition();
            if (Presenter.TipoBusqueda == CAJ002IngresosEgresosPresenter.TBusqueda.Base)
            { columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("")); }
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(""));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Documento"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Datos Vinculados"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Monto a Cancelar"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Tipo de Cambio Delfin"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Saldo"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Cliente"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Transacción"));
            if (Presenter.TMovimiento == TipoMovimientoCtaCte.Ingresos)
            { columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Servicio")); }

            int index = 0;
            if (Presenter.TipoBusqueda == CAJ002IngresosEgresosPresenter.TBusqueda.Base)
            {
               columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
               columnGroupsView.ColumnGroups[index].ShowHeader = false;
               columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["Delete"]);
               index++;
            }
            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].ShowHeader = false;
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["CtaCte"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["TIPO_TDO"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["CCCT_Serie"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["CCCT_Numero"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["CCCT_FechaEmision"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["TipoCtaCte"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["CCCT_Monto_Text"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["CCCT_Monto_Real_Text"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["OV_OP"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["NAVE_Nombre"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["MBL_HBL"]);
            index++;

            //columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            //columnGroupsView.ColumnGroups[index].ShowHeader = false;
            //columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["TIPO_MND"]);
            //index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].ShowHeader = false;
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["CCCT_Pendiente"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].ShowHeader = false;
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["DCCT_TipoCambio"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].ShowHeader = false;
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["CCCT_Saldo_Text"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].ShowHeader = false;
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["ENTC_RazonSocial"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].ShowHeader = true;
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["CCCT_Codigo"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["MODULO"]);
            index++;

            if (Presenter.TMovimiento == TipoMovimientoCtaCte.Ingresos)
            {
               columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
               columnGroupsView.ColumnGroups[index].ShowHeader = true;
               columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["SERV_Codigo"]);
               columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsDocumentos.Columns["SERV_Nombre_SPA"]);
               index++;
            }
            grdItemsDocumentos.ViewDefinition = columnGroupsView;

            /* Propiedades Finales */
            grdItemsDocumentos.ReadOnly = false;
            grdItemsDocumentos.ShowFilteringRow = false;
            grdItemsDocumentos.EnableFiltering = false;
            grdItemsDocumentos.MasterTemplate.EnableFiltering = false;
            grdItemsDocumentos.EnableGrouping = false;
            grdItemsDocumentos.MasterTemplate.EnableGrouping = false;
            grdItemsDocumentos.EnableSorting = false;
            grdItemsDocumentos.MasterTemplate.EnableCustomSorting = false;

            //Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsDocumentos);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex); }
      }

      private void FormatGridConciliacion()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsConciliacion.Columns.Clear();
            this.grdItemsConciliacion.AllowAddNewRow = false;

            this.grdItemsConciliacion.Columns.Add("CONC_Codigo", "Item", "CONC_Codigo");
            this.grdItemsConciliacion.Columns.Add("CONC_FecConciliacion", "Fecha Conciliación", "CONC_FecConciliacion");
            this.grdItemsConciliacion.Columns.Add("CONC_MontoBCO", "Monto", "CONC_MontoBCO");
            this.grdItemsConciliacion.Columns.Add("AUDI_UsrCrea", "Usuario", "AUDI_UsrCrea");
            this.grdItemsConciliacion.Columns["CONC_FecConciliacion"].FormatString = "{0:dd/MM/yyyy}";
            /* Propiedades Finales */
            grdItemsConciliacion.ReadOnly = true;
            grdItemsConciliacion.ShowFilteringRow = false;
            grdItemsConciliacion.EnableFiltering = false;
            grdItemsConciliacion.MasterTemplate.EnableFiltering = false;
            grdItemsConciliacion.EnableGrouping = false;
            grdItemsConciliacion.MasterTemplate.EnableGrouping = false;
            grdItemsConciliacion.EnableSorting = false;
            grdItemsConciliacion.MasterTemplate.EnableCustomSorting = false;

            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsConciliacion);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex); }
      }

      private void FormatGridFlujo()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsFlujo.Columns.Clear();
            this.grdItemsFlujo.AllowAddNewRow = false;

            Telerik.WinControls.UI.GridViewCommandColumn commandColumn;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Editar";
            commandColumn.DefaultText = "Editar";
            commandColumn.UseDefaultText = true;
            this.grdItemsFlujo.Columns.Add(commandColumn);
            this.grdItemsFlujo.Columns["Edit"].AllowSort = false;
            this.grdItemsFlujo.Columns["Edit"].AllowFiltering = false;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItemsFlujo.Columns.Add(commandColumn);
            this.grdItemsFlujo.Columns["Delete"].AllowSort = false;
            this.grdItemsFlujo.Columns["Delete"].AllowFiltering = false;
            this.grdItemsFlujo.Columns.Add("MFLU_Item", "Código", "MFLU_Item");
            this.grdItemsFlujo.Columns.Add("FLUJ_Codigo", "Código Flujo", "FLUJ_Codigo");
            this.grdItemsFlujo.Columns.Add("FLUJ_Glosa", "Glosa", "FLUJ_Glosa");
            //this.grdItemsFlujo.Columns.Add("MFLU_Flujo", "Flujo", "MFLU_Flujo");
            this.grdItemsFlujo.Columns.Add("MFLU_Monto", "Monto", "MFLU_Monto");
            this.grdItemsFlujo.Columns.Add("MFLU_Porcentaje", "Porcentaje", "MFLU_Porcentaje");


            /* Propiedades Finales */
            grdItemsFlujo.ReadOnly = true;
            grdItemsFlujo.ShowFilteringRow = false;
            grdItemsFlujo.EnableFiltering = false;
            grdItemsFlujo.MasterTemplate.EnableFiltering = false;
            grdItemsFlujo.EnableGrouping = false;
            grdItemsFlujo.MasterTemplate.EnableGrouping = false;
            grdItemsFlujo.EnableSorting = false;
            grdItemsFlujo.MasterTemplate.EnableCustomSorting = false;

            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsFlujo);

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex); }
      }

      private void SeleccionarCuentaBancaria()
      {
         try
         {
            if (txaCUBA_NroCuenta.SelectedItem != null)
            {
               cmbTIPO_CodMND.SelectedValue = txaCUBA_NroCuenta.SelectedItem.TIPO_CodMND;
               if (cmbTIPO_CodMOV.TiposSelectedItem != null)
               {
                  cmbTIPO_CodMOV_SelectedIndexChanged(null, null);
               }
            }
            else
            {
               cmbTIPO_CodMND.SelectedIndex = 0;
               if (Presenter.Item != null && Presenter.Item.ListDetCtaCte != null)
               {
                  //foreach (DetCtaCte idetCtaCte in Presenter.Item.ListDetCtaCte)
                  //{
                  //   idetCtaCte.CCCT_Monto_Real = 0;
                  //}
                  txtMOVI_Numero.Clear();
                  txnMonto.Value = 0;
                  BSItemsDocumentos.ResetBindings(false);
               }
            }
            grdItemsDocumentos_CellEndEdit(null, null);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error seleccionado la moneda de la cuenta bancaria.", ex); }
      }

      private void FormatGridTipificacion()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsTipificacion.Columns.Clear();
            this.grdItemsTipificacion.AllowAddNewRow = false;
            this.grdItemsTipificacion.AutoGenerateColumns = false;

            GridViewCommandColumn commandColumn;
            if (Presenter.TipoBusqueda == CAJ002IngresosEgresosPresenter.TBusqueda.Base)
            {
               commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
               commandColumn.Name = "Edit";
               commandColumn.HeaderText = "Editar";
               commandColumn.DefaultText = "Editar";
               commandColumn.UseDefaultText = true;
               this.grdItemsTipificacion.Columns.Add(commandColumn);
               this.grdItemsTipificacion.Columns["Edit"].AllowSort = false;
               this.grdItemsTipificacion.Columns["Edit"].AllowFiltering = false;

               commandColumn = new GridViewCommandColumn();
               commandColumn.Name = "Delete";
               commandColumn.HeaderText = "Eliminar";
               commandColumn.DefaultText = "Eliminar";
               commandColumn.UseDefaultText = true;
               this.grdItemsTipificacion.Columns.Add(commandColumn);
               this.grdItemsTipificacion.Columns["Delete"].AllowSort = false;
               this.grdItemsTipificacion.Columns["Delete"].AllowFiltering = false;
            }
            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "CtaCte";
            commandColumn.HeaderText = "Cta Cte.";
            commandColumn.DefaultText = "CtaCte";
            commandColumn.UseDefaultText = true;
            this.grdItemsTipificacion.Columns.Add(commandColumn);
            this.grdItemsTipificacion.Columns["CtaCte"].AllowSort = false;
            this.grdItemsTipificacion.Columns["CtaCte"].WrapText = true;
            this.grdItemsTipificacion.Columns["CtaCte"].AllowFiltering = false;

            this.grdItemsTipificacion.Columns.Add("TIPD_Item", "Item", "TIPD_Item");

            this.grdItemsTipificacion.Columns.Add("TIPO_CodDES_Text", "Tipificación", "TIPO_CodDES_Text");
            this.grdItemsTipificacion.Columns.Add("TIPD_Tipo_Text", "Tipo", "TIPD_Tipo_Text");

            this.grdItemsTipificacion.Columns.Add("TIPO_CodMND_Text", "Moneda", "TIPO_CodMND_Text");
            this.grdItemsTipificacion.Columns.Add("TIPD_MontoDebe", "Monto Debe", "TIPD_MontoDebe");
            this.grdItemsTipificacion.Columns.Add("TIPD_MontoHaber", "Monto Haber", "TIPD_MontoHaber");

            this.grdItemsTipificacion.Columns.Add("TIPD_GeneraCtaCte_Text", "Genera Cta. Cte.", "TIPD_GeneraCtaCte_Text");

            this.grdItemsTipificacion.Columns.Add("TIPD_Cuenta", "Cuenta", "TIPD_Cuenta");
            this.grdItemsTipificacion.Columns.Add("CENT_Desc", "Centro de Costo", "CENT_Desc");

            this.grdItemsTipificacion.Columns.Add("TIPE_Descripcion", "Tipo de Entidad", "TIPE_Descripcion");
            this.grdItemsTipificacion.Columns.Add("ENTC_RazonSocial", "Razon Social", "ENTC_RazonSocial");

            grdItemsTipificacion.Columns["TIPD_MontoDebe"].FormatString = "{0:#,###,##0.00}";
            grdItemsTipificacion.Columns["TIPD_MontoDebe"].TextAlignment = ContentAlignment.MiddleLeft;
            grdItemsTipificacion.Columns["TIPD_MontoHaber"].FormatString = "{0:#,###,##0.00}";
            grdItemsTipificacion.Columns["TIPD_MontoHaber"].TextAlignment = ContentAlignment.MiddleLeft;

            /* Propiedades Finales */
            grdItemsTipificacion.ReadOnly = true;
            grdItemsTipificacion.ShowFilteringRow = false;
            grdItemsTipificacion.EnableFiltering = false;
            grdItemsTipificacion.MasterTemplate.EnableFiltering = false;
            grdItemsTipificacion.EnableGrouping = false;
            grdItemsTipificacion.MasterTemplate.EnableGrouping = false;
            grdItemsTipificacion.EnableSorting = false;
            grdItemsTipificacion.MasterTemplate.EnableCustomSorting = false;

            //Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsDocumentos);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex); }
      }

      #region [ Metodos Documentos ]

      /// <summary>
      /// Agregar Nuevo Detalle al Movimiento, registros de la tabla DetCtaCte
      /// </summary>
      private void NuevoDocumento()
      {
         try
         {
            if (txaCUBA_NroCuenta.SelectedItem != null && txaENTC_Codigo.SelectedItem != null && txnMOVI_TipoCambio.Value > 0 && cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
            {
               txaENTC_Codigo.SelectedItem.TIPE_Codigo = cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo;
               if (Presenter.NuevoDocumento(txaCUBA_NroCuenta.SelectedItem, txaENTC_Codigo.SelectedItem, cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo, txnMOVI_TipoCambio.Value))
               { ShowDocumentos(); }
            }
            else
            {
               String _Mensaje = "";
               if (txaCUBA_NroCuenta.SelectedItem == null) { _Mensaje += "* Ingresar una Cuenta Bancaria" + Environment.NewLine; }
               if (txaENTC_Codigo.SelectedItem == null) { _Mensaje += "* Ingresar una Entidad" + Environment.NewLine; }
               if (txnMOVI_TipoCambio.Value <= 0) { _Mensaje += "* Ingresar un Tipo de Cambio Correcto" + Environment.NewLine; }
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, haga click en el boton detalles.", _Mensaje);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar documentos.", ex); }
      }

      private void EliminarDocumento()
      {
         try
         {
            if (BSItemsDocumentos.Current != null)
            {
               Entities.DetCtaCte _detctacte = (BSItemsDocumentos.Current as Entities.DetCtaCte);
               if (Presenter.EliminarDocumento(_detctacte))
               {
                  ShowDocumentos();
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar Item.", ex); }
      }

      private void AbrirCtaCte()
      {
         try
         {
            if (BSItemsDocumentos.Current != null)
            {
               Entities.DetCtaCte _detctacte = (BSItemsDocumentos.Current as Entities.DetCtaCte);
               Presenter.AbriCtaCte(_detctacte);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Abrir Cta. Cte. del Item.", ex); }
      }

      private void AbrirCtaCteDescuadre()
      {
         try
         {
            if (Presenter != null && Presenter.Item != null && Presenter.Item.ItemCtaCteDescuadre != null)
            {
               Entities.DetCtaCte _detctacte = new DetCtaCte();
               _detctacte.EMPR_Codigo = Presenter.Item.ItemCtaCteDescuadre.EMPR_Codigo;
               _detctacte.CCCT_Codigo = Presenter.Item.ItemCtaCteDescuadre.CCCT_Codigo;
               Presenter.AbriCtaCte(_detctacte);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Abrir Cta. Cte. del Item.", ex); }
      }

      /// <summary>
      /// Actualizar el listado de documentos
      /// </summary>
      private void ShowDocumentos()
      {
         try
         {
            FormatGridDocumentos();
            BSItemsDocumentos.DataSource = Presenter.Item.ListDetCtaCte;
            BSItemsDocumentos.ResetBindings(false);
            grdItemsDocumentos.BestFitColumns();
            grdItemsDocumentos_CellEndEdit(null, null);
            this.grdItemsDocumentos.Columns["DCCT_TipoCambio"].Width = 80;
            //this.grdItemsDocumentos.Columns["CCCT_Monto"].Width = 80;
            this.grdItemsDocumentos.Columns["CCCT_Pendiente"].Width = 80;
            navItems.BindingSource = BSItemsDocumentos;
            if (Presenter.TipoBusqueda == CAJ002IngresosEgresosPresenter.TBusqueda.Liquidaciones)
            { btnNuevoDocumento.Enabled = false; tsbtnNuevoDocumento.Enabled = false; }
         }
         catch (Exception)
         { }
      }

      public void SetEnabled(Boolean x_opcion)
      {
         try
         {
            btnGuardar.Enabled = x_opcion;
            btnEjecutarDiferido.Enabled = x_opcion;
            btnRediferir.Enabled = x_opcion;
            //btnSalir.Enabled = x_opcion;
            btnAbrir.Enabled = x_opcion;
            tableDatosGenerales.Enabled = x_opcion;
            btnNuevoDocumento.Enabled = x_opcion;
            tableLayoutPanel2.Enabled = x_opcion;
            tableLayoutPanel1.Enabled = x_opcion;

         }
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Realizar los calculos para veridicar si existe un descuadre
      /// </summary>
      private void getDescuadre()
      {
         try
         {
            Decimal _totalDetalle = 0, _totalIngresado = 0, _diferencia = 0;
            _totalIngresado = txnMonto.Value;
            if (Presenter != null && Presenter.Item != null && Presenter.Item.ListDetCtaCte != null & Presenter.Item.ListDetCtaCte.Count > 0)
            {
               foreach (DetCtaCte idetCtaCte in Presenter.Item.ListDetCtaCte)
               {
                  if (idetCtaCte.TipoCtaCte.Equals("+"))
                  { _totalDetalle += (idetCtaCte.CCCT_Pendiente.HasValue ? idetCtaCte.CCCT_Pendiente.Value : 0); }
                  else if (idetCtaCte.TipoCtaCte.Equals("-"))
                  { _totalDetalle -= (idetCtaCte.CCCT_Pendiente.HasValue ? idetCtaCte.CCCT_Pendiente.Value : 0); }
                  else { _totalDetalle += (idetCtaCte.CCCT_Pendiente.HasValue ? idetCtaCte.CCCT_Pendiente.Value : 0); }
               }
               _diferencia = Math.Round(_totalIngresado - _totalDetalle, 2, MidpointRounding.AwayFromZero);
               SetDiferencia(_diferencia);
            }
            else if (Presenter != null && Presenter.Item != null)
            {
               _diferencia = Math.Round(_totalIngresado - _totalDetalle, 2, MidpointRounding.AwayFromZero);
               SetDiferencia(_diferencia);
            }
         }
         catch (Exception)
         { }
      }

      private void SetDiferencia(Decimal _diferencia)
      {
         try
         {
            if (_diferencia == 0)
            {
               //if (pnlDescuadre.Visible) { btnNuevoDocumento.Location = new Point(btnNuevoDocumento.Location.X, btnNuevoDocumento.Location.Y - 27 * 2); }
               //tlpDescuadre.Visible = false;
               //pnlDescuadre.Visible = false;
               btnTipificacion.Enabled = false;
               cmbTIPO_CodDES.SelectedIndex = cmbTIPO_CodDES.TiposSelectedItem != null ? 0 : -1;
               txnMOVI_MontoDescuadre.Value = 0;
               Presenter.Item.TieneDescuadre = false;
               txnMOVI_MontoDescuadre.Tag = null;
            }
            else
            {
               //if (!pnlDescuadre.Visible) { btnNuevoDocumento.Location = new Point(btnNuevoDocumento.Location.X, btnNuevoDocumento.Location.Y + 27 * 2); }
               //tlpDescuadre.Visible = true;
               //pnlDescuadre.Visible = true;
               btnTipificacion.Enabled = true;
               txnMOVI_MontoDescuadre.Value = Math.Abs(_diferencia);
               txnMOVI_MontoDescuadre.Tag = _diferencia;
               Presenter.Item.TieneDescuadre = true;
               if (_diferencia > 0) { }
            }
         }
         catch (Exception)
         { throw; }
      }

      private void setNroCheque(String CUBA_Codigo, String TipoMovimiento, Decimal Opcion)
      {
         try
         {
            if (Presenter.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
            {
               if (Presenter.setNroCheque(CUBA_Codigo, TipoMovimiento, Opcion))
               {
                  txtMOVI_Numero.Text = (Presenter.Item.ItemChequera.CHEQ_NroActual + 1).ToString();
                  txtMOVI_Numero.ReadOnly = true;
               }
               else
               {
                  txtMOVI_Numero.ReadOnly = false;
                  txtMOVI_Numero.Clear();
               }
            }
         }
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Ejecutars the diferido. Actualiza la fecha de ejecución del cheque diferido, asi como tambien permite cambiar la cuenta bancaria del mismo
      /// </summary>
      private void EjecutarDiferido()
      {
         try
         {
            if (btnEjecutarDiferido.Visible)
            {
               if (Presenter.EjecutarDiferido(txaCUBA_NroCuenta.SelectedItem))
               {
                  this.FormClosing -= MView_FormClosing;
                  //errorProviderCab_Cotizacion_OV.Dispose();
                  PresenterBase.CloseMView(this);
                  PresenterBase.Actualizar();
                  this.Close();
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Ejecutar un Movimiento Diferido.", ex); }
      }

      private void Rediferir()
      {
         try
         {
            if (btnRediferir.Visible)
            {
               if (Presenter.Rediferir())
               {
                  this.FormClosing -= MView_FormClosing;
                  //errorProviderCab_Cotizacion_OV.Dispose();
                  PresenterBase.CloseMView(this);
                  PresenterBase.Actualizar();
                  this.Close();
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Rediferir el movimiento.", ex); }
      }

      private Boolean ValidarDescuadre()
      {
         try
         {
            Boolean m_IsCorrect = true;
            Decimal _descuadre = 0;
            _descuadre = Decimal.Parse(txtPendiente.Text);
            switch (Presenter.TMovimiento)
            {
               case TipoMovimientoCtaCte.Ingresos:
                  //_descuadre = txnMOVI_MontoDescuadre.Value;

                  if (_descuadre != 0)
                  {
                     try
                     {
                        //_descuadre = Convert.ToDecimal(txnMOVI_MontoDescuadre.Tag); 
                        _descuadre = txtPendiente.Value;
                     }
                     catch (Exception)
                     {
                        getDescuadre();
                        CalcularDescuadre();
                        //_descuadre = Convert.ToDecimal(txnMOVI_MontoDescuadre.Tag);
                        _descuadre = Convert.ToDecimal(txtPendiente.Tag);
                     }
                     foreach (Entities.Tipificaciones iTip in Presenter.Item.ListTipificaciones)
                     {
                        if (_descuadre < 0 && iTip.TIPD_GeneraCtaCte)
                        { m_IsCorrect = false; }
                     }
                     //if (_descuadre < 0 && chkGeneraCtaCte.Checked)
                     //{ m_IsCorrect = false; }
                  }
                  break;
               case TipoMovimientoCtaCte.Egresos:
                  //_descuadre = txnMOVI_MontoDescuadre.Value;
                  if (_descuadre != 0)
                  {
                     try
                     {
                        //_descuadre = Convert.ToDecimal(txnMOVI_MontoDescuadre.Tag); 
                        _descuadre = Convert.ToDecimal(txtPendiente.Tag);
                     }
                     catch (Exception)
                     {
                        getDescuadre();
                        CalcularDescuadre();
                        //_descuadre = Convert.ToDecimal(txnMOVI_MontoDescuadre.Tag);
                        _descuadre = Convert.ToDecimal(txtPendiente.Tag);
                     }
                     foreach (Entities.Tipificaciones iTip in Presenter.Item.ListTipificaciones)
                     {
                        if (_descuadre < 0 && iTip.TIPD_GeneraCtaCte)
                        { m_IsCorrect = false; }
                     }
                     //if (_descuadre < 0 && chkGeneraCtaCte.Checked)
                     //{ m_IsCorrect = false; }
                  }
                  break;
            }
            return m_IsCorrect;
         }
         catch (Exception)
         { return false; }
      }

      #endregion

      #region [ Metodos Flujo ]

      private void NuevoFlujo()
      {
         try
         {
            if (Presenter.Item != null)
            {
               Int32 _item = 0;
               if (((ObservableCollection<Entities.MovimientoFlujo>)BSItemsMovimientosFlujo.DataSource).Count > 0)
               { _item = ((ObservableCollection<Entities.MovimientoFlujo>)BSItemsMovimientosFlujo.DataSource).Max(dcot => dcot.MFLU_Item); }

               if (Presenter.NuevoMovimientoFlujo(_item))
               {
                  BSItemsMovimientosFlujo.DataSource = Presenter.Item.ListFlujos;
                  BSItemsMovimientosFlujo.ResetBindings(false);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar documentos.", ex); }
      }

      private void EditarMovimientoFlujo()
      {
         try
         {
            if (Presenter.Item != null && BSItemsMovimientosFlujo != null && BSItemsMovimientosFlujo.DataSource != null)
            {
               Int32 x_position = BSItemsMovimientosFlujo.Position;
               Entities.MovimientoFlujo _movimientoFlujo = (BSItemsMovimientosFlujo.Current as Entities.MovimientoFlujo);
               if (Presenter.EditarMovimientoFlujo(ref _movimientoFlujo))
               {
                  (BSItemsMovimientosFlujo.DataSource as ObservableCollection<Entities.MovimientoFlujo>)[x_position] = _movimientoFlujo;
                  BSItemsMovimientosFlujo.ResetBindings(false);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al editar una chequera", ex); }
      }

      private void EliminarMovimientoFlujo()
      {
         try
         {
            if (BSItemsMovimientosFlujo.Current != null && BSItemsMovimientosFlujo.Current is Entities.MovimientoFlujo)
            {
               Entities.MovimientoFlujo _movimientoFlujo = (Entities.MovimientoFlujo)BSItemsMovimientosFlujo.Current;
               if (_movimientoFlujo.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
               {
                  _movimientoFlujo.AUDI_UsrMod = Presenter.Session.UserName;
                  _movimientoFlujo.AUDI_FecMod = Presenter.Session.Fecha;
                  _movimientoFlujo.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                  Presenter.Item.ListFlujosEliminados.Add(_movimientoFlujo);
               }
               BSItemsMovimientosFlujo.RemoveCurrent();
               BSItemsMovimientosFlujo.ResetBindings(true);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar una chequera", ex); }
      }

      #endregion

      #region [ Metodos de Tipificación ]

      private void NuevaTipificacion()
      {
         try
         {
            if (Presenter.Item != null)
            {
               if (txaCUBA_NroCuenta.SelectedItem != null && txaENTC_Codigo.SelectedItem != null && txnMOVI_TipoCambio.Value > 0 && cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
               {
                  Int32 _item = 0;
                  if (((ObservableCollection<Entities.Tipificaciones>)BSItemsTipificacion.DataSource).Count > 0)
                  { _item = ((ObservableCollection<Entities.Tipificaciones>)BSItemsTipificacion.DataSource).Max(dcot => dcot.TIPD_Item); }

                  CalcularDescuadre();
                  Int16 x_TIPE_Codigo = (Int16)cmbTIPE_Codigo.SelectedValue;
                  if (Presenter.NuevaTipificacion(_item, x_TIPE_Codigo, txaENTC_Codigo.SelectedItem.ENTC_Codigo, cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo, txnMOVI_TipoCambio.Value))
                  {
                     CalcularDescuadre();
                     BSItemsTipificacion.DataSource = Presenter.Item.ListTipificaciones;
                     BSItemsTipificacion.ResetBindings(false);
                     grdItemsTipificacion.BestFitColumns();
                  }
               }
               else
               {
                  String _Mensaje = "";
                  if (txaCUBA_NroCuenta.SelectedItem == null) { _Mensaje += "* Ingresar una Cuenta Bancaria" + Environment.NewLine; }
                  if (txaENTC_Codigo.SelectedItem == null) { _Mensaje += "* Ingresar una Entidad" + Environment.NewLine; }
                  if (txnMOVI_TipoCambio.Value <= 0) { _Mensaje += "* Ingresar un Tipo de Cambio Correcto" + Environment.NewLine; }
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, haga click en el boton detalles.", _Mensaje);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar una tipificación.", ex); }
      }

      private void EditarTipificacion()
      {
         try
         {
            if (Presenter.Item != null && BSItemsTipificacion != null && BSItemsTipificacion.DataSource != null)
            {
               CalcularDescuadre();
               Int32 x_position = BSItemsTipificacion.Position;
               Entities.Tipificaciones _tipificacion = (BSItemsTipificacion.Current as Entities.Tipificaciones);
               if (Presenter.EditarTipificacion(ref _tipificacion))
               {
                  CalcularDescuadre();
                  (BSItemsTipificacion.DataSource as ObservableCollection<Entities.Tipificaciones>)[x_position] = _tipificacion;
                  BSItemsTipificacion.ResetBindings(false);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al editar una chequera", ex); }
      }

      private void EliminarTipificacion()
      {
         try
         {
            if (BSItemsTipificacion.Current != null && BSItemsTipificacion.Current is Entities.Tipificaciones)
            {
               Entities.Tipificaciones _tipificacion = (Entities.Tipificaciones)BSItemsTipificacion.Current;
               if (_tipificacion.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
               {
                  _tipificacion.AUDI_UsrMod = Presenter.Session.UserName;
                  _tipificacion.AUDI_FecMod = Presenter.Session.Fecha;
                  _tipificacion.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                  Presenter.Item.ListTipificacionesEliminados.Add(_tipificacion);
               }
               CalcularDescuadre();
               BSItemsTipificacion.RemoveCurrent();
               BSItemsTipificacion.ResetBindings(true);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar una chequera", ex); }
      }

      private void CalcularDescuadre()
      {
         try
         {
            if (Presenter != null && Presenter.Item != null && Presenter.Item.ListTipificaciones != null)
            {
               Decimal _Ing = 0, _Egre = 0, _difDescuadre = 0;

               getDescuadre();
               _difDescuadre = Convert.ToDecimal(txnMOVI_MontoDescuadre.Tag);

               foreach (Entities.Tipificaciones iTip in Presenter.Item.ListTipificaciones)
               {
                  _Ing += iTip.TIPD_MontoDebe;
                  _Egre += iTip.TIPD_MontoHaber;
               }
               Decimal _dif = 0;
               switch (Presenter.TMovimiento)
               {
                  case TipoMovimientoCtaCte.Ingresos:
                     _dif = _Egre - _Ing;
                     break;
                  case TipoMovimientoCtaCte.Egresos:
                     _dif = _Ing - _Egre;
                     break;
                  default:
                     break;
               }
               txtDifDescuadre.Text = _dif.ToString("#,###,##0.00");
               txtDifDescuadre.Tag = _dif;
               Presenter.Total = _dif;

               Decimal _pen = _difDescuadre - _dif;
               txtPendiente.Text = _pen.ToString("#,###,##0.00");
               txtPendiente.Tag = _pen;
               Presenter.Pendiente = _pen;
            }
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #endregion

      #region [ Eventos ]

      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (ValidarDescuadre())
            {
               if (Presenter.Guardar(true))
               {
                  this.FormClosing -= MView_FormClosing;
                  PresenterBase.CloseMView(this);
                  PresenterBase.Actualizar();
                  switch (Presenter.TipoInicio)
                  {
                     case CAJ002IngresosEgresosPresenter.TInicio.Normal:
                        break;
                     case CAJ002IngresosEgresosPresenter.TInicio.SoloMovimiento:
                        this.DialogResult = DialogResult.OK;
                        break;
                  }
                  this.Close();
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "La tipificación con valor negativo no puede generar Cuenta Cte., si desea continuar debe cambiar la tipicación desde el maestro de Descuadres."); }
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

      private void btnNuevoDocumento_Click(object sender, EventArgs e)
      { NuevoDocumento(); }

      private void btnNuevoFlujo_Click(object sender, EventArgs e)
      { NuevoFlujo(); }

      private void btnAceptar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Aceptar())
            {
               this.FormClosing -= MView_FormClosing;
               this.DialogResult = System.Windows.Forms.DialogResult.OK;
               this.Close();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al aceptar el formulario.", ex); }
      }

      private void btnCtaCteDescuadre_Click(object sender, EventArgs e)
      { AbrirCtaCteDescuadre(); }

      private void txaCUBA_NroCuenta_SelectedItemCuentaBancariaChanged(object sender, EventArgs e)
      { SeleccionarCuentaBancaria(); }

      private void cmbTIPO_CodMOV_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPO_CodMOV.TiposSelectedItem != null && !String.IsNullOrEmpty(cmbTIPO_CodMOV.TiposSelectedItem.TIPO_Mascara))
            { cmbTIPO_CodMDP.SelectedValue = cmbTIPO_CodMOV.TiposSelectedItem.TIPO_Mascara; }
            else {
               if (cmbTIPO_CodMDP.DataSource != null) { cmbTIPO_CodMDP.SelectedIndex = 0; }
            }

            switch (Presenter.TMovimiento)
            {
               case TipoMovimientoCtaCte.Ingresos:
                  #region [ Ingresos ]

                  EnabledItem(true);
                  lblMensaje.Visible = false;
                  btnGuardar.Enabled = true;
                  if (cmbTIPO_CodMOV.TiposSelectedItem != null && (cmbTIPO_CodMOV.TiposSelectedItem.TIPO_Num1 == 1)) // INGRESOS DIFERIDOS
                  {
                     #region [ INGRESOS DIFERIDOS ]
                     dtpMOVI_FecDiferido.Visible = true;
                     lblMOVI_FecDiferido.Visible = true;
                     lblMOVI_FecEjecutado.Visible = false;
                     dtpMOVI_FecEjecutado.Visible = false;
                     lblMOVI_FecEjecutado2.Visible = true;
                     dtpMOVI_FecEjecutado2.Visible = true;
                     #endregion
                  }
                  else if (cmbTIPO_CodMOV.TiposSelectedItem != null && (cmbTIPO_CodMOV.TiposSelectedItem.TIPO_Num1 == 2)) // INGRESOS TRANSFERENCIA - CUENTAS PROPIAS
                  {
                     #region [ INGRESOS TRANSFERENCIA - CUENTAS PROPIAS ]

                     dtpMOVI_FecDiferido.Visible = false;
                     lblMOVI_FecDiferido.Visible = false;
                     lblMOVI_FecEjecutado.Visible = false;
                     dtpMOVI_FecEjecutado.Visible = false;
                     lblMOVI_FecEjecutado2.Visible = false;
                     dtpMOVI_FecEjecutado2.Visible = false;
                     btnGuardar.Enabled = false;

                     switch (Presenter.TipoInicio)
                     {
                        case CAJ002IngresosEgresosPresenter.TInicio.Normal:
                           EnabledItem(false);
                           cmbTIPO_CodMOV.Enabled = true;
                           lblMensaje.Visible = false;
                           if (cmbTIPO_CodMOV.TiposSelectedItem.TIPO_CodTipo.Equals(Presenter.Item.GetTipoMovimiento(Movimiento.TipoMovimiento.IngresosTransferenciaCuentasPropias)))
                           {
                              lblMensaje.Visible = false;
                              lblMensaje.Text =
                                 String.Format(
                                    "El tipo de Movimiento: [{0}] solo se puede ingresar desde la opción del sistema [Finanzas]/[Transf. de Cuentas Propias]",
                                    cmbTIPO_CodMOV.Text);
                           }
                           else if (cmbTIPO_CodMOV.TiposSelectedItem.TIPO_CodTipo.Equals(Presenter.Item.GetTipoMovimiento(Movimiento.TipoMovimiento.IngresosExtorno)))
                           {
                              lblMensaje.Visible = false;
                              lblMensaje.Text =
                                 String.Format(
                                    "El tipo de Movimiento: [{0}] solo se puede ingresar desde la opción del sistema [Finanzas]/[Anulación de Documentos]",
                                    cmbTIPO_CodMOV.Text);
                           }
                           break;
                        case CAJ002IngresosEgresosPresenter.TInicio.SoloMovimiento:
                           EnabledItem(true);
                           lblMensaje.Visible = false;
                           break;
                        default:
                           break;
                     }

                     #endregion
                  }
                  else
                  {
                     dtpMOVI_FecDiferido.Visible = false; lblMOVI_FecDiferido.Visible = false;
                     dtpMOVI_FecEjecutado.Visible = false; lblMOVI_FecEjecutado.Visible = false;
                     dtpMOVI_FecEjecutado2.Visible = false; lblMOVI_FecEjecutado2.Visible = false;
                  }

                  #endregion
                  break;
               case TipoMovimientoCtaCte.Egresos:
                  #region [ Egresos ]

                  EnabledItem(true);
                  lblMensaje.Visible = false;
                  lblMOVI_FecDiferido.Visible = false;
                  dtpMOVI_FecDiferido.Visible = false;
                  lblMOVI_FecEjecutado.Visible = false;
                  dtpMOVI_FecEjecutado.Visible = false;
                  lblMOVI_FecEjecutado2.Visible = false;
                  dtpMOVI_FecEjecutado2.Visible = false;
                  txtMOVI_Numero.Clear();
                  btnGuardar.Enabled = true;
                  if (cmbTIPO_CodMOV.TiposSelectedItem != null && cmbTIPO_CodMOV.TiposSelectedItem.TIPO_Num1.HasValue)
                  {
                     switch ((int)cmbTIPO_CodMOV.TiposSelectedItem.TIPO_Num1.Value)
                     {
                        case 1: // EGRESOS - CHEQUE
                           tableDatosGenerales.RowStyles[4].Height = 0;
                           lblMOVI_NroOperacion.Visible = false;
                           txnMOVI_NroOperacion.Visible = false;
                           lbltxtMOVI_NroOficina.Visible = false;
                           txtMOVI_NroOficina.Visible = false;

                           tableDatosGenerales.RowStyles[5].Height = 27;
                           lblMOVI_Numero.Visible = true;
                           txtMOVI_Numero.Visible = true;
                           lblMOVI_OrdenDe.Visible = true;
                           txtMOVI_OrdenDe.Visible = true;
                           chkMOVI_NoNegociable.Visible = true;

                           tableDatosGenerales.RowStyles[6].Height = 27;
                           lblMOVI_FecDiferido.Visible = false;
                           dtpMOVI_FecDiferido.Visible = false;
                           lblMOVI_FecEjecutado.Visible = false;
                           dtpMOVI_FecEjecutado.Visible = false;
                           lblMOVI_FecEjecutado2.Visible = false;
                           dtpMOVI_FecEjecutado2.Visible = false;
                           lblMOVI_Referencia.Visible = true;
                           txtMOVI_Referencia.Visible = true;
                           chkMOVI_NoNegociable.Visible = true;
                           /*
                            * Obtener el Numero de Cheque correspondiente
                            */
                           if (cmbTIPO_CodMOV.TiposSelectedItem != null && txaCUBA_NroCuenta.SelectedItem != null)
                           {
                              setNroCheque(txaCUBA_NroCuenta.SelectedItem.CUBA_Codigo, cmbTIPO_CodMOV.TiposSelectedItem.TIPO_Desc2, cmbTIPO_CodMOV.TiposSelectedItem.TIPO_Num1.Value);
                           }
                           break;
                        case 2: // EGRESOS - CHEQUE DIFERIDO
                           tableDatosGenerales.RowStyles[4].Height = 0;
                           lblMOVI_NroOperacion.Visible = false;
                           txnMOVI_NroOperacion.Visible = false;
                           lbltxtMOVI_NroOficina.Visible = false;
                           txtMOVI_NroOficina.Visible = false;

                           tableDatosGenerales.RowStyles[5].Height = 27;
                           lblMOVI_Numero.Visible = true;
                           txtMOVI_Numero.Visible = true;
                           lblMOVI_OrdenDe.Visible = true;
                           txtMOVI_OrdenDe.Visible = true;
                           chkMOVI_NoNegociable.Visible = true;

                           tableDatosGenerales.RowStyles[6].Height = 27;
                           lblMOVI_FecDiferido.Visible = true;
                           dtpMOVI_FecDiferido.Visible = true;
                           lblMOVI_FecEjecutado.Visible = true;
                           dtpMOVI_FecEjecutado.Visible = true;
                           lblMOVI_FecEjecutado2.Visible = false;
                           dtpMOVI_FecEjecutado2.Visible = false;
                           lblMOVI_Referencia.Visible = true;
                           txtMOVI_Referencia.Visible = true;
                           chkMOVI_NoNegociable.Visible = true;
                           /*
                            * Obtener el Numero de Cheque Diferido correspondiente
                            */
                           if (cmbTIPO_CodMOV.TiposSelectedItem != null && txaCUBA_NroCuenta.SelectedItem != null)
                           {
                              setNroCheque(txaCUBA_NroCuenta.SelectedItem.CUBA_Codigo, cmbTIPO_CodMOV.TiposSelectedItem.TIPO_Desc2, cmbTIPO_CodMOV.TiposSelectedItem.TIPO_Num1.Value);
                           }
                           break;
                        case 3: // EGRESOS TRANSFERENCIA - CUENTAS PROPIAS
                        case 4:
                           tableDatosGenerales.RowStyles[4].Height = 27;
                           lblMOVI_NroOperacion.Visible = true;
                           txnMOVI_NroOperacion.Visible = true;
                           lbltxtMOVI_NroOficina.Visible = true;
                           txtMOVI_NroOficina.Visible = true;

                           tableDatosGenerales.RowStyles[5].Height = 0;
                           lblMOVI_Numero.Visible = false;
                           txtMOVI_Numero.Visible = false;
                           lblMOVI_OrdenDe.Visible = false;
                           txtMOVI_OrdenDe.Visible = false;
                           chkMOVI_NoNegociable.Visible = false;

                           tableDatosGenerales.RowStyles[6].Height = 27;
                           lblMOVI_FecDiferido.Visible = false;
                           dtpMOVI_FecDiferido.Visible = false;
                           lblMOVI_FecEjecutado.Visible = false;
                           dtpMOVI_FecEjecutado.Visible = false;
                           lblMOVI_FecEjecutado2.Visible = false;
                           dtpMOVI_FecEjecutado2.Visible = false;
                           lblMOVI_Referencia.Visible = true;
                           txtMOVI_Referencia.Visible = true;

                           txtMOVI_Numero.ReadOnly = false;
                           btnGuardar.Enabled = false;

                           switch (Presenter.TipoInicio)
                           {
                              case CAJ002IngresosEgresosPresenter.TInicio.Normal:
                                 EnabledItem(false);
                                 cmbTIPO_CodMOV.Enabled = true;
                                 lblMensaje.Visible = true;
                                 if (cmbTIPO_CodMOV.TiposSelectedItem.TIPO_CodTipo.Equals(Presenter.Item.GetTipoMovimiento(Movimiento.TipoMovimiento.EgresosTransferenciaCuentasPropias)))
                                 {
                                    lblMensaje.Text =
                                       String.Format(
                                          "El tipo de Movimiento: [{0}] solo se puede ingresar desde la opción del sistema [Finanzas]/[Transf. de Cuentas Propias]",
                                          cmbTIPO_CodMOV.Text);
                                 }
                                 else if (cmbTIPO_CodMOV.TiposSelectedItem.TIPO_CodTipo.Equals(Presenter.Item.GetTipoMovimiento(Movimiento.TipoMovimiento.EgresosExtorno)))
                                 {
                                    lblMensaje.Text =
                                       String.Format(
                                          "El tipo de Movimiento: [{0}] solo se puede ingresar desde la opción del sistema [Finanzas]/[Anulación de Documentos]",
                                          cmbTIPO_CodMOV.Text);
                                 }
                                 else if (cmbTIPO_CodMOV.TiposSelectedItem.TIPO_CodTipo.Equals(Presenter.Item.GetTipoMovimiento(Movimiento.TipoMovimiento.EgresosTransferenciaMVirtual)))
                                 {
                                    lblMensaje.Text =
                                       String.Format(
                                          "El tipo de Movimiento: [{0}] solo se puede ingresar desde la opción del sistema [Finanzas]/[Exportación]",
                                          cmbTIPO_CodMOV.Text);
                                 }
                                 break;
                              case CAJ002IngresosEgresosPresenter.TInicio.SoloMovimiento:
                                 EnabledItem(true);
                                 lblMensaje.Visible = false;
                                 break;
                              default:
                                 break;
                           }
                           break;
                        case 0: // EGRESOS DEPOSITO
                           tableDatosGenerales.RowStyles[4].Height = 27;
                           lblMOVI_NroOperacion.Visible = true;
                           txnMOVI_NroOperacion.Visible = true;
                           lbltxtMOVI_NroOficina.Visible = true;
                           txtMOVI_NroOficina.Visible = true;

                           tableDatosGenerales.RowStyles[5].Height = 0;
                           lblMOVI_Numero.Visible = false;
                           txtMOVI_Numero.Visible = false;
                           lblMOVI_OrdenDe.Visible = false;
                           txtMOVI_OrdenDe.Visible = false;
                           chkMOVI_NoNegociable.Visible = false;

                           tableDatosGenerales.RowStyles[6].Height = 27;
                           lblMOVI_FecDiferido.Visible = false;
                           dtpMOVI_FecDiferido.Visible = false;
                           lblMOVI_FecEjecutado.Visible = false;
                           dtpMOVI_FecEjecutado.Visible = false;
                           lblMOVI_FecEjecutado2.Visible = false;
                           dtpMOVI_FecEjecutado2.Visible = false;
                           lblMOVI_Referencia.Visible = true;
                           txtMOVI_Referencia.Visible = true;

                           txtMOVI_Numero.ReadOnly = false;
                           btnGuardar.Enabled = true;
                           break;
                        default:
                           tableDatosGenerales.RowStyles[4].Height = 27;
                           lblMOVI_NroOperacion.Visible = true;
                           txnMOVI_NroOperacion.Visible = true;
                           lbltxtMOVI_NroOficina.Visible = true;
                           txtMOVI_NroOficina.Visible = true;

                           tableDatosGenerales.RowStyles[5].Height = 0;
                           lblMOVI_Numero.Visible = false;
                           txtMOVI_Numero.Visible = false;
                           lblMOVI_OrdenDe.Visible = false;
                           txtMOVI_OrdenDe.Visible = false;
                           chkMOVI_NoNegociable.Visible = false;

                           tableDatosGenerales.RowStyles[6].Height = 27;
                           lblMOVI_FecDiferido.Visible = false;
                           dtpMOVI_FecDiferido.Visible = false;
                           lblMOVI_FecEjecutado.Visible = false;
                           dtpMOVI_FecEjecutado.Visible = false;
                           lblMOVI_FecEjecutado2.Visible = false;
                           dtpMOVI_FecEjecutado2.Visible = false;
                           lblMOVI_Referencia.Visible = true;
                           txtMOVI_Referencia.Visible = true;

                           txtMOVI_Numero.ReadOnly = false;
                           btnGuardar.Enabled = false;
                           break;
                     }
                  }
                  else
                  {
                     EnabledItem(false);
                     cmbTIPO_CodMOV.Enabled = true;
                     lblMensaje.Visible = true;
                     lblMensaje.Text = String.Format(
                                          "El tipo de Movimiento: [{0}] no puede utilizarse desde esta Interfaz",
                                          cmbTIPO_CodMOV.Text);
                  }

                  #endregion
                  break;
            }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cambiar el tipo de movimiento.", ex); }
      }

      private void txnMonto_LostFocus(object sender, EventArgs e)
      { getDescuadre(); }

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

      private void btnEjecutarDiferido_Click(object sender, EventArgs e)
      { EjecutarDiferido(); }

      private void btnRediferir_Click(object sender, EventArgs e)
      {
         Rediferir();
      }

      private void btnTipificacion_Click(object sender, EventArgs e)
      { NuevaTipificacion(); }

      #region [ Eventos de Grillas ]

      private void grdItemsFlujo_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     EditarMovimientoFlujo();
                     break;
                  case "Eliminar":
                     EliminarMovimientoFlujo();
                     //SeleccionarItem();
                     //Presenter.Eliminar();
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }
      }

      private void grdItemsFlujo_CellFormatting(object sender, CellFormattingEventArgs e)
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

      private void grdItemsDocumentos_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Eliminar":
                     EliminarDocumento();
                     break;
                  case "CtaCte":
                     AbrirCtaCte();
                     break;
               }
            }
         }
         catch (Exception)
         { }
      }

      private void grdItemsDocumentos_CellFormatting(object sender, CellFormattingEventArgs e)
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
                     bte.Image = Resources.Sign_07;
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
               if (e.Column.Name.Equals("CtaCte"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.document_pinned_16x16;
                     bte.ToolTipText = @"Abrir Documento Cta. Cte.";
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

      private void grdItemsDocumentos_CellEndEdit(object sender, GridViewCellEventArgs e)
      {
         try
         {
            if (BSItemsDocumentos != null && BSItemsDocumentos.Current != null)
            {
               Decimal _total = 0;
               foreach (DetCtaCte idetCtaCte in Presenter.Item.ListDetCtaCte)
               {
                  //if (idetCtaCte.TIPO_CodTDO.Equals(Entities.Tipos.GetTipo(Entities.Tipos.TipoTDO.NotaCredito)))
                  //{ _total -= (idetCtaCte.CCCT_Pendiente.HasValue ? idetCtaCte.CCCT_Pendiente.Value : 0); }
                  if (idetCtaCte.TipoCtaCte.Equals("+"))
                  { _total += Math.Round((idetCtaCte.CCCT_Pendiente.HasValue ? idetCtaCte.CCCT_Pendiente.Value : 0), 2, MidpointRounding.AwayFromZero); }
                  else if (idetCtaCte.TipoCtaCte.Equals("-"))
                  { _total -= Math.Round((idetCtaCte.CCCT_Pendiente.HasValue ? idetCtaCte.CCCT_Pendiente.Value : 0), 2, MidpointRounding.AwayFromZero); }
                  else
                  { _total += Math.Round((idetCtaCte.CCCT_Pendiente.HasValue ? idetCtaCte.CCCT_Pendiente.Value : 0), 2, MidpointRounding.AwayFromZero); }
               }
               txnMonto.Value = _total;
               Entities.DetCtaCte _ctacte = (BSItemsDocumentos.Current as Entities.DetCtaCte);

               if (
                  cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo.Equals(
                     Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Soles)))
               {
                  if (_ctacte.TIPO_CodMND_Real.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Soles)))
                  {
                     _ctacte.CCCT_Monto_Real = Math.Round((_ctacte.CCCT_Pendiente.HasValue ? _ctacte.CCCT_Pendiente.Value : 0), 2, MidpointRounding.AwayFromZero);
                     _ctacte.CCCT_Saldo = Math.Round((_ctacte.CCCT_Pendiente_Real.HasValue ? _ctacte.CCCT_Pendiente_Real.Value : 0), 2, MidpointRounding.AwayFromZero) - _ctacte.CCCT_Monto_Real;
                  }
                  else if (_ctacte.TIPO_CodMND_Real.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Dolares)))
                  {
                     _ctacte.CCCT_Monto_Real = Math.Round(((_ctacte.CCCT_Pendiente.HasValue ? _ctacte.CCCT_Pendiente.Value : 0) / _ctacte.DCCT_TipoCambio), 2, MidpointRounding.AwayFromZero);
                     _ctacte.CCCT_Saldo = Math.Round((_ctacte.CCCT_Pendiente_Real.HasValue ? _ctacte.CCCT_Pendiente_Real.Value : 0), 2, MidpointRounding.AwayFromZero) - _ctacte.CCCT_Monto_Real;
                  }
               }
               else if (
                  cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo.Equals(
                     Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Dolares)))
               {
                  if (_ctacte.TIPO_CodMND_Real.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Dolares)))
                  {
                     _ctacte.CCCT_Monto_Real = Math.Round((_ctacte.CCCT_Pendiente.HasValue ? _ctacte.CCCT_Pendiente.Value : 0), 2, MidpointRounding.AwayFromZero);
                     _ctacte.CCCT_Saldo = Math.Round((_ctacte.CCCT_Pendiente_Real.HasValue ? _ctacte.CCCT_Pendiente_Real.Value : 0), 2, MidpointRounding.AwayFromZero) - _ctacte.CCCT_Monto_Real;
                  }
                  else if (_ctacte.TIPO_CodMND_Real.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Soles)))
                  {
                     _ctacte.CCCT_Monto_Real = Math.Round(((_ctacte.CCCT_Pendiente.HasValue ? _ctacte.CCCT_Pendiente.Value : 0) * _ctacte.DCCT_TipoCambio), 2, MidpointRounding.AwayFromZero);
                     _ctacte.CCCT_Saldo = Math.Round((_ctacte.CCCT_Pendiente_Real.HasValue ? _ctacte.CCCT_Pendiente_Real.Value : 0), 2, MidpointRounding.AwayFromZero) - _ctacte.CCCT_Monto_Real;
                  }
               }
               getDescuadre();
               BSItemsDocumentos.ResetBindings(false);
            }
         }
         catch (Exception)
         { }
      }

      private void grdItemsTipificacion_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     EditarTipificacion();
                     break;
                  case "Eliminar":
                     EliminarTipificacion();
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }
      }

      private void grdItemsTipificacion_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            if (e.CellElement is GridCommandCellElement)
            {
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
               if (e.Column.Name.Equals("CtaCte"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.document_pinned_16x16;
                     bte.ToolTipText = @"Abrir Documento Cta. Cte.";
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

      #endregion

      public void CloseMView()
      {
         try
         {
            this.FormClosing -= MView_FormClosing;
            this.FormClosed -= CAJ002IngresosEgresosMView_FormClosed;
            this.Close();
         }
         catch (Exception)
         { throw; }
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
                  switch (Presenter.TipoInicio)
                  {
                     case CAJ002IngresosEgresosPresenter.TInicio.Normal:
                        if (btnGuardar.Enabled && Presenter.GuardarCambios() == System.Windows.Forms.DialogResult.Cancel)
                        {
                           e.Cancel = true;
                           this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
                        }
                        else
                        {
                           PresenterBase.CloseMView(this);
                           PresenterBase.Actualizar();
                        }
                        break;
                     case CAJ002IngresosEgresosPresenter.TInicio.SoloMovimiento:
                        break;
                     default:
                        break;
                  }
               }
               else
               {
                  switch (Presenter.TipoInicio)
                  {
                     case CAJ002IngresosEgresosPresenter.TInicio.Normal:
                        PresenterBase.CloseMView(this);
                        PresenterBase.Actualizar();
                        break;
                     case CAJ002IngresosEgresosPresenter.TInicio.SoloMovimiento:
                        break;
                     default:
                        break;
                  }
               }
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }

      private void btnCopy_Click(object sender, EventArgs e)
      {
         try
         {
            if (txaENTC_Codigo.SelectedItem != null) { txtMOVI_OrdenDe.Text = txaENTC_Codigo.SelectedItem.ENTC_NomCompleto; }
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      private void pageGenerales_Click(object sender, EventArgs e)
      {

      }

      private void grdItemsDocumentos_Click(object sender, EventArgs e)
      {

      }

      private void txnMOVI_NroOperacion_Leave(object sender, EventArgs e)
      {
          if (txnMOVI_NroOperacion.Text.Trim() == "") 
          { return; }
          if (Presenter.Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added) // || Presenter.Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified)
          { return; }
          DataTable dtQuery = new DataTable();
          string sMsgErr;
           
          AppService.DelfinServiceClient oAppService = new AppService.DelfinServiceClient();
          //dtQuery = oAppService.ExecuteSQL("EXEC Integrador.nxs.paObtieneOperacionBancaria " + txaENTC_Codigo.SelectedItem.ENTC_Codigo + ",'" + Convert.ToDateTime(dtpMOVI_FecOperacion.NSFecha).ToString("yyyyMMdd") + "'," + txnMOVI_NroOperacion.Text).Tables[0];
          dtQuery = oAppService.ExecuteSQL("EXEC Integrador.nxs.paObtieneOperacionBancaria '" + Convert.ToDateTime(dtpMOVI_FecOperacion.NSFecha).ToString("yyyyMMdd") + "','" + txnMOVI_NroOperacion.Text + "'").Tables[0];
          if (dtQuery.Rows.Count > 0)
          {
              sMsgErr="";
              sMsgErr += ("El número de operación ingresado ya ha sido registrado." + System.Environment.NewLine + System.Environment.NewLine);
              sMsgErr += ("Asiento Contable: " + dtQuery.Rows[0]["Voucher"].ToString() + System.Environment.NewLine);
              sMsgErr += ("Concepto: " + dtQuery.Rows[0]["Concepto"].ToString() + System.Environment.NewLine);
              sMsgErr += ("Código: " + dtQuery.Rows[0]["Codigo"].ToString());
          Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, sMsgErr);
          }
                    
      }

   }
}