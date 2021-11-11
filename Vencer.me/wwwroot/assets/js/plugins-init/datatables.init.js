let dataSet = [
    ["میترا خاکی", "مدیر سیستم", "تهران", "5421", "1397/04/25", "1,945,000 تومان"],
    ["سعید خضری", "حسابدار", "شیراز", "8422", "1397/07/25", "1,750,000 تومان"],
    ["سوگل کریمی", "نویسنده بخش فنی", "تبریز", "1562", "1396/01/12", "2,645,000 تومان"],
    ["طاها قربانی", "توسعه دهنده جاوا اسکریپت", "تهران", "6224", "1397/03/29", "2,342,000 تومان"],
    ["پریسا خادمی", "حسابدار", "شیراز", "5407", "1395/11/28", "2,132,000 تومان"],
    ["کیوان جلیلی", "مدیر فروش", "اصفهان", "4804", "1397/12/02", "3,431,000 تومان"],
    ["الهه معصومی", "دستیار فروش", "تبریز", "9608", "1397/08/06", "2,778,000 تومان"],
    ["مریم خادم", "مدیر فروش", "شیراز", "6200", "2010/10/14", "2,266,000 تومان"],
    ["کامبیز کشاورز", "توسعه دهنده جاوا", "تبریز", "2360", "1396/09/15", "3,115,000 تومان"],
    ["تبسم هاشمی", "مهندس نرم افزار", "تهران", "1667", "1395/12/13", "2,415,000 تومان"],
    ["ترانه مکرم", "مدیر دفتر", "مشهد", "3814", "1395/12/19", "1,985,000 تومان"],
    ["حسین مومنی", "مدیر پشتیبانی", "تهران", "9497", "2013/03/03", "2,455,000 تومان"],
    ["صدرا عرفانی", "نویسنده", "تبریز", "6741", "1395/10/16", "3,843,000 تومان"],
    ["کتایون امیری", "دیجیتال مارکتنگ", "مشهد", "3597", "1397/12/18", "3,345,000 تومان"],
    ["آتنا جهرمی", "نویسنده", "مشهد", "1965", "2010/03/17", "1,119,000 تومان"],
    ["سمیرا سبحانی", "طراح گرافیک", "مشهد", "1581", "1397/11/27", "1,873,000 تومان"],
    ["ستایش واحدی", "مدیر ارشد سئو", "اصفهان", "3059", "2010/06/09", "2,455,000 تومان"],
    ["سمیه نریمانی", "مدیر سیستم", "اصفهان", "1721", "1396/04/10", "2,600,000 تومان"],
    ["امید هاشمی", "مهندس نرم افزار", "مشهد", "2558", "1397/10/13", "1,569,000 تومان"],
    ["محمد کاظمی", "پشتیبانی فنی", "تهران", "2290", "1397/09/26", "2,548,000 تومان"],
    ["یوسف محمودی", "توسعه دهنده", "اصفهان", "1937", "1397/09/03", "2,124,000 تومان"],
    ["پدرام شریفی", "سئو", "اصفهان", "6154", "1396/06/25", "3,654,000 تومان"],
    ["علی آقایی", "پشتیبانی فروش", "اصفهان", "8330", "1397/12/12", "2,352,000 تومان"],
    ["همایون معینی", "دستیار فروش", "سمنان", "3023", "2010/09/20", "3,451,000 تومان"],
    ["فریبا غفاری", "سئو", "مشهد", "5797", "1396/10/09", "3,745,000 تومان"],
    ["حسن جعفری", "توسعه دهنده", "تهران", "8822", "2010/12/22", "3,181,000 تومان"],
    ["مریم دهقان", "نویسنده", "مازندران", "9239", "2010/11/14", "2,568,000 تومان"],
    ["یلدا رضوانی", "مهندس نرم افزار", "تبریز", "1314", "1397/06/07", "1,214,000 تومان"],
    ["رضا افشار", "سئو", "تبریز", "2947", "2010/03/11", "3,954,000 تومان"],
    ["ساناز توکلی", "دیجیتال مارکتینگ", "شیراز", "8899", "1397/08/14", "$2,457,000 تومان"],
    ["لیلا میرزایی", "مدیر فروش", "سمنان", "2769", "1397/06/02", "1,311,000 تومان"],
    ["بهروز تقوی", "توسعه دهنده", "مشهد", "6832", "1396/10/22", "3,922,000 تومان"],
    ["رها قربانی", "نویسنده بخش فنی", "مشهد", "3606", "1397/05/07", "2,874,000 تومان"],
    ["ماهان رحیمی", "مدیر تیم", "تبریز", "2860", "1395/10/26", "2,118,000 تومان"],
    ["امیرعلی جهانبخت", "پشتیبانی فروش", "تهران", "8240", "1397/03/09", "2,825,000 تومان"],
    ["حسین الهامی", "طراح گرافیک", "تبریز", "5384", "1396/12/09", "2,329,000 تومان"]
];




(function ($) {
    "use strict"

    $('.example-style').DataTable();
    //example 1
    var table = $('#example').DataTable({
        createdRow: function (row, data, index) {
            $(row).addClass('selected')
        }
    });

    table.on('click', 'tbody tr', function () {
        var $row = table.row(this).nodes().to$();
        var hasClass = $row.hasClass('selected');
        if (hasClass) {
            $row.removeClass('selected')
        } else {
            $row.addClass('selected')
        }
    })

    table.rows().every(function () {
        this.nodes().to$().removeClass('selected')
    });



    //example 2
    var table2 = $('#example2').DataTable({
        createdRow: function (row, data, index) {
            $(row).addClass('selected')
        },

        "scrollY": "42vh",
        "scrollCollapse": true,
        "paging": false
    });

    table2.on('click', 'tbody tr', function () {
        var $row = table2.row(this).nodes().to$();
        var hasClass = $row.hasClass('selected');
        if (hasClass) {
            $row.removeClass('selected')
        } else {
            $row.addClass('selected')
        }
    })

    table2.rows().every(function () {
        this.nodes().to$().removeClass('selected')
    });


    //example 3
    var table3 = $('#example3').DataTable({
        createdRow: function (row, data, index) {
            $(row).addClass('selected')
        },

        "scrollY": "400",
        "scrollX": true
    });

    table3.on('click', 'tbody tr', function () {
        var $row = table3.row(this).nodes().to$();
        var hasClass = $row.hasClass('selected');
        if (hasClass) {
            $row.removeClass('selected')
        } else {
            $row.addClass('selected')
        }
    })

    table3.rows().every(function () {
        this.nodes().to$().removeClass('selected')
    });


    //example 4
    var table4 = $('#example4').DataTable({
        createdRow: function (row, data, index) {
            $(row).addClass('selected')
        },

        "scrollX": true
    });

    table4.on('click', 'tbody tr', function () {
        var $row = table4.row(this).nodes().to$();
        var hasClass = $row.hasClass('selected');
        if (hasClass) {
            $row.removeClass('selected')
        } else {
            $row.addClass('selected')
        }
    })

    table4.rows().every(function () {
        this.nodes().to$().removeClass('selected')
    });

    //ajax example
    $('#example-ajax').DataTable({
        "ajax": '../ajax/arrays.json'
    });


    //datasource example 1
    $('#example-datasource1').DataTable({
        data: dataSet,
        columns: [{
                title: "نام"
            },
            {
                title: "موقعیت شغلی"
            },
            {
                title: "دفتر"
            },
            {
                title: "گسترش"
            },
            {
                title: "تاریخ شروع"
            },
            {
                title: "حقوق"
            }
        ]
    });

    // Setup - add a text input to each footer cell
    $('#example-api-1 tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text"  placeholder="جستجو ' + title + '" />');
    });

    // DataTable - individual column searching by text
    var table = $('#example-api-1').DataTable();

    // Apply the search
    table.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });


    //datatable individual column searching by select
    $('#example-api-2').DataTable({
        initComplete: function () {
            this.api().columns().every(function () {
                var column = this;
                var select = $('<select><option value=""></option></select>')
                    .appendTo($(column.footer()).empty())
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );

                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });

                column.data().unique().sort().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>')
                });
            });
        }
    });


    //Row selection (multiple rows)
    var table = $('#example-api-3').DataTable();

    $('#example-api-3 tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
    });

    $('#show-row').click(function () {
        alert(table.rows('.selected').data().length + ' row(s) selected');
    });


    //Add new row
    var t = $('#example-api-4').DataTable();
    var counter = 1;

    $('#addRow').on('click', function () {
        t.row.add([
            counter + '.1',
            counter + '.2',
            counter + '.3',
            counter + '.4',
            counter + '.5'
        ]).draw(false);

        counter++;
    });

    // Automatically add a first row of data
    $('#addRow').click();


    //Form inputs
    var table = $('#example-api-5').DataTable();

    $('#form-submit').click(function () {
        var data = table.$('input, select').serialize();
        alert(
            "داده های زیر به سرور ارسال می شوند : \n\n" +
            data.substr(0, 120) + '...'
        );
        return false;
    });


    //Show / hide columns dynamically
    var table = $('#example-api-6').DataTable({
        "scrollY": "200px",
        "paging": false
    });

    $('.toggle-vis').on('click', function (e) {
        e.preventDefault();

        // Get the column API object
        var column = table.column($(this).attr('data-column'));

        // Toggle the visibility
        column.visible(!column.visible());
    });


    //Search API (regular expressions)
    function filterGlobal() {
        $('#example-api-7').DataTable().search(
            $('#global_filter').val(),
            $('#global_regex').prop('checked'),
            $('#global_smart').prop('checked')
        ).draw();
    }

    function filterColumn(i) {
        $('#example-api-7').DataTable().column(i).search(
            $('#col' + i + '_filter').val(),
            $('#col' + i + '_regex').prop('checked'),
            $('#col' + i + '_smart').prop('checked')
        ).draw();
    }

    $('#example-api-7').DataTable();

    $('input.global_filter').on('keyup click', function () {
        filterGlobal();
    });

    $('input.column_filter').on('keyup click', function () {
        filterColumn($(this).parents('tr').attr('data-column'));
    });


    //DOM / jQuery events
    var table = $('#example-advance-1').DataTable();

    $('#example-advance-1 tbody').on('click', 'tr', function () {
        var data = table.row(this).data();
        alert('شما کلیک کرده اید روی ' + data[0] + '\'s ردیف');
    });


    //DataTables events
    var eventFired = function (type) {
        var n = $('#demo_info')[0];
        n.innerHTML += '<div>' + ' رویداد ' + type + ' - ' + new Date().getTime() + '</div>';
        n.scrollTop = n.scrollHeight;
    }

    $('#example-advance-2')
        .on('order.dt', function () {
            eventFired('سفارشی');
        })
        .on('search.dt', function () {
            eventFired('یافت شده');
        })
        .on('page.dt', function () {
            eventFired('صفحه');
        })
        .DataTable();



    //Language file
    $('#example-advance-3').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/German.json"
        }
    });




    //plugins

    //API plug-in methods
    $.fn.dataTable.Api.register('column().data().sum()', function () {
        return this.reduce(function (a, b) {
            var x = parseFloat(a) || 0;
            var y = parseFloat(b) || 0;
            return x + y;
        });
    });

    /* Init the table and fire off a call to get the hidden nodes. */

    var table = $('#example-plugin-1').DataTable();

    $('<button class="btn btn-light mb-5">برای مشاهده جمع سن همه ردیف ها اینجا کلیک کنید</button>')
        .prependTo('#demo')
        .on('click', function () {
            alert('جمع ستون سن برابر است با : ' + table.column(3).data().sum());
        });

    $('<button class="btn btn-light mb-5 mr-4">برای مشاهده جمع سن ردیف های قابل مشاهده اینجا کلیک کنید</button>')
        .prependTo('#demo')
        .on('click', function () {
            alert('جمع ستون سن برابر است با : ' + table.column(3, {
                page: 'current'
            }).data().sum());
        });






    //Custom filtering - range search
    $.fn.dataTable.ext.search.push(
        function (settings, data, dataIndex) {
            var min = parseInt($('#min').val(), 10);
            var max = parseInt($('#max').val(), 10);
            var age = parseFloat(data[3]) || 0; // use data for the age column

            if ((isNaN(min) && isNaN(max)) ||
                (isNaN(min) && age <= max) ||
                (min <= age && isNaN(max)) ||
                (min <= age && age <= max)) {
                return true;
            }
            return false;
        }
    );

    var table = $('#example-plugin-2').DataTable();

    // Event listener to the two range filtering inputs to redraw on input
    $('#min, #max').keyup(function () {
        table.draw();
    });



    //Live DOM ordering
    $.fn.dataTable.ext.order['dom-text'] = function (settings, col) {
        return this.api().column(col, {
            order: 'index'
        }).nodes().map(function (td, i) {
            return $('input', td).val();
        });
    }

    /* Create an array with the values of all the input boxes in a column, parsed as numbers */
    $.fn.dataTable.ext.order['dom-text-numeric'] = function (settings, col) {
        return this.api().column(col, {
            order: 'index'
        }).nodes().map(function (td, i) {
            return $('input', td).val() * 1;
        });
    }

    /* Create an array with the values of all the select options in a column */
    $.fn.dataTable.ext.order['dom-select'] = function (settings, col) {
        return this.api().column(col, {
            order: 'index'
        }).nodes().map(function (td, i) {
            return $('select', td).val();
        });
    }

    /* Create an array with the values of all the checkboxes in a column */
    $.fn.dataTable.ext.order['dom-checkbox'] = function (settings, col) {
        return this.api().column(col, {
            order: 'index'
        }).nodes().map(function (td, i) {
            return $('input', td).prop('checked') ? '1' : '0';
        });
    }

    /* Initialise the table with the required column ordering data types */
    $(document).ready(function () {
        $('#example-plugin-3').DataTable({
            "columns": [
                null,
                {
                    "orderDataType": "dom-text-numeric"
                },
                {
                    "orderDataType": "dom-text",
                    type: 'string'
                },
                {
                    "orderDataType": "dom-select"
                }
            ]
        });
    });




})(jQuery);