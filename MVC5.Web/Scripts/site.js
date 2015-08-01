
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


var warningBeforeLoad = function () {
    var msg = "اطلاعات دخیره نشده ای در این صفحه دارید و با" +
        " هدایت به صفحه بعد این اطلاعات را از دست خواهید داد";
    $('button:button').click(function () {
        msg = null;
    });
    $('input:not(:button,:submit),textarea,select').change(function () {
        window.onbeforeunload = function () {
            if (msg != null)
                return msg;
        };
    });
    $('input:checkbox,input:radio').click(function () {
        window.onbeforeunload = function () {
            if (msg != null)
                return msg;
        };
    });
}

function onComplete(xhr, status) {
    var data = xhr.responseText;
    if (xhr.status == 403) {
        window.location = '/Account/Login';
    }
}

function makeUploadFile(id) {
    $("#" + id).fileinput({
        showUpload: false,
        previewFileType: "image",
        msgInvalidFileType: "از فایل معتبر استفاده کنید",
        //maxFileSize: "10000",
        msgSizeTooLarge: "حجم فایل مورد نظر بیشتر از حجم مورد قبول است",
        browseClass: "btn btn-success",
        browseLabel: "انتخاب تصویر",
        browseIcon: '<i class="glyphicon glyphicon-picture"></i>',
        removeClass: "btn btn-danger",
        removeLabel: "حذف",
        removeIcon: '<i class="glyphicon glyphicon-trash"></i>',
        allowedFileExtensions: ["jpg", "gif", "png"]
    });
}