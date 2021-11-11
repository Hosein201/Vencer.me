using Common.CommonModel;
using Common.Interface;
using Common.Utilities;
using Nest;
using Serilog;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebFramework.ElasticSearch
{
    public class ElasticSearchRepository : IElasticSearchRepository, IScopedDependency
    {
        private readonly IElasticClient _elasticClient;
        private readonly ILogger logger;
        public ElasticSearchRepository(IElasticClient elasticClient, ILogger _logger)
        {
            _elasticClient = elasticClient;
            logger = _logger;
        }
        public async Task<bool> CreateElasticBusiness(QueryBusinessDto queryBusinessDto, CancellationToken cancellationToken)
        {
            Assert.NotNull(queryBusinessDto, nameof(queryBusinessDto), "create elastic is null");
            // await _elasticClient.IndexDocumentAsync(queryBusinessDto);
            queryBusinessDto.businessurl.ToLower();
            BulkResponse result = await _elasticClient
                .BulkAsync(b => b.Index<QueryBusinessDto>(i => i.Document(queryBusinessDto)), cancellationToken);
            if (result.IsValid && !result.Errors)
            {
                logger.Information("Create business elastric search ", result.ApiCall);
                logger.Information("Create business elastric search ", result.Items);
                return true;
            }
            if (result.ItemsWithErrors.Any() || result.Errors)
            {
                logger.Error(" Error Create business elastric search ", result.ItemsWithErrors);
                return false;
            }
            throw new AppException(ApiResultStatusCode.ServerError);
        }

        //public async Task<ModelSearchReturnData> SearchElasticBusiness(string Query, CancellationToken cancellationToken, int Take = 20, int Skip = 0)
        //{
        //    if (string.IsNullOrEmpty(Query))
        //        return new ModelSearchReturnData() { Data = null, Total = null };
        //    ISearchResponse<QueryBusinessDto> responsedata = await _elasticClient.SearchAsync<QueryBusinessDto>(s => s
        //                       .Index("businessurl")
        //                            .Size(Take)
        //                              .Skip(Skip)
        //                               .Query(q => q
        //                                  .Match(m =>m
        //                                   .AutoGenerateSynonymsPhraseQuery(true)
        //                                   .Query(Query
        //                                    )
        //                                  )
        //                                )
        //                             , cancellationToken);
        //    long total = responsedata.Total;
        //    System.Collections.Generic.List<QueryBusinessDto> data = (from hits in responsedata.Hits
        //                                                              select hits.Source).ToList();
        //    return new ModelSearchReturnData() { Data = data, Total = total };
        //} 
        public async Task<ModelSearchReturnData> SearchElasticBusiness(string Query, CancellationToken cancellationToken, int Take = 20, int Skip = 0)
        {
            if (string.IsNullOrEmpty(Query))
                return new ModelSearchReturnData() { Data = null, Total = null };
            ISearchResponse<QueryBusinessDto> responsedata = await _elasticClient.SearchAsync<QueryBusinessDto>(s => s
                               .Index("businessurl")
                                    .Size(Take)
                                      .Skip(Skip)
                                       .Query(q => q
                                          .MultiMatch(m=> m
                                            .Query(Query))
                                        )
                                     , cancellationToken);
            long total = responsedata.Total;
            System.Collections.Generic.List<QueryBusinessDto> data = (from hits in responsedata.Hits
                                                                      select hits.Source).ToList();
            return new ModelSearchReturnData() { Data = data, Total = total };
        }

        public async Task<bool> UpdateElasticBusiness(QueryBusinessDto queryBusinessDto, CancellationToken cancellationToken)
        {

            UpdateResponse<QueryBusinessDto> result = await _elasticClient.UpdateAsync<QueryBusinessDto>(queryBusinessDto, i => i, cancellationToken);
            if (result.IsValid)
            {
                logger.Information("Update business elastric search ", result.ApiCall);
                logger.Information("Update business elastric search ", result.Result);
                return true;
            }
            throw new AppException(ApiResultStatusCode.ServerError);
        }

        public async Task<bool> DeleteElasticBusiness(QueryBusinessDto queryBusinessDto, CancellationToken cancellationToken)
        {
            DeleteResponse result = await _elasticClient.DeleteAsync<QueryBusinessDto>(queryBusinessDto,d=>d,cancellationToken);
            if (result.IsValid)
            {
                logger.Information("Delete business elastric search ", result.ApiCall);
                logger.Information("Delete business elastric search ", result.Result);
                logger.Information("Delete business elastric search ", result.ServerError);
                return true;
            }
            else 
            {
                logger.Error(" Error Delete business elastric search ", result.ServerError);
                return false;
            }
            throw new AppException(ApiResultStatusCode.ServerError);
        }
    }
}
