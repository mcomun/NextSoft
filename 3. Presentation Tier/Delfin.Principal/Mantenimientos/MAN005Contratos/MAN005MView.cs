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
   public partial class MAN005MView : Form, IMAN005MView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public MAN005MView()
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
      public MAN005Presenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }
      #endregion

      #region [ ICUS004MView ]
      public void LoadView()
      {
         try
         {
            ENTC_CodCliente.ContainerService = Presenter.ContainerService;
            ENTC_CodTransportista.ContainerService = Presenter.ContainerService;

            ENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            ENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;

            CONS_CodRGM.LoadControl(Presenter.ContainerService, "Tabla Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);
            CONS_CodVia.LoadControl(Presenter.ContainerService, "Tabla Vía", "VIA", "< Seleccionar Vía >", ListSortDirection.Ascending);
         }
         catch (Exception)
         { }
      }

      public void ClearItem()
      {
         try
         {
            CONT_Codigo.Text = string.Empty;
            CONT_Activo.Checked = false;
            CONT_Numero.Text = string.Empty;
            CONT_FecEmi.NSFecha = null;
            CONT_Descrip.Text = string.Empty;
            CONT_FecFin.NSFecha = null;
            CONT_FecIni.NSFecha = null;
            ENTC_CodTransportista.ClearValue();
            ENTC_CodTransportista.Text = String.Empty; 
            ENTC_CodCliente.ClearValue();
            ENTC_CodCliente.Text = String.Empty;
            CONS_CodRGM.ConstantesSelectedValue = null;
            CONS_CodVia.ConstantesSelectedValue = null;
         }
         catch (Exception)
         { }
      }
      public void GetItem()
      {
         try
         {
            //Presenter.Item.CONT_Codigo = CONT_Codigo.Text;
            //Presenter.Item.CONT_Activo =  CONT_Activo.Checked;
            Presenter.Item.CONT_Numero = CONT_Numero.Text;
            Presenter.Item.CONT_FecEmi = CONT_FecEmi.NSFecha;
            Presenter.Item.CONT_Descrip = CONT_Descrip.Text;
            Presenter.Item.CONT_FecFin = CONT_FecFin.NSFecha;
            Presenter.Item.CONT_FecIni =  CONT_FecIni.NSFecha;
            if (ENTC_CodTransportista.Value != null)
            { Presenter.Item.ENTC_CodTransportista = ENTC_CodTransportista.Value.ENTC_Codigo; }
            else
            { Presenter.Item.ENTC_CodTransportista = null; }

            if (ENTC_CodCliente.Value != null)
            { Presenter.Item.ENTC_CodCliente = ENTC_CodCliente.Value.ENTC_Codigo; }
            else
            { Presenter.Item.ENTC_CodCliente = null; }

            if (CONS_CodRGM.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TapRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TapRGM = null;
               Presenter.Item.CONS_CodRGM = null;
            }
            if (CONS_CodVia.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TapVia = CONS_CodVia.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodVia = CONS_CodVia.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TapVia = null;
               Presenter.Item.CONS_CodVia = null;
            }
          }
         catch (Exception)
         { }
      }
      public void SetItem()
      {
         try
         {
            CONT_Codigo.Text = Presenter.Item.CONT_Codigo.ToString();
            //CONT_Activo.Checked = Presenter.Item.CONT_Activo;
            CONT_Numero.Text = Presenter.Item.CONT_Numero;
            CONT_FecEmi.NSFecha = Presenter.Item.CONT_FecEmi;
            CONT_Descrip.Text = Presenter.Item.CONT_Descrip;
            CONT_FecIni.NSFecha = Presenter.Item.CONT_FecIni;
            CONT_FecFin.NSFecha = Presenter.Item.CONT_FecFin;

            if (Presenter.Item.ENTC_CodTransportista.HasValue)
            { ENTC_CodTransportista.SetValue(Presenter.Item.ENTC_CodTransportista.Value); }
            if (Presenter.Item.ENTC_CodCliente.HasValue)
            { ENTC_CodCliente.SetValue(Presenter.Item.ENTC_CodCliente.Value); }

            CONS_CodRGM.ConstantesSelectedValue = Presenter.Item.CONS_CodRGM;
            CONS_CodVia.ConstantesSelectedValue = Presenter.Item.CONS_CodVia;

            CONT_Numero.Select();
           
            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception)
         { }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Contrato>.Validate(Presenter.Item, this, errorProvider1);
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

      private void CONT_Activo_CheckedChanged(object sender, EventArgs e)
      {

      }

      
   }
}

