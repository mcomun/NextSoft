using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;
using System.Collections.ObjectModel;
using Microsoft.Practices.Unity;
using Infrastructure.Aspect.DataAccess;
using Delfin.ServiceContracts;
using Delfin.BusinessLogic;
using Delfin.Entities;


namespace Delfin.ServiceProxy
{
  

   public partial class DelfinServicesProxy : IDelfinServices
   {
      #region [ Nave ]
       [Dependency]
       public IBLNave BL_Nave { get; set; }

      public Boolean SaveNave(Nave Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Nave.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Nave GetOneNave(Int16 NAVE_Codigo)
      {
         try
         {
             return BL_Nave.GetOne(NAVE_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Nave> GetAllNave(string x_ENTC_CodTransportista)
      {
         try
         {
             return BL_Nave.GetAll(x_ENTC_CodTransportista);
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
