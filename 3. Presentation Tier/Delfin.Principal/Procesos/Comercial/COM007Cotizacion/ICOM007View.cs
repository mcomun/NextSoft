using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface ICOM007LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      COM007Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView(Int16 CCOT_Tipo);
      void ShowItems();
   }
   public interface ICOM007MView
   {
      COM007Presenter Presenter { get; set; }

      void LoadView(Int16 CCOT_Codigo);

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

   }
   public interface ICOM007OView
   {
      COM007Presenter Presenter { get; set; }

      void LoadView(Int16 CCOT_Codigo);

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

   }

   public interface ICOM007RView
   {
      COM007Presenter Presenter { get; set; }

      void ShowItems();
   }
}
