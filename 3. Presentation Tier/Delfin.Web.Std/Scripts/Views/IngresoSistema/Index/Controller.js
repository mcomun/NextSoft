ns('Delfin.Web.Std.IngresoSistema.Index.Controller');
Delfin.Web.Std.IngresoSistema.Index.Controller = function () {
   var base = this;
   base.Ini = function (opts) {
      'use strict';
      base.Control.BtnIngresoSistema().click(base.Event.BtnIngresoSistemaClick);
      base.Control.CriterioIngresoSistema.TxtUsuario().keypress(base.Event.txtKeypress);
      base.Control.CriterioIngresoSistema.TxtContrasenia().keypress(base.Event.txtKeypress);

      base.Control.Validador = new Delfin.Web.Std.Components.Validator({
         form: 'frmIngresoSistema',
         messages: Delfin.Web.Std.ValidacionIngresoSistema.Mensaje.Resources
      });
   };

   base.Parameters = {

   };

   base.Control = {
      Validador: null,
      Modal: null,
      Mesaje: new Delfin.Web.Std.Components.Message(),
      FormularioIngresoSistema: null,
      BtnIngresoSistema: function () { return $('#btnIngresoSistema'); },
      LblMensaje: function () { return $('#lblMensaje'); },
      CriterioIngresoSistema: {
         TxtUsuario: function () { return $('#txtUsuario'); },
         TxtContrasenia: function () { return $('#txtContrasenia'); },
      }
   };
   base.Event = {
      txtKeypress: function (e) {
         var key = e.keyCode || e.which;
         if (key == 13) {
            base.Event.BtnIngresoSistemaClick();
         }
      },

      BtnIngresoSistemaClick: function () {
         if (base.Function.ValidarRegistro()) {
            base.Ajax.AjaxIngresoSistema.data = {
               Usuario: base.Control.CriterioIngresoSistema.TxtUsuario().val(), //.toUpperCase()
               Contrasenia: base.Control.CriterioIngresoSistema.TxtContrasenia().val()
            };

            base.Ajax.AjaxIngresoSistema.submit();
         }
      },

      AjaxIngresoSistemaSuccess: function (data) {
         if (data != null) {
            if (data.CodigoError == '0') {
               window.location.href = Delfin.Web.Std.IngresoSistema.Actions.Ruta;
            }
            else {
               base.Control.Mesaje.Warning({ message: data.DescripcionError });
            }
         }
         else {
            base.Control.Mesaje.Warning({ message: 'Usuario no tiene Acceso.' });
         }
      }
   };

   base.Ajax = {
      AjaxIngresoSistema: new Delfin.Web.Std.Components.Ajax({
         action: Delfin.Web.Std.IngresoSistema.Actions.IngresoSistema,
         autoSubmit: false,
         onSuccess: base.Event.AjaxIngresoSistemaSuccess
      })
   };

   base.Function = {
      ValidarRegistro: function () {
         var esValido = true;
         var txtUsuario = base.Control.CriterioIngresoSistema.TxtUsuario().val();
         var txtContrasenia = base.Control.CriterioIngresoSistema.TxtContrasenia().val();
         var lblMensaje = base.Control.LblMensaje().val();

         if (txtUsuario == "") {
            esValido = false,
            base.Control.LblMensaje().text(Delfin.Web.Std.ValidacionIngresoSistema.Mensaje.Resources.IngreseUsuarioReq);
            //base.Control.Mesaje.Warning({
            //   message: Delfin.Web.Std.ValidacionIngresoSistema.Mensaje.Resources.IngreseUsuarioReq
            //});
         }
         else {
            if (txtContrasenia == "") {
               esValido = false,
               base.Control.LblMensaje().text(Delfin.Web.Std.ValidacionIngresoSistema.Mensaje.Resources.IngreseContraseniaReq);
               //base.Control.Mesaje.Warning({
               //   message: Delfin.Web.Std.ValidacionIngresoSistema.Mensaje.Resources.IngreseContraseniaReq
               //});
            }
            else {
               esValido = true;
            }
         }

         return esValido;
      },

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
            base.Control.Mensaje.Warning({ message: Delfin.Web.Std.Shared.Resources.ErrorCargarViewModel });
         }
         return esValido;
      }
   };
};