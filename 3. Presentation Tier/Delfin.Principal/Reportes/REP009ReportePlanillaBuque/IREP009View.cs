using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface IREP009LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      REP009Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
      void FormatDataGrid(String CONS_CodRGM);
      void ShowItems(System.Data.DataTable dt);

   }
}
