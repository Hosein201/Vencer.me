using System;
using Data.Dto.Lookups;
using Data.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface ILookupsRepository : IRepository<Lookups>
    {
        Task<LookupsDto> GetLookupWithType(string Type, CancellationToken cancellationToken);
        Task<LookupsDto> GetLookupWithTypeAndAux(string Type, string Aux1, CancellationToken cancellationToken);
        Task<LookupsDto> GetLookupWithTypeAndAuxAndCode(string Type, int Code, string Aux1, CancellationToken cancellationToken);
        Task<IEnumerable<LookupsDto>> GetLookupsWithTypeAndAux(string Type, string Aux1, CancellationToken cancellationToken);
        Task<IEnumerable<LookupsDto>> GetLookupsWithType(string Type, CancellationToken cancellationToken);
        Task<LookupsDto> GetLookupById(Guid id, CancellationToken cancellationToken);
    }
}
