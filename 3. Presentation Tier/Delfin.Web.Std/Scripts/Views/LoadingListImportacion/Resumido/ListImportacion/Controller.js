try {
   ns('Delfin.Web.Std.LoadingListImportacion.Resumido.ListImportacion.Controller');
   Delfin.Web.Std.LoadingListImportacion.Resumido.ListImportacion.Controller = function () {
      var base = this;
      base.Ini = function () {
         'use strict';
         base.Control.Dialog = new Delfin.Web.Std.Components.Dialog({
            autoOpen: false,
            maxHeight: 480,
            width: '75%',
            modal: true
         });

         base.Control.ConfirmLoadingList = new Delfin.Web.Std.Components.Dialog({
            autoOpen: false,
            maxHeight: 480,
            width: '55%',
            modal: true
         });

         base.Control.DocOrigenMD = new Delfin.Web.Std.Components.Dialog({
            autoOpen: false,
            maxHeight: 480,
            width: '55%',
            modal: true
         });

         base.Control.BtnConfirmLoadingList().click(base.Event.BtnConfirmLoadingListClick);

         base.Control.BtnOpenDocOrigenMD().click(base.Event.BtnOpenDocOrigenMDClick);

      };

      base.Control = {
         ConfirmLoadingList: null,
         DocOrigenMD: null,

         BtnConfirmLoadingList: function () { return $('#BtnConfirmLoadingList'); },

         BtnOpenDocOrigenMD: function () { return $('#btnOpenDocOrigenMD'); },
      };


      base.Event = {
         
         //#########
         BtnConfirmLoadingListClick: function () {
            base.Control.ConfirmLoadingList.getAjaxContent({
               action: Delfin.Web.Std.LoadingListImportacion.Actions.ConfirmLoadingList,
               
            });
         },

         //onSuccess: base.Event.ConfirmLoadingListSuccess

         ConfirmLoadingListSuccess: function (data) {
            base.Control.FormularioNuevo = new Delfin.Web.Std.LoadingListImportacion.Resumido.Controller();
            base.Control.FormularioNuevo.Ini({
               Contenedor: base.Control.ConfirmLoadingList,
               AjaxNuevoSuccessCustom: base.Event.DialogAjaxSucess
            });
         },
         //#########


         //#########
         BtnOpenDocOrigenMDClick: function () {

            alert('Alert');


         },


         //base.Control.DocOrigenMD.getAjaxContent({
         //   action: Delfin.Web.Std.SolicitudServicio.SolicitudServicioMain.Actions.OpenDocOrigenMD,
               
         //});

         DocOrigenMDSuccess: function (data) {
            base.Control.FormularioNuevo = new Delfin.Web.Std.SolicitudServicio.SolicitudServicioMain.EscogerDocOrigenMD.Controller();
            base.Control.FormularioNuevo.Ini({
               Contenedor: base.Control.DocOrigenMD,
               AjaxNuevoSuccessCustom: base.Event.DialogAjaxSucess
            });
         },
         //#########
         
      };

   };
} catch (ex) {
   alert(ex.message);
}