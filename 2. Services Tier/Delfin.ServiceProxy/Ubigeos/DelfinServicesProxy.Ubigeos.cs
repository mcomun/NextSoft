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

   public partial class DelfinServices : IDelfinServices
   {
      #region [ Propiedades ]
      [Dependency]
      public IBLUbigeos BL_Ubigeos { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTUbigeos(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Ubigeos.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Ubigeos> GetAllUbigeosFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Ubigeos.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Ubigeos> GetAllUbigeos()
      {
         try
         {
            return BL_Ubigeos.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public Ubigeos GetOneUbigeos(String UBIG_Codigo, String TIPO_CodPais, String TIPO_TabPais)
      {
         try
         {
            return BL_Ubigeos.GetOne(UBIG_Codigo, TIPO_CodPais, TIPO_TabPais);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveUbigeos(ref Ubigeos Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Ubigeos.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
