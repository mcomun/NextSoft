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
       public ObservableCollection<Det_Tarifa_Servicio> GetAllDet_ServicioByTarifario(Int32 x_CTAR_Codigo, String x_CTAR_Tipo)
       {
           try
           {
               return BL_Det_Tarifa_Servicio.GetAllDet_ServicioByTarifario(x_CTAR_Codigo, x_CTAR_Tipo);
           }
           catch (Exception ex)
           { throw ex; }
       }
       public ObservableCollection<Det_Tarifa_Servicio> GetAllServiciosTarifaByCotizacion(Int32? x_CTAR_CodigoLogistico, Int32? x_CTAR_CodigoAduanero)
       {
           try
           {
               return BL_Det_Tarifa_Servicio.GetAllServiciosTarifaByCotizacion(x_CTAR_CodigoLogistico, x_CTAR_CodigoAduanero);
           }
           catch (Exception ex)
           { throw ex; }
       }
   }
}
