using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Forms;

namespace Delfin.Comercial
{
   public class MAN004Presenter
   {
      #region [ Variables ]
      public String Title = "Mantenimiento de Servicios";
      public String CUS = "MAN004";
      #endregion

      #region [ Contrusctor ]
      public MAN004Presenter(IUnityContainer x_container, IMAN004LView x_lview, IMAN004MView x_mview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
            this.MView = x_mview;
         }
         catch (Exception)
         { throw; }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();

            /************** Servicios/Documentos *****************/
            Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.AddComboBoxItem("I", "INGRESO", true);
            Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.AddComboBoxItem("C", "COSTO");
            ListIngresoCosto = Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.GetComboBoxItems();
            ListTiposTDO = Client.GetAllTiposByTipoCodTabla("TDO");
            /*****************************************************/

            DSPeriodos = new DataSet();
            DSPeriodos = Client.GetDSDocsVta("CON_CENTSS_PeriodosDisponibles", null);

            string x_year = Client.GetFecha().Year.ToString();

            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TIPO_CodTabla", FilterValue = "OPE", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TIPO_ano", FilterValue = x_year, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Tipo", FilterValue = "V", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });

            DSTiposOPE = Client.GetDSDocsVta("CON_TABLSS_TodosPorTipo", _listFilters);

            _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TIPO_CodTabla", FilterValue = "OPE", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TIPO_ano", FilterValue = x_year, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Tipo", FilterValue = "C", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });

            DSTiposOPE_Costo = Client.GetDSDocsVta("CON_TABLSS_TodosPorTipo", _listFilters);

            LoadParameteres();

            LView.LoadView();
            MView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      //ObservableCollection<Servicio> _MyProperty;
      //public int Otra { get; set; }
      //public ObservableCollection<Servicio> MyProperty
      //{
      //   get
      //   {
      //      if (_MyProperty == null) { _MyProperty = new ObservableCollection<Servicio>(); }
      //      return _MyProperty;
      //   }
      //   set
      //   {
      //      _MyProperty = value;

      //      if (_MyProperty == null)
      //      {
      //         Otra = _MyProperty.Count();
      //      }
      //   }
      //}
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public IMAN004LView LView { get; set; }
      public IMAN004MView MView { get; set; }

      public Servicio Item { get; set; }
      public ObservableCollection<Servicio> Items { get; set; }

      //public ServiciosDocumentos Item { get; set; }
      //public ObservableCollection<ServiciosDocumentos> Items { get; set; }

      public Constantes FILTROItemVia { get; set; }
      public Constantes FILTROItemRegimen { get; set; }
      public Constantes FILTROItemLineaNegocio { get; set; }
      public Constantes FILTROItemTipoServicio { get; set; }

      public Boolean FILTROItemIGV { get; set; }
      public Boolean FILTROItemDetraccion { get; set; }

      public System.Data.DataSet DSPeriodos { get; set; }
      public System.Data.DataSet DSTiposOPE { get; set; }
      public System.Data.DataSet DSTiposOPE_Costo { get; set; }

      #endregion

      #region [ Parámetros ]

      /*********** TIPOS DE DOCUMENTOS (TDO) ****************/
      public Entities.Parametros PARA_TDO_FACTURA { get; set; }
      public Entities.Parametros PARA_TDO_BOLETAVENTA { get; set; }
      public Entities.Parametros PARA_TDO_INVOICE { get; set; }
      public Entities.Parametros PARA_TDO_NOTACREDITO { get; set; }
      public Entities.Parametros PARA_TDO_NOTADEBITO { get; set; }
      public Entities.Parametros PARA_TDO_LIQUIDACION { get; set; }
      public Entities.Parametros PARA_TDO_GUIAAEREA { get; set; }
      public Entities.Parametros PARA_TDO_RECIBOCAJA { get; set; }
      public Entities.Parametros PARA_TDO_BL { get; set; }
      /******************************************************/
      public void LoadParameteres()
      {
         try
         {
            var ItemsPARAMETRO = Client.GetAllParametros();

            /*********** TIPOS DE DOCUMENTOS (TDO) ****************/
            PARA_TDO_FACTURA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "FACTURA");
            PARA_TDO_BOLETAVENTA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "BOLETA_VENTA");
            PARA_TDO_INVOICE = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "INVOICE");
            PARA_TDO_NOTACREDITO = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "NOTA_CREDITO");
            PARA_TDO_NOTADEBITO = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "NOTA_DEBITO");
            PARA_TDO_LIQUIDACION = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "LIQUIDACION");
            PARA_TDO_GUIAAEREA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "GUIA_AEREA");
            PARA_TDO_RECIBOCAJA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "RECIBO_CAJA");
            PARA_TDO_BL = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "BL");
            /******************************************************/
         }
         catch (Exception)
         { throw; }
      }
      #endregion

      #region [ Metodos ]
      public void Actualizar()
      {
         try
         {
            Item = null;
            Items = null;

            String CONS_TabVia = null;
            String CONS_CodVia = null;
            String CONS_TabRGM = null;
            String CONS_CodRGM = null;

            String CONS_TabLNG = null;
            String CONS_CodLNG = null;
            String SERV_TipoMov = null;

            Boolean SERV_AfeIgv = false; if (FILTROItemIGV != null) { SERV_AfeIgv = FILTROItemIGV; }
            Boolean SERV_AfeDet = false; if (FILTROItemDetraccion != null) { SERV_AfeDet = FILTROItemDetraccion; }

            if (FILTROItemRegimen != null)
            {
               CONS_TabRGM = FILTROItemRegimen.CONS_CodTabla;
               CONS_CodRGM = FILTROItemRegimen.CONS_CodTipo;
            }
            if (FILTROItemVia != null)
            {


               CONS_TabVia = FILTROItemVia.CONS_CodTabla;
               CONS_CodVia = FILTROItemVia.CONS_CodTipo;
            }

            if (FILTROItemLineaNegocio != null)
            {
               CONS_TabLNG = FILTROItemLineaNegocio.CONS_CodTabla;
               CONS_CodLNG = FILTROItemLineaNegocio.CONS_CodTipo;
            }

            if (FILTROItemTipoServicio != null)
            {

               SERV_TipoMov = FILTROItemTipoServicio.CONS_CodTipo;
            }



            Items = Client.GetAllServicioByFiltros(true, CONS_TabVia, CONS_CodVia, CONS_TabRGM, CONS_CodRGM, CONS_TabLNG, CONS_CodLNG, SERV_TipoMov, SERV_AfeIgv, SERV_AfeDet);

            LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }
      public void Nuevo()
      {
         try
         {
            MView.ClearItem();
            this.Item = new Servicio();
            this.Item.ServiciosDocumentos = new ObservableCollection<ServiciosDocumentos>();
            this.Item.ServiciosDocumentosDelete = new ObservableCollection<ServiciosDocumentos>();
            this.Item.SERV_Tipo = "";
            this.Item.SERV_FrecFac = "";

            if (FILTROItemRegimen != null)
            {
               this.Item.CONS_TabRGM = FILTROItemRegimen.CONS_CodTabla;
               this.Item.CONS_CodRGM = FILTROItemRegimen.CONS_CodTipo;
            }
            if (FILTROItemVia != null)
            {
               this.Item.CONS_TabVia = FILTROItemVia.CONS_CodTabla;
               this.Item.CONS_CodVia = FILTROItemVia.CONS_CodTipo;
            }

            this.Item.AUDI_UsrCrea = Session.UserName;
            this.Item.AUDI_FecCrea = Session.Fecha;
            this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            MView.SetItem();

            ((MAN004MView)MView).ShowDialog();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }
      public void Editar()
      {
         try
         {
            if (Item != null)
            {
               Int32 _SERV_Codigo = Item.SERV_Codigo;
               Item = new Servicio();
               Item = Client.GetOneServicio(_SERV_Codigo);
               MView.ClearItem();
               //this.Item.ServiciosDocumentos = new ObservableCollection<ServiciosDocumentos>();
               this.Item.ServiciosDocumentosDelete = new ObservableCollection<ServiciosDocumentos>();
               this.Item.AUDI_UsrMod = Session.UserName;
               this.Item.AUDI_FecMod = Session.Fecha;
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
               MView.SetItem();

               ((MAN004MView)MView).ShowDialog();
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
                  if (Client.SaveServicio(Item))
                  {
                     Actualizar();
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al eliminar el item porque pueda que tenga relaciones activas."); }
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex); }
      }
      public bool Guardar()
      {
         try
         {
            MView.GetItem();
            if (Item.Validar())
            {
               string l_mensaje = null;
               if (Item.SERV_Flete == true) { l_mensaje = ValidarExistencia(Item); }
               if (string.IsNullOrEmpty(l_mensaje))
               {
                  if (Client.SaveServicio(Item))
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                     Actualizar();
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
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, l_mensaje);
                  return false;
               }
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Se han encontrado algunos errores, revisar los detalles.", Item.MensajeError);
               MView.ShowValidation();
               return false;
            }
         }
         catch (Exception ex)
         {
            string errorMsg = Delfin.Controls.Utils.getErrorMsg(ex);
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, errorMsg, ex);
            //Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
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
                  if (Guardar())
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
      private String ValidarExistencia(Servicio x_item)
      {
         try
         {
            String _MenssaggeError = String.Empty;
            _MenssaggeError = Client.CheckServicio(x_item);
            return _MenssaggeError;

         }
         catch (Exception ex)
         { throw ex; }
      }

      public Boolean AyudaCentroCto(String x_CENT_Ano, ref String x_CENT_Codigo, ref String x_CENT_Desc)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CENT_Ano", FilterValue = x_CENT_Ano, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CENT_Codigo", FilterValue = x_CENT_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 17 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CENT_Desc", FilterValue = x_CENT_Desc, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 50 });

            System.Data.DataTable dtAyuda = new System.Data.DataTable();
            dtAyuda = Client.GetDTChequera("CON_CENTSS_TodosAyuda", _listFilters);

            if (dtAyuda.Rows.Count == 0)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias."); }
            else if (dtAyuda.Rows.Count == 1)
            {
               x_CENT_Ano = dtAyuda.Rows[0]["TIPO_TabPaisOrigen"].ToString();
               x_CENT_Desc = dtAyuda.Rows[0]["CENT_Desc"].ToString();
               x_CENT_Codigo = dtAyuda.Rows[0]["CENT_Codigo"].ToString();
               return true;
            }
            else
            {
               int i = 0;
               List<Infrastructure.WinForms.Controls.ColumnaAyuda> _columnas = new List<Infrastructure.WinForms.Controls.ColumnaAyuda>();
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "CENT_Ano",
                  ColumnCaption = "Año",
                  Alineacion = DataGridViewContentAlignment.MiddleCenter,
                  Width = 60,
                  DataType = typeof(System.String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "CENT_Codigo",
                  ColumnCaption = "Código",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 100,
                  DataType = typeof(System.String),
                  Format = null
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "CENT_Desc",
                  ColumnCaption = "Descripción",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 250,
                  DataType = typeof(System.String),
                  Format = null
               });

               Infrastructure.WinForms.Controls.Ayuda x_Ayuda = new Infrastructure.WinForms.Controls.Ayuda("Ayuda - Centros de Costo", dtAyuda, false, _columnas);

               if (x_Ayuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                  x_CENT_Ano = x_Ayuda.Respuesta.Rows[0]["CENT_Ano"].ToString();
                  x_CENT_Codigo = x_Ayuda.Respuesta.Rows[0]["CENT_Codigo"].ToString();
                  x_CENT_Desc = x_Ayuda.Respuesta.Rows[0]["CENT_Desc"].ToString();
                  return true;
               }
               else { throw new Exception("Error en el dialogo de Ayuda de Horarios Disponibles"); }
            }
         }
         catch (Exception)
         { throw; }
         return false;
      }
      #endregion

      #region [ Servicios/Documentos ]

      #region[ Propiedades]
      public ObservableCollection<Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem> ListIngresoCosto { get; set; }
      public ObservableCollection<Tipos> ListTiposTDO { get; set; }
      #endregion

      #endregion
   }
}
