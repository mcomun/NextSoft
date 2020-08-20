try {
   ns('Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Index');
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
      Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Index.Page = new Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Index.Controller();
      Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Index.Page.Ini();
   });

} catch (ex) {
   alert(ex.message);
}