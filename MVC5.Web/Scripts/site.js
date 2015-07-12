
$(function() {
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

var LoginForm = new Object();

LoginForm.onSuccess = function () {
    $('#loginModal').modal('show');
};

LoginForm.onBegin = function () {
    noty({
        text: "مشتری گرامی لطفا صبر کنید",
        type: "information",
        dismissQueue: true,
        modal: false,
        killer: true,
        timeout: 2000,
        layout: 'center',
        theme: 'relax',
        animation: {
            open: 'animated fadeIn', // Animate.css class names
            close: 'animated fadeOut', // Animate.css class names
            easing: 'swing', // unavailable - no need
            speed: 500 // unavailable - no need
        }
    });
};
LoginForm.onError = function () {
    noty({
        text: "مشتری گرامی مشکل فنی ایجاد شده لطفا با مدیریت تماس بکیرید",
        type: "error",
        dismissQueue: true,
        modal: false,
        killer: true,
        timeout: 2000,
        layout: 'center',
        theme: 'relax',
        animation: {
            open: 'animated fadeIn', // Animate.css class names
            close: 'animated fadeOut', // Animate.css class names
            easing: 'swing', // unavailable - no need
            speed: 500 // unavailable - no need
        }
    });
};
/*###################      registerform     #################*/

var RegisterForm = new Object();

RegisterForm.onSuccess = function () {
    $('#registerModal').modal('show');
};

RegisterForm.onBegin = function () {

    noty({
        text: "مشتری گرامی لطفا صبر کنید",
        type: "information",
        dismissQueue: true,
        modal: false,
        killer: true,
        timeout: 2000,
        layout: 'center',
        theme: 'relax',
        animation: {
            open: 'animated fadeIn', // Animate.css class names
            close: 'animated fadeOut', // Animate.css class names
            easing: 'swing', // unavailable - no need
            speed: 500 // unavailable - no need
        }
    });
};
RegisterForm.onError = function () {
    noty({
        text: "مشتری گرامی مشکل فنی ایجاد شده لطفا با مدیریت تماس بکیرید",
        type: "error",
        dismissQueue: true,
        modal: false,
        killer: true,
        timeout: 2000,
        layout: 'center',
        theme: 'relax',
        animation: {
            open: 'animated fadeIn', // Animate.css class names
            close: 'animated fadeOut', // Animate.css class names
            easing: 'swing', // unavailable - no need
            speed: 500 // unavailable - no need
        }
    });
};
var Home = new Object();
Home.RatingAndSlider = function () {
    if ($.cookie('totalInCart') != null)
        $('#shoppingCart').text(parseFloat($.cookie('totalInCart')).toFixed(1));
    if ($.cookie('totalInCompare') != null)
        $('#compare').text(parseFloat($.cookie('totalInCompare')).toFixed(0));
    $(".rating").rating();
    $(".rating-container").attr('dir', 'ltr');
    $('#siteSlideShow').sliderPro({
        width: 960,
        height: 340,
        arrows: true,
        buttons: false,
        waitForLayers: true,
        thumbnailWidth: 150,
        thumbnailHeight: 70,
        thumbnailPointer: true,
        autoplay: true,
        autoScaleLayers: false,
        breakpoints: {
            500: {
                thumbnailWidth: 120,
                thumbnailHeight: 50
            }
        }
    });
};

var Master = new Object();
Master.AutoComplete = function (url) {

    $("#term").keyup(function(e) {
        var $val = $(this).val();

        if ($val.length > 1) {
            $.ajaxSetup({ cache: false });
            $.ajax({
                type: "POST",
                url: url,
                data: JSON.stringify({q:$val}),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                complete: function (xhr, status) {
                    var data = xhr.responseText;
                    $("#masterSearch").html(data).show(600);
                }
            });
        }
    });
    //var formatItem = function (row) {
    //    if (!row) return "";
    //    return "<img  src='" + "" + "'?w=30&h=30&mode=crop' class='lazyload'/> " + row[0];
    //}
    //$(function () {
    //    $("#term").autocomplete(url, {
    //        dir: 'ltr',
    //        minChars: 2,
    //        delay: 5,
    //        mustMatch: false,
    //        max: 20,
    //        autoFill: false,
    //        matchContains: false,
    //        scroll: false,
    //        formatItem: formatItem
    //    }).result(function (evt, row, formatted) {
    //        if (!row) return;
    //        window.location = row[1];
    //    });
    //});
};

Master.JavaScript = function () {
    window.lazySizesConfig = {
        addClasses: true
    };

    $('.dropdown').hover(function () {
        $(this).find('.dropdown-menu').first().addClass('animated bounceInUp');
    },
        function () {
            $(this).find('.dropdown-menu').first().removeClass('animated bounceInUp');
        });
};

Master.Noty = function (func) {
    noty({
        text: "درحال بارگذاری اطلاعات در خواستی شما کاربر گرامی....",
        type: "information",
        dismissQueue: true,
        modal: true,
        killer: true,
        timeout: 2000,
        layout: 'center',
        theme: 'relax',

        animation: {
            open: 'animated fadeIn', // Animate.css class names
            close: 'animated fadeOut', // Animate.css class names
            easing: 'swing', // unavailable - no need
            speed: 500 // unavailable - no need
        }
    });
}