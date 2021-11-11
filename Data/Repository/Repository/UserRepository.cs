using Common.Interface;
using Common.Utilities;
using Data.Dto.User;
using Data.Model;
using Kendo.DynamicLinqCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository, IScopedDependency
    {
        private readonly VencerDbContext _dbContext;
        private IJsonConvertCommon _jsonConvert;

        public UserRepository(VencerDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _jsonConvert = new JsonConvertCommon();
        }

        public async Task<User> GetUserById(Guid userId, CancellationToken cancellationToken)
        {
            return await TableNoTracking.FirstOrDefaultAsync(s => s.Id == userId, cancellationToken);

        }
        public async Task<User> GetUserByMobile(string phone, CancellationToken cancellationToken)
        {
            return await TableNoTracking.FirstOrDefaultAsync(s => s.PhoneNumber == phone, cancellationToken);
        }

        public DataSourceResult GetUsers(DataSourceRequest dataSourceRequest)
        {
            var users = TableNoTracking.Select(s => new UsersDto
            {
                UserId = s.Id,
                UserName = s.UserName,
                Mobile = s.PhoneNumber,
                Email = s.Email,
                FullName = s.FullName
            }).ToDataSourceResult(dataSourceRequest);
            return users;
        }

        public async Task<List<UsersDto>> GetUsersForTransaction(Guid userId,CancellationToken cancellationToken)
        {
            var users = await TableNoTracking.Where(w=> w.Id!= userId).Select(s => new UsersDto
            {
                UserId = s.Id,
                FullName = s.UserName
            }).ToListAsync(cancellationToken);
            return users;
        }

        public async Task<User> GetUserByName(string userName, CancellationToken cancellationToken)
        {
            return await TableNoTracking.FirstOrDefaultAsync(s => s.UserName == userName, cancellationToken);
        }

        public async Task<TimeSpan> GetRegisterDate(Guid userId, CancellationToken cancellationToken)
        {
            var registerDate = await TableNoTracking.Where(s => s.Id == userId).Select(s => s.RegisterDate).FirstOrDefaultAsync(cancellationToken);
            return DateTime.Now - registerDate;
        }


        public async Task<ProfileDto> GetProfile(Guid userId, CancellationToken cancellationToken)
        {

            var result = await TableNoTracking.Where(f => f.Id == userId).Select(s => new ProfileDto
            {
                FullName = s.FullName,
                Email = s.Email,
                CountryId = s.CountryId,
                ProvinceId = s.ProvinceId,
                Address = s.Address,
                //JobId = s.JobId,
                PhoneNumber = s.PhoneNumber,
                CityId = s.CityId,
                PathImgUser = s.PathImgUser
            }).FirstOrDefaultAsync(cancellationToken);
            return result;
        }

        public async Task<bool> EditProfile(ProfileDto dto, Guid userId, CancellationToken cancellationToken)
        {
            var user = await Table.FirstOrDefaultAsync(f => f.Id == userId, cancellationToken);

            user.ProvinceId = dto.ProvinceId;
            user.CountryId = dto.CountryId;
            //user.JobId = dto.JobId;
            user.CityId = dto.CityId;
            user.Address = dto.Address;
            user.FullName = dto.FullName;
            user.PathImgUser = dto.PathImgUser;
            Update(user);
            return true;
        }

        public async Task<bool> DeactivateUser(Guid userId, CancellationToken cancellationToken)
        {
            var user = await Table.FirstOrDefaultAsync(f => f.Id == userId, cancellationToken);
            user.IsActive = false;
            return true;
        }

        public async Task<bool> UpdateRefreshToken(Guid userId, bool isActive, CancellationToken cancellationToken)
        {
            var user = await Table.FirstOrDefaultAsync(f => f.Id == userId, cancellationToken);
            user.RefreshToken = isActive ? Guid.NewGuid() : Guid.Empty;

            Update(user); return true;
        }
    }
}
