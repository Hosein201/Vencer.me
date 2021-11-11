// Dashboard 1 Morris-chart
$(function () {
    "use strict";

    // LINE CHART
    let line = new Morris.Line({
        element: 'morris-line-chart',
        resize: true,
        data: [{
                y: '1397 Q1',
                item1: 2666
            },
            {
                y: '1397 Q2',
                item1: 2778
            },
            {
                y: '1397 Q3',
                item1: 4912
            },
            {
                y: '1397 Q4',
                item1: 3767
            },
            {
                y: '1398 Q1',
                item1: 6810
            },
            {
                y: '1398 Q2',
                item1: 5670
            },
            {
                y: '1398 Q3',
                item1: 4820
            },
            {
                y: '1398 Q4',
                item1: 15073
            },
            {
                y: '1399 Q1',
                item1: 10687
            },
            {
                y: '1399 Q2',
                item1: 8432
            }
        ],
        xkey: 'y',
        ykeys: ['item1'],
        labels: ['آیتم 1'],
        gridLineColor: 'transparent',
        lineColors: ['#0000FF'], //hrere
        lineWidth: 1,
        hideHover: 'auto',
        pointSize: 0,
        axes: false
    });
    // Morris donut chart 


    Morris.Donut({
        element: 'morris-donut-chart',
        data: [{
            label: "فروش دانلودی",
            value: 12,

        }, {
            label: "فروش در فروشگاه",
            value: 30
        }, {
            label: "فروش سفارشی",
            value: 20
        }],
        resize: true,
        colors: ['#00A2FF', '#34C73B', '#F44336']
    });

    // Extra chart
    Morris.Area({
        element: 'extra-area-chart',
        data: [{
                period: '1393',
                smartphone: 0,
                windows: 0,
                mac: 0
            }, {
                period: '1394',
                smartphone: 90,
                windows: 60,
                mac: 25
            }, {
                period: '1395',
                smartphone: 40,
                windows: 80,
                mac: 35
            }, {
                period: '1396',
                smartphone: 30,
                windows: 47,
                mac: 17
            }, {
                period: '1397',
                smartphone: 150,
                windows: 40,
                mac: 120
            }, {
                period: '1398',
                smartphone: 25,
                windows: 80,
                mac: 40
            }, {
                period: '1399',
                smartphone: 10,
                windows: 10,
                mac: 10
            }


        ],
        lineColors: ['#34C73B', '#F44336', '#00A2FF'],
        xkey: 'period',
        ykeys: ['smartphone', 'windows', 'mac'],
        labels: ['تلفن هوشمند', 'ویندوز', 'مک بوک'],
        pointSize: 0,
        lineWidth: 0,
        resize: true,
        fillOpacity: 0.8,
        behaveLikeLine: true,
        gridLineColor: 'transparent',
        hideHover: 'auto'

    });



    Morris.Area({
        element: 'morris-area-chart',
        data: [{
                period: '1393',
                smartphone: 0,
                windows: 0,
                mac: 0
            }, {
                period: '1394',
                smartphone: 90,
                windows: 60,
                mac: 25
            }, {
                period: '1395',
                smartphone: 40,
                windows: 80,
                mac: 35
            }, {
                period: '1396',
                smartphone: 30,
                windows: 47,
                mac: 17
            }, {
                period: '1397',
                smartphone: 150,
                windows: 40,
                mac: 120
            }, {
                period: '1398',
                smartphone: 25,
                windows: 80,
                mac: 40
            }, {
                period: '1399',
                smartphone: 10,
                windows: 10,
                mac: 10
            }


        ],
        xkey: 'period',
        ykeys: ['smartphone', 'windows', 'mac'],
        labels: ['تلفن هوشمند', 'ویندوز', 'مک بوک'],
        pointSize: 3,
        fillOpacity: 0,
        pointStrokeColors: ['#DCDCDC', '#34C73B', '#0000FF'],
        behaveLikeLine: true,
        gridLineColor: 'transparent',
        lineWidth: 3,
        hideHover: 'auto',
        lineColors: ['#DCDCDC', '#34C73B', '#0000FF'],
        resize: true

    });





    Morris.Area({
        element: 'morris-area-chart0',
        data: [{
                period: '1393',
                SiteA: 0,
                SiteB: 0,

            }, {
                period: '1394',
                SiteA: 130,
                SiteB: 100,

            }, {
                period: '1395',
                SiteA: 80,
                SiteB: 60,

            }, {
                period: '1396',
                SiteA: 70,
                SiteB: 200,

            }, {
                period: '1397',
                SiteA: 180,
                SiteB: 150,

            }, {
                period: '1398',
                SiteA: 105,
                SiteB: 90,

            },
            {
                period: '1399',
                SiteA: 250,
                SiteB: 150,

            }
        ],
        xkey: 'period',
        ykeys: ['SiteA', 'SiteB'],
        labels: ['سری یک', 'سری دو'],
        pointSize: 0,
        fillOpacity: 0.4,
        pointStrokeColors: ['#b4becb', '#00A2FF'], //here
        behaveLikeLine: true,
        gridLineColor: 'transparent',
        lineWidth: 0,
        smooth: false,
        hideHover: 'auto',
        lineColors: ['#b4becb', '#00A2FF'],
        resize: true

    });

    // Morris bar chart
    Morris.Bar({
        element: 'morris-bar-chart',
        data: [{
            y: '1393',
            a: 100,
            b: 90,
            c: 60
        }, {
            y: '1394',
            a: 75,
            b: 65,
            c: 40
        }, {
            y: '1395',
            a: 50,
            b: 40,
            c: 30
        }, {
            y: '1396',
            a: 75,
            b: 65,
            c: 40
        }, {
            y: '1397',
            a: 50,
            b: 40,
            c: 30
        }, {
            y: '1398',
            a: 75,
            b: 65,
            c: 40
        }, {
            y: '1399',
            a: 100,
            b: 90,
            c: 40
        }],
        xkey: 'y',
        ykeys: ['a', 'b', 'c'],
        labels: ['الف', 'ب', 'ج'],
        barColors: ['#0000FF', '#34C73B', '#DCDCDC'],
        hideHover: 'auto',
        gridLineColor: 'transparent',
        resize: true,
        barSizeRatio: 0.25,
    });

});