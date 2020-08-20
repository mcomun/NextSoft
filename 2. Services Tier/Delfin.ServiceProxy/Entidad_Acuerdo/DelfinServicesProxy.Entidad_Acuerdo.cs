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
      public IBLEntidad_Acuerdo BL_Entidad_Acuerdo { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTEntidad_Acuerdo(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Entidad_Acuerdo.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Entidad_Acuerdo> GetAllEntidad_AcuerdoFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Entidad_Acuerdo.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Entidad_Acuerdo> GetAllEntidad_Acuerdo()
      {
         try
         {
            return BL_Entidad_Acuerdo.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public Entidad_Acuerdo GetOneEntidad_Acuerdo(Int32 ACUE_Codigo)
      {
         try
         {
            return BL_Entidad_Acuerdo.GetOne(ACUE_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveEntidad_Acuerdo(ref Entidad_Acuerdo Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Entidad_Acuerdo.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
