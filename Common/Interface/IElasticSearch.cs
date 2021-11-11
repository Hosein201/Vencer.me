using Common.CommonModel;
using Nest;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IConnectToElasticSearch
    {
        ElasticClient Client();
    }
    public interface IElasticSearchRepository
    {
        Task<ModelSearchReturnData> SearchElasticBusiness(string Query, CancellationToken cancellationToken, int Take = 20, int Skip = 0);
        Task<bool> CreateElasticBusiness(QueryBusinessDto queryBusinessDto, CancellationToken cancellationToken);
        Task<bool> UpdateElasticBusiness(QueryBusinessDto queryBusinessDto, CancellationToken cancellationToken);
        Task<bool> DeleteElasticBusiness(QueryBusinessDto queryBusinessDto, CancellationToken cancellationToken);
    }
}
