using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.Collections;

namespace Delfin.Principal
{
   public partial class MAN015SeriesMView : Form, IMAN015SeriesMView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public MAN015SeriesMView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += MAN015SeriesMView_FormClosed;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;

            txtSERI_Desc.MaxLength = 100;
            txtSERI_Impresora.MaxLength = 100;
            txtSERI_Serie.MaxLength = 20;

            this.Load += MAN015SeriesMView_Load;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      private void MAN015SeriesMView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }

      private void MAN015SeriesMView_Load(object sender, EventArgs e)
      {

      }
      #endregion

      #region [ Propiedades ]
      public MAN015SeriesPresenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }

      #endregion

      #region [ IMAN015SeriesMView ]
      public void LoadView()
      {
         try
         {
            cmbTIPO_CodTDO.LoadControl(Presenter.ContainerService, "Tipo de Documento", "TDO", "< Selec. Tipo Documento >", ListSortDirection.Ascending);
            //cmbSERI_UnidadNegocio.LoadControl("Unidad de Negocio", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.UnidadNegocio, "< Sel. Unidad de Negocio >", ListSortDirection.Ascending);
            lvwUnidadNegocio.CheckBoxes = true;
            lvwUnidadNegocio.View = View.SmallIcon;
            if (Presenter.ListConsLNG != null)
            {
               foreach (Entities.Constantes iLNG in Presenter.ListConsLNG)
               {
                  ListViewItem item = new ListViewItem(String.Format("{0}", iLNG.CONS_Desc_SPA)) { Tag = iLNG };
                  lvwUnidadNegocio.Items.Add(item);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      public void ClearItem()
      {
         try
         {
            errorProviderCab_Cotizacion_OV.Clear();
            txtSERI_Desc.Clear();
            txtSERI_Impresora.Clear();
            txtSERI_Serie.Clear();

            txnSERI_MaxItems.Clear();
            txnSERI_NumFinal.Clear();
            txnSERI_NumInicial.Clear();
            txnSERI_UltNumero.Clear();

            cmbTIPO_CodTDO.SelectedIndex = 0;
            foreach (ListViewItem item in lvwUnidadNegocio.Items) { item.Checked = false; }

            chkSERI_Activo.Checked = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ClearItem.", ex); }
      }
      public void GetItem()
      {
         try
         {
            errorProviderCab_Cotizacion_OV.Clear();

            if (!String.IsNullOrEmpty(txtSERI_Serie.Text)) { Presenter.Item.SERI_Serie = txtSERI_Serie.Text; } else { Presenter.Item.SERI_Serie = null; }
            if (cmbTIPO_CodTDO.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_CodTDO = cmbTIPO_CodTDO.TiposSelectedItem.TIPO_CodTipo;
               Presenter.Item.TIPO_TabTDO = cmbTIPO_CodTDO.TiposSelectedItem.TIPO_CodTabla;
            }
            else { Presenter.Item.TIPO_CodTDO = null; }
            Presenter.Item.SERI_UltNumero = Convert.ToInt32(txnSERI_UltNumero.Value);
            if (txnSERI_MaxItems.Value != 0) { Presenter.Item.SERI_MaxItems = Convert.ToInt16(txnSERI_MaxItems.Value); } else { Presenter.Item.SERI_MaxItems = null; }
            if (txnSERI_NumInicial.Value != 0) { Presenter.Item.SERI_NumInicial = Convert.ToInt16(txnSERI_NumInicial.Value); } else { Presenter.Item.SERI_NumInicial = null; }
            if (txnSERI_NumFinal.Value != 0) { Presenter.Item.SERI_NumFinal = Convert.ToInt16(txnSERI_NumFinal.Value); } else { Presenter.Item.SERI_NumFinal = null; }
            if (!String.IsNullOrEmpty(txtSERI_Desc.Text)) { Presenter.Item.SERI_Desc = txtSERI_Desc.Text; } else { Presenter.Item.SERI_Desc = null; }

            //if (cmbSERI_UnidadNegocio.ConstantesSelectedItem != null) 
            //{ Presenter.Item.SERI_UnidadNegocio = cmbSERI_UnidadNegocio.ConstantesSelectedItem.CONS_CodTipo; } 
            //else { Presenter.Item.SERI_UnidadNegocio = null; }

            String x_lng = "";
            foreach (ListViewItem item in lvwUnidadNegocio.Items)
            {
               if (item.Checked) { x_lng += ((Entities.Constantes)item.Tag).CONS_Desc_SPA.Substring(0, 1); }
            }
            if (!String.IsNullOrEmpty(x_lng)) { Presenter.Item.SERI_UnidadNegocio = x_lng; } else { Presenter.Item.SERI_UnidadNegocio = null; }


            if (!String.IsNullOrEmpty(txtSERI_Impresora.Text)) { Presenter.Item.SERI_Impresora = txtSERI_Impresora.Text; } else { Presenter.Item.SERI_Impresora = null; }
            Presenter.Item.SERI_Activo = chkSERI_Activo.Checked;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en GetItem.", ex); }
      }
      public void SetItem()
      {
         try
         {
            EnabledItem();
            if (!String.IsNullOrEmpty(Presenter.Item.SERI_Serie)) { txtSERI_Serie.Text = Presenter.Item.SERI_Serie; }
            if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodTDO)) { cmbTIPO_CodTDO.TiposSelectedValue = Presenter.Item.TIPO_CodTDO; }
            if (Presenter.Item.SERI_UltNumero.HasValue) { txnSERI_UltNumero.Value = Convert.ToDecimal(Presenter.Item.SERI_UltNumero); }
            if (Presenter.Item.SERI_MaxItems.HasValue) { txnSERI_MaxItems.Value = Convert.ToDecimal(Presenter.Item.SERI_MaxItems); }
            if (Presenter.Item.SERI_NumFinal.HasValue) { txnSERI_NumFinal.Value = Convert.ToDecimal(Presenter.Item.SERI_NumFinal); }
            if (Presenter.Item.SERI_NumInicial.HasValue) { txnSERI_NumInicial.Value = Convert.ToDecimal(Presenter.Item.SERI_NumInicial); }
            if (!String.IsNullOrEmpty(Presenter.Item.SERI_Desc)) { txtSERI_Desc.Text = Presenter.Item.SERI_Desc; }
            chkSERI_Activo.Checked = (Presenter.Item.SERI_Activo.HasValue ? Presenter.Item.SERI_Activo.Value : false);
            if (!String.IsNullOrEmpty(Presenter.Item.SERI_UnidadNegocio))
            {
               int i = 0;
               foreach (ListViewItem item in lvwUnidadNegocio.Items)
               {
                  String x_cadena = ((Entities.Constantes)item.Tag).CONS_Desc_SPA.Substring(0, 1);
                  lvwUnidadNegocio.Items[i].Checked = Presenter.Item.SERI_UnidadNegocio.Contains(x_cadena);
                  i++;
               }
            }
            if (!String.IsNullOrEmpty(Presenter.Item.SERI_Impresora)) { txtSERI_Impresora.Text = Presenter.Item.SERI_Impresora; }

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
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Series>.Validate(Presenter.Item, this, errorProviderCab_Cotizacion_OV);
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
               errorProviderCab_Cotizacion_OV.Dispose();
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
            errorProviderCab_Cotizacion_OV.Dispose();
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

      #endregion
   }
}