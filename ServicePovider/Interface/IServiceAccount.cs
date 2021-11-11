using Common.Interface;
using Data.Dto.User;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System;

namespace ServicePovider
{
    public interface IServiceAccount : ITransientDependency
    {
        Task<RegsiterModel> RegsiterInPanel(UserRegsiterInPanelDto regsiterDto, string UriVerify, bool iSSandBox, CancellationToken cancellationToken = default);
        Task<AccessToken> Regsiter(UserRegsiterDto regsiterDto, CancellationToken cancellationToken = default);
        Task<AccessToken> Login(UserLogin userLogin, CancellationToken cancellationToken = default);
        Task<bool> ChangePassword(ChangePasswordDto changePasswordDto, string userName, CancellationToken cancellationToken = default);
        Task<string> ForgetPassword(ForgetPasswordDto dto, CancellationToken cancellationToken);
        Task<bool> DeactivateUser(Guid userId, CancellationToken cancellationToken);
    }
}
