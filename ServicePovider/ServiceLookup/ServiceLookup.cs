using System;
using Data.Dto.Lookups;
using Data.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServicePovider
{
    public class ServiceLookup : IServiceLookup
    {
        public IUnitOfWork UnitOfWork;
        public ServiceLookup(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
        public Task<LookupsDto> GetLookupWithType(string type, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<LookupsDto> GetLookupWithTypeAndAux(string type, string aux1, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<LookupsDto> GetLookupWithTypeAndAuxAndCode(string type, int code, string aux1, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<LookupsDto>> GetLookupsWithTypeAndAux(string type, string aux1, CancellationToken cancellationToken)
        {
            var lookups = await UnitOfWork.LookupsRepository.GetLookupsWithTypeAndAux(type, aux1, cancellationToken);
            return lookups;
        }

        public async Task<IEnumerable<LookupsDto>> GetLookupsWithType(string type, CancellationToken cancellationToken)
        {
            var lookups = await UnitOfWork.LookupsRepository.GetLookupsWithType(type, cancellationToken);
            return lookups;
        }

        public async Task<LookupsDto> GetLookupById(Guid id, CancellationToken cancellationToken)
        {
            var lookups = await UnitOfWork.LookupsRepository.GetLookupById(id, cancellationToken);
            return lookups;
        }
    }
}
