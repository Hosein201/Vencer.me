$(function () {
    $("#username").editable({
        type: "text",
        pk: 1,
        name: "username",
        title: "نام کاربری خود را وارد کنید"
    }), $("#firstname").editable({
        validate: function (e) {
            if ("" == $.trim(e)) return "این فیلد اجباری است"
        }
    }), $("#sex").editable({
        prepend: "انتخاب نشده",
        source: [{
            value: 1,
            text: "مرد"
        }, {
            value: 2,
            text: "زن"
        }],
        display: function (e, t) {
            var i = $.grep(t, function (t) {
                return t.value == e
            });
            i.length ? $(this).text(i[0].text).css("color", {
                "": "#98a6ad",
                1: "#5fbeaa",
                2: "#5d9cec"
            } [e]) : $(this).empty()
        }
    }), $("#status").editable(), $("#group").editable({
        showbuttons: !1
    }), $("#dob").editable(), $("#comments").editable({
        showbuttons: "bottom"
    }), $("#inline-username").editable({
        type: "text",
        pk: 1,
        name: "username",
        title: "نام کاربری خود را وارد کنید",
        mode: "inline"
    }), $("#inline-firstname").editable({
        validate: function (e) {
            if ("" == $.trim(e)) return "این فیلد اجباری است"
        },
        mode: "inline"
    }), $("#inline-sex").editable({
        prepend: "انتخاب نشده",
        mode: "inline",
        source: [{
            value: 1,
            text: "مرد"
        }, {
            value: 2,
            text: "زن"
        }],
        display: function (e, t) {
            var i = $.grep(t, function (t) {
                return t.value == e
            });
            i.length ? $(this).text(i[0].text).css("color", {
                "": "#98a6ad",
                1: "#5fbeaa",
                2: "#5d9cec"
            } [e]) : $(this).empty()
        }
    }), $("#inline-status").editable({
        mode: "inline"
    }), $("#inline-group").editable({
        showbuttons: !1,
        mode: "inline"
    }), $("#inline-dob").editable({
        mode: "inline"
    }), $("#inline-comments").editable({
        showbuttons: "bottom",
        mode: "inline"
    })
});