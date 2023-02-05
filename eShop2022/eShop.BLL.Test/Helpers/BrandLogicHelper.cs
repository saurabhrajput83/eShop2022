using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Logics.Interfaces;
using eShop.BLL.Logging;
using eShop.DAL.Implementations;

using eShop.DAL.Main;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.BLL.Services;

namespace eShop.BLL.Test.Helpers
{
    public class BrandLogicHelper : BaseHelper<BrandFullView>
    {
        private readonly IAppServices _appServices;

        public BrandLogicHelper(IAppServices AppServices)
        {
            _appServices = AppServices;
        }

        public BrandFullView GetTestBrandView(Guid brandGuid)
        {
            BrandFullView brandView = new BrandFullView()
            {
                Guid = brandGuid,
                Name = "Test Brand Name",
                Description = "Test Brand Description",
                IsHidden = false,
            };

            UpdateView(brandView);

            return brandView;

        }

        public override async Task<BrandFullView> InsertAsync(Guid brandGuid)
        {
            BrandFullView brandView = GetTestBrandView(brandGuid);
            return await _appServices.BrandLogic.InsertAsync(brandView);
        }

        public override async Task DeleteAsync(Guid brandGuid)
        {
            await _appServices.BrandLogic.DeleteAsync(brandGuid);
        }

        public override async Task CleanUpAsync()
        {
        }

    }
}
