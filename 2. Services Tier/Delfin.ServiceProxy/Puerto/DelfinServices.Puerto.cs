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
      #region [ Puerto ]
      [Dependency]
      public IBLPuerto BL_Puerto { get; set; }

      public Boolean SavePuerto(Puerto Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Puerto.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Puerto GetOnePuerto(Int32 PUER_Codigo)
      {
         try
         {
            return BL_Puerto.GetOne(PUER_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Puerto> GetAllPuerto()
      {
         try
         {
            return BL_Puerto.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
