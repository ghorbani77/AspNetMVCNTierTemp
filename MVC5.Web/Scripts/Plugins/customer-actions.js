var Customer = new Object();
Customer.Rate = function() {
    $('input[id^=rate]').on('rating.change', function (event, value, caption) {
        event.preventDefault();
        var rateElement = $(this).attr('id');
        $(this).StarRating({
            postInfoUrl: '/Product/SaveRatings',
            errorHandler: function () {
                $('#' + rateElement).rating('reset');
                noty({
                    text: "مشتری گرامی مشکلی در ثبت امتیاز شما بوجود آمده",
                    type: "error",
                    dismissQueue: true,
                    modal: true,
                    killer: true,
                    timeout: 3000,
                    layout: 'center',
                    theme: 'relax',
                    animation: {
                        open: 'animated fadeIn', // Animate.css class names
                        close: 'animated fadeOut', // Animate.css class names
                        easing: 'swing', // unavailable - no need
                        speed: 500 // unavailable - no need
                    }
                });
            },
            completeHandler: function () {
                noty({
                    text: "مشتری گرامی امتیاز شما با موفقیت ثبت شد.از توجه شما متشکریم",
                    type: "success",
                    dismissQueue: true,
                    modal: true,
                    timeout: 3000,
                    layout: 'center',
                    theme: 'relax',
                    killer: true,
                    animation: {
                        open: 'animated fadeIn', // Animate.css class names
                        close: 'animated fadeOut', // Animate.css class names
                        easing: 'swing', // unavailable - no need
                        speed: 500 // unavailable - no need
                    }
                });

            },
            onlyOneTimeHandler: function () {
                $('#' + rateElement).rating('reset');
                noty({
                    text: "مشتری گرامی شما فقط قادر هستید یکبار به هر کالا امتیاز دهید.با تشکر",
                    type: "warning",
                    dismissQueue: true,
                    modal: true,
                    maxVisible: 3,
                    timeout: 2000,
                    layout: 'center',
                    killer: true,
                    theme: 'relax',
                    animation: {
                        open: 'animated fadeIn', // Animate.css class names
                        close: 'animated fadeOut', // Animate.css class names
                        easing: 'swing', // unavailable - no need
                        speed: 500 // unavailable - no need
                    }
                });
            },
            authorizationHandler: function () {
                $('#' + rateElement).rating('reset');
                $('#loginMenuBtn').click();
            }
        });
    });
};

Customer.AddToCart = function() {
    $('button[id^=toCart]').click(function (event) {
        event.preventDefault();
        var $value = $('input[id="'+ $(this).attr('id').replace('toCart','value') + '"]').val();
        if ($value ==null)
            $value = 1;
        var btn = $(this);
        DoDisable(btn);
        $(this).ToCart({
            value:$value,
            postInfoUrl: '/ShoppingCart/AddToCart',
            errorHandler: function () {
                DoEnable(btn);
                noty({
                    text: "مشتری گرامی در خرید شما مشکلی بوجود آمده با بخض مدیریت تماس بگیرید.متشکریم",
                    type: "error",
                    dismissQueue: true,
                    modal: true,
                    killer: true,
                    timeout: 3000,
                    layout: 'center',
                    theme: 'relax',
                    animation: {
                        open: 'animated fadeIn', // Animate.css class names
                        close: 'animated fadeOut', // Animate.css class names
                        easing: 'swing', // unavailable - no need
                        speed: 500 // unavailable - no need
                    }
                });
            },
            completeHandler: function () {
                DoEnable(btn);
                $('#shoppingCart').text(parseFloat($.cookie('totalInCart')).toFixed(1));
                noty({
                    text: "مشتری گرامی کالای  مورد نظر با موفقیت  در سبد شما ثبت شد.از خرید شما متشکریم",
                    type: "success",
                    dismissQueue: true,
                    modal: true,
                    timeout: 3000,
                    layout: 'center',
                    killer: true,
                    theme: 'relax',
                    animation: {
                        open: 'animated fadeIn', // Animate.css class names
                        close: 'animated fadeOut', // Animate.css class names
                        easing: 'swing', // unavailable - no need
                        speed: 500 // unavailable - no need
                    }
                });
            },
            noInStockHandler: function () {
                DoEnable(btn);
                noty({
                    text: "مشتری گرامی مقدار مورد نظر شما در فروشکاه موجود نیست لطفا با بخش مدیریت تماس بگیرید.متشکریم",
                    type: "information",
                    dismissQueue: true,
                    modal: true,
                    maxVisible: 3,
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
            },
            authorizationHandler: function () {
                DoEnable(btn);
                $('#loginMenuBtn').click();
            }
        });
        return false;
    });
};

Customer.AddToWishList = function() {
    $('button[id^=toWish]').click(function (event) {
        event.preventDefault();
        var btn = $(this);
        DoDisable(btn);
        $(this).ToWish({
            postInfoUrl: '/Product/AddToWishList',
            errorHandler: function () {
                DoEnable(btn);
                noty({
                    text: "مشتری گرامی در ثیت اطلاعات مشکلی بوجود آمده با بخض مدیریت تماس بگیرید.متشکریم",
                    type: "error",
                    dismissQueue: true,
                    modal: true,
                    timeout: 3000,
                    killer: true,
                    layout: 'center',
                    theme: 'relax',
                    animation: {
                        open: 'animated fadeIn', // Animate.css class names
                        close: 'animated fadeOut', // Animate.css class names
                        easing: 'swing', // unavailable - no need
                        speed: 500 // unavailable - no need
                    }
                });
            },
            completeHandler: function () {
                DoEnable(btn);
                noty({
                    text: "مشتری گرامی کالای  مورد نظر با موفقیت  در لیست علاقه شما ثبت شد.متشکریم",
                    type: "success",
                    dismissQueue: true,
                    modal: true,
                    timeout: 3000,
                    layout: 'center',
                    killer: true,
                    theme: 'relax',
                    animation: {
                        open: 'animated fadeIn', // Animate.css class names
                        close: 'animated fadeOut', // Animate.css class names
                        easing: 'swing', // unavailable - no need
                        speed: 500 // unavailable - no need
                    }
                });
            },
            isInYourWishHandler: function () {
                DoEnable(btn);
                noty({
                    text: "مشتری گرامی محصول مورد نظر  در لیست علاقه شما موجود است ",
                    type: "information",
                    dismissQueue: true,
                    modal: true,
                    maxVisible: 3,
                    timeout: 2000,
                    layout: 'center',
                    killer: true,
                    theme: 'relax',
                    animation: {
                        open: 'animated fadeIn', // Animate.css class names
                        close: 'animated fadeOut', // Animate.css class names
                        easing: 'swing', // unavailable - no need
                        speed: 500 // unavailable - no need
                    }
                });
            },
            limitationHandler: function () {
                DoEnable(btn);
                noty({
                    text: "مشتری گرامی لیست علاقه مندی های شما پر شده است",
                    type: "warning",
                    dismissQueue: true,
                    modal: true,
                    maxVisible: 3,
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
            },
            authorizationHandler: function () {
                DoEnable(btn);
                $('#loginMenuBtn').click();
            }
        });
        return false;
    });
};

Customer.AddToCompare = function() {
    $('button[id^=toCompare]').click(function (event) {
        
        var btn = $(this);
        DoDisable(btn);
        event.preventDefault();
        $(this).ToCompare({
            postInfoUrl: '/Product/AddToCompareList',
            errorHandler: function () {
                DoEnable(btn);
                noty({
                    text: "مشتری گرامی در ثیت اطلاعات مشکلی بوجود آمده با بخض مدیریت تماس بگیرید.متشکریم",
                    type: "error",
                    dismissQueue: true,
                    modal: true,
                    timeout: 3000,
                    killer: true,
                    layout: 'center',
                    theme: 'relax',
                    animation: {
                        open: 'animated fadeIn', // Animate.css class names
                        close: 'animated fadeOut', // Animate.css class names
                        easing: 'swing', // unavailable - no need
                        speed: 500 // unavailable - no need
                    }
                });
            },
            completeHandler: function () {
                $('#compare').text(parseFloat($.cookie('totalInCompare')).toFixed(0));
                DoEnable(btn);
                noty({
                    text: "مشتری گرامی کالای  مورد نظر با موفقیت  در لیست مقایسه شما ثبت شد.متشکریم",
                    type: "success",
                    dismissQueue: true,
                    modal: true,
                    timeout: 3000,
                    layout: 'center',
                    killer: true,
                    theme: 'relax',
                    animation: {
                        open: 'animated fadeIn', // Animate.css class names
                        close: 'animated fadeOut', // Animate.css class names
                        easing: 'swing', // unavailable - no need
                        speed: 500 // unavailable - no need
                    }
                });
            },
            isInYourCompareHandler: function () {
                DoEnable(btn);
                noty({
                    text: "مشتری گرامی محصول مورد نظر  در لیست مقایسه شما موجود است ",
                    type: "information",
                    dismissQueue: true,
                    modal: true,
                    maxVisible: 3,
                    timeout: 2000,
                    killer: true,
                    layout: 'center',
                    theme: 'relax',
                    animation: {
                        open: 'animated fadeIn', // Animate.css class names
                        close: 'animated fadeOut', // Animate.css class names
                        easing: 'swing', // unavailable - no need
                        speed: 500 // unavailable - no need
                    }
                });
            },
            limitationNotHandler: function () {
                DoEnable(btn);
                noty({
                    text: "مشتری گرامی شما قادر هستید فقط 5 کالا را برای مقایسه انتخاب کنید.متشکریم",
                    type: "information",
                    dismissQueue: true,
                    modal: true,
                    maxVisible: 3,
                    timeout: 2000,
                    layout: 'center',
                    killer: true,
                    theme: 'relax',
                    animation: {
                        open: 'animated fadeIn', // Animate.css class names
                        close: 'animated fadeOut', // Animate.css class names
                        easing: 'swing', // unavailable - no need
                        speed: 500 // unavailable - no need
                    }
                });
            },
            authorizationHandler: function () {
                DoEnable(btn);
                $('#loginMenuBtn').click();
            }
        });
        return false;
    });
};


function DoDisable(elem) {
    elem.attr('disabled', 'disabled');
}
function DoEnable(elem) {
    elem.removeAttr('disabled');
}