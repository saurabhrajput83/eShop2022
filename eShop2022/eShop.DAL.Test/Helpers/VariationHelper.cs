using eShop.DAL.Entities;
using eShop.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class VariationHelper : BaseHelper<Variation>
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly VariationTypeHelper _variationTypeHelper;

        public VariationHelper(IAppUnitOfWork unitOfWork, CancellationToken token)
        {
            _unitOfWork = unitOfWork;
            _token = token;
            _variationTypeHelper = new VariationTypeHelper(_unitOfWork, _token);

        }

        public async Task<Variation> GetTestVariation(Guid variationGuid)
        {
            VariationType variationType = await _variationTypeHelper.InsertAsync(Constants.VariationTypeGuid);

            Variation variation = new Variation()
            {
                Guid = variationGuid,
                Name = "Test Variation Name",
                Description = "Test Variation Description",
                IsHidden = false,
                VariationTypeId = variationType.Id,
            };

            UpdateEntity(variation);

            return variation;

        }

        public override async Task<Variation> InsertAsync(Guid variationGuid)
        {
            Variation variation = await GetTestVariation(variationGuid);

            await _unitOfWork.VariationRepository.InsertAsync(variation, _token);
            await _unitOfWork.SaveChangesAsync(_token);

            return variation;
        }

        public override async Task DeleteAsync(Guid variationGuid)
        {
            Variation variation = await _unitOfWork.VariationRepository.GetByGuidAsync(Constants.VariationGuid, _token);

            _unitOfWork.VariationRepository.Delete(variation, _token);
            await _unitOfWork.SaveChangesAsync(_token);
        }

        public override async Task CleanUpAsync()
        {
            await _variationTypeHelper.DeleteAsync(Constants.VariationTypeGuid);
            await _variationTypeHelper.CleanUpAsync();
        }

    }
}
