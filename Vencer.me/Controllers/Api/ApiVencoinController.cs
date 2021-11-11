using System;
using Common.Utilities;
using Data.Dto.Vencoin;
using Kendo.DynamicLinqCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicePovider;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Permition;
using WebFramework.UserIdentityExtension;

namespace Vencer.me.Controllers.Api
{
    [Route("api/ApiVencoin")]
    [ApiController]
    public class ApiVencoinController : ControllerBase
    {
        private readonly IServiceVencoin _serviceVencore;
        public ApiVencoinController(IServiceVencoin serviceVencore)
        {
            _serviceVencore = serviceVencore;
        }

        #region Create
        [HttpPost(nameof(CreateVencoin)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> CreateVencoin([FromForm] CreateVencoinDto createVencoinDto, CancellationToken cancellationToken)
        {
            var result = await _serviceVencore.CreateVencoin(createVencoinDto, User.Identity.GetUserId(), cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, "عملیات با موفقیت انجام شد"));
        }
        #endregion

        #region User
        [HttpPost(nameof(CancelTransaction)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> CancelTransaction([FromForm] VencoinTransactionDto dto, CancellationToken cancellationToken)
        {
            var result = await _serviceVencore.CancelTransaction(dto, User.Identity.GetUserId(), cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, "عملیات با موفقیت انجام شد"));
        }

        [HttpGet(nameof(GetAllTransactionUser)), Authorize, Permission(VencerPermission.AllUser)]
        public IActionResult GetAllTransactionUser([FromForm] DataSourceRequest dataSourceRequest)
        {
            var result = _serviceVencore.GetAllTransactionUser(dataSourceRequest, User.Identity.GetUserId());
            return Ok(result);
        }
        #endregion

        #region Report

        [HttpGet(nameof(GetReportVencoinSaleGrid)), Authorize, Permission(VencerPermission.AllUser)]
        public IActionResult GetReportVencoinSaleGrid([FromForm] DataSourceRequest dataSourceRequest)
        {
            var result = _serviceVencore.GetReportVencoinSaleGrid(dataSourceRequest);
            return Ok(result);
        }
        [HttpGet(nameof(GetReportVencoinBuyGrid)), Authorize, Permission(VencerPermission.AllUser)]
        public IActionResult GetReportVencoinBuyGrid([FromForm] DataSourceRequest dataSourceRequest)
        {
            var result = _serviceVencore.GetReportVencoinBuyGrid(dataSourceRequest);
            return Ok(result);
        }

        [HttpGet(nameof(GetReportLineChart)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetReportLineChart(CancellationToken cancellationToken)
        {
            var result = await _serviceVencore.GetReportLineChart(cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, "عملیات با موفقیت انجام شد"));
        }

        [HttpGet(nameof(GetReporAreaChart)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetReporAreaChart(CancellationToken cancellationToken)
        {
            var result = await _serviceVencore.GetReporAreaChart(cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, "عملیات با موفقیت انجام شد"));
        }

        [HttpGet(nameof(GetReportColumnChart)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetReportColumnChart(CancellationToken cancellationToken)
        {
            var result = await _serviceVencore.GetReportColumnChart(cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, "عملیات با موفقیت انجام شد"));
        }

        [HttpGet(nameof(GetReportTicker)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetReportTicker(CancellationToken cancellationToken)
        {
            var result = await _serviceVencore.GetReportTicker(cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, "عملیات با موفقیت انجام شد"));
        }

        [HttpGet(nameof(GetVolumeVencoinOfUsers)), Authorize, Permission(VencerPermission.AllUser)]
        public IActionResult GetVolumeVencoinOfUsers([FromForm] DataSourceRequest dataSourceRequest,[FromQuery] string userId , CancellationToken cancellationToken)
        {
            var result =  _serviceVencore.GetVolumeVencoinOfUsers(dataSourceRequest,Guid.Parse(userId));
            return Ok(result);
        }
        #endregion

        [HttpGet(nameof(JobTransactionDailyVencoin)), AllowAnonymous, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> JobTransactionDailyVencoin()
        {
            var result = await _serviceVencore.JobTransactionDailyVencoin();
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, "عملیات با موفقیت انجام شد"));
        }
    }
}
