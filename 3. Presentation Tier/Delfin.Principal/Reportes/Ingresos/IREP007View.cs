using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Delfin.Principal
{
    public interface IREP007LView
    {

        Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        REP007Presenter Presenter { get; set; }
        Image IconView { get; set; }
        event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

        void LoadView();
        void LoadFilters();
        void ShowValidation();
        void ShowReporte();

    }
    public interface IPRO007RMView
    {
        /* Impresión */
        REP007Presenter Presenter { get; set; }
        void ShowReporte();

    }
}
