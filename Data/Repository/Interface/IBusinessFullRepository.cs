using Common.CommonModel;
using Data.Dto.Business;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Data.Repository
{
    public interface IBusinessFullRepository : IRepository<BusinessFull>
    {
        Task<bool> CreateBusinessAndForRegsiter(string UserName, string businessUrl,  string NameBusiness, string BusinessManeger, CancellationToken cancellationToken);
        Task<QueryBusinessDto> CreateBusiness(CreateBioBusinessDto createBusinessDto, Guid userId, CancellationToken cancellationToken);
        Task<List<ListBusinessDto>> GetListBusinessUser(Guid userId, CancellationToken cancellationToken);
        Task<List<ListBusinessDto>> GetListBusiness(CancellationToken cancellationToken);
        Task<BusinessDto> GetBusiness(string businessUrl, CancellationToken cancellationToken);
        //Task<BusinessDto> GetBioBusiness(string businessUrl, CancellationToken cancellationToken);
        int GetCountBusinessFull(Guid userId, CancellationToken cancellationToken);
    }
}
