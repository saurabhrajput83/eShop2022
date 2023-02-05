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
        private readonly IeShopUnitOfWork _unitOfWork;
        private readonly ProductHelper _productHelper;

        public ProductImageHelper(IeShopUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productHelper = new ProductHelper(_unitOfWork);
        }

        public ProductImage GetTestProductImage(Guid productImageGuid)
        {
            Product product = _productHelper.Insert(Constants.ProductGuid);

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

        public override ProductImage Insert(Guid productImageGuid)
        {
            ProductImage productImage = GetTestProductImage(productImageGuid);

            _unitOfWork.ProductImageRepository.Insert(productImage);
            _unitOfWork.SaveChanges();

            return productImage;
        }

        public override void Delete(Guid productImageGuid)
        {
            ProductImage productImage = _unitOfWork.ProductImageRepository.GetByGuid(Constants.ProductImageGuid);

            _unitOfWork.ProductImageRepository.Delete(productImage);
            _unitOfWork.SaveChanges();
        }

        public override void CleanUp()
        {
            _productHelper.Delete(Constants.ProductGuid);
            _productHelper.CleanUp();
        }

    }
}
