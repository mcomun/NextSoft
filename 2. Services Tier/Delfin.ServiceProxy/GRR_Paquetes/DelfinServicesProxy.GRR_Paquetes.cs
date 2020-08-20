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
      public IBLGRR_Paquetes BL_GRR_Paquetes { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTGRR_Paquetes(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_GRR_Paquetes.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<GRR_Paquetes> GetAllGRR_PaquetesFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_GRR_Paquetes.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<GRR_Paquetes> GetAllGRR_Paquetes()
      {
         try
         {
            return BL_GRR_Paquetes.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public GRR_Paquetes GetOneGRR_Paquetes(String REBA_Tipo, Int32 REBA_Codigo, Int32 PACK_Codigo)
      {
         try
         {
            return BL_GRR_Paquetes.GetOne(REBA_Tipo, REBA_Codigo, PACK_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveGRR_Paquetes(ref GRR_Paquetes Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_GRR_Paquetes.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
