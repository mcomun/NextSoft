using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface IREP014View
   {
      REP014Presenter Presenter { get; set; }

      void LoadView();
      //void ShowValidation();
   }
}
