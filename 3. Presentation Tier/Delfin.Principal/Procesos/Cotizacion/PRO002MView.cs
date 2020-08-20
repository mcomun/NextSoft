using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Delfin.Entities;
using Delfin.Principal.Properties;
using Infrastructure.Aspect.Constants;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using TiposEntidad = Delfin.Controls.TiposEntidad;

namespace Delfin.Principal
{
   public partial class PRO002MView : Form, IPRO002MView
   {
      #region [ Variables ]
      private bool Closing = false;
      #endregion

      #region [ Formulario ]
      public PRO002MView()
      {
         InitializeComponent();
         try
         {
             this.FormClosing += PRO002MView_FormClosing;
             this.FormClosed += PRO002MView_FormClosed;
             this.MaximizeBox = false;
             this.MinimizeBox = true;
             this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;

             AyudaLogistico.TipoTarifa = Delfin.Controls.TiposTarifas.TIPE_Logistico;
             AyudaAduanero.TipoTarifa = Delfin.Controls.TiposTarifas.TIPE_Aduanero;
             AyudaTransporte.TipoTarifa = Delfin.Controls.TiposTarifas.TIPE_Transportista;

            /* Encabezado Cotizacion */
            btnGuardar.Click += btnGuardar_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnSalir.Click += btnSalir_Click;
            
            btnImprimir.Click +=btnImprimir_Click;
            btnActualizar.Click += btnActualizar_Click;
            Load += PRO002MView_Load;
            chkCTAR_Logistico.CheckedChanged += chkCTAR_Logistico_CheckedChanged;
            chkCTAR_Aduanero.CheckedChanged += chkCTAR_Aduanero_CheckedChanged;
            chkCTAR_Transporte.CheckedChanged += chkCTAR_Transporte_CheckedChanged;

            AyudaLogistico.AyudaValueChanged += AyudaLogistico_AyudaValueChanged;
            AyudaAduanero.AyudaValueChanged += AyudaAduanero_AyudaValueChanged;
            AyudaTransporte.AyudaValueChanged += AyudaTransporte_AyudaValueChanged;

            /* Detalle Cotizacion */
            BSItemsLogistico = new BindingSource();
            BSItemsAduanero = new BindingSource();
            BSItemsTransporte = new BindingSource();
            BSItemsLogistico.CurrentItemChanged += BSItemsLogistico_CurrentItemChanged;
            BSItemsAduanero.CurrentItemChanged += BSItemsAduanero_CurrentItemChanged;
            BSItemsTransporte.CurrentItemChanged += BSItemsTransporte_CurrentItemChanged;
            grdItemsLogistico.CommandCellClick += grdItemsLogistico_CommandCellClick;
            grdItemsLogistico.CellFormatting += grdItemsLogistico_CellFormatting;
            grdItemsAduanero.CommandCellClick += grdItemsAduanero_CommandCellClick;
            grdItemsAduanero.CellFormatting += grdItemsAduanero_CellFormatting;
            grdItemsTransporte.CommandCellClick += grdItemsTransporte_CommandCellClick;
            grdItemsTransporte.CellFormatting += grdItemsTransporte_CellFormatting;

            /* Detalle Servicio */
            btnNuevoServicio.Click += btnNuevoServicio_Click;
            BSItemsServicios = new BindingSource();
            BSItemsServicios.CurrentItemChanged += BSItemsServicios_CurrentItemChanged;
            grdItemsServicios.CommandCellClick += grdItemsServicios_CommandCellClick;
            grdItemsServicios.CellFormatting += grdItemsServicios_CellFormatting;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }

      #endregion

      #region [ Propiedades ]
      public PRO002Presenter Presenter { get; set; }
      public BindingSource BSItemsLogistico { get; set; }
      public BindingSource BSItemsAduanero { get; set; }
      public BindingSource BSItemsTransporte { get; set; }
      public BindingSource BSItemsServicios { get; set; }
      private Hashtable HashFormulario { get; set; }
      #endregion

      #region [ IPRO002MView ]
      public void LoadView()
      {
         try
         {
            AyudaAduanero.ContainerService = Presenter.ContainerService;
            AyudaLogistico.ContainerService = Presenter.ContainerService;
            AyudaTransporte.ContainerService = Presenter.ContainerService;

            ENTC_CodigoEntidad.ContainerService = Presenter.ContainerService;

            CmbCONS_CodReg.LoadControl(Presenter.ContainerService, "Tabla Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Descending);
            CbTIPO_CodMnd.LoadControl(Presenter.ContainerService, "Tabla Moneda", "MND", "< Selecione Moneda >", ListSortDirection.Descending);
            //CmbCONS_CodEstado.LoadControl("Tabla Estado", "COT", "< Selecione Estado >", ListSortDirection.Descending);
            CmbCONS_CodEstado.DataSource = Presenter.ListConstantesEstado;
            CmbCONS_CodEstado.ValueMember = "CONS_CodTipo";
            CmbCONS_CodEstado.DisplayMember = "CONS_Desc_SPA";
            dtpCCOT_FecEmi.NSFecha = Presenter.Session.Fecha.Date;
            dtpCCOT_FecVcto.NSFecha = Presenter.Session.Fecha.Date.AddMonths(1);
            ENTC_CodigoEntidad.TipoEntidad = TiposEntidad.TIPE_Cliente;
 
            FormatDataGridLogistico();
            FormatDataGridAduanero();
            FormatDataGridTransporte();
            FormatDataGridServicos();
            txtCantidad.Text = "1";
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      #region [Encabezado Cotización ]
      public void ClearItem()
      {
          try
          {
              txtCCOT_NumDoc.Clear();
              dtpCCOT_FecEmi.NSFecha = null;
              dtpCCOT_FecVcto.NSFecha = null;
              CmbCONS_CodReg.ConstantesSelectedValue = null;
              CmbCONS_CodReg.SelectedIndex = 0;
              CbTIPO_CodMnd.SelectedIndex = 0;
              CmbCONS_CodEstado.SelectedIndex = 0;
              ENTC_CodigoEntidad.ClearValue();
              txtCCOT_Observaciones.Clear();
              dtpCCOT_FecEmi.NSFecha = Presenter.Session.Fecha.Date;
              dtpCCOT_FecVcto.NSFecha = Presenter.Session.Fecha.Date.AddMonths(1);
              chkCTAR_Logistico.Checked = false;
              chkCTAR_Aduanero.Checked = false;
              chkCTAR_Transporte.Checked = false;

              AyudaLogistico.ClearValue();
              AyudaLogistico.Enabled = false;
              AyudaAduanero.ClearValue();
              AyudaAduanero.Enabled = false;
              AyudaTransporte.ClearValue();
              AyudaTransporte.Enabled = false;

              btnImprimir.Enabled = false;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void GetItem()
      {
          try
          {
              if (dtpCCOT_FecEmi.NSFecha != null)
              {
                  Presenter.ItemCab_Cotizacion.CCOT_FecEmi = dtpCCOT_FecEmi.NSFecha.Value;
              } else { Presenter.ItemCab_Cotizacion.CCOT_FecEmi = null; }

              if (dtpCCOT_FecVcto.NSFecha != null)
              {
                  Presenter.ItemCab_Cotizacion.CCOT_FecVcto= dtpCCOT_FecVcto.NSFecha.Value;
              } else { Presenter.ItemCab_Cotizacion.CCOT_FecVcto = null; }

              if (ENTC_CodigoEntidad.Value != null)
              {
                  if (ENTC_CodigoEntidad.Value.ENTC_Codigo > 0)
                  {
                      Presenter.ItemCab_Cotizacion.ENTC_Codigo = ENTC_CodigoEntidad.Value.ENTC_Codigo;
                  }
              }

              Presenter.ItemCab_Cotizacion.CONS_CodReg = CmbCONS_CodReg.SelectedValue != null ? CmbCONS_CodReg.ConstantesSelectedValue : null;

              Presenter.ItemCab_Cotizacion.TIPO_CodMND = CbTIPO_CodMnd.SelectedValue != null ? CbTIPO_CodMnd.SelectedValue.ToString() : null;

              if (chkCTAR_Logistico.Checked && AyudaLogistico.Value != null && AyudaLogistico.Value.CTAR_Codigo > 0)
              {
                  Presenter.ItemCab_Cotizacion.ENTC_CodLogistico = AyudaLogistico.Value.CTAR_Codigo;
              } else { Presenter.ItemCab_Cotizacion.ENTC_CodLogistico = null; }

              if (chkCTAR_Aduanero.Checked && AyudaAduanero.Value != null && AyudaAduanero.Value.CTAR_Codigo > 0)
              {
                  Presenter.ItemCab_Cotizacion.ENTC_CodAduana = AyudaAduanero.Value.CTAR_Codigo;
              }
              else { Presenter.ItemCab_Cotizacion.ENTC_CodAduana = null; }

              if (chkCTAR_Transporte.Checked && AyudaTransporte.Value != null && AyudaTransporte.Value.CTAR_Codigo > 0)
              {
                  Presenter.ItemCab_Cotizacion.ENTC_CodTransporte = AyudaTransporte.Value.CTAR_Codigo;
              }
              else { Presenter.ItemCab_Cotizacion.ENTC_CodTransporte = null; }
              
              Presenter.ItemCab_Cotizacion.CCOT_Observaciones = txtCCOT_Observaciones.Text;
              Presenter.ItemCab_Cotizacion.CONS_CodEstado = CmbCONS_CodEstado.SelectedValue != null ? CmbCONS_CodEstado.SelectedValue.ToString() : null;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.GetItem, ex); }
      }
      public void SetItem()
      {
          try
          {
             btnImprimir.Enabled = true;
              txtCCOT_NumDoc.Text = Presenter.ItemCab_Cotizacion.CCOT_NumDoc;
              dtpCCOT_FecEmi.NSFecha = Presenter.ItemCab_Cotizacion.CCOT_FecEmi;
              dtpCCOT_FecVcto.NSFecha = Presenter.ItemCab_Cotizacion.CCOT_FecVcto;
              if (Presenter.ItemCab_Cotizacion.ENTC_Codigo != null)
                  ENTC_CodigoEntidad.SetValue(Presenter.ItemCab_Cotizacion.ENTC_Codigo.Value);
              CmbCONS_CodReg.ConstantesSelectedValue = Presenter.ItemCab_Cotizacion.CONS_CodReg;
              CbTIPO_CodMnd.SelectedValue = Presenter.ItemCab_Cotizacion.TIPO_CodMND;

              if (Presenter.ItemCab_Cotizacion.ENTC_CodLogistico != null)
              {
                  AyudaLogistico.SetValue(Presenter.ItemCab_Cotizacion.ENTC_CodLogistico.Value,"L", false);
                  chkCTAR_Logistico.Checked = true;
              }
              if (Presenter.ItemCab_Cotizacion.ENTC_CodAduana != null)
              {
                  AyudaAduanero.SetValue(Presenter.ItemCab_Cotizacion.ENTC_CodAduana.Value, "A", false);
                  chkCTAR_Aduanero.Checked = true;
              }
              if (Presenter.ItemCab_Cotizacion.ENTC_CodTransporte != null )
              {
                  AyudaTransporte.SetValue(Presenter.ItemCab_Cotizacion.ENTC_CodTransporte.Value, "T", false);
                  chkCTAR_Transporte.Checked =true;
              }
              txtCCOT_Observaciones.Text = Presenter.ItemCab_Cotizacion.CCOT_Observaciones;
              CmbCONS_CodEstado.SelectedValue = Presenter.ItemCab_Cotizacion.CONS_CodEstado;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetItem, ex); }
      }
      public void SetInstance(InstanceView x_instance)
      {
          try
          {
              errorProvider1.Dispose();
              CmbCONS_CodEstado.Enabled = false;
              btnBuscar.Enabled = true;
              btnGuardar.Enabled = true;
              btnNuevoServicio.Enabled = true;
              switch (x_instance)
              {
                  case InstanceView.Default:
                      break;
                  case InstanceView.New:
                      CmbCONS_CodEstado.SelectedValue = "001";
                      //HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
                      break;
                  case InstanceView.Edit:
                      if (!String.IsNullOrEmpty(Presenter.ItemCab_Cotizacion.CONS_CodEstado))
                      {
                          if (Presenter.ItemCab_Cotizacion.CONS_CodEstado.Equals("001"))
                          {
                              btnBuscar.Enabled = true;
                              btnGuardar.Enabled = true;
                              btnNuevoServicio.Enabled = true;
                          }
                          else
                          {
                              btnBuscar.Enabled = false;
                              //btnGuardar.Enabled = false;
                              btnNuevoServicio.Enabled = false;
                          }
                      }
                      //HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
                      break;
                  case InstanceView.Delete:
                      break;
                  case InstanceView.Save:
                      break;
                  default:
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
              Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.ItemCab_Cotizacion.MensajeError, Dialogos.Boton.Detalles);
              FormShowErrorProvider<Cab_Cotizacion>.Validate(Presenter.ItemCab_Cotizacion, this, errorProvider1);
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      public void FiltrosTarifas()
      {
          try
          {
              if (AyudaLogistico.Value != null)
              {
                  Presenter.CTAR_CodigoLogistico = AyudaLogistico.Value.CTAR_Codigo;
              }
              else { Presenter.CTAR_CodigoLogistico = null; }
              if (AyudaAduanero.Value != null)
              {
                  Presenter.CTAR_CodigoAduanero = AyudaAduanero.Value.CTAR_Codigo;
              }
              else { Presenter.CTAR_CodigoAduanero = null; }
              if (AyudaTransporte.Value != null)
              {
                  Presenter.CTAR_CodigoTransporte = AyudaTransporte.Value.CTAR_Codigo;
              }
              else { Presenter.CTAR_CodigoTransporte = null; }

          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }
      public void SetItemServicio(String x_CTAR_Tipo, Int32 x_CTAR_Codigo)
      {
          switch (x_CTAR_Tipo)
          {
              case "L":
                  AyudaLogistico.SetValue(x_CTAR_Codigo, x_CTAR_Tipo,false);
                  chkCTAR_Logistico.Checked = true;
                  break;
              case "A":
                  AyudaAduanero.SetValue(x_CTAR_Codigo, x_CTAR_Tipo,false);
                  chkCTAR_Aduanero.Checked = true;
                  break;
              case "T":
                  AyudaTransporte.SetValue(x_CTAR_Codigo, x_CTAR_Tipo, false);
                  chkCTAR_Transporte.Checked = true;
                  break;
          }
       }
      #endregion

      #region [ Detalle Cotización ]
      public void ShowItemsLogisticoDetalleCotizacion(Boolean Nuevo)
      {
          try
          {
             BSItemsLogistico.DataSource = Presenter.ItemsGrillaDet_Cotizacion;
             if(Presenter.ItemsGrillaDet_Cotizacion != null)
               BSItemsLogistico.DataSource = Presenter.ItemsGrillaDet_Cotizacion.Where(var => var.Instance != InstanceEntity.Deleted).ToObservableCollection();
              grdItemsLogistico.DataSource = BSItemsLogistico;
              navItemsLogistico.BindingSource = BSItemsLogistico;
              BSItemsLogistico.ResetBindings(true);
             //if(Nuevo)
             //   LimpiaTotales();
             //else
              CalculaTotalesSL();
              if (Nuevo)
              {
                  String _Cero = "0.00";
                  txtTotalCosto20.Text = _Cero;
                  txtTotalCosto40.Text = _Cero;
                  txtTotalCostoSada20.Text = _Cero;
                  txtTotalCostoSADA40.Text = _Cero;
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      public void LimpiaTotales()
      {
         String _Cero = "0.00";
         txtTotalCosto20.Text = _Cero;
         txtTotalCosto40.Text = _Cero;
         txtTotalCostoSada20.Text = _Cero;
         txtTotalCostoSADA40.Text = _Cero;
         //Venta Total
         txtVentaTotal20.Text = _Cero;
         txtVentaTotal40.Text = _Cero;
         txtVentaTotal20SEDA.Text = _Cero;
         txtVentaTotal40SEDA.Text = _Cero; 
         //Costo
         txtPrecioCosto20.Text = _Cero;
         txtPrecioCosto20SADA.Text = _Cero;
         txtPrecioCosto40.Text = _Cero;
         txtPrecioCosto40SADA.Text = _Cero;
         // Margen
         txtMargen20.Text = _Cero;
         txtMargen20SADA.Text = _Cero;
         txtMargen40.Text = _Cero;
         txtMargen40SADA.Text = _Cero;
         //Prorrateo
         txtProrrateo20.Text = _Cero;
         txtProrrateo20SADA.Text = _Cero;
         txtProrrateo40.Text = _Cero;
         txtProrrateo40SADA.Text = _Cero;
      }
      private void CalculaTotalesSL()
      {
         Decimal _TotCosto20 = 0;
         Decimal _TotCosto20SADA = 0;
         Decimal _TotCosto40 = 0;
         Decimal _TotCosto40SADA = 0;
         Decimal _TotHBL = 0;
         Decimal _TotHBLSADA = 0;
         Decimal _TotCostoHBL = 0;
         Decimal _TotCostoHBLSADA = 0;
         Decimal _TotVenta20 = 0;
         Decimal _TotVenta20SADA = 0;
         Decimal _TotVenta40 = 0;
         Decimal _TotVenta40SADA = 0;
         if (Presenter.ItemsGrillaDet_Cotizacion != null)
         {
            foreach (Det_Cotizacion Item in Presenter.ItemsGrillaDet_Cotizacion.Where(var => var.Instance != InstanceEntity.Deleted).ToObservableCollection())
            {
               _TotVenta20 += Item.DCOT_Venta20;
               _TotVenta20SADA += Item.DCOT_VentaSada20;
               _TotVenta40 += Item.DCOT_Venta40;
               _TotVenta40SADA += Item.DCOT_VentaSada40;
               _TotHBL += Item.DCOT_VentaHBL;
               _TotHBLSADA += Item.DCOT_VentaSadaHBL;
               _TotCostoHBL += Item.DCOT_CostoHBL;
               _TotCostoHBLSADA += Item.DCOT_CostoSadaHBL;
               _TotCosto20 += Item.DCOT_Costo20;
               _TotCosto20SADA += Item.DCOT_CostoSada20;
               _TotCosto40 += Item.DCOT_Costo40;
               _TotCosto40SADA += Item.DCOT_CostoSada40; 
            }
         }
         txtTotalCosto20.Text = (_TotVenta20 + (_TotVenta20==0?0:_TotHBL)).ToString();
         txtTotalCosto40.Text = (_TotVenta40 + (_TotVenta40==0?0:_TotHBL)).ToString();
         txtTotalCostoSada20.Text = (_TotVenta20SADA + (_TotVenta20SADA==0?0:_TotHBLSADA)).ToString();
         txtTotalCostoSADA40.Text = (_TotVenta40SADA + (_TotVenta40SADA==0?0:_TotHBLSADA)).ToString();
         //Venta Total
         Int32 _Cantidad;
         _Cantidad = Convert.ToInt32(txtCantidad.Text);
         txtVentaTotal20.Text = (Convert.ToDecimal(txtTotalCosto20.Text) * _Cantidad).ToString();
         txtVentaTotal40.Text = (Convert.ToDecimal(txtTotalCosto40.Text) * _Cantidad).ToString();
         txtVentaTotal20SEDA.Text = (Convert.ToDecimal(txtTotalCostoSada20.Text) * _Cantidad).ToString();
         txtVentaTotal40SEDA.Text = (Convert.ToDecimal(txtTotalCostoSADA40.Text) * _Cantidad).ToString(); 
         //Costo
         txtPrecioCosto20.Text = ((_TotCosto20 * _Cantidad) + _TotCostoHBL).ToString();
         txtPrecioCosto20SADA.Text = ((_TotCosto20SADA * _Cantidad) + _TotCostoHBLSADA).ToString();
         txtPrecioCosto40.Text = ((_TotCosto40 * _Cantidad) + _TotCostoHBL).ToString();
         txtPrecioCosto40SADA.Text = ((_TotCosto40SADA * _Cantidad) + _TotCostoHBLSADA).ToString();
         // Margen
         txtMargen20.Text = _TotVenta20 == 0? "0": (Convert.ToDecimal(txtVentaTotal20.Text) - Convert.ToDecimal(txtPrecioCosto20.Text)).ToString();
         txtMargen20SADA.Text = _TotVenta20SADA == 0 ? "0" : (Convert.ToDecimal(txtVentaTotal20SEDA.Text) - Convert.ToDecimal(txtPrecioCosto20SADA.Text)).ToString();
         txtMargen40.Text = _TotVenta40 == 0 ? "0" : (Convert.ToDecimal(txtVentaTotal40.Text) - Convert.ToDecimal(txtPrecioCosto40.Text)).ToString();
         txtMargen40SADA.Text = _TotVenta40SADA == 0 ? "0" : (Convert.ToDecimal(txtVentaTotal40SEDA.Text) - Convert.ToDecimal(txtPrecioCosto40SADA.Text)).ToString();
         //Prorrateo
         if (Convert.ToDecimal(txtVentaTotal20.Text) == 0 || Convert.ToDecimal(txtPrecioCosto20.Text) == 0)
            txtProrrateo20.Text = "0";
         else
            txtProrrateo20.Text = (Convert.ToDecimal(txtMargen20.Text) / Convert.ToDecimal(txtPrecioCosto20.Text)).ToString();
         if (Convert.ToDecimal(txtVentaTotal20SEDA.Text) == 0 || Convert.ToDecimal(txtPrecioCosto20.Text) == 0 || Convert.ToDecimal(txtPrecioCosto20SADA.Text) == 0) 
            txtProrrateo20SADA.Text = "0";
         else
            txtProrrateo20SADA.Text = (Convert.ToDecimal(txtMargen20SADA.Text) / Convert.ToDecimal(txtPrecioCosto20SADA.Text)).ToString();
         if (Convert.ToDecimal(txtPrecioCosto40.Text) == 0 || Convert.ToDecimal(txtVentaTotal40.Text) == 0)
            txtProrrateo40.Text = "0";
         else
            txtProrrateo40.Text = (Convert.ToDecimal(txtMargen40.Text) / Convert.ToDecimal(txtPrecioCosto40.Text)).ToString();
         if (Convert.ToDecimal(txtPrecioCosto40SADA.Text) == 0 || Convert.ToDecimal(txtVentaTotal40SEDA.Text) == 0)
            txtProrrateo40SADA.Text = "0";
         else
            txtProrrateo40SADA.Text = (Convert.ToDecimal(txtMargen40SADA.Text) / Convert.ToDecimal(txtPrecioCosto40SADA.Text)).ToString(); 
      }

      public void ShowItemsAduaneroDetalleCotizacion()
      {
          try
          {
              BSItemsAduanero.DataSource = Presenter.ItemsDet_CotizacionRegistros.Where(var => var.Instance != InstanceEntity.Deleted && var.CTAR_Tipo == "A").ToObservableCollection();
              grdItemsAduanero.DataSource = BSItemsAduanero;
              navItemsAduanero.BindingSource = BSItemsAduanero;
              BSItemsAduanero.ResetBindings(true);
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      public void ShowItemsTransporteDetalleCotizacion()
      {
          try
          {
              BSItemsTransporte.DataSource = Presenter.ItemsDet_CotizacionRegistros.Where(var => var.Instance != InstanceEntity.Deleted && var.CTAR_Tipo == "T").ToObservableCollection();
              grdItemsTransporte.DataSource = BSItemsTransporte;
              navItemsTransporte.BindingSource = BSItemsTransporte;
              BSItemsTransporte.ResetBindings(true);
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      public void SetItemST20_ST40_HBL( ref ObservableCollection<Det_Cotizacion> x_items)
      {
          try
          {
              if (x_items != null)
              {
                  decimal _TempVenta20 = 0;
                  decimal _TempVentaSada20 = 0;
                  decimal _TempVenta40 = 0;
                  decimal _TempVentaSada40 = 0;
                  decimal _TempCosto20 = 0;
                  decimal _TempCostoSada20 = 0;
                  decimal _TempCosto40 = 0;
                  decimal _TempCostoSada40 = 0;
                  decimal _TempCostoHBL = 0;
                  decimal _TempCostoSadaHBL = 0;
                  Det_Cotizacion _Det_Cotizacion = new Det_Cotizacion();
                  Int32 _Fila = 0;
                  for (int i = 0; i < x_items.Count; i++)
                  {
                      if (((i % 2) == 0) && i == 0)   /* primer registro */
                      {
                          _Det_Cotizacion = new Det_Cotizacion();
                          _Det_Cotizacion = x_items.ElementAt(i);
                          _Fila = 1;
                      }
                      else
                      {
                          _Det_Cotizacion = x_items.ElementAt(i);
                          _Det_Cotizacion.DCOT_Venta20 = _TempVenta20;
                          _Det_Cotizacion.DCOT_VentaSada20 = _TempVentaSada20;
                          _Det_Cotizacion.DCOT_Venta40 = _TempVenta40;
                          _Det_Cotizacion.DCOT_VentaSada40 = _TempVentaSada40;
                          _Det_Cotizacion.DCOT_Costo20 = _TempCosto20;
                          _Det_Cotizacion.DCOT_Costo40 = _TempCosto40;
                          _Det_Cotizacion.DCOT_CostoSada20 = _TempCostoSada20;
                          _Det_Cotizacion.DCOT_CostoSada40 = _TempCostoSada40;
                      }
                      if (_Det_Cotizacion.PACK_Codigo == 1)
                      {
                          _TempVenta20 = 0;
                          _TempVentaSada20 = 0;
                          _TempCosto20 = 0;
                          _TempCostoSada20 = 0;
                          _Det_Cotizacion.DCOT_Venta20 = x_items[i].DCOT_Venta;
                          _Det_Cotizacion.DCOT_VentaSada20 = _Det_Cotizacion.DCOT_VentaSada;
                          _Det_Cotizacion.DCOT_Costo20 =  x_items[i].DCOT_Costo;
                          _Det_Cotizacion.DCOT_CostoSada20 = _Det_Cotizacion.DCOT_CostoSada;
                          _TempVenta20 = _Det_Cotizacion.DCOT_Venta20;
                          _TempVentaSada20 = _Det_Cotizacion.DCOT_VentaSada20;
                         _TempCosto20 = _Det_Cotizacion.DCOT_Costo20;
                         _TempCostoSada20 = _Det_Cotizacion.DCOT_CostoSada20;
                          _Det_Cotizacion.DCOT_Fila = _Fila;
                          Presenter.ItemsDet_CotizacionRegistros.Add(_Det_Cotizacion);
                      }

                      if (_Det_Cotizacion.PACK_Codigo == 2)
                      {
                          _TempVenta40 = 0;
                          _TempVentaSada40 = 0;
                          _TempCosto40 = 0;
                          _TempCostoSada40 = 0;
                          _Det_Cotizacion.DCOT_Venta40 = x_items[i].DCOT_Venta;
                          _Det_Cotizacion.DCOT_VentaSada40 = _Det_Cotizacion.DCOT_VentaSada;
                          _Det_Cotizacion.DCOT_Costo40 = x_items[i].DCOT_Costo;
                          _Det_Cotizacion.DCOT_CostoSada40 = _Det_Cotizacion.DCOT_CostoSada;
                          _TempVenta40 = _Det_Cotizacion.DCOT_Venta40;
                          _TempVentaSada40 = _Det_Cotizacion.DCOT_VentaSada40;
                          _TempCosto40 = _Det_Cotizacion.DCOT_Costo40;
                          _TempCostoSada40 = _Det_Cotizacion.DCOT_CostoSada40;
                          if (_Det_Cotizacion.TIPE_Codigo != null && _Det_Cotizacion.TIPE_Codigo.Value.ToString(CultureInfo.InvariantCulture) != "13") /* Maritimo */
                          {
                              _Det_Cotizacion.DCOT_Fila = _Fila;
                              Presenter.ItemsDet_CotizacionRegistros.Add(_Det_Cotizacion);
                              if(Presenter.ItemsGrillaDet_Cotizacion == null)
                                 Presenter.ItemsGrillaDet_Cotizacion = new ObservableCollection<Det_Cotizacion>();
                              Presenter.ItemsGrillaDet_Cotizacion.Add(_Det_Cotizacion);
                              _Fila++;
                          }
                          else
                          {
                              _Det_Cotizacion.DCOT_Fila = _Fila;
                             Presenter.ItemsDet_CotizacionRegistros.Add(_Det_Cotizacion);
                          }
                      }
                      if (_Det_Cotizacion.TIPE_Codigo != null && _Det_Cotizacion.TIPE_Codigo.Value.ToString(CultureInfo.InvariantCulture).Equals("13")) /* Maritimo */
                      {
                          if (_Det_Cotizacion.PACK_Codigo == null)
                          {
                              _Det_Cotizacion.DCOT_VentaHBL = x_items[i].DCOT_Venta;
                              _Det_Cotizacion.DCOT_VentaSadaHBL = _Det_Cotizacion.DCOT_VentaSada;
                              _Det_Cotizacion.DCOT_CostoHBL = x_items[i].DCOT_Costo;
                              _Det_Cotizacion.DCOT_CostoSadaHBL = x_items[i].DCOT_CostoSada;
                              if (Presenter.ItemsGrillaDet_Cotizacion == null)
                                 Presenter.ItemsGrillaDet_Cotizacion = new ObservableCollection<Det_Cotizacion>();
                              _Det_Cotizacion.DCOT_Fila = _Fila;
                              Presenter.ItemsDet_CotizacionRegistros.Add(_Det_Cotizacion);
                              Presenter.ItemsGrillaDet_Cotizacion.Add(_Det_Cotizacion);
                              _Fila++;
                          }
                      }
                  }
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar el nuevo registro.", ex); }
      }
      public void ClearItemsDetallesCotizacion()
      {
          try
          {
              BSItemsLogistico.DataSource = null;
              grdItemsLogistico.DataSource = null;
              navItemsLogistico.BindingSource = null;

              BSItemsTransporte.DataSource = null;
              grdItemsTransporte.DataSource = null;
              navItemsTransporte.BindingSource = null;

              BSItemsAduanero.DataSource = null;
              grdItemsAduanero.DataSource = null;
              navItemsAduanero.BindingSource = null;

              Presenter.ItemsDet_Tarifa = new ObservableCollection<Det_Tarifa>();
              Presenter.ItemsDet_CotizacionLogistico = new ObservableCollection<Det_Cotizacion>();
              Presenter.ItemsDet_CotizacionAduanero = new ObservableCollection<Det_Cotizacion>();
              Presenter.ItemsDet_CotizacionTransporte = new ObservableCollection<Det_Cotizacion>();
              Presenter.ItemsDet_Cotizacion = new ObservableCollection<Det_Cotizacion>();
              Presenter.ItemsDet_CotizacionRegistros = new ObservableCollection<Det_Cotizacion>();
              Presenter.ItemsGrillaDet_Cotizacion = new ObservableCollection<Det_Cotizacion>();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      #endregion

      #region [ Detalle Servicios ]
      public void ClearItemsDetalleServicios()
      {
          try
          {
              BSItemsServicios.DataSource = null;
              grdItemsServicios.DataSource = null;
              navItemsServicios.BindingSource = null;
              Presenter.ItemsDet_CotizacionServicio = new ObservableCollection<Det_Cotizacion_Servicio>();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void ShowItemsDetalleServicios()
      {
          try
          {
              BSItemsServicios.DataSource = Presenter.ItemsDet_CotizacionServicio.Where(var => var.Instance != InstanceEntity.Deleted).ToObservableCollection();
              grdItemsServicios.DataSource = BSItemsServicios;
              navItemsServicios.BindingSource = BSItemsServicios;
              BSItemsServicios.ResetBindings(true);
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      #endregion

      #endregion

      #region [ Metodos ]

      #region [ Encabezado ]

      private void Guardar()
      {
          try
          {
              if (Presenter.GuardarCotizacion())
              {
                  errorProvider1.Dispose();
                  Close();
              }
          }
          catch (Exception)
          { }
      }
      #endregion

      #region [ Detalle ]
      private void FormatDataGridLogistico()
      {
          try
          {
              RadGridLocalizationProvider.CurrentProvider = new MySpanishRadGridLocalizationProvider();
              grdItemsLogistico.Columns.Clear();
              grdItemsLogistico.EnableHotTracking = true;
              grdItemsLogistico.EnableAlternatingRowColor = false;
              grdItemsLogistico.ShowFilteringRow = false;
              grdItemsLogistico.ShowHeaderCellButtons = false;
              grdItemsLogistico.TableElement.RowSpacing = 0;
              grdItemsLogistico.TableElement.CellSpacing = 0;
              grdItemsLogistico.EnableFiltering = false;
              grdItemsLogistico.MasterTemplate.EnableFiltering = false;
              grdItemsLogistico.AllowColumnHeaderContextMenu = false;
              grdItemsLogistico.AllowCellContextMenu = false;
              grdItemsLogistico.AllowAddNewRow = false;
              grdItemsLogistico.AllowDeleteRow = false;
              grdItemsLogistico.AllowEditRow = false;
              grdItemsLogistico.AutoGenerateColumns = false;
              grdItemsLogistico.AllowMultiColumnSorting = false;
              grdItemsLogistico.AllowRowResize = false;
              grdItemsLogistico.AllowColumnResize = true;
              grdItemsLogistico.ShowGroupPanel = false;

              GridViewCommandColumn commandEditar;
              commandEditar = new GridViewCommandColumn();
              commandEditar.Name = "Edit";
              commandEditar.HeaderText = @"Editar";
              commandEditar.DefaultText = @"Editar";
              commandEditar.UseDefaultText = true;
              grdItemsLogistico.Columns.Add(commandEditar);
              grdItemsLogistico.Columns["Edit"].AllowSort = false;
              grdItemsLogistico.Columns["Edit"].AllowFiltering = false;

              GridViewCommandColumn commandDeleteColumn;
              commandDeleteColumn = new GridViewCommandColumn();
              commandDeleteColumn.Name = "Delete";
              commandDeleteColumn.HeaderText = @"Eliminar";
              commandDeleteColumn.DefaultText = @"Eliminar";
              commandDeleteColumn.UseDefaultText = true;
              grdItemsLogistico.Columns.Add(commandDeleteColumn);
              grdItemsLogistico.Columns["Delete"].AllowSort = false;
              grdItemsLogistico.Columns["Delete"].AllowFiltering = false;

              grdItemsLogistico.Columns.Add("TIPE_Descripcion", "Servicio", "TIPE_Descripcion");
              grdItemsLogistico.Columns["TIPE_Descripcion"].Width = 120;
              
              grdItemsLogistico.Columns.Add("ENTC_RazonSocial", "Entidad", "ENTC_RazonSocial");
              grdItemsLogistico.Columns["ENTC_RazonSocial"].Width = 200;
              
              grdItemsLogistico.Columns.Add("DCOT_Venta20", "Venta", "DCOT_Venta20");
              grdItemsLogistico.Columns["DCOT_Venta20"].Width = 70;
              grdItemsLogistico.Columns["DCOT_Venta20"].FormatString = @"{0:###,##0.00}";
              grdItemsLogistico.Columns["DCOT_Venta20"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItemsLogistico.Columns["DCOT_Venta20"].TextAlignment = ContentAlignment.MiddleRight;
              
              grdItemsLogistico.Columns.Add("DCOT_VentaSada20", "Venta Sada", "DCOT_VentaSada20");
              grdItemsLogistico.Columns["DCOT_VentaSada20"].Width = 70;
              grdItemsLogistico.Columns["DCOT_VentaSada20"].FormatString = @"{0:###,##0.00}";
              grdItemsLogistico.Columns["DCOT_VentaSada20"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItemsLogistico.Columns["DCOT_VentaSada20"].TextAlignment = ContentAlignment.MiddleRight;
              
              grdItemsLogistico.Columns.Add("DCOT_Venta40", "Venta", "DCOT_Venta40");
              grdItemsLogistico.Columns["DCOT_Venta40"].Width = 70;
              grdItemsLogistico.Columns["DCOT_Venta40"].FormatString = @"{0:###,##0.00}";
              grdItemsLogistico.Columns["DCOT_Venta40"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItemsLogistico.Columns["DCOT_Venta40"].TextAlignment = ContentAlignment.MiddleRight;
              
              grdItemsLogistico.Columns.Add("DCOT_VentaSada40", "Venta Sada", "DCOT_VentaSada40");
              grdItemsLogistico.Columns["DCOT_VentaSada40"].Width = 70;
              grdItemsLogistico.Columns["DCOT_VentaSada40"].FormatString = @"{0:###,##0.00}";
              grdItemsLogistico.Columns["DCOT_VentaSada40"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItemsLogistico.Columns["DCOT_VentaSada40"].TextAlignment = ContentAlignment.MiddleRight;
              
              grdItemsLogistico.Columns.Add("DCOT_VentaHBL", "HBL", "DCOT_VentaHBL");
              grdItemsLogistico.Columns["DCOT_VentaHBL"].Width = 70;
              grdItemsLogistico.Columns["DCOT_VentaHBL"].FormatString = @"{0:###,##0.00}";
              grdItemsLogistico.Columns["DCOT_VentaHBL"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItemsLogistico.Columns["DCOT_VentaHBL"].TextAlignment = ContentAlignment.MiddleRight;
              
              grdItemsLogistico.Columns.Add("DCOT_VentaSadaHBL", "HBL Sada", "DCOT_VentaSadaHBL");
              grdItemsLogistico.Columns["DCOT_VentaSadaHBL"].Width = 70;
              grdItemsLogistico.Columns["DCOT_VentaSadaHBL"].FormatString = @"{0:###,##0.00}";
              grdItemsLogistico.Columns["DCOT_VentaSadaHBL"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItemsLogistico.Columns["DCOT_VentaSadaHBL"].TextAlignment = ContentAlignment.MiddleRight;

              

              ColumnGroupsViewDefinition columnGroupsView = new ColumnGroupsViewDefinition();
              columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Acciones"));
              columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Datos Generales"));
              columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Standar 20"));
              columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Standar 40"));
              columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("HBL"));
              

              columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
              columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grdItemsLogistico.Columns["Edit"]);
              columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grdItemsLogistico.Columns["Delete"]);

              columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
              columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grdItemsLogistico.Columns["TIPE_Descripcion"]);
              columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grdItemsLogistico.Columns["ENTC_RazonSocial"]);


              columnGroupsView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
              columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItemsLogistico.Columns["DCOT_Venta20"]);
              columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItemsLogistico.Columns["DCOT_VentaSada20"]);

              columnGroupsView.ColumnGroups[3].Rows.Add(new GridViewColumnGroupRow());
              columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(grdItemsLogistico.Columns["DCOT_Venta40"]);
              columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(grdItemsLogistico.Columns["DCOT_VentaSada40"]);

              columnGroupsView.ColumnGroups[4].Rows.Add(new GridViewColumnGroupRow());
              columnGroupsView.ColumnGroups[4].Rows[0].Columns.Add(grdItemsLogistico.Columns["DCOT_VentaHBL"]);
              columnGroupsView.ColumnGroups[4].Rows[0].Columns.Add(grdItemsLogistico.Columns["DCOT_VentaSadaHBL"]);

              grdItemsLogistico.ViewDefinition = columnGroupsView;
             
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }
      private void FormatDataGridAduanero()
      {
          try
          {
              RadGridLocalizationProvider.CurrentProvider = new MySpanishRadGridLocalizationProvider();
              grdItemsAduanero.Columns.Clear();
              grdItemsAduanero.EnableHotTracking = true;
              grdItemsAduanero.EnableAlternatingRowColor = false;
              grdItemsAduanero.ShowFilteringRow = false;
              grdItemsAduanero.ShowHeaderCellButtons = false;
              grdItemsAduanero.TableElement.RowSpacing = 0;
              grdItemsAduanero.TableElement.CellSpacing = 0;
              grdItemsAduanero.EnableFiltering = false;
              grdItemsAduanero.MasterTemplate.EnableFiltering = false;
              grdItemsAduanero.AllowColumnHeaderContextMenu = false;
              grdItemsAduanero.AllowCellContextMenu = false;
              grdItemsAduanero.AllowAddNewRow = false;
              grdItemsAduanero.AllowDeleteRow = false;
              grdItemsAduanero.AllowEditRow = false;
              grdItemsAduanero.AutoGenerateColumns = false;
              grdItemsAduanero.AllowMultiColumnSorting = false;
              grdItemsAduanero.AllowRowResize = false;
              grdItemsAduanero.AllowColumnResize = true;
              grdItemsAduanero.ShowGroupPanel = false;

              GridViewCommandColumn commandEditar;
              commandEditar = new GridViewCommandColumn();
              commandEditar.Name = "Edit";
              commandEditar.HeaderText = @"Editar";
              commandEditar.DefaultText = @"Editar";
              commandEditar.UseDefaultText = true;
              grdItemsAduanero.Columns.Add(commandEditar);
              grdItemsAduanero.Columns["Edit"].AllowSort = false;
              grdItemsAduanero.Columns["Edit"].AllowFiltering = false;
              

              GridViewCommandColumn commandDeleteColumn;
              commandDeleteColumn = new GridViewCommandColumn();
              commandDeleteColumn.Name = "Delete";
              commandDeleteColumn.HeaderText = @"Eliminar";
              commandDeleteColumn.DefaultText = @"Eliminar";
              commandDeleteColumn.UseDefaultText = true;
              grdItemsAduanero.Columns.Add(commandDeleteColumn);
              grdItemsAduanero.Columns["Delete"].AllowSort = false;
              grdItemsAduanero.Columns["Delete"].AllowFiltering = false;

              grdItemsAduanero.Columns.Add("CONS_Desc_SPA", "Base", "CONS_Desc_SPA");
              grdItemsAduanero.Columns["CONS_Desc_SPA"].Width = 300;

              grdItemsAduanero.Columns.Add("DCOT_Venta", "Valor", "DCOT_Venta");
              grdItemsAduanero.Columns["DCOT_Venta"].Width = 70;
              grdItemsAduanero.Columns["DCOT_Venta"].FormatString = @"{0:###,##0.00}";
              grdItemsAduanero.Columns["DCOT_Venta"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItemsAduanero.Columns["DCOT_Venta"].TextAlignment = ContentAlignment.MiddleRight;

              grdItemsAduanero.Columns.Add("DCOT_Minimo", "Minimo", "DCOT_Minimo");
              grdItemsAduanero.Columns["DCOT_Minimo"].Width = 70;
              grdItemsAduanero.Columns["DCOT_Minimo"].FormatString = @"{0:###,##0.00}";
              grdItemsAduanero.Columns["DCOT_Minimo"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItemsAduanero.Columns["DCOT_Minimo"].TextAlignment = ContentAlignment.MiddleRight;

          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }
      private void FormatDataGridTransporte()
      {
          try
          {
              RadGridLocalizationProvider.CurrentProvider = new MySpanishRadGridLocalizationProvider();
              grdItemsTransporte.Columns.Clear();
              grdItemsTransporte.EnableHotTracking = true;
              grdItemsTransporte.EnableAlternatingRowColor = false;
              grdItemsTransporte.ShowFilteringRow = false;
              grdItemsTransporte.ShowHeaderCellButtons = false;
              grdItemsTransporte.TableElement.RowSpacing = 0;
              grdItemsTransporte.TableElement.CellSpacing = 0;
              grdItemsTransporte.EnableFiltering = false;
              grdItemsTransporte.MasterTemplate.EnableFiltering = false;
              grdItemsTransporte.AllowColumnHeaderContextMenu = false;
              grdItemsTransporte.AllowCellContextMenu = false;
              grdItemsTransporte.AllowAddNewRow = false;
              grdItemsTransporte.AllowDeleteRow = false;
              grdItemsTransporte.AllowEditRow = false;
              grdItemsTransporte.AutoGenerateColumns = false;
              grdItemsTransporte.AllowMultiColumnSorting = false;
              grdItemsTransporte.AllowRowResize = false;
              grdItemsTransporte.AllowColumnResize = true;
              grdItemsTransporte.ShowGroupPanel = false;

              GridViewCommandColumn commandEditar;
              commandEditar = new GridViewCommandColumn();
              commandEditar.Name = "Edit";
              commandEditar.HeaderText = @"Editar";
              commandEditar.DefaultText = @"Editar";
              commandEditar.UseDefaultText = true;
              grdItemsTransporte.Columns.Add(commandEditar);
              grdItemsTransporte.Columns["Edit"].AllowSort = false;
              grdItemsTransporte.Columns["Edit"].AllowFiltering = false;

              GridViewCommandColumn commandDeleteColumn;
              commandDeleteColumn = new GridViewCommandColumn();
              commandDeleteColumn.Name = "Delete";
              commandDeleteColumn.HeaderText = @"Eliminar";
              commandDeleteColumn.DefaultText = @"Eliminar";
              commandDeleteColumn.UseDefaultText = true;
              grdItemsTransporte.Columns.Add(commandDeleteColumn);
              grdItemsTransporte.Columns["Delete"].AllowSort = false;
              grdItemsTransporte.Columns["Delete"].AllowFiltering = false;

              grdItemsTransporte.Columns.Add("CONS_Desc_TRA", "Tipo", "CONS_Desc_TRA");
              grdItemsTransporte.Columns["CONS_Desc_TRA"].Width = 120;
              
              grdItemsTransporte.Columns.Add("DCOT_Venta", "Flete", "DCOT_Venta");
              grdItemsTransporte.Columns["DCOT_Venta"].Width = 70;
              grdItemsTransporte.Columns["DCOT_Venta"].FormatString = @"{0:###,##0.00}";
              grdItemsTransporte.Columns["DCOT_Venta"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItemsTransporte.Columns["DCOT_Venta"].TextAlignment = ContentAlignment.MiddleRight;
              
              grdItemsTransporte.Columns.Add("CONS_Desc_SPA", "Base", "CONS_Desc_SPA");
              grdItemsTransporte.Columns["CONS_Desc_SPA"].Width = 120;
              
              grdItemsTransporte.Columns.Add("ORIGEN", "Origen", "ORIGEN");
              grdItemsTransporte.Columns["ORIGEN"].Width = 150;
              
              grdItemsTransporte.Columns.Add("DESTINO", "Destino", "DESTINO");
              grdItemsTransporte.Columns["DESTINO"].Width = 150;

              GridViewCheckBoxColumn DCOT_Roudtrip = new GridViewCheckBoxColumn();
              DCOT_Roudtrip.Name = "DCOT_Roudtrip";
              DCOT_Roudtrip.HeaderText = "Roundtrip";
              DCOT_Roudtrip.FieldName = "DCOT_Roudtrip";
              grdItemsTransporte.Columns.Add(DCOT_Roudtrip);
              grdItemsTransporte.Columns["DCOT_Roudtrip"].Width = 50;
              grdItemsTransporte.Columns["DCOT_Roudtrip"].ReadOnly = false;    

          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }
      private void SeleccionarItemLogsitico()
      {
          try
          {
              if (Presenter != null)
              {
                if (BSItemsLogistico != null && BSItemsLogistico.Current != null && BSItemsLogistico.Current is Det_Cotizacion)
                {
                    Presenter.ItemDet_Cotizacion = ((Det_Cotizacion)BSItemsLogistico.Current);
                    if (Presenter.ItemDet_Cotizacion.DTAR_Item > 0)
                    {
                        //Presenter.ItemDet_Cotizacion.AUDI_UsrMod = Presenter.Session.UserName;
                        //Presenter.ItemDet_Cotizacion.AUDI_FecMod = Presenter.Session.Fecha;
                        //Presenter.ItemDet_Cotizacion.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                    }
                } else { Presenter.ItemDet_Cotizacion = null; }   
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }
      private void SeleccionarItemAduanero()
      {
          try
          {
              if (Presenter != null)
              {
                  if (BSItemsAduanero != null && BSItemsAduanero.Current != null && BSItemsAduanero.Current is Det_Cotizacion)
                  {
                      Presenter.ItemDet_Cotizacion = ((Det_Cotizacion)BSItemsAduanero.Current);
                      if (Presenter.ItemDet_Cotizacion.DTAR_Item > 0)
                      {
                          //Presenter.ItemDet_Cotizacion.AUDI_UsrMod = Presenter.Session.UserName;
                          //Presenter.ItemDet_Cotizacion.AUDI_FecMod = Presenter.Session.Fecha;
                          //Presenter.ItemDet_Cotizacion.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                      }
                  }
                  else { Presenter.ItemDet_Cotizacion = null; }
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }
      private void SeleccionarItemTransporte()
      {
          try
          {
              if (Presenter != null)
              {
                  if (BSItemsTransporte != null && BSItemsTransporte.Current != null && BSItemsTransporte.Current is Det_Cotizacion)
                  {
                      Presenter.ItemDet_Cotizacion = ((Det_Cotizacion)BSItemsTransporte.Current);
                      if (Presenter.ItemDet_Cotizacion.DTAR_Item > 0)
                      {
                          //Presenter.ItemDet_Cotizacion.AUDI_UsrMod = Presenter.Session.UserName;
                          //Presenter.ItemDet_Cotizacion.AUDI_FecMod = Presenter.Session.Fecha;
                          //Presenter.ItemDet_Cotizacion.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                      }
                  }
                  else { Presenter.ItemDet_Cotizacion = null; }
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }
      
      #endregion

      #region [ Servicios ]
      private void FormatDataGridServicos()
      {
          try
          {
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
              grdItemsServicios.AllowEditRow = false;
              grdItemsServicios.AutoGenerateColumns = false;
              grdItemsServicios.AllowMultiColumnSorting = false;
              grdItemsServicios.AllowRowResize = false;
              grdItemsServicios.AllowColumnResize = true;
              grdItemsServicios.ShowGroupPanel = false;

              GridViewCommandColumn commandEditar;
              commandEditar = new GridViewCommandColumn();
              commandEditar.Name = "Edit";
              commandEditar.HeaderText = @"Editar";
              commandEditar.DefaultText = @"Editar";
              commandEditar.UseDefaultText = true;
              grdItemsServicios.Columns.Add(commandEditar);
              grdItemsServicios.Columns["Edit"].AllowSort = false;
              grdItemsServicios.Columns["Edit"].AllowFiltering = false;

              GridViewCommandColumn commandDeleteColumn;
              commandDeleteColumn = new GridViewCommandColumn();
              commandDeleteColumn.Name = "Delete";
              commandDeleteColumn.HeaderText = @"Eliminar";
              commandDeleteColumn.DefaultText = @"Eliminar";
              commandDeleteColumn.UseDefaultText = true;
              grdItemsServicios.Columns.Add(commandDeleteColumn);
              grdItemsServicios.Columns["Delete"].AllowSort = false;
              grdItemsServicios.Columns["Delete"].AllowFiltering = false;

              grdItemsServicios.Columns.Add("CONS_Desc_TMC", "Ingreso", "CONS_Desc_TMC");
              grdItemsServicios.Columns["CONS_Desc_TMC"].Width = 70;

              grdItemsServicios.Columns.Add("CONS_Desc_Servicio", "Servicio", "CONS_Desc_Servicio");
              grdItemsServicios.Columns["CONS_Desc_Servicio"].Width = 170;

              grdItemsServicios.Columns.Add("Proveedor", "Proveedor", "Proveedor");
              grdItemsServicios.Columns["Proveedor"].Width = 200;

              grdItemsServicios.Columns.Add("SCOT_Cantidad", "Cantidad", "SCOT_Cantidad");
              grdItemsServicios.Columns["SCOT_Cantidad"].Width = 70;
              grdItemsServicios.Columns["SCOT_Cantidad"].FormatString = @"{0:###,##0.00}";
              grdItemsServicios.Columns["SCOT_Cantidad"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItemsServicios.Columns["SCOT_Cantidad"].TextAlignment = ContentAlignment.MiddleRight;

              grdItemsServicios.Columns.Add("SCOT_PrecioUni", "Precio Unit.", "SCOT_PrecioUni");
              grdItemsServicios.Columns["SCOT_PrecioUni"].Width = 80;
              grdItemsServicios.Columns["SCOT_PrecioUni"].FormatString = @"{0:###,##0.00}";
              grdItemsServicios.Columns["SCOT_PrecioUni"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItemsServicios.Columns["SCOT_PrecioUni"].TextAlignment = ContentAlignment.MiddleRight;

              grdItemsServicios.Columns.Add("CONS_Desc_Moneda", "Moneda", "CONS_Desc_Moneda");
              grdItemsServicios.Columns["CONS_Desc_Moneda"].Width = 60;

              grdItemsServicios.Columns.Add("CONS_Desc_Base", "Base", "CONS_Desc_Base");
              grdItemsServicios.Columns["CONS_Desc_Base"].Width = 80;

              grdItemsServicios.Columns.Add("SCOT_ImporteIngreso", "Ingreso", "SCOT_ImporteIngreso");
              grdItemsServicios.Columns["SCOT_ImporteIngreso"].Width = 70;
              grdItemsServicios.Columns["SCOT_ImporteIngreso"].FormatString = @"{0:###,##0.00}";
              grdItemsServicios.Columns["SCOT_ImporteIngreso"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItemsServicios.Columns["SCOT_ImporteIngreso"].TextAlignment = ContentAlignment.MiddleRight;

              grdItemsServicios.Columns.Add("SCOT_ImporteEgreso", "Egreso", "SCOT_ImporteEgreso");
              grdItemsServicios.Columns["SCOT_ImporteEgreso"].Width = 70;
              grdItemsServicios.Columns["SCOT_ImporteEgreso"].FormatString = @"{0:###,##0.00}";
              grdItemsServicios.Columns["SCOT_ImporteEgreso"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItemsServicios.Columns["SCOT_ImporteEgreso"].TextAlignment = ContentAlignment.MiddleRight;

          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }
      private void SeleccionarItemServicios()
      {
          try
          {
              if (Presenter != null)
              {
                  if (BSItemsServicios != null && BSItemsServicios.Current != null && BSItemsServicios.Current is Det_Cotizacion_Servicio)
                  {
                      Presenter.ItemDet_CotizacionServicio = ((Det_Cotizacion_Servicio)BSItemsServicios.Current);
                      if (Presenter.ItemDet_CotizacionServicio.SCOT_Item > 0)
                      {
                          Presenter.ItemDet_CotizacionServicio.AUDI_UsrMod = Presenter.Session.UserName;
                          Presenter.ItemDet_CotizacionServicio.AUDI_FecMod = Presenter.Session.Fecha;
                          Presenter.ItemDet_CotizacionServicio.Instance = InstanceEntity.Modified;
                      }
                  }
                  else
                  { Presenter.ItemDet_CotizacionServicio = null; }
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }
      #endregion

      #endregion

      #region [ Eventos ]

      #region [ Encabezado Tarifario ]
      private void btnGuardar_Click(object sender, EventArgs e)
      { Guardar(); }

      void btnBuscar_Click(object sender, EventArgs e)
      {
          try
          {
             Presenter.BuscarTarifarios(false, chkCTAR_Logistico.Checked ? 1 : 0, chkCTAR_Aduanero.Checked ? 5 : 0, null);
          }
          catch (Exception) { }
      }

      void btnActualizar_Click(object sender, EventArgs e)
      {
         try
         {
            Decimal TotalVenta20= 0;
            Decimal TotalVenta20SADA = 0;
            Decimal TotalVenta40 = 0;
            Decimal TotalVenta40SADA = 0;
            Decimal TotalHBL = 0;
            Decimal TotalHBLSADA = 0;
            Decimal _Porcentaje = 0;

            Decimal _TotalValidaVenta20 = 0;
            Decimal _TotalValidaVentaSADA20 = 0;
            Decimal _TotalValidaVenta40 = 0;
            Decimal _TotalValidaSADA40 = 0;

            foreach (Det_Cotizacion Item in Presenter.ItemsGrillaDet_Cotizacion)
            {
               TotalVenta20 += Item.DCOT_Venta20;
               TotalVenta40 += Item.DCOT_Venta40;  
               TotalVenta40SADA += Item.DCOT_VentaSada40;
               TotalVenta20SADA += Item.DCOT_VentaSada20;   
               TotalHBL += Item.DCOT_VentaHBL;
               TotalHBLSADA += Item.DCOT_VentaSadaHBL; 
            }


            foreach (Det_Cotizacion Item in Presenter.ItemsGrillaDet_Cotizacion)
            {
               if (Item.DCOT_Venta20 == 0 || Decimal.Parse(txtTotalCosto20.Text) == 0)
               { _Porcentaje = 0;
               }else
               {
               _Porcentaje = Convert.ToDecimal(String.Format(@"{0:###,##0.00}",  ((Item.DCOT_Venta20 * 100) / TotalVenta20).ToString()));
               }
               Item.DCOT_Venta20 = Decimal.Round (Convert.ToDecimal(Convert.ToDecimal(txtTotalCosto20.Text) - TotalHBL) * (_Porcentaje / 100),2);
               _TotalValidaVenta20 += Item.DCOT_Venta20;
               if (Item.DCOT_VentaSada20 == 0 || Decimal.Parse(txtTotalCostoSada20.Text) == 0)
               {
                  _Porcentaje = 0;
               }
               else
               {
                  _Porcentaje = (Item.DCOT_VentaSada20 * 100) / TotalVenta20SADA;
               }
               Item.DCOT_VentaSada20 = Decimal.Round ( Convert.ToDecimal(Convert.ToDecimal(txtTotalCostoSada20.Text) - TotalHBLSADA) * (_Porcentaje / 100),2);
               _TotalValidaVentaSADA20 += Item.DCOT_VentaSada20;
               if (Item.DCOT_Venta40 == 0 || Decimal.Parse(txtTotalCosto40.Text) == 0)
               {
                  _Porcentaje = 0;
               }
               else
               {
               _Porcentaje = (Item.DCOT_Venta40 * 100) / TotalVenta40;
               }
               Item.DCOT_Venta40 = Decimal.Round (Convert.ToDecimal(Convert.ToDecimal(txtTotalCosto40.Text) - TotalHBL) * (_Porcentaje / 100),2);
               _TotalValidaVenta40 += Item.DCOT_Venta40;
               if (Item.DCOT_VentaSada40 == 0 || Decimal.Parse(txtTotalCostoSADA40.Text) == 0)
               {
                  _Porcentaje = 0;
               }
               else
               {
                  _Porcentaje = (Item.DCOT_VentaSada40 * 100) / TotalVenta40SADA;
               }
               Item.DCOT_VentaSada40 = Decimal.Round ( (Convert.ToDecimal(txtTotalCostoSADA40.Text) - TotalHBLSADA) * (_Porcentaje / 100),2);
               _TotalValidaSADA40 += Item.DCOT_VentaSada40;
            }

            Int16 _Cantidad20 = 0;
            Int16 _Cantidad40 = 0;
            foreach (Det_Cotizacion Item in Presenter.ItemsDet_CotizacionRegistros.Where(tipo => tipo.CTAR_Tipo == "L" && tipo.PACK_Codigo != null && tipo.Instance != InstanceEntity.Deleted))
            {
               switch (Item.PACK_Codigo)
               {
                  case 1:
                     if(Item.Instance != InstanceEntity.Added )
                        Item.Instance = InstanceEntity.Modified;
                     if (TotalVenta20 == 0)
                     {
                        _Porcentaje = 0;
                        Item.DCOT_Venta = 0;
                     }
                     else
                     {
                        _Porcentaje =  (Item.DCOT_Venta * 100) / TotalVenta20;
                        Item.DCOT_Venta = Decimal.Round( Convert.ToDecimal(Convert.ToDecimal(txtTotalCosto20.Text) - (Convert.ToDecimal(txtTotalCosto20.Text)==0?0:TotalHBL)) * (_Porcentaje / 100),2);
                     }
                     if (TotalVenta20SADA == 0)
                     {
                        _Porcentaje = 0;
                        Item.DCOT_VentaSada = 0;
                     }
                     else
                     {
                        _Porcentaje = (Item.DCOT_VentaSada * 100) / TotalVenta20SADA;
                        Item.DCOT_VentaSada = Decimal.Round (Convert.ToDecimal(Convert.ToDecimal(txtTotalCostoSada20.Text) - (Convert.ToDecimal(txtTotalCostoSada20.Text)==0?0: TotalHBLSADA)) * (_Porcentaje / 100),2);
                     }
                     _Cantidad20++;
                     if (_Cantidad20 == Presenter.ItemsGrillaDet_Cotizacion.Count)
                     {
                        if (_TotalValidaVenta20 != (Convert.ToDecimal(txtTotalCosto20.Text) - (Convert.ToDecimal(txtTotalCosto20.Text) ==0?0:TotalHBL)))
                        {
                           if (_TotalValidaVenta20 < (Convert.ToDecimal(txtTotalCosto20.Text) - TotalHBL))
                           {
                              Item.DCOT_Venta = Item.DCOT_Venta + ((Convert.ToDecimal(txtTotalCosto20.Text) - (Convert.ToDecimal(txtTotalCosto20.Text)==0?0: TotalHBL)) - _TotalValidaVenta20);
                           }
                           else
                           {
                              Item.DCOT_Venta = Item.DCOT_Venta - (_TotalValidaVenta20 - (Convert.ToDecimal(txtTotalCosto20.Text) - (Convert.ToDecimal(txtTotalCosto20.Text)==0?0:TotalHBL)));
                           }
                        }
                        if (_TotalValidaVentaSADA20 != (Convert.ToDecimal(txtTotalCostoSada20.Text) - (Convert.ToDecimal(txtTotalCostoSada20.Text) == 0 ? 0 : TotalHBLSADA)))
                        {
                           if (_TotalValidaVentaSADA20 < (Convert.ToDecimal(txtTotalCostoSada20.Text) - TotalHBLSADA))
                           {
                              Item.DCOT_VentaSada = Item.DCOT_VentaSada + ((Convert.ToDecimal(txtTotalCostoSada20.Text) - (Convert.ToDecimal(txtTotalCostoSada20.Text) == 0 ? 0 : TotalHBLSADA)) - _TotalValidaVentaSADA20);
                           }
                           else
                           {
                              Item.DCOT_VentaSada = Item.DCOT_VentaSada - (_TotalValidaVentaSADA20 - (Convert.ToDecimal(txtTotalCostoSada20.Text) - (Convert.ToDecimal(txtTotalCostoSada20.Text) == 0 ? 0 : TotalHBLSADA)));
                           }
                        }

                     }
                     break;
                  case 2:
                     if (Item.Instance != InstanceEntity.Added)
                        Item.Instance = InstanceEntity.Modified;
                     if (TotalVenta40 == 0)
                     {
                        _Porcentaje = 0;
                        Item.DCOT_Venta = 0;
                     }
                     else
                     {
                        _Porcentaje = (Item.DCOT_Venta * 100) / TotalVenta40;
                        Item.DCOT_Venta = Decimal.Round( Convert.ToDecimal(Convert.ToDecimal(txtTotalCosto40.Text) - (Convert.ToDecimal(txtTotalCosto40.Text) ==0?0: TotalHBL)) * (_Porcentaje / 100),2);
                     }
                     if (TotalVenta40SADA == 0)
                     {
                        _Porcentaje = 0;
                        Item.DCOT_VentaSada = 0;
                     }
                     else
                     {
                        _Porcentaje = (Item.DCOT_VentaSada * 100) / TotalVenta40SADA;
                        Item.DCOT_VentaSada = Decimal.Round (  Convert.ToDecimal(Convert.ToDecimal(txtTotalCostoSADA40.Text) - (Convert.ToDecimal(txtTotalCostoSADA40.Text)==0?0:TotalHBLSADA)) * (_Porcentaje / 100),2);
                     }
                     _Cantidad40++;
                     if (_Cantidad40 == Presenter.ItemsGrillaDet_Cotizacion.Count)
                     {
                        if (_TotalValidaVenta40 != (Convert.ToDecimal(txtTotalCosto40.Text) - (Convert.ToDecimal(txtTotalCosto40.Text) == 0 ? 0 : TotalHBL)))
                        {
                           if (_TotalValidaVenta40 < (Convert.ToDecimal(txtTotalCosto40.Text) - TotalHBL))
                           {
                              Item.DCOT_Venta = Item.DCOT_Venta + ((Convert.ToDecimal(txtTotalCosto40.Text) - (Convert.ToDecimal(txtTotalCosto40.Text) == 0 ? 0 : TotalHBL)) - _TotalValidaVenta40);
                           }
                           else
                           {
                              Item.DCOT_Venta = Item.DCOT_Venta - (_TotalValidaVenta40 - (Convert.ToDecimal(txtTotalCosto40.Text) - (Convert.ToDecimal(txtTotalCosto40.Text) == 0 ? 0 : TotalHBL)));
                           }
                        }

                     }
                     if (_TotalValidaSADA40 != (Convert.ToDecimal(txtTotalCostoSADA40.Text) - (Convert.ToDecimal(txtTotalCostoSADA40.Text) == 0 ? 0 : TotalHBLSADA)))
                     {
                        if (_TotalValidaSADA40 < (Convert.ToDecimal(txtTotalCostoSADA40.Text) - TotalHBLSADA))
                        {
                           Item.DCOT_VentaSada = Item.DCOT_VentaSada + ((Convert.ToDecimal(txtTotalCostoSADA40.Text) - (Convert.ToDecimal(txtTotalCostoSADA40.Text) == 0 ? 0 : TotalHBL)) - _TotalValidaSADA40);
                        }
                        else
                        {
                           Item.DCOT_VentaSada = Item.DCOT_VentaSada - (_TotalValidaSADA40 - (Convert.ToDecimal(txtTotalCostoSADA40.Text) - (Convert.ToDecimal(txtTotalCostoSADA40.Text) == 0 ? 0 : TotalHBLSADA)));
                        }
                     }

                     break;
               }

            }

            if (_TotalValidaVenta20 != (Convert.ToDecimal(txtTotalCosto20.Text) - Convert.ToDecimal(txtTotalCosto20.Text) == 0 ? 0 : TotalHBL))
            {
               if (_TotalValidaVenta20 < (Convert.ToDecimal(txtTotalCosto20.Text) -TotalHBL))
               {
                  Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count- 1].DCOT_Venta20 = Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count - 1].DCOT_Venta20 + ((Convert.ToDecimal(txtTotalCosto20.Text) -TotalHBL) - _TotalValidaVenta20);
               }
               else
               {
                  Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count - 1].DCOT_Venta20 = Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count - 1].DCOT_Venta20 - (_TotalValidaVenta20 - (Convert.ToDecimal(txtTotalCosto20.Text) - TotalHBL));
               }
            }

            if (_TotalValidaVentaSADA20 != (Convert.ToDecimal(txtTotalCostoSada20.Text) - Convert.ToDecimal(txtTotalCostoSada20.Text) == 0?0:TotalHBLSADA))
            {
               if (_TotalValidaVentaSADA20 < (Convert.ToDecimal(txtTotalCostoSada20.Text) - TotalHBLSADA))
               {
                  Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count - 1].DCOT_VentaSada20 = Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count - 1].DCOT_VentaSada20 + ((Convert.ToDecimal(txtTotalCostoSada20.Text) - TotalHBLSADA) - _TotalValidaVentaSADA20);
               }
               else
               {
                  Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count - 1].DCOT_VentaSada20 = Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count - 1].DCOT_VentaSada20 - (_TotalValidaVentaSADA20 - (Convert.ToDecimal(txtTotalCostoSada20.Text) - TotalHBLSADA));
               }
            }

            if (_TotalValidaVenta40 != (Convert.ToDecimal(txtTotalCosto40.Text) - Convert.ToDecimal(txtTotalCosto40.Text) == 0?0:TotalHBL))
            {
               if (_TotalValidaVenta40 < (Convert.ToDecimal(txtTotalCosto40.Text) - TotalHBL))
               {
                  Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count - 1].DCOT_Venta40 = Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count - 1].DCOT_Venta40 + ((Convert.ToDecimal(txtTotalCosto40.Text) - TotalHBL) - _TotalValidaVenta40);
               }
               else
               {
                  Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count - 1].DCOT_Venta40 = Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count - 1].DCOT_Venta40 - (_TotalValidaVenta40 - (Convert.ToDecimal(txtTotalCosto40.Text) - TotalHBL));
               }
            }
            if (_TotalValidaSADA40 != (Convert.ToDecimal(txtTotalCostoSADA40.Text) - Convert.ToDecimal(txtTotalCostoSADA40.Text) == 0 ? 0 : TotalHBLSADA))
            {
               if (_TotalValidaSADA40 < (Convert.ToDecimal(txtTotalCostoSADA40.Text) - TotalHBLSADA))
               {
                  Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count - 1].DCOT_VentaSada40 = Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count - 1].DCOT_VentaSada40 + ((Convert.ToDecimal(txtTotalCostoSADA40.Text) - TotalHBLSADA) - _TotalValidaSADA40);
               }
               else
               {
                  Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count - 1].DCOT_VentaSada40 = Presenter.ItemsGrillaDet_Cotizacion[Presenter.ItemsGrillaDet_Cotizacion.Count - 1].DCOT_VentaSada40 - (_TotalValidaSADA40 - (Convert.ToDecimal(txtTotalCostoSADA40.Text) - TotalHBLSADA));
               }
            }
            ShowItemsLogisticoDetalleCotizacion(false);
         }
         catch (Exception) { }
      }

      private void btnSalir_Click(object sender, EventArgs e)
      {
          try
          {
              Close();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      private void btnImprimir_Click(object sender, EventArgs e)
      {
          try
          {
             Presenter.Imprimir();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al imprimir la cotización", ex); }
      }
      
      void PRO002MView_Load(object sender, EventArgs e)
      {
          TabCotizacion.SelectedTab = TabPageServicios;
          TabControlDetalleCotizacion.SelectedTab = TabPageLogistico;
      }
      void chkCTAR_Transporte_CheckedChanged(object sender, EventArgs e)
      {
          try
          {
              if (chkCTAR_Transporte.Checked)
              {
                  AyudaTransporte.Enabled = true;
              }
              else
              {
                  AyudaTransporte.Enabled = false;
                  AyudaTransporte.ClearValue();
              }
              AsignarCodigoTarifa();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido una error al activar la casilla de verificación", ex); }
      }
      void chkCTAR_Aduanero_CheckedChanged(object sender, EventArgs e)
      {
          try
          {
              if (chkCTAR_Aduanero.Checked)
              {
                 AyudaAduanero.Enabled = true;
              }
              else
              {
                  AyudaAduanero.Enabled = false;
                  AyudaAduanero.ClearValue();
              }
              AsignarCodigoTarifa();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido una error al activar la casilla de verificación", ex); }
      }
      void chkCTAR_Logistico_CheckedChanged(object sender, EventArgs e)
      {
          try
          {
              if (chkCTAR_Logistico.Checked)
              {
                  AyudaLogistico.Enabled = true;
              }
              else
              {
                  AyudaLogistico.Enabled = false;
                  AyudaLogistico.ClearValue();
              }
              AsignarCodigoTarifa();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido una error al activar la casilla de verificación", ex); }
      }

      void AsignarCodigoTarifa()
      {
         if (AyudaAduanero.Value == null && AyudaTransporte.Value == null && AyudaLogistico.Value == null)
         {
            Presenter.CTAR_Codigo = 0;
         }
            AyudaAduanero.CTAR_Codigo = Presenter.CTAR_Codigo;
            AyudaLogistico.CTAR_Codigo = Presenter.CTAR_Codigo;
            AyudaTransporte.CTAR_Codigo = Presenter.CTAR_Codigo;

      }
      void AyudaTransporte_AyudaValueChanged(object sender, EventArgs e)
      {
          if (AyudaTransporte.Value != null && !Presenter._LoadCotizacion)
          {
             Presenter.BuscarTarifarios(true, null, null, AyudaTransporte.Value.CTAR_Codigo ); 
          }
          else
          {
             if (AyudaTransporte.Value == null)
             {

                while (Presenter.ItemsDet_CotizacionTransporte.FirstOrDefault(tipo => tipo.CTAR_Tipo == "T" && tipo.Instance != InstanceEntity.Deleted) != null)
                {
                   var _item = Presenter.ItemsDet_CotizacionTransporte.First(tipo => tipo.CTAR_Tipo == "T" && tipo.Instance != InstanceEntity.Deleted);
                   if (_item.DCOT_Item > 0)
                   { _item.Instance = InstanceEntity.Deleted; }
                   else
                   { Presenter.ItemsDet_CotizacionTransporte.Remove(_item); }
                }
                while (Presenter.ItemsDet_CotizacionRegistros.FirstOrDefault(tipo => tipo.CTAR_Tipo == "T" && tipo.Instance != InstanceEntity.Deleted) != null)
                {
                   var _item = Presenter.ItemsDet_CotizacionRegistros.First(tipo => tipo.CTAR_Tipo == "T" && tipo.Instance != InstanceEntity.Deleted);
                   if (_item.DCOT_Item > 0)
                   { _item.Instance = InstanceEntity.Deleted; }
                   else
                   { Presenter.ItemsDet_CotizacionRegistros.Remove(_item); }
                }

                ShowItemsTransporteDetalleCotizacion();
                AsignarCodigoTarifa();
             }
          }
      }
      void AyudaAduanero_AyudaValueChanged(object sender, EventArgs e)
      {
         if (AyudaAduanero.Value != null && !Presenter._LoadCotizacion)
         {
            Presenter.BuscarTarifarios(true, null, AyudaAduanero.Value.CTAR_Codigo, null);
         }
         else
         {
            if (AyudaAduanero.Value == null)
            {
               while (Presenter.ItemsDet_CotizacionAduanero.FirstOrDefault(tipo => tipo.CTAR_Tipo == "A" && tipo.Instance != InstanceEntity.Deleted) != null)
               {
                  var _item = Presenter.ItemsDet_CotizacionAduanero.First(tipo => tipo.CTAR_Tipo == "A" && tipo.Instance != InstanceEntity.Deleted);
                  if (_item.DCOT_Item > 0)
                  { _item.Instance = InstanceEntity.Deleted; }
                  else
                  { Presenter.ItemsDet_CotizacionAduanero.Remove(_item); }
               }
               while (Presenter.ItemsDet_CotizacionRegistros.FirstOrDefault(tipo => tipo.CTAR_Tipo == "A" && tipo.Instance != InstanceEntity.Deleted) != null)
               {
                  var _item = Presenter.ItemsDet_CotizacionRegistros.First(tipo => tipo.CTAR_Tipo == "A" && tipo.Instance != InstanceEntity.Deleted);
                  if (_item.DCOT_Item > 0)
                  { _item.Instance = InstanceEntity.Deleted; }
                  else
                  { Presenter.ItemsDet_CotizacionRegistros.Remove(_item); }
               }
               while (Presenter.ItemsDet_CotizacionServicio.FirstOrDefault(tipo => tipo.SCOT_Tipo == "A" && tipo.Instance != InstanceEntity.Deleted) != null)
               {
                  var _item = Presenter.ItemsDet_CotizacionServicio.First(tipo => tipo.SCOT_Tipo == "A" && tipo.Instance != InstanceEntity.Deleted);
                  if (_item.SCOT_Item > 0)
                  { _item.Instance = InstanceEntity.Deleted; }
                  else
                  { Presenter.ItemsDet_CotizacionServicio.Remove(_item); }
               }
               ShowItemsDetalleServicios();
               ShowItemsAduaneroDetalleCotizacion();
               AsignarCodigoTarifa();
            }
         }
      }
      void AyudaLogistico_AyudaValueChanged(object sender, EventArgs e)
      {
         if (AyudaLogistico.Value != null && !Presenter._LoadCotizacion)
          {
             Presenter.BuscarTarifarios(true, AyudaLogistico.Value.CTAR_Codigo, null, null); 
          }
         else
            if (AyudaLogistico.Value == null)
            {
               Presenter.ItemsGrillaDet_Cotizacion = null;

               while (Presenter.ItemsDet_Cotizacion.FirstOrDefault(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted) != null)
               {
                  var _item = Presenter.ItemsDet_Cotizacion.FirstOrDefault(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted);
                  if (_item.DCOT_Item > 0)
                  { _item.Instance = InstanceEntity.Deleted; }
                  else
                  { Presenter.ItemsDet_Cotizacion.Remove(_item); }
               }

               while (Presenter.ItemsDet_CotizacionRegistros.FirstOrDefault(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted) != null)
               {
                  var _item = Presenter.ItemsDet_CotizacionRegistros.First(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted);
                  if (_item.DCOT_Item > 0)
                  { _item.Instance = InstanceEntity.Deleted; }
                  else
                  { Presenter.ItemsDet_CotizacionRegistros.Remove(_item); }
               }

               while (Presenter.ItemsDet_CotizacionLogistico.FirstOrDefault(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted) != null)
               {
                  var _item = Presenter.ItemsDet_CotizacionLogistico.First(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted);
                  if (_item.DCOT_Item > 0)
                  { _item.Instance = InstanceEntity.Deleted; }
                  else
                  { Presenter.ItemsDet_CotizacionLogistico.Remove(_item); }
               }

               while (Presenter.ItemsDet_CotizacionServicio.FirstOrDefault(tipo => tipo.SCOT_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted) != null)
               {
                  var _item = Presenter.ItemsDet_CotizacionServicio.First(tipo => tipo.SCOT_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted);
                  if (_item.SCOT_Item > 0)
                  { _item.Instance = InstanceEntity.Deleted; }
                  else
                  { Presenter.ItemsDet_CotizacionServicio.Remove(_item); }
               }
               ShowItemsLogisticoDetalleCotizacion(true);
               ShowItemsDetalleServicios();
               AsignarCodigoTarifa();
            }
          
      }

      public void SeteaCabTarifarios(Int32 _CTAR_Codigo, String _CTAR_Tipo)
      {
         switch (_CTAR_Tipo)
         {
            case "L":
               AyudaLogistico.SetValue(_CTAR_Codigo, _CTAR_Tipo, false);
               break;
            case "A":
               AyudaAduanero.SetValue(_CTAR_Codigo, _CTAR_Tipo, false);
               break;
         }
         
      }
      private void PRO002MView_FormClosed(object sender, FormClosedEventArgs e)
      {
          Presenter.IsClosedMView();
      }

      private void PRO002MView_FormClosing(object sender, FormClosingEventArgs e)
      {
          try
          {
              if (Closing != true)
              {
                  this.FormClosing -= PRO002MView_FormClosing;
                  if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
                  {
                      //if (Presenter.GuardarCambio(EsProspecto) == System.Windows.Forms.DialogResult.Cancel)
                      //{
                      //   e.Cancel = true;
                      //   this.FormClosing += new FormClosingEventHandler(PRO002MView_FormClosing);
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

      #endregion

      #region [ Detalle Cotizacion ]
      void grdItemsTransporte_CellFormatting(object sender, CellFormattingEventArgs e)
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
                          bte.Enabled = Presenter.ItemCab_Cotizacion.CONS_CodEstado == "001" || String.IsNullOrEmpty(Presenter.ItemCab_Cotizacion.CONS_CodEstado);
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
                          bte.Enabled = Presenter.ItemCab_Cotizacion.CONS_CodEstado == "001" || String.IsNullOrEmpty(Presenter.ItemCab_Cotizacion.CONS_CodEstado);
                      }
                  }
                  if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
                  {
                      e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
                  }
              }

          }
          catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      void grdItemsAduanero_CellFormatting(object sender, CellFormattingEventArgs e)
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
                          bte.Enabled = Presenter.ItemCab_Cotizacion.CONS_CodEstado == "001" || String.IsNullOrEmpty(Presenter.ItemCab_Cotizacion.CONS_CodEstado);
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
                          bte.Enabled = Presenter.ItemCab_Cotizacion.CONS_CodEstado == "001" || String.IsNullOrEmpty(Presenter.ItemCab_Cotizacion.CONS_CodEstado);
                      }
                  }
                  if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
                  {
                      e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
                  }
              }

          }
          catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      void grdItemsLogistico_CellFormatting(object sender, CellFormattingEventArgs e)
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
                          bte.Enabled = Presenter.ItemCab_Cotizacion.CONS_CodEstado == "001" || String.IsNullOrEmpty(Presenter.ItemCab_Cotizacion.CONS_CodEstado);
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
                          bte.Enabled = Presenter.ItemCab_Cotizacion.CONS_CodEstado == "001" || String.IsNullOrEmpty(Presenter.ItemCab_Cotizacion.CONS_CodEstado); 
                      }
                  }
                  if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
                  {
                      e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
                  }
              }

          }
          catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      void grdItemsLogistico_CommandCellClick(object sender, EventArgs e)
      {
          try
          {
              if (sender is GridCommandCellElement)
              {
                  switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
                  {
                      case "Editar":
                          SeleccionarItemLogsitico();
                          Presenter.EditarDetalleCotizacion();
                          break;
                      case "Eliminar":
                          SeleccionarItemLogsitico();
                          Presenter.EliminarDetalleCotizacion();
                          break;
                  }
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar el registro.", ex); }
      }
      void grdItemsTransporte_CommandCellClick(object sender, EventArgs e)
      {
          try
          {
              if (sender is GridCommandCellElement)
              {
                  switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
                  {
                      case "Editar":
                          SeleccionarItemTransporte();
                          Presenter.EditarDetalleCotizacion();
                          break;
                      case "Eliminar":
                          SeleccionarItemTransporte();
                          Presenter.EliminarDetalleCotizacion();
                          break;
                  }
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar el registro.", ex); }
      }
      void grdItemsAduanero_CommandCellClick(object sender, EventArgs e)
      {
          try
          {
              if (sender is GridCommandCellElement)
              {
                  switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
                  {
                      case "Editar":
                          SeleccionarItemAduanero();
                          Presenter.EditarDetalleCotizacion();
                          break;
                      case "Eliminar":
                          SeleccionarItemAduanero();
                          Presenter.EliminarDetalleCotizacion();
                          break;
                  }
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar el registro.", ex); }
      }
      void BSItemsTransporte_CurrentItemChanged(object sender, EventArgs e)
      {
          try
          {
              SeleccionarItemTransporte();
          }
          catch (Exception) { }
      }
      void BSItemsAduanero_CurrentItemChanged(object sender, EventArgs e)
      {
          try
          {
              SeleccionarItemAduanero();
          }
          catch (Exception) { }
      }
      void BSItemsLogistico_CurrentItemChanged(object sender, EventArgs e)
      {
          try
          {
              SeleccionarItemLogsitico();
          }
          catch (Exception) { }
      }
      #endregion

      #region [ Servicios ]
      void btnNuevoServicio_Click(object sender, EventArgs e)
      {
          try
          {
              Presenter.LoadNuevoDetalleServicioCotizacion();
          }
          catch (Exception) { }
      }
      void grdItemsServicios_CellFormatting(object sender, CellFormattingEventArgs e)
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
                          bte.Enabled = Presenter.ItemCab_Cotizacion.CONS_CodEstado == "001" || String.IsNullOrEmpty(Presenter.ItemCab_Cotizacion.CONS_CodEstado);
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
                          bte.Enabled = Presenter.ItemCab_Cotizacion.CONS_CodEstado == "001" || String.IsNullOrEmpty(Presenter.ItemCab_Cotizacion.CONS_CodEstado);
                      }
                  }
              }
              if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
              {
                  e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
              }
          }
          catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      void grdItemsServicios_CommandCellClick(object sender, EventArgs e)
      {
          try
          {
              if (sender is GridCommandCellElement)
              {
                  switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
                  {
                      case "Editar":
                          SeleccionarItemServicios();
                          Presenter.EditarServicioDetalleCotizacion();
                          break;
                      case "Eliminar":
                          SeleccionarItemServicios();
                          Presenter.EliminarDetalleServicioCotizacion();
                          break;
                  }
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar el registro.", ex); }
      }
      void BSItemsServicios_CurrentItemChanged(object sender, EventArgs e)
      {
          try
          {
              SeleccionarItemServicios();
          }
          catch (Exception) { }
      } 
      #endregion
      #endregion
   }
}
