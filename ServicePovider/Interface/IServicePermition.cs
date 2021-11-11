using System;
using Common.Interface;
using Data.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Utilities;
using Kendo.DynamicLinqCore;
using Microsoft.AspNetCore.Mvc;

namespace ServicePovider
{
    public interface IServicePermition : IScopedDependency
    {
        Task<List<Role>> GetPermitions(CancellationToken cancellationToken);
        Task<bool> CreatePermitions(CancellationToken cancellationToken);
        Task<bool> AddUserToRole(string userName, VencerPermission permission);
        Task<bool> RemoveUserToRole(string userName, VencerPermission permission);
        DataSourceResult GetUserOfPermition(DataSourceRequest dataSourceRequest, string roleName, CancellationToken cancellationToken);
    }
}
