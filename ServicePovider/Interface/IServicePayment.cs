using Common.Interface;
using Data.Dto.Payment;
using Kendo.DynamicLinqCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Data.Dto.Vencoin;

namespace ServicePovider
{
    public interface IServicePayment : ITransientDependency
    {

        Task<string> RequestToPayAndAddPayment(AddPaymentDto requestToPayDto, string UriVerify, Guid userId, bool iSSandBox, CancellationToken cancellationToken);
        Task<bool> VerifyToPayAndUpdatePayment(Guid userId, bool iSSandBox, CancellationToken cancellationToken);
        DataSourceResult GetAllPayment(DataSourceRequest dataSourceRequest);
        DataSourceResult GetPaymentByUser(DataSourceRequest dataSourceRequest, Guid userId);
        DataSourceResult GetPaymentByMoblie(DataSourceRequest dataSourceRequest, string Moblie);
        SumAmountUserDto GetSumAmountUserWithOutDiscount(Guid userId);
        SumAmountUserDto GetSumAmountUserWithDiscount(Guid userId);
        Task<bool> DiscountPayment(DiscountDto increaseAndDecrease, CancellationToken cancellationToken);
        Task<bool> TransactionBetweenUser(TransactionDto increaseAndDecrease, Guid userId, CancellationToken cancellationToken);
        Task<bool> AddPaymentForTransactionVencoin(TransactionDaily transactionDaily,CancellationToken cancellationToken);
        Task<bool> AddPaymentForBuiness(Guid userId, double amount, CancellationToken cancellationToken);

    }
}
