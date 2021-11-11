(function ($) {
    "use strict"

    Morris.Bar({
        element: 'timeline-chart',
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
        ykeys: ['a', 'b', "c"],
        labels: ['الف', 'ب', "ج"],
        barColors: ['#D57FF8', "#FF9800", '#FFC107'],
        hideHover: 'auto',
        gridLineColor: '#F5F5F5',
        resize: true,
        barSizeRatio: 0.4
    });


    $('#download-chart').circleProgress({
        startAngle: -Math.PI / 4 * 2,
        value: 0.5,
        size: 195,
        fill: {
            color: '#00A2FF'
        },
        reverse: false,
        thickness: 30
    });


    $('#upload-chart').circleProgress({
        startAngle: -Math.PI / 4 * 2,
        value: 0.7,
        size: 195,
        fill: {
            color: '#00A2FF'
        },
        reverse: false,
        thickness: 30
    });

    var ctx = document.getElementById("storage-used-chart");
    // ctx.height = 200;
    new Chart(ctx, {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [45, 25],
                backgroundColor: [
                    "#FFC107",
                    "#E36CD9"
                ],
                hoverBackgroundColor: [
                    "rgba(255, 193, 7, .6)",
                    "rgba(227, 108, 217, 0.6)"
                ]

            }],
            labels: [
                "استفاده شده",
                "در دسترس"
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            legend: {
                display: false
            }
        }
    });


    var ctx = document.getElementById("total-income");
    // ctx.height = 110;
    new Chart(ctx, {
        type: 'line',
        data: {
            labels: ["01 تیر", "02 تیر", "03 تیر", "04 تیر", "05 تیر", "06 تیر", "07 تیر"],
            datasets: [{
                data: [50, 31, 49, 75, 84, 90, 43],
                borderWidth: 3,
                borderColor: "#51CCA9",
                pointBackgroundColor: "#fff",
                pointBorderColor: "#D07BED",
                pointHoverBackgroundColor: "#FFF",
                pointHoverBorderColor: "#D07BED",
                pointRadius: 0,
                pointHoverRadius: 6,
                fill: !1
            }, {
                data: [45, 35, 39, 58, 90, 76, 80],
                borderWidth: 3,
                borderColor: "#D07BED",
                pointBackgroundColor: "#fff",
                pointBorderColor: "#D07BED",
                pointHoverBackgroundColor: "#FFF",
                pointHoverBorderColor: "#D07BED",
                pointRadius: 0,
                pointHoverRadius: 6,
                fill: !1
            }]
        },
        options: {
            responsive: !0,
            maintainAspectRatio: false,
            legend: {
                display: false
            },
            scales: {
                xAxes: [{
                    display: true,
                    gridLines: {
                        display: false,
                        drawBorder: false
                    }
                }],
                yAxes: [{
                    display: true,
                    ticks: {
                        padding: 10,
                        stepSize: 25,
                        max: 100,
                        min: 0
                    },
                    gridLines: {
                        display: true,
                        draw1Border: !1,
                        lineWidth: 0.5,
                        zeroLineColor: "transparent",
                        drawBorder: false
                    }
                }]
            }
        }
    });



})(jQuery);