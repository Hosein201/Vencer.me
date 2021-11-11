using Common.Interface;
using Common.Utilities;
using Data.Dto.Payment;
using Data.Dto.User;
using Data.Model;
using Data.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.CustomMapper;
using WebFramework.UserManagerExtension;

namespace ServicePovider
{
    public class ServiceAccount : IServiceAccount
    {
        public IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private IJsonConvertCommon _jsonConvert;
        private readonly IJwtService _jwtService;
        private readonly IServicePayment _servicePayment;
        private readonly IServiceBusiness _serviceBusiness;

        public ServiceAccount(IUnitOfWork unitOfWork, UserManager<User> userManager,
            SignInManager<User> signInManager, IJwtService jwtService, IServicePayment servicePayment, IServiceBusiness serviceBusiness)
        {
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._jsonConvert = new JsonConvertCommon();
            this._jwtService = jwtService;
            this._servicePayment = servicePayment;
            this._serviceBusiness = serviceBusiness;
        }

        public async Task<bool> ChangePassword(ChangePasswordDto changePasswordDto, string userName, CancellationToken cancellationToken = default)
        {
            var findUserName = await _userManager.FindByNameAsync(userName);
            var ChangePassword = await _userManager.ChangePasswordAsync(findUserName, changePasswordDto.Oldpassword, changePasswordDto.Newpassword);
            if (ChangePassword.Succeeded)
                return true;
            throw new AppException(ApiResultStatusCode.BadRequest, "مشکلی در تغییر پسورد به وجود امده است");
        }

        public async Task<AccessToken> Login(UserLogin userLogin, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByNameAsync(userLogin.UserName);
            var checkPassword = await _signInManager.UserManager.CheckPasswordAsync(user, userLogin.Password);
            if (checkPassword)
            {

                List<string> role = (List<string>)await _signInManager.UserManager.GetRolesAsync(user);
                var token = await _jwtService.GenerateAsync(user, role.FirstOrDefault()?.Trim());
                return token;
            }
            throw new AppException(ApiResultStatusCode.BadRequest, "نام کاربری یا رمز عبور اشتباه است");
        }

        public async Task<AccessToken> Regsiter(UserRegsiterDto regsiterDto, CancellationToken cancellationToken = default)
        {
            var findUserName = await _userManager.FindByNameAsync(regsiterDto.UserName);
            if (findUserName != null)
                throw new AppException(ApiResultStatusCode.UserIsInsystem, "نام کاربری در سیستم ثبت شده است");
            var findEmail = await _userManager.FindByEmailAsync(regsiterDto.Email);
            if (findEmail != null)
                throw new AppException(ApiResultStatusCode.UserIsInsystem, "ایمیل در سیستم ثبت شده است");
            var findMobile = await _unitOfWork.UserRepository.GetUserByMobile(regsiterDto.Mobile, cancellationToken);
            if (findMobile != null)
                throw new AppException(ApiResultStatusCode.UserIsInsystem, "موبایل در سیستم ثبت شده است");

            var user = Req2User.ReqDto2User(regsiterDto);
            var userForToken = await _userManager.CreateAsync(user, regsiterDto.Password);
            if (!userForToken.Succeeded)
                throw new AppException(ApiResultStatusCode.ServerError, "خطا در ثبت نام کاربر رخ داده است");

            var roleForToken = await _userManager.AddToRoleAsync(user, VencerPermission.Customer.ToDisplay());
            if (!roleForToken.Succeeded)
                throw new AppException(ApiResultStatusCode.ServerError, "خطا در ثبت پرمیشن کاربر رخ داده است");

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var token = await _jwtService.GenerateAsync(user, VencerPermission.Customer.ToDisplay());

            return token;

            #region MyRegion
            //var createBusinessRegsiter = await _serviceBusiness.CreateBusinessAndForRegsiter(regsiterDto.UserName, regsiterDto.NameBusiness, regsiterDto.BusinessManeger, cancellationToken);
            //if (!createBusinessRegsiter)
            //    throw new AppException(ApiResultStatusCode.ServerError, "خطا در ثبت کسب و کار رخ داده است");
            //var url = await _servicePayment.RequestToPayAndAddPayment(new AddPaymentDto
            //{ Amount = Convert.ToInt32(amount), Authority = null, Description = regsiterDto.DcrAmount, Discount = false, Increase = true, Mobile = regsiterDto.Mobile },
            //         uriVerify,
            //         user.Id, true, cancellationToken);

            //return new RegsiterModel
            //{
            //    Url = url,
            //    AccessToken = token
            //};
            #endregion
        }
        public async Task<RegsiterModel> RegsiterInPanel(UserRegsiterInPanelDto registerDto, string UriVerify, bool iSSandBox, CancellationToken cancellationToken = default)
        {
            var findUserName = await _userManager.FindByNameAsync(registerDto.UserName);
            if (findUserName != null)
                throw new AppException(ApiResultStatusCode.UserIsInsystem, "نام کاربری در سیستم ثبت شده است");
            var findEmail = await _userManager.FindByEmailAsync(registerDto.Email);
            if (findEmail != null)
                throw new AppException(ApiResultStatusCode.UserIsInsystem, "ایمیل در سیستم ثبت شده است");
            var findMobile = await _unitOfWork.UserRepository.GetUserByMobile(registerDto.Mobile, cancellationToken);
            if (findMobile != null)
                throw new AppException(ApiResultStatusCode.UserIsInsystem, "موبایل در سیستم ثبت شده است");

            var user = Req2User.ReqDto2User(registerDto);
            var userForToken = await _userManager.CreateAsync(user, registerDto.Password);
            if (!userForToken.Succeeded)
                throw new AppException(ApiResultStatusCode.ServerError, "خطا در ثبت نام کاربر رخ داده است");

            var roleForToken = await _userManager.AddToRoleAsync(user, VencerPermission.Customer.ToDisplay());
            if (!roleForToken.Succeeded)
                throw new AppException(ApiResultStatusCode.ServerError, "خطا در ثبت پرمیشن کاربر رخ داده است");

            var token = await _jwtService.GenerateAsync(user, VencerPermission.Customer.ToDisplay());

            var createBusinessRegsiter = await _serviceBusiness.CreateBusinessAndForRegsiter(registerDto.UserName, registerDto.BusinessUrl,
                registerDto.NameBusiness, registerDto.BusinessManeger,
                        cancellationToken);

            //payment 
            var url = await _servicePayment.RequestToPayAndAddPayment(new AddPaymentDto()
            {
                Amount = long.Parse(registerDto.Amount),
                TransactionBetweenUser = false,
                Description = registerDto.DcrAmount,
                Discount = false,
                Increase = false,
                IsComplete = false,
                IsSite = true,
                Mobile = registerDto.Mobile,
                Authority = null
            }, UriVerify, user.Id, iSSandBox, cancellationToken);


            if (!createBusinessRegsiter)
                throw new AppException(ApiResultStatusCode.ServerError, "خطا در ثبت کسب و کار رخ داده است");
            return new RegsiterModel
            {
                AccessToken = token,
                Url = url
            };
        }


        public async Task<string> ForgetPassword(ForgetPasswordDto dto, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindUserByUserNameAndMobie(dto.UserName, dto.Mobile, cancellationToken);
            if (user == null)
                throw new AppException(ApiResultStatusCode.BadRequest, "نام کاربری یا موبایل اشتباه است");

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetToken, dto.Mobile);
            if (resetPassResult.Succeeded)
                return user.PhoneNumber;
            return string.Empty;
        }

        public async Task<bool> DeactivateUser(Guid userId,CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRepository.DeactivateUser(userId, cancellationToken);
            if(result)
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }


    public class RegsiterModel
    {
        public AccessToken AccessToken { get; set; }
        public string Url { get; set; }
    }
}
