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
      #endregion

      #region [ Metodos ]

      public Boolean SaveLiquidacion(ref Liquidacion Item, Liquidacion.TOperacion x_toperacion)
      {
         try
         {
            return BL_Liquidacion.Save(ref Item, x_toperacion);
         }
         catch (Exception)
         { throw; }
      }

      #endregion
   }
}
