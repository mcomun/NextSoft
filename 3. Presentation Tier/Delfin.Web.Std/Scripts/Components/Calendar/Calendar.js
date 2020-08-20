ns('Delfin.Web.Std.Components');
Delfin.Web.Std.Components.Calendar = function (opts) {
    this.init(opts);
};

Delfin.Web.Std.Components.Calendar.prototype = {
    inputFrom: null,
    inputTo: null,
    init: function (opts) {
        this.inputFrom = opts.inputFrom ? opts.inputFrom : null;
        this.inputTo = opts.inputTo ? opts.inputTo : null;
        var me = this;
        //this._privateFunction

        if (this.inputFrom && this.inputFrom != null) {
            var configFrom = {
               dateFormat: Delfin.Web.Std.Global.Format.Date,
                onClose: function (selected) {
                    var result = ValidarFechaOnBlur(this);
                    
                    if (me.inputTo && me.inputTo != null) {
                        if (result) {
                            me.inputTo.datepicker('option', 'minDate', selected);
                        }
                        else {
                            me.inputTo.datepicker('option', 'minDate', null);
                        }
                    }
                }
            };

            if (opts.maxDateFrom && opts.maxDateFrom != null) {
                configFrom.maxDate = opts.maxDateFrom;
            }

            if (opts.minDateFrom && opts.minDateFrom != null) {
                configFrom.minDate = opts.minDateFrom;
            }

            this.inputFrom.datepicker(configFrom);
            this.inputFrom.bind("blur", function () {
                return ValidarFechaOnBlur(this);
            });

            this.inputFrom.mask(Delfin.Web.Std.Global.Format.DatePicker);
            
            if (me.inputTo && me.inputTo != null) {
                this.inputFrom.change(function () {
                    if ($(this).val() == "" || $(this).val() == null) {
                        me.inputTo.datepicker('option', 'minDate', null);
                    }
                });
            }
        }

        if (this.inputTo && this.inputTo != null) {
            var configTo = {
               dateFormat: Delfin.Web.Std.Global.Format.Date,
                onClose: function (selected) {
                    var result = ValidarFechaOnBlur(this);
                    
                    if (me.inputFrom && me.inputFrom != null) {
                        if (result) {
                            me.inputFrom.datepicker('option', 'maxDate', selected);
                        }
                        else {
                            me.inputFrom.datepicker('option', 'maxDate', null);
                        }
                    }
                }
            };

            if (opts.maxDateTo && opts.maxDateTo != null) {
                configTo.maxDate = opts.maxDateTo;
            }

            this.inputTo.datepicker(configTo);
            this.inputTo.bind("blur", function () {
                return ValidarFechaOnBlur(this);
            });
            this.inputTo.mask(Delfin.Web.Std.Global.Format.DatePicker);
            
            if (me.inputFrom && me.inputFrom != null) {
                this.inputTo.change(function () {
                    if ($(this).val() == "" || $(this).val() == null) {
                        me.inputFrom.datepicker('option', 'maxDate', null);
                    }
                });
            }
        }
    },

    destroy: function () {
        if (this.inputFrom) {
            this.inputFrom.datepicker("destroy");
        }

        if (this.inputTo) {
            this.inputTo.datepicker("destroy");
        }
    },

    _privateFunction: {
        createDatePicker: function (input, reference) {
            if (input && input != null) {
                input.datepicker({
                   dateFormat: Delfin.Web.Std.Global.Format.Date,
                    onClose: function (selected) {
                        if (reference && reference != null) {
                            reference.datepicker('option', 'minDate', selected);
                        }
                    }
                });
            }
        }
    }
};