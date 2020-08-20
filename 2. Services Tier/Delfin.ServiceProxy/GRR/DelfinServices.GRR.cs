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
      #region [ GRR ]
      [Dependency]
      public IBLGRR BL_GRR { get; set; }

      public Boolean SaveGRR(GRR Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_GRR.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public GRR GetOneGRR(Int32 REBA_Codigo)
      {
         try
         {
            return BL_GRR.GetOne(REBA_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<GRR> GetAllGRR()
      {
         try
         {
            return BL_GRR.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
