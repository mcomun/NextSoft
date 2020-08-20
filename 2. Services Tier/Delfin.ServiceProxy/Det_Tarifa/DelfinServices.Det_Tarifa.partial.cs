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
       public ObservableCollection<Det_Tarifa> GetAllDet_TarifaByTarifario(Int32 x_CTAR_Codigo, String x_CTAR_Tipo)
       {
           try
           {
               return BL_Det_Tarifa.GetAllDet_TarifaByTarifario(x_CTAR_Codigo, x_CTAR_Tipo);
           }
           catch (Exception ex)
           { throw ex; }
       }
       public ObservableCollection<Det_Tarifa> GetAllTarifasByCotizacion(Int32? x_CTAR_CodigoLogistico, Int32? x_CTAR_CodigoAduanero, Int32? x_CTAR_CodigoTransporte, Boolean x_Filtros)
       {
           try
           {
               return BL_Det_Tarifa.GetAllTarifasByCotizacion(x_CTAR_CodigoLogistico, x_CTAR_CodigoAduanero, x_CTAR_CodigoTransporte,x_Filtros);
           }
           catch (Exception ex)
           { throw ex; }
       }
   }
}
