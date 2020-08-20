using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;
using System.Collections.ObjectModel;
using Microsoft.Practices.Unity;
using Infrastructure.Aspect.DataAccess;
using Delfin.ServiceContracts;
using Delfin.BusinessLogic;
using Delfin.Entities;

namespace Delfin.ServiceProxy
{

   public partial class DelfinServices : IDelfinServices
   {
      #region [ Propiedades ]
      [Dependency]
      public IBLEntidad_Servicio BL_Entidad_Servicio { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTEntidad_Servicio(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Entidad_Servicio.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Entidad_Servicio> GetAllEntidad_ServicioFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Entidad_Servicio.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Entidad_Servicio> GetAllEntidad_Servicio()
      {
         try
         {
            return BL_Entidad_Servicio.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public Entidad_Servicio GetOneEntidad_Servicio(Int32 ESER_Codigo)
      {
         try
         {
            return BL_Entidad_Servicio.GetOne(ESER_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveEntidad_Servicio(ref Entidad_Servicio Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Entidad_Servicio.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
