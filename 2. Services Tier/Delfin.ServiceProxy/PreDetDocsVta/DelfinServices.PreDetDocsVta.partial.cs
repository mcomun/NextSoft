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
       public DataTable GetAllServiciosPorDOCV_CodigoPreFactura(Int32 x_DOCV_Codigo)
       {
           try
           {
               return BL_PreDetDocsVta.GetAllServiciosPorDOCV_CodigoPreFactura(x_DOCV_Codigo);
           }
           catch (Exception ex)
           { throw ex; }
       }
   }
}
