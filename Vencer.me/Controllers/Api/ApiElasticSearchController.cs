using Common.CommonModel;
using Common.Interface;
using Common.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Permition;

namespace Vencer.me.Controllers.Api
{
    [Route("api/ApiElasticSearch")]
    [ApiController]
    public class ApiElasticSearchController : ControllerBase
    {
        private IElasticSearchRepository ElasticSearchRepository;
        private IJsonConvertCommon jsonConvert;

        public ApiElasticSearchController(IElasticSearchRepository _ElasticSearchRepository)
        {
            ElasticSearchRepository = _ElasticSearchRepository;
            jsonConvert = new JsonConvertCommon();
        }

        [HttpPost(nameof(GetSearch)), AllowAnonymous, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetSearch([FromForm] DtoSearch dtoSearch, CancellationToken cancellationToken)
        {
            ModelSearchReturnData data = await ElasticSearchRepository.SearchElasticBusiness(dtoSearch.Query, cancellationToken, dtoSearch.Take, dtoSearch.Skip);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت انجام شد"));
        }

        [HttpPost(nameof(CreateElasticSearch)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> CreateElasticSearch([FromForm] QueryBusinessDto queryBusinessDto, CancellationToken cancellationToken)
        {
            var result = await ElasticSearchRepository.CreateElasticBusiness(queryBusinessDto, cancellationToken);
            if (result)
                return Ok(new ApiResult(true, ApiResultStatusCode.Success, null, "عملیات با موفقیت انجام شد"));
            return Ok(new ApiResult(false, ApiResultStatusCode.BadRequest, null, "مشکلی در سیستم به وجود امده است"));

        }
    }
}