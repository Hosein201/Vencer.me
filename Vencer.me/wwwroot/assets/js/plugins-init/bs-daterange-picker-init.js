(function ($) {
    "use strict"

    // Daterange picker
    $('.input-daterange-datepicker').daterangepicker({
        buttonClasses: ['btn', 'btn-sm'],
        applyClass: 'btn-danger',
        cancelClass: 'btn-inverse'
    });
    $('.input-daterange-timepicker').daterangepicker({
        timePicker: true,
        format: 'MM/DD/YYYY h:mm A',
        timePickerIncrement: 30,
        timePicker12Hour: true,
        timePickerSeconds: false,
        buttonClasses: ['btn', 'btn-sm'],
        applyClass: 'btn-danger',
        cancelClass: 'btn-inverse'
    });
    $('.input-limit-datepicker').daterangepicker({
        format: 'MM/DD/YYYY',
        minDate: '06/01/2020',
        maxDate: '06/30/2020',
        buttonClasses: ['btn', 'btn-sm'],
        applyClass: 'btn-danger',
        cancelClass: 'btn-inverse',
        dateLimit: {
            days: 6
        }
    });
    $('.tarikh').persianDatepicker({
        altFormat: "X",
        format: "D MMMM YYYY",
        observer: true
    });
    $('.tarikh-time').persianDatepicker({
        altFormat: "X",
        format: "D MMMM YYYY HH:mm a",
        observer: true,
        timePicker: {
            enabled: true
        }
    });
    $("#tarikh").persianDatepicker({
        altField: "#tarikhAlt",
        altFormat: "X",
        format: "D MMMM YYYY HH:mm a",
        observer: true,
        timePicker: {
            enabled: true
        }
    });
    $('.tarikh-in').persianDatepicker({
        altFormat: "X",
        format: "D MMMM YYYY",
        observer: true
    });
    $('.tarikh-out').persianDatepicker({
        altFormat: "X",
        format: "D MMMM YYYY",
        observer: true
    });
})(jQuery);