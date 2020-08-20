using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal.Procesos.Finanzas.CAJ012IngresoLibre
{
   public partial class CAJ012IngresoLibreAView : Form
   {
      public int CCCT_Codigo { get; set; }
      public String CCCT_Numero { get; set; }
      public DateTime CCCT_FechaEmision { get; set; }
      public DateTime CCCT_FecReg { get; set; }

      public CAJ012IngresoLibreAView()
      {
         InitializeComponent();
         try
         {
            txtCCCT_Numero.ReadOnly = true;
                        
            txtCCCT_Codigo.Enabled = false;
            label2.Enabled = false;

            btnAceptar.Click += btnAceptar_Click;
         }
         catch (Exception)
         { throw; }
      }

      public void LoadView()
      {
         try
         {
            txtCCCT_Numero.Text = CCCT_Numero;
            dtpCCCT_FechaEmision.NSFecha = CCCT_FechaEmision;
            dtpCCCT_FecReg.Value = CCCT_FecReg;
            txtCCCT_Codigo.Text = CCCT_Codigo.ToString();
         }
         catch (Exception)
         { throw; }
      }

      private void btnAceptar_Click(object sender, EventArgs e)
      {
         try
         {
            if (dtpCCCT_FechaEmision.NSFecha.HasValue) { this.CCCT_FechaEmision = dtpCCCT_FechaEmision.NSFecha.Value; }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(this.Text, String.Format("El documento requiere una fecha de Emisión."));
               return;
            }
            this.CCCT_FecReg = dtpCCCT_FecReg.Value;
            
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
         }
         catch (Exception)
         { throw; }
      }


   }
}
