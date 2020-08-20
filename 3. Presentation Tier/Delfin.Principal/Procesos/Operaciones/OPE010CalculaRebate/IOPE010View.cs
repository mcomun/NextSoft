using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface IOPE010View
   {
      OPE010Presenter Presenter { get; set; }

      void LoadView();
      //void ShowValidation();
   }
}
