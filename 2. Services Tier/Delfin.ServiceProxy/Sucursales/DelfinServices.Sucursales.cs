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
      #region [ Sucursales ]
      [Dependency]
      public IBLSucursales BL_Sucursales { get; set; }

      public Boolean SaveSucursales(Sucursales Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Sucursales.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Sucursales GetOneSucursales(Int16 SUCR_Codigo)
      {
         try
         {
            return BL_Sucursales.GetOne(SUCR_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Sucursales> GetAllSucursales()
      {
         try
         {
            return BL_Sucursales.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
