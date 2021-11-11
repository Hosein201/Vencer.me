using Common.CommonModel;
using Data.Dto.Business;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServicePovider
{
    public class ServiceBusiness : IServiceBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServicePayment _servicePayment;
        public ServiceBusiness(IUnitOfWork unitOfWork, IServicePayment servicePayment)
        {
            _unitOfWork = unitOfWork;
            _servicePayment = servicePayment;
        }

        public async Task<bool> CreateBusinessAndForRegsiter(string userName, string businessUrl, string nameBusiness, string businessManeger,
            CancellationToken cancellationToken)
        {
            var createBusinessRegsiter = await _unitOfWork.BusinessFullRepository.CreateBusinessAndForRegsiter(userName, businessUrl,
                nameBusiness, businessManeger, cancellationToken);
            return createBusinessRegsiter;
        }

        public async Task<QueryBusinessDto> CreateBusiness(CreateBioBusinessDto createBusinessDto, Guid userId,double amount, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BusinessFullRepository.CreateBusiness(createBusinessDto, userId, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _servicePayment.AddPaymentForBuiness(userId, amount, cancellationToken);
            return result;
        }

        public async Task<List<ListBusinessDto>> GetListBusinessUser(Guid userId, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BusinessFullRepository.GetListBusinessUser(userId, cancellationToken);
        }

        public async Task<List<ListBusinessDto>> GetListBusiness(CancellationToken cancellationToken)
        {
            return await _unitOfWork.BusinessFullRepository.GetListBusiness( cancellationToken);
        }

        public async Task<BusinessDto> GetBusiness(string businessUrl, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BusinessFullRepository.GetBusiness(businessUrl, cancellationToken);
        }

        public Task<BusinessDto> GetBioBusiness(string businessUrl, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public int GetCountBusinessFull(Guid userId, CancellationToken cancellationToken)
        {
            return _unitOfWork.BusinessFullRepository.GetCountBusinessFull(userId, cancellationToken);
        }

        #region Edit

        public async Task<bool> EditDetailBusiness(EditDetailDto editDetail, string businessUrl, Guid userId, CancellationToken cancellationToken)
        {
            var result=await _unitOfWork.BioBusinessRepository.EditDetailBusiness(editDetail, businessUrl, userId, cancellationToken);

            if (!result)
                return false;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
              return true;
        }

        public async Task<bool> EditGalleryAndVidoeBusiness(EditGalleryDto editGalleryDto, string businessUrl, Guid userId, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BioBusinessRepository.EditGalleryAndVidoeBusiness(editGalleryDto, businessUrl, userId, cancellationToken);

            if (!result)
                return false;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> EditWorkHoursBusiness(EditWorkHoursDto editWorkHoursDto, string businessUrl, Guid userId, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BioBusinessRepository.EditWorkHoursBusiness(editWorkHoursDto, businessUrl, userId, cancellationToken);

            if (!result)
                return false;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> EditLogoBusiness(EditLogoBusinessDto editLogoBusinessDto, string businessUrl, Guid userId, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BioBusinessRepository.EditLogoBusiness(editLogoBusinessDto, businessUrl, userId, cancellationToken);

            if (!result)
                return false;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }

        #endregion
    }
}
