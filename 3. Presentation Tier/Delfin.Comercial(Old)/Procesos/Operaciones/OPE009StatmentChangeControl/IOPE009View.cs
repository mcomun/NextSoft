using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Comercial
{
   public interface IOPE009View
   {
      OPE009Presenter Presenter { get; set; }

      void LoadView();
      void ShowValidation();
   }
}
