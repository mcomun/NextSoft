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
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using Infrastructure.Aspect.DataAccess;

namespace Delfin.Principal
{
   public class COM006Presenter
   {
      #region [ Variables ]
      public String Title = "Tarifario";
      public String CUS = "COM006";
      #endregion

      #region [ Propiedades BussinessLogic ]

      #endregion

      #region [ Contrusctor ]
      public COM006Presenter(IUnityContainer x_container, ICOM006LView x_lview, ICOM006MView x_mview, ICOM006DView x_dview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
            this.MView = x_mview;
            this.DView = x_dview;

            CView = new COM006CView();
            CView.Presenter = this;

            EsCopia = false;
         }
         catch (Exception)
         { throw; }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();

            ListMonedas = Client.GetAllTiposByTipoCodTabla("MND");
            ListPaquetes = Client.GetAllPaquete();
            ListPaises = Client.GetAllTiposByTipoCodTabla("PAI");
            ListPuertos = Client.GetAllPuerto();

            LView.LoadView();
            MView.LoadView();
            DView.LoadView();
            CView.LoadView();

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]

      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }

      public IDelfinServices Client { get; set; }

      public ICOM006LView LView { get; set; }
      public ICOM006MView MView { get; set; }
      public ICOM006DView DView { get; set; }
      public ICOM006CView CView { get; set; }

      public Contrato Item { get; set; }
      public Contrato ItemCopia { get; set; }
      public ObservableCollection<Contrato> Items { get; set; }

      public ObservableCollection<Tarifa> ItemsTarifa { get; set; }

      public Tarifa ItemTarifa { get; set; }
      public ObservableCollection<Tipos> ListMonedas { get; set; }
      public ObservableCollection<Paquete> ListPaquetes { get; set; }
      public ObservableCollection<Tipos> ListPaises { get; set; }
      public ObservableCollection<Puerto> ListPuertos { get; set; }

      public Boolean EsCopia { get; set; }
      #endregion

      #region [ Metodos ]
      public Int32? ENTC_CodTransportista;
      public DateTime? CONT_FecDesde;
      public DateTime? CONT_FecHasta;
      public void Actualizar(Int32? x_ENTC_CodTransportista, DateTime? x_CONT_FecDesde, DateTime? x_CONT_FecHasta, Boolean CONT_Activo)
      {
         try
         {
            Item = null;
            Items = null;


            if (x_CONT_FecDesde.HasValue && x_CONT_FecHasta.HasValue)
            {
               ENTC_CodTransportista = x_ENTC_CodTransportista;
               CONT_FecDesde = x_CONT_FecDesde;
               CONT_FecHasta = x_CONT_FecHasta;

               Items = Client.GetAllContratoByFiltro(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, ENTC_CodTransportista, CONT_FecDesde, CONT_FecHasta, CONT_Activo);
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar las fechas Desde y Hasta."); }

            LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      public Tipos ItemTipoMND;
      public Paquete ItemPaquete;
      public Tipos ItemTipoPAIOrigen;
      public Puerto ItemPuertoOrigen;
      public Tipos ItemTipoPAIDestino;
      public Puerto ItemPuertoDestino;
      public void LoadTarifas(Tipos x_ItemTipoMND, Paquete x_ItemPaquete, Tipos x_ItemTipoPAIOrigen, Puerto x_ItemPuertoOrigen, Tipos x_ItemTipoPAIDestino, Puerto x_ItemPuertoDestino)
      {
         try
         {


            ItemTipoMND = x_ItemTipoMND;
            ItemPaquete = x_ItemPaquete;
            ItemTipoPAIOrigen = x_ItemTipoPAIOrigen;
            ItemPuertoOrigen = x_ItemPuertoOrigen;
            ItemTipoPAIDestino = x_ItemTipoPAIDestino;
            ItemPuertoDestino = x_ItemPuertoDestino;

            MView.GetItem(false);
            Item.TIPO_CodMNDOK = true;
            Item.TIPO_CodMNDMSGERROR = "";
            Item.PUER_CodOrigenOK = true;
            Item.PUER_CodOrigenMSGERROR = "";
            Item.PUER_CodDestinoOK = true;
            Item.PUER_CodDestinoMSGERROR = "";
            if (Item.Validar())
            {
               if (ItemTipoMND == null)
               {
                  Item.TIPO_CodMNDOK = false;
                  Item.TIPO_CodMNDMSGERROR = String.Format("Debe ingresar la {0} de la {1}.", "Moneda", "Tarifa"); ;
                  //Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar una moneda.");
                  MView.ShowValidation();
                  return;
               }

               Nullable<Int32> CONT_Codigo = Item.CONT_Codigo;
               String CONS_TabRGM = Item.CONS_TapRGM;
               String CONS_CodRGM = Item.CONS_CodRGM;
               String CONS_TabVIA = Item.CONS_TapVia;
               String CONS_CodVIA = Item.CONS_CodVia;
               String TIPO_TabMND = ItemTipoMND.TIPO_CodTabla;
               String TIPO_CodMND = ItemTipoMND.TIPO_CodTipo;
               Nullable<Int32> PACK_Codigo = null; if (ItemPaquete != null) { PACK_Codigo = ItemPaquete.PACK_Codigo; }
               String TIPO_TabPAI = null;
               String TIPO_CodPAI = null;
               Nullable<Int32> PUER_Codigo = null;

               if (Item.CONS_CodRGM == Controls.variables.CONSRGM_Importacion)
               {
                  if (ItemPuertoDestino == null)
                  {
                     Item.PUER_CodDestinoOK = false;
                     Item.PUER_CodDestinoMSGERROR = String.Format("Debe ingresar el {0} de la {1}.", "Puerto Destino", "Tarifa");
                     //Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un puerto de Destino.");
                     MView.ShowValidation();
                     return;
                  }
                  if (ItemTipoPAIOrigen != null)
                  {
                     TIPO_TabPAI = ItemTipoPAIOrigen.TIPO_CodTabla;
                     TIPO_CodPAI = ItemTipoPAIOrigen.TIPO_CodTipo;
                  }
                  if (ItemPuertoDestino != null) { PUER_Codigo = ItemPuertoDestino.PUER_Codigo; };
               }
               else if (Item.CONS_CodRGM == Controls.variables.CONSRGM_Exportacion)
               {
                  if (ItemPuertoOrigen == null)
                  {
                     Item.PUER_CodOrigenOK = false;
                     Item.PUER_CodOrigenMSGERROR = String.Format("Debe ingresar el {0} de la {1}.", "Puerto Origen", "Tarifa");
                     //Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un puerto de Origen.");
                     MView.ShowValidation();
                     return;
                  }

                  if (ItemTipoPAIDestino != null)
                  {
                     TIPO_TabPAI = ItemTipoPAIDestino.TIPO_CodTabla;
                     TIPO_CodPAI = ItemTipoPAIDestino.TIPO_CodTipo;
                  }
                  if (ItemTipoPAIOrigen != null) { PUER_Codigo = ItemPuertoOrigen.PUER_Codigo; };
               }

               System.Data.DataTable DTImportacion = Client.GetAllTarifaByContrato(CONT_Codigo, CONS_TabRGM, CONS_CodRGM, CONS_TabVIA, CONS_CodVIA, TIPO_TabMND, TIPO_CodMND, PACK_Codigo, TIPO_TabPAI, TIPO_CodPAI, PUER_Codigo);
               MView.ShowTarifas(DTImportacion);
            }
            else
            { MView.ShowValidation(); }
         }
         catch (Exception)
         { throw; }
      }

      public void Importar(Tipos x_ItemTipoMND, Paquete x_ItemPaquete, Tipos x_ItemTipoPAIOrigen, Puerto x_ItemPuertoOrigen, Tipos x_ItemTipoPAIDestino, Puerto x_ItemPuertoDestino, String x_IMPO_Ruta, Decimal x_TARI_ValorAdicionar)
      {
         try
         {
            ItemTipoMND = x_ItemTipoMND;
            ItemPaquete = x_ItemPaquete;
            ItemTipoPAIOrigen = x_ItemTipoPAIOrigen;
            ItemPuertoOrigen = x_ItemPuertoOrigen;
            ItemTipoPAIDestino = x_ItemTipoPAIDestino;
            ItemPuertoDestino = x_ItemPuertoDestino;

            MView.GetItem(false);
            Item.TIPO_CodMNDOK = true;
            Item.TIPO_CodMNDMSGERROR = "";
            Item.PUER_CodOrigenOK = true;
            Item.PUER_CodOrigenMSGERROR = "";
            Item.PUER_CodDestinoOK = true;
            Item.PUER_CodDestinoMSGERROR = "";
            if (Item.Validar())
            {
               if (ItemTipoMND == null)
               {
                  Item.TIPO_CodMNDOK = false;
                  Item.TIPO_CodMNDMSGERROR = String.Format("Debe ingresar la {0} de la {1}.", "Moneda", "Tarifa"); ;
                  MView.ShowValidation();
                  return;
               }

               Nullable<Int32> CONT_Codigo = Item.CONT_Codigo;
               String CONS_TabRGM = Item.CONS_TapRGM;
               String CONS_CodRGM = Item.CONS_CodRGM;
               String CONS_TabVIA = Item.CONS_TapVia;
               String CONS_CodVIA = Item.CONS_CodVia;
               String TIPO_TabMND = ItemTipoMND.TIPO_CodTabla;
               String TIPO_CodMND = ItemTipoMND.TIPO_CodTipo;
               Nullable<Int32> PACK_Codigo = null; if (ItemPaquete != null) { PACK_Codigo = ItemPaquete.PACK_Codigo; }
               String TIPO_TabPAI = null;
               String TIPO_CodPAI = null;
               Nullable<Int32> PUER_Codigo = null;

               if (Item.CONS_CodRGM == Controls.variables.CONSRGM_Importacion)
               {
                  if (ItemPuertoDestino == null)
                  {
                     Item.PUER_CodDestinoOK = false;
                     Item.PUER_CodDestinoMSGERROR = String.Format("Debe ingresar el {0} de la {1}.", "Puerto Destino", "Tarifa");
                     MView.ShowValidation();
                     return;
                  }

                  if (ItemTipoPAIOrigen != null)
                  {
                     TIPO_TabPAI = ItemTipoPAIOrigen.TIPO_CodTabla;
                     TIPO_CodPAI = ItemTipoPAIOrigen.TIPO_CodTipo;
                  }
                  if (ItemPuertoDestino != null) { PUER_Codigo = ItemPuertoDestino.PUER_Codigo; };
               }
               else if (Item.CONS_CodRGM == Controls.variables.CONSRGM_Exportacion)
               {
                  if (ItemPuertoOrigen == null)
                  {
                     Item.PUER_CodOrigenOK = false;
                     Item.PUER_CodOrigenMSGERROR = String.Format("Debe ingresar el {0} de la {1}.", "Puerto Origen", "Tarifa");
                     MView.ShowValidation();
                     return;
                  }

                  if (ItemTipoPAIDestino != null)
                  {
                     TIPO_TabPAI = ItemTipoPAIDestino.TIPO_CodTabla;
                     TIPO_CodPAI = ItemTipoPAIDestino.TIPO_CodTipo;
                  }
                  if (ItemTipoPAIOrigen != null) { PUER_Codigo = ItemPuertoOrigen.PUER_Codigo; };
               }


               String ErrorMessage = "";
               ImportarExcel excel = new ImportarExcel();
               DataTable DTImportacion = excel.ReadExcel(x_IMPO_Ruta, ref ErrorMessage);

               if (DTImportacion != null && DTImportacion.Rows.Count > 0)
               {
                  for (int indexColumn = 2; indexColumn < DTImportacion.Columns.Count; indexColumn++)
                  {
                     String _PACK_DescC = DTImportacion.Columns[indexColumn].ColumnName;

                     Paquete _itemPaquete = ListPaquetes.Where(pack => pack.PACK_DescC == _PACK_DescC).FirstOrDefault();
                     if (_itemPaquete != null)
                     { DTImportacion.Columns[indexColumn].ColumnName = String.Format("{0}#{1}", _itemPaquete.PACK_Codigo, _itemPaquete.PACK_Desc); }
                     else
                     {
                        ErrorMessage += "* No se encontro el paquete: " + _PACK_DescC + Environment.NewLine;
                        DTImportacion.Columns.RemoveAt(indexColumn); indexColumn -= 1;
                     }
                  }

                  for (int indexRow = 0; indexRow < DTImportacion.Rows.Count; indexRow++)
                  {
                     String _PUER_CodAlterno = DTImportacion.Rows[indexRow][0].ToString();

                     Puerto _itemPuerto = ListPuertos.Where(puer => puer.PUER_CodEstandar.Trim() == _PUER_CodAlterno.Trim() && puer.CONS_CodVia == Item.CONS_CodVia).FirstOrDefault();
                     if (_itemPuerto != null)
                     { DTImportacion.Rows[indexRow][1] = String.Format("{0}#{1}", _itemPuerto.PUER_Codigo, _itemPuerto.PUER_Nombre); }
                     else
                     {
                        ErrorMessage += "* No se encontro el puerto: " + _PUER_CodAlterno + Environment.NewLine;
                        DTImportacion.Rows.RemoveAt(indexRow); indexRow -= 1;
                     }
                  }

                  for (int indexRow = 0; indexRow < DTImportacion.Rows.Count; indexRow++)
                  {
                     for (int indexColumn = 2; indexColumn < DTImportacion.Columns.Count; indexColumn++)
                     {
                        if (DTImportacion.Rows[indexRow][indexColumn] != DBNull.Value)
                        {
                           Decimal _TARI_Costo = (Decimal)0.00;
                           if (Decimal.TryParse(DTImportacion.Rows[indexRow][indexColumn].ToString(), out _TARI_Costo))
                           { DTImportacion.Rows[indexRow][indexColumn] = String.Format("-1#{0}", (_TARI_Costo + x_TARI_ValorAdicionar)); }
                           else
                           { DTImportacion.Rows[indexRow][indexColumn] = String.Format("-1#{0}", 0.00); }
                        }
                        else
                        { DTImportacion.Rows[indexRow][indexColumn] = String.Format("-1#{0}", ""); }
                     }
                  }

                  DTImportacion.Columns[1].ColumnName = "PUER_Nombre";
                  DTImportacion.Columns.RemoveAt(0);

                  if (!String.IsNullOrEmpty(ErrorMessage))
                  {
                     ErrorMessage = "Se han encontrado las siguientes incidencias:" + Environment.NewLine + ErrorMessage;
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Algunos Embalajes o Puertos no han sido encontrados.", ErrorMessage);
                  }

                  MView.ShowTarifas(DTImportacion);
                  Guardar(true, false);
               }


            }
            else
            { MView.ShowValidation(); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error en el proceso de importación.", ex); }
      }

      public Entidad GetEntidad(Int32 ENTC_Codigo, Nullable<Int16> TIPE_Codigo)
      {
         try
         { return Client.GetOneEntidad(ENTC_Codigo, TIPE_Codigo); }
         catch (Exception)
         { return null; }
      }

      public void Nuevo()
      {
         try
         {
            MView.ClearItem();
            this.Item = new Contrato();
            this.Item.CONT_FecEmi = Session.Fecha;
            this.Item.AUDI_UsrCrea = Session.UserName;
            this.Item.AUDI_FecCrea = Session.Fecha;
            this.Item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            MView.SetItem();
            MView.EnableItem(true, true);

            ((COM006MView)MView).ShowDialog();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }
      //public void Copiar()
      //{
      //   try
      //   {
      //      if (Item != null && Item.CONT_Codigo.HasValue)
      //      {
      //         Item = Client.GetOneContratoCopy(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Item.CONT_Codigo.Value, Session.UserName);

      //         if (Item != null)
      //         {
      //            EsCopia = true;

      //            MView.ClearItem();
      //            this.Item.AUDI_UsrMod = Session.UserName;
      //            this.Item.AUDI_FecMod = Session.Fecha;
      //            this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
      //            MView.SetItem();

      //            LoadTarifas(ItemTipoMND, ItemPaquete, ItemTipoPAIOrigen, ItemPuertoOrigen, ItemTipoPAIDestino, ItemPuertoDestino);

      //            MView.EnableItem(false, true);

      //            ((COM006MView)MView).ShowDialog();
      //         }
      //         else
      //         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
      //      }
      //      else
      //      { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      //}
      public void Editar()
      {
         try
         {
            String _TIPO_TabPaisOrigen = Item.TIPO_TabPaisOrigen;
            String _TIPO_CodPaisOrigen = Item.TIPO_CodPaisOrigen;
            Nullable<Int32> _PUER_CodigoOrigen = Item.PUER_CodigoOrigen;
            String _TIPO_TabPaisDestino = Item.TIPO_TabPaisDestino;
            String _TIPO_CodPaisDestino = Item.TIPO_CodPaisDestino;
            Nullable<Int32> _PUER_CodigoDestino = Item.PUER_CodigoDestino;

            if (Item != null && Item.CONT_Codigo.HasValue)
            {
               Item = Client.GetOneContrato(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Item.CONT_Codigo.Value);
               Item.TIPO_TabPaisOrigen = _TIPO_TabPaisOrigen;
               Item.TIPO_CodPaisOrigen = _TIPO_CodPaisOrigen;
               Item.PUER_CodigoOrigen = _PUER_CodigoOrigen;
               Item.TIPO_TabPaisDestino = _TIPO_TabPaisDestino;
               Item.TIPO_CodPaisDestino = _TIPO_CodPaisDestino;
               Item.PUER_CodigoDestino = _PUER_CodigoDestino;

               if (Item != null)
               {
                  ItemTipoMND = ListMonedas.Where(tmnd => tmnd.TIPO_CodTabla == Item.TIPO_TabMND && tmnd.TIPO_CodTipo == Item.TIPO_CodMND).FirstOrDefault();
                  ItemTipoPAIOrigen = ListPaises.Where(tmnd => tmnd.TIPO_CodTabla == Item.TIPO_TabPaisOrigen && tmnd.TIPO_CodTipo == Item.TIPO_CodPaisOrigen).FirstOrDefault();
                  ItemPuertoOrigen = ListPuertos.Where(puer => puer.PUER_Codigo == Item.PUER_CodigoOrigen).FirstOrDefault();
                  ItemTipoPAIDestino = ListPaises.Where(tmnd => tmnd.TIPO_CodTabla == Item.TIPO_TabPaisDestino && tmnd.TIPO_CodTipo == Item.TIPO_CodPaisDestino).FirstOrDefault();
                  ItemPuertoDestino = ListPuertos.Where(puer => puer.PUER_Codigo == Item.PUER_CodigoDestino).FirstOrDefault();

                  MView.ClearItem();
                  this.Item.AUDI_UsrMod = Session.UserName;
                  this.Item.AUDI_FecMod = Session.Fecha;
                  this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                  MView.SetItem();

                  LoadTarifas(ItemTipoMND, ItemPaquete, ItemTipoPAIOrigen, ItemPuertoOrigen, ItemTipoPAIDestino, ItemPuertoDestino);

                  MView.EnableItem(false, false);

                  ((COM006MView)MView).ShowDialog();
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }
      public void Eliminar(Boolean CONT_Activo)
      {
         try
         {
            if (Item != null)
            {
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                  if (Client.SaveContrato(Item, false) > 0)
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                     Actualizar(ENTC_CodTransportista, CONT_FecDesde, CONT_FecHasta, CONT_Activo);
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se ha podido eliminar el item debido a que ya se encuentra relacionado."); }
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex); }
      }
      public void Copiar()
      {
         try
         {

            String _TIPO_TabPaisOrigen = null; if (ItemPuertoOrigen != null) { _TIPO_TabPaisOrigen = ItemPuertoOrigen.TIPO_TabPais; }
            String _TIPO_CodPaisOrigen = null; if (ItemPuertoOrigen != null) { _TIPO_CodPaisOrigen = ItemPuertoOrigen.TIPO_CodPais; }
            Nullable<Int32> _PUER_CodigoOrigen = null; if (ItemPuertoOrigen != null) { _PUER_CodigoOrigen = ItemPuertoOrigen.PUER_Codigo; }
            String _TIPO_TabPaisDestino = null; if (ItemPuertoDestino != null) { _TIPO_TabPaisDestino = ItemPuertoDestino.TIPO_TabPais; }
            String _TIPO_CodPaisDestino = null; if (ItemPuertoDestino != null) { _TIPO_CodPaisDestino = ItemPuertoDestino.TIPO_CodPais; }
            Nullable<Int32> _PUER_CodigoDestino = null; if (ItemPuertoDestino != null) { _PUER_CodigoDestino = ItemPuertoDestino.PUER_Codigo; }

            if (Item != null && Item.CONT_Codigo.HasValue)
            {
               Item = Client.GetOneContrato(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Item.CONT_Codigo.Value);
               Item.TIPO_TabPaisOrigen = _TIPO_TabPaisOrigen;
               Item.TIPO_CodPaisOrigen = _TIPO_CodPaisOrigen;
               Item.PUER_CodigoOrigen = _PUER_CodigoOrigen;
               Item.TIPO_TabPaisDestino = _TIPO_TabPaisDestino;
               Item.TIPO_CodPaisDestino = _TIPO_CodPaisDestino;
               Item.PUER_CodigoDestino = _PUER_CodigoDestino;

               if (Item != null)
               {
                  //ItemTipoMND = ListMonedas.Where(tmnd => tmnd.TIPO_CodTabla == Item.TIPO_TabMND && tmnd.TIPO_CodTipo == Item.TIPO_CodMND).FirstOrDefault();
                  //ItemTipoPAIOrigen = ListPaises.Where(tmnd => tmnd.TIPO_CodTabla == Item.TIPO_TabPaisOrigen && tmnd.TIPO_CodTipo == Item.TIPO_CodPaisOrigen).FirstOrDefault();
                  //ItemPuertoOrigen = ListPuertos.Where(puer => puer.PUER_Codigo == Item.PUER_CodigoOrigen).FirstOrDefault();
                  //ItemTipoPAIDestino = ListPaises.Where(tmnd => tmnd.TIPO_CodTabla == Item.TIPO_TabPaisDestino && tmnd.TIPO_CodTipo == Item.TIPO_CodPaisDestino).FirstOrDefault();
                  //ItemPuertoDestino = ListPuertos.Where(puer => puer.PUER_Codigo == Item.PUER_CodigoDestino).FirstOrDefault();

                  CView.ClearItem();
                  ItemCopia = new Contrato();
                  ItemCopia.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                  ItemCopia.AUDI_UsrCrea = Session.UserName;
                  ItemCopia.AUDI_FecCrea = Session.Fecha;
                  ItemCopia.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                  CView.SetItem();

                  //LoadTarifas(ItemTipoMND, ItemPaquete, ItemTipoPAIOrigen, ItemPuertoOrigen, ItemTipoPAIDestino, ItemPuertoDestino);

                  //CView.EnableItem(false, false);

                  ((COM006CView)CView).ShowDialog();
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }

      String MensajeErrorTarifa = "";
      public Boolean ValidarTarifario(Boolean Cerrar)
      {
         try
         {
            Boolean _isCorrect = true;
            MensajeErrorTarifa = "";
            if (Cerrar)
            {
               if (Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
               {
                  foreach (Tarifa itemTarifa in Item.ListTarifa)
                  {
                     if (!itemTarifa.ValidarProfit())
                     {
                        _isCorrect = false;
                        Puerto _puerto = ListPuertos.Where(puer => puer.PUER_Codigo == itemTarifa.PUER_CodOrigen).FirstOrDefault();
                        Paquete _paquete = ListPaquetes.Where(pack => pack.PACK_Codigo == itemTarifa.PACK_Codigo).FirstOrDefault();
                        String _puer_nombre = _puerto != null ? _puerto.PUER_Nombre : "";
                        String _pack_desc = _paquete != null ? _paquete.PACK_Desc : "";
                        MensajeErrorTarifa += String.Format("Tarifa del Puerto {0} y Embalaje {1}", _puer_nombre, _pack_desc) + Environment.NewLine + itemTarifa.MensajeError;
                     }
                  }
               }
               else
               {
                  foreach (Tarifa itemTarifa in Item.ListTarifa)
                  {
                     if (!itemTarifa.Validar())
                     {
                        _isCorrect = false;
                        Puerto _puerto = ListPuertos.Where(puer => puer.PUER_Codigo == itemTarifa.PUER_CodDestino).FirstOrDefault();
                        Paquete _paquete = ListPaquetes.Where(pack => pack.PACK_Codigo == itemTarifa.PACK_Codigo).FirstOrDefault();
                        String _puer_nombre = _puerto != null ? _puerto.PUER_Nombre : "";
                        String _pack_desc = _paquete != null ? _paquete.PACK_Desc : "";
                        MensajeErrorTarifa += String.Format("Tarifa del Puerto {0} y Embalaje {1}", _puer_nombre, _pack_desc) + Environment.NewLine + itemTarifa.MensajeError;
                     }
                  }
               }
            }
            return _isCorrect;
         }
         catch (Exception ex)
         { throw ex; }
      }
      public bool Guardar(Boolean Tarifario, Boolean Cerrar)
      {
         try
         {
            MView.GetItem(Tarifario);
            if (Item.Validar())
            {
               if (ValidarTarifario(Cerrar))
               {
                  if (Client.GetOneContratoValidacion((Item.CONT_Codigo.HasValue ? Item.CONT_Codigo.Value : -1), Item.CONT_Numero, Item.CONT_FecIni.Value, Item.CONT_FecFin.Value))
                  {
                     Int32 _CONT_Codigo = Client.SaveContrato(Item, Tarifario);
                     if (_CONT_Codigo > 0)
                     {
                        EsCopia = false;

                        Item.CONT_Codigo = _CONT_Codigo;
                        Item = Client.GetOneContrato(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Item.CONT_Codigo.Value);

                        Item.AUDI_UsrMod = Session.UserName;
                        Item.AUDI_FecMod = Session.Fecha;
                        Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                        if (Tarifario) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente"); }
                        if (Tarifario) { LoadTarifas(ItemTipoMND, ItemPaquete, ItemTipoPAIOrigen, ItemPuertoOrigen, ItemTipoPAIDestino, ItemPuertoDestino); }
                        if (Cerrar) { Actualizar(ENTC_CodTransportista, CONT_FecDesde, CONT_FecHasta, true); }

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
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Existe un contrato con el mismo Número y el Rango de Fechas que se cruzan.");
                     return false;
                  }
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Existe algunos errores en las Tarfias.", MensajeErrorTarifa);
                  return false;
               }
            }
            else
            {
               MView.ShowValidation();
               return false;
            }
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
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.SaveChangesPreguntaPresenter, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  if (Guardar(true, true))
                  { return System.Windows.Forms.DialogResult.Yes; }
                  else
                  { return System.Windows.Forms.DialogResult.Cancel; }
               }
               else
               {
                  if (EsCopia)
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe guardar los cambios de la copia con las fechas Correctas.");
                     return System.Windows.Forms.DialogResult.Cancel;
                  }
                  else
                  { return _result; }
               }
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

      public bool GuardarCopia(Boolean CopiarContrato, Int32 PUER_Codigo)
      {
         try
         {
            CView.GetItem();
            if (Item.Validar())
            {
               if (!CopiarContrato && PUER_Codigo <= 0)
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un puerto.");
                  return false;
               }

               if (Client.GetOneContratoValidacion((CopiarContrato ? -1 : Item.CONT_Codigo.Value), ItemCopia.CONT_Numero, ItemCopia.CONT_FecIni.Value, ItemCopia.CONT_FecFin.Value))
               {
                  Item = Client.GetOneContratoCopiar(CopiarContrato, Item, ItemCopia, Session.UserName, PUER_Codigo);
                  if (Item != null)
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha copiado satisfactoriamente");

                     if (!CopiarContrato)
                     {
                        if (Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
                        {
                           ItemPuertoDestino = ListPuertos.Where(puer => puer.PUER_Codigo == PUER_Codigo).FirstOrDefault();
                           if (ItemPuertoDestino != null)
                           { ItemTipoPAIDestino = ListPaises.Where(tmnd => tmnd.TIPO_CodTabla == ItemPuertoDestino.TIPO_TabPais && tmnd.TIPO_CodTipo == ItemPuertoDestino.TIPO_CodPais).FirstOrDefault(); }

                           Item.TIPO_TabPaisDestino = ItemPuertoDestino.TIPO_TabPais;
                           Item.TIPO_CodPaisDestino = ItemPuertoDestino.TIPO_CodPais;
                           Item.PUER_CodigoDestino = ItemPuertoDestino.PUER_Codigo;
                        }
                        else
                        {
                           ItemPuertoOrigen = ListPuertos.Where(puer => puer.PUER_Codigo == PUER_Codigo).FirstOrDefault();
                           if (ItemPuertoOrigen != null)
                           { ItemTipoPAIOrigen = ListPaises.Where(tmnd => tmnd.TIPO_CodTabla == ItemPuertoOrigen.TIPO_TabPais && tmnd.TIPO_CodTipo == ItemPuertoOrigen.TIPO_CodPais).FirstOrDefault(); }

                           Item.TIPO_TabPaisOrigen = ItemPuertoOrigen.TIPO_TabPais;
                           Item.TIPO_CodPaisOrigen = ItemPuertoOrigen.TIPO_CodPais;
                           Item.PUER_CodigoOrigen = ItemPuertoOrigen.PUER_Codigo;
                        }
                     }

                     MView.ClearItem();
                     this.Item.AUDI_UsrMod = Session.UserName;
                     this.Item.AUDI_FecMod = Session.Fecha;
                     this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                     MView.SetItem(true);

                     LoadTarifas(ItemTipoMND, ItemPaquete, ItemTipoPAIOrigen, ItemPuertoOrigen, ItemTipoPAIDestino, ItemPuertoDestino);

                     return true;
                  }
                  else
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al copiar el item.");
                     return false;
                  }
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Existe un contrato con el mismo Número y el Rango de Fechas que se cruzan.");
                  return false;
               }
            }
            else
            {
               MView.ShowValidation();
               return false;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
            return false;
         }
      }

      public void NuevoTarifa(Tipos ItemTipoMND, Int32 PUER_Codigo1, Int32 PUER_Codigo2, Int32 PACK_Codigo, Decimal TARI_Costo)
      {
         try
         {
            if (Guardar(false, false))
            {
               MView.EnableItem(false, false);

               DView.ClearItem();
               this.ItemTarifa = new Tarifa();
               this.ItemTarifa.CONT_Codigo = Item.CONT_Codigo;
               if (Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
               {
                  this.ItemTarifa.PUER_CodOrigen = PUER_Codigo1;
                  this.ItemTarifa.PUER_CodDestino = PUER_Codigo2;
               }
               else
               {
                  this.ItemTarifa.PUER_CodDestino = PUER_Codigo1;
                  this.ItemTarifa.PUER_CodOrigen = PUER_Codigo2;
               }
               this.ItemTarifa.PACK_Codigo = PACK_Codigo;
               this.ItemTarifa.TARI_Costo = TARI_Costo;
               this.ItemTarifa.TIPO_TabMnd = ItemTipoMND.TIPO_CodTabla;
               this.ItemTarifa.TIPO_CodMnd = ItemTipoMND.TIPO_CodTipo;
               this.ItemTarifa.AUDI_UsrCrea = Session.UserName;
               this.ItemTarifa.AUDI_FecCrea = Session.Fecha;
               this.ItemTarifa.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
               DView.SetItem();

               ((COM006DView)DView).ShowDialog();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }
      public void EditarTarifa(Tipos ItemTipoMND, Int32 PUER_Codigo1, Int32 PUER_Codigo2, Int32 PACK_Codigo, Int32 TARI_Codigo, Decimal TARI_Costo)
      {
         try
         {
            if (Guardar(false, false))
            {
               MView.EnableItem(false, false);

               ItemTarifa = Item.ListTarifa.Where(tari => tari.TARI_Codigo == TARI_Codigo).FirstOrDefault();

               if (ItemTarifa != null)
               {
                  DView.ClearItem();
                  this.ItemTarifa.TARI_Costo = TARI_Costo;
                  this.ItemTarifa.AUDI_UsrMod = Session.UserName;
                  this.ItemTarifa.AUDI_FecMod = Session.Fecha;
                  this.ItemTarifa.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                  DView.SetItem();

                  ((COM006DView)DView).ShowDialog();
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }
      public bool GuardarTarifa()
      {
         try
         {
            DView.GetItem();
            if (ItemTarifa.Validar())
            {
               if (ItemTarifa.ValidarProfit())
               {
                  if (Client.SaveTarifa(ItemTarifa))
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                     LoadTarifas(ItemTipoMND, ItemPaquete, ItemTipoPAIOrigen, ItemPuertoOrigen, ItemTipoPAIDestino, ItemPuertoDestino);
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
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error en los datos del item.", ItemTarifa.MensajeError);
                  return false;
               }
            }
            else
            {
               DView.ShowValidation();
               return false;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
            return false;
         }
      }
      public System.Windows.Forms.DialogResult GuardarTarifaCambios()
      {
         try
         {
            if (this.Item != null)
            {
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.SaveChangesPreguntaPresenter, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  if (GuardarTarifa())
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

      public Boolean ActualizarTarifa(Int32 TARI_Codigo, Int32 PUER_CodOrigen, Int32 PUER_CodDestino, Int32 PACK_Codigo, Int32 TARI_Campo, Decimal TARI_Valor, Decimal TARI_CostoActualizar, Decimal TARI_Profit1Actualizar, Decimal TARI_Profit2Actualizar, Decimal TARI_Profit3Actualizar, Decimal TARI_Profit4Actualizar, Decimal TARI_Costo)
      {
         try
         {
            if (TARI_Codigo <= 0)
            {
               //Presenter.NuevoTarifa(TIPO_CodMnd.TiposSelectedItem, _PUER_Codigo, _PUER_Codigo2, _PACK_Codigo, _TARI_Costo);

               ItemTarifa = new Tarifa();
               ItemTarifa.CONT_Codigo = Item.CONT_Codigo;
               if (Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
               {
                  this.ItemTarifa.PUER_CodOrigen = PUER_CodOrigen;
                  this.ItemTarifa.PUER_CodDestino = PUER_CodDestino;
               }
               else
               {
                  this.ItemTarifa.PUER_CodOrigen = PUER_CodOrigen;
                  this.ItemTarifa.PUER_CodDestino = PUER_CodDestino;
               }
               ItemTarifa.PACK_Codigo = PACK_Codigo;
               ItemTarifa.TIPO_TabMnd = ItemTipoMND.TIPO_CodTabla;
               ItemTarifa.TIPO_CodMnd = ItemTipoMND.TIPO_CodTipo;
               ItemTarifa.AUDI_UsrCrea = Session.UserName;
               ItemTarifa.AUDI_FecCrea = Session.Fecha;
               ItemTarifa.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            }
            else
            {
               ItemTarifa = Item.ListTarifa.Where(tari => tari.TARI_Codigo == TARI_Codigo).FirstOrDefault();
               ItemTarifa.AUDI_UsrMod = Session.UserName;
               ItemTarifa.AUDI_FecMod = Session.Fecha;
               ItemTarifa.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
            }

            if (ItemTarifa != null)
            {
               Boolean _guardar = false;
               //switch (TARI_Campo)
               //{
               //   case 1://"Campo Costo"
               //if (TARI_Costo > (Decimal)0.00)
               //{
               if (TARI_CostoActualizar > (Decimal)0.00)
               {
                  ItemTarifa.TARI_Costo = TARI_CostoActualizar;

                  if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit1.HasValue)
                  { ItemTarifa.TARI_PVenta1 = (ItemTarifa.TARI_Profit1.Value + ItemTarifa.TARI_Costo.Value); }

                  if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit2.HasValue)
                  { ItemTarifa.TARI_PVenta2 = (ItemTarifa.TARI_Profit2.Value + ItemTarifa.TARI_Costo.Value); }

                  if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit3.HasValue)
                  { ItemTarifa.TARI_PVenta3 = (ItemTarifa.TARI_Profit3.Value + ItemTarifa.TARI_Costo.Value); }

                  if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit4.HasValue)
                  { ItemTarifa.TARI_PVenta4 = (ItemTarifa.TARI_Profit4.Value + ItemTarifa.TARI_Costo.Value); }

                  _guardar = true;
               }
               else
               {
                  if (TARI_Costo > (Decimal)0.00)
                  {
                     ItemTarifa.TARI_Costo = TARI_Costo;

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit1.HasValue)
                     { ItemTarifa.TARI_PVenta1 = (ItemTarifa.TARI_Profit1.Value + ItemTarifa.TARI_Costo.Value); }

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit2.HasValue)
                     { ItemTarifa.TARI_PVenta2 = (ItemTarifa.TARI_Profit2.Value + ItemTarifa.TARI_Costo.Value); }

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit3.HasValue)
                     { ItemTarifa.TARI_PVenta3 = (ItemTarifa.TARI_Profit3.Value + ItemTarifa.TARI_Costo.Value); }

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit4.HasValue)
                     { ItemTarifa.TARI_PVenta4 = (ItemTarifa.TARI_Profit4.Value + ItemTarifa.TARI_Costo.Value); }

                     _guardar = true;
                  }
               }

               if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Costo.Value > (Decimal)0.00)
               {
                  //if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit1.HasValue)
                  //{ ItemTarifa.TARI_PVenta1 = (ItemTarifa.TARI_Profit1.Value + ItemTarifa.TARI_Costo.Value); }

                  //if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit2.HasValue)
                  //{ ItemTarifa.TARI_PVenta2 = (ItemTarifa.TARI_Profit2.Value + ItemTarifa.TARI_Costo.Value); }

                  //if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit3.HasValue)
                  //{ ItemTarifa.TARI_PVenta3 = (ItemTarifa.TARI_Profit3.Value + ItemTarifa.TARI_Costo.Value); }

                  //if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit4.HasValue)
                  //{ ItemTarifa.TARI_PVenta4 = (ItemTarifa.TARI_Profit4.Value + ItemTarifa.TARI_Costo.Value); }

                  //      _guardar = true;
                  //   //}
                  //   break;
                  //case 2://"Campo Profit 1"
                  //   if (TARI_Costo > (Decimal)0.00)
                  //   {
                  //ItemTarifa.TARI_Costo = TARI_Costo;
                  if (TARI_Profit1Actualizar > (Decimal)0.00)
                  {
                     ItemTarifa.TARI_Profit1 = TARI_Profit1Actualizar;

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit1.HasValue)
                     { ItemTarifa.TARI_PVenta1 = (ItemTarifa.TARI_Profit1.Value + ItemTarifa.TARI_Costo.Value); }

                     _guardar = true;
                  }
                  //   }
                  //   break;
                  //case 3://"Campo Profit 2"
                  //   if (TARI_Costo > (Decimal)0.00)
                  //   {
                  //ItemTarifa.TARI_Costo = TARI_Costo;
                  if (TARI_Profit2Actualizar > (Decimal)0.00)
                  {
                     ItemTarifa.TARI_Profit2 = TARI_Profit2Actualizar;

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit2.HasValue)
                     { ItemTarifa.TARI_PVenta2 = (ItemTarifa.TARI_Profit2.Value + ItemTarifa.TARI_Costo.Value); }

                     _guardar = true;
                  }
                  //   }
                  //   break;
                  //case 4://"Campo Profit 3"
                  //   if (TARI_Costo > (Decimal)0.00)
                  //   {

                  if (TARI_Profit3Actualizar > (Decimal)0.00)
                  {
                     ItemTarifa.TARI_Profit3 = TARI_Profit3Actualizar;

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit3.HasValue)
                     { ItemTarifa.TARI_PVenta3 = (ItemTarifa.TARI_Profit3.Value + ItemTarifa.TARI_Costo.Value); }

                     _guardar = true;
                  }
                  //   }
                  //   break;
                  //case 5://"Campo Profit 4"
                  //   if (TARI_Costo > (Decimal)0.00)
                  //   {
                  //ItemTarifa.TARI_Costo = TARI_Costo;
                  if (TARI_Profit4Actualizar > (Decimal)0.00)
                  {
                     ItemTarifa.TARI_Profit4 = TARI_Profit4Actualizar;

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit4.HasValue)
                     { ItemTarifa.TARI_PVenta4 = (ItemTarifa.TARI_Profit4.Value + ItemTarifa.TARI_Costo.Value); }

                     _guardar = true;
                  }
                  //}
                  //break;
                  //}

                  if (_guardar && ItemTarifa.Validar())
                  {
                     ItemsTarifa.Add(ItemTarifa);
                     ItemTarifa = null;
                     return true;
                     //return Client.SaveTarifa(ItemTarifa); 
                  }
                  else
                  { return false; }
               }
               else
               { return false; }
            }
            else
            { return false; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al actualizar la tarifa.", ex); return false; }
      }
      public Boolean SumarTarifa(Int32 TARI_Codigo, Int32 PUER_CodOrigen, Int32 PUER_CodDestino, Int32 PACK_Codigo, Int32 TARI_Campo, Decimal TARI_Valor, Decimal TARI_CostoActualizar, Decimal TARI_Profit1Actualizar, Decimal TARI_Profit2Actualizar, Decimal TARI_Profit3Actualizar, Decimal TARI_Profit4Actualizar, Decimal TARI_Costo)
      {
         try
         {
            if (TARI_Codigo <= 0)
            {
               //Presenter.NuevoTarifa(TIPO_CodMnd.TiposSelectedItem, _PUER_Codigo, _PUER_Codigo2, _PACK_Codigo, _TARI_Costo);

               ItemTarifa = new Tarifa();
               ItemTarifa.CONT_Codigo = Item.CONT_Codigo;
               if (Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
               {
                  this.ItemTarifa.PUER_CodOrigen = PUER_CodOrigen;
                  this.ItemTarifa.PUER_CodDestino = PUER_CodDestino;
               }
               else
               {
                  this.ItemTarifa.PUER_CodOrigen = PUER_CodOrigen;
                  this.ItemTarifa.PUER_CodDestino = PUER_CodDestino;
               }
               ItemTarifa.PACK_Codigo = PACK_Codigo;
               ItemTarifa.TIPO_TabMnd = ItemTipoMND.TIPO_CodTabla;
               ItemTarifa.TIPO_CodMnd = ItemTipoMND.TIPO_CodTipo;
               ItemTarifa.AUDI_UsrCrea = Session.UserName;
               ItemTarifa.AUDI_FecCrea = Session.Fecha;
               ItemTarifa.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            }
            else
            {
               ItemTarifa = Item.ListTarifa.Where(tari => tari.TARI_Codigo == TARI_Codigo).FirstOrDefault();
               ItemTarifa.AUDI_UsrMod = Session.UserName;
               ItemTarifa.AUDI_FecMod = Session.Fecha;
               ItemTarifa.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
            }

            if (ItemTarifa != null)
            {
               Boolean _guardar = false;
               //switch (TARI_Campo)
               //{
               //   case 1://"Campo Costo"
               //if (TARI_Costo > (Decimal)0.00)
               //{
               if (TARI_CostoActualizar > (Decimal)0.00)
               {
                  if (ItemTarifa.TARI_Costo.HasValue)
                  { ItemTarifa.TARI_Costo += TARI_Valor; }
                  else
                  { ItemTarifa.TARI_Costo = TARI_Valor; }

                  if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit1.HasValue)
                  { ItemTarifa.TARI_PVenta1 = (ItemTarifa.TARI_Profit1.Value + ItemTarifa.TARI_Costo.Value); }

                  if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit2.HasValue)
                  { ItemTarifa.TARI_PVenta2 = (ItemTarifa.TARI_Profit2.Value + ItemTarifa.TARI_Costo.Value); }

                  if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit3.HasValue)
                  { ItemTarifa.TARI_PVenta3 = (ItemTarifa.TARI_Profit3.Value + ItemTarifa.TARI_Costo.Value); }

                  if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit4.HasValue)
                  { ItemTarifa.TARI_PVenta4 = (ItemTarifa.TARI_Profit4.Value + ItemTarifa.TARI_Costo.Value); }

                  _guardar = true;
               }
               else
               {
                  if (TARI_Costo > (Decimal)0.00)
                  {
                     ItemTarifa.TARI_Costo = TARI_Costo;

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit1.HasValue)
                     { ItemTarifa.TARI_PVenta1 = (ItemTarifa.TARI_Profit1.Value + ItemTarifa.TARI_Costo.Value); }

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit2.HasValue)
                     { ItemTarifa.TARI_PVenta2 = (ItemTarifa.TARI_Profit2.Value + ItemTarifa.TARI_Costo.Value); }

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit3.HasValue)
                     { ItemTarifa.TARI_PVenta3 = (ItemTarifa.TARI_Profit3.Value + ItemTarifa.TARI_Costo.Value); }

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit4.HasValue)
                     { ItemTarifa.TARI_PVenta4 = (ItemTarifa.TARI_Profit4.Value + ItemTarifa.TARI_Costo.Value); }

                     _guardar = true;
                  }
               }

               //if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit1.HasValue)
               //{ ItemTarifa.TARI_PVenta1 = (ItemTarifa.TARI_Profit1.Value + ItemTarifa.TARI_Costo.Value); }

               //if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit2.HasValue)
               //{ ItemTarifa.TARI_PVenta2 = (ItemTarifa.TARI_Profit2.Value + ItemTarifa.TARI_Costo.Value); }

               //if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit3.HasValue)
               //{ ItemTarifa.TARI_PVenta3 = (ItemTarifa.TARI_Profit3.Value + ItemTarifa.TARI_Costo.Value); }

               //if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit4.HasValue)
               //{ ItemTarifa.TARI_PVenta4 = (ItemTarifa.TARI_Profit4.Value + ItemTarifa.TARI_Costo.Value); }

               if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Costo.Value > (Decimal)0.00)
               {
                  //}
                  //   break;
                  //case 2://"Campo Profit 1"
                  if (ItemTarifa.TARI_Costo > (Decimal)0.00 && TARI_Profit1Actualizar > (Decimal)0.00)
                  {
                     //ItemTarifa.TARI_Costo = TARI_Costo;

                     if (ItemTarifa.TARI_Profit1.HasValue)
                     { ItemTarifa.TARI_Profit1 += TARI_Profit1Actualizar; }
                     else
                     { ItemTarifa.TARI_Profit1 = TARI_Profit1Actualizar; }

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit1.HasValue)
                     { ItemTarifa.TARI_PVenta1 = (ItemTarifa.TARI_Profit1.Value + ItemTarifa.TARI_Costo.Value); }

                     _guardar = true;
                  }
                  //   break;
                  //case 3://"Campo Profit 2"
                  if (ItemTarifa.TARI_Costo > (Decimal)0.00 && TARI_Profit2Actualizar > (Decimal)0.00)
                  {
                     //ItemTarifa.TARI_Costo = TARI_Costo;

                     if (ItemTarifa.TARI_Profit2.HasValue)
                     { ItemTarifa.TARI_Profit2 += TARI_Profit2Actualizar; }
                     else
                     { ItemTarifa.TARI_Profit2 = TARI_Profit2Actualizar; }

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit2.HasValue)
                     { ItemTarifa.TARI_PVenta2 = (ItemTarifa.TARI_Profit2.Value + ItemTarifa.TARI_Costo.Value); }

                     _guardar = true;
                  }
                  //   break;
                  //case 4://"Campo Profit 3"
                  if (ItemTarifa.TARI_Costo > (Decimal)0.00 && TARI_Profit3Actualizar > (Decimal)0.00)
                  {
                     //ItemTarifa.TARI_Costo = TARI_Costo;

                     if (ItemTarifa.TARI_Profit3.HasValue)
                     { ItemTarifa.TARI_Profit3 += TARI_Profit3Actualizar; }
                     else
                     { ItemTarifa.TARI_Profit3 = TARI_Profit3Actualizar; }

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit3.HasValue)
                     { ItemTarifa.TARI_PVenta3 = (ItemTarifa.TARI_Profit3.Value + ItemTarifa.TARI_Costo.Value); }

                     _guardar = true;
                  }
                  //   break;
                  //case 5://"Campo Profit 4"
                  if (ItemTarifa.TARI_Costo > (Decimal)0.00 && TARI_Profit4Actualizar > (Decimal)0.00)
                  {
                     //ItemTarifa.TARI_Costo = TARI_Costo;

                     if (ItemTarifa.TARI_Profit4.HasValue)
                     { ItemTarifa.TARI_Profit4 += TARI_Profit4Actualizar; }
                     else
                     { ItemTarifa.TARI_Profit4 = TARI_Profit4Actualizar; }

                     if (ItemTarifa.TARI_Costo.HasValue && ItemTarifa.TARI_Profit4.HasValue)
                     { ItemTarifa.TARI_PVenta4 = (ItemTarifa.TARI_Profit4.Value + ItemTarifa.TARI_Costo.Value); }

                     _guardar = true;
                  }
                  //break;
                  //}

                  if (_guardar && ItemTarifa.Validar())
                  {
                     ItemsTarifa.Add(ItemTarifa);
                     ItemTarifa = null;
                     return true;
                     //return Client.SaveTarifa(ItemTarifa); 
                  }
                  else
                  { return false; }
               }
               else
               { return false; }
            }
            else
            { return false; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al actualizar la tarifa.", ex); return false; }
      }

      public Boolean GuardarTarifas()
      {
         try
         {
            return Client.SaveTarifas(ItemsTarifa);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al actualizar la tarifa.", ex); return false; }
      }
      #endregion
   }
}