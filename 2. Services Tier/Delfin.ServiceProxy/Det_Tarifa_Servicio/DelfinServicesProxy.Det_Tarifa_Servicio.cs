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
      public IBLDet_Tarifa_Servicio BL_Det_Tarifa_Servicio { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTDet_Tarifa_Servicio(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Det_Tarifa_Servicio.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Det_Tarifa_Servicio> GetAllDet_Tarifa_ServicioFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Det_Tarifa_Servicio.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Det_Tarifa_Servicio> GetAllDet_Tarifa_Servicio()
      {
         try
         {
            return BL_Det_Tarifa_Servicio.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public Det_Tarifa_Servicio GetOneDet_Tarifa_Servicio(Int32 CTAR_Codigo, String CTAR_Tipo, Int32 DTAS_Item)
      {
         try
         {
            return BL_Det_Tarifa_Servicio.GetOne(CTAR_Codigo, CTAR_Tipo, DTAS_Item);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveDet_Tarifa_Servicio(ref Det_Tarifa_Servicio Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Det_Tarifa_Servicio.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
