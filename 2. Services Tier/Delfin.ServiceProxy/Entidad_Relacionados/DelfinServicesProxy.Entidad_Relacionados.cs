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

   public partial class DelfinServicesProxy : IDelfinServices
   {
      #region [ Propiedades ]
      [Dependency]
      public IBLEntidad_Relacionados BL_Entidad_Relacionados { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTEntidad_Relacionados(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Entidad_Relacionados.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Entidad_Relacionados> GetAllEntidad_RelacionadosFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Entidad_Relacionados.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Entidad_Relacionados> GetAllEntidad_Relacionados()
      {
         try
         {
            return BL_Entidad_Relacionados.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public Entidad_Relacionados GetOneEntidad_Relacionados(Int32 RELA_Codigo)
      {
         try
         {
            return BL_Entidad_Relacionados.GetOne(RELA_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveEntidad_Relacionados(ref Entidad_Relacionados Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Entidad_Relacionados.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
