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
      public ObservableCollection<Contrato> GetAllContratoByTransportista(Int32 ENTC_CodTransportista, DateTime REBA_FecIni, DateTime REBA_FecFin)
      {
         try
         {
            return BL_GRR.GetAllContratoByTransportista(ENTC_CodTransportista, REBA_FecIni, REBA_FecFin);
         }
         catch (Exception)
         { throw; }
      }
		#endregion

		#region [ Metodos ]
		#endregion
   }
}
