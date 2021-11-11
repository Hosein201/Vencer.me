$(function () {
    "use strict";

    // Morris bar chart
    Morris.Bar({
        element: 'morris-bar-chart',
        data: [{
            y: 'فروردین',
            a: 100,
            b: 90,
            c: 60
        }, {
            y: 'اردیبهشت',
            a: 75,
            b: 65,
            c: 40
        }, {
            y: 'خرداد',
            a: 50,
            b: 40,
            c: 30
        }, {
            y: 'تیر',
            a: 75,
            b: 65,
            c: 40
        }, {
            y: 'مرداد',
            a: 50,
            b: 40,
            c: 30
        }, {
            y: 'شهریور',
            a: 75,
            b: 65,
            c: 40
        }, {
            y: 'مهر',
            a: 100,
            b: 90,
            c: 40
        }, {
            y: 'آبان',
            a: 75,
            b: 65,
            c: 40
        }, {
            y: 'آذر',
            a: 50,
            b: 40,
            c: 30
        }, {
            y: 'دی',
            a: 75,
            b: 65,
            c: 40
        }, ],
        xkey: 'y',
        ykeys: ['a', 'b', 'c'],
        labels: ['الف', 'ب', 'ج'],
        barColors: ['#7bb31a', '#00a2ff', '#ff9800'],
        hideHover: 'auto',
        gridLineColor: 'transparent',
        resize: true,
        barSizeRatio: 0.5,
        barRadius: [5, 5, 0, 0],
    });


    Morris.Donut({
        element: 'morris-donut-chart',
        data: [{
            label: "کروم",
            value: 60,

        }, {
            label: "فایرفاکس",
            value: 30
        }, {
            label: "سافاری",
            value: 20
        }, {
            label: "دیگر",
            value: 40
        }],
        resize: true,
        colors: ['#ff9800', '#7bb31a', '#00a2ff', '#ffc107']
    });

});