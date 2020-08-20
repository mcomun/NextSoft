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
      #region [ Rebate ]
      public Boolean SaveRebate(Rebate Item)
      {
         try
         { return base.Channel.SaveRebate(Item); }
         catch (Exception ex)
         { throw ex; }
      }

      public Rebate GetOneRebate(Int32 REBA_Codigo)
      {
         try
         { return base.Channel.GetOneRebate(REBA_Codigo); }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Rebate> GetAllRebate(string x_CONC_TabReb, string x_CONC_CodReb, string x_ENTC_CodTransportista, DateTime x_REBA_FecIni)
      {
         try
         { return base.Channel.GetAllRebate(  x_CONC_TabReb,  x_CONC_CodReb ,  x_ENTC_CodTransportista ,  x_REBA_FecIni ); }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
