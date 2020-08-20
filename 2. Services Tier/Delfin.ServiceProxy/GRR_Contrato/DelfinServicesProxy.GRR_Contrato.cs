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
      public IBLGRR_Contrato BL_GRR_Contrato { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTGRR_Contrato(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_GRR_Contrato.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<GRR_Contrato> GetAllGRR_ContratoFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_GRR_Contrato.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<GRR_Contrato> GetAllGRR_Contrato()
      {
         try
         {
            return BL_GRR_Contrato.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public GRR_Contrato GetOneGRR_Contrato(String REBA_Tipo, Int32 REBA_Codigo, Int32 CONT_Codigo)
      {
         try
         {
            return BL_GRR_Contrato.GetOne(REBA_Tipo, REBA_Codigo, CONT_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveGRR_Contrato(ref GRR_Contrato Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_GRR_Contrato.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
