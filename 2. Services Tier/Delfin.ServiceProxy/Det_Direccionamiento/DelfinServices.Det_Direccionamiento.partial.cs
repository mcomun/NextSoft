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
      public System.Data.DataTable GetDetalleForward(Int32 _Operacion)
      {
         try
         {
            return BL_Det_Direccionamiento.GetDetalleForward(_Operacion);
         }
         catch (Exception ex)
         { throw ex; }
      }
   }   
}
