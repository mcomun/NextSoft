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
      #region [ Empresa ]
      [Dependency]
      public IBLEmpresa BL_Empresa { get; set; }

      public Boolean SaveEmpresa(Empresa Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Empresa.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Empresa GetOneEmpresa(Int16 EMPR_Codigo)
      {
         try
         {
            return BL_Empresa.GetOne(EMPR_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Empresa> GetAllEmpresa()
      {
         try
         {
            return BL_Empresa.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
