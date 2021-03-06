﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Comercial
{
   public partial class MAN000MView : Form, IMAN000MView
   {
       #region [ Variables ]

       #endregion

       #region [ Formulario ]
      public MAN000MView()
       {
          InitializeComponent();
          try
          {
             btnGuardar.Click += new EventHandler(btnGuardar_Click);
             btnSalir.Click += new EventHandler(btnSalir_Click);

             this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
              
          }
          catch (Exception)
          { }
       }
       #endregion

       #region [ Propiedades ]
       public MAN000Presenter Presenter { get; set; }
       private bool Closing = false;
       private System.Collections.Hashtable HashFormulario { get; set; }
       #endregion

       #region [ ICUS002MView ]
       public void LoadView()
       {
          try
          {
             txtEMPR_RUC.TextAlign = HorizontalAlignment.Left;
          }
          catch (Exception)
          { }
       }

       public void ClearItem()
       {
          try
          {
              txtEMPR_RazonSocial.Text = String.Empty;
              txtEMPR_RazonComercial.Text = String.Empty;
              txtEMPR_Direccion.Text = String.Empty;
              txtEMPR_RUC.Text = String.Empty;
          }
          catch (Exception)
          {  }
       }
       public void GetItem()
       {
          try
          {
             Presenter.Item.EMPR_Codigo = Presenter.Item.EMPR_Codigo;
             Presenter.Item.EMPR_RazonSocial = txtEMPR_RazonSocial.Text;
             Presenter.Item.EMPR_RazonComercial = txtEMPR_RazonComercial.Text;
             Presenter.Item.EMPR_Direccion = txtEMPR_Direccion.Text;
             Presenter.Item.EMPR_RUC = txtEMPR_RUC.Text;
          }
          catch (Exception)
          { }
       }
       public void SetItem()
       {
          try
          {

             ClearItem();

             txtEMPR_RazonSocial.Text = Presenter.Item.EMPR_RazonSocial;
             txtEMPR_RazonComercial.Text = Presenter.Item.EMPR_RazonComercial;
             txtEMPR_Direccion.Text = Presenter.Item.EMPR_Direccion;
             txtEMPR_RUC.Text = Presenter.Item.EMPR_RUC;

             txtEMPR_RUC.Select();

             HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
          }
          catch (Exception)
          { }
       }
       
       public void ShowValidation()
       {
          try
          {
             Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Empresa>.Validate(Presenter.Item, this, errorProvider1);
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
          { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex); }
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
