using System;
using AutoMapper;
using Common.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ServicePovider;
using System.Threading;
using System.Threading.Tasks;
using Data.Dto.Lookups;
using WebFramework.Permition;

namespace Vencer.me.Controllers.Api
{
    [Route("api/ApiLookups")]
    [ApiController, Authorize]
    public class ApiLookupsController : ControllerBase
    {
        private readonly IServiceLookup _serviceLookup;
        public ApiLookupsController(IServiceLookup serviceLookup,
            ILogger _logger, IMapper _mappers)
        {
            this._serviceLookup = serviceLookup;
        }

        [HttpGet(nameof(GetLookupsWithTypeAndAux)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetLookupsWithTypeAndAux([FromQuery] string Type, [FromQuery] string Aux1, CancellationToken cancellationToken)
        {
            var lookup = await _serviceLookup.GetLookupsWithTypeAndAux(Type, Aux1, cancellationToken);
            return Ok(lookup);
        }

        [HttpGet(nameof(GetLookupsWithType)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetLookupsWithType([FromQuery] string Type, CancellationToken cancellationToken)
        {
            var lookup = await _serviceLookup.GetLookupsWithType(Type, cancellationToken);
            return Ok(lookup);
        }

        [HttpGet(nameof(GetLookupById)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetLookupById([FromQuery]string id, CancellationToken cancellationToken)
        {
            var lookup = await _serviceLookup.GetLookupById( Guid.Parse(id), cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, lookup, "عملیات با موفقیت ایجاد شد."));
        }
    }
}