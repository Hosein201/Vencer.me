using Common.CommonModel;
using Common.Interface;
using Common.Utilities;
using Data.Dto.Business;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BusinessFullRepository : Repository<BusinessFull>, IBusinessFullRepository, IScopedDependency
    {
        private VencerDbContext _dbContext;
        private IJsonConvertCommon jsonConvert;
        public BusinessFullRepository(VencerDbContext dbContext)
            : base(dbContext)
        {
            this._dbContext = dbContext;
            jsonConvert = new JsonConvertCommon();
        }
        public async Task<bool> CreateBusinessAndForRegsiter(string userName,string businessUrl, string nameBusiness, string businessManeger, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(f => f.UserName == userName, cancellationToken);

            BusinessFull businessFull = new BusinessFull()
            {
                UserId = user.Id,
                BusinessUrl = businessUrl,
            };
            BioBusiness bioBusiness = new BioBusiness()
            {
                Clock = string.Empty,
                Description = string.Empty,
                BusinessManeger = businessManeger,
                TypeBusiness = string.Empty,
                PathLicense = "~/placeholderImage.jpg",
                PathLogoMax = "~/profile-cover.jpg",
                PathVideo = string.Empty,
                NameBusiness = nameBusiness,
                BusinessFullId = businessFull.Id
            };

            await _dbContext.AddAsync(businessFull, cancellationToken);
            await _dbContext.AddAsync(bioBusiness, cancellationToken);

            return true;
        }

        public async Task<QueryBusinessDto> CreateBusiness(CreateBioBusinessDto createBusinessDto, Guid userId, CancellationToken cancellationToken)
        {
            BusinessFull businessFull = new BusinessFull()
            {
                UserId = userId,
                BusinessUrl = createBusinessDto.BusinessUrl
            };

            BioBusiness bioBusiness = new BioBusiness()
            {
                Clock = createBusinessDto.Clock,
                Description = createBusinessDto.Description,
                BusinessManeger = createBusinessDto.BusinessManeger,
                TypeBusiness = createBusinessDto.TypeBusiness,
                PathLicense = string.IsNullOrEmpty(createBusinessDto.PathLicense) ? "~/placeholderImage.jpg" : createBusinessDto.PathLicense,
                PathLogoMax = string.IsNullOrEmpty(createBusinessDto.PathLogoMax) ? "~/profile-cover.jpg" : createBusinessDto.PathLogoMax,
                PathVideo = createBusinessDto.PathVideo,
                NameBusiness = createBusinessDto.NameBusiness,
                PathLogoMini = string.IsNullOrEmpty(createBusinessDto.PathLogoMini) ? "~/placeholderImage.jpg" : createBusinessDto.PathLogoMini,
                Address = createBusinessDto.Address,
                Aparat = createBusinessDto.Aparat,
                Email = createBusinessDto.Email,
                FaxNumber = createBusinessDto.FaxNumber,
                HomeNumber = createBusinessDto.HomeNumber,
                Instagram = createBusinessDto.Instagram,
                Mobile = createBusinessDto.Mobile,
                WhatsApp = createBusinessDto.WhatsApp,
                Youtube = createBusinessDto.Youtube,
                GalleryImg = string.Empty,
                BusinessFullId = businessFull.Id

            };

         

            await _dbContext.AddAsync(bioBusiness, cancellationToken);
            await _dbContext.AddAsync(businessFull, cancellationToken);
            string st = jsonConvert.SerializeObject(createBusinessDto);
            return jsonConvert.DeserializeObject<QueryBusinessDto>(st);
        }

        public async Task<BusinessDto> GetBusiness(string businessUrl, CancellationToken cancellationToken)
        {
            var result = await TableNoTracking.Where(f => f.BusinessUrl == businessUrl)
                   .Select(s => new BusinessDto
                   {
                       BusinessUrl = s.BusinessUrl,
                       PathLogoMax = s.Bio‌Business.PathLogoMax,
                       PathLogoMini = s.Bio‌Business.PathLogoMini,
                       PathLicense = s.Bio‌Business.PathLicense,
                       PathVideo = s.Bio‌Business.PathVideo,
                       NameBusiness = s.Bio‌Business.NameBusiness,
                       BusinessManeger = s.Bio‌Business.BusinessManeger,
                       TypeBusines = s.Bio‌Business.TypeBusiness,
                       Description = s.Bio‌Business.Description,
                       Clock = s.Bio‌Business.Clock,
                       Address = s.Bio‌Business.Address,
                       Aparat = s.Bio‌Business.Aparat,
                       Email = s.Bio‌Business.Email,
                       FaxNumber = s.Bio‌Business.FaxNumber,
                       HomeNumber = s.Bio‌Business.HomeNumber,
                       Instagram = s.Bio‌Business.Instagram,
                       Mobile = s.Bio‌Business.Mobile,
                       TypeBusiness = s.Bio‌Business.TypeBusiness,
                       WhatsApp = s.Bio‌Business.WhatsApp,
                       Youtube = s.Bio‌Business.Youtube,
                   }).FirstOrDefaultAsync(cancellationToken);
            return result;
        }

        public async Task<List<ListBusinessDto>> GetListBusinessUser(Guid userId, CancellationToken cancellationToken)
        {
            List<ListBusinessDto> data = await TableNoTracking.Where(f => f.UserId == userId).OrderByDescending(o => o.RegisterDate)
                 .Select(s => new ListBusinessDto
                 {
                     Description = s.Bio‌Business.Description,
                     NameBusiness = s.Bio‌Business.NameBusiness,
                     BusinessUrl = s.BusinessUrl,
                     PathLogoMini = s.Bio‌Business.PathLogoMini,
                     BusinessManeger = s.Bio‌Business.BusinessManeger,
                     IdBusinessFull = s.Id,
                     IsActive = s.IsActive
                 }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<ListBusinessDto>> GetListBusiness(CancellationToken cancellationToken)
        {
            List<ListBusinessDto> data = await TableNoTracking.OrderByDescending(o => o.RegisterDate)
                 .Select(s => new ListBusinessDto
                 {
                     Description = s.Bio‌Business.Description,
                     NameBusiness = s.Bio‌Business.NameBusiness,
                     BusinessUrl = s.BusinessUrl,
                     PathLogoMini = s.Bio‌Business.PathLogoMini,
                     BusinessManeger = s.Bio‌Business.BusinessManeger,
                     IdBusinessFull = s.Id,
                     IsActive = s.IsActive
                 }).ToListAsync(cancellationToken);
            return data;
        }

        public int GetCountBusinessFull(Guid userId, CancellationToken cancellationToken)
        {
            var count = TableNoTracking.Count(w => w.UserId == userId);
            return count;
        }
    }
}
