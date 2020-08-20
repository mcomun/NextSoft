using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Aspect;
using Infrastructure.Aspect.Collections;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using Infrastructure.WinFormsControls;
using System.Data;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
   public class PRO005Presenter
   {
      #region [ Variables ]
      public String Title = "Direccionamiento";
      public String CUS = "LOG005";
      #endregion
      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public Delfin.ServiceContracts.IDelfinServices Client { get; set; }
      public Int32 CDIR_Codigo { get; set; }
      public IPRO005LView LView { get; set; }

      public DataTable _dtDireccionamiento { get; set; }
      public Nave ItemNave { get; set; }
      public ObservableCollection<Nave> ItemsNave { get; set; }
      public Paquete ItemPaquete { get; set; }
      public ObservableCollection<Paquete> ItemsPaquete { get; set; }
      public Cab_Direccionamiento ItemDireccionamiento { get; set; }
      #endregion

      #region [ Constructor ]
      public PRO005Presenter(IUnityContainer x_container, IPRO005LView x_lview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.ConstructorPresenter, ex); }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<Delfin.ServiceContracts.IDelfinServices>();
            LView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.LoadPresenter, ex); }
      }

      public void LoadNaves()
      {

         ItemsNave = Client.GetAllNave(null);
         ItemsNave.Insert(0, new Nave() { NAVE_Nombre = "< Seleccione Nave >" });
      }
      public void LoadPaquetes()
      {

         ItemsPaquete = Client.GetAllPaquete();
      }

      public void Buscar(DateTime? FecEmi_Desde, DateTime? FecEmi_Hasta, DateTime? FecArr_Desde, DateTime? FecArr_Hasta, String HBL, String MBL, Int32? CodCliente, Int32? LineaN, Int32? DepTemporal, Int16 Nave, String NombreNave, String Viaje)
      {
         try
         {
            //_dtDireccionamiento = Client.GetAllCab_Direccionamiento(FecEmi_Desde, FecEmi_Hasta, FecArr_Desde, FecArr_Hasta, HBL, MBL, CodCliente, LineaN, DepTemporal, Nave);

            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CDIR_FecEmisionInicio", FilterValue = FecEmi_Desde, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CDIR_FecEmisionFin", FilterValue = FecEmi_Hasta, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CDIR_FecArriboInicio", FilterValue = FecArr_Desde, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CDIR_FecArriboFin", FilterValue = FecArr_Hasta, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CDIR_HBL", FilterValue = HBL, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CDIR_MBL", FilterValue = MBL, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@ENTC_CodCliente", FilterValue = CodCliente, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@ENTC_CodLinea", FilterValue = LineaN, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@ENTC_CodTemporal", FilterValue = DepTemporal, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@NAVE_Codigo", FilterValue = null, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CDIR_Nave", FilterValue = NombreNave, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 50 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CDIR_Viaje", FilterValue = Viaje, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 50 });

            _dtDireccionamiento = Client.GetDTAgMaritimoEntidad("SLI_CDIRSS_Todos", _listFilters);

            LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.LoadPresenter, ex); }
      }

      public void BuscarDetalle(Int32 CDIR_Codigo)
      {
         try
         {
            _dtDireccionamiento = Client.GetOneDet_Direccionamiento(0, CDIR_Codigo);
            LView.ShowItemsDetalle();
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.LoadPresenter, ex); }
      }

      public void ActualizarDepTemporal(DataTable _data)
      {
         try
         {
            Client.SaveDepTemporal(_data);
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.LoadPresenter, ex); }
      }
      public DataTable CargarForward(String _Nave, String _Viaje)
      {
         return Client.GetForward(_Nave, _Viaje);
      }

      public void AgregarDireccionamiento(DataTable dt)
      {
         for (int i = 0; i < dt.Rows.Count; i++)
         {
            if (!(dt.Rows[i]["CodCliente"] != DBNull.Value && !String.IsNullOrEmpty(dt.Rows[i]["CodCliente"].ToString())))
            { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeInformacion(Title, "No tiene un codigo de cliente valido"); return; }

            Cab_Direccionamiento _Item = new Cab_Direccionamiento
            {
               AUDI_UsrCrea = Session.UserName,
               Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added,
               CDIR_HBL = dt.Rows[i]["HBL"].ToString(),
               CDIR_MBL = dt.Rows[i]["MBL"].ToString(),
               CDIR_Viaje = dt.Rows[i]["Viaje"].ToString(),
               CDIR_Nave = dt.Rows[i]["Nave"].ToString(),
               CDIR_FecArribo = Convert.ToDateTime(dt.Rows[i]["FLLegada"].ToString()),
               CDIR_FecEmision = Convert.ToDateTime(dt.Rows[i]["FSalida"].ToString()), 
               ENTC_CodCliente = Convert.ToInt32(dt.Rows[i]["CodCliente"].ToString()),
               ENTC_CodLinea = Convert.ToInt32(dt.Rows[i]["CodLinea"].ToString()),
            };
            Client.SaveCab_Direccionamiento(ref _Item);
            CargarDetalleForward(Int16.Parse(dt.Rows[i]["CCOT_Tipo"].ToString()), Int32.Parse(dt.Rows[i]["CCOT_Numero"].ToString()), _Item.CDIR_Codigo);
         }
      }

      public void CargarDetalleForward(Int16 CCOT_Tipo, Int32 CCOT_Numero, Int32 CDIR_Codigo)
      {
         Det_Direccionamiento _Item;
         ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
         _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinCCOT_Tipo", FilterValue = CCOT_Tipo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
         _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintCCOT_Numero", FilterValue = CCOT_Numero, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
         ObservableCollection<Det_CNTR> ListaCNTR = Client.GetAllDet_CNTRFilter("OPE_DHBLSS_TodosPorOV", _listFilters);

         if (ListaCNTR != null && ListaCNTR.Count > 0)
         {
            ObservableCollection<Det_Direccionamiento> ItemsDetalle = new ObservableCollection<Det_Direccionamiento>();
            foreach (Det_CNTR item in ListaCNTR)
            {
               _Item = new Det_Direccionamiento
               {
                  AUDI_UsrCrea = Session.UserName,
                  CDIR_Codigo = CDIR_Codigo,
                  DDIR_Cantidad = 1,
                  DDIR_Tarja = true,
                  DDIR_Rebate = false,
                  DDIR_Contenedor = item.CNTR_Numero, //_dt.Rows[0]["con_numero"].ToString(),
                  DDIR_Estado = "A",
                  DDIR_MontoTarja = 0,
                  DDIR_MontoRebate = 0,
                  PACK_Codigo = item.PACK_Codigo, //Convert.ToInt32(_dt.Rows[0]["con_tipo"].ToString()),
                  Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added,
               };
               Client.SaveDet_Direccionamiento(_Item);
            }
         }
      }
      #endregion


   }
}
