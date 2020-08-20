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
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;


namespace Delfin.Principal
{
   public partial class PRO009MView : Form, IPRO009MView
   {
      public PRO009MView()
      {
         InitializeComponent();
         try
         {
            btnGuardar.Click += btnGuardar_Click;

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }
      #region [ Propiedades ]
      public PRO009Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      private Hashtable HashFormulario { get; set; }
      #endregion
      #region [ IPRO009MView ]
      public void LoadView()
      {
         try
         {
            CbTIPO_CodBCO.LoadControl(Presenter.ContainerService, "Tabla Bancos", "BCO", "< Selecione Banco >", ListSortDirection.Descending);
            CbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Tabla Moneda", "MND", "< Selecione Moneda >", ListSortDirection.Descending);
            //CbTIPO_CodFPG.LoadControl("Tabla F. Pago", "FPG", "< Selecione F. Pago >", ListSortDirection.Descending);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      void btnGuardar_Click(object sender, EventArgs e)
      {
         Guardar();
      }
      private void Guardar()
      {
         if (!Presenter.Guardar()) return;
         errorProvider1.Dispose();
         Close();
      }

      public void ClearItem()
      {
         txtCACU_NroCuenta.Text = "";
         CbTIPO_CodBCO.SelectedIndex = 0;
         CbTIPO_CodMND.SelectedIndex = 0;
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
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.ItemCajaCuentas.MensajeError, Dialogos.Boton.Detalles);
            FormShowErrorProvider<CajaCuentas>.Validate(Presenter.ItemCajaCuentas , this, errorProvider1);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      } 
      public void GetItem()
      {
         Presenter.ItemCajaCuentas.CACU_NroCuenta = txtCACU_NroCuenta.Text;
         if(CbTIPO_CodBCO.SelectedValue != null)
            Presenter.ItemCajaCuentas.TIPO_CodBCO = CbTIPO_CodBCO.SelectedValue.ToString();
         if(CbTIPO_CodMND.SelectedValue != null )
            Presenter.ItemCajaCuentas.TIPO_CodMND = CbTIPO_CodMND.SelectedValue.ToString();   
      }

      public void SetItem()
      {
         txtCACU_NroCuenta.Text = Presenter.ItemCajaCuentas.CACU_NroCuenta;
         CbTIPO_CodBCO.SelectedValue = Presenter.ItemCajaCuentas.TIPO_CodBCO;
         CbTIPO_CodMND.SelectedValue = Presenter.ItemCajaCuentas.TIPO_CodMND; 
      }
      #endregion

   }

}
