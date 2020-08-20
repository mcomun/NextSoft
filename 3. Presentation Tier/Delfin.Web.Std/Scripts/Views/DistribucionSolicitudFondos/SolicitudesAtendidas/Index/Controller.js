try {
   ns('Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Index.Controller');
   Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Index.Controller = function () {
      var base = this;
      base.Ini = function () {
         'use strict';
         base.Control.Dialog = new Delfin.Web.Std.Components.Dialog({
            autoOpen: false,
            maxHeight: 480,
            width: '80%',
            modal: true
         });

         base.Control.CriterioBusqueda.TxtDesde().keypress(base.Event.TxtBuscarKeyPress);
         base.Control.CriterioBusqueda.txtAnio().keypress(base.Event.validacionCampoNumerico);
         base.Control.CriterioBusqueda.TxtHasta().keypress(base.Event.TxtBuscarKeyPress);
         base.Control.CriterioBusqueda.txtAnio().keypress(base.Event.TxtBuscarKeyPress);
         //base.Control.GridResultado().onClick(base.Event.Seleccionar);

         if (base.Function.AplicarBinding(Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Models.Index)) {
            base.Control.BtnBuscar().click(base.Event.BtnBuscarClick);
            base.Control.BtnAceptar().click(base.Event.BtnAceptarClick);
            base.Control.BtnConsultar().click(base.Event.BtnConsultarClick);
            //base.Function.GenerarGrid(Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Models.Index);
            //base.Function.GenerarGrid();
            base.Control.DivResultadoBusqueda().fadeIn();
         };

         if (base.Control.modelSolicitudesAtendidas != null) {
            var indicadorFiltroSesion = 0;
            if (base.Control.modelSolicitudesAtendidas.FechaDesde != null) { base.Control.CriterioBusqueda.TxtDesde().attr('value', base.Control.modelDatosGenerales.TxtDesde); indicadorFiltroSesion = 1; }
            if (base.Control.modelSolicitudesAtendidas.FechaHasta != null) { base.Control.CriterioBusqueda.TxtHasta().attr('value', base.Control.modelDatosGenerales.TxtHasta); indicadorFiltroSesion = 1 }
            if (base.Control.modelSolicitudesAtendidas.Anio != null) { base.Control.CriterioBusqueda.txtAnio().attr('value', base.Control.modelDatosGenerales.Anio); indicadorFiltroSesion = 1; }
            // if (indicadorFiltroSesion == 1) { base.Event.BtnBuscarClick(); }
         }

         base.Event.BtnBuscarClick();
      };

      base.Parametros = {
         FormularioSeleccion: {
            RegistroSeleccionado: null
         },

         Busqueda: null,
         Consulta: null
      };

      base.Control = {
         Dialog: null,
         Mensaje: new Delfin.Web.Std.Components.Message(),
         FormularioNuevo: null,
         FormularioModificar: null,
         GridResultado: null,
         modelSolicitudesAtendidas: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Models.Index,
         FormularioCriterioBusqueda: function () { return $('#frmSolicitudesAtendidasIndex'); },
         DivResultadoBusqueda: function () { return $('#divResultadoBusquedaSolicitudesAtendidas'); },
         DivResultadoBusquedaDetalle: function () { return $('#divResultadoBusquedaSolicitudesAtendidasDetalle'); },
         BtnBuscar: function () { return $('#btnBuscar'); },
         BtnAceptar: function () { return $('#btnAnular'); },
         BtnConsultar: function () { return $('#btnConsultar'); },

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
               FechaDesde: base.Control.CriterioBusqueda.TxtDesde().val(),
               FechaHasta: base.Control.CriterioBusqueda.TxtHasta().val(),
               Anio: base.Control.CriterioBusqueda.txtAnio().val(),
               Sd: base.Control.CriterioBusqueda.TxtSd().val(),
               Placa: base.Control.CriterioBusqueda.TxtPlaca().val()
            }

            base.Function.EjecutarConsulta();
         },

         BtnAceptarClick: function () {
            var RegistrosSeleccionados = base.Control.GridResultado.getSelectionData();

            if (RegistrosSeleccionados.length == null || RegistrosSeleccionados.length <= 0) {
               base.Control.Mensaje.Warning({ message: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Mensaje.Resources.SeleccioneRegistro });
            } else {
               if (RegistrosSeleccionados.length == 1) {
                  if (RegistrosSeleccionados[0].CodigoTipoCaja == Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaCajaDelfin
                   && RegistrosSeleccionados[0].CodigoMedioPago == Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaTransferenciaBancaria) {
                     base.Control.Mensaje.Confirmation({
                        title: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaCabeceraConfirmacion,
                        message: function () {
                           var sMensaje = Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaConfirmacion;

                           if (RegistrosSeleccionados[0].NumeroSolicitudARendirSap != null) {
                              sMensaje = sMensaje.concat(" \n ", Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Mensaje.Resources.MensajeNroSolicitudSap, ": \n ", RegistrosSeleccionados[0].NumeroSolicitudARendirSap)
                           }
                           
                           return sMensaje;
                        },
                        onAccept: function () {
                           base.Ajax.AjaxAnularSAP.data = {
                              nIdSolic: RegistrosSeleccionados[0].Id,
                           };

                           base.Ajax.AjaxAnularSAP.submit();
                        }
                     });
                  } else {
                     base.Control.Mensaje.Confirmation({
                        title: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaCabeceraConfirmacion,
                        message: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaConfirmacion,
                        onAccept: function () {
                           base.Ajax.AjaxAnular.data = {
                              nIdSolic: RegistrosSeleccionados[0].Id,
                           };

                           base.Ajax.AjaxAnular.submit();
                        }
                     });
                  }
               } else {
                  base.Control.Mensaje.Warning({ message: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Mensaje.Resources.SeleccioneSoloUno });
               }
            } 
         },

         BtnConsultarClick: function () {
            var RegistrosSeleccionados = base.Control.GridResultado.getSelectionData();

            if (RegistrosSeleccionados.length == null || RegistrosSeleccionados.length <= 0) {
               base.Control.Mensaje.Warning({ message: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Mensaje.Resources.SeleccioneRegistro });
            } else {
               base.Control.Mensaje.Confirmation({
                  title: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaCabeceraConfirmacion,
                  message: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaConfirmacion,
                  onAccept: function () {
                     var miArray = new Array();
                     for (var i = 0; i < RegistrosSeleccionados.length; i++) {
                        miArray[i] = RegistrosSeleccionados[i].Id;
                     }

                     base.Parametros.Consulta = {
                        ListaEnteros: miArray
                     }

                     base.Function.EjecutarConsultaSap();
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
               base.Function.GenerarGrid(Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Models.Index);
               base.Control.GridResultado.setData(data);
            }
         },

         AjaxAnularSuccess: function (data) {
            switch (data.CodigoError) {
               case '0':
                  base.Control.Mensaje.Information({ message: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaRegistroConforme });

                  //if (base.Event.AjaxCajaMedioPagoSuccessCustom != null) {
                  //   base.Event.AjaxCajaMedioPagoSuccessCustom(data);
                  //}

                  base.Event.BtnBuscarClick();
                  break;

               default:
                  base.Control.Mensaje.Warning({ message: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaErrorRegistro + " " + data.DescripcionError });
                  //base.Event.BtnBuscarClick();
                  break;
            }
         },

         AjaxConsultarSapSuccess: function (data) {
            if (data != null) {
               base.Function.GenerarGrid(Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Models.Index);
               base.Control.GridResultado.setData(data);
            }
         },
      };

      base.Ajax = {
         

         AjaxAnular: new Delfin.Web.Std.Components.Ajax({
            action: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Actions.Anular,
            autoSubmit: false,
            onSuccess: base.Event.AjaxAnularSuccess
         }),

         AjaxAnularSAP: new Delfin.Web.Std.Components.Ajax({
            action: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Actions.AnularSAP,
            autoSubmit: false,
            onSuccess: base.Event.AjaxAnularSuccess
         }),

         AjaxConsultarSap: new Delfin.Web.Std.Components.Ajax({
            action: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Actions.ConsultarSap,
            autoSubmit: false,
            onSuccess: base.Event.AjaxConsultarSapSuccess
         }),
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
            base.Control.DivResultadoBusquedaDetalle().fadeIn();
            base.Function.GenerarGrid(Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Models.Index);
            base.Control.GridResultado.load();
         },

         EjecutarConsultaSap: function () {
            base.Function.GenerarGridSap(Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Models.Index);
            base.Control.GridResultado.load();
         },

         GenerarGrid: function (model) {
            if (base.Control.GridResultado != null) {
               base.Control.GridResultado.destroy();
            }

            var columns = new Array();

            columns.push({ id: 'Id', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColIdSolicitud, field: 'Id', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'AnioServicio', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColAnioServicio, field: 'AnioServicio', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'CodigoServicio', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColCodigoServicio, field: 'CodigoServicio', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'NombreCuenta', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColNombreCuenta, field: 'NombreCuenta', width: 250, cssClass: 'text-center' });
            columns.push({ id: 'FechaSolicitud', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColFechaSolicitud, field: 'FechaSolicitud', width: 150, cssClass: 'text-center' });
            columns.push({ id: 'FechaAprobacion', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColFechaAprobacion, field: 'FechaAprobacion', width: 150, cssClass: 'text-center' });
            columns.push({ id: 'PlacaTracto', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColPlacaTracto, field: 'PlacaTracto', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'PlacaCarreta', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColPlacaCarreta, field: 'PlacaCarreta', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'NombreBeneficiario', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColNombreBeneficiario, field: 'NombreBeneficiario', width: 250, cssClass: 'text-center' });
            columns.push({ id: 'CodigoMoneda', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColCodigoMoneda, field: 'CodigoMoneda', width: 100, cssClass: 'text-center' });
            //columns.push({ id: 'MontoSoles', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColMontoSoles, field: 'MontoSoles', width: 100, cssClass: 'text-center' });
            //columns.push({ id: 'MontoDolares', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColMontoDolares, field: 'MontoDolares', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'Monto', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColMonto, field: 'Monto', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'NumeroSolicitudARendirSap', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColNumeroSolicitudARendirSap, field: 'NumeroSolicitudARendirSap', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'OrdenInterna', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColOrdenInterna, field: 'OrdenInterna', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'UsuarioSolicita', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColUsuarioSolicita, field: 'UsuarioSolicita', width: 200, cssClass: 'text-center' });
            columns.push({ id: 'UsuarioAprueba', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColUsuarioAprueba, field: 'UsuarioAprueba', width: 200, cssClass: 'text-center' });
            //columns.push({ id: 'CodigoTipoCaja', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColCodigoTipoCaja, field: 'CodigoTipoCaja', width: 0, cssClass: 'text-center' });
            columns.push({ id: 'TipoCaja', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColTipoCaja, field: 'NombreTipoCaja', width: 150, cssClass: 'text-center' });
            //columns.push({ id: 'CodigoMedioPago', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColCodigoMedioPago, field: 'CodigoMedioPago', width: 0, cssClass: 'text-center' });
            columns.push({ id: 'MedioPago', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColMedioPago, field: 'NombreMedioPago', width: 250, cssClass: 'text-center' });
            columns.push({ id: 'EstadoSolicitudSap', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColEstadoSolicitudSap, field: 'EstadoSolicitudSap', width: 200, cssClass: 'text-center' });
            columns.push({ id: 'FechaPago', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColFechaPago, field: 'FechaPago', width: 150, cssClass: 'text-center' });
            columns.push({ id: 'Banco', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColBanco, field: 'NombreBanco', width: 200, cssClass: 'text-center' });
            columns.push({ id: 'NumeroOperacionValeCaja', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColNumeroOperacionValeCaja, field: 'NumeroOperacionOValeCaja', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'FechaSalida', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColFechaSalida, field: 'FechaSalida', width: 200, cssClass: 'text-center' });
            

            base.Control.GridResultado = new Delfin.Web.Std.Components.Grid({
               renderTo: 'divGridResultadoSolicitudesAtendidas',
               isPager: false,
               isServerPaging: false,
               proxy: {
                  action: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Actions.Buscar,
                  data: base.Parametros.Busqueda
               },
               columns: columns,
               isCheckboxSelector: true,
               height: 350,
               isSeleccionarIdSolicitud: true
            });
         },

         GenerarGridSap: function (model) {
            if (base.Control.GridResultado != null) {
               base.Control.GridResultado.destroy();
            }

            var columns = new Array();

            columns.push({ id: 'Id', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColIdSolicitud, field: 'Id', width: 50, cssClass: 'text-center' });
            columns.push({ id: 'AnioServicio', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColAnioServicio, field: 'AnioServicio', width: 50, cssClass: 'text-center' });
            columns.push({ id: 'CodigoServicio', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColCodigoServicio, field: 'CodigoServicio', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'NombreCuenta', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColNombreCuenta, field: 'NombreCuenta', width: 200, cssClass: 'text-center' });
            columns.push({ id: 'FechaSolicitud', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColFechaSolicitud, field: 'FechaSolicitud', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'FechaAprobacion', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColFechaAprobacion, field: 'FechaAprobacion', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'NombreBeneficiario', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColNombreBeneficiario, field: 'NombreBeneficiario', width: 150, cssClass: 'text-center' });
            columns.push({ id: 'PlacaCarreta', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColPlacaCarreta, field: 'PlacaCarreta', width: 50, cssClass: 'text-center' });
            columns.push({ id: 'PlacaTracto', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColPlacaTracto, field: 'PlacaTracto', width: 50, cssClass: 'text-center' });
            columns.push({ id: 'CodigoMoneda', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColCodigoMoneda, field: 'CodigoMoneda', width: 50, cssClass: 'text-center' });
            columns.push({ id: 'MontoSoles', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColMontoSoles, field: 'MontoSoles', width: 50, cssClass: 'text-center' });
            columns.push({ id: 'MontoDolares', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColMontoDolares, field: 'MontoDolares', width: 50, cssClass: 'text-center' });
            columns.push({ id: 'NumeroSolicitudARendirSap', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColNumeroSolicitudARendirSap, field: 'NumeroSolicitudARendirSap', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'OrdenInterna', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColOrdenInterna, field: 'OrdenInterna', width: 50, cssClass: 'text-center' });
            columns.push({ id: 'UsuarioSolicita', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColUsuarioSolicita, field: 'UsuarioSolicita', width: 250, cssClass: 'text-center' });
            columns.push({ id: 'UsuarioAprueba', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColUsuarioAprueba, field: 'UsuarioAprueba', width: 250, cssClass: 'text-center' });
            //columns.push({ id: 'CodigoTipoCaja', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColCodigoTipoCaja, field: 'CodigoTipoCaja', width: 0, cssClass: 'text-center' });
            columns.push({ id: 'TipoCaja', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColTipoCaja, field: 'NombreTipoCaja', width: 150, cssClass: 'text-center' });
            //columns.push({ id: 'CodigoMedioPago', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColCodigoMedioPago, field: 'CodigoMedioPago', width: 0, cssClass: 'text-center' });
            columns.push({ id: 'MedioPago', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColMedioPago, field: 'NombreMedioPago', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'EstadoSolicitudSap', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColEstadoSolicitudSap, field: 'EstadoSolicitudSap', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'FechaPago', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColFechaPago, field: 'FechaPago', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'Banco', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColBanco, field: 'NombreBanco', width: 100, cssClass: 'text-center' });
            columns.push({ id: 'NumeroOperacionValeCaja', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColNumeroOperacionValeCaja, field: 'NumeroOperacionOValeCaja', width: 100, cssClass: 'text-center' });

            columns.push({ id: 'FechaSalida', name: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Resources.EtiquetaColFechaSalida, field: 'FechaSalida', width: 250, cssClass: 'text-center' });


            base.Control.GridResultado = new Delfin.Web.Std.Components.Grid({
               renderTo: 'divGridResultadoSolicitudesAtendidas',
               isPager: false,
               isServerPaging: false,
               proxy: {
                  action: Delfin.Web.Std.DistribucionSolicitudFondos.SolicitudesAtendidas.Actions.ConsultarSap,
                  data: base.Parametros.Consulta
               },
               columns: columns,
               isCheckboxSelector: true,
               height: 160,
               isSeleccionarIdSolicitud: true
            });
         }
      };
   };
} catch (ex) {
   alert(ex.message);
}