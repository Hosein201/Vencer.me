using Common.Interface;
using Data.Dto.Vencoin;
using Kendo.DynamicLinqCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServicePovider
{
    public interface IServiceVencoin : ITransientDependency
    {
        Task<bool> CreateVencoin(CreateVencoinDto createVencoinDto, Guid userId, CancellationToken cancellationToken);
        Task<bool> CancelTransaction(VencoinTransactionDto transactionDto, Guid userId, CancellationToken cancellationToken);
        DataSourceResult GetAllTransactionUser(DataSourceRequest dataSourceRequest, Guid userId);
        Task<bool> JobTransactionDailyVencoin(CancellationToken cancellationToken = default);
        DataSourceResult GetReportVencoinBuyGrid(DataSourceRequest dataSourceRequest);
        DataSourceResult GetReportVencoinSaleGrid(DataSourceRequest dataSourceRequest);
        Task<ResultLineReport> GetReportLineChart(CancellationToken cancellationToken);
        Task<ResultAreaReport> GetReporAreaChart(CancellationToken cancellationToken);
        Task<ResultColumnReport> GetReportColumnChart(CancellationToken cancellationToken);
        Task<ReportTicker> GetReportTicker(CancellationToken cancellationToken);
        DataSourceResult GetVolumeVencoinOfUsers(DataSourceRequest dataSourceRequest, Guid userId);
    }
}