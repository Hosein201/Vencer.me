using Common;
using Common.Utilities;
using Data.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServicePovider;
using Services;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Permition;
using WebFramework.Sms;
using WebFramework.UserIdentityExtension;

namespace Vencer.me.Controllers.Api
{
    [Route("api/ApiAccount")]
    [ApiController]
    public class ApiAccountController : ControllerBase
    {

        private IServiceAccount serviceAccount;
        private IConfiguration Configuration { get; }
        private SiteSettings siteSettings;


        public ApiAccountController(IServiceAccount serviceAccount, IConfiguration Configuration)
        {
            this.serviceAccount = serviceAccount;
            this.Configuration = Configuration;
            this.siteSettings = Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        [HttpPost(nameof(Regsiter)), AllowAnonymous, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> Regsiter([FromForm] UserRegsiterDto regsiterDto,
            CancellationToken cancellationToken)
        {
            var reuslt = await serviceAccount.Regsiter(regsiterDto, cancellationToken);
            var mag =
                $"به سایت www.vencer.me خوش آمدید نام کاربری شما {regsiterDto.UserName} و پسورد شما {regsiterDto.Password}";
            PayamakPanel.SendSMS(regsiterDto.Mobile, mag);
            CookieCustom.SetCookie(HttpContext.Response.Cookies, reuslt);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, true, "عضویت با موفقیت ایجاد شد."));
        }

        [HttpPost(nameof(Login)), AllowAnonymous, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> Login([FromForm] UserLogin loginDto, CancellationToken cancellationToken)
        {
            var token = await serviceAccount.Login(loginDto, cancellationToken);
            CookieCustom.SetCookie(HttpContext.Response.Cookies, token);
            if (!loginDto.IsSite)
                return Ok(new ApiResult(true, ApiResultStatusCode.Success, token, "به ونسر خوش آمدید"));
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, null, "به ونسر خوش آمدید"));
        }

        [HttpPost(nameof(RegsiterInPanel)), AllowAnonymous, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> RegsiterInPanel([FromForm] UserRegsiterInPanelDto regsiterDto, CancellationToken cancellationToken)
        {
            regsiterDto.Amount = Convert.ToString(siteSettings.AmountToPay.Amount);
            var result = await serviceAccount.RegsiterInPanel(regsiterDto, siteSettings.CallbackURL.UriVerify, 
                siteSettings.SandBoxPayment.IsSandBox == "true" ? true : false, cancellationToken);

            var mag =
                $"به سایت www.vencer.me خوش آمدید نام کاربری شما {regsiterDto.UserName} و پسورد شما {regsiterDto.Password}";
            PayamakPanel.SendSMS(regsiterDto.Mobile, mag);
            CookieCustom.SetCookie(HttpContext.Response.Cookies, result.AccessToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result.Url, "عضویت با موفقیت ایجاد شد."));
  
        }

        [HttpPost(nameof(ChangePassword)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordDto changePassword,
            CancellationToken cancellationToken)
        {
            var result = await serviceAccount.ChangePassword(changePassword, User.Identity.Name, cancellationToken);
            if (result)
                return Ok(new ApiResult(true, ApiResultStatusCode.Success, null, "رمز عبور با موفقیت تغییر کرد"));
            return Ok(new ApiResult(false, ApiResultStatusCode.BadRequest, null,
                "مشکلی در تغییر پسورد به وجود امده است"));
        }

        [HttpPost(nameof(ForgetPassword)), AllowAnonymous, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> ForgetPassword([FromForm] ForgetPasswordDto forgetPasswordDto, CancellationToken cancellationToken)
        {
            var result = await serviceAccount.ForgetPassword(forgetPasswordDto, cancellationToken);
            if (result==string.Empty)
                return Ok(new ApiResult(false, ApiResultStatusCode.BadRequest, null, "مشکلی در تغییر پسورد به وجود امده است"));

            var mag = $"به سایت www.vencer.me خوش آمدید نام کاربری شما {forgetPasswordDto.UserName} و پسورد شما {forgetPasswordDto.Mobile}";
            PayamakPanel.SendSMS(result, mag);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, null, "رمز عبور با موفقیت تغییر کرد"));
        }

        [HttpGet(nameof(DeactivateUser)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> DeactivateUser(CancellationToken cancellationToken)
        {
            var result = await serviceAccount.DeactivateUser(User.Identity.GetUserId(), cancellationToken);
            if(!result)
                return Ok(new ApiResult(false, ApiResultStatusCode.BadRequest, null, "مشکلی در تغییر پسورد به وجود امده است"));

            var mag = $" کاربر گرامی{User.Identity.Name} به دلیل انصراف از پرداخت شما حساب کاربری شما معلق شده است";
            PayamakPanel.SendSMS(User.Identity.GetMobileUser(), mag);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, null, ""));
        }
    }
}
