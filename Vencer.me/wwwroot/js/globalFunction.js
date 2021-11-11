function gritterNotification(type, title, text) {
    switch (type) {
        case "info":
            toastr.info(text, title, {
                positionClass: "toast-top-right",
                timeOut: 5e3,
                closeButton: !0,
                debug: !1,
                newestOnTop: !0,
                progressBar: !0,
                preventDuplicates: !0,
                onclick: null,
                showDuration: "300",
                hideDuration: "1000",
                extendedTimeOut: "1000",
                showEasing: "swing",
                hideEasing: "linear",
                showMethod: "fadeIn",
                hideMethod: "fadeOut",
                tapToDismiss: !1
            })
            break;
        case "success":
            toastr.success(text, title, {
                timeOut: 5e3,
                closeButton: !0,
                debug: !1,
                newestOnTop: !0,
                progressBar: !0,
                positionClass: "toast-top-right",
                preventDuplicates: !0,
                onclick: null,
                showDuration: "300",
                hideDuration: "1000",
                extendedTimeOut: "1000",
                showEasing: "swing",
                hideEasing: "linear",
                showMethod: "fadeIn",
                hideMethod: "fadeOut",
                tapToDismiss: !1
            })
            break;
        case "warning":
            toastr.warning(text, title, {
                positionClass: "toast-top-right",
                timeOut: 5e3,
                closeButton: !0,
                debug: !1,
                newestOnTop: !0,
                progressBar: !0,
                preventDuplicates: !0,
                onclick: null,
                showDuration: "300",
                hideDuration: "1000",
                extendedTimeOut: "1000",
                showEasing: "swing",
                hideEasing: "linear",
                showMethod: "fadeIn",
                hideMethod: "fadeOut",
                tapToDismiss: !1
            })
            break;
        case "error":
            toastr.error(text, title, {
                positionClass: "toast-top-right",
                timeOut: 5e3,
                closeButton: !0,
                debug: !1,
                newestOnTop: !0,
                progressBar: !0,
                preventDuplicates: !0,
                onclick: null,
                showDuration: "300",
                hideDuration: "1000",
                extendedTimeOut: "1000",
                showEasing: "swing",
                hideEasing: "linear",
                showMethod: "fadeIn",
                hideMethod: "fadeOut",
                tapToDismiss: !1
            })
            break;
        default:
    }
  
};
function swalGlobal(dataClik, title, text, icon, textCancel, valueCancel, visibleCancel, classNameCancel, closeModalCancel,
    functionCancel, textConfirm, valueConfirm, visibleConfirm, classNameConfirm, closeModalConfirm, functionConfirm,functionDefault)
{
    switch (icon) {
        case "success":
            $('[data-click="'+dataClik+'"]').click(function (e) {
                e.preventDefault();
                swal({
                    title: title,
                    text: text,
                    icon: icon,
                    buttons: {
                        cancel: {
                            text: textCancel,
                            value: valueCancel,
                            visible: visibleCancel,
                            className: classNameCancel,
                            closeModal: closeModalCancel,
                        },
                        confirm: {
                            text: textConfirm,
                            value: valueConfirm,
                            visible: visibleConfirm,
                            className: classNameConfirm,
                            closeModal: closeModalConfirm,
                        }
                    }
                }).then((value) => {
                    switch (value) {
                        case true:
                            functionConfirm();
                            break;
                        case false:
                            functionCancel();
                            break;
                        default:
                            functionDefault();
                    }
                });;
            });
            break;
        case "success":
            $.gritter.add({
                title: title,
                text: text,
                image: '../assets/plugins/gritter/images/success.png',
                sticky: false,
                time: 2000,
                class_name: 'my-sticky-class'
            });
            break;
        case "warning":
            $.gritter.add({
                title: title,
                text: text,
                image: '../assets/plugins/gritter/images/warning.png',
                sticky: false,
                time: 2000,
                class_name: 'my-sticky-class'
            });
            break;
        case "error":
            $.gritter.add({
                title: title,
                text: text,
                image: '../assets/plugins/gritter/images/error.png',
                sticky: false,
                time: 2000,
                class_name: 'my-sticky-class'
            });
            break;
        default:
    }
}

function ajaxGetDropDownLists(url, data, idDropDownLists, dataTextField, dataValueField, optionLabel  ) {
    $.ajax({
        url: url,
        headers: { "Authorization": 'Bearer ' + document.cookie.toString().split('=')[1] },
        type: 'Get',
        data: data,
        success: function (response) {
            ;
            if (response.isSuccess) {
                $("#" + idDropDownLists).kendoDropDownList({
                    optionLabel: optionLabel,
                    dataTextField: dataTextField,
                    dataValueField: dataValueField,
                    dataSource: {
                        data: response.data
                    },
                });
            }
            console.log(response);
        },
        error: function (xhr) {
            ; 
            iziTostGlobal('error', 'خطا', 'خطایی درسیستم رخ داده است', false ,999);
            console.log(xhr);
        }
    });
}

function disabledBtn(idBtn, bool) {
    $("#"+idBtn).attr('disabled', bool); 
}

function getValueAttr(typeSelect, select, attrName) {
    var value = '';
    switch (typeSelect) {
        case "class":
            value= $('.' + select).attr(attrName);
            break;
        case "id":
            value= $('#' + select).attr(attrName);
            break;
        default:
            value = '';
            break;
    }
    return value;
}

function setAttr(typeSelect, select, attrName, value) {
    switch (typeSelect) {
        case "class":
            $('.'+ select).attr(attrName, value);
            break;
        case "id":
            $('#'+ select).attr(attrName, value);
            break;
        default:
            break;
    }
}

function removeAttr(typeSelect, select, attrName) {
    switch (typeSelect) {
        case "class":
            $('.' + select).removeAttr(attrName);
            break;
        case "id":
            $('#' + select).removeAttr(attrName);
            break;
        default:
            break;
    }
}    

function setCookie(nameCookie, valueCookie, expireCookie) {
    var d = new Date();
    d.setTime(d.getTime() + (expireCookie * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = nameCookie + "=" + valueCookie + ";" + expires + ";path=/";
}

function getCookie(nameCookie) {
    var allCookie = document.cookie.toString().split(';');
    var cookie = null;
    $.each(allCookie, function (i, v) {
        var name = v.toString().split('=')[0].trim();
        if (nameCookie === name) {
             cookie = v.toString().split('=')[1];
            return;
        }
    });
    return cookie;
}

function deleteCookie(nameCookie) {
    var allCookie = document.cookie.toString().split(';');
    var cookie = null;
    $.each(allCookie, function (i, v) {
        var name = v.toString().split('=')[0].trim();
        if (nameCookie === name) {
            cookie = null;
            return;
        }
    });
    return cookie;
}

function getDataTimeNow() {
    var dt = new Date();
    var time = dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds();
    return time;
}

function requestToPay(amount, paymentType ) {
    $.ajax({
        url: '/api/ApiPaymentComponent/RequestToPay',
       // headers: { "Authorization": 'Bearer ' + getCookie('Bearer') },
        type: 'Post',
        data: {
            Amount:amount,
            PaymentType:paymentType
        },
        success: function (response) {
            ;
            console.log(response);
            if (response.isSuccess) {
                iziTostGlobal('success', 'موفق', 'عملیات با موفقیت انجام شد', false, 999);
                return response;
            }
            else {
                iziTostGlobal('error', 'خطا', 'خطایی درسیستم به وجود امده است', false, 999);
            }
        },
        error: function (xhr) {
            console.log(xhr);
            ;
            iziTostGlobal('error', 'خطا', 'خطایی درسیستم به وجود امده است', false, 999);
        }
    });
}

function verifyToPay(data) {
    ;
    $.ajax({
        url: '/api/ApiPaymentComponent/VerifyPay',
        headers: { "Authorization": 'Bearer ' + getCookie('Bearer') },
        type: 'Post',
        data: {
            Amount:amount,
            PaymentType:paymentType
        },
        success: function (response) {
            ;
            console.log(response);
            if (response.isSuccess) {
                iziTostGlobal('success', 'موفق', 'عملیات با موفقیت انجام شد', false, 999);
            }
            else {
                iziTostGlobal('error', 'خطا', 'خطایی درسیستم به وجود امده است', false, 999);
            }
        },
        error: function (xhr) {
            console.log(xhr);
            ;
            iziTostGlobal('error', 'خطا', 'خطایی درسیستم به وجود امده است', false, 999);
        }
    })
}

function funThousandsSeparator(numberString) {
    numberString += '';
    var x = numberString.split('.');
    var x1 = x[0];
    var x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
}