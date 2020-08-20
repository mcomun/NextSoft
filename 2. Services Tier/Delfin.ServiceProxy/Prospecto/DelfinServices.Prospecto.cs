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
      #region [ Prospecto ]
      [Dependency]
      public IBLProspecto BL_Prospecto { get; set; }

      public Boolean SaveProspecto(Prospecto Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Prospecto.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Prospecto GetOneProspecto(Int32 PROS_codigo)
      {
         try
         {
            return BL_Prospecto.GetOne(PROS_codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Prospecto> GetAllProspecto()
      {
         try
         {
            return BL_Prospecto.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
