(function ($) {
    "use strict"


    let draw = Chart.controllers.line.prototype.draw;
    Chart.controllers.line = Chart.controllers.line.extend({
        draw: function () {
            draw.apply(this, arguments);
            let ctx = this.chart.chart.ctx;
            let _stroke = ctx.stroke;
            ctx.stroke = function () {
                ctx.save();
                ctx.shadowColor = '#ccc';
                ctx.shadowBlur = 20;
                ctx.shadowOffsetX = 0;
                ctx.shadowOffsetY = 1;
                _stroke.apply(this, arguments)
                ctx.restore();
            }
        }
    });

    var ctx = document.getElementById("product-sales-chart");
    // ctx.height = 70;
    new Chart(ctx, {
        type: 'line',
        data: {
            labels: ["فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"],
            type: 'line',
            defaultFontFamily: 'iransans',
            datasets: [{
                label: "این ماه",
                data: [0, 10, 20, 10, 25, 15, 150, 46, 43, 65, 39, 61],
                backgroundColor: 'transparent',
                borderColor: '#71D875',
                borderWidth: 3,
                pointStyle: 'circle',
                pointRadius: 5,
                pointBorderColor: '#71D875',
                pointBackgroundColor: '#fff'

            }, {
                label: "ماه گذشته",
                data: [0, 30, 10, 60, 50, 63, 10, 100, 54, 120, 32, 74],
                backgroundColor: 'transparent',
                borderColor: "#D07BED",
                borderWidth: 3,
                pointStyle: 'circle',
                pointRadius: 5,
                pointBorderColor: '#D07BED',
                pointBackgroundColor: '#fff'
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            tooltips: {
                mode: 'index',
                titleFontSize: 12,
                titleFontColor: '#000',
                bodyFontColor: '#000',
                backgroundColor: '#fff',
                titleFontFamily: 'iransans',
                bodyFontFamily: 'iransans',
                cornerRadius: 3,
                intersect: false,
            },
            legend: {
                display: false,
                labels: {
                    usePointStyle: true,
                    fontFamily: 'iransans',
                },
            },
            scales: {
                xAxes: [{
                    display: true,
                    gridLines: {
                        display: false,
                        drawBorder: false
                    },
                    scaleLabel: {
                        display: false,
                        labelString: 'ماه'
                    }
                }],
                yAxes: [{
                    display: true,
                    gridLines: {
                        display: true,
                        drawBorder: false,
                        zeroLineColor: "transparent"
                    },
                    scaleLabel: {
                        display: false,
                        labelString: 'مقدار'
                    }
                }]
            },
            title: {
                display: false,
                text: 'نرمال'
            }
        }
    });

    //doughut chart
    var ctx = document.getElementById("most-selling-items-electronics");
    // ctx.height = 175;
    new Chart(ctx, {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [10, 20, 30, 50],
                backgroundColor: [
                    "rgba(255,193,7,0.9)",
                    "rgba(0,162,255,0.9)",
                    "rgba(123,179,26,0.9)",
                    "rgba(255,152,0,0.9)"
                ],
                hoverBackgroundColor: [
                    "rgba(255,193,7,0.5)",
                    "rgba(0,162,255,0.5)",
                    "rgba(123,179,26,0.5)",
                    "rgba(255,152,0,0.5)"
                ]

            }],
            labels: [
                "دوربین دیجیتال",
                "گوشی هوشمند",
                "لوازم صوتی",
                "لوازم جانبی"
            ]
        },
        options: {
            responsive: true,
            cutoutPercentage: 60,
            maintainAspectRatio: false,
            animation: {
                animateRotate: true,
                animateScale: true,
            },
            legend: {
                position: 'right',
                labels: {
                    usePointStyle: true,
                    fontFamily: "iransans",
                },


            },
        }
    });


    var i = new Datamap({
        scope: "world",
        element: document.getElementById("world-custommer-map"),
        responsive: !0,
        geographyConfig: {
            popupOnHover: !1,
            highlightOnHover: !1,
            borderColor: "transparent",
            borderWidth: 1,
            highlightBorderWidth: 3,
            highlightFillColor: "rgba(0,123,255,0.5)",
            highlightBorderColor: "transparent",
            borderWidth: 1
        },
        bubblesConfig: {
            popupTemplate: function (e, i) {
                return '<div class="datamap-sales-hover-tooltip">' + i.country + '<span class="m-l-5"></span>' + i.sold + "</div>"
            },
            borderWidth: 1,
            highlightBorderWidth: 3,
            highlightFillColor: "rgba(0,123,255,0.5)",
            highlightBorderColor: "transparent",
            fillOpacity: .75
        },
        fills: {
            Visited: "#00A2FF",
            neato: "#673AB7",
            white: "#FF9800",
            defaultFill: "#E7E8E9"
        }
    });

    i.bubbles([{
            centered: "USA",
            fillKey: "white",
            radius: 5,
            sold: "500",
            country: "آمریکا"
        }, {
            centered: "SAU",
            fillKey: "Visited",
            radius: 5,
            sold: "900",
            country: "عربستان"
        }, {
            centered: "RUS",
            fillKey: "neato",
            radius: 5,
            sold: "250",
            country: "روسیه"
        }, {
            centered: "CAN",
            fillKey: "white",
            radius: 5,
            sold: "1000",
            country: "کانادا"
        }, {
            centered: "IRN",
            fillKey: "Visited",
            radius: 5,
            sold: "50",
            country: "ایران"
        }, {
            centered: "AUS",
            fillKey: "white",
            radius: 5,
            sold: "700",
            country: "استرالیا"
        }, {
            centered: "BGD",
            fillKey: "Visited",
            radius: 5,
            sold: "1500",
            country: "بنگلادش"
        }]),
        window.addEventListener("resize", function (e) {
            i.resize()
        });






})(jQuery);