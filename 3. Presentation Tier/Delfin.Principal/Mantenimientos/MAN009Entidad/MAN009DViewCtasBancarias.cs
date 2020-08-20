using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delfin.Controls.Tipos;
using Delfin.Entities;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.WinForms.Controls;

namespace Delfin.Principal
{
   public partial class MAN009DViewCtasBancarias : Form
   {
      #region [ Variables ]

      public enum TRegistro
      {
         Nuevo = 0, Editar = 1
      }

      #endregion

      #region [ Propiedades ]

      public TRegistro TOpcion { get; set; }
      public MAN009Presenter Presenter { get; set; }
      public Entities.EntidadCuentaBancaria Item { get; set; }

      #endregion

      #region [ Formulario ]

      public MAN009DViewCtasBancarias(TRegistro Opcion)
      {
         InitializeComponent();
         try
         {
            TOpcion = Opcion;
            this.StartPosition = FormStartPosition.CenterScreen;

            cmbTIPE_CodPadre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTIPE_CodPadre.Enabled = false;
            lblTIPE_CodPadre.Enabled = false;
            txaENTC_CodPadre.Enabled = false;
            lblENTC_CodPadre.Enabled = false;

            txtENCB_NroCuentaSol.MaxLength = 50;
            txtENCB_NroCuentaDol.MaxLength = 50;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al iniciar", ex); }
      }
      
      public void LoadView()
      {
         try
         {

            if (TOpcion == TRegistro.Nuevo)
            {
               if (Presenter.Item.ListEntidadCuentaBancarias != null &&
                   Presenter.Item.ListEntidadCuentaBancarias.Count > 0)
               {
                  ObservableCollection<Entities.Tipos> x_listTipos = Presenter.Client.GetAllTiposByTipoCodTabla("BCO");
                  foreach (Entities.EntidadCuentaBancaria iECBancaria in Presenter.Item.ListEntidadCuentaBancarias)
                  {
                     x_listTipos.Remove(
                        x_listTipos.Where(Tip => Tip.TIPO_CodTipo == iECBancaria.TIPO_CodBCO).FirstOrDefault());
                  }
                  if (x_listTipos.Count > 1)
                  {
                     cmbTIPO_CodBCO.LoadControl(x_listTipos, "Bancos", "< Sel. Banco >", ListSortDirection.Ascending);
                  }
                  else
                  {
                     Dialogos.MostrarMensajeInformacion(Presenter.Title, "No existen bancos disponibles.");
                     cmbTIPO_CodBCO.SelectedIndex = -1;
                     cmbTIPO_CodBCO.Enabled = false;
                     btnGuardar.Enabled = false;
                  }
               }
               else
               { cmbTIPO_CodBCO.LoadControl(Presenter.ContainerService, "Bancos", "BCO", "< Sel. Banco >", ListSortDirection.Ascending); }
            }
            else { cmbTIPO_CodBCO.LoadControl(Presenter.ContainerService, "Bancos", "BCO", "< Sel. Banco >", ListSortDirection.Ascending); }

            cmbENCB_TipoCuenta.LoadControl("Tipo de Cuenta", ComboBoxConstantes.OConstantes.TipoCuenta, "< Sel. Tipo de Cuenta >", ListSortDirection.Ascending);

            if (Presenter.Item.ENTC_Codigo > 0)
            {
               cmbTIPE_CodPadre.ValueMember = "TIPE_Codigo";
               cmbTIPE_CodPadre.DisplayMember = "TIPE_Descripcion";
               cmbTIPE_CodPadre.DataSource = Presenter.ListTiposEntidad;

               cmbTIPE_CodPadre.SelectedValue = Presenter.Item.TIPE_Codigo;
               txaENTC_CodPadre.LoadControl(Presenter.ContainerService, Delfin.Controls.EntidadClear.getTipoEntidadEnum(Presenter.Item.TIPE_Codigo), "ENTC_DocIden", "ENTC_NomCompleto");
               txaENTC_CodPadre.SetEntidad(Presenter.Item);
            }
            else
            {
               tableLayoutPanel3.Visible = false;
               panelCaption1.Visible = false;
               this.Height = this.Height - 55;
            }
            switch (TOpcion)
            {
               case TRegistro.Nuevo:
                  Item = new EntidadCuentaBancaria();
                  Item.AUDI_UsrCrea = Presenter.Session.UserName;
                  Item.ENTC_Codigo = Presenter.Item.ENTC_Codigo;
                  Item.Instance = InstanceEntity.Added;
                  break;
               case TRegistro.Editar:
                  cmbTIPO_CodBCO.Enabled = false;
                  Item.AUDI_UsrMod = Presenter.Session.UserName;
                  Item.Instance = InstanceEntity.Unchanged;
                  break;
            }

            SetItem();
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ ICUS002MView ]

      #endregion

      #region [ Metodos ]

      private void ClearItem()
      {
         try
         {
            cmbTIPO_CodBCO.SelectedIndex = 0;
            cmbENCB_TipoCuenta.SelectedIndex = 0;
            txtENCB_NroCuentaSol.Clear();
            txtENCB_NroCuentaDol.Clear();
         }
         catch (Exception)
         { throw; }
      }

      private void SetItem()
      {
         try
         {
            if (Item.TIPO_CodBCO != null) { cmbTIPO_CodBCO.TiposSelectedValue = Item.TIPO_CodBCO; }
            if (Item.ENCB_TipoCuenta != null) { cmbENCB_TipoCuenta.ConstantesSelectedValue = Item.ENCB_TipoCuenta; }
            if (Item.ENCB_NroCuentaSol != null) { txtENCB_NroCuentaSol.Text = Item.ENCB_NroCuentaSol; }
            if (Item.ENCB_NroCuentaDol != null) { txtENCB_NroCuentaDol.Text = Item.ENCB_NroCuentaDol; }
         }
         catch (Exception)
         { throw; }
      }

      private void getItem()
      {
         try
         {
            Item.TIPO_CodBCO = null; Item.TIPO_TabBCO = null;
            if (cmbTIPO_CodBCO.TiposSelectedItem != null)
            {
               Item.TIPO_CodBCO = cmbTIPO_CodBCO.TiposSelectedItem.TIPO_CodTipo; Item.TIPO_TabBCO = cmbTIPO_CodBCO.TiposSelectedItem.TIPO_CodTabla;
               Item.TIPO_BCO = cmbTIPO_CodBCO.Text;
            }
            Item.ENCB_TipoCuenta = null;
            if (cmbENCB_TipoCuenta.ConstantesSelectedItem != null)
            {
               Item.ENCB_TipoCuenta = cmbENCB_TipoCuenta.ConstantesSelectedItem.CONS_CodTipo;
               Item.TipoCuenta = cmbENCB_TipoCuenta.Text;
            }
            Item.ENCB_NroCuentaSol = null; if (!String.IsNullOrEmpty(txtENCB_NroCuentaSol.Text)) { Item.ENCB_NroCuentaSol = txtENCB_NroCuentaSol.Text; }
            Item.ENCB_NroCuentaDol = null; if (!String.IsNullOrEmpty(txtENCB_NroCuentaDol.Text)) { Item.ENCB_NroCuentaDol = txtENCB_NroCuentaDol.Text; }
         }
         catch (Exception)
         { throw; }
      }



      #endregion

      #region [ Eventos ]

      private void btnSalir_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            getItem();
            if (Item.Validar())
            {
               DialogResult = DialogResult.OK;
            }
            else { Dialogos.MostrarMensajeInformacion(Presenter.Title, "Ha ocurrido un error al intentar guardar la cuenta bancaria.", Item.MensajeError); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al intentar guardar la cuenta bancaria.", ex); }
      }

      #endregion

      #region [ IFormClose ]

      #endregion

   }
}
