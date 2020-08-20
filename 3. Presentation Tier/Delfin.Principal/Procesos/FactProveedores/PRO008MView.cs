using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Delfin.Entities;
using Delfin.Principal.Properties;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinForms.Controls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using Delfin.Controls;

namespace Delfin.Principal
{
   public partial class PRO008MView : Form, IPRO008MView
   {

      Decimal PorcentajeIGV;
      AppService.DelfinServiceClient oAppService = new AppService.DelfinServiceClient();

      public PRO008MView()
      {

         InitializeComponent();
         try
         {
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormClosing += PRO008MView_FormClosing;
            this.FormClosed += PRO008MView_FormClosed;

            /* Encabezado Facturacion */
            btnGuardar.Click += btnGuardar_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnHelpDetalle.Click += btnHelpDetalle_Click;
            btnActualizar.Click += btnActualizar_Click;
            txnCCCT_ValVta.Maximum = 10000000;
            txnCCCT_Imp1.Maximum = 100000;
            txnCCCT_Monto.Maximum = 100000000;
            Load += PRO008MView_Load;
            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += BSItems_CurrentItemChanged;
            grdItems.CommandCellClick += grdItems_CommandCellClick;
            grdItems.CellFormatting += grdItems_CellFormatting;
            grdItems.ValueChanged += grdItems_ValueChanged;
            grdItems.DataError += grdItems_DataError;
            txtCTCT_Numero.KeyPress += txtCTCT_Numero_KeyPress;
            txnCCCT_Imp2.LostFocus += txnCCCT_Imp2_LostFocus;

            Proveedor.AyudaValueChanged += Proveedor_AyudaValueChanged;

            pnlDocReferencia.Visible = false;
            pnlRenta3ra.Visible = false;

            txtCCCT_SerieReferencia.MaxLength = 20;
            txtCCCT_SerieReferencia.Tag = "CCCT_SerieReferenciaMSGERROR";
            txtCCCT_NumeroReferencia.MaxLength = 20;
            txtCCCT_NumeroReferencia.Tag = "CCCT_NumeroReferenciaMSGERROR";
            cmbTIPO_CodTDOReferencia.Tag = "TIPO_CodTDOReferenciaMSGERROR";
            chkCCCT_ProvAsumeDetraccion.Tag = "CCCT_ProvAsumeDetraccionMSGERROR";
            dtpCCCT_FechaEmisionReferencia.Tag = "CCCT_FechaEmisionReferenciaMSGERROR";

            txtCTCT_Serie.MaxLength = 20;
            txtCTCT_Numero.MaxLength = 20;

            cmbTIPO_CodTDO.SelectedValueChanged += cmbTIPO_CodTDO_SelectedValueChanged;

            txaCCCT_CodReferencia.TipoFactura = TiposFactura.TIPE_Factura;
            txaCCCT_CodReferencia.AyudaValueChanged += txaCCCT_CodReferencia_AyudaValueChanged;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }

      #region [ IPRO008MView ]

      public void LoadView()
      {
         try
         {
            DTPCCCT_FechaVcto_Enabled = false;

            Cliente.ContainerService = Presenter.ContainerService;
            Proveedor.ContainerService = Presenter.ContainerService;

            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            BSItems.ResetBindings(true);
            FormatDataGrid();
            cmbTIPO_CodTDO.LoadControl(Presenter.ContainerService, "Tabla Moneda", "TDO", "< Seleccione Documento >", ListSortDirection.Descending);
            CbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Tabla Moneda", "MND", "< Seleccione Moneda >", ListSortDirection.Descending);
            CbTIPO_CodFPG.LoadControl(Presenter.ContainerService, "Tabla F. Pago", "FPG", "< Seleccione F. Pago >", ListSortDirection.Descending);
            CbTIPO_CodDetrac.LoadControl(Presenter.ContainerService, "Tabla Detracción", "DET", "< Seleccione Detracción >", ListSortDirection.Descending);
            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo de Entidad", "< Sel. Tipo de Entidad >", ListSortDirection.Ascending);
            txaCCCT_CodReferencia.LoadControl(Presenter.ContainerService, "Ayuda de Documento de Referencia", Delfin.Controls.AyudaFacturaCC.TipoAyuda.Normal, Entorno.ItemEmpresa.EMPR_Codigo);
            cmbTIPO_CodTDOReferencia.LoadControl(Presenter.ContainerService, "Tabla Tipo Documento Referencia", "TDO", "< Seleccione Documento >", ListSortDirection.Descending);
            cmbTIPO_CodTI3.LoadControl(Presenter.ContainerService, "Tabla Impuesto de 3ra", "TI3", "< Seleccione Impuesto >", ListSortDirection.Descending);

            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;
            //cmbTIPE_Codigo.Enabled = false;
            CbTIPO_CodFPG.SelectedIndexChanged += CbTIPO_CodFPG_SelectedIndexChanged;
            cmbTIPO_CodTI3.SelectedIndexChanged += cmbTIPO_CodTI3_SelectedIndexChanged;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      #endregion

      #region [ Propiedades ]
      public PRO008Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      private Hashtable HashFormulario { get; set; }
      Int32 _ENTC_Codigo;
      Int16 _TIPE_Codigo;
      ToolStripMenuItem tsmTodos;
      String[] defaultColumns;

      private bool Closing = false;
      public Boolean DTPCCCT_FechaVcto_Enabled { get; set; }
      #endregion

      #region [ Metodos ]

      public void ClearItem()
      {
         try
         {
            cmbTIPO_CodTDO.SelectedValue = "001";
            CbTIPO_CodMND.SelectedIndex = 3;
            cmbTIPE_Codigo.SelectedIndex = 14;
            CbTIPO_CodFPG.SelectedIndex = 0;
            CbTIPO_CodDetrac.SelectedIndex = 0;
            txtCTCT_Numero.Clear();

            DTPCCCT_FechaVcto.NSFecha = Presenter.Session.Fecha.AddMonths(2);
            NUDCCCT_TipoCambio.Value = 0;
            DTPCCCT_FechaEmision.Value = Presenter.Session.Fecha;
            txnCCCT_Imp1.Value = 0;
            txnCCCT_Monto.Value = 0;
            txnCCCT_ValVta.Value = 0;
            txtCTCT_Serie.Clear();
            btnGuardar.Enabled = true;
            txtCOPE_Numero.Text = "";
            txtCOPE_HBL.Text = "";
            //DTPCCCT_FechaEmision.Value = DateTime.Now;
            txtCOPE_Estado.Text = "";
            Cliente.ClearValue();
            txtServicio.Text = "";
            txtDOPE_Monto.Text = "";
            txtDOPE_ValorVta.Text = "";
            txtOrigen.Text = "";
            txtDestino.Text = "";
            txtCliente.Text = "";
            Presenter._CostoServicio = 0;
            Proveedor.ClearValue();
            grdItems.DataSource = null;
            CbTIPO_CodMND.Enabled = true;
            Presenter.CCCT_Codigo = 0;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }

      public void ShowValidation()
      {
         try
         {
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.ItemCtaCte.MensajeError, Dialogos.Boton.Detalles);
            FormShowErrorProvider<CtaCte>.Validate(Presenter.ItemCtaCte, this, errorProvider1);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }

      public void SetItem()
      {
         try
         {
            CbTIPO_CodDetrac.TiposSelectedValue = Presenter.ItemCtaCte.TIPO_CodDetrac ?? null;
            cmbTIPO_CodTDO.SelectedValue = Presenter.ItemCtaCte.TIPO_CodTDO;
            CbTIPO_CodMND.SelectedValue = Presenter.ItemCtaCte.TIPO_CodMND;
            CbTIPO_CodFPG.SelectedValue = Presenter.ItemCtaCte.TIPO_CodFPG;
            txtCTCT_Serie.Text = Presenter.ItemCtaCte.CCCT_Serie;
            txtCTCT_Numero.Text = Presenter.ItemCtaCte.CCCT_Numero;
            cmbTIPE_Codigo.TipoEntidadSelectedValue = Presenter.ItemCtaCte.TIPE_Codigo;
            chkCCCT_ProvAsumeDetraccion.Checked = (Presenter.ItemCtaCte.CCCT_ProvAsumeDetraccion.HasValue ? Presenter.ItemCtaCte.CCCT_ProvAsumeDetraccion.Value : false);

            if (!String.IsNullOrEmpty(Presenter.ItemCtaCte.TIPO_CodTI3)) { cmbTIPO_CodTI3.SelectedValue = Presenter.ItemCtaCte.TIPO_CodTI3; }
            if (Presenter.ItemCtaCte.CCCT_Imp2.HasValue) { txnCCCT_Imp2.Value = Presenter.ItemCtaCte.CCCT_Imp2.Value; }
            if (Presenter.ItemCtaCte.CCCT_RetencionIGV.HasValue) { chkCCCT_RetencionIGV.Checked = Presenter.ItemCtaCte.CCCT_RetencionIGV.Value; }

            if (Presenter.ItemCtaCte.ENTC_Codigo != null)
            {
               Proveedor.TipoEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(Presenter.ItemCtaCte.TIPE_Codigo.Value);
               Proveedor.SetValue(Presenter.ItemCtaCte.ENTC_Codigo.Value);
               Proveedor_AyudaValueChanged(null, null);
            }
            if (Presenter.ItemCtaCte.CCCT_FechaEmision != null) { DTPCCCT_FechaEmision.Value = Presenter.ItemCtaCte.CCCT_FechaEmision.Value; }
            if (Presenter.ItemCtaCte.CCCT_FechaVcto != null) { DTPCCCT_FechaVcto.NSDateTimePicke.Value = Presenter.ItemCtaCte.CCCT_FechaVcto.Value; }
            if (Presenter.ItemCtaCte.CCCT_TipoCambio != null) { NUDCCCT_TipoCambio.Value = Presenter.ItemCtaCte.CCCT_TipoCambio.Value; }
            if (Presenter.ItemCtaCte.CCCT_ValVta != null) { txnCCCT_ValVta.Value = Presenter.ItemCtaCte.CCCT_ValVta.Value; }
            if (Presenter.ItemCtaCte.CCCT_Imp1 != null) { txnCCCT_Imp1.Value = Presenter.ItemCtaCte.CCCT_Imp1.Value; }
            if (Presenter.ItemCtaCte.CCCT_Monto != null) { txnCCCT_Monto.Value = Presenter.ItemCtaCte.CCCT_Monto.Value; }
            if (Presenter.ItemCtaCte.CCCT_ValVta != null) { Presenter._CostoServicio = Presenter.ItemCtaCte.CCCT_ValVta.Value; }
            if (Presenter.ItemCtaCte.CCCT_FecReg.HasValue) { dtpCCCT_FecReg.Value = Presenter.ItemCtaCte.CCCT_FecReg.Value; }

            /* 01/03/2017 - Cambio para Renta de Tercera */

            if (Presenter.ItemCtaCte.CCCT_Imp2.HasValue) { txnCCCT_Imp2.Value = Presenter.ItemCtaCte.CCCT_Imp2.Value; }
            if (!String.IsNullOrEmpty(Presenter.ItemCtaCte.TIPO_CodTI3)) { cmbTIPO_CodTI3.SelectedValue = Presenter.ItemCtaCte.TIPO_CodTI3; }
            chkCCCT_RetencionIGV.Checked = false; if (Presenter.ItemCtaCte.CCCT_RetencionIGV.HasValue) { chkCCCT_RetencionIGV.Checked = Presenter.ItemCtaCte.CCCT_RetencionIGV.Value; }


            /* Fin 01/03/2017 */

            Presenter.COPE_Codigo = Presenter.ItemCtaCte.COPE_Codigo;
            DataTable _dt = new DataTable();
            _dt = Presenter.LoadServicio(CbTIPO_CodMND.TiposSelectedValue, NUDCCCT_TipoCambio.Value);

            DataColumn _dc = _dt.Columns.Add("CostoOriginal", typeof(Decimal));
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
               _dt.Rows[i]["CostoOriginal"] = Convert.ToDecimal(_dt.Rows[i]["PreCostoSada"].ToString());
            }
            BSItems.DataSource = _dt;
            grdItems.DataSource = BSItems;
            BSItems.ResetBindings(true);
            if (grdItems.RowCount > 0)
            {
               grdItems.Enabled = true;
               grdItems.BestFitColumns();
               //GridAutoFit.Fit(grdItems);
            }
            else
            {
               grdItems.Enabled = false;
            }

            if (Presenter.ItemOperacion != null && Presenter.ItemOperacion.COPE_Codigo > 0)
            {
               txtCOPE_Numero.Text = Presenter.ItemOperacion.COPE_NumDoc;
               txtCOPE_HBL.Text = Presenter.ItemOperacion.COPE_HBL;
               if (Presenter.ItemOperacion.COPE_FecEmi != null)
               {
                  if (Presenter.ItemCtaCte.Instance == InstanceEntity.Added)
                  { DTPCCCT_FechaEmision.Value = Presenter.ItemOperacion.COPE_FecEmi.Value; }
               }
               txtCOPE_Estado.Text = Presenter.ItemOperacion.CONS_CodEstadoSTR;
               if (Presenter.ItemOperacion.ENTC_CodCliente != null)
               {
                  Cliente.SetValue(Presenter.ItemOperacion.ENTC_CodCliente.Value);
               }

               //txtServicio.Text = Presenter._DT.Rows[0]["Servicio"].ToString();
               //txtDOPE_Monto.Text = Presenter._DT.Rows[0]["Costo"].ToString();
               //txtDOPE_ValorVta.Text = Presenter._DT.Rows[0]["Monto"].ToString();
               //txtOrigen.Text = Presenter._DT.Rows[0]["Origen"].ToString();
               //txtDestino.Text = Presenter._DT.Rows[0]["Destino"].ToString();
               //txtCliente.Text = Presenter._DT.Rows[0]["Proveedor"].ToString();
            }
            btnGuardar.Enabled = Presenter.ItemCtaCte.PreFacturado == 1 ? false : true;

         }
         catch (Exception)
         { throw; }
      }

      public void SetInstance(InstanceView xInstance)
      {
         try
         {
            errorProvider1.Dispose();

            switch (xInstance)
            {
               case InstanceView.Default:
                  break;
               case InstanceView.New:
                  //grdItems.Columns["Edit"].IsVisible = true;
                  grdItems.ReadOnly = false;
                  HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                  dtpCCCT_FecReg.Enabled = true;
                  break;
               case InstanceView.Edit:
                  HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                  //btnGuardar.Enabled = false;
                  btnBuscar.Enabled = false;
                  //grdItems.Columns["Edit"].IsVisible = false;
                  //grdItems.ReadOnly = true;
                  dtpCCCT_FecReg.Enabled = false;
                  break;
               case InstanceView.Delete:
                  break;
               case InstanceView.Save:
                  break;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetInstanceView, ex); }
      }

      public void GetItem()
      {
         try
         {
            Presenter.ItemCtaCte.CCCT_FechaEmision = DTPCCCT_FechaEmision.Value;

            Presenter.ItemCtaCte.CCCT_Serie = txtCTCT_Serie.Text;
            Presenter.ItemCtaCte.CCCT_Numero = txtCTCT_Numero.Text;
            Presenter.ItemCtaCte.CCCT_TipoCambio = NUDCCCT_TipoCambio.Value;
            Presenter.ItemCtaCte.CCCT_FechaVcto = DTPCCCT_FechaVcto.NSDateTimePicke.Value;
            //Presenter.ItemCtaCte.CCCT_Fecha = DTPCCCT_FechaEmision.Value;
            Presenter.ItemCtaCte.CCCT_ValVta = System.Math.Round(txnCCCT_ValVta.Value, 2, MidpointRounding.AwayFromZero);
            Presenter.ItemCtaCte.CCCT_Imp1 = System.Math.Round(txnCCCT_Imp1.Value, 2, MidpointRounding.AwayFromZero);
            Presenter.ItemCtaCte.CCCT_Discrepancia = System.Math.Round(txnCCCT_Discrepancia.Value, 2, MidpointRounding.AwayFromZero);

            if (Presenter.ItemCtaCte.CCCT_Imp1 != 0) { Presenter.ItemCtaCte.CCCT_PorcImp1 = PorcentajeIGV; }

            Presenter.ItemCtaCte.CCCT_Monto = System.Math.Round(Convert.ToDecimal(txnCCCT_Monto.Text), 2, MidpointRounding.AwayFromZero);
            Presenter.ItemCtaCte.CCCT_Costo = System.Math.Round(txnCCCT_ValVta.Value, 2, MidpointRounding.AwayFromZero);
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
            {
               Presenter.ItemCtaCte.TIPE_Codigo = cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo;
               Presenter.ItemCtaCte.TIPE_CodigoServicio = cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo;
            }
            else { Presenter.ItemCtaCte.TIPE_Codigo = null; }
            if (Proveedor.Value != null) { Presenter.ItemCtaCte.ENTC_Codigo = Proveedor.Value.ENTC_Codigo; }
            if (cmbTIPO_CodTDO.SelectedValue != null) { Presenter.ItemCtaCte.TIPO_CodTDO = cmbTIPO_CodTDO.SelectedValue.ToString(); }
            if (CbTIPO_CodFPG.SelectedValue != null) { Presenter.ItemCtaCte.TIPO_CodFPG = CbTIPO_CodFPG.SelectedValue.ToString(); }
            if (CbTIPO_CodMND.SelectedValue != null) { Presenter.ItemCtaCte.TIPO_CodMND = CbTIPO_CodMND.SelectedValue.ToString(); }

            if (CbTIPO_CodDetrac.TiposSelectedValue != null)
            {
               Presenter.ItemCtaCte.TIPO_CodDetrac = CbTIPO_CodDetrac.TiposSelectedValue;
               Presenter.ItemCtaCte.TIPO_TabDetrac = "DET";

               Decimal _monto = 0, _porcentaje = (CbTIPO_CodDetrac.TiposSelectedItem.TIPO_Num1.HasValue ? CbTIPO_CodDetrac.TiposSelectedItem.TIPO_Num1.Value : 0); ;
               if (CbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo.Equals(Util.getMoneda(TMoneda.Soles)))
               { _monto = Math.Round(_porcentaje * Presenter.ItemCtaCte.CCCT_Monto.Value / 100, 0, MidpointRounding.AwayFromZero); }
               else if (CbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo.Equals(Util.getMoneda(TMoneda.Dolares)))
               { _monto = Math.Round((_porcentaje * Presenter.ItemCtaCte.CCCT_Monto.Value * Presenter.ItemCtaCte.CCCT_TipoCambio.Value / 100), 0, MidpointRounding.AwayFromZero); }

               Presenter.ItemCtaCte.CCCT_MontoDetraccion = _monto;
               Presenter.ItemCtaCte.CCCT_PorDetraccion = _porcentaje;
            }
            else
            {
               Presenter.ItemCtaCte.TIPO_CodDetrac = null;
               Presenter.ItemCtaCte.TIPO_TabDetrac = null;
            }

            Presenter.ItemCtaCte.CCCT_FecReg = null; if (dtpCCCT_FecReg.Value.Year > 1900) { Presenter.ItemCtaCte.CCCT_FecReg = dtpCCCT_FecReg.Value; }
            Presenter.ItemCtaCte.SUCR_Codigo = Entorno.ItemSucursal.SUCR_Codigo;


            if (pncDocReferencia.Visible)
            {
               /* Documento de Referencia Cuando es Nota de Crédito */
               Presenter.ItemCtaCte.CCCT_CodReferencia = null; if (txaCCCT_CodReferencia.SelectedItem != null) { Presenter.ItemCtaCte.CCCT_CodReferencia = txaCCCT_CodReferencia.SelectedItem.CCCT_Codigo; }
               Presenter.ItemCtaCte.TIPO_CodTDOReferencia = null; if (cmbTIPO_CodTDOReferencia.TiposSelectedValue != null) { Presenter.ItemCtaCte.TIPO_CodTDOReferencia = cmbTIPO_CodTDOReferencia.TiposSelectedItem.TIPO_CodTipo; }
               Presenter.ItemCtaCte.CCCT_SerieReferencia = null; if (!string.IsNullOrEmpty(txtCCCT_SerieReferencia.Text)) { Presenter.ItemCtaCte.CCCT_SerieReferencia = txtCCCT_SerieReferencia.Text; }
               Presenter.ItemCtaCte.CCCT_NumeroReferencia = null; if (!String.IsNullOrEmpty(txtCCCT_NumeroReferencia.Text)) { Presenter.ItemCtaCte.CCCT_NumeroReferencia = txtCCCT_NumeroReferencia.Text; }
               Presenter.ItemCtaCte.CCCT_FechaEmisionReferencia = null; if (dtpCCCT_FechaEmisionReferencia.NSFecha.HasValue) { Presenter.ItemCtaCte.CCCT_FechaEmisionReferencia = dtpCCCT_FechaEmisionReferencia.NSFecha; }
            }

            Presenter.ItemCtaCte.DetCtaCteAsientos = new DetCtaCteAsientos();
            Presenter.ItemCtaCte.DetCtaCteAsientos.EMPR_Codigo = Presenter.ItemCtaCte.EMPR_Codigo;
            Presenter.ItemCtaCte.DetCtaCteAsientos.CCCT_Codigo = Presenter.ItemCtaCte.CCCT_Codigo;
            Presenter.ItemCtaCte.DetCtaCteAsientos.DCCA_Cuenta = Presenter.ItemCtaCte.CCCT_CuentaBI;
            Presenter.ItemCtaCte.DetCtaCteAsientos.DCCA_DebePorc = 100;

            if (Presenter.ItemCtaCte.TIPO_CodTDO.Equals("007"))
            {
               Presenter.ItemCtaCte.DetCtaCteAsientos.DCCA_DebeMonto = 0;
               Presenter.ItemCtaCte.DetCtaCteAsientos.DCCA_HaberMonto = Presenter.ItemCtaCte.CCCT_ValVta.Value;
            }
            else
            {
               Presenter.ItemCtaCte.DetCtaCteAsientos.DCCA_DebeMonto = Presenter.ItemCtaCte.CCCT_ValVta.Value;
               Presenter.ItemCtaCte.DetCtaCteAsientos.DCCA_HaberMonto = 0;
            }
            
            Presenter.ItemCtaCte.DetCtaCteAsientos.DCCA_Item = 1;
            Presenter.ItemCtaCte.DetCtaCteAsientos.DCCA_Glosa = Presenter.ItemCtaCte.SERV_Nombre_SPA.Trim();
            Presenter.ItemCtaCte.CCCT_ProvAsumeDetraccion = chkCCCT_ProvAsumeDetraccion.Checked;

            Presenter.ItemCtaCte.DetCtaCteAsientos.TIPO_CodOPE = Presenter.ItemCtaCte.TIPO_CodOPE_Costo;
            Presenter.ItemCtaCte.DetCtaCteAsientos.TIPO_TabOPE = Presenter.ItemCtaCte.TIPO_TabOPE_Costo;

            Presenter.ItemCtaCte.DetCtaCteAsientos.CENT_Ano = Presenter.ItemCtaCte.CENT_Ano;
            Presenter.ItemCtaCte.DetCtaCteAsientos.CENT_Codigo = Presenter.ItemCtaCte.CENT_Codigo;

            Presenter.ItemCtaCte.DetCtaCteAsientos.AUDI_UsrCrea = Presenter.Session.UserName;

            /* 01/03/2017 - Cambio para Renta de Tercera */

            Presenter.ItemCtaCte.TIPO_CodTI3 = null;
            Presenter.ItemCtaCte.TIPO_TabTI3 = null;
            if (cmbTIPO_CodTI3.TiposSelectedValue != null)
            {
               Presenter.ItemCtaCte.TIPO_TabTI3 = cmbTIPO_CodTI3.TiposSelectedItem.TIPO_CodTabla;
               Presenter.ItemCtaCte.TIPO_CodTI3 = cmbTIPO_CodTI3.TiposSelectedItem.TIPO_CodTipo;
               Presenter.ItemCtaCte.CCCT_PorcImp2 = cmbTIPO_CodTI3.TiposSelectedItem.TIPO_Num1.HasValue ? cmbTIPO_CodTI3.TiposSelectedItem.TIPO_Num1.Value : 0;
            }
            Presenter.ItemCtaCte.CCCT_Imp2 = 0; if (txnCCCT_Imp2.Value != 0) { Presenter.ItemCtaCte.CCCT_Imp2 = txnCCCT_Imp2.Value; }
            Presenter.ItemCtaCte.CCCT_RetencionIGV = chkCCCT_RetencionIGV.Checked;

            /* Fin 01/03/2017 */

            Presenter.ItemCtaCte.DetCtaCteAsientos.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.GetItem, ex); }
      }

      public Boolean ConvertColeccion()
      {
         Boolean _Return = false;
         Det_Operacion _Item_Det = new Det_Operacion();
         Presenter.ItemsDet_Operacion = new ObservableCollection<Det_Operacion>();
         for (int i = 0; i < grdItems.Rows.Count; i++)
         {
            if (Convert.ToBoolean(grdItems.Rows[i].Cells["Agregar"].Value) == true)
            {
               _Item_Det.COPE_Codigo = Presenter.COPE_Codigo;
               _Item_Det.CTAR_Tipo = grdItems.Rows[i].Cells["CTAR_Tipo"].Value.ToString();
               if (grdItems.Rows[i].Cells["TIPE_Codigo"].Value.ToString() != "")
                  _Item_Det.TIPE_Codigo = Convert.ToInt16(grdItems.Rows[i].Cells["TIPE_Codigo"].Value.ToString());
               if (grdItems.Rows[i].Cells["ENTC_Codigo"].Value.ToString() != "")
                  _Item_Det.ENTC_Codigo = Convert.ToInt32(grdItems.Rows[i].Cells["ENTC_Codigo"].Value.ToString());
               _Item_Det.DOPE_Costo = Convert.ToDecimal(grdItems.Rows[i].Cells["PreCostoSada"].Value.ToString());
               _Item_Det.DTAR_Item = Convert.ToInt16(Convert.ToBoolean(grdItems.Rows[i].Cells["UltCostoServicio"].Value.ToString()) == true ? 1 : 0);
               Presenter.ItemsDet_Operacion.Add(_Item_Det);
               _Return = true;
            }
         }
         return _Return;

      }

      private void Guardar()
      {
         try
         {
            String DOPE_Items = "";
            foreach (DataRow item in (BSItems.DataSource as DataTable).Rows)
            {
               if (Convert.ToBoolean(item["Agregar"]))
               { DOPE_Items += String.Format("|{0}|", item["DOPE_Item"].ToString()); }
            }

            //DataTable dtDocumento = new DataTable();
            //string sQuery;
            //sQuery = "EXEC dgp.paConsultaDocumentoPorFiltros " + cmbTIPE_Codigo.SelectedValue.ToString() + "," + Proveedor.Value.ENTC_Codigo.ToString() + ",'" + txtCTCT_Serie.Text + "','" + txtCTCT_Numero.Text + "','I'";
            //dtDocumento = oAppService.ExecuteSQL(sQuery).Tables[0];
            //if (dtDocumento.Rows.Count > 0)
            //{
            //    Dialogos.MostrarMensajeError(Presenter.Title, "El documento ingresado ya existe y se encuentra asociado al código interno:" + dtDocumento.Rows[0][0].ToString(),true);
            //    return;
            //}


            if (Presenter._CostoServicio != Convert.ToDecimal(txnCCCT_ValVta.Value) && Presenter._CostoServicio > 0)
            {
               if (Dialogos.MostrarMensajePregunta(Presenter.Title, "El valor de venta del documento no coincide con el valor de costo del servicio. Desea continuar?", Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
               {
                  if (!Presenter.Guardar(DOPE_Items)) return;
                  errorProvider1.Dispose();
                  Close();
               }
            }
            else
            {
               if (!Presenter.Guardar(DOPE_Items)) return;
               errorProvider1.Dispose();
               Close();

            }
         }
         catch (Exception)
         { throw; }
      }

      private Boolean BuscarDoc_Detraccion(String x_TipoDoc, String Serie, String x_NroDoc, Int32 x_CodProve)
      {


         return false;
      }

      private void LimpiarAyuda()
      {
         Presenter.COPE_Codigo = 0;
         txtCOPE_Numero.Clear();
         txtCOPE_Estado.Clear();
         txtCOPE_HBL.Clear();
      }

      private void LimpiarAyudaDetalle()
      {
         Presenter.ENTC_Codigo = 0;
         Presenter.CTAR_Tipo = "";
         Proveedor.Text = "";
         txtDestino.Clear();
         txtOrigen.Clear();
         txtDOPE_Monto.Clear();
      }

      private void CargaDataOperativo(DataTable dt)
      {
         Presenter.COPE_Codigo = Convert.ToInt32(dt.Rows[0]["COPE_Codigo"].ToString());
         //CbTIPO_CodMND.SelectedValue = dt.Rows[0]["TIPO_CodMND"].ToString();
         CbTIPO_CodMND.Enabled = false;
         txtCOPE_Numero.Text = dt.Rows[0]["COPE_NumDoc"].ToString();
         Cliente.SetValue(Convert.ToInt32(dt.Rows[0]["ENTC_Codigo"].ToString()));
         txtCOPE_HBL.Text = dt.Rows[0]["COPE_HBL"].ToString();
         txtCOPE_Estado.Text = dt.Rows[0]["CONS_CodEstadoSTR"].ToString();
         dtpCOPE_FechaEmision.Value = Convert.ToDateTime(dt.Rows[0]["COPE_FecEmi"].ToString());
         btnHelpDetalle.Enabled = true;
         DataTable _dt = new DataTable();
         _dt = Presenter.LoadServicio(CbTIPO_CodMND.TiposSelectedValue, NUDCCCT_TipoCambio.Value);
         if (_dt != null)
         {
            DataColumn _dc = _dt.Columns.Add("CostoOriginal", typeof(Decimal));
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
               if (_dt.Rows[i]["PreCostoSada"].ToString() != "")
                  _dt.Rows[i]["CostoOriginal"] = Convert.ToDecimal(_dt.Rows[i]["PreCostoSada"].ToString());
            }
         }

         BSItems.DataSource = _dt;
         grdItems.DataSource = BSItems;
         BSItems.ResetBindings(true);
         if (grdItems.RowCount > 0)
         {
            grdItems.Enabled = true;
            //GridAutoFit.Fit(grdItems);
            grdItems.BestFitColumns();
         }
         else
         {
            grdItems.Enabled = false;
         }

      }

      private void CargaDataServicio(DataTable dt)
      {
         txtServicio.Text = dt.Rows[0]["Servicio"].ToString();
         Presenter.ENTC_Codigo = dt.Rows[0]["ENTC_Codigo"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["ENTC_Codigo"].ToString()) : 0;
         Presenter.TIPE_CodigoServicio = (short)(dt.Rows[0]["TIPE_Codigo"] != DBNull.Value ? Convert.ToInt16(dt.Rows[0]["TIPE_Codigo"].ToString()) : 0);
         Presenter.CTAR_Tipo = dt.Rows[0]["CTAR_Tipo"].ToString();
         txtOrigen.Text = dt.Rows[0]["Origen"].ToString();
         txtDestino.Text = dt.Rows[0]["Destino"].ToString();
         txtDOPE_ValorVta.Text = dt.Rows[0]["PreVentaSada"].ToString();
         txtDOPE_Monto.Text = dt.Rows[0]["PreCostoSada"].ToString();
         txtCliente.Text = dt.Rows[0]["Proveedor"].ToString();
         CbTIPO_CodMND.SelectedValue = dt.Rows[0]["TIPO_CodMND"].ToString();
         Presenter._CostoServicio = Convert.ToDecimal(txtDOPE_Monto.Text);
         if (Proveedor.Value == null)
         {
            Proveedor.SetValue(Presenter.ENTC_Codigo);
            if (Proveedor.Value.ENTC_DiasCredito.HasValue)
            { DTPCCCT_FechaVcto.NSFecha = Presenter.Session.Fecha.AddDays((Double)Proveedor.Value.ENTC_DiasCredito); }
            else { DTPCCCT_FechaVcto_Enabled = true; }
         }
         txnCCCT_ValVta.Value = dt.Rows[0]["PreCostoSada"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["PreCostoSada"].ToString()) : 0;
      }

      private void LoadImportacion()
      {
         DataTable dt = new DataTable();
         dt = Presenter.LoadAyudaOperacion(txtCOPE_Numero.Text);
         if (dt != null)
         {
            if (dt.Rows.Count == 0)
            {
               Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se encontraron coincidencias.");
            }
            else if (dt.Rows.Count == 1)
            {
               Int32 COPE_Codigo;
               if (Int32.TryParse(dt.Rows[0]["COPE_Codigo"].ToString(), out COPE_Codigo))
               {
                  CargaDataOperativo(dt);
               }
               else { LimpiarAyuda(); }
            }
            else
            {
               List<Infrastructure.WinForms.Controls.ColumnaAyuda> _columnas = new List<Infrastructure.WinForms.Controls.ColumnaAyuda>();
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 0,
                  ColumnName = "COPE_NumDoc",
                  ColumnCaption = "Nro. Operación",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 120,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 1,
                  ColumnName = "Cliente",
                  ColumnCaption = "Cliente",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 200,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 2,
                  ColumnName = "COPE_FecEmi",
                  ColumnCaption = "Fecha Emisión",
                  Alineacion = DataGridViewContentAlignment.MiddleRight,
                  Width = 110,
                  DataType = typeof(DateTime),
                  Format = "dd/MM/yyyy"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 3,
                  ColumnName = "COPE_HBL",
                  ColumnCaption = "HBL",
                  Alineacion = DataGridViewContentAlignment.MiddleRight,
                  Width = 100,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 4,
                  ColumnName = "COPE_MBL",
                  ColumnCaption = "MBL",
                  Alineacion = DataGridViewContentAlignment.MiddleRight,
                  Width = 100,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 5,
                  ColumnName = "COPE_FechaArribo",
                  ColumnCaption = "Fecha Arribo",
                  Alineacion = DataGridViewContentAlignment.MiddleRight,
                  Width = 110,
                  DataType = typeof(DateTime),
                  Format = "dd/MM/yyyy"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 6,
                  ColumnName = "COPE_CantidadDias",
                  ColumnCaption = "Días",
                  Alineacion = DataGridViewContentAlignment.MiddleRight,
                  Width = 50,
                  DataType = typeof(Int16),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 7,
                  ColumnName = "COPE_Codigo",
                  ColumnCaption = "Código",
                  Alineacion = DataGridViewContentAlignment.MiddleRight,
                  Width = 0,
                  DataType = typeof(Int32),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 8,
                  ColumnName = "ENTC_CodCliente",
                  ColumnCaption = "Cliente",
                  Alineacion = DataGridViewContentAlignment.MiddleRight,
                  Width = 0,
                  DataType = typeof(Int32),
                  Format = null
               });
               Ayuda x_Ayuda = new Ayuda("Ayuda Operación", dt, false, _columnas);
               if (x_Ayuda.ShowDialog() == DialogResult.OK)
               {
                  Int32 COPE_Codigo;
                  if (Int32.TryParse(x_Ayuda.Respuesta.Rows[0]["COPE_Codigo"].ToString(), out COPE_Codigo))
                  {
                     CargaDataOperativo(x_Ayuda.Respuesta);
                  }
                  else { LimpiarAyuda(); }
               }
               else { LimpiarAyuda(); }
            }
         }
         else
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se encontraron coincidencias.");
      }

      private void LoadServicio()
      {
         DataTable dt = new DataTable();
         dt = Presenter.LoadServicio(CbTIPO_CodMND.TiposSelectedValue, NUDCCCT_TipoCambio.Value);
         if (dt != null)
         {
            if (dt.Rows.Count == 0)
            {
               Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se encontraron coincidencias.");
            }
            else if (dt.Rows.Count == 1)
            {
               CargaDataServicio(dt);
            }
            else
            {
               List<Infrastructure.WinForms.Controls.ColumnaAyuda> _columnas = new List<Infrastructure.WinForms.Controls.ColumnaAyuda>();
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 0,
                  ColumnName = "Servicio",
                  ColumnCaption = "Servicio",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 120,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 1,
                  ColumnName = "Proveedor",
                  ColumnCaption = "Proveedor",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 110,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 2,
                  ColumnName = "TIPE_Descripcion",
                  ColumnCaption = "Tipo",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 110,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 3,
                  ColumnName = "Moneda",
                  ColumnCaption = "Moneda",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 110,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 4,
                  ColumnName = "PreCostoSada",
                  ColumnCaption = "Costo",
                  Alineacion = DataGridViewContentAlignment.MiddleRight,
                  Width = 100,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 5,
                  ColumnName = "PreVentaSada",
                  ColumnCaption = "Precio Venta",
                  Alineacion = DataGridViewContentAlignment.MiddleRight,
                  Width = 100,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 6,
                  ColumnName = "Origen",
                  ColumnCaption = "Orígen",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 110,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 7,
                  ColumnName = "Destino",
                  ColumnCaption = "Destino",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 50,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 8,
                  ColumnName = "ENTC_Codigo",
                  ColumnCaption = "Código",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 0,
                  DataType = typeof(Int32),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 9,
                  ColumnName = "CTAR_Tipo",
                  ColumnCaption = "Tipo",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 0,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 10,
                  ColumnName = "TIPE_Codigo",
                  ColumnCaption = "Tipo Entidad",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 0,
                  DataType = typeof(Int16),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 11,
                  ColumnName = "TIPO_CodMND",
                  ColumnCaption = "CodMoneda",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 0,
                  DataType = typeof(Int16),
                  Format = null
               });
               Ayuda x_Ayuda = new Ayuda("Ayuda Detalle Operación", dt, false, _columnas);
               if (x_Ayuda.ShowDialog() == DialogResult.OK)
               {
                  CargaDataServicio(x_Ayuda.Respuesta);
               }
               else { LimpiarAyudaDetalle(); }
            }
         }
         else
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se encontraron coincidencias.");
      }

      private void FormatDataGrid()
      {
         try
         {
            RadGridLocalizationProvider.CurrentProvider = new MySpanishRadGridLocalizationProvider();
            grdItems.Columns.Clear();
            grdItems.AutoGenerateColumns = false;
            grdItems.AllowAddNewRow = false;
            grdItems.AllowCellContextMenu = false;
            grdItems.AllowColumnHeaderContextMenu = false;
            grdItems.ShowFilteringRow = false;
            grdItems.EnableCustomGrouping = false;
            //GridViewCommandColumn commandColumn;
            //commandColumn = new GridViewCommandColumn();
            //commandColumn.Name = "Edit";
            //commandColumn.HeaderText = @"Seleccionar";
            //commandColumn.DefaultText = @"Editar";
            //commandColumn.UseDefaultText = true;
            //grdItems.Columns.Add(commandColumn);
            //grdItems.Columns["Edit"].AllowSort = false;
            //grdItems.Columns["Edit"].AllowFiltering = false;

            GridViewCheckBoxColumn chkAgregado = new GridViewCheckBoxColumn();
            chkAgregado.Name = "Agregar";
            chkAgregado.HeaderText = @"Facturar";
            chkAgregado.FieldName = "Agregar";
            //            grdItems.Columns.Add(chkFacturar);
            grdItems.Columns.Add(chkAgregado);
            grdItems.Columns["Agregar"].Width = 50;
            grdItems.Columns["Agregar"].ReadOnly = false;

            grdItems.Columns.Add("Servicio", "Servicio", "Servicio");
            grdItems.Columns["Servicio"].Width = 120;
            grdItems.Columns["Servicio"].ReadOnly = true;
            grdItems.Columns.Add("Proveedor", "Proveedor", "Proveedor");
            grdItems.Columns["Proveedor"].Width = 160;
            grdItems.Columns["Proveedor"].ReadOnly = true;
            grdItems.Columns.Add("TIPE_Descripcion", "Tipo", "TIPE_Descripcion");
            grdItems.Columns["TIPE_Descripcion"].Width = 140;
            grdItems.Columns["TIPE_Descripcion"].ReadOnly = true;
            grdItems.Columns.Add("Moneda", "Moneda", "Moneda");
            grdItems.Columns["Moneda"].Width = 50;
            grdItems.Columns["Moneda"].ReadOnly = true;
            grdItems.Columns.Add("PreCostoSada", "Saldo Costo", "PreCostoSada");
            grdItems.Columns["PreCostoSada"].Width = 75;
            grdItems.Columns["PreCostoSada"].ReadOnly = true;
            grdItems.Columns["PreCostoSada"].TextAlignment = ContentAlignment.MiddleRight;
            grdItems.Columns["PreCostoSada"].FormatString = "{0:###,##0.00}";
            grdItems.Columns.Add("PreVentaSada", "Valor Venta", "PreVentaSada");
            grdItems.Columns["PreVentaSada"].Width = 75;
            grdItems.Columns["PreVentaSada"].ReadOnly = true;
            grdItems.Columns["PreVentaSada"].TextAlignment = ContentAlignment.MiddleRight;
            grdItems.Columns["PreVentaSada"].FormatString = "{0:###,##0.00}";
            grdItems.Columns.Add("ENTC_Codigo", "Codigo", "ENTC_Codigo");
            grdItems.Columns["ENTC_Codigo"].IsVisible = false;
            grdItems.Columns.Add("CTAR_Tipo", "CTAR_Tipo", "CTAR_Tipo");
            grdItems.Columns["CTAR_Tipo"].IsVisible = false;
            grdItems.Columns.Add("TIPE_Codigo", "Tipo Entidad", "TIPE_Codigo");
            grdItems.Columns["TIPE_Codigo"].IsVisible = false;
            grdItems.Columns.Add("TIPO_CodMND", "TipoMoneda", "TIPO_CodMND");
            grdItems.Columns["TIPO_CodMND"].IsVisible = false;
            grdItems.Columns.Add("UltCostoServicio", "UltCostoServicio", "UltCostoServicio");
            grdItems.Columns["UltCostoServicio"].IsVisible = false;
            grdItems.Columns.Add("CostoOriginal", "Costo", "CostoOriginal");
            grdItems.Columns["CostoOriginal"].Width = 80;
            grdItems.Columns["CostoOriginal"].IsVisible = false;

            grdItems.Columns.Add("COPE_Codigo", "COPE_Codigo", "COPE_Codigo");
            grdItems.Columns["COPE_Codigo"].AllowHide = true;
            grdItems.Columns["COPE_Codigo"].IsVisible = false;

            grdItems.Columns.Add("DOPE_Item", "Costo", "DOPE_Item");
            grdItems.Columns["DOPE_Item"].AllowHide = true;
            grdItems.Columns["DOPE_Item"].IsVisible = false;
            //grdItems.BestFitColumns();
            grdItems.Columns.Add("SERV_Codigo", "Código Servicio", "SERV_Codigo");
            grdItems.Columns.Add("SERV_Nombre_SPA", "Nombre Servicio", "SERV_Nombre_SPA");
            grdItems.Columns.Add("SERV_CuenCosto", "Cuenta Servicio", "SERV_CuenCosto");

            grdItems.Columns.Add("TIPO_TabOPE_Costo", "Tipo Operación", "TIPO_TabOPE_Costo");
            grdItems.Columns.Add("TIPO_CodOPE_Costo", "Tipo Operación", "TIPO_CodOPE_Costo");

            grdItems.Columns.Add("CENT_Ano", "Año Cto Costo", "CENT_Ano");
            grdItems.Columns.Add("CENT_Codigo", "Cod. Centro Costo", "CENT_Codigo");

            //grdItems.Columns["SERV_CuenCosto"].IsVisible = false;
            grdItems.Columns["TIPO_TabOPE_Costo"].IsVisible = false;
            grdItems.Columns["TIPO_CodOPE_Costo"].IsVisible = false;
            grdItems.Columns["CENT_Ano"].IsVisible = false;
            //grdItems.Columns["CENT_Codigo"].IsVisible = false;

            grdItems.ShowFilteringRow = false;
            grdItems.EnableFiltering = false;
            grdItems.MasterTemplate.EnableFiltering = false;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = false;
            grdItems.MasterTemplate.EnableCustomSorting = false;
            grdItems.AutoGenerateColumns = false;

            tsmColumnas.DropDownItems.Clear();
            defaultColumns = new string[grdItems.Columns.Count];
            int index = 0;
            foreach (GridViewDataColumn column in grdItems.Columns)
            {
               ToolStripMenuItem _item = new ToolStripMenuItem(column.HeaderText);
               _item.Tag = column.Name;
               _item.Checked = column.IsVisible;
               _item.CheckOnClick = true;
               _item.Click += tsmColumna_Click;
               tsmColumnas.DropDownItems.Add(_item);

               if (column.IsVisible)
               { defaultColumns[index] = column.Name; index += 1; }
            }

            ToolStripSeparator tsmSeparacion = new ToolStripSeparator();
            tsmColumnas.DropDownItems.Add(tsmSeparacion);
            tsmTodos = new ToolStripMenuItem("Todos");
            tsmTodos.Tag = "Todas";
            tsmTodos.Checked = false;
            tsmTodos.CheckOnClick = true;
            tsmTodos.Click += tsmTodos_Click;
            tsmColumnas.DropDownItems.Add(tsmTodos);
            //GridAutoFit.Fit(grdItems);

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }

      private void SeleccionarItem()
      {
         try
         {
            if (Presenter != null)
            {
               if (BSItems != null && BSItems.Current != null && BSItems.Current is System.Data.DataRowView)
               {
                  Int32 i = BSItems.Position;
                  if (!Int32.TryParse(((System.Data.DataRowView)(BSItems.Current)).Row["ENTC_Codigo"].ToString(), out _ENTC_Codigo) && !Int16.TryParse(((System.Data.DataRowView)(BSItems.Current)).Row["TIPE_Codigo"].ToString(), out _TIPE_Codigo))
                  {

                     Presenter.ItemCtaCte = null;
                  }
               }
               else
               { Presenter.ItemCtaCte = null; }
            }
         }
         catch (Exception ex)
         {
            if (Presenter != null)
               Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex);
         }
      }

      private void CalcularTotal()
      {
         Decimal _Total = 0;
         for (int i = 0; i < grdItems.Rows.Count; i++)
         {
            if (Convert.ToBoolean(grdItems.Rows[i].Cells["Agregar"].Value) == true)
            {
               if (grdItems.Rows[i].Cells["PreCostoSada"].Value != "")
                  _Total += Convert.ToDecimal(grdItems.Rows[i].Cells["PreCostoSada"].Value);
            }
         }
         txnCCCT_ValVta.Value = _Total;
      }

      private void LimpiarDatosServicio()
      {
         txtServicio.Text = "";
         txtDOPE_ValorVta.Text = "0.00";
         txtDOPE_Monto.Text = "0.00";
         txtCliente.Text = "";
         ChkUltimoCosto.Checked = false;
      }

      private void ValidarAgrupación()
      {
         String _Tipo = grdItems.Rows[BSItems.Position].Cells["TIPE_Descripcion"].Value.ToString() + "|" + grdItems.Rows[BSItems.Position].Cells["DOPE_Item"].Value.ToString();
         if (_Tipo != "S")
         {
            for (int i = 0; i < grdItems.Rows.Count; i++)
            {
               if (i != BSItems.Position)
               {
                  if (_Tipo != grdItems.Rows[i].Cells["TIPE_Descripcion"].Value.ToString() + "|" + grdItems.Rows[i].Cells["DOPE_Item"].Value.ToString())
                  {
                     grdItems.Rows[i].Cells["Agregar"].Value = 0;
                  }
               }
            }
         }
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
               CalcularMontoTotal();
            }
         }
         catch (Exception)
         { throw; }
      }

      private void CalcularMontoTotal()
      {
         try
         {
            Decimal _total = txnCCCT_ValVta.Value + txnCCCT_Imp1.Value + txnCCCT_Imp2.Value;
            txnCCCT_Monto.Value = _total;
         }
         catch (Exception)
         { throw; }
      }

      private void SetValueChanged()
      {
         try
         {
            grdItems.EndEdit();
            grdItems.EndUpdate();
            BSItems.EndEdit();
            ValidarAgrupación();
            CalcularTotal();
            for (int i = 0; i < grdItems.Rows.Count; i++)
            {
               if (Convert.ToBoolean(grdItems.Rows[i].Cells["Agregar"].Value) == true)
               {
                  if (Presenter.ItemCtaCte.Instance == InstanceEntity.Added)
                  {
                     var dt = Presenter.Client.GetServicioFacturado(Convert.ToInt32(grdItems.Rows[i].Cells["COPE_Codigo"].Value), Convert.ToInt32(grdItems.Rows[i].Cells["DOPE_Item"].Value));
                     if (dt != null && dt.Rows.Count > 0 && Convert.ToBoolean(dt.Rows[0]["Existe"]))
                     {
                        var mensaje = "El Servicio " + grdItems.Rows[BSItems.Position].Cells["Servicio"].Value.ToString() + " se encuentra facturado ";
                        mensaje += " por el importe " + dt.Rows[0]["CCCT_Monto"];
                        mensaje += " " + grdItems.Rows[BSItems.Position].Cells["Moneda"].Value.ToString();
                        mensaje += " " + grdItems.Rows[BSItems.Position].Cells["TIPE_Descripcion"].Value.ToString() + "  Nro. Documento: " + dt.Rows[0]["DOCV_Numero"];
                        mensaje += " y por el proveedor " + grdItems.Rows[BSItems.Position].Cells["Proveedor"].Value.ToString();

                        //DialogResult result = Dialogos.MostrarMensajePregunta(Presenter.Title, mensaje, Dialogos.LabelBoton.Si_No);
                        DialogResult result = MessageBox.Show(mensaje, Presenter.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                           grdItems.EndEdit();
                           grdItems.EndUpdate();
                           BSItems.EndEdit();
                           ValidarAgrupación();
                           CalcularTotal();
                        }
                        else
                        {
                           Close();
                        }
                     }
                  }
                  else
                  {
                     grdItems.EndEdit();
                     grdItems.EndUpdate();
                     BSItems.EndEdit();
                     ValidarAgrupación();
                     CalcularTotal();
                  }
               }
            }
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Eventos ]

      private void tsmColumna_Click(object sender, EventArgs e)
      {
         if (sender is ToolStripMenuItem)
         {
            ToolStripMenuItem _item = (ToolStripMenuItem)sender;
            grdItems.Columns[_item.Tag.ToString()].IsVisible = _item.Checked;
         }
      }

      private void grdItems_ValueChanged(object sender, EventArgs e)
      {
         try
         {
            if (!(grdItems.ActiveEditor is RadCheckBoxEditor)) return;
            SetValueChanged();
            EditClick();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el registro.", ex); }
      }

      private void grdItems_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is GridCommandCellElement)
            {
               switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     EditClick();
                     break;
               }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }

      }

       private void EditClick()
      {
           //SeleccionarItem();
                     LimpiarDatosServicio();
                     //CheckBox _chk = ((System.Data.DataRowView)(BSItems.Current)).Row["Agregar"];    


                     DataRowView _DR = ((System.Data.DataRowView)(BSItems.Current));
                     grdItems.Rows[BSItems.Position].Cells["Agregar"].Value = true;
                     SetValueChanged();
                     if (Convert.ToBoolean(grdItems.Rows[BSItems.Position].Cells["Agregar"].Value) == true)
                     {
                        ValidarAgrupación();
                        txtServicio.Text = grdItems.Rows[BSItems.Position].Cells["Servicio"].Value.ToString();

                        if (grdItems.Rows[BSItems.Position].Cells["SERV_Codigo"].Value != null && !String.IsNullOrEmpty(grdItems.Rows[BSItems.Position].Cells["SERV_Codigo"].Value.ToString()))
                        {
                           Presenter.ItemCtaCte.SERV_Codigo = Int32.Parse(grdItems.Rows[BSItems.Position].Cells["SERV_Codigo"].Value.ToString());
                           Presenter.ItemCtaCte.SERV_Nombre_SPA = grdItems.Rows[BSItems.Position].Cells["SERV_Nombre_SPA"].Value.ToString().Trim();
                           Presenter.ItemCtaCte.CCCT_CuentaBI = grdItems.Rows[BSItems.Position].Cells["SERV_CuenCosto"].Value.ToString();
                           Presenter.ItemCtaCte.TIPO_TabOPE_Costo = grdItems.Rows[BSItems.Position].Cells["TIPO_TabOPE_Costo"].Value.ToString();
                           Presenter.ItemCtaCte.TIPO_CodOPE_Costo = grdItems.Rows[BSItems.Position].Cells["TIPO_CodOPE_Costo"].Value.ToString();
                           Presenter.ItemCtaCte.CENT_Ano = grdItems.Rows[BSItems.Position].Cells["CENT_Ano"].Value.ToString();
                           Presenter.ItemCtaCte.CENT_Codigo = grdItems.Rows[BSItems.Position].Cells["CENT_Codigo"].Value.ToString();
                           Presenter.ItemCtaCte.CCCT_Glosa = grdItems.Rows[BSItems.Position].Cells["SERV_Nombre_SPA"].Value.ToString();
                        }

                        txtServicio.Enabled = false;
                        Presenter.ENTC_Codigo = grdItems.Rows[BSItems.Position].Cells["ENTC_Codigo"].Value.ToString() != null ? Convert.ToInt32(grdItems.Rows[BSItems.Position].Cells["ENTC_Codigo"].Value.ToString()) : 0;
                        Presenter.TIPE_CodigoServicio = (short)(!String.IsNullOrEmpty(grdItems.Rows[BSItems.Position].Cells["TIPE_Codigo"].Value.ToString()) ? Convert.ToInt16(grdItems.Rows[BSItems.Position].Cells["TIPE_Codigo"].Value.ToString()) : 0);
                        Presenter.CTAR_Tipo = grdItems.Rows[BSItems.Position].Cells["CTAR_Tipo"].Value.ToString();
                        txtDOPE_ValorVta.Text = grdItems.Rows[BSItems.Position].Cells["PreVentaSada"].Value.ToString();
                        txtDOPE_Monto.Text = grdItems.Rows[BSItems.Position].Cells["PreCostoSada"].Value.ToString();

                        txtCliente.Text = grdItems.Rows[BSItems.Position].Cells["Proveedor"].Value.ToString();
                        if (grdItems.Rows[BSItems.Position].Cells["UltCostoServicio"].Value == null)
                           grdItems.Rows[BSItems.Position].Cells["UltCostoServicio"].Value = "False";
                        ChkUltimoCosto.Checked = Convert.ToBoolean(grdItems.Rows[BSItems.Position].Cells["UltCostoServicio"].Value.ToString());
                        Presenter._CostoDetServicio = Decimal.Parse(grdItems.Rows[BSItems.Position].Cells["CostoOriginal"].Value.ToString());
                        Presenter._CostoServicio = Convert.ToDecimal(txtDOPE_Monto.Text);
                        Presenter.TMovimiento = ((DataRowView)BSItems.Current)["TMovimiento"].ToString();
                        //CbTIPO_CodMND.SelectedValue = _DR["TIPO_CodMND"].ToString();
                        //Presenter._CostoServicio = Convert.ToDecimal(txtDOPE_Monto.Text);

                        if (cmbTIPE_Codigo.TipoEntidadSelectedItem == null)
                        { cmbTIPE_Codigo.SelectedValue = grdItems.Rows[BSItems.Position].Cells["TIPE_Codigo"].Value; }

                        if (Proveedor.Value == null)
                        {
                           Proveedor.SetValue(Presenter.ENTC_Codigo);
                           if (Proveedor.Value.ENTC_DiasCredito.HasValue)
                           { DTPCCCT_FechaVcto.NSFecha = Presenter.Session.Fecha.AddDays((Double)Proveedor.Value.ENTC_DiasCredito); }
                           else { DTPCCCT_FechaVcto_Enabled = true; }
                        }
                        if (pnlRenta3ra.Visible) { CalcularImp3ra(); }
                        //NUDCCCT_ValVta.Value = _DR["PreCostoSada"] != DBNull.Value ? Convert.ToDecimal(_DR["PreCostoSada"].ToString()) : 0;
                     }

      }

      private void grdItems_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            if (!(e.CellElement is GridCommandCellElement)) return;
            if (e.Column.Name.Equals("Edit"))
            {
               var bte = (RadButtonElement)e.CellElement.Children[0];
               if (bte.Image == null)
               {
                  bte.TextImageRelation = TextImageRelation.Overlay;
                  bte.DisplayStyle = DisplayStyle.Image;
                  bte.ImageAlignment = ContentAlignment.MiddleCenter;
                  bte.Image = Resources.check_16x16;
                  bte.ToolTipText = @"Editar Registro";
                  bte.AutoSize = true;
               }
            }
            if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
               e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
            }
         }
         catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }

      private void grdItems_DataError(object sender, GridViewDataErrorEventArgs e)
      {
         e.Cancel = false;
         if ((e.Exception) is System.Data.NoNullAllowedException)
         {
            RadGridView view = (RadGridView)sender;
            if (view.CurrentRow is GridViewNewRowInfo)
            {
               view.CurrentRow.ErrorText = e.Exception.Message;
               //The following line doesnt work when adding a row, as e.RowIndex will equal -1
               //(sender as RadGridView).Rows[e.RowIndex].ErrorText = e.Exception.Message;  		      
               e.ThrowException = false;
            }
         }
      }

      private void tsmTodos_Click(object sender, EventArgs e)
      {
         foreach (GridViewDataColumn column in grdItems.Columns)
         { column.IsVisible = tsmTodos.Checked; }

         foreach (ToolStripItem item in tsmColumnas.DropDownItems)
         { if (item is ToolStripMenuItem) { ((ToolStripMenuItem)item).Checked = tsmTodos.Checked; } }

         if (!tsmTodos.Checked)
         {
            foreach (String item in defaultColumns)
            {
               if (!String.IsNullOrEmpty(item))
               {
                  grdItems.Columns[item].IsVisible = true;
                  foreach (ToolStripItem tsitem in tsmColumnas.DropDownItems)
                  { if (tsitem is ToolStripMenuItem && tsitem.Tag.ToString() == item) { ((ToolStripMenuItem)tsitem).Checked = true; } }
               }
            }
         }
      }

      private void btnBuscar_Click(object sender, EventArgs e)
      {
         if (CbTIPO_CodMND.TiposSelectedItem != null && NUDCCCT_TipoCambio.Value > 0)
         {
            LoadImportacion();
         }
         else
         {
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar una moneda e ingresar el Tipo de Cambio");
         }
      }

      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItem();
      //EditClick();
      }

      private void btnActualizar_Click(object sender, EventArgs e)
      {
         try
         {
            grdItems.Rows[BSItems.Position].Cells["PreCostoSada"].Value = txtDOPE_Monto.Text;
            grdItems.Rows[BSItems.Position].Cells["UltCostoServicio"].Value = ChkUltimoCosto.Checked;
            CalcularTotal();
            LimpiarDatosServicio();
         }
         catch (Exception) { }
      }

      private void btnGuardar_Click(object sender, EventArgs e)
      {
         CalcularMontoTotal();
         Guardar();
      }

      private void Proveedor_AyudaValueChanged(object sender, EventArgs e)
      {
         try
         {
            if (Proveedor.Value != null)
            {
               if (Presenter.ItemCtaCte.Instance == InstanceEntity.Added)
               {
                  CbTIPO_CodFPG.SelectedValue = Proveedor.Value.ENTC_DiasCredito == 0 || Proveedor.Value.ENTC_DiasCredito == null ? "001" : "002";
                  txaCCCT_CodReferencia.ENTC_Codigo = Proveedor.Value.ENTC_Codigo;
                  if (Proveedor.Value.ENTC_DiasCredito.HasValue)
                  { DTPCCCT_FechaVcto.NSFecha = Presenter.Session.Fecha.AddDays((Double)Proveedor.Value.ENTC_DiasCredito); }
                  else { DTPCCCT_FechaVcto_Enabled = true; }

                  Presenter.ItemCtaCte.NoDomiciliado = Proveedor.Value.ENTC_Domiciliado;
                  if (Proveedor.Value.ENTC_Domiciliado)
                  { pnlRenta3ra.Visible = true; txnCCCT_Imp1.Enabled = false; label10.Enabled = false; txnCCCT_Imp1.Value = 0; }
                  else
                  { pnlRenta3ra.Visible = false; txnCCCT_Imp1.Enabled = true; label10.Enabled = true; }
                  CalcularMontoTotal();
               }
               else
               {
                  Presenter.ItemCtaCte.NoDomiciliado = Proveedor.Value.ENTC_Domiciliado;
                  if (Proveedor.Value.ENTC_Domiciliado)
                  { pnlRenta3ra.Visible = true; txnCCCT_Imp1.Enabled = false; label10.Enabled = false; txnCCCT_Imp1.Value = 0; }
                  else
                  { pnlRenta3ra.Visible = false; txnCCCT_Imp1.Enabled = true; label10.Enabled = true; }
               }
            }
            else
            {
               pnlRenta3ra.Visible = false;
               cmbTIPO_CodTI3.SelectedIndex = 0;
               chkCCCT_RetencionIGV.Checked = false;
            }
         }
         catch (Exception)
         { }
      }

      private void PRO008MView_Load(object sender, EventArgs e)
      {

      }

      private void NUDCCCT_ValVta_ValueChanged(object sender, EventArgs e)
      {
         if (cmbTIPO_CodTI3.TiposSelectedValue == null)
         {
            txnCCCT_Imp1.Value = Presenter.CalculaIGV(txnCCCT_ValVta.Value);
            txnCCCT_Monto.Value = Convert.ToDecimal(txnCCCT_ValVta.Value) + Convert.ToDecimal(txnCCCT_Imp1.Value) + Convert.ToDecimal(txnCCCT_Imp2.Value);
         }
         else { CalcularMontoTotal(); }
         //if(CbTIPO_CodTDO.TiposSelectedValue == "001")
         //   txtDOPE_Monto.Text = NUDCCCT_ValVta.Value.ToString();
      }

      private void btnHelpDetalle_Click(object sender, EventArgs e)
      {
         if (Presenter.COPE_Codigo > 0)
         {
            LimpiarDatosServicio();
         }
         else
         {
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un operativo");
         }
      }

      private void btnSalir_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void DTPCCCT_FechaEmision_ValueChanged(object sender, EventArgs e)
      {
         NUDCCCT_TipoCambio.Value = Presenter.TCporDia(DTPCCCT_FechaEmision.Value.Year.ToString() + DTPCCCT_FechaEmision.Value.Month.ToString().PadLeft(2, '0') + DTPCCCT_FechaEmision.Value.Day.ToString().PadLeft(2, '0'));
      }

      private void PRO008MView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            if (Closing != true)
            {
               this.FormClosing -= PRO008MView_FormClosing;
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }

      }

      private void PRO008MView_FormClosed(object sender, FormClosedEventArgs e)
      {
         Presenter.IsClosedMView();
      }

      private void cmbTIPE_Codigo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
            {
               Proveedor.Enabled = true;
               Proveedor.TipoEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo);
               //Proveedor.Clear();
               //Proveedor.ClearValue();
            }
            else { 
               //Proveedor.Enabled = false; 
               //Proveedor.ClearValue(); 
            }
         }
         catch (Exception)
         { }
      }

      private void cmbTIPO_CodTDO_SelectedValueChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPO_CodTDO.SelectedValue != null)
            {
               if (cmbTIPO_CodTDO.SelectedValue.ToString().Equals(Tipos.GetTipo(Tipos.TipoTDO.NotaCredito)))
               {
                  pnlDocReferencia.Visible = true;
                  txnCCCT_ValVta.Enabled = true;
               }
               else
               {
                  pnlDocReferencia.Visible = false;
                  txnCCCT_ValVta.Enabled = false;
                  txaCCCT_CodReferencia.ClearValue();
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }

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

      private void txtCTCT_Numero_KeyPress(object sender, KeyPressEventArgs e)
      {
         Infrastructure.Aspect.Constants.Util.ValidaCodigo_KeyPress(ref e);
      }

      private void CbTIPO_CodFPG_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (CbTIPO_CodFPG.SelectedValue != null)
            {
               if (CbTIPO_CodFPG.SelectedValue.ToString().Equals("002"))
               { DTPCCCT_FechaVcto.Enabled = DTPCCCT_FechaVcto_Enabled; }
               else { DTPCCCT_FechaVcto.Enabled = false; }
            }
            else { DTPCCCT_FechaVcto.Enabled = false; }
         }
         catch (Exception)
         { }
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

      private void txnCCCT_Imp2_LostFocus(object sender, EventArgs e)
      {
         try
         {
            if (txnCCCT_Imp2.Value > 0)
            { txnCCCT_Imp2.Value = 0; }
            CalcularMontoTotal();
         }
         catch (Exception)
         { }
      }
      #endregion

   }

}
