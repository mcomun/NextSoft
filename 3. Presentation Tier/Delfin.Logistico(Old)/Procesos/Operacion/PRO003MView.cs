using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Delfin.Entities;
using Delfin.Logistico.Properties;
using Infrastructure.Aspect.Constants;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using TiposEntidad = Delfin.Controls.TiposEntidad;
using ApplicationForm;

namespace Delfin.Logistico
{
   public partial class PRO003MView : Form, IPRO003MView
   {
      #region [ Variables ]
      private bool Closing = false;
      #endregion

      #region [ Formulario ]
      public PRO003MView()
      {
         InitializeComponent();
         try
         {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += MView_FormClosed;
            /* Encabezado Operacion */
            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;
            btnPreFactura.Click += btnPreFactura_Click;
            btnFacturacion.Click += btnFacturacion_Click;
            Load += PRO003MView_Load;
            chkCTAR_Logistico.CheckedChanged += chkCTAR_Logistico_CheckedChanged;
            chkCTAR_Aduanero.CheckedChanged += chkCTAR_Aduanero_CheckedChanged;
            chkCTAR_Transporte.CheckedChanged += chkCTAR_Transporte_CheckedChanged;

            AyudaLogistico.AyudaValueChanged += AyudaLogistico_AyudaValueChanged;
            AyudaAduanero.AyudaValueChanged += AyudaAduanero_AyudaValueChanged;
            AyudaTransporte.AyudaValueChanged += AyudaTransporte_AyudaValueChanged;

            AyudaLogistico.AyudaGetValores += AyudaLogistico_AyudaGetValores;
            AyudaAduanero.AyudaGetValores += AyudaAduanero_AyudaGetValores;
            AyudaTransporte.AyudaGetValores += AyudaTransporte_AyudaGetValores;


            txtCOPE_Fob.ValueChanged += txtCOPE_Fob_ValueChanged;
            txtCOPE_Flete.ValueChanged += txtCOPE_Flete_ValueChanged;
            txtCOPE_Seguro.ValueChanged += txtCOPE_Seguro_ValueChanged;
            txtCOPE_PartArancelaria.ValueChanged += txtCOPE_PartArancelaria_ValueChanged;
            ChkPrecioSada.CheckedChanged += ChkPrecioSada_CheckedChanged;
            /* Detalle Operacion */
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

            /* Detalle Servicio Operacion */
            btnNuevoServicio.Click += btnNuevoServicio_Click;
            BSItemsServicios = new BindingSource();
            BSItemsServicios.CurrentItemChanged += BSItemsServicios_CurrentItemChanged;
            grdItemsServicios.CommandCellClick += grdItemsServicios_CommandCellClick;
            grdItemsServicios.CellFormatting += grdItemsServicios_CellFormatting;

            AyudaOrdenVenta.AyudaClick += AyudaOrdenVenta_AyudaClick;
            _CheckLogisticoManual = false;
            _CheckTransporteManual = false;
            _CheckAduaneroManual = false;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }
      #endregion

      #region [ Propiedades ]
      public PRO003Presenter Presenter { get; set; }
      public BindingSource BSItemsLogistico { get; set; }
      public BindingSource BSItemsAduanero { get; set; }
      public BindingSource BSItemsTransporte { get; set; }
      public BindingSource BSItemsServicios { get; set; }
      public Boolean _CheckLogisticoManual { get; set; }
      public Boolean _CheckTransporteManual { get; set; }
      public Boolean _CheckAduaneroManual { get; set; }
      private Hashtable HashFormulario { get; set; }
      #endregion

      #region [ IPRO003MView ]
      public void LoadView()
      {
         try
         {
            AyudaLogistico.ContainerService = Presenter.ContainerService;
            AyudaAduanero.ContainerService = Presenter.ContainerService;
            AyudaTransporte.ContainerService = Presenter.ContainerService;
            AyudaENTC_CodCliente.ContainerService = Presenter.ContainerService;
            AyudaENTC_CodTransporte.ContainerService = Presenter.ContainerService;
            AyudaENTC_CodAgente.ContainerService = Presenter.ContainerService;

            CbTIPO_CodMnd.LoadControl(Presenter.ContainerService, "Tabla Moneda", "MND", "< Selecione Moneda >", ListSortDirection.Descending);
            CmbCONS_CodEstado.LoadControl(Presenter.ContainerService, "Tabla Estado", "OPE", "< Selecione Estado >", ListSortDirection.Descending);
            CbCONS_CodCRG.LoadControl(Presenter.ContainerService, "Tabla Estado", "CRG", "< Tipo Carga >", ListSortDirection.Descending);
            dtpCOPE_FecEmi.NSFecha = Presenter.Session.Fecha.Date;
            dtpCOPE_FecEmi.Enabled = false;

            AyudaENTC_CodCliente.TipoEntidad = TiposEntidad.TIPE_Cliente;

            FormatDataGridLogistico();
            FormatDataGridAduanero();
            FormatDataGridTransporte();
            FormatDataGridServicos();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      #region [Encabezado Operación ]
      public void ClearItem()
      {
         try
         {
            txtCOPE_NumDoc.Clear();
            TxtNroCotizacion.Clear();
            Presenter.CCOT_NumDoc = null;
            dtpCOPE_FecEmi.NSFecha = null;
            CbCONS_CodCRG.SelectedIndex = 0;
            CbTIPO_CodMnd.SelectedIndex = 0;
            CmbCONS_CodEstado.SelectedIndex = 0;
            AyudaENTC_CodCliente.ClearValue();
            AyudaENTC_CodTransporte.ClearValue();
            AyudaENTC_CodAgente.ClearValue();
            AyudaOrdenVenta.ClearValue();
            txtCOPE_Observacion.Clear();
            dtpCOPE_FecEmi.NSFecha = Presenter.Session.Fecha.Date;
            txtCOPE_HBL.Text = String.Empty;
            ChkCOPE_Excepcion.Checked = false;
            txtViaje.Clear();
            txtNave.Clear();
            txtMBL.Clear();
            //dtpFecLlegada.NSFecha = Presenter.Session.Fecha.Date;

            txtCOPE_Fob.Text = @"0";
            txtCOPE_Fob.Value = 0;
            txtCOPE_Flete.Text = @"0";
            txtCOPE_Flete.Value = 0;
            txtCOPE_Seguro.Text = @"0";
            txtCOPE_Seguro.Value = 0;
            txtCOPE_Cif.Text = @"0";
            txtCOPE_Cif.Value = 0;
            txtCOPE_PartArancelaria.Text = @"0";
            txtCOPE_PartArancelaria.Value = 0;
            txtkilos.Text = @"0";
            txtkilos.Value = 0;
            chkCOPE_1erEmbarque.Checked = false;
            txtCOPE_AdValorem.Text = @"0";
            txtCOPE_AdValorem.Value = 0;
            txtVolumen.Text = @"0";
            txtVolumen.Value = 0;
            txtCantidadDias.Value = 0;
            txtCantidadDias.Text = @"0";
            ChkPrecioSada.Checked = false;
            Presenter.PrecioSada = false;
            chkCTAR_Logistico.Checked = false;
            chkCTAR_Aduanero.Checked = false;
            chkCTAR_Transporte.Checked = false;

            AyudaLogistico.ClearValue();
            AyudaLogistico.Enabled = false;
            AyudaAduanero.ClearValue();
            AyudaAduanero.Enabled = false;
            AyudaTransporte.ClearValue();
            AyudaTransporte.Enabled = false;

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void GetItem()
      {
         try
         {
            if (dtpCOPE_FecEmi.NSFecha != null)
            {
               Presenter.ItemCab_Operacion.COPE_FecEmi = dtpCOPE_FecEmi.NSFecha.Value;
            }
            else { Presenter.ItemCab_Operacion.COPE_FecEmi = null; }

            if (AyudaENTC_CodCliente.Value != null)
            {
               if (AyudaENTC_CodCliente.Value.ENTC_Codigo > 0)
               {
                  Presenter.ItemCab_Operacion.ENTC_CodCliente = AyudaENTC_CodCliente.Value.ENTC_Codigo;
                  //if (Presenter.ItemCab_Operacion.Instance == InstanceEntity.Added)
                  //{ Presenter.ItemCab_Operacion.Cliente = AyudaENTC_CodCliente.Value.ENTC_RazonSocial; }
               }
            }
            if (AyudaENTC_CodTransporte.Value != null)
            {
               if (AyudaENTC_CodTransporte.Value.ENTC_Codigo > 0)
               {
                  Presenter.ItemCab_Operacion.ENTC_CodTransporte = AyudaENTC_CodTransporte.Value.ENTC_Codigo;
                  //if (Presenter.ItemCab_Operacion.Instance == InstanceEntity.Added)
                  //{ Presenter.ItemCab_Operacion.Transportista = AyudaENTC_CodTransporte.Value.ENTC_RazonSocial; }
               }
            }
            if (AyudaENTC_CodAgente.Value != null)
            {
               if (AyudaENTC_CodAgente.Value.ENTC_Codigo > 0)
               {
                  Presenter.ItemCab_Operacion.ENTC_CodAgente = AyudaENTC_CodAgente.Value.ENTC_Codigo;
                  //if (Presenter.ItemCab_Operacion.Instance == InstanceEntity.Added)
                  //{ Presenter.ItemCab_Operacion.Agente = AyudaENTC_CodAgente.Value.ENTC_RazonSocial; }
               }
            }

            Presenter.ItemCab_Operacion.CONS_CodEstado = CmbCONS_CodEstado.SelectedValue != null ? CmbCONS_CodEstado.SelectedValue.ToString() : null;
            //if (Presenter.ItemCab_Operacion.Instance == InstanceEntity.Added)
            //{ Presenter.ItemCab_Operacion.CONS_CodEstadoSTR = CmbCONS_CodEstado.ConstantesSelectedItem.CONS_Desc_SPA; }

            Presenter.ItemCab_Operacion.TIPO_CodMND = CbTIPO_CodMnd.SelectedValue != null ? CbTIPO_CodMnd.SelectedValue.ToString() : null;
            //if (Presenter.ItemCab_Operacion.Instance == InstanceEntity.Added)
            //{ Presenter.ItemCab_Operacion.MonedaSTR = CbTIPO_CodMnd.TiposSelectedItem.TIPO_Desc1; }

            if (chkCTAR_Logistico.Checked && AyudaLogistico.Value != null && AyudaLogistico.Value.CCOT_Codigo > 0)
            {
               Presenter.ItemCab_Operacion.CCOT_CodLogistico = AyudaLogistico.Value.CCOT_Codigo;
            }
            else { Presenter.ItemCab_Operacion.CCOT_CodLogistico = null; }

            if (chkCTAR_Aduanero.Checked && AyudaAduanero.Value != null && AyudaAduanero.Value.CCOT_Codigo > 0)
            {
               Presenter.ItemCab_Operacion.CCOT_CodAduana = AyudaAduanero.Value.CCOT_Codigo;
            }
            else { Presenter.ItemCab_Operacion.CCOT_CodAduana = null; }

            if (chkCTAR_Transporte.Checked && AyudaTransporte.Value != null && AyudaTransporte.Value.CCOT_Codigo > 0)
            {
               Presenter.ItemCab_Operacion.CCOT_CodTransporte = AyudaTransporte.Value.CCOT_Codigo;
            }
            else { Presenter.ItemCab_Operacion.CCOT_CodTransporte = null; }

            Presenter.ItemCab_Operacion.CONS_CodCRG = CbCONS_CodCRG.SelectedValue != null ? CbCONS_CodCRG.SelectedValue.ToString() : null;
            Presenter.ItemCab_Operacion.COPE_HBL = !String.IsNullOrEmpty(txtCOPE_HBL.Text) ? txtCOPE_HBL.Text : null;
            Presenter.ItemCab_Operacion.COPE_Excepcion = ChkCOPE_Excepcion.Checked;
            Presenter.ItemCab_Operacion.COPE_Viaje = !String.IsNullOrEmpty(txtViaje.Text) ? txtViaje.Text : null;
            Presenter.ItemCab_Operacion.COPE_Nave = !String.IsNullOrEmpty(txtNave.Text) ? txtNave.Text : null;
            Presenter.ItemCab_Operacion.COPE_MBL = !String.IsNullOrEmpty(txtMBL.Text) ? txtMBL.Text : null;

            Presenter.ItemCab_Operacion.COPE_FechaArribo = dtpFecLlegada.NSFecha != null ? (DateTime?)dtpFecLlegada.NSFecha.Value : null;
            Presenter.ItemCab_Operacion.COPE_CantidadDias = txtCantidadDias.Value > 0 ? (short?)txtCantidadDias.Value : null;

            Presenter.ItemCab_Operacion.COPE_Fob = txtCOPE_Fob.Value > 0 ? txtCOPE_Fob.Value : 0;
            Presenter.ItemCab_Operacion.COPE_Flete = txtCOPE_Flete.Value > 0 ? txtCOPE_Flete.Value : 0;
            Presenter.ItemCab_Operacion.COPE_Seguro = txtCOPE_Seguro.Value > 0 ? txtCOPE_Seguro.Value : 0;
            Presenter.ItemCab_Operacion.COPE_Cif = txtCOPE_Cif.Value > 0 ? txtCOPE_Cif.Value : 0;
            Presenter.ItemCab_Operacion.COPE_PartArancelaria = txtCOPE_PartArancelaria.Value > 0 ? txtCOPE_PartArancelaria.Value : 0;
            Presenter.ItemCab_Operacion.COPE_1erEmbarque = chkCOPE_1erEmbarque.Checked;
            Presenter.ItemCab_Operacion.COPE_AdValorem = txtCOPE_AdValorem.Value > 0 ? txtCOPE_AdValorem.Value : 0;
            Presenter.ItemCab_Operacion.COPE_Observacion = txtCOPE_Observacion.Text;

            Presenter.ItemCab_Operacion.COPE_Kilos = txtkilos.Value > 0 ? txtkilos.Value : (decimal?)null;
            Presenter.ItemCab_Operacion.COPE_Volumen = txtVolumen.Value > 0 ? txtVolumen.Value : (decimal?)null;
            Presenter.ItemCab_Operacion.COPE_PrecioSada = ChkPrecioSada.Checked;

            /* Calculos internos */
            //Valor IPM = 2% * (CIF + AV)
            Presenter.ItemCab_Operacion.COPE_Ipm = ((Decimal)0.02 * (Presenter.ItemCab_Operacion.COPE_Cif + Presenter.ItemCab_Operacion.COPE_AdValorem));
            //Valor IGV = 16% * (CIF + AV)
            Presenter.ItemCab_Operacion.COPE_Igv = ((Decimal)0.16 * (Presenter.ItemCab_Operacion.COPE_Cif + Presenter.ItemCab_Operacion.COPE_AdValorem));

            //Valor Percepción = 10% * (CIF + AV + IPM + IGV).

            if (Presenter.ItemCab_Operacion.COPE_1erEmbarque.Value)  //10% para primer embarque o producto nuevo
            {
               Presenter.ItemCab_Operacion.COPE_Percepcion = ((Decimal)0.1 * (Presenter.ItemCab_Operacion.COPE_Cif + Presenter.ItemCab_Operacion.COPE_AdValorem + Presenter.ItemCab_Operacion.COPE_Ipm + Presenter.ItemCab_Operacion.COPE_Igv));
            }
            else //3.5% para segundo embarque.
            {
               Presenter.ItemCab_Operacion.COPE_Percepcion = ((Decimal)0.035 * (Presenter.ItemCab_Operacion.COPE_Cif + Presenter.ItemCab_Operacion.COPE_AdValorem + Presenter.ItemCab_Operacion.COPE_Ipm + Presenter.ItemCab_Operacion.COPE_Igv));
            }
            //Valor de Tasa = USD $ 9.00
            Presenter.ItemCab_Operacion.COPE_TasaDespacho = (Decimal)9.00;
            Presenter.ItemCab_Operacion.CCOT_Codigo = Presenter.CCOT_Codigo;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.GetItem, ex); }
      }
      public void SetItem()
      {
         try
         {
            if (Presenter.ItemCab_Operacion.CCOT_Codigo != null)
               Presenter.CCOT_Codigo = Presenter.ItemCab_Operacion.CCOT_Codigo.Value;
            txtCOPE_NumDoc.Text = Presenter.ItemCab_Operacion.COPE_NumDoc;
            TxtNroCotizacion.Text = Presenter.ItemCab_Operacion.CCOT_NumDoc;
            Presenter.CCOT_NumDoc = Presenter.ItemCab_Operacion.CCOT_NumDoc;
            if (Presenter.ItemCab_Operacion.COPE_FecEmi != null)
            {
               dtpCOPE_FecEmi.NSFecha = Presenter.ItemCab_Operacion.COPE_FecEmi.Value;
            }
            if (Presenter.ItemCab_Operacion.ENTC_CodCliente != null)
            {
               AyudaENTC_CodCliente.SetValue(Presenter.ItemCab_Operacion.ENTC_CodCliente.Value);
            }
            if (Presenter.ItemCab_Operacion.ENTC_CodTransporte != null)
            {
               AyudaENTC_CodTransporte.SetValue(Presenter.ItemCab_Operacion.ENTC_CodTransporte.Value);
            }
            if (Presenter.ItemCab_Operacion.ENTC_CodAgente != null)
            {
               AyudaENTC_CodAgente.SetValue(Presenter.ItemCab_Operacion.ENTC_CodAgente.Value);
            }
            CmbCONS_CodEstado.SelectedValue = Presenter.ItemCab_Operacion.CONS_CodEstado;
            CbTIPO_CodMnd.SelectedValue = Presenter.ItemCab_Operacion.TIPO_CodMND;

            txtCOPE_Observacion.Text = Presenter.ItemCab_Operacion.COPE_Observacion;

            if (Presenter.ItemCab_Operacion.CONS_CodCRG != null)
            {
               CbCONS_CodCRG.SelectedValue = Presenter.ItemCab_Operacion.CONS_CodCRG;
            }

            if (!String.IsNullOrEmpty(Presenter.ItemCab_Operacion.COPE_HBL))
            {
               txtCOPE_HBL.Text = Presenter.ItemCab_Operacion.COPE_HBL;
            }
            if (Presenter.ItemCab_Operacion.COPE_Excepcion != null)
            {
               ChkCOPE_Excepcion.Checked = Presenter.ItemCab_Operacion.COPE_Excepcion.Value;
            }

            txtViaje.Text = Presenter.ItemCab_Operacion.COPE_Viaje;
            txtNave.Text = Presenter.ItemCab_Operacion.COPE_Nave;
            txtMBL.Text = Presenter.ItemCab_Operacion.COPE_MBL;

            dtpFecLlegada.NSFecha = Presenter.ItemCab_Operacion.COPE_FechaArribo != null ? Presenter.ItemCab_Operacion.COPE_FechaArribo.Value : (DateTime?)null;
            txtCantidadDias.Value = Presenter.ItemCab_Operacion.COPE_CantidadDias != null ? Presenter.ItemCab_Operacion.COPE_CantidadDias.Value : 0;
            txtCantidadDias.Text = Presenter.ItemCab_Operacion.COPE_CantidadDias != null ? Presenter.ItemCab_Operacion.COPE_CantidadDias.Value.ToString(CultureInfo.InvariantCulture) : "0";

            txtCOPE_Fob.Value = Presenter.ItemCab_Operacion.COPE_Fob;
            txtCOPE_Fob.Text = Presenter.ItemCab_Operacion.COPE_Fob.ToString(CultureInfo.InvariantCulture);

            txtCOPE_Flete.Value = Presenter.ItemCab_Operacion.COPE_Flete;
            txtCOPE_Flete.Text = Presenter.ItemCab_Operacion.COPE_Flete.ToString(CultureInfo.InvariantCulture);

            txtCOPE_Seguro.Value = Presenter.ItemCab_Operacion.COPE_Seguro;
            txtCOPE_Seguro.Text = Presenter.ItemCab_Operacion.COPE_Seguro.ToString(CultureInfo.InvariantCulture);

            txtCOPE_Cif.Value = Presenter.ItemCab_Operacion.COPE_Cif;
            txtCOPE_Cif.Text = Presenter.ItemCab_Operacion.COPE_Cif.ToString(CultureInfo.InvariantCulture);
            Presenter.CCOT_CIF = txtCOPE_Cif.Value;

            if (Presenter.ItemCab_Operacion.CCOT_CodLogistico != null)
            {
               AyudaLogistico.SetValue(Presenter.ItemCab_Operacion.CCOT_CodLogistico.Value);
               chkCTAR_Logistico.Checked = true;
            }
            if (Presenter.ItemCab_Operacion.CCOT_CodAduana != null)
            {
               AyudaAduanero.SetValue(Presenter.ItemCab_Operacion.CCOT_CodAduana.Value);
               chkCTAR_Aduanero.Checked = true;
            }
            if (Presenter.ItemCab_Operacion.CCOT_CodTransporte != null)
            {
               AyudaTransporte.SetValue(Presenter.ItemCab_Operacion.CCOT_CodTransporte.Value);
               chkCTAR_Transporte.Checked = true;
            }
            txtCOPE_PartArancelaria.Value = Presenter.ItemCab_Operacion.COPE_PartArancelaria;
            txtCOPE_PartArancelaria.Text = Presenter.ItemCab_Operacion.COPE_PartArancelaria.ToString(CultureInfo.InvariantCulture);

            if (Presenter.ItemCab_Operacion.COPE_1erEmbarque != null)
            {
               chkCOPE_1erEmbarque.Checked = Presenter.ItemCab_Operacion.COPE_1erEmbarque.Value;
            }

            txtCOPE_AdValorem.Value = Presenter.ItemCab_Operacion.COPE_AdValorem;
            txtCOPE_AdValorem.Text = Presenter.ItemCab_Operacion.COPE_AdValorem.ToString(CultureInfo.InvariantCulture);

            txtkilos.Value = (decimal)(Presenter.ItemCab_Operacion.COPE_Kilos ?? 0);
            txtkilos.Text = Presenter.ItemCab_Operacion.COPE_Kilos != null ? Presenter.ItemCab_Operacion.COPE_Kilos.Value.ToString(CultureInfo.InvariantCulture) : "0";
            txtVolumen.Value = (decimal)(Presenter.ItemCab_Operacion.COPE_Volumen ?? 0);
            txtVolumen.Text = Presenter.ItemCab_Operacion.COPE_Volumen != null ? Presenter.ItemCab_Operacion.COPE_Volumen.Value.ToString(CultureInfo.InvariantCulture) : "0";

            ChkPrecioSada.Checked = Presenter.ItemCab_Operacion.COPE_PrecioSada;
            Presenter.PrecioSada = Presenter.ItemCab_Operacion.COPE_PrecioSada;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetItem, ex); }
      }
      public void SetInstance(InstanceView xInstance)
      {
         try
         {
            errorProvider1.Dispose();
            CmbCONS_CodEstado.Enabled = false;
            btnGuardar.Enabled = true;
            btnNuevoServicio.Enabled = true;
            switch (xInstance)
            {
               case InstanceView.Default:
                  break;
               case InstanceView.New:
                  txtCOPE_HBL.Enabled = true;
                  CmbCONS_CodEstado.SelectedValue = "001";
                  break;
               case InstanceView.Edit:
                  if (!String.IsNullOrEmpty(Presenter.ItemCab_Operacion.CONS_CodEstado))
                  {
                     if (Presenter.ItemCab_Operacion.CONS_CodEstado.Equals("001"))
                     {
                        btnGuardar.Enabled = true;
                        btnNuevoServicio.Enabled = true;
                     }
                     else
                     {
                        btnGuardar.Enabled = true;
                        btnNuevoServicio.Enabled = true;
                     }
                  }
                  txtCOPE_HBL.Enabled = false;
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
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.ItemCab_Operacion.MensajeError, Dialogos.Boton.Detalles);
            FormShowErrorProvider<Cab_Operacion>.Validate(Presenter.ItemCab_Operacion, this, errorProvider1);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      public void FiltrosCotizaciones()
      {
         try
         {
            if (AyudaLogistico.Value != null)
            {
               Presenter.CCOT_CodigoLogistico = AyudaLogistico.Value.CCOT_Codigo;
            }
            else { Presenter.CCOT_CodigoLogistico = null; }
            if (AyudaAduanero.Value != null)
            {
               Presenter.CCOT_CodigoAduanero = AyudaAduanero.Value.CCOT_Codigo;
            }
            else { Presenter.CCOT_CodigoAduanero = null; }
            if (AyudaTransporte.Value != null)
            {
               Presenter.CCOT_CodigoTransporte = AyudaTransporte.Value.CCOT_Codigo;
            }
            else { Presenter.CCOT_CodigoTransporte = null; }

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }
      #endregion

      #region [ Detalle Operación ]
      public void ShowItemsLogisticoDetalleOperacion()
      {
         try
         {
            if (Presenter.ItemsGrillaDet_Operacion != null)
               BSItemsLogistico.DataSource = Presenter.ItemsGrillaDet_Operacion.Where(var => var.Instance != InstanceEntity.Deleted).ToObservableCollection();
            else
               BSItemsLogistico.DataSource = null;
            grdItemsLogistico.DataSource = BSItemsLogistico;
            navItemsLogistico.BindingSource = BSItemsLogistico;
            BSItemsLogistico.ResetBindings(true);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      public void ShowItemsAduaneroDetalleOperacion()
      {
         try
         {
            if (Presenter.ItemsDet_OperacionRegistros != null)
               BSItemsAduanero.DataSource = Presenter.ItemsDet_OperacionRegistros.Where(var => var.Instance != InstanceEntity.Deleted && var.CTAR_Tipo == "A").ToObservableCollection();
            grdItemsAduanero.DataSource = BSItemsAduanero;
            navItemsAduanero.BindingSource = BSItemsAduanero;
            BSItemsAduanero.ResetBindings(true);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      public void ShowItemsTransporteDetalleOperacion()
      {
         try
         {
            if (Presenter.ItemsDet_OperacionRegistros != null)
               BSItemsTransporte.DataSource = Presenter.ItemsDet_OperacionRegistros.Where(var => var.Instance != InstanceEntity.Deleted && var.CTAR_Tipo == "T").ToObservableCollection();
            grdItemsTransporte.DataSource = BSItemsTransporte;
            navItemsTransporte.BindingSource = BSItemsTransporte;
            BSItemsTransporte.ResetBindings(true);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      public void SetItemST20_ST40_HBL(ref ObservableCollection<Det_Operacion> xItems, Boolean xBuscar)
      {
         try
         {
            if (xItems != null)
            {
               decimal tempVenta20 = 0;
               decimal tempVentaSada20 = 0;
               decimal tempVenta40 = 0;
               decimal tempVentaSada40 = 0;
               decimal tempCosto20 = 0;
               decimal tempCosto40 = 0;
               decimal tempCostoHBL = 0;
               decimal tempCosto20SADA = 0;
               decimal tempCosto40SADA = 0;
               decimal tempCostoHBLSADA = 0;
               Int16 tempCantidad20 = 0;
               Int16 tempCantidad40 = 0;
               decimal total20 = 0;
               decimal total40 = 0;
               decimal totalHBL = 0;
               TxtNroCotizacion.Text = Presenter.CCOT_NumDoc;
               var _Det_Operacion = new Det_Operacion();
               Det_Operacion _DetalleOperacion = new Det_Operacion();
               var fila = 0;
               if (Presenter.ItemsDet_OperacionRegistros == null)
                  Presenter.ItemsDet_OperacionRegistros = new ObservableCollection<Det_Operacion>();
               if (Presenter.ItemsGrillaDet_Operacion == null || Presenter.ItemsGrillaDet_Operacion.Count == 0)
                  Presenter.ItemsGrillaDet_Operacion = new ObservableCollection<Det_Operacion>();

               for (var i = 0; i < xItems.Count; i++)
               {
                  if (((i % 2) == 0) && i == 0)   /* primer registro */
                  {
                     _Det_Operacion = new Det_Operacion();
                     _Det_Operacion = xItems.ElementAt(i);
                     fila = 1;
                  }
                  else
                  {
                     _Det_Operacion = xItems.ElementAt(i);
                     _Det_Operacion.DOPE_Cantidad20 = tempCantidad20;
                     _Det_Operacion.DOPE_Cantidad40 = tempCantidad40;
                     _Det_Operacion.DOPE_Venta20 = tempVenta20;
                     _Det_Operacion.DOPE_VentaSada20 = tempVentaSada20;
                     _Det_Operacion.DOPE_Venta40 = tempVenta40;
                     _Det_Operacion.DOPE_VentaSada40 = tempVentaSada40;
                     _Det_Operacion.DOPE_CostoSada20 = tempCosto20SADA;
                     _Det_Operacion.DOPE_Costo20 = tempCosto20;
                     _Det_Operacion.DOPE_Costo40 = tempCosto40;
                     _Det_Operacion.DOPE_CostoSada40 = tempCosto40SADA;
                  }
                  if (_Det_Operacion.PACK_Codigo == 1)
                  {
                     tempCantidad20 = 0;
                     tempVenta20 = 0;
                     tempVentaSada20 = 0;
                     total20 = 0;
                     total40 = 0;
                     totalHBL = 0;
                     _Det_Operacion.DOPE_Cantidad20 = xItems[i].DOPE_Cantidad;
                     _Det_Operacion.DOPE_Venta20 = xItems[i].DOPE_Venta;
                     _Det_Operacion.DOPE_VentaSada20 = _Det_Operacion.DOPE_VentaSada;
                     _Det_Operacion.DOPE_Costo20 = xItems[i].DOPE_Costo;
                     _Det_Operacion.DOPE_CostoSada20 = xItems[i].DOPE_CostoSada;
                     tempCantidad20 = _Det_Operacion.DOPE_Cantidad20;
                     tempVenta20 = _Det_Operacion.DOPE_Venta20;
                     tempVentaSada20 = _Det_Operacion.DOPE_VentaSada20;
                     tempCosto20 = _Det_Operacion.DOPE_Costo20;
                     tempCosto20SADA = _Det_Operacion.DOPE_CostoSada20;
                     _Det_Operacion.DOPE_Fila = fila;
                     if (Presenter.ItemCab_Operacion.Instance == InstanceEntity.Added) { _Det_Operacion.Validado = false; } else { _Det_Operacion.Validado = true; }

                     total20 += Presenter.PrecioSada ? _Det_Operacion.DOPE_Cantidad20 * _Det_Operacion.DOPE_VentaSada20 : _Det_Operacion.DOPE_Cantidad20 * _Det_Operacion.DOPE_Venta20;
                     _DetalleOperacion = _Det_Operacion.Clone();
                     Presenter.ItemsDet_OperacionRegistros.Add(_DetalleOperacion);
                  }

                  if (_Det_Operacion.PACK_Codigo == 2)
                  {
                     tempCantidad40 = 0;
                     tempVenta40 = 0;
                     tempVentaSada40 = 0;
                     _Det_Operacion.DOPE_Cantidad40 = xItems[i].DOPE_Cantidad;
                     _Det_Operacion.DOPE_Venta40 = xItems[i].DOPE_Venta;
                     _Det_Operacion.DOPE_VentaSada40 = _Det_Operacion.DOPE_VentaSada;
                     _Det_Operacion.DOPE_Costo40 = xItems[i].DOPE_Costo;
                     _Det_Operacion.DOPE_CostoSada40 = xItems[i].DOPE_CostoSada;
                     tempCantidad40 = _Det_Operacion.DOPE_Cantidad40;
                     tempVenta40 = _Det_Operacion.DOPE_Venta40;
                     tempVentaSada40 = _Det_Operacion.DOPE_VentaSada40;
                     tempCosto40 = _Det_Operacion.DOPE_Costo40;
                     tempCosto40SADA = _Det_Operacion.DOPE_CostoSada40;
                     //total += x_items[i].DOPE_PrecioTotVta;
                     total40 += Presenter.PrecioSada ? _Det_Operacion.DOPE_Cantidad40 * _Det_Operacion.DOPE_VentaSada40 : _Det_Operacion.DOPE_Cantidad40 * _Det_Operacion.DOPE_Venta40;

                     if (_Det_Operacion.TIPE_Codigo != null && _Det_Operacion.TIPE_Codigo.Value != 13) /* Maritimo */
                     {
                        _Det_Operacion.DOPE_Fila = fila;
                        if (Presenter.ItemCab_Operacion.Instance == InstanceEntity.Added) { _Det_Operacion.Validado = false; } else { _Det_Operacion.Validado = true; }
                        if (!xBuscar)
                        {
                           _Det_Operacion.DOPE_PrecioTotVta = total20 + total40 + totalHBL;
                        }
                        //Presenter.ItemsDet_OperacionRegistros.Add(_Det_Operacion);
                        _DetalleOperacion = _Det_Operacion.Clone();
                        Presenter.ItemsDet_OperacionRegistros.Add(_DetalleOperacion);
                        Presenter.ItemsGrillaDet_Operacion.Add(_Det_Operacion);
                        fila++;
                     }
                     else
                     {
                        _Det_Operacion.DOPE_Fila = fila;
                        _DetalleOperacion = _Det_Operacion.Clone();
                        Presenter.ItemsDet_OperacionRegistros.Add(_DetalleOperacion);
                        //Presenter.ItemsDet_OperacionRegistros.Add(_Det_Operacion);
                     }
                  }
                  if (_Det_Operacion.TIPE_Codigo != null && _Det_Operacion.TIPE_Codigo.Value == 13) /* Maritimo */
                  {
                     if (_Det_Operacion.PACK_Codigo == null)
                     {
                        _Det_Operacion.DOPE_VentaHBL = xItems[i].DOPE_Venta;
                        _Det_Operacion.DOPE_VentaSadaHBL = _Det_Operacion.DOPE_VentaSada;
                        _Det_Operacion.DOPE_CostoHBL = xItems[i].DOPE_Costo;
                        _Det_Operacion.DOPE_CostoSadaHBL = xItems[i].DOPE_CostoSada;
                        _Det_Operacion.DOPE_Cantidad = xItems[i].DOPE_Cantidad;
                        _Det_Operacion.DOPE_Fila = fila;
                        totalHBL += (Presenter.PrecioSada ? _Det_Operacion.DOPE_VentaSadaHBL : _Det_Operacion.DOPE_VentaHBL) * xItems[i].DOPE_Cantidad;
                        if (Presenter.ItemCab_Operacion.Instance == InstanceEntity.Added) { _Det_Operacion.Validado = false; } else { _Det_Operacion.Validado = true; }
                        if (!xBuscar)
                        {
                           _Det_Operacion.DOPE_PrecioTotVta = total20 + total40 + totalHBL;
                        }
                        _DetalleOperacion = _Det_Operacion.Clone();
                        Presenter.ItemsDet_OperacionRegistros.Add(_DetalleOperacion);
                        //Presenter.ItemsDet_OperacionRegistros.Add(_Det_Operacion);
                        Presenter.ItemsGrillaDet_Operacion.Add(_Det_Operacion);
                        fila++;

                     }
                  }
               }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar el nuevo registro.", ex); }
      }
      public void ClearItemsDetallesOperacion()
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

            Presenter.ItemsDet_Operacion = new ObservableCollection<Det_Operacion>();
            Presenter.ItemsDet_Cotizacion = new ObservableCollection<Det_Cotizacion>();
            Presenter.ItemsDet_OperacionLogistico = new ObservableCollection<Det_Operacion>();
            Presenter.ItemsDet_OperacionAduanero = new ObservableCollection<Det_Operacion>();
            Presenter.ItemsDet_OperacionTransporte = new ObservableCollection<Det_Operacion>();
            Presenter.ItemsDet_Operacion = new ObservableCollection<Det_Operacion>();
            Presenter.ItemsDet_OperacionRegistros = new ObservableCollection<Det_Operacion>();
            Presenter.ItemsGrillaDet_Operacion = new ObservableCollection<Det_Operacion>();
            //Presenter.TempItemDet_OperacionServicio = new Det_Operacion_Servicio();
            Presenter.ItemsDet_OperacionServicio = new ObservableCollection<Det_Operacion_Servicio>();
            Presenter.ItemsDet_Cotizacion_Servicio_parcial = new ObservableCollection<Det_Cotizacion_Servicio>();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      #endregion

      #region [ Detalle Servicios ]
      public void ClearItemsDetalleServiciosOperactivo()
      {
         try
         {
            BSItemsServicios.DataSource = null;
            grdItemsServicios.DataSource = null;
            navItemsServicios.BindingSource = null;
            Presenter.ItemsDet_OperacionServicio = new ObservableCollection<Det_Operacion_Servicio>();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void ShowItemsDetalleServiciosOperativo()
      {
         try
         {
            if (Presenter.ItemsDet_OperacionServicio != null)
               BSItemsServicios.DataSource = Presenter.ItemsDet_OperacionServicio.Where(var => var.Instance != InstanceEntity.Deleted).ToObservableCollection();
            else
               BSItemsServicios.DataSource = Presenter.ItemsDet_OperacionServicio;
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
            String mensajeError = "";
            if (chkCTAR_Aduanero.Checked)
            {
               if (String.IsNullOrEmpty(txtCOPE_Fob.Value.ToString()) || txtCOPE_Fob.Value == 0)
               {
                  mensajeError += "Debe ingresar el campo FOB" + Environment.NewLine;
               }
               if (String.IsNullOrEmpty(txtCOPE_Flete.Value.ToString()) || txtCOPE_Flete.Value == 0)
               {
                  mensajeError += "Debe ingresar el campo Flete" + Environment.NewLine;
               }
               if (String.IsNullOrEmpty(txtCOPE_Seguro.Value.ToString()) || txtCOPE_Seguro.Value == 0)
               {
                  mensajeError += "Debe ingresar el campo Seguro" + Environment.NewLine;
               }
               if (String.IsNullOrEmpty(txtCOPE_Cif.Value.ToString()) || txtCOPE_Cif.Value == 0)
               {
                  mensajeError += "Debe ingresar el campo CIF" + Environment.NewLine;
               }
               if (String.IsNullOrEmpty(txtCOPE_PartArancelaria.Value.ToString()) || txtCOPE_PartArancelaria.Value == 0)
               {
                  mensajeError += "Debe ingresar el campo Parte Arancelaria" + Environment.NewLine;
               }
               if (String.IsNullOrEmpty(txtCOPE_AdValorem.Value.ToString()) || txtCOPE_AdValorem.Value == 0)
               {
                  mensajeError += "Debe ingresar el campo Ad Valorem" + Environment.NewLine;
               }
               if (CbCONS_CodCRG.SelectedItem == null)
               {
                  mensajeError += "Debe ingresar el campo Tipo de Carga" + Environment.NewLine;
               }
               if (mensajeError != "")
               {
                  Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", mensajeError, Dialogos.Boton.Detalles);
                  return;
               }
            }
            if (Presenter.GuardarOperacion())
            {
               errorProvider1.Dispose();
               Close();
            }
         }
         catch (Exception)
         { }
      }
      private void CalculosCif()
      {
         try
         {
            Presenter.COPE_Fob = txtCOPE_Fob.Value > 0 ? txtCOPE_Fob.Value : 0;
            Presenter.COPE_Flete = txtCOPE_Flete.Value > 0 ? txtCOPE_Flete.Value : 0;
            Presenter.COPE_Seguro = txtCOPE_Seguro.Value > 0 ? txtCOPE_Seguro.Value : 0;
            decimal valores = (txtCOPE_Fob.Value + txtCOPE_Flete.Value + txtCOPE_Seguro.Value);
            txtCOPE_Cif.Value = valores;
            txtCOPE_Cif.Text = valores.ToString(CultureInfo.InvariantCulture);
            if (txtCOPE_Fob.Value > 0 && txtCOPE_Flete.Value > 0 && txtCOPE_Seguro.Value > 0)
            {
               Presenter.CCOT_CIF = valores;
            }
            else
            {
               Presenter.CCOT_CIF = 0;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al realizar los calculos.", ex); }
      }
      private void CalculosAdValorem()
      {
         try
         {
            var valores = (txtCOPE_PartArancelaria.Value / 100) * txtCOPE_Cif.Value;
            txtCOPE_AdValorem.Value = valores;
            txtCOPE_AdValorem.Text = valores.ToString(CultureInfo.InvariantCulture);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al realizar los calculos.", ex); }
      }
      private String Habilitar(ref String mensajeError)
      {
         if (Presenter.COPE_Fob == 0)
         {
            mensajeError += "* Debe ingresar el campo Fob. " + Environment.NewLine;
         }
         if (Presenter.COPE_Flete == 0)
         {
            mensajeError += "* Debe ingresar el campo Flete. " + Environment.NewLine;
         }
         if (Presenter.COPE_Seguro == 0)
         {
            mensajeError += "* Debe ingresar el campo Seguro. " + Environment.NewLine;
         }
         return mensajeError;
      }
      private void LimpiarAyudaTransportista()
      {
         AyudaTransporte.Enabled = false;
         AyudaTransporte.ENTC_CodigoCliente = null;
         AyudaTransporte.CCOT_Codigo = 0;
         AyudaTransporte.ClearValue();
         Presenter.LimpiarServicioAdicional("T");
         ShowItemsDetalleServiciosOperativo();
      }
      private void LimpiarAyudaAduanero()
      {
         AyudaAduanero.Enabled = false;
         AyudaAduanero.ClearValue();
         AyudaAduanero.ENTC_CodigoCliente = null;
         Presenter.LimpiarServicioAdicional("A");
         ShowItemsDetalleServiciosOperativo();
      }
      private void LimpiarAyudaLogistico()
      {
         AyudaLogistico.Enabled = false;
         AyudaLogistico.ClearValue();
         AyudaLogistico.ENTC_CodigoCliente = null;
         AyudaLogistico.ENTC_CodigoLNaviera = null;
         AyudaLogistico.CCOT_Codigo = 0;
         Presenter.LimpiarServicioAdicional("L");

         ShowItemsDetalleServiciosOperativo();
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
            grdItemsLogistico.Columns["TIPE_Descripcion"].Width = 110;

            grdItemsLogistico.Columns.Add("ENTC_RazonSocial", "Entidad", "ENTC_RazonSocial");
            grdItemsLogistico.Columns["ENTC_RazonSocial"].Width = 200;

            grdItemsLogistico.Columns.Add("DOPE_Cantidad20", "Cant. 20", "DOPE_Cantidad20");
            grdItemsLogistico.Columns["DOPE_Cantidad20"].Width = 50;
            grdItemsLogistico.Columns["DOPE_Cantidad20"].FormatString = @"{0:###,##0.00}";
            grdItemsLogistico.Columns["DOPE_Cantidad20"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsLogistico.Columns["DOPE_Cantidad20"].TextAlignment = ContentAlignment.MiddleRight;

            grdItemsLogistico.Columns.Add("DOPE_Cantidad40", "Cant. 40", "DOPE_Cantidad40");
            grdItemsLogistico.Columns["DOPE_Cantidad40"].Width = 50;
            grdItemsLogistico.Columns["DOPE_Cantidad40"].FormatString = @"{0:###,##0.00}";
            grdItemsLogistico.Columns["DOPE_Cantidad40"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsLogistico.Columns["DOPE_Cantidad40"].TextAlignment = ContentAlignment.MiddleRight;


            grdItemsLogistico.Columns.Add("DOPE_Venta20", "Venta", "DOPE_Venta20");
            grdItemsLogistico.Columns["DOPE_Venta20"].Width = 60;
            grdItemsLogistico.Columns["DOPE_Venta20"].FormatString = @"{0:###,##0.00}";
            grdItemsLogistico.Columns["DOPE_Venta20"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsLogistico.Columns["DOPE_Venta20"].TextAlignment = ContentAlignment.MiddleRight;

            grdItemsLogistico.Columns.Add("DOPE_VentaSada20", "Venta Sada", "DOPE_VentaSada20");
            grdItemsLogistico.Columns["DOPE_VentaSada20"].Width = 70;
            grdItemsLogistico.Columns["DOPE_VentaSada20"].FormatString = @"{0:###,##0.00}";
            grdItemsLogistico.Columns["DOPE_VentaSada20"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsLogistico.Columns["DOPE_VentaSada20"].TextAlignment = ContentAlignment.MiddleRight;

            grdItemsLogistico.Columns.Add("DOPE_Venta40", "Venta", "DOPE_Venta40");
            grdItemsLogistico.Columns["DOPE_Venta40"].Width = 60;
            grdItemsLogistico.Columns["DOPE_Venta40"].FormatString = @"{0:###,##0.00}";
            grdItemsLogistico.Columns["DOPE_Venta40"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsLogistico.Columns["DOPE_Venta40"].TextAlignment = ContentAlignment.MiddleRight;

            grdItemsLogistico.Columns.Add("DOPE_VentaSada40", "Venta Sada", "DOPE_VentaSada40");
            grdItemsLogistico.Columns["DOPE_VentaSada40"].Width = 70;
            grdItemsLogistico.Columns["DOPE_VentaSada40"].FormatString = @"{0:###,##0.00}";
            grdItemsLogistico.Columns["DOPE_VentaSada40"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsLogistico.Columns["DOPE_VentaSada40"].TextAlignment = ContentAlignment.MiddleRight;

            grdItemsLogistico.Columns.Add("DOPE_VentaHBL", "HBL", "DOPE_VentaHBL");
            grdItemsLogistico.Columns["DOPE_VentaHBL"].Width = 60;
            grdItemsLogistico.Columns["DOPE_VentaHBL"].FormatString = @"{0:###,##0.00}";
            grdItemsLogistico.Columns["DOPE_VentaHBL"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsLogistico.Columns["DOPE_VentaHBL"].TextAlignment = ContentAlignment.MiddleRight;

            grdItemsLogistico.Columns.Add("DOPE_VentaSadaHBL", "HBL Sada", "DOPE_VentaSadaHBL");
            grdItemsLogistico.Columns["DOPE_VentaSadaHBL"].Width = 70;
            grdItemsLogistico.Columns["DOPE_VentaSadaHBL"].FormatString = @"{0:###,##0.00}";
            grdItemsLogistico.Columns["DOPE_VentaSadaHBL"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsLogistico.Columns["DOPE_VentaSadaHBL"].TextAlignment = ContentAlignment.MiddleRight;

            grdItemsLogistico.Columns.Add("DOPE_PrecioTotVta", "", "DOPE_PrecioTotVta");
            grdItemsLogistico.Columns["DOPE_PrecioTotVta"].Width = 70;
            grdItemsLogistico.Columns["DOPE_PrecioTotVta"].FormatString = @"{0:###,##0.00}";
            grdItemsLogistico.Columns["DOPE_PrecioTotVta"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsLogistico.Columns["DOPE_PrecioTotVta"].TextAlignment = ContentAlignment.MiddleRight;


            var columnGroupsView = new ColumnGroupsViewDefinition();
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Acciones"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Datos Generales"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Cantidades"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Standar 20"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Standar 40"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("HBL"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Total"));

            columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grdItemsLogistico.Columns["Edit"]);
            columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grdItemsLogistico.Columns["Delete"]);

            columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grdItemsLogistico.Columns["TIPE_Descripcion"]);
            columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grdItemsLogistico.Columns["ENTC_RazonSocial"]);

            columnGroupsView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItemsLogistico.Columns["DOPE_Cantidad20"]);
            columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItemsLogistico.Columns["DOPE_Cantidad40"]);

            columnGroupsView.ColumnGroups[3].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(grdItemsLogistico.Columns["DOPE_Venta20"]);
            columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(grdItemsLogistico.Columns["DOPE_VentaSada20"]);

            columnGroupsView.ColumnGroups[4].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[4].Rows[0].Columns.Add(grdItemsLogistico.Columns["DOPE_Venta40"]);
            columnGroupsView.ColumnGroups[4].Rows[0].Columns.Add(grdItemsLogistico.Columns["DOPE_VentaSada40"]);

            columnGroupsView.ColumnGroups[5].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[5].Rows[0].Columns.Add(grdItemsLogistico.Columns["DOPE_VentaHBL"]);
            columnGroupsView.ColumnGroups[5].Rows[0].Columns.Add(grdItemsLogistico.Columns["DOPE_VentaSadaHBL"]);

            columnGroupsView.ColumnGroups[6].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[6].Rows[0].Columns.Add(grdItemsLogistico.Columns["DOPE_PrecioTotVta"]);

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

            grdItemsAduanero.Columns.Add("DOPE_Venta", "Comisión", "DOPE_Venta");
            grdItemsAduanero.Columns["DOPE_Venta"].Width = 70;
            grdItemsAduanero.Columns["DOPE_Venta"].FormatString = @"{0:###,##0.00}";
            grdItemsAduanero.Columns["DOPE_Venta"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsAduanero.Columns["DOPE_Venta"].TextAlignment = ContentAlignment.MiddleRight;

            grdItemsAduanero.Columns.Add("DOPE_Minimo", "Minimo", "DOPE_Minimo");
            grdItemsAduanero.Columns["DOPE_Minimo"].Width = 70;
            grdItemsAduanero.Columns["DOPE_Minimo"].FormatString = @"{0:###,##0.00}";
            grdItemsAduanero.Columns["DOPE_Minimo"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsAduanero.Columns["DOPE_Minimo"].TextAlignment = ContentAlignment.MiddleRight;

            grdItemsAduanero.Columns.Add("DOPE_PrecioTotVta", "Total", "DOPE_PrecioTotVta");
            grdItemsAduanero.Columns["DOPE_PrecioTotVta"].Width = 70;
            grdItemsAduanero.Columns["DOPE_PrecioTotVta"].FormatString = @"{0:###,##0.00}";
            grdItemsAduanero.Columns["DOPE_PrecioTotVta"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsAduanero.Columns["DOPE_PrecioTotVta"].TextAlignment = ContentAlignment.MiddleRight;

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

            grdItemsTransporte.Columns.Add("DOPE_Venta", "Flete", "DOPE_Venta");
            grdItemsTransporte.Columns["DOPE_Venta"].Width = 70;
            grdItemsTransporte.Columns["DOPE_Venta"].FormatString = @"{0:###,##0.00}";
            grdItemsTransporte.Columns["DOPE_Venta"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsTransporte.Columns["DOPE_Venta"].TextAlignment = ContentAlignment.MiddleRight;

            grdItemsTransporte.Columns.Add("CONS_Desc_SPA", "Base", "CONS_Desc_SPA");
            grdItemsTransporte.Columns["CONS_Desc_SPA"].Width = 120;

            grdItemsTransporte.Columns.Add("ORIGEN", "Origen", "ORIGEN");
            grdItemsTransporte.Columns["ORIGEN"].Width = 150;

            grdItemsTransporte.Columns.Add("DESTINO", "Destino", "DESTINO");
            grdItemsTransporte.Columns["DESTINO"].Width = 150;

            grdItemsTransporte.Columns.Add("DOPE_PrecioTotVta", "Total", "DOPE_PrecioTotVta");
            grdItemsTransporte.Columns["DOPE_PrecioTotVta"].Width = 70;
            grdItemsTransporte.Columns["DOPE_PrecioTotVta"].FormatString = @"{0:###,##0.00}";
            grdItemsTransporte.Columns["DOPE_PrecioTotVta"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsTransporte.Columns["DOPE_PrecioTotVta"].TextAlignment = ContentAlignment.MiddleRight;

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
               if (BSItemsLogistico != null && BSItemsLogistico.Current != null && BSItemsLogistico.Current is Det_Operacion)
               {
                  Presenter.ItemDet_Operacion = ((Det_Operacion)BSItemsLogistico.Current);
               }
               else { Presenter.ItemDet_Operacion = null; }
            }
         }
         catch (Exception ex)
         {
            if (Presenter != null)
               Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex);
         }
      }
      private void SeleccionarItemAduanero()
      {
         try
         {
            if (Presenter == null) return;
            if (BSItemsAduanero != null && BSItemsAduanero.Current != null && BSItemsAduanero.Current is Det_Operacion)
            {
               Presenter.ItemDet_Operacion = ((Det_Operacion)BSItemsAduanero.Current);
            }
            else { Presenter.ItemDet_Operacion = null; }
         }
         catch (Exception ex)
         {
            if (Presenter != null)
               Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex);
         }
      }
      private void SeleccionarItemTransporte()
      {
         try
         {
            if (Presenter != null)
            {
               if (BSItemsTransporte != null && BSItemsTransporte.Current != null && BSItemsTransporte.Current is Det_Operacion)
               {
                  Presenter.ItemDet_Operacion = ((Det_Operacion)BSItemsTransporte.Current);

               }
               else { Presenter.ItemDet_Operacion = null; }
            }
         }
         catch (Exception ex)
         {
            if (Presenter != null)
               Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex);
         }
      }
      private bool BloquearBotonesServicios()
      {
         if (Presenter.ItemDet_Operacion.CONS_CodEST == "001" || String.IsNullOrEmpty(Presenter.ItemDet_Operacion.CONS_CodEST)) return false;
         String _Estado = "";
         switch (Presenter.ItemDet_Operacion.CONS_CodEST)
         {
            case "002":
               {
                  _Estado = "Facturado por el Proveedor";
                  break;
               }
            case "003":
               {
                  _Estado = "PreFacturado";
                  break;
               }
            case "004":
               {
                  _Estado = "Facturado";
                  break;
               }
         }
         Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se puede editar el Item porque ha sido " + _Estado);
         return true;
      }
      private bool BloquearBotonesServiciosAdicionales()
      {
         if (Presenter.ItemDet_OperacionServicio.CONS_CodEST == "001" || String.IsNullOrEmpty(Presenter.ItemDet_OperacionServicio.CONS_CodEST)) return false;
         String _Estado = "";
         switch (Presenter.ItemDet_OperacionServicio.CONS_CodEST)
         {
            case "002":
               {
                  _Estado = "Facturado por el Proveedor";
                  break;
               }
            case "003":
               {
                  _Estado = "PreFacturado";
                  break;
               }
            case "004":
               {
                  _Estado = "Facturado";
                  break;
               }
         }
         Dialogos.MostrarMensajeInformacion(Presenter.Title, "No Se puede eliminar el Item porque ha sido " + _Estado);
         return true;
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

            grdItemsServicios.Columns.Add("SOPE_Cantidad", "Cantidad", "SOPE_Cantidad");
            grdItemsServicios.Columns["SOPE_Cantidad"].Width = 70;
            grdItemsServicios.Columns["SOPE_Cantidad"].FormatString = @"{0:###,##0.00}";
            grdItemsServicios.Columns["SOPE_Cantidad"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsServicios.Columns["SOPE_Cantidad"].TextAlignment = ContentAlignment.MiddleRight;

            grdItemsServicios.Columns.Add("SOPE_PrecioUni", "Precio Unit.", "SOPE_PrecioUni");
            grdItemsServicios.Columns["SOPE_PrecioUni"].Width = 80;
            grdItemsServicios.Columns["SOPE_PrecioUni"].FormatString = @"{0:###,##0.00}";
            grdItemsServicios.Columns["SOPE_PrecioUni"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsServicios.Columns["SOPE_PrecioUni"].TextAlignment = ContentAlignment.MiddleRight;

            grdItemsServicios.Columns.Add("CONS_Desc_Moneda", "Moneda", "CONS_Desc_Moneda");
            grdItemsServicios.Columns["CONS_Desc_Moneda"].Width = 60;

            grdItemsServicios.Columns.Add("CONS_Desc_Base", "Base", "CONS_Desc_Base");
            grdItemsServicios.Columns["CONS_Desc_Base"].Width = 80;

            grdItemsServicios.Columns.Add("SOPE_ImporteIngreso", "Ingreso", "SOPE_ImporteIngreso");
            grdItemsServicios.Columns["SOPE_ImporteIngreso"].Width = 70;
            grdItemsServicios.Columns["SOPE_ImporteIngreso"].FormatString = @"{0:###,##0.00}";
            grdItemsServicios.Columns["SOPE_ImporteIngreso"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsServicios.Columns["SOPE_ImporteIngreso"].TextAlignment = ContentAlignment.MiddleRight;

            grdItemsServicios.Columns.Add("SOPE_ImporteEgreso", "Egreso", "SOPE_ImporteEgreso");
            grdItemsServicios.Columns["SOPE_ImporteEgreso"].Width = 70;
            grdItemsServicios.Columns["SOPE_ImporteEgreso"].FormatString = @"{0:###,##0.00}";
            grdItemsServicios.Columns["SOPE_ImporteEgreso"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItemsServicios.Columns["SOPE_ImporteEgreso"].TextAlignment = ContentAlignment.MiddleRight;

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
               if (BSItemsServicios != null && BSItemsServicios.Current != null && BSItemsServicios.Current is Det_Operacion_Servicio)
               {
                  Presenter.ItemDet_OperacionServicio = ((Det_Operacion_Servicio)BSItemsServicios.Current);
                  if (Presenter.ItemDet_OperacionServicio.SOPE_Item <= 0) return;
                  Presenter.ItemDet_OperacionServicio.AUDI_UsrMod = Presenter.Session.UserName;
                  Presenter.ItemDet_OperacionServicio.AUDI_FecMod = Presenter.Session.Fecha;
                  Presenter.ItemDet_OperacionServicio.Instance = InstanceEntity.Modified;
               }
               else
               { Presenter.ItemDet_OperacionServicio = null; }
            }
         }
         catch (Exception ex)
         {
            if (Presenter != null)
               Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex);
         }
      }
      #endregion

      #endregion

      #region [ Eventos ]

      #region [ Encabezado Operación ]

      private void btnGuardar_Click(object sender, EventArgs e)
      { Guardar(); }
      void btnFacturacion_Click(object sender, EventArgs e)
      {

      }
      void btnPreFactura_Click(object sender, EventArgs e)
      {

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
      void PRO003MView_Load(object sender, EventArgs e)
      {
         TabCotizacion.SelectedTab = TabPageServicios;
         TabControlDetalleCotizacion.SelectedTab = TabPageLogistico;
      }
      void chkCTAR_Transporte_CheckedChanged(object sender, EventArgs e)
      {
         try
         {
            if (!_CheckTransporteManual)
            {

               String mensajeError = String.Empty;
               if (chkCTAR_Transporte.Checked)
               {
                  if (AyudaENTC_CodCliente.Value != null)
                  {
                     AyudaTransporte.ENTC_CodigoCliente = AyudaENTC_CodCliente.Value.ENTC_Codigo;
                     AyudaTransporte.CCOT_Codigo = Presenter.CCOT_Codigo;
                     AyudaTransporte.Enabled = true;
                  }
                  else
                  {
                     Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", "Debe ingresar el cliente de la ficha datos generales", Dialogos.Boton.Detalles);
                     chkCTAR_Transporte.Checked = false;
                     return;
                  }
               }
               else
               {
                  if (ValidaEstadoServiciosTransporte())
                  {
                     LimpiarAyudaTransportista();
                  }
                  else
                  {
                     Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se puede Eliminar los Servicios debido a que estan referenciados");
                     _CheckTransporteManual = true;
                     chkCTAR_Transporte.Checked = true;
                  }

               }
            }
            else
            {
               _CheckTransporteManual = false;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido una error al activar la casilla de verificación", ex); }
      }
      void chkCTAR_Aduanero_CheckedChanged(object sender, EventArgs e)
      {
         try
         {
            if (!_CheckLogisticoManual)
            {
               String mensajeError = String.Empty;
               if (chkCTAR_Aduanero.Checked)
               {
                  if (AyudaENTC_CodCliente.Value != null)
                  {
                     AyudaAduanero.ENTC_CodigoCliente = AyudaENTC_CodCliente.Value.ENTC_Codigo;
                     AyudaAduanero.CCOT_Codigo = AyudaAduanero.CCOT_Codigo;
                     //AyudaAduanero.ENTC_CodigoLNaviera =  ???
                  }
                  else
                  {
                     Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", "Debe ingresar el cliente de la ficha datos generales", Dialogos.Boton.Detalles);
                     chkCTAR_Aduanero.Checked = false;
                     return;
                  }
                  if (String.IsNullOrEmpty(Habilitar(ref mensajeError)))
                  {
                     AyudaAduanero.Enabled = true;
                  }
                  else
                  {
                     Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", mensajeError, Dialogos.Boton.Detalles);
                     chkCTAR_Aduanero.Checked = false;
                  }
               }
               else
               {
                  if (ValidaEstadoServiciosAduaneros())
                  {
                     LimpiarAyudaAduanero();
                  }
                  else
                  {
                     Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se puede Eliminar los Servicios debido a que estan referenciados");
                     _CheckAduaneroManual = true;
                     chkCTAR_Aduanero.Checked = true;
                  }

               }
            }
            else
            {
               _CheckAduaneroManual = false;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido una error al activar la casilla de verificación", ex); }
      }
      void chkCTAR_Logistico_CheckedChanged(object sender, EventArgs e)
      {
         try
         {
            if (!_CheckLogisticoManual)
            {
               String mensajeError = String.Empty;
               if (chkCTAR_Logistico.Checked)
               {
                  if (AyudaENTC_CodCliente.Value != null)
                  {
                     AyudaLogistico.ENTC_CodigoCliente = AyudaENTC_CodCliente.Value.ENTC_Codigo;
                     AyudaLogistico.CCOT_Codigo = Presenter.CCOT_Codigo;
                     if (AyudaENTC_CodTransporte.Value != null)
                        AyudaLogistico.ENTC_CodigoLNaviera = AyudaENTC_CodTransporte.Value.ENTC_Codigo;
                  }
                  else
                  {
                     Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", "Debe ingresar el cliente de la ficha datos generales", Dialogos.Boton.Detalles);
                     chkCTAR_Logistico.Checked = false;

                     return;
                  }
                  AyudaLogistico.Enabled = true;
               }
               else
               {
                  if (ValidaEstadoServiciosLogisticos())
                  {
                     LimpiarAyudaLogistico();
                  }
                  else
                  {
                     Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se puede Eliminar los Servicios debido a que estan referenciados");
                     _CheckLogisticoManual = true;
                     chkCTAR_Logistico.Checked = true;
                  }
               }
            }
            else
            {
               _CheckLogisticoManual = false;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido una error al activar la casilla de verificación", ex); }
      }

      private Boolean ValidaEstadoServiciosLogisticos()
      {
         try
         {
            for (int i = 0; i < grdItemsLogistico.RowCount; i++)
            {
               grdItemsLogistico.Rows[i].IsSelected = true;
               if (BSItemsLogistico != null && BSItemsLogistico.Current != null && BSItemsLogistico.Current is Det_Operacion)
               {
                  Presenter.ItemDet_Operacion = ((Det_Operacion)BSItemsLogistico.Current);
                  if (Presenter.ItemDet_Operacion.CONS_CodEST != "001" || String.IsNullOrEmpty(Presenter.ItemDet_Operacion.CONS_CodEST)) return false;
               }
               else { Presenter.ItemDet_Operacion = null; }
            }
            return true;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido una error al activar la casilla de verificación de Servicios Logísticos", ex);
            return false;
         }
      }

      private Boolean ValidaEstadoServiciosTransporte()
      {
         try
         {
            for (int i = 0; i < grdItemsTransporte.RowCount; i++)
            {
               grdItemsTransporte.Rows[i].IsSelected = true;
               if (BSItemsTransporte != null && BSItemsTransporte.Current != null && BSItemsTransporte.Current is Det_Operacion)
               {
                  Presenter.ItemDet_Operacion = ((Det_Operacion)BSItemsTransporte.Current);
                  if (Presenter.ItemDet_Operacion.CONS_CodEST != "001" || String.IsNullOrEmpty(Presenter.ItemDet_Operacion.CONS_CodEST)) return false;
               }
               else { Presenter.ItemDet_Operacion = null; }
            }
            return true;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido una error al activar la casilla de verificación de Servicios de Transporte", ex);
            return false;
         }
      }

      private Boolean ValidaEstadoServiciosAduaneros()
      {
         try
         {
            for (int i = 0; i < grdItemsAduanero.RowCount; i++)
            {
               grdItemsAduanero.Rows[i].IsSelected = true;
               if (BSItemsAduanero != null && BSItemsAduanero.Current != null && BSItemsAduanero.Current is Det_Operacion)
               {
                  Presenter.ItemDet_Operacion = ((Det_Operacion)BSItemsAduanero.Current);
                  if (Presenter.ItemDet_Operacion.CONS_CodEST != "001" || String.IsNullOrEmpty(Presenter.ItemDet_Operacion.CONS_CodEST)) return false;
               }
               else { Presenter.ItemDet_Operacion = null; }
            }
            return true;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido una error al activar la casilla de verificación de Servicios Aduaneros", ex);
            return false;
         }
      }
      void AyudaTransporte_AyudaValueChanged(object sender, EventArgs e)
      {
         if (AyudaTransporte.Value != null)
         {
            Presenter.CCOT_CodigoLogistico = null;
            Presenter.CCOT_CodigoAduanero = null;
            Presenter.CCOT_CodigoTransporte = AyudaTransporte.Value.CCOT_Codigo;
            //if (Presenter.InstanciaEdicion != InstanceEntity.Modified)
            Presenter.BuscarCotizaciones();
            AyudaTransporte.CCOT_Codigo = Presenter.CCOT_Codigo;
            Presenter.Moneda = AyudaTransporte.Value.TIPO_CodMND;
            CbTIPO_CodMnd.TiposSelectedValue = Presenter.Moneda;
         }
         else
         {
            if (AyudaTransporte.Value == null)
            {
               LimpiarNroCotización();
               while (Presenter.ItemsDet_OperacionTransporte.FirstOrDefault(tipo => tipo.CTAR_Tipo == "T" && tipo.Instance != InstanceEntity.Deleted) != null)
               {
                  var _item = Presenter.ItemsDet_OperacionTransporte.First(tipo => tipo.CTAR_Tipo == "T" && tipo.Instance != InstanceEntity.Deleted);
                  if (_item.DOPE_Item > 0)
                  { _item.Instance = InstanceEntity.Deleted; }
                  else
                  { Presenter.ItemsDet_OperacionTransporte.Remove(_item); }
               }
               while (Presenter.ItemsDet_OperacionRegistros.FirstOrDefault(tipo => tipo.CTAR_Tipo == "T" && tipo.Instance != InstanceEntity.Deleted) != null)
               {
                  var _item = Presenter.ItemsDet_OperacionRegistros.First(tipo => tipo.CTAR_Tipo == "T" && tipo.Instance != InstanceEntity.Deleted);
                  if (_item.DOPE_Item > 0)
                  { _item.Instance = InstanceEntity.Deleted; }
                  else
                  { Presenter.ItemsDet_OperacionRegistros.Remove(_item); }
               }

               ShowItemsTransporteDetalleOperacion();
            }
         }
      }
      void AyudaAduanero_AyudaValueChanged(object sender, EventArgs e)
      {
         if (AyudaAduanero.Value != null)
         {
            Presenter.CCOT_CodigoLogistico = null;
            Presenter.CCOT_CodigoAduanero = AyudaAduanero.Value.CCOT_Codigo;
            Presenter.CCOT_CodigoTransporte = null;
            //if (Presenter.InstanciaEdicion != InstanceEntity.Modified)
            Presenter.BuscarCotizaciones();
            AyudaAduanero.CCOT_Codigo = Presenter.CCOT_Codigo;
            Presenter.Moneda = AyudaAduanero.Value.TIPO_CodMND;
            CbTIPO_CodMnd.TiposSelectedValue = Presenter.Moneda;
         }
         if (AyudaAduanero.Value == null)
         {
            LimpiarNroCotización();
            while (Presenter.ItemsDet_OperacionAduanero.FirstOrDefault(tipo => tipo.CTAR_Tipo == "A" && tipo.Instance != InstanceEntity.Deleted) != null)
            {
               var _item = Presenter.ItemsDet_OperacionAduanero.First(tipo => tipo.CTAR_Tipo == "A" && tipo.Instance != InstanceEntity.Deleted);
               if (_item.DOPE_Item > 0)
               { _item.Instance = InstanceEntity.Deleted; }
               else
               { Presenter.ItemsDet_OperacionAduanero.Remove(_item); }
            }
            while (Presenter.ItemsDet_OperacionRegistros.FirstOrDefault(tipo => tipo.CTAR_Tipo == "A" && tipo.Instance != InstanceEntity.Deleted) != null)
            {
               var _item = Presenter.ItemsDet_OperacionRegistros.First(tipo => tipo.CTAR_Tipo == "A" && tipo.Instance != InstanceEntity.Deleted);
               if (_item.DOPE_Item > 0)
               { _item.Instance = InstanceEntity.Deleted; }
               else
               { Presenter.ItemsDet_OperacionRegistros.Remove(_item); }
            }
            Presenter.LimpiarServicioAdicional("A");
            ShowItemsAduaneroDetalleOperacion();
            ShowItemsDetalleServiciosOperativo();
         }
      }

      void AyudaTransporte_AyudaGetValores(object sender, EventArgs e)
      {
         AyudaLogistico.ENTC_CodigoCliente = AyudaENTC_CodCliente.Value.ENTC_Codigo;
      }
      void AyudaAduanero_AyudaGetValores(object sender, EventArgs e)
      {
         AyudaAduanero.ENTC_CodigoCliente = AyudaENTC_CodCliente.Value.ENTC_Codigo;
      }
      void AyudaLogistico_AyudaGetValores(object sender, EventArgs e)
      {
         if (AyudaENTC_CodCliente.Value != null)
            AyudaLogistico.ENTC_CodigoCliente = AyudaENTC_CodCliente.Value.ENTC_Codigo;
         if (AyudaENTC_CodTransporte.Value != null)
            AyudaLogistico.ENTC_CodigoLNaviera = AyudaENTC_CodTransporte.Value.ENTC_Codigo;

      }

      void AyudaLogistico_AyudaValueChanged(object sender, EventArgs e)
      {
         if (AyudaLogistico.Value != null)
         {
            Presenter.CCOT_CodigoLogistico = AyudaLogistico.Value.CCOT_Codigo;
            Presenter.CCOT_CodigoAduanero = null;
            Presenter.CCOT_CodigoTransporte = null;
            Presenter.Moneda = AyudaLogistico.Value.TIPO_CodMND;
            //if (Presenter.InstanciaEdicion != InstanceEntity.Modified)
            Presenter.BuscarCotizaciones();
            AyudaLogistico.CCOT_Codigo = Presenter.CCOT_Codigo;
            CbTIPO_CodMnd.TiposSelectedValue = Presenter.Moneda;
            if (AyudaENTC_CodTransporte.Value == null)
               AyudaENTC_CodTransporte.SetValue(Convert.ToInt32(AyudaLogistico.Value.ENTC_Codigo));

         }
         if (AyudaLogistico.Value == null)
         {
            LimpiarNroCotización();
            Presenter.ItemsGrillaDet_Operacion = null;
            while (Presenter.ItemsDet_OperacionLogistico.FirstOrDefault(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted) != null)
            {
               var _item = Presenter.ItemsDet_OperacionLogistico.First(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted);
               if (_item.DOPE_Item > 0)
               { _item.Instance = InstanceEntity.Deleted; }
               else
               { Presenter.ItemsDet_OperacionLogistico.Remove(_item); }
            }
            while (Presenter.ItemsDet_OperacionRegistros.FirstOrDefault(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted) != null)
            {
               var _item = Presenter.ItemsDet_OperacionRegistros.First(tipo => tipo.CTAR_Tipo == "L" && tipo.Instance != InstanceEntity.Deleted);
               if (_item.DOPE_Item > 0)
               { _item.Instance = InstanceEntity.Deleted; }
               else
               { Presenter.ItemsDet_OperacionRegistros.Remove(_item); }
            }
            ShowItemsLogisticoDetalleOperacion();
            Presenter.LimpiarServicioAdicional("L");
            ShowItemsDetalleServiciosOperativo();
         }
      }

      private void LimpiarNroCotización()
      {
         if (AyudaAduanero.Value == null && AyudaTransporte.Value == null && AyudaLogistico.Value == null)
         {
            Presenter.CCOT_Codigo = 0;
            AyudaTransporte.CCOT_Codigo = Presenter.CCOT_Codigo;
            AyudaAduanero.CCOT_Codigo = Presenter.CCOT_Codigo;
            AyudaLogistico.CCOT_Codigo = Presenter.CCOT_Codigo;
         }
      }

      void ChkPrecioSada_CheckedChanged(object sender, EventArgs e)
      {
         Presenter.PrecioSada = ChkPrecioSada.Checked;
      }
      void txtCOPE_PartArancelaria_ValueChanged(object sender, EventArgs e)
      {
         CalculosAdValorem();
      }
      void txtCOPE_Seguro_ValueChanged(object sender, EventArgs e)
      {
         CalculosCif();
      }
      void txtCOPE_Flete_ValueChanged(object sender, EventArgs e)
      {
         CalculosCif();
      }
      void txtCOPE_Fob_ValueChanged(object sender, EventArgs e)
      {
         CalculosCif();
      }
      #endregion

      #region [ Detalle Cotizacion ]
      void grdItemsTransporte_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            //SeleccionarItemTransporte();
            if (!(e.CellElement is GridCommandCellElement)) return;
            if (e.Column.Name.Equals("Edit"))
            {
               var bte = (RadButtonElement)e.CellElement.Children[0];
               if (bte.Image == null)
               {
                  bte.TextImageRelation = TextImageRelation.Overlay;
                  bte.DisplayStyle = DisplayStyle.Image;
                  bte.ImageAlignment = ContentAlignment.MiddleCenter;
                  bte.Image = Resources.editar16x16;
                  bte.ToolTipText = @"Editar Registro";
                  bte.AutoSize = true;
                  //bte.Enabled = Presenter.ItemDet_Operacion.CONS_CodEST == "001" || String.IsNullOrEmpty(Presenter.ItemDet_Operacion.CONS_CodEST);
                  // //(Presenter.ItemDet_Operacion.CONS_CodEST =="002" || Presenter.ItemDet_Operacion.CONS_CodEST == "003" || Presenter.ItemDet_Operacion.CONS_CodEST == "004") // Terminada  - Pre-Facturada - Facturada
               }
            }
            if (e.Column.Name.Equals("Delete"))
            {
               var bte = (RadButtonElement)e.CellElement.Children[0];
               if (bte.Image == null)
               {
                  bte.TextImageRelation = TextImageRelation.Overlay;
                  bte.DisplayStyle = DisplayStyle.Image;
                  bte.ImageAlignment = ContentAlignment.MiddleCenter;
                  bte.Image = Resources.Sign_07;
                  bte.ToolTipText = @"Eliminar Registro";
                  bte.AutoSize = true;
                  //bte.Enabled = Presenter.ItemDet_Operacion.CONS_CodEST == "001" || String.IsNullOrEmpty(Presenter.ItemDet_Operacion.CONS_CodEST);
               }
            }
            if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
               e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
            }
         }
         catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      void grdItemsAduanero_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            //SeleccionarItemAduanero();
            if (!(e.CellElement is GridCommandCellElement)) return;
            if (e.Column.Name.Equals("Edit"))
            {
               var bte = (RadButtonElement)e.CellElement.Children[0];
               if (bte.Image == null)
               {
                  bte.TextImageRelation = TextImageRelation.Overlay;
                  bte.DisplayStyle = DisplayStyle.Image;
                  bte.ImageAlignment = ContentAlignment.MiddleCenter;
                  bte.Image = Resources.editar16x16;
                  bte.ToolTipText = @"Editar Registro";
                  bte.AutoSize = true;
                  //bte.Enabled = Presenter.ItemDet_Operacion.CONS_CodEST == "001" || String.IsNullOrEmpty(Presenter.ItemDet_Operacion.CONS_CodEST);
               }
            }
            if (e.Column.Name.Equals("Delete"))
            {
               var bte = (RadButtonElement)e.CellElement.Children[0];
               if (bte.Image == null)
               {
                  bte.TextImageRelation = TextImageRelation.Overlay;
                  bte.DisplayStyle = DisplayStyle.Image;
                  bte.ImageAlignment = ContentAlignment.MiddleCenter;
                  bte.Image = Resources.Sign_07;
                  bte.ToolTipText = @"Eliminar Registro";
                  bte.AutoSize = true;
                  //bte.Enabled = Presenter.ItemDet_Operacion.CONS_CodEST == "001" || String.IsNullOrEmpty(Presenter.ItemDet_Operacion.CONS_CodEST);
               }
            }
            if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
               e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
            }
         }
         catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      void grdItemsLogistico_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            //SeleccionarItemLogsitico();
            if (!(e.CellElement is GridCommandCellElement)) return;
            if (e.Column.Name.Equals("Edit"))
            {
               var bte = (RadButtonElement)e.CellElement.Children[0];
               if (bte.Image == null)
               {
                  bte.TextImageRelation = TextImageRelation.Overlay;
                  bte.DisplayStyle = DisplayStyle.Image;
                  bte.ImageAlignment = ContentAlignment.MiddleCenter;
                  bte.Image = Resources.editar16x16;
                  bte.ToolTipText = @"Editar Registro";
                  bte.AutoSize = true;
                  //bte.Enabled = ((Presenter.ItemDet_Operacion.CONS_CodEST == "001" || String.IsNullOrEmpty(Presenter.ItemDet_Operacion.CONS_CodEST)) && Presenter.CCOT_CIF > 0);
               }
            }
            if (e.Column.Name.Equals("Delete"))
            {
               var bte = (RadButtonElement)e.CellElement.Children[0];
               if (bte.Image == null)
               {
                  bte.TextImageRelation = TextImageRelation.Overlay;
                  bte.DisplayStyle = DisplayStyle.Image;
                  bte.ImageAlignment = ContentAlignment.MiddleCenter;
                  bte.Image = Resources.Sign_07;
                  bte.ToolTipText = @"Eliminar Registro";
                  bte.AutoSize = true;
                  //bte.Enabled = Presenter.ItemDet_Operacion.CONS_CodEST == "001" || String.IsNullOrEmpty(Presenter.ItemDet_Operacion.CONS_CodEST);
               }
            }
            if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
               e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
            }
         }
         catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      void grdItemsLogistico_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (!(sender is GridCommandCellElement)) return;
            SeleccionarItemLogsitico();
            switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
            {
               case "Editar":
                  if (!BloquearBotonesServicios())
                  {
                     Presenter.EditarDetalleOperacion();
                  }
                  break;
               case "Eliminar":
                  if (!BloquearBotonesServicios())
                  {
                     Presenter.EliminarDetalleOperacion();
                  }
                  break;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar el registro.", ex); }
      }
      void grdItemsTransporte_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (!(sender is GridCommandCellElement)) return;
            SeleccionarItemTransporte();
            switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
            {
               case "Editar":
                  if (!BloquearBotonesServicios())
                  {
                     Presenter.EditarDetalleOperacion();
                  }
                  break;
               case "Eliminar":
                  if (!BloquearBotonesServicios())
                  {
                     Presenter.EliminarDetalleOperacion();
                  }
                  break;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar el registro.", ex); }
      }
      void grdItemsAduanero_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (!(sender is GridCommandCellElement)) return;
            SeleccionarItemAduanero();
            switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
            {
               case "Editar":
                  if (!BloquearBotonesServicios())
                  {
                     Presenter.EditarDetalleOperacion();
                  }
                  break;
               case "Eliminar":
                  if (!BloquearBotonesServicios())
                  {
                     Presenter.EliminarDetalleOperacion();
                  }
                  break;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar el registro.", ex); }
      }
      void BSItemsTransporte_CurrentItemChanged(object sender, EventArgs e)
      {
         SeleccionarItemTransporte();
      }
      void BSItemsAduanero_CurrentItemChanged(object sender, EventArgs e)
      {
         SeleccionarItemAduanero();
      }
      void BSItemsLogistico_CurrentItemChanged(object sender, EventArgs e)
      {
         SeleccionarItemLogsitico();
      }

      #endregion

      #region [ Servicios ]
      void btnNuevoServicio_Click(object sender, EventArgs e)
      {
         Presenter.LoadNuevoDetalleServicioOperacion();
      }
      void grdItemsServicios_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            if (e.CellElement is GridCommandCellElement)
            {
               if (e.Column.Name.Equals("Edit"))
               {
                  var bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.editar16x16;
                     bte.ToolTipText = @"Editar Registro";
                     bte.AutoSize = true;
                     //bte.Enabled = Presenter.ItemDet_OperacionServicio.CONS_CodEST == "001" || String.IsNullOrEmpty(Presenter.ItemDet_OperacionServicio.CONS_CodEST);
                  }
               }
               if (e.Column.Name.Equals("Delete"))
               {
                  var bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.Sign_07;
                     bte.ToolTipText = @"Eliminar Registro";
                     bte.AutoSize = true;
                     //bte.Enabled = Presenter.ItemDet_OperacionServicio.CONS_CodEST == "001" || String.IsNullOrEmpty(Presenter.ItemDet_OperacionServicio.CONS_CodEST);
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
            if (!(sender is GridCommandCellElement)) return;
            SeleccionarItemServicios();
            switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
            {
               case "Editar":
                  if (!BloquearBotonesServiciosAdicionales())
                  {
                     if (Presenter.EditarServicioDetalleOperacion())
                     {
                        //Presenter.ItemDet_OperacionServicio = Presenter.TempItemDet_OperacionServicio;
                        for (int i = 0; i < Presenter.ItemsDet_OperacionServicio.Count; i++)
                        {
                           if (Presenter.ItemsDet_OperacionServicio[i].SOPE_Item == Presenter.TempItemDet_OperacionServicio.SOPE_Item)
                           {
                              Presenter.ItemsDet_OperacionServicio[i] = Presenter.TempItemDet_OperacionServicio;
                              break;
                           }
                        }
                        ShowItemsDetalleServiciosOperativo();
                        //BSItemsServicios.ResetBindings(false);
                     }
                  }
                  break;
               case "Eliminar":
                  if (!BloquearBotonesServiciosAdicionales())
                  {
                     Presenter.EliminarDetalleServicioOperacion();
                  }
                  break;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar el registro.", ex); }
      }
      void BSItemsServicios_CurrentItemChanged(object sender, EventArgs e)
      {
         SeleccionarItemServicios();
      }
      void AyudaOrdenVenta_AyudaClick(object sender, EventArgs e)
      {
         try
         {
            System.Data.DataTable dt = new System.Data.DataTable();

            dt = Presenter.CargaOV(AyudaOrdenVenta.Text);

            if (dt == null || dt.Rows.Count == 0)
            { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se encontraron coincidencias."); }
            else if (dt.Rows.Count == 1)
            {
               CargarDatosOV(dt);
            }
            else
            {
               var columnas = new System.Collections.Generic.List<Infrastructure.WinForms.Controls.ColumnaAyuda>();
               int index = 0;
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = index++,
                  ColumnName = "HBL",
                  ColumnCaption = "HBL",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 150,
                  DataType = typeof(System.String),
                  Format = null,
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = index++,
                  ColumnName = "OrdenVenta",
                  ColumnCaption = "Orden Venta",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 120,
                  DataType = typeof(System.String),
                  Format = null
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = index++,
                  ColumnName = "NombreCliente",
                  ColumnCaption = "Cliente",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 200,
                  DataType = typeof(System.String),
                  Format = null
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = index++,
                  ColumnName = "NombreTransportista",
                  ColumnCaption = "Transportista",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 200,
                  DataType = typeof(System.String),
                  Format = null
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
              {
                 Index = index++,
                 ColumnName = "NombreAgente",
                 ColumnCaption = "Agente",
                 Alineacion = DataGridViewContentAlignment.MiddleLeft,
                 Width = 200,
                 DataType = typeof(System.String),
                 Format = null
              });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = index++,
                  ColumnName = "MBL",
                  ColumnCaption = "MBL",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 150,
                  DataType = typeof(System.String),
                  Format = null,
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = index++,
                  ColumnName = "Nave",
                  ColumnCaption = "Nave",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 100,
                  DataType = typeof(System.String),
                  Format = null,
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = index++,
                  ColumnName = "Viaje",
                  ColumnCaption = "Viaje",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 100,
                  DataType = typeof(System.String),
                  Format = null,
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                   Index = index++,
                   ColumnName = "FecLlegada",
                   ColumnCaption = "Fecha Arribo",
                   Alineacion = DataGridViewContentAlignment.MiddleLeft,
                   Width = 100,
                   DataType = typeof(System.DateTime),
                   Format = null,
               });
               var xAyuda = new Infrastructure.WinForms.Controls.Ayuda(Presenter.Title, dt, false, columnas, "");
               xAyuda.Width = xAyuda.Width * 2;
               if (xAyuda.ShowDialog() == DialogResult.OK)
               {
                  CargarDatosOV(xAyuda.Respuesta);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, "ha ocurrido un error en la Ayuda de Orden de Venta", ex); }
      }

      private void CargarDatosOV(System.Data.DataTable dt)
      {
         txtCOPE_HBL.Text = dt.Rows[0]["HBL"].ToString();
         txtMBL.Text = dt.Rows[0]["MBL"].ToString();
         txtNave.Text = dt.Rows[0]["Nave"].ToString();
         txtViaje.Text = dt.Rows[0]["Viaje"].ToString();
         AyudaENTC_CodCliente.SetValue(Int32.Parse(dt.Rows[0]["CodCliente"].ToString()));
         AyudaENTC_CodTransporte.SetValue(Int32.Parse(dt.Rows[0]["CodTransporte"].ToString()));
         AyudaENTC_CodAgente.SetValue(Int32.Parse(dt.Rows[0]["CodAgente"].ToString()));
         dtpFecLlegada.NSFecha = Convert.ToDateTime(dt.Rows[0]["FecLlegada"].ToString());
         AyudaOrdenVenta.Text = dt.Rows[0]["OrdenVenta"].ToString();

      }

      #endregion

      private void MView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }

      private void MView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            if (Closing != true)
            {
               this.FormClosing -= MView_FormClosing;
               //if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
               //{
               //   //if (Presenter.GuardarCambios(EsProspecto) == System.Windows.Forms.DialogResult.Cancel)
               //   //{
               //   //   e.Cancel = true;
               //   //   this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
               //   //}
               //   //else
               //   Presenter.Actualizar();
               //}
               //else
               //{ Presenter.Actualizar(); }
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }

      #endregion

      private void btnNuevoServicio_Click_1(object sender, EventArgs e)
      {

      }

      private void btnPreFactura_Click_1(object sender, EventArgs e)
      {

      }

      private void btnOrdenVenta_Click(object sender, EventArgs e)
      {
          ApplicationForm.VerticalViewerOVForm oVisorOVForm = new ApplicationForm.VerticalViewerOVForm();
          oVisorOVForm.sOrdenVenta = txtCOPE_HBL.Text;
          //oVisorOVForm.TopLevel = false;
          //oVisorOVForm.Dock = DockStyle.Fill;
          //oVisorOVForm.FormBorderStyle = FormBorderStyle.None;
          oVisorOVForm.Show();
      }
   }
}
