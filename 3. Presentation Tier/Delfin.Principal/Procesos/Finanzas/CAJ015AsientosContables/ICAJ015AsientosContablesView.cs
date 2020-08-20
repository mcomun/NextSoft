using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface ICAJ015AsientosContablesLView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      CAJ015AsientosContablesPresenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
   }
   //public interface ICAJ015AsientosContablesMView
   //{
   //   CAJ015AsientosContablesPresenter Presenter { get; set; }

   //   void LoadView(Int16 CCOT_Codigo);

   //   void ClearItem();
   //   void GetItem();
   //   void SetItem();
      
   //   void ShowValidation();

   //}

}
