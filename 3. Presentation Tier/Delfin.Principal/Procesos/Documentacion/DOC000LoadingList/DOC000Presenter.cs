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
using Infrastructure.WinForms.Controls;
using System.Data;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
    public class DOC000Presenter
   {
      #region [ Variables ]
      public String Title = "LoadingList";
      public String CUS = "DOC000";
      #endregion
      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public DelfinServicesProxy Client { get; set; }
      public Int32 CDIR_Codigo { get; set; }
      public IDOC000LView LView { get; set; }

      public DataTable _dtDireccionamiento { get; set; }
      public Nave ItemNave { get; set; }
      public ObservableCollection<Nave> ItemsNave { get; set; }
      public Paquete ItemPaquete { get; set; }
      public ObservableCollection<Paquete> ItemsPaquete { get; set; }
      public Cab_Direccionamiento ItemDireccionamiento { get; set; }
      #endregion

      #region [ Constructor ]
      public DOC000Presenter(IUnityContainer x_container, IDOC000LView x_lview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.ConstructorPresenter, ex); }
      }
      public void Load()
      {
         try
         {
            Client = new DelfinServicesProxy();
            LView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.LoadPresenter, ex); }
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

      public void Buscar(DateTime FecEmi_Desde, DateTime FecEmi_Hasta, DateTime FecArr_Desde, DateTime FecArr_Hasta, String HBL, String MBL, Int32 CodCliente, Int32 LineaN, Int32 DepTemporal, Int16 Nave)
      {
         try
         {
            _dtDireccionamiento = Client.GetAllCab_Direccionamiento(FecEmi_Desde, FecEmi_Hasta, FecArr_Desde, FecArr_Hasta, HBL, MBL, CodCliente, LineaN, DepTemporal, Nave);
            LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.LoadPresenter, ex); }
      }

      public void BuscarDetalle(Int32 CDIR_Codigo)
      {
         try
         {
            _dtDireccionamiento = Client.GetOneDet_Direccionamiento(0, CDIR_Codigo); 
            LView.ShowItemsDetalle();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.LoadPresenter, ex); }
      }

      public void ActualizarDepTemporal(DataTable _data)
      {
         try
         {
            Client.SaveDepTemporal(_data);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.LoadPresenter, ex); }
      }
      public DataTable CargarForward(String _Nave, String _Viaje)
      {
         return Client.GetForward(_Nave, _Viaje);  
      }

      public void AgregarDireccionamiento(DataTable dt)
      {
         for (int i = 0; i < dt.Rows.Count; i++)
         {
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
            CargarDetalleForward(Convert.ToInt32(dt.Rows[i]["Operacion"].ToString()), _Item.CDIR_Codigo);
         }
      }

      public void CargarDetalleForward(Int32 x_Operacion, Int32 CDIR_Codigo)
      {
         DataTable _dt = new DataTable();
         Det_Direccionamiento _Item;
         _dt = Client.GetDetalleForward(x_Operacion);
         ObservableCollection<Det_Direccionamiento> ItemsDetalle = new ObservableCollection<Det_Direccionamiento>();
         for (Int16 i = 0; i < _dt.Rows.Count; i++)
         {
            _Item = new Det_Direccionamiento
            {
               AUDI_UsrCrea = Session.UserName,
               CDIR_Codigo = CDIR_Codigo,
               DDIR_Cantidad = 1,
               DDIR_Tarja = true,
               DDIR_Rebate = false,
               DDIR_Contenedor = _dt.Rows[0]["con_numero"].ToString(),
               DDIR_Estado = "A",
               DDIR_MontoTarja = 0,
               DDIR_MontoRebate = 0,
               PACK_Codigo = Convert.ToInt32(_dt.Rows[0]["con_tipo"].ToString()),
               Instance =  Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added,
            };
            Client.SaveDet_Direccionamiento(_Item); 
         }
         
      }
      #endregion


   }
}
