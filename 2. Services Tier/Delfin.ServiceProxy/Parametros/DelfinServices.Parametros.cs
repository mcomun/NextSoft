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
      #region [ Parametros ]
      [Dependency]
      public IBLParametros BL_Parametros { get; set; }

      //public Boolean SaveParametros(Parametros Item)
      //{
      //   try
      //   {
      //      if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
      //      {
      //         return BL_Parametros.Save(ref Item);
      //      }
      //      return true;
      //   }
      //   catch (Exception ex)
      //   { throw ex; }
      //}

      public Boolean SaveParametros(ObservableCollection<Parametros> Items)
      {
         try
         {
            return BL_Parametros.Save(ref Items);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Parametros GetOneParametros(Int32 PARA_Codigo)
      {
         try
         {
            return BL_Parametros.GetOne(PARA_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Parametros> GetAllParametros()
      {
         try
         {
            return BL_Parametros.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
