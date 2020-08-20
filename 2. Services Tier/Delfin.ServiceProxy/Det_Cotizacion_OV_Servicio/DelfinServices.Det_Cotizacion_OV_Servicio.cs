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
      #region [ Det_Cotizacion_OV_Servicio ]
      [Dependency]
      public IBLDet_Cotizacion_OV_Servicio BL_Det_Cotizacion_OV_Servicio { get; set; }

      public Boolean SaveDet_Cotizacion_OV_Servicio(ref Det_Cotizacion_OV_Servicio Item, Boolean Tran)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Det_Cotizacion_OV_Servicio.Save(ref Item, Tran);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Det_Cotizacion_OV_Servicio GetOneDet_Cotizacion_OV_Servicio(Int16 CCOT_Tipo, Int32 CCOT_Numero, Int32 SCOT_Item)
      {
         try
         {
            return BL_Det_Cotizacion_OV_Servicio.GetOne(CCOT_Tipo, CCOT_Numero, SCOT_Item);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Det_Cotizacion_OV_Servicio> GetAllDet_Cotizacion_OV_Servicio()
      {
         try
         {
            return BL_Det_Cotizacion_OV_Servicio.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
