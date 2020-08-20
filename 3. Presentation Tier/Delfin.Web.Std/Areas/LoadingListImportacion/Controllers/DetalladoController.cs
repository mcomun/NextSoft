using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using Microsoft.Practices.Unity;

using Infrastructure.Aspect.Importacion;
using Infrastructure.Aspect.Collections;

namespace Delfin.Web.Std.Areas.LoadingListImportacion.Controllers
{
   public class DetalladoController : Delfin.Web.Std.Controllers.BaseController  //Controller
   {
      //
      // GET: /LoadingListImportacion/Detallado/

      public ActionResult Index()
      {
         Models.LoadingListImportacionModel _model = new Models.LoadingListImportacionModel();
         return View(_model);
      }

      [HttpPost]
      public ActionResult UploadFile(Models.LoadingListImportacionModel x_model)
      {
         try
         {
            x_model.LOAD_MensajeError = null;
            if (!ModelState.IsValid)
            {
               String _LOAD_MensajeError = "";
               if (String.IsNullOrEmpty(x_model.Via))
               { _LOAD_MensajeError += "* Debe seleccionar la Vía"; }
               if (String.IsNullOrEmpty(x_model.CargaFecha))
               { _LOAD_MensajeError += "* Debe ingresar la Fecha de Carga (dd/mm/yyyy)"; }

               DateTime _LOAD_CargaFecha = DateTime.Now;
               var _culture = System.Globalization.CultureInfo.CreateSpecificCulture("es-PE");
               if (!DateTime.TryParse(x_model.CargaFecha, _culture, System.Globalization.DateTimeStyles.None, out _LOAD_CargaFecha))
               { _LOAD_MensajeError += "* Debe ingresar una fecha válida de Carga (dd/mm/yyyy)"; }

               if (x_model.Archivo == null || String.IsNullOrEmpty(x_model.Archivo.FileName))
               { _LOAD_MensajeError += "* Debe seleccionar el archivo de importación"; }

               if (!String.IsNullOrEmpty(_LOAD_MensajeError))
               { x_model.LOAD_MensajeError = _LOAD_MensajeError; }

               return View("Index", x_model);
            }
            else
            {
               String _fileName = "";

               if (x_model.Archivo != null && !String.IsNullOrEmpty(x_model.Archivo.FileName))
               {
                  //_fileName = x_model.file.FileName;

                  if (x_model.Archivo != null && x_model.Archivo.ContentLength > 0 && (Path.GetExtension(x_model.Archivo.FileName) == ".xls" || Path.GetExtension(x_model.Archivo.FileName) == ".xlsx"))
                  {
                     var fileName = Path.GetFileName(x_model.Archivo.FileName);
                     _fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                     x_model.Archivo.SaveAs(_fileName);

                     ImportarExcel excel = new ImportarExcel();
                     String _message = "";
                     //System.Data.DataTable DataTableImportacion = excel.ReadExcel(_fileName, ref _message);
                     System.Data.DataTable DataTableImportacion = excel.Excel(_fileName, ref _message);

                     System.IO.File.Delete(_fileName);

                     if (DataTableImportacion != null && DataTableImportacion.Rows.Count > 0)
                     {
                        foreach (System.Data.DataColumn _column in DataTableImportacion.Columns)
                        { _column.ColumnName = _column.ColumnName.Trim().ToUpper(); }

                        if (ValidateArchivo(DataTableImportacion))
                        {
                           String columna = "";
                           columna = "HBL";
                           if (DataTableImportacion.Columns.Contains(columna))
                           {
                              DataTableImportacion.DefaultView.RowFilter = columna + " IS NOT NULL";
                              DataTableImportacion = DataTableImportacion.DefaultView.ToTable();
                           }

                           var ContainerService = System.Web.HttpContext.Current.Application["ContainerService"] as UnityContainer;
                           var Client = ContainerService.Resolve<ServiceContracts.IDelfinServices>();

                           ObservableCollection<Entities.LoadingListDetallado> _list = new ObservableCollection<Entities.LoadingListDetallado>();
                           Entities.LoadingListDetallado _item = new Entities.LoadingListDetallado();

                           foreach (System.Data.DataRow _DataRowImportacion in DataTableImportacion.Rows)
                           {
                              _item = new Entities.LoadingListDetallado();

                              //RO NO.UP	            =>    LOAD_RONOUP
                              columna = "RO NO.UP";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_RONOUP = _DataRowImportacion[columna].ToString(); }
                              }
                              //FOLLOWUP	            =>    LOAD_FOLLOWUP
                              columna = "FOLLOWUP";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_FOLLOWUP = _DataRowImportacion[columna].ToString(); }
                              }
                              //SHIPPER NAME	         =>    LOAD_SHIPPER
                              columna = "SHIPPER NAME";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_SHIPPER = _DataRowImportacion[columna].ToString(); }
                              }
                              //CONSIGNEE NAME	      =>    LOAD_CONSIGNEE
                              columna = "CONSIGNEE NAME";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_CONSIGNEE = _DataRowImportacion[columna].ToString(); }
                              }
                              //NOTIFY NAME	         =>    LOAD_NOTIFY
                              columna = "NOTIFY NAME";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_NOTIFY = _DataRowImportacion[columna].ToString(); }
                              }
                              //POL	                  =>    LOAD_POL
                              columna = "POL";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_POL = _DataRowImportacion[columna].ToString(); }
                              }
                              //POL_NAME               =>    LOAD_POLNAME
                              columna = "POL_NAME";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_POLNAME = _DataRowImportacion[columna].ToString(); }
                              }
                              //POD	                  =>    LOAD_POD
                              columna = "POD";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_POD = _DataRowImportacion[columna].ToString(); }
                              }
                              //POD_NAME               =>    LOAD_PODNAME
                              columna = "POD_NAME";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_PODNAME = _DataRowImportacion[columna].ToString(); }
                              }
                              //CARRIER	               =>    LOAD_CARRIER
                              columna = "CARRIER";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_CARRIER = _DataRowImportacion[columna].ToString(); }
                              }
                              //BOOKINGNBR	            =>    LOAD_BOOKING
                              columna = "BOOKINGNBR";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_BOOKING = _DataRowImportacion[columna].ToString(); }
                              }
                              //MBL	                  =>    LOAD_MBL
                              columna = "MBL";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_MBL = _DataRowImportacion[columna].ToString(); }
                              }
                              //HBL	                  =>    LOAD_HBL
                              columna = "HBL";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_HBL = _DataRowImportacion[columna].ToString(); }
                              }
                              //ETD	                  =>    LOAD_ETD
                              columna = "ETD";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 DateTime _LOAD_ETD;
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()) && DateTime.TryParse(_DataRowImportacion[columna].ToString(), out _LOAD_ETD))
                                 { _item.LOAD_ETD = _LOAD_ETD; }
                              }
                              //ETA	                  =>    LOAD_ETA
                              columna = "ETA";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 DateTime _LOAD_ETA;
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()) && DateTime.TryParse(_DataRowImportacion[columna].ToString(), out _LOAD_ETA))
                                 { _item.LOAD_ETA = _LOAD_ETA; }
                              }
                              //CNTRTYPE	            =>    LODE_TIPOCNT
                              columna = "CNTRTYPE";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LODE_TIPOCNT = _DataRowImportacion[columna].ToString(); }
                              }
                              //CNTRSIZE	            =>    LODE_TAMANIOCNTR
                              columna = "CNTRSIZE";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LODE_TAMANIOCNTR = _DataRowImportacion[columna].ToString(); }
                              }
                              //CNTR ID	               =>    LODE_NUMEROCNTR
                              columna = "CNTR ID";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LODE_NUMEROCNTR = _DataRowImportacion[columna].ToString(); }
                              }
                              //SEAL NUMBER	         =>    LODE_PRECINTO
                              columna = "SEAL NUMBER";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LODE_PRECINTO = _DataRowImportacion[columna].ToString(); }
                              }//HAZARDOUS	            =>    LODE_CARGAPELIGROSA
                              columna = "HAZARDOUS";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LODE_CARGAPELIGROSA = _DataRowImportacion[columna].ToString(); }
                              }
                              //IMO CLASS	            =>    LODE_IMOCLASS
                              columna = "IMO CLASS";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LODE_IMOCLASS = _DataRowImportacion[columna].ToString(); }
                              }
                              //GROSS WEIGHT	         =>    LODE_PESOBRUTO
                              columna = "GROSS WEIGHT";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 Decimal _LODE_PESOBRUTO;
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()) && Decimal.TryParse(_DataRowImportacion[columna].ToString(), out _LODE_PESOBRUTO))
                                 { _item.LODE_PESOBRUTO = _LODE_PESOBRUTO; }
                              }
                              //PACK TYPE              =>    LODE_PACKTYPE
                              columna = "PACK TYPE";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LODE_PACKTYPE = _DataRowImportacion[columna].ToString(); }
                              }
                              //PACK QTY	            =>    LODE_CANTBULTOS
                              columna = "PACK QTY";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 Decimal _LODE_CANTBULTOS;
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()) && Decimal.TryParse(_DataRowImportacion[columna].ToString(), out _LODE_CANTBULTOS))
                                 { _item.LODE_CANTBULTOS = _LODE_CANTBULTOS; }
                              }
                              //VOLUME	               =>    LODE_VOLUMEN
                              columna = "VOLUME";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 Decimal _LODE_VOLUMEN;
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()) && Decimal.TryParse(_DataRowImportacion[columna].ToString(), out _LODE_VOLUMEN))
                                 { _item.LODE_VOLUMEN = _LODE_VOLUMEN; }
                              }
                              //COMMODITY DESCRIPTION  =>    LODE_DESCCARGA
                              columna = "COMMODITY DESCRIPTION";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LODE_DESCCARGA = _DataRowImportacion[columna].ToString(); }
                              }
                              //MARKS & NUMBERS	      =>    LODE_MARCASNUMEROS
                              columna = "MARKS & NUMBERS";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LODE_MARCASNUMEROS = _DataRowImportacion[columna].ToString(); }
                              }
                              //CONTRACT CODE          =>    LOAD_CONTRACTCODE                         
                              columna = "CONTRACT CODE";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_CONTRACTCODE = _DataRowImportacion[columna].ToString(); }
                              }

                              _list.Add(_item);
                           }

                           //if (User != null && User.Identity != null)
                           //{
                           //Entities.LoadingList _itemLoadingList = new Entities.LoadingList();
                           //if (x_model.Viaje.HasValue)
                           //{ _itemLoadingList.NVIA_Codigo = x_model.Viaje.Value; }
                           //_itemLoadingList.LOAD_CargaUsuario = User.Identity.Name;
                           //_itemLoadingList.LOAD_CargaFecha = DateTime.Now;

                           Delfin.Web.Std.Util.DistribucionSession distribucionSession = Delfin.Web.Std.AdministracionSession.Obtener();
                           var sUsuario = distribucionSession.usuario;

                           String LOAD_CargaUsuario = sUsuario;

                           //String LOAD_CargaUsuario = User.Identity.Name;
                           DateTime LOAD_CargaFecha = DateTime.Now;
                           var culture = System.Globalization.CultureInfo.CreateSpecificCulture("es-PE");
                           if (DateTime.TryParse(x_model.CargaFecha, culture, System.Globalization.DateTimeStyles.None, out LOAD_CargaFecha))
                           {
                              String CONS_TabVIA = "VIA";
                              String CONS_CodVIA = x_model.Via;
                              String LOAD_MensajeError = "";

                              if (Client.SaveLoadingListImportDetallado(_list.ToTableValuedParameter(), LOAD_CargaUsuario, LOAD_CargaFecha, CONS_TabVIA, CONS_CodVIA, ref LOAD_MensajeError))
                              {
                                 if (String.IsNullOrEmpty(LOAD_MensajeError))
                                 { x_model.LOAD_MensajeError = "Se ha cargado satisfactoriamente el archivo."; }
                                 else
                                 { x_model.LOAD_MensajeError = LOAD_MensajeError; }

                                 return View("Index", x_model);

                                 //return RedirectToAction("ListImportacion", new { CargaFecha = x_model.CargaFecha }); 
                              }
                              else
                              {
                                 x_model.LOAD_MensajeError = LOAD_MensajeError;
                                 return View("Index", x_model);
                              }
                           }
                           else
                           {
                              x_model.LOAD_MensajeError = "* Debe ingresar una fecha válida de Carga (dd/mm/yyyy)";
                              return View("Index", x_model);
                           }

                           //}
                        }
                        else
                        {
                           x_model.LOAD_MensajeError = "El archivo seleccionado no contiene las columnas según el formato.";
                           return View("Index", x_model);
                        }
                     }
                     else
                     {
                        //NO TIENE REGISTROS
                        x_model.LOAD_MensajeError = "* El archivo seleccionado no devolvio ningún registro, seleccione otro archivo.";
                        return View("Index", x_model);
                     }
                  }
                  else
                  {
                     //ARCHIVO INCORRECTO
                     x_model.LOAD_MensajeError = "* El archivo seleccionado no es correcto, debe ingresar un Archivo de Excel (*.xls, *.xlsx)";
                     return View("Index", x_model);
                  }
               }
               return View("Index", x_model);
            }
         }
         catch (Exception)
         { return View("Index", x_model); }
      }

      public ActionResult ListImportacion(String CargaFecha = null, string sortBy = "LOAD_HBL", bool ascending = true, int page = 1, int pageSize = 10, Boolean ShowLoadingListAsociado = true, Boolean ShowLoadingListNoAsociado = true, Boolean ShowOrdenVentaAsociada = true, Int32 LoadingListAsociado = 0, Int32 LoadingListNoAsociado = 0, Int32 OrdenVentaAsociada = 0)
      {
         try
         {
            DateTime _LOAD_CargaFecha;
            var _culture = System.Globalization.CultureInfo.CreateSpecificCulture("es-PE");
            if (!String.IsNullOrEmpty(CargaFecha) && DateTime.TryParse(CargaFecha, _culture, System.Globalization.DateTimeStyles.None, out _LOAD_CargaFecha))
            {
               var ContainerService = System.Web.HttpContext.Current.Application["ContainerService"] as UnityContainer;
               var Client = ContainerService.Resolve<ServiceContracts.IDelfinServices>();
               var ListLoadingList = Client.GetAllLoadingListImportDetallado(_LOAD_CargaFecha).AsQueryable();


               var model = new Models.LoadingListImportacionModel()
               {
                  CargaFecha = CargaFecha,

                  // Sorting-related properties
                  SortBy = sortBy,
                  SortAscending = ascending,

                  // Paging-related properties
                  CurrentPageIndex = page,
                  PageSize = pageSize,

                  // Paging-related properties
                  ShowLoadingListAsociado = ShowLoadingListAsociado,
                  ShowLoadingListNoAsociado = ShowLoadingListNoAsociado,
                  ShowOrdenVentaAsociada = ShowOrdenVentaAsociada,

               };

               // Get the current page of sorted, filtered products
               model.ListLoadingListDetalladoTotal = ListLoadingList.ToObservableCollection();

               // Filter the results
               ObservableCollection<Entities.LoadingListDetallado> _newListLoadingList = new ObservableCollection<Entities.LoadingListDetallado>();
               _newListLoadingList = _newListLoadingList.Concat(ListLoadingList).ToObservableCollection();

               //if (ShowLoadingListAsociado)
               //{ _newListLoadingList = _newListLoadingList.Concat(ListLoadingList.Where(llis => llis.LoadingListAsociado)).ToObservableCollection(); }
               //if (ShowLoadingListNoAsociado)
               //{ _newListLoadingList = _newListLoadingList.Concat(ListLoadingList.Where(llis => llis.LoadingListNoAsociado)).ToObservableCollection(); }
               //if (ShowOrdenVentaAsociada)
               //{ _newListLoadingList = _newListLoadingList.Concat(ListLoadingList.Where(llis => llis.OrdenVentaAsociada)).ToObservableCollection(); }


               //ListLoadingList = ListLoadingList.Where( llis=> llis.LoadingListAsociado == ShowLoadingListAsociado
               //                                              ^ llis.LoadingListNoAsociado == ShowLoadingListNoAsociado
               //                                              ^ llis.OrdenVentaAsociada == ShowOrdenVentaAsociada);

               // Determine the total number of FILTERED products being paged through (needed to compute PageCount)
               model.TotalRecordCount = _newListLoadingList.Count();

               model.ListLoadingListDetallado = (_newListLoadingList
                                                .OrderBy(model.SortExpression)
                                                .Skip((model.CurrentPageIndex - 1) * model.PageSize)
                                                .Take(model.PageSize)).ToObservableCollection();

               return View(model);
            }
            return View();
         }
         catch (Exception)
         { return View(); }
      }

      private Boolean ValidateArchivo(System.Data.DataTable DataTableImportacion)
      {
         String columna;

         //RO NO.UP	            =>    LOAD_RONOUP
         columna = "RO NO.UP";
         //if (!DataTableImportacion.Columns.Contains(columna))
         //{ return false; }
         //FOLLOWUP	            =>    LOAD_FOLLOWUP
         columna = "FOLLOWUP";
         //if (!DataTableImportacion.Columns.Contains(columna))
         //{ return false; }
         //SHIPPER NAME	         =>    LOAD_SHIPPER
         columna = "SHIPPER NAME";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //CONSIGNEE NAME	      =>    LOAD_CONSIGNEE
         columna = "CONSIGNEE NAME";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //NOTIFY NAME	         =>    LOAD_NOTIFY
         columna = "NOTIFY NAME";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //POL	                  =>    LOAD_POL
         columna = "POL";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //POL_NAME               =>    LOAD_POLNAME
         columna = "POL_NAME";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //POD	                  =>    LOAD_POD
         columna = "POD";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //POD_NAME               =>    LOAD_PODNAME
         columna = "POD_NAME";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //CARRIER	               =>    LOAD_CARRIER
         columna = "CARRIER";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //BOOKINGNBR	            =>    LOAD_BOOKING
         columna = "BOOKINGNBR";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //MBL	                  =>    LOAD_MBL
         columna = "MBL";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //HBL	                  =>    LOAD_HBL
         columna = "HBL";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //ETD	                  =>    LOAD_ETD
         columna = "ETD";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //ETA	                  =>    LOAD_ETA
         columna = "ETA";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //CNTRTYPE	            =>    LODE_TIPOCNT
         columna = "CNTRTYPE";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //CNTRSIZE	            =>    LODE_TAMANIOCNTR
         columna = "CNTRSIZE";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //CNTR ID	               =>    LODE_NUMEROCNTR
         columna = "CNTR ID";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //SEAL NUMBER	         =>    LODE_PRECINTO
         columna = "SEAL NUMBER";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //HAZARDOUS	            =>    LODE_CARGAPELIGROSA
         columna = "HAZARDOUS";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //IMO CLASS	            =>    LODE_IMOCLASS
         columna = "IMO CLASS";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //GROSS WEIGHT	         =>    LODE_PESOBRUTO
         columna = "GROSS WEIGHT";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //PACK TYPE              =>    LODE_PACKTYPE
         columna = "PACK TYPE";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //PACK QTY	            =>    LODE_CANTBULTOS
         columna = "PACK QTY";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //VOLUME	               =>    LODE_VOLUMEN
         columna = "VOLUME";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //COMMODITY DESCRIPTION  =>    LODE_DESCCARGA
         columna = "COMMODITY DESCRIPTION";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //MARKS & NUMBERS	      =>    LODE_MARCASNUMEROS
         columna = "MARKS & NUMBERS";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }
         //CONTRACT CODE          =>    LOAD_CONTRACTCODE                         
         columna = "CONTRACT CODE";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }



         return true;
      }
   }
}