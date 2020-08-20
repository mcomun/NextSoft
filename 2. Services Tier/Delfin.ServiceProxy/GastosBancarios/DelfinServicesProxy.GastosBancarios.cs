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
      public IBLGastosBancarios BL_GastosBancarios { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTGastosBancarios(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_GastosBancarios.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<GastosBancarios> GetAllGastosBancariosFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_GastosBancarios.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<GastosBancarios> GetAllGastosBancarios()
      {
         try
         {
            return BL_GastosBancarios.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public GastosBancarios GetOneGastosBancarios(Int16 EMPR_Codigo, Int32 TRAN_Codigo, Int32 GBAN_Codigo)
      {
         try
         {
            return BL_GastosBancarios.GetOne(EMPR_Codigo, TRAN_Codigo, GBAN_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveGastosBancarios(ref GastosBancarios Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_GastosBancarios.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
