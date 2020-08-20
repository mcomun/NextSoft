ns('Delfin.Web.Std.Components');
Delfin.Web.Std.Components.Ajax = function (opts) {
    this.init(opts);
};

Delfin.Web.Std.Components.Ajax.prototype = {
    form: null,
    content: null,
    action: null,
    data: null,
    updatePanel: null,
    updateForm: null,
    objectCall: null,
    showLoading: null,
    targetLoading: null,
    autoSubmit: null,
    ajaxRequest: null,
    async: null,
    method: null,
    dataType: null,
    processData: null,
    hasFile: null,

    CONTENT_TYPE_POST: 'application/json; charset=utf-8',
    CONTENT_TYPE_GET: 'text/json;',
    CONTENT_TYPE_FORM: 'application/x-www-form-urlencoded',
    init: function (opts) {
        this.async = this.async == false ? false : true;
        this.method = this.method ? this.method : 'POST';
        this.dataType = this.dataType ? this.dataType : 'json';
        this.showLoading = this.showLoading == false ? false : true;

        if (opts) {
            this.form = opts.form && opts.form != null ? document.getElementById(opts.form) : null;
            this.content = opts.content ? document.getElementById(opts.content) : null;
            this.action = opts.action && opts.action != null ? opts.action : (this.form != null && this.action == null) ? this.form.action : this.action;
            this.data = opts.data ? opts.data : {};
            this.updatePanel = opts.updatePanel ? $('#' + opts.updatePanel) : null;
            this.dataType = opts.dataType ? opts.dataType : (this.dataType && this.dataType != null) ? this.dataType : 'json';
            this.method = opts.method ? opts.method : 'POST';
            this.async = opts.async == false ? opts.async : true;
            this.processData = opts.processData == false ? opts.processData : true;
            this.hasFile = opts.hasFile == true ? opts.hasFile : false;
            this.onSuccess = opts.onSucces ? opts.onSucces : null; //Depreciado
            this.onSuccess = opts.onSuccess && this.onSuccess == null ? opts.onSuccess : this.onSuccess;
            this.onError = opts.onError ? opts.onError : this.onError;
            this.autoSubmit = opts.autoSubmit == false ? opts.autoSubmit : true;
            this.showLoading = opts.showLoading == false ? opts.showLoading : true;
            this.targetLoading = opts.targetLoading;
            this.updateForm = opts.updateForm && opts.updateForm != null ? document.getElementById(opts.updateForm) : null;

            if (this.autoSubmit) {
                this.submit();
            }
        }
    },

    dataJsonToForm: function (data) {
        if (data && data != null) {
            var valor = null;
            for (var i = 0; i < this.updateForm.elements.length; i++) {
                if (this.updateForm.elements[i].name && this.updateForm.elements[i].name != '') {
                    valor = data[this.updateForm.elements[i].name];

                    if (this.updateForm.elements[i].type.toUpperCase() == 'RADIO' || this.updateForm.elements[i].type.toUpperCase() == 'CHECKBOX') {
                        if (valor == null) {
                            valor = false;
                        }
                        this.updateForm.elements[i].checked = valor;
                    } else {
                        if (valor == null) {
                            valor = '';
                        }
                        this.updateForm.elements[i].value = valor;
                    }
                }
            }
        }
    },

    formToDataJSon: function () {
        this.data = this.data ? this.data : {};
        
        for (var i = 0; i < this.form.elements.length; i++) {
            if (this.form.elements[i].name && this.form.elements[i].name != '') {
                if (this.form.elements[i].type.toUpperCase() == 'RADIO' || this.form.elements[i].type.toUpperCase() == 'CHECKBOX') {
                    if (this.form.elements[i].checked) {
                        if (this.data[this.form.elements[i].name] != null) {
                            if (typeof this.data[this.form.elements[i].name] == 'string') {
                                var firstValueArray = this.data[this.form.elements[i].name];
                                this.data[this.form.elements[i].name] = null;
                                this.data[this.form.elements[i].name] = new Array();
                                this.data[this.form.elements[i].name][0] = firstValueArray;
                            }
                            this.data[this.form.elements[i].name][this.data[this.form.elements[i].name].length] = this.form.elements[i].value.toString().trim().toUpperCase();
                        }
                        else {
                            this.data[this.form.elements[i].name] = this.form.elements[i].value.toString().trim().toUpperCase();
                        }
                    }
                } else {
                    this.data[this.form.elements[i].name] = this.form.elements[i].value.toString().trim().toUpperCase();
                }
            }
        }
        return this.data;
    },

    contentToDataJSon: function () {
        this.data = this.data ? this.data : {};
        var ele = null;
        var name = '';
        var array = this.content.getElementsByTagName('*');
        
        for (var i = 0; i < array.length; i++) {
            ele = array[i];
            if ((ele.name && ele.name != '') || (ele.id && ele.id != '')) {
                name = (ele.id && ele.id != '') ? ele.id : '';
                name = (ele.name && ele.name != '') ? ele.name : name;
                if (ele.type.toUpperCase() == 'RADIO' || ele.type.toUpperCase() == 'CHECKBOX') {
                    if (ele.checked) {
                        this.data[name] = ele.value;

                        if (this.data[name] != null) {
                            if (typeof this.data[name] == 'string') {
                                var firstValueArray = this.data[name];
                                this.data[name] = null;
                                this.data[name] = new Array();
                                this.data[name][0] = firstValueArray;
                            }
                            this.data[name][this.data[name].length] = ele.value;
                        }
                        else {
                            this.data[name] = ele.value;
                        }
                    }
                } else {
                    this.data[name] = ele.value;
                }
            }
        }

        return this.data;
    },

    submit: function (customParam) {
        if (typeof this.form == 'string') {
            this.form = document.getElementById(this.form);
        }

        if (this.action == null && this.form != null) {
            this.action = this.form.action;
        }

        if (this.ajaxRequest != null) {
            this.abort();
        }

        if (this.form != null)
            this.formToDataJSon();

        if (this.content != null)
            this.contentToDataJSon();

        var me = this;
        this.ajaxRequest = $.ajax({
            type: this.method,
            url: this.action,
            async: this.async,
            cache: false,
            contentType: (this.hasFile) ? false : (this.dataType.toUpperCase() == 'SCRIPT') ? this.CONTENT_TYPE_FORM : (this.method.toUpperCase() == 'GET') ? this.CONTENT_TYPE_GET : this.CONTENT_TYPE_POST,
            dataType: this.dataType,
            data: (this.method.toUpperCase() == 'GET' || this.hasFile) ? this.data : JSON.stringify(this.data),
            processData: this.processData,
            customParams: me.customParams,
            /*xhr: function () {
                myXhr = $.ajaxSettings.xhr();
                if (me.showLoading == true) {

                    if (me.loading == null) {
                        me.implementLoading();
                    }

                    if (myXhr.upload) {

                        me.loading.setValue(0);
                        myXhr.upload.addEventListener("progress", function (evt) {
                            if (evt.lengthComputable) {
                                var percentComplete = ((evt.loaded / evt.total) * 30);
                                for (var i = 0 ; i < percentComplete ; i++) {
                                    setTimeout(function () {
                                        me.loading.setValue(me.loading.getValue() + i);
                                    }, 100);
                                }
                            }
                            else {
                                me.loading.setValue(false);
                            }
                        }, false);

                        myXhr.addEventListener("progress", function (evt) {
                            if (evt.lengthComputable) {
                                var percentComplete = ((evt.loaded / evt.total) * 30);
                                for (var i = 0 ; i < percentComplete ; i++) {
                                    setTimeout(function () {
                                        me.loading.setValue(me.loading.getValue() + i);
                                    }, 100);
                                }
                            }
                            else {
                                me.loading.setValue(false);
                            }
                        }, false);

                    }
                    else {
                        me.loading.setValue(false);
                    }
                }

                return myXhr;
            },*/
            beforeSend: function (jqXHR, settings) {
                if (me.showLoading == true) {
                    if (me.loading == null) {
                        me.implementLoading();
                    }

                    me.loading.setValue(false);
                    me.loading.show();
                }
            }
        });

        this.ajaxRequest.done(function (data) {
            if (data != null && data.Error != undefined) {
                alert(data.Error.Message);
                
                if (me.onError) {
                    me.onError(data.Error);
                }
            } else {
                if (me.updateForm != null) {
                    me.dataJsonToForm(data);
                }

                if (me.updatePanel != null) {
                    me.updatePanel.html(data);
                }

                if (me.showLoading == true && me.loading != null) {
                    me.loading.setValue(false);
                }

                if (me.onSuccess && me.onSuccess != null) {
                    me.onSuccess(data, customParam);
                }
                /*if (me.showLoading == true && me.loading != null) {
                    me.loading.setValue(100);
                }*/
            }

            me.data = null;
        });

        this.ajaxRequest.fail(function (jqXHR, textStatus, errorThrown) {
            if (!(textStatus == 'abort' && errorThrown == 'abort')) {
                if (me.onError) {
                    me.onError(errorThrown, textStatus, jqXHR);
                }
            }

            me.data = null;
        });

        this.ajaxRequest.always(function (jqXHR, textStatus) {
            if (me.showLoading == true && me.loading != null) {
                me.loading.hide();
            }
        });
    },

    send: function (data, onSuccess, onError) {
        this.data = data && data != null ? data : this.data;
        this.onSuccess = onSuccess ? onSuccess : this.onSuccess;
        this.onError = onError ? onError : this.onError;
        this.submit();
    },

    loading: null,

    implementLoading: function () {
       this.loading = new Delfin.Web.Std.Components.ProgressBar({ targetLoading: this.targetLoading });
    },

    abort: function () {
        if (this.ajaxRequest)
            this.ajaxRequest.abort();
    },

    onSuccess: null,
    onError: null
};