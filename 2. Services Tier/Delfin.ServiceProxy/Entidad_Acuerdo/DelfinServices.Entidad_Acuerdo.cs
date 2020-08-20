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
      #region [ Entidad_Acuerdo ]
      [Dependency]
      public IBLEntidad_Acuerdo BL_Entidad_Acuerdo { get; set; }

      public Boolean SaveEntidad_Acuerdo(Entidad_Acuerdo Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Entidad_Acuerdo.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Entidad_Acuerdo GetOneEntidad_Acuerdo(Int32 ACUE_Codigo)
      {
         try
         {
            return BL_Entidad_Acuerdo.GetOne(ACUE_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Entidad_Acuerdo> GetAllEntidad_Acuerdo()
      {
         try
         {
            return BL_Entidad_Acuerdo.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
