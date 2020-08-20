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
      public String UsuarioPuertos
      {
         get { return BL_Puerto.UsuarioPuertos; }
         set { BL_Puerto.UsuarioPuertos = value; }
      }

      public ObservableCollection<Puerto> GetAllPuertoByVia(String CONS_TabVia, String CONS_CodVia)
      {
         try
         {
            return BL_Puerto.GetAllByVia(CONS_TabVia, CONS_CodVia);
         }
         catch (Exception)
         { throw; }
      }

      public Puerto GetOnePuertoByCodEstandar(String CONS_TabVia, String CONS_CodVia, String PUER_CodEstandar)
      {
         try
         {
            return BL_Puerto.GetOneByCodEstandar(CONS_TabVia, CONS_CodVia, PUER_CodEstandar);
         }
         catch (Exception)
         { throw; }
      }

      public ObservableCollection<Puerto> GetAllPuertoByAyuda(String CONS_TabVia, String CONS_CodVia, String TIPO_TabPais, String TIPO_CodPais, String PUER_CodEstandar, String PUER_Nombre)
      {
         try
         {
            return BL_Puerto.GetAllByAyuda(CONS_TabVia, CONS_CodVia, TIPO_TabPais, TIPO_CodPais, PUER_CodEstandar, PUER_Nombre);
         }
         catch (Exception)
         { throw; }
      }
   }
}
