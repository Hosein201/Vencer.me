#pragma checksum "E:\githup\Vencerme\Vencer.me\Views\Business\Business.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8515ab5537eb5efe68ab2990c0e68f8b1da30097"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Business_Business), @"mvc.1.0.view", @"/Views/Business/Business.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8515ab5537eb5efe68ab2990c0e68f8b1da30097", @"/Views/Business/Business.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa51d1f44a53d1f5e4b4d512a78a04d457a9a881", @"/Views/_ViewImports.cshtml")]
    public class Views_Business_Business : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Business.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\githup\Vencerme\Vencer.me\Views\Business\Business.cshtml"
  
    Layout = "~/Views/Shared/_LayoutBusiness.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8515ab5537eb5efe68ab2990c0e68f8b1da300974882", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<!-- =======================header ===================== -->
<div class=""row"" style=""direction: ltr"">
    <div class=""col-xl-12"">
        <div class=""card button-card"">
            <div class=""card-body"">
                <section class=""page-title-banner"" id=""pathLogoMax"" style=""background-image:url(../../assets/images/profile/cover.jpg);"">
                    <div class=""container"" style=""text-align: left"">
                        <div class=""row m-0 align-items-end detail-swap"">
                            <div class=""tr-list-wrap"">
                                <div class=""tr-list-detail"">
                                    <div class=""tr-list-thumb"">
                                        <img src=""../../assets/images/profile/cover.jpg"" id=""pathLogoMini"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 906, "\"", 912, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""height: 100%"" />
                                    </div>
                                    <div class=""tr-list-info"">
                                        <h4 class=""veryfied-list"" id=""nameBusiness""></h4>
                                        <p id=""address""></p>
                                    </div>
                                </div>
                                <div class=""listing-detail_right"">
                                    <div class=""listing-detail-item"">
                                        <a href=""#"" class=""btn btn-list""><i class=""ti-heart""></i> دنبال کردن </a>
                                        <a id=""settingsBusiness"" class=""btn btn-list""><i class=""icon-settings""></i>ویرایش</a>
                                    </div>
                                    <div class=""listing-detail-item"" style=""display: none"">
                                        <div class=""share-opt-wrap"">
                                            <button type=""button"" class=""btn bt");
            WriteLiteral(@"n-list"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                <i class=""ti-share""></i> Share
                                            </button>
                                            <div class=""dropdown-menu animated flipInX"">
                                                <a href=""#"" class=""cl-facebook""><i class=""lni-facebook""></i></a>
                                                <a href=""#"" class=""cl-twitter""><i class=""lni-twitter""></i></a>
                                                <a href=""#"" class=""cl-gplus""><i class=""lni-google-plus""></i></a>
                                                <a href=""#"" class=""cl-instagram""><i class=""lni-instagram""></i></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
  ");
            WriteLiteral(@"              </section>
            </div>
        </div>
        <!-- ======================= Tabs ===================== -->
        <div class=""col-xl-12"">
            <div class=""card button-card border"" >
                <div class=""card-body"">
                    <div class=""profile-header-nav p-0 b-b"">

                        <div class=""row"">

                            <div class=""col-md-12 col-sm-12"">
                                <div class=""tab"" role=""tabpanel"">
                                    <!-- Nav tabs -->
                                    <ul class=""nav nav-tabs"" role=""tablist"">
                                        <li role=""presentation""><a href=""#Overview"" class=""active"" role=""tab"" data-toggle=""tab""><i class=""ti-user""></i>جزییات کسب وکار</a></li>
                                        <li role=""presentation""><a href=""#Photos"" role=""tab"" data-toggle=""tab""><i class=""ti-gallery""></i>گالری تصاویر</a></li>
                                    </ul>
                                 ");
            WriteLiteral(@"   <!-- Tab panes -->
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
        <!-- ============== Detail ====================== -->
        <div class=""row"">
            <div class=""col-lg-8 col-md-12 col-sm-12"">
                <div class=""card button-card border"">
                    <div class=""card-body"">
                        <div class=""tab-content tabs"">
                            <!-- ============ Overview =================== -->
                            <div role=""tabpanel"" class=""tab-pane fade in show active"" id=""Overview"" style=""height: 937px"">
                                <!-- Description -->
                                <div class=""row"">
                                    <div class=""tr-single-box"">
                                        <div class=""tr-single-body"">
                                            <h4>توضیحات</h4>
                ");
            WriteLiteral(@"                            <p id=""description""></p>
                                            <h4>ویدیو معرفی کسب و کار</h4>
                                            <div class=""h_iframe-aparat_embed_frame"">
                                                <span style=""display: block; padding-top: 57%""></span>
                                                <iframe src=""https://www.aparat.com/video/video/embed/videohash/LTI1X/vt/frame"" allowFullScreen=""true"" webkitallowfullscreen=""true"" mozallowfullscreen=""true"">
                                                </iframe>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- ============ Photos =================== -->
                            <div role=""tabpanel"" class=""tab-pane fade in"" id=""Photos"">

                                <!--  Photos -->
             ");
            WriteLiteral(@"                   <div class=""row"">
                                    <div class=""tr-single-box"">
                                        <div class=""tr-single-header"">
                                            <h4><i class=""ti-thumb-up""></i>عکس های کسب و کار</h4>
                                        </div>
                                        <div class=""tr-single-body"">
                                            <ul class=""gallery-list"">
                                                <li>

                                                    <img src=""../../assets/images/profile/cover.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 6666, "\"", 6672, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""height: 300px"">

                                                </li>
                                                <li>

                                                    <img src=""../../assets/images/profile/cover.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 6929, "\"", 6935, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""height: 300px"">

                                                </li>
                                                <li>

                                                    <img src=""../../assets/images/profile/cover.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 7192, "\"", 7198, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""height: 300px"">

                                                </li>
                                                <li>

                                                    <img src=""../../assets/images/profile/cover.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 7455, "\"", 7461, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""height: 300px"">

                                                </li>
                                                <li>

                                                    <img src=""../../assets/images/profile/cover.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 7718, "\"", 7724, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""height: 300px"">

                                                </li>
                                                <li>

                                                    <img src=""../../assets/images/profile/cover.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 7981, "\"", 7987, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""height: 300px"">

                                                </li>
                                                <li>

                                                    <img src=""../../assets/images/profile/cover.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 8244, "\"", 8250, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""height: 300px"">

                                                </li>
                                                <li>

                                                    <img src=""../../assets/images/profile/cover.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 8507, "\"", 8513, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""height: 300px"">

                                                </li>
                                                <li>

                                                    <img src=""../../assets/images/profile/cover.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 8770, "\"", 8776, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""height: 300px"">

                                                </li>

                                            </ul>


                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            
            <div class=""col-lg-4 col-md-12 col-sm-12"">
                <div class=""card button-card border"">
                    <div class=""card-body"">
                        <!-- Sidebar Start -->
                        <!-- Author Name -->
                        <div class=""author-box-wrapper mb-4"">
                            <div class=""author-box-body"">
                                <div class=""author-thumb"">
                                    <img id=""pathLogoMini2"" src=""../../assets/images/profile/cover.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 9726, "\"", 9732, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                </div>
                                <div class=""author-caption"">
                                    <h4 class=""author-name"" id=""nameBusiness2""><a href=""#"">asdasd</a></h4>
                                    <div class=""author-location"" id=""businessManeger"">asdasdas</div>
                                    <div class=""author-location"" id=""address2""><i class=""ti-location-pin""></i></div>
                                </div>
                            </div>
                            <div class=""author-box-footer"" style=""display: none"">
                                <ul>
                                    <li><span>Followers</span>2015</li>
                                    <li><span>Following</span>2015</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>

                <div class=""card button-card border"">
                    <div class=""card-body "">
      ");
            WriteLiteral(@"                  <!-- Business Info -->
                        <div class=""tr-single-box"">
                            <div class=""tr-single-header"">
                                <h4><i class=""ti-direction""></i>مشخصات کسب و کار</h4>
                            </div>

                            <div class=""tr-single-body"">
                                <ul class=""extra-service"">
                                    <li>
                                        <div class=""icon-box-icon-block"">
                                            <a href=""#"">
                                                <h6>تلفن همراه</h6>
                                                <div class=""icon-box-text"" id=""mobile"">
                                                </div>
                                            </a>
                                        </div>
                                    </li>

                                    <li>
                                        <div class=""icon-box-icon-block");
            WriteLiteral(@""">
                                            <a href=""#"">
                                           <h6>تلفن ثابت</h6>
                                                <div class=""icon-box-text"" id=""homeNumber"">
                                                </div>
                                            </a>
                                        </div>
                                    </li>  
                                    <li>
                                        <div class=""icon-box-icon-block"">
                                            <a href=""#"">
                                            <h6>تلفن فکس</h6>
                                                <div class=""icon-box-text"" id=""faxNumber"">
                                                </div>
                                            </a>
                                        </div>
                                    </li>

                                    <li>
                                        <div class=""ico");
            WriteLiteral(@"n-box-icon-block"">
                                            <a href=""#"">
                                          <h6>ایمیل</h6>

                                                <div class=""icon-box-text"" id=""email"">
                                                  
                                                </div>
                                            </a>
                                        </div>
                                    </li>

                                    <li>
                                        <div class=""icon-box-icon-block"">
                                            <a href=""#"">
                                            <h6>آپارات</h6>

                                                <div class=""icon-box-text"" id=""aparat"">
                                            
                                                </div>
                                            </a>
                                        </div>
                                    </li>");
            WriteLiteral(@" 
                                    <li>
                                        <div class=""icon-box-icon-block"">
                                            <a href=""#"">
                                            <h6>اینستاگرام</h6>

                                                <div class=""icon-box-text"" id=""instagram"">
                                                   
                                                </div>
                                            </a>
                                        </div>
                                    </li> 
                                    <li>
                                        <div class=""icon-box-icon-block"">
                                            <a href=""#"">
                                           <h6>یوتیوب</h6>

                                                <div class=""icon-box-text"" id=""youtube"">
                                                
                                                </div>
                       ");
            WriteLiteral(@"                     </a>
                                        </div>
                                    </li>  <li>
                                        <div class=""icon-box-icon-block"">
                                            <a href=""#"">
                                                
                                                <h6>واتساپ</h6>

                                                <div class=""icon-box-text"" id=""whatsApp"">
                                                   
                                                </div>
                                            </a>
                                        </div>
                                    </li>

                                </ul>
                            </div>

                        </div>
                    </div>
                </div>

                <div class=""card button-card border"">
                    <div class=""card-body"">
                        <!-- Listing Hour Detail -->
               ");
            WriteLiteral(@"         <div class=""tr-single-box"">
                            <div class=""tr-single-header listing-hours-header open"">
                                <h4>ساعت کاری </h4>
                            </div>
                            <div class=""tr-single-body"">
                                <ul class=""listing-hour-day"">
                                    <li>
                                        <span class=""listing-hour-day"">شنبه</span>
                                        <span class=""listing-hour-time"" id=""input1""></span>
                                    </li>
                                    <li>
                                        <span class=""listing-hour-day"">یک شنبه</span>
                                        <span class=""listing-hour-time"" id=""input2""></span>
                                    </li>
                                    <li>
                                        <span class=""listing-hour-day"">دوشنبه</span>
                                        <span class");
            WriteLiteral(@"=""listing-hour-time"" id=""input3""></span>
                                    </li>
                                    <li>
                                        <span class=""listing-hour-day"">سه شنبه</span>
                                        <span class=""listing-hour-time"" id=""input4""></span>
                                    </li>
                                    <li>
                                        <span class=""listing-hour-day"">چهار شنبه</span>
                                        <span class=""listing-hour-time"" id=""input5""></span>
                                    </li>
                                    <li>
                                        <span class=""listing-hour-day"">پنج شنبه</span>
                                        <span class=""listing-hour-time"" id=""input6""></span>
                                    </li>
                                    <li>
                                        <span class=""listing-hour-day"">جمعه</span>
                               ");
            WriteLiteral(@"         <span class=""listing-hour-time"" id=""input7""></span>
                                    </li>

                                </ul>
                            </div>

                        </div>



                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


<script>
    var urlHeader = '");
#nullable restore
#line 350 "E:\githup\Vencerme\Vencer.me\Views\Business\Business.cshtml"
                Write(Html.Raw(ViewBag.url));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
    debugger;
    if (urlHeader === 'Swagger' || urlHeader === ""swagger"") {
        window.location.href = '/swagger/index.html';

    } else if (urlHeader == '' || urlHeader==null) {
        window.location.href = '/home/NotFoundPage';
    }
    $.ajax({
        url: 'api/ApiBusiness/GetBusiness?urlBusiness=' + urlHeader+'',
        type: 'GET',
        success: function (response) {
            if (response.isSuccess) {
                var data = response.data;
                if (data == null) {
                    window.location.href = '/home/NotFoundPage';
                }
                $('#nameBusiness').html(data.nameBusiness);
                $('#nameBusiness2').html(data.nameBusiness);
                $('#address').html(data.address);
                $('#address2').html(data.address);
                $('#description').html(data.description);
                $('#businessManeger').html(data.businessManeger);
                $('#mobile').html(data.mobile);
                $('#homeNumber').html(da");
            WriteLiteral(@"ta.homeNumber);
                $('#faxNumber').html(data.faxNumber);
                $('#email').html(data.email);
                $('#aparat').html(data.aparat);
                $('#instagram').html(data.instagram);
                $('#youtube').html(data.youtube);
                $('#whatsApp').html(data.whatsApp);
                var clock = JSON.parse(data.clock);
                $('#input1').html(clock[0].input1 + '_' + clock[1].input2);
                $('#input2').html(clock[2].input3 + '_' + clock[3].input4);
                $('#input3').html(clock[4].input5 + '_' + clock[5].input6);
                $('#input4').html(clock[6].input7 + '_' + clock[7].input8);
                $('#input5').html(clock[8].input9 + '_' + clock[9].input10);
                $('#input6').html(clock[10].input11 + '_' + clock[11].input12);
                $('#input7').html(clock[12].input13 + '_' + clock[13].input14);
                $('#pathLogoMax').css('background-image', 'url(/imagesUsers/' + data.pathLogoMax + ')');
      ");
            WriteLiteral(@"          $('#pathLogoMini').attr('src', '/imagesUsers/' + data.pathLogoMini)
                $('#pathLogoMini2').attr('src', '/imagesUsers/' + data.pathLogoMini)
            }
        },
        error: function (xhr) {
            window.location.href = '/home/NotFoundPage';
        }
    });
    $('#settingsBusiness').click(function () {
        var urlPage = window.location.href.split('/')[3];
        window.location = '/EditBusiness/' + urlPage + '';
    });
</script>");
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
