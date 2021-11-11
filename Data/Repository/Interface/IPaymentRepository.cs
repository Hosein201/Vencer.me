using Data.Dto.Payment;
using Data.Dto.Vencoin;
using Data.Model;
using Kendo.DynamicLinqCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<bool> AddPaymentWtihRegister(long Amount, string Description, Guid userId, CancellationToken cancellationToken);
        Task<AddPaymentDto> AddPayment(AddPaymentDto addPayment, Guid userId, CancellationToken cancellationToken);
        Task<UpdatePaymentDto> UpdatePayment(UpdatePaymentDto updatePayment, Guid userId, CancellationToken cancellationToken);
        DataSourceResult GetAllPaymentUser(DataSourceRequest dataSourceRequest);
        DataSourceResult GetPaymentByMoblie(DataSourceRequest dataSourceRequest, string Moblie);
        DataSourceResult GetPaymentByUserName(DataSourceRequest dataSourceRequest, Guid userId);
        SumAmountUserDto GetSumAmountUserWithOutDiscount(Guid userId);
        SumAmountUserDto GetSumAmountUserWithDiscount(Guid userId);
        Task<bool> TransactionBetweenUser(TransactionDto increaseAndDecrease, Guid userId, CancellationToken cancellationToken);
        Task<bool> DiscountPayment(DiscountDto increaseAndDecrease, CancellationToken cancellationToken);
        Task<bool> AddRengPayment(TransactionDaily transactionDaily, Guid userIdAdmin, CancellationToken cancellationToken);
        Task<bool> AddRengPayment(Guid adminUserId, Guid userId, double amount, CancellationToken cancellationToken);
    }
}
