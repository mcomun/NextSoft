using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;
using System.Collections.ObjectModel;
using Microsoft.Practices.Unity;
using Infrastructure.Aspect.DataAccess;
using Delfin.ServiceContracts;
using Delfin.BusinessLogic;
using Delfin.Entities;

namespace Delfin.ServiceProxy
{

   public partial class DelfinServices : IDelfinServices
   {
      #region [ Propiedades ]
      [Dependency]
      public IBLDet_Operacion_Servicio BL_Det_Operacion_Servicio { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTDet_Operacion_Servicio(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Det_Operacion_Servicio.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Det_Operacion_Servicio> GetAllDet_Operacion_ServicioFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Det_Operacion_Servicio.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Det_Operacion_Servicio> GetAllDet_Operacion_Servicio()
      {
         try
         {
            return BL_Det_Operacion_Servicio.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public Det_Operacion_Servicio GetOneDet_Operacion_Servicio(Int32 SOPE_Item, Int32 COPE_Codigo)
      {
         try
         {
            return BL_Det_Operacion_Servicio.GetOne(SOPE_Item, COPE_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveDet_Operacion_Servicio(ref Det_Operacion_Servicio Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Det_Operacion_Servicio.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
