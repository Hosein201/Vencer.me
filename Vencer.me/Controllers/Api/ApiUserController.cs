using Common.Utilities;
using Data.Dto.User;
using Data.Model;
using Kendo.DynamicLinqCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServicePovider;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Permition;
using WebFramework.UserIdentityExtension;

namespace Vencer.me.Controllers.Api
{
    [Route("api/ApiUser")]
    [ApiController]
    public class ApiUserController : ControllerBase
    {
        private readonly IServiceUser _serviceUser;
        private readonly UserManager<User> _userManager;

        public ApiUserController(IServiceUser serviceUser, UserManager<User> userManager)
        {
            this._serviceUser = serviceUser;
            this._userManager = userManager;
        }

        [HttpGet(nameof(GetUser)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetUser()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, user, "عضویت با موفقیت ایجاد شد."));
        }

        [HttpGet(nameof(GetUsers)), Authorize, Permission(VencerPermission.AllUser)]
        public IActionResult GetUsers([FromForm] DataSourceRequest dataSourceRequest, CancellationToken cancellationToken)
        {
            var users = _serviceUser.GetUsers(dataSourceRequest);
            return Ok(users);
        }

        [HttpGet(nameof(GetUsersForTransaction)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetUsersForTransaction(CancellationToken cancellationToken)
        {
            var data = await _serviceUser.GetUsersForTransaction(User.Identity.GetUserId(), cancellationToken);
            return Ok(data);
        }

        [HttpGet(nameof(GetDataDashboard)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetDataDashboard(CancellationToken cancellationToken)
        {
            var data = await _serviceUser.GetDataDashboard(User.Identity.GetUserId(), cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عضویت با موفقیت ایجاد شد."));
        }

        [HttpGet(nameof(GetProfile)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetProfile(Guid userId, CancellationToken cancellationToken)
        {
            var data = await _serviceUser.GetProfile(User.Identity.GetUserId(), cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت ایجاد شد."));
        }

        [HttpPost(nameof(EditProfile)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> EditProfile([FromForm] ProfileDto dto, CancellationToken cancellationToken)
        {
            var data = await _serviceUser.EditProfile(dto, User.Identity.GetUserId(), cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت ایجاد شد."));
        }
    }
}