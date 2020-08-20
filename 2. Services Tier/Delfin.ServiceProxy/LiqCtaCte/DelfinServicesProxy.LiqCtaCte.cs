using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;
using System.Collections.ObjectModel;
using Microsoft.Practices.Unity;
using Infrastructure.Aspect.DataAccess;
using Delfin.ServiceContracts;
using Delfin.BusinessLogic;
using Delfin.Entities;

namespace Delfin.ServiceProxy
{

   public partial class DelfinServicesProxy : IDelfinServices
   {
      #region [ Propiedades ]
      [Dependency]
      public IBLLiqCtaCte BL_LiqCtaCte { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTLiqCtaCte(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_LiqCtaCte.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<LiqCtaCte> GetAllLiqCtaCteFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_LiqCtaCte.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<LiqCtaCte> GetAllLiqCtaCte()
      {
         try
         {
            return BL_LiqCtaCte.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public LiqCtaCte GetOneLiqCtaCte(Int16 EMPR_Codigo, String LIQU_Codigo, Int32 CCCT_Codigo, Int16 LCCC_Item)
      {
         try
         {
            return BL_LiqCtaCte.GetOne(EMPR_Codigo, LIQU_Codigo, CCCT_Codigo, LCCC_Item);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveLiqCtaCte(ref LiqCtaCte Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_LiqCtaCte.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
