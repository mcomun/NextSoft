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
      #region [ Rebate ]
      [Dependency]
      public IBLRebate BL_Rebate { get; set; }

      public Boolean SaveRebate(Rebate Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Rebate.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Rebate GetOneRebate(Int32 REBA_Codigo)
      {
         try
         {
            return BL_Rebate.GetOne(REBA_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Rebate> GetAllRebate(string x_CONC_TabReb,string x_CONC_CodReb ,string x_ENTC_CodTransportista ,DateTime x_REBA_FecIni )
      {
         try
         {
            return BL_Rebate.GetAll(  x_CONC_TabReb,  x_CONC_CodReb ,  x_ENTC_CodTransportista ,  x_REBA_FecIni );
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
