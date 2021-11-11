using Common.Utilities;
using Data.Dto.SupportExchanges;
using Data.Model;
using Kendo.DynamicLinqCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface ISupportExchangesRepository : IRepository<SupportExchanges>
    {
        DataSourceResult GetSupportExchanges(DataSourceRequest dataSourceRequest);
        DataSourceResult GetSupportExchangesUser(DataSourceRequest dataSourceRequest, Guid userId);
        DataSourceResult GetSupportExchangesByState(DataSourceRequest dataSourceRequest, SupportExchangesState state, Guid userId, CancellationToken cancellationToken);
        Task<bool> UpdateSupportExchanges(SupportExchangesState stateToChange, string description, Guid idExchange, Guid userId, CancellationToken cancellationToken);
        Task<bool> CreateSupportExchanges(CreateSupportExchangesDto createSupportExchangesDto, Guid userId, CancellationToken cancellationToken);
        Task<bool> ConfirmedFileSupportExchanges(bool isConfirmed, SupportExchangesState stateToChange, Guid idExchange, Guid userId, CancellationToken cancellationToken);
    }
}
