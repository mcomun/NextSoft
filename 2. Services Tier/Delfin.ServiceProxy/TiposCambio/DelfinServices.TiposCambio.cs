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
      #region [ TiposCambio ]
      [Dependency]
      public IBLTiposCambio BL_TiposCambio { get; set; }

      public Boolean SaveTiposCambio(TiposCambio Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_TiposCambio.Save(Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public TiposCambio GetOneTiposCambio(String TIPC_Fecha)
      {
         try
         {
            return BL_TiposCambio.GetOne(TIPC_Fecha);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<TiposCambio> GetAllTiposCambio(String x_TIPC_AnoMes)
      {
         try
         {
            return BL_TiposCambio.GetAll(x_TIPC_AnoMes);
         }
         catch (Exception ex)
         { throw ex; }
      }

      #endregion
   }
}
