using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface IREP007AntiguedadDeudaLView
   {

      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      REP007AntiguedadDeudaPresenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();

   }
}
