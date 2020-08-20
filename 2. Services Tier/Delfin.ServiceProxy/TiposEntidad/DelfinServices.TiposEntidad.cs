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
      #region [ TiposEntidad ]
      [Dependency]
      public IBLTiposEntidad BL_TiposEntidad { get; set; }

      public Boolean SaveTiposEntidad(TiposEntidad Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_TiposEntidad.Save(ref Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public TiposEntidad GetOneTiposEntidad(Int16 TIPE_Codigo)
      {
         try
         {
            return BL_TiposEntidad.GetOne(TIPE_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<TiposEntidad> GetAllTiposEntidad()
      {
         try
         {
            return BL_TiposEntidad.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<TiposEntidad> GetAllTiposEntidad_Relacionados()
      {
          try
          {
              return BL_TiposEntidad.GetAllTIPE_Relacionados();
          }
          catch (Exception ex)
          { throw ex; }
      }
      #endregion
   }
}
