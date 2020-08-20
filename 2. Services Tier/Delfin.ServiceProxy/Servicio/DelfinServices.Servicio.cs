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
      #region [ Servicio ]
      [Dependency]
      public IBLServicio BL_Servicio { get; set; }

      public Boolean SaveServicio(Servicio Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Servicio.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Servicio GetOneServicio(Int32 SERV_Codigo)
      {
         try
         {
            return BL_Servicio.GetOne(SERV_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public System.Data.DataTable GetServiciosAdicionales(Int32 SERV_Codigo)
      {
         try
         {
            return BL_Servicio.GetServiciosAdicionales(SERV_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }
      public ObservableCollection<Servicio> GetAllServicio()
      {
         try
         {
            return BL_Servicio.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
