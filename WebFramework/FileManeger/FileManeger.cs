using Common;
using Common.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebFramework
{
    public class FileManeger : IFileManger
    {
        public IConfiguration Configuration { get; }
        private readonly SiteSettings siteSettings;

        public FileManeger(IConfiguration _configuration)
        {
            Configuration = _configuration;
            siteSettings=Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }
        public async Task<string> GetImgPath(IFormFile file)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteImg(file);
            }

            throw new AppException(ApiResultStatusCode.LogicError, "Invalid image file");
        }
        #region WriteImg
        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return ExtensionFormatFile.GetImageFormat(fileBytes) != ImageFormat.unknown;
        }
        private async Task<string> WriteImg(IFormFile file)
        {
            string fileName = string.Empty;
            string path = string.Empty;
            string pathReturn = string.Empty;
            try
            {
                string extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension; //Create a new Name 
                                                                  //for the file due to security reasons.
                pathReturn = Path.Combine(fileName);
                // path = Path.Combine(@"E:\githup\Vencer.me\Vencer.me\wwwroot\imagesUsers", fileName);
                path = Path.Combine(siteSettings.UrlImage.Url, fileName);

                using (FileStream bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
            }
            catch (Exception e)
            {
                throw new AppException(ApiResultStatusCode.ServerError, e.Message);
            }

            return pathReturn;
        }

        #endregion
    }
}
