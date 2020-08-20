try {
   ns('Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Index');
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

      Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Index.Page = new Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Index.Controller();
      Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Index.Page.Ini();
   });

} catch (ex) {
   alert(ex.message);
}