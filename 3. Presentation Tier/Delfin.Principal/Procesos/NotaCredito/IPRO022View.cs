using System.Drawing;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
   public interface IPRO022LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      PRO022Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
      void FiltrosLView();

   }
   public interface IPRO022MView
   {
      PRO022Presenter Presenter { get; set; }
      void LoadView();
      void ClearItem();
      void GetItem();
      void SetItem();
      void SetInstance(InstanceView xInstance);
      void ShowValidation();
      void GetItemReferencia();
     
   }
   public interface IPRO022RView
   {
       /* Impresión */
       PRO022Presenter Presenter { get; set; }
       void ShowReporte();

   }
}
