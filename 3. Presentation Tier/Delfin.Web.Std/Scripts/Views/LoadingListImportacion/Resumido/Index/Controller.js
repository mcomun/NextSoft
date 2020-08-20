try {
   ns('Delfin.Web.Std.LoadingListImportacion.Resumido.Index.Controller');
   Delfin.Web.Std.LoadingListImportacion.Resumido.Index.Controller = function () {
      var base = this;
      base.Ini = function () {
         'use strict';
         base.Control.Dialog = new Delfin.Web.Std.Components.Dialog({
            autoOpen: false,
            maxHeight: 480,
            width: '75%',
            modal: true
         });

      };

      base.Control.ConfirmLoadingList = new Delfin.Web.Std.Components.Dialog({
         autoOpen: false,
         maxHeight: 480,
         width: '55%',
         modal: true
      });



      base.Control.BtnConfirmLoadingList().click(base.Event.BtnConfirmLoadingListClick);

      base.Control = {
         DocOrigenMD: null,
         
         BtnConfirmLoadingList: function () { return $('#BtnConfirmLoadingList'); },
      };



      base.Event = {
         
         //#########
         BtnConfirmLoadingListClick: function () {
            base.Control.DocOrigenMD.getAjaxContent({
               action: Delfin.Web.Std.LoadingListImportacion.Resumido.Actions.ConfirmLoadingList,
               onSuccess: base.Event.ConfirmLoadingListSuccess
            });
         },

         ConfirmLoadingListSuccess: function (data) {
            base.Control.FormularioNuevo = new Delfin.Web.Std.LoadingListImportacion.Resumido.ConfirmLoadingList.Controller();
            base.Control.FormularioNuevo.Ini({
               Contenedor: base.Control.ConfirmLoadingList,
               AjaxNuevoSuccessCustom: base.Event.DialogAjaxSucess
            });
         },
         //#########
         
      };

   };
} catch (ex) {
   alert(ex.message);
}