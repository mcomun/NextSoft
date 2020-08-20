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
      #region [ Paquete ]
      [Dependency]
      public IBLPaquete BL_Paquete { get; set; }

      public Boolean SavePaquete(Paquete Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Paquete.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Paquete GetOnePaquete(Int32 PACK_Codigo)
      {
         try
         {
            return BL_Paquete.GetOne(PACK_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Paquete> GetAllPaquete()
      {
         try
         {
            return BL_Paquete.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
