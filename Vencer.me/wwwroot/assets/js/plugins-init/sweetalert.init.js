document.querySelector(".sweet-wrong").onclick = function () {
    sweetAlert("اوه ...", "خطایی رخ داده است!", "error")
}, document.querySelector(".sweet-message").onclick = function () {
    swal("سلام، این یک پیغام است !!")
}, document.querySelector(".sweet-text").onclick = function () {
    swal("سلام، این یک پیغام متنی است !!", "این زیباست!")
}, document.querySelector(".sweet-success").onclick = function () {
    swal("خب، کارت عالی بود!", "ثبت نام شما با موفیت انجام شد", "success")
}, document.querySelector(".sweet-confirm").onclick = function () {
    swal({
        title: "آیا از حذف مطمئن هستید؟",
        text: "شما بعد از حذف قادر به بازگردانی فایل نخواهید بود!",
        type: "warning",
        showCancelButton: !0,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "بله، حذف شود",
        closeOnConfirm: !1
    }, function () {
        swal("حف شد!!", "فایل شما با موفقیت حذف شد!", "success")
    })
}, document.querySelector(".sweet-success-cancel").onclick = function () {
    swal({
        title: "آیا از حذف فایل اطمینان دارید؟",
        text: "بعد از حذف شما قادر به بازگردانی فایل نخواهید بود!",
        type: "warning",
        showCancelButton: !0,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "بله، حذف شود !!",
        cancelButtonText: "نه، حذف نشود !!",
        closeOnConfirm: !1,
        closeOnCancel: !1
    }, function (e) {
        e ? swal("حذف شد!", "فایل شما با موفیقیت حذف شد", "success") : swal("لغو شد !!", "شما عملیات حذف را لغو کردید !!", "error")
    })
}, document.querySelector(".sweet-image-message").onclick = function () {
    swal({
        title: "هشدار شیرین !!",
        text: "این یک هشدار تصویری است !",
        imageUrl: "../../assets/images/hand.jpg"
    })
}, document.querySelector(".sweet-html").onclick = function () {
    swal({
        title: "هشدار شیرین !!",
        text: "<span style='color:#ff0000'>شما از تگ های HTML استفاده کردید<span>",
        html: !0
    })
}, document.querySelector(".sweet-auto").onclick = function () {
    swal({
        title: "هشدار با بسته شدن اتوماتیک !!",
        text: "این هشدار بعد از 2 ثانیه به صورت خودکا بسته خواهد شد !!",
        timer: 2e3,
        showConfirmButton: !1
    })
}, document.querySelector(".sweet-prompt").onclick = function () {
    swal({
        title: "یک ورودی را انتخاب کنید!!",
        text: "اینجا میتوانید هرچیزی بنویسید!!",
        type: "input",
        showCancelButton: !0,
        closeOnConfirm: !1,
        animation: "slide-from-top",
        inputPlaceholder: "چیزی بنویسید"
    }, function (e) {
        return !1 !== e && ("" === e ? (swal.showInputError("شما باید چیزی بنویسد!!"), !1) : void swal("سلام!!", "نوشته شما : " + e, "success"))
    })
}, document.querySelector(".sweet-ajax").onclick = function () {
    swal({
        title: "هشدار ajax !!",
        text: "تایید کنید تا درخواست ارسال شود !!",
        type: "info",
        showCancelButton: !0,
        closeOnConfirm: !1,
        showLoaderOnConfirm: !0
    }, function () {
        setTimeout(function () {
            swal("درخواست شما با موفقیت به چایان رسید !!")
        }, 2e3)
    })
};