using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Delfin.Principal
{
    public interface IREP005LView
    {

        Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        REP005Presenter Presenter { get; set; }
        Image IconView { get; set; }
        event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

        void LoadView();
        void ShowItems();
        void LoadFilters();
        void ShowValidation();
    }
    public interface IPRO005RView
    {
        /* Impresión */
        REP005Presenter Presenter { get; set; }
        void ShowReporte();

    }
}
