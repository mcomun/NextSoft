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
      public IBLLoadingListDetalle BL_LoadingListDetalle { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTLoadingListDetalle(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_LoadingListDetalle.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<LoadingListDetalle> GetAllLoadingListDetalleFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_LoadingListDetalle.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<LoadingListDetalle> GetAllLoadingListDetalle()
      {
         try
         {
            return BL_LoadingListDetalle.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public LoadingListDetalle GetOneLoadingListDetalle(Int32 LOAD_Codigo, Int16 LODE_Item)
      {
         try
         {
            return BL_LoadingListDetalle.GetOne(LOAD_Codigo, LODE_Item);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveLoadingListDetalle(ref LoadingListDetalle Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_LoadingListDetalle.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
