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
      public System.Data.DataTable GetAllTarifaByContrato(Nullable<Int32> CONT_Codigo, String CONS_TabRGM, String CONS_CodRGM, String CONS_TabVIA, String CONS_CodVIA, String TIPO_TabMND, String TIPO_CodMND, Nullable<Int32> PACK_Codigo, String TIPO_TabPAI, String TIPO_CodPAI, Nullable<Int32> PUER_Codigo)
      {
         try
         {
            return this.BL_Tarifa.GetAllByContratoGrilla(CONT_Codigo, CONS_TabRGM, CONS_CodRGM, CONS_TabVIA, CONS_CodVIA, TIPO_TabMND, TIPO_CodMND, PACK_Codigo, TIPO_TabPAI, TIPO_CodPAI, PUER_Codigo);
         }
         catch (Exception)
         { throw; }
      }
   }
}
