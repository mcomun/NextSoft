using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delfin.Principal
{
   public interface IMAN005LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      MAN005Presenter Presenter { get; set; }
      System.Drawing.Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
   }
   public interface IMAN005MView
   {
      MAN005Presenter Presenter { get; set; }

      void LoadView();

      void ClearItem();
      void GetItem();
      void SetItem();

      void ShowValidation();
   }
}
