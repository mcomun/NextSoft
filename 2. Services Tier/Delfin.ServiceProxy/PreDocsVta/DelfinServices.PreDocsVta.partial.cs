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
      public DataTable GetAllServiciosPreFactura(Int32 x_COPE_Codigo, String x_TIPO_CodMND, Decimal x_TIPO_Cambio)
       {
           try
           {
              return BL_PreDocsVta.GetAllServiciosPreFactura(x_COPE_Codigo, x_TIPO_CodMND, x_TIPO_Cambio);
           }
           catch (Exception ex)
           { throw ex; }
       }
       public DataTable GetOneCORR_SerieFactura(String x_CORR_ServerName, String x_CORR_CodCorr)
       {
           try
           {
               return BL_PreDocsVta.GetOneSerieFactura(x_CORR_ServerName, x_CORR_CodCorr);
           }
           catch (Exception ex)
           { throw ex; }
       }
       public Boolean SaveAnulacionPreFacturaPreDocsVta(PreDocsVta Item, String TipoPrefactura)
       {
           try
           {
               if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
               {
                   return BL_PreDocsVta.SaveAnulacion( Item,TipoPrefactura);
               }
               return true;
           }
           catch (Exception ex)
           { throw ex; }
       }

   }
}
