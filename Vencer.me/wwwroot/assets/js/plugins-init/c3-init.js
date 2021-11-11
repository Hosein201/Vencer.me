$(document).ready(function () {

    $(function () {
        var chart = c3.generate({
            bindto: '#c3-chart',
            data: {
                columns: [
                    ['داده دوم', 100, 200, 150, 300, 200],
                    ['داده اول', 400, 500, 250, 700, 300],
                ],
                colors: {
                    'داده دوم': '#34C73B',
                    'داده اول': '#00A2FF'
                    //data3: '#0000ff'
                },
                axes: {
                    data2: 'y2' // ADD
                }
            },
            axis: {
                y2: {
                    show: true // ADD
                }
            }
        });

    });

    $(function () {
        var chart = c3.generate({
            bindto: '#c3-combination',
            data: {
                columns: [
                    ['داده سوم', 30, 20, 50, 40, 60, 50],
                    ['داده دوم', 200, 130, 90, 240, 130, 220],
                    ['داده اول', 300, 200, 160, 400, 250, 250]
                ],
                type: 'bar',
                colors: {
                    'داده سوم': '#34C73B',
                    'داده دوم': '#00A2FF',
                    'داده اول': '#0000FF'
                },
                types: {
                    'داده اول': 'spline',
                    data4: 'line',
                    data6: 'area'
                },
                groups: [
                    ['داده سوم', 'داده دوم']
                ]
            }
        });
    });

    $(function () {
        var chart = c3.generate({
            bindto: '#c3-area',
            data: {
                columns: [
                    ['داده دوم', 300, 350, 300, 0, 0, 0],
                    ['داده اول', 130, 100, 140, 200, 150, 50]
                ],
                colors: {
                    'داده دوم': '#34C73B',
                    'داده اول': '#00A2FF'
                },
                types: {
                    'داده دوم': 'area',
                    'داده اول': 'area-spline'
                }
            }
        });
    });

    $(function () {
        var chart = c3.generate({
            bindto: '#c3-rotated_axis',
            data: {
                columns: [
                    ['داده دوم', 30, 200, 100, 400, 150, 250],
                    ['داده اول', 50, 20, 10, 40, 15, 25]
                ],
                colors: {
                    'داده دوم': '#34C73B',
                    'داده اول': '#0000FF',
                },
                types: {
                    'داده دوم': 'bar'
                }
            },
            axis: {
                rotated: true
            }
        });
    });


    $(function () {
        var chart = c3.generate({
            bindto: '#c3-spline',
            data: {
                columns: [
                    ['داده دوم', 30, 200, 100, 400, 150, 250],
                    ['داده اول', 130, 100, 140, 200, 150, 50]
                ],
                colors: {
                    'داده دوم': '#00A2FF',
                    'داده اول': '#0000FF'
                },
                type: 'spline'
            }
        });
    });


    $(function () {
        var chart = c3.generate({
            bindto: '#c3-simple-xy-line',
            data: {
                x: 'x',
                columns: [
                    ['x', 30, 50, 100, 230, 300, 310],
                    ['داده دوم', 30, 200, 100, 400, 150, 250],
                    ['داده اول', 130, 300, 200, 300, 250, 450]
                ],
                colors: {
                    'داده سوم': '#00A2FF',
                    'داده دوم': '#0000FF',
                    'داده اول': '#F44336'
                }
            }

        });
        setTimeout(function () {
            chart.load({
                columns: [
                    ['داده دوم', 100, 250, 150, 200, 100, 350]
                ]
            });
        }, 1000);

        setTimeout(function () {
            chart.load({
                columns: [
                    ['داده اول', 80, 150, 100, 180, 80, 150]
                ]
            });
        }, 1500);

        setTimeout(function () {
            chart.unload({
                ids: 'data2'
            });
        }, 2000);
    });

    $(function () {
        var chart = c3.generate({
            bindto: '#c3-line-with-region',
            data: {
                columns: [
                    ['داده دوم', 30, 200, 100, 400, 150, 250],
                    ['داده اول', 50, 20, 10, 40, 15, 25]
                ],
                colors: {
                    'داده دوم': '#00A2FF',
                    'داده اول': '#0000FF'
                },
                regions: {
                    'داده دوم': [{
                        'start': 1,
                        'end': 2,
                        'style': 'dashed'
                    }, {
                        'start': 3
                    }], // currently 'dashed' style only
                    'داده اول': [{
                        'end': 3
                    }]
                }
            }
        });
    });

    $(function () {
        var chart = c3.generate({
            bindto: '#c3-step-chart',
            data: {
                columns: [
                    ['داده دوم', 300, 350, 300, 0, 0, 100],
                    ['داده ول', 130, 100, 140, 200, 150, 50]
                ],
                colors: {
                    'داده دوم': '#0000FF',
                    'داده ول': '#00A2FF'
                },
                types: {
                    'داده دوم': 'step',
                    'داده ول': 'area-step'
                }
            }
        });
    });

    $(function () {
        var chart = c3.generate({
            bindto: '#c3-stacked-area-chart',
            data: {
                columns: [
                    ['داده دوم', 300, 350, 300, 0, 0, 120],
                    ['داده اول', 130, 100, 140, 200, 150, 50]
                ],
                types: {
                    'داده دوم': 'area-spline',
                    'داده اول': 'area-spline'
                    // 'line', 'spline', 'step', 'area', 'area-step' are also available to stack
                },
                colors: {
                    'داده دوم': '#00A2FF',
                    'داده اول': '#0000FF'
                },
                groups: [
                    ['داده دوم', 'داده اول']
                ]
            }
        });
    });

    $(function () {
        var chart = c3.generate({
            bindto: '#c3-bar-chart',
            data: {
                columns: [
                    ['داده سوم', 30, 200, 100, 400, 150, 250],
                    ['داده دوم', 130, 100, 140, 200, 150, 50]
                ],
                colors: {
                    'داده سوم': '#34C73B',
                    'داده دوم': '#00A2FF',
                    'داده اول': '#0000FF'
                },
                type: 'bar'
            },
            bar: {
                width: {
                    ratio: 0.5 // this makes bar width 50% of length between ticks
                }
                // or
                //width: 100 // this makes bar width 100px
            }
        });
        setTimeout(function () {
            chart.load({
                columns: [
                    ['داده اول', 130, -150, 200, 300, -200, 100]
                ]
            });
        }, 1000);
    });


    $(function () {
        var chart = c3.generate({
            bindto: '#c3-stacked-bar-chart',
            data: {
                columns: [
                    ['داده چهارم', -30, 200, 200, 400, -150, 250],
                    ['داده سوم', 130, 100, -100, 200, -150, 50],
                    ['داده دوم', -230, 200, 200, -300, 250, 250]
                ],
                colors: {
                    'داده چهارم': '#34C73B',
                    'داده سوم': '#00A2FF',
                    'داده دوم': '#0000FF',
                    'داده اول': '#F44336'
                },
                type: 'bar',
                groups: [
                    ['داده چهارم', 'داده سوم']
                ]
            },
            grid: {
                y: {
                    lines: [{
                        value: 0
                    }]
                }
            }
        });
        setTimeout(function () {
            chart.groups([
                ['داده چهارم', 'داده سوم', 'داده دوم']
            ])
        }, 1000);

        setTimeout(function () {
            chart.load({
                columns: [
                    ['داده اول', 100, -50, 150, 200, -300, -100]
                ]
            });
        }, 1500);

        setTimeout(function () {
            chart.groups([
                ['داده چهارم', 'داده سوم', 'داده دوم', 'داده اول']
            ])
        }, 2000);
    });




    $(function () {
        var chart = c3.generate({
            bindto: '#c3-scatter-plot',
            data: {
                xs: {
                    setosa: 'setosa_x',
                    'داده دوم': 'versicolor_x'
                },
                // iris data from R
                columns: [
                    ["setosa_x", 3.5, 3.0, 3.2, 3.1, 3.6, 3.9, 3.4, 3.4, 2.9, 3.1, 3.7, 3.4, 3.0, 3.0, 4.0, 4.4, 3.9, 3.5, 3.8, 3.8, 3.4, 3.7, 3.6, 3.3, 3.4, 3.0, 3.4, 3.5, 3.4, 3.2, 3.1, 3.4, 4.1, 4.2, 3.1, 3.2, 3.5, 3.6, 3.0, 3.4, 3.5, 2.3, 3.2, 3.5, 3.8, 3.0, 3.8, 3.2, 3.7, 3.3],
                    ["versicolor_x", 3.2, 3.2, 3.1, 2.3, 2.8, 2.8, 3.3, 2.4, 2.9, 2.7, 2.0, 3.0, 2.2, 2.9, 2.9, 3.1, 3.0, 2.7, 2.2, 2.5, 3.2, 2.8, 2.5, 2.8, 2.9, 3.0, 2.8, 3.0, 2.9, 2.6, 2.4, 2.4, 2.7, 2.7, 3.0, 3.4, 3.1, 2.3, 3.0, 2.5, 2.6, 3.0, 2.6, 2.3, 2.7, 3.0, 2.9, 2.9, 2.5, 2.8],
                    ["setosa", 0.2, 0.2, 0.2, 0.2, 0.2, 0.4, 0.3, 0.2, 0.2, 0.1, 0.2, 0.2, 0.1, 0.1, 0.2, 0.4, 0.4, 0.3, 0.3, 0.3, 0.2, 0.4, 0.2, 0.5, 0.2, 0.2, 0.4, 0.2, 0.2, 0.2, 0.2, 0.4, 0.1, 0.2, 0.2, 0.2, 0.2, 0.1, 0.2, 0.2, 0.3, 0.3, 0.2, 0.6, 0.4, 0.3, 0.2, 0.2, 0.2, 0.2],
                    ["داده دوم", 1.4, 1.5, 1.5, 1.3, 1.5, 1.3, 1.6, 1.0, 1.3, 1.4, 1.0, 1.5, 1.0, 1.4, 1.3, 1.4, 1.5, 1.0, 1.5, 1.1, 1.8, 1.3, 1.5, 1.2, 1.3, 1.4, 1.4, 1.7, 1.5, 1.0, 1.1, 1.0, 1.2, 1.6, 1.5, 1.6, 1.5, 1.3, 1.3, 1.3, 1.2, 1.4, 1.2, 1.0, 1.3, 1.2, 1.3, 1.3, 1.1, 1.3],
                ],
                colors: {
                    setosa: '#F44336',
                    'داده دوم': '#34C73B',
                    versicolor_x: '#00A2FF',
                    setosa_x: '#0000FF'
                },
                type: 'scatter'
            },
            axis: {
                x: {
                    label: 'عرض ویژه',
                    tick: {
                        fit: false
                    }
                },
                y: {
                    label: 'عرض ساده'
                }
            }
        });
        setTimeout(function () {
            chart.load({
                xs: {
                    'داده اول': 'virginica_x'
                },
                columns: [
                    ["virginica_x", 3.3, 2.7, 3.0, 2.9, 3.0, 3.0, 2.5, 2.9, 2.5, 3.6, 3.2, 2.7, 3.0, 2.5, 2.8, 3.2, 3.0, 3.8, 2.6, 2.2, 3.2, 2.8, 2.8, 2.7, 3.3, 3.2, 2.8, 3.0, 2.8, 3.0, 2.8, 3.8, 2.8, 2.8, 2.6, 3.0, 3.4, 3.1, 3.0, 3.1, 3.1, 3.1, 2.7, 3.2, 3.3, 3.0, 2.5, 3.0, 3.4, 3.0],
                    ["داده اول", 2.5, 1.9, 2.1, 1.8, 2.2, 2.1, 1.7, 1.8, 1.8, 2.5, 2.0, 1.9, 2.1, 2.0, 2.4, 2.3, 1.8, 2.2, 2.3, 1.5, 2.3, 2.0, 2.0, 1.8, 2.1, 1.8, 1.8, 1.8, 2.1, 1.6, 1.9, 2.0, 2.2, 1.5, 1.4, 2.3, 2.4, 1.8, 1.8, 2.1, 2.4, 2.3, 1.9, 2.3, 2.5, 2.3, 1.9, 2.0, 2.3, 1.8],
                ]
            });
        }, 1000);

        setTimeout(function () {
            chart.unload({
                ids: 'setosa'
            });
        }, 2000);

        setTimeout(function () {
            chart.load({
                columns: [
                    ["virginica", 0.2, 0.2, 0.2, 0.2, 0.2, 0.4, 0.3, 0.2, 0.2, 0.1, 0.2, 0.2, 0.1, 0.1, 0.2, 0.4, 0.4, 0.3, 0.3, 0.3, 0.2, 0.4, 0.2, 0.5, 0.2, 0.2, 0.4, 0.2, 0.2, 0.2, 0.2, 0.4, 0.1, 0.2, 0.2, 0.2, 0.2, 0.1, 0.2, 0.2, 0.3, 0.3, 0.2, 0.6, 0.4, 0.3, 0.2, 0.2, 0.2, 0.2],
                ]
            });
        }, 3000);

    });



    $(function () {
        var chart = c3.generate({
            bindto: '#c3-pie-chart',
            data: {
                // iris data from R
                columns: [
                    ['data1', 30],
                    ['data2', 120],
                ],
                type: 'pie',
                onclick: function (d, i) {
                    console.log("onclick", d, i);
                },
                onmouseover: function (d, i) {
                    console.log("onmouseover", d, i);
                },
                onmouseout: function (d, i) {
                    console.log("onmouseout", d, i);
                }
            }
        });
        setTimeout(function () {
            chart.load({
                columns: [
                    ["داده سوم", 0.2, 0.2, 0.2, 0.2, 0.2, 0.4, 0.3, 0.2, 0.2, 0.1, 0.2, 0.2, 0.1, 0.1, 0.2, 0.4, 0.4, 0.3, 0.3, 0.3, 0.2, 0.4, 0.2, 0.5, 0.2, 0.2, 0.4, 0.2, 0.2, 0.2, 0.2, 0.4, 0.1, 0.2, 0.2, 0.2, 0.2, 0.1, 0.2, 0.2, 0.3, 0.3, 0.2, 0.6, 0.4, 0.3, 0.2, 0.2, 0.2, 0.2],
                    ["داده دوم", 1.4, 1.5, 1.5, 1.3, 1.5, 1.3, 1.6, 1.0, 1.3, 1.4, 1.0, 1.5, 1.0, 1.4, 1.3, 1.4, 1.5, 1.0, 1.5, 1.1, 1.8, 1.3, 1.5, 1.2, 1.3, 1.4, 1.4, 1.7, 1.5, 1.0, 1.1, 1.0, 1.2, 1.6, 1.5, 1.6, 1.5, 1.3, 1.3, 1.3, 1.2, 1.4, 1.2, 1.0, 1.3, 1.2, 1.3, 1.3, 1.1, 1.3],
                    ["داده اول", 2.5, 1.9, 2.1, 1.8, 2.2, 2.1, 1.7, 1.8, 1.8, 2.5, 2.0, 1.9, 2.1, 2.0, 2.4, 2.3, 1.8, 2.2, 2.3, 1.5, 2.3, 2.0, 2.0, 1.8, 2.1, 1.8, 1.8, 1.8, 2.1, 1.6, 1.9, 2.0, 2.2, 1.5, 1.4, 2.3, 2.4, 1.8, 1.8, 2.1, 2.4, 2.3, 1.9, 2.3, 2.5, 2.3, 1.9, 2.0, 2.3, 1.8],
                ],
                colors: {
                    "داده سوم": '#F44336',
                    "داده دوم": '#34C73B',
                    "داده اول": '#00A2FF'
                }
            });
        }, 1500);

        setTimeout(function () {
            chart.unload({
                ids: 'data1'
            });
            chart.unload({
                ids: 'data2'
            });
        }, 2500);
    });


    $(function () {
        var chart = c3.generate({
            bindto: '#c3-donut-chart',
            data: {
                columns: [
                    ['data1', 30],
                    ['data2', 120],
                ],
                type: 'donut',
                onclick: function (d, i) {
                    console.log("onclick", d, i);
                },
                onmouseover: function (d, i) {
                    console.log("onmouseover", d, i);
                },
                onmouseout: function (d, i) {
                    console.log("onmouseout", d, i);
                }
            },
            donut: {
                title: "عنوان نمودار"
            }
        });
        setTimeout(function () {
            chart.load({
                columns: [
                    ["داده سوم", 0.2, 0.2, 0.2, 0.2, 0.2, 0.4, 0.3, 0.2, 0.2, 0.1, 0.2, 0.2, 0.1, 0.1, 0.2, 0.4, 0.4, 0.3, 0.3, 0.3, 0.2, 0.4, 0.2, 0.5, 0.2, 0.2, 0.4, 0.2, 0.2, 0.2, 0.2, 0.4, 0.1, 0.2, 0.2, 0.2, 0.2, 0.1, 0.2, 0.2, 0.3, 0.3, 0.2, 0.6, 0.4, 0.3, 0.2, 0.2, 0.2, 0.2],
                    ["داده دوم", 1.4, 1.5, 1.5, 1.3, 1.5, 1.3, 1.6, 1.0, 1.3, 1.4, 1.0, 1.5, 1.0, 1.4, 1.3, 1.4, 1.5, 1.0, 1.5, 1.1, 1.8, 1.3, 1.5, 1.2, 1.3, 1.4, 1.4, 1.7, 1.5, 1.0, 1.1, 1.0, 1.2, 1.6, 1.5, 1.6, 1.5, 1.3, 1.3, 1.3, 1.2, 1.4, 1.2, 1.0, 1.3, 1.2, 1.3, 1.3, 1.1, 1.3],
                    ["داده اول", 2.5, 1.9, 2.1, 1.8, 2.2, 2.1, 1.7, 1.8, 1.8, 2.5, 2.0, 1.9, 2.1, 2.0, 2.4, 2.3, 1.8, 2.2, 2.3, 1.5, 2.3, 2.0, 2.0, 1.8, 2.1, 1.8, 1.8, 1.8, 2.1, 1.6, 1.9, 2.0, 2.2, 1.5, 1.4, 2.3, 2.4, 1.8, 1.8, 2.1, 2.4, 2.3, 1.9, 2.3, 2.5, 2.3, 1.9, 2.0, 2.3, 1.8],
                ],
                colors: {
                    "داده سوم": '#F44336',
                    "داده دوم": '#34C73B',
                    "داده اول": '#00A2FF'
                }
            });
        }, 1500);

        setTimeout(function () {
            chart.unload({
                ids: 'data1'
            });
            chart.unload({
                ids: 'data2'
            });
        }, 2500);
    });

    $(function () {
        var chart = c3.generate({
            bindto: '#c3-gauge-chart',
            data: {
                columns: [
                    ['داده', 91.4]
                ],
                type: 'gauge',
                onclick: function (d, i) {
                    console.log("onclick", d, i);
                },
                onmouseover: function (d, i) {
                    console.log("onmouseover", d, i);
                },
                onmouseout: function (d, i) {
                    console.log("onmouseout", d, i);
                }
            },
            gauge: {
                label: {
                    format: function (value, ratio) {
                        return value;
                    },
                    show: false // to turn off the min/max labels.
                },
                min: 0, // 0 is default, //can handle negative min e.g. vacuum / voltage / current flow / rate of change
                max: 100, // 100 is default
                units: ' %',
                width: 39 // for adjusting arc thickness
            },
            color: {
                pattern: ['#F44336', '#00A2FF', '#0000FF', '#34C73B'], // the three color levels for the percentage values.
                threshold: {
                    unit: 'value', // percentage is default
                    max: 200, // 100 is default
                    values: [30, 60, 90, 100]
                }
            },
            size: {
                height: 180
            }
        });
        setTimeout(function () {
            chart.load({
                columns: [
                    ['داده', 10]
                ]
            });
        }, 1000);

        setTimeout(function () {
            chart.load({
                columns: [
                    ['داده', 50]
                ]
            });
        }, 2000);

        setTimeout(function () {
            chart.load({
                columns: [
                    ['داده', 70]
                ]
            });
        }, 3000);

        setTimeout(function () {
            chart.load({
                columns: [
                    ['داده', 0]
                ]
            });
        }, 4000);

        setTimeout(function () {
            chart.load({
                columns: [
                    ['داده', 100]
                ]
            });
        }, 5000);
    });


    $(function () {
        var chart = c3.generate({
            bindto: '#c3-category-axis',
            data: {
                columns: [
                    ['داده اول', 30, 200, 100, 400, 150, 250, 50, 100, 250]
                ],
                colors: {
                    "داده اول": '#34C73B'
                }
            },
            axis: {
                x: {
                    type: 'category',
                    categories: ['دسته1', 'دسته2', 'دسته3', 'دسته4', 'دسته5', 'دسته6', 'دسته7', 'دسته8', 'دسته9']
                }
            }
        });
    });



    $(function () {
        var chart = c3.generate({
            bindto: '#c3-additional-y-axis',
            data: {
                columns: [
                    ['داده دوم', 30, 200, 100, 400, 150, 250],
                    ['داده اول', 50, 20, 10, 40, 15, 25]
                ],
                colors: {
                    'داده دوم': '#34C73B',
                    'داده اول': '#00A2FF'
                },
                axes: {
                    'داده دوم': 'y',
                    'داده اول': 'y2'
                }
            },
            axis: {
                y2: {
                    show: true
                }
            }
        });
    });



    $(function () {
        var chart = c3.generate({
            bindto: '#c3-tick-format',
            data: {
                x: 'x',
                columns: [
                    ['x', '2010-01-01', '2011-01-01', '2012-01-01', '2013-01-01', '2014-01-01', '2015-01-01'],
                    ['نمونه', 30, 200, 100, 400, 150, 250]
                ],
                colors: {
                    "نمونه": '#34C73B'
                }
            },
            axis: {
                x: {
                    type: 'timeseries',
                    tick: {
                        format: function (x) {
                            return x.getFullYear();
                        }
                        //format: '%Y' // format string is also available for timeseries data
                    }
                }
            }
        });
    });


    $(function () {
        var chart = c3.generate({
            bindto: '#c3-tick-count',
            data: {
                x: 'x',
                columns: [
                    ['x', '2013-01-01', '2013-01-02', '2013-01-03', '2013-01-04', '2013-01-05', '2013-01-06', '2013-01-07', '2013-01-08', '2013-01-09', '2013-01-10', '2013-01-11', '2013-01-12'],
                    ['نمونه', 30, 200, 100, 400, 150, 250, 30, 200, 100, 400, 150, 250]
                ],
                colors: {
                    "نمونه": '#34C73B'
                }
            },
            axis: {
                x: {
                    type: 'timeseries',
                    tick: {
                        count: 4,
                        format: '%Y-%m-%d'
                    }
                }
            }
        });
    });



    $(function () {
        var chart = c3.generate({
            bindto: '#c3-tick-values',
            data: {
                x: 'x',
                columns: [
                    ['x', '2013-01-01', '2013-01-02', '2013-01-03', '2013-01-04', '2013-01-05', '2013-01-06', '2013-01-07', '2013-01-08', '2013-01-09', '2013-01-10', '2013-01-11', '2013-01-12'],
                    ['نمونه', 30, 200, 100, 400, 150, 250, 30, 200, 100, 400, 150, 250]
                ],
                colors: {
                    "نمونه": '#00A2FF'
                }
            },
            axis: {
                x: {
                    type: 'timeseries',
                    tick: {
                        // this also works for non timeseries data
                        values: ['1399-03-05', '1399-03-10']
                    }
                }
            }
        });
    });



    $(function () {
        var chart = c3.generate({
            bindto: '#c3-tick-culling',
            data: {
                columns: [
                    ['نمونه', 30, 200, 100, 400, 150, 250, 30, 200, 100, 400, 150, 250, 30, 200, 100, 400, 150, 250, 200, 100, 400, 150, 250]
                ],
                colors: {
                    "نمونه": '#34C73B'
                }
            },
            axis: {
                x: {
                    type: 'category',
                    tick: {
                        culling: {
                            max: 4 // the number of tick texts will be adjusted to less than this value
                        }
                        // for normal axis, default on
                        // for category axis, default off
                    }
                }
            }
        });
    });



    $(function () {
        var chart = c3.generate({
            bindto: '#c3-tick-fitting',
            data: {
                x: 'x',
                columns: [
                    ['x', '1398-10-31', '1398-12-31', '1399-01-31', '1399-02-28'],
                    ['نمونه', 30, 100, 400, 150],
                ],
                colors: {
                    "نمونه": '#00A2FF'
                }
            },
            axis: {
                x: {
                    type: 'timeseries',
                    tick: {
                        fit: true,
                        format: "%e %b %y"
                    }
                }
            }
        });
    });



    $(function () {
        var chart = c3.generate({
            bindto: '#c3-tick-timezone',
            data: {
                x: 'x',
                xFormat: '%Y',
                columns: [
                    //            ['x', '2012-12-31', '2013-01-01', '2013-01-02', '2013-01-03', '2013-01-04', '2013-01-05'],
                    ['x', '1394', '1395', '1396', '1397', '1398', '1399'],
                    ['داده دوم', 30, 200, 100, 400, 150, 250],
                    ['داده اول', 130, 340, 200, 500, 250, 350]
                ],
                colors: {
                    'داده دوم': '#00A2FF',
                    'داده اول': '#34C73B'
                }
            },
            axis: {
                x: {
                    type: 'timeseries',
                    // if true, treat x value as localtime (Default)
                    // if false, convert to UTC internally
                    localtime: false,
                    tick: {
                        format: '%Y-%m-%d %H:%M:%S'
                    }
                }
            }
        });
    });



    $(function () {
        var chart = c3.generate({
            bindto: '#c3-tick-text',
            data: {
                x: 'x',
                columns: [
                    ['x', 'www.somesitename1.com', 'www.somesitename2.com', 'www.somesitename3.com', 'www.somesitename4.com', 'www.somesitename5.com', 'www.somesitename6.com', 'www.somesitename7.com', 'www.somesitename8.com', 'www.somesitename9.com', 'www.somesitename10.com', 'www.somesitename11.com', 'www.somesitename12.com'],
                    ['نمونه', 90, 100, 140, 200, 100, 400, 90, 100, 140, 200, 100, 400],
                ],
                colors: {
                    "نمونه": '#00A2FF'
                },
                type: 'bar'
            },
            axis: {
                x: {
                    type: 'category',
                    tick: {
                        rotate: 75,
                        multiline: false
                    },
                    height: 130
                }
            }
        });
    });


    $(function () {
        var chart = c3.generate({
            bindto: '#c3-y-axis-tick-timezone',
            data: {
                columns: [
                    ['نمونه', 30, 200, 100, 400, 150, 2500]
                ],
                colors: {
                    "'داده دوم'": '#00A2FF'
                },
            },
            axis: {
                y: {
                    tick: {
                        format: d3.format(",")
                        //                format: function (d) { return "$" + d; }
                    }
                }
            }
        });
    });


    $(function () {
        var chart = c3.generate({
            bindto: '#c3-padding-y-axis',
            data: {
                columns: [
                    ['داده دوم', 30, 200, 100, 400, 150, 250],
                    ['داده اول', 50, 20, 10, 40, 15, 25]
                ],
                axes: {
                    'داده دوم': 'y',
                    'داده اول': 'y2'
                },
                colors: {
                    'داده دوم': '#34C73B',
                    'داده اول': '#00A2FF'
                },
            },
            axis: {
                y: {
                    padding: {
                        top: 200,
                        bottom: 0
                    }
                },
                y2: {
                    padding: {
                        top: 100,
                        bottom: 100
                    },
                    show: true
                }
            }
        });
    });


    $(function () {
        var chart = c3.generate({
            bindto: '#c3-range-y-axis',
            data: {
                columns: [
                    ['نمونه', 30, 200, 400, -400, 150, 250]
                ],
                colors: {
                    'نمونه': '#00A2FF'
                }
            },
            axis: {
                y: {
                    max: 400,
                    min: -400,
                    // Range includes padding, set 0 if no padding needed
                    // padding: {top:0, bottom:0}
                }
            }
        });
    });

    $(function () {
        var chart = c3.generate({
            bindto: '#c3-axis-label',
            data: {
                columns: [
                    ['نمونه2', 30, 200, 100, 400, 150, 250],
                    ['نمونه1', 130, 300, 200, 500, 250, 350]
                ],
                axes: {
                    "نمونه1": 'y2'
                },
                colors: {
                    'نمونه2': '#34C73B',
                    'نمونه1': '#00A2FF'
                }
            },
            axis: {
                x: {
                    label: 'برچسب X'
                },
                y: {
                    label: 'برچسب Y'
                },
                y2: {
                    show: true,
                    label: 'برچسب Y2'
                }
            }
        });
    });


    $(function () {
        var chart = c3.generate({
            bindto: '#c3-axis-label-position',
            data: {
                columns: [
                    ['نمونه2', 30, 200, 100, 400, 150, 250],
                    ['نمونه1', 430, 300, 500, 400, 650, 250]
                ],
                colors: {
                    'نمونه2': '#34C73B',
                    'نمونه1': '#00A2FF'
                },
                axes: {
                    "نمونه2": 'y',
                    "نمونه1": 'y2'
                }
            },
            axis: {
                x: {
                    label: {
                        text: 'برچسب X',
                        position: 'outer-center'
                        // inner-right : default
                        // inner-center
                        // inner-left
                        // outer-right
                        // outer-center
                        // outer-left
                    }
                },
                y: {
                    label: {
                        text: 'برچسب Y',
                        position: 'outer-middle'
                        // inner-top : default
                        // inner-middle
                        // inner-bottom
                        // outer-top
                        // outer-middle
                        // outer-bottom
                    }
                },
                y2: {
                    show: true,
                    label: {
                        text: 'برچسب Y2',
                        position: 'outer-middle'
                        // inner-top : default
                        // inner-middle
                        // inner-bottom
                        // outer-top
                        // outer-middle
                        // outer-bottom
                    }
                }
            }
        });
    });



});