using System.Drawing;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
   public interface IPRO009LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      PRO009Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
   }
   public interface IPRO009MView
   {
      PRO009Presenter Presenter { get; set; }
      void LoadView();
      void ClearItem();
      void GetItem();
      void SetItem();
      void ShowValidation();
      void SetInstance(InstanceView xInstance);
   }
}
