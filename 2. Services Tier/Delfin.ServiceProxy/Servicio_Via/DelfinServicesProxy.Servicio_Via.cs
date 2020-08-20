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
      public IBLServicio_Via BL_Servicio_Via { get; set; }
      #endregion

      #region [ Consultas ]
      public System.Data.DataTable GetDTServicio_Via(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Servicio_Via.GetDT(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Servicio_Via> GetAllServicio_ViaFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
      {
         try
         {
            return BL_Servicio_Via.GetAllFilter(x_procedure, x_filters);
         }
         catch (Exception)
         { throw; }
      }
      public ObservableCollection<Servicio_Via> GetAllServicio_Via()
      {
         try
         {
            return BL_Servicio_Via.GetAll();
         }
         catch (Exception)
         { throw; }
      }
      public Servicio_Via GetOneServicio_Via(String CONS_TabVIA, String CONS_CodVIA, Int32 SERV_Codigo, String CONS_TabRGM, String CONS_CodRGM, String CONS_TabCEM, String CONS_CodCEM)
      {
         try
         {
            return BL_Servicio_Via.GetOne(CONS_TabVIA, CONS_CodVIA, SERV_Codigo, CONS_TabRGM, CONS_CodRGM, CONS_TabCEM, CONS_CodCEM);
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos ]
      public Boolean SaveServicio_Via(ref Servicio_Via Item)
      {
         try
         {
            if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
            {
               return BL_Servicio_Via.Save(ref Item);
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
