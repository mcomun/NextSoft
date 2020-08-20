using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delfin.Web.Models
{
   public class LoadingListGridModel
   {
      // Constructor
      public LoadingListGridModel()
        {
            // Define any default values here...
            this.PageSize = 10;
            this.NumericPageCount = 10;
            //this.OmitDiscontinued = false;
        }


        // Data properties
        public IEnumerable<Entities.LoadingList> ListLoadingList { get; set; }

        public Int32 NVIA_Codigo { get; set; }

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


        //// Filtering-related properties
        //public int? CategoryId { get; set; }
        //public decimal MinPrice { get; set; }
        //public bool OmitDiscontinued { get; set; }
        //public IEnumerable<SelectListItem> CategoryList { get; set; }
   }
}