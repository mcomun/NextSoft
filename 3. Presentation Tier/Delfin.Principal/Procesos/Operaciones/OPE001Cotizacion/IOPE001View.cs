using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface IOPE001LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      OPE001Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
   }
   public interface IOPE001MView
   {
      OPE001Presenter Presenter { get; set; }

      void LoadView();

      void ClearItem();
      void GetItem();
      void SetItem();

      void ClearItemContrato();
      void SetItemContrato(Boolean ActualizarContrato);

      void ClearItemViaje();
      void SetItemViaje();

      void GetItemNovedad();
      void ClearItemNovedad();
      void ShowValidationItemNovedad();
      void ShowNovedades();
      
      void ShowValidation();

      void SelectTab(Int16 index);


      #region [ MatrizDraft ]
      void ShowImportacionMatrizDraft();
      #endregion
   }
}
