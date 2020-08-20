using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Aspect.Importacion;
using Infrastructure.Aspect.Collections;
using Microsoft.Practices.Unity;
using System.Collections.ObjectModel;
using System.IO;

using System.Data.Linq;
//using System.Linq.Dynamic;

namespace Delfin.Web.Controllers
{
   public class HomeController : Controller
   {
      [Authorize]
      public ActionResult Index()
      {
         ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";


         Models.LoadingListModel _model = new Models.LoadingListModel();
         return View(_model);
      }

      [Authorize]
      [HttpPost]
      public ActionResult UploadFile(Models.LoadingListModel x_model)
      {
         try
         {
            String _fileName = "";

            if (x_model.file != null && !String.IsNullOrEmpty(x_model.file.FileName))
            {
               //_fileName = x_model.file.FileName;

               if (x_model.file != null && x_model.file.ContentLength > 0)
               {
                  var fileName = Path.GetFileName(x_model.file.FileName);
                  _fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                  x_model.file.SaveAs(_fileName);

                  ImportarExcel excel = new ImportarExcel();
                  String _message = "";
                  //System.Data.DataTable DataTableImportacion = excel.ReadExcel(_fileName, ref _message);
                  System.Data.DataTable DataTableImportacion = excel.Excel(_fileName, ref _message);

                  System.IO.File.Delete(_fileName);

                  if (DataTableImportacion != null && DataTableImportacion.Rows.Count > 0)
                  {
                     var ContainerService = System.Web.HttpContext.Current.Application["ContainerService"] as UnityContainer;
                     var Client = ContainerService.Resolve<ServiceContracts.IDelfinServices>();

                     ObservableCollection<Entities.LoadingListResumido> _list = new ObservableCollection<Entities.LoadingListResumido>();
                     Entities.LoadingListResumido _item = new Entities.LoadingListResumido();
                     String columna = "";
                     foreach (System.Data.DataRow _DataRowImportacion in DataTableImportacion.Rows)
                     {
                        _item = new Entities.LoadingListResumido();

                        //[POL]              //[LOAD_POL]      
                        //[M/V]              //[LOAD_MV]       
                        //[ETD]              //[LOAD_ETD]      
                        //[CARRIER]          //[LOAD_CARRIER]  
                        //[BOOKING NO.]      //[LOAD_BOOKING]  
                        //[MB/L]             //[LOAD_MBL]      
                        //[HB/L]             //[LOAD_HBL]      
                        //[POD]              //[LOAD_POD]      
                        //[20']              
                        //[40']              
                        //[40'HQ]            
                        //[40'NOR]           
                        //[O/F TERM]         //[LOAD_OFTERM]    
                        //[CNTR]             //[LOAD_CNTR]     
                        //[SHIPPER]          //[LOAD_SHIPPER]  
                        //[CONSIGNEE]        //[LOAD_CONSIGNEE]
                        //[CODE]             //[LOAD_CODE]     

                        columna = "POL";
                        if (DataTableImportacion.Columns.Contains(columna))
                        {
                           if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                           { _item.LOAD_POL = _DataRowImportacion[columna].ToString(); }
                        }

                        columna = "M/V";
                        if (DataTableImportacion.Columns.Contains(columna))
                        {
                           if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                           { _item.LOAD_MV = _DataRowImportacion[columna].ToString(); }
                        }

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

                        columna = "CARRIER";
                        if (DataTableImportacion.Columns.Contains(columna))
                        {
                           if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                           { _item.LOAD_CARRIER = _DataRowImportacion[columna].ToString(); }
                        }

                        columna = "BOOKING NO.";
                        if (DataTableImportacion.Columns.Contains(columna))
                        {
                           if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                           { _item.LOAD_BOOKING = _DataRowImportacion[columna].ToString(); }
                        }

                        columna = "MB/L";
                        if (DataTableImportacion.Columns.Contains(columna))
                        {
                           if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                           { _item.LOAD_MBL = _DataRowImportacion[columna].ToString(); }
                        }

                        columna = "HB/L";
                        if (DataTableImportacion.Columns.Contains(columna))
                        {
                           if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                           { _item.LOAD_HBL = _DataRowImportacion[columna].ToString(); }
                        }

                        columna = "POD";
                        if (DataTableImportacion.Columns.Contains(columna))
                        {
                           if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                           { _item.LOAD_POD = _DataRowImportacion[columna].ToString(); }
                        }

                        columna = "O/F TERM";
                        if (DataTableImportacion.Columns.Contains(columna))
                        {
                           if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                           { _item.LOAD_OFTERM = _DataRowImportacion[columna].ToString(); }
                        }

                        columna = "CNTR";
                        if (DataTableImportacion.Columns.Contains(columna))
                        {
                           if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                           { _item.LOAD_CNTR = _DataRowImportacion[columna].ToString(); }
                        }

                        columna = "SHIPPER";
                        if (DataTableImportacion.Columns.Contains(columna))
                        {
                           if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                           { _item.LOAD_SHIPPER = _DataRowImportacion[columna].ToString(); }
                        }

                        columna = "CONSIGNEE";
                        if (DataTableImportacion.Columns.Contains(columna))
                        {
                           if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                           { _item.LOAD_CONSIGNEE = _DataRowImportacion[columna].ToString(); }
                        }

                        columna = "CODE";
                        if (DataTableImportacion.Columns.Contains(columna))
                        {
                           if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                           { _item.LOAD_CODE = _DataRowImportacion[columna].ToString(); }
                        }

                        _list.Add(_item);
                     }

                     if (User != null && User.Identity != null)
                     {
                        Entities.LoadingList _itemLoadingList = new Entities.LoadingList();
                        if (x_model.NVIA_Codigo.HasValue)
                        { _itemLoadingList.NVIA_Codigo = x_model.NVIA_Codigo.Value; }
                        _itemLoadingList.LOAD_CargaUsuario = User.Identity.Name;
                        _itemLoadingList.LOAD_CargaFecha = DateTime.Now;

                        x_model.ListLoadingList = Client.SaveLoadingListImportResumido(ref _itemLoadingList, _list.ToTableValuedParameter());


                        string sortBy = "ProductName"; 
                        bool ascending = true; 
                        int page = 1; 
                        int pageSize = 10; 
                        int? categoryId = null;
                        decimal minPrice = 0M; 
                        bool? omitDiscontinued = null;

                        var model = new Models.LoadingListGridModel()
                        {
                           // Sorting-related properties
                           SortBy = sortBy,
                           SortAscending = ascending,

                           // Paging-related properties
                           CurrentPageIndex = page,
                           PageSize = pageSize,

                           // Paging-related properties
                           //CategoryId = categoryId,
                           //MinPrice = minPrice,
                           //OmitDiscontinued = omitDiscontinued.HasValue ? omitDiscontinued.Value : false,
                           //CategoryList = this.DataContext.Categories
                           //                                .OrderBy(c => c.CategoryName)
                           //                                .Select(c =>
                           //                                        new SelectListItem
                           //                                        {
                           //                                           Text = c.CategoryName,
                           //                                           Value = c.CategoryID.ToString()
                           //                                        }
                           //                                 )
                        };

                        // Filter the results
                        //var filteredResults = this.DataContext.Products.AsQueryable();

                        //if (categoryId != null)
                        //   filteredResults = filteredResults.Where(p => p.CategoryID == categoryId.Value);
                        //if (minPrice > 0M)
                        //   filteredResults = filteredResults.Where(p => p.UnitPrice >= minPrice);
                        //if (omitDiscontinued != null && omitDiscontinued.Value == true)
                        //   filteredResults = filteredResults.Where(p => p.Discontinued == false);

                        // Determine the total number of FILTERED products being paged through (needed to compute PageCount)
                        model.TotalRecordCount = x_model.ListLoadingList.Count();

                        // Get the current page of sorted, filtered products
                        model.ListLoadingList = x_model.ListLoadingList
                                                    //.OrderBy(model.SortExpression)
                                                    .Skip((model.CurrentPageIndex - 1) * model.PageSize)
                                                    .Take(model.PageSize);

                        //return View(model);

                        return RedirectToAction("Index", x_model.NVIA_Codigo);
                     }
                  }
               }
            }
            return RedirectToAction("Index");
         }
         catch (Exception ex)
         {
            x_model.LOAD_Error = ex.Message;
            return RedirectToAction("Index", x_model);
         }
      }

      [Authorize]
      public ActionResult Import(Int32 NVIA_Codigo = -1,string sortBy = "ProductName",bool ascending = true,int page = 1,int pageSize = 10,int? categoryId = null,decimal minPrice = 0M,bool? omitDiscontinued = null)
      {
         try
         {

            var ContainerService = System.Web.HttpContext.Current.Application["ContainerService"] as UnityContainer;
            var Client = ContainerService.Resolve<ServiceContracts.IDelfinServices>();
            var ListLoadingList = Client.GetAllLoadingListImportResumido(NVIA_Codigo).AsQueryable();


            var model = new Models.LoadingListGridModel()
            {
               NVIA_Codigo = NVIA_Codigo,

               // Sorting-related properties
               SortBy = sortBy,
               SortAscending = ascending,

               // Paging-related properties
               CurrentPageIndex = page,
               PageSize = pageSize,

               // Paging-related properties
               //CategoryId = categoryId,
               //MinPrice = minPrice,
               //OmitDiscontinued = omitDiscontinued.HasValue ? omitDiscontinued.Value : false,
               //CategoryList = this.DataContext.Categories
               //                                .OrderBy(c => c.CategoryName)
               //                                .Select(c =>
               //                                        new SelectListItem
               //                                        {
               //                                           Text = c.CategoryName,
               //                                           Value = c.CategoryID.ToString()
               //                                        }
               //                                 )
            };

            // Filter the results
            //var filteredResults = this.DataContext.Products.AsQueryable();

            //if (categoryId != null)
            //   filteredResults = filteredResults.Where(p => p.CategoryID == categoryId.Value);
            //if (minPrice > 0M)
            //   filteredResults = filteredResults.Where(p => p.UnitPrice >= minPrice);
            //if (omitDiscontinued != null && omitDiscontinued.Value == true)
            //   filteredResults = filteredResults.Where(p => p.Discontinued == false);

            // Determine the total number of FILTERED products being paged through (needed to compute PageCount)
            model.TotalRecordCount = ListLoadingList.Count();

            // Get the current page of sorted, filtered products
            model.ListLoadingList = ListLoadingList
                                    //.OrderBy(model.SortExpression)
                                    .Skip((model.CurrentPageIndex - 1) * model.PageSize)
                                    .Take(model.PageSize);

            return View(model);
         }
         catch (Exception ex)
         {
            return RedirectToAction("Index");
         }

      }
   }
}
