using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;
using System.Collections.ObjectModel;
using Microsoft.Practices.Unity;
using Infrastructure.Aspect.DataAccess;

namespace Delfin.ServiceProxy
{
   using Delfin.ServiceContracts;
   using Delfin.BusinessLogic;
   using Delfin.Entities;

   public partial class DelfinServicesProxy : IDelfinServices
   {
      #region [ Det_Tarjas ]
      [Dependency]
      public IBLDet_Tarjas BL_Det_Tarjas { get; set; }

      public Boolean SaveDet_Tarjas(Det_Tarjas Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Det_Tarjas.Save(Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Det_Tarjas GetOneDet_Tarjas(Int32 DTAJ_Item, Int32 TARJ_Codigo)
      {
         try
         {
            return BL_Det_Tarjas.GetOne(DTAJ_Item, TARJ_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Det_Tarjas> GetAllDet_TarjasPorTARJ_Codigo(Int32 x_TARJ_Codigo)
      {
         try
         {
             return BL_Det_Tarjas.GetAllDet_TarjasPorTARJ_Codigo(x_TARJ_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
