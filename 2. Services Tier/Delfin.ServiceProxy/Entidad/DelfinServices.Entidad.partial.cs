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

      [Dependency]
      public IBLEntidad_Relacionados BL_EntidadRelacionados { get; set; }

      //public ObservableCollection<Entidad> GetAllEntidadByNomCompleto(String ENTC_NomCompleto)
      //{
      //   try
      //   {
      //      return BL_Entidad.GetAllByNomCompleto(ENTC_NomCompleto);
      //   }
      //   catch (Exception) 
      //   { throw; }
      //}
      public Entidad GetOneEntidadValidarDocIden(Int32 ENTC_Codigo, String TIPO_TabTDI, String TIPO_CodTDI, String ENTC_DocIden)
      {
         try
         {
            return BL_Entidad.GetOneValidarDocIden(ENTC_Codigo, TIPO_TabTDI, TIPO_CodTDI, ENTC_DocIden);
         }
         catch (Exception)
         { throw; }
      }
      
      public DataTable GetTodosEntidadByTIPE_Codigo(Nullable<Int16> x_TIPE_Codigo)
      {
         try
         {
            return BL_Entidad.GetTodosEntidadByTIPE_Codigo(x_TIPE_Codigo);
         }
         catch (Exception)
         { throw; }
      }
      
      public Entidad GetEntidadOnePorRuc(String x_ENTC_DocIden, Nullable<Int16> x_TIPE_Codigo)
      {
         try
         {
            return BL_Entidad.GetEntidadOnePorRuc(x_ENTC_DocIden, x_TIPE_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }
      
      public ObservableCollection<Entidad> GetAllEntidadByTipoEntidadAndText(Int16 TIPE_CODIGO, string Text, Boolean Activo, String ENTC_DOCIDEN)
      {
         try
         {
            return BL_Entidad.GetAllByTipoEntidadAndText(TIPE_CODIGO, Text, Activo, ENTC_DOCIDEN);
         }
         catch (Exception)
         { throw; }
      }

      public ObservableCollection<Entidad> GetAllEntidadByNVIA_Codigo(Int32 NVIA_codigo, Int32 TIPO_correo)
      {
         try
         {
            return BL_Entidad.GetAllEntidadByNVIA_Codigo(NVIA_codigo, TIPO_correo);
         }
         catch (Exception)
         { throw; }
      }

      public ObservableCollection<Entidad> GetAllEntidadFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Entidad.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }

      public Boolean GetOneEntidadLimiteCredito(Int16 EMPR_Codigo, Int32 ENTC_Codigo, ref Decimal Monto, ref Int16 DiasDuracion)
      {
         try
         {
            return BL_Entidad.GetLimiteCredito(EMPR_Codigo, ENTC_Codigo, ref Monto, ref DiasDuracion);
         }
         catch (Exception)
         { throw; }
      }
   }
}
