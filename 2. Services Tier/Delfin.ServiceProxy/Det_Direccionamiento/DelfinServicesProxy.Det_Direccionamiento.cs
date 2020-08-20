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
      public IBLDet_Direccionamiento BL_Det_Direccionamiento { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTDet_Direccionamiento(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Det_Direccionamiento.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Det_Direccionamiento> GetAllDet_DireccionamientoFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Det_Direccionamiento.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Det_Direccionamiento> GetAllDet_Direccionamiento()
      {
         try
         {
            return BL_Det_Direccionamiento.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public Det_Direccionamiento GetOneDet_Direccionamiento(Int32 CDIR_Codigo, Int32 DDIR_Item)
      {
         try
         {
            return BL_Det_Direccionamiento.GetOne(CDIR_Codigo, DDIR_Item);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveDet_Direccionamiento(ref Det_Direccionamiento Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Det_Direccionamiento.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
