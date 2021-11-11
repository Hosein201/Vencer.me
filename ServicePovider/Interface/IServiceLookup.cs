using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Interface;
using Data.Dto.Lookups;

namespace ServicePovider
{
    public interface IServiceLookup: ITransientDependency
    {
        Task<LookupsDto> GetLookupWithType(string Type, CancellationToken cancellationToken);
        Task<LookupsDto> GetLookupWithTypeAndAux(string Type, string Aux1, CancellationToken cancellationToken);
        Task<LookupsDto> GetLookupWithTypeAndAuxAndCode(string Type, int Code, string Aux1, CancellationToken cancellationToken);
        Task<IEnumerable<LookupsDto>> GetLookupsWithTypeAndAux(string Type, string Aux1, CancellationToken cancellationToken);
        Task<IEnumerable<LookupsDto>> GetLookupsWithType(string Type, CancellationToken cancellationToken);
        Task<LookupsDto> GetLookupById(Guid id, CancellationToken cancellationToken);

    }
}
