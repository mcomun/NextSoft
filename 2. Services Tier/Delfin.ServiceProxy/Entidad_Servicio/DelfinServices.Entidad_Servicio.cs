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
      #region [ Entidad_Servicio ]
      [Dependency]
      public IBLEntidad_Servicio BL_Entidad_Servicio { get; set; }

      public Boolean SaveEntidad_Servicio(Entidad_Servicio Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Entidad_Servicio.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Entidad_Servicio GetOneEntidad_Servicio(Int32 ESER_Codigo)
      {
         try
         {
            return BL_Entidad_Servicio.GetOne(ESER_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Entidad_Servicio> GetAllEntidad_Servicio(Int32 ENTC_Codigo)
      {
         try
         {
            return BL_Entidad_Servicio.GetAll(ENTC_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
