using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface IOPE004View
   {
      OPE004Presenter Presenter { get; set; }

      void LoadView();
      void ShowValidation();
   }
}
