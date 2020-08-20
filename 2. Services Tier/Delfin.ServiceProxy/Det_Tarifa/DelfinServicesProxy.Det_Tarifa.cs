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
      public IBLDet_Tarifa BL_Det_Tarifa { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTDet_Tarifa(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Det_Tarifa.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Det_Tarifa> GetAllDet_TarifaFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Det_Tarifa.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Det_Tarifa> GetAllDet_Tarifa()
      {
         try
         {
            return BL_Det_Tarifa.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public Det_Tarifa GetOneDet_Tarifa(Int32 CTAR_Codigo, String CTAR_Tipo, Int16 DTAR_Item)
      {
         try
         {
            return BL_Det_Tarifa.GetOne(CTAR_Codigo, CTAR_Tipo, DTAR_Item);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveDet_Tarifa(ref Det_Tarifa Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Det_Tarifa.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
