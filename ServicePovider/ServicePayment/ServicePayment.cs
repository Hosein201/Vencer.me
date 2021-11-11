using Common.Utilities;
using Data.Dto.Payment;
using Data.Dto.Vencoin;
using Data.Model;
using Data.Repository;
using Kendo.DynamicLinqCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebFramework;
using WebFramework.UserManagerExtension;

namespace ServicePovider
{
    public class ServicePayment : IServicePayment
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRequestToPay _paymentPay;
        private readonly IMemoryCacheCustome _cacheCustome;
        private readonly UserManager<User> _userManager;
        public ServicePayment(IUnitOfWork unitOfWork, IRequestToPay _paymentPay, IMemoryCacheCustome cacheCustome, UserManager<User> userManager)
        {
            this._unitOfWork = unitOfWork;
            this._paymentPay = _paymentPay;
            this._cacheCustome = cacheCustome;
            _userManager = userManager;
        }

        public async Task<bool> AddPaymentForTransactionVencoin(TransactionDaily transactionDaily, CancellationToken cancellationToken)
        {
            // add payment for  admin  -   for buys   - for  sales
            var adminUser = await _userManager.GetUserAdmin(cancellationToken);
            var userIdAdmin = adminUser.Id;
            var result = await _unitOfWork.PaymentRepository.AddRengPayment(transactionDaily, userIdAdmin, cancellationToken);
            if (!result)
                return false;
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }


        public async Task<bool> AddPaymentForBuiness(Guid userId, double amount, CancellationToken cancellationToken)
        {
            var adminUser = await _userManager.GetUserAdmin(cancellationToken);
            var userIdAdmin = adminUser.Id;
            var result = await _unitOfWork.PaymentRepository.AddRengPayment(userIdAdmin, userId, amount, cancellationToken);
            if (!result)
                return false;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
        #region Reports

        public DataSourceResult GetAllPayment(DataSourceRequest dataSourceRequest)
        {
            var data = _unitOfWork.PaymentRepository.GetAllPaymentUser(dataSourceRequest);
            return data;
        }

        public DataSourceResult GetPaymentByUser(DataSourceRequest dataSourceRequest, Guid userId)
        {
            var data = _unitOfWork.PaymentRepository.GetPaymentByUserName(dataSourceRequest, userId);
            return data;
        }

        public DataSourceResult GetPaymentByMoblie(DataSourceRequest dataSourceRequest, string Moblie)
        {
            var data = _unitOfWork.PaymentRepository.GetPaymentByMoblie(dataSourceRequest, Moblie);
            return data;
        }

        public SumAmountUserDto GetSumAmountUserWithOutDiscount(Guid userId)
        {
            var data = _unitOfWork.PaymentRepository.GetSumAmountUserWithOutDiscount(userId);
            return data;
        }

        public SumAmountUserDto GetSumAmountUserWithDiscount(Guid userId)
        {
            var data = _unitOfWork.PaymentRepository.GetSumAmountUserWithDiscount(userId);
            return data;
        }
        #endregion

        public async Task<bool> DiscountPayment(DiscountDto increaseAndDecrease, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.PaymentRepository.DiscountPayment(increaseAndDecrease, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return data;
        }

        #region ReqisetToPayment
        public async Task<string> RequestToPayAndAddPayment(AddPaymentDto requestToPayDto, string UriVerify, Guid userId, bool iSSandBox, CancellationToken cancellationToken)
        {
            var data = _paymentPay.ZarinPalRequestToPay(Convert.ToString(requestToPayDto.Amount), UriVerify,
                requestToPayDto.Description, requestToPayDto.Mobile, iSSandBox);

            requestToPayDto.Authority = data.Authority;
            var cacheKey = "verifyToPayDto" + userId;

            _cacheCustome.Remove(cacheKey);
            _cacheCustome.Set(cacheKey, requestToPayDto, DateTime.Now.AddMinutes(15));

            await _unitOfWork.PaymentRepository.AddPayment(requestToPayDto, userId, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (data.Status != 100)
                throw new AppException(ApiResultStatusCode.BadRequest, "خطا در ارتباط با درگاه بانک رخ داده است");
            if (!iSSandBox)
                return "https://www.zarinpal.com/pg/StartPay/" + data.Authority;
            return "https://sandbox.zarinpal.com/pg/StartPay/" + data.Authority;
        }

        public async Task<bool> VerifyToPayAndUpdatePayment(Guid userId, bool iSSandBox, CancellationToken cancellationToken)
        {
            var cacheKey = "verifyToPayDto" + userId;
            var dataVerify = (AddPaymentDto)_cacheCustome.Get(cacheKey);
            var data = _paymentPay.ZarinPalVerifyPay(Convert.ToString(dataVerify.Amount), dataVerify.Authority, iSSandBox);
            var updatePaymentDto = new UpdatePaymentDto()
            {
                Amount = dataVerify.Amount,
                Authority = dataVerify.Authority,
                IsComplete = true,
                RefID = data.RefID
            };
            await _unitOfWork.PaymentRepository.UpdatePayment(updatePaymentDto, userId, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> TransactionBetweenUser(TransactionDto increaseAndDecrease, Guid userId, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.PaymentRepository.TransactionBetweenUser(increaseAndDecrease, userId, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return data;
        }
        #endregion
    }
}
