using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Delfin.Controls;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Aspect.Collections;
using Microsoft.Practices.Unity;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using Infrastructure.WinFormsControls;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
   public class PRO008Presenter
   {
      #region [ Variables ]
      public String Title = "Facturación Proveedores";
      public String CUS = "LOG008";

      private Parametros m_ItemParametros;
      private Parametros m_ItemsParametros;
      private CtaCte m_itemLView;
      private CtaCte m_ItemCtaCte;
      private DetCtaCte m_ItemDetCtaCte;
      private ObservableCollection<CtaCte> m_ItemsCtaCte;
      private ObservableCollection<DetCtaCte> m_ItemsDetCtaCte;
      private ObservableCollection<Det_Operacion> m_Items_Det_Operacion;
      private ObservableCollection<Det_Operacion_Servicio> m_Items_Det_Operacion_Servicio;
      public Int32 COPE_Codigo { get; set; }
      public Int32 CCCT_Codigo { get; set; }
      public Int32 ENTC_Codigo { get; set; }
      public Int16 TIPE_CodigoServicio { get; set; }
      public String CTAR_Tipo { get; set; }
      public Boolean TipoFiltroFechas { get; set; }
      public Decimal _CostoServicio { get; set; }
      public Decimal _CostoDetServicio { get; set; }
      public DateTime CCCT_Desde { get; set; }
      public DateTime CCCT_Hasta { get; set; }
      public String TMovimiento { get; set; }

      public DataTable _DT;

      #endregion

      #region [ Encabezado Facturacion ]

      public CtaCte ItemLView
      {
         get { return m_itemLView; }
         set { m_itemLView = value; }
      }
      public CtaCte ItemCtaCte
      {
         get { return m_ItemCtaCte; }
         set { m_ItemCtaCte = value; }
      }
      public Parametros ItemParametros
      {
         get { return m_ItemParametros; }
         set { m_ItemParametros = value; }
      }
      public Cab_Operacion ItemOperacion { get; set; }
      public ObservableCollection<Parametros> ItemsParametros { get; set; }
      public ObservableCollection<CtaCte> ItemsCtaCte { get; set; }
      public ObservableCollection<DetCtaCte> ItemsDetCtaCte { get; set; }
      public ObservableCollection<Det_Operacion> ItemsDet_Operacion { get; set; }
      public ObservableCollection<Det_Operacion_Servicio> ItemsDet_Operacion_Servicio { get; set; }

      #endregion

      #region [ Constructor ]
      public PRO008Presenter(IUnityContainer x_container, IPRO008LView x_lview, IPRO008MView x_mview)
      {
         try
         {
            ContainerService = x_container;
            Session = ContainerService.Resolve<ISessionService>();
            LView = x_lview;
            MView = x_mview;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.ConstructorPresenter, ex); }
      }

      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<Delfin.ServiceContracts.IDelfinServices>();

            LView.LoadView();
            MView.LoadView();

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.LoadPresenter, ex); }
      }

      public DataTable LoadAyudaOperacion(String x_Numero)
      {
         try
         {
            return Client.GetAyudaOperacionXNumero(x_Numero);
         }
         catch (Exception) { return null; }
      }

      public DataTable LoadServicio(String x_Moneda, Decimal x_TipoCambio)
      {
         try
         {
            return Client.GetAyudaOperacionXProveedor(COPE_Codigo, x_Moneda, x_TipoCambio, CCCT_Codigo);
         }
         catch (Exception) { return null; }
      }

      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public Delfin.ServiceContracts.IDelfinServices Client { get; set; }
      public IPRO008LView LView { get; set; }
      public IPRO008MView MView { get; set; }
      Boolean isMViewShow = false;
      public Int32 Position { set; get; }

      #region [ Encabezado Facturacion ]

      public Decimal CalculaIGV(Decimal _Valor)
      {
         try
         {
            ItemsParametros = Client.GetAllParametros();
            String PARA_Clave = "IGV";
            ItemParametros = ItemsParametros.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            return _Valor * (Convert.ToDecimal(ItemParametros.PARA_Valor.ToString()) / 100);
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex);
            return 0;
         }
      }

      public Decimal TCporDia(String _Fecha)
      {
         TiposCambio _TC = Client.GetOneTiposCambio(_Fecha);
         if (_TC == null)
            return 0;
         else
            return _TC.TIPC_Compra;
      }

      public void Nuevo()
      {
         try
         {
            if (!isMViewShow)
            {
               MView = new PRO008MView();
               MView.Presenter = this;
               MView.LoadView();
            }

            MView.ClearItem();
            ItemCtaCte = new CtaCte
            {
               AUDI_UsrCrea = Session.UserName,
               AUDI_FecCrea = Session.Fecha,
               TIPE_Codigo = 2,
               TIPO_TabFPG = "FPG",
               TIPO_TabMND = "MND",
               TIPO_TabTDO = "TDO",
               Instance = InstanceEntity.Added,
            };
            TIPE_CodigoServicio = 2;
            ItemCtaCte.CCCT_FechaRecepcion = Client.GetFecha();
            ItemCtaCte.EMPR_Codigo = Entorno.ItemEmpresa.EMPR_Codigo;
            MView.SetInstance(InstanceView.New);
            //((PRO008MView)MView).ShowDialog();
            isMViewShow = true;
            if (LView != null) { ((PRO008MView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
            ((PRO008MView)MView).Show();
            ((PRO008MView)MView).BringToFront();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }

      public void Editar(Int32 x_CCCT_Codigo)
      {
         try
         {
            if (!isMViewShow)
            {
               MView = new PRO008MView();
               MView.Presenter = this;
               MView.LoadView();
            }
            MView.ClearItem();
            /* Encabezado Seguimiento  :) */
            ItemCtaCte = Client.GetOneCtaCte(Entorno.ItemEmpresa.EMPR_Codigo, x_CCCT_Codigo, CtaCte.TInterfazCtaCte.RegistroSLI);
            CCCT_Codigo = x_CCCT_Codigo;
            ItemCtaCte.AUDI_UsrMod = Session.UserName;
            ItemCtaCte.AUDI_FecMod = Session.Fecha;
            ItemCtaCte.Instance = InstanceEntity.Modified;
            ItemOperacion = Client.GetOneCab_Operacion(ItemCtaCte.COPE_Codigo);
            this.TMovimiento = ItemCtaCte.TMovimiento == CtaCte.TipoMovimiento.Ingreso ? "I" : "E";

            MView.SetItem();
            MView.SetInstance(InstanceView.Edit);
            isMViewShow = true;
            if (LView != null) { ((PRO008MView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
            ((PRO008MView)MView).Show();
            ((PRO008MView)MView).BringToFront();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
      }

      public void Eliminar(Int32 x_CCCT_Codigo, Int16 x_EMPR_Codigo)
      {
         try
         {
            DialogResult result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
            if (result == DialogResult.Yes)
            {
               ItemLView = new CtaCte();
               ItemLView.CCCT_Codigo = x_CCCT_Codigo;
               ItemLView.EMPR_Codigo = x_EMPR_Codigo;
               ItemLView.Instance = InstanceEntity.Deleted;
               ItemLView.AUDI_UsrMod = Session.UserName;
               if (Client.SaveCtaCte(ref m_itemLView, CtaCte.TInterfazCtaCte.RegistroSLI))
               {
                  Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                  Actualizar(true);
               }
               else
               { Dialogos.MostrarMensajeInformacion(Title, "No se ha podido eliminar el item debido a que ya se encuentra relacionado."); }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
      }

      public Boolean BuscarDetraccion(String x_TipoDoc, String x_Serie, String x_NroDoc, Int32 x_CodProve)
      {
         try { return Client.GetCtaCteDoc_Detraccion(x_TipoDoc, x_Serie, x_NroDoc, x_CodProve); }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private Boolean Validar(ref String x_msg)
      {
         try
         {
            Boolean _iscorrect = true;
            x_msg = "";

            if (ItemCtaCte.NoDomiciliado)
            {
               if (String.IsNullOrEmpty(ItemCtaCte.TIPO_CodTI3))
               {
                  x_msg = String.Format("- Le Entidad {1} es no Domiciliado, por lo que no debe tener IGV.{0}", Environment.NewLine);
                  _iscorrect = false;
               }
            }

            return _iscorrect;
         }
         catch (Exception)
         { throw; }
      }

      private bool ValidarRenta3ra(ref String _msg)
      {
         try
         {
            Boolean _rpt = true;
            _msg = "";

            Decimal _MontoBase = ItemCtaCte.CCCT_ValVta.Value;
            Decimal _imp2 = ItemCtaCte.CCCT_Imp2.Value;
            Decimal _porcentaje = ItemCtaCte.CCCT_PorcImp2.Value;
            Decimal _val = 0;
            _val = -Math.Round(_MontoBase * (_porcentaje / 100), 2, MidpointRounding.AwayFromZero);
            if (_imp2 < _val)
            { _msg = String.Format("El importe de Renta de 3ra es Menor al {0}% del tipo de renta seleccionado, desea continuar", _porcentaje); _rpt = false; }
            else if (_imp2 > _val)
            { _msg = String.Format("El importe de Renta de 3ra es Mayor al {0}% del tipo de renta seleccionado, desea continuar", _porcentaje); _rpt = false; }

            return _rpt;
         }
         catch (Exception)
         { throw; }
      }

      public bool Guardar(String x_DOPE_Items)
      {
         try
         {
            MView.GetItem();

            if (MView.ConvertColeccion())
            {
               ItemCtaCte.Entidad = ENTC_Codigo;
               ItemCtaCte.CTAR_Tipo = CTAR_Tipo;
               ItemCtaCte.COPE_Codigo = COPE_Codigo;
               ItemCtaCte.TIPE_CodigoServicio = TIPE_CodigoServicio;
               ItemCtaCte.ListDet_Operacion = ItemsDet_Operacion;
               ItemCtaCte.TMovimiento = TMovimiento.Equals("I") ? CtaCte.TipoMovimiento.Ingreso : CtaCte.TipoMovimiento.Egreso;
               if (ItemCtaCte.CCCT_TipoCambio == 0)
               {
                  Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar Tipo de Cambio del día.");
                  return false;
               }
               else
               {
                  if (ItemCtaCte.Validar())
                  {
                     if (ItemCtaCte.Instance == InstanceEntity.Added)
                     {
                         //Valida Duplicidad
                        if (BuscarDetraccion(ItemCtaCte.TIPO_CodTDO, ItemCtaCte.CCCT_Serie, ItemCtaCte.CCCT_Numero, ItemCtaCte.ENTC_Codigo.Value))
                        {
                           Dialogos.MostrarMensajeError(Title, "El documento ya existe, verifique por favor.");
                           return false;
                        }
                     }
                     if (!String.IsNullOrEmpty(ItemCtaCte.TIPO_CodTI3))
                     {
                        String _msg = "";
                        if (!ValidarRenta3ra(ref _msg))
                        {
                           if (!(Dialogos.MostrarMensajePregunta(Title, _msg, Dialogos.LabelBoton.Si_No) == DialogResult.Yes))
                           {
                              return false;
                           }
                        }
                     }
                     String _voucher = Client.SaveCtaCteSLI(ref m_ItemCtaCte, x_DOPE_Items);
                     if (!String.IsNullOrEmpty(_voucher))
                     {
                        //Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                         Dialogos.MostrarMensajeSatisfactorio(Title, "Se actualizó el registro: " + _voucher);
                        Actualizar(false);
                        return true;
                     }
                     Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                     return false;
                  }
                  MView.ShowValidation();
                  return false;
               }
            }
            else
            {
               Dialogos.MostrarMensajeInformacion(Title, "Debe de Seleccionar al menos un servicio");
               return false;
            }
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Title, Mensajes.SavePresenter, ex);
            return false;
         }
      }

      public void Actualizar(bool ActualizarBaseDatos = true)
      {
         try
         {
            if (ActualizarBaseDatos)
            {
               ItemLView = null;
               ItemCtaCte = null;
               ItemsCtaCte = null;
               LView.FiltrosLView();
               _DT = Client.GetCtaCteFiltros(CCCT_Desde, CCCT_Hasta, ENTC_Codigo, TipoFiltroFechas);
            }
            else
            {
               if (ItemCtaCte.Instance == InstanceEntity.Added)
               {
                  if (_DT == null)
                  {
                     _DT = new DataTable();
                     _DT.Columns.Add(new DataColumn("EMPR_Codigo", typeof(Int16)));
                     _DT.Columns.Add(new DataColumn("CCCT_Codigo", typeof(Int32)));
                     _DT.Columns.Add(new DataColumn("CCCT_FechaEmision", typeof(DateTime)));
                     _DT.Columns.Add(new DataColumn("CCCT_Serie", typeof(String)));
                     _DT.Columns.Add(new DataColumn("CCCT_Numero", typeof(String)));
                     _DT.Columns.Add(new DataColumn("CCCT_ValVta", typeof(Decimal)));
                     _DT.Columns.Add(new DataColumn("CCCT_Imp1", typeof(Decimal)));
                     _DT.Columns.Add(new DataColumn("ENTC_Codigo", typeof(Int32)));
                     _DT.Columns.Add(new DataColumn("CCCT_Monto", typeof(Decimal)));
                     _DT.Columns.Add(new DataColumn("COPE_NumDoc", typeof(String)));
                     _DT.Columns.Add(new DataColumn("COPE_HBL", typeof(String)));
                     _DT.Columns.Add(new DataColumn("ENTC_CodCliente", typeof(Int32)));
                     _DT.Columns.Add(new DataColumn("COPE_Estado", typeof(String)));
                     _DT.Columns.Add(new DataColumn("TIPO_Moneda", typeof(String)));
                     _DT.Columns.Add(new DataColumn("TIPO_Documento", typeof(String)));
                     _DT.Columns.Add(new DataColumn("Proveedor", typeof(String)));
                     _DT.Columns.Add(new DataColumn("CCCT_Saldo", typeof(Decimal)));
                     _DT.Columns.Add(new DataColumn("Cliente", typeof(String)));
                     _DT.Columns.Add(new DataColumn("CCCT_FecReg", typeof(DateTime)));
                     _DT.Columns.Add(new DataColumn("TIPO", typeof(String)));
                     _DT.Columns.Add(new DataColumn("SERVICIO", typeof(String)));
                     _DT.Columns.Add(new DataColumn("Detraccion", typeof(String)));
                  }
                  DataRow NuevoRegistro = _DT.NewRow();
                  DataTable DT = Client.GetOneCtaCteDT(Entorno.ItemEmpresa.EMPR_Codigo, ItemCtaCte.CCCT_Codigo);
                  if (DT != null)
                  {
                     for (int i = 0; i < _DT.Columns.Count; i++)
                     {
                        NuevoRegistro[_DT.Columns[i].ColumnName] = DT.Rows[0][_DT.Columns[i].ColumnName];
                     }
                     _DT.Rows.Add(NuevoRegistro);
                  }
               }
               else if (ItemCtaCte.Instance == InstanceEntity.Modified)
               {
                  var ItemResultado = _DT.Select("CCCT_Codigo =" + ItemCtaCte.CCCT_Codigo);
                  if (ItemResultado != null)
                  {
                     Position = _DT.Rows.IndexOf(ItemResultado[0]);
                     var Result = Client.GetOneCtaCteDT(Entorno.ItemEmpresa.EMPR_Codigo, Int32.Parse(ItemResultado[0]["CCCT_Codigo"].ToString()));
                     if (Result != null)
                     {
                        for (int i = 0; i < _DT.Columns.Count; i++)
                        {
                           _DT.Rows[Position][_DT.Columns[i].ColumnName] = Result.Rows[0][_DT.Columns[i].ColumnName];
                        }
                     }
                  }
               }
            }
            LView.ShowItems();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }
      #endregion

      #endregion

      #region [ Metodos ]

      public void CloseView()
      {
         if (isMViewShow)
         { ((PRO008MView)MView).Close(); }
      }
      public void IsClosedMView()
      { isMViewShow = false; }

      #endregion
   }
}
