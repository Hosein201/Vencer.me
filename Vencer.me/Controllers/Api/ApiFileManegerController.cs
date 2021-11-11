using Common.Interface;
using Common.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework;
using WebFramework.Permition;

namespace Vencer.me.Controllers.Api
{
    [Route("api/ApiFileManeger")]
    [ApiController]
    public class ApiFileManegerController : ControllerBase
    {
        private IFileManger fileManger;
        private IJsonConvertCommon jsonConvert;

        public ApiFileManegerController(IFileManger _fileManger)
        {
            fileManger = _fileManger;
            jsonConvert = new JsonConvertCommon();
        }

        [HttpPost(nameof(CreateFile)), Permission(VencerPermission.AllUser)]
        public async Task<IActionResult> CreateFile(List<IFormFile> files)
        {
            if (files == null || !files.Any() || files.Count == 0)
                new AppException(ApiResultStatusCode.ListEmpty, "هیچ فایل برای ارسال وجود ندارد");
            Assert.NotNull(files, "formFile", "formFile is null");
            string path = await fileManger.GetImgPath(files[0]);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, path, "عملیات با موفقیت انجام شد"));
        }
    }
}