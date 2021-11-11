using Common.Utilities;
using Data.Dto.SupportExchanges;
using Kendo.DynamicLinqCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Interface;

namespace ServicePovider
{
    public interface IServiceTicketing :IScopedDependency
    {
        DataSourceResult GetSupportExchanges(DataSourceRequest dataSourceRequest);
        DataSourceResult GetSupportExchangesUser(DataSourceRequest dataSourceRequest, Guid userId);
        DataSourceResult GetSupportExchangesByState(DataSourceRequest dataSourceRequest, SupportExchangesState state, Guid userId, CancellationToken cancellationToken);
        Task<bool> UpdateSupportExchanges(SupportExchangesState stateToChange, string description, Guid idExchange, Guid userId, CancellationToken cancellationToken);
        Task<bool> CreateSupportExchanges(CreateSupportExchangesDto createSupportExchangesDto, Guid userId, CancellationToken cancellationToken);
        Task<bool> ConfirmedFileSupportExchanges(bool isConfirmed, SupportExchangesState stateToChange, Guid idExchange, Guid userId, CancellationToken cancellationToken);
    }
}
