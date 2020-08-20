using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Infrastructure.Aspect.BusinessEntity;
using Microsoft.Practices.Unity;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Aspect.Collections;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using Infrastructure.WinFormsControls;
using System.Data;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
    public class PRO001Presenter
    {
        #region [ Variables ]
        public String Title = "Tarifario";
        public String CUS = "";
        private Cab_Tarifa m_ItemCAB_Tarifa;
        private Cab_Tarifa m_itemLView;
        public string tipe_Desc = ""; // descripcion de titulo
        private ObservableCollection<Det_Tarifa> m_ItemsDet_Tarifa;
        private ObservableCollection<Det_Tarifa> m_ItemsDet_TarifaCopia;
        private ObservableCollection<Det_Tarifa> m_ItemsDet_TarifaDelete;
        private Boolean m_EsCopia = false;
        #endregion

        #region [ Constructor ]
        public PRO001Presenter(IUnityContainer x_container, IPRO001LView x_lview, IPRO001MView x_mview, IPRO001DTarifa x_dmview, IPRO001DSMview x_dsmview, String x_TipoTarifa)
        {
            try
            {
                ContainerService = x_container;
                Session = ContainerService.Resolve<ISessionService>();
                LView = x_lview;
                MView = x_mview;
                DView = x_dmview;
                DSView = x_dsmview;
                EsCopia = false;
                TipoTarifa = x_TipoTarifa;
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.ConstructorPresenter, ex); }
        }
        public void Load()
        {
            try
            {
                Client = ContainerService.Resolve<Delfin.ServiceContracts.IDelfinServices>();
                ListMonedas = Client.GetAllTiposByTipoCodTabla("MND");

                /* solo 13 => Agencia Maritima , 14 => Deposito Temporal, 15 => Deposito Vacio */
                switch (TipoTarifa)
                {
                    case "L": /* Logistico */
                        CodTipoEntidad = 13;
                        ListTiposEntidad = Client.GetAllTiposEntidad().Where(tipe => tipe.TIPE_Codigo == 13 || tipe.TIPE_Codigo == 14 || tipe.TIPE_Codigo == 15).ToObservableCollection();
                        tipe_Desc = " TARIFA SERVICIO LOGÍSTICO";
                        DSView.LoadView();
                        break;
                    case "A": /* Aduana */
                        CodTipoEntidad = 14;
                        ListConstantes = Client.GetAllConstantesByConstanteTabla("BSL");
                        tipe_Desc = "TARIFA SERVICIO ADUANERO";
                        DSView.LoadView();
                        break;
                    case "T": /* Transporte */
                        CodTipoEntidad = 15;
                        tipe_Desc = "TARIFA SERVICIO TRANSPORTE";
                        ListConstantes = Client.GetAllConstantesByConstanteTabla("BSL");
                        ListConstantesTipo = Client.GetAllConstantesByConstanteTabla("TRA");
                        ListZonas = Client.GetAllTiposByTipoCodTabla("ZON");
                        ListZonasDetino = Client.GetAllTiposByTipoCodTabla("ZON");
                        break;
                }
                LView.LoadView();
                MView.LoadView();
                DView.LoadView();
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.LoadPresenter, ex); }
        }
        #endregion

        #region [ Propiedades ]
        public IUnityContainer ContainerService { get; set; }
        public ISessionService Session { get; set; }
        public Delfin.ServiceContracts.IDelfinServices Client { get; set; }

        public IPRO001LView LView { get; set; }
        public IPRO001MView MView { get; set; }
        public IPRO001DTarifa DView { get; set; }
        public IPRO001DSMview DSView { get; set; }

        public String TipoTarifa { get; set; }
        public short CodTipoEntidad { get; set; }
        public ObservableCollection<Tipos> ListMonedas { get; set; }
        public ObservableCollection<TiposEntidad> ListTiposEntidad { get; set; }
        public ObservableCollection<Entidad> ListEntidad { get; set; }
        public ObservableCollection<Servicio> ListServicios { get; set; }
        public ObservableCollection<Constantes> ListConstantes { get; set; }
        public ObservableCollection<Constantes> ListConstantesTipo { get; set; }
        public ObservableCollection<Tipos> ListZonas { get; set; }
        public ObservableCollection<Tipos> ListZonasDetino { get; set; }

        public InstanceView InstanciaDet_Tarifa { get; set; }
        public InstanceView InstanciaDet_TarifaServicio { get; set; }
        public Decimal Profit { get; set; }
        public DateTime FILTRO_FecEmiDesde { get; set; }
        public DateTime FILTRO_FecEmiHasta { get; set; }

        public Int32? FILTROLineaNaviera { get; set; }
        public Int32? FILTROAgMaritimo { get; set; }
        public Int32? FILTRODepTemporal { get; set; }
        public Int32? FILTRODepVacio { get; set; }
        public Int32? FILTROAgAduana { get; set; }
        public Int32? FILTROTransporte { get; set; }
        Boolean isMViewShow = false;

        #region [ Encabezado Tarifario ]
        public Boolean EsCopia
        {
            get { return m_EsCopia; }
            set { m_EsCopia = value; }
        }
        public Cab_Tarifa ItemCab_Copia { get; set; }
        public Cab_Tarifa ItemCAB_Tarifa
        {
            get { return m_ItemCAB_Tarifa; }
            set { m_ItemCAB_Tarifa = value; }
        }
        public Cab_Tarifa ItemLView
        {
            get { return m_itemLView; }
            set { m_itemLView = value; }
        }
        public ObservableCollection<Cab_Tarifa> ItemsCAB_Tarifa { get; set; }
        #endregion

        #region [ Detalle Tarifario ]
        public Det_Tarifa ItemDet_Copia { get; set; }

        public ObservableCollection<Det_Tarifa> ItemsDet_Tarifa
        {
            get { return m_ItemsDet_Tarifa; }
            set { m_ItemsDet_Tarifa = value; }
        }
        public ObservableCollection<Det_Tarifa> ItemsDet_TarifaCopia
        {
            get { return m_ItemsDet_TarifaCopia; }
            set { m_ItemsDet_TarifaCopia = value; }
        }
        public ObservableCollection<Det_Tarifa> ItemsDet_TarifaDelete
        {
            get { return m_ItemsDet_TarifaDelete; }
            set { m_ItemsDet_TarifaDelete = value; }
        }
        public ObservableCollection<Det_Tarifa> ItemsGrillaDet_Tarifa { get; set; }

        public Det_Tarifa ItemDET_Tarifa { get; set; }
        public Det_Tarifa TempItemDET_Tarifa { get; set; }

        public Det_Tarifa_Servicio ItemDet_TarifaServicio { get; set; }
        public Det_Tarifa_Servicio TempItemDet_TarifaServicio { get; set; }
        public ObservableCollection<Det_Tarifa_Servicio> ItemsDet_TarifaServicio { get; set; }
        public ObservableCollection<Det_Tarifa_Servicio> ItemsDet_TarifaServicioCopia { get; set; }
        #endregion

        #endregion

        #region [ Metodos ]

        #region [ Encabezado Tarifario ]
        public void Nuevo()
        {
            try
            {

                if (!isMViewShow)
                {
                    MView = new PRO001MView();
                    MView.Presenter = this;
                    MView.LoadView();
                }

                MView.ClearItem();
                ItemCAB_Tarifa = new Cab_Tarifa
                {
                    AUDI_UsrCrea = Session.UserName,
                    AUDI_FecCrea = Session.Fecha,
                    Instance = InstanceEntity.Added,
                    TIPO_TabMnd = "MND",
                    CONS_TabReg = "RGM",
                    CTAR_Tipo = TipoTarifa
                };
                MView.ClearItemsDetalles();
                ItemDET_Tarifa = new Det_Tarifa();
                ItemsGrillaDet_Tarifa = new ObservableCollection<Det_Tarifa>();
                ItemsDet_Tarifa = new ObservableCollection<Det_Tarifa>();
                ItemsDet_TarifaServicio = new ObservableCollection<Det_Tarifa_Servicio>();
                MView.ClearItemsDetalleServicios();
                MView.SetInstance(InstanceView.New);

                isMViewShow = true;
                ((PRO001MView)MView).Show();
                ((PRO001MView)MView).BringToFront();
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
        }
        public void Editar()
        {
            try
            {
                if (!isMViewShow)
                {
                    MView = new PRO001MView();
                    MView.Presenter = this;
                    MView.LoadView();
                }
                if (ItemLView != null)
                {
                    MView.ClearItem();
                    /* Encabezado  :) */
                    ItemCAB_Tarifa = Client.GetOneCab_Tarifa(ItemLView.CTAR_Tipo, ItemLView.CTAR_Codigo);
                    if (ItemCAB_Tarifa != null)
                    {
                        ItemCAB_Tarifa.AUDI_UsrMod = Session.UserName;
                        ItemCAB_Tarifa.AUDI_FecMod = Session.Fecha;
                        ItemCAB_Tarifa.Instance = InstanceEntity.Modified;
                        MView.SetItem();

                        /* Detalle Tarifa :) */
                        MView.ClearItemsDetalles();
                        ItemsDet_Tarifa = Client.GetAllDet_TarifaByTarifario(ItemCAB_Tarifa.CTAR_Codigo, ItemCAB_Tarifa.CTAR_Tipo);
                        if (TipoTarifa.Equals("L"))
                        {
                            DView.SetItemST20_ST40(ref m_ItemsDet_Tarifa);
                        }
                        MView.ShowItemsDetalleTarifario();

                        /* Detalle Servicio :) */
                        MView.ClearItemsDetalleServicios();
                        ItemsDet_TarifaServicio = Client.GetAllDet_ServicioByTarifario(ItemCAB_Tarifa.CTAR_Codigo, ItemCAB_Tarifa.CTAR_Tipo);
                        MView.ShowItemsDetalleServicios();

                        MView.SetInstance(InstanceView.Edit);

                        isMViewShow = true;
                        ((PRO001MView)MView).Show();
                        ((PRO001MView)MView).BringToFront();
                    }
                    else
                    { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontro la Tarifa Seleccionada"); }
                }
                else
                { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
        }
        public void Eliminar()
        {
            try
            {
                if (ItemLView != null)
                {
                    DialogResult result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
                    if (result == DialogResult.Yes)
                    {
                        if ((ItemLView.CTAR_Codigo != ItemCAB_Tarifa.CTAR_Codigo) || (!isMViewShow))
                        {
                            ItemLView.Instance = InstanceEntity.Deleted;
                            if (Client.SaveCab_Tarifa(ref m_itemLView))
                            {
                                Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                                Actualizar();
                            }
                            else
                            { Dialogos.MostrarMensajeInformacion(Title, "No se ha podido eliminar el item debido a que ya se encuentra relacionado."); }
                        }
                        else
                        {
                            { Dialogos.MostrarMensajeInformacion(Title, "El Registro que desea eliminar se encuentra abierto por favor cierre el registro para poder eliminarlo"); }
                        }
                    }
                }
                else
                { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
        }
        public void Actualizar()
        {
            try
            {
                ItemLView = null;
                ItemCAB_Tarifa = null;
                ItemsCAB_Tarifa = null;
                LView.FiltrosLView();
                ItemsCAB_Tarifa = Client.GetAllByFiltrosTarifario(FILTROLineaNaviera, FILTROAgMaritimo, FILTRODepTemporal, FILTRODepVacio,
                                 FILTROAgAduana, FILTROTransporte, FILTRO_FecEmiDesde, FILTRO_FecEmiHasta, TipoTarifa);
                LView.ShowItems();
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
        }
        private void ActualizaProfit()
        {
            foreach (Det_Tarifa _item in ItemsDet_Tarifa)
            {
                _item.DTAR_Profit = ItemCAB_Tarifa.CTAR_Profit == null ? 0 : ItemCAB_Tarifa.CTAR_Profit;
                if (_item.DTAR_Costo == 0)
                    _item.DTAR_Venta = 0;
                else
                    _item.DTAR_Venta = _item.DTAR_Costo + _item.DTAR_Profit;
                if (_item.DTAR_CostoSada == 0)
                    _item.DTAR_VentaSada = 0;
                else
                    _item.DTAR_VentaSada = _item.DTAR_CostoSada + _item.DTAR_Profit;
                if (_item.Instance == InstanceEntity.Unchanged)
                    _item.Instance = InstanceEntity.Modified;
            }
        }
        public bool GuardarTarifa()
        {
            try
            {
                MView.GetItem();
                if (ItemCAB_Tarifa.Validar())
                {
                    if (ItemsDet_Tarifa != null && ItemsDet_Tarifa.Count > 0)
                    {
                        ActualizaProfit();
                        ItemCAB_Tarifa.ItemsDet_Tarifa = new ObservableCollection<Det_Tarifa>();
                        ItemCAB_Tarifa.ItemsDet_Tarifa = ItemsDet_Tarifa;
                        if (ItemsDet_TarifaServicio != null && ItemsDet_TarifaServicio.Count > 0)
                        {
                            m_ItemCAB_Tarifa.ItemsDet_Tarifa_Servicio = new ObservableCollection<Det_Tarifa_Servicio>();
                            m_ItemCAB_Tarifa.ItemsDet_Tarifa_Servicio = ItemsDet_TarifaServicio;
                        }
                        if (m_ItemCAB_Tarifa.Instance != InstanceEntity.Added)
                        {
                            if (Client.SaveCab_Tarifa(ref m_ItemCAB_Tarifa))
                            {
                                Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                                Actualizar();
                                return true;
                            }
                            Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                            return false;
                        }
                        if (ItemCAB_Tarifa.ENTC_Codigo != null && Client.ValidarCopiaTarifa(ItemCAB_Tarifa.CTAR_FecIni, ItemCAB_Tarifa.CTAR_FecFin, ItemCAB_Tarifa.CONS_CodReg, ItemCAB_Tarifa.TIPO_CodMnd, ItemCAB_Tarifa.ENTC_Codigo.Value))
                        {
                            if (Client.SaveCab_Tarifa(ref m_ItemCAB_Tarifa))
                            {
                                Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                                Actualizar();
                                return true;
                            }
                        }
                        else
                        {
                            Dialogos.MostrarMensajeInformacion(Title, "Se ha encontrado una tarifa con mismos datos verifique porfavor.");
                            return false;
                        }
                        Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                        return false;
                    }
                    Dialogos.MostrarMensajeInformacion(Title, "Debe agregar un detalle del tarifario como minimo");
                    return false;
                }
                MView.ShowValidation();
                return false;
            }
            catch (Exception ex)
            {
                Dialogos.MostrarMensajeError(Title, "El detalle del tarifario tiene relaciones con otras tablas verifique porfavor.", ex);
                return false;
            }
        }
        public void Copia()
        {
            try
            {
                EsCopia = true;
                /* Encabezado  :) */
                ItemCAB_Tarifa.AUDI_UsrCrea = Session.UserName;
                ItemCAB_Tarifa.AUDI_FecCrea = Session.Fecha;
                ItemCAB_Tarifa.Instance = InstanceEntity.Added;
                ItemCAB_Tarifa.CTAR_Codigo = 0;
                ItemCAB_Tarifa.TIPO_TabMnd = "MND";
                ItemCAB_Tarifa.CONS_TabReg = "RGM";
                ItemCAB_Tarifa.CTAR_Tipo = TipoTarifa; // L=> Logistico  A => Aduanero T => Transporte
                MView.SetInstance(InstanceView.New);
                /* Detalle Tarifa :) */
                foreach (var xItem in ItemsDet_Tarifa)
                {
                    xItem.Instance = InstanceEntity.Added;
                    xItem.DTAR_Item = 0;
                }

                /* Detalle Servicio :) */
                if (ItemsDet_TarifaServicio != null)
                {
                    foreach (var xItem in ItemsDet_TarifaServicio)
                    {
                        xItem.Instance = InstanceEntity.Added;
                        xItem.DTAS_Item = 0;
                    }
                }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
        }
        #endregion

        #region [ Detalle Tarifario ]
        public void LoadDetalleTarifario(InstanceView xInstance)
        {
            try
            {
                DView.ClearItem(TipoTarifa);
                switch (xInstance)
                {
                    case InstanceView.New:
                        DView.SetInstance(InstanceView.New);
                        ItemDET_Tarifa = new Det_Tarifa();
                        InstanciaDet_Tarifa = InstanceView.New;
                        break;
                    case InstanceView.Edit:
                        InstanciaDet_Tarifa = InstanceView.Edit;
                        DView.SetInstance(InstanceView.Edit);
                        break;
                }
                ((PRO001DTarifa)DView).ShowDialog();
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
        }
        public void NuevoDetalleTarifarios()
        {
            try
            {
                TempItemDET_Tarifa = new Det_Tarifa
                {
                    CTAR_Tipo = TipoTarifa,
                    AUDI_UsrCrea = Session.UserName,
                    AUDI_FecCrea = Session.Fecha,
                    Instance = InstanceEntity.Added
                };
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
        }
        public void AgregarDetalleTarifario()
        {
            try
            {
                if (TipoTarifa.Equals("L"))
                {
                    if (InstanciaDet_Tarifa == InstanceView.Edit)
                    {
                        if (ItemDET_Tarifa.DTAR_Item > 0)
                        {
                            //ItemsDet_Tarifa.Remove(ItemDET_Tarifa);
                            ItemDET_Tarifa.Instance = InstanceEntity.Modified;
                            ItemDET_Tarifa.AUDI_UsrMod = Session.UserName;
                        }
                        else
                        {
                            while (ItemsDet_Tarifa.FirstOrDefault(tipo => tipo.CTAR_Tipo == TipoTarifa && tipo.TIPE_Codigo == ItemDET_Tarifa.TIPE_Codigo && tipo.ENTC_Codigo == ItemDET_Tarifa.ENTC_Codigo) != null)
                            {
                                var item = ItemsDet_Tarifa.FirstOrDefault(tipo => tipo.CTAR_Tipo == TipoTarifa && tipo.TIPE_Codigo == ItemDET_Tarifa.TIPE_Codigo && tipo.ENTC_Codigo == ItemDET_Tarifa.ENTC_Codigo);
                                ItemsDet_Tarifa.Remove(item);
                            }
                        }
                        ItemsGrillaDet_Tarifa.Remove(ItemDET_Tarifa);

                        //continuar:
                        //foreach (var item in ItemsDet_Tarifa)
                        //{
                        //    if (ItemDET_Tarifa.DTAR_Fila == item.DTAR_Fila)
                        //    {
                        //        if (item.DTAR_Item > 0)
                        //        {
                        //            item.Instance = InstanceEntity.Deleted;
                        //        }
                        //        else
                        //        {
                        //            ItemsDet_Tarifa.Remove(item);
                        //            goto continuar;
                        //        }
                        //    }
                        //}
                    }
                    else
                    {
                        ItemDET_Tarifa.Instance = InstanceEntity.Added;
                        ItemDET_Tarifa.AUDI_UsrCrea = Session.UserName;
                    }
                    //ItemDET_Tarifa = new Det_Tarifa
                    //{
                    //    AUDI_UsrCrea = Session.UserName,
                    //    AUDI_FecCrea = Session.Fecha,
                    //    Instance = InstanceEntity.Added
                    //};
                    DView.GetItem();
                    if (ItemDET_Tarifa.Validar())
                    {
                        if (ItemsDet_Tarifa != null && ItemsDet_Tarifa.Count > 0)
                        {
                            if (ItemDET_Tarifa.TIPE_Codigo != null && ItemDET_Tarifa.TIPE_Codigo.Value.ToString(CultureInfo.InvariantCulture).Equals("13")) //maritimo
                            {
                                const short tipeCodigo = 13;
                                if (ItemsGrillaDet_Tarifa.Count(tipo => tipo.TIPE_Codigo != null && tipo.TIPE_Codigo.Value == tipeCodigo) > 0)
                                {
                                    Dialogos.MostrarMensajeInformacion(Title, "No puede haber mas de un agente maritimo."); return;
                                }
                            }
                            else
                            {
                                if (ItemsGrillaDet_Tarifa.Any(entCodigo => entCodigo.ENTC_Codigo == ItemDET_Tarifa.ENTC_Codigo && entCodigo.TIPE_Codigo == ItemDET_Tarifa.TIPE_Codigo && entCodigo.Instance == InstanceEntity.Added))
                                {
                                    Dialogos.MostrarMensajeInformacion(Title, "No puede haber mas de una entidad duplicada."); return;
                                }
                            }
                        }
                        // if (InstanciaDet_Tarifa == InstanceView.New)
                        ItemsGrillaDet_Tarifa.Add(ItemDET_Tarifa);

                        DView.GenerarST20_ST40_HBL();
                        MView.ShowItemsDetalleTarifario();
                        DView.CerrarVenta();
                    }
                    else
                    {
                        DView.ShowValidation();
                    }
                }
                else   // Tarifa Aduanera || Tarifa Transporte
                {
                    if (InstanciaDet_Tarifa == InstanceView.Edit)
                    {
                        if (ItemDET_Tarifa.DTAR_Item > 0)
                        {
                            ItemDET_Tarifa.AUDI_UsrMod = Session.UserName;
                            ItemDET_Tarifa.Instance = InstanceEntity.Modified;
                        }
                        else
                        {
                            ItemsDet_Tarifa.Remove(ItemDET_Tarifa);
                        }
                    }
                    else
                    {
                        ItemDET_Tarifa.AUDI_UsrCrea = Session.UserName;
                        ItemDET_Tarifa.Instance = InstanceEntity.Added;
                        TempItemDET_Tarifa = new Det_Tarifa
                        {
                            AUDI_UsrCrea = Session.UserName,
                            AUDI_FecCrea = Session.Fecha,
                            Instance = InstanceEntity.Added
                        };
                    }
                    DView.GetItem();
                    if (TempItemDET_Tarifa.Validar())
                    {
                        if (ItemsDet_Tarifa != null && ItemsDet_Tarifa.Count > 0)
                        {
                            if (TempItemDET_Tarifa.CTAR_Tipo.Equals("A"))
                            {
                                if (ItemsDet_Tarifa.Any(codBase => codBase.CONS_CodBas == TempItemDET_Tarifa.CONS_CodBas && codBase.Instance != InstanceEntity.Modified))
                                {
                                    Dialogos.MostrarMensajeInformacion(Title, "No puede haber mas de un base duplicada."); return;
                                }
                            }
                            if (TempItemDET_Tarifa.CTAR_Tipo.Equals("T"))
                            {
                                if (ItemsDet_Tarifa.Any(data => data.CONS_CodTRA == TempItemDET_Tarifa.CONS_CodTRA && data.TIPO_CodZONDestino == TempItemDET_Tarifa.TIPO_CodZONDestino && data.Instance != InstanceEntity.Modified))
                                {
                                    Dialogos.MostrarMensajeInformacion(Title, "No puede haber mas de una mismo tipo y destino."); return;
                                }
                            }
                        }
                        if (ItemsDet_Tarifa != null && InstanciaDet_Tarifa != InstanceView.Edit) ItemsDet_Tarifa.Add(TempItemDET_Tarifa);
                        MView.ShowItemsDetalleTarifario();
                        DView.CerrarVenta();
                    }
                    else
                    {
                        DView.ShowValidation();
                    }
                }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
        }
        public void EditarDetalleTarifa()
        {
            try
            {
                if (ItemDET_Tarifa != null)
                {
                    DView.ClearItem(TipoTarifa);
                    DView.SetItem();
                    InstanciaDet_Tarifa = InstanceView.Edit;
                    DView.SetInstance(InstanceView.Edit);
                    ((PRO001DTarifa)DView).ShowDialog();
                }
                else
                { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
        }
        public void EliminarDetalleTarifario()
        {
            try
            {
                if (ItemDET_Tarifa != null)
                {
                    DialogResult result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
                    if (result == DialogResult.Yes)
                    {
                        if (ItemDET_Tarifa.DTAR_Item > 0)
                        {
                            ItemDET_Tarifa.Instance = InstanceEntity.Deleted;
                        }
                        else
                        {
                            ItemsGrillaDet_Tarifa.Remove(ItemDET_Tarifa);
                        }
                        MView.ShowItemsDetalleTarifario();
                    }
                }
                else
                { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
        }
        #endregion

        #region [ Detalle Servicios ]
        public DataTable GetTodosServicios()
        {
            try
            {
                //return Client.GetAllServicio().ToDataTable();// falta  CAMBIAR A DATATABLE  CON 2 CAMPOS
                return Client.GetServiciosAdicionales(7);
            }
            catch (Exception)
            { return null; }
        }
        public void LoadNuevoDetalleServicioTarifa()
        {
            try
            {
                DSView.ClearItem();
                DSView.SetInstance(InstanceView.New);
                ((PRO001DSMview)DSView).ShowDialog();
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
        }

        private void NuevoDetalleServicioTarifa(String xCtarTipo)
        {
            try
            {
                TempItemDet_TarifaServicio = new Det_Tarifa_Servicio
                {
                    AUDI_UsrCrea = Session.UserName,
                    AUDI_FecCrea = Session.Fecha,
                    Instance = InstanceEntity.Added,
                    CTAR_Tipo = xCtarTipo
                };
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
        }
        public void AgregarDetalleServicioTarifa()
        {
            try
            {
                if (InstanciaDet_TarifaServicio == InstanceView.Edit)
                {
                    if (ItemDet_TarifaServicio.DTAS_Item > 0)
                    {
                        ItemDet_TarifaServicio.Instance = InstanceEntity.Deleted;
                    }
                    else
                    {
                        ItemsDet_TarifaServicio.Remove(ItemDet_TarifaServicio);
                    }
                }
                NuevoDetalleServicioTarifa(TipoTarifa);
                DSView.GetItem();
                if (TempItemDet_TarifaServicio.Validar())
                {
                    ItemsDet_TarifaServicio.Add(TempItemDet_TarifaServicio);
                    MView.ShowItemsDetalleServicios();
                    DSView.CerrarVenta();
                }
                else
                {
                    DSView.ShowValidation();
                }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
        }
        public void EditarServicioDetalleTarifa()
        {
            try
            {
                if (ItemDet_TarifaServicio != null)
                {
                    DSView.ClearItem();
                    DSView.SetItem();
                    DSView.SetInstance(InstanceView.Edit);
                    ((PRO001DSMview)DSView).ShowDialog();
                }
                else
                { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
        }
        public void EliminarDetalleServicioTarifa()
        {
            try
            {
                if (ItemDet_TarifaServicio != null)
                {
                    DialogResult result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
                    if (result == DialogResult.Yes)
                    {
                        if (ItemDet_TarifaServicio.DTAS_Item > 0)
                        {
                            ItemDet_TarifaServicio.Instance = InstanceEntity.Deleted;
                        }
                        else
                        {
                            ItemsDet_TarifaServicio.Remove(ItemDet_TarifaServicio);
                        }
                        MView.ShowItemsDetalleServicios();
                    }
                }
                else
                { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
        }
        #endregion

        #region [ Close ]
        public void CloseView()
        {
            if (isMViewShow)
            { ((PRO001MView)MView).Close(); }
        }
        public void IsClosedMView()
        { isMViewShow = false; }
        #endregion

        #endregion
    }
}
