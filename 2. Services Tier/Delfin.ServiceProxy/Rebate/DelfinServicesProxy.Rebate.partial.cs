using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.ObjectModel;

namespace Delfin.ServiceProxy
{
   using Delfin.Entities;

   public partial class DelfinServicesProxy : ClientBase<ServiceContracts.IDelfinServices>, ServiceContracts.IDelfinServices
   {
   }
}
