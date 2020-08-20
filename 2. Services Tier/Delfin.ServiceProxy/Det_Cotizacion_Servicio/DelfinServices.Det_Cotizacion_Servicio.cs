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
      #region [ Det_Cotizacion_Servicio ]
      [Dependency]
      public IBLDet_Cotizacion_Servicio BL_Det_Cotizacion_Servicio { get; set; }

      public Boolean SaveDet_Cotizacion_Servicio(ref Det_Cotizacion_Servicio Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Det_Cotizacion_Servicio.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Det_Cotizacion_Servicio GetOneDet_Cotizacion_Servicio(Int32 CCOT_Codigo, Int32 SCOT_Item)
      {
         try
         {
            return BL_Det_Cotizacion_Servicio.GetOne(CCOT_Codigo, SCOT_Item);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Det_Cotizacion_Servicio> GetAllDet_Cotizacion_ServicioByCotizacion(Int32 x_CCOT_Codigo, String x_SCOT_Tipo)
      {
         try
         {
            return BL_Det_Cotizacion_Servicio.GetAllByCotizacion(x_CCOT_Codigo, x_SCOT_Tipo);
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
