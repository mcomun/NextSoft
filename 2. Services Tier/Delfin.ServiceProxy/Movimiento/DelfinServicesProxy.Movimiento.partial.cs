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
		#region [ Consultas ]

      public Movimiento GetOneMovimiento(Int16 EMPR_Codigo, Int32 MOVI_Codigo, Entities.Movimiento.TInterfazMovimiento x_opcion)
      {
         try
         {
            return BL_Movimiento.GetOne(EMPR_Codigo, MOVI_Codigo, x_opcion);
         }
         catch (Exception)
         { throw; }
      }

		#endregion

		#region [ Metodos ]

      public Boolean SaveMovimiento(ref Movimiento Item, Entities.Movimiento.TInterfazMovimiento x_opcion)
      {
         try
         {
            return BL_Movimiento.Save(ref Item, x_opcion);
         }
         catch (Exception)
         { throw; }
      }

      public Boolean SaveMovimiento(ref ObservableCollection<Movimiento> Items, Movimiento.TInterfazMovimientos x_opcion)
      {
         try
         {
            return BL_Movimiento.Save(ref Items, x_opcion);
         }
         catch (Exception)
         { throw; }
      }

      public Boolean SaveMovimientoAnular(ref Movimiento Item)
      {
         try
         {
            return BL_Movimiento.SaveAnular(ref Item);
         }
         catch (Exception)
         { throw; }
      }

		#endregion
   }
}
