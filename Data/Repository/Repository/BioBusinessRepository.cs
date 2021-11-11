using Common.Interface;
using Data.Dto.Business;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BioBusinessRepository : Repository<BioBusiness>, IBioBusinessRepository, IScopedDependency
    {
        private VencerDbContext _context;
        public BioBusinessRepository(VencerDbContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> EditDetailBusiness(EditDetailDto editDetail, string businessUrl, Guid userId, CancellationToken cancellationToken)
        {
            var bioBusiness = await Table.FirstOrDefaultAsync(
                f => f.BusinessFull.BusinessUrl == businessUrl && f.BusinessFull.UserId == userId, cancellationToken);

            bioBusiness.Address = editDetail.Address;
            bioBusiness.Aparat = editDetail.Aparat;
            bioBusiness.BusinessManeger = editDetail.BusinessManeger;
            bioBusiness.NameBusiness = editDetail.NameBusiness;
            bioBusiness.Description = editDetail.Description;
            bioBusiness.Email = editDetail.Email;
            bioBusiness.FaxNumber = editDetail.FaxNumber;
            bioBusiness.HomeNumber = editDetail.HomeNumber;
            bioBusiness.Instagram = editDetail.Instagram;
            bioBusiness.Mobile = editDetail.Mobile;
            bioBusiness.TypeBusiness = editDetail.TypeBusiness;
            bioBusiness.WhatsApp = editDetail.WhatsApp;
            bioBusiness.Youtube = editDetail.Youtube;

            return true;
        }

        public async Task<bool> EditGalleryAndVidoeBusiness(EditGalleryDto editGalleryDto, string businessUrl, Guid userId, CancellationToken cancellationToken)
        {
            var bioBusiness = await Table.FirstOrDefaultAsync(
                f => f.BusinessFull.BusinessUrl == businessUrl && f.BusinessFull.UserId == userId, cancellationToken);

            if (string.IsNullOrEmpty(editGalleryDto.ImgGallery))
                bioBusiness.GalleryImg = editGalleryDto.ImgGallery;

            if (string.IsNullOrEmpty(editGalleryDto.PathVideo))
                bioBusiness.PathVideo = editGalleryDto.PathVideo;

            return true;
        }

        public async Task<bool> EditWorkHoursBusiness(EditWorkHoursDto editWorkHoursDto, string businessUrl, Guid userId, CancellationToken cancellationToken)
        {
            var bioBusiness = await Table.FirstOrDefaultAsync(
                f => f.BusinessFull.BusinessUrl == businessUrl && f.BusinessFull.UserId == userId, cancellationToken);

            if (string.IsNullOrEmpty(editWorkHoursDto.Clock))
                bioBusiness.Clock = editWorkHoursDto.Clock;

            return true;
        }

        public async Task<bool> EditLogoBusiness(EditLogoBusinessDto editLogoBusinessDto, string businessUrl, Guid userId, CancellationToken cancellationToken)
        {
            var bioBusiness = await Table.FirstOrDefaultAsync(
                f => f.BusinessFull.BusinessUrl == businessUrl && f.BusinessFull.UserId == userId, cancellationToken);

            if (string.IsNullOrEmpty(editLogoBusinessDto.PathLicense))
                bioBusiness.PathLicense = editLogoBusinessDto.PathLicense;

            if (string.IsNullOrEmpty(editLogoBusinessDto.PathLogoMax))
                bioBusiness.PathLogoMax = editLogoBusinessDto.PathLogoMax;


            if (string.IsNullOrEmpty(editLogoBusinessDto.PathLogoMini))
                bioBusiness.PathLogoMini = editLogoBusinessDto.PathLogoMini;

            return true;
        }
    }
}
