(function ($) {
    "use strict"

    $('.dropify-default .dropify').dropify();

    $('.dropify-message .dropify').dropify({
        messages: {
            'default': 'فایل خود را برای بارگزاری کشیده و اینجا رها کنید یا کلیک کنید',
            'replace': 'برای جایگزینی بکشید و اینجا رها کنید یا کلیک کنید',
            'remove': 'حذف',
            'error': 'اوه، خطایی رخ داده است!'
        }
    });

    $('.dropify-error .dropify').dropify({
        error: {
            'fileSize': 'فایل شما خیلی بزرگ است ({{ value }} حداکثر)',
            'minWidth': 'عرض تصویر شما خیلی کوچک است ({{ value }}}px حداقل)',
            'maxWidth': 'عرض تصویر شما خیلی بزرگ است ({{ value }}}px حداکثر)',
            'minHeight': 'ارتفاع تصویر خیلی کوچک است ({{ value }}}px حداقل)',
            'maxHeight': 'ارتفاع تصویر خیلی زیاد است ({{ value }}px حداکثر)',
            'imageFormat': 'فرمت تصویر شما مجاز نمی باشد ({{ value }} فقط)'
        }
    });




})(jQuery);