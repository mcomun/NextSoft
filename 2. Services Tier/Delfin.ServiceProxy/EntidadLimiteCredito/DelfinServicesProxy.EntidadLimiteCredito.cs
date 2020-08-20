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
      #region [ Propiedades ]
      [Dependency]
      public IBLEntidadLimiteCredito BL_EntidadLimiteCredito { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTEntidadLimiteCredito(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_EntidadLimiteCredito.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<EntidadLimiteCredito> GetAllEntidadLimiteCreditoFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_EntidadLimiteCredito.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<EntidadLimiteCredito> GetAllEntidadLimiteCredito()
      {
         try
         {
            return BL_EntidadLimiteCredito.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public EntidadLimiteCredito GetOneEntidadLimiteCredito(Int32 ENTC_Codigo, Int16 TIPE_Codigo, String ENLI_Tipos, Int16 ENLI_Codigo)
      {
         try
         {
            return BL_EntidadLimiteCredito.GetOne(ENTC_Codigo, TIPE_Codigo, ENLI_Tipos, ENLI_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveEntidadLimiteCredito(ref EntidadLimiteCredito Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_EntidadLimiteCredito.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
