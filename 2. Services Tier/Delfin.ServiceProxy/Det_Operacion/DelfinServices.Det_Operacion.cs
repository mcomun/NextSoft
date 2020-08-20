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
      #region [ Det_Operacion ]
      [Dependency]
      public IBLDet_Operacion BL_Det_Operacion { get; set; }

      public Boolean SaveDet_Operacion(Det_Operacion Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Det_Operacion.Save(Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Det_Operacion GetOneDet_Operacion(Int32 DOPE_Item, Int32 COPE_Codigo)
      {
         try
         {
            return BL_Det_Operacion.GetOne(DOPE_Item, COPE_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Det_Operacion> GetAllDet_OperacionByOperacion(Int32 x_COPE_Codigo)
      {
         try
         {
             return BL_Det_Operacion.GetAllByOperacion(x_COPE_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
