using Common.Utilities;
using Data.Dto.SupportExchanges;
using Kendo.DynamicLinqCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicePovider;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Permition;
using WebFramework.UserIdentityExtension;

namespace Vencer.me.Controllers.Api
{
    [Route("api/ApiTicketing")]
    [ApiController, Authorize]
    public class ApiTicketingController : ControllerBase
    {
        private readonly IServiceTicketing _serviceTicketing;
        public ApiTicketingController(IServiceTicketing serviceTicketing)
        {
            _serviceTicketing = serviceTicketing;
        }

        #region SupportExchanges
        [HttpGet(nameof(GetSupportExchanges)), Permission(VencerPermission.AllUser)]
        public IActionResult GetSupportExchanges([FromForm] DataSourceRequest dataSourceRequest)
        {
            var result = _serviceTicketing.GetSupportExchanges(dataSourceRequest);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, "عملیات با موفقیت انجام شد."));
        }

        [HttpGet(nameof(GetSupportExchangesUser)), Permission(VencerPermission.AllUser)]
        public IActionResult GetSupportExchangesUser([FromForm] DataSourceRequest dataSourceRequest)
        {
            var result = _serviceTicketing.GetSupportExchangesUser(dataSourceRequest, User.Identity.GetUserId());
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, "عملیات با موفقیت انجام شد."));
        }

        [HttpGet(nameof(GetSupportExchangesByState)), Permission(VencerPermission.AllUser)]
        public IActionResult GetSupportExchangesByState([FromForm] DataSourceRequest dataSourceRequest, [FromQuery] string state, CancellationToken cancellationToken)
        {
            Enum.TryParse(state, out SupportExchangesState supportExchangesState);
            var result = _serviceTicketing.GetSupportExchangesByState(dataSourceRequest, supportExchangesState, User.Identity.GetUserId(), cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, "عملیات با موفقیت انجام شد."));
        }

        [HttpPost(nameof(UpdateSupportExchanges)), Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> UpdateSupportExchanges([FromForm] UpdateSupportExchangesDto dto, CancellationToken cancellationToken)
        {
            Enum.TryParse(dto.State, out SupportExchangesState supportExchangesState);
            var result = await _serviceTicketing.UpdateSupportExchanges(supportExchangesState, dto.Description, dto.IdExchange, dto.UserId, cancellationToken);
            if (result)
                return Ok(new ApiResult(true, ApiResultStatusCode.Success, true, "عملیات با موفقیت انجام شد."));
            return Ok(new ApiResult(false, ApiResultStatusCode.Success, null, "عملیات با موفقیت انجام نشد."));

        }

        [HttpPost(nameof(CreateSupportExchanges)), Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> CreateSupportExchanges([FromForm] CreateSupportExchangesDto createSupportExchangesDto, CancellationToken cancellationToken)
        {
            var result = await _serviceTicketing.CreateSupportExchanges(createSupportExchangesDto, User.Identity.GetUserId(), cancellationToken);
            if (result)
                return Ok(new ApiResult(true, ApiResultStatusCode.Success, true, "عملیات با موفقیت انجام شد."));
            return Ok(new ApiResult(false, ApiResultStatusCode.Success, null, "عملیات با موفقیت انجام نشد."));
        }

        [HttpPost(nameof(ConfirmedFileSupportExchanges)), Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> ConfirmedFileSupportExchanges([FromForm] ConfirmedFileSupportExchangesDto dto, CancellationToken cancellationToken)
        {
            Enum.TryParse(dto.State, out SupportExchangesState supportExchangesState);
            var result = await _serviceTicketing.ConfirmedFileSupportExchanges(dto.IsConfirmed, supportExchangesState, dto.IdExchange, dto.UserId, cancellationToken);
            if (result)
                return Ok(new ApiResult(true, ApiResultStatusCode.Success, true, "عملیات با موفقیت انجام شد."));
            return Ok(new ApiResult(false, ApiResultStatusCode.Success, null, "عملیات با موفقیت انجام نشد."));
        }
        #endregion
    }
}
