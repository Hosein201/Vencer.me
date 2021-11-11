using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Interface;
using Microsoft.AspNetCore.Http;

namespace WebFramework
{
    public interface IFileManger: ITransientDependency
    {
        Task<string> GetImgPath(IFormFile file );
    }
}
