using System.Threading;
using System.Threading.Tasks;
using Data.Repository.Repository;

namespace Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VencerDbContext _dbContext;
        public IBusinessFullRepository BusinessFullRepository { get; set; }
        public ILookupsRepository LookupsRepository { get; set; }
        public IPaymentRepository PaymentRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IVencoinRepository VencoinRepository { get; set; }
        public IBioBusinessRepository BioBusinessRepository { get; set; }

        public UnitOfWork(VencerDbContext dbContext)
        {
            this._dbContext = dbContext;
            BusinessFullRepository = new BusinessFullRepository(dbContext);
            LookupsRepository = new LookupsRepository(dbContext);
            PaymentRepository = new PaymentRepository(dbContext);
            RoleRepository = new RoleRepository(dbContext);
            UserRepository = new UserRepository(dbContext);
            VencoinRepository = new VencoinRepository(dbContext);
            BioBusinessRepository=new BioBusinessRepository(dbContext);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
