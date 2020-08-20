using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface ICAJ018AsientosStatementLView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      CAJ018AsientosStatementPresenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
      void ShowItems();

      void LoadView();
   }
   //public interface ICAJ018AsientosStatementMView
   //{
   //   CAJ018AsientosStatementPresenter Presenter { get; set; }

   //   void LoadView(Int16 CCOT_Codigo);

   //   void ClearItem();
   //   void GetItem();
   //   void SetItem();
      
   //   void ShowValidation();

   //}

}
