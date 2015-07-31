
$(function () {
    Public.Routin();
});
/*#####################   pblic       ###################*/

var Public = new Object();
Public.Routin = function () {

    $('[data-toggle="tooltip"]').tooltip();
    //$('[data-val-number]').each(function () {
    //    var el = $(this);
    //    var orig = el.data('val-number');

    //    var fieldName = orig.replace('The field ', '');
    //    fieldName = fieldName.replace(' must be a number.', '');

    //    el.attr('data-val-number', fieldName + ' باید عددی باشد');
    //});
    $(".pagination").addClass("pagination-sm");
    $('a.nofollow').attr('rel', 'nofollow');
};



/*####################  Prevent Navigation ###############*/


var warningBeforeLoad= function() {
    var msg = "اطلاعات دخیره نشده ای در این صفحه دارید و با" +
        " هدایت به صفحه بعد این اطلاعات را از دست خواهید داد";
    $('button:button').click(function() {
        msg = null;
    });
    $('input:not(:button,:submit),textarea,select').change(function() {
        window.onbeforeunload = function () {
            if(msg!=null)
                 return  msg;
        };
    });
    $('input:checkbox,input:radio').click(function() {
        window.onbeforeunload = function() {
            if (msg != null)
                return msg;
        };
    });
}

function onComplete(xhr, status) {
    var data = xhr.responseText;
    if (xhr.status == 403) {
        window.location ='/Account/Login'; 
    }
}