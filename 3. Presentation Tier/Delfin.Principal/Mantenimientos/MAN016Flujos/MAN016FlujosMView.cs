using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Aspect.Collections;

namespace Delfin.Principal
{
   public partial class MAN016FlujosMView : Form, IMAN016FlujosMView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public MAN016FlujosMView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += MAN016FlujosMView_FormClosed;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;

            txtFLUJ_Codigo.MaxLength = 20;
            txtFLUJ_Glosa.MaxLength = 100;

            txtFLUJ_Codigo.Tag = "FLUJ_CodigoMSGERROR";
            txtFLUJ_Glosa.Tag = "FLUJ_GlosaMSGERROR";
            cmbFLUJ_TipoFlujo.Tag = "FLUJ_TipoFlujoMSGERROR";
            cmbFLUJ_TipoMovimiento.Tag = "FLUJ_TipoMovimientoMSGERROR";
                     
            this.Load += MAN016FlujosMView_Load;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      private void MAN016FlujosMView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }

      private void MAN016FlujosMView_Load(object sender, EventArgs e)
      {
       
      }
      #endregion

      #region [ Propiedades ]
      public MAN016FlujosPresenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }

      #endregion

      #region [ IMAN016FlujosMView ]
      public void LoadView()
      {
         try
         {
            cmbFLUJ_TipoFlujo.LoadControl("Tipo Flujo", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.TipoFlujo, "< Sel. Tipo Flujo >", ListSortDirection.Ascending);
            cmbFLUJ_TipoMovimiento.LoadControl("Tipo Movimiento", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.TipoMovimiento, "< Sel. Tipo Flujo >", ListSortDirection.Ascending);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      public void ClearItem()
      {
         try
         {
            txtFLUJ_Codigo.Clear();
            txtFLUJ_Glosa.Clear();
            cmbFLUJ_TipoFlujo.SelectedIndex = 0;
            cmbFLUJ_TipoMovimiento.SelectedIndex = 0;
            errorProviderCab_Cotizacion_OV.Clear();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ClearItem.", ex); }
      }
      public void GetItem()
      {
         try
         {
            errorProviderCab_Cotizacion_OV.Clear();
             
             if (Presenter.Item.Instance == InstanceEntity.Added)
             {
                 Presenter.Item.FLUJ_Codigo = txtFLUJ_Codigo.Text;
             }
            
             if (!String.IsNullOrEmpty(txtFLUJ_Glosa.Text))
             {
                 Presenter.Item.FLUJ_Glosa = txtFLUJ_Glosa.Text;
             }
             else
             {
                 Presenter.Item.FLUJ_Glosa = null;
             }
             if (cmbFLUJ_TipoFlujo.ConstantesSelectedItem != null)
             {
                 Presenter.Item.FLUJ_TipoFlujo = cmbFLUJ_TipoFlujo.ConstantesSelectedItem.CONS_CodTipo;
             }
             else { Presenter.Item.FLUJ_TipoFlujo = null; }
             if (cmbFLUJ_TipoMovimiento.ConstantesSelectedItem != null)
             {
                 Presenter.Item.FLUJ_TipoMovimiento = cmbFLUJ_TipoMovimiento.ConstantesSelectedItem.CONS_CodTipo;
             }
             else { Presenter.Item.FLUJ_TipoMovimiento = null; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en GetItem.", ex); }
      }
      public void SetItem()
      {
         try
         {
            EnabledItem();

            if (!String.IsNullOrEmpty(Presenter.Item.FLUJ_Codigo)) { txtFLUJ_Codigo.Text = Presenter.Item.FLUJ_Codigo; } else { txtFLUJ_Codigo.Clear(); }
            if (!String.IsNullOrEmpty(Presenter.Item.FLUJ_Glosa)) { txtFLUJ_Glosa.Text = Presenter.Item.FLUJ_Glosa; } else { txtFLUJ_Glosa.Clear(); }
            if (!String.IsNullOrEmpty(Presenter.Item.FLUJ_TipoFlujo)) { cmbFLUJ_TipoFlujo.SelectedValue = Presenter.Item.FLUJ_TipoFlujo; } else { cmbFLUJ_TipoFlujo.SelectedIndex = 0; }
            if (!String.IsNullOrEmpty(Presenter.Item.FLUJ_TipoMovimiento)) { cmbFLUJ_TipoMovimiento.SelectedValue = Presenter.Item.FLUJ_TipoMovimiento; } else { cmbFLUJ_TipoMovimiento.SelectedIndex = 0; }

            
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
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Flujo>.Validate(Presenter.Item, this, errorProviderCab_Cotizacion_OV);

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