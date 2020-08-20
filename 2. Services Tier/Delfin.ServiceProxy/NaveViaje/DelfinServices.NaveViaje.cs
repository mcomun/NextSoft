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
      #region [ NaveViaje ]
      [Dependency]
      public IBLNaveViaje BL_NaveViaje { get; set; }

      public Int32 SaveNaveViaje(NaveViaje Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_NaveViaje.Save(ref Item);
            }
            return -1;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public NaveViaje GetOneNaveViaje(Int32 NVIA_Codigo)
      {
         try
         {
            return BL_NaveViaje.GetOne(NVIA_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<NaveViaje> GetAllNaveViaje()
      {
         try
         {
            return BL_NaveViaje.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
