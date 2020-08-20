using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.Constants;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.Constants;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.WinForms.Controls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace Delfin.Principal
{
   public partial class DOC001LView : UserControl, IDOC001LView
   {
      #region [ Variables ]
      Boolean _CargaGrid = false;
      
      #endregion
      #region [ Formulario ]
      public DOC001LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
      }
      #endregion
      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public DOC001Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      public BindingSource BSItemsDetalle { get; set; }
      public void LoadView()
      {
      }
      private void FormatDataGrid()
      {
      }

      private void FormatDataGridDetalles()
      {
      }

      void grdItemsDetalle_RowValidating(object sender, RowValidatingEventArgs e)
      {
      }

      public void ShowItems()
      {
      }

      public void ShowItemsDetalle()
      {
        
      }

      private void dgvItems_RowFormatting(object sender, RowFormattingEventArgs e)
      {
      }
      #endregion
      #region [ IFormClose ]


      private void TitleView_FormClose(object sender, EventArgs e)
      {
        
      }
      public event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
      #endregion

      #region [ Eventos ]
      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      { }
      private void BSItemsDetalle_CurrentItemChanged(object sender, EventArgs e)
      { 

      }
      private void SeleccionarItem()
      {
       }
      void grdItems_ValueChanged(object sender, EventArgs e)
      {
      }
      #endregion
      #region [ Metodos ]
      private void btnBuscar_Click(object sender, EventArgs e)
      {
        
      }

      #endregion

      private void btnAsignar_Click(object sender, EventArgs e)
      {
      }

      private void HabilitaBotones(Boolean Tipo)
      {
      }

      private void btnDeshacer_Click(object sender, EventArgs e)
      {
         
      }
      private void Deshacer()
      {
      }

      private void btnExportar_Click(object sender, EventArgs e)
      {
       
      }
      private void Exportar()
      {
      }

      private void CargarDatosForward(DataTable _dt)
      {
      }


      private void BtnForward_AyudaClick(object sender, EventArgs e)
      {
      } 
   }
}
