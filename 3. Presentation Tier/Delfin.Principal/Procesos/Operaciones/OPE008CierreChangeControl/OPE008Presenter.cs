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
//using Delfin.Controls;

namespace Delfin.Principal
{
   public class OPE008Presenter
   {
      #region [ Variables ]
      public String Title = "Cierre ChangeControl";
      public String CUS = "OPE008";

      private CierresChangeControl m_item;
      private ObservableCollection<CierresChangeControl> m_items;
      #endregion

      #region [ Contrusctor ]
      public OPE008Presenter(IUnityContainer x_container, IOPE008LView x_lview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
         }
         catch (Exception)
         { throw; }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();
            LView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }
      public IOPE008LView LView { get; set; }

      public CierresChangeControl Item
      {
         get { return m_item; }
         set { m_item = value; }
      }
      public ObservableCollection<CierresChangeControl> Items
      {
         get { if (m_items == null) { m_items = new ObservableCollection<CierresChangeControl>(); } return m_items; }
         set { m_items = value; }
      }
      #endregion

      #region [ Filtros ]
      public Nullable<Int16> FILTRO_CHAN_Anio { get; set; }
      #endregion

      #region [ Metodos ]
      public void Actualizar()
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinSUCR_Codigo", FilterValue = Controls.Entorno.ItemSucursal.SUCR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinCHAN_Anio", FilterValue = FILTRO_CHAN_Anio, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            Items = Client.GetAllCierresChangeControlFilter("OPE_CHANSS_Todos", _filters);

            LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando el reporte.", ex); }
      }
      public void Cerrar()
      {
         try
         {
            if (Item.Validar())
            {
               if (Item.CHAN_Estado == "A")
               {
                  m_item.CHAN_Estado = "C";
                  m_item.CHAN_UsuarioCierre = Session.UserName;
                  m_item.CHAN_FechaCierre = Session.Fecha;
                  m_item.AUDI_UsrCrea = Session.UserName;
                  m_item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

                  String MensajeError = String.Empty;
                  if (Client.SaveCierresChangeControl(ref m_item, ref MensajeError))
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha cerrado satisfactoriamente el mes."); }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al cerrar el mes.", MensajeError); }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "El mes ya se encuentra cerrado."); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Faltan Datos Obligatorios.", Item.MensajeError); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cerrando el mes.", ex); }
         finally
         { Actualizar(); }
      }
      public void Aperturar()
      {
         try
         {
            if (Item.Validar())
            {
               if (Item.CHAN_Estado == "C")
               {
                  m_item.CHAN_Estado = "A";
                  m_item.CHAN_UsuarioApertura = Session.UserName;
                  m_item.CHAN_FechaApertura = Session.Fecha;
                  m_item.AUDI_UsrMod = Session.UserName;
                  m_item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;

                  String MensajeError = String.Empty;
                  if (Client.SaveCierresChangeControl(ref m_item, ref MensajeError))
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha aperturado satisfactoriamente el mes."); }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al aperturar el mes.", MensajeError); }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "El mes ya se encuentra abierto."); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Faltan Datos Obligatorios.", Item.MensajeError); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando el reporte.", ex); }
         finally
         { Actualizar(); }
      }
      #endregion

   }
}
