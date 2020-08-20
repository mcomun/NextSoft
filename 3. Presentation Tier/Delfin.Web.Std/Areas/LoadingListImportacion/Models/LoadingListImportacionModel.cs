using System;
//using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

using Delfin.Entities;
using Delfin.ServiceProxy;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using System.Web;
using System.Linq;
using System.Collections.Generic;

namespace Delfin.Web.Std.Areas.LoadingListImportacion.Models
{
   public class LoadingListImportacionModel
   {
      //[Required]
      [Display(Name = "Viaje")]
      public Nullable<Int32> Viaje { get; set; }

      //[Required]
      //[DataType(DataType.DateTime)]
      //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
      //public DateTime CargaFecha { get; set; }

      [Required]
      [Display(Name = "CargaFecha")]
      public String CargaFecha { get; set; }
      
      [Required]
      [Display(Name = "Archivo")]
      public HttpPostedFileBase Archivo { get; set; }

      [Required]
      [Display(Name = "Vía")]
      public String Via { get; set; }


      public String LOAD_MensajeError { get; set; }

      private List<SelectListItem> m_listContantesVIA;
      public List<SelectListItem> ListContantesVIA
      {
         get
         {
            if (m_listContantesVIA == null)
            {
               m_listContantesVIA = new List<SelectListItem>();

               var ContainerService = System.Web.HttpContext.Current.Application["ContainerService"] as UnityContainer;
               var Client = ContainerService.Resolve<ServiceContracts.IDelfinServices>();
               ObservableCollection<Constantes> _listContantesVIA = Client.GetAllConstantesByConstanteTabla("VIA");
               foreach (Entities.Constantes _itemConstenteVIA in _listContantesVIA)
               { m_listContantesVIA.Add(new SelectListItem() { Value = _itemConstenteVIA.CONS_CodTipo, Text = _itemConstenteVIA.CONS_Desc_SPA }); }
            }
            return m_listContantesVIA;
         }
      }

      [Display(Name = "LoadingListAsociado")]
      public String LoadingListAsociado
      { get { return ListLoadingListTotal.Where(llis => llis.LoadingListAsociado).Count().ToString(); } }

      [Display(Name = "LoadingListNoAsociado")]
      public String LoadingListNoAsociado
      { get { return ListLoadingListTotal.Where(llis => llis.LoadingListNoAsociado).Count().ToString(); } }

      [Display(Name = "OrdenVentaAsociada")]
      public String OrdenVentaAsociada
      { get { return ListLoadingListTotal.Where(llis => llis.OrdenVentaAsociada).Count().ToString(); } }

      [Display(Name = "ShowLoadingListAsociado")]
      public Boolean ShowLoadingListAsociado { get; set; }

      [Display(Name = "ShowLoadingListNoAsociado")]
      public Boolean ShowLoadingListNoAsociado { get; set; }

      [Display(Name = "ShowOrdenVentaAsociada")]
      public Boolean ShowOrdenVentaAsociada { get; set; }


      // Constructor
      public LoadingListImportacionModel()
      {
         if (ListContantesVIA != null && ListContantesVIA.Count > 0)
         { Via = ListContantesVIA[0].Value; }
         CargaFecha = DateTime.Now.ToString("dd/MM/yyyy");

         // Define any default values here...
         this.PageSize = 10;
         this.NumericPageCount = 10;

         //this.LoadingListAsociado = "";
         //this.LoadingListNoAsociado = "";
         //this.OrdenVentaAsociada = "";

         this.ShowLoadingListAsociado = true;
         this.ShowLoadingListNoAsociado = true;
         this.ShowOrdenVentaAsociada = true;
      }

      // Data properties
      //public IEnumerable<Entities.LoadingList> ListLoadingList { get; set; }
      #region [ Listas Resumido ]
      private ObservableCollection<Entities.LoadingList> m_listLoadingList;
      public ObservableCollection<Entities.LoadingList> ListLoadingList
      {
         get
         {
            if (m_listLoadingList == null) { m_listLoadingList = new ObservableCollection<LoadingList>(); }
            return m_listLoadingList;
         }
         set { m_listLoadingList = value; }
      }

      private ObservableCollection<Entities.LoadingList> m_listLoadingListTotal;
      public ObservableCollection<Entities.LoadingList> ListLoadingListTotal
      {
         get
         {
            if (m_listLoadingListTotal == null) { m_listLoadingListTotal = new ObservableCollection<LoadingList>(); }
            return m_listLoadingListTotal;
         }
         set { m_listLoadingListTotal = value; }
      }

      private ObservableCollection<LoadingListModel> m_listLoadingListModel;
      public ObservableCollection<LoadingListModel> ListLoadingListModel
      {
         get
         {
            if (m_listLoadingListModel == null)
            {
               m_listLoadingListModel = new ObservableCollection<LoadingListModel>();

               if (ListLoadingList != null)
               {
                  LoadingListModel _itemLoadingListModel = new LoadingListModel();

                  foreach (Entities.LoadingList _itemLoadingList in ListLoadingList)
                  {
                     _itemLoadingListModel = null;
                     _itemLoadingListModel = new LoadingListModel();

                     _itemLoadingListModel.LOAD_Codigo = _itemLoadingList.LOAD_Codigo;
                     _itemLoadingListModel.LOAD_Shipper = _itemLoadingList.LOAD_Shipper;
                     _itemLoadingListModel.LOAD_Consignee = _itemLoadingList.LOAD_Consignee;
                     _itemLoadingListModel.LOAD_Notify = _itemLoadingList.LOAD_Notify;
                     _itemLoadingListModel.LOAD_Carrier = _itemLoadingList.LOAD_Carrier;
                     _itemLoadingListModel.LOAD_Booking = _itemLoadingList.LOAD_Booking;
                     _itemLoadingListModel.LOAD_MBL = _itemLoadingList.LOAD_MBL;
                     _itemLoadingListModel.LOAD_HBL = _itemLoadingList.LOAD_HBL;
                     _itemLoadingListModel.LOAD_ETA = _itemLoadingList.LOAD_ETA;
                     _itemLoadingListModel.LOAD_ETD = _itemLoadingList.LOAD_ETD;
                     _itemLoadingListModel.LOAD_Payment = _itemLoadingList.LOAD_Payment;
                     _itemLoadingListModel.LOAD_NaveViaje = _itemLoadingList.LOAD_NaveViaje;
                     _itemLoadingListModel.CCOT_Numero = _itemLoadingList.CCOT_Numero;
                     _itemLoadingListModel.CCOT_Tipo = _itemLoadingList.CCOT_Tipo;
                     _itemLoadingListModel.LOAD_ContractNRO = _itemLoadingList.LOAD_ContractNRO;
                     _itemLoadingListModel.LOAD_PrimerUsuario = _itemLoadingList.LOAD_PrimerUsuario;
                     _itemLoadingListModel.LOAD_SegundoOK = _itemLoadingList.LOAD_SegundoOK;
                     _itemLoadingListModel.LOAD_SegundoUsuario = _itemLoadingList.LOAD_SegundoUsuario;
                     _itemLoadingListModel.LOAD_CargaUsuario = _itemLoadingList.LOAD_CargaUsuario;
                     _itemLoadingListModel.LOAD_PrimerOK = _itemLoadingList.LOAD_PrimerOK;
                     _itemLoadingListModel.LOAD_Error = _itemLoadingList.LOAD_Error;
                     _itemLoadingListModel.LOAD_EnvioCorreo = _itemLoadingList.LOAD_EnvioCorreo;
                     _itemLoadingListModel.LOAD_EnvioCorreoFecha = _itemLoadingList.LOAD_EnvioCorreoFecha;
                     _itemLoadingListModel.LOAD_EnvioCorreoUsuario = _itemLoadingList.LOAD_EnvioCorreoUsuario;
                     _itemLoadingListModel.LOAD_ErrorDescripcion = _itemLoadingList.LOAD_ErrorDescripcion;
                     _itemLoadingListModel.LOAD_CargaFecha = _itemLoadingList.LOAD_CargaFecha;
                     _itemLoadingListModel.PUER_CodOrigen = _itemLoadingList.PUER_CodOrigen;
                     _itemLoadingListModel.PUER_CodDestino = _itemLoadingList.PUER_CodDestino;
                     _itemLoadingListModel.LOAD_FecPrimerOK = _itemLoadingList.LOAD_FecPrimerOK;
                     _itemLoadingListModel.LOAD_FecSegundoOK = _itemLoadingList.LOAD_FecSegundoOK;
                     _itemLoadingListModel.NVIA_Codigo = _itemLoadingList.NVIA_Codigo;
                     _itemLoadingListModel.LOAD_FecDevolucion = _itemLoadingList.LOAD_FecDevolucion;
                     _itemLoadingListModel.CCOT_NumDoc = _itemLoadingList.CCOT_NumDoc;
                     _itemLoadingListModel.NVIA_NroViaje = _itemLoadingList.NVIA_NroViaje;
                     _itemLoadingListModel.NVIA_NroManifiesto = _itemLoadingList.NVIA_NroManifiesto;
                     _itemLoadingListModel.PUER_NomOrigen = _itemLoadingList.PUER_NomOrigen;
                     _itemLoadingListModel.PUER_NomDestino = _itemLoadingList.PUER_NomDestino;

                     m_listLoadingListModel.Add(_itemLoadingListModel);
                  }

               }

            }
            return m_listLoadingListModel;
         }
         set { m_listLoadingListModel = value; }
      }
      #endregion

      #region [ Listas Detallado ]
      private ObservableCollection<Entities.LoadingListDetallado> m_listLoadingListDetallado;
      public ObservableCollection<Entities.LoadingListDetallado> ListLoadingListDetallado
      {
         get
         {
            if (m_listLoadingListDetallado == null) { m_listLoadingListDetallado = new ObservableCollection<LoadingListDetallado>(); }
            return m_listLoadingListDetallado;
         }
         set { m_listLoadingListDetallado = value; }
      }

      private ObservableCollection<Entities.LoadingListDetallado> m_listLoadingListDetalladoTotal;
      public ObservableCollection<Entities.LoadingListDetallado> ListLoadingListDetalladoTotal
      {
         get
         {
            if (m_listLoadingListDetalladoTotal == null) { m_listLoadingListDetalladoTotal = new ObservableCollection<LoadingListDetallado>(); }
            return m_listLoadingListDetalladoTotal;
         }
         set { m_listLoadingListDetalladoTotal = value; }
      }
      #endregion
      
      // Sorting-related properties
      public string SortBy { get; set; }
      public bool SortAscending { get; set; }
      public string SortExpression
      {
         get
         {
            return this.SortAscending ? this.SortBy + " asc" : this.SortBy + " desc";
         }
      }

      // Paging-related properties
      public int CurrentPageIndex { get; set; }
      public int PageSize { get; set; }
      public int TotalRecordCount { get; set; }
      public int PageCount
      {
         get
         {
            return Math.Max(this.TotalRecordCount / this.PageSize, 1);
         }
      }
      public int NumericPageCount { get; set; }

   }
}