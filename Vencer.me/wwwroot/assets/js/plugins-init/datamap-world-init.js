(function ($) {
    "use strict"

    var i = new Datamap({
        scope: "world",
        element: document.getElementById("world-map-restaurant"),
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


})(jQuery)