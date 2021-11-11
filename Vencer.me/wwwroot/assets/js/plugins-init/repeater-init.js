(function ($) {
    "use strict"

    $('.repeater-default').repeater();


    $('.repeater-custom').repeater({
        show: function () {
            $(this).slideDown();
        },
        hide: function (remove) {
            if (confirm('آیا از حذف این آیتم مطمئن هستید؟')) {
                $(this).slideUp(remove);
            }
        }
    });


    $('.repeater-default-value').repeater({
        defaultValues: {
            features: ['abs'],
            make: 'ford',
            model: 'جک S5'
        }
    });















})(jQuery);