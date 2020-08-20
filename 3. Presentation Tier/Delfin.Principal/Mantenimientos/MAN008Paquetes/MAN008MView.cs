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
   public partial class MAN008MView : Form, IMAN008MView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public MAN008MView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);

            PACK_Codigo.ReadOnly = true;
            txtPACK_Desc.MaxLength = 50;
            txtPACK_DescC.MaxLength = 20;
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Propiedades ]
      public MAN008Presenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }
      #endregion

      #region [ ICUS008MView ]
      public void LoadView()
      {
         try
         {
            cmbTIPO_Paqute.LoadControl(Presenter.ContainerService, "Tabla de Paquetes", "PAQ", "< Seleccionar Paquete >", ListSortDirection.Ascending);
            cmbTIPO_Tamaño.LoadControl(Presenter.ContainerService, "Tabla de Tamaños", "TAM", "< Seleccionar Tamaño >", ListSortDirection.Ascending);
            cmbTIPO_Contenedor.LoadControl(Presenter.ContainerService, "Tabla de Contenedores", "CNT", "< Seleccionar Contendor >", ListSortDirection.Ascending);
            
         }
         catch (Exception)
         { }
      }

      public void ClearItem()
      {
         try
         {
            PACK_Codigo.Text = null;
            txtPACK_Desc.Text = null;
            txtPACK_DescC.Text = null;
            cmbTIPO_Paqute.TiposSelectedValue = null;
            cmbTIPO_Tamaño.TiposSelectedValue = null;
            cmbTIPO_Contenedor.TiposSelectedValue = null;
         }
         catch (Exception)
         { }
      }
      public void GetItem()
      {
         try
         {

            Presenter.Item.PACK_Desc = txtPACK_Desc.Text;
            Presenter.Item.PACK_DescC = txtPACK_DescC.Text;

            if (cmbTIPO_Paqute.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabPAQ = cmbTIPO_Paqute.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodPAQ = cmbTIPO_Paqute.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabPAQ = null;
               Presenter.Item.TIPO_CodPAQ = null;
            }

            if (cmbTIPO_Tamaño.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabTAM = cmbTIPO_Tamaño.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodTAM = cmbTIPO_Tamaño.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabTAM = null;
               Presenter.Item.TIPO_CodTAM = null;
            }

            if (cmbTIPO_Contenedor.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabCNT = cmbTIPO_Contenedor.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodCNT = cmbTIPO_Contenedor.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabPAQ = null;
               Presenter.Item.TIPO_CodPAQ = null;
            }
         }
         catch (Exception)
         { }
      }
      public void SetItem()
      {
         try
         {
            if (Presenter.Item != null)
            {
               if (Presenter.Item.PACK_Codigo != 0) { PACK_Codigo.Text = Presenter.Item.PACK_Codigo.ToString(); }
               txtPACK_Desc.Text = Presenter.Item.PACK_Desc.ToString();
               txtPACK_DescC.Text = Presenter.Item.PACK_DescC.ToString();
               cmbTIPO_Paqute.SelectedValue = Presenter.Item.TIPO_CodPAQ;
               cmbTIPO_Tamaño.SelectedValue = Presenter.Item.TIPO_CodTAM;
               cmbTIPO_Contenedor.SelectedValue = Presenter.Item.TIPO_CodCNT;

               PACK_Codigo.Select();
               HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
            }
         }
         catch (Exception)
         { }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Paquete>.Validate(Presenter.Item, this, errorProvider1);
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

