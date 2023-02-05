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
        private readonly BrandLogicHelper _BrandLogicHelper;

        public ProductLogicHelper(IAppServices AppServices)
        {
            _appServices = AppServices;
            _BrandLogicHelper= new BrandLogicHelper(_appServices);
        }

        public ProductFullView GetTestProductView(Guid productGuid)
        {
            BrandFullView brand = _BrandLogicHelper.Insert(Constants.BrandGuid);

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

        public override ProductFullView Insert(Guid productGuid)
        {
            ProductFullView productView = GetTestProductView(productGuid);
            return _appServices.ProductLogic.Insert(productView);
        }

        public override void Delete(Guid productGuid)
        {
            _appServices.ProductLogic.Delete(productGuid);
        }

        public override void CleanUp()
        {
            _BrandLogicHelper.Delete(Constants.BrandGuid);
            _BrandLogicHelper.CleanUp();
        }

    }
}
