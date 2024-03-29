#pragma checksum "E:\githup\Vencerme\Vencer.me\Views\Permition\ManegmentUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a21e6fb22d08c95f75158a6d9dc520b6baa81681"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Permition_ManegmentUsers), @"mvc.1.0.view", @"/Views/Permition/ManegmentUsers.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\githup\Vencerme\Vencer.me\Views\_ViewImports.cshtml"
using Vencer.me;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\githup\Vencerme\Vencer.me\Views\_ViewImports.cshtml"
using Data.Dto.User;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\githup\Vencerme\Vencer.me\Views\_ViewImports.cshtml"
using Data.Dto.Customer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\githup\Vencerme\Vencer.me\Views\_ViewImports.cshtml"
using Data.Dto.Business;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\githup\Vencerme\Vencer.me\Views\_ViewImports.cshtml"
using Data.Dto.Payment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\githup\Vencerme\Vencer.me\Views\_ViewImports.cshtml"
using Data.Dto.Permition;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\githup\Vencerme\Vencer.me\Views\_ViewImports.cshtml"
using Data.Dto.SupportExchanges;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\githup\Vencerme\Vencer.me\Views\_ViewImports.cshtml"
using Data.Dto.Vencoin;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a21e6fb22d08c95f75158a6d9dc520b6baa81681", @"/Views/Permition/ManegmentUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa51d1f44a53d1f5e4b4d512a78a04d457a9a881", @"/Views/_ViewImports.cshtml")]
    public class Views_Permition_ManegmentUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\githup\Vencerme\Vencer.me\Views\Permition\ManegmentUsers.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .customeClass {
        text-align: right;
        float: right;
    }

    .customeBtn {
        margin-top: 43px;
        float: right;
    }
</style>
<div class=""row page-titles"">
    <div class=""col p-md-0"">
        <h4>مدیریت دسترسی های کاربران</h4>
    </div>
</div>
<div class=""row"">
    <div class=""col-xl-12"">
        <div class=""card button-card"">
            <div class=""card-body"">
                <div style=""display: block"" id=""Permitions""></div>
            </div>
        </div>
        <div class=""card button-card"">
            <div class=""card-body"">
                <div id=""gridPermitionUsers"" class=""k-rtl"">

                </div>
            </div>
        </div>
        <input id=""textkendoDropDownList"" style=""display: none""/>
    </div>
</div>

<script>
    $(function ($) {
        gridPermitionUsers('Customer');
        var dataSource = [{ 'name': 'Admin', 'text': 'مدیر سایت' }, { 'name': 'AllUser', 'text': 'کاربر عادی' },
        { 'name': 'MasterBusiness', 'text': 'مدیر کسب وک");
            WriteLiteral(@"ار' }, { 'name': 'Customer', 'text': 'مشتری' }, { 'name': 'Employe', 'text': 'کارمندها' }];
        $(""#Permitions"").kendoDropDownList({
            optionLabel: 'انتخاب کنید',
            dataTextField: ""text"",
            dataValueField: ""name"",
            dataSource: {
                data: dataSource
            },
            select: function (e) {
                gridPermitionUsers(e.dataItem.name);
                e.sender.close();
            }
        });
        function gridPermitionUsers(value) {
            $(""#gridPermitionUsers"").kendoGrid({
                dataSource: {
                    type: (function () {
                        if (kendo.data.transports[""aspnetmvc-ajax""]) {
                            return ""aspnetmvc-ajax""
                        } else {
                            throw new Error('The kendo.aspnetmvc.min.js script is not included.')
                        }
                    }),
                    transport: {
                        read: {
                    ");
            WriteLiteral(@"        url: ""/api/ApiPermition/GetUserOfPermition?roleName="" + value + """",
                            headers: { 'Authorization': 'Bearer ' + getCookie('Bearer') }
                        }
                    },
                    pageSize: 20,
                    serverPage: true,
                    schema: {
                        data: ""data"",
                        total: ""total""
                    },
                    serverFiltering: true,
                    serverSorting: true,
                    ""filter"": []
                },
                height: 550,
                groupable: true,
                sortable: true,
                pageable: {
                    pageSizes: true,
                    buttonCount: 5
                },
                columns: [
                    { field: ""Row"", title: ""ردیف"", width: ""60px"" },
                    { field: ""fullName"", title: ""نام خانوادگی"", width: ""100px"" },
                    { field: ""userName"", title: ""نام کاربری"", width: ""100px"" },
 ");
            WriteLiteral(@"                   { field: ""email"", title: ""ایمیل"", width: ""200px"" },
                    { field: ""phoneNumber"", title: ""تلفن همراه"", width: ""100px"" },
                    {
                        template: ""#: templateFunction(data.registerDate ) # "",
                        field: ""registerDate"",
                        title: ""تاریخ عضویت"",
                        width: 150
                    }, {
                        field: """",
                        title: ""عملیات"",
                        width: 200,
                        template:
                            '<div style=""display: block"" class=""dropDownTemplate""></div>' +
                            '<button onclick=""btnDone(this)""  name=#:data.userName#  style=""margin-right: 10px;"" class=""btn btn-info btn-ft btn-sm btn-rounded"">تایید</button>'
                    }
                ],
                dataBinding: function (a) {
                    var row = 0;
                    a.items.forEach(function (value) {
                        row+");
            WriteLiteral(@"+;
                        value.Row = ((a.sender.dataSource.page() - 1) * a.sender.dataSource.pageSize()) + row
                    });
                },
                dataBound: function (e) {
                    var items = e.sender.items();
                    items.each(function (e) {
                        var ddt = $(this).find('.dropDownTemplate');
                        $(ddt).kendoDropDownList({
                            optionLabel: 'انتخاب کنید',
                            dataSource: dataSource,
                            dataTextField: ""text"",
                            dataValueField: ""name"",
                            select: function (e) {
                                $('#textkendoDropDownList').val(e.dataItem.name);
                                e.sender.close();
                            }
                        });
                    });
                }
            });

        }
    });
    function templateFunction(value) {
        value.toString();
        var data");
            WriteLiteral(@" = new Date(value).toLocaleDateString('fa-IR');
        var time = new Date(value).toLocaleTimeString('fa-IR');
        return time + ' ' + data
    }
    function btnDone(e) {
        $(e).attr('disabled', true); 
        $.ajax({
            url: '/api/ApiPermition/AddUserToRole',
            type: 'Post',
            headers: { 'Authorization': 'Bearer ' + getCookie('Bearer') },
            data: {
                UserName: e.name,
                RoleName: $('#textkendoDropDownList').val(),
            },
            success: function (response) {
                console.log(response);
                if (response.isSuccess) {
                    gritterNotification('success', 'موفق', response.message);
                }
                else {
                    $(e).attr('disabled', false); 
                    gritterNotification('error', 'خطا', response.message);
                }
            },
            error: function (xhr) {
                $(e).attr('disabled', false);
                console.l");
            WriteLiteral("og(xhr);\n                gritterNotification(\'error\', xhr.responseJSON.Message);\n            }\n        });\n    }\n</script>\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
