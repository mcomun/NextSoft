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
      public IBLEntidadCuentaBancaria BL_EntidadCuentaBancaria { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTEntidadCuentaBancaria(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_EntidadCuentaBancaria.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<EntidadCuentaBancaria> GetAllEntidadCuentaBancariaFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_EntidadCuentaBancaria.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<EntidadCuentaBancaria> GetAllEntidadCuentaBancaria()
      {
         try
         {
            return BL_EntidadCuentaBancaria.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public EntidadCuentaBancaria GetOneEntidadCuentaBancaria(Int32 ENTC_Codigo, String TIPO_TabBCO, String TIPO_CodBCO)
      {
         try
         {
            return BL_EntidadCuentaBancaria.GetOne(ENTC_Codigo, TIPO_TabBCO, TIPO_CodBCO);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveEntidadCuentaBancaria(ref EntidadCuentaBancaria Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_EntidadCuentaBancaria.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
