﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Delfin.Logistico
{
    public interface IREP006LView
    {

        Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        REP006Presenter Presenter { get; set; }
        Image IconView { get; set; }
        event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

        void LoadView();
        void LoadFilters();
        void ShowValidation();
    }
    public interface IPRO006RView
    {
        /* Impresión */
        REP006Presenter Presenter { get; set; }
        void ShowReporte();

    }
}
