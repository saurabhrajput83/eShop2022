using eShop.DAL.Entities;
using eShop.DAL.UnitOfWork;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class ProductHelper : BaseHelper<Product>
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly BrandHelper _brandHelper;
    

        public ProductHelper(IAppUnitOfWork unitOfWork, CancellationToken token)
        {
            _unitOfWork = unitOfWork;
            _token = token;
            _brandHelper = new BrandHelper(_unitOfWork, _token);
        }

        public async Task<Product> GetTestProduct(Guid productGuid)
        {
            Brand brand = await _brandHelper.InsertAsync(Constants.BrandGuid);

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

        public override async Task<Product> InsertAsync(Guid productGuid)
        {
            Product product = await GetTestProduct(productGuid);

            await _unitOfWork.ProductRepository.InsertAsync(product, _token);
            await _unitOfWork.SaveChangesAsync(_token);

            return product;
        }

        public override async Task DeleteAsync(Guid productGuid)
        {
            Product product = await _unitOfWork.ProductRepository.GetByGuidAsync(productGuid, _token);

            _unitOfWork.ProductRepository.Delete(product, _token);
            await _unitOfWork.SaveChangesAsync(_token);
        }

        public override async Task CleanUpAsync()
        {
            await _brandHelper.DeleteAsync(Constants.BrandGuid);
            await _brandHelper.CleanUpAsync();
        }

    }
}
