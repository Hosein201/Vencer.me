using Data.Dto.Business;
using Data.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IBioBusinessRepository : IRepository<BioBusiness>
    {
        Task<bool> EditDetailBusiness(EditDetailDto editDetail, string businessUrl, Guid userId, CancellationToken cancellationToken);
        Task<bool> EditGalleryAndVidoeBusiness(EditGalleryDto editGalleryDto, string businessUrl, Guid userId, CancellationToken cancellationToken);
        Task<bool> EditWorkHoursBusiness(EditWorkHoursDto editWorkHoursDto, string businessUrl, Guid userId, CancellationToken cancellationToken);
        Task<bool> EditLogoBusiness(EditLogoBusinessDto editLogoBusinessDto, string businessUrl, Guid userId, CancellationToken cancellationToken);
    }
}
