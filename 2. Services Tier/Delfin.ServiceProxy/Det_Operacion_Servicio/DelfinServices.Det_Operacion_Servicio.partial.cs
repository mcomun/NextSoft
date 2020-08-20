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
       public DataSet GetAllServiciosAdicionalesReporte(Int32? x_ENTC_Codigo, DateTime x_COPE_FecEmiIni, DateTime x_COPE_FecEmiFin, String x_TipoReporteAdicional)
       {
           try
           {
               return  BL_Det_Operacion_Servicio.GetAllServiciosAdicionalesReporte(x_ENTC_Codigo, x_COPE_FecEmiIni, x_COPE_FecEmiFin, x_TipoReporteAdicional);
           }
           catch (Exception ex)
           { throw ex; }
       }
   }
}
