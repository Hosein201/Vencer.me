using Common;
using Common.CommonModel;
using Common.Interface;
using Common.Utilities;
using Data.Dto.Payment;
using Kendo.DynamicLinqCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using ServicePovider;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebFramework;
using WebFramework.Permition;
using WebFramework.UserIdentityExtension;

namespace Vencer.me.Controllers.Api
{
    [Route("api/ApiPayment")]
    [ApiController]
    public class ApiPaymentController : ControllerBase
    {
        private IServicePayment  servicePayment;
        private IConfiguration Configuration { get; }
        private SiteSettings siteSettings;
        public ApiPaymentController(IServicePayment servicePayment, IRequestToPay _paymentPay, IConfiguration Configuration)
        {
            this.servicePayment = servicePayment;
            this.Configuration = Configuration;
            this.siteSettings = Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
           
        }

        #region RequestToPay
        [HttpPost(nameof(RequestToPay)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> RequestToPay([FromForm] AddPaymentDto requestToPayDto, CancellationToken cancellationToken)
        {

           var data = await servicePayment.RequestToPayAndAddPayment( requestToPayDto, siteSettings.CallbackURL.UriVerify
            , User.Identity.GetUserId(),siteSettings.SandBoxPayment.IsSandBox == "true" ?true : false , cancellationToken);
             return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت انجام شد"));
        }

        [HttpGet(nameof(VerifyToPay)), Authorize , Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> VerifyToPay(CancellationToken cancellationToken)
        {
            var data = await servicePayment.VerifyToPayAndUpdatePayment(User.Identity.GetUserId(), siteSettings.SandBoxPayment.IsSandBox == "true" ? true : false, cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت انجام شد"));
        }
        #endregion

        #region Reports

        [HttpGet(nameof(GetAllPayment)), Authorize , Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetAllPayment([FromForm] DataSourceRequest dataSourceRequest, CancellationToken cancellationToken)
        {    
            var data =  servicePayment.GetAllPayment(dataSourceRequest);
            return Ok(data);
        }

        [HttpGet(nameof(GetPaymentByUser)), Authorize , Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetPaymentByUser([FromForm] DataSourceRequest dataSourceRequest, CancellationToken cancellationToken)
        {
            var data =  servicePayment.GetPaymentByUser(dataSourceRequest, User.Identity.GetUserId());
            return Ok(data);
        }

        [HttpPost(nameof(GetPaymentByMoblie)), Authorize , Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetPaymentByMoblie(DataSourceRequest dataSourceRequest, string Moblie , CancellationToken cancellationToken)
        {
            var data =  servicePayment.GetPaymentByMoblie(dataSourceRequest, Moblie);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت انجام شد"));
        }

        [HttpGet(nameof(GetSumAmountUserWithOutDiscount)), Authorize , Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetSumAmountUserWithOutDiscount(CancellationToken cancellationToken)
        {
            var data =  servicePayment.GetSumAmountUserWithOutDiscount(User.Identity.GetUserId());
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت انجام شد"));
        }

        [HttpGet(nameof(GetSumAmountUserWithDiscount)), Authorize , Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetSumAmountUserWithDiscount(CancellationToken cancellationToken)
        {
            var data =  servicePayment.GetSumAmountUserWithDiscount(User.Identity.GetUserId());
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت انجام شد"));
        }
        #endregion

        #region Increase 
        [HttpPost(nameof(DiscountPayment)), Authorize , Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> DiscountPayment([FromForm]DiscountDto increaseAndDecrease , CancellationToken cancellationToken)
        {
            var data = await servicePayment.DiscountPayment(increaseAndDecrease, cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, null, "عملیات با موفقیت انجام شد"));
        }

        [HttpPost(nameof(TransactionBetweenUser)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> TransactionBetweenUser([FromForm]TransactionDto  transactionDto, CancellationToken cancellationToken)
        {
            var data = await servicePayment.TransactionBetweenUser(transactionDto,User.Identity.GetUserId(), cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, null, "عملیات با موفقیت انجام شد"));
        }
        #endregion

        #region Decrease
        [HttpPost(nameof(DecreasePayment)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> DecreasePayment([FromForm] DiscountDto increaseAndDecrease, CancellationToken cancellationToken)
        {
            var data = await servicePayment.DiscountPayment(increaseAndDecrease, cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, null, "عملیات با موفقیت انجام شد"));
        }
        #endregion
    }
}
