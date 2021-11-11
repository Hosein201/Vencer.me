using Common.Utilities;
using Data.Dto.Vencoin;
using Data.Model;
using Data.Repository;
using Kendo.DynamicLinqCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework;
using WebFramework.UserManagerExtension;

namespace ServicePovider
{
    public class ServiceVencoin : IServiceVencoin
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUpdateDataGrid _updateDataGrid;
        private readonly IServicePayment _servicePayment;

        public ServiceVencoin(IUnitOfWork unitOfWork, IUpdateDataGrid updateDataGrid,
            IServicePayment servicePayment)
        {
            _unitOfWork = unitOfWork;
            _updateDataGrid = updateDataGrid;
            _servicePayment = servicePayment;
        }

        public async Task<bool> CreateVencoin(CreateVencoinDto createVencoinDto, Guid userId, CancellationToken cancellationToken)
        {
            Enum.TryParse(createVencoinDto.Condition, out VencoinCondition condition);
            Enum.TryParse(createVencoinDto.TypeSaleOrBuy, out VencoinTypeSaleOrBuy typeSaleOrBuy);

            if (typeSaleOrBuy == VencoinTypeSaleOrBuy.Buy && condition == VencoinCondition.Now) // چک کردن اعتبار کاربری که میخواهد بخرد
            {
                var salary = double.Parse(createVencoinDto.Price) * 0.06;

                var userCredit = _servicePayment.GetSumAmountUserWithDiscount(userId).NumberPayment;

                if ((double.Parse(createVencoinDto.Price)+salary) > userCredit)
                    throw new AppException(ApiResultStatusCode.NotSuccess, "اعتبار شما کافی نمی باشد");
            }

            var result = await _unitOfWork.VencoinRepository.CreateVencoin(condition, createVencoinDto.Price, createVencoinDto.Total, typeSaleOrBuy, userId, cancellationToken);
            if (!result.IsSave)
                return false;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (typeSaleOrBuy== VencoinTypeSaleOrBuy.Buy)
                await _servicePayment.AddPaymentForTransactionVencoin(result, cancellationToken);
            else if(typeSaleOrBuy==VencoinTypeSaleOrBuy.Sale)
                await _servicePayment.AddPaymentForTransactionVencoin(result, cancellationToken);

            return true;
        }

        public async Task<bool> CancelTransaction(VencoinTransactionDto transactionDto, Guid userId, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.VencoinRepository.CancelTransaction(transactionDto, userId, cancellationToken);
            if (!result)
                return false;
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }

        public DataSourceResult GetAllTransactionUser(DataSourceRequest dataSourceRequest, Guid userId)
        {
            return _unitOfWork.VencoinRepository.GetAllTransactionUser(dataSourceRequest, userId);
        }

        public async Task<bool> JobTransactionDailyVencoin(CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.VencoinRepository.JobTransactionDailyVencoin(cancellationToken);
            if (!result.IsSave)
                return false;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _servicePayment.AddPaymentForTransactionVencoin(result, cancellationToken);

            return true;
        }

        public DataSourceResult GetReportVencoinBuyGrid(DataSourceRequest dataSourceRequest)
        {
            var result = _unitOfWork.VencoinRepository.GetReportVencoinBuyGrid(dataSourceRequest);

            return result;
        }

        public DataSourceResult GetReportVencoinSaleGrid(DataSourceRequest dataSourceRequest)
        {
            var result = _unitOfWork.VencoinRepository.GetReportVencoinSaleGrid(dataSourceRequest);

            return result;
        }

        public async Task<ResultLineReport> GetReportLineChart(CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.VencoinRepository.GetReportLineChart(cancellationToken);

            return result;
        }

        public async Task<ResultAreaReport> GetReporAreaChart(CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.VencoinRepository.GetReporAreaChart(cancellationToken);

            return result;
        }

        public async Task<ResultColumnReport> GetReportColumnChart(CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.VencoinRepository.GetReportColumnChart(cancellationToken);

            return result;
        }

        public async Task<ReportTicker> GetReportTicker(CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.VencoinRepository.GetReportTicker(cancellationToken);

            return result;
        }

        public DataSourceResult GetVolumeVencoinOfUsers(DataSourceRequest dataSourceRequest, Guid userId)
        {
            var result =  _unitOfWork.VencoinRepository.GetVolumeVencoinOfUsers(dataSourceRequest,userId);

            return result;
        }
    }
}