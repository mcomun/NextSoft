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
      #region [ Det_Seguimientos ]
      [Dependency]
      public IBLDet_Seguimientos BL_Det_Seguimientos { get; set; }

      public Boolean SaveDet_Seguimientos(Det_Seguimientos Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Det_Seguimientos.Save(Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Det_Seguimientos GetOneDet_Seguimientos(Int32 CSEG_Codigo)
      {
         try
         {
            return BL_Det_Seguimientos.GetOne(CSEG_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Det_Seguimientos> GetAllDet_Seguimientos()
      {
         try
         {
            return BL_Det_Seguimientos.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
