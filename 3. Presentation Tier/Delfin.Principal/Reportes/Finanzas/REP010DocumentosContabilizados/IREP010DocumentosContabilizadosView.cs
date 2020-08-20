using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface IREP010DocumentosContabilizadosLView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      REP010DocumentosContabilizadosPresenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();

      void ShowItems();
   }
   //public interface IREP010DocumentosContabilizadosMView
   //{
   //   REP010DocumentosContabilizadosPresenter Presenter { get; set; }

   //   void LoadView(Int16 CCOT_Codigo);

   //   void ClearItem();
   //   void GetItem();
   //   void SetItem();
      
   //   void ShowValidation();

   //}

}
