using Common.Utilities;
using Data.Model;
using Data.Repository;
using Kendo.DynamicLinqCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;


namespace ServicePovider
{
    public class ServicePermition : IServicePermition
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public ServicePermition(RoleManager<Role> roleManager, UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Role>> GetPermitions(CancellationToken cancellationToken)
        {
            return await _roleManager.Roles.ToListAsync(cancellationToken);
        }

        public async Task<bool> CreatePermitions(CancellationToken cancellationToken)
        {
            var list = CreateRoles();
            foreach (var item in list)
            {
                var result = await _roleManager.CreateAsync(item);
            }
            return true;
        }

        public async Task<bool> AddUserToRole(string userName, VencerPermission permission)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var isInRoleAsync = await _userManager.IsInRoleAsync(user, permission.ToDisplay());
            if (!isInRoleAsync)
            {
                await ClearAllRolesForUser(user);
                await _userManager.AddToRoleAsync(user, permission.ToDisplay());
            }
            return true;
        }

        public async Task<bool> RemoveUserToRole(string userName, VencerPermission permission)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var isInRoleAsync = await _userManager.IsInRoleAsync(user, permission.ToDisplay());
            if (!isInRoleAsync)
                return await ClearAllRolesForUser(user);
            return true;
        }

        public DataSourceResult GetUserOfPermition(DataSourceRequest dataSourceRequest, string roleName, CancellationToken cancellationToken)
        {
            var result = _userManager.Users.Where(t => t.UserRoles.FirstOrDefault().Role.Name== roleName).Select( s=> new 
            {
                UserName= s.UserName,
                FullName = s.FullName,
                RegisterDate= s.RegisterDate,
                PhoneNumber = s.PhoneNumber,
                Email= s.Email,
                UserId=s.Id
            });
            return result.ToDataSourceResult(dataSourceRequest);
        }

        #region private
        private async Task<bool> ClearAllRolesForUser(User user)
        {
            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                var delete = await _userManager.RemoveFromRoleAsync(user, role);
                if (!delete.Succeeded)
                    return false;
            }
            return true;
        }
        private List<Role> CreateRoles()
        {
            List<Role> role = new List<Role>();
            role.Add(new Role
            {
                Id = Guid.NewGuid(),
                NormalizedName = VencerPermission.Admin.ToDisplay().ToUpper(),
                Description = "مدیر سایت",
                Name = VencerPermission.Admin.ToDisplay(),
                //CodeRole = 0,
                ConcurrencyStamp = Guid.NewGuid().ToString()

            });
            role.Add(new Role
            {
                Id = Guid.NewGuid(),
                Description = "همه کاربران",
                Name = VencerPermission.AllUser.ToDisplay().ToUpper(),
                // CodeRole = 1,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }); role.Add(new Role
            {
                Id = Guid.NewGuid(),
                Description = "صاحب کسب کار",
                Name = VencerPermission.MasterBusiness.ToDisplay().ToUpper(),
                // CodeRole = 2,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }); role.Add(new Role
            {
                Id = Guid.NewGuid(),
                Description = "مشتری یا خریدار",
                Name = VencerPermission.Customer.ToDisplay().ToUpper(),
                // CodeRole = 3,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }); role.Add(new Role
            {
                Id = Guid.NewGuid(),
                Description = "کارمند",
                Name = VencerPermission.Employe.ToDisplay().ToUpper(),
                // CodeRole = 4,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
            return role;
        }
        #endregion
    }
}
