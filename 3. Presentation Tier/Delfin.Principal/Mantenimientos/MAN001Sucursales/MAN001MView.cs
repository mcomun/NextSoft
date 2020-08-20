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
   public partial class MAN001MView : Form, IMAN001MView
   {
       #region [ Variables ]

       #endregion

       #region [ Formulario ]
      public MAN001MView()
       {
          InitializeComponent();
          try
          {
             btnMAN_guardar.Click += new EventHandler(btnGuardar_Click);
             btnMAN_salir.Click += new EventHandler(btnSalir_Click);

             this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
              
          }
          catch (Exception)
          { }
       }
       #endregion

       #region [ Propiedades ]
       public MAN001Presenter Presenter { get; set; }
       private bool Closing = false;
       private System.Collections.Hashtable HashFormulario { get; set; }
       #endregion

       #region [ ICUS002MView ]
       public void LoadView()
       {
          try
          {
             txtSUCR_Ruc.TextAlign = HorizontalAlignment.Left;

              //cmbSUCR_Empresa.ValueMember = "SUCR_Codigo";
              //cmbSUCR_Empresa.DisplayMember = "TIPO_Desc1";
              //cmbSUCR_Empresa.DataSource = Presenter.ListEmpresas;
              //cmbSUCR_Empresa.SelectedIndex = -1;
          }
          catch (Exception)
          { }
       }

       public void ClearItem()
       {
          try
          {
            
             txtSUCR_Desc.Text = null;
             txtSUCR_DescC.Text = null;
             txtSUCR_Direccion.Text = null;
             txtSUCR_Ruc.Text = null;
             
          }
          catch (Exception)
          {  }
       }
       public void GetItem()
       {
          try
          {
             Presenter.Item.SUCR_Codigo = Presenter.Item.SUCR_Codigo;
             Presenter.Item.SUCR_Desc = txtSUCR_Desc.Text;
             Presenter.Item.SUCR_DescC = txtSUCR_DescC.Text;
             Presenter.Item.SUCR_Direc = txtSUCR_Direccion.Text;
             Presenter.Item.SUCR_RUC = txtSUCR_Ruc.Text;
         }
          catch (Exception)
          { }
       }
       public void SetItem()
       {
          try
          {
             
             txtSUCR_Desc.Text = Presenter.Item.SUCR_Desc;
             txtSUCR_DescC.Text=  Presenter.Item.SUCR_DescC;
             txtSUCR_Direccion.Text = Presenter.Item.SUCR_Direc;
             txtSUCR_Ruc.Text = Presenter.ItemEmpresa.EMPR_RUC.ToString();

             txtSUCR_Desc.Select();
                          
             HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
          }
          catch (Exception)
          { }
       }
       
       public void ShowValidation()
       {
          try
          {
             Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Sucursales>.Validate(Presenter.Item, this, errorProvider1);
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
          catch (Exception)
          { }  
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
