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

      public Boolean SavePlanillasLevantarRespuesta(Infrastructure.Aspect.Constants.CCabeceraRDetracciones RDetraccion, ref String x_resultado)
      {
         try
         {
            return BL_Planillas.SaveLevantarRespuesta(RDetraccion, ref x_resultado);
         }
         catch (Exception)
         { throw; }
      }

		#endregion
   }
}
