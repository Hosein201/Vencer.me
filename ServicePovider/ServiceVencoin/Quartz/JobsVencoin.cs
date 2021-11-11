using Quartz;
using ServicePovider;
using System.Threading.Tasks;

namespace ServicePoviders
{
    public class JobsVencoin : IJob
    {
        private IServiceVencoin _serviceVencoin;

        public JobsVencoin(IServiceVencoin serviceVencoin)
        {
            _serviceVencoin = serviceVencoin;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            await _serviceVencoin.JobTransactionDailyVencoin();
        }
    }
}
