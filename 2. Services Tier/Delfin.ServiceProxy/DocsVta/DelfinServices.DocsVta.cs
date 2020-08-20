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
      #region [ DocsVta ]
      [Dependency]
      public IBLDocsVta BL_DocsVta { get; set; }

      public Boolean SaveDocsVta(ref DocsVta Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_DocsVta.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Boolean ModificarCliente(Int32 x_DOCV_Codigo, Int32 x_ENTC_Codigo, String x_AUDI_UsrMod, Int16 x_TIPE_Codigo)
      {
         try
         {
            return BL_DocsVta.ModificarCliente(x_DOCV_Codigo, x_ENTC_Codigo, x_AUDI_UsrMod, x_TIPE_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public DocsVta GetOneDocsVta(Int32 DOCV_Codigo)
      {
         try
         {
            return BL_DocsVta.GetOne(DOCV_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }
      public ObservableCollection<DocsVta> GetAllDocsVtaPorFiltrosLView(String x_DOCV_Numero, DateTime x_DOCV_FechaEmisionIni, DateTime x_DOCV_FechaEmisionFin, Int32? x_ENTC_Codigo, String x_Estado)
      {
          try
          {
             return BL_DocsVta.GetAllPorFiltrosLView(x_DOCV_Numero, x_DOCV_FechaEmisionIni, x_DOCV_FechaEmisionFin, x_ENTC_Codigo, x_Estado);
          }
          catch (Exception ex)
          { throw ex; }
      }
      #endregion
   }
}
