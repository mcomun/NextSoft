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
      public ObservableCollection<TiposEntidad> GetTodosTiposEntidad()
      {
         try
         {
            return BL_TiposEntidad.GetTodos();
         }
         catch (Exception)
         { throw; }
      }
   }
}
