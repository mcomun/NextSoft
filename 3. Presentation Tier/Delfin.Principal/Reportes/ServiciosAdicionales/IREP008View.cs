using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Delfin.Principal
{
    public interface IREP008LView
    {

        Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        REP008Presenter Presenter { get; set; }
        Image IconView { get; set; }
        event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

        void LoadView();
        void LoadFilters();
        void ShowValidation();
    }
    public interface IPRO008RMView
    {
        /* Impresión */
        REP008Presenter Presenter { get; set; }
        void ShowReporte();

    }
}
