using System;
using System.Collections.Generic;
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

namespace Delfin.Web.Models
{
   public class LoadingListModel
   {
      [Required]
      [Display(Name = "Regímen")]
      public Nullable<Int32> NVIA_Codigo { get; set; }

      //[Required]
      //[Display(Name = "Regímen")]
      //public String CONS_CodRGM { get; set; }

      //[Required]
      //[Display(Name = "Vía")]
      //public String CONS_CodVIA { get; set; }

      [Required]
      [Display(Name = "Mensaje Error")]
      public String LOAD_Error { get; set; }


      [Required]
      [Display(Name = "Archivo")]
      public HttpPostedFileBase file { get; set; }

      private ObservableCollection<Entities.LoadingList> m_listLoadingList;

      public ObservableCollection<Entities.LoadingList> ListLoadingList
      {
         get {
            if (m_listLoadingList == null) { m_listLoadingList = new ObservableCollection<LoadingList>(); }
            return m_listLoadingList; }
         set { m_listLoadingList = value; }
      }
      

      //private List<SelectListItem> m_listContantesRGM;
      //public List<SelectListItem> ListContantesRGM 
      //{
      //   get 
      //   {
      //      if (m_listContantesRGM == null)
      //      {
      //         m_listContantesRGM = new List<SelectListItem>();

      //         var ContainerService = System.Web.HttpContext.Current.Application["ContainerService"] as UnityContainer;
      //         var Client = ContainerService.Resolve<ServiceContracts.IDelfinServices>();
      //         ObservableCollection<Constantes> _listContantesRGM = Client.GetAllConstantesByConstanteTabla("RGM");
      //         foreach (Entities.Constantes _itemConstenteRGM in _listContantesRGM)
      //         { m_listContantesRGM.Add(new SelectListItem() { Value = _itemConstenteRGM.CONS_CodTipo, Text = _itemConstenteRGM.CONS_Desc_SPA }); }
      //      }
      //      return m_listContantesRGM;
      //   } 
      //}

      //private List<SelectListItem> m_listContantesVIA;
      //public List<SelectListItem> ListContantesVIA 
      //{
      //   get
      //   {
      //      if (m_listContantesVIA == null)
      //      {
      //         m_listContantesVIA = new List<SelectListItem>();

      //         var ContainerService = System.Web.HttpContext.Current.Application["ContainerService"] as UnityContainer;
      //         var Client = ContainerService.Resolve<ServiceContracts.IDelfinServices>();
      //         ObservableCollection<Constantes> _listContantesVIA = Client.GetAllConstantesByConstanteTabla("VIA");
      //         foreach (Entities.Constantes _itemConstenteVIA in _listContantesVIA)
      //         { m_listContantesVIA.Add(new SelectListItem() { Value = _itemConstenteVIA.CONS_CodTipo, Text = _itemConstenteVIA.CONS_Desc_SPA }); }
      //      }
      //      return m_listContantesVIA;
      //   } 
      //}
   }
}