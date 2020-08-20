using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delfin.Controls.Tipos;
using Delfin.Entities;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinForms.Controls;

namespace Delfin.Principal
{
   public partial class CAJ001CuentasBancariasCView : Form
   {
      #region [ Variables ]

      public enum TInicio
      {
         Nuevo = 0, Editar = 1
      }

      #endregion

      #region [ Propiedades ]

      public Entities.Chequera Item { get; set; }
      public TInicio TipoInicio { get; set; }
      public CAJ001CuentasBancariasPresenter Presenter { get; set; }

      #endregion

      #region [ Formulario ]

      public CAJ001CuentasBancariasCView()
      {
         InitializeComponent();
         try
         {
            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;

            txtCHEQ_Codigo.Enabled = false;
            txtCHEQ_Codigo.Tag = "CHEQ_CodigoMSGERROR";
            txnCHEQ_NroFinal.Tag = "CHEQ_NroFinalMSGERROR";
            txnCHEQ_NroInicial.Tag = "CHEQ_NroInicialMSGERROR";
            txnCHEQ_NroActual.Tag = "CHEQ_NroActualMSGERROR";
            cmbCHEQ_Diferido.Tag = "CHEQ_DiferidoMSGERROR";
            cmbCHEQ_Estado.Tag = "CHEQ_EstadoMSGERROR";

            /********(MaxLength)*********/
            txtCHEQ_Codigo.MaxLength = 4;
            txnCHEQ_NroInicial.MaxLength = 4;
            txnCHEQ_NroActual.MaxLength = 4;
            txnCHEQ_NroFinal.MaxLength = 4;
            /****************************/
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      public void LoadView(TInicio x_opcion)
      {
         try
         {
            cmbCHEQ_Diferido.LoadControl("Tipo Chequera", ComboBoxConstantes.OConstantes.TipoChequera, "< Sel Tipo Chequera >", ListSortDirection.Ascending);
            cmbCHEQ_Estado.LoadControl("Estado Chequera", ComboBoxConstantes.OConstantes.EstadoChequera, "< Sel Estado Chequera >", ListSortDirection.Ascending);

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
            if (Item != null)
            {
               if (txnCHEQ_NroInicial.Value > 0) { Item.CHEQ_NroInicial = Convert.ToInt32(txnCHEQ_NroInicial.Value); } else { Item.CHEQ_NroInicial = null; }
               if (txnCHEQ_NroFinal.Value > 0) { Item.CHEQ_NroFinal = Convert.ToInt32(txnCHEQ_NroFinal.Value); } else { Item.CHEQ_NroFinal = null; }
               if (txnCHEQ_NroActual.Value > 0) { Item.CHEQ_NroActual = Convert.ToInt32(txnCHEQ_NroActual.Value); } else { Item.CHEQ_NroActual = null; }
               if (cmbCHEQ_Diferido.ConstantesSelectedItem != null)
               {
                  Item.CHEQ_Diferido = cmbCHEQ_Diferido.ConstantesSelectedItem.CONS_CodTipo.Equals("D");
                  Item.CHEQ_Diferido_Text = cmbCHEQ_Diferido.Text;
               }
               else { Item.CHEQ_Diferido = null; }
               if (cmbCHEQ_Estado.ConstantesSelectedItem != null)
               {
                  Item.CHEQ_Estado = cmbCHEQ_Estado.ConstantesSelectedItem.CONS_CodTipo;
                  Item.CHEQ_Estado_Text = cmbCHEQ_Estado.Text;
               }
               else { Item.CHEQ_Estado = null; }
            }
            else { throw new Exception("Clase no inicializada"); }
         }
         catch (Exception)
         { throw; }
      }

      private void setItem()
      {
         try
         {
            if (Item != null)
            {
               if (Item.CHEQ_Codigo > 0) { txtCHEQ_Codigo.Text = Item.CHEQ_Codigo.ToString(); }
               if (Item.CHEQ_NroInicial.HasValue) { txnCHEQ_NroInicial.Value = Convert.ToInt32(Item.CHEQ_NroInicial); }
               if (Item.CHEQ_NroFinal.HasValue) { txnCHEQ_NroFinal.Value = Convert.ToInt32(Item.CHEQ_NroFinal); }
               if (Item.CHEQ_NroActual.HasValue) { txnCHEQ_NroActual.Value = Convert.ToInt32(Item.CHEQ_NroActual); }
               if (Item.CHEQ_Diferido.HasValue) cmbCHEQ_Diferido.ConstantesSelectedValue = (Item.CHEQ_Diferido.Value ? "D" : "N");
               if (Item.CHEQ_Estado != null) { cmbCHEQ_Estado.ConstantesSelectedValue = Item.CHEQ_Estado; }
            }
         }
         catch (Exception)
         { throw; }
      }

      public void ShowValidation()
      {
         try
         {
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Item.MensajeError, Dialogos.Boton.Detalles);
            FormShowErrorProvider<Entities.Chequera>.Validate(Item, this, errorProviderChequera);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }

      #endregion

      #region [ Eventos ]

      private void btnSalir_Click(object sender, EventArgs e)
      { this.Close(); }

      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            getItem();
            if (Item.Validar())
            {
               this.DialogResult = DialogResult.OK;
            }
            else { ShowValidation(); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ocurrio un error grabando la Chequera", ex); }
      }

      #endregion

      #region [ IFormClose ]

      #endregion

   }
}
