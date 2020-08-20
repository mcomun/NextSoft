function postJson(url, data, success, error) {
   //$('#loading').show();
   $.ajax({
      url: url,
      data: data,
      type: 'POST',
      dataType: 'json',
      cache: false,
      success: success,
      error: error,
      //complete: function () {
      //    $('#loading').hide();
      //}
   });
}

function getJson(url, data, success, error) {
   //var result;
   $.ajax({
      url: url,
      data: data,
      type: 'GET',
      datatype: 'json',
      cache: false,
      async: false,
      success: success,
      error: error,
   });
   //return parseDatesInObject(result);
}

// jquery extend function
$.extend(
{
   redirectPost: function (location, args) {
      var form = '';
      $.each(args, function (key, value) {
         form += '<input type="hidden" name="' + key + '" value="' + value + '">';
      });
      $('<form action="' + location + '" method="POST">' + form + '</form>').submit();
   }
});