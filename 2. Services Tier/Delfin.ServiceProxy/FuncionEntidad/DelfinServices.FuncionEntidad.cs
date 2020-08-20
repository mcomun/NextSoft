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
      #region [ FuncionEntidad ]
      [Dependency]
      public IBLFuncionEntidad BL_FuncionEntidad { get; set; }

      public Boolean SaveFuncionEntidad(FuncionEntidad Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_FuncionEntidad.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public FuncionEntidad GetOneFuncionEntidad(Int32 ENTC_Codigo, Int16 TIPE_Codigo)
      {
         try
         {
            return BL_FuncionEntidad.GetOne(ENTC_Codigo, TIPE_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<FuncionEntidad> GetAllFuncionEntidad()
      {
         try
         {
            return BL_FuncionEntidad.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
