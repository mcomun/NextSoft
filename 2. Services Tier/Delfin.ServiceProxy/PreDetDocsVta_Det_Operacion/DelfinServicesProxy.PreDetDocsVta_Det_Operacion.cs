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
      public IBLPreDetDocsVta_Det_Operacion BL_PreDetDocsVta_Det_Operacion { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTPreDetDocsVta_Det_Operacion(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_PreDetDocsVta_Det_Operacion.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<PreDetDocsVta_Det_Operacion> GetAllPreDetDocsVta_Det_OperacionFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_PreDetDocsVta_Det_Operacion.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<PreDetDocsVta_Det_Operacion> GetAllPreDetDocsVta_Det_Operacion()
      {
         try
         {
            return BL_PreDetDocsVta_Det_Operacion.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public PreDetDocsVta_Det_Operacion GetOnePreDetDocsVta_Det_Operacion(Int32 PDVO_Codigo)
      {
         try
         {
            return BL_PreDetDocsVta_Det_Operacion.GetOne(PDVO_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SavePreDetDocsVta_Det_Operacion(ref PreDetDocsVta_Det_Operacion Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_PreDetDocsVta_Det_Operacion.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
