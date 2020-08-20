try {
   ns('Delfin.Web.Std.LoadingListImportacion.Resumido.Index');
   $(document).ready(function () {
      'use strict';
      $('.input-daterange').datepicker({
         todayBtn: "linked",
         format: "dd/mm/yyyy",
         language: "es",
         changeMonth: true,
         changeYear: true,
         autoclose: false
      });

      Delfin.Web.Std.LoadingListImportacion.Resumido.Index.Page = new Delfin.Web.Std.LoadingListImportacion.Resumido.Index.Controller();
      Delfin.Web.Std.LoadingListImportacion.Resumido.Index.Page.Ini();
   });

} catch (ex) {
   alert(ex.message);
}