try {
   ns('Delfin.Web.Std.Home.Index.Controller');
   Delfin.Web.Std.Home.Index.Controller = function () {
      var base = this;
      base.Ini = function () {
         'use strict';
      };

      base.Control = {

      };

      base.Event = {

      };
      base.Ajax = {

      };

      base.Function = {
         AplicarBinding: function (model, contenedor) {
            var esValido = (typeof model !== 'undefined');

            if (esValido) {
               var contenedorDom = (contenedor) ? contenedor[0] : contenedor;
               esValido = (model.Error.Code == 0);
               if (esValido) {
                  ko.applyBindings(model, contenedorDom);
               } else {
                  base.Control.Mensaje.Warning({ message: model.Error.Message });
               }

            } else {
               base.Control.Mensaje.Warning({ message: Delfin.Comex.Web.Shared.Resources.ErrorCargarViewModel });
            }
            return esValido;
         }
      };
   };
} catch (ex) {
   alert(ex.message);
}