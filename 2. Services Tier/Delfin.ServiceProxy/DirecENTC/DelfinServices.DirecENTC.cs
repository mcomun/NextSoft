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
      #region [ DirecENTC ]
      [Dependency]
      public IBLDirecENTC BL_DirecENTC { get; set; }

      public Boolean SaveDirecENTC(DirecENTC Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_DirecENTC.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public DirecENTC GetOneDirecENTC(Int32 ENTC_Codigo, Int16 DIRE_Codigo)
      {
         try
         {
            return BL_DirecENTC.GetOne(ENTC_Codigo, DIRE_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<DirecENTC> GetAllDirecENTC(Int32 x_ENTC_Codigo)
      {
         try
         {
            return BL_DirecENTC.GetAll(x_ENTC_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
