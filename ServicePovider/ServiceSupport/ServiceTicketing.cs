using Common.Utilities;
using Data.Dto.SupportExchanges;
using Data.Repository;
using Kendo.DynamicLinqCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServicePovider
{
    public class ServiceTicketing : IServiceTicketing
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupportExchangesRepository _supportExchangesRepository;
        public ServiceTicketing(ISupportExchangesRepository supportExchangesRepository, IUnitOfWork unitOfWork)
        {
            _supportExchangesRepository = supportExchangesRepository;
            _unitOfWork = unitOfWork;
        }
        public DataSourceResult GetSupportExchanges(DataSourceRequest dataSourceRequest)
        {
            return _supportExchangesRepository.GetSupportExchanges(dataSourceRequest);
        } 
        public DataSourceResult GetSupportExchangesUser(DataSourceRequest dataSourceRequest, Guid userId)
        {
            return _supportExchangesRepository.GetSupportExchangesUser(dataSourceRequest, userId);
        }

        public DataSourceResult GetSupportExchangesByState(DataSourceRequest dataSourceRequest, SupportExchangesState state,
            Guid userId, CancellationToken cancellationToken)
        {
            return _supportExchangesRepository.GetSupportExchangesByState(dataSourceRequest, state, userId, cancellationToken);
        }

        public async Task<bool> UpdateSupportExchanges(SupportExchangesState stateToChange, string description, Guid idExchange, Guid userId,
            CancellationToken cancellationToken)
        {
            var result=await _supportExchangesRepository.UpdateSupportExchanges(stateToChange, description, idExchange, userId, cancellationToken);
            if (result)
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }

        public async Task<bool> CreateSupportExchanges(CreateSupportExchangesDto createSupportExchangesDto, Guid userId,
            CancellationToken cancellationToken)
        {
            var result= await _supportExchangesRepository.CreateSupportExchanges(createSupportExchangesDto, userId, cancellationToken);
             if(result)
               await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }

        public async Task<bool> ConfirmedFileSupportExchanges(bool isConfirmed, SupportExchangesState stateToChange, Guid idExchange, Guid userId,
            CancellationToken cancellationToken)
        {
            var result= await _supportExchangesRepository.ConfirmedFileSupportExchanges(isConfirmed, stateToChange, idExchange, userId, cancellationToken);
            if (result)
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
