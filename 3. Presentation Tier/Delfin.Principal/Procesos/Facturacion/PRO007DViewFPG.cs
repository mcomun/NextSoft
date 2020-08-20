using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.WinFormsControls;

namespace Delfin.Principal
{
   public partial class PRO007DViewFPG : Form, IPRO007DViewFPG
   {

      #region [ Variables ]

      #endregion

      #region [ Propiedades ]

      public PRO007Presenter Presenter { get; set; }
      public Entities.DocsVta ItemDocVta { get; set; }

      #endregion

      #region [ Formulario ]

      public PRO007DViewFPG()
      {
         InitializeComponent();
         try
         {
            btnGuardar.Click += btnGuardar_Click;
            
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar el modulo", ex); }
      }

      
      #endregion

      #region [ IPRO007DViewFPG ]

      #endregion

      #region [ Metodos ]

      public void LoadView()
      {
         try
         {
            txaSeries.LoadControl(Presenter.ContainerService, "Ayuda de Series");
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, Delfin.Controls.TiposEntidad.TIPE_Cliente);
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Moneda", "MND", "< Sel. Moneda >", ListSortDirection.Ascending);
            cmbTIPO_CodFPG.LoadControl(Presenter.ContainerService, " Forma de Pago", "FPG", "< Sel. Forma de Pago >", ListSortDirection.Ascending);

            txaENTC_Codigo.Enabled = false;
            txaENTC_Codigo.Enabled = false;
            cmbTIPO_CodMND.Enabled = false;
            dtpDOCV_FechaEmision.Enabled = false;

            SetItem();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar el modulo", ex); }
      }

      public void ClearItem() { }
      public void GetItem()
      {
         try
         {
            if (cmbTIPO_CodFPG.TiposSelectedItem != null)
            { 
               ItemDocVta.TIPO_CodFPG = cmbTIPO_CodFPG.TiposSelectedItem.TIPO_CodTipo; 
               ItemDocVta.TIPO_TabFPG = cmbTIPO_CodFPG.TiposSelectedItem.TIPO_CodTabla;
               ItemDocVta.TIPO_FPG = cmbTIPO_CodFPG.Text;
            }
            if (dtpDOCV_FechaVcmto.NSFecha.HasValue) { ItemDocVta.DOCV_FechaVcmto = dtpDOCV_FechaVcmto.NSFecha; }
         }
         catch (Exception)
         { }
      }
      public void SetItem()
      {
         try
         {
            if (ItemDocVta != null)
            {
               if (!String.IsNullOrEmpty(ItemDocVta.TIPO_CodTDO) && !String.IsNullOrEmpty(ItemDocVta.DOCV_Serie))
               { txaSeries.SetValue(ItemDocVta.TIPO_CodTDO, ItemDocVta.DOCV_Serie); }
               if (ItemDocVta.ENTC_Codigo.HasValue) { txaENTC_Codigo.SetEntidad(ItemDocVta.ENTC_Codigo); }
               if (!String.IsNullOrEmpty(ItemDocVta.TIPO_CodMND)) { cmbTIPO_CodMND.SelectedValue = ItemDocVta.TIPO_CodMND; }
               if (ItemDocVta.DOCV_FechaEmision.HasValue) { dtpDOCV_FechaEmision.NSFecha = ItemDocVta.DOCV_FechaEmision; }
               if (ItemDocVta.DOCV_FechaVcmto.HasValue) { dtpDOCV_FechaVcmto.NSFecha = ItemDocVta.DOCV_FechaVcmto; }
               if (!String.IsNullOrEmpty(ItemDocVta.TIPO_CodFPG)) { cmbTIPO_CodFPG.SelectedValue = ItemDocVta.TIPO_CodFPG; }
            }
         }
         catch (Exception)
         { }
      }

      public void ShowValidation() { }

      #endregion

      #region [ Eventos ]

      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            GetItem();
            if (cmbTIPO_CodFPG.TiposSelectedItem != null)
            {
               if (cmbTIPO_CodFPG.TiposSelectedItem.TIPO_CodTipo.Equals("001"))
               {
                  if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Desea confirmar los cambios realizados?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
                  {
                     this.DialogResult = System.Windows.Forms.DialogResult.OK;
                     this.Close();
                  }
               }
               else if (cmbTIPO_CodFPG.TiposSelectedItem.TIPO_CodTipo.Equals("002"))
               {
                  if (dtpDOCV_FechaVcmto.NSFecha.HasValue)
                  {
                     if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Desea confirmar los cambios realizados?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
                     {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                     }
                  }
                  else { Dialogos.MostrarMensajeError(Presenter.Title, "No ha definido una fecha de vencimiento"); }
               }
            }
            else { Dialogos.MostrarMensajeError(Presenter.Title, "No ha una forma de pago"); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al grabar el cambio", ex); }
      }
      
      #endregion

      #region [ IFormClose ]

      #endregion

   }
}
