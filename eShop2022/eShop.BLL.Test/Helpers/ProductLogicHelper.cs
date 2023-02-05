using AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Logics.Interfaces;
using eShop.BLL.Services;
using eShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Test.Helpers
{
    public class ProductLogicHelper : BaseHelper<ProductFullView>
    {
        private readonly IAppServices _appServices;
        private readonly BrandLogicHelper _brandLogicHelper;

        public ProductLogicHelper(IAppServices AppServices)
        {
            _appServices = AppServices;
            _brandLogicHelper = new BrandLogicHelper(_appServices);
        }

        public async Task<ProductFullView> GetTestProductView(Guid productGuid)
        {
            BrandFullView brand = await _brandLogicHelper.InsertAsync(Constants.BrandGuid);

            ProductFullView productView = new ProductFullView()
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

            UpdateView(productView);

            return productView;

        }

        public override async Task<ProductFullView> InsertAsync(Guid productGuid)
        {
            ProductFullView productView = await GetTestProductView(productGuid);
            return await _appServices.ProductLogic.InsertAsync(productView);
        }

        public override async Task DeleteAsync(Guid productGuid)
        {
            await _appServices.ProductLogic.DeleteAsync(productGuid);
        }

        public override async Task CleanUpAsync()
        {
            await _brandLogicHelper.DeleteAsync(Constants.BrandGuid);
            await _brandLogicHelper.CleanUpAsync();
        }

    }
}
