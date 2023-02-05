using eShop.DAL.Entities;
using eShop.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class BrandHelper : BaseHelper<Brand>
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;


        public BrandHelper(IAppUnitOfWork unitOfWork, CancellationToken token)
        {
            _unitOfWork = unitOfWork;
            _token = token;
        }

        public Brand GetTestBrand(Guid brandGuid)
        {
            Brand brand = new Brand()
            {
                Guid = brandGuid,
                Name = "Test Brand Name",
                Description = "Test Brand Description",
                IsHidden = false
            };

            UpdateEntity(brand);

            return brand;

        }

        public override async Task<Brand> InsertAsync(Guid brandGuid)
        {
            Brand brand = GetTestBrand(brandGuid);

            await _unitOfWork.BrandRepository.InsertAsync(brand, _token);
            await _unitOfWork.SaveChangesAsync(_token);

            return brand;
        }

        public override async Task DeleteAsync(Guid brandGuid)
        {
            Brand? brand = await _unitOfWork.BrandRepository.GetByGuidAsync(Constants.BrandGuid, _token);

            _unitOfWork.BrandRepository.Delete(brand, _token);
            await _unitOfWork.SaveChangesAsync(_token);
        }

        public override async Task CleanUpAsync()
        {

        }

    }
}
