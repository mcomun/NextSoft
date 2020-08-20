using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;
using System.Collections.ObjectModel;
using Microsoft.Practices.Unity;
using Infrastructure.Aspect.DataAccess;

namespace Delfin.ServiceProxy
{
   using Delfin.ServiceContracts;
   using Delfin.BusinessLogic;
   using Delfin.Entities;

   public partial class DelfinServicesProxy : IDelfinServices
   {
      #region [ PreDocsVta ]
      [Dependency]
      public IBLPreDocsVta BL_PreDocsVta { get; set; }

      public Boolean SavePreDocsVta(ref PreDocsVta Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_PreDocsVta.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public PreDocsVta GetOnePreDocsVta(Int32 PDOC_Codigo)
      {
         try
         {
            return BL_PreDocsVta.GetOne(PDOC_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<PreDocsVta> GetAllPorFiltrosLViewPreDocsVta(String x_DOCV_Numero, DateTime x_DOCV_FechaEmisionIni, DateTime x_DOCV_FechaEmisionFin, Int32? x_ENTC_Codigo, String x_Estado)
      {
         try
         {
            return BL_PreDocsVta.GetAllPorFiltrosLView(x_DOCV_Numero, x_DOCV_FechaEmisionIni, x_DOCV_FechaEmisionFin, x_ENTC_Codigo, x_Estado);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<PreDocsVta> GetAllPreDocsVtaFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_PreDocsVta.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }

      #endregion
   }
}
