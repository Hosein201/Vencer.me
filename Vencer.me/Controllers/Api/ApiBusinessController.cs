using Common;
using Common.Interface;
using Common.Utilities;
using Data.Dto.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServicePovider;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Permition;
using WebFramework.UserIdentityExtension;

namespace Vencer.me.Controllers.Api
{
    [Route("api/ApiBusiness")]
    [ApiController]
    public class ApiBusinessController : ControllerBase
    {
        private readonly IServiceBusiness _serviceBusiness;
        private readonly IElasticSearchRepository _elasticSearchRepository;
        private IConfiguration Configuration { get; }
        private SiteSettings siteSettings;

        public ApiBusinessController(IServiceBusiness serviceBusiness, IElasticSearchRepository elasticSearchRepository,
            IConfiguration configuration)
        {
            _serviceBusiness = serviceBusiness;
            _elasticSearchRepository = elasticSearchRepository;
            Configuration = configuration;
            this.siteSettings = Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        #region CreateBusiness

        [HttpPost(nameof(CreateBusiness)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> CreateBusiness([FromForm] CreateBioBusinessDto createBusinessDto, CancellationToken cancellationToken)
        {

            var data = await _serviceBusiness.CreateBusiness(createBusinessDto, User.Identity.GetUserId(),
                siteSettings.AmountToPay.Amount, cancellationToken);
            // bool result = await _elasticSearchRepository.CreateElasticBusiness(data, cancellationToken); // elastic search 
            //   if (result)
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت انجام شد"));
            //  return Ok(new ApiResult(false, ApiResultStatusCode.BadRequest, null, "مشکلی در سیستم به وجود امده است"));
        }
        #endregion

        #region EditBuiness

        [HttpPost(nameof(EditDetailBusiness)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> EditDetailBusiness([FromForm] EditDetailDto createBusinessDto,[FromForm]string businessUrl, CancellationToken cancellationToken)
        {
            var data = await _serviceBusiness.EditDetailBusiness(createBusinessDto, businessUrl, User.Identity.GetUserId(), cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت انجام شد"));
        }

        [HttpPost(nameof(EditGalleryAndVidoeBusiness)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> EditGalleryAndVidoeBusiness([FromForm] EditGalleryDto createBusinessDto, [FromForm] string businessUrl, CancellationToken cancellationToken)
        {
            var data = await _serviceBusiness.EditGalleryAndVidoeBusiness(createBusinessDto, businessUrl, User.Identity.GetUserId(), cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت انجام شد"));
        } 
        
        [HttpPost(nameof(EditWorkHoursBusiness)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> EditWorkHoursBusiness([FromForm] EditWorkHoursDto createBusinessDto, [FromForm] string businessUrl, CancellationToken cancellationToken)
        {
            var data = await _serviceBusiness.EditWorkHoursBusiness(createBusinessDto, businessUrl, User.Identity.GetUserId(), cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت انجام شد"));
        } 
        
        [HttpPost(nameof(EditLogoBusiness)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> EditLogoBusiness([FromForm] EditLogoBusinessDto createBusinessDto,[FromForm] string businessUrl, CancellationToken cancellationToken)
        {
            var data = await _serviceBusiness.EditLogoBusiness(createBusinessDto, businessUrl,User.Identity.GetUserId(), cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت انجام شد"));
        }

        #endregion

        #region GetBusiness

        [HttpGet(nameof(GetListBusinessUser)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetListBusinessUser(CancellationToken cancellationToken)
        {
            List<ListBusinessDto> data = await _serviceBusiness.GetListBusinessUser(User.Identity.GetUserId(), cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت انجام شد"));
        } 
        
        [HttpGet(nameof(GetListBusiness)), Authorize, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetListBusiness(CancellationToken cancellationToken)
        {
            List<ListBusinessDto> data = await _serviceBusiness.GetListBusiness( cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت انجام شد"));
        }

        [HttpGet(nameof(GetBusiness)), AllowAnonymous, Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> GetBusiness([FromQuery] string urlBusiness, CancellationToken cancellationToken)
        {
            var data = await _serviceBusiness.GetBusiness(urlBusiness, cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, data, "عملیات با موفقیت انجام شد"));
        }
        #endregion
    }
}