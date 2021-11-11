(function ($) {
    'use strict'

    //basic jsgrid table
    let clients = [{
            "نام": "رضا افشار",
            "سن": 25,
            "شهر": 1,
            "آدرس": "میدان آزادی، خیابان آزادی",
            "Married": false
        },
        {
            "نام": "نرگس محمدی",
            "سن": 45,
            "شهر": 2,
            "آدرس": "میدان امام، خیابان شهید بهشتی",
            "Married": true
        },
        {
            "نام": "علیرضا کریمی",
            "سن": 29,
            "شهر": 3,
            "آدرس": "خیابان گلها، خیابان پرستو، پلاک 7",
            "Married": false
        },
        {
            "نام": "الناز سبحانی",
            "سن": 56,
            "شهر": 1,
            "آدرس": "خیابان شهید سبحانی، پلاک 66",
            "Married": true
        },
        {
            "نام": "امیر صبور",
            "سن": 56,
            "شهر": 1,
            "آدرس": "میدان فردوسی، خیابان امید",
            "Married": true
        },
        {
            "نام": "امیر صبور",
            "سن": 56,
            "شهر": 1,
            "آدرس": "میدان فردوسی، خیابان امید",
            "Married": true
        },
        {
            "نام": "امیر صبور",
            "سن": 56,
            "شهر": 1,
            "آدرس": "میدان فردوسی، خیابان امید",
            "Married": true
        },
        {
            "نام": "امیر صبور",
            "سن": 56,
            "شهر": 1,
            "آدرس": "میدان فردوسی، خیابان امید",
            "Married": true
        },
        {
            "نام": "امیر صبور",
            "سن": 56,
            "شهر": 1,
            "آدرس": "میدان فردوسی، خیابان امید",
            "Married": true
        },
        {
            "نام": "امیر صبور",
            "سن": 56,
            "شهر": 1,
            "آدرس": "میدان فردوسی، خیابان امید",
            "Married": true
        },
        {
            "نام": "امیر صبور",
            "سن": 56,
            "شهر": 1,
            "آدرس": "میدان فردوسی، خیابان امید",
            "Married": true
        },
        {
            "نام": "مینا قربانی",
            "سن": 32,
            "شهر": 3,
            "آدرس": "میدان حافظ، خیابان استاندارد",
            "Married": false
        }
    ];
    let countries = [{
            Name: "",
            Id: 0
        },
        {
            Name: "تهران",
            Id: 1
        },
        {
            Name: "شیراز",
            Id: 2
        },
        {
            Name: "تبریز",
            Id: 3
        }
    ];
    $("#jsGrid-basic").jsGrid({
        width: "100%",
        height: "400px",

        inserting: true,
        editing: true,
        sorting: true,
        paging: true,

        data: clients,

        fields: [{
                name: "نام",
                type: "text",
                width: 150,
                validate: "required"
            },
            {
                name: "سن",
                type: "number",
                width: 50,
                css: "text-center"
            },
            {
                name: "آدرس",
                type: "text",
                width: 200
            },
            {
                name: "شهر",
                type: "select",
                items: countries,
                valueField: "Id",
                textField: "Name"
            },
            {
                name: "Married",
                type: "checkbox",
                title: "متأهل",
                sorting: false
            },
            {
                type: "control"
            }
        ]
    });



})(jQuery)