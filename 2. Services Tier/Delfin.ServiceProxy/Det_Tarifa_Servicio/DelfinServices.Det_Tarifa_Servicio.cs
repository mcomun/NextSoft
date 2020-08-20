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
      #region [ Det_Tarifa_Servicio ]
      [Dependency]
      public IBLDet_Tarifa_Servicio BL_Det_Tarifa_Servicio { get; set; }

      public Boolean SaveDet_Tarifa_Servicio( ref Det_Tarifa_Servicio Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Det_Tarifa_Servicio.Save( ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Det_Tarifa_Servicio GetOneDet_Tarifa_Servicio(Int32 CTAR_Codigo, String CTAR_Tipo, Int32 DTAS_Item)
      {
         try
         {
            return BL_Det_Tarifa_Servicio.GetOne(CTAR_Codigo, CTAR_Tipo, DTAS_Item);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Det_Tarifa_Servicio> GetAllDet_Tarifa_Servicio()
      {
         try
         {
            return BL_Det_Tarifa_Servicio.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
