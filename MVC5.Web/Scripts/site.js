
$(function () {
    $(".pagination").addClass("pagination-sm");
    $('a.nofollow').attr('rel', 'nofollow');
    AjaxForm.EnableBootstrapStyleValidation();
    AjaxForm.EnablePostbackValidation();
});
/*#####################   pblic       ###################*/

var Public = new Object();
Public.Routin = function () {

    $('[data-toggle="tooltip"]').tooltip();
    $('[data-val-number]').each(function () {
        var el = $(this);
        var orig = el.data('val-number');

        var fieldName = orig.replace('The field ', '');
        fieldName = fieldName.replace(' must be a number.', '');

        el.attr('data-val-number', fieldName + ' باید عددی باشد')
    });
    $(".pagination").addClass("pagination-sm").addClass("pull-left");
    $("button:has(.cancel)").removeClass("btn-lg").addClass("btn-md");
    $("input").attr("autocomplete", "off");
    $(".selectpicker").attr("data-live-search", "true").attr("data-size", "5").selectpicker();

};


var AjaxForm = new Object();

AjaxForm.EnableAjaxFormvalidate = function (formId) {
    $.validator.unobtrusive.parse('#' + formId);
};


AjaxForm.ValidateForm = function (formId) {
    var val = $('#' + formId).validate();
    val.form();
    return val.valid();
};

AjaxForm.DisableEnableButton = function (element, formId) {
    if (!AjaxForm.ValidateForm(formId)) return;
    $(element).button('loading');
    $('#' + formId).submit();
};

AjaxForm.EnablePostbackValidation = function () {
    $('form').each(function () {
        $(this).find('div.form-group').each(function () {
            if ($(this).find('span.field-validation-error').length > 0) {
                $(this).addClass('has-error');
            }
        });
    });
};

AjaxForm.EnableBootstrapStyleValidation = function () {
    $.validator.setDefaults({
        ignore: "",
        highlight: function (element, errorClass, validClass) {
            if (element.type === 'radio') {
                this.findByName(element.name).addClass(errorClass).removeClass(validClass);
            } else {
                $(element).addClass(errorClass).removeClass(validClass);
                $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
            }
            $(element).trigger('highlited');
        },
        unhighlight: function (element, errorClass, validClass) {
            if (element.type === 'radio') {
                this.findByName(element.name).removeClass(errorClass).addClass(validClass);
            } else {
                $(element).removeClass(errorClass).addClass(validClass);
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
            }
            $(element).trigger('unhighlited');
        }
    });
};

/*####################  loginform && forgetPassForm ###############*/


