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
        public LoadingList GetALoadingListByLoad_Codigo(Nullable<Int32> LOAD_Codigo)
        {
            try
            {
                return BL_LoadingList.GetALoadingListByLoad_Codigo(LOAD_Codigo);
            }
            catch (Exception)
            { throw; }
        }
        #endregion

        #region [ Metodos ]
        public Boolean SaveLoadingListImportResumido(System.Data.DataTable dtImportacion, String LOAD_CargaUsuario, DateTime LOAD_CargaFecha, String CONS_TabVIA, String CONS_CodVIA, ref String LOAD_MensajeError)
        {
            try
            {
                return BL_LoadingList.SaveImportResumido(dtImportacion, LOAD_CargaUsuario, LOAD_CargaFecha, CONS_TabVIA, CONS_CodVIA, ref LOAD_MensajeError);
            }
            catch (Exception)
            { throw; }
        }
        public ObservableCollection<LoadingList> GetAllLoadingListImportResumido(DateTime LOAD_CargaFecha)
        {
            try
            {
                return BL_LoadingList.GetAllImportResumido(LOAD_CargaFecha);
            }
            catch (Exception)
            { throw; }
        }

        public Boolean SaveLoadingListImportDetallado(System.Data.DataTable dtImportacion, String LOAD_CargaUsuario, DateTime LOAD_CargaFecha, String CONS_TabVIA, String CONS_CodVIA, ref String LOAD_MensajeError)
        {
            try
            {
                return BL_LoadingList.SaveImportDetallado(dtImportacion, LOAD_CargaUsuario, LOAD_CargaFecha, CONS_TabVIA, CONS_CodVIA, ref LOAD_MensajeError);
            }
            catch (Exception)
            { throw; }
        }
        public ObservableCollection<LoadingListDetallado> GetAllLoadingListImportDetallado(DateTime LOAD_CargaFecha)
        {
            try
            {
                return BL_LoadingList.GetAllImportDetallado(LOAD_CargaFecha);
            }
            catch (Exception)
            { throw; }
        }

        public Boolean UpdateLoadingListCorreo(Int32 LOAD_Codigo, Boolean LOAD_EnvioCorreo, String LOAD_EnvioCorreoUsr)
        {
            try
            {
                return BL_LoadingList.UpdateCorreo(LOAD_Codigo, LOAD_EnvioCorreo, LOAD_EnvioCorreoUsr);
            }
            catch (Exception)
            { throw; }
        }
        public Boolean SaveLoadingListControlDoc(LoadingList Item)
        {
            try
            {
                if (Item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged)
                {
                    return BL_LoadingList.SaveControlDoc(ref Item);
                }
                return true;
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion
    }
}
