$(function () {
    Highcharts.chart('basic-line', {
        chart: {
            backgroundColor: 'transparent',
        },
        title: {
            text: 'متوسط درجه حرارت ماهانه',
            x: -20 //center
        },
        subtitle: {
            text: 'WorldClimate.com : منبع',
            x: -20
        },
        xAxis: {

            categories: ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور',
                'مهر', 'آبان', 'آذر', 'دی', 'بهمن', 'اسفند'
            ]
        },
        yAxis: {
            gridLineColor: 'transparent',
            title: {
                text: 'درجه حرارت (°C)'
            },
            plotLines: [{
                value: 0,
                width: 1,
                color: '#808080'
            }]
        },
        tooltip: {
            valueSuffix: '°C'
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle',
            borderWidth: 0,
        },
        series: [{
            name: 'Tehran',
            data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6],
            color: '#00A2FF'
        }, {
            name: 'Shiraz',
            data: [-0.2, 0.8, 5.7, 11.3, 17.0, 22.0, 24.8, 24.1, 20.1, 14.1, 8.6, 2.5],
            color: '#0000FF'
        }, {
            name: 'Tabriz',
            data: [-0.9, 0.6, 3.5, 8.4, 13.5, 17.0, 18.6, 17.9, 14.3, 9.0, 3.9, 1.0],
            color: '#F44336'
        }, {
            name: 'Esfahan',
            data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8],
            color: '#34C73B'
        }]
    });
});

// area inverted

$(function () {
    Highcharts.chart('area-inverted', {
        chart: {
            type: 'area',
            backgroundColor: 'transparent',
            inverted: true
        },
        title: {
            text: 'متوسط مصرف میوه در یک هفته'
        },
        subtitle: {
            style: {
                position: 'absolute',
                right: '0px',
                bottom: '10px'
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -150,
            y: 100,
            floating: true,
            borderWidth: 1,
            backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'
        },
        xAxis: {
            categories: [
                'شنبه',
                'یکشنبه',
                'دوشنبه',
                'سه شنبه',
                'چهارشنبه',
                'پنج شنبه',
                'جمعه'
            ]
        },
        yAxis: {
            title: {
                text: 'تعداد'
            },
            labels: {
                formatter: function () {
                    return this.value;
                }
            },
            min: 0
        },
        plotOptions: {
            area: {
                fillOpacity: 0.5
            }
        },
        series: [{
            name: 'Reza',
            data: [3, 4, 3, 5, 4, 10, 12],
            color: '#34C73B'
        }, {
            name: 'Sara',
            data: [1, 3, 4, 3, 3, 5, 4],
            color: '#00A2FF'
        }]
    });
});

// bubble chart

$(function () {
    Highcharts.chart('bubble-chart', {

        chart: {
            type: 'bubble',
            plotBorderWidth: 1,
            zoomType: 'xy',
            backgroundColor: 'transparent',
        },

        legend: {
            enabled: false
        },

        title: {
            text: 'مصرف چربی و شکر در هر کشور'
        },

        subtitle: {
            text: '<a href="http://www.euromonitor.com/">Euromonitor</a> و <a href="https://data.oecd.org/">OECD</a> : منبع'
        },

        xAxis: {
            gridLineWidth: 1,
            title: {
                text: 'مصرف چربی روزانه'
            },
            labels: {
                format: 'گرم {value}'
            },
            plotLines: [{
                color: 'black',
                dashStyle: 'dot',
                width: 2,
                value: 65,
                label: {
                    rotation: 0,
                    y: 15,
                    style: {
                        fontStyle: 'italic'
                    },
                    text: 'مصرف ایمن چربی 65گرم/روز'
                },
                zIndex: 3
            }]
        },

        yAxis: {
            startOnTick: false,
            endOnTick: false,
            title: {
                text: 'مصرف روزانه شکر'
            },
            labels: {
                format: 'گرم {value}'
            },
            maxPadding: 0.2,
            plotLines: [{
                color: 'black',
                dashStyle: 'dot',
                width: 2,
                value: 50,
                label: {
                    align: 'right',
                    style: {
                        fontStyle: 'italic'
                    },
                    text: 'مصرف ایمن شکر 50گرم/روز',
                    x: -10
                },
                zIndex: 3
            }]
        },

        tooltip: {
            useHTML: true,
            headerFormat: '<table>',
            pointFormat: '<tr><th colspan="2"><h3>{point.country}</h3></th></tr>' +
                '<tr><th>مصرف چربی:</th><td>{point.x}گرم</td></tr>' +
                '<tr><th>مصرف چربی:</th><td>{point.y}گرم</td></tr>' +
                '<tr><th>چاقی(بزرگسالان):</th><td>{point.z}%</td></tr>',
            footerFormat: '</table>',
            followPointer: true
        },

        plotOptions: {
            series: {
                dataLabels: {
                    enabled: true,
                    format: '{point.name}'
                }
            }
        },

        series: [{
            data: [{
                    x: 95,
                    y: 95,
                    z: 13.8,
                    name: 'IR',
                    country: 'ایران',
                    color: '#00A2FF'
                },
                {
                    x: 86.5,
                    y: 102.9,
                    z: 14.7,
                    name: 'DE',
                    country: 'آلمان',
                    color: '#00A2FF'
                },
                {
                    x: 80.8,
                    y: 91.5,
                    z: 15.8,
                    name: 'FI',
                    country: 'فنلاند',
                    color: '#00A2FF'
                },
                {
                    x: 80.4,
                    y: 102.5,
                    z: 12,
                    name: 'NL',
                    country: 'هلند',
                    color: '#00A2FF'
                },
                {
                    x: 80.3,
                    y: 86.1,
                    z: 11.8,
                    name: 'SE',
                    country: 'سوئد',
                    color: '#00A2FF'
                },
                {
                    x: 78.4,
                    y: 70.1,
                    z: 16.6,
                    name: 'ES',
                    country: 'اسپانیا',
                    color: '#00A2FF'
                },
                {
                    x: 74.2,
                    y: 68.5,
                    z: 14.5,
                    name: 'FR',
                    country: 'فرانسه',
                    color: '#00A2FF'
                },
                {
                    x: 73.5,
                    y: 83.1,
                    z: 10,
                    name: 'NO',
                    country: 'نروژ',
                    color: '#00A2FF'
                },
                {
                    x: 71,
                    y: 93.2,
                    z: 24.7,
                    name: 'UK',
                    country: 'انگلستان',
                    color: '#00A2FF'
                },
                {
                    x: 69.2,
                    y: 57.6,
                    z: 10.4,
                    name: 'IT',
                    country: 'ایتالیا',
                    color: '#00A2FF'
                },
                {
                    x: 68.6,
                    y: 20,
                    z: 16,
                    name: 'RU',
                    country: 'روسیه',
                    color: '#00A2FF'
                },
                {
                    x: 65.5,
                    y: 126.4,
                    z: 35.3,
                    name: 'US',
                    country: 'آمریکا',
                    color: '#00A2FF'
                },
                {
                    x: 65.4,
                    y: 50.8,
                    z: 28.5,
                    name: 'HU',
                    country: 'مجارستان',
                    color: '#00A2FF'
                },
                {
                    x: 63.4,
                    y: 51.8,
                    z: 15.4,
                    name: 'PT',
                    country: 'پرتغال',
                    color: '#00A2FF'
                },
                {
                    x: 64,
                    y: 82.9,
                    z: 31.3,
                    name: 'NZ',
                    country: 'نیوزلند',
                    color: '#00A2FF'
                },
            ]
        }]

    });
});

//polar chart

$(function () {

    Highcharts.chart('polar-chart', {

        chart: {
            polar: true,
            backgroundColor: 'transparent',
        },

        title: {
            text: 'نمودار قطبی Highchart'
        },

        pane: {
            startAngle: 0,
            endAngle: 360
        },

        xAxis: {
            tickInterval: 45,
            min: 0,
            max: 360,
            labels: {
                formatter: function () {
                    return this.value + '°';
                }
            }
        },

        yAxis: {
            min: 0
        },

        plotOptions: {
            series: {
                pointStart: 0,
                pointInterval: 45
            },
            column: {
                pointPadding: 0,
                groupPadding: 0
            }
        },

        series: [{
            type: 'column',
            name: 'ستون',
            data: [8, 7, 6, 5, 4, 3, 2, 1],
            pointPlacement: 'between',
            color: '#34C73B'
        }, {
            type: 'line',
            name: 'خط',
            data: [1, 2, 3, 4, 5, 6, 7, 8],
            color: '#0000FF'
        }, {
            type: 'area',
            name: 'محیط',
            data: [1, 8, 2, 7, 3, 6, 4, 5],
            color: '#00A2FF'
        }]
    });
});


// box plot

$(function () {
    Highcharts.chart('box-plot', {

        chart: {
            type: 'boxplot',
            backgroundColor: 'transparent',
        },

        title: {
            text: 'نمونه نمودار طرح جعبه'
        },

        legend: {
            enabled: false
        },

        xAxis: {
            categories: ['1', '2', '3', '4', '5'],
            title: {
                text: 'سطح تجربه'
            }
        },

        yAxis: {
            title: {
                text: 'مشاهدات'
            },
            plotLines: [{
                value: 932,
                color: '#0000FF',
                width: 1,
                label: {
                    text: 'متوسط نظرات : 932',
                    align: 'center',
                    style: {
                        color: 'gray'
                    }
                }
            }]
        },

        series: [{
            name: 'Moshahedat',
            data: [
                [760, 801, 848, 895, 965],
                [733, 853, 939, 980, 1080],
                [714, 762, 817, 870, 918],
                [724, 802, 806, 871, 950],
                [834, 836, 864, 882, 910]
            ],
            color: '#00A2FF',
            tooltip: {
                headerFormat: '<em>سطح تجربه {point.key}</em><br/>'
            }
        }, {
            name: 'Moshahedat',
            color: Highcharts.getOptions().colors[0],
            type: 'scatter',
            data: [ // x, y positions where 0 is the first category
                [0, 644],
                [4, 718],
                [4, 951],
                [4, 969]
            ],
            marker: {
                fillColor: 'white',
                lineWidth: 1,
                lineColor: Highcharts.getOptions().colors[0]
            },
            tooltip: {
                pointFormat: 'تعداد: {point.y}'
            }
        }]

    });
});