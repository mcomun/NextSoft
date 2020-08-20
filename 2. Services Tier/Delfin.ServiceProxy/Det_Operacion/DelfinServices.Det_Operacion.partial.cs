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
      public DataTable GetAyudaOperacionXProveedor(Int32 x_COPE_Codigo, String x_Moneda, Decimal x_TipoCambio, Int32 x_CCCT_Codigo)
      {
         try
         {
            return BL_Det_Operacion.GetAyudaOperacionXProveedor(x_COPE_Codigo, x_Moneda, x_TipoCambio, x_CCCT_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Det_Operacion> GetAllDetOperacvionByDOCV_Codigo(Int32 x_DOCV_Codigo)
      {
          try
          {
              return BL_Det_Operacion.GetAllByDOCV_Codigo(x_DOCV_Codigo);
          }
          catch (Exception ex)
          { throw ex; }
      }
      public DataTable GetServicioByOperacion(Int32 x_COPE_Codigo)
      {
          try { return BL_Det_Operacion.GetServicioByOperacion(x_COPE_Codigo); }
          catch (Exception ex)
          { throw ex; }
      }
      public DataTable GetServicioFacturado(Int32 x_COPE_Codigo, Int32 x_DOPE_Item)
      {
          try { return BL_Det_Operacion.GetVerificaServicioFacturado(x_COPE_Codigo, x_DOPE_Item); }
          catch (Exception ex)
          { throw ex; }
      }

   }
}
