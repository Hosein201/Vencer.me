// Dashboard 1 Morris-chart
$(function () {
    "use strict";

    // LINE CHART
    let btc = new Morris.Line({
        element: 'crypto-btc-card',
        resize: true,
        data: [{
                y: '1390',
                item1: 4912
            },
            {
                y: '1391',
                item1: 3767
            },
            {
                y: '1392',
                item1: 6810
            },
            {
                y: '1393',
                item1: 5670
            },
            {
                y: '1394',
                item1: 4820
            },
            {
                y: '1395',
                item1: 15073
            },
            {
                y: '1396',
                item1: 10687
            },
            {
                y: '1397',
                item1: 8432
            }, {
                y: '1398',
                item1: 2666
            },
            {
                y: '1399',
                item1: 15778
            },
        ],
        xkey: 'y',
        ykeys: ['item1'],
        labels: ['بیت کویین'],
        gridLineColor: 'transparent',
        lineColors: ['#fff'],
        lineWidth: 3,
        hideHover: 'auto',
        pointSize: 0,
        axes: false
    });

    // LINE CHART
    let eth = new Morris.Line({
        element: 'crypto-eth-card',
        resize: true,
        data: [{
                y: '1390',
                item1: 4912
            },
            {
                y: '1391',
                item1: 3767
            },
            {
                y: '1392',
                item1: 6810
            },
            {
                y: '1393',
                item1: 5670
            },
            {
                y: '1394',
                item1: 4820
            },
            {
                y: '1395',
                item1: 15073
            },
            {
                y: '1396',
                item1: 10687
            },
            {
                y: '1397',
                item1: 8432
            }, {
                y: '1398',
                item1: 2666
            },
            {
                y: '1399',
                item1: 15778
            },
        ],
        xkey: 'y',
        ykeys: ['item1'],
        labels: ['اتریوم'],
        gridLineColor: 'transparent',
        lineColors: ['#fff'],
        lineWidth: 3,
        hideHover: 'auto',
        pointSize: 0,
        axes: false
    });

    // LINE CHART
    let rpl = new Morris.Line({
        element: 'crypto-rpl-card',
        resize: true,
        data: [{
                y: '1390',
                item1: 4912
            },
            {
                y: '1391',
                item1: 3767
            },
            {
                y: '1392',
                item1: 6810
            },
            {
                y: '1393',
                item1: 5670
            },
            {
                y: '1394',
                item1: 4820
            },
            {
                y: '1395',
                item1: 15073
            },
            {
                y: '1396',
                item1: 10687
            },
            {
                y: '1397',
                item1: 8432
            }, {
                y: '1398',
                item1: 2666
            },
            {
                y: '1399',
                item1: 15778
            },
        ],
        xkey: 'y',
        ykeys: ['item1'],
        labels: ['ریپل'],
        gridLineColor: 'transparent',
        lineColors: ['#fff'],
        lineWidth: 3,
        hideHover: 'auto',
        pointSize: 0,
        axes: false
    });
    // LINE CHART
    let ltc = new Morris.Line({
        element: 'crypto-ltc-card',
        resize: true,
        data: [{
                y: '1390',
                item1: 4912
            },
            {
                y: '1391',
                item1: 3767
            },
            {
                y: '1392',
                item1: 6810
            },
            {
                y: '1393',
                item1: 5670
            },
            {
                y: '1394',
                item1: 4820
            },
            {
                y: '1395',
                item1: 15073
            },
            {
                y: '1396',
                item1: 10687
            },
            {
                y: '1397',
                item1: 8432
            }, {
                y: '1398',
                item1: 2666
            },
            {
                y: '1399',
                item1: 15778
            },
        ],
        xkey: 'y',
        ykeys: ['item1'],
        labels: ['لیتکویین'],
        gridLineColor: 'transparent',
        lineColors: ['#fff'],
        lineWidth: 3,
        hideHover: 'auto',
        pointSize: 0,
        axes: false
    });


    ///////////////////////
    // BTC Am Chart
    ///////////////////////

    var chartData = generateChartData();

    function generateChartData() {
        var chartData = [];
        var firstDate = new Date(1402, 0, 17);
        firstDate.setDate(firstDate.getDate() - 1000);
        firstDate.setHours(0, 0, 0, 0);

        var a = 2000;

        for (var i = 0; i < 1000; i++) {
            var newDate = new Date(firstDate);
            newDate.setHours(0, i, 0, 0);

            a += Math.round((Math.random() < 0.5 ? 1 : -1) * Math.random() * 10);
            var b = Math.round(Math.random() * 100000000);

            chartData.push({
                "date": newDate,
                "value": a,
                "volume": b
            });
        }
        return chartData;
    }

    var chart = AmCharts.makeChart("btc1", {
        "type": "stock",
        "theme": "light",
        "categoryAxesSettings": {
            "minPeriod": "mm",
        },



        "dataSets": [{
            "color": "#7f63f4",
            "fieldMappings": [{
                "fromField": "value",
                "toField": "value"
            }, {
                "fromField": "volume",
                "toField": "volume"
            }],

            "dataProvider": chartData,
            "categoryField": "date"
        }],

        "panels": [{
            "showCategoryAxis": false,
            "title": "Value",
            "percentHeight": 50,

            "stockGraphs": [{
                "id": "g1",
                "valueField": "value",
                "type": "smoothedLine",
                "lineThickness": 2,
                "bullet": ""
            }],


            "stockLegend": {
                "valueTextRegular": " ",
                "markerType": "none"
            }
        }, {
            "title": "Volume",
            "percentHeight": 30,
            "stockGraphs": [{
                "valueField": "volume",
                "type": "column",
                "cornerRadiusTop": 2,
                "fillAlphas": 1
            }],

            "stockLegend": {
                "valueTextRegular": " ",
                "markerType": "none"
            }
        }],

        "chartScrollbarSettings": {
            "graph": "g1",
            "usePeriod": "10mm",
            "position": "bottom",
            "oppositeAxis": true,
            "offset": 50,
            // "scrollbarHeight": 100,
            "background": "#7f63f4",
            "backgroundAlpha": 0.5,
            "selectedBackgroundAlpha": 0.5,
            "selectedBackgroundColor": "#fff",
            "graphFillAlpha": 1,
            "graphLineAlpha": 0.5,
            "selectedGraphFillColor": "#7f63f4",
            "selectedGraphFillAlpha": 1,
            "selectedGraphLineAlpha": 1,
            "autoGridCount": true,
            "color": "#fff"
        },

        "chartCursorSettings": {
            "valueBalloonsEnabled": true
        },

        "periodSelector": {
            "position": "top",
            "dateFormat": "JJ:NN , YYYY-MM-DD",
            "inputFieldWidth": 250,
            "periods": [{
                "period": "hh",
                "count": 1,
                "label": "1 ساعت گذشته"
            }, {
                "period": "hh",
                "count": 2,
                "label": "2 ساعت گذشته"
            }, {
                "period": "hh",
                "count": 5,
                "selected": true,
                "label": "5 ساعت گذشته"
            }, {
                "period": "hh",
                "count": 12,
                "label": "12 ساعت گذشته"
            }, {
                "period": "MAX",
                "label": "همه"
            }]
        },

        "panelsSettings": {
            "usePrefixes": true
        },

        "export": {
            "enabled": false,
            "position": "bottom-right"
        }
    });


});