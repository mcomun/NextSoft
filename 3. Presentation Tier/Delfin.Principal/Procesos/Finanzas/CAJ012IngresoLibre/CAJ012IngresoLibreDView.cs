using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal.Procesos.Finanzas
{
   public partial class CAJ012IngresoLibreDView : Form
   {

      public Entities.CtaCte.TipoDesvAsiento TOpcion { get; set; }

      public CAJ012IngresoLibreDView(String x_asiento)
      {
         InitializeComponent();
         try
         {
            btnAceptar.Click += btnAceptar_Click;
            txtAsientos.ReadOnly = true;
            txtAsientos.Text = x_asiento;
         }
         catch (Exception)
         { throw; }
      }

      private void btnAceptar_Click(object sender, EventArgs e)
      {
         try
         {
            SetTipoOpcion();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
         }
         catch (Exception)
         { throw; }
      }

      private void SetTipoOpcion()
      {
         if (rbtnAnular.Checked)
            TOpcion = Entities.CtaCte.TipoDesvAsiento.Anular;
         else if (rbtnEliminar.Checked)
            TOpcion = Entities.CtaCte.TipoDesvAsiento.Eliminar;
         else
            TOpcion = Entities.CtaCte.TipoDesvAsiento.Anular;
      }

   }
}
