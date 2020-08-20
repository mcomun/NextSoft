﻿$.validator.methods.number = function (value, element) {
   var patron = '^-?(?:\\d+|\\d{1' + Delfin.Web.Std.Global.Format.DecimalSeparatorMiles + '3}(?:' + Delfin.Web.Std.Global.Format.DecimalSeparatorMiles + '\\d{3})+)(?:\\' + Delfin.Web.Std.Global.Format.DecimalSeparatorDecimal + '\\d+)?$';
    var regexp = new RegExp(patron);

    return this.optional(element) || true;
};

$.validator.methods.max = function (value, element, param) {
    value = convertirDecimal(value.toString());
    return this.optional(element) || value <= param;
};

$.validator.methods.min = function (value, element, param) {
    value = convertirDecimal(value.toString());
    return this.optional(element) || value >= param;
};

ns('Delfin.Web.Std.Components.Validator');
Delfin.Web.Std.Components.Validator = function (opts) {
    this.init(opts);
};

Delfin.Web.Std.Components.Validator.prototype = {
    form: null,
    validationsExtra: null,
    messages: null,
    validator: null,
    errorMessage: null,
    title: null,
    rulesExtra: null,
    messagesExtra: false,//Begin Politica
    idDivSummaryErrorMessage : null,
    init: function (opts) {
        if (opts) {
            this.form = opts.form ? $('#' + opts.form) : null;
            this.validationsExtra = opts.validationsExtra ? opts.validationsExtra : null;
            this.rulesExtra = opts.rulesExtra ? opts.rulesExtra : null;
            this.messages = opts.messages ? opts.messages : null;
            this.title = opts.title ? opts.title : null;
            this.messagesExtra = opts.messagesExtra ? opts.messagesExtra : null//Begin Politica
            
            if (this.form != null) {
                this.idDivSummaryErrorMessage = this.form.attr('id') + 'SummaryErrorMessage';
                this.errorMessage = new Delfin.Web.Std.Components.Message();
                this.validator = this.form.validate();
                this.validator.settings.success = 'valid';
                this.validator.settings.errorClass = 'hasError';
                var spinnerErrorClass = 'spinner-error';
                this.validator.settings.errorElement = 'span';
                this.validator.settings.highlight = function (element, errorClass, validClass) {
                    if (element.type === 'radio') {
                        this.findByName(element.name).addClass(errorClass).removeClass(validClass);
                    } else {
                        $(element).addClass(errorClass).removeClass(validClass);
                        if ($(element).parent().hasClass('ui-spinner')) {
                            $(element).parent().addClass(spinnerErrorClass);
                        }
                    }
                };

                this.validator.settings.unhighlight = function (element, errorClass, validClass) {
                    if (element.type === 'radio') {
                        this.findByName(element.name).removeClass(errorClass).addClass(validClass);
                    } else {
                        $(element).removeClass(errorClass).addClass(validClass);
                        if ($(element).parent().hasClass('ui-spinner')) {
                            $(element).parent().removeClass(spinnerErrorClass);
                        }
                    }
                };

                this.validator.settings.errorPlacement = null;
                this.validator.settings.showErrors = this.showErrors;
                this.validator.settings.ignore = '';
                this.configure();
            }
        }
    },

    showErrors: function (errorMap, errorList) {
        for (var i = 0; this.errorList[i]; i++) {
            var error = this.errorList[i];
            var labelError = '';
            this.settings.highlight && this.settings.highlight.call(this, error.element, this.settings.errorClass, this.settings.validClass);
            this.showLabel(error.element, labelError);
        }

        if (this.errorList.length) {
            this.toShow = this.toShow.add(this.containers);
        }

        if (this.settings.success) {
            for (var i = 0; this.successList[i]; i++) {
                this.showLabel(this.successList[i]);
            }
        }

        if (this.settings.unhighlight) {
            for (var i = 0, elements = this.validElements() ; elements[i]; i++) {
                this.settings.unhighlight.call(this, elements[i], this.settings.errorClass, this.settings.validClass);
            }
        }

        this.toHide = this.toHide.not(this.toShow).not('.ui-spinner');
        this.hideErrors();
        this.addWrapper(this.toShow).show();
    },

    configure: function () {
        var base = this;

        var rules = {};
        var messages = {};
        var messagesExtra = {};//Begin Politica
        base.form.find('[validable]').each(function () {
            var nameControl = $(this).attr('name');

            if (nameControl == undefined) {
                var id = $(this).attr('id');
                $(this).attr('name', id);
                nameControl = $(this).attr('name');
            }

            var settingsControl = {};
            var settingsMessage = {};
            var validations = $(this).attr('validable').split(',');

            for (var i = 0; i < validations.length; i++) {
                var attributes = $.trim(validations[i]).split(' ');
                var typeValidation = $.trim(attributes[0]);
                var newValue = (typeValidation == 'required');
                var value = $.trim(attributes[1]);
                var codeMessage;

                if (value == 'true') {
                    var newValue = true;
                } else if (value == 'false') {
                    var newValue = false;
                } else if ($.isNumeric(value)) {
                    var newValue = parseFloat(value);
                } else {
                    codeMessage = value;
                }

                if (attributes.length > 2) {
                    codeMessage = $.trim(attributes[2]);
                }

                settingsControl[typeValidation] = newValue;
                settingsMessage[typeValidation] = base.messages[codeMessage];
            }

            rules[nameControl] = settingsControl;
            messages[nameControl] = settingsMessage;
        });

        if (this.rulesExtra != null) {
            for (var i = 0; i < this.rulesExtra.length; i++) {
                var rule = this.rulesExtra[i];
                rules[rule.nameControl] = rule.settings;
                messages[rule.nameControl] = rule.message;
            }
        }

        base.validator.settings.rules = rules;
        base.validator.settings.messages = messages;
    },

    isValid: function () {
        var valid = this.generateSummaryError();
        return valid;
    },

    reset: function () {
        this.deleteSummary();
        this.validator.resetForm();
    },

    generateSummaryError: function () {
       var summaryHtml = Delfin.Web.Std.Shared.General.Resources.EtiquetaDebeIngresar + ' ';
        var valid = true;
        var base = this;

        if (this.messagesExtra != null)//Begin Politica
           summaryHtml = Delfin.Web.Std.Shared.General.Resources.EtiquetaDebeSeleccionar + ' ';//End Politica
        
        var msj = this.messages;
        this.validator.form();
        valid = this.validator.valid();

        if (this.validator.errorList.length > 0) {
            for (var i = 0; i < this.validator.errorList.length; i++) {
                var error = this.validator.errorList[i];
                if (i == 0) {
                    summaryHtml = summaryHtml + ' ' + error.message;
                } else {
                    summaryHtml = summaryHtml + ', ' + error.message;
                }
            }
        }

        if (this.validationsExtra != null) {
            for (var i = 0; i < this.validationsExtra.length; i++) {

                var error = this.validationsExtra[i];
                if (error.Event && error.Event != null && !error.Event.apply(error, error.Args)) {
                    if (valid == true) {
                        summaryHtml = summaryHtml + ' ' + base.messages[error.codeMessage];
                    } else {
                        summaryHtml = summaryHtml + ', ' + base.messages[error.codeMessage];
                    }
                    valid = false;
                }

            }
        }

        summaryHtml = summaryHtml + '.';
        this.deleteSummary();

        if (!valid) {
            var divErrorMessage = $('<div />');
            divErrorMessage.attr('id', this.idDivSummaryErrorMessage);
            divErrorMessage.attr('class', 'alert alert-danger');
            divErrorMessage.html(summaryHtml);
            this.form.before(divErrorMessage);
        }

        return valid;
    },

    deleteSummary: function () {
        if ($('#' + this.idDivSummaryErrorMessage).length > 0) {
            $('#' + this.idDivSummaryErrorMessage).remove();
        }
    }
}