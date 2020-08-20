ns('Delfin.Web.Std.IngresoSistema.Index');
try {
   $(document).ready(function () {
      'use strict';

      Delfin.Web.Std.IngresoSistema.Index.Page = new Delfin.Web.Std.IngresoSistema.Index.Controller();
      Delfin.Web.Std.IngresoSistema.Index.Page.Ini();
   });

} catch (ex) {
   alert(ex.message);
}