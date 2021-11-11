using Data.Dto.User;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kendo.DynamicLinqCore;

namespace ServicePovider
{
    public class ServiceUser : IServiceUser
    {
        public IUnitOfWork UnitOfWork;
        public ServiceUser(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public async Task<DataDashboard> GetDataDashboard(Guid userId, CancellationToken cancellationToken)
        {
            var registerDate = await UnitOfWork.UserRepository.GetRegisterDate(userId, cancellationToken);
            var count = UnitOfWork.BusinessFullRepository.GetCountBusinessFull(userId, cancellationToken);
            var muchPayment = UnitOfWork.PaymentRepository.GetSumAmountUserWithDiscount(userId);
            return new DataDashboard
            {
                CountBusinessFull = count,
                RegisterDate = $"{registerDate.Days}روز ",
                MuchPayment = muchPayment.AlphPayment
            };
        }

        public async Task<List<UsersDto>> GetUsersForTransaction(Guid userId, CancellationToken cancellationToken)
        {
            var users = await UnitOfWork.UserRepository.GetUsersForTransaction(userId,cancellationToken);
            return users;
        }

        public DataSourceResult GetUsers(DataSourceRequest dataSourceRequest)
        {
            var result = UnitOfWork.UserRepository.GetUsers(dataSourceRequest);
            return result;
        }
        public async Task<ProfileDto> GetProfile(Guid userId, CancellationToken cancellationToken)
        {
            var result =await UnitOfWork.UserRepository.GetProfile(userId, cancellationToken);
            return result;
        }

        public async Task<bool> EditProfile(ProfileDto dto, Guid userId,CancellationToken cancellationToken)
        {
            var result = await UnitOfWork.UserRepository.EditProfile(dto, userId, cancellationToken);
            if (result)
                await UnitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }

        public async Task<bool> UpdateRefreshToken(Guid userId, bool isActive, CancellationToken cancellationToken)
        {
            var result = await UnitOfWork.UserRepository.UpdateRefreshToken(userId,isActive, cancellationToken);
            if (result)
                await UnitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
