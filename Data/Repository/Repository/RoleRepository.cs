using Common.Interface;
using Common.Utilities;
using Data.Model;

namespace Data.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository, IScopedDependency
    {
        private VencerDbContext _dbContext;
        private IJsonConvertCommon _jsonConvert;

        public RoleRepository(VencerDbContext dbContext)
            : base(dbContext)
        {
            _jsonConvert = new JsonConvertCommon();
            this._dbContext = dbContext;
        }
    }
}
