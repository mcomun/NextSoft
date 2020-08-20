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
      #region [ PreDetDocsVta_Det_Operacion ]
      [Dependency]
      public IBLPreDetDocsVta_Det_Operacion BL_PreDetDocsVta_Det_Operacion { get; set; }

      public Boolean SavePreDetDocsVta_Det_Operacion(PreDetDocsVta_Det_Operacion Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_PreDetDocsVta_Det_Operacion.Save(Item);
            }
            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      public PreDetDocsVta_Det_Operacion GetOnePreDetDocsVta_Det_Operacion(Int32 PDDO_Codigo)
      {
         try
         {
            return BL_PreDetDocsVta_Det_Operacion.GetOne(PDDO_Codigo);
         }
         catch (Exception ex)
         { throw ex; }
      }

      public ObservableCollection<PreDetDocsVta_Det_Operacion> GetAllPreDetDocsVta_Det_Operacion()
      {
         try
         {
            return BL_PreDetDocsVta_Det_Operacion.GetAll();
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}
