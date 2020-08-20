using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Delfin.Controls;
using Delfin.Entities;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using ColumnaAyuda = Infrastructure.WinFormsControls.ColumnaAyuda;
using ContentAlignment = System.Drawing.ContentAlignment;
using TiposEntidad = Delfin.Controls.TiposEntidad;

namespace Delfin.Principal
{
   public partial class PRO007PView : Form, IPRO007PView
   {
      #region [ Variables ]
      private bool Closing = false;

      #endregion

      #region [ Formulario ]
      public PRO007PView()
      {
         InitializeComponent();
         try
         {
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormClosing += PRO007MView_FormClosing;
            this.FormClosed += PRO007MView_FormClosed;
            /* Encabezado Facturacion */
            btnGuardar.Click += btnGuardar_Click;
            //btnBuscar.Click += btnBuscar_Click;
            //btnBuscarTarja.Click += btnBuscarTarja_Click;
            btnSalir.Click += btnSalir_Click;
            Load += PRO007MView_Load;
            CbTIPO_CodFPG.SelectedValueChanged += CbTIPO_CodFPG_SelectedValueChanged;
            AyudaENTC_Cliente.TipoEntidad = TiposEntidad.TIPE_Cliente;
            /* Detalle Facturacion */
            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += BSItems_CurrentItemChanged;
            grdItemsServicios.ValueChanged += grdItemsServicios_ValueChanged;
            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;
            txaSeries.SelectedItemSerieChanged += txaSeries_SelectedItemSerieChanged;
            txtPDOV_Observaciones.TextChanged += txtPDOV_Observaciones_TextChanged;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }

      #endregion

      #region [ Propiedades ]
      public PRO007Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      private Hashtable HashFormulario { get; set; }
       
      #endregion

      #region [ IPRO007MView ]
      public void LoadView()
      {
         try
         {
            AyudaENTC_Cliente.ContainerService = Presenter.ContainerService;

            Entities.Parametros para = Presenter.Client.GetOneParametrosByClave("PREF_TDO_SLI");
            String[] TiposTDO = null;
            if (para != null) { TiposTDO = para.PARA_Valor.ToString().Split('|'); }

            txaSeries.LoadControl(Presenter.ContainerService, "Ayuda de Series", TiposTDO, new String[] { "S" });
            //CbTIPO_CodTDO.LoadControl(Presenter.ContainerService, "Tabla Moneda", "TDO", "< Selecione Documento >", ListSortDirection.Descending);
            CbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Tabla Moneda", "MND", "< Selecione Moneda >", ListSortDirection.Descending);
            CbTIPO_CodFPG.LoadControl(Presenter.ContainerService, "Tabla F. Pago", "FPG", "< Selecione F. Pago >", ListSortDirection.Descending);
            CmbDOCV_Estado.LoadControl(Presenter.ContainerService, "Tabla Estado", "FAC", "< Selecione Estado >", ListSortDirection.Descending);
            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo de Entidad", "< Sel. Tipo de Entidad >", ListSortDirection.Ascending);
            if (!String.IsNullOrEmpty(Presenter.TipoDocumentoVenta))
            {
               CbTIPO_CodMND.Enabled = true;
               switch (Presenter.TipoDocumentoVenta)
               {
                  case "PreFactura":
                     btnGuardar.Visible = true;
                     Presenter.TInicio = PRO007Presenter.TipoInicio.NuevoPreFactura;
                     break;
                  case "Factura":
                     btnGuardar.Visible = false;
                     Presenter.TInicio = PRO007Presenter.TipoInicio.NuevoFactura;
                     break;
               }
            }
            FormatDataGrid();
            Text = Presenter.TipoDocumentoVenta;
            switch (Presenter.TInicio)
            {
               case PRO007Presenter.TipoInicio.NuevoFactura:
                  break;
               case PRO007Presenter.TipoInicio.EditarFactura:
                  //CbTIPO_CodTDO.Enabled = false;
                  txaSeries.Enabled = false;
                  break;
               case PRO007Presenter.TipoInicio.NuevoPreFactura:
                  break;
               case PRO007Presenter.TipoInicio.EditarPreFactura:
                  break;
               case PRO007Presenter.TipoInicio.EditarNotaCredito:
                  break;
               default:
                  break;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      #region [Encabezado Facturacion ]
      public void ClearItem()
      {
         try
         {
            NUDPDOV_TipoCambio.Value = 0;
            //CbTIPO_CodTDO.SelectedIndex = 0;
            txaSeries.Clear();
            txtPDOV_Numero.Clear();
            if (DTPPDOV_FechaEmision.Value == Presenter.Session.Fecha)
               GetTipoCambio();
            DTPPDOV_FechaEmision.Value = Presenter.Session.Fecha;
            DTPPDOV_FechaVcmto.NSFecha = Presenter.Session.Fecha.AddMonths(2);
            GetTipoCambio();
            CbTIPO_CodMND.SelectedIndex = 3;
            CbTIPO_CodFPG.SelectedIndex = 0;
            AyudaENTC_Cliente.ClearValue();
            txtPDOV_Observaciones.Clear();
            txtIGV.Clear();
            txtSubTotal.Clear();
            txtTotal.Clear();
            TxtDOCV_Notas.Clear();
            lblLetras.Text = "";
            CmbDOCV_Estado.SelectedIndex = 0;
            CbTIPO_CodMND.Enabled = true;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void GetItem()
      {
         try
         {
            Presenter.ItemPreDocsVta.DOCV_FechaEmision = DTPPDOV_FechaEmision.Value.Date;
            Presenter.ItemPreDocsVta.DOCV_FechaVcmto = DTPPDOV_FechaVcmto.NSFecha != null ? DTPPDOV_FechaVcmto.NSFecha.Value : (DateTime?)null;
            Presenter.ItemPreDocsVta.TIPO_CodMND = CbTIPO_CodMND.TiposSelectedValue ?? null;
            Presenter.ItemPreDocsVta.TIPO_CodFPG = CbTIPO_CodFPG.TiposSelectedValue ?? null;
            Presenter.ItemPreDocsVta.DOCV_TipoCambio = NUDPDOV_TipoCambio.Value;
            Presenter.ItemPreDocsVta.DOCV_Observaciones = txtPDOV_Observaciones.Text;
            Presenter.ItemPreDocsVta.TIPE_Codigo = cmbTIPE_Codigo.TipoEntidadSelectedItem != null ? cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo : Convert.ToInt16(0);
            Presenter.ItemPreDocsVta.ENTC_Codigo = AyudaENTC_Cliente.Value != null ? AyudaENTC_Cliente.Value.ENTC_Codigo : 0;

            if (txaSeries.SelectedItemTipoTDO != null)
            {
               Presenter.ItemPreDocsVta.TIPO_CodTDO = txaSeries.SelectedItemTipoTDO.TIPO_CodTipo; // CbTIPO_CodTDO.TiposSelectedValue;
               if (txaSeries.SelectedItem != null)
               {
                  Presenter.ItemPreDocsVta.DOCV_Serie = txaSeries.SelectedItem.SERI_Serie;
                  Presenter.DOCV_Serie = txaSeries.SelectedItem.SERI_Serie;
               }
            }
            if (AyudaENTC_Cliente.Value != null)
            {
               Presenter.ClienteSelected = AyudaENTC_Cliente.Value;
               //TDI 001 RUC
               if (!String.Equals(Presenter.ClienteSelected.TIPO_CodTDI, "001"))
               {
                  if (Presenter.ItemPreDocsVta.TIPO_CodTDO.Equals(Infrastructure.Aspect.Constants.Util.getTipoTDO(TipoTDO.FACTURA)))
                  {
                     //TDO 003 Boleta de Venta
                     Dialogos.MostrarMensajeInformacion(Presenter.Title, "El Cliente Seleccionado no tiene RUC,\n El documento que se generara sera un Boleta de Venta ");
                     txaSeries.SelectedItemTipoTDO.TIPO_CodTipo = "003";
                     Presenter.ItemPreDocsVta.TIPO_CodTDO = "003";
                  }
               }
            }
            Presenter.ItemPreDocsVta.DOCV_Notas = TxtDOCV_Notas.Text;
            if (CmbDOCV_Estado.SelectedValue == null) return;
            switch (CmbDOCV_Estado.SelectedValue.ToString())
            {
               case "001":
                  Presenter.ItemPreDocsVta.DOCV_Estado = "E"; /* Emitida */
                  break;
               case "002":
                  Presenter.ItemPreDocsVta.DOCV_Estado = "I";  /* Impresa */
                  break;
               case "003":
                  Presenter.ItemPreDocsVta.DOCV_Estado = "A"; /* Anulada */
                  break;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.GetItem, ex); }
      }

      public void GetItemTotales()
      {
         try
         {
            Decimal ddovValorVenta = 0;
            Decimal tipoCambio = 0;
            ddovValorVenta = Decimal.Parse(txtSubTotal.Text);
            tipoCambio = Convert.ToDecimal(NUDPDOV_TipoCambio.Value.ToString(CultureInfo.InvariantCulture));
            if (Presenter.ItemPreDocsVta.TIPO_CodMND == "001")  // Soles
            {
               Presenter.ItemPreDocsVta.DOCV_Impuesto1 = Decimal.Parse(txtIGV.Text);
               Presenter.ItemPreDocsVta.DOCV_Impuesto1D = Decimal.Parse(txtIGV.Text) / tipoCambio;
               Presenter.ItemPreDocsVta.DOCV_PrecVtaTotal = Decimal.Parse(txtTotal.Text);
               Presenter.ItemPreDocsVta.DOCV_PrecVtaTotalD = Decimal.Parse(txtTotal.Text) / tipoCambio;
               Presenter.ItemPreDocsVta.DOCV_ValorTotal = ddovValorVenta;
               Presenter.ItemPreDocsVta.DOCV_ValorTotalD = ddovValorVenta / tipoCambio;
               Presenter.ItemPreDocsVta.DOCV_ValorVtaTotal = Decimal.Parse(txtTotal.Text);
               Presenter.ItemPreDocsVta.DOCV_ValorVtaTotalD = Decimal.Parse(txtTotal.Text) / tipoCambio;
            }
            else
            {
               Presenter.ItemPreDocsVta.DOCV_Impuesto1 = Decimal.Parse(txtIGV.Text) * tipoCambio;
               Presenter.ItemPreDocsVta.DOCV_Impuesto1D = Decimal.Parse(txtIGV.Text);
               Presenter.ItemPreDocsVta.DOCV_PrecVtaTotalD = Decimal.Parse(txtTotal.Text);
               Presenter.ItemPreDocsVta.DOCV_PrecVtaTotal = Decimal.Parse(txtTotal.Text) * tipoCambio;
               Presenter.ItemPreDocsVta.DOCV_ValorTotal = ddovValorVenta * tipoCambio; ;
               Presenter.ItemPreDocsVta.DOCV_ValorTotalD = ddovValorVenta;
               Presenter.ItemPreDocsVta.DOCV_ValorVtaTotal = Decimal.Parse(txtTotal.Text) * tipoCambio;
               Presenter.ItemPreDocsVta.DOCV_ValorVtaTotalD = Decimal.Parse(txtTotal.Text);
            }
            Presenter.ItemPreDocsVta.DOCV_PorcImp1 = Presenter.IGV;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.GetItem, ex); }
      }
      public void SetItem()
      {
         try
         {
            if (!String.IsNullOrEmpty(Presenter.TipoDocumentoVenta))
            {
               CbTIPO_CodMND.Enabled = false;
               switch (Presenter.TipoDocumentoVenta)
               {
                  case "PreFactura":
                     txaSeries.SetValue(Presenter.ItemPreDocsVta.TIPO_CodTDO, Presenter.ItemPreDocsVta.DOCV_Serie);
                     Presenter.DOCV_Serie = Presenter.ItemPreDocsVta.DOCV_Serie;
                     Presenter.DOCV_Observaciones = Presenter.ItemPreDocsVta.DOCV_Observaciones;
                     //CbTIPO_CodTDO.TiposSelectedValue = Presenter.ItemPreDocsVta.TIPO_CodTDO ?? null;
                     //txtPDOV_Numero.Text = Presenter.ItemPreDocsVta.DOCV_Numero ?? null;
                     if (Presenter.ItemPreDocsVta.DOCV_FechaEmision != null) { DTPPDOV_FechaEmision.Value = Presenter.ItemPreDocsVta.DOCV_FechaEmision.Value; }
                     if (Presenter.ItemPreDocsVta.DOCV_FechaVcmto != null) { DTPPDOV_FechaVcmto.NSFecha = Presenter.ItemPreDocsVta.DOCV_FechaVcmto.Value; }
                     CbTIPO_CodMND.TiposSelectedValue = Presenter.ItemPreDocsVta.TIPO_CodMND;
                     CbTIPO_CodFPG.TiposSelectedValue = Presenter.ItemPreDocsVta.TIPO_CodFPG;
                     NUDPDOV_TipoCambio.Value = Presenter.ItemPreDocsVta.DOCV_TipoCambio;
                     txtPDOV_Observaciones.Text = Presenter.ItemPreDocsVta.DOCV_Observaciones;
                     if (Presenter.ItemPreDocsVta.TIPE_Codigo > 0) { cmbTIPE_Codigo.TipoEntidadSelectedValue = Presenter.ItemPreDocsVta.TIPE_Codigo; }
                    // if (Presenter.ItemPreDocsVta.ENTC_Codigo > 0) { AyudaENTC_Cliente.SetValue////(Presenter.ItemPreDocsVta.ENTC_Codigo); }
                     if (Presenter.ItemDocsVta != null)
                     {
                         if (Presenter.ItemDocsVta.ENTC_Codigo > 0)
                         {
                             AyudaENTC_Cliente.UsarTipoEntidad = false;
                             AyudaENTC_Cliente.TipoEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(Presenter.ItemDocsVta.TIPE_Codigo);
                             AyudaENTC_Cliente.SetValue(Presenter.ItemDocsVta.ENTC_Codigo.Value);
                             AyudaENTC_Cliente.UsarTipoEntidad = true;
                         }
                     }
                     TxtDOCV_Notas.Text = Presenter.ItemPreDocsVta.DOCV_Notas;
                     //txtserie.Text = Presenter.ItemPreDocsVta.DOCV_Serie;
                     switch (Presenter.ItemPreDocsVta.DOCV_Estado)
                     {
                        case "E":
                           CmbDOCV_Estado.SelectedValue = "001";      /* Emitida */
                           break;
                        case "I":
                           CmbDOCV_Estado.SelectedValue = "002";  /* Impresa */
                           break;
                        case "A":
                           CmbDOCV_Estado.SelectedValue = "003"; /* Anulada */
                           break;
                     }
                     break;
                  case "Factura":
                     Entities.Parametros para = Presenter.Client.GetOneParametrosByClave("FAC_TDO");
                     String[] TiposTDO = null;
                     if (para != null) { TiposTDO = para.PARA_Valor.ToString().Split('|'); }

                     txaSeries.LoadControl(Presenter.ContainerService, "Ayuda de Series", TiposTDO);
                     txaSeries.SetValue(Presenter.ItemDocsVta.TIPO_CodTDO, Presenter.ItemDocsVta.DOCV_Serie);
                     //CbTIPO_CodTDO.TiposSelectedValue = Presenter.ItemDocsVta.TIPO_CodTDO ?? null;
                     txtPDOV_Numero.Text = Presenter.ItemDocsVta.DOCV_Numero ?? null;
                     if (Presenter.ItemDocsVta.DOCV_FechaEmision != null) { DTPPDOV_FechaEmision.Value = Presenter.ItemDocsVta.DOCV_FechaEmision.Value; }
                     if (Presenter.ItemDocsVta.DOCV_FechaVcmto != null) { DTPPDOV_FechaVcmto.NSFecha = Presenter.ItemDocsVta.DOCV_FechaVcmto.Value; }
                     CbTIPO_CodMND.TiposSelectedValue = Presenter.ItemDocsVta.TIPO_CodMND;
                     CbTIPO_CodFPG.TiposSelectedValue = Presenter.ItemDocsVta.TIPO_CodFPG;
                     NUDPDOV_TipoCambio.Value = Presenter.ItemDocsVta.DOCV_TipoCambio;
                     txtPDOV_Observaciones.Text = Presenter.ItemDocsVta.DOCV_Observaciones;
                     if (Presenter.ItemDocsVta.TIPE_Codigo > 0) { cmbTIPE_Codigo.TipoEntidadSelectedValue = Presenter.ItemDocsVta.TIPE_Codigo; }
                     if (Presenter.ItemDocsVta.ENTC_Codigo > 0)
                     {
                        AyudaENTC_Cliente.UsarTipoEntidad = false;
                        AyudaENTC_Cliente.TipoEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(Presenter.ItemDocsVta.TIPE_Codigo);
                        AyudaENTC_Cliente.SetValue(Presenter.ItemDocsVta.ENTC_Codigo.Value);
                        AyudaENTC_Cliente.UsarTipoEntidad = true;
                     }
                     TxtDOCV_Notas.Text = Presenter.ItemDocsVta.DOCV_Notas;
                     //txtserie.Text = Presenter.ItemDocsVta.DOCV_Serie;
                     switch (Presenter.ItemDocsVta.DOCV_Estado)
                     {
                        case "E":
                           CmbDOCV_Estado.SelectedValue = "001";      /* Emitida */
                           btnGuardar.Visible = true;
                           break;
                        case "I":
                           CmbDOCV_Estado.SelectedValue = "002";  /* Impresa */
                           break;
                        case "A":
                           CmbDOCV_Estado.SelectedValue = "003"; /* Anulada */
                           break;
                     }

                     break;


                  case "eFact":
                     Entities.Parametros paraEfact = Presenter.Client.GetOneParametrosByClave("FAC_TDO");
                     String[] TiposTDOeFact = null;
                     if (paraEfact != null) { TiposTDOeFact = paraEfact.PARA_Valor.ToString().Split('|'); }

                     txaSeries.LoadControl(Presenter.ContainerService, "Ayuda de Series", TiposTDOeFact);
                     txaSeries.SetValue(Presenter.ItemDocsVta.TIPO_CodTDO, Presenter.ItemDocsVta.DOCV_Serie);
                     //CbTIPO_CodTDO.TiposSelectedValue = Presenter.ItemDocsVta.TIPO_CodTDO ?? null;
                     txtPDOV_Numero.Text = Presenter.ItemDocsVta.DOCV_Numero ?? null;
                     if (Presenter.ItemDocsVta.DOCV_FechaEmision != null) { DTPPDOV_FechaEmision.Value = Presenter.ItemDocsVta.DOCV_FechaEmision.Value; }
                     if (Presenter.ItemDocsVta.DOCV_FechaVcmto != null) { DTPPDOV_FechaVcmto.NSFecha = Presenter.ItemDocsVta.DOCV_FechaVcmto.Value; }
                     CbTIPO_CodMND.TiposSelectedValue = Presenter.ItemDocsVta.TIPO_CodMND;
                     CbTIPO_CodFPG.TiposSelectedValue = Presenter.ItemDocsVta.TIPO_CodFPG;
                     NUDPDOV_TipoCambio.Value = Presenter.ItemDocsVta.DOCV_TipoCambio;
                     txtPDOV_Observaciones.Text = Presenter.ItemDocsVta.DOCV_Observaciones;
                     if (Presenter.ItemDocsVta.TIPE_Codigo > 0) { cmbTIPE_Codigo.TipoEntidadSelectedValue = Presenter.ItemDocsVta.TIPE_Codigo; }
                     if (Presenter.ItemDocsVta.ENTC_Codigo > 0)
                     {
                         AyudaENTC_Cliente.UsarTipoEntidad = false;
                         AyudaENTC_Cliente.TipoEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(Presenter.ItemDocsVta.TIPE_Codigo);
                         AyudaENTC_Cliente.SetValue(Presenter.ItemDocsVta.ENTC_Codigo.Value);
                         AyudaENTC_Cliente.UsarTipoEntidad = true;
                     }
                     TxtDOCV_Notas.Text = Presenter.ItemDocsVta.DOCV_Notas;
                     //txtserie.Text = Presenter.ItemDocsVta.DOCV_Serie;
                     switch (Presenter.ItemDocsVta.DOCV_Estado)
                     {
                         case "E":
                             CmbDOCV_Estado.SelectedValue = "001";      /* Emitida */
                             btnGuardar.Visible = true;
                             break;
                         case "I":
                             CmbDOCV_Estado.SelectedValue = "002";  /* Impresa */
                             break;
                         case "A":
                             CmbDOCV_Estado.SelectedValue = "003"; /* Anulada */
                             break;
                     }

                     break;

               }
            }

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetItem, ex); }
      }
      public void SetInstance(InstanceView xInstance)
      {
         try
         {
            errorProvider1.Dispose();
            CmbDOCV_Estado.Enabled = false;
            switch (xInstance)
            {
               case InstanceView.Default:
                  break;
               case InstanceView.New:
                  CmbDOCV_Estado.SelectedValue = @"001";// Emitida :)
                  if (!String.IsNullOrEmpty(Presenter.TipoDocumentoVenta))
                  {
                     switch (Presenter.TipoDocumentoVenta)
                     {
                        case "PreFactura":
                           break;
                     }
                  }
                  HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                  break;
               case InstanceView.Edit:
                  if (Presenter.ItemPreDocsVta.DOCV_Estado.Equals("I")) // impresa significa que el prefactura fue facturada fecha 06-11-2015 piter
                  {
                     btnGuardar.Enabled = false;
                  }
                  else
                  {
                     btnGuardar.Enabled = true;
                  }
                  if (!String.IsNullOrEmpty(Presenter.TipoDocumentoVenta))
                  {
                     switch (Presenter.TipoDocumentoVenta)
                     {
                        case "PreFactura":
                           if (!string.IsNullOrEmpty(Presenter.TipoPreFactura))
                           {
                              if (Presenter.TipoPreFactura.Equals("OPERACION"))// operacion
                              {
                              }
                              else // Tarjas
                              {
                              }
                           }
                           break;
                     }
                  }

                  HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
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
      public void ShowValidation()
      {
         try
         {
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.ItemPreDocsVta.MensajeError, Dialogos.Boton.Detalles);
            FormShowErrorProvider<PreDocsVta>.Validate(Presenter.ItemPreDocsVta, this, errorProvider1);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }

      public void SetEnabled()
      {
         try
         {
            switch (Presenter.TInicio)
            {
               case PRO007Presenter.TipoInicio.NuevoFactura:
                  break;
               case PRO007Presenter.TipoInicio.EditarFactura:
                  DTPPDOV_FechaEmision.Enabled = false;
                  DTPPDOV_FechaVcmto.Enabled = false;
                  CbTIPO_CodMND.Enabled = false;
                  CbTIPO_CodFPG.Enabled = false;
                  NUDPDOV_TipoCambio.Enabled = false;
                  txtPDOV_Observaciones.ReadOnly = false;
                  txtPDOV_Observaciones.Enabled = true;
                  txaSeries.cmbTIPO_CodTDO_Enabled = false;

                  if (Presenter.ItemDocsVta != null && Presenter.ItemDocsVta.DOCV_Estado.Equals("E"))
                  {
                     txaSeries.cmbSERI_Serie_Enabled = true;
                     AyudaENTC_Cliente.Enabled = true;
                     cmbTIPE_Codigo.Enabled = true;
                  }
                  else
                  {
                     txaSeries.cmbSERI_Serie_Enabled = false;
                     AyudaENTC_Cliente.Enabled = false;
                     cmbTIPE_Codigo.Enabled = false;
                  }
                  break;
               case PRO007Presenter.TipoInicio.NuevoPreFactura:
                  break;
               case PRO007Presenter.TipoInicio.EditarPreFactura:
                  break;
               case PRO007Presenter.TipoInicio.EditarNotaCredito:
                  break;
               default:
                  break;
            }
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Detalle Facturacion ]
      public void ClearItemsDetalles()
      {
         try
         {
            if (!String.IsNullOrEmpty(Presenter.TipoDocumentoVenta))
            {
               switch (Presenter.TipoDocumentoVenta)
               {
                  case "PreFactura":
                     Presenter.ItemsPreDetDocsVta = new ObservableCollection<PreDetDocsVta>();
                     Presenter.GrillaItemsPreDetDocsVta = new ObservableCollection<PreDetDocsVta>();
                     Presenter.ItemsPreDetDocsVta_Det_Operacion = new ObservableCollection<PreDetDocsVta_Det_Operacion>();

                     break;
                  case "Factura":
                     //Presenter.ItemsDetDocsVta = new ObservableCollection<DetDocsVta>();
                     //Presenter.GrillaItemsDetDocsVta = new ObservableCollection<DetDocsVta>();
                     //Presenter.ItemsDetDocsVta_Det_Operacion = new ObservableCollection<DetDocsVta_Det_Operacion>();
                     break;
                  case "eFact":
                     //Presenter.ItemsDetDocsVta = new ObservableCollection<DetDocsVta>();
                     //Presenter.GrillaItemsDetDocsVta = new ObservableCollection<DetDocsVta>();
                     //Presenter.ItemsDetDocsVta_Det_Operacion = new ObservableCollection<DetDocsVta_Det_Operacion>();
                     break;
               }
            }

            BSItems.DataSource = null;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void ShowItemsDetalles()
      {
         try
         {
            if (!String.IsNullOrEmpty(Presenter.TipoDocumentoVenta))
            {
               switch (Presenter.TipoDocumentoVenta)
               {
                  case "PreFactura":
                     BSItems.DataSource = Presenter.GrillaItemsPreDetDocsVta;
                     break;
                  case "Factura":
                     BSItems.DataSource = Presenter.DTServicios;
                     break;
                  case "eFact":
                     BSItems.DataSource = Presenter.DTServicios;
                     break;
               }
            }
            grdItemsServicios.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            grdItemsServicios.Enabled = grdItemsServicios.RowCount > 0;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      #endregion
      #endregion

      #region [ Metodos ]
      #region [ Encabezado Facturacion ]
      private void Guardar()
      {
         try
         {
            Presenter.Entc_Codigo = AyudaENTC_Cliente.Value != null ? AyudaENTC_Cliente.Value.ENTC_Codigo : 0;
            Presenter.TIPE_Codigo = cmbTIPE_Codigo.TipoEntidadSelectedItem != null ? cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo : Convert.ToInt16(0);
            GetItemEdit();
            if (!Presenter.Guardar()) return;
            errorProvider1.Dispose();
            Close();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SavePresenter, ex); }
      }

      private void GetItemEdit()
      {
         try
         {
            Presenter.DOCV_Observaciones = txtPDOV_Observaciones.Text;
            if (txaSeries.SelectedItem != null) { Presenter.DOCV_Serie = txaSeries.SelectedItem.SERI_Serie; }

         }
         catch (Exception)
         { }
      }

      private void LoadOperacion()
      {
         Presenter.COPE_Codigo = 0;
         DataTable dt = new DataTable();
         dt = Presenter.LoadAyudaOperacion();
         if (dt != null)
         {
            if (dt.Rows.Count == 0)
            {
               Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se encontraron coincidencias.");
            }
            else if (dt.Rows.Count == 1)
            {
               Int32 COPE_Codigo;
               Presenter.COPE_Codigo = Int32.TryParse(dt.Rows[0]["COPE_Codigo"].ToString(), out COPE_Codigo) ? COPE_Codigo : 0;
            }
            else
            {
               List<ColumnaAyuda> _columnas = new List<ColumnaAyuda>();
               _columnas.Add(new ColumnaAyuda()
               {
                  Index = 0,
                  ColumnName = "COPE_NumDoc",
                  ColumnCaption = "Nro. Operación",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 150,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new ColumnaAyuda()
               {
                  Index = 1,
                  ColumnName = "COPE_FecEmi",
                  ColumnCaption = "Fecha Emisión",
                  Alineacion = DataGridViewContentAlignment.MiddleRight,
                  Width = 110,
                  DataType = typeof(DateTime),
                  Format = "dd/MM/yyyy"
               });
               _columnas.Add(new ColumnaAyuda()
               {
                  Index = 2,
                  ColumnName = "Cliente",
                  ColumnCaption = "Cliente",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 200,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new ColumnaAyuda()
               {
                  Index = 3,
                  ColumnName = "HBL",
                  ColumnCaption = "HBL",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 120,
                  DataType = typeof(String),
                  Format = null
               });
               _columnas.Add(new ColumnaAyuda()
               {
                  Index = 4,
                  ColumnName = "COPE_Codigo",
                  ColumnCaption = "Código",
                  Alineacion = DataGridViewContentAlignment.MiddleRight,
                  Width = 50,
                  DataType = typeof(Int32),
                  Format = null
               });

               Ayuda x_Ayuda = new Ayuda("Ayuda Operación", dt, false, _columnas);
               if (x_Ayuda.ShowDialog() == DialogResult.OK)
               {
                  Int32 COPE_Codigo;
                  Presenter.COPE_Codigo = Int32.TryParse(x_Ayuda.Respuesta.Rows[0]["COPE_Codigo"].ToString(), out COPE_Codigo) ? COPE_Codigo : COPE_Codigo;
               }
               else
               {
                  Presenter.COPE_Codigo = 0;
               }
            }
         }
      }
      #endregion

      #region [ Detalle Facturacion ]
      private void FormatDataGrid()
      {
         try
         {
            RadGridLocalizationProvider.CurrentProvider = new MySpanishRadGridLocalizationProvider();
            grdItemsServicios.Columns.Clear();
            grdItemsServicios.EnableHotTracking = true;
            grdItemsServicios.EnableAlternatingRowColor = false;
            grdItemsServicios.ShowFilteringRow = false;
            grdItemsServicios.ShowHeaderCellButtons = false;
            grdItemsServicios.TableElement.RowSpacing = 0;
            grdItemsServicios.TableElement.CellSpacing = 0;
            grdItemsServicios.EnableFiltering = false;
            grdItemsServicios.MasterTemplate.EnableFiltering = false;
            grdItemsServicios.AllowColumnHeaderContextMenu = false;
            grdItemsServicios.AllowCellContextMenu = false;
            grdItemsServicios.AllowAddNewRow = false;
            grdItemsServicios.AllowDeleteRow = false;
            grdItemsServicios.AllowEditRow = true;
            grdItemsServicios.AutoGenerateColumns = false;
            grdItemsServicios.AllowMultiColumnSorting = false;
            grdItemsServicios.AllowRowResize = false;
            grdItemsServicios.AllowColumnResize = true;
            grdItemsServicios.ShowGroupPanel = false;

            GridViewCheckBoxColumn chkFacturar = new GridViewCheckBoxColumn();
            chkFacturar.Name = "Agregar";
            chkFacturar.HeaderText = @"Facturar";
            chkFacturar.FieldName = "Agregar";
            grdItemsServicios.Columns.Add(chkFacturar);
            grdItemsServicios.Columns["Agregar"].Width = 50;
            grdItemsServicios.Columns["Agregar"].ReadOnly = false;

            grdItemsServicios.Columns.Add("Servicio", "Descripción", "Servicio");
            grdItemsServicios.Columns["Servicio"].Width = 590;
            grdItemsServicios.Columns["Servicio"].TextAlignment = ContentAlignment.MiddleLeft;
            grdItemsServicios.Columns["Servicio"].ReadOnly = true;

            grdItemsServicios.Columns.Add("Moneda", "Moneda", "Moneda");
            grdItemsServicios.Columns["Moneda"].Width = 150;
            grdItemsServicios.Columns["Moneda"].TextAlignment = ContentAlignment.MiddleLeft;
            grdItemsServicios.Columns["Moneda"].ReadOnly = true;
            grdItemsServicios.Columns["Moneda"].IsVisible = false;

            switch (Presenter.TInicio)
            {
               case PRO007Presenter.TipoInicio.NuevoFactura:
                  break;
               case PRO007Presenter.TipoInicio.EditarFactura:
                  break;
               case PRO007Presenter.TipoInicio.NuevoPreFactura:
               case PRO007Presenter.TipoInicio.EditarPreFactura:
                  grdItemsServicios.Columns.Add("Importe", "Valor Costo", "Importe");
                  grdItemsServicios.Columns["Importe"].Width = 100;
                  grdItemsServicios.Columns["Importe"].FormatString = @"{0:###,##0.00}";
                  grdItemsServicios.Columns["Importe"].TextAlignment = ContentAlignment.MiddleRight;
                  grdItemsServicios.Columns["Importe"].ReadOnly = true;
                  break;
               case PRO007Presenter.TipoInicio.EditarNotaCredito:
                  break;
               default:
                  break;
            }

            grdItemsServicios.Columns.Add("DDOV_ValorVenta", "Valor Venta", "DDOV_ValorVenta");
            grdItemsServicios.Columns["DDOV_ValorVenta"].Width = 100;
            grdItemsServicios.Columns["DDOV_ValorVenta"].FormatString = @"{0:###,##0.00}";
            grdItemsServicios.Columns["DDOV_ValorVenta"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsServicios.Columns["DDOV_ValorVenta"].TextAlignment = ContentAlignment.MiddleRight;
            grdItemsServicios.Columns["DDOV_ValorVenta"].ReadOnly = true;

            grdItemsServicios.Columns.Add("DDOV_Impuesto", "Impuesto", "DDOV_Impuesto1");
            grdItemsServicios.Columns["DDOV_Impuesto"].Width = 100;
            grdItemsServicios.Columns["DDOV_Impuesto"].FormatString = @"{0:###,##0.00}";
            grdItemsServicios.Columns["DDOV_Impuesto"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsServicios.Columns["DDOV_Impuesto"].TextAlignment = ContentAlignment.MiddleRight;
            grdItemsServicios.Columns["DDOV_Impuesto"].ReadOnly = true;

            grdItemsServicios.Columns.Add("DDOV_ImporteTotal", "Total Venta", "DDOV_ValorTotal");
            grdItemsServicios.Columns["DDOV_ImporteTotal"].Width = 100;
            grdItemsServicios.Columns["DDOV_ImporteTotal"].FormatString = @"{0:###,##0.00}";
            grdItemsServicios.Columns["DDOV_ImporteTotal"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsServicios.Columns["DDOV_ImporteTotal"].TextAlignment = ContentAlignment.MiddleRight;
            grdItemsServicios.Columns["DDOV_ImporteTotal"].ReadOnly = true;

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }
      private void SeleccionarItemServicio()
      {
         try
         {
            if (Presenter == null) return;
            if (!String.IsNullOrEmpty(Presenter.TipoDocumentoVenta))
            {
               switch (Presenter.TipoDocumentoVenta)
               {
                  case "PreFactura":
                     if (BSItems != null && BSItems.Current != null && BSItems.Current is PreDetDocsVta)
                     {
                        Presenter.ItemPreDetDocsVta = ((PreDetDocsVta)BSItems.Current);
                     }
                     else
                     { Presenter.ItemPreDetDocsVta = null; }
                     break;
                  case "Factura":
                     if (BSItems != null && BSItems.Current != null && BSItems.Current is DetDocsVta)
                     {
                        Presenter.ItemDetDocsVta = ((DetDocsVta)BSItems.Current);
                     }
                     else
                     { Presenter.ItemDetDocsVta = null; }
                     break;
               }
            }
         }
         catch (Exception ex)
         {
            if (Presenter != null) Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex);
         }
      }
      public void GetItemsDetalleServicios()
      {
         foreach (var item in Presenter.GrillaItemsPreDetDocsVta.Where(data => data.Agregar))
         {
             item.DDOV_ValorTotal = decimal.Parse(txtSubTotal.Text);
            //item.DDOV_Impuesto1 = (Presenter.IGV / 100) * item.DDOV_Impuesto1;
            //item.DDOV_ValorTotal = item.DDOV_ValorVenta;// Presenter.DTServicios.Select("CTAR_Tipo = 'A'").Sum(e => (Decimal)e.ItemArray[3]), //DOPE_Venta Decimal.Parse(txtSubTotal.Text);
            //item.DDOV_ValorVenta = Decimal.Parse(txtTotal.Text);
            //item.DDOV_ValorVenta = Decimal.Parse(txtTotal.Text);--comentado por JL el  06/11/2015


         }
      }
      public void Calculos()
      {
         try
         {
            Decimal ddovValorVenta = 0;
            Decimal ddovImpuesto1 = 0;
            Decimal ddovTotalaPagar = 0;
            if (!String.IsNullOrEmpty(Presenter.TipoDocumentoVenta))
            {
               switch (Presenter.TipoDocumentoVenta)
               {
                  case "PreFactura":
                     ddovValorVenta = Presenter.GrillaItemsPreDetDocsVta.Where(data => data.Agregar).Sum(item => item.DDOV_ValorVenta);
                     ddovImpuesto1 = Presenter.GrillaItemsPreDetDocsVta.Where(data => data.Agregar).Sum(item => item.DDOV_Impuesto1);
                     ddovTotalaPagar = Presenter.GrillaItemsPreDetDocsVta.Where(data => data.Agregar).Sum(item => item.DDOV_ValorTotal);
                     break;
                  case "Factura":
                     ddovValorVenta = Presenter.DTServicios != null ? Presenter.DTServicios.Select("").Sum(e => (Decimal)e.ItemArray[2]) : 0; //DDOV_ValorVenta
                      ddovImpuesto1 = Presenter.DTServicios != null ? Presenter.DTServicios.Select("Agregar=1").Sum(e => (Decimal)e.ItemArray[3]) : 0; //DDOV_Impuesto1
                     ddovTotalaPagar = Presenter.DTServicios != null ? Presenter.DTServicios.Select("Agregar=1").Sum(e => (Decimal)e.ItemArray[4]) : 0; //DDOV_ValorTotal
                     break;
                  case "eFact":
                     ddovValorVenta = Presenter.DTServicios != null ? Presenter.DTServicios.Select("Agregar=1").Sum(e => (Decimal)e.ItemArray[2]) : 0; //DDOV_ValorVenta
                      ddovImpuesto1 = Presenter.DTServicios != null ? Presenter.DTServicios.Select("Agregar=1").Sum(e => (Decimal)e.ItemArray[3]) : 0; //DDOV_Impuesto1
                     ddovTotalaPagar = Presenter.DTServicios != null ? Presenter.DTServicios.Select("Agregar=1").Sum(e => (Decimal)e.ItemArray[4]) : 0; //DDOV_ValorTotal
                     break;
               }
            }
             //Decimal ddovImpuesto1 = 0;
             //if ((bool)Presenter.DTServicios.Rows[grdItemsServicios.CurrentRow.Index]["SERV_AfeIgv"] == true)
             //{ddovImpuesto1=(Presenter.IGV / 100) * ddovValorVenta;}
           
            //Decimal ddovTotalaPagar = ddovValorVenta + ddovImpuesto1;
            txtSubTotal.Text = String.Format("{0:###,##0.00}", ddovValorVenta);
            txtIGV.Text = String.Format("{0:###,##0.00}", ddovImpuesto1);
            txtTotal.Text = String.Format("{0:###,##0.00}", ddovTotalaPagar);
            lblLetras.Text = Utilitarios.NumeroALetras(ddovTotalaPagar.ToString(CultureInfo.InvariantCulture), "");
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error la realizar los calculos.", ex); }
      }
      #endregion

      #endregion

      #region [ Eventos ]

      #region [ Encabezado Facturacion ]
      void PRO007MView_Load(object sender, EventArgs e)
      {
         TabDetalleDocVenta.SelectedTab = TabPageServicios;
      }
      void CbTIPO_CodFPG_SelectedValueChanged(object sender, EventArgs e)
      {
         try
         {
            if (CbTIPO_CodFPG.SelectedValue != null)
            {
               if (((Tipos)(CbTIPO_CodFPG.TiposSelectedItem)).TIPO_CodTipo.Equals("001"))
               {
                  DTPPDOV_FechaVcmto.NSFecha = DTPPDOV_FechaEmision.Value;

               }
               else
               {
                  double dias = 0;
                  var tipoNum1 = ((Tipos)(CbTIPO_CodFPG.SelectedItem)).TIPO_Num1;
                  if (tipoNum1 != null)
                  {
                     string cant = tipoNum1.Value.ToString(CultureInfo.InvariantCulture);
                     dias = (double)Math.Round(decimal.Parse(cant));
                  }
                  if (DTPPDOV_FechaEmision.Value != null)
                  {
                     DateTime fecha = DTPPDOV_FechaEmision.Value;
                     fecha = fecha.AddDays(dias);
                     DTPPDOV_FechaVcmto.NSFecha = fecha;
                  }
               }

            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en la fecha de vencimiento.", ex); }
      }
      
      private void btnGuardar_Click(object sender, EventArgs e)
      { Guardar(); }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            Close();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }


      private void txaSeries_SelectedItemSerieChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaSeries.SelectedItem != null)
            { Presenter.DOCV_Serie = txaSeries.SelectedItem.SERI_Serie; }
            else { Presenter.DOCV_Serie = null; }
         }
         catch (Exception)
         { }
      }

      private void txtPDOV_Observaciones_TextChanged(object sender, EventArgs e)
      {
         try
         {
            if (!String.IsNullOrEmpty(txtPDOV_Observaciones.Text))
            {
               Presenter.DOCV_Observaciones = txtPDOV_Observaciones.Text;
            }
         }
         catch (Exception)
         { }
      }

      #endregion

      #region [ Detalle Facturacion ]
      void grdItemsServicios_ValueChanged(object sender, EventArgs e)
      {
         if (!(grdItemsServicios.ActiveEditor is RadCheckBoxEditor)) return;
         grdItemsServicios.EndEdit();
         grdItemsServicios.EndUpdate();
         BSItems.EndEdit();
         if (!String.IsNullOrEmpty(Presenter.TipoDocumentoVenta))
         {
            switch (Presenter.TipoDocumentoVenta)
            {
               case "PreFactura":
                  Presenter.GrillaItemsPreDetDocsVta = (ObservableCollection<PreDetDocsVta>)BSItems.DataSource;
                  break;
               case "Factura":
                  Presenter.DTServicios = (DataTable)BSItems.DataSource;
                  break;
               case "eFact":
                  Presenter.DTServicios = (DataTable)BSItems.DataSource;
                  break;
            }
         }

         Calculos();
         Presenter.MarcarServicios();
      }
      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItemServicio(); }


      #endregion

      private void GetTipoCambio()
      {
         String Fecha = DTPPDOV_FechaEmision.Value.Year.ToString() + DTPPDOV_FechaEmision.Value.Month.ToString().PadLeft(2, '0').Trim() + DTPPDOV_FechaEmision.Value.Day.ToString().PadLeft(2, '0').Trim();
         Presenter.ValidarTipoCambio(Fecha);
         NUDPDOV_TipoCambio.Value = Presenter.TipoCambio;
      }
      private void DTPPDOV_FechaEmision_ValueChanged(object sender, EventArgs e)
      {
         GetTipoCambio();
      }
      private void PRO007MView_FormClosed(object sender, FormClosedEventArgs e)
      {
         Presenter.IsClosedMView();
      }
      private void PRO007MView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            if (Closing != true)
            {
               this.FormClosing -= PRO007MView_FormClosing;
               if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
               {
                  //if (Presenter.GuardarCambios(EsProspecto) == System.Windows.Forms.DialogResult.Cancel)
                  //{
                  //   e.Cancel = true;
                  //   this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
                  //}
                  //else
                  //{
                  Presenter.Actualizar();
                  //}
               }
               else
               { Presenter.Actualizar(); }
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }

      }
      private void cmbTIPE_Codigo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
            {
               AyudaENTC_Cliente.TipoEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo);
               AyudaENTC_Cliente.Enabled = true;
               AyudaENTC_Cliente.ClearValue();
            }
            else
            { AyudaENTC_Cliente.Enabled = false; AyudaENTC_Cliente.ClearValue(); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar un tipo de entidad.", ex); }
      }
      #endregion


   }
}


