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
      public ObservableCollection<NaveViaje> GetAllNaveViajeByViajeTransportista(String NVIA_NroViaje, Nullable<Int32> ENTC_CodTransportista, String CONS_TabVIA, String CONS_CodVIA, Nullable<DateTime> NVIA_FecETA)
      {
         try
         {
            return this.BL_NaveViaje.GetAllByViajeTransportista(NVIA_NroViaje, ENTC_CodTransportista, CONS_TabVIA, CONS_CodVIA, NVIA_FecETA);
         }
         catch (Exception)
         { throw; }
      }


      public ObservableCollection<NaveViaje> GetAllNaveViajeByFiltros(Boolean AcceptNulls, String NVIA_Estado, String CONS_TabRGM, String CONS_CodRGM, String CONS_TabVia, String CONS_CodVia, Nullable<Int32> ENTC_CodTransportista, Nullable<Int16> NAVE_Codigo, Nullable<DateTime> NVIA_FecCreacion, String NVIA_NroViaje)
      {
         try
         {
            return this.BL_NaveViaje.GetAllByFiltros(AcceptNulls, NVIA_Estado, CONS_TabRGM, CONS_CodRGM, CONS_TabVia, CONS_CodVia, ENTC_CodTransportista, NAVE_Codigo, NVIA_FecCreacion, NVIA_NroViaje);
         }
         catch (Exception)
         { throw; }
      }

      public System.Data.DataTable GetAllNaveViajeByFilters(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_NaveViaje.GetAllByFilters(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }

      public ObservableCollection<Cab_Cotizacion_OV> GetAllCab_OV_CabByNVIA_Codigo(Int32 NVIA_Codigo)//Int16 EMPR_Codigo, Int16 SUCR_Codigo,
      {
         try
         {
            return BL_NaveViaje.GetAllCab_OV_CabByNVIA_Codigo(NVIA_Codigo);//EMPR_Codigo, SUCR_Codigo,
         }
         catch (Exception ex)
         { throw ex; }
      }

      public System.Data.DataTable GetAllNaveViajeByReporte(String CONS_TabRGM, String CONS_CodRGM, Nullable<DateTime> NVIA_FecETAIni, Nullable<DateTime> NVIA_FecETAFin, Nullable<DateTime> NVIA_FecZarpeIni, Nullable<DateTime> NVIA_FecZarpeFin, Nullable<Int32> ENTC_CodTransportista, Nullable<Int16> NAVE_Codigo)
      {
         try
         {
            return BL_NaveViaje.ReportByFilters(CONS_TabRGM, CONS_CodRGM, NVIA_FecETAIni, NVIA_FecETAFin, NVIA_FecZarpeIni, NVIA_FecZarpeFin, ENTC_CodTransportista, NAVE_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      public System.Data.DataTable GetAllMBLsByNaveViaje(Nullable<Int32> NVIA_Codigo, Int32 TIPO_Direccionamiento, Nullable<Int32> CCOT_Codigo)
      {
         try
         {
            return BL_NaveViaje.MBLsByNaveViaje(NVIA_Codigo, TIPO_Direccionamiento, CCOT_Codigo);
         }
         catch (Exception)
         { throw; }
      }
      public System.Data.DataTable GetAllCargaTarjadaByNaveViaje(Nullable<Int32> NVIA_Codigo, String TIPO_Embarque, Nullable<Int32> CCOT_Codigo)
      {
         try
         {
            return BL_NaveViaje.CargaTarjadaByNaveViaje(NVIA_Codigo, TIPO_Embarque, CCOT_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      public System.Data.DataTable GetAllEmisionHBLByNaveViaje(Nullable<Int32> NVIA_Codigo, Nullable<Int32> CCOT_Numero)
      {
         try
         {
            return BL_NaveViaje.EmisionHBLByNaveViaje(NVIA_Codigo, CCOT_Numero);
         }
         catch (Exception)
         { throw; }
      }

      public System.Data.DataTable GetAllAvisosByNaveViaje(Nullable<Int32> NVIA_Codigo, Nullable<Int32> CCOT_Numero, String CCOT_NumDoc, Nullable<Int32> ENTC_CodCliente)
      {
         try
         {
            return BL_NaveViaje.AvisosByNaveViaje(NVIA_Codigo,CCOT_Numero,CCOT_NumDoc, ENTC_CodCliente);
         }
         catch (Exception)
         { throw; }
      }


      public System.Data.DataSet GetAllNaveViajeEmisionAduana(Int32 NVIA_Codigo, string Formato)
      {
         try
         {
            return BL_NaveViaje.GetEmisionAduana(NVIA_Codigo, Formato);
         }
         catch (Exception)
         { throw; }
      }
      public System.Data.DataSet GetAllNaveViajeEmisionAduanaTeledespacho(Int32 NVIA_Codigo)
      {
         try
         {
            return BL_NaveViaje.GetEmisionAduanaTeledespacho(NVIA_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      public bool SaveAprobarStatment(Int32 x_NVIA_Codigo, String x_AUDI_Usuario, ref String x_NVIA_MensajeError)
      {
         try
         {
            return BL_NaveViaje.SaveAprobarStatment(x_NVIA_Codigo, x_AUDI_Usuario, ref x_NVIA_MensajeError);
         }
         catch (Exception)
         { throw; }
      }

      public Boolean AbrirStatment_Update_NaveViaje_OV(Nullable<Int32> NVIA_Codigo,ref String x_Mensaje)
      {
         try
         {
            return BL_NaveViaje.AbrirStatment(NVIA_Codigo,ref x_Mensaje);
         }
         catch (Exception)
         { throw; }
      }

      public Boolean EmiteStatment_Update_User(Nullable<Int32> NVIA_Codigo, String NVIA_UsrEmiteStatment)
      {
          try
          {
              return BL_NaveViaje.EmiteStatment(NVIA_Codigo, NVIA_UsrEmiteStatment);
          }
          catch (Exception)
          {throw;}
      }

      public System.Data.DataTable GetAllNaveViajeByControlTransmisiones(String CONS_TabRGM, String CONS_CodRGM, Nullable<DateTime> NVIA_FecETA_ETDIni, Nullable<DateTime> NVIA_FecETA_ETDFin)
      {
          try
          {
              return BL_NaveViaje.GetAllByControlTransmisiones(CONS_TabRGM, CONS_CodRGM, NVIA_FecETA_ETDIni,NVIA_FecETA_ETDFin);
          }
          catch (Exception)
          { throw; }
      }

      public String CheckNaveViaje(NaveViaje Item)
      {
          try
          {
              return BL_NaveViaje.CheckAllNaveViaje(Item);
          }
          catch (Exception)
          { throw; }
      }

      public String OrdenesVentaByNVIA(Nullable<Int32> x_NVIA_Codigo)
      {
          try
          {
              return BL_NaveViaje.OVsByNVIA(x_NVIA_Codigo);
          }
          catch (Exception)
          { throw; }
      }

      public Boolean UpdateTransportistaOVsByNVIA(Nullable<Int32> x_NVIA_Codigo, Nullable<Int32> x_ENTC_CodTransportista)
      {
          try
          {
              return BL_NaveViaje.UpdateTransportistaOVs(x_NVIA_Codigo,x_ENTC_CodTransportista);
          }
          catch (Exception)
          { throw; }
      }

      public Boolean SaveNaveViaje(ref ObservableCollection<NaveViaje> Items, Entities.NaveViaje.TInterfazNaveViaje x_opcion)
      {
         try
         {
            return BL_NaveViaje.Save(ref Items, x_opcion);
         }
         catch (Exception)
         { throw; }
      }
   }
}