using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface ICAJ011AnularDocBancosLView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      CAJ011AnularDocBancosPresenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
   }
   //public interface ICAJ011AnularDocBancosMView
   //{
   //   CAJ011AnularDocBancosPresenter Presenter { get; set; }

   //   void LoadView();

   //   void ClearItem();
   //   void GetItem();
   //   void SetItem();
      
   //   void ShowValidation();

   //}
}
