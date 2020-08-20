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
      public Boolean SaveDet_Cotizacion_OV_ServicioDocumento(Det_Cotizacion_OV_Servicio Item)
      {
         try
         {
            return BL_Det_Cotizacion_OV_Servicio.SaveDocumento(ref Item);
         }
         catch (Exception)
         { throw; }
      }
   }
}
