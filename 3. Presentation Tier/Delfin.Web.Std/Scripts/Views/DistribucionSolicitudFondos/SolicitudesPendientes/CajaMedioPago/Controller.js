ns('Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.CajaMedioPago.Controller');
Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.CajaMedioPago.Controller = function () {
   var base = this;
   base.Ini = function (opts) {
      'use strict';
      base.Control.Contenedor = opts.Contenedor;
      base.Event.AjaxCajaMedioPagoSuccessCustom = (opts.AjaxCajaMedioPagoSuccessCustom) ? opts.AjaxCajaMedioPagoSuccessCustom : null;

      base.Control.Validador = new Delfin.Web.Std.Components.Validator({
         form: 'frmSolicitudesPendientesCajaMedioPago',
         messages: Delfin.Web.Std.ValidacionSolicitudesPendientes.Mensaje.Resources
      });

      if (base.Function.AplicarBinding(Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Models.CajaMedioPago, base.Control.Contenedor.getMainContainer())) {
         base.Control.BtnGrabar().click(base.Event.BtnGrabarClick);
         base.Control.BtnSalir().click(base.Event.BtnSalirClick);
      };

      base.Event.CajaChange();
      base.Control.SolicitudesPendientesRegistro.RadCaja().change(base.Event.CajaChange);
      base.Control.SolicitudesPendientesRegistro.RadMedioPago().change(base.Event.MedioPagoChange);
   };

   base.Parametros = {

   };

   base.Control = {
      AjaxCajaMedioPagoSuccessCustom: null,
      Contenedor: null,
      Mesaje: new Delfin.Web.Std.Components.Message(),
      BtnGrabar: function () { return $('#btnAprobar'); },
      BtnSalir: function () { return $('#btnCancelar'); },
      DivCajaMedioPago: function () { return $('#divCajaMedioPagoSolicitudesPendientes'); },

      SolicitudesPendientesRegistro: {
         RadCaja: function () { return $('input:radio[name=radiosCaja]'); },
         RadCajaSel: function () { return $('input:radio[name=radiosCaja]:checked'); },
         RadMedioPago: function () { return $('input:radio[name=radiosMedioPago]'); },
         RadMedioPagoSel: function () { return $('input:radio[name=radiosMedioPago]:checked'); },
         RadTransferenciaBancaria: function () { return $('#radTransferenciaBancaria'); },
         RadEfectivo: function () { return $('#radEfectivo'); },
         DivEfectivo: function () { return $('#divEfectivo'); },
         DivDetallePago: function () { return $('#DetallePago'); },
         SlcBanco: function () { return $('#slcBanco'); },
         TxtFechaPago: function () { return $('#txtFechaPago'); },
         TxtNumeroOperacionValeCaja: function () { return $('#txtNumeroOperacionValeCaja'); }
      }
   };

   base.Event = {
      validacionCampoNumerico: function (e) {
         return validarSoloNumeros(e);
      },

      CajaChange: function() {
         var valorCaja = base.Control.SolicitudesPendientesRegistro.RadCajaSel().val();

         if (valorCaja == "CD") {
            base.Control.SolicitudesPendientesRegistro.RadEfectivo().prop('disabled', true);
            base.Control.SolicitudesPendientesRegistro.DivEfectivo().addClass('disabled');
            base.Control.SolicitudesPendientesRegistro.RadTransferenciaBancaria().prop('checked', true);
            base.Control.SolicitudesPendientesRegistro.SlcBanco().prop('disabled', true);
            base.Control.SolicitudesPendientesRegistro.TxtFechaPago().prop('disabled', true);
            base.Control.SolicitudesPendientesRegistro.TxtNumeroOperacionValeCaja().prop('disabled', true);
            base.Control.SolicitudesPendientesRegistro.TxtFechaPago().val('');
            base.Control.SolicitudesPendientesRegistro.TxtNumeroOperacionValeCaja().val('');
         }
         else {
            base.Control.SolicitudesPendientesRegistro.RadEfectivo().prop('disabled', false);
            base.Control.SolicitudesPendientesRegistro.DivEfectivo().removeClass('disabled');
            base.Control.SolicitudesPendientesRegistro.SlcBanco().prop('disabled', false);
            base.Control.SolicitudesPendientesRegistro.TxtFechaPago().prop('disabled', false);
            base.Control.SolicitudesPendientesRegistro.TxtNumeroOperacionValeCaja().prop('disabled', false);
         }

      },

      MedioPagoChange: function () {
         var valorMedioPago = base.Control.SolicitudesPendientesRegistro.RadMedioPagoSel().val();

         if (valorMedioPago == "EF") {
            base.Control.SolicitudesPendientesRegistro.SlcBanco().prop('disabled', true);
         } else {
            base.Control.SolicitudesPendientesRegistro.SlcBanco().prop('disabled', false);
         }

      },

      BtnGrabarClick: function () {
         var RegistrosSeleccionados = Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Index.Page.Control.GridResultado.getSelectionData();
         if (base.Control.Validador.isValid()) {        
            base.Control.Mesaje.Confirmation({
               title: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaCabeceraConfirmacion,
               message: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaConfirmacion,
               onAccept: function () {
                  base.Ajax.AjaxGrabar.data = {
                     myData: RegistrosSeleccionados,
                     sTipoCaja: base.Control.SolicitudesPendientesRegistro.RadCajaSel().val(),
                     sMedioPago: base.Control.SolicitudesPendientesRegistro.RadMedioPagoSel().val(),
                     sCodBanco: base.Control.SolicitudesPendientesRegistro.SlcBanco().val(),
                     sNroOper: base.Control.SolicitudesPendientesRegistro.TxtNumeroOperacionValeCaja().val(),
                     dFOper: base.Control.SolicitudesPendientesRegistro.TxtFechaPago().val()
                  };

                  base.Ajax.AjaxGrabar.submit();
               }
            });
         }
      },

      BtnSalirClick: function () {
         base.Control.Contenedor.close();
      },

      AjaxGrabarSuccess: function (data) {
         switch (data.CodigoError) {
            case '0':
               base.Control.Mesaje.Information({ message: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaRegistroConforme });

               if (base.Event.AjaxCajaMedioPagoSuccessCustom != null) {
                  base.Event.AjaxCajaMedioPagoSuccessCustom(data);
               }

               base.Control.Contenedor.close();
               Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Index.Page.Event.BtnBuscarClick();
               break;

            default:
               base.Control.Mesaje.Warning({ message: /*Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaErrorRegistro + " " +*/ data.DescripcionError });
               base.Control.Contenedor.close();
               Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Index.Page.Event.BtnBuscarClick();
               break;
         }
      }

      //AjaxListarCategoriaSuccess: function (data) {
      //   $.each(data, function (index, value) {
      //      base.Control.SolicitudesPendientesRegistro.SlcCategoriaCajaMedioPago().append($("<option />").val(value.Codigo).text(value.Descripcion));
      //   });

      //   var listaCategoria = base.Control.SolicitudesPendientesRegistro.SlcCategoriaCajaMedioPago().find('option').size();
      //   if (listaCategoria == 0) {
      //      base.Control.SolicitudesPendientesRegistro.SlcCategoriaCajaMedioPago().prop('disabled', true);
      //      base.Control.SolicitudesPendientesRegistro.SlcCategoriaCajaMedioPago().find('option').remove();
      //      base.Control.SolicitudesPendientesRegistro.SlcCategoriaCajaMedioPago().append($("<option />").val('').text(Delfin.Web.Std.Shared.General.Resources.EtiquetaSeleccionar));
      //      base.Control.BtnGrabar().prop('disabled', true);
      //   }
      //},

      //AjaxListarPuertoEmbarqueSuccess: function (data) {
      //   $.each(data, function (index, value) {
      //      base.Control.SolicitudesPendientesRegistro.SlcPuertoEmbarqueCajaMedioPago().append($("<option />").val(value.Codigo).text(value.Descripcion));
      //   });

      //   var listaPuertoEmbarque = base.Control.SolicitudesPendientesRegistro.SlcPuertoEmbarqueCajaMedioPago().find('option').size();
      //   if (listaPuertoEmbarque == 0) {
      //      base.Control.SolicitudesPendientesRegistro.SlcPuertoEmbarqueCajaMedioPago().prop('disabled', true);
      //      base.Control.SolicitudesPendientesRegistro.SlcPuertoEmbarqueCajaMedioPago().find('option').remove();
      //      base.Control.SolicitudesPendientesRegistro.SlcPuertoEmbarqueCajaMedioPago().append($("<option />").val('').text(Delfin.Web.Std.Shared.General.Resources.EtiquetaSeleccionar));
      //      base.Control.BtnGrabar().prop('disabled', true);
      //   }
      //},

      //AjaxListarNavieraAerolineaSuccess: function (data) {
      //   $.each(data, function (index, value) {
      //      base.Control.SolicitudesPendientesRegistro.SlcNavieraAerolineaCajaMedioPago().append($("<option />").val(value.Codigo).text(value.Descripcion));
      //   });

      //   var listaNavieraAerolinea = base.Control.SolicitudesPendientesRegistro.SlcNavieraAerolineaCajaMedioPago().find('option').size();
      //   if (listaNavieraAerolinea == 0) {
      //      base.Control.SolicitudesPendientesRegistro.SlcNavieraAerolineaCajaMedioPago().prop('disabled', true);
      //      base.Control.SolicitudesPendientesRegistro.SlcNavieraAerolineaCajaMedioPago().find('option').remove();
      //      base.Control.SolicitudesPendientesRegistro.SlcNavieraAerolineaCajaMedioPago().append($("<option />").val('').text(Delfin.Web.Std.Shared.General.Resources.EtiquetaSeleccionar));
      //      base.Control.BtnGrabar().prop('disabled', true);
      //   }
      //}
   };

   base.Ajax = {
      AjaxGrabar: new Delfin.Web.Std.Components.Ajax({
         action: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Actions.Atender,
         autoSubmit: false,
         onSuccess: base.Event.AjaxGrabarSuccess
      })

      //AjaxListarCategoria: new Delfin.Web.Std.Components.Ajax({
      //   action: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Actions.ListarCategoria,
      //   autoSubmit: false,
      //   onSuccess: base.Event.AjaxListarCategoriaSuccess
      //}),

      //AjaxListarPuertoEmbarque: new Delfin.Web.Std.Components.Ajax({
      //   action: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Actions.ListarPuertoEmbarque,
      //   autoSubmit: false,
      //   onSuccess: base.Event.AjaxListarPuertoEmbarqueSuccess
      //}),

      //AjaxListarNavieraAerolinea: new Delfin.Web.Std.Components.Ajax({
      //   action: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Actions.ListarNavieraAerolinea,
      //   autoSubmit: false,
      //   onSuccess: base.Event.AjaxListarNavieraAerolineaSuccess
      //})
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
            base.Control.Mensaje.Warning({ message: Delfin.Web.Std.Shared.Resources.ErrorCargarViewModel });
         }

         return esValido;
      }
   };
};