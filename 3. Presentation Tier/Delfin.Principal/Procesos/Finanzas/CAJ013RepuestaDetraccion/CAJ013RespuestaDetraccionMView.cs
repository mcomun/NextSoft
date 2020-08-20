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

namespace Delfin.Comercial
{
   public partial class CAJ013RespuestaDetraccionMView : Form, ICAJ013RespuestaDetraccionMView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public CAJ013RespuestaDetraccionMView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += CAJ013RespuestaDetraccionMView_FormClosed;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;

            this.Load += CAJ013RespuestaDetraccionMView_Load;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      private void CAJ013RespuestaDetraccionMView_FormClosed(object sender, FormClosedEventArgs e)
      {  }

      private void CAJ013RespuestaDetraccionMView_Load(object sender, EventArgs e)
      {
      }
      #endregion

      #region [ Propiedades ]
      public CAJ013RespuestaDetraccionPresenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }

      #endregion

      #region [ ICAJ013RespuestaDetraccionMView ]
      public void LoadView()
      {
         try
         {
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      public void ClearItem()
      {
         try
         {
            errorProviderCab_Cotizacion_OV.Clear();

            #region [ Datos Generales ]
            
            #endregion

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ClearItem.", ex); }
      }
      public void GetItem()
      {
         try
         {
            errorProviderCab_Cotizacion_OV.Clear();

            #region [ Datos Generales ]

            
            #endregion

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en GetItem.", ex); }
      }
      public void SetItem()
      {
         try
         {
            EnabledItem();
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
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Planillas>.Validate(Presenter.Item, this, errorProviderCab_Cotizacion_OV);

            //Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Planillas>.SetTabError(tabCab_Cotizacion_OV, errorProviderCab_Cotizacion_OV);
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
      
      #endregion
   }
}