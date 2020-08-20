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
      public IBLFuncionEntidad BL_FuncionEntidad { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTFuncionEntidad(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_FuncionEntidad.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<FuncionEntidad> GetAllFuncionEntidadFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_FuncionEntidad.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<FuncionEntidad> GetAllFuncionEntidad()
      {
         try
         {
            return BL_FuncionEntidad.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public FuncionEntidad GetOneFuncionEntidad(Int32 ENTC_Codigo, Int16 TIPE_Codigo)
      {
         try
         {
            return BL_FuncionEntidad.GetOne(ENTC_Codigo, TIPE_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveFuncionEntidad(ref FuncionEntidad Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_FuncionEntidad.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
