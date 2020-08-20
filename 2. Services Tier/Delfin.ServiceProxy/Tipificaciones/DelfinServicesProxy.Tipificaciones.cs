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
      public IBLTipificaciones BL_Tipificaciones { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTTipificaciones(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Tipificaciones.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Tipificaciones> GetAllTipificacionesFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Tipificaciones.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Tipificaciones> GetAllTipificaciones()
      {
         try
         {
            return BL_Tipificaciones.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public Tipificaciones GetOneTipificaciones(Int16 EMPR_Codigo, Int32 MOVI_Codigo, Int16 TIPD_Item)
      {
         try
         {
            return BL_Tipificaciones.GetOne(EMPR_Codigo, MOVI_Codigo, TIPD_Item);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveTipificaciones(ref Tipificaciones Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Tipificaciones.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
