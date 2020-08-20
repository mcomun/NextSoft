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
      public IBLSobreEstadia BL_SobreEstadia { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTSobreEstadia(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_SobreEstadia.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<SobreEstadia> GetAllSobreEstadiaFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_SobreEstadia.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<SobreEstadia> GetAllSobreEstadia()
      {
         try
         {
            return BL_SobreEstadia.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public SobreEstadia GetOneSobreEstadia(Int32 CONT_Codigo, Int16 SOES_Item)
      {
         try
         {
            return BL_SobreEstadia.GetOne(CONT_Codigo, SOES_Item);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveSobreEstadia(ref SobreEstadia Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_SobreEstadia.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
