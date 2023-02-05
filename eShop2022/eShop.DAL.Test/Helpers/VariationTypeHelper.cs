using eShop.DAL.Entities;
using eShop.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class VariationTypeHelper : BaseHelper<VariationType>
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;

        public VariationTypeHelper(IAppUnitOfWork unitOfWork, CancellationToken token)
        {
            _unitOfWork = unitOfWork;
            _token = token;
        }

        public VariationType GetTestVariationType(Guid variationTypeGuid)
        {
            VariationType variationType = new VariationType()
            {
                Guid = variationTypeGuid,
                Name = "Test VariationType Name",
                Description = "Test VariationType Description"
            };

            UpdateEntity(variationType);

            return variationType;

        }

        public override async Task<VariationType> InsertAsync(Guid variationTypeGuid)
        {
            VariationType variationType = GetTestVariationType(variationTypeGuid);

            await _unitOfWork.VariationTypeRepository.InsertAsync(variationType, _token);
            await _unitOfWork.SaveChangesAsync(_token);

            return variationType;
        }

        public override async Task DeleteAsync(Guid variationTypeGuid)
        {
            VariationType variationType = await _unitOfWork.VariationTypeRepository.GetByGuidAsync(Constants.VariationTypeGuid, _token);

            _unitOfWork.VariationTypeRepository.Delete(variationType, _token);
            await _unitOfWork.SaveChangesAsync(_token);
        }

        public override async Task CleanUpAsync()
        {
        }

    }
}
