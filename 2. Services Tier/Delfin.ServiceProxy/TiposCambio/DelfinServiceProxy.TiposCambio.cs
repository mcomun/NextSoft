using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.ObjectModel;

namespace Delfin.ServiceProxy
{
   using Delfin.Entities;

   public partial class DelfinServicesProxy : ClientBase<ServiceContracts.IDelfinServices>, ServiceContracts.IDelfinServices
   {
      #region [ TiposCambio ]
      public Boolean SaveTiposCambio(TiposCambio Item)
      {
         try
         { return base.Channel.SaveTiposCambio(Item); }
         catch (Exception ex)
         { throw ex; }
      }

      public TiposCambio GetOneTiposCambio(String TIPC_Fecha)
      {
         try
         { return base.Channel.GetOneTiposCambio(TIPC_Fecha); }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<TiposCambio> GetAllTiposCambio(String TIPC_AnoMes)
      {
         try
         { return base.Channel.GetAllTiposCambio(TIPC_AnoMes); }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
