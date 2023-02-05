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
        private readonly IeShopUnitOfWork _unitOfWork;

        public VariationTypeHelper(IeShopUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public override VariationType Insert(Guid variationTypeGuid)
        {
            VariationType variationType = GetTestVariationType(variationTypeGuid);

            _unitOfWork.VariationTypeRepository.Insert(variationType);
            _unitOfWork.SaveChanges();

            return variationType;
        }

        public override void Delete(Guid variationTypeGuid)
        {
            VariationType variationType = _unitOfWork.VariationTypeRepository.GetByGuid(Constants.VariationTypeGuid);

            _unitOfWork.VariationTypeRepository.Delete(variationType);
            _unitOfWork.SaveChanges();
        }

        public override void CleanUp()
        {
        }

    }
}
