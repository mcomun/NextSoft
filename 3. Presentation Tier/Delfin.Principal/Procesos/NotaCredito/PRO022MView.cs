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
   public partial class PRO022MView : Form, IPRO022MView
   {
      #region [ Variables ]
      private bool Closing = false;
      #endregion

      #region [ Formulario ]
      public PRO022MView()
      {
         InitializeComponent();
         try
         {
            btnGuardar.Click += btnGuardar_Click;
            Load += PRO022MView_Load;

            txaENTC_Codigo.TiposEntidad = TiposEntidad.TIPE_Cliente;
            txaFactura.TipoFactura = TiposFactura.TIPE_Factura;
            txaENTC_Codigo.SelectedItemChanged += AyudaENTC_Cliente_SelectedItemChanged;
            txaFactura.AyudaValueChanged += txaFactura_AyudaValueChanged;

            txtSERI_UnidadNegocio.ReadOnly = true;
            txtDOCV_TipoCambioNC.ReadOnly = true;
            txtDOCV_Numero.ReadOnly = true;

            cmbDOCV_Estado.Visible = false;

            chkFiltroOV.CheckedChanged += chkFiltroOV_CheckedChanged;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }

      #endregion

      #region [ Propiedades ]

      public PRO022Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      private Hashtable HashFormulario { get; set; }

      #endregion

      #region [ IPRO022MView ]

      public void LoadView()
      {
         try
         {
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += MView_FormClosed;

            txaENTC_Codigo.LoadControl(Presenter.ContainerService, TiposEntidad.TIPE_Cliente);
            txaFactura.LoadControl(Presenter.ContainerService, "Ayuda de Facturas", AyudaFactura.TipoAyuda.Todos);

            CmbTIPO_CodMND_NC.LoadControl(Presenter.ContainerService, "Tabla Moneda", "MND", "< Selecione Moneda >", ListSortDirection.Descending);
            cmbTIPO_CodMND_Fac.LoadControl(Presenter.ContainerService, "Tabla Moneda", "MND", "< Selecione Moneda >", ListSortDirection.Descending);
            cmbDOCV_Estado.LoadControl(Presenter.ContainerService, "Tabla Estado", "FAC", "< Selecione Estado >", ListSortDirection.Descending);

            dtpDOCV_FechaEmisionNC.NSFecha = Presenter.Fecha;
            string dateStr = dtpDOCV_FechaEmisionNC.NSFecha.Value.ToString("yyyyMMdd");
            decimal tipoCambio = Presenter.GetTipoCambio(dateStr);
            txtDOCV_TipoCambioNC.Value = tipoCambio;

            /* Series solo de Notas de Credito */
            cmbSERI_Serie.DisplayMember = "SERI_Serie";
            cmbSERI_Serie.ValueMember = "SERI_Serie";
            cmbSERI_Serie.DataSource = Presenter.ListSeries;

            cmbSERI_Serie.SelectedIndexChanged += cmbSERI_Serie_SelectedIndexChanged;

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      #region [Encabezado Facturacion ]
      public void ClearItem()
      {
         try
         {
            txaENTC_Codigo.Clear();
            txaFactura.ClearValue();

            txtDOCV_ValorTotalNC.Value = 0;
            CmbTIPO_CodMND_NC.SelectedIndex = 0;
            txtDOCV_ObservacionesNC.Text = null;

            txtDOCV_ValorTotalFac.Text = null;
            cmbTIPO_CodMND_Fac.SelectedIndex = 0;
            txtDOCV_ObservacionesFAC.Text = null;
            cmbDOCV_Estado.SelectedIndex = 0;

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }

      public void GetItem()
      {
         try
         {
            if (Presenter.ItemNotaCredito != null)
            {
               if (Presenter.ClienteSelected == null)
               {
                  //Dialogos.MostrarMensajeError(Presenter.Title, "Debe Seleccionar un Cliente");
                  return;
               }
               if (Presenter.ItemDocsVta == null)
               {
                  //Dialogos.MostrarMensajeError(Presenter.Title, "Debe Seleccionar una Factura");
                  return;
               }
               else
               {
                  Presenter.ItemNotaCredito.DOCV_CodigoPadre = Presenter.ItemDocsVta.DOCV_Codigo;
                  Presenter.ItemNotaCredito.ItemDetCtaCteFactura.CCCT_Codigo = Presenter.ItemDocsVta.CCCT_Codigo;
                  Presenter.ItemNotaCredito.ItemDetCtaCteFactura.CCCT_Pendiente = Presenter.ItemDocsVta.CCCT_Pendiente;

                  if (!String.IsNullOrEmpty((cmbSERI_Serie.SelectedItem as Entities.Series).SERI_Desc))
                  { Presenter.ItemNotaCredito.DOCV_Serie = (cmbSERI_Serie.SelectedItem as Entities.Series).SERI_Serie; }
                  else { Presenter.ItemNotaCredito.DOCV_Serie = null; }

                  Presenter.ItemNotaCredito.DOCV_Numero = null;
                  Presenter.ItemNotaCredito.DOCV_NroOperacion = Presenter.ItemDocsVta.DOCV_NroOperacion;
                  Presenter.ItemNotaCredito.DOCV_HBL = Presenter.ItemDocsVta.DOCV_HBL;
                  Presenter.ItemNotaCredito.TIPO_CodFPG = "001";
                  if (Presenter.ItemNotaCredito.ItemCtaCte != null)
                  { Presenter.ItemNotaCredito.ItemCtaCte.TIPE_Codigo = Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(txaENTC_Codigo.TiposEntidad); }
                  Presenter.ItemNotaCredito.DOCV_TipoCambio = txtDOCV_TipoCambioNC.Value;

                  decimal IGV = Presenter.IGV;
                  if (Presenter.ItemDocsVta.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Soles)))
                  {
                     Presenter.ItemNotaCredito.DOCV_ValorTotal = txtDOCV_ValorTotalNC.Value;
                     Presenter.ItemNotaCredito.DOCV_ValorVtaTotal = Presenter.ItemNotaCredito.DOCV_ValorTotal * (1 + (IGV / 100));
                     Presenter.ItemNotaCredito.DOCV_Impuesto1 = Presenter.ItemNotaCredito.DOCV_ValorVtaTotal - Presenter.ItemNotaCredito.DOCV_ValorTotal;

                     Presenter.ItemNotaCredito.DOCV_ValorTotalD = Math.Round(Presenter.ItemNotaCredito.DOCV_ValorTotal / Presenter.ItemNotaCredito.DOCV_TipoCambio, 2, MidpointRounding.AwayFromZero);
                     Presenter.ItemNotaCredito.DOCV_ValorVtaTotalD = Math.Round(Presenter.ItemNotaCredito.DOCV_ValorVtaTotal / Presenter.ItemNotaCredito.DOCV_TipoCambio, 2, MidpointRounding.AwayFromZero);
                     Presenter.ItemNotaCredito.DOCV_Impuesto1D = Presenter.ItemNotaCredito.DOCV_ValorVtaTotalD - Presenter.ItemNotaCredito.DOCV_ValorTotalD;
                  }
                  else if (Presenter.ItemDocsVta.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Dolares)))
                  {
                     Presenter.ItemNotaCredito.DOCV_ValorTotalD = txtDOCV_ValorTotalNC.Value;
                     Presenter.ItemNotaCredito.DOCV_ValorVtaTotalD = Presenter.ItemNotaCredito.DOCV_ValorTotalD * (1 + (IGV / 100));
                     Presenter.ItemNotaCredito.DOCV_Impuesto1D = Presenter.ItemNotaCredito.DOCV_ValorVtaTotalD - Presenter.ItemNotaCredito.DOCV_ValorTotalD;

                     Presenter.ItemNotaCredito.DOCV_ValorTotal = Math.Round(Presenter.ItemNotaCredito.DOCV_ValorTotalD * Presenter.ItemNotaCredito.DOCV_TipoCambio, 2, MidpointRounding.AwayFromZero);
                     Presenter.ItemNotaCredito.DOCV_ValorVtaTotal = Math.Round(Presenter.ItemNotaCredito.DOCV_ValorVtaTotalD * Presenter.ItemNotaCredito.DOCV_TipoCambio, 2, MidpointRounding.AwayFromZero);
                     Presenter.ItemNotaCredito.DOCV_Impuesto1 = Presenter.ItemNotaCredito.DOCV_ValorVtaTotal - Presenter.ItemNotaCredito.DOCV_ValorTotal;
                  }

                  Presenter.ItemNotaCredito.TIPO_CodTDO = "007";
                  Presenter.ItemNotaCredito.ENTC_Codigo = Presenter.ItemDocsVta.ENTC_Codigo;
                  Presenter.ItemNotaCredito.DOCV_Estado = "E";
                  Presenter.ItemNotaCredito.DOCV_FechaEmision = dtpDOCV_FechaEmisionNC.NSFecha;


                  if (CmbTIPO_CodMND_NC.SelectedValue != null && CmbTIPO_CodMND_NC.SelectedValue.ToString() != null)
                  { Presenter.ItemNotaCredito.TIPO_CodMND = CmbTIPO_CodMND_NC.SelectedValue.ToString(); }
                  else
                  { Presenter.ItemNotaCredito.TIPO_CodMND = null; }

                  Presenter.ItemNotaCredito.DOCV_Observaciones = txtDOCV_ObservacionesNC.Text;
               }
            }
            else
            { Dialogos.MostrarMensajeInformacion(Presenter.Title, "Error al Obtener La Nota de Credito Actual"); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.GetItem, ex); }
      }

      /// <summary>
      /// Obtener los datos necesario para realizar la referencia a la factura.
      /// </summary>
      public void GetItemReferencia()
      {
         try
         {
            Presenter.ItemNotaCredito.DOCV_CodigoPadre = Presenter.ItemDocsVta.DOCV_Codigo;
            Presenter.ItemNotaCredito.DOCV_Observaciones = txtDOCV_ObservacionesNC.Text;

            Presenter.ItemNotaCredito.ItemDetCtaCteFactura.CCCT_Codigo = Presenter.ItemDocsVta.CCCT_Codigo;
            Presenter.ItemNotaCredito.ItemDetCtaCteFactura.CCCT_Pendiente = Presenter.ItemDocsVta.CCCT_Pendiente;

            if (!String.IsNullOrEmpty((cmbSERI_Serie.SelectedItem as Entities.Series).SERI_Desc))
            { Presenter.ItemNotaCredito.DOCV_Serie = (cmbSERI_Serie.SelectedItem as Entities.Series).SERI_Serie; }
            else { Presenter.ItemNotaCredito.DOCV_Serie = null; }
         }
         catch (Exception)
         { throw; }
      }

      public void SetItem()
      {
         try
         {
            if (Presenter.ItemNotaCredito != null)
            {
               if (Presenter.ItemNotaCredito.ENTC_Codigo.HasValue) { txaENTC_Codigo.SetEntidad(Presenter.ItemNotaCredito.ENTC_Codigo); }
               if (Presenter.ItemNotaCredito.DOCV_CodigoPadre.HasValue)
               {
                  txaFactura.AyudaValueChanged -= txaFactura_AyudaValueChanged;
                  txaFactura.SetValue(Presenter.ItemNotaCredito.DOCV_CodigoPadre.Value);
                  txaFactura.AyudaValueChanged += txaFactura_AyudaValueChanged;
               }
               if (Presenter.ItemNotaCredito.DOCV_FechaEmision != null) { dtpDOCV_FechaEmisionNC.NSFecha = Presenter.ItemNotaCredito.DOCV_FechaEmision.Value; }
               if (!String.IsNullOrEmpty(Presenter.ItemNotaCredito.DOCV_Numero)) { txtDOCV_Numero.Text = Presenter.ItemNotaCredito.DOCV_Numero; }

               if (!String.IsNullOrEmpty(Presenter.ItemNotaCredito.TIPO_CodMND) && Presenter.ItemNotaCredito.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Soles)))
               { txtDOCV_ValorTotalNC.Value = Presenter.ItemNotaCredito.DOCV_ValorTotal; CmbTIPO_CodMND_NC.SelectedValue = Presenter.ItemNotaCredito.TIPO_CodMND; }
               else if (!String.IsNullOrEmpty(Presenter.ItemNotaCredito.TIPO_CodMND) && Presenter.ItemNotaCredito.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Dolares)))
               { txtDOCV_ValorTotalNC.Value = Presenter.ItemNotaCredito.DOCV_ValorTotalD; CmbTIPO_CodMND_NC.SelectedValue = Presenter.ItemNotaCredito.TIPO_CodMND; }
               else { txtDOCV_ValorTotalNC.Value = 0; CmbTIPO_CodMND_NC.SelectedIndex = 0; }

               txtDOCV_TipoCambioNC.Value = Presenter.ItemNotaCredito.DOCV_TipoCambio;
               txtDOCV_ObservacionesNC.Text = Presenter.ItemNotaCredito.DOCV_Observaciones;

               if (!String.IsNullOrEmpty(Presenter.ItemNotaCredito.DOCV_Serie))
               { cmbSERI_Serie.SelectedValue = Presenter.ItemNotaCredito.DOCV_Serie; }
               else { cmbSERI_Serie.SelectedIndex = 0; }

               chkFiltroOV.Checked = false;
               txaFactura.AyudaPorOV = false; 
               chkFiltroOV.Visible = !String.IsNullOrEmpty(Presenter.ItemNotaCredito.CCOT_TipoNumero);

               txaFactura.CCOT_TipoNumero = Presenter.ItemNotaCredito.CCOT_TipoNumero;
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
            switch (xInstance)
            {
               case InstanceView.Default:
                  break;
               case InstanceView.New:

                  HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                  break;
               case InstanceView.Edit:
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
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.ItemNotaCredito.MensajeError, Dialogos.Boton.Detalles);
            FormShowErrorProvider<DocsVta>.Validate(Presenter.ItemNotaCredito, this, errorProvider1);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }

      #endregion

      #region [ Metodos ]
      #region [ Encabezado Facturacion ]
      private void Guardar()
      {
         if (Presenter.ItemNotaCredito != null)
         {
            if (!Presenter.Guardar()) return;
            errorProvider1.Dispose();
            Close();
         }
      }

      #endregion

      #endregion

      #region [ Eventos ]

      private void AyudaENTC_Cliente_SelectedItemChanged(object sender, EventArgs e)
      {
         try
         {
            int idCliente = txaENTC_Codigo.SelectedItem != null ? txaENTC_Codigo.SelectedItem.ENTC_Codigo : 0;
            txaFactura.m_idCliente = idCliente;
            if (idCliente != 0)
            {
               Presenter.ClienteSelected = txaENTC_Codigo.SelectedItem;
            }
            else
            {
               Presenter.ClienteSelected = null;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Selecionar un Cliente.", ex); }
      }

      private void txaFactura_AyudaValueChanged(object sender, EventArgs e)
      {
         try
         {
            int idFactura = txaFactura.SelectedItem != null ? txaFactura.SelectedItem.DOCV_Codigo : 0;

            if (idFactura != 0)
            {
               cmbTIPO_CodMND_Fac.SelectedValue = txaFactura.SelectedItem.TIPO_CodMND;
               txtDOCV_ObservacionesFAC.Text = txaFactura.SelectedItem.DOCV_Observaciones;
               txtDOCV_ValorTotalFac.Text = txaFactura.SelectedItem.DOCV_ValorTotal.ToString();
               Presenter.ItemDocsVta = txaFactura.SelectedItem;
               switch (Presenter.TInicio)
               {
                  case PRO022Presenter.TipoInicio.Normal:
                     dtpDOCV_FechaEmision.Value = Presenter.ItemDocsVta.DOCV_FechaEmision.Value;
                     if (Presenter.ItemDocsVta.DOCV_FechaVcmto.HasValue) { dtpDOCV_FechaVcmto.Value = Presenter.ItemDocsVta.DOCV_FechaVcmto.Value; }

                     CmbTIPO_CodMND_NC.SelectedValue = Presenter.ItemDocsVta.TIPO_CodMND;

                     if (String.Equals(Presenter.ItemDocsVta.DOCV_Estado, "I")) { cmbDOCV_Estado.SelectedValue = "002"; }
                     else if (String.Equals(Presenter.ItemDocsVta.DOCV_Estado, "E")) { cmbDOCV_Estado.SelectedValue = "001"; }
                     else if (String.Equals(Presenter.ItemDocsVta.DOCV_Estado, "A")) { cmbDOCV_Estado.SelectedValue = "003"; }

                     txtDOCV_TipoCambioNC.Value = Presenter.ItemDocsVta.DOCV_TipoCambio;
                     txtDOCV_ValorTotalNC.Focus();
                     break;
                  case PRO022Presenter.TipoInicio.EditarFacturacion:
                     break;
                  default:
                     break;
               }


               //if (txaFactura.SelectedItem.CCCT_Pendiente == 0)
               //{
               //   btnGuardar.Enabled = false;
               //   Dialogos.MostrarMensajeError(Presenter.Title, "No puede crear una nota de credito con un documento que no tiene saldo, cambie de documento para continuar.");
               //}
               //else { btnGuardar.Enabled = true; }

            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Selecionar un Cliente.", ex); }
      }

      private void PRO022MView_Load(object sender, EventArgs e)
      {

      }

      private void btnBuscar_Click(object sender, EventArgs e)
      {

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

      private void MView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }

      private void MView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            if (Closing != true)
            {
               this.FormClosing -= MView_FormClosing;
               switch (Presenter.TInicio)
               {
                  case PRO022Presenter.TipoInicio.Normal:
                     Presenter.Actualizar();
                     break;
                  case PRO022Presenter.TipoInicio.EditarFacturacion:
                     break;
               }
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }

      private void cmbSERI_Serie_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (String.IsNullOrEmpty((cmbSERI_Serie.SelectedItem as Series).SERI_Serie))
            {
               txtSERI_UnidadNegocio.Clear();
            }
            else
            {
               txtSERI_UnidadNegocio.Text = (cmbSERI_Serie.SelectedItem as Entities.Series).GetSERI_UnidadNegocio();
            }
         }
         catch (Exception)
         { }
      }

      private void chkFiltroOV_CheckedChanged(object sender, EventArgs e)
      { txaFactura.AyudaPorOV = chkFiltroOV.Checked; }

      #endregion

      #endregion
   }
}


