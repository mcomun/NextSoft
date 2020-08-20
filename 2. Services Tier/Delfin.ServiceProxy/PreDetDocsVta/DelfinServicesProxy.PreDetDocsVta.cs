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
      public IBLPreDetDocsVta BL_PreDetDocsVta { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTPreDetDocsVta(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_PreDetDocsVta.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<PreDetDocsVta> GetAllPreDetDocsVtaFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_PreDetDocsVta.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<PreDetDocsVta> GetAllPreDetDocsVta()
      {
         try
         {
            return BL_PreDetDocsVta.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public PreDetDocsVta GetOnePreDetDocsVta(Int16 PDDO_Item, Int32 DOCV_Codigo)
      {
         try
         {
            return BL_PreDetDocsVta.GetOne(PDDO_Item, DOCV_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SavePreDetDocsVta(ref PreDetDocsVta Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_PreDetDocsVta.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
