using eShop.DAL.Entities;
using eShop.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class VariationHelper : BaseHelper<Variation>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly VariationTypeHelper _variationTypeHelper;

        public VariationHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _variationTypeHelper = new VariationTypeHelper(_unitOfWork);
        }

        public Variation GetTestVariation(Guid variationGuid)
        {
            VariationType variationType = _variationTypeHelper.Insert(Constants.VariationTypeGuid);

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

        public override Variation Insert(Guid variationGuid)
        {
            Variation variation = GetTestVariation(variationGuid);

            _unitOfWork.VariationRepository.Insert(variation);
            _unitOfWork.SaveChanges();

            return variation;
        }

        public override void Delete(Guid variationGuid)
        {
            Variation variation = _unitOfWork.VariationRepository.GetByGuid(Constants.VariationGuid);

            _unitOfWork.VariationRepository.Delete(variation);
            _unitOfWork.SaveChanges();
        }

        public override void CleanUp()
        {
            _variationTypeHelper.Delete(Constants.VariationTypeGuid);
            _variationTypeHelper.CleanUp();
        }

    }
}
