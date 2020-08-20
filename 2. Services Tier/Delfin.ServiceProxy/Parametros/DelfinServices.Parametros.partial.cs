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
      public String UsuarioParametros
      {
         get { return BL_Parametros.UsuarioParametros; }
         set { BL_Parametros.UsuarioParametros = value; }
      }

      public Parametros GetOneParametrosByClave(String PARA_Clave)
      {
         try
         {
            return BL_Parametros.GetOneByClave(PARA_Clave);
         }
         catch (Exception)
         { throw; }
      }

      public ObservableCollection<Parametros> GetAllParametrosByClave(String PARA_Clave)
      {
          try 
          {
              return BL_Parametros.GetAllByClave(PARA_Clave);
          }
          catch (Exception)
          { throw; }
      }
   }
}
