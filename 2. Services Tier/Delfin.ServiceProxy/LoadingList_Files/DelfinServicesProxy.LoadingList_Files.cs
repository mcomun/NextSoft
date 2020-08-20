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
      public IBLLoadingList_Files BL_LoadingList_Files { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTLoadingList_Files(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_LoadingList_Files.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<LoadingList_Files> GetAllLoadingList_FilesFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_LoadingList_Files.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<LoadingList_Files> GetAllLoadingList_Files()
      {
         try
         {
            return BL_LoadingList_Files.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public LoadingList_Files GetOneLoadingList_Files(Int32 LOAD_Codigo, Int32 FILE_Codigo)
      {
         try
         {
            return BL_LoadingList_Files.GetOne(LOAD_Codigo, FILE_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveLoadingList_Files(ref LoadingList_Files Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_LoadingList_Files.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
