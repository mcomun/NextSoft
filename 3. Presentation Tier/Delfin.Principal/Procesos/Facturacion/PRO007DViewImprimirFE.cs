using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.WinFormsControls;

namespace Delfin.Principal
{
   public partial class PRO007DViewImprimirFE : Form
   {
      #region [ Variables ]

      #endregion

      #region [ Propiedades ]

      public PRO007Presenter Presenter { get; set; }
      public String email { get; set; }      
      public String Imprimir { get; set; }
      public int entidad { get; set; }

      #endregion

      #region [ Formulario ]

      public PRO007DViewImprimirFE()
      {
         InitializeComponent();
         try
         {
            btnImprimir.Click += btnImprimir_Click;

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar el modulo", ex); }
      }


      #endregion

      #region [ IPRO007DViewFPG ]

      #endregion

      #region [ Metodos ]

      public void LoadView()
      {
         try
         {
            

            
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar el modulo", ex); }
      }

      
      

      public void ShowValidation() { }

      #endregion

      #region [ Eventos ]

      private void btnImprimir_Click(object sender, EventArgs e)
      {

          email = txtEmail.Text;
          AppService.DelfinServiceClient oAppService = new AppService.DelfinServiceClient();
          oAppService.ExecuteSQLNonQuery("UPDATE NextSoft.dbo.Entidad SET ENTC_EmailReceptorFE='" + email + "' WHERE ENTC_Codigo='" + entidad + "'");

         //try
         //{
         //   GetItem();
         //   if (txaSeries.SelectedItem != null && !String.IsNullOrEmpty(txaSeries.SelectedItem.SERI_Serie))
         //   {
         //      if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Desea confirmar los cambios realizados?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
         //      {
         //         this.DialogResult = System.Windows.Forms.DialogResult.OK;
         //         this.Close();
         //      }
         //   }
         //   else { Dialogos.MostrarMensajeError(Presenter.Title, "No ha seleccionado un numero de serie valido"); }
         //}
         //catch (Exception ex)
         //{ Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al grabar el cambio", ex); }
      }

      #endregion



      #region [ IFormClose ]

      #endregion
   }
}
