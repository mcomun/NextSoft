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
      #region [ PreDetDocsVta ]
      [Dependency]
      public IBLPreDetDocsVta BL_PreDetDocsVta { get; set; }

      public Boolean SavePreDetDocsVta(PreDetDocsVta Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_PreDetDocsVta.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public PreDetDocsVta GetOnePreDetDocsVta(Int16 PDDO_Item, Int32 DOCV_Codigo)
      {
         try
         {
            return BL_PreDetDocsVta.GetOne(PDDO_Item, DOCV_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<PreDetDocsVta> GetAllPreDetDocsVtaPorDOCV_Codigo(Int32 x_DOCV_Codigo)
      {
         try
         {
             return BL_PreDetDocsVta.GetAllPorDOCV_Codigo(x_DOCV_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
