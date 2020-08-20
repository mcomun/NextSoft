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
   using System.Data;

   public partial class DelfinServicesProxy : IDelfinServices
   {
      public ObservableCollection<Prospecto> GetAllProspectosValidos(DataTable Items, Int16 EMPR_Codigo, Int16 SUCR_Codigo, DateTime PROS_FecAsignacion)
      {
         try
         {
            return this.BL_Prospecto.GetAllValidos(Items, EMPR_Codigo, SUCR_Codigo, PROS_FecAsignacion);
         }
         catch (Exception)
         { throw; }
      }

      public ObservableCollection<Prospecto> GetAllProspectosByEjecutivo(Int16 EMPR_Codigo, Int16 SUCR_Codigo, Int32 ENTC_CodEjecutivo, Nullable<Int32> ENTC_CodAgenteCarga, Nullable<DateTime> PROS_FecAsignacion, Nullable<DateTime> PROS_FecAsignacionInicio, Nullable<DateTime> PROS_FecAsignacionFinal)
      {
         try
         {
            return this.BL_Prospecto.GetAllByEjecutivo(EMPR_Codigo, SUCR_Codigo, ENTC_CodEjecutivo, ENTC_CodAgenteCarga, PROS_FecAsignacion, PROS_FecAsignacionInicio, PROS_FecAsignacionFinal);
         }
         catch (Exception)
         { throw; }
      }

      public ObservableCollection<Prospecto> GetAllProspectosByEjecutivoGestionVentas(Int16 EMPR_Codigo, Int16 SUCR_Codigo, Int32 ENTC_CodEjecutivo, Nullable<Int32> ENTC_CodAgenteCarga, Nullable<DateTime> GEST_FechaProximaGestion)
      {
         try
         {
            return this.BL_Prospecto.GetAllByEjecutivoGestionVentas(EMPR_Codigo, SUCR_Codigo, ENTC_CodEjecutivo, ENTC_CodAgenteCarga, GEST_FechaProximaGestion);
         }
         catch (Exception)
         { throw; }
      }

      public Boolean AsignarProspectos(DataTable Items, Int16 EMPR_Codigo, Int16 SUCR_Codigo, DateTime PROS_FecAsignacion, String AUDI_Usuario)
      {
         try
         {
            return this.BL_Prospecto.Asignar(Items, EMPR_Codigo, SUCR_Codigo, PROS_FecAsignacion, AUDI_Usuario);
         }
         catch (Exception)
         { throw; }
      }

      public Boolean ReAsignarProspectos(DataTable Items, Int16 EMPR_Codigo, Int16 SUCR_Codigo, DateTime PROS_FecAsignacion, String AUDI_Usuario)
      {
         try
         {
            return this.BL_Prospecto.ReAsignar(Items, EMPR_Codigo, SUCR_Codigo, PROS_FecAsignacion, AUDI_Usuario);
         }
         catch (Exception)
         { throw; }
      }
   }
}
