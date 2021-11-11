using Common.Interface;
using Common.Utilities;
using Data.Dto.Payment;
using Data.Dto.Vencoin;
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
    public class PaymentRepository : Repository<Payment>, IPaymentRepository, IScopedDependency
    {
        private VencerDbContext DbContext;
        public PaymentRepository(VencerDbContext dbContext)
            : base(dbContext)
        {
            DbContext = dbContext;
        }

        // پرداخت با بانک
        public async Task<AddPaymentDto> AddPayment(AddPaymentDto addPayment, Guid userId, CancellationToken cancellationToken)
        {

            var payment = new Payment()
            {
                Amount = addPayment.Amount,
                Description = addPayment.Description,
                IsSite = addPayment.IsSite,
                UserId = userId,
                Authority = addPayment.Authority,
                IsComplete = addPayment.IsComplete,
                Status = 0,
                Discount = addPayment.Discount,
                Increase = addPayment.Increase,
                TransactionBetweenUser = addPayment.TransactionBetweenUser
            };
            await AddAsync(payment, cancellationToken);
            return addPayment;
        }

        public async Task<UpdatePaymentDto> UpdatePayment(UpdatePaymentDto updatePayment, Guid userId, CancellationToken cancellationToken)
        {
            var paymentDb = await TableNoTracking.FirstOrDefaultAsync
                (
                   f => f.User.Id == userId &&
                   f.Amount == updatePayment.Amount &&
                   f.Authority == updatePayment.Authority, cancellationToken
                );

            paymentDb.IsComplete = updatePayment.IsComplete;
            paymentDb.RefID = updatePayment.RefID;
            Update(paymentDb);
            return updatePayment;
        }

        public async Task<bool> AddPaymentWtihRegister(long amount, string description, Guid userId, CancellationToken cancellationToken)
        {
            var payment = new Payment()
            {
                Amount = amount,
                Description = description,
                IsSite = true,
                UserId = userId,
                Authority = null,
                IsComplete = true,
                Status = 1,
                Discount = false,
                Increase = true,
                RefID = null
            };
            await AddAsync(payment, cancellationToken);
            return true;
        }

        public async Task<bool> AddRengPayment(TransactionDaily transactionDaily, Guid adminUserId, CancellationToken cancellationToken)
        {
            var payments = new List<Payment>();

            //Complete
            foreach (var item in transactionDaily.DataTransactionCompleteForPayment)
            {
                var salarySales = item.Amount * 0.07;
                var salaryBuy = item.Amount * 0.06;

                if (item.BuyOrSale == "buy")
                {
                    payments.Add(new Payment()
                    {
                        Amount = item.Amount - salaryBuy,
                        Description = "خرید ارز دیجیتالی",
                        IsComplete = true,
                        Status = 0,
                        UserId = item.UserId,
                        Increase = false
                    });

                    payments.Add(new Payment()
                    {
                        Amount = salaryBuy,
                        Description = "خرید vencoin کاربران",
                        IsComplete = true,
                        Status = 0,
                        UserId = adminUserId,
                        Increase = true
                    });
                }

                if (item.BuyOrSale == "sale")
                {
                    payments.Add(new Payment()
                    {
                        Amount = item.Amount - salarySales,
                        Description = "فروش ارز دیجیتالی",
                        IsComplete = true,
                        Status = 0,
                        UserId = item.UserId,
                        Increase = true
                    });

                    payments.Add(new Payment()
                    {
                        Amount = salarySales,
                        Description = "فروش vencoin کاربران",
                        IsComplete = true,
                        Status = 0,
                        UserId = adminUserId,
                        Increase = true
                    });
                }
            }

            //Not Complete
            foreach (var item in transactionDaily.DataTransactionNotCompleteForPayment)
            {
                var amount = (item.Dispute * item.Amount) / item.Total;

                var salarySales = amount * 0.07;
                var salaryBuy = amount * 0.06;

                if (item.BuyOrSale == "buy")
                {
                    payments.Add(new Payment()
                    {
                        Amount = amount - salaryBuy,
                        Description = "خرید ارز دیجیتالی",
                        IsComplete = true,
                        Status = 0,
                        UserId = item.UserId,
                        Increase = false
                    });

                    payments.Add(new Payment()
                    {
                        Amount = salaryBuy,
                        Description = "خرید vencoin کاربران",
                        IsComplete = true,
                        Status = 0,
                        UserId = adminUserId,
                        Increase = true
                    });
                }

                if (item.BuyOrSale == "sale")
                {
                    payments.Add(new Payment()
                    {
                        Amount = amount - salarySales,
                        Description = "فروش ارز دیجیتالی",
                        IsComplete = true,
                        Status = 0,
                        UserId = item.UserId,
                        Increase = true
                    });

                    payments.Add(new Payment()
                    {
                        Amount = salarySales,
                        Description = "فروش vencoin کاربران",
                        IsComplete = true,
                        Status = 0,
                        UserId = adminUserId,
                        Increase = true
                    });

                }
            }

            await AddRangeAsync(payments, cancellationToken);
            return true;
        }

        public async Task<bool> AddRengPayment(Guid adminUserId, Guid userId, double amount, CancellationToken cancellationToken)
        {
            await AddRangeAsync(new List<Payment>()
            {
                new Payment()
                {
                    Amount = amount,
                    Description ="ایجاد کسب و کار",
                    IsComplete = true,
                    Status = 0,
                    UserId = userId,
                    Increase = false
                },
                new Payment()
                { 
                    Amount = amount,
                    Description ="ایجاد کسب و کار کاربران", 
                    IsComplete = true,
                    Status = 0,
                    UserId = adminUserId,
                    Increase = true
                }
            }, cancellationToken);
            return true;
        }

        #region Report
        public DataSourceResult GetAllPaymentUser(DataSourceRequest dataSourceRequest)
        {
            var paymentDb = TableNoTracking.OrderByDescending(o => o.RegisterDate)
                               .Select(s => new
                               {
                                   Amount = s.Amount,
                                   Description = s.Description,
                                   RegisterDate = s.RegisterDate,
                                   IsComplete = s.IsComplete,
                                   RefID = s.RefID,
                                   UserName = s.User.UserName,
                                   Mobile = s.User.PhoneNumber,
                                   TransactionBetweenUser=s.TransactionBetweenUser,
                                   Increase = s.Increase

                               }).ToDataSourceResult(dataSourceRequest);
            return paymentDb;
        }

        public DataSourceResult GetPaymentByMoblie(DataSourceRequest dataSourceRequest, string Moblie)
        {
            var paymentDb = TableNoTracking.Where(w => w.User.PhoneNumber == Moblie).OrderByDescending(o => o.RegisterDate).ToDataSourceResult(dataSourceRequest);
            return paymentDb;

        }

        public DataSourceResult GetPaymentByUserName(DataSourceRequest dataSourceRequest, Guid userId)
        {
            var paymentDb = TableNoTracking.Where(w => w.UserId == userId).OrderByDescending(o => o.RegisterDate).ToDataSourceResult(dataSourceRequest);
            return paymentDb;
        }

        public SumAmountUserDto GetSumAmountUserWithOutDiscount(Guid userId)
        {
            var sumAmount = TableNoTracking.Where(w => w.UserId == userId && !w.Discount && w.IsComplete  && w.Increase).Sum(s => s.Amount);
            return new SumAmountUserDto() { NumberPayment = sumAmount, AlphPayment = ConvertIntToString.Return_String_Number(sumAmount) };

        }

        public SumAmountUserDto GetSumAmountUserWithDiscount(Guid userId)
        {
            var sumAmount = TableNoTracking.Where(w => w.UserId == userId && w.IsComplete && w.Increase).Sum(s => s.Amount);
            return new SumAmountUserDto() { NumberPayment = sumAmount, AlphPayment = ConvertIntToString.Return_String_Number(sumAmount) };
        }
        #endregion

        public async Task<bool> TransactionBetweenUser(TransactionDto increaseAndDecrease, Guid userId, CancellationToken cancellationToken)
        {
            var sumAmountDb = TableNoTracking.Where(w => w.User.Id == userId).Sum(s => s.Amount);
            if (increaseAndDecrease.Amount > sumAmountDb)
                throw new AppException(ApiResultStatusCode.BadRequest, "موجودی شما کافی نمی باشد");


            await AddPayment(new AddPaymentDto
            {
                Amount = increaseAndDecrease.Amount,
                Authority = null,
                Description = increaseAndDecrease.Description,
                Discount = false,
                IsSite = increaseAndDecrease.IsSite,
                Increase = false,
                IsComplete = true,
                TransactionBetweenUser = true
            }, userId, cancellationToken);

            await AddPayment(new AddPaymentDto
            {
                Amount = increaseAndDecrease.Amount,
                Authority = null,
                Description = increaseAndDecrease.Description,
                Discount = false,
                IsSite = increaseAndDecrease.IsSite,
                Increase = true,
                IsComplete = true,
                TransactionBetweenUser = true
            }, increaseAndDecrease.UserId, cancellationToken);

            return true;
        }

        public async Task<bool> DiscountPayment(DiscountDto increaseAndDecrease, CancellationToken cancellationToken)
        {
            await AddPayment(new AddPaymentDto
            {
                Amount = increaseAndDecrease.Amount,
                Authority = null,
                Description = increaseAndDecrease.Description,
                Discount = true,
                IsSite = increaseAndDecrease.IsSite,
                Increase = true,
                 IsComplete = true,
                 TransactionBetweenUser = true
            }, increaseAndDecrease.UserId, cancellationToken);
            return true;
        }
    }
}
