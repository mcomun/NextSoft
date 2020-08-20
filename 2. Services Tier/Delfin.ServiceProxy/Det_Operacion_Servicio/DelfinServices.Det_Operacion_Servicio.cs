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
      #region [ Det_Operacion_Servicio ]
      [Dependency]
      public IBLDet_Operacion_Servicio BL_Det_Operacion_Servicio { get; set; }

      public Boolean SaveDet_Operacion_Servicio(Det_Operacion_Servicio Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Det_Operacion_Servicio.Save(Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Det_Operacion_Servicio GetOneDet_Operacion_Servicio(Int32 SOPE_Item, Int32 COPE_Codigo)
      {
         try
         {
            return BL_Det_Operacion_Servicio.GetOne(SOPE_Item, COPE_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }
      public ObservableCollection<Det_Operacion_Servicio> GetAllDet_Operacion_ServicioByOperacion(Int32 x_COPE_Codigo)
      {
          try
          {
              return BL_Det_Operacion_Servicio.GetAllByOperacion(x_COPE_Codigo);
          }
          catch (Exception ex)
          { throw ex; }
      }
      #endregion
   }
}
