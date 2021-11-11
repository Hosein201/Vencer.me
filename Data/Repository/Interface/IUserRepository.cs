using Data.Dto.User;
using Data.Model;
using Kendo.DynamicLinqCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByMobile(string phone, CancellationToken cancellationToken);
        Task<User> GetUserById(Guid userId, CancellationToken cancellationToken);
        DataSourceResult GetUsers(DataSourceRequest dataSourceRequest);
        Task<List<UsersDto>> GetUsersForTransaction(Guid userId,CancellationToken cancellationToken);
        Task<User> GetUserByName(string userName, CancellationToken cancellationToken);
        Task<TimeSpan> GetRegisterDate(Guid userId, CancellationToken cancellationToken);
        Task<ProfileDto> GetProfile(Guid userId, CancellationToken cancellationToken);
        Task<bool> EditProfile(ProfileDto dto, Guid userId, CancellationToken cancellationToken);
        Task<bool> UpdateRefreshToken(Guid userId, bool isActive, CancellationToken cancellationToken);
        Task<bool> DeactivateUser(Guid userId, CancellationToken cancellationToken);
    }
}
