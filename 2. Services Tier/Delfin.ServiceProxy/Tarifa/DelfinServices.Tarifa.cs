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
      #region [ Tarifa ]
      [Dependency]
      public IBLTarifa BL_Tarifa { get; set; }

      public Boolean SaveTarifa(Tarifa Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Tarifa.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Boolean SaveTarifas(ObservableCollection<Tarifa> Items)
      {
         try
         {
            return BL_Tarifa.Save(ref Items);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Tarifa GetOneTarifa(Int32 TARI_Codigo)
      {
         try
         {
            return BL_Tarifa.GetOne(TARI_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Tarifa> GetAllTarifa()
      {
         try
         {
            return BL_Tarifa.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
