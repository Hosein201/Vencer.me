using Common.Utilities;
using Data.Dto.Permition;
using Kendo.DynamicLinqCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicePovider;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Permition;

namespace Vencer.me.Controllers.Api
{
    [Route("api/ApiPermition")]
    [ApiController]
    public class ApiPermitionController : ControllerBase
    {

        private readonly IServicePermition servicePermition;
        public ApiPermitionController(IServicePermition servicePermition)
        {
            this.servicePermition = servicePermition;
        }

        [HttpGet(nameof(GetUserOfPermition)), Authorize, Permission(VencerPermission.AllUser)]
        public IActionResult GetUserOfPermition([FromForm] DataSourceRequest dataSourceRequest, [FromQuery] string roleName, CancellationToken cancellationToken)
        {
            var result = servicePermition.GetUserOfPermition(dataSourceRequest, roleName, cancellationToken);
            return Ok(result);
        }

        [HttpGet(nameof(GetPermitions)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetPermitions(CancellationToken cancellationToken)
        {
            var result = await servicePermition.GetPermitions(cancellationToken);
            return Ok(result);
        }

        [HttpPost(nameof(CreatePermitions)), AllowAnonymous, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> CreatePermitions(CancellationToken cancellationToken)
        {
            var result = await servicePermition.CreatePermitions(cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, "پرمیشن با موفقیت ایجاد شد."));
        }


        [HttpPost(nameof(AddUserToRole)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> AddUserToRole([FromForm] AddOrUpdatePermitionDto dto, CancellationToken cancellationToken)
        {
            Enum.TryParse(dto.RoleName, out VencerPermission roleName);
            var result = await servicePermition.AddUserToRole(dto.UserName, roleName);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, "پرمیشن با موفقیت ایجاد شد."));
        }

        [HttpPost(nameof(RemoveUserToRole)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> RemoveUserToRole([FromForm] AddOrUpdatePermitionDto dto, CancellationToken cancellationToken)
        {
            Enum.TryParse(dto.RoleName, out VencerPermission roleName);
            var result = await servicePermition.RemoveUserToRole(dto.UserName, roleName);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, "پرمیشن با موفقیت ایجاد شد."));
        }
    }
}