try {
   ns('Delfin.Web.Std.Home.Index');
   $(document).ready(function () {
      'use strict';
      Delfin.Web.Std.Home.Index.Page = new Delfin.Web.Std.Home.Index.Controller();
      Delfin.Web.Std.Home.Index.Page.Ini();
   });

} catch (ex) {
   alert(ex.message);
}