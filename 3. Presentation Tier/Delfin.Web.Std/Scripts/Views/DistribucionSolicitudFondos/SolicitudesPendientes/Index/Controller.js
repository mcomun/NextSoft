try {
   ns('Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Index.Controller');
   Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Index.Controller = function () {
      var base = this;
      base.Ini = function () {
         'use strict';
         base.Control.Dialog = new Delfin.Web.Std.Components.Dialog({
            autoOpen: false,
            maxHeight: 480,
            width: '75%',
            modal: true
         });
         
         base.Control.CriterioBusqueda.TxtDesde().keypress(base.Event.TxtBuscarKeyPress);
         base.Control.CriterioBusqueda.txtAnio().keypress(base.Event.validacionCampoNumerico);
         base.Control.CriterioBusqueda.TxtHasta().keypress(base.Event.TxtBuscarKeyPress);
         base.Control.CriterioBusqueda.txtAnio().keypress(base.Event.TxtBuscarKeyPress);
         base.Control.CriterioBusqueda.TxtSd().keypress(base.Event.TxtBuscarKeyPress);
         //base.Control.CriterioBusqueda.TxtSd().onkeypress(base.Event.validacionAlfanumericoSinEspacios);
         base.Control.CriterioBusqueda.TxtPlaca().keypress(base.Event.TxtBuscarKeyPress);
         //base.Control.GridResultado().onClick(base.Event.Seleccionar);

         if (base.Function.AplicarBinding(Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Models.Index)) {
            base.Control.BtnBuscar().click(base.Event.BtnBuscarClick);
            base.Control.BtnAceptar().click(base.Event.BtnAceptarClick);
            //base.Function.GenerarGrid(Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Models.Index);
            //base.Function.GenerarGrid();
            base.Control.DivResultadoBusqueda().fadeIn();
         };

         if (base.Control.modelSolicitudesPendientes != null) {
            var indicadorFiltroSesion = 0;
            if (base.Control.modelSolicitudesPendientes.FechaDesde != null) { base.Control.CriterioBusqueda.TxtDesde().attr('value', base.Control.modelDatosGenerales.TxtDesde); indicadorFiltroSesion = 1; }
            if (base.Control.modelSolicitudesPendientes.FechaHasta != null) { base.Control.CriterioBusqueda.TxtHasta().attr('value', base.Control.modelDatosGenerales.TxtHasta); indicadorFiltroSesion = 1 }
            if (base.Control.modelSolicitudesPendientes.Anio != null) { base.Control.CriterioBusqueda.txtAnio().attr('value', base.Control.modelDatosGenerales.Anio); indicadorFiltroSesion = 1; }
            // if (indicadorFiltroSesion == 1) { base.Event.BtnBuscarClick(); }
         }

         base.Event.BtnBuscarClick();
      };

      base.Parametros = {
         FormularioSeleccion: {
            RegistroSeleccionado: null
         },

         Busqueda: null
      };

      base.Control = {
         Dialog: null,
         Mensaje: new Delfin.Web.Std.Components.Message(),
         FormularioNuevo: null,
         FormularioModificar: null,
         GridResultado: null,
         modelSolicitudesPendientes: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Models.Index,
         FormularioCriterioBusqueda: function () { return $('#frmSolicitudesPendientesIndex'); },
         DivResultadoBusqueda: function () { return $('#divResultadoBusquedaSolicitudesPendientes'); },
         DivResultadoBusquedaDetalle: function () { return $('#divResultadoBusquedaSolicitudesPendientesDetalle'); },
         BtnBuscar: function () { return $('#btnBuscar'); },
         BtnAceptar: function () { return $('#btnCajaMedioPago'); },

         CriterioBusqueda: {
            TxtDesde: function () { return $('#TxtDesde'); },
            TxtHasta: function () { return $('#TxtHasta'); },
            txtAnio: function () { return $('#txtAnio'); },
            TxtSd: function () { return $('#TxtSd'); },
            TxtPlaca: function () { return $('#TxtPlaca'); }
         }
      };

      base.Event = {
         validacionCampoNumerico: function (e) {
            return validarSoloNumeros(e);
         },

         validacionAlfanumericoSinEspacios: function (e) {
            return validarSoloNumerosLetrasEspaciosEnBlancoYGuionBajo(e);
         },

         TxtBuscarKeyPress: function (evento) {
            var key = obtenerKeyCode(evento);
            var esValido = !(evento && key == 13);
            if (esValido == false) {
               base.Event.BtnBuscarClick();
            }
            return esValido;
         },

         BtnBuscarClick: function () {
            base.Parametros.Busqueda = {
               FechaDesde: (base.Control.CriterioBusqueda.TxtDesde().val() != "" ? base.Control.CriterioBusqueda.TxtDesde().val() : null),
               FechaHasta: (base.Control.CriterioBusqueda.TxtHasta().val() != "" ? base.Control.CriterioBusqueda.TxtHasta().val() : null),
               Anio: base.Control.CriterioBusqueda.txtAnio().val(),
               Sd: base.Control.CriterioBusqueda.TxtSd().val(),
               Placa: base.Control.CriterioBusqueda.TxtPlaca().val()
            }

            base.Function.EjecutarConsulta();
         },

         BtnAceptarClick: function () {
            if (base.Function.ValidaMoneda()) {
               base.Control.Dialog.getAjaxContent({
                  action: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Actions.CajaMedioPago,
                  onSuccess: base.Event.ModalSuccess,
                  data: {
                  }
               });
            }           
         },

         DialogAjaxSucess: function (data) {
            base.Event.BtnBuscarClick();
         },

         AjaxBuscarSuccess: function (data) {
            if (data != null) {
               //base.Function.GenerarGrid();
               base.Function.GenerarGrid(Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Models.Index);
               base.Control.GridResultado.setData(data);
            }
         },

         ModalSuccess: function (data) {
            base.Control.FormularioNuevo = new Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.CajaMedioPago.Controller();
            base.Control.FormularioNuevo.Ini({
               Contenedor: base.Control.Dialog,
               AjaxNuevoSuccessCustom: base.Event.DialogAjaxSucess
            });
         }
      };

      base.Ajax = {
         AjaxBuscar: new Delfin.Web.Std.Components.Ajax({
            action: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Actions.Buscar,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarSuccess
         })
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
         },

         EjecutarConsulta: function () {
            //base.Function.GenerarGrid();
            base.Function.GenerarGrid(Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Models.Index);
            base.Control.GridResultado.load();
            base.Control.DivResultadoBusquedaDetalle().fadeIn();
         },

         GenerarGrid: function (model) {
            if (base.Control.GridResultado != null) {
               base.Control.GridResultado.destroy();
            }

            var columns = new Array();

            columns.push({ id: 'AnioServicio', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColAnioServicio, field: 'AnioServicio', width: 50, cssClass: 'text-center' });
            columns.push({ id: 'CodigoServicio', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColCodigoServicio, field: 'CodigoServicio', width: 80, cssClass: 'text-center' });
            columns.push({ id: 'NombreCuenta', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColNombreCuenta, field: 'NombreCuenta', width: 300, cssClass: 'text-center' });
            columns.push({ id: 'FechaSolicitud', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColFechaSolicitud, field: 'FechaSolicitud', width: 150, cssClass: 'text-center' });
            columns.push({ id: 'FechaProgramada', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColFechaProgramada, field: 'FechaProgramada', width: 150, cssClass: 'text-center' });
            columns.push({ id: 'NombreProveedor', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColNombreProveedor, field: 'NombreProveedor', width: 150, cssClass: 'text-center' });
            columns.push({ id: 'NombreBeneficiario', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColNombreBeneficiario, field: 'NombreBeneficiario', width: 300, cssClass: 'text-center' });
            columns.push({ id: 'PlacaTracto', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColPlacaTracto, field: 'PlacaTracto', width: 80, cssClass: 'text-center' });
            columns.push({ id: 'PlacaCarreta', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColPlacaCarreta, field: 'PlacaCarreta', width: 80, cssClass: 'text-center' });
            columns.push({ id: 'MontoDolares', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColMoneda, field: 'CodigoMoneda', width: 80, cssClass: 'text-center' });
            columns.push({ id: 'MontoSoles', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColMonto, field: 'Monto', width: 80, cssClass: 'text-center' });
            columns.push({ id: 'OrdenInterna', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColOrdenInterna, field: 'OrdenInterna', width: 80, cssClass: 'text-center' });
            columns.push({ id: 'UsuarioSolicita', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColUsuarioSolicita, field: 'UsuarioSolicita', width: 300, cssClass: 'text-center' });
            columns.push({ id: 'CodigoRuta', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColCodigoRuta, field: 'CodigoRuta', width: 80, cssClass: 'text-center' });
            columns.push({ id: 'NombreRuta', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColNombreRuta, field: 'NombreRuta', width: 250, cssClass: 'text-center' });
            //columns.push({ id: 'CodigoBeneficiario', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColCodigoBeneficiario, field: 'CodigoBeneficiario', width: 100, cssClass: 'text-center' });
            //columns.push({ id: 'CodigoMoneda', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColCodigoMoneda, field: 'CodigoMoneda', width: 100, cssClass: 'text-center' });
            //columns.push({ id: 'FlagErrorSAP', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColFlagErrorSAP, field: 'FlagErrorSAP', width: 0, cssClass: 'text-center' });
            columns.push({ id: 'ObservacionSAP', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Resources.EtiquetaColObservacionSAP, field: 'ObservacionSAP', width: 700, cssClass: 'text-center' });
            
            base.Control.GridResultado = new Delfin.Web.Std.Components.Grid({
               renderTo: 'divGridResultadoSolicitudesPendientes',
               isPager: false,
               isServerPaging: false,
               proxy: {
                  action: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Actions.Buscar,
                  data: base.Parametros.Busqueda
               },
               columns: columns,
               isCheckboxSelector : true,
               height: 350,
               isSeleccionarCodigoServicio : true
            });
         },

         ValidaMoneda: function () {
            var RegistrosSeleccionados = base.Control.GridResultado.getSelectionData();
            var isValid = true;
            var CodigoMoneda;

            if (RegistrosSeleccionados.length == null || RegistrosSeleccionados.length <= 0) {
               isValid = false;
               base.Control.Mensaje.Warning({ message: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Mensaje.Resources.SeleccioneRegistro });
            } else {
               CodigoMoneda = RegistrosSeleccionados[0].CodigoMoneda;

               for (var i = 0; i < RegistrosSeleccionados.length; i++) {
                  if (CodigoMoneda != RegistrosSeleccionados[i].CodigoMoneda) {
                     base.Control.Mensaje.Warning({ message: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesPendientes.Mensaje.Resources.SeleccionaUnaMoneda });
                     isValid = false;
                     break;
                  }
               }
            }

            return isValid;
         }
      };
   };
} catch (ex) {
   alert(ex.message);
}