using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Aspect.Constants;
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
   public partial class CAJ005TransferenciasPresenter
   {
      #region [ Variables ]
      public String Title = "Transferencias";
      public String CUS = "CAJ005";
      #endregion

      #region [ Contrusctor ]
      public CAJ005TransferenciasPresenter(IUnityContainer x_container, ICAJ005TransferenciasLView x_lview)
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
            Fecha = Client.GetFecha();

            String fecha = Fecha.ToString("yyyyMMdd");
            Entities.TiposCambio _TCambio = Client.GetOneTiposCambio(fecha);
            MensajeError = "";
            if (_TCambio != null)
            {
               TipoCambio = _TCambio.TIPC_Venta;
               if (!(TipoCambio > 0))
               { MensajeError = String.Format("El tipo de Cambio definido para [{0:dd/MM/yyyy}] no es correcto.", Fecha); Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, MensajeError); }
            }
            else { MensajeError = String.Format("No se ha definido el tipo de cambio para el dia {0:dd/MM/yyyy}", Fecha); Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, MensajeError); }

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

      public ICAJ005TransferenciasLView LView { get; set; }
      public ICAJ005TransferenciasMView MView { get; set; }
      public ICAJ005TransferenciasMViewSmall MViewReducido { get; set; }

      public Transferencia Item { get; set; }
      public ObservableCollection<Transferencia> Items { get; set; }
      public DateTime Fecha { get; set; }

      public Decimal TipoCambio { get; set; }
      public String MensajeError { get; set; }

      public int? F_TRAN_Codigo { get; set; }
      public DateTime? F_FecIni { get; set; }
      public DateTime? F_FecFin { get; set; }

      public Movimiento MOVI_Ingresos { get; set; }
      public Movimiento MOVI_Egresos { get; set; }
      public GastosBancarios MOVI_GBancarios { get; set; }

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
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintTRAN_Codigo", FilterValue = F_TRAN_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 10 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmTRAN_Fecha_Ini", FilterValue = F_FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmTRAN_Fecha_Fin", FilterValue = F_FecFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

               Items = Client.GetAllTransferenciaFilter("CAJ_TRANSS_TodosBusqueda", listFilters);

               LView.ShowItems();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      Boolean isMViewShow = false;
      public void Nuevo()
      {
         try
         {
            if (!isMViewShow)
            {
               MView = new CAJ005TransferenciasMView();
               MView.Presenter = this;
               MView.LoadView();
            }

            MView.ClearItem();
            this.Item = new Transferencia();
            this.Item.TRAN_Tipo = "N";
            this.Item.ListEgresos = new ObservableCollection<Movimiento>();
            this.Item.ListIngresos = new ObservableCollection<Movimiento>();
            this.Item.ListGastosBancarios = new ObservableCollection<GastosBancarios>();

            this.Item.ListEgresosEliminados = new ObservableCollection<Movimiento>();
            this.Item.ListIngresosEliminados = new ObservableCollection<Movimiento>();
            this.Item.ListGastosBancariosEliminados = new ObservableCollection<GastosBancarios>();

            this.Item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            this.Item.AUDI_UsrCrea = Session.UserName;
            this.Item.AUDI_FecCrea = Session.Fecha;
            this.Item.SetEstado(Transferencia.Estado.Ingresado);
            this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            MView.SetItem();

            isMViewShow = true;
            if (LView != null) { ((CAJ005TransferenciasMView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
            ((CAJ005TransferenciasMView)MView).ShowDialog();
            ((CAJ005TransferenciasMView)MView).BringToFront();

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }

      public void NuevoReducido()
      {
         try
         {
            if (!isMViewShow)
            {
               MViewReducido = new CAJ005TransferenciasMViewSmall();
               MViewReducido.Presenter = this;
               MViewReducido.LoadView();
            }

            MViewReducido.ClearItem();
            this.Item = new Transferencia();
            this.Item.TRAN_Tipo = "R";
            this.Item.ListEgresos = new ObservableCollection<Movimiento>();
            this.Item.ListIngresos = new ObservableCollection<Movimiento>();
            this.Item.ListGastosBancarios = new ObservableCollection<GastosBancarios>();

            this.Item.ListEgresosEliminados = new ObservableCollection<Movimiento>();
            this.Item.ListIngresosEliminados = new ObservableCollection<Movimiento>();
            this.Item.ListGastosBancariosEliminados = new ObservableCollection<GastosBancarios>();

            this.MOVI_Egresos = new Entities.Movimiento();
            this.MOVI_Egresos.Instance = InstanceEntity.Added;

            this.MOVI_GBancarios = new Entities.GastosBancarios();
            this.MOVI_GBancarios.Instance = InstanceEntity.Added;

            this.MOVI_Ingresos = new Entities.Movimiento();
            this.MOVI_Ingresos.Instance = InstanceEntity.Added;

            this.Item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            this.Item.AUDI_UsrCrea = Session.UserName;
            this.Item.AUDI_FecCrea = Session.Fecha;
            this.Item.SetEstado(Transferencia.Estado.Ingresado);
            this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            MViewReducido.SetItem();

            isMViewShow = true;
            if (LView != null) { ((CAJ005TransferenciasMViewSmall)MViewReducido).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
            ((CAJ005TransferenciasMViewSmall)MViewReducido).StartPosition = FormStartPosition.CenterScreen;
            ((CAJ005TransferenciasMViewSmall)MViewReducido).ShowDialog();
            ((CAJ005TransferenciasMViewSmall)MViewReducido).BringToFront();

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
               MView = new CAJ005TransferenciasMView();
               MView.Presenter = this;
               MView.LoadView();
            }


            if (Item.TRAN_Estado.Equals(Item.GetEstado(Transferencia.Estado.Anulado)))
            {
               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "El registro se encuentra anulado, ¿Desea abrir el registro en solo lectura?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
               {
                  MView.EnabledItem(false);
               }
               else { return; }
            }

            if (Item.TRAN_Tipo.Equals("R"))
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "El registro seleccionado fue creado desde el módulo reducido, si continua la edición ya no podra editarlo desde el módulo reducido."); }

            Item = Client.GetOneTransferencia(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Item.TRAN_Codigo);

            if (Item != null)
            {
               MView.ClearItem();
               this.Item.AUDI_UsrMod = Session.UserName;
               this.Item.AUDI_FecMod = Session.Fecha;

               this.Item.ListEgresosEliminados = new ObservableCollection<Movimiento>();
               this.Item.ListIngresosEliminados = new ObservableCollection<Movimiento>();
               this.Item.ListGastosBancariosEliminados = new ObservableCollection<GastosBancarios>();

               MView.SetItem();

               isMViewShow = true;
               if (LView != null) { ((CAJ005TransferenciasMView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
               ((CAJ005TransferenciasMView)MView).ShowDialog();
               ((CAJ005TransferenciasMView)MView).BringToFront();
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }

      public void EditarReducido()
      {
         try
         {
            if (!isMViewShow)
            {
               MViewReducido = new CAJ005TransferenciasMViewSmall();
               MViewReducido.Presenter = this;
               MViewReducido.LoadView();
            }

            if (Item.TRAN_Estado.Equals(Item.GetEstado(Transferencia.Estado.Anulado)))
            {
               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "El registro se encuentra anulado, ¿Desea abrir el registro en solo lectura?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
               {
                  MViewReducido.EnabledItem(false);
               }
               else { return; }
            }
            if (Item.TRAN_Tipo.Equals("N"))
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "El registro seleccionado fue editado desde el módulo detallado, y no puede ser editado con el modo reducido.");
               return;
            }

            Item = Client.GetOneTransferencia(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Item.TRAN_Codigo);

            if (Item != null)
            {
               MViewReducido.ClearItem();
               this.Item.AUDI_UsrMod = Session.UserName;
               this.Item.AUDI_FecMod = Session.Fecha;

               this.Item.ListEgresosEliminados = new ObservableCollection<Movimiento>();
               this.Item.ListIngresosEliminados = new ObservableCollection<Movimiento>();
               this.Item.ListGastosBancariosEliminados = new ObservableCollection<GastosBancarios>();

               if (Item.ListEgresos != null && Item.ListEgresos.Count > 0) { MOVI_Egresos = Item.ListEgresos[0]; } else { MOVI_Egresos = new Movimiento(); }
               if (Item.ListIngresos != null && Item.ListIngresos.Count > 0) { MOVI_Ingresos = Item.ListIngresos[0]; } else { MOVI_Ingresos = new Movimiento(); }
               if (Item.ListGastosBancarios != null && Item.ListGastosBancarios.Count > 0) { MOVI_GBancarios = Item.ListGastosBancarios[0]; } else { MOVI_GBancarios = new GastosBancarios(); }

               MViewReducido.SetItem();

               isMViewShow = true;
               if (LView != null) { ((CAJ005TransferenciasMViewSmall)MViewReducido).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
               ((CAJ005TransferenciasMViewSmall)MViewReducido).StartPosition = FormStartPosition.CenterScreen;
               ((CAJ005TransferenciasMViewSmall)MViewReducido).ShowDialog();
               ((CAJ005TransferenciasMViewSmall)MViewReducido).BringToFront();
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
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
                  Entities.Transferencia _item = Item;
                  if (Client.SaveTransferencia(ref _item))
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

      public void Anular()
      {
         try
         {
            if (Item != null)
            {
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaAnular, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                  Entities.Transferencia _item = Item;
                  _item.SetEstado(Transferencia.Estado.Anulado);
                  if (Client.SaveTransferencia(ref _item, Entities.Transferencia.TOperacion.Anular))
                  {
                     Actualizar();
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha anulado el registro correctamente.");
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

      public bool Guardar(Boolean ShowMessage)
      {
         try
         {
            MView.GetItem();
            if (Item.Validar())
            {
               Entities.Transferencia _item = Item;
               if (Client.SaveTransferencia(ref _item))
               {
                  if (ShowMessage) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente"); }
                  return true;
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

      public bool GuardarReducido(Boolean ShowMessage)
      {
         try
         {
            MViewReducido.GetItem();


            Item.ListIngresos = new ObservableCollection<Movimiento>();
            Item.ListIngresos.Add(MOVI_Ingresos);

            Item.ListEgresos = new ObservableCollection<Movimiento>();
            Item.ListEgresos.Add(MOVI_Egresos);

            if (MOVI_GBancarios.GBAN_MontoDebe + MOVI_GBancarios.GBAN_MontoHaber > 0)
            {
               if (Item.Instance == InstanceEntity.Added)
               { MOVI_GBancarios.Instance = InstanceEntity.Added; }
               else
               {
                  if (Item.ListGastosBancarios.Count > 0)
                  { MOVI_GBancarios.Instance = InstanceEntity.Modified; }
                  if (Item.ListGastosBancarios.Count == 0)
                  { MOVI_GBancarios.Instance = InstanceEntity.Added; }                  
               }

               Item.ListGastosBancarios = new ObservableCollection<GastosBancarios>(); 
               Item.ListGastosBancarios.Add(MOVI_GBancarios);
            }
            else { Item.ListGastosBancariosEliminados.Add(MOVI_GBancarios); Item.ListGastosBancarios = new ObservableCollection<GastosBancarios>(); }

            if (Item.Validar())
            {
               Entities.Transferencia _item = Item;
               if (Client.SaveTransferencia(ref _item))
               {
                  if (ShowMessage) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente"); }
                  return true;
               }
               else
               {
                  MViewReducido.ShowValidation();
                  return false;
               }
            }
            else
            {
               MViewReducido.ShowValidation();
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

      public System.Windows.Forms.DialogResult GuardarCambios()
      {
         try
         {
            if (this.Item != null)
            {
               ((CAJ005TransferenciasMView)MView).BringToFront();
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

      public System.Windows.Forms.DialogResult GuardarCambiosReducido()
      {
         try
         {
            if (this.Item != null)
            {
               ((CAJ005TransferenciasMViewSmall)MViewReducido).BringToFront();
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.SaveChangesPreguntaPresenter, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  if (GuardarReducido(true))
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
         { ((CAJ005TransferenciasMView)MView).Close(); }
      }
      public void IsClosedMView()
      { isMViewShow = false; }

      private Boolean getAyuda(String x_procedure, ref List<Infrastructure.WinForms.Controls.ColumnaAyuda> _columnas, ref DataTable dtAyuda)
      {
         try
         {
            dtAyuda = new System.Data.DataTable();
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            //listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintMOVI_Codigo", FilterValue = F_MOVI_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
            //listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCUBA_Codigo", FilterValue = F_CUBA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });
            //listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintMOVI_NroOperacion", FilterValue = F_MOVI_NroOperacion, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
            //listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = F_ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
            //listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodMOV", FilterValue = F_TIPO_CodMOV, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });
            //listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIni", FilterValue = F_FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            //listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFin", FilterValue = F_FecFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

            dtAyuda = Client.GetAllMovimientoFilter(x_procedure, listFilters).ToDataTable();

            if (dtAyuda.Rows.Count == 0)
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias.");
               return false;
            }
            else
            {
               int i = 0;
               _columnas = new List<Infrastructure.WinForms.Controls.ColumnaAyuda>();
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "MOVI_Codigo",
                  ColumnCaption = "Código",
                  Alineacion = DataGridViewContentAlignment.MiddleCenter,
                  Width = 50,
                  DataType = typeof(System.String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "TIPO_MOV",
                  ColumnCaption = "Tipo Movimiento",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 120,
                  DataType = typeof(System.String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "ENTC_RazonSocial",
                  ColumnCaption = "Entidad",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 200,
                  DataType = typeof(System.String),
                  Format = null
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "CUBA_NroCuenta",
                  ColumnCaption = "Nro. Cuenta",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 100,
                  DataType = typeof(System.String),
                  Format = null
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "TIPO_MND",
                  ColumnCaption = "Moneda",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 100,
                  DataType = typeof(System.String),
                  Format = null
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "Monto",
                  ColumnCaption = "Monto",
                  Alineacion = DataGridViewContentAlignment.MiddleRight,
                  Width = 70,
                  DataType = typeof(System.String),
                  Format = null
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "Oficina_Operacion",
                  ColumnCaption = "Oficina / Operación",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 80,
                  DataType = typeof(System.String),
                  Format = null
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "NEstado",
                  ColumnCaption = "Estado",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 100,
                  DataType = typeof(System.String),
                  Format = null
               });
               return true;
            }
         }
         catch (Exception)
         { throw; }
      }

      #region Ingresos

      /// <summary>
      /// Cargar una ayuda de Ingresos para seleccion multiple
      /// </summary>
      /// <returns></returns>
      public Boolean NuevoIngresos()
      {
         try
         {
            CAJ002IngresosEgresosPresenter _movimiento = new CAJ002IngresosEgresosPresenter(ContainerService, TipoMovimientoCtaCte.Ingresos, CAJ002IngresosEgresosPresenter.TInicio.SoloMovimiento);
            _movimiento.Load();
            if (_movimiento.Nuevo() == DialogResult.OK)
            {
               Item.ListIngresos.Add(_movimiento.Item);
               return true;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      public Boolean EditarIngreso(ref Entities.Movimiento x_Movimiento)
      {
         try
         {
            CAJ002IngresosEgresosPresenter _movimiento = new CAJ002IngresosEgresosPresenter(ContainerService, TipoMovimientoCtaCte.Ingresos, CAJ002IngresosEgresosPresenter.TInicio.SoloMovimiento);
            _movimiento.Item = x_Movimiento;
            _movimiento.Load();
            if (_movimiento.EditarMovimiento() == DialogResult.OK)
            {
               return true;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      public Boolean EliminarIngresos(Entities.Movimiento _movimiento)
      {
         try
         {
            if (
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title,
                  "¿Desea eliminar el registro seleccionado?",
                  Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) ==
               System.Windows.Forms.DialogResult.Yes)
            {
               if (_movimiento.Instance != InstanceEntity.Added)
               { Item.ListIngresosEliminados.Add(_movimiento); }
               Item.ListIngresos.Remove(_movimiento);
               return true;
            }
            return false;
         }
         catch (Exception)
         {
            return false;
         }
      }

      #endregion

      #region Egresos

      /// <summary>
      /// Cargar una ayuda de movimiento de egresos para seleccion multiple
      /// </summary>
      /// <returns></returns>
      public Boolean NuevoEgresos()
      {
         try
         {
            CAJ002IngresosEgresosPresenter _movimiento = new CAJ002IngresosEgresosPresenter(ContainerService, TipoMovimientoCtaCte.Egresos, CAJ002IngresosEgresosPresenter.TInicio.SoloMovimiento);
            _movimiento.Load();
            if (_movimiento.Nuevo() == DialogResult.OK)
            {
               Item.ListEgresos.Add(_movimiento.Item);
               return true;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      public Boolean EditarEgreso(ref Entities.Movimiento x_Movimiento)
      {
         try
         {
            CAJ002IngresosEgresosPresenter _movimiento = new CAJ002IngresosEgresosPresenter(ContainerService, TipoMovimientoCtaCte.Egresos, CAJ002IngresosEgresosPresenter.TInicio.SoloMovimiento);
            _movimiento.Item = x_Movimiento;
            _movimiento.Load();
            if (_movimiento.EditarMovimiento() == DialogResult.OK)
            {
               return true;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      public Boolean EliminarEgresos(Entities.Movimiento _movimiento)
      {
         try
         {
            if (
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title,
                  "¿Desea eliminar el registro seleccionado?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) ==
               System.Windows.Forms.DialogResult.Yes)
            {
               if (_movimiento.Instance != InstanceEntity.Added)
               { Item.ListEgresosEliminados.Add(_movimiento); }
               Item.ListEgresos.Remove(_movimiento);
               return true;
            }
            return false;
         }
         catch (Exception)
         { return false; }
      }

      #endregion

      #region Gastos Bancarios

      /// <summary>
      /// Agregar un registro en el Gasto bancario
      /// </summary>
      /// <returns></returns>
      public Boolean NuevoGastoBancario()
      {
         try
         {
            CAJ005TransferenciasGView GView = new CAJ005TransferenciasGView();
            GView.Presenter = this;
            GView.Item = new GastosBancarios();
            GView.Item.GBAN_Estado = "I";
            if (Item.ListGastosBancarios.Count > 0)
            { GView.Item.GBAN_Codigo = Item.ListGastosBancarios.Max(GBan => GBan.GBAN_Codigo) + 1; }
            else { GView.Item.GBAN_Codigo = 1; }
            GView.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            GView.LoadView();
            GView.StartPosition = FormStartPosition.CenterScreen;
            if (GView.ShowDialog() == DialogResult.OK)
            {
               Item.ListGastosBancarios.Add(GView.Item);
               return true;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      public Boolean EditarGastoBancarios(ref Entities.GastosBancarios x_GastoBancario)
      {
         try
         {
            CAJ005TransferenciasGView GView = new CAJ005TransferenciasGView();
            GView.Presenter = this;
            GView.Item = x_GastoBancario;
            GView.LoadView();
            GView.StartPosition = FormStartPosition.CenterScreen;
            if (GView.ShowDialog() == DialogResult.OK)
            {
               return true;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      public Boolean EliminarGastosBancarios(Entities.GastosBancarios _gastosBancarios)
      {
         try
         {
            if (
              Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title,
                 "¿Desea eliminar el registro seleccionado?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) ==
              System.Windows.Forms.DialogResult.Yes)
            {
               if (_gastosBancarios.Instance != InstanceEntity.Added)
               { Item.ListGastosBancariosEliminados.Add(_gastosBancarios); }
               Item.ListGastosBancarios.Remove(_gastosBancarios);
               return true;
            }
            return false;
         }
         catch (Exception)
         { return false; }
      }

      #endregion

      #endregion

      #region [ Metodos Eventos/Tareas ]

      #endregion
   }
}