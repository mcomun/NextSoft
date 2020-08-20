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
		#region [ Consultas ]

      public ObservableCollection<Entidad_Relacionados> GetAllDepositoTemporalByCliente(Int32 ENTC_Codigo)
      {
         try
         {
            return BL_EntidadRelacionados.GetAllDepositoTemporalByCliente(ENTC_Codigo);
         }
         catch (Exception)
         { throw; }
      }

      public ObservableCollection<Entidad_Relacionados> GetAllEntidadRelacionadosByCliente(Nullable<Int32> ENTC_Codigo, String RELA_Tipos)
      {
         try
         {
            return BL_Entidad_Relacionados.GetAllEntidadRelacionadosByCliente(ENTC_Codigo, RELA_Tipos);
         }
         catch (Exception)
         { throw; }
      }

      public ObservableCollection<Entidad_Relacionados> GetAllEntidadRelacionadosByRelaTipo(String RELA_Tipos)
      {
         try
         {
            return BL_Entidad_Relacionados.GetAllEntidadRelacionadosByRelaTipo(RELA_Tipos);
         }
         catch (Exception)
         { throw; }
      }
         
		#endregion

		#region [ Metodos ]
		#endregion
   }
}
