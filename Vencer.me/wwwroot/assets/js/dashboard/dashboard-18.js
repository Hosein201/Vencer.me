(function ($) {
    "use strict"

    Morris.Bar({
        element: 'count-avarage-students',
        data: [{
            y: '1393',
            a: 100,
            b: 90
        }, {
            y: '1394',
            a: 75,
            b: 65
        }, {
            y: '1395',
            a: 50,
            b: 40
        }, {
            y: '1396',
            a: 75,
            b: 65
        }, {
            y: '1397',
            a: 50,
            b: 40
        }, {
            y: '1398',
            a: 75,
            b: 65
        }, {
            y: '1399',
            a: 100,
            b: 90
        }],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['الف', 'ب'],
        barColors: ['#D57FF8', '#FFC107'],
        hideHover: 'auto',
        gridLineColor: '#F5F5F5',
        resize: true,
        barSizeRatio: 0.4
    });




})(jQuery);