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
      #region [ Ubigeos ]
      [Dependency]
      public IBLUbigeos BL_Ubigeos { get; set; }

      public Boolean SaveUbigeos(Ubigeos Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Ubigeos.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Ubigeos GetOneUbigeos(String UBIG_Codigo, String TIPO_CodPais, String TIPO_TabPais)
      {
         try
         {
            return BL_Ubigeos.GetOne(UBIG_Codigo, TIPO_CodPais, TIPO_TabPais);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Ubigeos> GetAllUbigeos()
      {
         try
         {
            return BL_Ubigeos.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
