(function ($) {
    "use strict"

    $('#p-users').circleProgress({
        startAngle: -Math.PI / 4 * 2,
        value: 0.85,
        size: 115,
        lineCap: 'round',
        fill: {
            color: '#43E794'
        },
        reverse: false,
        emptyFill: "#F3F6F9"
    });

    $('#a-users').circleProgress({
        startAngle: -Math.PI / 4 * 2,
        value: 0.75,
        size: 115,
        lineCap: 'round',
        fill: {
            color: '#FF5274'
        },
        reverse: false,
        emptyFill: "#F3F6F9"
    });

    $('#dm-users').circleProgress({
        startAngle: -Math.PI / 4 * 2,
        value: 0.5,
        size: 115,
        lineCap: 'round',
        fill: {
            color: '#1D8FF7'
        },
        reverse: false,
        emptyFill: "#F3F6F9"
    });

    $('#dl-users').circleProgress({
        startAngle: -Math.PI / 4 * 2,
        value: 0.3,
        size: 115,
        lineCap: 'round',
        fill: {
            color: '#FFA616'
        },
        reverse: false,
        emptyFill: "#F3F6F9"
    });

    Morris.Bar({
        element: 'job-applicants-chart',
        data: [{
            y: 'شنبه',
            a: 66,
            b: 34
        }, {
            y: 'یکشنبه',
            a: 75,
            b: 25
        }, {
            y: 'دوشنبه',
            a: 50,
            b: 50
        }, {
            y: 'سه شنبه',
            a: 75,
            b: 25
        }, {
            y: 'چهارشنبه',
            a: 50,
            b: 50
        }, {
            y: 'پنج شنبه',
            a: 16,
            b: 84
        }, {
            y: 'جمعه',
            a: 70,
            b: 30
        }, {
            y: 'شنبه',
            a: 30,
            b: 70
        }, {
            y: 'یکشنبه',
            a: 40,
            b: 60
        }, {
            y: 'دوشنبه',
            a: 29,
            b: 71
        }, {
            y: 'سه شنبه',
            a: 44,
            b: 56
        }, {
            y: 'چهارشنبه',
            a: 30,
            b: 70
        }, {
            y: 'پنج شنبه',
            a: 60,
            b: 40
        }, {
            y: 'جمعه',
            a: 40,
            b: 60
        }, {
            y: 'شنبه',
            a: 46,
            b: 54
        }],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['الف', 'ب'],
        barColors: ['#7F63F4', "#F1F3F7"],
        hideHover: 'auto',
        gridLineColor: 'transparent',
        resize: true,
        barSizeRatio: 0.25,
        stacked: true,
        behaveLikeLine: true,
        barRadius: [6, 6, 0, 0]
    });



})(jQuery);