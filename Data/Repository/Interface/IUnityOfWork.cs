using System.Threading;
using System.Threading.Tasks;
using Common.Interface;

namespace Data.Repository
{
    public interface IUnitOfWork : ITransientDependency
    {
        IBusinessFullRepository BusinessFullRepository { get; set; }
        ILookupsRepository LookupsRepository { get; set; }
        IPaymentRepository PaymentRepository { get; set; }
        IRoleRepository RoleRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        IVencoinRepository VencoinRepository { get; set; }
        IBioBusinessRepository BioBusinessRepository { get; set; }

        void SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
