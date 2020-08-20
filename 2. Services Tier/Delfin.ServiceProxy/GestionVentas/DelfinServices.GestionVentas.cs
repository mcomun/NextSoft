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
      #region [ GestionVentas ]
      [Dependency]
      public IBLGestionVentas BL_GestionVentas { get; set; }

      public Boolean SaveGestionVentas(GestionVentas Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_GestionVentas.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public GestionVentas GetOneGestionVentas(Int32 GEST_Codigo)
      {
         try
         {
            return BL_GestionVentas.GetOne(GEST_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<GestionVentas> GetAllGestionVentas()
      {
         try
         {
            return BL_GestionVentas.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
