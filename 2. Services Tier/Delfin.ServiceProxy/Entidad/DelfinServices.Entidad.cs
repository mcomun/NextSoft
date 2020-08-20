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
      #region [ Entidad ]
      [Dependency]
      public IBLEntidad BL_Entidad { get; set; }

      public Entidad SaveEntidad(Entidad Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
                return BL_Entidad.Save(ref Item);
            }
            return null ;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public Entidad GetOneEntidad(Int32 ENTC_Codigo, Nullable<Int16> x_TIPE_Codigo = null, Boolean x_soloentidad = false)
      {
         try
         {
            return BL_Entidad.GetOne(ENTC_Codigo, x_TIPE_Codigo, x_soloentidad);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<Entidad> GetAllEntidad(Nullable<Int16> x_TIPE_Codigo = null, string x_ENTC_NomCompleto = null)
      {
         try
         {
            return BL_Entidad.GetAll(x_TIPE_Codigo ,  x_ENTC_NomCompleto );
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
