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

   public partial class DelfinServicesProxy : IDelfinServices
   {
      #region [ Propiedades ]
      [Dependency]
      public IBLMovimientoFlujo BL_MovimientoFlujo { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTMovimientoFlujo(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_MovimientoFlujo.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<MovimientoFlujo> GetAllMovimientoFlujoFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_MovimientoFlujo.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<MovimientoFlujo> GetAllMovimientoFlujo()
      {
         try
         {
            return BL_MovimientoFlujo.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public MovimientoFlujo GetOneMovimientoFlujo(Int16 EMPR_Codigo, Int32 MOVI_Codigo, Int16 MFLU_Item)
      {
         try
         {
            return BL_MovimientoFlujo.GetOne(EMPR_Codigo, MOVI_Codigo, MFLU_Item);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveMovimientoFlujo(ref MovimientoFlujo Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_MovimientoFlujo.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
