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
      public System.Data.DataTable GetGestionVentasKPIContactados(Int16 EMPR_Codigo, Int16 SUCR_Codigo, DateTime GEST_FechaDesde, DateTime GEST_FechaHasta, Boolean PorEjecutivo, Nullable<Int32> ENTC_CodEjecutivo)
      {
         try
         {
            return this.BL_GestionVentas.GetKPIContactados(EMPR_Codigo, SUCR_Codigo, GEST_FechaDesde, GEST_FechaHasta, PorEjecutivo, ENTC_CodEjecutivo);
         }
         catch (Exception)
         { throw; }
      }
      public System.Data.DataTable GetGestionVentasKPIReuniones(Int16 EMPR_Codigo, Int16 SUCR_Codigo, DateTime GEST_FechaDesde, DateTime GEST_FechaHasta, Boolean PorEjecutivo, Nullable<Int32> ENTC_CodEjecutivo)
      {
         try
         {
            return this.BL_GestionVentas.GetKPIReuniones(EMPR_Codigo, SUCR_Codigo, GEST_FechaDesde, GEST_FechaHasta, PorEjecutivo, ENTC_CodEjecutivo);
         }
         catch (Exception)
         { throw; }
      }
   }
}
