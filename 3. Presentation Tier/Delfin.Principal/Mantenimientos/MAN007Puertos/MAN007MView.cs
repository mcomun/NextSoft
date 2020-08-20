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
   public partial class MAN007MView : Form, IMAN007MView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public MAN007MView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al inicializar el formulario MView.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public MAN007Presenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }
      #endregion

      #region [ ICUS007MView ]
      public void LoadView()
      {
         try
         {
            CONS_CodVia.LoadControl(Presenter.ContainerService, "Constantes de VIA", "VIA", "< Selecionar Tipo Vía >", ListSortDirection.Ascending);
            TIPO_CodPais.LoadControl(Presenter.ContainerService, "Tabla de Paises", "PAI", "< Seleccionar País >", ListSortDirection.Ascending);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }

      public void ClearItem()
      {
         try
         {
            PUER_Codigo.Text = string.Empty;
            PUER_CodEstandar.Text = string.Empty;
            CONS_CodVia.SelectedItem = Presenter.ItemVIA;
            PUER_Nombre.Text = string.Empty;
            PUER_Favorito.Checked = false;
            TIPO_CodPais.SelectedIndex = 0;
            PUER_Activo.Checked = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error limpiando el item.", ex); }
      }
      public void GetItem()
      {
         try
         {
            if (Presenter != null && Presenter.Item != null)
            {
               //PUER_Codigo.Text = Presenter.Item.PUER_Codigo.ToString();
               Presenter.Item.PUER_CodEstandar = PUER_CodEstandar.Text;
               Presenter.Item.CONS_TabVia = CONS_CodVia.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodVia = CONS_CodVia.ConstantesSelectedItem.CONS_CodTipo;
               Presenter.Item.PUER_Nombre = PUER_Nombre.Text;
               Presenter.Item.PUER_Favorito = PUER_Favorito.Checked;
               Presenter.Item.TIPO_TabPais = TIPO_CodPais.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodPais = TIPO_CodPais.TiposSelectedItem.TIPO_CodTipo;
               Presenter.Item.PUER_Activo = PUER_Activo.Checked;
               Presenter.Item.PUER_CodAduana = txtPUER_CodAduana.Text;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error obteniendo el item.", ex); }
      }
      public void SetItem()
      {
         try
         {
            if (Presenter != null && Presenter.Item != null)
            {
               PUER_Codigo.Text = Presenter.Item.PUER_Codigo.ToString();
               PUER_CodEstandar.Text = Presenter.Item.PUER_CodEstandar;
               CONS_CodVia.ConstantesSelectedValue = Presenter.Item.CONS_CodVia;
               PUER_Nombre.Text = Presenter.Item.PUER_Nombre;
               PUER_Favorito.Checked = Presenter.Item.PUER_Favorito;
               TIPO_CodPais.TiposSelectedValue = Presenter.Item.TIPO_CodPais;
               if (Presenter.Item.PUER_Activo.HasValue)
               { PUER_Activo.Checked = Presenter.Item.PUER_Activo.Value; }
               txtPUER_CodAduana.Text = Presenter.Item.PUER_CodAduana;
            }
            PUER_CodEstandar.Select();
            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error seteando el item.", ex); }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Puerto>.Validate(Presenter.Item, this, errorProvider1);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error mostrando la validación", ex); }
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
               //'Presenter.Actualizar(); ya esta actualizando al btnGuardar_Click en else presenter
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

