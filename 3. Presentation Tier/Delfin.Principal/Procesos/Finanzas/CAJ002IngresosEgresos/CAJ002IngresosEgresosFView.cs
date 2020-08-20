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
   public partial class CAJ002IngresosEgresosFView : Form
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]

      public CAJ002IngresosEgresosFView()
      {
         InitializeComponent();
         try
         {
            dtpMOVI_FecDiferidoNow.Enabled = false;
            lblMOVI_FecDiferidoNow.Enabled = false;

            btnAceptar.Click += btnAceptar_Click;
         }
         catch (Exception)
         { }
      }
      
      public void LoadView(DateTime x_FechaActual)
      {
         try
         {
            dtpMOVI_FecDiferidoNow.NSFecha = x_FechaActual;
            FechaActual = x_FechaActual;
         }
         catch (Exception)
         { }
      }

      #endregion

      #region [ Propiedades ]

      public Nullable<DateTime> FechaDiferido { get; set; }
      public DateTime FechaActual { get; set; }

      #endregion

      #region [ ICUS002MView ]

      #endregion

      #region [ Metodos ]

      private void Aceptar()
      {
         try
         {
            if (dtpMOVI_FecDiferidoNew.NSFecha.HasValue)
            {
               if (dtpMOVI_FecDiferidoNew.NSFecha.Value.Date > FechaActual.Date)
               {
                  FechaDiferido = dtpMOVI_FecDiferidoNew.NSFecha;
                  this.DialogResult = System.Windows.Forms.DialogResult.OK;
                  this.Close();
               }
               else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Rediferir", "Debe seleccionar una fecha superior a la actualmente seleccionada."); }
            }
            else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Rediferir", "Debe seleccionar una fecha valida para poder continuar."); }
         }
         catch (Exception)
         { }
      }

      #endregion

      #region [ Eventos ]

      private void btnAceptar_Click(object sender, EventArgs e)
      { Aceptar(); }

      #endregion

   }
}
