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
   public partial class MotivoAnulacion : Form
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]

      public MotivoAnulacion()
      {
         InitializeComponent();
         try
         {
            txtUsuario.Enabled = false;
            dtpFecha.Enabled = false;
            txtObservación.MaxLength = 100;

            btnAceptar.Click += btnAceptar_Click;
            btnCancelar.Click += btnCancelar_Click;
         }
         catch (Exception)
         { }
      }

      public DialogResult LoadControl(DateTime Fecha, String Usuario)
      {
         try
         {
            dtpFecha.NSFecha = Fecha;
            txtUsuario.Text = Usuario;

            return this.ShowDialog();
         }
         catch (Exception)
         { return DialogResult.Cancel; }
      }

      #endregion

      #region [ Propiedades ]

      public String Observacion { get { return txtObservación.Text; } }

      #endregion

      #region [ ICUS002MView ]

      #endregion

      #region [ Metodos ]

      private Boolean Validar()
      {
         try
         {
            Boolean _esCorrecto = true;
            String _errorMensaje = String.Empty;
            if (String.IsNullOrEmpty(txtObservación.Text))
            {
               _errorMensaje += "Debe Ingresar una observación." + Environment.NewLine;
               errorValidacion.SetError(txtObservación, "Debe Ingresar una observación.");
               _esCorrecto = false;
            }
            return _esCorrecto;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(this.Text, "Ha ocurrido error un validar el motivo de anulación.", ex); return false; }
      }

      #endregion

      #region [ Eventos ]

      private void btnCancelar_Click(object sender, EventArgs e)
      { this.DialogResult = System.Windows.Forms.DialogResult.Cancel; }

      private void btnAceptar_Click(object sender, EventArgs e)
      {
         if (Validar())
         { this.DialogResult = System.Windows.Forms.DialogResult.OK; }
      }

      #endregion

   }
}
