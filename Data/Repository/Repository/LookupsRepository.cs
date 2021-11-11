using Common.Interface;
using Common.Utilities;
using Data.Dto.Lookups;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class LookupsRepository : Repository<Lookups>, ILookupsRepository, IScopedDependency
    {
        private IJsonConvertCommon jsonConvert;
        public LookupsRepository(VencerDbContext dbContext)
            : base(dbContext)
        {
            jsonConvert = new JsonConvertCommon();
        }

        public async Task<LookupsDto> GetLookupById(Guid id, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Where(f => f.Id == id).Select(s => new LookupsDto
            {
                Type = s.Type,
                Id = s.Id,
                Aux1 = s.Aux1,
                Aux2 = s.Aux2,
                Code = s.Code,
                IsActive = s.IsActive,
                Title = s.Title
            }).FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<LookupsDto> GetLookupWithType(string Type, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Where(s => s.Type == Type && s.IsActive)
            .Select(s => new LookupsDto
            {
                Aux1 = s.Aux1,
                Aux2 = s.Aux2,
                Code = s.Code,
                Id = s.Id,
                IsActive = s.IsActive,
                Title = s.Title,
                Type = s.Type
            }).FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<LookupsDto> GetLookupWithTypeAndAux(string Type, string Aux1, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Where(s => s.Type == Type && s.Aux1 == Aux1 && s.IsActive)
            .Select(s => new LookupsDto
            {
                Aux1 = s.Aux1,
                Aux2 = s.Aux2,
                Code = s.Code,
                Id = s.Id,
                IsActive = s.IsActive,
                Title = s.Title,
                Type = s.Type
            }).FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<LookupsDto> GetLookupWithTypeAndAuxAndCode(string Type, int Code, string Aux1, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Where(s => s.Type == Type && s.Code == Code && s.Aux1 == Aux1 && s.IsActive)
            .Select(s => new LookupsDto
            {
                Aux1 = s.Aux1,
                Aux2 = s.Aux2,
                Code = s.Code,
                Id = s.Id,
                IsActive = s.IsActive,
                Title = s.Title,
                Type = s.Type
            }).FirstOrDefaultAsync(cancellationToken);
        }



        public async Task<IEnumerable<LookupsDto>> GetLookupsWithTypeAndAux(string Type, string Aux1, CancellationToken cancellationToken)
        {
            var list = await TableNoTracking.Where(s => s.Type == Type && s.Aux1 == Aux1 && s.IsActive)
             .Select(s => new LookupsDto
             {
                 Aux1 = s.Aux1,
                 Aux2 = s.Aux2,
                 Code = s.Code,
                 Id = s.Id,
                 IsActive = s.IsActive,
                 Title = s.Title,
                 Type = s.Type
             }).ToListAsync(cancellationToken);

            return list;
        }
        public async Task<IEnumerable<LookupsDto>> GetLookupsWithType(string Type, CancellationToken cancellationToken)
        {
            var list = await TableNoTracking.Where(s => s.Type == Type && s.IsActive)
             .Select(s => new LookupsDto
             {
                 Aux1 = s.Aux1,
                 Aux2 = s.Aux2,
                 Code = s.Code,
                 Id = s.Id,
                 IsActive = s.IsActive,
                 Title = s.Title,
                 Type = s.Type
             }).ToListAsync(cancellationToken);

            return list;
        }
    }
}
