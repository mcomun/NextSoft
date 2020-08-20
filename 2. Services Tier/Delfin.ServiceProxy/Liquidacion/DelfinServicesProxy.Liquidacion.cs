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
      public IBLLiquidacion BL_Liquidacion { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTLiquidacion(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Liquidacion.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Liquidacion> GetAllLiquidacionFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Liquidacion.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Liquidacion> GetAllLiquidacion()
      {
         try
         {
            return BL_Liquidacion.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public Liquidacion GetOneLiquidacion(Int16 EMPR_Codigo, String LIQU_Codigo)
      {
         try
         {
            return BL_Liquidacion.GetOne(EMPR_Codigo, LIQU_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveLiquidacion(ref Liquidacion Item)
      {
         try
         {
            return BL_Liquidacion.Save(ref Item);
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
