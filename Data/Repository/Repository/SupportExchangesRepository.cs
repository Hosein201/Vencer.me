using Common.Interface;
using Common.Utilities;
using Data.Dto.SupportExchanges;
using Data.Model;
using Kendo.DynamicLinqCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.CommonModel;

namespace Data.Repository.Repository
{
    public class SupportExchangesRepository : Repository<SupportExchanges>, ISupportExchangesRepository, IScopedDependency
    {
        private readonly IJsonConvertCommon _jsonConvert;
        public SupportExchangesRepository(VencerDbContext dbContext)
            : base(dbContext)
        {
            _jsonConvert = new JsonConvertCommon();
        }

        public DataSourceResult GetSupportExchangesByState(DataSourceRequest dataSourceRequest,SupportExchangesState state, Guid userId, CancellationToken cancellationToken)
        {
            var supportExchangesState = (int)state;
            var result = TableNoTracking.Where(w=>w.State== supportExchangesState)
                .OrderByDescending(p => p.RegisterDate).ToDataSourceResult(dataSourceRequest);
            return result;
        }

        public DataSourceResult GetSupportExchanges(DataSourceRequest dataSourceRequest)
        {
            var result = TableNoTracking.Where(w=> w.State!=4).OrderByDescending(p => p.RegisterDate).ToDataSourceResult(dataSourceRequest);
            return result;
        }  
        public DataSourceResult GetSupportExchangesUser(DataSourceRequest dataSourceRequest ,Guid userId)
        {
            var result = TableNoTracking.Where(w=> w.UserId==userId)
                .OrderByDescending(p => p.RegisterDate).ToDataSourceResult(dataSourceRequest);
            return result;
        }


        public async Task<bool> UpdateSupportExchanges(SupportExchangesState stateToChange,string description,
            Guid idExchange, Guid userId, CancellationToken cancellationToken)
        {
            var result = await Table.FirstOrDefaultAsync(w => w.Id == idExchange && w.UserId == userId, cancellationToken);
            result.State = (int)stateToChange;
            result.Description = description;
            return true;
        }

        public async Task<bool> CreateSupportExchanges(CreateSupportExchangesDto createSupportExchangesDto, Guid userId, CancellationToken cancellationToken)
        {
            if (!_jsonConvert.TryDeserializeObject<List<FilePathSupport>>(createSupportExchangesDto.FilePath))
                throw new AppException(ApiResultStatusCode.LogicError, "فایلی ارسال نشده است ");

            var entity = new SupportExchanges()
            {
                State = createSupportExchangesDto.State,
                AmountOfExchange =long.Parse(createSupportExchangesDto.AmountOfExchange),
                ConfirmedFile = false,
                Description = createSupportExchangesDto.Description,
                FilePath = createSupportExchangesDto.FilePath,
                HasFile = _jsonConvert.TryDeserializeObject<List<FilePathSupport>>(createSupportExchangesDto.FilePath),
                AccountNumberOfBank = createSupportExchangesDto.AccountNumberOfBank,
                UserId = userId
            };
            await AddAsync(entity, cancellationToken);
            return true;
        }

        public async Task<bool> ConfirmedFileSupportExchanges(bool isConfirmed , SupportExchangesState stateToChange, Guid idExchange, Guid userId, CancellationToken cancellationToken)
        {
            var result = await Table.FirstOrDefaultAsync(w => w.Id == idExchange && w.UserId == userId, cancellationToken);
            result.ConfirmedFile = isConfirmed;
            result.State = (int) stateToChange;
            return true;
        }
    }
}
