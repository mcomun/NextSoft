using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
   public partial class CAJ005TransferenciasGView : Form
   {

      #region [ Variables ]

      #endregion

      #region [ Propiedades ]

      public CAJ005TransferenciasPresenter Presenter { get; set; }
      public Entities.GastosBancarios Item { get; set; }


      #endregion

      #region [ Formulario ]

      public CAJ005TransferenciasGView()
      {
         InitializeComponent();
         try
         {
            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;

            txtGBAN_Codigo.Enabled = false;
         }
         catch (Exception)
         { }
      }

      public void LoadView()
      {
         try
         {
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Moneda", "MND", "< Sel. Moneda >", ListSortDirection.Ascending);
            txnGBAN_TipoCambio.Value = Presenter.TipoCambio;
            setItem();
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ ICUS002MView ]

      #endregion

      #region [ Metodos ]

      private void getItem()
      {
         try
         {
            if (txnGBAN_MontoDebe.Value != 0) { Item.GBAN_MontoDebe = txnGBAN_MontoDebe.Value; } else { Item.GBAN_MontoDebe = 0; }
            if (txnGBAN_MontoHaber.Value != 0) { Item.GBAN_MontoHaber = txnGBAN_MontoHaber.Value; } else { Item.GBAN_MontoHaber = 0; }
            if (txnGBAN_TipoCambio.Value != 0) { Item.GBAN_TipoCambio = txnGBAN_TipoCambio.Value; } else { Item.GBAN_TipoCambio = 0; }
            if (cmbTIPO_CodMND.TiposSelectedItem != null)
            {
               Item.TIPO_CodMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo;
               Item.TIPO_TabMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTabla;
               Item.TIPO_MND = cmbTIPO_CodMND.Text;
            }
         }
         catch (Exception)
         { throw; }
      }

      private void setItem()
      {
         try
         {
            if (Item.GBAN_Codigo > 0) { txtGBAN_Codigo.Text = Item.GBAN_Codigo.ToString(); }
            if (Item.GBAN_MontoDebe > 0) { txnGBAN_MontoDebe.Value = Item.GBAN_MontoDebe; }
            if (Item.GBAN_MontoHaber > 0) { txnGBAN_MontoHaber.Value = Item.GBAN_MontoHaber; }
            if (!String.IsNullOrEmpty(Item.TIPO_CodMND)) { cmbTIPO_CodMND.TiposSelectedValue = Item.TIPO_CodMND; }
            if (Item.GBAN_TipoCambio > 0) { txnGBAN_TipoCambio.Value = Item.GBAN_TipoCambio; }
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Eventos ]

      void btnSalir_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            getItem();
            if (((txnGBAN_MontoDebe.Value + txnGBAN_MontoHaber.Value) > 0 && (txnGBAN_MontoDebe.Value == 0 || txnGBAN_MontoHaber.Value == 0))&& cmbTIPO_CodMND.TiposSelectedItem!=null)
            {
               this.DialogResult = DialogResult.OK;
               this.Close();
            }
            else
            {
               if (!(txnGBAN_MontoDebe.Value == 0 || txnGBAN_MontoHaber.Value == 0))
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No puede ingresar valores en ambos campos(Debe y Haber)."); }
               if ((txnGBAN_MontoDebe.Value + txnGBAN_MontoHaber.Value) <= 0)
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe ingresar un valor en el campo del Debe o Haber."); }
               if (cmbTIPO_CodMND.TiposSelectedItem == null)
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un valor en el campo del Moneda."); }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex); }
      }

      #endregion

      #region [ IFormClose ]

      #endregion

   }
}
