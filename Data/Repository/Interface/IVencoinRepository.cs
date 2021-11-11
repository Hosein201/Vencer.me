using Common.Utilities;
using Data.Dto.Vencoin;
using Data.Model;
using Kendo.DynamicLinqCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IVencoinRepository : IRepository<Vencoin>
    {
        Task<TransactionDaily> CreateVencoin(VencoinCondition condition, string price, string total, VencoinTypeSaleOrBuy saleOrBuy, Guid userId, CancellationToken cancellationToken);
        DataSourceResult GetAllTransactionUser(DataSourceRequest dataSourceRequest, Guid userId);
        Task<ResultLineReport> GetReportLineChart(CancellationToken cancellationToken);
        Task<ResultAreaReport> GetReporAreaChart(CancellationToken cancellationToken);
        Task<ResultColumnReport> GetReportColumnChart(CancellationToken cancellationToken);
        DataSourceResult GetReportVencoinBuyGrid(DataSourceRequest dataSourceRequest);
        DataSourceResult GetReportVencoinSaleGrid(DataSourceRequest dataSourceRequest);
        Task<bool> CancelTransaction(VencoinTransactionDto transactionDto, Guid userId, CancellationToken cancellationToken);
        Task<TransactionDaily> JobTransactionDailyVencoin(CancellationToken cancellationToken = default);
        Task<ReportTicker> GetReportTicker(CancellationToken cancellationToken);
        DataSourceResult GetVolumeVencoinOfUsers(DataSourceRequest dataSourceRequest, Guid userId);

    }
}
