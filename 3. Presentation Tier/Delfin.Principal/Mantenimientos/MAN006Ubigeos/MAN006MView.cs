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
   public partial class MAN006MView : Form, IMAN006MView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public MAN006MView()
      {
         InitializeComponent();
         try
         {
            
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Propiedades ]
      public MAN006Presenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }
      #endregion

      #region [ ICUS006MView ]
      public void LoadView()
      {
         try
         {
            ////Presenter.GetTabla('UNT');              
            //// cmbSERV_CodUNT.DataSource = Presenter.ListTabla;
            //cmbSERV_CodUNT.ValueMember = "TIPO_TabUNT";
            //cmbSERV_CodUNT.DisplayMember = "TIPO_CodUNT";
         }
         catch (Exception)
         { }
      }

      public void ClearItem()
      {
         try
         {
            txtUBIG_desc.Text = null;
            txtUBIG_DescC.Text = null;
            txtUBIG_Codigo.Text = null;
            //txtUBIG_CodPadre.Text = null;
          
         }
         catch (Exception)
         { }
      }
      public void GetItem()
      {
         try
         {
                                  
            Presenter.Item.TIPO_TabPais = "PAI" ;
            Presenter.Item.TIPO_CodPais = Presenter.ItemTabla.TIPO_CodTipo;
            Presenter.Item.UBIG_Codigo = txtUBIG_Codigo.Text;
            Presenter.Item.UBIG_CodPadre = null;
            Presenter.Item.UBIG_Desc = txtUBIG_desc.Text;
            Presenter.Item.UBIG_DescC = txtUBIG_DescC.Text;
         
         }
         catch (Exception)
         { }
      }
      public void SetItem()
      {
         try
         {
            
            txtUBIG_Codigo.Text = Presenter.Item.UBIG_Codigo.ToString();
            //txtUBIG_CodPadre.Text = Presenter.Item.UBIG_CodPadre.ToString();
            txtUBIG_desc.Text = Presenter.Item.UBIG_Desc.ToString();
            txtUBIG_DescC.Text = Presenter.Item.UBIG_DescC.ToString();

            txtUBIG_Codigo.Select();
          

            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception)
         { }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Ubigeos>.Validate(Presenter.Item, this, errorProvider1);
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

