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
   public partial class OPE001TView : Form
   {
      public OPE001TView(String Title, String Texto, Int32 MaxLength, Boolean ReadOnly = false)
      {
         InitializeComponent();

         this.Text = Title;
         txtTexto.Text = Texto;
         txtTexto.MaxLength = MaxLength;
         txtTexto.ReadOnly = ReadOnly;

         btnAceptar.Click += btnAceptar_Click;
         btnCancelar.Click += btnCancelar_Click;

         btnCancelar.Visible = !ReadOnly;
      }

      private void btnAceptar_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.OK;
      }

      private void btnCancelar_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      }

      public String Texto { get { return txtTexto.Text; } }
   }
}
