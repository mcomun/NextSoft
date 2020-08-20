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
using System.IO;

using System.Configuration;
using System.Net;
using System.Runtime.Serialization.Json;


namespace Delfin.Principal
{
   public partial class REP010DocumentosContabilizadosPresenter
   {
      #region [ Variables ]
      public String Title = "Documentos Contabilizados";
      public String CUS = "REP0101";
      public Boolean FleteNegativo = false;
      #endregion

      #region [ Contrusctor ]
      public REP010DocumentosContabilizadosPresenter(IUnityContainer x_container, IREP010DocumentosContabilizadosLView x_lview)
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


            //Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.AddComboBoxItem("I", "Ingreso", true);
            //Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.AddComboBoxItem("E", "Egreso");
            //ListIngresoEgreso = Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.GetComboBoxItems();

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

      public IREP010DocumentosContabilizadosLView LView { get; set; }

      public Cab_Cotizacion_OV Item { get; set; }
      public System.Data.DataTable Items { get; set; }

      public String F_TipoResultado { get; set; }
      public DateTime? F_FecIni { get; set; }
      public DateTime? F_FecFin { get; set; }

      #endregion

      #region [ Metodos ]

      public void Actualizar()
      {
         try
         {
            Item = null;
            Items = null;

            if (LView != null)
            {
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIni", FilterValue = F_FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFin", FilterValue = F_FecFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Tipo", FilterValue = F_TipoResultado, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });

               Items = Client.GetDTCtaCte("CAJ_REPOSS_DocOtrosTraficos", listFilters);

               LView.ShowItems();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }


      Boolean isMViewShow = false;


      public void CloseView()
      {
         if (isMViewShow)
         { }
      }
      public void IsClosedMView()
      { isMViewShow = false; }

      public Boolean VerificarPemisoEdicion()
      {
         try
         {
            //NextAdmin.Entities.PermisosUsuarioProcesos _itemPermisosUsuarioProcesos = ClientNextAdmin.GetOnePermisosUsuarioProcesosByUsuario(Session.AplicacionCodigo.Value, Session.UserCodigo, Delfin.Controls.variables.CCOT_EDITARCOTIZ);
            //if (_itemPermisosUsuarioProcesos != null && _itemPermisosUsuarioProcesos.PUPR_Codigo > 0)
            //{ return true; }
            //else
            //{ return false; }
            return true;
         }
         catch (Exception)
         { return false; }
      }
      #endregion


      #region [ Metodos Eventos/Tareas ]

      #endregion
   }
}