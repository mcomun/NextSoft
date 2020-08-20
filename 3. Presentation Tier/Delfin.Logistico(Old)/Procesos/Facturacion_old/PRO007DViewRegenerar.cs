using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.WinFormsControls;

namespace Delfin.Logistico
{
   public partial class PRO007DViewRegenerar : Form
   {
      #region [ Variables ]

      #endregion

      #region [ Propiedades ]

      public PRO007Presenter Presenter { get; set; }
      public Entities.DocsVta ItemDocVta { get; set; }

      #endregion

      #region [ Formulario ]

      public PRO007DViewRegenerar()
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
            txaSeries.LoadControl(Presenter.ContainerService, "Ayuda de Series", null, null, Delfin.Controls.Serie.SeriesLarge.TInicio.SoloSerie);
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, Delfin.Controls.TiposEntidad.TIPE_Cliente);
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Moneda", "MND", "< Sel. Moneda >", ListSortDirection.Ascending);

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
            if (txaSeries.SelectedItem != null)
            {
               ItemDocVta.DOCV_Serie = txaSeries.SelectedItem.SERI_Serie;
            }
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
            if (txaSeries.SelectedItem != null && !String.IsNullOrEmpty(txaSeries.SelectedItem.SERI_Serie))
            {
               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Desea confirmar los cambios realizados?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
               {
                  this.DialogResult = System.Windows.Forms.DialogResult.OK;
                  this.Close();
               }
            }
            else { Dialogos.MostrarMensajeError(Presenter.Title, "No ha seleccionado un numero de serie valido"); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al grabar el cambio", ex); }
      }

      #endregion

      #region [ IFormClose ]

      #endregion
   }
}
