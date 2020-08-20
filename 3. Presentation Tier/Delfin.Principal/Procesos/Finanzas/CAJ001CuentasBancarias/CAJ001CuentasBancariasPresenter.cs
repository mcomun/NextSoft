using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.BusinessEntity;
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
   /// <summary>
   /// Clase Presenter de Cuentas Bancarias
   /// </summary>
   public partial class CAJ001CuentasBancariasPresenter
   {
      #region [ Variables ]
      public String Title = "Cuentas Bancarias";
      public String CUS = "CAJ001";
      #endregion

      #region [ Constructor ]
      public CAJ001CuentasBancariasPresenter(IUnityContainer x_container, ICAJ001CuentasBancariasLView x_lview, ICAJ001CuentasBancariasMView x_mview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
            //this.MView = x_mview;
         }
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Inicializa las principales clases del modulo de cuentas bancarias
      /// </summary>
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();
            ListSucursales = Client.GetAllSucursales();
            ListTipoChequera = new ObservableCollection<Constantes>();
            ListTipoChequera.Add(new Constantes() { CONS_CodTipo = "N", CONS_Desc_SPA = "Normal" });
            ListTipoChequera.Add(new Constantes() { CONS_CodTipo = "D", CONS_Desc_SPA = "Diferido" });
            var BL_Usuarios = ContainerService.Resolve<NextAdmin.BusinessLogic.IBLUsuarios>();
            ListUsuarios = BL_Usuarios.GetAll();

            string x_year = Client.GetFecha().Year.ToString();
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TIPO_CodTabla", FilterValue = "REG", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TIPO_ano", FilterValue = x_year, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 4 });
            
            System.Data.DataSet DSTiposOPE = Client.GetDSDocsVta("CON_TABLSS_TodosPorTipo", _listFilters);
            ListTiposREG = DSTiposOPE.Tables[0].ToObservableCollection<Tipos>();

            /* Inicializa los principales controles del la interfaz LView - Pantalla de inicial de presentación */
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

      public ICAJ001CuentasBancariasLView LView { get; set; }
      public ICAJ001CuentasBancariasMView MView { get; set; }

      public Entities.CuentasBancarias Item { get; set; }
      public ObservableCollection<Entities.CuentasBancarias> Items { get; set; }
      public ObservableCollection<Sucursales> ListSucursales { get; set; }
      public ObservableCollection<Constantes> ListTipoChequera { get; set; }
      public ObservableCollection<NextAdmin.BusinessLogic.Usuarios> ListUsuarios { get; set; }
      public ObservableCollection<Tipos> ListTiposREG { get; set; }

      public Int16? SUCR_Codigo { get; set; }
      public String CUBA_Codigo { get; set; }
      public String CUBA_TipoCuenta { get; set; }
      public Boolean CUBA_Bloqueo { get; set; }

      public DateTime? FecIni { get; set; }
      public DateTime? FecFin { get; set; }

      private Boolean isMViewShow = false;

      #endregion

      #region [ Metodos ]
      /// <summary>
      /// Realiza la busqueda de registros del LView
      /// </summary>
      public void Actualizar()
      {
         try
         {
            Item = null;
            Items = null;

            if (LView != null)
            {
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 22 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinSUCR_Codigo", FilterValue = SUCR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 22 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCUBA_Codigo", FilterValue = CUBA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCUBA_TipoCuenta", FilterValue = CUBA_TipoCuenta, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 1 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitCUBA_Bloqueo", FilterValue = CUBA_Bloqueo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIni", FilterValue = FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFin", FilterValue = FecFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

               Items = Client.GetAllCuentasBancariasFilter("CAJ_CUBASS_Busqueda", _listFilters);
               if (Items == null || Items.Count == 0)
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias "); }

               LView.ShowItems();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      /// <summary>
      /// Lanza el formulario para la creación de un registro de cuentas bancarias
      /// </summary>
      public void Nuevo()
      {
         try
         {
            if (!isMViewShow)
            {
               MView = new CAJ001CuentasBancariasMView();
               MView.Presenter = this;
               MView.LoadView();
            }

            MView.ClearItem();
            this.Item = new CuentasBancarias();
            this.Item.ListChequera = new ObservableCollection<Chequera>();
            this.Item.ListCuentasBancariasUsuarios = new ObservableCollection<CuentasBancariasUsuarios>();
            this.Item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            this.Item.SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
            this.Item.AUDI_UsrCrea = Session.UserName;
            this.Item.AUDI_FecCrea = Session.Fecha;
            this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            MView.SetItem();
            isMViewShow = true;

            if (LView != null) { ((CAJ001CuentasBancariasMView)MView).Icon = Icon.FromHandle(((Bitmap)LView.IconView).GetHicon()); }
            ((CAJ001CuentasBancariasMView)MView).Show();
            ((CAJ001CuentasBancariasMView)MView).BringToFront();

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }

      public void Editar()
      {
         try
         {
            if (!isMViewShow)
            {
               MView = new CAJ001CuentasBancariasMView();
               MView.Presenter = this;
               MView.LoadView();
            }
            if (Item != null)
            {
               Item = Client.GetOneCuentasBancarias(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Item.CUBA_Codigo);

               MView.ClearItem();
               this.Item.AUDI_UsrMod = Session.UserName;
               this.Item.AUDI_FecMod = Session.Fecha;
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
               MView.SetItem();

               isMViewShow = true;
               if (LView != null) { ((CAJ001CuentasBancariasMView)MView).Icon = Icon.FromHandle(((Bitmap)LView.IconView).GetHicon()); }
               ((CAJ001CuentasBancariasMView)MView).Show();
               ((CAJ001CuentasBancariasMView)MView).BringToFront();
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }

      /// <summary>
      /// Metodo que lanza la interfaz para crear un nuevo registro de chequera
      /// </summary>
      /// <param name="x_item"></param>
      /// <returns></returns>
      public Boolean NuevaChequera(int x_item)
      {
         try
         {
            Entities.Chequera _chequera = new Entities.Chequera();

            _chequera.CHEQ_Codigo = ++x_item;
            _chequera.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            _chequera.AUDI_UsrCrea = Session.UserName;
            _chequera.AUDI_FecCrea = Session.Fecha;
            _chequera.Instance = InstanceEntity.Added;

            CAJ001CuentasBancariasCView CView = new CAJ001CuentasBancariasCView();
            CView.LoadView(CAJ001CuentasBancariasCView.TInicio.Nuevo);
            CView.Item = _chequera;
            CView.Presenter = this;
            CView.StartPosition = FormStartPosition.CenterScreen;
            if (CView.ShowDialog() == DialogResult.OK)
            {
               Item.ListChequera.Add(CView.Item);
               return true;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Método que lanza la interfaz para editar un registro de la chequera
      /// </summary>
      /// <param name="_chequera"></param>
      /// <returns></returns>
      public Boolean EditarChequera(ref Entities.Chequera _chequera)
      {
         try
         {
            _chequera.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            _chequera.AUDI_UsrMod = Session.UserName;
            _chequera.AUDI_FecMod = Session.Fecha;

            CAJ001CuentasBancariasCView CView = new CAJ001CuentasBancariasCView();
            CView.Item = _chequera;
            CView.LoadView(CAJ001CuentasBancariasCView.TInicio.Nuevo);
            CView.Presenter = this;
            CView.StartPosition = FormStartPosition.CenterScreen;
            if (CView.ShowDialog() == DialogResult.OK)
            { return true; }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      public void Eliminar()
      {
         try
         {
            if (Item != null)
            {
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                  Entities.CuentasBancarias _item = Item;
                  Client.SaveCuentasBancarias(ref _item);
                  Item = _item;
                  if (Item != null)
                  {
                     Actualizar();
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item."); }
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex); }
      }

      /// <summary>
      /// Realiza la operación de Insercion/Actualización del registro en base de datos
      /// </summary>
      /// <param name="ShowMessage"></param>
      /// <returns></returns>
      public bool Guardar(Boolean ShowMessage)
      {
         try
         {
            MView.GetItem();
            if (Item.Validar())
            {
               Entities.CuentasBancarias _item = Item;
               Client.SaveCuentasBancarias(ref _item);
               Item = _item;
               if (Item != null)
               {
                  if (ShowMessage) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente"); }

                  MView.ClearItem();
                  this.Item.AUDI_UsrMod = Session.UserName;
                  this.Item.AUDI_FecMod = Session.Fecha;
                  this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                  MView.SetItem();

                  return true;
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                  return false;
               }
            }
            else
            {
               MView.ShowValidation();
               return false;
            }
            return false;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
            return false;
         }
      }

      /// <summary>
      /// Lanza el dialogo de guardar cuando se cierra el formulario de datos del registro (MView)
      /// </summary>
      /// <returns></returns>
      public System.Windows.Forms.DialogResult GuardarCambios()
      {
         try
         {
            if (this.Item != null)
            {
               ((CAJ001CuentasBancariasMView)MView).BringToFront();
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.SaveChangesPreguntaPresenter, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  if (Guardar(true))
                  { return System.Windows.Forms.DialogResult.Yes; }
                  else
                  { return System.Windows.Forms.DialogResult.Cancel; }
               }
               else
               { return _result; }
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al cerrar el formulario.");
               return System.Windows.Forms.DialogResult.Cancel;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
            return System.Windows.Forms.DialogResult.Cancel;
         }
      }

      public void CloseView()
      {
         if (isMViewShow)
         { ((CAJ001CuentasBancariasMView)MView).Close(); }
      }

      public void IsClosedMView()
      { isMViewShow = false; }

      #endregion

      #region [ Metodos Eventos/Tareas ]

      #endregion
   }
}