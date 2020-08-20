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
      public String UsuarioTipos
      {
         get { return BL_Tipos.UsuarioTipos; }
         set { BL_Tipos.UsuarioTipos = value; }
      }

      public ObservableCollection<Tipos> GetAllTiposByTipoCodTabla(String TIPO_CodTabla)
      {
         try
         {
            return BL_Tipos.GetAllByTipoCodTabla(TIPO_CodTabla);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Tipos> GetAllTiposFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Tipos.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
         
   }
}
