using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace Delfin.Principal
{
   public partial class CAJ006LiquidacionAgentesDViewConciliacion : Form, ICAJ006LiquidacionAgentesDViewConciliacion
   {
      #region [ Variables ]

      #endregion

      #region [ Propiedades ]

      public CAJ006LiquidacionAgentesPresenter Presenter { get; set; }
      public String PathPlantilla { get; set; }
      public String PathConciliacion { get; set; }

      #endregion

      #region [ Formulario ]

      public CAJ006LiquidacionAgentesDViewConciliacion()
      {
         InitializeComponent();
         try
         {
            btnAceptar.Click += btnAceptar_Click;
            txaConciliacion.Enabled = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario DView.", ex); }
      }

      #endregion

      #region [ ICUS002MView ]

      public void LoadView()
      {
         try
         {
            PathPlantilla = Path.Combine(Path.Combine(Application.StartupPath.ToString(), "Plantillas"), "pltConciliacionAgentes.xls");
            txaConciliacion.Enabled = true;
            txaConciliacion.AbrirButton.Visible = false;
            txaConciliacion.Filter = "Archivos de Excel (*.xls)|*.xls|Archivos de Excel (*.xlsx)| *.xlsx";
            //txaConciliacion.
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando controles", ex); }
      }

      #endregion

      #region [ Metodos ]

      #endregion

      #region [ Eventos ]

      private void btnAceptar_Click(object sender, EventArgs e)
      {
         try
         {
            if (!String.IsNullOrEmpty(txaConciliacion.FullPath))
            {
               if (File.Exists(txaConciliacion.FullPath))
               {
                  PathConciliacion = txaConciliacion.FullPath;
                  this.DialogResult = System.Windows.Forms.DialogResult.OK;
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No existe el archivo seleccionado.");
               }
            }
            else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No ha seleccionado ningun archivo para ser conciliado."); }
            this.Close();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un procesando la solicitud.", ex); }
      }

      #endregion

      #region [ IFormClose ]

      #endregion

   }
}
