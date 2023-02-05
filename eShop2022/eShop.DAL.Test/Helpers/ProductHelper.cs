using eShop.DAL.Entities;
using eShop.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class ProductHelper : BaseHelper<Product>
    {
        private readonly IeShopUnitOfWork _unitOfWork;
        private readonly BrandHelper _brandHelper;

        public ProductHelper(IeShopUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _brandHelper = new BrandHelper(_unitOfWork);
        }

        public Product GetTestProduct(Guid productGuid)
        {
            Brand brand = _brandHelper.Insert(Constants.BrandGuid);

            Product product = new Product()
            {
                Guid = productGuid,
                Name = "Test Product Name",
                Description = "Test Product Description",
                IsHidden = false,
                BrandId = brand.Id,
                Breadth = 0,
                HasFreeShipping = false,
                Height = 0,
                ImageUrl = "",
                InfoUrl = "",
                IsFeatured = true,
                IsActive = true,
                IsTaxable = true,
                Length = 1,
                ListPrice = 23.00,
                ModelNumber = "Test Model",
                SellingPrice = 21.00,
                Summary = "Test Summary",
                Weight = 30
            };

            UpdateEntity(product);

            return product;

        }

        public override Product Insert(Guid productGuid)
        {
            Product product = GetTestProduct(productGuid);

            _unitOfWork.ProductRepository.Insert(product);
            _unitOfWork.SaveChanges();

            return product;
        }

        public override void Delete(Guid productGuid)
        {
            Product product = _unitOfWork.ProductRepository.GetByGuid(productGuid);

            _unitOfWork.ProductRepository.Delete(product);
            _unitOfWork.SaveChanges();
        }

        public override void CleanUp()
        {
            _brandHelper.Delete(Constants.BrandGuid);
            _brandHelper.CleanUp();
        }

    }
}
