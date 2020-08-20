﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Comercial
{
   public interface IOPE008LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      OPE008Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();

   }
}
