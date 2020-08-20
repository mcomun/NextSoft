using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Comercial
{
    public interface ICAJ017View
    {
        CAJ017Presenter Presenter { get; set; }
        void LoadView();
    }
}
