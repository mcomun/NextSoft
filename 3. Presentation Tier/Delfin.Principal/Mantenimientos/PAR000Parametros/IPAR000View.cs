using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delfin.Principal
{
    public interface IPAR000MView
    {
        PAR000Presenter Presenter { get; set; }

        void LoadView();

        void ClearItem();
        Boolean GetItem();
        void SetItem();
    }
}