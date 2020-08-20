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
   public partial class MAN003MView : Form, IMAN003MView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public MAN003MView()
      {
         InitializeComponent();
         try
         {
            //btnGuardar.Click += new EventHandler(btnGuardar_Click);
            //btnSalir.Click += new EventHandler(btnSalir_Click);

            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);

         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Propiedades ]
      public MAN003Presenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }
      #endregion

      #region [ ICUS003MView ]
      public void LoadView()
      {
         try
         {
            TipoRESG_Codigo.AddComboBoxItem(0, "Neutral");
            TipoRESG_Codigo.AddComboBoxItem(1, "Positivo");
            TipoRESG_Codigo.AddComboBoxItem(-1, "Negativo");
            TipoRESG_Codigo.LoadComboBox(null);
         }
         catch (Exception)
         { }
      }

      public void ClearItem()
      {
         try
         {
            TipoRESG_Codigo.ComboIntSelectedValue = 0;
            txtTIPOS_Desc.Text = null;
            txtTIPOS_DescC.Text = null;
            chkRESG_estado.Checked = false;
         }
         catch (Exception)
         { }
      }
      public void GetItem()
      {
         try
         {

            Presenter.Item.EMPR_Codigo =1;
            Presenter.Item.RESG_Desc = txtTIPOS_Desc.Text;
            Presenter.Item.RESG_DescC = txtTIPOS_DescC.Text;
            Presenter.Item.RESG_Activo = chkRESG_estado.Checked;
            Presenter.Item.RESG_PositivoNegativo = (Int16)TipoRESG_Codigo.ComboIntSelectedValue;
         }
         catch (Exception)
         { }
      }
      public void SetItem()
      {
         try
         {
            txtTIPOS_Desc.Text = Presenter.Item.RESG_Desc;
            txtTIPOS_DescC.Text = Presenter.Item.RESG_DescC;
            chkRESG_estado.Checked = Presenter.Item.RESG_Activo;
            TipoRESG_Codigo.ComboIntSelectedValue = Presenter.Item.RESG_PositivoNegativo;

            TipoRESG_Codigo.Focus();
            TipoRESG_Codigo.Select();

            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception)
         { }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.ResultGestion>.Validate(Presenter.Item, this, errorProvider1);
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos ]

      #endregion

      #region [ Eventos ]
      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Guardar())
            {
               this.FormClosing -= MView_FormClosing;
               errorProvider1.Dispose();
               Presenter.Actualizar();
               this.Close();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Guardar.", ex); }
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            this.FormClosing -= MView_FormClosing;
            errorProvider1.Dispose();
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
               }
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
