using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;
using System.Collections.ObjectModel;
using Microsoft.Practices.Unity;
using Infrastructure.Aspect.DataAccess;
using System.Data;

namespace Delfin.ServiceProxy
{
   using Delfin.ServiceContracts;
   using Delfin.BusinessLogic;
   using Delfin.Entities;

   public partial class DelfinServicesProxy : IDelfinServices
   {
      #region [ Det_Direccionamiento ]
      [Dependency]
      public IBLDet_Direccionamiento BL_Det_Direccionamiento { get; set; }

      public Boolean SaveDet_Direccionamiento(Det_Direccionamiento Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Det_Direccionamiento.Save(Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public DataTable GetOneDet_Direccionamiento(Int32 DDIR_Item, Int32 CDIR_Codigo)
      {
         try
         {
            return BL_Det_Direccionamiento.GetOne(DDIR_Item, CDIR_Codigo); 
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Det_Direccionamiento> GetAllDet_Direccionamiento()
      {
         try
         {
            return BL_Det_Direccionamiento.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
