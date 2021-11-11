(function ($) {
    'use strict'

    $('select[name="duallistbox_demo1[]"]').bootstrapDualListbox();

    $('.demo2').bootstrapDualListbox({
        nonSelectedListLabel: 'انتخاب نشده',
        selectedListLabel: 'انتخاب شده',
        preserveSelectionOnMove: 'moved',
        moveOnSelect: false,
        nonSelectedFilter: 'گزینه ([7-9]|[1][0-2])'
    });

    let demo3 = $('.demo3').bootstrapDualListbox({
        nonSelectedListLabel: 'انتخاب نشده',
        selectedListLabel: 'انتخاب شده',
        preserveSelectionOnMove: 'moved',
        moveOnSelect: false,
        nonSelectedFilter: 'گزینه ([7-9]|[1][0-2])'
    });

    $("#demo3-add").click(function () {
        demo3.append('<option value="apples">سیب</option><option value="oranges" selected>پرتقال</option>');
        demo3.bootstrapDualListbox('refresh');
    });

    $("#demo3-add-clear").click(function () {
        demo3.append('<option value="apples">سیب</option><option value="oranges" selected>پرتقال</option>');
        demo3.bootstrapDualListbox('refresh', true);
    });








})(jQuery);