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
      #region [ Servicio_Via ]
      [Dependency]
      public IBLServicio_Via BL_Servicio_Via { get; set; }

      public Boolean SaveServicio_Via(Servicio_Via Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Servicio_Via.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Servicio_Via GetOneServicio_Via(String CONS_TabVIA, String CONS_CodVIA, Int32 SERV_Codigo)
      {
         try
         {
            return BL_Servicio_Via.GetOne(CONS_TabVIA, CONS_CodVIA, SERV_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Servicio_Via> GetAllServicio_Via()
      {
         try
         {
            return BL_Servicio_Via.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
