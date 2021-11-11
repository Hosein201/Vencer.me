using Common.Interface;
using Data.Dto.User;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kendo.DynamicLinqCore;

namespace ServicePovider
{
    public interface IServiceUser : ITransientDependency
    {
        Task<DataDashboard> GetDataDashboard(Guid userId, CancellationToken cancellationToken);
        Task<List<UsersDto>> GetUsersForTransaction(Guid userId,CancellationToken cancellationToken);
        DataSourceResult GetUsers(DataSourceRequest dataSourceRequest);
        Task<ProfileDto> GetProfile(Guid userId, CancellationToken cancellationToken);
        Task<bool> EditProfile(ProfileDto dto, Guid userId, CancellationToken cancellationToken);
        Task<bool> UpdateRefreshToken(Guid userId, bool isActive, CancellationToken cancellationToken);
    }
}
