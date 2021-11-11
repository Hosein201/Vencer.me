using Common.CommonModel;
using Common.Interface;
using Data.Dto.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServicePovider
{
    public interface IServiceBusiness : ITransientDependency
    {
        Task<bool> CreateBusinessAndForRegsiter(string UserName, string businessUrl, string NameBusiness, string BusinessManeger, CancellationToken cancellationToken);
        Task<QueryBusinessDto> CreateBusiness(CreateBioBusinessDto createBusinessDto, Guid userId, double amount, CancellationToken cancellationToken);
        Task<List<ListBusinessDto>> GetListBusinessUser(Guid userId, CancellationToken cancellationToken);
        Task<List<ListBusinessDto>> GetListBusiness(CancellationToken cancellationToken);
        Task<BusinessDto> GetBusiness(string businessUrl, CancellationToken cancellationToken);
        Task<BusinessDto> GetBioBusiness(string businessUrl, CancellationToken cancellationToken);
        int GetCountBusinessFull(Guid userId, CancellationToken cancellationToken);
        Task<bool> EditDetailBusiness(EditDetailDto editDetail, string businessUrl, Guid userId, CancellationToken cancellationToken);
        Task<bool> EditGalleryAndVidoeBusiness(EditGalleryDto editGalleryDto, string businessUrl, Guid userId, CancellationToken cancellationToken);
        Task<bool> EditWorkHoursBusiness(EditWorkHoursDto editWorkHoursDto, string businessUrl, Guid userId, CancellationToken cancellationToken);
        Task<bool> EditLogoBusiness(EditLogoBusinessDto editLogoBusinessDto, string businessUrl, Guid userId, CancellationToken cancellationToken);
    }
}
