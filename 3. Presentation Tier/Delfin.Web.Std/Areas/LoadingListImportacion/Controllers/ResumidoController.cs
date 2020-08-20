using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using Kendo.Mvc.Extensions;
using Microsoft.Practices.Unity;

using Infrastructure.Aspect.Importacion;
using Infrastructure.Aspect.Collections;
using Kendo.Mvc.UI;
using Delfin.Web.Std.Areas.LoadingListImportacion.Models;

namespace Delfin.Web.Std.Areas.LoadingListImportacion.Controllers
{
   public class ResumidoController : Delfin.Web.Std.Controllers.BaseController //Controller
   {
      public static ObservableCollection<LoadingListImportacion.Models.LoadingListModel> Items = new ObservableCollection<Models.LoadingListModel>();

      public ActionResult Index()
      {
         Models.LoadingListImportacionModel _model = null;
         if (_model == null) { _model = new Models.LoadingListImportacionModel(); }
         //return RedirectToAction("Index", new { Via = "001", CargaFecha = _model.CargaFecha });
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
                           columna = "HB/L";
                           if (DataTableImportacion.Columns.Contains(columna))
                           {
                              DataTableImportacion.DefaultView.RowFilter = "[" + columna + "] IS NOT NULL";
                              DataTableImportacion = DataTableImportacion.DefaultView.ToTable();
                           }

                           var ContainerService = System.Web.HttpContext.Current.Application["ContainerService"] as UnityContainer;
                           var Client = ContainerService.Resolve<ServiceContracts.IDelfinServices>();

                           ObservableCollection<Entities.LoadingListResumido> _list = new ObservableCollection<Entities.LoadingListResumido>();
                           Entities.LoadingListResumido _item = new Entities.LoadingListResumido();
                           foreach (System.Data.DataRow _DataRowImportacion in DataTableImportacion.Rows)
                           {
                              _item = new Entities.LoadingListResumido();

                              //[POL]              //[LOAD_POL]      
                              columna = "POL";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_POL = _DataRowImportacion[columna].ToString(); }
                              }

                              //[M/V]              //[LOAD_MV]       
                              columna = "M/V";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_MV = _DataRowImportacion[columna].ToString(); }
                              }

                              //[ETD]              //[LOAD_ETD]      
                              columna = "ETD";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 {
                                    DateTime _LOAD_ETD;
                                    if (DateTime.TryParse(_DataRowImportacion[columna].ToString(), out _LOAD_ETD))
                                    { _item.LOAD_ETD = _LOAD_ETD; }
                                 }
                              }

                              //[CARRIER]          //[LOAD_CARRIER]  
                              columna = "CARRIER";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_CARRIER = _DataRowImportacion[columna].ToString(); }
                              }

                              //[BOOKING NO.]      //[LOAD_BOOKING]  
                              columna = "BOOKING NO.";
                              string columna2 = "BOOKING NO#";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_BOOKING = _DataRowImportacion[columna].ToString(); }
                              }
                              else if (DataTableImportacion.Columns.Contains(columna2))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna2].ToString()))
                                 { _item.LOAD_BOOKING = _DataRowImportacion[columna2].ToString(); }
                              }

                              //[MB/L]             //[LOAD_MBL]      
                              columna = "MB/L";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_MBL = _DataRowImportacion[columna].ToString(); }
                              }

                              //[HB/L]             //[LOAD_HBL]      
                              columna = "HB/L";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_HBL = _DataRowImportacion[columna].ToString(); }
                              }

                              //[POD]              //[LOAD_POD]      
                              columna = "POD";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_POD = _DataRowImportacion[columna].ToString(); }
                              }

                              //[O/F TERM]         //[LOAD_OFTERM]    
                              columna = "O/F TERM";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_OFTERM = _DataRowImportacion[columna].ToString(); }
                              }

                              //[CNTR]             //[LOAD_CNTR]     
                              columna = "CNTR";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_CNTR = _DataRowImportacion[columna].ToString(); }
                              }

                              //[SHIPPER]          //[LOAD_SHIPPER]  
                              columna = "SHIPPER";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_SHIPPER = _DataRowImportacion[columna].ToString(); }
                              }

                              //[CONSIGNEE]        //[LOAD_CONSIGNEE]
                              columna = "CONSIGNEE";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_CONSIGNEE = _DataRowImportacion[columna].ToString(); }
                              }

                              //[CODE]             //[LOAD_CODE]     
                              columna = "CODE";
                              if (DataTableImportacion.Columns.Contains(columna))
                              {
                                 if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                 { _item.LOAD_CODE = _DataRowImportacion[columna].ToString(); }
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


                           DateTime LOAD_CargaFecha = DateTime.Now;
                           var culture = System.Globalization.CultureInfo.CreateSpecificCulture("es-PE");
                           if (DateTime.TryParse(x_model.CargaFecha, culture, System.Globalization.DateTimeStyles.None, out LOAD_CargaFecha))
                           {
                              String CONS_TabVIA = "VIA";
                              String CONS_CodVIA = x_model.Via;
                              String LOAD_MensajeError = "";
                              if (Client.SaveLoadingListImportResumido(_list.ToTableValuedParameter(), LOAD_CargaUsuario, LOAD_CargaFecha, CONS_TabVIA, CONS_CodVIA, ref LOAD_MensajeError))
                              {
                                 if (String.IsNullOrEmpty(LOAD_MensajeError))
                                 { x_model.LOAD_MensajeError = "Se ha cargado satisfactoriamente el archivo."; }
                                 else
                                 { x_model.LOAD_MensajeError = LOAD_MensajeError; }

                                 return RedirectToAction("ListImportacion", new { CargaFecha = x_model.CargaFecha });
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
         {
            return View("Index", x_model);
         }
      }

      public ActionResult ListImportacion(String CargaFecha = null, Boolean ShowLoadingListAsociado = true, Boolean ShowLoadingListNoAsociado = true, Boolean ShowOrdenVentaAsociada = true, Int32 LoadingListAsociado = 0, Int32 LoadingListNoAsociado = 0, Int32 OrdenVentaAsociada = 0)
      {
         try
         {

            DateTime _LOAD_CargaFecha;
            var _culture = System.Globalization.CultureInfo.CreateSpecificCulture("es-PE");
            
            Items.Clear();
            
            if (!String.IsNullOrEmpty(CargaFecha) && DateTime.TryParse(CargaFecha, _culture, System.Globalization.DateTimeStyles.None, out _LOAD_CargaFecha))
            {
               var ContainerService = System.Web.HttpContext.Current.Application["ContainerService"] as UnityContainer;
               var Client = ContainerService.Resolve<ServiceContracts.IDelfinServices>();
               var ListLoadingList = Client.GetAllLoadingListImportResumido(_LOAD_CargaFecha).AsQueryable();


               var model = new Models.LoadingListImportacionModel()
               {
                  ShowLoadingListAsociado = ShowLoadingListAsociado,
                  ShowLoadingListNoAsociado = ShowLoadingListNoAsociado,
                  ShowOrdenVentaAsociada = ShowOrdenVentaAsociada,

               };

               // Get the current page of sorted, filtered products
               model.ListLoadingListTotal = ListLoadingList.ToObservableCollection();

               // Filter the results
               ObservableCollection<Entities.LoadingList> _newListLoadingList = new ObservableCollection<Entities.LoadingList>();

               if (ShowLoadingListAsociado)
               {
                  _newListLoadingList = _newListLoadingList.Concat(ListLoadingList.Where(llis => llis.LoadingListAsociado)).ToObservableCollection();
               }
               if (ShowLoadingListNoAsociado)
               {
                  _newListLoadingList = _newListLoadingList.Concat(ListLoadingList.Where(llis => llis.LoadingListNoAsociado)).ToObservableCollection();
               }
               if (ShowOrdenVentaAsociada)
               {
                  _newListLoadingList = _newListLoadingList.Concat(ListLoadingList.Where(llis => llis.OrdenVentaAsociada)).ToObservableCollection();
               }

               model.ListLoadingList = _newListLoadingList;

               LoadingListModel _itemLoadingListModel = new LoadingListModel();
               foreach (var _itemLoadingList in _newListLoadingList)
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

                  Items.Add(_itemLoadingListModel);
               }


               return View(model);
            } else
            {
               Models.LoadingListImportacionModel _model = new Models.LoadingListImportacionModel();
               return View(_model);
            }
         } catch (Exception)
         {
            return View();
         }
      }

      public ActionResult GetLoadingList([DataSourceRequest] DataSourceRequest dsRequest)
      {
         var result = Items.ToDataSourceResult(dsRequest);
         return Json(result);
      }

      private Boolean ValidateArchivo(System.Data.DataTable DataTableImportacion)
      {
         String columna;

         //[POL]              //[LOAD_POL]      
         columna = "POL";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }

         //[M/V]              //[LOAD_MV]       
         columna = "M/V";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }

         //[ETD]              //[LOAD_ETD]      
         columna = "ETD";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }

         //[CARRIER]          //[LOAD_CARRIER]  
         columna = "CARRIER";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }

         //[BOOKING NO.]      //[LOAD_BOOKING]  
         columna = "BOOKING NO.";
         string columna2 = "BOOKING NO#";
         if (!(DataTableImportacion.Columns.Contains(columna) || (DataTableImportacion.Columns.Contains(columna2))))
         { return false; }
         
         //[MB/L]             //[LOAD_MBL]      
         columna = "MB/L";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }

         //[HB/L]             //[LOAD_HBL]      
         columna = "HB/L";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }

         //[POD]              //[LOAD_POD]      
         columna = "POD";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }

         //[O/F TERM]         //[LOAD_OFTERM]    
         columna = "O/F TERM";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }

         //[CNTR]             //[LOAD_CNTR]     
         columna = "CNTR";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }

         //[SHIPPER]          //[LOAD_SHIPPER]  
         columna = "SHIPPER";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }

         //[CONSIGNEE]        //[LOAD_CONSIGNEE]
         columna = "CONSIGNEE";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }

         //[CODE]             //[LOAD_CODE]     
         columna = "CODE";
         if (!DataTableImportacion.Columns.Contains(columna))
         { return false; }

         return true;
      }


      #region [ Partial View ]
      [HttpPost]
      public ActionResult Confirm([DataSourceRequest] DataSourceRequest dsRequest, LoadingListImportacion.Models.LoadingListModel ItemLoadingList, HttpPostedFileBase Archivo)
      {
         if (ItemLoadingList != null && ModelState.IsValid)
         {
            //var target = SessionProductRepository.One(p => p.ProductID == product.ProductID);
            //if (target != null)
            //{
            //   target.ProductName = product.ProductName;
            //   target.UnitPrice = product.UnitPrice;
            //   target.UnitsInStock = product.UnitsInStock;
            //   target.LastSupply = product.LastSupply;
            //   target.Discontinued = product.Discontinued;
            //   SessionProductRepository.Update(target);
            //}
         }

         return Json(ModelState.ToDataSourceResult());
      }

      [HttpPost]
      public ActionResult ConfirmFile([DataSourceRequest] DataSourceRequest dsRequest, LoadingListImportacion.Models.LoadingListModel ItemLoadingList, HttpPostedFileBase Archivo)
      {
         if (Archivo != null)
         {
            Delfin.Web.Std.Util.DistribucionSession distribucionSession = Delfin.Web.Std.AdministracionSession.Obtener();

            var ContainerService = System.Web.HttpContext.Current.Application["ContainerService"] as UnityContainer;
            var Client = ContainerService.Resolve<ServiceContracts.IDelfinServices>();
            
            Delfin.Entities.LoadingList_Files _itemLoadingList_Files = new Entities.LoadingList_Files();
            _itemLoadingList_Files.LOAD_Codigo = ItemLoadingList.LOAD_Codigo.Value;
            _itemLoadingList_Files.ItemFile = new Entities.Files();
            _itemLoadingList_Files.ItemFile.FILE_ContentLenght = Archivo.ContentLength;
            _itemLoadingList_Files.ItemFile.FILE_ContentType = Archivo.ContentType;
            _itemLoadingList_Files.ItemFile.FILE_FileName = Archivo.FileName;
            _itemLoadingList_Files.ItemFile.FILE_InputStream = ReadToEnd(Archivo.InputStream);

            _itemLoadingList_Files.AUDI_UsrCrea = distribucionSession.usuario;
            _itemLoadingList_Files.AUDI_FecCrea = DateTime.Now;
            
            _itemLoadingList_Files.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

            Client.SaveLoadingList_Files(ref _itemLoadingList_Files);

         }

         //var result = Items.ToDataSourceResult(dsRequest);
         //return Json(result);

         return RedirectToAction("ListImportacion", new { CargaFecha = ItemLoadingList.LOAD_CargaFecha.HasValue ? ItemLoadingList.LOAD_CargaFecha.Value.ToShortDateString() : null});
         
      }

      private static byte[] ReadToEnd(System.IO.Stream stream)
      {
         long originalPosition = 0;

         if (stream.CanSeek)
         {
            originalPosition = stream.Position;
            stream.Position = 0;
         }

         try
         {
            byte[] readBuffer = new byte[4096];

            int totalBytesRead = 0;
            int bytesRead;

            while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
            {
               totalBytesRead += bytesRead;

               if (totalBytesRead == readBuffer.Length)
               {
                  int nextByte = stream.ReadByte();
                  if (nextByte != -1)
                  {
                     byte[] temp = new byte[readBuffer.Length * 2];
                     Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                     Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                     readBuffer = temp;
                     totalBytesRead++;
                  }
               }
            }

            byte[] buffer = readBuffer;
            if (readBuffer.Length != totalBytesRead)
            {
               buffer = new byte[totalBytesRead];
               Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
            }
            return buffer;
         }
         finally
         {
            if (stream.CanSeek)
            {
               stream.Position = originalPosition;
            }
         }
      }
      #endregion
   }
}
