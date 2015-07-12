// <![CDATA[
(function ($) {
    $.fn.ToCart = function (options) {
        var defaults = {
            postInfoUrl: '/',
            loginUrl: '/Customer/Login',
            value: 1,
            errorHandler: null,
            completeHandler: null,
            noInStockHandler: null,
            authorizationHandler: function () { window.location = options.loginUrl; }
        };
        var options = $.extend(defaults, options);

        return this.each(function () {
            var product = $(this);
            var dataJsonArray = { productId: product.attr('id').replace('toCart-', ''), value: options.value };
            $.ajaxSetup({ cache: false });
            $.ajax({
                type: "POST",
                url: options.postInfoUrl,
                data: JSON.stringify(dataJsonArray),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                complete: function (xhr, status) {
                    var data = xhr.responseText;
                    if (xhr.status == 403) {
                        options.authorizationHandler(this);
                    }
                    else if (status === 'error' || !data) {
                        if (options.errorHandler)
                            options.errorHandler(this);
                    }
                    else if (data == "nok") {
                        if (options.noInStockHandler)
                            options.noInStockHandler(this);
                    }
                    else {
                        if (options.completeHandler)
                            options.completeHandler(this);
                    }
                }
            });
            return false;
        });
    };
})(jQuery);
// ]]>