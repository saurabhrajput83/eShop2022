using eShop.DAL.Entities;
using eShop.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class ProductImageHelper : BaseHelper<ProductImage>
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly ProductHelper _productHelper;

        public ProductImageHelper(IAppUnitOfWork unitOfWork, CancellationToken token)
        {
            _unitOfWork = unitOfWork;
            _token = token;
            _productHelper = new ProductHelper(_unitOfWork, _token);

        }

        public async Task<ProductImage> GetTestProductImage(Guid productImageGuid)
        {
            Product product = await _productHelper.InsertAsync(Constants.ProductGuid);

            ProductImage productImage = new ProductImage()
            {
                Guid = productImageGuid,
                AltTag = "Test ProductImage AltTag",
                ImageUrl = "Test ProductImage ImageUrl",
                IsDefault = true,
                ProductId = product.Id
            };

            UpdateEntity(productImage);

            return productImage;

        }

        public override async Task<ProductImage> InsertAsync(Guid productImageGuid)
        {
            ProductImage productImage = await GetTestProductImage(productImageGuid);

            await _unitOfWork.ProductImageRepository.InsertAsync(productImage, _token);
            await _unitOfWork.SaveChangesAsync(_token);

            return productImage;
        }

        public override async Task DeleteAsync(Guid productImageGuid)
        {
            ProductImage productImage = await _unitOfWork.ProductImageRepository.GetByGuidAsync(Constants.ProductImageGuid, _token);

            _unitOfWork.ProductImageRepository.Delete(productImage, _token);
            await _unitOfWork.SaveChangesAsync(_token);
        }

        public override async Task CleanUpAsync()
        {
            await _productHelper.DeleteAsync(Constants.ProductGuid);
            await _productHelper.CleanUpAsync();
        }

    }
}
