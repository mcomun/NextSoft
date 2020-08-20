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
      public DataTable GetAllDet_TarjasServiciosFacturacion(Int32 x_DOCV_Codigo, String x_TIPO_CodMND, Decimal x_TipoCambio)
       {
           try
           {
              return BL_Det_Tarjas.GetAllServiciosDetTarjas(x_DOCV_Codigo, x_TIPO_CodMND, x_TipoCambio);
           }
           catch (Exception ex)
           { throw ex; }
       }
   }
}
