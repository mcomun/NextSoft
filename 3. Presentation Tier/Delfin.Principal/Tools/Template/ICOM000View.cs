using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface ICOM000LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      COM000Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView(Int16 CCOT_Tipo);
      void ShowItems();
   }
   public interface ICOM000MView
   {
      COM000Presenter Presenter { get; set; }

      void LoadView(Int16 CCOT_Codigo);

      void ClearItem();
      void GetItem();
      void SetItem();
      
      void ShowValidation();

   }

}
