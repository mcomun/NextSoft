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
      #region [ Det_Tarifa ]
      [Dependency]
      public IBLDet_Tarifa BL_Det_Tarifa { get; set; }

      public Boolean SaveDet_Tarifa( ref Det_Tarifa Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Det_Tarifa.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Boolean SavesDet_Tarifa(ref ObservableCollection<Det_Tarifa> Items)
      {
          try
          {
              return BL_Det_Tarifa.Saves(ref Items);
              
          }
          catch (Exception ex)
          { throw ex; }
      }
      public Det_Tarifa GetOneDet_Tarifa(Int32 CTAR_Codigo, String CTAR_Tipo, String DTAR_Item)
      {
         try
         {
            return BL_Det_Tarifa.GetOne(CTAR_Codigo, CTAR_Tipo, DTAR_Item);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Det_Tarifa> GetAllDet_Tarifa()
      {
         try
         {
            return BL_Det_Tarifa.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
