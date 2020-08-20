using System;
using System.Collections.Generic;
using System.Data;
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

      public Boolean SaveDocsVta(ref DocsVta Item, Entities.DocsVta.TInterfazDocsVta x_opcion)
      {
         try
         {
            return BL_DocsVta.Save(ref Item, x_opcion);
         }
         catch (Exception)
         { throw; }
      }

      public Boolean SaveDocsVtaFacturacion(DocsVta Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_DocsVta.SaveFacturacion(Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }
      public bool AnularDocsVtaFacturacion(DocsVta item, string TipDocVta)
      {
         try
         {
            return BL_DocsVta.AnularDocsVtaFacturacion(item, TipDocVta);
         }
         catch (Exception ex)
         { throw ex; }
      }
      public DataSet GetAllDocsVtaImpresionFactura(Int32 x_DOCV_Codigo)
      {
         try
         {
            return BL_DocsVta.GetAllImpresionFactura(x_DOCV_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }


      public DataSet GetDS(string x_procedure, List<object> filters )
      {
         try
         {
            return BL_DocsVta.GetDS(x_procedure, filters);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public DataSet GetDSDocsVta(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters, Boolean x_transaccion = false)
      {
         try
         {
            return BL_DocsVta.GetDS(x_procedure, x_filters, x_transaccion);
         }
         catch (Exception)
         { throw; }
      }

      public DataSet GetImpresionDSDocsVta(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters, String x_usuario, Int16 x_sucr_codigo, Boolean x_transaccion = false)
      {
          try
          {
              return BL_DocsVta.GetImpresionDS(x_procedure, x_filters, x_usuario, x_sucr_codigo, x_transaccion);
          }
          catch (Exception)
          { throw; }
      }

      public DataSet GetImpresionFEDSDocsVta(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters, String x_usuario, Int16 x_sucr_codigo, Boolean x_transaccion = false, String Email = "")
      {
          try
          {
              return BL_DocsVta.GetImpresionFEDS(x_procedure, x_filters, x_usuario, x_sucr_codigo, x_transaccion, Email);
          }
          catch (Exception)
          { throw; }
      }

      public ObservableCollection<DocsVta> GetAllDocsVtaFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_DocsVta.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }

      public DocsVta GetOneDocsVta(Int16 EMPR_Codigo, Int32 DOCV_Codigo)
      {
         try
         {
            return BL_DocsVta.GetOne(EMPR_Codigo, DOCV_Codigo);
         }
         catch (Exception)
         { throw; }
      }

   }
}
