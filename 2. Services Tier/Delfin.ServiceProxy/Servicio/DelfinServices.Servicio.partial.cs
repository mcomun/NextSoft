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
      [Dependency]
      public IBLServiciosDocumentos BL_ServicioDocumento { get; set; }

      public ObservableCollection<Servicio> GetAllServicioByViaRegimen(String CONS_TabVia, String CONS_CodVia, String CONS_TabRGM, String CONS_CodRGM, String CONS_TabLNG, String CONS_CodLNG)
      {
         try
         {
            return BL_Servicio.GetAllByViaRegimen(CONS_TabVia, CONS_CodVia, CONS_TabRGM, CONS_CodRGM, CONS_TabLNG, CONS_CodLNG);
         }
         catch (Exception)
         { throw; }
      }

      public ObservableCollection<Servicio> GetAllServicioByFiltros(Boolean AcceptNulls, String CONS_TabVia, String CONS_CodVia, String CONS_TabRGM, String CONS_CodRGM, String CONS_TabLNG, String CONS_CodLNG, String SERV_TipoMov, Boolean SERV_AfeIgv, Boolean SERV_AfeDet)
      {
         try
         {
            return BL_Servicio.GetAllByFiltros(AcceptNulls, CONS_TabVia, CONS_CodVia, CONS_TabRGM, CONS_CodRGM, CONS_TabLNG, CONS_CodLNG, SERV_TipoMov, SERV_AfeIgv, SERV_AfeDet);
         }
         catch (Exception)
         { throw; }
      }

      public ObservableCollection<Servicio> GetAllServiciosFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Servicio.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }

      public ObservableCollection<ServiciosDocumentos> GetAllServiciosDocumentosByServCodigo(Int32 SERV_codigo)
      {
         try
         {
            return BL_ServicioDocumento.GetAllServiciosDocumentosByServCodigo(SERV_codigo);
         }
         catch (Exception)
         { throw; }
      }

      //public ObservableCollection<Servicio> GetAllServicioByCachetes(String Nombre)
      //{
      //   try
      //   {
      //      return BL_Servicio.GetAllByCachetes(Nombre);
      //   }
      //   catch (Exception)
      //   { throw; }
      //}

      public System.Data.DataTable GetAllServiciosDTByFilters(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Servicio.GetAllDTByFilters(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public string CheckServicio(Servicio x_Item)
      {
          try
          {
              return BL_Servicio.VerificaServicio(x_Item);
          }
          catch (Exception)
          {throw;}
      }

   }
}