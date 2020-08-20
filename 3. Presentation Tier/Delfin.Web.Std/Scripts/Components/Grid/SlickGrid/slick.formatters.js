/*
 * Contains basic SlickGrid formatters.
 * 
 * NOTE:  These are merely examples.  You will most likely need to implement something more
 *        robust/extensible/localizable/etc. for your use!
 * 
 * @module Formatters
 * @namespace Slick
 */

(function ($) {
    // register namespace
    $.extend(true, window, {
        "Slick": {
            "Formatters": {
                "PercentComplete": PercentCompleteFormatter,
                "PercentCompleteBar": PercentCompleteBarFormatter,
                "YesNo": YesNoFormatter,
                "Checkmark": CheckmarkFormatter,
                "Select": SelectFormatter
            }
        }
    });
    //function DateFormatter(row, cell, value, columnDef, dataContext) {
    //    //'ddmmyyyy'
    //   //// var myDate = new Date(value);
    //   // var jsonWithDates = value.replace(/"\/Date\((\d+)\)\/"/g, 'new Date($1)');
    //   // var myDate = jsonWithDates.evalJSON(true);
    //   // return myDate.getDate() + "/" + (myDate.getMonth() + 1) + "/" + myDate.getFullYear();
    //}

    function SelectFormatter(row, cell, value, columnDef, dataContext) {
        var output = value;

        if (columnDef.editor == Slick.Editors.Select) {
            var options = columnDef.options;
            for (var i = 0; i < options.length; i++) {
                var option = options[i];
                if (option.Id == dataContext[columnDef.field]) {
                    output = option.Name;
                    break;
                }
            }
        }

        return output;
    }
    function PercentCompleteFormatter(row, cell, value, columnDef, dataContext) {
        if (value == null || value === "") {
            return "-";
        } else if (value < 50) {
            return "<span style='color:red;font-weight:bold;'>" + value + "%</span>";
        } else {
            return "<span style='color:green'>" + value + "%</span>";
        }
    }

    function PercentCompleteBarFormatter(row, cell, value, columnDef, dataContext) {
        if (value == null || value === "") {
            return "";
        }

        var color;

        if (value < 30) {
            color = "red";
        } else if (value < 70) {
            color = "silver";
        } else {
            color = "green";
        }

        return "<span class='percent-complete-bar' style='background:" + color + ";width:" + value + "%'></span>";
    }

    function YesNoFormatter(row, cell, value, columnDef, dataContext) {
        return value ? "Yes" : "No";
    }

    function CheckmarkFormatter(row, cell, value, columnDef, dataContext) {
        return value ? "<img src='../Scripts/SlickGrid/images/tick.png'>" : "";
    }
})(jQuery);
