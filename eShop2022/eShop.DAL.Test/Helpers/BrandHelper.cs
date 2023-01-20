using eShop.DAL.Entities;
using eShop.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class BrandHelper : BaseHelper<Brand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public override Brand Insert(Guid brandGuid)
        {
            Brand brand = GetTestBrand(brandGuid);

            _unitOfWork.BrandRepository.Insert(brand);
            _unitOfWork.SaveChanges();

            return brand;
        }

        public override void Delete(Guid brandGuid)
        {
            Brand brand = _unitOfWork.BrandRepository.GetByGuid(Constants.BrandGuid);

            _unitOfWork.BrandRepository.Delete(brand);
            _unitOfWork.SaveChanges();
        }

        public override void CleanUp()
        {
        }

    }
}
