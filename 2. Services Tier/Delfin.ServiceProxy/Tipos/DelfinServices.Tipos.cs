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
      #region [ Tipos ]
      [Dependency]
      public IBLTipos BL_Tipos { get; set; }

      public Boolean SaveTipos(Tipos Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Tipos.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Tipos GetOneTipos(String TIPO_CodTabla, String TIPO_CodTipo)
      {
         try
         {
            return BL_Tipos.GetOne(TIPO_CodTabla, TIPO_CodTipo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Tipos> GetAllTipos()
      {
         try
         {
            return BL_Tipos.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
