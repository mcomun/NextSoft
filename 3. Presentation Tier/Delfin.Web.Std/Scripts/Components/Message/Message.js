ns('Delfin.Web.Std.Components');
ns('Delfin.Web.Std.Shared.General.Resources')
Delfin.Web.Std.Components.Message = function (opts) {
    this.init(opts);
};

Delfin.Web.Std.Components.Message.prototype = {
    init: function (opts) {
        this._privateFunction.createMessage.apply(this, [opts]);
        ResultConfirm = false;
    },

    Information: function (opts) {
        opts.dialogClass = 'message-dialog-information';
        opts.position = { my: "right top", at: "right top", of: window };
        opts.title = opts.title ? opts.title : Delfin.Web.Std.Shared.General.Resources.EtiquetaInformacion;
        opts.title = '<strong>' + opts.title + ' : </strong>'
        opts.message = opts.title + opts.message;
        opts.message = '<div class="alert alert-success">' + opts.message + '</div>';
        opts.modal = false;
        opts.minWidth = 550;
        opts.minHeight = 60;
        this._privateFunction.show.apply(this, [opts]);
        
        if (this.divDialog) {
            var me = this;
            this.informationTimeOut = setTimeout(function () {
                me.divDialog.close();
            }, 2500);
        }
    },

    InformationCustom: function (opts) {
        var me = this;
        opts.dialogClass = 'message-dialog-informationCustom';
        opts.position = { my: "right top", at: "right top", of: window };
        opts.title = opts.title ? opts.title : Delfin.Web.Std.Shared.General.Resources.EtiquetaInformacion;
        opts.title = '<strong>' + opts.title + ' : </strong>'
        opts.message = opts.title + opts.message;
        opts.message = '<div class="alert alert-success">' + opts.message + '</div>';
        opts.modal = true;
        opts.minWidth = 550;
        opts.minHeight = 60;
        opts.buttons = [{
           text: opts.textConfirmar ? opts.textConfirmar : Delfin.Web.Std.Shared.General.Resources.EtiquetaAceptarConfirmacion,
            'class': 'ui-button-Confirmar',
            click: function () {
                if (me.divDialog) {
                    me.divDialog.close();
                }
            }
        }
        ];
        this._privateFunction.show.apply(this, [opts]);
    },

    ResultConfirm: false,
    Confirmation: function (opts) {
        var me = this;
        opts.dialogClass = 'message-dialog-confirmation';
        opts.title = opts.title ? opts.title : Delfin.Web.Std.Shared.General.Resources.EtiquetaConfirmacion;
        opts.buttons = [
                            {
                               //text: Delfin.Web.Std.Shared.General.Resources.EtiquetaAceptarConfirmacion,
                               text: opts.textConfirmar ? opts.textConfirmar : Delfin.Web.Std.Shared.General.Resources.EtiquetaAceptarConfirmacion,
                                'class': 'ui-button-Confirmar',
                                click: function () {
                                    ResultConfirm = true;
                                    if (me.divDialog) {
                                        me.divDialog.close();
                                    }
                                    setTimeout(function () {
                                        if (opts.onConfirm) {
                                            opts.onConfirm(true);
                                        }
                                        if (opts.onAccept) {
                                            opts.onAccept();
                                        }
                                    }, 100);
                                }
                            },
                            {
                               //text: Delfin.Web.Std.Shared.General.Resources.EtiquetaCancelarConfirmacion,
                               text: opts.textCancelar ? opts.textCancelar : Delfin.Web.Std.Shared.General.Resources.EtiquetaCancelarConfirmacion,
                                'class': 'ui-button-Cancelar',
                                click: function () {
                                    if (me.divDialog) {
                                        me.divDialog.close();
                                    }
                                    setTimeout(function () {
                                        if (opts.onConfirm) {
                                            opts.onConfirm(false);
                                        }
                                        if (opts.onCancel) {
                                            opts.onCancel();
                                        }
                                    }, 100);

                                }
                            }
        ];
        //D: Eliminado
        //opts.buttons = {
        //    Acceptar: function () {
        //        ResultConfirm = true;
        //        if (me.divDialog) {
        //            me.divDialog.close();
        //        }
        //        setTimeout(function () {
        //            if (opts.onConfirm) {
        //                opts.onConfirm(true);
        //            }
        //            if (opts.onAccept) {
        //                opts.onAccept();
        //            }
        //        }, 100);
        //    },
        //    Cancelar: function () {
        //        if (me.divDialog) {
        //            me.divDialog.close();
        //        }
        //        setTimeout(function () {
        //            if (opts.onConfirm) {
        //                opts.onConfirm(false);
        //            }
        //            if (opts.onCancel) {
        //                opts.onCancel();
        //            }
        //        }, 100);

        //    }
        //};
        this._privateFunction.show.apply(this, [opts]);
    },

    Warning: function (opts) {
        opts.dialogClass = 'message-dialog-warning';
        opts.title = opts.title ? opts.title : Delfin.Web.Std.Shared.General.Resources.EtiquetaAdvertencia;
        opts.message = '<div class="alert alert-warning">' + opts.message + '</div>';
        this._privateFunction.show.apply(this, [opts]);
    },

    Error: function (opts) {
        opts.dialogClass = 'message-dialog-error';
        opts.title = opts.title ? opts.title : 'Error';
        opts.message = '<div class="alert alert-danger">' + opts.message + '</div>';
        this._privateFunction.show.apply(this, [opts]);
    },

    setMessage: function (message) {
        this.divDialog.setContent(message);
    },

    onClose: null,

    destroy: function () {
        if (this.divDialog) {
            this.divDialog.destroy();
        }
    },

    _privateFunction: {
        createMessage: function (opts) {
            var me = this;
            this.divDialog = new Delfin.Web.Std.Components.Dialog({
                closeOnEscape: false,
                close: function (event, ui) { if (me.onClose && me.onClose != null) { me.onClose(event, ui); } },
                resizable: false,
                closeText: "Close",
                width: 300
            });

            this.divDialog.setClass('message-dialog-confirmation');
        },

        show: function (opts) {
            if (this.divDialog) {
                if (this.informationTimeOut) {
                    clearTimeout(this.informationTimeOut);
                }
                //opts.position = opts.position ? opts.position : { my: "center", at: "center", of: window };
                opts.modal = opts.modal == false ? opts.modal : true;
                //this.divDialog.setPosition(opts.position);
                this.divDialog.close();
                this.onClose = opts.onClose ? opts.onClose : null;
                this.divDialog.setTitle(opts.title);
                this.setMessage(opts.message);
                this.divDialog.setButtons(opts.buttons);
                this.divDialog.setClass(opts.dialogClass);
                this.divDialog.setModal(opts.modal);
                this.divDialog.setMinWidth(opts.minWidth);
                this.divDialog.setMinHeight(opts.minHeight);
                this.divDialog.open();
            }
        }
    }
};