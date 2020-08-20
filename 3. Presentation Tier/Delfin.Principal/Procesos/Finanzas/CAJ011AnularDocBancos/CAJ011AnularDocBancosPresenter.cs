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
   public partial class CAJ011AnularDocBancosPresenter
   {
      #region [ Variables ]
      public String Title = " Documentos Bancarios";
      public String CUS = "CAJ011";
      public Boolean FleteNegativo = false;
      #endregion

      #region [ Contrusctor ]

      public CAJ011AnularDocBancosPresenter(IUnityContainer x_container, ICAJ011AnularDocBancosLView x_lview)
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

      public ICAJ011AnularDocBancosLView LView { get; set; }

      public Movimiento Item { get; set; }
      public ObservableCollection<Movimiento> Items { get; set; }
      public DateTime Fecha { get; set; }

      #endregion

      #region [ Metodos ]

      public DateTime? F_FecIni { get; set; }
      public DateTime? F_FecFin { get; set; }
      public String F_CUBA_Codigo { get; set; }

      public void Actualizar()
      {
         try
         {
            Item = null;
            Items = null;

            if (LView != null)
            {
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCUBA_Codigo", FilterValue = F_CUBA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIni", FilterValue = F_FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFin", FilterValue = F_FecFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

               Items = Client.GetAllMovimientoFilter("CAJ_MOVISS_Todos", _listFilters);
               LView.ShowItems();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      Boolean isMViewShow = false;

      public void Eliminar()
      {
         try
         {
            if (Item != null)
            {
               //System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               //if (_result == System.Windows.Forms.DialogResult.Yes)
               //{
               //   Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
               //   Item = Client.SaveCab_Cotizacion_OV(Item);
               //   if (Item != null)
               //   {
               //      Actualizar();
               //      Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
               //   }
               //   else
               //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item."); }
               //}
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex); }
      }

      /// <summary>
      /// Anular registros
      /// </summary>
      public void Anular()
      {
         try
         {
             if (!Item.CONS_CodEST.Equals(Entities.Movimiento.GetEstado(Entities.Movimiento.Estado.Anulado)) && !Item.CONS_CodEST.Equals(Entities.Movimiento.GetEstado(Entities.Movimiento.Estado.Extornado)) && !Item.Extornado)
            {
               String _dialogo = "¿Desea Anular el registro seleccionado?";
               if (Item.Diferido)
               {
                  //if (!Item.Ejecutado)
                  //{
                  //   Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Anular"+Title, "No se puede Anular un movimiento diferido que no fue ejecutado.");
                  //   return;
                  //}
                  _dialogo = "¿Desea Anular el registro diferido seleccionado?";
               }
               if (Item.ChequeEnBlanco)
               {
                   Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Anular" + Title, "No se puede Anular un cheque en blanco.");
                  return;
               }
               if (Item.Transferencia) { _dialogo = "El registro seleccionado pertenece a una transferencia, ¿Desea Anular todos los registros pertenecientes a las transferencia?"; }

               if (
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta("Anular" + Title, _dialogo, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
               {
                  MotivoAnulacion _motivoAnulacion = new MotivoAnulacion() { StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen };
                  DateTime _fecha = Fecha;
                  if (_motivoAnulacion.LoadControl(_fecha, Session.UserName) == System.Windows.Forms.DialogResult.OK)
                  {
                     Entities.Movimiento _movimiento = new Movimiento();
                     _movimiento.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                     _movimiento.MOVI_Codigo = Item.MOVI_Codigo;
                     _movimiento.TIPO_TabMOV = Item.TIPO_TabMOV;
                     _movimiento.TIPO_CodMOV = Item.TIPO_CodMOV;
                     _movimiento.MOVI_FecAnulacion = _fecha;
                     _movimiento.MOVI_GlosaAnulacion = _motivoAnulacion.Observacion;
                     _movimiento.MOVI_UserAnulacion = Session.UserName;
                     _movimiento.AUDI_UsrMod = Session.UserName;
                     _movimiento.Transferencia = Item.Transferencia;
                     _movimiento.Diferido = Item.Diferido;
                     _movimiento.Ejecutado = Item.Ejecutado;
                     _movimiento.ChequeEnBlanco = Item.ChequeEnBlanco;

                     if (Client.SaveMovimiento(ref _movimiento, Movimiento.TInterfazMovimiento.Anular))
                     {
                         Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio("Anular" + Title, "Se Anulo el registro Satisfactoriamente.");
                        Actualizar();
                     }
                  }
               }
            }
            else
            {
               String _tipo = "";
               if (Item.CONS_CodEST.Equals(Entities.Movimiento.GetEstado(Entities.Movimiento.Estado.Anulado))) { _tipo += "Anulado"; }
               if (Item.CONS_CodEST.Equals(Entities.Movimiento.GetEstado(Entities.Movimiento.Estado.Extornado))) { _tipo += "Extorado"; }
               if (Item.Extornado) { _tipo += "Extornado"; }
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Anular" + Title, String.Format("NO puede anular un registro ya {0}.", _tipo));
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError("Anular" + Title, "Ha ocurrido un error anulando.", ex); }
      }

      /// <summary>
      /// Anular registros
      /// </summary>
      public void Extornar()
      {
         try
         {
            if (!Item.CONS_CodEST.Equals(Entities.Movimiento.GetEstado(Entities.Movimiento.Estado.Anulado)) && !Item.CONS_CodEST.Equals(Entities.Movimiento.GetEstado(Entities.Movimiento.Estado.Extornado)) && !Item.Extornado)
            {
               String _dialogo = "¿Desea Extornar el registro seleccionado?";
               if (Item.Diferido)
               {
                  if (!Item.Ejecutado)
                  {
                      Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Extornar" + Title, "No se puede Extornar un movimiento diferido que no fue ejecutado.");
                     return;
                  }
                  _dialogo = "¿Desea Extornar el registro diferido seleccionado?";
               }
               if (Item.ChequeEnBlanco)
               {
                   Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Extornar" + Title, "No se puede Extornar un cheque en blanco.");
                  return;
               }
               if (Item.Transferencia) { _dialogo = "El registro seleccionado pertenece a una transferencia, ¿Desea extornar todos los registros pertenecientes a las transferencia?"; }

               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta("Extornar" + Title, _dialogo, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
               {
                  CAJ011AnularDocBancosFView fview = new CAJ011AnularDocBancosFView() { Item = this.Item, Presenter = this };
                  fview.LoadView();
                  fview.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                  if (fview.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                  {
                     Entities.Movimiento _movimiento = new Movimiento();
                     _movimiento = Item;
                     _movimiento.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                     _movimiento.MOVI_Codigo = Item.MOVI_Codigo;
                     _movimiento.TIPO_TabMOV = Item.TIPO_TabMOV;
                     _movimiento.MOVI_FecEmision = fview.Fecha; ;
                     _movimiento.TIPO_Movimiento = Client.GetOneTipos(Item.TIPO_TabMOV, Item.TIPO_CodMOV);
                     _movimiento.Transferencia = Item.Transferencia;
                     _movimiento.Diferido = Item.Diferido;
                     _movimiento.Ejecutado = Item.Ejecutado;
                     _movimiento.ChequeEnBlanco = Item.ChequeEnBlanco;
                     if (_movimiento.TIPO_Movimiento.TIPO_Desc2.Equals("I"))
                     { _movimiento.SetTipoMovimiento(Movimiento.TipoMovimiento.IngresosExtorno); }
                     else { _movimiento.SetTipoMovimiento(Movimiento.TipoMovimiento.EgresosExtorno); }

                     _movimiento.AUDI_UsrCrea = Session.UserName;

                     if (Client.SaveMovimiento(ref _movimiento, Movimiento.TInterfazMovimiento.Extornar))
                     {
                         Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio("Extornar" + Title, "Se Extorno el registro Satisfactoriamente.");
                        Actualizar();
                     }
                  }
               }
            }
            else
            {
               String _tipo = "";
               if (Item.CONS_CodEST.Equals(Entities.Movimiento.GetEstado(Entities.Movimiento.Estado.Anulado))) { _tipo += "Anulado"; }
               if (Item.CONS_CodEST.Equals(Entities.Movimiento.GetEstado(Entities.Movimiento.Estado.Extornado))) { _tipo += "Extorado"; }
               if (Item.Extornado) {_tipo += "Extornado";}
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Extornar" +  Title, String.Format("NO puede Extornar un registro ya {0}.", _tipo));
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError("Extornar" + Title, "Ha ocurrido un error anulando.", ex); }
      }

      public void CloseView()
      {
         //if (isMViewShow)
         //{ ((CAJ011AnularDocBancosMView)MView).Close(); }
      }

      public void IsClosedMView()
      { isMViewShow = false; }

      #endregion

      #region [ Metodos Eventos/Tareas ]

      #endregion
   }
}