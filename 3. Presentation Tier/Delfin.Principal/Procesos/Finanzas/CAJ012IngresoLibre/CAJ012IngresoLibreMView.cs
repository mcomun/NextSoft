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
using Telerik.WinControls.UI;
using Infrastructure.Aspect.Constants;
using Telerik.WinControls;
using Delfin.Principal.Properties;

namespace Delfin.Principal
{
   public partial class CAJ012IngresoLibreMView : Form, ICAJ012IngresoLibreMView
   {
      #region [ Variables ]

      Decimal PorcentajeIGV;

      #endregion

      #region [ Formulario ]
      public CAJ012IngresoLibreMView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += CAJ012IngresoLibreMView_FormClosed;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;
            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;
            cmbTIPO_CodDetrac.SelectedIndexChanged += cmbTIPO_CodDetrac_SelectedIndexChanged;
            txaCABP_Codigo.SelectedItemChanged += txaCABP_Codigo_SelectedItemChanged;
            cmbTIPO_CodMND.SelectedIndexChanged += cmbTIPO_CodMND_SelectedIndexChanged;
            cmbTIPO_CodTDO.SelectedIndexChanged += cmbTIPO_CodTDO_SelectedIndexChanged;

            txtCCCT_Numero.KeyPress += txtCCCT_Numero_KeyPress;

            BSItemsFlete = new BindingSource();
            grdItemsDetCtaCte.DataSource = BSItemsFlete;
            navItems.BindingSource = BSItemsFlete;
            this.Load += CAJ012IngresoLibreMView_Load;

            BSItemsAsiento = new BindingSource();
            grdItemsAsiento.DataSource = BSItemsAsiento;
            navsItemsAsiento.BindingSource = BSItemsAsiento;

            txtCCCT_Codigo.Enabled = false;

            txtCCCT_Notas.MaxLength = 1000;
            txtCCCT_NroDetraccion.MaxLength = 20;
            txtCCCT_Numero.MaxLength = 20;
            txtCCCT_Serie.MaxLength = 20;

            txtCCCT_Codigo.Tag = "CCCT_CodigoMSGERROR";
            cmbTIPE_Codigo.Tag = "TIPE_CodigoMSGERROR";
            txaENTC_Codigo.Tag = "ENTC_CodigoMSGERROR";

            cmbTIPO_CodTDO.Tag = "TIPO_CodTDOMSGERROR";
            cmbTIPO_CodMND.Tag = "TIPO_CodMNDMSGERROR";
            txtCCCT_Serie.Tag = "CTCT_SerieMSGERROR";
            txtCCCT_Numero.Tag = "CTCT_NumeroMSGERROR";
            txnCCCT_TipoCambio.Tag = "CCCT_TipoCambioMSGERROR";
            dtpCCCT_FechaEmision.Tag = "CCCT_FechaEmisionMSGERROR";
            txnCCCT_ValVta.Tag = "CCCT_ValVtaMSGERROR";
            txnCCCT_Imp1.Tag = "CCCT_Imp1MSGERROR";
            txnCCCT_Imp4.Tag = "CCCT_Imp4MSGERROR";
            txnCCCT_Monto.Tag = "CCCT_MontoMSGERROR";
            txtCCCT_NroDetraccion.Tag = "CCCT_NroDetraccionMSGERROR";
            dtpCCCT_FecDetraccion.Tag = "CCCT_FecDetraccionMSGERROR";
            cmbTIPO_CodDetrac.Tag = "TIPO_CodDetracMSGERROR";
            txtCCCT_Notas.Tag = "CCCT_NotasMSGERROR";
            txnCCCT_PorDetraccion.Tag = "CCCT_PorDetraccionMSGERROR";
            txnCCCT_MontoDetraccion.Tag = "CCCT_MontoDetraccionMSGERROR";
            chkCCCT_ProvAsumeDetraccion.Tag = "CCCT_ProvAsumeDetraccionMSGERROR";
            dtpCCCT_FechaRecepcion.Tag = "CCCT_FechaRecepcionMSGERROR";
            txnCCCT_ValVta.LostFocus += txnCCCT_ValVta_LostFocus;
            txnCCCT_Imp1.LostFocus += txnCCCT_Imp1_LostFocus;
            txnCCCT_Imp4.LostFocus += txnCCCT_Imp4_LostFocus;
            dtpCCCT_FecReg.Tag = "CCCT_FecRegMSGERROR";

            txtCCCT_Glosa.Tag = "CCCT_GlosaMSGERROR";
            txtCCCT_Glosa.MaxLength = 100;
            txtCCCT_CuentaBI.Tag = "CCCT_CuentaBIMSGERROR";
            txtCCCT_CuentaBI.MaxLength = 20;
            cmbTIPO_CodFPG.Tag = "TIPO_CodFPGMSGERROR";

            txnCCCT_Monto.ReadOnly = true;
            txnCCCT_PorDetraccion.ReadOnly = true;

            dtpCCCT_FechaRecepcion.SelectedDateChanged += dtpCCCT_FechaRecepcion_SelectedDateChanged;
            txaCCCT_CodReferencia.TipoFactura = TiposFactura.TIPE_Factura;
            txaCCCT_CodReferencia.AyudaValueChanged += txaCCCT_CodReferencia_AyudaValueChanged;
            grdItemsAsiento.CommandCellClick += grdItemsAsiento_CommandCellClick;
            grdItemsAsiento.CellFormatting += grdItemsAsiento_CellFormatting;
            grdItemsAsiento.CellValueChanged += grdItemsAsiento_CellValueChanged;
            grdItemsAsiento.CellEndEdit += grdItemsAsiento_CellEndEdit;
            grdItemsAsiento.CurrentCellChanged += grdItemsAsiento_CurrentCellChanged;
            grdItemsAsiento.CellBeginEdit += grdItemsAsiento_CellBeginEdit;
            grdItemsAsiento.DataError += grdItemsAsiento_DataError;
            dtpCCCT_FechaEmision.SelectedDateChanged += dtpCCCT_FechaEmision_SelectedDateChanged;
            //dtpCCCT_FechaEmision.LostFocus += dtpCCCT_FechaEmision_SelectedDateChanged;

            btnAddAsiento.Click += btnAddAsiento_Click;

            lblCCCT_CuentaBI.Visible = false;
            txtCCCT_CuentaBI.Visible = false;
            tblRenta4ta.Visible = false;
            pnlRenta3ra.Visible = false;
            txtAsientos.ReadOnly = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      private void dtpCCCT_FechaEmision_SelectedDateChanged(object sender, EventArgs e)
      {
         try
         {
            if (dtpCCCT_FechaEmision.NSFecha.HasValue)
            {
               txnCCCT_TipoCambio.Value = Presenter.GetTipoCambio(dtpCCCT_FechaEmision.NSFecha.Value);
            }
            else { txnCCCT_TipoCambio.Value = Presenter.TipoCambio; }
         }
         catch (Exception)
         { }
      }


      private void grdItemsAsiento_DataError(object sender, GridViewDataErrorEventArgs e)
      {

      }

      private void cmbTIPO_CodMND_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPO_CodMND.TiposSelectedItem != null)
            {
               if (cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Soles)))
               { if (String.IsNullOrEmpty(txtCCCT_Cuenta.Text)) { txtCCCT_Cuenta.Text = Presenter.P_Cuenta_Sol; } }
               else if (cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Dolares)))
               { if (String.IsNullOrEmpty(txtCCCT_Cuenta.Text)) { txtCCCT_Cuenta.Text = Presenter.P_Cuenta_Dol; } }
               else { txtCCCT_Cuenta.Clear(); }
            }
            else
            { txtCCCT_Cuenta.Clear(); }
         }
         catch (Exception)
         { }
      }

      private void cmbTIPO_CodTDO_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPO_CodTDO.TiposSelectedItem != null && cmbTIPO_CodTDO.SelectedValue != null)
            {
               if (!String.IsNullOrEmpty(cmbTIPO_CodTDO.TiposSelectedItem.TIPO_Desc3))
               { Presenter.P_Cuenta_IGV = cmbTIPO_CodTDO.TiposSelectedItem.TIPO_Desc3; }
               cmbTIPO_CodMND_SelectedIndexChanged(null, null);

               if (cmbTIPO_CodTDO.SelectedValue.ToString().Equals(Entities.Tipos.GetTipo(Entities.Tipos.TipoTDO.ReciboHonorario)))
               {
                  lblCCCT_Imp1.Enabled = false;
                  lblCCCT_CuentaIGV.Enabled = false;
                  txtCCCT_CuentaIGV.Enabled = false;
                  txnCCCT_Imp1.Enabled = false;
                  txnCCCT_Imp1.Value = 0;

                  tblRenta4ta.Visible = true;

                  txtCCCT_CuentaIGV.Clear();
                  txtCCCT_Cuenta4Ta.Text = Presenter.P_Cuenta_IGV;

                  cmbTIPO_CodDetrac.SelectedValue = "001";
                  cmbTIPO_CodDetrac.Enabled = false;
                  chkCCCT_ProvAsumeDetraccion.Enabled = false;
                  dtpCCCT_FecDetraccion.Enabled = false;
                  txnCCCT_MontoDetraccion.Enabled = false;
                  txtCCCT_NroDetraccion.Enabled = false;
                  txnCCCT_PorDetraccion.Enabled = false;
                  lblCCCT_PorDetraccion.Enabled = false;
                  lblTIPO_CodDetrac.Enabled = false;
                  lblCCCT_FecDetraccion.Enabled = false;
                  lblCCCT_MontoDetraccion.Enabled = false;
                  lblCCCT_NroDetraccion.Enabled = false;
               }
               else
               {
                  if (cmbTIPO_CodTDO.SelectedValue.ToString().Equals(Entities.Tipos.GetTipo(Entities.Tipos.TipoTDO.NotaCredito)))
                  { pnlDocReferencia.Visible = true; }
                  else
                  {
                     pnlDocReferencia.Visible = false;
                     txaCCCT_CodReferencia.ClearValue();
                  }

                  lblCCCT_Imp1.Enabled = true;
                  lblCCCT_CuentaIGV.Enabled = true;
                  txtCCCT_CuentaIGV.Enabled = true;
                  txnCCCT_Imp1.Enabled = true;
                  txtCCCT_Cuenta4Ta.Enabled = true;

                  tblRenta4ta.Visible = false;
                  txnCCCT_Imp4.Value = 0;

                  txtCCCT_Cuenta4Ta.Clear();
                  txtCCCT_CuentaIGV.Text = Presenter.P_Cuenta_IGV;

                  lblCCCT_Imp1.Text = "I.G.V. :";
                  lblCCCT_CuentaIGV.Text = "Cuenta I.G.V. :";
                  ClearDetraccion();
                  cmbTIPO_CodDetrac.Enabled = true;
                  chkCCCT_ProvAsumeDetraccion.Enabled = true;
                  dtpCCCT_FecDetraccion.Enabled = true;
                  txnCCCT_MontoDetraccion.Enabled = true;
                  txtCCCT_NroDetraccion.Enabled = true;
                  lblTIPO_CodDetrac.Enabled = true;
                  lblCCCT_FecDetraccion.Enabled = true;
                  lblCCCT_MontoDetraccion.Enabled = true;
                  lblCCCT_NroDetraccion.Enabled = true;
                  txnCCCT_PorDetraccion.Enabled = true;
                  lblCCCT_PorDetraccion.Enabled = true;
               }
            }
         }
         catch (Exception)
         { }
      }

      private void CAJ012IngresoLibreMView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }

      private void CAJ012IngresoLibreMView_Load(object sender, EventArgs e)
      {
         //tabCab_Cotizacion_OV.TabPages.Add(pageNovedades);
         //tabCab_Cotizacion_OV.TabPages.Add(pageArchivos);
         //tabCab_Cotizacion_OV.TabPages.Add(pageEventosTareas);
      }

      #endregion

      #region [ Propiedades ]

      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }
      public CAJ012IngresoLibrePresenter Presenter { get; set; }
      public BindingSource BSItemsFlete { get; set; }
      public BindingSource BSItemsAsiento { get; set; }

      #endregion

      #region [ ICAJ012IngresoLibreMView ]

      public void LoadView()
      {
         try
         {
            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo de Entidad", "< Sel. Tipo de Entidad >", ListSortDirection.Ascending);
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, TiposEntidad.TIPE_Cliente, null, null, true);
            cmbTIPO_CodTDO.LoadControl(Presenter.ContainerService, "Tipo Documento", "TDO", "< Sel. Tipo Documento >", ListSortDirection.Ascending);
            cmbTIPO_CodDetrac.LoadControl(Presenter.ContainerService, "Tipo de Detracción", "DET", "< Sel. Tipo Detracción >", ListSortDirection.Ascending);
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Moneda", "MND", "< Sel. Moneda >", ListSortDirection.Ascending);
            cmbTIPO_CodTDOReferencia.LoadControl(Presenter.ContainerService, "Tabla Tipo Documento Referencia", "TDO", "< Seleccione Documento >", ListSortDirection.Descending);
            txaCABP_Codigo.LoadControl(Presenter.ContainerService, "Planillas de Asientos");
            cmbTIPO_CodFPG.LoadControl(Presenter.ContainerService, "Ayuda de Forma de Pago", "FPG", "< Sel. Forma de Pago >", ListSortDirection.Ascending);
            cmbTIPO_CodTI3.LoadControl(Presenter.ContainerService, "Tabla Impuesto de 3ra", "TI3", "< Seleccione Impuesto >", ListSortDirection.Descending);

            FormatDataGrid();
            FormatDataGridPAsientos();
            FormatDataGridAsientos();

            txaENTC_Codigo.SelectedItemChanged += txaENTC_Codigo_SelectedItemChanged;
            txaCCCT_CodReferencia.LoadControl(Presenter.ContainerService, "Ayuda de Documento de Referencia", Delfin.Controls.AyudaFacturaCC.TipoAyuda.Normal, Entorno.ItemEmpresa.EMPR_Codigo);

            cmbTIPO_CodTI3.SelectedIndexChanged += cmbTIPO_CodTI3_SelectedIndexChanged;
            txnCCCT_Imp2.LostFocus += txnCCCT_Imp2_LostFocus;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      #endregion

      #region [ Metodos ]

      private void FormatDataGrid()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsDetCtaCte.Columns.Clear();
            this.grdItemsDetCtaCte.AllowAddNewRow = false;

            this.grdItemsDetCtaCte.Columns.Add("DCCT_Item", "Item", "DCCT_Item");
            this.grdItemsDetCtaCte.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            this.grdItemsDetCtaCte.Columns.Add("CONS_TDC", "Tipo", "CONS_TDC");
            this.grdItemsDetCtaCte.Columns.Add("DCCT_FechaTrans", "Fecha", "DCCT_FechaTrans");
            //this.grdItemsDetCtaCte.Columns.Add("MOVI_FecOperacion", "Fecha", "MOVI_FecOperacion");
            this.grdItemsDetCtaCte.Columns.Add("DCCT_TipoCambio", "Tipo Cambio", "DCCT_TipoCambio");
            this.grdItemsDetCtaCte.Columns.Add("DCCT_MontoDebe", "Debe S/.", "DCCT_MontoDebe");
            this.grdItemsDetCtaCte.Columns.Add("DCCT_MontoHaber", "Haber S/.", "DCCT_MontoHaber");
            this.grdItemsDetCtaCte.Columns.Add("DCCT_MontoDebeD", "Debe US$", "DCCT_MontoDebeD");
            this.grdItemsDetCtaCte.Columns.Add("DCCT_MontoHaberD", "Haber US$", "DCCT_MontoHaberD");

            this.grdItemsDetCtaCte.Columns.Add("TipoMovimiento", "Movimiento", "TipoMovimiento");
            this.grdItemsDetCtaCte.Columns.Add("Asiento", "Asiento", "Asiento");
            this.grdItemsDetCtaCte.Columns.Add("CUBA_NroCuenta", "Nro Cuenta", "CUBA_NroCuenta");
            this.grdItemsDetCtaCte.Columns.Add("TIPO_MND_MOV", "Moneda", "TIPO_MND_MOV");
            this.grdItemsDetCtaCte.Columns.Add("MOVI_Codigo", "Interno", "MOVI_Codigo");

            this.grdItemsDetCtaCte.Columns["DCCT_FechaTrans"].FormatString = "{0:dd/MM/yyyy}";
            //this.grdItemsDetCtaCte.Columns["MOVI_FecOperacion"].FormatString = "{0:dd/MM/yyyy}";
            this.grdItemsDetCtaCte.Columns["DCCT_TipoCambio"].FormatString = "{0:0.0000}";
            this.grdItemsDetCtaCte.Columns["DCCT_MontoDebe"].FormatString = "{0:#,###,##0.00}";
            this.grdItemsDetCtaCte.Columns["DCCT_MontoDebe"].TextAlignment = ContentAlignment.MiddleRight;
            this.grdItemsDetCtaCte.Columns["DCCT_MontoHaber"].FormatString = "{0:#,###,##0.00}";
            this.grdItemsDetCtaCte.Columns["DCCT_MontoHaber"].TextAlignment = ContentAlignment.MiddleRight;
            this.grdItemsDetCtaCte.Columns["DCCT_MontoDebeD"].FormatString = "{0:#,###,##0.00}";
            this.grdItemsDetCtaCte.Columns["DCCT_MontoDebeD"].TextAlignment = ContentAlignment.MiddleRight;
            this.grdItemsDetCtaCte.Columns["DCCT_MontoHaberD"].FormatString = "{0:#,###,##0.00}";
            this.grdItemsDetCtaCte.Columns["DCCT_MontoHaberD"].TextAlignment = ContentAlignment.MiddleRight;

            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsDetCtaCte);

            grdItemsDetCtaCte.ShowFilteringRow = false;
            grdItemsDetCtaCte.EnableFiltering = false;
            grdItemsDetCtaCte.MasterTemplate.EnableFiltering = false;
            grdItemsDetCtaCte.EnableGrouping = false;
            grdItemsDetCtaCte.MasterTemplate.EnableGrouping = false;
            grdItemsDetCtaCte.EnableSorting = false;
            grdItemsDetCtaCte.MasterTemplate.EnableCustomSorting = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
      }

      private void FormatDataGridPAsientos()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsPAsiento.Columns.Clear();
            this.grdItemsPAsiento.AllowAddNewRow = false;

            this.grdItemsPAsiento.Columns.Add("CUEN_Codigo", "Cuenta", "CUEN_Codigo");
            this.grdItemsPAsiento.Columns.Add("CENT_Codigo", "Centro Costo", "CENT_Codigo");
            this.grdItemsPAsiento.Columns.Add("DETP_DebePorc", "%", "DETP_DebePorc");
            this.grdItemsPAsiento.Columns.Add("Debe", "Debe", "Debe");
            this.grdItemsPAsiento.Columns.Add("DETP_HaberPorc", "%", "DETP_HaberPorc");
            this.grdItemsPAsiento.Columns.Add("Haber", "Haber", "Haber");

            this.grdItemsPAsiento.Columns["Debe"].FormatString = "{0:#,###,##0.00}";
            this.grdItemsPAsiento.Columns["Debe"].TextAlignment = ContentAlignment.MiddleRight;
            this.grdItemsPAsiento.Columns["DETP_DebePorc"].FormatString = "{0:#,##0.00 %}";
            this.grdItemsPAsiento.Columns["DETP_DebePorc"].TextAlignment = ContentAlignment.MiddleRight;

            this.grdItemsPAsiento.Columns["Haber"].FormatString = "{0:#,###,##0.00}";
            this.grdItemsPAsiento.Columns["Haber"].TextAlignment = ContentAlignment.MiddleRight;
            this.grdItemsPAsiento.Columns["DETP_HaberPorc"].FormatString = "{0:#,##0.00 %}";
            this.grdItemsPAsiento.Columns["DETP_HaberPorc"].TextAlignment = ContentAlignment.MiddleRight;

            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsPAsiento);

            grdItemsPAsiento.ShowFilteringRow = false;
            grdItemsPAsiento.EnableFiltering = false;
            grdItemsPAsiento.MasterTemplate.EnableFiltering = false;
            grdItemsPAsiento.EnableGrouping = false;
            grdItemsPAsiento.MasterTemplate.EnableGrouping = false;
            grdItemsPAsiento.EnableSorting = false;
            grdItemsPAsiento.MasterTemplate.EnableCustomSorting = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
      }

      private void FormatDataGridAsientos()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsAsiento.Columns.Clear();
            this.grdItemsAsiento.AllowAddNewRow = false;

            GridViewCommandColumn _btnEliminar = new GridViewCommandColumn();
            _btnEliminar.Name = "Delete";
            _btnEliminar.HeaderText = "Eliminar";
            _btnEliminar.DefaultText = "Eliminar";
            _btnEliminar.UseDefaultText = true;
            this.grdItemsAsiento.Columns.Add(_btnEliminar);
            this.grdItemsAsiento.Columns["Delete"].AllowSort = false;
            this.grdItemsAsiento.Columns["Delete"].AllowFiltering = false;

            Telerik.WinControls.UI.GridViewCommandColumn _cuenta = new Telerik.WinControls.UI.GridViewCommandColumn();
            _cuenta.Name = "Cuenta";
            _cuenta.HeaderText = "Ayuda Cta.";
            _cuenta.DefaultText = "Cuenta";
            _cuenta.UseDefaultText = true;
            this.grdItemsAsiento.Columns.Add(_cuenta);

            this.grdItemsAsiento.Columns.Add("DCCA_Cuenta", "Nro. Cuenta", "DCCA_Cuenta");
            this.grdItemsAsiento.Columns.Add("CUEN_Desc", "Descripción", "CUEN_Desc");

            this.grdItemsAsiento.Columns.Add("DCCA_Glosa", "Glosa", "DCCA_Glosa");

            Telerik.WinControls.UI.GridViewCommandColumn _centroCto = new Telerik.WinControls.UI.GridViewCommandColumn();
            _centroCto.Name = "CentroCto";
            _centroCto.HeaderText = "Ayuda C.C.";
            _centroCto.DefaultText = "CentroCto";
            _centroCto.UseDefaultText = true;
            this.grdItemsAsiento.Columns.Add(_centroCto);

            this.grdItemsAsiento.Columns.Add("CENT_Codigo", "Código", "CENT_Codigo");
            this.grdItemsAsiento.Columns.Add("CENT_Desc", "Descripción", "CENT_Desc");
            this.grdItemsAsiento.Columns.Add("ValidarCentroCto", "ValidarCentroCto", "ValidarCentroCto");
            this.grdItemsAsiento.Columns["ValidarCentroCto"].IsVisible = false;
            //ValidarCentroCto

            /*cmbTIPO_CodOPE.ValueMember = "TIPO_CodTipo";
            cmbTIPO_CodOPE.DisplayMember = "TIPO_Desc1";
            cmbTIPO_CodOPE.DataSource = Presenter.DSTiposOPE.Tables[0];*/

            Telerik.WinControls.UI.GridViewComboBoxColumn _TipoOperacion = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _TipoOperacion.Name = "TIPO_CodOPE";
            _TipoOperacion.HeaderText = "Tipo Operación";
            _TipoOperacion.FieldName = "TIPO_CodOPEstr";
            _TipoOperacion.ValueMember = "TIPO_CodOPEstr";
            _TipoOperacion.DisplayMember = "TIPO_OPE";
            _TipoOperacion.DataSource = Presenter.DSTiposOPE.Tables[0];
            _TipoOperacion.DataType = typeof(System.String);
            _TipoOperacion.ReadOnly = true;
            _TipoOperacion.TextAlignment = ContentAlignment.MiddleLeft;
            //_tipoentidad.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            this.grdItemsAsiento.Columns.Add(_TipoOperacion);

            Telerik.WinControls.UI.GridViewDecimalColumn _porcentajeDebe = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _porcentajeDebe.Name = "DCCA_DebePorc";
            _porcentajeDebe.HeaderText = "Porcentaje";
            _porcentajeDebe.FieldName = "DCCA_DebePorc";
            _porcentajeDebe.DecimalPlaces = 2;
            _porcentajeDebe.Minimum = (Decimal)0.00;
            this.grdItemsAsiento.Columns.Add(_porcentajeDebe);

            Telerik.WinControls.UI.GridViewDecimalColumn _montoDebe = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _montoDebe.Name = "DCCA_DebeMonto";
            _montoDebe.HeaderText = "Monto";
            _montoDebe.FieldName = "DCCA_DebeMonto";
            _montoDebe.DecimalPlaces = 2;
            _montoDebe.Minimum = (Decimal)0.00;
            this.grdItemsAsiento.Columns.Add(_montoDebe);

            Telerik.WinControls.UI.GridViewDecimalColumn _porcentajeHaber = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _porcentajeHaber.Name = "DCCA_HaberPorc";
            _porcentajeHaber.HeaderText = "Porcentaje";
            _porcentajeHaber.FieldName = "DCCA_HaberPorc";
            _porcentajeHaber.DecimalPlaces = 2;
            _porcentajeHaber.Minimum = (Decimal)0.00;
            this.grdItemsAsiento.Columns.Add(_porcentajeHaber);

            Telerik.WinControls.UI.GridViewDecimalColumn _montoHaber = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _montoHaber.Name = "DCCA_HaberMonto";
            _montoHaber.HeaderText = "Monto";
            _montoHaber.FieldName = "DCCA_HaberMonto";
            _montoHaber.DecimalPlaces = 2;
            _montoHaber.Minimum = (Decimal)0.00;
            this.grdItemsAsiento.Columns.Add(_montoHaber);


            ColumnGroupsViewDefinition columnGroupsView = new ColumnGroupsViewDefinition();
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(""));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Cuenta"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Centro Costo"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Tipo Operación"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Glosa"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Debe"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Haber"));

            int index = 0;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].ShowHeader = false;
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsAsiento.Columns["Delete"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsAsiento.Columns["Cuenta"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsAsiento.Columns["DCCA_Cuenta"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsAsiento.Columns["CUEN_Desc"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsAsiento.Columns["CentroCto"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsAsiento.Columns["CENT_Codigo"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsAsiento.Columns["CENT_Desc"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].ShowHeader = false;
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsAsiento.Columns["TIPO_CodOPE"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].ShowHeader = false;
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsAsiento.Columns["DCCA_Glosa"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsAsiento.Columns["DCCA_DebePorc"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsAsiento.Columns["DCCA_DebeMonto"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsAsiento.Columns["DCCA_HaberPorc"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItemsAsiento.Columns["DCCA_HaberMonto"]);
            index++;

            grdItemsAsiento.ViewDefinition = columnGroupsView;

            this.grdItemsAsiento.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsAsiento);
            this.grdItemsAsiento.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.grdItemsAsiento.MultiSelect = false;

            this.grdItemsAsiento.ShowFilteringRow = false;
            this.grdItemsAsiento.EnableFiltering = false;
            this.grdItemsAsiento.MasterTemplate.EnableFiltering = false;
            this.grdItemsAsiento.EnableGrouping = false;
            this.grdItemsAsiento.MasterTemplate.EnableGrouping = false;
            this.grdItemsAsiento.EnableSorting = false;
            this.grdItemsAsiento.MasterTemplate.EnableCustomSorting = false;

            this.grdItemsAsiento.ReadOnly = false;
            this.grdItemsAsiento.AllowEditRow = true;

            this.grdItemsAsiento.Columns["DCCA_Cuenta"].ReadOnly = true;
            this.grdItemsAsiento.Columns["DCCA_Cuenta"].Width = 80;
            this.grdItemsAsiento.Columns["Cuenta"].Width = 50;

            this.grdItemsAsiento.Columns["CUEN_Desc"].ReadOnly = true;
            this.grdItemsAsiento.Columns["CUEN_Desc"].Width = 120;

            this.grdItemsAsiento.Columns["CENT_Codigo"].ReadOnly = true;
            this.grdItemsAsiento.Columns["CENT_Codigo"].Width = 80;
            this.grdItemsAsiento.Columns["CentroCto"].Width = 80;

            this.grdItemsAsiento.Columns["CENT_Desc"].ReadOnly = true;
            this.grdItemsAsiento.Columns["CENT_Desc"].Width = 120;

            this.grdItemsAsiento.Columns["DCCA_Glosa"].Width = 150;

            this.grdItemsAsiento.Columns["DCCA_DebeMonto"].ReadOnly = false;
            this.grdItemsAsiento.Columns["DCCA_HaberMonto"].ReadOnly = false;

            this.grdItemsAsiento.Columns["TIPO_CodOPE"].ReadOnly = false;
            this.grdItemsAsiento.Columns["TIPO_CodOPE"].Width = 140;

            //this.grdItemsAsiento.Columns["SCOT_Exonerado"].ReadOnly = true;
            //this.grdItemsServicio.Columns["SCOT_Exonerado"].Width = 60;
         }
         catch (Exception)
         { throw; }
      }

      public void ClearItem()
      {
         try
         {
            errorProviderMovimiento.Clear();
            ClearDetraccion();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ClearItem.", ex); }
      }

      public void ClearDetraccion()
      {
         try
         {
            cmbTIPO_CodDetrac.TiposSelectedValue = null;
            txnCCCT_MontoDetraccion.Value = (Decimal)0.0;
            txnCCCT_PorDetraccion.Value = (Decimal)0.0;
            txtCCCT_NroDetraccion.Text = String.Empty;
            dtpCCCT_FecDetraccion.NSFecha = null;
            chkCCCT_ProvAsumeDetraccion.Checked = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error limpiando Detraccion.", ex); }
      }

      public void GetItem()
      {
         try
         {
            errorProviderMovimiento.Clear();

            if (!Presenter.Item.SUCR_Codigo.HasValue) { Presenter.Item.SUCR_Codigo = Entorno.ItemSucursal.SUCR_Codigo; }

            if (dtpCCCT_FechaEmision.NSFecha.HasValue) { Presenter.Item.CCCT_FechaEmision = dtpCCCT_FechaEmision.NSFecha; }
            else { Presenter.Item.CCCT_FechaEmision = null; }
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null) { Presenter.Item.TIPE_Codigo = cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo; } else { Presenter.Item.TIPE_Codigo = null; }
            if (txaENTC_Codigo.SelectedItem != null) { Presenter.Item.ENTC_Codigo = txaENTC_Codigo.SelectedItem.ENTC_Codigo; } else { Presenter.Item.ENTC_Codigo = null; }
            if (cmbTIPO_CodTDO.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_CodTDO = cmbTIPO_CodTDO.TiposSelectedItem.TIPO_CodTipo;
               Presenter.Item.TIPO_TabTDO = cmbTIPO_CodTDO.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodTDO_CodSunat = cmbTIPO_CodTDO.TiposSelectedItem.TIPO_Desc2;
            }
            else
            {
               Presenter.Item.TIPO_CodTDO = null;
               Presenter.Item.TIPO_TabTDO = null;
               Presenter.Item.TIPO_CodTDO_CodSunat = null;
            }
            if (!String.IsNullOrEmpty(txtCCCT_Serie.Text)) { Presenter.Item.CCCT_Serie = txtCCCT_Serie.Text; } else { Presenter.Item.CCCT_Serie = null; }
            if (!String.IsNullOrEmpty(txtCCCT_Numero.Text)) { Presenter.Item.CCCT_Numero = txtCCCT_Numero.Text; } else { Presenter.Item.CCCT_Numero = null; }
            if (cmbTIPO_CodMND.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_CodMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo;
               Presenter.Item.TIPO_TabMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTabla;
            }
            else
            {
               Presenter.Item.TIPO_CodMND = null;
               Presenter.Item.TIPO_TabMND = null;
            }
            if (txnCCCT_TipoCambio.Value != 0) { Presenter.Item.CCCT_TipoCambio = txnCCCT_TipoCambio.Value; } else { Presenter.Item.CCCT_TipoCambio = null; }
            if (txnCCCT_ValVta.Value != 0) { Presenter.Item.CCCT_ValVta = txnCCCT_ValVta.Value; } else { Presenter.Item.CCCT_ValVta = null; }

            Presenter.Item.CCCT_Imp1 = txnCCCT_Imp1.Value;
            if (txnCCCT_Imp1.Value != 0) { Presenter.Item.CCCT_PorcImp1 = PorcentajeIGV; }

            Presenter.Item.CCCT_Imp4 = txnCCCT_Imp4.Value;
            if (txnCCCT_Imp4.Value != 0) { Presenter.Item.CCCT_PorcImp4 = 0; }
            //if (!String.IsNullOrEmpty(txnCCCT_Imp1.Text)) { Presenter.Item.CCCT_Imp1 = txnCCCT_Imp1.Value; } else { Presenter.Item.CCCT_Imp1 = null; }

            if (txnCCCT_Monto.Value != 0) { Presenter.Item.CCCT_Monto = txnCCCT_Monto.Value; } else { Presenter.Item.CCCT_Monto = null; }
            if (!String.IsNullOrEmpty(txtCCCT_Notas.Text)) { Presenter.Item.CCCT_Notas = txtCCCT_Notas.Text; } else { Presenter.Item.CCCT_Notas = null; }
            if (cmbTIPO_CodFPG.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_CodFPG = cmbTIPO_CodFPG.TiposSelectedItem.TIPO_CodTipo;
               Presenter.Item.TIPO_TabFPG = cmbTIPO_CodFPG.TiposSelectedItem.TIPO_CodTabla;
            }
            else
            {
               Presenter.Item.TIPO_CodFPG = null;
               Presenter.Item.TIPO_TabFPG = null;
            }

            if (cmbTIPO_CodDetrac.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabDetrac = cmbTIPO_CodDetrac.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodDetrac = cmbTIPO_CodDetrac.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabDetrac = null;
               Presenter.Item.TIPO_CodDetrac = null;
            }
            if (txnCCCT_MontoDetraccion.Value != 0) { Presenter.Item.CCCT_MontoDetraccion = txnCCCT_MontoDetraccion.Value; } else { Presenter.Item.CCCT_MontoDetraccion = null; }
            if (txnCCCT_PorDetraccion.Value != 0) { Presenter.Item.CCCT_PorDetraccion = txnCCCT_PorDetraccion.Value; } else { Presenter.Item.CCCT_PorDetraccion = null; }
            if (!String.IsNullOrEmpty(txtCCCT_NroDetraccion.Text)) { Presenter.Item.CCCT_NroDetraccion = txtCCCT_NroDetraccion.Text; } else { Presenter.Item.CCCT_NroDetraccion = null; }
            if (dtpCCCT_FecDetraccion.NSFecha.HasValue) { Presenter.Item.CCCT_FecDetraccion = dtpCCCT_FecDetraccion.NSFecha.Value; } else { Presenter.Item.CCCT_FecDetraccion = null; }
            if (dtpCCCT_FechaRecepcion.NSFecha.HasValue) { Presenter.Item.CCCT_FechaRecepcion = dtpCCCT_FechaRecepcion.NSFecha; } else { Presenter.Item.CCCT_FechaRecepcion = null; }
            if (dtpCCCT_FechaPosPago.NSFecha.HasValue) { Presenter.Item.CCCT_FechaPosPago = dtpCCCT_FechaPosPago.NSFecha; } else { Presenter.Item.CCCT_FechaPosPago = null; }
            if (dtpCCCT_FechaVcto.NSFecha.HasValue) { Presenter.Item.CCCT_FechaVcto = dtpCCCT_FechaVcto.NSFecha; } else { Presenter.Item.CCCT_FechaVcto = null; }
            if (dtpCCCT_FecReg.Value.Year > 1900) { Presenter.Item.CCCT_FecReg = dtpCCCT_FecReg.Value; } else { Presenter.Item.CCCT_FecReg = null; }

            if (!String.IsNullOrEmpty(txtCCCT_CuentaBI.Text)) { Presenter.Item.CCCT_CuentaBI = txtCCCT_CuentaBI.Text; } else { Presenter.Item.CCCT_CuentaBI = null; }
            if (!String.IsNullOrEmpty(txtCCCT_Cuenta.Text)) { Presenter.Item.CCCT_Cuenta = txtCCCT_Cuenta.Text; } else { Presenter.Item.CCCT_Cuenta = null; }
            if (!String.IsNullOrEmpty(txtCCCT_CuentaIGV.Text)) { Presenter.Item.CCCT_CuentaIGV = txtCCCT_CuentaIGV.Text; } else { Presenter.Item.CCCT_CuentaIGV = null; }
            if (!String.IsNullOrEmpty(txtCCCT_Glosa.Text)) { Presenter.Item.CCCT_Glosa = txtCCCT_Glosa.Text; } else { Presenter.Item.CCCT_Glosa = null; }
            Presenter.Item.CCCT_ProvAsumeDetraccion = chkCCCT_ProvAsumeDetraccion.Checked;

            if (txaCABP_Codigo.SelectedItem != null)
            {
               Presenter.Item.CABP_Ano = txaCABP_Codigo.SelectedItem.CABP_Ano;
               Presenter.Item.CABP_Codigo = txaCABP_Codigo.SelectedItem.CABP_Codigo;
            }
            else { Presenter.Item.CABP_Ano = null; Presenter.Item.CABP_Codigo = null; }

            if (pncDocReferencia.Visible)
            {
               /* Documento de Referencia Cuando es Nota de Crédito */
               Presenter.Item.CCCT_CodReferencia = null; if (txaCCCT_CodReferencia.SelectedItem != null) { Presenter.Item.CCCT_CodReferencia = txaCCCT_CodReferencia.SelectedItem.CCCT_Codigo; }
               Presenter.Item.TIPO_CodTDOReferencia = null; if (cmbTIPO_CodTDOReferencia.TiposSelectedValue != null) { Presenter.Item.TIPO_CodTDOReferencia = cmbTIPO_CodTDOReferencia.TiposSelectedItem.TIPO_CodTipo; }
               Presenter.Item.CCCT_SerieReferencia = null; if (!string.IsNullOrEmpty(txtCCCT_SerieReferencia.Text)) { Presenter.Item.CCCT_SerieReferencia = txtCCCT_SerieReferencia.Text; }
               Presenter.Item.CCCT_NumeroReferencia = null; if (!String.IsNullOrEmpty(txtCCCT_NumeroReferencia.Text)) { Presenter.Item.CCCT_NumeroReferencia = txtCCCT_NumeroReferencia.Text; }
               Presenter.Item.CCCT_FechaEmisionReferencia = null; if (dtpCCCT_FechaEmisionReferencia.NSFecha.HasValue) { Presenter.Item.CCCT_FechaEmisionReferencia = dtpCCCT_FechaEmisionReferencia.NSFecha; }
            }

            /* 01/03/2017 - Cambio para Renta de Tercera */

            Presenter.Item.TIPO_CodTI3 = null;
            Presenter.Item.TIPO_TabTI3 = null;
            if (cmbTIPO_CodTI3.TiposSelectedValue != null)
            {
               Presenter.Item.TIPO_TabTI3 = cmbTIPO_CodTI3.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodTI3 = cmbTIPO_CodTI3.TiposSelectedItem.TIPO_CodTipo;
               Presenter.Item.CCCT_PorcImp2 = cmbTIPO_CodTI3.TiposSelectedItem.TIPO_Num1.HasValue ? cmbTIPO_CodTI3.TiposSelectedItem.TIPO_Num1.Value : 0;
            }
            Presenter.Item.CCCT_Imp2 = null; if (txnCCCT_Imp2.Value != 0) { Presenter.Item.CCCT_Imp2 = txnCCCT_Imp2.Value; }
            Presenter.Item.CCCT_RetencionIGV = chkCCCT_RetencionIGV.Checked;

            /* Fin 01/03/2017 */
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
               if (Presenter.Item.CCCT_Codigo > 0) { txtCCCT_Codigo.Text = Presenter.Item.CCCT_Codigo.ToString(); }
               if (Presenter.Item.CCCT_FechaEmision.HasValue) { dtpCCCT_FechaEmision.NSFecha = Presenter.Item.CCCT_FechaEmision; }
               if (Presenter.Item.TIPE_Codigo.HasValue) { cmbTIPE_Codigo.TipoEntidadSelectedValue = Presenter.Item.TIPE_Codigo; }
               if (Presenter.Item.ENTC_Codigo.HasValue)
               {
                  txaENTC_Codigo.SetEntidad(Presenter.Item.ENTC_Codigo);
                  txaCCCT_CodReferencia.ENTC_Codigo = Presenter.Item.ENTC_Codigo.Value;
               }
               if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodTDO)) { cmbTIPO_CodTDO.SelectedValue = Presenter.Item.TIPO_CodTDO; }
               if (!String.IsNullOrEmpty(Presenter.Item.CCCT_Serie)) { txtCCCT_Serie.Text = Presenter.Item.CCCT_Serie; }
               if (!String.IsNullOrEmpty(Presenter.Item.CCCT_Numero)) { txtCCCT_Numero.Text = Presenter.Item.CCCT_Numero; }
               if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodMND)) { cmbTIPO_CodMND.TiposSelectedValue = Presenter.Item.TIPO_CodMND; }
               if (Presenter.Item.CCCT_TipoCambio.HasValue) { txnCCCT_TipoCambio.Value = Presenter.Item.CCCT_TipoCambio.Value; }
               if (Presenter.Item.CCCT_ValVta.HasValue) { txnCCCT_ValVta.Value = Presenter.Item.CCCT_ValVta.Value; }
               if (Presenter.Item.CCCT_Imp1.HasValue) { txnCCCT_Imp1.Value = Presenter.Item.CCCT_Imp1.Value; }
               if (Presenter.Item.CCCT_Imp4.HasValue) { txnCCCT_Imp4.Value = Presenter.Item.CCCT_Imp4.Value; }
               if (Presenter.Item.CCCT_Monto.HasValue) { txnCCCT_Monto.Value = Presenter.Item.CCCT_Monto.Value; }
               if (!String.IsNullOrEmpty(Presenter.Item.CCCT_Notas)) { txtCCCT_Notas.Text = Presenter.Item.CCCT_Notas; }

               if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodDetrac)) { cmbTIPO_CodDetrac.TiposSelectedValue = Presenter.Item.TIPO_CodDetrac; }
               if (Presenter.Item.CCCT_MontoDetraccion.HasValue) { txnCCCT_MontoDetraccion.Value = Presenter.Item.CCCT_MontoDetraccion.Value; }
               if (Presenter.Item.CCCT_PorDetraccion.HasValue) { txnCCCT_PorDetraccion.Value = Presenter.Item.CCCT_PorDetraccion.Value; }
               if (!String.IsNullOrEmpty(Presenter.Item.CCCT_NroDetraccion)) { txtCCCT_NroDetraccion.Text = Presenter.Item.CCCT_NroDetraccion; }
               if (Presenter.Item.CCCT_FecDetraccion.HasValue) { dtpCCCT_FecDetraccion.NSFecha = Presenter.Item.CCCT_FecDetraccion; }

               if (Presenter.Item.CCCT_FechaRecepcion.HasValue) { dtpCCCT_FechaRecepcion.NSFecha = Presenter.Item.CCCT_FechaRecepcion; }
               if (Presenter.Item.CCCT_FechaPosPago.HasValue) { dtpCCCT_FechaPosPago.NSFecha = Presenter.Item.CCCT_FechaPosPago; }
               if (Presenter.Item.CCCT_FechaVcto.HasValue) { dtpCCCT_FechaVcto.NSFecha = Presenter.Item.CCCT_FechaVcto; }
               if (Presenter.Item.CCCT_FecReg.HasValue) { dtpCCCT_FecReg.Value = Presenter.Item.CCCT_FecReg.Value; }
               if (Presenter.Item.CABP_Codigo != null && Presenter.Item.CABP_Ano != null)
               {
                  txaCABP_Codigo.SelectedItemChanged -= txaCABP_Codigo_SelectedItemChanged;
                  txaCABP_Codigo.SetPerfilAsientos(Presenter.Item.CABP_Ano, Presenter.Item.CABP_Codigo);
                  txaCABP_Codigo.SelectedItemChanged += txaCABP_Codigo_SelectedItemChanged;
               }
               if (!String.IsNullOrEmpty(Presenter.Item.CCCT_Glosa)) { txtCCCT_Glosa.Text = Presenter.Item.CCCT_Glosa; }

               txtAsientos.Text = String.Format("{0} / {1}", Presenter.Item.AsientoContable, Presenter.Item.AsientoContableC);

               if (Presenter.Item.CCCT_CodReferencia.HasValue)
               { txaCCCT_CodReferencia.SetValue(Presenter.Item.EMPR_Codigo, Presenter.Item.CCCT_CodReferencia.Value); }
               else
               {
                  if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodTDOReferencia)) { cmbTIPO_CodTDOReferencia.SelectedValue = Presenter.Item.TIPO_CodTDOReferencia; }
                  if (!String.IsNullOrEmpty(Presenter.Item.CCCT_SerieReferencia)) { txtCCCT_SerieReferencia.Text = Presenter.Item.CCCT_SerieReferencia; }
                  if (!String.IsNullOrEmpty(Presenter.Item.CCCT_NumeroReferencia)) { txtCCCT_NumeroReferencia.Text = Presenter.Item.CCCT_NumeroReferencia; }
                  dtpCCCT_FechaEmisionReferencia.NSFecha = Presenter.Item.CCCT_FechaEmisionReferencia;
               }

               if (!String.IsNullOrEmpty(Presenter.Item.CCCT_Cuenta)) { txtCCCT_Cuenta.Text = Presenter.Item.CCCT_Cuenta; }
               if (!String.IsNullOrEmpty(Presenter.Item.CCCT_CuentaIGV)) { txtCCCT_CuentaIGV.Text = Presenter.Item.CCCT_CuentaIGV; }
               if (!String.IsNullOrEmpty(Presenter.Item.CCCT_CuentaBI)) { txtCCCT_CuentaBI.Text = Presenter.Item.CCCT_CuentaBI; }

               if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodFPG)) { cmbTIPO_CodFPG.SelectedValue = Presenter.Item.TIPO_CodFPG; }

               /* 01/03/2017 - Cambio para Renta de Tercera */

               if (Presenter.Item.CCCT_Imp2.HasValue) { txnCCCT_Imp2.Value = Presenter.Item.CCCT_Imp2.Value; }
               if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodTI3)) { cmbTIPO_CodTI3.SelectedValue = Presenter.Item.TIPO_CodTI3; }
               if (Presenter.Item.CCCT_RetencionIGV.HasValue) { chkCCCT_RetencionIGV.Checked = Presenter.Item.CCCT_RetencionIGV.Value; }

               /* Fin 01/03/2017 */

               chkCCCT_ProvAsumeDetraccion.Checked = (Presenter.Item.CCCT_ProvAsumeDetraccion.HasValue ? Presenter.Item.CCCT_ProvAsumeDetraccion.Value : false);

               if (Presenter.Item.ItemCabPerfilAsientos != null && Presenter.Item.ItemCabPerfilAsientos.ListDetPerfilAsientos != null && Presenter.Item.ItemCabPerfilAsientos.ListDetPerfilAsientos.Count > 0)
               { grdItemsPAsiento.DataSource = Presenter.Item.ItemCabPerfilAsientos.ListDetPerfilAsientos; }

                BSItemsFlete.DataSource = Presenter.Item.ListDetCtaCte;
               BSItemsFlete.ResetBindings(false);

               BSItemsAsiento.DataSource = Presenter.Item.ListDetCtaCteAsientos;
               BSItemsAsiento.ResetBindings(false);

               EnabledItem(true);
               switch (Presenter.TInicio)
               {
                  case CAJ012IngresoLibrePresenter.TipoInicio.Normal:
                     if (Presenter.Item.ListDetCtaCte != null)
                     {
                        if (Presenter.Item.ListDetCtaCte.Count > 1)
                        {
                           EnabledItem(true);
                           Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "El registro tiene movimientos de cuenta corriente.");
                        }
                     }
                     if (Presenter.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
                     {
                        cmbTIPO_CodMND.Enabled = true;

                     }
                     break;
                  case CAJ012IngresoLibrePresenter.TipoInicio.MostraCtaCte:
                     btnGuardar.Enabled = false;
                     EnabledItem(false);
                     panel3.Visible = false;
                     txaCABP_Codigo.Enabled = false;
                     dtpCCCT_FechaVcto.Enabled = false;
                     chkCCCT_ProvAsumeDetraccion.Enabled = false;
                     if (txaENTC_Codigo.SelectedItem != null)
                     {
                        this.Text = String.Format("Cta. Cte. : {0} /  Entidad : {1}", Presenter.Item.CCCT_Codigo, txaENTC_Codigo.SelectedItem.ENTC_RazonSocial);
                     }
                     break;
                  default:
                     throw new ArgumentOutOfRangeException();
               }

               switch (Presenter.Item.TMovimiento)
               {
                  case Delfin.Entities.CtaCte.TipoMovimiento.Ingreso:
                     this.grdItemsAsiento.Columns["DCCA_DebePorc"].ReadOnly = true;
                     this.grdItemsAsiento.Columns["DCCA_DebePorc"].IsVisible = false;
                     this.grdItemsAsiento.Columns["DCCA_DebeMonto"].IsVisible = false;

                     this.grdItemsAsiento.Columns["DCCA_HaberPorc"].ReadOnly = false;
                     this.grdItemsAsiento.Columns["DCCA_HaberPorc"].IsVisible = true;
                     this.grdItemsAsiento.Columns["DCCA_HaberMonto"].IsVisible = true;

                     btnAddAsiento.Visible = false;
                     tabControl1.TabPages.Remove(tpgAsiento);
                     tabControl1.SelectedTab = tpgHistorial;
                     txaCABP_Codigo.Visible = false;
                     lblCABP_Codigo.Visible = false;
                     break;
                  case Delfin.Entities.CtaCte.TipoMovimiento.Egreso:
                     this.grdItemsAsiento.Columns["DCCA_DebePorc"].ReadOnly = false;
                     this.grdItemsAsiento.Columns["DCCA_DebePorc"].IsVisible = true;
                     this.grdItemsAsiento.Columns["DCCA_DebeMonto"].IsVisible = true;

                     this.grdItemsAsiento.Columns["DCCA_HaberPorc"].ReadOnly = true;
                     this.grdItemsAsiento.Columns["DCCA_HaberPorc"].IsVisible = false;
                     this.grdItemsAsiento.Columns["DCCA_HaberMonto"].IsVisible = false;

                     tabControl1.SelectedTab = tpgAsiento;
                     if (Presenter.Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
                     {
                        if (String.IsNullOrEmpty(Presenter.Item.CABA_Ano) && String.IsNullOrEmpty(Presenter.Item.CABA_Mes) && String.IsNullOrEmpty(Presenter.Item.CABA_NroVoucher))
                        {
                           btnAddAsiento.Visible = false;
                           tabControl1.TabPages.Remove(tpgAsiento);
                           tabControl1.SelectedTab = tpgHistorial;
                           txaCABP_Codigo.Visible = false;
                           lblCABP_Codigo.Visible = false;
                        }
                        else if (!String.IsNullOrEmpty(Presenter.Item.CABA_Ano) && !String.IsNullOrEmpty(Presenter.Item.CABA_Mes) && !String.IsNullOrEmpty(Presenter.Item.TIPO_CodREG)
                           && !String.IsNullOrEmpty(Presenter.Item.CABA_NroVoucher) && Presenter.Item.TIPO_CodREG.Equals(Presenter.TR_DGENERAL))
                        {
                           if (!String.IsNullOrEmpty(Presenter.Item.CABA_Ano_LCompras) && !String.IsNullOrEmpty(Presenter.Item.CABA_Mes_LCompras)
                              && !String.IsNullOrEmpty(Presenter.Item.TIPO_CodREG_LCompras) && !String.IsNullOrEmpty(Presenter.Item.CABA_NroVoucher_LCompras)
                              && Presenter.Item.TIPO_CodREG_LCompras.Equals(Presenter.TR_RCOMPRAS))
                           {
                              btnAddAsiento.Enabled = false;
                              grdItemsAsiento.Columns["Delete"].IsVisible = false;
                              grdItemsAsiento.Columns["Cuenta"].IsVisible = false;
                              grdItemsAsiento.Columns["CentroCto"].IsVisible = false;
                              grdItemsAsiento.ReadOnly = true;
                           }
                           else
                           {
                              btnAddAsiento.Enabled = true;
                              grdItemsAsiento.Columns["Delete"].IsVisible = true;
                              grdItemsAsiento.Columns["Cuenta"].IsVisible = true;
                              grdItemsAsiento.Columns["CentroCto"].IsVisible = true;
                              grdItemsAsiento.ReadOnly = false;
                           }
                        }
                        else
                        {
                           btnAddAsiento.Enabled = true;
                           grdItemsAsiento.Columns["Delete"].IsVisible = true;
                           grdItemsAsiento.Columns["Cuenta"].IsVisible = true;
                           grdItemsAsiento.Columns["CentroCto"].IsVisible = true;
                           grdItemsAsiento.ReadOnly = false;
                        }
                     }
                     else
                     {

                     }
                     break;
                  default:
                     break;
               }
               this.grdItemsAsiento.Columns["Cuenta"].Width = 50;
               HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
               if (Presenter.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
               {
                  cmbTIPO_CodTDO.LoadControl(Presenter.ContainerService, "Tipo Documento", "TDO", "< Sel. Tipo Documento >", ListSortDirection.Ascending, Presenter.TIPO_CodTDO_Disponibles);
               }

            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en SetItem.", ex); }
      }

      private void EnabledItem(Boolean x_opcion)
      {
         try
         {
            cmbTIPE_Codigo.Enabled = x_opcion;
            txaENTC_Codigo.Enabled = x_opcion;
            cmbTIPO_CodTDO.Enabled = x_opcion;
            cmbTIPO_CodMND.Enabled = x_opcion;
            txtCCCT_Serie.ReadOnly = !x_opcion;
            txtCCCT_Notas.ReadOnly = !x_opcion;
            txtCCCT_NroDetraccion.ReadOnly = !x_opcion;
            txtCCCT_Numero.ReadOnly = !x_opcion;

            cmbTIPO_CodDetrac.Enabled = x_opcion;
            txnCCCT_Monto.Enabled = x_opcion;
            txnCCCT_Imp1.Enabled = x_opcion;
            txnCCCT_Imp4.Enabled = x_opcion;
            txnCCCT_MontoDetraccion.Enabled = x_opcion;
            txnCCCT_PorDetraccion.Enabled = x_opcion;
            txnCCCT_TipoCambio.Enabled = x_opcion;
            txnCCCT_ValVta.Enabled = x_opcion;

            dtpCCCT_FechaEmision.Enabled = x_opcion;
            dtpCCCT_FecDetraccion.Enabled = x_opcion;
            dtpCCCT_FechaPosPago.Enabled = x_opcion;
            dtpCCCT_FechaRecepcion.Enabled = x_opcion;
            dtpCCCT_FecReg.Enabled = x_opcion;

            txtCCCT_CuentaBI.ReadOnly = !x_opcion;
            txtCCCT_CuentaIGV.ReadOnly = !x_opcion;
            txtCCCT_Cuenta.ReadOnly = !x_opcion;

            txtCCCT_Glosa.ReadOnly = !x_opcion;
            cmbTIPO_CodFPG.Enabled = x_opcion;

            btnAddAsiento.Visible = x_opcion;

            if (Presenter.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
            { }
            else
            {
               cmbTIPO_CodMND.Enabled = false;
               txnCCCT_Imp1.Enabled = false;
               txnCCCT_Imp4.Enabled = false;
               txnCCCT_Monto.Enabled = false;
               txnCCCT_ValVta.Enabled = false;
               //dtpCCCT_FecReg.Enabled = false;
               lblCCCT_Cuenta4Ta.Enabled = true;
               lblCCCT_CuentaIGV.Enabled = false;
               txtCCCT_CuentaIGV.Enabled = false;

               if (x_opcion)
               {
                  cmbTIPO_CodTDO.SelectedIndexChanged -= cmbTIPO_CodTDO_SelectedIndexChanged;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en EnabledItem.", ex); }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.CtaCte>.Validate(Presenter.Item, this, errorProviderMovimiento);
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, revise los detalles.", Presenter.Item.MensajeError);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }

      private void CalcularTotal()
      {
         try
         {
            txnCCCT_Monto.Value = Math.Round(txnCCCT_ValVta.Value + txnCCCT_Imp1.Value + txnCCCT_Imp2.Value + txnCCCT_Imp4.Value, 2, MidpointRounding.AwayFromZero);
            CalcularDetraccion();
         }
         catch (Exception)
         { throw; }
      }

      private void CalcularDetraccion()
      {
         try
         {
            if (tlpDetraccion.Visible && cmbTIPO_CodDetrac.TiposSelectedItem != null && txnCCCT_Monto.Value != 0)
            {
               Decimal _monto = 0;
               if (Presenter.DET_REDONDEONORMAL)
               {
                  if (cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo.Equals(Util.getMoneda(TMoneda.Soles)))
                  {
                     _monto = Math.Round(txnCCCT_PorDetraccion.Value * txnCCCT_Monto.Value / 100, 0, MidpointRounding.AwayFromZero);
                  }
                  else if (cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo.Equals(Util.getMoneda(TMoneda.Dolares)))
                  {
                     _monto = Math.Round((txnCCCT_PorDetraccion.Value * txnCCCT_Monto.Value * txnCCCT_TipoCambio.Value / 100), 0, MidpointRounding.AwayFromZero);
                  }
               }
               else
               {
                  if (cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo.Equals(Util.getMoneda(TMoneda.Soles)))
                  {
                     _monto = Math.Ceiling(txnCCCT_PorDetraccion.Value * txnCCCT_Monto.Value / 100);
                  }
                  else if (cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo.Equals(Util.getMoneda(TMoneda.Dolares)))
                  {
                     _monto = Math.Ceiling((txnCCCT_PorDetraccion.Value * txnCCCT_Monto.Value * txnCCCT_TipoCambio.Value / 100));
                  }
               }
               txnCCCT_MontoDetraccion.Value = _monto;
            }
         }
         catch (Exception)
         { throw; }
      }

      private void CargarAdicionales()
      {
         try
         {
            if (Presenter.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
            {
               if (txaENTC_Codigo.SelectedItem != null)
               {
                  Int16 _dias = 0;
                  if (txaENTC_Codigo.SelectedItem.TIPE_Codigo == EntidadClear.GetCodigoTipoEntidad(TiposEntidad.TIPE_Cliente))
                  {
                     if (Presenter.CargarFormaPago(txaENTC_Codigo.SelectedItem.ENTC_Codigo, ref _dias))
                     {
                        dtpCCCT_FechaVcto.NSFecha = Presenter.Fecha.AddDays((double)_dias);
                     }
                     else { dtpCCCT_FechaVcto.NSClear(); }
                  }
                  if (txaENTC_Codigo.SelectedItem.ENTC_Codigo > 0)
                  { txaCCCT_CodReferencia.ENTC_Codigo = txaENTC_Codigo.SelectedItem.ENTC_Codigo; }
                  /* Renta de 3ra */
                  Presenter.Item.NoDomiciliado = txaENTC_Codigo.SelectedItem.ENTC_Domiciliado;
                  if (txaENTC_Codigo.SelectedItem.ENTC_Domiciliado)
                  { pnlRenta3ra.Visible = true; txnCCCT_Imp1.Enabled = false; label10.Enabled = false; txnCCCT_Imp1.Value = 0; }
                  else
                  { pnlRenta3ra.Visible = false; txnCCCT_Imp1.Enabled = true; label10.Enabled = true; }
                  CalcularTotal();
               }
               else
               {
                  pnlRenta3ra.Visible = false;
                  cmbTIPO_CodTI3.SelectedIndex = 0;
                  chkCCCT_RetencionIGV.Checked = false;
               }
            }
            else
            {
               if (txaENTC_Codigo.SelectedItem != null)
               {
                  Presenter.Item.NoDomiciliado = txaENTC_Codigo.SelectedItem.ENTC_Domiciliado;
                  if (txaENTC_Codigo.SelectedItem.ENTC_Domiciliado)
                  { pnlRenta3ra.Visible = true; txnCCCT_Imp1.Enabled = false; label10.Enabled = false; txnCCCT_Imp1.Value = 0; }
                  else
                  { pnlRenta3ra.Visible = false; txnCCCT_Imp1.Enabled = true; label10.Enabled = true; }
               }
               else { pnlRenta3ra.Visible = false; txnCCCT_Imp1.Enabled = true; label10.Enabled = true; }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error a cargar datos adicionales de la Entidad.", ex); }
      }

      private void SeleccionarCuenta(Int32 rowIndex)
      {
         try
         {
            String _DCCA_Cuenta = ""; // grdItemsAsiento.Rows[rowIndex].Cells["CENT_Codigo"].Value.ToString();
            String _CUEN_Desc = "";
            Boolean _ValidarCentroCto = false;
            if (Presenter.AyudaCuenta(ref _DCCA_Cuenta, ref _CUEN_Desc, ref _ValidarCentroCto))
            {
               grdItemsAsiento.Rows[rowIndex].Cells["DCCA_Cuenta"].Value = _DCCA_Cuenta;
               grdItemsAsiento.Rows[rowIndex].Cells["CUEN_Desc"].Value = _CUEN_Desc;
               grdItemsAsiento.Rows[rowIndex].Cells["ValidarCentroCto"].Value = _ValidarCentroCto;
            }
            BSItemsAsiento.ResetBindings(false);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error a cargar la ayuda de Cuentas.", ex); }
      }

      private void SeleccionarCentroCto(Int32 rowIndex)
      {
         try
         {
            String _CENT_Codigo = ""; //grdItemsAsiento.Rows[rowIndex].Cells["CENT_Codigo"].Value.ToString();
            String _CENT_Desc = null;
            string _CENT_Ano = null;
            if (Presenter.AyudaCentroCto(ref _CENT_Ano, ref _CENT_Codigo, ref _CENT_Desc))
            {
               ((Entities.DetCtaCteAsientos)BSItemsAsiento.Current).CENT_Ano = _CENT_Ano;
               //grdItemsAsiento.Rows[rowIndex].Cells["CENT_Ano"].Value = _CENT_Ano;
               grdItemsAsiento.Rows[rowIndex].Cells["CENT_Codigo"].Value = _CENT_Codigo;
               grdItemsAsiento.Rows[rowIndex].Cells["CENT_Desc"].Value = _CENT_Desc;
            }
            BSItemsAsiento.ResetBindings(false);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error a cargar la ayuda de Centros de Costo.", ex); }
      }

      private void CalcularImp3ra()
      {
         try
         {
            if (cmbTIPO_CodTI3.TiposSelectedItem != null)
            {
               Decimal _MontoBase = txnCCCT_ValVta.Value;
               Decimal _Imp2 = 0;
               PorcentajeIGV = cmbTIPO_CodTI3.TiposSelectedItem.TIPO_Num1.HasValue ? cmbTIPO_CodTI3.TiposSelectedItem.TIPO_Num1.Value : 0;
               if (_MontoBase > 0)
               {
                  _Imp2 = -Math.Round(_MontoBase * (PorcentajeIGV / 100), 2, MidpointRounding.AwayFromZero);
                  txnCCCT_Imp1.Value = 0;
               }
               txnCCCT_Imp2.Value = _Imp2;
               //CalcularTotal();
               CalcularTotal();
            }
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos De Asientos ]

      private void EliminarDocumento()
      {
         try
         {
            if (BSItemsAsiento.Current != null)
            {
               Entities.DetCtaCteAsientos _detctacte = (BSItemsAsiento.Current as Entities.DetCtaCteAsientos);
               if (Presenter.EliminarDetAsiento(_detctacte))
               {
                  ShowDocumentos();
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar Item.", ex); }
      }

      private void ShowDocumentos()
      {
         try
         {
            BSItemsAsiento.ResetBindings(true);
         }
         catch (Exception)
         { }
      }

      #endregion

      #region [ Eventos ]

      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Guardar(true))
            {
               this.FormClosing -= MView_FormClosing;
               errorProviderDet_Cotizacion_OV_Novedad.Dispose();
               Presenter.Actualizar();
               this.Close();
            }
            else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No  completo el proceso de guardado."); }
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
                  if (Presenter.GuardarCambios() == System.Windows.Forms.DialogResult.Cancel && btnGuardar.Enabled)
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

      private void cmbTIPE_Codigo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
            {
               txaENTC_Codigo.TiposEntidad = EntidadClear.getTipoEntidadEnum(cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo);
               txaENTC_Codigo.Enabled = true;
               txaENTC_Codigo.Clear();
               if (txaENTC_Codigo.TiposEntidad == TiposEntidad.TIPE_Cliente)
               {
                  pnlDetraccion.Visible = false;
                  tlpDetraccion.Visible = false;
                  ClearDetraccion();
               }
               else
               {
                  pnlDetraccion.Visible = true;
                  tlpDetraccion.Visible = true;
                  ClearDetraccion();
               }
            }
            else
            { txaENTC_Codigo.Enabled = false; txaENTC_Codigo.Clear(); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar un tipo de entidad.", ex); }
      }

      private void cmbTIPO_CodDetrac_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPO_CodDetrac.TiposSelectedItem != null)
            {
               txnCCCT_PorDetraccion.Value = (cmbTIPO_CodDetrac.TiposSelectedItem.TIPO_Num1.HasValue ? cmbTIPO_CodDetrac.TiposSelectedItem.TIPO_Num1.Value : 0);

               if (cmbTIPO_CodDetrac.TiposSelectedItem.TIPO_CodTipo.Equals(Entities.Tipos.GetTipo(Entities.Tipos.TipoDetraccion.SinDetraccion)))
               { setDatosDetraccion(false); }
               else
               { setDatosDetraccion(true); }

               CalcularTotal();
            }
            else { setDatosDetraccion(false); }
         }
         catch (Exception)
         { }
      }

      private void setDatosDetraccion(Boolean x_opcion)
      {
         lblCCCT_MontoDetraccion.Enabled = x_opcion;
         txnCCCT_PorDetraccion.Enabled = x_opcion;
         lblCCCT_PorDetraccion.Enabled = x_opcion;
         txtCCCT_NroDetraccion.Enabled = x_opcion;
         lblCCCT_NroDetraccion.Enabled = x_opcion;
         dtpCCCT_FecDetraccion.Enabled = x_opcion;
         lblCCCT_FecDetraccion.Enabled = x_opcion;
      }

      private void txnCCCT_Imp1_LostFocus(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Item != null)
            {
               CalcularTotal();
            }
         }
         catch (Exception)
         { }
      }

      private void txnCCCT_Imp4_LostFocus(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Item != null)
            {
               CalcularTotal();
            }
         }
         catch (Exception)
         { }
      }

      private void txnCCCT_ValVta_LostFocus(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Item != null)
            {
               if (!cmbTIPO_CodTDO.SelectedValue.ToString().Equals(Entities.Tipos.GetTipo(Entities.Tipos.TipoTDO.ReciboHonorario)))
               {
                  txnCCCT_Imp1.Value = txnCCCT_ValVta.Value * Presenter.IGV / 100;
                  CalcularTotal();
                  grdItemsAsiento_CellValueChanged(null, null);
               }
               else
               {
                  CalcularTotal();
               }
            }
         }
         catch (Exception)
         { }
      }

      private void dtpCCCT_FechaRecepcion_SelectedDateChanged(object sender, EventArgs e)
      {
         try
         {
            if (dtpCCCT_FechaRecepcion != null && dtpCCCT_FechaRecepcion.NSFecha.HasValue)
            {
               txaCABP_Codigo.CABP_Ano = dtpCCCT_FechaRecepcion.NSFecha.Value.Year.ToString();
            }
         }
         catch (Exception)
         { }
      }

      private void txaCABP_Codigo_SelectedItemChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaCABP_Codigo.SelectedItem != null)
            {
               Presenter.ObtenerAsientos(txaCABP_Codigo.SelectedItem.CABP_Ano, txaCABP_Codigo.SelectedItem.CABP_Codigo);

               Presenter.Item.CCCT_ValVta = txnCCCT_ValVta.Value;

               if (cmbTIPO_CodTDO.TiposSelectedItem != null)
               { Presenter.Item.TIPO_CodTDO = cmbTIPO_CodTDO.TiposSelectedItem.TIPO_CodTipo; }
               else
               { Presenter.Item.TIPO_CodTDO = Entities.Tipos.GetTipo(Entities.Tipos.TipoTDO.Factura); }

               Presenter.GenerarAsiento();
               BSItemsAsiento.DataSource = Presenter.Item.ListDetCtaCteAsientos;
               BSItemsAsiento.ResetBindings(false);
               grdItemsAsiento.EndEdit();
               grdItemsAsiento_CellValueChanged(null, null);

               if (Presenter.Item.ItemCabPerfilAsientos != null && Presenter.Item.ItemCabPerfilAsientos.ListDetPerfilAsientos != null && Presenter.Item.ItemCabPerfilAsientos.ListDetPerfilAsientos.Count > 0)
               { grdItemsPAsiento.DataSource = Presenter.Item.ItemCabPerfilAsientos.ListDetPerfilAsientos; }
            }
         }
         catch (Exception)
         { }
      }

      private void txaENTC_Codigo_SelectedItemChanged(object sender, EventArgs e)
      { CargarAdicionales(); }

      private void txaCCCT_CodReferencia_AyudaValueChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaCCCT_CodReferencia.SelectedItem != null)
            {
               cmbTIPO_CodTDOReferencia.SelectedValue = txaCCCT_CodReferencia.SelectedItem.TIPO_CodTDO;
               txtCCCT_SerieReferencia.Text = txaCCCT_CodReferencia.SelectedItem.CCCT_Serie;
               txtCCCT_NumeroReferencia.Text = txaCCCT_CodReferencia.SelectedItem.CCCT_Numero;
               dtpCCCT_FechaEmisionReferencia.NSFecha = txaCCCT_CodReferencia.SelectedItem.CCCT_FechaEmision;

               cmbTIPO_CodTDOReferencia.Enabled = false;
               txtCCCT_SerieReferencia.Enabled = false;
               txtCCCT_NumeroReferencia.Enabled = false;
               dtpCCCT_FechaEmisionReferencia.Enabled = false;
            }
            else
            {
               cmbTIPO_CodTDOReferencia.SelectedIndex = 0;
               txtCCCT_SerieReferencia.Clear();
               txtCCCT_NumeroReferencia.Clear();
               dtpCCCT_FechaEmisionReferencia.NSClear();

               cmbTIPO_CodTDOReferencia.Enabled = true;
               txtCCCT_SerieReferencia.Enabled = true;
               txtCCCT_NumeroReferencia.Enabled = true;
               dtpCCCT_FechaEmisionReferencia.Enabled = true;
            }
         }
         catch (Exception)
         { }
      }

      private void txnCCCT_Imp2_LostFocus(object sender, EventArgs e)
      {
         try
         {
            if (txnCCCT_Imp2.Value > 0)
            { txnCCCT_Imp2.Value = 0; }
            CalcularTotal();
         }
         catch (Exception)
         { }
      }

      #region [ Detalle de Asientos ]

      private void btnAddAsiento_Click(object sender, EventArgs e)
      {
         try
         {
            Entities.DetCtaCteAsientos _asiento = new Entities.DetCtaCteAsientos();
            Int16 _item = 0;
            if (((ObservableCollection<Entities.DetCtaCteAsientos>)BSItemsAsiento.DataSource).Count > 0)
            {
               _item = ((ObservableCollection<Entities.DetCtaCteAsientos>)BSItemsAsiento.DataSource).Max(Asi => Asi.DCCA_Item);
            }
            _asiento.DCCA_Item = ++_item;
            _asiento.AUDI_UsrCrea = Presenter.Session.UserName;
            _asiento.TIPO_TabOPE = "OPE";
            _asiento.TIPO_CodOPE = "001";
            _asiento.DCCA_Glosa = "";

            _asiento.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

            BSItemsAsiento.Add(_asiento);
            BSItemsAsiento.ResetBindings(true);
            this.grdItemsAsiento.Columns["Cuenta"].Width = 50;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al quitar un nuevo registro al asiento.", ex); }
      }

      private void grdItemsAsiento_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((sender as Telerik.WinControls.UI.GridCommandCellElement).ColumnInfo.Name)
               {
                  case "Cuenta":
                     SeleccionarCuenta(((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex);
                     break;
                  case "CentroCto":
                     SeleccionarCentroCto(((Telerik.WinControls.UI.GridCommandCellElement)sender).RowIndex);
                     break;
                  case "Delete":
                     EliminarDocumento();
                     break;
               }
            }
         }
         catch (Exception)
         { throw; }
      }


      private void grdItemsAsiento_CellEndEdit(object sender, GridViewCellEventArgs e)
      {
         try
         {

         }
         catch (Exception)
         { }
      }

      private void grdItemsAsiento_CurrentCellChanged(object sender, CurrentCellChangedEventArgs e)
      {
         try
         {

         }
         catch (Exception)
         { }
      }


      private void grdItemsAsiento_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
      {
         try
         {

         }
         catch (Exception)
         { }
      }

      private void grdItemsAsiento_CellFormatting(object sender, CellFormattingEventArgs e)
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
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }

      private void txtCCCT_Numero_KeyPress(object sender, KeyPressEventArgs e)
      {
         Infrastructure.Aspect.Constants.Util.ValidaCodigo_KeyPress(ref e);
      }

      private void grdItemsAsiento_CellValueChanged(object sender, GridViewCellEventArgs e)
      {
         try
         {
            if (BSItemsAsiento != null && BSItemsAsiento.Current != null)
            {
               grdItemsAsiento.EndEdit();
               if (e != null && e.Column.Name.Equals("DCCA_DebeMonto"))
               {
                  Decimal _totalBaseHaber = 0, _totalBaseAfecta = 0;
                  Decimal _porTotal = 0;
                  foreach (Entities.DetCtaCteAsientos iDet in ((ObservableCollection<Entities.DetCtaCteAsientos>)BSItemsAsiento.DataSource))
                  {
                     _totalBaseHaber += iDet.DCCA_DebeMonto;
                     String _NoGravada = "004";

                     if (!String.IsNullOrEmpty(iDet.TIPO_CodOPE))
                     { if (!iDet.TIPO_CodOPE.Equals(_NoGravada)) { _totalBaseAfecta += iDet.DCCA_DebeMonto; } }
                     else
                     { _totalBaseAfecta += iDet.DCCA_DebeMonto; }
                     _porTotal += iDet.DCCA_DebePorc;
                  }
                  if (txnCCCT_ValVta.Value > _totalBaseHaber)
                  {
                     Decimal _porDebe = 100 * ((Entities.DetCtaCteAsientos)BSItemsAsiento.Current).DCCA_DebeMonto / txnCCCT_ValVta.Value;
                     ((Entities.DetCtaCteAsientos)BSItemsAsiento.Current).DCCA_DebePorc = _porDebe;
                  }
                  else
                  {
                     if (cmbTIPO_CodTDO.SelectedValue.ToString().Equals(Entities.Tipos.GetTipo(Entities.Tipos.TipoTDO.ReciboHonorario)))
                     {
                        /* Calcular el IGV */
                        txnCCCT_Imp1.Value = 0;
                     }
                     else
                     {
                        txnCCCT_Imp1.Value = Math.Round(_totalBaseAfecta * Presenter.IGV / 100, 2, MidpointRounding.AwayFromZero);
                     }
                     txnCCCT_ValVta.Value = _totalBaseHaber;

                     Presenter.Item.CCCT_ValVta = _totalBaseHaber;
                     _porTotal = 0;
                     foreach (Entities.DetCtaCteAsientos item in ((ObservableCollection<Entities.DetCtaCteAsientos>)BSItemsAsiento.DataSource))
                     {
                        Decimal _porDebe = Math.Round(100 * item.DCCA_DebeMonto / txnCCCT_ValVta.Value, 2, MidpointRounding.AwayFromZero);
                        item.DCCA_DebePorc = _porDebe;
                        _porTotal += item.DCCA_DebePorc;
                     }
                     txnCCCT_ValVta_LostFocus(null, null);
                  }
                  /* Ajustar Porcentajes */
                  if (txnCCCT_ValVta.Value == _totalBaseHaber)
                  {
                     Decimal Maximo = ((ObservableCollection<Entities.DetCtaCteAsientos>)BSItemsAsiento.DataSource).Max(Det => Det.DCCA_DebePorc);
                     Decimal _dif = Math.Round(100 - _porTotal, 2, MidpointRounding.AwayFromZero);

                     Entities.DetCtaCteAsientos _detAsiento = ((ObservableCollection<Entities.DetCtaCteAsientos>)BSItemsAsiento.DataSource).Where(Det => Det.DCCA_DebePorc == Maximo).FirstOrDefault();
                     _detAsiento.DCCA_DebePorc += _dif;
                  }
                  BSItemsAsiento.ResetBindings(false);
               }
               else if (e != null && e.Column.Name.Equals("DCCA_DebePorc"))
               {
                  Decimal Base = txnCCCT_ValVta.Value;
                  Decimal _porTotal = 0, _totSuma = 0;
                  foreach (Entities.DetCtaCteAsientos iDet in ((ObservableCollection<Entities.DetCtaCteAsientos>)BSItemsAsiento.DataSource))
                  {
                     Decimal PDebe = 0, PHaber = 0, Importe = 0;
                     PDebe = iDet.DCCA_DebePorc;
                     PHaber = iDet.DCCA_HaberPorc;
                     iDet.DCCA_DebeMonto = Math.Round(PDebe * Base / 100, 2, MidpointRounding.AwayFromZero);
                     iDet.DCCA_HaberMonto = Math.Round(PHaber * Base / 100, MidpointRounding.AwayFromZero);

                     _porTotal += iDet.DCCA_DebePorc;
                     _totSuma += iDet.DCCA_DebeMonto;
                  }
                  /* Ajusto Montos */
                  if (_porTotal == 100)
                  {
                     Decimal Maximo = ((ObservableCollection<Entities.DetCtaCteAsientos>)BSItemsAsiento.DataSource).Max(Det => Det.DCCA_DebeMonto);
                     Decimal _dif = Base - _totSuma;

                     Entities.DetCtaCteAsientos _detAsiento = ((ObservableCollection<Entities.DetCtaCteAsientos>)BSItemsAsiento.DataSource).Where(Det => Det.DCCA_DebeMonto == Maximo).FirstOrDefault();
                     _detAsiento.DCCA_DebeMonto += _dif;
                  }
                  BSItemsAsiento.ResetBindings(false);
               }
               else
               {
                  Decimal Base = txnCCCT_ValVta.Value;
                  foreach (Entities.DetCtaCteAsientos iDet in ((ObservableCollection<Entities.DetCtaCteAsientos>)BSItemsAsiento.DataSource))
                  {
                     Decimal PDebe = 0, PHaber = 0, Importe = 0;
                     PDebe = iDet.DCCA_DebePorc;
                     PHaber = iDet.DCCA_HaberPorc;
                     iDet.DCCA_DebeMonto = Math.Round(PDebe * Base / 100, 2, MidpointRounding.AwayFromZero);
                     iDet.DCCA_HaberMonto = Math.Round(PHaber * Base / 100, MidpointRounding.AwayFromZero);
                  }


                  BSItemsAsiento.ResetBindings(false);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error modificar el valor de la celda seleccionada.", ex); }
      }

      private void cmbTIPO_CodTI3_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPO_CodTI3.TiposSelectedValue != null)
            {
               CalcularImp3ra();
               chkCCCT_RetencionIGV.Checked = true;
               chkCCCT_RetencionIGV.Enabled = true;
               txnCCCT_Imp1.Value = 0;
            }
            else
            {
               chkCCCT_RetencionIGV.Checked = false;
               chkCCCT_RetencionIGV.Enabled = false;
               txnCCCT_Imp2.Value = 0;
            }
         }
         catch (Exception)
         { }
      }
      #endregion

      #endregion
   }
}